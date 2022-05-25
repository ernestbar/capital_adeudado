<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Libro de Ventas IVA" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteLibroVentasRenta") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim reporte As New rpt_libro_ventas_renta
        reporte.DataSource = contabilidadReporte.LibroVentasRenta(Integer.Parse(ddl_razon_social.SelectedValue), cp_inicio.SelectedDate, cp_fin.SelectedDate)
        reporte.CargarDatos(Integer.Parse(ddl_razon_social.SelectedValue), cp_inicio.SelectedDate, cp_fin.SelectedDate)
        Reporte1.WebView.Report = reporte
    End Sub

    Protected Sub btn_generar_txt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_generar_txt.Click
        cargarReporte()
    End Sub

    Public Sub cargarReporte()
        Dim id_sucursal As Integer = 0
        If rbl_archivo_texto.SelectedValue = "sucursal" AndAlso ddl_sucursal.Visible = True Then
            id_sucursal = Integer.Parse(ddl_sucursal.SelectedValue)
        End If

        Dim pfact_obj As New parametro_facturacion(Integer.Parse(ddl_razon_social.SelectedValue))
        Dim sb As StringBuilder = contabilidadReporte.LibroVentasRenta_txt(Integer.Parse(ddl_razon_social.SelectedValue), cp_inicio.SelectedDate, cp_fin.SelectedDate, id_sucursal)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "text/plain"
        Response.AddHeader("Content-Disposition", "attachment;filename=ventas_" & cp_inicio.SelectedDate.ToString("MMyyyy") & "_" & pfact_obj.nit.ToString & ".txt")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString().TrimEnd(";").Replace(";", vbNewLine))
        Response.End()
    End Sub
    
    Protected Sub ddl_sucursal_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_sucursal.DataBound
        rbl_archivo_texto.SelectedValue = "sucursal"
        If ddl_sucursal.Items.Count > 1 Then
            lbl_archivo_texto.Visible = True
            rbl_archivo_texto.Visible = True
        Else
            lbl_archivo_texto.Visible = False
            rbl_archivo_texto.Visible = False
        End If
    End Sub
    Protected Sub rbl_archivo_texto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_archivo_texto.SelectedIndexChanged
        ddl_sucursal.Visible = rbl_archivo_texto.SelectedValue.Equals("sucursal")
        btn_mostrar_reporte.Enabled = rbl_archivo_texto.SelectedValue.Equals("sucursal")
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteLibroVentasRenta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Libro de Ventas IVA</td></tr>
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
                                        <td class="formTdEnun"><asp:Label ID="lbl_archivo_texto" runat="server" Text="Archivo de texto:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_archivo_texto" runat="server" CellSpacing="0" CellPadding="0" RepeatDirection="Horizontal" AutoPostBack="true">
                                                <asp:ListItem Text="Por sucursal" Value="sucursal" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Consolidado" Value="consolidado"></asp:ListItem>
                                            </asp:RadioButtonList>
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
                                </table>
                                <asp:ValidationSummary ID="vs_reporte" runat="server" DisplayMode="List" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                                <asp:Button ID="btn_generar_txt" runat="server" SkinID="btnAccion" Text="Generar archivo TXT" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteLibroVentasRenta" />
            </td>
        </tr>
    </table>
</asp:Content>