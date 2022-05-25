<%@ Control Language="C#" ClassName="sEeffAbm" %>

<script runat="server">
    private bool permiso_eeff_update { get { return bool.Parse(lbl_permiso_eeff_update.Text); } set { lbl_permiso_eeff_update.Text = value.ToString(); } }
    private bool permiso_sucursal_view { get { return bool.Parse(lbl_permiso_sucursal_view.Text); } set { lbl_permiso_sucursal_view.Text = value.ToString(); } }
    private bool permiso_sucursal_update { get { return bool.Parse(lbl_permiso_sucursal_update.Text); } set { lbl_permiso_sucursal_update.Text = value.ToString(); } }
    
    public void Cargar()
    {
        bool permiso_eeff_view = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_eeff", "view");
        permiso_sucursal_view = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_sucursal", "view");
        permiso_eeff_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_eeff", "update");
        permiso_sucursal_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_sucursal", "update");

        if (permiso_eeff_view == true || permiso_sucursal_view == true)
        {
            //Para la EEFF:
            gv_eeff.DataBind();
            lbl_id_eeff.Text = "0";
            //Para la Sucursal:
            if (permiso_sucursal_view == true)
            {
                panel_sucursal.Visible = true;
                gv_sucursal.DataBind();
            }
            else { panel_sucursal.Visible = true; }
        }
        else { panel_eeff_sucursal.Visible = false; }
    }


    protected void gv_eeff_DataBound(object sender, EventArgs e)
    {
        gv_eeff.Columns[0].Visible = permiso_eeff_update;

        for (int j = 0; j < gv_eeff.Rows.Count; j++)
        {
            if (gv_eeff.Rows[j].RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)gv_eeff.Rows[j].FindControl("lb_eeff_actualizar")).CommandArgument = j.ToString();
                ((LinkButton)gv_eeff.Rows[j].FindControl("lb_eeff_cancelar")).CommandArgument = j.ToString();
            }
        }
    }
    protected void gv_eeff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (int.Parse(DataBinder.Eval(e.Row.DataItem, "num_sucursales").ToString()) > 0 && permiso_sucursal_view == true)
            {
                e.Row.Cells[1].Enabled = true;
            }
            else { e.Row.Cells[1].Enabled = false; }
        }
    }
    protected void gv_eeff_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        int id_eeff = int.Parse(gv_eeff.DataKeys[index].Value.ToString());

        LinkButton lb_eeff_actualizar = ((LinkButton)gv_eeff.Rows[index].FindControl("lb_eeff_actualizar"));
        LinkButton lb_eeff_cancelar = ((LinkButton)gv_eeff.Rows[index].FindControl("lb_eeff_cancelar"));
        Label lbl_eeff_nombre = ((Label)gv_eeff.Rows[index].FindControl("lbl_eeff_nombre"));
        TextBox txt_eeff_nombre = ((TextBox)gv_eeff.Rows[index].FindControl("txt_eeff_nombre"));

        switch (e.CommandName)
        {
            case "editar":
                
                gv_eeff.Rows[index].Cells[0].Controls[0].Visible = false;
                lb_eeff_actualizar.Visible = true;
                lb_eeff_cancelar.Visible = true;

                lbl_eeff_nombre.Visible = false;
                txt_eeff_nombre.Visible = true;
                txt_eeff_nombre.Text = lbl_eeff_nombre.Text;
                txt_eeff_nombre.Focus();
                break;
            case "sucursal":
                lbl_id_eeff.Text = id_eeff.ToString();
                gv_sucursal.DataBind();
                break;
            case "actualizar":
                string nombre = txt_eeff_nombre.Text;
                if ((new terrasur.sintesis.s_eeff(id_eeff, nombre)).Actualizar(Profile.id_usuario) == true)
                {
                    Msg1.Text = "El nombre de la entidad se actualizó correctamente";
                    lbl_eeff_nombre.Text = nombre;

                    gv_eeff.Rows[index].Cells[0].Controls[0].Visible = true;
                    lb_eeff_actualizar.Visible = false;
                    lb_eeff_cancelar.Visible = false;

                    lbl_eeff_nombre.Visible = true;
                    txt_eeff_nombre.Visible = false;
                }
                else { Msg1.Text = "El nombre de la entidad NO se actualizó correctamente"; }
                
                break;
            case "cancelar":
                gv_eeff.Rows[index].Cells[0].Controls[0].Visible = true;
                lb_eeff_actualizar.Visible = false;
                lb_eeff_cancelar.Visible = false;

                lbl_eeff_nombre.Visible = true;
                txt_eeff_nombre.Visible = false;
                break;
        }
    }


    protected void gv_sucursal_DataBound(object sender, EventArgs e)
    {
        if (int.Parse(lbl_id_eeff.Text) > 0)
        {
            terrasur.sintesis.s_eeff eObj = new terrasur.sintesis.s_eeff(int.Parse(lbl_id_eeff.Text));
            lbl_sucursal_enun.Text = "Sucursales de: " + eObj.nombre + " (" + eObj.codigo + ")";
        }
        else { lbl_sucursal_enun.Text = ""; }

        gv_sucursal.Columns[0].Visible = permiso_sucursal_update;

        for (int j = 0; j < gv_sucursal.Rows.Count; j++)
        {
            if (gv_sucursal.Rows[j].RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)gv_sucursal.Rows[j].FindControl("lb_sucursal_actualizar")).CommandArgument = j.ToString();
                ((LinkButton)gv_sucursal.Rows[j].FindControl("lb_sucursal_cancelar")).CommandArgument = j.ToString();
            }
        }
    }


    protected void gv_sucursal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        int id_sucursal_eeff = int.Parse(gv_sucursal.DataKeys[index].Value.ToString());

        LinkButton lb_sucursal_actualizar = ((LinkButton)gv_sucursal.Rows[index].FindControl("lb_sucursal_actualizar"));
        LinkButton lb_sucursal_cancelar = ((LinkButton)gv_sucursal.Rows[index].FindControl("lb_sucursal_cancelar"));
        Label lbl_sucursal_nombre = ((Label)gv_sucursal.Rows[index].FindControl("lbl_sucursal_nombre"));
        TextBox txt_sucursal_nombre = ((TextBox)gv_sucursal.Rows[index].FindControl("txt_sucursal_nombre"));

        switch (e.CommandName)
        {
            case "editar":
                gv_sucursal.Rows[index].Cells[0].Controls[0].Visible = false;
                lb_sucursal_actualizar.Visible = true;
                lb_sucursal_cancelar.Visible = true;

                lbl_sucursal_nombre.Visible = false;
                txt_sucursal_nombre.Visible = true;
                txt_sucursal_nombre.Text = lbl_sucursal_nombre.Text;
                txt_sucursal_nombre.Focus();
                break;
            case "actualizar":
                string nombre = txt_sucursal_nombre.Text;
                if ((new terrasur.sintesis.s_sucursal_eeff(id_sucursal_eeff, nombre)).Actualizar(Profile.id_usuario) == true)
                {
                    Msg1.Text = "El nombre de la sucursal se actualizó correctamente";
                    lbl_sucursal_nombre.Text = nombre;

                    gv_sucursal.Rows[index].Cells[0].Controls[0].Visible = true;
                    lb_sucursal_actualizar.Visible = false;
                    lb_sucursal_cancelar.Visible = false;

                    lbl_sucursal_nombre.Visible = true;
                    txt_sucursal_nombre.Visible = false;
                }
                else { Msg1.Text = "El nombre de la sucursal NO se actualizó correctamente"; }

                break;
            case "cancelar":
                gv_sucursal.Rows[index].Cells[0].Controls[0].Visible = true;
                lb_sucursal_actualizar.Visible = false;
                lb_sucursal_cancelar.Visible = false;

                lbl_sucursal_nombre.Visible = true;
                txt_sucursal_nombre.Visible = false;
                break;
        }
    }
</script>
<asp:Label ID="lbl_permiso_eeff_update" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_sucursal_view" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_sucursal_update" runat="server" Text="false" Visible="false"></asp:Label>


<asp:Panel ID="panel_eeff_sucursal" runat="server" GroupingText="Entidades financieras y sucursales">
    <table align="center">
        <tr>
            <td>
                <asp:Panel ID="panel_eeff" runat="server">
                    <table>
                        <tr><td align="left"><asp:Label ID="lbl_eeff_enun" runat="server" Text="Entidades financieras:" SkinID="lblEnun"></asp:Label></td></tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gv_eeff" runat="server" DataSourceID="ods_lista_eeff" DataKeyNames="id_eeff" AutoGenerateColumns="false" OnRowDataBound="gv_eeff_RowDataBound" OnRowCommand="gv_eeff_RowCommand" OnDataBound="gv_eeff_DataBound">
                                    <Columns>
                                        <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                        <asp:ButtonField Text="Sucursales" CommandName="sucursal" ControlStyle-CssClass="gvButton" />
                                        <asp:BoundField HeaderText="Código" DataField="codigo" />
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_eeff_nombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                <asp:TextBox ID="txt_eeff_nombre" runat="server" Visible="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td><asp:LinkButton ID="lb_eeff_actualizar" runat="server" Visible="false" Text="Actualizar" CommandName="actualizar"></asp:LinkButton></td>
                                                        <td><asp:LinkButton ID="lb_eeff_cancelar" runat="server" Visible="false" Text="Cancelar" CommandName="cancelar"></asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Nº sucursales" DataField="num_sucursales" ItemStyle-CssClass="gvCell1"/>
                                    </Columns>
                                </asp:GridView>
                                <%--[id_eeff],[codigo],[nombre],[num_sucursales]--%>
                                <asp:ObjectDataSource ID="ods_lista_eeff" runat="server" TypeName="terrasur.sintesis.s_eeff" SelectMethod="Lista">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_id_eeff" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel_sucursal" runat="server" Width="100%">
                    <table align="left">
                        <tr><td align="left"><asp:Label ID="lbl_sucursal_enun" runat="server" Text="Sucursales:" SkinID="lblEnun"></asp:Label></td></tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gv_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataKeyNames="id_sucursal_eeff" AutoGenerateColumns="false" OnDataBound="gv_sucursal_DataBound" OnRowCommand="gv_sucursal_RowCommand">
                                    <Columns>
                                        <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                        <asp:BoundField HeaderText="Código" DataField="codigo" />
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sucursal_nombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                <asp:TextBox ID="txt_sucursal_nombre" runat="server" Visible="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td><asp:LinkButton ID="lb_sucursal_actualizar" runat="server" Visible="false" Text="Actualizar" CommandName="actualizar" CommandArgument='<%# Eval("id_sucursal_eeff") %>'></asp:LinkButton></td>
                                                        <td><asp:LinkButton ID="lb_sucursal_cancelar" runat="server" Visible="false" Text="Cancelar" CommandName="cancelar" CommandArgument='<%# Eval("id_sucursal_eeff") %>'></asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <%--[id_sucursal_eeff],[codigo],[nombre]--%>
                                <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sintesis.s_sucursal_eeff" SelectMethod="Lista">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Id_eeff" Type="Int32" ControlID="lbl_id_eeff" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>

