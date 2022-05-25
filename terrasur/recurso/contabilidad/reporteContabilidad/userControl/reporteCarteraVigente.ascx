<%@ Control Language="VB" ClassName="reporteCarteraVigente" %>

<script runat="server">
    
    
    Public Property WebView() As WebViewer
        Get
            Return WebViewer1
        End Get
        Set(ByVal value As WebViewer)
            WebViewer1 = value
        End Set
    End Property
    Public Property NombreReporte() As String
        Get
            Return lbl_nombre_reporte.Text
        End Get
        Set(ByVal value As String)
            lbl_nombre_reporte.Text = value
        End Set
    End Property
    
    Public Property Formato_Pdf() As Boolean
        Get
            Return rb_pdf.Visible
        End Get
        Set(ByVal value As Boolean)
            rb_pdf.Visible = value
        End Set
    End Property
    
    Public Property Formato_Web() As Boolean
        Get
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Property Formato_Text() As Boolean
        Get
            Return lb_txt.Visible
        End Get
        Set(ByVal value As Boolean)
            lb_txt.Visible = value
        End Set
    End Property
    Public Property Formato_Excel() As Boolean
        Get
            Return lb_excel.Visible
        End Get
        Set(ByVal value As Boolean)
            lb_excel.Visible = value
        End Set
    End Property
    Public Property Formato_Word() As Boolean
        Get
            Return lb_doc.Visible
        End Get
        Set(ByVal value As Boolean)
            lb_doc.Visible = value
        End Set
    End Property


    Protected Sub rb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_pdf.CheckedChanged
        Select Case CType(sender, RadioButton).Text
            Case "Web"
                WebViewer1.ViewerType = ViewerType.HtmlViewer
            Case "Pdf"
                WebViewer1.ViewerType = ViewerType.AcrobatReader
        End Select
    End Sub

    Protected Sub lb_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_excel.Click
        If WebViewer1.Report IsNot Nothing Then
            Session("exp") = 1
            Dim m_stream As New System.IO.MemoryStream
            Dim xlsExport1 As New DataDynamics.ActiveReports.Export.Xls.XlsExport
            xlsExport1.MinColumnWidth = 0.5F
            m_stream.Position = 0
            xlsExport1.AutoRowHeight = True
            xlsExport1.RemoveVerticalSpace = True
            xlsExport1.UseCellMerging = True
            xlsExport1.Export(WebViewer1.Report.Document, m_stream)
            Response.ContentType = "application/excel"
            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".xls")
            Response.BinaryWrite(m_stream.ToArray())
            Response.End()
            Response.ClearContent()
        End If
    End Sub

    Protected Sub lb_txt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_txt.Click
        If WebViewer1.Report IsNot Nothing Then
            Session("exp") = 1
            Dim m_stream As New System.IO.MemoryStream
            Dim txtExport1 As New DataDynamics.ActiveReports.Export.Text.TextExport
            txtExport1.Encoding = System.Text.Encoding.Default
            txtExport1.SuppressEmptyLines = False
            txtExport1.TextDelimiter = vbTab
            txtExport1.Export(WebViewer1.Report.Document, m_stream)
            m_stream.Position = 0
            Response.ContentType = "text/plain"
            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".txt")
            Response.BinaryWrite(m_stream.ToArray())
            Response.End()
            Response.ClearContent()
        End If
    End Sub

    Protected Sub lb_doc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_doc.Click
        If WebViewer1.Report IsNot Nothing Then
            Session("exp") = 1
            Dim m_stream As New System.IO.MemoryStream
            Dim rtfExport1 As New DataDynamics.ActiveReports.Export.Rtf.RtfExport
            rtfExport1.Export(WebViewer1.Report.Document, m_stream)
            m_stream.Position = 0
            Response.ContentType = "application/word"
            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
            Response.BinaryWrite(m_stream.ToArray())
            Response.End()
            Response.ClearContent()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        If (WebViewer1.Report IsNot Nothing) Or (Session("exp") Is Nothing) Then
            WebViewer1.ClearCachedReport()
        End If
        If (Session("exp") IsNot Nothing) Then
            Session.Remove("exp")
        End If
    End Sub
</script>
<asp:Label ID="lbl_nombre_reporte" runat="server" Text="Reporte" Visible="false"></asp:Label>
<asp:Label ID="lbl_aux" runat="server"></asp:Label>
<table align="center">
    <tr>
        <td align="left">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:Label ID="lbl_formato_enun" runat="server" Text="Formato del reporte: "></asp:Label></td>
                    <td>
                        <asp:RadioButton ID="rb_pdf" runat="server" Text="Pdf" GroupName="formato" AutoPostBack="true" Checked="true" />
                        <asp:LinkButton ID="lb_excel" runat="server" Text="Exportar a Excel"></asp:LinkButton>
                        <asp:LinkButton ID="lb_doc" runat="server" Text="Exportar a Word"></asp:LinkButton>
                        <asp:LinkButton ID="lb_txt" runat="server" Text="Exportar a texto" Visible="false"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center">
            <activereportsweb:webviewer id="WebViewer1" runat="server" Height="220" Width="500" MaxReportRunTime="00:20:00" ViewerType="AcrobatReader"></activereportsweb:webviewer>
        </td>
    </tr>
</table>
