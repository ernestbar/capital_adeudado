<%@ Control Language="C#" ClassName="pagoDevolucionInsert" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_monto1.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto1.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto1.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";

        txt_monto2.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto2.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto2.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }
    
    private string strPago { get { return lbl_strPago.Text; } set { lbl_strPago.Text = value; } }

    private DateTime fecha { get { return DateTime.Parse(lbl_fecha.Text); } set { lbl_fecha.Text = value.ToString(); } }
    private string codigo_moneda_traspaso
    {
        get { return lbl_codigo_moneda_traspaso.Text; }
        set
        {
            lbl_codigo_moneda_traspaso.Text = value;
            lbl_moneda1.Text = value;
            lbl_moneda2.Text = value;
            gv_pago.Columns[2].HeaderText = "Monto (" + value + ")";
        }
    }
    public decimal m_devolver { get { return decimal.Parse(lbl_m_devolver.Text); } set { lbl_m_devolver.Text = value.ToString(); } }


    public void CargarInsertar(int Id_contrato, DateTime Fecha, decimal Monto_traspasar)
    {
        strPago = "";
        fecha = Fecha;
        codigo_moneda_traspaso = contrato.CodigoMoneda(Id_contrato);
        m_devolver = Monto_traspasar;

        rbl_definicion.SelectedValue = "basico";
        
        panel_basico.Visible = true;
        ddl_num_pagos.SelectedValue = "1";
        cp_fecha1.SelectedDate = DateTime.Now;
        txt_monto1.Text = "";
        rv_monto1.Enabled = true;

        panel_manual.Visible = false;
        rv_monto2.Enabled = false;
        
        gv_pago.DataBind();
    }


    public bool VerificarInsertar()
    {
        bool correcto = true;
        if (m_devolver > 0)
        {
            if (terrasur.traspaso.tmpPago.MontoTotal(strPago) != m_devolver)
            {
                correcto = false;
                Msg1.Text = "El monto total de los pagos de la devolución debe ser " + codigo_moneda_traspaso + " " + m_devolver.ToString("N2");
            }
        }
        else { correcto = false; }
        return correcto;
    }

    public bool Insertar(int Id_reembolso)
    {
        bool correcto = true;

        foreach (terrasur.traspaso.tmpPago p in terrasur.traspaso.tmpPago.Cadena_a_Lista(strPago))
        {
            if (new terrasur.traspaso.pago(Id_reembolso, p.fecha,p.monto).Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host) == false)
            {
                correcto = false;
            }
        }
        
        if (correcto) { return true; }
        else
        {
            Msg1.Text = "Los pagos de la devolución destino NO se registraron correctamente";
            return false;
        }
    }
        
    
    
    
    
    
    protected void rbl_definicion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbl_definicion.SelectedValue == "basico")
        {
            panel_basico.Visible = true;
            ddl_num_pagos.SelectedValue = "1";
            cp_fecha1.SelectedDate = DateTime.Now;
            txt_monto1.Text = "";
            txt_monto1.Focus();
            rv_monto1.Enabled = true;

            panel_manual.Visible = false;
            rv_monto2.Enabled = false;
        }
        else
        {
            panel_basico.Visible = false;
            rv_monto1.Enabled = false;
            
            panel_manual.Visible = true;
            if (terrasur.traspaso.tmpPago.MontoTotal(strPago) == 0)
            { cp_fecha2.SelectedDate = DateTime.Now; }
            else { cp_fecha2.SelectedDate = terrasur.traspaso.tmpPago.FechaMaxima(strPago).AddMonths(1); }
            
            txt_monto2.Text = "";
            txt_monto2.Focus();
            rv_monto2.Enabled = true;
        }
    }

    protected void btn_calcular_Click(object sender, EventArgs e)
    {
        if (m_devolver > 0)
        {
            decimal Pago_inicial = 0; if (!string.IsNullOrEmpty(txt_monto1.Text.Trim())) { Pago_inicial = decimal.Parse(txt_monto1.Text.Trim()); }
            DateTime Fecha_pago = cp_fecha1.SelectedDate;
            if (Fecha_pago >= fecha)
            {
                strPago = terrasur.traspaso.tmpPago.GenerarBasico(m_devolver, int.Parse(ddl_num_pagos.SelectedValue), Fecha_pago, Pago_inicial);
                gv_pago.DataBind();
            }
            else { Msg1.Text = "La fecha de pago inicial (" + Fecha_pago.ToString("d") + ") no puede ser anterior a la fecha de devolución (" + fecha.ToString("d") + ")"; }
        }
    }
    
    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        if (VerificarAgregar())
        {
            strPago = terrasur.traspaso.tmpPago.Agregar(strPago, cp_fecha2.SelectedDate, decimal.Parse(txt_monto2.Text.Trim()));
            gv_pago.DataBind();

            cp_fecha2.SelectedDate = terrasur.traspaso.tmpPago.FechaMaxima(strPago).AddMonths(1);
            txt_monto2.Text = "";
            txt_monto2.Focus();
        }
    }

    protected bool VerificarAgregar()
    {
        bool correcto = false;

        DateTime Fecha_pago = cp_fecha2.SelectedDate;
        DateTime Fecha_maxima = terrasur.traspaso.tmpPago.FechaMaxima(strPago);
        if (Fecha_pago >= fecha)
        {
            if (Fecha_pago >= Fecha_maxima)
            {
                if (!string.IsNullOrEmpty(txt_monto2.Text.Trim()))
                {
                    decimal _Monto = decimal.Parse(txt_monto2.Text.Trim());
                    decimal _Monto_devuelto = terrasur.traspaso.tmpPago.MontoTotal(strPago);

                    if (_Monto <= (m_devolver - _Monto_devuelto))
                    {
                        correcto = true;
                    }
                    else { Msg1.Text = "El monto del pago (" + codigo_moneda_traspaso + " " + _Monto.ToString("N2") + ") no puede ser mayor a " + codigo_moneda_traspaso + " " + (m_devolver - _Monto_devuelto).ToString("N2"); }
                }
                else { Msg1.Text = "Debe introducir el monto del pago"; }
            }
            else { Msg1.Text = "La fecha de pago (" + Fecha_pago.ToString("d") + ") debe ser posterior a (" + Fecha_maxima.ToString("d") + ")"; }
        }
        else { Msg1.Text = "La fecha de pago (" + Fecha_pago.ToString("d") + ") no puede ser anterior a la fecha de devolución (" + fecha.ToString("d") + ")"; }
        
        return correcto;
    }


    protected void gv_pago_DataBound(object sender, EventArgs e)
    {
        if (gv_pago.Rows.Count > 0)
        {
            gv_pago.Rows[gv_pago.Rows.Count - 1].CssClass = "gvRowSelected";
            gv_pago.Rows[gv_pago.Rows.Count - 1].Cells[gv_pago.Columns.Count - 1].Controls[0].Visible = false;

            for (int j = 0; j < gv_pago.Rows.Count - 2; j++) { gv_pago.Rows[j].Cells[gv_pago.Columns.Count - 1].Controls[0].Visible = false; }
        }
    }

    protected void gv_pago_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "retirar")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            int Orden = (int)gv_pago.DataKeys[index].Value;

            strPago = terrasur.traspaso.tmpPago.Retirar(strPago, Orden);
            gv_pago.DataBind();
        }
    }
</script>

<asp:Label ID="lbl_strPago" runat="server" Visible="false"></asp:Label>

<asp:Label ID="lbl_fecha" runat="server" Text="01/01/1900" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_moneda_traspaso" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_m_devolver" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <table align="left">
                            <tr>
                                <td><asp:Label ID="lbl_definicion_enun" runat="server" Text="Definición:" SkinID="lblEnun"></asp:Label></td>
                                <td>
                                    <asp:RadioButtonList ID="rbl_definicion" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="rbl_definicion_SelectedIndexChanged">
                                        <asp:ListItem Text="Básico" Value="basico" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Manual" Value="manual"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Panel ID="panel_basico" runat="server" DefaultButton="btn_calcular">
                            <table>
                                <tr>
                                    <td><asp:Label ID="lbl_num_pagos_enun1" runat="server" Text="Nº pagos:" SkinID="lblEnun"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_num_pagos" runat="server">
                                            <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td><asp:Label ID="lbl_fecha_enun1" runat="server" Text="desde:" SkinID="lblEnun"></asp:Label></td>
                                    <td><ew:CalendarPopup ID="cp_fecha1" runat="server"></ew:CalendarPopup></td>
                                    <td><asp:Label ID="lbl_monto_enun1" runat="server" Text="pago inicial:" SkinID="lblEnun"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txt_monto1" runat="server" Width="75" MaxLength="9"></asp:TextBox>
                                        <asp:RangeValidator ID="rv_monto1" runat="server" ControlToValidate="txt_monto1" Display="Dynamic" ValidationGroup="basico" Text="*" ErrorMessage="El monto es incorrecto" Type="Double" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                                    </td>
                                    <td><asp:Label ID="lbl_moneda1" runat="server" SkinID="lblEnun"></asp:Label></td>
                                    <td><asp:Button ID="btn_calcular" runat="server" Text="Aplicar" CausesValidation="true" ValidationGroup="basico" OnClick="btn_calcular_Click" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panel_manual" runat="server" Visible="false" DefaultButton="btn_agregar">
                            <table>
                                <tr>
                                    <td><asp:Label ID="lbl_fecha_enun2" runat="server" Text="Fecha:" SkinID="lblEnun"></asp:Label></td>
                                    <td><ew:CalendarPopup ID="cp_fecha2" runat="server"></ew:CalendarPopup></td>
                                    <td><asp:Label ID="lbl_monto_enun2" runat="server" Text="Monto:" SkinID="lblEnun"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txt_monto2" runat="server" Width="75" MaxLength="9"></asp:TextBox>
                                        <asp:RangeValidator ID="rv_monto2" runat="server" ControlToValidate="txt_monto2" Display="Dynamic" ValidationGroup="manual" Text="*" ErrorMessage="El monto es incorrecto" Type="Double" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                                    </td>
                                    <td><asp:Label ID="lbl_moneda2" runat="server" SkinID="lblEnun"></asp:Label></td>
                                    <td><asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="manual" OnClick="btn_agregar_Click" /></td>
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
            <asp:ValidationSummary ID="vs_basico" runat="server" DisplayMode="List" ValidationGroup="basico" />
            <asp:ValidationSummary ID="vs_manual" runat="server" DisplayMode="List" ValidationGroup="manual" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_pago" runat="server" AutoGenerateColumns="false" DataSourceID="ods_pago_lista" DataKeyNames="orden" OnDataBound="gv_pago_DataBound" OnRowCommand="gv_pago_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="orden_string" />
                    <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Monto" DataField="monto" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Estado" DataField="estado" />
                    <asp:ButtonField CommandName="retirar" Text="Eliminar" ButtonType="Image" ImageUrl="~/images/gv/delete.gif" />
                </Columns>
            </asp:GridView>
            <%--[orden],[orden_string],[fecha],[monto],[estado]--%>
            <asp:ObjectDataSource ID="ods_pago_lista" runat="server" TypeName="terrasur.traspaso.tmpPago" SelectMethod="Cadena_a_tabla">
                <SelectParameters>
                    <asp:ControlParameter Name="strPago" Type="String" ControlID="lbl_strPago" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </td>
    </tr>
</table>



