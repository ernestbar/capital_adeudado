<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cambio de Titular" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/contrato/cambioTitular/userControl/contratoCambioPrimerTitular.ascx" TagName="contratoCambioPrimerTitular" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/contrato/cambioTitular/userControl/contratoCambioOtroTitular.ascx" TagName="contratoCambioOtroTitular" TagPrefix="uc5" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "primer_titular") Or _
            permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "otro_titular") Then

            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim estado_id As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        If estado_id <> 2 And estado_id <> 3 Then
            ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
            ContratoCambioPrimerTitular1.id_contrato = ContratoBusqueda1.id_resultado
            ContratoCambioOtroTitular1.id_contrato = ContratoBusqueda1.id_resultado
            MultiView1.ActiveViewIndex = 1
        Else
            Msg1.Text = "No esta permitido cambiar el titular de contratos Revertidos o Liquidados"
        End If
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cambioTitular"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Cambio de Titular</td></tr>
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
                                    <asp:Panel ID="panel_cambio" runat="server" GroupingText="Cambio de Titular del contrato">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr><td class="contratoWizardStepTd"><uc4:contratoCambioPrimerTitular ID="ContratoCambioPrimerTitular1" runat="server" /></td></tr>
                                            <tr><td class="contratoWizardStepTd"><uc5:contratoCambioOtroTitular ID="ContratoCambioOtroTitular1" runat="server" /></td></tr>
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
