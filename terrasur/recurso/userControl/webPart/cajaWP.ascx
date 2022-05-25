<%@ Control Language="VB" ClassName="cajaWP" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_parametrosCaja()
            recurso_tipocambio()
            recurso_contratoPago()
            recurso_contratoAnulacion()
            recurso_pagoServicioClienteTransitorios()
            recurso_anulacionServicioClienteTransitorios()
            recurso_anulacion()
            recurso_liquidacionReimprimir()
            recurso_reporte()
            recurso_reciboGastos()
            recurso_terraplus()
        End If
    End Sub

    
    Protected Sub recurso_parametrosCaja()
        If parametro_facturacion.ActivoActual = 0 Then
            msg_parametros.Text = "Todos los Negocios del Sistema deben tener asignada una razón social"
        End If
        If tipo_cambio.Actual = 0 Then
            msg_parametros.Text = "Se debe definir el Tipo de Cambio de hoy"
        End If
    End Sub
    
    
    Protected Sub recurso_tipocambio()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tipoCambio").id_recurso)
        panel_tipocambio.Visible = ver
        If ver Then
            lbl_tipocambio_fecha.Text = DateTime.Now.ToString("D")
            Dim tc As New tipo_cambio(DateTime.Now)
            If tc.id_tipocambio > 0 Then
                lbl_tipocambio_compra.Text = tc.compra.ToString("F2")
                lbl_tipocambio_venta.Text = tc.venta.ToString("F2")
            Else
                lbl_tipocambio_compra.Text = "----"
                lbl_tipocambio_venta.Text = "----"
                msg_tipocambio.Text = "Se debe definir el tipo de cambio de hoy"
            End If
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "insert") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "update") = True Then
                btn_tipocambio.Visible = True
            Else
                btn_tipocambio.Visible = False
            End If
            lb_tipocambio_historico.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "view")
        End If
    End Sub
    Protected Sub btn_tipocambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_tipocambio.Click
        Response.Redirect("~/recurso/caja/tipoCambio/Default.aspx")
    End Sub
    Protected Sub lb_tipocambio_historico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_tipocambio_historico.Click
        WinPopUp1.NavigateUrl = "~/recurso/caja/tipoCambio/tipoCambioHistorico.aspx"
        WinPopUp1.Show()
    End Sub

    
    Protected Sub recurso_contratoPago()
        Dim ver As Boolean = contrato.HabilitarPagosContrato(Profile.entorno.id_rol)
        panel_contratoPago.Visible = ver
        If ver Then
            btn_contratoPago.Visible = contrato.PermitirPagosContrato(Profile.id_usuario, Profile.entorno.id_rol)
        End If
    End Sub
    Protected Sub btn_contratoPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_contratoPago.Click
        Response.Redirect("~/recurso/caja/contratoPago.aspx")
    End Sub

    
    Protected Sub recurso_contratoAnulacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("anulacion").id_recurso)
        panel_contratoAnulacion.Visible = ver
        If ver Then
            btn_contratoAnulacion.Visible = contrato.PermitirAnulacionesContrato(Profile.id_usuario, Profile.entorno.id_rol)
        End If
    End Sub
    Protected Sub btn_contratoAnulacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_contratoAnulacion.Click
        Response.Redirect("~/recurso/caja/contratoAnulacion.aspx")
    End Sub
    
    
    Protected Sub recurso_pagoServicioClienteTransitorios()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("pagoOtroServicioNoCliente").id_recurso)
        panel_osnc.Visible = ver
        If ver Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoOtroServicioNoCliente", "dpr") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoOtroServicioNoCliente", "efectivo") = True Then
                btn_osnc.Visible = True
            Else
                btn_osnc.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_osnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_osnc.Click
        Response.Redirect("~/recurso/caja/pagoOtroServicioNoCliente/Default.aspx")
    End Sub

    
    Protected Sub recurso_anulacionServicioClienteTransitorios()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("anulacion").id_recurso)
        If ver Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "osnc_mes") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "osnc_dia") = True Then
                btn_aosnc.Visible = True
                panel_anulacionOsnc.Visible = True
            Else
                btn_aosnc.Visible = False
                panel_anulacionOsnc.Visible = False
            End If
        Else
            panel_anulacionOsnc.Visible = False
        End If
    End Sub
    Protected Sub btn_aosnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aosnc.Click
        Response.Redirect("~/recurso/caja/anulacion/anulacionVentaServiciosNoClientes.aspx")
    End Sub
    
    Protected Sub recurso_anulacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("anulacion").id_recurso)
        panel_anulacion.Visible = ver
        If ver Then
            Dim permiso_factura As Boolean = False, permiso_recibo As Boolean = False, permiso_dpr As Boolean = False
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_anular_dia") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_anular_mes") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_reimprimir") = True Then
                permiso_factura = True
            End If
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "recibo_anular_dia") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "recibo_anular_mes") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "recibo_reimprimir") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "recibo_bnb_reimprimir") = True Then
                permiso_recibo = True
            End If
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_anular_dia") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_anular_mes") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_reimprimir") = True Then
                permiso_dpr = True
            End If
            lb_anulacion_factura.Visible = permiso_factura
            lb_anulacion_recibo.Visible = permiso_recibo
            lb_anulacion_dpr.Visible = permiso_dpr
            lb_correccion_factura.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_corregir")
        End If
    End Sub
    Protected Sub lb_anulacion_factura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_anulacion_factura.Click
        Response.Redirect("~/recurso/caja/anulacion/anulacionFacturas.aspx")
    End Sub
    Protected Sub lb_anulacion_recibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_anulacion_recibo.Click
        Response.Redirect("~/recurso/caja/anulacion/anulacionRecibos.aspx")
    End Sub
    Protected Sub lb_anulacion_dpr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_anulacion_dpr.Click
        Response.Redirect("~/recurso/caja/anulacion/anulacionComprobantes.aspx")
    End Sub
    Protected Sub lb_correccion_factura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_correccion_factura.Click
        Response.Redirect("~/recurso/caja/anulacion/correccionFactura.aspx")
    End Sub
    
    Protected Sub recurso_liquidacionReimprimir()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("liquidacion").id_recurso)
        panel_liquidacionReimprimir.Visible = ver
        If ver Then
            btn_liquidacionReimprimir.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "liquidacion", "proforma_reimprimir")
        End If
    End Sub
    Protected Sub btn_liquidacionReimprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_liquidacionReimprimir.Click
        Response.Redirect("~/recurso/caja/liquidacion/reimprimirProforma.aspx")
    End Sub
    
    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteCaja").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteCaja").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCaja", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/caja/reporteCaja/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub

    
    Protected Sub recurso_reciboGastos()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reciboGastos").id_recurso)
        panel_reciboGastos.Visible = ver
        If ver Then
            btn_reciboGastos.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "view")
        End If
    End Sub
    Protected Sub btn_reciboGastos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reciboGastos.Click
        Response.Redirect("~/recurso/caja/reciboGastos/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_terraplus()
        'Se verifica si se tiene permiso para anular pagos terraplus
        Dim permiso_anular_terraplus As Boolean = False
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "terraplus_dia") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "terraplus_mes") = True Then
            permiso_anular_terraplus = True
        End If
        
        'Se verifica si el módulo actual tiene el recurso "Pagos TerraPlus" o se tiene permipo anulaciones TerraPlus
        Dim ver As Boolean = False
        If modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("pagoTerraPlus").id_recurso) = True _
        Or permiso_anular_terraplus = True Then
            ver = True
        End If

        'Se habilitan paneles y botones
        panel_terraplus.Visible = ver
        If ver Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoTerraPlus", "dpr") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoTerraPlus", "efectivo") = True Then
                btn_terraplus_pago.Visible = True
            Else
                btn_terraplus_pago.Visible = False
            End If
            
            btn_terraplus_anulacion.Visible = permiso_anular_terraplus
        End If
    End Sub
    Protected Sub btn_terraplus_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_terraplus_pago.Click
        Response.Redirect("~/recurso/caja/terraplusPago.aspx")
    End Sub
    Protected Sub btn_terraplus_anulacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_terraplus_anulacion.Click
        Response.Redirect("~/recurso/caja/terraplusAnulacion.aspx")
    End Sub
</script>
<asp:WinPopUp ID="WinPopUp1" runat="server"></asp:WinPopUp>
<asp:Msg ID="msg_parametros" runat="server"></asp:Msg>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_tipocambio" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_tipocambio_titulo" runat="server" SkinID="lblWebPartTitle" Text="Tipo de cambio"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><asp:Label ID="lbl_tipocambio_fecha_enun" runat="server" Text="Fecha:"></asp:Label></td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td><asp:Label ID="lbl_tipocambio_fecha" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lbl_tipocambio_compra_enun" runat="server" Text="T/C Compra: "></asp:Label></td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td><asp:Label ID="lbl_tipocambio_compra" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lbl_tipocambio_venta_enun" runat="server" Text="T/C Venta: "></asp:Label></td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td><asp:Label ID="lbl_tipocambio_venta" runat="server"></asp:Label></td>
                                </tr>
                                <tr><td colspan="3"><asp:LinkButton ID="lb_tipocambio_historico" runat="server" Text="Reporte de tipos de cambio históricos" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                            </table>
                            <asp:Msg ID="msg_tipocambio" runat="server" Show="false"></asp:Msg>
                        </td>
                    </tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_tipocambio" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_contratoPago" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_pago_titulo" runat="server" SkinID="lblWebPartTitle" Text="Pagos (contratos)"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd">Pago Inicial, Normal, Adelantado, Según Plan, Directo a Capital, Interés Penal, Otros Servicios, Liquidación</td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_contratoPago" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_contratoAnulacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_contratoAnulacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Anulaciones (contratos)"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:Msg ID="msg_contratoAnulacion" runat="server"></asp:Msg></td></tr>
                    <tr><td class="wpContenidoTd">Anulación de Pago inicial, Pagos, Venta de servicios, Reprogramación</td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_contratoAnulacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_osnc" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_osnc_titulo" runat="server" SkinID="lblWebPartTitle" Text="Pago de Otros Servicios (Clientes transitorios)"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd">Realizar pagos por la venta de servicios a cliente transitorios</td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_osnc" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_anulacionOsnc" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_aosnc_titulo" runat="server" SkinID="lblWebPartTitle" Text="Anulación de Otros Servicios (Clientes transitorios)"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd">Anulación de la venta de servicios a cliente transitorios</td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_aosnc" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_terraplus" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_terraplus_titulo" runat="server" SkinID="lblWebPartTitle" Text="TerraPlus (Pagos y Anulaciones)"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd">Realizar pagos y anulaciones de planes TerraPlus</td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <table cellpadding="0" cellspacing="0" align="right">
                                <tr>
                                    <td><asp:Button ID="btn_terraplus_anulacion" runat="server" Text="Anulaciones" SkinID="btnWebPart" /></td>
                                    <td style="width:20px;"></td>
                                    <td><asp:Button ID="btn_terraplus_pago" runat="server" Text="Realizar PAGOS" SkinID="btnWebPart" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_anulacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_anulacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Anulaciones / reimpresiones"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><asp:LinkButton ID="lb_anulacion_factura" runat="server" Text="Anulación/Reimpresión de Facturas" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_anulacion_recibo" runat="server" Text="Anulación/Reimpresión de Recibos" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_anulacion_dpr" runat="server" Text="Anulación/Reimpresión de Comprobantes Dpr" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_correccion_factura" runat="server" Text="Corrección de Facturas" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_liquidacionReimprimir" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_liquidacionReimprimir_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reimprimir proforma de liquidación"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd">Realizar la reimpresión de la proforma de liquidación de un contrato</td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_liquidacionReimprimir" runat="server" Text="Entrar" SkinID="btnWebPart"/></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de Caja"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Repeater ID="r_reporte" runat="server" DataSourceID="ods_lista_reporte">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_reporte" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_reporte_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbl_reporte_id_recurso" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:ObjectDataSource ID="ods_lista_reporte" runat="server" TypeName="terrasur.permiso" SelectMethod="ListaPorRecurso">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_recurso" Type="Int32" ControlID="lbl_reporte_id_recurso" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reciboGastos" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reciboGastos" runat="server" SkinID="lblWebPartTitle" Text="Recibos de gastos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd">Registro de recibos de gastos de caja</td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_reciboGastos" runat="server" Text="Entrar" SkinID="btnWebPart"/></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
