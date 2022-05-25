<%@ Control Language="C#" ClassName="contratoFormCliente" %>

<script runat="server">
    public int id_cliente { get { return Int32.Parse(lbl_id_cliente.Text); } set { lbl_id_cliente.Text = value.ToString(); } }
    public string strCl { get { return lbl_strCl.Text; } set { lbl_strCl.Text = value; } }

    public string ci { get { return txt_ci.Text.Trim(); } set { txt_ci.Text = value; } }
    public int id_lugarcedula { get { return int.Parse(ddl_lugar_cedula.SelectedValue); } set { ddl_lugar_cedula.SelectedValue = value.ToString(); } }
    public string paterno { get { return txt_paterno.Text.Trim(); } set { txt_paterno.Text = value; } }
    public string materno { get { return txt_materno.Text.Trim(); } set { txt_materno.Text = value; } }
    public string nombres { get { return txt_nombres.Text.Trim(); } set { txt_nombres.Text = value; } }
    public string nit { get { return txt_nit.Text.Trim(); } set { txt_nit.Text = value; } }
    public string celular { get { return txt_celular.Text.Trim(); } set { txt_celular.Text = value; } }
    public string email { get { return txt_email.Text.Trim(); } set { txt_email.Text = value; } }

    public bool HabilitarControles
    {
        get { return txt_paterno.Enabled; }
        set
        {
            //txt_ci.Enabled = value;
            ddl_lugar_cedula.Enabled = value;
            txt_paterno.Enabled = value;
            txt_materno.Enabled = value;
            txt_nombres.Enabled = value;
            txt_nit.Enabled = value;
            txt_celular.Enabled = value;
            txt_email.Enabled = value;
        }
    }
    
    public void Reset(bool limpiar_lista)
    {
        id_cliente = 0;
        if (limpiar_lista == true)
        {
            strCl = "";
            gv_clientes.DataBind();
        }
        HabilitarControles = true;
        ci = "";
        //ddl_lugar_cedula.DataBind();
        paterno = "";
        materno = "";
        nombres = "";
        nit = "";
        celular = "";
        email = "";
    }
    public void RecuperarDatos(int _id_cliente)
    {
        id_cliente = _id_cliente;
        cliente clienteObj = new cliente(_id_cliente);
        ci = clienteObj.ci;
        ddl_lugar_cedula.DataBind();
        ddl_lugar_cedula.SelectedValue = clienteObj.id_lugarcedula.ToString();
        paterno = clienteObj.paterno;
        materno = clienteObj.materno;
        nombres = clienteObj.nombres;
        nit = clienteObj.nit;
        celular = clienteObj.celular;
        email = clienteObj.email;
        txt_ci.Focus();
    }

    public bool Verificar()
    {
        if (ci != "")
        {
            VerificarCi();
            if (tmpCliente.Verificar(strCl, ci) == false)
            {
                strCl = tmpCliente.Insertar(strCl, id_cliente, ci, ddl_lugar_cedula.SelectedItem.Text,
                    paterno, materno, nombres, nit, celular, email);
                gv_clientes.DataBind();
                Reset(false);
                txt_ci.Focus();
                return true;
            }
            else
            {
                Msg1.Text = "El cliente ya esta registrado como titular del contrato";
                return false;
            }
        }
        else return true;
    }

    //public bool RevisarDatos()
    //{
    //    bool correcto = true;
    //    if (cliente.VerificarCI(id_cliente.Equals(0), id_cliente, ci) == true)
    //    {
    //        Msg1.Text = "El C.I. pertenece a un cliente registrado";
    //        correcto = false;
    //    }
    //    //if (cliente.VerificarNombreCompleto(id_cliente.Equals(0), id_cliente, nombres, paterno, materno) == true)
    //    //{
    //    //    Msg1.Text = "El nombre completo del cliente pertenece a otro cliente ya registrado";
    //    //    correcto = false;
    //    //}
    //    return correcto;
    //}

    private void VerificarCi()
    {
        if (ci != "" && ci != "0")
        {
            if (cliente.VerificarCI(true, 0, ci) == true)
            {
                RecuperarDatos(cliente.ObtenerIdPorCi(ci));
                HabilitarControles = false;
                Msg1.Text = "El C.I. pertenece a un cliente registrado";
            }
            else
            {
                id_cliente = 0;
                if (HabilitarControles == false) HabilitarControles = true;
            }
        }
        else
        {
            id_cliente = 0;
            if (HabilitarControles == false) { HabilitarControles = true; Reset(false); }
            Msg1.Text = "Debe introducir el C.I. del cliente";
        }
    }

    protected void lb_verificar_Click(object sender, EventArgs e)
    {
        VerificarCi();
    }

    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        VerificarCi();
        //if (tmpCliente.Verificar(strCl, ci, paterno, materno, nombres) == false)
        if (tmpCliente.Verificar(strCl, ci) == false)
        {
            strCl = tmpCliente.Insertar(strCl, id_cliente, ci, ddl_lugar_cedula.SelectedItem.Text,
                paterno, materno, nombres, nit, celular, email);
            gv_clientes.DataBind();
            Reset(false);
            txt_ci.Focus();
        }
        else { Msg1.Text = "El cliente ya esta registrado como titular del contrato"; }
    }
    protected void gv_clientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "retirar")
        {
            strCl = tmpCliente.Eliminar(strCl, int.Parse(e.CommandArgument.ToString()));
            gv_clientes.DataBind();
        }
    }

    protected void ddl_lugar_cedula_DataBound(object sender, EventArgs e)
    {
        ddl_lugar_cedula.Items.Insert(0, new ListItem("", "0"));
    }
</script>
<asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_strCl" runat="server" Visible="false"></asp:Label>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <table><tr><td><asp:Panel ID="panel_titular" runat="server" GroupingText="Datos del titular adicional">
            <table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdMsg" colspan="4">
                        <asp:Msg ID="Msg1" runat="server" Show="false"></asp:Msg>
                        <asp:ValidationSummary ID="vs_verificar_ci" runat="server" DisplayMode="List" ValidationGroup="verificar_ci" />
                        <asp:ValidationSummary ID="vs_cliente" runat="server" DisplayMode="List" ValidationGroup="cliente" />
                    </td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_ci" runat="server" Text="C.I."></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_paterno" runat="server" Text="Ap.Paterno"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_materno" runat="server" Text="Ap.Materno"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_nombres" runat="server" Text="Nombre"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_ci" runat="server" DefaultButton="lb_verificar">
                                    <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el C.I. del cliente"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    <asp:RegularExpressionValidator ID="rev_verificar_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="verificar_ci" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    </asp:Panel>
                                </td>
                                <td><asp:DropDownList ID="ddl_lugar_cedula" runat="server" DataSourceID="ods_lista_lugar_cedula" DataTextField="codigo" DataValueField="id_lugarcedula" OnDataBound="ddl_lugar_cedula_DataBound"></asp:DropDownList></td>
                                <td><asp:ImageButton ID="lb_verificar" runat="server" ImageUrl="~/images/verificar.gif" ToolTip="Verificar C.I." CausesValidation="true" ValidationGroup="verificar_ci" OnClick="lb_verificar_Click" /></td>
                            </tr>
                            <%--<tr><td colspan="2"><asp:LinkButton ID="lb_verificar" runat="server" Text="Verificar" CausesValidation="true" ValidationGroup="verificar_ci" OnClick="lb_verificar_Click"></asp:LinkButton></td></tr>--%>
                        </table>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_paterno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el apellido paterno"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido paterno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_materno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfv_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el apellido materno"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rev_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido materno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_nombres" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el nombre"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorEnun"></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_nit" runat="server" Text="NIT"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_celular" runat="server" Text="Celular"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato"></td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_nit" runat="server" SkinID="txtSingleLine100" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_celular" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_celular" runat="server" ControlToValidate="txt_celular" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_celular %>" Text="*" ErrorMessage="El Nº de celular contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_email" runat="server" SkinID="txtSingleLine100" MaxLength="200"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_email %>" Text="*" ErrorMessage="La dirección E-Mail es incorrecta"></asp:RegularExpressionValidator> 
                    </td>
                </tr>
                <tr>
                    <td class="contratoFormTdButton" colspan="4">
                        <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="cliente" OnClick="btn_agregar_Click" />
                    </td>
                </tr>
            </table>
            </asp:Panel></td></tr></table>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="gv_clientes" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_cliente_tmp" OnRowCommand="gv_clientes_RowCommand">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CausesValidation="false" Text="Retirar" CommandName="retirar" />
                    <asp:TemplateField HeaderText="C.I." ItemStyle-HorizontalAlign="Right"><ItemTemplate><asp:Label ID="lbl_ci" runat="server" Text='<%# String.Format("{0} {1}",Eval("ci"),Eval("codigo_lugar_cedula")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre completo"><ItemTemplate><asp:Label ID="lbl_nombre" runat="server" Text='<%# String.Format("{0} {1} {2}",Eval("paterno"),Eval("materno"),Eval("nombres")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:BoundField HeaderText="NIT" DataField="nit" />
                    <asp:BoundField HeaderText="Teléfono" DataField="fono" />
                    <asp:BoundField HeaderText="Email" DataField="email" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<%--[id_lugarcedula],[codigo],[nombre]--%>
<asp:ObjectDataSource ID="ods_lista_lugar_cedula" runat="server" TypeName="terrasur.lugar_cedula" SelectMethod="Lista"></asp:ObjectDataSource>
<%--[id_cliente],[ci],[codigo_lugar_cedula],[paterno],[materno],[nombres],[nit],[fono],[email]--%>
<asp:ObjectDataSource ID="ods_lista_cliente_tmp" runat="server" TypeName="terrasur.tmpCliente" SelectMethod="TablaCliente">
    <SelectParameters>
        <asp:ControlParameter Name="strCl" Type="String" ControlID="lbl_strCl" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>
