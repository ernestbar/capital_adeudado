<%@ Page Language="C#" MasterPageFile="~/modulo/simple.master" Title="Obras de la urbanización" %>
<%@ Register Src="~/recurso/inventario/lote/userControl/loteViewDato.ascx" TagName="loteViewDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    public int id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["id_urbanizacion"] != null)
            {
                id_urbanizacion = int.Parse(Session["id_urbanizacion"].ToString());
                Session.Remove("id_urbanizacion");
                CargarDatos();
            }
            else { Page.Visible = false; }
        }
    }

    protected void CargarDatos()
    {
        urbanizacion uObj = new urbanizacion(id_urbanizacion);
        Page.Title = "Obras de la urbanización: " + uObj.nombre;
        lbl_urbanizacion.Text = uObj.nombre;
        lbl_localizacion.Text = (new localizacion(uObj.id_localizacion)).nombre;
        lbl_num_lotes.Text = uObj.num_lote.ToString();



        terrasur.so.so_obraMaestro omObj = new terrasur.so.so_obraMaestro(id_urbanizacion);
        if (omObj.estado_nombre != "") { lbl_estado.Text = omObj.estado_nombre; } else { lbl_estado.Text = "---"; }
        lbl_avance.Text = omObj.avance.ToString("N2") + @" %";
        terrasur.so.so_urbanizacion_prioridad up = new terrasur.so.so_urbanizacion_prioridad(0, omObj.id_urbanizacion);
        if (up.prioridad_nombre != "") { lbl_prioridad.Text = up.prioridad_nombre; } else { lbl_prioridad.Text = "---"; }
        if (up.fecha_planificada.Date != DateTime.Parse("01/01/1900")) { lbl_fecha_planificada.Text = up.fecha_planificada.ToString("d"); } else { lbl_fecha_planificada.Text = "---"; }
        if (up.id_prioridad > 0) { lbl_prioridadObservacion_fechaUsuario.Text = up.fecha.ToString("d") + " - " + up.usuario_nombre; } else { lbl_prioridadObservacion_fechaUsuario.Text = ""; }
        if (up.id_prioridad > 0) { if (up.observacion.Trim() != "") { lbl_prioridad_observacion.Text = up.observacion.Trim(); } else { lbl_prioridad_observacion.Text = "(Sin observación)"; } } else { lbl_prioridad_observacion.Text = "---"; }
    }

    
    
    protected string EncabezadoObservacion(object Fecha, string Estado, string Usuario)
    { return ((DateTime)Fecha).ToString("d") + " - Estado: " + Estado + " (" + Usuario + ")"; }
    protected string StringFechaUsuario(object Fecha, string Usuario) { return String.Format("({0:d} - {1})", (DateTime)Fecha, Usuario); }
    protected string StringFechaCorta(object Fecha)
    {
        if (((DateTime)Fecha).Date.Equals(DateTime.Parse("01/01/1900"))) { return "---"; }
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
    { return ((decimal)_avance_).ToString("N2") + " %"; }

    protected void r_obra_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int id_tipoobra = int.Parse(DataBinder.Eval(e.Item.DataItem, "id_tipoobra").ToString());
            System.Data.DataTable tabla_obs = terrasur.so.so_observacion.ListaPorObra(id_urbanizacion, id_tipoobra);
            ((Label)e.Item.FindControl("lbl_obra_obs_enun")).Visible = tabla_obs.Rows.Count.Equals(0).Equals(false);
            ((Repeater)e.Item.FindControl("r_obra_obs")).Visible = tabla_obs.Rows.Count.Equals(0).Equals(false);
            if (tabla_obs.Rows.Count > 0)
            {
                ((Repeater)e.Item.FindControl("r_obra_obs")).DataSource = tabla_obs;
                ((Repeater)e.Item.FindControl("r_obra_obs")).DataBind();
            }
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="seguimientoObras" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
    <%--<asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>--%>
    <table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Obras de la urbanización"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="Datos de la urbanización">
                                <table class="viewTable" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Urbanización:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Localización:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Nº lotes:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_num_lotes" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_obraMaestro" runat="server" GroupingText="Prioridad y estado de las obras">
                                <table class="viewTable" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Prioridad:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_prioridad" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Entrega planificada:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_fecha_planificada" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Observación:</td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0" align="left">
                                                <tr><td><asp:Label ID="lbl_prioridadObservacion_fechaUsuario" runat="server"></asp:Label></td></tr>
                                                <tr><td><asp:Panel ID="panel_prioridadObservacion" runat="server" Width="300"><asp:Label ID="lbl_prioridad_observacion" runat="server"></asp:Label></asp:Panel></td></tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Estado:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Avance:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_avance" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_obraDetalle" runat="server" GroupingText="Observaciones">
                                <asp:Repeater ID="r_observaciones" runat="server" DataSourceID="ods_lista_observaciones">
                                    <HeaderTemplate><table cellpadding="0" cellspacing="0" width="450"></HeaderTemplate>
                                    <ItemTemplate>
                                        <tr><td align="left"><asp:Label ID="lbl_encabezado" runat="server" Text='<%# EncabezadoObservacion(Eval("fecha"),Eval("estado").ToString(),Eval("usuario").ToString()) %>'></asp:Label></td></tr>
                                        <tr><td align="left"><asp:Label ID="lbl_observacion" runat="server" Text='<%# Eval("texto") %>'></asp:Label></td></tr>
                                    </ItemTemplate>
                                    <SeparatorTemplate><tr><td><hr /></td></tr></SeparatorTemplate>
                                    <FooterTemplate></table></FooterTemplate>
                                </asp:Repeater>
                                <%--[id_observacion],[usuario],[estado],[fecha],[texto]--%>
                                <asp:ObjectDataSource ID="ods_lista_observaciones" runat="server" TypeName="terrasur.so.so_observacion" SelectMethod="ListaPorUrbanizacion">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_obras" runat="server" GroupingText="Obras">
                                <asp:Repeater ID="r_obra" runat="server" DataSourceID="ods_listaDetalle" OnItemDataBound="r_obra_ItemDataBound">
                                    <HeaderTemplate><table width="100%"></HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_obra_enun" runat="server" SkinID="lblEnun" Text="Obra: "></asp:Label>
                                                <asp:Label ID="lbl_obra_nombre" runat="server" SkinID="lblEnun" Text='<%# String.Format("{0} {1}",Eval("tipoObra_nombre"),StringFechaUsuario(Eval("tipoObra_fecha"),Eval("tipoObra_usuario").ToString())) %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_estado_enun" runat="server" SkinID="lblEnun" Text="Estado actual: "></asp:Label>
                                                <asp:Label ID="lbl_estado_nombre" runat="server" SkinID="lblDato" Text='<%# String.Format("{0} ({1})",Eval("estado_nombre"),StringAvance(Eval("estado_avance"))) %>'></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="lbl_planif_enun" runat="server" SkinID="lblEnun" Text="Fecha de entrega:"></asp:Label>
                                                <asp:Label ID="lbl_planif_nombre" runat="server" SkinID="lblDato" Text='<%# StringFechaCorta(Eval("tipoObra_fechaPlanif")) %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table cellpadding="0" cellspacing="0" align="left">
                                                    <tr>
                                                        <td valign="top"><asp:Label ID="lbl_obra_obs_enun" runat="server" SkinID="lblEnun" Font-Italic="true" Text="Observación(es):&nbsp;&nbsp;"></asp:Label></td>
                                                        <td>
                                                            <asp:Repeater ID="r_obra_obs" runat="server">
                                                                <HeaderTemplate><table cellpadding="0" cellspacing="0" align="left"></HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr><td><asp:Label ID="lbl_obs_titulo" runat="server" Text='<%# String.Format("({0} - {1:d} - {2})",Eval("usuario"),Eval("fecha"),Eval("estado")) %>'></asp:Label></td></tr>
                                                                    <tr><td><asp:Panel ID="panel_obs_texto" runat="server" Width="400"><asp:Label ID="lbl_obs_texto" runat="server" Text='<%# Eval("texto") %>'></asp:Label></asp:Panel></td></tr>
                                                                </ItemTemplate>
                                                                <SeparatorTemplate><tr><td><hr /></td></tr></SeparatorTemplate>
                                                                <FooterTemplate></table></FooterTemplate>
                                                            </asp:Repeater>
                                                            <%--[id_observacion],[usuario],[estado],[fecha],[texto]--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <SeparatorTemplate><tr><td><hr /></td></tr></SeparatorTemplate>
                                    <FooterTemplate></table></FooterTemplate>
                                </asp:Repeater>
                                <%--
                                [id_tipoobra],[tipoObra_nombre],[tipoObra_fecha],[tipoObra_usuario]
                                [tipoObra_fechaPlanif],[tipoObra_diasPlanif]
                                [estado_nombre],[estado_avance],[estado_observacion]
                                --%>
                                 <asp:ObjectDataSource ID="ods_listaDetalle" runat="server" TypeName="terrasur.so.so_obraDetalle" SelectMethod="Lista">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                                    </SelectParameters>
                                 </asp:ObjectDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <asp:Panel ID="panel2" runat="server" GroupingText="">
                                <table class="viewTable" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel3" runat="server" GroupingText="">
                                <table class="viewTable" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

