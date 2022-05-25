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
                    'cb_totcom.Visible = False
                    btn_guardar_bonos.Visible = True
                Else
                    cb_totcom.Visible = False
                    btn_guardar_bonos.Visible = False
                End If
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub rbl_tipo_reporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_tipo_reporte.SelectedIndexChanged
        If rbl_tipo_reporte.SelectedValue = "actual" Then
            lbl_ciclo_enun.Visible = False
            CicloComercialPeriodo1.Visible = False
        Else
            lbl_ciclo_enun.Visible = True
            CicloComercialPeriodo1.Visible = True
        End If
        If rbl_tipo_reporte.SelectedValue = "finanzas_resumen" Then
            lbl_moneda.Visible = True
            rbl_moneda_bs.Visible = True
        Else
            lbl_moneda.Visible = True
            rbl_moneda_bs.Visible = True
            'lbl_moneda.Visible = False
            'rbl_moneda_bs.Visible = False
        End If
    End Sub

    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Select Case rbl_tipo_reporte.SelectedValue
            Case "actual"
                Dim reporte As New rpt_comision_arrastre
                reporte.DataSource = marketingReporte.ReporteComisionPromotorArrastre(cp_inicio.SelectedDate, cp_fin.SelectedDate, Id_negocio())
                reporte.CargarDatos(cp_inicio.SelectedDate, cp_fin.SelectedDate, rbl_negocio.SelectedItem.Text)
                Reporte1.WebView.Report = reporte
                'If cb_totcom.Visible = True AndAlso cb_totcom.Checked = True Then
                '    marketingReporte.TablaTotcom(cp_inicio.SelectedDate, cp_fin.SelectedDate, ConfigurationManager.AppSettings("promotor_codigo"))
                'End If
            Case "marketing"
                Dim reporte As New rpt_comision_arrastre_marketing
                reporte.DataSource = marketingReporte.ReporteComisionPromotorArrastre_marketing(cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio())
                reporte.CargarDatos(cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, rbl_negocio.SelectedItem.Text)
                Reporte1.WebView.Report = reporte
            Case "finanzas_resumen"
                Dim reporte As New rpt_comision_arrastre_planilla_resumen
                reporte.DataSource = marketingReporte.ReporteComisionPromotorArrastre_planilla("grupo_venta,promotor_nombre,num_contrato asc", Boolean.Parse(rbl_moneda_bs.SelectedValue), New tipo_cambio(CicloComercialPeriodo1.fin).compra, cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio())
                reporte.CargarDatos(Boolean.Parse(rbl_moneda_bs.SelectedValue), New tipo_cambio(CicloComercialPeriodo1.fin).compra, cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, rbl_negocio.SelectedItem.Text)
                Reporte1.WebView.Report = reporte


                If cb_totcom.Visible = True AndAlso cb_totcom.Checked = True Then
                    marketingReporte.TablaTotcom(Boolean.Parse(rbl_moneda_bs.SelectedValue), New tipo_cambio(CicloComercialPeriodo1.fin).compra, cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio())
                End If

            Case "finanzas_detalle"
                Dim reporte As New rpt_comision_arrastre_planilla_detalle
                reporte.DataSource = marketingReporte.ReporteComisionPromotorArrastre_planilla("grupo_venta,promotor_nombre,num_contrato asc", Boolean.Parse(rbl_moneda_bs.SelectedValue), New tipo_cambio(CicloComercialPeriodo1.fin).compra, cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio())
                reporte.CargarDatos(Boolean.Parse(rbl_moneda_bs.SelectedValue), New tipo_cambio(CicloComercialPeriodo1.fin).compra, cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, rbl_negocio.SelectedItem.Text)
                Reporte1.WebView.Report = reporte
        End Select
    End Sub

    Protected Sub btn_guardar_bonos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar_bonos.Click
        Dim reporte As New rpt_comision_arrastre_planilla_resumen
        reporte.DataSource = marketingReporte.ReporteComisionPromotorArrastre_planilla("grupo_venta,promotor_nombre,num_contrato asc", Boolean.Parse(rbl_moneda_bs.SelectedValue), New tipo_cambio(CicloComercialPeriodo1.fin).compra, cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio())
        If marketingReporte.ReporteComisionPromotorArrastre_planilla_GuardarBonos(cp_inicio.SelectedDate, cp_fin.SelectedDate, CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio()) = True Then
            lbl_mensaje.Text = "Los bonos generados se guardaron correctamente"
        Else
            lbl_mensaje.Text = "Los bonos generados NO se guardaron correctamente"
        End If

    End Sub

    Protected Function Id_negocio() As String
        Dim resultado As New StringBuilder()
        '[id_negocio],[codigo],[nombre],[origen]
        Dim tabla As Data.DataTable = negocio.Lista
        For Each fila As Data.DataRow In tabla.Rows
            Dim _codigo As String = fila("codigo").ToString
            Dim _id_negocio As String = fila("id_negocio").ToString

            If rbl_negocio.SelectedValue = "todos" Then
                resultado.Append("," & _id_negocio)
            ElseIf rbl_negocio.SelectedValue = "no_mercado" Then
                If _codigo <> "mercado" Then
                    resultado.Append("," & _id_negocio)
                End If
            ElseIf rbl_negocio.SelectedValue = "si_mercado" Then
                If _codigo = "mercado" Then
                    resultado.Append("," & _id_negocio)
                End If
            End If
        Next
        resultado.Append(",")
        Return resultado.ToString
    End Function
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
                                        <td class="formTdEnun">Tipo de reporte:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_tipo_reporte" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Reporte anterior" Value="actual" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Planilla de comisiones - Marketing (Versión final)" Value="marketing"></asp:ListItem>
                                                <asp:ListItem Text="Planilla de comisiones (Resumen) - Finanzas (Versión final)" Value="finanzas_resumen"></asp:ListItem>
                                                <asp:ListItem Text="Planilla de comisiones (Detalle) - Finanzas (Versión final)" Value="finanzas_detalle"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_moneda" runat="server" Visible="false" Text="Moneda:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_moneda_bs" runat="server" Visible="false" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Dólares ($us)" Value="False" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Bolivianos (Bs)" Value="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Periodo para arrastres de comisiones:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_inicio" runat="server" Width="100px"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_fin" runat="server" Width="100px"></ew:CalendarPopup>
                                            <asp:CompareValidator ID="cv_fin" runat="server" ControlToValidate="cp_fin" ControlToCompare="cp_inicio" Type="Date" Operator="GreaterThanEqual" Display="Dynamic" Text="*" ErrorMessage="Rango de fechas Incorrecto"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_ciclo_enun" runat="server" Visible="false" Text="Ciclo comercial para comisiones iniciales:"></asp:Label></td>
                                        <td class="formTdDato"><uc3:cicloComercialPeriodo ID="CicloComercialPeriodo1" runat="server" Visible="false" /></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_negocio" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Todos" Value="todos" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Todos excepto Mercado" Value="no_mercado"></asp:ListItem>
                                                <asp:ListItem Text="Solo Mercado La Suiza" Value="si_mercado"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
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
                                <asp:Button ID="btn_guardar_bonos" runat="server" SkinID="btnAccion" Text="Guardar bonos generados" OnClientClick="return confirm('¿Esta seguro que desea guardar los bonos generados?');" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Label ID="lbl_mensaje" runat="server" SkinID="lblMsg"></asp:Label>
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