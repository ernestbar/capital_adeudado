<%@ Control Language="VB" ClassName="motivoDesactivacionAbm" %>

<script runat="server">
    Private Property id_motivoDesactivacion() As Integer
        Get
            Return Integer.Parse(lbl_id_motivoDesactivacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_motivoDesactivacion.Text = value
        End Set
    End Property
    
    
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If motivo_desactivacion.VerificarCodigoNombre(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del motivo de desactivación pertenece a otro motivo de desactivación  registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim motivoDesactivacionObj As New motivo_desactivacion(txt_codigo.Text.Trim, txt_nombre.Text.Trim)
            If motivoDesactivacionObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El motivo de desactivación se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El motivo de desactivación NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_motivoDesactivacion As Integer)
        id_motivoDesactivacion = _Id_motivoDesactivacion
        Dim motivoDesactivacionObj As New motivo_desactivacion(id_motivoDesactivacion)
        'lbl_id_usuario.Text = motivoReversionObj.id_usuario
        txt_codigo.Text = motivoDesactivacionObj.codigo
        txt_nombre.Text = motivoDesactivacionObj.nombre
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If motivo_desactivacion.VerificarCodigoNombre(False, id_motivoDesactivacion, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del motivo de desactivación pertenece a otro motivo de desactivación  registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim motivoDesactivacionObj As New motivo_desactivacion(txt_codigo.Text.Trim, txt_nombre.Text.Trim)
            motivoDesactivacionObj.id_motivodesactivacion = id_motivoDesactivacion
            If motivoDesactivacionObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del motivo de desactivación se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del motivo de desactivación NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_motivoDesactivacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_motivoDesactivacion" runat="server" DisplayMode="List" ValidationGroup="motivoDesactivacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del motivo de desactivación"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoDesactivacion" Text="*" ErrorMessage="Debe introducir el código del motivo de desactivación"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoDesactivacion" Text="*" ErrorMessage="El código del motivo de desactivación contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:motivoDesactivacion_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del motivo de desactivación"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoDesactivacion" Text="*" ErrorMessage="Debe introducir el nombre del motivo de desactivación"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="motivoDesactivacion" Text="*" ErrorMessage="El nombre del motivo de desactivación contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:motivoDesactivacion_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>