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
/// Summary description for contrato
/// </summary>
namespace terrasur
{
    public class contrato
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_contrato = 0;
        private int _id_moneda = 0;
        private int _id_usuario = 0;
        private string _numero = "";
        private DateTime _fecha = DateTime.Now;
        private bool _contado = false;
        private bool _preferencial = false;
        private decimal _precio = 0;
        private decimal _descuento_porcentaje = 0;
        private decimal _descuento_efectivo = 0;
        private decimal _precio_final = 0;
        //Propiedades privadas (datos del plan de pagos)
        private decimal _cuota_inicial = 0;
        private int _num_cuotas = 0;
        private decimal _seguro = 0;
        private decimal _mantenimiento_sus = 0;
        private decimal _interes_corriente = 0;
        private decimal _interes_penal = 0;
        private decimal _cuota_base = 0;
        private DateTime _fecha_inicio_plan = DateTime.Now;
        //Propiedades privadas (observación)
        private string _observacion = "";

        private bool _venta_lote = true;
        private int _id_planpago_vigente = 0;
        private int _estado_id = 0;
        private string _estado_nombre = "";
        private int _id_negociocontrato = 0;
        private string _negocio_nombre = "";
        private int _id_ultimo_pago = 0;
        private int _id_cuota_inicial = 0;
        private int _id_promotor_vigente = 0;
        private int _id_cobrador_vigente = 0;
        private int _id_titular = 0;
        private int _id_reversion = 0;
        private decimal _capital_pagado = 0;
        private decimal _saldo_capital = 0;
        private int _cuotas_pagadas = 0;
        private string _codigo_moneda = "";

        //Propiedades públicas
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string numero { get { return _numero; } set { _numero = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool contado { get { return _contado; } set { _contado = value; } }
        public bool preferencial { get { return _preferencial; } set { _preferencial = value; } }
        public decimal precio { get { return _precio; } set { _precio = value; } }
        public decimal descuento_porcentaje { get { return _descuento_porcentaje; } set { _descuento_porcentaje = value; } }
        public decimal descuento_efectivo { get { return _descuento_efectivo; } set { _descuento_efectivo = value; } }
        public decimal precio_final { get { return _precio_final; } set { _precio_final = value; } }
        //Propiedades públicas (datos del plan de pagos)
        public decimal cuota_inicial { get { return _cuota_inicial; } set { _cuota_inicial = value; } }
        public int num_cuotas { get { return _num_cuotas; } set { _num_cuotas = value; } }
        public decimal seguro { get { return _seguro; } set { _seguro = value; } }
        public decimal mantenimiento_sus { get { return _mantenimiento_sus; } set { _mantenimiento_sus = value; } }
        public decimal interes_corriente { get { return _interes_corriente; } set { _interes_corriente = value; } }
        public decimal interes_penal { get { return _interes_penal; } set { _interes_penal = value; } }
        public decimal cuota_base { get { return _cuota_base; } set { _cuota_base = value; } }
        public DateTime fecha_inicio_plan { get { return _fecha_inicio_plan; } set { _fecha_inicio_plan = value; } }
        //Propiedades públicas (observación)
        public string observacion { get { return _observacion; } set { _observacion = value; } }

        public bool venta_lote { get { return _venta_lote; } }
        public int id_planpago_vigente { get { return _id_planpago_vigente; } }
        public int estado_id { get { return _estado_id; } }
        public string estado_nombre { get { return _estado_nombre; } }
        public int id_negociocontrato { get { return _id_negociocontrato; } }
        public string negocio_nombre { get { return _negocio_nombre; } }
        public int id_ultimo_pago { get { return _id_ultimo_pago; } }
        public int id_cuota_inicial { get { return _id_cuota_inicial; } }
        public int id_promotor_vigente { get { return _id_promotor_vigente; } }
        public int id_cobrador_vigente { get { return _id_cobrador_vigente; } }
        public int id_titular { get { return _id_titular; } }
        public int id_reversion { get { return _id_reversion; } }
        public decimal capital_pagado { get { return _capital_pagado; } }
        public decimal saldo_capital { get { return _saldo_capital; } }
        public decimal cuotas_pagadas { get { return _cuotas_pagadas; } }
        public string codigo_moneda { get { return _codigo_moneda; } }

        #endregion

        #region Constructores
        public contrato(int Id_contrato)
        {
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }
        public contrato(string Numero)
        {
            _numero = Numero;
            RecuperarDatos();
        }
        public contrato(int Id_contrato, string Observacion)
        {
            _id_contrato = Id_contrato;
            _observacion = Observacion;
        }
        public contrato(int Id_moneda, string Numero, bool Contado, bool Preferencial,
            decimal Precio, decimal Descuento_porcentaje, decimal Descuento_efectivo, decimal Precio_final,
            decimal Cuota_inicial, int Num_cuotas, decimal Seguro, decimal Mantenimiento_sus, decimal Interes_corriente,
            decimal Interes_penal, decimal Cuota_base, DateTime Fecha_inicio_plan, string Observacion)
        {
            _id_moneda = Id_moneda;
            _numero = Numero;
            _contado = Contado;
            _preferencial = Preferencial;
            _precio = Precio;
            _descuento_porcentaje = Descuento_porcentaje;
            _descuento_efectivo = Descuento_efectivo;
            _precio_final = Precio_final;
            _cuota_inicial = Cuota_inicial;
            _num_cuotas = Num_cuotas;
            _seguro = Seguro;
            _mantenimiento_sus = Mantenimiento_sus;
            _interes_corriente = Interes_corriente;
            _interes_penal = Interes_penal;
            _cuota_base = Cuota_base;
            _fecha_inicio_plan = Fecha_inicio_plan;
            _observacion = Observacion;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool VerificarNumero(string Numero)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_VerificarNumero");
                db1.AddInParameter(cmd, "numero", DbType.String, Numero);
                if ((int)db1.ExecuteScalar(cmd) == 0) return false;
                else return true;
            }
            catch { return true; }
        }

        public static int Estado(int Id_contrato, DateTime Fecha)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_Estado_PorFecha");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return -1; }
        }
        public static DateTime EstadoActualFecha(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_EstadoActualFecha");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (DateTime)db1.ExecuteScalar(cmd);
            }
            catch { return DateTime.Now; }
        }

        public static string Estado_string(int Id_contrato, DateTime Fecha)
        {
            string estado_contrato = "";
            switch (Estado(Id_contrato, Fecha))
            {
                case -1: estado_contrato = "Inexistente"; break;
                case 0: estado_contrato = "Preasignado"; break;
                case 1: estado_contrato = "Vigente"; break;
                case 2: estado_contrato = "Revertido"; break;
                case 3: estado_contrato = "Liquidado"; break;
            }
            return estado_contrato;
        }
        public static int UltimoPago(int Id_contrato, DateTime Fecha)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_UltimoPago_PorFecha");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int UltimoPagoMora(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_UltimoPagoMora");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int PlanPago(int Id_contrato, DateTime Fecha)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_PlanPago");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static int PlanPagoVigente(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_PlanPagoVigente");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static int IdPagoInicial(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_IdPagoInicial");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static int NegocioContrato(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_NegocioContrato_Vigente");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static bool EsContratoVenta(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_EsContratoVenta");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public static decimal InteresAcumulado(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_InteresAcumulado");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (decimal)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static int IdPorNumero(string Numero)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_IdPorNumero");
                db1.AddInParameter(cmd, "numero", DbType.String, Numero);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static void RectificarCuotaBase(int Id_contrato)
        {
            try
            {
                contrato contratoObj = new contrato(Id_contrato);
                if (contratoObj.contado == false)
                {
                    decimal Nueva_cuota_base = simular.Obtener_cuota_base(contratoObj.precio_final - contratoObj.cuota_inicial,
                        contratoObj.num_cuotas, contratoObj.seguro, contratoObj.mantenimiento_sus, contratoObj.interes_corriente);
                    if (contratoObj.cuota_base != Nueva_cuota_base)
                    {
                        DbCommand cmd = db1.GetStoredProcCommand("contrato_RectificarCuotaBase");
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                        db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, Nueva_cuota_base);
                        db1.ExecuteNonQuery(cmd);
                    }
                }
            }
            catch { }
        }

        public static bool Transferir(int Id_contrato, int Id_negocio, int Id_pago, int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_Transferir");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, Id_pago);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static DataTable TablaTransferencia(int Id_contrato, int Id_pago)
        {
            negocio_contrato nc = new negocio_contrato(contrato.NegocioContrato(Id_contrato));
            int Id_pago_elegido = Id_pago;
            decimal saldo_ultimo_pago;
            if (Id_pago_elegido > 0)
            {
                if (nc.num_pagos > 0) saldo_ultimo_pago = new pago(Id_pago_elegido).saldo;
                //if (5 > 0) saldo_ultimo_pago = new pago(Id_contrato, Id_pago_elegido).saldo;
                else saldo_ultimo_pago = nc.saldo_capital;
            }
            else saldo_ultimo_pago = nc.saldo_capital;
            decimal total_amortizacion = nc.saldo_capital - saldo_ultimo_pago;
            decimal nuevo_saldo_capital = saldo_ultimo_pago;
            decimal nuevo_saldo_costo;
            if (nc.saldo_capital > 0) nuevo_saldo_costo = nc.saldo_costo - ((total_amortizacion / nc.saldo_capital) * nc.saldo_costo);
            else nuevo_saldo_costo = 0;
            decimal amortizacion_posterior;
            if (Id_pago_elegido > 0 && nc.num_pagos > 0)
            {
                int Id_ultimo_pago = contrato.UltimoPago(Id_contrato, DateTime.Now);
                if (Id_ultimo_pago != Id_pago_elegido) amortizacion_posterior = new pago(Id_pago_elegido).saldo - new pago(Id_ultimo_pago).saldo;
                else amortizacion_posterior = 0;
            }
            //if (Id_pago_elegido > 0 && 5 > 0)
            //{
            //    decimal Id_ultimo_pago = 5;
            //    if (Id_ultimo_pago != Id_pago_elegido) amortizacion_posterior = new pago(Id_contrato, Id_pago_elegido).saldo - new pago(Id_contrato, 5).saldo;
            //    else amortizacion_posterior = 0;
            //}
            else amortizacion_posterior = 0;

            DataTable tabla = new DataTable();
            tabla.Columns.Add("tipo", typeof(string));
            tabla.Columns.Add("capital", typeof(decimal));
            tabla.Columns.Add("costo", typeof(decimal));
            tabla.Columns.Add("amortizacion", typeof(decimal));

            DataRow fila1 = tabla.NewRow();
            fila1["tipo"] = "Negocio actual:";
            fila1["capital"] = nc.saldo_capital;
            fila1["costo"] = nc.saldo_costo;
            fila1["amortizacion"] = Math.Round(total_amortizacion, 2);
            tabla.Rows.Add(fila1);

            DataRow fila2 = tabla.NewRow();
            fila2["tipo"] = "A transferir:";
            fila2["capital"] = Math.Round(nuevo_saldo_capital, 2);
            fila2["costo"] = Math.Round(nuevo_saldo_costo, 2);
            fila2["amortizacion"] = Math.Round(amortizacion_posterior, 2);
            tabla.Rows.Add(fila2);
            return tabla;
        }


        public static DataTable Lista_Por_Cliente(int Id_cliente)
        {
            //[id_contrato],[numero],[fecha],[fecha_inicial],[concepto],[titular],[estado]
            DbCommand cmd = db1.GetStoredProcCommand("contrato_Lista_Por_Cliente");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool PermitirPagosContrato(int Id_usuario, int Id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_PermitirPagosContrato");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                if ((int)db1.ExecuteScalar(cmd) != 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static bool PermitirAnulacionesContrato(int Id_usuario, int Id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_PermitirAnulacionesContrato");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                if ((int)db1.ExecuteScalar(cmd) != 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static bool HabilitarPagosContrato(int Id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_HabilitarPagosContrato");
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                if ((int)db1.ExecuteScalar(cmd) != 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public static decimal PagadoGestor(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_PagadoGestor");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (decimal)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static void NumDprsPromocion(int Id_contrato, ref int Num_dprs, ref decimal Monto_dprs)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_NumDprsPromocion");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddOutParameter(cmd, "num_dprs", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto_dprs", DbType.Double, 14);
                db1.ExecuteNonQuery(cmd);
                Num_dprs = (int)db1.GetParameterValue(cmd, "num_dprs");
                Monto_dprs = (decimal)(double)db1.GetParameterValue(cmd, "monto_dprs");
            }
            catch { }
        }

        public static string CodigoMoneda(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_CodigoMoneda");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteScalar(cmd).ToString();
            }
            catch { return "$us"; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato0", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "numero0", DbType.String, _numero);

                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_moneda", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "numero", DbType.String, 50);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "contado", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "preferencial", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "precio", DbType.Double, 14);
                db1.AddOutParameter(cmd, "descuento_porcentaje", DbType.Double, 7);
                db1.AddOutParameter(cmd, "descuento_efectivo", DbType.Double, 14);
                db1.AddOutParameter(cmd, "precio_final", DbType.Double, 14);
                db1.AddOutParameter(cmd, "cuota_inicial", DbType.Double, 14);
                db1.AddOutParameter(cmd, "num_cuotas", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "seguro", DbType.Double, 11);
                db1.AddOutParameter(cmd, "mantenimiento_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes_corriente", DbType.Double, 7);
                db1.AddOutParameter(cmd, "interes_penal", DbType.Double, 7);
                db1.AddOutParameter(cmd, "cuota_base", DbType.Double, 14);
                db1.AddOutParameter(cmd, "fecha_inicio_plan", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "observacion", DbType.String, 2000);

                db1.AddOutParameter(cmd, "venta_lote", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "id_planpago_vigente", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "estado_id", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 15);
                db1.AddOutParameter(cmd, "id_negociocontrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "negocio_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "id_ultimo_pago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_cuota_inicial", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_promotor_vigente", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_cobrador_vigente", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_titular", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_reversion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "capital_pagado", DbType.Double, 14);
                db1.AddOutParameter(cmd, "saldo_capital", DbType.Double, 14);
                db1.AddOutParameter(cmd, "cuotas_pagadas", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_moneda = (int)db1.GetParameterValue(cmd, "id_moneda");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _numero = (string)db1.GetParameterValue(cmd, "numero");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _contado = (bool)db1.GetParameterValue(cmd, "contado");
                _preferencial = (bool)db1.GetParameterValue(cmd, "preferencial");

                _precio = (decimal)(double)db1.GetParameterValue(cmd, "precio");
                _descuento_porcentaje = (decimal)(double)db1.GetParameterValue(cmd, "descuento_porcentaje");
                _descuento_efectivo = (decimal)(double)db1.GetParameterValue(cmd, "descuento_efectivo");
                _precio_final = (decimal)(double)db1.GetParameterValue(cmd, "precio_final");
                _cuota_inicial = (decimal)(double)db1.GetParameterValue(cmd, "cuota_inicial");
                _num_cuotas = (int)db1.GetParameterValue(cmd, "num_cuotas");

                _seguro = (decimal)(double)db1.GetParameterValue(cmd, "seguro");
                _mantenimiento_sus = (decimal)(double)db1.GetParameterValue(cmd, "mantenimiento_sus");
                _interes_corriente = (decimal)(double)db1.GetParameterValue(cmd, "interes_corriente");
                _interes_penal = (decimal)(double)db1.GetParameterValue(cmd, "interes_penal");
                _cuota_base = (decimal)(double)db1.GetParameterValue(cmd, "cuota_base");
                _fecha_inicio_plan = (DateTime)db1.GetParameterValue(cmd, "fecha_inicio_plan");
                _observacion = (string)db1.GetParameterValue(cmd, "observacion");

                _venta_lote = (bool)db1.GetParameterValue(cmd, "venta_lote");
                _id_planpago_vigente = (int)db1.GetParameterValue(cmd, "id_planpago_vigente");
                _estado_id = (int)db1.GetParameterValue(cmd, "estado_id");
                _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
                _id_negociocontrato = (int)db1.GetParameterValue(cmd, "id_negociocontrato");
                _negocio_nombre = (string)db1.GetParameterValue(cmd, "negocio_nombre");
                _id_ultimo_pago = (int)db1.GetParameterValue(cmd, "id_ultimo_pago");
                _id_cuota_inicial = (int)db1.GetParameterValue(cmd, "id_cuota_inicial");
                _id_promotor_vigente = (int)db1.GetParameterValue(cmd, "id_promotor_vigente");
                _id_cobrador_vigente = (int)db1.GetParameterValue(cmd, "id_cobrador_vigente");
                _id_titular = (int)db1.GetParameterValue(cmd, "id_titular");
                _id_reversion = (int)db1.GetParameterValue(cmd, "id_reversion");
                _capital_pagado = (decimal)(double)db1.GetParameterValue(cmd, "capital_pagado");
                _saldo_capital = (decimal)(double)db1.GetParameterValue(cmd, "saldo_capital");
                _cuotas_pagadas = (int)db1.GetParameterValue(cmd, "cuotas_pagadas");
                _codigo_moneda = (string)db1.GetParameterValue(cmd, "codigo_moneda");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_Insertar");
                db1.AddInParameter(cmd, "id_moneda", DbType.Int32, _id_moneda);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "numero", DbType.String, _numero);
                db1.AddInParameter(cmd, "contado", DbType.Boolean, _contado);
                db1.AddInParameter(cmd, "preferencial", DbType.Boolean, _preferencial);

                db1.AddInParameter(cmd, "precio", DbType.Decimal, _precio);
                db1.AddInParameter(cmd, "descuento_porcentaje", DbType.Decimal, _descuento_porcentaje);
                db1.AddInParameter(cmd, "descuento_efectivo", DbType.Decimal, _descuento_efectivo);
                db1.AddInParameter(cmd, "precio_final", DbType.Decimal, _precio_final);
                db1.AddInParameter(cmd, "cuota_inicial", DbType.Decimal, _cuota_inicial);
                db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, _num_cuotas);

                db1.AddInParameter(cmd, "seguro", DbType.Decimal, _seguro);
                db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, _mantenimiento_sus);
                db1.AddInParameter(cmd, "interes_corriente", DbType.Decimal, _interes_corriente);
                db1.AddInParameter(cmd, "interes_penal", DbType.Decimal, _interes_penal);
                db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, _cuota_base);
                db1.AddInParameter(cmd, "fecha_inicio_plan", DbType.DateTime, _fecha_inicio_plan);
                db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
                _id_contrato = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool CambiarTipoCliente(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_CambiarTipoCliente");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool ActualizarObservacion()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_ActualizarObservacion");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos para la búsqueda de contratos y clientes

        public static DataTable BusquedaContratoCliente(bool Buscar_contrato, string Numero, string Ci, string Nombres)
        {
            //[id],[texto]
            DbCommand cmd = db1.GetStoredProcCommand("contrato_BusquedaContratoCliente");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "buscar_contrato", DbType.Boolean, Buscar_contrato);
            db1.AddInParameter(cmd, "numero", DbType.String, Numero);
            db1.AddInParameter(cmd, "ci", DbType.String, Ci);
            db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool BusquedaExactaVerificacion(bool Buscar_contrato, string Numero, string Ci, string Nombres)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_BusquedaExactaVerificacion");
                db1.AddInParameter(cmd, "buscar_contrato", DbType.Boolean, Buscar_contrato);
                db1.AddInParameter(cmd, "numero", DbType.String, Numero);
                db1.AddInParameter(cmd, "ci", DbType.String, Ci);
                db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
                if ((int)db1.ExecuteScalar(cmd) == 1) return true;
                else return false;
            }
            catch { return false; }
        }
        #endregion
    }
}