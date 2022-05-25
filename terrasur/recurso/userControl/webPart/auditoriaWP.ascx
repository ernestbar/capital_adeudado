<%@ Control Language="VB" ClassName="auditoriaWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_periodo()
            recurso_reporte()
        End If
    End Sub
    
    Protected Sub recurso_periodo()
        If Profile.entorno.codigo_modulo = "adm" Then
            lbl_periodo_titulo.Visible = True
            panel_periodo.Visible = True
            Dim Fecha_inicio As DateTime = DateTime.Now.Date.AddDays(-1)
            Dim Fecha_fin As DateTime = DateTime.Now.Date
            Dim Periodo1_ini As DateTime = DateTime.Now.Date.AddHours(8).AddMinutes(30)
            Dim Periodo1_fin As DateTime = DateTime.Now.Date.AddHours(13)
            Dim Periodo2_ini As DateTime = DateTime.Now.Date.AddHours(14).AddMinutes(30)
            Dim Periodo2_fin As DateTime = DateTime.Now.Date.AddHours(19)
            Dim Num_transacciones As Integer = 0
            Dim Num_transacciones_anuladas As Integer = 0
            Dim Num_facturas_anulados As Integer = 0
            Dim Num_recibos_anulados As Integer = 0
            Dim Num_comprobantes_anulados As Integer = 0
            auditoriaReporte.Reporte_pago_fuera_del_periodo_totales(Fecha_inicio, Fecha_fin, Periodo1_ini, Periodo1_fin, Periodo2_ini, Periodo2_fin, Num_transacciones, Num_transacciones_anuladas, Num_facturas_anulados, Num_recibos_anulados, Num_comprobantes_anulados)
            lbl_periodo_fechas.Text = Fecha_inicio.ToString("d") & " - " & Fecha_fin.ToString("d")
            lbl_periodo_valido.Text = Periodo1_ini.ToString("t") & "-" & Periodo1_fin.ToString("t") & " ; " & Periodo2_ini.ToString("t") & "-" & Periodo2_fin.ToString("t")

            lbl_periodo_transacciones.Text = Num_transacciones & " trans."
            lbl_periodo_transacciones_anuladas.Text = Num_transacciones_anuladas & " trans. anuladas"
            lbl_periodo_facturas_anuladas.Text = Num_facturas_anulados & " facturas anuladas"
            lbl_periodo_recibos_anulados.Text = Num_recibos_anulados & " recibos anulados"
            lbl_periodo_comprobantes_anulados.Text = Num_comprobantes_anulados & " comprobantes anulados"
            If Num_transacciones > 0 Then
                lbl_periodo_transacciones.ForeColor = Drawing.Color.Red
            End If
            If Num_transacciones_anuladas > 0 Then
                lbl_periodo_transacciones_anuladas.ForeColor = Drawing.Color.Red
            End If
            If Num_facturas_anulados > 0 Then
                lbl_periodo_facturas_anuladas.ForeColor = Drawing.Color.Red
            End If
            If Num_recibos_anulados > 0 Then
                lbl_periodo_recibos_anulados.ForeColor = Drawing.Color.Red
            End If
            If Num_comprobantes_anulados > 0 Then
                lbl_periodo_comprobantes_anulados.ForeColor = Drawing.Color.Red
            End If

        Else
            lbl_periodo_titulo.Visible = False
            panel_periodo.Visible = False
        End If
    End Sub
    
    Protected Sub recurso_reporte()
        If modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteAuditoria").id_recurso) = True _
        And permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteAuditoria", "ver") = True Then
            panel_reporte.Visible = True
        Else
            panel_reporte.Visible = False
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("codigo_reporte") = CType(sender, LinkButton).CommandArgument
        Response.Redirect("~/recurso/auditoria/reporteAuditoria/Default.aspx")
    End Sub
    Protected Sub btn_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reporte.Click
        Response.Redirect("~/recurso/auditoria/reporteAuditoria/Default.aspx")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_periodo_titulo" runat="server" SkinID="lblWebPartTitle" Text="Eventos fuera del horario regular"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Panel ID="panel_periodo" runat="server">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight:bold;">Fechas:</td>
                                        <td><asp:Label ID="lbl_periodo_fechas" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight:bold;">Horario regular:</td>
                                        <td><asp:Label ID="lbl_periodo_valido" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <label style="font-weight:bold;">Eventos:</label>
                                            <asp:Label ID="lbl_periodo_transacciones" runat="server"></asp:Label>;
                                            <asp:Label ID="lbl_periodo_transacciones_anuladas" runat="server"></asp:Label>;
                                            <asp:Label ID="lbl_periodo_facturas_anuladas" runat="server"></asp:Label>;
                                            <asp:Label ID="lbl_periodo_recibos_anulados" runat="server"></asp:Label>;
                                            <asp:Label ID="lbl_periodo_comprobantes_anulados" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de auditoría"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_auditoria_titulo" runat="server" SkinID="lblWebPartTitle" Text="Operaciones y transacciones"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Panel ID="panel_reporte_auditoria" runat="server" ScrollBars="Vertical" Height="175px">
                                <asp:Repeater ID="r_reporte_auditoria" runat="server" DataSourceID="xds_lista_reporte_auditoria">
                                    <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                    <ItemTemplate><tr><td><asp:LinkButton ID="lb_reporte" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_reporte_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                    <FooterTemplate></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:XmlDataSource ID="xds_lista_reporte_auditoria" runat="server" DataFile="~/App_Data/reportesAuditoria.xml" XPath="/reportes/reporte[@parametro='false']"></asp:XmlDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_parametro_titulo" runat="server" SkinID="lblWebPartTitle" Text="Parámetros"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Repeater ID="r_reporte_parametro" runat="server" DataSourceID="xds_lista_reporte_parametro">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_reporte" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_reporte_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                            <asp:XmlDataSource ID="xds_lista_reporte_parametro" runat="server" DataFile="~/App_Data/reportesAuditoria.xml" XPath="/reportes/reporte[@parametro='true']"></asp:XmlDataSource>
                        </td>
                    </tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_reporte" runat="server" Text="Entrar" SkinID="btnWebPart"/></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>

