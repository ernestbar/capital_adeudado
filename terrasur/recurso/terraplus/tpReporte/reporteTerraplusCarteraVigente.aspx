<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cartera TerraPlus" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpReporte/userControl/tpFiltroCarteraVigente.ascx" tagname="tpFiltroCarteraVigente" tagprefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReporte", "reporteTerraplusCarteraVigente") Then
                Dim nombre_reporte As String = New permiso("reporteTerraplusCarteraVigente", "tpReporte").nombre
                lbl_titulo.Text = nombre_reporte
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(tpf1.id_moneda).codigo

        Dim reporte As New rpt_tpCarteraVigente
        reporte.CargarDatos(tpf1.fecha, tpf1.estado_nombres, tpf1.registro_inicio, tpf1.registro_fin, tpf1.ult_pago_inicio, tpf1.ult_pago_fin, tpf1.ult_mes_inicio, tpf1.ult_mes_fin,  tpf1.nombre_ci_cliente , tpf1.tp_num_contrato, Profile.nombre_persona, Codigo_moneda, tpf1.moneda_string, tpf1.consolidado_string)
        reporte.DataSource = terrasur.terraplus.tp_terraplusReporte.Cartera(tpf1.fecha, tpf1.estado_ids, tpf1.registro_inicio, tpf1.registro_fin, tpf1.ult_pago_inicio, tpf1.ult_pago_fin, tpf1.ult_mes_inicio, tpf1.ult_mes_fin, tpf1.nombre_ci_cliente, tpf1.tp_num_contrato, tpf1.id_moneda, tpf1.consolidado)
        Reporte1.WebView.Report = reporte
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteVentasGeneral" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server"></asp:Label></td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <uc3:tpFiltroCarteraVigente ID="tpf1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteCarteraTerraPlus" />
            </td>
        </tr>
    </table>
</asp:Content>