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
/// Descripción breve de s_sucursal_eeff
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_sucursal_eeff
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_sucursal_eeff = 0;
            private int _id_eeff = 0;
            private string _codigo = "";
            private string _nombre = "";

            //Propiedades públicas
            public int id_sucursal_eeff { get { return _id_sucursal_eeff; } set { _id_sucursal_eeff = value; } }
            public int id_eeff { get { return _id_eeff; } set { _id_eeff = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            #endregion

            #region Constructores
            public s_sucursal_eeff(int Id_sucursal_eeff, string Nombre)
            {
                _id_sucursal_eeff = Id_sucursal_eeff;
                _nombre = Nombre;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_eeff)
            {
                //[id_sucursal_eeff],[codigo],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("s_sucursal_eeff_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_eeff", DbType.Int32, Id_eeff);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            public bool Actualizar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_sucursal_eeff_Actualizar");
                    db1.AddInParameter(cmd, "id_sucursal_eeff", DbType.Int32, _id_sucursal_eeff);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion

        }
    }
}