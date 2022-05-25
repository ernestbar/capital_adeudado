<%@ Control Language="VB" ClassName="otroServicioAbm" %>

<script runat="server">
    Private Property id_servicio() As Integer
        Get
            Return Integer.Parse(lbl_id_servicio.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_servicio.Text = value
        End Set
    End Property
    Public Sub CargarInsertar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        txt_valor.Text = "0"
        cbx_varios.Checked = False
        cbx_facturar.Checked = False
        cbx_liquidacion.Checked = False
        cbx_activo.Checked = True
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If servicio.VerificarCodigoNombre(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del servicio pertenece a otro servicio registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim servicioObj As New servicio(txt_codigo.Text.Trim, txt_nombre.Text.Trim, Decimal.Parse(txt_valor.Text.Trim), cbx_varios.Checked, cbx_facturar.Checked, cbx_liquidacion.Checked, cbx_activo.Checked)
            If servicioObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El servicio se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El servicio NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_servicio As Integer)
        id_servicio = _Id_servicio
        Dim servicioObj As New servicio(id_servicio)
        'lbl_id_usuario.Text = bancoObj.id_usuario
        txt_codigo.Text = servicioObj.codigo
        txt_nombre.Text = servicioObj.nombre
        txt_valor.Text = servicioObj.valor_sus
        cbx_varios.Checked = servicioObj.varios
        cbx_facturar.Checked = servicioObj.facturar
        cbx_liquidacion.Checked = servicioObj.liquidacion
        cbx_activo.Checked = servicioObj.activo
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If servicio.VerificarCodigoNombre(False, id_servicio, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del servicio pertenece a otro servicio registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim servicioObj As New servicio(txt_codigo.Text.Trim, txt_nombre.Text.Trim, Decimal.Parse(txt_valor.Text.Trim), cbx_varios.Checked, cbx_facturar.Checked, cbx_liquidacion.Checked, cbx_activo.Checked)
            servicioObj.id_servicio = id_servicio
            If servicioObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del servicio se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del servicio NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>


<asp:Label ID="lbl_id_servicio" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_servicio" runat="server" DisplayMode="List" ValidationGroup="servicio" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del servicio"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="Debe introducir el código del servicio"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="El código del servicio contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:servicio_ExpReg_codigo %>"></asp:RegularExpressionValidator>--%>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del servicio"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="Debe introducir el nombre del servicio"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="El nombre del servicio contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:servicio_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_valor_enun" runat="server" Text="Valor $us:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor" runat="server" ControlToValidate="txt_valor" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor" runat="server" Type="Double"  MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_valor"  Display="Dynamic" ValidationGroup="servicio" SetFocusOnError="true" Text="*" ErrorMessage="El valor $us de servicio contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_varios_enum" runat="server" Text="Varios"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_varios" runat="server" Text="Se puede pagar por varias unidades o cuotas"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_facturar_enum" runat="server" Text="Facturar"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_facturar" runat="server"  Text="Se factura"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_liquidacion_enum" runat="server" Text="Liquidación"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_liquidacion" runat="server" Text="Parte de la liquidación de un contrato"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_activo_enum" runat="server" Text="Activo:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Text="Servicio activo"/></td>
    </tr>
</table>