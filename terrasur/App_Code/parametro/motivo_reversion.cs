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
/// Summary description for motivo_reversion
/// </summary>
namespace terrasur
{
    public class motivo_reversion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_motivoreversion = 0;
        private int _id_usuario = 0;
        private string _codigo = "";
        private string _nombre = "";
        private bool _sistema = false;

        private int _num_reversiones = 0;

        //Propiedades públicas
        public int id_motivoreversion { get { return _id_motivoreversion; } set { _id_motivoreversion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool sistema { get { return _sistema; } set { _sistema = value; } }

        public int num_reversiones { get { return _num_reversiones; } }
        #endregion

        #region Constructores
        public motivo_reversion(int Id_motivoreversion)
        {
            _id_motivoreversion = Id_motivoreversion;
            RecuperarDatos();
        }
        public motivo_reversion(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        public motivo_reversion(string Codigo, string Nombre, bool Sistema)
        {
            _codigo = Codigo;
            _nombre = Nombre;
            _sistema = Sistema; 
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_motivoreversion],[id_usuario],[codigo],[nombre],[sistema]
            DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaNoSistema()
        {
            //[id_motivoreversion],[id_usuario],[codigo],[nombre],[sistema]
            DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_ListaNoSistema");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarCodigoNombre(bool Inserta, int Id_motivoreversion, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_motivoreversion", DbType.Int32, Id_motivoreversion);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
                db1.AddInParameter(cmd, "nombre", DbType.String, Nombre);
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
                DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_motivoreversion0", DbType.Int32, _id_motivoreversion);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_motivoreversion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "sistema", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_reversiones", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_motivoreversion = (int)db1.GetParameterValue(cmd, "id_motivoreversion");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _sistema = (bool)db1.GetParameterValue(cmd, "sistema");


                _num_reversiones = (int)db1.GetParameterValue(cmd, "num_reversiones");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "sistema", DbType.Boolean, _sistema);
                    _id_motivoreversion = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }

        }


        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(false, _id_motivoreversion, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_Actualizar");
                    db1.AddInParameter(cmd, "id_motivoreversion", DbType.Int32, _id_motivoreversion);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "sistema", DbType.Boolean, _sistema);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_reversiones == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("motivo_reversion_Eliminar");
                    db1.AddInParameter(cmd, "id_motivoreversion", DbType.Int32, _id_motivoreversion);
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