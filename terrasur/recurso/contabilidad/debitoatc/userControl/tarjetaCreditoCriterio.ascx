<%@ Control Language="C#" ClassName="tarjetaCreditoCriterio" %>

<script runat="server">
    public int id_tipotarjetacredito { get { if (ddl_tipo_tarjeta.Items.Count == 0) return 0; else return int.Parse(ddl_tipo_tarjeta.SelectedValue); } }
    public int id_banco { get { if (ddl_banco.Items.Count == 0) return 0; else return int.Parse(ddl_banco.SelectedValue); } }
    public string num_tarjeta { get { return txt_num_tarjeta.Text.Trim(); } }
    public string titular { get { return txt_titular.Text.Trim(); } }
    public string ci { get { return txt_ci.Text.Trim(); } }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } }
    public int activo { get { return int.Parse(ddl_activo.SelectedValue); } }

    public void Reset()
    {
        ddl_tipo_tarjeta.DataBind();
        ddl_banco.DataBind();
        txt_num_tarjeta.Text = "";
        txt_titular.Text = "";
        txt_ci.Text = "";
        txt_num_contrato.Text = "";
        ddl_activo.SelectedValue = "-1";
    }

    public bool TieneCriterio()
    {
        if (int.Parse(ddl_tipo_tarjeta.SelectedValue) > 0) return true;
        else if (int.Parse(ddl_banco.SelectedValue) > 0) return true;
        else if (txt_num_tarjeta.Text.Trim() != "") return true;
        else if (txt_titular.Text.Trim() != "") return true;
        else if (txt_ci.Text.Trim() != "") return true;
        else if (txt_num_contrato.Text.Trim() != "") return true;
        else if (ddl_activo.SelectedValue != "-1") return true;
        txt_num_tarjeta.Focus();
        return false;
    }
    
    protected void ddl_tipo_tarjeta_DataBound(object sender, EventArgs e)
    {
        ddl_tipo_tarjeta.Items.Insert(0, new ListItem("Todos", "0"));
    }

    protected void ddl_banco_DataBound(object sender, EventArgs e)
    {
        ddl_banco.Items.Insert(0, new ListItem("Todos", "0"));
    }

</script>
<asp:ValidationSummary ID="vs_criterio" runat="server" DisplayMode="List" ValidationGroup="criterio" />
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdEnun">Tipo de tarjeta</td>
        <td class="formHorTdEnun">Banco</td>
        <td class="formHorTdEnun">Nº tarjeta</td>
        <td class="formHorTdEnun">Titular</td>
        <td class="formHorTdEnun">C.I.</td>
        <td class="formHorTdEnun">Nº contrato</td>
        <td class="formHorTdEnun">Activo</td>
    </tr>
    <tr>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_tipo_tarjeta" runat="server" DataSourceID="ods_lista_tipo_tarjeta" DataTextField="nombre" DataValueField="id_tipotarjetacredito" OnDataBound="ddl_tipo_tarjeta_DataBound">
            </asp:DropDownList>
            <%--[id_tipotarjetacredito],[codigo],[nombre],[num_tarjetas]--%>
            <asp:ObjectDataSource ID="ods_lista_tipo_tarjeta" runat="server" TypeName="terrasur.tipo_tarjeta_credito" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_banco" runat="server" DataSourceID="ods_lista_banco" DataTextField="nombre" DataValueField="id_banco" OnDataBound="ddl_banco_DataBound">
            </asp:DropDownList>
            <%--[id_banco],[id_usuario],[codigo],[nombre],[activo],[num_cheques]--%>
            <asp:ObjectDataSource ID="ods_lista_banco" runat="server" TypeName="terrasur.banco" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_num_tarjeta" runat="server" SkinID="txtSingleLine100" MaxLength="30"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_titular" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_activo" runat="server">
                <asp:ListItem Text="Todos" Value="-1" Selected="True" />
                <asp:ListItem Text="Activo" Value="1" />
                <asp:ListItem Text="Inactivo" Value="0" />
            </asp:DropDownList>
        </td>
    </tr>
</table>