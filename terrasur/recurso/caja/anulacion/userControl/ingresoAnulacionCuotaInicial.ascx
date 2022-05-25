<%@ Control Language="VB" ClassName="ingresoAnulacionCuotaInicial" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
            Cargar()
        End Set
    End Property
     
    Protected Sub Cargar()
        If pago.PermitirAnularCuotaInicial(id_contrato, Profile.id_usuario, Profile.entorno.id_rol) Then
            panel_ingreso.Visible = True
            
            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)
            lbl_monto_enun.Text = "Monto Pagado (" & codigo_moneda & "):"
            
            Dim p As New pago(contrato.IdPagoInicial(id_contrato))
            lbl_fecha_pago.Text = p.fecha.ToString("d")
            lbl_monto.Text = p.monto_pago.ToString("F2")
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/anulacion/anulacionCuotaInicial.aspx")
    End Sub
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Anulación de la cuota inicial"> 
   <table class="cajaIngresoTable" >
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contratoViewTdEnun">Fecha de pago:</td>
                        <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_pago" runat="server"></asp:Label></td>
                        <td class="contratoViewTdEnun" width="10px"></td>
                        <td class="contratoViewTdEnun"><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto Pagado:"></asp:Label></td>
                        <td class="contratoViewTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="Puede anular la cuota inicial."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Anular CUOTA INICIAL" CommandArgument="0" />
            </td>
         </tr>
    </table>
</asp:Panel>
