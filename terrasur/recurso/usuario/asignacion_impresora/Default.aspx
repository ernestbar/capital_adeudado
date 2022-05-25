<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Asignación de Impresoras" %>
<%@ Register Src="~/recurso/usuario/asignacion_impresora/userControl/asignacion_impresoraAbm.ascx" TagName="asignacion_impresoraAbm"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignacion_impresora", "asignar") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_impresora_abm.Text = "Nueva asignación"
        Asignacion_impresoraAbm1.Cargar(0)
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If Asignacion_impresoraAbm1.InsertarEliminar Then
            'MultiView1.ActiveViewIndex = 0
            gv_asignacion.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If Asignacion_impresoraAbm1.InsertarEliminar Then
            'MultiView1.ActiveViewIndex = 0
            gv_asignacion.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_asignacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_asignacion.DataBound
        'gv_impresora.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "update")
        'gv_impresora.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "impresora", "delete")
    End Sub

    Protected Sub gv_asignacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_asignacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            CType(e.Row.FindControl("cbl_facturas"), BulletedList).DataSource = impresora_usuario.ListaImpresoraPorUsuario(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_usuario").ToString()), True, False, False, True)
            CType(e.Row.FindControl("cbl_facturas"), BulletedList).DataBind()
            CType(e.Row.FindControl("cbl_recibos"), BulletedList).DataSource = impresora_usuario.ListaImpresoraPorUsuario(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_usuario").ToString()), False, True, False, True)
            CType(e.Row.FindControl("cbl_recibos"), BulletedList).DataBind()
            CType(e.Row.FindControl("cbl_comprobantes"), BulletedList).DataSource = impresora_usuario.ListaImpresoraPorUsuario(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_usuario").ToString()), False, False, True, True)
            CType(e.Row.FindControl("cbl_comprobantes"), BulletedList).DataBind()
        End If
    End Sub

    Protected Sub gv_asignacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_asignacion.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_impresora_abm.Text = "Edición de asignación de impresoras"
                Asignacion_impresoraAbm1.Cargar(Integer.Parse(gv_asignacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
        End Select
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
        <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="asignacion_impresora" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Asignación de Impresoras</td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nueva asignación" />
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
                                    <asp:GridView ID="gv_asignacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_impresora_lista" DataKeyNames="id_usuario">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                                            <asp:TemplateField HeaderText="Impresoras">
                                                <ItemTemplate>
                                                    <table class="impresoraViewTable">
                                                        <tr>
                                                            <td class="impresoraViewTdEnun">
                                                                Facturas
                                                            </td>
                                                            <td class="impresoraViewTdEnun">
                                                                Recibos
                                                            </td>
                                                            <td class="impresoraViewTdEnun">
                                                                Comprobantes
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="impresoraViewTdDato">
                                                                <asp:BulletedList ID="cbl_facturas" runat="server" RepeatDirection="Vertical" RepeatColumns="1" DataTextField="nombre" DataValueField="id_impresora">
                                                                </asp:BulletedList>
                                                            </td>
                                                            <td class="impresoraViewTdDato">
                                                                <asp:BulletedList ID="cbl_recibos" runat="server" RepeatDirection="Vertical" RepeatColumns="1" DataTextField="nombre" DataValueField="id_impresora">
                                                                </asp:BulletedList>
                                                            </td>
                                                            <td class="impresoraViewTdDato">
                                                                <asp:BulletedList ID="cbl_comprobantes" runat="server" RepeatDirection="Vertical" RepeatColumns="1" DataTextField="nombre" DataValueField="id_impresora">
                                                                </asp:BulletedList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_impresora],[id_usuario],[codigo],[nombre],[valor]--%>
                                    <asp:ObjectDataSource ID="ods_impresora_lista" runat="server" TypeName="terrasur.impresora_usuario" SelectMethod="ListaUsuarios"></asp:ObjectDataSource>
                                    <%--<asp:ObjectDataSource ID="ods_impresoras_factura" runat="server" TypeName="terrasur.impresora_usuario" SelectMethod="ListaImpresoraPorUsuario">
                                        <SelectParameters >
                                            <asp:Parameter Name="id_usuario" DefaultValue="3" Type="Int32" />
                                            <asp:Parameter Name="factura" DefaultValue="true" Type="Boolean" />
                                            <asp:Parameter Name="recibo" DefaultValue="false" Type="Boolean" />
                                            <asp:Parameter Name="comprobante" DefaultValue="false" Type="Boolean" />
                                            <asp:Parameter Name="solo_activos" DefaultValue="true" Type="Boolean" />
                                        </SelectParameters>    
                                    </asp:ObjectDataSource>--%>
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
                                        <uc1:asignacion_impresoraAbm ID="Asignacion_impresoraAbm1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formEntTdButton">
                                        <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="impresora"/>
                                        <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" />
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

