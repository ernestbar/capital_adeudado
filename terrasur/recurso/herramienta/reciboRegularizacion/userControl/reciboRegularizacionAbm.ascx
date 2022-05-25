<%@ Control Language="VB" ClassName="reciboRegularizacionAbm" %>

<script runat="server">
    Protected Property id_reciboregularizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_reciboregularizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_reciboregularizacion.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        txt_num_contrato.Text = ""
        txt_monto_sus.Text = ""
        cp_fecha.SelectedDate = DateTime.Now
        txt_concepto.Text = ""
        txt_cliente.Text = ""
        txt_num_contrato.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If contrato.IdPorNumero(txt_num_contrato.Text.Trim) = 0 Then
            Msg1.Text = "El número de contrato (" & txt_num_contrato.Text.Trim & ") no existe"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim rObj As New recibo_regularizacion(contrato.IdPorNumero(txt_num_contrato.Text.Trim), cp_fecha.SelectedDate, Decimal.Parse(txt_monto_sus.Text), txt_concepto.Text.Trim, txt_cliente.Text)
            If rObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "El recibo se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El recibo NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_reciboregularizacion As Integer)
        id_reciboregularizacion = _Id_reciboregularizacion
        Dim rObj As New recibo_regularizacion(id_reciboregularizacion)
        txt_num_contrato.Text = rObj.num_contrato
        txt_monto_sus.Text = rObj.monto_sus.ToString
        cp_fecha.SelectedDate = rObj.fecha
        txt_concepto.Text = rObj.concepto
        txt_cliente.Text = rObj.cliente
        txt_num_contrato.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If contrato.IdPorNumero(txt_num_contrato.Text.Trim) = 0 Then
            Msg1.Text = "El número de contrato (" & txt_num_contrato.Text.Trim & ") no exixte"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim rObj As New recibo_regularizacion(id_reciboregularizacion, contrato.IdPorNumero(txt_num_contrato.Text.Trim), cp_fecha.SelectedDate, Decimal.Parse(txt_monto_sus.Text), txt_concepto.Text.Trim, txt_cliente.Text)
            If rObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "Los datos del recibo se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del recibo NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_reciboregularizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_recibo" runat="server" DisplayMode="List" ValidationGroup="recibo" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del recibo"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº contrato:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir número de contrato"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="El número de contrato debe ser un número válido" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Monto (en la moneda del contrato):</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_monto_sus" runat="server" SkinID="txtSingleLine100" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_monto_sus" runat="server" ControlToValidate="txt_monto_sus" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir el monto del recibo"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cv_monto_sus" runat="server" ControlToValidate="txt_monto_sus" Display="Dynamic" ValidationGroup="recibo" Text="*"  ErrorMessage="El monto debe ser un número válido" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
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
            <asp:TextBox ID="txt_concepto" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_concepto" runat="server" ControlToValidate="txt_concepto" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir el concepto del recibo"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Cliente:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir el nombre del cliente"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>