<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Sectores de la ciudad" %>
<%@ Register Src="~/recurso/clienteZona/sectorZona/userControl/sectorZonaAbm.ascx" TagName="sectorZonaAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sectorZona", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sectorZona", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_sector_abm.Text = "Nuevo sector de la ciudad"
        SectorZonaAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If SectorZonaAbm1.VerificarInsertar Then
            If SectorZonaAbm1.Insertar Then
                gv_sector.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If SectorZonaAbm1.VerificarActualizar Then
            If SectorZonaAbm1.Actualizar Then
                gv_sector.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_sector_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_sector.DataBound
        gv_sector.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sectorZona", "update")
        gv_sector.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sectorZona", "delete")
        gv_sector.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "zona", "view")
    End Sub

    Protected Sub gv_sector_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_sector.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_zonas").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_sector_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_sector.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_sector_abm.Text = "Edición de datos de un sector de la ciudad"
                SectorZonaAbm1.CargarActualizar(Integer.Parse(gv_sector.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim sectorObj As New sector_zona(Integer.Parse(e.CommandArgument.ToString))
                If sectorObj.Eliminar Then
                    gv_sector.DataBind()
                    Msg1.Text = "El sector de la ciudad se eliminó correctamente"
                Else
                    Msg1.Text = "El sector de la ciudad NO se eliminó correctamente"
                End If
            Case "zonas"
                Session("id_sector") = Integer.Parse(gv_sector.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Response.Redirect("~/recurso/clienteZona/zona/Default.aspx")
        End Select
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="sectorZona" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Sectores de la ciudad</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo sector de la ciudad" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_sector" runat="server" AutoGenerateColumns="false" DataSourceID="ods_sector_lista" DataKeyNames="id_sector">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_sector") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el sector?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="zonas" Text="Zonas" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Sector" DataField="nombre" />
                                            <asp:BoundField HeaderText="Nº de zonas" DataField="num_zonas" ItemStyle-CssClass="gvCell1" />
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_sector],[codigo],[nombre],[num_zonas]--%>
                                    <asp:ObjectDataSource ID="ods_sector_lista" runat="server" TypeName="terrasur.sector_zona" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_sector_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc1:sectorZonaAbm ID="SectorZonaAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="sector" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="sector" />
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


