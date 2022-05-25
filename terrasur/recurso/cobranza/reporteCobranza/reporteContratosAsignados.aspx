<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de asignación de contratos a cobradores" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "reporteContratosAsignados") Then
                ddl_cobrador.DataBind()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Public Sub cargarReporte()
        Dim fecha_inicio As DateTime = DateTime.Parse("01/01/1950")
        Dim fecha_fin As DateTime = DateTime.Parse("01/01/2050")
        Dim fecha_cuota_inicial As String
        If cp_inicio.SelectedValue.HasValue = False And cp_fin.SelectedValue.HasValue = False Then
            fecha_cuota_inicial = "Todas"
        ElseIf cp_inicio.SelectedValue.HasValue = True And cp_fin.SelectedValue.HasValue = False Then
            fecha_cuota_inicial = "Desde " & cp_inicio.SelectedDate.ToString("d")
            fecha_inicio = cp_inicio.SelectedDate
        ElseIf cp_inicio.SelectedValue.HasValue = False And cp_fin.SelectedValue.HasValue = True Then
            fecha_cuota_inicial = "Hasta " & cp_fin.SelectedDate.ToString("d")
            fecha_fin = cp_fin.SelectedDate
        Else
            fecha_cuota_inicial = "Entre " & cp_inicio.SelectedDate.ToString("d") & " y " & cp_fin.SelectedDate.ToString("d")
            fecha_inicio = cp_inicio.SelectedDate
            fecha_fin = cp_fin.SelectedDate
        End If

        
        Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
        Dim cmd As DbCommand = db1.GetStoredProcCommand("cobranza_ReporteContratosAsignados")
        cmd.CommandTimeout = Integer.Parse(ConfigurationManager.AppSettings("CommandTimeout"))
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, cp_fecha.SelectedDate)
        db1.AddInParameter(cmd, "fecha_venta_inicio", DbType.DateTime, fecha_inicio)
        db1.AddInParameter(cmd, "fecha_venta_fin", DbType.DateTime, fecha_fin)
        db1.AddInParameter(cmd, "id_cobrador", DbType.Int32, Integer.Parse(ddl_cobrador.SelectedValue))
        db1.AddInParameter(cmd, "en_mora", DbType.Int32, Integer.Parse(rbl_mora.SelectedValue))
        Dim tabla As DataTable = db1.ExecuteDataSet(cmd).Tables(0)
        

        Dim reporte As New rpt_cobranza_contratos_asignados()
        reporte.Encabezado(cp_fecha.SelectedDate, fecha_cuota_inicial, ddl_cobrador.SelectedItem.Text, rbl_mora.SelectedItem.Text)
        reporte.DataSource = tabla
        Reporte1.WebView.Report = reporte
    End Sub
        
    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub

    Protected Sub ddl_cobrador_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_cobrador.DataBound
        ddl_cobrador.Items.Insert(0, New ListItem("Todos", "-1"))
        ddl_cobrador.Items.Insert(1, New ListItem("Sin cobrador", "0"))
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCobranza" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
     <asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de asignación de contratos a cobradores</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdButtonVolver">
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">A la fecha:</td>
                                <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Fecha de venta:</td>
                                <td class="formTdDato">
                                    <table>
                                        <tr>
                                            <td><ew:CalendarPopup ID="cp_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                            <td>-</td>
                                            <td><ew:CalendarPopup ID="cp_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Cobrador:</td>
                                <td class="formTdDato">
                                   <asp:DropDownList ID="ddl_cobrador" runat="server" AutoPostBack="false" DataSourceID="ods_cobrador_lista" DataTextField="nombre_completo" DataValueField="id_usuario">
                                   </asp:DropDownList>
                                   <%--[id_localizacion],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_cobrador_lista" runat="server" TypeName="terrasur.cobrador" SelectMethod="ListaNoEliminado"></asp:ObjectDataSource>
                               </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Contratos:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_mora" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Sin mora" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="En mora" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                               </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte"/>
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                    <uc1:reporte ID="Reporte1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

