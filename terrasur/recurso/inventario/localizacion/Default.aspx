<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Localizaciones" %>
<%@ Register Src="~/recurso/inventario/localizacion/userControl/localizacionAbm.ascx" TagName="localizacionAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "localizacion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "localizacion", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_localizacion_abm.Text = "Nueva localización"
        LocalizacionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If LocalizacionAbm1.VerificarInsertar Then
            If LocalizacionAbm1.Insertar Then
                LocalizacionAbm1.CargarInsertar()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If LocalizacionAbm1.VerificarActualizar Then
            If LocalizacionAbm1.Actualizar Then
                LocalizacionAbm1.CargarActualizar(LocalizacionAbm1.id_localizacion)
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        gv_localizacion.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_localizacion.DataBound
        gv_localizacion.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "localizacion", "view")
        gv_localizacion.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "localizacion", "update")
        gv_localizacion.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "localizacion", "delete")
    End Sub

    Protected Sub gv_localizacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_localizacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_urbanizacion").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_localizacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_localizacion.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_localizacion") = Integer.Parse(gv_localizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_localizacion_abm.Text = "Edición de datos de una localización"
                LocalizacionAbm1.CargarActualizar(Integer.Parse(gv_localizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim localizacionObj As New localizacion(Integer.Parse(e.CommandArgument.ToString))
                If localizacionObj.Eliminar() Then
                    gv_localizacion.DataBind()
                    Msg1.Text = "La localizacion se eliminó correctamente"
                Else
                    Msg1.Text = "La localizacion NO se eliminó correctamente"
                End If
            Case "urbanizacion"
                Session("id_localizacion") = Integer.Parse(gv_localizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Response.Redirect("~/recurso/inventario/urbanizacion/Default.aspx")
        End Select
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="localizacion" MostrarLink="true" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/localizacion/localizacionDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Localizaciones</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nueva localización" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_localizacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_localizacion_lista" DataKeyNames="id_localizacion">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_localizacion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la localización?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="urbanizacion" Text="Sector" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Localizacion" DataField="nombre" />
                                            <asp:BoundField HeaderText="No. de Sec." DataField="num_urbanizacion_activa" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="No. de lotes" DataField="num_lote" ItemStyle-CssClass="gvCell1"/> 
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%-- [id_localizacion],[codigo],[nombre],[imagen],[num_urbanizacion],[num_lote],[num_urbanizacion_activa]
--%>
                                    <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_localizacion_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:localizacionAbm ID="LocalizacionAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="localizacion" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="localizacion" />
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

