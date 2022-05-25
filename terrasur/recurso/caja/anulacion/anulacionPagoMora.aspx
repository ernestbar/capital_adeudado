<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación de un pago de mora" %>
<%@ Register Src="~/recurso/caja/userControl/cajaAnulacionesMaster.ascx" TagName="cajaAnulacionesMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>

<script runat="server">
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            lbl_monto_pagar_enun.Text = "Monto a Pagar (" & value & "):"
            lbl_monto_pagado_enun.Text = "Monto Pagado (" & value & "):"
        End Set
    End Property
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                lbl_id_contrato.Text = Session("id_contrato").ToString
                
                codigo_moneda = contrato.CodigoMoneda(ContratoDatos1.id_contrato)
                
                Session.Remove("id_contrato")
                CargarDatos()
            Else
                Response.Redirect("~/recurso/caja/contratoAnulacion.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Session("id_contrato") = ContratoDatos1.id_contrato
        Response.Redirect("~/recurso/caja/contratoAnulacion.aspx")
    End Sub

    
    Protected Sub CargarDatos()
        Dim pm As New pago_mora(contrato.UltimoPagoMora(Integer.Parse(lbl_id_contrato.Text)))
        btn_accion.Enabled = True
        lbl_fecha.Text = pm.fecha.ToString("d")
        Dim id_recibo As Integer = recibo.IdPorTransaccion(pm.id_transaccion)
        Dim r As New recibo(id_recibo, 0)
        lbl_recibo.Text = r.num_recibo.ToString()
        lbl_num_dias.Text = pm.num_dias.ToString()
        lbl_factura.Text = New factura(factura.IdPorTransaccion(pm.id_transaccion)).num_factura.ToString()
        lbl_num_cuotas.Text = pm.num_cuotas.ToString()
        lbl_monto_pagar.Text = pm.monto_pagar.ToString("F2")
        lbl_monto_pagado.Text = pm.monto_pagado.ToString("F2")
        lbl_comprobante.Text = New comprobante_dpr(comprobante_dpr.IdPorTransaccion(pm.id_transaccion), 0).num_comprobante.ToString()
     End Sub
    
    Protected Sub btn_accion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_accion.Click
        If pago_mora.Anular(contrato.UltimoPagoMora(Integer.Parse(lbl_id_contrato.Text)), Integer.Parse(lbl_id_contrato.Text), Profile.id_usuario, Profile.entorno.id_rol) = True Then
            Msg1.Text = "PAGO DE MORA ANULADO"
            btn_accion.Enabled = False
        Else
            Msg1.Text = "LA ANULACION DEL PAGO DE MORA NO SE REALIZÓ CORRECTAMENTE"
        End If
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaAnulacionesMaster ID="CajaAnulacionesMaster1" runat="server" tipo_anulacion="pagoUltimo" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_id_contrato" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Anulación de un pago de mora</td></tr>
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
                                                <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Último pago de mora">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="contratoViewTdHorEnun">Fecha:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
                                                                        <td class="contratoViewTdHorEnun" width="10px"></td>
                                                                        <td class="contratoViewTdHorEnun">No. comprobante:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_comprobante" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="contratoViewTdHorEnun">Número de días:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_num_dias" runat="server"></asp:Label></td>
                                                                        <td class="contratoViewTdHorEnun" width="10px"></td>
                                                                        <td class="contratoViewTdHorEnun">No. recibo:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_recibo" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="contratoViewTdHorEnun">No. de cuotas:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_num_cuotas" runat="server"></asp:Label></td>
                                                                        <td class="contratoViewTdHorEnun" width="10px"></td>
                                                                        <td class="contratoViewTdHorEnun">No. factura:</td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_factura" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_monto_pagar_enun" runat="server" Text="Monto a Pagar ($us):"></asp:Label></td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_monto_pagar" runat="server"></asp:Label></td>
                                                                        <td class="contratoViewTdHorEnun" width="10px"></td>
                                                                        <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_monto_pagado_enun" runat="server" Text="Monto Pagado ($us):"></asp:Label></td>
                                                                        <td class="contratoViewTdDato"><asp:Label ID="lbl_monto_pagado" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cajaPagoTdButton" colspan="2">
                                                                <asp:Button ID="btn_accion" runat="server" Text="Anular pago de mora" CausesValidation="False" OnClientClick="return confirm('¿Esta seguro que desea anular el pago de mora?');" />
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

