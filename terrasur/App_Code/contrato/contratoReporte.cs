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
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for contratoReporte
/// </summary>
/// 
namespace terrasur
{
    public class contratoReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Constructores
        public contratoReporte()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ReporteEstadoCuenta(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contrato_ReporteEstadoCuenta");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            return tabla;
        }

        public static DataTable ReporteEstadoCuentaDesfase(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contrato_ReporteEstadoCuentaDesfazada");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            return tabla;
        }
        public static DataTable ReporteDatosContratoEstadoCuenta(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contrato_ReporteDatosContratoEstadoCuenta");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            return tabla;
        }
        public static DataTable ReportePlanPagosOriginal(decimal Capital, decimal Inicial, int Num_cuotas, int Num_gracia, decimal Interes, decimal Desgravamen, decimal Mantenimiento, DateTime Fecha_inicio)
        {
            DataTable tabla = simular.tabla_plan_simulado(simular.lista_plan_simulado(Capital, Inicial, Num_cuotas, Num_gracia, Interes, Desgravamen, Mantenimiento, Fecha_inicio));
            return tabla;
        }

        public static DataTable ReportePlanPagosRestante(int Id_contrato, bool Preferencial, int Id_pago, decimal Cuota_mensual, int Num_cuotas, DateTime Fecha_inicio_plan, decimal Interes, decimal Desgravamen, decimal Mantenimiento)
        {
            DataTable tabla = simular.tabla_plan_simulado(simular.lista_plan_restante_simulado(Id_contrato, Preferencial, Id_pago, Cuota_mensual, Num_cuotas, Fecha_inicio_plan, Interes, Desgravamen, Mantenimiento));
            return tabla;
        }
        public static DataTable ReportePagosRestantesTotales(int Id_contrato, bool Preferencial, int Id_pago, decimal Cuota_mensual, int Num_cuotas, DateTime Fecha_inicio_plan, decimal Interes, decimal Desgravamen, decimal Mantenimiento)
        {
            DataTable tabla = simular.tabla_plan_simulado_total(simular.lista_plan_restante_simulado(Id_contrato, Preferencial, Id_pago, Cuota_mensual, Num_cuotas, Fecha_inicio_plan, Interes, Desgravamen, Mantenimiento));
            return tabla;
        }
        //public static DataTable ReportePlanPagosRestante(int Cuotas_pagadas, int Id_pago, decimal Cuota_mensual, int Num_cuotas, DateTime Fecha_inicio_plan, decimal Interes, decimal Desgravamen, decimal Mantenimiento)
        //{
        //    DataTable tabla = simular.tabla_plan_simulado(simular.lista_plan_restante_simulado(Id_pago, Cuota_mensual, Num_cuotas, Fecha_inicio_plan, Interes, Desgravamen, Mantenimiento));
        //    return tabla;
        //}
        //public static DataTable ReportePagosRestantesTotales(int Cuotas_pagadas, int Id_pago, decimal Cuota_mensual, int Num_cuotas, DateTime Fecha_inicio_plan, decimal Interes, decimal Desgravamen, decimal Mantenimiento)
        //{
        //    DataTable tabla = simular.tabla_plan_simulado_total(simular.lista_plan_restante_simulado(Id_pago, Cuota_mensual, Num_cuotas, Fecha_inicio_plan, Interes, Desgravamen, Mantenimiento));
        //    return tabla;
        //}

        //public static DataTable ReportePlanPagosVigente(int Id_contrato, decimal Cuota_mensual, int Num_cuotas, DateTime Fecha_inicio_plan, decimal Interes, decimal Desgravamen, decimal Mantenimiento)
        public static DataTable ReportePlanPagosVigente(int Id_contrato, bool Preferencial, decimal Cuota_mensual, int Num_cuotas, DateTime Fecha_inicio_plan, decimal Interes, decimal Desgravamen, decimal Mantenimiento)
        {
            //int cont = 1;
            int Id_pago = 0;
            //PARA LOS PAGOS YA REALIZADOS
            DbCommand cmd = db1.GetStoredProcCommand("contrato_ReportePlanPagosVigente");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            Id_pago = Int32.Parse(tabla.Rows[(tabla.Rows.Count - 1)]["id_pago"].ToString());

            //PARA LOS PAGOS SIMULADOS
            DataTable tabla2 = simular.tabla_plan_simulado(simular.lista_plan_restante_simulado(Id_contrato, Preferencial, Id_pago, Cuota_mensual, Num_cuotas, Fecha_inicio_plan, Interes, Desgravamen, Mantenimiento));

            //Se unen ambos
            DataTable tabla_aux = tabla;
            foreach (DataRow fila in tabla2.Rows)
            {
                tabla_aux.ImportRow(fila);
            }
            return tabla_aux;
        }


        public static DataTable ReporteReversion(DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado, DateTime F_ini_desde, DateTime F_ini_hasta)
        {
            //[negocio],[localizacion_nombre],[sector_nombre],[fecha_reversion],[usuario],[contrato_numero],[motivo_nombre],[cliente_nombre],[manzano_codigo],[lote_codigo],[superficie_m2],[codigo_moneda]
            //[tipo_cambio],[capital_total],[capital_pagado],[capital_deudor]
            //[num_dias_mora],[num_cuotas_mora],[interes_penal],[promotor_nombre]
            //Orden:[negocio],[fecha_reversion]
            if (Consolidado == false) { return ReporteReversion_original(Desde, Hasta, Id_negocio, Id_moneda, F_ini_desde, F_ini_hasta); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteReversion_original(Desde, Hasta, Id_negocio, Id_moneda, F_ini_desde, F_ini_hasta);
                    tabla_bs = ReporteReversion_original(Desde, Hasta, Id_negocio, Id_segunda_moneda, F_ini_desde, F_ini_hasta);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteReversion_original(Desde, Hasta, Id_negocio, Id_segunda_moneda, F_ini_desde, F_ini_hasta);
                    tabla_bs = ReporteReversion_original(Desde, Hasta, Id_negocio, Id_moneda, F_ini_desde, F_ini_hasta);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "capital_total,capital_pagado,capital_deudor", false, false, "", "negocio,fecha_reversion");
            }
        }
        private static DataTable ReporteReversion_original(DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, DateTime F_ini_desde, DateTime F_ini_hasta)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contrato_ReporteReversion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);

            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);

            db1.AddInParameter(cmd, "f_ini_desde", DbType.DateTime, F_ini_desde);
            db1.AddInParameter(cmd, "f_ini_hasta", DbType.DateTime, F_ini_hasta);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PlanesOriginales(DateTime Fecha, string Num_contrato, int Id_moneda)
        {
            //[id_contrato],[numero],[preferencial],[precio_final],[cuota_inicial],[num_cuotas],
            //[seguro],[mantenimiento_sus],[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan]

            DbCommand cmd = db1.GetStoredProcCommand("contrato_PlanesOriginales");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PlanesVigentes(DateTime Fecha, string Num_contrato, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contrato_PlanesVigentes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static StringBuilder ReportePlanPagosOriginalesVigentes(DateTime Fecha, bool Originales, string Num_contrato, int Id_moneda)
        {
            StringBuilder resultado = new System.Text.StringBuilder();

            if (Originales == true)
            {
                DataTable tabla_contratos = PlanesOriginales(Fecha, Num_contrato, Id_moneda);
                foreach (DataRow fila_contrato in tabla_contratos.Rows)
                {
                    List<sim_pago> lista_pagos = simular.lista_plan_simulado((decimal)fila_contrato["precio_final"], (decimal)fila_contrato["cuota_inicial"], (int)fila_contrato["num_cuotas"], 0, (decimal)fila_contrato["interes_corriente"], (decimal)fila_contrato["seguro"], (decimal)fila_contrato["mantenimiento_sus"], (DateTime)fila_contrato["fecha_inicio_plan"]);
                    int num_pago = 0;
                    foreach (sim_pago pago_simulado in lista_pagos)
                    {
                        resultado.Append(fila_contrato["numero"].ToString());
                        resultado.Append(',' + num_pago.ToString());
                        resultado.Append(',' + pago_simulado.fecha_proximo.ToString("d"));
                        resultado.Append(',' + pago_simulado.amortizacion.ToString("F2").Replace(',', '.'));
                        resultado.Append(',' + pago_simulado.interes.ToString("F2").Replace(',', '.'));
                        resultado.Append(',' + pago_simulado.monto_pago.ToString("F2").Replace(',', '.'));
                        resultado.Append(',' + pago_simulado.saldo.ToString("F2").Replace(',', '.'));
                        resultado.Append(';');
                        num_pago += 1;
                    }
                }
            }
            else
            {
                DataTable tabla = PlanesVigentes(Fecha, Num_contrato, Id_moneda);
                if (tabla.Rows.Count > 0)
                {
                    int numero_contrato = int.Parse(tabla.Rows[0]["numero"].ToString());
                    int num_filas = tabla.Rows.Count;
                    int num_pago = 0;
                    for (int index = 0; index < num_filas; index++)
                    {
                        resultado.Append(numero_contrato);
                        resultado.Append(',' + num_pago.ToString());
                        resultado.Append(',' + ((DateTime)tabla.Rows[index]["fecha"]).ToString("d"));
                        resultado.Append(',' + ((DateTime)tabla.Rows[index]["fecha_proximo"]).ToString("d"));
                        resultado.Append(',' + ((decimal)tabla.Rows[index]["amortizacion"]).ToString("F2").Replace(',', '.'));
                        resultado.Append(',' + ((decimal)tabla.Rows[index]["interes"]).ToString("F2").Replace(',', '.'));
                        resultado.Append(',' + ((decimal)tabla.Rows[index]["monto_pago"]).ToString("F2").Replace(',', '.'));
                        resultado.Append(',' + ((decimal)tabla.Rows[index]["saldo"]).ToString("F2").Replace(',', '.'));
                        resultado.Append(",E");
                        resultado.Append(';');

                        num_pago += 1;
                        bool simular_pagos = false;
                        if (index + 1 == num_filas) simular_pagos = true;
                        else
                        {
                            if (index + 1 < num_filas)
                                if (int.Parse(tabla.Rows[index + 1]["numero"].ToString()) != numero_contrato)
                                    simular_pagos = true;
                        }

                        if (simular_pagos == true)
                        {
                            ReportePlanPagosVigente_SimularPagos(
                                //ref tabla_general
                                ref resultado
                                , (DateTime)tabla.Rows[index]["fecha"]
                                , (DateTime)tabla.Rows[index]["fecha_proximo"]
                                , (int)tabla.Rows[index]["num_cuotas"]
                                , (decimal)tabla.Rows[index]["seguro"]
                                , (int)tabla.Rows[index]["seguro_meses"]
                                , (DateTime)tabla.Rows[index]["seguro_fecha"]
                                , (decimal)tabla.Rows[index]["mantenimiento_sus"]
                                , (int)tabla.Rows[index]["mantenimiento_meses"]
                                , (DateTime)tabla.Rows[index]["mantenimiento_fecha"]
                                , (decimal)tabla.Rows[index]["interes"]
                                , (int)tabla.Rows[index]["interes_dias"]
                                , (int)tabla.Rows[index]["interes_dias_total"]
                                , (DateTime)tabla.Rows[index]["interes_fecha"]
                                , (decimal)tabla.Rows[index]["monto_pago"]
                                , (decimal)tabla.Rows[index]["amortizacion"]
                                , (decimal)tabla.Rows[index]["saldo"]

                                , (decimal)tabla.Rows[index]["pp_cuota_base"]
                                , (DateTime)tabla.Rows[index]["pp_fecha_inicio_plan"]
                                , (decimal)tabla.Rows[index]["pp_seguro"]
                                , (decimal)tabla.Rows[index]["pp_mantenimiento_sus"]
                                , (decimal)tabla.Rows[index]["pp_interes_corriente"]

                                , numero_contrato

                                , num_pago
                            );
                            if (index + 1 < num_filas) numero_contrato = int.Parse(tabla.Rows[index + 1]["numero"].ToString());
                            num_pago = 0;
                        }
                    }
                }
            }
            return resultado;
        }

        protected static void ReportePlanPagosVigente_SimularPagos(
            //ref DataTable tabla_general,
            ref StringBuilder resultado,
            DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha,
            decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes,
            int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo,

            decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, decimal pp_seguro, decimal pp_mantenimiento_sus, decimal pp_interes_corriente,

            int numero_contrato

            ,int num_pago
            )
        {
            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
                , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
                , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);

                //DataRow fila = tabla_general.NewRow();
                //fila["ncontrato"] = numero_contrato;
                //fila["ncuota"] = num_pago.ToString();
                //fila["fecha_pago"] = pago_simulado.fecha;
                //fila["fecha_proximo"] = pago_simulado.fecha_proximo;
                //fila["amortizacion"] = pago_simulado.amortizacion.ToString("F2").Replace(',', '.');
                //fila["interes"] = pago_simulado.interes.ToString("F2").Replace(',', '.');
                //fila["monto_pago"] = pago_simulado.monto_pago.ToString("F2").Replace(',', '.');
                //fila["saldo_capital"] = pago_simulado.saldo.ToString("F2").Replace(',', '.');
                //fila["estado_cuota"] = "P";
                //tabla_general.Rows.Add(fila);

                //try
                //{
                resultado.Append(numero_contrato);
                resultado.Append(',' + num_pago.ToString());
                resultado.Append(',' + pago_simulado.fecha.ToString("d"));
                resultado.Append(',' + pago_simulado.fecha_proximo.ToString("d"));
                resultado.Append(',' + pago_simulado.amortizacion.ToString("F2").Replace(',', '.'));
                resultado.Append(',' + pago_simulado.interes.ToString("F2").Replace(',', '.'));
                resultado.Append(',' + pago_simulado.monto_pago.ToString("F2").Replace(',', '.'));
                resultado.Append(',' + pago_simulado.saldo.ToString("F2").Replace(',', '.'));
                resultado.Append(",P");
                resultado.Append(';');
                //}
                //catch { }
                num_pago += 1;
            }
        }

        #endregion
    }
}