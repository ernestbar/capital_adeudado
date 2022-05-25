<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Datos del Contrato" %>
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
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoDatosDetalle") Then
                recurso_intercambio()
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

        Dim regEm As New terrasur.emDoc.emision("dd_contrato", Contrato_id, Profile.id_usuario, 0, "", "")
        regEm.Registrar()

        Dim c As New contrato(Contrato_id)
        panel_cambio.GroupingText = "Datos de contrato"
        Dim dc As New rpt_contratoDatosDetalle()
        dc.Encabezado(Contrato_id)
        'Subreporte1  -> Datos del lote
        Dim srpt_lote As New srpt_DatosLoteServicio()
        srpt_lote.DatosLote(Contrato_id)
        dc.subReport1.Report = srpt_lote
        'Subreporte2  -> Datos del contrato
        Dim srpt_contrato As New srpt_DatosContrato()
        srpt_contrato.DatosContrato(Contrato_id)
        dc.subReport2.Report = srpt_contrato
        'Subreporte3  -> Datos del primer titular
        Dim srpt_titular As New srpt_DatosTitular()
        srpt_titular.DatosTitular(Contrato_id)
        dc.subReport3.Report = srpt_titular
        'Subreporte4  -> Datos de los otros titulares
        Dim tabla4 As Data.DataTable = cliente_contrato.ListaClientesAdicionales(Contrato_id)
        If tabla4.Rows.Count > 0 Then
            Dim srpt_titulares As New srpt_DatosOtrosTitulares()
            srpt_titulares.DataSource = tabla4
            dc.subReport4.Report = srpt_titulares
        End If
        'Subreporte5  -> Datos del plan de pagos vigente
        Dim srpt_plan_pagos As New srpt_PlanVigente()
        srpt_plan_pagos.DatosPlan(Contrato_id)
        dc.subReport5.Report = srpt_plan_pagos
        'Subreporte6  -> Datos de los anteriores planes no vigentes
        Dim tabla6 As Data.DataTable = plan_pago.ListaNoVigentes(Contrato_id)
        If tabla6.Rows.Count > 0 Then
            Dim srpt_otros_planes As New srpt_AnterioresPlanes()
            srpt_otros_planes.DataSource = tabla6
            srpt_otros_planes.DatosMoneda(c.codigo_moneda)
            dc.subReport6.Report = srpt_otros_planes
        End If
        'Subreporte7  -> Datos del estado de cuenta
        Dim srpt_estado As New srpt_EstadoCuenta()
        srpt_estado.DatosEstadoCuenta(Contrato_id)
        dc.subReport7.Report = srpt_estado
        'Subreporte8  -> Datos de pagos de intereses penales
        Dim tabla8 As Data.DataTable = pago_mora.ListaPorContrato(Contrato_id)
        If tabla8.Rows.Count > 0 Then
            Dim srpt_pagos_penales As New srpt_PagosPenales()
            srpt_pagos_penales.DataSource = tabla8
            srpt_pagos_penales.DatosMoneda(c.codigo_moneda)
            dc.subReport8.Report = srpt_pagos_penales
        End If
        'Subreporte9  -> Datos del promotor
        If c.id_promotor_vigente > 0 Then
            Dim srpt_promotor As New srpt_Promotor()
            srpt_promotor.DatosPromotor(Contrato_id)
            srpt_promotor.DataSource = asignacion_promotor.ListaComisiones(Contrato_id)
            dc.subReport9.Report = srpt_promotor
        End If
        'Subreporte10  -> Datos del cobrador
        If c.id_cobrador_vigente > 0 Then
            Dim srpt_cobrador As New srpt_Cobrador()
            srpt_cobrador.DatosCobrador(Contrato_id)
            dc.subReport10.Report = srpt_cobrador
        End If
        'Subreporte11  -> Servicios vendidos al contrato
        Dim tabla11 As Data.DataTable = servicio_vendido.ListaVendidosPorContrato(Contrato_id)
        If tabla11.Rows.Count > 0 Then
            Dim srpt_servicios As New srpt_Servicios()
            srpt_servicios.DataSource = tabla11
            srpt_servicios.DatosMoneda(c.codigo_moneda)
            dc.subReport11.Report = srpt_servicios
        End If


        Id_contrato.Text = Contrato_id
        Reporte1.WebView.Report = dc
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub recurso_intercambio()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("intercambio").id_recurso)
        'panel_intercambio.Visible = ver
        If ver Then
            btn_intercambio.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "view")
        End If
    End Sub

    Protected Sub btn_intercambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_intercambio.Click
        Response.Redirect("~/recurso/contrato/intercambio/Default.aspx")
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContrato" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<table class="priTable">
        <tr><td class="priTdTitle">Datos del Contrato</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                            <asp:Button ID="btn_intercambio" runat="server" Text="Ver Intercambios" SkinID="btnWebPart"/>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td align="left" style="width:800px;"><uc4:contratoDatosReembolso ID="contratoDatosReembolso1" runat="server" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc1:reporte ID="Reporte1" runat="server" /></td></tr>
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

