<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Tipos de cambio históricos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "view") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_ver_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ver_reporte.Click
        Dim reporte As New rpt_tipo_cambio_historico
        Dim fecha_inicio As Date = Date.Now
        Dim fecha_inicio_string As String = "--------"
        If c_inicio.SelectedValue.HasValue Then
            fecha_inicio = c_inicio.SelectedDate
            fecha_inicio_string = c_inicio.SelectedDate.ToString("d")
        End If
        Dim fecha_fin_string As String = "--------"
        Dim fecha_fin As Date = Date.Now
        If c_fin.SelectedValue.HasValue Then
            fecha_fin = c_fin.SelectedDate
            fecha_fin_string = c_fin.SelectedDate.ToString("d")
        End If
        reporte.CargarDatos(fecha_inicio_string, fecha_fin_string)
        
        reporte.DataSource = tipo_cambio.Lista(c_inicio.SelectedValue.HasValue, fecha_inicio, c_fin.SelectedValue.HasValue, fecha_fin)
        Reporte1.WebView.Report = reporte
        
        'rep.CalculatedFields("par_cliente").Value = txt_cliente.Text.Trim
        'rep.CalculatedFields("par_ci").Value = txt_ci.Text.Trim
        'rep.CalculatedFields("par_capital").Value = txt_capital.Text.Trim
        'rep.CalculatedFields("par_inicial").Value = txt_inicial.Text.Trim
        'rep.CalculatedFields("par_num_cuota").Value = txt_num_cuota.Text.Trim
        'rep.CalculatedFields("par_num_gracia").Value = txt_num_gracia.Text.Trim
        'rep.CalculatedFields("par_interes").Value = txt_interes.Text.Trim
        'rep.CalculatedFields("par_seguro").Value = txt_desgravamen.Text.Trim
        'rep.CalculatedFields("par_mantenimiento").Value = txt_mantenimiento.Text.Trim
        'rep.CalculatedFields("par_fecha_inicio").Value = c_inicio.SelectedDate.ToString
        'rep.Run()
        'Reporte1.WebView.Report = rep
        
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="tipoCambio" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Tipos de cambio históricos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_ver_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Desde:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="c_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Hasta:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="c_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_ver_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

