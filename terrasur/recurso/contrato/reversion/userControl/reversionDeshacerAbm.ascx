<%@ Control Language="VB" ClassName="reversionDeshacerAbm" %>

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
        Dim r As New reversion(reversion.ReversionNoAnulada(id_contrato))
        txt_dias_mora.Text = r.dias_mora.ToString()
        txt_cuotas_mora.Text = r.cuotas_mora.ToString()
        txt_motivo_reversion.Text = r.motivo_reversion
        txt_fecha_reversion.Text = r.fecha.ToString("d")
        txt_usuario.Text = r.usuario_reversion
    End Sub
   
    
    Public Function VerificarDeshacer() As Boolean
        Dim correcto As Boolean = True
        Dim c As New contrato(id_contrato)
        If c.venta_lote = True Then
            'verificar que el estado del lote sea disponible
            Dim c_v As New contrato_venta(c.id_contrato)
            Dim l As New lote(c_v.id_lote)
            Dim es As New estado(New estado_lote(l.id_estadolote).id_estado)
            If es.codigo = "dis" Then
                'Verificar el negocio del lote
                Dim n_c As New negocio_contrato(c.id_negociocontrato)
                Dim n_l As New negocio_lote(l.id_negociolote)
                If n_c.id_negocio = n_l.id_negocio Then
                    correcto = True
                Else
                    Msg1.Text = "El negocio del lote ha cambiado."
                    correcto = False
                End If
            Else
                Msg1.Text = "El lote del contrato no se encuentra disponible."
                correcto = False
            End If
        End If
        Return correcto
    End Function
    
    Public Function Deshacer() As Boolean
        If VerificarDeshacer() Then
            Dim r As New reversion(reversion.ReversionNoAnulada(id_contrato))
            'La reversión
            If r.Deshacer(r.id_reversion, Profile.id_usuario) Then
                Msg1.Text = "La reversión se deshizo correctamente"
                Return True
            Else
                Msg1.Text = "La reversión NO se deshizo correctamente"
                Return False
            End If
        Else
            Msg1.Text = "La reversión NO se guardó correctamente"
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
            <asp:Label ID="lbl_dias_mora_enun" runat="server" Text="No. días de mora:"></asp:Label>
        </td>
            <td class="formTdDato">
                <asp:Label ID="txt_dias_mora" runat="server" Text=""></asp:Label>
            </td>
   </tr>
   <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_cuotas_mora_enun" runat="server" Text="No. cuotas en mora:"></asp:Label>
        </td>
            <td class="formTdDato">
                 <asp:Label ID="txt_cuotas_mora" runat="server" Text=""></asp:Label>
            </td>
   </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_motivo_reversion_enun" runat="server" Text="Motivo de reversión:"></asp:Label>
        </td>
        <td class="formTdDato">
             <asp:Label ID="txt_motivo_reversion" runat="server" Text=""></asp:Label>
        </td>
   </tr>
   <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_fecha_reversion_enun" runat="server" Text="Fecha de reversión:"></asp:Label>
        </td>
        <td class="formTdDato">
             <asp:Label ID="txt_fecha_reversion" runat="server" Text=""></asp:Label>
        </td>
   </tr>
      <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_usuario_enun" runat="server" Text="Usuario (reversión):"></asp:Label>
        </td>
        <td class="formTdDato">
             <asp:Label ID="txt_usuario" runat="server" Text=""></asp:Label>
        </td>
   </tr>

</table>
