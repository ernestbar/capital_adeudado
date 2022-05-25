<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            btn_por_mora.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "mora_ver")
            btn_por_fuerza.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "fuerza_ver")
            btn_deshacer.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "deshacer")
        End If
    End Sub
    
    Protected Sub btn_por_mora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_por_mora.Click
        Response.Redirect("~/recurso/contrato/reversion/contratoReversionMora.aspx")
    End Sub

    Protected Sub btn_por_fuerza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_por_fuerza.Click
        Response.Redirect("~/recurso/contrato/reversion/contratoReversionFuerza.aspx")
    End Sub
    
    Protected Sub btn_deshacer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_deshacer.Click
        Response.Redirect("~/recurso/contrato/reversion/contratoReversionDeshacer.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reversion" MostrarLink="true"  />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reversiones de contratos</td></tr>
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
                                    <asp:Button ID="btn_por_mora" runat="server" Text="Reversión por mora" />
                                    <asp:Button ID="btn_por_fuerza" runat="server" Text="Reversión por fuerza"/>
                                    <asp:Button ID="btn_deshacer" runat="server" Text="Deshacer reversión"/>
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

