<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Liquidación del contrato" %>

<%@ Register Src="~/recurso/caja/liquidacion/userControl/liquidacionViewServiciosVendidos.ascx" TagName="liquidacionViewServiciosVendidos" TagPrefix="uc7" %>
<%@ Register Src="~/recurso/caja/liquidacion/userControl/liquidacionViewDescuentoDpr.ascx" TagName="liquidacionViewDescuentoDpr" TagPrefix="uc6" %>
<%@ Register Src="~/recurso/caja/liquidacion/userControl/liquidacionViewDatos2.ascx" TagName="liquidacionViewDatos2" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/caja/liquidacion/userControl/liquidacionViewDatos1.ascx" TagName="liquidacionViewDatos1" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/caja/liquidacion/userControl/liquidacionContratoViewDatos.ascx" TagName="liquidacionContratoViewDatos" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc8" %>

<script runat="server"> 

    Protected Property strServ() As String
        Get
            Return lbl_strServ.Text
        End Get
        Set(ByVal value As String)
            lbl_strServ.Text = value
        End Set
    End Property

    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value

            lbl_precio_moneda.Text = "P.Unit.(" & value & ")"
            lbl_total_moneda.Text = "(" & value & ")"

            gv_servicios.Columns(3).HeaderText = "Precio unit.(" & value & ")"
            gv_servicios.Columns(4).HeaderText = "Precio total(" & value & ")"
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler CajaRealizarPago1.Eleccion_aceptar, AddressOf CajaRealizarPago_Aceptar
        AddHandler CajaRealizarPago1.Eleccion_cancelar, AddressOf CajaRealizarPago_Cancelar
        If Not Page.IsPostBack Then
            btn_proforma.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "liquidacion", "proforma_ver")
            Reporte1.Visible = False
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "liquidacion", "dpr") = True Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "liquidacion", "efectivo") = True Then
                btn_pagar.Enabled = True
            Else
                btn_pagar.Enabled = False
            End If
            If Session("id_contrato") IsNot Nothing Then
                lbl_id_contrato.Text = Session("id_contrato").ToString()
                LiquidacionContratoViewDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                LiquidacionViewDatos1_1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                LiquidacionViewDatos2_1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                If liquidacion.DescuentoDpr(Integer.Parse(Session("id_contrato").ToString())) > 0 Then
                    panel_descuentos_dpr.Visible = True
                    LiquidacionViewDescuentoDpr1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                Else
                    panel_descuentos_dpr.Visible = False
                End If
                If liquidacion.ListaServiciosLiquidablesVendidos(Integer.Parse(Session("id_contrato").ToString())).Rows.Count > 0 Then
                    panel_servicios_previos.Visible = True
                    LiquidacionViewServiciosVendidos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                Else
                    panel_servicios_previos.Visible = False
                End If
                Session.Remove("id_contrato")

                codigo_moneda = contrato.CodigoMoneda(Integer.Parse(lbl_id_contrato.Text))
            Else
                Response.Redirect("~/recurso/caja/contratoPago.aspx")
            End If
            CargarServiciosDefecto()
        End If
    End Sub

    Sub CargarServiciosDefecto()
        strServ = ""
        Dim tabla_paquete_principal As New System.Data.DataTable
        tabla_paquete_principal = servicio.ListaLiquidacionDefecto
        For Each row As System.Data.DataRow In tabla_paquete_principal.Rows
            RevisarServiciosCalculados(row("codigo").ToString(), Integer.Parse(row("id_servicio").ToString()), row("nombre").ToString(), 1, Decimal.Parse(row("valor_sus").ToString()), Boolean.Parse(row("facturar").ToString()))
        Next
        gv_servicios.DataBind()
    End Sub

    Sub RevisarServiciosCalculados(ByVal Codigo As String, ByVal Id_servicio As Integer, ByVal Nombre As String, ByVal Unidades As Integer, ByVal Valor_unitario As Decimal, ByVal Facturar As Boolean)
        If Codigo.ToUpper() = "ITR" Then
            Dim ITR As Decimal = 0
            Dim c As New contrato(Integer.Parse(lbl_id_contrato.Text))
            ITR = Math.Round(logica.ServicioLiquidacionITRCalculado(c.precio_final, liquidacion.DescuentoDpr(Integer.Parse(lbl_id_contrato.Text))), 2)
            If ITR > 0 Then
                strServ = tmpServicio.Insertar(strServ, Id_servicio, Nombre & " (" & (New parametro("it").valor.ToString()) & ")", 1, ITR, ITR, Facturar, "")
            Else
                'Msg1.Text = "El Impuesto Transferencia calculado es 0"
            End If
        Else
            If Codigo.ToUpper() = "DRE" Then
                Dim DRE As Decimal = 0
                Dim c As New contrato(Integer.Parse(lbl_id_contrato.Text))
                DRE = Math.Round(logica.ServicioLiquidacionDRECalculado(c.precio_final, liquidacion.DescuentoDpr(Integer.Parse(lbl_id_contrato.Text))), 2)
                If DRE > 0 Then
                    strServ = tmpServicio.Insertar(strServ, Id_servicio, Nombre & " (" & (New parametro("ddrr").valor.ToString()) & ")", 1, DRE, DRE, Facturar, "")
                Else
                    'Msg1.Text = "El servicio de Derechos Reales calculado es 0"
                End If
            Else
                Dim factor As Decimal = 1
                If codigo_moneda = "Bs" Then
                    factor = New tipo_cambio(DateTime.Now).compra
                End If

                If Codigo.ToUpper() = "IMP" Then
                    Dim IMP As Decimal = 0
                    Dim c As New contrato(Integer.Parse(lbl_id_contrato.Text))
                    IMP = Math.Round(logica.ServicioLiquidacionIMPCalculado(Integer.Parse(logica.AñosContrato(c.fecha, New pago(c.id_ultimo_pago).fecha_proximo)), New contrato_venta(c.id_contrato).superficie_m2), 2)
                    IMP = IMP * factor
                    If IMP > 0 Then
                        strServ = tmpServicio.Insertar(strServ, Id_servicio, Nombre & " (" & (New parametro("factor_impuestos").valor.ToString()) & ")", 1, IMP, IMP, Facturar, "")
                    Else
                        'Msg1.Text = "El Impuesto al contrato calculado es 0"
                    End If
                Else
                    strServ = tmpServicio.Insertar(strServ, Id_servicio, Nombre, Unidades, Valor_unitario * factor, Valor_unitario * factor * Unidades, Facturar, "")
                End If
            End If
        End If
    End Sub

    Sub AgregarServicio(ByVal Codigo As String, ByVal Id_servicio As Integer, ByVal Nombre As String, ByVal Unidades As Integer, ByVal Valor_unitario As Decimal, ByVal Facturar As Boolean)
        strServ = tmpServicio.Insertar(strServ, Id_servicio, Nombre, Unidades, Valor_unitario, Valor_unitario * Unidades, Facturar, "")
    End Sub

    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        If gv_servicios.Rows.Count > 0 Then
            Dim permiso_efectivo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "liquidacion", "efectivo")
            Dim con_factura As Boolean = False
            For Each row As GridViewRow In Me.gv_servicios.Rows
                Dim chk As CheckBox = CType(gv_servicios.Rows.Item(row.RowIndex).Cells(5).Controls.Item(0), CheckBox)
                If chk.Checked = True Then
                    con_factura = True
                    Exit For
                End If
            Next

            CajaRealizarPago1.Cargar(tmpServicio.PrecioTotal(strServ), permiso_efectivo.Equals(False), False, con_factura, Integer.Parse(lbl_id_contrato.Text), codigo_moneda)
            MultiView1.ActiveViewIndex = 1

            btn_otro_contrato.Visible = False
            btn_otro_pago.Visible = False
        Else
            Msg1.Text = "No se agregó ningún servicio."
        End If
    End Sub

    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id_transaccion As String = liquidacion.Insertar_PagoLiquidacion_VARIOS_PAGOS(Profile.id_usuario, Profile.entorno.id_rol, Integer.Parse(lbl_id_contrato.Text), CajaRealizarPago1.dato_id_recibo_cobrador, strServ, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar)
        If id_transaccion <> "" Then
            Msg2.Text = "PAGO REALIZADO"
            'En este punto se despliegan: la factura, el recibo y el comprobante
            CajaRealizarPago1.Pago_Realizado(id_transaccion.ToString)
        Else
            Msg2.Text = "EL PAGO NO SE REALIZÓ CORRECTAMENTE"
        End If
    End Sub

    Protected Sub CajaRealizarPago_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
        Reporte1.Visible = False

        btn_otro_contrato.Visible = True
        btn_otro_pago.Visible = True
    End Sub

    Protected Sub ddl_servicio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarDatosServicio()
    End Sub

    Protected Sub ddl_servicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarDatosServicio()
        Reporte1.Visible = False
    End Sub

    Sub CargarDatosServicio()
        If (ddl_servicio.Items.Count > 0) Then
            Dim servicioObj As New servicio(Int32.Parse(ddl_servicio.SelectedValue))
            Dim c As New contrato(Integer.Parse(lbl_id_contrato.Text))

            Dim precio As Decimal = 0
            Dim factor As Decimal = 1
            If codigo_moneda = "Bs" Then
                factor = New tipo_cambio(DateTime.Now).compra
            End If

            If servicioObj.codigo.ToUpper() = "ITR" Then
                OcultarUnidadesPrecio()
                'txt_precio.Enabled = True
                precio = logica.ServicioLiquidacionITRCalculado(c.precio_final, liquidacion.DescuentoDpr(Integer.Parse(lbl_id_contrato.Text)))
            Else
                If servicioObj.codigo.ToUpper() = "DRE" Then
                    OcultarUnidadesPrecio()
                    'txt_precio.Enabled = True
                    precio = logica.ServicioLiquidacionDRECalculado(c.precio_final, liquidacion.DescuentoDpr(Integer.Parse(lbl_id_contrato.Text)))
                Else
                    If servicioObj.codigo.ToUpper() = "IMP" Then
                        OcultarUnidadesPrecio()
                        'txt_precio.Enabled = True
                        precio = logica.ServicioLiquidacionIMPCalculado(Integer.Parse(logica.AñosContrato(c.fecha, New pago(c.id_ultimo_pago).fecha_proximo)), New contrato_venta(c.id_contrato).superficie_m2)
                        precio = precio * factor
                    Else
                        MostrarUnidadesPrecio()
                        txt_unidades.Text = "1"
                        txt_unidades.Enabled = servicioObj.varios
                        precio = servicioObj.valor_sus
                        precio = precio * factor
                    End If
                End If
            End If

            txt_precio.Text = precio.ToString("F2")

            ddl_factura.SelectedValue = servicioObj.facturar.ToString()
            btn_agregar.Enabled = True
        Else
            btn_agregar.Enabled = False
        End If
    End Sub

    Sub MostrarUnidadesPrecio()
        'lbl_unidades.Visible = True

        'txt_unidades.Visible = True
        txt_unidades.Enabled = True
    End Sub

    Sub OcultarUnidadesPrecio()
        'lbl_unidades.Visible = False

        'txt_unidades.Visible = False
        txt_unidades.Enabled = False
        txt_unidades.Text = "1"
        'txt_precio.Text = "1"
    End Sub

    Protected Sub btn_agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Reporte1.Visible = False
        If (tmpServicio.Verificar(strServ, Int32.Parse(ddl_servicio.SelectedValue)) = False) Then
            Dim servObj As New servicio(Int32.Parse(ddl_servicio.SelectedValue))
            AgregarServicio(servObj.codigo, servObj.id_servicio, servObj.nombre, Int32.Parse(txt_unidades.Text.Trim()), Decimal.Parse(txt_precio.Text.Trim()), Boolean.Parse(ddl_factura.SelectedValue))
            'Msg1.Text = "El servicio elegido se agregó correctamente"
            'Msg1.Show = False
            gv_servicios.DataBind()
        Else
            Msg1.Text = "El servicio elegido ya se agregó previamente"
        End If
    End Sub

    Protected Sub gv_servicios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    CType(e.Row.Cells(0).Controls(0), LinkButton).OnClientClick = "return confirm('¿Esta seguro que desea retirar el servicio?');"
        'End If
    End Sub

    Protected Sub gv_servicios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If (e.CommandName = "retirar") Then
            strServ = tmpServicio.Eliminar(strServ, Int32.Parse(e.CommandArgument.ToString()))
            gv_servicios.DataBind()
            Reporte1.Visible = False
        End If
    End Sub

    Protected Sub gv_servicios_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        If (gv_servicios.Rows.Count > 0) Then
            Dim precio_total As Decimal = tmpServicio.PrecioTotal(strServ)
            lbl_total_pagar.Text = precio_total.ToString("F2")
        Else
            lbl_total_pagar.Text = "0"
        End If
    End Sub

    Protected Sub btn_proforma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_proforma.Click
        Dim rpt As New rpt_proformaLiquidacion()
        Dim c1 As New srpt_ContratoDatos1()
        Dim c2 As New srpt_proformaContratoDatos2()
        Dim dpr As New srpt_proformaDescuentosDpr()
        Dim serv As New srpt_proformaServicios()
        rpt.LlenarDatos(Integer.Parse(lbl_id_contrato.Text))
        rpt.subReport1.Report = c1
        c1.LlenarDatos(Integer.Parse(lbl_id_contrato.Text))
        rpt.subReport2.Report = c2
        c2.LlenarDatos(Integer.Parse(lbl_id_contrato.Text))
        If liquidacion.ListaDescuentoDpr(Integer.Parse(lbl_id_contrato.Text)).Rows.Count > 0 Then
            rpt.subReport3.Report = dpr
            dpr.CargarDatos(contrato.CodigoMoneda(Integer.Parse(lbl_id_contrato.Text)))
            dpr.DataSource = liquidacion.ListaDescuentoDpr(Integer.Parse(lbl_id_contrato.Text))
        End If
        If strServ <> "" Then
            rpt.subReport4.Report = serv
            serv.CargarDatos(contrato.CodigoMoneda(Integer.Parse(lbl_id_contrato.Text)))
            serv.DataSource = tmpServicio.TablaServicio(strServ)
        End If
        Reporte1.WebView.Report = rpt
        Reporte1.Visible = True
    End Sub

    Protected Sub btn_otro_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_otro_contrato.Click
        Response.Redirect("~/recurso/caja/contratoPago.aspx")
    End Sub
    Protected Sub btn_otro_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_otro_pago.Click
        Session("id_contrato") = Integer.Parse(lbl_id_contrato.Text)
        Response.Redirect("~/recurso/caja/contratoPago.aspx")
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:cajaMaster ID="CajaMaster1" runat="server" tipo_pago="liquidacion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_venta_lote" runat="server" Text="True" Visible="false"></asp:Label>
    <asp:Label ID="lbl_strServ" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_id_contrato" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Liquidación del contrato</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdButtonNuevaBusqueda" colspan="2">
                            <asp:Button ID="btn_otro_contrato" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" />
                            <asp:Button ID="btn_otro_pago" runat="server" Text="Realizar otro pago" SkinID="btnVolver" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdEncabezado" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="panel_contrato" runat="server" GroupingText="Contrato">
                                <uc2:liquidacionContratoViewDatos ID="LiquidacionContratoViewDatos1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:Panel ID="panel_datos1" runat="server" GroupingText=" ">
                                <uc4:liquidacionViewDatos1 ID="LiquidacionViewDatos1_1" runat="server" />
                            </asp:Panel>
                        </td>
                        <td width="50%">
                            <asp:Panel ID="panel_datos2" runat="server" GroupingText=" ">
                                <uc5:liquidacionViewDatos2 ID="LiquidacionViewDatos2_1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View1" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_descuentos_dpr" runat="server" GroupingText="Descuentos por DPR's">
                                                <uc6:liquidacionViewDescuentoDpr ID="LiquidacionViewDescuentoDpr1" runat="server" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_servicios_previos" runat="server" GroupingText="Servicios (liquidación) comprados previamente">
                                                <uc7:liquidacionViewServiciosVendidos ID="LiquidacionViewServiciosVendidos1" runat="server" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_pago" runat="server" GroupingText="Servicios que forman parte de la liquidación" DefaultButton="btn_pagar">
                                                <table class="cajaPagoTable">
                                                    <tr>
                                                        <td class="cajaPagoTdContenido">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" RenderMode="Inline" UpdateMode="Always">
                                                                <ContentTemplate>
                                                            <table align="center" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <table align="left">
                                                                            <tr>
                                                                                <td class="contratoFormTdMsg" colspan="5">
                                                                                    <asp:Label ID="Msg1" runat="server" SkinID="lblMsg" EnableViewState="false"></asp:Label>
                                                                                    <asp:ValidationSummary ID="vs_servicio" runat="server" DisplayMode="List" ValidationGroup="servicio" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="contratoFormTdHorEnun">Servicio</td>
                                                                                <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_unidades" runat="server" Text="Nº unid./cuo."/></td>
                                                                                <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_precio_moneda" runat="server" Text="P.Unit.($us)"/></td>
                                                                                <td class="contratoFormTdHorEnun">Emitir Fact.</td>
                                                                                <td class="contratoFormTdHorEnun">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="contratoFormTdHorDato">
                                                                                    <asp:DropDownList ID="ddl_servicio" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_servicio" DataSourceID="ods_lista_servicio_activo" OnDataBound="ddl_servicio_DataBound" OnSelectedIndexChanged="ddl_servicio_SelectedIndexChanged"></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="rfv_servicio" runat="server" ControlToValidate="ddl_servicio" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="Debe elegir un servicio"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td class="contratoFormTdHorDato">
                                                                                    <asp:TextBox ID="txt_unidades" runat="server" SkinID="txtSingleLine50" MaxLength="3"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfv_unidades" runat="server" ControlToValidate="txt_unidades" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="Debe introducir el Nº de unidades"></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="rv_unidades" runat="server" ControlToValidate="txt_unidades" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Type="Integer" MinimumValue="1" MaximumValue="999" Text="*" ErrorMessage="El Nº de unidades debe ser un número entero positivo"></asp:RangeValidator>
                                                                                </td>
                                                                                <td class="contratoFormTdHorDato">
                                                                                    <asp:TextBox ID="txt_precio" runat="server" SkinID="txtSingleLine50" MaxLength="8" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfv_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="Debe introducir el Precio Unitario"></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="rv_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Type="Double" MinimumValue="0,01" MaximumValue="99999" Text="*" ErrorMessage="El precio unitario debe ser un número positivo"></asp:RangeValidator>
                                                                                </td>
                                                                                <td class="contratoFormTdHorDato">
                                                                                    <asp:RadioButtonList ID="ddl_factura" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                                                        <asp:ListItem Value="True" Selected="True" Text="Si"></asp:ListItem>
                                                                                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td class="contratoFormTdHorDato">
                                                                                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="servicio" OnClick="btn_agregar_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Panel ID="panel_pagos" runat="server">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:GridView ID="gv_servicios" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_servicios_tmp" DataKeyNames="id_servicio" OnRowDataBound="gv_servicios_RowDataBound" OnRowCommand="gv_servicios_RowCommand" OnDataBound="gv_servicios_DataBound">
                                                                                            <Columns>
                                                                                                <asp:ButtonField Text="Retirar" CommandName="retirar" ControlStyle-CssClass="gvButton" />
                                                                                                <asp:BoundField HeaderText="Servicio" DataField="nombre" />
                                                                                                <asp:BoundField HeaderText="Nº unidades" DataField="unidades" ItemStyle-CssClass="gvCell1" />
                                                                                                <asp:BoundField HeaderText="Precio unit. ($us)" DataField="precio_unitario" ItemStyle-CssClass="gvCell1"  DataFormatString="{0:F}"/>
                                                                                                <asp:BoundField HeaderText="Precio total ($us)" DataField="precio_total" ItemStyle-CssClass="gvCell1"  DataFormatString="{0:F}"/>
                                                                                                <asp:CheckBoxField HeaderText="Facturar" DataField="facturar" Text="emitir factura" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table align="center">
                                                                                <tr>
                                                                                    <td class="cajaPagoTdEnun">Total a pagar:</td>
                                                                                    <td class="cajaPagoTdDato"><asp:Label ID="lbl_total_pagar" runat="server"></asp:Label></td>
                                                                                    <td class="cajaPagoTdEnun"><asp:Label ID="lbl_total_moneda" runat="server" Text="($us)"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cajaPagoTdButton">
                                            <asp:Button ID="btn_proforma" runat="server" SkinID="btnCajaPago" Text="VER PROFORMA DE LIQUIDACION" CausesValidation="true" />
                                            <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" CausesValidation="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <uc8:reporte id="Reporte1" runat="server" Visible ="false" />
                                        </td>
                                    </tr>
                                </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <asp:Msg ID="Msg2" runat="server"></asp:Msg>
                                    <uc3:cajaRealizarPago ID="CajaRealizarPago1" runat="server" />
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr> 
                </table>
            </td>
        </tr>
    </table>
<%--  [id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo],[num_pagos]--%>
<asp:ObjectDataSource ID="ods_lista_servicio_activo" runat="server" TypeName="terrasur.servicio" SelectMethod="ListaActivosParaLiquidacion">
</asp:ObjectDataSource>
<%--[id_servicio],[nombre],[unidades],[precio_unitario],[precio_total]--%>
<asp:ObjectDataSource ID="ods_lista_servicios_tmp" runat="server" TypeName="terrasur.tmpServicio" SelectMethod="TablaServicio">
    <SelectParameters>
        <asp:ControlParameter Name="strServ" Type="String" ControlID="lbl_strServ" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>

</asp:Content>

