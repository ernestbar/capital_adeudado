<%@ Control Language="C#" ClassName="localizacionForm" %>

<script runat="server">
    
    public int id_localizacion { get { return int.Parse(lbl_id_localizacion.Text); } set { lbl_id_localizacion.Text = value.ToString(); } }
    public string codigo { get { return txt_codigo.Text.Trim(); } set { txt_codigo.Text = value; } }
    public string nombre { get { return txt_nombre.Text.Trim(); } set { txt_nombre.Text = value; } }
    public FileUpload imagen { get { return fu_imagen; } }
    public bool Visible_imagen_file { get { return fu_imagen.Visible; } set { lbl_imagen.Visible = value; fu_imagen.Visible = value; img_imagen.Visible = value; lb_imagen_eliminar.Visible = value; } }
    public bool Visible_imagen_img { get { return img_imagen.Visible; } set { img_imagen.Visible = value; lb_imagen_eliminar.Visible = value; } }

    public void RecuperarDatos(int Id_localizacion)
    {
        this.id_localizacion = Id_localizacion;
        localizacion l = new localizacion(Id_localizacion);
        this.codigo = l.codigo;
        this.nombre = l.nombre;
        img_imagen.ImageUrl = localizacion.ImagenDireccion(l.imagen);
        if (l.imagen.Equals("").Equals(false)== false)
        {
            img_imagen.Visible = true;
            lb_imagen_eliminar.Visible = false;
        }
        else
        {
            img_imagen.Visible = true;
            lb_imagen_eliminar.Visible = true;
            
        }    
        txt_codigo.Focus();
    }
    public bool Verificar(int _Id_localizacion, bool Inserta)
    {
        bool correcto = true;
        if(localizacion.VerificarCodigoNombre(Inserta,_Id_localizacion,txt_codigo.Text,txt_nombre.Text) == true)
        {
            Msg1.Text = "El Código o nombre de la localización pertenece a otra localización registrado";
            correcto = false;
        }
        if (imagen.HasFile == true)
        {
            if (imagen.PostedFile.ContentLength > Int32.Parse(ConfigurationManager.AppSettings["localizacion_tam_imagen"]))
            {
                Msg1.Text = "El archivo de la imagen tiene un tamaño mayor al permitido (" + Math.Round(Double.Parse(ConfigurationManager.AppSettings["localizacion_tam_imagen"]) / 1024, 2) + " KB)";
                correcto = false;
            }
            if (ConfigurationManager.AppSettings["localizacion_tipo_imagen"].Contains(System.IO.Path.GetExtension(imagen.FileName)) == false)
            {
                Msg1.Text = "El archivo de la imagen no tiene un formato permitido (" + ConfigurationManager.AppSettings["localizacion_tipo_imagen"] + ")";
                correcto = false;
            }
        }
        return correcto;
    }       
    public void Reset()
    {
        this.txt_codigo.Text  = "";
        this.txt_nombre.Text  = "";
        img_imagen.Visible = false;
        lb_imagen_eliminar.Visible = false;
        txt_codigo.Focus();
    }
    protected void lb_imagen_eliminar_Click(object sender, EventArgs e)
    {
        localizacion u = new localizacion(id_localizacion);
        u.imagen = "";
        u.ImagenActualizar(id_localizacion);
        img_imagen.ImageUrl = localizacion.ImagenDireccion(u.imagen);
        lb_imagen_eliminar.Visible = false;
    }
    protected void lb_img_imagen_Click(object sender, EventArgs e)
    {
        localizacion l = new localizacion(id_localizacion);
        if (l.imagen.Equals("").Equals(false) == true)
        {
            Session["id_localizacion"] = id_localizacion;
            WinPopUp1.NavigateUrl = localizacion.ImagenDireccion(l.imagen);
            WinPopUp1.Show();
        }
    }
</script>

<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/localizacion/localizacionImagen.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_localizacion" runat="server" DisplayMode="List" ValidationGroup="localizacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de la localización"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="localizacion" Text="*" ErrorMessage="Debe introducir el código de la localización"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="localizacion" Text="*" ErrorMessage="El código de la localización contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:localizacion_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre de la localizacion:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="localizacion" Text="*" ErrorMessage="Debe introducir el nombre dela localización"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="localizacion" Text="*" ErrorMessage="El nombre de la localización contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:localizacion_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_imagen" runat="server" Text="Imagen:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table>
                <tr>
                    <td><asp:ImageButton ID="img_imagen"  OnClick="lb_img_imagen_Click" runat="server" Height="<%$ AppSettings:localizacion_tam_img %>" /></td>
                    <td valign="bottom"><asp:LinkButton ID="lb_imagen_eliminar" runat="server" Text="Borrar" OnClick="lb_imagen_eliminar_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar la imagen de esta localización?');"></asp:LinkButton></td>
                </tr>
                <tr><td colspan="2"><asp:FileUpload ID="fu_imagen" runat="server" SkinID="fuFileUpload200"  /></td></tr>
            </table>
         </td>
    </tr>
</table>