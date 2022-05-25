<%@ Control Language="VB" ClassName="lugarCobroAbm" %>

<script runat="server">
    Private Property id_lugarcobro() As Integer
        Get
            Return Integer.Parse(lbl_id_lugarcobro.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_lugarcobro.Text = value
        End Set
    End Property
    
    
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_codigo.ReadOnly = False
        txt_nombre.Text = ""
        cbx_cobrador.Checked = True
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If lugar_cobro.VerificarCodigoNombre(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del lugar de cobro pertenece a otro lugar de cobro registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim lugarcobroObj As New lugar_cobro(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_cobrador.Checked)
            If lugarcobroObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El lugar de cobro se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El lugar de cobro NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_lugarcobro As Integer)
        id_lugarcobro = _Id_lugarcobro
        Dim lugarcobroObj As New lugar_cobro(id_lugarcobro)
        If lugarcobroObj.codigo = "terrasur" Or lugarcobroObj.codigo = "domicilio" Or lugarcobroObj.codigo = "oficina" Then
            txt_codigo.ReadOnly = True
        Else
            txt_codigo.ReadOnly = False
        End If
        'lbl_id_usuario.Text = lugarcobroObj.id_usuario
        txt_codigo.Text = lugarcobroObj.codigo
        txt_nombre.Text = lugarcobroObj.nombre
        cbx_cobrador.Checked = lugarcobroObj.cobrador
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If lugar_cobro.VerificarCodigoNombre(False, id_lugarcobro, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del lugar de cobro pertenece a otro lugar de cobro  registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim lugarcobroObj As New lugar_cobro(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_cobrador.Checked)
            lugarcobroObj.id_lugarcobro = id_lugarcobro
            If lugarcobroObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del lugar de cobro se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del lugar de cobro NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_lugarcobro" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_lugarCobro" runat="server" DisplayMode="List" ValidationGroup="lugarCobro" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del lugar de cobro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lugarCobro" Text="*" ErrorMessage="Debe introducir el código del lugar de cobro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lugarCobro" Text="*" ErrorMessage="El código del lugar de cobro contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:lugarCobro_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del lugar de cobro"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lugarCobro" Text="*" ErrorMessage="Debe introducir el nombre del lugar de cobro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lugarCobro" Text="*" ErrorMessage="El nombre del lugar de cobro contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:lugarCobro_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_cobrador_enum" runat="server" Text="Cobrador"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_cobrador" runat="server" Text="Un cobrador se encarga de la cobranza"/></td>
    </tr>
</table>