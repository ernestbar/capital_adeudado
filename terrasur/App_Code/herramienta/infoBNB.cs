using System;
using System.Collections.Generic;
using System.Web;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de infoBNB
/// </summary>
namespace terrasur
{
    public class infoBNB
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public infoBNB() { }
        #endregion

        #region Métodos que NO requieren constructor
        private static List<string> VerificacionContratosExistentes(string contratos)
        {
            //[num_contrato]
            DbCommand cmd = db1.GetStoredProcCommand("b_VerificacionContratosExistentes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "contratos", DbType.String, contratos);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            List<string> lista_inexistentes = new List<string>();

            string[] lista_contratos = contratos.Split(',');
            if (tabla.Rows.Count != lista_contratos.Length)
            {
                for (int j = 0; j < lista_contratos.Length; j++)
                {
                    bool existe = false;
                    foreach (DataRow fila in tabla.Rows)
                    {
                        if (fila["num_contrato"].ToString() == lista_contratos[j].Trim())
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false) { lista_inexistentes.Add(lista_contratos[j].Trim()); }
                }
            }

            return lista_inexistentes;
        }

        public static DataTable VerificacionContratos(string contratos, DateTime fecha,
            ref int num_total, ref int num_error, ref int num_alerta)
        {
            //[id_contrato],[num_contrato],[moneda],[estado_nombre],[negocio_nombre],[saldo]
            //[error],[alerta],[error_alerta],[descripcion]
            DbCommand cmd = db1.GetStoredProcCommand("b_VerificacionEstadoContratos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "contratos", DbType.String, contratos);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            List<string> lista_inexistentes = VerificacionContratosExistentes(contratos);
            if (lista_inexistentes.Count > 0)
            {
                foreach (string num_contrato in lista_inexistentes)
                {
                    DataRow fila = tabla.NewRow();
                    fila["num_contrato"] = num_contrato;
                    fila["error"] = 1;
                    fila["alerta"] = 0;
                    fila["error_alerta"] = "Error";
                    fila["descripcion"] = "Inexistente (No existe un contrato con el número: " + num_contrato + ")";
                    tabla.Rows.Add(fila);
                }
            }

            num_total = contratos.Split(',').Length;
            num_error = 0;
            num_alerta = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                if (((int)fila["error"]) == 1) { num_error += 1; }
                if (((int)fila["alerta"]) == 1) { num_alerta += 1; }
            }

            tabla.DefaultView.Sort = "error desc,alerta desc,descripcion";
            return tabla.DefaultView.ToTable();
        }


        public static DataTable ListaDatos1(string Contratos, DateTime Fecha, int Id_moneda, bool Consolidado)
        {
            DataTable tabla;
            if (Consolidado == false) { tabla = ListaDatos1_original(Contratos, Fecha, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ListaDatos1_original(Contratos, Fecha, Id_moneda);
                    tabla_bs = ListaDatos1_original(Contratos, Fecha, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ListaDatos1_original(Contratos, Fecha, Id_segunda_moneda);
                    tabla_bs = ListaDatos1_original(Contratos, Fecha, Id_moneda);
                }
                tabla = general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento_efectivo,precio_final,cuota_inicial,cuota_base,valor_final,aporte_total,aporte_interes,aporte_capital,saldo,pp_mantenimiento_sus,pp_cuota_base,p_seguro,p_mantenimiento_sus,p_interes,p_monto_pago,p_amortizacion,p_saldo", false, false, "", "");
            }

            //Se obtienen los datos de los pagos que se adeudan
            int cuotas_num_total = 0; int cuotas_num_anteriores = 0; int cuotas_num_restantes = 0;
            int num_cuotas_adeuda = 0; decimal monto_adeuda = 0; decimal capital_adeuda = 0; decimal interes_adeuda = 0; decimal mantenimiento_adeuda = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                PagosRestantes(/*Fecha, */ref num_cuotas_adeuda, ref monto_adeuda, ref capital_adeuda, ref interes_adeuda, ref mantenimiento_adeuda,
                    (decimal)fila["pp_interes_corriente"], (decimal)fila["pp_mantenimiento_sus"], (decimal)fila["pp_seguro"], (decimal)fila["pp_cuota_base"], (DateTime)fila["pp_fecha_inicio_plan"]
                    , (int)fila["id_ultimo_pago"], (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"], (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"], (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);
                
                cuotas_num_anteriores = (int)fila["cuotas_num_anteriores"];
                cuotas_num_restantes = num_cuotas_adeuda;
                cuotas_num_total = cuotas_num_anteriores + cuotas_num_restantes;

                fila["cuotas_num_restantes"] = cuotas_num_restantes;
                fila["cuotas_num_total"] = cuotas_num_total;

                //fila["num_cuotas_adeuda"] = num_cuotas_adeuda;
                //fila["monto_adeuda"] = monto_adeuda;
                //fila["capital_adeuda"] = capital_adeuda;
                //fila["interes_adeuda"] = interes_adeuda;
                //fila["mantenimiento_adeuda"] = mantenimiento_adeuda;
            }
            return tabla;
        }

        private static DataTable ListaDatos1_original(string Contratos, DateTime Fecha, int Id_moneda)
        {
            //[grupo],[director],[promotor],[tipo_cambio]
            //[num_contrato],[fecha_registro],[negocio],[loc],[urb],[mzno],[lote]
            //[paterno],[materno],[nombres],[ci],[nit],[celular],[fax],[email],[casilla],[domicilio_direccion],[domicilio_fono],[domicilio_zona],[oficina_direccion],[oficina_fono],[oficina_zona]
            //[precio],[descuento_porcentaje],[descuento_efectivo],[precio_final],[cuota_inicial]
            //[interes_corriente],[num_cuotas],[cuota_base],[fecha_inicio_plan]
            //[fecha_ultimo_pago],[interes_fecha],[fecha_proximo]
            //[valor_final],[aporte_total],[aporte_interes],[aporte_capital],[saldo]
            //[cuotas_num_total],[cuotas_num_anteriores],[cuotas_num_restantes]
            //[pp_seguro],[pp_mantenimiento_sus],[pp_interes_corriente],[pp_cuota_base],[pp_fecha_inicio_plan]
            //[id_ultimo_pago],[p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            DbCommand cmd = db1.GetStoredProcCommand("b_ListaDatos1");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "contratos", DbType.String, Contratos);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        private static void PagosRestantes(/*DateTime Fecha,*/
            ref int num_cuotas_adeuda, ref decimal monto_adeuda, ref decimal capital_adeuda, ref decimal interes_adeuda, ref decimal mantenimiento_adeuda,
            decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago,
            DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha, decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes, int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
        {
            num_cuotas_adeuda = 0; monto_adeuda = 0; capital_adeuda = 0; interes_adeuda = 0; mantenimiento_adeuda = 0;

            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha, p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes, p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

            //Fecha = Fecha.Date.AddDays(1).AddSeconds(-1);
            DateTime Fecha_pago;
            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                Fecha_pago = pago_simulado.fecha_proximo;
                pago_simulado = new sim_pago(pago_simulado, Fecha_pago, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
                /*if (Fecha_pago < Fecha)
                {*/
                    num_cuotas_adeuda += 1;
                    monto_adeuda += pago_simulado.monto_pago;
                    capital_adeuda += pago_simulado.amortizacion;
                    interes_adeuda += pago_simulado.interes;
                    mantenimiento_adeuda += pago_simulado.mantenimiento_sus;
                /*}
                else { break; }*/
            }
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion

        
    }
}