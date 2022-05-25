<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reprogramación de contratos" %>

<%@ Register Src="~/recurso/contrato/reprogramacion/userControl/reprogramacionFormFechaInteres.ascx" TagName="reprogramacionFormFechaInteres" TagPrefix="uc6" %>
<%@ Register Src="~/recurso/contrato/reprogramacion/userControl/reprogramacionFomrPlanPago.ascx" TagName="reprogramacionFormPlanPago" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewPlanPago.ascx" TagName="contratoViewPlanPago" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reprogramacion", "reprogramar") Then
                panel_cambio_fecha_interes.Visible = Profile.entorno.codigo_modulo.Equals("adm")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        Dim codigo_moneda As String = New moneda(c.id_moneda).codigo
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        If c.estado_id <> 2 And c.estado_id <> 3 And c.estado_id <> 0 Then
            panel_cambio.GroupingText = "Reprogramación de contrato"
            ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
            Id_contrato.Text = ContratoDatos1.id_contrato
            btn_confirmar.Enabled = True
            
            Dim num_seguro As Integer = New seguro_provida(c.id_contrato).numero
            If c.id_planpago_vigente > 0 Then
                Dim pp As New plan_pago(c.id_planpago_vigente)
                ContratoViewPlanPago1.Cargar(pp.num_cuotas, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente, pp.cuota_base, pp.fecha_inicio_plan, codigo_moneda, num_seguro)
                ReprogramacionFormPlanPago1.id_contrato = c.id_contrato
                If c.venta_lote = True Then
                    ReprogramacionFormPlanPago1.Reset(c.id_planpago_vigente, 0, New contrato_venta(c.id_contrato).id_lote, c.precio_final, c.cuota_inicial, codigo_moneda)
                Else
                    ReprogramacionFormPlanPago1.Reset(c.id_planpago_vigente, 0, 0, c.precio_final, c.cuota_inicial, codigo_moneda)
                End If
                ReprogramacionFormFechaInteres1.Fecha_inicio_plan = pp.fecha_inicio_plan
                MultiView1.ActiveViewIndex = 1
            Else
                ContratoViewPlanPago1.Cargar(c.num_cuotas, c.seguro, c.mantenimiento_sus, c.interes_corriente, c.cuota_base, c.fecha_inicio_plan, codigo_moneda, num_seguro)
                If c.venta_lote = True Then
                    ReprogramacionFormPlanPago1.Reset(0, c.id_contrato, New contrato_venta(c.id_contrato).id_lote, c.precio_final, c.cuota_inicial, codigo_moneda)
                Else
                    ReprogramacionFormPlanPago1.Reset(0, c.id_contrato, 0, c.precio_final, c.cuota_inicial, codigo_moneda)
                End If
                ReprogramacionFormFechaInteres1.Fecha_inicio_plan = c.fecha_inicio_plan
                MultiView1.ActiveViewIndex = 1
            End If
            ReprogramacionFormFechaInteres1.id_ultimo_pago = c.id_ultimo_pago
            ReprogramacionFormFechaInteres1.Reset()
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    
    Protected Sub btn_asignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click
        'If ReprogramacionFormPlanPago1.Verificar(Id_contrato.Text) Then
        If ReprogramacionFormPlanPago1.Insertar(Id_contrato.Text) Then
            Dim c As New contrato(ContratoBusqueda1.id_resultado)
            Dim codigo_moneda As String = New moneda(c.id_moneda).codigo
            Dim pp As New plan_pago(c.id_planpago_vigente)
            Dim num_seguro As Integer = New seguro_provida(c.id_contrato).numero
            ContratoViewPlanPago1.Cargar(pp.num_cuotas, pp.seguro, pp.mantenimiento_sus, pp.interes_corriente, pp.cuota_base, pp.fecha_inicio_plan, codigo_moneda, num_seguro)
            ReprogramacionFormPlanPago1.id_contrato = c.id_contrato
            'If c.venta_lote = True Then
            '    ReprogramacionFormPlanPago1.Reset(c.id_planpago_vigente, 0, New contrato_venta(c.id_contrato).id_lote, c.precio_final, c.cuota_inicial, codigo_moneda)
            'Else
            '    ReprogramacionFormPlanPago1.Reset(c.id_planpago_vigente, 0, 0, c.precio_final, c.cuota_inicial, codigo_moneda)
            'End If
            ReprogramacionFormFechaInteres1.Fecha_inicio_plan = pp.fecha_inicio_plan
            btn_confirmar.Enabled = False
            MultiView1.ActiveViewIndex = 1
        End If
        'End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reprogramacion" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<table class="priTable">
        <tr><td class="priTdTitle">Reprogramación de contratos</td></tr>
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
                                    <asp:Panel ID="panel_cambio" runat="server" DefaultButton="btn_confirmar">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_view_plan_pago_actual" runat="server" GroupingText="Plan de pagos actual">
                                                        <uc4:contratoViewPlanPago ID="ContratoViewPlanPago1" runat="server" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_view_plan_pago_nuevo" runat="server" GroupingText="Nuevo plan de pagos">
                                                        <uc5:reprogramacionFormPlanPago ID="ReprogramacionFormPlanPago1" runat="server" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                               <td  align="right">
                                                    <asp:ButtonAction ID="btn_confirmar" runat="server" Text="Confirmar Reprogramación"  TextoEnviando="Guardando" CausesValidation="true"
                                                        ValidationGroup="reprogramacion" />
                                               </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio_fecha_interes" runat="server" GroupingText="Cambio de fecha de interés del último pago">
                                        <uc6:reprogramacionFormFechaInteres ID="ReprogramacionFormFechaInteres1" runat="server" />
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

