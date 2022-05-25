<%@ Control Language="C#" ClassName="tParametroAbm" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_monto.Attributes["onfocus"] = "this.select();";
        txt_monto.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }

    public void Cargar()
    {
        HabilitarControles_monto(false);
        HabilitarControles_restriccion(false);
        HabilitarControles_reversion(false);
        HabilitarControles_consecutivo(false);
        HabilitarControles_reactivacion_caja(false);
        HabilitarControles_reactivacion_marketing(false);
        HabilitarControles_reactivacion_num(false);

        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpParametro", "update") == false)
        {
            lb_monto_change.Visible = false;
            lb_restriccion_change.Visible = false;
            lb_reversion_change.Visible = false;
            lb_consecutivo_change.Visible = false;
            lb_reactivacion_caja_change.Visible = false;
            lb_reactivacion_marketing_change.Visible = false;
            lb_reactivacion_num_change.Visible = false;
        }
    }


    protected void lb_monto_change_Click(object sender, EventArgs e) { HabilitarControles_monto(true); }
    protected void lb_monto_cancel_Click(object sender, EventArgs e) { HabilitarControles_monto(false); }
    protected void lb_monto_update_Click(object sender, EventArgs e)
    {
        bool correcto = true;

        parametro pMonto = new parametro("tp_monto");
        if (pMonto.valor != decimal.Parse(txt_monto.Text.Trim()))
        {
            pMonto.valor = decimal.Parse(txt_monto.Text.Trim());
            if (pMonto.Actualizar(Profile.id_usuario)) { Msg1.Text = "El monto mensual se actualizó correctamente"; }
            else { Msg1.Text = "El monto mensual NO se actualizó correctamente"; correcto = false; }
        }
        else { Msg1.Text = "El monto mensual es igual al anterior"; }

        parametro pMoneda = new parametro("tp_moneda");
        if (pMoneda.valor != decimal.Parse(rbl_moneda.SelectedValue) && correcto == true)
        {
            pMoneda.valor = decimal.Parse(rbl_moneda.SelectedValue);
            if (pMoneda.Actualizar(Profile.id_usuario)) { Msg1.Text = "La moneda del monto mensual se actualizó correctamente"; }
            else { Msg1.Text = "La moneda del monto mensual NO se actualizó correctamente"; correcto = false; }
        }

        if (correcto) { HabilitarControles_monto(false); }
    }

    protected void lb_restriccion_change_Click(object sender, EventArgs e) { HabilitarControles_restriccion(true); }
    protected void lb_restriccion_cancel_Click(object sender, EventArgs e) { HabilitarControles_restriccion(false); }
    protected void lb_restriccion_update_Click(object sender, EventArgs e)
    {
        parametro pRestriccion = new parametro("tp_meses_restriccion");
        if (pRestriccion.valor != decimal.Parse(txt_meses_restriccion.Text.Trim()))
        {
            pRestriccion.valor = decimal.Parse(txt_meses_restriccion.Text.Trim());
            if (pRestriccion.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El número de meses de restricción inicial se actualizó correctamente";
                HabilitarControles_restriccion(false);
            }
            else { Msg1.Text = "El número de meses de restricción inicial NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El número de meses de restricción inicial es igual al anterior"; }
    }

    protected void lb_reversion_change_Click(object sender, EventArgs e) { HabilitarControles_reversion(true); }
    protected void lb_reversion_cancel_Click(object sender, EventArgs e) { HabilitarControles_reversion(false); }
    protected void lb_reversion_update_Click(object sender, EventArgs e)
    {
        parametro pReversion = new parametro("tp_meses_reversion");
        if (pReversion.valor != decimal.Parse(txt_meses_reversion.Text.Trim()))
        {
            pReversion.valor = decimal.Parse(txt_meses_reversion.Text.Trim());
            if (pReversion.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El número de meses para revertir el contrato se actualizó correctamente";
                HabilitarControles_reversion(false);
            }
            else { Msg1.Text = "El número de meses para revertir el contrato NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El número de meses para revertir el contrato es igual al anterior"; }
    }

    protected void lb_consecutivo_change_Click(object sender, EventArgs e) { HabilitarControles_consecutivo(true); }
    protected void lb_consecutivo_cancel_Click(object sender, EventArgs e) { HabilitarControles_consecutivo(false); }
    protected void lb_consecutivo_update_Click(object sender, EventArgs e)
    {
        parametro pConsecutivo = new parametro("tp_meses_consecutivo");
        if (pConsecutivo.valor != decimal.Parse(txt_meses_consecutivo.Text.Trim()))
        {
            pConsecutivo.valor = decimal.Parse(txt_meses_consecutivo.Text.Trim());
            if (pConsecutivo.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El número de meses de pago consecutivo se actualizó correctamente";
                HabilitarControles_consecutivo(false);
            }
            else { Msg1.Text = "El número de meses de pago consecutivo NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El número de meses de pago consecutivo es igual al anterior"; }
    }

    protected void lb_reactivacion_caja_change_Click(object sender, EventArgs e) { HabilitarControles_reactivacion_caja(true); }
    protected void lb_reactivacion_caja_cancel_Click(object sender, EventArgs e) { HabilitarControles_reactivacion_caja(false); }
    protected void lb_reactivacion_caja_update_Click(object sender, EventArgs e)
    {
        parametro pReactivacionCaja = new parametro("tp_reactivacion_meses_caja");
        if (pReactivacionCaja.valor != decimal.Parse(txt_reactivacion_meses_caja.Text.Trim()))
        {
            pReactivacionCaja.valor = decimal.Parse(txt_reactivacion_meses_caja.Text.Trim());
            if (pReactivacionCaja.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El número de meses de incumplimiento para permitir la reactivación en Caja se actualizó correctamente";
                HabilitarControles_reactivacion_caja(false);
            }
            else { Msg1.Text = "El número de meses de incumplimiento para permitir la reactivación en Caja NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El número de meses de incumplimiento para permitir la reactivación en Caja es igual al anterior"; }
    }

    protected void lb_reactivacion_marketing_change_Click(object sender, EventArgs e) { HabilitarControles_reactivacion_marketing(true); }
    protected void lb_reactivacion_marketing_cancel_Click(object sender, EventArgs e) { HabilitarControles_reactivacion_marketing(false); }
    protected void lb_reactivacion_marketing_update_Click(object sender, EventArgs e)
    {
        parametro pReactivacionMarketing = new parametro("tp_reactivacion_meses_marketing");
        if (pReactivacionMarketing.valor != decimal.Parse(txt_reactivacion_meses_marketing.Text.Trim()))
        {
            pReactivacionMarketing.valor = decimal.Parse(txt_reactivacion_meses_marketing.Text.Trim());
            if (pReactivacionMarketing.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El número de meses de incumplimiento para permitir la reactivación en Marketing se actualizó correctamente";
                HabilitarControles_reactivacion_marketing(false);
            }
            else { Msg1.Text = "El número de meses de incumplimiento para permitir la reactivación en Marketing NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El número de meses de incumplimiento para permitir la reactivación en Marketing es igual al anterior"; }
    }

    protected void lb_reactivacion_num_change_Click(object sender, EventArgs e) { HabilitarControles_reactivacion_num(true); }
    protected void lb_reactivacion_num_cancel_Click(object sender, EventArgs e) { HabilitarControles_reactivacion_num(false); }
    protected void lb_reactivacion_num_update_Click(object sender, EventArgs e)
    {
        parametro pReactivacionNum = new parametro("tp_reactivacion_num_maximo");
        if (pReactivacionNum.valor != decimal.Parse(txt_reactivacion_num_maximo.Text.Trim()))
        {
            pReactivacionNum.valor = decimal.Parse(txt_reactivacion_num_maximo.Text.Trim());
            if (pReactivacionNum.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El número de reactivaciones admitidas se actualizó correctamente";
                HabilitarControles_reactivacion_num(false);
            }
            else { Msg1.Text = "El número de reactivaciones admitidas NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El número de reactivaciones admitidas es igual al anterior"; }
    }
    
    
    
    private void HabilitarControles_monto(bool Habilitar)
    {
        if (Habilitar == true) { txt_monto.Focus(); }
        else
        {
            txt_monto.Text = (new parametro("tp_monto")).valor.ToString("N2");
            rbl_moneda.SelectedValue = (new parametro("tp_moneda")).valor.ToString("N0");
            //txt_monto.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpParametro", "monto");
            //rbl_moneda.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpParametro", "monto");
        }
        txt_monto.Enabled = Habilitar;
        rbl_moneda.Enabled = Habilitar;
        lb_monto_change.Visible = Habilitar.Equals(false);
        lb_monto_update.Visible = Habilitar;
        lb_monto_cancel.Visible = Habilitar;
    }
    private void HabilitarControles_restriccion(bool Habilitar)
    {
        if (Habilitar == true) { txt_meses_restriccion.Focus(); }
        else { txt_meses_restriccion.Text = (new parametro("tp_meses_restriccion")).valor.ToString("N0"); }

        txt_meses_restriccion.Enabled = Habilitar;
        lb_restriccion_change.Visible = Habilitar.Equals(false);
        lb_restriccion_update.Visible = Habilitar;
        lb_restriccion_cancel.Visible = Habilitar;
    }
    private void HabilitarControles_reversion(bool Habilitar)
    {
        if (Habilitar == true) { txt_meses_reversion.Focus(); }
        else { txt_meses_reversion.Text = (new parametro("tp_meses_reversion")).valor.ToString("N0"); }

        txt_meses_reversion.Enabled = Habilitar;
        lb_reversion_change.Visible = Habilitar.Equals(false);
        lb_reversion_update.Visible = Habilitar;
        lb_reversion_cancel.Visible = Habilitar;
    }
    private void HabilitarControles_consecutivo(bool Habilitar)
    {
        if (Habilitar == true) { txt_meses_consecutivo.Focus(); }
        else { txt_meses_consecutivo.Text = (new parametro("tp_meses_consecutivo")).valor.ToString("N0"); }

        txt_meses_consecutivo.Enabled = Habilitar;
        lb_consecutivo_change.Visible = Habilitar.Equals(false);
        lb_consecutivo_update.Visible = Habilitar;
        lb_consecutivo_cancel.Visible = Habilitar;
    }
    private void HabilitarControles_reactivacion_caja(bool Habilitar)
    {
        if (Habilitar == true) { txt_reactivacion_meses_caja.Focus(); }
        else { txt_reactivacion_meses_caja.Text = (new parametro("tp_reactivacion_meses_caja")).valor.ToString("N0"); }

        txt_reactivacion_meses_caja.Enabled = Habilitar;
        lb_reactivacion_caja_change.Visible = Habilitar.Equals(false);
        lb_reactivacion_caja_update.Visible = Habilitar;
        lb_reactivacion_caja_cancel.Visible = Habilitar;
    }
    private void HabilitarControles_reactivacion_marketing(bool Habilitar)
    {
        if (Habilitar == true) { txt_reactivacion_meses_marketing.Focus(); }
        else { txt_reactivacion_meses_marketing.Text = (new parametro("tp_reactivacion_meses_marketing")).valor.ToString("N0"); }

        txt_reactivacion_meses_marketing.Enabled = Habilitar;
        lb_reactivacion_marketing_change.Visible = Habilitar.Equals(false);
        lb_reactivacion_marketing_update.Visible = Habilitar;
        lb_reactivacion_marketing_cancel.Visible = Habilitar;
    }
    private void HabilitarControles_reactivacion_num(bool Habilitar)
    {
        if (Habilitar == true) { txt_reactivacion_num_maximo.Focus(); }
        else { txt_reactivacion_num_maximo.Text = (new parametro("tp_reactivacion_num_maximo")).valor.ToString("N0"); }

        txt_reactivacion_num_maximo.Enabled = Habilitar;
        lb_reactivacion_num_change.Visible = Habilitar.Equals(false);
        lb_reactivacion_num_update.Visible = Habilitar;
        lb_reactivacion_num_cancel.Visible = Habilitar;
    }


</script>
<table cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td>
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_terraplus" runat="server" DisplayMode="List" ValidationGroup="terraplus" />
        </td>
    </tr>
    <tr>
        <td>
            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formTdEnun">Monto mensual:</td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_monto" runat="server" DefaultButton="lb_monto_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_monto" runat="server" Enabled="false" SkinID="txtSingleLine50" MaxLength="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir monto mensual"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="terraplus" Type="Double" MinimumValue="0,01" MaximumValue="9999" Text="*" ErrorMessage="El monto debe estar entre 0,01 y 9999"></asp:RangeValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbl_moneda" runat="server" Enabled="false" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Text="$us" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Bs" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_monto_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_monto_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_monto_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_monto_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_monto_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_monto_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Nro. meses de restricción inicial:</td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_restriccion" runat="server" DefaultButton="lb_restriccion_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_meses_restriccion" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_meses_restriccion" runat="server" ControlToValidate="txt_meses_restriccion" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses de restricción inicial"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_meses_restriccion" runat="server" ControlToValidate="txt_meses_restriccion" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="0" MaximumValue="60" Text="*" ErrorMessage="El número de meses de restricción inicial debe estar entre 0 y 60"></asp:RangeValidator>
                                    </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_restriccion_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_restriccion_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_restriccion_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_restriccion_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_restriccion_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_restriccion_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formTdEnun">Nro. meses para resolver (revertir) el contrato:</td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_reversion" runat="server" DefaultButton="lb_reversion_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_meses_reversion" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_meses_reversion" runat="server" ControlToValidate="txt_meses_reversion" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses para resolver (revertir) el contrato"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_meses_reversion" runat="server" ControlToValidate="txt_meses_reversion" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1" MaximumValue="12" Text="*" ErrorMessage="El número de meses para resolver (revertir) el contrato debe estar entre 1 y 12"></asp:RangeValidator>
                                    </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reversion_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reversion_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reversion_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_reversion_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reversion_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reversion_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun"><asp:Label ID="lbl_meses_consecutivo_enun" runat="server" Text="Nro. meses de pago consecutivo para acceder al servicio:"></asp:Label></td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_consecutivo" runat="server" DefaultButton="lb_consecutivo_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_meses_consecutivo" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_meses_consecutivo" runat="server" ControlToValidate="txt_meses_consecutivo" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses de pago consecutivo"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_meses_consecutivo" runat="server" ControlToValidate="txt_meses_consecutivo" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="0" MaximumValue="12" Text="*" ErrorMessage="El número de meses de pago consecutivo debe estar entre 0 y 12"></asp:RangeValidator>
                                    </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_consecutivo_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_consecutivo_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_consecutivo_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_consecutivo_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_consecutivo_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_consecutivo_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Nro. meses de incumplimiento para permitir la reactivación en Caja:</td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_reactivacion_caja" runat="server" DefaultButton="lb_reactivacion_caja_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_reactivacion_meses_caja" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_reactivacion_meses_caja" runat="server" ControlToValidate="txt_reactivacion_meses_caja" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses de incumplimiento para permitir la reactivación en Caja"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_reactivacion_meses_caja" runat="server" ControlToValidate="txt_reactivacion_meses_caja" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1" MaximumValue="12" Text="*" ErrorMessage="El número de meses para la reactivación en Caja debe estar entre 1 y 12"></asp:RangeValidator>
                                    </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_caja_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reactivacion_caja_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_caja_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_reactivacion_caja_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_caja_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reactivacion_caja_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Nro. meses de incumplimiento para permitir la reactivación en Marketing:</td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_reactivacion_marketing" runat="server" DefaultButton="lb_reactivacion_marketing_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_reactivacion_meses_marketing" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_reactivacion_meses_marketing" runat="server" ControlToValidate="txt_reactivacion_meses_marketing" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses de incumplimiento para permitir la reactivación en Marketing"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_reactivacion_meses_marketing" runat="server" ControlToValidate="txt_reactivacion_meses_marketing" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1" MaximumValue="12" Text="*" ErrorMessage="El número de meses para la reactivación en Marketing debe estar entre 1 y 12"></asp:RangeValidator>
                                    </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_marketing_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reactivacion_marketing_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_marketing_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_reactivacion_marketing_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_marketing_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reactivacion_marketing_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Nro. reactivaciones admitidas:</td>
                    <td class="formTdDato">
                        <asp:Panel ID="panel_reactivacion_num" runat="server" DefaultButton="lb_reactivacion_num_update">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txt_reactivacion_num_maximo" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_reactivacion_num_maximo" runat="server" ControlToValidate="txt_reactivacion_num_maximo" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de reactivaciones admitidas"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_reactivacion_num_maximo" runat="server" ControlToValidate="txt_reactivacion_num_maximo" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1" MaximumValue="12" Text="*" ErrorMessage="El número de reactivaciones admitidas debe estar entre 1 y 12"></asp:RangeValidator>
                                   </td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_num_change" runat="server" Text="Modificar" Visible="true" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reactivacion_num_change_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_num_update" runat="server" Text="Actualizar" Visible="false" ValidationGroup="terraplus" CausesValidation="true" OnClick="lb_reactivacion_num_update_Click"></asp:LinkButton></td>
                                    <td>&nbsp;<asp:LinkButton ID="lb_reactivacion_num_cancel" runat="server" Text="Cancelar" Visible="false" ValidationGroup="terraplus" CausesValidation="false" OnClick="lb_reactivacion_num_cancel_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
 
            </table>
        </td>
    </tr>
</table>
