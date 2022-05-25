<%@ Control Language="VB" ClassName="ingresoAnulacionUltimoPago" %>

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
        If pago.PermitirAnularUltimoPago(id_contrato, Profile.id_usuario, Profile.entorno.id_rol) = True Then
            panel_anular_pago.Visible = True
            Dim id_ultimo_pago As New pago(contrato.UltimoPago(id_contrato, Date.Now))
            lbl_fecha_pago.Text = id_ultimo_pago.fecha.ToString("d")
            lbl_fecha_interes.Text = id_ultimo_pago.interes_fecha.ToString("d")
            lbl_fecha_prox.Text = id_ultimo_pago.fecha_proximo.ToString("d")
            lbl_num_dias.Text = id_ultimo_pago.interes_dias.ToString()
            lbl_cuotas.Text = simular.tabla_plan_string_cuotas(id_ultimo_pago.anterior_num_cuotas, id_ultimo_pago.num_cuotas)
            lbl_pago.Text = id_ultimo_pago.monto_pago.ToString("F2")
            
            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)
            lbl_pago_enun.Text = "Pago (" & codigo_moneda & ")"
        Else
            panel_anular_pago.Visible = False
        End If
    End Sub
 
    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/anulacion/anulacionUltimoPago.aspx")
    End Sub
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_anular_pago" runat="server"  GroupingText="Anulación del último pago realizado">
    <table class="cajaIngresoTable" >
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contratoViewTdHorEnun"></td>
                        <td class="contratoViewTdHorEnun"></td>
                        <td class="contratoViewTdHorEnun">Fecha Pago</td>
                        <td class="contratoViewTdHorEnun">Fecha Pago<br />(interés)</td>
                        <td class="contratoViewTdHorEnun">Fecha Prox.<br />Pago</td>
                        <td class="contratoViewTdHorEnun">Num días<br />(interés)</td>
                        <td class="contratoViewTdHorEnun">Cuotas</td>
                        <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_pago_enun" runat="server" Text="Pago ($us)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="contratoViewTdHorEnun">Último pago:</td>
                        <td class="contratoViewTdHorEnun" width="10px"></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha_pago" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha_interes" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_fecha_prox" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_num_dias" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_cuotas" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_pago" runat="server"></asp:Label></td>
                   </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="El último pago se puede anular."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Anular ULTIMO PAGO realizado" CommandArgument="0" />
            </td>
         </tr>
    </table>
</asp:Panel>