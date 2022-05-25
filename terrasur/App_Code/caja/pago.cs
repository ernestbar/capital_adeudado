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
using System.Threading;
/// <summary>
/// Summary description for pago
/// </summary>
namespace terrasur 
{
    public class pago
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        // Propiedades privadas
        private int _id_pago = 0;
        private int _id_tipopago = 0;
        private int _id_contrato = 0;
        private int _id_transaccion = 0;
        private int _id_planpago = 0;
        private DateTime _fecha = DateTime.Now;
        private DateTime _fecha_proximo = DateTime.Now;
        private int _num_cuotas = 0;
        private decimal _monto_pago = 0;
        private decimal _seguro = 0;
        private DateTime _seguro_fecha = DateTime.Now;
        private int _seguro_meses = 0;
        private decimal _mantenimiento_sus = 0;
        private DateTime _mantenimiento_fecha = DateTime.Now;
        private int _mantenimiento_meses = 0;
        private decimal _interes = 0;
        private DateTime _interes_fecha = DateTime.Now;
        private int _interes_dias = 0;
        private int _interes_dias_total = 0;
        private decimal _amortizacion = 0;
        private decimal _saldo = 0;
        private bool _anulado = false;

        private string _codigo_tipo_pago = "";
        private int _anterior_num_pagos = 0;
        private int _anterior_num_cuotas = 0;
        // Propiedades públicas
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public int id_tipopago { get { return _id_tipopago; } set { _id_tipopago = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public int id_planpago { get { return _id_planpago; } set { _id_planpago = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public DateTime fecha_proximo { get { return _fecha_proximo; } set { _fecha_proximo = value; } }
        public int num_cuotas { get { return _num_cuotas; } set { _num_cuotas = value; } }
        public decimal monto_pago { get { return _monto_pago; } set { _monto_pago = value; } }
        public decimal seguro { get { return _seguro; } set { _seguro = value; } }
        public DateTime seguro_fecha { get { return _seguro_fecha; } set { _seguro_fecha = value; } }
        public int seguro_meses { get { return _seguro_meses; } set { _seguro_meses = value; } }
        public decimal mantenimiento_sus { get { return _mantenimiento_sus; } set { _mantenimiento_sus = value; } }
        public DateTime mantenimiento_fecha { get { return _mantenimiento_fecha; } set { _mantenimiento_fecha = value; } }
        public int mantenimiento_meses { get { return _mantenimiento_meses; } set { _mantenimiento_meses = value; } }
        public decimal interes { get { return _interes; } set { _interes = value; } }
        public DateTime interes_fecha { get { return _interes_fecha; } set { _interes_fecha = value; } }
        public int interes_dias { get { return _interes_dias; } set { _interes_dias = value; } }
        public int interes_dias_total { get { return _interes_dias_total; } set { _interes_dias_total = value; } }
        public decimal amortizacion { get { return _amortizacion; } set { _amortizacion = value; } }
        public decimal saldo { get { return _saldo; } set { _saldo = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }

        public string codigo_tipo_pago { get { return _codigo_tipo_pago; } }
        public int anterior_num_pagos { get { return _anterior_num_pagos; } set { _anterior_num_pagos = value; } }
        public int anterior_num_cuotas { get { return _anterior_num_cuotas; } set { _anterior_num_cuotas = value; } }
        #endregion

        #region Constructores
        public pago(int Id_pago)
        {
            _id_pago = Id_pago;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaTransferencia(int Id_contrato)
        {
            //[id_pago],[fecha],[monto_pago],[amortizacion],[saldo],[codigo_tipo_pago],[nombre_tipo_pago],[texto]
            DbCommand cmd = db1.GetStoredProcCommand("pago_ListaTransferencia");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorContratoKardex(int Id_contrato)
        {
            //[id_transaccion],[tipo_pago],[string_cuotas],[fecha_pago],[fecha_proximo],[interes_fecha]
            //[monto_pago],[seguro],[mantenimiento_sus],[interes],[amortizacion],[saldo],[interes_penal]
            DbCommand cmd = db1.GetStoredProcCommand("pago_ListaPorContratoKardex");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            if (tabla.Rows.Count > 0)
            {
                decimal monto_pago = 0, seguro = 0, mantenimiento_sus = 0, interes = 0, amortizacion = 0, interes_penal = 0;
                foreach (DataRow fila in tabla.Rows)
                {
                    monto_pago += (decimal)fila["monto_pago"];
                    seguro += (decimal)fila["seguro"];
                    mantenimiento_sus += (decimal)fila["mantenimiento_sus"];
                    interes += (decimal)fila["interes"];
                    amortizacion += (decimal)fila["amortizacion"];
                    interes_penal += (decimal)fila["interes_penal"];
                }
                DataRow fila_totales = tabla.NewRow();
                fila_totales["string_cuotas"] = "Total:";
                fila_totales["monto_pago"] = monto_pago;
                fila_totales["seguro"] = seguro;
                fila_totales["mantenimiento_sus"] = mantenimiento_sus;
                fila_totales["interes"] = interes;
                fila_totales["amortizacion"] = amortizacion;
                fila_totales["interes_penal"] = interes_penal;
                tabla.Rows.Add(fila_totales);
            }
            return tabla;
        }

        public static bool PermitirAnularCuotaInicial(int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_PermitirAnularCuotaInicial");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static bool AnularCuotaInicial(int Id_cuota_inicial, int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_AnularCuotaInicial");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_cuota_inicial", DbType.Int32, Id_cuota_inicial);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0)
                {
                    //pago pag = new pago(Id_cuota_inicial);
                    //transaccion tran = new transaccion(pag.id_transaccion);
                    //forma_pago fpago = new forma_pago(pag._id_transaccion);
                    //contrato ob_con = new contrato(Id_contrato);
                    //contrato_venta ob_cv = new contrato_venta(Id_contrato);
                    //lote lot = new lote(ob_cv.id_lote);
                    //negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                    // tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    //if (neg.id_negocio == 3)
                    //{
                    //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //    ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    //    string tipo_pago = "";
                    //    string nombre_urbanizacion;
                    //    nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    //    bool efectivo = true;
                    //    if (fpago.dpr == true)
                    //    { 
                    //        tipo_pago = "CUOTA INICIAL DPR";
                    //        efectivo = false;
                    //    }
                    //    else
                    //    { 
                    //        tipo_pago = "CUOTA INICIAL EFECTIVO";
                    //        efectivo = true;                      
                    //    }

                    //    decimal monto_pago_bs = 0;
                    //    decimal precio_final_bs = 0;
                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        monto_pago_bs = Math.Round(pag.monto_pago * tran.tipo_cambio,2);
                    //        precio_final_bs = Math.Round(ob_con.precio_final * tran.tipo_cambio, 2);
                    //    }
                    //    else
                    //    {
                    //        monto_pago_bs = pag.monto_pago;
                    //        precio_final_bs = pag.monto_pago;
                    //    }


                    //    string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", pag.id_transaccion.ToString(), 0, true, tipo_pago,
                    //        float.Parse(monto_pago_bs.ToString("F2")), true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 
                    //        lot.id_urbanizacion.ToString(), "", "", efectivo,true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    //    ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                    //    string resultado2 = obj2.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", pag.id_transaccion.ToString(), 0, true,"VENTA DE LOTES EFECTIVO Y DPR",
                    //        0, true, 0, true, 0, true, 0, true, float.Parse(precio_final_bs.ToString("F2")), true, 0, true, 0, true, 0, true, 
                    //        lot.id_urbanizacion.ToString(), "", "", efectivo,true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    //    /////////////////////INVENTARIOS//////////////////////////////////
                    //    decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                    //    decimal porcentaje = pag.monto_pago / ob_con.precio_final;
                    //    decimal costo_pagado = costo_lote * porcentaje;

                    //    decimal costo_lote_bs = 0;
                    //    decimal costo_pagado_bs = 0;

                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        costo_pagado_bs =Math.Round(costo_pagado * tc.compra);
                    //        costo_lote_bs = Math.Round(costo_lote * tc.compra);
                    //    }
                    //    else
                    //    {
                    //        costo_pagado_bs = costo_pagado;
                    //        costo_lote_bs = costo_lote;
                    //    }

                    //    ServiceReference1.SintesisService obj3 = new ServiceReference1.SintesisService();
                    //    string resultado3 = obj3.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", pag.id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                    //       0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 
                    //       lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //       true, ip, DateTime.Now.ToShortDateString(), 0, true, float.Parse(costo_pagado_bs.ToString("F2")), true, 0, true);

                    //    ServiceReference1.SintesisService obj4 = new ServiceReference1.SintesisService();
                    //    string resultado4 = obj4.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", pag.id_transaccion.ToString(), 0, true, "INVENTARIO VENTA DE LOTES",
                    //       0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 
                    //       lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //       true, ip, DateTime.Now.ToShortDateString(), float.Parse(costo_lote_bs.ToString("F2")), true, 0, true, 0, true);
                    //}
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }
        public static bool PermitirAnularUltimoPago(int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_PermitirAnularUltimoPago");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static bool AnularUltimoPago(int Id_ultimo_pago, int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_AnularUltimoPago");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_ultimo_pago", DbType.Int32, Id_ultimo_pago);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0)
                {
                    //pago pag = new pago(Id_ultimo_pago);
                    //transaccion tran = new transaccion(pag.id_transaccion);
                    //forma_pago fpago = new forma_pago(pag._id_transaccion);
                    
                    //contrato ob_con = new contrato(Id_contrato);
                    //contrato_venta ob_cv = new contrato_venta(Id_contrato);
                    //lote lot = new lote(ob_cv.id_lote);
                    //negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                    //tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    //if (neg.id_negocio == 3)
                    //{
                    //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //    ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    //    string tipo_pago = "";
                    //    string nombre_urbanizacion;
                    //    nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();

                    //    bool efectivo = true;
                    //    if (fpago.dpr == true)
                    //    {
                    //        tipo_pago = "CUOTA NORMAL DPR";
                    //        efectivo = false;
                    //    }
                    //    else
                    //    { 
                    //        tipo_pago = "CUOTA NORMAL EFECTIVO";
                    //        efectivo = true;
                    //    }

                    //    decimal monto_pago_bs = 0;
                    //    decimal interes_bs = 0;
                    //    decimal amortizacion_bs = 0;

                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        monto_pago_bs = Math.Round(pag.monto_pago * tran.tipo_cambio);
                    //        interes_bs = Math.Round(pag.interes * tran.tipo_cambio);
                    //        amortizacion_bs = Math.Round(pag.amortizacion * tran.tipo_cambio);
                    //    }
                    //    else
                    //    {
                    //        monto_pago_bs = pag.monto_pago;
                    //        interes_bs = pag.interes ;
                    //        amortizacion_bs =pag.amortizacion ;
                    //    }


                       
                    //    string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", pag.id_transaccion.ToString(), 0, true, tipo_pago,
                    //        0, true, float.Parse(monto_pago_bs.ToString("F2")), true, float.Parse(interes_bs.ToString("F2")), true, float.Parse(amortizacion_bs.ToString("F2")), true, 0, true, 0, true, 0, true, 0, true, 
                    //        lot.id_urbanizacion.ToString(), "", "",efectivo, true, nombre_urbanizacion, "", true, true, context_id_usuario, 
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    //    decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                    //    decimal porcentaje = pag.amortizacion / ob_con.precio_final;
                    //    decimal costo_pagado = costo_lote * porcentaje;
                    //    decimal costo_pagado_bs = 0;
                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        costo_pagado_bs = Math.Round(costo_pagado * tc.compra, 2);
                    //    }
                    //    else
                    //    {
                    //        costo_pagado_bs = costo_pagado;
                    //    }

                    //    ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                    //    string resultado1 = obj1.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", pag.id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                    //       0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 
                    //       lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //       true, ip, DateTime.Now.ToShortDateString(), 0, true, float.Parse(costo_pagado_bs.ToString("F2")), true, 0, true);
                    //}

                    return true; 
                }
                else return false;
            }
            catch { return false; }
        }
        public static int IdPorTransaccion(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_IdPorTransaccion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int IdPagoAnterior(int Id_pago, int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_IdPagoAnterior");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, Id_pago);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static bool FechaInteres_Actualizar(int Id_ultimo_pago, DateTime Fecha_interes, DateTime Fecha_proximo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_FechaInteres_Actualizar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_ultimo_pago", DbType.Int32, Id_ultimo_pago);
                db1.AddInParameter(cmd, "fecha_interes", DbType.DateTime, Fecha_interes);
                db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, Fecha_proximo);
                db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.AddOutParameter(cmd, "id_tipopago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_planpago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "fecha_proximo", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "num_cuotas", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto_pago", DbType.Double, 14);
                db1.AddOutParameter(cmd, "seguro", DbType.Double, 14);
                db1.AddOutParameter(cmd, "seguro_fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "seguro_meses", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "mantenimiento_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "mantenimiento_fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "mantenimiento_meses", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "interes", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes_fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "interes_dias", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "interes_dias_total", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "amortizacion", DbType.Double, 14);
                db1.AddOutParameter(cmd, "saldo", DbType.Double, 14);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "codigo_tipo_pago", DbType.String, 50);
                db1.AddOutParameter(cmd, "anterior_num_pagos", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "anterior_num_cuotas", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);

                _id_tipopago = (int)db1.GetParameterValue(cmd, "id_tipopago");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                _id_planpago = (int)db1.GetParameterValue(cmd, "id_planpago");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _fecha_proximo = (DateTime)db1.GetParameterValue(cmd, "fecha_proximo");
                _num_cuotas = (int)db1.GetParameterValue(cmd, "num_cuotas");
                _monto_pago = (decimal)(double)db1.GetParameterValue(cmd, "monto_pago");
                _seguro = (decimal)(double)db1.GetParameterValue(cmd, "seguro");
                _seguro_fecha = (DateTime)db1.GetParameterValue(cmd, "seguro_fecha");
                _seguro_meses = (int)db1.GetParameterValue(cmd, "seguro_meses");
                _mantenimiento_sus = (decimal)(double)db1.GetParameterValue(cmd, "mantenimiento_sus");
                _mantenimiento_fecha = (DateTime)db1.GetParameterValue(cmd, "mantenimiento_fecha");
                _mantenimiento_meses = (int)db1.GetParameterValue(cmd, "mantenimiento_meses");
                _interes = (decimal)(double)db1.GetParameterValue(cmd, "interes");
                _interes_fecha = (DateTime)db1.GetParameterValue(cmd, "interes_fecha");
                _interes_dias = (int)db1.GetParameterValue(cmd, "interes_dias");
                _interes_dias_total = (int)db1.GetParameterValue(cmd, "interes_dias_total");
                _amortizacion = (decimal)(double)db1.GetParameterValue(cmd, "amortizacion");
                _saldo = (decimal)(double)db1.GetParameterValue(cmd, "saldo");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");

                _codigo_tipo_pago = (string)db1.GetParameterValue(cmd, "codigo_tipo_pago");
                _anterior_num_pagos = (int)db1.GetParameterValue(cmd, "anterior_num_pagos");
                _anterior_num_cuotas = (int)db1.GetParameterValue(cmd, "anterior_num_cuotas");
            }
            catch { }
        }

        //public static bool Forma_dprO;
        //public static int Id_contratoO,Id_transaccionO,context_id_usuarioO;
        //public static decimal monto_pagoO, amortizacionO, interesO;
        //public static string ipO;
        private static int Insertar_PagoNormalAdelantadoSegunPlan(int context_id_usuario, int context_id_rol,
            int Id_contrato, int Id_recibocobrador, string Recurso_pago,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar,
            sim_pago nuevo_pago, decimal Monto_sus, bool Forma_dpr)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                DbCommand cmd = db1.GetStoredProcCommand("pago_Insertar_PagoNormalAdelantadoSegunPlan");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "p_id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "p_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "p_id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "p_id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "p_id_recibocobrador", DbType.Int32, Id_recibocobrador);
                db1.AddInParameter(cmd, "p_recurso_pago", DbType.String, Recurso_pago);

                db1.AddInParameter(cmd, "p_monto", DbType.Decimal, Monto_sus);
                db1.AddInParameter(cmd, "p_forma_dpr", DbType.Boolean, Forma_dpr);

                db1.AddInParameter(cmd, "p_cliente_nombre", DbType.String, Cliente_nombre);
                db1.AddInParameter(cmd, "p_cliente_nit", DbType.Decimal, Cliente_nit);
                db1.AddInParameter(cmd, "p_cliente_guardar", DbType.Boolean, Cliente_guardar);

                db1.AddInParameter(cmd, "p_fecha_proximo", DbType.DateTime, nuevo_pago.fecha_proximo);
                db1.AddInParameter(cmd, "p_num_cuotas", DbType.Int32, nuevo_pago.num_cuotas);
                db1.AddInParameter(cmd, "p_monto_pago", DbType.Decimal, nuevo_pago.monto_pago);
                db1.AddInParameter(cmd, "p_seguro", DbType.Decimal, nuevo_pago.seguro);
                db1.AddInParameter(cmd, "p_seguro_fecha", DbType.DateTime, nuevo_pago.seguro_fecha);
                db1.AddInParameter(cmd, "p_seguro_meses", DbType.Int32, nuevo_pago.seguro_meses);
                db1.AddInParameter(cmd, "p_mantenimineto_sus", DbType.Decimal, nuevo_pago.mantenimiento_sus);
                db1.AddInParameter(cmd, "p_mantenimineto_fecha", DbType.DateTime, nuevo_pago.mantenimiento_fecha);
                db1.AddInParameter(cmd, "p_mantenimineto_meses", DbType.Int32, nuevo_pago.mantenimiento_meses);
                db1.AddInParameter(cmd, "p_interes", DbType.Decimal, nuevo_pago.interes);
                db1.AddInParameter(cmd, "p_interes_fecha", DbType.DateTime, nuevo_pago.interes_fecha);
                db1.AddInParameter(cmd, "p_interes_dias", DbType.Int32, nuevo_pago.interes_dias);
                db1.AddInParameter(cmd, "p_interes_dias_total", DbType.Int32, nuevo_pago.interes_dias_total);
                db1.AddInParameter(cmd, "p_amortizacion", DbType.Decimal, nuevo_pago.amortizacion);
                db1.AddInParameter(cmd, "p_saldo", DbType.Decimal, nuevo_pago.saldo);

                db1.AddOutParameter(cmd, "p_id_transaccion", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                int Id_transaccion =(int)db1.GetParameterValue(cmd, "p_id_transaccion");
                //contrato ob_con = new contrato(Id_contrato);
                //negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                //string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                //if (neg.id_negocio == 3)
                //{
                    //string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    
                    //bool efectivo = true;
                    //string tipo_pago = "";
                    //string nombre_urbanizacion;
                    //tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    //nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    //if (Forma_dpr == true)
                    //{ tipo_pago = "CUOTA NORMAL DPR"; efectivo = false; }
                    //else
                    //{ tipo_pago = "CUOTA NORMAL EFECTIVO"; efectivo = true; }
                    //float pago_total_bs = 0;
                    //float amortizacion_bs = 0;
                    //float intereses_bs = 0;
                    //if (ob_con.id_moneda == 1)
                    //{
                    //    pago_total_bs = (float)Math.Round(nuevo_pago.monto_pago * tc.compra, 2);
                    //     amortizacion_bs = (float)Math.Round(nuevo_pago.amortizacion * tc.compra, 2);
                    //     intereses_bs = (float)Math.Round(nuevo_pago.interes * tc.compra, 2);
                    //}
                    //else
                    //{
                    //    pago_total_bs = (float)nuevo_pago.monto_pago;
                    //    amortizacion_bs = (float)nuevo_pago.amortizacion;
                    //    intereses_bs = (float)nuevo_pago.interes;
                    //}

                    //string pago_total_s = pago_total_bs.ToString("F2");
                    //string amortizacion_s = amortizacion_bs.ToString("F2");
                    //string intereses_s = intereses_bs.ToString("F2");

                    //ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    //string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, tipo_pago,
                    //    0, true, float.Parse(pago_total_s), true, float.Parse(intereses_s), true, float.Parse(amortizacion_s), true, 0, true, 0, true, 0, true, 0, true,
                    //   lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario,
                    //    true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    //decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                    //decimal porcentaje = nuevo_pago.amortizacion / ob_con.precio_final;
                    //decimal costo_pagado = costo_lote * porcentaje;

                    //string costo_pagado_S=Math.Round(costo_pagado * tc.compra, 2).ToString("F2");
                    //float costo_pagado_bs = float.Parse(costo_pagado_S);
                    ////lot.id_urbanizacion.ToString() -------> 10000
                    //ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                    //string resultado1 = obj1.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                    //   0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true,
                    //   lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario,
                    //   true, ip, DateTime.Now.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);

                    //Forma_dprO=Forma_dpr;
                    //Id_contratoO=Id_contrato;
                    //Id_transaccionO=Id_transaccion;
                    //context_id_usuarioO=context_id_usuario;
                    //monto_pagoO=nuevo_pago.monto_pago;
                    //amortizacionO=nuevo_pago.amortizacion;
                    //interesO=nuevo_pago.interes;
                    //ipO = ip;
                    //Thread odooT = new Thread(new ThreadStart(insertar_odoo));
                    ////odooT.IsBackground = true;
                    //odooT.Start();
                //}
               
                
                return Id_transaccion;
            }
            catch { return 0; }
        }

        //public static void insertar_odoo()
        //{
        //    try
        //    {
        //        contrato ob_con = new contrato(Id_contratoO);
        //        contrato_venta ob_cv = new contrato_venta(Id_contratoO);
        //        lote lot = new lote(ob_cv.id_lote);
        //        negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                

        //        bool efectivo = true;
        //        string tipo_pago = "";
        //        string nombre_urbanizacion;
        //        tipo_cambio tc = new tipo_cambio(DateTime.Now);
        //        nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
        //        if (Forma_dprO == true)
        //        { tipo_pago = "CUOTA NORMAL DPR"; efectivo = false; }
        //        else
        //        { tipo_pago = "CUOTA NORMAL EFECTIVO"; efectivo = true; }
        //        float pago_total_bs = 0;
        //        float amortizacion_bs = 0;
        //        float intereses_bs = 0;
        //        if (ob_con.id_moneda == 1)
        //        {
        //            pago_total_bs = (float)Math.Round(monto_pagoO * tc.compra, 2);
        //            amortizacion_bs = (float)Math.Round(amortizacionO * tc.compra, 2);
        //            intereses_bs = (float)Math.Round(interesO * tc.compra, 2);
        //        }
        //        else
        //        {
        //            pago_total_bs = (float)monto_pagoO;
        //            amortizacion_bs = (float)amortizacionO;
        //            intereses_bs = (float)interesO;
        //        }

        //        string pago_total_s = pago_total_bs.ToString("F2");
        //        string amortizacion_s = amortizacion_bs.ToString("F2");
        //        string intereses_s = intereses_bs.ToString("F2");

        //        ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
        //        string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccionO.ToString(), 0, true, tipo_pago,
        //            0, true, float.Parse(pago_total_s), true, float.Parse(intereses_s), true, float.Parse(amortizacion_s), true, 0, true, 0, true, 0, true, 0, true,
        //           "10000", "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuarioO,
        //            true, ipO, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

        //        decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
        //        decimal porcentaje = amortizacionO / ob_con.precio_final;
        //        decimal costo_pagado = costo_lote * porcentaje;

        //        string costo_pagado_S = Math.Round(costo_pagado * tc.compra, 2).ToString("F2");
        //        float costo_pagado_bs = float.Parse(costo_pagado_S);
        //        //lot.id_urbanizacion.ToString() -------> 10000
        //        ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
        //        string resultado1 = obj1.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccionO.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
        //           0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true,
        //           "10000", "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuarioO,
        //           true, ipO, DateTime.Now.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = "";
        //    }
            
                
        //}
        #endregion

        #region Pagos

        public static sim_pago CambioTipoCliente_PagoNormalSimulado(int Id_contrato, DateTime Fecha_pago, ref sim_pago ultimo_pago)
        {
            contrato c = new contrato(Id_contrato);
            plan_pago pp = new plan_pago(c.id_planpago_vigente);
            int Num_cuotas;
            decimal Monto_pago;
            DateTime Fecha_cobro_interes = logica.FechaCobroInteres(c.preferencial.Equals(false), Fecha_pago, ultimo_pago.fecha_proximo);
            Num_cuotas = logica.NumCuotasAdeuda(ultimo_pago.fecha_proximo, Fecha_pago);
            if (Num_cuotas == 0) Monto_pago = pp.cuota_base;
            else Monto_pago = pp.cuota_base * Num_cuotas;
            sim_pago nuevo_pago = new sim_pago(ultimo_pago, Fecha_pago, Fecha_pago, Fecha_pago, Fecha_pago, Num_cuotas,
                Monto_pago, pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);
            return nuevo_pago;
        }

        public static DataTable CambioTipoCliente_ListaPago(int Id_contrato, ref decimal MontoMinimo)
        {
            DateTime Fecha_pago = DateTime.Now;
            DataTable tabla = simular.tabla_plan_crear();
            sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, Fecha_pago));

            contrato c = new contrato(Id_contrato);
            sim_pago nuevo_pago;
            if (c.preferencial == true) nuevo_pago = CambioTipoCliente_PagoNormalSimulado(Id_contrato, DateTime.Now, ref ultimo_pago);
            else nuevo_pago = PagoAdelantadoSegunPlanSimulado_VARIOS_PAGOS(new plan_pago(c.id_planpago_vigente), ultimo_pago);
            MontoMinimo = nuevo_pago.seguro + nuevo_pago.mantenimiento_sus + nuevo_pago.interes;

            simular.tabla_plan_insertar(ref tabla, ultimo_pago);
            simular.tabla_plan_insertar(ref tabla, nuevo_pago);
            return tabla;
        }

        public static bool Permitir(int Id_contrato, int context_id_usuario, int context_id_rol, string Codigo_pago)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("pago_Permitir");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "codigo_pago", DbType.String, Codigo_pago);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public static int Insertar_PagoInicial(int context_id_usuario, int context_id_rol, int Id_contrato, int Id_recibocobrador,
            tmpFormaPago tfp, string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                //Se registra: la transacción, la factura, el beneficiario, el recibo, el comprobante, el pago y el plan de pagos
                DbCommand cmd = db1.GetStoredProcCommand("pago_Insertar_PagoInicial");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
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
                    //contrato ob_con = new contrato(Id_contrato);
                    //contrato_venta ob_cv = new contrato_venta(Id_contrato);
                    //lote lot = new lote(ob_cv.id_lote);
                    //negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                    //if (neg.id_negocio == 3)
                    //{
                    //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //    ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    //    string tipo_pago = "";
                    //    string nombre_urbanizacion;
                    //    nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    //    bool efectivo = true;
                    //    tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    //    if (tfp.dpr == true)
                    //    { tipo_pago = "CUOTA INICIAL DPR"; efectivo = false; }
                    //    else
                    //    { tipo_pago = "CUOTA INICIAL EFECTIVO"; efectivo = true; }

                    //    decimal monto_bs = 0;
                    //    decimal precio_final_bs = 0;

                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        monto_bs =Math.Round(tfp.monto * tc.compra,2);
                    //        precio_final_bs = Math.Round(ob_con.precio_final * tc.compra, 2);
                    //    }
                    //    else
                    //    {
                    //        monto_bs = tfp.monto;
                    //        precio_final_bs = ob_con.precio_final;
                    //    }

                    //    string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, tipo_pago,
                    //        float.Parse(monto_bs.ToString("F2")), true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 
                    //        lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario, 
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    //    ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                    //    string resultado2 = obj2.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, "VENTA DE LOTES EFECTIVO Y DPR",
                    //        0, true, 0, true, 0, true, 0, true, float.Parse(precio_final_bs.ToString("F2")), true, 0, true, 0, true, 0, true, 
                    //        lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario, 
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);
                    //    /////////////////////INVENTARIOS//////////////////////////////////
                    //    decimal costo_lote_bs = 0;
                    //    decimal costo_pagado_bs = 0;

                    //    decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                    //    decimal porcentaje = tfp.monto / ob_con.precio_final;
                    //    decimal costo_pagado = costo_lote * porcentaje;

                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        costo_lote_bs =Math.Round( costo_lote * tc.compra,2);
                    //        costo_pagado_bs = Math.Round(costo_pagado * tc.compra, 2);
                    //    }
                    //    else
                    //    {
                    //        costo_lote_bs = costo_lote ;
                    //        costo_pagado_bs = costo_pagado;
                    //    }

                    //    ServiceReference1.SintesisService obj3 = new ServiceReference1.SintesisService();
                    //    string resultado3 = obj3.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                    //       0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, lot.id_urbanizacion.ToString(),
                    //       "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario,
                    //       true, ip, DateTime.Now.ToShortDateString(), 0, true, float.Parse(costo_pagado_bs.ToString("F2")), true, 0, true);

                    //    ServiceReference1.SintesisService obj4 = new ServiceReference1.SintesisService();
                    //    string resultado4 = obj4.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, "INVENTARIO VENTA DE LOTES",
                    //       0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, lot.id_urbanizacion.ToString(),
                    //       "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario,
                    //       true, ip, DateTime.Now.ToShortDateString(), float.Parse(costo_lote_bs.ToString("F2")), true, 0, true, 0, true);

                    //}

                    if (new forma_pago(Id_transaccion, tfp).Insertar() == true) return Id_transaccion;
                    else return 0;
                }
                else return 0;
            }
            catch { return 0; }
        }

        public static int Insertar_PagoCapital(int context_id_usuario, int context_id_rol, int Id_contrato, int Id_recibocobrador,
            tmpFormaPago tfp, string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                //Se registra: la transacción, la factura, el beneficiario, el recibo, el comprobante, el pago
                DbCommand cmd = db1.GetStoredProcCommand("pago_Insertar_PagoCapital");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
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
                    //contrato ob_con = new contrato(Id_contrato);
                    //contrato_venta ob_cv = new contrato_venta(Id_contrato);
                    //lote lot = new lote(ob_cv.id_lote);
                    //negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                    //tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    //if (neg.id_negocio == 3)
                    //{
                    //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //    ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    //    string tipo_pago = "";
                    //    string nombre_urbanizacion;
                    //    nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    //    bool efectivo = true;
                    //    if (tfp.dpr == true)
                    //    { tipo_pago = "CUOTA NORMAL DPR"; efectivo = false; }
                    //    else
                    //    { tipo_pago = "CUOTA NORMAL EFECTIVO"; efectivo = true; }

                    //    decimal monto_bs = 0;
                    //    if (ob_con.id_moneda == 1)
                    //    {
                    //        monto_bs = Math.Round(tfp.monto * tc.compra, 2);
                    //    }
                    //    else
                    //    {
                    //        monto_bs = tfp.monto;
                    //    }

                    //    string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, tipo_pago,
                    //        0, true, float.Parse(monto_bs.ToString("F2")), true, 0, true, float.Parse(monto_bs.ToString("F2")), true, 0, true, 0, true, 0, true, 0, true, 
                    //        lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario, 
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    //    /////////////////////INVENTARIOS//////////////////////////////////
                    //    decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                    //    decimal porcentaje = tfp.monto / ob_con.precio_final;
                    //    decimal costo_pagado = costo_lote * porcentaje;

                    //    decimal costo_pagado_bs = 0;

                    //    if (ob_con.id_moneda == 1)
                    //    { costo_pagado_bs =Math.Round(costo_pagado * tc.compra,2); }
                    //    else
                    //    { costo_pagado_bs = costo_pagado; }

                    //    ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                    //    string resultado1 = obj1.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                    //       0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 
                    //       lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, "", false, true, context_id_usuario,
                    //       true, ip, DateTime.Now.ToShortDateString(), 0, true, float.Parse(costo_pagado_bs.ToString("F2")), true, 0, true);
                    //}

                    if (new forma_pago(Id_transaccion, tfp).Insertar() == true) return Id_transaccion;
                    else return 0;
                }
                else return 0;
            }
            catch { return 0; }
        }


        public static sim_pago PagoNormalSimulado(int Id_contrato, decimal Monto, DateTime Fecha_pago, sim_pago ultimo_pago)
        {
            contrato c = new contrato(Id_contrato);
            plan_pago pp = new plan_pago(c.id_planpago_vigente);
            int Num_cuotas;
            decimal Monto_pago;
            if (Monto > 0)
            {//Si el usuario digitó un monto:
                Num_cuotas = 0;
                Monto_pago = Monto;
            }
            else
            {//Lo que el usuario debe pagar por defecto:
                Num_cuotas = logica.NumCuotasAdeuda(ultimo_pago.fecha_proximo, Fecha_pago);
                //if (Num_cuotas == 0) Num_cuotas = 1;
                if (Num_cuotas == 0) Monto_pago = pp.cuota_base;
                else Monto_pago = pp.cuota_base * Num_cuotas;
            }

            //La fecha de cobro de intereses ficticia es -->
            DateTime Fecha_cobro_interes = logica.FechaCobroInteres_Modificado(c.preferencial, new negocio_contrato(c.id_negociocontrato).negocio_codigo, Fecha_pago, ultimo_pago.fecha_proximo);
            //<-- Es la fecha de cobro de intereses ficticia
            ////PERO la fecha de cobro de intereses REAL es:
            //DateTime Fecha_cobro_interes = logica.FechaCobroInteres(c.preferencial, Fecha_pago, ultimo_pago.fecha_proximo);

            sim_pago nuevo_pago = new sim_pago(ultimo_pago, Fecha_pago, Fecha_pago, Fecha_pago, Fecha_cobro_interes, Num_cuotas,
                Monto_pago, pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);

            //DEBIDO a la fecha de cobro de intereses se debe: -->
            DateTime Fecha_cobro_interes_REAL = logica.FechaCobroInteres(c.preferencial, Fecha_pago, ultimo_pago.fecha_proximo);
            if (Fecha_cobro_interes > Fecha_cobro_interes_REAL)
            {
                TimeSpan Aux_num_dias;
                Aux_num_dias = Fecha_cobro_interes.Subtract(Fecha_cobro_interes_REAL);
                int Num_dias = Convert.ToInt32(Math.Floor(Aux_num_dias.TotalDays));
                if (nuevo_pago.interes_dias_total == nuevo_pago.interes_dias)
                {
                    if ((nuevo_pago.interes_dias_total - Num_dias) >= 0)
                    {
                        nuevo_pago.interes_fecha = nuevo_pago.interes_fecha.AddDays((-1) * Num_dias);
                        nuevo_pago.interes_dias_total -= Num_dias;
                    }
                }
                else if (nuevo_pago.interes_dias_total - Num_dias >= nuevo_pago.interes_dias)
                {
                    nuevo_pago.interes_dias_total -= Num_dias;
                }
            }
            //<-- DEBIDO a la fecha de cobro de intereses


            //Lógica para la determinación del número de cuotas pagadas:

            //Si el usuario digitó un monto:
            //if (Monto > 0) nuevo_pago.num_cuotas = logica.NumCuotasPagadas(ultimo_pago.fecha_proximo, nuevo_pago.interes_fecha);
            if (nuevo_pago.interes == 0 && pp.interes_corriente > 0) nuevo_pago.num_cuotas = 0;
            else
            {
                nuevo_pago.num_cuotas = 1;

                ////Primera opción:
                ////Opcionalmente se puede contar 1 cuota por X(cuota base) monto pagado
                //decimal aux = nuevo_pago.monto_pago - pp.cuota_base;
                //while (aux >= pp.cuota_base)
                //{
                //    nuevo_pago.num_cuotas = nuevo_pago.num_cuotas + 1;
                //    aux = aux - pp.cuota_base;
                //}

                ////Segunda opción:
                //if (ultimo_pago.fecha_proximo <= DateTime.Now.Date)
                //{
                //    //decimal aux = nuevo_pago.monto_pago - pp.cuota_base;
                //    //while (aux >= pp.cuota_base && aux2 > 0)
                //    //{
                //    //    nuevo_pago.num_cuotas = nuevo_pago.num_cuotas + 1;
                //    //    aux = aux - pp.cuota_base;
                //    //    aux2 = aux2 - pp.cuota_base;
                //    //}
                //}
            }


            return nuevo_pago;
        }

        public static DataTable Lista_PagoNormal(int Id_contrato, decimal Monto, DateTime Fecha_pago,
            ref decimal Monto_predeterminado, ref decimal Monto_minimo, ref decimal Monto_maximo, ref bool Con_factura)
        {
            //en la version final se debe borrar el parámetro "Fecha_pago" porque dicho parámetro siempre debe ser "DateTime.Now"
            DataTable tabla = simular.tabla_plan_crear();
            sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, Fecha_pago));
            sim_pago nuevo_pago = PagoNormalSimulado(Id_contrato, Monto, Fecha_pago, ultimo_pago);
            simular.tabla_plan_insertar(ref tabla, ultimo_pago);
            simular.tabla_plan_insertar(ref tabla, nuevo_pago);

            decimal sum_seg_mant_int = nuevo_pago.seguro + nuevo_pago.mantenimiento_sus + nuevo_pago.interes;
            Monto_predeterminado = nuevo_pago.monto_pago;
            Monto_minimo = Math.Ceiling(sum_seg_mant_int);
            if (Monto_minimo == 0) Monto_minimo = nuevo_pago.monto_pago;
            Monto_maximo = sum_seg_mant_int + ultimo_pago.saldo;

            decimal SUM_MANT_INT = nuevo_pago.mantenimiento_sus + nuevo_pago.interes;
            if (contrato.EsContratoVenta(Id_contrato) == true) { Con_factura = SUM_MANT_INT.Equals(0).Equals(false); }
            else { Con_factura = true; }
            //Anterior:
            //if (contrato.EsContratoVenta(Id_contrato) == true) Con_factura = sum_seg_mant_int.Equals(0).Equals(false);
            //else { Con_factura = true; }

            return tabla;
        }

        public static int Insertar_PagoNormal(DateTime Fecha_pago, int context_id_usuario, int context_id_rol, int Id_contrato, int Id_recibocobrador,
            tmpFormaPago tfp, string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar, Decimal Monto_digitado)
        {

            sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, Fecha_pago));
            sim_pago nuevo_pago = PagoNormalSimulado(Id_contrato, Monto_digitado, Fecha_pago, ultimo_pago);
            int Id_transaccion = Insertar_PagoNormalAdelantadoSegunPlan(context_id_usuario, context_id_rol, Id_contrato, Id_recibocobrador, "pagoNormal",
                Cliente_nombre, Cliente_nit, Cliente_guardar,
                nuevo_pago, tfp.monto, tfp.dpr);
            if (Id_transaccion > 0)
            {
                if (new forma_pago(Id_transaccion, tfp).Insertar() == true) return Id_transaccion;
                else return 0;
            }
            else return 0;
        }
      

        //Cuando se genera una transacción para cada pago adelantado:
        private static sim_pago PagoAdelantadoSegunPlanSimulado_VARIOS_PAGOS(plan_pago pp, sim_pago ultimo_pago)
        {
            sim_pago nuevo_pago = new sim_pago(ultimo_pago, ultimo_pago.fecha_proximo, ultimo_pago.fecha_proximo, ultimo_pago.fecha_proximo, ultimo_pago.fecha_proximo, 1,
                 pp.cuota_base, pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);
            nuevo_pago.fecha = DateTime.Now;
            return nuevo_pago;
        }
        public static DataTable Lista_PagoAdelantadoSegunPlan_VARIOS_PAGOS(int Id_contrato, ref int Num_cuotas, ref decimal Monto_total_cuotas, ref bool Con_factura)
        {
            plan_pago pp = new plan_pago(contrato.PlanPagoVigente(Id_contrato));
            sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, DateTime.Now));
            System.Collections.Generic.List<sim_pago> L_pagos = new System.Collections.Generic.List<sim_pago>();
            L_pagos.Add(ultimo_pago);
            decimal sum_montos = 0;
            decimal sum_seg_mant_int = 0;
            decimal SUM_MANT_INT = 0;
            for (int j = 1; j <= Num_cuotas; j++)
            {
                sim_pago nuevo_pago = PagoAdelantadoSegunPlanSimulado_VARIOS_PAGOS(pp, ultimo_pago);
                nuevo_pago.fecha = DateTime.Now;
                L_pagos.Add(nuevo_pago);
                sum_montos += nuevo_pago.monto_pago;
                sum_seg_mant_int += (nuevo_pago.seguro + nuevo_pago.mantenimiento_sus + nuevo_pago.interes);
                SUM_MANT_INT += (nuevo_pago.mantenimiento_sus + nuevo_pago.interes);
                if (nuevo_pago.saldo == 0)
                {
                    Num_cuotas = j;
                    Monto_total_cuotas = Math.Round(sum_montos, 2);

                    if (contrato.EsContratoVenta(Id_contrato) == true) Con_factura = SUM_MANT_INT.Equals(0).Equals(false);
                    else { Con_factura = true; }
                    //Anterior:
                    //if (contrato.EsContratoVenta(Id_contrato) == true) Con_factura = sum_seg_mant_int.Equals(0).Equals(false);
                    //else { Con_factura = true; }
                    
                    return simular.tabla_plan_simulado(L_pagos);
                }
                else ultimo_pago = nuevo_pago;
            }
            Monto_total_cuotas = Math.Round(sum_montos, 2);

            if (contrato.EsContratoVenta(Id_contrato) == true) Con_factura = SUM_MANT_INT.Equals(0).Equals(false);
            else { Con_factura = true; }
            //Anterior:
            //if (contrato.EsContratoVenta(Id_contrato) == true) Con_factura = sum_seg_mant_int.Equals(0).Equals(false);
            //else { Con_factura = true; }
            
            return simular.tabla_plan_simulado(L_pagos);
        }
        public static string Insertar_PagoAdelantadoSegunPlan_VARIOS_PAGOS(int context_id_usuario, int context_id_rol,
            int Id_contrato, int Id_recibocobrador, string Recurso_pago, int Num_cuotas, tmpFormaPago tfp,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                plan_pago pp = new plan_pago(contrato.PlanPagoVigente(Id_contrato));
                sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, DateTime.Now));
                decimal sum_montos = 0;
                System.Collections.Generic.List<sim_pago> L_pagos = new System.Collections.Generic.List<sim_pago>();
                for (int j = 1; j <= Num_cuotas; j++)
                {
                    sim_pago nuevo_pago = PagoAdelantadoSegunPlanSimulado_VARIOS_PAGOS(pp, ultimo_pago);
                    sum_montos += nuevo_pago.monto_pago;
                    L_pagos.Add(nuevo_pago);
                    ultimo_pago = nuevo_pago;
                }
                if (Math.Round(sum_montos, 2) == Math.Round(tfp.monto, 2))
                {
                    System.Text.StringBuilder tr = new System.Text.StringBuilder();
                    tmpFormaPago tfp_aux = tmpFormaPago.TmpFormaPagoReplica(tfp);
                    foreach (sim_pago p in L_pagos)
                    {
                        int Id_transaccion = Insertar_PagoNormalAdelantadoSegunPlan(context_id_usuario, context_id_rol,
                            Id_contrato, Id_recibocobrador, Recurso_pago, Cliente_nombre, Cliente_nit, Cliente_guardar,
                            p, p.monto_pago, tfp.dpr);
                        if (Id_transaccion > 0)
                        {
                            forma_pago fp = tmpFormaPago.FormaPagoTransaccion(Id_transaccion, ref tfp_aux, p.monto_pago);
                            //forma_pago fp = tfp.FormaPagoTransaccion(Id_transaccion, p.monto_pago);
                            if (fp.Insertar() == true) tr.Append(Id_transaccion.ToString() + ',');
                            else { return ""; }
                        }
                        else { return ""; }
                    }
                    return tr.ToString().TrimEnd(',');
                }
                else { return ""; }
            }
            catch { return ""; }
        }


        ////Cuando se genera una sola transacción para todos los pagos adelantados:
        //public static DataTable Lista_PagoAdelantadoSegunPlan_UN_PAGO(int Id_contrato, ref int Num_cuotas, ref decimal Monto_total_cuotas, ref bool Con_factura)
        //{
        //    plan_pago pp = new plan_pago(contrato.PlanPagoVigente(Id_contrato));
        //    sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, DateTime.Now));
        //    DateTime FechaCobro = ultimo_pago.fecha_proximo.AddMonths(Num_cuotas - 1);

        //    //Desde aquí se modifica el Nº de cuotas (si es necesario)
        //    sim_pago paux = new sim_pago(ultimo_pago, FechaCobro, FechaCobro, FechaCobro, FechaCobro, Num_cuotas, 1000000, pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);
        //    decimal seg_mant_int = paux.seguro + paux.mantenimiento_sus + paux.interes;

        //    while (((Num_cuotas * pp.cuota_base) > (seg_mant_int + ultimo_pago.saldo)) && Num_cuotas > 1)
        //    {
        //        Num_cuotas -= 1;
        //        FechaCobro = ultimo_pago.fecha_proximo.AddMonths(Num_cuotas - 1);

        //        paux = new sim_pago(ultimo_pago, FechaCobro, FechaCobro, FechaCobro, FechaCobro, Num_cuotas, 1000000, pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);
        //        seg_mant_int = paux.seguro + paux.mantenimiento_sus + paux.interes;
        //    }
        //    //Hasta aquí se modifica el Nº de cuotas (si es necesario)

        //    sim_pago nuevo_pago = new sim_pago(ultimo_pago, FechaCobro, FechaCobro, FechaCobro, FechaCobro, Num_cuotas,
        //        (pp.cuota_base * Num_cuotas), pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);

        //    DataTable tabla = simular.tabla_plan_crear();
        //    simular.tabla_plan_insertar(ref tabla, ultimo_pago);
        //    simular.tabla_plan_insertar(ref tabla, nuevo_pago);

        //    Monto_total_cuotas = Math.Round(nuevo_pago.monto_pago, 2);
        //    decimal sum_seg_mant_int = nuevo_pago.seguro + nuevo_pago.mantenimiento_sus + nuevo_pago.interes;
        //    if (contrato.EsContratoVenta(Id_contrato) == true) Con_factura = sum_seg_mant_int.Equals(0).Equals(false);
        //    else { Con_factura = true; }

        //    return tabla;
        //}
        //public static string Insertar_PagoAdelantadoSegunPlan_UN_PAGO(int context_id_usuario, int context_id_rol,
        //    int Id_contrato, int Id_recibocobrador, string Recurso_pago, int Num_cuotas, tmpFormaPago tfp,
        //    string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        //{
        //    try
        //    {
        //        plan_pago pp = new plan_pago(contrato.PlanPagoVigente(Id_contrato));
        //        sim_pago ultimo_pago = new sim_pago(contrato.UltimoPago(Id_contrato, DateTime.Now));
        //        DateTime FechaCobro = ultimo_pago.fecha_proximo.AddMonths(Num_cuotas - 1);
        //        sim_pago nuevo_pago = new sim_pago(ultimo_pago, FechaCobro, FechaCobro, FechaCobro, FechaCobro, Num_cuotas,
        //            (pp.cuota_base * Num_cuotas), pp.fecha_inicio_plan, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente);

        //        int Id_transaccion = Insertar_PagoNormalAdelantadoSegunPlan(context_id_usuario, context_id_rol,
        //            Id_contrato, Id_recibocobrador, Recurso_pago, Cliente_nombre, Cliente_nit, Cliente_guardar,
        //            nuevo_pago, tfp.monto_sus, tfp.dpr);
        //        if (Id_transaccion > 0)
        //        {
        //            if (new forma_pago(Id_transaccion, tfp).Insertar() == true) return Id_transaccion.ToString();
        //            else return "";
        //        }
        //        else return "";
        //    }
        //    catch { return ""; }
        //}


        public static DataTable Lista_PagoNormalParaCliente(int Id_transaccion)
        {
            DataTable tabla = simular.tabla_plan_crear();
            int id_pago = pago.IdPorTransaccion(Id_transaccion);
            int id_pago_anterior = pago.IdPagoAnterior(id_pago, transaccion.IdContrato(Id_transaccion));
            sim_pago ultimo_pago = new sim_pago(id_pago);
            sim_pago pago_anterior = new sim_pago(id_pago_anterior);
            simular.tabla_plan_insertar(ref tabla, pago_anterior);
            simular.tabla_plan_insertar(ref tabla, ultimo_pago);
            tabla.Columns.Add("tipo_pago");
            tabla.Rows[0]["tipo_pago"] = "Pago anterior:";
            tabla.Rows[1]["tipo_pago"] = "Pago realizado:";
            return tabla;
        }

        public static DataTable Lista_PagoNormalParaDocumentos(int Id_transaccion)
        {
            DataTable tabla = simular.tabla_plan_crear();
            int id_pago = pago.IdPorTransaccion(Id_transaccion);
            int id_pago_anterior = pago.IdPagoAnterior(id_pago, transaccion.IdContrato(Id_transaccion));
            sim_pago ultimo_pago = new sim_pago(id_pago);
            //sim_pago pago_anterior = new sim_pago(id_pago_anterior);
            //simular.tabla_plan_insertar(ref tabla, pago_anterior);
            simular.tabla_plan_insertar(ref tabla, ultimo_pago);
            tabla.Columns.Add("tipo_pago");
            //tabla.Rows[0]["tipo_pago"] = "Pago anterior:";
            tabla.Rows[0]["tipo_pago"] = (ultimo_pago.anterior_num_pagos + 1);
            return tabla;
        }
        #endregion
    }
}