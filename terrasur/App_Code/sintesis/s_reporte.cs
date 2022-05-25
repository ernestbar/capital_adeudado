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
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de s_reporte
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_reporte
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas

            //Propiedades públicas
            #endregion

            #region Constructores
            //public s_reporte() { }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable reporte_resumen(int Id_eeff, int Id_sucursal_eeff, string Codigo_usuario, DateTime Fecha_inicio, DateTime Fecha_fin, string Num_contrato, int Id_pagopendiente, string Tipo_reporte)
            {
                //[fecha],[id],[tipo_codigo],[tipo_nombre],[codigo_eeff],[codigo_sucursal],[codigo_usuario]
                //[num_contrato],[solicitud],[num_respuesta],[respuesta]
                DbCommand cmd = db1.GetStoredProcCommand("s_reporte_resumen");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_eeff", DbType.Int32, Id_eeff);
                db1.AddInParameter(cmd, "id_sucursal_eeff", DbType.Int32, Id_sucursal_eeff);
                db1.AddInParameter(cmd, "codigo_usuario", DbType.String, Codigo_usuario);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1.AddInParameter(cmd, "id_pagopendiente", DbType.Int32, Id_pagopendiente);
                db1.AddInParameter(cmd, "tipo_reporte", DbType.String, Tipo_reporte);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable reporte_control(string tipo_reporte, int Id_eeff, int Id_sucursal_eeff, string Codigo_usuario, DateTime Fecha_inicio, DateTime Fecha_fin, string Num_contrato, int Id_pagopendiente)
            {
                //Para busqueda_cliente:
                //[id_busqueda],[fecha_busqueda],[codigo_eeff],[codigo_sucursal],[codigo_usuario],[num_contrato_busqueda],[ci_cliente]
                //[id_resultado],[fecha_resultado],[num_contrato],[permitir_cobro],[estado_contrato],[producto],[nombre_cliente],[tiempo_respuesta]

                // Para solicitud_tipo_pago:
                //[id_solicitud],[fecha_solicitud],[codigo_eeff],[codigo_sucursal],[codigo_usuario],[num_contrato],
                //[id_respuesta],[fecha_respuesta],[codigo],[nombre],[tiempo_respuesta]

                // Para solicitud_contrato:
                //[id_solicitud],[fecha_solicitud],[codigo_eeff],[codigo_sucursal],[codigo_usuario],[num_contrato]
                //[id_respuesta],[fecha_respuesta],[moneda],[tc_cobranza],[producto],[nombre_cliente],[ci_cliente]
                //[nit_negocio],[unidad_negocio],[promotor],[recibo_mensaje],[factura_cliente_nombre],[factura_cliente_nit],[tiempo_respuesta]

                // Para pago:
                //[id_solicitud],[fecha_solicitud],[codigo_eeff],[codigo_sucursal],[codigo_usuario],[num_contrato],[codigo_tipo_pago]
                //[id_respuesta],[fecha_respuesta]
                //[cp_id_condicionpago],[cp_fecha],[cp_estado],[cp_id_ultimo_pago],[cp_id_planpago],[cp_preferencial],[cp_bloqueado],[cp_saldo],[cp_interes_fecha]
                //[id_pagopendiente],[moneda],[tc_cobranza],[variable],[variable_monto_minimo],[variable_monto_maximo],[variable_saldo_anterior]
                //[num_pago],[concepto_pago],[fecha_pago],[fecha_interes],[fecha_proximo]
                //[monto_pago],[seguro],[mantenimiento],[interes],[capital],[saldo]
                //[factura],[factura_tc],[factura_bs_monto],[factura_bs_seguro],[factura_bs_mantenimiento],[factura_bs_interes],[factura_bs_capital]

                // Para conciliacion:
                //[id_conciliacion],[fecha_conciliacion],[codigo_eeff],[codigo_sucursal],[codigo_usuario],[id_pagopendiente],[num_contrato],[num_pago],[cobrado],[cobrado_id_pago]
                //[moneda],[id_confirmacion],[fecha_confirmacion],[correcto],[tiempo_respuesta]
                //[monto_pago],[recibo_num],[recibo_efectivo_sus],[recibo_efectivo_bs]
                //[factura_num],[factura_bs_monto],[factura_codigo_control],[factura_cliente_nombre],[factura_cliente_nit]

                //Para conciliación de pagos a capital diferentes al predeterminado:
                //[id_conciliacion],[fecha_conciliacion],[codigo_eeff],[codigo_sucursal],[codigo_usuario],[id_pagopendiente],[monto_pago],[moneda]
                //[variable_saldo_anterior],[saldo],[variable_monto_minimo],[variable_monto_maximo]
                //[recibo_num],[recibo_efectivo_sus],[recibo_efectivo_bs]
                //[factura],[factura_num],[factura_tc],[factura_bs_monto]
                //[cobrado],[num_contrato],[num_pago],[cobrado_id_pago]

                //Opciones de tipo_reporte: busqueda_cliente, solicitud_tipo_pago, solicitud_contrato, solicitud_pago, 
                //conciliacion, conciliacion_PagoCapital, verificacion_anulacion, anulacion
                DbCommand cmd = db1.GetStoredProcCommand("s_reporte_" + tipo_reporte);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_eeff", DbType.Int32, Id_eeff);
                db1.AddInParameter(cmd, "id_sucursal_eeff", DbType.Int32, Id_sucursal_eeff);
                db1.AddInParameter(cmd, "codigo_usuario", DbType.String, Codigo_usuario);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1.AddInParameter(cmd, "id_pagopendiente", DbType.Int32, Id_pagopendiente);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

                string columna_id = "";
                string columnas_para_ocultar1 = "";
                string columnas_para_ocultar2 = "";
                switch (tipo_reporte)
                {
                    case "busqueda_cliente":
                        columna_id = "id_busqueda";
                        columnas_para_ocultar1 = "id_busqueda,fecha_busqueda,codigo_eeff,codigo_sucursal,codigo_usuario,num_contrato_busqueda,ci_cliente";
                        break;
                    case "solicitud_tipo_pago":
                        columna_id = "id_solicitud";
                        columnas_para_ocultar1 = "id_solicitud,fecha_solicitud,codigo_eeff,codigo_sucursal,codigo_usuario,num_contrato";
                        break;
                    case "solicitud_pago":
                        columna_id = "id_solicitud";
                        columnas_para_ocultar1 = "id_solicitud,fecha_solicitud,codigo_eeff,codigo_sucursal,codigo_usuario,num_contrato,codigo_tipo_pago";
                        break;
                    case "conciliacion_PagoCapital":
                        columna_id = "id_conciliacion";
                        columnas_para_ocultar1 = "id_conciliacion,fecha_conciliacion,codigo_eeff,codigo_sucursal,codigo_usuario,id_pagopendiente";
                        columnas_para_ocultar2 = "recibo_num,recibo_efectivo_sus,recibo_efectivo_bs,factura,factura_num,factura_tc,factura_bs_monto,cobrado,num_contrato,num_pago,cobrado_id_pago";
                        break;
                }
                if (columnas_para_ocultar1 != "") { ajustes_tabla(ref tabla, columna_id, columnas_para_ocultar1, columnas_para_ocultar2); }

                return tabla;
            }

            private static void ajustes_tabla(ref DataTable tabla, string columna_id, string columnas_para_ocultar1, string columnas_para_ocultar2)
            {
                int valor_id = 0;
                string[] lista_columnas1 = columnas_para_ocultar1.Split(',');
                string[] lista_columnas2 = columnas_para_ocultar2.Split(',');
                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    if (((int)tabla.Rows[j][columna_id]) == valor_id)
                    {
                        if (columnas_para_ocultar1 != "")
                        {
                            foreach (string columna in lista_columnas1) { tabla.Rows[j][columna] = DBNull.Value; }
                        }
                    }
                    else
                    {
                        valor_id = ((int)tabla.Rows[j][columna_id]);
                        if (columnas_para_ocultar2 != "")
                        {
                            foreach (string columna in lista_columnas2) { tabla.Rows[j][columna] = DBNull.Value; }
                        }
                    }
                }
            }

            public static DataTable reporte_ingresos(int Id_eeff, int Id_sucursal_eeff, string Codigo_usuario, DateTime Fecha_inicio, DateTime Fecha_fin)
            {
                //[id_pago],[fecha],[num_contrato],[tipo_pago],[cliente]
                //[monto_pago_sus],[monto_pago_bs],[interes],[seguro],[mantenimiento_sus],[capital]
                //[cobranza_tc],[cobranza_sus],[cobranza_bs]
                //[num_recibo],[num_factura],[tc_factura],[monto_factura]
                DbCommand cmd = db1.GetStoredProcCommand("s_reporte_Ingresos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_eeff", DbType.Int32, Id_eeff);
                db1.AddInParameter(cmd, "id_sucursal_eeff", DbType.Int32, Id_sucursal_eeff);
                db1.AddInParameter(cmd, "codigo_usuario", DbType.String, Codigo_usuario);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }


            #endregion

            #region Métodos que requieren constructor
            #endregion

        }
    }
}