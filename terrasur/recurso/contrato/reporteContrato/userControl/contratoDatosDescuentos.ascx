<%@ Control Language="VB" ClassName="contratoDatosDescuentos" %>

<script runat="server">
    Public Property fecha() As String
        Get
            Return lbl_fecha.Text
        End Get
        Set(ByVal value As String)
            lbl_fecha.Text = value
        End Set
    End Property
    
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
            CargarDatos()
        End Set
    End Property

    Private Sub CargarDatos()
        'Dim c As New contrato(id_contrato)
        Dim c As New contrato_venta(id_contrato)
        lbl_numero.Text = c.numero
        If fecha = "" Then
            lbl_estado.Text = c.estado_nombre
        Else
            lbl_estado.Text = contrato.Estado_string(c.id_contrato, DateTime.Parse(fecha).Date)
        End If
        lbl_negocio.Text = c.negocio_nombre
        If c.preferencial Then
            lbl_tipo_cliente.Text = "Preferencial"
        Else
            lbl_tipo_cliente.Text = "Normal"
        End If
        lbl_fecha_registro.Text = c.fecha
        lbl_lote_servicio.Text = c.urbanizacion_nombre & " - " & c.lote_codigo
        'If c.venta_lote Then
        '    Dim c_venta As New contrato_venta(id_contrato)
        '    lbl_lote_servicio.Text = c_venta.urbanizacion_nombre_corto & " - " & c_venta.lote_codigo
        'Else
        '    lbl_lote_servicio.Text = "Servicios funerarios"
        'End If
        
        Dim titularObj As New cliente(c.id_titular)
        lbl_titular.Text = titularObj.paterno & " " & titularObj.materno & " " & titularObj.nombres
        If c.id_promotor_vigente > 0 Then
            Dim promotorObj As New usuario(c.id_promotor_vigente)
            lbl_promotor.Text = promotorObj.paterno & " " & promotorObj.materno & " " & promotorObj.nombres
        Else
            lbl_promotor.Text = "(No asignado)"
        End If
        If c.id_cobrador_vigente > 0 Then
            Dim cobradorObj As New usuario(c.id_cobrador_vigente)
            lbl_cobrador.Text = cobradorObj.paterno & " " & cobradorObj.materno & " " & cobradorObj.nombres
        Else
            lbl_cobrador.Text = "(No asignado)"
        End If

        lbl_precio_total.Text = c.precio.ToString("F2")
        lbl_descuento_por.Text = c.descuento_porcentaje.ToString("F2")
        lbl_descuento_sus.Text = c.descuento_efectivo.ToString("F2")
        lbl_precio_final.Text = c.precio_final.ToString("F2")
        lbl_cuota_inicial.Text = c.cuota_inicial.ToString("F2")

        Dim id_ultimo_pago As Integer
        If fecha = "" Then
            id_ultimo_pago = c.id_ultimo_pago
        Else
            id_ultimo_pago = contrato.UltimoPago(c.id_contrato, DateTime.Parse(fecha).Date)
        End If
        If id_ultimo_pago > 0 Then
            Dim p As New pago(id_ultimo_pago)
            lbl_capital_pagado.Text = (c.precio_final - p.saldo).ToString("F2")
            lbl_saldo_capital.Text = p.saldo.ToString("F2")
        Else
            lbl_capital_pagado.Text = (0).ToString("F2")
            lbl_saldo_capital.Text = c.precio_final.ToString("F2")
        End If

        Dim id_planpago As Integer
        If fecha = "" Then
            id_planpago = c.id_planpago_vigente
        Else
            id_planpago = contrato.PlanPago(c.id_contrato, DateTime.Parse(fecha).Date)
        End If
        If id_planpago > 0 Then
            Dim pp As New plan_pago(id_planpago)
            lbl_num_cuotas.Text = pp.num_cuotas
            lbl_seguro.Text = pp.seguro
            lbl_mantenimiento.Text = pp.mantenimiento_sus.ToString("F2")
            lbl_interes_corriente.Text = pp.interes_corriente.ToString("F2")
            'lbl_interes_penal.Text = pp.interes_penal.ToString("F2")
            lbl_cuota_base.Text = pp.cuota_base.ToString("F2")
            lbl_fecha_inicio_plan.Text = pp.fecha_inicio_plan.ToShortDateString
        Else
            lbl_num_cuotas.Text = c.num_cuotas
            lbl_seguro.Text = c.seguro
            lbl_mantenimiento.Text = c.mantenimiento_sus.ToString("F2")
            lbl_interes_corriente.Text = c.interes_corriente.ToString("F2")
            'lbl_interes_penal.Text = c.interes_penal.ToString("F2")
            lbl_cuota_base.Text = c.cuota_base.ToString("F2")
            lbl_fecha_inicio_plan.Text = c.fecha_inicio_plan.ToShortDateString
        End If
        
        lbl_precio_total_enun.Text = "Precio total (" & c.codigo_moneda & "):"
        lbl_descuento_sus_enun.Text = "Descuento (" & c.codigo_moneda & "):"
        lbl_precio_final_enun.Text = "Precio final (" & c.codigo_moneda & "):"
        lbl_cuota_inicial_enun.Text = "Cuota inicial (" & c.codigo_moneda & "):"
        lbl_capital_pagado_enun.Text = "Capital pagado (" & c.codigo_moneda & "):"
        lbl_saldo_capital_enun.Text = "Saldo a capital (" & c.codigo_moneda & "):"
        lbl_mantenimiento_enun.Text = "Mantenim. (" & c.codigo_moneda & "/mes):"
        lbl_cuota_base_enun.Text = "Cuota mensual (" & c.codigo_moneda & "/mes):"
        lbl_moneda.Text = New moneda(c.id_moneda).nombre
    End Sub
    
</script>
<asp:Label ID="lbl_fecha" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server" GroupingText="Contrato">
                <table class="contratoDatosTable">
                    <tr>
                        <td class="contratoDatosTdGrupo" colspan="3">
                            <table align="left">
                                <tr>
                                    <td class="contratoDatosTdNumEnun">Nº contrato:</td>
                                    <td class="contratoDatosTdNumDato"><asp:Label ID="lbl_numero" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdNumEnun">Moneda:</td>
                                    <td class="contratoDatosTdNumDato"><asp:Label ID="lbl_moneda" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdEstadoEnun">Estado:</td>
                                    <td class="contratoDatosTdEstadoDato"><asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdEstadoEnun">Negocio:</td>
                                    <td class="contratoDatosTdEstadoDato"><asp:Label ID="lbl_negocio" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdEstadoEnun">Cliente:</td>
                                    <td class="contratoDatosTdEstadoDato"><asp:Label ID="lbl_tipo_cliente" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoDatosTdGrupo">
                            <table>
                                <tr>
                                    <td class="contratoDatosTdEnun">Fecha de registro:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_fecha_registro" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Lote:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_lote_servicio" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Primer titular:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_titular" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Promotor:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_promotor" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Cobrador:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_cobrador" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td class="contratoDatosTdGrupo">
                            <table>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_precio_total_enun" runat="server" Text="Precio total($):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_precio_total" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Descuento (%):</td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_descuento_por" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_descuento_sus_enun" runat="server" Text="Descuento($):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_descuento_sus" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_precio_final_enun" runat="server" Text="Precio final($):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_precio_final" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_cuota_inicial_enun" runat="server" Text="Cuota inicial($):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_cuota_inicial" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_capital_pagado_enun" runat="server" Text="Capital pagado($):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_capital_pagado" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_saldo_capital_enun" runat="server" Text="Saldo a capital($):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_saldo_capital" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td class="contratoDatosTdGrupo">
                            <table>
                                <tr>
                                    <td class="contratoDatosTdEnun">Nº cuotas:</td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_num_cuotas" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Seguro (%/mes):</td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_seguro" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_mantenimiento_enun" runat="server" Text="Mantenim.($/mes):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_mantenimiento" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Interés Corr.(%/año):</td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_interes_corriente" runat="server"></asp:Label></td>
                                </tr>
                                <%--<tr>
                                    <td class="contratoDatosTdEnun">Interés penal(%/mes):</td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_interes_penal" runat="server"></asp:Label></td>
                                </tr>--%>
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_cuota_base_enun" runat="server" Text="Cuota mensual($/mes):"></asp:Label></td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_cuota_base" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="contratoDatosTdEnun">Fecha de inicio de plan:</td>
                                    <td class="contratoDatosTdDatoNumerico"><asp:Label ID="lbl_fecha_inicio_plan" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
