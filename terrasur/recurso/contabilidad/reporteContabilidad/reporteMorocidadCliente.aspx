<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Morosidad por Cliente" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteMorocidadCliente") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
            Dim p As New parametro("plazo_mora")
            txt_num_dias_ultimo_pago.Text = Integer.Parse(p.valor.ToString)
        End If
    End Sub

    Protected Sub rbl_resumen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_resumen.SelectedIndexChanged
        btn_mostrar_reporte.Enabled = Boolean.Parse(rbl_resumen.SelectedValue)
        panel_busqueda.Visible = Boolean.Parse(rbl_resumen.SelectedValue).Equals(False)
        lbl_cliente.Visible = Boolean.Parse(rbl_resumen.SelectedValue).Equals(False)
        If Boolean.Parse(rbl_resumen.SelectedValue) = False Then
            ContratoBusqueda1.Reset()
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_mostrar_reporte.Enabled = ContratoBusqueda1.id_resultado.Equals(0).Equals(False)
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim id_cliente As Integer = 0
        If Boolean.Parse(rbl_resumen.SelectedValue) = True Then
            id_cliente = 0
        Else
            id_cliente = ContratoBusqueda1.id_resultado
        End If
        Dim reporte As New rpt_morocidad_cliente
        reporte.DataSource = contabilidadReporte.MorosidadCliente(cp_fecha.SelectedDate, id_cliente, Integer.Parse(txt_num_dias_ultimo_pago.Text), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        reporte.CargarDatos(cp_fecha.SelectedDate, Integer.Parse(txt_num_dias_ultimo_pago.Text), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
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
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteMorocidadCliente" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Morosidad por Cliente</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">A la fecha:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" Width="100px"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"></td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_resumen" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Resumen general" Value="True" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Por cliente" Value="False"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_cliente" runat="server" Text="Cliente:" Visible="false"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:Panel ID="panel_busqueda" runat="server" Visible="false">
                                                <uc3:contratoBusqueda ID="ContratoBusqueda1" runat="server" buscar_contrato="false" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Nº días desde el último pago:</td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_num_dias_ultimo_pago" runat="server" SkinID="txtSingleLine50" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_num_dias_ultimo_pago" runat="server" ControlToValidate="txt_num_dias_ultimo_pago" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Dene introducir un número"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cv_num_dias_ultimo_pago" runat="server" ControlToValidate="txt_num_dias_ultimo_pago" Display="Dynamic" SetFocusOnError="true" Type="Integer" Operator="DataTypeCheck" Text="*" ErrorMessage="Debe introducir un número entero positivo"></asp:CompareValidator>
                                            <asp:RangeValidator ID="rv_num_dias_ultimo_pago" runat="server" ControlToValidate="txt_num_dias_ultimo_pago" Display="Dynamic" SetFocusOnError="true" Type="Integer" MinimumValue="1" MaximumValue="99999" Text="*" ErrorMessage="El Nº de días debe estar entre 1 y 99999"></asp:RangeValidator>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteMorocidadCliente" />
            </td>
        </tr>
    </table>
</asp:Content>