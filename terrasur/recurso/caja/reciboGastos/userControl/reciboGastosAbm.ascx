<%@ Control Language="VB" ClassName="reciboGastosAbm" %>

<script runat="server">
    Protected Property id_recibogastos() As Integer
        Get
            Return Integer.Parse(lbl_id_recibogastos.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_recibogastos.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        cp_fecha.SelectedDate = DateTime.Now.Date
        cp_fecha.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "insert_fecha")
        txt_concepto.Text = ""
        txt_entregado.Text = ""
        txt_monto.Text = ""
        rbl_moneda.SelectedValue = "sus"
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If Decimal.Parse(txt_monto.Text.Trim) <= 0 Then
            Msg1.Text = "El monto del recibo debe ser un número positivo"
            correcto = False
        End If
        If cp_fecha.SelectedDate > DateTime.Now.Date Then
            Msg1.Text = "La fecha del recibo no puede ser portero a la fecha actual (" & Date.Now.ToString("d") & ")"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim monto_sus As Decimal = 0
            Dim monto_bs As Decimal = 0
            If rbl_moneda.SelectedValue = "sus" Then
                monto_sus = Decimal.Parse(txt_monto.Text.Trim)
            Else
                monto_bs = Decimal.Parse(txt_monto.Text.Trim)
            End If
            
            Dim rObj As New recibo_gastos(Profile.id_usuario, cp_fecha.SelectedDate, txt_concepto.Text.Trim, txt_entregado.Text.Trim, monto_sus, monto_bs)
            If rObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El recibo de gastos se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El recibo de gastos NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_recibogastos As Integer)
        id_recibogastos = _Id_recibogastos
        Dim rObj As New recibo_gastos(id_recibogastos)

        cp_fecha.SelectedDate = rObj.fecha
        cp_fecha.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "update_fecha")
        txt_concepto.Text = rObj.concepto
        txt_entregado.Text = rObj.entregado
        If rObj.monto_sus > 0 Then
            txt_monto.Text = rObj.monto_sus
            rbl_moneda.SelectedValue = "sus"
        Else
            txt_monto.Text = rObj.monto_bs
            rbl_moneda.SelectedValue = "bs"
        End If
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If Decimal.Parse(txt_monto.Text.Trim) <= 0 Then
            Msg1.Text = "El monto del recibo debe ser un número positivo"
            correcto = False
        End If
        If cp_fecha.SelectedDate > DateTime.Now.Date Then
            Msg1.Text = "La fecha del recibo no puede ser posterior a la fecha actual (" & Date.Now.ToString("d") & ")"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim monto_sus As Decimal = 0
            Dim monto_bs As Decimal = 0
            If rbl_moneda.SelectedValue = "sus" Then
                monto_sus = Decimal.Parse(txt_monto.Text.Trim)
            Else
                monto_bs = Decimal.Parse(txt_monto.Text.Trim)
            End If

            Dim rObj As New recibo_gastos(id_recibogastos, 0, cp_fecha.SelectedDate, txt_concepto.Text.Trim, txt_entregado.Text.Trim, monto_sus, monto_bs)
            If rObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del recibo de gastos se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del recibo de gastos NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

</script>
<asp:Label ID="lbl_id_recibogastos" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_recibo" runat="server" DisplayMode="List" ValidationGroup="recibo" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del Recibo de Gastos"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha" runat="server">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Concepto:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_concepto" runat="server" SkinID="txtSingleLine400" MaxLength="200"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_concepto" runat="server" ControlToValidate="txt_concepto" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir el concepto del recibo"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Entregado a:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_entregado" runat="server" SkinID="txtSingleLine400" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_entregado" runat="server" ControlToValidate="txt_entregado" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir el nombre de la persona a la que se entregó el dinero"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Monto:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txt_monto" runat="server" SkinID="txtSingleLine100" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir el monto del recibo"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="recibo" Text="*"  ErrorMessage="El monto debe ser un número válido" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbl_moneda" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                            <asp:ListItem Text="Dólares ($us)" Value="sus" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Bolivianos (Bs)" Value="bs"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>