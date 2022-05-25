<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Plan de pagos vigente" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoDatosReembolso.ascx" tagname="contratoDatosReembolso" tagprefix="uc4" %>

<script runat="server"> 

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs)
        If Request.QueryString("t") IsNot Nothing AndAlso Session("id_contrato") IsNot Nothing Then
            Session.Remove("id_contrato")
        End If
        If Session("id_contrato") IsNot Nothing Then
            general.CambiarMasterPage(Me, False)
        End If
    End Sub

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoVigente") Then
                Page.Visible = True
                If Session("id_contrato") IsNot Nothing Then
                    'CargarReportes(Int32.Parse(Session("id_contrato")))
                    If contrato_estado_especial.BloquearContrato(Int32.Parse(Session("id_contrato")), Profile.entorno.codigo_modulo) = True Then
                        Page.Visible = False
                    Else
                        CargarReportes(Int32.Parse(Session("id_contrato")))
                    End If

                    Session.Remove("id_contrato")
                    btn_volver.Visible = False
                Else
                    btn_volver.Visible = True
                End If
                'lkb_plan_vigente_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoVigenteDetalle")
            Else
                If Session("id_contrato") IsNot Nothing Then
                    Page.Visible = False
                Else
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
            If Page.MasterPageFile.Contains("simple.master") Then
                Reporte1.Formato_Web = False
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        CargarReportes(ContratoBusqueda1.id_resultado)
    End Sub

    Sub CargarReportes(ByVal Contrato_id As Integer)
        contratoDatosReembolso1.id_contrato = Contrato_id
        
        Dim regEm As New terrasur.emDoc.emision("pp_vigente", Contrato_id, Profile.id_usuario, 0, "", "")
        regEm.Registrar()
        
        Dim c As New contrato(Contrato_id)
        panel_cambio.GroupingText = "Plan de pagos vigente"
        Dim ppr As New rpt_contratoPlanPagoVigente()
        ppr.DatosPlanPagosVigente(Contrato_id, Profile.nombre_persona)
        'If c.saldo_capital > 0 Then
        If c.id_planpago_vigente > 0 Then
            Dim pp As New plan_pago(c.id_planpago_vigente)
            Dim p As New pago(c.id_ultimo_pago)
            ppr.DataSource = contratoReporte.ReportePlanPagosVigente(Contrato_id, c.preferencial, pp.cuota_base, pp.num_cuotas, pp.fecha_inicio_plan, pp.interes_corriente, pp.seguro, pp.mantenimiento_sus)
        Else
            ppr.DataSource = contratoReporte.ReportePlanPagosOriginal(c.capital_pagado, c.saldo_capital, c.num_cuotas, 0, c.interes_corriente, c.seguro, c.mantenimiento_sus, c.fecha_inicio_plan)
        End If
        'End If
        Id_contrato.Text = Contrato_id
        Reporte1.WebView.Report = ppr
        MultiView1.ActiveViewIndex = 1
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    'Protected Sub lkb_plan_vigente_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkb_plan_vigente_detalle.Click
    '    Session("id_contrato") = Id_contrato.Text
    '    'Response.Redirect("~/recurso/contrato/reporteContrato/reporteContratoPlanPagoVigenteDetalle.aspx")
    '    WinPopUp1.NavigateUrl = "~/recurso/contrato/reporteContrato/reporteContratoPlanPagoVigenteDetalle.aspx"
    '    WinPopUp1.Show()
    'End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContrato" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
           <asp:Label runat="server" id="Id_contrato" Visible="false"  />
<table class="priTable">
        <tr><td class="priTdTitle">Plan de pagos vigente</td></tr>
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
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <%--<tr><td class="tdButtonNuevaBusqueda"><asp:LinkButton ID="lkb_plan_vigente_detalle" runat="server" OnClick="lkb_plan_vigente_detalle_Click" >Ver plan de pagos vigente en detalle</asp:LinkButton></td></tr>  --%>
                                            <tr><td align="left" style="width:800px;"><uc4:contratoDatosReembolso ID="contratoDatosReembolso1" runat="server" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc1:reporte ID="Reporte1" runat="server" /></td></tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                       <%-- <asp:WinPopUp id="WinPopUp1" runat="server"></asp:WinPopUp>--%>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

