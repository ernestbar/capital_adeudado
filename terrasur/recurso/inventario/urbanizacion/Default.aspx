<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Sectores" %>
<%@ Register Src="~/recurso/inventario/urbanizacion/userControl/urbanizacionAbm.ascx" TagName="urbanizacionAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "urbanizacion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "urbanizacion", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        'btn_nuevo.Enabled = ddl_localizacion.Items.Count.Equals(0).Equals(False)
        'ddl_localizacion.Items.Insert(0, New ListItem("TODOS", "0"))
        If ddl_localizacion.Items.Count > 0 Then
            If Session("id_localizacion") IsNot Nothing Then
                ddl_localizacion.SelectedValue = Session("id_localizacion").ToString
                Session.Remove("id_localizacion")
            End If
        End If
    End Sub
    
    

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_urbanizacion_abm.Text = "Nuevo sector"
        UrbanizacionAbm1.id_localizacion = ddl_localizacion.SelectedValue
        UrbanizacionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If UrbanizacionAbm1.VerificarInsertar Then
            If UrbanizacionAbm1.Insertar Then
                UrbanizacionAbm1.CargarInsertar()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If UrbanizacionAbm1.VerificarActualizar Then
            If UrbanizacionAbm1.Actualizar Then
                UrbanizacionAbm1.CargarActualizar(UrbanizacionAbm1.id_urbanizacion)
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        gv_urbanizacion.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_urbanizacion.DataBound
        gv_urbanizacion.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "urbanizacion", "view")
        gv_urbanizacion.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "urbanizacion", "update")
        gv_urbanizacion.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "urbanizacion", "delete")
    End Sub

    Protected Sub gv_urbanizacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_urbanizacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_manzano").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_urbanizacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_urbanizacion.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_urbanizacion") = Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_urbanizacion_abm.Text = "Edición de datos de un sector"
                UrbanizacionAbm1.CargarActualizar(Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim urbanizacionObj As New urbanizacion(Integer.Parse(e.CommandArgument.ToString))
                If urbanizacionObj.Eliminar() Then
                    gv_urbanizacion.DataBind()
                    Msg1.Text = "El sector se eliminó correctamente"
                Else
                    Msg1.Text = "El sector NO se eliminó correctamente"
                End If
            Case "manzano"
                Session("id_localizacion") = ddl_localizacion.SelectedValue
                Session("id_urbanizacion") = Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Response.Redirect("~/recurso/inventario/manzano/Default.aspx")
        End Select
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="urbanizacion" MostrarLink="true" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/urbanizacion/urbanizacionDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Sectores</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdDropDown">
                                    <table class="tableDDL">
                                        <tr>
                                            <td class="tdDDLEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion"></asp:DropDownList>
                                                <%--[id_localizacion],[nombre]--%>
                                                <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                            </td>
                                            <td class="tdDDLEspacio"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo sector" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_urbanizacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_urbanizacion_lista" DataKeyNames="id_urbanizacion">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_urbanizacion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el sector?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="manzano" Text="Manzanos" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Sector" DataField="nombre_completo" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />
                                            <asp:BoundField HeaderText="No. de manzanos" DataField="num_manzano" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="No. de lotes" DataField="num_lote" ItemStyle-CssClass="gvCell1"/> 
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%-- [id_urbanizacion],[codigo],[nombre_corto],[nombre]
                                         [mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
                                    <asp:ObjectDataSource ID="ods_urbanizacion_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                        <SelectParameters>
                                           <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                       </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_urbanizacion_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:urbanizacionAbm ID="UrbanizacionAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="urbanizacion" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="urbanizacion" />
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

