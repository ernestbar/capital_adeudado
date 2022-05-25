<%@ Control Language="VB" ClassName="sintesisWP" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_parametro()
            recurso_bloqueado()
	    recurso_reporte()
        End If
    End Sub
    
    Protected Sub recurso_parametro()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("sParametro").id_recurso)
        panel_parametro.Visible = ver
        If ver Then
            Dim tc_sintesis As New terrasur.sintesis.s_tipo_cambio(terrasur.sintesis.s_tipo_cambio.IdVigente(DateTime.Now))
            lbl_tipo_cambio.Text = "TC OFICIAL:  " & tc_sintesis.oficial.ToString("N2") & "  ;  Compra:  " & tc_sintesis.compra.ToString("N2") & "  ;  Venta:  " & tc_sintesis.venta.ToString("N2")
            Dim tc_cartera As New tipo_cambio(DateTime.Now)
            If Profile.entorno.codigo_modulo = "adm" And tc_cartera.id_tipocambio > 0 And tc_sintesis.oficial <> tc_cartera.compra Then
                msg_tipocambio.Text = "ALERTA: El tipo de cambio OFICIAL para Síntesis es diferente del tipo de cambio del Sistema de Cartera"
            End If

            btn_parametro.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "view")
        End If
    End Sub
    Protected Sub btn_parametro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_parametro.Click
        Response.Redirect("~/recurso/sintesis/sParametro/Default.aspx")
    End Sub
    
    Protected Sub recurso_bloqueado()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("sBloqueado").id_recurso)
        panel_bloqueado.Visible = ver
        If ver Then
            btn_bloqueado.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sBloqueado", "view")
        End If
    End Sub
    Protected Sub btn_bloqueado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_bloqueado.Click
        Response.Redirect("~/recurso/sintesis/sBloqueado/Default.aspx")
    End Sub
    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("sReporte").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lb_reporteResumen.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sReporte", "reporteResumen")
            lb_reporteControl.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sReporte", "reporteControl")
            lb_reporteIngresos.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sReporte", "reporteIngresos")
        End If
    End Sub
    Protected Sub lb_reporteResumen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reporteResumen.Click
        Response.Redirect("~/recurso/sintesis/sReporte/reporteResumen.aspx")
    End Sub
    Protected Sub lb_reporteControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reporteControl.Click
        Response.Redirect("~/recurso/sintesis/sReporte/reporteControl.aspx")
    End Sub
    Protected Sub lb_reporteIngresos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/sintesis/sReporte/reporteIngresos.aspx")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_parametro" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_parametro_titulo" runat="server" SkinID="lblWebPartTitle" Text="Parámetros para Síntesis"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd" align="left"><asp:Label ID="lbl_tipo_cambio" runat="server" SkinID="lblEnun"></asp:Label></td></tr>
                    <tr><td align="left"><asp:Msg ID="msg_tipocambio" runat="server"></asp:Msg></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_parametro" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_bloqueado" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_bloqueado" runat="server" SkinID="lblWebPartTitle" Text="Contratos bloqueados para Síntesis"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_bloqueado" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte" runat="server" SkinID="lblWebPartTitle" Text="Reportes de flujo de información"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><asp:LinkButton ID="lb_reporteResumen" runat="server" Text="Resumen de intercambio de información"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_reporteControl" runat="server" Text="Control de intercambio de información"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_reporteIngresos" runat="server" Text="Reporte de ingresos cobrados por Síntesis" OnClick="lb_reporteIngresos_Click"></asp:LinkButton></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>

</table>