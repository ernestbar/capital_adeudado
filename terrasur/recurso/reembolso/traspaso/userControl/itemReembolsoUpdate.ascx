<%@ Control Language="C#" ClassName="itemReembolsoUpdate" %>

<script runat="server">    
    public event EventHandler Eleccion;
    protected virtual void RealizarEleccion(object sender)
    {
        if (this.Eleccion != null) this.Eleccion(sender, new EventArgs());
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_monto.Attributes["onblur"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeyup"] = "extractNumber(this,2,false);";
        txt_monto.Attributes["onkeypress"] = "return blockNonNumbers(this, event, true, false);";
    }

    private int id_reembolso { get { return int.Parse(lbl_id_reembolso.Text); } set { lbl_id_reembolso.Text = value.ToString(); } }
    private bool traspaso { get { return bool.Parse(lbl_traspaso.Text); } set { lbl_traspaso.Text = value.ToString(); } }
    string tipo_reembolso_string { get { if (traspaso) { return "traspasarse"; } else { return "devolverse"; } } }

    public void CargarActualizar(int Id_reembolso, bool Traspaso, string Codigo_moneda)
    {
        traspaso = Traspaso;

        lbl_moneda.Text = Codigo_moneda;
        gv_item.Columns[2].HeaderText = "Monto (" + Codigo_moneda + ")";
        id_reembolso = Id_reembolso;
        gv_item.DataBind();

        string aux_trasp = "el Traspaso"; if (!Traspaso) { aux_trasp = "la Devolución"; }
        lbl_nota_item.ToolTip = "Dado que los elementos y datos definidos en esta sección son producto de un análisis y verificación específica, la correcta definición de los mismos es responsabilidad de la persona que procesa " + aux_trasp + ".";
    }

    protected void ddl_item_DataBound(object sender, EventArgs e)
    {
        ddl_item.Items.Insert(0, new ListItem("", "0"));
    }

    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        if (VerificarAgregar())
        {
            int Id_item = int.Parse(ddl_item.SelectedValue);
            decimal Monto = decimal.Parse(txt_monto.Text.Trim());
            decimal Monto_preliminar = terrasur.traspaso.item.MontoPredeterminadoPorReembolso(Id_item, id_reembolso);
            if (new terrasur.traspaso.item_reembolso(Id_item, id_reembolso, Monto_preliminar, Monto).Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                gv_item.DataBind();

                RealizarEleccion(sender);
            }
            else { Msg1.Text = "El elemento " + (new terrasur.traspaso.item(Id_item)).nombre + " NO fue agregado correctamente"; }

        }
    }

    private bool VerificarAgregar()
    {
        bool correcto = false;

        int Id_item = int.Parse(ddl_item.SelectedValue);
        if (Id_item > 0)
        {
            if (terrasur.traspaso.item_reembolso.Verificar(id_reembolso, Id_item) == false)
            {
                if (!string.IsNullOrEmpty(txt_monto.Text.Trim()))
                {
                    decimal Monto = decimal.Parse(txt_monto.Text.Trim());
                    if (Monto > 0)
                    {
                        if ((new terrasur.traspaso.item(Id_item)).incremento)
                        {
                            decimal Monto_predeterminado = terrasur.traspaso.item.MontoPredeterminadoPorReembolso(Id_item, id_reembolso);
                            if (Monto <= Monto_predeterminado)
                            {
                                correcto = true;
                            }
                            else { Msg1.Text = "El monto no puede ser mayor a " + Monto_predeterminado.ToString("N2"); }
                        }
                        else
                        {
                            decimal _Monto_total = terrasur.traspaso.reembolso.MontoTotal(id_reembolso);
                            decimal _Monto_pagado = terrasur.traspaso.reembolso.MontoPagado(id_reembolso);
                            if ((_Monto_total - Monto) >= _Monto_pagado)
                            {
                                correcto = true;
                            }
                            else { Msg1.Text = "El monto de reducción produciría una inconsistencia respecto al monto ya asignado (" + lbl_moneda.Text + " " + _Monto_pagado.ToString("N2") + ")"; }
                        }
                    }
                    else { Msg1.Text = "El monto debe ser mayor a 0"; }
                }
                else { Msg1.Text = "Debe introducir el monto"; }
            }
            else { Msg1.Text = "El elemento " + (new terrasur.traspaso.item(Id_item)).nombre + " ya fue seleccionado"; }
        }
        return correcto;
    }

    protected void gv_item_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "retirar")
        {
            int Index = int.Parse(e.CommandArgument.ToString());
            int Id_item = (int)gv_item.DataKeys[Index].Value;

            decimal _Monto_total = terrasur.traspaso.reembolso.MontoTotal(id_reembolso);
            decimal _Monto_pagado = terrasur.traspaso.reembolso.MontoPagado(id_reembolso);
            decimal _Monto_item = terrasur.traspaso.item_reembolso.MontoItem(id_reembolso, Id_item);


            bool correcto = true;
            if ((new terrasur.traspaso.item(Id_item)).incremento)
            {
                if ((_Monto_total - _Monto_item) < _Monto_pagado)
                {
                    correcto = false;
                    Msg1.Text = "No es posible retirar el elemento seleccionado, pues se produciría una inconsistencia respecto al monto ya traspasado/devuelto";
                }
            }

            if (correcto)
            {
                if (new terrasur.traspaso.item_reembolso(Id_item, id_reembolso).Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
                {
                    gv_item.DataBind();

                    if (ddl_item.Items.FindByValue(Id_item.ToString()) != null) { ddl_item.SelectedValue = Id_item.ToString(); } txt_monto.Focus();
                    
                    RealizarEleccion(sender);
                }
                else { Msg1.Text = "El elemento \"" + (new terrasur.traspaso.item(Id_item)).nombre + "\" NO fue retirado correctamente"; }
            }
            
        }
    }

    protected void gv_item_DataBound(object sender, EventArgs e)
    {
        if (gv_item.Rows.Count > 0)
        {
            gv_item.Rows[gv_item.Rows.Count - 1].CssClass = "gvRowSelected";
            gv_item.Rows[gv_item.Rows.Count - 1].Cells[gv_item.Columns.Count - 1].Controls[0].Visible = false;
        }
    }

    protected void ddl_item_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Id_item = int.Parse(ddl_item.SelectedValue);
        if (Id_item > 0)
        {
            decimal _Monto_predeterminado = terrasur.traspaso.item.MontoPredeterminadoPorReembolso(Id_item, id_reembolso);
            if (_Monto_predeterminado > 0) { txt_monto.Text = _Monto_predeterminado.ToString(); }
            else { txt_monto.Text = ""; }
        }
        else { txt_monto.Text = ""; }
        txt_monto.Focus();
    }


</script>

<asp:Label ID="lbl_traspaso" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_reembolso" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_item" runat="server" DefaultButton="btn_agregar">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width:100px;" align="left"><asp:Label ID="lbl_nota_item" runat="server" SkinID="lblMsg" Text="NOTA"></asp:Label></td>
                    <td>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:Label ID="lbl_item_enun" runat="server" Text="Elemento:" SkinID="lblEnun"></asp:Label></td>
                    <td> 
                        <asp:DropDownList ID="ddl_item" runat="server" DataSourceID="ods_item_lista" DataTextField="nombre" DataValueField="id_item" AutoPostBack="true" OnDataBound="ddl_item_DataBound" OnSelectedIndexChanged="ddl_item_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--[id_item],[nombre]--%>
                        <asp:ObjectDataSource ID="ods_item_lista" runat="server" TypeName="terrasur.traspaso.item" SelectMethod="ListaParaDll">
                            <SelectParameters>
                                <asp:ControlParameter Name="Traspaso" Type="Boolean" ControlID="lbl_traspaso" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_monto" runat="server" Width="75" MaxLength="9" ValidationGroup="itree"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="itree" Text="*" ErrorMessage="Debe introducir el monto"></asp:RequiredFieldValidator>--%>
                        <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="itree" Text="*" ErrorMessage="El monto es incorrecto" Type="Double" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                    </td>
                    <td><asp:Label ID="lbl_moneda" runat="server" SkinID="lblEnun"></asp:Label></td>
                    <td><asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="itree" OnClick="btn_agregar_Click" /></td>
                </tr>
            </table>
                    </td>
                    <td style="width:100px;"></td>
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:ValidationSummary ID="vs_item" runat="server" DisplayMode="List" ValidationGroup="itree" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_item" runat="server" AutoGenerateColumns="false" DataSourceID="ods_itemReembolso_lista" DataKeyNames="id_item" OnRowCommand="gv_item_RowCommand" OnDataBound="gv_item_DataBound">
                <Columns>
                    <asp:BoundField DataField="incremento_string" />
                    <asp:BoundField HeaderText="Elemento" DataField="nombre" />
                    <asp:BoundField HeaderText="Monto" DataField="monto" ItemStyle-CssClass="gvCell1" HtmlEncode="false" DataFormatString="{0:N2}" />
                    <asp:ButtonField CommandName="retirar" Text="Eliminar" ButtonType="Image" ImageUrl="~/images/gv/delete.gif" />
                </Columns>
            </asp:GridView>
            <%--[id_item],[incremento],[incremento_string],[codigo],[nombre],[preliminar],[monto]--%>
            <asp:ObjectDataSource ID="ods_itemReembolso_lista" runat="server" TypeName="terrasur.traspaso.item_reembolso" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_reembolso" Type="Int32" ControlID="lbl_id_reembolso" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>