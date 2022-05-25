<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación / reimpresión de facturas" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/caja/userControl/cajaImpresion.ascx" TagName="cajaImpresion" TagPrefix="uc2" %>
<%@ Register src="~/recurso/caja/userControl/cajaImpresionNueva.ascx" tagname="cajaImpresionNueva" tagprefix="uc3" %>

<script runat="server">  
    Protected Property id_factura() As Integer
        Get
            Return Integer.Parse(lbl_id_factura.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_factura.Text = value
        End Set
    End Property
    Protected Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If parametro_facturacion.ActivoActual = 0 Or tipo_cambio.Actual = 0 Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            Else
                txt_no_factura.Focus()
            End If
        End If
    End Sub

    Sub Reset()
        panel_datos_factura.Visible = False
        panel_datos_factura_nueva.Visible = False
        panel_beneficiario.Visible = False
        rb_reimprimir.Checked = True
        rb_anular.Checked = False
        panel_reimpresion.Visible = False
        panel_anterior.Visible = False
        panel_nuevo.Visible = False
        CajaImpresionFacturas.btn_imprimir_1.Visible = False
        CajaImpresionFacturas.wv_documento_1.Visible = False
        CajaImpresionFacturasNuevo.btn_imprimir_1.Visible = False
        CajaImpresionFacturasNuevo.wv_documento_1.Visible = False
    End Sub
    
    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        Dim Idfactura As Integer
        Idfactura = factura.IdPorNumeroFecha(Integer.Parse(rbl_sucursal.SelectedValue), Integer.Parse(txt_no_factura.Text), cp_fecha.SelectedDate, Integer.Parse(rbl_negocio.SelectedValue))
        Reset()
        ResetBeneficiario("")
        If Idfactura > 0 Then
            ' Facturacion Sintesis
            Dim Cuf As String = ""
            Dim Url As String = ""
            Dim NroFactura As Integer = 0
            Dim objFactura As factura = New factura(Idfactura)
            NroFactura = objFactura.num_factura
            Dim dtFactura As DataTable = terrasur.factura.RecuperarDatosNuevos(Idfactura)
            If dtFactura.Rows.Count > 0 Then
                Cuf = dtFactura.Rows(0)("cuf").ToString()
                Url = dtFactura.Rows(0)("url").ToString()
            End If
            '
            If Cuf <> "" Then
                panel_datos_factura_nueva.Visible = True
                hlFactura.NavigateUrl = "#"
                hlFactura.Text = ""
                
                If Url <> "" Then
                    hlFactura.NavigateUrl = Url
                Else
                    Dim aut As WSFacturacion.Autenticacion = New WSFacturacion.Autenticacion()
                    Dim autRes As WSFacturacion.AutenticacionRes = New WSFacturacion.AutenticacionRes()
                    Dim usuario As String = ConfigurationManager.AppSettings("usuarioSintesis").ToString()
                    Dim password As String = ConfigurationManager.AppSettings("passwordSintesis").ToString()
                    Dim token As String = ""
                    
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
                    
                    ' Obtener el enlace de la representacion grafica
                    Dim objFacturacion As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                    objFacturacion = New WSFacturacion.WSFacturacion()
                    Url = objFacturacion.RepGraficaFacturaOficio(token, Cuf, "bbr")
                    If Url <> "" Then
                        hlFactura.NavigateUrl = Url
                        hlFactura.Text &= "Enlace a la Factura " & NroFactura
                        ' Actualizar datos en tabla factura
                        Dim factActualizada As Boolean = terrasur.factura.ActualizarDatos(Idfactura, "", Url, "")
                        If Not factActualizada Then
                            Msg1.Text = "ERROR AL ACTUALIZAR DATOS DE LA FACTURA NRO. " & NroFactura
                            Exit Sub
                        End If
                    Else
                        Msg1.Text = "ERROR AL OBTENER LA REPRESENTACION GRAFICA DE LA FACTURA NRO. " & NroFactura & " EN SINTESIS"
                        Exit Sub
                    End If
                End If
            Else
                panel_datos_factura.Visible = True
                id_factura = Idfactura
                Dim f As New factura(Idfactura)
                Dim Idcontrato As Integer = factura.IdContrato(Idfactura)
                id_contrato = Idcontrato
                If Idcontrato > 0 Then
                    lbl_no_contrato.Text = New contrato(Idcontrato).numero
                Else
                    lbl_no_contrato.Text = "-------"
                End If
                lbl_no_factura.Text = f.num_factura.ToString()
                lbl_no_control.Text = f.numero_control.ToString()
                lbl_fecha_emision.Text = f.fecha.ToString("d")
                lbl_monto_bs.Text = f.monto_bs.ToString("F2")
                lbl_cliente.Text = f.cliente_nombre.ToString()
                lbl_nit.Text = f.cliente_nit.ToString()
                lbl_concepto.Text = f.concepto.ToString()
                lbl_usuario.Text = New usuario(New transaccion(f.id_transaccion).id_usuario).nombre_usuario.ToString()
                'VERIFICAR PERMISOS PARA REIMPRIMIR O ANULAR
                rb_reimprimir.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_reimprimir")
                If rb_reimprimir.Enabled = False Then
                    rb_anular.Checked = True
                End If
                If DateTime.Parse(f.fecha.ToString("d")) = DateTime.Parse(Date.Now.ToString("d")) Then
                    If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_anular_dia") = True Then
                        rb_anular.Visible = True
                    Else
                        If f.fecha.ToString("MM/yyyy") = Date.Now.ToString("MM/yyyy") Then
                            rb_anular.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_anular_mes")
                        Else
                            rb_anular.Visible = False
                        End If
                    End If
                Else
                    'SI LA FECHA DE LA EMISION ES MENOR A LA FECHA ACTUAL SE VERIFICA QUE SE ENCUENTRE EN EL MISMO MES Y TENGA EL PERMISO PARA LA ANULACION
                    If DateTime.Parse(f.fecha.ToString("d")) < DateTime.Parse(Date.Now.ToString("d")) Then
                        If f.fecha.ToString("MM/yyyy") = Date.Now.ToString("MM/yyyy") Then
                            rb_anular.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_anular_mes")
                        Else
                            rb_anular.Visible = False
                        End If
                    End If
                End If
                If f.anulado = False Then
                    lbl_estado.Text = "Activa"
                Else
                    lbl_estado.Text = "Anulada"
                    rb_anular.Visible = False
                End If
            End If
        Else
            Msg1.Text = "No se encontró ninguna factura."
        End If
    End Sub

    Protected Sub rb_anular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_anular.CheckedChanged
        panel_beneficiario.Visible = True
        ResetBeneficiario("actual")
        VerficarPermisos()
    End Sub
        
    Sub VerficarPermisos()
        rbl_beneficiario.Items.Item(1).Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_temporal")
        rbl_beneficiario.Items.Item(2).Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_permanente")
    End Sub
    
    Protected Sub rb_reimprimir_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_reimprimir.CheckedChanged
        panel_beneficiario.Visible = False
        ResetBeneficiario("")
    End Sub
    
    Protected Sub rbl_beneficiario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ResetBeneficiario(rbl_beneficiario.SelectedValue)
    End Sub
    
    Sub ResetBeneficiario(ByVal Tipo As String)
        Select Case Tipo
            Case "actual"
                Dim f As New factura(id_factura)
                txt_cliente.Text = f.cliente_nombre.ToString()
                txt_cliente.Enabled = False
                txt_nit.Text = f.cliente_nit.ToString()
                txt_nit.Enabled = False
            Case "modificar"
                txt_cliente.Enabled = True
                txt_nit.Enabled = True
                txt_cliente.Focus()
            Case "modificar_guardar"
                txt_cliente.Enabled = True
                txt_nit.Enabled = True
                txt_cliente.Focus()
            Case Else
                txt_cliente.Text = ""
                txt_cliente.Enabled = True
                txt_nit.Text = ""
                txt_nit.Enabled = True
                rbl_beneficiario.SelectedValue = "actual"
        End Select
    End Sub
    
    Protected Sub btn_accion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_accion.Click
        If rb_reimprimir.Checked = True Then
            'SE HABILITA EL WEBVIEWER CON EL ID DE LA TRANSACCION DE LA FACTURA A REIMPRIMIR
            Dim f As New factura(id_factura)
            ImprimirDocumento(f.id_transaccion.ToString, True)
        Else
            If rb_anular.Checked = True Then
                'SE REALIZA LA ANULACION
                Dim cliente_guardar As Boolean = False
                If rbl_beneficiario.SelectedValue = "modificar_guardar" Then
                    cliente_guardar = True
                End If
                Dim id_transaccion As Integer = factura.AnularReimprimir(id_factura, Profile.id_usuario, Profile.entorno.id_rol, id_contrato, txt_cliente.Text, Decimal.Parse(txt_nit.Text), cliente_guardar)
                If id_transaccion > 0 Then
                    Msg1.Text = "FACTURA ANULADA"
                    Reset()
                    'En este punto se despliega: la factura
                    id_factura = factura.IdPorTransaccion(id_transaccion)
                    ImprimirDocumento(id_transaccion.ToString, False)
                Else
                    Msg1.Text = "LA ANULACION DE LA FACTURA NO SE REALIZÓ CORRECTAMENTE"
                End If
            End If
        End If
    End Sub
   
    Sub ImprimirDocumento(ByVal transacciones As String, ByVal reimpresion As Boolean)
        If ConfigurationManager.AppSettings("impresoras_red") = "si" Then
            panel_reimpresion.Visible = True
            panel_anterior.Visible = False
            panel_nuevo.Visible = True
            CajaImpresionFacturasNuevo.MostrarDocumento("Factura", transacciones, reimpresion, id_factura, 600, 400)
        Else
            If (CajaImpresionFacturas.VerificarDocumento("Factura", transacciones) = True) Or reimpresion = True Then
                panel_reimpresion.Visible = True
                panel_anterior.Visible = True
                panel_nuevo.Visible = False
                CajaImpresionFacturas.MostrarDocumento("Factura", transacciones, reimpresion, id_factura, 600, 400)
            Else
                panel_reimpresion.Visible = False
                panel_anterior.Visible = False
                panel_nuevo.Visible = False
            End If
        End If
    End Sub

    Protected Sub rbl_sucursal_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_sucursal.DataBound
        Dim id_sucursal_predeterminada As Integer = sucursal.IdSucursalPorNum(Integer.Parse(ConfigurationManager.AppSettings("num_sucursal")))
        If rbl_sucursal.Items.FindByValue(id_sucursal_predeterminada) IsNot Nothing Then
            rbl_sucursal.SelectedValue = id_sucursal_predeterminada
        ElseIf rbl_sucursal.Items.Count > 0 Then
            rbl_sucursal.SelectedIndex = 0
        End If
        For Each item As ListItem In rbl_sucursal.Items
            If item.Text = "BNB" Or item.Text = "SINTESIS" Then
                item.Enabled = False
            End If
        Next
        btn_busqueda.Enabled = rbl_sucursal.Items.Count.Equals(0).Equals(False)
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaMaster ID="CajaMaster1" runat="server"  Visible="false"  />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
<asp:Label runat="server" id="lbl_id_contrato" Visible="false"  Text="0"/>
<asp:Label runat="server" id="lbl_id_factura" Visible="false"  Text="0"/>
<table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdMsg">
                            <asp:Msg ID="Msg1" runat="server">
                            </asp:Msg>
                            <asp:ValidationSummary ID="vs_anulacion" runat="server" DisplayMode="List" ValidationGroup="anulacion" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdFiltro">
                            <asp:Panel ID="panel_busqueda" runat="server" Width="100%" DefaultButton="btn_busqueda">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="viewTdTitle" colspan="2">
                                            <asp:Label ID="lbl_title" runat="server" Text="Anulación / reimpresión de facturas"  ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_negocio" runat="server" DataSourceID="ods_negocio" DataTextField="nombre" DataValueField="id_negocio" CellSpacing="0" CellPadding="0">
                                            </asp:RadioButtonList>
                                            <%--[id_sucursal],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista" FilterExpression="id_negocio IN (1,3)">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Sucursal:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataTextField="nombre" DataValueField="id_sucursal" CellSpacing="0" CellPadding="0">
                                            </asp:RadioButtonList>
                                            <%--[id_sucursal],[nombre]--%>
                                            <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sucursal" SelectMethod="ListaParaDDL">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">
                                            <asp:Label ID="lbl_factura_enun" runat="server" Text="No. de factura:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_no_factura" runat="server" Text="" SkinID="txtSingleLine100" />
                                            <asp:RequiredFieldValidator ID="rfv_busqueda" runat="server" ControlToValidate="txt_no_factura" Display="Dynamic" SetFocusOnError="true" ValidationGroup="anulacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="rav_busqueda" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999999" ControlToValidate="txt_no_factura" Display="Dynamic" ValidationGroup="anulacion" SetFocusOnError="true" Text="*" ErrorMessage="El número de factura contiene caracteres inválidos"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">
                                            <asp:Label ID="lbl_desde" runat="server" Text="Fecha de emisión:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false">
                                            </ew:CalendarPopup>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cajaPagoTdButton" colspan="2">
                                            <asp:Button ID="btn_busqueda" runat="server" Text="Buscar factura" ValidationGroup="anulacion" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos_factura" runat="server" Width="100%" GroupingText="Datos de la factura" Visible="false">
                                <table class="contratoViewTable" width="100%" cellspacing="0">
                                    <tr>
                                        <td >
                                            <table>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">No. contrato:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_no_contrato" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">No. de factura:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_no_factura" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">No. de control:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_no_control" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Fecha de emision:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_emision" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Monto (Bs.):</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_monto_bs" runat="server"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="bottom">
                                            <table>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Estado:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Cliente:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">NIT del cliente:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_nit" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Concepto:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_concepto" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Usuario:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_usuario" runat="server"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" >
                                            <asp:Label ID="lbl_accion_enun" runat="server" Text="Acción:"/>
                                            <asp:RadioButton ID="rb_reimprimir" runat="server" Text="Reimprimir"  Checked="true" GroupName="accion"  AutoPostBack="true" />
                                            <asp:RadioButton ID="rb_anular" runat="server" Text="Anular y emitir nueva factura" GroupName="accion" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                      <td class="cajaPagoTdButton" colspan="2">
                                        <asp:ButtonAction ID="btn_accion" runat="server" Text="Realizar acción" TextoEnviando="Ejecutando..."  CausesValidation="False" />
                                      </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos_factura_nueva" runat="server" Width="100%" GroupingText="Datos de la factura" Visible="false">
                                <asp:HyperLink ID="hlFactura" runat="server" Text="Enlace a la Factura" NavigateUrl="#" Target="_blank"></asp:HyperLink>
                            </asp:Panel>
                        </td>
                    </tr>	
                    <tr>
                        <td>
                            <asp:Panel ID="panel_beneficiario" runat="server" GroupingText="Beneficiario de la factura"
                                Visible="false">
                                <table align="center">
                                    <tr>
                                        <td class="cajaCobroFormaTdEnun">
                                            Cliente:</td>
                                        <td class="cajaCobroFormaTdDato">
                                            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtCajaCobroClienteNombre" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el Apellido Paterno del cliente para la emisión de la factura" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rev_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre del beneficiario de la factura contiene caracteres inválidos" ValidationGroup="pago"></asp:RegularExpressionValidator>
                                        </td>
                                        <td class="cajaCobroFacturaTdOpciones" align="left" rowspan="2">
                                            <asp:RadioButtonList ID="rbl_beneficiario" runat="server" AutoPostBack="true" CausesValidation="false" CellSpacing="2" CellPadding="1" RepeatDirection="Vertical" OnSelectedIndexChanged="rbl_beneficiario_SelectedIndexChanged">
                                                <asp:ListItem Text="Asignado" Value="actual" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Modificar" Value="modificar"></asp:ListItem>
                                                <asp:ListItem Text="Modificar y guardar" Value="modificar_guardar"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cajaCobroFormaTdEnun">
                                            NIT:</td>
                                        <td class="cajaCobroFormaTdDato">
                                            <asp:TextBox ID="txt_nit" runat="server" SkinID="txtCajaCobroClienteNit" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el NIT del cliente para la emisión de la factura" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos" ValidationGroup="pago"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Panel runat="server" ID="panel_reimpresion" GroupingText="Reimpresión" Visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_anterior" runat="server">
                                        <uc2:cajaImpresion ID="CajaImpresionFacturas" runat="server" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_nuevo" runat="server">
                                        <uc3:cajaImpresionNueva ID="CajaImpresionFacturasNuevo" runat="server" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel> 
                        </td>
                    </tr>
                 </table>
            </td>
        </tr>
    </table>
</asp:Content>

