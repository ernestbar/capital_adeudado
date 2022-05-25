<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos del usuario" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_usuario() As Integer
        Get
            Return Integer.Parse(lbl_id_usuario.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_usuario.Text = value
            recuperar_datos()
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_usuario") IsNot Nothing Then
                id_usuario = Integer.Parse(Session("id_usuario"))
                Session.Remove("id_usuario")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
    
    Protected Sub recuperar_datos()
        Dim usr As New usuario(id_usuario)
        img_imagen.ImageUrl = usuario.ImagenDireccion(usr.imagen)
        lbl_paterno.Text = usr.paterno
        lbl_materno.Text = usr.materno
        lbl_nombres.Text = usr.nombres
        lbl_ci.Text = usr.ci
        lbl_email.Text = usr.email
        lbl_nombre_usuario.Text = usr.nombre_usuario
        If usr.activo Then
            lbl_activo.Text = "Usuario activo"
        Else
            lbl_activo.Text = "Usuario inactivo"
        End If
        lbl_bloqueado.Visible = Membership.GetUser(usr.nombre_usuario).IsLockedOut
        If usr.eliminado Then
            lbl_elimiando.Text = "Usuario eliminado"
        Else
            lbl_elimiando.Text = "Usuario no eliminado"
        End If
        
        Page.Title = "Datos del usuario - " & usr.paterno & " " & usr.materno & " " & usr.nombres & " (" & usr.nombre_usuario & ")"

        'r_rol.DataBind()
    End Sub

    Protected Sub r_rol_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_rol.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("r_grupo_recurso"), Repeater).DataSource = grupo_recurso.ListaPorRol(Integer.Parse(DataBinder.Eval(e.Item.DataItem, "id_rol").ToString))
            CType(e.Item.FindControl("r_grupo_recurso"), Repeater).DataBind()
        End If
    End Sub
    Protected Sub r_grupo_recurso_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim id_rol As Integer = Integer.Parse(CType(CType(sender, Repeater).Parent.FindControl("lbl_id_rol"), Label).Text)
            CType(e.Item.FindControl("r_recurso"), Repeater).DataSource = recurso.ListaPorRolGrupoRecurso(id_rol, Integer.Parse(DataBinder.Eval(e.Item.DataItem, "id_gruporecurso").ToString))
            CType(e.Item.FindControl("r_recurso"), Repeater).DataBind()
        End If
    End Sub
    Protected Sub r_recurso_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If Integer.Parse(DataBinder.Eval(e.Item.DataItem, "num_permisos").ToString) > 0 Then
                Dim id_rol As Integer = Integer.Parse(CType(CType(sender, Repeater).Parent.Parent.Parent.Parent.FindControl("lbl_id_rol"), Label).Text)
                CType(e.Item.FindControl("r_permiso"), Repeater).DataSource = usuario_rol_permiso.ListaPermisoPorUsuarioRolRecurso(Me.id_usuario, id_rol, Integer.Parse(DataBinder.Eval(e.Item.DataItem, "id_recurso")))
                CType(e.Item.FindControl("r_permiso"), Repeater).DataBind()
                CType(e.Item.FindControl("lbl_no_permiso"), Label).Visible = CType(e.Item.FindControl("r_permiso"), Repeater).Items.Count.Equals(0)
            Else
                CType(e.Item.FindControl("lbl_no_permiso"), Label).Visible = False
            End If
        End If
    End Sub
    Protected Function string_rol_modulo(ByVal rol As String, ByVal modulo As String) As String
        If String.IsNullOrEmpty(modulo) Then
            Return rol
        Else
            Return rol & " (Módulo: " & modulo & ")"
        End If
    End Function

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="usuarioTodos" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td colspan="2" class="viewTdTitle">Datos del usuario</td></tr>
                    <tr><td colspan="2" class="viewTdImage"><asp:Image ID="img_imagen" runat="server" Height="<%$ AppSettings:usuario_tam_img %>" /></td></tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_paterno_enun" runat="server" Text="Apellido paterno:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_paterno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_materno_enun" runat="server" Text="Apellido materno:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_materno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_nombres_enun" runat="server" Text="Nombres:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_nombres" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_ci_enun" runat="server" Text="Nº doc. de identidad:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_ci" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_email_enun" runat="server" Text="Dirección Email:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_email" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_nombre_usuario_enun" runat="server" Text="Nombre de usuario:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_nombre_usuario" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_activo_enun" runat="server" Text="Usuario activo:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_activo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_bloqueado" runat="server" Text="Usuario bloqueado" ForeColor="red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_elimiando_enun" runat="server" Text="Usuario eliminado:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_elimiando" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_roles_enun" runat="server" Text="Roles del usuario:"></asp:Label></td>
                        <td class="viewTdDato">
                            <%--[id_rol],[id_modulo],[codigo],[nombre],[modulo_nombre]--%>
                            <asp:Repeater ID="r_rol" runat="server" DataSourceID="ods_roles_ListaPorUsuario">
                                <HeaderTemplate><table cellpadding="1" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_rol_enun" runat="server" Text='<%# string_rol_modulo(Eval("nombre"),Eval("modulo_nombre").ToString()) %>'></asp:Label>
                                        <asp:Label ID="lbl_id_rol" runat="server" Text='<%# Eval("id_rol") %>' Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;</td>
                                    <td>
                                        <%--[id_gruporecurso],[codigo],[nombre]--%>
                                        <asp:Repeater ID="r_grupo_recurso" runat="server" OnItemDataBound="r_grupo_recurso_ItemDataBound">
                                            <HeaderTemplate><table cellpadding="1" cellspacing="0" width="400px"></HeaderTemplate>
                                            <ItemTemplate><tr><td>
                                                <asp:Panel ID="panel_gruporecurso" runat="server" GroupingText='<%# Eval("nombre") %>'>
                                                    <%--[id_recurso],[id_gruporecurso],[codigo],[nombre],[num_permisos]--%>
                                                    <asp:Repeater ID="r_recurso" runat="server" OnItemDataBound="r_recurso_ItemDataBound">
                                                        <ItemTemplate>
                                                        <asp:Panel ID="panel_recurso" runat="server" GroupingText='<%# Eval("nombre") %>'>
                                                            <asp:CheckBoxList ID="cbl_permiso" runat="server" DataTextField="nombre" DataValueField="id_permiso"></asp:CheckBoxList>
                                                            <%--[id_permiso],[codigo],[nombre]--%>
                                                            <asp:Repeater ID="r_permiso" runat="server">
                                                                <ItemTemplate><asp:Label ID="lbl_permiso" runat="server" Text='<%# Eval("nombre") %>'></asp:Label></ItemTemplate>
                                                                <SeparatorTemplate>, </SeparatorTemplate>
                                                            </asp:Repeater>
                                                            <asp:Label ID="lbl_no_permiso" runat="server" Text="Ningún permiso"></asp:Label>
                                                        </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </asp:Panel>
                                            </td></tr></ItemTemplate>
                                            <FooterTemplate></table></FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                </ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ods_roles_ListaPorUsuario" runat="server" TypeName="terrasur.rol" SelectMethod="ListaPorUsuario">
        <SelectParameters><asp:ControlParameter Name="Id_usuario" Type="Int32" ControlID="lbl_id_usuario" PropertyName="Text" /></SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


