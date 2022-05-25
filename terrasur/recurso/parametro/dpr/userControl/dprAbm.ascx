<%@ Control Language="VB" ClassName="dprAbm" %>

<script runat="server">
    Private Property id_dpr() As Integer
        Get
            Return Integer.Parse(lbl_id_dpr.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_dpr.Text = value
        End Set
    End Property
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        cbx_inicial.Checked = False
        cbx_liquidable.Checked = False
        cbx_activo.Checked = True
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If dpr.VerificarCodigoNombre(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del dpr pertenece a otro dpr registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim dprObj As New dpr(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_inicial.Checked, cbx_liquidable.Checked, cbx_activo.Checked)
            If dprObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El dpr se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El dpr NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_dpr As Integer)
        id_dpr = _Id_dpr
        Dim dprObj As New dpr(id_dpr)
        'lbl_id_usuario.Text = bancoObj.id_usuario
        txt_codigo.Text = dprObj.codigo
        txt_nombre.Text = dprObj.nombre
        cbx_inicial.Checked = dprObj.inicial
        cbx_liquidable.Checked = dprObj.liquidable
        cbx_activo.Checked = dprObj.activo
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If dpr.VerificarCodigoNombre(False, id_dpr, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del dpr pertenece a otro dpr registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim dprObj As New dpr(txt_codigo.Text.Trim, txt_nombre.Text.Trim, cbx_inicial.Checked, cbx_liquidable.Checked, cbx_activo.Checked)
            dprObj.id_dpr = id_dpr
            If dprObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del dpr se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del dpr NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_dpr" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_dpr" runat="server" DisplayMode="List" ValidationGroup="dpr" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del dpr"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dpr" Text="*" ErrorMessage="Debe introducir el código del dpr"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dpr" Text="*" ErrorMessage="El código del dpr contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:dpr_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del dpr"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dpr" Text="*" ErrorMessage="Debe introducir el nombre del dpr"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dpr" Text="*" ErrorMessage="El nombre del dpr contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:dpr_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_inicial_enum" runat="server" Text="Inicial"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_inicial" runat="server" Text="Utilizado para pagos iniciales"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_liquidable_enum" runat="server" Text="Liquidable"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_liquidable" runat="server"  Text="Utilizado para descuentos en la liquidación"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_activo_enum" runat="server" Text="Activo"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Text="DPR activo"/></td>
    </tr>
</table>