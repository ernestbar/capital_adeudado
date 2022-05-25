<%@ Control Language="C#" ClassName="datosPreliminaresBNB" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">

    public void Cargar()
    {
        txt_contratos.Text = "";
        cp_fecha.SelectedDate = DateTime.Now;
        btn_obtener1.Visible = true;
        panel_verificacion.Visible = false;
        btn_obtener2.Visible = false;
        btn_cancelar.Visible = false;

        lb_datos.Visible = false;
        lb_formato1.Visible = false;
        lb_formato2.Visible = false;
    }    
    
    protected void btn_obtener1_Click(object sender, EventArgs e)
    {
        int num_total = 0; int num_error = 0; int num_alerta = 0;
        System.Data.DataTable tabla = infoBNB.VerificacionContratos(txt_contratos.Text.Trim(), cp_fecha.SelectedDate, ref num_total, ref num_error, ref num_alerta);
        if ((num_error + num_alerta) > 0)
        {
            lbl_verificacion.Text = "Error(es): " + num_error.ToString() + " ; Alerta(s): " + num_alerta.ToString();
            gv_verificacion.DataSource = tabla;
            gv_verificacion.DataBind();

            btn_obtener1.Visible = false;
            panel_verificacion.Visible = true;
            btn_obtener2.Visible = num_error.Equals(0);
            btn_cancelar.Visible = true;

            lb_datos.Visible = false;
            lb_formato1.Visible = false;
            lb_formato2.Visible = false;
        }
        else { ObtenerDatos(); }
    }

    protected void btn_obtener2_Click(object sender, EventArgs e)
    {
        ObtenerDatos();
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        btn_obtener1.Visible = true;
        panel_verificacion.Visible = false;
        btn_obtener2.Visible = false;
        btn_cancelar.Visible = false;

        lb_datos.Visible = false;
        lb_formato1.Visible = false;
        lb_formato2.Visible = false;
    }

    protected void gv_verificacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (int.Parse(DataBinder.Eval(e.Row.DataItem, "error").ToString()) == 1) { e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF7D7D"); }
            else if (int.Parse(DataBinder.Eval(e.Row.DataItem, "alerta").ToString()) == 1) { e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFDB79"); }
        }
    }

    protected void ObtenerDatos()
    {
        //lb_datos.Visible = true;
        //lb_formato1.Visible = true;
        //lb_formato2.Visible = true;

        GenerarArchivo();
    }

    protected void lb_formato1_Click(object sender, EventArgs e) { }

    protected void lb_formato2_Click(object sender, EventArgs e) { }

    protected void lb_datos_Click(object sender, EventArgs e)
    {
        GenerarArchivo();
    }

    protected void GenerarArchivo()
    {
        Hashtable hashtable = new Hashtable();
        hashtable["grupo"] = "Grupo de Ventas";
        hashtable["director"] = "Director del grupo";
        hashtable["promotor"] = "Promotor";
        hashtable["num_contrato"] = "Nº contrato";
        hashtable["fecha_registro"] = "F.Registro";
        hashtable["negocio"] = "Negocio";
        hashtable["loc"] = "Loc.";
        hashtable["urb"] = "Sector";
        hashtable["mzno"] = "Mzno.";
        hashtable["lote"] = "Lote";
        hashtable["paterno"] = "Apellido Paterno";
        hashtable["materno"] = "Apellido Materno";
        hashtable["nombres"] = "Nombres";
        hashtable["ci"] = "C.I.";
        hashtable["nit"] = "NIT";
        hashtable["celular"] = "Celular";
        hashtable["fax"] = "Fax";
        hashtable["email"] = "Email";
        hashtable["casilla"] = "Casilla";
        hashtable["domicilio_direccion"] = "Dirección (Domicilio)";
        hashtable["domicilio_fono"] = "Fono (Domic.)";
        hashtable["domicilio_zona"] = "Zona (Domicilio)";
        hashtable["oficina_direccion"] = "Dirección (Oficina)";
        hashtable["oficina_fono"] = "Fono (Ofi.)";
        hashtable["oficina_zona"] = "Zona (Oficina)";
        hashtable["precio"] = "Valor Orig. ($us)";
        hashtable["descuento_porcentaje"] = "Desc.(%)";
        hashtable["descuento_efectivo"] = "Desc.($us)";
        hashtable["precio_final"] = "Valor final ($us)";
        hashtable["cuota_inicial"] = "Cuota Inicial ($us)";
        hashtable["interes_corriente"] = "Interés";
        hashtable["num_cuotas"] = "Nº cuo";
        hashtable["cuota_base"] = "Cuota mensual ($us)";
        hashtable["fecha_inicio_plan"] = "F.Ini.Plan";
        hashtable["fecha_ultimo_pago"] = "F.Ult.pago";
        hashtable["interes_fecha"] = "F. Interés";
        hashtable["fecha_proximo"] = "F.Prox. Pago";
        hashtable["valor_final"] = "Valor final lote ($us)";
        hashtable["aporte_total"] = "Total aport. ($us)";
        hashtable["aporte_interes"] = "Aporte inte. ($us)";
        hashtable["aporte_capital"] = "Aporte amortiz. ($us)";
        hashtable["saldo"] = "Saldo ($us)";
        hashtable["cuotas_num_total"] = "Total cuotas";
        hashtable["cuotas_num_anteriores"] = "Cuotas Pagadas";
        hashtable["cuotas_num_restantes"] = "Cuotas Restantes";

        System.Data.DataTable tabla = infoBNB.ListaDatos1(txt_contratos.Text.Trim(), cp_fecha.SelectedDate, int.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("true"));
        string columnas = "grupo,director,promotor,num_contrato,fecha_registro,negocio,loc,urb,mzno,lote,paterno,materno,nombres,ci,nit,celular,fax,email,casilla,domicilio_direccion,domicilio_fono,domicilio_zona,oficina_direccion,oficina_fono,oficina_zona,precio,descuento_porcentaje,descuento_efectivo,precio_final,cuota_inicial,interes_corriente,num_cuotas,cuota_base,fecha_inicio_plan,fecha_ultimo_pago,interes_fecha,fecha_proximo,valor_final,aporte_total,aporte_interes,aporte_capital,saldo,cuotas_num_total,cuotas_num_anteriores,cuotas_num_restantes";
        string nombre_archivo = "BBR_cttos_" + tabla.Rows.Count.ToString() + "_al_" + cp_fecha.SelectedDate.ToString("d").Replace("/", "-") + "_datos";
        ExportarExcel(ref tabla, columnas, nombre_archivo, hashtable);
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

        ////Se renombran los encabezados del gridview
        //for (int j = 0; j < gv.Columns.Count; j++) { gv.Columns[j].HeaderText = hashtable[gv.Columns[j].HeaderText].ToString(); }

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

    protected void rbl_moneda_DataBound(object sender, EventArgs e) { if (rbl_moneda.Items.Count > 0) { rbl_moneda.SelectedIndex = 0; } }
    protected void rbl_consolidado_DataBound(object sender, EventArgs e) { if (rbl_consolidado.Items.Count > 1) { rbl_consolidado.SelectedIndex = 1; } }

</script>
<table width="100%">
    <tr>
        <td>
            <table align="center">
                <tr>
                    <td class="formTdEnun">Contrato(s):</td>
                    <td class="formTdDato">
                        <asp:TextBox ID="txt_contratos" runat="server" TextMode="MultiLine" SkinID="txtMultiLine400x4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Fecha:</td>
                    <td class="formTdDato">
                        <ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup>
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
                    <td class="formTdEnun">Datos contemplados:</td>
                    <td class="formTdDato">
                        <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_consolidado_DataBound">
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
        <td align="center">
            <asp:Button ID="btn_obtener1" runat="server" Text="Obtener datos" OnClick="btn_obtener1_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td>
                        <asp:Panel ID="panel_verificacion" runat="server" Visible="false" GroupingText="Errores / Alertas" ScrollBars="Vertical" Height="200">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lbl_verificacion" runat="server" SkinID="lblEnun"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv_verificacion" runat="server" AutoGenerateColumns="false" OnRowDataBound="gv_verificacion_RowDataBound">
                                            <Columns>
                                                <asp:BoundField HeaderText="" DataField="error_alerta" ItemStyle-Font-Bold="true" />
                                                <asp:BoundField HeaderText="Nº ctto." DataField="num_contrato" ItemStyle-Font-Bold="true" ItemStyle-CssClass="gvCell1" />
                                                <asp:BoundField HeaderText="Estado" DataField="estado_nombre" />
                                                <asp:BoundField HeaderText="Negocio" DataField="negocio_nombre" />
                                                <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                                <asp:BoundField HeaderText="Moneda" DataField="moneda" />
                                                <asp:TemplateField HeaderText="Descrición del Error / Alerta">
                                                    <ItemTemplate>
                                                        <div style="width:480px;">
                                                            <asp:Label ID="lbl_descripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <%--[id_contrato],[num_contrato],[moneda],[estado_nombre],[negocio_nombre],[saldo], [error],[alerta],[error_alerta],[descripcion]--%>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btn_obtener2" runat="server" Visible="false" Text="Obtener (confirmado)" OnClick="btn_obtener2_Click" />
            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <table align="center">
                <tr>
                    <td align="left"><asp:LinkButton ID="lb_datos" runat="server" Text="Archivo de datos" OnClick="lb_datos_Click"></asp:LinkButton></td>
                    <td align="left"><asp:LinkButton ID="lb_formato1" runat="server" OnClick="lb_formato1_Click"></asp:LinkButton></td>
                    <td align="left"><asp:LinkButton ID="lb_formato2" runat="server" OnClick="lb_formato2_Click"></asp:LinkButton></td>
                </tr>
            </table>
        </td>
    </tr>
</table>