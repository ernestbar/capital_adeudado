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
/// Descripción breve de nafibo_formato
/// </summary>
namespace terrasur
{
    public class nafibo_formato
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public nafibo_formato() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable FormatoNafibo(string Numero_contrato, DateTime Fecha, int Id_moneda)
        {
            Numero_contrato = ',' + Numero_contrato.Trim().Trim(',') + ',';

            DbCommand cmd = db1.GetStoredProcCommand("nafibo_FormatoNafibo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "numero_contrato", DbType.String, Numero_contrato);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
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
            tabla2.Columns.Add("num_row", typeof(int));
            tabla2.Columns.Add("num_contrato", typeof(string));
            tabla2.Columns.Add("num_cuotas_totales", typeof(int));
            tabla2.Columns.Add("num_cuotas_pagadas", typeof(int));
            tabla2.Columns.Add("num_cuotas_pendientes", typeof(int));
            tabla2.Columns.Add("fecha_vencimiento", typeof(string));
            tabla2.Columns.Add("total_pagado", typeof(decimal));
            tabla2.Columns.Add("monto_otorgado", typeof(decimal));
            tabla2.Columns.Add("estado", typeof(string));
            tabla2.Columns.Add("plazo", typeof(int));
            tabla2.Columns.Add("plazo_remanente", typeof(int));
            tabla2.Columns.Add("tasa_interes", typeof(decimal));
            tabla2.Columns.Add("monto_saldo", typeof(decimal));

            int num_row = 1;
            decimal num_dias_mes = Convert.ToDecimal((Convert.ToDouble(365) / Convert.ToDouble(12)));
            foreach (DataRow fila in tabla.Rows)
            {
                DataRow fila2 = tabla2.NewRow();
                fila2["num_row"] = num_row;
                fila2["num_contrato"] = fila["numero"].ToString();
                fila2["num_cuotas_totales"] = (int)fila["total_num_cuotas"];
                fila2["num_cuotas_pagadas"] = (int)fila["realizado_num_cuotas"];
                fila2["num_cuotas_pendientes"] = (int)fila["restante_num_cuotas"];
                decimal restante_num_cuotas = Convert.ToDecimal((int)fila["restante_num_cuotas"]);
                decimal aux_num_dias = restante_num_cuotas * num_dias_mes;
                //fila2["fecha_vencimiento"] = ((DateTime)fila["p_fecha"]).AddDays(Convert.ToDouble(aux_num_dias)).ToString("d");
                fila2["fecha_vencimiento"] = ((DateTime)fila["p_fecha_proximo"]).AddDays(Convert.ToDouble(aux_num_dias)).ToString("d");
                fila2["total_pagado"] = (decimal)fila["realizado_amortizacion"];
                fila2["monto_otorgado"] = (decimal)fila["precio_final"];
                fila2["estado"] = fila["estado"].ToString();
                fila2["plazo"] = (int)(((decimal)(int)fila["total_num_cuotas"]) * num_dias_mes);
                fila2["plazo_remanente"] = (int)(((decimal)(int)fila["restante_num_cuotas"]) * num_dias_mes);
                fila2["tasa_interes"] = (decimal)fila["interes_corriente"];
                fila2["monto_saldo"] = (decimal)fila["p_saldo"];
                tabla2.Rows.Add(fila2);
                num_row += 1;
            }
            return tabla2;
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion

    }
}