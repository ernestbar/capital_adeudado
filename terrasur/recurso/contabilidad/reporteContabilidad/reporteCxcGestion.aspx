<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Cuentas por Cobrar por Gestión" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCxcGestion") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        Dim casas_edif As String = ConfigurationManager.AppSettings("negocios_casas")
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(False)
        Next
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Fecha_eval As DateTime = cp_fecha_eval.SelectedDate.Date
        Dim Fecha_inicio As DateTime = Fecha_eval.AddDays(Fecha_eval.DayOfYear * (-1)).AddDays(1)
        Dim Fecha_fin As DateTime = Fecha_inicio.AddYears(1).AddDays(-1)

        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Select Case rbl_tipo.SelectedValue
            Case "detalle"
                Dim reporte As New rpt_cxc_gestion_detalle
                reporte.DataSource = contabilidadReporte.Cxc_Gestion(Fecha_inicio, Fecha_fin, Fecha_eval, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
                reporte.Encabezado(Fecha_eval.ToString("yyyy") & " (" & Fecha_inicio.ToString("d") & " - " & Fecha_fin.ToString("d") & ")", Fecha_eval, general.StringNegocios(False, cbl_negocio.Items), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
                Reporte1.WebView.Report = reporte
            Case "resumen"
                Dim reporte As New rpt_cxc_gestion_resumen
                reporte.DataSource = contabilidadReporte.Cxc_Gestion(Fecha_inicio, Fecha_fin, Fecha_eval, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
                reporte.Encabezado(Fecha_eval.ToString("yyyy") & " (" & Fecha_inicio.ToString("d") & " - " & Fecha_fin.ToString("d") & ")", Fecha_eval, general.StringNegocios(False, cbl_negocio.Items), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
                Reporte1.WebView.Report = reporte
            Case "gerencial"
                Dim reporte As New rpt_cxc_gestion_gerencial
                reporte.DataSource = contabilidadReporte.Cxc_Gestion(Fecha_inicio, Fecha_fin, Fecha_eval, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
                reporte.Encabezado(Fecha_eval.ToString("yyyy") & " (" & Fecha_inicio.ToString("d") & " - " & Fecha_fin.ToString("d") & ")", Fecha_eval, general.StringNegocios(False, cbl_negocio.Items), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
                Reporte1.WebView.Report = reporte
        End Select
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
    Protected Sub rbl_consolidado_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_consolidado.DataBound
        If rbl_consolidado.Items.Count > 0 Then
            rbl_consolidado.SelectedIndex = 0
        End If
        lbl_consolidado_enun.Text = "Datos contemplados:"
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteCxcDetalle" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Cuentas por Cobrar por Gestión</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Fecha de evaluación:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha_eval" runat="server" Width="100px"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                            <%--[id_negocio],[codigo],[nombre],[origen]--%>
                                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Moneda:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                            <%--[valor],[texto]--%>
                                            <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_tipo" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Detalle" Value="detalle" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Resumen por sector" Value="resumen"></asp:ListItem>
                                                <asp:ListItem Text="Gerencial" Value="gerencial"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteCxcDetalle" />
            </td>
        </tr>
    </table>
</asp:Content>