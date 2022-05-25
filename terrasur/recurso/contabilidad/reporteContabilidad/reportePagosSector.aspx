<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Pagos por Sector" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%--<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>--%>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reportePagosSector") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.DataBound
        ddl_urbanizacion.Items.Add(New ListItem("Todos", "0"))
    End Sub

    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Sin_ini As Boolean, Fecha_inicio As DateTime, Sin_fin As Boolean, Fecha_fin As DateTime
        If cp_inicio.SelectedValue.HasValue = True Then
            Sin_ini = False
            Fecha_inicio = cp_inicio.SelectedValue.Value
        Else
            Sin_ini = True
            Fecha_inicio = DateTime.Now
        End If
        If cp_fin.SelectedValue.HasValue = True Then
            Sin_fin = False
            Fecha_fin = cp_fin.SelectedValue.Value
        Else
            Sin_fin = True
            Fecha_fin = DateTime.Now
        End If
        Dim Inicio As DateTime = DateTime.Now
        Dim Fin As DateTime = DateTime.Now

        Dim tabla As Data.DataTable = contabilidadReporte.urbanizacion_pago_mes(Integer.Parse(ddl_urbanizacion.SelectedValue), Boolean.Parse(rbl_detalle.SelectedValue), Sin_ini, Fecha_inicio, Sin_fin, Fecha_fin, Inicio, Fin, Boolean.Parse(rbl_int_amortiz.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        Dim int_amortiz As String = ""
        If Boolean.Parse(rbl_int_amortiz.SelectedValue) = False Then
            int_amortiz = "_MONTO"
        End If
        Dim nombre_archivo As String = rbl_detalle.SelectedItem.Text.ToUpper & int_amortiz & "_PAGOS_" & ddl_urbanizacion.SelectedItem.Text.ToUpper.Trim.Replace(" ", "_") & "_" & Inicio.ToString("d").Replace("/", "") & "_" & Fin.ToString("d").Replace("/", "")
        
        ExportarExcel(tabla, nombre_archivo)
    End Sub
    
    Public Sub ExportarExcel(ByVal tabla As Data.DataTable, ByVal nombre As String)
        Response.Clear()
        For Each columna As System.Data.DataColumn In tabla.Columns
            Response.Write(columna.ColumnName + ";")
        Next columna
        
        Response.Write(Environment.NewLine)
        
        For Each fila As System.Data.DataRow In tabla.Rows
            For i As Integer = 0 To tabla.Columns.Count - 1
                Response.Write(fila(i).ToString().Replace(";", String.Empty) + ";")
            Next
            Response.Write(Environment.NewLine)
        Next fila

        Response.ContentType = "text/csv"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre + ".csv")
        Response.End()
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
    Protected Sub rbl_consolidado_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_consolidado.DataBound
        If rbl_consolidado.Items.Count > 0 Then
            rbl_consolidado.SelectedIndex = 0
        End If
        lbl_consolidado_enun.Text = "Datos contemplados:"
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reportePagosSector" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Pagos por Sector</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Sector:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_urbanizacion" runat="server" DataSourceID="ods_lista_urbanizacion" DataValueField="id_urbanizacion" DataTextField="nombre">
                                            </asp:DropDownList>
                                            <%--[id_urbanizacion],[codigo],[nombre_corto],[nombre],[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                                <SelectParameters><asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0"/></SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Periodo:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_detalle" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Detalle" Value="True" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Resumen" Value="False"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_int_amortiz" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Monto de pagos" Value="False" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Amortización e interés" Value="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Moneda:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                            <%--[valor],[texto]--%>
                                            <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Exportar datos a un archivo Excel" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <%--<uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteVentasCobranzas" />--%>
            </td>
        </tr>
    </table>
</asp:Content>