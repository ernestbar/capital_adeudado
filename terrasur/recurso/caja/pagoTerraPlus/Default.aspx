<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pago TerraPlus" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/cajaTerraPlusMaster.ascx" tagname="cajaTerraPlusMaster" tagprefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc2" %>
<%@ Register Src="~/recurso/caja/userControl/cajaRealizarPago.ascx" TagName="cajaRealizarPago" TagPrefix="uc3" %>

<script runat="server">
    Protected Property id_contrato_terraplus As Integer
        Get
            Return Integer.Parse(lbl_id_contrato_terraplus.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato_terraplus.Text = value
        End Set
    End Property

    Protected Property num_meses() As Integer
        Get
            Return Integer.Parse(lbl_num_meses.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_num_meses.Text = value
        End Set
    End Property

    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            lbl_total_moneda.Text = "(" & value & ")"
            gv_pago.Columns(2).HeaderText = "Monto(" & value & ")"
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler CajaRealizarPago1.Eleccion_aceptar, AddressOf CajaRealizarPago_Aceptar
        AddHandler CajaRealizarPago1.Eleccion_cancelar, AddressOf CajaRealizarPago_Cancelar
        txt_num_meses.Attributes("onfocus") = "this.select();"
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                id_contrato_terraplus = Integer.Parse(Session("id_contrato").ToString)
                Session.Remove("id_contrato")

                tpDatosTerraPlus1.id_contrato = id_contrato_terraplus
                codigo_moneda = terrasur.terraplus.tp_contrato.CodigoMoneda(id_contrato_terraplus)

                CargarDatosPago()
            Else
                Response.Redirect("~/recurso/caja/contratoPago.aspx")
            End If
        End If
    End Sub
    
    Protected Sub CargarDatosPago()
        MultiView1.ActiveViewIndex = 0
        txt_num_meses.Text = "1"
        CargarTablaCuotasSegunPlan()
        txt_num_meses.Focus()
    End Sub
    
    Protected Sub btn_aplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aplicar.Click
        CargarTablaCuotasSegunPlan()
    End Sub

    Protected Sub CargarTablaCuotasSegunPlan()
        'Se obtiene la tabla y los parámetros necesarios
        num_meses = Integer.Parse(txt_num_meses.Text.Trim)
        gv_pago.DataBind()
        
        'Se despliega el monto total a pagar
        lbl_total_pagar.Text = terrasur.terraplus.tmpTpPago.MontoMesesPagar(id_contrato_terraplus, num_meses).ToString("F2")

        txt_focus.Visible = True
        txt_focus.Focus()
    End Sub
    Protected Sub btn_pagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        'Se verifica si hubo cambios en el número de meses
        If num_meses <> Integer.Parse(txt_num_meses.Text) Then
            CargarTablaCuotasSegunPlan()
        End If
        
        Dim permiso_efectivo As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoTerraPlus", "efectivo")
        Dim monto_a_pagar As Decimal = terrasur.terraplus.tmpTpPago.MontoMesesPagar(id_contrato_terraplus, num_meses)
        
        CajaRealizarPago1.Cargar(monto_a_pagar, permiso_efectivo.Equals(False), False, True, 0, codigo_moneda)
        
        'Se cargan los datyos de la última factura
        Dim bfNombre As String = "", bfNit As String = ""
        terrasur.terraplus.tp_contrato.BeneficiarioFactura(id_contrato_terraplus, bfNombre, bfNit)
        CajaRealizarPago1.SetBeneficiarioFactura(bfNombre, bfNit)
        
        MultiView1.ActiveViewIndex = 1

        btn_otro_contrato.Visible = False
        btn_otro_pago.Visible = False
        
        btn_otro_contrato2.Visible = False
        btn_otro_pago2.Visible = False
    End Sub

    Protected Sub CajaRealizarPago_Aceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id_transaccion As Integer = terrasur.terraplus.tp_pago.Insertar_PagosTerraPlus(id_contrato_terraplus, num_meses, _
                                                                                          Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host, _
                                                                                          CajaRealizarPago1.dato_id_recibo_cobrador, CajaRealizarPago1.dato_FormaPagoCliente, _
                                                                                          CajaRealizarPago1.dato_cliente_nombre, CajaRealizarPago1.dato_cliente_nit, CajaRealizarPago1.dato_cliente_guardar)
        If id_transaccion > 0 Then
            Msg1.Text = "PAGO REALIZADO"
            tpDatosTerraPlus1.id_contrato = id_contrato_terraplus
            'En este punto se despliegan: la factura, el recibo y el comprobante
            CajaRealizarPago1.Pago_Realizado(id_transaccion.ToString)

            btn_otro_contrato2.Visible = True
            btn_otro_pago2.Visible = True
            txt_focus2.Focus()
        Else
            Msg1.Text = "EL PAGO NO SE REALIZÓ CORRECTAMENTE"
        End If
    End Sub
    Protected Sub CajaRealizarPago_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
        
        btn_otro_contrato.Visible = True
        btn_otro_pago.Visible = True
    End Sub
    
    Protected Sub btn_otro_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_otro_contrato.Click, btn_otro_contrato2.Click
        Response.Redirect("~/recurso/caja/terraplusPago.aspx")
    End Sub
    Protected Sub btn_otro_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_otro_pago.Click, btn_otro_pago2.Click
        Session("id_contrato") = tpDatosTerraPlus1.id_contrato
        Response.Redirect("~/recurso/caja/terraplusPago.aspx")
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaTerraPlusMaster ID="cajaTerraPlusMaster1" runat="server" tipo_pago="pagoTerraPlus" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_id_contrato_terraplus" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_num_meses" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>

    <table class="priTable">
        <tr><td class="priTdTitle">Pago TerraPlus</td></tr>
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
                            <uc2:tpDatosTerraPlus ID="tpDatosTerraPlus1" runat="server" />
                        </td>
                    </tr>
                    <tr><td class="tdMsg">
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_pago" runat="server" GroupingText="Pagos TerraPlus" DefaultButton="btn_aplicar">
                                                    <asp:ValidationSummary ID="vs_terraplus" runat="server" DisplayMode="List" ValidationGroup="terraplus" />
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table align="center">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="panel_meses_a_pagar" runat="server" DefaultButton="btn_aplicar">
                                                                                <table align="left">
                                                                                    <tr>
                                                                                        <td class="cajaPagoTdEnun">Nº de meses a pagar:</td>
                                                                                        <td class="cajaPagoTdDato">
                                                                                            <asp:TextBox ID="txt_num_meses" runat="server" Text="1" SkinID="txtSingleLine50"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfv_num_meses" runat="server" ControlToValidate="txt_num_meses" Display="Dynamic" Text="*" ErrorMessage="Debe introducir el Nº de meses" ValidationGroup="terraplus"></asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cv_num_meses" runat="server" ControlToValidate="txt_num_meses" Display="Dynamic" Type="Integer" Operator="DataTypeCheck" Text="*" ErrorMessage="El Nº de meses debe ser un número entero" ValidationGroup="terraplus"></asp:CompareValidator>
                                                                                            <asp:RangeValidator ID="rv_num_meses" runat="server" ControlToValidate="txt_num_meses" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="120" Text="*" ErrorMessage="El Nº de meses no puede ser inferior a 1 ni superior a 120" ValidationGroup="terraplus"></asp:RangeValidator>
                                                                                        </td>
                                                                                        <td><asp:Button ID="btn_aplicar" runat="server" Text="Aplicar" CausesValidation="true" ValidationGroup="terraplus" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="panel_pagos" runat="server" ScrollBars="Vertical" Height="120">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:GridView ID="gv_pago" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false" DataSourceID="ods_lista_pagos" DataKeyNames="id_mes">
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="" DataField="id_mes" ItemStyle-HorizontalAlign="Right" />
                                                                                                <asp:BoundField HeaderText="Mes a pagar" DataField="mes_pago_string" ItemStyle-HorizontalAlign="Left" />
                                                                                                <asp:BoundField HeaderText="Monto" DataField="monto" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                        <%--[id_mes],[fecha],[monto],[mes_pago],[mes_pago_string]--%>
                                                                                        <asp:ObjectDataSource ID="ods_lista_pagos" runat="server" TypeName="terrasur.terraplus.tmpTpPago" SelectMethod="TablaMesesPagar">
                                                                                            <SelectParameters>
                                                                                                <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato_terraplus" PropertyName="Text" />
                                                                                                <asp:ControlParameter Name="Num_meses" Type="Int32" ControlID="lbl_num_meses" PropertyName="Text" />
                                                                                            </SelectParameters>
                                                                                        </asp:ObjectDataSource>
                                                                                    </td>
                                                                                    <td valign="bottom">
                                                                                        <asp:TextBox ID="txt_focus" runat="server" Height="0px" Width="0px" MaxLength="0" BorderStyle="Solid" BorderColor="white"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
                                                                                    <td height="1px">
                                                                                        <asp:TextBox ID="txt_focus" runat="server" Height="0px" Width="0px" MaxLength="0" BorderStyle="Solid" BorderColor="white"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>--%>
                                                                            </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table align="left">
                                                                                <tr>
                                                                                    <td class="cajaPagoTdEnun">Total a pagar:</td>
                                                                                    <td class="cajaPagoTdDato"><asp:Label ID="lbl_total_pagar" runat="server"></asp:Label></td>
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
                                                                <asp:Button ID="btn_pagar" runat="server" SkinID="btnCajaPago" Text="PAGAR" CausesValidation="true" ValidationGroup="terraplus" />
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
                                                <table cellpadding="0" cellspacing="0" align="center">
                                                    <tr>
                                                        <td>
                                                            <uc3:cajaRealizarPago ID="CajaRealizarPago1" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button ID="btn_otro_contrato2" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" />
                                                            <asp:Button ID="btn_otro_pago2" runat="server" Text="Realizar otro pago" SkinID="btnVolver" />
                                                            <asp:TextBox ID="txt_focus2" runat="server" Height="0" Width="0" MaxLength="0" BorderStyle="Solid" BorderColor="white"></asp:TextBox> 
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

