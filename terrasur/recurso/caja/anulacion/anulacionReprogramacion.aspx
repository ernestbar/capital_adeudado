<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación de una reprogramación" %>
<%@ Register Src="~/recurso/caja/userControl/cajaAnulacionesMaster.ascx" TagName="cajaAnulacionesMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>

<script runat="server">
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            lbl_cuota_mensual_enun.Text = "Cuota mensual (" & value & "):"
            lbl_mantenimiento_enun.Text = "Manten. (" & value & "/mes):"
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing And Session("id_plan_pago_anulable") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                lbl_id_plan_pago_anulable.Text = Session("id_plan_pago_anulable").ToString()
                
                codigo_moneda = contrato.CodigoMoneda(ContratoDatos1.id_contrato)
                
                Session.Remove("id_contrato")
                Session.Remove("id_plan_pago_anulable")
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
        Dim pp As New plan_pago(Integer.Parse(lbl_id_plan_pago_anulable.Text))
        btn_accion.Enabled = True
        lbl_fecha_reprog.Text = pp.fecha.ToString()
        lbl_no_cuotas.Text = pp.num_cuotas
        lbl_seguro.Text = pp.seguro
        lbl_mantenimiento.Text = pp.mantenimiento_sus
        lbl_int_corriente.Text = pp.interes_corriente
        lbl_int_penal.Text = New parametro("tasa_mora").valor
        lbl_cuota_mensual.Text = pp.cuota_base
        lbl_inicio_plan.Text = pp.fecha_inicio_plan.ToString("d") '("dd/mm/yyyy")
    End Sub
    
    Protected Sub btn_accion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_accion.Click
       
        If plan_pago.AnularReprogramacion(Integer.Parse(lbl_id_plan_pago_anulable.Text), Profile.id_usuario, Profile.entorno.id_rol) = True Then
            Msg1.Text = "REPROGRAMACION ANULADA"
            btn_accion.Enabled = False
        Else
            Msg1.Text = "LA ANULACION DE LA REPROGRAMACION NO SE REALIZÓ CORRECTAMENTE"
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:cajaAnulacionesMaster ID="CajaAnulacionesMaster1" runat="server" tipo_anulacion="reprogramacion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_id_plan_pago_anulable" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
    <table class="priTable">
        <tr><td class="priTdTitle">Anulación de una reprogramación</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Cancelar / Volver" SkinID="btnVolver"/></td></tr>
                    <tr><td class="tdEncabezado"><uc2:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                    <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Última Reprogramación">
                                                    <table class="cajaPagoTable">
                                                        <tr>
                                                            <td class="cajaPagoTdContenido">
                                                                <table class="contratoViewTable" width="100%" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun">Fecha de reprog.:</td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_reprog" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun">No. cuotas</td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_no_cuotas" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun">F. Inicio de plan:</td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_inicio_plan" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_cuota_mensual_enun" runat="server" Text="Cuota mensual:"></asp:Label></td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_cuota_mensual" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun">Seguro (%/mes):</td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_seguro" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun"><asp:Label ID="lbl_mantenimiento_enun" runat="server" Text="Manten. ($/mes):"></asp:Label></td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_mantenimiento" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun">Int. corriente (%/año):</td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_int_corriente" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="contratoViewTdHorEnun">Int. penal (%/mes):</td>
                                                                                    <td class="contratoViewTdDato"><asp:Label ID="lbl_int_penal" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cajaPagoTdButton" colspan="2">
                                                                            <asp:Button ID="btn_accion" runat="server" Text="Anular Reprogramación" 
                                                                                  CausesValidation="False" OnClientClick="return confirm('¿Esta seguro que desea anular esta reprogramación?');" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
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

