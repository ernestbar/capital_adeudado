<%@ Control Language="VB" ClassName="contratoViewLote" %>

<script runat="server">
    Public Sub Cargar(ByVal id_lote As String, ByVal codigo_moneda As String)
        Dim loteObj As New lote(id_lote)
        lbl_localizacion.Text = loteObj.nombre_localizacion
        lbl_urbanizacion.Text = loteObj.nombre_urbanizacion
        lbl_manzano.Text = loteObj.codigo_manzano
        lbl_lote.Text = loteObj.codigo
        lbl_superficie.Text = loteObj.superficie_m2
        lbl_precio_m2.Text = loteObj.precio_m2_sus.ToString("F2")
        Dim precio_sus As Decimal = loteObj.superficie_m2 * loteObj.precio_m2_sus

        Dim tipo_cambio_actual As Decimal
        If codigo_moneda = "$us" Then
            tipo_cambio_actual = 1
            lbl_precio_total_enun.Visible = False
            lbl_precio_total.Visible = False
        Else
            tipo_cambio_actual = New tipo_cambio(DateTime.Now).compra
            lbl_precio_total_enun.Visible = True
            lbl_precio_total.Visible = True
        End If
        
        lbl_precio_total_sus.Text = precio_sus.ToString("F2")
        lbl_precio_total.Text = (precio_sus * tipo_cambio_actual).ToString("F2")
    End Sub
    
    'Public WriteOnly Property id_lote() As Integer
    '    Set(ByVal value As Integer)
    '        Dim loteObj As New lote(value)
    '        lbl_localizacion.Text = loteObj.nombre_localizacion
    '        lbl_urbanizacion.Text = loteObj.nombre_urbanizacion
    '        lbl_manzano.Text = loteObj.codigo_manzano
    '        lbl_lote.Text = loteObj.codigo
    '        lbl_superficie.Text = loteObj.superficie_m2
    '        lbl_precio_m2.Text = loteObj.precio_m2_sus.ToString("F2")
    '        'lbl_precio_sus.Text = (loteObj.superficie_m2 * loteObj.precio_m2_sus).ToString("F2")
    '        'lbl_precio_total_sus.Text = lbl_precio_sus.Text

    '        lbl_precio_total.Text = (loteObj.superficie_m2 * loteObj.precio_m2_sus).ToString("F2")
    '    End Set
    'End Property
    'Public WriteOnly Property codigo_moneda() As String
    '    Set(ByVal value As String)
    '        Dim tipo_cambio_actual As Decimal
    '        If value = "$us" Then
    '            tipo_cambio_actual = 1
    '            lbl_precio_total_enun.Visible = False
    '            lbl_precio_total.Visible = False
    '        Else
    '            tipo_cambio_actual = New tipo_cambio(DateTime.Now).compra
    '            lbl_precio_total_enun.Visible = True
    '            lbl_precio_total.Visible = True
    '        End If
    '    End Set
    'End Property
</script>
<table class="contratoViewTable" align="left" cellpadding="0" cellspacing="0">
    <tr>
        <td rowspan="3" class="contratoFormTdLeft"></td>
        <td class="contratoViewTdHorEnun">Localizacion</td>
        <td class="contratoViewTdHorEnun">Sector</td>
        <td class="contratoViewTdHorEnun">Manzano</td>
        <td class="contratoViewTdHorEnun">Lote</td>
    </tr>
    <tr>
        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_manzano" runat="server"></asp:Label></td>
        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_lote" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdEnun">Superficie (m2):</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_superficie" runat="server"></asp:Label></td>
                    <td class="contratoViewTdEspacio"></td>
                    <td class="contratoViewTdEnun">Precio ($/m2):</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_precio_m2" runat="server"></asp:Label></td>
                    <td class="contratoViewTdEspacio"></td>
                    <td class="contratoViewTdEnun">Precio total ($):</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_precio_total_sus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td class="contratoViewTdEnun"><asp:Label ID="lbl_precio_total_enun" runat="server" Visible="false" Text="Precio total (Bs):"></asp:Label> </td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_precio_total" runat="server" Visible="false"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>