<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de ventas de lotes revertidos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/cicloComercialPeriodo.ascx" TagName="cicloComercialPeriodo" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", "reporteVentasGeneralReversion") Then
                Dim nombre_reporte As String = New permiso("reporteVentasGeneralReversion", "reporteMarketing").nombre
                'Page.Title = nombre_reporte
                lbl_titulo.Text = nombre_reporte
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub ddl_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_grupoventa.DataBound, ddl_promotor.DataBound, ddl_localizacion.DataBound, ddl_urbanizacion.DataBound
        CType(sender, DropDownList).Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim reporte As New rpt_ventas_general_reversion
        reporte.CargarDatos(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, ddl_grupoventa.SelectedItem.Text, ddl_promotor.SelectedItem.Text, ddl_localizacion.SelectedItem.Text, ddl_urbanizacion.SelectedItem.Text, rbl_tipo_venta.SelectedItem.Text, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        reporte.DataSource = marketingReporte.ReporteVentasGeneral_reversion(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Integer.Parse(ddl_grupoventa.SelectedValue), Integer.Parse(ddl_promotor.SelectedValue), Integer.Parse(ddl_localizacion.SelectedValue), Integer.Parse(ddl_urbanizacion.SelectedValue), Integer.Parse(rbl_tipo_venta.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
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
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteVentasGeneralReversion" />
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
                                        <td class="formTdEnun">Grupo de venta:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_grupoventa" runat="server" AutoPostBack="true" DataSourceID="ods_lista_grupoventa" DataValueField="id_grupoventa" DataTextField="nombre">
                                            </asp:DropDownList>
                                            <%--[id_grupoventa],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_grupoventa" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="ListaActivoOConVentas">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Promotor:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_promotor" runat="server" DataSourceID="ods_lista_promotor" DataValueField="id_grupopromotor" DataTextField="nombre">
                                            </asp:DropDownList>
                                            <%--[id_grupopromotor],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaActivoOConVentas">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="ddl_grupoventa" PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
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
                                        <td class="formTdEnun">Sector:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_urbanizacion" runat="server" DataSourceID="ods_lista_urbanizacion" DataValueField="id_urbanizacion" DataTextField="nombre">
                                            </asp:DropDownList>
                                            <%--[id_urbanizacion],[codigo],[nombre_corto],[nombre],[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Tipo de venta:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_tipo_venta" runat="server" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Venta de lotes revertidos" Value="2" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Primera venta de lotes" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
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
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteVentasGeneralLotesRevertidos" />
            </td>
        </tr>
    </table>
</asp:Content>