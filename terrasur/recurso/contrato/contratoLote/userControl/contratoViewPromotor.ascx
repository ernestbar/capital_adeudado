<%@ Control Language="VB" ClassName="contratoViewPromotor" %>

<script runat="server">
    
    Public WriteOnly Property id_grupopromotor() As Integer
        Set(ByVal value As Integer)
            If value > 0 Then
                Dim gpObj As New grupo_promotor(value)
                lbl_grupo.Text = gpObj.nombre_grupo
                lbl_promotor.Text = gpObj.nombre_promotor
            Else
                lbl_grupo.Text = "Ninguno"
                lbl_promotor.Text = "Ninguno"
            End If
        End Set
    End Property
</script>
<table class="contratoViewTable" align="left" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdLeft"></td>
        <td class="contratoViewTdEnun">Grupo de venta:</td>
        <td class="contratoViewTdDato"><asp:Label ID="lbl_grupo" runat="server"></asp:Label></td>
        <td class="contratoViewTdEspacio"></td>
        <td class="contratoViewTdEnun">Promotor:</td>
        <td class="contratoViewTdDato"><asp:Label ID="lbl_promotor" runat="server"></asp:Label></td>
    </tr>
</table>
