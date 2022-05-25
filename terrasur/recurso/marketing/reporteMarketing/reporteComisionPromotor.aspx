<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte para el cálculo de comisiones por promotor" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/cicloComercialPeriodo.ascx" TagName="cicloComercialPeriodo" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", "reporteComisionPromotor") Then
                Dim nombre_reporte As String = New permiso("reporteComisionPromotor", "reporteMarketing").nombre
                'Page.Title = nombre_reporte
                lbl_titulo.Text = nombre_reporte
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim reporte As New rpt_comision_promotor
        reporte.DataSource = marketingReporte.ReporteComisionPromotor(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, Id_negocio(), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        reporte.CargarDatos(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, rbl_negocio.SelectedItem.Text, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        Reporte1.WebView.Report = reporte
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
    Protected Sub rbl_consolidado_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_consolidado.DataBound
        If rbl_consolidado.Items.Count > 1 Then
            rbl_consolidado.SelectedIndex = 1
        End If
        lbl_consolidado_enun.Text = "Datos contemplados:"
    End Sub
    
    Protected Function Id_negocio() As String
        Dim resultado As New StringBuilder()
        '[id_negocio],[codigo],[nombre],[origen]
        Dim tabla As Data.DataTable = negocio.Lista
        For Each fila As Data.DataRow In tabla.Rows
            Dim _codigo As String = fila("codigo").ToString
            Dim _id_negocio As String = fila("id_negocio").ToString
            
            If rbl_negocio.SelectedValue = "todos" Then
                resultado.Append("," & _id_negocio)
            ElseIf rbl_negocio.SelectedValue = "no_mercado" Then
                If _codigo <> "mercado" Then
                    resultado.Append("," & _id_negocio)
                End If
            ElseIf rbl_negocio.SelectedValue = "si_mercado" Then
                If _codigo = "mercado" Then
                    resultado.Append("," & _id_negocio)
                End If
            End If
        Next
        resultado.Append(",")
        Return resultado.ToString
    End Function
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteComisionPromotor" />
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
                                        <td class="formTdEnun">Moneda:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_moneda" runat="server" Enabled="false" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_consolidado" runat="server" Enabled="false" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                            <%--[valor],[texto]--%>
                                            <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_negocio" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Todos" Value="todos" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Todos excepto Mercado" Value="no_mercado"></asp:ListItem>
                                                <asp:ListItem Text="Solo Mercado La Suiza" Value="si_mercado"></asp:ListItem>
                                            </asp:RadioButtonList>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteComisionPromotor" />
            </td>
        </tr>
    </table>
</asp:Content>