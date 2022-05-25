<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        //gv1.DataSource = tablaCompleta();
        ////gv1.DataSource = GenerarDetalle_transpuesto();
        //gv1.DataBind();

        if (rbl_forma.SelectedValue == "detalle")
        {
            DataTable tabla_detalle = tablaCompleta();
            ExportarExcel(ref tabla_detalle, "detalle");
        }
        else if (rbl_forma.SelectedValue == "detalle_trans")
        {
            DataTable tabla_detalle_trans = GenerarDetalle_transpuesto();
            ExportarExcel(ref tabla_detalle_trans, "detalle_trans");
        }
        else if (rbl_forma.SelectedValue == "resumen")
        {
            DataTable tabla_resumen = resumen();
            ExportarExcel(ref tabla_resumen, "resumen");
        }
        
    }


    public DataTable GenerarDetalle_transpuesto()
    {
        DataTable tabla_completa = tablaCompleta();
        //DataTable tabla_simulada = tablaSimulada();
        DataTable tabla_contratos = lista_contratos();

        DateTime fecha_minima_general = DateTime.Parse("01/01/2900");
        DateTime fecha_maxima_general = DateTime.Parse("01/01/1900");
        foreach (DataRow fila in tabla_completa.Rows)
        {
            if ((DateTime)fila["fecha"] < fecha_minima_general) { fecha_minima_general = (DateTime)fila["fecha"]; }
            if ((DateTime)fila["fecha"] > fecha_maxima_general) { fecha_maxima_general = (DateTime)fila["fecha"]; }
        }
        fecha_minima_general = DateTime.Parse("01/" + fecha_minima_general.Month.ToString() + "/" + fecha_minima_general.Year.ToString());
        fecha_maxima_general = DateTime.Parse("01/" + fecha_maxima_general.Month.ToString() + "/" + fecha_maxima_general.Year.ToString());

        //Se crean columnas
        DateTime fecha_aux = fecha_minima_general;
        DataTable tabla_resultado = new DataTable();
        tabla_resultado.Columns.Add("ctto");
        while (fecha_aux <= fecha_maxima_general)
        {
            tabla_resultado.Columns.Add(fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_k", typeof(string));
            tabla_resultado.Columns.Add(fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_i", typeof(string));
            fecha_aux = fecha_aux.AddMonths(1);
        }
        
        
        //Se definne encabezados
        DataRow fila_encab1 = tabla_resultado.NewRow();
        DataRow fila_encab2 = tabla_resultado.NewRow();
        DataRow fila_encab3 = tabla_resultado.NewRow();
        fila_encab1["ctto"] = "Año";
        fila_encab2["ctto"] = "Mes";
        fila_encab3["ctto"] = "Concep.";
        fecha_aux = fecha_minima_general;
        while (fecha_aux <= fecha_maxima_general)
        {
            fila_encab1[fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_k"] = fecha_aux.Year.ToString();
            fila_encab1[fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_i"] = fecha_aux.Year.ToString();

            fila_encab2[fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_k"] = LiteralMes(fecha_aux.Month);
            fila_encab2[fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_i"] = LiteralMes(fecha_aux.Month);

            fila_encab3[fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_k"] = "K";
            fila_encab3[fecha_aux.Year.ToString() + "_" + fecha_aux.Month.ToString() + "_i"] = "I";

            fecha_aux = fecha_aux.AddMonths(1);
        }
        tabla_resultado.Rows.Add(fila_encab1);
        tabla_resultado.Rows.Add(fila_encab2);
        tabla_resultado.Rows.Add(fila_encab3);

        foreach (DataRow fila_contrato in tabla_contratos.Rows)
        {
            string num_contrato = fila_contrato["numero"].ToString();

            DataRow fila_dato = tabla_resultado.NewRow();

            fila_dato["ctto"] = num_contrato;
            //[contrato],[mes_guia],[fecha],[monto],[interes],[capital],[saldo]
            foreach (DataRow fila_completa in tabla_completa.Rows)
            {
                if (fila_completa["contrato"].ToString() == num_contrato)
                {
                    DateTime fecha_guia = (DateTime)fila_completa["mes_guia"];
                    fila_dato[fecha_guia.Year.ToString() + "_" + fecha_guia.Month.ToString() + "_k"] = (decimal)fila_completa["capital"];
                    fila_dato[fecha_guia.Year.ToString() + "_" + fecha_guia.Month.ToString() + "_i"] = (decimal)fila_completa["interes"];
                }
            }

            tabla_resultado.Rows.Add(fila_dato);            
        }

        return tabla_resultado;
    }



    public DataTable resumen()
    {
        DataTable tabla_contratos = lista_contratos();
        DataTable tabla_completa = tablaCompleta();

        DateTime fecha_minima_general = DateTime.Parse("01/01/2900");
        DateTime fecha_maxima_general = DateTime.Parse("01/01/1900");
        foreach (DataRow fila in tabla_completa.Rows)
        {
            if ((DateTime)fila["fecha"] < fecha_minima_general) { fecha_minima_general = (DateTime)fila["fecha"]; }
            if ((DateTime)fila["fecha"] > fecha_maxima_general) { fecha_maxima_general = (DateTime)fila["fecha"]; }
        }
        fecha_minima_general = DateTime.Parse("01/01/" + fecha_minima_general.Year.ToString());
        fecha_maxima_general = DateTime.Parse("01/01/" + fecha_maxima_general.Year.ToString());
        
        //[contrato],[mes_guia],[fecha],[monto],[interes],[capital],[saldo]


        //Se crean columnas
        DateTime fecha_aux = fecha_minima_general;
        DataTable tabla_resultado = new DataTable();
        tabla_resultado.Columns.Add("ctto");
        while (fecha_aux <= fecha_maxima_general)
        {
            tabla_resultado.Columns.Add(fecha_aux.Year.ToString() + "_k", typeof(string));
            tabla_resultado.Columns.Add(fecha_aux.Year.ToString() + "_i", typeof(string));
            fecha_aux = fecha_aux.AddYears(1);
        }


        //Se definne encabezados
        DataRow fila_encab1 = tabla_resultado.NewRow();
        DataRow fila_encab2 = tabla_resultado.NewRow();
        fila_encab1["ctto"] = "Año";
        fila_encab2["ctto"] = "Concep.";
        fecha_aux = fecha_minima_general;
        while (fecha_aux <= fecha_maxima_general)
        {
            fila_encab1[fecha_aux.Year.ToString() + "_k"] = fecha_aux.Year.ToString();
            fila_encab1[fecha_aux.Year.ToString() + "_i"] = fecha_aux.Year.ToString();

            fila_encab2[fecha_aux.Year.ToString() + "_k"] = "K";
            fila_encab2[fecha_aux.Year.ToString() + "_i"] = "I";

            fecha_aux = fecha_aux.AddYears(1);
        }
        tabla_resultado.Rows.Add(fila_encab1);
        tabla_resultado.Rows.Add(fila_encab2);

        //Se obtienen los subtotales
        foreach (DataRow fila_contrato in tabla_contratos.Rows)
        {
            string num_contrato = fila_contrato["numero"].ToString();

            DataRow fila_dato = tabla_resultado.NewRow();
            fila_dato["ctto"] = num_contrato;
            
            fecha_aux = fecha_minima_general;
            while (fecha_aux <= fecha_maxima_general)
            {
                decimal k = 0;
                decimal i = 0;
                foreach (DataRow fila_completa in tabla_completa.Rows)
                {
                    if (fila_completa["contrato"].ToString() == num_contrato
                        && ((DateTime)fila_completa["mes_guia"]).Year == fecha_aux.Year)
                    {
                        k = k + (decimal)fila_completa["capital"];
                        i = i + (decimal)fila_completa["interes"];
                    }
                }

                fila_dato[fecha_aux.Year.ToString() + "_k"] = k;
                fila_dato[fecha_aux.Year.ToString() + "_i"] = i;

                fecha_aux = fecha_aux.AddYears(1);
            }

            tabla_resultado.Rows.Add(fila_dato);
        }
        return tabla_resultado;
    }
    
    public DataTable tablaCompleta()
    {
        DataTable tabla_simulada = tablaSimulada();
        DataTable tabla_contratos = lista_contratos();
        
        DateTime fecha_minima_general = DateTime.Parse("01/01/2900");
        DateTime fecha_maxima_general = DateTime.Parse("01/01/1900");
        foreach (DataRow fila in tabla_simulada.Rows)
        {
            if ((DateTime)fila["fecha"] < fecha_minima_general) { fecha_minima_general = (DateTime)fila["fecha"]; }
            if ((DateTime)fila["fecha"] > fecha_maxima_general) { fecha_maxima_general = (DateTime)fila["fecha"]; }
        }
        fecha_minima_general = DateTime.Parse("01/" + fecha_minima_general.Month.ToString() + "/" + fecha_minima_general.Year.ToString());
        fecha_maxima_general = DateTime.Parse("01/" + fecha_maxima_general.Month.ToString() + "/" + fecha_maxima_general.Year.ToString());
        

        foreach (DataRow fila_contrato in tabla_contratos.Rows)
        {
            string num_contrato = fila_contrato["numero"].ToString();
            DateTime fecha_minima_contrato = DateTime.Parse("01/01/2900");
            DateTime fecha_maxima_contrato = DateTime.Parse("01/01/1900");
            foreach (DataRow fila_pagos in tabla_simulada.Rows)
            {
                if (fila_pagos["contrato"].ToString() == num_contrato)
                {
                    if ((DateTime)fila_pagos["fecha"] < fecha_minima_contrato) { fecha_minima_contrato = (DateTime)fila_pagos["fecha"]; }
                    if ((DateTime)fila_pagos["fecha"] > fecha_maxima_contrato) { fecha_maxima_contrato = (DateTime)fila_pagos["fecha"]; }
                }
            }
            fecha_minima_contrato = DateTime.Parse("01/" + fecha_minima_contrato.Month.ToString() + "/" + fecha_minima_contrato.Year.ToString());
            fecha_maxima_contrato = DateTime.Parse("01/" + fecha_maxima_contrato.Month.ToString() + "/" + fecha_maxima_contrato.Year.ToString());

            //relleno inferior
            DateTime f_inf = fecha_minima_general;
            while (f_inf < fecha_minima_contrato)
            {
                DataRow fila_pago = tabla_simulada.NewRow();
                fila_pago["contrato"] = num_contrato;
                fila_pago["fecha"] = f_inf;
                fila_pago["monto"] = 0;
                fila_pago["interes"] = 0;
                fila_pago["capital"] = 0;
                fila_pago["saldo"] = 0;
                tabla_simulada.Rows.Add(fila_pago);

                f_inf = f_inf.AddMonths(1);  
            }
            
            //relleno superior
            DateTime f_sup = fecha_maxima_contrato.AddMonths(1);
            while (f_sup <= fecha_maxima_general)
            {
                DataRow fila_pago = tabla_simulada.NewRow();
                fila_pago["contrato"] = num_contrato;
                fila_pago["fecha"] = f_sup;
                fila_pago["monto"] = 0;
                fila_pago["interes"] = 0;
                fila_pago["capital"] = 0;
                fila_pago["saldo"] = 0;
                tabla_simulada.Rows.Add(fila_pago);

                f_sup = f_sup.AddMonths(1);
            }
        }
        
        //Se completa el mes guia
        foreach (DataRow fila_simulada in tabla_simulada.Rows)
        {
            DateTime fecha = (DateTime)fila_simulada["fecha"];
            fila_simulada["mes_guia"] = DateTime.Parse("01/" + fecha.Month.ToString() + "/" + fecha.Year.ToString());
        }

        return tabla_simulada;
    }
    
    public DataTable lista_contratos()
    {
        //[id_pago],[numero],[mes_inicio],[mes_fin]
        //[num_cuotas],[fecha],[fecha_proximo],[seguro],[seguro_fecha],[seguro_meses],[mantenimiento_sus],[mantenimiento_fecha],[mantenimiento_meses],[interes],[interes_fecha],[interes_dias],[interes_dias_total],[monto_pago],[amortizacion],[saldo]
        //[pp_cuota_base],[pp_fecha_inicio_plan],[pp_seguro],[pp_mantenimiento_sus],[pp_interes_corriente]

        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("nafibo_simPlanesOriginales");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }
    
    public DataTable tablaSimulada()
    {
        //[contrato],[mes_guia],[fecha],[monto],[interes],[capital],[saldo]
        DataTable tabla_resultado = new DataTable();
        tabla_resultado.Columns.Add("contrato", typeof(string));
        tabla_resultado.Columns.Add("mes_guia", typeof(DateTime));
        tabla_resultado.Columns.Add("fecha", typeof(DateTime));
        tabla_resultado.Columns.Add("monto", typeof(decimal));
        tabla_resultado.Columns.Add("interes", typeof(decimal));
        tabla_resultado.Columns.Add("capital", typeof(decimal));
        tabla_resultado.Columns.Add("saldo", typeof(decimal));

        string num_contrato = "";
        DateTime fecha_inicio = DateTime.Now;
        DateTime fecha_fin = DateTime.Now;

        DataTable tabla_contratos = lista_contratos();

        foreach (DataRow fila_contratos in tabla_contratos.Rows)
        {
            num_contrato = (string)fila_contratos["numero"];
            fecha_inicio = (DateTime)fila_contratos["mes_inicio"];
            fecha_fin = (DateTime)fila_contratos["mes_fin"];

            ReportePlanPagosVigente_SimularPagos(ref tabla_resultado,
                num_contrato, fecha_inicio, fecha_fin

                , (DateTime)fila_contratos["fecha"], (DateTime)fila_contratos["fecha_proximo"], (int)fila_contratos["num_cuotas"], (decimal)fila_contratos["seguro"], (int)fila_contratos["seguro_meses"], (DateTime)fila_contratos["seguro_fecha"], (decimal)fila_contratos["mantenimiento_sus"], (int)fila_contratos["mantenimiento_meses"], (DateTime)fila_contratos["mantenimiento_fecha"], (decimal)fila_contratos["interes"], (int)fila_contratos["interes_dias"], (int)fila_contratos["interes_dias_total"], (DateTime)fila_contratos["interes_fecha"], (decimal)fila_contratos["monto_pago"], (decimal)fila_contratos["amortizacion"], (decimal)fila_contratos["saldo"]

                , (decimal)fila_contratos["pp_cuota_base"]
                , (DateTime)fila_contratos["pp_fecha_inicio_plan"]
                , (decimal)fila_contratos["pp_seguro"]
                , (decimal)fila_contratos["pp_mantenimiento_sus"]
                , (decimal)fila_contratos["pp_interes_corriente"]
            );
        }

        return tabla_resultado;
    }

    protected static void ReportePlanPagosVigente_SimularPagos(ref DataTable Tabla_res,
    string Num_contrato, DateTime Fecha_inicio, DateTime Fecha_fin,

    DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha,
    decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes,
    int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo,

    decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, decimal pp_seguro, decimal pp_mantenimiento_sus, decimal pp_interes_corriente
    )
    {
        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

        //int contador_pagos = Num_pagos_anteriores;
        //DateTime Fecha_recompra = Reco_fecha.Date.AddDays(1).AddSeconds(-1);
        DateTime Fecha_ini_aux = DateTime.Parse(pp_fecha_inicio_plan.Day.ToString() + "/" + Fecha_inicio.Month.ToString() + "/" + Fecha_inicio.Year.ToString() + " 12:00:00");
        DateTime Fecha_fin_aux = DateTime.Parse("01/" + Fecha_fin.Month.ToString() + "/" + Fecha_fin.Year.ToString()).AddMonths(1).AddSeconds(-1);
        
        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        while (pago_simulado.saldo > 0 && Fecha_ini_aux <= Fecha_fin_aux)
        {
            //pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
            pago_simulado = new sim_pago(pago_simulado, Fecha_ini_aux, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);

            DataRow fila_pago = Tabla_res.NewRow();
            fila_pago["contrato"] = Num_contrato;
            fila_pago["fecha"] = pago_simulado.fecha;
            fila_pago["monto"] = pago_simulado.monto_pago;
            fila_pago["interes"] = pago_simulado.interes;
            fila_pago["capital"] = pago_simulado.amortizacion;
            fila_pago["saldo"] = pago_simulado.saldo;

            //if (pago_simulado.fecha <= Fecha_recompra) { fila_pago["estado"] = "Nafi"; }
            //else { fila_pago["estado"] = "Terr"; }
            Tabla_res.Rows.Add(fila_pago);

            Fecha_ini_aux = Fecha_ini_aux.AddMonths(1);
        }
    }

    public string LiteralMes(int num)
    {
        string literal = "";
        switch (num)
        {
            case 1: literal = "Ene"; break;
            case 2: literal = "Feb"; break;
            case 3: literal = "Mar"; break;
            case 4: literal = "Abr"; break;
            case 5: literal = "May"; break;
            case 6: literal = "Jun"; break;
            case 7: literal = "Jul"; break;
            case 8: literal = "Ago"; break;
            case 9: literal = "Sep"; break;
            case 10: literal = "Oct"; break;
            case 11: literal = "Nov"; break;
            case 12: literal = "Dic"; break;
        }
        return literal;
    }

    protected void ExportarExcel(ref System.Data.DataTable tabla, string nombre_archivo)
    {

        //Se crea el gridview y se cargan sus datos
        GridView gv = new GridView();
        gv.DataSource = tabla;
        gv.DataBind();

        //Estilos de la tabla
        gv.Attributes.CssStyle.Add("font-size", "9px");
        gv.Attributes.CssStyle.Add("font-family", "Arial");
        //for (int j = 0; j < gv.Columns.Count; j++)
        //{
        //    gv.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-color", "black");
        //    gv.HeaderRow.Cells[j].Attributes.CssStyle.Add("color", "white");
        //}

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        System.Web.UI.Page page = new System.Web.UI.Page();
        System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
        gv.EnableViewState = false;
        //Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;
        //Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();
        page.Controls.Add(form);
        //form.Controls.Add(titulo);
        form.Controls.Add(gv);
        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + nombre_archivo + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbl_forma" runat="server">
                        <asp:ListItem Text="Detalle" Value="detalle" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Detalle transpueto" Value="detalle_trans"></asp:ListItem>
                        <asp:ListItem Text="Resumen" Value="resumen"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_obtener" runat="server" Text="Obtener datos" onclick="btn_obtener_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv1" runat="server"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
