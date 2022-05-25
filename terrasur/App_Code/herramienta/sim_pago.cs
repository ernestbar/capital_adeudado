using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for sim_pago
/// </summary>
namespace terrasur
{
    public class sim_pago
    {
        #region Propiedades
        // Propiedades privadas
        private DateTime _fecha;
        private DateTime _fecha_proximo;
        private int _num_cuotas = 0;

        private decimal _seguro = 0;
        private DateTime _seguro_fecha;
        private int _seguro_meses = 0;

        private decimal _mantenimiento_sus = 0;
        private DateTime _mantenimiento_fecha;
        private int _mantenimiento_meses = 0;

        private decimal _interes = 0;
        private DateTime _interes_fecha;
        private int _interes_dias = 0;
        private int _interes_dias_total = 0;

        private decimal _monto_pago = 0;
        private decimal _amortizacion = 0;
        private decimal _saldo = 0;

        private int _anterior_num_pagos = 0;
        private int _anterior_num_cuotas = 0;

        // Propiedades públicas
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

        public int anterior_num_pagos { get { return _anterior_num_pagos; } set { _anterior_num_pagos = value; } }
        public int anterior_num_cuotas { get { return _anterior_num_cuotas; } set { _anterior_num_cuotas = value; } }
        #endregion

        #region Constructores
        //public sim_pago(DateTime Fecha, DateTime Fecha_proximo, int Num_cuotas, 
        //    decimal Seguro, int Seguro_meses, DateTime Seguro_fecha,
        //    decimal Mantenimiento_sus, int Mantenimiento_meses, DateTime Mantenimiento_fecha,
        //    decimal Interes, int Interes_dias, int Interes_dias_total, DateTime Interes_fecha,
        //    decimal Monto_pago, decimal Amortizacion, decimal Saldo,
        //    int Anterior_num_pagos, int Anterior_num_cuotas)
        //{
        //    this.fecha = Fecha;
        //    this.fecha_proximo = Fecha_proximo;
        //    this.num_cuotas = Num_cuotas;
        //    this.seguro = Seguro;
        //    this.seguro_meses = Seguro_meses;
        //    this.seguro_fecha = Seguro_fecha;
        //    this.mantenimiento_sus = Mantenimiento_sus;
        //    this.mantenimiento_meses = Mantenimiento_meses;
        //    this.mantenimiento_fecha = Mantenimiento_fecha;
        //    this.interes = Interes;
        //    this.interes_dias = Interes_dias;
        //    this.interes_dias_total = Interes_dias_total;
        //    this.interes_fecha = Interes_fecha;
        //    this.monto_pago = Monto_pago;
        //    this.amortizacion = Amortizacion;
        //    this.saldo = Saldo;

        //    this.anterior_num_pagos = real_pago.anterior_num_pagos;
        //    this.anterior_num_cuotas = real_pago.anterior_num_cuotas;

        //}

        public sim_pago(DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
            , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
            , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
        {
            this.fecha = p_fecha;
            this.fecha_proximo = p_fecha_proximo;
            this.num_cuotas = p_num_cuotas;
            this.seguro = p_seguro;
            this.seguro_meses = p_seguro_meses;
            this.seguro_fecha = p_seguro_fecha;
            this.mantenimiento_sus = p_mantenimiento_sus;
            this.mantenimiento_meses = p_mantenimiento_meses;
            this.mantenimiento_fecha = p_mantenimiento_fecha;
            this.interes = p_interes;
            this.interes_dias = p_interes_dias;
            this.interes_dias_total = p_interes_dias_total;
            this.interes_fecha = p_interes_fecha;
            this.monto_pago = p_monto_pago;
            this.amortizacion = p_amortizacion;
            this.saldo = p_saldo;

            this.anterior_num_pagos = 0;
            this.anterior_num_cuotas = 0;
        }

        //Contrctor para construir un PAGO SIMULADO a partir de un pago REAL
        public sim_pago(int Id_pago)
        {
            pago real_pago = new pago(Id_pago);
            this.fecha = real_pago.fecha;
            this.fecha_proximo = real_pago.fecha_proximo;
            this.num_cuotas = real_pago.num_cuotas;
            this.seguro = real_pago.seguro;
            this.seguro_meses = real_pago.seguro_meses;
            this.seguro_fecha = real_pago.seguro_fecha;
            this.mantenimiento_sus = real_pago.mantenimiento_sus;
            this.mantenimiento_meses = real_pago.mantenimiento_meses;
            this.mantenimiento_fecha = real_pago.mantenimiento_fecha;
            this.interes = real_pago.interes;
            this.interes_dias = real_pago.interes_dias;
            this.interes_dias_total = real_pago.interes_dias_total;
            this.interes_fecha = real_pago.interes_fecha;
            this.monto_pago = real_pago.monto_pago;
            this.amortizacion = real_pago.amortizacion;
            this.saldo = real_pago.saldo;
            
            this.anterior_num_pagos = real_pago.anterior_num_pagos;
            this.anterior_num_cuotas = real_pago.anterior_num_cuotas;
        }

        //Contructor para simular la Cuota Inicial (Simulador)
        public sim_pago(decimal Saldo, decimal Cuota_inicial, DateTime Fecha_pago, DateTime Fecha_inicio_plan)
        {
            this.fecha = Fecha_pago;
            this.fecha_proximo = Fecha_inicio_plan.AddMonths(1);
            this.num_cuotas = 0;
            this.seguro = 0;
            this.seguro_meses = 0;
            this.seguro_fecha = Fecha_inicio_plan;
            this.mantenimiento_sus = 0;
            this.mantenimiento_meses = 0;
            this.mantenimiento_fecha = Fecha_inicio_plan;
            this.interes = 0;
            this.interes_dias = 0;
            this.interes_dias_total = 0;
            this.interes_fecha = Fecha_inicio_plan;
            this.monto_pago = Cuota_inicial;
            this.amortizacion = Cuota_inicial;
            this.saldo = Saldo - Cuota_inicial;

            this.anterior_num_pagos = 0;
            this.anterior_num_cuotas = 0;
        }

        //Constructor para simular un Pago Normal (Simulador)
        public sim_pago(sim_pago anterior_pago,
            DateTime Fecha_pago, int Num_cuotas, decimal Monto_pago, DateTime Fecha_inicio_plan,
            decimal Seguro_tasa_mensual, decimal Mantenimiento_sus_mensual, decimal Interes_tasa_anual)
        {
            this.anterior_num_pagos = anterior_pago.anterior_num_pagos + 1;
            this.anterior_num_cuotas = anterior_pago.anterior_num_cuotas + anterior_pago.num_cuotas;
            GenerarPago(Fecha_pago, Fecha_pago, Fecha_pago, Fecha_pago,
                Num_cuotas, Monto_pago, anterior_pago.saldo,
                Fecha_inicio_plan, anterior_pago.fecha_proximo,
                anterior_pago.seguro_fecha, Seguro_tasa_mensual,
                anterior_pago.mantenimiento_fecha, Mantenimiento_sus_mensual,
                anterior_pago.interes_fecha, Interes_tasa_anual);
        }

        public sim_pago(sim_pago anterior_pago, DateTime Fecha_pago,
            DateTime Fecha_cobro_seguro, DateTime Fecha_cobro_mantenimiento, DateTime Fecha_cobro_interes,
            int Num_cuotas, decimal Monto_pago, DateTime Fecha_inicio_plan,
            decimal Seguro_tasa_mensual, decimal Mantenimiento_sus_mensual, decimal Interes_tasa_anual)
        {
            this.anterior_num_pagos = anterior_pago.anterior_num_pagos + 1;
            this.anterior_num_cuotas = anterior_pago.anterior_num_cuotas + anterior_pago.num_cuotas;
            GenerarPago(Fecha_pago, Fecha_cobro_seguro, Fecha_cobro_mantenimiento, Fecha_cobro_interes,
                Num_cuotas, Monto_pago, anterior_pago.saldo,
                Fecha_inicio_plan, anterior_pago.fecha_proximo,
                anterior_pago.seguro_fecha, Seguro_tasa_mensual,
                anterior_pago.mantenimiento_fecha, Mantenimiento_sus_mensual,
                anterior_pago.interes_fecha, Interes_tasa_anual);
        }

        #endregion

        #region Métodos que NO requieren constructor
        #endregion

        #region Métodos que requieren constructor

        private void GenerarPago(DateTime Fecha_pago,
            DateTime Fecha_cobro_seguro, DateTime Fecha_cobro_mantenimiento, DateTime Fecha_cobro_interes,
            int Num_cuotas, decimal Monto_pago, decimal Saldo,
            DateTime Fecha_inicio_plan, DateTime Fecha_proximo_pago,
            DateTime Seguro_fecha, decimal Seguro_tasa_mensual,
            DateTime Mantenimiento_fecha, decimal Mantenimiento_sus_mensual,
            DateTime Interes_fecha, decimal Interes_tasa_anual)
        {
            this.fecha = Fecha_pago;
            this.num_cuotas = Num_cuotas;

            decimal aux_Monto_pago = Monto_pago;
            //Primero: Seguro de desgravamen
            CobrarSeguro(Saldo, aux_Monto_pago, Fecha_cobro_seguro, Seguro_fecha, Seguro_tasa_mensual);
            this.seguro = Math.Round(this.seguro, 2);
            aux_Monto_pago -= this.seguro;
            //Segundo: Cuota de mantenimiento
            CobrarMantenimiento(aux_Monto_pago, Fecha_cobro_mantenimiento, Mantenimiento_fecha, Mantenimiento_sus_mensual);
            this.mantenimiento_sus = Math.Round(this.mantenimiento_sus, 2);
            aux_Monto_pago -= this.mantenimiento_sus;
            //Tercero: Interés corriente
            CobrarInteres(Saldo, aux_Monto_pago, Fecha_cobro_interes, Interes_fecha, Interes_tasa_anual);
            this.interes = Math.Round(this.interes, 2);
            aux_Monto_pago -= this.interes;

            //Se verifica si el periodo de seguro es posterior al periodo de interés, de ser así ya nos e cobra el seguro
            if (this.seguro > 0)
            {
                int calc_MesSeguro = (this.seguro_fecha.Year * 100) + this.seguro_fecha.Month;
                int calc_MesInteres_ideal = (Fecha_cobro_interes.Year * 100) + Fecha_cobro_interes.Month;
                //int calc_MesInteres = (this.interes_fecha.Year * 100) + this.interes_fecha.Month;
                if (calc_MesSeguro > calc_MesInteres_ideal)
                {
                    aux_Monto_pago += this.seguro;
                    this.seguro_fecha = Seguro_fecha;
                    this.seguro_meses = 0;
                    this.seguro = 0;
                }
            }

            //Cuarto: Amortización
            if (aux_Monto_pago <= Saldo)
            {
                this.amortizacion = aux_Monto_pago;
                this.saldo = Saldo - this.amortizacion;
                this.monto_pago = Monto_pago;
            }
            else
            {
                this.amortizacion = Saldo;
                this.saldo = 0;
                this.monto_pago = Monto_pago - aux_Monto_pago + this.amortizacion;

                //En caso de que sea el último pago ya no se cobra el seguro
                if (this.seguro > 0)
                {
                    this.monto_pago = this.monto_pago - this.seguro;
                    this.seguro = 0;
                }
            }

            this.fecha_proximo = logica.FechaProximoPago(this.interes_fecha, Fecha_inicio_plan);
        }

        private void CobrarSeguro(decimal Saldo, decimal Monto_Pago, DateTime Fecha_cobro, DateTime Seguro_fecha, decimal Seguro_tasa_mensual)
        {
            if (Saldo > 0 && Monto_Pago > 0)
            {
                DateTime Fecha_actual = DateTime.Now;

                int mes_seguro = (Seguro_fecha.Year * 100) + Seguro_fecha.Month;
                int mes_actual = (Fecha_actual.Year * 100) + Fecha_actual.Month;
                if (mes_seguro < mes_actual || Seguro_tasa_mensual == 0) { this.seguro_fecha = Fecha_actual.AddDays(Fecha_actual.Day * (-1)).AddDays(Seguro_fecha.Day); }
                else { this.seguro_fecha = Seguro_fecha.AddMonths(1); }
                this.seguro_meses = 1;
                this.seguro = Saldo * (Seguro_tasa_mensual / 100);
                this.seguro = Math.Round(this.seguro, 2);

                if (this.seguro > Monto_Pago)
                {
                    this.seguro_fecha = Seguro_fecha;
                    this.seguro_meses = 0;
                    this.seguro = 0;
                }
            }
            else
            {
                this.seguro_fecha = Seguro_fecha;
                this.seguro_meses = 0;
                this.seguro = 0;
            }
        }

        private void CobrarMantenimiento(decimal Monto_Pago, DateTime Fecha_cobro, DateTime Mantenimiento_fecha, decimal Mantenimiento_sus_mensual)
        {
            if (Monto_Pago > 0 && Fecha_cobro > Mantenimiento_fecha /*&& Mantenimiento_sus_mensual > 0*/)
            {
                this.mantenimiento_meses = logica.NumMesesSeguroManten(Mantenimiento_fecha, Fecha_cobro);
                this.mantenimiento_sus = Mantenimiento_sus_mensual * this.mantenimiento_meses;
                if (this.mantenimiento_sus > Monto_Pago)
                {
                    while (this.mantenimiento_sus > Monto_Pago && this.mantenimiento_meses > 0)
                    {
                        this.mantenimiento_meses = this.mantenimiento_meses - 1;
                        this.mantenimiento_sus = Mantenimiento_sus_mensual * this.mantenimiento_meses;
                    }
                }
                this.mantenimiento_fecha = Mantenimiento_fecha.AddMonths(this.mantenimiento_meses);
            }
            else
            {
                this.mantenimiento_sus = 0;
                this.mantenimiento_meses = 0;
                this.mantenimiento_fecha = Mantenimiento_fecha;
            }
        }

        private void CobrarInteres(decimal Saldo, decimal Monto_pago, DateTime Fecha_cobro, DateTime Interes_fecha, decimal Interes_tasa_anual)
        {
            if (Saldo > 0 && Monto_pago > 0 && Fecha_cobro > Interes_fecha)
            {
                TimeSpan aux_num_dias;
                aux_num_dias = Fecha_cobro.Subtract(Interes_fecha);
                this.interes_dias_total = Convert.ToInt32(Math.Floor(aux_num_dias.TotalDays));
                this.interes_dias = this.interes_dias_total;
                this.interes = Saldo * (Interes_tasa_anual / 36500) * this.interes_dias;
                if (this.interes > Monto_pago)
                {
                    this.interes_dias = Convert.ToInt32((Monto_pago / this.interes) * this.interes_dias_total);
                    this.interes = Saldo * (Interes_tasa_anual / 36500) * this.interes_dias;
                    while (this.interes > Monto_pago && this.interes_dias > 0)
                    {
                        this.interes_dias = this.interes_dias - 1;
                        this.interes = Saldo * (Interes_tasa_anual / 36500) * this.interes_dias;
                    }
                }
                this.interes_fecha = Interes_fecha.AddDays(this.interes_dias);
            }
            else
            {
                this.interes = 0;
                this.interes_fecha = Interes_fecha;
                this.interes_dias = 0;
                this.interes_dias_total = 0;
            }
        }

        #endregion
    }
}