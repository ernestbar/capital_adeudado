<%@ Control Language="C#" ClassName="tpFiltroContrato" %>

<script runat="server">
    public string nombre { get { return txt_nombre.Text.Trim(); } }
    public int tp_id_estado { get { return int.Parse(ddl_tp_estado.SelectedValue); } }

    public string tp_num_contrato { get { return txt_tp_num_contrato.Text.Trim(); } }
    public DateTime tp_fecha_inicio { get { if (cp_tp_inicio.SelectedValue.HasValue) { return cp_tp_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime tp_fecha_fin { get { if (cp_tp_fin.SelectedValue.HasValue) { return cp_tp_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }

    public string lot_num_contrato { get { return txt_lot_num_contrato.Text.Trim(); } }
    public DateTime lot_fecha_inicio { get { if (cp_lot_inicio.SelectedValue.HasValue) { return cp_lot_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime lot_fecha_fin { get { if (cp_lot_fin.SelectedValue.HasValue) { return cp_lot_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }

    public void Reset()
    {
        txt_nombre.Text = "";
        if (ddl_tp_estado.Items.FindByValue("0") != null) { ddl_tp_estado.SelectedValue = "0"; } else { ddl_tp_estado.DataBind(); }
        
        txt_tp_num_contrato.Text = "";
        cp_tp_inicio.SelectedValue = DateTime.Now.Date;
        //cp_tp_inicio.SelectedValue = null;
        cp_tp_fin.SelectedValue = null;

        txt_lot_num_contrato.Text = "";
        cp_lot_inicio.SelectedValue = null;
        cp_lot_fin.SelectedValue = null;
    }
    
    public bool TieneDatos
    {
        get
        {
            if (this.nombre != "" || this.tp_id_estado > 0
                || this.tp_num_contrato != "" || cp_tp_inicio.SelectedValue.HasValue == true || cp_tp_fin.SelectedValue.HasValue == true
                || this.lot_num_contrato != "" || cp_lot_inicio.SelectedValue.HasValue == true || cp_lot_fin.SelectedValue.HasValue == true
                )
            { return true; }
            else { return false; }
        }
    }
    
    
    
    protected void ddl_tp_estado_DataBound(object sender, EventArgs e)
    {
        ddl_tp_estado.Items.Insert(0, new ListItem("Todos", "0"));
    }
</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdEnun">Estado del Ctto. (Terraplus):</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_tp_estado" runat="server" DataSourceID="ods_lista_tp_estado" DataTextField="nombre" DataValueField="id_estado" OnDataBound="ddl_tp_estado_DataBound">
            </asp:DropDownList>
            <%--[id_estado],[codigo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_tp_estado" runat="server" TypeName="terrasur.terraplus.tp_estado" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
        <td class="formTdEnun">Nombre/CI del cliente:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" MaxLength="30" SkinID="txtSingleLine200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. contrato (TerraPlus):</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_tp_num_contrato" runat="server" MaxLength="10"></asp:TextBox>
        </td>
        <td class="formTdEnun">Nro. contrato (Lote):</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_lot_num_contrato" runat="server" MaxLength="10"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha Ctto.(TerraPlus):</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_tp_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            -<ew:CalendarPopup ID="cp_tp_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>        
        <td class="formTdEnun">Fecha Ctto.(Lote):</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_lot_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            -<ew:CalendarPopup ID="cp_lot_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>        
    </tr>
</table>