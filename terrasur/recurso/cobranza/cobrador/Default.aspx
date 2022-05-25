<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cobradores" %>
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
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrador", "view") Then
                id_rol = New rol(ConfigurationManager.AppSettings("cobrador_codigo")).id_rol
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrador", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_cobrador_abm.Text = "Nuevo cobrador"
        Usuario2Abm1.CargarInsertar(id_rol)
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If Usuario2Abm1.VerificarInsertar Then
            If Usuario2Abm1.Insertar Then
                Usuario2Abm1.CargarInsertar(id_rol)
                gv_cobrador.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If Usuario2Abm1.VerificarActualizar Then
            If Usuario2Abm1.Actualizar Then
                gv_cobrador.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_cobrador_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_cobrador.DataBound
        gv_cobrador.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrador", "update")
        gv_cobrador.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrador", "delete")
    End Sub

    Protected Sub gv_cobrador_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_cobrador.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_contratos_asignados").ToString).Equals(0) = True Then
                If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_dosificaciones").ToString).Equals(0) = True Then
                    CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = True
                Else
                    CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = False
                End If
            Else
                CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub gv_cobrador_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_cobrador.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_cobrador") = Integer.Parse(gv_cobrador.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_cobrador_abm.Text = "Edición de datos de un cobrador"
                Usuario2Abm1.CargarActualizar(id_rol, Integer.Parse(gv_cobrador.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim user As New usuario(Integer.Parse(e.CommandArgument.ToString))
                If user.Eliminar(id_rol, Profile.id_usuario) Then
                    gv_cobrador.DataBind()
                    Msg1.Text = "El cobrador se eliminó correctamente"
                Else
                    Msg1.Text = "El cobrador NO se eliminó correctamente"
                End If
        End Select
    End Sub


    Protected Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/cobrador/busquedaRecibo.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
       <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cobrador" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_id_rol" runat="server" Text="0" Visible="false"></asp:Label>
<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/cobranza/cobrador/cobradorDetalle.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="0" Win_Left="0" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="0" Win_Width="0">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Cobradores</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo cobrador" />
                                </td>
                            </tr>
                           <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_cobrador" runat="server" AllowSorting="true" AutoGenerateColumns="false" DataSourceID="ods_cobrador_lista" DataKeyNames="id_usuario">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_usuario") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar al cobrador?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Ap. Paterno" DataField="paterno" SortExpression="paterno" />
                                            <asp:BoundField HeaderText="Ap. Materno" DataField="materno" SortExpression="materno" />
                                            <asp:BoundField HeaderText="Nombres" DataField="nombres" SortExpression="nombres" />
                                            <asp:BoundField HeaderText="C.I." DataField="ci" SortExpression="ci" />
                                            <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" SortExpression="nombre_usuario" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" SortExpression="activo" Text="Activo" />                    
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_cobrador],[id_usuario],[codigo],[nombre],[valor]--%>
                                    <asp:ObjectDataSource ID="ods_cobrador_lista" runat="server" TypeName="terrasur.cobrador" SelectMethod="ListaNoEliminado">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                            <table class="formEntTable">
                                <tr>
                                    <td class="formEntTdTitle">
                                        <asp:Label ID="lbl_cobrador_abm" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="formEntTdForm">
                                        <uc2:usuario2Abm ID="Usuario2Abm1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formEntTdButton">
                                        <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>"
                                            TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true"
                                            ValidationGroup="cobrador" />
                                        <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>"
                                            TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true"
                                            ValidationGroup="cobrador" />
                                        <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>"
                                            CausesValidation="false" SkinID="btnAccion" />
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

