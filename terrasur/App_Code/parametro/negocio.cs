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
/// Summary description for negocio
/// </summary>
namespace terrasur
{
    public class negocio
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_negocio = 0;
        private string _codigo = "";
        private string _nombre = "";
        private bool _origen = false;

        //Propiedades públicas
        public int id_negocio { get { return _id_negocio; } set { _id_negocio = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool origen { get { return _origen; } set { _origen = value; } }
        #endregion

        #region Constructores
        public negocio(int Id_negocio)
        {
            _id_negocio = Id_negocio;
            RecuperarDatos();
        }
        public negocio(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_negocio],[codigo],[nombre],[origen]
            DbCommand cmd = db1.GetStoredProcCommand("negocio_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable Lista_por_origen(bool Origen)
        {
            //[id_negocio],[codigo],[nombre],[origen]
            DbCommand cmd = db1.GetStoredProcCommand("negocio_Lista_por_origen");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "origen", DbType.Boolean, Origen);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaTransferencia( int Id_contrato)
        {
            //[id_negocio],[codigo],[nombre],[origen]
            DbCommand cmd = db1.GetStoredProcCommand("negocio_ListaTransferencia");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaTraspaso(int Id_lote)
        {
            //[id_negocio],[codigo],[nombre],[origen]
            DbCommand cmd = db1.GetStoredProcCommand("negocio_ListaTraspaso");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_RecuperarDatos");
                db1.AddInParameter(cmd, "id_negocio0", DbType.Int32, _id_negocio);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_negocio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "origen", DbType.Boolean, 32);
                db1.ExecuteNonQuery(cmd);
                _id_negocio = (int)db1.GetParameterValue(cmd, "id_negocio");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _origen = (bool)db1.GetParameterValue(cmd, "origen");
            }
            catch { }
        }
        #endregion
    }
}