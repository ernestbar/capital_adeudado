<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte Auxiliar para Bancarización" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteBancarizacion") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        Dim casas_edif As String = ConfigurationManager.AppSettings("negocios_casas")
        For Each item As ListItem In cbl_negocio.Items
            'item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(False)
            item.Selected = False
        Next
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub

    Protected Sub btn_txt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_txt.Click
        Dim sb As StringBuilder = BancarizacionTxt(cp_desde.SelectedDate, cp_hasta.SelectedDate, general.StringNegocios(True, cbl_negocio.Items))
        
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "text/plain"
        Response.AddHeader("Content-Disposition", "attachment;filename=bancarizacion_" & cp_desde.SelectedDate.ToString("ddMMyyyy") & "_" & cp_hasta.SelectedDate.ToString("ddMMyyyy") & ".txt")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString().TrimEnd(";").Replace(";", vbNewLine))
        Response.End()
    End Sub
    
    Public Sub cargarReporte()
        Dim reporte As New rpt_bancarizacion()
        reporte.DataSource = contabilidadReporte.Bancarizacion(cp_desde.SelectedDate, cp_hasta.SelectedDate, general.StringNegocios(True, cbl_negocio.Items))
        reporte.CargarDatos(cp_desde.SelectedDate, cp_hasta.SelectedDate, general.StringNegocios(False, cbl_negocio.Items), Profile.nombre_persona)
        Reporte1.WebView.Report = reporte
    End Sub

    Protected Function BancarizacionTxt(ByVal Fecha_pago_inicio As DateTime, ByVal Fecha_pago_fin As DateTime, ByVal Id_negocio As String) As StringBuilder
        Dim resultado As New StringBuilder
        Dim tabla As Data.DataTable = contabilidadReporte.Bancarizacion(Fecha_pago_inicio, Fecha_pago_fin, Id_negocio)
        For Each fila As Data.DataRow In tabla.Rows
            '[modalidad],[fecha_documento],[tipo_transaccion],[numero_documento],[monto_documento],[num_autorizacion],
            '[ci_cliente],[nombre_cliente],
            '[doc_pago_cuenta], [doc_pago_monto], [monto_acumulado], [nit_entidad], [doc_pago_numero], [doc_pago_tipo], [doc_pago_fecha]
            resultado.Append(fila("modalidad").ToString())
            resultado.Append("|" & fila("fecha_documento").ToString())
            resultado.Append("|" & fila("tipo_transaccion").ToString())
            resultado.Append("|" & fila("numero_documento").ToString())
            resultado.Append("|" & Decimal.Parse(fila("monto_documento").ToString()).ToString("F2").Replace(",", "."))
            resultado.Append("|" & fila("num_autorizacion").ToString())
            resultado.Append("|" & fila("ci_cliente").ToString())
            resultado.Append("|" & fila("nombre_cliente").ToString())
            resultado.Append("|" & fila("doc_pago_cuenta").ToString())
            resultado.Append("|" & Decimal.Parse(fila("doc_pago_monto").ToString()).ToString("F2").Replace(",", "."))
            resultado.Append("|" & Decimal.Parse(fila("monto_acumulado").ToString()).ToString("F2").Replace(",", "."))
            resultado.Append("|" & fila("nit_entidad").ToString())
            resultado.Append("|" & fila("doc_pago_numero").ToString())
            resultado.Append("|" & fila("doc_pago_tipo").ToString())
            resultado.Append("|" & fila("doc_pago_fecha").ToString())
            resultado.Append(";")
        Next
        Return resultado
    End Function
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
 <asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte Auxiliar para Bancarización</td>
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
                                <td class="formTdEnun">Periodo:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_desde" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                    -
                                    <ew:CalendarPopup ID="cp_hasta" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_negocio" runat="server" Text="Negocio:"></asp:Label></td>
                                <td class="formTdDato">
                                    <%--<asp:DropDownList ID="ddl_negocio" runat="server" AutoPostBack="false" DataSourceID="ods_negocio_lista"
                                        DataTextField="nombre" DataValueField="id_negocio" OnDataBound="ddl_negocio_DataBound" >
                                    </asp:DropDownList>--%>
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" AutoPostBack="false" DataSourceID="ods_negocio_lista" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                    <%--[id_lote],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte"/>
                                   <asp:Button ID="btn_txt" runat="server" SkinID="btnAccion" Text="Descargar TXT" />
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

