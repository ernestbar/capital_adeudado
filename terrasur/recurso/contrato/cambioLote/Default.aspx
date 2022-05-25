<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cambio de Lote de un contrato" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/contrato/cambioLote/userControl/contratoCambioLote.ascx" TagName="contratoCambioLote" TagPrefix="uc4" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioLote", "cambiar_lote") = False Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        If c.estado_id <> 2 And c.estado_id <> 3 Then
            If c.venta_lote Then
                If c.contado = False Then
                    If c.id_ultimo_pago = 0 Or c.id_ultimo_pago = c.id_cuota_inicial Then
                        ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
                        ContratoCambioLote1.id_contrato = c.id_contrato
                        btn_cambiar.Enabled = True
                        MultiView1.ActiveViewIndex = 1
                    Else
                        Msg1.Text = "No se puede cambiar el lote de un contrato sobre el cual se realizaron pagos (posteriores a la cuota inicial)"
                    End If
                Else
                    Msg1.Text = "No se puede cambiar el lote de un contrato que se paga al contado"
                End If
            Else
                Msg1.Text = "Solo se puede cambiar el lote de un contrato de Venta de Lote"
            End If
        Else
            Msg1.Text = "No esta permitido cambiar el lote de contratos Revertidos o Liquidados"
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_cambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        If ContratoCambioLote1.Verificar Then
            Dim contratoObj As New contrato_venta(ContratoCambioLote1.id_contrato)
            If contratoObj.CambiarLote(ContratoCambioLote1.id_lote_nuevo, Profile.id_usuario) Then
                ContratoDatos1.id_contrato = ContratoCambioLote1.id_contrato
                btn_cambiar.Enabled = False
                Msg2.Text = "El lote del contrato se cambió correctamente"
            Else
                Msg2.Text = "El lote del contrato NO se cambió correctamente"
            End If
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cambioLote"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Cambio de Lote de un contrato</td></tr>
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
                                    <asp:Panel ID="panel_cambio" runat="server" GroupingText="Cambio de Lote de un contrato">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr><td class="tdGrid"><uc4:contratoCambioLote ID="ContratoCambioLote1" runat="server" /></td></tr>
                                            <tr><td class="tdMsg"><asp:Msg ID="Msg2" runat="server"></asp:Msg></td></tr>
                                            <tr><td class="tdButtonRealizarAccion"><asp:Button ID="btn_cambiar" runat="server" Text="Realizar cambio" TextoEnviando="Realizando el cambio" OnClientClick="return confirm('¿Esta seguro que desea cambiar el Lote del contrato?');" CausesValidation="true" ValidationGroup="contrato_lote"/></td></tr>
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
