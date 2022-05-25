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
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de contrato_especial_nafibo
/// </summary>
namespace terrasur
{
    public class contrato_especial_nafibo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_contrato = 0;
        private decimal _cuota_base = 0;
        private decimal _cuota_frecuente = 0;
        private DateTime _fecha = DateTime.Now;
        private int _id_usuario = 0;
        private string _observacion = "";

        private string _num_contrato = "";
        
        //Propiedades públicas
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public decimal cuota_base { get { return _cuota_base; } set { _cuota_base = value; } }
        public decimal cuota_frecuente { get { return _cuota_frecuente; } set { _cuota_frecuente = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string observacion { get { return _observacion; } set { _observacion = value; } }

        public string num_contrato { get { return _num_contrato; } }
        #endregion

        #region Constructores
        public contrato_especial_nafibo(int Id_contrato)
        {
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }
        public contrato_especial_nafibo(string Num_contrato)
        {
            _num_contrato = Num_contrato;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_contrato],[num_contrato],[lote],[cuota_base],[cuota_frecuente]
            DbCommand cmd = db1.GetStoredProcCommand("contrato_especial_nafibo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool Verificar(int Id_Contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_especial_nafibo_Verificar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_Contrato);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, "");
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        public static bool Verificar(string Num_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_especial_nafibo_Verificar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, 0);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_especial_nafibo_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato0", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "num_contrato0", DbType.String, _num_contrato);

                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "cuota_base", DbType.Double, 50);
                db1.AddOutParameter(cmd, "cuota_frecuente", DbType.Double, 50);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "observacion", DbType.String, 100);

                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 20);

                db1.ExecuteNonQuery(cmd);

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _cuota_base = (decimal)(double)db1.GetParameterValue(cmd, "cuota_base");
                _cuota_frecuente = (decimal)(double)db1.GetParameterValue(cmd, "cuota_frecuente");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _observacion = (string)db1.GetParameterValue(cmd, "observacion");

                _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
            }
            catch { }
        }
        #endregion
    }
}