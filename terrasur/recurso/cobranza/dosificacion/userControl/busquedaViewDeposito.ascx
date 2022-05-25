<%@ Control Language="VB" ClassName="busquedaViewDeposito" %>

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
    Public Property id_transaccion() As Integer
        Get
            Return Integer.Parse(lbl_id_transaccion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_transaccion.Text = value.ToString()
        End Set
    End Property
    Private Sub CargarDatos()
        Dim recibo As New recibo_cobrador(0, numero_recibo)
        If recibo.con_transaccion > 0 Then
            panel_deposito.Visible = True

            Dim codigo_moneda As String = contrato.CodigoMoneda(contrato.IdPorNumero(recibo.numero_contrato))
            lbl_monto_enun.Text = "Monto (" & codigo_moneda & "):"

            If recibo.monto_transaccion > 0 Then
                lbl_monto.Text = recibo.monto_transaccion.ToString("F")
            Else
                lbl_monto.Text = "No existe"
            End If
            If recibo.fecha_transaccion <> "31/12/1899" Then
                lbl_fecha.Text = recibo.fecha_transaccion.ToString()
            Else
                lbl_fecha.Text = "No existe"
            End If
            If recibo.numero_contrato > 0 Then
                lbl_num_contrato.Text = recibo.numero_contrato
            Else
                lbl_num_contrato.Text = "No existe"
            End If
        Else
            panel_deposito.Visible = False
        End If
    End Sub
</script>


<asp:Label ID="lbl_numero" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_transaccion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_deposito" runat="server" Width="100%" GroupingText="Depósito en caja" Visible="false">
    <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto ($us):"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_num_contrato_enun" runat="server" Text="No. contrato:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_num_contrato" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>
