<%@ Control Language="C#" ClassName="obraDetalleAbm" %>
<%@ Import Namespace="terrasur.so" %>
<%@ Register src="~/recurso/inventario/seguimientoObras/userControl/urbDatosView.ascx" tagname="urbDatosView" tagprefix="uc1" %>

<%@ Register src="obraDetalleForm.ascx" tagname="obraDetalleForm" tagprefix="uc2" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        this.obraDetalleForm1.Eleccion += new EventHandler(ActualizarListado);
    }
    
    private int _id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }

    public void Cargar(int Id_urbanizacion)
    {
        _id_urbanizacion = Id_urbanizacion;
        urbDatosView1.id_urbanizacion = _id_urbanizacion;
        gv_obra.DataBind();
        btn_obra_nueva.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_agregar");
        panel_obra_nueva.Visible = false;
        panel_obraDetalle.Visible = false;
    }


    protected void ddl_obra_DataBound(object sender, EventArgs e)
    { btn_obra_insert.Enabled = ddl_obra.Items.Count.Equals(0).Equals(false); }
    protected void btn_obra_nueva_Click(object sender, EventArgs e)
    {
        btn_obra_nueva.Visible = false;
        panel_obra_nueva.Visible = true;
        ddl_obra.DataBind();
    }
    protected void btn_obra_insert_Click(object sender, EventArgs e)
    {
        if (terrasur.so.so_obraDetalle.Verificar(_id_urbanizacion, int.Parse(ddl_obra.SelectedValue)) == false)
        {
            panel_obraDetalle.Visible = true;
            panel_obraDetalle.GroupingText = ddl_obra.SelectedItem.Text;
            obraDetalleForm1.CargarNuevo(_id_urbanizacion, int.Parse(ddl_obra.SelectedValue));
            btn_obraDetalle_insert.Visible = true;
        }
        else { panel_obraDetalle.Visible = false; }
    }
    protected void btn_obra_cancel_Click(object sender, EventArgs e)
    {
        btn_obra_nueva.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_agregar");
        panel_obra_nueva.Visible = false;

        panel_obraDetalle.Visible = false;
    }
    protected void btn_obraDetalle_insert_Click(object sender, EventArgs e)
    {
        if (obraDetalleForm1.RegistrarNuevo() == true)
        {
            urbDatosView1.id_urbanizacion = _id_urbanizacion;
            gv_obra.DataBind();
            ddl_obra.DataBind();
            panel_obraDetalle.Visible = false;
        }
    }

    protected void btn_obraDetalle_cancel_Click(object sender, EventArgs e)
    {
        urbDatosView1.id_urbanizacion = _id_urbanizacion;
        gv_obra.DataBind();
        ddl_obra.DataBind();
        panel_obraDetalle.Visible = false;
    }


    protected string StringFechaUsuario(object Fecha, string Usuario) { return String.Format("({0:d} - {1})", (DateTime)Fecha, Usuario); }
    protected string StringFechaCorta(object Fecha)
    {
        if (((DateTime)Fecha).Date.Equals(DateTime.Parse("01/01/1900"))) { return ""; }
        else { return ((DateTime)Fecha).ToString("d"); }
    }
    protected string StringDiasPlanificados(object Fecha, object Num_dias)
    {
        if (((DateTime)Fecha).Date.Equals(DateTime.Parse("01/01/1900"))) { return ""; }
        else
        {
            int _num = (int)Num_dias;
            if (_num == 9999) { return ""; }
            else if (_num == 0) { return "Plazo cumplido"; }
            else if (_num < 0)
            {
                if (_num == -1) { return "Fecha planificada excedida (en " + (_num * (-1)).ToString() + " día)"; }
                else { return "Fecha planificada excedida (en " + (_num * (-1)).ToString() + " días)"; }
            }
            else if (_num > 0)
            {
                if (_num == 1) { return _num.ToString() + " día para la fecha planificada"; }
                else { return _num.ToString() + " días para la fecha planificada"; }
            }
            else { return ""; }
            
        }
    }
    protected string StringObsCorta(string Obs)
    {
        Obs = Obs.Trim();
        if (Obs == "") { return ""; }
        else if (Obs.Length <= 15) { return Obs; }
        else { return Obs.Substring(0, 15) + "..."; }
    }

    protected string StringAvance(object _avance_)
    {
        return ((decimal)_avance_).ToString("N2") + " %";
    }


    protected void gv_obra_DataBound(object sender, EventArgs e)
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_avance") == true
            || permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_obs") == true
            || permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_fechaPlanificacion") == true)
        { gv_obra.Columns[0].Visible = true;}
        else { gv_obra.Columns[0].Visible = false; }
    }
    protected void gv_obra_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editar")
        {
            int _id_tipoobra = int.Parse(gv_obra.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

            btn_obra_nueva.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_agregar");
            panel_obra_nueva.Visible = false;
            
            panel_obraDetalle.Visible = true;
            panel_obraDetalle.GroupingText = (new terrasur.so.so_tipoObra(_id_tipoobra)).nombre;
            obraDetalleForm1.CargarAntiguo(_id_urbanizacion, _id_tipoobra);
            btn_obraDetalle_insert.Visible = false;
        }
    }

    protected void ActualizarListado(object sender, System.EventArgs e)
    {
        urbDatosView1.id_urbanizacion = _id_urbanizacion;
        gv_obra.DataBind();
    }



</script>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr><td class="priTdTitle">Obras en la urbanización</td></tr>
    <%--<tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="(Obras)" SkinID="lblEnun"></asp:Label>
        </td>
    </tr>--%>
    <tr><td><uc1:urbDatosView ID="urbDatosView1" runat="server" /></td></tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" align="center"><tr><td>
            <asp:GridView ID="gv_obra" runat="server" AutoGenerateColumns="false" DataSourceID="ods_listaDetalle" DataKeyNames="id_tipoobra" OnRowCommand="gv_obra_RowCommand" OnDataBound="gv_obra_DataBound">
                <Columns>
                    <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                    <asp:TemplateField HeaderText="Tipo de obra"><ItemTemplate><asp:Label ID="lbl_tipoObra" runat="server" Text='<%# Eval("tipoObra_nombre") %>' ToolTip='<%# StringFechaUsuario(Eval("tipoObra_fecha"),Eval("tipoObra_usuario").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="F.Planificada"><ItemTemplate><asp:Label ID="lbl_fechaPlanif" runat="server" Text='<%# StringFechaCorta(Eval("tipoObra_fechaPlanif")) %>' ToolTip='<%# StringDiasPlanificados(Eval("tipoObra_fechaPlanif"),Eval("tipoObra_diasPlanif")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:BoundField HeaderText="Estado" DataField="estado_nombre" />
                    <%--<asp:BoundField HeaderText="Avance" DataField="estado_avance" DataFormatString="{0:N2 %}" />--%>
                    <asp:TemplateField HeaderText="Avance" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_avance" runat="server" Text='<%# StringAvance(Eval("estado_avance")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Observación"><ItemTemplate><asp:Label ID="lbl_observacion" runat="server" Text='<%# StringObsCorta(Eval("estado_observacion").ToString()) %>' ToolTip='<%# Eval("estado_observacion") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
            </td></tr></table>
            <%--[id_tipoobra],[tipoObra_nombre],[tipoObra_fecha],[tipoObra_usuario]
            [tipoObra_fechaPlanif],[tipoObra_diasPlanif]
            [estado_nombre],[estado_avance],[estado_observacion]--%>
             <asp:ObjectDataSource ID="ods_listaDetalle" runat="server" TypeName="terrasur.so.so_obraDetalle" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                </SelectParameters>
             </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btn_obra_nueva" runat="server" Text="Agregar obra" OnClick="btn_obra_nueva_Click" />
            <asp:Panel ID="panel_obra_nueva" runat="server" Visible="false" GroupingText="Agregar obra">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:Label ID="lbl_obra_enun" runat="server" Text="Obra:"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_obra" runat="server" DataSourceID="ods_lista_obra" DataTextField="nombre" DataValueField="id_tipoobra" OnDataBound="ddl_obra_DataBound">
                            </asp:DropDownList>
                            <%--[id_tipoobra],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_lista_obra" runat="server" TypeName="terrasur.so.so_obraDetalle" SelectMethod="ListaTiposPendiente">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td><asp:Button ID="btn_obra_insert" runat="server" Text="Agregar" OnClick="btn_obra_insert_Click" /></td>
                        <td><asp:Button ID="btn_obra_cancel" runat="server" Text="Cancelar" OnClick="btn_obra_cancel_Click" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_obraDetalle" runat="server" Visible="false">
                <table align="center">
                    <tr>
                        <td>
                            <uc2:obraDetalleForm ID="obraDetalleForm1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btn_obraDetalle_insert" runat="server" Text="Registrar" OnClick="btn_obraDetalle_insert_Click" />
                            <asp:Button ID="btn_obraDetalle_cancel" runat="server" Text="Cancelar/Volver" OnClick="btn_obraDetalle_cancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>