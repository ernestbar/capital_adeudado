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
/// Summary description for adj_ingreso
/// </summary>
namespace terrasur
{
    public class adj_ingreso
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_documento)
        {
            //[id_ingreso],[fecha],[usuario]
            DbCommand cmd = db1.GetStoredProcCommand("adj_ingreso_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_documento", DbType.Int32, Id_documento);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static void Insertar(int Id_documento, int Id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_ingreso_Insertar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_documento", DbType.Int32, Id_documento);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.ExecuteNonQuery(cmd);
                /*return true;*/
            }
            catch { /*return false;*/ }
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}