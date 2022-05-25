<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            'btn_datos_contrato.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "")
        End If
    End Sub

    Protected Sub btn_datos_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_datos_contrato.Click
        Response.Redirect("~/recurso/contrato/reportecontrato/contratoReportes.aspx")
    End Sub
    
    Protected Sub btn_reversion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reversion.Click
        Response.Redirect("~/recurso/contrato/reportecontrato/reporteContratoReversion.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContrato" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reportes de contrato</td></tr>
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
                                            <td class="tdDDLEnun">
                                            </td>
                                            <td>
                                                <%--[Aquí viene el DropDownList]--%>
                                            </td>
                                            <td class="tdDDLEspacio">
                                            </td>
                                            <%--Es para insertar un espacio entre opciones (si es necesario)--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_datos_contrato" runat="server" Text="Reportes de contrato"/>
                                </td>
                                <td class="tdButton">
                                    <asp:Button ID="btn_reversion" runat="server" Text="Reporte de reversiones"/>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

