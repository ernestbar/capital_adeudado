<%@ Control Language="C#" ClassName="sTipoCambioAbm" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_compra.Attributes["onfocus"] = "this.select();";
        txt_compra.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_compra.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_compra.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

        txt_oficial.Attributes["onfocus"] = "this.select();";
        txt_oficial.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_oficial.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_oficial.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

        txt_venta.Attributes["onfocus"] = "this.select();";
        txt_venta.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_venta.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_venta.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

    }

    public void Cargar()
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_tipo_cambio", "view") == true)
        {
            panel_tipo_cambio.Visible = true;

            txt_compra.Enabled = false;
            txt_oficial.Enabled = false;
            txt_venta.Enabled = false;

            terrasur.sintesis.s_tipo_cambio tc = new terrasur.sintesis.s_tipo_cambio(terrasur.sintesis.s_tipo_cambio.IdVigente(DateTime.Now));
            txt_compra.Text = tc.compra.ToString("N2");
            txt_oficial.Text = tc.oficial.ToString("N2");
            txt_venta.Text = tc.venta.ToString("N2");

            btn_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_tipo_cambio", "update");
            btn_actualizar.Visible = false;
            btn_cancelar.Visible = false;
        }
        else { panel_tipo_cambio.Visible = false; }
    }

    protected void btn_modificar_Click(object sender, EventArgs e)
    {
        txt_oficial.Focus();
        
        txt_compra.Enabled = true;
        txt_oficial.Enabled = true;
        txt_venta.Enabled = true;

        btn_modificar.Visible = false;
        btn_actualizar.Visible = true;
        btn_cancelar.Visible = true;
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        terrasur.sintesis.s_tipo_cambio tc = new terrasur.sintesis.s_tipo_cambio(DateTime.Now.Date, decimal.Parse(txt_oficial.Text.Trim()), decimal.Parse(txt_compra.Text.Trim()), decimal.Parse(txt_venta.Text.Trim()));
        if (tc.Registrar(Profile.id_usuario) == true)
        {
            Msg1.Text = "El tipo de cambio se actualizó correctamente";
            Cargar();
        }
        else { Msg1.Text = "El tipo de cambio NO se actualizó correctamente"; }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        Cargar();
    }
</script>

<asp:Panel ID="panel_tipo_cambio" runat="server" GroupingText="Tipo de cambio" DefaultButton="btn_actualizar">
    <table align="center">
        <tr>
            <td valign="bottom" align="right"><asp:TextBox ID="txt_compra" runat="server" MaxLength="5" Width="60" Height="30" Font-Bold="true" Font-Size="X-Large"></asp:TextBox></td>
            <td valign="bottom"><asp:TextBox ID="txt_oficial" runat="server" MaxLength="5" Width="80" Height="40" Font-Bold="true" Font-Size="XX-Large"></asp:TextBox></td>
            <td valign="bottom"><asp:TextBox ID="txt_venta" runat="server" MaxLength="5" Width="60" Height="30" Font-Bold="true" Font-Size="X-Large"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center"><asp:Label ID="lbl_compra" runat="server" Text="TC Compra" SkinID="lblEnun"></asp:Label></td>
            <td align="center"><asp:Label ID="lbl_oficial" runat="server" Text="TC OFICIAL" SkinID="lblEnun"></asp:Label></td>
            <td align="center"><asp:Label ID="lbl_venta" runat="server" Text="TC Venta" SkinID="lblEnun"></asp:Label></td>
        </tr>
        <tr>
            <td colspan=3 align=center>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:Button ID="btn_modificar" runat="server" Text="Modificar" OnClick="btn_modificar_Click" /></td>
                        <td><asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" /></td>
                        <td><asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            </td>
        </tr>
    </table>
</asp:Panel>