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
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for contabilidadReporte
/// </summary>
/// 
namespace terrasur
{
    public class contabilidadReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Constructores
        public contabilidadReporte()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Cxc_NegocioUrbanizacion(DateTime Fecha, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[orden_negocio],[id_contrato],[cliente_paterno],[cliente_materno],[urbanizacion],[urbanizacion_corto],[manzano],[lote],[superficie_m2],[codigo_moneda]
            //[tipo_cambio],[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan],[id_ultimo_pago]

            //[realizado_num_cuotas],[realizado_amortizacion],[realizado_seguro],[realizado_mantenimiento],[realizado_interes],[realizado_total],
            //[restante_num_cuotas],[restante_amortizacion],[restante_seguro],[restante_mantenimiento],[restante_interes],[restante_total],
            //[total_num_cuotas],[total_precio],[total_seguro],[total_mantenimiento],[total_interes],[total_total]

            //p_fecha,p_fecha_proximo,p_num_cuotas,p_seguro,p_seguro_meses,p_seguro_fecha,p_mantenimiento_sus,p_mantenimiento_meses,p_mantenimiento_fecha,p_interes,p_interes_dias,p_interes_dias_total,p_interes_fecha,p_monto_pago,p_amortizacion,p_saldo
            //Orden:[orden_negocio],[urbanizacion],[numero]
            if (Consolidado == false) { return Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_moneda);
                    tabla_bs = Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_segunda_moneda);
                    tabla_bs = Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_final,mantenimiento_sus,cuota_base,realizado_amortizacion,realizado_seguro,realizado_mantenimiento,realizado_interes,realizado_total,restante_amortizacion,restante_seguro,restante_mantenimiento,restante_interes,restante_total,total_precio,total_seguro,total_mantenimiento,total_interes,total_total", false, false, "", "orden_negocio,urbanizacion,numero");
            }
        }
        private static DataTable Cxc_NegocioUrbanizacion_original(DateTime Fecha, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Cxc_NegocioUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
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
            return tabla;
        }


        public static DataTable VentasCobranzas_LocalizacionUrbanizacion(DateTime Inicio, DateTime Fin, int Traspaso, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[orden_negocio],[id_contrato],[numero],[cliente_paterno],[cliente_materno],[localizacion],[urbanizacion],[urbanizacion_corto],[manzano],[lote],[superficie_m2],[precio_m2_sus],[codigo_moneda]
            //[tipo_cambio],[precio_inicial],[descuento],[precio_final],[pago_monto],[pago_efectivo],[pago_dpr]
            //[pago_fecha],[num_recibo],[num_comprobante],[codigo_dpr]
            //Orden:[orden_negocio],[urbanizacion],[id_contrato]
            if (Consolidado == false) { return VentasCobranzas_LocalizacionUrbanizacion_original(Inicio, Fin, Traspaso, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = VentasCobranzas_LocalizacionUrbanizacion_original(Inicio, Fin, Traspaso, Id_negocio, Id_moneda);
                    tabla_bs = VentasCobranzas_LocalizacionUrbanizacion_original(Inicio, Fin, Traspaso, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = VentasCobranzas_LocalizacionUrbanizacion_original(Inicio, Fin, Traspaso, Id_negocio, Id_segunda_moneda);
                    tabla_bs = VentasCobranzas_LocalizacionUrbanizacion_original(Inicio, Fin, Traspaso, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_inicial,descuento,precio_final,pago_monto,pago_efectivo,pago_dpr", false, false, "", "orden_negocio,urbanizacion,id_contrato");
            }
        }
        private static DataTable VentasCobranzas_LocalizacionUrbanizacion_original(DateTime Inicio, DateTime Fin, int Traspaso, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_VentasCobranzas_LocalizacionUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "traspaso", DbType.Int32, Traspaso);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable VentasCobranzas_ResumenMes(DateTime Inicio, DateTime Fin, int Traspaso, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[orden_negocio],[id_contrato],[numero],[cliente_paterno],[cliente_materno],[localizacion],[urbanizacion],[urbanizacion_corto],[manzano],[lote],[superficie_m2],[precio_m2_sus],[codigo_moneda]
            //[tipo_cambio],[precio_inicial],[descuento],[precio_final],[pago_monto],[pago_efectivo],[pago_dpr]
            //[pago_fecha],[num_recibo],[num_comprobante],[codigo_dpr],[mes],[num_ventas],[num_cuotas]
            //Orden:[orden_negocio],[urbanizacion],[id_contrato]
            if (Consolidado == false) { return VentasCobranzas_ResumenMes_original(Inicio, Fin, Traspaso, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = VentasCobranzas_ResumenMes_original(Inicio, Fin, Traspaso, Id_negocio, Id_moneda);
                    tabla_bs = VentasCobranzas_ResumenMes_original(Inicio, Fin, Traspaso, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = VentasCobranzas_ResumenMes_original(Inicio, Fin, Traspaso, Id_negocio, Id_segunda_moneda);
                    tabla_bs = VentasCobranzas_ResumenMes_original(Inicio, Fin, Traspaso, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_inicial,descuento,precio_final,pago_monto,pago_efectivo,pago_dpr", false, false, "", "orden_negocio,urbanizacion,id_contrato");
            }
        }
        private static DataTable VentasCobranzas_ResumenMes_original(DateTime Inicio, DateTime Fin, int Traspaso, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_VentasCobranzas_ResumenMes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "traspaso", DbType.Int32, Traspaso);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable VentaCostoDiferido_NegocioUrbanizacion(DateTime Inicio, DateTime Fin, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[orden_negocio],[urbanizacion],[manzano],[lote],[num_contrato],[pago_fecha],[superficie_m2],[costo_m2_sus],[porcentaje_cancelado],[num_venta],[codigo_moneda]
            //[tipo_cambio],[pago_capital],[saldo_capital],[saldo_costo],[costo_diferido],[precio_venta],[costo_venta]
            //Orden:[orden_negocio],[urbanizacion],[pago_fecha]
            if (Consolidado == false) { return VentaCostoDiferido_NegocioUrbanizacion_original(Inicio, Fin, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = VentaCostoDiferido_NegocioUrbanizacion_original(Inicio, Fin, Id_negocio, Id_moneda);
                    tabla_bs = VentaCostoDiferido_NegocioUrbanizacion_original(Inicio, Fin, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = VentaCostoDiferido_NegocioUrbanizacion_original(Inicio, Fin, Id_negocio, Id_segunda_moneda);
                    tabla_bs = VentaCostoDiferido_NegocioUrbanizacion_original(Inicio, Fin, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "pago_capital,saldo_capital,saldo_costo,costo_diferido,precio_venta,costo_venta", false, false, "", "orden_negocio,urbanizacion,pago_fecha");
            }
        }
        private static DataTable VentaCostoDiferido_NegocioUrbanizacion_original(DateTime Inicio, DateTime Fin, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_VentaCostoDiferido_NegocioUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteOtrosServicios(int Id_usuario, int Id_servicio, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[id_servicio],[fecha],[nombre],[numero_contrato],[paterno_cliente],[materno_cliente],[codigo_moneda]
            //[tipo_cambio],[valor_sus],[dpr_sus]
            //[num_factura],[num_recibo],[num_comprobante]
            //Orden:[negocio],[id_servicio],[fecha]
            if (Consolidado == false) { return ReporteOtrosServicios_original(Id_usuario, Id_servicio, Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteOtrosServicios_original(Id_usuario, Id_servicio, Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = ReporteOtrosServicios_original(Id_usuario, Id_servicio, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteOtrosServicios_original(Id_usuario, Id_servicio, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ReporteOtrosServicios_original(Id_usuario, Id_servicio, Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "valor_sus,dpr_sus", false, false, "", "negocio,id_servicio,fecha");
            }
        }
        private static DataTable ReporteOtrosServicios_original(int Id_usuario, int Id_servicio, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ReporteOtrosServicios");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "id_servicio", DbType.Int32, Id_servicio);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable RerpoteDPRpromocion(DateTime Desde, DateTime Hasta)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ReportePromocion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio1", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "fecha_fin1", DbType.DateTime, Hasta);
            //db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            //db1.AddInParameter(cmd, "id_servicio", DbType.Int32, Id_servicio);
            //db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            //db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReportePagosDPR(int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio_codigo],[urbanizacion_codigo],[id_transaccion],[negocio_nombre],[urbanizacion_nombre],[tipo_pago],[contrato_numero],[string_cuotas],[fecha_pago],[paterno_cliente],[materno_cliente],[manzano_codigo],[lote_codigo],[num_factura],[num_comprobante],[codigo_moneda]
            //[tipo_cambio],[cuota_inicial],[monto_pago],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal],[dpr_otserv],[DPR_BONOS],[DPR_DCTO],[DRP_PROM],[DPR_VARIOS],[DPR_TRASP],[DPR_INTER],[DPR_OTROS]
            //Orden:[negocio_codigo],[urbanizacion_codigo],[id_transaccion]
            if (Consolidado == false) { return ReportePagosDPR_original(Id_usuario, Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReportePagosDPR_original(Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = ReportePagosDPR_original(Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReportePagosDPR_original(Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ReportePagosDPR_original(Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_inicial,monto_pago,seguro,mantenimiento_sus,interes,amortizacion,saldo,interes_penal,dpr_otserv,DPR_BONOS,DPR_DCTO,DRP_PROM,DPR_VARIOS,DPR_TRASP,DPR_INTER,DPR_OTROS", false, false, "", "negocio_codigo,urbanizacion_codigo,id_transaccion");
            }
        }
        private static DataTable ReportePagosDPR_original(int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ReportePagosDPR");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReportePagosDPR_Resumen(int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio_codigo],[urbanizacion_codigo],[id_transaccion],[negocio_nombre],[urbanizacion_nombre],[tipo_pago],[contrato_numero],[string_cuotas],[fecha_pago],[paterno_cliente],[materno_cliente],[manzano_codigo],[lote_codigo],[num_factura],[num_comprobante],[codigo_moneda]
            //[tipo_cambio],[cuota_inicial],[monto_pago],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal],[dpr_otserv],[DPR_BONOS],[DPR_DCTO],[DRP_PROM],[DPR_VARIOS],[DPR_TRASP],[DPR_INTER],[DPR_OTROS]
            //Orden:[negocio_codigo],[urbanizacion_codigo],[id_transaccion]
            if (Consolidado == false) { return ReportePagosDPR_Resumen_original(Id_usuario, Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReportePagosDPR_Resumen_original(Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = ReportePagosDPR_Resumen_original(Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReportePagosDPR_Resumen_original(Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ReportePagosDPR_Resumen_original(Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_inicial,monto_pago,seguro,mantenimiento_sus,interes,amortizacion,saldo,interes_penal,dpr_otserv,DPR_BONOS,DPR_DCTO,DRP_PROM,DPR_VARIOS,DPR_TRASP,DPR_INTER,DPR_OTROS", false, false, "", "negocio_codigo,urbanizacion_codigo,id_transaccion");
            }
        }
        private static DataTable ReportePagosDPR_Resumen_original(int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ReportePagosDPR_Resumen");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable Cxc_Gestion(DateTime Fecha_inicio, DateTime Fecha_fin, DateTime Fecha_eval, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[orden_negocio],[id_contrato],[cliente_paterno],[cliente_materno],[numero],[seguro],[interes_corriente],[fecha_inicio_plan],[id_ultimo_pago],[urbanizacion],[urbanizacion_corto],[manzano],[lote],[superficie_m2],[antes_gestion_num_cuotas],[realizado_gestion_num_cuotas],[restante_gestion_num_cuotas],[total_gestion_num_cuotas],[despues_gestion_num_cuotas],[codigo_moneda]
            //[tipo_cambio],[precio_final],[mantenimiento_sus],[cuota_base],[antes_gestion_amortizacion],[antes_gestion_seguro],[antes_gestion_mantenimiento],[antes_gestion_interes],[antes_gestion_total],[realizado_gestion_amortizacion],[realizado_gestion_seguro],[realizado_gestion_mantenimiento],[realizado_gestion_interes],[realizado_gestion_total],[restante_gestion_amortizacion],[restante_gestion_seguro],[restante_gestion_mantenimiento_sus],[restante_gestion_interes_corriente],[restante_gestion_monto_pago],[total_gestion_amortizacion],[total_gestion_seguro],[total_gestion_mantenimiento_sus],[total_gestion_interes_corriente],[total_gestion_monto_pago],[despues_gestion_amortizacion],[despues_gestion_seguro],[despues_gestion_mantenimiento_sus],[despues_gestion_interes_corriente],[despues_gestion_monto_pago]
            //Orden:[orden_negocio],[urbanizacion_corto],[manzano],[lote]

            if (Consolidado == false) { return Cxc_Gestion_original(Fecha_inicio, Fecha_fin, Fecha_eval, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = Cxc_Gestion_original(Fecha_inicio, Fecha_fin, Fecha_eval, Id_negocio, Id_moneda);
                    tabla_bs = Cxc_Gestion_original(Fecha_inicio, Fecha_fin, Fecha_eval, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = Cxc_Gestion_original(Fecha_inicio, Fecha_fin, Fecha_eval, Id_negocio, Id_segunda_moneda);
                    tabla_bs = Cxc_Gestion_original(Fecha_inicio, Fecha_fin, Fecha_eval, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_final,mantenimiento_sus,cuota_base,antes_gestion_amortizacion,antes_gestion_seguro,antes_gestion_mantenimiento,antes_gestion_interes,antes_gestion_total,realizado_gestion_amortizacion,realizado_gestion_seguro,realizado_gestion_mantenimiento,realizado_gestion_interes,realizado_gestion_total,restante_gestion_amortizacion,restante_gestion_seguro,restante_gestion_mantenimiento_sus,restante_gestion_interes_corriente,restante_gestion_monto_pago,total_gestion_amortizacion,total_gestion_seguro,total_gestion_mantenimiento_sus,total_gestion_interes_corriente,total_gestion_monto_pago,despues_gestion_amortizacion,despues_gestion_seguro,despues_gestion_mantenimiento_sus,despues_gestion_interes_corriente,despues_gestion_monto_pago", false, false, "", "orden_negocio,urbanizacion_corto,manzano,lote");
            }
        }
        private static DataTable Cxc_Gestion_original(DateTime Fecha_inicio, DateTime Fecha_fin, DateTime Fecha_eval, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Cxc_Gestion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "fecha_eval", DbType.DateTime, Fecha_eval);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            int Restante_gestion_num_cuotas = 0; decimal Restante_gestion_amortizacion = 0; decimal Restante_gestion_seguro = 0; decimal Restante_gestion_mantenimiento_sus = 0; decimal Restante_gestion_interes_corriente = 0; decimal Restante_gestion_monto_pago = 0;
            int Despues_gestion_num_cuotas = 0; decimal Despues_gestion_amortizacion = 0; decimal Despues_gestion_seguro = 0; decimal Despues_gestion_mantenimiento_sus = 0; decimal Despues_gestion_interes_corriente = 0; decimal Despues_gestion_monto_pago = 0;

            tabla.Columns.Add("restante_gestion_num_cuotas", typeof(decimal));
            tabla.Columns.Add("restante_gestion_amortizacion", typeof(decimal));
            tabla.Columns.Add("restante_gestion_seguro", typeof(decimal));
            tabla.Columns.Add("restante_gestion_mantenimiento_sus", typeof(decimal));
            tabla.Columns.Add("restante_gestion_interes_corriente", typeof(decimal));
            tabla.Columns.Add("restante_gestion_monto_pago", typeof(decimal));

            tabla.Columns.Add("total_gestion_num_cuotas", typeof(decimal));
            tabla.Columns.Add("total_gestion_amortizacion", typeof(decimal));
            tabla.Columns.Add("total_gestion_seguro", typeof(decimal));
            tabla.Columns.Add("total_gestion_mantenimiento_sus", typeof(decimal));
            tabla.Columns.Add("total_gestion_interes_corriente", typeof(decimal));
            tabla.Columns.Add("total_gestion_monto_pago", typeof(decimal));

            tabla.Columns.Add("despues_gestion_num_cuotas", typeof(decimal));
            tabla.Columns.Add("despues_gestion_amortizacion", typeof(decimal));
            tabla.Columns.Add("despues_gestion_seguro", typeof(decimal));
            tabla.Columns.Add("despues_gestion_mantenimiento_sus", typeof(decimal));
            tabla.Columns.Add("despues_gestion_interes_corriente", typeof(decimal));
            tabla.Columns.Add("despues_gestion_monto_pago", typeof(decimal));

            foreach (DataRow fila in tabla.Rows)
            {
                contabilidadReporte.PagosRestantes_Gestion(Fecha_fin,
                    ref Restante_gestion_num_cuotas, ref Restante_gestion_amortizacion, ref Restante_gestion_seguro, ref Restante_gestion_mantenimiento_sus, ref Restante_gestion_interes_corriente, ref Restante_gestion_monto_pago,
                    ref Despues_gestion_num_cuotas, ref Despues_gestion_amortizacion, ref Despues_gestion_seguro, ref Despues_gestion_mantenimiento_sus, ref Despues_gestion_interes_corriente, ref Despues_gestion_monto_pago,

                    (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                    (int)fila["id_ultimo_pago"]
                    , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                    , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                    , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

                fila["antes_gestion_total"] = (decimal)fila["antes_gestion_amortizacion"] + (decimal)fila["antes_gestion_seguro"] + (decimal)fila["antes_gestion_mantenimiento"] + (decimal)fila["antes_gestion_interes"];

                fila["restante_gestion_num_cuotas"] = Restante_gestion_num_cuotas;
                fila["restante_gestion_amortizacion"] = Restante_gestion_amortizacion;
                fila["restante_gestion_seguro"] = Restante_gestion_seguro;
                fila["restante_gestion_mantenimiento_sus"] = Restante_gestion_mantenimiento_sus;
                fila["restante_gestion_interes_corriente"] = Restante_gestion_interes_corriente;
                fila["restante_gestion_monto_pago"] = Restante_gestion_monto_pago;

                fila["despues_gestion_num_cuotas"] = Despues_gestion_num_cuotas;
                fila["despues_gestion_amortizacion"] = Despues_gestion_amortizacion;
                fila["despues_gestion_seguro"] = Despues_gestion_seguro;
                fila["despues_gestion_mantenimiento_sus"] = Despues_gestion_mantenimiento_sus;
                fila["despues_gestion_interes_corriente"] = Despues_gestion_interes_corriente;
                fila["despues_gestion_monto_pago"] = Despues_gestion_monto_pago;

                fila["total_gestion_num_cuotas"] = (int)fila["realizado_gestion_num_cuotas"] + Restante_gestion_num_cuotas;
                fila["total_gestion_amortizacion"] = (decimal)fila["realizado_gestion_amortizacion"] + Restante_gestion_amortizacion;
                fila["total_gestion_seguro"] = (decimal)fila["realizado_gestion_seguro"] + Restante_gestion_seguro;
                fila["total_gestion_mantenimiento_sus"] = (decimal)fila["realizado_gestion_mantenimiento"] + Restante_gestion_mantenimiento_sus;
                fila["total_gestion_interes_corriente"] = (decimal)fila["realizado_gestion_interes"] + Restante_gestion_interes_corriente;
                fila["total_gestion_monto_pago"] = (decimal)fila["realizado_gestion_total"] + Restante_gestion_monto_pago;
            }
            return tabla;
        }


        public static DataTable ResumenCxC(DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[id_contrato],[negocio_nombre],[urbanizacion_nombre],[numero_contrato],[codigo_lote],[codigo_moneda],[tipo_cambio]
            //[saldo_inicial],[reactivados],[amortizado],[ventas_nuevas],[revertidos],[transferido],[saldo_final]
            //Orden:[negocio_nombre],[urbanizacion_nombre],[id_contrato]
            if (Consolidado == false) { return ResumenCxC_original(Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ResumenCxC_original(Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = ResumenCxC_original(Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ResumenCxC_original(Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ResumenCxC_original(Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "saldo_inicial,reactivados,amortizado,ventas_nuevas,revertidos,transferido,saldo_final", false, false, "", "negocio_nombre,urbanizacion_nombre,id_contrato");
            }
        }
        private static DataTable ResumenCxC_original(DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ResumenCxC");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable Transferencia(DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio_nombre],[urbanizacion_nombre],[numero_contrato],[codigo_lote],[fecha],[codigo_moneda]
            //[tipo_cambio],[saldo_inicial],[amortizado],[transferido],[saldo_final]
            //Orden:[negocio_nombre],[urbanizacion_nombre],[numero_contrato]
            if (Consolidado == false) { return Transferencia_original(Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = Transferencia_original(Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = Transferencia_original(Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = Transferencia_original(Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = Transferencia_original(Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "saldo_inicial,amortizado,transferido,saldo_final", false, false, "", "negocio_nombre,urbanizacion_nombre,numero_contrato");
            }
        }
        private static DataTable Transferencia_original(DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Transferencia");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            //return db1.ExecuteDataSet(cmd).Tables[0];
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            foreach (DataRow fila in tabla.Rows)
            {
                decimal a = (decimal)fila["saldo_inicial"];
                decimal b = (decimal)fila["amortizado"];
                decimal c = (decimal)fila["transferido"];
                fila["saldo_final"] = a - b + c;
            }
            return tabla;
        }


        public static DataTable ContratoSaldoCancelado(int Tipo_fecha, DateTime Fecha_inicio, DateTime Fecha_fin, int Ini_tipo_fecha, DateTime Ini_fecha_inicio, DateTime Ini_fecha_fin, int Id_localizacion, int Id_urbanizacion, int Id_manzano, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[numero_contrato],[fecha_registro],[localizacion],[sector],[manzano],[lote],[titular_nombre],[titular_ci],[superficie_m2],[descuento_porcentaje],[codigo_moneda],
            //[tipo_cambio],[precio],[descuento_efectivo],[precio_final],[saldo]
            //[interes],[fecha_ultimo_pago],[negocio]
            //Orden:[fecha_ultimo_pago]
            DataTable tabla;
            if (Consolidado == false) { tabla = ContratoSaldoCancelado_original(Tipo_fecha, Fecha_inicio, Fecha_fin, Ini_tipo_fecha, Ini_fecha_inicio, Ini_fecha_fin, Id_localizacion, Id_urbanizacion, Id_manzano, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ContratoSaldoCancelado_original(Tipo_fecha, Fecha_inicio, Fecha_fin, Ini_tipo_fecha, Ini_fecha_inicio, Ini_fecha_fin, Id_localizacion, Id_urbanizacion, Id_manzano, Id_negocio, Id_moneda);
                    tabla_bs = ContratoSaldoCancelado_original(Tipo_fecha, Fecha_inicio, Fecha_fin, Ini_tipo_fecha, Ini_fecha_inicio, Ini_fecha_fin, Id_localizacion, Id_urbanizacion, Id_manzano, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ContratoSaldoCancelado_original(Tipo_fecha, Fecha_inicio, Fecha_fin, Ini_tipo_fecha, Ini_fecha_inicio, Ini_fecha_fin, Id_localizacion, Id_urbanizacion, Id_manzano, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ContratoSaldoCancelado_original(Tipo_fecha, Fecha_inicio, Fecha_fin, Ini_tipo_fecha, Ini_fecha_inicio, Ini_fecha_fin, Id_localizacion, Id_urbanizacion, Id_manzano, Id_negocio, Id_moneda);
                }
                tabla = general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento_efectivo,precio_final,saldo", false, false, "", "fecha_registro");
            }

            Ini_fecha_fin = Ini_fecha_fin.AddDays(1).AddSeconds(-1);
            if (Ini_tipo_fecha == 0) { Ini_fecha_inicio = DateTime.Parse("01/01/1900"); Ini_fecha_fin = DateTime.Parse("01/01/5900"); }
            else if (Ini_tipo_fecha == 1) { Ini_fecha_fin = DateTime.Parse("01/01/5900"); }
            else if (Ini_tipo_fecha == 2) { Ini_fecha_inicio = DateTime.Parse("01/01/1900"); }

            for (int j = tabla.Rows.Count - 1; j >= 0; j--)
            {
                if (((DateTime)tabla.Rows[j]["fecha_registro"]) < Ini_fecha_inicio || ((DateTime)tabla.Rows[j]["fecha_registro"]) > Ini_fecha_fin)
                {
                    tabla.Rows.RemoveAt(j);
                }
            }
            return tabla;
        }
        private static DataTable ContratoSaldoCancelado_original(int Tipo_fecha, DateTime Fecha_inicio, DateTime Fecha_fin, int Ini_tipo_fecha, DateTime Ini_fecha_inicio, DateTime Ini_fecha_fin, int Id_localizacion, int Id_urbanizacion, int Id_manzano, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ContratoSaldoCancelado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "tipo_fecha", DbType.Int32, Tipo_fecha);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "ini_tipo_fecha", DbType.Int32, Ini_tipo_fecha);
            db1.AddInParameter(cmd, "ini_fecha_inicio", DbType.DateTime, Ini_fecha_inicio);
            db1.AddInParameter(cmd, "ini_fecha_fin", DbType.DateTime, Ini_fecha_fin);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ComposicionCuota(DateTime Inicio, DateTime Fin, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[urbanizacion],[servicio],
            //[pagos_total],[pagos_capital],[pagos_interes],[pagos_seguro],[pagos_mantenimiento],[pagos_mora],[pagos_servicios],
            //[dpr_total],[dpr_capital],[dpr_interes],[dpr_seguro],[dpr_mantenimiento],[dpr_mora],[dpr_servicios],
            //[efectivo_total],[efectivo_capital],[efectivo_interes],[efectivo_seguro],[efectivo_mantenimiento],[efectivo_mora],[efectivo_servicios],
            //[ventas_mes],[saldo_revertido],[ingreso_tramites],[libro_ventas],[debito_fiscal],[importe_neto]
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ComposicionCuota");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            for (int aux = tabla.Rows.Count - 1; aux >= 0; aux--)
            {
                if ((bool)tabla.Rows[aux]["servicio"] == true)
                {
                    if ((decimal)tabla.Rows[aux]["pagos_total"] == 0) tabla.Rows.RemoveAt(aux);
                }
                else if ((decimal)tabla.Rows[aux]["pagos_total"] == 0 && (decimal)tabla.Rows[aux]["ventas_mes"] == 0 && (decimal)tabla.Rows[aux]["saldo_revertido"] == 0 && (decimal)tabla.Rows[aux]["libro_ventas"] == 0)
                    tabla.Rows.RemoveAt(aux);
            }
            return tabla;
        }


        public static DataTable ComposicionCuotaDetalle(DateTime Inicio, DateTime Fin, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[negocio],[urbanizacion],[manzano],[lote],[numero_contrato],[servicio],
            //[pagos_total],[pagos_capital],[pagos_interes],[pagos_seguro],[pagos_mantenimiento],[pagos_mora],[pagos_servicios],
            //[dpr_total],[dpr_capital],[dpr_interes],[dpr_seguro],[dpr_mantenimiento],[dpr_mora],[dpr_servicios],
            //[efectivo_total],[efectivo_capital],[efectivo_interes],[efectivo_seguro],[efectivo_mantenimiento],[efectivo_mora],[efectivo_servicios],
            //[ventas_mes],[saldo_revertido],[ingreso_tramites],[libro_ventas],[debito_fiscal],[importe_neto]
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_ComposicionCuotaDetalle");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            //DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            //for (int aux = tabla.Rows.Count - 1; aux >= 0; aux--)
            //{
            //    if ((bool)tabla.Rows[aux]["servicio"] == true)
            //    {
            //        if ((decimal)tabla.Rows[aux]["pagos_total"] == 0) tabla.Rows.RemoveAt(aux);
            //    }
            //    else if ((decimal)tabla.Rows[aux]["pagos_total"] == 0 && (decimal)tabla.Rows[aux]["ventas_mes"] == 0 && (decimal)tabla.Rows[aux]["saldo_revertido"] == 0 && (decimal)tabla.Rows[aux]["libro_ventas"] == 0)
            //        tabla.Rows.RemoveAt(aux);
            //}
            //return tabla;
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable MorosidadContratoPromotor(DateTime Fecha, string Id_negocio, int Id_urbanizacion, int Id_promotor, string OrdenarPor, int Por_cobrador, int Num_dias_ultimo_pago, DateTime F_ini_desde, DateTime F_ini_hasta, int Id_moneda, bool Consolidado)
        {
            //[negocio],[urbanizacion],[orden_negocio],[cliente],[cliente_fono],[num_contrato],[precio_final],[lote],[fecha_ultimo_pago],[fecha_interes_pago],[fecha_proximo_pago],[fecha_cuota_inicial]
            //[codigo_moneda],[tipo_cambio]
            //[saldo_deudor],[pagado_num_cuotas],[pagado_seguro],[pagado_mantenimiento],[pagado_interes],[pagado_capital],[pagado_total],[promotor_codigo],[promotor_nombre]
            //[ultimo_pago_string],[num_cuotas_adeuda],[num_dias_adeuda],[num_dias_mora],[interes_penal],[mora_sus]
            //[cuota_base],[interes_corriente],[interes_adeuda],[capital_adeuda],[pagos_adeuda]
            if (Consolidado == false) { return MorosidadContratoPromotor_original(Fecha, Id_negocio, Id_urbanizacion, Id_promotor, OrdenarPor, Por_cobrador, Num_dias_ultimo_pago, F_ini_desde, F_ini_hasta, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = MorosidadContratoPromotor_original(Fecha, Id_negocio, Id_urbanizacion, Id_promotor, OrdenarPor, Por_cobrador, Num_dias_ultimo_pago, F_ini_desde, F_ini_hasta, Id_moneda);
                    tabla_bs = MorosidadContratoPromotor_original(Fecha, Id_negocio, Id_urbanizacion, Id_promotor, OrdenarPor, Por_cobrador, Num_dias_ultimo_pago, F_ini_desde, F_ini_hasta, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = MorosidadContratoPromotor_original(Fecha, Id_negocio, Id_urbanizacion, Id_promotor, OrdenarPor, Por_cobrador, Num_dias_ultimo_pago, F_ini_desde, F_ini_hasta, Id_segunda_moneda);
                    tabla_bs = MorosidadContratoPromotor_original(Fecha, Id_negocio, Id_urbanizacion, Id_promotor, OrdenarPor, Por_cobrador, Num_dias_ultimo_pago, F_ini_desde, F_ini_hasta, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_final,saldo_deudor,pagado_seguro,pagado_mantenimiento,pagado_interes,pagado_capital,pagado_total,mora_sus,cuota_base,interes_adeuda,capital_adeuda,pagos_adeuda", false, false, "", OrdenarPor);
            }
        }
        private static DataTable MorosidadContratoPromotor_original(DateTime Fecha, string Id_negocio, int Id_urbanizacion, int Id_promotor, string OrdenarPor, int Por_cobrador, int Num_dias_ultimo_pago, DateTime F_ini_desde, DateTime F_ini_hasta, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_MorosidadContratoPromotor");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_promotor", DbType.Int32, Id_promotor);
            db1.AddInParameter(cmd, "por_cobrador", DbType.Int32, Por_cobrador);
            db1.AddInParameter(cmd, "num_dias_ultimo_pago", DbType.Int32, Num_dias_ultimo_pago);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);

            db1.AddInParameter(cmd, "f_ini_desde", DbType.DateTime, F_ini_desde);
            db1.AddInParameter(cmd, "f_ini_hasta", DbType.DateTime, F_ini_hasta);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            tabla.DefaultView.Sort = OrdenarPor;
            return tabla.DefaultView.ToTable();
        }

        public static DataTable MorosidadCliente(DateTime Fecha, int Id_cliente, int Num_dias_ultimo_pago, int Id_moneda, bool Consolidado)
        {
            //[cliente_nombre],[cliente_fono],[cliente_ci],[cliente_direccion],[cliente_zona],[num_contrato],[lote],[fecha_ultimo_pago],[fecha_proximo_pago],[num_cuotas_adeuda],[num_dias_mora],[interes_penal],[pagado_num_cuotas],[promotor],[ultimo_pago_string],[codigo_moneda]
            //[tipo_cambio],[saldo_deudor],[mora_sus],[pagado_seguro],[pagado_mantenimiento],[pagado_interes],[pagado_capital],[pagado_total],
            //Orden:[ultimo_pago_string],[cliente_nombre],[num_contrato]
            if (Consolidado == false) { return MorosidadCliente_original(Fecha, Id_cliente, Num_dias_ultimo_pago, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = MorosidadCliente_original(Fecha, Id_cliente, Num_dias_ultimo_pago, Id_moneda);
                    tabla_bs = MorosidadCliente_original(Fecha, Id_cliente, Num_dias_ultimo_pago, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = MorosidadCliente_original(Fecha, Id_cliente, Num_dias_ultimo_pago, Id_segunda_moneda);
                    tabla_bs = MorosidadCliente_original(Fecha, Id_cliente, Num_dias_ultimo_pago, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "saldo_deudor,mora_sus,pagado_seguro,pagado_mantenimiento,pagado_interes,pagado_capital,pagado_total", false, false, "", "ultimo_pago_string,cliente_nombre,num_contrato");
            }
        }
        private static DataTable MorosidadCliente_original(DateTime Fecha, int Id_cliente, int Num_dias_ultimo_pago, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_MorosidadCliente");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
            db1.AddInParameter(cmd, "num_dias_ultimo_pago", DbType.Int32, Num_dias_ultimo_pago);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable LibroVentasInterno(int Id_parametrofacturacion, DateTime Inicio, DateTime Fin, int Tipo_facturas)
        {
            //@tipo_facturas: 1=Sin facturas anuladas;  2=Con facturas anuladas;  3=Solo facturas anuladas

            //[fecha],[nit],[num_autorizacion],[codigo_control],[anulado],[num_factura],
            //[cliente],[importe_sus],[tipo_cambio],[importe_bs]
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_LibroVentasInterno");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, Id_parametrofacturacion);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "tipo_facturas", DbType.Int32, Tipo_facturas);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable LibroVentasRenta(int Id_parametrofacturacion, DateTime Inicio, DateTime Fin)
        {
            //[fecha],[nit],[num_autorizacion],[codigo_control],[anulado],[num_factura],
            //[cliente],[importe_bs],[ice],[imp_exce],[importe_neto],[debito_iva]
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_LibroVentasRenta");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, Id_parametrofacturacion);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            LibroVentasRenta_InsertarFacturasAnuladas(ref tabla);
            return tabla;
        }
        public static StringBuilder LibroVentasRenta_txt(int Id_parametrofacturacion, DateTime Inicio, DateTime Fin, int Id_sucursal)
        {
            StringBuilder resultado = new StringBuilder();
            if (Id_sucursal > 0)
            {
                DataTable tabla = LibroVentasRenta(Id_parametrofacturacion, Inicio, Fin);
                foreach (DataRow fila in tabla.Rows)
                {
                    //resultado.Append(fila["nit"].ToString());
                    //resultado.Append('|' + fila["cliente"].ToString());
                    //resultado.Append('|' + fila["num_factura"].ToString());
                    //resultado.Append('|' + fila["num_autorizacion"].ToString());
                    //resultado.Append('|' + ((DateTime)fila["fecha"]).ToString("d"));
                    //resultado.Append('|' + ((decimal)fila["importe_bs"]).ToString("F2").Replace(',', '.'));
                    //resultado.Append('|' + ((decimal)fila["ice"]).ToString("F2").Replace(',', '.'));
                    //resultado.Append('|' + ((decimal)fila["imp_exce"]).ToString("F2").Replace(',', '.'));
                    //resultado.Append('|' + ((decimal)fila["importe_neto"]).ToString("F2").Replace(',', '.'));
                    //resultado.Append('|' + ((decimal)fila["debito_iva"]).ToString("F2").Replace(',', '.'));
                    //resultado.Append('|' + fila["anulado"].ToString());
                    //resultado.Append('|' + fila["codigo_control"].ToString());
                    //resultado.Append(';');
                    resultado.Append(fila["especificacion"].ToString());
                    resultado.Append('|' + fila["fecha"].ToString());
                    resultado.Append('|' + fila["num_factura"].ToString());
                    resultado.Append('|' + fila["num_autorizacion"].ToString());
                    resultado.Append('|' + fila["nit"].ToString());
                    resultado.Append('|');
                    resultado.Append('|' + fila["cliente"].ToString());
                    resultado.Append('|' + ((decimal)fila["importe_bs"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["ice"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["imp_iehd"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["tasas"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["otros"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["exportaciones"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["ventas_tasa_0"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["subtotal"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["descuentos"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["imp_gift_card"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["importe_neto"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + ((decimal)fila["debito_iva"]).ToString("F2").Replace(',', '.'));
                    resultado.Append('|' + fila["anulado"].ToString());
                    resultado.Append('|' + fila["codigo_control"].ToString());
                    resultado.Append('|' + fila["tipo_venta"].ToString());
                    resultado.Append(';');
                }
            }
            else
            {
                decimal nit_guia = (new parametro_facturacion(Id_parametrofacturacion)).nit;
                DataTable tabla_sucursal = sucursal.Lista();
                foreach (DataRow fila_sucursal in tabla_sucursal.Rows)
                {
                    //Se obtiene el parámetro de facturación vigente para esa sucursal
                    int _id_sucursal = (int)fila_sucursal["id_sucursal"];
                    int _id_parametrofacturacion = 0;
                    DataTable tabla_par = parametro_facturacion.ListaLibroVentas(_id_sucursal);
                    foreach (DataRow fila_par in tabla_par.Rows)
                    {
                        if (((decimal)fila_par["nit"]) == nit_guia)
                        {
                            _id_parametrofacturacion = (int)fila_par["id_parametrofacturacion"];
                            break;
                        }
                    }

                    //Si existe un parámetro de facturación vigente se lo añade al archivo
                    if (_id_parametrofacturacion > 0)
                    {
                        DataTable tabla = LibroVentasRenta(_id_parametrofacturacion, Inicio, Fin);
                        foreach (DataRow fila in tabla.Rows)
                        {
                            //resultado.Append(fila["nit"].ToString());
                            //resultado.Append('|' + fila["cliente"].ToString());
                            //resultado.Append('|' + fila["num_factura"].ToString());
                            //resultado.Append('|' + fila["num_autorizacion"].ToString());
                            //resultado.Append('|' + ((DateTime)fila["fecha"]).ToString("d"));
                            //resultado.Append('|' + ((decimal)fila["importe_bs"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["ice"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["imp_exce"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["importe_neto"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["debito_iva"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + fila["anulado"].ToString());
                            //resultado.Append('|' + fila["codigo_control"].ToString());
                            //resultado.Append(';');
                            //resultado.Append(fila["especificacion"].ToString());
                            //resultado.Append('|' + fila["nro"].ToString());
                            //resultado.Append('|' + ((DateTime)fila["fecha"]).ToString("d"));
                            //resultado.Append('|' + fila["num_factura"].ToString());
                            //resultado.Append('|' + fila["num_autorizacion"].ToString());
                            //resultado.Append('|' + fila["anulado"].ToString());
                            //resultado.Append('|' + fila["nit"].ToString());
                            //resultado.Append('|' + fila["cliente"].ToString());
                            //resultado.Append('|' + ((decimal)fila["importe_bs"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["ice"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["imp_exce"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["ventas_tasa_0"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["importe_neto"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["descuentos"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["importe_neto"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + ((decimal)fila["debito_iva"]).ToString("F2").Replace(',', '.'));
                            //resultado.Append('|' + fila["codigo_control"].ToString());
                            //resultado.Append(';');
                            resultado.Append(fila["especificacion"].ToString());
                            resultado.Append('|' + fila["fecha"].ToString());
                            resultado.Append('|' + fila["num_factura"].ToString());
                            resultado.Append('|' + fila["num_autorizacion"].ToString());
                            resultado.Append('|' + fila["nit"].ToString());
                            resultado.Append('|');
                            resultado.Append('|' + fila["cliente"].ToString());
                            resultado.Append('|' + ((decimal)fila["importe_bs"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["ice"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["imp_iehd"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["tasas"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["otros"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["exportaciones"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["ventas_tasa_0"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["subtotal"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["descuentos"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["imp_gift_card"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["importe_neto"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + ((decimal)fila["debito_iva"]).ToString("F2").Replace(',', '.'));
                            resultado.Append('|' + fila["anulado"].ToString());
                            resultado.Append('|' + fila["codigo_control"].ToString());
                            resultado.Append('|' + fila["tipo_venta"].ToString());
                            resultado.Append(';');
                        }
                    }
                }

            }
            return resultado;
        }
        private static void LibroVentasRenta_InsertarFacturasAnuladas(ref DataTable tabla)
        {
            List<itemFact> lista = new List<itemFact>();
            for (int j = 0; j < tabla.Rows.Count - 1; j++)
            {
                int num1 = (int)tabla.Rows[j]["num_factura"];
                int num2 = (int)tabla.Rows[j + 1]["num_factura"];
                if (num2 > (num1 + 1))
                    lista.Add(new itemFact(j + 1, num1 + 1, num2 - 1, DateTime.Parse(tabla.Rows[j]["fecha"].ToString()), tabla.Rows[j]["num_autorizacion"].ToString()));
            }
            for (int j = lista.Count - 1; j >= 0; j--)
            {
                itemFact fact = lista[j];
                for (int n = fact.num2; n >= fact.num1; n--)
                {
                    DataRow fila = tabla.NewRow();
                    //fila["especificacion"] = 3;
                    //fila["nro"] = 0;
                    //fila["fecha"] = fact.fecha;
                    //fila["num_factura"] = n;
                    //fila["num_autorizacion"] = fact.num_autorizacion;
                    //fila["anulado"] = "A";
                    //fila["nit"] = "0";
                    //fila["cliente"] = "ANULADA";
                    //fila["importe_bs"] = 0;
                    //fila["ice"] = 0;
                    //fila["imp_exce"] = 0;
                    //fila["ventas_tasa_0"] = 0;
                    //fila["importe_neto"] = 0;
                    //fila["descuentos"] = 0;
                    //fila["importe_neto"] = 0;
                    //fila["debito_iva"] = 0;
                    //fila["codigo_control"] = "0";
                    fila["especificacion"] = 3;
                    fila["fecha"] = fact.fecha;
                    fila["num_factura"] = n;
                    fila["num_autorizacion"] = fact.num_autorizacion;
                    fila["nit"] = "0";
                    fila["cliente"] = "ANULADA";
                    fila["importe_bs"] = 0;
                    fila["ice"] = 0;
                    fila["imp_iehd"] = 0;
                    fila["tasas"] = 0;
                    fila["otros"] = 0;
                    fila["exportaciones"] = 0;
                    fila["ventas_tasa_0"] = 0;
                    fila["subtotal"] = 0;
                    fila["descuentos"] = 0;
                    fila["imp_gift_card"] = 0;
                    fila["importe_neto"] = 0;
                    fila["debito_iva"] = 0;
                    fila["anulado"] = "A";
                    fila["codigo_control"] = "0";
                    fila["tipo_venta"] = "0";
                   
                    tabla.Rows.InsertAt(fila, fact.index);
                }
            }
        }


        public static DataTable CarteraVigente(DateTime Fecha, string Id_negocio, int Id_localizacion, int Id_urbanizacion, int Id_manzano, int Id_moneda, bool Consolidado)
        {
            //[codigo_moneda],
            //[tipo_cambio],[precio],[descuento_efectivo],[precio_final],[cuota_inicial],[cuota_base],[valor_final_terreno],[total_pago],[total_interes],[total_amortizacion],[saldo]
            //Orden:[num_dias_retraso]
            if (Consolidado == false) { return CarteraVigente_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = CarteraVigente_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Id_moneda);
                    tabla_bs = CarteraVigente_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = CarteraVigente_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Id_segunda_moneda);
                    tabla_bs = CarteraVigente_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento_efectivo,precio_final,cuota_inicial,cuota_base,valor_final_terreno,total_pago,total_interes,total_amortizacion,saldo", false, false, "", "num_dias_retraso");
            }
        }
        private static DataTable CarteraVigente_original(DateTime Fecha, string Id_negocio, int Id_localizacion, int Id_urbanizacion, int Id_manzano, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraVigente");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable CarteraVigente2(DateTime Fecha, string Id_negocio, int Id_localizacion, int Id_urbanizacion, int Id_manzano, decimal Saldo_menor, decimal Saldo_mayor, string Orden, int Id_moneda, bool Consolidado)
        {
            //[negocio],[numero_contrato],[fecha_registro],[localizacion],[urbanizacion],[manzano],[lote],[nombre_cliente],[celular],[email],[domicilio_fono],[oficina_fono]
            //[interes_corriente],[num_cuotas],[fecha_ultimo_pago],[interes_fecha],[fecha_proximo],[num_dias_retraso],[num_cuotas_adeuda],[num_dias_mora],[num_cuotas_mora],[porcentaje_saldo],[codigo_moneda]
            //[tipo_cambio],[cuota_base],[precio_final],[total_amortizacion],[saldo]
            //Orden:[numero_contrato]
            if (Consolidado == false) { return CarteraVigente2_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Saldo_menor, Saldo_mayor, Orden, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = CarteraVigente2_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Saldo_menor, Saldo_mayor, Orden, Id_moneda);
                    tabla_bs = CarteraVigente2_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Saldo_menor, Saldo_mayor, Orden, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = CarteraVigente2_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Saldo_menor, Saldo_mayor, Orden, Id_segunda_moneda);
                    tabla_bs = CarteraVigente2_original(Fecha, Id_negocio, Id_localizacion, Id_urbanizacion, Id_manzano, Saldo_menor, Saldo_mayor, Orden, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_base,precio_final,total_amortizacion,saldo", false, false, "", Orden);
            }
        }
        private static DataTable CarteraVigente2_original(DateTime Fecha, string Id_negocio, int Id_localizacion, int Id_urbanizacion, int Id_manzano, decimal Saldo_menor, decimal Saldo_mayor, string Orden, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraVigente2");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "saldo_menor", DbType.Decimal, Saldo_menor);
            db1.AddInParameter(cmd, "saldo_mayor", DbType.Decimal, Saldo_mayor);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            tabla.DefaultView.Sort = Orden;
            return tabla.DefaultView.ToTable();
        }


        public static DataTable urbanizacion_pago_mes(int Id_urbanizacion, bool Detalle, bool Sin_ini, DateTime Fecha_inicio, bool Sin_fin, DateTime Fecha_fin, ref DateTime Inicio, ref DateTime Fin, bool int_amortiz, int Id_moneda, bool Consolidado)
        {

            //Se obtiene la tabla con las primeras columnas y el rango de fechas
            DbCommand cmd;
            if (int_amortiz == false) cmd = db1.GetStoredProcCommand("contabilidad_urbanizacion_pago_mes");
            else cmd = db1.GetStoredProcCommand("contabilidad_urbanizacion_pago_mes_interes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "columna_mes", DbType.Boolean, false);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "detalle", DbType.Boolean, Detalle);
            if (Sin_ini == true) db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, DBNull.Value);
            else db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            if (Sin_fin == true) db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, DBNull.Value);
            else db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddOutParameter(cmd, "inicio", DbType.DateTime, 200);
            db1.AddOutParameter(cmd, "fin", DbType.DateTime, 200);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            Fecha_inicio = (DateTime)db1.GetParameterValue(cmd, "inicio");
            Fecha_fin = (DateTime)db1.GetParameterValue(cmd, "fin");

            //Inicio = Fecha_inicio;
            //Fin = Fecha_fin;

            //Se setean las fechas
            Fecha_inicio = Fecha_inicio.AddDays((-1) * (Fecha_inicio.Day - 1)).Date;
            Fecha_fin = Fecha_fin.AddDays((-1) * (Fecha_fin.Day - 1)).Date.AddMonths(1).AddSeconds(-1);

            Inicio = Fecha_inicio;
            Fin = Fecha_fin;

            //Se generan las columnas (una por mes)
            DateTime fecha_aux = Fecha_inicio;
            while (fecha_aux <= Fecha_fin)
            {
                //Se crea la columna
                string nombre_columna = "";
                string nombre_columna1 = "";
                if (int_amortiz == false)
                {
                    nombre_columna = fecha_aux.ToString("MMM-yy");
                    tabla.Columns.Add(nombre_columna, typeof(decimal));
                }
                else
                {
                    nombre_columna = fecha_aux.ToString("MMM-yy") + " Amortiz.";
                    nombre_columna1 = fecha_aux.ToString("MMM-yy") + " Int.";
                    tabla.Columns.Add(nombre_columna, typeof(decimal));
                    tabla.Columns.Add(nombre_columna1, typeof(decimal));
                }
                
                //Se recuperan los datos de la columna
                if (int_amortiz == false)
                    cmd = db1.GetStoredProcCommand("contabilidad_urbanizacion_pago_mes");
                else cmd = db1.GetStoredProcCommand("contabilidad_urbanizacion_pago_mes_interes");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "columna_mes", DbType.Boolean, true);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "detalle", DbType.Boolean, Detalle);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, fecha_aux);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, fecha_aux.AddMonths(1).AddSeconds(-1));
                db1.AddOutParameter(cmd, "inicio", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "fin", DbType.DateTime, 200);
                db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
                db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
                DataTable tabla_pagos_mes = db1.ExecuteDataSet(cmd).Tables[0];
                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    if (int_amortiz == false)
                        tabla.Rows[j][nombre_columna] = tabla_pagos_mes.Rows[j]["monto"];
                    else
                    {
                        tabla.Rows[j][nombre_columna] = tabla_pagos_mes.Rows[j]["monto_amortizacion"];
                        tabla.Rows[j][nombre_columna1] = tabla_pagos_mes.Rows[j]["monto_interes"];
                    }
                }
                fecha_aux = fecha_aux.AddMonths(1);
            }
            return tabla;
        }






        public static DataTable Inventario(DateTime Desde, DateTime Hasta, string Id_negocio)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Inventario");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            return db1.ExecuteDataSet(cmd).Tables[0];
            //DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            //foreach (DataRow fila in tabla.Rows)
            //{

            //    fila["estado_nombre"] = new estado(int.Parse(fila["id_estado_desde"].ToString())).nombre;
            //    if (int.Parse(fila["id_estado_desde"].ToString()) != 0 || int.Parse(fila["id_estado_desde"].ToString()) != 5)
            //    {
            //        fila["inventario_inicial"] = decimal.Parse(fila["lote_superficie"].ToString()) * decimal.Parse(fila["lote_costo"].ToString());
            //    }
            //    if (int.Parse(fila["revertido"].ToString()) == 1)
            //    {
            //        fila["costo_revertido"] = decimal.Parse(fila["lote_superficie"].ToString()) * decimal.Parse(fila["lote_costo"].ToString());
            //    }
            //    if (int.Parse(fila["habilitado"].ToString()) == 1)
            //    {
            //        fila["lote_habilitado"] = decimal.Parse(fila["lote_superficie"].ToString()) * decimal.Parse(fila["lote_costo"].ToString());
            //    }
            //    if (int.Parse(fila["id_estado_hasta"].ToString()) == 5)
            //    {
            //        fila["lotes_vendidos"] = decimal.Parse(fila["lote_superficie"].ToString()) * decimal.Parse(fila["lote_costo"].ToString());
            //    }
            //}
            //return tabla;
        }

        public static void PagosRestantes(int Id_contrato, DateTime Fecha, ref int Num_cuotas, ref decimal Amortizacion,
            ref decimal Seguro, ref decimal Mantenimiento_sus, ref decimal Interes_corriente, ref decimal Monto_pago,
            decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

            , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
            , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
            , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
        {
            Num_cuotas = 0; Amortizacion = 0; Seguro = 0; Mantenimiento_sus = 0; Interes_corriente = 0; Monto_pago = 0;
            //sim_pago pago_simulado = new sim_pago(Id_ultimo_pago);
            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
                , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
                , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1,
                    pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                    pp_mantenimiento_sus, pp_interes_corriente);
                Num_cuotas += 1;
                Amortizacion += pago_simulado.amortizacion;
                Seguro += pago_simulado.seguro;
                Mantenimiento_sus += pago_simulado.mantenimiento_sus;
                Interes_corriente += pago_simulado.interes;
                Monto_pago += pago_simulado.monto_pago;
            }
        }

        public static void PagosRestantes_Gestion(DateTime Fecha_fin,
            ref int Restante_gestion_num_cuotas, ref decimal Restante_gestion_amortizacion, ref decimal Restante_gestion_seguro, ref decimal Restante_gestion_mantenimiento_sus, ref decimal Restante_gestion_interes_corriente, ref decimal Restante_gestion_monto_pago,
            ref int Despues_gestion_num_cuotas, ref decimal Despues_gestion_amortizacion, ref decimal Despues_gestion_seguro, ref decimal Despues_gestion_mantenimiento_sus, ref decimal Despues_gestion_interes_corriente, ref decimal Despues_gestion_monto_pago,

            decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

            , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
            , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
            , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
        {

            Restante_gestion_num_cuotas = 0; Restante_gestion_amortizacion = 0; Restante_gestion_seguro = 0; Restante_gestion_mantenimiento_sus = 0; Restante_gestion_interes_corriente = 0; Restante_gestion_monto_pago = 0;
            Despues_gestion_num_cuotas = 0; Despues_gestion_amortizacion = 0; Despues_gestion_seguro = 0; Despues_gestion_mantenimiento_sus = 0; Despues_gestion_interes_corriente = 0; Despues_gestion_monto_pago = 0;

            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
                , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
                , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

            DateTime Fecha_fin1 = Fecha_fin.Date.AddDays(1).AddSeconds(-1);
            DateTime Fecha_pago;
            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                Fecha_pago = pago_simulado.fecha_proximo;
                pago_simulado = new sim_pago(pago_simulado, Fecha_pago, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
                if (Fecha_pago < Fecha_fin1)
                {
                    Restante_gestion_num_cuotas += 1;
                    Restante_gestion_amortizacion += pago_simulado.amortizacion;
                    Restante_gestion_seguro += pago_simulado.seguro;
                    Restante_gestion_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                    Restante_gestion_interes_corriente += pago_simulado.interes;
                    Restante_gestion_monto_pago += pago_simulado.monto_pago;
                }
                else
                {
                    Despues_gestion_num_cuotas += 1;
                    Despues_gestion_amortizacion += pago_simulado.amortizacion;
                    Despues_gestion_seguro += pago_simulado.seguro;
                    Despues_gestion_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                    Despues_gestion_interes_corriente += pago_simulado.interes;
                    Despues_gestion_monto_pago += pago_simulado.monto_pago;
                }
            }
        }

        public static DataTable Bancarizacion(DateTime Fecha_pago_inicio, DateTime Fecha_pago_fin, string Id_negocio)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Bancarizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_pago_inicio", DbType.DateTime, Fecha_pago_inicio);
            db1.AddInParameter(cmd, "fecha_pago_fin", DbType.DateTime, Fecha_pago_fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        
        #endregion
    }
    public class itemFact
    {
        private int _index = 0;
        private int _num1 = 0;
        private int _num2 = 0;
        private DateTime _fecha = DateTime.Now;
        private string _num_autorizacion = "";

        public int index { get { return _index; } set { _index = value; } }
        public int num1 { get { return _num1; } set { _num1 = value; } }
        public int num2 { get { return _num2; } set { _num2 = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string num_autorizacion { get { return _num_autorizacion; } set { _num_autorizacion = value; } }

        public itemFact(int Index, int Num1, int Num2, DateTime Fecha, string Num_autorizacion)
        {
            _index = Index;
            _num1 = Num1;
            _num2 = Num2;
            _fecha = Fecha;
            _num_autorizacion = Num_autorizacion;
        }
    }
}