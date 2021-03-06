<%@ Control Language="VB" ClassName="contratoWP" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_contratoLote()
            recurso_cambioLote()
            recurso_cambioTitular()
            recurso_cambioTipoCliente()
            recurso_transferencia()
            recurso_reprogramacion()
            recurso_observacion()
            recurso_beneficiario()
            recurso_estadoespecial()
            recurso_intercambio()
            recurso_reembolso()
            recurso_reversion()
            recurso_reporte()
            recurso_adjunto()
        End If
    End Sub

    Protected Sub recurso_adjunto()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("archivoAdjunto").id_recurso)
        panel_adjunto.Visible = ver
        If ver Then
            btn_adjunto.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "archivoAdjunto", "view")
        End If
    End Sub
    Protected Sub btn_adjunto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adjunto.Click
        Response.Redirect("~/recurso/contrato/archivoAdjunto/Default.aspx")
    End Sub


    Protected Sub recurso_contratoLote()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("contratoLote").id_recurso)
        panel_lote.Visible = ver
        If ver = True Then
            'Dim num_preasignado As Integer = 0, num_vigente As Integer = 0, num_liquidado As Integer = 0, num_revertido As Integer = 0
            'contrato_venta.DatosWebPart(num_preasignado, num_vigente, num_liquidado, num_revertido)
            'lbl_lote_num.Text = "Preasignados (" & num_preasignado & "), Vigentes (" & num_vigente & "), Liquidados (" & num_liquidado & "), Revertidos (" & num_revertido & ")"
            btn_lote_registrar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "registrar")
            btn_lote_listado.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "ver_listado")
        End If
    End Sub
    Protected Sub btn_lote_registrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_lote_registrar.Click
        Response.Redirect("~/recurso/contrato/contratoLote/Default.aspx")
    End Sub
    Protected Sub btn_lote_listado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_lote_listado.Click
        Response.Redirect("~/recurso/contrato/contratoLote/listado.aspx")
    End Sub


    Protected Sub recurso_cambioLote()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cambioLote").id_recurso)
        panel_cambioLote.Visible = ver
        If ver Then
            btn_cambioLote.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioLote", "cambiar_lote")
        End If
    End Sub
    Protected Sub btn_cambioLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambioLote.Click
        Response.Redirect("~/recurso/contrato/cambioLote/Default.aspx")
    End Sub


    Protected Sub recurso_cambioTitular()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cambioTitular").id_recurso)
        panel_cambioTitular.Visible = ver
        If ver Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "primer_titular") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "otro_titular") = True Then
                btn_cambioTitular.Visible = True
            Else
                btn_cambioTitular.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_cambioTitular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambioTitular.Click
        Response.Redirect("~/recurso/contrato/cambioTitular/Default.aspx")
    End Sub


    Protected Sub recurso_cambioTipoCliente()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cambioTipoCliente").id_recurso)
        panel_cambioTipoCliente.Visible = ver
        If ver Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTipoCliente", "normal_preferencial") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTipoCliente", "preferencial_normal") = True Then
                btn_cambioTipoCliente.Visible = True
            Else
                btn_cambioTipoCliente.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_cambioTipoCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambioTipoCliente.Click
        Response.Redirect("~/recurso/contrato/cambioTipoCliente/Default.aspx")
    End Sub


    Protected Sub recurso_transferencia()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("transferencia").id_recurso)
        panel_transferencia.Visible = ver
        If ver Then
            btn_transferencia.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "transferencia", "ingresar")
        End If
    End Sub
    Protected Sub btn_transferencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_transferencia.Click
        Response.Redirect("~/recurso/contrato/transferencia/Default.aspx")
    End Sub


    Protected Sub recurso_reprogramacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reprogramacion").id_recurso)
        panel_reprogramacion.Visible = ver
        If ver Then
            btn_reprogramacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reprogramacion", "reprogramar")
        End If
    End Sub
    Protected Sub btn_reprogramacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reprogramacion.Click
        Response.Redirect("~/recurso/contrato/reprogramacion/Default.aspx")
    End Sub


    Protected Sub recurso_observacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("observacion").id_recurso)
        panel_observacion.Visible = ver
        If ver Then
            btn_observacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "observacion", "registrar_editar")
        End If
    End Sub
    Protected Sub btn_observacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_observacion.Click
        Response.Redirect("~/recurso/contrato/observacion/Default.aspx")
    End Sub


    Protected Sub recurso_beneficiario()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cambioBeneficiario").id_recurso)
        panel_beneficiario.Visible = ver
        If ver Then
            btn_beneficiario.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioBeneficiario", "view")
        End If
    End Sub
    Protected Sub btn_beneficiario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_beneficiario.Click
        Response.Redirect("~/recurso/contrato/cambioBeneficiario/Default.aspx")
    End Sub


    Protected Sub recurso_estadoespecial()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("contratoEstadoEspecial").id_recurso)
        panel_estadoespecial.Visible = ver
        If ver Then
            btn_estadoespecial.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "view")
        End If
    End Sub
    Protected Sub btn_estadoespecial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_estadoespecial.Click
        Response.Redirect("~/recurso/contrato/contratoEstadoEspecial/Default.aspx")
    End Sub


    Protected Sub recurso_intercambio()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("intercambio").id_recurso)
        panel_intercambio.Visible = ver
        If ver Then
            btn_intercambio.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "view")
        End If
    End Sub
    Protected Sub btn_intercambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_intercambio.Click
        Response.Redirect("~/recurso/contrato/intercambio/Default.aspx")
    End Sub


    Protected Sub recurso_reembolso()
        Dim ver As Boolean = False
        If modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("traspaso").id_recurso) _
            Or modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("devolucion").id_recurso) _
            Or modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reItem").id_recurso) _
            Or modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reMotivo").id_recurso) _
            Or modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reUsuario").id_recurso) Then
            ver = True
        End If

        panel_reembolso.Visible = ver
        If ver Then
            btn_reembolso.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "view")
            'Req. Conciliaciones
            btn_conciliacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "conciliacion", "view")
            btn_seguimiento_conciliacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoConciliacion", "view")
            'Req. Conciliaciones            
            lb_reembolso_item.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reItem", "view")
            lb_reembolso_motivo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reMotivo", "view")
            lb_reembolso_usuario.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reUsuario", "view")
            lb_reembolso_reporte.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "reporte")
        End If
    End Sub
    Protected Sub btn_reembolso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reembolso.Click
        Response.Redirect("~/recurso/reembolso/traspaso/Default.aspx")
    End Sub

    'Req. Conciliaciones
    Protected Sub btn_conciliacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_conciliacion.Click
        Response.Redirect("~/recurso/reembolso/conciliacion/Default.aspx")
    End Sub

    Protected Sub btn_seguimiento_conciliacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_seguimiento_conciliacion.Click
        Response.Redirect("~/recurso/reembolso/seguimientoConciliacion/Default.aspx")
    End Sub
    'Req. Conciliaciones

    Protected Sub lb_reembolso_item_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reembolso_item.Click
        Response.Redirect("~/recurso/reembolso/reItem/Default.aspx")
    End Sub
    Protected Sub lb_reembolso_motivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reembolso_motivo.Click
        Response.Redirect("~/recurso/reembolso/reMotivo/Default.aspx")
    End Sub
    Protected Sub lb_reembolso_usuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reembolso_usuario.Click
        Response.Redirect("~/recurso/reembolso/reUsuario/Default.aspx")
    End Sub
    Protected Sub lb_reembolso_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reembolso_reporte.Click
        Response.Redirect("~/recurso/reembolso/traspaso/reReporte.aspx")
    End Sub


    Protected Sub recurso_reversion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reversion").id_recurso)
        panel_reversion.Visible = ver
        If ver Then
            btn_reversion_mora.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "mora_ver")
            btn_reversion_fuerza.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "fuerza_ver")
            btn_reversion_deshacer.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "deshacer")
        End If
    End Sub
    Protected Sub btn_reversion_mora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reversion_mora.Click
        Response.Redirect("~/recurso/contrato/reversion/contratoReversionMora.aspx")
    End Sub
    Protected Sub btn_reversion_fuerza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reversion_fuerza.Click
        Response.Redirect("~/recurso/contrato/reversion/contratoReversionFuerza.aspx")
    End Sub
    Protected Sub btn_reversion_deshacer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reversion_deshacer.Click
        Response.Redirect("~/recurso/contrato/reversion/contratoReversionDeshacer.aspx")
    End Sub
    'Protected Sub lb_reversion_mora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reversion_mora.Click
    '    Response.Redirect("~/recurso/contrato/reversion/contratoReversionMora.aspx")
    'End Sub
    'Protected Sub lb_reversion_fuerza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reversion_fuerza.Click
    '    Response.Redirect("~/recurso/contrato/reversion/contratoReversionFuerza.aspx")
    'End Sub
    'Protected Sub lb_reversion_deshacer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reversion_deshacer.Click
    '    Response.Redirect("~/recurso/contrato/reversion/contratoReversionDeshacer.aspx")
    'End Sub


    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteContrato").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteContrato").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contrato/reporteContrato/" & CType(sender, LinkButton).CommandArgument & ".aspx?t=")
    End Sub


</script>

<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_lote" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_lote_titulo" runat="server" SkinID="lblWebPartTitle" Text="Contratos de venta de lote"></asp:Label></td></tr>
                    <%--<tr><td class="wpContenidoTd"><asp:Label ID="lbl_lote_num" runat="server"></asp:Label></td></tr>--%>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_lote_registrar" runat="server" Text="Registrar" SkinID="btnWebPart" />
                            <asp:Button ID="btn_lote_listado" runat="server" Text="Listado" SkinID="btnWebPart" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_cambioLote" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_cambioLote_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cambio de lote"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_cambioLote" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_cambioTitular" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_cambioTitular_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cambio de titular"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_cambioTitular" runat="server" Text="Entrar" SkinID="btnWebPart"/></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_cambioTipoCliente" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_cambioTipoCliente_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cambio de tipo de cliente"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_cambioTipoCliente" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_transferencia" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_transferencia_titulo" runat="server" SkinID="lblWebPartTitle" Text="Transferencia"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_transferencia" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reprogramacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reprogramacion" runat="server" SkinID="lblWebPartTitle" Text="Reprogramaci?n"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_reprogramacion" runat="server" Text="Entrar" SkinID="btnWebPart"  /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_observacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_observacion" runat="server" SkinID="lblWebPartTitle" Text="Observaciones"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_observacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_adjunto" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_adjunto" runat="server" SkinID="lblWebPartTitle" Text="Documentos adjuntos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_adjunto" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_beneficiario" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_beneficiario" runat="server" SkinID="lblWebPartTitle" Text="Cambio de beneficiario de facturas"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_beneficiario" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_estadoespecial" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="label_estadoespecial" runat="server" SkinID="lblWebPartTitle" Text="Estados especiales de contratos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_estadoespecial" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_intercambio" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_intercambio" runat="server" SkinID="lblWebPartTitle" Text="Intercambios"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_intercambio" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reembolso" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reembolso" runat="server" Text="Traspasos y devoluciones" SkinID="lblWebPartTitle"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_reembolso" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                    <%--Req. Conciliaciones--%>
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_conciliacion" runat="server" Text="Conciliaciones" SkinID="lblWebPartTitle"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_conciliacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_seguimiento_conciliacion" runat="server" Text="Seguimiento Conciliaciones" SkinID="lblWebPartTitle"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_seguimiento_conciliacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                    <%--Req. Conciliaciones--%>
                    <tr><td class="wpContenidoTd"><asp:LinkButton ID="lb_reembolso_item" runat="server" Text="Elementos de reembolso" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                    <tr><td class="wpContenidoTd"><asp:LinkButton ID="lb_reembolso_motivo" runat="server" Text="Motivos de reembolso" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                    <tr><td class="wpContenidoTd"><asp:LinkButton ID="lb_reembolso_usuario" runat="server" Text="Usuarios que procesan reembolsos" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                    <tr><td class="wpContenidoTd"><asp:LinkButton ID="lb_reembolso_reporte" runat="server" Text="Reporte de traspasos y devoluciones" SkinID="lbWebPart"></asp:LinkButton></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reversion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reversion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reversiones"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_reversion_mora" runat="server" Text="Por mora" SkinID="btnWebPart"/>
                            <asp:Button ID="btn_reversion_fuerza" runat="server" Text="Por fuerza" SkinID="btnWebPart"/>
                            <asp:Button ID="btn_reversion_deshacer" runat="server" Text="Deshacer reversi?n" SkinID="btnWebPart"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de Contratos"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Repeater ID="r_reporte" runat="server" DataSourceID="ods_lista_reporte">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_reporte" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_reporte_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbl_reporte_id_recurso" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:ObjectDataSource ID="ods_lista_reporte" runat="server" TypeName="terrasur.permiso" SelectMethod="ListaPorRecurso" FilterExpression="nombre<>'Imprimir estado cuenta'">
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
</table>