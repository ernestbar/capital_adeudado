<%@ Control Language="VB" ClassName="cobranzaWP" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_cobrador()
            recurso_dosificacion()
            recurso_asignacion()
            recurso_recibo_transaccion()
            recurso_reporte()
        End If
    End Sub

    
    Protected Sub recurso_cobrador()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cobrador").id_recurso)
        panel_cobrador.Visible = ver
        If ver Then
            btn_cobrador.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrador", "view")
        End If
    End Sub
    Protected Sub btn_cobrador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cobrador.Click
        Response.Redirect("~/recurso/cobranza/cobrador/Default.aspx")
    End Sub

    
    Protected Sub recurso_dosificacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("dosificacion").id_recurso)
        panel_dosificacion.Visible = ver
        If ver Then
            btn_dosificacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "view")
            btn_busqueda.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "buscar")
        End If
    End Sub
    Protected Sub btn_dosificacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_dosificacion.Click
        Response.Redirect("~/recurso/cobranza/dosificacion/Default.aspx")
    End Sub
    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        Response.Redirect("~/recurso/cobranza/dosificacion/busquedaRecibo.aspx")
    End Sub

    
    Protected Sub recurso_asignacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("asignaCobrador").id_recurso)
        panel_asignacion.Visible = ver
        If ver Then
            btn_asignacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaCobrador", "asignar")
        End If
    End Sub
    
    Protected Sub btn_asignacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_asignacion.Click
        Response.Redirect("~/recurso/cobranza/asignaCobrador/Default.aspx")
    End Sub
        

    Protected Sub recurso_recibo_transaccion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reciboCobradorAsignacion").id_recurso)
        panel_recibo_transaccion.Visible = ver
        If ver Then
            btn_recibo_transaccion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboCobradorAsignacion", "view")
        End If
    End Sub
    
    Protected Sub btn_recibo_transaccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_recibo_transaccion.Click
        Response.Redirect("~/recurso/cobranza/reciboCobradorAsignacion/Default.aspx")
    End Sub

    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteCobranza").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteCobranza").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reporteCobranza/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_cobrador" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_cobrador_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cobradores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_cobrador" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_dosificacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_dosificacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Dosificación de recibos"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_dosificacion" runat="server" Text="Dosificación" SkinID="btnWebPart" />
                            <asp:Button ID="btn_busqueda" runat="server" Text="Búsqueda de recibos" SkinID="btnWebPart" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_asignacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_asignacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Asignación de cobradores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_asignacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_recibo_transaccion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_recibo_transaccion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Modificación en la asignación de recibos a pagos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_recibo_transaccion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de cobranza"></asp:Label></td></tr>
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
</table>
