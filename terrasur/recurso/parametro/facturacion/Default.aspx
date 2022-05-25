<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Parámetros de facturación" %>
<%@ Register Src="~/recurso/parametro/facturacion/userControl/facturacionAbm.ascx" TagName="facturacionAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "facturacion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "facturacion", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_parametrofacturacion_abm.Text = "Nuevos parámetros de facturación"
        FacturacionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If FacturacionAbm1.Insertar Then
            gv_parametrofacturacion.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If FacturacionAbm1.Actualizar Then
            gv_parametrofacturacion.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_parametrofacturacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_parametrofacturacion.DataBound
        gv_parametrofacturacion.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "facturacion", "view")
        gv_parametrofacturacion.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "facturacion", "update")
        gv_parametrofacturacion.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "facturacion", "delete")
    End Sub

    Protected Sub gv_parametrofacturacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_parametrofacturacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_facturas").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_parametrofacturacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_parametrofacturacion.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_parametrofacturacion") = Integer.Parse(gv_parametrofacturacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_parametrofacturacion_abm.Text = "Edición de datos de parámetros de facturación"
                FacturacionAbm1.CargarActualizar(Integer.Parse(gv_parametrofacturacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim parametrofacturacionObj As New parametro_facturacion(Integer.Parse(e.CommandArgument.ToString))
                If parametrofacturacionObj.Eliminar(Profile.id_usuario) Then
                    gv_parametrofacturacion.DataBind()
                    Msg1.Text = "Los parámetros de facturación se eliminaron correctamente"
                Else
                    Msg1.Text = "Los parámetros de facturación NO se eliminaron correctamente"
                End If
        End Select
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="facturacion" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/parametro/facturacion/facturacionDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Parámetros de facturación</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevos parámetros de facturación" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_parametrofacturacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_parametrofacturacion_lista" DataKeyNames="id_parametrofacturacion">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_parametrofacturacion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el parámetro de facturación?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Sucursal" DataField="sucursal" />
                                            <asp:BoundField HeaderText="Razón Social" DataField="razon_social" />
                                            <asp:BoundField HeaderText="NIT" DataField="nit" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Nº autorización" DataField="num_autorizacion" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Fecha Límite" DataField="fecha_limite" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Nº sig. fact." DataField="num_siguiente_factura" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Negocios" DataField="negocios"  />
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_parametrofacturacion],[sucursal],[razon_social],[nit],[fecha_limite],[num_autorizacion],[num_siguiente_factura],[num_facturas],[negocios]--%>
                                    <asp:ObjectDataSource ID="ods_parametrofacturacion_lista" runat="server" TypeName="terrasur.parametro_facturacion" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_parametrofacturacion_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc1:facturacionAbm ID="FacturacionAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="parametrofacturacion" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="parametrofacturacion" />
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

