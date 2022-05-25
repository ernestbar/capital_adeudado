<%@ Control Language="VB" ClassName="cajaAnulacionesMaster" %>

<script runat="server">
    Public Property tipo_anulacion() As String
        Get
            Return lbl_tipo_anulacion.Text
        End Get
        Set(ByVal value As String)
            lbl_tipo_anulacion.Text = value
            lbl_gruporecurso.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            'lbl_gruporecurso.Visible = value.Trim.Equals("").Equals(False)
            Select Case value
                Case "cuotaInicial"
                    lbl_gruporecurso.Text = "Anulación de cuota inicial"
                Case "pagoUltimo"
                    lbl_gruporecurso.Text = "Anulación de pago"
                Case "reprogamacion"
                    lbl_gruporecurso.Text = "Anulación de reprogramación"
                Case "otrosServicios"
                    lbl_gruporecurso.Text = "Anulación de venta de servicios"
                Case "otrosServiciosNoCliente"
                    lbl_gruporecurso.Text = "Anulación de venta de servicios a clientes transitorios"
                Case ""
                    lbl_gruporecurso.Text = "Anulaciones"
            End Select
        End Set
    End Property

</script>

<asp:Label ID="lbl_tipo_anulacion" runat="server" Visible="false"></asp:Label>
<table class="masterRecursoTable" align="right" cellpadding="0" cellspacing="0">
    <tr>
        <td class="masterRecursoTdRecurso" colspan="2" align="left">
            <asp:HyperLink ID="hl_recurso" runat="server" SkinID="hlMasterRecurso" Text="Caja - Anulaciones" NavigateUrl="~/recurso/caja/contratoAnulacion.aspx"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="masterRecursoTdEspacio"></td>
        <td class="masterRecursoTdGrupo">
            <asp:Label ID="lbl_gruporecurso" runat="server" Text="Caja"></asp:Label>
        </td>
    </tr>
</table>