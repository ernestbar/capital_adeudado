using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de tarjeta_credito_periodicidad
/// </summary>
namespace terrasur
{
    public class tarjeta_credito_periodicidad
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_periodicidad = 0;
        private int _codigo = 0;
        private string _nombre = "";
        private int _num_contratos = 0;

        //Propiedades públicas
        public int id_periodicidad { get { return _id_periodicidad; } set { _id_periodicidad = value; } }
        public int codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int num_contratos { get { return _num_contratos; } }
        #endregion

        #region Constructores
        public tarjeta_credito_periodicidad(int Id_periodicidad, int Codigo)
        {
            _id_periodicidad = Id_periodicidad;
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_periodicidad],[codigo],[nombre],[num_contratos]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_periodicidad_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_periodicidad_RecuperarDatos");
                db1.AddInParameter(cmd, "id_periodicidad0", DbType.Int32, _id_periodicidad);
                db1.AddInParameter(cmd, "codigo0", DbType.Int32, _codigo);
                db1.AddOutParameter(cmd, "id_periodicidad", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 20);
                db1.AddOutParameter(cmd, "num_contratos", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _id_periodicidad = (int)db1.GetParameterValue(cmd, "id_periodicidad");
                _codigo = (int)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _num_contratos = (int)db1.GetParameterValue(cmd, "num_contratos");
            }
            catch { }
        }
        #endregion
    }
}