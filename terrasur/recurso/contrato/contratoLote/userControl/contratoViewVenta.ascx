<%@ Control Language="VB" ClassName="contratoViewVenta" %>

<script runat="server">
    ' Req. Capital Adeudado
    Public Sub Cargar(ByVal precio_total As Decimal, ByVal desc_por As Decimal, ByVal desc_sus As Decimal, ByVal precio_final As Decimal, _
    ByVal contado As Boolean, ByVal cuota_inicial As Decimal, ByVal cliente As String, ByVal nit As String, ByVal observacion As String, ByVal preferencial As Boolean, _
    ByVal codigo_moneda As String, ByVal capital_adeudado As Decimal, ByVal porcentaje_capital_deudor As Decimal)
        lbl_precio_total.Text = precio_total.ToString("F2")
        lbl_desc_por.Text = desc_por.ToString("F2")
        lbl_desc_sus.Text = desc_sus.ToString("F2")
        lbl_precio_final.Text = precio_final.ToString("F2")
        If contado Then
            lbl_contado.Text = "Al contado"
        Else
            lbl_contado.Text = "A plazos"
        End If
        lbl_inicial.Text = cuota_inicial.ToString("F2")
        If cliente = "" Then
            lbl_cliente.Text = "----------"
        Else
            lbl_cliente.Text = cliente
        End If
        If nit = "" Then
            lbl_nit.Text = "----------"
        Else
            lbl_nit.Text = nit
        End If
        lbl_observacion.Text = observacion
        If preferencial Then
            lbl_preferencial.Text = "Preferencial"
        Else
            lbl_preferencial.Text = "Normal"
        End If

        lbl_precio_total_enun.Text = "Precio total (" & codigo_moneda & ")"
        lbl_descuento_enun.Text = "Descuento (" & codigo_moneda & ")"
        lbl_precio_final_enun.Text = "Precio final (" & codigo_moneda & ")"
        lbl_inicial_enun.Text = "Cuota inicial (" & codigo_moneda & "):"
        
        If capital_adeudado > 0 Then
            pnlCapAdeudado1.Visible = True
            pnlCapAdeudado2.Visible = True
            lbl_capital_adeudado_titulo.Text = "Capital Adeudado (" & porcentaje_capital_deudor.ToString.Replace(",", ".") & "%)"
            lbl_capital_adeudado.Text = capital_adeudado.ToString() 
        Else
            pnlCapAdeudado1.Visible = False
            pnlCapAdeudado2.Visible = False
        End If
    End Sub
    '
</script>
<table class="contratoViewTable" align="left" cellpadding="0" cellspacing="0">
    <tr>
        <td rowspan="6" class="contratoFormTdLeft"></td>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_precio_total_enun" runat="server" Text="Precio total ($us)"></asp:Label></td>
                    <asp:Panel ID="pnlCapAdeudado1" runat="server" Visible="false">
                        <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_capital_adeudado_titulo" runat="server" Text="Capital Adeudado"></asp:Label></td>
                    </asp:Panel>
                    <td class="contratoViewTdHorEnun">Descuento(%)</td>
                    <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_descuento_enun" runat="server" Text="Descuento($us)"></asp:Label></td>
                    <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_precio_final_enun" runat="server" Text="Precio final ($us)"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_precio_total" runat="server"></asp:Label></td>
                    <asp:Panel ID="pnlCapAdeudado2" runat="server" Visible="false">
                        <td class="contratoFormTdHorDato">
                            <asp:Label ID="lbl_capital_adeudado" runat="server" Text="Capital Adeudado"></asp:Label>
                        </td>
                    </asp:Panel>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_desc_por" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_desc_sus" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_precio_final" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdEnun">Forma de pago:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_contado" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoViewTdEnun"><asp:Label ID="lbl_inicial_enun" runat="server" Text="Cuota inicial ($us):"></asp:Label></td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_inicial" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdEnun">Facturas a nombre de:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
                    <td class="contratoViewTdEnun">con el NIT:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_nit" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdEnun">Observaciones:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_observacion" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoViewTdEnun">Tipo de cliente:</td>
                    <td class="contratoViewTdDato"><asp:Label ID="lbl_preferencial" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
