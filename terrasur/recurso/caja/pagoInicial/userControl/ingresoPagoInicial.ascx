<%@ Control Language="VB" ClassName="ingresoPagoInicial" %>

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
        If pago.Permitir(id_contrato, Profile.id_usuario, Profile.entorno.id_rol, "pagoInicial") Then
            panel_ingreso.Visible = True
            Dim c As New contrato(id_contrato)
            Dim fecha_limite As Date = c.fecha.AddHours(Convert.ToDouble(New parametro("plazo_preasignacion").valor))
            lbl_monto.Text = c.cuota_inicial.ToString & " " & c.codigo_moneda
            lbl_fecha.Text = fecha_limite.ToString("F")
            lbl_fecha_limite.Text = "La cuota inicial debe ser pagada hasta el: " & fecha_limite.ToString("F")
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/pagoInicial/Default.aspx")
    End Sub
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Cuota Inicial">
    <table class="cajaIngresoTable">
        <tr>
            <td class="cajaIngresoTdContenido">
                <table>
                    <tr>
                        <td class="cajaIngresoTdEnun">Monto:</td>
                        <td class="cajaIngresoTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="cajaIngresoTdEnun">Fecha límite de pago:</td>
                        <td class="cajaIngresoTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_fecha_limite" runat="server" SkinID="lbl_CajaIngresoMensaje"></asp:Label>
            </td>
        </tr>
        <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Pagar CUOTA INICIAL" CommandArgument="0" /></td></tr>
    </table>
</asp:Panel>