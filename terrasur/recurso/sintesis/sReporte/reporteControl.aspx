<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Control de intercambio de información con Síntesis" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/sintesis/sReporte/userControl/criterioReporteSintesis.ascx" tagname="criterioReporteSintesis" tagprefix="uc3" %>
<%@ Register src="~/recurso/sintesis/sReporte/userControl/tipoReporteSintesis.ascx" tagname="tipoReporteSintesis" tagprefix="uc4" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sReporte", "reporteControl") == true)
            {
                criterioReporteSintesis1.Cargar(false);
                tipoReporteSintesis1.Cargar(true);
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_obtener_datos_Click(object sender, EventArgs e)
    {
        if (tipoReporteSintesis1.busqueda_cliente)
        {
            panel_busqueda_cliente.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("busqueda_cliente", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_busqueda_cliente reporte = new rpt_sintesis_busqueda_cliente();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_busqueda_cliente.WebView.Report = reporte;
        }
        else { panel_busqueda_cliente.Visible = false; }

        if (tipoReporteSintesis1.solicitud_tipo_pago)
        {
            panel_solicitud_tipo_pago.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("solicitud_tipo_pago", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_tipo_pago reporte = new rpt_sintesis_tipo_pago();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_solicitud_tipo_pago.WebView.Report = reporte;
        }
        else { panel_solicitud_tipo_pago.Visible = false; }

        if (tipoReporteSintesis1.solicitud_contrato)
        {
            panel_solicitud_contrato.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("solicitud_contrato", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_contrato reporte = new rpt_sintesis_contrato();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_solicitud_contrato.WebView.Report = reporte;
        }
        else { panel_solicitud_contrato.Visible = false; }

        if (tipoReporteSintesis1.solicitud_pago)
        {
            panel_solicitud_pago.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("solicitud_pago", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_pago reporte = new rpt_sintesis_pago();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_solicitud_pago.WebView.Report = reporte;
        }
        else { panel_solicitud_pago.Visible = false; }

        if (tipoReporteSintesis1.conciliacion)
        {
            panel_conciliacion.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("conciliacion", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_conciliacion reporte = new rpt_sintesis_conciliacion();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_conciliacion.WebView.Report = reporte;
        }
        else { panel_conciliacion.Visible = false; }

        if (tipoReporteSintesis1.conciliacion_PagoCapital)
        {
            panel_conciliacion_PagoCapital.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("conciliacion_PagoCapital", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_pago_capital_diferente reporte = new rpt_sintesis_pago_capital_diferente();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_conciliacion_PagoCapital.WebView.Report = reporte;
        }
        else { panel_conciliacion_PagoCapital.Visible = false; }

        if (tipoReporteSintesis1.verificacion_anulacion)
        {
            panel_verificacion_anulacion.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("verificacion_anulacion", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_verificacion_anulacion reporte = new rpt_sintesis_verificacion_anulacion();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_verificacion_anulacion.WebView.Report = reporte;
        }
        else { panel_verificacion_anulacion.Visible = false; }

        if (tipoReporteSintesis1.anulacion)
        {
            panel_anulacion.Visible = true;
            DataTable tabla = terrasur.sintesis.s_reporte.reporte_control("anulacion", criterioReporteSintesis1.id_eeff, criterioReporteSintesis1.id_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.fecha_inicio, criterioReporteSintesis1.fecha_fin, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.id_pagopendiente);
            rpt_sintesis_anulacion reporte = new rpt_sintesis_anulacion();
            reporte.DataSource = tabla;
            reporte.Encabezado(criterioReporteSintesis1.string_eeff, criterioReporteSintesis1.string_sucursal_eeff, criterioReporteSintesis1.usuario, criterioReporteSintesis1.string_fechas, criterioReporteSintesis1.num_contrato, criterioReporteSintesis1.string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
            Reporte_anulacion.WebView.Report = reporte;
        }
        else { panel_anulacion.Visible = false; }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="sReporte" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Control de intercambio de información con Síntesis</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table cellpadding="0" cellspacing="0" align="center">
                            <tr><td><uc3:criterioReporteSintesis ID="criterioReporteSintesis1" runat="server"/></td></tr>
                            <tr><td><uc4:tipoReporteSintesis ID="tipoReporteSintesis1" runat="server" /></td></tr>
                            <tr><td><asp:Button ID="btn_obtener_datos" runat="server" Text="Obtener datos" OnClick="btn_obtener_datos_Click" /></td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_busqueda_cliente" runat="server" GroupingText="Búsqueda de clientes">
                                        <uc2:reporte ID="Reporte_busqueda_cliente" runat="server" NombreReporte="Reporte_busqueda_cliente" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_solicitud_tipo_pago" runat="server" GroupingText="Solicitud de tipos de pago disponibles por contrato">
                                        <uc2:reporte ID="Reporte_solicitud_tipo_pago" runat="server" NombreReporte="Reporte_solicitud_tipo_pago" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_solicitud_contrato" runat="server" GroupingText="Solicitud de datos de contratos">
                                        <uc2:reporte ID="Reporte_solicitud_contrato" runat="server" NombreReporte="Reporte_solicitud_contrato" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_solicitud_pago" runat="server" GroupingText="Solicitud de datos de pagos a realizar">
                                        <uc2:reporte ID="Reporte_solicitud_pago" runat="server" NombreReporte="Reporte_solicitud_pago" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_conciliacion" runat="server" GroupingText="Conciliación de cobros">
                                        <uc2:reporte ID="Reporte_conciliacion" runat="server" NombreReporte="Reporte_conciliacion" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_conciliacion_PagoCapital" runat="server" GroupingText="Pagos a capital diferentes al monto predeterminado">
                                        <uc2:reporte ID="Reporte_conciliacion_PagoCapital" runat="server" NombreReporte="Reporte_conciliacion_PagoCapital" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_verificacion_anulacion" runat="server" GroupingText="Verificación para anulación de cobros realizados">
                                        <uc2:reporte ID="Reporte_verificacion_anulacion" runat="server" NombreReporte="Reporte_verificacion_anulacion" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Anulación de cobros realizados">
                                        <uc2:reporte ID="Reporte_anulacion" runat="server" NombreReporte="Reporte_anulacion" />
                                    </asp:Panel>
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
