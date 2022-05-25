using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for inventarioReporte
/// </summary>
/// 
namespace terrasur
{
    public class inventarioReporte
    {

        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Constructores
        public inventarioReporte()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ReporteLoteDetalle(DateTime Fecha, int Id_localizacion, int Id_urbanizacion, int Id_manzano, int Id_estado, string Id_negocios, int Id_motivobloqueo)
        {
            //[id_lote],[id_usuario],[fecha_registro],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[anterior_propietario],[num_partida]
            DbCommand cmd = db1.GetStoredProcCommand("inventario_ReporteLoteDetalle");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "id_estado", DbType.Int32, Id_estado);
            db1.AddInParameter(cmd, "id_negocios", DbType.String, Id_negocios);
            db1.AddInParameter(cmd, "id_motivobloqueo", DbType.Int32, Id_motivobloqueo);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteLoteResumen(DateTime Fecha, string Id_negocio)
        {
            //[id_negocio],[id_localizacion],[id_urbanizacion]
            //[nombre_negocio],[nombre_localizacion],[nombre_urbanizacion],[codigo_manzano],[codigo]
            //[superficie_total],[costo_total],[precio_total],[numero_lotes],[num_lotes_disponibles]
            //[num_lotes_preasignados],[num_lotes_vendidos],[num_lotes_bloqueados],[num_lotes_reservados]
            DbCommand cmd = db1.GetStoredProcCommand("inventario_ReporteLoteResumen");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteLoteResumenSector(DateTime Fecha)
        {
            //[id_localizacion],[id_urbanizacion]
            //[nombre_localizacion],[nombre_urbanizacion],[codigo_manzano],[codigo]
            //[superficie_total],[costo_total],[precio_total],[numero_lotes],[num_lotes_disponibles]
            //[num_lotes_preasignados],[num_lotes_vendidos],[num_lotes_bloqueados],[num_lotes_reservados]
            DbCommand cmd = db1.GetStoredProcCommand("inventario_ReporteLoteResumenSector");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteLoteContrato(DateTime Fecha, int Id_urbanizacion, string Id_negocio, bool incluir_cuotas_restantes, bool incluir_contratos_saldo0)
        {
            //[negocio],[sector],[sector_codigo],[manzano],[lote],[estado],[num_contrato],[saldo],[num_cuotas_restantes]
            DbCommand cmd = db1.GetStoredProcCommand("inventario_ReporteLoteContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.String, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            if (incluir_cuotas_restantes == true) AgregarCuotasRestantes(Fecha, ref tabla);
            if (incluir_contratos_saldo0 == false) RetirarContratosSaldo0(ref tabla);
            return tabla;
        }
        protected static void AgregarCuotasRestantes(DateTime Fecha, ref DataTable tabla)
        {
            DataTable tabla_cuotas = new DataTable();
            tabla_cuotas.Columns.Add("num_contrato", typeof(string));
            tabla_cuotas.Columns.Add("num_cuotas_restantes", typeof(int));

            string cadena_contratos = "";
            int num_cadena_contratos = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                string num_contrato = fila["num_contrato"].ToString().Trim();
                decimal saldo = (decimal)fila["saldo"];
                if (num_contrato != "")
                {
                    DataRow fila_cuotas = tabla_cuotas.NewRow();
                    fila_cuotas["num_contrato"] = num_contrato;
                    if (saldo > 0)
                    {
                        fila_cuotas["num_cuotas_restantes"] = 1;
                        cadena_contratos += num_contrato;
                        num_cadena_contratos += 1;
                        if (num_cadena_contratos % 500 == 0) { cadena_contratos += ";"; }
                        else { cadena_contratos += ","; }
                    }
                    else { fila_cuotas["num_cuotas_restantes"] = 0; }
                    tabla_cuotas.Rows.Add(fila_cuotas);
                }
            }

            //Se obtienen las cuotas restantes
            string res_cuotas = "";
            string[] grupo_contratos = cadena_contratos.TrimEnd(',').TrimEnd(';').Split(';');
            for (int j = 0; j < grupo_contratos.Length; j++)
            {
                DataTable tabla_repositorio = Tabla_Num_Cuotas_Restantes(Fecha, "," + grupo_contratos[j] + ",");
                foreach (DataRow fila in tabla_repositorio.Rows)
                    res_cuotas += fila["num_contrato"].ToString() + "," + fila["num_cuotas_pendientes"].ToString() + ";";
            }

            //Se agregan las cuotas restantes a la tabla de cuotas
            if (res_cuotas.TrimEnd(';') != "")
            {
                string[] lista_res_cuotas = res_cuotas.TrimEnd(';').Split(';');
                for (int j = 0; j < lista_res_cuotas.Length; j++)
                {
                    string num_contrato = lista_res_cuotas[j].Split(',')[0];
                    int num_cuotas_restantes = int.Parse(lista_res_cuotas[j].Split(',')[1]);
                    foreach (DataRow fila_cuotas in tabla_cuotas.Rows)
                    {
                        if (fila_cuotas["num_contrato"].ToString() == num_contrato)
                        {
                            fila_cuotas["num_cuotas_restantes"] = num_cuotas_restantes;
                            break;
                        }
                    }
                }
            }

            //Se agrega el campo de cuotas a la tabla original
            tabla.Columns.Add("num_cuotas_restantes", typeof(int));
            foreach (DataRow fila_cuotas in tabla_cuotas.Rows)
            {
                string num_contrato = fila_cuotas["num_contrato"].ToString();
                int num_cuotas_restantes = (int)fila_cuotas["num_cuotas_restantes"];
                foreach (DataRow fila in tabla.Rows)
                {
                    if (fila["num_contrato"].ToString() == num_contrato)
                    {
                        fila["num_cuotas_restantes"] = num_cuotas_restantes;
                        break;
                    }
                }
            }
        }
        protected static DataTable Tabla_Num_Cuotas_Restantes(DateTime Fecha, string numero_contrato)
        {
            //[num_contrato],[num_cuotas_pendientes]
            Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_FormatoNafibo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "numero_contrato", DbType.String, numero_contrato);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, 0);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            int Num_cuotas = 0; decimal Amortizacion = 0; decimal Seguro = 0; decimal Mantenimiento_sus = 0; decimal Interes_corriente = 0; decimal Monto_pago = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                contabilidadReporte.PagosRestantes((int)fila["id_contrato"], Fecha, ref Num_cuotas,
                    ref Amortizacion, ref Seguro, ref Mantenimiento_sus, ref Interes_corriente, ref Monto_pago,
                    (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                    (int)fila["id_ultimo_pago"]
                    , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                    , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                    , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);
                fila["restante_num_cuotas"] = Num_cuotas;
                //fila["restante_amortizacion"] = Amortizacion;
                fila["restante_seguro"] = Seguro;
                fila["restante_mantenimiento"] = Mantenimiento_sus;
                fila["restante_interes"] = Interes_corriente;
                fila["restante_total"] = Monto_pago;

                fila["total_num_cuotas"] = (int)fila["realizado_num_cuotas"] + Num_cuotas;
                //fila["total_precio"] = (decimal)fila["realizado_amortizacion"] + Amortizacion;
                fila["total_seguro"] = (decimal)fila["realizado_seguro"] + Seguro;
                fila["total_mantenimiento"] = (decimal)fila["realizado_mantenimiento"] + Mantenimiento_sus;
                fila["total_interes"] = (decimal)fila["realizado_interes"] + Interes_corriente;
                fila["total_total"] = (decimal)fila["realizado_total"] + Monto_pago;
            }
            /*[id_contrato],[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],
            [cuota_base],[fecha_inicio_plan],[id_ultimo_pago],[estado]
            [p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            [realizado_num_cuotas],[realizado_amortizacion],[realizado_seguro],[realizado_mantenimiento],[realizado_interes],[realizado_total],
            [restante_num_cuotas],[restante_amortizacion],[restante_seguro],[restante_mantenimiento],[restante_interes],[restante_total],
            [total_num_cuotas],[total_precio],[total_seguro],[total_mantenimiento],[total_interes],[total_total]
            */
            DataTable tabla2 = new DataTable();
            tabla2.Columns.Add("num_contrato", typeof(string));
            tabla2.Columns.Add("num_cuotas_pendientes", typeof(int));
            decimal num_dias_mes = Convert.ToDecimal((Convert.ToDouble(365) / Convert.ToDouble(12)));
            foreach (DataRow fila in tabla.Rows)
            {
                DataRow fila2 = tabla2.NewRow();
                fila2["num_contrato"] = fila["numero"].ToString();
                fila2["num_cuotas_pendientes"] = (int)fila["restante_num_cuotas"];
                tabla2.Rows.Add(fila2);
            }
            return tabla2;
        }
        protected static void RetirarContratosSaldo0(ref DataTable tabla)
        {
            for (int j = tabla.Rows.Count - 1; j >= 0; j--)
                if (tabla.Rows[j]["num_contrato"].ToString() != "")
                    if (((decimal)tabla.Rows[j]["saldo"]) == 0)
                        tabla.Rows.RemoveAt(j);
        }
        #endregion
    }
}