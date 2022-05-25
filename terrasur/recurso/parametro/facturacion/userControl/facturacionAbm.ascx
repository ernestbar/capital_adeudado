<%@ Control Language="VB" ClassName="facturacionAbm" %>

<script runat="server">
    Private Property id_parametrofacturacion() As Integer
        Get
            Return Integer.Parse(lbl_id_parametrofacturacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_parametrofacturacion.Text = value
        End Set
    End Property
    Public Sub CargarInsertar()
        id_parametrofacturacion = 0
        If rbl_sucursal.Items.Count = 0 Then
            rbl_sucursal.DataBind()
        End If
        If rbl_sucursal.Items.Count > 0 Then
            rbl_sucursal.SelectedIndex = 0
        End If

        txt_razon_social.Text = ""
        txt_nit.Text = "0"
        txt_fecha.SelectedDate = DateTime.Today
        txt_autorizacion.Text = "0"
        txt_dosificacion.Text = "0"
        txt_num_siguiente.Text = "1"
        
        txt_encab_empresa.Text = ""
        txt_encab_actividad.Text = ""
        txt_encab_direccion.Text = ""
        txt_encab_telefono.Text = ""
        txt_encab_lugar.Text = ""
        
        cbl_negocio.DataBind()
        txt_razon_social.Focus()
    End Sub
    Private Function VerificarInsertar() As Boolean
        If rbl_sucursal.Items.Count > 0 AndAlso rbl_sucursal.SelectedIndex >= 0 Then
            Return Page.IsValid
        Else
            Msg1.Text = "Se deben definir sucursales antes de registrar parámetros de facturación"
            Return False
        End If
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim pObj As New parametro_facturacion(Integer.Parse(rbl_sucursal.SelectedValue), txt_razon_social.Text.Trim, _
            txt_nit.Text.Trim, txt_fecha.SelectedDate, txt_autorizacion.Text.Trim, _
            txt_dosificacion.Text.Trim, Integer.Parse(txt_num_siguiente.Text.Trim), _
            txt_encab_empresa.Text.Trim, txt_encab_actividad.Text.Trim, txt_encab_direccion.Text.Trim, txt_encab_telefono.Text.Trim, txt_encab_lugar.Text.Trim)
            If pObj.Insertar(Profile.id_usuario) Then
                For Each item As ListItem In cbl_negocio.Items
                    parametro_facturacion_negocio.InsertarEliminar(item.Selected, pObj.id_parametrofacturacion, Integer.Parse(item.Value), Profile.id_usuario)
                Next
                Msg1.Text = "Los parámetros de facturación se guardaron correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "Los parámetros de facturación NO se guardaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_parametrofacturacion As Integer)
        Dim pObj As New parametro_facturacion(_Id_parametrofacturacion)
        id_parametrofacturacion = pObj.id_parametrofacturacion
        
        If rbl_sucursal.Items.Count = 0 Then
            rbl_sucursal.DataBind()
        End If
        If rbl_sucursal.Items.Count > 0 Then
            If rbl_sucursal.Items.FindByValue(pObj.id_sucursal) IsNot Nothing Then
                rbl_sucursal.SelectedValue = pObj.id_sucursal
            End If
        End If

        txt_razon_social.Text = pObj.razon_social
        txt_nit.Text = pObj.nit
        txt_fecha.SelectedDate = pObj.fecha_limite
        txt_autorizacion.Text = pObj.num_autorizacion
        txt_dosificacion.Text = pObj.llave_dosificacion
        txt_num_siguiente.Text = pObj.num_siguiente_factura
        
        txt_encab_empresa.Text = pObj.encabezado_empresa
        txt_encab_actividad.Text = pObj.encabezado_actividad
        txt_encab_direccion.Text = pObj.encabezado_direccion
        txt_encab_telefono.Text = pObj.encabezado_telefono
        txt_encab_lugar.Text = pObj.encabezado_lugar
        
        cbl_negocio.DataBind()
        txt_razon_social.Focus()
    End Sub
    Private Function VerificarActualizar() As Boolean
        If rbl_sucursal.Items.Count > 0 AndAlso rbl_sucursal.SelectedIndex >= 0 Then
            Return Page.IsValid
        Else
            Msg1.Text = "Se deben definir sucursales antes de registrar parámetros de facturación"
            Return False
        End If
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim pObj As New parametro_facturacion(id_parametrofacturacion, Integer.Parse(rbl_sucursal.SelectedValue), txt_razon_social.Text.Trim, _
            txt_nit.Text.Trim, txt_fecha.SelectedDate, txt_autorizacion.Text.Trim, _
            txt_dosificacion.Text.Trim, Integer.Parse(txt_num_siguiente.Text.Trim), _
            txt_encab_empresa.Text.Trim, txt_encab_actividad.Text.Trim, txt_encab_direccion.Text.Trim, txt_encab_telefono.Text.Trim, txt_encab_lugar.Text.Trim)
            If pObj.Actualizar(Profile.id_usuario) Then
                For Each item As ListItem In cbl_negocio.Items
                    parametro_facturacion_negocio.InsertarEliminar(item.Selected, id_parametrofacturacion, Integer.Parse(item.Value), Profile.id_usuario)
                Next
                Msg1.Text = "Los parámetros de facturación se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los parámetros de facturación NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Protected Sub rbl_sucursal_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_sucursal.DataBound
        cbl_negocio.DataBind()
    End Sub
    Protected Sub rbl_sucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_sucursal.SelectedIndexChanged
        cbl_negocio.DataBind()
    End Sub

    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        Dim id_sucursal As Integer = 0
        If rbl_sucursal.SelectedIndex >= 0 Then
            id_sucursal = Integer.Parse(rbl_sucursal.SelectedValue)
        End If
        For Each item As ListItem In cbl_negocio.Items
            If id_parametrofacturacion = 0 Then
                If parametro_facturacion_negocio.VerificarNegocioAsignado(id_sucursal, Integer.Parse(item.Value), 0) = True Then
                    item.Enabled = False
                End If
            Else
                If parametro_facturacion_negocio.VerificarNegocioAsignado(id_sucursal, Integer.Parse(item.Value), 0) = True Then
                    If parametro_facturacion_negocio.VerificarNegocioAsignado(id_sucursal, Integer.Parse(item.Value), id_parametrofacturacion) = False Then
                        item.Enabled = False
                    End If
                End If
                item.Selected = parametro_facturacion_negocio.Verificar(id_parametrofacturacion, Integer.Parse(item.Value))
            End If
        Next
    End Sub

</script>

<asp:Label ID="lbl_id_parametrofacturacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_parametrofacturacion" runat="server" DisplayMode="List" ValidationGroup="parametrofacturacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de los parámetros de facturación"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Sucursal:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_sucursal" runat="server" AutoPostBack="true" DataSourceID="ods_sucursal_lista" DataTextField="nombre" DataValueField="id_sucursal" CellSpacing="0" CellPadding="0">
            </asp:RadioButtonList>
            <%--[id_sucursal],[nombre]--%>
            <asp:ObjectDataSource ID="ods_sucursal_lista" runat="server" TypeName="terrasur.sucursal" SelectMethod="ListaParaDDL">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Razón Social:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_razon_social" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_razon_social" runat="server" ControlToValidate="txt_razon_social" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir la Razón Social"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">NIT:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nit" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir el NIT"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="El NIT contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:parametrofacturacion_ExpReg_nit %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha límite de emisión:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="txt_fecha" runat="server" ShowClearDate="true" DisableTextBoxEntry="True"></ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº de autorización:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_autorizacion" runat="server" SkinID="txtSingleLine200" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_autorizacion" runat="server" ControlToValidate="txt_autorizacion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir un número de autorización"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_autorizacion" runat="server" ControlToValidate="txt_autorizacion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="El número de autorización contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:parametrofacturacion_ExpReg_autorizacion %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">Llave de dosificación:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_dosificacion" runat="server" SkinID="txtSingleLine200" MaxLength="256"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_dosificacion" runat="server" ControlToValidate="txt_dosificacion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir una llave de dosificación"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_dosificacion" runat="server" ControlToValidate="txt_dosificacion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="La llave de dosificación contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:parametrofacturacion_ExpReg_dosificacion %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">Nº siguiente factura:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_num_siguiente" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_num_siguiente" runat="server" ControlToValidate="txt_num_siguiente" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir un número de la siguiente factura"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_num_siguiente" runat="server" ControlToValidate="txt_num_siguiente" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="El número de la siguiente factura contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:parametrofacturacion_ExpReg_factura %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Encabezado - Empresa:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_encab_empresa" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_encab_empresa" runat="server" ControlToValidate="txt_encab_empresa" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir la Empresa para el Encabezado"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Encabezado - Actividad:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_encab_actividad" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_encab_actividad" runat="server" ControlToValidate="txt_encab_actividad" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir la Actividad para el Encabezado"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Encabezado - Dirección:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_encab_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_encab_direccion" runat="server" ControlToValidate="txt_encab_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir la Dirección para el Encabezado"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Encabezado - Teléfono:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_encab_telefono" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_encab_telefono" runat="server" ControlToValidate="txt_encab_telefono" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir el Teléfono para el Encabezado"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Encabezado - Lugar:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_encab_lugar" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_encab_lugar" runat="server" ControlToValidate="txt_encab_lugar" Display="Dynamic" SetFocusOnError="true" ValidationGroup="parametrofacturacion" Text="*" ErrorMessage="Debe introducir el Lugar para el Encabezado"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Negocios:</td>
        <td class="formTdDato">
            <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0"></asp:CheckBoxList>
            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista"></asp:ObjectDataSource>
        </td>
    </tr>
</table>