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
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Xml;
using System.Text;

/// <summary>
/// Descripción breve de so_tipoObra
/// </summary>
namespace terrasur
{
    namespace so
    {
        public class so_tipoObra
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_tipoobra = 0;
            private string _codigo = "";
            private string _nombre = "";
            private string _descripcion = "";

            //Propiedades públicas
            public int id_tipoobra { get { return _id_tipoobra; } set { _id_tipoobra = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            public string descripcion { get { return _descripcion; } set { _descripcion = value; } }
            #endregion

            #region Constructores
            public so_tipoObra(int Id_tipoobra)
            {
                _id_tipoobra = Id_tipoobra;
                _codigo = "";
                RecuperarDatos();
            }
            public so_tipoObra(string Codigo)
            {
                _id_tipoobra = 0;
                _codigo = Codigo;
                RecuperarDatos();
            }
            #endregion

            #region Métodos que NO requieren constructor
            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_tipoObra_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_tipoobra0", DbType.Int32, _id_tipoobra);
                    db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                    db1.AddOutParameter(cmd, "id_tipoobra", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "descripcion", DbType.String, 200);

                    db1.ExecuteNonQuery(cmd);
                    _id_tipoobra = (int)db1.GetParameterValue(cmd, "id_tipoobra");
                    _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                    _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                    _descripcion = (string)db1.GetParameterValue(cmd, "descripcion");
                }
                catch { }
            }

            public static DataTable Lista(int Id_manzano)
            {
                //[id_tipoobra],[codigo],[nombre],[descripcion]
                DbCommand cmd = db1.GetStoredProcCommand("so_tipoObra_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion
        }
    }
}