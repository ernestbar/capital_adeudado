<%@ Control Language="C#" ClassName="servicioViewDato" %>

<script runat="server">
    public int id_servicio
    {
        set
        {
            servicio servicioObj = new servicio(value);
            lbl_codigo.Text = servicioObj.codigo;
            lbl_nombre.Text = servicioObj.nombre;
            lbl_valor.Text = servicioObj.valor_sus.ToString();
            cbx_varios.Checked  = servicioObj.varios;
            cbx_facturar.Checked = servicioObj.facturar;
            cbx_liquidacion.Checked = servicioObj.liquidacion;
            cbx_activo.Checked = servicioObj.activo;
        }
    }
</script>

<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_codigo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enum" runat="server" Text="Nombre del servicio:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_nombre" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_valor_enum" runat="server" Text="Valor $us:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_valor" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_varios_enum" runat="server" Text="Varios:"></asp:Label></td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_varios" runat="server" Enabled="false" /><asp:Label ID="lbl_varios"
                Text="Se puede pagar por varias unidades o cuotas" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_facturar_enum" runat="server" Text="Facturar:"></asp:Label></td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_facturar" runat="server" Enabled="false" /><asp:Label ID="lbl_facturar"
                Text="Se factura" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_liquidacion_enum" runat="server" Text="Liquidación:"></asp:Label></td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_liquidacion" runat="server" Enabled="false" /><asp:Label ID="lbl_liquidacion"
                Text="Parte de la liquidación de un contrato" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_activo_enum" runat="server" Text="Activo:"></asp:Label></td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Enabled="false" /><asp:Label ID="lbl_activo"
                Text="Servicio Activo" runat="server"></asp:Label></td>
    </tr>
</table>
