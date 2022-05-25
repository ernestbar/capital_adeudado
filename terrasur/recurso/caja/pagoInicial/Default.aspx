<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pago de Cuota Inicial" %>

<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago" TagPrefix="uc3" %>

<script runat="server">
    Protected Property monto() As Decimal
        Get
            Return Decimal.Parse(lbl_monto.Text)
        End Get
        Set(ByVal value As Decimal)
            lbl_monto.Text = value
        End Set
    End Property
    Protected Property venta_lote() As Boolean
        Get
            Return Boolean.Parse(lbl_venta_lote.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_venta_lote.Text = value
        End Set
    End Property
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            lbl_inicial_moneda.Text = value
            lbl_saldo_moneda.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler CajaRealizarPago1.Eleccion_aceptar, AddressOf CajaRealizarPago_Aceptar
        AddHandler CajaRealizarPago1.Eleccion_cancelar, AddressOf CajaRealizarPago_Cancelar
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
        Dim c As New contrato(ContratoDatos1.id_contrato)
        txt_inicial.Text = c.cuota_inicial.ToString("F2")
        lbl_saldo.Text = (c.precio_final - c.cuota_inicial).ToString("F2")
        
        monto = c.cuota_inicial
        venta_lote = c.venta_lote
    End Sub
    
    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        Dim permiso_efectibo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoInicial", "efectivo")
        CajaRealizarPago1.Cargar(monto, permiso_efectibo.Equals(False), True, venta_lote.Equals(False), ContratoDatos1.id_contrato, codigo_moneda)
        
        Session("permitir_pagar") = "si"
        MultiView1.ActiveViewIndex = 1

        btn_otro_contrato.Visible = False
        btn_otro_pago.Visible = False
        
        ' Facturacion Sintesis
        Dim conFactura As Boolean = False
        Dim contVenta As contrato_venta = New contrato_venta(ContratoDatos1.id_contrato)
        If contVenta.venta_lote = False Then
            conFactura = True
        End If
        If conFactura Then
            panel_correo_factura.Visible = True
            txtCorreoFactura.Text = ""
        Else
            panel_correo_factura.Visible = False
        End If
        '
    End Sub
    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Session("permitir_pagar") = "si" Then
                pnlUrlFactura.Visible = False
                
                ' Facturacion Sintesis
                Dim conFactura As Boolean = False
                Dim contVenta As contrato_venta = New contrato_venta(ContratoDatos1.id_contrato)
                If contVenta.venta_lote = False Then
                    conFactura = True
                End If

                Dim aut As WSFacturacion.Autenticacion = New WSFacturacion.Autenticacion()
                Dim autRes As WSFacturacion.AutenticacionRes = New WSFacturacion.AutenticacionRes()
                Dim usuario As String = ConfigurationManager.AppSettings("usuarioSintesis").ToString()
                Dim password As String = ConfigurationManager.AppSettings("passwordSintesis").ToString()
                Dim businessCode As String = ConfigurationManager.AppSettings("businessCodeSintesis").ToString()
                Dim token As String = ""
        
                If conFactura Then
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
                '

                Dim id_transaccion As Integer = pago.Insertar_PagoInicial(Profile.id_usuario, Profile.entorno.id_rol, ContratoDatos1.id_contrato, CajaRealizarPago1.dato_id_recibo_cobrador, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar)
                If id_transaccion > 0 Then
                    ContratoDatos1.id_contrato = ContratoDatos1.id_contrato
                    'En este punto se despliegan: la factura, el recibo y el comprobante
                    CajaRealizarPago1.Pago_Realizado(id_transaccion.ToString)
                    
                    '-- Facturacion Sintesis
                    If conFactura Then
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
                        facturaDetalle.codigoProducto = "2" ' PAGO OTROS SERVICIOS
                        facturaDetalle.descripcion = "PAGO OTROS SERVICIOS"
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
                                Msg1.Text = "ERROR AL ACTUALIZAR EL DATOS DE LA FACTURA NRO. " & Nro_factura
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
                'Session("id_contrato") = ContratoDatos1.id_contrato
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
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

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaMaster ID="CajaMaster1" runat="server" tipo_pago="pagoInicial" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_monto" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_venta_lote" runat="server" Text="True" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Pago de Cuota Inicial</td></tr>
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
                                                <asp:Panel ID="panel_pago" runat="server" GroupingText="Cuota Inicial">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table align="center">
                                                                    <tr>
                                                                        <td class="cajaPagoTdEnun">Total a pagar:</td>
                                                                        <td class="cajaPagoTdDato"><asp:TextBox ID="txt_inicial" runat="server" SkinID="txtCajaPagoMonto" MaxLength="9" Enabled="false"></asp:TextBox></td>
                                                                        <td class="cajaPagoTdEnun"><asp:Label ID="lbl_inicial_moneda" runat="server" Text="$us"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cajaPagoTdEnun">Saldo a capital:</td>
                                                                        <td class="cajaPagoTdDato"><div style="text-align:right;"><asp:Label ID="lbl_saldo" runat="server"></asp:Label></div></td>
                                                                        <td class="cajaPagoTdEnun"><asp:Label ID="lbl_saldo_moneda" runat="server" Text="$us"></asp:Label></td>
                                                                        <td class="cajaPagoTdDato" colspan="3"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdButton">
                                                                <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <asp:Panel runat="server" ID="pnlUrlFactura" Visible ="false">
                                                    <asp:HyperLink ID="hlFactura" runat="server" Text="Enlace a la Factura" NavigateUrl="#" Target="_blank"></asp:HyperLink>
                                                </asp:Panel>
                                                <asp:Panel ID="panel_correo_factura" runat="server" GroupingText="Correo para envio de la factura" Visible="true">
                                                    <asp:Label ID="Label1" runat="server" Text="Correo: "></asp:Label> <asp:TextBox ID="txtCorreoFactura" runat="server" Text=""></asp:TextBox>
                                                </asp:Panel>
                                                <br />
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
