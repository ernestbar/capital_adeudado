<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Manzanos" %>
<%@ Register Src="~/recurso/inventario/manzano/userControl/manzanoAbm.ascx" TagName="manzanoAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddl_urbanizacion.Items.Count > 0 Then
            If Session("id_urbanizacion") IsNot Nothing Then
                ddl_urbanizacion.SelectedValue = Session("id_urbanizacion").ToString
                Session.Remove("id_urbanizacion")
            End If
            btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "insert")
        ElseIf ddl_urbanizacion.Items.Count = 0 Then
            btn_nuevo.Visible = False
        End If
        
    End Sub
    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        If ddl_localizacion.Items.Count > 0 Then
            If Session("id_localizacion") IsNot Nothing Then
                ddl_localizacion.SelectedValue = Session("id_localizacion").ToString
                Session.Remove("id_localizacion")
            End If
        End If
    End Sub
    
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_urbanizacion.DataBind()
    End Sub
    

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_manzano_abm.Text = "Nuevo manzano"
        ManzanoAbm1.id_localizacion = ddl_localizacion.SelectedValue
        ManzanoAbm1.id_urbanizacion = ddl_urbanizacion.SelectedValue 
        ManzanoAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If ManzanoAbm1.VerificarInsertar Then
            If ManzanoAbm1.Insertar Then
                ManzanoAbm1.CargarInsertar()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If ManzanoAbm1.VerificarActualizar Then
            If ManzanoAbm1.Actualizar Then
                ManzanoAbm1.CargarActualizar(ManzanoAbm1.id_manzano)
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        gv_manzano.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_manzano.DataBound
        gv_manzano.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "view")
        gv_manzano.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "update")
        gv_manzano.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "manzano", "delete")
    End Sub

    Protected Sub gv_manzano_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_manzano.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_lote").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_manzano_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_manzano.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_manzano") = Integer.Parse(gv_manzano.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_manzano_abm.Text = "Edición de datos de un manzano"
                ManzanoAbm1.CargarActualizar(Integer.Parse(gv_manzano.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim manzanoObj As New manzano(Integer.Parse(e.CommandArgument.ToString))
                If manzanoObj.Eliminar() Then
                    gv_manzano.DataBind()
                    Msg1.Text = "El manzano se eliminó correctamente"
                Else
                    Msg1.Text = "El manzano NO se eliminó correctamente"
                End If
            Case "lote"
                Session("id_localizacion") = ddl_localizacion.SelectedValue
                Session("id_urbanizacion") = ddl_urbanizacion.SelectedValue
                Session("id_manzano") = Integer.Parse(gv_manzano.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Response.Redirect("~/recurso/inventario/lote/Default.aspx")
        End Select
    End Sub

   
  
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="manzano" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/manzano/manzanoDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Manzanos</td></tr>
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
                                                <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound"></asp:DropDownList>
                                                <%--[id_urbanizacion],[nombre]--%>
                                                <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion"
                                                    SelectMethod="Lista">
                                                    <SelectParameters>
                                                        <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion"
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
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo manzano" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid" >
                                    <asp:GridView AllowPaging="true" PageSize="20" ID="gv_manzano" runat="server" AutoGenerateColumns="false" DataSourceID="ods_manzano_lista" DataKeyNames="id_manzano">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_manzano") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el manzano?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="lote" Text="Lotes" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Manzano" DataField="codigo" />
                                           <asp:BoundField HeaderText="No. de lotes" DataField="num_lote" ItemStyle-CssClass="gvCell1"/> 
                                        </Columns>
                                    </asp:GridView>
                                    <%-- [id_manzanos],[codigo],[num_lote]--%>
                                    <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                                        <SelectParameters>
                                           <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                       </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_manzano_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:manzanoAbm ID="ManzanoAbm1" runat="server" />
                           </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="manzano" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="manzano" />
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

