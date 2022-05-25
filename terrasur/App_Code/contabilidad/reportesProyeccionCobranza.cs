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
using System.Collections;

/// <summary>
/// Descripción breve de reportesCarteraRetraso
/// </summary>
namespace terrasur
{
    public class reportesProyeccionCobranza
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
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
                    index = j; break;
                }
            }
            return index;
        }

        public static DataTable Resumen(ref DataTable tabla_origen, string orden)
        {
            //rango,num_contratos,saldo,pend_num,pend_monto,pend_capital,pend_interes,pend_manten,proy_num,proy_monto,proy_capital,proy_interes,proy_manten,tot_num,tot_monto,tot_capital,tot_interes,tot_manten
            //eje_pend_num,eje_pend_monto,eje_pend_capital,eje_pend_interes,eje_pend_manten,eje_proy_num,eje_proy_monto,eje_proy_capital,eje_proy_interes,eje_proy_manten,eje_ade_num,eje_ade_monto,eje_ade_capital,eje_ade_interes,eje_ade_manten,eje_cap_num,eje_cap_monto,eje_cap_capital,eje_nue_num,eje_nue_monto,eje_nue_capital,eje_tot_num,eje_tot_monto,eje_tot_capital,eje_tot_interes,eje_tot_manten
            DataTable tabla = new DataTable();
            tabla.Columns.Add("tipo", typeof(string));
            tabla.Columns.Add("orden_tipo", typeof(int));
            tabla.Columns.Add("rango", typeof(string));
            tabla.Columns.Add("grupo", typeof(string));
            tabla.Columns.Add("promotor", typeof(string));
            tabla.Columns.Add("numero_contrato", typeof(string));

            tabla.Columns.Add("num_contratos", typeof(int));
            tabla.Columns.Add("saldo", typeof(decimal));

            string[] lista_cols = "pend_num,pend_monto,proy_num,proy_monto,ade_num,ade_monto,cap_num,cap_monto,nue_num,nue_monto,tot_num,tot_monto".Split(',');
            for (int j = 0; j < lista_cols.Length; j++) { tabla.Columns.Add(lista_cols[j], tabla_origen.Columns["eje_" + lista_cols[j]].DataType); }
            string[] lista_cols_proy = "pend_num,pend_monto,proy_num,proy_monto,tot_num,tot_monto".Split(',');
            string[] lista_cols_ejec = "pend_num,pend_monto,proy_num,proy_monto,ade_num,ade_monto,cap_num,cap_monto,nue_num,nue_monto,tot_num,tot_monto".Split(',');
            string columna;

            int pend_num = 0; int proy_num = 0; int eje_pend_num = 0; int eje_proy_num = 0;
            decimal pend_monto = 0; decimal proy_monto = 0; decimal eje_pend_monto = 0; decimal eje_proy_monto = 0;
            int aux_proy_int = 0; int aux_eje_int = 0;
            decimal aux_proy_decimal = 0;decimal aux_eje_decimal = 0;
            foreach (DataRow fila_origen in tabla_origen.Rows)
            {
                //Para el registro de "Proyectado"
                DataRow fila_proy = tabla.NewRow();
                fila_proy["tipo"] = "Por cobrar";
                fila_proy["orden_tipo"] = 1;
                fila_proy["rango"] = fila_origen["rango"].ToString();

                fila_proy["grupo"] = fila_origen["grupo"].ToString();
                fila_proy["promotor"] = fila_origen["promotor"].ToString();
                fila_proy["numero_contrato"] = fila_origen["numero_contrato"].ToString();

                if (fila_origen.IsNull("saldo") == false)
                {
                    if (((decimal)fila_origen["saldo"]) > 0) { fila_proy["num_contratos"] = 1; fila_proy["saldo"] = (decimal)fila_origen["saldo"]; }
                    else { fila_proy["num_contratos"] = 0; fila_proy["saldo"] = 0; }
                }
                else { fila_proy["num_contratos"] = 0; fila_proy["saldo"] = 0; }

                for (int j = 0; j < lista_cols_proy.Length; j++)
                {
                    columna = lista_cols_proy[j];
                    if (tabla.Columns[columna].DataType == typeof(string)) { fila_proy[columna] = fila_origen[columna].ToString(); }
                    else if (tabla.Columns[columna].DataType == typeof(int)) { if (fila_origen.IsNull(columna) == false) { fila_proy[columna] = (int)fila_origen[columna]; } else { fila_proy[columna] = 0; } }
                    else if (tabla.Columns[columna].DataType == typeof(decimal)) { if (fila_origen.IsNull(columna) == false) { fila_proy[columna] = (decimal)fila_origen[columna]; } else { fila_proy[columna] = 0; } }
                }
                tabla.Rows.Add(fila_proy);

                //Para el registro de "Ejecutado"
                DataRow fila_ejec = tabla.NewRow();
                fila_ejec["tipo"] = "Cobrado";
                fila_ejec["orden_tipo"] = 2;
                fila_ejec["rango"] = fila_origen["rango"].ToString();

                fila_ejec["grupo"] = fila_origen["grupo"].ToString();
                fila_ejec["promotor"] = fila_origen["promotor"].ToString();
                fila_ejec["numero_contrato"] = fila_origen["numero_contrato"].ToString();

                for (int j = 0; j < lista_cols_ejec.Length; j++)
                {
                    columna = lista_cols_ejec[j];
                    if (tabla.Columns[columna].DataType == typeof(string)) { fila_ejec[columna] = fila_origen["eje_" + columna].ToString(); }
                    else if (tabla.Columns[columna].DataType == typeof(int)) { if (fila_origen.IsNull("eje_" + columna) == false) { fila_ejec[columna] = (int)fila_origen["eje_" + columna]; } else { fila_ejec[columna] = 0; } }
                    else if (tabla.Columns[columna].DataType == typeof(decimal)) { if (fila_origen.IsNull("eje_" + columna) == false) { fila_ejec[columna] = (decimal)fila_origen["eje_" + columna]; } else { fila_ejec[columna] = 0; } }
                }
                tabla.Rows.Add(fila_ejec);

                
                //Para el registro de "No cobrado"
                DataRow fila_no_ejec = tabla.NewRow();
                fila_no_ejec["tipo"] = "No Cobrado";
                fila_no_ejec["orden_tipo"] = 3;
                fila_no_ejec["rango"] = fila_origen["rango"].ToString();

                fila_no_ejec["grupo"] = fila_origen["grupo"].ToString();
                fila_no_ejec["promotor"] = fila_origen["promotor"].ToString();
                fila_no_ejec["numero_contrato"] = fila_origen["numero_contrato"].ToString();

                //string[] lista_cols_proy = "pend_num,pend_monto,proy_num,proy_monto,                                                      tot_num,tot_monto".Split(',');
                //string[] lista_cols_ejec = "pend_num,pend_monto,proy_num,proy_monto,ade_num,ade_monto,cap_num,cap_monto,nue_num,nue_monto,tot_num,tot_monto".Split(',');
                for (int j = 0; j < lista_cols_proy.Length; j++)
                {
                    columna = lista_cols_proy[j];
                    if (columna == "tot_num")
                    {
                        pend_num = 0; if (fila_origen.IsNull("pend_num") == false) { pend_num = (int)fila_origen["pend_num"]; }
                        proy_num = 0; if (fila_origen.IsNull("proy_num") == false) { proy_num = (int)fila_origen["proy_num"]; }
                        eje_pend_num = 0; if (fila_origen.IsNull("eje_pend_num") == false) { eje_pend_num = (int)fila_origen["eje_pend_num"]; }
                        eje_proy_num = 0; if (fila_origen.IsNull("eje_proy_num") == false) { eje_proy_num = (int)fila_origen["eje_proy_num"]; }
                        fila_no_ejec[columna] = (pend_num + proy_num) - (eje_pend_num + eje_proy_num);
                    }
                    else if (columna == "tot_monto")
                    {
                        pend_monto = 0; if (fila_origen.IsNull("pend_monto") == false) { pend_monto = (decimal)fila_origen["pend_monto"]; }
                        proy_monto = 0; if (fila_origen.IsNull("proy_monto") == false) { proy_monto = (decimal)fila_origen["proy_monto"]; }
                        eje_pend_monto = 0; if (fila_origen.IsNull("eje_pend_monto") == false) { eje_pend_monto = (decimal)fila_origen["eje_pend_monto"]; }
                        eje_proy_monto = 0; if (fila_origen.IsNull("eje_proy_monto") == false) { eje_proy_monto = (decimal)fila_origen["eje_proy_monto"]; }
                        fila_no_ejec[columna] = (pend_monto + proy_monto) - (eje_pend_monto + eje_proy_monto);
                    }
                    else if (tabla.Columns[columna].DataType == typeof(string)) { fila_no_ejec[columna] = fila_origen[columna].ToString(); }
                    else if (tabla.Columns[columna].DataType == typeof(int))
                    {
                        aux_proy_int = 0; if (fila_origen.IsNull(columna) == false) { aux_proy_int = (int)fila_origen[columna]; }
                        aux_eje_int = 0; if (fila_origen.IsNull("eje_" + columna) == false) { aux_eje_int = (int)fila_origen["eje_" + columna]; }
                        fila_no_ejec[columna] = aux_proy_int - aux_eje_int;
                    }
                    else if (tabla.Columns[columna].DataType == typeof(decimal))
                    {
                        aux_proy_decimal = 0; if (fila_origen.IsNull(columna) == false) { aux_proy_decimal = (decimal)fila_origen[columna]; }
                        aux_eje_decimal = 0; if (fila_origen.IsNull("eje_" + columna) == false) { aux_eje_decimal = (decimal)fila_origen["eje_" + columna]; }
                        fila_no_ejec[columna] = aux_proy_decimal - aux_eje_decimal;
                    }
                }
                tabla.Rows.Add(fila_no_ejec);
            }
            tabla.DefaultView.Sort = orden;
            return tabla.DefaultView.ToTable();
        }

        public static DataTable ResumenGrupos(ref DataTable tabla, string tipo, string col_valor, string orden)
        {
            DataTable tabla_grupo = new DataTable();
            tabla_grupo.Columns.Add("grupo", typeof(string));
            tabla_grupo.Columns.Add("valor", typeof(decimal));
            int index;
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["tipo"].ToString() == tipo)
                {
                    index = busca_index(ref tabla_grupo, "grupo", fila["grupo"].ToString());
                    if (index < 0)
                    {
                        DataRow fila_grupo = tabla_grupo.NewRow();
                        fila_grupo["grupo"] = fila["grupo"].ToString();
                        fila_grupo["valor"] = (decimal)fila[col_valor];
                        tabla_grupo.Rows.Add(fila_grupo);
                    }
                    else
                    {
                        tabla_grupo.Rows[index]["valor"] = ((decimal)tabla_grupo.Rows[index]["valor"]) + ((decimal)fila[col_valor]);
                    }
                }
            }
            
            tabla_grupo.DefaultView.Sort = "valor";
            DataTable tabla_grupo_ordenada = tabla_grupo.DefaultView.ToTable();
            Hashtable hash_grupo = new Hashtable();
            for (int j = 0; j < tabla_grupo_ordenada.Rows.Count; j++) { hash_grupo.Add(tabla_grupo_ordenada.Rows[j]["grupo"], j + 1); }
            tabla.Columns.Add("orden_grupo", typeof(int));
            foreach (DataRow fila in tabla.Rows) { fila["orden_grupo"] = (int)hash_grupo[fila["grupo"].ToString()]; }

            tabla.DefaultView.Sort=orden;

            return tabla.DefaultView.ToTable();
        }

        public static DataTable ResumenPromotores(ref DataTable tabla, string tipo, string col_valor, string orden)
        {
            DataTable tabla_promotor = new DataTable();
            tabla_promotor.Columns.Add("grupo", typeof(string));
            tabla_promotor.Columns.Add("promotor", typeof(string));
            tabla_promotor.Columns.Add("valor", typeof(decimal));
            int index;
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["tipo"].ToString() == tipo)
                {
                    index = busca_index(ref tabla_promotor, "grupo", fila["grupo"].ToString(), "promotor", fila["promotor"].ToString());
                    if (index < 0)
                    {
                        DataRow fila_promotor = tabla_promotor.NewRow();
                        fila_promotor["grupo"] = fila["grupo"].ToString();
                        fila_promotor["promotor"] = fila["promotor"].ToString();
                        fila_promotor["valor"] = (decimal)fila[col_valor];
                        tabla_promotor.Rows.Add(fila_promotor);
                    }
                    else
                    {
                        tabla_promotor.Rows[index]["valor"] = ((decimal)tabla_promotor.Rows[index]["valor"]) + ((decimal)fila[col_valor]);
                    }
                }
            }

            tabla_promotor.DefaultView.Sort = "valor";
            DataTable tabla_promotor_ordenada = tabla_promotor.DefaultView.ToTable();
            Hashtable hash_grupo_promotor = new Hashtable();
            for (int j = 0; j < tabla_promotor_ordenada.Rows.Count; j++) { hash_grupo_promotor.Add(tabla_promotor_ordenada.Rows[j]["grupo"].ToString() + ',' + tabla_promotor_ordenada.Rows[j]["promotor"].ToString(), j + 1); }
            tabla.Columns.Add("orden_promotor", typeof(int));
            foreach (DataRow fila in tabla.Rows) { fila["orden_promotor"] = (int)hash_grupo_promotor[fila["grupo"].ToString() + ',' + fila["promotor"].ToString()]; }

            tabla.DefaultView.Sort = orden;

            return tabla.DefaultView.ToTable();
        }



        public static DataTable CarteraProyectadoEjecutado(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa, string Tipo_grupo, string Id_negocio, int Id_moneda, bool Consolidado, bool con_ejecutado, DateTime Ejecutado_fecha_inicio, DateTime Ejecutado_fecha_fin, string col_grupo, string orden)
        {
            DataTable tabla = CarteraProyectado(Fecha_inicio.AddDays(-1), Id_grupoventa, Tipo_grupo, Id_negocio, Id_moneda, Consolidado);
            DatosPagosProyectados(ref tabla, Fecha_inicio, Fecha_fin);
            if (con_ejecutado == true)
            {
                DataTable tabla_pagos = CarteraCobrosRealizados(Ejecutado_fecha_inicio, Ejecutado_fecha_fin, Id_grupoventa, Tipo_grupo, Id_negocio, Id_moneda, Consolidado);
                CompletarContratosPagados(ref tabla, ref tabla_pagos, Fecha_fin, Id_moneda);
                ClasificarPagos(ref tabla, ref tabla_pagos, Fecha_inicio, Fecha_fin);
            }

            if (col_grupo != "grupo") { foreach (DataRow fila in tabla.Rows) { fila["grupo"] = fila[col_grupo].ToString(); } }

            if (orden == "") { return tabla; }
            else
            {
                tabla.DefaultView.Sort = orden;
                return tabla.DefaultView.ToTable();
            }
        }
        
        private static void DatosPagosProyectados(ref DataTable tabla, DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            int pend_num = 0; decimal pend_monto = 0; decimal pend_interes = 0; decimal pend_capital = 0; decimal pend_manten = 0;
            int proy_num = 0; decimal proy_monto = 0; decimal proy_interes = 0; decimal proy_capital = 0; decimal proy_manten = 0; DateTime proy_fecha = DateTime.Parse("01/01/1900");

            //pend_num,pend_monto,pend_interes,pend_capital,pend_manten
            //proy_num,proy_monto,proy_interes,proy_capital,proy_manten
            tabla.Columns.Add("pend_num", typeof(int));
            tabla.Columns.Add("pend_monto", typeof(decimal));
            tabla.Columns.Add("pend_capital", typeof(decimal));
            tabla.Columns.Add("pend_interes", typeof(decimal));
            tabla.Columns.Add("pend_manten", typeof(decimal));

            tabla.Columns.Add("proy_num", typeof(int));
            tabla.Columns.Add("proy_monto", typeof(decimal));
            tabla.Columns.Add("proy_capital", typeof(decimal));
            tabla.Columns.Add("proy_interes", typeof(decimal));
            tabla.Columns.Add("proy_manten", typeof(decimal));
            tabla.Columns.Add("proy_fecha", typeof(DateTime));

            tabla.Columns.Add("tot_num", typeof(int));
            tabla.Columns.Add("tot_monto", typeof(decimal));
            tabla.Columns.Add("tot_capital", typeof(decimal));
            tabla.Columns.Add("tot_interes", typeof(decimal));
            tabla.Columns.Add("tot_manten", typeof(decimal));

            foreach (DataRow fila in tabla.Rows)
            {
                PagosRestantes_Periodo(Fecha_inicio, Fecha_fin,
                    ref pend_num, ref pend_monto, ref pend_interes, ref pend_capital, ref pend_manten,
                    ref proy_num, ref proy_monto, ref proy_interes, ref proy_capital, ref proy_manten, ref proy_fecha,

                    (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"]
                    , (int)fila["id_ultimo_pago"]
                    , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                    , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                    , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

                fila["pend_num"] = pend_num;
                fila["pend_monto"] = pend_monto;
                fila["pend_capital"] = pend_capital;
                fila["pend_interes"] = pend_interes;
                fila["pend_manten"] = pend_manten;

                fila["proy_num"] = proy_num;
                fila["proy_monto"] = proy_monto;
                fila["proy_capital"] = proy_capital;
                fila["proy_interes"] = proy_interes;
                fila["proy_manten"] = proy_manten;
                if (proy_fecha > DateTime.Parse("01/01/1900")) { fila["proy_fecha"] = proy_fecha; }

                fila["tot_num"] = pend_num + proy_num;
                fila["tot_monto"] = pend_monto + proy_monto;
                fila["tot_capital"] = pend_capital + proy_capital;
                fila["tot_interes"] = pend_interes + proy_interes;
                fila["tot_manten"] = pend_manten + proy_manten;
            }
        }
        private static void CompletarContratosPagados(ref DataTable tabla, ref DataTable tabla_pagos, DateTime Fecha_fin, int Id_moneda)
        {
            List<string> lista_contratos = new List<string>();
            foreach (DataRow fila_pago in tabla_pagos.Rows)
            {
                if (busca_index(ref tabla, "numero_contrato", fila_pago["numero_contrato"].ToString()) < 0)
                {
                    bool existe_en_listado = false;
                    foreach (string item in lista_contratos) { if (item == fila_pago["numero_contrato"].ToString()) { existe_en_listado = true; break; } }
                    if (existe_en_listado == false) { lista_contratos.Add(fila_pago["numero_contrato"].ToString()); }
                }
            }

            for (int j = 0; j < lista_contratos.Count; j++)
            {
                DataRow fila = tabla.NewRow();
                fila["numero_contrato"] = lista_contratos[j];
                fila["pend_num"] = 0; fila["pend_monto"] = 0; fila["pend_interes"] = 0; fila["pend_capital"] = 0; fila["pend_manten"] = 0;
                fila["proy_num"] = 0; fila["proy_monto"] = 0; fila["proy_interes"] = 0; fila["proy_capital"] = 0; fila["proy_manten"] = 0;
                tabla.Rows.Add(fila);
            }

            DataTable tabla_datos_contratos = DatosContratosIncorporados(Fecha_fin, Id_moneda, ref lista_contratos);
            foreach (DataRow fila_contratos in tabla_datos_contratos.Rows)
            {
                int index_contrato = busca_index(ref tabla, "numero_contrato", fila_contratos["numero_contrato"].ToString());
                foreach (DataColumn columna in tabla_datos_contratos.Columns)
                {
                    if (columna.DataType == typeof(string)) { tabla.Rows[index_contrato][columna.ColumnName] = fila_contratos[columna.ColumnName].ToString(); }
                    else if (columna.DataType == typeof(int) && fila_contratos.IsNull(columna.ColumnName) == false) { tabla.Rows[index_contrato][columna.ColumnName] = (int)fila_contratos[columna.ColumnName]; }
                    else if (columna.DataType == typeof(decimal) && fila_contratos.IsNull(columna.ColumnName) == false) { tabla.Rows[index_contrato][columna.ColumnName] = (decimal)fila_contratos[columna.ColumnName]; }
                    else if (columna.DataType == typeof(DateTime) && fila_contratos.IsNull(columna.ColumnName) == false) { tabla.Rows[index_contrato][columna.ColumnName] = (DateTime)fila_contratos[columna.ColumnName]; }
                }
            }
        }
        private static void ClasificarPagos(ref DataTable tabla, ref DataTable tabla_pagos, DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            Fecha_fin = Fecha_fin.Date.AddDays(1).AddSeconds(-1);

            tabla.Columns.Add("eje_pend_num", typeof(int)); tabla.Columns.Add("eje_pend_monto", typeof(decimal)); tabla.Columns.Add("eje_pend_capital", typeof(decimal)); tabla.Columns.Add("eje_pend_interes", typeof(decimal)); tabla.Columns.Add("eje_pend_manten", typeof(decimal));
            tabla.Columns.Add("eje_proy_num", typeof(int)); tabla.Columns.Add("eje_proy_monto", typeof(decimal)); tabla.Columns.Add("eje_proy_capital", typeof(decimal)); tabla.Columns.Add("eje_proy_interes", typeof(decimal)); tabla.Columns.Add("eje_proy_manten", typeof(decimal));
            tabla.Columns.Add("eje_ade_num", typeof(int)); tabla.Columns.Add("eje_ade_monto", typeof(decimal)); tabla.Columns.Add("eje_ade_capital", typeof(decimal)); tabla.Columns.Add("eje_ade_interes", typeof(decimal)); tabla.Columns.Add("eje_ade_manten", typeof(decimal));
            tabla.Columns.Add("eje_cap_num", typeof(int)); tabla.Columns.Add("eje_cap_monto", typeof(decimal)); tabla.Columns.Add("eje_cap_capital", typeof(decimal)); tabla.Columns.Add("eje_cap_interes", typeof(decimal)); tabla.Columns.Add("eje_cap_manten", typeof(decimal));
            tabla.Columns.Add("eje_nue_num", typeof(int)); tabla.Columns.Add("eje_nue_monto", typeof(decimal)); tabla.Columns.Add("eje_nue_capital", typeof(decimal)); tabla.Columns.Add("eje_nue_interes", typeof(decimal)); tabla.Columns.Add("eje_nue_manten", typeof(decimal));
            tabla.Columns.Add("eje_tot_num", typeof(int)); tabla.Columns.Add("eje_tot_monto", typeof(decimal)); tabla.Columns.Add("eje_tot_capital", typeof(decimal)); tabla.Columns.Add("eje_tot_interes", typeof(decimal)); tabla.Columns.Add("eje_tot_manten", typeof(decimal));

            if (tabla_pagos.Rows.Count > 0)
            {
                DateTime fecha; DateTime interes_fecha; string tipo_pago; decimal monto_pago; decimal amortizacion; decimal interes; decimal mantenimiento_sus;
                DateTime nor_fecha; DateTime nor_interes_fecha; int nor_num_pend; int nor_num_proy; decimal nor_monto_pago; decimal nor_amortizacion; decimal nor_interes; decimal nor_mantenimiento_sus;
                //decimal cuota_base;
                decimal saldo_al_inicio; string prefijo;
                decimal pend_monto; decimal pend_interes; decimal pend_capital; decimal pend_manten;
                decimal proy_monto; decimal proy_interes; decimal proy_capital; decimal proy_manten;

                foreach (DataRow fila in tabla.Rows)
                {
                    nor_fecha = DateTime.Parse("01/01/1900");
                    nor_interes_fecha = DateTime.Parse("01/01/1900");
                    nor_num_pend = 0;
                    nor_num_proy = 0;
                    nor_monto_pago = 0;
                    nor_amortizacion = 0;
                    nor_interes = 0;
                    nor_mantenimiento_sus = 0;

                    if (fila.IsNull("saldo") == false) { saldo_al_inicio = (decimal)fila["saldo"]; } else { saldo_al_inicio = 0; }

                    List<int> lista_index = ObtenerListaDatos(ref tabla_pagos, "numero_contrato", fila["numero_contrato"].ToString());
                    for (int j = 0; j < lista_index.Count; j++)
                    {
                        fecha = (DateTime)tabla_pagos.Rows[lista_index[j]]["fecha"];
                        interes_fecha = (DateTime)tabla_pagos.Rows[lista_index[j]]["interes_fecha"];
                        tipo_pago = tabla_pagos.Rows[lista_index[j]]["tipo_pago"].ToString();
                        monto_pago = (decimal)tabla_pagos.Rows[lista_index[j]]["monto_pago"];
                        amortizacion = (decimal)tabla_pagos.Rows[lista_index[j]]["amortizacion"];
                        interes = (decimal)tabla_pagos.Rows[lista_index[j]]["interes"];
                        mantenimiento_sus = (decimal)tabla_pagos.Rows[lista_index[j]]["mantenimiento_sus"];

                        prefijo = "";
                        //if (tipo_pago == "ini")
                        if (saldo_al_inicio == 0) { prefijo = "nue"; }
                        else if (tipo_pago == "cap") { prefijo = "cap"; }
                        else if (tipo_pago == "ade" || interes_fecha.Date > fecha.Date) { prefijo = "ade"; }
                        else
                        {
                            if (interes_fecha >= Fecha_inicio) { nor_num_proy += 1; } else { nor_num_pend += 1; }
                            if (fecha > nor_fecha) nor_fecha = fecha;
                            if (interes_fecha > nor_interes_fecha) nor_interes_fecha = interes_fecha;
                            nor_monto_pago += monto_pago;
                            nor_amortizacion += amortizacion;
                            nor_interes += interes;
                            nor_mantenimiento_sus += mantenimiento_sus;
                        }
                        if (prefijo == "nue" || prefijo == "cap" || prefijo == "ade")
                        {
                            if (fila.IsNull("eje_" + prefijo + "_num") == true)
                            {
                                fila["eje_" + prefijo + "_num"] = 1;
                                fila["eje_" + prefijo + "_monto"] = monto_pago;
                                fila["eje_" + prefijo + "_capital"] = amortizacion;
                                fila["eje_" + prefijo + "_interes"] = interes;
                                fila["eje_" + prefijo + "_manten"] = mantenimiento_sus;
                            }
                            else
                            {
                                fila["eje_" + prefijo + "_num"] = (int)fila["eje_" + prefijo + "_num"] + 1;
                                fila["eje_" + prefijo + "_monto"] = (decimal)fila["eje_" + prefijo + "_monto"] + monto_pago;
                                fila["eje_" + prefijo + "_capital"] = (decimal)fila["eje_" + prefijo + "_capital"] + amortizacion;
                                fila["eje_" + prefijo + "_interes"] = (decimal)fila["eje_" + prefijo + "_interes"] + interes;
                                fila["eje_" + prefijo + "_manten"] = (decimal)fila["eje_" + prefijo + "_manten"] + mantenimiento_sus;
                            }
                        }
                        if (fila.IsNull("eje_tot_num") == true)
                        {
                            fila["eje_tot_num"] = 1;
                            fila["eje_tot_monto"] = monto_pago;
                            fila["eje_tot_capital"] = amortizacion;
                            fila["eje_tot_interes"] = interes;
                            fila["eje_tot_manten"] = mantenimiento_sus;
                        }
                        else
                        {
                            fila["eje_tot_num"] = (int)fila["eje_tot_num"] + 1;
                            fila["eje_tot_monto"] = (decimal)fila["eje_tot_monto"] + monto_pago;
                            fila["eje_tot_capital"] = (decimal)fila["eje_tot_capital"] + amortizacion;
                            fila["eje_tot_interes"] = (decimal)fila["eje_tot_interes"] + interes;
                            fila["eje_tot_manten"] = (decimal)fila["eje_tot_manten"] + mantenimiento_sus;
                        }
                    }

                    //cuota_base = (decimal)fila["cuota_base"];
                    pend_monto = (decimal)fila["pend_monto"]; pend_interes = (decimal)fila["pend_interes"]; pend_capital = (decimal)fila["pend_capital"]; pend_manten = (decimal)fila["pend_manten"];
                    proy_monto = (decimal)fila["proy_monto"]; proy_interes = (decimal)fila["proy_interes"]; proy_capital = (decimal)fila["proy_capital"]; proy_manten = (decimal)fila["proy_manten"];
                    if (nor_monto_pago > 0)
                    {
                        //if (nor_monto_pago >= pend_monto) { fila["eje_pend_num"] = pend_num_cuotas; fila["eje_proy_num"] = Convert.ToInt32((nor_monto_pago - pend_monto) / cuota_base); }
                        //else { fila["eje_pend_num"] = Convert.ToInt32(nor_monto_pago / cuota_base); fila["eje_proy_num"] = 0; }
                        fila["eje_pend_num"] = nor_num_pend;
                        fila["eje_proy_num"] = nor_num_proy;

                        //if (nor_monto_pago <= pend_monto) { fila["eje_pend_monto"] = nor_monto_pago; fila["eje_proy_monto"] = 0; }
                        //else { fila["eje_pend_monto"] = pend_monto; fila["eje_proy_monto"] = nor_monto_pago - pend_monto; }

                        if (nor_amortizacion <= pend_capital) { fila["eje_pend_capital"] = nor_amortizacion; fila["eje_proy_capital"] = 0; }
                        else { fila["eje_pend_capital"] = pend_capital; fila["eje_proy_capital"] = nor_amortizacion - pend_capital; }

                        if (nor_interes <= pend_interes) { fila["eje_pend_interes"] = nor_interes; fila["eje_proy_interes"] = 0; }
                        else { fila["eje_pend_interes"] = pend_interes; fila["eje_proy_interes"] = nor_interes - pend_interes; }

                        if (nor_mantenimiento_sus <= pend_manten) { fila["eje_pend_manten"] = nor_mantenimiento_sus; fila["eje_proy_manten"] = 0; }
                        else { fila["eje_pend_manten"] = pend_manten; fila["eje_proy_manten"] = nor_mantenimiento_sus - pend_manten; }

                        fila["eje_pend_monto"] = ((decimal)fila["eje_pend_capital"]) + ((decimal)fila["eje_pend_interes"]) + ((decimal)fila["eje_pend_manten"]);
                        fila["eje_proy_monto"] = ((decimal)fila["eje_proy_capital"]) + ((decimal)fila["eje_proy_interes"]) + ((decimal)fila["eje_proy_manten"]);
                    }
                }
            }
        }
        private static List<int> ObtenerListaDatos(ref DataTable tabla, string columna, string valor)
        {
            List<int> lista = new List<int>();
            for (int j = 0; j < tabla.Rows.Count; j++) { if (tabla.Rows[j][columna].ToString() == valor) { lista.Add(j); } }
            return lista;
        }
        private static DataTable DatosContratosIncorporados(DateTime Fecha, int Id_moneda, ref List<string> Lista_contratos)
        {
            //[numero_contrato],[negocio],[especial],[grupo],[grupo_actual],[promotor],[promotor_corto],[fecha_registro],[fecha_ultimo_pago],[interes_fecha],[fecha_proximo]
            //[precio_final],[total_amortizacion],[saldo],[codigo_moneda],[tipo_cambio],[lote],[cliente_nombre],[mantenimiento_sus],[interes_corriente],[cuota_base]
            //[rango]
           StringBuilder num_contratos = new StringBuilder();
            if (Lista_contratos.Count > 0)
            {
                num_contratos.Append(",");
                foreach (string item in Lista_contratos)
                {
                    num_contratos.Append(item);
                    num_contratos.Append(",");
                }
            }
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraProyectado_DatosContratosIncorporados");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "num_contratos", DbType.String, num_contratos.ToString());
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable CarteraProyectado(DateTime Fecha, int Id_grupoventa, string Tipo_grupo, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[numero_contrato],[negocio],[especial],[grupo],[grupo_actual],[promotor],[promotor_corto]
            //[fecha_registro],[fecha_ultimo_pago],[interes_fecha],[fecha_proximo]
            //[num_dias_retraso],[num_cuotas_adeuda],[num_dias_mora],[num_cuotas_mora]
            //[precio_final],[total_amortizacion],[saldo]
            //[codigo_moneda],[tipo_cambio]
            //[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan],
            //[id_ultimo_pago],[p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            //[rango]
            if (Consolidado == false) { return CarteraProyectado_original(Fecha, Id_grupoventa, Tipo_grupo, Id_negocio, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = CarteraProyectado_original(Fecha, Id_grupoventa, Tipo_grupo, Id_negocio, Id_moneda);
                    tabla_bs = CarteraProyectado_original(Fecha, Id_grupoventa, Tipo_grupo, Id_negocio, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = CarteraProyectado_original(Fecha, Id_grupoventa, Tipo_grupo, Id_negocio, Id_segunda_moneda);
                    tabla_bs = CarteraProyectado_original(Fecha, Id_grupoventa, Tipo_grupo, Id_negocio, Id_moneda);
                }
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_final,total_amortizacion,saldo,mantenimiento_sus,cuota_base,p_seguro,p_mantenimiento_sus,p_interes,p_monto_pago,p_amortizacion,p_saldo", false, false, "", "");
            }
        }
        private static DataTable CarteraProyectado_original(DateTime Fecha, int Id_grupoventa, string Tipo_grupo, string Id_negocio, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraProyectado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "tipo_grupo", DbType.String, Tipo_grupo);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        private static DataTable CarteraCobrosRealizados(DateTime Fecha_inicio, DateTime Fecha_fin, int Id_grupoventa, string Tipo_grupo, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[numero_contrato],[id_pago],[fecha],[interes_fecha],[tipo_pago],[monto_pago],[amortizacion],[interes],[mantenimiento_sus]
            DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraCobrosRealizados");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "tipo_grupo", DbType.String, Tipo_grupo);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        private static void PagosRestantes_Periodo(DateTime Fecha_inicio, DateTime Fecha_fin,
            ref int pend_num, ref decimal pend_monto, ref decimal pend_interes, ref decimal pend_capital, ref decimal pend_manten,ref int proy_num, ref decimal proy_monto, ref decimal proy_interes, ref decimal proy_capital, ref decimal proy_manten, ref DateTime proy_fecha,
            decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago,
            DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha, decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes, int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
        {
            pend_num = 0; pend_monto = 0; pend_interes = 0; pend_capital = 0; pend_manten = 0;
            proy_num = 0; proy_monto = 0; proy_interes = 0; proy_capital = 0; proy_manten = 0; proy_fecha = DateTime.Parse("01/01/1900");

            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha, p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes, p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);
            
            Fecha_fin = Fecha_fin.Date.AddDays(1).AddSeconds(-1);
            DateTime Fecha_pago;
            //DateTime Fecha_pago = Fecha_inicio.Date.AddDays(-1);
            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                Fecha_pago = pago_simulado.fecha_proximo;
                pago_simulado = new sim_pago(pago_simulado, Fecha_pago, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
                if (Fecha_pago < Fecha_inicio)
                {
                    pend_num += 1;
                    pend_monto += pago_simulado.monto_pago;
                    pend_interes += pago_simulado.interes;
                    pend_capital += pago_simulado.amortizacion;
                    pend_manten += pago_simulado.mantenimiento_sus;
                }
                else if (Fecha_pago < Fecha_fin)
                {
                    proy_num += 1;
                    proy_monto += pago_simulado.monto_pago;
                    proy_interes += pago_simulado.interes;
                    proy_capital += pago_simulado.amortizacion;
                    proy_manten += pago_simulado.mantenimiento_sus;
                    proy_fecha = pago_simulado.fecha;
                }
                else { break; }
                //Fecha_pago = pago_simulado.fecha_proximo;
            }
        }
    }
}
