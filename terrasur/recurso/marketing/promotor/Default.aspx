<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Promotores" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuario2Abm.ascx" TagName="usuario2Abm" TagPrefix="uc2" %>

<script runat="server">
    Protected Property id_rol() As Integer
        Get
            Return Integer.Parse(lbl_id_rol.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_rol.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "promotor", "view") Then
                id_rol = New rol(ConfigurationManager.AppSettings("promotor_codigo")).id_rol
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "promotor", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_usuario_abm.Text = "Nuevo promotor"
        Usuario2Abm1.CargarInsertar(id_rol)
        rbl_tipoPromotor.SelectedIndex = 0
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub gv_usuario_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_usuario.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_promotor") = Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_usuario_abm.Text = "Edición de datos de un promotor"
                Usuario2Abm1.CargarActualizar(id_rol, Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                
                Dim utp As New usuario_tipoPromotor(Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                If utp.id_usuariotipopromotor > 0 Then
                    rbl_tipoPromotor.SelectedValue = utp.id_tipopromotor
                Else
                    rbl_tipoPromotor.SelectedIndex = 0
                End If
                
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim user As New usuario(Integer.Parse(e.CommandArgument.ToString))
                If user.Eliminar(id_rol, Profile.id_usuario) Then
                    gv_usuario.DataBind()
                    Msg1.Text = "El promotor se eliminó correctamente"
                Else
                    Msg1.Text = "El promotor NO se eliminó correctamente"
                End If
        End Select
    End Sub

    Protected Sub gv_usuario_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_usuario.DataBound
        gv_usuario.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "promotor", "update")
        gv_usuario.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "promotor", "delete")
    End Sub
    Protected Sub gv_usuario_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_usuario.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
        End If
    End Sub
    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If Usuario2Abm1.VerificarInsertar Then
            If Usuario2Abm1.Insertar Then
                Dim utp As New usuario_tipoPromotor(Usuario2Abm1.id_usuario, Integer.Parse(rbl_tipoPromotor.SelectedValue))
                utp.Insertar(Profile.id_usuario)

                Usuario2Abm1.CargarInsertar(id_rol)
                gv_usuario.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If Usuario2Abm1.VerificarActualizar Then
            If Usuario2Abm1.Actualizar Then
                Dim utp As New usuario_tipoPromotor(Usuario2Abm1.id_usuario, Integer.Parse(rbl_tipoPromotor.SelectedValue))
                utp.Insertar(Profile.id_usuario)
                
                gv_usuario.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub ddl_grupo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_grupo.DataBound
        ddl_grupo.Items.Insert(0, New ListItem("Todos los grupos", "0"))
        ddl_grupo.Items.Add(New ListItem("Promotores sin grupo", "-1"))
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="promotor" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_rol" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/marketing/promotor/promotorDetalle.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="0" Win_Left="0" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="0" Win_Width="0">[WinPopUp1]</asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Promotores</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo promotor" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table>
                                        <tr>
                                            <td><asp:Label ID="lbl_grupo_enun" runat="server" SkinID="lblEnun" Text="Grupo de ventas:"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_grupo" runat="server" AutoPostBack="true" DataSourceID="ods_lista_grupo" DataTextField="nombre" DataValueField="id_grupoventa">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ods_lista_grupo" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="Lista_ParaDropDownList">
                                                </asp:ObjectDataSource>
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
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_usuario" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_promotor" DataKeyNames="id_usuario" AllowSorting="true">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_usuario") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar al promotor?');"/></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Ap.Paterno" DataField="paterno" SortExpression="paterno" />
                                            <asp:BoundField HeaderText="Ap.Materno" DataField="materno" SortExpression="materno" />
                                            <asp:BoundField HeaderText="Nombres" DataField="nombres" SortExpression="nombres" />
                                            <asp:BoundField HeaderText="C.I." DataField="ci" SortExpression="ci" />
                                            <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" SortExpression="nombre_usuario" />
                                            <asp:TemplateField HeaderText="Activo" SortExpression="activo"><ItemTemplate><asp:Label ID="lbl_activo" runat="server" Text='<%# general.StringActivo(Eval("activo").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Grupo de venta" DataField="nombre_grupo" NullDisplayText="(Sin grupo)" SortExpression="nombre_grupo" />
                                        </Columns>
                                    </asp:WizardGridView>
                                </td>
                            </tr>
                        </table>
                        <%--[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario],[activo],[nombre_grupo]--%>
                        <asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaNoEliminado">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="ddl_grupo" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_usuario_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc2:usuario2Abm ID="Usuario2Abm1" runat="server" /></td></tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr>
                                            <td class="formTdEnun">
                                                <asp:Label ID="lbl_tipoPromotor_enun" runat="server" Text="Tipo de promotor:"></asp:Label>
                                            </td>
                                            <td class="formTdDato">
                                                <asp:RadioButtonList ID="rbl_tipoPromotor" runat="server" DataSourceID="ods_lista_tipo_promotor" DataTextField="nombre" DataValueField="id_tipopromotor" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                </asp:RadioButtonList>
                                                <%--[id_tipopromotor],[codigo],[nombre]--%>
                                                <asp:ObjectDataSource ID="ods_lista_tipo_promotor" runat="server" TypeName="terrasur.tipoPromotor" SelectMethod="Lista">
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:Button ID="btn_insertar" runat="server" Text="Guardar" CausesValidation="true" ValidationGroup="usuario" />
                                    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="usuario" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar / Volver" CausesValidation="false" />
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
