<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Motivos de reembolso" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/reembolso/reMotivo/userControl/motivoReembolsoAbm.ascx" tagname="motivoReembolsoAbm" tagprefix="uc2" %>


<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reMotivo", "view"))
            {
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reMotivo", "insert");
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        panel_abm.DefaultButton = "btn_insertar";
        lbl_abm.Text = "Nuevo motivo";
        motivoReembolsoAbm1.CargarInsertar();
        btn_insertar.Visible = true;
        btn_actualizar.Visible = false;
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (motivoReembolsoAbm1.Insertar()) { gv1.DataBind(); }
        panel_abm.DefaultButton = "btn_insertar";
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (motivoReembolsoAbm1.Actualizar()) { gv1.DataBind(); }
        panel_abm.DefaultButton = "btn_actualizar";
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void gv1_DataBound(object sender, EventArgs e)
    {
        gv1.Columns[0].Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reMotivo", "update");
        gv1.Columns[1].Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reMotivo", "delete");
    }

    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //general.OnMouseOver(sender, e);
            int num_traspasos = int.Parse(DataBinder.Eval(e.Row.DataItem, "num_traspasos").ToString());
            int num_devoluciones = int.Parse(DataBinder.Eval(e.Row.DataItem, "num_devoluciones").ToString());
            if (num_traspasos > 0 || num_devoluciones > 0)
            { e.Row.Cells[1].Controls[0].Visible = false; }
            else { e.Row.Cells[1].Controls[0].Visible = true; }
        }
    }

    protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "editar":
                panel_abm.DefaultButton = "btn_actualizar";
                lbl_abm.Text = "Edición de datos de un motivo";
                motivoReembolsoAbm1.CargarActualizar(int.Parse(gv1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()));
                btn_insertar.Visible = false;
                btn_actualizar.Visible = true;
                MultiView1.ActiveViewIndex = 1;
                break;
            case "eliminar":
                terrasur.traspaso.motivo mObj = new terrasur.traspaso.motivo(int.Parse(e.CommandArgument.ToString()));
                if (mObj.Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
                {
                    gv1.DataBind();
                    Msg1.Text = "El motivo se eliminó correctamente";
                }
                else { Msg1.Text = "El motivo NO se eliminó correctamente"; }
                break;
        }

    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reMotivo" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Motivos de reembolso</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo motivo" OnClick="btn_nuevo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid"><%--WizardGridView AllowPaging="true" PageSize="20"--%>
                                    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" DataSourceID="ods_motivo_lista" DataKeyNames="id_motivo" OnDataBound="gv1_DataBound" OnRowDataBound="gv1_RowDataBound" OnRowCommand="gv1_RowCommand">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_motivo") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el motivo?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                            <asp:BoundField HeaderText="Activo" DataField="activo" />
                                            <asp:BoundField HeaderText="Nº traspasos" DataField="num_traspasos" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Nº devoluciones" DataField="num_devoluciones" ItemStyle-CssClass="gvCell1" />
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_motivo],[codigo],[nombre],[activo],[num_traspasos],[num_devoluciones]--%>
                                    <asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.traspaso.motivo" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc2:motivoReembolsoAbm ID="motivoReembolsoAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="motivo" OnClick="btn_insertar_Click" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="motivo" OnClick="btn_actualizar_Click" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

