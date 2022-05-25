<%@ Control Language="VB" ClassName="liquidacionViewDatos2" %>

<script runat="server">
    Public WriteOnly Property id_contrato() As Integer
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value.ToString()
            Dim c As New contrato(value)
            'Dim l As New lote(value)
            Dim p As New pago(c.id_ultimo_pago)
            lbl_fecha_compra.Text = c.fecha.ToString("d")
            lbl_fecha_ultimo_pago.Text = p.fecha.ToString("d")
            lbl_fecha_actual.Text = Date.Now.ToString("d")
            lbl_contrato_años.Text = logica.AñosContrato(c.fecha, p.fecha).ToString()
            lbl_tiempo_meses.Text = logica.MesesContrato(c.fecha)

            lbl_cuota_mantenimiento_enun.Text = "Cuota de mantenimiento (" & c.codigo_moneda & "):"
            lbl_cuota_mantenimiento.Text = New plan_pago(c.id_planpago_vigente).mantenimiento_sus
        End Set
    End Property
</script>


<asp:Label ID="lbl_id_contrato" runat="server" Visible="false"></asp:Label>
<table class="liquidacionViewTable" align="center" width="100%" cellspacing="0">
    <tr>
        <td class="liquidacionViewTdHorEnun">Fecha de compra:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_fecha_compra" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Fecha de Pago Final:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_fecha_ultimo_pago" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Tiempo de contrato en años:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_contrato_años" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Fecha Actual:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_fecha_actual" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Tiempo hasta fecha actual en meses:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_tiempo_meses" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun"><asp:Label ID="lbl_cuota_mantenimiento_enun" runat="server" Text="Cuota de mantenimiento ($us):"></asp:Label></td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_cuota_mantenimiento" runat="server"></asp:Label></td>
    </tr>
    
</table>