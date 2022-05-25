<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pago por venta de servicios a Cliente Transitorio" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Src="~/recurso/caja/pagoOtroServicioNoCliente/userControl/pagoOtroServicioNoClienteFormCliente.ascx"
    TagName="pagoOtroServicioNoClienteFormCliente" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago"
    TagPrefix="uc3" %>
<script runat="server">

    Protected Property strServ() As String
        Get
            Return lbl_strServ.Text
        End Get
        Set(ByVal value As String)
            lbl_strServ.Text = value
        End Set
    End Property
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value

            lbl_precio_moneda.Text = "P.Unit.(" & value & ")"
            lbl_total_moneda.Text = "(" & value & ")"

            gv_servicios.Columns(3).HeaderText = "Precio unit.(" & value & ")"
            gv_servicios.Columns(4).HeaderText = "Precio total(" & value & ")"
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler CajaRealizarPago1.Eleccion_aceptar, AddressOf CajaRealizarPago_Aceptar
        AddHandler CajaRealizarPago1.Eleccion_cancelar, AddressOf CajaRealizarPago_Cancelar
        If parametro_facturacion.ActivoActual = 0 Or tipo_cambio.Actual = 0 Then
            Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
        Else
            codigo_moneda = "$us"
        End If
    End Sub


    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        If gv_servicios.Rows.Count > 0 Then
            If PagOtrServNoCli1.Verificar = True Then
                Dim permiso_efectivo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoOtroServicioNoCliente", "efectivo")
                Dim con_factura As Boolean = False
                For Each row As GridViewRow In Me.gv_servicios.Rows
                    Dim chk As CheckBox = CType(gv_servicios.Rows.Item(row.RowIndex).Cells(5).Controls.Item(0), CheckBox)
                    If chk.Checked = True Then
                        con_factura = True
                        Exit For
                    End If
                Next
                CajaRealizarPago1.Cargar(tmpServicio.PrecioTotal(strServ), permiso_efectivo.Equals(False), False, con_factura, 0, codigo_moneda)
                CajaRealizarPago1.factura_cliente = PagOtrServNoCli1.paterno
                CajaRealizarPago1.factura_nit = PagOtrServNoCli1.nit
                MultiView1.ActiveViewIndex = 1
                
                '-- Facturacion Sintesis
                If con_factura Then
                    panel_correo_factura.Visible = True
                    txtCorreoFactura.Text = ""
                Else
                    panel_correo_factura.Visible = False
                End If
                '--                 
            Else
                Msg1.Text = "Debe introducir los datos del cliente"
            End If
        Else
            Msg1.Text = "No se agregó ningún servicio."
        End If

    End Sub

    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            pnlUrlFactura.Visible = False
        
            '-- Facturacion Sintesis
            Dim conFactura As Boolean = False
            Dim listaServ As List(Of tmpServicio) = tmpServicio.ListaServicio(strServ)
            For Each serv As tmpServicio In listaServ
                If serv.facturar Then
                    conFactura = True
                    Exit For
                End If
            Next
            
            Dim aut As WSFacturacion.Autenticacion = New WSFacturacion.Autenticacion()
            Dim autRes As WSFacturacion.AutenticacionRes = New WSFacturacion.AutenticacionRes()
            Dim usuario As String = ConfigurationManager.AppSettings("usuarioSintesis").ToString()
            Dim password As String = ConfigurationManager.AppSettings("passwordSintesis").ToString()
            Dim businessCode As String = ConfigurationManager.AppSettings("businessCodeSintesis").ToString()
            Dim token As String = ""
            
            If conFactura Then
                If CajaRealizarPago1.dato_cliente_nit = 0 Then
                    Msg2.Text = "Debe ingresar un NIT"
                    Exit Sub
                End If
                
                If txtCorreoFactura.Text <> "" Then
                    If Not logica.ValidaEmail(txtCorreoFactura.Text) Then
                        Msg2.Text = "La dirección E-Mail es incorrecta"
                        txtCorreoFactura.Focus()
                        Exit Sub
                    End If
                End If
                
                aut.username = usuario
                aut.password = password
                Dim objLogin As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                autRes = objLogin.Autenticar(aut)
                If autRes.code <> 200 Then
                    Msg2.Text = "Error en la Conexión a Sintesis"
                    Exit Sub
                Else
                    token = autRes.body.idToken
                End If
            End If
            '--
        
            If PagOtrServNoCli1.Verificar() = True Then
                ' Facturacion Sintesis
                Dim id_transaccion As Integer = 0
                Dim tr As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim listaServicio As List(Of tmpServicio2) = servicio_vendido.Insertar_PagoOtroServicioNoClientes_VARIOS_PAGOS2(Profile.id_usuario, Profile.entorno.id_rol, CajaRealizarPago1.dato_id_recibo_cobrador, strServ, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar, PagOtrServNoCli1.ci, PagOtrServNoCli1.id_cliente, PagOtrServNoCli1.id_lugarcedula, PagOtrServNoCli1.paterno, PagOtrServNoCli1.materno, PagOtrServNoCli1.nombres, PagOtrServNoCli1.nit, PagOtrServNoCli1.celular, PagOtrServNoCli1.email)

                Dim Mensaje As String = ""
                Dim ErrorFacturas As String = ""
                Dim ErrorObtenerFacturas As String = ""
                Dim ErrorActualizaFacturas As String = ""
                Dim listaFacturas As List(Of String) = New List(Of String)()
                
                If listaServicio.Count > 0 Then
                    For Each servicio As tmpServicio2 In listaServicio
                        tr.Append(servicio.id_transaccion.ToString() + ",")
                    Next
                    'En este punto se despliegan: la factura, el recibo y el comprobante
                    CajaRealizarPago1.Pago_Realizado(tr.ToString().TrimEnd(","))
                
                    Dim codigoMoneda As String = "1"
                    Dim codigoMetodoPago As String = ""
                    Dim numeroTarjeta As String = ""

                    ' Forma de Pago
                    codigoMetodoPago = logica.MetodoPagoFacturacion(CajaRealizarPago1.dato_FormaPagoCliente)
                    If codigoMetodoPago = "10" Or codigoMetodoPago = "2" Then
                        numeroTarjeta = CajaRealizarPago1.dato_FormaPagoCliente.tarjeta_numero
                    End If
                
                    For Each servicio As tmpServicio2 In listaServicio
                        If servicio.facturar Then
                            id_transaccion = servicio.id_transaccion.ToString()
                    
                            ' Obtener la factura
                            Dim Id_factura As Integer = terrasur.factura.IdPorTransaccion(id_transaccion)
                            Dim fact As factura = New factura(Id_factura)
                            Dim Nro_factura As String = fact.num_factura.ToString()
                    
                            ' Obtener datos del cliente
                            Dim codigoCliente As String = "N/A"
                    
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
                            facturaCabecera.codigoCliente = codigoCliente ' Este campo no puede estar vacio
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
                            If servicio.nombre.Contains("ALQUILER") Then
                                facturaDetalle.codigoProducto = "3" ' PAGO ALQUILERES
                            Else
                                facturaDetalle.codigoProducto = "2" ' PAGO OTROS SERVICIOS
                            End If
                            
                            facturaDetalle.descripcion = servicio.nombre
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
                                ' Obtener el enlace de la representacion grafica
                                objFacturacion = New WSFacturacion.WSFacturacion()
                                Dim urlFactura As String = objFacturacion.RepGraficaFacturaOficio(token, factRes.body.cuf, "bbr")
                                If urlFactura <> "" Then
                                    listaFacturas.Add(urlFactura)
                                    Dim hl As New HyperLink
                                    hl.ID = Nro_factura
                                    hl.Text = "Enlace a la Factura " & Nro_factura
                                    hl.Target = "_blank"
                                    hl.NavigateUrl = urlFactura
                                    Me.pnlUrlFactura.Controls.Add(hl)
                                    Me.pnlUrlFactura.Controls.Add(New LiteralControl("<br />"))
                                    pnlUrlFactura.Visible = True
                                Else
                                    ErrorObtenerFacturas = ErrorObtenerFacturas & Nro_factura & ", "
                                End If
                                
                                ' Actualizar datos en tabla factura
                                Dim factActualizada As Boolean = terrasur.factura.ActualizarDatos(Id_factura, factRes.body.cuf, urlFactura, txtCorreoFactura.Text)
                                If Not factActualizada Then
                                    ErrorActualizaFacturas = ErrorActualizaFacturas & Nro_factura & ", "
                                End If
                            Else
                                ErrorFacturas = ErrorFacturas & Nro_factura & ", "
                            End If
                        End If
                    Next
                    
                    If conFactura Then
                        ErrorFacturas = ErrorFacturas.Trim.TrimEnd(",")
                        ErrorObtenerFacturas = ErrorObtenerFacturas.Trim.TrimEnd(",")
                        ErrorActualizaFacturas = ErrorActualizaFacturas.Trim.TrimEnd(",")
                        
                        If ErrorFacturas = "" And ErrorObtenerFacturas = "" And ErrorActualizaFacturas = "" Then
                            Mensaje = "PAGO REALIZADO"
                        Else
                            Mensaje = "PAGO REALIZADO CON ERRORES: "
                        End If

                        If ErrorFacturas <> "" Then
                            Mensaje = Mensaje & "ERROR EN EL REGISTRO DE FACTURA(S) EN SINTESIS: " & ErrorFacturas & "; "
                        End If

                        If ErrorObtenerFacturas <> "" Then
                            Mensaje = Mensaje & "ERROR AL OBTENER LA REPRESENTACION GRAFICA DE LA(S) FACTURA(S): " & ErrorObtenerFacturas & "; "
                        End If

                        If ErrorActualizaFacturas <> "" Then
                            Mensaje = Mensaje & "ERROR AL ACTUALIZAR DATOS DE LAS FACTURA(S): " & ErrorActualizaFacturas & "; "
                        End If

                        If listaFacturas.Count > 0 Then
                            pnlUrlFactura.Visible = True
                            ' Enviar Correo
                            If txtCorreoFactura.Text <> "" Then
                                If Not logica.enviarCorreoLista(listaFacturas, txtCorreoFactura.Text, "Factura(s) de su pago BBR") Then
                                    Mensaje = Mensaje + "; " + "ERROR AL ENVIAR CORREO"
                                End If
                            End If
                        Else
                            pnlUrlFactura.Visible = False
                        End If

                        Mensaje = Mensaje.Trim.TrimEnd(";")
                        Msg2.Text = Mensaje
                    Else
                        Msg2.Text = "PAGO REALIZADO"
                        pnlUrlFactura.Visible = False
                    End If
                Else
                    Msg2.Text = "EL PAGO NO SE REALIZÓ CORRECTAMENTE"
                End If
            Else
                Msg2.Text = "Se han realizado cambios al CI del cliente, por favor verifique el mismo nuevamente"
            End If
        Catch ex As Exception
            Msg2.Text = "Error: " & ex.Message
        End Try
    End Sub

    Protected Sub CajaRealizarPago_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub ddl_servicio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarDatosServicio()
    End Sub

    Protected Sub ddl_servicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarDatosServicio()
    End Sub

    Sub CargarDatosServicio()
        If (ddl_servicio.Items.Count > 0) Then
            Dim servicioObj As New servicio(Int32.Parse(ddl_servicio.SelectedValue))
            If servicioObj.codigo <> "ICA" Then
                txt_unidades.Text = "1"
                txt_unidades.Enabled = servicioObj.varios
                txt_precio.Enabled = True
                txt_precio.Text = servicioObj.valor_sus.ToString()
                ddl_factura.Enabled = True
                ddl_factura.SelectedValue = servicioObj.facturar.ToString()
                btn_agregar.Enabled = True
            Else
                txt_unidades.Text = "0"
                txt_unidades.Enabled = False
                txt_precio.Enabled = False
                txt_precio.Text = 0
                ddl_factura.SelectedValue = servicioObj.facturar.ToString()
                ddl_factura.Enabled = False
                btn_agregar.Enabled = False
            End If
        Else
            btn_agregar.Enabled = False
        End If
    End Sub

    Protected Sub btn_agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ''-- Facturacion Sintesis
        'If gv_servicios.Rows.Count > 0 Then
        '    Msg1.Text = "Solo se puede agregar un servicio a la vez."
        '    Exit Sub
        'End If
        ''--
        
        If (tmpServicio.Verificar(strServ, Int32.Parse(ddl_servicio.SelectedValue)) = False) Then
            Dim servObj As New servicio(Int32.Parse(ddl_servicio.SelectedValue))
            strServ = tmpServicio.Insertar(strServ, servObj.id_servicio, servObj.nombre, Int32.Parse(txt_unidades.Text.Trim()), Decimal.Parse(txt_precio.Text.Trim()), Decimal.Parse(txt_precio.Text.Trim()) * Int32.Parse(txt_unidades.Text.Trim()), Boolean.Parse(ddl_factura.SelectedValue), "")
            'Msg1.Text = "El servicio elegido se agregó correctamente"
            'Msg1.Show = False
            gv_servicios.DataBind()
        Else
            Msg1.Text = "El servicio elegido ya se agregó previamente"
        End If
    End Sub

    Protected Sub gv_servicios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    CType(e.Row.Cells(0).Controls(0), LinkButton).OnClientClick = "return confirm('¿Esta seguro que desea retirar el servicio?');"
        'End If
    End Sub

    Protected Sub gv_servicios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If (e.CommandName = "retirar") Then
            strServ = tmpServicio.Eliminar(strServ, Int32.Parse(e.CommandArgument.ToString()))
            gv_servicios.DataBind()
        End If
    End Sub

    Protected Sub gv_servicios_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        If (gv_servicios.Rows.Count > 0) Then
            Dim precio_total As Decimal = tmpServicio.PrecioTotal(strServ)
            lbl_total_pagar_sus.Text = precio_total.ToString("F2")
        Else
            lbl_total_pagar_sus.Text = "0"
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="pagoOtroServicioNoCliente"
        MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../js/scriptjs.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    <asp:Label ID="lbl_strServ" runat="server" Visible="false"></asp:Label>
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Pago por venta de servicios a Cliente Transitorio
            </td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdGrid">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <table align="center" width="100%">
                                                    <tr>
                                                        <td class="tdEncabezado">
                                                            <uc2:pagoOtroServicioNoClienteFormCliente ID="PagOtrServNoCli1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="panel_pago" runat="server" GroupingText="Servicios vendidos" DefaultButton="btn_pagar">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" RenderMode="Inline"
                                                                    UpdateMode="Always">
                                                                    <ContentTemplate>
                                                                        <table align="center" width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table align="left">
                                                                                        <tr>
                                                                                            <td class="contratoFormTdMsg" colspan="5">
                                                                                                <asp:Label ID="Msg1" runat="server" SkinID="lblMsg" EnableViewState="false"></asp:Label>
                                                                                                <asp:ValidationSummary ID="vs_servicio" runat="server" DisplayMode="List" ValidationGroup="servicio_agregar" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="contratoFormTdHorEnun">
                                                                                                Servicio
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorEnun">
                                                                                                Nº unid./cuo.
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorEnun">
                                                                                                <asp:Label ID="lbl_precio_moneda" runat="server" Text="P.Unit.($us)"></asp:Label>
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorEnun">
                                                                                                Emitir Fact.
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorEnun">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="contratoFormTdHorDato">
                                                                                                <asp:DropDownList ID="ddl_servicio" runat="server" AutoPostBack="true" DataTextField="nombre"
                                                                                                    DataValueField="id_servicio" DataSourceID="ods_lista_servicio_activo" OnDataBound="ddl_servicio_DataBound"
                                                                                                    OnSelectedIndexChanged="ddl_servicio_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="rfv_servicio" runat="server" ControlToValidate="ddl_servicio"
                                                                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio_agregar" Text="*"
                                                                                                    ErrorMessage="Debe elegir un servicio"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorDato">
                                                                                                <asp:TextBox ID="txt_unidades" runat="server" SkinID="txtSingleLine50" MaxLength="3"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="rfv_unidades" runat="server" ControlToValidate="txt_unidades"
                                                                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio_agregar" Text="*"
                                                                                                    ErrorMessage="Debe introducir el Nº de unidades"></asp:RequiredFieldValidator>
                                                                                                <asp:RangeValidator ID="rv_unidades" runat="server" ControlToValidate="txt_unidades"
                                                                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio_agregar" Type="Integer"
                                                                                                    MinimumValue="1" MaximumValue="999" Text="*" ErrorMessage="El Nº de unidades debe ser un número entero positivo"></asp:RangeValidator>
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorDato">
                                                                                                <asp:TextBox ID="txt_precio" runat="server" SkinID="txtSingleLine50" MaxLength="8"
                                                                                                    onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="rfv_precio" runat="server" ControlToValidate="txt_precio"
                                                                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio_agregar" Text="*"
                                                                                                    ErrorMessage="Debe introducir el Precio Unitario"></asp:RequiredFieldValidator>
                                                                                                <asp:RangeValidator ID="rv_precio" runat="server" ControlToValidate="txt_precio"
                                                                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="servicio_agregar" Type="Double"
                                                                                                    MinimumValue="0,01" MaximumValue="99999" Text="*" ErrorMessage="El precio unitario debe ser un número positivo"></asp:RangeValidator>
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorDato">
                                                                                                <asp:RadioButtonList ID="ddl_factura" runat="server" RepeatDirection="Horizontal"
                                                                                                    CellPadding="0" CellSpacing="0">
                                                                                                    <asp:ListItem Value="True" Selected="True" Text="Si"></asp:ListItem>
                                                                                                    <asp:ListItem Value="False" Text="No"></asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                            <td class="contratoFormTdHorDato">
                                                                                                <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CausesValidation="true"
                                                                                                    ValidationGroup="servicio_agregar" OnClick="btn_agregar_Click" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="panel_pagos" runat="server">
                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:GridView ID="gv_servicios" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_servicios_tmp"
                                                                                                        DataKeyNames="id_servicio" OnRowDataBound="gv_servicios_RowDataBound" OnRowCommand="gv_servicios_RowCommand"
                                                                                                        OnDataBound="gv_servicios_DataBound">
                                                                                                        <Columns>
                                                                                                            <asp:ButtonField Text="Retirar" CommandName="retirar" ControlStyle-CssClass="gvButton" />
                                                                                                            <asp:BoundField HeaderText="Servicio" DataField="nombre" />
                                                                                                            <asp:BoundField HeaderText="Nº unidades" DataField="unidades" ItemStyle-CssClass="gvCell1" />
                                                                                                            <asp:BoundField HeaderText="Precio unit. ($us)" DataField="precio_unitario" ItemStyle-CssClass="gvCell1" />
                                                                                                            <asp:BoundField HeaderText="Precio total ($us)" DataField="precio_total" ItemStyle-CssClass="gvCell1" />
                                                                                                            <asp:CheckBoxField HeaderText="Facturar" DataField="facturar" Text="emitir factura" />
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <table align="center">
                                                                                            <tr>
                                                                                                <td class="cajaPagoTdEnun">
                                                                                                    Total a pagar:
                                                                                                </td>
                                                                                                <td class="cajaPagoTdDato">
                                                                                                    <asp:Label ID="lbl_total_pagar_sus" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td class="cajaPagoTdEnun">
                                                                                                    <asp:Label ID="lbl_total_moneda" runat="server" Text="($us)"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdButton">
                                                                <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" CausesValidation="true"
                                                                    ValidationGroup="servicio" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <asp:Msg ID="Msg2" runat="server"></asp:Msg>
                                                <asp:Panel runat="server" ID="pnlUrlFactura" Visible="false">
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
    <%--  [id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo],[num_pagos]--%>
    <asp:ObjectDataSource ID="ods_lista_servicio_activo" runat="server" TypeName="terrasur.servicio"
        SelectMethod="ListaActivosParaVenta"></asp:ObjectDataSource>
    <%--[id_servicio],[nombre],[unidades],[precio_unitario],[precio_total]--%>
    <asp:ObjectDataSource ID="ods_lista_servicios_tmp" runat="server" TypeName="terrasur.tmpServicio"
        SelectMethod="TablaServicio">
        <SelectParameters>
            <asp:ControlParameter Name="strServ" Type="String" ControlID="lbl_strServ" PropertyName="Text" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
