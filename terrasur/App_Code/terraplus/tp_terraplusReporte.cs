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
/// Descripción breve de tp_terraplusReporte
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_terraplusReporte
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Métodos que NO requieren constructor
            public static DataTable ReporteEstadoCuenta(int Id_contrato)
            {
                //[num_pago],[num_mes],[id_serviciovendido],[id_pago],[fecha],[num_mes_restriccion],[estado],[mes_pagado]
                //[monto],[codigo_moneda],[num_factura],[forma_pago],[sucursal]
                DbCommand cmd = db1.GetStoredProcCommand("tp_reporte_EstadoCuenta");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

                int id_serviciovendido = 0;
                int num_pago = 1;
                int num_mes = 1;
                foreach (DataRow fila in tabla.Rows)
                {
                    if ((int)fila["id_serviciovendido"] != id_serviciovendido)
                    {
                        id_serviciovendido = (int)fila["id_serviciovendido"];
                        fila["num_pago"] = num_pago;
                        num_pago += 1;
                    }
                    else
                    {
                        fila["num_pago"] = DBNull.Value;
                        //fila["fecha"] = DBNull.Value; fila["num_factura"] = DBNull.Value; fila["forma_pago"] = DBNull.Value; fila["sucursal"] = DBNull.Value;
                    }
                    fila["num_mes"] = num_mes;
                    num_mes += 1;
                }
                return tabla;
            }

            public static DataTable Cartera(DateTime Fecha, string Id_estado, DateTime Registro_inicio, DateTime Registro_fin, DateTime Ult_pago_inicio, DateTime Ult_pago_fin, DateTime Ult_mes_inicio, DateTime Ult_mes_fin, string Nombre_ci_cliente, string Tp_num_contrato, int Id_moneda, bool Consolidado)
            {
                if (Consolidado == false) { return Cartera_original(Fecha, Id_estado, Registro_inicio, Registro_fin, Ult_pago_inicio, Ult_pago_fin, Ult_mes_inicio, Ult_mes_fin, Nombre_ci_cliente, Tp_num_contrato, Id_moneda);
                }
                else
                {
                    string codigo_moneda = new moneda(Id_moneda).codigo;
                    DataTable tabla_sus; DataTable tabla_bs;
                    if (codigo_moneda == "$us")
                    {
                        int Id_segunda_moneda = new moneda("Bs").id_moneda;
                        tabla_sus = Cartera_original(Fecha, Id_estado, Registro_inicio, Registro_fin, Ult_pago_inicio, Ult_pago_fin, Ult_mes_inicio, Ult_mes_fin, Nombre_ci_cliente, Tp_num_contrato, Id_moneda);
                        tabla_bs = Cartera_original(Fecha, Id_estado, Registro_inicio, Registro_fin, Ult_pago_inicio, Ult_pago_fin, Ult_mes_inicio, Ult_mes_fin, Nombre_ci_cliente, Tp_num_contrato, Id_segunda_moneda);
                    }
                    else
                    {
                        int Id_segunda_moneda = new moneda("$us").id_moneda;
                        tabla_sus = Cartera_original(Fecha, Id_estado, Registro_inicio, Registro_fin, Ult_pago_inicio, Ult_pago_fin, Ult_mes_inicio, Ult_mes_fin, Nombre_ci_cliente, Tp_num_contrato, Id_segunda_moneda);
                        tabla_bs = Cartera_original(Fecha, Id_estado, Registro_inicio, Registro_fin, Ult_pago_inicio, Ult_pago_fin, Ult_mes_inicio, Ult_mes_fin, Nombre_ci_cliente, Tp_num_contrato, Id_moneda);
                    }
                    return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "monto_mensual,pagado_monto", false, false, "", "orden_estado,fecha");
                }

            }
            private static DataTable Cartera_original(DateTime Fecha, string Id_estado, DateTime Registro_inicio, DateTime Registro_fin, DateTime Ult_pago_inicio, DateTime Ult_pago_fin, DateTime Ult_mes_inicio, DateTime Ult_mes_fin, string Nombre_ci_cliente, string Tp_num_contrato, int Id_moneda)
            {
                //[num_contrato],[estado0],[estado],[fecha],[cliente],[fecha_nacimiento],[edad],
                //[monto_mensual],[ult_fecha],[ult_mes],[meses_incumplimineto]
                //[pagado_num_meses],[pagado_monto],[codigo_moneda],[tipo_cambio]
                DbCommand cmd = db1.GetStoredProcCommand("tp_reporte_Cartera");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                db1.AddInParameter(cmd, "id_estado", DbType.String, Id_estado);

                db1.AddInParameter(cmd, "registro_inicio", DbType.DateTime, Registro_inicio);
                db1.AddInParameter(cmd, "registro_fin", DbType.DateTime, Registro_fin);

                db1.AddInParameter(cmd, "ult_pago_inicio", DbType.DateTime, Ult_pago_inicio);
                db1.AddInParameter(cmd, "ult_pago_fin", DbType.DateTime, Ult_pago_fin);

                db1.AddInParameter(cmd, "ult_mes_inicio", DbType.DateTime, Ult_mes_inicio);
                db1.AddInParameter(cmd, "ult_mes_fin", DbType.DateTime, Ult_mes_fin);

                db1.AddInParameter(cmd, "nombre_ci_cliente", DbType.String, Nombre_ci_cliente);
                db1.AddInParameter(cmd, "tp_num_contrato", DbType.String, Tp_num_contrato);

                db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

        }
    }
}