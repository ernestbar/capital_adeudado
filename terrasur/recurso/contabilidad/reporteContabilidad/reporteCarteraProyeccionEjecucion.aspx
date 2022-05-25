<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de proyección y ejecución de cobranza" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register src="~/recurso/contabilidad/reporteContabilidad/userControl/reporteCarteraVigente.ascx" tagname="reporteCarteraVigente" tagprefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraProyeccionEjecucion") == true)
            {
                rbl_periodo_cobros.SelectedValue = "todo";
                panel_periodo_cobros.Visible = false;
            }
            else
            {
                Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
            }
        }
    }

    public void cargarReporte()
    {
        DateTime Fecha1 = cp_fecha1.SelectedDate;
        DateTime Fecha2 = cp_fecha2.SelectedDate;
        DateTime Ejec_Fecha1;
        DateTime Ejec_Fecha2;
        if (rbl_periodo_cobros.SelectedValue == "todo")
        {
            Ejec_Fecha1 = Fecha1;
            Ejec_Fecha2 = Fecha2;
        }
        else
        {
            Ejec_Fecha1 = cp_ejec_fecha1.SelectedDate;
            Ejec_Fecha2 = cp_ejec_fecha2.SelectedDate;
        }
        int Id_grupoventa = int.Parse(ddl_grupoventa.SelectedValue);
        string Id_negocio = general.StringNegocios(true, cbl_negocio.Items);
        string Id_negocio_encabezado = general.StringNegocios(false, cbl_negocio.Items);
        int Id_moneda = int.Parse(rbl_moneda.SelectedValue);
        bool Consolidado = rbl_consolidado.SelectedValue.Equals("True");
        string Codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        string col_grupo = rbl_grupo_original_actual.SelectedValue;
        string col_grupo_encabezado = rbl_grupo_original_actual.SelectedItem.Text;

        DataTable tabla_origen = reportesProyeccionCobranza.CarteraProyectadoEjecutado(Fecha1, Fecha2, Id_grupoventa, col_grupo, Id_negocio, Id_moneda, Consolidado, true, Ejec_Fecha1, Ejec_Fecha2, col_grupo, "grupo,promotor,rango,pend_num");

        if (tabla_origen.Rows.Count > 0)
        {
            lbl_mensaje.Text = "";

            DataTable tabla_resumen = reportesProyeccionCobranza.Resumen(ref tabla_origen, "orden_tipo,rango");
            rpt_proyectado_resumenRangos reporte = new rpt_proyectado_resumenRangos();
            reporte.DataSource = tabla_resumen;
            reporte.CargarEncabezado(Profile.nombre_persona, Fecha1, Fecha2, Ejec_Fecha1, Ejec_Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda);
            reporte1.WebView.Report = reporte;

            DataTable tabla_resumen_grupo = reportesProyeccionCobranza.ResumenGrupos(ref tabla_resumen, "No Cobrado", "tot_monto", "orden_grupo,orden_tipo");
            rpt_proyectado_resumenGrupos reporte_grupos = new rpt_proyectado_resumenGrupos();
            reporte_grupos.DataSource = tabla_resumen_grupo;
            reporte_grupos.CargarEncabezado(Profile.nombre_persona, Fecha1, Fecha2, Ejec_Fecha1, Ejec_Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, ddl_grupoventa.SelectedItem.Text, col_grupo_encabezado);
            reporte2.WebView.Report = reporte_grupos;

            DataTable tabla_resumen_promotor = reportesProyeccionCobranza.ResumenPromotores(ref tabla_resumen, "No Cobrado", "tot_monto", "orden_grupo,orden_promotor,orden_tipo");
            rpt_proyectado_resumenPromotores reporte_promotores = new rpt_proyectado_resumenPromotores();
            reporte_promotores.DataSource = tabla_resumen_promotor;
            reporte_promotores.CargarEncabezado(Profile.nombre_persona, Fecha1, Fecha2, Ejec_Fecha1, Ejec_Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, ddl_grupoventa.SelectedItem.Text, col_grupo_encabezado);
            reporte3.WebView.Report = reporte_promotores;

            rpt_proyectado_detalle reporte_detalle = new rpt_proyectado_detalle();
            reporte_detalle.DataSource = tabla_origen;
            reporte_detalle.CargarEncabezado(Profile.nombre_persona, Fecha1, Fecha2, Ejec_Fecha1, Ejec_Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, ddl_grupoventa.SelectedItem.Text, col_grupo_encabezado);
            reporte4.WebView.Report = reporte_detalle;
        }
        else
        {
            lbl_mensaje.Text = "No se encontraron contratos según los parámetros elegidos";
        }
    }

    protected void btn_mostrar_Click(object sender, EventArgs e) { if (VerificarFechas() == true) { cargarReporte(); } }
    protected void cbl_negocio_DataBound(object sender, EventArgs e) { string casas_edif = ConfigurationManager.AppSettings["negocios_casas"]; foreach (ListItem item in cbl_negocio.Items) { item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(false); } }
    protected void rbl_moneda_DataBound(object sender, EventArgs e) { if (rbl_moneda.Items.Count > 0) { rbl_moneda.SelectedIndex = 0; } }
    protected void rbl_consolidado_DataBound(object sender, EventArgs e) { if (rbl_consolidado.Items.Count > 1) { rbl_consolidado.SelectedIndex = 1; } lbl_consolidado_enun.Text = "Datos contemplados:"; }
    protected void ddl_grupoventa_DataBound(object sender, EventArgs e) { ddl_grupoventa.Items.Insert(0, new ListItem("Todos", "0")); }
    protected void rbl_periodo_cobros_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbl_periodo_cobros.SelectedValue == "parte")
        {
            panel_periodo_cobros.Visible = true;
            cp_ejec_fecha1.SelectedDate = cp_fecha1.SelectedDate;
            cp_ejec_fecha2.SelectedDate = cp_fecha2.SelectedDate;
        }
        else { panel_periodo_cobros.Visible = false; }
    }

    protected bool VerificarFechas()
    {
        bool correcto = true;
        if (rbl_periodo_cobros.SelectedValue == "parte")
        {
            if (cp_ejec_fecha1.SelectedDate < cp_fecha1.SelectedDate
                || cp_ejec_fecha2.SelectedDate < cp_fecha1.SelectedDate
                || cp_ejec_fecha1.SelectedDate > cp_fecha2.SelectedDate
                || cp_ejec_fecha2.SelectedDate > cp_fecha2.SelectedDate
                || cp_ejec_fecha2.SelectedDate < cp_ejec_fecha1.SelectedDate
                )
            {
                Msg1.Text = "Revise el rango de fechas del periodo de cobros definido";
                correcto = false;
            }
        }
        return correcto;
    }
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de proyección y ejecución de cobranza</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">Periodo de proyección de pagos:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha1" runat="server"></ew:CalendarPopup>
                                    -
                                    <ew:CalendarPopup ID="cp_fecha2" runat="server"></ew:CalendarPopup> 
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Periodo de cobros realizados:</td>
                                <td class="formTdDato">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="rbl_periodo_cobros" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_periodo_cobros_SelectedIndexChanged">
                                                    <asp:ListItem Text="Todo el periodo" Value="todo" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Entre las fechas" Value="parte"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:Panel ID="panel_periodo_cobros" runat="server" Visible="false">
                                                    <ew:CalendarPopup ID="cp_ejec_fecha1" runat="server"></ew:CalendarPopup>
                                                    -
                                                    <ew:CalendarPopup ID="cp_ejec_fecha2" runat="server"></ew:CalendarPopup>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Grupo de venta:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_grupoventa" runat="server" AutoPostBack="true" DataSourceID="ods_lista_grupoventa" DataValueField="id_grupoventa" DataTextField="nombre" OnDataBound="ddl_grupoventa_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_grupoventa],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_grupoventa" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="ListaActivoOConVentas">
                                    </asp:ObjectDataSource>
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
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2" OnDataBound="cbl_negocio_DataBound"></asp:CheckBoxList>
                                    <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_moneda_DataBound">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_consolidado_DataBound">
                                    </asp:RadioButtonList>
                                    <%--[valor],[texto]--%>
                                    <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" ValidationGroup="filtro" OnClick="btn_mostrar_Click" />
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
                                        <tr><td><asp:Panel ID="panel1" runat="server" GroupingText="Proyección y Ejecución de cobranza por RANGOS"><uc1:reporteCarteraVigente ID="reporte1" runat="server" NombreReporte="CarteraCobranzaPorRangos" /></asp:Panel></td></tr>
                                        <tr><td><asp:Panel ID="panel2" runat="server" GroupingText="Proyección y Ejecución de cobranza por GRUPOS"><uc1:reporteCarteraVigente ID="reporte2" runat="server" NombreReporte="CarteraCobranzaPorGrupos" /></asp:Panel></td></tr>
                                    </table>
                                </td>
                                <td>
                                    <table>
                                        <tr><td><asp:Panel ID="panel3" runat="server" GroupingText="Proyección y Ejecución de cobranza por PROMOTORES"><uc1:reporteCarteraVigente ID="reporte3" runat="server" NombreReporte="CarteraCobranzaPorPromotores" /></asp:Panel></td></tr>
                                        <tr><td><asp:Panel ID="panel4" runat="server" GroupingText="Proyección y Ejecución de cobranza en DETALLE"><uc1:reporteCarteraVigente ID="reporte4" runat="server" NombreReporte="CarteraCobranzaDetalle" /></asp:Panel></td></tr>
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
