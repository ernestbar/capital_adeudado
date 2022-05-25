<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de proyección de pagos" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(!permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteProyeccionPagos"))
            {
                Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
            }
        }
    }    
    
    protected void btn_mostrar_reporte_Click(object sender, EventArgs e)
    {
        DateTime Fecha = cp_fecha.SelectedDate;
        string Id_negocio = general.StringNegocios(true, cbl_negocio.Items);
        DateTime Periodo_inicio;
        if (cp_fecha_inicio.SelectedValue.HasValue) { Periodo_inicio = cp_fecha_inicio.SelectedDate; } else { Periodo_inicio = cp_fecha.SelectedDate.AddDays(1); }
        DateTime Periodo_fin;
        if (cp_fecha_fin.SelectedValue.HasValue) { Periodo_fin = cp_fecha_fin.SelectedDate; } else { Periodo_fin = DateTime.Parse("01/01/5900"); }
        DateTime Fecha_limite_saldo0;
        if (cp_fecha_fin_pago.SelectedValue.HasValue) { Fecha_limite_saldo0 = cp_fecha_fin_pago.SelectedDate; } else { Fecha_limite_saldo0 = DateTime.Parse("01/01/5900"); }
        int Id_moneda = int.Parse(rbl_moneda.SelectedValue);
        bool Consolidado = rbl_consolidado.SelectedValue.Equals("True");

        if (rbl_resumen.SelectedValue == "pagos_restantes")
        {
            System.Data.DataTable tabla_resultado = CxcPagosRestantes(Fecha, Id_negocio, decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), Fecha_limite_saldo0, Id_moneda, Consolidado);
            string columnas = "num_contrato,sector,cuota,fecha,monto,capital,interes,manten,seguro,saldo";
            Hashtable hashtable = Obtenerhash2();
            ExportarExcel(ref tabla_resultado, columnas, "CarteraProyectada_pagos", hashtable);
        }
        else
        {
            System.Data.DataTable tabla_resultado = Cxc(Fecha, Id_negocio, decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), Periodo_inicio, Periodo_fin, Fecha_limite_saldo0, Id_moneda, Consolidado);

            panel_resumen.Visible = rbl_resumen.SelectedValue.Equals("resumen_general");
            if (rbl_resumen.SelectedValue.Equals("resumen_general"))
            {
                //gv_resumen.DataSource = proyeccionPagos.ResumenCxc(ref tabla_resultado);
                gv_resumen.DataSource = ResumenCxc(ref tabla_resultado);
                gv_resumen.DataBind();
            }
            else if (rbl_resumen.SelectedValue.Equals("resumen_sector"))
            {
                DataTable tabla_resumen_sector = ResumenCxc_por_sector(ref tabla_resultado);
                string columnas = "localizacion,sector,num_contratos,precio_final,real_capital,real_mant,real_interes,real_seguro,real_total,real_saldo,PendPeri_capital,PendPeri_mant,PendPeri_interes,PendPeri_seguro,PendPeri_total,PendPeri_saldo,post_capital,post_mant,post_interes,post_seguro,post_total,tota_capital,tota_mant,tota_interes,tota_seguro,tota_total";
                Hashtable hashtable = Obtenerhash();
                ExportarExcel(ref tabla_resumen_sector, columnas, "CarteraProyectada_sector", hashtable);
            }
            else if (rbl_resumen.SelectedValue.Equals("detalle"))
            {
                //string columnas = "numero,precio_final,real_cuotas,real_capital,real_mant,real_interes,real_total,real_saldo,PendPeri_cuotas,PendPeri_capital,PendPeri_mant,PendPeri_interes,PendPeri_total,PendPeri_saldo,post_cuotas,post_capital,post_mant,post_interes,post_total,post_saldo,tota_cuotas,tota_capital,tota_mant,tota_interes,tota_total,fecha_saldo0";
                string columnas = "localizacion,sector,numero,precio_final,real_cuotas,real_capital,real_mant,real_interes,real_seguro,real_total,real_saldo,PendPeri_cuotas,PendPeri_capital,PendPeri_mant,PendPeri_interes,PendPeri_seguro,PendPeri_total,PendPeri_saldo,post_cuotas,post_capital,post_mant,post_interes,post_seguro,post_total,tota_cuotas,tota_capital,tota_mant,tota_interes,tota_seguro,tota_total,fecha_saldo0";
                Hashtable hashtable = Obtenerhash();
                ExportarExcel(ref tabla_resultado, columnas, "CarteraProyectada", hashtable);
            }
            //else if (rbl_resumen.SelectedValue.Equals("pagos_restantes"))
            //{
            //    DataTable tabla_pagos_restantes = (Fecha, Id_negocio, decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), Periodo_inicio, Periodo_fin, Fecha_limite_saldo0, Id_moneda, Consolidado);
            //    string columnas = "";
            //    Hashtable hashtable = Obtenerhash();
            //    ExportarExcel(ref tabla_resumen_sector, columnas, "CarteraProyectada_sector", hashtable);
            //}
        }
    }


    protected void rbl_consolidado_DataBound(object sender, EventArgs e) { if (rbl_consolidado.Items.Count > 1) { rbl_consolidado.SelectedIndex = 1; } lbl_consolidado_enun.Text = "Datos contemplados:"; }
    protected void cbl_negocio_DataBound(object sender, EventArgs e) { string casas_edif = ConfigurationManager.AppSettings["negocios_casas"]; foreach (ListItem item in cbl_negocio.Items) { item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(false); } }
    protected void rbl_moneda_DataBound(object sender, EventArgs e) { if (rbl_moneda.Items.Count > 0) { rbl_moneda.SelectedIndex = 0; } }


    protected void ExportarExcel(ref System.Data.DataTable tabla, string columnas, string nombre_archivo, Hashtable hashtable)
    {
        System.Collections.Generic.List<string> col = new System.Collections.Generic.List<string>();
        string[] lista_columnas = columnas.Split(',');
        for (int j = 0; j < lista_columnas.Length; j++) { col.Add(lista_columnas[j]); }


        //Se eliminan las columnas innecesarias
        for (int j = tabla.Columns.Count - 1; j >= 0; j--)
        {
            bool existe = false; foreach (string item in col) { if (item == tabla.Columns[j].ColumnName) { existe = true; break; } }
            if (!existe) { tabla.Columns.RemoveAt(j); }
        }

        foreach (DataColumn c in tabla.Columns)
        {
            c.ColumnName = hashtable[c.ColumnName].ToString();
        }

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

    protected Hashtable Obtenerhash2()
    {
        string codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        Hashtable hashtable = new Hashtable();
        hashtable["num_contrato"] = "Nº contrato";
        hashtable["sector"] = "Sector";
        hashtable["cuota"] = "Nº cuota";
        hashtable["fecha"] = "Fecha";
        hashtable["monto"] = "Monto del pago";
        hashtable["capital"] = "Capital";
        hashtable["interes"] = "Interés";
        hashtable["manten"] = "Mantenimiento";
        hashtable["seguro"] = "Seguro";
        hashtable["saldo"] = "Saldo";
        return hashtable;
    }

    protected Hashtable Obtenerhash()
    {
        string codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;

        Hashtable hashtable = new Hashtable();
        hashtable["localizacion"] = "Localización";
        hashtable["sector"] = "Sector";
        hashtable["num_contratos"] = "Nº cttos.";
        hashtable["numero"] = "Nº ctto.";
        hashtable["precio_final"] = "Precio final";
        hashtable["real_cuotas"] = "Realiz.Nro Cuotas";
        hashtable["real_capital"] = "Realiz.Capital";
        hashtable["real_mant"] = "Realiz.Mantenim.";
        hashtable["real_interes"] = "Realiz.Interés";
        hashtable["real_seguro"] = "Realiz.Seguro";
        hashtable["real_total"] = "Realiz.Total";
        hashtable["real_saldo"] = "Realiz.Saldo";
        hashtable["PendPeri_cuotas"] = "Periodo Nro Cuotas";
        hashtable["PendPeri_capital"] = "Periodo Capital";
        hashtable["PendPeri_mant"] = "Periodo Mantenim.";
        hashtable["PendPeri_interes"] = "Periodo Interés";
        hashtable["PendPeri_seguro"] = "Periodo Seguro";
        hashtable["PendPeri_total"] = "Periodo Total";
        hashtable["PendPeri_saldo"] = "Periodo Saldo";
        hashtable["post_cuotas"] = "Posterior Nro Cuotas";
        hashtable["post_capital"] = "Posterior Capital";
        hashtable["post_mant"] = "Posterior Mantenim.";
        hashtable["post_interes"] = "Posterior Interés";
        hashtable["post_seguro"] = "Posterior Seguro";
        hashtable["post_total"] = "Posterior Total";
        hashtable["tota_cuotas"] = "Total Nro Cuotas";
        hashtable["tota_capital"] = "Total Capital";
        hashtable["tota_mant"] = "Total Mantenim.";
        hashtable["tota_interes"] = "Total Interés";
        hashtable["tota_seguro"] = "Total Seguro";
        hashtable["tota_total"] = "Total Pagos";
        hashtable["fecha_saldo0"] = "Fecha de saldo 0";

        return hashtable;
    }

    public static DataTable ResumenCxc_por_sector(ref DataTable tabla_origen)
    {
        //origen.DefaultView.Sort = "localizacion,sector";
        //DataTable tabla_origen = origen.DefaultView.ToTable();
        
        DataTable tabla = new DataTable();
        
        tabla.Columns.Add("localizacion", typeof(string));
        tabla.Columns.Add("sector", typeof(string));

        tabla.Columns.Add("num_contratos", typeof(int));
        tabla.Columns.Add("precio_final", typeof(decimal));

        tabla.Columns.Add("real_capital", typeof(decimal));
        tabla.Columns.Add("real_interes", typeof(decimal));
        tabla.Columns.Add("real_seguro", typeof(decimal));
        tabla.Columns.Add("real_mant", typeof(decimal));
        tabla.Columns.Add("real_total", typeof(decimal));
        tabla.Columns.Add("real_saldo", typeof(decimal));

        tabla.Columns.Add("PendPeri_capital", typeof(decimal));
        tabla.Columns.Add("PendPeri_interes", typeof(decimal));
        tabla.Columns.Add("PendPeri_seguro", typeof(decimal));
        tabla.Columns.Add("PendPeri_mant", typeof(decimal));
        tabla.Columns.Add("PendPeri_total", typeof(decimal));
        tabla.Columns.Add("PendPeri_saldo", typeof(decimal));

        tabla.Columns.Add("post_capital", typeof(decimal));
        tabla.Columns.Add("post_interes", typeof(decimal));
        tabla.Columns.Add("post_seguro", typeof(decimal));
        tabla.Columns.Add("post_mant", typeof(decimal));
        tabla.Columns.Add("post_total", typeof(decimal));

        tabla.Columns.Add("tota_capital", typeof(decimal));
        tabla.Columns.Add("tota_interes", typeof(decimal));
        tabla.Columns.Add("tota_seguro", typeof(decimal));
        tabla.Columns.Add("tota_mant", typeof(decimal));
        tabla.Columns.Add("tota_total", typeof(decimal));
        
        foreach (DataRow fila_origen in tabla_origen.Rows)
        {
            int index_sector = -1;
            for (int j = 0; j < tabla.Rows.Count; j++)
            {
                if (tabla.Rows[j]["localizacion"].ToString() == fila_origen["localizacion"].ToString()
                    && tabla.Rows[j]["sector"].ToString() == fila_origen["sector"].ToString())
                {
                    index_sector = j; break;
                }
            }
            
            if (index_sector >= 0)
            {
                tabla.Rows[index_sector]["num_contratos"] = (int)tabla.Rows[index_sector]["num_contratos"] + 1;
                tabla.Rows[index_sector]["precio_final"] = (decimal)tabla.Rows[index_sector]["precio_final"] + (decimal)fila_origen["precio_final"];

                tabla.Rows[index_sector]["real_capital"] = (decimal)tabla.Rows[index_sector]["real_capital"] + (decimal)fila_origen["real_capital"];
                tabla.Rows[index_sector]["real_interes"] = (decimal)tabla.Rows[index_sector]["real_interes"] + (decimal)fila_origen["real_interes"];
                tabla.Rows[index_sector]["real_seguro"] = (decimal)tabla.Rows[index_sector]["real_seguro"] + (decimal)fila_origen["real_seguro"];
                tabla.Rows[index_sector]["real_mant"] = (decimal)tabla.Rows[index_sector]["real_mant"] + (decimal)fila_origen["real_mant"];
                tabla.Rows[index_sector]["real_total"] = (decimal)tabla.Rows[index_sector]["real_total"] + (decimal)fila_origen["real_total"];
                tabla.Rows[index_sector]["real_saldo"] = (decimal)tabla.Rows[index_sector]["real_saldo"] + (decimal)fila_origen["real_saldo"];

                tabla.Rows[index_sector]["PendPeri_capital"] = (decimal)tabla.Rows[index_sector]["PendPeri_capital"] + (decimal)fila_origen["PendPeri_capital"];
                tabla.Rows[index_sector]["PendPeri_interes"] = (decimal)tabla.Rows[index_sector]["PendPeri_interes"] + (decimal)fila_origen["PendPeri_interes"];
                tabla.Rows[index_sector]["PendPeri_seguro"] = (decimal)tabla.Rows[index_sector]["PendPeri_seguro"] + (decimal)fila_origen["PendPeri_seguro"];
                tabla.Rows[index_sector]["PendPeri_mant"] = (decimal)tabla.Rows[index_sector]["PendPeri_mant"] + (decimal)fila_origen["PendPeri_mant"];
                tabla.Rows[index_sector]["PendPeri_total"] = (decimal)tabla.Rows[index_sector]["PendPeri_total"] + (decimal)fila_origen["PendPeri_total"];
                tabla.Rows[index_sector]["PendPeri_saldo"] = (decimal)tabla.Rows[index_sector]["PendPeri_saldo"] + (decimal)fila_origen["PendPeri_saldo"];

                tabla.Rows[index_sector]["post_capital"] = (decimal)tabla.Rows[index_sector]["post_capital"] + (decimal)fila_origen["post_capital"];
                tabla.Rows[index_sector]["post_interes"] = (decimal)tabla.Rows[index_sector]["post_interes"] + (decimal)fila_origen["post_interes"];
                tabla.Rows[index_sector]["post_seguro"] = (decimal)tabla.Rows[index_sector]["post_seguro"] + (decimal)fila_origen["post_seguro"];
                tabla.Rows[index_sector]["post_mant"] = (decimal)tabla.Rows[index_sector]["post_mant"] + (decimal)fila_origen["post_mant"];
                tabla.Rows[index_sector]["post_total"] = (decimal)tabla.Rows[index_sector]["post_total"] + (decimal)fila_origen["post_total"];

                tabla.Rows[index_sector]["tota_capital"] = (decimal)tabla.Rows[index_sector]["tota_capital"] + (decimal)fila_origen["tota_capital"];
                tabla.Rows[index_sector]["tota_interes"] = (decimal)tabla.Rows[index_sector]["tota_interes"] + (decimal)fila_origen["tota_interes"];
                tabla.Rows[index_sector]["tota_seguro"] = (decimal)tabla.Rows[index_sector]["tota_seguro"] + (decimal)fila_origen["tota_seguro"];
                tabla.Rows[index_sector]["tota_mant"] = (decimal)tabla.Rows[index_sector]["tota_mant"] + (decimal)fila_origen["tota_mant"];
                tabla.Rows[index_sector]["tota_total"] = (decimal)tabla.Rows[index_sector]["tota_total"] + (decimal)fila_origen["tota_total"];
            }
            else
            {
                DataRow fila = tabla.NewRow();

                fila["localizacion"] = fila_origen["localizacion"].ToString();
                fila["sector"] = fila_origen["sector"].ToString();

                fila["num_contratos"] = 1;
                fila["precio_final"] = (decimal)fila_origen["precio_final"];

                fila["real_capital"] = (decimal)fila_origen["real_capital"];
                fila["real_interes"] = (decimal)fila_origen["real_interes"];
                fila["real_seguro"] = (decimal)fila_origen["real_seguro"];
                fila["real_mant"] = (decimal)fila_origen["real_mant"];
                fila["real_total"] = (decimal)fila_origen["real_total"];
                fila["real_saldo"] = (decimal)fila_origen["real_saldo"];

                fila["PendPeri_capital"] = (decimal)fila_origen["PendPeri_capital"];
                fila["PendPeri_interes"] = (decimal)fila_origen["PendPeri_interes"];
                fila["PendPeri_seguro"] = (decimal)fila_origen["PendPeri_seguro"];
                fila["PendPeri_mant"] = (decimal)fila_origen["PendPeri_mant"];
                fila["PendPeri_total"] = (decimal)fila_origen["PendPeri_total"];
                fila["PendPeri_saldo"] = (decimal)fila_origen["PendPeri_saldo"];

                fila["post_capital"] = (decimal)fila_origen["post_capital"];
                fila["post_interes"] = (decimal)fila_origen["post_interes"];
                fila["post_seguro"] = (decimal)fila_origen["post_seguro"];
                fila["post_mant"] = (decimal)fila_origen["post_mant"];
                fila["post_total"] = (decimal)fila_origen["post_total"];

                fila["tota_capital"] = (decimal)fila_origen["tota_capital"];
                fila["tota_interes"] = (decimal)fila_origen["tota_interes"];
                fila["tota_seguro"] = (decimal)fila_origen["tota_seguro"];
                fila["tota_mant"] = (decimal)fila_origen["tota_mant"];
                fila["tota_total"] = (decimal)fila_origen["tota_total"];
                
                tabla.Rows.Add(fila);
            }
        }

        tabla.DefaultView.Sort = "localizacion,sector";
        return tabla.DefaultView.ToTable();
    }











    public static DataTable ResumenCxc(ref DataTable origen)
    {
        DataTable tabla = new DataTable();
        tabla.Columns.Add("tipo", typeof(string));
        tabla.Columns.Add("capital", typeof(decimal));
        tabla.Columns.Add("interes", typeof(decimal));
        tabla.Columns.Add("manten", typeof(decimal));
        tabla.Columns.Add("seguro", typeof(decimal));
        tabla.Columns.Add("total", typeof(decimal));
        tabla.Columns.Add("saldo", typeof(decimal));

        if (origen.Rows.Count > 0)
        {
            decimal real_capital = 0; decimal real_mant = 0; decimal real_interes = 0; decimal real_seguro = 0; decimal real_total = 0; decimal real_saldo = 0;
            decimal PendPeri_capital = 0; decimal PendPeri_mant = 0; decimal PendPeri_interes = 0; decimal PendPeri_seguro = 0; decimal PendPeri_total = 0; decimal PendPeri_saldo = 0;
            decimal post_capital = 0; decimal post_mant = 0; decimal post_interes = 0; decimal post_seguro = 0; decimal post_total = 0;
            decimal tota_capital = 0; decimal tota_mant = 0; decimal tota_interes = 0; decimal tota_seguro = 0; decimal tota_total = 0;

            foreach (DataRow fila in origen.Rows)
            {
                real_capital += (decimal)fila["real_capital"];
                real_mant += (decimal)fila["real_mant"];
                real_interes += (decimal)fila["real_interes"];
                real_seguro += (decimal)fila["real_seguro"];
                real_total += (decimal)fila["real_total"];
                real_saldo += (decimal)fila["real_saldo"];

                PendPeri_capital += (decimal)fila["PendPeri_capital"];
                PendPeri_mant += (decimal)fila["PendPeri_mant"];
                PendPeri_interes += (decimal)fila["PendPeri_interes"];
                PendPeri_seguro += (decimal)fila["PendPeri_seguro"];
                PendPeri_total += (decimal)fila["PendPeri_total"];
                PendPeri_saldo += (decimal)fila["PendPeri_saldo"];

                post_capital += (decimal)fila["post_capital"];
                post_mant += (decimal)fila["post_mant"];
                post_interes += (decimal)fila["post_interes"];
                post_seguro += (decimal)fila["post_seguro"];
                post_total += (decimal)fila["post_total"];

                tota_capital += (decimal)fila["tota_capital"];
                tota_mant += (decimal)fila["tota_mant"];
                tota_interes += (decimal)fila["tota_interes"];
                tota_seguro += (decimal)fila["tota_seguro"];
                tota_total += (decimal)fila["tota_total"];
            }

            DataRow fila_realiz = tabla.NewRow();
            fila_realiz["tipo"] = "Pagos realizados antes del periodo";
            fila_realiz["capital"] = real_capital;
            fila_realiz["manten"] = real_mant;
            fila_realiz["interes"] = real_interes;
            fila_realiz["seguro"] = real_seguro;
            fila_realiz["total"] = real_total;
            fila_realiz["saldo"] = real_saldo;
            tabla.Rows.Add(fila_realiz);

            DataRow fila_periodo = tabla.NewRow();
            fila_periodo["tipo"] = "Pagos a realizarse en el periodo";
            fila_periodo["capital"] = PendPeri_capital;
            fila_periodo["manten"] = PendPeri_mant;
            fila_periodo["interes"] = PendPeri_interes;
            fila_periodo["seguro"] = PendPeri_seguro;
            fila_periodo["total"] = PendPeri_total;
            fila_periodo["saldo"] = PendPeri_saldo;
            tabla.Rows.Add(fila_periodo);

            DataRow fila_posterior = tabla.NewRow();
            fila_posterior["tipo"] = "Pagos a realizarse después del periodo";
            fila_posterior["capital"] = post_capital;
            fila_posterior["manten"] = post_mant;
            fila_posterior["interes"] = post_interes;
            fila_posterior["seguro"] = post_seguro;
            fila_posterior["total"] = post_total;
            tabla.Rows.Add(fila_posterior);

            DataRow fila_total = tabla.NewRow();
            fila_total["tipo"] = "Pagos en total";
            fila_total["capital"] = tota_capital;
            fila_total["manten"] = tota_mant;
            fila_total["interes"] = tota_interes;
            fila_total["seguro"] = tota_seguro;
            fila_total["total"] = tota_total;
            tabla.Rows.Add(fila_total);
        }

        return tabla;
    }

    
    public static DataTable Cxc(DateTime Fecha, string Id_negocio, decimal Saldo_menor, decimal Saldo_mayor, DateTime Periodo_inicio, DateTime Periodo_fin, DateTime Fecha_limite_saldo0, int Id_moneda, bool Consolidado)
    {
        //[negocio],[orden_negocio],[id_contrato],[codigo_moneda]
        //[tipo_cambio],[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan],[id_ultimo_pago]

        //[real_cuotas],[real_capital],[real_mant],[real_interes],[real_total],[real_saldo]
        //[pend_cuotas],[pend_capital],[pend_mant],[pend_interes],[pend_total],[real_saldo]
        //[PendPeri_capital],[PendPeri_mant],[PendPeri_interes],[PendPeri_total],[PendPeri_saldo]
        //[peri_cuotas],[peri_capital],[peri_mant],[peri_interes],[peri_total],[peri_saldo]
        //[post_cuotas],[post_capital],[post_mant],[post_interes],[post_total],[post_saldo]
        //[tota_cuotas],[tota_capital],[tota_mant],[tota_interes],[tota_total],[fecha_saldo0]

        //p_fecha,p_fecha_proximo,p_num_cuotas,p_seguro,p_seguro_meses,p_seguro_fecha,p_mantenimiento_sus,p_mantenimiento_meses,p_mantenimiento_fecha,p_interes,p_interes_dias,p_interes_dias_total,p_interes_fecha,p_monto_pago,p_amortizacion,p_saldo

        if (Consolidado == false) { return Cxc_original(Fecha, Id_negocio, Id_moneda, Saldo_menor, Saldo_mayor, Periodo_inicio, Periodo_fin, Fecha_limite_saldo0); }
        else
        {
            string codigo_moneda = new moneda(Id_moneda).codigo;
            DataTable tabla_sus; DataTable tabla_bs;
            if (codigo_moneda == "$us")
            {
                int Id_segunda_moneda = new moneda("Bs").id_moneda;
                tabla_sus = Cxc_original(Fecha, Id_negocio, Id_moneda, Saldo_menor, Saldo_mayor, Periodo_inicio, Periodo_fin, Fecha_limite_saldo0);
                tabla_bs = Cxc_original(Fecha, Id_negocio, Id_segunda_moneda, Saldo_menor, Saldo_mayor, Periodo_inicio, Periodo_fin, Fecha_limite_saldo0);
            }
            else
            {
                int Id_segunda_moneda = new moneda("$us").id_moneda;
                tabla_sus = Cxc_original(Fecha, Id_negocio, Id_segunda_moneda, Saldo_menor, Saldo_mayor, Periodo_inicio, Periodo_fin, Fecha_limite_saldo0);
                tabla_bs = Cxc_original(Fecha, Id_negocio, Id_moneda, Saldo_menor, Saldo_mayor, Periodo_inicio, Periodo_fin, Fecha_limite_saldo0);
            }
            return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio",
                "precio_final,mantenimiento_sus,cuota_base" +
                ",real_capital,real_mant,real_interes,real_seguro,real_total,real_saldo" +
                ",pend_capital,pend_mant,pend_interes,pend_seguro,pend_total,pend_saldo" +
                ",peri_capital,peri_mant,peri_interes,peri_seguro,peri_total,peri_saldo" +
                ",PendPeri_capital,PendPeri_mant,PendPeri_interes,PendPeri_seguro,PendPeri_total,PendPeri_saldo" +
                ",post_capital,post_mant,post_interes,post_seguro,post_total,post_saldo" +
                ",tota_capital,tota_mant,tota_interes,tota_seguro,tota_total"
                , false, false, "", "orden_negocio,numero");
        }
    }
    private static DataTable Cxc_original(DateTime Fecha, string Id_negocio, int Id_moneda, decimal Saldo_menor, decimal Saldo_mayor, DateTime Periodo_inicio, DateTime Periodo_fin, DateTime Fecha_limite_saldo0)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("proyeccionPagos_Cxc");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
        db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
        db1.AddInParameter(cmd, "saldo_menor", DbType.Decimal, Saldo_menor);
        db1.AddInParameter(cmd, "saldo_mayor", DbType.Decimal, Saldo_mayor);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];


        //int real_cuotas = 0; decimal real_capital = 0; decimal real_mant = 0; decimal real_interes = 0; decimal real_total = 0; decimal real_saldo = 0;
        int pend_cuotas = 0; decimal pend_capital = 0; decimal pend_mant = 0; decimal pend_interes = 0; decimal pend_seguro = 0; decimal pend_total = 0; decimal pend_saldo = 0;
        int peri_cuotas = 0; decimal peri_capital = 0; decimal peri_mant = 0; decimal peri_interes = 0; decimal peri_seguro = 0; decimal peri_total = 0; decimal peri_saldo = 0;
        int post_cuotas = 0; decimal post_capital = 0; decimal post_mant = 0; decimal post_interes = 0; decimal post_seguro = 0; decimal post_total = 0; decimal post_saldo = 0;
        DateTime fecha_saldo0 = DateTime.Parse("01/01/5900");
        //int tota_cuotas = 0; decimal tota_capital = 0; decimal tota_mant = 0; decimal tota_interes = 0; decimal tota_total = 0; 

        foreach (DataRow fila in tabla.Rows)
        {
            PagosRestantes((int)fila["id_contrato"], Periodo_inicio, Periodo_fin
                , (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                (int)fila["id_ultimo_pago"]
                , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]

                //, ref Num_cuotas, ref Amortizacion, ref Seguro, ref Mantenimiento_sus, ref Interes_corriente, ref Monto_pago
                , ref pend_cuotas, ref pend_capital, ref pend_mant, ref pend_interes, ref pend_seguro, ref pend_total, ref pend_saldo
                , ref peri_cuotas, ref peri_capital, ref peri_mant, ref peri_interes, ref peri_seguro, ref peri_total, ref peri_saldo
                , ref post_cuotas, ref post_capital, ref post_mant, ref post_interes, ref post_seguro, ref post_total, ref post_saldo
                , ref fecha_saldo0
                );

            fila["pend_cuotas"] = pend_cuotas;
            fila["pend_capital"] = pend_capital;
            fila["pend_mant"] = pend_mant;
            fila["pend_interes"] = pend_interes;
            fila["pend_seguro"] = pend_seguro;
            fila["pend_total"] = pend_total;
            fila["pend_saldo"] = pend_saldo;

            fila["peri_cuotas"] = peri_cuotas;
            fila["peri_capital"] = peri_capital;
            fila["peri_mant"] = peri_mant;
            fila["peri_interes"] = peri_interes;
            fila["peri_seguro"] = peri_seguro;
            fila["peri_total"] = peri_total;
            fila["peri_saldo"] = peri_saldo;

            fila["PendPeri_cuotas"] = pend_cuotas + peri_cuotas;
            fila["PendPeri_capital"] = pend_capital + peri_capital;
            fila["PendPeri_mant"] = pend_mant + peri_mant;
            fila["PendPeri_interes"] = pend_interes + peri_interes;
            fila["PendPeri_seguro"] = pend_seguro + peri_seguro;
            fila["PendPeri_total"] = pend_total + peri_total;
            fila["PendPeri_saldo"] = peri_saldo;

            fila["post_cuotas"] = post_cuotas;
            fila["post_capital"] = post_capital;
            fila["post_mant"] = post_mant;
            fila["post_interes"] = post_interes;
            fila["post_seguro"] = post_seguro;
            fila["post_total"] = post_total;
            fila["pend_saldo"] = pend_saldo;

            fila["tota_cuotas"] = (int)fila["real_cuotas"] + pend_cuotas + peri_cuotas + post_cuotas;
            fila["tota_capital"] = (decimal)fila["real_capital"] + pend_capital + peri_capital + post_capital;
            fila["tota_mant"] = (decimal)fila["real_mant"] + pend_mant + peri_mant + post_mant;
            fila["tota_interes"] = (decimal)fila["real_interes"] + pend_interes + peri_interes + post_interes;
            fila["tota_seguro"] = (decimal)fila["real_seguro"] + pend_seguro + peri_seguro + post_seguro;
            fila["tota_total"] = (decimal)fila["real_total"] + pend_total + peri_total + post_total;
            fila["fecha_saldo0"] = fecha_saldo0;
        }

        Fecha_limite_saldo0 = Fecha_limite_saldo0.Date.AddDays(1).AddSeconds(-1);
        if (Fecha_limite_saldo0 < DateTime.Parse("01/01/5900"))
        {
            int num_filas = tabla.Rows.Count;
            for (int j = num_filas - 1; j >= 0; j--)
            {
                if (((DateTime)tabla.Rows[j]["fecha_saldo0"]) > Fecha_limite_saldo0)
                {
                    tabla.Rows.RemoveAt(j);
                }
            }
        }

        return tabla;
    }

    private static void PagosRestantes(int Id_contrato, DateTime Periodo_inicio, DateTime Periodo_fin
        , decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

        , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
        , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
        , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo

        //, ref int Num_cuotas, ref decimal Amortizacion, ref decimal Seguro, ref decimal Mantenimiento_sus, ref decimal Interes_corriente, ref decimal Monto_pago,
        , ref int pend_cuotas, ref decimal pend_capital, ref decimal pend_mant, ref decimal pend_interes, ref decimal pend_seguro, ref decimal pend_total, ref decimal pend_saldo
        , ref int peri_cuotas, ref decimal peri_capital, ref decimal peri_mant, ref decimal peri_interes, ref decimal peri_seguro, ref decimal peri_total, ref decimal peri_saldo
        , ref int post_cuotas, ref decimal post_capital, ref decimal post_mant, ref decimal post_interes, ref decimal post_seguro, ref decimal post_total, ref decimal post_saldo
        , ref DateTime fecha_saldo0
        )
    {
        pend_cuotas = 0; pend_capital = 0; pend_mant = 0; pend_interes = 0; pend_seguro = 0; pend_total = 0; pend_saldo = 0;
        peri_cuotas = 0; peri_capital = 0; peri_mant = 0; peri_interes = 0; peri_seguro = 0; peri_total = 0; peri_saldo = 0;
        post_cuotas = 0; post_capital = 0; post_mant = 0; post_interes = 0; post_seguro = 0; post_total = 0; post_saldo = 0;
        fecha_saldo0 = DateTime.Parse("01/01/5900");

        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

        Periodo_inicio = Periodo_inicio.Date;
        Periodo_fin = Periodo_fin.Date.AddDays(1).AddSeconds(-1);

        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        while (pago_simulado.saldo > 0)
        {
            pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1,
                pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                pp_mantenimiento_sus, pp_interes_corriente);

            if (pago_simulado.fecha < Periodo_inicio)
            {
                pend_cuotas += 1;
                pend_capital += pago_simulado.amortizacion;
                pend_mant += pago_simulado.mantenimiento_sus;
                pend_interes += pago_simulado.interes;
                pend_seguro += pago_simulado.seguro;
                pend_total += pago_simulado.monto_pago;
                pend_saldo = pago_simulado.saldo;
            }
            else if (Periodo_inicio <= pago_simulado.fecha && pago_simulado.fecha < Periodo_fin)
            {
                peri_cuotas += 1;
                peri_capital += pago_simulado.amortizacion;
                peri_mant += pago_simulado.mantenimiento_sus;
                peri_interes += pago_simulado.interes;
                peri_seguro += pago_simulado.seguro;
                peri_total += pago_simulado.monto_pago;
                peri_saldo = pago_simulado.saldo;
            }
            else
            {
                post_cuotas += 1;
                post_capital += pago_simulado.amortizacion;
                post_mant += pago_simulado.mantenimiento_sus;
                post_interes += pago_simulado.interes;
                post_seguro += pago_simulado.seguro;
                post_total += pago_simulado.monto_pago;
                post_saldo = pago_simulado.saldo;
            }

            if (pago_simulado.saldo == 0) { fecha_saldo0 = pago_simulado.fecha; }
        }
    }



    private static DataTable CxcPagosRestantes_TablaBase()
    {
        DataTable tabla = new DataTable();
        tabla.Columns.Add("num_contrato", typeof(string));
        tabla.Columns.Add("sector", typeof(string));
        tabla.Columns.Add("tipo_cambio", typeof(decimal));
        tabla.Columns.Add("cuota", typeof(int));
        tabla.Columns.Add("fecha", typeof(DateTime));
        tabla.Columns.Add("monto", typeof(decimal));
        tabla.Columns.Add("capital", typeof(decimal));
        tabla.Columns.Add("interes", typeof(decimal));
        tabla.Columns.Add("manten", typeof(decimal));
        tabla.Columns.Add("seguro", typeof(decimal));
        tabla.Columns.Add("saldo", typeof(decimal));
        return tabla;
    }
    public static DataTable CxcPagosRestantes(DateTime Fecha, string Id_negocio, decimal Saldo_menor, decimal Saldo_mayor, DateTime Fecha_limite_saldo0, int Id_moneda, bool Consolidado)
    {
        //[num_contrato],[sector],[tipo_cambio],[cuota],[fecha],[monto],[capital],[interes],[manten],[seguro],[saldo]

        if (Consolidado == false) { return CxcPagosRestantes_original(Fecha, Id_negocio, Id_moneda, Saldo_menor, Saldo_mayor, Fecha_limite_saldo0); }
        else
        {
            string codigo_moneda = new moneda(Id_moneda).codigo;
            DataTable tabla_sus; DataTable tabla_bs;
            if (codigo_moneda == "$us")
            {
                int Id_segunda_moneda = new moneda("Bs").id_moneda;
                tabla_sus = CxcPagosRestantes_original(Fecha, Id_negocio, Id_moneda, Saldo_menor, Saldo_mayor, Fecha_limite_saldo0);
                tabla_bs = CxcPagosRestantes_original(Fecha, Id_negocio, Id_segunda_moneda, Saldo_menor, Saldo_mayor, Fecha_limite_saldo0);
            }
            else
            {
                int Id_segunda_moneda = new moneda("$us").id_moneda;
                tabla_sus = CxcPagosRestantes_original(Fecha, Id_negocio, Id_segunda_moneda, Saldo_menor, Saldo_mayor, Fecha_limite_saldo0);
                tabla_bs = CxcPagosRestantes_original(Fecha, Id_negocio, Id_moneda, Saldo_menor, Saldo_mayor, Fecha_limite_saldo0);
            }
            return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio",
                "monto,capital,interes,manten,seguro,saldo"
                , false, false, "", "num_contrato,cuota");
        }
        
    }
    private static DataTable CxcPagosRestantes_original(DateTime Fecha, string Id_negocio, int Id_moneda, decimal Saldo_menor, decimal Saldo_mayor, DateTime Fecha_limite_saldo0)
    {

        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("proyeccionPagos_Cxc");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
        db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
        db1.AddInParameter(cmd, "saldo_menor", DbType.Decimal, Saldo_menor);
        db1.AddInParameter(cmd, "saldo_mayor", DbType.Decimal, Saldo_mayor);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

        DataTable tabla_res_ori = CxcPagosRestantes_TablaBase();
        Fecha_limite_saldo0 = Fecha_limite_saldo0.Date.AddDays(1).AddSeconds(-1);

        foreach (DataRow fila in tabla.Rows)
        {
            DataTable tabla_parcial = CxcPagosRestantes_TablaBase();
            DateTime fecha_saldo0 = DateTime.Parse("01/01/5900");
            
            CxcPagosRestantes_PagosRestantes((int)fila["id_contrato"]
                , (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                (int)fila["id_ultimo_pago"]
                , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]

                , (int)fila["real_cuotas"]
                , ref tabla_parcial
                , ref fecha_saldo0
                );

            //Se verifica si se debe tomar en cuenta el contrato o no
            bool agregrar_al_resultado = true;
            if (tabla_parcial.Rows.Count > 0)
            {
                if (Fecha_limite_saldo0 < DateTime.Parse("01/01/5900") && fecha_saldo0 > Fecha_limite_saldo0)
                { agregrar_al_resultado = false; }
            }
            else { agregrar_al_resultado = false; }

            //Se adiere el resultado parcial al global
            if (agregrar_al_resultado == true)
            {
                //Se completan los datos
                foreach (DataRow filaParcial in tabla_parcial.Rows)
                {
                    filaParcial["num_contrato"] = (string)fila["numero"];
                    filaParcial["sector"] = (string)fila["sector"];
                    filaParcial["tipo_cambio"] = (decimal)fila["tipo_cambio"];
                }
                tabla_res_ori.Merge(tabla_parcial, true);
            }
        }
        return tabla_res_ori;
    }

    private static void CxcPagosRestantes_PagosRestantes(int Id_contrato
    , decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

    , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
    , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
    , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo

    , int Real_cuotas
    , ref DataTable Tabla_res_ori
    , ref DateTime fecha_saldo0
    )
    {
        fecha_saldo0 = DateTime.Parse("01/01/5900");

        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

        int num_cuotas_contador = Real_cuotas + 1;
        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        while (pago_simulado.saldo > 0)
        {
            pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1,
                pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                pp_mantenimiento_sus, pp_interes_corriente);

            DataRow fila_nueva = Tabla_res_ori.NewRow();
            fila_nueva["cuota"] = num_cuotas_contador;
            fila_nueva["fecha"] = pago_simulado.fecha;
            fila_nueva["monto"] = pago_simulado.monto_pago;
            fila_nueva["capital"] = pago_simulado.amortizacion;
            fila_nueva["interes"] = pago_simulado.interes;
            fila_nueva["manten"] = pago_simulado.mantenimiento_sus;
            fila_nueva["seguro"] = pago_simulado.seguro;
            fila_nueva["saldo"] = pago_simulado.saldo;
            Tabla_res_ori.Rows.Add(fila_nueva);

            num_cuotas_contador = num_cuotas_contador + 1;
            if (pago_simulado.saldo == 0) { fecha_saldo0 = pago_simulado.fecha; }
        }
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteProyeccionPagos" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de proyección de pagos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Fecha de corte (para la evaluación de cartera):</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" Width="100px"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha final del periodo de pagos:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_fecha_inicio" runat="server" Visible="false" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            <ew:CalendarPopup ID="cp_fecha_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Solo considerar contratos que finalizan hasta el:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_fecha_fin_pago" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            (opcional, solo si se requiere)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2" OnDataBound="cbl_negocio_DataBound"></asp:CheckBoxList>
                                            <%--[id_negocio],[codigo],[nombre],[origen]--%>
                                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">% Saldo restante:</td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txt_saldo_menor" runat="server" Text="0" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_saldo_menor" runat="server" ControlToValidate="txt_saldo_menor" Display="Dynamic" ValidationGroup="filtro" Text="*" ErrorMessage="Debe introducir el porcentaje de saldo restante"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cv_saldo_menor" runat="server" ControlToValidate="txt_saldo_menor" Display="Dynamic" ValidationGroup="filtro" Text="*"  ErrorMessage="El porcentaje de saldo debe ser un número válido" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                                                    </td>
                                                    <td>% - </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_saldo_mayor" runat="server" Text="100" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_saldo_mayor" runat="server" ControlToValidate="txt_saldo_mayor" Display="Dynamic" ValidationGroup="filtro" Text="*" ErrorMessage="Debe introducir el porcentaje de saldo restante"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cv_saldo_mayor" runat="server" ControlToValidate="txt_saldo_mayor" Display="Dynamic" ValidationGroup="filtro" Text="*"  ErrorMessage="El porcentaje de saldo debe ser un número válido" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                                                        <asp:CompareValidator ID="cv_saldo_restante" runat="server" ControlToValidate="txt_saldo_mayor" ControlToCompare="txt_saldo_menor" Display="Dynamic" ValidationGroup="filtro" Text="*"  ErrorMessage="El rango del porcentaje de saldo es incorrecto" Type="Double" Operator="GreaterThanEqual"></asp:CompareValidator>
                                                    </td>
                                                    <td>%</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Moneda:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_moneda_DataBound">
                                            </asp:RadioButtonList>
                                            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_consolidado_DataBound">
                                            </asp:RadioButtonList>
                                            <%--[valor],[texto]--%>
                                            <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList id="rbl_resumen" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Resumen (general)" Value="resumen_general" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Resumen (por sectores)" Value="resumen_sector"></asp:ListItem>
                                                <asp:ListItem Text="Detalle" Value="detalle"></asp:ListItem>
                                                <asp:ListItem Text="Pagos restantes" Value="pagos_restantes"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" OnClick="btn_mostrar_reporte_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="panel_resumen" runat="server">
                                <asp:GridView ID="gv_resumen" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField HeaderText="" DataField="tipo" />
                                        <asp:BoundField HeaderText="Capital" DataField="capital" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Interés" DataField="interes" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Manten." DataField="manten" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Total pagos" DataField="total" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>