<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Generación de datos Nafibo" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<%@ Register src="~/recurso/herramienta/datosNafibo/userControl/ejecutadoProyectado.ascx" tagname="ejecutadoProyectado" tagprefix="uc2" %>
<%@ Register src="~/recurso/herramienta/datosNafibo/userControl/tablas.ascx" tagname="tablas" tagprefix="uc3" %>
<%@ Register src="~/recurso/herramienta/datosNafibo/userControl/formatoNafibo.ascx" tagname="formatoNafibo" tagprefix="uc4" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Page.IsPostBack = False Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "ingresar_ajuste_pago") = True Then
                lbl_fecha_inicio.Text = DateTime.Now.ToString("d")
                lbl_fecha_fin.Text = DateTime.Now.ToString("d")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub gv_pago_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_pago.DataBound
        If gv_pago.Rows.Count > 0 Then
            gv_pago.Columns(9).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "generar_ajuste_pago")
            
            Dim estilo As String = "gvRow1"
            If rbl_orden.SelectedValue = "num_contrato" Then
                Dim num_contrato As String = gv_pago.Rows(0).Cells(1).Text
                For Each fila As GridViewRow In gv_pago.Rows
                    If fila.Cells(1).Text <> num_contrato Then
                        If estilo = "gvRow1" Then
                            estilo = "gvRowSelected"
                        Else
                            estilo = "gvRow1"
                        End If
                        num_contrato = fila.Cells(1).Text
                    End If
                    fila.CssClass = estilo
                Next
            Else
                Dim mes As String = DateTime.Parse(gv_pago.Rows(0).Cells(2).Text).ToString("MMM")
                For Each fila As GridViewRow In gv_pago.Rows
                    If DateTime.Parse(fila.Cells(2).Text).ToString("MMM") <> mes Then
                        If estilo = "gvRow1" Then
                            estilo = "gvRowSelected"
                        Else
                            estilo = "gvRow1"
                        End If
                        mes = DateTime.Parse(fila.Cells(2).Text).ToString("MMM")
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
                CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).Visible = True
                If permitir_ajustar = True Then
                    CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).Text = "Ajustar"
                    CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).CommandName = "ajustar"
                    CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).OnClientClick = "return confirm('Esta seguro que desea realizar el ajuste?');"
                Else
                    CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).Text = "Deshacer"
                    CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).CommandName = "deshacer"
                    CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).OnClientClick = "return confirm('Esta seguro que desea deshacer el ajuste?');"
                End If
            Else
                CType(e.Row.Cells(9).FindControl("lb_accion"), LinkButton).Visible = False
            End If
            '
            
        End If
    End Sub

    Protected Sub gv_pago_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_pago.RowCommand
        If e.CommandName = "ajustar" Then
            'Dim id_pago As Integer = Integer.Parse(gv_pago.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value)
            Dim id_pago As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(1))
            Dim id_pagonafibo As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(2))
            Dim id_contrato As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(3))
            
            If pagoEspecialNafibo.Verificar(id_pago, id_pagonafibo) = False Then
                'Dim Id_pago_anterior As Integer = pago_especial_nafibo.AnteriorPago(id_pago)
                'If pago_especial_nafibo.Verificar(Id_pago_anterior) = True Then
                If pagoEspecialNafibo.Ajustar(id_contrato, id_pago, id_pagonafibo, Profile.id_usuario) Then
                    Msg1.Text = "El pago se ajustó correctamente"
                Else
                    Msg1.Text = "El pago NO se ajustó correctamente"
                End If
                gv_pago.DataBind()
                'Else
                '    Msg1.Text = "Primero debe ajustar el pago anterior"
                'End If
            Else
                Msg1.Text = "El pago ya fue ajustado"
            End If
            
        ElseIf e.CommandName = "deshacer" Then
            Dim id_pagoespecialnafibo As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(0))
            If id_pagoespecialnafibo > 0 Then
                Dim penObj As New pagoEspecialNafibo(id_pagoespecialnafibo, 0, 0)
                If penObj.Deshacer(Profile.id_usuario) Then
                    Msg1.Text = "El ajuste se deshizo correctamente"
                    gv_pago.DataBind()
                Else
                    Msg1.Text = "El ajuste NO se deshizo correctamente"
                End If
            End If
        End If
    End Sub

    Protected Sub btn_obtener_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_obtener.Click
        lbl_fecha_inicio.Text = cp_inicio.SelectedDate.ToString("d")
        lbl_fecha_fin.Text = cp_fin.SelectedDate.ToString("d")
        gv_pago.DataBind()
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Response.Redirect("~/recurso/herramienta/datosNafibo/Default.aspx")
    End Sub

    Protected Function ClavesConcatenadas(ByVal Id_pagoespecialnafibo As String, ByVal Id_pago As String, ByVal Id_pagonafibo As String, ByVal Id_contrato As String) As String
        Return Id_pagoespecialnafibo & "," & Id_pago & "," & Id_pagonafibo & "," & Id_contrato
    End Function
    
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="datosNafibo" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Generación de datos Nafibo</td>
    </tr>
    <tr>
        <td class="priTdTitle">Contratos especiales y ajustes de montos de pago</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <asp:Label ID="lbl_fecha_inicio" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lbl_fecha_fin" runat="server" Visible="false"></asp:Label>
            <table>
                <tr>
                    <td>
                        <table align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3" align="right">
                                    <asp:Button ID="btn_volver" runat="server" Text="Volver" SkinID="btnVolver" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Panel ID="panel_contrato_especial_nafibo" runat="server" Height="200" ScrollBars="Vertical">
                                    <asp:GridView ID="gv_contrato" runat="server" DataSourceID="ods_lista_contrato_especial" AutoGenerateColumns="false" DataKeyNames="id_contrato">
                                        <Columns>
                                            <%--<asp:BoundField DataField="num_contrato" HeaderText="Nº contrato" ItemStyle-CssClass="gvCell1" />--%>
                                            <asp:TemplateField ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_lote" runat="server" Text='<%# Eval("num_contrato") %>' ToolTip='<%# Eval("observacion") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField DataField="lote" HeaderText="Lote" />
                                            <asp:BoundField DataField="cuota_frecuente" HeaderText="Cuota frecuente" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField DataField="cuota_base" HeaderText="Cuota base" ItemStyle-CssClass="gvCell1" />
                                        </Columns>
                                    </asp:GridView>
                                    </asp:Panel>
                                    <%--[id_contrato],[num_contrato],[lote],[cuota_base],[cuota_frecuente]--%>
                                    <asp:ObjectDataSource ID="ods_lista_contrato_especial" runat="server" TypeName="terrasur.contrato_especial_nafibo" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                                <td style="width:15px;"></td>
                                <td valign="top">
                                    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="formTdEnun">Periodo:</td>
                                            <td class="formTdDato">
                                                <ew:CalendarPopup ID="cp_inicio" runat="server"></ew:CalendarPopup>
                                                -
                                                <ew:CalendarPopup ID="cp_fin" runat="server"></ew:CalendarPopup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTdEnun">Nº contrato:</td>
                                            <td class="formTdDato"><asp:TextBox ID="txt_num_contrato" runat="server" Width="100"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="formTdEnun">Orden:</td>
                                            <td class="formTdDato">
                                                <asp:RadioButtonList ID="rbl_orden" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Nº contrato" Value="num_contrato" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Fecha de pago" Value="fecha_pago"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="btn_obtener" runat="server" Text="Obtener datos" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gv_pago" runat="server" DataSourceID="ods_lista_pago_especial" AutoGenerateColumns="false" DataKeyNames="id_pagoespecialnafibo,id_pago,id_pagonafibo,id_contrato">
                            <Columns>
                                <asp:BoundField DataField="tipo" HeaderText="Tipo pago" />
                                <asp:BoundField DataField="num_contrato" HeaderText="Nº contrato" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="fecha" HeaderText="F.Pago" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                
                                <asp:BoundField DataField="fuera_hora" HeaderText="Fuera de hora" />

                                <asp:BoundField DataField="monto_pago" HeaderText="Monto" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="interes" HeaderText="Interés" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="amortizacion" HeaderText="Capital" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="saldo" HeaderText="Saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="interes_fecha" HeaderText="F.Interes" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_accion" runat="server" CommandArgument='<%# ClavesConcatenadas(Eval("id_pagoespecialnafibo").ToString(),Eval("id_pago").ToString(),Eval("id_pagonafibo").ToString(),Eval("id_contrato").ToString()) %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="e_fecha" HeaderText="Fecha Aj." HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="e_monto_pago" HeaderText="Monto Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="e_interes" HeaderText="Interés Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="e_amortizacion" HeaderText="Capital Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="e_saldo" HeaderText="Saldo Aj." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField DataField="e_interes_fecha" HeaderText="F.Interes Aj." HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                                
                                <asp:BoundField DataField="diferencia" HeaderText="Difer." HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                            </Columns>
                        </asp:GridView>
                        <%--[tipo],[id_pagoespecialnafibo],[id_pago],[id_pagonafibo],[id_contrato]
                            [num_contrato][fecha],[monto_pago],[interes],[amortizacion],[saldo],[interes_fecha]
                            [permitir_ajustar],[permitir_deshacer],[fuera_hora]
                            [e_monto_pago],[e_interes],[e_amortizacion],[e_saldo],[e_interes_fecha],[diferencia]--%>
                        <asp:ObjectDataSource ID="ods_lista_pago_especial" runat="server" TypeName="terrasur.pagoEspecialNafibo" SelectMethod="Lista">
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
</asp:Content>

