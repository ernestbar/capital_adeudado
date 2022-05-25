<%@ Page Language="C#" Title="Actualización de datos del Cliente" %>

<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteAbm.ascx" TagName="clienteAbm" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["id_cliente"] != null)
            {
                ClienteAbm1.CargarActualizar(Int32.Parse(Session["id_cliente"].ToString()));
                Session.Remove("id_cliente");
            }
        }
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (ClienteAbm1.VerificarActualizar() == true)
        {
            if (ClienteAbm1.Actualizar() == true)
                btn_actualizar.Enabled = false;
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tr>
                <td>
                    <uc1:clienteAbm ID="ClienteAbm1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar datos" CausesValidation="true" ValidationGroup="cliente" OnClick="btn_actualizar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar / Cerrar" CausesValidation="false" OnClientClick="javascript:window.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
