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
using System.Collections;

/// <summary>
/// Descripción breve de promocion
/// </summary>
namespace terrasur
{
    public class promocion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        #region Propiedades
        #endregion

        #region Constructores
        //public promocion() { }
        #endregion

        #region Métodos que NO requieren constructor

        public static Hashtable PermisoPorContrato(int Id_contrato)
        {
            //[permitir],[periodo_correcto],[es_terreno],[es_nafibo],[num_pagos_promo_mes],[al_dia]
            Hashtable hashtable = new Hashtable();
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("promocion_PermisoPorContrato");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataColumn columna in tabla.Columns)
                    {
                        hashtable.Add(columna.ColumnName, tabla.Rows[0][columna.ColumnName].ToString());
                    }
                }
            }
            catch { }
            return hashtable;
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion

    }
}