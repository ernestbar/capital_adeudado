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
        DataTable tabla_resultado = lista_resultados();
        string columnas = "contrato,cuota,fecha,monto,interes,capital,saldo,estado";
        Hashtable hashtable = Obtenerhash();
        ExportarExcel(ref tabla_resultado, columnas, "PlanesDePagoNafibo", hashtable);
    }

    public DataTable lista_resultados()
    {
        DataTable tabla_resultado = new DataTable();
        tabla_resultado.Columns.Add("contrato", typeof(string));
        tabla_resultado.Columns.Add("cuota", typeof(string));
        tabla_resultado.Columns.Add("fecha", typeof(string));
        tabla_resultado.Columns.Add("monto", typeof(string));
        tabla_resultado.Columns.Add("interes", typeof(string));
        tabla_resultado.Columns.Add("capital", typeof(string));
        tabla_resultado.Columns.Add("saldo", typeof(string));
        tabla_resultado.Columns.Add("estado", typeof(string));

        string num_contrato = "";
        int num_pagos_anteriores = 0;
        DateTime trans_fecha = DateTime.Now;
        DateTime reco_fecha = DateTime.Now;

        DataTable tabla_contratos = lista_contratos();

        foreach (DataRow fila_contratos in tabla_contratos.Rows)
        {
            num_contrato = (string)fila_contratos["numero"];
            trans_fecha = (DateTime)fila_contratos["trans_fecha"];
            reco_fecha = (DateTime)fila_contratos["reco_fecha"];
            num_pagos_anteriores = (int)fila_contratos["num_pagos_anteriores"];

            ReportePlanPagosVigente_SimularPagos(
                ref tabla_resultado,
                num_contrato, num_pagos_anteriores, reco_fecha

                , (DateTime)fila_contratos["fecha"]
                , (DateTime)fila_contratos["fecha_proximo"]
                , (int)fila_contratos["num_cuotas"]
                , (decimal)fila_contratos["seguro"]
                , (int)fila_contratos["seguro_meses"]
                , (DateTime)fila_contratos["seguro_fecha"]
                , (decimal)fila_contratos["mantenimiento_sus"]
                , (int)fila_contratos["mantenimiento_meses"]
                , (DateTime)fila_contratos["mantenimiento_fecha"]
                , (decimal)fila_contratos["interes"]
                , (int)fila_contratos["interes_dias"]
                , (int)fila_contratos["interes_dias_total"]
                , (DateTime)fila_contratos["interes_fecha"]
                , (decimal)fila_contratos["monto_pago"]
                , (decimal)fila_contratos["amortizacion"]
                , (decimal)fila_contratos["saldo"]

                , (decimal)fila_contratos["pp_cuota_base"]
                , (DateTime)fila_contratos["pp_fecha_inicio_plan"]
                , (decimal)fila_contratos["pp_seguro"]
                , (decimal)fila_contratos["pp_mantenimiento_sus"]
                , (decimal)fila_contratos["pp_interes_corriente"]
            );
        }

        return tabla_resultado;
    }


    protected static void ReportePlanPagosVigente_SimularPagos(
        ref DataTable Tabla_res,
        string Num_contrato,int Num_pagos_anteriores, DateTime Reco_fecha,

        DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha,
        decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes,
        int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo,

        decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, decimal pp_seguro, decimal pp_mantenimiento_sus, decimal pp_interes_corriente
    )
    {
        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

        int contador_pagos=Num_pagos_anteriores;
        DateTime Fecha_recompra= Reco_fecha.Date.AddDays(1).AddSeconds(-1);
        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        while (pago_simulado.saldo > 0)
        {
            pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);
            contador_pagos = contador_pagos + 1;

            DataRow fila_pago = Tabla_res.NewRow();
            fila_pago["contrato"] = Num_contrato;
            fila_pago["cuota"] = contador_pagos.ToString();
            fila_pago["fecha"] = pago_simulado.fecha.ToString("d");
            fila_pago["monto"] = pago_simulado.monto_pago.ToString("F2");//.Replace(',', '.');
            fila_pago["interes"] = pago_simulado.interes.ToString("F2");//.Replace(',', '.');
            fila_pago["capital"] = pago_simulado.amortizacion.ToString("F2");//.Replace(',', '.');
            fila_pago["saldo"] = pago_simulado.saldo.ToString("F2");//.Replace(',', '.');
            if (pago_simulado.fecha <= Fecha_recompra) { fila_pago["estado"] = "Nafi"; }
            else { fila_pago["estado"] = "Terr"; }
            Tabla_res.Rows.Add(fila_pago);
        }
    }
   
    public DataTable lista_contratos()
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("nafiboPlanesOriginalesTodos");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }



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

        foreach (DataColumn c in tabla.Columns) { c.ColumnName = hashtable[c.ColumnName].ToString(); }

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

    protected Hashtable Obtenerhash()
    {
        Hashtable hashtable = new Hashtable();
        hashtable["contrato"] = "Nro.Ctto.";
        hashtable["cuota"] = "Cuota";
        hashtable["fecha"] = "Fecha";
        hashtable["monto"] = "Monto";
        hashtable["interes"] = "Interés";
        hashtable["capital"] = "Capital";
        hashtable["saldo"] = "Saldo";
        hashtable["estado"] = "Obs.";
        return hashtable;
    }
    
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_obtener" runat="server" Text="Obtener" OnClick="btn_obtener_Click" />
    </div>
    </form>
</body>
</html>
