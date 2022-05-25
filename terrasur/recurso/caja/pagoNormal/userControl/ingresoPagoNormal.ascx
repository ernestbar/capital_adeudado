<%@ Control Language="VB" ClassName="ingresoPagoNormal" %>

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

    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value

            gv.Columns(6).HeaderText = "Pago(" & value & ")"
            gv.Columns(7).HeaderText = "Saldo(" & value & ")"
        End Set
    End Property

    Protected Sub Cargar()
        If pago.Permitir(id_contrato, Profile.id_usuario, Profile.entorno.id_rol, "pagoNormal") Then
            panel_ingreso.Visible = True
            Dim tabla As Data.DataTable = pago.Lista_PagoNormal(id_contrato, 0, DateTime.Now, False, 0, 0, 0)
            lbl_monto_minimo.Text = Math.Ceiling((Decimal.Parse(tabla.Rows(1)("seguro").ToString) + Decimal.Parse(tabla.Rows(1)("mantenimiento_sus").ToString) + Decimal.Parse(tabla.Rows(1)("interes").ToString))).ToString("F2")

            codigo_moneda = contrato.CodigoMoneda(id_contrato)

            tabla.Columns.Add("tipo_pago")
            tabla.Rows(0)("tipo_pago") = "Último pago:"
            tabla.Rows(1)("tipo_pago") = "Pago a realizar:"
            gv.DataSource = tabla
            gv.DataBind()
            gv.Rows(0).CssClass = "cajaGvRowUltimo"
            gv.Rows(1).CssClass = "cajaGvRowNuevo"
            gv.Rows(1).Cells(6).CssClass = "cajaGvCellTotal"

            Dim fecha_interes As DateTime = New pago(contrato.UltimoPago(id_contrato, DateTime.Now)).interes_fecha
            If fecha_interes.Date < DateTime.Now.Date Then
                btn_ingresar.Enabled = True
            Else
                btn_ingresar.Enabled = False
            End If
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/pagoNormal/Default.aspx")
    End Sub

</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Pago Normal">
    <table class="cajaIngresoTable">
        <tr>
            <td class="cajaIngresoTdContenido">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gv" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField ShowHeader="false" DataField="tipo_pago" ItemStyle-CssClass="cajaGvCellTipoEnun"/>
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
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="cajaIngresoTdEnun"><asp:Label ID="lbl_monto_minimo_enun" runat="server" Text="Pago mínimo (para ponerse al día en el pago del seguro, mantenimiento e intereses):"></asp:Label></td>
                                    <td class="cajaIngresoTdDato"><asp:Label ID="lbl_monto_minimo" runat="server"></asp:Label></td>
                                    <td class="cajaIngresoTdDato"><asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Realizar pago NORMAL" CommandArgument="0" /></td></tr>
    </table>
</asp:Panel>