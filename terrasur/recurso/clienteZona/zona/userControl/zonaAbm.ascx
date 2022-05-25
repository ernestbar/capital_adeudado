<%@ Control Language="VB" ClassName="zonaAbm" %>

<script runat="server">
    Private Property id_zona() As Integer
        Get
            Return Integer.Parse(lbl_id_zona.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_zona.Text = value
        End Set
    End Property
   
    
    Public Sub CargarInsertar(ByVal _Id_sector As Integer)
        ddl_sector.DataBind()
        If _Id_sector > 0 Then
            ddl_sector.SelectedValue = _Id_sector
        End If
        txt_nombre.Text = ""
        txt_nombre.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        If zona.VerificarNombre(True, 0, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El nombre de la zona pertenece a otra zona registrada"
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim zonaObj As New zona(Integer.Parse(ddl_sector.SelectedValue), txt_nombre.Text.Trim)
            If zonaObj.Insertar Then
                Msg1.Text = "La zona se guardó correctamente"
                CargarInsertar(Integer.Parse(ddl_sector.SelectedValue))
                Return True
            Else
                Msg1.Text = "La zona NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
    
    Public Sub CargarActualizar(ByVal _Id_zona As Integer)
        id_zona = _Id_zona
        Dim zonaObj As New zona(id_zona)
        ddl_sector.DataBind()
        ddl_sector.SelectedValue = zonaObj.id_sector
        txt_nombre.Text = zonaObj.nombre
        txt_nombre.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        If zona.VerificarNombre(False, id_zona, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El nombre de la zona pertenece a otra zona registrada"
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim zonaObj As New zona(id_zona, ddl_sector.SelectedValue, txt_nombre.Text.Trim)
            If zonaObj.Actualizar Then
                Msg1.Text = "Los datos de la zona se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos de la zona NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_zona" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_sector" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_zona" runat="server" DisplayMode="List" ValidationGroup="zona" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de la Zona"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_sector_enun" runat="server" Text="Sector de la ciudad:"></asp:Label></td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_sector" runat="server" DataSourceID="ods_sector_lista" DataTextField="nombre" DataValueField="id_sector">
            </asp:DropDownList>
            <%--[id_sector],[codigo],[nombre],[num_zonas]--%>
            <asp:ObjectDataSource ID="ods_sector_lista" runat="server" TypeName="terrasur.sector_zona" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre de la zona:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="zona" Text="*" ErrorMessage="Debe introducir el nombre de la zona"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="zona" Text="*" ErrorMessage="El nombre de la zona contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:zona_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>