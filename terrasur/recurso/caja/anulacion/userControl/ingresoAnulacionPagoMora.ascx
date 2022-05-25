<%@ Control Language="VB" ClassName="ingresoAnulacionPagoMora" %>

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
        If pago_mora.PermitirAnular(id_contrato, Profile.id_usuario, Profile.entorno.id_rol) = True Then
            panel_anular_pago.Visible = True
            
            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)
            lbl_monto_pagar_enun.Text = "a Pagar (" & codigo_moneda & ")"
            lbl_monto_pagado_enun.Text = "Pagado (" & codigo_moneda & ")"
            
            Dim id_ultimo_pago As New pago_mora(contrato.UltimoPagoMora(id_contrato))
            lbl_fecha.Text = id_ultimo_pago.fecha.ToString("d")
            lbl_num_dias.Text = id_ultimo_pago.num_dias.ToString()
            lbl_num_cuotas.Text = id_ultimo_pago.num_cuotas.ToString()
            lbl_monto_pagar.Text = id_ultimo_pago.monto_pagar.ToString("F2")
            lbl_monto_pagado.Text = id_ultimo_pago.monto_pagado.ToString("F2")
        Else
            panel_anular_pago.Visible = False
        End If
    End Sub
 
    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/anulacion/anulacionPagoMora.aspx")
    End Sub
</script>


<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_anular_pago" runat="server"  GroupingText="Anulación del último pago de mora realizado">
    <table class="cajaIngresoTable" >
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contratoViewTdHorEnun"></td>
                        <td class="contratoViewTdHorEnun"></td>
                        <td class="contratoViewTdHorEnun">Fecha</td>
                        <td class="contratoViewTdHorEnun">No. días</td>
                        <td class="contratoViewTdHorEnun">No. cuotas</td>
                        <td class="contratoViewTdHorEnun">Monto<br /><asp:Label ID="lbl_monto_pagar_enun" runat="server" Text="a Pagar ($us)"></asp:Label></td>
                        <td class="contratoViewTdHorEnun">Monto<br /><asp:Label ID="lbl_monto_pagado_enun" runat="server" Text="Pagado ($us)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="contratoViewTdHorEnun">Pago de mora:</td>
                        <td class="contratoViewTdHorEnun" width="10px"></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_num_dias" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_num_cuotas" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_monto_pagar" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_monto_pagado" runat="server"></asp:Label></td>
                   </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="El último pago de mora se puede anular."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Anular PAGO DE MORA realizado" CommandArgument="0" />
            </td>
         </tr>
    </table>
</asp:Panel>