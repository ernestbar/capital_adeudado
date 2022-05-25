<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="DPR's" %>
<%@ Register Src="~/recurso/parametro/dpr/userControl/dprAbm.ascx" TagName="dprAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dpr", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dpr", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_dpr_abm.Text = "Nuevo dpr"
        DprAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If DprAbm1.VerificarInsertar Then
            If DprAbm1.Insertar Then
                gv_dpr.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If DprAbm1.VerificarActualizar Then
            If DprAbm1.Actualizar Then
                gv_dpr.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_dpr_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_dpr.DataBound
        gv_dpr.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dpr", "update")
        gv_dpr.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dpr", "delete")
    End Sub

    Protected Sub gv_dpr_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_dpr.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_pagos").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_dpr_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_dpr.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_dpr_abm.Text = "Edición de datos de un dpr"
                DprAbm1.CargarActualizar(Integer.Parse(gv_dpr.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim dprObj As New dpr(Integer.Parse(e.CommandArgument.ToString))
                If dprObj.Eliminar(Profile.id_usuario) Then
                    gv_dpr.DataBind()
                    Msg1.Text = "El dpr se eliminó correctamente"
                Else
                    Msg1.Text = "El dpr NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="dpr" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">DPR's</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo dpr" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_dpr" runat="server" AutoGenerateColumns="false" DataSourceID="ods_dpr_lista" DataKeyNames="id_dpr">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_dpr") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el dpr?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="DPR" DataField="nombre" />
                                            <asp:CheckBoxField HeaderText="Inicial" DataField="inicial" Text="Inicial" /> 
                                            <asp:CheckBoxField HeaderText="Liquidable" DataField="liquidable" Text="Liquidable" /> 
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />                    
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_dpr],[id_usuario],[codigo],[nombre],[inicial],[liquidable],[activo]--%>
                                    <asp:ObjectDataSource ID="ods_dpr_lista" runat="server" TypeName="terrasur.dpr" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_dpr_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:dprAbm ID="DprAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="dpr" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="dpr" />
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

