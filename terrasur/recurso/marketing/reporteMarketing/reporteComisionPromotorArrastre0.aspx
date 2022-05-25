<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Planilla de comisiones con arrastres (por promotor)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/cicloComercialPeriodo.ascx" TagName="cicloComercialPeriodo" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", "reporteComisionPromotorArrastre") Then
                Dim nombre_reporte As String = New permiso("reporteComisionPromotorArrastre", "reporteMarketing").nombre
                'Page.Title = nombre_reporte
                lbl_titulo.Text = nombre_reporte
                cb_totcom.Checked = False
                If Profile.entorno.id_rol = New rol("adm").id_rol Then
                    cb_totcom.Visible = True
                Else
                    cb_totcom.Visible = False
                End If
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim reporte As New rpt_comision_arrastre
        'reporte.DataSource = marketingReporte.ReporteComisionPromotorArrastre(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin)
        'reporte.CargarDatos(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin)
        Reporte1.WebView.Report = reporte
        If cb_totcom.Visible = True AndAlso cb_totcom.Checked = True Then
            'marketingReporte.TablaTotcom(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, "")
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteComisionPromotorArrastre" />
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
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2" class="formTdMsg">
                                            <asp:ValidationSummary ID="vs_reporte" runat="server" DisplayMode="List" ShowMessageBox="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Periodo:</td>
                                        <td class="formTdDato"><uc3:cicloComercialPeriodo ID="CicloComercialPeriodo1" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"><asp:CheckBox ID="cb_totcom" runat="server" Text="Generar tabla totcom" Checked="false" /></td>
                                    </tr>
                                </table>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteComisionPromotorArrastre" />
            </td>
        </tr>
    </table>
</asp:Content>