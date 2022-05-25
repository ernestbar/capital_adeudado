<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de ingresos de cobranzas realizadas por Síntesis" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/sintesis/sReporte/userControl/criterioReporteSintesis.ascx" tagname="criterioReporteSintesis" tagprefix="uc3" %>
<%@ Register src="~/recurso/sintesis/sReporte/userControl/tipoReporteSintesis.ascx" tagname="tipoReporteSintesis" tagprefix="uc4" %>

<script runat="server">
    public int id_eeff { get { return int.Parse(ddl_eeff.SelectedValue); } }
    public int id_sucursal_eeff { get { return int.Parse(ddl_sucursal.SelectedValue); } }
    public string usuario { get { return txt_usuario.Text.Trim(); } }
    public DateTime fecha_inicio { get { return cp_fecha_inicio.SelectedDate; } }
    public DateTime fecha_fin { get { return cp_fecha_fin.SelectedDate; } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sReporte", "reporteIngresos") == false)
            { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_mostrar_Click(object sender, EventArgs e)
    {
        DataTable tabla = terrasur.sintesis.s_reporte.reporte_ingresos(id_eeff, id_sucursal_eeff, usuario, fecha_inicio, fecha_fin);
        if (rbl_tipo.SelectedValue == "detalle")
        {
            rpt_sintesis_ingresos_detalle reporte = new rpt_sintesis_ingresos_detalle();
            reporte.DataSource = tabla;
            reporte.Encabezado(ddl_eeff.SelectedItem.Text, ddl_sucursal.SelectedItem.Text, txt_usuario.Text.Trim(), cp_fecha_inicio.SelectedDate.ToString("d") + " - " + cp_fecha_fin.SelectedDate.ToString("d"), Profile.nombre_persona, tabla.Rows.Count);
            Reporte1.WebView.Report = reporte;
        }
        else
        {
            rpt_sintesis_ingresos_resumen reporte = new rpt_sintesis_ingresos_resumen();
            reporte.DataSource = tabla;
            reporte.Encabezado(ddl_eeff.SelectedItem.Text, ddl_sucursal.SelectedItem.Text, txt_usuario.Text.Trim(), cp_fecha_inicio.SelectedDate.ToString("d") + " - " + cp_fecha_fin.SelectedDate.ToString("d"), Profile.nombre_persona, tabla.Rows.Count);
            Reporte1.WebView.Report = reporte;
        }
    }

    protected void ddl_eeff_DataBound(object sender, EventArgs e) { ddl_eeff.Items.Insert(0, new ListItem("Todos", "0")); }
    protected void ddl_sucursal_DataBound(object sender, EventArgs e) { ddl_sucursal.Items.Insert(0, new ListItem("Todos", "0")); }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="sReporte" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de ingresos de cobranzas realizadas por Síntesis</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">EEFF / Sucursal:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_eeff" runat="server" AutoPostBack="true" DataSourceID="ods_lista_eeff" DataValueField="id_eeff" DataTextField="nombre" OnDataBound="ddl_eeff_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_eeff],[codigo],[nombre],[num_sucursales]--%>
                                    <asp:ObjectDataSource ID="ods_lista_eeff" runat="server" TypeName="terrasur.sintesis.s_eeff" SelectMethod="Lista">
                                    </asp:ObjectDataSource>

                                    <asp:DropDownList ID="ddl_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataValueField="id_sucursal_eeff" DataTextField="nombre" OnDataBound="ddl_sucursal_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_sucursal_eeff],[codigo],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sintesis.s_sucursal_eeff" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_eeff" Type="Int32" ControlID="ddl_eeff" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><%--Usuario:--%></td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_usuario" runat="server" SkinID="txtSingleLine100" Visible="false" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Periodo:</td>
                                <td class="formTdDato">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td><ew:CalendarPopup ID="cp_fecha_inicio" runat="server"></ew:CalendarPopup></td>
                                            <td>&nbsp;&nbsp;-&nbsp;&nbsp;</td>
                                            <td><ew:CalendarPopup ID="cp_fecha_fin" runat="server"></ew:CalendarPopup></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_tipo" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Detalle" Value="detalle" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Resumen" Value="resumen"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btn_mostrar" runat="server"  SkinID="btnAccion" Text="Mostrar reporte" OnClick="btn_mostrar_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <uc2:reporte ID="Reporte1" runat="server" NombreReporte="Reporte_ingresos_sintesis" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
