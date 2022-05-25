<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pago Normal" %>

<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos"
    TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago"
    TagPrefix="uc3" %>
<script runat="server">
    Protected Property monto_predeterminado() As Decimal
        Get
            Return Decimal.Parse(lbl_monto_predeterminado.Text)
        End Get
        Set(ByVal value As Decimal)
            lbl_monto_predeterminado.Text = value
        End Set
    End Property
    Protected Property monto_minimo() As Decimal
        Get
            Return Decimal.Parse(lbl_monto_minimo.Text)
        End Get
        Set(ByVal value As Decimal)
            lbl_monto_minimo.Text = value
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
    Protected Property digitado_con_factura() As Boolean
        Get
            Return Boolean.Parse(lbl_digitado_con_factura.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_digitado_con_factura.Text = value
        End Set
    End Property
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value

            gv_pago.Columns(6).HeaderText = "Pago(" & value & ")"
            gv_pago.Columns(7).HeaderText = "Seguro(" & value & ")"
            gv_pago.Columns(8).HeaderText = "Manten.(" & value & ")"
            gv_pago.Columns(9).HeaderText = "Interés(" & value & ")"
            gv_pago.Columns(10).HeaderText = "Amortiz.(" & value & ")"
            gv_pago.Columns(11).HeaderText = "Saldo(" & value & ")"

            lbl_monto_moneda.Text = value
            gv_pago_minimo.Columns(2).HeaderText = "Pago(" & value & ")"
            gv_pago_minimo.Columns(3).HeaderText = "Seguro(" & value & ")"
            gv_pago_minimo.Columns(4).HeaderText = "Manten.(" & value & ")"
            gv_pago_minimo.Columns(5).HeaderText = "Interés(" & value & ")"
            gv_pago_minimo.Columns(6).HeaderText = "Amortiz.(" & value & ")"
            gv_pago_minimo.Columns(7).HeaderText = "Saldo(" & value & ")"

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler CajaRealizarPago1.Eleccion_aceptar, AddressOf CajaRealizarPago_Aceptar
        AddHandler CajaRealizarPago1.Eleccion_cancelar, AddressOf CajaRealizarPago_Cancelar
        txt_monto.Attributes("onfocus") = "this.select();"
        txt_monto.Attributes("onblur") = "extractNumber(this,2,false);"
        txt_monto.Attributes("onkeyup") = "extractNumber(this,2,false);"
        txt_monto.Attributes("onkeypress") = "return blockNonNumbers(this, event, true, false);"

        If Not Page.IsPostBack Then
            Session("permitir_pagar") = "no"
            If Session("id_contrato") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                Session.Remove("id_contrato")

                codigo_moneda = contrato.CodigoMoneda(ContratoDatos1.id_contrato)

                CargarDatosPago()
                
                '-- Facturacion Sintesis
                txtCorreoFactura.Text = ""
                If con_factura Then
                    panel_correo_factura.Visible = True
                End If
                '--
            Else
                Response.Redirect("~/recurso/caja/contratoPago.aspx")
            End If
        End If
    End Sub

    Protected Sub CargarDatosPago()
        MultiView1.ActiveViewIndex = 0

        Dim _monto_predeterminado As Decimal = 0
        Dim _monto_minimo As Decimal = 0
        Dim monto_maximo As Decimal = 0
        Dim _con_factura As Boolean = False
        Dim tabla As Data.DataTable = pago.Lista_PagoNormal(ContratoDatos1.id_contrato, 0, DateTime.Now, _monto_predeterminado, _monto_minimo, monto_maximo, _con_factura)
        monto_predeterminado = _monto_predeterminado
        monto_minimo = _monto_minimo
        con_factura = _con_factura

        'Dim monto_maximo = seg_mant_int + Decimal.Parse(tabla.Rows(0)("saldo").ToString)

        'If (cbCero.Checked = False) Then
        rv_monto.ErrorMessage = "El monto a pagar no puede ser inferior a 0,10 ni superior a " & monto_maximo.ToString("F2")
        rv_monto.MaximumValue = Math.Round(monto_maximo, 2)
        'Else
        '    txt_monto.Text = monto_maximo
        'End If

        tabla.Columns.Add("tipo_pago")
        tabla.Rows(0)("tipo_pago") = "Último pago:"
        tabla.Rows(1)("tipo_pago") = "Pago a realizar:"
        gv_pago.DataSource = tabla
        gv_pago.DataBind()
        gv_pago.Rows(0).CssClass = "cajaGvRowUltimo"
        gv_pago.Rows(1).CssClass = "cajaGvRowNuevo"
        gv_pago.Rows(1).Cells(6).CssClass = "cajaGvCellTotal"

        rbl_monto.SelectedValue = "false"
        CargarDatosSegunOpcion()
    End Sub

    Protected Sub rbl_monto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_monto.SelectedIndexChanged
        CargarDatosSegunOpcion()
    End Sub

    Protected Sub CargarDatosSegunOpcion()
        If Boolean.Parse(rbl_monto.SelectedValue) = True Then
            panel_monto.Visible = True
            txt_monto.Text = monto_minimo
            txt_monto.Focus()
            CargarDatosMontoDigitado()
        Else
            panel_monto.Visible = False
        End If
    End Sub

    Protected Sub btn_ver_monto_digitado_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_ver_monto_digitado.Click
        CargarDatosMontoDigitado()
    End Sub

    Protected Sub CargarDatosMontoDigitado()
        If Boolean.Parse(rbl_monto.SelectedValue) = True Then
            Dim aux As Decimal = 0
            Dim _digitado_con_factura As Boolean = False
            Dim monto_aux As Decimal
            monto_aux = Decimal.Parse(txt_monto.Text.Trim)
            'If (cbCero.Checked = False) Then

            'Else
            '    monto_aux = 9999999

            'End If
            Dim tabla_pago_minimo As Data.DataTable = pago.Lista_PagoNormal(ContratoDatos1.id_contrato, monto_aux, DateTime.Now, aux, aux, aux, _digitado_con_factura)
            digitado_con_factura = _digitado_con_factura

            tabla_pago_minimo.Rows.RemoveAt(0)
            gv_pago_minimo.DataSource = tabla_pago_minimo
            gv_pago_minimo.DataBind()
            gv_pago_minimo.Rows(0).CssClass = "cajaGvRowNuevo"
            txt_monto.Text = monto_aux.ToString()
            'If (cbCero.Checked = False) Then

            'Else
            '    'txt_monto.Text =  tabla_pago_minimo.Rows(0).Item(2).ToString()
            '    txt_monto.Text = gv_pago_minimo.Rows(0).Cells(2).Text
            'End If
            'lbl_monto_minimo_sus.Text = monto_minimo.ToString("F2")
            'lbl_monto_minimo_bs.Text = (monto_minimo * New tipo_cambio(DateTime.Now).compra).ToString("F2")
        End If
    End Sub

    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        CargarDatosMontoDigitado()
        If VerificarNafibo() = True Then
            Dim permiso_efectivo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoNormal", "efectivo")
            If Boolean.Parse(rbl_monto.SelectedValue) = True Then
                CajaRealizarPago1.Cargar(Decimal.Parse(txt_monto.Text), permiso_efectivo.Equals(False), False, digitado_con_factura, ContratoDatos1.id_contrato, codigo_moneda)
            Else
                CajaRealizarPago1.Cargar(monto_predeterminado, permiso_efectivo.Equals(False), False, con_factura, ContratoDatos1.id_contrato, codigo_moneda)
            End If

            If Boolean.Parse(rbl_monto.SelectedValue) = False Then
                Dim pp As New plan_pago(contrato.PlanPagoVigente(ContratoDatos1.id_contrato))
                If monto_predeterminado > pp.cuota_base Then
                    Msg1.Text = "El monto a pagar: " & monto_predeterminado.ToString("f2") & " ES MAYOR a la cuota mensual del cliente: " & pp.cuota_base.ToString("f2") & " " & codigo_moneda
                End If
            End If

            Session("permitir_pagar") = "si"
            MultiView1.ActiveViewIndex = 1

            btn_otro_contrato.Visible = False
            btn_otro_pago.Visible = False

        End If
    End Sub

    Protected Function VerificarNafibo() As Boolean
        Dim correcto As Boolean = True
        If Boolean.Parse(rbl_monto.SelectedValue) = True Then
            Dim _id_contrato As Integer = ContratoDatos1.id_contrato
            If Boolean.Parse(rbl_monto.SelectedValue) = True AndAlso (negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "nafibo" Or negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "roldan" Or negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "bbr" Or negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "cea" Or negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "terra") Then
                Dim monto_digitado As Decimal = Decimal.Parse(txt_monto.Text)

                Dim coObj As New contrato(_id_contrato)
                Dim saldo As Decimal = coObj.saldo_capital

                Dim cuota_base As Decimal = New plan_pago(coObj.id_planpago_vigente).cuota_base
                'Comentar estos IFs para que se pueda pagar a capital menor de su cuota
                'Desde aqui----------
                If monto_digitado < cuota_base Then
                    If coObj.saldo_capital >= cuota_base Then
                        correcto = False
                        Msg2.Text = "El monto a pagar no puede ser inferior a la cuota mensual establecida (" & cuota_base.ToString("F2") & ")"
                    End If
                End If
                '-----Hasta aqui
            End If
        End If

        Return correcto
    End Function

    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Session("permitir_pagar") = "si" Then
                pnlUrlFactura.Visible = False
                
                Dim monto_digitado As Decimal = 0
                If Boolean.Parse(rbl_monto.SelectedValue) = True Then
                    monto_digitado = CajaRealizarPago1.monto
                End If
            
                '-- Facturacion Sintesis
                Dim aut As WSFacturacion.Autenticacion = New WSFacturacion.Autenticacion()
                Dim autRes As WSFacturacion.AutenticacionRes = New WSFacturacion.AutenticacionRes()
                Dim usuario As String = ConfigurationManager.AppSettings("usuarioSintesis").ToString()
                Dim password As String = ConfigurationManager.AppSettings("passwordSintesis").ToString()
                Dim businessCode As String = ConfigurationManager.AppSettings("businessCodeSintesis").ToString()
                Dim token As String = ""
                
                If con_factura Then
                    If txtCorreoFactura.Text <> "" Then
                        If Not logica.ValidaEmail(txtCorreoFactura.Text) Then
                            Msg1.Text = "La dirección E-Mail es incorrecta"
                            txtCorreoFactura.Focus()
                            Exit Sub
                        End If
                    End If
                    
                    aut.username = usuario
                    aut.password = password
                    Dim objLogin As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                    autRes = objLogin.Autenticar(aut)
                    If autRes.code <> 200 Then
                        Msg1.Text = "Error en la Conexión a Sintesis"
                        Exit Sub
                    Else
                        token = autRes.body.idToken
                    End If
                End If
                '--
            
                Dim id_transaccion As Integer = pago.Insertar_PagoNormal(DateTime.Now, Profile.id_usuario, Profile.entorno.id_rol, ContratoDatos1.id_contrato, CajaRealizarPago1.dato_id_recibo_cobrador, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar, monto_digitado)
                If id_transaccion > 0 Then
                    ContratoDatos1.id_contrato = ContratoDatos1.id_contrato
                    'En este punto se despliegan: la factura, el recibo y el comprobante
                    CajaRealizarPago1.Pago_Realizado(id_transaccion.ToString)
                
                    '-- Facturacion Sintesis
                    If CajaRealizarPago1.con_factura Then
                        Dim codigoMoneda As String = "1"
                        Dim codigoMetodoPago As String = ""
                        Dim numeroTarjeta As String = ""
                    
                        ' Forma de Pago
                        codigoMetodoPago = logica.MetodoPagoFacturacion(CajaRealizarPago1.dato_FormaPagoCliente)
                        If codigoMetodoPago = "10" Or codigoMetodoPago = "2" Then
                            numeroTarjeta = CajaRealizarPago1.dato_FormaPagoCliente.tarjeta_numero
                        End If
                    
                        ' Obtener la factura
                        Dim Id_factura As Integer = terrasur.factura.IdPorTransaccion(id_transaccion)
                        Dim fact As factura = New factura(Id_factura)
                        Dim Nro_factura As String = fact.num_factura.ToString()
                    
                        ' Obtener datos del cliente
                        Dim cont As contrato = New contrato(ContratoDatos1.id_contrato)
                        Dim codigoCliente As String = cont.numero.ToString()
                    
                        ' Emitir Factura
                        ' Principal 
                        Dim factura As FacturaPrincipal = New FacturaPrincipal()
                        factura.businessCode = businessCode
                        factura.branchOfficeSiat = 0
                        factura.pointSaleSiat = 0
                        factura.documentSectorType = 1
                        factura.email = ""
                        factura.useCurrencyType = False

                        ' Cabecera
                        Dim facturaCabecera As FacturaCabecera = New FacturaCabecera()
                        facturaCabecera.numeroFactura = Nro_factura
                        facturaCabecera.nombreRazonSocial = CajaRealizarPago1.dato_cliente_nombre
                        facturaCabecera.codigoTipoDocumentoIdentidad = "5" ' NIT
                        facturaCabecera.numeroDocumento = CajaRealizarPago1.dato_cliente_nit
                        facturaCabecera.complemento = "" ' Enviar vacio si tipo de documento es 5
                        facturaCabecera.codigoCliente = codigoCliente.ToString() ' Este campo no puede estar vacio
                        facturaCabecera.codigoMetodoPago = codigoMetodoPago
                        facturaCabecera.numeroTarjeta = numeroTarjeta
                        facturaCabecera.montoTotal = fact.monto_bs.ToString().Replace(",", ".")
                        facturaCabecera.montoTotalSujetoIva = fact.monto_bs.ToString().Replace(",", ".")
                        facturaCabecera.codigoMoneda = codigoMoneda
                        facturaCabecera.tipoCambio = "1" ' Este campo debe ser 1
                        facturaCabecera.montoTotalMoneda = fact.monto_bs.ToString().Replace(",", ".")
                        facturaCabecera.montoGiftCard = "0"
                        facturaCabecera.descuentoAdicional = "0"
                        facturaCabecera.codigoExcepcion = "1" ' Enviar 1 para que no se haga validación del NIT
                        facturaCabecera.usuario = Profile.UserName

                        ' Detalle
                        Dim facturaDetalle As New FacturaDetalle()
                        facturaDetalle.codigoProducto = "1" ' PAGO INTERES CORRIENTE
                        facturaDetalle.descripcion = "PAGO INTERES CORRIENTE"
                        facturaDetalle.cantidad = "1"
                        facturaDetalle.precioUnitario = fact.monto_bs.ToString().Replace(",", ".")
                        facturaDetalle.montoDescuento = "0"
                        facturaDetalle.subTotal = fact.monto_bs.ToString().Replace(",", ".")
                        facturaDetalle.numeroSerie = ""
                        facturaDetalle.numeroImei = ""
            
                        Dim CadenaFactura As String = factura.businessCode & "|" & factura.branchOfficeSiat & "|" & factura.pointSaleSiat & "|" & factura.documentSectorType & "|" & factura.email & "|" & factura.useCurrencyType
                
                        Dim CadenaCabecera As String = facturaCabecera.numeroFactura & "|" & facturaCabecera.nombreRazonSocial & "|" & facturaCabecera.codigoTipoDocumentoIdentidad & "|" & facturaCabecera.numeroDocumento & "|" & facturaCabecera.complemento & "|" & _
                                                       facturaCabecera.codigoCliente & "|" & facturaCabecera.codigoMetodoPago & "|" & facturaCabecera.numeroTarjeta & "|" & facturaCabecera.montoTotal & "|" & facturaCabecera.montoTotalSujetoIva & "|" & _
                                                       facturaCabecera.codigoMoneda & "|" & facturaCabecera.tipoCambio & "|" & facturaCabecera.montoTotalMoneda & "|" & facturaCabecera.montoGiftCard & "|" & facturaCabecera.descuentoAdicional & "|" & _
                                                       facturaCabecera.codigoExcepcion & "|" & facturaCabecera.usuario
                    
                        Dim CadenaOpcional(0) As String
                        CadenaOpcional(0) = ""
                    
                        Dim CadenaDetalle(0) As String
                        CadenaDetalle(0) = facturaDetalle.codigoProducto & "|" & facturaDetalle.descripcion & "|" & facturaDetalle.cantidad & "|" & facturaDetalle.precioUnitario & "|" & facturaDetalle.montoDescuento & "|" & _
                                           facturaDetalle.subTotal & "|" & facturaDetalle.numeroSerie & "|" & facturaDetalle.numeroImei
            
                        Dim objFacturacion As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                        Dim factRes As WSFacturacion.FacturaRes = objFacturacion.EmitirFacturaCompraVenta(token, CadenaFactura, CadenaCabecera, CadenaOpcional, CadenaDetalle)
                        If factRes.code = 200 Then
                            Msg1.Text = "PAGO REALIZADO"
                            ' Obtener el enlace de la representacion grafica
                            objFacturacion = New WSFacturacion.WSFacturacion()
                            Dim urlFactura As String = objFacturacion.RepGraficaFacturaOficio(token, factRes.body.cuf, "bbr")
                            If urlFactura <> "" Then
                                hlFactura.NavigateUrl = urlFactura
                                hlFactura.Text &= " " & Nro_factura
                                pnlUrlFactura.Visible = True
                            End If
                            
                            ' Actualizar datos en tabla factura
                            Dim factActualizada As Boolean = terrasur.factura.ActualizarDatos(Id_factura, factRes.body.cuf, urlFactura, txtCorreoFactura.Text)
                            If factActualizada Then
                                If urlFactura <> "" Then
                                    If txtCorreoFactura.Text <> "" Then
                                        If Not logica.enviarCorreo(urlFactura, txtCorreoFactura.Text, "Factura de su pago BBR") Then
                                            Msg1.Text = "ERROR AL ENVIAR CORREO DE LA FACTURA NRO. " & Nro_factura
                                        End If
                                    End If
                                Else
                                    Msg1.Text = "ERROR AL OBTENER LA REPRESENTACION GRAFICA DE LA FACTURA NRO. " & Nro_factura & " EN SINTESIS"
                                End If
                            Else
                                Msg1.Text = "ERROR AL ACTUALIZAR DATOS DE LA FACTURA NRO. " & Nro_factura
                            End If
                        Else
                            Msg1.Text = "ERROR EN EL REGISTRO DE FACTURA NRO. " & Nro_factura & " EN SINTESIS"
                        End If
                    Else
                        Msg1.Text = "PAGO REALIZADO"
                    End If
                    '--
                Else
                    Msg1.Text = "EL PAGO NO SE REALIZÓ CORRECTAMENTE"
                End If
                Session("permitir_pagar") = "no"
            Else
                Session("id_contrato") = ContratoDatos1.id_contrato
                Response.Redirect("~/recurso/caja/contratoPago.aspx")
            End If
        Catch ex As Exception
            Msg1.Text = "Error: " & ex.Message
        End Try
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

    'Protected Sub cbCero_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If (cbCero.Checked = False) Then
    '        txt_monto.Text = monto_minimo
    '    End If
    '    CargarDatosMontoDigitado()

    'End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" runat="Server">
    <uc1:cajaMaster ID="CajaMaster1" runat="server" tipo_pago="pagoNormal" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../js/scriptjs.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:Label ID="lbl_monto_predeterminado" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_monto_minimo" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_con_factura" runat="server" Text="False" Visible="false"></asp:Label>
    <asp:Label ID="lbl_digitado_con_factura" runat="server" Text="False" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Pago Normal
            </td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdButtonNuevaBusqueda">
                            <asp:Button ID="btn_otro_contrato" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" />
                            <asp:Button ID="btn_otro_pago" runat="server" Text="Realizar otro pago" SkinID="btnVolver" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdEncabezado">
                            <uc2:contratoDatos ID="ContratoDatos1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdMsg">
                            <asp:Msg ID="Msg2" runat="server"></asp:Msg>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_pago" runat="server" GroupingText="Pago Normal" DefaultButton="btn_pagar">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table align="center" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <table align="center">
                                                                                <tr>
                                                                                    <td class="cajaPagoTdEnun">
                                                                                        Pago a realizar:
                                                                                    </td>
                                                                                    <td class="cajaPagoTdDato">
                                                                                        <asp:RadioButtonList ID="rbl_monto" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                                                            CellPadding="0" CellSpacing="0">
                                                                                            <asp:ListItem Text="Cuota(s) vencida(s)" Value="false" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Text="Digitar monto" Value="true"></asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gv_pago" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:BoundField ShowHeader="false" DataField="tipo_pago" ItemStyle-CssClass="cajaGvCellTipoEnun" />
                                                                                    <asp:BoundField HeaderText="F.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}"
                                                                                        ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="F.Pago Int." DataField="interes_fecha" HtmlEncode="false"
                                                                                        DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo" HtmlEncode="false"
                                                                                        DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="Nºdias Int." DataField="interes_dias" />
                                                                                    <asp:BoundField HeaderText="Cuota" DataField="string_cuotas" />
                                                                                    <asp:BoundField HeaderText="Pago" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Manten." DataField="mantenimiento_sus" HtmlEncode="false"
                                                                                        DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Interés" DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Amortiz." DataField="amortizacion" HtmlEncode="false"
                                                                                        DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="panel_monto" runat="server" GroupingText="Digitar monto" DefaultButton="btn_ver_monto_digitado">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td valign="middle">
                                                                                            <%-- <asp:CheckBox ID="cbCero" Text="Saldar contrato?" Font-Bold="true" runat="server" 
                                                                                                AutoPostBack="False" Checked="false" />--%>
                                                                                            <table align="center">
                                                                                                <tr>
                                                                                                    <td class="cajaPagoTdEnun">
                                                                                                        Monto a pagar:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txt_monto" runat="server" SkinID="txtCajaPagoMonto" MaxLength="8"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto"
                                                                                                            Display="Dynamic" Text="*" ErrorMessage="Debe introducir el monto a pagar" ValidationGroup="monto"></asp:RequiredFieldValidator>
                                                                                                        <asp:CompareValidator ID="cv_monto" runat="server" ControlToValidate="txt_monto"
                                                                                                            Display="Dynamic" Type="Double" Operator="DataTypeCheck" Text="*" ErrorMessage="El monto a pagar debe ser un número válido"
                                                                                                            ValidationGroup="monto"></asp:CompareValidator>
                                                                                                        <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic"
                                                                                                            Type="Double" MinimumValue="0,01" MaximumValue="9999999" Text="*" ErrorMessage="El monto a pagar no puede ser inferior a 0,10 ni superior a"
                                                                                                            ValidationGroup="monto"></asp:RangeValidator>
                                                                                                    </td>
                                                                                                    <td class="cajaPagoTdEnun">
                                                                                                        <asp:Label ID="lbl_monto_moneda" runat="server" Text="$us"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="middle">
                                                                                            <asp:ImageButton ID="btn_ver_monto_digitado" runat="server" ImageUrl="~/images/cambiar.gif"
                                                                                                CausesValidation="true" ValidationGroup="monto" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table align="center">
                                                                                                <%--<tr><td align="left" class="cajaPagoTdEnun">Monto mínimo a pagar para ponerce al día:</td></tr>--%>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:GridView ID="gv_pago_minimo" SkinID="gvCajaPagos" runat="server" AutoGenerateColumns="false">
                                                                                                            <Columns>
                                                                                                                <%--<asp:BoundField HeaderText="F.Pago Int." DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                                                <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />--%>
                                                                                                                <asp:BoundField HeaderText="Nºdias Int." DataField="interes_dias" />
                                                                                                                <asp:BoundField HeaderText="Cuota" DataField="string_cuotas" />
                                                                                                                <asp:BoundField HeaderText="Pago" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}"
                                                                                                                    ItemStyle-CssClass="cajaGvCellTotal" />
                                                                                                                <asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                                                <asp:BoundField HeaderText="Manten." DataField="mantenimiento_sus" HtmlEncode="false"
                                                                                                                    DataFormatString="{0:F2}" />
                                                                                                                <asp:BoundField HeaderText="Interés" DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                                                <asp:BoundField HeaderText="Amortiz." DataField="amortizacion" HtmlEncode="false"
                                                                                                                    DataFormatString="{0:F2}" />
                                                                                                                <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdButton">
                                                                <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" CausesValidation="true"
                                                                    ValidationGroup="monto" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdMsg">
                                                                <asp:ValidationSummary ID="vs_monto" runat="server" DisplayMode="List" ValidationGroup="monto" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel runat="server" ID="pnlUrlFactura" Visible="false">
                                                                <asp:HyperLink ID="hlFactura" runat="server" Text="Enlace a la Factura" NavigateUrl="#"
                                                                    Target="_blank">
                                                                </asp:HyperLink>
                                                            </asp:Panel>
                                                            <asp:Panel ID="panel_correo_factura" runat="server" GroupingText="Correo para envio de la factura" Visible="false">
                                                                <asp:Label ID="Label1" runat="server" Text="Correo: "></asp:Label> <asp:TextBox ID="txtCorreoFactura" runat="server" Text=""></asp:TextBox>
                                                            </asp:Panel>
                                                            <br />
                                                            <uc3:cajaRealizarPago ID="CajaRealizarPago1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
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
