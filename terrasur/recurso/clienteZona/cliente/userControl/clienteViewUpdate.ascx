<%@ Control Language="C#" ClassName="clienteViewUpdate" %>

<script runat="server">
    public int id_cliente
    {
        set
        {
            int id_usuario = 0;
            DateTime fecha = DateTime.Now;
            string nombre_usuario = "";
            cliente.UltimaModificacion(value, ref id_usuario, ref fecha, ref nombre_usuario);
            if (id_usuario > 0)
            {
                lbl_fecha.Text = fecha.ToString("F");
                lbl_usuario.Text = nombre_usuario;
            }
            else
            {
                    lbl_fecha.Text = "-----";
                    lbl_usuario.Text = "-----";
            }
        }
    }
</script>
<table class="viewHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="viewTdEnun">Fecha:</td>
        <td class="viewTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="viewTdEnun">Usuario:</td>
        <td class="viewTdDato"><asp:Label ID="lbl_usuario" runat="server"></asp:Label></td>
    </tr>
</table>
