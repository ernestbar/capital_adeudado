<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Corrección de datos de facturas" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

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
    Protected Property id_transaccion() As Integer
        Get
            Return Integer.Parse(lbl_id_transaccion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_transaccion.Text = value
        End Set
    End Property
    
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "factura_corregir") = False Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            Else
                txt_num_factura.Focus()
            End If
        End If
    End Sub

    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        id_factura = factura.IdPorNumeroFecha(Integer.Parse(rbl_sucursal.SelectedValue), Integer.Parse(txt_num_factura.Text), cp_fecha.SelectedDate, Integer.Parse(rbl_negocio.SelectedValue))

        If id_factura > 0 Then
            'Se cargan los datos actuales de la factura
            panel_datos_factura.Visible = True
            Dim f As New factura(id_factura)
            id_transaccion = f.id_transaccion
            Dim id_contrato As Integer = factura.IdContrato(id_factura)
            If id_contrato > 0 Then
                lbl_no_contrato.Text = New contrato(id_contrato).numero
            Else
                lbl_no_contrato.Text = "---"
            End If
            lbl_no_factura.Text = f.num_factura.ToString()
            lbl_no_control.Text = f.numero_control
            lbl_fecha_emision.Text = f.fecha.ToString("d")
            lbl_monto_bs.Text = f.monto_bs.ToString("F2")
            lbl_cliente.Text = f.cliente_nombre
            lbl_nit.Text = f.cliente_nit.ToString()
            lbl_concepto.Text = f.concepto.ToString()
            lbl_usuario.Text = New usuario(New transaccion(f.id_transaccion).id_usuario).nombre_usuario.ToString()
            If f.anulado = False Then
                lbl_estado.Text = "Activa"
            Else
                lbl_estado.Text = "Anulada"
            End If
            
            'Se cargan los datos en es segmento de beneficiario de factura
            If f.anulado = False Then
                If VerificarPermitirCorregir(f.fecha) = True Then
                    panel_beneficiario.Visible = True
                    txt_cliente.Text = f.cliente_nombre
                    txt_nit.Text = f.cliente_nit.ToString()
                    txt_cliente.Focus()
                    btn_accion.Enabled = True
                Else
                    panel_beneficiario.Visible = False
                End If
            Else
                Msg1.Text = "La factura se encuentra anulada"
                panel_beneficiario.Visible = False
            End If
        Else
            panel_datos_factura.Visible = False
            panel_beneficiario.Visible = False
            Msg1.Text = "No se encontró ninguna factura"
        End If
        panel_reimpresion.Visible = False
        panel_anterior.Visible = False
        panel_nuevo.Visible = False
        CajaImpresionFacturas.btn_imprimir_1.Visible = False
        CajaImpresionFacturas.wv_documento_1.Visible = False
        CajaImpresionFacturasNuevo.btn_imprimir_1.Visible = False
        CajaImpresionFacturasNuevo.wv_documento_1.Visible = False
    End Sub


    Protected Sub btn_accion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_accion.Click
        If Corregir(id_factura, txt_cliente.Text.Trim, txt_nit.Text.ToString, Profile.id_usuario) = True Then
            Msg1.Text = "La corrección se realizó correctamente"
            ImprimirDocumento(id_transaccion)
            btn_accion.Enabled = False
        Else
            Msg1.Text = "La corrección NO se realizó correctamente"
        End If
    End Sub
   
    Sub ImprimirDocumento(ByVal transaccion As String)
        If ConfigurationManager.AppSettings("impresoras_red") = "si" Then
            panel_reimpresion.Visible = True
            panel_anterior.Visible = False
            panel_nuevo.Visible = True
            CajaImpresionFacturasNuevo.MostrarDocumento("Factura", transaccion, True, id_factura, 600, 400)
        Else
            panel_reimpresion.Visible = True
            panel_anterior.Visible = True
            panel_nuevo.Visible = False
            CajaImpresionFacturas.MostrarDocumento("Factura", transaccion, True, id_factura, 600, 400)
        End If
    End Sub

    Protected Sub rbl_sucursal_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_sucursal.DataBound
        Dim id_sucursal_predeterminada As Integer = sucursal.IdSucursalPorNum(Integer.Parse(ConfigurationManager.AppSettings("num_sucursal")))
        If rbl_sucursal.Items.FindByValue(id_sucursal_predeterminada) IsNot Nothing Then
            rbl_sucursal.SelectedValue = id_sucursal_predeterminada
        ElseIf rbl_sucursal.Items.Count > 0 Then
            rbl_sucursal.SelectedIndex = 0
        End If
        btn_busqueda.Enabled = rbl_sucursal.Items.Count.Equals(0).Equals(False)
    End Sub
    
    Protected Function VerificarPermitirCorregir(ByVal fecha_emision As DateTime) As Boolean
        Dim permitir As Boolean = False
        If fecha_emision.Year = DateTime.Now.Year And fecha_emision.Month = DateTime.Now.Month Then
            permitir = True
        Else
            Dim fecha_inicio As DateTime = fecha_emision.Date.AddDays((-1) * fecha_emision.Day).AddDays(1)
            Dim fecha_fin As DateTime = fecha_emision.Date.AddDays((-1) * fecha_emision.Day).AddDays(14).AddMonths(1)
            If fecha_inicio <= DateTime.Now.Date And DateTime.Now.Date <= fecha_fin Then
                permitir = True
            Else
                Msg1.Text = "La factura NO se puede corregir (correcciones del " & fecha_inicio.ToString("d") & " al " & fecha_fin.ToString("d") & ")"
            End If
        End If
        Return permitir
    End Function
    
    Public Function Corregir(ByVal _id_factura As Integer, ByVal _nuevo_cliente_nombre As String, ByVal _nuevo_cliente_nit As String, ByVal _audit_id_usuario As Integer) As Boolean
        Try
            Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
            Dim cmd As DbCommand = db1.GetStoredProcCommand("factura_Corregir")
            cmd.CommandTimeout = Integer.Parse(ConfigurationManager.AppSettings("CommandTimeout"))
            db1.AddInParameter(cmd, "id_factura", DbType.Int32, _id_factura)
            db1.AddInParameter(cmd, "nuevo_cliente_nombre", DbType.String, _nuevo_cliente_nombre)
            db1.AddInParameter(cmd, "nuevo_cliente_nit", DbType.String, _nuevo_cliente_nit)
            db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, _audit_id_usuario)
            db1.ExecuteNonQuery(cmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaMaster ID="CajaMaster1" runat="server"  Visible="false"  />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
<asp:Label runat="server" ID="lbl_id_factura" Text="0" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lbl_id_transaccion" Text="0" Visible="false"></asp:Label>

    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
                    <tr><td class="priTdTitle">Corrección de datos de facturas</td></tr>
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
                                        <td class="formTdEnun">No. de factura:</td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_num_factura" runat="server" Text="" SkinID="txtSingleLine100" />
                                            <asp:RequiredFieldValidator ID="rfv_busqueda" runat="server" ControlToValidate="txt_num_factura" Display="Dynamic" SetFocusOnError="true" ValidationGroup="anulacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="rav_busqueda" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999999" ControlToValidate="txt_num_factura" Display="Dynamic" ValidationGroup="anulacion" SetFocusOnError="true" Text="*" ErrorMessage="El número de factura contiene caracteres inválidos"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha de emisión:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false"></ew:CalendarPopup></td>
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
                        <td class="formTdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            <asp:ValidationSummary ID="vs_anulacion" runat="server" DisplayMode="List" ValidationGroup="anulacion" />
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
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_beneficiario" runat="server" GroupingText="Beneficiario de la factura" Visible="false">
                                <table align="center">
                                    <tr>
                                        <td class="cajaCobroFormaTdEnun">Cliente:</td>
                                        <td class="cajaCobroFormaTdDato">
                                            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtCajaCobroClienteNombre" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el Apellido Paterno del cliente para la emisión de la factura" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rev_cliente" runat="server" ControlToValidate="txt_cliente" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nombre_paterno_materno %>" Text="*" ErrorMessage="El nombre del beneficiario de la factura contiene caracteres inválidos" ValidationGroup="pago"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cajaCobroFormaTdEnun">NIT:</td>
                                        <td class="cajaCobroFormaTdDato">
                                            <asp:TextBox ID="txt_nit" runat="server" SkinID="txtCajaCobroClienteNit" MaxLength="<%$ AppSettings:cliente_longitud_nit %>"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el NIT del cliente para la emisión de la factura" ValidationGroup="pago"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rev_nit" runat="server" ControlToValidate="txt_nit" Display="Dynamic" SetFocusOnError="true" ValidationExpression="<%$ AppSettings:cliente_ExpReg_nit %>" Text="*" ErrorMessage="El NIT contiene caracteres no permitidos" ValidationGroup="pago"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                      <td class="cajaPagoTdButton" colspan="2">
                                        <asp:ButtonAction ID="btn_accion" runat="server" Text="Realizar la corrección" TextoEnviando="Ejecutando..."  CausesValidation="False" />
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

