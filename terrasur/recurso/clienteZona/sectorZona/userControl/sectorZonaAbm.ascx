<%@ Control Language="VB" ClassName="sectorZonaAbm" %>

<script runat="server">
    Private Property id_sector() As Integer
        Get
            Return Integer.Parse(lbl_id_sector.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_sector.Text = value
        End Set
    End Property
    
    
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If sector_zona.VerificarCodigo(True, 0, txt_codigo.Text.Trim) = True Then
            Msg1.Text = "El Código del sector pertenece a otro sector registrado"
            correcto = False
        End If
        If sector_zona.VerificarNombre(True, 0, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Nombre del sector pertenece a otro sector registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim sectorObj As New sector_zona(txt_codigo.Text.Trim, txt_nombre.Text.Trim)
            If sectorObj.Insertar Then
                Msg1.Text = "El sector se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El sector NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    
    Public Sub CargarActualizar(ByVal _Id_sector As Integer)
        id_sector = _Id_sector
        Dim sectorObj As New sector_zona(id_sector)
        txt_codigo.Text = sectorObj.codigo
        txt_nombre.Text = sectorObj.nombre
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If sector_zona.VerificarCodigo(False, id_sector, txt_codigo.Text.Trim) = True Then
            Msg1.Text = "El Código del sector pertenece a otro sector registrado"
            correcto = False
        End If
        If sector_zona.VerificarNombre(False, id_sector, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Nombre del sector pertenece a otro sector registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim sectorObj As New sector_zona(id_sector, txt_codigo.Text.Trim, txt_nombre.Text.Trim)
            If sectorObj.Actualizar Then
                Msg1.Text = "Los datos del sector se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del sector NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_sector" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_sector" runat="server" DisplayMode="List" ValidationGroup="sector" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del sector"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sector" Text="*" ErrorMessage="Debe introducir el código del sector"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sector" Text="*" ErrorMessage="El código del sector contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:sectorZona_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del sector"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sector" Text="*" ErrorMessage="Debe introducir el nombre del sector"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="sector" Text="*" ErrorMessage="El nombre del sector contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:sectorZona_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>
