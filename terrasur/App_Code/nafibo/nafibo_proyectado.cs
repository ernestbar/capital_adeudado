using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de nafibo_proyectado
/// </summary>
namespace terrasur
{
    public class nafibo_proyectado
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public nafibo_proyectado() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable TablaProyectado(DateTime Fecha, bool AjustarCuotas, bool CapitalInteres, bool Excel, int Id_moneda)
        {
            if (Fecha.Day != DateTime.DaysInMonth(Fecha.Year, Fecha.Month)) Fecha = Fecha.AddDays((-1) * Fecha.Day).AddDays(DateTime.DaysInMonth(Fecha.Year, Fecha.Month));
            DataTable tabla = DatosProyectado(Fecha, Id_moneda);
            if (AjustarCuotas == true) AjusteProyectado(ref tabla, Fecha);
            DataTable tabla_res = TablaProyeccion(tabla, Fecha);
            return FormatoProyectado(tabla_res, CapitalInteres, Excel);
        }

        protected static DataTable DatosProyectado(DateTime Fecha, int Id_moneda)
        {
            //[id_contrato],[numero]
            //[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan]
            //[realizado_num_cuotas]
            //[p_id_pago],[p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_proyectado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        protected static void AjusteProyectado(ref DataTable tabla_proyectado, DateTime Fecha)
        {
            //Se obtine la tabla de ajuste almacenada
            //[id_contrato],[num_cuota]
            DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_Fecha");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha.AddDays(1));
            DataTable tabla_ajuste_almacenada = db1.ExecuteDataSet(cmd).Tables[0];

            //Se realizan los ajustes en la tabla de proyectados
            foreach (DataRow fila_ajuste in tabla_ajuste_almacenada.Rows)
            {
                int id_contrato = ((int)fila_ajuste["id_contrato"]);
                int num_cuota = ((int)fila_ajuste["num_cuota"]);

                foreach (DataRow fila_proyectado in tabla_proyectado.Rows)
                {
                    if (((int)fila_proyectado["id_contrato"]) == id_contrato)
                    {
                        fila_proyectado["realizado_num_cuotas"] = num_cuota;
                        break;
                    }
                }
            }
        }

        protected static DataTable TablaProyeccion(DataTable tabla, DateTime Fecha)
        {
            //[fecha_emision],[institucion],[contrato],[ncuota],[fecha_pago],[interes],[capital],[monto]
            DataTable tabla_res = new DataTable();
            tabla_res.Columns.Add("fecha_emision", typeof(string));
            tabla_res.Columns.Add("institucion", typeof(string));
            tabla_res.Columns.Add("contrato", typeof(string));
            tabla_res.Columns.Add("ncuota", typeof(string));
            tabla_res.Columns.Add("fecha_pago", typeof(string));
            tabla_res.Columns.Add("interes", typeof(decimal));
            tabla_res.Columns.Add("capital", typeof(decimal));
            tabla_res.Columns.Add("monto", typeof(decimal));

            foreach (DataRow fila in tabla.Rows)
            {
                string num_contrato = fila["numero"].ToString();
                decimal pp_seguro = (decimal)fila["seguro"];
                decimal pp_mantenimiento_sus = (decimal)fila["mantenimiento_sus"];
                decimal pp_interes_corriente = (decimal)fila["interes_corriente"];
                decimal pp_cuota_base = (decimal)fila["cuota_base"];
                DateTime pp_fecha_inicio_plan = (DateTime)fila["fecha_inicio_plan"];
                int realizado_num_cuotas = (int)fila["realizado_num_cuotas"];

                sim_pago pago_simulado = new sim_pago((DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                    , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                    , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

                DateTime fecha_prox_pago = Fecha.AddDays(pp_fecha_inicio_plan.Day);

                //while (pago_simulado.saldo > 0)
                //{
                    pago_simulado = new sim_pago(pago_simulado, fecha_prox_pago, 1,
                        pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                        pp_mantenimiento_sus, pp_interes_corriente);

                    DataRow fila_cap_res = tabla_res.NewRow();
                    fila_cap_res["fecha_emision"] = Fecha.ToString("d");
                    fila_cap_res["institucion"] = "007";
                    fila_cap_res["contrato"] = num_contrato;
                    fila_cap_res["ncuota"] = realizado_num_cuotas + pago_simulado.num_cuotas;
                    fila_cap_res["fecha_pago"] = pago_simulado.fecha.ToString("d");
                    fila_cap_res["interes"] = pago_simulado.interes;
                    fila_cap_res["capital"] = pago_simulado.amortizacion;
                    fila_cap_res["monto"] = pago_simulado.monto_pago;
                    tabla_res.Rows.Add(fila_cap_res);

                //    realizado_num_cuotas = realizado_num_cuotas + pago_simulado.num_cuotas;
                //    fecha_prox_pago = fecha_prox_pago.AddMonths(1);
                //}
            }
            return tabla_res;
        }

        protected static DataTable FormatoProyectado(DataTable tabla, bool CapitalInteres, bool Excel)
        {
            if (CapitalInteres == false)
            {
                if (Excel == true) { return tabla; }
                else
                {
                    DataTable tabla_res = new DataTable();
                    tabla_res.Columns.Add("fecha_emision", typeof(string));
                    tabla_res.Columns.Add("institucion", typeof(string));
                    tabla_res.Columns.Add("contrato", typeof(string));
                    tabla_res.Columns.Add("ncuota", typeof(string));
                    tabla_res.Columns.Add("fecha_pago", typeof(string));
                    tabla_res.Columns.Add("interes", typeof(string));
                    tabla_res.Columns.Add("capital", typeof(string));
                    tabla_res.Columns.Add("monto", typeof(string));

                    foreach (DataRow fila in tabla.Rows)
                    {
                        DataRow fila_res = tabla_res.NewRow();
                        fila_res["fecha_emision"] = fila["fecha_emision"];
                        fila_res["institucion"] = fila["institucion"];
                        fila_res["contrato"] = fila["contrato"];
                        fila_res["ncuota"] = fila["ncuota"];
                        fila_res["fecha_pago"] = fila["fecha_pago"];
                        fila_res["interes"] = ((decimal)fila["interes"]).ToString("F2").Replace(",", ".");
                        fila_res["capital"] = ((decimal)fila["capital"]).ToString("F2").Replace(",", ".");
                        fila_res["monto"] = ((decimal)fila["monto"]).ToString("F2").Replace(",", ".");
                        tabla_res.Rows.Add(fila_res);
                    }
                    return tabla_res;
                }
            }
            else
            {
                DataTable tabla_res = new DataTable();
                tabla_res.Columns.Add("fecha_emision", typeof(string));
                tabla_res.Columns.Add("institucion", typeof(string));
                tabla_res.Columns.Add("contrato", typeof(string));
                tabla_res.Columns.Add("concepto", typeof(string));
                tabla_res.Columns.Add("ncuota", typeof(string));
                tabla_res.Columns.Add("fecha_pago", typeof(string));
                if (Excel == true) tabla_res.Columns.Add("monto", typeof(decimal));
                else tabla_res.Columns.Add("monto", typeof(string));

                foreach (DataRow fila in tabla.Rows)
                {
                    DataRow fila_res_cap = tabla_res.NewRow();
                    fila_res_cap["fecha_emision"] = fila["fecha_emision"];
                    fila_res_cap["institucion"] = fila["institucion"];
                    fila_res_cap["contrato"] = fila["contrato"];
                    fila_res_cap["concepto"] = "CAP";
                    fila_res_cap["ncuota"] = fila["ncuota"];
                    fila_res_cap["fecha_pago"] = fila["fecha_pago"];
                    if (Excel == true) fila_res_cap["monto"] = fila["capital"];
                    else fila_res_cap["monto"] = ((decimal)fila["capital"]).ToString("F2").Replace(",", ".");
                    tabla_res.Rows.Add(fila_res_cap);

                    DataRow fila_res_int = tabla_res.NewRow();
                    fila_res_int["fecha_emision"] = fila["fecha_emision"];
                    fila_res_int["institucion"] = fila["institucion"];
                    fila_res_int["contrato"] = fila["contrato"];
                    fila_res_int["concepto"] = "INT";
                    fila_res_int["ncuota"] = fila["ncuota"];
                    fila_res_int["fecha_pago"] = fila["fecha_pago"];
                    if (Excel == true) fila_res_int["monto"] = fila["interes"];
                    else fila_res_int["monto"] = ((decimal)fila["interes"]).ToString("F2").Replace(",", ".");
                    tabla_res.Rows.Add(fila_res_int);
                }
                return tabla_res;
            }
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion

    }
}