<%@ Control Language="C#" ClassName="tpDatosTerraPlus" %>

<script runat="server">
    public int id_contrato
    {
        get { return int.Parse(lbl_id_contrato.Text); }
        set { lbl_id_contrato.Text = value.ToString(); CargarDatosContrato(); }
    }
    public int id_cliente
    {
        get { return int.Parse(lbl_id_cliente.Text); }
        set
        {
            lbl_id_cliente.Text = value.ToString();
            int id_contrato_terraplus = terrasur.terraplus.tp_contrato.IdContratoPorCliente(value);
            if (id_contrato_terraplus > 0) { id_contrato = id_contrato_terraplus; }
            else { CargarDatosCliente(); }
        }
    }

    private void CargarDatosCliente()
    {
        cliente cliObj = new cliente(id_cliente);
        lbl_cliente.Text = cliObj.nombres + " " + cliObj.paterno + " " + cliObj.materno;
        lbl_ci.Text = cliObj.ci + " " + cliObj.codigo_lugarcedula;
        if (cliObj.fecha_nacimiento.Date == DateTime.Now.Date)
        {
            lbl_fecha_nacimiento_enun.Visible = false;
            lbl_fecha_nacimiento.Visible = false;
            //lbl_fecha_nacimiento.Text = "";
        }
        else
        {
            lbl_fecha_nacimiento_enun.Visible = true;
            lbl_fecha_nacimiento.Visible = true;
            int num_anios = 0; DateTime fechaAux = cliObj.fecha_nacimiento.Date.AddYears(1); while (fechaAux < DateTime.Now.Date) { num_anios += 1; fechaAux = fechaAux.AddYears(1); }
            lbl_fecha_nacimiento.Text = cliObj.fecha_nacimiento.ToString("d") + " (" + num_anios.ToString() + " años)";
        }
        lbl_contratos_lotes_enun.Visible = true;
        lbl_contratos_lotes.Visible = true;
        lbl_contratos_lotes.Text = terrasur.terraplus.tp_contrato.ListaContratosLotes_string(cliObj.id_cliente, false, true, true);

        lbl_num_contrato_terraplus.Text = "---";
        lbl_fecha_registro.Text = "";
        lbl_cuota_mensual_enun.Text = "";
        lbl_cuota_mensual.Text = "";
        lbl_contatos_terraplus_enun.Visible = true;
        lbl_contatos_terraplus.Visible = true;
        lbl_contatos_terraplus.Text = terrasur.terraplus.tp_contrato.ListaContratosTerraplus_string(cliObj.id_cliente, true, 0);


        lbl_estado.Text = "---";
        lbl_num_cuotas.Text = "";
        lbl_monto_pagado_enun.Text = "";
        lbl_monto_pagado.Text = "";

        lbl_fecha_registro_enun.Visible = false;
        lbl_fecha_registro.Visible = false;
        lbl_num_cuotas_enun.Visible = false;
        lbl_num_cuotas.Visible = false;
        lbl_fecha_ultimo_enun.Visible = false;
        lbl_fecha_ultimo.Visible = false;
        lbl_ultimo_mes_enun.Visible = false;
        lbl_ultimo_mes.Visible = false;
    }
    
    private void CargarDatosContrato()
    {
        terrasur.terraplus.tp_contrato c = new terrasur.terraplus.tp_contrato(id_contrato);
        lbl_cliente.Text = c.cliente_nombre;
        lbl_ci.Text = c.cliente_ci;
        if (c.cliente_fecha_nacimiento.Date == DateTime.Now.Date)
        {
            lbl_fecha_nacimiento_enun.Visible = false;
            lbl_fecha_nacimiento.Visible = false;
            //lbl_fecha_nacimiento.Text = "";
        }
        else
        {
            lbl_fecha_nacimiento_enun.Visible = true;
            lbl_fecha_nacimiento.Visible = true;
            int num_anios = 0; DateTime fechaAux = c.cliente_fecha_nacimiento.Date.AddYears(1); while (fechaAux < DateTime.Now.Date) { num_anios += 1; fechaAux = fechaAux.AddYears(1); }
            lbl_fecha_nacimiento.Text = c.cliente_fecha_nacimiento.ToString("d") + " (" + num_anios.ToString() + " años)";
        }
        if (c.num_contratos_lotes == 0)
        {
            lbl_contratos_lotes_enun.Visible = false;
            lbl_contratos_lotes.Visible = false;
        }
        else
        {
            lbl_contratos_lotes_enun.Visible = true;
            lbl_contratos_lotes.Visible = true;
            lbl_contratos_lotes.Text = terrasur.terraplus.tp_contrato.ListaContratosLotes_string(c.id_cliente, false, true, true);
        }

        lbl_num_contrato_terraplus.Text= c.numero;
        lbl_fecha_registro.Text = c.fecha.ToString("d");
        lbl_fecha_registro_enun.Visible = true;
        lbl_fecha_registro.Visible = true;

        terrasur.terraplus.tp_plan ppObj = new terrasur.terraplus.tp_plan(terrasur.terraplus.tp_plan.Actual(id_contrato));
        lbl_cuota_mensual_enun.Text = "Cuota mensual (" + ppObj.codigo_moneda + "):";
        lbl_cuota_mensual.Text = ppObj.monto.ToString("N2");
        
        if (c.num_contratos_terraplus <= 1)
        {
            lbl_contatos_terraplus_enun.Visible = false;
            lbl_contatos_terraplus.Visible = false;
        }
        else
        {
            lbl_contatos_terraplus_enun.Visible = true;
            lbl_contatos_terraplus.Visible = true;
            lbl_contatos_terraplus.Text = terrasur.terraplus.tp_contrato.ListaContratosTerraplus_string(c.id_cliente, true, c.id_contrato);
        }

        lbl_estado.Text = c.estado_nombre.ToUpper();
        lbl_num_cuotas.Text = c.cuotas_pagadas.ToString();
        lbl_monto_pagado_enun.Text = "Monto pagado (" + c.moneda_codigo + "):";
        lbl_monto_pagado.Text = c.cuotas_monto.ToString("N2");
        if (c.ultimo_id_pago == 0)
        {

            lbl_num_cuotas_enun.Visible = false;
            lbl_num_cuotas.Visible = false;
            lbl_fecha_ultimo_enun.Visible = false;
            lbl_fecha_ultimo.Visible = false;
            lbl_ultimo_mes_enun.Visible = false;
            lbl_ultimo_mes.Visible = false;
            //lbl_fecha_ultimo.Text = "";
            //lbl_ultimo_mes.Text = "";
        }
        else
        {
            lbl_num_cuotas_enun.Visible = true;
            lbl_num_cuotas.Visible = true;
            lbl_fecha_ultimo_enun.Visible = true;
            lbl_fecha_ultimo.Visible = true;
            lbl_ultimo_mes_enun.Visible = true;
            lbl_ultimo_mes.Visible = true;

            terrasur.terraplus.tp_pago p = new terrasur.terraplus.tp_pago(c.ultimo_id_pago);
            lbl_fecha_ultimo.Text = p.fecha.ToString("d");
            lbl_ultimo_mes.Text = terrasur.terraplus.tp_pago.StringMes(p.mes_pago, p.mes_pago);
        }
    }
</script>
<asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server" GroupingText="Datos del contrato TerraPlus">
                <table class="contratoDatosTable">
                    <tr>
                        <td colspan="3">
                            <table align="left">
                                <tr>
                                    <td class="contratoDatosTdNumEnun">Nº ctto. TerraPlus:</td>
                                    <td class="contratoDatosTdNumDato"><asp:Label ID="lbl_num_contrato_terraplus" runat="server" Font-Size=""></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdEstadoEnun">Cliente:</td>
                                    <td class="contratoDatosTdEstadoDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdEstadoEnun">Estado del Ctto.:</td>
                                    <td class="contratoDatosTdEstadoDato"><asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoDatosTdGrupo" valign="top">
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td class="contratoDatosTdEnun">C.I.:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_ci" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_fecha_nacimiento_enun" runat="server" Text="F.Nacim.:"></asp:Label></td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_fecha_nacimiento" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_contratos_lotes_enun" runat="server" Text="Cttos.Lotes::"></asp:Label></td>
                                    <td class="contratoDatosTdDato">
                                        <table cellpadding="0" cellspacing="0" width="250px"><tr><td><asp:Label ID="lbl_contratos_lotes" runat="server"></asp:Label></td></tr></table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="contratoDatosTdGrupo" valign="top">
                            <table>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_fecha_registro_enun" runat="server" Text="F.Registro:"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_fecha_registro" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_cuota_mensual_enun" runat="server" Text="Cuota mensual ($us):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_cuota_mensual" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_contatos_terraplus_enun" runat="server" Text="Cttos.TerraPlus:"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_contatos_terraplus" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td class="contratoDatosTdGrupo" valign="top">
                            <table>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_num_cuotas_enun" runat="server" Text="Nº meses pagados:"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_num_cuotas" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_monto_pagado_enun" runat="server" Text="Monto pagado ($us):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_monto_pagado" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_fecha_ultimo_enun" runat="server" Text="F.Último pago:"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_fecha_ultimo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_ultimo_mes_enun" runat="server" Text="Últ.Mes Pagado:"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_ultimo_mes" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
