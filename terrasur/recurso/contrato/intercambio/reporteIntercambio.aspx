<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Reporte de intercambios" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register src="~/recurso/contrato/intercambio/userControl/filtroReporteIntercambio.ascx" tagname="filtroReporteIntercambio" tagprefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "reporteIntercambio") Then
                If Session("datosFiltroIntercambio") IsNot Nothing Then
                    f1.datosFiltro = Session("datosFiltroIntercambio").ToString
                    Session.Remove("datosFiltroIntercambio")
                End If
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        Dim reporte As New rpt_intercambio()
        Dim tabla As System.Data.DataTable = intercambio.Reporte(f1.fecha_inicio, f1.fecha_fin, f1.num_contrato, f1.id_localizacion, f1.id_urbanizacion, f1.id_manzano, f1.empresa, f1.descripcion)
        reporte.DataSource = tabla
        reporte.Encabezado(f1.str_periodo, f1.num_contrato, f1.str_lote, f1.empresa, f1.descripcion, Profile.nombre_persona, tabla.Rows.Count)
        Reporte1.WebView.Report = reporte
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="intercambio" MostrarLink="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="priTable">
        <tr>
            <td class="priTdTitle">Reporte de intercambios</td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <table align="center">
                    <tr>
                        <td class="tdFiltro">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de búsqueda del reporte" DefaultButton="btn_mostrar">
                                            <table>
                                                <tr><td><uc3:filtroReporteIntercambio ID="f1" runat="server" /></td></tr>
                                                <tr><td align="center"><asp:Button ID="btn_mostrar" runat="server" Text="Mostrar reporte" /></td></tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid">
                            <uc1:reporte ID="Reporte1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>