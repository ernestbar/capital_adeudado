<%@ Control Language="C#" ClassName="tpEstadoContratoAbm" %>

<script runat="server">
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }

    public void Cargar(int Id_contrato)
    {
        id_contrato = Id_contrato;
        terrasur.terraplus.tp_estado_contrato ecObj = new terrasur.terraplus.tp_estado_contrato(terrasur.terraplus.tp_estado_contrato.Actual(id_contrato));
        
        if (ecObj.estado_codigo == "restriccion") { rbl_estado.SelectedValue = "cobertura"; }
        else if (ecObj.estado_codigo == "cobertura") { rbl_estado.SelectedValue = "restriccion"; }
        else { rbl_estado.SelectedIndex = -1; }
        
        txt_observacion.Text = "";
        txt_observacion.Focus();
    }

    private bool VerificarInsertar()
    {
        bool correcto = true;
        if (rbl_estado.SelectedIndex == -1)
        {
            Msg1.Text = "No es posible realizar el cambio de estado";
            correcto = false;
        }
        return correcto;
    }
    
    public bool Insertar()
    {
        if (VerificarInsertar())
        {
            terrasur.terraplus.tp_estado_contrato ecObj = new terrasur.terraplus.tp_estado_contrato(id_contrato, (new terrasur.terraplus.tp_estado(rbl_estado.SelectedValue)).id_estado, 0, 0, txt_observacion.Text.Trim());
            if (ecObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El nuevo estado del contrato TerraPlus se registró correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El nuevo estado del contrato TerraPlus NO se registró correctamente";
                return false;
            }
        }
        else { return false; }
    }
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Estado actual:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_estado" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Cambiar estado a:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_estado" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" Enabled="true">
                <asp:ListItem Value="restriccion" Text="Restricción" Selected="True"></asp:ListItem>
                <asp:ListItem Value="cobertura" Text="Cobertura"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Observación:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" SkinID="txtMultiLine300x3"></asp:TextBox>
        </td>
    </tr>
</table>