using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de pago_especial_nafibo
/// </summary>
namespace terrasur
{
    public class pago_especial_nafibo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_pago = 0;
        private decimal _monto_pago = 0;
        private decimal _amortizacion = 0;
        private decimal _interes = 0;
        private decimal _saldo = 0;
        private DateTime _interes_fecha = DateTime.Now;

        //Propiedades públicas
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public decimal monto_pago { get { return _monto_pago; } set { _monto_pago = value; } }
        public decimal amortizacion { get { return _amortizacion; } set { _amortizacion = value; } }
        public decimal interes { get { return _interes; } set { _interes = value; } }
        public decimal saldo { get { return _saldo; } set { _saldo = value; } }
        public DateTime interes_fecha { get { return _interes_fecha; } set { _interes_fecha = value; } }
        #endregion

        #region Constructores
        public pago_especial_nafibo(int Id_pago)
        {
            _id_pago = Id_pago;
            RecuperarDatos();
        }

        public pago_especial_nafibo(int Id_pago, decimal Monto_pago, decimal Amortizacion, decimal Interes, decimal Saldo, DateTime Interes_fecha)
        {
            _id_pago = Id_pago;
            _monto_pago = Monto_pago;
            _amortizacion = Amortizacion;
            _interes = Interes;
            _saldo = Saldo;
            _interes_fecha = Interes_fecha;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(DateTime Fecha_inicio, DateTime Fecha_fin, string Num_contrato, string Orden)
        {
            //@orden: num_contrato, fecha_pago
            if (Num_contrato == null) Num_contrato = "";
            //[id_pago],[num_contrato],[fecha],[monto_pago],[interes],[amortizacion],[saldo],[interes_fecha], [permitir_ajustar],[permitir_deshacer]
            //[fuera_hora],[e_monto_pago],[e_interes],[e_amortizacion],[e_saldo],[e_interes_fecha],[diferencia]
            DbCommand cmd = db1.GetStoredProcCommand("pago_especial_nafibo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "orden", DbType.String, Orden);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool Verificar(int Id_pago)
        {
            DbCommand cmd = db1.GetStoredProcCommand("pago_especial_nafibo_Verificar");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_pago", DbType.Int32, Id_pago);
            if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
            else { return false; }
        }

        public static int AnteriorPago(int Id_pago)
        {
            DbCommand cmd = db1.GetStoredProcCommand("pago_especial_nafibo_AnteriorPago");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_pago", DbType.Int32, Id_pago);
            return (int)db1.ExecuteScalar(cmd);
        }

        public static bool Ajustar(int Id_pago, int Context_id_usuario)
        {
            bool correcto = false;
            if (pago_especial_nafibo.Verificar(Id_pago) == false)
            {
                int Id_pago_anterior = AnteriorPago(Id_pago);
                if (pago_especial_nafibo.Verificar(Id_pago_anterior) == true)
                {
                    //Se recuperan los datos del pago anterior
                    pago_especial_nafibo pEspAntObj = new pago_especial_nafibo (Id_pago_anterior);
                    
                    sim_pago pAntSimObj = new sim_pago(Id_pago_anterior);
                    pAntSimObj.monto_pago = pEspAntObj.monto_pago;
                    pAntSimObj.interes = pEspAntObj.interes;
                    pAntSimObj.amortizacion = pEspAntObj.amortizacion;
                    pAntSimObj.saldo = pEspAntObj.saldo;
                    pAntSimObj.interes_fecha = pEspAntObj.interes_fecha;

                    //Se recupera el pago sin ajustes
                    pago pObj = new pago(Id_pago);
                    plan_pago ppObj = new plan_pago(pObj.id_planpago);

                    //Se recuperan los datos del contrato_especial
                    contrato_especial_nafibo cenObj = new contrato_especial_nafibo(pObj.id_contrato);

                    //Se determina el Monto y la fecha de pago
                    decimal Monto_pago = pObj.monto_pago;
                    if (Monto_pago < cenObj.cuota_base) Monto_pago = cenObj.cuota_base;
                    DateTime Fecha_pago = pObj.fecha;
                    if (pObj.interes_dias_total < pObj.interes_dias) Fecha_pago = pObj.fecha.AddDays(Convert.ToDouble(pObj.interes_dias - pObj.interes_dias_total));

                    //Se generan los datos del nuevo pago ajustado
                    sim_pago nuevo_pago = new sim_pago(pAntSimObj, Fecha_pago, Fecha_pago, Fecha_pago, Fecha_pago, 0,
                    Monto_pago, ppObj.fecha_inicio_plan, ppObj.seguro, ppObj.mantenimiento_sus, ppObj.interes_corriente);

                    //Se registran los datos del Pago Especial Nafibo
                    pago_especial_nafibo penObj = new pago_especial_nafibo(pObj.id_pago, nuevo_pago.monto_pago, nuevo_pago.amortizacion, nuevo_pago.interes, nuevo_pago.saldo, nuevo_pago.interes_fecha);
                    return penObj.Registrar(Context_id_usuario);
                }
            }
            return correcto;
        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_especial_nafibo_RecuperarDatos");
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.AddOutParameter(cmd, "monto_pago", DbType.Double, 14);
                db1.AddOutParameter(cmd, "amortizacion", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes", DbType.Double, 14);
                db1.AddOutParameter(cmd, "saldo", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes_fecha", DbType.DateTime, 32);

                db1.ExecuteNonQuery(cmd);

                _monto_pago = (decimal)(double)db1.GetParameterValue(cmd, "monto_pago");
                _amortizacion = (decimal)(double)db1.GetParameterValue(cmd, "amortizacion");
                _interes = (decimal)(double)db1.GetParameterValue(cmd, "interes");
                _saldo = (decimal)(double)db1.GetParameterValue(cmd, "saldo");
                _interes_fecha = (DateTime)db1.GetParameterValue(cmd, "interes_fecha");
            }
            catch { }
        }

        protected bool Registrar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_especial_nafibo_Registrar");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.AddInParameter(cmd, "monto_pago", DbType.Decimal, _monto_pago);
                db1.AddInParameter(cmd, "amortizacion", DbType.Decimal, _amortizacion);
                db1.AddInParameter(cmd, "interes", DbType.Decimal, _interes);
                db1.AddInParameter(cmd, "saldo", DbType.Decimal, _saldo);
                db1.AddInParameter(cmd, "interes_fecha", DbType.DateTime, _interes_fecha);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Deshacer(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_especial_nafibo_Deshacer");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }


        #endregion
    }
}