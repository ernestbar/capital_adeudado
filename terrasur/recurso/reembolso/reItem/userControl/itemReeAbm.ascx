<%@ Control Language="C#" ClassName="itemReeAbm" %>

<script runat="server">
    private int id_item { get { return int.Parse(lbl_id_item.Text); } set { lbl_id_item.Text = value.ToString(); } }

    public void CargarInsertar()
    {
        txt_codigo.Enabled = true; txt_nombre.Enabled = true; rbl_incremento.Enabled = true;
        
        txt_codigo.Text = "";
        txt_nombre.Text = "";
        rbl_incremento.SelectedValue = "true";
        
        cb_traspaso.Checked = false;
        cb_traspaso_por_defecto.Checked = false;
        cb_traspaso_por_defecto.Enabled = false;
        
        cb_devolucion.Checked = false;
        cb_devolucion_por_defecto.Checked = false;
        cb_devolucion_por_defecto.Enabled = false;

        txt_codigo.Focus();
    }

    private bool VerificarInsertar()
    {
        bool correcto = true;
        if (terrasur.traspaso.item.VerificarCodigo(true, 0, txt_codigo.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El código introducido pertenece a otro elemento existente";
        }
        if (terrasur.traspaso.item.VerificarNombre(true, 0, txt_nombre.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El nombre introducido pertenece a otro elemento existente";
        }
        return correcto;
    }

    public bool Insertar()
    {
        if (VerificarInsertar())
        {
            terrasur.traspaso.item iObj = new terrasur.traspaso.item(txt_codigo.Text.Trim(), txt_nombre.Text.Trim(), rbl_incremento.SelectedValue.Equals("true"), cb_traspaso.Checked, cb_traspaso_por_defecto.Checked, cb_devolucion.Checked, cb_devolucion_por_defecto.Checked);
            if (iObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El elemento de reembolso se registró correctamente";
                CargarInsertar();
                return true;
            }
            else
            {
                Msg1.Text = "El elemento de reembolso NO se registró correctamente";
                return false;
            }
        }
        else { return false; }
    }


    public void CargarActualizar(int Id_item)
    {
        id_item = Id_item;

        terrasur.traspaso.item iObj = new terrasur.traspaso.item(id_item);
        txt_codigo.Text = iObj.codigo;
        txt_nombre.Text = iObj.nombre;
        if (iObj.incremento) { rbl_incremento.SelectedValue = "true"; } else { rbl_incremento.SelectedValue = "false"; }

        if (",capital,interes,director,promotor,ica,adm,".Contains("," + iObj.codigo + ","))
        { txt_codigo.Enabled = false; txt_nombre.Enabled = false; rbl_incremento.Enabled = false; }
        else { txt_codigo.Enabled = true; txt_nombre.Enabled = true; rbl_incremento.Enabled = true; }
        

        cb_traspaso.Checked = iObj.traspaso;
        cb_traspaso_por_defecto.Checked = iObj.traspaso_por_defecto;
        cb_traspaso_por_defecto.Enabled = cb_traspaso.Checked;

        cb_devolucion.Checked = iObj.devolucion;
        cb_devolucion_por_defecto.Checked = iObj.devolucion_por_defecto;
        cb_devolucion_por_defecto.Enabled = cb_devolucion.Checked;

        txt_codigo.Focus();
    }

    private bool VerificarActualizar()
    {
        bool correcto = true;
        if (terrasur.traspaso.item.VerificarCodigo(false, id_item, txt_codigo.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El código introducido pertenece a otro elemento existente";
        }
        if (terrasur.traspaso.item.VerificarNombre(false, id_item, txt_nombre.Text.Trim()))
        {
            correcto = false;
            Msg1.Text = "El nombre introducido pertenece a otro elemento existente";
        }
        return correcto;
    }

    public bool Actualizar()
    {
        if (VerificarActualizar())
        {
            terrasur.traspaso.item iObj = new terrasur.traspaso.item(id_item, txt_codigo.Text.Trim(), txt_nombre.Text.Trim(), rbl_incremento.SelectedValue.Equals("true"), cb_traspaso.Checked, cb_traspaso_por_defecto.Checked, cb_devolucion.Checked, cb_devolucion_por_defecto.Checked);
            if (iObj.Actualizar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El elemento de reembolso se actualizó correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El elemento de reembolso NO se actualizó correctamente";
                return false;
            }
        }
        else { return false; }
    }
    
    
    protected void cb_traspaso_CheckedChanged(object sender, EventArgs e)
    {
        cb_traspaso_por_defecto.Enabled = cb_traspaso.Checked;
        cb_traspaso_por_defecto.Checked = false;
    }

    protected void cb_devolucion_CheckedChanged(object sender, EventArgs e)
    {
        cb_devolucion_por_defecto.Enabled = cb_devolucion.Checked;
        cb_devolucion_por_defecto.Checked = false;
    }
</script>
<asp:Label ID="lbl_id_item" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_item" runat="server" DisplayMode="List" ValidationGroup="item" />
        </td>
    </tr>
    <tr><td class="formTdTitle" colspan="2">Datos del elemento</td></tr>
    <tr>
        <td class="formTdEnun">Código:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" ValidationGroup="item" Text="*" ErrorMessage="Debe introducir el código del reembolso"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nombre:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ValidationGroup="item" Text="*" ErrorMessage="Debe introducir el nombre del reembolso"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Tipo:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_incremento" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Value="true" Text="Incremento" Selected="True"></asp:ListItem>
                <asp:ListItem Value="false" Text="Reducción"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Para:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:CheckBox ID="cb_traspaso" runat="server" Text="Traspaso" AutoPostBack="true" OnCheckedChanged="cb_traspaso_CheckedChanged" /></td>
                    <td><asp:CheckBox ID="cb_traspaso_por_defecto" runat="server" Text="Por defecto" Enabled="false" /></td>
                </tr>
                <tr>
                    <td><asp:CheckBox ID="cb_devolucion" runat="server" Text="Devolución" AutoPostBack="true" OnCheckedChanged="cb_devolucion_CheckedChanged" /></td>
                    <td><asp:CheckBox ID="cb_devolucion_por_defecto" runat="server" Text="Por defecto" Enabled="false" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>