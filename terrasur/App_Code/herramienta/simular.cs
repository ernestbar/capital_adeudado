using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for simular
/// </summary>
namespace terrasur
{
    public class simular 
    {
        
        #region Lógica
        public static decimal Obtener_cuota_base(decimal saldo_capital, int num_cuotas, decimal seguro, decimal mantenimiento, decimal interes)
        {
            decimal seguro_mensual = seguro / 100;
            decimal i_anual = interes / 100;
            decimal Co = saldo_capital;
            decimal n = (decimal)num_cuotas;
            decimal i_mensual = i_anual / 12;
            decimal int_seg = i_mensual + seguro_mensual;
            if (n == 0) n = 1;
            if (int_seg == 0) { return Math.Ceiling((Co / n) + mantenimiento); }
            else
            {
                decimal cuota_periodica = Co * (int_seg * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + int_seg), Convert.ToDouble(n)))) / (Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + int_seg), Convert.ToDouble(n))) - 1);
                return Math.Ceiling(cuota_periodica) + mantenimiento;
            }
        }
        #endregion

        #region Simulación de plan de pagos
        public static List<sim_pago> lista_plan_simulado(decimal _saldo_capital, decimal _cuota_inicial,
            int _num_cuotas, int _num_gracia, decimal _interes, decimal _seguro, decimal _mantenimiento, DateTime _fecha_inicio)
        {
            //Se simula la cuota inicial
            List<sim_pago> lista_pagos = new List<sim_pago>();
            sim_pago pago_simulado = new sim_pago(_saldo_capital, _cuota_inicial, _fecha_inicio, _fecha_inicio);
            lista_pagos.Add(pago_simulado);
            
            //Simulación para el periodo de gracia:
            int aux = _num_gracia;
            if (aux > 0)
            {
                decimal cuota_mensual1 = Obtener_cuota_base(pago_simulado.saldo, _num_cuotas, _seguro, _mantenimiento, 0);
                while (pago_simulado.saldo > 0 && aux > 0)
                {
                    pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, cuota_mensual1, _fecha_inicio, _seguro, _mantenimiento, 0);
                    //pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha.AddMonths(1), 1, cuota_mensual1, _fecha_inicio, _seguro, _mantenimiento, 0);
                    lista_pagos.Add(pago_simulado);
                    aux -= 1;
                }
            }
            //Simulación para el periodo de normal:
            if (pago_simulado.saldo > 0)
            {
                decimal cuota_mensual2 = Obtener_cuota_base(pago_simulado.saldo, _num_cuotas - _num_gracia, _seguro, _mantenimiento, _interes);
                while (pago_simulado.saldo > 0)
                {
                    pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, cuota_mensual2, _fecha_inicio, _seguro, _mantenimiento, _interes);
                    //pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha.AddMonths(1), 1, cuota_mensual2, _fecha_inicio, _seguro, _mantenimiento, _interes);
                    lista_pagos.Add(pago_simulado);
                }
            }
            return lista_pagos;
        }
        public static List<sim_pago> lista_plan_restante_simulado(int Id_contrato, bool Preferencial, int Id_pago, decimal Cuota_mensual, int _num_cuotas,
            DateTime Fecha_inicio_plan, decimal _interes, decimal _seguro, decimal _mantenimiento)
        {
            List<sim_pago> lista_pagos = new List<sim_pago>();
            sim_pago pago_simulado = new sim_pago(Id_pago);

            //if (Preferencial == false && pago_simulado.fecha.Date < DateTime.Now.Date && pago_simulado.saldo > 0)
            //{
            //    pago_simulado = pago.PagoNormalSimulado(Id_contrato, 0, DateTime.Now, pago_simulado);
            //    lista_pagos.Add(pago_simulado);
            //}

            //Simulación de pagos normales restantes:
            if (Cuota_mensual == 0 && pago_simulado.saldo > 0) Cuota_mensual = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                pago_simulado = new sim_pago(pago_simulado, logica.FechaProximoPago(pago_simulado.interes_fecha, Fecha_inicio_plan), 1, Cuota_mensual, Fecha_inicio_plan, _seguro, _mantenimiento, _interes);
                //pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, Cuota_mensual, Fecha_inicio_plan, _seguro, _mantenimiento, _interes);
                lista_pagos.Add(pago_simulado);
            }
            return lista_pagos;
        }
        //public static List<sim_pago> lista_plan_restante_totales(int Id_pago, int Cuota_mensual, int _num_cuotas, int _num_gracia, decimal _interes, decimal _seguro, decimal _mantenimiento)
        //{
        //    List<sim_pago> lista_pagos = new List<sim_pago>();
        //    sim_pago pago_simulado = new sim_pago(Id_pago);

        //    //Simulación de pagos normales restantes:
        //    if (pago_simulado.saldo > 0)
        //    {
        //        while (pago_simulado.saldo > 0)
        //        {
        //            pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, Cuota_mensual, pago_simulado.fecha_proximo.AddMonths(-1), _seguro, _mantenimiento, _interes);
        //            lista_pagos.Add(pago_simulado);
        //        }
        //    }
        //    return lista_pagos;
        //}
        #endregion

        #region Tabla de simulación de plan de pagos
        public static DataTable tabla_plan_simulado(List<sim_pago> lista)
        {
            DataTable tabla = tabla_plan_crear();
            foreach (sim_pago item_pago in lista) {tabla_plan_insertar(ref tabla, item_pago);}
            return tabla;
        }
        public static DataTable tabla_plan_simulado_total(List<sim_pago> lista)
        {
            int num_pago = 0;
            int num_cuotas = 0;
            decimal seguro = 0;
            int seguro_meses = 0;
            decimal mantenimiento_sus = 0;
            int mantenimiento_meses = 0;
            decimal interes = 0;
            int interes_dias = 0;
            decimal monto_pago = 0;
            DataTable tabla_totales = tabla_plan_restante_total();
            foreach (sim_pago item_pago in lista)
            {
                num_pago = item_pago.anterior_num_pagos + 1;
                num_cuotas += item_pago.num_cuotas;
                seguro += item_pago.seguro;
                seguro_meses += item_pago.seguro_meses;
                mantenimiento_sus += item_pago.mantenimiento_sus;
                mantenimiento_meses += item_pago.mantenimiento_meses;
                interes += item_pago.interes;
                interes_dias += item_pago.interes_dias;
                monto_pago += item_pago.monto_pago;
            }
            DataRow fila = tabla_totales.NewRow();

            fila["num_pago"] = num_pago;
            fila["num_cuotas"] = num_cuotas;
            fila["seguro"] = seguro;
            fila["seguro_meses"] = seguro_meses;
            fila["mantenimiento_sus"] = mantenimiento_sus;
            fila["mantenimiento_meses"] = mantenimiento_meses;
            fila["interes"] = interes;
            fila["interes_dias"] = interes_dias;
            fila["monto_pago"] = monto_pago;
            tabla_totales.Rows.Add(fila);

            return tabla_totales;
        }
        public static DataTable tabla_plan_crear()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("num_pago", typeof(string));
            tabla.Columns.Add("num_cuotas", typeof(int));
            tabla.Columns.Add("fecha", typeof(DateTime));
            tabla.Columns.Add("fecha_proximo", typeof(DateTime));
            tabla.Columns.Add("string_cuotas", typeof(string));
            tabla.Columns.Add("seguro", typeof(decimal));
            tabla.Columns.Add("seguro_fecha", typeof(DateTime));
            tabla.Columns.Add("seguro_meses", typeof(int));
            tabla.Columns.Add("mantenimiento_sus", typeof(decimal));
            tabla.Columns.Add("mantenimiento_fecha", typeof(DateTime));
            tabla.Columns.Add("mantenimiento_meses", typeof(int));
            tabla.Columns.Add("interes", typeof(decimal));
            tabla.Columns.Add("interes_fecha", typeof(DateTime));
            tabla.Columns.Add("interes_dias", typeof(int));
            tabla.Columns.Add("interes_dias_total", typeof(int));
            tabla.Columns.Add("monto_pago", typeof(decimal));
            tabla.Columns.Add("amortizacion", typeof(decimal));
            tabla.Columns.Add("saldo", typeof(decimal));
            return tabla;
        }
        public static DataTable tabla_plan_restante_total()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("num_pago", typeof(string));
            tabla.Columns.Add("num_cuotas", typeof(int));
            tabla.Columns.Add("seguro", typeof(decimal));
            tabla.Columns.Add("seguro_meses", typeof(int));
            tabla.Columns.Add("mantenimiento_sus", typeof(decimal));
            tabla.Columns.Add("mantenimiento_meses", typeof(int));
            tabla.Columns.Add("interes", typeof(decimal));
            tabla.Columns.Add("interes_dias", typeof(int));
            tabla.Columns.Add("monto_pago", typeof(decimal));
            return tabla;
        }
        public static void tabla_plan_insertar(ref DataTable tabla, sim_pago item_pago)
        {
            DataRow fila = tabla.NewRow();

            fila["num_pago"] = tabla_plan_num_pago(item_pago.anterior_num_pagos, 1);
            fila["string_cuotas"] = tabla_plan_string_cuotas(item_pago.anterior_num_cuotas, item_pago.num_cuotas);
            fila["num_cuotas"] = item_pago.num_cuotas;
            fila["fecha"] = item_pago.fecha;
            fila["fecha_proximo"] = item_pago.fecha_proximo;
            fila["seguro"] = item_pago.seguro;
            fila["seguro_fecha"] = item_pago.seguro_fecha;
            fila["seguro_meses"] = item_pago.seguro_meses;
            fila["mantenimiento_sus"] = item_pago.mantenimiento_sus;
            fila["mantenimiento_fecha"] = item_pago.mantenimiento_fecha;
            fila["mantenimiento_meses"] = item_pago.mantenimiento_meses;
            fila["interes"] = item_pago.interes;
            fila["interes_fecha"] = item_pago.interes_fecha;
            fila["interes_dias"] = item_pago.interes_dias;
            fila["interes_dias_total"] = item_pago.interes_dias_total;
            fila["monto_pago"] = item_pago.monto_pago;
            fila["amortizacion"] = item_pago.amortizacion;
            fila["saldo"] = item_pago.saldo;
            tabla.Rows.Add(fila);
        }

        private static string tabla_plan_num_pago(int num_pago_anterior, int num_pagos)
        {
            if (num_pagos > 0) return (num_pago_anterior + num_pagos).ToString();
            else return string.Empty;
        }
        public static string tabla_plan_string_cuotas(int num_cuota_anterior, int num_cuotas)
        {
            if (num_cuotas > 0)
            {
                if (num_cuotas == 1) return (num_cuota_anterior + 1).ToString();
                else return (num_cuota_anterior + 1).ToString() + " - " + (num_cuota_anterior + num_cuotas).ToString();
            }
            else return string.Empty;
        }
        #endregion

    }
}