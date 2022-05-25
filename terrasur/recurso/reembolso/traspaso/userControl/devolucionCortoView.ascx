<%@ Control Language="C#" ClassName="devolucionCortoView" %>

<script runat="server">
    public int id_reembolso
    {
        set
        {
            terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(value);
            lbl_num_contrato.Text = rObj.num_contrato;
            lbl_producto.Text = rObj.producto;
            lbl_cliente.Text = terrasur.traspaso.cliente_reembolso.Lista_string(rObj.id_reembolso, false).Replace(",", "</br>");
            lbl_monto_enun.Text = "Monto de devolución (" + rObj.codigo_moneda + "):";
            lbl_monto.Text = rObj.monto.ToString("N2");
        }
    }
</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº contrato:</td>
        <td class="formTdDato"><asp:Label ID="lbl_num_contrato" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">Lote:</td>
        <td class="formTdDato"><asp:Label ID="lbl_producto" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">Cliente(s):</td>
        <td class="formTdDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto devolución:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
    </tr>
</table>