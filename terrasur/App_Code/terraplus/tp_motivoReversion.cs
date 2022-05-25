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
/// Descripción breve de tp_motivoReversion
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_motivoReversion
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_motivoreversion = 0;
            private string _codigo = "";
            private string _nombre = "";

            //Propiedades públicas
            public int id_motivoreversion { get { return _id_motivoreversion; } set { _id_motivoreversion = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            #endregion

            #region Constructores
            public tp_motivoReversion(int Id_motivoreversion)
            {
                _id_motivoreversion = Id_motivoreversion;
                _codigo = "";
                RecuperarDatos();
            }
            public tp_motivoReversion(string Codigo)
            {
                _id_motivoreversion = 0;
                _codigo = Codigo;
                RecuperarDatos();
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_motivoreversion],[codigo],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("tp_motivoReversion_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_motivoReversion_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_motivoreversion0", DbType.Int32, _id_motivoreversion);
                    db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                    db1.AddOutParameter(cmd, "id_motivoreversion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_motivoreversion = (int)db1.GetParameterValue(cmd, "id_motivoreversion");
                    _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                    _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                }
                catch { }
            }


            #endregion
        }
    }
}