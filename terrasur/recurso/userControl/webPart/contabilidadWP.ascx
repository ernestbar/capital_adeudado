<%@ Control Language="VB" ClassName="contabilidadWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_reporte()
            recurso_debitoAutomatico()
            recurso_cobrobnb()
            recurso_carteraespecial()
            recurso_seguro_provida()
        End If
    End Sub

    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteContabilidad").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteContabilidad").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/reporteContabilidad/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub

    Protected Sub recurso_debitoAutomatico()
        Dim ver As Boolean = False
        If modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tarjetaCredito").id_recurso) _
        Or modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("grupoTransaccion").id_recurso) Then
            ver = True
        End If
        panel_debito_automatico.Visible = ver
        If ver Then
            lb_tarjetaCredito.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCredito", "view")
            lb_grupoTransaccion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "view")
            lb_reporteDebitosAceptados.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "reporteDebitosAceptados")
        End If
    End Sub

    Protected Sub lb_tarjetaCredito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_tarjetaCredito.Click
        Response.Redirect("~/recurso/contabilidad/debitoatc/tarjetaCredito.aspx")
    End Sub

    Protected Sub lb_grupoTransaccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_grupoTransaccion.Click
        Response.Redirect("~/recurso/contabilidad/debitoatc/grupoTransaccion.aspx")
    End Sub

    Protected Sub lb_reporteDebitosAceptados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_reporteDebitosAceptados.Click
        Response.Redirect("~/recurso/contabilidad/debitoatc/debitosAceptados.aspx")
    End Sub
    
    
    Protected Sub recurso_cobrobnb()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cobrobnb").id_recurso)
        panel_cobrobnb.Visible = ver
        If ver Then
            lb_archivosbnb.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "ver_archivos")
        End If
    End Sub
    Protected Sub lb_archivosbnb_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/cobrobnb/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_carteraespecial()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("contratoEspecial").id_recurso)
        panel_carteraespecial.Visible = ver
        If ver Then
            lb_carteraespecial.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEspecial", "view")
        End If
    End Sub
    Protected Sub lb_carteraespecial_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/contratoEspecial/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_seguro_provida()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("seguro").id_recurso)
        panel_seguro.Visible = ver
        If ver Then
            lb_seguro.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "view")
            lb_seguro_reporte.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "reporte")
        End If
    End Sub
    Protected Sub lb_seguro_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/seguro/Default.aspx")
    End Sub
    Protected Sub lb_seguro_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/seguro/reporteSeguro.aspx")
    End Sub
    
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de contabilidad"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Repeater ID="r_reporte" runat="server" DataSourceID="ods_lista_reporte">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_reporte" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_reporte_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbl_reporte_id_recurso" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:ObjectDataSource ID="ods_lista_reporte" runat="server" TypeName="terrasur.permiso" SelectMethod="ListaPorRecurso">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_recurso" Type="Int32" ControlID="lbl_reporte_id_recurso" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_debito_automatico" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_debito_automatico_titulo" runat="server" SkinID="lblWebPartTitle" Text="Debito automático (ATC)"></asp:Label></td></tr>
                    <%--<tr><td class="wpContenidoTdButton"><asp:Button ID="btn_recibo_transaccion" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>--%>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><asp:LinkButton ID="lb_tarjetaCredito" runat="server" Text="Tarjetas de crédito"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_grupoTransaccion" runat="server" Text="Debito automático (ATC)"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_reporteDebitosAceptados" runat="server" Text="Reporte de debitos aceptados"></asp:LinkButton></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_cobrobnb" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_cobrobnb_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cobros en el BNB"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><asp:LinkButton ID="lb_archivosbnb" runat="server" Text="Generación de archivos BNB" OnClick="lb_archivosbnb_Click"></asp:LinkButton></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Panel ID="panel_carteraespecial" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_carteraespecial_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cartera especial"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><asp:LinkButton ID="lb_carteraespecial" runat="server" Text="Contratos de cartera especial" OnClick="lb_carteraespecial_Click"></asp:LinkButton></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Panel ID="panel_seguro" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_seguro_titulo" runat="server" SkinID="lblWebPartTitle" Text="Seguro de desgravamen"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><asp:LinkButton ID="lb_seguro" runat="server" Text="Asignación de número de seguro" OnClick="lb_seguro_Click"></asp:LinkButton></td></tr>
                                <tr><td><asp:LinkButton ID="lb_seguro_reporte" runat="server" Text="Reporte de Seguro de Desgravamen" OnClick="lb_seguro_reporte_Click"></asp:LinkButton></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
