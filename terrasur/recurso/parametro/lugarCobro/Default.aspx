<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Lugares de Cobro" %>
<%@ Register Src="~/recurso/parametro/lugarCobro/userControl/lugarCobroAbm.ascx" TagName="lugarCobroAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lugarCobro", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lugarCobro", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_lugarCobro_abm.Text = "Nuevo lugar de cobro"
        LugarCobroAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If LugarCobroAbm1.VerificarInsertar Then
            If LugarCobroAbm1.Insertar Then
                gv_lugarCobro.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If LugarCobroAbm1.VerificarActualizar Then
            If LugarCobroAbm1.Actualizar Then
                gv_lugarCobro.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_banco_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_lugarCobro.DataBound
        gv_lugarCobro.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lugarCobro", "update")
        gv_lugarCobro.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lugarCobro", "delete")
    End Sub

    Protected Sub gv_lugarCobro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_lugarCobro.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_clientes").ToString).Equals(0)
            If DataBinder.Eval(e.Row.DataItem, "codigo").ToString() = "terrasur" Or DataBinder.Eval(e.Row.DataItem, "codigo").ToString() = "domicilio" Or DataBinder.Eval(e.Row.DataItem, "codigo").ToString() = "oficina" Then
                CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub gv_lugarCobro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_lugarCobro.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_lugarCobro_abm.Text = "Edición de datos de un lugar de cobro"
                LugarCobroAbm1.CargarActualizar(Integer.Parse(gv_lugarCobro.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim lugarCobroObj As New lugar_cobro(Integer.Parse(e.CommandArgument.ToString))
                If lugarCobroObj.Eliminar(Profile.id_usuario) Then
                    gv_lugarCobro.DataBind()
                    Msg1.Text = "El lugar de cobro se eliminó correctamente"
                Else
                    Msg1.Text = "El lugar de cobro NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="lugarCobro" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Lugares de Cobro</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo lugar de cobro" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_lugarCobro" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lugarCobro_lista" DataKeyNames="id_lugarcobro">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_lugarcobro") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el lugar de cobro?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Lugar de cobro" DataField="nombre" />
                                            <asp:CheckBoxField HeaderText="Cobrador" DataField="cobrador" Text="Cobrador" />                    
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_lugarcobro],[id_usuario],[codigo],[nombre],[cobrador],[num_clientes]--%>
                                    <asp:ObjectDataSource ID="ods_lugarCobro_lista" runat="server" TypeName="terrasur.lugar_cobro" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_lugarCobro_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc1:lugarCobroAbm ID="LugarCobroAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="lugarCobro" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="lugarCobro" />
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

