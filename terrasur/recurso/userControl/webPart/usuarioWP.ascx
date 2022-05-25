<%@ Control Language="VB" ClassName="usuarioWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_usuarioTodos()
            recurso_impresora()
            recurso_asignacion_impresora()
        End If
    End Sub

    Protected Sub recurso_usuarioTodos()
        panel_usuario.Visible = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("usuarioTodos").id_recurso)
    End Sub
    Protected Sub r_usuario_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles r_usuario.ItemCommand
        Session.Add("id_rol", Integer.Parse(e.CommandArgument.ToString))
        Response.Redirect("~/recurso/usuario/usuarioTodos/Default.aspx")
    End Sub
    Protected Sub btn_usuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_usuario.Click
        Response.Redirect("~/recurso/usuario/usuarioTodos/Default.aspx")
    End Sub

    Protected Sub recurso_impresora()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("impresora").id_recurso)
        panel_impresoras.Visible = ver
        If ver Then
            lbl_num_facturas.Text = impresora.Lista(True, False, False, True).Rows.Count.ToString()
            lbl_num_recibos.Text = impresora.Lista(False, True, False, True).Rows.Count.ToString()
            lbl_num_comprobantes.Text = impresora.Lista(False, False, True, True).Rows.Count.ToString()
            btn_impresora.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "view")
        End If
    End Sub
    Protected Sub btn_impresora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_impresora.Click
        Response.Redirect("~/recurso/usuario/impresora/Default.aspx")
    End Sub

    Protected Sub recurso_asignacion_impresora()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("asignacion_impresora").id_recurso)
        panel_asignaciones.Visible = ver
        If ver Then
            lbl_num_asignaciones.Text = impresora_usuario.ListaUsuarios().Rows.Count.ToString()
            btn_asignacion_impresora.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignacion_impresora", "asignar")
        End If
    End Sub
    Protected Sub btn_asignacion_impresora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_asignacion_impresora.Click
        Response.Redirect("~/recurso/usuario/asignacion_impresora/Default.aspx")
    End Sub

    Protected Function StringTipoUsuario(ByVal Nombre As String, ByVal Num_activo As String, ByVal Num_total As String) As String
        If Num_activo <> "" And Num_total <> "" Then
            Return String.Format("{0} ({1}/{2})", Nombre, Num_activo, Num_total)
        Else
            Return Nombre
        End If
    End Function


</script>
<table class="wpContenidoTable">
    <tr>
        <td>
        <asp:Panel ID="panel_usuario" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td class="wpContenidoTdTitle">
                    <asp:Label ID="lbl_WebPartTitle" runat="server" SkinID="lblWebPartTitle" Text="Usuarios"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="wpContenidoTd">
                    <asp:Repeater ID="r_usuario" runat="server" DataSourceID="ods_rol_lista">
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>    
                                    <asp:LinkButton ID="lb_rol" runat="server" SkinID="lbWebPart" Text='<%# StringTipoUsuario(Eval("nombre"),Eval("num_usuario_activo").ToString(),Eval("num_usuario_total").ToString()) %>'
                                        CommandArgument='<%# Eval("id_rol") %>'></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table></FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td class="wpContenidoTdButton">
                    <asp:Button ID="btn_usuario" runat="server" Text="Entrar" SkinID="btnWebPart" />
                </td>
            </tr>
        </table>
         </asp:Panel> 
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_impresoras" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="wpContenidoTdTitle">
                            <asp:Label ID="lbl_impresora" runat="server" SkinID="lblWebPartTitle" Text="Impresoras"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>Impresoras de Facturas (Activas):</td>
                                    <td>
                                     <asp:Label ID="lbl_num_facturas" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Impresoras de Recibos (Activas):</td>
                                    <td>
                                     <asp:Label ID="lbl_num_recibos" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Impresoras de Comprobantes DPR (Activas):</td>
                                    <td>
                                     <asp:Label ID="lbl_num_comprobantes" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table> 
                        </td>
                    </tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_impresora" runat="server" Text="Entrar" SkinID="btnWebPart" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr> 
    <tr>
        <td>
            <asp:Panel ID="panel_asignaciones" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="wpContenidoTdTitle">
                            <asp:Label ID="lbl_asignacion_impresora" runat="server" SkinID="lblWebPartTitle"
                                Text="Asignación de impresoras"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="wpContenidoTd">
                         <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>No. de asignaciones de impresoras:</td>
                                    <td>
                                     <asp:Label ID="lbl_num_asignaciones" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table> 
                        </td>
                    </tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_asignacion_impresora" runat="server" Text="Entrar" SkinID="btnWebPart" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>  
</table>

<%--[id_rol],[id_modulo],[codigo],[nombre],[num_usuario_activo],[num_usuario_total]--%>
<asp:ObjectDataSource ID="ods_rol_lista" runat="server" TypeName="terrasur.rol" SelectMethod="Lista">
    <SelectParameters><asp:Parameter Name="para_menu" Type="Boolean" DefaultValue="True" /></SelectParameters>
</asp:ObjectDataSource>