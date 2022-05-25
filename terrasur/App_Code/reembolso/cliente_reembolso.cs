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
using System.Text;

/// <summary>
/// Descripción breve de cliente_reembolso
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class cliente_reembolso
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas

            //Propiedades públicas
            #endregion

            #region Constructores
            public cliente_reembolso()
            {
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_reembolso)
            {
                //[id_cliente],[nombre],[ci],[primer_titular],[primer_titular_bit]
                DbCommand cmd = db1.GetStoredProcCommand("re_cliente_reembolso_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static string Lista_string(int Id_reembolso, bool con_salto_de_linea)
            {
                DataTable tabla = Lista(Id_reembolso);
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    if (con_salto_de_linea)
                    {
                        if ((bool)tabla.Rows[j]["primer_titular_bit"])
                        { str.AppendLine("* " + tabla.Rows[j]["nombre"].ToString() + " (" + tabla.Rows[j]["ci"].ToString() + ")"); }
                        else { str.AppendLine(tabla.Rows[j]["nombre"].ToString() + " (" + tabla.Rows[j]["ci"].ToString() + ")"); }
                    }
                    else
                    {
                        if ((bool)tabla.Rows[j]["primer_titular_bit"]) { str.Append("* "); }
                        str.Append(tabla.Rows[j]["nombre"].ToString());
                        str.Append(" (" + tabla.Rows[j]["ci"].ToString() + ")");
                        str.Append(", ");
                    }
                }
                return str.ToString().Trim().TrimEnd(',');
            }

            public static DataTable ListaPorContrato(int Id_contrato)
            {
                //[id_cliente],[nombre],[ci],[primer_titular],[primer_titular_bit]
                DbCommand cmd = db1.GetStoredProcCommand("re_cliente_reembolso_ListaPorContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static string ListaPorContrato_string(int Id_contrato, bool con_salto_de_linea)
            {
                DataTable tabla = ListaPorContrato(Id_contrato);
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    if (con_salto_de_linea)
                    {
                        if ((bool)tabla.Rows[j]["primer_titular_bit"])
                        { str.AppendLine("* " + tabla.Rows[j]["nombre"].ToString() + " (" + tabla.Rows[j]["ci"].ToString() + ")"); }
                        else { str.AppendLine(tabla.Rows[j]["nombre"].ToString() + " (" + tabla.Rows[j]["ci"].ToString() + ")"); }
                    }
                    else
                    {
                        if ((bool)tabla.Rows[j]["primer_titular_bit"]) { str.Append("* "); }
                        str.Append(tabla.Rows[j]["nombre"].ToString());
                        str.Append(" (" + tabla.Rows[j]["ci"].ToString() + ")");
                        str.Append(", ");
                    }
                }
                return str.ToString().Trim().TrimEnd(',');
            }

            #endregion

            #region Métodos que requieren constructor
            #endregion
        }
    }
}