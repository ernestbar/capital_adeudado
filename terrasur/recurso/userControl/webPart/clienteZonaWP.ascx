<%@ Control Language="VB" ClassName="clienteZonaWP" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_cliente()
            recurso_sector()
            recurso_zona()
            recurso_kardex()
            recurso_reporte()
        End If
    End Sub
    
    
    Protected Sub recurso_cliente()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("cliente").id_recurso)
        panel_cliente.Visible = ver
        If ver Then
            Dim p As Integer = 0, t As Integer = 0
            cliente.NumeroClientes(p, t)
            lbl_cliente_num.Text = "Permanentes (" & p & "), Transitorios (" & t & ")"
            btn_cliente.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cliente", "view")
        End If
    End Sub
    Protected Sub btn_cliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cliente.Click
        Response.Redirect("~/recurso/clienteZona/cliente/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_sector()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("sectorZona").id_recurso)
        panel_sector.Visible = ver
        If ver Then
            lbl_sector_num.Text = "Nº de sectores: " & sector_zona.Lista.Rows.Count
            btn_sector.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sectorZona", "view")
        End If
    End Sub
    Protected Sub btn_sector_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sector.Click
        Response.Redirect("~/recurso/clienteZona/sectorZona/Default.aspx")
    End Sub
    
    
    Protected Sub recurso_zona()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("zona").id_recurso)
        panel_zona.Visible = ver
        If ver Then
            lbl_zona_num.Text = "Nº de zonas: " & zona.Lista(0).Rows.Count
            btn_zona.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "zona", "view")
        End If
    End Sub
    Protected Sub btn_zona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_zona.Click
        Response.Redirect("~/recurso/clienteZona/zona/Default.aspx")
    End Sub

    
    Protected Sub recurso_kardex()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("kardex").id_recurso)
        panel_kardex.Visible = ver
        If ver Then
            btn_kardex.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "kardex", "view")
        End If
    End Sub
    Protected Sub btn_kardexClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_kardex.Click
        Response.Redirect("~/recurso/clienteZona/kardex/Default.aspx?t=")
    End Sub
    
    Protected Sub recurso_reporte()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("reporteClienteZona").id_recurso)
        panel_reporte.Visible = ver
        If ver Then
            lbl_reporte_id_recurso.Text = New recurso("reporteClienteZona").id_recurso
            r_reporte.DataBind()
        End If
    End Sub
    Protected Sub r_reporte_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_reporte.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lb_reporte"), LinkButton).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteClienteZona", DataBinder.Eval(e.Item.DataItem, "codigo").ToString)
        End If
    End Sub
    Protected Sub lb_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/clienteZona/reporteClienteZona/" & CType(sender, LinkButton).CommandArgument & ".aspx")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_cliente" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_cliente_titulo" runat="server" SkinID="lblWebPartTitle" Text="Clientes"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:Label ID="lbl_cliente_num" runat="server"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_cliente" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_sector" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_sector_titulo" runat="server" SkinID="lblWebPartTitle" Text="Sectores de la ciudad"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:Label ID="lbl_sector_num" runat="server"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_sector" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_zona" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_zona_titulo" runat="server" Text="Zonas" SkinID="lblWebPartTitle"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTd"><asp:Label ID="lbl_zona_num" runat="server"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_zona" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_kardex" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_kardex_titulo" runat="server" Text="Kardex" SkinID="lblWebPartTitle"></asp:Label></td></tr>
                    <tr><td class="wpContenidoTdButton"><asp:Button ID="btn_kardex" runat="server" Text="Entrar" SkinID="btnWebPart" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
     <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_reporte_titulo" runat="server" SkinID="lblWebPartTitle" Text="Reportes de Clientes y Zonificación"></asp:Label></td></tr>
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
