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
/// Summary description for recurso
/// </summary>
namespace terrasur
{
    public class recurso
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_recurso = 0;
        private int _id_gruporecurso = 0;
        private string _codigo = "";
        private string _nombre = "";

        private string _codigo_gruporecurso = "";
        private string _nombre_gruporecurso = "";

        //Propiedades públicas
        public int id_recurso { get { return _id_recurso; } set { _id_recurso = value; } }
        public int id_gruporecurso { get { return _id_gruporecurso; } set { _id_gruporecurso = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public string codigo_gruporecurso { get { return _codigo_gruporecurso; } }
        public string nombre_gruporecurso { get { return _nombre_gruporecurso; } }
        #endregion

        #region Constructores
        public recurso(int Id_recurso)
        {
            _id_recurso = Id_recurso;
            RecuperarDatos();
        }
        public recurso(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorGrupoRecurso(int Id_gruporecurso)
        {
            //[id_recurso],[id_gruporecurso],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("recurso_ListaPorGrupoRecurso");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_gruporecurso", DbType.Int32, Id_gruporecurso);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaPorRolGrupoRecurso(int Id_rol, int Id_gruporecurso)
        {
            //[id_recurso],[id_gruporecurso],[codigo],[nombre],[num_permisos]
            DbCommand cmd = db1.GetStoredProcCommand("recurso_ListaPorRolGrupoRecurso");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
            db1.AddInParameter(cmd, "id_gruporecurso", DbType.Int32, Id_gruporecurso);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaPorModulo(int Id_modulo)
        {
            //[id_recurso],[id_gruporecurso],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("recurso_ListaPorModulo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_modulo", DbType.Int32, Id_modulo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recurso_RecuperarDatos");
                db1.AddInParameter(cmd, "id_recurso0", DbType.Int32, _id_recurso);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_recurso", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_gruporecurso", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "codigo_gruporecurso", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_gruporecurso", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_recurso = (int)db1.GetParameterValue(cmd, "id_recurso");
                _id_gruporecurso = (int)db1.GetParameterValue(cmd, "id_gruporecurso");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _codigo_gruporecurso = (string)db1.GetParameterValue(cmd, "codigo_gruporecurso");
                _nombre_gruporecurso = (string)db1.GetParameterValue(cmd, "nombre_gruporecurso");
            }
            catch { }
        }
        #endregion
    }
}