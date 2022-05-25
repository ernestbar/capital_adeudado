<%@ Control Language="VB" ClassName="busquedaViewRecibo" %>

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
            panel_recibo.Visible = True
            If recibo.numero > 0 Then
                lbl_num_recibo.Text = recibo.numero.ToString()
            Else
                lbl_num_recibo.Text = "No existe"
            End If
            If dosif.fecha.ToString("d") <> "01/01/0001" Then
                lbl_fecha_emision.Text = dosif.fecha.ToString()
            Else
                lbl_fecha_emision.Text = "No existe"
            End If
            If dosif.nombre_cobrador <> "" Then
                lbl_cobrador.Text = dosif.nombre_cobrador
            Else
                lbl_cobrador.Text = "No existe"
            End If
            If recibo.activo = True Then
                lbl_estado.Text = "Recibo Activo"
            Else
                lbl_estado.Text = "Recibo Inactivo"
            End If
        Else
            Msg1.Text = "No se encontró níngún recibo"
            panel_recibo.Visible = False
        End If
        
    End Sub
</script>


<asp:Label ID="lbl_numero" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_recibo" runat="server" Width="100%" GroupingText="Recibo de Cobrador" Visible="false">
<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_num_recibo_enun" runat="server" Text="No. recibo:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_num_recibo" runat="server"></asp:Label></td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_fecha_emision_enun" runat="server" Text="Fecha de emisión:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_fecha_emision" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_cobrador_enun" runat="server" Text="Cobrador:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_cobrador" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_estado_enun" runat="server" Text="Estado:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
    </tr>
</table>
</asp:Panel>