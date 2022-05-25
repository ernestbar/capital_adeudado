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
/// Summary description for grupo_recurso
/// </summary>
namespace terrasur
{
    public class grupo_recurso
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_gruporecurso = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_gruporecurso { get { return _id_gruporecurso; } set { _id_gruporecurso = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public grupo_recurso(int Id_gruporecurso)
        {
            _id_gruporecurso = Id_gruporecurso;
            RecuperarDatos();
        }
        public grupo_recurso(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_gruporecurso],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_recurso_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaPorRol(int Id_rol)
        {
            //[id_gruporecurso],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_recurso_ListaPorRol");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_recurso_RecuperarDatos");
                db1.AddInParameter(cmd, "id_gruporecurso0", DbType.Int32, _id_gruporecurso);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_gruporecurso", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_gruporecurso = (int)db1.GetParameterValue(cmd, "id_gruporecurso");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion
    }
}