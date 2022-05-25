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
/// Summary description for factura
/// </summary>
namespace terrasur
{
    public class factura
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_factura = 0;
        private int _id_parametrofacturacion = 0;
        private int _id_transaccion = 0;
        private string _razon_social = "";
        private decimal _nit = 0;
        private DateTime _fecha_limite = DateTime.Now;
        private decimal _num_autorizacion = 0;
        private int _num_factura = 0;
        private DateTime _fecha = DateTime.Now;
        private string _cliente_nombre = "";
        private decimal _cliente_nit = 0;
        private string _concepto = "";
        private decimal _monto_bs = 0;
        private decimal _tipo_cambio = 0;
        private string _numero_control = "";
        private bool _anulado = false;
        private DateTime _anulado_fecha = DateTime.Now;
        private int _anulado_id_usuario = 0;
        private string _encabezado_empresa = "";
        private string _encabezado_actividad = "";
        private string _encabezado_direccion = "";
        private string _encabezado_telefono = "";
        private string _encabezado_lugar = "";

        private decimal _aux_monto_sus = 0;
        private string _num_cuotas = "";
        private string _codigo_moneda = "";

        //Propiedades públicas
        public int id_factura { get { return _id_factura; } set { _id_factura = value; } }
        public int id_parametrofacturacion { get { return _id_parametrofacturacion; } set { _id_parametrofacturacion = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public string razon_social { get { return _razon_social; } set { _razon_social = value; } }
        public decimal nit { get { return _nit; } set { _nit = value; } }
        public DateTime fecha_limite { get { return _fecha_limite; } set { _fecha_limite = value; } }
        public decimal num_autorizacion { get { return _num_autorizacion; } set { _num_autorizacion = value; } }
        public int num_factura { get { return _num_factura; } set { _num_factura = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string cliente_nombre { get { return _cliente_nombre; } set { _cliente_nombre = value; } }
        public decimal cliente_nit { get { return _cliente_nit; } set { _cliente_nit = value; } }
        public string concepto { get { return _concepto; } set { _concepto = value; } }
        public decimal monto_bs { get { return _monto_bs; } set { _monto_bs = value; } }
        public decimal tipo_cambio { get { return _tipo_cambio; } set { _tipo_cambio = value; } }
        public string numero_control { get { return _numero_control; } set { _numero_control = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }
        public DateTime anulado_fecha { get { return _anulado_fecha; } set { _anulado_fecha = value; } }
        public int anulado_id_usuario { get { return _anulado_id_usuario; } set { _anulado_id_usuario = value; } }
        public string encabezado_empresa { get { return _encabezado_empresa; } set { _encabezado_empresa = value; } }
        public string encabezado_actividad { get { return _encabezado_actividad; } set { _encabezado_actividad = value; } }
        public string encabezado_direccion { get { return _encabezado_direccion; } set { _encabezado_direccion = value; } }
        public string encabezado_telefono { get { return _encabezado_telefono; } set { _encabezado_telefono = value; } }
        public string encabezado_lugar { get { return _encabezado_lugar; } set { _encabezado_lugar = value; } }

        public string num_cuotas { get { return _num_cuotas; } set { _num_cuotas = value; } }
        public string codigo_moneda { get { return _codigo_moneda; } }

        #endregion

        #region Constructores
        public factura(int Id_factura)
        {
            _id_factura = Id_factura;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static int IdPorNumeroFecha(int Id_sucursal, int Num_factura, DateTime Fecha,int Id_negocio)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_IdPorNumeroFecha");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "num_factura", DbType.Int32, Num_factura);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int IdPorTransaccion(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_IdPorTransaccion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int IdContrato(int Id_factura)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_IdContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static bool PermitirAnularReimprimir(int Id_factura, int context_id_usuario, int context_id_rol, string Codigo_pago)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_PermitirAnularReimprimir");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static int AnularReimprimir(int Id_factura, int context_id_usuario,int context_id_rol , int Id_contrato, string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_AnularReimprimir");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
               
                db1.AddInParameter(cmd, "cliente_nombre", DbType.String, Cliente_nombre);
                db1.AddInParameter(cmd, "cliente_nit", DbType.Decimal, Cliente_nit);
                db1.AddInParameter(cmd, "cliente_guardar", DbType.Boolean, Cliente_guardar);

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

        // Facturacion Sintesis
        public static bool ActualizarDatos(int Id_factura, string Cuf, string Url, string Email)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_ActualizarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                db1.AddInParameter(cmd, "cuf", DbType.String, Cuf);
                db1.AddInParameter(cmd, "url", DbType.String, Url);
                db1.AddInParameter(cmd, "email", DbType.String, Email);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public static DataTable RecuperarDatosNuevos(int Id_factura)
        {
            DbCommand cmd = db1.GetStoredProcCommand("factura_RecuperarDatosNuevos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        //
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("factura_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_factura", DbType.Int32, _id_factura);
                db1.AddOutParameter(cmd, "id_parametrofacturacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "razon_social", DbType.String, 100);
                db1.AddOutParameter(cmd, "nit", DbType.Double, 10);
                db1.AddOutParameter(cmd, "fecha_limite", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "num_autorizacion", DbType.Double, 15);
                db1.AddOutParameter(cmd, "num_factura", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "cliente_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "cliente_nit", DbType.Double, 15);
                db1.AddOutParameter(cmd, "concepto", DbType.String, 200);
                db1.AddOutParameter(cmd, "monto_bs", DbType.Double, 14);
                db1.AddOutParameter(cmd, "tipo_cambio", DbType.Double, 14);
                db1.AddOutParameter(cmd, "numero_control", DbType.String, 14);
                db1.AddOutParameter(cmd, "encabezado", DbType.String, 300);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "anulado_fecha", DbType.DateTime, 20);
                db1.AddOutParameter(cmd, "anulado_id_usuario", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "num_cuotas", DbType.String, 100);
                db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 50);
                
                db1.ExecuteNonQuery(cmd);

                _id_parametrofacturacion = (int)db1.GetParameterValue(cmd, "id_parametrofacturacion");
                _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                _razon_social = (string)db1.GetParameterValue(cmd, "razon_social");
                _nit = (decimal)(double)db1.GetParameterValue(cmd, "nit");
                _fecha_limite = (DateTime)db1.GetParameterValue(cmd, "fecha_limite");
                _num_autorizacion = (decimal)(double)db1.GetParameterValue(cmd, "num_autorizacion");
                _num_factura = (int)db1.GetParameterValue(cmd, "num_factura");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _cliente_nombre = (string)db1.GetParameterValue(cmd, "cliente_nombre");
                _cliente_nit = (decimal)(double)db1.GetParameterValue(cmd, "cliente_nit");
                _concepto = (string)db1.GetParameterValue(cmd, "concepto");
                _monto_bs = (decimal)(double)db1.GetParameterValue(cmd, "monto_bs");
                _tipo_cambio = (decimal)(double)db1.GetParameterValue(cmd, "tipo_cambio");
                _numero_control = (string)db1.GetParameterValue(cmd, "numero_control");
                string encab = (string)db1.GetParameterValue(cmd, "encabezado");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");
                _anulado_fecha = (DateTime)db1.GetParameterValue(cmd, "anulado_fecha");
                _anulado_id_usuario = (int)db1.GetParameterValue(cmd, "anulado_id_usuario");

                _num_cuotas = (string)db1.GetParameterValue(cmd, "num_cuotas");
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