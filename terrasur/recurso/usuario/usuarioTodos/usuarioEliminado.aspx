<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Usuarios eliminados" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Response.Redirect("~/recurso/usuario/usuarioTodos/Default.aspx")
    End Sub

    Protected Sub gv_usuario_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_usuario.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_usuario") = Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "recuperar"
                Dim u As New usuario(Integer.Parse(gv_usuario.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                If u.RecuperarEliminado(Profile.id_usuario) Then
                    Msg1.Text = "Los datos del usuario se recuperaron correctamente"
                    gv_usuario.DataBind()
                Else
                    Msg1.Text = "Los datos del usuario NO se recuperaron correctamente"
                End If
        End Select
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="usuarioTodos" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/usuario/usuarioTodos/usuarioDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Usuarios eliminados</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr><td class="tdButtonVolver"><asp:Button ID="btn_volver" runat="server" Text="Volver a la lista de usuarios" SkinID="btnVolver" /></td></tr>
                    <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_usuario" runat="server" AutoGenerateColumns="false" DataSourceID="ods_usuario_lista_eliminados" DataKeyNames="id_usuario">
                                <Columns>
                                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                    <asp:ButtonField CommandName="recuperar" Text="Recuperar" ButtonType="Image" ImageUrl="~/images/gv/undo.gif" />
                                    <asp:BoundField HeaderText="C.I." DataField="ci" />
                                    <asp:BoundField HeaderText="Ap.Paterno" DataField="paterno" />
                                    <asp:BoundField HeaderText="Ap.Materno" DataField="materno" />
                                    <asp:BoundField HeaderText="Nombres" DataField="nombres" />
                                    <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                                    <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />
                                    <asp:BoundField HeaderText="Roles" DataField="roles" />
                                </Columns>
                            </asp:WizardGridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--[id_usuario],[nombres],[paterno],[materno],[ci],[nombre_usuario],[password],[activo],[eliminable],[numero_roles]--%>
    <asp:ObjectDataSource ID="ods_usuario_lista_eliminados" runat="server" TypeName="terrasur.usuario" SelectMethod="Lista">
        <SelectParameters>
            <asp:Parameter Name="Id_rol" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Eliminado" Type="Boolean" DefaultValue="True" />
            <asp:Parameter Name="Busqueda" Type="Boolean" DefaultValue="False" />
            <asp:Parameter Name="Ci" Type="String" DefaultValue="" />
            <asp:Parameter Name="Paterno" Type="String" DefaultValue="" />
            <asp:Parameter Name="Materno" Type="String" DefaultValue="" />
            <asp:Parameter Name="Nombres" Type="String" DefaultValue="" />
            <asp:Parameter Name="Nombre_usuario" Type="String" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


