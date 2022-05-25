<%@ Control Language="C#" ClassName="contratoEmisionFiltro" %>

<script runat="server">
    public DateTime fecha_inicio { get { if (cp_inicio.SelectedValue.HasValue) { return cp_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime fecha_fin { get { if (cp_fin.SelectedValue.HasValue) { return cp_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }
    public string tipo_documento_codigo { get { return ddl_tipo_documento.SelectedValue; } }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } }
    public int id_usuario { get { if (ddl_usuario.Items.Count > 0) { return int.Parse(ddl_usuario.SelectedValue); } else { return 0; } } }
    public string cliente { get { return txt_cliente.Text.Trim(); } }
    public int para_cliente { get { return int.Parse(rbl_para_cliente.SelectedValue); } }

    public string string_fecha
    {
        get
        {
            if (cp_inicio.SelectedValue.HasValue == true && cp_fin.SelectedValue.HasValue == true)
            { return "Desde el " + cp_inicio.SelectedDate.ToString("d") + " hasta el " + cp_fin.SelectedDate.ToString("d"); }
            else if (cp_inicio.SelectedValue.HasValue == true && cp_fin.SelectedValue.HasValue == false)
            { return "Desde el " + cp_inicio.SelectedDate.ToString("d"); }
            else if (cp_inicio.SelectedValue.HasValue == false && cp_fin.SelectedValue.HasValue == true)
            { return "Hasta el " + cp_fin.SelectedDate.ToString("d"); }
            else { return ""; }
        }
    }
    public string string_tipo_documento { get { return ddl_tipo_documento.SelectedItem.Text; } }
    public string string_usuario { get { if (ddl_usuario.Items.Count > 0) { return ddl_usuario.SelectedItem.Text; } else { return ""; } } }
    public string string_tipo_emision { get { return rbl_para_cliente.SelectedItem.Text; } }
    
    
    public void Reset(int Id_contrato, string Codigo_tipo_documento)
    {
        cp_inicio.SelectedDate = DateTime.Now.Date;
        if (Id_contrato > 0)
        {
            txt_num_contrato.Text = (new contrato(Id_contrato)).numero;
            
            if (ddl_tipo_documento.Items.FindByValue(Codigo_tipo_documento) != null)
            { ddl_tipo_documento.SelectedValue = Codigo_tipo_documento; }
        }
        rbl_para_cliente.SelectedValue = "-1";
    }

    protected void ddl_usuario_DataBound(object sender, EventArgs e)
    {
        //ddl_usuario.Items.Insert(0, new ListItem("Todos", "0"));
        ddl_usuario.Items.Insert(0, new ListItem("", "0"));
    }

    protected void ddl_tipo_documento_DataBound(object sender, EventArgs e)
    {
        //ddl_tipo_documento.Items.Insert(0, new ListItem("Todos", ""));
        ddl_tipo_documento.Items.Insert(0, new ListItem("", ""));
    }
</script>
<table cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_filtro" runat="server" GroupingText="Criterio de búsqueda">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdEnun">Fecha de emisión:</td>
                        <td class="formTdDato" colspan="3">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td><ew:CalendarPopup ID="cp_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                    <td>-</td>
                                    <td><ew:CalendarPopup ID="cp_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">Tipo de documento:</td>
                        <td class="formTdDato" colspan="3">
                            <asp:DropDownList ID="ddl_tipo_documento" runat="server" DataSourceID="ods_lista_tipo" DataTextField="nombre" DataValueField="codigo" OnDataBound="ddl_tipo_documento_DataBound">
                            </asp:DropDownList>
                            <%--[id_tipodocumento],[codigo],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_lista_tipo" runat="server" TypeName="terrasur.emDoc.emision" SelectMethod="ListaTipoDocumento">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">Nro. contrato:</td>
                        <td class="formTdDato">
                            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine50">
                            </asp:TextBox>
                        </td>
                        <td class="formTdEnun">Usuario:</td>
                        <td class="formTdDato">
                            <asp:DropDownList ID="ddl_usuario" runat="server" DataSourceID="ods_lista_usuario" DataTextField="nombre" DataValueField="id_usuario" OnDataBound="ddl_usuario_DataBound">
                            </asp:DropDownList>
                            <%--[id_usuario],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_lista_usuario" runat="server" TypeName="terrasur.emDoc.emision" SelectMethod="ListaUsuarios">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">Nombre/CI del cliente:</td>
                        <td class="formTdDato" colspan="3">
                            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtSingleLine200">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">Tipo de emisión:</td>
                        <td class="formTdDato" colspan="3">
                            <asp:RadioButtonList ID="rbl_para_cliente" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Para el cliente" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Uso interno" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>