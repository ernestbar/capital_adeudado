<%@ Control Language="C#" ClassName="usuarioForm" %>

<script runat="server">
    public int id_rol { get { return int.Parse(lbl_id_rol.Text); } set { lbl_id_rol.Text = value.ToString();  } }
    public int id_usuario { get { return int.Parse(lbl_id_usuario.Text); } set { lbl_id_usuario.Text = value.ToString(); } }

    public string paterno { get { return txt_paterno.Text.Trim(); } set { txt_paterno.Text = value; } }
    public string materno { get { return txt_materno.Text.Trim(); } set { txt_materno.Text = value; } }
    public string nombres { get { return txt_nombres.Text.Trim(); } set { txt_nombres.Text = value; } }
    public string ci { get { return txt_ci.Text.Trim(); } set { txt_ci.Text = value; } }
    public string email { get { return txt_email.Text.Trim(); } set { txt_email.Text = value; } }
    public FileUpload imagen { get { return fu_imagen; } }
    public string nombre_usuario { get { return txt_nombre_usuario.Text.Trim(); } set { txt_nombre_usuario.Text = value; } }
    public string password { get { return txt_password.Text.Trim(); } set { txt_password.Text = value; } }
    public bool activo { get { return cb_activo.Checked; } set { cb_activo.Checked = value; } }
    public string permisos
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (RepeaterItem item_gr in r_grupo_recurso.Items)
                foreach (RepeaterItem item_r in ((Repeater)item_gr.FindControl("r_recurso")).Items)
                    foreach (ListItem item_cbl in ((CheckBoxList)item_r.FindControl("cbl_permiso")).Items)
                        sb.Append(item_cbl.Value + "," + item_cbl.Selected.ToString() + ";");
            return sb.ToString().TrimEnd(';');
        }
    }

    public bool Enabled_nombres { get { return txt_nombres.Enabled; } set { txt_nombres.Enabled = value; rfv_nombres.Enabled = value; rev_nombres.Enabled = value; } }
    public bool Enabled_paterno { get { return txt_paterno.Enabled; } set { txt_paterno.Enabled = value; rfv_paterno.Enabled = value; rev_paterno.Enabled = value; } }
    public bool Enabled_materno { get { return txt_materno.Enabled; } set { txt_materno.Enabled = value; rfv_materno.Enabled = value; rev_materno.Enabled = value; } }
    public bool Enabled_ci { get { return txt_ci.Enabled; } set { txt_ci.Enabled = value; rfv_ci.Enabled = value; rev_ci.Enabled = value; } }
    public bool Enabled_email { get { return txt_email.Enabled; } set { txt_email.Enabled = value; rev_email.Enabled = value; } }
    public bool Enabled_imagen_file { get { return fu_imagen.Enabled; } set { fu_imagen.Enabled = value; } }
    public bool Enabled_nombre_usuario { get { return txt_nombre_usuario.Enabled; } set { txt_nombre_usuario.Enabled = value; rfv_nombre_usuario.Enabled = value; rev_nombre_usuario.Enabled = value; } }
    public bool Enabled_password { get { return txt_password.Enabled; } set { txt_password.Enabled = value; rfv_password.Enabled = value; rev_password.Enabled = value; txt_password_confirm.Enabled = value; rfv_password_confirm.Enabled = value; rev_password_confirm.Enabled = value; cv_password_confirm.Enabled = value; } }
    public bool Enabled_activo { get { return cb_activo.Enabled; } set { cb_activo.Enabled = value; cb_activo.Enabled = value; } }

    public bool Visible_nombres { get { return txt_nombres.Visible; } set { lbl_nombres.Visible = value; txt_nombres.Visible = value; rfv_nombres.Enabled = value; rev_nombres.Enabled = value; } }
    public bool Visible_paterno { get { return txt_paterno.Visible; } set { lbl_paterno.Visible = value; txt_paterno.Visible = value; rfv_paterno.Enabled = value; rev_paterno.Enabled = value; } }
    public bool Visible_materno { get { return txt_materno.Visible; } set { lbl_materno.Visible = value; txt_materno.Visible = value; rfv_materno.Enabled = value; rev_materno.Enabled = value; } }
    public bool Visible_ci { get { return txt_ci.Visible; } set { lbl_ci.Visible = value; txt_ci.Visible = value; rfv_ci.Enabled = value; rev_ci.Enabled = value; } }
    public bool Visible_email { get { return txt_email.Visible; } set { lbl_email.Visible = value; txt_email.Visible = value; rev_email.Enabled = value; } }
    public bool Visible_imagen_file { get { return fu_imagen.Visible; } set { lbl_imagen.Visible = value; fu_imagen.Visible = value; img_imagen.Visible = value; lb_imagen_eliminar.Visible = value; } }
    public bool Visible_imagen_img { get { return img_imagen.Visible; } set { img_imagen.Visible = value; lb_imagen_eliminar.Visible = value; } }
    public bool Visible_nombre_usuario { get { return txt_nombre_usuario.Visible; } set { lbl_nombre_usuario.Visible = value; txt_nombre_usuario.Visible = value; rfv_nombre_usuario.Enabled = value; rev_nombre_usuario.Enabled = value; } }
    public bool Visible_password { get { return txt_password.Visible; } set { lbl_password.Visible = value; txt_password.Visible = value; lbl_password_confirm.Visible = value; txt_password_confirm.Visible = value; rfv_password.Enabled = value; rev_password.Enabled = value; rfv_password_confirm.Enabled = value; rev_password_confirm.Enabled = value; cv_password_confirm.Enabled = value; } }
    public bool Visible_activo { get { return cb_activo.Visible; } set { lbl_activo.Visible = value; cb_activo.Visible = value; } }
    public bool Visible_desbloquear { get { return bool.Parse(lbl_desbloquear.Text); } set { lbl_desbloquear.Text = value.ToString(); } }
    public bool Visible_permiso { get { return lbl_permisos.Visible; } set { lbl_permisos.Visible = value; panel_recurso.Visible = value; } }

    public bool RequiredField_password { get { return rfv_password.Enabled; } set { rfv_password.Enabled = value; rfv_password_confirm.Enabled = value; } }

    public void RecuperarDatos(int Id_rol_, int Id_usuario_)
    {
        this.id_rol = Id_rol_;
        this.id_usuario = Id_usuario_;
        usuario u = new usuario(Id_usuario_);
        this.paterno = u.paterno;
        this.materno = u.materno;
        this.nombres = u.nombres;
        this.ci = u.ci;
        this.email = u.email;
        img_imagen.ImageUrl = usuario.ImagenDireccion(u.imagen);
        if (Visible_imagen_img == true) lb_imagen_eliminar.Visible = u.imagen.Equals("").Equals(false);
        else lb_imagen_eliminar.Visible = false;
        this.nombre_usuario = u.nombre_usuario;
        this.password = "";
        this.activo = u.activo;
        if (Visible_desbloquear == true && Membership.GetUser(u.nombre_usuario).IsLockedOut == true) lb_desbloquear.Visible = true;
        else lb_desbloquear.Visible = false;
        r_grupo_recurso.DataBind();
        //if (Visible_permiso == true) //panel_recurso.Visible = true;

        //lbl_permisos.Visible = r_grupo_recurso.Items.Count.Equals(0).Equals(false);
        //panel_recurso.Visible = r_grupo_recurso.Items.Count.Equals(0).Equals(false);
        
        //else panel_recurso.Visible = false;
        if (this.Enabled_nombres == true) txt_nombres.Focus();
    }
    
    public void Reset(int Id_rol)
    {
        this.id_rol = Id_rol;
        this.id_usuario = 0;
        this.paterno = "";
        this.materno = "";
        this.nombres = "";
        this.ci = "";
        this.email = "";
        img_imagen.Visible = false;
        lb_imagen_eliminar.Visible = false;
        this.nombre_usuario = "";
        this.password = "";
        this.activo = true;
        lb_desbloquear.Visible = false;
        r_grupo_recurso.DataBind();
        //if (Visible_permiso == true) //panel_recurso.Visible = true;
        
        //lbl_permisos.Visible = r_grupo_recurso.Items.Count.Equals(0).Equals(false);
        //panel_recurso.Visible = r_grupo_recurso.Items.Count.Equals(0).Equals(false);
        
        //else panel_recurso.Visible = false;
        if (this.Enabled_nombres == true) txt_nombres.Focus();
    }

    public bool Verificar(int _Id_usuario)
    {
        bool correcto = true;
        if (usuario.VerificarNombreUsuario(_Id_usuario.Equals(0), _Id_usuario, nombre_usuario) == true)
        {
            Msg1.Text = "El nombre de usuario pertenece a otro usuario registrado";
            correcto = false;
        }
        if (usuario.VerificarCI(_Id_usuario.Equals(0), _Id_usuario, ci) == true)
        {
            Msg1.Text = "El Nº de documento de identidad pertenece a otro usuario registrado";
            correcto = false;
        }
        if (usuario.VerificarNombreCompleto(_Id_usuario.Equals(0), _Id_usuario, nombres, paterno, materno) == true)
        {
            Msg1.Text = "El nombre de la persona pertenece a otro usuario registrado";
            correcto = false;
        }
        if (imagen.HasFile == true)
        {
            if (imagen.PostedFile.ContentLength > Int32.Parse(ConfigurationManager.AppSettings["usuario_tam_imagen"]))
            {
                Msg1.Text = "El archivo de la imagen tiene un tamaño mayor al permitido (" + Math.Round(Double.Parse(ConfigurationManager.AppSettings["usuario_tam_imagen"]) / 1024, 2) + " KB)";
                correcto = false;
            }
            if (ConfigurationManager.AppSettings["usuario_tipo_imagen"].Contains(System.IO.Path.GetExtension(imagen.FileName)) == false)
            {
                Msg1.Text = "El archivo de la imagen no tiene un formato permitido (" + ConfigurationManager.AppSettings["usuario_tipo_imagen"] + ")";
                correcto = false;
            }
        }
        return correcto;
    }

    protected void r_grupo_recurso_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((Repeater)e.Item.FindControl("r_recurso")).DataSource = recurso.ListaPorRolGrupoRecurso(this.id_rol, (int)DataBinder.Eval(e.Item.DataItem, "id_gruporecurso"));
            ((Repeater)e.Item.FindControl("r_recurso")).DataBind();
        }
    }
    protected void r_recurso_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ((CheckBoxList)e.Item.FindControl("cbl_permiso")).DataSource = permiso.ListaPorRecurso((int)DataBinder.Eval(e.Item.DataItem, "id_recurso"));
        ((CheckBoxList)e.Item.FindControl("cbl_permiso")).DataBind();
    }

    protected void cbl_permiso_DataBound(object sender, EventArgs e)
    {
        foreach (ListItem item in ((CheckBoxList)sender).Items)
            if (this.id_usuario > 0)
                item.Selected = usuario_rol_permiso.Verificar(this.id_usuario, this.id_rol, int.Parse(item.Value));
    }

    protected void lb_imagen_eliminar_Click(object sender, EventArgs e)
    {
        usuario u = new usuario(id_usuario);
        u.imagen = "";
        u.ImagenActualizar(Profile.id_usuario);
        img_imagen.ImageUrl = usuario.ImagenDireccion(u.imagen);
        lb_imagen_eliminar.Visible = false;
    }

    protected void lb_desbloquear_Click(object sender, EventArgs e)
    {
        Membership.GetUser(new usuario(id_usuario).nombre_usuario).UnlockUser();
    }
</script>
<asp:Label ID="lbl_id_rol" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_desbloquear" runat="server" Text="True" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_usuario" runat="server" DisplayMode="List" ValidationGroup="usuario" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del usuario"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_nombres" runat="server" Text="Nombres:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe introducir el nombre del usuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_nombres" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_paterno" runat="server" Text="Apellido paterno:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe introducir el apellido paterno del usuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido paterno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_paterno" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_materno" runat="server" Text="Apellido materno:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_materno" runat="server" Enabled="false" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe introducir el apellido materno del usuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido materno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_materno" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_ci" runat="server" Text="Nº doc. de identidad:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe introducir el Nº del documento de identidad del usuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_ci %>" Text="*" ErrorMessage="El Nº del documento de identidad contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine200" MaxLength="25"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_email" runat="server" Text="Dirección Email:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_email %>" Text="*" ErrorMessage="La dirección Email es incorrecta"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_email" runat="server" SkinID="txtSingleLine200" MaxLength="200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_imagen" runat="server" Text="Imagen:"></asp:Label></td>
        <td class="formTdDato">
            <table>
                <tr>
                    <td><asp:Image ID="img_imagen" runat="server" Height="<%$ AppSettings:usuario_tam_img %>" /></td>
                    <td valign="bottom"><asp:LinkButton ID="lb_imagen_eliminar" runat="server" Text="Borrar" OnClick="lb_imagen_eliminar_Click"></asp:LinkButton></td>
                </tr>
                <tr><td colspan="2"><asp:FileUpload ID="fu_imagen" runat="server" SkinID="fuFileUpload200" /></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_nombre_usuario" runat="server" Text="Nombre de usuario:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_nombre_usuario" runat="server" ControlToValidate="txt_nombre_usuario" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe introducir el nombre de usuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre_usuario" runat="server" ControlToValidate="txt_nombre_usuario" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_nombre_usuario %>" Text="*" ErrorMessage="El nombre de usuario contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_nombre_usuario" runat="server" SkinID="txtSingleLine200" MaxLength="25"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_password" runat="server" Text="Contraseña de ingreso:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_password" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe introducir la contraseña"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_password" runat="server" ControlToValidate="txt_password" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_password %>" Text="*" ErrorMessage="La contraseña contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_password" runat="server" TextMode="Password" SkinID="txtPassword" MaxLength="25"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_password_confirm" runat="server" Text="Confirme la contraseña:"></asp:Label></td>
        <td class="formTdDato">
            <asp:RequiredFieldValidator ID="rfv_password_confirm" runat="server" ControlToValidate="txt_password_confirm" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Text="*" ErrorMessage="Debe confirmar la contraseña"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_password_confirm" runat="server" ControlToValidate="txt_password_confirm" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" ValidationExpression="<%$ AppSettings:usuario_ExpReg_password %>" Text="*" ErrorMessage="La confirmación de la contraseña contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:CompareValidator ID="cv_password_confirm" runat="server" ControlToValidate="txt_password_confirm" ControlToCompare="txt_password" Display="Dynamic" SetFocusOnError="true" ValidationGroup="usuario" Type="String" Operator="Equal" Text="*" ErrorMessage="La confirmación de la contraseña es incorrecta"></asp:CompareValidator>
            <asp:TextBox ID="txt_password_confirm" runat="server" TextMode="Password" SkinID="txtPassword" MaxLength="25"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_activo" runat="server" Text="Usuario activo:"></asp:Label></td>
        <td class="formTdDato"><asp:CheckBox ID="cb_activo" runat="server" Text="Usuario activo" Checked="true" /></td>
    </tr>
    <tr>
        <td class="formTdEnun"></td>
        <td class="formTdDato"><asp:LinkButton ID="lb_desbloquear" runat="server" Text="Desbloquear usuario" OnClick="lb_desbloquear_Click"></asp:LinkButton></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_permisos" runat="server" Text="Permisos:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Panel ID="panel_recurso" runat="server" ScrollBars="Vertical" Height="200">
                <%--[id_gruporecurso],[codigo],[nombre]--%>
                <asp:Repeater ID="r_grupo_recurso" runat="server" DataSourceID="ods_ListaPorRol" OnItemDataBound="r_grupo_recurso_ItemDataBound">
                    <HeaderTemplate><table></HeaderTemplate>
                    <ItemTemplate><tr><td>
                        <asp:Panel ID="panel_gruporecurso" runat="server" GroupingText='<%# Eval("nombre") %>'>
                            <%--[id_recurso],[id_gruporecurso],[codigo],[nombre]--%>
                            <asp:Repeater ID="r_recurso" runat="server" OnItemDataBound="r_recurso_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Panel ID="panel_recurso" runat="server" GroupingText='<%# Eval("nombre") %>'>
                                        <asp:CheckBoxList ID="cbl_permiso" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" DataTextField="nombre" DataValueField="id_permiso" OnDataBound="cbl_permiso_DataBound"></asp:CheckBoxList>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:Panel>
                    </td></tr></ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
            </asp:Panel>
            <asp:ObjectDataSource ID="ods_ListaPorRol" runat="server" TypeName="terrasur.grupo_recurso" SelectMethod="ListaPorRol">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_rol" Type="Int32" ControlID="lbl_id_rol" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>