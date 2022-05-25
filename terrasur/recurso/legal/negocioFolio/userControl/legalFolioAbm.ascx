<%@ Control Language="C#" ClassName="legalFolioAbm" %>

<script runat="server">
    public event EventHandler FolioLoteElegido;
    protected virtual void ElegirFolioLote(object sender)
    {
        if (this.FolioLoteElegido != null)
            this.FolioLoteElegido(sender, new EventArgs());
    }

    public event EventHandler FolioTodosElegido;
    protected virtual void ElegirFolioTodos(object sender)
    {
        if (this.FolioTodosElegido != null)
            this.FolioTodosElegido(sender, new EventArgs());
    }

    public event EventHandler CancelarElegido;
    protected virtual void ElegirCancelar(object sender)
    {
        if (this.CancelarElegido != null)
            this.CancelarElegido(sender, new EventArgs());
    }

    public int id_lote
    {
        get { return int.Parse(lbl_id_lote.Text); }
        set
        {
            lbl_id_lote.Text = value.ToString();

            if (value > 0)
            {
                lbl_lote_enun.Visible = true;
                gv_lote.Visible = true;
                gv_lote.DataBind();

                legal_folio fObj = new legal_folio(value);
                txt_num_folio.Text = fObj.numero;
                if (fObj.entregado == false) rbl_entregado.SelectedValue = "0"; else rbl_entregado.SelectedValue = "1"; 
                cp_fecha.Visible = fObj.entregado;
                cp_fecha.SelectedDate = fObj.entregado_fecha;
                txt_observacion.Text = "";

                panel_folio.GroupingText = "Asignación de folio a un lote";
                btn_actualizar.Visible = true;
                btn_actualizar_varios.Visible = false;
            }
            else
            {
                lbl_lote_enun.Visible = false;
                gv_lote.Visible = false;

                txt_num_folio.Text = "";
                rbl_entregado.SelectedValue = "0";
                cp_fecha.Visible = false;
                txt_observacion.Text = "";

                panel_folio.GroupingText = "Asignación de folios a varios lotes";
                btn_actualizar.Visible = false;
                btn_actualizar_varios.Visible = true;
            }
            txt_num_folio.Focus();
        }
    }

    public string num_folio { get { return txt_num_folio.Text.Trim(); } }
    public bool entregado { get { return rbl_entregado.SelectedValue.Equals("1"); } }
    public DateTime entregado_fecha { get { if (rbl_entregado.SelectedValue.Equals("1") == true) { return cp_fecha.SelectedDate; } else { return DateTime.Now; } } }
    public string observacion { get { return txt_observacion.Text.Trim(); } }

    protected void rbl_entregado_SelectedIndexChanged(object sender, EventArgs e)
    {
        cp_fecha.Visible = rbl_entregado.SelectedValue.Equals("1");
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        ElegirFolioLote(sender);
    }

    protected void btn_actualizar_varios_Click(object sender, EventArgs e)
    {
        ElegirFolioTodos(sender);
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        ElegirCancelar(sender);
    }
</script>
<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_folio" runat="server" GroupingText="Asignación de folios a varios lotes">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <%--[id_lote],[localizacion],[sector],[manzano],[lote],[superficie]--%>
                <asp:ObjectDataSource ID="ods_lista_lote" runat="server" TypeName="terrasur.legal_negocio_lote" SelectMethod="ListaDatosLote">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td align="left" valign="top"><asp:Label ID="lbl_lote_enun" runat="server" Text="Lote:" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left" colspan="2">
                            <asp:GridView ID="gv_lote" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_lote" DataKeyNames="id_lote">
                                <Columns>
                                    <asp:BoundField HeaderText="Loc." DataField="localizacion" />
                                    <asp:BoundField HeaderText="Sector" DataField="sector" />
                                    <asp:BoundField HeaderText="Mzno." DataField="manzano" />
                                    <asp:BoundField HeaderText="Lote" DataField="lote" />
                                    <asp:BoundField HeaderText="Sup.(m2)" DataField="superficie" HtmlEncode="false" DataFormatString="{0:F2}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="lbl_folio_enun" runat="server" Text="Nº folio:" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txt_num_folio" runat="server" SkinID="txtSingleLine100" MaxLength="13"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_num_folio" runat="server" ControlToValidate="txt_num_folio" Display="Dynamic" Text="*" ErrorMessage="Debe introducir el número de folio" ValidationGroup="lote"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev_num_folio" runat="server" ControlToValidate="txt_num_folio" Display="Dynamic" Text="*" ErrorMessage="El número de folio debe tener 13 números" ValidationExpression="([0-9]){13}" ValidationGroup="lote"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="lbl_entregado_enun" runat="server" Text="Entregado" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_entregado" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_entregado_SelectedIndexChanged">
                                <asp:ListItem Text="No entregado" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Entregado" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td><ew:CalendarPopup ID="cp_fecha" runat="server" DisableTextBoxEntry="false"></ew:CalendarPopup></td>
                    </tr>
                    <tr>
                        <td valign="top" align="left"><asp:Label ID="lbl_observacion_enun" runat="server" Text="Observación:" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txt_observacion" runat="server" Columns="40" Rows="2" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>        
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td><asp:Button ID="btn_actualizar" runat="server" Text="Actualizar datos" ValidationGroup="lote" CausesValidation="true" OnClick="btn_actualizar_Click" /></td>
                        <td><asp:Button ID="btn_actualizar_varios" runat="server" Text="Aplicar a lotes seleccionados" ValidationGroup="lote" CausesValidation="true" OnClick="btn_actualizar_varios_Click" /></td>
                        <td><asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btn_cancelar_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
