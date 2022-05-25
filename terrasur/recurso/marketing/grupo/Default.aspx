<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Grupos de venta" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/marketing/grupo/userControl/grupoAbm.ascx" TagName="grupoAbm" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupo", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupo", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_grupo_abm.Text = "Nuevo grupo de ventas"
        GrupoAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If GrupoAbm1.VerificarInsertar Then
            GrupoAbm1.Insertar()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If GrupoAbm1.VerificarActualizar Then
            GrupoAbm1.Actualizar()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        gv_grupoventa.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    Protected Sub gv_grupoventa_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_grupoventa.DataBound
        gv_grupoventa.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupo", "update")
        gv_grupoventa.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupo", "delete")
    End Sub

    Protected Sub gv_grupoventa_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_grupoventa.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_asignacion").ToString) > 0 Then
                CType(e.Row.Cells(2).Controls(0), ImageButton).OnClientClick = "return confirm('¿El grupo de venta no puede ser eliminado y será marcado como INACTIVO?');"
            Else
                CType(e.Row.Cells(2).Controls(0), ImageButton).OnClientClick = "return confirm('¿Esta seguro que desea eliminar el grupo de venta?');"
            End If
        End If
    End Sub
    
    Protected Sub gv_grupoventa_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_grupoventa.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_grupoventa") = Integer.Parse(gv_grupoventa.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_grupo_abm.Text = "Edición de datos de un grupo de ventas"
                GrupoAbm1.CargarActualizar(Integer.Parse(gv_grupoventa.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim grupoObj As New grupo_venta(Integer.Parse(e.CommandArgument.ToString))
                If grupoObj.Eliminar() Then
                    gv_grupoventa.DataBind()
                    If grupoObj.num_asignacion > 0 Then
                        Msg1.Text = "El grupo de ventas se marcó como INACTIVO"
                    Else
                        Msg1.Text = "El grupo de ventas se eliminó correctamente"
                    End If
                Else
                    Msg1.Text = "El grupo de ventas NO se eliminó correctamente"
                End If
        End Select
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="grupo" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/marketing/grupo/grupoDetalle.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="0" Win_Left="0" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="0" Win_Width="0">[WinPopUp1]</asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Grupos de venta</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo grupo de ventas" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_grupoventa" runat="server" AutoGenerateColumns="false" DataSourceID="ods_grupoventa_lista" DataKeyNames="id_grupoventa">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_grupoventa") %>'/></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Nombre del grupo" DataField="nombre" />
                                            <asp:BoundField HeaderText="Director de ventas" DataField="nombre_director" />
                                            <asp:TemplateField HeaderText="Activo"><ItemTemplate><asp:Label ID="lbl_activo" runat="server" Text='<%# general.StringActivo(Eval("activo").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:CheckBoxField HeaderText="En planilla" DataField="en_planilla" Text="En planilla" />
                                            <asp:BoundField HeaderText="Nº promot." DataField="num_promotor_activo" ItemStyle-CssClass="gvCell1" />
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_grupoventa],[id_director],[nombre],[activo],[en_planilla],[num_promotor],[num_promotor_activo],[num_asignacion],[nombre_director]--%>
                                    <asp:ObjectDataSource ID="ods_grupoventa_lista" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="Lista">
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
                                    <asp:Label ID="lbl_grupo_abm" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdForm">
                                    <uc2:grupoAbm ID="GrupoAbm1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="grupoventa" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="grupoventa" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
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