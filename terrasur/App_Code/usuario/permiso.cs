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
/// Summary description for permiso
/// </summary>
namespace terrasur
{
    public class permiso
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_permiso = 0;
        private int _id_recurso = 0;
        private string _codigo = "";
        private string _nombre = "";

        private string _recurso_codigo = "";
        private string _recurso_nombre = "";

        //Propiedades públicas
        public int id_permiso { get { return _id_permiso; } set { _id_permiso = value; } }
        public int id_recurso { get { return _id_recurso; } set { _id_recurso = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public string recurso_codigo { get { return _recurso_codigo; } }
        public string recurso_nombre { get { return _recurso_nombre; } }
        #endregion

        #region Constructores
        public permiso(int Id_permiso)
        {
            _id_permiso = Id_permiso;
            RecuperarDatos();
        }
        public permiso(string Codigo, string Recurso_codigo)
        {
            _codigo = Codigo;
            _recurso_codigo = Recurso_codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorRecurso(int Id_recurso)
        {
            //[id_permiso],[id_recurso],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("permiso_ListaPorRecurso");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_recurso", DbType.Int32, Id_recurso);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool Verificar(int Id_usuario, int Id_rol, string Codigo_recurso, string Codigo_permiso)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("permiso_Verificar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                db1.AddInParameter(cmd, "codigo_recurso", DbType.String, Codigo_recurso);
                db1.AddInParameter(cmd, "codigo_permiso", DbType.String, Codigo_permiso);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("permiso_RecuperarDatos");
                db1.AddInParameter(cmd, "id_permiso0", DbType.Int32, _id_permiso);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddInParameter(cmd, "recurso_codigo0", DbType.String, _recurso_codigo);
                db1.AddOutParameter(cmd, "id_permiso", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_recurso", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "recurso_codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "recurso_nombre", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_permiso = (int)db1.GetParameterValue(cmd, "id_permiso");
                _id_recurso = (int)db1.GetParameterValue(cmd, "id_recurso");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _recurso_codigo = (string)db1.GetParameterValue(cmd, "recurso_codigo");
                _recurso_nombre = (string)db1.GetParameterValue(cmd, "recurso_nombre");
            }
            catch { }
        }
        #endregion
    }
}