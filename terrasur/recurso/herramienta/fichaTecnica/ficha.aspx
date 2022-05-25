<%@ Page Language="C#" MasterPageFile="~/modulo/simple.master" Title="Ficha técnica" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["id_contrato"] != null)
            {
                int id_contrato = (int)Session["id_contrato"];
                DateTime fecha = (DateTime)Session["fecha"];
                RecuperarDatos(id_contrato, fecha);
                Session.Remove("id_contrato");
                Session.Remove("fecha");
            }
            else { Page.Visible = false; }
        }
    }
    
    protected void RecuperarDatos(int id_contrato,DateTime fecha)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        
        
        string num_contrato = "";
        string titular = "";
        int num_cuotas = 0;
        decimal cuota_base = 0;
        int num_pagos = 0;
        decimal porcentaje_amortizado = 0;
        decimal superficie_m2 = 0;
        string urbanizacion = "";
        string codigo_moneda = "";
        
        //num_contrato,titular,num_cuotas,cuota_base,num_pagos,porcentaje_amortizado,superficie_m2,urbanizacion,codigo_moneda
        DbCommand cmd = db1.GetStoredProcCommand("ficha_tecnica_DatosFicha");
        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
        if (tabla.Rows.Count > 0)
        {
            num_contrato = tabla.Rows[0]["num_contrato"].ToString();
            titular = tabla.Rows[0]["titular"].ToString();
            num_cuotas = (int)tabla.Rows[0]["num_cuotas"];
            cuota_base = (decimal)tabla.Rows[0]["cuota_base"];
            num_pagos = (int)tabla.Rows[0]["num_pagos"];
            porcentaje_amortizado = (decimal)tabla.Rows[0]["porcentaje_amortizado"];
            superficie_m2 = (decimal)tabla.Rows[0]["superficie_m2"];
            urbanizacion = tabla.Rows[0]["urbanizacion"].ToString();
            codigo_moneda = tabla.Rows[0]["codigo_moneda"].ToString();
        }

        
        
        string verif_dom = "";
        string certif_lab = "";
        string avaluo_fecha = "";
        string avaluo_comercial = "";
        string avaluo_rapida = "";
        string avaluo_terreno = "";
        string avaluo_construc = "";
        string avaluo_valuador = "";
        string funcionario = "";
        string testimonio = "";
        string texto_avaluos = "";
        
        DbCommand cmd1 = db1.GetStoredProcCommand("ficha_tecnica_DatosContrato");
        db1.AddInParameter(cmd1, "id_contrato", DbType.Int32, id_contrato);
        cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla1 = db1.ExecuteDataSet(cmd1).Tables[0];
        if (tabla1.Rows.Count > 0)
        {
            verif_dom = tabla1.Rows[0]["verif_dom"].ToString();
            certif_lab = tabla1.Rows[0]["certif_lab"].ToString();
            avaluo_fecha = tabla1.Rows[0]["avaluo_fecha"].ToString();
            avaluo_comercial = tabla1.Rows[0]["avaluo_comercial"].ToString();
            avaluo_rapida = tabla1.Rows[0]["avaluo_rapida"].ToString();
            avaluo_terreno = tabla1.Rows[0]["avaluo_terreno"].ToString();
            avaluo_construc = tabla1.Rows[0]["avaluo_construc"].ToString();
            avaluo_valuador = tabla1.Rows[0]["avaluo_valuador"].ToString();
            funcionario = tabla1.Rows[0]["funcionario"].ToString();
            testimonio = tabla1.Rows[0]["testimonio"].ToString();
            texto_avaluos = tabla1.Rows[0]["texto_avaluos"].ToString();
        }

        DataTable tabla_formato_nafibo = Tabla_formato_nafibo(fecha, "," + num_contrato + ",");
        decimal num_anios = Convert.ToDecimal((int)tabla_formato_nafibo.Rows[0]["num_cuotas_pendientes"]) / 12;

        //lbl_aux.Text = "";
        //lbl_aux.Text += "num_contrato=" + num_contrato + "<br/>";
        //lbl_aux.Text += "titular=" + titular + "<br/>";
        //lbl_aux.Text += "num_cuotas=" + num_cuotas.ToString() + "<br/>";
        //lbl_aux.Text += "cuota_base=" + cuota_base.ToString() + "<br/>";
        //lbl_aux.Text += "num_pagos=" + num_pagos.ToString() + "<br/>";
        //lbl_aux.Text += "porcentaje_amortizado=" + porcentaje_amortizado.ToString() + "<br/>";
        //lbl_aux.Text += "superficie_m2=" + superficie_m2.ToString() + "<br/>";
        //lbl_aux.Text += "urbanizacion=" + urbanizacion + "<br/>";
        //lbl_aux.Text += "<br/>";
        //lbl_aux.Text += "verif_dom=" + verif_dom + "<br/>";
        //lbl_aux.Text += "certif_lab=" + certif_lab + "<br/>";
        //lbl_aux.Text += "avaluo_fecha=" + avaluo_fecha + "<br/>";
        //lbl_aux.Text += "avaluo_comercial=" + avaluo_comercial + "<br/>";
        //lbl_aux.Text += "avaluo_rapida=" + avaluo_rapida + "<br/>";
        //lbl_aux.Text += "avaluo_terreno=" + avaluo_terreno + "<br/>";
        //lbl_aux.Text += "avaluo_construc=" + avaluo_construc + "<br/>";
        //lbl_aux.Text += "avaluo_valuador=" + avaluo_valuador + "<br/>";
        //lbl_aux.Text += "funcionario=" + funcionario + "<br/>";
        //lbl_aux.Text += "<br/>";
        //lbl_aux.Text += "num_anios=" + num_anios.ToString() + "<br/>";

        fichaTecnica rep = new fichaTecnica();
        rep.CargarDatos(fecha, num_contrato, titular, num_cuotas, cuota_base, num_pagos, porcentaje_amortizado, superficie_m2, urbanizacion, verif_dom, certif_lab, avaluo_fecha, avaluo_comercial, avaluo_rapida, avaluo_terreno, avaluo_construc, avaluo_valuador, funcionario, num_anios, testimonio, texto_avaluos, codigo_moneda);
        Reporte1.WebView.Report = rep;
    }

    //public void CargarDatos(DateTime fecha, string num_contrato, string titular, int num_cuotas, decimal cuota_base,
    //int num_pagos, decimal porcentaje_amortizado, decimal superficie_m2, string urbanizacion,

    //string verif_dom, string certif_lab, string avaluo_fecha, string avaluo_comercial, string avaluo_rapida, string avaluo_terreno,
    //string avaluo_construc, string avaluo_valuador, string funcionario,

    //string testimonio, string texto_avaluos)
    //{
    //}

    
    

    protected DataTable Tabla_formato_nafibo(DateTime Fecha, string numero_contrato)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("nafibo_FormatoNafibo");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "numero_contrato", DbType.String, numero_contrato);
        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, 0);
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

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="fichaTecnica" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <%--<asp:Label ID="lbl_aux" runat="server"></asp:Label>--%>
    <uc1:reporte ID="Reporte1" runat="server" />
</asp:Content>