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
using System.Collections.Generic;

/// <summary>
/// Summary description for bnb_pago_pendiente
/// </summary>
namespace terrasur
{
    public class bnb_pago_pendiente
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades privadas
        private int _id_pagopendiente = 0;
        private int _id_contrato = 0;
        private int _id_periodo = 0;
        private int _id_ultimopago = 0;
        private string _codigo_deudor = "";
        private int _periodo = 0;
        private bool _activo = false;
        private bool _cobrado = false;
        private int _cobrado_id_conciliacion = 0;
        private int _cobrado_id_pago = 0;

        private int _id_tipopago = 0;
        private int _id_planpago = 0;
        private DateTime _fecha = DateTime.Parse("01/01/1900");
        private DateTime _fecha_proximo = DateTime.Parse("01/01/1900");
        private int _num_cuotas = 0;
        private decimal _monto_pago = 0;
        private decimal _seguro = 0;
        private DateTime _seguro_fecha = DateTime.Parse("01/01/1900");
        private int _seguro_meses = 0;
        private decimal _mantenimiento_sus = 0;
        private DateTime _mantenimiento_fecha = DateTime.Parse("01/01/1900");
        private int _mantenimiento_meses = 0;
        private decimal _interes = 0;
        private DateTime _interes_fecha = DateTime.Parse("01/01/1900");
        private int _interes_dias = 0;
        private int _interes_dias_total = 0;
        private decimal _amortizacion = 0;
        private decimal _saldo = 0;
        private bool _anulado = false;
        #endregion

        #region Propiedades públicas
        public int id_pagopendiente { get { return _id_pagopendiente; } set { _id_pagopendiente = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_periodo { get { return _id_periodo; } set { _id_periodo = value; } }
        public int id_ultimopago { get { return _id_ultimopago; } set { _id_ultimopago = value; } }
        public string codigo_deudor { get { return _codigo_deudor; } set { _codigo_deudor = value; } }
        public int periodo { get { return _periodo; } set { _periodo = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public bool cobrado { get { return _cobrado; } set { _cobrado = value; } }
        public int cobrado_id_conciliacion { get { return _cobrado_id_conciliacion; } set { _cobrado_id_conciliacion = value; } }
        public int cobrado_id_pago { get { return _cobrado_id_pago; } set { _cobrado_id_pago = value; } }

        public int id_tipopago { get { return _id_tipopago; } set { _id_tipopago = value; } }
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
        #endregion

        #region Constructores
        public bnb_pago_pendiente(int Id_pagopendiente, int Id_contrato, int Id_periodo, int Id_ultimopago, string Codigo_deudor, int Periodo, bool Activo, bool Cobrado, int Cobrado_id_conciliacion, int Cobrado_id_pago,
            int Id_tipopago, int Id_planpago, DateTime Fecha, DateTime Fecha_proximo, int Num_cuotas, decimal Monto_pago, decimal Seguro, DateTime Seguro_fecha, int Seguro_meses, decimal Mantenimiento_sus, DateTime Mantenimiento_fecha, int Mantenimiento_meses, decimal Interes, DateTime Interes_fecha, int Interes_dias, int Interes_dias_total, decimal Amortizacion, decimal Saldo, bool Anulado)
        {
            _id_pagopendiente = Id_pagopendiente;
            _id_contrato = Id_contrato;
            _id_periodo = Id_periodo;
            _id_ultimopago = Id_ultimopago;
            _codigo_deudor = Codigo_deudor;
            _periodo = Periodo;
            _activo = Activo;
            _cobrado = Cobrado;
            _cobrado_id_conciliacion = Cobrado_id_conciliacion;
            _cobrado_id_pago = Cobrado_id_pago;

            _id_tipopago = Id_tipopago;
            _id_planpago = Id_planpago;
            _fecha = Fecha;
            _fecha_proximo = Fecha_proximo;
            _num_cuotas = Num_cuotas;
            _monto_pago = Monto_pago;
            _seguro = Seguro;
            _seguro_fecha = Seguro_fecha;
            _seguro_meses = Seguro_meses;
            _mantenimiento_sus = Mantenimiento_sus;
            _mantenimiento_fecha = Mantenimiento_fecha;
            _mantenimiento_meses = Mantenimiento_meses;
            _interes = Interes;
            _interes_fecha = Interes_fecha;
            _interes_dias = Interes_dias;
            _interes_dias_total = Interes_dias_total;
            _amortizacion = Amortizacion;
            _saldo = Saldo;
            _anulado = Anulado;
        }
        public bnb_pago_pendiente(int Id_pagopendiente, int Id_contrato, int Id_periodo, int Id_ultimopago, string Codigo_deudor, int Periodo, bool Activo, bool Cobrado, int Cobrado_id_conciliacion, int Cobrado_id_pago,
            int Id_tipopago, int Id_planpago, sim_pago pago_simulado)
        {
            _id_pagopendiente = Id_pagopendiente;
            _id_contrato = Id_contrato;
            _id_periodo = Id_periodo;
            _id_ultimopago = Id_ultimopago;
            _codigo_deudor = Codigo_deudor;
            _periodo = Periodo;
            _activo = Activo;
            _cobrado = Cobrado;
            _cobrado_id_conciliacion = Cobrado_id_conciliacion;
            _cobrado_id_pago = Cobrado_id_pago;

            _id_tipopago = Id_tipopago;
            _id_planpago = Id_planpago;
            _fecha = pago_simulado.fecha;
            _fecha_proximo = pago_simulado.fecha_proximo;
            _num_cuotas = pago_simulado.num_cuotas;
            _monto_pago = pago_simulado.monto_pago;
            _seguro = pago_simulado.seguro;
            _seguro_fecha = pago_simulado.seguro_fecha;
            _seguro_meses = pago_simulado.seguro_meses;
            _mantenimiento_sus = pago_simulado.mantenimiento_sus;
            _mantenimiento_fecha = pago_simulado.mantenimiento_fecha;
            _mantenimiento_meses = pago_simulado.mantenimiento_meses;
            _interes = pago_simulado.interes;
            _interes_fecha = pago_simulado.interes_fecha;
            _interes_dias = pago_simulado.interes_dias;
            _interes_dias_total = pago_simulado.interes_dias_total;
            _amortizacion = pago_simulado.amortizacion;
            _saldo = pago_simulado.saldo;
            _anulado = false;
        }


        #endregion

        #region Métodos que NO requieren constructor

        public static bool GenerarPagosPendientes(int Id_institucion, DateTime Fecha_Evaluacion, string Cadena_contratos, int context_id_usuario)
        {
            bool correcto = true;
            if (Cadena_contratos.Trim() != "") Cadena_contratos = "," + Cadena_contratos.Trim() + ",";

            bnb_archivo aObj = new bnb_archivo(Id_institucion, Fecha_Evaluacion, "C", "E", "1");
            if (aObj.Insertar(context_id_usuario) == true && aObj.id_archivo > 0)
            {
                //Se realizan la bajas necesarias
                correcto = BajaContratosNoCobrar(Id_institucion, aObj.id_archivo, Cadena_contratos, context_id_usuario);
                if (correcto == true)
                {
                    //Se realizan las Altas y Moficicaciones necesarias
                    DataTable TablaContrato = TablaContratosCobrar(Id_institucion, Cadena_contratos, Fecha_Evaluacion);
                    DataTable TablaPagosPendientesActuales = TablaPagosPendientesActivos(Id_institucion, Cadena_contratos);
                    foreach (DataRow fila_contrato in TablaContrato.Rows)
                    {
                        //Se obtienen los pagos pendientes del contrato
                        int id_contrato = (int)fila_contrato["id_contrato"];
                        List<bnb_pago_pendiente> ListaPagoPendienteNuevos = GenerarListaPagoPendienteNuevos(fila_contrato, Fecha_Evaluacion);
                        List<bnb_pago_pendiente> ListaPagoPendienteActual = GenerarListaPagoPendienteActual(id_contrato, TablaPagosPendientesActuales);

                        //Primero se registran y actualizan todos los pagos nuevos
                        foreach (bnb_pago_pendiente nuevo in ListaPagoPendienteNuevos)
                        {
                            //Se busca el pago nuevo en la lista de pagos actuales
                            int index_lista_actual = BuscarPagoPorPeriodoEnLista(nuevo, ListaPagoPendienteActual);
                            if (index_lista_actual >= 0) nuevo.id_pagopendiente = ListaPagoPendienteActual[index_lista_actual].id_pagopendiente;

                            //Se inserta o actualiza el nuevo pagos simulado
                            if (bnb_pago_pendiente.InsertarActualizar(nuevo, aObj.id_archivo) == false)
                            {
                                correcto = false;
                            }
                        }
                        //Finalmente se verifica si alguno de los pagos actuales debe ser dado de baja
                        foreach (bnb_pago_pendiente actual in ListaPagoPendienteActual)
                        {
                            if (BuscarPagoPorIdEnLista(actual, ListaPagoPendienteNuevos) < 0)
                            {
                                //Se da de baja el pago pendiente que ya no se utiliza
                                if (bnb_pago_pendiente.Eliminar(actual.id_pagopendiente, aObj.id_archivo) == false)
                                {
                                    correcto = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    correcto = false;
                }
                if (aObj.Actualizar() == false)
                {
                    correcto = false;
                }
            }
            else
            {
                correcto = false;
            }
            return correcto;
        }

        protected static bool BajaContratosNoCobrar(int Id_institucion, int Id_archivo, string Cadena_contratos, int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_pago_pendiente_BajaContratosNoCobrar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, Id_archivo);
                db1.AddInParameter(cmd, "cadena_contratos", DbType.String, Cadena_contratos);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        protected static bool InsertarActualizar(bnb_pago_pendiente item, int id_archivo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_pago_pendiente_InsertarActualizar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, id_archivo);

                db1.AddInParameter(cmd, "id_pagopendiente", DbType.Int32, item.id_pagopendiente);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, item.id_contrato);
                db1.AddInParameter(cmd, "id_periodo", DbType.Int32, item.id_periodo);
                db1.AddInParameter(cmd, "id_ultimopago", DbType.Int32, item.id_ultimopago);
                db1.AddInParameter(cmd, "codigo_deudor", DbType.String, item.codigo_deudor);
                db1.AddInParameter(cmd, "periodo", DbType.Int32, item.periodo);
                db1.AddInParameter(cmd, "cobrado", DbType.Boolean, item.cobrado);
                db1.AddInParameter(cmd, "cobrado_id_conciliacion", DbType.Int32, item.cobrado_id_conciliacion);
                db1.AddInParameter(cmd, "cobrado_id_pago", DbType.Int32, item.cobrado_id_pago);

                db1.AddInParameter(cmd, "id_tipopago", DbType.Int32, item.id_tipopago);
                db1.AddInParameter(cmd, "id_planpago", DbType.Int32, item.id_planpago);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, item.fecha);
                db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, item.fecha_proximo);
                db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, item.num_cuotas);
                db1.AddInParameter(cmd, "monto_pago", DbType.Decimal, item.monto_pago);
                db1.AddInParameter(cmd, "seguro", DbType.Decimal, item.seguro);
                db1.AddInParameter(cmd, "seguro_fecha", DbType.DateTime, item.seguro_fecha);
                db1.AddInParameter(cmd, "seguro_meses", DbType.Int32, item.seguro_meses);
                db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, item.mantenimiento_sus);
                db1.AddInParameter(cmd, "mantenimiento_fecha", DbType.DateTime, item.mantenimiento_fecha);
                db1.AddInParameter(cmd, "mantenimiento_meses", DbType.Int32, item.mantenimiento_meses);
                db1.AddInParameter(cmd, "interes", DbType.Decimal, item.interes);
                db1.AddInParameter(cmd, "interes_fecha", DbType.DateTime, item.interes_fecha);
                db1.AddInParameter(cmd, "interes_dias", DbType.Int32, item.interes_dias);
                db1.AddInParameter(cmd, "interes_dias_total", DbType.Int32, item.interes_dias_total);
                db1.AddInParameter(cmd, "amortizacion", DbType.Decimal, item.amortizacion);
                db1.AddInParameter(cmd, "saldo", DbType.Decimal, item.saldo);
                db1.AddInParameter(cmd, "anulado", DbType.Boolean, item.anulado);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        protected static bool Eliminar(int id_pagopendiente, int id_archivo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_pago_pendiente_Eliminar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_pagopendiente", DbType.Int32, id_pagopendiente);
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, id_archivo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        protected static DataTable TablaContratosCobrar(int Id_institucion, string Cadena_contratos, DateTime Fecha)
        {
            //[id_contrato],[id_cliente],[numero_contrato],[codigo_deudor],[id_ultimopago],[preferencial],[id_planpago],[id_tipopago_normal],[id_tipopago_segunplan]
            //[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan]
            //[p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_pago_pendiente_ListaContratosCobrar");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
            db1.AddInParameter(cmd, "cadena_contratos", DbType.String, Cadena_contratos);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        protected static DataTable TablaPagosPendientesActivos(int Id_institucion, string Cadena_contratos)
        {
            //[id_pagopendiente],[id_contrato],[id_periodo],[id_ultimopago],[codigo_deudor],[periodo],[activo],[cobrado],[cobrado_id_conciliacion],[cobrado_id_pago],
            //[id_tipopago],[id_planpago],[fecha],[fecha_proximo],[num_cuotas],[monto_pago],[seguro],[seguro_fecha],[seguro_meses],[mantenimiento_sus],[mantenimiento_fecha],[mantenimiento_meses],[interes],[interes_fecha],[interes_dias],[interes_dias_total],[amortizacion],[saldo],[anulado]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_pago_pendiente_ListaPagosPendientesActivos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
            db1.AddInParameter(cmd, "cadena_contratos", DbType.String, Cadena_contratos);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        protected static List<bnb_pago_pendiente> GenerarListaPagoPendienteActual(int id_contrato, DataTable TablaPagosPendientesActuales)
        {
            List<bnb_pago_pendiente> lista = new List<bnb_pago_pendiente>();
            foreach (DataRow fila in TablaPagosPendientesActuales.Rows)
            {
                if (((int)fila["id_contrato"]) == id_contrato)
                {
                    lista.Add(new bnb_pago_pendiente(
                        (int)fila["id_pagopendiente"],
                        (int)fila["id_contrato"],
                        (int)fila["id_periodo"],
                        (int)fila["id_ultimopago"],
                        fila["codigo_deudor"].ToString(),
                        (int)fila["periodo"],
                        (bool)fila["activo"],
                        (bool)fila["cobrado"],
                        (int)fila["cobrado_id_conciliacion"],
                        (int)fila["cobrado_id_pago"],

                        (int)fila["id_tipopago"],
                        (int)fila["id_planpago"],
                        (DateTime)fila["fecha"],
                        (DateTime)fila["fecha_proximo"],
                        (int)fila["num_cuotas"],
                        (decimal)fila["monto_pago"],
                        (decimal)fila["seguro"],
                        (DateTime)fila["seguro_fecha"],
                        (int)fila["seguro_meses"],
                        (decimal)fila["mantenimiento_sus"],
                        (DateTime)fila["mantenimiento_fecha"],
                        (int)fila["mantenimiento_meses"],
                        (decimal)fila["interes"],
                        (DateTime)fila["interes_fecha"],
                        (int)fila["interes_dias"],
                        (int)fila["interes_dias_total"],
                        (decimal)fila["amortizacion"],
                        (decimal)fila["saldo"],
                        (bool)fila["anulado"]));
                }
            }
            return lista;
        }
        protected static List<bnb_pago_pendiente> GenerarListaPagoPendienteNuevos(DataRow fila_contrato, DateTime Fecha_evaluacion)
        {
            //[id_contrato],[id_cliente],[numero_contrato],[codigo_deudor],[id_ultimopago],[preferencial],[id_planpago],[id_tipopago_normal],[id_tipopago_segunplan]
            int id_contrato = (int)fila_contrato["id_contrato"];
            int id_cliente = (int)fila_contrato["id_cliente"];
            string numero_contrato = fila_contrato["numero_contrato"].ToString();
            string codigo_deudor = fila_contrato["codigo_deudor"].ToString();
            int id_ultimopago = (int)fila_contrato["id_ultimopago"];
            bool preferencial = (bool)fila_contrato["preferencial"];
            int id_planpago = (int)fila_contrato["id_planpago"];
            int id_tipopago_normal = (int)fila_contrato["id_tipopago_normal"];
            int id_tipopago_segunplan = (int)fila_contrato["id_tipopago_segunplan"];
            //[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan]
            decimal pp_seguro = (decimal)fila_contrato["seguro"];
            decimal pp_mantenimiento_sus = (decimal)fila_contrato["mantenimiento_sus"];
            decimal pp_interes_corriente = (decimal)fila_contrato["interes_corriente"];
            decimal pp_cuota_base = (decimal)fila_contrato["cuota_base"];
            DateTime pp_fecha_inicio_plan = (DateTime)fila_contrato["fecha_inicio_plan"];
            //[p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            sim_pago ultimo_pago = new sim_pago((DateTime)fila_contrato["p_fecha"], (DateTime)fila_contrato["p_fecha_proximo"], (int)fila_contrato["p_num_cuotas"], (decimal)fila_contrato["p_seguro"], (int)fila_contrato["p_seguro_meses"], (DateTime)fila_contrato["p_seguro_fecha"], (decimal)fila_contrato["p_mantenimiento_sus"], (int)fila_contrato["p_mantenimiento_meses"], (DateTime)fila_contrato["p_mantenimiento_fecha"], (decimal)fila_contrato["p_interes"], (int)fila_contrato["p_interes_dias"], (int)fila_contrato["p_interes_dias_total"], (DateTime)fila_contrato["p_interes_fecha"], (decimal)fila_contrato["p_monto_pago"], (decimal)fila_contrato["p_amortizacion"], (decimal)fila_contrato["p_saldo"]);

            //Ahora se simulan los pagos restantes
            List<bnb_pago_pendiente> ListaPagosPendientesSimulados = new List<bnb_pago_pendiente>();
            //Se verifica que el contrato NO haya pagado intereses en el periodo de la fecha de evaluación
            int periodo_inicio = PeriodoDeFecha(ultimo_pago.interes_fecha);
            int periodo_fin = PeriodoDeFecha(Fecha_evaluacion);
            if (periodo_inicio < periodo_fin)
            {
                //En caso de ser necesario se incrementa la fecha de próximo pago en un mes (cuando la fecha de próximo pago esta en el mismo mes de la fecha de cobro de intereses)
                if (PeriodoDeFecha(ultimo_pago.fecha_proximo) == PeriodoDeFecha(ultimo_pago.interes_fecha)) ultimo_pago.fecha_proximo = ultimo_pago.fecha_proximo.AddMonths(1);
                //Se determina el número de pagos que adeuda el contrato
                int num_pagos_pendientes = num_periodos(ultimo_pago.interes_fecha, Fecha_evaluacion);

                //Se realiza la simulación para cada periodo
                DateTime aux_fecha_periodo = ultimo_pago.interes_fecha.AddDays(ultimo_pago.interes_fecha.Day * (-1)).AddDays(1).AddMonths(1);

                //Para Renacer se toman todos los clientes como si fueran preferenciales (y se quita o comenta el "else")
                if (preferencial == true)
                {
                    for (int j = 0; j < num_pagos_pendientes; j++)
                    {
                        if (ultimo_pago.saldo > 0)
                        {
                            //Se simula el pago siguiente
                            sim_pago nuevo_pago = new sim_pago(ultimo_pago, ultimo_pago.fecha_proximo, ultimo_pago.fecha_proximo, ultimo_pago.fecha_proximo, ultimo_pago.fecha_proximo, 1,
                            pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
                            nuevo_pago.fecha = Fecha_evaluacion;

                            //Se registra el pago siguiente en la ListaPagosPendientesSimulados
                            int periodo = PeriodoDeFecha(aux_fecha_periodo);
                            ListaPagosPendientesSimulados.Add(new bnb_pago_pendiente(0, id_contrato, 0, id_ultimopago, codigo_deudor, periodo, true, false, 0, 0, id_tipopago_segunplan, id_planpago, nuevo_pago));

                            //Se preparan los datos para la siguiente simulación
                            ultimo_pago = nuevo_pago;
                            aux_fecha_periodo = aux_fecha_periodo.AddMonths(1);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < num_pagos_pendientes; j++)
                    {
                        if (ultimo_pago.saldo > 0)
                        {
                            //Se simula el pago siguiente
                            sim_pago nuevo_pago = new sim_pago(ultimo_pago, Fecha_evaluacion, Fecha_evaluacion, Fecha_evaluacion, Fecha_evaluacion, 0,
                            pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
                            nuevo_pago.num_cuotas = 1;
                            nuevo_pago.fecha = Fecha_evaluacion;

                            //Se registra el pago siguiente en la ListaPagosPendientesSimulados
                            int periodo = PeriodoDeFecha(aux_fecha_periodo);
                            ListaPagosPendientesSimulados.Add(new bnb_pago_pendiente(0, id_contrato, 0, id_ultimopago, codigo_deudor, periodo, true, false, 0, 0, id_tipopago_normal, id_planpago, nuevo_pago));

                            //Se preparan los datos para la siguiente simulación
                            ultimo_pago = nuevo_pago;
                            aux_fecha_periodo = aux_fecha_periodo.AddMonths(1);
                        }
                    }
                }

            }
            return ListaPagosPendientesSimulados;
        }
        protected static int BuscarPagoPorPeriodoEnLista(bnb_pago_pendiente item, List<bnb_pago_pendiente> Lista)
        {
            int index = -1;
            for (int j = 0; j < Lista.Count; j++)
            {
                if (item.periodo == Lista[j].periodo)
                {
                    index = j;
                    break;
                }
            }
            return index;
        }
        protected static int BuscarPagoPorIdEnLista(bnb_pago_pendiente item, List<bnb_pago_pendiente> Lista)
        {
            int index = -1;
            for (int j = 0; j < Lista.Count; j++)
            {
                if (item.id_pagopendiente == Lista[j].id_pagopendiente)
                {
                    index = j;
                    break;
                }
            }
            return index;
        }

        protected static int PeriodoDeFecha(DateTime Fecha) { return (Fecha.Year * 100) + Fecha.Month; }
        protected static int num_periodos(DateTime inicio, DateTime fin)
        {
            DateTime aux_inicio = DateTime.Parse("01/" + inicio.Month.ToString() + "/" + inicio.Year.ToString());
            DateTime aux_fin = DateTime.Parse("01/" + fin.Month.ToString() + "/" + fin.Year.ToString());
            int num = 0;
            while (aux_inicio < aux_fin)
            {
                num = num + 1;
                aux_inicio = aux_inicio.AddMonths(1);
            }
            return num;
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion


    }
}