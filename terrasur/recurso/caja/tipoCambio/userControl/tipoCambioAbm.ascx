<%@ Control Language="C#" ClassName="tipoCambioAbm" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_compra.Attributes["onfocus"] = "this.select();";
        txt_compra.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_compra.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_compra.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
        txt_venta.Attributes["onfocus"] = "this.select();";
        txt_venta.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_venta.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_venta.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }

    public DateTime fecha { get { return DateTime.Parse(lbl_fecha.Text); } private set { lbl_fecha.Text = value.ToShortDateString(); lbl_fecha_dato.Text = value.ToString("D"); } }

    public void Cargar(DateTime _Fecha)
    {
        lb_listado.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "view");
        fecha = _Fecha;
        //fecha = DateTime.Now.Date;
        if (tipo_cambio.Verificar(fecha) == true)
        {
            tipo_cambio tc = new tipo_cambio(fecha);
            txt_compra.Text = tc.compra.ToString("F2");
            txt_venta.Text = tc.venta.ToString("F2");

            txt_compra.Enabled = false;
            txt_venta.Enabled = false;
            btn_cambiar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "update");
            btn_guardar.Visible = false;
            btn_cancelar.Visible = false;
        }
        else
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "insert") == true)
            {
                //Msg1.Text = "Debe definir el Tipo de Cambio del Sistema";
                txt_compra.Enabled = true;
                txt_venta.Enabled = true;
                btn_cambiar.Visible = false;
                btn_guardar.Visible = true;
                btn_cancelar.Visible = false;

                txt_compra.Focus();

                int id_anterior = tipo_cambio.Anterior(fecha);
                if (id_anterior > 0)
                {
                    tipo_cambio tc = new tipo_cambio(id_anterior);
                    txt_compra.Text = tc.compra.ToString("F2");
                    txt_venta.Text = tc.venta.ToString("F2");
                }
                else
                {
                    txt_compra.Text = "";
                    txt_venta.Text = "";
                }
            }
            else
            {
                //Msg1.Text = "Comuniquese con la persona encargada de definir el Tipo de Cambio del Sistema";
                txt_compra.Text = "";
                txt_compra.Enabled = false;
                txt_venta.Text = "";
                txt_venta.Enabled = false;

                btn_cambiar.Visible = false;
                btn_guardar.Visible = false;
                btn_cancelar.Visible = false;
            }
        }
    }
    

    protected void btn_cambiar_Click(object sender, EventArgs e)
    {
        txt_compra.Enabled = true;
        txt_venta.Enabled = true;

        btn_cambiar.Visible = false;
        btn_guardar.Visible = true;
        btn_cancelar.Visible = true;

        txt_compra.Focus();
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        txt_compra.Enabled = false;
        txt_venta.Enabled = false;

        btn_cambiar.Visible = true;
        btn_guardar.Visible = false;
        btn_cancelar.Visible = false;
    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            tipo_cambio tc = new tipo_cambio(fecha);
            tc.compra = decimal.Parse(txt_compra.Text.Trim());
            tc.venta = decimal.Parse(txt_venta.Text.Trim());
            if (tc.Guardar(Profile.id_usuario))
            {
                Msg1.Text = "El Tipo de Cambio se guardó correctamente";
                txt_compra.Enabled = false;
                txt_venta.Enabled = false;
                btn_cambiar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tipoCambio", "update");
                btn_guardar.Visible = false;
                btn_cancelar.Visible = false;
            }
            else { Msg1.Text = "El Tipo de Cambio NO se guardó correctamente"; }
        }
        general.automatico_RevertirPreasignados();
    }

    protected void lb_listado_Click(object sender, EventArgs e)
    {
        wpu_listado.Show();
    }

</script>
<asp:Label ID="lbl_fecha" runat="server" Text="01/01/2008" Visible="false"></asp:Label>
<table width="100%">
    <tr>
        <td class="tipoCambioTdHistorico">
            <asp:LinkButton ID="lb_listado" runat="server" Text="Tipos de cambio históricos" OnClick="lb_listado_Click"></asp:LinkButton>
            <asp:WinPopUp ID="wpu_listado" runat="server" NavigateUrl="~/recurso/caja/tipoCambio/tipoCambioHistorico.aspx"></asp:WinPopUp>
        </td>
    </tr>
</table>
<table align="center">
    <tr>
        <td>
            <table class="tipoCambioTable">
                <tr>
                    <td class="tipoCambioTdTitle">Registro del tipo de cambio</td>
                </tr>
                <tr>
                    <td class="tipoCambioTdFecha">
                        <asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha:"></asp:Label>
                        <asp:Label ID="lbl_fecha_dato" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tipoCambioTdMsg">
                        <asp:ValidationSummary ID="vs_tipocambio" runat="server" DisplayMode="List" ValidationGroup="tipoCambio" />
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td class="tipoCambioTdEnun">T/C para la compra</td>
                                <td class="tipoCambioTdEspacio"></td>
                                <td class="tipoCambioTdEnun">T/C para la venta</td>
                            </tr>
                            <tr>
                                <td class="tipoCambioTdDato">
                                    <asp:TextBox ID="txt_compra" runat="server" SkinID="txtTipoCambio" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_compra" runat="server" ControlToValidate="txt_compra" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tipoCambio" Text="*" ErrorMessage="Debe introducir el Tipo de Cambio para la compra"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rv_compra" runat="server" ControlToValidate="txt_compra" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tipoCambio" MinimumValue="0" MaximumValue="99" Type="Double" Text="*" ErrorMessage="El Tipo de Cambio debe estar entre 0 y 99"></asp:RangeValidator> 
                                    <asp:CompareValidator ID="cv_compra" runat="server" ControlToValidate="txt_compra" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tipoCambio" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                                </td>
                                <td></td>
                                <td class="tipoCambioTdDato">
                                    <asp:TextBox ID="txt_venta" runat="server" SkinID="txtTipoCambio" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_venta" runat="server" ControlToValidate="txt_venta" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tipoCambio" Text="*" ErrorMessage="Debe introducir el Tipo de Cambio para la venta"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rv_venta" runat="server" ControlToValidate="txt_venta" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tipoCambio" MinimumValue="0" MaximumValue="99" Type="Double" Text="*" ErrorMessage="El Tipo de Cambio debe estar entre 0 y 99"></asp:RangeValidator> 
                                    <asp:CompareValidator ID="cv_venta" runat="server" ControlToValidate="txt_venta" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tipoCambio" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tipoCambioTdButton">
                        <asp:Button ID="btn_cambiar" runat="server" Text="Modificar" CausesValidation="false" OnClick="btn_cambiar_Click" OnClientClick="return confirm('¿Esta seguro que desea modificar el Tipo de Cambio?');" />
                        <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CausesValidation="true" ValidationGroup="tipoCambio" OnClick="btn_guardar_Click" OnClientClick="return confirm('¿Esta seguro que desea guardar el Tipo de Cambio?');" />
                        <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btn_cancelar_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>