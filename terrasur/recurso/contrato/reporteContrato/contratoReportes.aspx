<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            lkb_datos.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "datos")
            lkb_plan_original.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "plan_original")
            lkb_plan_restante.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "plan_restante")
            lkb_plan_vigente.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "plan_vigente")
            lkb_plan_vigente_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "plan_vigente_detalle")
            lkb_estado_cuenta.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "estado_cuenta")
            lkb_estado_cuenta_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "estado_cuenta_detalle")
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        panel_cambio.GroupingText = "Reportes de contratos"
        ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
        Id_contrato.Text = ContratoDatos1.id_contrato
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub lkb_datos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_datos.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp1.Show()
    End Sub

    Protected Sub lkb_estado_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_estado_cuenta.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp2.Show()
    End Sub

    Protected Sub lkb_estado_cuenta_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_estado_cuenta_detalle.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp3.Show()
    End Sub

    Protected Sub lkb_plan_original_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_plan_original.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp4.Show()
    End Sub

    Protected Sub lkb_plan_restante_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_plan_restante.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp5.Show()
    End Sub

    Protected Sub lkb_plan_vigente_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_plan_vigente_detalle.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp6.Show()
    End Sub

    Protected Sub lkb_plan_vigente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_plan_vigente.Click
        Session("id_contrato") = ContratoBusqueda1.id_resultado
        WinPopUp7.Show()
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContrato" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoDatosDetalle.aspx">
    </asp:WinPopUp>
<asp:WinPopUp id="WinPopUp2" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoEstadoCuenta.aspx">
    </asp:WinPopUp>
<asp:WinPopUp id="WinPopUp3" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoEstadoCuentaDetalle.aspx">
    </asp:WinPopUp>
<asp:WinPopUp id="WinPopUp4" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoPlanPagoOriginal.aspx">
   </asp:WinPopUp>
<asp:WinPopUp id="WinPopUp5" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoPlanPagoRestante.aspx">
    </asp:WinPopUp>
<asp:WinPopUp id="WinPopUp6" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoPlanPagoVigenteDetalle.aspx">
    </asp:WinPopUp>
<asp:WinPopUp id="WinPopUp7" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoPlanPagoVigente.aspx">
    </asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Reportes de contratos</td></tr>
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
                                    <asp:Panel ID="panel_cambio" runat="server">
                                        <table class="tableContenido" align="center">
                                            <tr>
                                                <td class="tdButtonNuevaBusqueda">
                                                    <asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td>
                                            </tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                    <uc3:contratoDatos ID="ContratoDatos1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                 <table align="center">
                                                    <tr><td>
                                                    <asp:Panel ID="panel_reportes" runat="server" GroupingText="Reportes">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_datos" runat="server">Contrato (datos detallados)</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_plan_original" runat="server">Plan de pagos original</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_plan_restante" runat="server" >Plan de pagos restante</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_plan_vigente" runat="server">Plan de pagos vigente</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_plan_vigente_detalle" runat="server">Plan de pagos vigente en detalle</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_estado_cuenta" runat="server">Estado de cuenta</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkb_estado_cuenta_detalle" runat="server">Estado de cuenta en detalle</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            </table>
                                                        </asp:Panel></td></tr>
                                                     </table>
                                                    
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

