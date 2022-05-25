<%@ Control Language="C#" ClassName="urbanizacionForm" %>

<script runat="server">
    
    public int id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }
    public int id_localizacion { get { return int.Parse(lbl_id_localizacion.Text); } set { lbl_id_localizacion.Text = value.ToString(); } }
    public string codigo { get { return txt_codigo.Text.Trim(); } set { txt_codigo.Text = value; } }
    public string nombre_corto { get { return txt_nombre_corto.Text.Trim(); } set { txt_nombre_corto.Text = value; } }
    public string nombre { get { return txt_nombre.Text.Trim(); } set { txt_nombre.Text = value; } }
    public decimal mantenimiento { get { return Decimal.Parse(txt_manten.Text.Trim()); } set { txt_manten.Text = value.ToString(); } }
    public decimal costo { get { return Decimal.Parse(txt_costo.Text.Trim()); } set { txt_costo.Text = value.ToString(); } }
    public decimal precio { get { return Decimal.Parse(txt_precio.Text.Trim()); } set { txt_precio.Text = value.ToString(); } }
    public bool activo { get { return cbx_activo.Checked; } set { cbx_activo.Checked  = value; } }
    public bool costo_todos { get { return cbx_costo_todos.Checked; } set { cbx_costo_todos.Checked = value; } }
    public bool precio_todos { get { return cbx_precio_todos.Checked; } set { cbx_precio_todos.Checked = value; } }
    public FileUpload imagen { get { return fu_imagen; } }
    public bool Visible_imagen_file { get { return fu_imagen.Visible; } set { lbl_imagen.Visible = value; fu_imagen.Visible = value; img_imagen.Visible = value; lb_imagen_eliminar.Visible = value; } }
    public bool Visible_imagen_img { get { return img_imagen.Visible; } set { img_imagen.Visible = value; lb_imagen_eliminar.Visible = value; } }

    public void RecuperarDatos(int Id_urbanizacion)
    {
        this.id_urbanizacion = Id_urbanizacion;
        urbanizacion u = new urbanizacion(Id_urbanizacion);
        localizacion l = new localizacion(u.id_localizacion);
        id_localizacion = u.id_localizacion;
        this.lbl_localizacion.Text = l.nombre;
        this.codigo = u.codigo;
        this.nombre = u.nombre;
        this.nombre_corto = u.nombre_corto;
        this.mantenimiento = u.mantenimiento_sus;
        this.costo = u.costo_m2_sus;
        this.precio = u.precio_m2_sus;
        this.cbx_activo.Checked = u.activo;
        if (u.num_lote > 0)
        {
            this.cbx_costo_todos.Checked = false;
            this.cbx_precio_todos.Checked = false;
            this.cbx_costo_todos.Visible = true;
            this.cbx_precio_todos.Visible = true;
        }
        else
        {
            this.cbx_costo_todos.Checked = false;
            this.cbx_precio_todos.Checked = false;
            this.cbx_costo_todos.Visible = false;
            this.cbx_precio_todos.Visible = false;
        }
        img_imagen.ImageUrl = urbanizacion.ImagenDireccion(u.imagen);
        if (u.imagen.Equals("").Equals(false)== false)
        {
            img_imagen.Visible = true;
            lb_imagen_eliminar.Visible = false;
        }
        else
        {
            img_imagen.Visible = true;
            lb_imagen_eliminar.Visible = true;
            
        }    
        //if (Visible_imagen_img == true) lb_imagen_eliminar.Visible = l.imagen.Equals("").Equals(false);
        //else lb_imagen_eliminar.Visible = false;
        txt_codigo.Focus();
    }
    public bool Verificar(int _Id_urbanizacion, bool Inserta)
    {
        bool correcto = true;
        if (urbanizacion.VerificarCodigoNombre(Inserta, _Id_urbanizacion, txt_codigo.Text, txt_nombre.Text) == true)
        {
            Msg1.Text = "El Código o nombre del sector pertenece a otra sector registrada";
            correcto = false;
        }
        if (imagen.HasFile == true)
        {
            if (imagen.PostedFile.ContentLength > Int32.Parse(ConfigurationManager.AppSettings["urbanizacion_tam_imagen"]))
            {
                Msg1.Text = "El archivo de la imagen tiene un tamaño mayor al permitido (" + Math.Round(Double.Parse(ConfigurationManager.AppSettings["urbanizacion_tam_imagen"]) / 1024, 2) + " KB)";
                correcto = false;
            }
            if (ConfigurationManager.AppSettings["urbanizacion_tipo_imagen"].Contains(System.IO.Path.GetExtension(imagen.FileName)) == false)
            {
                Msg1.Text = "El archivo de la imagen no tiene un formato permitido (" + ConfigurationManager.AppSettings["urbanizacion_tipo_imagen"] + ")";
                correcto = false;
            }
        }
        return correcto;
    }       
    public void Reset()
    {
        localizacion l = new localizacion(id_localizacion);
        this.lbl_localizacion.Text= l.nombre;
        this.txt_codigo.Text  = "";
        this.txt_nombre.Text  = "";
        this.txt_nombre_corto.Text  = "";
        this.txt_manten.Text  = "";
        this.txt_costo.Text  = "";
        this.txt_precio.Text  = "";
        this.cbx_activo.Checked = true;
        this.cbx_costo_todos.Checked = false;
        this.cbx_precio_todos.Checked = false;
        this.cbx_costo_todos.Visible = false;
        this.cbx_precio_todos.Visible = false;
        img_imagen.Visible = false;
        lb_imagen_eliminar.Visible = false;
        txt_codigo.Focus();
    }
    protected void lb_imagen_eliminar_Click(object sender, EventArgs e)
    {
        urbanizacion u = new urbanizacion(id_urbanizacion);
        u.imagen = "";
        u.ImagenActualizar(id_urbanizacion);
        img_imagen.ImageUrl = urbanizacion.ImagenDireccion(u.imagen);
        lb_imagen_eliminar.Visible = false;
    }
    protected void lb_img_imagen_Click(object sender, EventArgs e)
    {
        urbanizacion u = new urbanizacion(id_urbanizacion);
        if (u.imagen.Equals("").Equals(false) == true)
        {
             Session["id_urbanizacion"] = id_urbanizacion;
             WinPopUp1.NavigateUrl = urbanizacion.ImagenDireccion(u.imagen);
             WinPopUp1.Show();
        }
    }
</script>
<h2>Recuerde crear la cuenta analitica en Odoo de la nueva urbanizacion que esta creando</h2>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/urbanizacion/urbanizacionImagen.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_urbanizacion" runat="server" DisplayMode="List" ValidationGroup="urbanizacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del sector"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_localizacion" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="Debe introducir el código del sector"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="El código del sector contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:urbanizacion_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_corto_enum" runat="server" Text="Nombre corto:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre_corto" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nombre_corto" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="Debe introducir el nombre corto del sector"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_nombre_corto" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="El nombre corto del sector contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:urbanizacion_ExpReg_nombre_corto %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del sector:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="Debe introducir el nombre del sector"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="El nombre del sector contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:urbanizacion_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_manten_enun" runat="server" Text="Mantenimiento ($us):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_manten" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_manten" runat="server" ControlToValidate="txt_manten" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_manten" runat="server" Type="Double"  MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_manten"  Display="Dynamic" ValidationGroup="urbanizacion" SetFocusOnError="true" Text="*" ErrorMessage="El mantenimiento ($us) contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_costo_enun" runat="server" Text="Costo M2 ($us):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_costo" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:CheckBox ID="cbx_costo_todos" runat="server" Text="Aplicar a todos los lotes"/>
            <asp:RequiredFieldValidator ID="rfv_costo" runat="server" ControlToValidate="txt_costo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_costo" runat="server" Type="Double"  MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_costo"  Display="Dynamic" ValidationGroup="urbanizacion" SetFocusOnError="true" Text="*" ErrorMessage="El costo M2 ($us) contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_precio_enun" runat="server" Text="Precio M2 ($us):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_precio" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:CheckBox ID="cbx_precio_todos" runat="server" Text="Aplicar a todos los lotes"/>
            <asp:RequiredFieldValidator ID="rfv_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" SetFocusOnError="true" ValidationGroup="urbanizacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_precio" runat="server" Type="Double"  MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_precio"  Display="Dynamic" ValidationGroup="urbanizacion" SetFocusOnError="true" Text="*" ErrorMessage="El precio M2 ($us) contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_activo_enum" runat="server" Text="Activo"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Text="Sector activo"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_imagen" runat="server" Text="Imagen:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table>
                <tr>
                    <td><asp:ImageButton ID="img_imagen"  OnClick="lb_img_imagen_Click" runat="server" Height="<%$ AppSettings:urbanizacion_tam_img %>" /></td>
                    <td valign="bottom"><asp:LinkButton ID="lb_imagen_eliminar" runat="server" Text="Borrar" OnClick="lb_imagen_eliminar_Click"  OnClientClick="return confirm('¿Esta seguro que desea eliminar la imagen de este sector?');"></asp:LinkButton></td>
                </tr>
                <tr><td colspan="2"><asp:FileUpload ID="fu_imagen" runat="server" SkinID="fuFileUpload200" /></td></tr>
            </table>
         </td>
    </tr>
</table>