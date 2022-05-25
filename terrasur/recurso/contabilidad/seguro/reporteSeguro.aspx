<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Seguro de Desgravamen" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    
    Protected ReadOnly Property seguro_inicio() As DateTime
        Get
            If cb_pago_mensual.Checked = True And cp_seguro_inicio.SelectedValue.HasValue = True Then
                Return cp_seguro_inicio.SelectedDate
            Else
                Return DateTime.Parse("01/01/1900")
            End If
        End Get
    End Property
    Protected ReadOnly Property seguro_fin() As DateTime
        Get
            If cb_pago_mensual.Checked = True And cp_seguro_fin.SelectedValue.HasValue = True Then
                Return cp_seguro_fin.SelectedDate
            Else
                Return DateTime.Parse("01/01/5900")
            End If
        End Get
    End Property
    
    Protected ReadOnly Property pago_inicio() As DateTime
        Get
            If cb_pago_mensual.Checked = True And cp_pago_inicio.SelectedValue.HasValue = True Then
                Return cp_pago_inicio.SelectedDate
            Else
                Return DateTime.Parse("01/01/1900")
            End If
        End Get
    End Property
    Protected ReadOnly Property pago_fin() As DateTime
        Get
            If cb_pago_mensual.Checked = True And cp_pago_fin.SelectedValue.HasValue = True Then
                Return cp_pago_fin.SelectedDate
            Else
                Return DateTime.Parse("01/01/5900")
            End If
        End Get
    End Property

    Protected ReadOnly Property cuota_inicial_fecha_inicio() As DateTime
        Get
            If cb_cuota_inicial.Checked = True And cp_cuota_inicial_fecha_inicio.SelectedValue.HasValue = True Then
                Return cp_cuota_inicial_fecha_inicio.SelectedDate
            Else
                Return DateTime.Parse("01/01/1900")
            End If
        End Get
    End Property
    Protected ReadOnly Property cuota_inicial_fecha_fin() As DateTime
        Get
            If cb_cuota_inicial.Checked = True And cp_cuota_inicial_fecha_fin.SelectedValue.HasValue = True Then
                Return cp_cuota_inicial_fecha_fin.SelectedDate
            Else
                Return DateTime.Parse("01/01/5900")
            End If
        End Get
    End Property

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "reporte") Then
                cb_pago_mensual.Checked = True
                pago_mensual_reset(True)
                cb_cuota_inicial.Checked = True
                cuota_inicial_reset(True)
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        If Verificar() = True Then
            Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo
            Dim reporte As New rpt_seguro2
            reporte.DataSource = seguro_provida.ReporteCobroSeguro(cb_pago_mensual.Checked, seguro_inicio, seguro_fin, pago_inicio, pago_fin, cb_cuota_inicial.Checked, cuota_inicial_fecha_inicio, cuota_inicial_fecha_fin, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(rbl_estado.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
            reporte.Encabezado(cb_pago_mensual.Checked, seguro_inicio, seguro_fin, pago_inicio, pago_fin, cb_cuota_inicial.Checked, cuota_inicial_fecha_inicio, cuota_inicial_fecha_fin, general.StringNegocios(False, cbl_negocio.Items), rbl_estado.SelectedItem.Text, Profile.nombre_persona, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
            Reporte1.WebView.Report = reporte
        End If
    End Sub

    Protected Function Verificar() As Boolean
        Dim correcto As Boolean = True
        
        If cb_pago_mensual.Checked = True Then
            Dim fecha_seguro_elegido As Boolean
            If cp_seguro_fin.SelectedValue.HasValue = True And cp_seguro_fin.SelectedValue.HasValue = True Then
                fecha_seguro_elegido = True
            Else
                fecha_seguro_elegido = False
            End If
            
            Dim fecha_pago_elegido As Boolean
            If cp_pago_inicio.SelectedValue.HasValue = True And cp_pago_fin.SelectedValue.HasValue = True Then
                fecha_pago_elegido = True
            Else
                fecha_pago_elegido = False
            End If

            If fecha_seguro_elegido = False And fecha_pago_elegido = False Then
                correcto = False
                Msg1.Text = "Debe elegir el Perido de seguro o el Periodo de pago o ambos"
            End If
        End If
        
        If cb_cuota_inicial.Checked = True Then
            If cp_cuota_inicial_fecha_inicio.SelectedValue.HasValue = False And cp_cuota_inicial_fecha_fin.SelectedValue.HasValue = False Then
                correcto = False
                Msg1.Text = "Debe elegir el periodo de las cuotas iniciales"
            End If
        End If
        
        Dim negocio_elegido As Boolean = False
        For Each item As ListItem In cbl_negocio.Items
            If item.Selected = True Then
                negocio_elegido = True
                Exit For
            End If
        Next
        If negocio_elegido = False Then
            correcto = False
            Msg1.Text = "Debe elegir al menos un negocio"
        End If
        
        Return correcto
    End Function
    
    
    Protected Sub cb_pago_mensual_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_pago_mensual.CheckedChanged
        pago_mensual_reset(cb_pago_mensual.Checked)
    End Sub
    Protected Sub pago_mensual_reset(ByVal Checked As Boolean)
        If Checked = True Then
            Dim f_ini As DateTime
            f_ini = DateTime.Now.Date.AddDays((DateTime.Now.Day * -1) + 1)
            If DateTime.Now.Day < 25 Then
                f_ini = f_ini.AddMonths(-1)
            End If
            Dim f_fin As DateTime = f_ini.AddMonths(1).AddDays(-1)

            cp_seguro_inicio.SelectedDate = f_ini
            cp_seguro_fin.SelectedDate = f_fin
            
            cp_pago_inicio.SelectedValue = Nothing
            cp_pago_fin.SelectedValue = Nothing
        Else
            cp_seguro_inicio.SelectedValue = Nothing
            cp_seguro_fin.SelectedValue = Nothing

            cp_pago_inicio.SelectedValue = Nothing
            cp_pago_fin.SelectedValue = Nothing
        End If
        panel_pago_mensual.Enabled = Checked
    End Sub

    Protected Sub cb_cuota_inicial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_cuota_inicial.CheckedChanged
        cuota_inicial_reset(cb_cuota_inicial.Checked)
    End Sub
    Protected Sub cuota_inicial_reset(ByVal Checked As Boolean)
        If Checked = True Then
            Dim f_ini As DateTime
            f_ini = DateTime.Now.Date.AddDays((DateTime.Now.Day * -1) + 1)
            If DateTime.Now.Day < 25 Then
                f_ini = f_ini.AddMonths(-1)
            End If
            Dim f_fin As DateTime = f_ini.AddMonths(1).AddDays(-1)

            cp_cuota_inicial_fecha_inicio.SelectedDate = f_ini
            cp_cuota_inicial_fecha_fin.SelectedDate = f_fin
        Else
            cp_cuota_inicial_fecha_inicio.SelectedValue = Nothing
            cp_cuota_inicial_fecha_fin.SelectedValue = Nothing
        End If
        panel_cuota_inicial.Enabled = Checked
    End Sub
    

    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = item.Text.Equals("Boliviana de Bienes Raices")
        Next
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
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="seguro" reporte="reporte" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Seguro de Desgravamen</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Pagos mensuales:</td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr><td><asp:CheckBox ID="cb_pago_mensual" runat="server" Text="Pagos mensuales" AutoPostBack="true" /></td></tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panel_pago_mensual" runat="server">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td><asp:Label ID="lbl_seguro_periodo" runat="server" Text="Periodo del seguro:"></asp:Label></td>
                                                                    <td><ew:CalendarPopup ID="cp_seguro_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                                    <td>-</td>
                                                                    <td><ew:CalendarPopup ID="cp_seguro_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lbl_pago_periodo" runat="server" Text="Periodo del pago:"></asp:Label></td>
                                                                    <td><ew:CalendarPopup ID="cp_pago_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                                    <td>-</td>
                                                                    <td><ew:CalendarPopup ID="cp_pago_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Cuotas_iniciales:</td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr><td><asp:CheckBox ID="cb_cuota_inicial" runat="server" Text="Cuotas_iniciales" AutoPostBack="true" /></td></tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panel_cuota_inicial" runat="server">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td><asp:Label ID="lbl_cuota_inicial" runat="server" Text="Periodo de la cuota inicial:"></asp:Label></td>
                                                                    <td><ew:CalendarPopup ID="cp_cuota_inicial_fecha_inicio" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                                    <td>-</td>
                                                                    <td><ew:CalendarPopup ID="cp_cuota_inicial_fecha_fin" runat="server" Width="100px" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
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
                                        <td class="formTdEnun">Estado de contratos:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_estado" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Vigentes" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Revertidos" Value="0"></asp:ListItem>
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
                                            <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" Enabled="false">
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
                            <td align="center">
                                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <table width="500" align="center">
                                    <tr>
                                        <td style="width:140px;"></td>
                                        <td align="center"><asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/></td>
                                        <td style="width:140px;" align="right"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteSeguroDesgravamen" />
            </td>
        </tr>
    </table>
</asp:Content>