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
/// Summary description for amortizacion_capital_adeudado
/// </summary>
namespace terrasur
{
    public class amortizacion_capital_adeudado
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_amortizacioncapitaladeudado = 0;
        private int _id_capitaladeudado = 0;
        private int _id_usuario = 0;
        private int _id_transaccion = 0;
        private decimal _monto = 0;
        private decimal _saldo = 0;
        private DateTime _fecha = DateTime.Now;
        private bool _anulado = true;
        private int _anulado_id_usuario = 0;
        private DateTime _anulado_fecha = DateTime.Now;

        //Propiedades públicas
        public int id_amortizacioncapitaladeudado { get { return _id_amortizacioncapitaladeudado; } set { _id_amortizacioncapitaladeudado = value; } }
        public int id_capitaladeudado { get { return _id_capitaladeudado; } set { _id_capitaladeudado = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public decimal monto { get { return _monto; } set { _monto = value; } }
        public decimal saldo { get { return _saldo; } set { _saldo = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }
        public int anulado_id_usuario { get { return _anulado_id_usuario; } set { _anulado_id_usuario = value; } }
        public DateTime anulado_fecha { get { return _anulado_fecha; } set { _anulado_fecha = value; } }

        #endregion

        #region Constructores
        public amortizacion_capital_adeudado(int Id_amortizacioncapitaladeudado)
        {
            _id_amortizacioncapitaladeudado = Id_amortizacioncapitaladeudado;
            RecuperarDatos();
        }

        public amortizacion_capital_adeudado(int Id_capitaladeudado, int Id_usuario, int Id_transaccion, decimal Monto, decimal Saldo, DateTime Fecha, bool Anulado, int Anulado_id_usuario, DateTime Anulado_fecha)
        {
            _id_capitaladeudado = Id_capitaladeudado;
            _id_usuario = Id_usuario;
            _id_transaccion = Id_transaccion;
            _monto = Monto;
            _saldo = Saldo;
            _fecha = Fecha;
            _anulado = Anulado;
            _anulado_id_usuario = Anulado_id_usuario;
            _anulado_fecha = Anulado_fecha;
        }

        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorContrato()
        {
            DbCommand cmd = db1.GetStoredProcCommand("amortizacion_capital_adeudado_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("amortizacion_capital_adeudado_RecuperarDatos");
                db1.AddInParameter(cmd, "id_amortizacioncapitaladeudado", DbType.Int32, _id_amortizacioncapitaladeudado);
                db1.AddOutParameter(cmd, "id_capitaladeudado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto", DbType.Double, 14);
                db1.AddOutParameter(cmd, "saldo", DbType.Double, 14);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 1);
                db1.AddOutParameter(cmd, "anulado_id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "anulado_fecha", DbType.DateTime, 200);
                db1.ExecuteNonQuery(cmd);

                _id_capitaladeudado = (int)db1.GetParameterValue(cmd, "id_capitaladeudado");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                _monto = (decimal)(double)db1.GetParameterValue(cmd, "monto");
                _saldo = (decimal)(double)db1.GetParameterValue(cmd, "saldo");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");
                _anulado_id_usuario = (int)db1.GetParameterValue(cmd, "anulado_id_usuario");
                _anulado_fecha = (DateTime)db1.GetParameterValue(cmd, "anulado_fecha");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("amortizacion_capital_adeudado_Insertar");
                db1.AddInParameter(cmd, "id_capitaladeudado", DbType.Int32, _id_capitaladeudado);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                db1.AddInParameter(cmd, "saldo", DbType.Decimal, _saldo);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "anulado", DbType.Boolean, _anulado);
                db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, _anulado_fecha);

                _id_amortizacioncapitaladeudado = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }


        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("amortizacion_capital_adeudado_Actualizar");
                db1.AddInParameter(cmd, "id_amortizacioncapitaladeudado", DbType.Int32, _id_amortizacioncapitaladeudado);
                db1.AddInParameter(cmd, "id_capitaladeudado", DbType.Int32, _id_capitaladeudado);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                db1.AddInParameter(cmd, "saldo", DbType.Decimal, _saldo);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "anulado", DbType.Boolean, _anulado);
                db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, _anulado_fecha);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}