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
/// Descripción breve de reembolso
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class reembolso
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_reembolso = 0;
            private int _id_motivo = 0;
            private int _id_contrato = 0;
            private int _id_moneda = 0;
            private int _id_usuario = 0;
            private bool _traspaso = true;
            private DateTime _fecha = DateTime.Now;
            private decimal _monto = 0;
            private string _observacion = "";
            private DateTime _fecha_registro = DateTime.Now;

            private decimal _pagado = 0;
            private decimal _saldo = 0;
            private string _codigo_moneda = "";
            private string _num_contrato = "";
            private string _nombre_usuario = "";
            private string _producto = "";
            private string _motivo_nombre = "";
            private string _cliente = "";
            private int _num_items = 0;
            private int _num_contratos = 0;
            private int _num_pagos = 0;

            private decimal _dc_precio_final = 0;
            private decimal _dc_capital_pagado = 0;
            private decimal _dc_interes_pagado = 0;
            private decimal _dc_total_pagado = 0;
            private decimal _dc_saldo = 0;
            private int _dc_cuotas_pagadas = 0;
            private decimal _dc_interes_corriente = 0;
            private DateTime _dc_fecha_venta = DateTime.Now;
            private DateTime _dc_fecha_ultimo_pago = DateTime.Now;
            private DateTime _dc_fecha_interes = DateTime.Now;
            private DateTime _dc_fecha_reversion = DateTime.Now;

            //Propiedades públicas
            public int id_reembolso { get { return _id_reembolso; } set { _id_reembolso = value; } }
            public int id_motivo { get { return _id_motivo; } set { _id_motivo = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public bool traspaso { get { return _traspaso; } set { _traspaso = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            public string observacion { get { return _observacion; } set { _observacion = value; } }
            public DateTime fecha_registro { get { return _fecha_registro; } set { _fecha_registro = value; } }
            
            public decimal pagado { get { return _pagado; } }
            public decimal saldo { get { return _saldo; } }
            public string codigo_moneda { get { return _codigo_moneda; } }
            public string num_contrato { get { return _num_contrato; } }
            public string nombre_usuario { get { return _nombre_usuario; } }
            public string producto { get { return _producto; } }
            public string motivo_nombre { get { return _motivo_nombre; } }
            public string cliente { get { return _cliente; } }
            public int num_items { get { return _num_items; } }
            public int num_contratos { get { return _num_contratos; } }
            public int num_pagos { get { return _num_pagos; } }

            public decimal dc_precio_final { get { return _dc_precio_final; } }
            public decimal dc_capital_pagado { get { return _dc_capital_pagado; } }
            public decimal dc_interes_pagado { get { return _dc_interes_pagado; } }
            public decimal dc_total_pagado { get { return _dc_total_pagado; } }
            public decimal dc_saldo { get { return _dc_saldo; } }
            public int dc_cuotas_pagadas { get { return _dc_cuotas_pagadas; } }
            public decimal dc_interes_corriente { get { return _dc_interes_corriente; } }
            public DateTime dc_fecha_venta { get { return _dc_fecha_venta; } }
            public DateTime dc_fecha_ultimo_pago { get { return _dc_fecha_ultimo_pago; } }
            public DateTime dc_fecha_interes { get { return _dc_fecha_interes; } }
            public DateTime dc_fecha_reversion { get { return _dc_fecha_reversion; } }
            #endregion

            #region Constructores
            public reembolso(int Id_reembolso)
            {
                _id_reembolso = Id_reembolso;
                RecuperarDatos();
            }

            public reembolso(int Id_motivo, int Id_contrato, int Id_moneda, int Id_usuario, bool Traspaso, DateTime Fecha, decimal Monto, string Observacion)
            {
                _id_motivo = Id_motivo;
                _id_contrato = Id_contrato;
                _id_moneda = Id_moneda;
                _id_usuario = Id_usuario;
                _traspaso = Traspaso;
                _fecha = Fecha;
                _monto = Monto;
                _observacion = Observacion;
            }

            public reembolso(int Id_reembolso, int Id_motivo, int Id_contrato, int Id_moneda, int Id_usuario, bool Traspaso, DateTime Fecha, decimal Monto, string Observacion)
            {
                _id_reembolso = Id_reembolso;
                _id_motivo = Id_motivo;
                _id_contrato = Id_contrato;
                _id_moneda = Id_moneda;
                _id_usuario = Id_usuario;
                _traspaso = Traspaso;
                _fecha = Fecha;
                _monto = Monto;
                _observacion = Observacion;
            }
            //public reembolso(int Id_reembolso, int Id_motivo, int Id_usuario, string Observacion)
            //{
            //    _id_reembolso = Id_reembolso;
            //    _id_motivo = Id_motivo;
            //    _id_usuario = Id_usuario;
            //    _observacion = Observacion;
            //}
            
            #endregion

            #region Métodos que NO requieren constructor
            public static int VerificarContrato(bool Insertar, int Id_reembolso, int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_VerificarContrato");
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);

                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return -1; }
            }

            public static bool VerificarReembolsoContrato(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_VerificarReembolsoContrato");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    if (((int)db1.ExecuteScalar(cmd)) == 0) { return false; }
                    else { return true; }
                }
                catch { return true; }
            }


            public static void VerificarFechasContrato(int Id_contrato, 
                ref int Estado, ref DateTime Fecha_ultimo_pago, ref DateTime Fecha_reversion)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_VerificarFechasContrato");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);

                    db1.AddOutParameter(cmd, "estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha_ultimo_pago", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fecha_reversion", DbType.DateTime, 32);

                    db1.ExecuteNonQuery(cmd);

                    Estado = (int)db1.GetParameterValue(cmd, "estado");
                    Fecha_ultimo_pago = (DateTime)db1.GetParameterValue(cmd, "fecha_ultimo_pago");
                    Fecha_reversion = (DateTime)db1.GetParameterValue(cmd, "fecha_reversion");
                }
                catch { }
            }

            // Req.Conciliaciones
            public static DataTable Lista(int Tipo_reembolso, string Num_contrato, int Origen_contrato,
                DateTime Fecha_inicio, DateTime Fecha_fin, int Id_usuario, string Cliente, int Id_motivo, int Asignacion, int Saldo, int Id_localizacion, int Id_urbanizacion, int Id_estadoconciliacion)
            {
                //[id_reembolso],[tipo],[num_contrato],[fecha],[moneda],[monto],[pagado],[pendiente_asignacion],[saldo],[pagos],[cliente],[motivo],[usuario], 
                //[traspaso],[producto],[destino],[num_destino]
                DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "tipo_reembolso", DbType.Int32, Tipo_reembolso);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1.AddInParameter(cmd, "origen_contrato", DbType.Int32, Origen_contrato);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "cliente", DbType.String, Cliente);
                db1.AddInParameter(cmd, "id_motivo", DbType.Int32, Id_motivo);
                db1.AddInParameter(cmd, "asignacion", DbType.Int32, Asignacion);
                db1.AddInParameter(cmd, "saldo", DbType.Int32, Saldo);
                db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "id_estadoconciliacion", DbType.Int32, Id_estadoconciliacion);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
                CompletarContratosDestino(ref tabla);
                return tabla;
            }
            private static void CompletarContratosDestino(ref DataTable tabla)
            {
                StringBuilder str_reembolso = new StringBuilder();
                foreach (DataRow fila in tabla.Rows) { if (((int)fila["num_destino"]) > 1) { str_reembolso.Append(fila["id_reembolso"].ToString() + ","); } }

                if (!string.IsNullOrEmpty(str_reembolso.ToString()))
                {
                    DataTable tabla_destino = ListaContratosDestino("," + str_reembolso.ToString());
                    foreach (DataRow fila in tabla.Rows)
                    {
                        if (((int)fila["num_destino"]) > 1)
                        {
                            int _Id_reembolso = (int)fila["id_reembolso"];
                            StringBuilder str_destino = new StringBuilder();
                            foreach (DataRow fila_destino in tabla_destino.Rows) { if (((int)fila_destino["id_reembolso"]) == _Id_reembolso) { str_destino.Append(fila_destino["num_contrato"].ToString() + ", "); } }
                            fila["destino"] = str_destino.ToString().Trim().TrimEnd(',');
                        }
                    }
                }
            }
            private static DataTable ListaContratosDestino(string Id_reembolso)
            {
                //[id_reembolso],[num_contrato]
                DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_ListaContratosDestino");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.String, Id_reembolso);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            // Req.Conciliaciones
            public static DataTable Reporte(DateTime Fecha, 
                int Tipo_reembolso, string Num_contrato, int Origen_contrato,
                DateTime Fecha_inicio, DateTime Fecha_fin, int Id_usuario, 
                string Cliente, int Id_motivo, int Asignacion, int Saldo, 
                int Id_localizacion, int Id_urbanizacion,
                int Id_moneda, bool Consolidado, int Id_estadoconciliacion)
            {
                //[id_reembolso],[tipo],[num_contrato],[fecha],[moneda],[monto],[pagado],[pendiente_asignacion],[saldo],[pagos],[cliente],[motivo],[usuario], 
                //[traspaso],[producto],[destino],[num_destino]
                DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_Reporte");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                db1.AddInParameter(cmd, "tipo_reembolso", DbType.Int32, Tipo_reembolso);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1.AddInParameter(cmd, "origen_contrato", DbType.Int32, Origen_contrato);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "cliente", DbType.String, Cliente);
                db1.AddInParameter(cmd, "id_motivo", DbType.Int32, Id_motivo);
                db1.AddInParameter(cmd, "asignacion", DbType.Int32, Asignacion);
                db1.AddInParameter(cmd, "saldo", DbType.Int32, Saldo);
                db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
                db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
                db1.AddInParameter(cmd, "id_estadoconciliacion", DbType.Int32, Id_estadoconciliacion);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
                CompletarContratosDestino(ref tabla);
                return tabla;
            }

            public static void ListaNoRevertidos(ref string Texto, ref string ToolTip)
            {
                //[id_reembolso],[usuario],[num_contrato],[traspaso],[fecha_reembolso],[usuario2],[num_contrato2]
                DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_ListaNoRevertidos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

                StringBuilder str_texto = new StringBuilder();
                StringBuilder str_tooltip = new StringBuilder();

                string aux_usuario = "";
                foreach (DataRow fila in tabla.Rows)
                {
                    if (aux_usuario != fila["usuario"].ToString())
                    {
                        if (aux_usuario != "")
                        {
                            str_texto.Append(" ; ");
                            str_tooltip.AppendLine();
                        }
                        else
                        {
                            str_texto.Append("Contratos no revertidos: ");
                            str_tooltip.AppendLine("Contratos reembolsados no revertidos");
                        }
                        str_texto.Append(fila["usuario"].ToString() + ": ");
                        str_tooltip.AppendLine(fila["usuario2"].ToString());

                        aux_usuario = fila["usuario"].ToString();
                    }
                    str_texto.Append(fila["num_contrato"].ToString() + ", ");

                    string str_tipo = "Traspaso"; if (!((bool)fila["traspaso"])) { str_tipo = "Devolución"; }
                    str_tooltip.AppendLine(string.Format("{0} - {1} ({2})", fila["num_contrato2"].ToString(), str_tipo, ((DateTime)fila["fecha_reembolso"]).ToString("d")));
                }
                Texto = str_texto.ToString().Trim().TrimEnd(',').Replace(",  ; "," ; ");
                ToolTip = str_tooltip.ToString();
            }

            public static int Idreembolso_PorContrato(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_Idreembolso_PorContrato");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static DataTable ListaDatosContrato(int Id_contrato, DateTime Fecha)
            {
                //num_contrato,estado,estado_string,producto,fecha_venta,fecha_ultimo_pago,fecha_interes,fecha_reversion
                //precio_final,capital_pagado,interes_pagado,total_pagado,saldo,cuotas_pagadas,interes_corriente
                DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_ListaDatosContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaDatosReembolso(int Id_reembolso)
            {
                //num_contrato,estado,estado_string,producto,fecha_venta,fecha_ultimo_pago,fecha_interes,fecha_reversion
                //precio_final,capital_pagado,interes_pagado,total_pagado,saldo,cuotas_pagadas,interes_corriente
                DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_ListaDatosReembolso");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static string CodigoMoneda(int Id_reembolso)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_CodigoMoneda");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    return db1.ExecuteScalar(cmd).ToString();
                }
                catch { return ""; }
            }

            public static decimal MontoTotal(int Id_reembolso)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_MontoTotal");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    return (decimal)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static decimal MontoPagado(int Id_reembolso)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_MontoPagado");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    return (decimal)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);

                    db1.AddOutParameter(cmd, "id_motivo", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_moneda", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "traspaso", DbType.Boolean, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "monto", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "observacion", DbType.String, 400);
                    db1.AddOutParameter(cmd, "fecha_registro", DbType.DateTime, 32);

                    db1.AddOutParameter(cmd, "pagado", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "saldo", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 10);
                    db1.AddOutParameter(cmd, "num_contrato", DbType.String, 10);
                    db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                    db1.AddOutParameter(cmd, "producto", DbType.String, 100);
                    db1.AddOutParameter(cmd, "motivo_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "cliente", DbType.String, 100);
                    db1.AddOutParameter(cmd, "num_items", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "num_contratos", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "num_pagos", DbType.Int32, 32);

                    db1.AddOutParameter(cmd, "dc_precio_final", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "dc_capital_pagado", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "dc_interes_pagado", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "dc_total_pagado", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "dc_saldo", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "dc_cuotas_pagadas", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "dc_interes_corriente", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "dc_fecha_venta", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "dc_fecha_ultimo_pago", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "dc_fecha_interes", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "dc_fecha_reversion", DbType.DateTime, 32);

                    db1.ExecuteNonQuery(cmd);

                    _id_motivo = (int)db1.GetParameterValue(cmd, "id_motivo");
                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _id_moneda = (int)db1.GetParameterValue(cmd, "id_moneda");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _traspaso = (bool)db1.GetParameterValue(cmd, "traspaso");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _monto = (decimal)(double)db1.GetParameterValue(cmd, "monto");
                    _observacion = (string)db1.GetParameterValue(cmd, "observacion");
                    _fecha_registro = (DateTime)db1.GetParameterValue(cmd, "fecha_registro");

                    _pagado = (decimal)(double)db1.GetParameterValue(cmd, "pagado");
                    _saldo = (decimal)(double)db1.GetParameterValue(cmd, "saldo");
                    _codigo_moneda = (string)db1.GetParameterValue(cmd, "codigo_moneda");
                    _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                    _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                    _producto = (string)db1.GetParameterValue(cmd, "producto");
                    _motivo_nombre = (string)db1.GetParameterValue(cmd, "motivo_nombre");
                    _cliente = (string)db1.GetParameterValue(cmd, "cliente");
                    _num_items = (int)db1.GetParameterValue(cmd, "num_items");
                    _num_contratos = (int)db1.GetParameterValue(cmd, "num_contratos");
                    _num_pagos = (int)db1.GetParameterValue(cmd, "num_pagos");

                    _dc_precio_final = (decimal)(double)db1.GetParameterValue(cmd, "dc_precio_final");
                    _dc_capital_pagado = (decimal)(double)db1.GetParameterValue(cmd, "dc_capital_pagado");
                    _dc_interes_pagado = (decimal)(double)db1.GetParameterValue(cmd, "dc_interes_pagado");
                    _dc_total_pagado = (decimal)(double)db1.GetParameterValue(cmd, "dc_total_pagado");
                    _dc_saldo = (decimal)(double)db1.GetParameterValue(cmd, "dc_saldo");
                    _dc_cuotas_pagadas = (int)db1.GetParameterValue(cmd, "dc_cuotas_pagadas");
                    _dc_interes_corriente = (decimal)(double)db1.GetParameterValue(cmd, "dc_interes_corriente");
                    _dc_fecha_venta = (DateTime)db1.GetParameterValue(cmd, "dc_fecha_venta");
                    _dc_fecha_ultimo_pago = (DateTime)db1.GetParameterValue(cmd, "dc_fecha_ultimo_pago");
                    _dc_fecha_interes = (DateTime)db1.GetParameterValue(cmd, "dc_fecha_interes");
                    _dc_fecha_reversion = (DateTime)db1.GetParameterValue(cmd, "dc_fecha_reversion");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_Insertar");
                    db1.AddInParameter(cmd, "id_motivo", DbType.Int32, _id_motivo);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_moneda", DbType.Int32, _id_moneda);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "traspaso", DbType.Boolean, _traspaso);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                    db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_reembolso = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Actualizar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_Actualizar");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);
                    db1.AddInParameter(cmd, "id_motivo", DbType.Int32, _id_motivo);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_moneda", DbType.Int32, _id_moneda);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "traspaso", DbType.Boolean, _traspaso);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                    db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);

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
                    DbCommand cmd = db1.GetStoredProcCommand("re_reembolso_Eliminar");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);

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
    }
}