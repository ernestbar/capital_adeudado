<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Documentos adjuntos al contrato" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>

<%@ Register src="~/recurso/contrato/archivoAdjunto/userControl/adjuntoAbm.ascx" tagname="adjuntoAbm" tagprefix="uc4" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "archivoAdjunto", "view") Then
                MultiView1.ActiveViewIndex = 0
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
        adjuntoAbm1.id_contrato = ContratoDatos1.id_contrato
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
        <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="archivoAdjunto" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Documentos adjuntos al contrato</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_adjunto" runat="server" GroupingText="Archivos adjuntos al contrato">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr><td><uc4:adjuntoAbm ID="adjuntoAbm1" runat="server" /></td></tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

