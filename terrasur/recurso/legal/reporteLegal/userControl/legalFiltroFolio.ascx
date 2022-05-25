<%@ Control Language="C#" ClassName="legalFiltroFolio" %>

<script runat="server">
    public int con_folio { get { return int.Parse(rbl_con_folio.SelectedValue); } }
    public string num_folio { get { return txt_num_folio.Text.Trim(); } }
    public int entregado { get { return int.Parse(rbl_entregado.SelectedValue); } }
    public DateTime entregado_fecha_inicio
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true) return cp_fecha_inicio.SelectedDate;
            else return DateTime.Parse("29/12/1899");
        }
    }
    public DateTime entregado_fecha_fin
    {
        get
        {
            if (cp_fecha_fin.SelectedValue.HasValue == true) return cp_fecha_fin.SelectedDate;
            else return DateTime.Parse("01/01/2100");
        }
    }
    public bool varias_observaciones
    {
        get
        {
            if (rbl_varias_observaciones.SelectedValue == "true") return true;
            else return false;
        }
    }



    public string string_con_folio { get { return rbl_con_folio.SelectedItem.Text; } }
    public string string_num_folio { get { if (txt_num_folio.Text.Trim() == "") return "Todos"; else return txt_num_folio.Text.Trim(); } }
    public string string_entregado
    {
        get
        {
            string resultado = rbl_entregado.SelectedItem.Text;
            if (int.Parse(rbl_entregado.SelectedValue) == 1)
            {
                if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == true)
                    resultado += " (Entre el " + cp_fecha_inicio.SelectedDate.ToString("d") + " y el " + cp_fecha_fin.SelectedDate.ToString("d") + ")";
                else if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == false)
                    resultado += " (Desde el " + cp_fecha_inicio.SelectedDate.ToString("d") + ")";
                else if (cp_fecha_inicio.SelectedValue.HasValue == false && cp_fecha_fin.SelectedValue.HasValue == true)
                    resultado += " (Hasta el " + cp_fecha_fin.SelectedDate.ToString("d") + ")";
            }
            return resultado;
        }
    }
    public string string_varias_observaciones { get { return rbl_varias_observaciones.SelectedItem.Text; } }

    

    public void Reset()
    {
        rbl_con_folio.SelectedValue = "-1";
        txt_num_folio.Text = "";
        rbl_entregado.SelectedValue = "-1";

        lbl_fecha_enun.Visible = false;
        cp_fecha_inicio.Visible = false;
        cp_fecha_inicio.SelectedValue = null;
        lbl_fecha_guion.Visible = false;
        cp_fecha_fin.Visible = false;
        cp_fecha_fin.SelectedValue = null;
        
        rbl_varias_observaciones.SelectedValue = "false";

        lbl_varias_observaciones.Visible = false;
        rbl_varias_observaciones.Visible = false;
    }

    protected void rbl_entregado_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_fecha_enun.Visible = rbl_entregado.SelectedValue.Equals("1");
        cp_fecha_inicio.Visible = rbl_entregado.SelectedValue.Equals("1");
        cp_fecha_inicio.SelectedValue = null;
        lbl_fecha_guion.Visible = rbl_entregado.SelectedValue.Equals("1");
        cp_fecha_fin.Visible = rbl_entregado.SelectedValue.Equals("1");
        cp_fecha_fin.SelectedValue = null;

    }
</script>
<asp:Panel ID="panel_folio" runat="server" GroupingText="Negocio (para el dpto. Legal)">
    <table class="formTable" cellpadding="0" cellspacing="0" align="left">
        <tr>
            <td class="formTdEnun">Folio:</td>
            <td class="formTdDato">
                <asp:RadioButtonList ID="rbl_con_folio" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Con folio" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Sin folio" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Nº folio:</td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_num_folio" runat="server" SkinID="txtSingleLine100" MaxLength="13"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Entregado:</td>
            <td class="formTdDato">
                <asp:RadioButtonList ID="rbl_entregado" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" AutoPostBack="true" OnSelectedIndexChanged="rbl_entregado_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="No entregado" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Entregado" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server" Text="Entregado (Fecha):"></asp:Label></td>
            <td class="formTdDato">
                <ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                <asp:Label ID="lbl_fecha_guion" runat="server" Text="-"></asp:Label>
                <ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            </td>
        </tr>

        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_varias_observaciones" runat="server" Text="Observación:"></asp:Label></td>
            <td class="formTdDato">
                <asp:RadioButtonList ID="rbl_varias_observaciones" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Text="Solo la última" Value="false" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Todas las observaciones" Value="true"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</asp:Panel>