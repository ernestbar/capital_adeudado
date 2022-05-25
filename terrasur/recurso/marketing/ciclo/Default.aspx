<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Ciclos comerciales" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/marketing/ciclo/userControl/cicloAbm.ascx" TagName="cicloAbm" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "ciclo", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "ciclo", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_ciclo_abm.Text = "Nuevo ciclo comercial"
        If gv_ciclo.Rows.Count > 0 Then
            CicloAbm1.CargarInsertar(CType(gv_ciclo.Rows(gv_ciclo.Rows.Count - 1).Cells(2).FindControl("lbl_final"), Label).Text)
        Else
            CicloAbm1.CargarInsertar("")
        End If
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If CicloAbm1.VerificarInsertar Then
            If CicloAbm1.Insertar Then
                gv_ciclo.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If CicloAbm1.VerificarActualizar Then
            If CicloAbm1.Actualizar Then
                gv_ciclo.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    
    Protected Sub gv_ciclo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_ciclo.DataBound
        gv_ciclo.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "ciclo", "update")
        gv_ciclo.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "ciclo", "delete")
        If gv_ciclo.Rows.Count > 0 Then
            For i As Integer = 0 To gv_ciclo.Rows.Count - 2
                'If i < gv_ciclo.Rows.Count - 1 Then
                CType(gv_ciclo.Rows(i).Cells(1).Controls(0), ImageButton).Visible = False
                'End If
            Next
        End If
    End Sub

    Protected Sub gv_ciclo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_ciclo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            
        End If
    End Sub

    
    Protected Sub gv_ciclo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_ciclo.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_ciclo_abm.Text = "Edición de datos de un ciclo comercial"
                CicloAbm1.CargarActualizar(Integer.Parse(gv_ciclo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim cicloObj As New ciclo_comercial(Integer.Parse(e.CommandArgument.ToString))
                If cicloObj.Eliminar(Profile.id_usuario) Then
                    gv_ciclo.DataBind()
                    Msg1.Text = "El ciclo comercial se eliminó correctamente"
                Else
                    Msg1.Text = "El ciclo comercial NO se eliminó correctamente"
                End If
        End Select
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="ciclo" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Ciclos comerciales</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo ciclo comercial" />
                                </td>
                            </tr>
                            <tr><td class="tdMsg"><asp:Msg id="Msg1" runat="server"></asp:Msg></td></tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_ciclo" runat="server" AutoGenerateColumns="false" DataSourceID="ods_ciclo_lista" DataKeyNames="id_ciclocomercial">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_ciclocomercial") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el ciclo comercial?');" /></ItemTemplate></asp:TemplateField>
                                            <%--<asp:BoundField HeaderText="Fecha de inicio" DataField="inicio" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField HeaderText="Fecha final" DataField="fin" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />--%>
                                            <asp:TemplateField HeaderText="Ciclo comercial"><ItemTemplate><asp:Label ID="lbl_ciclo" runat="server" Text='<%# String.format("{0:dd/MM/yyyy} - {1:dd/MM/yyyy}",Eval("inicio"),Eval("fin")) %>'></asp:Label><asp:Label ID="lbl_final" runat="server" Text='<%# Eval("fin") %>' Visible="false"></asp:Label></ItemTemplate></asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_ciclocomercial],[inicio],[fin]--%>
                                    <asp:ObjectDataSource ID="ods_ciclo_lista" runat="server" TypeName="terrasur.ciclo_comercial" SelectMethod="Lista">
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
                                    <asp:Label ID="lbl_ciclo_abm" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdForm">
                                    <uc2:cicloAbm ID="CicloAbm1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="ciclo" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="ciclo" />
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