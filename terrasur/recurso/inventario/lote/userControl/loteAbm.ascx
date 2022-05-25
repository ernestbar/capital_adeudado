<%@ Control Language="VB" ClassName="loteAbm" %>

<script runat="server">
    Public Property id_lote() As Integer
        Get
            Return Integer.Parse(lbl_id_lote.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_lote.Text = value
        End Set
    End Property
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
    Public Property Enabled_cmv_precio() As Boolean
        Get
            Return Integer.Parse(cmv_precio.Enabled)
        End Get
        Set(ByVal value As Boolean)
            cmv_precio.Enabled = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        lbl_localizacion_enun.Visible = True
        lbl_localizacion.Visible = True
        lbl_urbanizacion.Visible = True
        lbl_manzano.Visible = True
        ddl_urbanizacion.Visible = False
        ddl_manzano.Visible = False
        
        id_localizacion = New urbanizacion(id_urbanizacion).id_localizacion
        Dim loc As New localizacion(id_localizacion)
        Dim urb As New urbanizacion(id_urbanizacion)
        Dim man As New manzano(id_manzano)
        lbl_localizacion.Text = loc.nombre
        lbl_urbanizacion.Text = urb.nombre
        lbl_manzano.Text = man.codigo
        txt_codigo.Text = ""
        txt_superf.Text = ""
        txt_costo.Text = ""
        txt_precio.Text = ""
        txt_propietario.Text = ""
        txt_partida.Text = ""
        cb_con_muro.Checked = False
        cb_con_construccion.Checked = False
        ods_negocio_lista.SelectMethod = "Lista_por_origen"
        ods_negocio_lista.SelectParameters.Clear()
        ods_negocio_lista.SelectParameters.Add("origen", System.TypeCode.Boolean, "True")
        rbl_negocio.Enabled = True
        rbl_negocio.DataBind()
        If rbl_negocio.Items.Count > 0 Then
            rbl_negocio.SelectedIndex = 0
        End If
        txt_codigo.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If lote.VerificarCodigo(True, id_manzano, 0, txt_codigo.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del lote pertenece a otro lote registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim loteObj As New lote(id_manzano, txt_codigo.Text.Trim, txt_superf.Text.Trim, txt_costo.Text.Trim, txt_precio.Text.Trim, txt_propietario.Text.Trim, txt_partida.Text.Trim, cb_con_muro.Checked, cb_con_construccion.Checked)
            If loteObj.Insertar(Integer.Parse(rbl_negocio.SelectedValue), Profile.id_usuario) Then
                Msg1.Text = "El lote se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El lote NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_lote As Integer)
        lbl_localizacion_enun.Visible = False
        lbl_localizacion.Visible = False
        lbl_urbanizacion.Visible = False
        lbl_manzano.Visible = False
        ddl_urbanizacion.Visible = True
        ddl_manzano.Visible = True

        id_lote = _Id_lote
        Dim loteObj As New lote(id_lote)
        Dim negocio_lote As New negocio_lote(loteObj.id_negociolote)
        id_manzano = loteObj.id_manzano
        'lbl_manzano.Text = loteObj.codigo_manzano
        'lbl_localizacion.Text = loteObj.nombre_localizacion
        'lbl_urbanizacion.Text = loteObj.nombre_urbanizacion 
        If ddl_urbanizacion.Items.Count = 0 Then
            ddl_urbanizacion.DataBind()
        End If
        ddl_urbanizacion.SelectedValue = loteObj.id_urbanizacion
        ddl_manzano.DataBind()
        ddl_manzano.SelectedValue = loteObj.id_manzano
        
        txt_codigo.Text = loteObj.codigo
        txt_superf.Text = loteObj.superficie_m2
        txt_costo.Text = loteObj.costo_m2_sus
        txt_precio.Text = loteObj.precio_m2_sus
        txt_propietario.Text = loteObj.anterior_propietario
        txt_partida.Text = loteObj.num_partida
        cb_con_muro.Checked = loteObj.con_muro
        cb_con_construccion.Checked = loteObj.con_construccion
        ods_negocio_lista.SelectMethod = "Lista"
        ods_negocio_lista.SelectParameters.Clear()
        rbl_negocio.Enabled = False
        rbl_negocio.DataBind()
        If rbl_negocio.Items.Count > 0 Then
            rbl_negocio.SelectedValue = negocio_lote.id_negocio
        End If
        txt_codigo.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        'If lote.VerificarCodigo(False, id_manzano, id_lote, txt_codigo.Text.Trim) = True Then
        If lote.VerificarCodigo(False, Integer.Parse(ddl_manzano.SelectedValue), id_lote, txt_codigo.Text.Trim) = True Then
            Msg1.Text = "El Código o nombre del lote pertenece a otro lote registrado"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            'Dim loteObj As New lote(id_manzano, txt_codigo.Text.Trim, txt_superf.Text.Trim, txt_costo.Text.Trim, txt_precio.Text.Trim, txt_propietario.Text.Trim, txt_partida.Text.Trim)
            Dim loteObj As New lote(Integer.Parse(ddl_manzano.SelectedValue), txt_codigo.Text.Trim, txt_superf.Text.Trim, txt_costo.Text.Trim, txt_precio.Text.Trim, txt_propietario.Text.Trim, txt_partida.Text.Trim, cb_con_muro.Checked, cb_con_construccion.Checked)
            loteObj.id_lote = id_lote
            If loteObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del lote se actualizaron correctamente"
            End If
        Else
            Msg1.Text = "Los datos del lote NO se actualizaron correctamente"
            Return False
        End If
    End Function

</script>

<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_manzano" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_lote" runat="server" DisplayMode="List" ValidationGroup="lote" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del lote"></asp:Label>
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
            <asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label>
            <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion"></asp:DropDownList>
            <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                <SelectParameters><asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_manzano" runat="server"></asp:Label>
            <asp:DropDownList ID="ddl_manzano" runat="server" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_manzano" runat="server" ControlToValidate="ddl_manzano" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="Debe elegir el manzano en el cual se encuentra el lote"></asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                <SelectParameters><asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Lote:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_codigo" runat="server" SkinID="txtSingleLine100" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="Debe introducir el código del lote"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ControlToValidate="txt_codigo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="El código del lote contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:lote_ExpReg_codigo %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_superf_enun" runat="server" Text="Superficie M2:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_superf" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_superf" runat="server" ControlToValidate="txt_superf" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_superf" runat="server" Type="Double"  MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_superf"  Display="Dynamic" ValidationGroup="lote" SetFocusOnError="true" Text="*" ErrorMessage="La superficie del lote contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_costo_enun" runat="server" Text="Costo ($us):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_costo" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_costo" runat="server" ControlToValidate="txt_costo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_costo" runat="server" Type="Double"  MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_costo"  Display="Dynamic" ValidationGroup="lote" SetFocusOnError="true" Text="*" ErrorMessage="El costo $us del lote contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_precio_enun" runat="server" Text="Precio ($us):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_precio" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_precio" runat="server" Type="Double"  MinimumValue="0" MaximumValue="999999" ControlToValidate="txt_precio"  Display="Dynamic" ValidationGroup="lote" SetFocusOnError="true" Text="*" ErrorMessage="El precio $us del lote contiene caracteres inválidos"></asp:RangeValidator>   
            <asp:CompareValidator ID="cmv_precio" runat="server" ControlToCompare="txt_costo" ControlToValidate="txt_precio" Operator="GreaterThanEqual" Type="Double" ErrorMessage="El precio ($us) debe ser mayor o igual al costo ($us)" ValidationGroup="lote" /> 
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_propietario_enun" runat="server" Text="Anterior propietario:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_propietario" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RegularExpressionValidator ID="rev_propietario" runat="server" ControlToValidate="txt_propietario" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="El anterior propietario contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:lote_ExpReg_propietario %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_partida_enun" runat="server" Text="No. de partida:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_partida" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
            <asp:RegularExpressionValidator ID="rav_partida" runat="server" ControlToValidate="txt_partida" Display="Dynamic" SetFocusOnError="true" ValidationGroup="lote" Text="*" ErrorMessage="El No. de partida contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:lote_ExpReg_partida %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Construcciones:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr><td><asp:CheckBox ID="cb_con_muro" runat="server" Text="Muro" /></td></tr>
                <tr><td><asp:CheckBox ID="cb_con_construccion" runat="server" Text="Construccion de casa" /></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_negocio_enum" runat="server" Text="Negocio:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_negocio" runat="server" DataSourceID="ods_negocio_lista"
                DataTextField="nombre" DataValueField="id_negocio" RepeatDirection="Horizontal" RepeatColumns="5" RepeatLayout="Flow" /></td>
        <%--[id_negocio],[nombre]--%>
        <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio">
           <%-- SelectMethod="Lista_por_origen">--%>
        <%--<SelectParameters>
                <asp:ControlParameter Name="origen"  ControlID="rbl_negocio" PropertyName="Enabled" Type="Boolean" />            
            </SelectParameters>--%>
        </asp:ObjectDataSource>
    </tr>
</table>