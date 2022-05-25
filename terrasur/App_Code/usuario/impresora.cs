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
/// Summary description for impresora
/// </summary>
namespace terrasur
{
    public class impresora
    { 
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_impresora = 0;
        private string _nombre = "";
        private string _direccion_red = "";
        private bool _factura = false;
        private bool _recibo = false;
        private bool _comprobante = false;
        private bool _activo = false;

        //Propiedades públicas
        public int id_impresora { get { return _id_impresora; } set { _id_impresora = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string direccion_red { get { return _direccion_red; } set { _direccion_red = value; } }
        public bool factura { get { return _factura; } set { _factura = value; } }
        public bool recibo { get { return _recibo; } set { _recibo = value; } }
        public bool comprobante { get { return _comprobante; } set { _comprobante = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        #endregion

        #region Constructores
        public impresora(int Id_impresora)
        {
            _id_impresora = Id_impresora;
            RecuperarDatos();
        }
        public impresora(string Nombre, string Direccion_red, bool Factura, bool Recibo, bool Comprobante, bool Activo)
        {
            _nombre = Nombre;
            _direccion_red = Direccion_red;
            _factura = Factura;
            _recibo = Recibo;
            _comprobante = Comprobante;
            _activo = Activo;
        }
        public impresora(int Id_impresora, string Nombre, string Direccion_red, bool Factura, bool Recibo, bool Comprobante, bool Activo)
        {
            _id_impresora = Id_impresora;
            _nombre = Nombre;
            _direccion_red = Direccion_red;
            _factura = Factura;
            _recibo = Recibo;
            _comprobante = Comprobante;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(bool Factura, bool Recibo, bool Comprobante, bool Solo_activos)
        {
            DbCommand cmd = db1.GetStoredProcCommand("impresora_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "factura", DbType.Boolean, Factura);
            db1.AddInParameter(cmd, "recibo", DbType.Boolean, Recibo);
            db1.AddInParameter(cmd, "comprobante", DbType.Boolean, Comprobante);
            db1.AddInParameter(cmd, "solo_activos", DbType.Boolean, Solo_activos);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool Verificar(string direccion_red)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("impresora_Verificar");
                db1.AddInParameter(cmd, "direccion_red", DbType.String, direccion_red);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }

        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("impresora_RecuperarDatos");
                db1.AddInParameter(cmd, "id_impresora", DbType.Int32, _id_impresora);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 30);
                db1.AddOutParameter(cmd, "direccion_red", DbType.String, 50);
                db1.AddOutParameter(cmd, "factura", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "recibo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "comprobante", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.ExecuteNonQuery(cmd);
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _direccion_red = (string)db1.GetParameterValue(cmd, "direccion_red");
                _factura = (bool)db1.GetParameterValue(cmd, "factura");
                _recibo = (bool)db1.GetParameterValue(cmd, "recibo");
                _comprobante = (bool)db1.GetParameterValue(cmd, "comprobante");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
            }
            catch { }
        }

        public bool Insertar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("impresora_Insertar");
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "direccion_red", DbType.String, _direccion_red);
                db1.AddInParameter(cmd, "factura", DbType.Boolean, _factura);
                db1.AddInParameter(cmd, "recibo", DbType.Boolean, _recibo);
                db1.AddInParameter(cmd, "comprobante", DbType.Boolean, _comprobante);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                _id_impresora = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("impresora_Actualizar");
                db1.AddInParameter(cmd, "id_impresora", DbType.Int32, _id_impresora);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "direccion_red", DbType.String, _direccion_red);
                db1.AddInParameter(cmd, "factura", DbType.Boolean, _factura);
                db1.AddInParameter(cmd, "recibo", DbType.Boolean, _recibo);
                db1.AddInParameter(cmd, "comprobante", DbType.Boolean, _comprobante);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("impresora_Eliminar");
                db1.AddInParameter(cmd, "id_impresora", DbType.Int32, _id_impresora);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}