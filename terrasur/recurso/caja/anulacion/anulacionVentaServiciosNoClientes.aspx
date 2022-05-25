<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación de venta de servicios a clientes transitorios" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/recurso/caja/userControl/cajaAnulacionesMaster.ascx" TagName="cajaAnulacionesMaster" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
         <uc1:cajaAnulacionesMaster ID="CajaAnulacionesMaster1" runat="server" tipo_anulacion="otrosServiciosNoCliente" />
</asp:Content>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarDatos()
    End Sub
    
   
    Protected Sub CargarDatos()
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "osnc_mes") = True Then
            lbl_permiso.Text = "mes"
            panel_anulacion.GroupingText = "Servicios vendidos en el mes"
            gv_servicios.DataBind()
        Else
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "anulacion", "osnc_dia") = True Then
                lbl_permiso.Text = "dia"
                panel_anulacion.GroupingText = "Servicios vendidos en el día"
                gv_servicios.DataBind()
            Else
                lbl_permiso.Text = ""
            End If
        End If
    End Sub
    
    Protected Sub gv_servicios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            CType(e.Row.Cells(0).Controls(0), LinkButton).OnClientClick = "return confirm('¿Esta seguro que desea anular la venta de este servicio?');"
            CType(e.Row.Cells(0).Controls(0), LinkButton).Enabled = True
        End If
    End Sub

    Protected Sub gv_servicios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        ' Facturacion Sintesis   
        Try
            If (e.CommandName = "anular") Then
                Dim IdServicioVendido As Integer = Integer.Parse(gv_servicios.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Dim objServ As servicio_vendido = New servicio_vendido(IdServicioVendido)
                Dim IdTransaccion As Integer = objServ.id_transaccion
                Dim Cuf As String = ""
                Dim IdFactura As Integer = terrasur.factura.IdPorTransaccion(IdTransaccion)
                Dim NroFactura As Integer = 0
        
                If IdFactura > 0 Then
                    Dim objFactura As factura = New factura(IdFactura)
                    NroFactura = objFactura.num_factura
                    Dim dtFactura As DataTable = terrasur.factura.RecuperarDatosNuevos(IdFactura)
                    If dtFactura.Rows.Count > 0 Then
                        Cuf = dtFactura.Rows(0)("cuf").ToString()
                    End If
                End If
        
                Dim token As String = ""
                If IdFactura > 0 And Cuf <> "" Then
                    Dim aut As WSFacturacion.Autenticacion = New WSFacturacion.Autenticacion()
                    Dim autRes As WSFacturacion.AutenticacionRes = New WSFacturacion.AutenticacionRes()
                    Dim usuario As String = ConfigurationManager.AppSettings("usuarioSintesis").ToString()
                    Dim password As String = ConfigurationManager.AppSettings("passwordSintesis").ToString()
                    Dim businessCode As String = ConfigurationManager.AppSettings("businessCodeSintesis").ToString()
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
        
                If IdFactura > 0 And Cuf <> "" Then
                    Dim objFactura As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                    Dim factInd As WSFacturacion.FacturaConsultaIndividual = objFactura.ConsultaFacturaIndividual(token, Cuf)
                    If factInd.code = 200 Then
                        Dim Estado As String = factInd.body.status
                        If Estado <> "EMITTED" Then
                            Msg1.Text = "No se puede anular el pago debido a que la factura en Sintesis tiene el estado " & Estado
                            Exit Sub
                        End If
                    Else
                        Msg1.Text = "No se pudo obtener la información de la factura de Sintesis"
                        Exit Sub
                    End If
                End If
                
                If servicio_vendido.AnularServicioNoCliente(IdServicioVendido, Profile.id_usuario, Profile.entorno.id_rol) Then
                    If IdFactura > 0 And Cuf <> "" Then
                        Dim objAnulacion As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                        Dim anulaRes As WSFacturacion.AnulacionRes = objAnulacion.AnularFactura(token, Cuf, 1, True)
                        If anulaRes.code = 200 Then
                            Msg1.Text = "VENTA DE SERVICIO ANULADA"
                            gv_servicios.DataBind()
                        Else
                            Msg1.Text = "LA ANULACION DE LA FACTURA NRO. " & NroFactura.ToString() & " Y CUF " & Cuf & " NO SE REALIZÓ CORRECTAMENTE EN SINTESIS"
                            gv_servicios.DataBind()
                        End If
                    Else
                        Msg1.Text = "VENTA DE SERVICIO ANULADA"
                        gv_servicios.DataBind()
                    End If
                Else
                    Msg1.Text = "LA ANULACION DE LA VENTA DE SERVICIO NO SE REALIZÓ CORRECTAMENTE"
                End If
            End If
        Catch ex As Exception
            Msg1.Text = "Error: " & ex.Message
        End Try
        ' 
    End Sub
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
     <asp:Label ID="lbl_permiso" runat="server" Text="" Visible="false"></asp:Label>
    <table class="priTable">
        <tr><td class="priTdTitle">Anulación de venta de servicios a clientes transitorios</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Servicios Vendidos">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <asp:Panel ID="panel_servicios" runat="server">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView ID="gv_servicios" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_servicios"
                                                                                    DataKeyNames="id_serviciovendido" OnRowDataBound="gv_servicios_RowDataBound" OnRowCommand="gv_servicios_RowCommand" >
                                                                                    <Columns>
                                                                                        <asp:ButtonField Text="Anular" CommandName="anular" ControlStyle-CssClass="gvButton"
                                                                                            ButtonType="Link" />
                                                                                        <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:d}" />
                                                                                        <asp:BoundField HeaderText="Cliente" DataField="cliente" />
                                                                                        <%--<asp:BoundField HeaderText="No. cont." DataField="num_contrato" />--%>
                                                                                        <asp:BoundField HeaderText="No. fact." DataField="num_factura" ItemStyle-CssClass="gvCell1"/>
                                                                                        <asp:BoundField HeaderText="No. rec." DataField="num_recibo" ItemStyle-CssClass="gvCell1"/>
                                                                                        <asp:BoundField HeaderText="No. DPR" DataField="num_comprobante" ItemStyle-CssClass="gvCell1"/>
                                                                                        <asp:BoundField HeaderText="Servicio" DataField="nombre" />
                                                                                        <asp:BoundField HeaderText="Nº unid." DataField="unidades" ItemStyle-CssClass="gvCell1" />
                                                                                        <asp:BoundField HeaderText="P. unit. ($us)" DataField="precio_unitario" ItemStyle-CssClass="gvCell1" />
                                                                                        <asp:BoundField HeaderText="P. total ($us)" DataField="precio_total" ItemStyle-CssClass="gvCell1" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
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
    <%--[id_servicio],[nombre],[unidades],[precio_unitario],[precio_total]--%>
<asp:ObjectDataSource ID="ods_lista_servicios" runat="server" TypeName="terrasur.servicio_vendido" SelectMethod="ListaVendidosNoClientes">
    <SelectParameters>
        <asp:ControlParameter Name="permiso" Type="String"  ControlID="lbl_permiso" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>

