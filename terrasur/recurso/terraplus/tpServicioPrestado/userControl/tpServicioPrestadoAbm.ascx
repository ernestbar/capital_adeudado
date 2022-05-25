<%@ Control Language="C#" ClassName="tpServicioPrestadoAbm" %>

<script runat="server">
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }

    public void Cargar(int Id_contrato)
    {
        id_contrato = Id_contrato;

        cp_fecha.SelectedDate = DateTime.Now;
        txt_ctto_renacer.Text = "";
        txt_observacion.Text = "";
    }

    private bool VerificarInsertar()
    {
        bool correcto = false;
        if (txt_ctto_renacer.Text.Trim() != "")
        {
            int ren_Id_contrato = 0; int ren_Codigo_estado = 0; string ren_Estado = ""; string ren_Codigo_moneda = ""; decimal ren_Saldo = 0;
            terrasur.traspaso.tmpContratoDestino.Renacer_BusquedaContrato(txt_ctto_renacer.Text.Trim(), DateTime.Now, ref ren_Id_contrato, ref ren_Codigo_estado, ref ren_Estado, ref ren_Codigo_moneda, ref ren_Saldo);
            if (ren_Id_contrato > 0)
            {
                if (ren_Codigo_estado != 2)
                {
                    if (ren_Saldo == 0)
                    {
                        correcto = true;
                    }
                    else { Msg1.Text = "El contrato " + txt_ctto_renacer.Text.Trim() + " todavía tienen un saldo de " + ren_Codigo_moneda + " " + ren_Saldo.ToString("N2") ; }
                }
                else { Msg1.Text = "El contrato " + txt_ctto_renacer.Text.Trim() + " se encuentra revertido"; }
            }
            else { Msg1.Text = "El contrato de Renacer: " + txt_ctto_renacer.Text.Trim() + ", no existe"; }


        }
        return correcto;
    }
    
    public bool Insertar()
    {
        if (VerificarInsertar())
        {
            terrasur.terraplus.tp_servicioPrestado spObj = new terrasur.terraplus.tp_servicioPrestado(id_contrato, cp_fecha.SelectedDate, txt_ctto_renacer.Text.Trim(), txt_observacion.Text.Trim());
            if (spObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "La prestación del servicio se registró correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "La prestación del servicio NO se registró correctamente";
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
            <asp:ValidationSummary ID="vs_terraplus" runat="server" DisplayMode="List" ValidationGroup="terraplus" />
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha del servicio:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. ctto. Renacer:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_ctto_renacer" runat="server" SkinID="txtSingleLine100" MaxLength="7"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_ctto_renacer" runat="server" ControlToValidate="txt_ctto_renacer" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de contrato de Renacer"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_ctto_renacer" runat="server" ControlToValidate="txt_ctto_renacer" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1000000" MaximumValue="9999999" Text="*" ErrorMessage="El número de contrato de Renacer contiene caracteres inválidos"></asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Observación:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" SkinID="txtMultiLine300x3"></asp:TextBox>
        </td>
    </tr>
</table>

