<%@ Control Language="VB" ClassName="liquidacionViewDatos1" %>

<script runat="server">
    Public WriteOnly Property id_contrato() As Integer
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value.ToString()
            Dim c As New contrato(value)
            'Dim cl As New cliente(c.id_titular)
            lbl_precio_real.Text = (c.precio).ToString("F2") & " (" & c.codigo_moneda & ")"
            lbl_descuentos_venta.Text = (c.descuento_efectivo + ((c.descuento_porcentaje / 100) * c.precio)).ToString("F2") & " (" & c.codigo_moneda & ")"
            lbl_descuentos_dpr.Text = liquidacion.DescuentoDpr(value).ToString("F2") & " (" & c.codigo_moneda & ")"
            'lbl_precio_lote.Text = (Decimal.Parse(lbl_precio_real.Text) - Decimal.Parse(lbl_descuentos_venta.Text) - Decimal.Parse(lbl_descuentos_dpr.Text)).ToString("F2") & " (" & c.codigo_moneda & ")"
            lbl_precio_lote.Text = (c.precio - (c.descuento_efectivo + ((c.descuento_porcentaje / 100) * c.precio)) - liquidacion.DescuentoDpr(value)).ToString("F2") & " (" & c.codigo_moneda & ")"
            lbl_tccompra.Text = New tipo_cambio(tipo_cambio.Actual).compra
            lbl_tcventa.Text = New tipo_cambio(tipo_cambio.Actual).venta
        End Set
    End Property
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Visible="false"></asp:Label>
<table class="liquidacionViewTable" align="center" width="100%" cellspacing="0">
    <tr>
        <td class="liquidacionViewTdHorEnun"><asp:Label ID="lbl_precio_real_enun" runat="server" Text="Precio Real del lote:"></asp:Label></td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_precio_real" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Descuentos (venta):</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_descuentos_venta" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Descuentos (DPR's):</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_descuentos_dpr" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">Precio Lote (liquidable)</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_precio_lote" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">TC. compra:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_tccompra" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="liquidacionViewTdHorEnun">TC. venta:</td>
        <td class="liquidacionViewTdDato"><asp:Label ID="lbl_tcventa" runat="server"></asp:Label></td>
    </tr>
    
</table>