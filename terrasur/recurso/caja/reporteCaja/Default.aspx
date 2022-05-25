<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            btn_nafibo_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCaja", "ingresos_nafibo_detalle")
            btn_nafibo_urbanizacion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCaja", "ingresos_nafibo_total")
        End If
    End Sub
    
    Protected Sub btn_ingresos_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresos_detalle.Click
        Response.Redirect("~/recurso/caja/reporteCaja/reporteIngresosDetalle.aspx")
    End Sub
    
    Protected Sub btn_nafibo_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nafibo_detalle.Click
        Response.Redirect("~/recurso/caja/reporteCaja/reporteIngresosNafiboDetalle.aspx")
    End Sub

    Protected Sub btn_nafibo_urbanizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nafibo_urbanizacion.Click
        Response.Redirect("~/recurso/caja/reporteCaja/reporteIngresosNafiboTotalesUrbanizacion.aspx")
    End Sub

    Protected Sub btn_totales_urbanizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_totales_urbanizacion.Click
        Response.Redirect("~/recurso/caja/reporteCaja/reporteIngresosTotalesUrbanizacion.aspx")
    End Sub
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCaja" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reportes de caja</td></tr>
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
                                    <asp:Button ID="btn_ingresos_detalle" runat="server" Text="Reporte de ingresos en detalle"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_totales_urbanizacion" runat="server" Text="Reporte de ingresos - Totales por sector"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nafibo_detalle" runat="server" Text="Reporte de ingresos NAFIBO en detalle"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nafibo_urbanizacion" runat="server" Text="Reporte de ingresos NAFIBO - Totales por sector"/>
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

