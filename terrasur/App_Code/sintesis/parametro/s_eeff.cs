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
/// Descripción breve de s_eeff
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_eeff
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_eeff = 0;
            private string _codigo = "";
            private string _nombre = "";
            
            //Propiedades públicas
            public int id_eeff { get { return _id_eeff; } set { _id_eeff = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            #endregion

            #region Constructores
            public s_eeff(int Id_eeff)
            {
                _id_eeff = Id_eeff;
                RecuperarDatos();
            }
            public s_eeff(int Id_eeff, string Nombre)
            {
                _id_eeff = Id_eeff;
                _nombre = Nombre;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_eeff],[codigo],[nombre],[num_sucursales]
                DbCommand cmd = db1.GetStoredProcCommand("s_eeff_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_eeff_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_eeff", DbType.Int32, _id_eeff);
                    db1.AddOutParameter(cmd, "codigo", DbType.String, 100);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 200);

                    db1.ExecuteNonQuery(cmd);

                    _codigo = db1.GetParameterValue(cmd, "codigo").ToString();
                    _nombre = db1.GetParameterValue(cmd, "nombre").ToString();
                }
                catch { }
            }

            public bool Actualizar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_eeff_Actualizar");
                    db1.AddInParameter(cmd, "id_eeff", DbType.Int32, _id_eeff);
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