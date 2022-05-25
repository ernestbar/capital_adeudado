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
/// Descripción breve de nafibo_ejecutado
/// </summary>
namespace terrasur
{
    public class nafibo_ejecutado
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public nafibo_ejecutado() { }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable ListaAnio()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigo", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));

            int anio_actual = DateTime.Now.Year;
            int mes_actual = DateTime.Now.Month;
            if (mes_actual == 12) anio_actual = anio_actual + 1;

            for (int anio = 2010; anio <= anio_actual; anio++)
            {
                DataRow fila = tabla.NewRow();
                fila["codigo"] = anio;
                fila["nombre"] = anio.ToString();
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static DataTable ListaMes(int codigo_anio)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigo", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));

            int anio_actual = DateTime.Now.Year;
            int mes_actual = DateTime.Now.Month;
            if (codigo_anio < anio_actual) mes_actual = 12;
            else if (codigo_anio > anio_actual) mes_actual = 1;

            if (mes_actual < 12) mes_actual = mes_actual + 1;

            for (int mes = 1; mes <= mes_actual; mes++)
            {
                DataRow fila = tabla.NewRow();
                fila["codigo"] = mes;
                switch (mes)
                {
                    case 1: fila["nombre"] = "Enero"; break;
                    case 2: fila["nombre"] = "Febrero"; break;
                    case 3: fila["nombre"] = "Marzo"; break;
                    case 4: fila["nombre"] = "Abril"; break;
                    case 5: fila["nombre"] = "Mayo"; break;
                    case 6: fila["nombre"] = "Junio"; break;
                    case 7: fila["nombre"] = "Julio"; break;
                    case 8: fila["nombre"] = "Agosto"; break;
                    case 9: fila["nombre"] = "Septiembre"; break;
                    case 10: fila["nombre"] = "Octubre"; break;
                    case 11: fila["nombre"] = "Noviembre"; break;
                    case 12: fila["nombre"] = "Diciembre"; break;
                }
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static string StringMes(int Mes)
        {
            string str = "";
            switch (Mes)
            {
                case 1: str = "Enero"; break;
                case 2: str = "Febrero"; break;
                case 3: str = "Marzo"; break;
                case 4: str = "Abril"; break;
                case 5: str = "Mayo"; break;
                case 6: str = "Junio"; break;
                case 7: str = "Julio"; break;
                case 8: str = "Agosto"; break;
                case 9: str = "Septiembre"; break;
                case 10: str = "Octubre"; break;
                case 11: str = "Noviembre"; break;
                case 12: str = "Diciembre"; break;
            }
            return str;
        }


        public static DataTable TablaEjecutado(DateTime Fecha_inicio, DateTime Fecha_fin, bool AjustarCuotas, bool CapitalInteres, bool Excel, int Id_moneda)
        {
            //[id_transaccion],[id_contrato],[fecha],[fecha_ejecutado],[institucion],[num_contrato],[num_cuota],[fecha_pago],[interes],[capital],[monto],[fuera_de_hora]
            DataTable tabla = DatosEjecutado(Fecha_inicio, Fecha_fin, Id_moneda);
            if (AjustarCuotas == true) AjusteEjecutado(ref tabla, Fecha_fin);
            DataTable tabla_res = FormatoEjecutado(tabla, CapitalInteres, Excel);
            return tabla_res;
        }
        protected static DataTable DatosEjecutado(DateTime Inicio, DateTime Fin, int Id_moneda)
        {
            //[id_transaccion],[id_contrato],[fecha],[fecha_ejecutado],[institucion],[num_contrato],[num_cuota],[fecha_pago],[interes],[capital],[monto],[fuera_de_hora]
            DbCommand cmd = db1.GetStoredProcCommand("nafibo_ejecutado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
            db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        protected static void AjusteEjecutado(ref DataTable tabla_ejecutado, DateTime Fecha)
        {
            //Se obtiene la tabla de ejecutados esencial ([id_contrato],[num_cuota_menor])
            DataTable tabla_ejecutado_esencial = new DataTable();
            tabla_ejecutado_esencial.Columns.Add("id_contrato", typeof(int));
            tabla_ejecutado_esencial.Columns.Add("num_cuota_menor", typeof(int));
            foreach (DataRow fila in tabla_ejecutado.Rows)
            {
                int id_contrato = (int)fila["id_contrato"];
                int num_cuota = (int)fila["num_cuota"];
                int index_esencial = -1;
                for (int j = 0; j < tabla_ejecutado_esencial.Rows.Count; j++)
                {
                    if (((int)tabla_ejecutado_esencial.Rows[j]["id_contrato"]) == id_contrato)
                    {
                        index_esencial = j;
                        break;
                    }
                }
                if (index_esencial >= 0)
                {
                    if (num_cuota < ((int)tabla_ejecutado_esencial.Rows[index_esencial]["num_cuota_menor"]))
                        tabla_ejecutado_esencial.Rows[index_esencial]["num_cuota_menor"] = num_cuota;
                }
                else
                {
                    DataRow fila_ejecutado_esencial = tabla_ejecutado_esencial.NewRow();
                    fila_ejecutado_esencial["id_contrato"] = id_contrato;
                    fila_ejecutado_esencial["num_cuota_menor"] = num_cuota;
                    tabla_ejecutado_esencial.Rows.Add(fila_ejecutado_esencial);
                }
            }

            //Se obtine la tabla de ajuste almacenada
            //[id_contrato],[num_cuota]
            DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_Fecha");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            DataTable tabla_ajuste_almacenada = db1.ExecuteDataSet(cmd).Tables[0];

            //Se obtiene la tabla de ajuste a aplicarse
            DataTable tabla_ajuste = new DataTable();
            tabla_ajuste.Columns.Add("id_contrato", typeof(int));
            tabla_ajuste.Columns.Add("diferencia", typeof(int));
            foreach (DataRow fila_almacenada in tabla_ajuste_almacenada.Rows)
            {
                int id_contrato = (int)fila_almacenada["id_contrato"];
                int num_cuota = (int)fila_almacenada["num_cuota"];

                int diferencia = 0;
                foreach (DataRow fila_esencial in tabla_ejecutado_esencial.Rows)
                {
                    if (((int)fila_esencial["id_contrato"]) == id_contrato)
                    {
                        diferencia = (num_cuota + 1) - ((int)fila_esencial["num_cuota_menor"]);
                        break;
                    }
                }
                if (diferencia != 0)
                {
                    DataRow fila_ajuste = tabla_ajuste.NewRow();
                    fila_ajuste["id_contrato"] = id_contrato;
                    fila_ajuste["diferencia"] = diferencia;
                    tabla_ajuste.Rows.Add(fila_ajuste);
                }
            }

            //Se realizan los ajustes en la tabla de ejecutados
            foreach (DataRow fila_ajuste in tabla_ajuste.Rows)
            {
                int id_contrato = (int)fila_ajuste["id_contrato"];
                int diferencia = (int)fila_ajuste["diferencia"];
                foreach (DataRow fila in tabla_ejecutado.Rows)
                    if (((int)fila["id_contrato"]) == id_contrato)
                        fila["num_cuota"] = ((int)fila["num_cuota"]) + diferencia;
            }
        }
        protected static DataTable FormatoEjecutado(DataTable tabla_ejecutado, bool CapitalInteres, bool Excel)
        {
            if (CapitalInteres == false)
            {
                if (Excel == true)
                {
                    DataTable tabla = tabla_ejecutado;
                    tabla.Columns.Remove("id_transaccion");
                    tabla.Columns.Remove("id_contrato");
                    tabla.Columns.Remove("fecha");
                    tabla.Columns["fuera_de_hora"].ColumnName = "observacion";
                    return tabla;
                }
                else
                {
                    DataTable tabla = new DataTable();
                    tabla.Columns.Add("fecha_ejecutado", typeof(string));
                    tabla.Columns.Add("institucion", typeof(string));
                    tabla.Columns.Add("num_contrato", typeof(string));
                    tabla.Columns.Add("num_cuota", typeof(string));
                    tabla.Columns.Add("fecha_pago", typeof(string));
                    tabla.Columns.Add("interes", typeof(string));
                    tabla.Columns.Add("capital", typeof(string));
                    tabla.Columns.Add("monto", typeof(string));
                    tabla.Columns.Add("observacion", typeof(string));
                    foreach (DataRow fila in tabla_ejecutado.Rows)
                    {
                        DataRow nueva_fila = tabla.NewRow();
                        nueva_fila["fecha_ejecutado"] = fila["fecha_ejecutado"];
                        nueva_fila["institucion"] = fila["institucion"];
                        nueva_fila["num_contrato"] = fila["num_contrato"];
                        nueva_fila["num_cuota"] = fila["num_cuota"].ToString();
                        nueva_fila["fecha_pago"] = fila["fecha_pago"];
                        nueva_fila["interes"] = ((decimal)fila["interes"]).ToString("F2").Replace(",", ".");
                        nueva_fila["capital"] = ((decimal)fila["capital"]).ToString("F2").Replace(",", ".");
                        nueva_fila["monto"] = ((decimal)fila["monto"]).ToString("F2").Replace(",", ".");
                        nueva_fila["observacion"] = fila["fuera_de_hora"];
                        tabla.Rows.Add(nueva_fila);
                    }
                    return tabla;
                }
            }
            else
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("fecha_ejecutado", typeof(string));
                tabla.Columns.Add("institucion", typeof(string));
                tabla.Columns.Add("num_contrato", typeof(string));
                tabla.Columns.Add("concepto", typeof(string));
                tabla.Columns.Add("num_cuota", typeof(string));
                tabla.Columns.Add("fecha_pago", typeof(string));
                if (Excel == true) tabla.Columns.Add("monto", typeof(decimal));
                else tabla.Columns.Add("monto", typeof(string));
                tabla.Columns.Add("fecha_pago2", typeof(string));
                tabla.Columns.Add("observacion", typeof(string));
                //[id_transaccion],[id_contrato],[fecha],[fecha_ejecutado],[institucion],[num_contrato],[num_cuota],[fecha_pago],[interes],[capital],[monto],[fuera_de_hora]
                foreach (DataRow fila in tabla_ejecutado.Rows)
                {
                    DataRow nueva_fila_cap = tabla.NewRow();
                    nueva_fila_cap["fecha_ejecutado"] = fila["fecha_ejecutado"];
                    nueva_fila_cap["institucion"] = fila["institucion"];
                    nueva_fila_cap["num_contrato"] = fila["num_contrato"];
                    nueva_fila_cap["concepto"] = "CAP";
                    nueva_fila_cap["num_cuota"] = fila["num_cuota"].ToString();
                    nueva_fila_cap["fecha_pago"] = fila["fecha_pago"];
                    if (Excel == true) nueva_fila_cap["monto"] = fila["capital"];
                    else nueva_fila_cap["monto"] = ((decimal)fila["capital"]).ToString("F2").Replace(",", ".");
                    nueva_fila_cap["fecha_pago2"] = fila["fecha_pago"];
                    nueva_fila_cap["observacion"] = fila["fuera_de_hora"];
                    tabla.Rows.Add(nueva_fila_cap);

                    DataRow nueva_fila_int = tabla.NewRow();
                    nueva_fila_int["fecha_ejecutado"] = fila["fecha_ejecutado"];
                    nueva_fila_int["institucion"] = fila["institucion"];
                    nueva_fila_int["num_contrato"] = fila["num_contrato"];
                    nueva_fila_int["concepto"] = "INT";
                    nueva_fila_int["num_cuota"] = fila["num_cuota"].ToString();
                    nueva_fila_int["fecha_pago"] = fila["fecha_pago"];
                    if (Excel == true) nueva_fila_int["monto"] = fila["interes"];
                    else nueva_fila_int["monto"] = ((decimal)fila["interes"]).ToString("F2").Replace(",", ".");
                    nueva_fila_int["fecha_pago2"] = fila["fecha_pago"];
                    nueva_fila_int["observacion"] = fila["fuera_de_hora"];
                    tabla.Rows.Add(nueva_fila_int);
                }
                if (Excel == false) { tabla.Columns.Remove("observacion"); }
                else { tabla.Columns.Remove("fecha_pago2"); }
                return tabla;
            }
        }


        public static bool GuardarAjustesNumCuotas(DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            //[id_contrato],[num_cuota]
            DataTable tabla_ajustes = TablaAjustesNumCuotas(Fecha_inicio, Fecha_fin);
            bool correcto = true;
            foreach (DataRow fila_ajuste in tabla_ajustes.Rows)
            {
                int id_contrato = (int)fila_ajuste["id_contrato"];
                int num_cuota = (int)fila_ajuste["num_cuota"];
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_Guardar");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha_fin.Date);
                    db1.AddInParameter(cmd, "num_cuota", DbType.Int32, num_cuota);
                    db1.ExecuteNonQuery(cmd);
                }
                catch { correcto = false; break; }
            }
            return correcto;
        }
        protected static DataTable TablaAjustesNumCuotas(DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            DataTable tabla_original = DatosEjecutado(Fecha_inicio, Fecha_fin, 0);
            DataTable tabla_ajustada = new DataTable(); tabla_ajustada.Columns.Add("id_contrato", typeof(int)); tabla_ajustada.Columns.Add("num_cuota", typeof(int));
            foreach (DataRow fila in tabla_original.Rows)
            {
                DataRow fila_ajustada = tabla_ajustada.NewRow(); fila_ajustada["id_contrato"] = ((int)fila["id_contrato"]); fila_ajustada["num_cuota"] = ((int)fila["num_cuota"]);
                tabla_ajustada.Rows.Add(fila_ajustada);
            }
            AjusteEjecutado(ref tabla_ajustada, Fecha_fin);

            //Se obtiene la tabla de original esencial
            DataTable tabla_original_esencial = new DataTable();
            tabla_original_esencial.Columns.Add("id_contrato", typeof(int));
            tabla_original_esencial.Columns.Add("num_cuota_mayor", typeof(int));
            foreach (DataRow fila in tabla_original.Rows)
            {
                int id_contrato = (int)fila["id_contrato"];
                int num_cuota = (int)fila["num_cuota"];
                int index_esencial = -1;
                for (int j = 0; j < tabla_original_esencial.Rows.Count; j++)
                {
                    if (((int)tabla_original_esencial.Rows[j]["id_contrato"]) == id_contrato)
                    {
                        index_esencial = j;
                        break;
                    }
                }
                if (index_esencial >= 0)
                {
                    if (num_cuota > ((int)tabla_original_esencial.Rows[index_esencial]["num_cuota_mayor"]))
                        tabla_original_esencial.Rows[index_esencial]["num_cuota_mayor"] = num_cuota;
                }
                else
                {
                    DataRow fila_original_esencial = tabla_original_esencial.NewRow();
                    fila_original_esencial["id_contrato"] = id_contrato;
                    fila_original_esencial["num_cuota_mayor"] = num_cuota;
                    tabla_original_esencial.Rows.Add(fila_original_esencial);
                }
            }

            //Se obtiene la tabla de ajustada esencial
            DataTable tabla_ajustada_esencial = new DataTable();
            tabla_ajustada_esencial.Columns.Add("id_contrato", typeof(int));
            tabla_ajustada_esencial.Columns.Add("num_cuota_mayor", typeof(int));
            foreach (DataRow fila in tabla_ajustada.Rows)
            {
                int id_contrato = (int)fila["id_contrato"];
                int num_cuota = (int)fila["num_cuota"];
                int index_esencial = -1;
                for (int j = 0; j < tabla_ajustada_esencial.Rows.Count; j++)
                {
                    if (((int)tabla_ajustada_esencial.Rows[j]["id_contrato"]) == id_contrato)
                    {
                        index_esencial = j;
                        break;
                    }
                }
                if (index_esencial >= 0)
                {
                    if (num_cuota > ((int)tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"]))
                        tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"] = num_cuota;
                }
                else
                {
                    DataRow fila_ajustada_esencial = tabla_ajustada_esencial.NewRow();
                    fila_ajustada_esencial["id_contrato"] = id_contrato;
                    fila_ajustada_esencial["num_cuota_mayor"] = num_cuota;
                    tabla_ajustada_esencial.Rows.Add(fila_ajustada_esencial);
                }
            }

            //Se construye la tabla de ajustes
            DataTable tabla_ajustes = new DataTable();
            tabla_ajustes.Columns.Add("id_contrato", typeof(int));
            tabla_ajustes.Columns.Add("num_cuota", typeof(int));

            foreach (DataRow fila in tabla_original_esencial.Rows)
            {
                int id_contrato = (int)fila["id_contrato"];
                int num_cuota_mayor = (int)fila["num_cuota_mayor"];
                int index_esencial = -1;
                for (int j = 0; j < tabla_ajustada_esencial.Rows.Count; j++)
                {
                    if (((int)tabla_ajustada_esencial.Rows[j]["id_contrato"]) == id_contrato)
                    {
                        index_esencial = j;
                        break;
                    }
                }
                if (num_cuota_mayor != ((int)tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"]))
                {
                    DataRow fila_ajustes = tabla_ajustes.NewRow();
                    fila_ajustes["id_contrato"] = id_contrato;
                    fila_ajustes["num_cuota"] = ((int)tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"]);
                    tabla_ajustes.Rows.Add(fila_ajustes);
                }
            }

            //Se localizan los Nº de cuota ajustados en el presente periodo
            //[id_contrato],[num_cuota]
            Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
            DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_TablaCuotasSistema");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha_fin.Date);
            DataTable tabla_num_cuotas = db1.ExecuteDataSet(cmd).Tables[0];

            foreach (DataRow fila_ajustada_esencial in tabla_ajustada_esencial.Rows)
            {
                int id_contrato = (int)fila_ajustada_esencial["id_contrato"];
                int num_cuota_mayor = (int)fila_ajustada_esencial["num_cuota_mayor"];
                foreach (DataRow fila_num_cuotas in tabla_num_cuotas.Rows)
                {
                    if (((int)fila_num_cuotas["id_contrato"]) == id_contrato)
                    {
                        if (((int)fila_num_cuotas["num_cuota"]) != num_cuota_mayor || ((int)fila_num_cuotas["num_ajustes"]) > 0)
                        {
                            DataRow fila_ajustes = tabla_ajustes.NewRow();
                            fila_ajustes["id_contrato"] = id_contrato;
                            fila_ajustes["num_cuota"] = num_cuota_mayor;
                            tabla_ajustes.Rows.Add(fila_ajustes);
                        }
                        break;
                    }
                }
            }


            return tabla_ajustes;
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}