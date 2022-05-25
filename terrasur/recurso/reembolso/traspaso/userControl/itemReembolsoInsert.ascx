<%@ Control Language="C#" ClassName="itemReembolsoInsert" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Text" %>

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
    
    private bool traspaso { get { return bool.Parse(lbl_traspaso.Text); } set { lbl_traspaso.Text = value.ToString(); } }
    private DateTime fecha { get { return DateTime.Parse(lbl_fecha.Text); } set { lbl_fecha.Text = value.ToString(); } }
    public int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    public decimal monto_total { get { return terrasur.traspaso.tmpItemReembolso.MontoTotal(strItem); } }
    string tipo_reembolso_string { get { if (traspaso) { return "traspasarse"; } else { return "devolverse"; } } }
    
    private string strItem { get { return lbl_strItem.Text; } set { lbl_strItem.Text = value; } }

    public void CargarInsertar(bool Traspaso, int Id_contrato, DateTime Fecha)
    {
        traspaso = Traspaso;
        id_contrato = Id_contrato;
        fecha = Fecha;
        
        ddl_item.DataBind();
        txt_monto.Text = "";
        
        lbl_moneda.Text = contrato.CodigoMoneda(id_contrato);
        gv_item.Columns[2].HeaderText = "Monto (" + lbl_moneda.Text + ")";
        strItem = terrasur.traspaso.tmpItemReembolso.ListaPreliminar(Traspaso, Id_contrato, Fecha);
        gv_item.DataBind();

        string aux_trasp = "el Traspaso"; if (!Traspaso) { aux_trasp = "la Devolución"; }
        lbl_nota_item.ToolTip = "Dado que los elementos y datos definidos en esta sección son producto de un análisis y verificación específica, la correcta definición de los mismos es responsabilidad de la persona que procesa " + aux_trasp + ".";
    }

    public bool VerificarInsertar()
    {
        bool correcto = true;
        if (terrasur.traspaso.tmpItemReembolso.MontoTotal(strItem) <= 0)
        {
            Msg1.Text = "El monto a " + tipo_reembolso_string + " debe ser mayor a 0";
            correcto = false;
        }
        return correcto;
    }

    public bool Insertar(int Id_reembolso)
    {
        //if (VerificarInsertar())
        //{
        bool correcto = true;
        foreach (terrasur.traspaso.tmpItemReembolso i in terrasur.traspaso.tmpItemReembolso.Cadena_a_Lista(strItem))
        {
            if (new terrasur.traspaso.item_reembolso(i.id_item, Id_reembolso, i.preliminar, i.monto).Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host) == false)
            {
                correcto = false;
            }
        }
        if (correcto) { return true; }
        else
        {
            Msg1.Text = "Los elementos NO se registraron correctamente";
            return false;
        }
        //}
        //else { return false; }
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
            strItem = terrasur.traspaso.tmpItemReembolso.Agregar(strItem, Id_item, id_contrato, fecha, Monto);

            gv_item.DataBind();
            ddl_item.SelectedValue = "0";
            txt_monto.Text = "";

            RealizarEleccion(sender);
        }
    }

    private bool VerificarAgregar()
    {
        bool correcto = false;

        int Id_item = int.Parse(ddl_item.SelectedValue);
        if (Id_item > 0)
        {
            if (terrasur.traspaso.tmpItemReembolso.Verificar(strItem, Id_item) == false)
            {
                if (!string.IsNullOrEmpty(txt_monto.Text.Trim()))
                {
                    decimal Monto = decimal.Parse(txt_monto.Text.Trim());
                    if (Monto > 0)
                    {
                        if ((new terrasur.traspaso.item(Id_item)).incremento)
                        {
                            decimal Monto_predeterminado = terrasur.traspaso.item.MontoPredeterminadoPorContrato(Id_item, id_contrato, fecha);
                            if (Monto <= Monto_predeterminado)
                            {
                                correcto = true;
                            }
                            else { Msg1.Text = "El monto no puede ser mayor a " + Monto_predeterminado.ToString("N2"); }
                        }
                        else { correcto = true; }
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
            strItem = strItem = terrasur.traspaso.tmpItemReembolso.Retirar(strItem, Id_item);
            gv_item.DataBind();

            if (ddl_item.Items.FindByValue(Id_item.ToString()) != null) { ddl_item.SelectedValue = Id_item.ToString(); } txt_monto.Focus();

            RealizarEleccion(sender);
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
            decimal _Monto_predeterminado = terrasur.traspaso.item.MontoPredeterminadoPorContrato(Id_item, id_contrato, fecha);
            if (_Monto_predeterminado > 0) { txt_monto.Text = _Monto_predeterminado.ToString(); }
            else { txt_monto.Text = ""; }
        }
        else { txt_monto.Text = ""; }
        txt_monto.Focus();
    }

</script>

<asp:Label ID="lbl_traspaso" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_fecha" runat="server" Text="01/01/1900" Visible="false"></asp:Label>

<asp:Label ID="lbl_strItem" runat="server" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg">
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
            <table cellpadding="0" cellspacing="0" align="center">
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
                        <asp:TextBox ID="txt_monto" runat="server" Width="75" MaxLength="9"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="itree" Text="*" ErrorMessage="Debe introducir el monto"></asp:RequiredFieldValidator>--%>
                        <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="itree" Text="*" ErrorMessage="El monto es incorrecto" Type="Double" MinimumValue="0" MaximumValue="999999"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:Label ID="lbl_moneda" runat="server" SkinID="lblEnun"></asp:Label>
                    </td>
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
                    <asp:BoundField HeaderText="Monto" DataField="monto" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:ButtonField CommandName="retirar" Text="Eliminar" ButtonType="Image" ImageUrl="~/images/gv/delete.gif" />
                </Columns>
            </asp:GridView>
            <%--[id_item],[incremento],[incremento_string],[nombre],[preliminar],[monto]--%>
            <asp:ObjectDataSource ID="ods_itemReembolso_lista" runat="server" TypeName="terrasur.traspaso.tmpItemReembolso" SelectMethod="Cadena_a_tabla">
                <SelectParameters>
                    <asp:ControlParameter Name="strItem" Type="String" ControlID="lbl_strItem" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
