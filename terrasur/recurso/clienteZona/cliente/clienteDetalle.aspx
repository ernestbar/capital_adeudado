<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos del cliente" %>

<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteViewDato.ascx" TagName="clienteViewDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteViewDireccion.ascx" TagName="clienteViewDireccion" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteViewUpdate.ascx" TagName="clienteViewUpdate" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_cliente") IsNot Nothing Then
                ClienteViewDato1.id_cliente = Integer.Parse(Session("id_cliente").ToString)
                ClienteViewDireccion1.id_cliente = Integer.Parse(Session("id_cliente").ToString)
                ClienteViewUpdate1.id_cliente = Integer.Parse(Session("id_cliente").ToString)
                Dim c As New cliente(Integer.Parse(Session("id_cliente").ToString))
                Page.Title = "Datos del cliente - " & c.paterno & " " & c.materno & " " & c.nombres & " (" & c.ci & " " & c.codigo_lugarcedula & ")"
                Session.Remove("id_cliente")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="cliente" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Datos del cliente"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="Datos personales">
                                <uc1:clienteViewDato ID="ClienteViewDato1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_direccion" runat="server" Width="100%" GroupingText="Direcciones">
                                <uc2:clienteViewDireccion ID="ClienteViewDireccion1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_modificacion" runat="server" Width="100%" GroupingText="Última actualización de datos">
                                <uc4:clienteViewUpdate ID="ClienteViewUpdate1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
