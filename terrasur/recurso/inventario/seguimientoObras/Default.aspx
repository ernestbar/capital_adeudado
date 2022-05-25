<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Seguimiento de obras" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/inventario/seguimientoObras/userControl/urbanizacionPrioridadAbm.ascx" tagname="urbanizacionPrioridadAbm" tagprefix="uc2" %>
<%@ Register src="~/recurso/inventario/seguimientoObras/userControl/estadoMaestroObservacion.ascx" tagname="estadoMaestroObservacion" tagprefix="uc3" %>
<%@ Register src="~/recurso/inventario/seguimientoObras/userControl/obraDetalleAbm.ascx" tagname="obraDetalleAbm" tagprefix="uc4" %>

<script runat="server">
    Protected Property permiso_prioridad() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_prioridad.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_prioridad.Text = value
        End Set
    End Property
    Protected Property permiso_observacion() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_observacion.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_observacion.Text = value
        End Set
    End Property
    Protected Property permiso_obras() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_obras.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_obras.Text = value
        End Set
    End Property

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "view") Then
                permiso_prioridad = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "prioridad")
                permiso_observacion = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "observacion")
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_agregar") Or _
                    permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_suspender") Or _
                    permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_avance") Or _
                    permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_obs") Or _
                    permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_fechaPlanificacion") Then
                    permiso_obras = True
                Else
                    permiso_obras = False
                End If
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        If ddl_localizacion.Items.Count > 0 Then
            'ddl_localizacion.Items.Insert(0, New ListItem("TODOS", "0"))
        End If
    End Sub

    
    
    Protected Sub gv_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_urbanizacion.DataBound
        gv_urbanizacion.Columns(1).Visible = permiso_prioridad
        gv_urbanizacion.Columns(2).Visible = permiso_observacion
        gv_urbanizacion.Columns(3).Visible = permiso_obras
    End Sub

    Protected Sub gv_urbanizacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_urbanizacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            'CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_manzano").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_urbanizacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_urbanizacion.RowCommand
        Select Case e.CommandName
            Case "ver"
                btn_volver.Visible = True
                Session("id_urbanizacion") = Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "prioridad"
                btn_volver.Visible = True
                MultiView1.ActiveViewIndex = 1
                Dim id_urb As Integer = Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                urbanizacionPrioridadAbm1.CargarInsertar(id_urb)
            Case "observacion"
                btn_volver.Visible = True
                MultiView1.ActiveViewIndex = 2
                Dim id_urb As Integer = Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                estadoMaestroObservacion1.CargarInsertar(id_urb)
            Case "obra"
                btn_volver.Visible = True
                MultiView1.ActiveViewIndex = 3
                Dim id_urb As Integer = Integer.Parse(gv_urbanizacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                obraDetalleAbm1.Cargar(id_urb)
        End Select
    End Sub

    Protected Sub btn_volverPrioridad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        gv_urbanizacion.DataBind()
        btn_volver.Visible = False
        MultiView1.ActiveViewIndex = 0
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="seguimientoObras" MostrarLink="true" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_permiso_prioridad" runat="server" Visible="false" Text="False"></asp:Label>
<asp:Label ID="lbl_permiso_observacion" runat="server" Visible="false" Text="False"></asp:Label>
<asp:Label ID="lbl_permiso_obras" runat="server" Visible="false" Text="False"></asp:Label>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/seguimientoObras/obrasDetalle.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400" Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                <table cellpadding="0" cellspacing="0" width="1000" align="center">
                    <tr>
                        <td align="left" style="width:120px"></td>
                        <td align="center">Seguimiento de Obras</td>
                        <td align="right" style="width:120px"><asp:Button ID="btn_volver" runat="server" Text="Volver al listado" Visible="false" /></td>
                    </tr>
                </table>
            </td>
        </tr>
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
                                                <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion">
                                                </asp:DropDownList>
                                                <%--[id_localizacion],[nombre]--%>
                                                <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista">
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_urbanizacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_obraMaestro_lista" DataKeyNames="id_urbanizacion">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="prioridad" Text="Prioridad /Planificación" ButtonType="Image" ImageUrl="~/images/gv/prioridad.gif" />
                                            <asp:ButtonField CommandName="observacion" Text="Observaciones"  ButtonType="Image" ImageUrl="~/images/gv/obs.gif" />
                                            <asp:ButtonField CommandName="obra" Text="Obras" ButtonType="Image" ImageUrl="~/images/gv/obras.gif" />
                                            
                                            <asp:BoundField HeaderText="Localización" DataField="localizacion" />
                                            <asp:BoundField HeaderText="Urbanización" DataField="urbanizacion" />
                                            <asp:BoundField HeaderText="Estado" DataField="estado" />
                                            <asp:BoundField HeaderText="Prioridad" DataField="prioridad" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="F.Planificada" DataField="fecha_planificada" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Avance" DataField="avance" ItemStyle-CssClass="gvCell1" />
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_urbanizacion],[localizacion],[urbanizacion],[registro_usuario],
                                        [registro_fecha],[estado],[prioridad],[fecha_planificada],[avance]--%>
                                    <asp:ObjectDataSource ID="ods_obraMaestro_lista" runat="server" TypeName="terrasur.so.so_obraMaestro" SelectMethod="Lista">
                                        <SelectParameters>
                                           <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                       </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <uc2:urbanizacionPrioridadAbm ID="urbanizacionPrioridadAbm1" runat="server" />
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <uc3:estadoMaestroObservacion ID="estadoMaestroObservacion1" runat="server" />
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <uc4:obraDetalleAbm ID="obraDetalleAbm1" runat="server" />
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

