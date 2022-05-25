<%@ Control Language="VB" ClassName="observacionAbm" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        Dim contratoObj As New contrato(id_contrato)
        txt_observacion.Text = contratoObj.observacion
    End Sub
    
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        'Dim contratoObj As New contrato_venta(id_contrato)
        'Dim contrato_p4n As New contrato_paquete4n(id_contrato.ToString())
        'Dim paquete4n_nuevo As New paquete4n(Int32.Parse(ddl_nuevo_paquete.SelectedValue))
        'contrato_p4n.num_cenizas_inhumadas
        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim contratoObj As New contrato(id_contrato, txt_observacion.Text)
            If contratoObj.ActualizarObservacion() Then
                Msg1.Text = "La observación se guardó correctamente"
                Return True
            Else
                Msg1.Text = "La observación NO se guardó correctamente"
                Return False
            End If
        Else
            Msg1.Text = "La observación NO se guardó correctamente"
            Return False
        End If
    End Function

    
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_dosificacion" runat="server" DisplayMode="List" ValidationGroup="dosificacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_observacion_enun" runat="server" Text="Observaciones:"></asp:Label>
        </td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" SkinID="txtMultiLine300x3"></asp:TextBox>
            </td>
   </tr>
</table>