<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Caja - Pagos - TerraPlus" %>

<%@ Register src="~/recurso/terraplus/tpContrato/userControl/cajaTerraPlusMaster.ascx" tagname="cajaTerraPlusMaster" tagprefix="uc0" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoBusqueda.ascx" tagname="tpContratoBusqueda" tagprefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc2" %>

<%@ Register src="~/recurso/caja/pagoTerraPlus/userControl/ingresoPagoTerraPlus.ascx" tagname="ingresoPagoTerraPlus" tagprefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler tpContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                tpDatosTerraPlus1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                MultiView1.ActiveViewIndex = 1
                CargarPagos()
                Session.Remove("id_contrato")
            Else
                If parametro_facturacion.ActivoActual = 0 Or tipo_cambio.Actual = 0 Or _
                contrato.PermitirPagosContrato(Profile.id_usuario, Profile.entorno.id_rol) = False Then
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim permitir_cobrar As Boolean = True
        'Dim num_sucursal As Integer = Integer.Parse(ConfigurationManager.AppSettings("num_sucursal"))

        'Si esta se continua con el pago
        If permitir_cobrar = True Then
            tpDatosTerraPlus1.id_contrato = tpContratoBusqueda1.id_resultado
            MultiView1.ActiveViewIndex = 1
            CargarPagos()
        End If
    End Sub

    Protected Sub CargarPagos()
        ingresoPagoTerraPlus1.id_contrato = tpDatosTerraPlus1.id_contrato
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        tpContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <%--<uc0:cajaTerraPlusMaster ID="cajaTerraPlusMaster1" runat="server" tipo_pago="pagoTerraPlus" />--%>
    <uc0:cajaTerraPlusMaster ID="cajaTerraPlusMaster1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Caja - Pagos - TerraPlus
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
                                                            <uc3:ingresoPagoTerraPlus ID="ingresoPagoTerraPlus1" runat="server" />
                                                            <%--<asp:Panel ID="panel_pago" runat="server" GroupingText="PAGOS">
                                                                <table align="center" width="100%">
                                                                    <tr><td><uc6:ingresoPagoMora ID="IngresoPagoMora1" runat="server" /></td></tr>
                                                                    <tr><td><uc3:ingresoPagoInicial ID="IngresoPagoInicial1" runat="server" /></td></tr>
                                                                    <tr><td><uc7:ingresoPagoNormal ID="IngresoPagoNormal1" runat="server" /></td></tr>
                                                                    <tr><td><uc8:ingresoPagoSegunPlan ID="IngresoPagoSegunPlan1" runat="server" /></td></tr>
                                                                    <tr><td><table width="100%"><tr>
                                                                        <td><uc5:ingresoPagoAdelantado ID="IngresoPagoAdelantado1" runat="server" /></td>
                                                                        <td><uc4:ingresoPagoCapital ID="IngresoPagoCapital1" runat="server" /></td>
                                                                    </tr></table></td></tr>
                                                                    <tr><td><uc9:ingresoPagoServiciosCliente ID="IngresoPagoServiciosCliente1" runat="server" /></td></tr>
                                                                </table>
                                                            </asp:Panel>--%>
                                                            
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
