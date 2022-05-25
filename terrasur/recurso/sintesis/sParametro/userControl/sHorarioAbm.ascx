<%@ Control Language="C#" ClassName="sHorarioAbm" %>

<script runat="server">
    private bool permiso_modificar { get { return bool.Parse(lbl_permiso_modificar.Text); } set { lbl_permiso_modificar.Text = value.ToString(); } }

    public void Cargar()
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_horario", "view") == true)
        {
            panel_horario.Visible = true;
            permiso_modificar = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_horario", "update");
            Cargar_lun_vie();
            Cargar_sab();
            Cargar_dom();
        }
        else { panel_horario.Visible = false; }
    }
    public void Cargar_lun_vie()
    {
        tp_lun_vie_ini.Enabled = false;
        tp_lun_vie_fin.Enabled = false;

        terrasur.sintesis.s_horario h_lun_vie = new terrasur.sintesis.s_horario("lun_vie");
        tp_lun_vie_ini.SelectedTime = h_lun_vie.inicio;
        tp_lun_vie_fin.SelectedTime = h_lun_vie.fin;

        btn_modificar_lun_vie.Visible = permiso_modificar;
        btn_actualizar_lun_vie.Visible = false;
        btn_cancelar_lun_vie.Visible = false;
    }
    public void Cargar_sab()
    {
        tp_sab_ini.Enabled = false;
        tp_sab_fin.Enabled = false;

        terrasur.sintesis.s_horario h_sab = new terrasur.sintesis.s_horario("sab");
        tp_sab_ini.SelectedTime = h_sab.inicio;
        tp_sab_fin.SelectedTime = h_sab.fin;

        btn_modificar_sab.Visible = permiso_modificar;
        btn_actualizar_sab.Visible = false;
        btn_cancelar_sab.Visible = false;
    }
    public void Cargar_dom()
    {
        tp_dom_ini.Enabled = false;
        tp_dom_fin.Enabled = false;

        terrasur.sintesis.s_horario h_dom = new terrasur.sintesis.s_horario("dom");
        tp_dom_ini.SelectedTime = h_dom.inicio;
        tp_dom_fin.SelectedTime = h_dom.fin;

        btn_modificar_dom.Visible = permiso_modificar;
        btn_actualizar_dom.Visible = false;
        btn_cancelar_dom.Visible = false;
    }

    protected void btn_modificar_lun_vie_Click(object sender, EventArgs e)
    {
        tp_lun_vie_ini.Enabled = true;
        tp_lun_vie_fin.Enabled = true;
        
        btn_modificar_lun_vie.Visible = false;
        btn_actualizar_lun_vie.Visible = true;
        btn_cancelar_lun_vie.Visible = true;
    }

    protected void btn_modificar_sab_Click(object sender, EventArgs e)
    {
        tp_sab_ini.Enabled = true;
        tp_sab_fin.Enabled = true;

        btn_modificar_sab.Visible = false;
        btn_actualizar_sab.Visible = true;
        btn_cancelar_sab.Visible = true;
    }

    protected void btn_modificar_dom_Click(object sender, EventArgs e)
    {
        tp_dom_ini.Enabled = true;
        tp_dom_fin.Enabled = true;

        btn_modificar_dom.Visible = false;
        btn_actualizar_dom.Visible = true;
        btn_cancelar_dom.Visible = true;
    }


    protected void btn_actualizar_lun_vie_Click(object sender, EventArgs e)
    {
        terrasur.sintesis.s_horario h = new terrasur.sintesis.s_horario("lun_vie", tp_lun_vie_ini.SelectedTime, tp_lun_vie_fin.SelectedTime);
        if (h.Actualizar(Profile.id_usuario) == true)
        {
            Msg1.Text = "El horario de atención de Lunes a Viernes se actualizó correctamente";
            Cargar_lun_vie();
        }
        else { Msg1.Text = "El horario de atención de Lunes a Viernes NO se actualizó correctamente"; }
    }

    protected void btn_actualizar_sab_Click(object sender, EventArgs e)
    {
        terrasur.sintesis.s_horario h_sab = new terrasur.sintesis.s_horario("sab", tp_sab_ini.SelectedTime, tp_sab_fin.SelectedTime);
        if (h_sab.Actualizar(Profile.id_usuario) == true)
        {
            Msg1.Text = "El horario de atención del Sábado se actualizó correctamente";
            Cargar_sab();
        }
        else { Msg1.Text = "El horario de atención del Sábado NO se actualizó correctamente"; }
    }

    protected void btn_actualizar_dom_Click(object sender, EventArgs e)
    {
        terrasur.sintesis.s_horario h_dom = new terrasur.sintesis.s_horario("dom", tp_dom_ini.SelectedTime, tp_dom_fin.SelectedTime);
        if (h_dom.Actualizar(Profile.id_usuario) == true)
        {
            Msg1.Text = "El horario de atención del Domingo se actualizó correctamente";
            Cargar_dom();
        }
        else { Msg1.Text = "El horario de atención del Domingo NO se actualizó correctamente"; }
    }

    protected void btn_cancelar_lun_vie_Click(object sender, EventArgs e)
    {
        Cargar_lun_vie();
    }

    protected void btn_cancelar_sab_Click(object sender, EventArgs e)
    {
        Cargar_sab();
    }

    protected void btn_cancelar_dom_Click(object sender, EventArgs e)
    {
        Cargar_dom();
    }
</script>
<asp:Label ID="lbl_permiso_modificar" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Panel ID="panel_horario" runat="server" GroupingText="Horario de atención">
    <table align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_lun_vie_enun" runat="server" Text="Lunes a Viernes:" SkinID="lblEnun"></asp:Label></td>
            <td><ew:TimePicker ID="tp_lun_vie_ini" runat="server"></ew:TimePicker></td>
            <td><ew:TimePicker ID="tp_lun_vie_fin" runat="server"></ew:TimePicker></td>
            <td align="left">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:Button ID="btn_modificar_lun_vie" runat="server" Text="Modificar" OnClick="btn_modificar_lun_vie_Click" /></td>
                        <td><asp:Button ID="btn_actualizar_lun_vie" runat="server" Text="Actualizar" OnClick="btn_actualizar_lun_vie_Click" /></td>
                        <td><asp:Button ID="btn_cancelar_lun_vie" runat="server" Text="Cancelar" OnClick="btn_cancelar_lun_vie_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_sab_enun" runat="server" Text="Sábado:" SkinID="lblEnun"></asp:Label></td>
            <td><ew:TimePicker ID="tp_sab_ini" runat="server"></ew:TimePicker></td>
            <td><ew:TimePicker ID="tp_sab_fin" runat="server"></ew:TimePicker></td>
            <td align="left">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:Button ID="btn_modificar_sab" runat="server" Text="Modificar" OnClick="btn_modificar_sab_Click" /></td>
                        <td><asp:Button ID="btn_actualizar_sab" runat="server" Text="Actualizar" OnClick="btn_actualizar_sab_Click" /></td>
                        <td><asp:Button ID="btn_cancelar_sab" runat="server" Text="Cancelar" OnClick="btn_cancelar_sab_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_dom_enun" runat="server" Text="Domingo:" SkinID="lblEnun"></asp:Label></td>
            <td><ew:TimePicker ID="tp_dom_ini" runat="server"></ew:TimePicker></td>
            <td><ew:TimePicker ID="tp_dom_fin" runat="server"></ew:TimePicker></td>
            <td align="left">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:Button ID="btn_modificar_dom" runat="server" Text="Modificar" OnClick="btn_modificar_dom_Click" /></td>
                        <td><asp:Button ID="btn_actualizar_dom" runat="server" Text="Actualizar" OnClick="btn_actualizar_dom_Click" /></td>
                        <td><asp:Button ID="btn_cancelar_dom" runat="server" Text="Cancelar" OnClick="btn_cancelar_dom_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td colspan="4">
                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            </td>
        </tr>
    </table>
</asp:Panel>