<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Usuarios" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuarioCriterio.ascx" TagName="usuarioCriterio" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuarioAbm.ascx" TagName="usuarioAbm" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuarioNuevoRol.ascx" TagName="usuarioNuevoRol" TagPrefix="uc3" %>

<script runat="server">
    Protected Property id_rol() As Integer
        Get
            Return Integer.Parse(lbl_id_rol.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_rol.Text = value
            btn_nuevo.Visible = value.Equals(0).Equals(False)
            If value = 0 Then
                lbl_titulo_usuario.Text = "Todos"
                codigo_rol = ""
            Else
                Dim rolObj As New rol(value)
                lbl_titulo_usuario.Text = rolObj.nombre
                codigo_rol = rolObj.codigo
            End If
        End Set
    End Property
    Protected Property codigo_rol() As String
        Get
            Return lbl_codigo_rol.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_rol.Text = value
        End Set
    End Property
    
    
    Protected Property busqueda() As Boolean
        Get
            Return Boolean.Parse(lbl_busqueda.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_busqueda.Text = value
            panel_criterio.Visible = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_rol") Is Nothing Then
                id_rol = 0
            Else
                id_rol = Integer.Parse(Session("id_rol").ToString)
                Session.Remove("id_rol")
            End If
        End If
    End Sub

    Protected Sub r_rol_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles r_rol.ItemCommand
        If e.CommandName = "elegir_rol" Then
            id_rol = Integer.Parse(e.CommandArgument)
            busqueda = False
            gv_usuario.DataBind()
            MultiView1.ActiveViewIndex = 0
        End If
    End Sub
    Protected Sub ods_usuario_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_usuario_lista.Selecting
        e.InputParameters("Ci") = UsuarioCriterio1.ci
        e.InputParameters("Paterno") = UsuarioCriterio1.paterno
        e.InputParameters("Materno") = UsuarioCriterio1.materno
        e.InputParameters("Nombres") = UsuarioCriterio1.nombres
        e.InputParameters("Nombre_usuario") = UsuarioCriterio1.usuario
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_usuario_abm.Text = "Nuevo " & New rol(id_rol).nombre
        UsuarioAbm1.CargarInsertar(id_rol)
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        busqueda = True
        UsuarioCriterio1.Reset()
    End Sub
    Protected Sub btn_eliminados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminados.Click
        Response.Redirect("~/recurso/usuario/usuarioTodos/usuarioEliminado.aspx")
    End Sub
    Protected Sub btn_criterio_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_buscar.Click
        If UsuarioCriterio1.TieneCriterio Then
            gv_usuario.DataBind()
        Else
            msg_criterio.Text = "Debe introducir un criterio de busqueda"
        End If
    End Sub
    Protected Sub btn_criterio_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_cancelar.Click
        busqueda = False
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If UsuarioAbm1.VerificarInsertar Then
            If UsuarioAbm1.Insertar Then
                UsuarioAbm1.CargarInsertar(id_rol)
                gv_usuario.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If UsuarioAbm1.VerificarActualizar Then
            If UsuarioAbm1.Actualizar Then
                gv_usuario.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        busqueda = False
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub gv_usuario_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_usuario.DataBound
        gv_usuario.Columns(1).Visible = id_rol.Equals(0).Equals(False)
        gv_usuario.Columns(2).Visible = id_rol.Equals(0).Equals(False)
        If codigo_rol = "adm" Then
            gv_usuario.Columns(3).Visible = False
        Else
            gv_usuario.Columns(3).Visible = id_rol.Equals(0).Equals(False)
        End If
        gv_usuario.Columns(gv_usuario.Columns.Count - 1).Visible = id_rol.Equals(0)
    End Sub

    Protected Sub gv_usuario_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_usuario.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            If codigo_rol = "adm" AndAlso Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_usuario")) <> Profile.id_usuario Then
                'CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
            End If
            CType(e.Row.Cells(2).Controls(0), ImageButton).OnClientClick = "return confirm('¿Esta seguro que desea eliminar el usuario " + lbl_titulo_usuario.Text + "?');"
        End If
    End Sub
    
    Protected Sub gv_usuario_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_usuario.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_usuario") = Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_usuario_abm.Text = "Edición de datos de un " & New rol(id_rol).nombre
                UsuarioAbm1.CargarActualizar(id_rol, Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                'Dim user As New usuario(Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                Dim user As New usuario(Integer.Parse(e.CommandArgument.ToString))
                If user.Eliminar(id_rol, Profile.id_usuario) Then
                    gv_usuario.DataBind()
                    Msg1.Text = "El usuario se eliminó correctamente"
                Else
                    Msg1.Text = "El usuario NO se eliminó correctamente"
                End If
            Case "nuevo_rol"
                UsuarioNuevoRol1.CargarInsertar(Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_nuevo_rol_insertar.Enabled = UsuarioNuevoRol1.VerificarInsertar
                MultiView1.ActiveViewIndex = 2
        End Select
    End Sub

    Protected Sub btn_nuevo_rol_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo_rol_insertar.Click
        If UsuarioNuevoRol1.VerificarInsertar Then
            If UsuarioNuevoRol1.Insertar Then
                UsuarioNuevoRol1.CargarInsertar(UsuarioNuevoRol1.id_usuario)
                btn_nuevo_rol_insertar.Enabled = UsuarioNuevoRol1.VerificarInsertar
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_rol_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo_rol_cancelar.Click
        busqueda = False
        MultiView1.ActiveViewIndex = 0
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc4:recursoMaster ID="RecursoMaster1" runat="server" recurso="usuarioTodos" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/usuario/usuarioTodos/usuarioDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
    <asp:Label ID="lbl_id_rol" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_rol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_busqueda" runat="server" Text="False" Visible="false"></asp:Label>
    <table class="priTable">
        <tr>
            <td></td>
            <td class="priTdTitle">Usuario: <asp:Label ID="lbl_titulo_usuario" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="usuarioTdRoles">
                <asp:Repeater ID="r_rol" runat="server" DataSourceID="ods_rol_lista">
                    <HeaderTemplate><table></HeaderTemplate>
                    <ItemTemplate><tr><td><asp:LinkButton ID="lb_rol" runat="server" Text='<%# Eval("nombre") %>' SkinID="lbUsuarioRol" CommandArgument='<%# Eval("id_rol") %>' CommandName="elegir_rol"></asp:LinkButton></td></tr></ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
                <%--[id_rol],[codigo],[nombre]--%>
                <asp:ObjectDataSource ID="ods_rol_lista" runat="server" TypeName="terrasur.rol" SelectMethod="Lista">
                    <SelectParameters><asp:Parameter Name="para_menu" Type="Boolean" DefaultValue="True" /></SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo usuario" />
                                    <asp:Button ID="btn_busqueda" runat="server" Text="Busqueda de usuarios" />
                                    <asp:Button ID="btn_eliminados" runat="server" Text="Usuarios eliminados" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdBusqueda">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de búsqueda" DefaultButton="btn_criterio_buscar" Visible="false">
                                                    <table>
                                                        <tr><td class="formHorTdMsg"><asp:Msg ID="msg_criterio" runat="server"></asp:Msg></td></tr>
                                                        <tr><td class="formHorEntTdForm"><uc1:usuarioCriterio ID="UsuarioCriterio1" runat="server" /></td></tr>
                                                        <tr>
                                                            <td class="formHorEntTdButton">
                                                                <asp:Button ID="btn_criterio_buscar" runat="server" Text="Buscar" CausesValidation="true" ValidationGroup="criterio" SkinID="btnAccion" />
                                                                <asp:Button ID="btn_criterio_cancelar" runat="server" Text="Cancelar" CausesValidation="false" SkinID="btnAccion" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_usuario" runat="server" AutoGenerateColumns="false" DataSourceID="ods_usuario_lista" DataKeyNames="id_usuario" >
                                        <Columns>
                                            <%--<asp:TemplateField><ItemTemplate><asp:HyperLink ID="hl_ver" runat="server" SkinID="hlVer" NavigateUrl='<%# String.Format("~/recurso/usuario/usuarioTodos/usuarioDetalle.aspx?id={0}",Eval("id_usuario")) %>'></asp:HyperLink></ItemTemplate></asp:TemplateField>--%>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <%--<asp:ButtonField CommandName="eliminar" Text="X" ControlStyle-CssClass="gvButtonDelete"/>--%>
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_usuario") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar al usuario?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="nuevo_rol" Text="Nuevo rol" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="C.I." DataField="ci" />
                                            <asp:BoundField HeaderText="Ap.Paterno" DataField="paterno" />
                                            <asp:BoundField HeaderText="Ap.Materno" DataField="materno" />
                                            <asp:BoundField HeaderText="Nombres" DataField="nombres" />
                                            <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />
                                            <asp:BoundField HeaderText="Roles" DataField="roles" />
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_usuario],[nombres],[paterno],[materno],[ci],[nombre_usuario],[password],[activo],[eliminable],[roles]--%>
                                    <asp:ObjectDataSource ID="ods_usuario_lista" runat="server" TypeName="terrasur.usuario" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_rol" Type="Int32" ControlID="lbl_id_rol" PropertyName="Text" DefaultValue="0" />
                                            <asp:Parameter Name="Eliminado" Type="Boolean" DefaultValue="False" />
                                            <asp:ControlParameter Name="Busqueda" Type="Boolean" ControlID="lbl_busqueda" PropertyName="Text" DefaultValue="False" />
                                            <asp:Parameter Name="Ci" Type="String" />
                                            <asp:Parameter Name="Paterno" Type="String" />
                                            <asp:Parameter Name="Materno" Type="String" />
                                            <asp:Parameter Name="Nombres" Type="String" />
                                            <asp:Parameter Name="Nombre_usuario" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_usuario_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc2:usuarioAbm ID="UsuarioAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="usuario" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="usuario" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <asp:Panel ID="panel_nuevo_rol" runat="server" DefaultButton="btn_nuevo_rol_insertar">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_nuevo_rol_abm" runat="server" Text="Nuevo rol del usuario"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc3:usuarioNuevoRol ID="UsuarioNuevoRol1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_nuevo_rol_insertar" runat="server" Text="Guardar nuevo rol" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="nuevo_rol"/>
                                    <asp:Button ID="btn_nuevo_rol_cancelar" runat="server" Text="Cancelar / Volver" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>


