<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data" %>

<%@ Register src="~/recurso/contabilidad/reporteContabilidad/userControl/reporteCarteraVigente.ascx" tagname="reporteCarteraVigente" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            //if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraRangos") == true)
            //{
            //    //Session.Add("codigo_rol", "director");
            //    //Session.Add("id_usuario", 78);
            //    //Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotorEleccion.aspx");

            //    int current_id_rol = Profile.entorno.id_rol;
            //    if (current_id_rol == 10 || current_id_rol == 11)
            //    {
            //        if (current_id_rol == 10) { Session.Add("codigo_rol", "promotor"); }
            //        else if (current_id_rol == 11) { Session.Add("codigo_rol", "director"); }
            //        Session.Add("id_usuario", Profile.id_usuario);
            //        Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotorEleccion.aspx");
            //    }
            //}
            //else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    public void cargarReporte()
    {
        DateTime Fecha = cp_fecha.SelectedDate;
        int Id_grupoventa = int.Parse(ddl_grupoventa.SelectedValue);
        string Grupo_encabezado = ddl_grupoventa.SelectedItem.Text;
        string Id_negocio = general.StringNegocios(true, cbl_negocio.Items);
        string Id_negocio_encabezado = general.StringNegocios(false, cbl_negocio.Items);
        int Id_moneda = int.Parse(rbl_moneda.SelectedValue);
        bool Consolidado = rbl_consolidado.SelectedValue.Equals("True");
        string Codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        decimal porcentaje_costo_oportunidad = 8;
        string col_grupo = rbl_grupo_original_actual.SelectedValue;
        string col_grupo_encabezado = rbl_grupo_original_actual.SelectedItem.Text;

        DataTable tabla = reportesRetraso.CarteraVigente3(Fecha, Id_grupoventa, col_grupo, 0, Id_negocio, Id_moneda, Consolidado);
        if (tabla.Rows.Count > 0)
        {
            lbl_mensaje.Text = "";
            DataTable tabla_resultado = reportesRetraso.resumen_grupos_promotores_rangos(tabla, col_grupo, "grupo,promotor,rango,num_dias_retraso", cb_con_contratos_al_dia.Checked, cb_con_retraso_1_a_30.Checked, cb_con_contratos_especiales.Checked);
            //string columnas = "numero_contrato,negocio,grupo,promotor,promotor_corto,fecha_registro,fecha_ultimo_pago,interes_fecha,fecha_proximo,interes_corriente,num_cuotas,cuota_base,precio_final,total_amortizacion,total_aporte,saldo,codigo_moneda,num_dias_retraso,especial,rango,num_cuotas_adeuda,monto_adeuda,lote,cliente_nombre,cliente_telefono";
            string columnas = "numero_contrato,negocio,grupo,promotor,promotor_corto,fecha_registro,fecha_ultimo_pago,interes_fecha,fecha_proximo,interes_corriente,num_cuotas,cuota_base,precio_final,total_amortizacion,total_aporte,saldo,codigo_moneda,num_dias_retraso,especial,rango,num_cuotas_adeuda,monto_adeuda,lote,cliente_nombre,cliente_telefono";
            Hashtable hashtable = Obtenerhash();
            ExportarExcel(ref tabla_resultado, columnas, "CarteraVigente", hashtable);
        }
        else
        {
            lbl_mensaje.Text = "No se encontraron contratos según los parámetros elegidos";
        }
    }

    protected void btn_mostrar_Click(object sender, EventArgs e) { cargarReporte(); }
    protected void cbl_negocio_DataBound(object sender, EventArgs e) { string casas_edif = ConfigurationManager.AppSettings["negocios_casas"]; foreach (ListItem item in cbl_negocio.Items) { item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(false); } }
    protected void rbl_moneda_DataBound(object sender, EventArgs e) { if (rbl_moneda.Items.Count > 0) { rbl_moneda.SelectedIndex = 0; } }
    protected void rbl_consolidado_DataBound(object sender, EventArgs e) { if (rbl_consolidado.Items.Count > 1) { rbl_consolidado.SelectedIndex = 1; } lbl_consolidado_enun.Text = "Datos contemplados:"; }
    protected void ddl_grupoventa_DataBound(object sender, EventArgs e) { ddl_grupoventa.Items.Insert(0, new ListItem("Todos", "0")); }



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
        string codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        
        Hashtable hashtable = new Hashtable();
        hashtable["numero_contrato"] = "Nº ctto.";
        hashtable["negocio"] = "Negocio";
        hashtable["grupo"] = "grupo";
        hashtable["promotor"] = "Promotor";
        hashtable["promotor_corto"] = "Promotor(corto)";
        hashtable["fecha_registro"] = "F.Registro";
        hashtable["fecha_ultimo_pago"] = "F.Ult.Pago";
        hashtable["interes_fecha"] = "F.Interés";
        hashtable["fecha_proximo"] = "F.Prox.Pago";
        hashtable["interes_corriente"] = "% int.";
        hashtable["num_cuotas"] = "Nº cuo.";
        hashtable["cuota_base"] = "Cuo.Mensual (" + codigo_moneda + ")";
        hashtable["precio_final"] = "Precio (" + codigo_moneda + ")";
        hashtable["total_amortizacion"] = "Capital aportado (" + codigo_moneda + ")";
        hashtable["total_aporte"] = "Total aportado (" + codigo_moneda + ")";
        hashtable["saldo"] = "Saldo (" + codigo_moneda + ")";
        hashtable["codigo_moneda"] = "Moneda";
        hashtable["num_dias_retraso"] = "Nº dias retraso";
        hashtable["especial"] = "Especial";
        hashtable["rango"] = "Rango de retraso";
        hashtable["num_cuotas_adeuda"] = "Nº cuo. adeuda";
        hashtable["monto_adeuda"] = "Monto que adeuda (" + codigo_moneda + ")";
        hashtable["lote"] = "Lote";
        hashtable["cliente_nombre"] = "Cliente (nombre)";
        hashtable["cliente_telefono"] = "Cliente (fono.)";
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
        <table align="center">
            <tr>
                <td class="tdFiltro">
                    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="formTdEnun">A la fecha:</td>
                            <td class="formTdDato">
                                <ew:CalendarPopup ID="cp_fecha" runat="server">
                                </ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Grupo de venta:</td>
                            <td class="formTdDato">
                                <asp:DropDownList ID="ddl_grupoventa" runat="server" AutoPostBack="true" DataSourceID="ods_lista_grupoventa" DataValueField="id_grupoventa" DataTextField="nombre" OnDataBound="ddl_grupoventa_DataBound">
                                </asp:DropDownList>
                                <%--[id_grupoventa],[nombre]--%>
                                <asp:ObjectDataSource ID="ods_lista_grupoventa" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="ListaActivoOConVentas">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Contratos asocidos al:</td>
                            <td class="formTdDato">
                                <asp:RadioButtonList ID="rbl_grupo_original_actual" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Text="Grupo original de la venta" Value="grupo" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Grupo actual del promotor" Value="grupo_actual"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Negocio:</td>
                            <td class="formTdDato">
                                <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2" OnDataBound="cbl_negocio_DataBound"></asp:CheckBoxList>
                                <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                </asp:ObjectDataSource>
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
                            <td class="formTdEnun">Cartera Vigente por PROMOTOR:</td>
                            <td class="formTdDato">
                                <asp:CheckBox ID="cb_con_contratos_al_dia" runat="server" Text="Con contratos al día" Checked="false" />
                                <asp:CheckBox ID="cb_con_retraso_1_a_30" runat="server" Text="Con contratos de 1 a 30 días" Checked="true" />
                                <asp:CheckBox ID="cb_con_contratos_especiales" runat="server" Text="Con contratos especiales" Checked="false" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton" colspan="2">
                                <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" ValidationGroup="filtro" OnClick="btn_mostrar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lbl_mensaje" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
