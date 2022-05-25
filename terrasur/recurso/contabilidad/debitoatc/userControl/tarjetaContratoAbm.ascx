<%@ Control Language="VB" ClassName="tarjetaContratoAbm" %>

<script runat="server">
    Protected Property id_tarjetacredito() As Integer
        Get
            Return Integer.Parse(lbl_id_tarjetacredito.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_tarjetacredito.Text = value
        End Set
    End Property
    Protected Property id_tarjetacreditocontrato() As Integer
        Get
            Return Integer.Parse(lbl_id_tarjetacreditocontrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_tarjetacreditocontrato.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar(ByVal _Id_tarjetacredito As Integer)
        id_tarjetacredito = _Id_tarjetacredito
        id_tarjetacreditocontrato = 0
        
        txt_num_contrato.Text = ""
        rbl_periodicidad.DataBind()
        If rbl_periodicidad.Items.Count > 0 Then
            rbl_periodicidad.SelectedIndex = 0
        End If
        ddl_fecha_debito.SelectedValue = "15"
        txt_monto.Text = ""
        rbl_moneda.SelectedIndex = -1
        rbl_activo.SelectedValue = "true"
        
        txt_num_contrato.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        Dim id_contrato As Integer = contrato.IdPorNumero(txt_num_contrato.Text.Trim)
        If id_contrato > 0 Then
            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)

            'Se verifica si la moneda elegida es igual a la moneda del contrato
            If rbl_moneda.SelectedIndex >= 0 Then
                If (codigo_moneda = "$us" And rbl_moneda.SelectedValue <> "sus") Or (codigo_moneda = "Bs" And rbl_moneda.SelectedValue <> "bs") Then
                    Msg1.Text = "La moneda elegida es diferente a la moneda del contrato " & txt_num_contrato.Text.Trim & ", debe presionar el botón Obtener Datos"
                    correcto = False
                End If
            Else
                Msg1.Text = "Debe presionar el botón Obtener Datos"
                correcto = False
            End If

            'Se verifica si el contrato esta asignado a una tarjeta de crédito
            If tarjeta_credito_contrato.VerificarContrato(True, 0, id_contrato) = True Then
                Msg1.Text = "El contrato (" & txt_num_contrato.Text.Trim & ") ya esta asignado a otra tarjeta de crédito"
                correcto = False
            End If
            'Se verifica el estado del contrato
            If contrato.Estado(id_contrato, DateTime.Now) <> 1 Then
                Msg1.Text = "El contrato no esta vigente (" & contrato.Estado_string(id_contrato, DateTime.Now) & ")"
                correcto = False
            End If
            'Se verifica el saldo del contrato
            Dim id_pago As Integer = contrato.UltimoPago(id_contrato, DateTime.Now)
            If id_pago > 0 Then
                Dim pObj As New pago(id_pago)
                If pObj.saldo = 0 Then
                    Msg1.Text = "El contrato esta cancelado"
                    correcto = False
                End If
            End If
            
            'Se verifica que el monto a debitar sea igual a la cuota base
            Dim id_planpago As Integer = contrato.PlanPagoVigente(id_contrato)
            If id_planpago > 0 Then
                Dim ppObj As New plan_pago(id_planpago)
                Dim codigo_periodicidad As Decimal = New tarjeta_credito_periodicidad(Integer.Parse(rbl_periodicidad.SelectedValue), 0).codigo
                
                If Decimal.Parse(txt_monto.Text.Trim) <> (ppObj.cuota_base * codigo_periodicidad) Then
                    If codigo_periodicidad = 1 Then
                        Msg1.Text = "El monto a debitar es diferente a la cuota base del contrato (" & codigo_moneda & " " & ppObj.cuota_base.ToString("F2") & ")"
                    Else
                        Msg1.Text = "El monto a debitar es diferente a " & codigo_periodicidad.ToString("F0") & " veces la cuota base del contrato (" & codigo_moneda & " " & ppObj.cuota_base.ToString("F2") & " * " & codigo_periodicidad.ToString("F0") & ")"
                    End If
                    correcto = False
                End If
            Else
                Msg1.Text = "El contrato no tiene un plan de pagos vigente"
                correcto = False
            End If
        Else
            Msg1.Text = "El contrato (" & txt_num_contrato.Text.Trim & ") no existe"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim id_contrato As Integer = contrato.IdPorNumero(txt_num_contrato.Text.Trim)
            Dim fecha_debito As DateTime = DateTime.Now.AddDays(((DateTime.Now.Day) * (-1)))
            fecha_debito = fecha_debito.AddDays(Integer.Parse(ddl_fecha_debito.SelectedValue))
            Dim monto_bs As Decimal, monto_sus As Decimal
            If rbl_moneda.SelectedValue = "bs" Then
                monto_bs = Decimal.Parse(txt_monto.Text.Trim)
                monto_sus = 0
            Else
                monto_bs = 0
                monto_sus = Decimal.Parse(txt_monto.Text.Trim)
            End If
            
            Dim tccObj As New tarjeta_credito_contrato(id_tarjetacredito, id_contrato, Integer.Parse(rbl_periodicidad.SelectedValue), fecha_debito, monto_bs, monto_sus, Boolean.Parse(rbl_activo.SelectedValue))
            If tccObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "La asignación del contrato a la tarjeta de credito se guardó correctamente"
                CargarInsertar(id_tarjetacredito)
                Return True
            Else
                Msg1.Text = "La asignación del contrato a la tarjeta de credito NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_tarjetacreditocontrato As Integer)
        id_tarjetacreditocontrato = _Id_tarjetacreditocontrato

        Dim tcc As New tarjeta_credito_contrato(id_tarjetacreditocontrato)
        id_tarjetacredito = tcc.id_tarjetacredito

        txt_num_contrato.Text = tcc.num_contrato
        If rbl_periodicidad.Items.Count = 0 Then
            rbl_periodicidad.DataBind()
        End If
        rbl_periodicidad.SelectedValue = tcc.id_periodicidad
        ddl_fecha_debito.SelectedValue = tcc.fecha_debito.ToString("dd")

        If tcc.monto_bs = 0 And tcc.monto_sus > 0 Then
            txt_monto.Text = tcc.monto_sus
            rbl_moneda.SelectedValue = "sus"
        ElseIf tcc.monto_bs > 0 And tcc.monto_sus = 0 Then
            txt_monto.Text = tcc.monto_bs
            rbl_moneda.SelectedValue = "bs"
        End If
        If tcc.activo = True Then
            rbl_activo.SelectedValue = "true"
        Else
            rbl_activo.SelectedValue = "false"
        End If

        txt_num_contrato.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        Dim id_contrato As Integer = contrato.IdPorNumero(txt_num_contrato.Text.Trim)
        If id_contrato > 0 Then
            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)

            'Se verifica si la moneda elegida es igual a la moneda del contrato
            If rbl_moneda.SelectedIndex >= 0 Then
                If (codigo_moneda = "$us" And rbl_moneda.SelectedValue <> "sus") Or (codigo_moneda = "Bs" And rbl_moneda.SelectedValue <> "bs") Then
                    Msg1.Text = "La moneda elegida es diferente a la moneda del contrato " & txt_num_contrato.Text.Trim & ", debe presionar el botón Obtener Datos"
                    correcto = False
                End If
            Else
                Msg1.Text = "Debe presionar el botón Obtener Datos"
                correcto = False
            End If
            
            'Se verifica si el contrato esta asignado a una tarjeta de crédito
            If tarjeta_credito_contrato.VerificarContrato(False, id_tarjetacreditocontrato, id_contrato) = True Then
                Msg1.Text = "El contrato (" & txt_num_contrato.Text.Trim & ") ya esta asignado a otra tarjeta de crédito"
                correcto = False
            End If
            
            'Se verifica el estado del contrato
            If contrato.Estado(id_contrato, DateTime.Now) <> 1 Then
                Msg1.Text = "El contrato no esta vigente (" & contrato.Estado_string(id_contrato, DateTime.Now) & ")"
                correcto = False
            End If
        
            'Se verifica el saldo del contrato
            Dim id_pago As Integer = contrato.UltimoPago(id_contrato, DateTime.Now)
            If id_pago > 0 Then
                Dim pObj As New pago(id_pago)
                If pObj.saldo = 0 Then
                    Msg1.Text = "El contrato esta cancelado"
                    correcto = False
                End If
            End If

            'Se verifica que el monto a debitar sea igual a la cuota base
            Dim id_planpago As Integer = contrato.PlanPagoVigente(id_contrato)
            If id_planpago > 0 Then
                Dim ppObj As New plan_pago(id_planpago)
                Dim codigo_periodicidad As Decimal = New tarjeta_credito_periodicidad(Integer.Parse(rbl_periodicidad.SelectedValue), 0).codigo

                If Decimal.Parse(txt_monto.Text.Trim) <> (ppObj.cuota_base * codigo_periodicidad) Then
                    If codigo_periodicidad = 1 Then
                        Msg1.Text = "El monto a debitar es diferente a la cuota base del contrato (" & codigo_moneda & " " & ppObj.cuota_base.ToString("F2") & ")"
                    Else
                        Msg1.Text = "El monto a debitar es diferente a " & codigo_periodicidad.ToString("F0") & " veces la cuota base del contrato (" & codigo_moneda & " " & ppObj.cuota_base.ToString("F2") & " * " & codigo_periodicidad.ToString("F0") & ")"
                    End If
                    correcto = False
                End If
            Else
                Msg1.Text = "El contrato no tiene un plan de pagos vigente"
                correcto = False
            End If
        Else
            Msg1.Text = "El contrato (" & txt_num_contrato.Text.Trim & ") no existe"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim id_contrato As Integer = contrato.IdPorNumero(txt_num_contrato.Text.Trim)
            Dim fecha_debito As DateTime = DateTime.Now.AddDays(((DateTime.Now.Day) * (-1)))
            fecha_debito = fecha_debito.AddDays(Integer.Parse(ddl_fecha_debito.SelectedValue))
            Dim monto_bs As Decimal, monto_sus As Decimal
            If rbl_moneda.SelectedValue = "bs" Then
                monto_bs = Decimal.Parse(txt_monto.Text.Trim)
                monto_sus = 0
            Else
                monto_bs = 0
                monto_sus = Decimal.Parse(txt_monto.Text.Trim)
            End If
            
            Dim tccObj As New tarjeta_credito_contrato(id_tarjetacreditocontrato, id_tarjetacredito, id_contrato, Integer.Parse(rbl_periodicidad.SelectedValue), fecha_debito, monto_bs, monto_sus, Boolean.Parse(rbl_activo.SelectedValue))
            If tccObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "La asignación del contrato a la tarjeta de credito se actualizó correctamente"
                CargarActualizar(id_tarjetacreditocontrato)
                Return True
            Else
                Msg1.Text = "La asignación del contrato a la tarjeta de credito NO se actualizó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
    Protected Sub btn_datos_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_datos_contrato.Click
        'Se verifica que el contrato exista
        Dim id_contrato As Integer = contrato.IdPorNumero(txt_num_contrato.Text.Trim)
        If id_contrato > 0 Then
            'Se obtiene el monto de la cuota base
            Dim id_planpago As Integer = contrato.PlanPagoVigente(id_contrato)
            If id_planpago > 0 Then
                Dim id_periodicidad_mensual As Integer = New tarjeta_credito_periodicidad(0, 1).id_periodicidad
                If rbl_periodicidad.Items.FindByValue(id_periodicidad_mensual.ToString) IsNot Nothing Then
                    rbl_periodicidad.SelectedValue = id_periodicidad_mensual
                End If
                txt_monto.Text = New plan_pago(id_planpago).cuota_base.ToString
                If contrato.CodigoMoneda(id_contrato) = "$us" Then
                    rbl_moneda.SelectedValue = "sus"
                Else
                    rbl_moneda.SelectedValue = "bs"
                End If
            Else
                Msg1.Text = "El contrato (" & txt_num_contrato.Text.Trim & ") no tiene un plan de pagos vigente"
                txt_monto.Text = ""
                rbl_moneda.SelectedIndex = -1
            End If
        Else
            Msg1.Text = "El contrato (" & txt_num_contrato.Text.Trim & ") no existe"
            txt_monto.Text = ""
            rbl_moneda.SelectedIndex = -1
        End If
    End Sub
</script>
<asp:Label ID="lbl_id_tarjetacredito" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_tarjetacreditocontrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_tarjeta" runat="server" DisplayMode="List" ValidationGroup="tarjeta_contrato" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Asignación de un contrato a la tarjeta de crédito"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº contrato:</td>
        <td class="formTdDato">
            <asp:Panel ID="panel_contato" runat="server" DefaultButton="btn_datos_contrato">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="rfv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="tarjeta_contrato" Text="*" ErrorMessage="Debe introducir el número de contrato"></asp:RequiredFieldValidator></td>
                        <td><asp:Button ID="btn_datos_contrato" runat="server" Text="Obtener datos" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Periodicidad:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_periodicidad" runat="server" DataSourceID="ods_lista_periodicidad" DataTextField="nombre" DataValueField="id_periodicidad" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
            </asp:RadioButtonList>
            <%--[id_periodicidad],[codigo],[nombre],[num_contratos]--%>
            <asp:ObjectDataSource ID="ods_lista_periodicidad" runat="server" TypeName="terrasur.tarjeta_credito_periodicidad" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de débito (día del mes):</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_fecha_debito" runat="server">
                <asp:ListItem Text="01" Value="01" /><asp:ListItem Text="02" Value="02" /><asp:ListItem Text="03" Value="03" /><asp:ListItem Text="04" Value="04" /><asp:ListItem Text="05" Value="05" /><asp:ListItem Text="06" Value="06" /><asp:ListItem Text="07" Value="07" /><asp:ListItem Text="08" Value="08" /><asp:ListItem Text="09" Value="09" /><asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="11" Value="11" /><asp:ListItem Text="12" Value="12" /><asp:ListItem Text="13" Value="13" /><asp:ListItem Text="14" Value="14" /><asp:ListItem Text="15" Value="15" /><asp:ListItem Text="16" Value="16" /><asp:ListItem Text="17" Value="17" /><asp:ListItem Text="18" Value="18" /><asp:ListItem Text="19" Value="19" /><asp:ListItem Text="20" Value="20" />
                <asp:ListItem Text="21" Value="21" /><asp:ListItem Text="22" Value="22" /><asp:ListItem Text="23" Value="23" /><asp:ListItem Text="24" Value="24" /><asp:ListItem Text="25" Value="25" /><asp:ListItem Text="26" Value="26" /><asp:ListItem Text="27" Value="27" /><asp:ListItem Text="28" Value="28" /><asp:ListItem Text="29" Value="29" /><asp:ListItem Text="30" Value="30" />
                <asp:ListItem Text="31" Value="31" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Monto a debitar:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txt_monto" runat="server" SkinID="txtSingleLine50" MaxLength="7" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ValidationGroup="tarjeta_contrato" Text="*" ErrorMessage="Debe introducir el monto a debitar"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_monto" runat="server" ControlToValidate="txt_monto" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ValidationGroup="tarjeta_contrato" Text="*" ErrorMessage="Debe introducir un monto válido"></asp:CompareValidator>
                        <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Type="Double" MinimumValue="1" MaximumValue="99998" Display="Dynamic" ValidationGroup="tarjeta_contrato" Text="*" ErrorMessage="El monto introducido debe ser mayor a 0 y menor a 99999"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbl_moneda" runat="server" Enabled="false" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                            <asp:ListItem Text="$us" Value="sus"></asp:ListItem>
                            <asp:ListItem Text="Bs" Value="bs"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td><asp:RequiredFieldValidator ID="rfv_moneda" runat="server" ControlToValidate="rbl_moneda" Display="Dynamic" ValidationGroup="tarjeta_contrato" Text="*" ErrorMessage="Debe presionar el botón Obtener Datos"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Asignación activa:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_activo" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Activa" Value="true" Selected="true"></asp:ListItem>
                <asp:ListItem Text="Inactiva" Value="false"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>