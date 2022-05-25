using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de tipo_tarjeta_credito
/// </summary>
namespace terrasur
{
    public class tipo_tarjeta_credito
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_tipotarjetacredito = 0;
        private string _codigo = "";
        private string _nombre = "";
        private int _num_tarjetas = 0;

        //Propiedades públicas
        public int id_tipotarjetacredito { get { return _id_tipotarjetacredito; } set { _id_tipotarjetacredito = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int num_tarjetas { get { return _num_tarjetas; } }
        #endregion

        #region Constructores
        public tipo_tarjeta_credito(int Id_tipotarjetacredito)
        {
            _id_tipotarjetacredito = Id_tipotarjetacredito;
            RecuperarDatos();
        }
        public tipo_tarjeta_credito(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_tipotarjetacredito],[codigo],[nombre],[num_tarjetas]
            DbCommand cmd = db1.GetStoredProcCommand("tipo_tarjeta_credito_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tipo_tarjeta_credito_RecuperarDatos");
                db1.AddInParameter(cmd, "id_tipotarjetacredito0", DbType.Int32, _id_tipotarjetacredito);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_tipotarjetacredito", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 10);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 20);
                db1.AddOutParameter(cmd, "num_tarjetas", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _id_tipotarjetacredito = (int)db1.GetParameterValue(cmd, "id_tipotarjetacredito");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _num_tarjetas = (int)db1.GetParameterValue(cmd, "num_tarjetas");
            }
            catch { }
        }
        #endregion

    }
}