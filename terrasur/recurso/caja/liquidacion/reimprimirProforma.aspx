<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reimpresión de liquidación de contrato" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc4" %>

<script runat="server">
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "liquidacion", "proforma_reimprimir") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        If c.estado_id = 3 Then
            panel_cambio.GroupingText = "Reimpresión de liquidación de contrato"
            ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
            Id_contrato.Text = ContratoDatos1.id_contrato
            Dim rpt As New rpt_proformaLiquidacion()
            Dim c1 As New srpt_ContratoDatos1()
            Dim c2 As New srpt_proformaContratoDatos2()
            Dim dpr As New srpt_proformaDescuentosDpr()
            Dim serv As New srpt_proformaServicios()
            rpt.LlenarDatos(ContratoDatos1.id_contrato)
            rpt.subReport1.Report = c1
            c1.LlenarDatos(ContratoDatos1.id_contrato)
            rpt.subReport2.Report = c2
            c2.LlenarDatos(ContratoDatos1.id_contrato)
            If liquidacion.ListaDescuentoDpr(ContratoDatos1.id_contrato).Rows.Count > 0 Then
                rpt.subReport3.Report = dpr
                dpr.CargarDatos(c.codigo_moneda)
                dpr.DataSource = liquidacion.ListaDescuentoDpr(ContratoDatos1.id_contrato)
            End If
            If servicio_vendido.ListaLiquidacionContrato(ContratoDatos1.id_contrato).Rows.Count > 0 Then
                rpt.subReport4.Report = serv
                serv.CargarDatos(c.codigo_moneda)
                serv.DataSource = servicio_vendido.ListaLiquidacionContrato(ContratoDatos1.id_contrato)
            End If
            Reporte1.WebView.Report = rpt
            Reporte1.Visible = True
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
        <uc1:cajaMaster ID="CajaMaster1" runat="server"  Visible="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
        <asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<table class="priTable">
        <tr><td class="priTdTitle">Reimpresión de liquidación de contrato</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr><td class="tdEncabezado"> 
                                              <uc4:reporte id="Reporte1" runat="server" Visible ="true" />
                                            </td></tr>
                                    </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

