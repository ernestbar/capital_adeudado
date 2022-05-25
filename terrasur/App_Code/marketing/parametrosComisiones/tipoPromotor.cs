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
/// Descripción breve de tipoPromotor
/// </summary>
namespace terrasur
{
    public class tipoPromotor
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_tipopromotor = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_tipopromotor { get { return _id_tipopromotor; } set { _id_tipopromotor = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public tipoPromotor(int Id_tipopromotor)
        {
            _id_tipopromotor = Id_tipopromotor;
            _codigo = "";
            RecuperarDatos();
        }
        public tipoPromotor(string Codigo)
        {
            _id_tipopromotor = 0;
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_tipopromotor],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("tipoPromotor_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_ParametrosComisionPromotor()
        {
            //[tipo_inmueble],[tipo_promotor],
            //[porcent_cuo_ini_menor50],[porcent_cuo_ini_menor100],[porcent_cuo_ini_igual100]
            //[com_ini_porcent_cuo_ini],[com_ini_porcent_comision],[com_num_adicional]
            DbCommand cmd = db1.GetStoredProcCommand("tipoPromotor_Lista_ParametrosComisionPromotor");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_ParametrosArrastreInmuebles()
        {
            //[tipo_inmueble],[num_arrastre],[porcent_arrastre],[porcent_capital]
            DbCommand cmd = db1.GetStoredProcCommand("tipoPromotor_Lista_ParametrosArrastreInmuebles");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tipoPromotor_RecuperarDatos");
                db1.AddInParameter(cmd, "id_tipopromotor0", DbType.Int32, _id_tipopromotor);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_tipopromotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 40);
                db1.ExecuteNonQuery(cmd);
                _id_tipopromotor = (int)db1.GetParameterValue(cmd, "id_tipopromotor");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion

    }
}