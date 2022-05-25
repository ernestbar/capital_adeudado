<%@ Control Language="VB" ClassName="reporte" %>

<script runat="server">


    Public Property WebView() As WebViewer
        Get
            Return WebViewer1
        End Get
        Set(ByVal value As WebViewer)
            WebViewer1 = value
            'panel_view.Enabled = True
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
            'Return rb_web.Visible
        End Get
        Set(ByVal value As Boolean)
            'rb_web.Visible = value
        End Set
    End Property

    Public Property Formato_Text() As Boolean
        Get
            'Return rb_txt.Visible
            Return lb_txt.Visible
        End Get
        Set(ByVal value As Boolean)
            'rb_txt.Visible = value
            lb_txt.Visible = value
        End Set
    End Property
    Public Property Formato_Excel() As Boolean
        Get
            'Return rb_xls.Visible
            Return lb_excel.Visible
        End Get
        Set(ByVal value As Boolean)
            'rb_xls.Visible = value
            lb_excel.Visible = value
        End Set
    End Property
    Public Property Formato_Word() As Boolean
        Get
            'Return rb_doc.Visible
            Return lb_doc.Visible
        End Get
        Set(ByVal value As Boolean)
            'rb_doc.Visible = value
            lb_doc.Visible = value
        End Set
    End Property

    'Protected Sub rbl_formato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_formato.SelectedIndexChanged
    '    Select Case rbl_formato.SelectedValue
    '        Case "html"
    '            'WebViewer1.ViewerType = ViewerType.HtmlViewer
    '            WebViewer1.ViewerType = ViewerType.ActiveXViewer
    '        Case "pdf"
    '            WebViewer1.ViewerType = ViewerType.AcrobatReader
    '        Case "txt"
    '            Dim m_stream As New System.IO.MemoryStream
    '            Dim txtExport1 As New DataDynamics.ActiveReports.Export.Text.TextExport
    '            txtExport1.Encoding = System.Text.Encoding.Default
    '            'txtExport1.PageDelimiter = vbCrLf & "End of Page" & vbCrLf & vbCrLf
    '            txtExport1.SuppressEmptyLines = False
    '            txtExport1.TextDelimiter = " "
    '            txtExport1.Export(WebViewer1.Report.Document, m_stream)
    '            m_stream.Position = 0
    '            Response.ContentType = "text/plain"
    '            'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".txt")
    '            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".txt")
    '            Response.BinaryWrite(m_stream.ToArray())
    '            Response.End()
    '            Response.ClearContent()
    '        Case "xls"
    '            Dim m_stream As New System.IO.MemoryStream
    '            Dim xlsExport1 As New DataDynamics.ActiveReports.Export.Xls.XlsExport
    '            xlsExport1.Export(WebViewer1.Report.Document, m_stream)
    '            m_stream.Position = 0
    '            Response.ContentType = "application/excel"
    '            'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".xls")
    '            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".xls")
    '            Response.BinaryWrite(m_stream.ToArray())
    '            Response.End()
    '            Response.ClearContent()
    '        Case "rtf"
    '            Dim m_stream As New System.IO.MemoryStream
    '            Dim rtfExport1 As New DataDynamics.ActiveReports.Export.Rtf.RtfExport
    '            rtfExport1.Export(WebViewer1.Report.Document, m_stream)
    '            m_stream.Position = 0
    '            Response.ContentType = "application/word"
    '            'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
    '            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
    '            Response.BinaryWrite(m_stream.ToArray())
    '            Response.End()
    '            Response.ClearContent()
    '    End Select
    'End Sub

    'Protected Sub rb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_web.CheckedChanged, rb_pdf.CheckedChanged ', rb_xls.CheckedChanged, rb_txt.CheckedChanged, rb_doc.CheckedChanged
    Protected Sub rb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_pdf.CheckedChanged
        Select Case CType(sender, RadioButton).Text
            Case "Web"
                'WebViewer1.ViewerType = ViewerType.HtmlViewer
                WebViewer1.ViewerType = ViewerType.HtmlViewer
            Case "Pdf"
                WebViewer1.ViewerType = ViewerType.AcrobatReader
                'Case "Texto"
                '    Dim m_stream As New System.IO.MemoryStream
                '    Dim txtExport1 As New DataDynamics.ActiveReports.Export.Text.TextExport
                '    txtExport1.Encoding = System.Text.Encoding.Default
                '    'txtExport1.PageDelimiter = vbCrLf & "End of Page" & vbCrLf & vbCrLf
                '    txtExport1.SuppressEmptyLines = False
                '    'txtExport1.TextDelimiter = " "
                '    txtExport1.TextDelimiter = vbTab
                '    txtExport1.Export(WebViewer1.Report.Document, m_stream)
                '    m_stream.Position = 0
                '    Response.ContentType = "text/plain"
                '    'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".txt")
                '    Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".txt")
                '    Response.BinaryWrite(m_stream.ToArray())
                '    Response.End()
                '    Response.ClearContent()
                'Case "Excel"
                '    Dim m_stream As New System.IO.MemoryStream
                '    Dim xlsExport1 As New DataDynamics.ActiveReports.Export.Xls.XlsExport
                '    xlsExport1.MinColumnWidth = 0.5F
                '    m_stream.Position = 0
                '    xlsExport1.Export(WebViewer1.Report.Document, m_stream)
                '    Response.ContentType = "application/excel"
                '    'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".xls")
                '    Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".xls")
                '    Response.BinaryWrite(m_stream.ToArray())
                '    Response.End()
                '    Response.ClearContent()
                'Case "Word"
                '    Dim m_stream As New System.IO.MemoryStream
                '    Dim rtfExport1 As New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                '    rtfExport1.Export(WebViewer1.Report.Document, m_stream)
                '    m_stream.Position = 0
                '    Response.ContentType = "application/word"
                '    'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
                '    Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
                '    Response.BinaryWrite(m_stream.ToArray())
                '    Response.End()
                '    Response.ClearContent()
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
            'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".xls")
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
            'txtExport1.PageDelimiter = vbCrLf & "End of Page" & vbCrLf & vbCrLf
            txtExport1.SuppressEmptyLines = False
            'txtExport1.TextDelimiter = " "
            txtExport1.TextDelimiter = vbTab
            txtExport1.Export(WebViewer1.Report.Document, m_stream)
            m_stream.Position = 0
            Response.ContentType = "text/plain"
            'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".txt")
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
            'Response.AddHeader("content-disposition", "inline; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
            Response.AddHeader("content-disposition", "attachment; filename=" & NombreReporte.Trim.Replace(" ", "_") & ".rtf")
            Response.BinaryWrite(m_stream.ToArray())
            Response.End()
            Response.ClearContent()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
                If (WebViewer1.Report IsNot Nothing) Or (Session("exp") Is Nothing) Then
            WebViewer1.ClearCachedReport()
            If (Session("estadoCuenta") = "SI") Then
                If (Session("imprimir") = "SI") Then
               
                    WebViewer1.ClearCachedReport()
                    WebViewer1.ViewerType = ViewerType.AcrobatReader
                    rb_pdf.Visible = True
                    lb_excel.Visible = True
                    lb_doc.Visible = True
                Else
                    WebViewer1.ClearCachedReport()
                    WebViewer1.ViewerType = ViewerType.RawHtml

                    rb_pdf.Visible = False
                    lb_excel.Visible = False
                    lb_doc.Visible = False
                End If
            Else
                WebViewer1.ClearCachedReport()
                WebViewer1.ViewerType = ViewerType.AcrobatReader
                rb_pdf.Visible = True
                lb_excel.Visible = True
                lb_doc.Visible = True
            End If
            Session("imprimir") = ""
            Session("estadoCuenta") = ""
        End If
            If (Session("exp") IsNot Nothing) Then
                Session.Remove("exp")
                Session("imprimir") = ""
                Session("estadoCuenta") = ""
        End If
    End Sub
</script>
<asp:Label ID="lbl_nombre_reporte" runat="server" Text="Reporte" Visible="false"></asp:Label>
<asp:Label ID="lbl_aux" runat="server"></asp:Label>


<table align="center">
    <tr>
        <td align="left">
            <%--<asp:Panel ID="panel_view" runat="server" Enabled="false">--%>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:Label ID="lbl_formato_enun" runat="server" Text="Formato del reporte: "></asp:Label></td>
                    <td>
                        <%--<asp:RadioButtonList ID="rbl_formato" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Web" Value="html" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Pdf" Value="pdf"></asp:ListItem>
                            <asp:ListItem Text="Texto" Value="txt"></asp:ListItem>
                            <asp:ListItem Text="Excel" Value="xls"></asp:ListItem>
                            <asp:ListItem Text="Word" Value="rtf"></asp:ListItem>
                        </asp:RadioButtonList>--%>
                        <asp:RadioButton ID="rb_pdf" runat="server" Text="Pdf" GroupName="formato" AutoPostBack="true" Checked="true" />
<%--                        <asp:RadioButton ID="rb_web" runat="server" Text="Web" GroupName="formato" AutoPostBack="true" />
--%>                        <%--<asp:RadioButton ID="rb_txt" runat="server" Text="Texto" GroupName="formato" AutoPostBack="true" />--%>
                        <%--<asp:RadioButton ID="rb_xls" runat="server" Text="Excel" GroupName="formato" AutoPostBack="true" />--%>
                        <%--<asp:RadioButton ID="rb_doc" runat="server" Text="Word" GroupName="formato" AutoPostBack="true" />--%>
                        
                        <asp:LinkButton ID="lb_excel" runat="server" Text="Exportar a Excel"></asp:LinkButton>
                        <asp:LinkButton ID="lb_doc" runat="server" Text="Exportar a Word"></asp:LinkButton>
                        <asp:LinkButton ID="lb_txt" runat="server" Text="Exportar a texto" Visible="false"></asp:LinkButton>
                    </td>
                </tr>
            </table>
            <%--</asp:Panel>--%>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Panel ID="Panel1"  Width="810px" Height="410px" ScrollBars="Auto" runat="server">
            <activereportsweb:webviewer id="WebViewer1" runat="server" Height="400" Width="800" MaxReportRunTime="00:20:00" ViewerType="AcrobatReader"></activereportsweb:webviewer>
             </asp:Panel>

        </td>
    </tr>
</table>
