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
/// Summary description for motivo_bloqueo
/// </summary>
namespace terrasur
{
    public class motivo_bloqueo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_motivobloqueo = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_motivobloqueo { get { return _id_motivobloqueo; } set { _id_motivobloqueo = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public motivo_bloqueo(int Id_motivobloqueo)
        {
            _id_motivobloqueo = Id_motivobloqueo;
            RecuperarDatos();
        }
        public motivo_bloqueo(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_motivobloqueo],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("motivo_bloqueo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool AsociarMotivoBloqueoConEstadoLote(int Id_estadolote, int Id_motivobloqueo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("motivo_bloqueo_AsociarMotivoBloqueoConEstadoLote");
                db1.AddInParameter(cmd, "id_estadolote", DbType.Int32, Id_estadolote);
                db1.AddInParameter(cmd, "id_motivobloqueo", DbType.Int32, Id_motivobloqueo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("motivo_bloqueo_RecuperarDatos");
                db1.AddInParameter(cmd, "id_motivobloqueo0", DbType.Int32, _id_motivobloqueo);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_motivobloqueo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_motivobloqueo = (int)db1.GetParameterValue(cmd, "id_motivobloqueo");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion

    }
}