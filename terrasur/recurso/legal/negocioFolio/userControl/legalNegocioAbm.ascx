<%@ Control Language="C#" ClassName="legalNegocioAbm" %>

<script runat="server">
    public event EventHandler NegocioLoteElegido;
    protected virtual void ElegirNegocioLote(object sender)
    {
        if (this.NegocioLoteElegido != null)
            this.NegocioLoteElegido(sender, new EventArgs());
    }

    public event EventHandler NegocioTodosElegido;
    protected virtual void ElegirNegocioTodos(object sender)
    {
        if (this.NegocioTodosElegido != null)
            this.NegocioTodosElegido(sender, new EventArgs());
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

            ddl_negocio.DataBind();
            rbl_estado_tramite.DataBind();

            if (value > 0)
            {
                lbl_lote_enun.Visible = true;
                gv_lote.Visible = true;
                gv_lote.DataBind();

                legal_negocio_lote nlObj = new legal_negocio_lote(legal_negocio_lote.Id_negociolote_actual(value));

                if (nlObj.id_negocio > 0) { if (ddl_negocio.Items.FindByValue(nlObj.id_negocio.ToString()) != null) ddl_negocio.SelectedValue = nlObj.id_negocio.ToString(); }
                else { if (ddl_negocio.Items.Count > 0) ddl_negocio.SelectedIndex = 0; }

                if (nlObj.id_estadotramite > 0) { if (rbl_estado_tramite.Items.FindByValue(nlObj.id_estadotramite.ToString()) != null) rbl_estado_tramite.SelectedValue = nlObj.id_estadotramite.ToString(); }
                else { if (rbl_estado_tramite.Items.Count > 0) rbl_estado_tramite.SelectedIndex = 0; }

                cp_fecha.SelectedDate = nlObj.fecha;

                panel_negocio.GroupingText = "Asignación de negocio a un lote";
                btn_actualizar.Visible = true;
                btn_actualizar_varios.Visible = false;
            }
            else
            {
                lbl_lote_enun.Visible = false;
                gv_lote.Visible = false;

                if (ddl_negocio.Items.Count > 0) ddl_negocio.SelectedIndex = 0;
                if (rbl_estado_tramite.Items.Count > 0) rbl_estado_tramite.SelectedIndex = 0;
                cp_fecha.SelectedDate = DateTime.Now;

                panel_negocio.GroupingText = "Asignación de negocios a varios lotes";
                btn_actualizar.Visible = false;
                btn_actualizar_varios.Visible = true;
            }
            cp_fecha.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "update_negocio_fecha");
        }
    }

    public int id_negocio { get { if (ddl_negocio.Items.Count > 0) return int.Parse(ddl_negocio.SelectedValue); else return 0; } }
    public int id_estadotramite { get { if (rbl_estado_tramite.Items.Count > 0 && rbl_estado_tramite.SelectedIndex>=0) return int.Parse(rbl_estado_tramite.SelectedValue); else return 0; } }
    public DateTime fecha { get { return cp_fecha.SelectedDate; } }

    protected void rbl_estado_tramite_DataBound(object sender, EventArgs e)
    {
        if (rbl_estado_tramite.Items.Count > 0) rbl_estado_tramite.SelectedIndex = 0;
    }


    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        ElegirNegocioLote(sender);
    }

    protected void btn_actualizar_varios_Click(object sender, EventArgs e)
    {
        ElegirNegocioTodos(sender);
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        ElegirCancelar(sender);
    }
</script>
<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_negocio" runat="server" GroupingText="Asignación de negocios a lotes">
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
                        <td align="left">
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
                        <td align="left"><asp:Label ID="lbl_negocio_enun" runat="server" Text="Negocio:" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio">
                            </asp:DropDownList>
                            <%--[id_negocio],[codigo],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.legal_negocio" SelectMethod="Lista">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="lbl_estado_enun" runat="server" Text="Estado:" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_estado_tramite" runat="server" DataSourceID="ods_lista_estado_tramite" DataTextField="nombre" DataValueField="id_estadotramite" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnDataBound="rbl_estado_tramite_DataBound">
                            </asp:RadioButtonList>
                            <%--[id_estadotramite],[codigo],[nombre],[orden]--%>
                            <asp:ObjectDataSource ID="ods_lista_estado_tramite" runat="server" TypeName="terrasur.legal_estado_tramite" SelectMethod="Lista">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha:" SkinID="lblEnun"></asp:Label></td>
                        <td style="width:10px;"></td>
                        <td align="left"><ew:CalendarPopup ID="cp_fecha" runat="server" DisableTextBoxEntry="false"></ew:CalendarPopup></td>
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
