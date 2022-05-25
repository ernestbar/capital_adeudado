<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Seguimiento de Obras" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpReporte/userControl/tpFiltroCarteraVigente.ascx" tagname="tpFiltroCarteraVigente" tagprefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "reporteSeguimiento") Then

            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Function FechaPlanifString() As String
        If cp_fecha_inicio.SelectedValue.HasValue = True And cp_fecha_fin.SelectedValue.HasValue = True Then
            Return "Entre el " & cp_fecha_inicio.SelectedDate.ToString("d") & " y el " & cp_fecha_fin.SelectedDate.ToString("d")
        ElseIf cp_fecha_inicio.SelectedValue.HasValue = True And cp_fecha_fin.SelectedValue.HasValue = False Then
            Return "Desde el " & cp_fecha_inicio.SelectedDate.ToString("d")
        ElseIf cp_fecha_inicio.SelectedValue.HasValue = False And cp_fecha_fin.SelectedValue.HasValue = True Then
            Return "Hasta el " & cp_fecha_fin.SelectedDate.ToString("d")
        Else
            Return ""
        End If
    End Function
    
    
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim fecha_inicio As Date = Date.Parse("01/01/1900")
        Dim fecha_fin As Date = Date.Parse("01/01/2900")
        If cp_fecha_inicio.SelectedValue.HasValue Then
            fecha_inicio = cp_fecha_inicio.SelectedDate
        End If
        If cp_fecha_fin.SelectedValue.HasValue Then
            fecha_fin = cp_fecha_fin.SelectedDate
        End If
        
        Dim reporte As New rpt_seguimiento_obra
        reporte.CargarDatos(cp_fecha.SelectedDate, ddl_localizacion.SelectedItem.Text, rbl_prioridad.SelectedItem.Text, rbl_estado.SelectedItem.Text, FechaPlanifString())
        reporte.DataSource = terrasur.so.so_obraMaestro.Reporte(cp_fecha.SelectedDate, Integer.Parse(ddl_localizacion.SelectedValue), Integer.Parse(rbl_prioridad.SelectedValue), Integer.Parse(rbl_estado.SelectedValue), fecha_inicio, fecha_fin)
        Reporte1.WebView.Report = reporte
    End Sub




    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_localizacion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
    Protected Sub rbl_prioridad_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        rbl_prioridad.Items.Insert(0, New ListItem("Todos", "0"))
        rbl_prioridad.SelectedIndex = 0
    End Sub
    Protected Sub rbl_estado_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        rbl_estado.Items.Insert(0, New ListItem("Todos", "0"))
        rbl_estado.SelectedIndex = 0
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="seguimientoObras" />
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
                                <table align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Fecha de corte:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Localización:</td>
                                        <td class="formTdDato">
                                            <asp:DropDownList ID="ddl_localizacion" runat="server" DataSourceID="ods_lista_localizacion" DataTextField="nombre" DataValueField="id_localizacion" OnDataBound="ddl_localizacion_DataBound">
                                            </asp:DropDownList>
                                            <%--[id_localizacion],[codigo],[nombre],[imagen],[num_urbanizacion],[num_lote],[num_urbanizacion_activa]--%>
                                            <asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Prioridad:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_prioridad" runat="server" DataSourceID="ods_lista_prioridad" DataTextField="nombre" DataValueField="id_prioridad" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnDataBound="rbl_prioridad_DataBound">
                                            </asp:RadioButtonList>
                                            <%--[id_prioridad],[numero],[codigo],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_prioridad" runat="server" TypeName="terrasur.so.so_prioridad" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Estado:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_estado" runat="server" DataSourceID="ods_lista_estado" DataTextField="nombre" DataValueField="id_estado" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnDataBound="rbl_estado_DataBound">
                                            </asp:RadioButtonList>
                                            <%--[id_estado],[orden],[codigo],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_estado" runat="server" TypeName="terrasur.so.so_estadoObra" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">F.Planificada:</td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
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
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteCarteraTerraPlus" />
            </td>
        </tr>
    </table>
</asp:Content>