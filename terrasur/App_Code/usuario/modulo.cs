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
/// Summary description for modulo
/// </summary>
namespace terrasur
{
    public class modulo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_modulo = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_modulo { get { return _id_modulo; } set { _id_modulo = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public modulo(int Id_modulo)
        {
            _id_modulo = Id_modulo;
            RecuperarDatos();
        }
        public modulo(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_modulo],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("modulo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int Obtener_Rol_del_usuario_por_modulo(int Id_usuario, string Codigo_modulo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("modulo_Obtener_Rol_del_usuario_por_modulo");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "codigo_modulo", DbType.String, Codigo_modulo);
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
                DbCommand cmd = db1.GetStoredProcCommand("modulo_RecuperarDatos");
                db1.AddInParameter(cmd, "id_modulo0", DbType.Int32, _id_modulo);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_modulo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_modulo = (int)db1.GetParameterValue(cmd, "id_modulo");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion
    }
}