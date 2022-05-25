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
/// Summary description for transaccion
/// </summary>
namespace terrasur
{
    public class transaccion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_transaccion = 0;
        private int _id_moneda = 0;
        private int _id_usuario = 0;
        private int _id_negocio = 0;
        private int _id_negociocontrato = 0;
        private int _id_recibocobrador = 0;
        private DateTime _fecha = DateTime.Now;
        private int _ntrans = 0;
        private decimal _tipo_cambio = 0;
        private decimal _monto = 0;
        private bool _comisionable = false;
        private bool _anulado = false;
        private DateTime _anulado_fecha = DateTime.Now;
        private int _anulado_id_usuario = 0;
        private int _id_sucursal = 0;

        private int _id_contrato = 0;
        private bool _pago_de_servicio = true;
        private string _codigo_moneda = "";

        //Propiedades públicas
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int id_negocio { get { return _id_negocio; } set { _id_negocio = value; } }
        public int id_negociocontrato { get { return _id_negociocontrato; } set { _id_negociocontrato = value; } }
        public int id_recibocobrador { get { return _id_recibocobrador; } set { _id_recibocobrador = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int ntrans { get { return _ntrans; } set { _ntrans = value; } }
        public decimal tipo_cambio { get { return _tipo_cambio; } set { _tipo_cambio = value; } }
        public decimal monto { get { return _monto; } set { _monto = value; } }
        public bool comisionable { get { return _comisionable; } set { _comisionable = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }
        public DateTime anulado_fecha { get { return _anulado_fecha; } set { _anulado_fecha = value; } }
        public int anulado_id_usuario { get { return _anulado_id_usuario; } set { _anulado_id_usuario = value; } }
        public int id_sucursal { get { return _id_sucursal; } set { _id_sucursal = value; } }

        public int id_contrato { get { return _id_contrato; } }
        public bool pago_de_servicio { get { return _pago_de_servicio; } }
        public string codigo_moneda { get { return _codigo_moneda; } }
        #endregion

        #region Constructores
        public transaccion(int Id_transaccion)
        {
            _id_transaccion = Id_transaccion;
            RecuperarDatos();
        }
        public transaccion(int Id_contrato, bool Pago_de_servicio, int Id_recibocobrador, decimal Monto, bool Comisionable)
        {
            _id_contrato = Id_contrato;
            _pago_de_servicio = Pago_de_servicio;
            _id_recibocobrador = Id_recibocobrador;
            _tipo_cambio = new tipo_cambio(DateTime.Now.Date).compra;
            _monto = Monto;
            _comisionable = Comisionable;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static string CodigoTipoPago(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("transaccion_CodigoTipoPago");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (string)db1.ExecuteScalar(cmd);
            }
            catch { return "0"; }
        }
        public static int IdContrato(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("transaccion_IdContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "Id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static DataTable datos_para_odoo(int Id_Transaccion)
        {
            DbCommand cmd = db1.GetStoredProcCommand("transaccion_RecuperarDatos_odoo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_Transaccion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("transaccion_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                db1.AddOutParameter(cmd, "id_moneda", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_negocio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_negociocontrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_recibocobrador", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "ntrans", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "tipo_cambio", DbType.Double, 14);
                db1.AddOutParameter(cmd, "monto", DbType.Double, 14);
                db1.AddOutParameter(cmd, "comisionable", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "anulado_fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "anulado_id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_sucursal", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);

                _id_moneda = (int)db1.GetParameterValue(cmd, "id_moneda");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _id_negocio = (int)db1.GetParameterValue(cmd, "id_negocio");
                _id_negociocontrato = (int)db1.GetParameterValue(cmd, "id_negociocontrato");
                _id_recibocobrador = (int)db1.GetParameterValue(cmd, "id_recibocobrador");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _ntrans = (int)db1.GetParameterValue(cmd, "ntrans");
                _tipo_cambio = (decimal)(double)db1.GetParameterValue(cmd, "tipo_cambio");
                _monto = (decimal)(double)db1.GetParameterValue(cmd, "monto");
                _comisionable = (bool)db1.GetParameterValue(cmd, "comisionable");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");
                _anulado_fecha = (DateTime)db1.GetParameterValue(cmd, "anulado_fecha");
                _anulado_id_usuario = (int)db1.GetParameterValue(cmd, "anulado_id_usuario");
                _id_sucursal = (int)db1.GetParameterValue(cmd, "id_sucursal");
                _codigo_moneda = (string)db1.GetParameterValue(cmd, "codigo_moneda");
            }
            catch { }
        }
        #endregion
    }
}