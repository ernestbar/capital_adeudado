<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Sucursales" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/parametro/sucursal/userControl/sucursalAbm.ascx" TagName="sucursalAbm" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sucursal", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sucursal", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_sucursal_abm.Text = "Nueva sucursal"
        SucursalAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If SucursalAbm1.VerificarInsertar Then
            If SucursalAbm1.Insertar Then
                gv_sucursal.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If SucursalAbm1.VerificarActualizar Then
            If SucursalAbm1.Actualizar Then
                gv_sucursal.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_sucursal_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_sucursal.DataBound
        gv_sucursal.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sucursal", "update")
        gv_sucursal.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sucursal", "delete")
    End Sub

    Protected Sub gv_sucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_sucursal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_transacciones").ToString) + Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_parametros").ToString) > 0 Then
                CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub gv_sucursal_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_sucursal.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_sucursal_abm.Text = "Edición de datos de una sucursal"
                SucursalAbm1.CargarActualizar(Integer.Parse(gv_sucursal.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim sucursalObj As New sucursal(Integer.Parse(e.CommandArgument.ToString), 0)
                If sucursalObj.Eliminar(Profile.id_usuario) Then
                    gv_sucursal.DataBind()
                    Msg1.Text = "La sucursal se eliminó correctamente"
                Else
                    Msg1.Text = "La sucursal NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="sucursal" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Sucursales</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nueva sucursal" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_sucursal" runat="server" AutoGenerateColumns="false" DataSourceID="ods_sucursal_lista" DataKeyNames="id_sucursal">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_sucursal") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la sucursal?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Nº" DataField="num_sucursal" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                            <asp:BoundField HeaderText="Dirección" DataField="direccion" />
                                            <asp:BoundField HeaderText="Teléfono(s)" DataField="telefono" />
                                            <asp:BoundField HeaderText="Lugar" DataField="lugar" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />                    
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_sucursal],[num_sucursal],[nombre],[direccion],[telefono],[lugar],[activo],[num_transacciones],[num_parametros]--%>
                                    <asp:ObjectDataSource ID="ods_sucursal_lista" runat="server" TypeName="terrasur.sucursal" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_sucursal_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc3:sucursalabm id="SucursalAbm1" runat="server"></uc3:sucursalabm>
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="sucursal" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="sucursal" />
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

