<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación / reimpresión de comprobante DPR" %>
<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/caja/userControl/cajaImpresion.ascx" TagName="cajaImpresion" TagPrefix="uc2" %>
<%@ Register src="~/recurso/caja/userControl/cajaImpresionNueva.ascx" tagname="cajaImpresionNueva" tagprefix="uc3" %>

<script runat="server">  
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            lbl_monto_enun.Text = "Monto (" & value & "):"
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If parametro_facturacion.ActivoActual = 0 Or tipo_cambio.Actual = 0 Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            Else
                txt_no_comprobantedpr.Focus()
            End If
        End If
    End Sub

    Sub Reset()
        panel_datos_comprobantedpr.Visible = False
        rb_reimprimir.Checked = True
        rb_anular.Checked = False
        rb_anular.Visible = True
        panel_reimpresion.Visible = False
        panel_anterior.Visible = False
        panel_nuevo.Visible = False
        CajaImpresionComprobantes.btn_imprimir_1.Visible = False
        CajaImpresionComprobantes.wv_documento_1.Visible = False
        CajaImpresionComprobantesNuevo.btn_imprimir_1.Visible = False
        CajaImpresionComprobantesNuevo.wv_documento_1.Visible = False
    End Sub
    
    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        Dim Idcomprobantedpr As Integer
        Idcomprobantedpr = comprobante_dpr.IdPorNumero(Integer.Parse(txt_no_comprobantedpr.Text), rbl_negocio.SelectedValue)
        Reset()
        If Idcomprobantedpr > 0 Then
            panel_datos_comprobantedpr.Visible = True
            lbl_id_comprobantedpr.Text = Idcomprobantedpr.ToString()
            Dim r As New comprobante_dpr(Idcomprobantedpr, 0)
            Dim Idcontrato As Integer
            Idcontrato = comprobante_dpr.IdContrato(Idcomprobantedpr)
            If Idcontrato > 0 Then
                lbl_id_contrato.Text = Idcontrato.ToString()
                Dim c As New contrato(Idcontrato)
                lbl_no_contrato.Text = c.numero.ToString()
                codigo_moneda = c.codigo_moneda
            Else
                lbl_no_contrato.Text = "-------"
                codigo_moneda = "$us"
            End If
            lbl_no_comprobantedpr.Text = r.num_comprobante.ToString()
            lbl_fecha_emision.Text = r.fecha.ToString("d")
            lbl_monto.Text = r.monto_sus.ToString("F2")
            lbl_cliente.Text = r.nombre_cliente
            lbl_concepto.Text = r.concepto
            lbl_usuario.Text = New usuario(New transaccion(r.id_transaccion).id_usuario).nombre_usuario.ToString()
            
            'VERIFICAR PERMISOS PARA REIMPRIMIR O ANULAR
            rb_reimprimir.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_reimprimir")
            If rb_reimprimir.Enabled = False Then
                rb_anular.Checked = True
            End If
            If DateTime.Parse(r.fecha.ToString("d")) = DateTime.Parse(Date.Now.ToString("d")) Then
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_anular_dia") = True Then
                    rb_anular.Enabled = True
                Else
                    If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_anular_mes") = True Then
                        rb_anular.Enabled = True
                    Else
                        rb_anular.Enabled = False
                    End If
                End If
            Else
                'SI LA FECHA DE LA EMISION ES MENOR A LA FECHA ACTUAL SE VERIFICA QUE SE ENCUENTRE EN EL MISMO MES Y TENGA EL PERMISO PARA LA ANULACION
                If DateTime.Parse(r.fecha.ToString("d")) < DateTime.Parse(Date.Now.ToString("d")) Then
                    If r.fecha.ToString("MM/yyyy") = Date.Now.ToString("MM/yyyy") Then
                        rb_anular.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "dpr_anular_mes")
                    Else
                        rb_anular.Visible = False
                    End If
                End If
            End If
            If r.anulado = False Then
                lbl_estado.Text = "Activa"
            Else
                lbl_estado.Text = "Anulada"
                rb_anular.Visible = False
            End If
        Else
            Msg1.Text = "No se encontró ningun comprobante DPR."
        End If
    End Sub

    Protected Sub btn_accion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_accion.Click
        If rb_reimprimir.Checked = True Then
            'SE HABILITA EL WEBVIEWER CON EL ID DE LA TRANSACCION DE LA RECIBO A REIMPRIMIR
            Dim cmp As New comprobante_dpr(Integer.Parse(lbl_id_comprobantedpr.Text), 0)
            ImprimirDocumento(cmp.id_transaccion.ToString(), True)
        Else
            If rb_anular.Checked = True Then
                'SE REALIZA LA ANULACION
                Dim id_transaccion As Integer = comprobante_dpr.AnularReimprimir(Integer.Parse(lbl_id_comprobantedpr.Text), Profile.id_usuario, Profile.entorno.id_rol)
                If id_transaccion > 0 Then
                    Msg1.Text = "COMPROBANTE DPR ANULADO"
                    Reset()
                    'En este punto se despliega: la comprobantedpr
                    lbl_id_comprobantedpr.Text = comprobante_dpr.IdPorTransaccion(id_transaccion)
                    ImprimirDocumento(id_transaccion.ToString, False)
                Else
                    Msg1.Text = "LA ANULACION DEL COMPROBANTE DPR NO SE REALIZÓ CORRECTAMENTE"
                End If
            End If
        End If
    End Sub
   
    Sub ImprimirDocumento(ByVal transacciones As String, ByVal reimpresion As Boolean)
        If ConfigurationManager.AppSettings("impresoras_red") = "si" Then
            panel_reimpresion.Visible = True
            panel_anterior.Visible = False
            panel_nuevo.Visible = True
            CajaImpresionComprobantesNuevo.MostrarDocumento("Comprobante", transacciones, reimpresion, Integer.Parse(lbl_id_comprobantedpr.Text), 600, 400)
        Else
            If (CajaImpresionComprobantes.VerificarDocumento("Comprobante", transacciones) = True) Or reimpresion = True Then
                panel_reimpresion.Visible = True
                panel_anterior.Visible = True
                panel_nuevo.Visible = False
                CajaImpresionComprobantes.MostrarDocumento("Comprobante", transacciones, reimpresion, Integer.Parse(lbl_id_comprobantedpr.Text), 600, 400)
            Else
                panel_reimpresion.Visible = False
                panel_anterior.Visible = False
                panel_nuevo.Visible = False
            End If
        End If
    End Sub

    Protected Sub rbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_negocio.DataBound
        For j As Integer = rbl_negocio.Items.Count - 1 To 0 Step -1
            If rbl_negocio.Items(j).Value = "cea" Or rbl_negocio.Items(j).Value = "roldan" Or rbl_negocio.Items(j).Value = "nafibo" Then
                rbl_negocio.Items.RemoveAt(j)
            End If
        Next
        If rbl_negocio.Items.FindByValue("bbr") IsNot Nothing Then
            rbl_negocio.SelectedValue = "bbr"
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaMaster ID="CajaMaster1" runat="server"  Visible="false"  />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

<asp:Label id="lbl_id_contrato" runat="server" Visible="false"  Text="0"/>
<asp:Label id="lbl_id_comprobantedpr" runat="server" Visible="false"  Text="0"/>
<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>

<table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr>
                        <td class="formTdMsg">
                            <asp:Msg ID="Msg1" runat="server">
                            </asp:Msg>
                            <asp:ValidationSummary ID="vs_anulacion" runat="server" DisplayMode="List" ValidationGroup="anulacion" />
                        </td>
                    </tr>
                    <tr>
                        <td class="viewTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Anulación / reimpresión de comprobante DPR"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdFiltro">
                            <asp:Panel ID="panel_busqueda" runat="server" Width="100%" DefaultButton="btn_busqueda">
                                <table class="formTable" align="center">
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_negocio" runat="server" CellPadding="0" CellSpacing="0" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="codigo">
                                            </asp:RadioButtonList>
                                            <%--[id_negocio],[codigo],[nombre],[origen]--%>
                                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_comprobantedpr_enun" runat="server" Text="No. de comprobante:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <asp:TextBox ID="txt_no_comprobantedpr" runat="server" Text="" SkinID="txtSingleLine100" />
                                            <asp:RequiredFieldValidator ID="rfv_busqueda" runat="server" ControlToValidate="txt_no_comprobantedpr" Display="Dynamic" SetFocusOnError="true" ValidationGroup="anulacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="rav_busqueda" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999999" ControlToValidate="txt_no_comprobantedpr" Display="Dynamic" ValidationGroup="anulacion" SetFocusOnError="true" Text="*" ErrorMessage="El número de comprobante contiene caracteres inválidos"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cajaPagoTdButton" colspan="2">
                                            <asp:Button ID="btn_busqueda" runat="server" Text="Buscar comprobante" ValidationGroup="anulacion" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos_comprobantedpr" runat="server" Width="100%" GroupingText="Datos del comprobante DPR" Visible="false">
                                <table class="contratoViewTable" width="100%" cellspacing="0">
                                    <tr>
                                        <td >
                                            <table>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">No. contrato:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_no_contrato" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">No. de comprobante:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_no_comprobantedpr" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Fecha de emision:</td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_emision" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Cliente:</td>
                                                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="contratoViewTdHorEnun">Concepto:</td>
                                                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_concepto" runat="server"></asp:Label></td>
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
                                                    <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto ($us):"></asp:Label></td>
                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
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
                                            <asp:RadioButton ID="rb_reimprimir" runat="server" Text="Reimprimir"  Checked="true" GroupName="accion"  AutoPostBack="false" />
                                            <asp:RadioButton ID="rb_anular" runat="server" Text="Anular y emitir nuevo comprobante" GroupName="accion" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                      <td class="cajaPagoTdButton" colspan="2">
                                        <asp:ButtonAction ID="btn_accion" runat="server" Text="Realizar acción" TextoEnviando="Ejecutando..."   CausesValidation="False" />
                                      </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                   <tr>
                        <td>
                           <asp:Panel runat="server" ID="panel_reimpresion" GroupingText="Reimpresión" Visible="false">
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_anterior" runat="server">
                                        <uc2:cajaImpresion ID="CajaImpresionComprobantes" runat="server" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_nuevo" runat="server">
                                        <uc3:cajaImpresionNueva ID="CajaImpresionComprobantesNuevo" runat="server" />
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

