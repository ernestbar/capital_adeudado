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

/// <summary>
/// Summary description for cajaReporte
/// </summary>
/// 

namespace terrasur
{
    public class cajaReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Constructores
        public cajaReporte()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static void ReporteIngresos_Recibos(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado, ref int num_recibo_min, ref int num_recibo_max)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteIngresos_Recibos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
                db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
                db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);

                db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
                db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);

                db1.AddOutParameter(cmd, "num_recibo_min", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_recibo_max", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                num_recibo_min = (int)db1.GetParameterValue(cmd, "num_recibo_min");
                num_recibo_max = (int)db1.GetParameterValue(cmd, "num_recibo_max");
            }
            catch { }
        }


        public static DataTable ReporteNafiboIngreso(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, int Id_moneda, bool Consolidado)
        {
            //[id_transaccion],[urbanizacion_codigo],[contrato_numero],[urbanizacion_nombre],[string_cuotas],[fecha_pago],[codigo_moneda]
            //[monto_pago],[tipo_cambio],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal]
            //[num_sucursal]
            //Orden: [urbanizacion_codigo],[fecha_pago]
            if (Consolidado == false) { return ReporteNafiboIngreso_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteNafiboIngreso_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_moneda);
                    tabla_bs = ReporteNafiboIngreso_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteNafiboIngreso_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_segunda_moneda);
                    tabla_bs = ReporteNafiboIngreso_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "monto_pago,seguro,mantenimiento_sus,interes,amortizacion,saldo,interes_penal", false, false, "", "urbanizacion_codigo,fecha_pago");
            }
        }
        private static DataTable ReporteNafiboIngreso_original(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteNafiboIngreso");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteIngresosNafiboTotalesUrbanizacion(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, int Id_moneda, bool Consolidado)
        {
            //[id_negocio],[negocio_nombre],[urbanizacion_nombre],
            //[interes_penal],[servicio_monto],[cuota_inicial],[monto_pago],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[total_dpr],[total_efe]
            //[efectivo_sus],[efectivo_bs],[cheque_sus],[cheque_bs],[tarjeta_sus],[tarjeta_bs],[deposito_sus],[deposito_bs],[dpr_sus],[dpr_bs],[efe_sus],[efe_bs],[total_sus],[total_bs]
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteIngresosNafiboTotalesUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteIngresosTransaccion(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado,string Trans)
        {
            //[id_negocio],[id_transaccion],[urbanizacion_codigo],[tipo_pago],[contrato_numero],[urbanizacion_nombre],[string_cuotas],[fecha_pago],[paterno_cliente],[materno_cliente],[manzano_codigo],[lote_codigo],[codigo_moneda],
            //[cuota_inicial],[monto_pago],[tipo_cambio],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal],[servicio_monto],[total_dpr],[total_efe]
            //[efectivo_sus],[efectivo_bs],[cheque_sus],[cheque_bs],[tarjeta_sus],[tarjeta_bs],[deposito_sus],[deposito_bs],[dpr_sus],[dpr_bs],[efe_sus],[efe_bs],[total_sus],[total_bs]
            //[servicio_codigo],[num_factura],[num_recibo],[num_comprobante],[nombre_dpr],[num_control]
            //Orden: [urbanizacion_codigo],[urbanizacion_nombre],[id_transaccion]
            if (Consolidado == false) { return ReporteIngresos_original_Transacciones(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda,Trans); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteIngresos_original_Transacciones(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Trans);
                    tabla_bs = ReporteIngresos_original_Transacciones(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda, Trans);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteIngresos_original_Transacciones(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda, Trans);
                    tabla_bs = ReporteIngresos_original_Transacciones(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Trans);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_inicial,monto_pago,seguro,mantenimiento_sus,interes,amortizacion,saldo,interes_penal,servicio_monto,total_dpr,total_efe", false, false, "", "urbanizacion_codigo,urbanizacion_nombre,id_transaccion");
            }
        }

        public static DataTable ReporteIngresos(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[id_negocio],[id_transaccion],[urbanizacion_codigo],[tipo_pago],[contrato_numero],[urbanizacion_nombre],[string_cuotas],[fecha_pago],[paterno_cliente],[materno_cliente],[manzano_codigo],[lote_codigo],[codigo_moneda],
            //[cuota_inicial],[monto_pago],[tipo_cambio],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal],[servicio_monto],[total_dpr],[total_efe]
            //[efectivo_sus],[efectivo_bs],[cheque_sus],[cheque_bs],[tarjeta_sus],[tarjeta_bs],[deposito_sus],[deposito_bs],[dpr_sus],[dpr_bs],[efe_sus],[efe_bs],[total_sus],[total_bs]
            //[servicio_codigo],[num_factura],[num_recibo],[num_comprobante],[nombre_dpr],[num_control]
            //Orden: [urbanizacion_codigo],[urbanizacion_nombre],[id_transaccion]
            if (Consolidado == false) { return ReporteIngresos_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteIngresos_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = ReporteIngresos_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteIngresos_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ReporteIngresos_original(Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_inicial,monto_pago,seguro,mantenimiento_sus,interes,amortizacion,saldo,interes_penal,servicio_monto,total_dpr,total_efe", false, false, "", "urbanizacion_codigo,urbanizacion_nombre,id_transaccion");
            }
        }
        private static DataTable ReporteIngresos_original(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteIngresos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        private static DataTable ReporteIngresos_original_Transacciones(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda,string Transacciones)
        {
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteIngresosTrans");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "transacciones", DbType.String, Transacciones);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteIngresosTotalesUrbanizacion(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[id_negocio],[negocio_nombre],[urbanizacion_nombre],
            //[interes_penal],[servicio_monto],[cuota_inicial],[monto_pago],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[total_dpr],[total_efe]
            //[efectivo_sus],[efectivo_bs],[cheque_sus],[cheque_bs],[tarjeta_sus],[tarjeta_bs],[deposito_sus],[deposito_bs],[dpr_sus],[dpr_bs],[efe_sus],[efe_bs],[total_sus],[total_bs]
            //Orden: [id_negocio],[negocio_nombre],[urbanizacion_nombre]
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteIngresosTotalesUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable ReporteIngresos2(int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //Tipos de datos: pagos,mora,servicio_no_ica,servicio_si_ica,servicio_no_cliente
            DataTable tabla_pagos = ReporteIngresos2_parcial("pagos", Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Consolidado);
            DataTable tabla_mora = ReporteIngresos2_parcial("mora", Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Consolidado);
            DataTable tabla_servicio_no_ica = ReporteIngresos2_parcial("servicio_no_ica", Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Consolidado);
            DataTable tabla_servicio_si_ica = ReporteIngresos2_parcial("servicio_si_ica", Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Consolidado);
            DataTable tabla_servicio_no_cliente = ReporteIngresos2_parcial("servicio_no_cliente", Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda, Consolidado);

            if (tabla_mora.Rows.Count > 0) { tabla_pagos.Merge(tabla_mora, true); }
            if (tabla_servicio_no_ica.Rows.Count > 0) { tabla_pagos.Merge(tabla_servicio_no_ica, true); }
            if (tabla_servicio_si_ica.Rows.Count > 0) { tabla_pagos.Merge(tabla_servicio_si_ica, true); }
            if (tabla_servicio_no_cliente.Rows.Count > 0) { tabla_pagos.Merge(tabla_servicio_no_cliente, true); }

            tabla_pagos.DefaultView.Sort = "urbanizacion_codigo,urbanizacion_nombre,id_transaccion";
            return tabla_pagos.DefaultView.ToTable();
        }
        private static DataTable ReporteIngresos2_parcial(string Tipo_datos, int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[id_negocio],[id_transaccion],[urbanizacion_codigo],[tipo_pago],[contrato_numero],[urbanizacion_nombre],[string_cuotas],[fecha_pago],[paterno_cliente],[materno_cliente],[manzano_codigo],[lote_codigo],[codigo_moneda],
            //[cuota_inicial],[monto_pago],[tipo_cambio],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal],[servicio_monto],[total_dpr],[total_efe]
            //[efectivo_sus],[efectivo_bs],[cheque_sus],[cheque_bs],[tarjeta_sus],[tarjeta_bs],[deposito_sus],[deposito_bs],[dpr_sus],[dpr_bs],[efe_sus],[efe_bs],[total_sus],[total_bs]
            //[servicio_codigo],[num_factura],[num_recibo],[num_comprobante],[nombre_dpr],[num_control]
            //Orden: [urbanizacion_codigo],[urbanizacion_nombre],[id_transaccion]
            if (Consolidado == false) { return ReporteIngresos2_original(Tipo_datos, Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteIngresos2_original(Tipo_datos, Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                    tabla_bs = ReporteIngresos2_original(Tipo_datos, Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteIngresos2_original(Tipo_datos, Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_segunda_moneda);
                    tabla_bs = ReporteIngresos2_original(Tipo_datos, Id_sucursal, Formapago, Id_usuario, Desde, Hasta, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_inicial,monto_pago,seguro,mantenimiento_sus,interes,amortizacion,saldo,interes_penal,servicio_monto,total_dpr,total_efe", false, false, "", "");
            }
        }
        private static DataTable ReporteIngresos2_original(string Tipo_datos, int Id_sucursal, int Formapago, int Id_usuario, DateTime Desde, DateTime Hasta, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteIngresos2");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "tipo_datos", DbType.String, Tipo_datos);
            
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static List<Int32> ListaTransacciones(string transacciones)
        {
            List<Int32> lista = new List<Int32>();
            if (transacciones != null && transacciones != "")
            {
                string[] fila = transacciones.TrimEnd(",".ToCharArray()).Split(",".ToCharArray());
                for (int j = 0; j < fila.Length; j++)
                {
                    lista.Add(int.Parse(fila[j]));
                }
            }
            return lista;
        }
        public static DataTable TablaTransaccionRecibo(string transacciones, int Id_recibo)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_transaccion", typeof(int));
            tabla.Columns.Add("id_recibo", typeof(int));
            foreach (Int32 t in ListaTransacciones(transacciones))
            {
                if (Id_recibo == 0)
                {
                    if (recibo.IdPorTransaccion(t) > 0)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["id_transaccion"] = t;
                        fila["id_recibo"] = Id_recibo;
                        tabla.Rows.Add(fila);
                    }
                }
                else
                {
                    DataRow fila = tabla.NewRow();
                    fila["id_transaccion"] = t;
                    fila["id_recibo"] = Id_recibo;
                    tabla.Rows.Add(fila);
                }
            }
            return tabla;
        }
        public static DataTable TablaTransaccionFactura(string transacciones, int Id_factura)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_transaccion", typeof(int));
            tabla.Columns.Add("id_factura", typeof(int));
            foreach (Int32 t in ListaTransacciones(transacciones))
            {
                if (Id_factura == 0)
                {
                    if (factura.IdPorTransaccion(t) > 0)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["id_transaccion"] = t;
                        fila["id_factura"] = Id_factura;
                        tabla.Rows.Add(fila);
                    }
                }
                else
                {
                    DataRow fila = tabla.NewRow();
                    fila["id_transaccion"] = t;
                    fila["id_factura"] = Id_factura;
                    tabla.Rows.Add(fila);
                }

            }
            return tabla;
        }
        public static DataTable TablaTransaccionComprobante(string transacciones, int Id_comprobantedpr)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_transaccion", typeof(int));
            tabla.Columns.Add("id_comprobantedpr", typeof(int));
            foreach (Int32 t in ListaTransacciones(transacciones))
            {
                if (Id_comprobantedpr == 0)
                {
                    if (comprobante_dpr.IdPorTransaccion(t) > 0)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["id_transaccion"] = t;
                        fila["id_comprobantedpr"] = Id_comprobantedpr;
                        tabla.Rows.Add(fila);
                    }
                }
                else
                {
                    DataRow fila = tabla.NewRow();
                    fila["id_transaccion"] = t;
                    fila["id_comprobantedpr"] = Id_comprobantedpr;
                    tabla.Rows.Add(fila);
                }

            }
            return tabla;
        }
        #endregion

    }
}