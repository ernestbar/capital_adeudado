<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Reporte de auditoría de Estados especiales de contratos" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/auditoria/reporteAuditoria/userControl/reporteAuditoriaFiltro.ascx" TagName="reporteAuditoriaFiltro" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "reporteAudit") Then
                raf1.Reporte = "audit_reporte_reprogramacion"
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Reporte1.NombreReporte = "Estados especiales de contratos"
        Dim reporte As New rpt_audit_reporte_contrato_estado_especial
        reporte.DataSource = auditoriaReporte.Reporte("audit_reporte_contrato_estado_especial", raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
        reporte.CargarDatos("Estados especiales de contratos", raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
        Reporte1.WebView.Report = reporte
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="contratoEstadoEspecial" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server" Text="Reporte de auditoría de Estados especiales de contratos"></asp:Label></td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_filtro" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr><td><uc3:reporteAuditoriaFiltro ID="raf1" runat="server" /></td></tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:ButtonAction ID="btn_mostrar_reporte" runat="server" Text="Mostrar reporte" TextoEnviando="Generando reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel_report_view" runat="server">
                    <uc2:reporte ID="Reporte1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>