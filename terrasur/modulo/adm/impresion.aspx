<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Lotes" %>
<%@ Register Src="~/recurso/inventario/lote/userControl/cambioNegocioLote.ascx" TagName="cambioNegocioLote"
    TagPrefix="uc4" %>
<%@ Register Src="~/recurso/inventario/lote/userControl/cambioEstadoLote.ascx" TagName="cambioEstadoLote" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/inventario/lote/userControl/loteAbm.ascx" TagName="loteAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            'If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "view") Then
            '    If ddl_manzano.Items.Count > 0 Then
            '        btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "insert")
            '    Else
            '        btn_nuevo.Visible = False
            '    End If
            'Else
            '    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            'End If
            'If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "precio_menor_costo") Then
            '    LoteAbm1.Enabled_cmv_precio = False
            'Else
            '    LoteAbm1.Enabled_cmv_precio = True
            'End If
        End If
    End Sub
    
    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddl_urbanizacion.Items.Count > 0 Then
            If Session("id_urbanizacion") IsNot Nothing Then
                ddl_urbanizacion.SelectedValue = Session("id_urbanizacion").ToString
                Session.Remove("id_urbanizacion")
            End If
        End If
    End Sub
    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        ddl_localizacion.Items.Insert(0, New ListItem("Todos", "0"))
        If ddl_localizacion.Items.Count > 0 Then
            If Session("id_localizacion") IsNot Nothing Then
                ddl_localizacion.SelectedValue = Session("id_localizacion").ToString
                Session.Remove("id_localizacion")
            End If
        End If
    End Sub
    
    Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_manzano.DataBound
        If ddl_manzano.Items.Count > 0 Then
            If Session("id_manzano") IsNot Nothing Then
                ddl_manzano.SelectedValue = Session("id_manzano").ToString
                Session.Remove("id_manzano")
            End If
            btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "insert")
        Else
            btn_nuevo.Visible = False
            Session.Remove("id_manzano")
        End If
    End Sub
    
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_urbanizacion.DataBind()
        ddl_manzano.DataBind()
    End Sub
    
    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_manzano.DataBind()
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_lote_abm.Text = "Nuevo lote"
        LoteAbm1.id_manzano = ddl_manzano.SelectedValue
        LoteAbm1.id_localizacion = ddl_localizacion.SelectedValue
        LoteAbm1.id_urbanizacion = ddl_urbanizacion.SelectedValue
        LoteAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If LoteAbm1.VerificarInsertar Then
            If LoteAbm1.Insertar Then
                LoteAbm1.CargarInsertar()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If LoteAbm1.VerificarActualizar Then
            If LoteAbm1.Actualizar Then
                LoteAbm1.CargarActualizar(LoteAbm1.id_lote)
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        gv_lote.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    Protected Sub btn_actualizar_estado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar_estado.Click
        If CambioEstadoLote1.Actualizar Then
            CambioEstadoLote1.CargarActualizar(cambioEstadoLote1.id_lote)
        End If
    End Sub
    
    Protected Sub btn_cancelar_estado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar_estado.Click
        gv_lote.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_actualizar_negocio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar_negocio.Click
        If CambioNegocioLote1.Actualizar Then
            CambioNegocioLote1.id_lote = CambioNegocioLote1.id_lote
            CambioNegocioLote1.CargarActualizar()
        End If
    End Sub
    
    Protected Sub btn_cancelar_negocio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar_negocio.Click
        gv_lote.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub

    
    Protected Sub gv_lote_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_lote.DataBound
        'gv_lote.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "view")
        'gv_lote.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "update")
        'gv_lote.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "delete")
        'gv_lote.Columns(3).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "cambiar_estado")
        'gv_lote.Columns(4).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "cambiar_negocio")
    End Sub

    Protected Sub gv_lote_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_lote.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            CType(e.Row.FindControl("r_contrato"), Repeater).DataSource = estado_lote.ListaPorLote(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_lote")))
            CType(e.Row.FindControl("r_contrato"), Repeater).DataBind()
            
            'CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_contratos").ToString).Equals(0)
            'e.Row.Cells(3).Enabled = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_cambiar").ToString())
        End If
    End Sub

    Protected Sub gv_lote_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_lote.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_lote") = Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_lote_abm.Text = "Edición de datos de un lote"
                LoteAbm1.CargarActualizar(Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim loteObj As New lote(Integer.Parse(e.CommandArgument.ToString))
                If loteObj.num_contratos = 0 Then
                    Dim neg_lote As New negocio_lote(0, Integer.Parse(e.CommandArgument.ToString))
                    If neg_lote.Eliminar() Then
                        Dim est_lote As New estado_lote(0, Integer.Parse(e.CommandArgument.ToString), 0, 0, "")
                        If est_lote.Eliminar() Then
                            If loteObj.Eliminar(Profile.id_usuario) Then
                                gv_lote.DataBind()
                                Msg1.Text = "El lote se eliminó correctamente"
                            Else
                                Msg1.Text = "El lote NO se eliminó correctamente"
                            End If
                        Else
                            Msg1.Text = "El lote NO se eliminó correctamente"
                        End If
                    Else
                        Msg1.Text = "El lote NO se eliminó correctamente"
                    End If
                End If
            Case "cambiar_estado"
                panel_cambio_estado.DefaultButton = "btn_actualizar_estado"
                lbl_cambio_estado.Text = "Cambio de estado del lote"
                CambioEstadoLote1.CargarActualizar(Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_actualizar_estado.Visible = True
                MultiView1.ActiveViewIndex = 2
            Case "cambiar_negocio"
                panel_cambio_negocio.DefaultButton = "btn_actualizar_negocio"
                lbl_cambio_negocio.Text = "Cambio de negocio del lote"
                CambioNegocioLote1.id_lote = Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                If CambioNegocioLote1.CargarActualizar() = True Then
                    btn_actualizar_negocio.Visible = True
                    MultiView1.ActiveViewIndex = 3
                Else
                    MultiView1.ActiveViewIndex = 0
                End If
                
        End Select
    End Sub


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="lote" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/lote/loteDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>

    <asp:WinPopUp ID="WinPopUp2" runat="server" NavigateUrl="~/recurso/inventario/lote/loteDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp2]</asp:WinPopUp>


<table class="priTable">
        <tr><td class="priTdTitle">Lotes</td></tr>
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
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo Lote" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid" >
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_lote" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lote_lista" DataKeyNames="id_lote">
                                        <Columns>
                                            <%--<asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_lote") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el lote?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="cambiar_estado" Text="Cambiar estado" ControlStyle-CssClass="gvButton" />
                                            <asp:ButtonField CommandName="cambiar_negocio" Text="Cambiar negocio" ControlStyle-CssClass="gvButton" />--%>
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Sup. M2" DataField="superficie_m2" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Costo $/M2" DataField="costo_m2_sus" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Precio $/M2" DataField="precio_m2_sus" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Estado" DataField="nombre_estado" />
                                           <asp:BoundField HeaderText="Negocio" DataField="nombre_negocio"/> 
                                           <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Repeater ID="r_contrato" runat="server">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hl_EstadoCuenta" runat="server" Text='<%# Eval("numero_contrato") %>' Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "EstadoCuenta", Eval("id_contrato")) %>'></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ItemTemplate>
                                           </asp:TemplateField>
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%-- [id_lote],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[nombre_estado],[nombre_lote]--%>
                                    <asp:ObjectDataSource ID="ods_lote_lista" runat="server" TypeName="terrasur.lote" SelectMethod="Lista">
                                        <SelectParameters>
                                           <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
                                       </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_lote_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:loteAbm ID="LoteAbm1" runat="server" />
                            
                           </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="lote" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="lote" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View id="View3" runat="server">
                        <asp:Panel ID="panel_cambio_estado" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_cambio_estado" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc3:cambioEstadoLote ID="CambioEstadoLote1" runat="server" />
                           </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_actualizar_estado" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="lote" />
                                    <asp:Button ID="btn_cancelar_estado" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View id="View4" runat="server">
                        <asp:Panel ID="panel_cambio_negocio" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_cambio_negocio" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc4:cambioNegocioLote ID="CambioNegocioLote1" runat="server" />
                           </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_actualizar_negocio" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="lote" />
                                    <asp:Button ID="btn_cancelar_negocio" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
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

