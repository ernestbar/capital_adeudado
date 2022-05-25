<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Archivos Shape de Planimetrías" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register src="~/recurso/inventario/planimetria/userControl/archivoShapeAbm.ascx" tagname="archivoShapeAbm" tagprefix="uc1" %>
<%@ Register Src="~/recurso/inventario/planimetria/userControl/revisionShape.ascx" TagName="revisionShape" TagPrefix="uc3" %>

<script runat="server">
    Protected Property insertar() As Boolean
        Get
            Return Boolean.Parse(lbl_insertar.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_insertar.Text = value.ToString
        End Set
    End Property
    Protected Property editar() As Boolean
        Get
            Return Boolean.Parse(lbl_editar.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_editar.Text = value.ToString
        End Set
    End Property
    Protected Property eliminar() As Boolean
        Get
            Return Boolean.Parse(lbl_eliminar.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_eliminar.Text = value.ToString
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "view") Then
                insertar = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "insert")
                editar = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "update")
                eliminar = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "delete")
                btn_revisar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "revisar")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub gv0_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv0.DataBound
        If insertar = True Or editar = True Or eliminar = True Then
            'gv0.Columns(1).Visible = True
            gv0.Columns(0).Visible = True
        Else
            'gv0.Columns(1).Visible = False
            gv0.Columns(0).Visible = False
        End If
        
    End Sub
    
    Protected Sub gv0_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv0.RowCommand
        Select Case e.CommandName
            'Case "ver"
            '    Session("id_urbanizacion") = Integer.Parse(gv0.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
            '    WinPopUp1.Show()
            Case "archivos"
                archivoShapeAbm1.Reset(Integer.Parse(gv0.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString), insertar, editar, eliminar)
                MultiView1.ActiveViewIndex = 1
        End Select
    End Sub

    Protected Sub btn_revisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_revisar.Click
        MultiView1.ActiveViewIndex = 2
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        gv0.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_volver_revision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver_revision.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        ddl_localizacion.Items.Add(New ListItem("Todos", "0"))
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="planimetria" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_insertar" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_editar" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_eliminar" runat="server" Text="false" Visible="false"></asp:Label>
<%--<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/planimetria/archivosShapeDetalle.aspx">[WinPopUp1]</asp:WinPopUp>--%>
<table class="priTable">
    <tr><td class="priTdTitle">Archivos Shape de Planimetrías</td></tr>
    <tr>
        <td class="priTdContenido">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table class="tableContenido" align="center">
                        <tr><td align="right"><asp:Button ID="btn_revisar" runat="server" Text="Verificación de consistencia" /></td></tr>
                        <tr>
                            <td class="tdDropDown">
                                <table class="tableDDL">
                                    <tr>
                                        <td class="tdDDLEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
                                        <td class="tdDDLEspacio">
                                            <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion"></asp:DropDownList>
                                            <%--[id_localizacion],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdGrid" >
                                <asp:GridView ID="gv0" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_urbanizacion" DataKeyNames="id_urbanizacion">
                                    <Columns>
                                        <%--<asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />--%>
                                        <asp:ButtonField CommandName="archivos" Text="Archivos" ControlStyle-CssClass="gvButton" />
                                        <asp:BoundField HeaderText="Urbanización" DataField="nombre" />
                                        <asp:BoundField HeaderText="Nº lotes" DataField="num_lotes" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Nº Shapes" DataField="num_archivos_shape" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Fecha Modif." DataField="fecha" />
                                        <asp:BoundField HeaderText="Usuario Modif." DataField="nombre_usuario" />
                                    </Columns>
                                </asp:GridView>
                                <%--[id_urbanizacion],[nombre],[num_lotes],[num_archivos_shape],[fecha],[nombre_usuario]--%>
                                <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.archivo_shape" SelectMethod="ListaUrbanizacion">
                                    <SelectParameters>
                                       <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                   </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table class="tableContenido" align="center">
                        <tr><td align="right"><asp:Button ID="btn_volver" runat="server" Text="Volver" SkinID="btnVolver"/></td></tr>
                        <tr>
                            <td>
                                <uc1:archivoShapeAbm ID="archivoShapeAbm1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table class="tableContenido" align="center">
                        <tr><td align="right"><asp:Button ID="btn_volver_revision" runat="server" Text="Volver" SkinID="btnVolver"/></td></tr>
                        <tr>
                            <td>
                                <uc3:revisionshape id="RevisionShape1" runat="server"></uc3:revisionshape>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
</table>

</asp:Content>

