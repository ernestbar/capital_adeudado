<%@ Control Language="C#" ClassName="filtroReembolso" %>

<script runat="server">
    public DateTime fecha { get { return cp_fecha.SelectedDate;} } 

    public int tipo_reembolso { get { return int.Parse(rbl_tipo.SelectedValue); } set { rbl_tipo.SelectedValue = value.ToString(); } }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } set { txt_num_contrato.Text = value; } }
    public int origen_contrato { get { return int.Parse(rbl_origen.SelectedValue); } set { rbl_origen.SelectedValue = value.ToString(); } }
    public DateTime fecha_inicio { get { if (cp_fecha_inicio.SelectedValue.HasValue == true) { return cp_fecha_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime fecha_fin { get { if (cp_fecha_fin.SelectedValue.HasValue == true) { return cp_fecha_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }
    public int id_usuario { get { return int.Parse(ddl_usuario.SelectedValue); } set { ddl_usuario.SelectedValue = value.ToString(); } }
    public string cliente { get { return txt_cliente.Text.Trim(); } set { txt_cliente.Text = value; } }
    public int id_motivo { get { return int.Parse(ddl_motivo.SelectedValue); } set { ddl_motivo.SelectedValue = value.ToString(); } }
    public int asignacion { get { return int.Parse(rbl_asignacion.SelectedValue); } set { rbl_asignacion.SelectedValue = value.ToString(); } }
    public int saldo { get { return int.Parse(rbl_saldo.SelectedValue); } set { rbl_saldo.SelectedValue = value.ToString(); } }
    public int id_localizacion { get { return int.Parse(ddl_localizacion.SelectedValue); } set { ddl_localizacion.SelectedValue = value.ToString(); } }
    public int id_urbanizacion { get { return int.Parse(ddl_urbanizacion.SelectedValue); } set { ddl_urbanizacion.SelectedValue = value.ToString(); } }
    public int id_estadoconciliacion { get { return int.Parse(rbl_estadoconciliacion.SelectedValue); } set { rbl_estadoconciliacion.SelectedValue = value.ToString(); } } // Req. Conciliaciones

    public int id_moneda { get { return int.Parse(rbl_moneda.SelectedValue); } }
    public bool consolidado { get { return bool.Parse(rbl_consolidado.SelectedValue); } }

    public bool ParaReporte
    {
        set
        {
            lbl_fecha_enun.Visible = value;
            cp_fecha.Visible = value;
            lbl_moneda_enun.Visible = value;
            rbl_moneda.Visible = value;
            lbl_consolidado_enun.Visible = value;
            rbl_consolidado.Visible = value;
        }
    }
    
    
    public string str_num_contrato
    {
        get
        {
            if (!string.IsNullOrEmpty(txt_num_contrato.Text.Trim()))
            {
                if (int.Parse(rbl_origen.SelectedValue) >= 0) { return txt_num_contrato.Text.Trim() + " (" + rbl_origen.SelectedItem.Text + ")"; }
                else { return txt_num_contrato.Text.Trim(); }
            }
            else { return ""; }
        }
    }
    public string str_tipo { get { if (int.Parse(rbl_tipo.SelectedValue) >= 0) { return rbl_tipo.SelectedItem.Text; } else { return ""; } } }
    public string str_fecha
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == false)
            { return "desde " + cp_fecha_inicio.SelectedDate.ToString("d"); }
            else if (cp_fecha_inicio.SelectedValue.HasValue == false && cp_fecha_fin.SelectedValue.HasValue == true)
            { return "hasta " + cp_fecha_fin.SelectedDate.ToString("d"); }
            else if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == true)
            { return cp_fecha_inicio.SelectedDate.ToString("d") + " - " + cp_fecha_fin.SelectedDate.ToString("d"); }
            else { return ""; }
        }
    }
    public string str_usuario { get { return ddl_usuario.SelectedItem.Text; } }
    public string str_motivo { get { return ddl_motivo.SelectedItem.Text; } }
    public string str_cliente { get { return txt_cliente.Text.Trim(); } }
    public string str_ubicacion
    {
        get
        {
            if (int.Parse(ddl_localizacion.SelectedValue) > 0 && int.Parse(ddl_urbanizacion.SelectedValue) == 0)
            { return ddl_localizacion.SelectedItem.Text; }
            else if (int.Parse(ddl_localizacion.SelectedValue) == 0 && int.Parse(ddl_urbanizacion.SelectedValue) > 0)
            { return ddl_urbanizacion.SelectedItem.Text; }
            else if (int.Parse(ddl_localizacion.SelectedValue) > 0 && int.Parse(ddl_urbanizacion.SelectedValue) > 0)
            { return ddl_localizacion.SelectedItem.Text + " / " + ddl_urbanizacion.SelectedItem.Text; }
            else { return ""; }
        }
    }
    public string str_asignacion { get { if (int.Parse(rbl_asignacion.SelectedValue) > -2) { return rbl_asignacion.SelectedItem.Text; } else { return ""; } } }
    public string str_saldo { get { if (int.Parse(rbl_saldo.SelectedValue) > -1) { return rbl_saldo.SelectedItem.Text; } else { return ""; } } }
    public string str_moneda { get { return rbl_moneda.SelectedItem.Text; } }
    public string str_consolidado { get { return rbl_consolidado.SelectedItem.Text; } }
    public string str_codigo_moneda { get { return (new moneda(int.Parse(rbl_moneda.SelectedValue))).codigo; } }
    
    
    public void Reset()
    {
        cp_fecha.SelectedDate = DateTime.Now;
        
        tipo_reembolso = -1;
        num_contrato = "";
        origen_contrato = -1;
        cp_fecha_inicio.SelectedValue = null;
        cp_fecha_fin.SelectedValue = null;
        ddl_usuario.DataBind();
        id_usuario = 0;
        cliente = "";
        ddl_motivo.DataBind();
        id_motivo = 0;
        asignacion = -2;
        saldo = -1;
        
        txt_num_contrato.Focus();
    }

    protected void ddl_usuario_DataBound(object sender, EventArgs e)
    {
        ddl_usuario.Items.Insert(0, new ListItem("", "0"));
    }
    
    protected void ddl_motivo_DataBound(object sender, EventArgs e)
    {
        ddl_motivo.Items.Insert(0, new ListItem("", "0"));
    }

    protected void ddl_localizacion_DataBound(object sender, EventArgs e)
    {
        ddl_localizacion.Items.Insert(0, new ListItem("", "0"));
    }

    protected void ddl_urbanizacion_DataBound(object sender, EventArgs e)
    {
        ddl_urbanizacion.Items.Insert(0, new ListItem("", "0"));
    }

    protected void rbl_moneda_DataBound(object sender, EventArgs e)
    {
        if (rbl_moneda.Items.Count > 0) { rbl_moneda.SelectedIndex = 0; }
    }

    protected void rbl_consolidado_DataBound(object sender, EventArgs e)
    {
        if (rbl_consolidado.Items.Count > 1) { rbl_consolidado.SelectedIndex = 1; }
        lbl_consolidado_enun.Text = "Datos contemplados:";
    }
</script>
<table class="formTable" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="formTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server" Visible="false" Text="A la fecha:"></asp:Label></td>
                    <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" Visible="false"></ew:CalendarPopup></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº contrato:</td>
        <td class="formTdDato" colspan="3">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="12"></asp:TextBox></td>
                    <td><asp:Label ID="lbl_origen_enun" runat="server" Text=" del sistema: " SkinID="lblEnun"></asp:Label></td>
                    <td>
                        <asp:RadioButtonList ID="rbl_origen" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                            <asp:ListItem Value="-1" Text="Todos" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="BBR/Terasur"></asp:ListItem>
                            <asp:ListItem Value="0" Text="Renacer"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Tipo:</td>
        <td class="formTdDato" colspan="3">
            <asp:RadioButtonList ID="rbl_tipo" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Value="-1" Text="Todos" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="Traspaso"></asp:ListItem>
                <asp:ListItem Value="0" Text="Devolución"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                    <td>-</td>
                    <td><ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                </tr>
            </table>
        </td>
        <td class="formTdEnun">Procesado por:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_usuario" runat="server" DataSourceID="ods_usuario_lista" DataValueField="id_usuario" DataTextField="nombre" OnDataBound="ddl_usuario_DataBound">
            </asp:DropDownList>
            <%--[id_usuario],[ci],[nombre]--%>
            <asp:ObjectDataSource ID="ods_usuario_lista" runat="server" TypeName="terrasur.traspaso.usuario_reembolso" SelectMethod="Lista">
                <SelectParameters><asp:Parameter Name="Id_usuario" Type="Int32" DefaultValue="0" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Cliente:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
        </td>
        <td class="formTdEnun">Motivo:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_motivo" runat="server" DataSourceID="ods_motivo_lista" DataValueField="id_motivo" DataTextField="nombre" OnDataBound="ddl_motivo_DataBound">
            </asp:DropDownList>
            <%--[id_motivo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.traspaso.motivo" SelectMethod="ListaParaDll">
                <SelectParameters><asp:Parameter Name="Id_motivo" Type="Int32" DefaultValue="0" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Ubicación:</td>
        <td class="formTdDato" colspan="3">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion" OnDataBound="ddl_localizacion_DataBound"></asp:DropDownList></td>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="false" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound"></asp:DropDownList></td>
                </tr>
            </table>
            <%--[id_localizacion],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="ListaConUrbanizacion_para_ddl">
                <SelectParameters>
                    <asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <%--[id_urbanizacion],[codigo],[nombre_corto],[nombre]
                [mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
            <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Asignación del reembolso:</td>
        <td class="formTdDato" colspan="3">
            <asp:RadioButtonList ID="rbl_asignacion" runat="server" RepeatDirection="Horizontal" CellSpacing="0" CellPadding="0">
                <asp:ListItem Value="-2" Text="Todos" Selected="True"></asp:ListItem>
                <asp:ListItem Value="0" Text="Realizado"></asp:ListItem>
                <asp:ListItem Value="1" Text="Pendiente"></asp:ListItem>
                <asp:ListItem Value="-1" Text="SobreAsignado"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Saldo:</td>
        <td class="formTdDato" colspan="3">
            <asp:RadioButtonList ID="rbl_saldo" runat="server" RepeatDirection="Horizontal" CellSpacing="0" CellPadding="0">
                <asp:ListItem Value="-1" Text="Todos" Selected="True"></asp:ListItem>
                <asp:ListItem Value="0" Text="Cancelado"></asp:ListItem>
                <asp:ListItem Value="1" Text="Pendiente"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <%--Req. Conciliaciones--%>
    <tr>
        <td class="formTdEnun">Estado de la Adenda:</td>
        <td class="formTdDato" colspan="3">
            <asp:RadioButtonList ID="rbl_estadoconciliacion" runat="server" RepeatDirection="Horizontal" CellSpacing="0" CellPadding="0">
                <asp:ListItem Value="-1" Text="Todos" Selected="True"></asp:ListItem>
                <asp:ListItem Value="2" Text="Realizado"></asp:ListItem>
                <asp:ListItem Value="1" Text="Pendiente"></asp:ListItem>
                <asp:ListItem Value="3" Text="Rechazado"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <%--Req. Conciliaciones--%>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_moneda_enun" runat="server" Visible="false" Text="Moneda:"></asp:Label></td>
        <td class="formTdDato" colspan="3">
            <asp:RadioButtonList ID="rbl_moneda" runat="server" Visible="false" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_moneda_DataBound">
            </asp:RadioButtonList>
            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server" Visible="false"></asp:Label></td>
        <td class="formTdDato" colspan="3">
            <asp:RadioButtonList ID="rbl_consolidado" runat="server" Visible="false" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_consolidado_DataBound">
            </asp:RadioButtonList>
            <%--[valor],[texto]--%>
            <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
            </asp:ObjectDataSource>
        </td>
    </tr>
    
</table>