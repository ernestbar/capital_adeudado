<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Zonas de la ciudad" %>
<%@ Register Src="~/recurso/clienteZona/zona/userControl/zonaAbm.ascx" TagName="zonaAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "zona", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "zona", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_zona_abm.Text = "Nueva zona"
        ZonaAbm1.CargarInsertar(Integer.Parse(ddl_sector.SelectedValue))
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If ZonaAbm1.VerificarInsertar Then
            If ZonaAbm1.Insertar Then
                gv_zona.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If ZonaAbm1.VerificarActualizar Then
            If ZonaAbm1.Actualizar Then
                gv_zona.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    Protected Sub ddl_sector_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_sector.DataBound
        btn_nuevo.Enabled = ddl_sector.Items.Count.Equals(0).Equals(False)
        ddl_sector.Items.Insert(0, New ListItem("Todos", "0"))
        If ddl_sector.Items.Count > 1 Then
            If Session("id_sector") IsNot Nothing Then
                ddl_sector.SelectedValue = Session("id_sector").ToString
                Session.Remove("id_sector")
            End If
        End If
    End Sub

    Protected Sub gv_zona_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_zona.DataBound
        gv_zona.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "zona", "update")
        gv_zona.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "zona", "delete")
        gv_zona.Columns(2).Visible = Integer.Parse(ddl_sector.SelectedValue).Equals(0)
    End Sub

    Protected Sub gv_zona_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_zona.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_clientes").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_zona_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_zona.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_zona_abm.Text = "Edición de datos de una zona"
                ZonaAbm1.CargarActualizar(Integer.Parse(gv_zona.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim zonaObj As New zona(Integer.Parse(e.CommandArgument.ToString))
                If zonaObj.Eliminar Then
                    gv_zona.DataBind()
                    Msg1.Text = "La zona se eliminó correctamente"
                Else
                    Msg1.Text = "La zona NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="zona" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Zonas de la ciudad</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdDropDown">
                                    <table class="tableDDL">
                                        <tr>
                                            <td class="tdDDLEnun"><asp:Label ID="lbl_sector_enun" runat="server" Text="Sector de la ciudad:"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_sector" runat="server" AutoPostBack="true" DataSourceID="ods_sector_lista" DataTextField="nombre" DataValueField="id_sector"></asp:DropDownList>
                                                <%--[id_sector],[codigo],[nombre],[num_zonas]--%>
                                                <asp:ObjectDataSource ID="ods_sector_lista" runat="server" TypeName="terrasur.sector_zona" SelectMethod="Lista"></asp:ObjectDataSource>
                                            </td>
                                            <td class="tdDDLEspacio"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nueva zona" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_zona" runat="server" AutoGenerateColumns="false" DataSourceID="ods_zona_lista" DataKeyNames="id_zona">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_zona") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la zona?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Sector" DataField="nombre_sector" />
                                            <asp:BoundField HeaderText="Zona" DataField="nombre" />
                                            <asp:BoundField HeaderText="Nº de clientes" DataField="num_clientes" ItemStyle-CssClass="gvCell1" />
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_zona],[id_sector],[nombre],[num_clientes],[nombre_sector]--%>
                                    <asp:ObjectDataSource ID="ods_zona_lista" runat="server" TypeName="terrasur.zona" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_sector" ControlID="ddl_sector" PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_zona_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc1:zonaAbm ID="ZonaAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="zona" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="zona" />
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
