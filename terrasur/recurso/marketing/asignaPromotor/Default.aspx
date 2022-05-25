<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cambio de asignación de promotores" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/marketing/asignaPromotor/userControl/asignaPromotorAbm.ascx" TagName="asignaPromotorAbm" TagPrefix="uc4" %>
<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_asignacion") = False _
            And permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_comision") = False Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        'Se verifica que el estado sea Preasignado o vigente
        If estado = 0 Or estado = 1 Then
            Dim ap As New asignacion_promotor(ContratoBusqueda1.id_resultado)
            Dim c As New contrato(ContratoBusqueda1.id_resultado)
            'If ciclo_comercial.VerificarMismoCiclo(c.fecha, DateTime.Now) = True Then
                If ap.id_grupopromotor = 0 Or (ap.monto_comision < ap.comision_total And ap.id_grupopromotor > 0) Then
                    If asignacion_promotor.PermitirModificar(ContratoBusqueda1.id_resultado) Then
                        ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
                        AsignaPromotorAbm1.id_contrato = ContratoBusqueda1.id_resultado
                        btn_cambiar.Enabled = True
                        MultiView1.ActiveViewIndex = 1
                    Else
                        Msg1.Text = "No esta permitido modificar la asignación de este contrato, porque ya fue modificada previamente"
                    End If
                Else
                    Msg1.Text = "El monto total de la comisión ya fue pagado"
                End If
            'Else
            '    Msg1.Text = "El contrato fue registrado en un ciclo comercial diferente al actual"
            'End If
        Else
            Msg1.Text = "Solo puede modificarse la asignación de contratos Preasignados o Vigentes y el estado actual del contrato es: " & contrato.Estado_string(ContratoBusqueda1.id_resultado, DateTime.Now)
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_cambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        If AsignaPromotorAbm1.Verificar Then
            If AsignaPromotorAbm1.Modificar() Then
                ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
                btn_cambiar.Enabled = False
            End If
        End If
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="asignaPromotor"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Cambio de asignación de promotores</td></tr>
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
                                    <asp:Panel ID="panel_cambio" runat="server" GroupingText="">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr>
                                                <td class="tdGrid">
                                                    <uc4:asignaPromotorAbm ID="AsignaPromotorAbm1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdButtonRealizarAccion">
                                                    <asp:Button ID="btn_cambiar" runat="server" Text="Modificar asignación" TextoEnviando="Modificando asignación" OnClientClick="return confirm('¿Esta seguro que desea modificar la asignación?');" CausesValidation="true" ValidationGroup="asignacion" />
                                                    <asp:Button ID="btn_volver" runat="server" Text="Cancelar / Volver" SkinID="btnVolver" CausesValidation="false" />
                                                </td>
                                            </tr>
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
