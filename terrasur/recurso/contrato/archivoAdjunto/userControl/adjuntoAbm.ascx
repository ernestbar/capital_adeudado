<%@ Control Language="C#" ClassName="adjuntoAbm" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Collections.Generic" %>
<script runat="server">
    public int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); CargarDatos(); } }
    public int id_documento { get { return int.Parse(lbl_id_documento.Text); } set { lbl_id_documento.Text = value.ToString(); } }

    private bool permiso_insert { get { return bool.Parse(lbl_permiso_insert.Text); } set { lbl_permiso_insert.Text = value.ToString(); } }
    private bool permiso_update { get { return bool.Parse(lbl_permiso_update.Text); } set { lbl_permiso_update.Text = value.ToString(); } }
    private bool permiso_delete { get { return bool.Parse(lbl_permiso_delete.Text); } set { lbl_permiso_delete.Text = value.ToString(); } }
    
    private void CargarDatos()
    {
        permiso_insert = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "archivoAdjunto", "insert");
        permiso_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "archivoAdjunto", "update");
        permiso_delete = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "archivoAdjunto", "delete");

        btn_nuevo.Visible = permiso_insert;
        panel_documento.Visible = true;
        panel_adjunto.Visible = false;
        gv_documento.DataBind();
    }

    protected void gv_documento_DataBound(object sender, EventArgs e)
    {
        gv_documento.Columns[1].Visible = permiso_update;
        gv_documento.Columns[2].Visible = permiso_delete;
    }

    protected void gv_documento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Controls[0].Visible = int.Parse(DataBinder.Eval(e.Row.DataItem, "num_archivos").ToString()).Equals(0).Equals(false);
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        id_documento = 0;
        CargarInsertar();
    }

    protected void gv_documento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ver")
        {
            int _id_documento = int.Parse(gv_documento.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            Session["id_documento"] = _id_documento;
            WinPopUp1.Show();
        }
        else if (e.CommandName == "editar")
        {
            id_documento = int.Parse(gv_documento.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            CargarActualizar();
        }
        else if (e.CommandName == "eliminar")
        {
            adj_documento aObj = new adj_documento(int.Parse(e.CommandArgument.ToString()));
            if (aObj.Eliminar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El documento se eliminó correctamente";
                gv_documento.DataBind();
            }
            else { Msg1.Text = "El documento NO se eliminó correctamente"; }
        }
    }

    protected void CargarInsertar()
    {
        id_documento = 0;

        panel_documento.Visible = false;
        panel_adjunto.Visible = true;
        txt_nombre.Text = "";
        btn_insertar.Visible = true;
        btn_actualizar.Visible = false;
        gv_archivo.DataBind();
        txt_nombre.Focus();
    }

    protected void CargarActualizar()
    {
        panel_documento.Visible = false;
        panel_adjunto.Visible = true;
        txt_nombre.Text = (new adj_documento(id_documento)).nombre;
        btn_insertar.Visible = false;
        btn_actualizar.Visible = true;
        gv_archivo.DataBind();
        txt_nombre.Focus();
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        gv_documento.DataBind();
        panel_documento.Visible = true;
        panel_adjunto.Visible = false;
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        Insertar();
    }

    protected void Insertar()
    {
        if (Page.IsValid == true)
        {
            adj_documento dObj = new adj_documento(id_contrato, txt_nombre.Text.Trim());
            if (dObj.Insertar(Profile.id_usuario) == true)
            {
                id_documento = dObj.id_documento;
                //CargarInsertar();
                btn_insertar.Visible = false;
                btn_actualizar.Visible = true;

                Msg1.Text = "El documento se registró correctamente";
            }
            else { Msg1.Text = "El documento NO se registró correctamente"; }
        }
        else { Msg1.Text = "El documento NO se registró correctamente"; }
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            if ((new adj_documento(id_documento, id_contrato, txt_nombre.Text.Trim())).Actualizar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El nombre del documento se actualizó correctamente";
            }
            else { Msg1.Text = "El nombre del documento NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El nombre del documento NO se actualizó correctamente"; }
    }

    protected void btn_archivo_Click(object sender, EventArgs e)
    {
        bool correcto;
        if (id_documento == 0)
        {
            Insertar();
            if (id_documento > 0) { correcto = true; } else { correcto = false; }
        }
        else { correcto = true; }

        if (correcto == true)
        {
            if (fu_archivo.HasFile == true)
            {
                string nombre_archivo = fu_archivo.FileName;
                string extension_archivo = System.IO.Path.GetExtension(nombre_archivo);
                if (ConfigurationManager.AppSettings["adjunto_tipo_imagen"].Contains(extension_archivo) == true)
                {
                    adj_archivo aObj = new adj_archivo(id_documento, nombre_archivo);
                    if (aObj.Insertar(Profile.id_usuario) == true)
                    {
                        try
                        {
                            aObj.codigo = aObj.id_archivo.ToString() + extension_archivo;
                            fu_archivo.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["adjunto_dir_imagen"] + aObj.codigo));
                            aObj.Actualizar();
                            Msg1.Text = "El archivo se guardó correctamente";
                            gv_archivo.DataBind();
                        }
                        catch
                        {
                            Msg1.Text = "El archivo NO se guardó correctamente";
                            aObj.Eliminar(Profile.id_usuario);
                        }
                    }
                    else { Msg1.Text = "El archivo se guardó correctamente"; }
                }
                else { Msg1.Text = "El archivo NO se guardó, debe elegir una imagen"; }
            }
            else { Msg1.Text = "Debe seleccionar un archivo"; }
        }
    }

    protected void gv_archivo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ver")
        {
            Session["id_archivo"] = gv_archivo.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
            WinPopUp1.Show();
        }
        else if (e.CommandName == "eliminar")
        {
            if (new adj_archivo(int.Parse(e.CommandArgument.ToString())).Eliminar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El acrhivo se eliminó correctamente";
                gv_archivo.DataBind();
            }
            else { Msg1.Text = "El acrhivo NO se eliminó correctamente"; }
        }
    }

</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_documento" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_insert" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_update" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_delete" runat="server" Text="false" Visible="false"></asp:Label>

<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/archivoAdjunto/documentoDetalle.aspx"
    Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="620"
    Win_Left="20" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
    Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="20" Win_Width="850">[WinPopUp1]</asp:WinPopUp>

<table align="center" width="100%">
    <tr>
        <td align="center">
            <asp:Panel ID="panel_documento" runat="server" GroupingText="Documentos adjuntos">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btn_nuevo" runat="server" Text="Agregar documento" onclick="btn_nuevo_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gv_documento" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_documentos" DataKeyNames="id_documento" OnDataBound="gv_documento_DataBound" OnRowCommand="gv_documento_RowCommand" OnRowDataBound="gv_documento_RowDataBound">
                                <Columns>
                                    <asp:ButtonField CommandName="ver" Text="Ver archivos" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                    <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                    <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_documento") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el documento, junto con todos sus archivos?');" /></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField HeaderText="Documento" DataField="nombre" />
                                    <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                                    <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                                    <asp:BoundField HeaderText="Nro.Archivos" DataField="num_archivos" ItemStyle-CssClass="gvCell1" />
                                </Columns>
                                <EmptyDataTemplate>No existen documentos del contrato</EmptyDataTemplate>
                            </asp:GridView>
                            <%--[id_documento],[fecha],[nombre],[usuario],[num_archivos]--%>
                            <asp:ObjectDataSource ID="ods_lista_documentos" runat="server" TypeName="terrasur.adj_documento" SelectMethod="ListaPorContrato">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Panel ID="panel_adjunto" runat="server" GroupingText="Archivos del documento adjunto">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar / Volver" OnClick="btn_cancelar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="formTdMsg" colspan="2">
                                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                        <asp:ValidationSummary ID="vs_adjunto" runat="server" DisplayMode="List" ValidationGroup="adjunto" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTdEnun">Nombre:</td>
                                    <td class="formTdDato">
                                        <asp:TextBox ID="txt_nombre" runat="server" Width="253" MaxLength="100" ValidationGroup="adjunto"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" Display="Dynamic" ControlToValidate="txt_nombre" Text="*" ErrorMessage="Debe introducir el nombre del documento" ValidationGroup="adjunto"></asp:RequiredFieldValidator>
                                        <asp:Button ID="btn_insertar" runat="server" Text="Registrar" CausesValidation="true" ValidationGroup="adjunto" OnClick="btn_insertar_Click" />
                                        <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="adjunto" OnClick="btn_actualizar_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTdEnun">Archivos:</td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="fu_archivo" runat="server" />
                                                    <asp:Button ID="btn_archivo" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="adjunto" onclick="btn_archivo_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gv_archivo" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_archivos" DataKeyNames="id_archivo" OnRowCommand="gv_archivo_RowCommand">
                                                        <Columns>
                                                            <asp:ButtonField CommandName="ver" Text="Ver archivo" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                                            <asp:BoundField HeaderText="Archivo" DataField="nombre" />
                                                            <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                                                            <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                                                            <%--<asp:BoundField HeaderText="Codigo" DataField="codigo" />--%>
                                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_archivo") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el archivo?');" /></ItemTemplate></asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <%--[id_archivo],[fecha],[codigo],[nombre],[usuario]--%>
                                                    <asp:ObjectDataSource ID="ods_lista_archivos" runat="server" TypeName="terrasur.adj_archivo" SelectMethod="Lista">
                                                        <SelectParameters>
                                                            <asp:ControlParameter Name="Id_documento" Type="Int32" ControlID="lbl_id_documento" PropertyName="Text" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
