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
/// Summary description for legal_estado_tramite
/// </summary>
namespace terrasur
{
    public class legal_estado_tramite
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_estadotramite = 0;
        private string _codigo = "";
        private string _nombre = "";
        private int _orden = 0;

        //Propiedades públicas
        public int id_estadotramite { get { return _id_estadotramite; } set { _id_estadotramite = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int orden { get { return _orden; } set { _orden = value; } }

        #endregion

        #region Constructores
        public legal_estado_tramite(int Id_estadotramite)
        {
            _id_estadotramite = Id_estadotramite;
            RecuperarDatos();
        }
        public legal_estado_tramite(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_estadotramite],[codigo],[nombre],[orden]
            DbCommand cmd = db1.GetStoredProcCommand("legal_estado_tramite_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_estado_tramite_RecuperarDatos");
                db1.AddInParameter(cmd, "id_estadotramite0", DbType.Int32, _id_estadotramite);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_estadotramite", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                db1.AddOutParameter(cmd, "orden", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _id_estadotramite = (int)db1.GetParameterValue(cmd, "id_estadotramite");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _orden = (int)db1.GetParameterValue(cmd, "orden");
            }
            catch { }
        }
       #endregion
    }
}