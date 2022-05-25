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
using System.Collections.Generic;

/// <summary>
/// Summary description for bnb_institucion
/// </summary>
namespace terrasur
{
    public class bnb_institucion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades privadas
        #endregion

        #region Propiedades públicas
        #endregion

        #region Constructores
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_institucion],[codigo],[bnb_codigo],[bnb_inicial]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_institucion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion


    }
}