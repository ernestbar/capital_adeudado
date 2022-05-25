<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Caja - Anulaciones" %>

<%@ Register Src="~/recurso/caja/anulacion/userControl/ingresoAnulacionPagoMora.ascx" TagName="ingresoAnulacionPagoMora" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/caja/userControl/cajaAnulacionesMaster.ascx" TagName="cajaAnulacionesMaster" TagPrefix="uc0" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/anulacion/userControl/ingresoAnulacionReprogramacion.ascx" TagName="ingresoAnulacionReprogramacion" TagPrefix="uc11" %>
<%@ Register Src="~/recurso/caja/anulacion/userControl/ingresoAnulacionVentaServicios.ascx" TagName="ingresoAnulacionVentaServicios" TagPrefix="uc12" %>
<%@ Register Src="~/recurso/caja/anulacion/userControl/ingresoAnulacionCuotaInicial.ascx" TagName="ingresoAnulacionCuotaInicial" TagPrefix="uc13" %>
<%@ Register Src="~/recurso/caja/anulacion/userControl/ingresoAnulacionUltimoPago.ascx" TagName="ingresoAnulacionUltimoPago" TagPrefix="uc14" %>

<script runat="server">
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                MultiView1.ActiveViewIndex = 1
                CargarAnulaciones()
                Session.Remove("id_contrato")
            Else
                If contrato.PermitirAnulacionesContrato(Profile.id_usuario, Profile.entorno.id_rol) = False Then
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
        End If
    End Sub
     
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
        MultiView1.ActiveViewIndex = 1
        CargarAnulaciones()
    End Sub
    
    Protected Sub CargarAnulaciones()
        IngresoAnulacionReprogramacion1.id_contrato = ContratoDatos1.id_contrato
        IngresoAnulacionVentaServicios1.id_contrato = ContratoDatos1.id_contrato
        IngresoAnulacionCuotaInicial1.id_contrato = ContratoDatos1.id_contrato
        IngresoAnulacionUltimoPago1.id_contrato = ContratoDatos1.id_contrato
        IngresoAnulacionPagoMora1.id_contrato = ContratoDatos1.id_contrato
        If negocio_contrato.CodigoNegocioPorContrato(ContratoDatos1.id_contrato) = "nafibo" Then
            Msg1.Text = "CONTRATO NAFIBO"
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
        <uc0:cajaAnulacionesMaster ID="CajaAnulacionesMaster1" runat="server" tipo_anulacion="" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Caja - Anulaciones
            </td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc1:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <table class="tableContenido" align="center">
                                        <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                        <tr><td class="tdEncabezado"><uc2:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                        <tr>
                                            <td class="tdGrid">
                                                <table align="center" width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Anulaciones">
                                                                <table align="center" width="100%">
                                                                    <tr><td><uc13:ingresoAnulacionCuotaInicial ID="IngresoAnulacionCuotaInicial1" runat="server" /></td></tr>
                                                                    <tr><td><uc14:ingresoAnulacionUltimoPago ID="IngresoAnulacionUltimoPago1" runat="server" /></td></tr>
                                                                    <tr><td><uc3:ingresoAnulacionPagoMora ID="IngresoAnulacionPagoMora1" runat="server" /></td></tr>
                                                                    <tr><td><uc11:ingresoAnulacionReprogramacion id="IngresoAnulacionReprogramacion1" runat="server" /></td></tr>
                                                                    <tr><td><uc12:ingresoAnulacionVentaServicios id="IngresoAnulacionVentaServicios1" runat="server" /></td></tr>
                                                                </table>
                                                            </asp:Panel>
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

