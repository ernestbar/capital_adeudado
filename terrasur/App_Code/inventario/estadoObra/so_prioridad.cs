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
        public class so_prioridad
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_prioridad = 0;
            private int _numero = 0;
            private string _codigo = "";
            private string _nombre = "";

            //Propiedades públicas
            public int id_prioridad { get { return _id_prioridad; } set { _id_prioridad = value; } }
            public int numero { get { return _numero; } set { _numero = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            #endregion

            #region Constructores
            public so_prioridad(int Id_prioridad)
            {
                _id_prioridad = Id_prioridad;
                RecuperarDatos();
            }
            public so_prioridad(int Numero,string Codigo)
            {
                _numero = Numero;
                _codigo = Codigo;
                RecuperarDatos();
            }

            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_prioridad],[numero],[codigo],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("so_prioridad_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_prioridad_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_prioridad0", DbType.Int32, _id_prioridad);
                    db1.AddInParameter(cmd, "numero0", DbType.Int32, _numero);
                    db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                    db1.AddOutParameter(cmd, "id_prioridad", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "numero", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "codigo", DbType.String, 10);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 30);

                    db1.ExecuteNonQuery(cmd);

                    _id_prioridad = (int)db1.GetParameterValue(cmd, "id_prioridad");
                    _numero = (int)db1.GetParameterValue(cmd, "numero");
                    _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                    _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                }
                catch { }
            }

            #endregion
        }
    }
}