<%@ Control Language="C#" ClassName="sParametrosVarios" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        txt_tolerancia.Attributes["onfocus"] = "this.select();";
        txt_tolerancia.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_tolerancia.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_tolerancia.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

        txt_minimo_sus.Attributes["onfocus"] = "this.select();";
        txt_minimo_sus.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_minimo_sus.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_minimo_sus.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

        txt_minimo_bs.Attributes["onfocus"] = "this.select();";
        txt_minimo_bs.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_minimo_bs.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_minimo_bs.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }

    public void Cargar()
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "view") == true)
        {
            panel_parametros_varios.Visible = true;

            ActivarDesactivarControles("anulacion", false, true);
            ActivarDesactivarControles("tolerancia", false, true);
            ActivarDesactivarControles("minimo_sus", false, true);
            ActivarDesactivarControles("minimo_bs", false, true);
        }
        else { panel_parametros_varios.Visible = false; }
    }

    
    protected void btn_anulacion_modificar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("anulacion", true, false);
    }
    protected void btn_anulacion_actualizar_Click(object sender, EventArgs e)
    {
        parametro p = new parametro("s_anulacion_num_dias_posterior");
        if (p.valor != decimal.Parse(txt_anulacion_num_dias.Text.Trim()))
        {
            p.valor = decimal.Parse(txt_anulacion_num_dias.Text.Trim());
            if (p.Actualizar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El parámetro se modificó correctamente";
                ActivarDesactivarControles("anulacion", false, true);
            }
            else { Msg1.Text = "El parámetro NO se modificó correctamente"; }
        }
        else { Msg1.Text = "El parámetro modificado es igual al anterior"; }
    }
    protected void btn_anulacion_cancelar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("anulacion", false, true);
    }


    protected void btn_tolerancia_modificar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("tolerancia", true, false);
    }
    protected void btn_tolerancia_actualizar_Click(object sender, EventArgs e)
    {
        parametro p = new parametro("s_margen_tolerancia_conversiones");
        if (p.valor != decimal.Parse(txt_tolerancia.Text.Trim()))
        {
            p.valor = decimal.Parse(txt_tolerancia.Text.Trim());
            if (p.Actualizar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El parámetro se modificó correctamente";
                ActivarDesactivarControles("tolerancia", false, true);
            }
            else { Msg1.Text = "El parámetro NO se modificó correctamente"; }
        }
        else { Msg1.Text = "El parámetro modificado es igual al anterior"; }
    }
    protected void btn_tolerancia_cancelar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("tolerancia", false, true);
    }



    protected void btn_minimo_sus_modificar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("minimo_sus", true, false);
    }
    protected void btn_minimo_sus_actualizar_Click(object sender, EventArgs e)
    {
        parametro p = new parametro("s_cobranza_monto_minimo_sus");
        if (p.valor != decimal.Parse(txt_minimo_sus.Text.Trim()))
        {
            p.valor = decimal.Parse(txt_minimo_sus.Text.Trim());
            if (p.Actualizar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El parámetro se modificó correctamente";
                ActivarDesactivarControles("minimo_sus", false, true);
            }
            else { Msg1.Text = "El parámetro NO se modificó correctamente"; }
        }
        else { Msg1.Text = "El parámetro modificado es igual al anterior"; }
    }
    protected void btn_minimo_sus_cancelar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("minimo_sus", false, true);
    }


    protected void btn_minimo_bs_modificar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("minimo_bs", true, false);
    }
    protected void btn_minimo_bs_actualizar_Click(object sender, EventArgs e)
    {
        parametro p = new parametro("s_cobranza_monto_minimo_bs");
        if (p.valor != decimal.Parse(txt_minimo_bs.Text.Trim()))
        {
            p.valor = decimal.Parse(txt_minimo_bs.Text.Trim());
            if (p.Actualizar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El parámetro se modificó correctamente";
                ActivarDesactivarControles("minimo_bs", false, true);
            }
            else { Msg1.Text = "El parámetro NO se modificó correctamente"; }
        }
        else { Msg1.Text = "El parámetro modificado es igual al anterior"; }
    }
    protected void btn_minimo_bs_cancelar_Click(object sender, EventArgs e)
    {
        ActivarDesactivarControles("minimo_bs", false, true);
    }
    
    
    
    
    private void ActivarDesactivarControles(string tipo, bool modificar, bool inicial)
    {
        switch (tipo)
        {
            case "anulacion":
                if (inicial) { txt_anulacion_num_dias.Text = new parametro("s_anulacion_num_dias_posterior").valor.ToString(); }
                txt_anulacion_num_dias.Enabled = modificar;
                if (modificar) { txt_anulacion_num_dias.Focus(); }
                if (inicial) { btn_anulacion_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "anulacion"); }
                //if (inicial) { btn_anulacion_modificar.Visible = true; }
                else { btn_anulacion_modificar.Visible = modificar.Equals(false); }
                btn_anulacion_actualizar.Visible = modificar;
                btn_anulacion_cancelar.Visible = modificar;
                break;
            case "tolerancia":
                if (inicial) { txt_tolerancia.Text = new parametro("s_margen_tolerancia_conversiones").valor.ToString(); }
                txt_tolerancia.Enabled = modificar;
                if (modificar) { txt_tolerancia.Focus(); }
                if (inicial) { btn_tolerancia_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "tolerancia"); }
                //if (inicial) { btn_tolerancia_modificar.Visible = true; }
                else { btn_tolerancia_modificar.Visible = modificar.Equals(false); }
                btn_tolerancia_actualizar.Visible = modificar;
                btn_tolerancia_cancelar.Visible = modificar;
                break;
            case "minimo_sus":
                if (inicial) { txt_minimo_sus.Text = new parametro("s_cobranza_monto_minimo_sus").valor.ToString(); }
                txt_minimo_sus.Enabled = modificar;
                if (modificar) { txt_minimo_sus.Focus(); }
                if (inicial) { btn_minimo_sus_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "minimo_sus"); }
                //if (inicial) { btn_minimo_sus_modificar.Visible = true; }
                else { btn_minimo_sus_modificar.Visible = modificar.Equals(false); }
                btn_minimo_sus_actualizar.Visible = modificar;
                btn_minimo_sus_cancelar.Visible = modificar;
                break;
            case "minimo_bs":
                if (inicial) { txt_minimo_bs.Text = new parametro("s_cobranza_monto_minimo_bs").valor.ToString(); }
                txt_minimo_bs.Enabled = modificar;
                if (modificar) { txt_minimo_bs.Focus(); }
                if (inicial) { btn_minimo_bs_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "minimo_bs"); }
                //if (inicial) { btn_minimo_bs_modificar.Visible = true; }
                else { btn_minimo_bs_modificar.Visible = modificar.Equals(false); }
                btn_minimo_bs_actualizar.Visible = modificar;
                btn_minimo_bs_cancelar.Visible = modificar;
                break;
        }
    }

</script>

<asp:Panel ID="panel_parametros_varios" runat="server" GroupingText="Parámetros para cobranza con Síntesis">
    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdMsg" colspan="3">
                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                <asp:ValidationSummary ID="vs_parametro" runat="server" DisplayMode="List" ValidationGroup="parametro" />
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">
                <asp:Label ID="lbl_anulacion_dias_enun" runat="server" Text="Permitir anulación en los siguientes:" ToolTip="Es el número de días posterior a la cobranza en los cuales se permite a Síntesis realizar la anulación de la cobranza realizada"></asp:Label>
            </td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_anulacion_num_dias" runat="server" SkinID="txtSingleLine50" MaxLength="1" Enabled="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_anulacion_num_dias" runat="server" ControlToValidate="txt_anulacion_num_dias" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rav_anulacion_num_dias" runat="server" Type="Integer" MinimumValue="0" MaximumValue="9" ControlToValidate="txt_anulacion_num_dias" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="El número introducido debe ser un entero entre 0 y 9"></asp:RangeValidator>
                <asp:Label ID="lbl_anulacion_dias_enun2" runat="server" Text=" días"></asp:Label>
            </td>
            <td align="left">
                <asp:Button ID="btn_anulacion_modificar" runat="server" Text="Modificar" CausesValidation="false" OnClick="btn_anulacion_modificar_Click" />
                <asp:Button ID="btn_anulacion_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="parametro" Visible="false" OnClick="btn_anulacion_actualizar_Click" />
                <asp:Button ID="btn_anulacion_cancelar" runat="server" Text="Cancelar/Volver" CausesValidation="false" Visible="false" OnClick="btn_anulacion_cancelar_Click" />
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">
                <asp:Label ID="lbl_tolerancia_enun" runat="server" Text="Tolerancia para la conversión de moneda:" ToolTip="Es el margen de tolerancia admitido para validar las conversiones, de Bs a $us y viceversa, realizadas por Síntesis"></asp:Label>
            </td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_tolerancia" runat="server" SkinID="txtSingleLine50" MaxLength="4" Enabled="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_tolerancia" runat="server" ControlToValidate="txt_tolerancia" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_tolerancia" runat="server" Type="Double" MinimumValue="0" MaximumValue="1" ControlToValidate="txt_tolerancia" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="El número introducido debe estar entre 0,00 y 1,00"></asp:RangeValidator>
            </td>
            <td align="left">
                <asp:Button ID="btn_tolerancia_modificar" runat="server" Text="Modificar" CausesValidation="false" OnClick="btn_tolerancia_modificar_Click" />
                <asp:Button ID="btn_tolerancia_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="parametro" Visible="false" OnClick="btn_tolerancia_actualizar_Click" />
                <asp:Button ID="btn_tolerancia_cancelar" runat="server" Text="Cancelar/Volver" CausesValidation="false" Visible="false" OnClick="btn_tolerancia_cancelar_Click" />
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">
                <asp:Label ID="lbl_minimo_sus_enun" runat="server" Text="Monto mínimo de pago a capital en $us:" ToolTip="Es el monto mínimo que Síntesis puede cobrar en un pago directo a capital de un contrato en Dólares"></asp:Label>
            </td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_minimo_sus" runat="server" SkinID="txtSingleLine50" MaxLength="6" Enabled="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_minimo_sus" runat="server" ControlToValidate="txt_minimo_sus" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_minimo_sus" runat="server" Type="Double" MinimumValue="0,01" MaximumValue="9999" ControlToValidate="txt_minimo_sus" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="El número introducido debe estar entre 0,01 y 9999"></asp:RangeValidator>
                <asp:Label ID="lbl_minimo_sus_enun2" runat="server" Text="$us" ToolTip="Es el monto mínimo que Síntesis puede cobrar en un pago directo a capital de un contrato en Dólares"></asp:Label>
            </td>
            <td align="left">
                <asp:Button ID="btn_minimo_sus_modificar" runat="server" Text="Modificar" CausesValidation="false" OnClick="btn_minimo_sus_modificar_Click" />
                <asp:Button ID="btn_minimo_sus_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="parametro" Visible="false" OnClick="btn_minimo_sus_actualizar_Click" />
                <asp:Button ID="btn_minimo_sus_cancelar" runat="server" Text="Cancelar/Volver" CausesValidation="false" Visible="false" OnClick="btn_minimo_sus_cancelar_Click" />
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">
                <asp:Label ID="lbl_minimo_bs_enun" runat="server" Text="Monto mínimo de pago a capital en Bs:" ToolTip="Es el monto mínimo que Síntesis puede cobrar en un pago directo a capital de un contrato en Bolivianos"></asp:Label>
            </td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_minimo_bs" runat="server" SkinID="txtSingleLine50" MaxLength="6" Enabled="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_minimo_bs" runat="server" ControlToValidate="txt_minimo_bs" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_minimo_bs" runat="server" Type="Double" MinimumValue="0,01" MaximumValue="9999" ControlToValidate="txt_minimo_bs" Display="Dynamic" ValidationGroup="parametro" Text="*" ErrorMessage="El número introducido debe estar entre 0,01 y 9999"></asp:RangeValidator>
                <asp:Label ID="lbl_minimo_bs_enun2" runat="server" Text="Bs" ToolTip="Es el monto mínimo que Síntesis puede cobrar en un pago directo a capital de un contrato en Bolivianos"></asp:Label>
            </td>
            <td align="left">
                <asp:Button ID="btn_minimo_bs_modificar" runat="server" Text="Modificar" CausesValidation="false" OnClick="btn_minimo_bs_modificar_Click" />
                <asp:Button ID="btn_minimo_bs_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="parametro" Visible="false" OnClick="btn_minimo_bs_actualizar_Click" />
                <asp:Button ID="btn_minimo_bs_cancelar" runat="server" Text="Cancelar/Volver" CausesValidation="false" Visible="false" OnClick="btn_minimo_bs_cancelar_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>