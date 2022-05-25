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
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Descripción breve de infoGerencialTerrasur
/// </summary>
namespace terrasur
{
    public class infoGerencialTerrasur
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        #endregion

        #region Constructores
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_persona],[activo],[nombre],[email],[repIngresos],[repVentas],[repReversiones],[repMora]
            DataTable tablaInicial = ListaBase();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_persona", typeof(int));
            tabla.Columns.Add("activo", typeof(bool));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("email", typeof(string));
            tabla.Columns.Add("repIngresos", typeof(bool));
            tabla.Columns.Add("repVentas", typeof(bool));
            tabla.Columns.Add("repReversiones", typeof(bool));
            tabla.Columns.Add("repMora", typeof(bool));
            tabla.Columns.Add("repCxc", typeof(bool));
            foreach (DataRow filaInicial in tablaInicial.Rows)
            {
                if (filaInicial["activo"].ToString() == "true")
                {
                    DataRow fila = tabla.NewRow();
                    fila["id_persona"] = int.Parse(filaInicial["id_persona"].ToString());
                    fila["activo"] = bool.Parse(filaInicial["activo"].ToString());
                    fila["nombre"] = filaInicial["nombre"].ToString();
                    fila["email"] = filaInicial["email"].ToString();
                    fila["repIngresos"] = bool.Parse(filaInicial["repIngresos"].ToString());
                    fila["repVentas"] = bool.Parse(filaInicial["repVentas"].ToString());
                    fila["repReversiones"] = bool.Parse(filaInicial["repReversiones"].ToString());
                    fila["repMora"] = bool.Parse(filaInicial["repMora"].ToString());
                    fila["repCxc"] = bool.Parse(filaInicial["repCxc"].ToString());
                    tabla.Rows.Add(fila);
                }
            }
            return tabla;
        }
        private static DataTable ListaBase()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/infoGerencialTerrasur.xml"));
            return ds.Tables[0];
        }

        public static void FechasInfoSemanal(DateTime Fecha, ref DateTime Fecha_inicio_semana, ref DateTime Fecha_inicio_anio)
        {
            int num_dia_semana = 0; switch (Fecha.DayOfWeek) { case DayOfWeek.Monday: num_dia_semana = 1; break; case DayOfWeek.Tuesday: num_dia_semana = 2; break; case DayOfWeek.Wednesday: num_dia_semana = 3; break; case DayOfWeek.Thursday: num_dia_semana = 4; break; case DayOfWeek.Friday: num_dia_semana = 5; break; case DayOfWeek.Saturday: num_dia_semana = 6; break; case DayOfWeek.Sunday: num_dia_semana = 7; break; }
            Fecha_inicio_anio = DateTime.Parse("01/01/" + Fecha.Year.ToString());
            Fecha_inicio_semana = Fecha.AddDays(num_dia_semana * (-1)).AddDays(-6);
        }

        public static string VerInfo(DateTime Fecha_inicio, DateTime Fecha_inicio_cxc, DateTime Fecha_fin, List<tmpInfoGerencialTerrasur> lista)
        {
            string rep_ingresos = ""; string rep_ventas = ""; string rep_reversiones = ""; string rep_mora = ""; string rep_cxc = "";
            tmpInfoGerencialTerrasur item = lista[0];
            if (item.repIngresos == true) { rep_ingresos = Datos("ingresos", Fecha_inicio, Fecha_fin); }
            if (item.repVentas == true) { rep_ventas = Datos("ventas", Fecha_inicio, Fecha_fin); }
            if (item.repReversiones == true) { rep_reversiones = Datos("reversiones", Fecha_inicio, Fecha_fin); }
            if (item.repMora == true) { rep_mora = Datos("mora", Fecha_inicio, Fecha_fin); }
            if (item.repCxc == true) { rep_cxc = Datos("cxc", Fecha_inicio, Fecha_fin); }

            return CuerpoMensaje(Fecha_fin, item , rep_ingresos, rep_ventas, rep_reversiones, rep_mora, rep_cxc);

            /*
            string rep_ingresos_sus = ""; string rep_ventas_sus = ""; string rep_reversiones_sus = ""; string rep_mora_sus = ""; string rep_cxc_sus = "";
            string rep_ingresos_bs = ""; string rep_ventas_bs = ""; string rep_reversiones_bs = ""; string rep_mora_bs = ""; string rep_cxc_bs = "";
            tmpInfoGerencialTerrasur item = lista[0];
            if (item.repIngresos == true) { rep_ingresos_sus = "1"; rep_ingresos_bs = "1"; }
            if (item.repVentas == true) { rep_ventas_sus = "1"; rep_ventas_bs = "1"; }
            if (item.repReversiones == true) { rep_reversiones_sus = "1"; rep_reversiones_bs = "1"; }
            if (item.repMora == true) { rep_mora_sus = "1"; rep_mora_bs = "1"; }
            if (item.repCxc == true) { rep_cxc_sus = "1"; rep_cxc_bs = "1"; }

            moneda m_sus = new moneda("$us");
            if (rep_ingresos_sus != "") rep_ingresos_sus = Datos("ingresos", Fecha_inicio, Fecha_fin, m_sus.id_moneda, m_sus.codigo);
            if (rep_ventas_sus != "") rep_ventas_sus = Datos("ventas", Fecha_inicio, Fecha_fin, m_sus.id_moneda, m_sus.codigo);
            if (rep_reversiones_sus != "") rep_reversiones_sus = Datos("reversiones", Fecha_inicio, Fecha_fin, m_sus.id_moneda, m_sus.codigo);
            if (rep_mora_sus != "") rep_mora_sus = Datos("mora", Fecha_inicio, Fecha_fin, m_sus.id_moneda, m_sus.codigo);
            if (rep_cxc_sus != "") rep_cxc_sus = Datos("cxc", Fecha_inicio_cxc, Fecha_fin, m_sus.id_moneda, m_sus.codigo);

            moneda m_bs = new moneda("Bs");
            if (rep_ingresos_bs != "") rep_ingresos_bs = Datos("ingresos", Fecha_inicio, Fecha_fin, m_bs.id_moneda, m_bs.codigo);
            if (rep_ventas_bs != "") rep_ventas_bs = Datos("ventas", Fecha_inicio, Fecha_fin, m_bs.id_moneda, m_bs.codigo);
            if (rep_reversiones_bs != "") rep_reversiones_bs = Datos("reversiones", Fecha_inicio, Fecha_fin, m_bs.id_moneda, m_bs.codigo);
            if (rep_mora_bs != "") rep_mora_bs = Datos("mora", Fecha_inicio, Fecha_fin, m_bs.id_moneda, m_bs.codigo);
            if (rep_cxc_bs != "") rep_cxc_bs = Datos("cxc", Fecha_inicio_cxc, Fecha_fin, m_bs.id_moneda, m_bs.codigo);

            return CuerpoMensaje(Fecha_fin, item
                , rep_ingresos_sus, rep_ventas_sus, rep_reversiones_sus, rep_mora_sus, rep_cxc_sus
                , rep_ingresos_bs, rep_ventas_bs, rep_reversiones_bs, rep_mora_bs, rep_cxc_bs);
            */
        }

        public static string EnviarInfo(DateTime Fecha_inicio, DateTime Fecha_inicio_cxc, DateTime Fecha_fin, List<tmpInfoGerencialTerrasur> lista)
        {
            string rep_ingresos = ""; string rep_ventas = ""; string rep_reversiones = ""; string rep_mora = ""; string rep_cxc = "";
            foreach (tmpInfoGerencialTerrasur item in lista)
            {
                if (item.repIngresos == true) rep_ingresos = "1";
                if (item.repVentas == true) rep_ventas = "1";
                if (item.repReversiones == true) rep_reversiones = "1";
                if (item.repMora == true) rep_mora = "1";
                if (item.repCxc == true) rep_cxc = "1";
            }
            if (rep_ingresos != "") rep_ingresos = Datos("ingresos", Fecha_inicio, Fecha_fin);
            if (rep_ventas != "") rep_ventas = Datos("ventas", Fecha_inicio, Fecha_fin);
            if (rep_reversiones != "") rep_reversiones = Datos("reversiones", Fecha_inicio, Fecha_fin);
            if (rep_mora != "") rep_mora = Datos("mora", Fecha_inicio, Fecha_fin);
            if (rep_cxc != "") rep_cxc = Datos("cxc", Fecha_inicio_cxc, Fecha_fin);

            StringBuilder str = new StringBuilder();
            foreach (tmpInfoGerencialTerrasur item in lista)
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sistemas@terrasur.com.bo", "Información Gerencial de Terrasur");
                correo.To.Add(item.email);
                correo.Subject = "Información Gerencial de Terrasur al " + Fecha_fin.ToString("d");
                correo.Body = CuerpoMensaje(Fecha_fin, item, rep_ingresos, rep_ventas, rep_reversiones, rep_mora, rep_cxc);
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient("mail.terrasur.com.bo");
                smtp.Credentials = new NetworkCredential("sistemas", "TerraNet");
                try
                {
                    smtp.Send(correo); 
                    str.Append("El mail a " + item.email + " se envió correctamente|");
                }
                catch { str.Append("El mail a " + item.email + " NO se envió correctamente|"); }
            }
            return str.ToString().TrimEnd('|');
        }

        private static string CuerpoMensaje(DateTime Fecha_fin, tmpInfoGerencialTerrasur infoObj
            , string rep_ingresos, string rep_ventas, string rep_reversiones, string rep_mora, string rep_cxc)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("<table align='center'>");

            str.AppendLine("<tr><td style='font-weight:bold; text-align:center; font-size:17px; font-family:Arial;'>Información Gerencial de la Cartera de Terrasur al " + Fecha_fin.ToString("d") + " (expresada en dólares)</td></tr>");
            str.AppendLine("<tr><td style='font-weight:bold; text-align:center; font-size:14px; font-family:Arial;'>(de los negocios: BBR, Terrasur y CEA)</td></tr>");
            str.AppendLine("<tr><td><hr /></td></tr>");
            if (infoObj.repCxc == true) str.AppendLine("<tr><td>" + rep_cxc + "<hr /></td></tr>");
            if (infoObj.repIngresos == true) str.AppendLine("<tr><td>" + rep_ingresos + "<hr /></td></tr>");
            if (infoObj.repVentas == true) str.AppendLine("<tr><td>" + rep_ventas + "<hr /></td></tr>");
            if (infoObj.repReversiones == true) str.AppendLine("<tr><td>" + rep_reversiones + "<hr /></td></tr>");
            if (infoObj.repMora == true) str.AppendLine("<tr><td>" + rep_mora + "<hr /></td></tr>");

            str.AppendLine("</table>");
            return str.ToString();
        }

        private static string Datos(string Tipo_datos, DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            moneda mObj_sus = new moneda("$us");
            DbCommand cmd_sus = db1.GetStoredProcCommand("infoGerencialTerrasur");
            cmd_sus.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd_sus, "dato", DbType.String, Tipo_datos);
            db1.AddInParameter(cmd_sus, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd_sus, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd_sus, "id_moneda", DbType.Int32, mObj_sus.id_moneda);
            DataTable tabla_sus = db1.ExecuteDataSet(cmd_sus).Tables[0];

            moneda mObj_bs = new moneda("Bs");
            DbCommand cmd_bs = db1.GetStoredProcCommand("infoGerencialTerrasur");
            cmd_bs.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd_bs, "dato", DbType.String, Tipo_datos);
            db1.AddInParameter(cmd_bs, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd_bs, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd_bs, "id_moneda", DbType.Int32, mObj_bs.id_moneda);
            DataTable tabla_bs = db1.ExecuteDataSet(cmd_bs).Tables[0];

            decimal tc = (new tipo_cambio(tipo_cambio.Anterior(Fecha_fin))).compra;
            string Codigo_moneda = "$us";
            StringBuilder str = new StringBuilder();
            str.AppendLine("<div style='font-family:Arial; font-size:13px'>");

            switch (Tipo_datos)
            {
                case "ingresos":
                    decimal ingresos_caja_cliente = 0;
                    decimal ingresos_caja_cobrador =  0;
                    decimal ingresos_finanzas_dpr =  0;
                    decimal ingresos_total = 0;
                    if (tabla_sus.Rows.Count > 0)
                    {
                        ingresos_caja_cliente += (decimal)tabla_sus.Rows[0]["caja_cliente"];
                        ingresos_caja_cobrador += (decimal)tabla_sus.Rows[0]["caja_cobrador"];
                        ingresos_finanzas_dpr += (decimal)tabla_sus.Rows[0]["finanzas_dpr"];
                        ingresos_total += (decimal)tabla_sus.Rows[0]["total"];
                    }
                    if (tabla_bs.Rows.Count > 0)
                    {
                        ingresos_caja_cliente += (((decimal)tabla_bs.Rows[0]["caja_cliente"]) / tc);
                        ingresos_caja_cobrador += (((decimal)tabla_bs.Rows[0]["caja_cobrador"]) / tc);
                        ingresos_finanzas_dpr += (((decimal)tabla_bs.Rows[0]["finanzas_dpr"]) / tc);
                        ingresos_total += (((decimal)tabla_bs.Rows[0]["total"]) / tc);
                    }

                    str.AppendLine("<div style='font-weight:bold; text-align:center; font-size:14px;'>Resumen de Ingresos (entre el " + Fecha_inicio.ToString("d") + " y el " + Fecha_fin.AddDays(-1).ToString("d") + ")</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Ingresos en Caja:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + (ingresos_caja_cliente + ingresos_caja_cobrador).ToString("N2") + " (Clientes: " + Codigo_moneda + " " + ingresos_caja_cliente.ToString("N2") + " ; Cobradores: " + Codigo_moneda + " " + ingresos_caja_cobrador.ToString("N2") + ")</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Ingresos en finanzas (DPRs):</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + ingresos_finanzas_dpr.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Total de ingresos:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + ingresos_total.ToString("N2") + "</span>");
                    str.AppendLine("</div>");
                    break;

                case "ventas":
                    //[terreno_suma],[terreno_num],[dpto_suma],[dpto_num],[casa_suma],[casa_num],[total_suma],[total_num]
                    int ventas_terreno_num = 0;
                    int ventas_dpto_num = 0;
                    int ventas_casa_num = 0;
                    int ventas_total_num = 0;
                    decimal ventas_terreno_suma = 0;
                    decimal ventas_dpto_suma = 0;
                    decimal ventas_casa_suma = 0;
                    decimal ventas_total_suma = 0;
                    if (tabla_sus.Rows.Count > 0)
                    {
                        ventas_terreno_num += (int)tabla_sus.Rows[0]["terreno_num"];
                        ventas_dpto_num += (int)tabla_sus.Rows[0]["dpto_num"];
                        ventas_casa_num += (int)tabla_sus.Rows[0]["casa_num"];
                        ventas_total_num += (int)tabla_sus.Rows[0]["total_num"];

                        ventas_terreno_suma += (decimal)tabla_sus.Rows[0]["terreno_suma"];
                        ventas_dpto_suma += (decimal)tabla_sus.Rows[0]["dpto_suma"];
                        ventas_casa_suma += (decimal)tabla_sus.Rows[0]["casa_suma"];
                        ventas_total_suma += (decimal)tabla_sus.Rows[0]["total_suma"];
                    }
                    if (tabla_bs.Rows.Count > 0)
                    {
                        ventas_terreno_num += (int)tabla_bs.Rows[0]["terreno_num"];
                        ventas_dpto_num += (int)tabla_bs.Rows[0]["dpto_num"];
                        ventas_casa_num += (int)tabla_bs.Rows[0]["casa_num"];
                        ventas_total_num += (int)tabla_bs.Rows[0]["total_num"];

                        ventas_terreno_suma += (((decimal)tabla_bs.Rows[0]["terreno_suma"]) / tc);
                        ventas_dpto_suma += (((decimal)tabla_bs.Rows[0]["dpto_suma"]) / tc);
                        ventas_casa_suma += (((decimal)tabla_bs.Rows[0]["casa_suma"]) / tc);
                        ventas_total_suma += (((decimal)tabla_bs.Rows[0]["total_suma"]) / tc);
                    }
                    
                    str.AppendLine("<div style='font-weight:bold; text-align:center; font-size:14px;'>Resumen de Ventas (entre el " + Fecha_inicio.ToString("d") + " y el " + Fecha_fin.AddDays(-1).ToString("d") + ")</div>");
                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Venta de terrenos:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + ventas_terreno_suma.ToString("N2") + " (" + ventas_terreno_num.ToString() + " ventas)</span>");
                    str.AppendLine("</div>");
                    break;

                case "reversiones":
                    //[terreno_num],[terreno_suma],[dpto_num],[dpto_suma],[casa_num],[casa_suma],[total_num],[total_suma]
                    int rev_terreno_num = 0;
                    int rev_dpto_num = 0;
                    int rev_casa_num = 0;
                    int rev_total_num = 0;
                    decimal rev_terreno_suma = 0;
                    decimal rev_dpto_suma = 0;
                    decimal rev_casa_suma = 0;
                    decimal rev_total_suma = 0;
                    if (tabla_sus.Rows.Count > 0)
                    {
                        rev_terreno_num += (int)tabla_sus.Rows[0]["terreno_num"];
                        rev_dpto_num += (int)tabla_sus.Rows[0]["dpto_num"];
                        rev_casa_num += (int)tabla_sus.Rows[0]["casa_num"];
                        rev_total_num += (int)tabla_sus.Rows[0]["total_num"];

                        rev_terreno_suma += (decimal)tabla_sus.Rows[0]["terreno_suma"];
                        rev_dpto_suma += (decimal)tabla_sus.Rows[0]["dpto_suma"];
                        rev_casa_suma += (decimal)tabla_sus.Rows[0]["casa_suma"];
                        rev_total_suma += (decimal)tabla_sus.Rows[0]["total_suma"];
                    }
                    if (tabla_bs.Rows.Count > 0)
                    {
                        rev_terreno_num += (int)tabla_bs.Rows[0]["terreno_num"];
                        rev_dpto_num += (int)tabla_bs.Rows[0]["dpto_num"];
                        rev_casa_num += (int)tabla_bs.Rows[0]["casa_num"];
                        rev_total_num += (int)tabla_bs.Rows[0]["total_num"];

                        rev_terreno_suma += (((decimal)tabla_bs.Rows[0]["terreno_suma"]) / tc);
                        rev_dpto_suma += (((decimal)tabla_bs.Rows[0]["dpto_suma"]) / tc);
                        rev_casa_suma += (((decimal)tabla_bs.Rows[0]["casa_suma"]) / tc);
                        rev_total_suma += (((decimal)tabla_bs.Rows[0]["total_suma"]) / tc);
                    }

                    str.AppendLine("<div style='font-weight:bold; text-align:center; font-size:14px;'>Resumen de Reversiones (entre el " + Fecha_inicio.ToString("d") + " y el " + Fecha_fin.AddDays(-1).ToString("d") + ")</div>");
                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Reversión de terrenos:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + rev_terreno_suma.ToString("N2") + " (" + rev_terreno_num.ToString() + " terrenos)</span>");
                    str.AppendLine("</div>");
                    break;

                case "mora":
                    //[fecha],[num_dias_mora],[num_dias_ultimo_pago],[num_no_pagaron],[saldo_no_pagaron],[num_pagaron],[saldo_pagaron],[num_total],[saldo_total]
                    //DateTime fecha = (DateTime)tabla.Rows[0]["fecha"];
                    int num_dias_mora = 0;
                    int num_dias_ultimo_pago = 0;

                    int mora_num_no_pagaron = 0;
                    int mora_num_pagaron = 0;
                    int mora_num_especial = 0;
                    int mora_num_total = 0;

                    decimal mora_saldo_no_pagaron = 0;
                    decimal mora_saldo_pagaron = 0;
                    decimal mora_saldo_especial = 0;
                    decimal mora_saldo_total = 0;

                    if (tabla_sus.Rows.Count > 0)
                    {
                        num_dias_mora = (int)tabla_sus.Rows[0]["num_dias_mora"];
                        num_dias_ultimo_pago = (int)tabla_sus.Rows[0]["num_dias_ultimo_pago"];

                        mora_num_no_pagaron += (int)tabla_sus.Rows[0]["num_no_pagaron"];
                        mora_num_pagaron += (int)tabla_sus.Rows[0]["num_pagaron"];
                        mora_num_especial += (int)tabla_sus.Rows[0]["num_especial"];
                        mora_num_total += (int)tabla_sus.Rows[0]["num_total"];

                        mora_saldo_no_pagaron += (decimal)tabla_sus.Rows[0]["saldo_no_pagaron"];
                        mora_saldo_pagaron += (decimal)tabla_sus.Rows[0]["saldo_pagaron"];
                        mora_saldo_especial += (decimal)tabla_sus.Rows[0]["saldo_especial"];
                        mora_saldo_total += (decimal)tabla_sus.Rows[0]["saldo_total"];
                    }
                    if (tabla_bs.Rows.Count > 0)
                    {
                        num_dias_mora = (int)tabla_bs.Rows[0]["num_dias_mora"];
                        num_dias_ultimo_pago = (int)tabla_bs.Rows[0]["num_dias_ultimo_pago"];

                        mora_num_no_pagaron += (int)tabla_bs.Rows[0]["num_no_pagaron"];
                        mora_num_pagaron += (int)tabla_bs.Rows[0]["num_pagaron"];
                        mora_num_especial += (int)tabla_bs.Rows[0]["num_especial"];
                        mora_num_total += (int)tabla_bs.Rows[0]["num_total"];

                        mora_saldo_no_pagaron += (((decimal)tabla_bs.Rows[0]["saldo_no_pagaron"])/tc);
                        mora_saldo_pagaron += (((decimal)tabla_bs.Rows[0]["saldo_pagaron"])/tc);
                        mora_saldo_especial += (((decimal)tabla_bs.Rows[0]["saldo_especial"])/tc);
                        mora_saldo_total += (((decimal)tabla_bs.Rows[0]["saldo_total"]) / tc);
                    }

                    str.AppendLine("<div style='font-weight:bold; text-align:center; font-size:14px;'>Resumen de Mora (al " + Fecha_fin.AddDays(-1).ToString("d") + ")</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo de contratos en mora que NO pagaron en los últimos " + num_dias_ultimo_pago.ToString() + " días:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + mora_saldo_no_pagaron.ToString("N2") + " (" + mora_num_no_pagaron.ToString() + " contratos)</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo de contratos en mora que pagaron en los últimos " + num_dias_ultimo_pago.ToString() + " días:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + mora_saldo_pagaron.ToString("N2") + " (" + mora_num_pagaron.ToString() + " contratos)</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo de contratos en mora de cartera Especial</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + mora_saldo_especial.ToString("N2") + " (" + mora_num_especial.ToString() + " contratos)</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo total de todos los contratos en mora:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + mora_saldo_total.ToString("N2") + " (" + mora_num_total.ToString() + " contratos)</span>");
                    
                    str.AppendLine("</div>");
                    break;
                case "cxc":
                    //[saldo_inicial],[reactivados],[ventas],[reversiones],[saldo_final],[mora]
                    decimal cxc_saldo_inicial = 0;
                    decimal cxc_reactivados = 0;
                    decimal cxc_ventas = 0;
                    decimal cxc_reversiones = 0;
                    decimal cxc_saldo_final = 0;
                    decimal cxc_mora = 0;

                    if (tabla_sus.Rows.Count > 0)
                    {
                        cxc_saldo_inicial += (decimal)tabla_sus.Rows[0]["saldo_inicial"];
                        cxc_reactivados += (decimal)tabla_sus.Rows[0]["reactivados"];
                        cxc_ventas += (decimal)tabla_sus.Rows[0]["ventas"];
                        cxc_reversiones += (decimal)tabla_sus.Rows[0]["reversiones"];
                        cxc_saldo_final += (decimal)tabla_sus.Rows[0]["saldo_final"];
                        cxc_mora += (decimal)tabla_sus.Rows[0]["mora"];
                    }
                    if (tabla_bs.Rows.Count > 0)
                    {
                        cxc_saldo_inicial += (((decimal)tabla_bs.Rows[0]["saldo_inicial"]) / tc);
                        cxc_reactivados += (((decimal)tabla_bs.Rows[0]["reactivados"]) / tc);
                        cxc_ventas += (((decimal)tabla_bs.Rows[0]["ventas"]) / tc);
                        cxc_reversiones += (((decimal)tabla_bs.Rows[0]["reversiones"]) / tc);
                        cxc_saldo_final += (((decimal)tabla_bs.Rows[0]["saldo_final"]) / tc);
                        cxc_mora += (((decimal)tabla_bs.Rows[0]["mora"]) / tc);
                    }

                    str.AppendLine("<div style='font-weight:bold; text-align:center; font-size:14px;'>Resumen de cuentas por cobrar de contratos (entre el " + Fecha_inicio.ToString("d") + " y el " + Fecha_fin.AddDays(-1).ToString("d") + ")</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo final (al " + Fecha_inicio.AddDays(-1).ToString("d") + "):</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + cxc_saldo_inicial.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Reactivaciones:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + cxc_reactivados.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Ventas realizadas:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + cxc_ventas.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Reversiones realizadas:</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + cxc_reversiones.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo final (al " + Fecha_fin.AddDays(-1).ToString("d") + "):</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + cxc_saldo_final.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Mora (al " + Fecha_fin.AddDays(-1).ToString("d") + "):</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + cxc_mora.ToString("N2") + "</span>");
                    str.AppendLine("</div>");

                    str.AppendLine("<div style='text-align:left;'>");
                    str.AppendLine("<span style='font-weight:bold;'>Saldo final - Mora (al " + Fecha_fin.AddDays(-1).ToString("d") + "):</span>");
                    str.AppendLine("<span>" + Codigo_moneda + " " + (cxc_saldo_final - cxc_mora).ToString("N2") + "</span>");
                    str.AppendLine("</div>");
                    break;

            }

            str.AppendLine("</div>");
            return str.ToString();
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion

    }

    public class tmpInfoGerencialTerrasur
    {
        #region Propiedades
        private string _email = "";
        private bool _repIngresos = false;
        private bool _repVentas = false;
        private bool _repReversiones = false;
        private bool _repMora = false;
        private bool _repCxc = false;

        //Propiedades públicas
        public string email { get { return _email; } }
        public bool repIngresos { get { return _repIngresos; } }
        public bool repVentas { get { return _repVentas; } }
        public bool repReversiones { get { return _repReversiones; } }
        public bool repMora { get { return _repMora; } }
        public bool repCxc { get { return _repCxc; } }
        #endregion

        #region Constructores
        public tmpInfoGerencialTerrasur(string Email, bool RepIngresos, bool RepVentas, bool RepReversiones, bool RepMora, bool RepCxc)
        {
            _email = Email;
            _repIngresos = RepIngresos;
            _repVentas = RepVentas;
            _repReversiones = RepReversiones;
            _repMora = RepMora;
            _repCxc = RepCxc;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static List<tmpInfoGerencialTerrasur> ListaPredefinida()
        {
            List<tmpInfoGerencialTerrasur> lista = new List<tmpInfoGerencialTerrasur>();
            DataTable tabla = infoGerencialTerrasur.Lista();
            foreach (DataRow fila in tabla.Rows) lista.Add(new tmpInfoGerencialTerrasur(fila["email"].ToString(), bool.Parse(fila["repIngresos"].ToString()), bool.Parse(fila["repVentas"].ToString()), bool.Parse(fila["repReversiones"].ToString()), bool.Parse(fila["repMora"].ToString()), bool.Parse(fila["repCxc"].ToString())));
            return lista;
        }

        #endregion
    }

}