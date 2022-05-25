<%@ Control Language="C#" ClassName="sBloqueadoCriterioBusqueda" %>

<script runat="server">
    public int activo { get { return int.Parse(rbl_activo.SelectedValue); } }
    public DateTime fecha_inicio { get { if (cp_fecha_inicio.SelectedValue.HasValue == true) { return cp_fecha_inicio.SelectedDate; } else { return DateTime.Parse("01/01/1900"); } } }
    public DateTime fecha_fin { get { if (cp_fecha_fin.SelectedValue.HasValue == true) { return cp_fecha_fin.SelectedDate; } else { return DateTime.Parse("01/01/2900"); } } }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } }
    public string usuario { get { return txt_usuario.Text.Trim(); } }
    
    public void Reset()
    {
        cp_fecha_inicio.SelectedValue = null;
        cp_fecha_fin.SelectedValue = null;

        txt_num_contrato.Text = "";
        txt_usuario.Text = "";
        rbl_activo.SelectedValue = "-1";

        txt_num_contrato.Focus();
    }
</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdEnun">Bloqueo:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_activo" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Bloqueado" Value="1"></asp:ListItem>
                <asp:ListItem Text="Desbloqueado" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de bloqueo/desbloqueo:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            -
            <ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. contrato:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_num_contrato" runat="server" MaxLength="10" SkinID="txtSingleLine100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Usuario:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_usuario" runat="server" MaxLength="50" SkinID="txtSingleLine200"></asp:TextBox></td>
    </tr>
    <%--<tr>
        <td class="formTdEnun"></td>
        <td class="formTdDato"></td>
    </tr>--%>
</table>
