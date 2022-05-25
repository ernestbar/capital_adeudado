<%@ Control Language="VB" ClassName="ingresoAnulacionReprogramacion" %>

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
    
    Public Property id_plan_pago_anulable() As Integer
        Get
            Return Integer.Parse(lbl_id_plan_pago_anulable.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_plan_pago_anulable.Text = value
        End Set
    End Property
      
    Protected Sub Cargar()
        Dim id_plan_pago As Integer
        id_plan_pago = plan_pago.AnulacionIdReprogramacion(id_contrato, Profile.id_usuario, Profile.entorno.id_rol)
        If id_plan_pago > 0 Then
            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)
            lbl_mantenimiento_enun.Text = "(" & codigo_moneda & " mes)"
            lbl_cuota_base_enun.Text = "(" & codigo_moneda & ")"
            
            Dim pp As New plan_pago(id_plan_pago)
            panel_anular_reprogramacion.Visible = True
            id_plan_pago_anulable = id_plan_pago.ToString()
            lbl_fecha_reprog.Text = pp.fecha.ToString("d")
            lbl_num_cuota.Text = pp.num_cuotas
            lbl_seguro.Text = pp.seguro
            lbl_mantenimiento.Text = pp.mantenimiento_sus.ToString("F2")
            lbl_interes.Text = pp.interes_corriente.ToString("F2")
            lbl_interes_penal.Text = New parametro("tasa_mora").valor.ToString("F2")
            lbl_cuota_base.Text = pp.cuota_base.ToString("F2")
            lbl_fecha_inicio.Text = pp.fecha_inicio_plan.ToString("d") '("dd/mm/yyyy")
        Else
            panel_anular_reprogramacion.Visible = False
        End If
    End Sub
 
    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Session("id_plan_pago_anulable") = id_plan_pago_anulable
        Response.Redirect("~/recurso/caja/anulacion/anulacionReprogramacion.aspx")
    End Sub
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_plan_pago_anulable" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_anular_reprogramacion" runat="server" GroupingText="Anulación de la última reprogramación realizada">
    <table class="cajaIngresoTable">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contratoViewTdHorEnun">F. reprog.</td>
                        <td class="contratoViewTdHorEnun">Nº cuotas</td>
                        <td class="contratoViewTdHorEnun">Seguro desgr.<br />(% mes)</td>
                        <td class="contratoViewTdHorEnun">Mantenimiento<br /><asp:Label ID="lbl_mantenimiento_enun" runat="server" Text="($us mes)"></asp:Label></td>
                        <td class="contratoViewTdHorEnun">Interés corr.<br />(% anual)</td>
                        <td class="contratoViewTdHorEnun">Interés penal<br />(% mes)</td>
                        <td class="contratoViewTdHorEnun">Cuota mensual<br /><asp:Label ID="lbl_cuota_base_enun" runat="server" Text="($us)"></asp:Label></td>
                        <td class="contratoViewTdHorEnun">F.Inicio Plan</td>
                    </tr>
                    <tr>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha_reprog" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_num_cuota" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_seguro" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_mantenimiento" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_interes" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_interes_penal" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_cuota_base" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha_inicio" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="La última reprogramacion se puede anular"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Anular ULTIMA REPROGRAMACION" CommandArgument="0" />
            </td>
         </tr>
    </table>
</asp:Panel>

