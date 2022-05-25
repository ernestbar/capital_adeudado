<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de evolución de cartera vigente" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register src="~/recurso/contabilidad/reporteContabilidad/userControl/reporteCarteraVigente.ascx" tagname="reporteCarteraEvolucion" tagprefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraEvolucion") == false)
            {
                Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
            }
        }
    }

    public void cargarReporte()
    {
        DateTime Fecha = cp_fecha.SelectedDate;
        DateTime Fecha2 = cp_fecha2.SelectedDate;
        int Id_grupoventa = int.Parse(ddl_grupoventa.SelectedValue);
        string Id_negocio = general.StringNegocios(true, cbl_negocio.Items);
        string Id_negocio_encabezado = general.StringNegocios(false, cbl_negocio.Items);
        int Id_moneda = int.Parse(rbl_moneda.SelectedValue);
        bool Consolidado = rbl_consolidado.SelectedValue.Equals("True");
        string Codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        string col_grupo = rbl_grupo_original_actual.SelectedValue;
        string col_grupo_encabezado = rbl_grupo_original_actual.SelectedItem.Text;

        DataTable tabla1 = reportesRetraso.CarteraVigente3(Fecha, Id_grupoventa, col_grupo, 0, Id_negocio, Id_moneda, Consolidado);
        DataTable tabla2 = reportesRetraso.CarteraVigente3(Fecha2, Id_grupoventa, col_grupo, 0, Id_negocio, Id_moneda, Consolidado);

        if (tabla1.Rows.Count > 0 && tabla2.Rows.Count > 0)
        {
            lbl_mensaje.Text = "";

            DataTable tabla_evolucion = reportesRetraso.CarteraEvolucion(tabla1, ref tabla2, col_grupo);
            DataTable tabla_evolucion_resumen = reportesRetraso.CarteraEvolucionResumen(tabla_evolucion, "");

            tabla_evolucion_resumen.DefaultView.Sort = "ini_rango,grupo,promotor";
            rpt_resumenEvolucion reporte_general = new rpt_resumenEvolucion();
            reporte_general.DataSource = tabla_evolucion_resumen.DefaultView.ToTable();
            reporte_general.CargarEncabezado(Profile.nombre_persona, Fecha, Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda);
            reporte1.WebView.Report = reporte_general;

            tabla_evolucion_resumen.DefaultView.Sort = "grupo,ini_rango,promotor";
            rpt_resumenEvolucionGrupos reporte_grupos = new rpt_resumenEvolucionGrupos();
            reporte_grupos.DataSource = tabla_evolucion_resumen.DefaultView.ToTable();
            reporte_grupos.CargarEncabezado(Profile.nombre_persona, Fecha, Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, col_grupo_encabezado);
            reporte2.WebView.Report = reporte_grupos;

            tabla_evolucion_resumen.DefaultView.Sort = "grupo,promotor,ini_rango";
            rpt_resumenEvolucionPromotores reporte_promotores = new rpt_resumenEvolucionPromotores();
            reporte_promotores.DataSource = tabla_evolucion_resumen.DefaultView.ToTable();
            reporte_promotores.CargarEncabezado(Profile.nombre_persona, Fecha, Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, col_grupo_encabezado);
            reporte3.WebView.Report = reporte_promotores;

            tabla_evolucion.DefaultView.Sort = "grupo,promotor,ini_rango,fin_rango";
            rpt_detalleEvolucionPromotores reporte_detalle = new rpt_detalleEvolucionPromotores();
            reporte_detalle.DataSource = tabla_evolucion.DefaultView.ToTable();
            reporte_detalle.CargarEncabezado(Profile.nombre_persona, Fecha, Fecha2, Id_negocio_encabezado, rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda, col_grupo_encabezado);
            reporte4.WebView.Report = reporte_detalle;
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
    protected void ddl_grupoventa_DataBound(object sender, EventArgs e) { ddl_grupoventa.Items.Insert(0, new ListItem("Todos", "0")); }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de evolución de cartera vigente</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">Periodo:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup>
                                    -
                                    <ew:CalendarPopup ID="cp_fecha2" runat="server"></ew:CalendarPopup> 
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
                                <td class="formTdEnun">Contratos asocidos al:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_grupo_original_actual" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Text="Grupo original de la venta" Value="grupo" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Grupo actual del promotor" Value="grupo_actual"></asp:ListItem>
                                    </asp:RadioButtonList>
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
                                        <tr><td><asp:Panel ID="panel1" runat="server" GroupingText="Evolución GENERAL de cartera"><uc1:reporteCarteraEvolucion ID="reporte1" runat="server" NombreReporte="CarteraEvolucionGeneral" /></asp:Panel></td></tr>
                                        <tr><td><asp:Panel ID="panel2" runat="server" GroupingText="Evolución de cartera por GRUPOS"><uc1:reporteCarteraEvolucion ID="reporte2" runat="server" NombreReporte="CarteraEvolucionGrupos" /></asp:Panel></td></tr>
                                    </table>
                                </td>
                                <td>
                                    <table>
                                        <tr><td><asp:Panel ID="panel3" runat="server" GroupingText="Evolución de cartera por PROMOTORES (resumen)"><uc1:reporteCarteraEvolucion ID="reporte3" runat="server" NombreReporte="CarteraEvolucionPromotoresResumen" /></asp:Panel></td></tr>
                                        <tr><td><asp:Panel ID="panel4" runat="server" GroupingText="Evolución de cartera por PROMOTORES (detalle)"><uc1:reporteCarteraEvolucion ID="reporte4" runat="server" NombreReporte="CarteraVigentePromotoresDetalle" /></asp:Panel></td></tr>
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
