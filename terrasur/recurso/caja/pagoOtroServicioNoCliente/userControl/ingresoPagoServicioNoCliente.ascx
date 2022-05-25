<%@ Control Language="VB" ClassName="ingresoPagoServicioNoCliente" %>

<script runat="server">
   Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("entrar") = 1
        Response.Redirect("~/recurso/caja/pagoOtroServicioNoCliente/Default.aspx")
    End Sub
</script>

<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Pago / compra de Servicios a Cliente Transitorio"> 
    <table class="cajaIngresoTable">
        <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="SERVICIOS A CLIENTE TRANSITORIO" CommandArgument="0" /></td></tr>
    </table>
</asp:Panel>