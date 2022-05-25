<%@ Control Language="C#" ClassName="contratoEmisionRegistro" %>

<script runat="server">
    public event EventHandler Continuar;
    protected virtual void PermitirContinuar(object sender)
    { if (this.Continuar != null)this.Continuar(sender, new EventArgs()); }
    
    
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    private string codigo_tipo_documento { get { return lbl_codigo_tipo_documento.Text; } set { lbl_codigo_tipo_documento.Text = value; } }


    public void Cargar(int Id_contrato, string Codigo_tipo_documento)
    {
        id_contrato = Id_contrato;
        codigo_tipo_documento = Codigo_tipo_documento;
        
        rbl_cliente.DataBind();
        rbl_cliente.Focus();

        string nombre_tipo_documento = terrasur.emDoc.emision.NombreTipoDocumentoPorCodigo(codigo_tipo_documento);
        panel_registro.GroupingText = "Registro de emisión del: " + nombre_tipo_documento;

        bool permitirAcceso = VerificarPermisosDeAcceso();
        btn_continuar.Enabled = permitirAcceso;
        rbl_cliente.Enabled = permitirAcceso;
    }

    protected void rbl_cliente_DataBound(object sender, EventArgs e)
    {
        rbl_cliente.Items.Add(new ListItem("Otro", "0")); rbl_cliente.SelectedIndex = 0;
        rbl_cliente.SelectedIndex = 0;
        
        HabilitarOtrosControles();
    }

    protected void rbl_cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        HabilitarOtrosControles();
    }

    protected void btn_continuar_Click(object sender, EventArgs e)
    {
        //if (terrasur.emDoc.emision.Verificar(codigo_tipo_documento, id_contrato))
        if (VerificarPermisosDeAcceso())
        {
            Registrar();
            PermitirContinuar(sender);
        }
    }

    protected bool VerificarPermisosDeAcceso()
    {
        bool permitir = false;
        
        if (terrasur.emDoc.emision.Verificar(codigo_tipo_documento, id_contrato))
        {
            permitir = true;
            lbl_limite_visualizacion.Text = "";
        }
        else
        {
            permitir = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "emisionDocCliente", "restringirPlazo").Equals(false);
            if (permitir == false) { if (Profile.entorno.codigo_modulo == "adm" || Profile.entorno.id_rol == 1) { permitir = true; } }

            //Se despliega el mensaje            
            parametro pObj = new parametro("emision_periodo_ec");
            string nombre_tipo_documento = terrasur.emDoc.emision.NombreTipoDocumentoPorCodigo(codigo_tipo_documento);
            lbl_limite_visualizacion.Text = "El " + nombre_tipo_documento + " del contrato ya se emitió para el cliente en los pasados " + pObj.valor.ToString("F0") + " meses";
        }
        return permitir;
    }
    
    protected void HabilitarOtrosControles()
    {
        bool habilitar = rbl_cliente.SelectedValue.Equals("0");

        panel_otro.Visible = habilitar;
        rfv_nombre.Enabled = habilitar;
        rev_nombre.Enabled = habilitar;
        rev_ci.Enabled = habilitar;

        if (habilitar)
        {
            txt_nombre.Text = "";
            txt_ci.Text = "";
            ddl_lugar_cedula.SelectedIndex = ddl_lugar_cedula.Items.Count - 1;
            txt_nombre.Focus();
        }
    }
    
    public bool Registrar()
    {
        int id_cliente = 0;
        string nombre = "";
        string ci = "";
        if (int.Parse(rbl_cliente.SelectedValue) > 0)
        {
            id_cliente = int.Parse(rbl_cliente.SelectedValue);
            cliente cObj = new cliente(id_cliente);
            nombre = (cObj.nombres + " " + cObj.paterno + " " + cObj.materno).Trim();
            ci = cObj.ci; if (cObj.codigo_lugarcedula.Trim() != "") { ci = ci + " " + cObj.codigo_lugarcedula; }
        }
        else
        {
            nombre = txt_nombre.Text.Trim();
            ci = txt_ci.Text.Trim();
            if (ci != "" && ddl_lugar_cedula.SelectedItem.Text.Trim() != "") { ci = ci + " " + ddl_lugar_cedula.SelectedItem.Text.Trim(); }
        }
        terrasur.emDoc.emision eObj = new terrasur.emDoc.emision("ec", id_contrato, Profile.id_usuario, id_cliente, nombre, ci);

        if (eObj.Registrar()) { return true; }
        else { return false; }
    }
    
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_tipo_documento" runat="server" Text="" Visible="false"></asp:Label>

<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="center">
            <asp:Label ID="lbl_limite_visualizacion" runat="server" ForeColor="Red" Font-Size="14"></asp:Label>
        </td>
    </tr>            
    <tr>
        <td>
            <asp:Panel ID="panel_registro" runat="server" GroupingText="Registro de emisión" DefaultButton="btn_continuar">
                <table class="formTable" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="formTdEnun">Cliente:</td>
                        <td class="formTdDato" style="width:600;">
                            <asp:RadioButtonList ID="rbl_cliente" runat="server" AutoPostBack="true" DataSourceID="ods_lista_clientes" DataTextField="nombre" DataValueField="id_cliente" CellPadding="0" CellSpacing="0" RepeatDirection="Vertical" OnDataBound="rbl_cliente_DataBound" OnSelectedIndexChanged="rbl_cliente_SelectedIndexChanged">
                            </asp:RadioButtonList>
                            <%--[id_cliente],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_lista_clientes" runat="server" TypeName="terrasur.emDoc.emision" SelectMethod="ListaTitulares">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun"></td>
                        <td class="formTdDato">
                            <asp:Panel ID="panel_otro" runat="server" Visible="false">
                                <table cellpadding="0" cellspacing="0" align="left">
                                    <tr>
                                        <td style="padding-right:10px;"><asp:Label ID="lbl_nombre" runat="server" Text="Nombre:" SkinID="lblEnun"></asp:Label></td>
                                        <td style="padding-right:10px;">
                                            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="registro" Text="*" ErrorMessage="Debe introducir el nombre de la persona que solicita la emisión del documento"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="registro" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre de la persona contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                        </td>
                                        <td style="padding-right:10px;"><asp:Label ID="lbl_ci" runat="server" Text="CI:" SkinID="lblEnun"></asp:Label></td>
                                        <td style="padding-right:10px;">
                                            <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine100"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="registro" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                        </td>
                                        <td style="padding-right:10px;">
                                            <asp:DropDownList ID="ddl_lugar_cedula" runat="server" DataSourceID="ods_lista_lugar_cedula" DataTextField="codigo" DataValueField="id_lugarcedula">
                                            </asp:DropDownList>
                                            <%--[id_lugarcedula],[codigo],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_lugar_cedula" runat="server" TypeName="terrasur.lugar_cedula" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <%--ButtonAction--%>
                            <asp:ButtonAction ID="btn_continuar" runat="server" Text="Continuar" TextoEnviando="Cargando..." CausesValidation="true" ValidationGroup="registro" OnClick="btn_continuar_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
