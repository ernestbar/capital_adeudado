<%@ Control Language="VB" ClassName="contratoFormVenta" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">
    Public ReadOnly Property precio() As Decimal
        Get
            Return Decimal.Parse(txt_precio.Text)
        End Get
    End Property
    Public ReadOnly Property desc_por() As Decimal
        Get
            If String.IsNullOrEmpty(txt_desc_por.Text.Trim) Then
                txt_desc_por.Text = 0
            End If
            Return Decimal.Parse(txt_desc_por.Text)
        End Get
    End Property
    Public ReadOnly Property desc_sus() As Decimal
        Get
            If String.IsNullOrEmpty(txt_desc_sus.Text.Trim) Then
                txt_desc_sus.Text = 0
            End If
            Return Decimal.Parse(txt_desc_sus.Text)
        End Get
    End Property
    Public ReadOnly Property precio_final() As Decimal
        Get
            Return Decimal.Parse(txt_precio_final.Text)
        End Get
    End Property
    Public ReadOnly Property cuota_inicial() As Decimal
        Get
            Return Decimal.Parse(txt_inicial.Text)
        End Get
    End Property
    Public ReadOnly Property contado() As Boolean
        Get
            Return Boolean.Parse(rbl_contado.SelectedValue)
        End Get
    End Property
    
    Public Property cliente() As String
        Get
            Return txt_cliente.Text.Trim
        End Get
        Set(ByVal value As String)
            txt_cliente.Text = value
        End Set
    End Property
    Public Property nit() As String
        Get
            Return txt_nit.Text.Trim
        End Get
        Set(ByVal value As String)
            txt_nit.Text = value
        End Set
    End Property
    Public ReadOnly Property observacion() As String
        Get
            Return txt_observacion.Text.Trim
        End Get
    End Property
    Public ReadOnly Property preferencial() As Boolean
        Get
            Return Boolean.Parse(rbl_preferencial.SelectedValue)
        End Get
    End Property
    
    ' Req. Capital Adeudado
    Public ReadOnly Property capital_adeudado() As Decimal
        Get
            If String.IsNullOrEmpty(txt_capital_adeudado.Text.Trim) Then
                txt_capital_adeudado.Text = 0
            End If
            Return Decimal.Parse(txt_capital_adeudado.Text)
        End Get
    End Property
    Public ReadOnly Property porcentaje_capital_deudor() As Decimal
        Get
            If String.IsNullOrEmpty(lbl_porcentaje_capital_deudor.Text.Trim) Then
                lbl_porcentaje_capital_deudor.Text = 0
            End If
            Return Decimal.Parse(lbl_porcentaje_capital_deudor.Text)
        End Get
    End Property
    Public ReadOnly Property id_parametro_capital_deudor() As Decimal
        Get
            If String.IsNullOrEmpty(lbl_id_parametro_capital_deudor.Text.Trim) Then
                lbl_id_parametro_capital_deudor.Text = 0
            End If
            Return Decimal.Parse(lbl_id_parametro_capital_deudor.Text)
        End Get
    End Property
    '
    Public Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            lbl_precio_enun.Text = "Precio total (" & value & ")"
            lbl_desc_enun.Text = "Descuento (" & value & ")"
            lbl_precio_final_enun.Text = "Precio final (" & value & ")"
            lbl_inicial_enun.Text = "Cuota inicial (" & value & "):"
        End Set
    End Property
  
    Public Sub Reset(ByVal _precio As Integer)
        txt_precio.Text = _precio
        txt_desc_por.Text = "0"
        txt_desc_sus.Text = "0"
        txt_precio_final.Text = _precio
        rbl_contado.SelectedValue = "false"
        txt_inicial.Enabled = True
        txt_inicial.Text = "0"
        txt_cliente.Text = ""
        txt_nit.Text = ""
        txt_observacion.Text = ""

        rbl_preferencial.SelectedValue = "false"
        rbl_preferencial.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "registrar_preferencial")
        AplicarDescuentos()
        
        ' Req. Capital Adeudado
        chkCapitalAdeudado.Checked = False
        lbl_capital_adeudado.Text = "0"
        pnlCapAdeudado1.Visible = False
        pnlCapAdeudado2.Visible = False
        '
    End Sub
    
    ' Req. Capital Adeudado
    Public Sub ResetCapAdeudado(ByVal _precio As Integer)
        txt_precio.Text = _precio
        txt_desc_por.Text = "0"
        txt_desc_sus.Text = "0"
        rbl_contado.SelectedValue = "false"
        txt_inicial.Enabled = True
        txt_inicial.Text = "0"
        txt_cliente.Text = ""
        txt_nit.Text = ""
        txt_observacion.Text = ""

        rbl_preferencial.SelectedValue = "false"
        rbl_preferencial.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "registrar_preferencial")
        AplicarDescuentos()
        
        chkCapitalAdeudado.Checked = True
        Dim dtCD As DataTable = terrasur.parametro_capital_deudor.ListaActivo()
        Dim porcentajeCapitalDeudor As Decimal = 0
        Dim idParametroCapitalDeudor As Integer = 0
        If dtCD.Rows.Count > 0 Then
            idParametroCapitalDeudor = Decimal.Parse(dtCD.Rows(0)("id_parametrocapitaldeudor"))
            porcentajeCapitalDeudor = Decimal.Parse(dtCD.Rows(0)("pocentaje_capital_deudor"))
        End If
        lbl_id_parametro_capital_deudor.Text = idParametroCapitalDeudor.ToString()
        lbl_porcentaje_capital_deudor.Text = porcentajeCapitalDeudor.ToString()
        lbl_capital_adeudado.Text = "Capital Adeudado (" & porcentajeCapitalDeudor.ToString.Replace(",", ".") & "%)"
        Dim capitalAdeudado As Decimal = Math.Round(_precio * (porcentajeCapitalDeudor / 100), 0)
        txt_capital_adeudado.Text = capitalAdeudado
        txt_precio_final.Text = Math.Round(_precio - capitalAdeudado, 0)
        pnlCapAdeudado1.Visible = True
        pnlCapAdeudado2.Visible = True
    End Sub
    
    Protected Sub chkCapitalAdeudado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCapitalAdeudado.CheckedChanged
        If chkCapitalAdeudado.Checked Then
            txt_capital_adeudado.Text = Math.Round(precio * (porcentaje_capital_deudor / 100), 0)
        Else
            txt_capital_adeudado.Text = "0"
        End If
        AplicarDescuentos()
    End Sub
    '
    
    Public Function Verificar(ByVal Id_lote As Integer) As Boolean
        Dim correcto As Boolean = True
        If Not AplicarDescuentos() Then
            correcto = False
        End If
        If Not VerificarCuotaInicial(Id_lote) Then
            correcto = False
        End If
        Return correcto
    End Function


    Protected Sub lb_aplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_aplicar.Click
        AplicarDescuentos()
    End Sub
    Protected Sub rbl_contado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_contado.SelectedIndexChanged
        AplicarDescuentos()
        If contado = True Then
            txt_inicial.Text = txt_precio_final.Text
        End If
        txt_inicial.Enabled = contado.Equals(False)
    End Sub
    
    Private Function AplicarDescuentos() As Boolean
        If precio > 0 Then
            If desc_sus < 0 Then
                Msg1.Text = "El descuento en efectivo no puede ser nevativo"
                txt_precio_final.Text = Math.Round(precio - (precio * (desc_por / 100)), 0)
                Return False
            ElseIf desc_sus >= Math.Round(precio - (precio * (desc_por / 100)), 0) Then
                Msg1.Text = "El descuento en efectivo debe ser menor al precio final después del descuento en pocentaje"
                txt_precio_final.Text = Math.Round(precio - (precio * (desc_por / 100)), 0)
                Return False
            Else
                
                ' Req. Capital Adeudado
                If capital_adeudado > 0 Then
                    txt_precio_final.Text = Math.Round(precio - capital_adeudado - (precio * (desc_por / 100)) - desc_sus, 0)
                Else
                    txt_precio_final.Text = Math.Round(precio - (precio * (desc_por / 100)) - desc_sus, 0)
                End If
                '
                
                If contado Or cuota_inicial > precio_final Then
                    txt_inicial.Text = txt_precio_final.Text
                    rbl_contado.SelectedValue = "true"
                    txt_inicial.Enabled = False
                End If
                Return True
                End If
        Else
                Return False
        End If
    End Function
    Private Function VerificarCuotaInicial(ByVal Id_lote As Integer) As Boolean
        Dim correcto As Boolean
        
        If cuota_inicial < 0 Then
            Msg1.Text = "La cuota inicial no puede ser nevativa"
            correcto = False
        ElseIf cuota_inicial = 0 Then
            Msg1.Text = "La cuota inicial no puede ser 0"
            correcto = False
        ElseIf cuota_inicial > precio_final Then
            Msg1.Text = "La cuota inicial no puede ser mayor que el precio final"
            correcto = False
        ElseIf cuota_inicial = precio_final Then
            rbl_contado.SelectedValue = "true"
            txt_inicial.Enabled = False
            correcto = True
        ElseIf contado = True AndAlso cuota_inicial < precio_final Then
            Msg1.Text = "La cuota inicial debe ser igual al precio final"
            correcto = False
        Else
            correcto = True
        End If
        
        If correcto = True Then
            Dim codigo_negocio As String = New negocio(New negocio_lote(New lote(Id_lote).id_negociolote).id_negocio).codigo
            Dim tipo_inmueble As String
            If codigo_negocio = "pr_casas" Then
                tipo_inmueble = "casa"
            ElseIf codigo_negocio = "pr_amanecer" Or codigo_negocio = "ed_suiza1" Or codigo_negocio = "pr_edificios" Then
                tipo_inmueble = "dpto"
            ElseIf codigo_negocio = "mercado" Then
                tipo_inmueble = "mercado"
            Else
                tipo_inmueble = "terreno"
            End If
            Dim cuoIni_porcent_min As Decimal = New parametro("cuoIni_porcent_min_" & tipo_inmueble).valor
            If Math.Round(((cuota_inicial / precio_final) * 100), 2) < cuoIni_porcent_min Then
                Msg1.Text = "La cuota inicial no puede ser menor al " & cuoIni_porcent_min.ToString("N2") & "% del precio final"
                correcto = False
            End If
        End If
        
        Return correcto
    End Function
    
    
</script>
<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
<asp:Label ID="lbl_porcentaje_capital_deudor" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_parametro_capital_deudor" runat="server" Text="0" Visible="false"></asp:Label>
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
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_precio_enun" runat="server" Text="Precio total ($us)"></asp:Label></td>
                    <asp:Panel ID="pnlCapAdeudado1" runat="server" Visible="false">
                        <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_capital_adeudado" runat="server" Text="Capital Adeudado"></asp:Label></td>
                        <td class="contratoFormTdHorEnun"></td>
                    </asp:Panel>
                    <td class="contratoFormTdHorEnun">Descuento(%)</td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_desc_enun" runat="server" Text="Descuento($us)"></asp:Label></td>
                    <td class="contratoFormTdHorEnun"></td>
                    <td class="contratoFormTdHorEnun"><asp:Label ID="lbl_precio_final_enun" runat="server" Text="Precio final ($us)"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_precio" runat="server" SkinID="txtSingleLine100" Enabled="false"></asp:TextBox>
                    </td>
                    <asp:Panel ID="pnlCapAdeudado2" runat="server" Visible="false">
                        <td class="contratoFormTdHorDato">
                            <asp:TextBox ID="txt_capital_adeudado" runat="server" SkinID="txtSingleLine100" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="contratoFormTdHorDato">
                            <asp:CheckBox ID="chkCapitalAdeudado" runat="server" Text="Usar Capital Adeudado" AutoPostBack="True" />
                        </td>
                    </asp:Panel>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_desc_por" runat="server" SkinID="txtSingleLine100" Text="0" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_desc_por" runat="server" ControlToValidate="txt_desc_por" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el descuento (en porcentaje)" ValidationGroup="contrato"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_desc_por" runat="server" ControlToValidate="txt_desc_por" Type="Double" MinimumValue="0" MaximumValue="99" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="El descuento debe ser un número positivo (entre 0 y 99)" ValidationGroup="contrato"></asp:RangeValidator>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_desc_sus" runat="server" SkinID="txtSingleLine100" Text="0" MaxLength="7" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_desc_sus" runat="server" ControlToValidate="txt_desc_sus" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el descuento (en efectivo $us)" ValidationGroup="contrato"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_desc_sus" runat="server" ControlToValidate="txt_desc_sus" Type="Double" Operator="DataTypeCheck" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="El descuento en efectivo debe ser un número positivo" ValidationGroup="contrato"></asp:CompareValidator>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:LinkButton ID="lb_aplicar" runat="server" Text="Aplicar" CausesValidation="true" ValidationGroup="contrato"></asp:LinkButton>
                    </td>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_precio_final" runat="server" SkinID="txtSingleLine100" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdEnun">Forma de pago:</td>
        <td class="contratoFormTdDato">
            <asp:RadioButtonList ID="rbl_contado" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" >
                <asp:ListItem Text="A plazos" Value="false" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Al contado" Value="true"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdEnun"><asp:Label ID="lbl_inicial_enun" runat="server" Text="Cuota inicial ($us):"></asp:Label></td>
        <td class="contratoFormTdDato">
            <asp:TextBox ID="txt_inicial" runat="server" SkinID="txtSingleLine100" MaxLength="8" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_inicial" runat="server" ControlToValidate="txt_inicial" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir la cuota inicial" ValidationGroup="contrato"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cv_inicial" runat="server" ControlToValidate="txt_inicial" Type="Double" Operator="DataTypeCheck" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="La cuota inicial debe ser un número entero positivo" ValidationGroup="contrato"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun">Facturas a nombre de:</td>
                    <td class="contratoFormTdDato">
                        <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfv_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el nombre del beneficiario de la factura" ValidationGroup="contrato"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rev_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre del beneficiario de la factura contiene caracteres inválidos" ValidationGroup="contrato"></asp:RegularExpressionValidator> 
                    </td>
                    <td class="contratoFormTdEnun">con el NIT:</td>
                    <td class="contratoFormTdDato">
                        <asp:TextBox ID="txt_nit" runat="server" SkinID="txtSingleLine100" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos" ValidationGroup="contrato"></asp:RegularExpressionValidator> 
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdEnun">Observaciones:</td>
        <td class="contratoFormTdDato">
            <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" SkinID="txtMultiLine300x3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdEnun">Tipo de cliente:</td>
        <td class="contratoFormTdDato">
            <asp:RadioButtonList ID="rbl_preferencial" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Text="Normal" Value="false" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Preferencial" Value="true"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
