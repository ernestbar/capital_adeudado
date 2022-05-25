<%@ Control Language="VB" ClassName="inventarioWP" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_localizacion()
            recurso_urbanizacion()
            recurso_manzano()
            recurso_lote()
            recurso_planimetria()
            recurso_seguimientoObras()
            recurso_reporte()
        End If
    End Sub

   
    Protected Sub recurso_localizacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("localizacion").id_recurso)
        panel_localizacion.Visible = ver
        If ver Then
            btn_localizacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "localizacion", "view")
        End If
    End Sub
    Protected Sub btn_localizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_localizacion.Click
        Response.Redirect("~/recurso/inventario/localizacion/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_urbanizacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("urbanizacion").id_recurso)
        panel_urbanizacion.Visible = ver
        If ver Then
            btn_urbanizacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "urbanizacion", "view")
        End If
    End Sub
    Protected Sub btn_urbanizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_urbanizacion.Click
        Response.Redirect("~/recurso/inventario/urbanizacion/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_manzano()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("manzano").id_recurso)
        panel_manzano.Visible = ver
        If ver Then
            btn_manzano.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "view")
        End If
    End Sub
    Protected Sub btn_manzano_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_manzano.Click
        Response.Redirect("~/recurso/inventario/manzano/Default.aspx")
    End Sub

    
    Protected Sub recurso_lote()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("lote").id_recurso)
        panel_lote.Visible = ver
        If ver Then
            btn_lote.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "view")
        End If
    End Sub
    Protected Sub btn_lote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_lote.Click
        Response.Redirect("~/recurso/inventario/lote/Default.aspx")
    End Sub

    
    Protected Sub recurso_planimetria()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("planimetria").id_recurso)
        panel_planimetria.Visible = ver
        If ver Then
            lb_planimetria_archivos.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "view")
            btn_planimetria.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "view_plan")
        End If
    End Sub
    Protected Sub lb_planimetria_archivos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_planimetria_archivos.Click
        Response.Redirect("~/recurso/inventario/planimetria/archivosShape.aspx")
    End Sub
    Protected Sub btn_planimetria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_planimetria.Click
        Response.Redirect("~/recurso/inventario/planimetria/Default.aspx")
    End Sub

    
    Protected Sub recurso_seguimientoObras()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("seguimientoObras").id_recurso)
        panel_seguimientoObras.Visible = ver
        If ver Then
            btn_seguimientoObras.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "view")
            lb_reporteSeguimiento.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "reporteSeguimiento")
        End If
    End Sub
    Protected Sub btn_seguimientoObras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_seguimientoObras.Click
        Response.Redirect("~/recurso/inventario/seguimientoObras/Default.aspx")
    End Sub
    Protected Sub lb_reporteSeguimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reporteSeguimiento.Click
        Response.Redirect("~/recurso/inventario/seguimientoObras/reporteSeguimientoObras.aspx")
    End Sub
    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteInventario").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteInventario").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/inventario/reporteInventario/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub


</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_localizacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_localizacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Localizaciones"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_localizacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_urbanizacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_urbanizacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Sectores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_urbanizacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_manzano" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_manzano_titulo" runat="server" SkinID="lblWebPartTitle" Text="Manzanos"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_manzano" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_lote" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_lote_titulo" runat="server" SkinID="lblWebPartTitle" Text="Lotes"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_lote" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_planimetria" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_planimetria_titulo" runat="server" SkinID="lblWebPartTitle" Text="Planimetrías de sectores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:LinkButton ID="lb_planimetria_archivos" runat="server" Text="Archivos Shape"></asp:LinkButton></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_planimetria" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_seguimientoObras" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_seguimientoObras_titulo" runat="server" SkinID="lblWebPartTitle" Text="Seguimiento de obras"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:LinkButton ID="lb_reporteSeguimiento" runat="server" Text="Reporte de Seguimiento de Obras"></asp:LinkButton></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_seguimientoObras" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de Inventario"></asp:Label></td></tr>
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
