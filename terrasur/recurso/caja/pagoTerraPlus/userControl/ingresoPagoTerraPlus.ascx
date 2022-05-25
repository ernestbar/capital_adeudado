<%@ Control Language="VB" ClassName="ingresoPagoTerraPlus" %>

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
        Dim permiso_pago As Boolean = False
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoTerraPlus", "efectivo") Or _
            permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "pagoTerraPlus", "dpr") Then
            permiso_pago = True
        End If
        
        If permiso_pago Then
            Dim ecObj As New terrasur.terraplus.tp_estado_contrato(terrasur.terraplus.tp_estado_contrato.Actual(id_contrato))
            If ecObj.estado_codigo = "revertido" Then
                panel_ingreso.Visible = True
                MultiView1.ActiveViewIndex = 0
                CargarDatosReactivación()
            ElseIf ecObj.estado_codigo = "restriccion" Or ecObj.estado_codigo = "cobertura" Then
                panel_ingreso.Visible = True
                MultiView1.ActiveViewIndex = 1
                CargarDatosSiguientePago()
            Else
                panel_ingreso.Visible = False
            End If
        Else
            panel_ingreso.Visible = False
        End If
        

    End Sub

    Protected Sub CargarDatosReactivación()
        btn_reactivar.Enabled = False
        
        'se verifica el número de reactivaciones ya realizadas:
        Dim Num_reactivaciones_realizadas As Integer = terrasur.terraplus.tp_contrato.NumReactivaciones(id_contrato)
        Dim Num_reactivaciones_admitidas As Integer = Convert.ToInt32(New parametro("tp_reactivacion_num_maximo").valor)
        If Num_reactivaciones_realizadas < Num_reactivaciones_admitidas Then
            Dim Num_meses_incumplimineto_caja As Integer = Convert.ToInt32(New parametro("tp_reactivacion_meses_caja").valor)
            Dim Num_meses_incumplidos As Integer = terrasur.terraplus.tp_contrato.NumMesesIncumplidos(id_contrato)
            
            If (Num_meses_incumplidos <= Num_meses_incumplimineto_caja) Then
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReversion", "reactivar_caja") Then
                    lbl_reactivar_si_permitir.Text = "Usted puede reactivar el contrato TerraPlus, tome en cuenta que tiene " & Num_reactivaciones_realizadas.ToString & " reactivación(es) previas y que el cliente incumplió " & Num_meses_incumplidos.ToString & " mes(es)"
                    lbl_reactivar_no_permitir.Text = ""
                    
                    btn_reactivar.Enabled = True
                Else
                    lbl_reactivar_si_permitir.Text = ""
                    lbl_reactivar_no_permitir.Text = "El contrato TerraPlus se puede reactivar pero usted no tiene el permiso requerido"
                End If
            Else
                lbl_reactivar_si_permitir.Text = ""
                lbl_reactivar_no_permitir.Text = "El número de meses de incumplimiento (" + Num_meses_incumplidos.ToString() + ") del contrato supera los permitidos para la reactivación en caja (" + Num_meses_incumplimineto_caja.ToString() + ")"
            End If
        Else
            lbl_reactivar_si_permitir.Text = ""
            lbl_reactivar_no_permitir.Text = "El contrato ya se reactivó " + Num_reactivaciones_realizadas.ToString() + " veces de las " + Num_reactivaciones_admitidas.ToString() + " permitidas"
        End If
    End Sub
    
    Protected Sub CargarDatosSiguientePago()
        gv.DataSource = terrasur.terraplus.tp_pago.ListaUltimoPago(id_contrato)
        gv.DataBind()
        If gv.Rows.Count > 0 Then
            gv.Rows(0).CssClass = "cajaGvRowUltimo"
        End If
    End Sub

    Protected Sub btn_reactivar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reactivar.Click
        Dim ecObj As New terrasur.terraplus.tp_estado_contrato(terrasur.terraplus.tp_estado_contrato.Actual(id_contrato))
        Dim rObj As New terrasur.terraplus.tp_reversion(ecObj.id_reversion)
        If rObj.Reactivar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host) Then
            Cargar()
        Else
            Msg1.Text = "La reactivación NO se realizó correctamente"
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Session("id_contrato") = id_contrato
        Response.Redirect("~/recurso/caja/pagoTerraPlus/Default.aspx")
    End Sub

</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_ingreso" runat="server" GroupingText="Pago TerraPlus">
    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
    <table class="cajaIngresoTable">
        <tr>
            <td class="cajaIngresoTdContenido">
                <table>
                    <tr>
                        <td>
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <asp:Panel ID="panel_revertido" runat="server" GroupingText="Contrato TerraPlus Revertido">
                                        <table cellpadding="0" cellspacing="0" align="center" width="800px">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lbl_reactivar_si_permitir" runat="server" SkinID="lbl_CajaIngresoPermitido"></asp:Label>
                                                    <asp:Label ID="lbl_reactivar_no_permitir" runat="server" SkinID="lbl_CajaIngresoMensaje"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btn_reactivar" runat="server" Text="Reactivar" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <%--<asp:Panel ID="panel1" runat="server" GroupingText="Pagos TerraPlus">--%>
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
                                            <tr><td><br /></td></tr>
                                            <tr><td class="cajaIngresoTdButton"><asp:Button ID="btn_ingresar" runat="server" Text="Realizar pago TerraPlus" CommandArgument="0" /></td></tr>
                                        </table>
                                    <%--</asp:Panel>--%>

                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>