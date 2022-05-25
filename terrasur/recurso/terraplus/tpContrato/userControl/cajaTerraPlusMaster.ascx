<%@ Control Language="VB" ClassName="cajaTerraPlusMaster" %>

<script runat="server">
    Public Property tipo_pago() As String
        Get
            Return lbl_tipo_pago.Text
        End Get
        Set(ByVal value As String)
            lbl_tipo_pago.Text = value
            lbl_gruporecurso.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

            Select Case value
                Case "pagoTerraPlus"
                    lbl_gruporecurso.Text = "Pago TerraPlus"
            End Select
        End Set
    End Property
</script>
<asp:Label ID="lbl_tipo_pago" runat="server" Visible="false"></asp:Label>
<table class="masterRecursoTable" align="right" cellpadding="0" cellspacing="0">
    <tr>
        <td class="masterRecursoTdRecurso" colspan="2" align="left">
            <asp:HyperLink ID="hl_recurso" runat="server" SkinID="hlMasterRecurso" Text="Caja - Pagos - TerraPlus" NavigateUrl="~/recurso/caja/terraplusPago.aspx"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="masterRecursoTdEspacio"></td>
        <td class="masterRecursoTdGrupo">
            <asp:Label ID="lbl_gruporecurso" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>