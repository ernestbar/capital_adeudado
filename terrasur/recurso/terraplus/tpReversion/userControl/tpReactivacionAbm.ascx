<%@ Control Language="C#" ClassName="tpReactivacionAbm" %>

<script runat="server">
    private int id_reversion { get { return int.Parse(lbl_id_reversion.Text); } set { lbl_id_reversion.Text = value.ToString(); } }

    public void Cargar(int Id_reversion)
    {
        id_reversion = Id_reversion;
        
        terrasur.terraplus.tp_reversion rObj = new terrasur.terraplus.tp_reversion(Id_reversion);

        lbl_fecha_reversion.Text = rObj.fecha.ToString("d");
        lbl_num_meses.Text = rObj.meses_incumplidos.ToString();
        lbl_motivo.Text = rObj.motivo_nombre;
    }

    public bool Reactivar()
    {
        terrasur.terraplus.tp_reversion rObj = new terrasur.terraplus.tp_reversion(id_reversion);
        if (rObj.Reactivar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
        {
            Msg1.Text = "La reactivación se realizó correctamente";
            return true;
        }
        else
        {
            Msg1.Text = "La reactivación NO se realizó correctamente";
            return false;
        }
    }
    
    
</script>
<asp:Label ID="lbl_id_reversion" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de reversión:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_fecha_reversion" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. meses incumplidos:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_num_meses" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Motivo de reversión:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_motivo" runat="server"></asp:Label>
        </td>
    </tr>
</table>