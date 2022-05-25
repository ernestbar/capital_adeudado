<%@ Control Language="C#" ClassName="clienteViewDato" %>

<script runat="server">
    public int id_cliente
    {
        set
        {
            cliente clienteObj = new cliente(value);
            if (clienteObj.ci.Trim() == "") lbl_ci.Text = "";
            else lbl_ci.Text = clienteObj.ci + " " + clienteObj.codigo_lugarcedula;
            lbl_paterno.Text = clienteObj.paterno;
            lbl_materno.Text = clienteObj.materno;
            lbl_nombres.Text = clienteObj.nombres;
            lbl_nit.Text = clienteObj.nit;

            if (clienteObj.fecha_nacimiento.Date == DateTime.Now.Date) lbl_fecha.Text = "";
            else lbl_fecha.Text = clienteObj.fecha_nacimiento.ToString("d");
            lbl_celular.Text = clienteObj.celular;
            lbl_fax.Text = clienteObj.fax;
            lbl_email.Text = clienteObj.email;
            lbl_casilla.Text = clienteObj.casilla;
        }
    }
</script>
<table class="viewHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_ci_enun" runat="server" Text="C.I."></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_paterno_enun" runat="server" Text="Ap.Paterno"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_materno_enun" runat="server" Text="Ap.Materno"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_nombres_enun" runat="server" Text="Nombre"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_nit_enun" runat="server" Text="NIT"></asp:Label></td>
    </tr>
    <tr>
        <td class="viewHorTdDato"><asp:Label ID="lbl_ci" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_paterno" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_materno" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_nombres" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_nit" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server" Text="F.Nacimiento"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_celular_enun" runat="server" Text="Celular"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_fax_enun" runat="server" Text="Fax"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_email_enun" runat="server" Text="Email"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_casilla_enun" runat="server" Text="Casilla"></asp:Label></td>
    </tr>
    <tr>
        <td class="viewHorTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_celular" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_fax" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_email" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_casilla" runat="server"></asp:Label></td>
    </tr>
</table>
