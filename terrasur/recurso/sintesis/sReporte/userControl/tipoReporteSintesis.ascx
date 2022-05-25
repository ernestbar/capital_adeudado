<%@ Control Language="C#" ClassName="tipoReporteSintesis" %>

<script runat="server">
    public void Cargar(bool mostrar_conciliacion_PagoCapital)
    {
        rbl_busqueda_cliente.Checked = true;
        rbl_solicitud_tipo_pago.Checked = true;
        
        rbl_solicitud_contrato.Checked = true;
        rbl_solicitud_pago.Checked = true;

        rbl_conciliacion.Checked = true;
        rbl_conciliacion_PagoCapital.Checked = true;
        rbl_conciliacion_PagoCapital.Visible = mostrar_conciliacion_PagoCapital;

        rbl_verificacion_anulacion.Checked = true;
        rbl_anulacion.Checked = true;
    }
    
    
    public bool busqueda_cliente { get { return rbl_busqueda_cliente.Checked; } }
    public bool solicitud_tipo_pago { get { return rbl_solicitud_tipo_pago.Checked; } }

    public bool solicitud_contrato { get { return rbl_solicitud_contrato.Checked; } }
    public bool solicitud_pago { get { return rbl_solicitud_pago.Checked; } }

    public bool conciliacion { get { return rbl_conciliacion.Checked; } }
    public bool conciliacion_PagoCapital { get { return rbl_conciliacion_PagoCapital.Checked; } }

    public bool verificacion_anulacion { get { return rbl_verificacion_anulacion.Checked; } }
    public bool anulacion { get { return rbl_anulacion.Checked; } }

    public string tipo_reporte_elegidos
    {
        get
        {
            string elegidos = "";
            if (busqueda_cliente) elegidos = elegidos + ",busqueda_cliente";
            if (solicitud_tipo_pago) elegidos = elegidos + ",solicitud_tipo_pago";
            if (solicitud_contrato) elegidos = elegidos + ",solicitud_contrato";
            if (solicitud_pago) elegidos = elegidos + ",solicitud_pago";
            if (conciliacion) elegidos = elegidos + ",conciliacion";
            if (verificacion_anulacion) elegidos = elegidos + ",verificacion_anulacion";
            if (anulacion) elegidos = elegidos + ",anulacion";
            if (elegidos == "") { return ""; }
            else { return elegidos + ","; }
        }
    }
    public string string_tipo_reporte_elegidos
    {
        get
        {
            string elegidos = "";
            if (busqueda_cliente) elegidos = elegidos + "Búsqueda de clientes, ";
            if (solicitud_tipo_pago) elegidos = elegidos + "Solicitud de tipos de pago, ";
            if (solicitud_contrato) elegidos = elegidos + "Solicitud de datos de contrato, ";
            if (solicitud_pago) elegidos = elegidos + "Solicitud de datos de pagos, ";
            if (conciliacion) elegidos = elegidos + "Conciliación de cobros, ";
            if (verificacion_anulacion) elegidos = elegidos + "Verificacion para anulacion, ";
            if (anulacion) elegidos = elegidos + "Solicitud de anulación de cobros, ";

            if (elegidos.Trim() == "") { return ""; } else { return elegidos.Trim().TrimEnd(','); }
        }
    }
    

    
</script>
<asp:Panel ID="panel_tipo_reporte" runat="server" GroupingText="Tipos de reporte / Intercambio de información">
    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr><td align="left"><asp:CheckBox ID="rbl_busqueda_cliente" runat="server" Text="Búsqueda de clientes" /></td></tr>
                    <tr><td align="left"><asp:CheckBox ID="rbl_solicitud_tipo_pago" runat="server" Text="Solicitud de tipos de pago" /></td></tr>
                </table>
            </td>
            <td valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr><td align="left"><asp:CheckBox ID="rbl_solicitud_contrato" runat="server" Text="Solicitud de datos de contrato" /></td></tr>
                    <tr><td align="left"><asp:CheckBox ID="rbl_solicitud_pago" runat="server" Text="Solicitud de datos de pagos" /></td></tr>
                </table>
            </td>
            <td valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr><td align="left"><asp:CheckBox ID="rbl_conciliacion" runat="server" Text="Conciliación de cobros" /></td></tr>
                    <tr><td align="left"><asp:CheckBox ID="rbl_conciliacion_PagoCapital" runat="server" Text="Pagos a capital diferentes" ToolTip="Pagos a capital con montos diferentes a la cuota mensual"/></td></tr>
                </table>
            </td>
            <td valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr><td align="left"><asp:CheckBox ID="rbl_verificacion_anulacion" runat="server" Text="Verificacion para anulacion" /></td></tr>
                    <tr><td align="left"><asp:CheckBox ID="rbl_anulacion" runat="server" Text="Solicitud de anulación de cobros" /></td></tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>