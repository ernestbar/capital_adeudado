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

using System.Text;
/// <summary>
/// Descripción breve de pago
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class pago
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_pago = 0;
            private int _id_reembolso = 0;
            private int _orden = 0;
            private DateTime _fecha = DateTime.Now;
            private decimal _monto = 0;
            private bool _pagado = false;
            private DateTime _pagado_fecha = DateTime.Parse("01/01/1900");
            private int _pagado_id_usuario = 0;

            //Propiedades públicas
            public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
            public int id_reembolso { get { return _id_reembolso; } set { _id_reembolso = value; } }
            public int orden { get { return _orden; } set { _orden = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            public bool pagado { get { return _pagado; } set { _pagado = value; } }
            public DateTime pagado_fecha { get { return _pagado_fecha; } set { _pagado_fecha = value; } }
            public int pagado_id_usuario { get { return _pagado_id_usuario; } set { _pagado_id_usuario = value; } }
            #endregion

            #region Constructores
            public pago(int Id_pago)
            {
                _id_pago = Id_pago;
            }

            public pago(int Id_reembolso, DateTime Fecha, decimal Monto)
            {
                _id_reembolso = Id_reembolso;
                _fecha = Fecha;
                _monto = Monto;
            }

            public pago(int Id_pago, int Id_reembolso, DateTime Fecha, decimal Monto)
            {
                _id_pago = Id_pago;
                _id_reembolso = Id_reembolso;
                _fecha = Fecha;
                _monto = Monto;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_reembolso)
            {
                //[id_pago],[orden],[orden_string],[fecha],[monto],[estado],[pagado],[estado_detalle],[estado_detalle2],[permitir_pago],[permitir_retirar]
                DbCommand cmd = db1.GetStoredProcCommand("re_pago_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

                if (tabla.Rows.Count > 0)
                {
                    decimal Monto_total = 0;
                    foreach (DataRow fila in tabla.Rows) { Monto_total += (decimal)fila["monto"]; }
                    DataRow fila_total = tabla.NewRow();
                    fila_total["orden_string"] = "Total";
                    fila_total["monto"] = Monto_total;
                    fila_total["permitir_pago"] = false;
                    fila_total["permitir_retirar"] = false;
                    tabla.Rows.Add(fila_total);
                }

                return tabla;
            }
            public static DataTable Lista_para_reporte(int Id_reembolso)
            {
                //[id_pago],[orden],[orden_string],[fecha],[monto],[estado],[pagado],[estado_detalle],[estado_detalle2],[permitir_pago],[permitir_retirar]
                DbCommand cmd = db1.GetStoredProcCommand("re_pago_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static decimal MontoPagos(int Id_reembolso)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_pago_MontoPagos");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    return (decimal)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static DateTime FechaMaxima(int Id_reembolso)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_pago_FechaMaxima");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    return ((DateTime)db1.ExecuteScalar(cmd)).Date;
                }
                catch { return DateTime.Now.Date; }
            }


            #endregion

            #region Métodos que requieren constructor
            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_pago_Insertar");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_pago = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Actualizar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_pago_Actualizar");
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Eliminar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_pago_Eliminar");
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool MarcarPagado(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_pago_MarcarPagado");
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion
        }
        
        public class tmpPago
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _orden = 0;
            private DateTime _fecha = DateTime.Now;
            private decimal _monto = 0;

            //Propiedades públicas
            public int orden { get { return _orden; } set { _orden = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            #endregion

            #region Constructores
            public tmpPago(int Orden, DateTime Fecha, decimal Monto)
            {
                _orden = Orden;
                _fecha = Fecha;
                _monto = Monto;
            }
            #endregion


            #region Métodos que NO requieren constructor
            public static string Lista_a_Cadena(List<tmpPago> lista)
            {
                StringBuilder str = new StringBuilder();
                foreach (tmpPago p in lista)
                {
                    str.Append(p.orden.ToString() + "·"
                    + p.fecha.ToString() + "·"
                    + p.monto.ToString() + "|");
                }
                return str.ToString().TrimEnd('|');
            }

            public static List<tmpPago> Cadena_a_Lista(string strPago)
            {
                List<tmpPago> lista = new List<tmpPago>();
                if (!string.IsNullOrEmpty(strPago))
                {
                    string[] datos_row = strPago.Split('|');
                    for (int j = 0; j < datos_row.Length; j++)
                    {
                        string[] datos_col = datos_row[j].Split('·');
                        lista.Add(new tmpPago(
                            int.Parse(datos_col[0]),
                            DateTime.Parse(datos_col[1]),
                            decimal.Parse(datos_col[2])));
                    }
                }
                return lista;
            }

            public static DataTable Cadena_a_tabla(string strPago)
            {
                //[orden],[orden_string],[fecha],[monto],[estado]
                List<tmpPago> lista = Cadena_a_Lista(strPago);
                DataTable tabla = new DataTable();
                tabla.Columns.Add("orden", typeof(int));
                tabla.Columns.Add("orden_string", typeof(string));
                tabla.Columns.Add("fecha", typeof(DateTime));
                tabla.Columns.Add("monto", typeof(decimal));
                tabla.Columns.Add("estado", typeof(string));

                if (lista.Count > 0)
                {
                    decimal Monto_total = 0;
                    foreach (tmpPago p in lista)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["orden"] = p.orden;
                        fila["orden_string"] = "Pago " + p.orden.ToString();
                        fila["fecha"] = p.fecha;
                        fila["monto"] = p.monto;
                        fila["estado"] = "Pendiente";
                        tabla.Rows.Add(fila);

                        Monto_total += p.monto;
                    }

                    DataRow fila_total = tabla.NewRow();
                    fila_total["orden_string"] = "Total";
                    fila_total["monto"] = Monto_total;
                    tabla.Rows.Add(fila_total);
                }
                return tabla;
            }


            public static string GenerarBasico(decimal Monto_total, int Num_pagos, DateTime Fecha, decimal Pago_inicial)
            {
                List<tmpPago> lista = Cadena_a_Lista("");
                if (Num_pagos == 1) { lista.Add(new tmpPago(1, Fecha, Monto_total)); }
                else
                {
                    int N_pago = 1;
                    decimal Saldo = Monto_total;
                    decimal Monto_mensual;
                    if (Pago_inicial > 0)
                    {
                        lista.Add(new tmpPago(N_pago, Fecha, Pago_inicial));
                        Saldo -= Pago_inicial;
                        Fecha = Fecha.AddMonths(1);
                        N_pago += 1;
                        Monto_mensual = Math.Ceiling(Saldo / (Num_pagos - 1));
                    }
                    else { Monto_mensual = Math.Ceiling(Saldo / Num_pagos); }


                    while (Saldo > 0)
                    {
                        if (Saldo >= Monto_mensual)
                        {
                            lista.Add(new tmpPago(N_pago, Fecha, Monto_mensual));
                            Saldo -= Monto_mensual;
                        }
                        else
                        {
                            lista.Add(new tmpPago(N_pago, Fecha, Saldo));
                            Saldo = 0;
                        }
                        Fecha = Fecha.AddMonths(1);
                        N_pago += 1;
                    }
                }
                return Lista_a_Cadena(lista);
            }


            public static string Agregar(string strPago, DateTime Fecha, decimal Monto)
            {
                List<tmpPago> lista = Cadena_a_Lista(strPago);
                int Orden = lista.Count + 1;
                lista.Add(new tmpPago(Orden, Fecha, Monto));
                return Lista_a_Cadena(lista);
            }

            public static string Retirar(string strPago, int Orden)
            {
                List<tmpPago> lista = Cadena_a_Lista(strPago);
                if (lista.FindIndex(delegate(tmpPago p) { return p.orden == Orden; }) >= 0)
                {
                    lista.Remove(lista.Find(delegate(tmpPago p) { return p.orden == Orden; }));
                }
                return Lista_a_Cadena(lista);
            }


            
            public static decimal MontoTotal(string strPago)
            {
                decimal Monto_total = 0;
                List<tmpPago> lista = Cadena_a_Lista(strPago);
                foreach (tmpPago p in lista) { Monto_total += p.monto; }
                return Monto_total;
            }

            public static DateTime FechaMaxima(string strPago)
            {
                List<tmpPago> lista = Cadena_a_Lista(strPago);
                DateTime Fecha = DateTime.Parse("01/01/1900");
                foreach (tmpPago p in lista) { if (p.fecha > Fecha) { Fecha = p.fecha; } }
                return Fecha;
            }

            #endregion
        }
    }
}