<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de cartera vigente por rangos de retraso" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    private string codigo_rol { get { return lbl_codigo_rol.Text; } set { lbl_codigo_rol.Text = value; } }
    private int id_usuario { get { return int.Parse(lbl_id_usuario.Text); } set { lbl_id_usuario.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraRangos") == true)
            {
                if (Session["codigo_rol"] != null)
                {
                    codigo_rol = Session["codigo_rol"].ToString();
                    id_usuario = int.Parse(Session["id_usuario"].ToString());
                    Session.Remove("codigo_rol");
                    Session.Remove("id_usuario");
                    CargarDatosUsuario();
                }
                else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }

            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    public void CargarDatosUsuario()
    {
        cp_fecha.SelectedDate = DateTime.Now.Date.AddDays(-1);
        if (codigo_rol == "promotor")
        {
            promotor pro = new promotor(id_usuario);

            if (ddl_grupoventa.Items.Count==0 || ddl_grupoventa.Items.FindByValue(pro.id_grupoventa.ToString()) == null) { ddl_grupoventa.DataBind(); }
            if (ddl_grupoventa.Items.FindByValue(pro.id_grupoventa.ToString()) != null) { ddl_grupoventa.SelectedValue = pro.id_grupoventa.ToString(); }
            else { ddl_grupoventa.SelectedValue = "-1"; }
            ddl_promotor.DataBind();

            if (ddl_promotor.Items.FindByValue(pro.id_grupopromotor.ToString()) != null) { ddl_promotor.SelectedValue = pro.id_grupopromotor.ToString(); }
            else { ddl_promotor.SelectedValue = "-1"; }
            ddl_promotor.Enabled = false;

            rbl_grupo_original_actual.SelectedValue = "grupo_actual";
            rbl_grupo_original_actual.Enabled = false;
        }
        else if (codigo_rol == "director")
        {
            director dir = new director(id_usuario);
            if (ddl_grupoventa.Items.Count == 0 || ddl_grupoventa.Items.FindByValue(dir.id_grupoventa.ToString()) == null) { ddl_grupoventa.DataBind(); }
            if (ddl_grupoventa.Items.FindByValue(dir.id_grupoventa.ToString()) != null) { ddl_grupoventa.SelectedValue = dir.id_grupoventa.ToString(); }
            else { ddl_grupoventa.SelectedValue = "-1"; }
            ddl_promotor.DataBind();

            promotor pro = new promotor(id_usuario);
            if (ddl_promotor.Items.FindByValue(pro.id_grupopromotor.ToString()) != null) { ddl_promotor.SelectedValue = pro.id_grupopromotor.ToString(); }
            else { ddl_promotor.SelectedValue = "-1"; }
            ddl_promotor.Enabled = true;

            rbl_grupo_original_actual.SelectedValue = "grupo_actual";
            rbl_grupo_original_actual.Enabled = false;
        }
    }

    public void cargarReporte()
    {
        DateTime Fecha = cp_fecha.SelectedDate;
        int Id_grupoventa = int.Parse(ddl_grupoventa.SelectedValue);
        string Grupo_encabezado = ddl_grupoventa.SelectedItem.Text;
        int Id_grupopromotor = int.Parse(ddl_promotor.SelectedValue);
        string Id_negocio = general.StringNegocios(true, cbl_negocio.Items);
        string Id_negocio_encabezado = general.StringNegocios(false, cbl_negocio.Items);
        int Id_moneda = int.Parse(rbl_moneda.SelectedValue);
        bool Consolidado = rbl_consolidado.SelectedValue.Equals("True");
        string Codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        decimal porcentaje_costo_oportunidad = 8;
        string col_grupo = rbl_grupo_original_actual.SelectedValue;
        string col_grupo_encabezado = rbl_grupo_original_actual.SelectedItem.Text;

        DataTable tabla = reportesRetraso.CarteraVigente3(Fecha, Id_grupoventa, col_grupo, Id_grupopromotor, Id_negocio, Id_moneda, Consolidado);
        if (tabla.Rows.Count > 0)
        {
            lbl_mensaje.Text = "";

            panel6.Visible = true;
            rpt_detalleGruposPromotoresRangos reporte_promotores_detalle = new rpt_detalleGruposPromotoresRangos();
            reporte_promotores_detalle.DataSource = reportesRetraso.resumen_grupos_promotores_rangos(tabla, col_grupo, "grupo,promotor,rango,num_dias_retraso", cb_con_contratos_al_dia.Checked, cb_con_retraso_1_a_30.Checked, cb_con_contratos_especiales.Checked);
            reporte_promotores_detalle.CargarEncabezado(Profile.nombre_persona, Fecha, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, cb_con_contratos_al_dia.Checked, cb_con_retraso_1_a_30.Checked, cb_con_contratos_especiales.Checked, col_grupo_encabezado);
            reporte6.WebView.Report = reporte_promotores_detalle;

            if (codigo_rol == "director")
            {
                panel4.Visible = true;
                rpt_resumenPromotores reporte_promotores_resumen = new rpt_resumenPromotores();
                reporte_promotores_resumen.DataSource = reportesRetraso.resumen_grupos_promotores(ref tabla, porcentaje_costo_oportunidad, col_grupo, "grupo,calidad");
                reporte_promotores_resumen.CargarEncabezado(Profile.nombre_persona, Fecha, Grupo_encabezado, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, col_grupo_encabezado);
                reporte4.WebView.Report = reporte_promotores_resumen;

                panel5.Visible = true;
                rpt_resumenGruposPromotoresRangos reporte_promotores_rangos_resumen = new rpt_resumenGruposPromotoresRangos();
                reporte_promotores_rangos_resumen.DataSource = reportesRetraso.resumen_grupos_promotores_rangos(tabla, col_grupo, "grupo,promotor,rango,num_dias_retraso", cb_con_contratos_al_dia.Checked, cb_con_retraso_1_a_30.Checked, cb_con_contratos_especiales.Checked);
                reporte_promotores_rangos_resumen.CargarEncabezado(Profile.nombre_persona, Fecha, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, cb_con_contratos_al_dia.Checked, cb_con_retraso_1_a_30.Checked, cb_con_contratos_especiales.Checked, col_grupo_encabezado);
                reporte5.WebView.Report = reporte_promotores_rangos_resumen;
            }
            else
            {
                panel4.Visible = false;
                panel5.Visible = false;
            }
        }
        else
        {
            lbl_mensaje.Text = "No se encontraron contratos según los parámetros elegidos";
        }
    }

    protected void btn_mostrar_Click(object sender, EventArgs e) { cargarReporte(); }
    protected void cbl_negocio_DataBound(object sender, EventArgs e) { string casas_edif = ConfigurationManager.AppSettings["negocios_casas"]; foreach (ListItem item in cbl_negocio.Items) { item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(false); } }
    protected void rbl_moneda_DataBound(object sender, EventArgs e) { if (rbl_moneda.Items.Count > 0) { rbl_moneda.SelectedIndex = 0; } }
    protected void rbl_consolidado_DataBound(object sender, EventArgs e) { if (rbl_consolidado.Items.Count > 1) { rbl_consolidado.SelectedIndex = 1; } lbl_consolidado_enun.Text = "Datos contemplados:"; }
    protected void ddl_grupoventa_DataBound(object sender, EventArgs e)
    {
        ddl_grupoventa.Items.Insert(0, new ListItem("Todos", "0"));
        ddl_grupoventa.Items.Add(new ListItem("Ninguno", "-1"));
    }
    protected void ddl_promotor_DataBound(object sender, EventArgs e)
    {
        ddl_promotor.Items.Insert(0, new ListItem("Todos", "0"));
        ddl_promotor.Items.Add(new ListItem("Ninguno", "-1"));
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_codigo_rol" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de cartera vigente por rangos de retraso</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td align="right">
                        <asp:Button ID="btn_volver" runat="server" SkinID="btnVolver" Text="Volver" onclick="btn_volver_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">A la fecha:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server" Enabled="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Grupo de venta:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_grupoventa" runat="server" Enabled="false" AutoPostBack="true" DataSourceID="ods_lista_grupoventa" DataValueField="id_grupoventa" DataTextField="nombre" OnDataBound="ddl_grupoventa_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_grupoventa],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_grupoventa" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="ListaActivoOConVentas">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Promotor:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_promotor" runat="server" DataSourceID="ods_lista_promotor" DataValueField="id_grupopromotor" DataTextField="nombre_completo" OnDataBound="ddl_promotor_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_grupopromotor],[id_usuario],[nombre_completo],[ci]--%>
                                    <asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaActivoPorGrupo">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="ddl_grupoventa" PropertyName="SelectedValue" />
                                            <asp:Parameter Name="Id_grupopromotor" Type="Int32" DefaultValue="0" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    
                                    <%--[id_grupopromotor],[nombre]--%>
                                    <%--<asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaActivoOConVentas">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="ddl_grupoventa" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Contratos asocidos al:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_grupo_original_actual" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Text="Grupo original de la venta" Value="grupo" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Grupo actual del promotor" Value="grupo_actual"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" Enabled="false" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2" OnDataBound="cbl_negocio_DataBound"></asp:CheckBoxList>
                                    <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" Enabled="false" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_moneda_DataBound">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_consolidado" runat="server" Enabled="false" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_consolidado_DataBound">
                                    </asp:RadioButtonList>
                                    <%--[valor],[texto]--%>
                                    <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Cartera Vigente por PROMOTOR:</td>
                                <td class="formTdDato">
                                    <asp:CheckBox ID="cb_con_contratos_al_dia" runat="server" Enabled="false" Text="Con contratos al día" Checked="false" />
                                    <asp:CheckBox ID="cb_con_retraso_1_a_30" runat="server" Enabled="false" Text="Con contratos de 1 a 30 días" Checked="true" />
                                    <asp:CheckBox ID="cb_con_contratos_especiales" runat="server" Enabled="false" Text="Con contratos especiales" Checked="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                    <asp:ButtonAction ID="btn_mostrar" runat="server" Text="Mostrar reporte" TextoEnviando="Obteniendo información..." CausesValidation="true" ValidationGroup="filtro" OnClick="btn_mostrar_Click" />
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lbl_mensaje" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <table width="80%" align="center">
                            <tr>
                                <td>
                                    <table>
                                        <tr><td><asp:Panel ID="panel6" runat="server" Visible="false" GroupingText="Cartera Vigente por PROMOTORES (detalle)"><uc1:reporte ID="reporte6" runat="server" NombreReporte="CarteraVigentePromotoresDetalle" /></asp:Panel></td></tr>
                                        <tr><td><asp:Panel ID="panel4" runat="server" Visible="false" GroupingText="Cartera Vigente por PROMOTORES (resumen)"><uc1:reporte ID="reporte4" runat="server" NombreReporte="CarteraVigentePromotoresResumen" /></asp:Panel></td></tr>
                                        <tr><td><asp:Panel ID="panel5" runat="server" Visible="false" GroupingText="Cartera Vigente por PROMOTORES y RANGOS (resumen)"><uc1:reporte ID="reporte5" runat="server" NombreReporte="CarteraVigentePromotoresRangosResumen" /></asp:Panel></td></tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
