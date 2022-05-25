<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cambio de tipo de cliente de un contrato" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTipoCliente", "normal_preferencial") = False And _
            permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTipoCliente", "preferencial_normal") = False Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        
        gv_pagos.Columns(6).HeaderText = "Pago(" & c.codigo_moneda & ")"
        gv_pagos.Columns(7).HeaderText = "Saldo(" & c.codigo_moneda & ")"
        
        If c.estado_id <> 2 And c.estado_id <> 3 Then
            Dim tiene_permiso As Boolean = True
            If c.preferencial Then
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTipoCliente", "preferencial_normal") Then
                    panel_cambio.GroupingText = "Cambio de cliente Preferencial a Normal"
                    lbl_tipo1.Text = "Cliente Preferencial"
                    lbl_tipo2.Text = "Cliente Normal"
                Else
                    Msg1.Text = "No tiene permiso de cambiar el tipo de cliente de Preferencial a Normal"
                    tiene_permiso = False
                End If
            Else
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTipoCliente", "normal_preferencial") Then
                    panel_cambio.GroupingText = "Cambio de cliente Normal a Preferencial"
                    lbl_tipo1.Text = "Cliente Normal"
                    lbl_tipo2.Text = "Cliente Preferencial"
                Else
                    Msg1.Text = "No tiene permiso de cambiar el tipo de cliente de Normal a Preferencial"
                    tiene_permiso = False
                End If
            End If
            If tiene_permiso Then
                ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
                Dim min As Decimal = 0
                Dim tabla As Data.DataTable = pago.CambioTipoCliente_ListaPago(ContratoBusqueda1.id_resultado, min)
                tabla.Columns.Add("tipo_pago")
                If tabla.Rows.Count > 0 Then
                    tabla.Rows(0)("tipo_pago") = "Último pago:"
                End If
                If tabla.Rows.Count > 1 Then
                    tabla.Rows(1)("tipo_pago") = "Pago a realizar:"
                End If
                gv_pagos.DataSource = tabla
                gv_pagos.DataBind()
                If gv_pagos.Rows.Count > 0 Then
                    gv_pagos.Rows(0).CssClass = "cajaGvRowUltimo"
                End If
                If gv_pagos.Rows.Count > 1 Then
                    gv_pagos.Rows(1).CssClass = "cajaGvRowNuevo"
                    gv_pagos.Rows(1).Cells(6).CssClass = "cajaGvCellTotal"
                End If
                lbl_monto_dia.Text = min.ToString("F2") & " " & c.codigo_moneda
                btn_cambiar.Enabled = True
                MultiView1.ActiveViewIndex = 1
            End If
        Else
            Msg1.Text = "No esta permitido cambiar el tipo de cliente de contratos Revertidos o Liquidados"
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_cambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        Dim contratoObj As New contrato(ContratoDatos1.id_contrato)
        If contratoObj.CambiarTipoCliente(Profile.id_usuario) Then
            btn_cambiar.Enabled = False
            ContratoDatos1.id_contrato = ContratoDatos1.id_contrato
            Msg2.Text = "El tipo de cliente se cambió correctamente"
        Else
            Msg2.Text = "El tipo de cliente NO se cambió correctamente"
        End If
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cambioTipoCliente"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Cambio de tipo de cliente de un contrato</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr>
                                                <td>
                                                    <table align="center">
                                                        <tr>
                                                            <td class="contratoTdTipoCliente"><asp:Label ID="lbl_tipo1" runat="server"></asp:Label></td>
                                                            <td><asp:Image ID="img_cambiar" runat="server" ImageUrl="~/images/cambiar.gif" /></td>
                                                            <td class="contratoTdTipoCliente"><asp:Label ID="lbl_tipo2" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdGrid">
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gv_pagos" runat="server" AutoGenerateColumns="false">
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
                                                                        <asp:BoundField HeaderText="Pago($us)" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                        <asp:BoundField HeaderText="Saldo($us)" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_monto_dia_enun" runat="server" SkinID="lblEnun" Text="Pago mínimo (para ponerse al día en el pago del seguro, mantenimiento e intereses):"></asp:Label>
                                                                <asp:Label ID="lbl_monto_dia" runat="server" SkinID="lblDato"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr><td class="tdMsg"><asp:Msg ID="Msg2" runat="server"></asp:Msg></td></tr>
                                            <tr><td class="tdButtonRealizarAccion"><asp:Button ID="btn_cambiar" runat="server" Text="Realizar cambio" TextoEnviando="Realizando el cambio" OnClientClick="return confirm('¿Esta seguro que desea cambiar el tipo de cliente del contrato?');" /></td></tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
