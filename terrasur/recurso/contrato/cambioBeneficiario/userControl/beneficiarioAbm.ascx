<%@ Control Language="VB" ClassName="beneficiarioAbm" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar(ByVal _id_contrato As Integer)
        id_contrato = _id_contrato
        'Dim bf As New beneficiario_factura(id_contrato)
        'txt_cliente.Text = bf.nombre
        'txt_nit.Text = bf.nit
        txt_cliente.Text = ""
        txt_nit.Text = ""
        txt_cliente.Focus()
    End Sub
    
    Public Function VerificarInsertar() As Boolean
        Return Page.IsValid
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim bf As New beneficiario_factura(id_contrato, txt_cliente.Text.Trim, txt_nit.Text.Trim)
            If bf.Asignar() Then
                Msg1.Text = "El nuevo beneficiario se registró correctamente"
                Return True
            Else
                Msg1.Text = "El nuevo beneficiario NO se registró correctamente"
                Return False
            End If
        Else
            Msg1.Text = "El nuevo beneficiario NO se registró correctamente"
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_beneficiario" runat="server" DisplayMode="List" ValidationGroup="beneficiario" />
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nombre</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtCajaCobroClienteNombre" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el Apellido Paterno del cliente para la emisión de la factura" ValidationGroup="beneficiario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre del beneficiario de la factura contiene caracteres inválidos" ValidationGroup="beneficiario"></asp:RegularExpressionValidator>
        </td>
   </tr>
   <tr>
        <td class="formTdEnun">NIT</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nit" runat="server" SkinID="txtCajaCobroClienteNit" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el NIT del cliente para la emisión de la factura" ValidationGroup="beneficiario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos" ValidationGroup="beneficiario"></asp:RegularExpressionValidator>
        </td>
   </tr>
</table>
