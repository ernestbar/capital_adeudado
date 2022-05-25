<%@ Control Language="C#" ClassName="legalFiltroNegocioLegal" %>

<script runat="server">
    public string id_negocio
    {
        get
        {
            StringBuilder str = new StringBuilder();
            foreach (ListItem item in cbl_negocio.Items) { if (item.Selected == true) str.Append(item.Value + ","); }
            if (str.ToString() != "") return "," + str.ToString().TrimEnd(',') + ",";
            else return "";
        }
    }
    public int id_estadotramite
    {
        get
        {
            if (rbl_estado_tramite.Items.Count > 0)
            {
                if (rbl_estado_tramite.SelectedIndex >= 0) return int.Parse(rbl_estado_tramite.SelectedValue);
                else return 0;
            }
            else { return 0; }
        }
    }
    public DateTime fecha_inicio
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true) return cp_fecha_inicio.SelectedDate;
            else return DateTime.Parse("29/12/1899");
        }
    }
    public DateTime fecha_fin
    {
        get
        {
            if (cp_fecha_fin.SelectedValue.HasValue == true) return cp_fecha_fin.SelectedDate;
            else return DateTime.Parse("01/01/2100");
        }
    }



    public string string_negocio
    {
        get
        {
            StringBuilder str = new StringBuilder();
            int num_elegidos = 0;
            foreach (ListItem item in cbl_negocio.Items)
            {
                if (item.Selected == true)
                {
                    str.Append(item.Text + ", ");
                    num_elegidos += 1;
                }
            }
            if (num_elegidos == cbl_negocio.Items.Count) return "Todos";
            else if (num_elegidos == 0) return "Ninguno";
            else return str.ToString().Trim().TrimEnd(',');
        }
    }
    public string string_estadotramite
    {
        get
        {
            if (rbl_estado_tramite.Items.Count > 0)
            {
                if (rbl_estado_tramite.SelectedIndex >= 0) return rbl_estado_tramite.SelectedItem.Text;
                else return "";
            }
            else { return ""; }
        }
    }
    public string string_fecha
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == true)
                return "Entre el " + cp_fecha_inicio.SelectedDate.ToString("d") + " y el " + cp_fecha_fin.SelectedDate.ToString("d");
            else if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == false)
                return "Desde el " + cp_fecha_inicio.SelectedDate.ToString("d");
            else if (cp_fecha_inicio.SelectedValue.HasValue == false && cp_fecha_fin.SelectedValue.HasValue == true)
                return "Hasta el " + cp_fecha_fin.SelectedDate.ToString("d");
            else return "Todos";
        }
    }



    public void Reset()
    {
        cbl_negocio.DataBind();
        rbl_estado_tramite.DataBind();
        cp_fecha_inicio.SelectedValue = null;
        cp_fecha_fin.SelectedValue = null;
    }



    protected void cbl_negocio_DataBound(object sender, EventArgs e)
    {
        legal_negocio nObj = new legal_negocio("bbr");
        foreach (ListItem item in cbl_negocio.Items)
        {
            item.Selected = true;
            if (item.Value == nObj.id_negocio.ToString()) item.Text = "BBR";
        }
    }

    protected void rbl_estado_tramite_DataBound(object sender, EventArgs e)
    {
        rbl_estado_tramite.Items.Insert(0, new ListItem("Todos", "0"));
        rbl_estado_tramite.SelectedIndex = 0;
    }
</script>
<asp:Panel ID="panel_legal_negocio" runat="server" GroupingText="Negocio (para el dpto. Legal)">
    <table class="formTable" cellpadding="0" cellspacing="0" align="left">
        <tr>
            <td class="formTdEnun">Negocio:</td>
            <td class="formTdDato">
                <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="cbl_negocio_DataBound"></asp:CheckBoxList>
                <%--[id_negocio],[codigo],[nombre]--%>
                <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.legal_negocio" SelectMethod="Lista">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Trámite:</td>
            <td class="formTdDato">
                <asp:RadioButtonList ID="rbl_estado_tramite" runat="server" DataSourceID="ods_lista_estado_tramite" DataTextField="nombre" DataValueField="id_estadotramite" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnDataBound="rbl_estado_tramite_DataBound">
                </asp:RadioButtonList>
                <%--[id_estadotramite],[codigo],[nombre],[orden]--%>
                <asp:ObjectDataSource ID="ods_lista_estado_tramite" runat="server" TypeName="terrasur.legal_estado_tramite" SelectMethod="Lista">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Fecha:</td>
            <td class="formTdDato">
                <ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                -
                <ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            </td>
        </tr>
    </table>
</asp:Panel>