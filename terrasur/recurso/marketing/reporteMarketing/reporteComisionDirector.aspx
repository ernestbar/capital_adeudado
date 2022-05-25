<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de comisiones a directores" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/cicloComercialPeriodo.ascx" TagName="cicloComercialPeriodo" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteMarketing", "reporteComisionDirector") Then
                Dim nombre_reporte As String = New permiso("reporteComisionDirector", "reporteMarketing").nombre
                lbl_titulo.Text = nombre_reporte

                cb_registrar.Visible = Profile.entorno.codigo_modulo.Equals("adm")
                cb_registrar.Checked = False
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo
        If cb_registrar.Checked = False Then
            Dim reporte As New rpt_comision_director
            reporte.CargarDatos(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, cb_revertidos.Checked, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
            reporte.DataSource = marketingReporte.ReporteComisionDirector(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, cb_revertidos.Checked, Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
            Reporte1.WebView.Report = reporte
        Else
            If VerificarFechas(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin) = False Then
                Dim tabla As DataTable = marketingReporte.ReporteComisionDirector(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, cb_revertidos.Checked, Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))

                Dim correcto As Boolean = True
                For Each fila As DataRow In tabla.Rows
                    Dim grupo_venta As String = fila("grupo_venta").ToString
                    Dim num_ventas As Integer = Convert.ToInt32(fila("num_ventas"))
                    Dim sum_precio_final As Decimal = Convert.ToDecimal(fila("sum_precio_final"))
                    Dim sum_cuota_inicial As Decimal = Convert.ToDecimal(fila("sum_cuota_inicial"))
                    Dim comision As Decimal = Convert.ToDecimal(fila("comision"))
                    If Registrar(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, grupo_venta, num_ventas, sum_precio_final, sum_cuota_inicial, comision) = False Then
                        correcto = False
                    End If
                Next
                If correcto = True Then
                    Msg1.Text = "Las comisiones se registraron correctamente"

                    Dim reporte As New rpt_comision_director
                    reporte.CargarDatos(CicloComercialPeriodo1.inicio, CicloComercialPeriodo1.fin, cb_revertidos.Checked, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
                    reporte.DataSource = tabla
                    Reporte1.WebView.Report = reporte
                Else
                    Msg1.Text = "Las comisiones NO se registraron correctamente"
                End If
            Else
                Msg1.Text = "Ya existen registros de comisiones de directores en el rango de fechas elegido"
            End If
        End If
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
    
    
    
    Public Function VerificarFechas(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime) As Boolean
        Try
            Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
            Dim cmd As DbCommand = db1.GetStoredProcCommand("comision_director_VerificarFechas")
            cmd.CommandTimeout = Integer.Parse(ConfigurationManager.AppSettings("CommandTimeout"))
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, fecha_inicio)
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, fecha_fin)
            Dim aux As Integer = Convert.ToInt32(db1.ExecuteScalar(cmd))
            If aux = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function
    
    Public Function Registrar(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, _
                                 ByVal grupo As String, ByVal num_ventas As Integer, _
                                 ByVal volumen_ventas As Decimal, ByVal cuota_inicial As Decimal, _
                                 ByVal comision As Decimal) As Boolean
        Try
            Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
            Dim cmd As DbCommand = db1.GetStoredProcCommand("comision_director_Registrar")
            cmd.CommandTimeout = Integer.Parse(ConfigurationManager.AppSettings("CommandTimeout"))
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, fecha_inicio)
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, fecha_fin)
            db1.AddInParameter(cmd, "grupo", DbType.String, grupo)
            db1.AddInParameter(cmd, "num_ventas", DbType.Int32, num_ventas)
            db1.AddInParameter(cmd, "volumen_ventas", DbType.Decimal, volumen_ventas)
            db1.AddInParameter(cmd, "cuota_inicial", DbType.Decimal, cuota_inicial)
            db1.AddInParameter(cmd, "comision", DbType.Decimal, comision)
            db1.ExecuteNonQuery(cmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteMarketing" reporte="reporteComisionDirector" />
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
                                        <td class="formTdEnun">Contratos revertidos:</td>
                                        <td class="formTdDato"><asp:CheckBox ID="cb_revertidos" runat="server" Enabled="false" Text="Incluir contratos Revertidos" Checked="true" /></td>
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:CheckBox ID="cb_registrar" runat="server" Text="Guardar comisiones" />
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteComisionDirector" />
            </td>
        </tr>
    </table>
</asp:Content>

