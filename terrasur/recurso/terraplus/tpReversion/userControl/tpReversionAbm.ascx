<%@ Control Language="C#" ClassName="tpReversionAbm" %>

<script runat="server">
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    
    
    public void CargarInsertar(int Id_contrato)
    {
        id_contrato = Id_contrato;
        
        terrasur.terraplus.tp_contrato cObj = new terrasur.terraplus.tp_contrato(Id_contrato);
        if (cObj.ultimo_id_pago > 0)
        {
            terrasur.terraplus.tp_pago pObj = new terrasur.terraplus.tp_pago(cObj.ultimo_id_pago);
            lbl_fecha_ultimo_pago.Text = pObj.fecha.ToString("d");
            lbl_mes_ultimo.Text = terrasur.terraplus.tp_pago.MesLiteral(pObj.mes_pago, pObj.mes_pago);
        }
        else
        {
            lbl_fecha_ultimo_pago.Text = "---";
            lbl_mes_ultimo.Text = "---";
        }
        lbl_monto_pagado.Text = cObj.cuotas_monto.ToString("N2");
        ddl_motivoreversion.DataBind();
    }

    public bool Insertar()
    {
        terrasur.terraplus.tp_reversion rObj = new terrasur.terraplus.tp_reversion(id_contrato, int.Parse(ddl_motivoreversion.SelectedValue));
        if (rObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
        {
            Msg1.Text = "La reversión se realizó correctamente";
            return true;
        }
        else
        {
            Msg1.Text = "La reversión NO se realizó correctamente";
            return false;
        }
    }
    
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de último pago:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_fecha_ultimo_pago" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Último mes pagado:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_mes_ultimo" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Monto pagado:</td>
        <td class="formTdDato">
            <asp:Label ID="lbl_monto_pagado" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Motivo de reversión:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_motivoreversion" runat="server" DataSourceID="ods_lista_motivos" DataValueField="id_motivoreversion" DataTextField="nombre">
            </asp:DropDownList>
            <%--[id_motivoreversion],[codigo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_motivos" runat="server" TypeName="terrasur.terraplus.tp_motivoReversion" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
