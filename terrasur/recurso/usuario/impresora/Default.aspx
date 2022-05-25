<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Impresoras" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/usuario/impresora/userControl/impresoraAbm.ascx" TagName="impresoraAbm" TagPrefix="uc1" %>


<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_impresora_abm.Text = "Nueva impresora"
        ImpresoraAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If ImpresoraAbm1.VerificarInsertar Then
            If ImpresoraAbm1.Insertar Then
                gv_impresora.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If ImpresoraAbm1.VerificarActualizar Then
            If ImpresoraAbm1.Actualizar Then
                gv_impresora.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_impresora_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_impresora.DataBound
        gv_impresora.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "update")
        gv_impresora.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "delete")
    End Sub

    Protected Sub gv_impresora_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_impresora.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_usuarios").ToString()).Equals(0)
        End If
    End Sub

    Protected Sub gv_impresora_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_impresora.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_impresora_abm.Text = "Edición de datos de una impresora"
                ImpresoraAbm1.CargarActualizar(Integer.Parse(gv_impresora.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim impresoraObj As New impresora(Integer.Parse(e.CommandArgument.ToString))
                If impresoraObj.Eliminar() Then
                    gv_impresora.DataBind()
                    Msg1.Text = "La impresora se eliminó correctamente"
                Else
                    Msg1.Text = "La impresora NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="impresora" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Impresoras</td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nueva impresora" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server">
                                    </asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_impresora" runat="server" AutoGenerateColumns="false" DataSourceID="ods_impresora_lista"
                                        DataKeyNames="id_impresora">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_impresora") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la impresora?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                            <asp:BoundField HeaderText="Dirección de red" DataField="direccion_red" />
                                            <asp:CheckBoxField HeaderText="Factura" Text="Factura" DataField="factura"/>
                                            <asp:CheckBoxField HeaderText="Recibo" Text="Recibo" DataField="recibo"/>
                                            <asp:CheckBoxField HeaderText="Comprobante" Text="Comprobante" DataField="comprobante"/>
                                            <%--<asp:BoundField HeaderText="Documento" DataField="documento" />--%>
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />
                                            <asp:BoundField HeaderText="No. usuarios" DataField="num_usuarios" ItemStyle-CssClass="gvCell1"/>
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_impresora],[id_usuario],[codigo],[nombre],[valor]--%>
                                    <asp:ObjectDataSource ID="ods_impresora_lista" runat="server" TypeName="terrasur.impresora"
                                        SelectMethod="Lista">
                                        <SelectParameters >
                                            <asp:Parameter Name="factura" DefaultValue="true" Type="Boolean" />
                                            <asp:Parameter Name="recibo" DefaultValue="true" Type="Boolean" />
                                            <asp:Parameter Name="comprobante" DefaultValue="true" Type="Boolean" />
                                            <asp:Parameter Name="solo_activos" DefaultValue="false" Type="Boolean" />
                                        </SelectParameters>    
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                            <table class="formEntTable">
                                <tr>
                                    <td class="formEntTdTitle">
                                        <asp:Label ID="lbl_impresora_abm" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="formEntTdForm">
                                        <uc1:impresoraAbm id="ImpresoraAbm1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formEntTdButton">
                                        <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>"
                                            TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true"
                                            ValidationGroup="sector" />
                                        <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>"
                                            TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true"
                                            ValidationGroup="sector" />
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

