<%@ Control Language="C#" ClassName="clienteViewDireccion" %>

<script runat="server">
    public int id_cliente
    {
        set
        {
            cliente clienteObj = new cliente(value);
            lbl_domicilio_direccion.Text = clienteObj.domicilio_direccion;
            lbl_domicilio_fono.Text = clienteObj.domicilio_fono;
            lbl_domicilio_zona.Text = clienteObj.nombre_zona_domicilio;

            lbl_oficina_direccion.Text = clienteObj.oficina_direccion;
            lbl_oficina_fono.Text = clienteObj.oficina_fono;
            lbl_oficina_zona.Text = clienteObj.nombre_zona_oficina;

            lbl_lugar_cobro.Text = clienteObj.nombre_lugarcobro;
        }
    }

    public bool Visible_lugar_cobro { get { return lbl_lugar_cobro.Visible; } set { lbl_lugar_cobro_enun.Visible = value; lbl_lugar_cobro.Visible = value; } }
</script>
<table class="viewHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_direccion_enun" runat="server" Text="Dirección"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_fono_enun" runat="server" Text="Teléfono"></asp:Label></td>
        <td class="viewHorTdEnun"><asp:Label ID="lbl_zona_enun" runat="server" Text="Zona"></asp:Label></td>
    </tr>
    <tr>
        <td class="viewHorTdEnun1"><asp:Label ID="lbl_domicilio_enun" runat="server" Text="Domicilio:"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_domicilio_direccion" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_domicilio_fono" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_domicilio_zona" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="viewHorTdEnun1"><asp:Label ID="lbl_oficina_enun" runat="server" Text="Oficina:"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_oficina_direccion" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_oficina_fono" runat="server"></asp:Label></td>
        <td class="viewHorTdDato"><asp:Label ID="lbl_oficina_zona" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4" align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHorTdEnun1"><asp:Label ID="lbl_lugar_cobro_enun" runat="server" Text="Lugar de cobro:"></asp:Label></td>
                    <td class="formHorTdDato"><asp:Label ID="lbl_lugar_cobro" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>