<%@ Control Language="VB" ClassName="motivoReversionAbml" %>

<script runat="server">
    Private Property id_motivoReversion() As Integer
        Get
            Return Integer.Parse(lbl_id_motivoReversion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_motivoReversion.Text = value
        End Set
    End Property
    
    
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_codigo.ReadOnly = False
        txt_nombre.Text = ""
        cbx_sistema.Checked = False
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If motivo_reversion.VerificarCodigoNombre(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El C�digo o nombre del motivo de reversi�n pertenece a otro motivo de reversi�n registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim motivoReversionObj As New motivo_reversion(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_sistema.Checked)
            If motivoReversionObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El motivo de reversi�n se guard� correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El motivo de reversi�n NO se guard� correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_motivoReversion As Integer)
        id_motivoReversion = _Id_motivoReversion
        Dim motivoReversionObj As New motivo_reversion(id_motivoReversion)
        'lbl_id_usuario.Text = motivoReversionObj.id_usuario
        If motivoReversionObj.codigo = "preasignacion" Or motivoReversionObj.codigo = "fuerza" Or motivoReversionObj.codigo = "mora" Then
            txt_codigo.ReadOnly = True
        Else
            txt_codigo.ReadOnly = False
        End If
        txt_codigo.Text = motivoReversionObj.codigo
        txt_nombre.Text = motivoReversionObj.nombre
        cbx_sistema.Checked = motivoReversionObj.sistema
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If motivo_reversion.VerificarCodigoNombre(False, id_motivoReversion, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El C�digo o nombre del motivo de reversi�n pertenece a otro motivo de reversi�n registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim motivoReversionObj As New motivo_reversion(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_sistema.Checked)
            motivoReversionObj.id_motivoreversion = id_motivoReversion
            If motivoReversionObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del motivo de reversi�n se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del motivo de reversi�n NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_motivoReversion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:CheckBox ID="cbx_sistema" runat="server"  checked=false  Visible="false" />
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_motivoReversion" runat="server" DisplayMode="List" ValidationGroup="motivoReversion" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del motivo de reversi�n"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="C�digo:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoReversion" Text="*" ErrorMessage="Debe introducir el c�digo del motivo de reversi�n"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoReversion" Text="*" ErrorMessage="El c�digo del motivo de reversi�n contiene caracteres inv�lidos" ValidationExpression="<%$ AppSettings:motivoReversion_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del motivo de reversi�n"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoReversion" Text="*" ErrorMessage="Debe introducir el nombre del motivo de reversi�n"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoReversion" Text="*" ErrorMessage="El nombre del motivo de reversi�n contiene caracteres inv�lidos" ValidationExpression="<%$ AppSettings:motivoReversion_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>