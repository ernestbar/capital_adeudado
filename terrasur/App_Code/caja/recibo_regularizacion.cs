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
/// Summary description for recibo
/// </summary>
namespace terrasur
{
    public class recibo_regularizacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_reciboregularizacion = 0;
        private int _id_contrato = 0;
        private DateTime _fecha;
        private decimal _monto_sus = 0;
        private string _concepto = "";
        private string _cliente = "";

        private string _num_contrato = "";
        private string _lote = "";
        private string _promotor = "";

        //Propiedades públicas
        public int id_reciboregularizacion { get { return _id_reciboregularizacion; } set { _id_reciboregularizacion = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public decimal monto_sus { get { return _monto_sus; } set { _monto_sus = value; } }
        public string concepto { get { return _concepto; } set { _concepto = value; } }
        public string cliente { get { return _cliente; } set { _cliente = value; } }

        public string num_contrato { get { return _num_contrato; } }
        public string lote { get { return _lote; } }
        public string promotor { get { return _promotor; } }
        #endregion

        #region Constructores
        public recibo_regularizacion(int Id_reciboregularizacion)
        {
            _id_reciboregularizacion = Id_reciboregularizacion;
            RecuperarDatos();
        }
        public recibo_regularizacion(int Id_contrato, DateTime Fecha, decimal Monto_sus, string Concepto, string Cliente)
        {
            _id_contrato = Id_contrato;
            _fecha = Fecha;
            _monto_sus = Monto_sus;
            _concepto = Concepto;
            _cliente = Cliente;
        }
        public recibo_regularizacion(int Id_reciboregularizacion, int Id_contrato, DateTime Fecha, decimal Monto_sus, string Concepto, string Cliente)
        {
            _id_reciboregularizacion = Id_reciboregularizacion;
            _id_contrato = Id_contrato;
            _fecha = Fecha;
            _monto_sus = Monto_sus;
            _concepto = Concepto;
            _cliente = Cliente;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string Num_contrato)
        {
            //[id_reciboregularizacion],[num_contrato],[lote],[fecha],[monto_sus],[concepto],[cliente]
            DbCommand cmd = db1.GetStoredProcCommand("recibo_regularizacion_Lista");
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_regularizacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_reciboregularizacion", DbType.Int32, _id_reciboregularizacion);

                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "monto_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "concepto", DbType.String, 100);
                db1.AddOutParameter(cmd, "cliente", DbType.String, 100);

                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 20);
                db1.AddOutParameter(cmd, "lote", DbType.String, 100);
                db1.AddOutParameter(cmd, "promotor", DbType.String, 100);

                db1.ExecuteNonQuery(cmd);

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _monto_sus = (decimal)(double)db1.GetParameterValue(cmd, "monto_sus");
                _concepto = (string)db1.GetParameterValue(cmd, "concepto");
                _cliente = (string)db1.GetParameterValue(cmd, "cliente");

                _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                _lote = (string)db1.GetParameterValue(cmd, "lote");
                _promotor = (string)db1.GetParameterValue(cmd, "promotor");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_regularizacion_Insertar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                db1.AddInParameter(cmd, "concepto", DbType.String, _concepto);
                db1.AddInParameter(cmd, "cliente", DbType.String, _cliente);

                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_reciboregularizacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_regularizacion_Actualizar");
                db1.AddInParameter(cmd, "id_reciboregularizacion", DbType.Int32, _id_reciboregularizacion);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                db1.AddInParameter(cmd, "concepto", DbType.String, _concepto);
                db1.AddInParameter(cmd, "cliente", DbType.String, _cliente);

                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
       
        #endregion
    }
}