<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Contratos TerraPlus" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpFiltroContrato.ascx" tagname="tpFiltroContrato" tagprefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>


<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "view"))
            { tpFiltroContrato1.Reset(); /*btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "insert");*/ }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void ods_contrato_lista_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["Nombre_ci_cliente"] = tpFiltroContrato1.nombre;

        e.InputParameters["Lote_num_contrato"] = tpFiltroContrato1.lot_num_contrato;
        e.InputParameters["Lote_fecha_inicio"] = tpFiltroContrato1.lot_fecha_inicio;
        e.InputParameters["Lote_fecha_fin"] = tpFiltroContrato1.lot_fecha_fin;

        e.InputParameters["Terraplus_num_contrato"] = tpFiltroContrato1.tp_num_contrato;
        e.InputParameters["Terraplus_fecha_inicio"] = tpFiltroContrato1.tp_fecha_inicio;
        e.InputParameters["Terraplus_fecha_fin"] = tpFiltroContrato1.tp_fecha_fin;

        if (tpFiltroContrato1.TieneDatos) { e.InputParameters["Id_estado"] = tpFiltroContrato1.tp_id_estado; }
        else { e.InputParameters["Id_estado"] = -1; }
    }

    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        if (tpFiltroContrato1.TieneDatos) { gv_contrato.DataBind(); }
        else { Msg1.Text = "Debe introducir algún dato en el filtro"; }
    }


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="tpContrato" MostrarLink="true" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">

    <table class="priTable">
        <tr><td class="priTdTitle">Listado de Contratos TerraPlus</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_filtro" runat="server" GroupingText="Filtro de búsqueda" DefaultButton="btn_obtener">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr><td><uc1:tpFiltroContrato ID="tpFiltroContrato1" runat="server" /></td></tr>
                                                <tr><td><asp:Button ID="btn_obtener" runat="server" Text="Buscar" OnClick="btn_obtener_Click" /></td></tr>
                                            </table>
                                        </asp:Panel> 
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="tdButton">
                            <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo contrato TerraPlus" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="tdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid">
                            <%--<asp:WizardGridView AllowPaging="true" PageSize="20"--%>
                            <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="false" DataSourceID="ods_contrato_lista" DataKeyNames="id_cliente">
                                <Columns>
                                    <%--<asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                    <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                    <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_localizacion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la localización?');" /></ItemTemplate></asp:TemplateField>
                                    <asp:ButtonField CommandName="urbanizacion" Text="Sector" ControlStyle-CssClass="gvButton" />--%>
                                    <asp:BoundField HeaderText="Cliente" DataField="nombre_cliente" />
                                    <asp:BoundField HeaderText="C.I." DataField="ci_cliente" ItemStyle-CssClass="gvCell1" />

                                    <asp:TemplateField HeaderText="Ctto.Lote" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_lot_numero" runat="server" Text='<%# Eval("lot_numero") %>' ToolTip='<%# Eval("lot_descrip") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField HeaderText="" DataField="lot_tipo_cliente"/> 
                                            
                                    <asp:BoundField HeaderText="Ctto.TerraPlus" DataField="tp_numero" ItemStyle-CssClass="gvCell1"/> 
                                    <asp:BoundField HeaderText="" DataField="tp_estado"/> 
                                </Columns>
                            </asp:GridView>
                            <%--[id_cliente],[nombre_cliente],[ci_cliente]
                                [lot_numero],[lot_descrip],[lot_tipo_cliente]
                                [tp_id_contrato],[tp_numero],[tp_estado],[tp_monto]--%>
                            <asp:ObjectDataSource ID="ods_contrato_lista" runat="server" TypeName="terrasur.terraplus.tp_contrato" SelectMethod="ListaContratosLotes" OnSelecting="ods_contrato_lista_Selecting">
                                <SelectParameters>
                                    <asp:Parameter Name="Nombre_ci_cliente" Type="String" DefaultValue="" />

                                    <asp:Parameter Name="Lote_num_contrato" Type="String" DefaultValue="" />
                                    <asp:Parameter Name="Lote_fecha_inicio" Type="DateTime" DefaultValue="01/01/1900" />
                                    <asp:Parameter Name="Lote_fecha_fin" Type="DateTime" DefaultValue="01/01/2900" />

                                    <asp:Parameter Name="Terraplus_num_contrato" Type="String" DefaultValue="" />
                                    <asp:Parameter Name="Terraplus_fecha_inicio" Type="DateTime" DefaultValue="01/01/1900" />
                                    <asp:Parameter Name="Terraplus_fecha_fin" Type="DateTime" DefaultValue="01/01/2900" />

                                    <asp:Parameter Name="Id_estado" Type="Int32" DefaultValue="0" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

