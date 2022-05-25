<%@ Control Language="VB" ClassName="reprogramacionFomrPlanPago" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<script runat="server">  
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
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
    
    Public Sub Reset(ByVal id_planpago_vigente As Integer, ByVal id_contrato As Integer, ByVal id_lote As Integer, ByVal precio_final As Decimal, ByVal cuota_inicial As Decimal, ByVal codigo_moneda As String)
        Dim loteObj As New lote(id_lote)
        lbl_lote.Visible = True
        If id_lote > 0 Then
            lbl_lote.Text = loteObj.nombre_urbanizacion & " / " & loteObj.codigo_manzano & " / " & loteObj.codigo
        Else
            lbl_lote.Text = "Servicio Funerario"
        End If
        Reporte1.Visible = False
        lbl_precio_final.Text = precio_final
        lbl_cuota_inicial.Text = cuota_inicial
        If precio_final = cuota_inicial Then
            txt_num_cuota.Text = "0"
            txt_seguro.Text = "0"
            txt_mantenimiento.Text = "0"
            txt_interes.Text = "0"
            txt_interes_penal.Text = "0"
            txt_cuota_base.Text = "0"
        Else
            If id_planpago_vigente > 0 And id_contrato = 0 Then
                Dim pp As New plan_pago(id_planpago_vigente)
                txt_num_cuota.Text = pp.num_cuotas.ToString()
                txt_seguro.Text = pp.seguro.ToString()
                txt_mantenimiento.Text = pp.mantenimiento_sus.ToString("F2")
                txt_mantenimiento.Enabled = pp.mantenimiento_sus.Equals(0).Equals(False)
                txt_interes.Text = pp.interes_corriente.ToString("F2")
                txt_interes_penal.Text = pp.interes_penal.ToString("F2")
                txt_cuota_base.Text = "0"
                cp_fecha_inicio.SelectedDate = pp.fecha_inicio_plan
                txt_num_cuota.Focus()
            ElseIf id_planpago_vigente = 0 And id_contrato > 0 Then
                Dim c As New contrato(id_contrato)
                txt_num_cuota.Text = c.num_cuotas.ToString()
                txt_seguro.Text = c.seguro.ToString()
                txt_mantenimiento.Text = c.mantenimiento_sus.ToString("F2")
                txt_mantenimiento.Enabled = c.mantenimiento_sus.Equals(0).Equals(False)
                txt_interes.Text = c.interes_corriente.ToString("F2")
                txt_interes_penal.Text = c.interes_penal.ToString("F2")
                txt_cuota_base.Text = "0"
                cp_fecha_inicio.SelectedDate = c.fecha_inicio_plan
                txt_num_cuota.Focus()
            End If
        End If

        lbl_precio_final_enun.Text = "Precio final (" & codigo_moneda & "):"
        lbl_cuota_inicial_enun.Text = "Cuota inicial (" & codigo_moneda & "):"
        lbl_mantenimiento_enun.Text = "(" & codigo_moneda & " mensual)"
        lbl_cuota_base_enun.Text = "Cuota mensual (" & codigo_moneda & "):"
    End Sub
    
   
    Public Function Verificar(ByVal Id_contrato As Integer) As Boolean
        Dim correcto As Boolean = False
        If Page.IsValid Then
            Dim codigo_negocio As String = negocio_contrato.CodigoNegocioPorContrato(Id_contrato)
            If codigo_negocio <> "nafibo" Then
                Dim seguro_correcto As Boolean = True
                If seguro > 0 Then
                    If seguro <> 0.07 Then
                        Msg1.Text = "El seguro de desgravamen no puede ser diferente a 0,07"
                        seguro_correcto = False
                    End If
                    If codigo_negocio <> "bbr" Then
                        Msg1.Text = "Solo esta permitido asignar el seguro de desgravamen a contratos de BBR"
                        seguro_correcto = False
                    End If
                End If
                If seguro_correcto Then
                    Dim estado_id As Integer = contrato.Estado(Id_contrato, DateTime.Now)
                    If estado_id = 1 Then
                        Calcular()
                        If cuota_base > 0 Then
                            correcto = True
                        Else
                            Msg1.Text = "Los parámetros dieron como resultado una cuota mensual de 0, lo cual es incorrecto"
                        End If
                    Else
                        Msg1.Text = "El contrato no se encuentra vigente."
                    End If
                End If
            Else
                Msg1.Text = "No esta permitido Reprogramar un contrato Nafibo"
            End If
        Else
            Msg1.Text = "Existen errores en la página"
        End If
        Return correcto
    End Function

    Protected Sub lb_calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) handles lb_calcular.Click
        Calcular()
    End Sub
    Private Sub Calcular()
        Dim c As New contrato(id_contrato)
        Dim p As New pago(c.id_ultimo_pago)
        If p.id_pago > 0 Then
            txt_cuota_base.Text = simular.Obtener_cuota_base(p.saldo, num_cuotas, seguro, mantenimiento, interes)
        End If
    End Sub
    
    Protected Sub btn_simular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_simular.Click
        
        If cuota_base > 0 Then
            Dim rep As New simulacion
            Reporte1.Visible = True
            Dim c As New contrato(id_contrato)
            Dim cl As New cliente(c.id_titular)
        
            rep.DataSource = contratoReporte.ReportePlanPagosRestante(id_contrato, True, c.id_ultimo_pago, Decimal.Parse(txt_cuota_base.Text.Trim), _
            Integer.Parse(txt_num_cuota.Text.Trim), cp_fecha_inicio.SelectedDate, _
            Decimal.Parse(txt_interes.Text.Trim), Decimal.Parse(txt_seguro.Text.Trim), Decimal.Parse(txt_mantenimiento.Text.Trim))
        
            'rep.DataSource = simular.tabla_plan_simulado(simular.lista_plan_simulado(Decimal.Parse(lbl_precio_final.Text.Trim), _
            '    Decimal.Parse(lbl_cuota_inicial.Text.Trim), Integer.Parse(txt_num_cuota.Text.Trim), 0, _
            '    Decimal.Parse(txt_interes.Text.Trim), Decimal.Parse(txt_seguro.Text.Trim), Decimal.Parse(txt_mantenimiento.Text.Trim), _
            '    cp_fecha_inicio.SelectedDate))
        
            rep.CargarDatos((cl.paterno & " " & cl.materno & " " & cl.nombres).ToString(), cl.ci.Trim, Decimal.Parse(lbl_precio_final.Text.Trim), Decimal.Parse(lbl_cuota_inicial.Text.Trim), Integer.Parse(txt_num_cuota.Text.Trim), 0, _
                Decimal.Parse(txt_interes.Text.Trim), Decimal.Parse(txt_seguro.Text.Trim), Decimal.Parse(txt_mantenimiento.Text.Trim), _
                cp_fecha_inicio.SelectedDate, New moneda(c.codigo_moneda).nombre, c.codigo_moneda)
            Reporte1.WebView.Report = rep
        Else
            Msg1.Text = "Debe calcular una cuota base mayor a 0"
        End If
       
    End Sub
    
    Public Function Insertar(ByVal Id_contrato As Integer) As Boolean
        If Verificar(Id_contrato) Then
            Dim contratoObj As New contrato(Id_contrato)
            Dim planpagoObj As New plan_pago(Id_contrato, contratoObj.id_ultimo_pago, Integer.Parse(txt_num_cuota.Text.Trim), Decimal.Parse(txt_seguro.Text.Trim), Decimal.Parse(txt_mantenimiento.Text.Trim), Decimal.Parse(txt_interes.Text.Trim), New parametro("tasa_mora").valor, Decimal.Parse(txt_cuota_base.Text), cp_fecha_inicio.SelectedDate)
            If planpagoObj.Reprogramar(Profile.id_usuario) Then
                Calcular()
                Msg1.Text = "La reprogramación se guardó correctamente"
                Return True
            Else
                Msg1.Text = "La reprogramación NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
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
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_precio_final_enun" runat="server" Text="Precio final:"></asp:Label></td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_precio_final" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_cuota_inicial_enun" runat="server" Text="Cuota inicial:"></asp:Label></td>
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
                    <td class="contratoFormTdHorEnun">Seguro desgr.<br />(% mensual)</td>
                    <td class="contratoFormTdHorEnun">Mantenimiento<br /><asp:Label ID="lbl_mantenimiento_enun" runat="server" Text="($us mensual)"></asp:Label></td>
                    <td class="contratoFormTdHorEnun">Interés corr.<br />(% anual)</td>
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
                        <asp:TextBox ID="txt_mantenimiento" runat="server" SkinID="txtSingleLine100" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
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
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun"><asp:Label ID="lbl_cuota_base_enun" runat="server" Text="Cuota mensual:"></asp:Label></td>
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
    <tr>
        <td  colspan="2">
            <asp:Button ID="btn_simular" runat="server" SkinID="btnAccion" Text="Simular" Visible="false" CausesValidation="true"
                ValidationGroup="contrato" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td colspan="2">
            <uc2:reporte ID="Reporte1" runat="server" Visible="false" />
        </td>
    </tr>
</table>

