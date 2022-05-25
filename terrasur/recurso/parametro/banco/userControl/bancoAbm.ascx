<%@ Control Language="VB" ClassName="bancoAbm" %>

<script runat="server">
    Private Property id_banco() As Integer
        Get
            Return Integer.Parse(lbl_id_banco.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_banco.Text = value
        End Set
    End Property
    
    
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        cbx_activo.Checked = True
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If banco.VerificarCodigoNombre(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del banco pertenece a otro banco registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim bancoObj As New banco(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_activo.Checked)
            If bancoObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El banco se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El banco NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_banco As Integer)
        id_banco = _Id_banco
        Dim bancoObj As New banco(id_banco)
        'lbl_id_usuario.Text = bancoObj.id_usuario
        txt_codigo.Text = bancoObj.codigo
        txt_nombre.Text = bancoObj.nombre
        cbx_activo.Checked = bancoObj.activo
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If banco.VerificarCodigoNombre(False, id_banco, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del banco pertenece a otro banco registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim bancoObj As New banco(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_activo.Checked)
            bancoObj.id_banco = id_banco
            If bancoObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del banco se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del banco NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_banco" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_banco" runat="server" DisplayMode="List" ValidationGroup="banco" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del banco"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="banco" Text="*" ErrorMessage="Debe introducir el código del banco"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="banco" Text="*" ErrorMessage="El código del banco contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:banco_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del banco"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="banco" Text="*" ErrorMessage="Debe introducir el nombre del banco"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="banco" Text="*" ErrorMessage="El nombre del banco contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:banco_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_banco_enum" runat="server" Text="Activo"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Text="Banco activo"/></td>
    </tr>
</table>