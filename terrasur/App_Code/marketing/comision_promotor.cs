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
/// Summary description for comision_promotor
/// </summary>
namespace terrasur
{
    public class comision_promotor
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupopromotor = 0;
        private int _id_contrato = 0;
        private int _id_usuario = 0;
        private int _id_pago = 0;
        private int _numero = 0;
        private decimal _monto = 0;

        //Propiedades públicas
        public int id_grupopromotor { get { return _id_grupopromotor; } set { _id_grupopromotor = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public int numero { get { return _numero; } set { _numero = value; } }
        public decimal monto { get { return _monto; } set { _monto = value; } }
        #endregion

        #region Constructores
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorContrato(int Id_contrato)
        {//[id_grupopromotor],[id_usuario],[numero],[monto],[fecha],[monto_pago],[tipo_pago],[promotor]
            DbCommand cmd = db1.GetStoredProcCommand("comision_promotor_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static decimal TotalComisionado(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("comision_promotor_TotalComisionado");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            db1.AddOutParameter(cmd, "total", DbType.Double, 14);
            db1.ExecuteNonQuery(cmd);
            return (decimal)(double)db1.GetParameterValue(cmd, "total");
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}
