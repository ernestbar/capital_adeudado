<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Inventario - Negocios y Folios (para el dpto. Legal)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<%@ Register src="userControl/legalFiltroLote.ascx" tagname="legalFiltroLote" tagprefix="uc3" %>
<%@ Register src="userControl/legalFiltroNegocioFinanzas.ascx" tagname="legalFiltroNegocioFinanzas" tagprefix="uc4" %>
<%@ Register src="userControl/legalFiltroNegocioLegal.ascx" tagname="legalFiltroNegocioLegal" tagprefix="uc5" %>
<%@ Register src="userControl/legalFiltroFolio.ascx" tagname="legalFiltroFolio" tagprefix="uc6" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteLegal", "reporteNegociosFolios") Then
                legalFiltroLote1.Reset()
                legalFiltroNegocioFinanzas1.Reset()
                legalFiltroNegocioLegal1.Reset()
                legalFiltroFolio1.Reset()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Public Sub cargarReporte()
        If legalFiltroFolio1.varias_observaciones = False Then
            Dim reporte As New rpt_legal_negocios_folios()
            reporte.Encabezado(Profile.nombre_persona, cp_fecha.SelectedDate, legalFiltroLote1.string_localizacion, legalFiltroLote1.string_urbanizacion, legalFiltroLote1.string_manzano, legalFiltroLote1.string_lote, legalFiltroLote1.string_estado, legalFiltroLote1.string_num_contrato, _
                               legalFiltroNegocioFinanzas1.string_negocio, _
                               legalFiltroNegocioLegal1.string_negocio, legalFiltroNegocioLegal1.string_estadotramite, legalFiltroNegocioLegal1.string_fecha, _
                               legalFiltroFolio1.string_con_folio, legalFiltroFolio1.string_num_folio, legalFiltroFolio1.string_entregado, legalFiltroFolio1.string_varias_observaciones)
            reporte.DataSource = legalReporte.ReporteNegociosFolios(cp_fecha.SelectedDate, legalFiltroLote1.id_localizacion, legalFiltroLote1.id_urbanizacion, legalFiltroLote1.id_manzano, legalFiltroLote1.id_lote, legalFiltroLote1.id_estado, legalFiltroLote1.num_contrato, _
                                                                   legalFiltroNegocioFinanzas1.id_negocio, _
                                                                   legalFiltroNegocioLegal1.id_negocio, legalFiltroNegocioLegal1.id_estadotramite, legalFiltroNegocioLegal1.fecha_inicio, legalFiltroNegocioLegal1.fecha_fin, _
                                                                   legalFiltroFolio1.con_folio, legalFiltroFolio1.num_folio, legalFiltroFolio1.entregado, legalFiltroFolio1.entregado_fecha_inicio, legalFiltroFolio1.entregado_fecha_fin, legalFiltroFolio1.varias_observaciones)
            Reporte1.WebView.Report = reporte
        Else
            Dim reporte As New rpt_legal_negocios_folios_obs()
            reporte.Encabezado(Profile.nombre_persona, cp_fecha.SelectedDate, legalFiltroLote1.string_localizacion, legalFiltroLote1.string_urbanizacion, legalFiltroLote1.string_manzano, legalFiltroLote1.string_lote, legalFiltroLote1.string_estado, legalFiltroLote1.string_num_contrato, _
                               legalFiltroNegocioFinanzas1.string_negocio, _
                               legalFiltroNegocioLegal1.string_negocio, legalFiltroNegocioLegal1.string_estadotramite, legalFiltroNegocioLegal1.string_fecha, _
                               legalFiltroFolio1.string_con_folio, legalFiltroFolio1.string_num_folio, legalFiltroFolio1.string_entregado, legalFiltroFolio1.string_varias_observaciones)
            reporte.DataSource = legalReporte.ReporteNegociosFolios(cp_fecha.SelectedDate, legalFiltroLote1.id_localizacion, legalFiltroLote1.id_urbanizacion, legalFiltroLote1.id_manzano, legalFiltroLote1.id_lote, legalFiltroLote1.id_estado, legalFiltroLote1.num_contrato, _
                                                                   legalFiltroNegocioFinanzas1.id_negocio, _
                                                                   legalFiltroNegocioLegal1.id_negocio, legalFiltroNegocioLegal1.id_estadotramite, legalFiltroNegocioLegal1.fecha_inicio, legalFiltroNegocioLegal1.fecha_fin, _
                                                                   legalFiltroFolio1.con_folio, legalFiltroFolio1.num_folio, legalFiltroFolio1.entregado, legalFiltroFolio1.entregado_fecha_inicio, legalFiltroFolio1.entregado_fecha_fin, legalFiltroFolio1.varias_observaciones)
            Reporte1.WebView.Report = reporte
        End If
    End Sub
        
   
    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteLegal" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
 <asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de Inventario - Negocios y Folios (para el dpto. Legal)</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdButtonVolver">
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table cellpadding="0" cellspacing="0" align="center">
                            <tr>
                                <td colspan="2">
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr>
                                            <td class="formTdEnun">A la fecha:</td>
                                            <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr><td><uc3:legalFiltroLote ID="legalFiltroLote1" runat="server" /></td></tr>
                                        <tr><td><br /></td></tr>
                                        <tr><td><uc4:legalFiltroNegocioFinanzas ID="legalFiltroNegocioFinanzas1" runat="server" /></td></tr>
                                    </table>
                                </td>
                                <td valign="top">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr><td><uc5:legalFiltroNegocioLegal ID="legalFiltroNegocioLegal1" runat="server" /></td></tr>
                                        <tr><td><br /></td></tr>
                                        <tr><td><uc6:legalFiltroFolio ID="legalFiltroFolio1" runat="server" /></td></tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_mostrar" runat="server"  SkinID="btnAccion" Text="Mostrar reporte"/>
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

