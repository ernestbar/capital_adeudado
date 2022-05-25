<%@ Control Language="VB" ClassName="usuarioNuevoRol" %>

<script runat="server">
    Public Property id_usuario() As Integer
        Get
            Return Integer.Parse(lbl_id_usuario.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_usuario.Text = value
        End Set
    End Property

    Public Sub CargarInsertar(ByVal _id_usuario As Integer)
        id_usuario = _id_usuario
        Dim u As New usuario(id_usuario)
        lbl_paterno.Text = u.paterno
        lbl_materno.Text = u.materno
        lbl_nombres.Text = u.nombres
        lbl_ci.Text = u.ci
        lbl_nombre_usuario.Text = u.nombre_usuario
        ddl_nuevo_rol.DataBind()
    End Sub
    
    Public Function VerificarInsertar() As Boolean
        Return ddl_nuevo_rol.Items.Count.Equals(0).Equals(False)
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            If usuario_rol.InsertarEliminar(True, Me.id_usuario, Integer.Parse(ddl_nuevo_rol.SelectedValue)) Then
                For Each item_gr As RepeaterItem In r_grupo_recurso.Items
                    For Each item_r As RepeaterItem In CType(item_gr.FindControl("r_recurso"), Repeater).Items
                        For Each item As ListItem In CType(item_r.FindControl("cbl_permiso"), CheckBoxList).Items
                            If item.Selected Then
                                usuario_rol_permiso.InsertarEliminar(True, Me.id_usuario, Integer.Parse(ddl_nuevo_rol.SelectedValue), Integer.Parse(item.Value))
                            End If
                        Next
                    Next
                Next
                CargarPerfilUsuario(Me.id_usuario, Integer.Parse(ddl_nuevo_rol.SelectedValue))
                Msg1.Text = "El nuevo rol del usuario se guardó correctamente"
                Return True
            Else
                Msg1.Text = "El nuevo rol del usuario NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
    Protected Sub r_grupo_recurso_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_grupo_recurso.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("r_recurso"), Repeater).DataSource = recurso.ListaPorRolGrupoRecurso(Integer.Parse(ddl_nuevo_rol.SelectedValue), Integer.Parse(DataBinder.Eval(e.Item.DataItem, "id_gruporecurso")))
            CType(e.Item.FindControl("r_recurso"), Repeater).DataBind()
        End If
    End Sub
    Protected Sub r_recurso_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        CType(e.Item.FindControl("cbl_permiso"), CheckBoxList).DataSource = permiso.ListaPorRecurso(Integer.Parse(DataBinder.Eval(e.Item.DataItem, "id_recurso")))
        CType(e.Item.FindControl("cbl_permiso"), CheckBoxList).DataBind()
    End Sub
    
    Public Sub CargarPerfilUsuario(ByVal Id_usuario As Integer, ByVal Id_rol As Integer)
        Dim usr As New usuario(Id_usuario)
        Dim pc As ProfileCommon = Profile.GetProfile(usr.nombre_usuario)
        pc.id_usuario = usr.id_usuario
        pc.nombre_usuario = usr.nombre_usuario
        pc.nombre_persona = usr.paterno & " " & usr.materno & " " & usr.nombres
        pc.imagen = usuario.ImagenDireccion(usr.imagen)
        Dim codigo_modulo As String = New modulo(New rol(Id_rol).id_modulo).codigo
        If codigo_modulo <> "" Then
            Try
                pc.SetPropertyValue("menu_modulos." & codigo_modulo, general.MenuStringEliminados(Id_usuario, Id_rol))
            Catch ex As Exception
            End Try
        End If
        pc.Save()
    End Sub

</script>
<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_nuevo_rol" runat="server" DisplayMode="List" ValidationGroup="nuevo_rol" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del nuevo rol del usuario"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_paterno_enun" runat="server" Text="Apellido paterno:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_paterno" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_materno_enun" runat="server" Text="Apellido materno:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_materno" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_nombres_enun" runat="server" Text="Nombres:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_nombres" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_ci_enun" runat="server" Text="Nº doc. de identidad:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_ci" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_nombre_usuario_enun" runat="server" Text="Nombre de usuario:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_nombre_usuario" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_nuevo_rol_enun" runat="server" Text="Nuevo rol del usuario:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_nuevo_rol" runat="server" ControlToValidate="ddl_nuevo_rol" Display="Dynamic" ValidationGroup="nuevo_rol" Text="*" ErrorMessage="No existen otros roles disponibles para el usuario"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddl_nuevo_rol" runat="server" AutoPostBack="true" DataSourceID="ods_lista_nuevo_rol" DataTextField="nombre" DataValueField="id_rol"></asp:DropDownList>
            <%--[id_rol],[id_modulo],[codigo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_nuevo_rol" runat="server" TypeName="terrasur.rol" SelectMethod="ListaNuevoRol">
                <SelectParameters><asp:ControlParameter Name="Id_usuario" Type="Int32" ControlID="lbl_id_usuario" PropertyName="Text" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_permisos" runat="server" Text="Permisos:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Panel ID="panel_recurso" runat="server" ScrollBars="Vertical" Height="270">
            <%--[id_gruporecurso],[codigo],[nombre]--%>
            <asp:Repeater ID="r_grupo_recurso" runat="server" DataSourceID="ods_ListaPorRol">
                <HeaderTemplate><table></HeaderTemplate>
                <ItemTemplate><tr><td>
                    <asp:Panel ID="panel_gruporecurso" runat="server" GroupingText='<%# Eval("nombre") %>'>
                        <%--[id_recurso],[id_gruporecurso],[codigo],[nombre]--%>
                        <asp:Repeater ID="r_recurso" runat="server" OnItemDataBound="r_recurso_ItemDataBound">
                            <ItemTemplate>
                                <asp:Panel ID="panel_recurso" runat="server" GroupingText='<%# Eval("nombre") %>'>
                                    <asp:CheckBoxList ID="cbl_permiso" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" DataTextField="nombre" DataValueField="id_permiso"></asp:CheckBoxList>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </td></tr></ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
            </asp:Panel>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="ods_ListaPorRol" runat="server" TypeName="terrasur.grupo_recurso" SelectMethod="ListaPorRol">
    <SelectParameters>
        <asp:ControlParameter Name="Id_rol" Type="Int32" ControlID="ddl_nuevo_rol" PropertyName="SelectedValue" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
