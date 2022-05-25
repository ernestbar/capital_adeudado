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
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Descripción breve de reportesCarteraRetraso
/// </summary>
namespace terrasur
{
    public class reportesRetraso
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        public static DataTable resumen_rangos(ref DataTable tabla_origen, decimal porcentaje_costo_oportunidad)
        {
            //rango,num_contratos,precio_final_efectivo,precio_final_porcentaje,saldo_efectivo,saldo_porcentaje,
            //adeuda_monto_efectivo,adeuda_capital_efectivo,adeuda_interes_efectivo
            //adeuda_monto_porcentaje,adeuda_capital_porcentaje,adeuda_interes_porcentaje
            //adeuda_monto_costo,adeuda_capital_costo,adeuda_interes_costo
            tabla_origen.DefaultView.Sort = "especial,num_dias_retraso";
            DataTable tabla_origen_ordenada = tabla_origen.DefaultView.ToTable();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("rango", typeof(string));
            tabla.Columns.Add("num_contratos", typeof(int));
            tabla.Columns.Add("precio_final_efectivo", typeof(decimal));
            tabla.Columns.Add("precio_final_porcentaje", typeof(string));
            tabla.Columns.Add("saldo_efectivo", typeof(decimal));
            tabla.Columns.Add("saldo_porcentaje", typeof(string));

            tabla.Columns.Add("adeuda_monto_efectivo", typeof(decimal));
            tabla.Columns.Add("adeuda_capital_efectivo", typeof(decimal));
            tabla.Columns.Add("adeuda_interes_efectivo", typeof(decimal));

            tabla.Columns.Add("adeuda_monto_porcentaje", typeof(decimal));
            tabla.Columns.Add("adeuda_capital_porcentaje", typeof(decimal));
            tabla.Columns.Add("adeuda_interes_porcentaje", typeof(decimal));

            tabla.Columns.Add("adeuda_monto_costo", typeof(decimal));
            tabla.Columns.Add("adeuda_capital_costo", typeof(decimal));
            tabla.Columns.Add("adeuda_interes_costo", typeof(decimal));


            //decimal precio_final_efectivo = 0;
            //decimal saldo_efectivo = 0;

            int index = -1;
            foreach (DataRow fila_origen in tabla_origen_ordenada.Rows)
            {
                index = busca_index(ref tabla, "rango", fila_origen["rango"].ToString());
                if (index < 0)
                {
                    DataRow fila = tabla.NewRow();
                    fila["rango"] = fila_origen["rango"].ToString();
                    fila["num_contratos"] = 1;
                    fila["precio_final_efectivo"] = (decimal)fila_origen["precio_final"];
                    fila["saldo_efectivo"] = (decimal)fila_origen["saldo"];

                    fila["adeuda_monto_efectivo"] = (decimal)fila_origen["monto_adeuda"];
                    fila["adeuda_capital_efectivo"] = (decimal)fila_origen["capital_adeuda"];
                    fila["adeuda_interes_efectivo"] = (decimal)fila_origen["interes_adeuda"];
                    tabla.Rows.Add(fila);
                }
                else
                {
                    tabla.Rows[index]["num_contratos"] = ((int)tabla.Rows[index]["num_contratos"]) + 1;
                    tabla.Rows[index]["precio_final_efectivo"] = ((decimal)tabla.Rows[index]["precio_final_efectivo"]) + ((decimal)fila_origen["precio_final"]);
                    tabla.Rows[index]["saldo_efectivo"] = ((decimal)tabla.Rows[index]["saldo_efectivo"]) + ((decimal)fila_origen["saldo"]);

                    tabla.Rows[index]["adeuda_monto_efectivo"] = ((decimal)tabla.Rows[index]["adeuda_monto_efectivo"]) + ((decimal)fila_origen["monto_adeuda"]);
                    tabla.Rows[index]["adeuda_capital_efectivo"] = ((decimal)tabla.Rows[index]["adeuda_capital_efectivo"]) + ((decimal)fila_origen["capital_adeuda"]);
                    tabla.Rows[index]["adeuda_interes_efectivo"] = ((decimal)tabla.Rows[index]["adeuda_interes_efectivo"]) + ((decimal)fila_origen["interes_adeuda"]);
                }
            }

            //Porcentajes
            decimal total_precio_final_efectivo = 0;
            decimal total_saldo_efectivo = 0;
            decimal total_adeuda_monto_efectivo = 0;
            decimal total_adeuda_capital_efectivo = 0;
            decimal total_adeuda_interes_efectivo = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                total_precio_final_efectivo += ((decimal)fila["precio_final_efectivo"]);
                total_saldo_efectivo += ((decimal)fila["saldo_efectivo"]);

                total_adeuda_monto_efectivo += ((decimal)fila["adeuda_monto_efectivo"]);
                total_adeuda_capital_efectivo += ((decimal)fila["adeuda_capital_efectivo"]);
                total_adeuda_interes_efectivo += ((decimal)fila["adeuda_interes_efectivo"]);
            }
            foreach (DataRow fila in tabla.Rows)
            {
                fila["precio_final_porcentaje"] = (((decimal)fila["precio_final_efectivo"]) / total_precio_final_efectivo) * 100;
                fila["saldo_porcentaje"] = (((decimal)fila["saldo_efectivo"]) / total_saldo_efectivo) * 100;

                fila["adeuda_monto_porcentaje"] = (((decimal)fila["adeuda_monto_efectivo"]) / total_adeuda_monto_efectivo) * 100;
                fila["adeuda_capital_porcentaje"] = (((decimal)fila["adeuda_capital_efectivo"]) / total_adeuda_capital_efectivo) * 100;
                fila["adeuda_interes_porcentaje"] = (((decimal)fila["adeuda_interes_efectivo"]) / total_adeuda_interes_efectivo) * 100;
            }

            //Costo de oportunidad
            foreach (DataRow fila in tabla.Rows)
            {
                fila["adeuda_monto_costo"] = ((decimal)fila["adeuda_monto_efectivo"]) * (porcentaje_costo_oportunidad / 100);
                fila["adeuda_capital_costo"] = ((decimal)fila["adeuda_capital_efectivo"]) * (porcentaje_costo_oportunidad / 100);
                fila["adeuda_interes_costo"] = ((decimal)fila["adeuda_interes_efectivo"]) * (porcentaje_costo_oportunidad / 100);
            }


            return tabla;
        }

        public static DataTable resumen_grupos(ref DataTable tabla_origen, decimal porcentaje_costo_oportunidad, string col_grupo, string orden)
        {
            //grupo,num_contratos,saldo,pagos_adeuda,capital_adeuda_efectivo,capital_adeuda_porcentaje
            DataTable tabla = new DataTable();
            tabla.Columns.Add("grupo", typeof(string));
            tabla.Columns.Add("num_contratos", typeof(int));
            tabla.Columns.Add("precio_final", typeof(decimal));
            tabla.Columns.Add("saldo", typeof(decimal));
            tabla.Columns.Add("pagos_adeuda_efectivo", typeof(decimal));
            tabla.Columns.Add("pagos_adeuda_porcentaje", typeof(decimal));
            tabla.Columns.Add("costo_oportunidad", typeof(decimal));
            tabla.Columns.Add("capital_adeuda_efectivo", typeof(decimal));
            tabla.Columns.Add("capital_adeuda_porcentaje", typeof(decimal));
            tabla.Columns.Add("calidad", typeof(decimal));

            string grupo = "";
            int num_contratos = 0;
            decimal precio_final = 0;
            decimal saldo = 0;
            decimal pagos_adeuda_efectivo = 0;
            decimal capital_adeuda_efectivo = 0;

            int index = 0;
            foreach (DataRow fila_origen in tabla_origen.Rows)
            {
                grupo = fila_origen[col_grupo].ToString();
                num_contratos = 1;
                precio_final = (decimal)fila_origen["precio_final"];
                saldo = (decimal)fila_origen["saldo"];
                pagos_adeuda_efectivo = (decimal)fila_origen["monto_adeuda"];
                capital_adeuda_efectivo = (decimal)fila_origen["capital_adeuda"];

                index = busca_index(ref tabla, "grupo", grupo);
                if (index < 0)
                {
                    DataRow fila = tabla.NewRow();
                    fila["grupo"] = grupo;
                    fila["num_contratos"] = num_contratos;
                    fila["precio_final"] = precio_final;
                    fila["saldo"] = saldo;
                    fila["pagos_adeuda_efectivo"] = pagos_adeuda_efectivo;
                    fila["capital_adeuda_efectivo"] = capital_adeuda_efectivo;
                    tabla.Rows.Add(fila);
                }
                else
                {
                    tabla.Rows[index]["num_contratos"] = ((int)tabla.Rows[index]["num_contratos"]) + num_contratos;
                    tabla.Rows[index]["precio_final"] = ((decimal)tabla.Rows[index]["precio_final"]) + precio_final;
                    tabla.Rows[index]["saldo"] = ((decimal)tabla.Rows[index]["saldo"]) + saldo;
                    tabla.Rows[index]["pagos_adeuda_efectivo"] = ((decimal)tabla.Rows[index]["pagos_adeuda_efectivo"]) + pagos_adeuda_efectivo;
                    tabla.Rows[index]["capital_adeuda_efectivo"] = ((decimal)tabla.Rows[index]["capital_adeuda_efectivo"]) + capital_adeuda_efectivo;
                }
            }

            decimal total_pagos_adeuda = 0;
            decimal total_capital_adeuda = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                total_pagos_adeuda += ((decimal)fila["pagos_adeuda_efectivo"]);
                total_capital_adeuda += ((decimal)fila["capital_adeuda_efectivo"]);
            }
            foreach (DataRow fila in tabla.Rows)
            {
                fila["costo_oportunidad"] = ((decimal)fila["pagos_adeuda_efectivo"]) * (porcentaje_costo_oportunidad / 100);
                fila["pagos_adeuda_porcentaje"] = (((decimal)fila["pagos_adeuda_efectivo"]) / total_pagos_adeuda) * 100;
                fila["capital_adeuda_porcentaje"] = (((decimal)fila["capital_adeuda_efectivo"]) / total_capital_adeuda) * 100;
                fila["calidad"] = (((decimal)fila["capital_adeuda_efectivo"]) / ((decimal)fila["saldo"])) * 100;
            }

            tabla.DefaultView.Sort = orden;
            return tabla.DefaultView.ToTable();
        }

        public static DataTable resumen_grupos_rangos(ref DataTable tabla_origen, string col_grupo, string orden)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("grupo", typeof(string));
            tabla.Columns.Add("d0_saldo", typeof(decimal)); tabla.Columns.Add("d0_pagos", typeof(decimal)); tabla.Columns.Add("d0_num_contratos", typeof(int));
            tabla.Columns.Add("d1_saldo", typeof(decimal)); tabla.Columns.Add("d1_pagos", typeof(decimal)); tabla.Columns.Add("d1_num_contratos", typeof(int));
            tabla.Columns.Add("d31_saldo", typeof(decimal)); tabla.Columns.Add("d31_pagos", typeof(decimal)); tabla.Columns.Add("d31_num_contratos", typeof(int));
            tabla.Columns.Add("d61_saldo", typeof(decimal)); tabla.Columns.Add("d61_pagos", typeof(decimal)); tabla.Columns.Add("d61_num_contratos", typeof(int));
            tabla.Columns.Add("d91_saldo", typeof(decimal)); tabla.Columns.Add("d91_pagos", typeof(decimal)); tabla.Columns.Add("d91_num_contratos", typeof(int));
            tabla.Columns.Add("d121_saldo", typeof(decimal)); tabla.Columns.Add("d121_pagos", typeof(decimal)); tabla.Columns.Add("d121_num_contratos", typeof(int));
            tabla.Columns.Add("desp_saldo", typeof(decimal)); tabla.Columns.Add("desp_pagos", typeof(decimal)); tabla.Columns.Add("desp_num_contratos", typeof(int));
            tabla.Columns.Add("tot_saldo", typeof(decimal)); tabla.Columns.Add("tot_pagos", typeof(decimal)); tabla.Columns.Add("tot_num_contratos", typeof(int));

            string grupo = "";
            int num_dias_retraso = 0;
            int especial = 0;
            decimal saldo = 0;
            decimal pagos_adeuda = 0;

            int index = -1;
            foreach (DataRow fila_origen in tabla_origen.Rows)
            {
                grupo = fila_origen[col_grupo].ToString();
                num_dias_retraso = (int)fila_origen["num_dias_retraso"];
                especial = (int)fila_origen["especial"];
                saldo = (decimal)fila_origen["saldo"];
                pagos_adeuda = (decimal)fila_origen["monto_adeuda"];

                index = busca_index(ref tabla, "grupo", grupo);
                if (index < 0)
                {
                    DataRow fila = tabla.NewRow();
                    fila["grupo"] = grupo;
                    if (especial == 0 && num_dias_retraso == 0) { fila["d0_saldo"] = saldo; fila["d0_pagos"] = pagos_adeuda; fila["d0_num_contratos"] = 1; } else { fila["d0_saldo"] = 0; fila["d0_pagos"] = 0; fila["d0_num_contratos"] = 0; }
                    if (especial == 0 && num_dias_retraso >= 1 && num_dias_retraso <= 30) { fila["d1_saldo"] = saldo; fila["d1_pagos"] = pagos_adeuda; fila["d1_num_contratos"] = 1; } else { fila["d1_saldo"] = 0; fila["d1_pagos"] = 0; fila["d1_num_contratos"] = 0; }
                    if (especial == 0 && num_dias_retraso >= 31 && num_dias_retraso <= 60) { fila["d31_saldo"] = saldo; fila["d31_pagos"] = pagos_adeuda; fila["d31_num_contratos"] = 1; } else { fila["d31_saldo"] = 0; fila["d31_pagos"] = 0; fila["d31_num_contratos"] = 0; }
                    if (especial == 0 && num_dias_retraso >= 61 && num_dias_retraso <= 90) { fila["d61_saldo"] = saldo; fila["d61_pagos"] = pagos_adeuda; fila["d61_num_contratos"] = 1; } else { fila["d61_saldo"] = 0; fila["d61_pagos"] = 0; fila["d61_num_contratos"] = 0; }
                    if (especial == 0 && num_dias_retraso >= 91 && num_dias_retraso <= 120) { fila["d91_saldo"] = saldo; fila["d91_pagos"] = pagos_adeuda; fila["d91_num_contratos"] = 1; } else { fila["d91_saldo"] = 0; fila["d91_pagos"] = 0; fila["d91_num_contratos"] = 0; }
                    if (especial == 0 && num_dias_retraso >= 121) { fila["d121_saldo"] = saldo; fila["d121_pagos"] = pagos_adeuda; fila["d121_num_contratos"] = 1; } else { fila["d121_saldo"] = 0; fila["d121_pagos"] = 0; fila["d121_num_contratos"] = 0; }
                    if (especial == 1) { fila["desp_saldo"] = saldo; fila["desp_pagos"] = pagos_adeuda; fila["desp_num_contratos"] = 1; } else { fila["desp_saldo"] = 0; fila["desp_pagos"] = 0; fila["desp_num_contratos"] = 0; }
                    fila["tot_saldo"] = saldo;
                    fila["tot_pagos"] = pagos_adeuda;
                    fila["tot_num_contratos"] = 1;
                    tabla.Rows.Add(fila);
                }
                else
                {
                    string sub_fijo = "";
                    if (especial == 0 && num_dias_retraso == 0) sub_fijo = "d0";
                    else if (especial == 0 && num_dias_retraso >= 1 && num_dias_retraso <= 30) sub_fijo = "d1";
                    else if (especial == 0 && num_dias_retraso >= 31 && num_dias_retraso <= 60) sub_fijo = "d31";
                    else if (especial == 0 && num_dias_retraso >= 61 && num_dias_retraso <= 90) sub_fijo = "d61";
                    else if (especial == 0 && num_dias_retraso >= 91 && num_dias_retraso <= 120) sub_fijo = "d91";
                    else if (especial == 0 && num_dias_retraso >= 121) sub_fijo = "d121";
                    else if (especial == 1) sub_fijo = "desp";

                    tabla.Rows[index][sub_fijo + "_saldo"] = ((decimal)tabla.Rows[index][sub_fijo + "_saldo"]) + saldo;
                    tabla.Rows[index][sub_fijo + "_pagos"] = ((decimal)tabla.Rows[index][sub_fijo + "_pagos"]) + pagos_adeuda;
                    tabla.Rows[index][sub_fijo + "_num_contratos"] = ((int)tabla.Rows[index][sub_fijo + "_num_contratos"]) + 1;

                    tabla.Rows[index]["tot_saldo"] = ((decimal)tabla.Rows[index]["tot_saldo"]) + saldo;
                    tabla.Rows[index]["tot_pagos"] = ((decimal)tabla.Rows[index]["tot_pagos"]) + pagos_adeuda;
                    tabla.Rows[index]["tot_num_contratos"] = ((int)tabla.Rows[index]["tot_num_contratos"]) + 1;
                }
            }
            tabla.DefaultView.Sort = orden;
            return tabla.DefaultView.ToTable();
        }

        public static DataTable resumen_grupos_promotores(ref DataTable tabla_origen, decimal porcentaje_costo_oportunidad, string col_grupo, string orden)
        {
            //tabla_origen.DefaultView.Sort = "grupo,promotor";
            //DataTable tabla_origen_ordenada = tabla_origen.DefaultView.ToTable();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("grupo", typeof(string));
            tabla.Columns.Add("promotor", typeof(string));
            tabla.Columns.Add("num_contratos", typeof(int));
            tabla.Columns.Add("precio_final", typeof(decimal));
            tabla.Columns.Add("saldo", typeof(decimal));
            tabla.Columns.Add("pagos_adeuda_efectivo", typeof(decimal));
            tabla.Columns.Add("pagos_adeuda_porcentaje", typeof(decimal));
            tabla.Columns.Add("costo_oportunidad", typeof(decimal));
            tabla.Columns.Add("capital_adeuda_efectivo", typeof(decimal));
            tabla.Columns.Add("capital_adeuda_porcentaje", typeof(decimal));
            tabla.Columns.Add("calidad", typeof(decimal));

            int index = 0;
            foreach (DataRow fila_origen in tabla_origen.Rows)
            {
                index = busca_index(ref tabla, "grupo", fila_origen[col_grupo].ToString(), "promotor", fila_origen["promotor"].ToString());
                if (index < 0)
                {
                    DataRow fila = tabla.NewRow();
                    fila["grupo"] = fila_origen[col_grupo].ToString();
                    fila["promotor"] = fila_origen["promotor"].ToString();
                    fila["num_contratos"] = 1;
                    fila["precio_final"] = (decimal)fila_origen["precio_final"];
                    fila["saldo"] = (decimal)fila_origen["saldo"];
                    fila["pagos_adeuda_efectivo"] = (decimal)fila_origen["monto_adeuda"];
                    fila["capital_adeuda_efectivo"] = (decimal)fila_origen["capital_adeuda"];
                    tabla.Rows.Add(fila);
                }
                else
                {
                    tabla.Rows[index]["num_contratos"] = ((int)tabla.Rows[index]["num_contratos"]) + 1;
                    tabla.Rows[index]["precio_final"] = ((decimal)tabla.Rows[index]["precio_final"]) + ((decimal)fila_origen["precio_final"]);
                    tabla.Rows[index]["saldo"] = ((decimal)tabla.Rows[index]["saldo"]) + ((decimal)fila_origen["saldo"]);
                    tabla.Rows[index]["pagos_adeuda_efectivo"] = ((decimal)tabla.Rows[index]["pagos_adeuda_efectivo"]) + ((decimal)fila_origen["monto_adeuda"]);
                    tabla.Rows[index]["capital_adeuda_efectivo"] = ((decimal)tabla.Rows[index]["capital_adeuda_efectivo"]) + ((decimal)fila_origen["capital_adeuda"]);
                }
            }

            //Se obtiene la lista de grupos
            List<string> lista_grupos = new List<string>();
            foreach(DataRow fila in tabla.Rows)
            {
                bool existe = false;
                for (int j = 0; j < lista_grupos.Count; j++) { if (lista_grupos[j] == fila["grupo"].ToString()) { existe = true; break; } }
                if (existe == false) { lista_grupos.Add(fila["grupo"].ToString()); }
            }

            for (int j = 0; j < lista_grupos.Count; j++)
            {
                decimal total_pagos_adeuda = 0;
                decimal total_capital_adeuda = 0;
                foreach (DataRow fila in tabla.Rows)
                {
                    if (fila["grupo"].ToString() == lista_grupos[j])
                    {
                        total_pagos_adeuda += ((decimal)fila["pagos_adeuda_efectivo"]);
                        total_capital_adeuda += ((decimal)fila["capital_adeuda_efectivo"]);
                    }
                }
                foreach (DataRow fila in tabla.Rows)
                {
                    if (fila["grupo"].ToString() == lista_grupos[j])
                    {
                        //fila["pagos_adeuda_porcentaje"] = (((decimal)fila["pagos_adeuda_efectivo"]) / total_pagos_adeuda) * 100;
                        //fila["capital_adeuda_porcentaje"] = (((decimal)fila["capital_adeuda_efectivo"]) / total_capital_adeuda) * 100;
                        if (total_pagos_adeuda > 0) { fila["pagos_adeuda_porcentaje"] = (((decimal)fila["pagos_adeuda_efectivo"]) / total_pagos_adeuda) * 100; } else { fila["pagos_adeuda_porcentaje"] = 0; }
                        if (total_capital_adeuda > 0) { fila["capital_adeuda_porcentaje"] = (((decimal)fila["capital_adeuda_efectivo"]) / total_capital_adeuda) * 100; } else { fila["capital_adeuda_porcentaje"] = 0; }

                        fila["costo_oportunidad"] = ((decimal)fila["pagos_adeuda_efectivo"]) * (porcentaje_costo_oportunidad / 100);
                        fila["calidad"] = (((decimal)fila["capital_adeuda_efectivo"]) / ((decimal)fila["saldo"])) * 100;
                    }
                }
            }
            //foreach (DataRow fila in tabla.Rows)
            //{
            //    fila["costo_oportunidad"] = ((decimal)fila["pagos_adeuda_efectivo"]) * (porcentaje_costo_oportunidad / 100);
            //    fila["calidad"] = (((decimal)fila["capital_adeuda_efectivo"]) / ((decimal)fila["saldo"])) * 100;
            //}

            tabla.DefaultView.Sort = orden;
            return tabla.DefaultView.ToTable();
        }

        public static DataTable resumen_grupos_promotores_rangos(DataTable tabla_origen, string col_grupo,string orden, bool con_contratos_al_dia, bool con_retraso_1_a_30, bool con_contratos_especiales)
        {
            //Si la columan es diferente a "grupo" se copia en la columan grupo los datos de la columna diferente "col_grupo"
            if (col_grupo != "grupo")
            {
                foreach (DataRow fila_origen in tabla_origen.Rows)
                {
                    fila_origen["grupo"] = fila_origen[col_grupo].ToString();
                }
            }
            //Se excluyen contratos especiales
            if (con_contratos_especiales == false)
            {
                for (int j = tabla_origen.Rows.Count - 1; j >= 0; j--)
                {
                    if (((int)tabla_origen.Rows[j]["especial"]) == 1) { tabla_origen.Rows.RemoveAt(j); }
                }
            }
            //Se excluyen contratos al día
            if (con_contratos_al_dia == false)
            {
                for (int j = tabla_origen.Rows.Count - 1; j >= 0; j--)
                {
                    if (((int)tabla_origen.Rows[j]["num_dias_retraso"]) == 0) { tabla_origen.Rows.RemoveAt(j); }
                }
            }
            //Se excluyen contratos con retraso de 1 a 30
            if (con_retraso_1_a_30 == false)
            {
                for (int j = tabla_origen.Rows.Count - 1; j >= 0; j--)
                {
                    int num_dias_retraso = (int)tabla_origen.Rows[j]["num_dias_retraso"];
                    if (num_dias_retraso >= 1 && num_dias_retraso <= 30) { tabla_origen.Rows.RemoveAt(j); }
                }
            }
            tabla_origen.DefaultView.Sort = orden;
            return tabla_origen.DefaultView.ToTable();
        }



        public static DataTable CarteraVigente3(DateTime Fecha, int Id_grupoventa, string Tipo_grupo, int Id_grupopromotor, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[numero_contrato],[negocio],[grupo],[grupo_actual],[promotor],[promotor_corto],[fecha_registro],[fecha_ultimo_pago],[interes_fecha],[fecha_proximo]
            //[interes_corriente],[num_cuotas],[cuota_base],[precio_final],[total_amortizacion],[total_aporte],[saldo],
            //[codigo_moneda],[tipo_cambio],
            //[num_dias_retraso],[especial],[rango],[num_cuotas_adeuda],[monto_adeuda],[capital_adeuda],[interes_adeuda],[mantenimiento_adeuda]
            //[lote],[cliente_nombre],[cliente_direccion],[cliente_telefono]
            //[pp_seguro],[pp_mantenimiento_sus],[pp_interes_corriente],[pp_cuota_base],[pp_fecha_inicio_plan]
            //[id_ultimo_pago],[p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            DataTable tabla;
            if (Consolidado == false) { tabla = CarteraVigente3_original(Fecha, Id_grupoventa, Tipo_grupo, Id_grupopromotor, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = CarteraVigente3_original(Fecha, Id_grupoventa, Tipo_grupo, Id_grupopromotor, Id_negocio, Id_moneda);
                    tabla_bs = CarteraVigente3_original(Fecha, Id_grupoventa, Tipo_grupo, Id_grupopromotor, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = CarteraVigente3_original(Fecha, Id_grupoventa, Tipo_grupo, Id_grupopromotor, Id_negocio, Id_segunda_moneda);
                    tabla_bs = CarteraVigente3_original(Fecha, Id_grupoventa, Tipo_grupo, Id_grupopromotor, Id_negocio, Id_moneda);
                }
                tabla = general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "cuota_base,precio_final,total_amortizacion,total_aporte,saldo,pp_mantenimiento_sus,pp_cuota_base,p_seguro,p_mantenimiento_sus,p_interes,p_monto_pago,p_amortizacion,p_saldo", false, false, "", "");
            }

            //Se obtienen los datos de los pagos que se adeudan
            int num_cuotas_adeuda = 0; decimal monto_adeuda = 0; decimal capital_adeuda = 0; decimal interes_adeuda = 0; decimal mantenimiento_adeuda = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                PagosRestantes(Fecha, ref num_cuotas_adeuda, ref monto_adeuda, ref capital_adeuda, ref interes_adeuda, ref mantenimiento_adeuda,
                    (decimal)fila["pp_interes_corriente"], (decimal)fila["pp_mantenimiento_sus"], (decimal)fila["pp_seguro"], (decimal)fila["pp_cuota_base"], (DateTime)fila["pp_fecha_inicio_plan"]
                    , (int)fila["id_ultimo_pago"], (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"], (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"], (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);
                fila["num_cuotas_adeuda"] = num_cuotas_adeuda;
                fila["monto_adeuda"] = monto_adeuda;
                fila["capital_adeuda"] = capital_adeuda;
                fila["interes_adeuda"] = interes_adeuda;
                fila["mantenimiento_adeuda"] = mantenimiento_adeuda;
            }
            return tabla;
        }
        private static DataTable CarteraVigente3_original(DateTime Fecha, int Id_grupoventa, string Tipo_grupo, int Id_grupopromotor, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraVigente3");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "tipo_grupo", DbType.String, Tipo_grupo);
            db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, Id_grupopromotor);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        private static void PagosRestantes(DateTime Fecha,
            ref int num_cuotas_adeuda, ref decimal monto_adeuda, ref decimal capital_adeuda, ref decimal interes_adeuda, ref decimal mantenimiento_adeuda,
            decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago,
            DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha, decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes, int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
        {
            num_cuotas_adeuda = 0; monto_adeuda = 0; capital_adeuda = 0; interes_adeuda = 0; mantenimiento_adeuda = 0;

            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha, p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes, p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

            Fecha = Fecha.Date.AddDays(1).AddSeconds(-1);
            DateTime Fecha_pago;
            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                Fecha_pago = pago_simulado.fecha_proximo;
                pago_simulado = new sim_pago(pago_simulado, Fecha_pago, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
                if (Fecha_pago < Fecha)
                {
                    num_cuotas_adeuda += 1;
                    monto_adeuda += pago_simulado.monto_pago;
                    capital_adeuda += pago_simulado.amortizacion;
                    interes_adeuda += pago_simulado.interes;
                    mantenimiento_adeuda += pago_simulado.mantenimiento_sus;
                }
                else { break; }
            }
        }

        private static int busca_index(ref DataTable tabla, string columna, string valor)
        {
            int index = -1;
            for (int j = 0; j < tabla.Rows.Count; j++) { if (tabla.Rows[j][columna].ToString() == valor) { index = j; break; } }
            return index;
        }
        private static int busca_index(ref DataTable tabla, string columna1, string valor1, string columna2, string valor2)
        {
            int index = -1;
            for (int j = 0; j < tabla.Rows.Count; j++)
            {
                if (tabla.Rows[j][columna1].ToString() == valor1 && tabla.Rows[j][columna2].ToString() == valor2)
                {
                    index = j; 
                    break;
                }
            }
            return index;
        }



        public static DataTable CarteraEvolucion(DataTable tabla, ref DataTable tabla_fin, string col_grupo)
        {
            //Resumen: numero_contrato,grupo,promotor,promotor_corto,precio_final,
            //especial,rango,num_dias_retraso,saldo,monto_adeuda,capital_adeuda
            //Detalle:numero_contrato,codigo_moneda,especial,grupo,promotor,promotor_corto,lote,cliente_nombre,cliente_direccion,cliente_telefono,precio_final,interes_corriente,num_cuotas,cuota_base
            //fecha_ultimo_pago,interes_fecha,fecha_proximo,rango,num_dias_retraso,num_cuotas_adeuda,num_dias_mora,num_cuotas_mora,total_amortizacion,saldo,monto_adeuda,capital_adeuda,interes_adeuda

            //Base: [numero_contrato],[codigo_moneda],[especial],[grupo],[promotor],[promotor_corto]
            //[lote],[cliente_nombre],[cliente_direccion],[cliente_telefono]
            //[precio_final],[interes_corriente],[num_cuotas],[cuota_base]

            //Movil: [fecha_ultimo_pago],[interes_fecha],[fecha_proximo]
            //[rango][num_dias_retraso],[num_cuotas_adeuda],[num_dias_mora],[num_cuotas_mora]
            //[total_amortizacion],[saldo],[monto_adeuda],[capital_adeuda],[interes_adeuda]
            
            //Si es necesario se reemplaza la información del grupo con la de otra columan
            if (col_grupo != "grupo")
            {
                foreach (DataRow fila in tabla.Rows) { fila["grupo"] = fila[col_grupo].ToString(); }
                foreach (DataRow fila_fin in tabla_fin.Rows) { fila_fin["grupo"] = fila_fin[col_grupo].ToString(); }
            }

            //string columnas_base = ",numero_contrato,codigo_moneda,grupo,grupo_actual,promotor,promotor_corto,lote,cliente_nombre,cliente_telefono,precio_final,";
            string columnas_base = ",numero_contrato,codigo_moneda,grupo,promotor,promotor_corto,lote,cliente_nombre,cliente_telefono,precio_final,";
            string columnas_moviles = ",especial,fecha_ultimo_pago,interes_fecha,rango,num_dias_retraso,num_cuotas_adeuda,saldo,monto_adeuda,capital_adeuda,interes_adeuda,";
            string[] lista_columnas_mobiles = columnas_moviles.TrimStart(',').TrimEnd(',').Split(',');
            string[] lista_columnas_base = columnas_base.TrimStart(',').TrimEnd(',').Split(',');
            //Se eliminan las columnas que no se utilizarán
            for (int j = tabla.Columns.Count - 1; j >= 0; j--)
            {
                if (columnas_base.Contains("," + tabla.Columns[j].ColumnName + ",") == false && columnas_moviles.Contains("," + tabla.Columns[j].ColumnName + ",") == false)
                {
                    tabla.Columns.RemoveAt(j);
                }
            }

            //Tabla Inicio: Se renombran las columnas de inicio y se crean las columans finales
            for (int j = 0; j < lista_columnas_mobiles.Length; j++)
            {
                DataColumn col = tabla.Columns[lista_columnas_mobiles[j]];
                tabla.Columns[lista_columnas_mobiles[j]].ColumnName = "ini_" + lista_columnas_mobiles[j];
                tabla.Columns.Add("fin_" + lista_columnas_mobiles[j], col.DataType);
            }

            //Se copian los resultados de la tabla_fin y se arma el listado de los contratos de la tabla 1 que fueron revertidos o cancelados
            List<string> lista_revertido_cancelado = new List<string>();
            List<string> lista_vendido_reactivado = new List<string>();
            int index = -1;
            string numero_contrato = "";
            foreach (DataRow fila in tabla.Rows)
            {
                numero_contrato = fila["numero_contrato"].ToString();
                index = busca_index(ref tabla_fin, "numero_contrato", numero_contrato);
                if (index >= 0)
                {
                    for (int j = 0; j < lista_columnas_mobiles.Length; j++)
                    {
                        if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(string)) { fila["fin_" + lista_columnas_mobiles[j]] = tabla_fin.Rows[index][lista_columnas_mobiles[j]].ToString(); }
                        else if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(int)) { fila["fin_" + lista_columnas_mobiles[j]] = (int)tabla_fin.Rows[index][lista_columnas_mobiles[j]]; }
                        else if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(decimal)) { fila["fin_" + lista_columnas_mobiles[j]] = (decimal)tabla_fin.Rows[index][lista_columnas_mobiles[j]]; }//Math.Round((decimal)tabla_fin.Rows[index][tabla_fin.Columns[j].ColumnName], 2); }
                        else if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(DateTime)) { fila["fin_" + lista_columnas_mobiles[j]] = (DateTime)tabla_fin.Rows[index][lista_columnas_mobiles[j]]; }
                    }
                }
                else { lista_revertido_cancelado.Add(numero_contrato); }
            }


            //Se completan las filas de contratos que no están en la primera tabla
            foreach (DataRow fila in tabla_fin.Rows)
            {
                numero_contrato = fila["numero_contrato"].ToString();
                if (busca_index(ref tabla, "numero_contrato", numero_contrato) < 0)
                {
                    DataRow nueva_fila = tabla.NewRow();
                    for (int j = 0; j < lista_columnas_base.Length; j++)
                    {
                        if (tabla_fin.Columns[lista_columnas_base[j]].DataType == typeof(string)) { nueva_fila[lista_columnas_base[j]] = fila[lista_columnas_base[j]].ToString(); }
                        else if (tabla_fin.Columns[lista_columnas_base[j]].DataType == typeof(int)) { nueva_fila[lista_columnas_base[j]] = (int)fila[lista_columnas_base[j]]; }
                        else if (tabla_fin.Columns[lista_columnas_base[j]].DataType == typeof(decimal)) { nueva_fila[lista_columnas_base[j]] = (decimal)fila[lista_columnas_base[j]]; }//Math.Round((decimal)fila[lista_columnas_base[j]], 2); }
                        else if (tabla_fin.Columns[lista_columnas_base[j]].DataType == typeof(DateTime)) { nueva_fila[lista_columnas_base[j]] = (DateTime)fila[lista_columnas_base[j]]; }
                    }
                    if (tabla.Columns.IndexOf("ini_rango") >= 0) { nueva_fila["ini_rango"] = "Contratos vendidos o reactivados"; }
                    for (int j = 0; j < lista_columnas_mobiles.Length; j++)
                    {
                        if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(string)) { nueva_fila["fin_" + lista_columnas_mobiles[j]] = fila[lista_columnas_mobiles[j]].ToString(); }
                        else if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(int)) { nueva_fila["fin_" + lista_columnas_mobiles[j]] = (int)fila[lista_columnas_mobiles[j]]; }
                        else if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(decimal)) { nueva_fila["fin_" + lista_columnas_mobiles[j]] = (decimal)fila[lista_columnas_mobiles[j]]; }//Math.Round((decimal)tabla_fin.Rows[index][tabla_fin.Columns[j].ColumnName], 2); }
                        else if (tabla_fin.Columns[lista_columnas_mobiles[j]].DataType == typeof(DateTime)) { nueva_fila["fin_" + lista_columnas_mobiles[j]] = (DateTime)fila[lista_columnas_mobiles[j]]; }
                    }
                    tabla.Rows.Add(nueva_fila);
                    lista_vendido_reactivado.Add(numero_contrato);
                }
            }
            return tabla;
        }

        public static DataTable CarteraEvolucionResumen(DataTable tabla, string Orden)
        {
            //string columnas_moviles = ",fin_especial,fin_rango,fin_num_dias_retraso,fin_saldo,fin_monto_adeuda,fin_capital_adeuda,";
            //string columnas_moviles = ",fin_saldo,fin_monto_adeuda,fin_capital_adeuda,";
            string columnas_moviles = ",saldo,monto_adeuda,";
            string[] lista_columnas_mobiles = columnas_moviles.TrimStart(',').TrimEnd(',').Split(',');

            for (int j = 0; j < lista_columnas_mobiles.Length; j++)
            {
                DataColumn col = tabla.Columns["fin_" + lista_columnas_mobiles[j]];

                tabla.Columns.Add("d0_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d1_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d31_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d61_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d91_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d121_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("desp_ini_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("rev_ini_" + lista_columnas_mobiles[j], col.DataType);

                tabla.Columns.Add("d0_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d1_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d31_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d61_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d91_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("d121_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("desp_fin_" + lista_columnas_mobiles[j], col.DataType);
                tabla.Columns.Add("rev_fin_" + lista_columnas_mobiles[j], col.DataType);

            }

            foreach (DataRow fila in tabla.Rows)
            {
                if (fila.IsNull("fin_num_dias_retraso") == true) { for (int j = 0; j < lista_columnas_mobiles.Length; j++) { fila["rev_ini_" + lista_columnas_mobiles[j]] = (decimal)fila["ini_" + lista_columnas_mobiles[j]]; } }
                else
                {
                    int especial = (int)fila["fin_especial"];
                    int num_dias_retraso = (int)fila["fin_num_dias_retraso"];

                    string subfijo = "";
                    if (especial == 0 && num_dias_retraso == 0) subfijo = "d0";
                    else if (especial == 0 && num_dias_retraso >= 1 && num_dias_retraso <= 30) subfijo = "d1";
                    else if (especial == 0 && num_dias_retraso >= 31 && num_dias_retraso <= 60) subfijo = "d31";
                    else if (especial == 0 && num_dias_retraso >= 61 && num_dias_retraso <= 90) subfijo = "d61";
                    else if (especial == 0 && num_dias_retraso >= 91 && num_dias_retraso <= 120) subfijo = "d91";
                    else if (especial == 0 && num_dias_retraso >= 121) subfijo = "d121";
                    else if (especial == 1) subfijo = "desp";
                    for (int j = 0; j < lista_columnas_mobiles.Length; j++)
                    {
                        if (fila.IsNull("ini_" + lista_columnas_mobiles[j]) == false) fila[subfijo + "_ini_" + lista_columnas_mobiles[j]] = (decimal)fila["ini_" + lista_columnas_mobiles[j]];
                        fila[subfijo + "_fin_" + lista_columnas_mobiles[j]] = (decimal)fila["fin_" + lista_columnas_mobiles[j]];
                    }
                }
            }
            if (Orden == "") { return tabla; }
            else
            {
                tabla.DefaultView.Sort = Orden;
                return tabla.DefaultView.ToTable();
            }
        }


    }
}
