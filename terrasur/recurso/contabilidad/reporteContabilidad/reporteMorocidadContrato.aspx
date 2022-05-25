<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Morosidad por Contrato" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteMorocidadContrato") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
            Dim p As New parametro("plazo_mora")
            txt_num_dias_ultimo_pago.Text = Integer.Parse(p.valor.ToString)
        End If
    End Sub
        
    Protected ReadOnly Property ini_desde() As DateTime
        Get
            If cp_ini_desde.SelectedValue.HasValue = True Then
                Return cp_ini_desde.SelectedDate
            Else
                Return DateTime.Parse("01/01/1900")
            End If
        End Get
    End Property
    Protected ReadOnly Property ini_hasta() As DateTime
        Get
            If cp_ini_hasta.SelectedValue.HasValue = True Then
                Return cp_ini_hasta.SelectedDate
            Else
                Return DateTime.Parse("01/01/5900")
            End If
        End Get
    End Property
    

    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        Dim casas_edif As String = ConfigurationManager.AppSettings("negocios_casas")
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(False)
        Next
    End Sub
    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.DataBound
        ddl_urbanizacion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim reporte As New rpt_morocidad_contrato
        reporte.DataSource = contabilidadReporte.MorosidadContratoPromotor(cp_fecha.SelectedDate, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(ddl_urbanizacion.SelectedValue), 0, "ultimo_pago_string,orden_negocio,urbanizacion", Integer.Parse(ddl_por_cobrador.SelectedValue), Integer.Parse(txt_num_dias_ultimo_pago.Text), ini_desde, ini_hasta, Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        reporte.CargarDatos(cp_fecha.SelectedDate, general.StringNegocios(False, cbl_negocio.Items), ddl_urbanizacion.SelectedItem.Text, ddl_por_cobrador.SelectedItem.Text, ini_desde, ini_hasta, Integer.Parse(txt_num_dias_ultimo_pago.Text), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
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
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteMorocidadContrato" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Morosidad por Contrato</td></tr>
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
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                            <%--[id_negocio],[codigo],[nombre],[origen]--%>
                                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Sector:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_urbanizacion" runat="server" DataSourceID="ods_lista_urbanizacion" DataTextField="nombre" DataValueField="id_urbanizacion">
                                            </asp:DropDownList>
                                            <%--[id_urbanizacion],[codigo],[nombre_corto],[nombre],[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
                                            <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                                <SelectParameters><asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" /></SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Cobranza:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_por_cobrador" runat="server">
                                                <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Por cobrador" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Sin cobrador" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha de venta (Cuo.Ini.):</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_ini_desde" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_ini_hasta" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteMorocidadContrato" />
            </td>
        </tr>
    </table>
</asp:Content>