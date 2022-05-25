<%@ Control Language="VB" ClassName="busquedaViewDesactivacion" %>

<script runat="server">
    Public Property numero_recibo() As Integer
        Get
            Return Integer.Parse(lbl_numero.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_numero.Text = value.ToString()
            CargarDatos()
        End Set
    End Property
    Private Sub CargarDatos()
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "desactivar") Then
            btn_desactivar.Enabled = True
            Dim recibo As New recibo_cobrador(0, numero_recibo)
            If recibo.id_recibocobrador > 0 AndAlso recibo.activo = True Then
                panel_desactivacion.Visible = True
                lbl_id_recibocobrador.Text = recibo.id_recibocobrador.ToString()
            Else
                lbl_id_recibocobrador.Text = "0"
                panel_desactivacion.Visible = False
            End If
        Else
            btn_desactivar.Enabled = False
        End If
    End Sub
    
    Private Sub Actualizar()
        If ddl_motivo.Items.Count > 0 Then
            Dim recibo As New recibo_cobrador(Int32.Parse(lbl_id_recibocobrador.Text), 0)
            recibo.id_motivodesactivacion = Int32.Parse(ddl_motivo.SelectedValue)
            If recibo.Desactivar(Profile.id_usuario) Then
                Msg1.Text = "El recibo se desactivó correctamente"
                Msg1.Show() = True
            Else
                Msg1.Text = "El recibo NO se desactivó correctamente"
                Msg1.Show() = True
            End If
        Else
            Msg1.Text = "No exiten motivos de desactivación registrados"
            Msg1.Show() = True
        End If
    End Sub
    
    Protected Sub btn_desactivar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Int32.Parse(lbl_id_recibocobrador.Text) > 0 Then
            Actualizar()
        End If
    End Sub
</script>

<asp:Label ID="lbl_numero" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_recibocobrador" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Panel ID="panel_desactivacion" runat="server" Width="100%" GroupingText="Desactivación del recibo" Visible="false">
<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_motivo_enun" runat="server" Text="Motivo de la desactivación:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddl_motivo" runat="server" AutoPostBack="true" DataSourceID="ods_motivo_lista"
                DataTextField="nombre" DataValueField="id_motivodesactivacion">
            </asp:DropDownList>
            <%--[id_motivodesactivacion],[nombre]--%>
            <asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.motivo_desactivacion"
                SelectMethod="Lista"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formEntTdButton">
            <asp:Button ID="btn_desactivar" runat="server" Text="Desactivar Recibo" SkinID="btnAccion"
                OnClick="btn_desactivar_Click" />
    </tr>
</table>
</asp:Panel>
