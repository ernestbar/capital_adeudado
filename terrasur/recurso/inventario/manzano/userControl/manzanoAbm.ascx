<%@ Control Language="VB" ClassName="manzanoAbm" %>

<script runat="server">
    Public Property id_manzano() As Integer
        Get
            Return Integer.Parse(lbl_id_manzano.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_manzano.Text = value
        End Set
    End Property
    Public Property id_urbanizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_urbanizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_urbanizacion.Text = value
        End Set
    End Property
    Public Property id_localizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_localizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_localizacion.Text = value
        End Set
    End Property
    Public Sub CargarInsertar()
        Dim loc As New localizacion(id_localizacion)
        Dim urb As New urbanizacion(id_urbanizacion)
        lbl_localizacion.Text = loc.nombre
        lbl_urbanizacion.Text = urb.nombre_completo
        txt_codigo.Text = ""
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If manzano.VerificarCodigo(True, id_urbanizacion, 0, txt_codigo.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del manzano pertenece a otro manzano registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim manzanoObj As New manzano(id_urbanizacion, txt_codigo.Text.Trim)
            If manzanoObj.Insertar() Then
                Msg1.Text = "El manzano se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El manzano NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_manzano As Integer)
        id_manzano = _Id_manzano
        Dim manzanoObj As New manzano(id_manzano)
        Dim urb As New urbanizacion(manzanoObj.id_urbanizacion)
        Dim loc As New localizacion(urb.id_localizacion)
        id_urbanizacion = manzanoObj.id_urbanizacion
        id_localizacion = urb.id_localizacion
        lbl_localizacion.Text = loc.nombre
        lbl_urbanizacion.Text = urb.nombre
        txt_codigo.Text = manzanoObj.codigo
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If manzano.VerificarCodigo(False, id_urbanizacion, id_manzano, txt_codigo.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del manzano pertenece a otro manzano registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim manzanoObj As New manzano(id_urbanizacion, txt_codigo.Text.Trim)
            manzanoObj.id_manzano = id_manzano
            If manzanoObj.Actualizar() Then
                Msg1.Text = "Los datos del manzano se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del manzano NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>


<asp:Label ID="lbl_id_manzano" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_manzano" runat="server" DisplayMode="List" ValidationGroup="manzano" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del manzano"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_localizacion" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_urbanizacion" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Manzano:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="manzano" Text="*" ErrorMessage="Debe introducir el código del manzano"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="manzano" Text="*" ErrorMessage="El código del manzano contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:manzano_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>