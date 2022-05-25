using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;


/// <summary>
/// Descripción breve de tarjeta_credito_error
/// </summary>
namespace terrasur
{
    public class tarjeta_credito_error
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_tarjetacreditoerror = 0;
        private string _codigo = "";
        private string _nombre = "";
        private int _num_transacciones = 0;

        //Propiedades públicas
        public int id_tarjetacreditoerror { get { return _id_tarjetacreditoerror; } set { _id_tarjetacreditoerror = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int num_transacciones { get { return _num_transacciones; } }
        #endregion

        #region Constructores
        public tarjeta_credito_error(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_tarjetacreditoerror],[codigo],[nombre],[num_transacciones]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_error_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_error_RecuperarDatos");
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_tarjetacreditoerror", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                db1.AddOutParameter(cmd, "num_transacciones", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _id_tarjetacreditoerror = (int)db1.GetParameterValue(cmd, "id_tarjetacreditoerror");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _num_transacciones = (int)db1.GetParameterValue(cmd, "num_transacciones");
            }
            catch { }
        }

        #endregion
    }
}