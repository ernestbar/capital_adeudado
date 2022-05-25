<%@ Control Language="VB" ClassName="cicloAbm" %>

<script runat="server">
    Private Property id_ciclocomercial() As Integer
        Get
            Return Integer.Parse(lbl_id_ciclocomercial.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_ciclocomercial.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar(ByVal Fecha_referencia As String)
        Dim f As DateTime
        If DateTime.TryParse(Fecha_referencia, f) Then
            cp_inicio.Enabled = False
            f = f.AddDays(1)
        Else
            cp_inicio.Enabled = True
            f = DateTime.Now.Date
        End If
        cp_inicio.SelectedDate = f
        cp_fin.SelectedDate = f.Date.AddMonths(1).AddDays(-1)
        cp_inicio.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If ciclo_comercial.VerificarFechas(True, 0, cp_inicio.SelectedDate, cp_fin.SelectedDate) = True Then
            Msg1.Text = "El intervalo de fechas introducido no es consistente con los ciclos comerciales ya registrados"
            correcto = False
        End If
        If cp_fin.SelectedDate < cp_inicio.SelectedDate Then
            Msg1.Text = "La fecha final no puede ser anterior a la fecha de inicio"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        Dim cicloObj As New ciclo_comercial(cp_inicio.SelectedDate, cp_fin.SelectedDate)
        If cicloObj.Insertar(Profile.id_usuario) Then
            Msg1.Text = "El ciclo comercial se guardó correctamente"
            CargarInsertar(cp_fin.SelectedDate)
            Return True
        Else
            Msg1.Text = "El ciclo comercial NO se guardó correctamente"
            Return False
        End If
    End Function
    
    Public Sub CargarActualizar(ByVal _Id_ciclocomercial As Integer)
        id_ciclocomercial = _Id_ciclocomercial
        Dim cicloObj As New ciclo_comercial(id_ciclocomercial)
        cp_inicio.Enabled = True
        cp_inicio.SelectedDate = cicloObj.inicio
        cp_fin.SelectedDate = cicloObj.fin
        cp_inicio.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If ciclo_comercial.VerificarFechas(False, id_ciclocomercial, cp_inicio.SelectedDate, cp_fin.SelectedDate) = True Then
            Msg1.Text = "El intervalo de fechas introducido no es consistente con los ciclos comerciales ya registrados"
            correcto = False
        End If
        If cp_fin.SelectedDate < cp_inicio.SelectedDate Then
            Msg1.Text = "La fecha final no puede ser anterior a la fecha de inicio"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        Dim cicloObj As New ciclo_comercial(id_ciclocomercial, cp_inicio.SelectedDate, cp_fin.SelectedDate)
        If cicloObj.Actualizar(Profile.id_usuario) Then
            Msg1.Text = "El ciclo comercial se actualizó correctamente"
            Return True
        Else
            Msg1.Text = "El ciclo comercial NO se actualizó correctamente"
            Return False
        End If
    End Function

</script>
<asp:Label ID="lbl_id_ciclocomercial" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_ciclo" runat="server" DisplayMode="List" ValidationGroup="ciclo" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del ciclo comercial"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            Fecha de inicio:
        </td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_inicio" runat="server">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            Fecha final:
        </td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fin" runat="server">
            </ew:CalendarPopup>
            <asp:CompareValidator ID="cv_fin" runat="server" ControlToValidate="cp_fin" ControlToCompare="cp_inicio" Type="Date" Operator="GreaterThanEqual" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ciclo" Text="*" ErrorMessage="La fecha final no puede ser anterior a la fecha de inicio"></asp:CompareValidator>
        </td>
    </tr>
</table>



