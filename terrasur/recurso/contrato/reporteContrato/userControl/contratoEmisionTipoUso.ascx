<%@ Control Language="C#" ClassName="contratoEmisionTipoUso" %>

<script runat="server">
    public bool interno { get { return rb_interno.Checked; } }
    public bool cliente { get { return rb_cliente.Checked; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Reset();
        }
    }

    public void Reset()
    {
        bool soloCliente = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "emisionDocCliente", "restringirSoloCliente");
        if (soloCliente == true) { if (Profile.entorno.codigo_modulo == "adm" || Profile.entorno.id_rol == 1) { soloCliente = false; } }

        if (soloCliente == true)
        {
            rb_interno.Enabled = false;
            rb_cliente.Enabled = false;

            rb_interno.Checked = false;
            rb_cliente.Checked = true;
        }
        else
        {
            rb_interno.Enabled = true;
            rb_cliente.Enabled = true;

            if (Profile.entorno.emision_tipo_uso == "cliente")
            {
                rb_interno.Checked = false;
                rb_cliente.Checked = true;
            }
            else
            {
                rb_interno.Checked = true;
                rb_cliente.Checked = false;
            }
        }
    }

    public void GuardarEleccion()
    {
        if (rb_cliente.Checked == true)
        { Profile.entorno.emision_tipo_uso = "cliente"; }
        else { Profile.entorno.emision_tipo_uso = "interno"; }
    }

</script>
<table cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td valign="middle"><asp:Label ID="lbl_tipo_enun" runat="server" Text="Emisión para:" SkinID="lblEnun" ForeColor="Blue"></asp:Label></td>
        <td valign="middle" style="width:10;"></td><%--USO INTERNO ENTREGA AL CLIENTE--%>
        <td valign="middle"><asp:RadioButton ID="rb_interno" runat="server" Text="Uso Interno" Checked="true" GroupName="uso" Font-Bold="true" Font-Size="Medium" ForeColor="Blue" /></td>
        <td valign="middle" style="width:10;"></td>
        <td valign="middle"><asp:RadioButton ID="rb_cliente" runat="server" Text="Entrega al Cliente" GroupName="uso" Font-Bold="true" Font-Size="Medium" ForeColor="Blue" /></td>
    </tr>
</table>