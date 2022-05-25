<%@ Control Language="C#" ClassName="contratoFormTitular" %>

<script runat="server">
    public int id_cliente { get { return Int32.Parse(lbl_id_cliente.Text); } set { lbl_id_cliente.Text = value.ToString(); } }

    public string ci { get { return txt_ci.Text.Trim(); } set { txt_ci.Text = value; } }
    public int id_lugarcedula { get { return int.Parse(ddl_lugar_cedula.SelectedValue); } set { ddl_lugar_cedula.SelectedValue = value.ToString(); } }
    public string paterno { get { return txt_paterno.Text.Trim(); } set { txt_paterno.Text = value; } }
    public string materno { get { return txt_materno.Text.Trim(); } set { txt_materno.Text = value; } }
    public string nombres { get { return txt_nombres.Text.Trim(); } set { txt_nombres.Text = value; } }
    public string nit { get { return txt_nit.Text.Trim(); } set { txt_nit.Text = value; } }
    public DateTime fecha_nacimiento { get { if (txt_fecha.SelectedValue.HasValue == true) return txt_fecha.SelectedDate; else return DateTime.Now; } set { if (value.Date == DateTime.Now.Date) txt_fecha.Clear(); else txt_fecha.SelectedDate = value; } }
    public string celular { get { return txt_celular.Text.Trim(); } set { txt_celular.Text = value; } }
    public string fax { get { return txt_fax.Text.Trim(); } set { txt_fax.Text = value; } }
    public string email { get { return txt_email.Text.Trim(); } set { txt_email.Text = value; } }
    public string casilla { get { return txt_casilla.Text.Trim(); } set { txt_casilla.Text = value; } }

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
        get { return txt_paterno.Enabled; }
        set
        {
            //txt_ci.Enabled = value;
            ddl_lugar_cedula.Enabled = value;
            txt_paterno.Enabled = value;
            txt_materno.Enabled = value;
            txt_nombres.Enabled = value;
            txt_nit.Enabled = value;
            
            txt_fecha.Enabled = value;
            txt_celular.Enabled = value;
            txt_fax.Enabled = value;
            txt_email.Enabled = value;
            txt_casilla.Enabled = value;

            txt_domicilio_direccion.Enabled = value;
            txt_domicilio_fono.Enabled = value;
            ddl_domicilio_zona.Enabled = value;
            txt_oficina_direccion.Enabled = value;
            txt_oficina_fono.Enabled = value;
            ddl_oficina_zona.Enabled = value;
            rbl_lugar_cobro.Enabled = value;

            btn_update.Visible = value.Equals(false);
        }
    }
    
    public void Reset()
    {
        id_cliente = 0;
        
        HabilitarControles = true;
        ci = "";
        //ddl_lugar_cedula.DataBind();
        paterno = "";
        materno = "";
        nombres = "";
        nit = "";
        
        fecha_nacimiento = DateTime.Now;
        celular = "";
        fax = "";
        email = "";
        casilla = "";
        txt_ci.Focus();

        domicilio_direccion = "";
        domicilio_fono = "";
        ddl_domicilio_zona.DataBind();
        ddl_domicilio_zona.SelectedValue = "0";
        oficina_direccion = "";
        oficina_fono = "";
        ddl_oficina_zona.DataBind();
        ddl_oficina_zona.SelectedValue = "0";
        if (rbl_lugar_cobro.Items.Count == 0) rbl_lugar_cobro.DataBind();
        rbl_lugar_cobro.SelectedValue = (new lugar_cobro("terrasur")).id_lugarcobro.ToString();
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

        fecha_nacimiento = clienteObj.fecha_nacimiento;
        celular = clienteObj.celular;
        fax = clienteObj.fax;
        email = clienteObj.email;
        casilla = clienteObj.casilla;
        txt_ci.Focus();

        domicilio_direccion = clienteObj.domicilio_direccion;
        domicilio_fono = clienteObj.domicilio_fono;
        domicilio_id_zona = clienteObj.domicilio_id_zona;
        oficina_direccion = clienteObj.oficina_direccion;
        oficina_fono = clienteObj.oficina_fono;
        oficina_id_zona = clienteObj.oficina_id_zona;
        if (clienteObj.id_lugarcobro == 0) id_lugarcobro = (new lugar_cobro("terrasur")).id_lugarcobro;
        else id_lugarcobro = clienteObj.id_lugarcobro;
    }
    public bool Verificar()
    {
        VerificarCi();
        bool correcto = true;
        if (RevisarDatos() == false) correcto = false;
        if (RevisarDirecciones() == false) correcto = false;
        return correcto;
    }
    
    public bool RevisarDatos()
    {
        bool correcto = true;
        if (cliente.VerificarCI(id_cliente.Equals(0), id_cliente, ci) == true)
        {
            Msg1.Text = "El C.I. pertenece a un cliente registrado";
            correcto = false;
        }
        if (txt_fecha.SelectedValue.HasValue == true)
        {
            if (txt_fecha.SelectedDate < DateTime.Parse("01/01/1900"))
            {
                Msg1.Text = "La fecha de nacimiento no puede ser anterior al 01/01/1900";
                correcto = false;
            }
            else if (txt_fecha.SelectedDate > DateTime.Parse("01/01/2009"))
            {
                Msg1.Text = "La fecha de nacimiento no puede ser posterior al 01/01/2009";
                correcto = false;
            }   
        }
        //if (cliente.VerificarNombreCompleto(id_cliente.Equals(0), id_cliente, nombres, paterno, materno) == true)
        //{
        //    Msg1.Text = "El nombre completo del cliente pertenece a otro cliente ya registrado";
        //    correcto = false;
        //}
        return correcto;
    }

    public bool RevisarDirecciones()
    {
        bool correcto = true;
        if (HabilitarControles == true)
        {
            //Revisamos que el lugar de cobro sea consistente
            if (id_lugarcobro > 0)
            {
                lugar_cobro lugar = new lugar_cobro(id_lugarcobro);
                if (lugar.codigo.ToLower() == "domicilio" && domicilio_direccion == "")
                {
                    Msg1.Text = "Si la dirección de cobro es el domicilio del cliente, debe introducir la dirección del domicilio";
                    correcto = false;
                }
                else if (lugar.codigo.ToLower() == "oficina" && oficina_direccion == "")
                {
                    Msg1.Text = "Si la dirección de cobro es la oficina del cliente, debe introducir la dirección de la oficina";
                    correcto = false;
                }
            }
            //Revisamos la dirección y zona del domicilio
            if (domicilio_direccion == "" && int.Parse(ddl_domicilio_zona.SelectedValue) > 0)
            {
                Msg1.Text = "Debe introducir la dirección del domicilio";
                correcto = false;
            }
            else if (domicilio_direccion != "" && int.Parse(ddl_domicilio_zona.SelectedValue) == 0)
            {
                Msg1.Text = "Debe elegir la zona del domicilio";
                correcto = false;
            }
            //Revisamos la dirección y zona de la oficina
            if (oficina_direccion == "" && int.Parse(ddl_oficina_zona.SelectedValue) > 0)
            {
                Msg1.Text = "Debe introducir la dirección de la oficina";
                correcto = false;
            }
            else if (oficina_direccion != "" && int.Parse(ddl_oficina_zona.SelectedValue) == 0)
            {
                Msg1.Text = "Debe elegir la zona de la oficina";
                correcto = false;
            }
        }
        return correcto;
    }


    protected void ddl_zona_DataBound(object sender, EventArgs e)
    {
        ((DropDownList)sender).Items.Insert(0, new ListItem("", "0"));
    }

    protected void lb_verificar_Click(object sender, EventArgs e)
    {
        VerificarCi();
    }
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
            if (HabilitarControles == false) { HabilitarControles = true; Reset(); }
            Msg1.Text = "Debe introducir el C.I. del cliente";
        }
    }

    protected void ddl_lugar_cedula_DataBound(object sender, EventArgs e)
    {
        ddl_lugar_cedula.Items.Insert(0, new ListItem("", "0"));
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        Session["id_cliente"] = id_cliente;
        WinPopUp1.Show();
    }
</script>
<asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/contratoLote/clienteUpdate.aspx"></asp:WinPopUp>
<asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg">
            <asp:Msg ID="Msg1" runat="server" Show="false"></asp:Msg>
            <asp:ValidationSummary ID="vs_verificar_ci" runat="server" DisplayMode="List" ValidationGroup="verificar_ci" />
        </td>
    </tr>
    <tr>
        <td>
            <table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_ci" runat="server" Text="C.I."></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_paterno" runat="server" Text="Ap.Paterno"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_materno" runat="server" Text="Ap.Materno"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_nombres" runat="server" Text="Nombre"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_nit" runat="server" Text="NIT"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_ci" runat="server" DefaultButton="lb_verificar">
                                    <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine50" MaxLength="12"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el C.I. del cliente"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    <%--<asp:RequiredFieldValidator ID="rfv_verificar_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="verificar_ci" Text="*" ErrorMessage="Debe introducir el C.I. del cliente"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="rev_verificar_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="verificar_ci" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                    </asp:Panel>
                                </td>
                                <td><asp:DropDownList ID="ddl_lugar_cedula" runat="server" DataSourceID="ods_lista_lugar_cedula" DataTextField="codigo" DataValueField="id_lugarcedula" OnDataBound="ddl_lugar_cedula_DataBound"></asp:DropDownList></td>
                                <td><asp:ImageButton ID="lb_verificar" runat="server" ImageUrl="~/images/verificar.gif" ToolTip="Verificar C.I." CausesValidation="true" ValidationGroup="verificar_ci" OnClick="lb_verificar_Click" /></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:LinkButton ID="btn_update" runat="server" Text="Modificar datos" OnClick="btn_update_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2"><asp:LinkButton ID="lb_verificar" runat="server" Text="Verificar" CausesValidation="true" ValidationGroup="verificar_ci" OnClick="lb_verificar_Click"></asp:LinkButton></td>
                            </tr>--%>
                        </table>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_paterno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el apellido paterno"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido paterno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_materno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfv_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el apellido materno"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rev_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido materno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_nombres" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el nombre"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_nit" runat="server" SkinID="txtSingleLine100" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
                    </td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_fecha" runat="server" Text="F.Nacimiento"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_celular" runat="server" Text="Celular"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_fax" runat="server" Text="Fax"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_casilla" runat="server" Text="Casilla"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato">
                        <ew:CalendarPopup ID="txt_fecha" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_celular" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_celular" runat="server" ControlToValidate="txt_celular" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_celular %>" Text="*" ErrorMessage="El Nº de celular contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_fax" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_fax" runat="server" ControlToValidate="txt_fax" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fax %>" Text="*" ErrorMessage="El Nº de fax contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_email" runat="server" SkinID="txtSingleLine100" MaxLength="200"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_email %>" Text="*" ErrorMessage="La dirección E-Mail es incorrecta"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_casilla" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_casilla" runat="server" ControlToValidate="txt_casilla" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_casilla %>" Text="*" ErrorMessage="El Nº de casilla contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_direccion" runat="server" Text="Dirección"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_fono" runat="server" Text="Teléfono"></asp:Label></td>
                    <td class="contratoFormTdHorEnun" colspan="2"><asp:Label ID="lbl_zona" runat="server" Text="Zona"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_domicilio_enun" runat="server" Text="Domicilio:"></asp:Label></td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_domicilio_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="200"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_domicilio_direccion" runat="server" ControlToValidate="txt_domicilio_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_direccion %>" Text="*" ErrorMessage="La dirección del domicilio contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_domicilio_fono" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_domicilio_fono" runat="server" ControlToValidate="txt_domicilio_fono" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fono %>" Text="*" ErrorMessage="El Nº de teléfono del domicilio contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato" colspan="2">
                        <asp:DropDownList ID="ddl_domicilio_zona" runat="server" DataSourceID="ods_lista_zona_domicilio" DataTextField="nombre" DataValueField="id_zona" OnDataBound="ddl_zona_DataBound"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_oficina_enun" runat="server" Text="Oficina:"></asp:Label></td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_oficina_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="200"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_oficina_direccion" runat="server" ControlToValidate="txt_oficina_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_direccion %>" Text="*" ErrorMessage="La dirección de la oficina contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_oficina_fono" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="ref_oficina_fono" runat="server" ControlToValidate="txt_oficina_fono" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fono %>" Text="*" ErrorMessage="El Nº de teléfono de la oficina contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdHorDato" colspan="2">
                        <asp:DropDownList ID="ddl_oficina_zona" runat="server" DataSourceID="ods_lista_zona_oficina" DataTextField="nombre" DataValueField="id_zona" OnDataBound="ddl_zona_DataBound"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formHorTdEnun1"><asp:Label ID="lbl_lugar_cobro_enun" runat="server" Text="Lugar de cobro:"></asp:Label></td>
                                <td class="formHorTdDato"><asp:RadioButtonList ID="rbl_lugar_cobro" runat="server" CellPadding="1" CellSpacing="0" DataSourceID="ods_lista_lugar_cobro" DataTextField="nombre" DataValueField="id_lugarcobro"></asp:RadioButtonList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--[id_lugarcedula],[codigo],[nombre]--%>
<asp:ObjectDataSource ID="ods_lista_lugar_cedula" runat="server" TypeName="terrasur.lugar_cedula" SelectMethod="Lista">
</asp:ObjectDataSource>
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