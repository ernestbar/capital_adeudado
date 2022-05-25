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
/// Summary description for pago_mora
/// </summary>
/// 
namespace terrasur
{
    public class pago_mora
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        // Propiedades privadas
        private int _id_pagomora = 0;
        private int _id_pago = 0;
        private int _id_transaccion = 0;
        private DateTime _fecha = DateTime.Now;
        private int _num_dias = 0;
        private int _num_cuotas = 0;
        private decimal _monto_pagar = 0;
        private decimal _monto_pagado = 0;
        
        // Propiedades públicas
        public int id_pagomora { get { return _id_pagomora; } set { _id_pagomora = value; } }
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int num_dias { get { return _num_dias; } set { _num_dias = value; } }
        public int num_cuotas { get { return _num_cuotas; } set { _num_cuotas = value; } }
        public decimal monto_pagar { get { return _monto_pagar; } set { _monto_pagar = value; } }
        public decimal monto_pagado { get { return _monto_pagado; } set { _monto_pagado = value; } }
        
        #endregion

        #region Constructores
        public pago_mora(int Id_pagomora)
        {
            _id_pagomora = Id_pagomora;
            RecuperarDatos();
        }
        public pago_mora(int Id_pago, int Id_transaccion, int Num_dias, int Num_cuotas, decimal Monto_pagar, decimal Monto_pagado)
        {
            _id_pago = Id_pago;
            _id_transaccion = Id_transaccion;
            _num_dias = Num_dias;
            _num_cuotas = Num_cuotas;
            _monto_pagar = Monto_pagar;
            _monto_pagado = Monto_pagado;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorContrato(int Id_contrato)
        {
            //[id_pagomora],[id_pago],[id_transferencia],[fecha],[num_dias],[num_cuotas],[monto_pagar],[monto_pagado]
            DbCommand cmd = db1.GetStoredProcCommand("pago_mora_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int DiasMoraPorContrato(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_mora_DiasMoraPorContrato");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int IdPorTransaccion(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_mora_IdPorTransaccion");
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static int InsertarPago(int context_id_usuario, int context_id_rol, int Id_contrato, int Id_recibocobrador,
    tmpFormaPago tfp, string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                //Se registra: la transacción, la factura, el beneficiario, el recibo, el comprobante, el pago de mora
                DbCommand cmd = db1.GetStoredProcCommand("pago_mora_InsertarPago");
                db1.AddInParameter(cmd, "p_id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "p_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "p_id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "p_id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "p_id_recibocobrador", DbType.Int32, Id_recibocobrador);

                db1.AddInParameter(cmd, "p_monto", DbType.Decimal, tfp.monto);
                db1.AddInParameter(cmd, "p_forma_dpr", DbType.Boolean, tfp.dpr);

                db1.AddInParameter(cmd, "p_cliente_nombre", DbType.String, Cliente_nombre);
                db1.AddInParameter(cmd, "p_cliente_nit", DbType.Decimal, Cliente_nit);
                db1.AddInParameter(cmd, "p_cliente_guardar", DbType.Boolean, Cliente_guardar);

                db1.AddOutParameter(cmd, "p_id_transaccion", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                int Id_transaccion = (int)db1.GetParameterValue(cmd, "p_id_transaccion");
                if (Id_transaccion > 0)
                {
                    if (new forma_pago(Id_transaccion, tfp).Insertar() == true) return Id_transaccion;
                    else return 0;
                }
                else return 0;
            }
            catch { return 0; }
        }
        public static bool PermitirAnular(int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_mora_PermitirAnular");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static bool Anular(int Id_pago_mora, int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_mora_Anular");
                db1.AddInParameter(cmd, "id_pago_mora", DbType.Int32, Id_pago_mora);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_mora_RecuperarDatos");
                db1.AddInParameter(cmd, "id_pagomora", DbType.Int32, _id_pagomora);
                db1.AddOutParameter(cmd, "id_pago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "num_dias", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_cuotas", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto_pagar", DbType.Double, 14);
                db1.AddOutParameter(cmd, "monto_pagado", DbType.Double, 14);
                
                db1.ExecuteNonQuery(cmd);

                _id_pago = (int)db1.GetParameterValue(cmd, "id_pago");
                _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _num_dias = (int)db1.GetParameterValue(cmd, "num_dias");
                _num_cuotas = (int)db1.GetParameterValue(cmd, "num_cuotas");
                _monto_pagar = (decimal)(double)db1.GetParameterValue(cmd, "monto_pagar");
                _monto_pagado = (decimal)(double)db1.GetParameterValue(cmd, "monto_pagado");
            }
            catch { }
        }
        #endregion
    }
}