<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pago Directo a Capital" %>
<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago" TagPrefix="uc3" %>

<script runat="server">
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
            
            lbl_total_moneda.Text = value
            
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
            Else
                Response.Redirect("~/recurso/caja/contratoPago.aspx")
            End If
        End If
    End Sub

    Protected Sub CargarDatosPago()
        MultiView1.ActiveViewIndex = 0
        Dim c As New contrato(ContratoDatos1.id_contrato)
        venta_lote = c.venta_lote
        
        Dim up As New sim_pago(c.id_ultimo_pago)
        Dim monto_maximo As Decimal = up.saldo

        Dim tabla As Data.DataTable = simular.tabla_plan_crear
        simular.tabla_plan_insertar(tabla, up)
        tabla.Columns.Add("tipo_pago")
        tabla.Rows(0)("tipo_pago") = "Último pago:"
        gv_pago.DataSource = tabla
        gv_pago.DataBind()
        gv_pago.Rows(0).CssClass = "cajaGvRowUltimo"

        rv_monto.ErrorMessage = "El monto a pagar no puede ser inferior a 0,10 ni superior a " & monto_maximo.ToString("F2")
        rv_monto.MaximumValue = Math.Round(monto_maximo, 2).ToString

        txt_monto.Text = New plan_pago(c.id_planpago_vigente).cuota_base
        txt_monto.Focus()
    End Sub
    
    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        If VerificarNafibo() = True Then
            Dim permiso_efectivo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoCapital", "efectivo")
            CajaRealizarPago1.Cargar(Decimal.Parse(txt_monto.Text), permiso_efectivo.Equals(False), False, venta_lote.Equals(False), ContratoDatos1.id_contrato, codigo_moneda)
            
            Session("permitir_pagar") = "si"
            MultiView1.ActiveViewIndex = 1

            btn_otro_contrato.Visible = False
            btn_otro_pago.Visible = False
        End If
    End Sub
    
    Protected Function VerificarNafibo() As Boolean
        Dim correcto As Boolean = True
        Dim _id_contrato As Integer = ContratoDatos1.id_contrato
        If negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "nafibo" Then
            Dim monto_digitado As Decimal = Decimal.Parse(txt_monto.Text)

            Dim coObj As New contrato(_id_contrato)
            Dim saldo As Decimal = coObj.saldo_capital

            Dim cuota_base As Decimal = New plan_pago(coObj.id_planpago_vigente).cuota_base
            If monto_digitado < cuota_base Then
                Dim ult_pago As New pago(coObj.id_ultimo_pago)
                If ult_pago.fecha < DateTime.Now.Date And coObj.saldo_capital >= cuota_base Then
                    correcto = False
                    Msg2.Text = "El monto a pagar no puede ser inferior a la cuota mensual establecida (" & cuota_base.ToString("F2") & ")"
                End If
            End If
        End If
        Return correcto
    End Function

    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("permitir_pagar") = "si" Then
            Dim id_transaccion As Integer = pago.Insertar_PagoCapital(Profile.id_usuario, Profile.entorno.id_rol, ContratoDatos1.id_contrato, CajaRealizarPago1.dato_id_recibo_cobrador, CajaRealizarPago1.dato_FormaPagoCliente, CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar)
            If id_transaccion > 0 Then
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
    <uc1:cajaMaster ID="CajaMaster1" runat="server" tipo_pago="pagoCapital" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_venta_lote" runat="server" Text="True" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Pago Directo a Capital</td></tr>
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
                    <tr><td class="tdMsg"><asp:Msg ID="Msg2" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_pago" runat="server" GroupingText="Pago Directo a Capital" DefaultButton="btn_pagar">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table align="center" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gv_pago" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:BoundField ShowHeader="false" DataField="tipo_pago" ItemStyle-CssClass="cajaGvCellTipoEnun" />
                                                                                    <asp:BoundField HeaderText="F.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="F.Pago Int." DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                                                    <asp:BoundField HeaderText="Nºdias Int." DataField="interes_dias" ItemStyle-CssClass="gvCell1" />
                                                                                    <asp:BoundField HeaderText="Cuota" DataField="string_cuotas" />
                                                                                    <asp:BoundField HeaderText="Pago" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Manten." DataField="mantenimiento_sus" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Interés" DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Amortiz." DataField="amortizacion" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                    <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="panel_monto" runat="server" GroupingText="Digitar monto" DefaultButton="btn_pagar">
                                                                                <table align="center">
                                                                                    <tr>
                                                                                        <td class="cajaPagoTdEnun">Monto a pagar:</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txt_monto" runat="server" SkinID="txtCajaPagoMonto" MaxLength="8"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" Text="*" ErrorMessage="Debe introducir el monto a pagar" ValidationGroup="monto"></asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" Type="Double" Operator="DataTypeCheck" Text="*" ErrorMessage="El monto a pagar debe ser un número válido" ValidationGroup="monto"></asp:CompareValidator>
                                                                                            <asp:RangeValidator ID="rv_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" Type="Double" MinimumValue="0,01" MaximumValue="9999999" Text="*" ErrorMessage="El monto a pagar no puede ser inferior a 0,10 ni superior a" ValidationGroup="monto"></asp:RangeValidator>
                                                                                        </td>
                                                                                        <td class="cajaPagoTdEnun"><asp:Label ID="lbl_total_moneda" runat="server" Text="$us"></asp:Label></td>
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
                                                                <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" CausesValidation="true" ValidationGroup="monto" />
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
