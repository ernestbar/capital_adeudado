<%@ Control Language="VB" ClassName="clienteCriterio" %>

<script runat="server">
    Public Sub Reset()
        txt_ci.Text = ""
        txt_paterno.Text = ""
        txt_materno.Text = ""
        txt_nombres.Text = ""
        txt_contrato.Text = ""
        txt_ci.Focus()
    End Sub
    
    Public Function TieneCriterio() As Boolean
        If txt_ci.Text.Trim <> "" Then
            Return True
        ElseIf txt_paterno.Text.Trim <> "" Then
            Return True
        ElseIf txt_materno.Text.Trim <> "" Then
            Return True
        ElseIf txt_nombres.Text.Trim <> "" Then
            Return True
        ElseIf txt_contrato.Text.Trim <> "" Then
            Return True
        End If
        txt_ci.Focus()
        Return False
    End Function
    
    Public ReadOnly Property ci() As String
        Get
            Return txt_ci.Text.Trim
        End Get
    End Property
    Public ReadOnly Property paterno() As String
        Get
            Return txt_paterno.Text.Trim
        End Get
    End Property
    Public ReadOnly Property materno() As String
        Get
            Return txt_materno.Text.Trim
        End Get
    End Property
    Public ReadOnly Property nombres() As String
        Get
            Return txt_nombres.Text.Trim
        End Get
    End Property
    Public ReadOnly Property num_contrato() As String
        Get
            Return txt_contrato.Text.Trim
        End Get
    End Property
</script>
<asp:ValidationSummary ID="vs_criterio" runat="server" DisplayMode="List" ValidationGroup="criterio" />
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdEnun"><asp:Label ID="lbl_ci" runat="server" Text="C.I."></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_paterno" runat="server" Text="Ap.Paterno"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_materno" runat="server" Text="Ap.Materno"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_nombres" runat="server" Text="Nombre"></asp:Label></td>
        <td class="formHorTdEnun"><asp:Label ID="lbl_contrato" runat="server" Text="Nº de contrato"></asp:Label></td>
    </tr>
    <tr>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine100" MaxLength="25"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_paterno" runat="server" ControlToValidate="txt_paterno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido paterno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_paterno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_materno" runat="server" ControlToValidate="txt_materno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El apellido materno contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_materno" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_nombres" runat="server" ControlToValidate="txt_nombres" Display="Dynamic" SetFocusOnError="true" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre contiene caracteres inválidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_nombres" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:RegularExpressionValidator ID="rev_contrato" runat="server" ControlToValidate="txt_contrato" Display="Dynamic" SetFocusOnError="true" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*" ErrorMessage="El Nº de contrato contiene caracteres no permitidos"></asp:RegularExpressionValidator> 
            <asp:TextBox ID="txt_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="25"></asp:TextBox>
        </td>
    </tr>
</table>