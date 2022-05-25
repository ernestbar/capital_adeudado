<%@ Control Language="VB" ClassName="contratoFormPlanPago" %>

<script runat="server">
    Public ReadOnly Property num_cuotas() As Integer
        Get
            Return Integer.Parse(txt_num_cuota.Text)
        End Get
    End Property
    Public ReadOnly Property seguro() As Decimal
        Get
            Return Decimal.Parse(txt_seguro.Text)
        End Get
    End Property
    Public ReadOnly Property mantenimiento() As Decimal
        Get
            Return Decimal.Parse(txt_mantenimiento.Text)
        End Get
    End Property
    Public ReadOnly Property interes() As Decimal
        Get
            Return Decimal.Parse(txt_interes.Text)
        End Get
    End Property
    Public ReadOnly Property cuota_base() As Decimal
        Get
            Return Decimal.Parse(txt_cuota_base.Text)
        End Get
    End Property
    Public ReadOnly Property fecha_inicio() As Date
        Get
            Return cp_fecha_inicio.SelectedDate
        End Get
    End Property
    Public ReadOnly Property num_seguro() As Integer
        Get
            If txt_num_seguro.Text.Trim = "" Then
                Return 0
            Else
                Dim n As Integer = 0
                If Integer.TryParse(txt_num_seguro.Text.Trim, n) = True Then
                    Return n
                Else
                    Return 0
                End If
            End If
        End Get
    End Property
    
    Public Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            lbl_precio_final_enun.Text = "Precio final (" & value & "):"
            lbl_cuota_inicial_enun.Text = "Cuota inicial (" & value & "):"
            lbl_mantenimiento_enun.Text = "(" & value & " mensual)"
            lbl_cuota_base_enun.Text = "Cuota mensual (" & value & "):"
        End Set
    End Property

    Protected Property codigo_negocio() As String
        Get
            Return lbl_codigo_negocio.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_negocio.Text = value
        End Set
    End Property
    
    
    Public Sub Reset(ByVal id_lote As Integer, ByVal precio_final As Decimal, ByVal cuota_inicial As Decimal)
        Dim loteObj As New lote(id_lote)
        lbl_lote.Text = loteObj.nombre_urbanizacion & " / " & loteObj.codigo_manzano & " / " & loteObj.codigo
        lbl_precio_final.Text = precio_final.ToString("F2")
        lbl_cuota_inicial.Text = cuota_inicial.ToString("F2")
        If precio_final = cuota_inicial Then
            txt_num_cuota.Text = "0"
            txt_seguro.Text = "0"
            txt_mantenimiento.Text = "0"
            txt_interes.Text = "0"
            txt_interes_penal.Text = "0"
            txt_cuota_base.Text = "0"
        Else
            Dim pSeguro As New parametro("tasa_seguro")
            
            txt_num_cuota.Text = ""
            txt_seguro.Text = "0"
            'txt_seguro.Text = pSeguro.valor.ToString
            txt_mantenimiento.Text = "0"
            txt_interes.Text = ""
            txt_interes_penal.Text = New parametro("tasa_mora").valor
            txt_cuota_base.Text = "0"
            txt_num_cuota.Focus()
        End If
        txt_num_seguro.Text = ""
        
        Dim nl_obj As New negocio_lote(loteObj.id_negociolote)
        Dim n_obj As New negocio(nl_obj.id_negocio)
        codigo_negocio = n_obj.codigo
    End Sub
    Public Function Verificar() As Boolean
        Dim correcto As Boolean = True
        
        If Page.IsValid Then
            Calcular()
            If cuota_base = 0 Then
                Msg1.Text = "Los parámetros dieron como resultado una cuota mensual de 0, lo cual es incorrecto"
                correcto = False
            End If
            If cp_fecha_inicio.SelectedDate < DateTime.Now.Date Then
                Msg1.Text = "La fecha de inicio de plan no puede ser anterior a la fecha actual"
                correcto = False
            End If
            Dim fecha_maxima As DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-1)
            If cp_fecha_inicio.SelectedDate > fecha_maxima Then
                Msg1.Text = "La fecha de inicio de plan no puede ser posterior al " & fecha_maxima.ToString("d")
                correcto = False
            End If
            If cp_fecha_inicio.SelectedDate.Day > 28 Then
                Msg1.Text = "La fecha de inicio de plan debe ser anterior del día 29 del mes seleccionado"
                correcto = False
            End If
            
            'Se verifica la asignación del seguro
            If seguro > 0 And num_seguro = 0 Then
                Msg1.Text = "Debe ingresar el Número del formulario de seguro"
                correcto = False
            ElseIf seguro = 0 And num_seguro > 0 Then
                Msg1.Text = "No corresponde la asignación de un Número del formulario de seguro, pues el porcentaje de seguro a cobrar es 0"
                correcto = False
            ElseIf seguro > 0 And num_seguro > 0 Then
                If seguro_provida.VerificarUtilizado(0, num_seguro) = True Then
                    Msg1.Text = "El número de seguro " & num_seguro.ToString & " ya fue utilizado en el contrato " & seguro_provida.Num_contrato_por_seguro(0, num_seguro, False)
                    correcto = False
                End If
            End If
            
            If seguro > 0 Then
                If seguro <> 0.07 Then
                    Msg1.Text = "El seguro de desgravamen no puede ser diferente a 0,07"
                    correcto = False
                End If
            End If
            
            If VerificarPorcentajeInteres() = False Then
                correcto = False
            End If
        Else
            correcto = False
        End If
        
        Return correcto
    End Function

    Protected Sub lb_calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) handles lb_calcular.Click
        Calcular()
    End Sub
    Private Sub Calcular()
        txt_cuota_base.Text = simular.Obtener_cuota_base(Decimal.Parse(lbl_precio_final.Text) - Decimal.Parse(lbl_cuota_inicial.Text), num_cuotas, seguro, mantenimiento, interes)
    End Sub
    
    
    Protected Function VerificarPorcentajeInteres() As Boolean
        Dim correcto As Boolean = False
        If ConfigurationManager.AppSettings("contrato_registro_verificar_interes") = "si" Then
            If codigo_negocio = "terra" Or codigo_negocio = "cea" Or codigo_negocio = "bbr" Or codigo_negocio = "roldan" Or codigo_negocio = "nafibo" Then
                If num_cuotas < 1 Then
                    Msg1.Text = "El número de cuotas no puede ser inferior a 1"
                ElseIf num_cuotas > 240 Then
                    Msg1.Text = "El número de cuotas no puede ser superior a 240"
                Else
                    Dim lim_inf As Integer
                    Dim lim_sup As Integer
                    Dim porcentaje As Decimal
                    If num_cuotas >= 1 And num_cuotas <= 12 Then
                        lim_inf = 1
                        lim_sup = 12
                        porcentaje = 6
                    ElseIf num_cuotas >= 13 And num_cuotas <= 18 Then
                        lim_inf = 13
                        lim_sup = 18
                        porcentaje = 6.5
                    ElseIf num_cuotas >= 19 And num_cuotas <= 30 Then
                        lim_inf = 19
                        lim_sup = 30
                        porcentaje = 7.5
                    ElseIf num_cuotas >= 31 And num_cuotas <= 60 Then
                        lim_inf = 31
                        lim_sup = 60
                        porcentaje = 8
                    ElseIf num_cuotas >= 61 And num_cuotas <= 120 Then
                        lim_inf = 61
                        lim_sup = 120
                        porcentaje = 8.5
                    ElseIf num_cuotas >= 121 And num_cuotas <= 180 Then
                        lim_inf = 121
                        lim_sup = 180
                        porcentaje = 9
                    ElseIf num_cuotas >= 181 And num_cuotas <= 240 Then
                        lim_inf = 181
                        lim_sup = 240
                        porcentaje = 10
                    End If
                
                    If interes = porcentaje Then
                        correcto = True
                    Else
                        Msg1.Text = "Interés INCORRECTO, el porcentaje de interés definido para el rango: " & lim_inf.ToString & " a " & lim_sup.ToString & " cuotas es de " & porcentaje.ToString & "%"
                    End If
                End If
            Else
                correcto = True
            End If
        Else
            correcto = True
        End If
        
        Return correcto
    End Function
    
</script>
<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_negocio" runat="server" Text="" Visible="false"></asp:Label>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun">Lote:</td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_lote" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_precio_final_enun" runat="server" Text="Precio final ($us):"></asp:Label></td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_precio_final" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_cuota_inicial_enun" runat="server" Text="Cuota inicial ($us):"></asp:Label></td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_cuota_inicial" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdHorEnun">Nº cuotas</td>
                    <td class="contratoFormTdHorEnun">Seguro desgrav.<br />(% mensual)</td>
                    <td class="contratoFormTdHorEnun">Mantenimiento<br /><asp:Label ID="lbl_mantenimiento_enun" runat="server" Text="($us mensual)"></asp:Label></td>
                    <td class="contratoFormTdHorEnun">Interés corriente<br />(% anual)</td>
                    <td class="contratoFormTdHorEnun">Interés penal<br />(% mensual)</td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_num_cuota" runat="server" SkinID="txtSingleLine100" MaxLength="3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el número de cuotas"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" MinimumValue="1" MaximumValue="<%$ AppSettings: contrato_max_num_cuotas %>" Type="Integer" Text="*" ErrorMessage="El número de cuotas supera el límite establecido"></asp:RangeValidator> 
                        <asp:CompareValidator ID="cv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Operator="DataTypeCheck" Type="Integer" Text="*" ErrorMessage="Debe introducir un número entero"></asp:CompareValidator>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_seguro" runat="server" SkinID="txtSingleLine100" MaxLength="6" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_seguro" runat="server" ControlToValidate="txt_seguro" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el seguro de desgravamen"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_seguro" runat="server" ControlToValidate="txt_seguro" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" MinimumValue="0" MaximumValue="100" Type="Double" Text="*" ErrorMessage="El seguro de desgravamen debe estar entre 0 y 100"></asp:RangeValidator> 
                        <asp:CompareValidator ID="cv_seguro" runat="server" ControlToValidate="txt_seguro" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_mantenimiento" runat="server" SkinID="txtSingleLine100" Enabled="false" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_mantenimiento" runat="server" ControlToValidate="txt_mantenimiento" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir la cuota de mantenimiento mensual"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_mantenimiento" runat="server" ControlToValidate="txt_mantenimiento" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" MinimumValue="0" MaximumValue="99999" Type="Double" Text="*" ErrorMessage="La cuota de mantenimiento debe estar entre 0 y 99999"></asp:RangeValidator> 
                        <asp:CompareValidator ID="cv_mantenimiento" runat="server" ControlToValidate="txt_mantenimiento" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número entero"></asp:CompareValidator>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_interes" runat="server" SkinID="txtSingleLine100" MaxLength="6" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_interes" runat="server" ControlToValidate="txt_interes" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Text="*" ErrorMessage="Debe introducir el interés corriente anual"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_interes" runat="server" ControlToValidate="txt_interes" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" MinimumValue="0" MaximumValue="100" Type="Double" Text="*" ErrorMessage="El interés corriente debe estar entre 0 y 100"></asp:RangeValidator> 
                        <asp:CompareValidator ID="cv_interes" runat="server" ControlToValidate="txt_interes" Display="Dynamic" SetFocusOnError="true" ValidationGroup="contrato" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_interes_penal" runat="server" SkinID="txtSingleLine100" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="contratoFormTdEnun">Nº form. seguro:</td>
                    <td class="contratoFormTdDato">
                        <asp:TextBox ID="txt_num_seguro" runat="server" SkinID="txtSingleLine100" MaxLength="5"></asp:TextBox>
                        <asp:RangeValidator ID="rv_num_seguro" runat="server" ControlToValidate="txt_num_seguro" Type="Integer" MinimumValue="0" MaximumValue="99999" Display="Dynamic" Text="*" ErrorMessage="Debe digitar un número entero válido" ValidationGroup="contrato"></asp:RangeValidator>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_cuota_base_enun" runat="server" Text="Cuota mensual ($us):"></asp:Label></td>
                    <td class="contratoFormTdDato"><asp:TextBox ID="txt_cuota_base" runat="server" SkinID="txtSingleLine100" Enabled="false"></asp:TextBox></td>
                    <td><asp:LinkButton ID="lb_calcular" runat="server" Text="Calcular" CausesValidation="true" ValidationGroup="contrato"></asp:LinkButton></td>
                </tr>
            </table>
        </td>
        <td>
            <table align="right" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun">Inicio de plan:</td>
                    <td class="contratoFormTdDato"><ew:CalendarPopup ID="cp_fecha_inicio" runat="server"></ew:CalendarPopup></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
