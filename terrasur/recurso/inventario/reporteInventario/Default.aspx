<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            btn_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", "detalle")
            btn_resumen.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", "resumen")
        End If
    End Sub
    
    Protected Sub btn_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/inventario/reporteInventario/reporteLoteDetalle.aspx")
    End Sub

    Protected Sub btn_resumen_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/inventario/reporteInventario/reporteLoteResumen.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteInventario" MostrarLink="true"  />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reportes de inventario</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButtonVolver">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDropDown">
                                    <table class="tableDDL">
                                        <tr>
                                            <td class="tdDDLEnun"></td>
                                            <td><%--[Aquí viene el DropDownList]--%></td>
                                            <td class="tdDDLEspacio"></td><%--Es para insertar un espacio entre opciones (si es necesario)--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_detalle" runat="server" Text="Inventario de lotes detalle" OnClick="btn_detalle_Click" />
                                    <asp:Button ID="btn_resumen" runat="server" Text="Inventario de lotes resumen" OnClick="btn_resumen_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdBusqueda">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

