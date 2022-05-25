<%@ Control Language="VB" ClassName="dosificacionAbm" %>


<script runat="server">
    Private Property id_dosificacion() As Integer
        Get
            Return Integer.Parse(lbl_id_dosificacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_dosificacion.Text = value
        End Set
    End Property
    
    
    Public Sub CargarInsertar()
        Dim dosifObj As New dosificacion()
        dosifObj.RecuperarUltimoNumero()
        txt_desde.Text = (dosifObj.numero_ultimo_recibo + 1).ToString()
        txt_hasta.Text = ""
        cbx_activo.Checked = True
        rbl_negocio.SelectedValue = "bbr"
        txt_desde.ReadOnly = False
        txt_desde.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        Dim dosificacionObj As New dosificacion(Int32.Parse(ddl_cobrador.SelectedValue), True)
        If dosificacionObj.id_dosificacion > 0 Then
            Dim anteriorObj As New dosificacion(dosificacionObj.id_dosificacion)
            If ((anteriorObj.num_recibos_utilizados + anteriorObj.num_recibos_desactivados) < (anteriorObj.total_recibos_dosificados * (Decimal.Parse(ConfigurationManager.AppSettings("cobranzaPorcentajeRecibosUtilizados").ToString) / 100))) Then
                Msg1.Text = "El cobrador no ha utilizado al menos el " & ConfigurationManager.AppSettings("cobranzaPorcentajeRecibosUtilizados").ToString & "% de los recibos de su última dosificación"
                correcto = False
            End If
        End If
        'If Integer.Parse(txt_desde.Text.Trim) < 1000000 Then
        '    Dim dosifObj As New dosificacion()
        '    dosifObj.RecuperarUltimoNumero()
        '    If Integer.Parse(txt_desde.Text.Trim) <= dosifObj.numero_ultimo_recibo Then
        '        Msg1.Text = "El rango de la dosificación es incorrecto pues el último recibo de cobrador es el " & dosifObj.numero_ultimo_recibo
        '        correcto = False
        '    End If
        'End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim id_negocio As Integer
            Dim negObj As New negocio(rbl_negocio.SelectedValue)
            id_negocio = negObj.id_negocio
            Dim dosificacionObj As New dosificacion(Int32.Parse(ddl_cobrador.SelectedValue), Int32.Parse(txt_desde.Text.Trim), Int32.Parse(txt_hasta.Text.Trim), cbx_activo.Checked, id_negocio)
            If dosificacionObj.Insertar() Then
                Msg1.Text = "La dosificación se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "La dosificación NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_dosificacion As Integer)
        id_dosificacion = _Id_dosificacion
        Dim dosificacionObj As New dosificacion(id_dosificacion)
        txt_desde.Text = dosificacionObj.desde.ToString()
        txt_hasta.Text = dosificacionObj.hasta.ToString()
        ddl_cobrador.SelectedValue = dosificacionObj.id_usuario.ToString()
        cbx_activo.Checked = dosificacionObj.activo
        rbl_negocio.SelectedValue = New negocio(dosificacionObj.id_negocio).codigo
        txt_desde.ReadOnly = True
        txt_desde.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        Dim dosificacionObj As New dosificacion(id_dosificacion)
        'If dosificacionObj.dosificaciones_posteriores > 0 And dosificacionObj.hasta <> Int32.Parse(txt_hasta.Text.Trim) Then
        If dosificacionObj.hasta <> Int32.Parse(txt_hasta.Text.Trim) Then
            Msg1.Text = "Existen dosificaciones posteriores a ésta, no es posible la modificación"
            correcto = False
        End If
        If dosificacionObj.num_recibos_utilizados > 0 And cbx_activo.Checked = False Then
            Msg1.Text = "La dosificación tiene recibos utilizados y no puede desactivarse"
            correcto = False
        End If
        If dosificacionObj.num_recibos_utilizados > 0 And ddl_cobrador.SelectedValue <> dosificacionObj.id_usuario Then
            Msg1.Text = "La dosificación tiene recibos utilizados y no puede cambiar al cobrador"
            correcto = False
        End If
        'If dosificacion.VerificarHasta(Int32.Parse(txt_hasta.Text.Trim)) = True Then
        '    Msg1.Text = "El último número de la dosificacion no puede modificarse"
        '    correcto = False
        'End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim dosificacionObj As New dosificacion(Int32.Parse(ddl_cobrador.SelectedValue), Int32.Parse(txt_desde.Text.Trim), Int32.Parse(txt_hasta.Text.Trim), cbx_activo.Checked, New negocio(rbl_negocio.SelectedValue).id_negocio)
            dosificacionObj.id_dosificacion = id_dosificacion
            If dosificacionObj.Actualizar() Then
                Msg1.Text = "Los datos de la dosificación se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos de la dosificación NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Label ID="lbl_id_dosificacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_dosificacion" runat="server" DisplayMode="List" ValidationGroup="dosificacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del dosificacion"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_desde_enun" runat="server" Text="No. del primer recibo (desde):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_desde" runat="server" ></asp:TextBox> <%--SkinID="txtSingleLine100" MaxLength="7"--%>
            <asp:RequiredFieldValidator ID="rfv_desde" runat="server" ControlToValidate="txt_desde" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dosificacion" Text="*" ErrorMessage="Debe introducir el primer número de la dosificación"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_desde" runat="server" Type="Integer"  MinimumValue="0" MaximumValue="9999999" ControlToValidate="txt_desde"  Display="Dynamic" ValidationGroup="dosificacion" SetFocusOnError="true" Text="*" ErrorMessage="El valor desde de la dosificación contiene caracteres inválidos"></asp:RangeValidator>   
            <asp:CompareValidator ID="cp_desde_hasta" runat="server" ErrorMessage="El número del último recibo no puede ser menor al número del primer recibo" ControlToValidate="txt_desde" ControlToCompare="txt_hasta" Operator="LessThanEqual" Type="Integer"  ValidationGroup="dosificacion"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_hasta_enun" runat="server" Text="No. del último recibo (hasta):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_hasta" runat="server" SkinID="txtSingleLine200" MaxLength="7"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_hasta" runat="server" ControlToValidate="txt_hasta" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dosificacion" Text="*" ErrorMessage="Debe introducir el último número de la dosificación"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_hasta" runat="server" Type="Integer"  MinimumValue="0" MaximumValue="9999999" ControlToValidate="txt_hasta"  Display="Dynamic" ValidationGroup="dosificacion" SetFocusOnError="true" Text="*" ErrorMessage="El valor hasta de la dosificación contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
        <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_cobrador_enun" runat="server" Text="Cobrador:"></asp:Label>
        </td>
            <td class="formTdDato">
                <asp:DropDownList ID="ddl_cobrador" runat="server" AutoPostBack="false" DataSourceID="ods_cobrador_lista"
                    DataTextField="nombre_completo" DataValueField="id_usuario">
                </asp:DropDownList>
                <%--[id_localizacion],[nombre]--%>
                <asp:ObjectDataSource ID="ods_cobrador_lista" runat="server" TypeName="terrasur.cobrador"
                    SelectMethod="ListaNoEliminado"></asp:ObjectDataSource>
            </td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_dosificacion_enum" runat="server" Text="Activo"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Text="Dosificación activa"/></td>
    </tr>
    <tr>
        <td class="formTdEnun">Negocio:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_negocio" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Boliviana de Bienes Raices" Value="bbr" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Terrasur" Value="terra"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>