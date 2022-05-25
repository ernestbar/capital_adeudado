<%@ Control Language="C#" ClassName="clienteFormDireccion" %>

<script runat="server">
    public string domicilio_direccion { get { return txt_domicilio_direccion.Text.Trim(); } set { txt_domicilio_direccion.Text = value; } }
    public string domicilio_fono { get { return txt_domicilio_fono.Text; } set { txt_domicilio_fono.Text = value; } }
    public int domicilio_id_zona
    {
        get
        {
            if (string.IsNullOrEmpty(domicilio_direccion)) return 0;
            else return int.Parse(ddl_domicilio_zona.SelectedValue);
        }
        set
        {
            if (value > 0)
            {
                ddl_domicilio_zona.DataBind();
                ddl_domicilio_zona.SelectedValue = value.ToString();
            }
            else
            {
                ddl_domicilio_zona.DataBind();
                ddl_domicilio_zona.SelectedValue = "0";
            }
        }
    }
    public string oficina_direccion { get { return txt_oficina_direccion.Text.Trim(); } set { txt_oficina_direccion.Text = value; } }
    public string oficina_fono { get { return txt_oficina_fono.Text; } set { txt_oficina_fono.Text = value; } }
    public int oficina_id_zona
    {
        get
        {
            if (string.IsNullOrEmpty(oficina_direccion)) return 0;
            else return int.Parse(ddl_oficina_zona.SelectedValue);
        }
        set
        {
            if (value > 0)
            {
                ddl_oficina_zona.DataBind();
                ddl_oficina_zona.SelectedValue = value.ToString();
            }
            else
            {
                ddl_oficina_zona.DataBind();
                ddl_oficina_zona.SelectedValue = "0";
            }
        }
    }
    public int id_lugarcobro
    {
        get
        {
            if (rbl_lugar_cobro.SelectedIndex >= 0) return int.Parse(rbl_lugar_cobro.SelectedValue);
            else return 0;
        }
        set
        {
            if (value > 0) rbl_lugar_cobro.SelectedValue = value.ToString();
            else rbl_lugar_cobro.SelectedIndex = -1;
        }
    }

    public bool HabilitarControles
    {
        get { return txt_domicilio_direccion.Enabled; }
        set
        {
            txt_domicilio_direccion.Enabled = value;
            txt_domicilio_fono.Enabled = value;
            ddl_domicilio_zona.Enabled = value;
            txt_oficina_direccion.Enabled = value;
            txt_oficina_fono.Enabled = value;
            ddl_oficina_zona.Enabled = value;
            rbl_lugar_cobro.Enabled = value;
        }
    }

    protected void ddl_sector_DataBound(object sender, EventArgs e)
    {
        ((DropDownList)sender).Items.Insert(0, new ListItem("", "-1"));
    }
    
    protected void ddl_zona_DataBound(object sender, EventArgs e)
    {
        ((DropDownList)sender).Items.Insert(0, new ListItem("", "0"));
    }

    public void Reset()
    {
        domicilio_direccion = "";
        domicilio_fono = "";
        ddl_domicilio_zona.DataBind();
        ddl_domicilio_zona.SelectedValue = "0";

        oficina_direccion = "";
        oficina_fono = "";
        ddl_oficina_zona.DataBind();
        ddl_oficina_zona.SelectedValue = "0";

        id_lugarcobro = 0;
    }

    public void RecuperarDatos(int _id_cliente)
    {
        cliente clienteObj = new cliente(_id_cliente);
        domicilio_direccion = clienteObj.domicilio_direccion;
        domicilio_fono = clienteObj.domicilio_fono;
        domicilio_id_zona = clienteObj.domicilio_id_zona;
        oficina_direccion = clienteObj.oficina_direccion;
        oficina_fono = clienteObj.oficina_fono;
        oficina_id_zona = clienteObj.oficina_id_zona;
        id_lugarcobro = clienteObj.id_lugarcobro;
    }

    public bool RevisarDirecciones()
    {
        bool correcto = true;
        //Revisamos que el lugar de cobro sea consistente
        if (id_lugarcobro > 0)
        {
            lugar_cobro lugar = new lugar_cobro(id_lugarcobro);
            if (lugar.codigo.ToLower() == "domicilio" && string.IsNullOrEmpty(domicilio_direccion) == true)
            {
                Msg1.Text = "Si la dirección de cobro es el domicilio del cliente, debe introducir la dirección del domicilio";
                correcto = false;
            }
            else if (lugar.codigo.ToLower() == "oficina" && string.IsNullOrEmpty(oficina_direccion) == true)
            {
                Msg1.Text = "Si la dirección de cobro es la oficina del cliente, debe introducir la dirección de la oficina";
                correcto = false;
            }
        }
        //Revisamos la dirección y zona del domicilio
        if (string.IsNullOrEmpty(domicilio_direccion) == true && int.Parse(ddl_domicilio_zona.SelectedValue) > 0)
        {
            Msg1.Text = "Debe introducir la dirección del domicilio";
            correcto = false;
        }
        else if (string.IsNullOrEmpty(domicilio_direccion) == false && int.Parse(ddl_domicilio_zona.SelectedValue) == 0)
        {
            Msg1.Text = "Debe elegir la zona del domicilio";
            correcto = false;
        }
        //Revisamos la dirección y zona de la oficina
        if (string.IsNullOrEmpty(oficina_direccion) == true && int.Parse(ddl_oficina_zona.SelectedValue) > 0)
        {
            Msg1.Text = "Debe introducir la dirección de la oficina";
            correcto = false;
        }
        else if (string.IsNullOrEmpty(oficina_direccion) == false && int.Parse(ddl_oficina_zona.SelectedValue) == 0)
        {
            Msg1.Text = "Debe elegir la zona de la oficina";
            correcto = false;
        }
        return correcto;
    }

</script>

<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdMsg" colspan="4">
            <asp:Msg ID="Msg1" runat="server" Show="false"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_direccion" runat="server" Text="Dirección"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_fono" runat="server" Text="Teléfono"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_zona" runat="server" Text="Zona"></asp:Label></td>
    </tr>
    <tr>
        <td class="formHorTdEnun1"><asp:Label ID="lbl_domicilio_enun" runat="server" Text="Domicilio:"></asp:Label></td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_domicilio_direccion" runat="server" ControlToValidate="txt_domicilio_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_direccion %>" Text="*" ErrorMessage="La dirección del domicilio contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_domicilio_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="200"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_domicilio_fono" runat="server" ControlToValidate="txt_domicilio_fono" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fono %>" Text="*" ErrorMessage="El Nº de teléfono del domicilio contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_domicilio_fono" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
            <%--<ew:NumericBox ID="txt_domicilio_fono" runat="server" SkinID="nbNumericBox100" MaxLength="8"></ew:NumericBox>--%>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_domicilio_zona" runat="server" DataSourceID="ods_lista_zona_domicilio" DataTextField="nombre" DataValueField="id_zona" OnDataBound="ddl_zona_DataBound"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formHorTdEnun1"><asp:Label ID="lbl_oficina_enun" runat="server" Text="Oficina:"></asp:Label></td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_oficina_direccion" runat="server" ControlToValidate="txt_oficina_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_direccion %>" Text="*" ErrorMessage="La dirección de la oficina contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_oficina_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="200"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="ref_oficina_fono" runat="server" ControlToValidate="txt_oficina_fono" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fono %>" Text="*" ErrorMessage="El Nº de teléfono de la oficina contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_oficina_fono" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
            <%--<ew:NumericBox ID="txt_oficina_fono" runat="server" SkinID="nbNumericBox100" MaxLength="8"></ew:NumericBox>--%>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_oficina_zona" runat="server" DataSourceID="ods_lista_zona_oficina" DataTextField="nombre" DataValueField="id_zona" OnDataBound="ddl_zona_DataBound"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHorTdEnun1"><asp:Label ID="lbl_lugar_cobro_enun" runat="server" Text="Lugar de cobro:"></asp:Label></td>
                    <td class="formHorTdDato"><asp:RadioButtonList ID="rbl_lugar_cobro" runat="server" CellPadding="1" CellSpacing="0" DataSourceID="ods_lista_lugar_cobro" DataTextField="nombre" DataValueField="id_lugarcobro"></asp:RadioButtonList></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--[id_zona],[id_sector],[nombre],[num_clientes],[nombre_sector]--%>
<asp:ObjectDataSource ID="ods_lista_zona_domicilio" runat="server" TypeName="terrasur.zona" SelectMethod="Lista">
    <SelectParameters>
        <asp:Parameter Name="Id_sector" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ods_lista_zona_oficina" runat="server" TypeName="terrasur.zona" SelectMethod="Lista">
    <SelectParameters>
        <asp:Parameter Name="Id_sector" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_lugarcobro],[id_usuario],[codigo],[nombre],[cobrador],[num_clientes]--%>
<asp:ObjectDataSource ID="ods_lista_lugar_cobro" runat="server" TypeName="terrasur.lugar_cobro" SelectMethod="Lista">
</asp:ObjectDataSource>