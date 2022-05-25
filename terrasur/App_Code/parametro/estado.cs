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
/// Summary description for estado
/// </summary>
namespace terrasur
{
    public class estado
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_estado = 0;
        private string _codigo = "";
        private string _nombre = "";
        private int _horas_limite = 0;
        private bool _vendible = false;
        private bool _permitir_cambiar = false;

        //Propiedades públicas
        public int id_estado { get { return _id_estado; } set { _id_estado = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int horas_limite { get { return _horas_limite; } set { _horas_limite = value; } }
        public bool vendible { get { return _vendible; } set { _vendible = value; } }
        public bool permitir_cambiar { get { return _permitir_cambiar; } set { _permitir_cambiar = value; } }
        #endregion

        #region Constructores
        public estado(int Id_estado)
        {
            _id_estado = Id_estado;
            RecuperarDatos();
        }
        public estado(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_estado],[codigo],[nombre],[horas_limite],[vendible],[permitir_cambiar]
            DbCommand cmd = db1.GetStoredProcCommand("estado_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_cambiar()
        {
            //[id_estado],[codigo],[nombre],[horas_limite],[vendible],[permitir_cambiar]
            DbCommand cmd = db1.GetStoredProcCommand("estado_Lista_cambiar");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("estado_RecuperarDatos");
                db1.AddInParameter(cmd, "id_estado0", DbType.Int32, _id_estado);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "horas_limite", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "vendible", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "permitir_cambiar", DbType.Boolean, 32);
                db1.ExecuteNonQuery(cmd);
                _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _horas_limite = (int)db1.GetParameterValue(cmd, "horas_limite");
                _vendible = (bool)db1.GetParameterValue(cmd, "vendible");
                _permitir_cambiar = (bool)db1.GetParameterValue(cmd, "permitir_cambiar");
            }
            catch { }
        }
        #endregion
    }
}