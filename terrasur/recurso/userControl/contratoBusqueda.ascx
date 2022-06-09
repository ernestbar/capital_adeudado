<%@ Control Language="C#" ClassName="contratoBusqueda" %>

<script runat="server">
    public event EventHandler Eleccion;
    protected virtual void RealizarEleccion(object sender)
    {
        bool correcto = true;
        if (buscar_contrato == true)
        {
            //  7 (M.Tejerina); ; 709 (Carlos Mercado)
            if (Profile.id_usuario == 7 || Profile.id_usuario == 709)
            { correcto = true; }
            else
            {
                if (contrato_estado_especial.BloquearContrato(id_resultado, Profile.entorno.codigo_modulo) == true)
                {
                    if (rbl_contrato_cliente.Items.FindByValue(id_resultado.ToString()) != null)
                    {
                        rbl_contrato_cliente.Items.Remove(rbl_contrato_cliente.Items.FindByValue(id_resultado.ToString()));
                    }
                    Msg1.Text = "CONTRATO BLOQUEADO";
                    correcto = false;
                }
            }
            
        }
        if (correcto == true)
        {
            if (this.Eleccion != null)
                this.Eleccion(sender, new EventArgs());
        }

        //if (this.Eleccion != null)
        //    this.Eleccion(sender, new EventArgs());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Reset();
        }
    }

    public bool buscar_contrato
    {
        get { return bool.Parse(lbl_buscar_contrato.Text); }
        set
        {
            lbl_buscar_contrato.Text = value.ToString();
            if (value == true)
            {
                panel_resultados.GroupingText = "Búsqueda de contrato";
                btn_buscar.Text = "Buscar contrato";
            }
            else
            {
                panel_resultados.GroupingText = "Búsqueda de cliente";
                btn_buscar.Text = "Buscar cliente";
            }
        }
    }
    public int id_resultado { get { return Int32.Parse(lbl_id_resultado.Text); } set { lbl_id_resultado.Text = value.ToString(); } }
    
    public void Reset()
    {
        txt_numero.Text = "";
        txt_ci.Text = "";
        txt_nombres.Text = "";
        if (buscar_contrato == true) txt_numero.Focus();
        else txt_ci.Focus();
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        if (txt_numero.Text.Trim() == "" && txt_ci.Text.Trim() == "" && txt_nombres.Text.Trim() == "")
            Msg1.Text = "Debe introducir un criterio de búsqueda";
        else rbl_contrato_cliente.DataBind();

        if (buscar_contrato == true) txt_numero.Focus();
        else txt_ci.Focus();
    }

    protected void rbl_contrato_cliente_DataBound(object sender, EventArgs e)
    {
        int num_resultados = rbl_contrato_cliente.Items.Count;

        if (num_resultados == 0)
            if (txt_numero.Text.Trim() == "" && txt_ci.Text.Trim() == "" && txt_nombres.Text.Trim() == "") lbl_resultados_enun.Text = "";
            else lbl_resultados_enun.Text = "La búsqueda no tuvo resultados";
        else if (num_resultados == 1) lbl_resultados_enun.Text = "La búsqueda tuvo 1 resultado";
        else lbl_resultados_enun.Text = "La búsqueda tuvo " + num_resultados + " resultados";

        if (num_resultados == 1)
        {
            if (contrato.BusquedaExactaVerificacion(buscar_contrato, txt_numero.Text.Trim(),
                txt_ci.Text.Trim(), txt_nombres.Text.Trim()) == true)
            {
                rbl_contrato_cliente.SelectedIndex = 0;
                id_resultado = int.Parse(rbl_contrato_cliente.SelectedValue);
                RealizarEleccion(sender);
            }
            else { rbl_contrato_cliente.SelectedIndex = -1; }

        }
        else if (num_resultados > 1) { rbl_contrato_cliente.SelectedIndex = -1; }

        //Se muestra o se oculta un ScrollBar para los resultados encontrados
        int num_resultados_visibles = 3;
        if (num_resultados > num_resultados_visibles)
        {
            panel_opciones.ScrollBars = ScrollBars.Vertical;
            panel_opciones.Height = Unit.Pixel(25 * num_resultados_visibles);
        }
        else if (num_resultados == 0)
        {
            panel_opciones.ScrollBars = ScrollBars.None;
            panel_opciones.Height = Unit.Pixel(0);
        }
        else
        {
            panel_opciones.ScrollBars = ScrollBars.None;
            panel_opciones.Height = Unit.Percentage(100);
        }
    }

    protected void rbl_contrato_cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbl_contrato_cliente.SelectedIndex >= 0)
        {
            id_resultado = int.Parse(rbl_contrato_cliente.SelectedValue);
            RealizarEleccion(sender);
        }
    }

</script>
<asp:Label ID="lbl_buscar_contrato" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_resultado" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:panel ID="panel_resultados" runat="server" GroupingText="Búsqueda de contrato" DefaultButton="btn_buscar">
                <table class="contratoBuscarTable">
                    <tr>
                        <td class="contratoBuscarTdCriterio">
                            <table class="contratoBuscarCriterioTable" align="center">
                                <tr>
                                    <td class="contratoBuscarCriterioTdEnun">Nº de contrato:</td>
                                    <td>
                                        <asp:TextBox ID="txt_numero" runat="server" SkinID="txtSingleLine200" MaxLength="25"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rev_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="busqueda_contrato" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*" ErrorMessage="El número del contrato contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    </td>
                                </tr>
                                <tr>
                                    <td class="contratoBuscarCriterioTdEnun">C.I. del cliente:</td>
                                    <td>
                                        <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine200" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="busqueda_contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. del cliente contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    </td>
                                </tr>
                                <tr>
                                    <td class="contratoBuscarCriterioTdEnun">Nombre del cliente:</td>
                                    <td>
                                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="10"
                                            ServicePath="~/ServicioWeb.asmx" ServiceMethod="NombreCliente"
                                            TargetControlID="txt_nombres" MinimumPrefixLength="2" CompletionInterval="500" EnableCaching="true"
                                            CompletionListCssClass="completionList" CompletionListItemCssClass="completionListItem" CompletionListHighlightedItemCssClass="completionListHighlightedItem">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <asp:TextBox ID="txt_nombres" runat="server" SkinID="txtSingleLine200" MaxLength="100" autocomplete="off"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rev_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="busqueda_contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre de cliente contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    </td>
                                </tr>
                                <tr>
                                    <td class="contratoBuscarCriterioTdButton" colspan="2">
                                        <%--<asp:Button ID="btn_buscar" runat="server" Text="Buscar contrato" CausesValidation="true" ValidationGroup="busqueda_contrato" OnClick="btn_buscar_Click" />--%>
                                        <asp:ButtonAction ID="btn_buscar" runat="server" Text="Buscar contrato" TextoEnviando="Buscando" CausesValidation="true" ValidationGroup="busqueda_contrato" OnClick="btn_buscar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoBuscarTdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            <asp:ValidationSummary ID="vs_contrato" runat="server" DisplayMode="List" ValidationGroup="busqueda_contrato" />
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoBuscarTdResultado">
                            <asp:Label ID="lbl_resultados_enun" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoBuscarTdOpciones">
                            <table align="center" cellspacing="0" cellpadding="0"><tr><td>
                            <asp:Panel ID="panel_opciones" runat="server" HorizontalAlign="Left">
                                <asp:RadioButtonList ID="rbl_contrato_cliente" runat="server" AutoPostBack="true" DataTextField="texto" DataValueField="id" DataSourceID="ods_lista_resultado" OnDataBound="rbl_contrato_cliente_DataBound" OnSelectedIndexChanged="rbl_contrato_cliente_SelectedIndexChanged">
                                </asp:RadioButtonList>
                            </asp:Panel>
                            </td></tr></table>
                        </td>
                    </tr>
                </table>
            </asp:panel>
        </td>
    </tr>
</table>

<%--[id],[texto]--%>
<asp:ObjectDataSource ID="ods_lista_resultado" runat="server" TypeName="terrasur.contrato" SelectMethod="BusquedaContratoCliente">
    <SelectParameters>
        <asp:ControlParameter Name="Buscar_contrato" Type="Boolean" ControlID="lbl_buscar_contrato" PropertyName="Text" />
        <asp:ControlParameter Name="Numero" Type="String" ControlID="txt_numero" PropertyName="Text" />
        <asp:ControlParameter Name="Ci" Type="String" ControlID="txt_ci" PropertyName="Text" />
        <asp:ControlParameter Name="Nombres" Type="String" ControlID="txt_nombres" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>