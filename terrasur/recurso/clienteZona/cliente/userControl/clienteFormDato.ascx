<%@ Control Language="C#" ClassName="clienteFormDato" %>

<script runat="server">
    private int id_cliente { get { return Int32.Parse(lbl_id_cliente.Text); } set { lbl_id_cliente.Text = value.ToString(); } }
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

    public bool transitorio { get { return bool.Parse(lbl_transitorio.Text); } set { lbl_transitorio.Text = value.ToString(); rfv_ci.Enabled = value.Equals(false); } }
    //public bool MostrarVerificar { get { return lb_verificar.Visible; } set { lb_verificar.Visible = value; } }
    //public bool Bloquear_y_recuperar { get { return bool.Parse(lbl_bloquear_y_recuperar.Text); } set { lbl_bloquear_y_recuperar.Text = value.ToString(); } }
    public bool HabilitarControles
    {
        get { return txt_paterno.Enabled; }
        set
        {
            txt_ci.Enabled = value;
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
        }
    }
    
    public void Reset()
    {
        id_cliente = 0;
        HabilitarControles = true;
        ci = "";
        paterno = "";
        materno = "";
        nombres = "";
        nit = "";
        transitorio = false;
        fecha_nacimiento = DateTime.Now;
        celular = "";
        fax = "";
        email = "";
        casilla = "";
        txt_ci.Focus();
    }
    public void RecuperarDatos(int _id_cliente)
    {
        id_cliente = _id_cliente;
        cliente clienteObj = new cliente(_id_cliente);
        ci = clienteObj.ci;
        transitorio = clienteObj.transitorio;
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
        //txt_ci.Focus();
        if (Profile.entorno.codigo_modulo != "adm") txt_ci.Enabled = false;
        txt_paterno.Focus();
    }
    public bool RevisarDatos(int _id_cliente)
    {
        bool correcto = true;
        if (txt_ci.Text.Trim() != "")
        {
            if (cliente.VerificarCI(_id_cliente.Equals(0), _id_cliente, ci) == true)
            {
                Msg1.Text = "El C.I. pertenece a otro cliente ya registrado";
                correcto = false;
            }
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
        //if (cliente.VerificarNombreCompleto(_id_cliente.Equals(0), _id_cliente, nombres, paterno, materno) == true)
        //{
        //    Msg1.Text = "El nombre completo del cliente pertenece a otro cliente ya registrado";
        //    correcto = false;
        //}
        return correcto;
    }

    //protected void lb_verificar_Click(object sender, EventArgs e)
    //{
    //    if (ci != "")
    //    {
    //        if (cliente.VerificarCI(id_cliente.Equals(0), id_cliente, ci) == true)
    //        {
    //            if (Bloquear_y_recuperar == true)
    //            {
    //                RecuperarDatos(cliente.ObtenerIdPorCi(ci));
    //                HabilitarControles = false;
    //            }
    //            else { HabilitarControles = true; }
    //            Msg1.Text = "El C.I. pertenece a un cliente registrado";
    //        }
    //        else
    //        {
    //            HabilitarControles = true;
    //            Msg1.Text = "El C.I. NO pertenece a un cliente registrado";
    //        }
    //    }
    //    else { Msg1.Text = "Debe introducir el C.I. del cliente"; }
    //}


    protected void ddl_lugar_cedula_DataBound(object sender, EventArgs e)
    {
        ddl_lugar_cedula.Items.Insert(0, new ListItem("", "0"));
    }
</script>
<asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_transitorio" runat="server" Text="false" Visible="false"></asp:Label>
<%--<asp:Label ID="lbl_bloquear_y_recuperar" runat="server" Text="false" Visible="false"></asp:Label>--%>
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdMsg" colspan="5">
            <asp:Msg ID="Msg1" runat="server" Show="false"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formHorTdEnun"><asp:Label ID="lbl_ci" runat="server" Text="C.I."></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_paterno" runat="server" Text="Ap.Paterno"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_materno" runat="server" Text="Ap.Materno"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_nombres" runat="server" Text="Nombre"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_nit" runat="server" Text="NIT"></asp:Label></td>
    </tr>
    <tr>
        <td class="formHorTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfv_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el C.I. del cliente"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                        <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
                        <%--<ew:RequiredFieldValidator ID="rfv_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el C.I."></ew:RequiredFieldValidator>
                        <ew:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></ew:RegularExpressionValidator> 
                        <ew:NumericBox ID="txt_ci" runat="server" SkinID="nbNumericBox50" MaxLength="10"></ew:NumericBox>--%>
                    </td>
                    <td><asp:DropDownList ID="ddl_lugar_cedula" runat="server" DataSourceID="ods_lista_lugar_cedula" DataTextField="codigo" DataValueField="id_lugarcedula" OnDataBound="ddl_lugar_cedula_DataBound"></asp:DropDownList></td>
                    <%--<td><asp:LinkButton ID="lb_verificar" runat="server" Text="Verificar" CausesValidation="true" ValidationGroup="verificar_ci" OnClick="lb_verificar_Click"></asp:LinkButton></td>--%>
                </tr>
            </table>
        </td>
        <td class="formHorTdDato">
            <asp:RequiredFieldValidator ID="rfv_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el apellido paterno"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido paterno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_paterno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RequiredFieldValidator ID="rfv_materno" runat="server" Enabled="false" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el apellido materno"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido materno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_materno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RequiredFieldValidator ID="rfv_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" Text="*" ErrorMessage="Debe introducir el nombre"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_nombres" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_nit" runat="server" SkinID="txtSingleLine100" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
            <%--<ew:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos"></ew:RegularExpressionValidator> 
            <ew:NumericBox ID="txt_nit" runat="server" SkinID="nbNumericBox100" MaxLength="10"></ew:NumericBox>--%>
        </td>
    </tr>
    <tr>
        <td class="formHorTdEnun"><asp:Label ID="lbl_fecha" runat="server" Text="F.Nacimiento"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_celular" runat="server" Text="Celular"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_fax" runat="server" Text="Fax"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_casilla" runat="server" Text="Casilla"></asp:Label></td>
    </tr>
    <tr>
        <td class="formHorTdDato">
            <ew:CalendarPopup ID="txt_fecha" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_celular" runat="server" ControlToValidate="txt_celular" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_celular %>" Text="*" ErrorMessage="El Nº de celular contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_celular" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
            <%--<ew:RegularExpressionValidator ID="rev_celular" runat="server" ControlToValidate="txt_celular" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_celular %>" Text="*" ErrorMessage="El Nº de celular contiene caracteres inválidos"></ew:RegularExpressionValidator> 
            <ew:NumericBox ID="txt_celular" runat="server" SkinID="nbNumericBox100" MaxLength="8"></ew:NumericBox>--%>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_fax" runat="server" ControlToValidate="txt_fax" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fax %>" Text="*" ErrorMessage="El Nº de fax contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_fax" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
            <%--<ew:RegularExpressionValidator ID="rev_fax" runat="server" ControlToValidate="txt_fax" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_fax %>" Text="*" ErrorMessage="El Nº de fax contiene caracteres inválidos"></ew:RegularExpressionValidator> 
            <ew:NumericBox ID="txt_fax" runat="server" SkinID="nbNumericBox100" MaxLength="8"></ew:NumericBox>--%>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_email %>" Text="*" ErrorMessage="La dirección E-Mail es incorrecta"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_email" runat="server" SkinID="txtSingleLine100" MaxLength="200"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_casilla" runat="server" ControlToValidate="txt_casilla" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_casilla %>" Text="*" ErrorMessage="El Nº de casilla contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_casilla" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
            <%--<ew:RegularExpressionValidator ID="rev_casilla" runat="server" ControlToValidate="txt_casilla" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cliente" ValidationExpression="<%$ AppSettings:cliente_ExpReg_casilla %>" Text="*" ErrorMessage="El Nº de casilla contiene caracteres no permitidos"></ew:RegularExpressionValidator> 
            <ew:NumericBox ID="txt_casilla" runat="server" SkinID="nbNumericBox100" MaxLength="8"></ew:NumericBox>--%>
        </td>
    </tr>
</table>
<%--[id_lugarcedula],[codigo],[nombre]--%>
<asp:ObjectDataSource ID="ods_lista_lugar_cedula" runat="server" TypeName="terrasur.lugar_cedula" SelectMethod="Lista"></asp:ObjectDataSource>
