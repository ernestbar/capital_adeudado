<%@ Control Language="C#" ClassName="sBloqueadoAbm" %>

<script runat="server">
    private int id_bloqueado { get { return int.Parse(lbl_id_bloqueado.Text); } set { lbl_id_bloqueado.Text = value.ToString(); } }
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    
    public void CargarBloquear()
    {
        txt_numero.Text = "";
        txt_numero.Enabled = true;
        txt_observacion.Text = "";
        txt_numero.Focus();
    }

    private bool VerificarBloquear()
    {
        bool correcto = false;
        if (Page.IsValid == true)
        {
            int _id_contrato = contrato.IdPorNumero(txt_numero.Text.Trim());
            if (_id_contrato > 0)
            {
                if (terrasur.sintesis.s_bloqueado.Verificar(_id_contrato) == false) { correcto = true; }
                else { Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " ya se encuentra bloqueado para Síntesis"; }
            }
            else { Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " no existe"; }
        }
        return correcto;
    }

    public bool Bloquear()
    {
        if (VerificarBloquear() == true)
        {
            int _id_contrato = contrato.IdPorNumero(txt_numero.Text.Trim());
            if (terrasur.sintesis.s_bloqueado.Bloquear(_id_contrato, txt_observacion.Text.Trim(), Profile.id_usuario) == true)
            {
                Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " se bloqueó correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " NO se bloqueó correctamente";
                return false;
            }
        }
        else { return false; }
    }


    
    public void CargarDesbloquear(int _Id_bloqueado)
    {
        terrasur.sintesis.s_bloqueado bObj = new terrasur.sintesis.s_bloqueado(_Id_bloqueado);
        id_bloqueado = bObj.id_bloqueado;
        id_contrato = bObj.id_contrato;

        txt_numero.Text = bObj.num_contrato;
        txt_numero.Enabled = false;
        txt_observacion.Text = "";
        txt_observacion.Focus();
    }

    private bool VerificarDesbloquear()
    {
        bool correcto = false;
        if (Page.IsValid == true)
        {
            if (terrasur.sintesis.s_bloqueado.Verificar(id_contrato) == true) { correcto = true; }
            else { Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " no se encuentra bloqueado para Síntesis"; }
        }
        return correcto;
    }

    public bool Desbloquear()
    {
        if (VerificarDesbloquear() == true)
        {
            if (terrasur.sintesis.s_bloqueado.Desbloquear(id_bloqueado, txt_observacion.Text.Trim(), Profile.id_usuario) == true)
            {
                Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " se desbloqueó correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El contrato " + txt_numero.Text.Trim() + " NO se desbloqueó correctamente";
                return false;
            }
        }
        else { return false; }
    }

    
</script>
<asp:Label ID="lbl_id_bloqueado" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdEnun" colspan="3">Nº contrato</td>
        <td class="formHorTdEnun">Observación</td>
    </tr>
    <tr>
        <td class="formHorTdDato"><asp:TextBox ID="txt_numero" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="rfv_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" Text="*"></asp:RequiredFieldValidator></td>
        <td><asp:RegularExpressionValidator ID="rev_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*"></asp:RegularExpressionValidator></td>
        <td class="formTdDato"><asp:TextBox ID="txt_observacion" runat="server" SkinID="txtSingleLine400" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdMsg" colspan="5">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_contrato" runat="server" ValidationGroup="contrato" />
        </td>
    </tr>
</table>
