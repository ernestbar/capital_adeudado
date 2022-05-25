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
/// Summary description for negocio_contrato
/// </summary>
namespace terrasur
{
    public class negocio_contrato
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_negociocontrato = 0;
        private int _id_negocio = 0;
        private int _id_contrato = 0;
        private int _id_usuario = 0;
        private int _id_negociolote = 0;
        private int _id_pago = 0;
        private int _id_reversion = 0;
        private DateTime _fecha = DateTime.Now;
        private decimal _saldo_capital = 0;
        private decimal _saldo_costo = 0;
        private bool _anulado = false;

        private string _negocio_nombre = "";
        private string _negocio_codigo = "";
        private decimal _suma_amortizacion = 0;
        private int _num_pagos = 0;

        //Propiedades públicas
        public int id_negociocontrato { get { return _id_negociocontrato; } set { _id_negociocontrato = value; } }
        public int id_negocio { get { return _id_negocio; } set { _id_negocio = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int id_negociolote { get { return _id_negociolote; } set { _id_negociolote = value; } }
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public int id_reversion { get { return _id_reversion; } set { _id_reversion = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public decimal saldo_capital { get { return _saldo_capital; } set { _saldo_capital = value; } }
        public decimal saldo_costo { get { return _saldo_costo; } set { _saldo_costo = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }

        public string negocio_nombre { get { return _negocio_nombre; } }
        public string negocio_codigo { get { return _negocio_codigo; } }
        public decimal suma_amortizacion { get { return _suma_amortizacion; } }
        public int num_pagos { get { return _num_pagos; } }
        #endregion

        #region Constructores
        public negocio_contrato(int Id_negociocontrato)
        {
            _id_negociocontrato = Id_negociocontrato;
            RecuperarDatos();
        }
        public negocio_contrato(int Id_negocio, int Id_contrato, int Id_negociolote, decimal Precio_final, decimal Costo_total)
        {
            _id_negocio = Id_negocio;
            _id_contrato = Id_contrato;
            _id_negociolote = Id_negociolote;
            _saldo_capital = Precio_final;
            _saldo_costo = Costo_total;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Anular(int Id_negociocontrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_contrato_Anular");
                db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, Id_negociocontrato);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static string CodigoNegocioPorContrato(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_contrato_CodigoNegocioPorContrato");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteScalar(cmd).ToString();
            }
            catch { return ""; }
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_contrato_RecuperarDatos");
                db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, _id_negociocontrato);
                db1.AddOutParameter(cmd, "id_negocio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_negociolote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_pago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_reversion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "saldo_capital", DbType.Double, 14);
                db1.AddOutParameter(cmd, "saldo_costo", DbType.Double, 14);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "negocio_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "negocio_codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "suma_amortizacion", DbType.Double, 14);
                db1.AddOutParameter(cmd, "num_pagos", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);

                _id_negocio = (int)db1.GetParameterValue(cmd, "id_negocio");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _id_negociolote = (int)db1.GetParameterValue(cmd, "id_negociolote");
                _id_pago = (int)db1.GetParameterValue(cmd, "id_pago");
                _id_reversion = (int)db1.GetParameterValue(cmd, "id_reversion");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _saldo_capital = (decimal)(double)db1.GetParameterValue(cmd, "saldo_capital");
                _saldo_costo = (decimal)(double)db1.GetParameterValue(cmd, "saldo_costo");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");

                _negocio_nombre = (string)db1.GetParameterValue(cmd, "negocio_nombre");
                _negocio_codigo = (string)db1.GetParameterValue(cmd, "negocio_codigo");
                _suma_amortizacion = (decimal)(double)db1.GetParameterValue(cmd, "suma_amortizacion");
                _num_pagos = (int)db1.GetParameterValue(cmd, "num_pagos");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_contrato_Insertar");
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, _id_negocio);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, _id_negociolote);
                db1.AddInParameter(cmd, "saldo_capital", DbType.Decimal, _saldo_capital);
                db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, _saldo_costo);
                _id_negociocontrato = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        public bool Revertir(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_contrato_Revertir");
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, _id_negocio);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, _id_negociolote);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.AddInParameter(cmd, "id_reversion", DbType.Int32,_id_reversion);
                db1.AddInParameter(cmd, "saldo_capital", DbType.Decimal, _saldo_capital);
                db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, _saldo_costo);
                _id_negociocontrato = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}