<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Listado de lotes y contratos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not Page.IsPostBack Then
                If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", "listadoLoteContrato") Then
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
        End If
    End Sub
    
    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'If ddl_urbanizacion.Items.Count > 0 Then
        '    If Session("id_urbanizacion") IsNot Nothing Then
        '        ddl_urbanizacion.SelectedValue = Session("id_urbanizacion").ToString
        '        Session.Remove("id_urbanizacion")
        '    End If
        'End If
    End Sub
    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        ddl_localizacion.Items.Insert(0, New ListItem("Todos", "0"))
        'If ddl_localizacion.Items.Count > 0 Then
        '    If Session("id_localizacion") IsNot Nothing Then
        '        ddl_localizacion.SelectedValue = Session("id_localizacion").ToString
        '        Session.Remove("id_localizacion")
        '    End If
        'End If
    End Sub
    
    Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_manzano.DataBound
        'If ddl_manzano.Items.Count > 0 Then
        '    If Session("id_manzano") IsNot Nothing Then
        '        ddl_manzano.SelectedValue = Session("id_manzano").ToString
        '        Session.Remove("id_manzano")
        '    End If
        'Else
        '    Session.Remove("id_manzano")
        'End If
    End Sub
    
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_urbanizacion.DataBind()
        ddl_manzano.DataBind()
    End Sub
    
    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_manzano.DataBind()
    End Sub


    Protected Sub gv_lote_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_lote.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            CType(e.Row.FindControl("r_contrato"), Repeater).DataSource = lote.ListaContratos(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_lote")))
            CType(e.Row.FindControl("r_contrato"), Repeater).DataBind()
        End If
    End Sub

    Protected Sub gv_lote_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_lote.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_lote") = Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
        End Select
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteInventario"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/lote/loteDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Listado de lotes y contratos</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdDropDown">
                            <table class="tableDDL">
                                <tr>
                                    <td class="tdDDLEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
                                    <td class="tdDDLEspacio">
                                        <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion" OnSelectedIndexChanged="ddl_localizacion_SelectedIndexChanged"></asp:DropDownList>
                                        <%--[id_localizacion],[nombre]--%>
                                        <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                    </td>
                                    <td class="tdDDLEnun"><asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
                                    <td class="tdDDLEspacio">
                                        <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound" OnSelectedIndexChanged="ddl_urbanizacion_SelectedIndexChanged"></asp:DropDownList>
                                        <%--[id_urbanizacion],[nombre_completo]--%>
                                        <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista_para_ddl">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                   <td class="tdDDLEnun"><asp:Label ID="lbl_lote_enun" runat="server" Text="Manzano:"></asp:Label></td>
                                   <td class="tdDDLEspacio">
                                        <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano" OnDataBound="ddl_manzano_DataBound"></asp:DropDownList>
                                        <%--[id_manzano],[codigo]--%>
                                        <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano"
                                            SelectMethod="Lista">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion"
                                                    PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="gv_lote" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lote_lista" DataKeyNames="id_lote">
                                <Columns>
                                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Sup. M2" DataField="superficie_m2" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Costo $/M2" DataField="costo_m2_sus" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Precio $/M2" DataField="precio_m2_sus" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Constr." DataField="con_construccion" />
                                    <asp:BoundField HeaderText="Estado" DataField="nombre_estado" />
                                    <asp:BoundField DataField="motivo_bloqueo" />
                                   <asp:BoundField HeaderText="Negocio" DataField="nombre_negocio"/> 
                                   <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Repeater ID="r_contrato" runat="server">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hl_EstadoCuenta" runat="server" Text='<%# Eval("numero_contrato") %>' ToolTip='<%# Eval("descrip") %>' Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "EstadoCuenta", Eval("id_contrato")) %>'></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                   </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <%-- [id_lote],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[nombre_estado],[nombre_lote]--%>
                            <asp:ObjectDataSource ID="ods_lote_lista" runat="server" TypeName="terrasur.lote" SelectMethod="Lista">
                                <SelectParameters>
                                   <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
                               </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

