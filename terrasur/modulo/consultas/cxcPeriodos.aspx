<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    public static DataTable Cxc_NegocioUrbanizacion(DateTime Fecha, string Id_negocio, int Id_moneda, bool Consolidado)
    {
        //[negocio],[orden_negocio],[id_contrato],[cliente_paterno],[cliente_materno],[urbanizacion],[urbanizacion_corto],[manzano],[lote],[superficie_m2],[codigo_moneda]
        //[tipo_cambio],[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan],[id_ultimo_pago]

        //[realizado_num_cuotas],[realizado_amortizacion],[realizado_seguro],[realizado_mantenimiento],[realizado_interes],[realizado_total],
        //[restante_num_cuotas],[restante_amortizacion],[restante_seguro],[restante_mantenimiento],[restante_interes],[restante_total],
        //[total_num_cuotas],[total_precio],[total_seguro],[total_mantenimiento],[total_interes],[total_total]

        //p_fecha,p_fecha_proximo,p_num_cuotas,p_seguro,p_seguro_meses,p_seguro_fecha,p_mantenimiento_sus,p_mantenimiento_meses,p_mantenimiento_fecha,p_interes,p_interes_dias,p_interes_dias_total,p_interes_fecha,p_monto_pago,p_amortizacion,p_saldo
        //Orden:[orden_negocio],[urbanizacion],[numero]
        if (Consolidado == false) { return Cxc_Periodos_original(Fecha, Id_negocio, Id_moneda); }
        else
        {
            string codigo_moneda = new moneda(Id_moneda).codigo;
            DataTable tabla_sus; DataTable tabla_bs;
            if (codigo_moneda == "$us")
            {
                int Id_segunda_moneda = new moneda("Bs").id_moneda;
                tabla_sus = Cxc_Periodos_original(Fecha, Id_negocio, Id_moneda);
                tabla_bs = Cxc_Periodos_original(Fecha, Id_negocio, Id_segunda_moneda);
            }
            else
            {
                int Id_segunda_moneda = new moneda("$us").id_moneda;
                tabla_sus = Cxc_Periodos_original(Fecha, Id_negocio, Id_segunda_moneda);
                tabla_bs = Cxc_Periodos_original(Fecha, Id_negocio, Id_moneda);
            }

            //string str_datos = "precio_final,mantenimiento_sus,cuota_base,realizado_amortizacion,realizado_seguro,realizado_mantenimiento,realizado_interes,realizado_total,restante_amortizacion,restante_seguro,restante_mantenimiento,restante_interes,restante_total,total_precio,total_seguro,total_mantenimiento,total_interes,total_total";
            string str_datos = "precio_final,mantenimiento_sus,cuota_base";
            str_datos += ",realizado_amortizacion,realizado_seguro,realizado_mantenimiento,realizado_interes,realizado_total";
            //str_datos += ",restante_amortizacion,restante_seguro,restante_mantenimiento,restante_interes,restante_total";
            //str_datos += ",total_precio,total_seguro,total_mantenimiento,total_interes,total_total";
            str_datos += ",capital_2,interes_2,manteni_2,pagos_2";
            str_datos += ",capital_5,interes_5,manteni_5,pagos_5";
            str_datos += ",capital_7,interes_7,manteni_7,pagos_7";
            str_datos += ",capital_10,interes_10,manteni_10,pagos_10";
            str_datos += ",capital_15,interes_15,manteni_15,pagos_15";
            str_datos += ",capital_resto,interes_resto,manteni_resto,pagos_resto";
            str_datos += ",capital_total,interes_total,manteni_total,pagos_total";

            return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", str_datos, false, false, "", "orden_negocio,urbanizacion,numero");
        }
    }

    
    private static DataTable Cxc_Periodos_original(DateTime Fecha, string Id_negocio, int Id_moneda)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Cxc_NegocioUrbanizacion");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
        db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];


        tabla.Columns.Add("num_cuotas_2", typeof(int));
        tabla.Columns.Add("capital_2", typeof(decimal));
        tabla.Columns.Add("interes_2", typeof(decimal));
        tabla.Columns.Add("manteni_2", typeof(decimal));
        tabla.Columns.Add("pagos_2", typeof(decimal));

        tabla.Columns.Add("num_cuotas_5", typeof(int));
        tabla.Columns.Add("capital_5", typeof(decimal));
        tabla.Columns.Add("interes_5", typeof(decimal));
        tabla.Columns.Add("manteni_5", typeof(decimal));
        tabla.Columns.Add("pagos_5", typeof(decimal));

        tabla.Columns.Add("num_cuotas_7", typeof(int));
        tabla.Columns.Add("capital_7", typeof(decimal));
        tabla.Columns.Add("interes_7", typeof(decimal));
        tabla.Columns.Add("manteni_7", typeof(decimal));
        tabla.Columns.Add("pagos_7", typeof(decimal));

        tabla.Columns.Add("num_cuotas_10", typeof(int));
        tabla.Columns.Add("capital_10", typeof(decimal));
        tabla.Columns.Add("interes_10", typeof(decimal));
        tabla.Columns.Add("manteni_10", typeof(decimal));
        tabla.Columns.Add("pagos_10", typeof(decimal));

        tabla.Columns.Add("num_cuotas_15", typeof(int));
        tabla.Columns.Add("capital_15", typeof(decimal));
        tabla.Columns.Add("interes_15", typeof(decimal));
        tabla.Columns.Add("manteni_15", typeof(decimal));
        tabla.Columns.Add("pagos_15", typeof(decimal));

        tabla.Columns.Add("num_cuotas_resto", typeof(int));
        tabla.Columns.Add("capital_resto", typeof(decimal));
        tabla.Columns.Add("interes_resto", typeof(decimal));
        tabla.Columns.Add("manteni_resto", typeof(decimal));
        tabla.Columns.Add("pagos_resto", typeof(decimal));

        tabla.Columns.Add("num_cuotas_total", typeof(int));
        tabla.Columns.Add("capital_total", typeof(decimal));
        tabla.Columns.Add("interes_total", typeof(decimal));
        tabla.Columns.Add("manteni_total", typeof(decimal));
        tabla.Columns.Add("pagos_total", typeof(decimal));

        int num_cuotas_2 = 0; decimal capital_2 = 0; decimal interes_2 = 0; decimal manteni_2 = 0; decimal pagos_2 = 0;
        int num_cuotas_5 = 0; decimal capital_5 = 0; decimal interes_5 = 0; decimal manteni_5 = 0; decimal pagos_5 = 0;
        int num_cuotas_7 = 0; decimal capital_7 = 0; decimal interes_7 = 0; decimal manteni_7 = 0; decimal pagos_7 = 0;
        int num_cuotas_10 = 0; decimal capital_10 = 0; decimal interes_10 = 0; decimal manteni_10 = 0; decimal pagos_10 = 0;
        int num_cuotas_15 = 0; decimal capital_15 = 0; decimal interes_15 = 0; decimal manteni_15 = 0; decimal pagos_15 = 0;
        int num_cuotas_resto = 0; decimal capital_resto = 0; decimal interes_resto = 0; decimal manteni_resto = 0; decimal pagos_resto = 0;
        int num_cuotas_total = 0; decimal capital_total = 0; decimal interes_total = 0; decimal manteni_total = 0; decimal pagos_total = 0;

        
        foreach (DataRow fila in tabla.Rows)
        {
            PagosRestantes((int)fila["id_contrato"], Fecha, 
                ref num_cuotas_2, ref capital_2, ref interes_2, ref manteni_2, ref pagos_2,
                ref num_cuotas_5, ref capital_5, ref interes_5, ref manteni_5, ref pagos_5,
                ref num_cuotas_7, ref capital_7, ref interes_7, ref manteni_7, ref pagos_7,
                ref num_cuotas_10, ref capital_10, ref interes_10, ref manteni_10, ref pagos_10,
                ref num_cuotas_15, ref capital_15, ref interes_15, ref manteni_15, ref pagos_15,
                ref num_cuotas_resto, ref capital_resto, ref interes_resto, ref manteni_resto, ref pagos_resto,
                ref num_cuotas_total, ref capital_total, ref interes_total, ref manteni_total, ref pagos_total,

                (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                (int)fila["id_ultimo_pago"]
                , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

            fila["num_cuotas_2"] = num_cuotas_2;
            fila["capital_2"] = capital_2;
            fila["interes_2"] = interes_2;
            fila["manteni_2"] = manteni_2;
            fila["pagos_2"] = pagos_2;

            fila["num_cuotas_5"] = num_cuotas_5;
            fila["capital_5"] = capital_5;
            fila["interes_5"] = interes_5;
            fila["manteni_5"] = manteni_5;
            fila["pagos_5"] = pagos_5;

            fila["num_cuotas_7"] = num_cuotas_7;
            fila["capital_7"] = capital_7;
            fila["interes_7"] = interes_7;
            fila["manteni_7"] = manteni_7;
            fila["pagos_7"] = pagos_7;

            fila["num_cuotas_10"] = num_cuotas_10;
            fila["capital_10"] = capital_10;
            fila["interes_10"] = interes_10;
            fila["manteni_10"] = manteni_10;
            fila["pagos_10"] = pagos_10;

            fila["num_cuotas_15"] = num_cuotas_15;
            fila["capital_15"] = capital_15;
            fila["interes_15"] = interes_15;
            fila["manteni_15"] = manteni_15;
            fila["pagos_15"] = pagos_15;

            fila["num_cuotas_resto"] = num_cuotas_resto;
            fila["capital_resto"] = capital_resto;
            fila["interes_resto"] = interes_resto;
            fila["manteni_resto"] = manteni_resto;
            fila["pagos_resto"] = pagos_resto;

            //fila["num_cuotas_total"] = ((int)fila["realizado_num_cuotas"]) + num_cuotas_total;
            //fila["capital_total"] = ((decimal)fila["realizado_amortizacion"]) + capital_total;
            //fila["interes_total"] = ((decimal)fila["realizado_interes"]) + interes_total;
            //fila["manteni_total"] = ((decimal)fila["realizado_mantenimiento"]) + manteni_total;
            //fila["pagos_total"] = ((decimal)fila["realizado_total"]) + pagos_total;

            fila["num_cuotas_total"] = num_cuotas_total;
            fila["capital_total"] = capital_total;
            fila["interes_total"] = interes_total;
            fila["manteni_total"] = manteni_total;
            fila["pagos_total"] = pagos_total;

        }
        return tabla;
    }

    public static void PagosRestantes(int Id_contrato, DateTime Fecha,
        ref int num_cuotas_2, ref decimal capital_2, ref decimal interes_2, ref decimal manteni_2, ref decimal pagos_2,
        ref int num_cuotas_5, ref decimal capital_5, ref decimal interes_5, ref decimal manteni_5, ref decimal pagos_5,
        ref int num_cuotas_7, ref decimal capital_7, ref decimal interes_7, ref decimal manteni_7, ref decimal pagos_7,
        ref int num_cuotas_10, ref decimal capital_10, ref decimal interes_10, ref decimal manteni_10, ref decimal pagos_10,
        ref int num_cuotas_15, ref decimal capital_15, ref decimal interes_15, ref decimal manteni_15, ref decimal pagos_15,
        ref int num_cuotas_resto, ref decimal capital_resto, ref decimal interes_resto, ref decimal manteni_resto, ref decimal pagos_resto,
        ref int num_cuotas_total, ref decimal capital_total, ref decimal interes_total, ref decimal manteni_total, ref decimal pagos_total,

    decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

    , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
    , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
    , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
    {
        num_cuotas_2 = 0; capital_2 = 0; interes_2 = 0; manteni_2 = 0; pagos_2 = 0;
        num_cuotas_5 = 0; capital_5 = 0; interes_5 = 0; manteni_5 = 0; pagos_5 = 0;
        num_cuotas_7 = 0; capital_7 = 0; interes_7 = 0; manteni_7 = 0; pagos_7 = 0;
        num_cuotas_10 = 0; capital_10 = 0; interes_10 = 0; manteni_10 = 0; pagos_10 = 0;
        num_cuotas_15 = 0; capital_15 = 0; interes_15 = 0; manteni_15 = 0; pagos_15 = 0;
        num_cuotas_resto = 0; capital_resto = 0; interes_resto = 0; manteni_resto = 0; pagos_resto = 0;
        num_cuotas_total = 0; capital_total = 0; interes_total = 0; manteni_total = 0; pagos_total = 0;
        
        //sim_pago pago_simulado = new sim_pago(Id_ultimo_pago);
        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

        DateTime Fecha_corte = Fecha.Date.AddDays(1);
        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        while (pago_simulado.saldo > 0)
        {
            pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1,
                pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                pp_mantenimiento_sus, pp_interes_corriente);

            if (pago_simulado.fecha < Fecha_corte.AddYears(2))
            {
                num_cuotas_2 += 1;
                capital_2 += pago_simulado.amortizacion;
                interes_2 += pago_simulado.interes;
                manteni_2 += pago_simulado.mantenimiento_sus;
                pagos_2 += pago_simulado.monto_pago;
            }
            else if (Fecha_corte.AddYears(2) <= pago_simulado.fecha
                && pago_simulado.fecha < Fecha_corte.AddYears(5))
            {
                num_cuotas_5 += 1;
                capital_5 += pago_simulado.amortizacion;
                interes_5 += pago_simulado.interes;
                manteni_5 += pago_simulado.mantenimiento_sus;
                pagos_5 += pago_simulado.monto_pago;
            }
            else if (Fecha_corte.AddYears(5) <= pago_simulado.fecha
                && pago_simulado.fecha < Fecha_corte.AddYears(7))
            {
                num_cuotas_7 += 1;
                capital_7 += pago_simulado.amortizacion;
                interes_7 += pago_simulado.interes;
                manteni_7 += pago_simulado.mantenimiento_sus;
                pagos_7 += pago_simulado.monto_pago;
            }
            else if (Fecha_corte.AddYears(7) <= pago_simulado.fecha
                && pago_simulado.fecha < Fecha_corte.AddYears(10))
            {
                num_cuotas_10 += 1;
                capital_10 += pago_simulado.amortizacion;
                interes_10 += pago_simulado.interes;
                manteni_10 += pago_simulado.mantenimiento_sus;
                pagos_10 += pago_simulado.monto_pago;
            }

            else if (Fecha_corte.AddYears(10) <= pago_simulado.fecha
                && pago_simulado.fecha < Fecha_corte.AddYears(15))
            {
                num_cuotas_15 += 1;
                capital_15 += pago_simulado.amortizacion;
                interes_15 += pago_simulado.interes;
                manteni_15 += pago_simulado.mantenimiento_sus;
                pagos_15 += pago_simulado.monto_pago;
            }
            else
            {
                num_cuotas_resto += 1;
                capital_resto += pago_simulado.amortizacion;
                interes_resto += pago_simulado.interes;
                manteni_resto += pago_simulado.mantenimiento_sus;
                pagos_resto += pago_simulado.monto_pago;
            }

            num_cuotas_total += 1;
            capital_total += pago_simulado.amortizacion;
            interes_total += pago_simulado.interes;
            manteni_total += pago_simulado.mantenimiento_sus;
            pagos_total += pago_simulado.monto_pago;

            //,capital_total,interes_total,manteni_total,pagos_total";
            
            //Num_cuotas += 1;
            //Amortizacion += pago_simulado.amortizacion;
            //Seguro += pago_simulado.seguro;
            //Mantenimiento_sus += pago_simulado.mantenimiento_sus;
            //Interes_corriente += pago_simulado.interes;
            //Monto_pago += pago_simulado.monto_pago;
        }
    }

    

    protected void btn_mostrar_reporte_Click(object sender, EventArgs e)
    {
        DataTable tabla_res = Cxc_NegocioUrbanizacion(cp_fecha.SelectedDate, general.StringNegocios(true, cbl_negocio.Items), int.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.ToLower().Equals("true"));
        string str_datos = "numero,precio_final";
        str_datos += ",realizado_amortizacion,realizado_interes,realizado_mantenimiento,realizado_total";
        //str_datos += ",restante_amortizacion,restante_seguro,restante_mantenimiento,restante_interes,restante_total";
        //str_datos += ",total_precio,total_seguro,total_mantenimiento,total_interes,total_total";
        str_datos += ",capital_2,interes_2,manteni_2,pagos_2";
        str_datos += ",capital_5,interes_5,manteni_5,pagos_5";
        str_datos += ",capital_7,interes_7,manteni_7,pagos_7";
        str_datos += ",capital_10,interes_10,manteni_10,pagos_10";
        str_datos += ",capital_15,interes_15,manteni_15,pagos_15";
        str_datos += ",capital_resto,interes_resto,manteni_resto,pagos_resto";
        str_datos += ",capital_total,interes_total,manteni_total,pagos_total";

        for (int j = tabla_res.Columns.Count - 1; j >= 0; j--)
        {
            if (("," + str_datos + ",").Contains("," + tabla_res.Columns[j].ColumnName + ",") == false)
            {
                tabla_res.Columns.RemoveAt(j);
            }
        }

        
        
        
        
        
        
        
        //Se crea el gridview y se cargan sus datos
        GridView gv = new GridView();
        gv.DataSource = tabla_res;
        gv.DataBind();

        //gv.Attributes.CssStyle.Add("font-size", "9px");
        //gv.Attributes.CssStyle.Add("font-family", "Arial");

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
        Response.AddHeader("Content-Disposition", "attachment;filename=" + "cxc_periodos" + ".xls");
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
        <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
            <table class="formEntTable">
                <tr>
                    <td class="formEntTdForm">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">A la fecha:</td>
                                <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" Width="100px"></ew:CalendarPopup></td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                    <%--[id_negocio],[codigo],[nombre],[origen]--%>
                                    <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server" Text="Datos contemplados:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[valor],[texto]--%>
                                    <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                    </asp:ObjectDataSource>
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

    </div>
    </form>
</body>
</html>
