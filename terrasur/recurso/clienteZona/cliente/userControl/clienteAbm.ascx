<%@ Control Language="VB" ClassName="clienteAbm" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteFormDato.ascx" TagName="clienteFormDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteFormDireccion.ascx" TagName="clienteFormDireccion" TagPrefix="uc2" %>

<script runat="server">
    Private Property id_cliente() As Integer
        Get
            Return Integer.Parse(lbl_id_cliente.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_cliente.Text = value
        End Set
    End Property

    
    Public Sub CargarInsertar()
        cdato.Reset()
        cdir.Reset()
        rbl_transitorio.SelectedValue = "False"
        rbl_transitorio.Visible = False
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If cdato.RevisarDatos(0) = False Then
            correcto = False
        End If
        If cdir.RevisarDirecciones = False Then
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        Dim clienteObj As New cliente(cdato.id_lugarcedula, cdir.id_lugarcobro, cdato.ci, cdato.nit, _
        cdato.nombres, cdato.paterno, cdato.materno, cdato.fecha_nacimiento, cdato.celular, cdato.fax, _
        cdato.email, cdato.casilla, cdir.domicilio_direccion, cdir.domicilio_fono, cdir.domicilio_id_zona, _
        cdir.oficina_direccion, cdir.oficina_fono, cdir.oficina_id_zona, False)
        If clienteObj.Insertar(Profile.id_usuario) Then
            Msg1.Text = "Los datos del cliente se guardaron correctamente"
            CargarInsertar()
            Return True
        Else
            Msg1.Text = "Los datos del cliente NO se guardaron correctamente"
            Return False
        End If
    End Function
    
    
    Public Sub CargarActualizar(ByVal _Id_cliente As Integer)
        id_cliente = _Id_cliente
        cdato.RecuperarDatos(id_cliente)
        cdir.RecuperarDatos(id_cliente)
        rbl_transitorio.SelectedValue = cdato.transitorio.ToString
        rbl_transitorio.Visible = cdato.transitorio
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If cdato.RevisarDatos(id_cliente) = False Then
            correcto = False
        End If
        If cdir.RevisarDirecciones = False Then
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        Dim clienteObj As New cliente(id_cliente, cdato.id_lugarcedula, cdir.id_lugarcobro, cdato.ci, cdato.nit, _
        cdato.nombres, cdato.paterno, cdato.materno, cdato.fecha_nacimiento, cdato.celular, cdato.fax, _
        cdato.email, cdato.casilla, cdir.domicilio_direccion, cdir.domicilio_fono, cdir.domicilio_id_zona, _
        cdir.oficina_direccion, cdir.oficina_fono, cdir.oficina_id_zona, Boolean.Parse(rbl_transitorio.SelectedValue))
        If clienteObj.Actualizar(Profile.id_usuario) Then
            Msg1.Text = "Los datos del cliente se actualizaron correctamente"
            Return True
        Else
            Msg1.Text = "Los datos del cliente NO se actualizaron correctamente"
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdMsg">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="cliente" />
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="Datos personales">
                <uc1:clienteFormDato ID="cdato" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_direccion" runat="server" Width="100%" GroupingText="Direcciones">
                <uc2:clienteFormDireccion ID="cdir" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:RadioButtonList ID="rbl_transitorio" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Cliente Permanente" Value="False"></asp:ListItem>
                <asp:ListItem Text="Cliente Transitorio" Value="True"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
