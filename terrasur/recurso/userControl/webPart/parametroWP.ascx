<%@ Control Language="VB" ClassName="parametroWP" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            recurso_parametro()
            If Profile.entorno.id_rol = 1 Then
                lbtnCiclos.Visible = True
            Else
                lbtnCiclos.Visible = False
            End If
        End If
        
    End Sub

    
    Protected Sub recurso_parametro()
        lbl_id_gruporecurso.Text = New grupo_recurso("parametro").id_gruporecurso
        r_parametro.DataBind()
        
        Dim ver As Boolean = False
        For Each item As RepeaterItem In r_parametro.Items
            If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
                If CType(item.FindControl("lb_parametro"), LinkButton).Visible = True Then
                    ver = True
                    Exit For
                End If
            End If
        Next
        panel_parametro.Visible = ver
    End Sub
    Protected Sub lb_parametro_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/parametro/" & CType(sender, LinkButton).CommandArgument & "/Default.aspx")
    End Sub

    Protected Sub r_parametro_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles r_parametro.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim id_recurso As Integer = Integer.Parse(DataBinder.Eval(e.Item.DataItem, "id_recurso").ToString)
            Dim codigo As String = DataBinder.Eval(e.Item.DataItem, "codigo").ToString
            If modulo_recurso.Verificar(Profile.entorno.id_modulo, id_recurso) = True Then
                If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, codigo, "view") Then
                    CType(e.Item.FindControl("lb_parametro"), LinkButton).Visible = False
                End If
            Else
                CType(e.Item.FindControl("lb_parametro"), LinkButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub lbtnCiclos_Click(sender As Object, e As System.EventArgs)
        Response.Redirect("http://10.10.10.15:2231")
    End Sub
</script>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_parametro" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle"><asp:Label ID="lbl_parametro_titulo" runat="server" SkinID="lblWebPartTitle" Text="Parámetros"></asp:Label></td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Repeater ID="r_parametro" runat="server" DataSourceID="ods_lista_parametro">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_parametro" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_parametro_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbl_id_gruporecurso" runat="server" Text="0" Visible="false"></asp:Label>
                            <%--[id_recurso],[id_gruporecurso],[codigo],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_lista_parametro" runat="server" TypeName="terrasur.recurso" SelectMethod="ListaPorGrupoRecurso">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_gruporecurso" Type="Int32" ControlID="lbl_id_gruporecurso" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                            <asp:LinkButton ID="lbtnCiclos" runat="server" onclick="lbtnCiclos_Click">Dosificacion Ciclos</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
