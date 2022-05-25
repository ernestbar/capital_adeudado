<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Usuarios que procesan reembolsos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reUsuario", "view"))
            {
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reUsuario", "insert");
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        btn_nuevo.Visible = false;
        panel_nuevo.Visible = true;
        txt_ci.Text = "";
        txt_ci.Focus();
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_ci.Text.Trim()))
        {
            int id_usuario = terrasur.traspaso.usuario_reembolso.IdPorCI(txt_ci.Text.Trim());
            if (id_usuario > 0)
            {
                if (!terrasur.traspaso.usuario_reembolso.Verificar(id_usuario))
                {
                    if (terrasur.traspaso.usuario_reembolso.Insertar(id_usuario, Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
                    {
                        Msg1.Text = "El usuario se agregó correctamente";
                        txt_ci.Text = "";
                        txt_ci.Focus();
                        gv1.DataBind();
                    }
                    else { Msg1.Text = "El usuario NO se agregó correctamente"; }
                }
                else { Msg1.Text = "El usuario ya se encuentra registrado para procesar reembolsos"; }
            }
            else { Msg1.Text = "El número de cédula introducido no corresponde a un usuario"; }
        }
        else { Msg1.Text = "Debe introducir el número de cédula del usuario"; }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        btn_nuevo.Visible = true;
        panel_nuevo.Visible = false;
    }

    protected void gv1_DataBound(object sender, EventArgs e)
    {
        gv1.Columns[0].Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reUsuario", "delete");
    }

    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //general.OnMouseOver(sender, e);
        }
    }

    protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eliminar")
        {
            if (terrasur.traspaso.usuario_reembolso.Eliminar(int.Parse(e.CommandArgument.ToString()), Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                gv1.DataBind();
                Msg1.Text = "El usuario se retiró correctamente";
            }
            else { Msg1.Text = "El usuario NO se retiró correctamente"; }
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reUsuario" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Usuarios que procesan reembolsos</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdButton">
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo usuario" OnClick="btn_nuevo_Click" />
                                        <asp:Panel ID="panel_nuevo" runat="server" GroupingText="Nuevo usuario" Visible="false">
                                            <table>
                                                <tr>
                                                    <td><asp:Label ID="lbl_ci_enun" runat="server" Text="CI:" SkinID="lblEnun"></asp:Label></td>
                                                    <td><asp:TextBox ID="txt_ci" runat="server"></asp:TextBox></td>
                                                    <td><asp:Button ID="btn_insertar" runat="server" Text="Agregar" OnClick="btn_insertar_Click" /></td>
                                                    <td><asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid"><%--WizardGridView AllowPaging="true" PageSize="20"--%>
                            <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" DataSourceID="ods_usuarioReembolso_lista" DataKeyNames="id_usuario" OnDataBound="gv1_DataBound" OnRowDataBound="gv1_RowDataBound" OnRowCommand="gv1_RowCommand">
                                <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_usuario") %>' OnClientClick="return confirm('¿Esta seguro que desea retirar al usuario?');" /></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField HeaderText="CI" DataField="ci" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_usuario],[ci],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_usuarioReembolso_lista" runat="server" TypeName="terrasur.traspaso.usuario_reembolso" SelectMethod="Lista">
                                <SelectParameters><asp:Parameter Name="Id_usuario" Type="Int32" DefaultValue="0" /></SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

