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
/// Summary description for comprobante_dpr
/// </summary>
namespace terrasur
{
    public class comprobante_dpr
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_comprobantedpr = 0;
        private int _id_transaccion = 0;
        private int _num_comprobante = 0;
        private DateTime _fecha = DateTime.Now;
        private string _nombre_cliente = "";
        private string _concepto = "";
        private decimal _monto_sus = 0;
        private decimal _tipo_cambio = 0;
        private bool _anulado = false;
        private DateTime _anulado_fecha = DateTime.Now;
        private int _anulado_id_usuario = 0;
        private string _encabezado_empresa = "";
        private string _encabezado_actividad = "";
        private string _encabezado_direccion = "";
        private string _encabezado_telefono = "";
        private string _encabezado_lugar = "";
        private string _codigo_moneda = "";

        //Propiedades públicas
        public int id_comprobantedpr { get { return _id_comprobantedpr; } set { _id_comprobantedpr = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public int num_comprobante { get { return _num_comprobante; } set { _num_comprobante = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string nombre_cliente { get { return _nombre_cliente; } set { _nombre_cliente = value; } }
        public string concepto { get { return _concepto; } set { _concepto = value; } }
        public decimal monto_sus { get { return _monto_sus; } set { _monto_sus = value; } }
        public decimal tipo_cambio { get { return _tipo_cambio; } set { _tipo_cambio = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }
        public DateTime anulado_fecha { get { return _anulado_fecha; } set { _anulado_fecha = value; } }
        public int anulado_id_usuario { get { return _anulado_id_usuario; } set { _anulado_id_usuario = value; } }
        public string encabezado_empresa { get { return _encabezado_empresa; } set { _encabezado_empresa = value; } }
        public string encabezado_actividad { get { return _encabezado_actividad; } set { _encabezado_actividad = value; } }
        public string encabezado_direccion { get { return _encabezado_direccion; } set { _encabezado_direccion = value; } }
        public string encabezado_telefono { get { return _encabezado_telefono; } set { _encabezado_telefono = value; } }
        public string encabezado_lugar { get { return _encabezado_lugar; } set { _encabezado_lugar = value; } }
        public string codigo_moneda { get { return _codigo_moneda; } }
        #endregion

        #region Constructores
        public comprobante_dpr(int Id_comprobantedpr, int Num_comprobante)
        {
            _id_comprobantedpr = Id_comprobantedpr;
            _num_comprobante = Num_comprobante;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static int IdPorNumero(int Num_comprobante, string Negocio)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("comprobante_dpr_IdPorNumero");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "negocio", DbType.String, Negocio);
                db1.AddInParameter(cmd, "num_comprobante", DbType.Int32, Num_comprobante);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int IdContrato(int Id_comprobantedpr)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("comprobante_dpr_IdContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_comprobantedpr", DbType.Int32, Id_comprobantedpr);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int IdPorTransaccion(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("comprobante_dpr_IdPorTransaccion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int AnularReimprimir(int Id_comprobantedpr, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("comprobante_dpr_AnularReimprimir");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_comprobantedpr", DbType.Int32, Id_comprobantedpr);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);

                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                int Id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                if (Id_transaccion > 0)
                {
                    return Id_transaccion;
                }
                else return 0;
            }
            catch { return 0; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("comprobante_dpr_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_comprobantedpr0", DbType.Int32, _id_comprobantedpr);
                db1.AddInParameter(cmd, "num_comprobante0", DbType.Int32, _num_comprobante);
                db1.AddOutParameter(cmd, "id_comprobantedpr", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_comprobante", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "nombre_cliente", DbType.String, 200);
                db1.AddOutParameter(cmd, "concepto", DbType.String, 200);
                db1.AddOutParameter(cmd, "monto_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "tipo_cambio", DbType.Double, 14);
                db1.AddOutParameter(cmd, "encabezado", DbType.String, 300);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "anulado_fecha", DbType.DateTime, 20);
                db1.AddOutParameter(cmd, "anulado_id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);

                _id_comprobantedpr = (int)db1.GetParameterValue(cmd, "id_comprobantedpr");
                _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                _num_comprobante = (int)db1.GetParameterValue(cmd, "num_comprobante");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _nombre_cliente = (string)db1.GetParameterValue(cmd, "nombre_cliente");
                _concepto = (string)db1.GetParameterValue(cmd, "concepto");
                _monto_sus = (decimal)(double)db1.GetParameterValue(cmd, "monto_sus");
                _tipo_cambio = (decimal)(double)db1.GetParameterValue(cmd, "tipo_cambio");
                string encab = (string)db1.GetParameterValue(cmd, "encabezado");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");
                _anulado_fecha = (DateTime)db1.GetParameterValue(cmd, "anulado_fecha");
                _anulado_id_usuario = (int)db1.GetParameterValue(cmd, "anulado_id_usuario");
                _codigo_moneda = (string)db1.GetParameterValue(cmd, "codigo_moneda");
                if (encab.Contains("|") == true)
                {
                    string[] enca = encab.Split('|');
                    _encabezado_empresa = enca[0];
                    _encabezado_actividad = enca[1];
                    _encabezado_direccion = enca[2];
                    _encabezado_telefono = enca[3];
                    _encabezado_lugar = enca[4];
                }
            }
            catch { }
        }
        #endregion
    }
}