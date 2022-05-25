<%@ Control Language="VB" ClassName="busquedaViewDosificacion" %>

<script runat="server">
    Public Property numero_recibo() As Integer
        Get
            Return Integer.Parse(lbl_numero.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_numero.Text = value.ToString()
            CargarDatos()
        End Set
    End Property
    Private Sub CargarDatos()
        Dim recibo As New recibo_cobrador(0, numero_recibo)
        Dim dosif As New dosificacion(recibo.id_dosificacion)
        If recibo.id_recibocobrador > 0 Then
            panel_dosificacion.Visible = True
            If dosif.desde > 0 Then
                lbl_desde.Text = dosif.desde.ToString()
            Else
                lbl_desde.Text = "No existe"
            End If
            If dosif.hasta > 0 Then
                lbl_hasta.Text = dosif.hasta.ToString()
            Else
                lbl_hasta.Text = "No existe"
            End If
            If dosif.fecha.ToString("d") <> "01/01/0001" Then
                lbl_fecha_emision.Text = dosif.fecha.ToString()
            Else
                lbl_fecha_emision.Text = "No existe"
            End If
            If dosif.activo = True Then
                lbl_estado.Text = "Dosificación Activa"
            Else
                lbl_estado.Text = "Dosificación Inactiva"
            End If
            lbl_negocio.Text = New negocio(dosif.id_negocio).nombre
        Else
            panel_dosificacion.Visible = False
        End If
        
    End Sub
</script>

<asp:Label ID="lbl_numero" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_dosificacion" runat="server" Width="100%" GroupingText="Dosificación del recibo" Visible="false">
<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_desde_enun" runat="server" Text="Desde:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_desde" runat="server"></asp:Label></td>
    </tr>
        <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_hasta_enun" runat="server" Text="Hasta:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_hasta" runat="server"></asp:Label></td>
    </tr>

     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_fecha_emision_enun" runat="server" Text="Fecha de emisión:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_fecha_emision" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_estado_enun" runat="server" Text="Estado:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">Negocio:</td>
        <td class="formTdDato"><asp:Label ID="lbl_negocio" runat="server"></asp:Label></td>
    </tr>
</table>
</asp:Panel>
