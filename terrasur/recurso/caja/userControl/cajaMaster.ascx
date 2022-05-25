<%@ Control Language="VB" ClassName="cajaMaster" %>

<script runat="server">
    Public Property tipo_pago() As String
        Get
            Return lbl_tipo_pago.Text
        End Get
        Set(ByVal value As String)
            lbl_tipo_pago.Text = value
            lbl_gruporecurso.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            'lbl_gruporecurso.Visible = value.Trim.Equals("").Equals(False)
            Select Case value
                Case "pagoInicial"
                    lbl_gruporecurso.Text = "Cuota Inicial"
                Case "pagoCapital"
                    lbl_gruporecurso.Text = "Pago Directo a Capital"
                Case "pagoNormal"
                    lbl_gruporecurso.Text = "Pago Normal"
                Case "pagoMora"
                    lbl_gruporecurso.Text = "Pago de Intereses Penales"
                Case "pagoAdelantado"
                    lbl_gruporecurso.Text = "Pago Adelantado"
                Case "pagoSegunPlan"
                    lbl_gruporecurso.Text = "Pago Según Plan"
                Case "pagoOtroServicio"
                    lbl_gruporecurso.Text = "Pago/compra de Otros Servicios"
                Case "liquidacion"
                    lbl_gruporecurso.Text = "Liquidación del contrato"
            End Select
        End Set
    End Property

</script>
<asp:Label ID="lbl_tipo_pago" runat="server" Visible="false"></asp:Label>
<table class="masterRecursoTable" align="right" cellpadding="0" cellspacing="0">
    <tr>
        <td class="masterRecursoTdRecurso" colspan="2" align="left">
            <asp:HyperLink ID="hl_recurso" runat="server" SkinID="hlMasterRecurso" Text="Caja - Pagos" NavigateUrl="~/recurso/caja/contratoPago.aspx"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="masterRecursoTdEspacio"></td>
        <td class="masterRecursoTdGrupo">
            <asp:Label ID="lbl_gruporecurso" runat="server" Text="Caja"></asp:Label>
        </td>
    </tr>
</table>
