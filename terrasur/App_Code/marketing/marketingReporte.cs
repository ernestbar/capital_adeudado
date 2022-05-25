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
/// Summary description for marketingReporte
/// </summary>
namespace terrasur
{
    public class marketingReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
            //public marketingReporte() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataView ReporteVentasTotales(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa, int Id_moneda, bool Consolidado)
        {
            //Con una modificación del reporte de ventas totales
            //[grupoventa],[promotor],[numero_contrato],[precio_final],[cuota_inicial],[total_venta_general]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteVentasTotales");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            DataTable tabla_general = db1.ExecuteDataSet(cmd).Tables[0];
            
            DataTable tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("grupoventa", typeof(string)));
            tabla.Columns.Add(new DataColumn("promotor", typeof(string)));
            tabla.Columns.Add(new DataColumn("total_venta", typeof(decimal)));
            tabla.Columns.Add(new DataColumn("total_inicial", typeof(decimal)));
            tabla.Columns.Add(new DataColumn("num_ventas", typeof(int)));
            tabla.Columns.Add(new DataColumn("total_venta_grupo", typeof(decimal)));
            tabla.Columns.Add(new DataColumn("total_venta_general", typeof(decimal)));
            foreach (DataRow fila_general in tabla_general.Rows)
            {
                int index = -1;
                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    if (tabla.Rows[j]["grupoventa"].ToString() == fila_general["grupoventa"].ToString() && tabla.Rows[j]["promotor"].ToString() == fila_general["promotor"].ToString())
                    {
                        index = j;
                        break;
                    }
                }
                if (index == -1)
                {
                    DataRow fila = tabla.NewRow();
                    fila["grupoventa"] = fila_general["grupoventa"];
                    fila["promotor"] = fila_general["promotor"];
                    fila["total_venta"] = fila_general["precio_final"];
                    fila["total_inicial"] = fila_general["cuota_inicial"];
                    fila["num_ventas"] = 1;
                    fila["total_venta_grupo"] = 0;
                    fila["total_venta_general"] = fila_general["total_venta_general"];
                    tabla.Rows.Add(fila);
                }
                else
                {
                    tabla.Rows[index]["total_venta"] = (decimal)tabla.Rows[index]["total_venta"] + (decimal)fila_general["precio_final"];
                    tabla.Rows[index]["total_inicial"] = (decimal)tabla.Rows[index]["total_inicial"] + (decimal)fila_general["cuota_inicial"];
                    tabla.Rows[index]["num_ventas"] = (int)tabla.Rows[index]["num_ventas"] + 1;
                }
            }
            TotalReporteVentasTotales(ref tabla);
            DataView dv = tabla.DefaultView;
            dv.Sort = "grupoventa,promotor,num_ventas desc";
            return dv;
        }
        private static void TotalReporteVentasTotales(ref DataTable tabla)
        {
            System.Collections.Hashtable grupos = new System.Collections.Hashtable();
            foreach (DataRow fila in tabla.Rows)
            {
                string grupoventa = fila["grupoventa"].ToString();
                decimal total_venta = decimal.Parse(fila["total_venta"].ToString());
                if (grupos.Contains(grupoventa) == true)
                    grupos[grupoventa] = decimal.Parse(grupos[grupoventa].ToString()) + total_venta;
                else grupos.Add(grupoventa, total_venta);
            }
            foreach (DataRow fila in tabla.Rows)
                fila["total_venta_grupo"] = decimal.Parse(grupos[fila["grupoventa"].ToString()].ToString());
        }


        public static DataTable ReporteVentasGeneral(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa,
            int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion, int Id_moneda, bool Consolidado)
        {
            //[negocio],[contrato_numero],[contrato_fecha],[contrato_fecha_pago_inicial],[venta_grupo],[venta_promotor],[venta_localizacion],[venta_urbanizacion],[venta_manzano],[venta_lote],[cliente_paterno],[cliente_materno],[cliente_nombres],[codigo_moneda]
            //[tipo_cambio],[precio],[descuento],[precio_final],[cuota_inicial],[cuota_base],[mantenimiento_sus],
            //[num_cuotas],[seguro],[interes_corriente]
            //Orden: [negocio],[contrato_numero]
            if (Consolidado == false) { return ReporteVentasGeneral_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteVentasGeneral_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_moneda);
                    tabla_bs = ReporteVentasGeneral_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteVentasGeneral_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_segunda_moneda);
                    tabla_bs = ReporteVentasGeneral_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_moneda);
                }//
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento,precio_final,cuota_inicial,cuota_base,mantenimiento_sus", false, false, "", "negocio,contrato_numero");
            }
        }
        private static DataTable ReporteVentasGeneral_original(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa,
            int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteVentasGeneral");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, Id_grupopromotor);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteVentasGeneral2(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa,
            int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion, int Id_moneda, bool Consolidado)
        {
            //[negocio],[contrato_numero],[contrato_fecha],[contrato_fecha_pago_inicial],[venta_grupo],[venta_promotor],[venta_localizacion],[venta_urbanizacion],[venta_manzano],[venta_lote],[cliente_paterno],[cliente_materno],[cliente_nombres],[codigo_moneda]
            //[tipo_cambio],[precio],[descuento],[precio_final],[cuota_inicial],[cuota_base],[mantenimiento_sus],[capital_amortizado],[saldo_capital]
            //[num_cuotas],[seguro],[interes_corriente],[porcentaje_cancelado]
            //Orden: [negocio],[contrato_numero]

            if (Consolidado == false) { return ReporteVentasGeneral2_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteVentasGeneral2_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_moneda);
                    tabla_bs = ReporteVentasGeneral2_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteVentasGeneral2_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_segunda_moneda);
                    tabla_bs = ReporteVentasGeneral2_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Id_moneda);
                }//
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento,precio_final,cuota_inicial,cuota_base,mantenimiento_sus,capital_amortizado,saldo_capital", false, false, "", "negocio,contrato_numero");
            }

        }
        private static DataTable ReporteVentasGeneral2_original(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa, 
            int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteVentasGeneral2");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, Id_grupopromotor);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteVentasDetalle(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_negocio, string Orden, int Id_moneda, bool Consolidado)
        {
            //[negocio],[contrato_numero],[contrato_fecha],[contrato_fecha_pago_inicial],[contrato_superficie],[venta_grupo],[venta_promotor],[venta_localizacion],[venta_urbanizacion],[venta_manzano],[venta_lote],[cliente_paterno],[cliente_materno],[cliente_nombres],[codigo_moneda],
            //[tipo_cambio],[precio],[descuento_efectivo],[precio_final],[cuota_inicial],[cuota_base],[mantenimiento_sus]
            //[descuento_porcentaje],,[num_cuotas],[seguro],[interes_corriente]

            if (Orden == "lote") Orden = "venta_localizacion,venta_urbanizacion,venta_manzano,venta_lote";

            if (Consolidado == false) { return ReporteVentasDetalle_original(Fecha_inicio, Fecha_fin, Id_negocio, Orden, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteVentasDetalle_original(Fecha_inicio, Fecha_fin, Id_negocio, Orden, Id_moneda);
                    tabla_bs = ReporteVentasDetalle_original(Fecha_inicio, Fecha_fin, Id_negocio, Orden, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteVentasDetalle_original(Fecha_inicio, Fecha_fin, Id_negocio, Orden, Id_segunda_moneda);
                    tabla_bs = ReporteVentasDetalle_original(Fecha_inicio, Fecha_fin, Id_negocio, Orden, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento_efectivo,precio_final,cuota_inicial,cuota_base,mantenimiento_sus", false, false, "", Orden);
            }
        }
        private static DataTable ReporteVentasDetalle_original(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_negocio, string Orden, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteVentasDetalle");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            tabla.DefaultView.Sort = Orden;
            return tabla;
        }


        public static DataTable ReporteMora(DateTime Fecha, int Id_grupoventa, int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion,
            int Tipo_limite, int Num_dias1, int Num_dias2, int Num_dias_ultimo_pago, int Id_moneda, bool Consolidado)
        {
            //[venta_grupo],[venta_promotor],[contrato_numero],[contrato_tipo],[intercambio],[contrato_fecha],[contrato_fecha_pago_inicial],
            //[venta_lote],[cliente],[celular],[domicilio_fono],[oficina_fono],[num_pagos],[num_cuotas],[fecha_inicio_plan]
            //[fecha_ultimo_pago],[fecha_proximo_pago],[fecha_pago_interes],[num_dias_retraso],[num_dias_mora],[codigo_moneda]
            //[tipo_cambio],[sum_monto_pago],[sum_seguro],[sum_mantenimiento],[sum_interes],[sum_amortizacion],[precio_final],[saldo]
            //[porcentaje_cancelado],[negocio],[ultimo_pago_string]
            //Orden: [ultimo_pago_string],[sum_amortizacion]
            if (Consolidado == false) { return ReporteMora_original(Fecha, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_limite, Num_dias1, Num_dias2, Num_dias_ultimo_pago, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteMora_original(Fecha, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_limite, Num_dias1, Num_dias2, Num_dias_ultimo_pago, Id_moneda);
                    tabla_bs = ReporteMora_original(Fecha, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_limite, Num_dias1, Num_dias2, Num_dias_ultimo_pago, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteMora_original(Fecha, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_limite, Num_dias1, Num_dias2, Num_dias_ultimo_pago, Id_segunda_moneda);
                    tabla_bs = ReporteMora_original(Fecha, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_limite, Num_dias1, Num_dias2, Num_dias_ultimo_pago, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "sum_monto_pago,sum_seguro,sum_mantenimiento,sum_interes,sum_amortizacion,precio_final,saldo", false, false, "", "ultimo_pago_string,sum_amortizacion");
            }
        }
        private static DataTable ReporteMora_original(DateTime Fecha, int Id_grupoventa, int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion,
            int Tipo_limite, int Num_dias1, int Num_dias2, int Num_dias_ultimo_pago, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteMora");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, Id_grupopromotor);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "tipo_limite", DbType.Int32, Tipo_limite);
            db1.AddInParameter(cmd, "num_dias1", DbType.Int32, Num_dias1);
            db1.AddInParameter(cmd, "num_dias2", DbType.Int32, Num_dias2);
            db1.AddInParameter(cmd, "num_dias_ultimo_pago", DbType.Int32, Num_dias_ultimo_pago);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteGerencialVentas(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_moneda, bool Consolidado)
        {
            //[id_negocio],[codigo_negocio],[nombre_negocio],[origen_negocio],
            //[num_ventas],[sum_cuota_inicial],[sum_precio],[sum_precio_final],[sum_descuento]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteGerencialVentas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteVentasGeneral_reversion(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa,
            int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion, int Tipo_venta, int Id_moneda, bool Consolidado)
        {
            //[negocio],[contrato_numero],[contrato_fecha],[contrato_fecha_pago_inicial],[venta_grupo],[venta_promotor],[venta_localizacion],[venta_urbanizacion],[venta_manzano],[venta_lote],[cliente_paterno],[cliente_materno],[cliente_nombres],[codigo_moneda],
            //[tipo_cambio],[precio],[descuento],[precio_final],[cuota_inicial],[cuota_base],[mantenimiento_sus],
            //[num_cuotas],[seguro],[interes_corriente],[num_reversiones],[reversion_num_contrato],[reversion_fecha]
            //Orden: [negocio],[contrato_numero]

            if (Consolidado == false) { return ReporteVentasGeneral_reversion_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_venta, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteVentasGeneral_reversion_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_venta, Id_moneda);
                    tabla_bs = ReporteVentasGeneral_reversion_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_venta, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteVentasGeneral_reversion_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_venta, Id_segunda_moneda);
                    tabla_bs = ReporteVentasGeneral_reversion_original(Fecha_inicio, Fecha_fin, Id_grupoventa, Id_grupopromotor, Id_localizacion, Id_urbanizacion, Tipo_venta, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento,precio_final,cuota_inicial,cuota_base,mantenimiento_sus", false, false, "", "negocio,contrato_numero");
            }
        }
        private static DataTable ReporteVentasGeneral_reversion_original(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa,
            int Id_grupopromotor, int Id_localizacion, int Id_urbanizacion, int Tipo_venta, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteVentasGeneral_reversion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, Id_grupopromotor);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "tipo_venta", DbType.Int32, Tipo_venta);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteMoraDirector(int Tipo_limite, int Num_dias1, int Num_dias2, int Id_moneda, bool Consolidado)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteMoraDirector");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            DataTable tabla_direc = db1.ExecuteDataSet(cmd).Tables[0];
            //[id_usuario],[director],[num_venta],[monto_venta],[num_mora],[monto_mora],[porcentaje_num],[porcentaje_monto]

            cmd = db1.GetStoredProcCommand("marketing_ReporteMoraDirector_ContratosMora");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "tipo_limite", DbType.Int32, Tipo_limite);
            db1.AddInParameter(cmd, "num_dias1", DbType.Int32, Num_dias1);
            db1.AddInParameter(cmd, "num_dias2", DbType.Int32, Num_dias2);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            DataTable tabla_mora = db1.ExecuteDataSet(cmd).Tables[0];
            //[id_usuario],[num_mora],[monto_mora]

            //Se obtienen los datos
            foreach (DataRow fila_direc in tabla_direc.Rows)
            {
                foreach (DataRow fila_mora in tabla_mora.Rows)
                {
                    if ((int)fila_mora["id_usuario"] == (int)fila_direc["id_usuario"])
                    {
                        fila_direc["num_mora"] = (int)fila_mora["num_mora"];
                        fila_direc["monto_mora"] = (decimal)fila_mora["monto_mora"];
                        break;
                    }
                }
            }
            foreach (DataRow fila_direc in tabla_direc.Rows)
            {
                if ((int)fila_direc["num_venta"] > 0)
                    fila_direc["porcentaje_num"] = (decimal.Parse(fila_direc["num_mora"].ToString()) / decimal.Parse(fila_direc["num_venta"].ToString())) * 100;
                else fila_direc["porcentaje_num"] = 0;
                if ((decimal)fila_direc["monto_venta"] > 0)
                    fila_direc["porcentaje_monto"] = ((decimal)fila_direc["monto_mora"] / (decimal)fila_direc["monto_venta"]) * 100;
                else fila_direc["porcentaje_monto"] = 0;
            }
            return tabla_direc;
        }


        public static DataTable ReporteComisionDirector(DateTime Fecha_inicio, DateTime Fecha_fin, bool Con_revertidos, int Id_moneda, bool Consolidado)
        {
            //[grupo_venta],[director],[num_ventas],[sum_precio_final],[sum_cuota_inicial],[comision]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteComisionDirector");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "con_revertidos", DbType.Boolean, Con_revertidos);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteComisionPromotor(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[orden_promotor],[nombre_promotor],[fecha_contrato],[fecha_cuota_inicial],[num_contrato],[negocio],[cliente],[forma_pago],
            //[tipo_cambio],[precio_final],[cuota_inicial],[comision_total],[comision_inicial],[monto_comisiones],
            //[comision_porcentaje],[num_comisiones],[codigo_moneda],[nombre_moneda]
            //Orden: [orden_promotor],[nombre_promotor],[fecha_cuota_inicial],[num_contrato]
            if (Consolidado == false) { return ReporteComisionPromotor_original(Fecha_inicio, Fecha_fin, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteComisionPromotor_original(Fecha_inicio, Fecha_fin, Id_negocio, Id_moneda);
                    tabla_bs = ReporteComisionPromotor_original(Fecha_inicio, Fecha_fin, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteComisionPromotor_original(Fecha_inicio, Fecha_fin, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ReporteComisionPromotor_original(Fecha_inicio, Fecha_fin, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_final,cuota_inicial,comision_total,comision_inicial,monto_comisiones", false, false, "", "orden_promotor,nombre_promotor,fecha_cuota_inicial,num_contrato");
            }
        }
        private static DataTable ReporteComisionPromotor_original(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteComisionPromotor");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteVentasSector(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_localizacion, int Id_moneda, bool Consolidado)
        {
            //[contrato_numero],[contrato_fecha],[venta_localizacion],[venta_urbanizacion],[inicio],[fin],[codigo_moneda]
            //[tipo_cambio],[precio],[descuento],[precio_final],[cuota_inicial]
            //Orden: [venta_localizacion],[venta_urbanizacion]
            if (Consolidado == false) { return ReporteVentasSector_original(Fecha_inicio, Fecha_fin, Id_localizacion, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteVentasSector_original(Fecha_inicio, Fecha_fin, Id_localizacion, Id_moneda);
                    tabla_bs = ReporteVentasSector_original(Fecha_inicio, Fecha_fin, Id_localizacion, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteVentasSector_original(Fecha_inicio, Fecha_fin, Id_localizacion, Id_segunda_moneda);
                    tabla_bs = ReporteVentasSector_original(Fecha_inicio, Fecha_fin, Id_localizacion, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento,precio_final,cuota_inicial", false, false, "", "venta_localizacion,venta_urbanizacion");
            }

        }
        private static DataTable ReporteVentasSector_original(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_localizacion, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteVentasSector");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteComisionPromotorArrastre(DateTime Fecha_inicio, DateTime Fecha_fin, string Id_negocio)
        {
            //[nombre_promotor],[fecha_contrato],[fecha_cuota_inicial],[num_contrato],[negocio],[lote],[cliente],[forma_pago],[codigo_moneda]
            //[precio_final],[cuota_inicial],[comision_total],[comision_inicial],[monto_comisiones],[comision_porcentaje],[num_comisiones]
            //[com_ini],[com_1],[com_2],[com_3],[com_4],[com_total_ciclo]
            //Orden: [nombre_promotor],[fecha_cuota_inicial],[num_contrato]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteComisionPromotorArrastre");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            DataTable reporte = db1.ExecuteDataSet(cmd).Tables[0];
            //marketingReporte.TablaTotcom(Fecha_inicio, Fecha_fin, ConfigurationManager.AppSettings["promotor_codigo"]);
            return reporte;
        }

        public static void TablaTotcom(bool bs, decimal tc, DateTime Arrastre_inicio, DateTime Arrastre_fin, DateTime Inicial_inicio, DateTime Inicial_fin, string Id_negocio)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("marketing_TablaTotcom");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "arrastre_inicio", DbType.DateTime, Arrastre_inicio);
                db1.AddInParameter(cmd, "arrastre_fin", DbType.DateTime, Arrastre_fin);
                db1.AddInParameter(cmd, "inicial_inicio", DbType.DateTime, Inicial_inicio);
                db1.AddInParameter(cmd, "inicial_fin", DbType.DateTime, Inicial_fin);
                db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
                db1.ExecuteNonQuery(cmd);

            }
            catch { }
        }

        public static DataTable ReporteComisionPromotorArrastre_marketing(DateTime Arrastre_inicio, DateTime Arrastre_fin, DateTime Inicial_inicio, DateTime Inicial_fin, string Id_negocio)
        {
            //[nombre_promotor],[fecha_contrato],[fecha_cuota_inicial],[num_contrato],[negocio],[lote],[cliente],[forma_pago],[codigo_moneda]
            //[precio_final],[cuota_inicial],[comision_porcentaje],[comision_total],[comision_inicial],[num_comisiones],[monto_comisiones]
            //[com_ini],[com_1],[com_2],[com_3],[com_4],[com_inicial],[com_arrastre],[com_total]
            //Orden: [nombre_promotor],[fecha_cuota_inicial],[num_contrato]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteComisionPromotorArrastre_marketing");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "arrastre_inicio", DbType.DateTime, Arrastre_inicio);
            db1.AddInParameter(cmd, "arrastre_fin", DbType.DateTime, Arrastre_fin);
            db1.AddInParameter(cmd, "inicial_inicio", DbType.DateTime, Inicial_inicio);
            db1.AddInParameter(cmd, "inicial_fin", DbType.DateTime, Inicial_fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            foreach (DataRow fila in tabla.Rows) fila["com_total"] = ((decimal)fila["com_inicial"]) + ((decimal)fila["com_arrastre"]);
            return tabla;
        }



        public static DataView ReporteComisionPromotorArrastre_planilla(string OrdenarPor, bool bs, decimal tc, DateTime Arrastre_inicio, DateTime Arrastre_fin, DateTime Inicial_inicio, DateTime Inicial_fin, string Id_negocio)
        {
            //[grupo_venta],[id_director],[id_promotor],[promotor_nombre],[promotor_ci],[promotor_activo]
            //[num_contrato],[sector],[com_inicial],[com_arrastre],
            //[venta_nueva],[num_ventas],[bono_mov],[bono_prod],[total_ganado],[total_ganado_otra_moneda]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteComisionPromotorArrastre_planilla3");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "arrastre_inicio", DbType.DateTime, Arrastre_inicio);
            db1.AddInParameter(cmd, "arrastre_fin", DbType.DateTime, Arrastre_fin);
            db1.AddInParameter(cmd, "inicial_inicio", DbType.DateTime, Inicial_inicio);
            db1.AddInParameter(cmd, "inicial_fin", DbType.DateTime, Inicial_fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            //[id_promotor],[id_director],[volumen_ventas],[num_ventas],
            //[bono_mov],[bono_prod],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio]
            DataTable tabla_ventas = ReporteComisionPromotorArrastre_planilla_ventas(tabla);

            //Se modifican los bonos necesarios
            //[id_bono],[id_promotor],[bono_mov],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio]
            DataTable tabla_bonos = bono_promotor.Lista(Arrastre_inicio.Date);
            foreach (DataRow fila_bonos in tabla_bonos.Rows)
            {
                int id_promotor = (int)fila_bonos["id_promotor"];
                decimal bono_mov = (decimal)fila_bonos["bono_mov"];
                decimal bono_prod_num_ventas = (decimal)fila_bonos["bono_prod_num_ventas"];
                decimal bono_prod_monto_ventas = (decimal)fila_bonos["bono_prod_monto_ventas"];
                decimal bono_prod_premio = (decimal)fila_bonos["bono_prod_premio"];

                foreach (DataRow fila_ventas in tabla_ventas.Rows)
                {
                    if (((int)fila_ventas["id_promotor"]) == id_promotor)
                    {
                        if (bono_mov >= 0) { fila_ventas["bono_mov"] = bono_mov; }
                        if (bono_prod_num_ventas >= 0 || bono_prod_monto_ventas >= 0 || bono_prod_premio >= 0)
                        {
                            if (bono_prod_num_ventas >= 0) { fila_ventas["bono_prod_num_ventas"] = bono_prod_num_ventas; }
                            if (bono_prod_monto_ventas >= 0) { fila_ventas["bono_prod_monto_ventas"] = bono_prod_monto_ventas; }
                            if (bono_prod_premio >= 0) { fila_ventas["bono_prod_premio"] = bono_prod_premio; }
                            fila_ventas["bono_prod"] = ((decimal)fila_ventas["bono_prod_num_ventas"]) + ((decimal)fila_ventas["bono_prod_monto_ventas"]) + ((decimal)fila_ventas["bono_prod_premio"]);
                        }
                    }
                }
            }

            //Se distribuye el monto de los bonos entre todos los contratos
            foreach (DataRow fila in tabla.Rows)
            {
                if (((decimal)fila["venta_nueva_bono"]) > 0)
                {
                    int id_promotor = (int)fila["id_promotor"];
                    decimal volumen_ventas = 0; int num_ventas = 0; decimal bono_mov = 0; decimal bono_prod = 0; decimal bono_prod_num_ventas = 0; decimal bono_prod_monto_ventas = 0; decimal bono_prod_premio = 0;
                    ReporteComisionPromotorArrastre_planilla_totales(id_promotor, ref tabla_ventas, ref volumen_ventas, ref num_ventas, ref bono_mov, ref bono_prod, ref bono_prod_num_ventas, ref bono_prod_monto_ventas, ref bono_prod_premio);

                    if (volumen_ventas > 0) fila["bono_mov"] = (((decimal)fila["venta_nueva_bono"]) / volumen_ventas) * bono_mov;
                    //if (num_ventas > 0) fila["bono_prod"] = bono_prod / ((decimal)num_ventas);

                    if (num_ventas > 0) fila["bono_prod_num_ventas"] = bono_prod_num_ventas / ((decimal)num_ventas);
                    if (volumen_ventas > 0) fila["bono_prod_monto_ventas"] = (((decimal)fila["venta_nueva_bono"]) / volumen_ventas) * bono_prod_monto_ventas;
                    if (volumen_ventas > 0) fila["bono_prod_premio"] = (((decimal)fila["venta_nueva_bono"]) / volumen_ventas) * bono_prod_premio;
                    fila["bono_prod"] = ((decimal)fila["bono_prod_num_ventas"]) + ((decimal)fila["bono_prod_monto_ventas"]) + ((decimal)fila["bono_prod_premio"]);

                }
            }
            //Se obtiene el total ganado
            foreach (DataRow fila in tabla.Rows)
            {
                fila["total_ganado"] = ((decimal)fila["com_inicial"]) + ((decimal)fila["com_arrastre"]) + ((decimal)fila["bono_mov"]) + ((decimal)fila["bono_prod"]);
                fila["total_ganado_otra_moneda"] = ((decimal)fila["total_ganado"]);
            }
            //Se realiza la conversión de moneda
            if (bs == true)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    fila["com_inicial"] = ((decimal)fila["com_inicial"]) * tc;
                    fila["com_arrastre"] = ((decimal)fila["com_arrastre"]) * tc;
                    //fila["venta_nueva"] = ((decimal)fila["venta_nueva"]) * tc;
                    fila["bono_mov"] = ((decimal)fila["bono_mov"]) * tc;
                    fila["bono_prod"] = ((decimal)fila["bono_prod"]) * tc;
                    fila["bono_prod_num_ventas"] = ((decimal)fila["bono_prod_num_ventas"]) * tc;
                    fila["bono_prod_monto_ventas"] = ((decimal)fila["bono_prod_monto_ventas"]) * tc;
                    fila["bono_prod_premio"] = ((decimal)fila["bono_prod_premio"]) * tc;
                    fila["total_ganado"] = ((decimal)fila["total_ganado"]) * tc;
                    //fila["total_ganado_otra_moneda"] = ((decimal)fila["total_ganado_otra_moneda"]);
                }
            }
            else
            {
                //Se obtiene el total ganado en otra moneda
                foreach (DataRow fila in tabla.Rows)
                    fila["total_ganado_otra_moneda"] = ((decimal)fila["total_ganado_otra_moneda"]) * tc;
            }

            DataView dv = tabla.DefaultView;
            dv.Sort = OrdenarPor;
            return dv;
        }
        private static DataTable ReporteComisionPromotorArrastre_planilla_ventas(DataTable tabla)
        {
            //[id_promotor],[id_director],[volumen_ventas],[num_ventas],
            //[bono_mov],[bono_prod],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio]
            DataTable tabla_ventas = new DataTable();
            tabla_ventas.Columns.Add("id_promotor", typeof(int));
            tabla_ventas.Columns.Add("id_director", typeof(int));
            tabla_ventas.Columns.Add("volumen_ventas", typeof(decimal));
            tabla_ventas.Columns.Add("num_ventas", typeof(int));
            tabla_ventas.Columns.Add("bono_mov", typeof(decimal));
            tabla_ventas.Columns.Add("bono_prod", typeof(decimal));
            tabla_ventas.Columns.Add("bono_prod_num_ventas", typeof(decimal));
            tabla_ventas.Columns.Add("bono_prod_monto_ventas", typeof(decimal));
            tabla_ventas.Columns.Add("bono_prod_premio", typeof(decimal));
            //tabla_ventas.Columns.Add("total_ganado", typeof(decimal));
            int index_ventas = -1;

            //Primero se determina el volumen y el número de ventas
            foreach (DataRow fila in tabla.Rows)
            {
                index_ventas = -1;
                for (int j = 0; j < tabla_ventas.Rows.Count; j++)
                {
                    if (((int)tabla_ventas.Rows[j]["id_promotor"]) == ((int)fila["id_promotor"]))
                    {
                        index_ventas = j;
                        break;
                    }
                }
                if (index_ventas >= 0)
                {
                    if (((decimal)fila["venta_nueva_bono"]) > 0)
                    {
                        tabla_ventas.Rows[index_ventas]["volumen_ventas"] = ((decimal)tabla_ventas.Rows[index_ventas]["volumen_ventas"]) + ((decimal)fila["venta_nueva_bono"]);
                        tabla_ventas.Rows[index_ventas]["num_ventas"] = ((int)tabla_ventas.Rows[index_ventas]["num_ventas"]) + ((int)fila["num_ventas"]);
                    }
                }
                else
                {
                    DataRow nueva_fila = tabla_ventas.NewRow();
                    nueva_fila["id_promotor"] = (int)fila["id_promotor"];
                    nueva_fila["id_director"] = (int)fila["id_director"];
                    nueva_fila["volumen_ventas"] = ((decimal)fila["venta_nueva_bono"]);
                    nueva_fila["num_ventas"] = ((int)fila["num_ventas"]);
                    tabla_ventas.Rows.Add(nueva_fila);
                }
            }

            //Ahora se determina el monto de los bonos
            //[id_grupopromotor],[volumen_ventas],[num_ventas],[bono_prod],[bono_mov]
            int id_primero = 0; int id_segundo = 0;
            decimal aux_volumen_ventas1 = 0; decimal aux_volumen_ventas2 = 0;
            foreach (DataRow fila in tabla_ventas.Rows)
            {
                //Se calcula el bono de movilidad
                decimal volumen_ventas = (decimal)fila["volumen_ventas"];
                //if (volumen_ventas < 10000) fila["bono_mov"] = 0;
                //else if (10000 <= volumen_ventas && volumen_ventas < 15000) fila["bono_mov"] = 60;
                //else if (15000 <= volumen_ventas && volumen_ventas < 20000) fila["bono_mov"] = 80;
                //else if (20000 <= volumen_ventas && volumen_ventas < 50000) fila["bono_mov"] = 100;
                //else fila["bono_mov"] = 150;
                if (volumen_ventas < 30000) fila["bono_mov"] = 0;
                else if (30000 <= volumen_ventas && volumen_ventas < 40001) fila["bono_mov"] = 60;
                else if (40001 <= volumen_ventas && volumen_ventas < 80001) fila["bono_mov"] = 80;
                else fila["bono_mov"] = 100;


                //Se calcula en bono de producción (por el número de ventas)
                int num_ventas = (int)fila["num_ventas"];
                //if (num_ventas < 3) fila["bono_prod_num_ventas"] = 0;
                //else if (3 <= num_ventas && num_ventas <= 4) fila["bono_prod_num_ventas"] = 20;
                //else if (5 <= num_ventas && num_ventas <= 6) fila["bono_prod_num_ventas"] = 30;
                //else fila["bono_prod_num_ventas"] = 40;
                fila["bono_prod_num_ventas"] = 0;

                //Se calcula en bono de producción (por el volumen de ventas)
                //if ((decimal)fila["volumen_ventas"] > 26000) fila["bono_prod_monto_ventas"] = 10;
                //else fila["bono_prod_monto_ventas"] = 0;
                fila["bono_prod_monto_ventas"] = 0;

                //Se evalúa cuál es el primero y segundo en ventas (por el volumen de ventas)
                if (((int)fila["id_promotor"]) != ((int)fila["id_director"]))
                {
                    if ((decimal)fila["volumen_ventas"] >= aux_volumen_ventas2)
                    {
                        id_segundo = (int)fila["id_promotor"];
                        aux_volumen_ventas2 = (decimal)fila["volumen_ventas"];
                    }
                    if (aux_volumen_ventas2 > aux_volumen_ventas1)
                    {
                        int aux_id_promotor = id_segundo; decimal aux_volumen = aux_volumen_ventas2;
                        id_segundo = id_primero; aux_volumen_ventas2 = aux_volumen_ventas1;
                        id_primero = aux_id_promotor; aux_volumen_ventas1 = aux_volumen;
                    }
                    //if ((decimal)fila["volumen_ventas"] >= aux_volumen_ventas1)
                    //{
                    //    id_segundo = id_primero;
                    //    id_primero = (int)fila["id_promotor"];
                    //    aux_volumen_ventas1 = (decimal)fila["volumen_ventas"];
                    //}
                }
            }
            //Se asignan los premios para el 1ro y 2do
            foreach (DataRow fila in tabla_ventas.Rows)
            {
                if ((int)fila["id_promotor"] == id_primero) fila["bono_prod_premio"] = 100;
                else if ((int)fila["id_promotor"] == id_segundo) fila["bono_prod_premio"] = 50;
                else fila["bono_prod_premio"] = 0;
                decimal bono_prod_num_ventas = (decimal)fila["bono_prod_num_ventas"];
                decimal bono_prod_monto_ventas = (decimal)fila["bono_prod_monto_ventas"];
                decimal bono_prod_premio = (decimal)fila["bono_prod_premio"];
                
                fila["bono_prod_premio"] = 0;
                fila["bono_prod_num_ventas"]=0;
                fila["bono_prod_monto_ventas"] = 0;
                fila["bono_prod"] = bono_prod_num_ventas + bono_prod_monto_ventas + bono_prod_premio;
            } 
            return tabla_ventas;
        }
        private static void ReporteComisionPromotorArrastre_planilla_totales(int id_promotor, ref DataTable tabla, ref decimal volumen_ventas, ref int num_ventas, ref decimal bono_mov, ref decimal bono_prod, ref decimal bono_prod_num_ventas, ref decimal bono_prod_monto_ventas, ref decimal bono_prod_premio)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                if (((int)fila["id_promotor"]) == id_promotor)
                {
                    volumen_ventas = (decimal)fila["volumen_ventas"];
                    num_ventas = (int)fila["num_ventas"];
                    bono_mov = (decimal)fila["bono_mov"];
                    bono_prod = (decimal)fila["bono_prod"];
                    bono_prod_num_ventas = (decimal)fila["bono_prod_num_ventas"];
                    bono_prod_monto_ventas = (decimal)fila["bono_prod_monto_ventas"];
                    bono_prod_premio = (decimal)fila["bono_prod_premio"];
                    break;
                }
            }
        }

        public static bool ReporteComisionPromotorArrastre_planilla_GuardarBonos(DateTime Arrastre_inicio, DateTime Arrastre_fin, DateTime Inicial_inicio, DateTime Inicial_fin, string Id_negocio)
        {
            //[tipo_inmueble],[grupo_venta],[id_director],[id_promotor],[promotor_nombre],[promotor_ci]
            //[promotor_activo],[num_contrato],[sector],[com_inicial],[com_arrastre],[venta_nueva],[num_ventas]
            //[bono_mov],[bono_prod],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio],[total_ganado],[total_ganado_otra_moneda]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteComisionPromotorArrastre_planilla3");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "arrastre_inicio", DbType.DateTime, Arrastre_inicio);
            db1.AddInParameter(cmd, "arrastre_fin", DbType.DateTime, Arrastre_fin);
            db1.AddInParameter(cmd, "inicial_inicio", DbType.DateTime, Inicial_inicio);
            db1.AddInParameter(cmd, "inicial_fin", DbType.DateTime, Inicial_fin);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            //[id_promotor],[id_director],[volumen_ventas],[num_ventas],
            //[bono_mov],[bono_prod],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio]
            DataTable tabla_ventas = ReporteComisionPromotorArrastre_planilla_ventas(tabla);

            //Se modifican los bonos necesarios
            //[id_bono],[id_promotor],[bono_mov],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio]
            DataTable tabla_bonos = bono_promotor.Lista(Arrastre_inicio.Date);
            foreach (DataRow fila_bonos in tabla_bonos.Rows)
            {
                int id_promotor = (int)fila_bonos["id_promotor"];
                decimal bono_mov = (decimal)fila_bonos["bono_mov"];
                decimal bono_prod_num_ventas = (decimal)fila_bonos["bono_prod_num_ventas"];
                decimal bono_prod_monto_ventas = (decimal)fila_bonos["bono_prod_monto_ventas"];
                decimal bono_prod_premio = (decimal)fila_bonos["bono_prod_premio"];

                foreach (DataRow fila_ventas in tabla_ventas.Rows)
                {
                    if (((int)fila_ventas["id_promotor"]) == id_promotor)
                    {
                        if (bono_mov >= 0) { fila_ventas["bono_mov"] = bono_mov; }
                        if (bono_prod_num_ventas >= 0 || bono_prod_monto_ventas >= 0 || bono_prod_premio >= 0)
                        {
                            if (bono_prod_num_ventas >= 0) { fila_ventas["bono_prod_num_ventas"] = bono_prod_num_ventas; }
                            if (bono_prod_monto_ventas >= 0) { fila_ventas["bono_prod_monto_ventas"] = bono_prod_monto_ventas; }
                            if (bono_prod_premio >= 0) { fila_ventas["bono_prod_premio"] = bono_prod_premio; }
                            fila_ventas["bono_prod"] = ((decimal)fila_ventas["bono_prod_num_ventas"]) + ((decimal)fila_ventas["bono_prod_monto_ventas"]) + ((decimal)fila_ventas["bono_prod_premio"]);
                        }
                    }
                }
            }

            //Se guardan los datos obtenidos
            bool correcto = true;
            foreach (DataRow fila_ventas in tabla_ventas.Rows)
            {
                int Id_promotor = (int)fila_ventas["id_promotor"];
                decimal Bono_mov = (decimal)fila_ventas["bono_mov"];
                decimal Bono_prod_num_ventas = (decimal)fila_ventas["bono_prod_num_ventas"];
                decimal Bono_prod_monto_ventas = (decimal)fila_ventas["bono_prod_monto_ventas"];
                decimal Bono_prod_premio = (decimal)fila_ventas["bono_prod_premio"];
                bono_promotor bnObj = new bono_promotor(Id_promotor, Arrastre_inicio.Date, Bono_mov, Bono_prod_num_ventas, Bono_prod_monto_ventas, Bono_prod_premio);
                if (bnObj.Registrar(1) == false) correcto = false;
            }
            return correcto;
        }


        public static DataTable ReporteReversionDescuento(bool Director, DateTime Fecha_inicio, DateTime Fecha_evaluacion, DateTime Fecha_cuotainicial_inicio, DateTime Fecha_cuotainicial_fin, int Num_pagos, decimal Porcentaje_cancelado, decimal Monto_cancelado, string Id_motivoreversion)
        {
            //[id_transaccion],[fecha],[id_contrato],[fecha_ejecutado],[institucion],[num_contrato],
            //[concepto],[num_cuota],[fecha_pago],[interes],[capital],[monto],[fuera_de_hora]
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteReversiones");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "director", DbType.Boolean, Director);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_evaluacion", DbType.DateTime, Fecha_evaluacion);

            db1.AddInParameter(cmd, "fecha_cuotainicial_inicio", DbType.DateTime, Fecha_cuotainicial_inicio);
            db1.AddInParameter(cmd, "fecha_cuotainicial_fin", DbType.DateTime, Fecha_cuotainicial_fin);
            db1.AddInParameter(cmd, "num_pagos_evitar_descuento", DbType.Int32, Num_pagos);
            db1.AddInParameter(cmd, "porcentaje_cancelado", DbType.Decimal, Porcentaje_cancelado);
            db1.AddInParameter(cmd, "monto_cancelado", DbType.Decimal, Monto_cancelado);
            db1.AddInParameter(cmd, "id_motivoreversion", DbType.String, Id_motivoreversion);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteReversiones_director(DateTime Fecha_inicio, DateTime Fecha_fin, DateTime Fecha_cuotainicial_inicio, DateTime Fecha_cuotainicial_fin, int Num_pagos, decimal Porcentaje_cancelado, decimal Monto_cancelado, string Id_motivoreversion)
        {
            //[id_grupoventa],[id_ciclocomercial],[grupo_venta],[num_contrato],[precio_final],[fecha_reversion],[pago_inicial_fecha],[ciclo],[ciclo_fecha_inicio],[ciclo_fecha_fin]
            //[volumen_ventas],[comision],[nuevo_volumen_ventas],[nueva_comision],[descuento]

            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteReversiones_director");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "fecha_cuotainicial_inicio", DbType.DateTime, Fecha_cuotainicial_inicio);
            db1.AddInParameter(cmd, "fecha_cuotainicial_fin", DbType.DateTime, Fecha_cuotainicial_fin);
            db1.AddInParameter(cmd, "num_pagos_evitar_descuento", DbType.Int32, Num_pagos);
            db1.AddInParameter(cmd, "porcentaje_cancelado", DbType.Decimal, Porcentaje_cancelado);
            db1.AddInParameter(cmd, "monto_cancelado", DbType.Decimal, Monto_cancelado);
            db1.AddInParameter(cmd, "id_motivoreversion", DbType.String, Id_motivoreversion);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            int index = 0;
            while (index < tabla.Rows.Count - 1)
            {
                int id_grupoventa = int.Parse(tabla.Rows[index]["id_grupoventa"].ToString());
                int id_ciclocomercial = int.Parse(tabla.Rows[index]["id_ciclocomercial"].ToString());

                //
                int id_grupoventa_siguiente = int.Parse(tabla.Rows[index + 1]["id_grupoventa"].ToString());
                int id_ciclocomercial_siguiente = int.Parse(tabla.Rows[index + 1]["id_ciclocomercial"].ToString());
                int index2 = index;
                while (id_grupoventa == id_grupoventa_siguiente && id_ciclocomercial == id_ciclocomercial_siguiente)
                {
                    index2 = index2 + 1;
                    if ((index2 + 1) < tabla.Rows.Count)
                    {
                        id_grupoventa_siguiente = int.Parse(tabla.Rows[index2 + 1]["id_grupoventa"].ToString());
                        id_ciclocomercial_siguiente = int.Parse(tabla.Rows[index2 + 1]["id_ciclocomercial"].ToString());
                    }
                    else
                    {
                        id_grupoventa_siguiente = 0;
                        id_ciclocomercial_siguiente = 0;
                    }
                }

                if (index2 > index)
                {
                    //Si el siguiente registro es del mismo grupo y ciclo se procesa los datos
                    decimal nuevo_volumen_ventas = (decimal)tabla.Rows[index2]["volumen_ventas"];
                    decimal comision = (decimal)tabla.Rows[index2]["comision"];
                    DateTime ciclo_fecha_fin = (DateTime)tabla.Rows[index2]["ciclo_fecha_fin"];

                    for (int j = index; j <= index2; j++)
                    {
                        decimal precio_final = (decimal)tabla.Rows[j]["precio_final"];
                        nuevo_volumen_ventas = nuevo_volumen_ventas - precio_final;

                        tabla.Rows[j]["nuevo_volumen_ventas"] = DBNull.Value;
                        tabla.Rows[j]["nueva_comision"] = DBNull.Value;
                        tabla.Rows[j]["descuento"] = DBNull.Value;
                    }

                    decimal nueva_comision = ReporteReversiones_director_CalculoComision(nuevo_volumen_ventas, ciclo_fecha_fin);

                    tabla.Rows[index2]["nuevo_volumen_ventas"] = nuevo_volumen_ventas;
                    tabla.Rows[index2]["nueva_comision"] = nueva_comision;
                    tabla.Rows[index2]["descuento"] = comision - nueva_comision;

                    //Se avanza el index al siguiente fuera del grupo 
                    index = index2 + 1;
                }
                else
                {
                    //Si el siguiente registro NO es del mismo grupo y ciclo se avanza
                    index = index + 1;
                }
            }

            return tabla;
        }
        public static decimal ReporteReversiones_director_CalculoComision(decimal Volumen_venta, DateTime Fecha_fin_ciclo)
        {
            DbCommand cmd = db1.GetStoredProcCommand("marketing_ReporteReversiones_director_CalculoComision");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "volumen_venta", DbType.Decimal, Volumen_venta);
            db1.AddInParameter(cmd, "fecha_fin_ciclo", DbType.DateTime, Fecha_fin_ciclo);
            return (decimal)db1.ExecuteScalar(cmd);
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}