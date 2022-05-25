<%@ Page Language="C#" MasterPageFile="~/modulo/simple.master" Title="Datos del Traspaso/Devolución" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<script runat="server">
    protected int id_reembolso { get { return int.Parse(lbl_id_reembolso.Text); } set { lbl_id_reembolso.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["id_reembolso"] != null)
            {
                id_reembolso = int.Parse(Session["id_reembolso"].ToString());
                CargarReporte();
            }
        }
        //else { Page.Visible = false; }
    }

    protected void rbl_detalle_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarReporte();
    }

    protected void CargarReporte()
    {
        rpt_reembolso_simple reporte = new rpt_reembolso_simple();
        reporte.CargarDatos(id_reembolso, Profile.nombre_persona, rbl_detalle.SelectedValue.Equals("True"));
        Reporte1.WebView.Report = reporte;
        Session.Remove("id_reembolso");
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="traspaso" MostrarLink="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_reembolso" runat="server" Text="" Visible="false"></asp:Label>
    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td align="right">
                <asp:RadioButtonList ID="rbl_detalle" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="rbl_detalle_SelectedIndexChanged">
                    <asp:ListItem Text="Mostrar detalles" Value="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Sin detalle" Value="False"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:reporte ID="Reporte1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
