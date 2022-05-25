<%@ Control Language="C#" ClassName="archivoShapeAbm" %>

<script runat="server">
    protected int id_archivo { get { return int.Parse(lbl_id_archivo.Text); } set { lbl_id_archivo.Text = value.ToString(); } }
    protected int id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }
    protected bool insertar { get { return bool.Parse(lbl_insertar.Text); } set { lbl_insertar.Text = value.ToString(); } }
    protected bool editar { get { return bool.Parse(lbl_editar.Text); } set { lbl_editar.Text = value.ToString(); } }
    protected bool eliminar { get { return bool.Parse(lbl_eliminar.Text); } set { lbl_eliminar.Text = value.ToString(); } }

    public void Reset(int _id_urbanizacion, bool _insertar, bool _editar, bool _eliminar)
    {
        id_urbanizacion = _id_urbanizacion;
        insertar = _insertar;
        editar = _editar;
        eliminar = _eliminar;

        urbanizacion uObj = new urbanizacion(id_urbanizacion);
        lbl_urb.Text = uObj.nombre;
        btn_nuevo.Visible = insertar;
        gv_archivo.DataBind();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void gv_archivo_DataBound(object sender, EventArgs e)
    {
        gv_archivo.Columns[0].Visible = editar;
        gv_archivo.Columns[1].Visible = eliminar;
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        CargarInsertar();
        MultiView1.ActiveViewIndex = 1;
    }

    protected void gv_archivo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editar")
        {
            CargarActualizar(int.Parse(gv_archivo.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()));
            MultiView1.ActiveViewIndex = 1;
        }
        else if (e.CommandName == "eliminar")
        {
            archivo_shape a = new archivo_shape(int.Parse(e.CommandArgument.ToString()));
            if (a.Eliminar(Profile.id_usuario) == true)
            {
                if (System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shp)) == true)
                    System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shp));
                if (System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.dbf)) == true)
                    System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.dbf));
                if (System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shx)) == true)
                    System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shx));
                
                gv_archivo.DataBind();
                Msg1.Text = "El archivo Shape se eliminó correctamente";
            }
            else { Msg1.Text = "El archivo Shape NO se eliminó correctamente"; }
        }
            
    }

    protected void CargarInsertar()
    {
        lbl_title.Text = "Nuevo archivo Shape";
        txt_nombre.Text = "";
        rfv_nombre.Enabled = false;

        rfv_shp.Enabled = true;
        rfv_dbf.Enabled = true;
        rfv_shx.Enabled = true;
        
        cb_shp.Checked = false;
        cb_dbf.Checked = false;
        cb_shx.Checked = false;

        cb_guia_datos.Checked = false;
        cb_guia_lotes.Checked = false;

        btn_insertar.Visible = true;
        btn_actualizar.Visible = false;
    }
    protected bool VerificarInsertar()
    {
        bool correcto = true;
        if (fu_shp.FileName.ToLower().EndsWith(".shp") == false)
        {
            Msg1.Text = "La extensión del archivo SHP es incorrecta";
            correcto = false;
        }
        if (fu_dbf.FileName.ToLower().EndsWith(".dbf") == false)
        {
            Msg1.Text = "La extensión del archivo DBF es incorrecta";
            correcto = false;
        }
        if (fu_shx.FileName.ToLower().EndsWith(".shx") == false)
        {
            Msg1.Text = "La extensión del archivo SHX es incorrecta";
            correcto = false;
        }
        if (correcto == true && txt_nombre.Text.Trim() == "") txt_nombre.Text = fu_shp.FileName.Replace(".SHP", "").Replace(".shp", "");
        return correcto;
    }
    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (VerificarInsertar() == true)
        {
            archivo_shape a = new archivo_shape(0, id_urbanizacion, txt_nombre.Text.Trim(), cb_guia_datos.Checked, cb_guia_lotes.Checked);
            if (a.Insertar(Profile.id_usuario) == true)
            {
                bool correcto = true;
                string nombre_archivo = id_urbanizacion.ToString() + "shape" + a.id_archivo.ToString();
                try
                {
                    fu_shp.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + nombre_archivo + ".shp"));
                    if (archivo_shape.ActualizarImagen(a.id_archivo, "shp", nombre_archivo + ".shp", Profile.id_usuario) == true)
                        Msg1.Text = "El archivo SHP se guardó correctamente";
                    else
                    {
                        correcto = false;
                        Msg1.Text = "El archivo SHP NO se guardó correctamente";
                    }
                }
                catch
                {
                    correcto = false;
                    Msg1.Text = "El archivo SHP NO se guardó correctamente";
                }

                if (correcto == true)
                {
                    try
                    {
                        fu_dbf.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + nombre_archivo + ".dbf"));
                        if (archivo_shape.ActualizarImagen(a.id_archivo, "dbf", nombre_archivo + ".dbf", Profile.id_usuario) == true)
                            Msg1.Text = "El archivo DBF se guardó correctamente";
                        else
                        {
                            correcto = false;
                            Msg1.Text = "El archivo DBF NO se guardó correctamente";
                        }
                    }
                    catch
                    {
                        correcto = false;
                        Msg1.Text = "El archivo DBF NO se guardó correctamente";
                    }
                }

                if (correcto == true)
                {
                    try
                    {
                        fu_shx.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + nombre_archivo + ".shx"));
                        if (archivo_shape.ActualizarImagen(a.id_archivo, "shx", nombre_archivo + ".shx", Profile.id_usuario) == true)
                            Msg1.Text = "El archivo SHX se guardó correctamente";
                        else
                        {
                            correcto = false;
                            Msg1.Text = "El archivo SHX NO se guardó correctamente";
                        }
                    }
                    catch
                    {
                        correcto = false;
                        Msg1.Text = "El archivo SHX NO se guardó correctamente";
                    }
                }

                if (correcto == true)
                {
                    Msg1.Text = "Los datos del archivo Shape se guardaron correctamente";
                    gv_archivo.DataBind();
                    CargarInsertar();
                }
                else
                {
                    if (a.Eliminar(Profile.id_usuario) == true)
                    {
                        if (a.shp != "" && System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shp)) == true)
                            System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shp));
                        if (a.dbf != "" && System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.dbf)) == true)
                            System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.dbf));
                        if (a.shx != "" && System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shx)) == true)
                            System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shx));
                    }
                    Msg1.Text = "Los datos del archivo Shape NO se guardaron correctamente";
                }
            }
            else { Msg1.Text = "Los datos del archivo Shape NO se guardaron correctamente"; }
        }
    }
    
    
    protected void CargarActualizar(int Id_archivo)
    {
        id_archivo = Id_archivo;
        lbl_title.Text = "Edición del archivo Shape";

        archivo_shape a = new archivo_shape(Id_archivo);
        txt_nombre.Text = a.nombre;
        rfv_nombre.Enabled = true;

        rfv_shp.Enabled = false;
        rfv_dbf.Enabled = false;
        rfv_shx.Enabled = false;

        cb_shp.Checked = System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shp));
        cb_dbf.Checked = System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.dbf));
        cb_shx.Checked = System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + a.shx));

        cb_guia_datos.Checked = a.guia_datos;
        cb_guia_lotes.Checked = a.guia_lotes;

        btn_insertar.Visible = false;
        btn_actualizar.Visible = true;
    }
    protected bool VerificarActualizar()
    {
        bool correcto = true;
        if (fu_shp.HasFile == true)
        {
            if (fu_shp.FileName.ToLower().EndsWith(".shp") == false)
            {
                Msg1.Text = "La extensión del archivo SHP es incorrecta";
                correcto = false;
            }
        }
        if (fu_dbf.HasFile == true)
        {    
            if (fu_dbf.FileName.ToLower().EndsWith(".dbf") == false)
        {
            Msg1.Text = "La extensión del archivo DBF es incorrecta";
            correcto = false;
            }
        }
        if (fu_shx.HasFile == true)
        {
            if (fu_shx.FileName.ToLower().EndsWith(".shx") == false)
            {
                Msg1.Text = "La extensión del archivo SHX es incorrecta";
                correcto = false;
            }
        }
        return correcto;
    }
    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (VerificarActualizar() == true)
        {
            archivo_shape a = new archivo_shape(id_archivo, id_urbanizacion, txt_nombre.Text.Trim(), cb_guia_datos.Checked, cb_guia_lotes.Checked);
            if (a.Actualizar(Profile.id_usuario) == true)
            {
                archivo_shape aObj = new archivo_shape(id_archivo);

                if (fu_shp.HasFile == true)
                {
                    try
                    {
                        fu_shp.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + aObj.shp));
                        Msg1.Text = "El archivo SHP se actualizó correctamente";
                    }
                    catch { Msg1.Text = "El archivo SHP NO se actualizó correctamente"; }
                }
                
                if (fu_dbf.HasFile == true)
                {
                    try
                    {
                        fu_dbf.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + aObj.dbf));
                        Msg1.Text = "El archivo DBF se actualizó correctamente";
                    }
                    catch { Msg1.Text = "El archivo DBF NO se actualizó correctamente"; }
                }

                if (fu_shx.HasFile == true)
                {
                    try
                    {
                        fu_shx.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + aObj.shx));
                        Msg1.Text = "El archivo SHX se actualizó correctamente";
                    }
                    catch { Msg1.Text = "El archivo SHX NO se actualizó correctamente"; }
                }

                Msg1.Text = "Los datos del archivo Shape se actualizaron correctamente";
                gv_archivo.DataBind();
            }
            else { Msg1.Text = "Los datos del archivo Shape NO se actualizaron correctamente"; }
        }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
</script>
<asp:Label ID="lbl_id_archivo" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_insertar" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_editar" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_eliminar" runat="server" Text="false" Visible="false"></asp:Label>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td class="priTdTitle">
            <table align="center">
                <tr>
                    <td><asp:Label ID="lbl_urb_enun" runat="server" Text="Sector:"></asp:Label></td>
                    <td><asp:Label ID="lbl_urb" runat="server"></asp:Label></td>
                </tr>
            </table>
            <%--<table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formTdEnun"><asp:Label ID="lbl_urb_enun" runat="server" Text="Sector:" SkinID="lblEnun"></asp:Label></td>
                    <td class="formTdDato"><asp:Label ID="lbl_urb" runat="server" SkinID="lblEnun"></asp:Label></td>
                </tr>
            </table>--%>
        </td>
    </tr>
    <tr>
        <td class="tdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_lote" runat="server" DisplayMode="List" ValidationGroup="shape" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btn_nuevo" runat="server" Text="Agregar archivo" OnClick="btn_nuevo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gv_archivo" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_archivos" DataKeyNames="id_archivo" OnDataBound="gv_archivo_DataBound" OnRowCommand="gv_archivo_RowCommand">
                                    <Columns>
                                        <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                        <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_archivo") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el archivo Shape?');" /></ItemTemplate></asp:TemplateField>
                                        <asp:BoundField HeaderText="Archivo" DataField="nombre" />
                                        <asp:CheckBoxField HeaderText="SHP" Text="shp" DataField="shp" />
                                        <asp:CheckBoxField HeaderText="DBF" Text="dbf" DataField="dbf" />
                                        <asp:CheckBoxField HeaderText="SHX" Text="shx" DataField="shx" />
                                        <%--<asp:CheckBoxField HeaderText="Guía de datos" Text="Guía de datos" DataField="guia_datos" />--%>
                                        <asp:TemplateField HeaderText="Guía de datos"><ItemTemplate><asp:RadioButton ID="rb_guia_datos" runat="server" Text="Guía de datos" Enabled="false" Checked='<%# Eval("guia_datos") %>' /></ItemTemplate></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Guía de lotes"><ItemTemplate><asp:RadioButton ID="rb_guia_lotes" runat="server" Text="Guía de lotes" Enabled="false" Checked='<%# Eval("guia_lotes") %>' /></ItemTemplate></asp:TemplateField>
                                        <asp:BoundField HeaderText="Fecha Modif." DataField="fecha" />
                                        <asp:BoundField HeaderText="Usuario Modif." DataField="nombre_usuario" />
                                    </Columns>
                                    <EmptyDataTemplate>No existen archivos Shape en este sector</EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <%--[id_archivo],[nombre],[shp],[dbf],[shx],[guia_datos],[guia_lotes],[fecha],[nombre_usuario]--%>
                    <asp:ObjectDataSource ID="ods_lista_archivos" runat="server" TypeName="terrasur.archivo_shape" SelectMethod="ListaArchivosPorUrbanizacion">
                        <SelectParameters>
                            <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="formTdTitle" colspan="2">
                                <asp:Label ID="lbl_title" runat="server" Text="Nuevo archivo Shape"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Nombre del Shape:</td>
                            <td class="formTdDato">
                                <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" ValidationGroup="shape" Display="Dynamic" Text="*" ErrorMessage="Debe introducir el nombre del archivo Shape"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Archivo SHP:</td>
                            <td class="formTdDato">
                                <asp:FileUpload ID="fu_shp" runat="server" />
                                <asp:RequiredFieldValidator ID="rfv_shp" runat="server" ControlToValidate="fu_shp" ValidationGroup="shape" Display="Dynamic" Text="*" ErrorMessage="Debe seleccionar el archivo SHP"></asp:RequiredFieldValidator>
                                <asp:CheckBox ID="cb_shp" runat="server" Enabled="false" Text="existe" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Archivo DBF:</td>
                            <td class="formTdDato">
                                <asp:FileUpload ID="fu_dbf" runat="server" />
                                <asp:RequiredFieldValidator ID="rfv_dbf" runat="server" ControlToValidate="fu_dbf" ValidationGroup="shape" Display="Dynamic" Text="*" ErrorMessage="Debe seleccionar el archivo DBF"></asp:RequiredFieldValidator>
                                <asp:CheckBox ID="cb_dbf" runat="server" Enabled="false" Text="existe" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Archivo SHX:</td>
                            <td class="formTdDato">
                                <asp:FileUpload ID="fu_shx" runat="server" />
                                <asp:RequiredFieldValidator ID="rfv_shx" runat="server" ControlToValidate="fu_shx" ValidationGroup="shape" Display="Dynamic" Text="*" ErrorMessage="Debe seleccionar el archivo SHX"></asp:RequiredFieldValidator>
                                <asp:CheckBox ID="cb_shx" runat="server" Enabled="false" Text="existe" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Guía de datos:</td>
                            <td class="formTdDato"><asp:CheckBox ID="cb_guia_datos" runat="server" Text="Se utiliza para ver DATOS DETALLADOS de lotes" /></td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Guía de lotes:</td>
                            <td class="formTdDato"><asp:CheckBox ID="cb_guia_lotes" runat="server" Text="Se utiliza para mostrar los ESTADOS de lotes" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btn_insertar" runat="server" Text="Guardar" OnClick="btn_insertar_Click" CausesValidation="true" ValidationGroup="shape" />
                                <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" CausesValidation="true" ValidationGroup="shape" />
                                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>

        </td>
    </tr>
</table>

