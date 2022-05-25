<%@ Control Language="VB" ClassName="contratoFormPromotor" %>

<script runat="server">
    Public ReadOnly Property id_grupopromotor() As Integer
        Get
            Return Integer.Parse(ddl_promotor.SelectedValue)
        End Get
    End Property
        
    Protected Sub ddl_grupo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_grupo.DataBound
        ddl_grupo.Items.Insert(0, New ListItem("-------", "0"))
    End Sub

    Protected Sub ddl_promotor_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_promotor.DataBound
        ddl_promotor.Items.Insert(0, New ListItem("Ninguno", "0"))
    End Sub
    
    Public Sub Reset()
        ddl_grupo.DataBind()
        ddl_promotor.DataBind()
    End Sub
    
    Public Function Verificar() As Boolean
        Dim correcto As Boolean = True
        If Integer.Parse(ddl_grupo.SelectedValue) > 0 And Integer.Parse(ddl_promotor.SelectedValue) > 0 And Integer.Parse(ddl_grupo.SelectedValue) <> 7 Then
            Dim gv As grupo_venta = New grupo_venta(Integer.Parse(ddl_grupo.SelectedValue))
            Dim gp As grupo_promotor = New grupo_promotor(Integer.Parse(ddl_promotor.SelectedValue))
            If gv.id_director = gp.id_promotor Then
                correcto = False
                Msg1.Text = "Por disposiciones de la gerencia el director de un grupo no puede realizar ventas"
            End If
        End If
        Return correcto
    End Function
</script>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="5">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdEnun">Grupo de venta:</td>
        <td class="contratoFormTdDato"><asp:DropDownList ID="ddl_grupo" runat="server" DataTextField="nombre" DataValueField="id_grupoventa" DataSourceID="ods_lista_grupo" AutoPostBack="true"></asp:DropDownList></td>
        <td class="contratoFormTdEspacio"></td>
        <td class="contratoFormTdEnun">Promotor:</td>
        <td class="contratoFormTdDato">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" RenderMode="Inline" UpdateMode="Always">
                <Triggers><asp:AsyncPostBackTrigger ControlID="ddl_grupo" EventName="SelectedIndexChanged" /></Triggers>
                <ContentTemplate>
                    <asp:DropDownList ID="ddl_promotor" runat="server" DataTextField="nombre_completo" DataValueField="id_grupopromotor" DataSourceID="ods_lista_promotor"></asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<%--[id_grupoventa],[id_director],[nombre],[num_promotor_activo],[nombre_director]--%>
<asp:ObjectDataSource ID="ods_lista_grupo" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="ListaActivoConPromotor">
    <SelectParameters>
        <asp:Parameter Name="Id_grupoventa" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_grupopromotor],[id_usuario],[nombre_completo],[ci]--%>
<asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaActivoPorGrupo">
    <SelectParameters>
        <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="ddl_grupo" PropertyName="SelectedValue" DefaultValue="0" />
        <asp:Parameter Name="Id_grupopromotor" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
