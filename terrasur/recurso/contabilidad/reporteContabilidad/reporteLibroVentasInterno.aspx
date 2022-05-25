<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Libro Interno de Ventas IVA" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteLibroVentasInterno") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim reporte As New rpt_libro_ventas_interno
        reporte.DataSource = contabilidadReporte.LibroVentasInterno(Integer.Parse(ddl_razon_social.SelectedValue), cp_inicio.SelectedDate, cp_fin.SelectedDate, Integer.Parse(rbl_facturas.SelectedValue))
        reporte.CargarDatos(ddl_sucursal.SelectedItem.Text, Integer.Parse(ddl_razon_social.SelectedValue), cp_inicio.SelectedDate, cp_fin.SelectedDate, rbl_facturas.SelectedItem.Text)
        Reporte1.WebView.Report = reporte
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteLibroVentasInterno" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Libro Interno de Ventas IVA</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Sucursal:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_sucursal" runat="server" AutoPostBack="true" DataSourceID="ods_lista_sucursal" DataTextField="nombre" DataValueField="id_sucursal"></asp:DropDownList>
                                            <%--[id_sucursal],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sucursal" SelectMethod="ListaParaDDL">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Razón social:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_razon_social" runat="server" DataSourceID="ods_lista_parametro_facturacion" DataTextField="razon_social" DataValueField="id_parametrofacturacion">
                                            </asp:DropDownList>
                                            <%--[id_parametrofacturacion],[razon_social]--%>
                                            <asp:ObjectDataSource ID="ods_lista_parametro_facturacion" runat="server" TypeName="terrasur.parametro_facturacion" SelectMethod="ListaLibroVentas">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Id_sucursal" Type="Int32" ControlID="ddl_sucursal" PropertyName="SelectedValue" DefaultValue="0" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Desde:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_inicio" runat="server" Width="100px"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Hasta:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_fin" runat="server" Width="100px"></ew:CalendarPopup>
                                            <asp:CompareValidator ID="cv_fin" runat="server" ControlToValidate="cp_fin" ControlToCompare="cp_inicio" Display="Dynamic" Type="Date" Operator="GreaterThanEqual" Text="*" ErrorMessage="El periodo es incorrecto"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Facturas:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_facturas" runat="server" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Sin facturas anuladas" Value="1" Selected="true"></asp:ListItem>
                                                <asp:ListItem Text="Con facturas anuladas" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Solo facturas anuladas" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="vs_reporte" runat="server" DisplayMode="List" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteLibroVentasInterno" />
            </td>
        </tr>
    </table>
</asp:Content>