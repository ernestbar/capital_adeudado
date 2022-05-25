<%@ Control Language="C#" ClassName="tpContratoAbm" %>

<script runat="server">
    private int id_cliente { get { return int.Parse(lbl_id_cliente.Text); } set { lbl_id_cliente.Text = value.ToString(); } }
    private int id_contrato_terraplus { get { return int.Parse(lbl_id_contrato_terraplus.Text); } set { lbl_id_contrato_terraplus.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_monto.Attributes["onfocus"] = "this.select();";
        txt_monto.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }

    private bool ConNroContrato
    {
        get { return lbl_num_contrato_enun.Visible; }
        set
        {
            lbl_num_contrato_enun.Visible = value;
            txt_num_contrato.Visible = value;
            rfv_num_contrato.Enabled = value;
            rv_num_contrato.Enabled = value;
        }
    }

    public void CargarInsertar(int Id_cliente)
    {
        id_cliente = Id_cliente;

        ConNroContrato = true;
        txt_num_contrato.Text = "";
        txt_monto.Text = (new parametro("tp_monto")).valor.ToString("N2");
        rbl_moneda.SelectedValue = Convert.ToInt32((new parametro("tp_moneda")).valor).ToString();
        rbl_moneda.Enabled = true;
        
        txt_meses_restriccion.Text = Convert.ToInt32((new parametro("tp_meses_restriccion")).valor).ToString();
        lbl_fecha_referencia.Text = DateTime.Now.ToString("d"); lbl_num_meses_antes.Text = "0"; lbl_num_meses_despues.Text = "1";
        ddl_mes_inicio_plan.DataBind();
        txt_meses_reversion.Text = Convert.ToInt32((new parametro("tp_meses_reversion")).valor).ToString();
        txt_meses_consecutivo.Text = Convert.ToInt32((new parametro("tp_meses_consecutivo")).valor).ToString();

        txt_monto.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "definir_monto");
        rbl_moneda.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "definir_monto");
        //if (rbl_moneda.Enabled) { rbl_moneda.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "definir_monto"); }
        txt_meses_restriccion.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "definir_meses_restriccion");
        txt_meses_reversion.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "definir_meses_reversion");
        txt_meses_consecutivo.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "definir_meses_consecutivo");

        //lbl_meses_consecutivo_enun.Visible = false;
        //txt_meses_consecutivo.Visible = false;
        rfv_meses_consecutivo.Enabled = false;
        rv_meses_consecutivo.Enabled = false;

        txt_num_contrato.Focus();
    }

    private bool VerificarInsertar()
    {
        bool correcto = true;
        if (terrasur.terraplus.tp_contrato.IdContratoPorCliente(id_cliente) > 0)
        {
            Msg1.Text = "El cliente ya tienen un contrato TerraPlus activo";
            correcto = false;
        }
        if (terrasur.terraplus.tp_contrato.IdContratoPorNumero(txt_num_contrato.Text.Trim()) > 0)
        {
            Msg1.Text = "El número de contrato (" + txt_num_contrato.Text.Trim() + ") ya fue utilizado";
            correcto = false;
        }
        return correcto;
    }

    public bool Insertar()
    {
        if (VerificarInsertar())
        {
            terrasur.terraplus.tp_contrato cObj = new terrasur.terraplus.tp_contrato(id_cliente
                , int.Parse(rbl_moneda.SelectedValue), txt_num_contrato.Text.Trim(), decimal.Parse(txt_monto.Text.Trim())
                , DateTime.Parse(ddl_mes_inicio_plan.SelectedValue), int.Parse(txt_meses_restriccion.Text.Trim())
                , int.Parse(txt_meses_reversion.Text.Trim()), int.Parse(txt_meses_consecutivo.Text.Trim()));
            if (cObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El contrato TerraPlus se registró correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El contrato TerraPlus NO se registró correctamente";
                return false;
            }
        }
        else { return false; }
    }


    public void CargarReprogramar(int Id_contrato, int Id_cliente)
    {
        id_contrato_terraplus = Id_contrato;
        id_cliente = Id_cliente;

        ConNroContrato = false;
        txt_num_contrato.Text = "";

        terrasur.terraplus.tp_plan ppObj = new terrasur.terraplus.tp_plan(terrasur.terraplus.tp_plan.Actual(id_contrato_terraplus));
        txt_monto.Text = ppObj.monto.ToString("N2");
        rbl_moneda.SelectedValue = ppObj.id_moneda.ToString();
        rbl_moneda.Enabled = false;


        int Id_pago_ultimo = terrasur.terraplus.tp_pago.Id_ultimo(id_contrato_terraplus);
        if (Id_pago_ultimo > 0)
        {
            terrasur.terraplus.tp_pago ult_p_obj = new terrasur.terraplus.tp_pago(Id_pago_ultimo);
            lbl_fecha_referencia.Text = ult_p_obj.mes_pago.AddMonths(1).ToString("d");
        }
        else { lbl_fecha_referencia.Text = DateTime.Now.ToString("d"); }
        lbl_num_meses_antes.Text = "0"; lbl_num_meses_despues.Text = "0";
        ddl_mes_inicio_plan.DataBind();
        
        txt_meses_reversion.Text = ppObj.meses_reversion.ToString();
        txt_meses_consecutivo.Text = ppObj.meses_consecutivo.ToString();
        txt_meses_restriccion.Text = ppObj.meses_restriccion.ToString();
        //txt_meses_reversion.Text = Convert.ToInt32((new parametro("tp_meses_reversion")).valor).ToString();
        //txt_meses_consecutivo.Text = Convert.ToInt32((new parametro("tp_meses_consecutivo")).valor).ToString();
        //txt_meses_restriccion.Text = Convert.ToInt32((new parametro("tp_meses_restriccion")).valor).ToString();

        txt_monto.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpPlan", "definir_monto");
        if (rbl_moneda.Enabled) { rbl_moneda.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpPlan", "definir_monto"); }
        
        txt_meses_restriccion.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpPlan", "definir_meses_restriccion");
        txt_meses_reversion.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpPlan", "definir_meses_reversion");
        txt_meses_consecutivo.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpPlan", "definir_meses_consecutivo");
        
        //lbl_meses_consecutivo_enun.Visible = false;
        //txt_meses_consecutivo.Visible = false;
        rfv_meses_consecutivo.Enabled = false;
        rv_meses_consecutivo.Enabled = false;
    }

    private bool VerificarReprogramar()
    {
        bool correcto = true;
        if (id_contrato_terraplus == 0)
        {
            Msg1.Text = "El cliente NO tienen un contrato TerraPlus activo";
            correcto = false;
        }
        return correcto;
    }

    public bool Reprogramar()
    {
        if (VerificarReprogramar())
        {
            //int id_contrato = terrasur.terraplus.tp_contrato.IdContratoPorCliente(id_cliente);
            terrasur.terraplus.tp_plan pObj = new terrasur.terraplus.tp_plan(id_contrato_terraplus
                , int.Parse(rbl_moneda.SelectedValue), decimal.Parse(txt_monto.Text.Trim())
                , DateTime.Parse(ddl_mes_inicio_plan.SelectedValue), int.Parse(txt_meses_restriccion.Text.Trim())
                , int.Parse(txt_meses_reversion.Text.Trim()), int.Parse(txt_meses_consecutivo.Text.Trim()));
            if (pObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El plan TerraPlus se registró correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El plan TerraPlus NO se registró correctamente";
                return false;
            }
        }
        else { return false; }
    }
    
</script>
<asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato_terraplus" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_fecha_referencia" runat="server" Text="01/01/2014" Visible="false"></asp:Label>
<asp:Label ID="lbl_num_meses_antes" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_num_meses_despues" runat="server" Text="0" Visible="false"></asp:Label>

<table align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_terraplus" runat="server" DisplayMode="List" ValidationGroup="terraplus" />
        </td>
    </tr>
    <tr>
        <td>
            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formTdEnun"><asp:Label ID="lbl_num_contrato_enun" runat="server" Text="Nro. contrato TerraPlus:"></asp:Label></td>
                    <td class="formTdDato">
                        <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine50" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número del contrato TerraPlus"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1" MaximumValue="9999" Text="*" ErrorMessage="El número del contrato TerraPlus debe estar entre 1 y 9999"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Monto mensual:</td>
                    <td class="formTdDato">
                        <table cellpadding="0" cellspacing="0" align="left">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_monto" runat="server" SkinID="txtSingleLine50" MaxLength="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir monto mensual"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="terraplus" Type="Double" MinimumValue="0,01" MaximumValue="9999" Text="*" ErrorMessage="El monto debe estar entre 0,01 y 9999"></asp:RangeValidator>
                                </td>
                                <td style="width:5px;"></td>
                                <td>
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="$us" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Bs" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Mes de inicio de plan:</td>
                    <td class="formTdDato">
                        <asp:DropDownList ID="ddl_mes_inicio_plan" runat="server" DataSourceID="ods_lista_meses_inicio_plan" DataValueField="fechaMes" DataTextField="literal">
                        </asp:DropDownList>
                        <%--[fechaMes],[literal]--%>
                        <asp:ObjectDataSource ID="ods_lista_meses_inicio_plan" runat="server" TypeName="terrasur.terraplus.tp_contrato" SelectMethod="ListaMesesInicioPlan">
                            <SelectParameters>
                                <asp:ControlParameter Name="Fecha_referencia" Type="DateTime" ControlID="lbl_fecha_referencia" PropertyName="Text" />
                                <asp:ControlParameter Name="Num_meses_antes" Type="Int32" ControlID="lbl_num_meses_antes" PropertyName="Text" />
                                <asp:ControlParameter Name="Num_meses_despues" Type="Int32" ControlID="lbl_num_meses_despues" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Nro. meses de restricción inicial:</td>
                    <td class="formTdDato">
                        <asp:TextBox ID="txt_meses_restriccion" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_meses_restriccion" runat="server" ControlToValidate="txt_meses_restriccion" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses de restricción inicial"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_meses_restriccion" runat="server" ControlToValidate="txt_meses_restriccion" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="0" MaximumValue="60" Text="*" ErrorMessage="El número de meses debe estar entre 0 y 60"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun"><asp:Label ID="lbl_meses_reversion_enun" runat="server" Text="Nro. meses para revertir el contrato:"></asp:Label></td>
                    <td class="formTdDato">
                        <asp:TextBox ID="txt_meses_reversion" runat="server" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_meses_reversion" runat="server" ControlToValidate="txt_meses_reversion" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses para resolver (revertir) el contrato"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_meses_reversion" runat="server" ControlToValidate="txt_meses_reversion" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="1" MaximumValue="12" Text="*" ErrorMessage="El número de meses para resolver (revertir) el contrato debe estar entre 1 y 12"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun"><asp:Label ID="lbl_meses_consecutivo_enun" runat="server" Visible="false" Text="Nro. meses de pago consecutivo para acceder al servicio:"></asp:Label></td>
                    <td class="formTdDato">
                        <asp:TextBox ID="txt_meses_consecutivo" runat="server" Visible="false" SkinID="txtSingleLine50" MaxLength="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_meses_consecutivo" runat="server" Enabled="false" ControlToValidate="txt_meses_consecutivo" Display="Dynamic" ValidationGroup="terraplus" Text="*" ErrorMessage="Debe introducir el número de meses de pago consecutivo"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_meses_consecutivo" runat="server" Enabled="false" ControlToValidate="txt_meses_consecutivo" Display="Dynamic" ValidationGroup="terraplus" Type="Integer" MinimumValue="0" MaximumValue="12" Text="*" ErrorMessage="El número de meses de pago consecutivo debe estar entre 0 y 12"></asp:RangeValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <%--<tr>
        <td>
            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
            </table>
        </td>
    </tr>--%>
</table>

