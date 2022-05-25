<%@ Control Language="VB" ClassName="herramientaWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_simulador()
            recurso_planPagoOriginalVigente()
            recurso_reprogramacionBloque()
            recurso_codigoControl()
            recibo_regularizacion()
            recurso_fichaTecnica()
            recurso_datosNafibo()
            recurso_datosBNB()
            recurso_infoGerencial()
        End If
    End Sub
    
    Protected Sub recurso_simulador()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("simulador").id_recurso)
        panel_simulador.Visible = ver
        If ver Then
            btn_simulador.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "simulador", "simular")
        End If
    End Sub
    Protected Sub btn_simulador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_simulador.Click
        Response.Redirect("~/recurso/herramienta/simulador/Default.aspx")
    End Sub
    
    Protected Sub recurso_planPagoOriginalVigente()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("planPagoOriginalVigente").id_recurso)
        panel_planPagoOriginalVigente.Visible = ver
        If ver Then
            btn_planPagoOriginalVigente.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planPagoOriginalVigente", "exportar")
        End If
    End Sub
    Protected Sub btn_planPagoOriginalVigente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_planPagoOriginalVigente.Click
        Response.Redirect("~/recurso/herramienta/planPagoOriginalVigente/Default.aspx")
    End Sub
    
    Protected Sub recurso_reprogramacionBloque()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reprogramacionBloque").id_recurso)
        panel_reprogramacionBloque.Visible = ver
        If ver Then
            btn_reprogramacionBloque.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reprogramacionBloque", "view")
        End If
    End Sub
    Protected Sub btn_reprogramacionBloque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reprogramacionBloque.Click
        Response.Redirect("~/recurso/herramienta/reprogramacionBloque/Default.aspx")
    End Sub

    Protected Sub recurso_codigoControl()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("codigoControl").id_recurso)
        panel_codigoControl.Visible = ver
        If ver Then
            btn_codigoControl.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "codigoControl", "view")
        End If
    End Sub
    Protected Sub btn_codigoControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_codigoControl.Click
        Response.Redirect("~/recurso/herramienta/codigoControl/Default.aspx")
    End Sub

    
    Protected Sub recibo_regularizacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reciboRegularizacion").id_recurso)
        panel_recibo_regularizacion.Visible = ver
        If ver Then
            btn_recibo_regularizacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboRegularizacion", "view")
        End If
    End Sub
    Protected Sub btn_recibo_regularizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_recibo_regularizacion.Click
        Response.Redirect("~/recurso/herramienta/reciboRegularizacion/Default.aspx")
    End Sub

    Protected Sub recurso_fichaTecnica()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("fichaTecnica").id_recurso)
        panel_fichaTecnica.Visible = ver
        If ver Then
            btn_fichaTecnica.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "fichaTecnica", "view")
        End If
    End Sub
    Protected Sub btn_fichaTecnica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_fichaTecnica.Click
        Response.Redirect("~/recurso/herramienta/fichaTecnica/Default.aspx")
    End Sub
    
    Protected Sub recurso_datosNafibo()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("datosNafibo").id_recurso)
        panel_datosNafibo.Visible = ver
        If ver Then
            Dim permiso_ejecutado_proyectado As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "ejecutado_proyectado")
            Dim permiso_formato_nafibo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "formato_nafibo")
            Dim permiso_generar_tablas As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "generar_tablas")
            Dim permiso_ingresar_ajuste_pago As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "ingresar_ajuste_pago")
            If permiso_ejecutado_proyectado = True Or permiso_formato_nafibo = True Or permiso_generar_tablas = True Or permiso_ingresar_ajuste_pago = True Then
                btn_datosNafibo.Visible = True
            Else
                btn_datosNafibo.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_datosNafibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_datosNafibo.Click
        Response.Redirect("~/recurso/herramienta/datosNafibo/Default.aspx")
    End Sub

    
    Protected Sub recurso_datosBNB()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("datosBNB").id_recurso)
        panel_datosBNB.Visible = ver
        If ver Then
            Dim permiso_datos_preliminares As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosBNB", "datos_preliminares")

            If permiso_datos_preliminares = True Then
                btn_datosBNB.Visible = True
            Else
                btn_datosBNB.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_datosBNB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_datosBNB.Click
        Response.Redirect("~/recurso/herramienta/datosBNB/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_infoGerencial()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("infoGerencial").id_recurso)
        panel_infoGerencial.Visible = ver
        If ver Then
            btn_infoGerencial.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "infoGerencial", "view")
        End If
    End Sub
    Protected Sub btn_infoGerencial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_infoGerencial.Click
        Response.Redirect("~/recurso/herramienta/infoGerencial/Default.aspx")
    End Sub


</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_simulador" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_simulador_titulo" runat="server" SkinID="lblWebPartTitle" Text="Simulación de plan de pagos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_simulador" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_planPagoOriginalVigente" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_planPagoOriginalVigente_titulo" runat="server" SkinID="lblWebPartTitle" Text="Planes Originales y Vigentes"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_planPagoOriginalVigente" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reprogramacionBloque" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reprogramacionBloque" runat="server" SkinID="lblWebPartTitle" Text="Reprogramaciones en bloque"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_reprogramacionBloque" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_codigoControl" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_codigoControl" runat="server" SkinID="lblWebPartTitle" Text="Generación de Códigos de control"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_codigoControl" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_recibo_regularizacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_recibo_regularizacion" runat="server" SkinID="lblWebPartTitle" Text="Recibos de regularización de pagos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_recibo_regularizacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_fichaTecnica" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_fichaTecnica" runat="server" SkinID="lblWebPartTitle" Text="Ficha Técnica Nafibo"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_fichaTecnica" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_datosNafibo" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_datosNafibo" runat="server" SkinID="lblWebPartTitle" Text="Generación de datos Nafibo"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_datosNafibo" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_datosBNB" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_datosBNB" runat="server" SkinID="lblWebPartTitle" Text="Generación de datos BNB"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_datosBNB" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_infoGerencial" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_infoGerencial" runat="server" SkinID="lblWebPartTitle" Text="Información Gerencial"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_infoGerencial" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>