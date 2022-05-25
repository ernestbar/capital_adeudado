<%@ Control Language="C#" ClassName="tpFiltroCarteraVigente" %>

<script runat="server">
    public DateTime fecha { get { return cp_fecha.SelectedDate; } }

    public string estado_ids
    {
        get
        {
            StringBuilder str = new StringBuilder();
            foreach (ListItem item in cbl_estado.Items) { if (item.Selected) { str.Append(item.Value + ","); } }
            return str.ToString().TrimEnd(',');
        }
    }
    public string estado_nombres
    {
        get
        {
            StringBuilder str = new StringBuilder();
            foreach (ListItem item in cbl_estado.Items) { if (item.Selected) { str.Append(item.Text + ", "); } }
            return str.ToString().Trim().TrimEnd(',');
        }
    }
    
    public DateTime registro_inicio { get { if (cp_registro_inicio.SelectedValue.HasValue) { return cp_registro_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime registro_fin { get { if (cp_registro_fin.SelectedValue.HasValue) { return cp_registro_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }

    public DateTime ult_pago_inicio { get { if (cp_ult_pago_inicio.SelectedValue.HasValue) { return cp_ult_pago_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime ult_pago_fin { get { if (cp_ult_pago_fin.SelectedValue.HasValue) { return cp_ult_pago_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }

    public DateTime ult_mes_inicio { get { if (cp_ult_mes_inicio.SelectedValue.HasValue) { return cp_ult_mes_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime ult_mes_fin { get { if (cp_ult_mes_fin.SelectedValue.HasValue) { return cp_ult_mes_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }

    public string nombre_ci_cliente { get { return txt_nombre_ci_cliente.Text.Trim(); } }

    public string tp_num_contrato { get { return txt_tp_num_contrato.Text.Trim(); } }

    public int id_moneda { get { return int.Parse(rbl_moneda.SelectedValue); } }
    public bool consolidado { get { return rbl_consolidado.SelectedValue.Equals("True"); } }

    public string moneda_string { get { return rbl_moneda.SelectedItem.Text; } }
    public string consolidado_string { get { return rbl_consolidado.SelectedItem.Text; } }
    
    public void Reset()
    {
        cp_fecha.SelectedDate = DateTime.Now;
        
        cbl_estado.DataBind();

        cp_registro_inicio.SelectedValue = null;
        cp_registro_fin.SelectedValue = null;

        cp_ult_pago_inicio.SelectedValue = null;
        cp_ult_pago_fin.SelectedValue = null;

        cp_ult_mes_inicio.SelectedValue = null;
        cp_ult_mes_fin.SelectedValue = null;

        txt_nombre_ci_cliente.Text = "";
        txt_tp_num_contrato.Text = "";

        rbl_moneda.DataBind();
        rbl_consolidado.DataBind();
    }

    public bool TieneDatos
    {
        get
        {
            if (this.nombre_ci_cliente != "" || this.tp_num_contrato != "" || this.estado_ids != ""
                || cp_registro_inicio.SelectedValue.HasValue == true || cp_registro_fin.SelectedValue.HasValue == true
                || cp_ult_pago_inicio.SelectedValue.HasValue == true || cp_ult_pago_fin.SelectedValue.HasValue == true
                || cp_ult_mes_inicio.SelectedValue.HasValue == true || cp_ult_mes_fin.SelectedValue.HasValue == true
                )
            { return true; }
            else { return false; }
        }
    }
    
    
    protected void cbl_estado_DataBound(object sender, EventArgs e)
    {
        foreach (ListItem item in cbl_estado.Items)
        {
            if (item.Text == "Restricción" || item.Text == "Cobertura")
            {
                item.Selected = true;
            }
        }
    }

    protected void rbl_moneda_DataBound(object sender, EventArgs e)
    {
        if (rbl_moneda.Items.Count > 0)
        {
            rbl_moneda.SelectedIndex = 0;
        }
    }

    protected void rbl_consolidado_DataBound(object sender, EventArgs e)
    {
        if (rbl_consolidado.Items.Count > 1)
        {
            rbl_consolidado.SelectedIndex = 1;
        }
        lbl_consolidado_enun.Text = "Datos contemplados:";
    }
</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdEnun">Corte al:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha" runat="server" Width="100px"></ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Estado del Ctto. (Terraplus):</td>
        <td class="formTdDato">
            <asp:CheckBoxList ID="cbl_estado" runat="server" DataSourceID="ods_lista_tp_estado" DataTextField="nombre" DataValueField="id_estado" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="cbl_estado_DataBound">
            </asp:CheckBoxList>
            <%--[id_estado],[codigo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_tp_estado" runat="server" TypeName="terrasur.terraplus.tp_estado" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de registro:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_registro_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            -<ew:CalendarPopup ID="cp_registro_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>        
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de últ. pago:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_ult_pago_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            -<ew:CalendarPopup ID="cp_ult_pago_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>        
    </tr>
    <tr>
        <td class="formTdEnun">Últ. mes pagado:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_ult_mes_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            -<ew:CalendarPopup ID="cp_ult_mes_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>        
    </tr>
    <tr>
        <td class="formTdEnun">Nombre/CI del cliente:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre_ci_cliente" runat="server" MaxLength="30" SkinID="txtSingleLine200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. contrato (TerraPlus):</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_tp_num_contrato" runat="server" MaxLength="10"></asp:TextBox>
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
</table>