<%@ Control Language="VB" ClassName="terraplusWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_contrato()
            recurso_plan()
            recurso_reversion()
            recurso_servicioPrestado()
            recurso_estadoContrato()
            recurso_parametro()
            recurso_reporte()
        End If
    End Sub
    
    Protected Sub recurso_contrato()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpContrato").id_recurso)
        panel_contrato.Visible = ver
        If ver Then
            btn_contrato_lista.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "view")
            btn_contrato_insert.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "insert")
        End If
    End Sub
    Protected Sub btn_contrato_lista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_contrato_lista.Click
        Response.Redirect("~/recurso/terraplus/tpContrato/Default.aspx")
    End Sub
    Protected Sub btn_contrato_insert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpContrato/nuevoContrato.aspx")
    End Sub
    
    Protected Sub recurso_plan()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpPlan").id_recurso)
        panel_plan.Visible = ver
        If ver Then
            btn_plan_insert.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpPlan", "insert")
        End If
    End Sub
    Protected Sub btn_plan_insert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpPlan/Default.aspx")
    End Sub

    Protected Sub recurso_reversion()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpReversion").id_recurso)
        panel_reversion.Visible = ver
        If ver Then
            'Para reversiones
            btn_reversion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReversion", "revertir")
            
            'Para reactivaciones
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReversion", "reactivar") Then
                btn_reactivar.Visible = True
            ElseIf Profile.entorno.codigo_modulo <> "adm" And permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReversion", "reactivar_marketing") Then
                btn_reactivar.Visible = True
            Else
                btn_reactivar.Visible = False
            End If
        End If
    End Sub
    Protected Sub btn_reversion_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpReversion/Default.aspx")
    End Sub
    Protected Sub btn_reactivar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpReversion/reactivacion.aspx")
    End Sub

    Protected Sub recurso_servicioPrestado()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpServicioPrestado").id_recurso)
        panel_servicioPrestado.Visible = ver
        If ver Then
            btn_servicioPrestado.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpServicioPrestado", "insert")
        End If
    End Sub
    Protected Sub btn_servicioPrestado_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpServicioPrestado/Default.aspx")
    End Sub

    Protected Sub recurso_estadoContrato()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpEstadoContrato").id_recurso)
        panel_estadoContrato.Visible = ver
        If ver Then
            btn_estadoContrato.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpEstadoContrato", "update")
        End If
    End Sub
    Protected Sub btn_estadoContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpEstadoContrato/Default.aspx")
    End Sub

    Protected Sub recurso_parametro()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpParametro").id_recurso)
        panel_parametro.Visible = ver
        If ver Then
            btn_parametro.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpParametro", "view")
        End If
    End Sub
    Protected Sub btn_parametro_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpParametro/Default.aspx")
    End Sub

    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("tpReporte").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("tpReporte").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReporte", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/terraplus/tpReporte/" & CType(sender, LinkButton).CommandArgument & ".aspx?t=")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_contrato_titulo" runat="server" SkinID="lblWebPartTitle" Text="Contratos TerraPlus"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_contrato_lista" runat="server" Text="Listado" SkinID="btnWebPart" />
                            <asp:Button ID="btn_contrato_insert" runat="server" Text="Registrar" SkinID="btnWebPart" OnClick="btn_contrato_insert_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_plan" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_plan_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reprogramar Plan TerraPlus"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_plan_insert" runat="server" Text="Reprogramar" SkinID="btnWebPart" OnClick="btn_plan_insert_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reversion" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reversion_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reversiones TerraPlus"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_reversion" runat="server" Text="Revertir" SkinID="btnWebPart" OnClick="btn_reversion_Click" />
                            <asp:Button ID="btn_reactivar" runat="server" Text="Reactivar" SkinID="btnWebPart" OnClick="btn_reactivar_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_servicioPrestado" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_servicioPrestado_titulo" runat="server" SkinID="lblWebPartTitle" Text="Servicio Prestado TerraPlus"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_servicioPrestado" runat="server" Text="Registro de Servicio" SkinID="btnWebPart" OnClick="btn_servicioPrestado_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_estadoContrato" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_estadoContrato_titulo" runat="server" SkinID="lblWebPartTitle" Text="Cambio de estado de contratos"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_estadoContrato" runat="server" Text="Cambiar estado" SkinID="btnWebPart" OnClick="btn_estadoContrato_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_parametro" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_parametro_titulo" runat="server" SkinID="lblWebPartTitle" Text="Parámetros TerraPlus"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <asp:Button ID="btn_parametro" runat="server" Text="Entrar" SkinID="btnWebPart" OnClick="btn_parametro_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de contratos TerraPlus"></asp:Label></td></tr>
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
</table>