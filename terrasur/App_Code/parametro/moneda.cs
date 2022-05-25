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
/// Summary description for moneda
/// </summary>
namespace terrasur
{
    public class moneda
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_moneda = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public moneda(int Id_moneda)
        {
            _id_moneda = Id_moneda;
            RecuperarDatos();
        }
        public moneda(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_moneda],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("moneda_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("moneda_RecuperarDatos");
                db1.AddInParameter(cmd, "id_moneda0", DbType.Int32, _id_moneda);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_moneda", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_moneda = (int)db1.GetParameterValue(cmd, "id_moneda");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion
    }
}