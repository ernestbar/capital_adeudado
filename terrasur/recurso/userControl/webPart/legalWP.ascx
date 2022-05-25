<%@ Control Language="VB" ClassName="legalWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_negocioFolio()
            recurso_reporte()
        End If
    End Sub
    
    Protected Sub recurso_negocioFolio()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("negocioFolio").id_recurso)
        panel_negocioFolio.Visible = ver
        If ver Then
            btn_negocioFolio.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "view")
        End If
    End Sub
    Protected Sub btn_negocioFolio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_negocioFolio.Click
        Response.Redirect("~/recurso/legal/negocioFolio/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteLegal").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteLegal").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteLegal", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/legal/reporteLegal/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub

</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_negocioFolio" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_negocioFolio_titulo" runat="server" SkinID="lblWebPartTitle" Text="Registro de Negocios y Folios"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_negocioFolio" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes del Dpto. Legal"></asp:Label></td></tr>
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