<%@ Page Language="VB" MasterPageFile="~/modulo/plan.master" Title="Planimetrías de sectores" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register TagPrefix="smap" Namespace="SharpMap.Web.UI.Ajax" Assembly="SharpMap.UI" %>
<%@ Import Namespace="System.Web.Services" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "view_plan") Then
                btn_archivos_shape.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planimetria", "view")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.DataBound
        ddl_urbanizacion.Items.Insert(0, New ListItem("Elija un sector", "0"))
        CargarFrame()
    End Sub
    
    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.SelectedIndexChanged
        CargarFrame()
    End Sub

    Protected Sub btn_update_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_update.Click
        CargarFrame()
    End Sub
    
    Protected Sub CargarFrame()
        If ddl_urbanizacion.Items.Count > 0 AndAlso ddl_urbanizacion.SelectedValue <> "0" Then
            Page.Title = "Planimetría del sector " + ddl_urbanizacion.SelectedItem.Text
            frame1.Attributes("src") = "planimetria.aspx?id=" & ddl_urbanizacion.SelectedValue
            panel_buscar.Visible = True
            rbl_por_codigo_lote.SelectedValue = "True"
            txt_codigo_numero.Text = ""
            txt_codigo_numero.Focus()
        Else
            Page.Title = "Planimetrías de sectores"
            frame1.Attributes("src") = ""
            panel_buscar.Visible = False
        End If
    End Sub
    
    Protected Sub btn_archivos_shape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_archivos_shape.Click
        Response.Redirect("~/recurso/inventario/planimetria/archivosShape.aspx")
    End Sub

    Protected Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim id_lote As Integer = lote.Buscar(Integer.Parse(ddl_urbanizacion.SelectedValue), Boolean.Parse(rbl_por_codigo_lote.SelectedValue), txt_codigo_numero.Text.Trim)
        lbl_no_encontrado.Visible = id_lote.Equals(0)
        If id_lote > 0 Then
            frame1.Attributes("src") = "planimetria.aspx?id=" & ddl_urbanizacion.SelectedValue & "&id_lote=" & id_lote.ToString
        End If
    End Sub
</script>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="planimetria" MostrarLink="true" />
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <table class="priTable">
        <tr>
            <td class="priTdTitle">Planimetrías de sectores</td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center" width="100%">
                    <tr>
                        <td class="tdDropDown">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td align="left" valign="bottom">
                                        <table class="tableDDL" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdDDLEnun">Sector:</td>
                                                <td class="tdDDLEspacio">
                                                    <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre" DataValueField="id_urbanizacion"></asp:DropDownList>
                                                    <%--[id_urbanizacion],[nombre]--%>
                                                    <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.archivo_shape" SelectMethod="ListaUrbanizacionConPlanimetria">
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td><asp:ImageButton ID="btn_update" runat="server" ImageUrl="~/images/update.gif" ToolTip="Volver a cargar planimetría"/></td>
                                                <td>&nbsp;&nbsp;&nbsp;</td>
                                                <td>
                                                    <asp:Panel ID="panel_buscar" runat="server" DefaultButton="btn_buscar">
                                                        <table cellpadding="0">
                                                            <tr>
                                                                <td><asp:Label ID="lbl_buscar" runat="server" Text="Buscar lote por" SkinID="lblEnun"></asp:Label></td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rbl_por_codigo_lote" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                                        <asp:ListItem Text="Código de lote" Value="True" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Nº contrato" Value="False"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_codigo_numero" runat="server" Width="50" MaxLength="10" ValidationGroup="planimetria"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfv_codigo_numero" runat="server" ControlToValidate="txt_codigo_numero" Display="Dynamic" ValidationGroup="planimetria" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td><asp:Button ID="btn_buscar" runat="server" Text="Buscar" CausesValidation="true" ValidationGroup="planimetria"/></td>
                                                                <td colspan="4"><asp:Label ID="lbl_no_encontrado" runat="server" Text="Lote no encontrado" SkinID="lblMsg" Visible="false"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right" valign="bottom">
                                        <asp:Button ID="btn_archivos_shape" runat="server" Text="Archivos shape" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <iframe id="frame1" scrolling="no" runat="server" width="100%" height="640">
                            </iframe>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table>
                                <tr>
                                    <td><div style="background-color:#F5760F; width:20px;">&nbsp;</div></td>
                                    <td>Disponible</td><td></td>

                                    <td><div style="background-color:#0066AE; width:20px;">&nbsp;</div></td>
                                    <td>Intercambio</td><td></td>

                                    <td><div style="background-color:#FF0000; width:20px;">&nbsp;</div></td>
                                    <td>Cancelado</td><td></td>

                                    <td><div style="background-color:#F6F90B; width:20px;">&nbsp;</div></td>
                                    <td>Nafibo</td><td></td>

                                    <td><div style="background-color:#F777B9; width:20px;">&nbsp;</div></td>
                                    <td>Vendido</td><td></td>

                                    <td><div style="background-color:#00FFFF; width:20px;">&nbsp;</div></td>
                                    <td>Preasignado</td><td></td>

                                    <td><div style="background-color:#A5A5A5; width:20px;">&nbsp;</div></td>
                                    <td>Bloqueado</td><td></td>

                                    <td><div style="background-color:#663300; width:20px;">&nbsp;</div></td>
                                    <td>Reservado</td><td></td>

                                    <td><div style="background-color:#000000; width:20px;">&nbsp;</div></td>
                                    <td>Inexistente</td><td></td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td><asp:Image ID="imgVenRetrasado" runat="server" ImageUrl="~/images/estadoLote/venRetrasado1.jpg" /></td>
                                    <td>Retrasado&nbsp;</td>
                                    <td><asp:Image ID="imgVenMora" runat="server" ImageUrl="~/images/estadoLote/venMora1.jpg" /></td>
                                    <td>En Mora&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

