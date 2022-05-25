<%@ Control Language="VB" ClassName="contratoEspecialAbm" %>

<script runat="server">
    Public Sub Reset(ByVal Num_contrato As String, ByVal Especial As Boolean)
        txt_numero.Text = Num_contrato
        txt_observacion.Text = ""
        'txt_numero.Enabled = Especial
        If Especial = True Then
            rbl_especial.SelectedValue = "1"
        Else
            rbl_especial.SelectedValue = "0"
        End If
        txt_numero.Focus()
    End Sub

    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        
        Dim id_contrato As Integer = contrato.IdPorNumero(txt_numero.Text.Trim)
        If id_contrato > 0 Then
            Dim especial As Boolean = rbl_especial.SelectedValue.Equals("1")
            Dim ceObj As New contrato_especial(id_contrato, "")

            If especial = True And ceObj.especial = True Then
                Msg1.Text = "El contrato elegido ya esta registrado en la cartera especial"
                correcto = False
            End If
            If especial = False And ceObj.especial = False Then
                Msg1.Text = "El contrato elegido no esta registrado en la cartera especial"
                correcto = False
            End If
            
        Else
            Msg1.Text = "El número de contrato: " + txt_numero.Text.Trim + " no existe"
            correcto = False
        End If

        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim id_contrato As Integer = contrato.IdPorNumero(txt_numero.Text.Trim)
            Dim especial As Boolean = rbl_especial.SelectedValue.Equals("1")

            Dim ceObj As New contrato_especial(id_contrato, especial, txt_observacion.Text.Trim)
            If ceObj.Insertar(Profile.id_usuario) = True Then
                If especial = True Then
                    Msg1.Text = "El contrato " & txt_numero.Text.Trim & " se agregó a la cartera especial"
                Else
                    Msg1.Text = "El contrato " & txt_numero.Text.Trim & " se retiró de la cartera especial"
                End If
                Reset("", especial)
                Return True
            Else
                If especial = True Then
                    Msg1.Text = "El contrato " & txt_numero.Text.Trim & " NO se agregó a la cartera especial"
                Else
                    Msg1.Text = "El contrato " & txt_numero.Text.Trim & " NO se retiró de la cartera especial"
                End If
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
</script>
<asp:Label ID="lbl_id_contratoespecial" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="5">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Contrato:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_numero" runat="server" MaxLength="7" Width="100"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="rfv_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" Text="*"></asp:RequiredFieldValidator></td>
        <td><asp:RegularExpressionValidator ID="rev_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*"></asp:RegularExpressionValidator></td>
        <td>
            <asp:RadioButtonList ID="rbl_especial" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                <asp:ListItem Text="Especial" Value="1"></asp:ListItem>
                <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
   </tr>
   <tr>
        <td class="formTdEnun">Observación:</td>
        <td class="formTdDato" colspan="4"><asp:TextBox ID="txt_observacion" runat="server" Width="250"></asp:TextBox></td>
   </tr>
</table>



