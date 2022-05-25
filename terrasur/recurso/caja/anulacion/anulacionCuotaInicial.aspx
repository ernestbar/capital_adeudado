<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación de cuota inicial" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/recurso/caja/userControl/cajaAnulacionesMaster.ascx" TagName="cajaAnulacionesMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                lbl_id_contrato.Text = Session("id_contrato").ToString
                Session.Remove("id_contrato")
                CargarDatos()
            Else
                Response.Redirect("~/recurso/caja/contratoAnulacion.aspx")
            End If
        End If
    End Sub

    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            lbl_monto_enun.Text = "Monto (" & value & "):"
        End Set
    End Property
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Session("id_contrato") = ContratoDatos1.id_contrato
        Response.Redirect("~/recurso/caja/contratoAnulacion.aspx")
    End Sub

    
    Protected Sub CargarDatos()
        Dim ci As New pago(contrato.IdPagoInicial(Integer.Parse(lbl_id_contrato.Text)))
        btn_accion.Enabled = True
        lbl_fecha_pago.Text = ci.fecha.ToString("d")
        Dim id_recibo As Integer = recibo.IdPorTransaccion(ci.id_transaccion)
        Dim r As New recibo(id_recibo, 0)
        lbl_recibo.Text = r.num_recibo.ToString()
        lbl_monto.Text = ci.monto_pago.ToString("F2")

        Dim c As New contrato(Integer.Parse(lbl_id_contrato.Text))
        codigo_moneda = c.codigo_moneda
        
        Dim cli As New cliente(c.id_titular)
        lbl_cliente.Text = cli.paterno + " " + cli.materno + " " + cli.nombres
     End Sub
    
    Protected Sub btn_accion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_accion.Click
        ' Facturacion Sintesis
        Try
            Dim IdPagoInicial As Integer = contrato.IdPagoInicial(Integer.Parse(lbl_id_contrato.Text))
            Dim objPago As pago = New pago(IdPagoInicial)
            Dim IdTransaccion As Integer = objPago.id_transaccion
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
            
            If pago.AnularCuotaInicial(IdPagoInicial, Integer.Parse(lbl_id_contrato.Text), Profile.id_usuario, Profile.entorno.id_rol) = True Then
                If IdFactura > 0 And Cuf <> "" Then
                    Dim objAnulacion As WSFacturacion.WSFacturacion = New WSFacturacion.WSFacturacion()
                    Dim anulaRes As WSFacturacion.AnulacionRes = objAnulacion.AnularFactura(token, Cuf, 1, True)
                    If anulaRes.code = 200 Then
                        Msg1.Text = "CUOTA INICIAL ANULADA"
                        btn_accion.Enabled = False
                    Else
                        Msg1.Text = "LA ANULACION DE LA FACTURA NRO. " & NroFactura.ToString() & " Y CUF " & Cuf & " NO SE REALIZÓ CORRECTAMENTE EN SINTESIS"
                        btn_accion.Enabled = False
                    End If
                Else
                    Msg1.Text = "CUOTA INICIAL ANULADA"
                    btn_accion.Enabled = False
                End If
            Else
                Msg1.Text = "LA ANULACION DE LA CUOTA INICIAL NO SE REALIZÓ CORRECTAMENTE"
            End If
        Catch ex As Exception
            Msg1.Text = "Error: " & ex.Message
        End Try
        '         
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaAnulacionesMaster ID="CajaAnulacionesMaster1" runat="server" tipo_anulacion="cuotaInicial" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_id_contrato" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Anulación de cuota inicial</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Cancelar / Volver" SkinID="btnVolver"/></td></tr>
                    <tr><td class="tdEncabezado"><uc2:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                    <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Cuota Inicial">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="contratoViewTdHorEnun">Fecha de pago:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_pago" runat="server"></asp:Label></td>
                                                                        <td class="contratoViewTdHorEnun" width="10px"></td>
                                                                        <td class="contratoViewTdHorEnun">No. Recibo:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_recibo" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto ($us):"></asp:Label></td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
                                                                        <td class="contratoViewTdHorEnun" width="10px"></td>
                                                                        <td class="contratoViewTdHorEnun">Cliente:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdButton" colspan="2">
                                                                <asp:Button ID="btn_accion" runat="server" Text="Anular cuota inicial" CausesValidation="False" OnClientClick="return confirm('¿Esta seguro que desea anular la cuota inicial?');" />
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
</asp:Content>

