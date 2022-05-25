<%@ Control Language="VB" ClassName="ingresoPagoCapital" %>

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
        If pago.Permitir(id_contrato, Profile.id_usuario, Profile.entorno.id_rol, "pagoCapital") Then
            panel_ingreso.Visible = True
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/pagoCapital/Default.aspx")
    End Sub
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Pago Directo a Capital">
    <table class="cajaIngresoTable">
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="Puede realizar pagos directo a capital"></asp:Label>
            </td>
        </tr>
        <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Realizar pago DIRECTO A CAPITAL" CommandArgument="0" /></td></tr>
    </table>
</asp:Panel>