<%@ Control Language="VB" ClassName="ingresoPagoMora" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
            Cargar()
        End Set
    End Property
    
    Protected Sub Cargar()
        Dim num_dias As Integer = pago_mora.DiasMoraPorContrato(id_contrato)
        If num_dias > 0 Then
            panel_ingreso.Visible = True
            Dim coObj As New contrato(id_contrato)
            Dim ult As New sim_pago(coObj.id_ultimo_pago)
            Dim pp As New plan_pago(coObj.id_planpago_vigente)
            lbl_num_dias_mora_enun.Text = "Nº días de mora hasta hoy (" & Date.Now.ToString("d") & "):"
            lbl_num_dias_mora.Text = num_dias
            lbl_monto_mora.Text = Math.Round(num_dias * ((pp.interes_penal / 100) / 30) * ult.saldo, 2)

            lbl_codigo_moneda.Text = coObj.codigo_moneda
            gv.Columns(6).HeaderText = "Pago(" & coObj.codigo_moneda & ")"
            gv.Columns(7).HeaderText = "Saldo(" & coObj.codigo_moneda & ")"
            
            Dim tabla As Data.DataTable = simular.tabla_plan_crear
            simular.tabla_plan_insertar(tabla, ult)
            tabla.Columns.Add("tipo_pago")
            tabla.Rows(0)("tipo_pago") = "Último pago:"
            gv.DataSource = tabla
            gv.DataBind()
            gv.Rows(0).CssClass = "cajaGvRowUltimo"
            If pago.Permitir(id_contrato, Profile.id_usuario, Profile.entorno.id_rol, "pagoMora") Then
                'panel_ingreso.Visible = True
                btn_ingresar.Visible = True
            Else
                'panel_ingreso.Visible = False
                btn_ingresar.Visible = False
            End If
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/pagoMora/Default.aspx")
    End Sub

    'Protected Sub gv_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DataBound
    '    gv.Columns(6).HeaderText = "Pago(" & lbl_codigo_moneda.Text & ")"
    '    gv.Columns(7).HeaderText = "Saldo(" & lbl_codigo_moneda.Text & ")"
    'End Sub
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Pago de Intereses Penales (Mora)">
    <table class="cajaIngresoTable">
        <tr>
            <td class="cajaIngresoTdContenido">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gv" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField ShowHeader="false" DataField="tipo_pago" ItemStyle-CssClass="cajaGvCellTipoEnun" />
                                    <asp:BoundField HeaderText="F.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                    <asp:BoundField HeaderText="F.Pago Int." DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                    <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                    <asp:BoundField HeaderText="Nºdias Int." DataField="interes_dias" />
                                    <asp:BoundField HeaderText="Cuotas" DataField="string_cuotas" />
                                    <asp:BoundField HeaderText="Pago" DataField="monto_pago" />
                                    <asp:BoundField HeaderText="Saldo" DataField="saldo" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="cajaIngresoTdEnun"><asp:Label ID="lbl_num_dias_mora_enun" runat="server"></asp:Label></td>
                                    <td class="cajaIngresoTdDato"><asp:Label ID="lbl_num_dias_mora" runat="server"></asp:Label></td>
                                    <td class="cajaIngresoTdEspacio"></td>
                                    <td class="cajaIngresoTdEnun">Monto a pagar por mora:</td>
                                    <td class="cajaIngresoTdDato"><asp:Label ID="lbl_monto_mora" runat="server"></asp:Label></td>
                                    <td class="cajaIngresoTdDato"><asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_mensaje_mora" runat="server" SkinID="lbl_CajaIngresoMensaje" Text="El contrato esta en mora"></asp:Label>
            </td>
        </tr>
        <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Realizar pago de INTERESES PENALES" CommandArgument="0" /></td></tr>
    </table>
</asp:Panel>