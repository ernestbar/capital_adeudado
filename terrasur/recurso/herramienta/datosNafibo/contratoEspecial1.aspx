<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Page.IsPostBack = False Then
            lbl_fecha_inicio.Text = DateTime.Now.ToString("d")
            lbl_fecha_fin.Text = DateTime.Now.ToString("d")
        End If
    End Sub

    Protected Sub gv_pago_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_pago.DataBound
        If gv_pago.Rows.Count > 0 Then
            gv_pago.Columns(8).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "generar_ajuste_pago")
            
            Dim estilo As String = "gvRow1"
            If rbl_orden.SelectedValue = "num_contrato" Then
                Dim num_contrato As String = gv_pago.Rows(0).Cells(0).Text
                For Each fila As GridViewRow In gv_pago.Rows
                    If fila.Cells(0).Text <> num_contrato Then
                        If estilo = "gvRow1" Then
                            estilo = "gvRowSelected"
                        Else
                            estilo = "gvRow1"
                        End If
                        num_contrato = fila.Cells(0).Text
                    End If
                    fila.CssClass = estilo
                Next
            Else
                Dim mes As String = DateTime.Parse(gv_pago.Rows(0).Cells(1).Text).ToString("MMM")
                For Each fila As GridViewRow In gv_pago.Rows
                    If DateTime.Parse(fila.Cells(1).Text).ToString("MMM") <> mes Then
                        If estilo = "gvRow1" Then
                            estilo = "gvRowSelected"
                        Else
                            estilo = "gvRow1"
                        End If
                        mes = DateTime.Parse(fila.Cells(1).Text).ToString("MMM")
                    End If
                    fila.CssClass = estilo
                Next
            End If
        End If
    End Sub

    Protected Sub gv_pago_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_pago.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            'e.Row.Cells(8).Controls(0).Visible = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_ajustar").ToString)
            'e.Row.Cells(9).Controls(0).Visible = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_deshacer").ToString)

            Dim permitir_ajustar As Boolean = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_ajustar").ToString)
            Dim permitir_deshacer As Boolean = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_deshacer").ToString)
            If permitir_ajustar = True Or permitir_deshacer = True Then
                CType(e.Row.Cells(8).FindControl("lb_accion"), LinkButton).Visible = True
                If permitir_ajustar = True Then
                    CType(e.Row.Cells(8).FindControl("lb_accion"), LinkButton).Text = "Ajustar"
                    CType(e.Row.Cells(8).FindControl("lb_accion"), LinkButton).CommandName = "ajustar"
                Else
                    CType(e.Row.Cells(8).FindControl("lb_accion"), LinkButton).Text = "Deshacer"
                    CType(e.Row.Cells(8).FindControl("lb_accion"), LinkButton).CommandName = "deshacer"
                End If
            Else
                CType(e.Row.Cells(8).FindControl("lb_accion"), LinkButton).Visible = False
            End If
            '
            
        End If
    End Sub

    Protected Sub gv_pago_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_pago.RowCommand
        If e.CommandName = "ajustar" Then
            'Dim id_pago As Integer = Integer.Parse(gv_pago.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value)
            Dim id_pago As Integer = Integer.Parse(e.CommandArgument.ToString)
            If pago_especial_nafibo.Verificar(id_pago) = False Then
                Dim Id_pago_anterior As Integer = pago_especial_nafibo.AnteriorPago(id_pago)
                If pago_especial_nafibo.Verificar(Id_pago_anterior) = True Then
                    If pago_especial_nafibo.Ajustar(id_pago, Profile.id_usuario) Then
                        Msg1.Text = "El pago se ajustó correctamente"
                    Else
                        Msg1.Text = "El pago NO se ajustó correctamente"
                    End If
                    gv_pago.DataBind()
                Else
                    Msg1.Text = "Primero debe ajustar el pago anterior"
                End If
            Else
                Msg1.Text = "El pago ya fue ajustado"
            End If
            
        ElseIf e.CommandName = "deshacer" Then
            Dim id_pago As Integer = Integer.Parse(e.CommandArgument.ToString)
            Dim penObj As New pago_especial_nafibo(id_pago)
            If penObj.Deshacer(Profile.id_usuario) Then
                Msg1.Text = "El ajuste se deshizo correctamente"
                gv_pago.DataBind()
            Else
                Msg1.Text = "El ajuste NO se deshizo correctamente"
            End If
        End If
    End Sub

    Protected Sub btn_obtener_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_obtener.Click
        lbl_fecha_inicio.Text = cp_inicio.SelectedDate.ToString("d")
        lbl_fecha_fin.Text = cp_fin.SelectedDate.ToString("d")
        gv_pago.DataBind()
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_fecha_inicio" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lbl_fecha_fin" runat="server" Visible="false"></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gv_contrato" runat="server" DataSourceID="ods_lista_contrato_especial" AutoGenerateColumns="false" DataKeyNames="id_contrato">
                        <Columns>
                            <asp:BoundField DataField="num_contrato" HeaderText="Nº contrato" ItemStyle-CssClass="gvCell1" />
                            <asp:BoundField DataField="lote" HeaderText="Lote" />
                            <asp:BoundField DataField="cuota_frecuente" HeaderText="Cuota frecuente" ItemStyle-CssClass="gvCell1" />
                            <asp:BoundField DataField="cuota_base" HeaderText="Cuota base" ItemStyle-CssClass="gvCell1" />
                        </Columns>
                    </asp:GridView>
                    <%--[id_contrato],[num_contrato],[lote],[cuota_base],[cuota_frecuente]--%>
                    <asp:ObjectDataSource ID="ods_lista_contrato_especial" runat="server" TypeName="terrasur.contrato_especial_nafibo" SelectMethod="Lista">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>Periodo:</td>
                                        <td>
                                            <ew:CalendarPopup ID="cp_inicio" runat="server"></ew:CalendarPopup>
                                            -
                                            <ew:CalendarPopup ID="cp_fin" runat="server"></ew:CalendarPopup>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nº contrato:</td>
                                        <td><asp:TextBox ID="txt_num_contrato" runat="server" Width="100"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Orden:</td>
                                        <td>
                                            <asp:RadioButtonList ID="rbl_orden" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Nº contrato" Value="num_contrato" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Fecha de pago" Value="fecha_pago"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_obtener" runat="server" Text="Obtener datos" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gv_pago" runat="server" DataSourceID="ods_lista_pago_especial" AutoGenerateColumns="false" DataKeyNames="id_pago">
                                    <Columns>
                                        <asp:BoundField DataField="num_contrato" HeaderText="Nº contrato" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="fecha" HeaderText="F.Pago" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                        
                                        <asp:BoundField DataField="fuera_hora" HeaderText="Fuera de hora" />

                                        <asp:BoundField DataField="monto_pago" HeaderText="Monto" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="interes" HeaderText="Interés" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="amortizacion" HeaderText="Capital" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="saldo" HeaderText="Saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="interes_fecha" HeaderText="F.Interes" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                        
                                        <%--<asp:ButtonField Text="Ajustar" CommandName="ajustar" />
                                        <asp:ButtonField Text="Deshacer" CommandName="deshacer" />--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lb_accion" runat="server" CommandArgument='<%# Eval("id_pago") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="e_monto_pago" HeaderText="Monto Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="e_interes" HeaderText="Interés Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="e_amortizacion" HeaderText="Capital Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="e_saldo" HeaderText="Saldo Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField DataField="e_interes_fecha" HeaderText="F.Interes Aj." HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                        
                                        <asp:BoundField DataField="diferencia" HeaderText="Difer." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                    </Columns>
                                </asp:GridView>
                                <%--[id_pago],[num_contrato],[fecha],[monto_pago],[interes],[amortizacion],[saldo],[interes_fecha], [permitir_ajustar],[permitir_deshacer]
                                    [fuera_hora],[e_monto_pago],[e_interes],[e_amortizacion],[e_saldo],[e_interes_fecha],[diferencia]--%>
                                <asp:ObjectDataSource ID="ods_lista_pago_especial" runat="server" TypeName="terrasur.pago_especial_nafibo" SelectMethod="Lista">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Fecha_inicio" Type="DateTime" ControlID="lbl_fecha_inicio" PropertyName="Text" />
                                        <asp:ControlParameter Name="Fecha_fin" Type="DateTime" ControlID="lbl_fecha_fin" PropertyName="Text" />
                                        <asp:ControlParameter Name="Num_contrato" Type="String" ControlID="txt_num_contrato" PropertyName="Text" /> 
                                        <asp:ControlParameter Name="Orden" Type="String" ControlID="rbl_orden" DefaultValue="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
