using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de s_tipo_pago
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_tipo_pago
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas

            //Propiedades públicas
            #endregion

            #region Constructores
            //public s_tipo_pago() { }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_tipopago],[codigo],[nombre],[activo]
                DbCommand cmd = db1.GetStoredProcCommand("s_tipo_pago_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            #endregion

        }
    }
}