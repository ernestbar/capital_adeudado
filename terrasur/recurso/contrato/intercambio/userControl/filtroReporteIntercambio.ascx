<%@ Control Language="C#" ClassName="filtroReporteIntercambio" %>

<script runat="server">
    public DateTime fecha_inicio { get { if (cp_fecha_inicio.SelectedValue.HasValue == true) { return cp_fecha_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime fecha_fin { get { if (cp_fecha_fin.SelectedValue.HasValue == true) { return cp_fecha_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } }
    public int id_localizacion { get { return int.Parse(ddl_localizacion.SelectedValue); } }
    public int id_urbanizacion { get { return int.Parse(ddl_urbanizacion.SelectedValue); } }
    public int id_manzano { get { return int.Parse(ddl_manzano.SelectedValue); } }
    public string empresa { get { return txt_empresa.Text.Trim(); } }
    public string descripcion { get { return txt_descripcion.Text.Trim(); } }

    public string str_periodo
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == true) { return "Entre el " + cp_fecha_inicio.SelectedDate.ToString("d") + " y el " + cp_fecha_fin.SelectedDate.ToString("d"); }
            else if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == false) { return "Desde el " + cp_fecha_inicio.SelectedDate.ToString("d"); }
            else if (cp_fecha_inicio.SelectedValue.HasValue == false && cp_fecha_fin.SelectedValue.HasValue == true) { return "Hasta el " + cp_fecha_fin.SelectedDate.ToString("d"); }
            else { return ""; }
        }
    }
    public string str_lote
    {
        get
        {
            StringBuilder str = new StringBuilder();
            if (ddl_localizacion.SelectedValue != "0") { str.Append("Loc.: " + ddl_localizacion.SelectedItem.Text + " ; "); }
            if (ddl_urbanizacion.SelectedValue != "0") { str.Append("Urb: " + ddl_urbanizacion.SelectedItem.Text + " ; "); }
            if (ddl_manzano.SelectedValue != "0") { str.Append("Mzno.: " + ddl_manzano.SelectedItem.Text); }
            return str.ToString().Trim().TrimEnd(';').Trim();
        }
    }
    
    protected void ddl_localizacion_DataBound(object sender, EventArgs e)
    {
        ddl_localizacion.Items.Insert(0, new ListItem("", "0"));
        ddl_urbanizacion.DataBind();
    }
    protected void ddl_urbanizacion_DataBound(object sender, EventArgs e)
    {
        ddl_urbanizacion.Items.Insert(0, new ListItem("", "0"));
        ddl_manzano.DataBind();
    }
    protected void ddl_manzano_DataBound(object sender, EventArgs e)
    {
        ddl_manzano.Items.Insert(0, new ListItem("", "0"));
    }


    public string datosFiltro
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == false
                && cp_fecha_fin.SelectedValue.HasValue == false
                && string.IsNullOrEmpty(txt_num_contrato.Text.Trim())
                && string.IsNullOrEmpty(txt_empresa.Text.Trim())
                && string.IsNullOrEmpty(txt_descripcion.Text.Trim())
                && int.Parse(ddl_localizacion.SelectedValue) == 0
                && int.Parse(ddl_urbanizacion.SelectedValue) == 0
                && int.Parse(ddl_manzano.SelectedValue) == 0
                ) { return ""; }
            else
            {
                StringBuilder str = new StringBuilder();
                
                if (cp_fecha_inicio.SelectedValue.HasValue == false) { str.Append(";"); }
                else { str.Append(cp_fecha_inicio.SelectedDate.ToString("d") + ";"); }

                if (cp_fecha_fin.SelectedValue.HasValue == false) { str.Append(";"); }
                else { str.Append(cp_fecha_fin.SelectedDate.ToString("d") + ";"); }

                str.Append(txt_num_contrato.Text.Trim() + ";");

                str.Append(txt_empresa.Text.Trim() + ";");

                str.Append(txt_descripcion.Text.Trim() + ";");

                str.Append(ddl_localizacion.SelectedValue + ";");
                
                str.Append(ddl_urbanizacion.SelectedValue + ";");
                
                str.Append(ddl_manzano.SelectedValue);
                return str.ToString();
            }
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                string[] datos = value.Split(';');
                if (!string.IsNullOrEmpty(datos[0])) { cp_fecha_inicio.SelectedDate = DateTime.Parse(datos[0]); }
                if (!string.IsNullOrEmpty(datos[1])) { cp_fecha_fin.SelectedDate = DateTime.Parse(datos[1]); }
                txt_num_contrato.Text = datos[2];
                txt_empresa.Text = datos[3];
                txt_descripcion.Text = datos[4];
                try
                {
                    if (ddl_localizacion.Items.FindByValue(datos[5]) == null) { ddl_localizacion.DataBind(); }
                    if (ddl_localizacion.Items.FindByValue(datos[5]) != null) { ddl_localizacion.SelectedValue = datos[5]; ddl_urbanizacion.DataBind(); }

                    if (ddl_urbanizacion.Items.FindByValue(datos[6]) == null) { ddl_urbanizacion.DataBind(); }
                    if (ddl_urbanizacion.Items.FindByValue(datos[6]) != null) { ddl_urbanizacion.SelectedValue = datos[6]; ddl_manzano.DataBind(); }

                    if (ddl_manzano.Items.FindByValue(datos[7]) == null) { ddl_manzano.DataBind(); }
                    if (ddl_manzano.Items.FindByValue(datos[7]) != null) { ddl_manzano.SelectedValue = datos[7]; }
                }
                catch { }
            }
        }
    }
    
        
    
    
</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de intercambio:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <td><ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                <td>-</td>
                <td><ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº contrato:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="12"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Lote:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion" OnDataBound="ddl_localizacion_DataBound"></asp:DropDownList></td>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound"></asp:DropDownList></td>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_manzano" DataSourceID="ods_lista_manzano" OnDataBound="ddl_manzano_DataBound"></asp:DropDownList></td>
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
            <%--[id_manzano],[codigo]--%>
            <asp:ObjectDataSource ID="ods_lista_manzano" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista_para_ddl">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Empresa/Persona:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_empresa" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Descripción:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_descripcion" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
</table>