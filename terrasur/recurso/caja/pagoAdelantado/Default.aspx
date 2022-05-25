<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pago por Adelantado" %>
<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago" TagPrefix="uc3" %>

<script runat="server">
    Protected Property num_cuotas() As Integer
        Get
            Return Integer.Parse(lbl_num_cuotas.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_num_cuotas.Text = value
        End Set
    End Property
    Protected Property monto_cuotas() As Decimal
        Get
            Return Decimal.Parse(lbl_monto_cuotas.Text)
        End Get
        Set(ByVal value As Decimal)
            lbl_monto_cuotas.Text = value
        End Set
    End Property
    Protected Property con_factura() As Boolean
        Get
            Return Boolean.Parse(lbl_con_factura.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_con_factura.Text = value
        End Set
    End Property
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value

            lbl_total_moneda.Text = "(" & value & ")"

            gv_pago.Columns(6).HeaderText = "Pago(" & value & ")"
            gv_pago.Columns(7).HeaderText = "Seguro(" & value & ")"
            gv_pago.Columns(8).HeaderText = "Manten.(" & value & ")"
            gv_pago.Columns(9).HeaderText = "Interés(" & value & ")"
            gv_pago.Columns(10).HeaderText = "Amortiz.(" & value & ")"
            gv_pago.Columns(11).HeaderText = "Saldo(" & value & ")"
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler CajaRealizarPago1.Eleccion_aceptar, AddressOf CajaRealizarPago_Aceptar
        AddHandler CajaRealizarPago1.Eleccion_cancelar, AddressOf CajaRealizarPago_Cancelar
        txt_num_cuotas.Attributes("onfocus") = "this.select();"
        If Not Page.IsPostBack Then
            Session("permitir_pagar") = "no"
            If Session("id_contrato") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                Session.Remove("id_contrato")

                codigo_moneda = contrato.CodigoMoneda(ContratoDatos1.id_contrato)

                CargarDatosPago()
            Else
                Response.Redirect("~/recurso/caja/contratoPago.aspx")
            End If
        End If
    End Sub

    Protected Sub CargarDatosPago()
        MultiView1.ActiveViewIndex = 0
        txt_num_cuotas.Text = "1"
        CargarTablaCuotasAdelantadas()
    End Sub

    Protected Sub btn_adelantar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adelantar.Click
        CargarTablaCuotasAdelantadas()
    End Sub

    Protected Sub CargarTablaCuotasAdelantadas()
        'Se obtiene la tabla y los parámetros necesarios
        Dim _num_cuotas As Integer = Integer.Parse(txt_num_cuotas.Text.Trim)
        Dim _monto_cuotas As Decimal = 0
        Dim _con_factura As Boolean = False
        Dim tabla As Data.DataTable = pago.Lista_PagoAdelantadoSegunPlan_VARIOS_PAGOS(ContratoDatos1.id_contrato, _num_cuotas, _monto_cuotas, _con_factura)
        'Dim tabla As Data.DataTable = pago.Lista_PagoAdelantadoSegunPlan_UN_PAGO(ContratoDatos1.id_contrato, p_num_cuotas, p_monto_cuotas, monto_seg_mant_int)
        If Integer.Parse(txt_num_cuotas.Text.Trim) <> _num_cuotas Then
            txt_num_cuotas.Text = _num_cuotas
        End If
        num_cuotas = _num_cuotas
        monto_cuotas = _monto_cuotas
        con_factura = _con_factura

        'Se prepara la tabla para desplegarla
        tabla.Columns.Add("tipo_pago")
        tabla.Rows(0)("tipo_pago") = "Último pago:"
        For i As Integer = 1 To tabla.Rows.Count - 1
            tabla.Rows(i)("tipo_pago") = "Cuota adelantada " & i.ToString & ":"
        Next
        'tabla.Rows(1)("tipo_pago") = num_cuotas & " Cuota(s) adelantada(s):"
        gv_pago.DataSource = tabla
        gv_pago.DataBind()
        gv_pago.Rows(0).CssClass = "cajaGvRowUltimo"
        For i As Integer = 1 To gv_pago.Rows.Count - 1
            gv_pago.Rows(i).CssClass = "cajaGvRowNuevo"
            gv_pago.Rows(i).Cells(6).CssClass = "cajaGvCellTotal"
        Next



        'Se dimensiona el contenedor de la tabla
        If num_cuotas > 3 Then
            panel_pagos.Height = Unit.Pixel(110)
            txt_focus.Visible = True
            txt_focus.Focus()
        Else
            panel_pagos.Height = Unit.Percentage(100)
            txt_focus.Visible = False
            txt_num_cuotas.Focus()
        End If

        'Se despliega el monto total a pagar
        lbl_total_monto.Text = monto_cuotas.ToString("F2")
    End Sub
    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        If num_cuotas <> Integer.Parse(txt_num_cuotas.Text) Then
            CargarTablaCuotasAdelantadas()
        End If
        Dim permiso_efectivo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoAdelantado", "efectivo")
        CajaRealizarPago1.Cargar(monto_cuotas, permiso_efectivo.Equals(False), False, con_factura, ContratoDatos1.id_contrato, codigo_moneda)

        Session("permitir_pagar") = "si"
        MultiView1.ActiveViewIndex = 1

        btn_otro_contrato.Visible = False
        btn_otro_pago.Visible = False
    End Sub

    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("permitir_pagar") = "si" Then
            Dim id_transaccion As String = pago.Insertar_PagoAdelantadoSegunPlan_VARIOS_PAGOS(Profile.id_usuario, Profile.entorno.id_rol, ContratoDatos1.id_contrato, CajaRealizarPago1.dato_id_recibo_cobrador, "pagoAdelantado", num_cuotas, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar)
            'Dim id_transaccion As String = pago.Insertar_PagoAdelantadoSegunPlan_UN_PAGO(Profile.id_usuario, Profile.entorno.id_rol, ContratoDatos1.id_contrato, CajaRealizarPago1.dato_id_recibo_cobrador, "pagoAdelantado", num_cuotas, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar)
            If id_transaccion <> "" Then
                Msg1.Text = "PAGO REALIZADO"
                ContratoDatos1.id_contrato = ContratoDatos1.id_contrato
                'En este punto se despliegan: la factura, el recibo y el comprobante
                CajaRealizarPago1.Pago_Realizado(id_transaccion.ToString)
            Else
                Msg1.Text = "EL PAGO NO SE REALIZÓ CORRECTAMENTE"
            End If
            Session("permitir_pagar") = "no"
        Else
            'Session("id_contrato") = ContratoDatos1.id_contrato
            Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
        End If

    End Sub
    Protected Sub CajaRealizarPago_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("permitir_pagar") = "no"
        MultiView1.ActiveViewIndex = 0

        btn_otro_contrato.Visible = True
        btn_otro_pago.Visible = True
    End Sub

    Protected Sub btn_otro_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_otro_contrato.Click
        Response.Redirect("~/recurso/caja/contratoPago.aspx")
    End Sub
    Protected Sub btn_otro_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_otro_pago.Click
        Session("id_contrato") = ContratoDatos1.id_contrato
        Response.Redirect("~/recurso/caja/contratoPago.aspx")
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaMaster ID="CajaMaster1" runat="server" tipo_pago="pagoAdelantado" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_venta_lote" runat="server" Text="True" Visible="false"></asp:Label>
    <asp:Label ID="lbl_num_cuotas" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_monto_cuotas" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_con_factura" runat="server" Text="True" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Pago por Adelantado</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdButtonNuevaBusqueda">
                            <asp:Button ID="btn_otro_contrato" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" />
                            <asp:Button ID="btn_otro_pago" runat="server" Text="Realizar otro pago" SkinID="btnVolver" />
                        </td>
                    </tr>
                    <tr><td class="tdEncabezado"><uc2:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                    <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_pago" runat="server" GroupingText="Pago Adelantado" DefaultButton="btn_adelantar">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table align="center" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <table align="left">
                                                                                <tr>
                                                                                    <td class="cajaPagoTdEnun">Nº de cuotas a adelantar:</td>
                                                                                    <td class="cajaPagoTdDato">
                                                                                        <asp:TextBox ID="txt_num_cuotas" runat="server" Text="1"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfv_num_cuotas" runat="server" ControlToValidate="txt_num_cuotas" Display="Dynamic" Text="*" ErrorMessage="Debe introducir el Nº de cuotas" ValidationGroup="adelanto_cuotas"></asp:RequiredFieldValidator>
                                                                                        <asp:CompareValidator ID="cv_num_cuotas" runat="server" ControlToValidate="txt_num_cuotas" Display="Dynamic" Type="Integer" Operator="DataTypeCheck" Text="*" ErrorMessage="El Nº de cuotas debe ser un número entero" ValidationGroup="adelanto_cuotas"></asp:CompareValidator>
                                                                                        <asp:RangeValidator ID="rv_num_cuotas" runat="server" ControlToValidate="txt_num_cuotas" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="120" Text="*" ErrorMessage="El Nº de cuotas no puede ser inferior a 1 ni superior a 120" ValidationGroup="adelanto_cuotas"></asp:RangeValidator>
                                                                                    </td>
                                                                                    <td><asp:Button ID="btn_adelantar" runat="server" Text="Adelantar cuotas" CausesValidation="true" ValidationGroup="adelanto_cuotas" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="panel_pagos" runat="server" ScrollBars="Vertical" Height="100">
                                                                            <table cellpadding="0" cellspacing="0"><tr><td>
                                                                            <asp:GridView ID="gv_pago" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:BoundField ShowHeader="false" DataField="tipo_pago" ItemStyle-CssClass="cajaGvCellTipoEnun" />
                                                                                    <asp:BoundField HeaderText="F.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="F.Pago Int." DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="Nºdias Int." DataField="interes_dias" />
                                                                                    <asp:BoundField HeaderText="Cuota" DataField="string_cuotas" />
                                                                                    <asp:BoundField HeaderText="Pago" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Manten." DataField="mantenimiento_sus" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Interés" DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Amortiz." DataField="amortizacion" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                            </td></tr><tr><td height="1px">
                                                                            <asp:TextBox ID="txt_focus" runat="server" Height="0px" Width="0px" MaxLength="0" BorderStyle="Solid" BorderColor="white"></asp:TextBox>
                                                                            </td></tr></table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table align="left">
                                                                                <tr>
                                                                                    <td class="cajaPagoTdEnun">Total a pagar:</td>
                                                                                    <td class="cajaPagoTdDato"><asp:Label ID="lbl_total_monto" runat="server"></asp:Label></td>
                                                                                    <td class="cajaPagoTdEnun"><asp:Label ID="lbl_total_moneda" runat="server" Text="($us)"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdButton">
                                                                <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" CausesValidation="true" ValidationGroup="adelanto_cuotas" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdMsg">
                                                                <asp:ValidationSummary ID="vs_monto" runat="server" DisplayMode="List" ValidationGroup="adelanto_cuotas" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <uc3:cajaRealizarPago ID="CajaRealizarPago1" runat="server" />
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

