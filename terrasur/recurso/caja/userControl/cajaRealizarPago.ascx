<%@ Control Language="C#" ClassName="cajaRealizarPago" %> 
<%@ Register Src="~/recurso/caja/userControl/cajaImpresion.ascx" TagName="cajaImpresion" TagPrefix="uc1" %>
<%@ Register src="~/recurso/caja/userControl/cajaImpresionNueva.ascx" tagname="cajaImpresionNueva" tagprefix="uc2" %>

<script runat="server">
    public string factura_cliente { set { if (value.Trim() != "")txt_cliente.Text = value.Trim(); } }
    public string factura_nit { set { if (value.Trim() != "") txt_nit.Text = value.Trim(); } }
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_cliente.Attributes["onfocus"] = "this.select();";
        txt_efect_monto.Attributes["onfocus"] = "this.select();";
        txt_efect_monto.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_efect_monto.Attributes["onkeyup"] = "extractNumber(this,2,false);calcularRestante(" + js_monto.ClientID + "," + txt_efect_monto.ClientID + "," + txt_otro_monto.ClientID + ");";
        txt_efect_monto.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    } 

    public event EventHandler Eleccion_aceptar;
    protected virtual void RealizarEleccionAceptar(object sender) { if (this.Eleccion_aceptar != null) this.Eleccion_aceptar(sender, new EventArgs()); }
    public event EventHandler Eleccion_cancelar;
    protected virtual void RealizarEleccionCancelar(object sender)
    {
        if (this.Eleccion_cancelar != null) 
            this.Eleccion_cancelar(sender, new EventArgs());
    }
    protected void btn_aceptar_Click(object sender, EventArgs e)
    {
        if (Verificar() == true) RealizarEleccionAceptar(sender);
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        RealizarEleccionCancelar(sender);
    }

    public void Pago_Realizado(string transacciones)
    {
        panel_pago.Enabled = false;
        panel_documentos.Visible = true;

        if (ConfigurationManager.AppSettings["impresoras_red"] == "si")
        {
            //TRANSACCIONES
            panel_transacciones.Visible = true;
            CajaImpresionTransacciones.MostrarDocumento("", transacciones, false, 0, 300, 200);
        }
        else
        {
            panel_transacciones.Visible = false;
            
            //RECIBOS
            if (CajaImpresionRecibos.VerificarDocumento("Recibo", transacciones) == true)
            {
                panel_recibos.Visible = true;
                CajaImpresionRecibos.MostrarDocumento("Recibo", transacciones, false, 0, 300, 200);
            }
            else { panel_recibos.Visible = false; }
            //FACTURAS 
            if (CajaImpresionFacturas.VerificarDocumento("Factura", transacciones) == true)
            {
                panel_facturas.Visible = true;
                CajaImpresionFacturas.MostrarDocumento("Factura", transacciones, false, 0, 300, 200);
            }
            else { panel_facturas.Visible = false; }
            //COMPROBANTES DPR
            if (CajaImpresionComprobantes.VerificarDocumento("Comprobante", transacciones) == true)
            {
                panel_comprobantes.Visible = true;
                CajaImpresionComprobantes.MostrarDocumento("Comprobante", transacciones, false, 0, 300, 200);
            }
            else { panel_comprobantes.Visible = false; }
        }
            
        if (Page.MaintainScrollPositionOnPostBack == true) Page.MaintainScrollPositionOnPostBack = false;
        if (id_contrato > 0)
        {
            btn_otro_contrato.Visible = true;
            btn_otro_pago.Visible = true;
        }
        txt_focus.Focus();
    }
    
    //Los datos de salida
    public string dato_cliente_nombre { get { return txt_cliente.Text.Trim(); } }
    public decimal dato_cliente_nit
    {
        get
        {
            decimal num_nit = 0;
            if (decimal.TryParse(txt_nit.Text.Trim(), out num_nit)) return num_nit;
            else return 0;
        }
    }
    public bool dato_cliente_guardar { get { return rbl_beneficiario.SelectedValue.Equals("modificar_guardar"); } }
    public int dato_id_recibo_cobrador { get { if (int.Parse(txt_recibo.Text.Trim()) == 0) return 0; else return new recibo_cobrador(0, int.Parse(txt_recibo.Text.Trim())).id_recibocobrador; } }
    public tmpFormaPago dato_FormaPagoCliente()
    {
        tmpFormaPago tmp_fp = new tmpFormaPago(monto);
        //if (Verificar() == true)
        //{
        if (dpr == true) 
        {
            tmp_fp.dpr = true;
            tmp_fp.dpr_sus = monto;
            tmp_fp.dpr_id_dpr = int.Parse(ddl_dpr.SelectedValue);
        }
        else
        {
            tmp_fp.dpr = false;
            
            //Efectivo
            decimal efect_monto = decimal.Parse(txt_efect_monto.Text);
            if (codigo_moneda == "$us") { tmp_fp.efectivo_sus = efect_monto; } else { tmp_fp.efectivo_bs = efect_monto; }

            //Si el monto no se convirtió correctamente:
            if (int.Parse(ddl_efectivo.SelectedValue) > 0 /*&& efect_monto < monto && decimal.Parse(txt_otro_monto.Text.Trim()) == 0*/)
            {
                if (efect_monto >= monto)
                {
                    txt_otro_monto.Text = "0,00";
                }
                else
                {
                    txt_otro_monto.Text = (monto - efect_monto).ToString("F2");
                }
            }
            
            decimal otro_monto = decimal.Parse(txt_otro_monto.Text.Trim());
            switch (int.Parse(ddl_efectivo.SelectedValue))
            {
                case 1:
                    //Cheque
                    tmp_fp.cheque_id_banco = int.Parse(ddl_banco.SelectedValue);
                    tmp_fp.cheque_numero = txt_cheque_numero.Text.Trim();
                    if (codigo_moneda == "$us") { tmp_fp.cheque_sus = otro_monto; } else { tmp_fp.cheque_bs = otro_monto; }
                    break;
                case 2:
                    //Tarjeta
                    tmp_fp.tarjeta_numero = txt_tarjeta_numero.Text.Trim();
                    if (codigo_moneda == "$us") { tmp_fp.tarjeta_sus = otro_monto; } else { tmp_fp.tarjeta_bs = otro_monto; }
                    break;
                case 3:
                    //Depósito
                    if (codigo_moneda == "$us") { tmp_fp.deposito_sus = otro_monto; } else { tmp_fp.deposito_bs = otro_monto; }
                    break;
            }
        }
        //}
        return tmp_fp;
    }

    public bool Verificar()
    {
        bool correcto = true;
        if (Page.IsValid == true)
        {
            //1: Se verifica el pago
            if (dpr == false)
            {
                tmpFormaPago fp1 = dato_FormaPagoCliente();
                decimal suma_componentes = 0;
                if (codigo_moneda == "$us") { suma_componentes = fp1.efectivo_sus + fp1.cheque_sus + fp1.tarjeta_sus + fp1.deposito_sus; }
                else { suma_componentes = fp1.efectivo_bs + fp1.cheque_bs + fp1.tarjeta_bs + fp1.deposito_bs; }
                if (suma_componentes != monto)
                {
                    Msg1.Text = "El monto a pagar debe ser: " + monto.ToString() + " " + codigo_moneda;
                    correcto = false;
                }
            }
            /*
            if (dpr == false && int.Parse(rbl_efectivo.SelectedValue) == 0)
            {
                //Pago en efectivo ($us o Bs)
                if (Math.Round(decimal.Parse(txt_efectivo_sus.Text) + decimal.Parse(txt_efectivo_bs.Text), 2) != monto)
                {
                    Msg1.Text = "El monto a pagar debe ser: " + monto.ToString() + " " + codigo_moneda;
                    correcto = false;
                }
            }*/
            //3: Se verifica el recibo de cobrador
            if (cb_recibo.Checked == false)
            {
                if (recibo_cobrador.PermitirUtilizar(0, Int32.Parse(txt_recibo.Text.Trim()), id_contrato) == false)
                {
                    Msg1.Text = "El recibo de cobrador no esta disponible para ser utilizado";
                    correcto = false;
                }
            }
        }
        else { correcto = false; }
        return correcto;
    }

    //Los atributos:
    public decimal monto { get { return decimal.Parse(lbl_monto.Text); } protected set { lbl_monto.Text = value.ToString(); js_monto.Value = value.ToString().Replace(',', '.'); } }
    public bool dpr { get { return bool.Parse(lbl_dpr.Text); } protected set { lbl_dpr.Text = value.ToString(); } }
    public bool cuota_inicial { get { return bool.Parse(lbl_cuota_inicial.Text); } protected set { lbl_cuota_inicial.Text = value.ToString(); } }
    public bool con_factura { get { return bool.Parse(lbl_con_factura.Text); } protected set { lbl_con_factura.Text = value.ToString(); } }
    public int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } protected set { lbl_id_contrato.Text = value.ToString(); } }
    public string codigo_moneda { get { return lbl_codigo_moneda.Text; } protected set { lbl_codigo_moneda.Text = value; lbl_efectivo_moneda.Text = value; lbl_dpr_moneda.Text = value; } }



    public void Cargar(decimal Monto, bool Dpr, bool Cuota_inicial, bool Con_factura, int Id_contrato, string Codigo_moneda)
    {
        monto = Math.Round(Monto, 2);
        dpr = Dpr;
        cuota_inicial = Cuota_inicial;

        string codigo_negocio = negocio_contrato.CodigoNegocioPorContrato(Id_contrato);
        if (codigo_negocio == "pr_casas" || codigo_negocio == "pr_amanecer" || codigo_negocio == "ed_suiza1" || codigo_negocio == "pr_edificios" || codigo_negocio == "mercado") { con_factura = false; }
        else { con_factura = Con_factura; }
        //con_factura = Con_factura;
        
        id_contrato = Id_contrato;
        codigo_moneda = Codigo_moneda;

        if (monto == 0) { panel_pago.Enabled = false; panel_documentos.Visible = false; }
        else { panel_pago.Enabled = true; panel_documentos.Visible = false; Reset(); }

        if (Page.MaintainScrollPositionOnPostBack == false) Page.MaintainScrollPositionOnPostBack = true;
        btn_otro_contrato.Visible = false;
        btn_otro_pago.Visible = false;
    }

    protected void Reset()
    {
        lbl_monto_num.Text = monto.ToString();
        if (dpr == false)
        {
            //Pago en efectivo:
            MultiView1.ActiveViewIndex = 0;
            View2.EnableViewState = false;
            ddl_efectivo.SelectedIndex = 0;
            ResetPagoEfectivo(0);
        }
        else
        {
            //Pago en documento:
            MultiView1.ActiveViewIndex = 1;
            View1.EnableViewState = false;
            ddl_dpr.DataBind();
            lbl_dpr_monto.Text = monto.ToString();
        }
        if (con_factura == true)
        {
            panel_beneficiario.Visible = true;
            rfv_cliente.Enabled = true;
            rfv_nit.Enabled = true;
            rbl_beneficiario.SelectedValue = "actual";
            ResetBeneficiario("actual");
        }
        else
        {
            panel_beneficiario.Visible = false;
            rfv_cliente.Enabled = false;
            rfv_nit.Enabled = false;
        }
        cb_recibo.Checked = false;
        ResetRecibo(false);

        panel_pago.Enabled = true;
    }

    protected void ddl_efectivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetPagoEfectivo(int.Parse(ddl_efectivo.SelectedValue));
    }
    protected void ResetPagoEfectivo(int Tipo)
    {
        txt_efect_monto.Text = monto.ToString("F2");
        lbl_efect_moneda.Text = codigo_moneda;

        txt_otro_monto.Text = Convert.ToDecimal(0).ToString("F2");
        lbl_otro_moneda.Text = codigo_moneda;

        if (Tipo == 0)
        {
            txt_efect_monto.Enabled = false;
            
            //Se ocultan los paneles de "otros"
            panel_otro_monto.Visible = false;
            panel_otro_datos.Visible = false;

            //(Se desactiva Cheque)
            panel_otro_datos_cheque.Visible = false;
            rfv_banco.Enabled = false;
            rfv_cheque_numero.Enabled = false;

            //(Se desactiva Tarjeta)
            panel_otro_datos_tarjeta.Visible = false;
            rfv_tarjeta_numero.Enabled = false;
        }
        else
        {
            txt_efect_monto.Enabled = true;
            txt_efect_monto.Focus();
            
            //Se muestran los paneles de "otros"
            panel_otro_monto.Visible = true;
            panel_otro_datos.Visible = true;

            switch (Tipo)
            {
                case 1:
                    //Cheque (se Activa)
                    panel_otro_datos_cheque.Visible = true;
                    if (ddl_banco.Items.Count == 0) { ddl_banco.DataBind(); }
                    if (ddl_banco.Items.Count > 0) { ddl_banco.SelectedIndex = 0; }
                    rfv_banco.Enabled = true;
                    txt_cheque_numero.Text = "";
                    rfv_cheque_numero.Enabled = true;

                    //(Se desactiva Tarjeta)
                    panel_otro_datos_tarjeta.Visible = false;
                    rfv_tarjeta_numero.Enabled = false;
                    break;
                case 2:
                    //Tarjeta (se Activa)
                    panel_otro_datos_tarjeta.Visible = true;
                    txt_tarjeta_numero.Text = "";
                    rfv_tarjeta_numero.Enabled = true;

                    //(Se desactiva Cheque)
                    panel_otro_datos_cheque.Visible = false;
                    rfv_banco.Enabled = false;
                    rfv_cheque_numero.Enabled = false;
                    break;
                case 3: 
                    //Depósito
                    //(Se desactiva Cheque)
                    panel_otro_datos_cheque.Visible = false;
                    rfv_banco.Enabled = false;
                    rfv_cheque_numero.Enabled = false;

                    //(Se desactiva Tarjeta)
                    panel_otro_datos_tarjeta.Visible = false;
                    rfv_tarjeta_numero.Enabled = false;
                    break;
            }
        }

        /*
        MultiView2.ActiveViewIndex = Tipo;
        switch (Tipo)
        {
            case 0:
                //Efectivo
                if (codigo_moneda == "$us") { txt_efectivo_sus.Text = monto.ToString(); txt_efectivo_bs.Text = "0"; }
                else { txt_efectivo_sus.Text = "0"; txt_efectivo_bs.Text = monto.ToString(); }
                break;
            case 1:
                //Cheque
                txt_cheque_numero.Text = "";
                txt_cheque_monto.Text = monto.ToString();
                if (codigo_moneda == "$us") { rbl_cheque_moneda.SelectedValue = "sus"; }
                else { rbl_cheque_moneda.SelectedValue = "bs"; }
                txt_cheque_numero.Focus();
                break;
            case 2:
                //Tarjeta
                txt_tarjeta_numero.Text = "";
                txt_tarjeta_monto.Text = monto.ToString();
                if (codigo_moneda == "$us") { rbl_tarjeta_moneda.SelectedValue = "sus"; }
                else { rbl_tarjeta_moneda.SelectedValue = "bs"; }
                txt_tarjeta_numero.Focus();
                break;
            case 3:
                //Depósito
                txt_deposito_monto.Text = monto.ToString();
                if (codigo_moneda == "$us") { rbl_deposito_moneda.SelectedValue = "sus"; }
                else { rbl_deposito_moneda.SelectedValue = "bs"; }
                break;
        }
        */
    }

    protected void rbl_beneficiario_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetBeneficiario(rbl_beneficiario.SelectedValue);
    }
    protected void ResetBeneficiario(string Tipo)
    {
        rbl_beneficiario.Visible = id_contrato.Equals(0).Equals(false);
        if (id_contrato == 0)
        {
            txt_cliente.Text = "";
            txt_cliente.Enabled = true;
            txt_nit.Text = "0";
            txt_nit.Enabled = true;
        }
        else
        {
            switch (Tipo)
            {
                case "actual":
                    beneficiario_factura bf = new beneficiario_factura(id_contrato);
                    txt_cliente.Text = bf.nombre;
                    txt_cliente.Enabled = false;
                    if (bf.nit == "") txt_nit.Text = "0";
                    else txt_nit.Text = bf.nit;
                    txt_nit.Enabled = false;
                    break;
                case "modificar":
                    txt_cliente.Enabled = true; ;
                    txt_nit.Enabled = true;
                    txt_cliente.Focus();
                    break;
                case "modificar_guardar":
                    txt_cliente.Enabled = true; ;
                    txt_nit.Enabled = true;
                    txt_cliente.Focus();
                    break;
            }
        }
    }

    protected void cb_recibo_CheckedChanged(object sender, EventArgs e)
    {
        ResetRecibo(cb_recibo.Checked);
        //if (cb_recibo.Checked == false) txt_recibo.Focus();
    }
    protected void ResetRecibo(bool Sin_recibo)
    {
        if (Sin_recibo == true)
        {
            txt_recibo.CssClass = "cajaCobroTextBoxReciboInactivo";
            txt_recibo.Text = "0";
            txt_recibo.Enabled = false;
        }
        else
        {
            txt_recibo.CssClass = "cajaCobroTextBoxReciboActivo";
            txt_recibo.Text = "";
            txt_recibo.Enabled = true;
            //txt_recibo.Focus();
        }
    }

    protected void btn_otro_contrato_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/recurso/caja/contratoPago.aspx");
    }
    protected void btn_otro_pago_Click(object sender, EventArgs e)
    {
        if (id_contrato > 0)
        {
            Session["id_contrato"] = id_contrato;
            Response.Redirect("~/recurso/caja/contratoPago.aspx");
        }
    }

    public void SetBeneficiarioFactura(string p_Nombre_cliente, string p_Nit)
    {
        txt_cliente.Text = p_Nombre_cliente;
        txt_nit.Text = p_Nit;
    }


</script>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>--%>
<asp:Label ID="lbl_monto" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_dpr" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_cuota_inicial" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_con_factura" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>

<input id="js_monto" runat="server" value="0" type="hidden" />
<input id="js_tc" runat="server" value="0" type="hidden" />
<asp:Panel ID="panel_pago" runat="server" GroupingText="Realizar pago" DefaultButton="btn_aceptar">
    <table width="100%">
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td class="cajaCobroMontoTdEnun">Monto a pagar:</td>
                        <td class="cajaCobroMontoTdDato"><asp:Label ID="lbl_monto_num" runat="server"></asp:Label></td>
                        <td class="cajaCobroMontoTdEnun"><asp:Label ID="lbl_efectivo_moneda" runat="server" Text="$us"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:Panel ID="panel_pago_efectivo" runat="server" GroupingText="PAGO EN EFECTIVO">
                            <table align="center">
                                <tr>
                                    <td valign="middle">
                                        <asp:Label ID="lbl_efect_enun" runat="server" Text="Efectivo:" SkinID="lblEnun"></asp:Label>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" align="left">
                                            <tr>
                                                <td><asp:TextBox ID="txt_efect_monto" runat="server" Enabled="false" SkinID="txtCajaCobroMonto" Text="0" MaxLength="9"></asp:TextBox></td>
                                                <td style="width:3px;"></td>
                                                <td><asp:Label ID="lbl_efect_moneda" runat="server" Text="$us"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        <asp:Label ID="lbl_efectivo_enun" runat="server" Text="+" SkinID="lblEnun"></asp:Label>
                                        <asp:DropDownList ID="ddl_efectivo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_efectivo_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Tarjeta" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Depósito" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Cheque" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Panel ID="panel_otro_monto" runat="server">
                                            <table cellpadding="0" cellspacing="0" align="left">
                                                <tr>
                                                    <td><asp:TextBox ID="txt_otro_monto" runat="server" Enabled="false" SkinID="txtCajaCobroMonto" Text="0" MaxLength="9"></asp:TextBox></td>
                                                    <td style="width:3px;"></td>
                                                    <td><asp:Label ID="lbl_otro_moneda" runat="server" Text="$us"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="width:260px;">
                                        <asp:Panel ID="panel_otro_datos" runat="server">
                                            <asp:Panel ID="panel_otro_datos_cheque" runat="server">
                                                <table cellpadding="0" cellspacing="0" align="left">
                                                    <tr>
                                                        <td>Nº de cheque:</td>
                                                        <td style="width:3px;"></td>
                                                        <td>
                                                            <asp:TextBox ID="txt_cheque_numero" runat="server" SkinID="txtCajaCobroNumChTj" MaxLength="20" Text="0"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv_cheque_numero" runat="server" Enabled="false" ControlToValidate="txt_cheque_numero" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el Nº de cheque" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="rev_cheque_numero" runat="server" ControlToValidate="txt_cheque_numero" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:forma_pago_ExpReg_numero_cheque %>" Text="*" ErrorMessage="El Nº de cheque contiene caracteres no permitidos" ValidationGroup="pago"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="right">
                                                            <asp:DropDownList ID="ddl_banco" runat="server" DataSourceID="ods_lista_banco_activo" DataValueField="id_banco" DataTextField="nombre"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfv_banco" runat="server" Enabled="false" ControlToValidate="ddl_banco" Display="Dynamic" Text="*" ErrorMessage="Debe elegir el Banco al cual pertenece el cheque" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                                            <asp:ObjectDataSource ID="ods_lista_banco_activo" runat="server" TypeName="terrasur.banco" SelectMethod="ListaActivo"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="panel_otro_datos_tarjeta" runat="server">
                                                <table cellpadding="0" cellspacing="0" align="left">
                                                    <tr>
                                                        <td>Nº de tarjeta:</td>
                                                        <td>
                                                            <asp:TextBox ID="txt_tarjeta_numero" runat="server" SkinID="txtCajaCobroNumChTj" MaxLength="20" Text="0"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv_tarjeta_numero" runat="server" Enabled="false" ControlToValidate="txt_tarjeta_numero" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el Nº de tarjeta" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="rev_tarjeta_numero" runat="server" ControlToValidate="txt_tarjeta_numero" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:forma_pago_ExpReg_numero_tarjeta %>" Text="*" ErrorMessage="El Nº de tarjeta contiene caracteres no permitidos" ValidationGroup="pago"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="panel_pago_dpr" runat="server" GroupingText="PAGO EN DOCUMENTO">
                            <table align="left">
                                <tr>
                                    <td class="cajaCobroFormaTdEnun">DPR:</td>
                                    <td class="cajaCobroFormaTdDato">
                                        <asp:DropDownList ID="ddl_dpr" runat="server" DataSourceID="ods_lista_dpr_activo" DataTextField="nombre" DataValueField="id_dpr"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfv_dpr" runat="server" ControlToValidate="ddl_dpr" Display="Dynamic" Text="*" ErrorMessage="Debe elegir el DPR" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                        <%--[id_dpr],[codigo],[nombre]--%>
                                        <asp:ObjectDataSource ID="ods_lista_dpr_activo" runat="server" TypeName="terrasur.dpr" SelectMethod="ListaActivo">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="Cuota_inicial" Type="Boolean" ControlID="lbl_cuota_inicial" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td class="cajaCobroFormaTdEnun"><asp:Label ID="lbl_dpr_moneda" runat="server" Text="Monto en $us:"></asp:Label></td>
                                    <td class="cajaCobroFormaTdDato">
                                        <asp:TextBox ID="lbl_dpr_monto" runat="server" SkinID="txtCajaCobroMonto" Enabled="false"></asp:TextBox>
                                        <%--<asp:Label ID="lbl_dpr_monto" runat="server"></asp:Label>--%>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel_beneficiario" runat="server" GroupingText="Beneficiario de la factura">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <table align="left">
                        <tr>
                            <td class="cajaCobroFormaTdEnun">Cliente:</td>
                            <td class="cajaCobroFormaTdDato">
                                <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtCajaCobroClienteNombre" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el Apellido Paterno del cliente para la emisión de la factura" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre del beneficiario de la factura contiene caracteres inválidos" ValidationGroup="pago"></asp:RegularExpressionValidator> 
                            </td>
                            <td class="cajaCobroFormaTdEnun">NIT:</td>
                            <td class="cajaCobroFormaTdDato">
                                <asp:TextBox ID="txt_nit" runat="server" SkinID="txtCajaCobroClienteNit" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el NIT del cliente para la emisión de la factura" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos" ValidationGroup="pago"></asp:RegularExpressionValidator> 
                            </td>
                            <td class="cajaCobroFacturaTdOpciones" align="left">
                                <asp:RadioButtonList ID="rbl_beneficiario" runat="server" AutoPostBack="true" CausesValidation="false" CellSpacing="2" CellPadding="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_beneficiario_SelectedIndexChanged">
                                    <asp:ListItem Text="Asignado" Value="actual"></asp:ListItem>
                                    <asp:ListItem Text="Modificar" Value="modificar"></asp:ListItem>
                                    <asp:ListItem Text="Modificar y guardar" Value="modificar_guardar"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel_recibo_cobrador" runat="server" GroupingText="Recibo de cobrador">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                    <table align="left">
                        <tr>
                            <td class="cajaCobroFormaTdEnun">Nº de recibo:</td>
                            <td class="cajaCobroFormaTdDato">
                                <asp:TextBox ID="txt_recibo" runat="server" MaxLength="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_recibo" runat="server" ControlToValidate="txt_recibo" Display="Dynamic" Text="*" ErrorMessage="Debe introducir el Nº del recibo de cobrador" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cv_recibo" runat="server" ControlToValidate="txt_recibo" Display="Dynamic" Type="Integer" Operator="DataTypeCheck" Text="*" ErrorMessage="El Nº del recibo de cobrador debe ser un número entero" ValidationGroup="pago"></asp:CompareValidator>
                                <asp:RangeValidator ID="rv_recibo" runat="server" ControlToValidate="txt_recibo" Display="Dynamic" Type="Integer" MinimumValue="0" MaximumValue="99999999" Text="*" ErrorMessage="El Nº del recibo de cobrador no puede ser inferior a 0 ni superior a 99999999" ValidationGroup="pago"></asp:RangeValidator>
                            </td>
                            <td class="cajaCobroFormaTdEnun"><asp:CheckBox ID="cb_recibo" runat="server" Text="Sin recibo de cobrador" AutoPostBack="true" OnCheckedChanged="cb_recibo_CheckedChanged" /></td>
                        </tr>
                    </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="cajaCobroTdButton">
                <asp:ButtonAction ID="btn_aceptar" runat="server" Text="Aceptar" TextoEnviando="Aceptar..." SkinID="btnCajaCobroAceptar" OnClick="btn_aceptar_Click" CausesValidation="true" ValidationGroup="pago" OnClientClick="return confirm('¿Esta seguro que desea realizar el pago?');" />
                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" SkinID="btnCajaCobroCancelar" OnClick="btn_cancelar_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                <asp:ValidationSummary ID="vs_pago" runat="server" DisplayMode="List" ValidationGroup="pago" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="panel_documentos" GroupingText=" " Visible="false" >
    <table width="100%">
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="panel_facturas" GroupingText="Facturas" Visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            <uc1:cajaImpresion ID="CajaImpresionFacturas" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="panel_recibos" GroupingText="Recibos" Visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            <uc1:cajaImpresion ID="CajaImpresionRecibos" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="panel_comprobantes" GroupingText="Comprobantes DPR" Visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            <uc1:cajaImpresion ID="CajaImpresionComprobantes" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="panel_transacciones" GroupingText="Transacción" Visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            <uc2:cajaImpresionNueva ID="CajaImpresionTransacciones" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                          </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdButtonNuevaBusqueda">
                <asp:TextBox ID="txt_focus" runat="server" Height="0" Width="0" MaxLength="0" BorderStyle="Solid" BorderColor="white"></asp:TextBox> 
                <asp:Button ID="btn_otro_contrato" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" OnClick="btn_otro_contrato_Click" />
                <asp:Button ID="btn_otro_pago" runat="server" Text="Realizar otro pago" SkinID="btnVolver" OnClick="btn_otro_pago_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
