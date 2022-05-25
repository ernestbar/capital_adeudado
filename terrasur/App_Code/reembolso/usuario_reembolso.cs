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
/// Descripción breve de usuario_reembolso
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class usuario_reembolso
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas

            //Propiedades públicas
            #endregion

            #region Constructores
            public usuario_reembolso()
            {
            }
            #endregion

            #region Métodos que NO requieren constructor

            public static bool Insertar(int Id_usuario, int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_usuario_reembolso_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);

                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public static bool Eliminar(int Id_usuario, int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_usuario_reembolso_Eliminar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);

                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public static bool Verificar(int Id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_usuario_reembolso_Verificar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                    if ((int)db1.ExecuteScalar(cmd) == 0) { return false; }
                    else { return true; }
                }
                catch { return true; }
            }

            public static int IdPorCI(string Ci)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_usuario_reembolso_IdPorCI");
                    db1.AddInParameter(cmd, "ci", DbType.String, Ci);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static DataTable Lista(int Id_usuario)
            {
                //[id_usuario],[ci],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("re_usuario_reembolso_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            #endregion
        }
    }
}