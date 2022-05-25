<%@ Control Language="C#" ClassName="pagoDevolucionUpdate" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_monto.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }
    
    private int id_reembolso { get { return int.Parse(lbl_id_reembolso.Text); } set { lbl_id_reembolso.Text = value.ToString(); } }
    private DateTime fecha { get { return DateTime.Parse(lbl_fecha.Text); } set { lbl_fecha.Text = value.ToString(); } }
    public decimal m_devolver { get { return decimal.Parse(lbl_m_devolver.Text); } set { lbl_m_devolver.Text = value.ToString(); } }
    private string codigo_moneda_devolucion
    {
        get { return lbl_codigo_moneda_devolucion.Text; }
        set
        {
            lbl_codigo_moneda_devolucion.Text = value;
            lbl_moneda.Text = value;
            gv_pago.Columns[2].HeaderText = "Monto (" + value + ")";
            //lbl_monto_total_moneda.Text = value;
            //lbl_monto_traspasado_moneda.Text = value;
            //lbl_monto_saldo_moneda.Text = value;
        }
    }
        
    public void CargarActualizar(int Id_reembolso, DateTime Fecha, string Codigo_moneda, decimal Monto)
    {
        id_reembolso = Id_reembolso;
        fecha = Fecha;
        codigo_moneda_devolucion = Codigo_moneda;
        m_devolver = Monto;

        cp_fecha.SelectedDate = terrasur.traspaso.pago.FechaMaxima(id_reembolso).AddMonths(1);
        txt_monto.Text = "";

        gv_pago.DataBind();
    }

    public bool VerificarActualizar()
    {
        bool correcto = true;
        decimal _Monto_pagos = terrasur.traspaso.pago.MontoPagos(id_reembolso);
        decimal _Monto_total = terrasur.traspaso.reembolso.MontoTotal(id_reembolso);

        if (_Monto_pagos != _Monto_total)
        {
            Msg1.Text = "El monto de los pagos (" + codigo_moneda_devolucion + " " + _Monto_pagos.ToString("N2") + ") deben sumar el monto del reembolso (" + codigo_moneda_devolucion + " " + _Monto_total.ToString("N2") + ")";
            correcto = false;
        }

        return correcto;
    }




    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        if (VerificarAgregar())
        {
            if ((new terrasur.traspaso.pago(id_reembolso, cp_fecha.SelectedDate, decimal.Parse(txt_monto.Text.Trim()))).Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                gv_pago.DataBind();

                cp_fecha.SelectedDate = terrasur.traspaso.pago.FechaMaxima(id_reembolso).AddMonths(1);
                txt_monto.Text = "";
                txt_monto.Focus();
            }
            else { }
        }
    }

    protected bool VerificarAgregar()
    {
        bool correcto = false;

        DateTime Fecha_pago = cp_fecha.SelectedDate;
        DateTime Fecha_maxima = terrasur.traspaso.pago.FechaMaxima(id_reembolso);
        if (Fecha_pago >= fecha)
        {
            if (Fecha_pago >= Fecha_maxima)
            {
                if (!string.IsNullOrEmpty(txt_monto.Text.Trim()))
                {
                    decimal _Monto = decimal.Parse(txt_monto.Text.Trim());
                    decimal _Monto_devuelto = terrasur.traspaso.pago.MontoPagos(id_reembolso);

                    if (_Monto <= (m_devolver - _Monto_devuelto))
                    {
                        correcto = true;
                    }
                    else { Msg1.Text = "El monto del pago (" + codigo_moneda_devolucion + " " + _Monto.ToString("N2") + ") no puede ser mayor a " + codigo_moneda_devolucion + " " + (m_devolver - _Monto_devuelto).ToString("N2"); }
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
            //gv_pago.Rows[gv_pago.Rows.Count - 1].Cells[gv_pago.Columns.Count - 1].Controls[0].Visible = false;
        }
    }


    protected void gv_pago_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[gv_pago.Columns.Count - 1].Controls[0].Visible = (bool)DataBinder.Eval(e.Row.DataItem, "permitir_retirar");
        }
    }
    
    protected void gv_pago_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "retirar")
        {
            int Id_pago = (int)gv_pago.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            if ((new terrasur.traspaso.pago(Id_pago)).Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                gv_pago.DataBind();

                cp_fecha.SelectedDate = terrasur.traspaso.pago.FechaMaxima(id_reembolso).AddMonths(1);
                txt_monto.Text = "";
                txt_monto.Focus();
            }
            else { Msg1.Text = "El pago NO se retiró correctamente"; }
        }
    }

</script>
<asp:Label ID="lbl_id_reembolso" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_fecha" runat="server" Text="01/01/1900" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_moneda_devolucion" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_m_devolver" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_manual" runat="server" DefaultButton="btn_agregar">
                <table>
                    <tr>
                        <td><asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha:" SkinID="lblEnun"></asp:Label></td>
                        <td><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
                        <td><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto:" SkinID="lblEnun"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txt_monto" runat="server" Width="75" MaxLength="9"></asp:TextBox>
                            <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="manual" Text="*" ErrorMessage="El monto es incorrecto" Type="Double" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                        </td>
                        <td><asp:Label ID="lbl_moneda" runat="server" SkinID="lblEnun"></asp:Label></td>
                        <td><asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="manual" OnClick="btn_agregar_Click" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>    
        <td>
            <asp:ValidationSummary ID="vs_manual" runat="server" DisplayMode="List" ValidationGroup="manual" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_pago" runat="server" AutoGenerateColumns="false" DataSourceID="ods_pago_lista" DataKeyNames="id_pago" OnDataBound="gv_pago_DataBound" OnRowCommand="gv_pago_RowCommand" OnRowDataBound="gv_pago_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="orden_string" />
                    <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Monto" DataField="monto" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:TemplateField HeaderText="Estado"><ItemTemplate><asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado") %>' ToolTip='<%# Eval("estado_detalle") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:ButtonField CommandName="retirar" Text="Eliminar" ButtonType="Image" ImageUrl="~/images/gv/delete.gif" />
                </Columns>
            </asp:GridView>
            <%--[id_pago],[orden],[orden_string],[fecha],[monto],[estado],[pagado],[estado_detalle],[permitir_pago]--%>
            <asp:ObjectDataSource ID="ods_pago_lista" runat="server" TypeName="terrasur.traspaso.pago" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_reembolso" Type="Int32" ControlID="lbl_id_reembolso" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </td>
    </tr>
</table>

