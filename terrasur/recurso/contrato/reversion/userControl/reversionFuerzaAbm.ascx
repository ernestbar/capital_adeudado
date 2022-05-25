<%@ Control Language="VB" ClassName="reversionFuerzaAbm" %>

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
        txt_dias_mora.Text = logica.NumDiasMora(contratoObj.estado_id, contratoObj.preferencial, New pago(contratoObj.id_ultimo_pago).interes_fecha, Date.Now(), New pago(contratoObj.id_ultimo_pago).saldo)
        txt_cuotas_mora.Text = logica.NumCuotasAdeuda(New pago(contratoObj.id_ultimo_pago).interes_fecha.AddDays(New parametro("plazo_mora").valor), Date.Now())
        ddl_motivo.Items.Clear()
        ddl_motivo.DataBind()
    End Sub
   
    
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        
        Dim cvObj As New contrato_venta(id_contrato)
        Dim tabla_intercambio As Data.DataTable = intercambio.ListaPorLote(cvObj.id_lote)
        If tabla_intercambio.Rows.Count > 0 Then
            Msg1.Text = "No se puede realizar la reversión debido a que el contrato corresponde a un Intercambio"
            correcto = False
        End If
        
        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim c As New contrato(id_contrato)
            Dim r As New reversion(id_contrato, Integer.Parse(ddl_motivo.SelectedValue), Integer.Parse(txt_dias_mora.Text), Integer.Parse(txt_cuotas_mora.Text), c.capital_pagado, c.saldo_capital)
            'La reversión
            If r.Insertar(Profile.id_usuario) Then
                Msg1.Text = "La reversión se guardó correctamente"
                Return True
            Else
                Msg1.Text = "La reversión NO se guardó correctamente"
                Return False
            End If
        Else
            Msg1.Text = "La reversión NO se guardó correctamente"
            Return False
        End If
    End Function

    Protected Sub ddl_motivo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_motivo.DataBound
        'ddl_motivo.Items.Remove(New ListItem(New motivo_reversion("mora").nombre, New motivo_reversion("mora").id_motivoreversion))
        If ddl_motivo.Items.FindByText("Devolución de aportes") IsNot Nothing Then
            ddl_motivo.Items.Remove(ddl_motivo.Items.FindByText("Devolución de aportes"))
        End If
    End Sub

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
            <asp:DropDownList ID="ddl_motivo" runat="server" DataSourceID="ods_motivo_lista" 
                DataTextField="nombre" DataValueField="id_motivoreversion">
            </asp:DropDownList>
            <%--[id_motivodesactivacion],[nombre]--%>
            <asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.motivo_reversion"
                SelectMethod="ListaNoSistema"></asp:ObjectDataSource>
        </td>
   </tr>
</table>
