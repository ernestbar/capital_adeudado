<%@ Control Language="VB" ClassName="marketingWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_ciclo()
            recurso_grupo()
            recurso_promotor()
            recurso_asignacion()
            recurso_bono()
            recurso_reporte()
        End If
    End Sub
    
    
    Protected Sub recurso_ciclo()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("ciclo").id_recurso)
        panel_ciclo.Visible = ver
        If ver Then
            Dim id_ciclocomercial As Integer = ciclo_comercial.VigentePorFecha(DateTime.Now)
            If id_ciclocomercial > 0 Then
                'lbl_ciclo_actual.Text = "Vigente: " & ciclo_comercial.CicloString(id_ciclocomercial)
                Dim c As New ciclo_comercial(id_ciclocomercial)
                lbl_ciclo_actual.Text = "Vigente: " & c.inicio.ToString("d") & " - " & c.fin.ToString("d")
            Else
                lbl_ciclo_actual.Text = "Vigente: " & "----"
                msg_ciclo.Text = "Se debe definir un ciclo comercial vigente"
            End If
            btn_ciclo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "ciclo", "view")
        End If
    End Sub
    Protected Sub btn_ciclo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ciclo.Click
        Response.Redirect("~/recurso/marketing/ciclo/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_grupo()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("grupo").id_recurso)
        panel_grupo.Visible = ver
        If ver Then
            btn_grupo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupo", "view")
        End If
    End Sub
    Protected Sub btn_grupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grupo.Click
        Response.Redirect("~/recurso/marketing/grupo/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_promotor()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("promotor").id_recurso)
        panel_promotor.Visible = ver
        If ver Then
            btn_promotor.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "promotor", "view")
        End If
    End Sub
    Protected Sub btn_promotor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_promotor.Click
        Response.Redirect("~/recurso/marketing/promotor/Default.aspx")
    End Sub

    
    Protected Sub recurso_asignacion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("asignaPromotor").id_recurso)
        panel_asignacion.Visible = ver
        If ver Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_asignacion") = True _
            Or permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_comision") = True Then
                btn_asignacion.Visible = True
            Else
                btn_asignacion.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_asignacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_asignacion.Click
        Response.Redirect("~/recurso/marketing/asignaPromotor/Default.aspx")
    End Sub
    
    Protected Sub recurso_bono()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("bonoPromotor").id_recurso)
        panel_bono.Visible = ver
        If ver Then
            btn_bono.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "bonoPromotor", "view")
        End If
    End Sub
    Protected Sub btn_bono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_bono.Click
        Response.Redirect("~/recurso/marketing/bonoPromotor/Default.aspx")
    End Sub
    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteMarketing").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteMarketing").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/marketing/reporteMarketing/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_ciclo" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_ciclo_titulo" runat="server" SkinID="lblWebPartTitle" Text="Ciclos comerciales"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:Label ID="lbl_ciclo_actual" runat="server"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_ciclo" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
                <asp:Msg ID="msg_ciclo" runat="server"></asp:Msg>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_grupo" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_grupo_titulo" runat="server" SkinID="lblWebPartTitle" Text="Grupos de venta"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_grupo" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_promotor" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_promotor_titulo" runat="server" SkinID="lblWebPartTitle" Text="Promotores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_promotor" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_asignacion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_asignacion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cambio de asignación de promotores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_asignacion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_bono" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_bono_titulo" runat="server" SkinID="lblWebPartTitle" Text="Asignación de bonos a promotores"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_bono" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de Marketing"></asp:Label></td></tr>
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
