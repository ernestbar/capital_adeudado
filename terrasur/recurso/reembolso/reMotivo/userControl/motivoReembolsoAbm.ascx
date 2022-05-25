<%@ Control Language="C#" ClassName="motivoReembolsoAbm" %>

<script runat="server">
    private int id_motivo { get { return int.Parse(lbl_id_motivo.Text); } set { lbl_id_motivo.Text = value.ToString(); } }

    public void CargarInsertar()
    {
        txt_codigo.Text = "";
        txt_nombre.Text = "";
        cb_activo.Checked = true;

        txt_codigo.Focus();
    }

    private bool VerificarInsertar()
    {
        bool correcto = true;
        if (terrasur.traspaso.motivo.VerificarCodigo(true, 0, txt_codigo.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El código introducido pertenece a otro motivo existente";
        }
        if (terrasur.traspaso.motivo.VerificarNombre(true, 0, txt_nombre.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El nombre introducido pertenece a otro motivo existente";
        }
        return correcto;
    }

    public bool Insertar()
    {
        if (VerificarInsertar())
        {
            terrasur.traspaso.motivo mObj = new terrasur.traspaso.motivo(txt_codigo.Text.Trim(), txt_nombre.Text.Trim(),cb_activo.Checked);
            if (mObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El motivo de reembolso se registró correctamente";
                CargarInsertar();
                return true;
            }
            else
            {
                Msg1.Text = "El motivo de reembolso NO se registró correctamente";
                return false;
            }
        }
        else { return false; }
    }


    public void CargarActualizar(int Id_motivo)
    {
        id_motivo = Id_motivo;

        terrasur.traspaso.motivo mObj = new terrasur.traspaso.motivo(id_motivo);
        txt_codigo.Text = mObj.codigo;
        txt_nombre.Text = mObj.nombre;
        cb_activo.Checked = mObj.activo;

        txt_codigo.Focus();
    }

    private bool VerificarActualizar()
    {
        bool correcto = true;
        if (terrasur.traspaso.motivo.VerificarCodigo(false, id_motivo, txt_codigo.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El código introducido pertenece a otro motivo existente";
        }
        if (terrasur.traspaso.motivo.VerificarNombre(false, id_motivo, txt_nombre.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El nombre introducido pertenece a otro motivo existente";
        }
        return correcto;
    }

    public bool Actualizar()
    {
        if (VerificarActualizar())
        {
            terrasur.traspaso.motivo mObj = new terrasur.traspaso.motivo(id_motivo, txt_codigo.Text.Trim(), txt_nombre.Text.Trim(), cb_activo.Checked);
            if (mObj.Actualizar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El motivo de reembolso se actualizó correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El motivo de reembolso NO se actualizó correctamente";
                return false;
            }
        }
        else { return false; }
    }
</script>
<asp:Label ID="lbl_id_motivo" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_motivo" runat="server" DisplayMode="List" ValidationGroup="motivo" />
        </td>
    </tr>
    <tr><td class="formTdTitle" colspan="2">Datos del motivo</td></tr>
    <tr>
        <td class="formTdEnun">Código:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" ValidationGroup="motivo" Text="*" ErrorMessage="Debe introducir el código del motivo"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nombre:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ValidationGroup="motivo" Text="*" ErrorMessage="Debe introducir el nombre del motivo"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Activo:</td>
        <td class="formTdDato">
            <asp:CheckBox ID="cb_activo" runat="server" Text="Motivo activo" />
        </td>
    </tr>
</table>