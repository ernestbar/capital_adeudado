<%@ Control Language="VB" ClassName="recursoMaster" %>

<script runat="server">
    Public Property recurso() As String
        Get
            Return lbl_rec.Text
        End Get
        Set(ByVal value As String)
            lbl_rec.Text = value
            If String.IsNullOrEmpty(value) = False AndAlso String.IsNullOrEmpty(reporte) = True Then
                Dim rec As New recurso(value)
                hl_recurso.Text = rec.nombre
                If Not String.IsNullOrEmpty(rec.nombre_gruporecurso) Then
                    lbl_gruporecurso.Text = "(" & rec.nombre_gruporecurso & ")"
                End If
                AsignarLink()
            End If
        End Set
    End Property
    Public Property reporte() As String
        Get
            Return lbl_per.Text
        End Get
        Set(ByVal value As String)
            lbl_per.Text = value
            If String.IsNullOrEmpty(value) = False AndAlso String.IsNullOrEmpty(recurso) = True Then
                Dim per As New permiso((value.Split(","))(0), (value.Split(","))(1))
                hl_recurso.Text = per.nombre
                If Not String.IsNullOrEmpty(per.recurso_nombre) Then
                    lbl_gruporecurso.Text = "(" & per.recurso_nombre & ")"
                End If
                AsignarLink()
            End If
        End Set
    End Property
    Public Property MostrarLink() As Boolean
        Get
            Return Boolean.Parse(lbl_link.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_link.Text = value
            AsignarLink()
        End Set
    End Property
    Protected Sub AsignarLink()
        If MostrarLink = True And String.IsNullOrEmpty(hl_recurso.NavigateUrl) = True Then
            If String.IsNullOrEmpty(recurso) = False Then
                hl_recurso.NavigateUrl = "~/recurso/" & New recurso(recurso).codigo_gruporecurso & "/" & recurso & "/Default.aspx"
            ElseIf String.IsNullOrEmpty(reporte) = False Then
                Dim rec As New recurso((reporte.Split(","))(1))
                hl_recurso.NavigateUrl = "~/recurso/" & rec.codigo_gruporecurso & "/reporte" & rec.codigo_gruporecurso & "/" & (reporte.Split(","))(0) & ".aspx"
            End If
        End If
    End Sub
</script>
<asp:Label ID="lbl_rec" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lbl_per" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lbl_link" runat="server" Text="False" Visible="false"></asp:Label>
<table class="masterRecursoTable" align="right" cellpadding="0" cellspacing="0">
    <tr>
        <td class="masterRecursoTdRecurso" colspan="2">
            <asp:HyperLink ID="hl_recurso" runat="server" SkinID="hlMasterRecurso"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="masterRecursoTdEspacio"></td>
        <td class="masterRecursoTdGrupo">
            <asp:Label ID="lbl_gruporecurso" runat="server"></asp:Label>
        </td>
    </tr>
</table>
