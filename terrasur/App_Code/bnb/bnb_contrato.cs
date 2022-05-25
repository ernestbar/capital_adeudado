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
/// Summary description for bnb_contrato
/// </summary>
namespace terrasur
{
    public class bnb_contrato
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
        public static bool Generar(int Id_institucion, string Cadena_contratos, DateTime Fecha_Evaluacion, int context_id_usuario)
        {
            if (Cadena_contratos.Trim() != "") Cadena_contratos = "," + Cadena_contratos.Trim() + ",";
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_contrato_Generar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
                db1.AddInParameter(cmd, "cadena_contratos", DbType.String, Cadena_contratos);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha_Evaluacion);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion


    }
}