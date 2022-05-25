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
/// Summary description for lugar_cobro
/// </summary>
namespace terrasur
{
    public class sucursal
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_sucursal = 0;
        private int _num_sucursal = 0;
        private string _nombre = "";
        private string _direccion = "";
        private string _telefono = "";
        private string _lugar = "";
        private bool _activo = false;

        private int _num_parametros = 0;

        //Propiedades públicas
        public int id_sucursal { get { return _id_sucursal; } set { _id_sucursal = value; } }
        public int num_sucursal { get { return _num_sucursal; } set { _num_sucursal = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string direccion { get { return _direccion; } set { _direccion = value; } }
        public string telefono { get { return _telefono; } set { _telefono = value; } }
        public string lugar { get { return _lugar; } set { _lugar = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_parametros { get { return _num_parametros; } }
        #endregion

        #region Constructores
        public sucursal(int Id_sucursal, int Num_sucursal)
        {
            _id_sucursal = Id_sucursal;
            _num_sucursal = Num_sucursal;
            RecuperarDatos();
        }
        public sucursal(int Num_sucursal, string Nombre, string Direccion, string Telefono, string Lugar, bool Activo)
        {
            _num_sucursal = Num_sucursal;
            _nombre = Nombre;
            _direccion = Direccion;
            _telefono = Telefono;
            _lugar = Lugar;
            _activo = Activo;
        }
        public sucursal(int Id_sucursal, int Num_sucursal, string Nombre, string Direccion, string Telefono, string Lugar, bool Activo)
        {
            _id_sucursal = Id_sucursal;
            _num_sucursal = Num_sucursal;
            _nombre = Nombre;
            _direccion = Direccion;
            _telefono = Telefono;
            _lugar = Lugar;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_sucursal],[num_sucursal],[nombre],[direccion],[telefono],[lugar],[activo],[num_transacciones],[num_parametros]
            DbCommand cmd = db1.GetStoredProcCommand("sucursal_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaParaDDL()
        {
            //[id_sucursal],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("sucursal_ListaParaDDL");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarNumSucursal(int Num_sucursal, bool Inserta, int Id_sucursal)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("sucursal_VerificarNumSucursal");
                db1.AddInParameter(cmd, "num_sucursal", DbType.Int32, Num_sucursal);
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static int IdSucursalPorNum(int Num_sucursal)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("sucursal_IdSucursalPorNum");
                db1.AddInParameter(cmd, "num_sucursal", DbType.Int32, Num_sucursal);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static int IdSucursalPorIdDocumento(int Id_factura, int Id_recibo, int Id_comprobante)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("sucursal_IdSucursalPorIdDocumento");
                db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                db1.AddInParameter(cmd, "id_recibo", DbType.Int32, Id_recibo);
                db1.AddInParameter(cmd, "id_comprobante", DbType.Int32, Id_comprobante);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("sucursal_RecuperarDatos");
                db1.AddInParameter(cmd, "id_sucursal0", DbType.Int32, _id_sucursal);
                db1.AddInParameter(cmd, "num_sucursal0", DbType.Int32, _num_sucursal);

                db1.AddOutParameter(cmd, "id_sucursal", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_sucursal", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 20);
                db1.AddOutParameter(cmd, "direccion", DbType.String, 50);
                db1.AddOutParameter(cmd, "telefono", DbType.String, 50);
                db1.AddOutParameter(cmd, "lugar", DbType.String, 50);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_parametros", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_sucursal = (int)db1.GetParameterValue(cmd, "id_sucursal");
                _num_sucursal = (int)db1.GetParameterValue(cmd, "num_sucursal");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _direccion = (string)db1.GetParameterValue(cmd, "direccion");
                _telefono = (string)db1.GetParameterValue(cmd, "telefono");
                _lugar = (string)db1.GetParameterValue(cmd, "lugar");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");

                _num_parametros = (int)db1.GetParameterValue(cmd, "num_parametros");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarNumSucursal(_num_sucursal, true, 0) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("sucursal_Insertar");
                    db1.AddInParameter(cmd, "num_sucursal", DbType.Int32, _num_sucursal);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "direccion", DbType.String, _direccion);
                    db1.AddInParameter(cmd, "telefono", DbType.String, _telefono);
                    db1.AddInParameter(cmd, "lugar", DbType.String, _lugar);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    _id_sucursal = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarNumSucursal(_num_sucursal, false, _id_sucursal) == false)
            {

                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("sucursal_Actualizar");
                    db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, _id_sucursal);
                    db1.AddInParameter(cmd, "num_sucursal", DbType.Int32, _num_sucursal);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "direccion", DbType.String, _direccion);
                    db1.AddInParameter(cmd, "telefono", DbType.String, _telefono);
                    db1.AddInParameter(cmd, "lugar", DbType.String, _lugar);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (_num_parametros == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("sucursal_Eliminar");
                    db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, _id_sucursal);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }
        #endregion
    }
}