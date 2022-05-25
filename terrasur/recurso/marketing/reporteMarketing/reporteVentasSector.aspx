<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de ventas por sector" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/cicloComercialPeriodo.ascx" TagName="cicloComercialPeriodo" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", "reporteVentasSector") Then
                Dim nombre_reporte As String = New permiso("reporteVentasSector", "reporteMarketing").nombre
                'Page.Title = nombre_reporte
                lbl_titulo.Text = nombre_reporte
                
                If Profile.entorno.codigo_modulo = "adm" Then
                    lbl_periodo2.Visible = True
                    panel_periodo2.Visible = True
                Else
                    lbl_periodo2.Visible = False
                    panel_periodo2.Visible = False
                End If
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        ddl_localizacion.Items.Insert(0, New ListItem("Todas", "0"))
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim reporte As New rpt_ventas_sector
        Dim reporte_fecha_inicio As Date = CicloComercialPeriodo1.inicio
        Dim reporte_fecha_fin As Date = CicloComercialPeriodo1.fin
        If cp_inicio.SelectedValue.HasValue Then
            reporte_fecha_inicio = cp_inicio.SelectedValue.Value
        End If
        If cp_fin.SelectedValue.HasValue Then
            reporte_fecha_fin = cp_fin.SelectedValue.Value
        End If
        
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        reporte.CargarDatos(reporte_fecha_inicio, reporte_fecha_fin, ddl_localizacion.SelectedItem.Text, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        reporte.DataSource = marketingReporte.ReporteVentasSector(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Integer.Parse(ddl_localizacion.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        
        Reporte1.WebView.Report = reporte
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
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteVentasTotales" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server"></asp:Label></td></tr>
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
                                    <tr>
                                        <td class="formTdEnun">Periodo:</td>
                                        <td class="formTdDato"><uc3:cicloComercialPeriodo ID="CicloComercialPeriodo1" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_periodo2" runat="server" Text="Periodo (reporte):"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:Panel ID="panel_periodo2" runat="server">
                                                <ew:CalendarPopup ID="cp_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                                -
                                                <ew:CalendarPopup ID="cp_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Localizacion:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_lista_localizacion" DataValueField="id_localizacion" DataTextField="nombre">
                                            </asp:DropDownList>
                                            <%--[id_localizacion],[codigo],[nombre],[imagen]--%>
                                            <asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="ListaConUrbanizacion">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
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
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteVentasSector" />
            </td>
        </tr>
    </table>
</asp:Content>

