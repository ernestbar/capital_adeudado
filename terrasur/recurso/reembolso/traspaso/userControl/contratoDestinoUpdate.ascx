<%@ Control Language="C#" ClassName="contratoDestinoUpdate" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        //txt_num_contrato.Attributes["onblur"] = "extractNumber(this,0,false);";
        //txt_num_contrato.Attributes["onkeyup"] = "extractNumber(this,0,false);";
        //txt_num_contrato.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

        txt_monto.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }

    int id_reembolso { get { return int.Parse(lbl_id_reembolso.Text); } set { lbl_id_reembolso.Text = value.ToString(); } }
    DateTime fecha { get { return DateTime.Parse(lbl_fecha.Text); } set { lbl_fecha.Text = value.ToString(); } }
    
    private string codigo_moneda_traspaso
    {
        get { return lbl_codigo_moneda_traspaso.Text; }
        set
        {
            lbl_codigo_moneda_traspaso.Text = value;
            lbl_moneda.Text = value;
            lbl_monto_total_moneda.Text = value;
            lbl_monto_traspasado_moneda.Text = value;
            lbl_monto_saldo_moneda.Text = value;
        }
    }
    public decimal m_trastasar
    {
        get { return decimal.Parse(lbl_m_trastasar.Text); }
        set
        {
            lbl_m_trastasar.Text = value.ToString();

            lbl_monto_total.Text = value.ToString("N2");
            lbl_monto_saldo.Text = (value - m_traspasado).ToString("N2");
        }
    }

    private decimal m_traspasado
    {
        get { return decimal.Parse(lbl_m_traspasado.Text); }
        set
        {
            lbl_m_traspasado.Text = value.ToString();

            lbl_monto_traspasado.Text = value.ToString("N2");
            lbl_monto_saldo.Text = (m_trastasar - value).ToString("N2");
        }
    }
    private decimal m_saldo
    {
        get { return m_trastasar - m_traspasado; }
    }

        
    public void CargarActualizar(int Id_reembolso, DateTime Fecha, string Codigo_moneda, decimal Monto, decimal Pagado)
    {
        id_reembolso = Id_reembolso;
        fecha = Fecha;

        codigo_moneda_traspaso = Codigo_moneda;
        m_trastasar = Monto;
        m_traspasado = Pagado;

        txt_num_contrato.Text = "";
        rbl_origen.SelectedValue = "1";
        txt_monto.Text = "";

        gv_destino.DataBind();
    }


    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        if (VerificarAgregar())
        {
            string _Num_contrato = txt_num_contrato.Text.Trim();
            decimal _Monto = decimal.Parse(txt_monto.Text.Trim());
            int _Origen = int.Parse(rbl_origen.SelectedValue);
            int _Id_contrato = 0; if (int.Parse(rbl_origen.SelectedValue) == 1) { _Id_contrato = contrato.IdPorNumero(_Num_contrato); }

            //Se obtienen los datos del contrato
            terrasur.traspaso.tmpContratoDestino tmpCttoObj;
            if (_Origen == 1) { tmpCttoObj = terrasur.traspaso.tmpContratoDestino.Terrasur_DatosContrato(_Id_contrato, _Num_contrato); }
            else { tmpCttoObj = terrasur.traspaso.tmpContratoDestino.Renacer_DatosContrato(_Id_contrato, _Num_contrato); tmpCttoObj.id_contrato = 0; }
            if (codigo_moneda_traspaso == "$us")
            {
                tmpCttoObj.monto_sus = _Monto;
                if (tmpCttoObj.codigo_moneda == "Bs")
                {
                    terrasur.sintesis.s_tipo_cambio tcObj = new terrasur.sintesis.s_tipo_cambio(terrasur.sintesis.s_tipo_cambio.IdVigente(fecha));
                    tmpCttoObj.tipo_cambio = tcObj.compra;
                    tmpCttoObj.monto_bs = tmpCttoObj.monto_sus * tmpCttoObj.tipo_cambio;
                }
            }
            else if (codigo_moneda_traspaso == "Bs")
            {
                tmpCttoObj.monto_bs = _Monto;
                if (tmpCttoObj.codigo_moneda == "$us")
                {
                    terrasur.sintesis.s_tipo_cambio tcObj = new terrasur.sintesis.s_tipo_cambio(terrasur.sintesis.s_tipo_cambio.IdVigente(fecha));
                    tmpCttoObj.tipo_cambio = tcObj.venta;
                    tmpCttoObj.monto_sus = Math.Round((tmpCttoObj.monto_bs / tmpCttoObj.tipo_cambio), 2);
                }
            }

            if (new terrasur.traspaso.contrato_destino(id_reembolso, tmpCttoObj.id_contrato, tmpCttoObj.id_moneda, tmpCttoObj.num_contrato, tmpCttoObj.negocio, tmpCttoObj.producto, tmpCttoObj.cliente, tmpCttoObj.monto_sus, tmpCttoObj.monto_bs, tmpCttoObj.tipo_cambio).Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host) == true)
            {
                gv_destino.DataBind();

                txt_num_contrato.Text = "";
                rbl_origen.SelectedValue = "1";
                txt_monto.Text = "";
                txt_num_contrato.Focus();

                m_traspasado = terrasur.traspaso.reembolso.MontoPagado(id_reembolso);
            }
            
        }
    }


    protected void gv_destino_DataBound(object sender, EventArgs e)
    {
        if (gv_destino.Rows.Count > 0)
        {
            gv_destino.Rows[gv_destino.Rows.Count - 1].CssClass = "gvRowSelected";
            gv_destino.Rows[gv_destino.Rows.Count - 1].Cells[gv_destino.Columns.Count - 1].Controls[0].Visible = false;
        }
    }

    protected void gv_destino_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "retirar")
        {
            int _Id_contratodestino = int.Parse(gv_destino.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            terrasur.traspaso.contrato_destino reObj = new terrasur.traspaso.contrato_destino(_Id_contratodestino);

            if (reObj.Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                gv_destino.DataBind();
                m_traspasado = terrasur.traspaso.reembolso.MontoPagado(id_reembolso);
            }
        }
    }


    public bool VerificarAgregar()
    {
        bool correcto = false;
        
        string _Num_contrato = txt_num_contrato.Text.Trim();

        //Se verifica el contrato
        if (!string.IsNullOrEmpty(_Num_contrato))
        {
            int _Id_contrato = 0; int _Codigo_estado = -1; string _Estado = ""; string _Codigo_moneda = ""; decimal _Saldo = 0;
            if (int.Parse(rbl_origen.SelectedValue) == 1)
            { terrasur.traspaso.tmpContratoDestino.Terrasur_BusquedaContrato(_Num_contrato, fecha, ref _Id_contrato, ref _Codigo_estado, ref _Estado, ref _Codigo_moneda, ref _Saldo); }
            else { terrasur.traspaso.tmpContratoDestino.Renacer_BusquedaContrato(_Num_contrato, fecha, ref _Id_contrato, ref _Codigo_estado, ref _Estado, ref _Codigo_moneda, ref _Saldo); }

            if (_Id_contrato > 0)
            {
                if (_Codigo_estado != 2)
                {
                    if (!string.IsNullOrEmpty(txt_monto.Text.Trim()))
                    {
                        decimal _Monto = decimal.Parse(txt_monto.Text.Trim());
                        if (_Monto <= m_saldo)
                        {
                            if (codigo_moneda_traspaso == _Codigo_moneda)
                            {
                                if (_Monto <= _Saldo) { correcto = true; }
                                else { Msg1.Text = "EL monto a traspasarse (" + codigo_moneda_traspaso + " " + _Monto.ToString("N2") + ") no puede ser mayor al saldo del contrato (" + _Codigo_moneda + " " + _Saldo.ToString("N2") + ")"; }
                            }
                            else
                            {
                                decimal _Monto_convertido = 0;
                                terrasur.sintesis.s_tipo_cambio tcObj = new terrasur.sintesis.s_tipo_cambio(terrasur.sintesis.s_tipo_cambio.IdVigente(fecha));
                                if (codigo_moneda_traspaso == "$us" && _Codigo_moneda == "Bs") { _Monto_convertido = _Monto * tcObj.compra; }
                                else if (codigo_moneda_traspaso == "Bs" && _Codigo_moneda == "$us") { _Monto_convertido = Math.Round((_Monto / tcObj.venta), 2); }

                                if (_Monto_convertido <= _Saldo) { correcto = true; }
                                else { Msg1.Text = "EL monto a traspasarse (" + codigo_moneda_traspaso + " " + _Monto.ToString("N2") + " o " + _Codigo_moneda + " " + _Monto_convertido.ToString("N2") + ") no puede ser mayor al saldo del contrato (" + _Codigo_moneda + " " + _Saldo.ToString("N2") + ")"; }
                            }
                        }
                        else { Msg1.Text = "El monto a traspasarse no puede ser mayor a " + codigo_moneda_traspaso + " " + m_saldo.ToString("N2"); }
                    }
                    else { Msg1.Text = "Debe introducir el monto a traspasarse"; }
                }
                else { Msg1.Text = "El estado del contrato " + _Num_contrato + ", al " + fecha.ToString("d") + ", es: REVERTIDO"; }
            }
            else { Msg1.Text = "El contrato número " + _Num_contrato + " de " + rbl_origen.SelectedItem.Text + " no existe"; }
        }
        else { Msg1.Text = "Debe introducir el número de contrato"; }
        
        return correcto;
    }
    
</script>
<asp:Label ID="lbl_id_reembolso" runat="server" Text="0" Visible="false"></asp:Label>

<%--<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>--%>
<asp:Label ID="lbl_fecha" runat="server" Text="01/01/1900" Visible="false"></asp:Label>

<asp:Label ID="lbl_codigo_moneda_traspaso" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_m_trastasar" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_m_traspasado" runat="server" Text="0" Visible="false"></asp:Label>

<table align="center">
    <tr>
        <td class="formTdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_agregar">
                <table>
                    <tr>
                        <td><asp:Label ID="lbl_num_contrato_enun" runat="server" Text="Nº contrato:" SkinID="lblEnun"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="destino" Text="*" ErrorMessage="Debe introducir el número de contrato"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="rev_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="destino" Text="*" ErrorMessage="El número del contrato contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>"></asp:RegularExpressionValidator> 
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbl_origen" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                <asp:ListItem Value="1" Text="BBR/Terrasur" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Renacer"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_monto" runat="server" Width="75" MaxLength="9"></asp:TextBox>
                            <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="destino" Text="*" ErrorMessage="El monto es incorrecto" Type="Double" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                        </td>
                        <td>
                            <asp:Label ID="lbl_moneda" runat="server" SkinID="lblEnun"></asp:Label>
                        </td>
                        <td><asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="destino" OnClick="btn_agregar_Click" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>    
        <td>
            <asp:ValidationSummary ID="vs_destino" runat="server" DisplayMode="List" ValidationGroup="destino" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_destino" runat="server" AutoGenerateColumns="false" DataSourceID="ods_contrato_lista" DataKeyNames="id_contratodestino" OnRowCommand="gv_destino_RowCommand" OnDataBound="gv_destino_DataBound">
                <Columns>
                    <asp:BoundField HeaderText="Nº ctto." DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField DataField="codigo_moneda" />
                    <asp:BoundField HeaderText="Negocio" DataField="negocio" /> 
                    <asp:TemplateField HeaderText="Lote / Servicio"><ItemTemplate><asp:Label ID="lbl_producto" runat="server" Text='<%# Eval("producto") %>' ToolTip='<%# Eval("cliente") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:BoundField HeaderText="Monto ($us)" DataField="monto_sus" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Monto (Bs)" DataField="monto_bs" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="TC" DataField="tipo_cambio" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:ButtonField CommandName="retirar" Text="Eliminar" ButtonType="Image" ImageUrl="~/images/gv/delete.gif" />
                </Columns>
            </asp:GridView>
            <%--[id_contratodestino],[num_contrato],[id_moneda],[codigo_moneda],[negocio],[producto],[cliente],[monto_sus],[monto_bs],[tipo_cambio]--%>
            <asp:ObjectDataSource ID="ods_contrato_lista" runat="server" TypeName="terrasur.traspaso.contrato_destino" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_reembolso" Type="Int32" ControlID="lbl_id_reembolso" PropertyName="Text" />
                    <asp:ControlParameter Name="Codigo_moneda" Type="String" ControlID="lbl_codigo_moneda_traspaso" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td>
            <table align="center">
                <tr>
                    <td align="left"><asp:Label ID="lbl_monto_total_enun" runat="server" SkinID="lblEnun" Text="Monto a traspasarse:"></asp:Label></td>
                    <td align="right"><asp:Label ID="lbl_monto_total" runat="server" SkinID="lblDato"></asp:Label></td>
                    <td align="left"><asp:Label ID="lbl_monto_total_moneda" runat="server" SkinID="lblEnun"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left"><asp:Label ID="lbl_monto_traspasado_enun" runat="server" SkinID="lblEnun" Text="Monto traspasado:"></asp:Label></td>
                    <td align="right"><asp:Label ID="lbl_monto_traspasado" runat="server" SkinID="lblDato"></asp:Label></td>
                    <td align="left"><asp:Label ID="lbl_monto_traspasado_moneda" runat="server" SkinID="lblEnun"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left"><asp:Label ID="lbl_monto_saldo_enun" runat="server" SkinID="lblEnun" Text="Saldo:"></asp:Label></td>
                    <td align="right"><asp:Label ID="lbl_monto_saldo" runat="server" SkinID="lblDato"></asp:Label></td>
                    <td align="left"><asp:Label ID="lbl_monto_saldo_moneda" runat="server" SkinID="lblEnun"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>


