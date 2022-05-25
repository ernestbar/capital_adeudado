<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Contrato de venta de lote" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormPromotor.ascx" TagName="contratoFormPromotor" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormLote.ascx" TagName="contratoFormLote" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormVenta.ascx" TagName="contratoFormVenta" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormPlanPago.ascx" TagName="contratoFormPlanPago" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormTitular.ascx" TagName="contratoFormTitular" TagPrefix="uc6" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormCliente.ascx" TagName="contratoFormCliente" TagPrefix="uc7" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewPromotor.ascx" TagName="contratoViewPromotor" TagPrefix="uc8" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewLote.ascx" TagName="contratoViewLote" TagPrefix="uc9" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewVenta.ascx" TagName="contratoViewVenta" TagPrefix="uc10" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewPlanPago.ascx" TagName="contratoViewPlanPago" TagPrefix="uc11" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewTitular.ascx" TagName="contratoViewTitular" TagPrefix="uc12" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewCliente.ascx" TagName="contratoViewCliente" TagPrefix="uc13" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoFormLote1.LoteElegido, AddressOf cambio_lote
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "registrar") And tipo_cambio.Actual > 0 Then
                Reset()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub cambio_lote(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Req. Capital Adeudado
        If terrasur.capital_adeudado_urbanizacion.VerificarUrbanizacion(ContratoFormLote1.id_urbanizacion) Then
            ContratoFormVenta1.ResetCapAdeudado(ContratoFormLote1.precio_total)
        Else
            ContratoFormVenta1.Reset(ContratoFormLote1.precio_total)
        End If
        '
    End Sub

    Protected Sub Reset()
        Msg1.Show = True
        MostrarNumeroContrato()
        ContratoFormPromotor1.Reset()
        ContratoFormLote1.Reset()
        ContratoFormVenta1.Reset(0)
        ContratoFormPlanPago1.Reset(0, 0, 0)
        ContratoFormTitular1.Reset()
        ContratoFormCliente1.Reset(True)
        btn_step4_previous.Enabled = True
        btn_insertar.Enabled = True
        btn_step4_cancel.Visible = True
        MultiView1.ActiveViewIndex = 0
    End Sub
    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step2_cancel.Click, btn_step3_cancel.Click, btn_step4_cancel.Click
        Reset()
    End Sub


    Protected Sub btn_step1_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step1_next.Click
        MostrarNumeroContrato()
        If ContratoFormPromotor1.Verificar And ContratoFormLote1.Verificar And ContratoFormVenta1.Verificar(ContratoFormLote1.id_lote) Then
            ContratoFormPlanPago1.Reset(ContratoFormLote1.id_lote, ContratoFormVenta1.precio_final, ContratoFormVenta1.cuota_inicial)
            ContratoFormPlanPago1.codigo_moneda = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo
            If ContratoFormVenta1.contado Then
                MultiView1.ActiveViewIndex = 2
            Else
                'ContratoFormPlanPago1.Reset(ContratoFormLote1.id_lote, ContratoFormVenta1.precio_final, ContratoFormVenta1.cuota_inicial)
                MultiView1.ActiveViewIndex = 1
            End If
        End If
    End Sub

    
    Protected Sub btn_step2_previous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step2_previous.Click
        MostrarNumeroContrato()
        MultiView1.ActiveViewIndex = 0
    End Sub
    Protected Sub btn_step2_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step2_next.Click
        MostrarNumeroContrato()
        If ContratoFormPlanPago1.Verificar Then
            If ContratoFormPlanPago1.seguro > 0 Then
                If (New lote(ContratoFormLote1.id_lote)).nombre_negocio = "Boliviana de Bienes Raices" Then
                    MultiView1.ActiveViewIndex = 2
                Else
                    Msg1.Text = "Solo esta permitido asignar el seguro de desgravamen a contratos de BBR"
                End If
            Else
                MultiView1.ActiveViewIndex = 2
            End If
        End If
    End Sub
    
    
    Protected Sub btn_step3_previous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step3_previous.Click
        MostrarNumeroContrato()
        If ContratoFormVenta1.contado Then
            MultiView1.ActiveViewIndex = 0
        Else
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub
    Protected Sub btn_step3_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step3_next.Click
        MostrarNumeroContrato()
        If ContratoFormTitular1.Verificar AndAlso ContratoFormCliente1.Verificar Then
            If tmpCliente.Verificar(ContratoFormCliente1.strCl, ContratoFormTitular1.ci) Then
                Msg1.Text = "El primer titular del contrato no puede ser tambíén un titular adicional"
            Else
                Dim correcto As Boolean = True
                'Se verifica si el contrato tiene seguro de desgravamen
                If ContratoFormPlanPago1.seguro > 0 Then
                    'Se verifica que se haya introducido la fecha de nacimiento
                    If ContratoFormTitular1.fecha_nacimiento.Date = DateTime.Now.Date Then
                        Msg1.Text = "Debe introducir la fecha de nacimiento del primer titular"
                        correcto = False
                    Else
                        'Se verifica que el titular tena como máximo 65 años
                        If ContratoFormTitular1.fecha_nacimiento.AddYears(66) < DateTime.Now.Date.AddDays(1) Then
                            Msg1.Text = "El titular tiene más de 65 años y no puede acceder al seguro de desgravamen"
                            correcto = False
                        End If
                    End If
                    'If (New negocio_lote(ContratoFormLote1.id_lote)).negocio_nombre <> "Boliviana de Bienes Raices" Then
                    '    Msg1.Text = "Solo esta permitido asignar el seguro de desgravamen a contratos de BBR"
                    '    correcto = False
                    'End If
                End If
                If correcto = True Then
                    Dim codigom As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

                    ContratoViewPromotor1.id_grupopromotor = ContratoFormPromotor1.id_grupopromotor
                    ContratoViewLote1.Cargar(ContratoFormLote1.id_lote, codigom)
                    'ContratoViewLote1.id_lote = ContratoFormLote1.id_lote
                    If ContratoFormVenta1.cliente = "" And ContratoFormVenta1.nit = "" Then
                        ContratoFormVenta1.cliente = ContratoFormTitular1.paterno
                        ContratoFormVenta1.nit = ContratoFormTitular1.nit
                    End If
                    ContratoViewVenta1.Cargar(ContratoFormVenta1.precio, ContratoFormVenta1.desc_por, ContratoFormVenta1.desc_sus, ContratoFormVenta1.precio_final, ContratoFormVenta1.contado, ContratoFormVenta1.cuota_inicial, ContratoFormVenta1.cliente, ContratoFormVenta1.nit, ContratoFormVenta1.observacion, ContratoFormVenta1.preferencial, codigom, ContratoFormVenta1.capital_adeudado, ContratoFormVenta1.porcentaje_capital_deudor)
                    If ContratoFormVenta1.contado Then
                        ContratoViewPlanPago1.Cargar(0, 0, 0, 0, 0, DateTime.Now.Date, codigom, 0)
                        panel_view_plan_pago.Visible = False
                    Else
                        ContratoViewPlanPago1.Cargar(ContratoFormPlanPago1.num_cuotas, ContratoFormPlanPago1.seguro, ContratoFormPlanPago1.mantenimiento, ContratoFormPlanPago1.interes, ContratoFormPlanPago1.cuota_base, ContratoFormPlanPago1.fecha_inicio, codigom, ContratoFormPlanPago1.num_seguro)
                        panel_view_plan_pago.Visible = True
                    End If
                    ContratoViewTitular1.Cargar(ContratoFormTitular1.ci, ContratoFormTitular1.id_lugarcedula, ContratoFormTitular1.paterno, ContratoFormTitular1.materno, ContratoFormTitular1.nombres, ContratoFormTitular1.nit, ContratoFormTitular1.fecha_nacimiento, ContratoFormTitular1.celular, ContratoFormTitular1.fax, ContratoFormTitular1.email, ContratoFormTitular1.casilla, ContratoFormTitular1.domicilio_direccion, ContratoFormTitular1.domicilio_fono, ContratoFormTitular1.domicilio_id_zona, ContratoFormTitular1.oficina_direccion, ContratoFormTitular1.oficina_fono, ContratoFormTitular1.oficina_id_zona, ContratoFormTitular1.id_lugarcobro)

                    panel_view_cliente.Visible = ContratoFormCliente1.strCl.Equals("").Equals(False)
                    ContratoViewCliente1.lista_clientes = ContratoFormCliente1.strCl
                    MultiView1.ActiveViewIndex = 3
                End If
            End If
        End If
    End Sub

    Protected Sub btn_step4_previous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_step4_previous.Click
        MostrarNumeroContrato()
        MultiView1.ActiveViewIndex = 2
    End Sub


    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If estado_lote.VerificarDisponible(ContratoFormLote1.id_lote) = True Then
            Dim loteObj As New lote(ContratoFormLote1.id_lote)
            Dim contratoVentaObj As New contrato_venta(loteObj.id_lote, _
            loteObj.superficie_m2, loteObj.precio_m2_sus, loteObj.costo_m2_sus, _
            Integer.Parse(rbl_moneda.SelectedValue), contrato_venta.SiguienteNumero, ContratoFormVenta1.contado, ContratoFormVenta1.preferencial, _
            ContratoFormVenta1.precio, ContratoFormVenta1.desc_por, ContratoFormVenta1.desc_sus, _
            ContratoFormVenta1.precio_final, ContratoFormVenta1.cuota_inicial, _
            ContratoFormPlanPago1.num_cuotas, ContratoFormPlanPago1.seguro, ContratoFormPlanPago1.mantenimiento, _
            ContratoFormPlanPago1.interes, New parametro("tasa_mora").valor, ContratoFormPlanPago1.cuota_base, _
            ContratoFormPlanPago1.fecha_inicio, ContratoFormVenta1.observacion)
            If contratoVentaObj.Insertar(Profile.id_usuario) Then
                If contratoVentaObj.cvInsertar Then
                    'El estado del lote
                    Dim estadoLoteObj As New estado_lote(New estado("pre").id_estado, loteObj.id_lote, contratoVentaObj.id_contrato, 0, "")
                    estadoLoteObj.Insertar(Profile.id_usuario)
                    'El negocio del contrato
                    Dim negocioContratoObj As New negocio_contrato(New negocio_lote(loteObj.id_negociolote).id_negocio, contratoVentaObj.id_contrato, loteObj.id_negociolote, contratoVentaObj.precio_final, ContratoFormLote1.costo_total)
                    negocioContratoObj.Insertar(Profile.id_usuario)
                    'El promotor
                    If ContratoFormPromotor1.id_grupopromotor Then
                        Dim asignacionPromotorObj As New asignacion_promotor(contratoVentaObj.id_contrato, ContratoFormPromotor1.id_grupopromotor)
                        asignacionPromotorObj.Asignar(Profile.id_usuario)
                    End If
                    'El beneficiario de la factura
                    Dim beneficiarioFacturaObj As New beneficiario_factura(contratoVentaObj.id_contrato, ContratoFormVenta1.cliente, ContratoFormVenta1.nit)
                    beneficiarioFacturaObj.Asignar()
                    'El titular del contrato
                    If ContratoFormTitular1.id_cliente > 0 Then
                        Dim clienteContratoObj As New cliente_contrato(ContratoFormTitular1.id_cliente, contratoVentaObj.id_contrato, True)
                        clienteContratoObj.Insertar(Profile.id_usuario)
                    Else
                        Dim clienteTitularObj As New cliente(ContratoFormTitular1.id_lugarcedula, ContratoFormTitular1.id_lugarcobro, ContratoFormTitular1.ci, ContratoFormTitular1.nit, ContratoFormTitular1.nombres, ContratoFormTitular1.paterno, ContratoFormTitular1.materno, ContratoFormTitular1.fecha_nacimiento, ContratoFormTitular1.celular, ContratoFormTitular1.fax, ContratoFormTitular1.email, ContratoFormTitular1.casilla, ContratoFormTitular1.domicilio_direccion, ContratoFormTitular1.domicilio_fono, ContratoFormTitular1.domicilio_id_zona, ContratoFormTitular1.oficina_direccion, ContratoFormTitular1.oficina_fono, ContratoFormTitular1.oficina_id_zona, False)
                        If clienteTitularObj.Insertar(Profile.id_usuario) Then
                            Dim clienteContratoObj As New cliente_contrato(clienteTitularObj.id_cliente, contratoVentaObj.id_contrato, True)
                            clienteContratoObj.Insertar(Profile.id_usuario)
                        End If
                    End If
                    'Los titulares adicionales
                    If ContratoFormCliente1.strCl <> "" Then
                        Dim lista As System.Collections.Generic.List(Of tmpCliente) = tmpCliente.ListaCliente(ContratoFormCliente1.strCl)
                        For Each tmpCli As tmpCliente In lista
                            If tmpCli.id_cliente > 0 Then
                                Dim cliContratoObj As New cliente_contrato(tmpCli.id_cliente, contratoVentaObj.id_contrato, False)
                                cliContratoObj.Insertar(Profile.id_usuario)
                            Else
                                Dim clienteObj As New cliente(New lugar_cedula(tmpCli.codigo_lugar_cedula).id_lugarcedula, 0, tmpCli.ci, tmpCli.nit, tmpCli.nombres, tmpCli.paterno, tmpCli.materno, DateTime.Now, tmpCli.fono, "", tmpCli.email, "", "", "", 0, "", "", 0, False)
                                If clienteObj.Insertar(Profile.id_usuario) Then
                                    Dim cliContratoObj As New cliente_contrato(clienteObj.id_cliente, contratoVentaObj.id_contrato, False)
                                    cliContratoObj.Insertar(Profile.id_usuario)
                                End If
                            End If
                        Next
                    End If
                    'El número del formulario de seguro
                    If ContratoFormPlanPago1.num_seguro > 0 Then
                        Dim segObj As New seguro_provida(contratoVentaObj.id_contrato, Profile.id_usuario, ContratoFormPlanPago1.num_seguro)
                        segObj.Asignar(True)
                    End If
                    
                    ' Req. Capital Adeudado
                    If ContratoFormVenta1.capital_adeudado > 0 Then
                        Dim capitalAdeudadoObj As New capital_adeudado(ContratoFormVenta1.id_parametro_capital_deudor, contratoVentaObj.id_contrato, ContratoFormVenta1.capital_adeudado, DateTime.Today, Profile.id_usuario, True, DateTime.Today)
                        capitalAdeudadoObj.Insertar(Profile.id_usuario)
                    End If
                    '
                    
                    btn_step4_previous.Enabled = False
                    btn_insertar.Enabled = False
                    btn_step4_cancel.Visible = False

                    Msg1.Show = False
                    Msg1.Text = "El contrato se registró correctamente"
                    
                    
                    Session("id_contrato") = contratoVentaObj.id_contrato
                    WinPopUp1.Show()
                Else
                    Msg1.Text = "El contrato NO se registró correctamente"
                End If
            Else
                Msg1.Text = "El contrato NO se registró correctamente"
            End If
            
        Else
            Msg1.Text = "El lote elegido ya NO esta disponible"
        End If
    End Sub
    
    Protected Sub MostrarNumeroContrato()
        Dim SiguienteNumero As String = contrato_venta.SiguienteNumero
        lbl_numero_paso1.text = SiguienteNumero
        lbl_numero_paso2.text = SiguienteNumero
        lbl_numero_paso3.text = SiguienteNumero
        lbl_numero.Text = SiguienteNumero
        
        If rbl_moneda.Items.Count > 0 Then
            lbl_moneda_pago2.Text = rbl_moneda.SelectedItem.Text
            lbl_moneda_paso3.Text = rbl_moneda.SelectedItem.Text
            lbl_moneda.Text = rbl_moneda.SelectedItem.Text
        End If
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.FindByValue("$us") IsNot Nothing Then
            rbl_moneda.SelectedValue = "$us"
        ElseIf rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub

    Protected Sub rbl_moneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.SelectedIndexChanged
        Dim codigom As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo
        ContratoFormLote1.codigo_moneda = codigom
        ContratoFormVenta1.codigo_moneda = codigom
        ContratoFormVenta1.Reset(ContratoFormLote1.precio_total)
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="contratoLote" MostrarLink="true"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoPreasignacion.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="0" Win_Left="0" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="0" Win_Width="0">[WinPopUp1]</asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Contrato de venta de lote</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="formEntTable">
                    <tr>
                        <td>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="vs_contrato" runat="server" DisplayMode="List" ValidationGroup="contrato" />
                                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="formEntTdForm">
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View1" runat="server">
                                    <table align="center">
                                        <tr><td class="contratoWizardTitle">Paso 1 de 3 (El promotor, el lote y el contrato)</td></tr>
                                        <tr>
                                            <td class="contratoWizardStepTd">
                                                <table class="contratoWizardStepTable">
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td class="contratoNumeroEnun">Nº de contrato:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_numero_paso1" runat="server"></asp:Label></td>
                                                                    <td width="25px"></td>
                                                                    <td class="contratoNumeroEnun">Moneda:</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rbl_moneda" runat="server" SkinID="rblContratoMoneda" AutoPostBack="true" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo">
                                                                        </asp:RadioButtonList>
                                                                        <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                                                        <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_promotor" runat="server" GroupingText="Promotor" DefaultButton="btn_step1_next" CssClass="contratoWizardPanel">
                                                                <uc2:contratoFormPromotor ID="ContratoFormPromotor1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_lote" runat="server" GroupingText="Lote" DefaultButton="btn_step1_next" CssClass="contratoWizardPanel">
                                                                <uc3:contratoFormLote ID="ContratoFormLote1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_contrato" runat="server" GroupingText="Contrato de venta" DefaultButton="btn_step1_next" CssClass="contratoWizardPanel">
                                                                <uc4:contratoFormVenta ID="ContratoFormVenta1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="contratoFormTdButton">
                                                <asp:Button ID="btn_step1_next" runat="server" Text="Siguiente" SkinID="btnAccion" CausesValidation="true" ValidationGroup="contrato" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table align="center">
                                        <tr><td class="contratoWizardTitle">Paso 2 de 3 (El plan de pagos)</td></tr>
                                        <tr>
                                            <td class="contratoWizardStepTd">
                                                <table class="contratoWizardStepTable">
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td class="contratoNumeroEnun">Nº de contrato:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_numero_paso2" runat="server"></asp:Label></td>
                                                                    <td width="25px"></td>
                                                                    <td class="contratoNumeroEnun">Moneda:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_moneda_pago2" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_plan_pago" runat="server" GroupingText="Plan de pagos" DefaultButton="btn_step2_next" CssClass="contratoWizardPanel">
                                                                <uc5:contratoFormPlanPago ID="ContratoFormPlanPago1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="contratoFormTdButton">
                                                <asp:Button ID="btn_step2_previous" runat="server" Text="Anterior" SkinID="btnAccion" CausesValidation="false" />
                                                <asp:Button ID="btn_step2_next" runat="server" Text="Siguiente" SkinID="btnAccion" CausesValidation="true" ValidationGroup="contrato" />
                                                <asp:Button ID="btn_step2_cancel" runat="server" Text="Cancelar" SkinID="btnAccion" CausesValidation="false" OnClientClick="return confirm('¿Esta seguro que desea cancelar el registro del nuevo contrato?');" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <table align="center">
                                        <tr><td class="contratoWizardTitle">Paso 3 de 3 (El cliente)</td></tr>
                                        <tr>
                                            <td class="contratoWizardStepTd">
                                                <table class="contratoWizardStepTable">
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td class="contratoNumeroEnun">Nº de contrato:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_numero_paso3" runat="server"></asp:Label></td>
                                                                    <td width="25px"></td>
                                                                    <td class="contratoNumeroEnun">Moneda:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_moneda_paso3" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_titular" runat="server" GroupingText="Primer titular del contrato" DefaultButton="btn_step3_next" CssClass="contratoWizardPanel">
                                                                <uc6:contratoFormTitular ID="ContratoFormTitular1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_cliente" runat="server" GroupingText="Otros titulares del contrato" DefaultButton="btn_step3_next" CssClass="contratoWizardPanel">
                                                                <uc7:contratoFormCliente ID="ContratoFormCliente1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="contratoFormTdButton">
                                                <asp:Button ID="btn_step3_previous" runat="server" Text="Anterior" SkinID="btnAccion" CausesValidation="false" />
                                                <asp:Button ID="btn_step3_next" runat="server" Text="Finalizar" SkinID="btnAccion" CausesValidation="true" ValidationGroup="contrato" />
                                                <asp:Button ID="btn_step3_cancel" runat="server" Text="Cancelar" SkinID="btnAccion" CausesValidation="false" OnClientClick="return confirm('¿Esta seguro que desea cancelar el registro del nuevo contrato?');" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View4" runat="server">
                                    <table align="center">
                                        <tr><td class="contratoWizardTitle">Confirmación de los datos</td></tr>
                                        <tr>
                                            <td class="contratoWizardStepTd">
                                                <table class="contratoWizardStepTable">
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td class="contratoNumeroEnun">Nº de contrato:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_numero" runat="server"></asp:Label></td>
                                                                    <td width="25px"></td>
                                                                    <td class="contratoNumeroEnun">Moneda:</td>
                                                                    <td class="contratoNumeroDato"><asp:Label ID="lbl_moneda" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_view_promotor" runat="server" GroupingText="Promotor" CssClass="contratoWizardPanel">
                                                                <uc8:contratoViewPromotor ID="ContratoViewPromotor1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_view_lote" runat="server" GroupingText="Lote" CssClass="contratoWizardPanel">
                                                                <uc9:contratoViewLote ID="ContratoViewLote1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_view_contrato" runat="server" GroupingText="Contrato de venta" CssClass="contratoWizardPanel">
                                                                <uc10:contratoViewVenta ID="ContratoViewVenta1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_view_plan_pago" runat="server" GroupingText="Plan de pagos" CssClass="contratoWizardPanel">
                                                                <uc11:contratoViewPlanPago ID="ContratoViewPlanPago1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_view_titular" runat="server" GroupingText="Primer titular del contrato" CssClass="contratoWizardPanel">
                                                                <uc12:contratoViewTitular ID="ContratoViewTitular1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_view_cliente" runat="server" GroupingText="Otros titulares del contrato" CssClass="contratoWizardPanel">
                                                                <uc13:contratoViewCliente ID="ContratoViewCliente1" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="contratoFormTdButton">
                                                <asp:Button ID="btn_step4_previous" runat="server" Text="Anterior" SkinID="btnAccion" CausesValidation="false" />
                                                <asp:Button ID="btn_insertar" runat="server" Text="Realizar venta" SkinID="btnAccion" CausesValidation="true" ValidationGroup="contrato" />
                                                <asp:Button ID="btn_step4_cancel" runat="server" Text="Cancelar" SkinID="btnAccion" CausesValidation="false" OnClientClick="return confirm('¿Esta seguro que desea cancelar el registro del nuevo contrato?');" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

