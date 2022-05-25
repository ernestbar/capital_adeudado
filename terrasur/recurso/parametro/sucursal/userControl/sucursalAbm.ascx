<%@ Control Language="VB" ClassName="sucursalAbm" %>

<script runat="server">
    Private Property id_sucursal() As Integer
        Get
            Return Integer.Parse(lbl_id_sucursal.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_sucursal.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        txt_num_sucursal.Text = ""
        txt_nombre.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_lugar.Text = ""
        cb_activo.Checked = True
        txt_num_sucursal.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If sucursal.VerificarNumSucursal(Integer.Parse(txt_num_sucursal.Text), True, 0) = True Then
            Msg1.Text = "El Nº de sucursal pertenece a otra sucursal registrada"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim sucursalObj As New sucursal(Integer.Parse(txt_num_sucursal.Text), txt_nombre.Text.Trim, txt_direccion.Text.Trim, txt_telefono.Text.Trim, txt_lugar.Text.Trim, cb_activo.Checked)
            If sucursalObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "Los datos de la sucursal se guardaron correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "Los datos de la sucursal NO se guardaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_sucursal As Integer)
        id_sucursal = _Id_sucursal
        Dim sucursalObj As New sucursal(id_sucursal, 0)
        txt_num_sucursal.Text = sucursalObj.num_sucursal
        txt_nombre.Text = sucursalObj.nombre
        txt_direccion.Text = sucursalObj.direccion
        txt_telefono.Text = sucursalObj.telefono
        txt_lugar.Text = sucursalObj.lugar
        cb_activo.Checked = sucursalObj.activo
        txt_nombre.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If sucursal.VerificarNumSucursal(Integer.Parse(txt_num_sucursal.Text), False, id_sucursal) = True Then
            Msg1.Text = "El Nº de sucursal pertenece a otra sucursal registrada"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim sucursalObj As New sucursal(id_sucursal, Integer.Parse(txt_num_sucursal.Text), txt_nombre.Text.Trim, txt_direccion.Text.Trim, txt_telefono.Text.Trim, txt_lugar.Text.Trim, cb_activo.Checked)
            If sucursalObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos de la sucursal se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos de la sucursal NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_sucursal" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_sucursal" runat="server" DisplayMode="List" ValidationGroup="sucursal" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de la sucursal"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº de sucursal:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_num_sucursal" runat="server" SkinID="txtSingleLine100" MaxLength="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_num_sucursal" runat="server" ControlToValidate="txt_num_sucursal" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sucursal" Text="*" ErrorMessage="Debe introducir el Nº de sucursal"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nombre:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sucursal" Text="*" ErrorMessage="Debe introducir el nombre de la sucursal"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Dirección:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ControlToValidate="txt_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sucursal" Text="*" ErrorMessage="Debe introducir la dirección de la sucursal"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Teléfono(s):</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_telefono" runat="server" SkinID="txtSingleLine200" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_telefono" runat="server" ControlToValidate="txt_telefono" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sucursal" Text="*" ErrorMessage="Debe introducir el(los) teléfono(s) de la sucursal"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Lugar:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_lugar" runat="server" SkinID="txtSingleLine200" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_lugar" runat="server" ControlToValidate="txt_lugar" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sucursal" Text="*" ErrorMessage="Debe introducir el departamento en el que se encuentra la sucursal"></asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">Activo:</td>
        <td class="formTdDato">
            <asp:CheckBox ID="cb_activo" runat="server" Text="Sucursal activa"/>
        </td>
    </tr>
</table>