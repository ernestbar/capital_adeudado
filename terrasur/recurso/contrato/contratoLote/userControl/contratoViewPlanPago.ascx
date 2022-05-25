<%@ Control Language="VB" ClassName="contratoViewPlanPago" %>

<script runat="server">
    Public Sub Cargar(ByVal num_cuotas As Integer, ByVal seguro As Decimal, ByVal mantenimiento As Decimal, _
    ByVal interes As Decimal, ByVal cuota_base As Decimal, ByVal fecha_inicio As Date, ByVal codigo_moneda As String, ByVal Num_seguro As Integer)
        lbl_num_cuota.Text = num_cuotas
        lbl_seguro.Text = seguro
        lbl_mantenimiento.Text = mantenimiento.ToString("F2")
        lbl_interes.Text = interes
        lbl_interes_penal.Text = New parametro("tasa_mora").valor
        lbl_cuota_base.Text = cuota_base.ToString("F2")
        lbl_fecha_inicio.Text = fecha_inicio.ToString("d") '("dd/mm/yyyy")
        If Num_seguro = 0 Then
            lbl_num_seguro.Text = "---"
        Else
            lbl_num_seguro.Text = Num_seguro
        End If
        
        lbl_mantenimiento_enun.Text = "(" & codigo_moneda & " mensual)"
        lbl_cuota_base_enun.Text = "Cuota mensual (" & codigo_moneda & "):"
    End Sub
</script>
<table class="contratoViewTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td rowspan="2" class="contratoFormTdLeft"></td>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdHorEnun">Nº cuotas</td>
                    <td class="contratoViewTdHorEnun">Seguro desgr.<br />(% mensual)</td>
                    <td class="contratoViewTdHorEnun">Mantenimiento<br /><asp:Label ID="lbl_mantenimiento_enun" runat="server" Text="($us mensual)"></asp:Label></td>
                    <td class="contratoViewTdHorEnun">Interés corr.<br />(% anual)</td>
                    <td class="contratoViewTdHorEnun">Interés penal<br />(% mensual)</td>
                </tr>
                <tr>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_num_cuota" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_seguro" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_mantenimiento" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_interes" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_interes_penal" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoViewTdEnun">Nº form. seguro:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_num_seguro" runat="server"></asp:Label></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdEnun"><asp:Label ID="lbl_cuota_base_enun" runat="server" Text="Cuota mensual ($us):"></asp:Label></td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_cuota_base" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
        <td>
            <table align="right" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdEnun">Inicio de plan:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_inicio" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
