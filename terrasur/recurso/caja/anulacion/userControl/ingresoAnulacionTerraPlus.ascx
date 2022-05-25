<%@ Control Language="VB" ClassName="ingresoAnulacionTerraPlus" %>

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
        If terrasur.terraplus.tp_pago.PermitirAnularUltimoPago(id_contrato, Profile.id_usuario, Profile.entorno.id_rol) Then
            panel_ingreso.Visible = True
            
            gv.DataSource = terrasur.terraplus.tp_pago.ListaUltimoPago(id_contrato)
            gv.DataBind()
            If gv.Rows.Count > 0 Then
                gv.Rows(0).CssClass = "cajaGvRowUltimo"
            End If
        Else
            panel_ingreso.Visible = False
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/anulacion/anulacionTerraPlus.aspx")
    End Sub
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Anulación del pago TerraPlus"> 
   <table class="cajaIngresoTable" >
        <tr>
            <td>
                <%--<table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contratoViewTdEnun">Fecha de pago:</td>
                        <td class="contratoViewTdDato"><asp:Label ID="lbl_fecha_pago" runat="server"></asp:Label></td>
                        <td class="contratoViewTdEnun" width="10px"></td>
                        <td class="contratoViewTdEnun"><asp:Label ID="lbl_monto_enun" runat="server" Text="Monto Pagado:"></asp:Label></td>
                        <td class="contratoViewTdDato"><asp:Label ID="lbl_monto" runat="server"></asp:Label></td>
                    </tr>
                 </table>--%>
                <table cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gv" runat="server" SkinID="gvCajaPagos" AutoGenerateColumns="false" DataKeyNames="id_serviciovendido">
                                <Columns>
                                    <asp:BoundField ShowHeader="false" DataField="texto_pago" ItemStyle-CssClass="cajaGvCellTipoEnun" />
                                    <asp:BoundField HeaderText="F.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                    <asp:BoundField HeaderText="Mes(es) pagado(s)" DataField="literal_meses" />
                                    <asp:BoundField HeaderText="Nº meses" DataField="num_meses" ItemStyle-CssClass="gvCell1" />
                                    <asp:BoundField HeaderText="Monto" DataField="precio_total" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                    <asp:BoundField HeaderText="" DataField="codigo_moneda" />
                                    <asp:BoundField HeaderText="Nº Fact." DataField="num_factura" ItemStyle-CssClass="gvCell1"/>

                                    <asp:BoundField HeaderText="Forma Pag." DataField="forma_pago" />
                                    <asp:BoundField HeaderText="Sucursal" DataField="sucursal" />
                                    <asp:BoundField HeaderText="Cajero(a)" DataField="usuario" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_serviciovendido],[fecha],[literal_meses],[num_meses]
                            [precio_total],[codigo_moneda],[num_factura]
                            [forma_pago],[sucursal],[usuario],[texto_pago]--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdMsg">
                <asp:Label ID="lbl_permitido" runat="server" SkinID="lbl_CajaIngresoPermitido" Text="Puede anular el último pago TerraPlus"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Anular pago TerraPlus" CommandArgument="0" />
            </td>
         </tr>
    </table>
</asp:Panel>
