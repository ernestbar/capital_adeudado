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

/// <summary>
/// Descripción breve de nafibo_tablas
/// </summary>
namespace terrasur
{
    public class nafibo_tablas
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public nafibo_tablas() { }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable Tabla_Titularizacion(string Tipo_tabla, string Numero_contrato, DateTime Fecha, int Id_moneda)
        {
            Numero_contrato = ',' + Numero_contrato.Trim().Trim(',') + ',';
            DataTable tabla;
            switch (Tipo_tabla)
            {
                case "cliente": tabla = obtener_tabla_cliente(Numero_contrato, Fecha, Id_moneda); break;
                case "credito": tabla = obtener_tabla_credito(Numero_contrato, Fecha, Id_moneda); break;
                case "garantia": tabla = obtener_tabla_garantia(Numero_contrato, Fecha, Id_moneda); break;
                case "plan_pago": tabla = obtener_tabla_plan_pago(Numero_contrato, Fecha, Id_moneda); break;
                default: tabla = obtener_tabla_registro_pago(Numero_contrato, Fecha, Id_moneda); break;
            }
            return tabla;
        }

        public static DataTable Tabla_Evaluacion(string Tipo_tabla, string Numero_contrato, DateTime Fecha, int Id_moneda)
        {
            Numero_contrato = ',' + Numero_contrato.Trim().Trim(',') + ',';
            DataTable tabla;
            switch (Tipo_tabla)
            {
                case "cliente": tabla = obtener_tabla_preliminar_cliente(Numero_contrato, Fecha, Id_moneda); break;
                case "credito": tabla = obtener_tabla_preliminar_credito(Numero_contrato, Fecha, Id_moneda); break;
                case "garantia": tabla = obtener_tabla_preliminar_garantia(Numero_contrato, Fecha, Id_moneda); break;
                case "plan_pago": tabla = obtener_tabla_preliminar_plan_pago(Numero_contrato, Fecha, Id_moneda); break;
                default: tabla = obtener_tabla_preliminar_registro_pago(Numero_contrato, Fecha, Id_moneda); break;
            }
            return tabla;
        }


        #region Tablas de Titularización
        protected static DataTable obtener_tabla_cliente(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //FECINFORMACION,NUM_PATRIMONIO,NUM_CREDITO,TIPODOC,NUMDOCIDENTIDAD,NUM_CAEDEC,
            //APELLIDO_PATERNO,APELLIDO_MATERNO,NOMBRES,APELLIDO_CASADA,PATRIMONIO_DECLARADO,
            //PORCENTAJE_PARTICIPACION,MONTO_PROMEDIO_INGRESO,MONEDA_INGRESOS,GENERO,
            //ESTADO_CIVIL,FEC_NACIMIENTO,TIPO_TRABAJO,CAMPO_EXTRA
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_tablas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, num_contrato);
            db1.AddInParameter(cmd, "tipo_reporte", DbType.String, "cliente");
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        protected static DataTable obtener_tabla_credito(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //FECINFORMACION,NUM_PATRIMONIO,NUM_CREDITO,CALIFICACION,TIPO_CREDITO,PLAZO,
            //GRACIA,TIPO_TASA,TASAINTERES,FECINICIO,FECVENCIMIENTO,MONTO_SALDO,DEPARTAMENTO,
            //MONTO_OTORGADO,MONEDA_CREDITO,NUM_CAEDEC,POLITICA_PAGO_CAPITAL,POLITICA_PAGO_INTERES,
            //POLITICA_PREPAGO,SUCURSAL_AGENCIA,TIPO,FECHA_CESION,MONTO_CUOTA,pagado
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_tablas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, num_contrato);
            db1.AddInParameter(cmd, "tipo_reporte", DbType.String, "credito");
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla_credito = db1.ExecuteDataSet(cmd).Tables[0];

            //num_contrato(string),plazo(int),fecha_vencimiento(string)
            DataTable tabla_formato_nafibo = Tabla_formato_nafibo(num_contrato, Fecha, Id_moneda);

            foreach (DataRow fila_credito in tabla_credito.Rows)
            {
                string NUM_CREDITO = fila_credito["NUM_CREDITO"].ToString();
                foreach (DataRow fila_formato in tabla_formato_nafibo.Rows)
                {
                    if (fila_formato["num_contrato"].ToString() == NUM_CREDITO)
                    {
                        fila_credito["PLAZO"] = (int)fila_formato["plazo"];
                        fila_credito["FECVENCIMIENTO"] = fila_formato["fecha_vencimiento"].ToString();
                        break;
                    }
                }
            }
            return tabla_credito;
        }
        protected static DataTable obtener_tabla_garantia(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //FECINFORMACION,NUM_PATRIMONIO,NUM_GARANTIA,NUM_CREDITO,TIPO_GARANTIA,
            //MTOVALORGARANTIA,MTOCOMPROMETIDO,MONEDA_GARANTIA,SEC_DEPARTAMENTO,
            //NRO_PARTIDA_DDRR,FECHA_DDRR,DESCRIPCION_GARANTIA,ZONA
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_tablas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, num_contrato);
            db1.AddInParameter(cmd, "tipo_reporte", DbType.String, "garantia");
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        protected static DataTable obtener_tabla_plan_pago(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            DataTable tabla_resultado = new DataTable();
            tabla_resultado.Columns.Add("FECINFORMACION", typeof(string));
            tabla_resultado.Columns.Add("NUM_PATRIMONIO", typeof(string));
            tabla_resultado.Columns.Add("NUM_CREDITO", typeof(string));
            tabla_resultado.Columns.Add("CONCEPTO", typeof(string));
            tabla_resultado.Columns.Add("NUM_CUOTA", typeof(string));
            tabla_resultado.Columns.Add("FEC_PROGRAMADA", typeof(string));
            tabla_resultado.Columns.Add("MONTO_PROGRAMADO", typeof(string));
            tabla_resultado.Columns.Add("ESTADO", typeof(string));

            DbCommand cmd = db1.GetStoredProcCommand("nafibo_PlanesVigentes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, num_contrato);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            int numero_contrato = int.Parse(tabla.Rows[0]["numero"].ToString());
            int num_filas = tabla.Rows.Count;
            int num_pago = 0;
            for (int index = 0; index < num_filas; index++)
            {
                if (existe_en_lista(numero_contrato.ToString(), num_contrato) == true)
                {
                    DataRow fila_resultado_cap = tabla_resultado.NewRow();
                    //fila_resultado_cap["FECINFORMACION"] = Fecha.ToString("d");
                    //fila_resultado_cap["NUM_PATRIMONIO"] = "007";
                    fila_resultado_cap["NUM_CREDITO"] = numero_contrato.ToString();
                    fila_resultado_cap["CONCEPTO"] = "CAP";
                    fila_resultado_cap["NUM_CUOTA"] = num_pago.ToString();
                    fila_resultado_cap["FEC_PROGRAMADA"] = ((DateTime)tabla.Rows[index]["fecha_proximo"]).ToString("d");
                    fila_resultado_cap["MONTO_PROGRAMADO"] = ((decimal)tabla.Rows[index]["amortizacion"]).ToString("F2").Replace(',', '.');
                    fila_resultado_cap["ESTADO"] = "E";
                    tabla_resultado.Rows.Add(fila_resultado_cap);
                    DataRow fila_resultado_int = tabla_resultado.NewRow();
                    //fila_resultado_int["FECINFORMACION"] = Fecha.ToString("d");
                    //fila_resultado_int["NUM_PATRIMONIO"] = "007";
                    fila_resultado_int["NUM_CREDITO"] = numero_contrato.ToString();
                    fila_resultado_int["CONCEPTO"] = "INT";
                    fila_resultado_int["NUM_CUOTA"] = num_pago.ToString();
                    fila_resultado_int["FEC_PROGRAMADA"] = ((DateTime)tabla.Rows[index]["fecha_proximo"]).ToString("d");
                    fila_resultado_int["MONTO_PROGRAMADO"] = ((decimal)tabla.Rows[index]["interes"]).ToString("F2").Replace(',', '.');
                    fila_resultado_int["ESTADO"] = "E";
                    tabla_resultado.Rows.Add(fila_resultado_int);

                    num_pago += 1;
                    bool simular_pagos = false;
                    if (index + 1 == num_filas) simular_pagos = true;
                    else
                    {
                        if (index + 1 < num_filas)
                            if (int.Parse(tabla.Rows[index + 1]["numero"].ToString()) != numero_contrato)
                                simular_pagos = true;
                    }

                    if (simular_pagos == true)
                    {
                        ReportePlanPagosVigente_SimularPagos(
                            //ref tabla_general
                            ref tabla_resultado
                            , (DateTime)tabla.Rows[index]["fecha"]
                            , (DateTime)tabla.Rows[index]["fecha_proximo"]
                            , (int)tabla.Rows[index]["num_cuotas"]
                            , (decimal)tabla.Rows[index]["seguro"]
                            , (int)tabla.Rows[index]["seguro_meses"]
                            , (DateTime)tabla.Rows[index]["seguro_fecha"]
                            , (decimal)tabla.Rows[index]["mantenimiento_sus"]
                            , (int)tabla.Rows[index]["mantenimiento_meses"]
                            , (DateTime)tabla.Rows[index]["mantenimiento_fecha"]
                            , (decimal)tabla.Rows[index]["interes"]
                            , (int)tabla.Rows[index]["interes_dias"]
                            , (int)tabla.Rows[index]["interes_dias_total"]
                            , (DateTime)tabla.Rows[index]["interes_fecha"]
                            , (decimal)tabla.Rows[index]["monto_pago"]
                            , (decimal)tabla.Rows[index]["amortizacion"]
                            , (decimal)tabla.Rows[index]["saldo"]

                            , (decimal)tabla.Rows[index]["pp_cuota_base"]
                            , (DateTime)tabla.Rows[index]["pp_fecha_inicio_plan"]
                            , (decimal)tabla.Rows[index]["pp_seguro"]
                            , (decimal)tabla.Rows[index]["pp_mantenimiento_sus"]
                            , (decimal)tabla.Rows[index]["pp_interes_corriente"]

                            , numero_contrato

                            , num_pago
                        );
                        if (index + 1 < num_filas) numero_contrato = int.Parse(tabla.Rows[index + 1]["numero"].ToString());
                        num_pago = 0;
                    }
                }
            }
            foreach (DataRow fila in tabla_resultado.Rows)
            {
                fila["FECINFORMACION"] = Fecha.ToString("d");
                fila["NUM_PATRIMONIO"] = "007";
            }
            return tabla_resultado;
        }
        protected static DataTable obtener_tabla_registro_pago(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //FECINFORMACION,NUM_PATRIMONIO,NUM_CREDITO,CONCEPTO,
            //NUM_CUOTA,FEC_PAGO,MONTO_PAGADO,FEC_LIQUIDACION
            DataTable tabla_resultado = new DataTable();
            tabla_resultado.Columns.Add("FECINFORMACION", typeof(string));
            tabla_resultado.Columns.Add("NUM_PATRIMONIO", typeof(string));
            tabla_resultado.Columns.Add("NUM_CREDITO", typeof(string));
            tabla_resultado.Columns.Add("CONCEPTO", typeof(string));
            tabla_resultado.Columns.Add("NUM_CUOTA", typeof(string));
            tabla_resultado.Columns.Add("FEC_PAGO", typeof(string));
            tabla_resultado.Columns.Add("MONTO_PAGADO", typeof(string));
            tabla_resultado.Columns.Add("FEC_LIQUIDACION", typeof(string));

            DbCommand cmd = db1.GetStoredProcCommand("nafibo_PlanesVigentes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, num_contrato);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            int numero_contrato = int.Parse(tabla.Rows[0]["numero"].ToString());
            int num_filas = tabla.Rows.Count;
            int num_pago = 0;
            for (int index = 0; index < num_filas; index++)
            {
                if (existe_en_lista(numero_contrato.ToString(), num_contrato) == true)
                {
                    DataRow fila_resultado_cap = tabla_resultado.NewRow();
                    fila_resultado_cap["FECINFORMACION"] = Fecha.ToString("d");
                    fila_resultado_cap["NUM_PATRIMONIO"] = "007";
                    fila_resultado_cap["NUM_CREDITO"] = numero_contrato.ToString();
                    fila_resultado_cap["CONCEPTO"] = "CAP";
                    fila_resultado_cap["NUM_CUOTA"] = num_pago.ToString();
                    fila_resultado_cap["FEC_PAGO"] = ((DateTime)tabla.Rows[index]["fecha"]).ToString("d");
                    fila_resultado_cap["MONTO_PAGADO"] = ((decimal)tabla.Rows[index]["amortizacion"]).ToString("F2").Replace(',', '.');
                    fila_resultado_cap["FEC_LIQUIDACION"] = ((DateTime)tabla.Rows[index]["fecha"]).ToString("d");
                    tabla_resultado.Rows.Add(fila_resultado_cap);
                    DataRow fila_resultado_int = tabla_resultado.NewRow();
                    fila_resultado_int["FECINFORMACION"] = Fecha.ToString("d");
                    fila_resultado_int["NUM_PATRIMONIO"] = "007";
                    fila_resultado_int["NUM_CREDITO"] = numero_contrato.ToString();
                    fila_resultado_int["CONCEPTO"] = "INT";
                    fila_resultado_int["NUM_CUOTA"] = num_pago.ToString();
                    fila_resultado_int["FEC_PAGO"] = ((DateTime)tabla.Rows[index]["fecha"]).ToString("d");
                    fila_resultado_int["MONTO_PAGADO"] = ((decimal)tabla.Rows[index]["interes"]).ToString("F2").Replace(',', '.');
                    fila_resultado_int["FEC_LIQUIDACION"] = ((DateTime)tabla.Rows[index]["fecha"]).ToString("d");
                    tabla_resultado.Rows.Add(fila_resultado_int);

                    num_pago += 1;

                    if (index + 1 < num_filas)
                    {
                        if (int.Parse(tabla.Rows[index + 1]["numero"].ToString()) != numero_contrato)
                        {
                            numero_contrato = int.Parse(tabla.Rows[index + 1]["numero"].ToString());
                            num_pago = 0;
                        }
                    }
                }
            }
            //foreach (DataRow fila in tabla_resultado.Rows)
            //{
            //    fila["FECINFORMACION"] = Fecha.ToString("d");
            //    fila["NUM_PATRIMONIO"] = "007";
            //}
            return tabla_resultado;
        }
        #endregion


        #region Tablas de Evaluación Preliminar
        protected static DataTable obtener_tabla_preliminar_cliente(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //NUM_CREDITO,TIPODOC,NUMDOCIDENTIDAD,NUM_CAEDEC,CAMPO_EXTRA1,CAMPO_EXTRA2,CAMPO_EXTRA3
            DataTable tabla0 = obtener_tabla_cliente(num_contrato, Fecha, Id_moneda);
            tabla0.Columns.Remove("FECINFORMACION");
            tabla0.Columns.Remove("NUM_PATRIMONIO");

            tabla0.Columns.Remove("APELLIDO_PATERNO");
            tabla0.Columns.Remove("APELLIDO_MATERNO");
            tabla0.Columns.Remove("NOMBRES");
            tabla0.Columns.Remove("APELLIDO_CASADA");
            tabla0.Columns.Remove("PATRIMONIO_DECLARADO");
            tabla0.Columns.Remove("PORCENTAJE_PARTICIPACION");
            tabla0.Columns.Remove("MONTO_PROMEDIO_INGRESO");
            tabla0.Columns.Remove("MONEDA_INGRESOS");
            tabla0.Columns.Remove("GENERO");
            tabla0.Columns.Remove("ESTADO_CIVIL");

            tabla0.Columns["FEC_NACIMIENTO"].ColumnName = "CAMPO_EXTRA1";
            tabla0.Columns["TIPO_TRABAJO"].ColumnName = "CAMPO_EXTRA2";
            tabla0.Columns["CAMPO_EXTRA"].ColumnName = "CAMPO_EXTRA3";
            return tabla0;
        }
        protected static DataTable obtener_tabla_preliminar_credito(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //NUM_CREDITO,CALIFICACION,TIPO_CREDITO,PLAZO,
            //GRACIA,TIPO_TASA,TASAINTERES,OTRO_CAMPO,FECINICIO,FECVENCIMIENTO,MONTO_SALDO,DEPARTAMENTO,
            //MONTO_OTORGADO,NUM_CAEDEC,POLITICA_PAGO_CAPITAL,POLITICA_PAGO_INTERES,
            //POLITICA_PREPAGO

            DataTable tabla0 = obtener_tabla_credito(num_contrato, Fecha, Id_moneda);
            tabla0.Columns.Remove("FECINFORMACION");
            tabla0.Columns.Remove("NUM_PATRIMONIO");
            foreach (DataRow fila in tabla0.Rows) fila["CALIFICACION"] = "A";
            tabla0.Columns.Remove("MONEDA_CREDITO");
            foreach (DataRow fila in tabla0.Rows) fila["POLITICA_PAGO_CAPITAL"] = "F";
            foreach (DataRow fila in tabla0.Rows) fila["POLITICA_PAGO_INTERES"] = "F";
            foreach (DataRow fila in tabla0.Rows) fila["POLITICA_PREPAGO"] = "F";
            tabla0.Columns.Remove("SUCURSAL_AGENCIA");
            tabla0.Columns.Remove("TIPO");
            tabla0.Columns.Remove("FECHA_CESION");
            tabla0.Columns.Remove("MONTO_CUOTA");
            tabla0.Columns.Remove("pagado");
            tabla0.Columns.Add("OTRO_CAMPO", typeof(string)).SetOrdinal(7);
            foreach (DataRow fila in tabla0.Rows) fila["OTRO_CAMPO"] = "0";
            return tabla0;
        }
        protected static DataTable obtener_tabla_preliminar_garantia(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //NUM_GARANTIA,NUM_CREDITO,TIPO_GARANTIA,
            //MTOCOMPROMETIDO,MTOVALORGARANTIA,MONEDA_GARANTIA,
            //NRO_PARTIDA_DDRR,FECHA_DDRR,DESCRIPCION_GARANTIA

            DataTable tabla0 = obtener_tabla_garantia(num_contrato, Fecha, Id_moneda);
            tabla0.Columns.Remove("FECINFORMACION");
            tabla0.Columns.Remove("NUM_PATRIMONIO");
            tabla0.Columns.Remove("SEC_DEPARTAMENTO");
            tabla0.Columns.Remove("ZONA");
            tabla0.Columns["MTOCOMPROMETIDO"].SetOrdinal(3);
            return tabla0;
        }
        protected static DataTable obtener_tabla_preliminar_plan_pago(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //NUM_CREDITO,CONCEPTO,NUM_CUOTA,FEC_PAGO,MONTO_PAGO
            DataTable tabla = new DataTable();
            tabla.Columns.Add("NUM_CREDITO", typeof(string));
            tabla.Columns.Add("CONCEPTO", typeof(string));
            tabla.Columns.Add("NUM_CUOTA", typeof(string));
            tabla.Columns.Add("FEC_PAGO", typeof(string));
            tabla.Columns.Add("MONTO_PAGO", typeof(string));

            //[id_contrato],[numero],[preferencial],[precio_final],[cuota_inicial],[num_cuotas],
            //[seguro],[mantenimiento_sus],[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan]
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_PlanesOriginales");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, num_contrato);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla_contratos = db1.ExecuteDataSet(cmd).Tables[0];

            foreach (DataRow fila_contrato in tabla_contratos.Rows)
            {
                string numero_contrato = fila_contrato["numero"].ToString();
                if (existe_en_lista(numero_contrato, num_contrato) == true)
                {
                    List<sim_pago> lista_pagos = simular.lista_plan_simulado((decimal)fila_contrato["precio_final"], (decimal)fila_contrato["cuota_inicial"], (int)fila_contrato["num_cuotas"], 0, (decimal)fila_contrato["interes_corriente"], (decimal)fila_contrato["seguro"], (decimal)fila_contrato["mantenimiento_sus"], (DateTime)fila_contrato["fecha_inicio_plan"]);
                    int num_pago = 0;
                    foreach (sim_pago pago_simulado in lista_pagos)
                    {
                        DataRow fila_cap = tabla.NewRow();
                        fila_cap["NUM_CREDITO"] = fila_contrato["numero"].ToString();
                        fila_cap["CONCEPTO"] = "CAP";
                        fila_cap["NUM_CUOTA"] = num_pago.ToString();
                        fila_cap["FEC_PAGO"] = pago_simulado.fecha_proximo.ToString("d");
                        fila_cap["MONTO_PAGO"] = pago_simulado.amortizacion.ToString("F2").Replace(',', '.');
                        tabla.Rows.Add(fila_cap);

                        DataRow fila_int = tabla.NewRow();
                        fila_int["NUM_CREDITO"] = fila_contrato["numero"].ToString();
                        fila_int["CONCEPTO"] = "INT";
                        fila_int["NUM_CUOTA"] = num_pago.ToString();
                        fila_int["FEC_PAGO"] = pago_simulado.fecha_proximo.ToString("d");
                        fila_int["MONTO_PAGO"] = pago_simulado.interes.ToString("F2").Replace(',', '.');
                        tabla.Rows.Add(fila_int);

                        num_pago += 1;
                    }
                }
            }
            return tabla;
        }
        protected static DataTable obtener_tabla_preliminar_registro_pago(string num_contrato, DateTime Fecha, int Id_moneda)
        {
            //NUM_CREDITO,CONCEPTO,NUM_CUOTA,FEC_PAGO,MONTO_PAGADO,FEC_LIQUIDACION
            DataTable tabla0 = obtener_tabla_registro_pago(num_contrato, Fecha, Id_moneda);
            tabla0.Columns.Remove("FECINFORMACION");
            tabla0.Columns.Remove("NUM_PATRIMONIO");
            return tabla0;
        }
        #endregion


        #region Funciones de apoyo para Tablas
        protected static DataTable Tabla_formato_nafibo(string Numero_contrato, DateTime Fecha, int Id_moneda)
        {
            Numero_contrato = ',' + Numero_contrato.Trim().Trim(',') + ',';

            DbCommand cmd = db1.GetStoredProcCommand("nafibo_FormatoNafibo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "numero_contrato", DbType.String, Numero_contrato);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            int Num_cuotas = 0; decimal Amortizacion = 0; decimal Seguro = 0; decimal Mantenimiento_sus = 0; decimal Interes_corriente = 0; decimal Monto_pago = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                contabilidadReporte.PagosRestantes((int)fila["id_contrato"], Fecha, ref Num_cuotas,
                    ref Amortizacion, ref Seguro, ref Mantenimiento_sus, ref Interes_corriente, ref Monto_pago,
                    (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                    (int)fila["id_ultimo_pago"]
                    , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                    , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                    , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);
                fila["restante_num_cuotas"] = Num_cuotas;
                //fila["restante_amortizacion"] = Amortizacion;
                fila["restante_seguro"] = Seguro;
                fila["restante_mantenimiento"] = Mantenimiento_sus;
                fila["restante_interes"] = Interes_corriente;
                fila["restante_total"] = Monto_pago;

                fila["total_num_cuotas"] = (int)fila["realizado_num_cuotas"] + Num_cuotas;
                //fila["total_precio"] = (decimal)fila["realizado_amortizacion"] + Amortizacion;
                fila["total_seguro"] = (decimal)fila["realizado_seguro"] + Seguro;
                fila["total_mantenimiento"] = (decimal)fila["realizado_mantenimiento"] + Mantenimiento_sus;
                fila["total_interes"] = (decimal)fila["realizado_interes"] + Interes_corriente;
                fila["total_total"] = (decimal)fila["realizado_total"] + Monto_pago;
            }
            /*[id_contrato],[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],
            [cuota_base],[fecha_inicio_plan],[id_ultimo_pago],[estado]
            [p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
            [realizado_num_cuotas],[realizado_amortizacion],[realizado_seguro],[realizado_mantenimiento],[realizado_interes],[realizado_total],
            [restante_num_cuotas],[restante_amortizacion],[restante_seguro],[restante_mantenimiento],[restante_interes],[restante_total],
            [total_num_cuotas],[total_precio],[total_seguro],[total_mantenimiento],[total_interes],[total_total]
            */
            DataTable tabla2 = new DataTable();
            tabla2.Columns.Add("num_row", typeof(int));
            tabla2.Columns.Add("num_contrato", typeof(string));
            tabla2.Columns.Add("num_cuotas_totales", typeof(int));
            tabla2.Columns.Add("num_cuotas_pagadas", typeof(int));
            tabla2.Columns.Add("num_cuotas_pendientes", typeof(int));
            tabla2.Columns.Add("fecha_vencimiento", typeof(string));
            tabla2.Columns.Add("total_pagado", typeof(decimal));
            tabla2.Columns.Add("monto_otorgado", typeof(decimal));
            tabla2.Columns.Add("estado", typeof(string));
            tabla2.Columns.Add("plazo", typeof(int));
            tabla2.Columns.Add("plazo_remanente", typeof(int));
            tabla2.Columns.Add("tasa_interes", typeof(decimal));
            tabla2.Columns.Add("monto_saldo", typeof(decimal));

            int num_row = 1;
            decimal num_dias_mes = Convert.ToDecimal((Convert.ToDouble(365) / Convert.ToDouble(12)));
            foreach (DataRow fila in tabla.Rows)
            {
                DataRow fila2 = tabla2.NewRow();
                fila2["num_row"] = num_row;
                fila2["num_contrato"] = fila["numero"].ToString();
                fila2["num_cuotas_totales"] = (int)fila["total_num_cuotas"];
                fila2["num_cuotas_pagadas"] = (int)fila["realizado_num_cuotas"];
                fila2["num_cuotas_pendientes"] = (int)fila["restante_num_cuotas"];
                decimal restante_num_cuotas = Convert.ToDecimal((int)fila["restante_num_cuotas"]);
                decimal aux_num_dias = restante_num_cuotas * num_dias_mes;
                //fila2["fecha_vencimiento"] = ((DateTime)fila["p_fecha"]).AddDays(Convert.ToDouble(aux_num_dias)).ToString("d");
                fila2["fecha_vencimiento"] = ((DateTime)fila["p_fecha_proximo"]).AddDays(Convert.ToDouble(aux_num_dias)).ToString("d");
                fila2["total_pagado"] = (decimal)fila["realizado_amortizacion"];
                fila2["monto_otorgado"] = (decimal)fila["precio_final"];
                fila2["estado"] = fila["estado"].ToString();
                fila2["plazo"] = (int)(((decimal)(int)fila["total_num_cuotas"]) * num_dias_mes);
                fila2["plazo_remanente"] = (int)(((decimal)(int)fila["restante_num_cuotas"]) * num_dias_mes);
                fila2["tasa_interes"] = (decimal)fila["interes_corriente"];
                fila2["monto_saldo"] = (decimal)fila["p_saldo"];
                tabla2.Rows.Add(fila2);
                num_row += 1;
            }
            return tabla2;
        }

        protected static bool existe_en_lista(string cadena, string lista)
        {
            bool existe = false;
            string[] lista_elementos = lista.Trim().Trim(',').Split(',');
            for (int j = 0; j < lista_elementos.Length; j++)
            {
                if (lista_elementos[j] == cadena) { existe = true; break; }
            }
            return existe;
        }

        //protected static void ReportePlanPagosVigente_SimularPagos(
        //ref DataTable tabla_resultado,
        //DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha,
        //decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes,
        //int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo,
        //decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, decimal pp_seguro, decimal pp_mantenimiento_sus, decimal pp_interes_corriente,
        //int numero_contrato
        //, int num_pago
        //)
        protected static void ReportePlanPagosVigente_SimularPagos(ref DataTable tabla_resultado, DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha, decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes, int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, decimal pp_seguro, decimal pp_mantenimiento_sus, decimal pp_interes_corriente, int numero_contrato, int num_pago)
        {
            sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
                , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
                , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

            if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
            while (pago_simulado.saldo > 0)
            {
                pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);

                DataRow fila_resultado_cap = tabla_resultado.NewRow();
                //fila_resultado_cap["FECINFORMACION"] = Fecha.ToString("d");
                //fila_resultado_cap["NUM_PATRIMONIO"] = "007";
                fila_resultado_cap["NUM_CREDITO"] = numero_contrato.ToString();
                fila_resultado_cap["CONCEPTO"] = "CAP";
                fila_resultado_cap["NUM_CUOTA"] = num_pago.ToString();
                fila_resultado_cap["FEC_PROGRAMADA"] = pago_simulado.fecha_proximo.ToString("d");
                fila_resultado_cap["MONTO_PROGRAMADO"] = pago_simulado.amortizacion.ToString("F2").Replace(',', '.');
                fila_resultado_cap["ESTADO"] = "P";
                tabla_resultado.Rows.Add(fila_resultado_cap);
                DataRow fila_resultado_int = tabla_resultado.NewRow();
                //fila_resultado_int["FECINFORMACION"] = Fecha.ToString("d");
                //fila_resultado_int["NUM_PATRIMONIO"] = "007";
                fila_resultado_int["NUM_CREDITO"] = numero_contrato.ToString();
                fila_resultado_int["CONCEPTO"] = "INT";
                fila_resultado_int["NUM_CUOTA"] = num_pago.ToString();
                fila_resultado_int["FEC_PROGRAMADA"] = pago_simulado.fecha_proximo.ToString("d");
                fila_resultado_int["MONTO_PROGRAMADO"] = pago_simulado.interes.ToString("F2").Replace(',', '.');
                fila_resultado_int["ESTADO"] = "P";
                tabla_resultado.Rows.Add(fila_resultado_int);

                num_pago += 1;
            }
        }
        #endregion

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}