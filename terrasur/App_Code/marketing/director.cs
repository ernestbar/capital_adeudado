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
/// Summary description for director
/// </summary>
namespace terrasur
{
    public class director : usuario
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupoventa = 0;
        private string _nombre_grupoventa = "";

        //Propiedades públicas
        public int id_grupoventa { get { return _id_grupoventa; } set { _id_grupoventa = value; } }
        public string nombre_grupoventa { get { return _nombre_grupoventa; } set { _nombre_grupoventa = value; } }
        #endregion

        #region Constructores
        public director(int Id_director)
            : base(Id_director)
        {
            RecuperarDatosDirector();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_grupoventa)
        {
            //[id_usuario],[nombre_completo],[ci],[nombre_usuario]
            DbCommand cmd = db1.GetStoredProcCommand("director_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["director_codigo"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static int NumeroGrupos(int Id_director, int Id_grupoventa)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("director_NumeroGrupos");
                db1.AddInParameter(cmd, "id_director", DbType.Int32, Id_director);
                db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 1; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatosDirector()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("director_RecuperarDatos");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, this.id_usuario);
                db1.AddOutParameter(cmd, "id_grupoventa", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_grupoventa", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_grupoventa = (int)db1.GetParameterValue(cmd, "id_grupoventa");
                _nombre_grupoventa = (string)db1.GetParameterValue(cmd, "nombre_grupoventa");
            }
            catch { }
        }
        #endregion
    }
}