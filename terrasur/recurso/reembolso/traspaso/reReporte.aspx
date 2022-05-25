<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de traspasos y devoluciones" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/filtroReembolso.ascx" tagname="filtroReembolso" tagprefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "reporte") Then
                f1.Reset()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        Dim reporte As New rpt_reembolso_reporte

        reporte.DataSource = terrasur.traspaso.reembolso.Reporte(f1.fecha_fin, _
            f1.tipo_reembolso, f1.num_contrato, f1.origen_contrato, f1.fecha_inicio, f1.fecha_fin, _
            f1.id_usuario, f1.cliente, f1.id_motivo, f1.asignacion, f1.saldo, _
            f1.id_localizacion, f1.id_urbanizacion, f1.id_moneda, f1.consolidado, f1.id_estadoconciliacion) ' Req.Conciliaciones

        reporte.CargarDatos(f1.fecha, Profile.nombre_persona, f1.str_num_contrato, f1.str_tipo, _
    f1.str_fecha, f1.str_usuario, f1.str_motivo, f1.str_cliente, f1.str_ubicacion, _
    f1.str_asignacion, f1.str_saldo, f1.str_moneda, f1.str_consolidado, f1.str_codigo_moneda)

        Reporte1.WebView.Report = reporte
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="traspaso" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server" Text="Reporte de traspasos y devoluciones"></asp:Label></td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_filtro" runat="server" DefaultButton="btn_mostrar">
                    <table class="formEntTable" align="center">
                        <tr>
                            <td class="formEntTdForm">
                                <uc3:filtroReembolso ID="f1" runat="server" ParaReporte="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteTraspasosDevoluciones" />
            </td>
        </tr>
    </table>
</asp:Content>