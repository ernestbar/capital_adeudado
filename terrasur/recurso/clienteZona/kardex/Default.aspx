<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Kardex" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteViewDato.ascx" TagName="clienteViewDato" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteViewDireccion.ascx" TagName="clienteViewDireccion" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteViewUpdate.ascx" TagName="clienteViewUpdate" TagPrefix="uc6" %>
<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoDatosReembolso.ascx" tagname="contratoDatosReembolso" tagprefix="uc7" %>

<script runat="server">
    Protected Property id_cliente() As Integer
        Get
            Return Integer.Parse(lbl_id_cliente.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_cliente.Text = value
            CargarDatosCliente()
        End Set
    End Property
    
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs)
        If Request.QueryString("t") IsNot Nothing AndAlso Session("id_cliente") IsNot Nothing Then
            Session.Remove("id_cliente")
        End If
        If Session("id_cliente") IsNot Nothing Then
            general.CambiarMasterPage(Me, False)
        End If
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "kardex", "view") = True Then
                If Session("id_cliente") IsNot Nothing Then
                    id_cliente = Integer.Parse(Session("id_cliente"))
                    btn_volver.Visible = False
                Else
                    btn_volver.Visible = True
                End If
                lb_datos_contrato.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoDatosDetalle")
                lb_plan_original.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoOriginal")
                lb_estado_cuenta.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoEstadoCuenta")
                lb_estado_cuenta_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoEstadoCuentaDetalle")
                lb_plan_restante.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoRestante")
                lb_plan_vigente.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoVigente")
                lb_plan_vigente_detalle.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoVigenteDetalle")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        lbl_id_cliente.Text = "0"
        ContratoBusqueda1.Reset()
        Page.Title = "Kardex"
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        id_cliente = ContratoBusqueda1.id_resultado
    End Sub

    
    Protected Sub CargarDatosCliente()
        MultiView1.ActiveViewIndex = 1
        Dim cli As New cliente(id_cliente)
        Page.Title = "Kardex" & " - " & cli.paterno & " " & cli.materno & " " & cli.nombres & " (" & cli.ci & " " & cli.codigo_lugarcedula & ")"
        lbl_aux.Text = "Kardex" & " - " & cli.paterno & " " & cli.materno & " " & cli.nombres & " (" & cli.ci & " " & cli.codigo_lugarcedula & ")"
        ClienteViewDato1.id_cliente = id_cliente
        ClienteViewDireccion1.id_cliente = id_cliente
        ClienteViewUpdate1.id_cliente = id_cliente
        gv_contrato.DataBind()
        panel_contrato_datos.Visible = False
    End Sub

    Protected Sub gv_contrato_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_contrato.RowCommand
        If e.CommandName = "ver" Then ' AndAlso contrato_estado_especial.VerificarActivo(Integer.Parse(gv_contrato.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString), 0, "", "bloqueado") = False Then
            Page.Title = lbl_aux.Text
            panel_contrato_datos.Visible = True
            Dim _id_contrato As Integer = Integer.Parse(gv_contrato.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
            ContratoDatos1.id_contrato = _id_contrato
            contratoDatosReembolso1.id_contrato = _id_contrato
            Dim num_dias_mora As Integer = pago_mora.DiasMoraPorContrato(_id_contrato)
            lbl_mora.Visible = num_dias_mora.Equals(0).Equals(False)
            If num_dias_mora > 0 Then
                If num_dias_mora = 1 Then
                    lbl_mora.Text = "El contrato esta en mora (1 día)"
                Else
                    lbl_mora.Text = "El contrato esta en mora (" & num_dias_mora & " días)"
                End If
            Else
                lbl_mora.Text = ""
            End If
            
            Dim ica As Decimal = contrato.InteresAcumulado(_id_contrato)
            If ica > 0 Then
                lbl_ica.Text = "El cliente adeuda $us " & ica.ToString("F2") & " por concepto de Interés corriente acumulado"
            Else
                lbl_ica.Text = ""
            End If
            
            lbl_id_contrato.Text = _id_contrato

            Dim tabla_pagos As System.Data.DataTable = pago.ListaPorContratoKardex(_id_contrato)
            GridView1.DataSource = tabla_pagos
            gv_pago.DataSource = tabla_pagos
            
            GridView1.DataBind()
            gv_pago.DataBind()
            
            
            If negocio_contrato.CodigoNegocioPorContrato(_id_contrato) = "nafibo" Then
                Msg1.Text = "CONTRATO NAFIBO"
            End If
            
            Dim codigo_moneda As String = contrato.CodigoMoneda(_id_contrato)
            GridView1.Columns(2).HeaderText = "Cuota"
            GridView1.Columns(5).HeaderText = "Monto (" & codigo_moneda & ")"
            GridView1.Columns(6).HeaderText = "Seg. (" & codigo_moneda & ")"
            GridView1.Columns(7).HeaderText = "Mant. (" & codigo_moneda & ")"
            GridView1.Columns(8).HeaderText = "Interés (" & codigo_moneda & ")"
            GridView1.Columns(9).HeaderText = "Amortiz (" & codigo_moneda & ")"
            GridView1.Columns(10).HeaderText = "Saldo (" & codigo_moneda & ")"
            GridView1.Columns(11).HeaderText = "Mora (" & codigo_moneda & ")"

            gv_pago.Columns(2).HeaderText = "Cuota"
            gv_pago.Columns(5).HeaderText = "Monto (" & codigo_moneda & ")"
            gv_pago.Columns(6).HeaderText = "Seg. (" & codigo_moneda & ")"
            gv_pago.Columns(7).HeaderText = "Mant. (" & codigo_moneda & ")"
            gv_pago.Columns(8).HeaderText = "Interés (" & codigo_moneda & ")"
            gv_pago.Columns(9).HeaderText = "Amortiz (" & codigo_moneda & ")"
            gv_pago.Columns(10).HeaderText = "Saldo (" & codigo_moneda & ")"
            gv_pago.Columns(11).HeaderText = "Mora (" & codigo_moneda & ")"
        End If
    End Sub

    Protected Sub gv_contrato_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_contrato.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            
            Dim id_contrato As Integer = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_contrato").ToString)
            If contrato_estado_especial.BloquearContrato(id_contrato, Profile.entorno.codigo_modulo) = True Then
                e.Row.Cells(0).Controls(0).Visible = False
            End If
        End If
    End Sub

    Protected Sub lb_datos_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_datos_contrato.Click, lb_estado_cuenta.Click, lb_estado_cuenta_detalle.Click, lb_plan_original.Click, lb_plan_restante.Click, lb_plan_vigente.Click, lb_plan_vigente_detalle.Click
        Session("id_contrato") = ContratoDatos1.id_contrato
        WinPopUp1.NavigateUrl = "~/recurso/contrato/reporteContrato/reporteContrato" & CType(sender, LinkButton).CommandName & ".aspx"
        WinPopUp1.Show()
    End Sub
    
    Protected Sub gv_pago_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_pago.DataBound
        If gv_pago.Rows.Count > 0 Then
            gv_pago.Rows(gv_pago.Rows.Count - 1).CssClass = "gvRowSelected"
            gv_pago.Rows(gv_pago.Rows.Count - 1).Font.Bold = True
        End If
    End Sub

    Protected Sub gv_pago_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_pago.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Footer Then
            For i As Integer = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).ToolTip = gv_pago.Columns(i).HeaderText 'gv_pago.HeaderRow.Cells(i).Text
            Next
        End If
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        For Each fila As GridViewRow In GridView1.Rows
            fila.Visible = False
        Next
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="kardex"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_aux" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>

    <table class="priTable">
        <tr><td class="priTdTitle">Kardex</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" buscar_contrato="false"/></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_kardex" runat="server" GroupingText="Kardex del cliente">
                                        <table width="100%"><tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Buscar otro kardex" SkinID="btnVolver" /></td></tr></table>
                                        <table class="tableContenido" align="center">
                                            <%--<tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Buscar otro kardex" SkinID="btnVolver" /></td></tr>--%>
                                            <tr>
                                                <td class="tdGrid">
                                                    <asp:Panel ID="panel_cliente_datos" runat="server" GroupingText="Datos personales del cliente">
                                                        <uc4:clienteViewDato ID="ClienteViewDato1" runat="server" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdGrid">
                                                    <asp:Panel ID="panel_cliente_direccion" runat="server" GroupingText="Direcciones">
                                                        <uc5:clienteViewDireccion ID="ClienteViewDireccion1" runat="server" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdGrid">
                                                    <asp:Panel ID="panel_cliente_modificacion" runat="server" GroupingText="Última actualización de datos">
                                                        <uc6:clienteViewUpdate ID="ClienteViewUpdate1" runat="server" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdGrid">
                                                    <asp:Panel ID="panel_cliente_contratos" runat="server" GroupingText="Contratos del cliente">
                                                        <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_contrato_por_cliente" DataKeyNames="id_contrato">
                                                            <Columns>
                                                                <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                                                <asp:BoundField HeaderText="Nº" DataField="numero" ItemStyle-CssClass="gvCell1" />
                                                                <asp:BoundField HeaderText="Moneda" DataField="codigo_moneda" />
                                                                <asp:BoundField HeaderText="Lote / Servicio" DataField="concepto" />
                                                                <asp:BoundField HeaderText="Estado" DataField="estado" />
                                                                <asp:BoundField HeaderText="Fecha de registro" DataField="fecha" />
                                                                <asp:BoundField HeaderText="Titular" DataField="titular" />
                                                            </Columns>
                                                            <EmptyDataTemplate>El cliente no tiene contratos asociados</EmptyDataTemplate>
                                                        </asp:GridView>
                                                        <%--[id_contrato],[numero],[fecha],[fecha_inicial],[concepto],[titular],[estado]--%>
                                                        <asp:ObjectDataSource ID="ods_lista_contrato_por_cliente" runat="server" TypeName="terrasur.contrato" SelectMethod="Lista_Por_Cliente">
                                                            <SelectParameters><asp:ControlParameter Name="Id_cliente" Type="Int32" ControlID="lbl_id_cliente" PropertyName="Text" /></SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_contrato_datos" runat="server" GroupingText="Datos del contrato" Visible="false">
                                        <uc3:contratoDatos ID="ContratoDatos1" runat="server" />
                                        <table align="center">
                                            <tr><td colspan="2" align="center"><asp:Label ID="lbl_mora" runat="server" SkinID="lbl_CajaIngresoMensaje"></asp:Label></td></tr>
                                            <tr><td colspan="2" align="center"><asp:Label ID="lbl_ica" runat="server" SkinID="lbl_CajaIngresoMensaje"></asp:Label></td></tr>
                                            <tr><td colspan="2" align="left" style="width:800px;"><uc7:contratoDatosReembolso ID="contratoDatosReembolso1" runat="server" /></td></tr>
                                            <tr>
                                                <td colspan="2" valign="top">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="false" DataSourceID="ods_lista_pagos_por_contrato" DataKeyNames="id_transaccion">--%>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="false" DataKeyNames="id_transaccion">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderStyle-Width="30px" DataField="tipo_pago" />
                                                                        <asp:BoundField HeaderStyle-Width="50px" HeaderText="Nº Pago" DataField="num_pago" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Cuota" DataField="string_cuotas" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="60px" HeaderText="F.Pago" DataField="fecha_pago" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                                                        <asp:BoundField HeaderStyle-Width="60px" HeaderText="F.Interes." DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                                                        <asp:BoundField HeaderStyle-Width="60px" HeaderText="Monto" FooterText="Monto" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Seg." FooterText="Seg." DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="40px" HeaderText="Mant." FooterText="Mant." DataField="mantenimiento_sus" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="50px" HeaderText="Interés" FooterText="Int." DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="50px" HeaderText="Amortiz." FooterText="Amortiz." DataField="amortizacion" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="60px" HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="50px" HeaderText="Mora" FooterText="Mora" DataField="interes_penal" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                        <asp:BoundField HeaderStyle-Width="30px" HeaderText="F.P." DataField="forma_pago"/>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                            <td width="18px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Panel ID="panel_pago" runat="server" ScrollBars="Vertical" Height="200" BackImageUrl="~/App_Themes/principal/images/fondowp.gif">
                                                                    <%--<asp:GridView ID="gv_pago" runat="server" AutoGenerateColumns="false" ShowFooter="false" DataSourceID="ods_lista_pagos_por_contrato" DataKeyNames="id_transaccion" ShowHeader="false">--%>
                                                                    <asp:GridView ID="gv_pago" runat="server" AutoGenerateColumns="false" ShowFooter="false" DataKeyNames="id_transaccion" ShowHeader="false">
                                                                        <Columns>
                                                                            <asp:BoundField ItemStyle-Width="30px" DataField="tipo_pago" />
                                                                            <asp:BoundField ItemStyle-Width="50px" HeaderText="Nº Pago" DataField="num_pago" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="40px" HeaderText="Cuota" DataField="string_cuotas" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="60px" HeaderText="F.Pago" DataField="fecha_pago" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                                                            <asp:BoundField ItemStyle-Width="60px" HeaderText="F.Prox." DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                                                            <asp:BoundField ItemStyle-Width="60px" HeaderText="Monto" FooterText="Monto" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="40px" HeaderText="Seg." FooterText="Seg." DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="40px" HeaderText="Mant." FooterText="Mant." DataField="mantenimiento_sus" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="50px" HeaderText="Interés" FooterText="Int." DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="50px" HeaderText="Amortiz." FooterText="Amortiz." DataField="amortizacion" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="60px" HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="50px" HeaderText="Mora" FooterText="Mora" DataField="interes_penal" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                            <asp:BoundField ItemStyle-Width="30px" HeaderText="F.P." DataField="forma_pago"/>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>El contrato no tiene pagos</EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--<asp:ObjectDataSource ID="ods_lista_pagos_por_contrato" runat="server" TypeName="terrasur.pago" SelectMethod="ListaPorContratoKardex">
                                                        <SelectParameters>
                                                            <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td valign="top">
                                                                <table>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_datos_contrato" runat="server" CommandName="DatosDetalle" Text="Ver Datos detallados del contrato"></asp:LinkButton></td></tr>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_plan_original" runat="server" CommandName="PlanPagoOriginal" Text="Ver Plan de pagos Original"></asp:LinkButton></td></tr>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_plan_restante" runat="server" CommandName="PlanPagoRestante" Text="Ver Plan de pagos Restante"></asp:LinkButton></td></tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top">
                                                                <table>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_estado_cuenta" runat="server" CommandName="EstadoCuenta" Text="Ver Estado de cuenta"></asp:LinkButton></td></tr>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_estado_cuenta_detalle" runat="server" CommandName="EstadoCuentaDetalle" Text="Ver Estado de cuenta en detalle"></asp:LinkButton></td></tr>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_plan_vigente" runat="server" CommandName="PlanPagoVigente" Text="Ver Plan de pagos Vigente"></asp:LinkButton></td></tr>
                                                                    <tr><td align="left"><asp:LinkButton ID="lb_plan_vigente_detalle" runat="server" CommandName="PlanPagoVigenteDetalle" Text="Ver Plan de pagos Vigente en detalle"></asp:LinkButton></td></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <asp:WinPopUp id="WinPopUp1" runat="server"></asp:WinPopUp>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
