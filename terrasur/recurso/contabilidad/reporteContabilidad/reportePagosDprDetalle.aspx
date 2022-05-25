<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de Pagos en Documento (Detalle)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>


<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reportePagosDprDetalle") Then
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

    Public Sub cargarReporte()
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim reporte As New rpt_pagosDprDetalle()
        reporte.DataSource = contabilidadReporte.ReportePagosDPR(Int32.Parse(ddl_cajero.SelectedValue), cp_desde.SelectedDate, cp_hasta.SelectedDate, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        reporte.Encabezado(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cajero.SelectedValue), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        Reporte1.WebView.Report = reporte
    End Sub


    Protected Sub ddl_cajero_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_cajero.DataBound
        ddl_cajero.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_cajero.SelectedValue = "0"
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        gv_datos.DataBind()
        btn_exportarExcel.Visible = False
        cargarReporte()

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


    Protected Sub lbtn_reportePromocion_Click(sender As Object, e As EventArgs)
        Dim dt As New System.Data.DataTable()
        dt = contabilidadReporte.RerpoteDPRpromocion(cp_desde.SelectedDate, cp_hasta.SelectedDate)
        If dt.Rows.Count > 0 Then
            gv_datos.DataSource = dt
            gv_datos.DataBind()
            btn_exportarExcel.Visible = True
        Else
            gv_datos.DataBind()
            btn_exportarExcel.Visible = False
        End If

    End Sub

    Protected Sub btn_exportarExcel_Click(sender As Object, e As EventArgs)
        Dim responsePage As HttpResponse = Response
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        Dim pageToRender As New Page()
        Dim form As New HtmlForm()
        Dim lab1 As New Label()
        Dim lab2 As New Label()
        lab1.Text = "<br/>REPORTE DPRs PROMOCION CONSOLIDADO EN $us. <br/>"
        lab2.Text = "DEL " & cp_desde.SelectedDate.ToShortDateString & " AL " & cp_hasta.SelectedDate.ToShortDateString & "<br/>Fecha reporte: " & Date.Now.ToShortDateString & "<br/>Usuario: " & Profile.UserName & "<br/><br/>"

        lab1.Font.Bold = True
        lab1.Font.Size = 20
        lab2.Font.Bold = True
        lab2.Font.Size = 14
        form.Controls.Add(lab1)
        form.Controls.Add(lab2)
        form.Controls.Add(gv_datos)
        pageToRender.Controls.Add(form)
        responsePage.Clear()
        responsePage.Buffer = True
        responsePage.ContentType = "application/vnd.ms-excel"
        responsePage.AddHeader("Content-Disposition", "attachment;filename=promocion_reporte.xls")
        responsePage.Charset = "UTF-8"
        responsePage.ContentEncoding = Encoding.Default
        pageToRender.RenderControl(htw)
        responsePage.Write(sw.ToString())
        responsePage.End()
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
 <asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de Pagos en Documento (Detalle)</td>
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
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_desde" runat="server" Text="Desde:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_desde" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                             <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_hasta" runat="server" Text="Hasta:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_hasta" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                         <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_usuario_enun" runat="server" Text="Usuario:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:DropDownList ID="ddl_cajero" runat="server" AutoPostBack="false" DataSourceID="ods_cajero_lista"
                                       DataTextField="nombre_completo" DataValueField="id_usuario">
                                   </asp:DropDownList>
                                   <%--[id_usuario],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_cajero_lista" runat="server" TypeName="terrasur.usuario"
                                       SelectMethod="ListaCajerosNoEliminados"></asp:ObjectDataSource>
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
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte"/>
                                </td>
                               
                            </tr>
                            <tr>
                                 <td class="formEntTdButton" colspan="1">
                                     <asp:LinkButton ID="lbtn_reportePromocion" runat="server" OnClick="lbtn_reportePromocion_Click">REPORTE DPRS PROMOCION CONSOLIDADO EN $us.</asp:LinkButton>
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                 <tr>
                    <td class="tdGrid">
                        <asp:Button ID="btn_exportarExcel" runat="server" Text="Exportar" Visible="false" OnClick="btn_exportarExcel_Click" /><br />
                        <asp:GridView ID="gv_datos" runat="server"></asp:GridView>
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

