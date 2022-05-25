<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Contratos con Saldo Cancelado" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteContratoSaldoCancelado") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        Dim casas_edif As String = ConfigurationManager.AppSettings("negocios_casas")
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(False)
        Next
    End Sub

    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim reporte As New rpt_contratoSaldoCancelado
        reporte.DataSource = contabilidadReporte.ContratoSaldoCancelado(tipofecha_fechas, fecha_inicio, fecha_fin, ini_tipofecha_fechas, ini_fecha_inicio, ini_fecha_fin, Integer.Parse(ddl_localizacion.SelectedValue), Integer.Parse(ddl_urbanizacion.SelectedValue), Integer.Parse(ddl_manzano.SelectedValue), general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        reporte.CargarDatos(ddl_localizacion.SelectedItem.Text, ddl_urbanizacion.SelectedItem.Text, ddl_manzano.SelectedItem.Text, tipofecha_fechas, fecha_inicio, fecha_fin, ini_tipofecha_fechas, ini_fecha_inicio, ini_fecha_fin, general.StringNegocios(False, cbl_negocio.Items), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        Reporte1.WebView.Report = reporte
    End Sub
    
    Protected Function verificar_fechas() As Boolean
        Dim correcto As Boolean = True
        If cp_inicio.SelectedValue.HasValue AndAlso cp_fin.SelectedValue.HasValue Then
            If cp_inicio.SelectedValue.Value > cp_fin.SelectedValue.Value Then
                correcto = False
            End If
        End If
        If cp_ini_inicio.SelectedValue.HasValue AndAlso cp_ini_fin.SelectedValue.HasValue Then
            If cp_ini_inicio.SelectedValue.Value > cp_ini_fin.SelectedValue.Value Then
                correcto = False
            End If
        End If
        Return correcto
    End Function
    
    
    Protected Function tipofecha_fechas() As Integer
        If cp_inicio.SelectedValue.HasValue = False And cp_fin.SelectedValue.HasValue = False Then
            Return 0
        ElseIf cp_inicio.SelectedValue.HasValue = True And cp_fin.SelectedValue.HasValue = False Then
            Return 1
        ElseIf cp_inicio.SelectedValue.HasValue = False And cp_fin.SelectedValue.HasValue = True Then
            Return 2
        Else
            Return 3
        End If
    End Function
    Protected ReadOnly Property fecha_inicio() As DateTime
        Get
            If cp_inicio.SelectedValue.HasValue = True Then
                Return cp_inicio.SelectedDate
            Else
                Return DateTime.Now
            End If
        End Get
    End Property
    Protected ReadOnly Property fecha_fin() As DateTime
        Get
            If cp_fin.SelectedValue.HasValue = True Then
                Return cp_fin.SelectedDate
            Else
                Return DateTime.Now
            End If
        End Get
    End Property

    
    Protected Function ini_tipofecha_fechas() As Integer
        If cp_ini_inicio.SelectedValue.HasValue = False And cp_ini_fin.SelectedValue.HasValue = False Then
            Return 0
        ElseIf cp_ini_inicio.SelectedValue.HasValue = True And cp_ini_fin.SelectedValue.HasValue = False Then
            Return 1
        ElseIf cp_ini_inicio.SelectedValue.HasValue = False And cp_ini_fin.SelectedValue.HasValue = True Then
            Return 2
        Else
            Return 3
        End If
    End Function
    Protected ReadOnly Property ini_fecha_inicio() As DateTime
        Get
            If cp_ini_inicio.SelectedValue.HasValue = True Then
                Return cp_ini_inicio.SelectedDate
            Else
                Return DateTime.Now
            End If
        End Get
    End Property
    Protected ReadOnly Property ini_fecha_fin() As DateTime
        Get
            If cp_ini_fin.SelectedValue.HasValue = True Then
                Return cp_ini_fin.SelectedDate
            Else
                Return DateTime.Now
            End If
        End Get
    End Property

    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        ddl_localizacion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.SelectedIndexChanged
        ddl_urbanizacion.DataBind()
        ddl_manzano.DataBind()
    End Sub

    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.DataBound
        ddl_urbanizacion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.SelectedIndexChanged
        ddl_manzano.DataBind()
    End Sub
    
    Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_manzano.DataBound
        ddl_manzano.Items.Insert(0, New ListItem("Todos", "0"))
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
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" reporte="reporteContratoSaldoCancelado" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Contratos con Saldo Cancelado</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion"></asp:DropDownList>
                                            <%--[id_localizacion],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion"></asp:DropDownList>
                                            <%--[id_urbanizacion],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                       <td class="formTdEnun"><asp:Label ID="lbl_lote_enun" runat="server" Text="Manzano:"></asp:Label></td>
                                       <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano"></asp:DropDownList>
                                            <%--[id_manzano],[codigo]--%>
                                            <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha del último pago:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha de venta (Cuo.Ini.):</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_ini_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_ini_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteContratoSaldoCancelado" />
            </td>
        </tr>
    </table>
</asp:Content>