<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de reversiones para descuentos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<script runat="server">
    protected DateTime reversion_inicio { get { if (cp_inicio.SelectedValue.HasValue == true) return cp_inicio.SelectedDate; else { return DateTime.Parse("01/01/1899"); } } }
    protected DateTime reversion_fin { get { if (cp_fin.SelectedValue.HasValue == true) return cp_fin.SelectedDate; else { return DateTime.Parse("01/01/2020"); } } }

    protected DateTime cuota_inicial_inicio { get { if (cp_cuotainicial_inicio.SelectedValue.HasValue == true) return cp_cuotainicial_inicio.SelectedDate; else { return DateTime.Parse("01/01/1899"); } } }
    protected DateTime cuota_inicial_fin { get { if (cp_cuotainicial_fin.SelectedValue.HasValue == true) return cp_cuotainicial_fin.SelectedDate; else { return DateTime.Parse("01/01/2020"); } } }

    protected int num_minimo_pagos { get { if (txt_num_pagos.Text.Trim() != "") return int.Parse(txt_num_pagos.Text); else return 1000; } }
    protected decimal porcentaje_minimo { get { if (txt_porcentaje.Text.Trim() != "") return decimal.Parse(txt_porcentaje.Text); else return 101; } }
    protected decimal monto_minimo { get { if (txt_monto.Text.Trim() != "") return decimal.Parse(txt_monto.Text); else return 1000000; } }

    protected string motivos_reversion_ejegidos(bool Ids)
    {
        string res = "";
        if (Ids == true)
        {
            foreach (ListItem item in cbl_motivoreversion.Items)
            {
                if (item.Selected == true) 
                    res += item.Value + ",";
            }
            if (res == "") return "";
            else return "," + res;
        }
        else
        {
            foreach (ListItem item in cbl_motivoreversion.Items)
            {
                if (item.Selected == true) 
                    res += item.Text + ", ";
            }
            if (res == "") return "Ninguno";
            else return res.Trim().TrimEnd(',');
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", "reporteReversionDescuento") == true)
            {
                rbl_director.SelectedValue = "promotor";
                DateTime fecha_actual = DateTime.Now.Date;
                cp_inicio.SelectedDate = fecha_actual.AddDays((fecha_actual.Day - 1) * (-1)).AddMonths(-1);
                cp_fin.SelectedDate = fecha_actual.AddDays((fecha_actual.Day - 1) * (-1)).AddDays(-1);
                cp_cuotainicial_inicio.SelectedDate = DateTime.Parse("01/01/2009").AddMonths(8);
                cp_cuotainicial_fin.SelectedDate = fecha_actual.AddDays((fecha_actual.Day - 1) * (-1)).AddMonths(-4).AddDays(-1);
                txt_num_pagos.Text = "8";
                txt_porcentaje.Text = "";
                txt_monto.Text = "500";
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }




    protected void btn_mostrar_reporte_Click(object sender, EventArgs e)
    {
        string fecha_reversion = "";
        if (cp_inicio.SelectedValue.HasValue == true && cp_fin.SelectedValue.HasValue == true) fecha_reversion = "Entre el " + cp_inicio.SelectedDate.ToString("d") + " y el " + cp_fin.SelectedDate.ToString("d");
        else if (cp_inicio.SelectedValue.HasValue == true && cp_fin.SelectedValue.HasValue == false) fecha_reversion = "Desde el " + cp_inicio.SelectedDate.ToString("d");
        else if (cp_inicio.SelectedValue.HasValue == false && cp_fin.SelectedValue.HasValue == true) fecha_reversion = "Hasta el " + cp_fin.SelectedDate.ToString("d");
        else fecha_reversion = "Todos";
        
        string fecha_cuota_incial = "";
        if (cp_cuotainicial_inicio.SelectedValue.HasValue == true && cp_cuotainicial_fin.SelectedValue.HasValue == true) fecha_cuota_incial = "Entre el " + cp_cuotainicial_inicio.SelectedDate.ToString("d") + " y el " + cp_cuotainicial_fin.SelectedDate.ToString("d");
        else if (cp_cuotainicial_inicio.SelectedValue.HasValue == true && cp_cuotainicial_fin.SelectedValue.HasValue == false) fecha_cuota_incial = "Desde el " + cp_cuotainicial_inicio.SelectedDate.ToString("d");
        else if (cp_cuotainicial_inicio.SelectedValue.HasValue == false && cp_cuotainicial_fin.SelectedValue.HasValue == true) fecha_cuota_incial = "Hasta el " + cp_cuotainicial_fin.SelectedDate.ToString("d");
        else fecha_cuota_incial = "Todos";
        
        string num_pagos = "";
        if (txt_num_pagos.Text.Trim() == "") num_pagos = "---"; else num_pagos = txt_num_pagos.Text.Trim();
        
        string porcentaje = "";
        if (txt_porcentaje.Text.Trim() == "") porcentaje = "---"; else porcentaje = decimal.Parse(txt_porcentaje.Text.Trim()).ToString("F2") + " %";

        string monto = "";
        if (txt_monto.Text.Trim() == "") monto = "---"; else monto = decimal.Parse(txt_monto.Text.Trim()).ToString("F2");

        if (rbl_director.SelectedValue == "promotor")
        {
            //if (rbl_formato.SelectedValue == "detalle")
            //{
            rpt_marketing_reversiones_promotor reporte = new rpt_marketing_reversiones_promotor();
            reporte.DataSource = marketingReporte.ReporteReversionDescuento(rbl_director.SelectedValue.Equals("director"), reversion_inicio, reversion_fin, cuota_inicial_inicio, cuota_inicial_fin, num_minimo_pagos, porcentaje_minimo, monto_minimo, motivos_reversion_ejegidos(true));
            reporte.CargarDatos(rbl_director.SelectedValue.Equals("director"), fecha_reversion, fecha_cuota_incial, num_pagos, porcentaje, monto, motivos_reversion_ejegidos(false));
            Reporte1.WebView.Report = reporte;
            //}
            //else
            //{
            //    rpt_marketing_reversiones_resumen reporte = new rpt_marketing_reversiones_resumen();
            //    reporte.DataSource = ReporteReversionDescuento(rbl_director.SelectedValue.Equals("director"), reversion_inicio, reversion_fin, cuota_inicial_inicio, cuota_inicial_fin, num_minimo_pagos, porcentaje_minimo, monto_minimo, motivos_reversion_ejegidos(true));
            //    reporte.CargarDatos(rbl_director.SelectedValue.Equals("director"), fecha_reversion, fecha_cuota_incial, num_pagos, porcentaje, monto, motivos_reversion_ejegidos(false));
            //    Reporte1.WebView.Report = reporte;
            //}
        }
        else
        {
            rpt_marketing_reversiones_director reporte = new rpt_marketing_reversiones_director();
            reporte.DataSource = marketingReporte.ReporteReversiones_director(reversion_inicio, reversion_fin, cuota_inicial_inicio, cuota_inicial_fin, num_minimo_pagos, porcentaje_minimo, monto_minimo, motivos_reversion_ejegidos(true));
            reporte.CargarDatos(fecha_reversion, fecha_cuota_incial, num_pagos, porcentaje, monto, motivos_reversion_ejegidos(false));
            Reporte1.WebView.Report = reporte;

        }
    }

    protected void cbl_motivoreversion_DataBound(object sender, EventArgs e)
    {
        foreach (ListItem item in cbl_motivoreversion.Items)
        {
            if (item.Text == "Reversión por mora" || item.Text == "A solicitud del cliente" || item.Text == "Recuperación de Cartera" || item.Text == "Devolución de aportes" || item.Text == "Devolución de aportes CON desc" || item.Text == "Traspaso de capital CON desc")
                item.Selected = true;
        }
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteReversionDescuento" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de reversiones para descuentos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2" class="formTdMsg">
                                            <asp:ValidationSummary ID="vs_reporte" runat="server" DisplayMode="List" ShowMessageBox="false" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="formTdEnun">Formato del reporte:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_formato" runat="server" Enabled="false" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="rbl_director_SelectedIndexChanged">
                                                <asp:ListItem Text="Detalle" Value="detalle" Selected="True" />
                                                <asp:ListItem Text="Resumen" Value="resumen" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="formTdEnun">Reporte de reversiones para:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_director" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Promotores" Value="promotor" Selected="True" />
                                                <asp:ListItem Text="Directores" Value="director" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Periodo de reversiones:</td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td><ew:CalendarPopup ID="cp_inicio" runat="server" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                    <td>-</td>
                                                    <td><ew:CalendarPopup ID="cp_fin" runat="server" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha cuota inicial:</td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td><ew:CalendarPopup ID="cp_cuotainicial_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                    <td>-</td>
                                                    <td><ew:CalendarPopup ID="cp_cuotainicial_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_num_pagos" runat="server" Text="Nro. mínimo de pagos para evitar el descuento:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_num_pagos" runat="server" Enabled="false" SkinID="txtSingleLine50" MaxLength="4"></asp:TextBox>
                                            <asp:CompareValidator ID="cv_num_pagos" runat="server" ControlToValidate="txt_num_pagos" Display="Dynamic" Type="Integer" Operator="DataTypeCheck" Text="*" ErrorMessage="Debe introducir un número entero válido"></asp:CompareValidator>
                                            <asp:RangeValidator ID="rv_num_pagos" runat="server" ControlToValidate="txt_num_pagos" Display="Dynamic" Type="Integer" MinimumValue="0" MaximumValue="9999" Text="*" ErrorMessage="El número de pagos debe estar entre 0 y 9999"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_porcentaje" runat="server" Text="% mínimo de capital cancelado para evitar el descuento:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_porcentaje" runat="server" Enabled="false" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                            <asp:CompareValidator ID="cv_porcentaje" runat="server" ControlToValidate="txt_porcentaje" Display="Dynamic" Type="Double" Operator="DataTypeCheck" Text="*" ErrorMessage="Debe introducir un número válido"></asp:CompareValidator>
                                            <asp:RangeValidator ID="rv_porcentaje" runat="server" ControlToValidate="txt_porcentaje" Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="100" Text="*" ErrorMessage="El porcentaje debe estar entre 0 y 100"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_monto" runat="server" Text="Monto mínimo de capital cancelado para evitar el descuento:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_monto" runat="server" Enabled="false" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                            <asp:CompareValidator ID="cv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" Type="Double" Operator="DataTypeCheck" Text="*" ErrorMessage="Debe introducir un número válido"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_morivoreversion" runat="server" Text="Motivos de reversión tomados en cuenta:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:CheckBoxList ID="cbl_motivoreversion" runat="server" Enabled="false" DataTextField="nombre" DataValueField="id_motivoreversion" DataSourceID="ods_motivo_lista" CellPadding="0" CellSpacing="0" OnDataBound="cbl_motivoreversion_DataBound">
                                            </asp:CheckBoxList>
                                            <%--[id_motivodesactivacion],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.motivo_reversion" SelectMethod="ListaNoSistema">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" OnClick="btn_mostrar_reporte_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteMora" />
            </td>
        </tr>
    </table>
</asp:Content>