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
/// Descripción breve de pagoEspecialNafibo
/// </summary>
namespace terrasur
{
    public class pagoEspecialNafibo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_pagoespecialnafibo = 0;
        private int _id_pago = 0;
        private int _id_pagonafibo = 0;

        private int _id_contrato = 0;
        private int _id_planpago = 0;

        private DateTime _fecha = DateTime.Now;
        private DateTime _interes_fecha = DateTime.Now;
        private DateTime _fecha_proximo = DateTime.Now;

        private decimal _monto_pago = 0;
        private decimal _interes = 0;
        private decimal _amortizacion = 0;
        private decimal _saldo = 0;

        //Propiedades públicas
        public int id_pagoespecialnafibo { get { return _id_pagoespecialnafibo; } set { _id_pagoespecialnafibo = value; } }
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public int id_pagonafibo { get { return _id_pagonafibo; } set { _id_pagonafibo = value; } }

        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_planpago { get { return _id_planpago; } set { _id_planpago = value; } }

        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public DateTime interes_fecha { get { return _interes_fecha; } set { _interes_fecha = value; } }
        public DateTime fecha_proximo { get { return _fecha_proximo; } set { _fecha_proximo = value; } }

        public decimal monto_pago { get { return _monto_pago; } set { _monto_pago = value; } }
        public decimal interes { get { return _interes; } set { _interes = value; } }
        public decimal amortizacion { get { return _amortizacion; } set { _amortizacion = value; } }
        public decimal saldo { get { return _saldo; } set { _saldo = value; } }
        #endregion

        #region Constructores
        public pagoEspecialNafibo(int Id_pagoespecialnafibo, int Id_pago, int Id_pagonafibo)
        {
            _id_pagoespecialnafibo = Id_pagoespecialnafibo;
            _id_pago = Id_pago;
            _id_pagonafibo = Id_pagonafibo;
            RecuperarDatos();
        }

        public pagoEspecialNafibo(int Id_pago, int Id_pagonafibo, int Id_contrato, int Id_planpago
            , DateTime Fecha, DateTime Interes_fecha, DateTime Fecha_proximo
            , decimal Monto_pago, decimal Interes, decimal Amortizacion, decimal Saldo)
        {
            _id_pago = Id_pago;
            _id_pagonafibo = Id_pagonafibo;

            _id_contrato = Id_contrato;
            _id_planpago = Id_planpago;

            _fecha = Fecha;
            _interes_fecha = Interes_fecha;
            _fecha_proximo = Fecha_proximo;

            _monto_pago = Monto_pago;
            _interes = Interes;
            _amortizacion = Amortizacion;
            _saldo = Saldo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(DateTime Fecha_inicio, DateTime Fecha_fin, string Num_contrato, string Orden)
        {
            //@orden: num_contrato, fecha_pago
            if (Num_contrato == null) Num_contrato = "";

            //[tipo],[id_pagoespecialnafibo],[id_pago],[id_pagonafibo],[id_contrato]
            //[num_contrato][fecha],[monto_pago],[interes],[amortizacion],[saldo],[interes_fecha]
            //[permitir_ajustar],[permitir_deshacer],[fuera_hora]
            //[e_monto_pago],[e_interes],[e_amortizacion],[e_saldo],[e_interes_fecha],[diferencia]

            DbCommand cmd = db1.GetStoredProcCommand("pagoEspecialNafibo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "orden", DbType.String, Orden);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool Verificar(int Id_pago, int Id_pagonafibo)
        {
            DbCommand cmd = db1.GetStoredProcCommand("pagoEspecialNafibo_Verificar");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_pago", DbType.Int32, Id_pago);
            db1.AddInParameter(cmd, "id_pagonafibo", DbType.Int32, Id_pagonafibo);
            if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
            else { return false; }
        }

        public static int UltimoPagoAjustado(int Id_pago, int Id_pagonafibo)
        {
            DbCommand cmd = db1.GetStoredProcCommand("pagoEspecialNafibo_UltimoPagoAjustado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_pago", DbType.Int32, Id_pago);
            db1.AddInParameter(cmd, "id_pagonafibo", DbType.Int32, Id_pagonafibo);
            return (int)db1.ExecuteScalar(cmd);
        }


        public static bool Ajustar(int Id_contrato, int Id_pago, int Id_pagonafibo, int Context_id_usuario)
        {
            bool correcto = false;
            if (pagoEspecialNafibo.Verificar(Id_pago, Id_pagonafibo) == false)
            {

                //Se recuperan los datos del pago anterior

                //Anterior pago especial
                int Id_pagoespecialnafibo_ultimo = UltimoPagoAjustado(Id_pago, Id_pagonafibo);
                pagoEspecialNafibo pEspUltObj = new pagoEspecialNafibo(Id_pagoespecialnafibo_ultimo, 0, 0);

                //Se construyen los datos del pago anterior
                sim_pago pAntSimObj = new sim_pago(contrato.UltimoPago(Id_contrato, DateTime.Now));
                pAntSimObj.fecha = pEspUltObj.fecha;
                pAntSimObj.fecha_proximo = pEspUltObj.fecha_proximo;
                pAntSimObj.interes_fecha = pEspUltObj.interes_fecha;

                pAntSimObj.monto_pago = pEspUltObj.monto_pago;
                pAntSimObj.interes = pEspUltObj.interes;
                pAntSimObj.amortizacion = pEspUltObj.amortizacion;
                pAntSimObj.saldo = pEspUltObj.saldo;

                if (Id_pago > 0)
                {
                    //Se recupera el pago sin ajustes
                    pago pObj = new pago(Id_pago);
                    plan_pago ppObj = new plan_pago(pObj.id_planpago);

                    //Se recuperan los datos del contrato_especial
                    contrato_especial_nafibo cenObj = new contrato_especial_nafibo(Id_contrato);

                    //Se determina el Monto
                    decimal Monto_pago = pObj.monto_pago;
                    if (Monto_pago < cenObj.cuota_base) Monto_pago = cenObj.cuota_base;
                    //Se determina Fecha de pago
                    DateTime Fecha_pago = pObj.fecha;
                    if (pObj.interes_dias_total < pObj.interes_dias) Fecha_pago = pObj.fecha.AddDays(Convert.ToDouble(pObj.interes_dias - pObj.interes_dias_total));
                    //Se determina Fecha de interés
                    DateTime Fecha_interes = Fecha_pago.Date;
                    if (pObj.interes_fecha.Date > Fecha_interes) { Fecha_interes = pObj.interes_fecha.Date; }

                    //Se generan los datos del nuevo pago ajustado
                    sim_pago nuevo_pago = new sim_pago(pAntSimObj, Fecha_pago, Fecha_pago, Fecha_pago, Fecha_interes, 0,
                    Monto_pago, ppObj.fecha_inicio_plan, ppObj.seguro, ppObj.mantenimiento_sus, ppObj.interes_corriente);

                    //Se registran los datos del Pago Especial Nafibo
                    pagoEspecialNafibo penObj = new pagoEspecialNafibo(Id_pago, 0, pObj.id_contrato, pObj.id_planpago
                        , Fecha_pago, nuevo_pago.interes_fecha, nuevo_pago.fecha_proximo
                        , nuevo_pago.monto_pago, nuevo_pago.interes, nuevo_pago.amortizacion, nuevo_pago.saldo);
                    return penObj.Registrar(Context_id_usuario);
                }
                else if (Id_pagonafibo > 0)
                {
                    //Se recupera el pago Nafibo sin ajustes
                    pagoEspecialNafibo pNafObj = new pagoEspecialNafibo(0, 0, Id_pagonafibo);
                    plan_pago ppNafObj = new plan_pago(pNafObj.id_planpago);

                    //Se recuperan los datos del contrato_especial
                    //contrato_especial_nafibo ceNafObj = new contrato_especial_nafibo(pNafObj.id_contrato);

                    //Se determina el Monto y la fecha de pago
                    decimal Monto_pago_Naf = pNafObj.monto_pago;
                    DateTime Fecha_pago_Naf = pNafObj.fecha;

                    //Se generan los datos del nuevo pago ajustado
                    sim_pago nuevo_pago_Naf = new sim_pago(pAntSimObj, Fecha_pago_Naf, Fecha_pago_Naf, Fecha_pago_Naf, Fecha_pago_Naf, 0,
                    Monto_pago_Naf, ppNafObj.fecha_inicio_plan, ppNafObj.seguro, ppNafObj.mantenimiento_sus, ppNafObj.interes_corriente);

                    //Se registran los datos del Pago Especial Nafibo
                    pagoEspecialNafibo penNafObj = new pagoEspecialNafibo(0, Id_pagonafibo, pNafObj.id_contrato, pNafObj.id_planpago
                        , Fecha_pago_Naf, nuevo_pago_Naf.interes_fecha, nuevo_pago_Naf.fecha_proximo
                        , nuevo_pago_Naf.monto_pago, nuevo_pago_Naf.interes, nuevo_pago_Naf.amortizacion, nuevo_pago_Naf.saldo);
                    return penNafObj.Registrar(Context_id_usuario);
                }
                else { return false; }
            }
            return correcto;
        }


        #endregion

        #region Métodos que requieren constructor

        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pagoEspecialNafibo_RecuperarDatos");
                db1.AddInParameter(cmd, "id_pagoespecialnafibo0", DbType.Int32, _id_pagoespecialnafibo);
                db1.AddInParameter(cmd, "id_pago0", DbType.Int32, _id_pago);
                db1.AddInParameter(cmd, "id_pagonafibo0", DbType.Int32, _id_pagonafibo);

                db1.AddOutParameter(cmd, "id_pagoespecialnafibo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_pago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_pagonafibo", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_planpago", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "fecha_proximo", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "interes_fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "monto_pago", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes", DbType.Double, 14);
                db1.AddOutParameter(cmd, "amortizacion", DbType.Double, 14);
                db1.AddOutParameter(cmd, "saldo", DbType.Double, 14);

                db1.ExecuteNonQuery(cmd);

                _id_pagoespecialnafibo = (int)db1.GetParameterValue(cmd, "id_pagoespecialnafibo");
                _id_pago = (int)db1.GetParameterValue(cmd, "id_pago");
                _id_pagonafibo = (int)db1.GetParameterValue(cmd, "id_pagonafibo");

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_planpago = (int)db1.GetParameterValue(cmd, "id_planpago");

                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _fecha_proximo = (DateTime)db1.GetParameterValue(cmd, "fecha_proximo");
                _interes_fecha = (DateTime)db1.GetParameterValue(cmd, "interes_fecha");

                _monto_pago = (decimal)(double)db1.GetParameterValue(cmd, "monto_pago");
                _interes = (decimal)(double)db1.GetParameterValue(cmd, "interes");
                _amortizacion = (decimal)(double)db1.GetParameterValue(cmd, "amortizacion");
                _saldo = (decimal)(double)db1.GetParameterValue(cmd, "saldo");
            }
            catch { }
        }

        protected bool Registrar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pagoEspecialNafibo_Registrar");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);

                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.AddInParameter(cmd, "id_pagonafibo", DbType.Int32, _id_pagonafibo);

                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_planpago", DbType.Int32, _id_planpago);

                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "interes_fecha", DbType.DateTime, _interes_fecha);
                db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, _fecha_proximo);

                db1.AddInParameter(cmd, "monto_pago", DbType.Decimal, _monto_pago);
                db1.AddInParameter(cmd, "interes", DbType.Decimal, _interes);
                db1.AddInParameter(cmd, "amortizacion", DbType.Decimal, _amortizacion);
                db1.AddInParameter(cmd, "saldo", DbType.Decimal, _saldo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Deshacer(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pagoEspecialNafibo_Deshacer");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_pagoespecialnafibo", DbType.Int32, _id_pagoespecialnafibo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion


    }
}