<%@ Control Language="VB" ClassName="ingresoPagoSegunPlan" %>

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
        If pago.Permitir(id_contrato, Profile.id_usuario, Profile.entorno.id_rol, "pagoSegunPlan") Then
            panel_ingreso.Visible = True


            Dim codigo_moneda As String = contrato.CodigoMoneda(id_contrato)
            gv.Columns(6).HeaderText = "Pago(" & codigo_moneda & ")"
            gv.Columns(7).HeaderText = "Saldo(" & codigo_moneda & ")"


            Dim tabla As Data.DataTable = pago.Lista_PagoAdelantadoSegunPlan_VARIOS_PAGOS(id_contrato, 1, 0, False)
            tabla.Columns.Add("tipo_pago")
            tabla.Rows(0)("tipo_pago") = "Último pago:"
            tabla.Rows(1)("tipo_pago") = "Pago a realizar:"
            gv.DataSource = tabla
            gv.DataBind()
            gv.Rows(0).CssClass = "cajaGvRowUltimo"
            gv.Rows(1).CssClass = "cajaGvRowNuevo"
            gv.Rows(1).Cells(6).CssClass = "cajaGvCellTotal"
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/pagoSegunPlan/Default.aspx")
    End Sub
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Pago Según Plan">
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
                                    <%--<asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" />
                                    <asp:BoundField HeaderText="Mantenim" DataField="mantenimiento_sus" HtmlEncode="false" DataFormatString="{0:F2}" />
                                    <asp:BoundField HeaderText="Interés" DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" />
                                    <asp:BoundField HeaderText="Amortización" DataField="amortizacion" HtmlEncode="false" DataFormatString="{0:F2}" />--%>
                                    <asp:BoundField HeaderText="Pago" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" />
                                    <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Realizar pago SEGÚN PLAN" CommandArgument="0" /></td></tr>
    </table>
</asp:Panel>