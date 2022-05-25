<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Caja - Pagos - TerraPlus" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/cajaTerraPlusAnulacionesMaster.ascx" tagname="cajaTerraPlusAnulacionesMaster" tagprefix="uc0" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoBusqueda.ascx" tagname="tpContratoBusqueda" tagprefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc2" %>
<%@ Register src="~/recurso/caja/anulacion/userControl/ingresoAnulacionTerraPlus.ascx" tagname="ingresoAnulacionTerraPlus" tagprefix="uc3" %>

<script runat="server">
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler tpContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                tpDatosTerraPlus1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                MultiView1.ActiveViewIndex = 1
                CargarAnulaciones()
                Session.Remove("id_contrato")
            Else
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "terraplus_dia") = False _
                    And permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "terraplus_mes") = False Then
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        tpDatosTerraPlus1.id_contrato = tpContratoBusqueda1.id_resultado
        MultiView1.ActiveViewIndex = 1
        CargarAnulaciones()
    End Sub

    Protected Sub CargarAnulaciones()
        ingresoAnulacionTerraPlus1.id_contrato = tpDatosTerraPlus1.id_contrato
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        tpContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <%--<uc0:cajaTerraPlusMaster ID="cajaTerraPlusMaster1" runat="server" />--%>
    <uc0:cajaTerraPlusAnulacionesMaster ID="cajaTerraPlusAnulacionesMaster1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Caja - Anulaciones - TerraPlus
            </td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdBusqueda">
                                    <uc1:tpContratoBusqueda ID="tpContratoBusqueda1" runat="server" buscar_contrato="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <table class="tableContenido" align="center">
                                        <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                        <tr>
                                            <td class="tdEncabezado">
                                                <uc2:tpDatosTerraPlus ID="tpDatosTerraPlus1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdGrid">
                                                <table align="center" width="100%">
                                                    <tr>
                                                        <td>
                                                            <uc3:ingresoAnulacionTerraPlus ID="ingresoAnulacionTerraPlus1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
