<%@ Control Language="VB" ClassName="ingresoAnulacionVentaServicios" %>

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
        If servicio_vendido.PermitirAnular(id_contrato, Profile.id_usuario, Profile.entorno.id_rol) = True Then
            panel_anular_servicio.Visible = True
            Dim id_ultimo_servicio As Integer
            id_ultimo_servicio = servicio_vendido.IdUltimoServicioVendido(id_contrato)
            If id_ultimo_servicio > 0 Then
                Dim sv As New servicio_vendido(id_ultimo_servicio)
                lbl_fecha_venta.Text = sv.fecha.ToString("d")
                lbl_servicio.Text = New servicio(sv.id_servicio).nombre
                lbl_unidades.Text = sv.num_unidades.ToString()
                lbl_precio_total.Text = sv.precio_total.ToString("F2")
                
                Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)
                lbl_precio_total_enun.Text = "(" & codigo_moneda & ")"
            End If
        Else
            panel_anular_servicio.Visible = False
        End If
    End Sub
 
    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/anulacion/anulacionVentaServicios.aspx")
    End Sub
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_anular_servicio" runat="server"  GroupingText="Anulación de la venta de otros servicios">
    <table class="cajaIngresoTable" >
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contratoViewTdHorEnun"></td>
                        <td class="contratoViewTdHorEnun"></td>
                        <td class="contratoViewTdHorEnun">Fecha de venta</td>
                        <td class="contratoViewTdHorEnun">Servicio</td>
                        <td class="contratoViewTdHorEnun">No. unidades/<br />cuotas</td>
                        <td class="contratoViewTdHorEnun">Precio Total<br /><asp:Label ID="lbl_precio_total_enun" runat="server" Text="($us)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="contratoViewTdHorEnun">Último servicio vendido:</td>
                        <td class="contratoViewTdHorEnun" width="10px"></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha_venta" runat="server"></asp:Label></td>
                        <td class="contratoViewTdHorDato"><asp:Label ID="lbl_servicio" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_unidades" runat="server"></asp:Label></td>
                        <td class="gvCell1"><asp:Label ID="lbl_precio_total" runat="server"></asp:Label></td>
                   </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="Existen otros servicios vendidos sobre este contrato."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Anular alguna VENTA DE OTROS SERVICIOS" CommandArgument="0" />
            </td>
         </tr>
    </table>
</asp:Panel>