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
/// <summary>
/// Summary description for capital_adeudado_urbanizacion
/// </summary>
namespace terrasur
{
    public class capital_adeudado_urbanizacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_urbanizacion = 0;
        private string _nombre_urbanizacion = "";

        //Propiedades públicas
        public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
        public string nombre_urbanizacion { get { return _nombre_urbanizacion; } set { _nombre_urbanizacion = value; } }

        #endregion

        #region Constructores
        public capital_adeudado_urbanizacion(int Id_urbanizacion)
        {
            _id_urbanizacion = Id_urbanizacion;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_urbanizacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_urbanizacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                db1.AddOutParameter(cmd, "nombre_urbanizacion", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);

                _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                _nombre_urbanizacion = (string)db1.GetParameterValue(cmd, "nombre_urbanizacion");
            }
            catch { }
        }

        public bool Insertar(int Id_urbanizacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_Insertar");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                _id_urbanizacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }


        public bool Eliminar(int Id_urbanizacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_urbanizacion_Eliminar");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}