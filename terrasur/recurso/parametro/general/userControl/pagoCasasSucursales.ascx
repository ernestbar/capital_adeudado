<%@ Control Language="VB" ClassName="pagoCasasSucursales" %>
<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            btn_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Public Sub CargarActualizar()
        Dim p_sucursal_permitir_pago_casas As New parametro("sucursal_permitir_pago_casas")

        If p_sucursal_permitir_pago_casas.valor = 1 Then
            rbl_sucursal_permitir_pago_casas.SelectedValue = "1"
        Else
            rbl_sucursal_permitir_pago_casas.SelectedValue = "0"
        End If
        
        MultiView1.ActiveViewIndex = 0
        rbl_sucursal_permitir_pago_casas.Enabled = False
    End Sub

    Protected Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        MultiView1.ActiveViewIndex = 1
        rbl_sucursal_permitir_pago_casas.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        CargarActualizar()
    End Sub
    
    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Dim p_sucursal_permitir_pago_casas As New parametro("sucursal_permitir_pago_casas")

        If rbl_sucursal_permitir_pago_casas.SelectedValue = "1" Then
            p_sucursal_permitir_pago_casas.valor = 1
        Else
            p_sucursal_permitir_pago_casas.valor = 0
        End If
        
        If p_sucursal_permitir_pago_casas.Actualizar(Profile.id_usuario) Then
            Msg4.Text = "El parámetro de pagos a contratos de Casas y Departamentos se actualizó correctamente"
            CargarActualizar()
        Else
            Msg4.Text = "El parámetro de pagos a contratos de Casas y Departamentos NO se actualizó correctamente"
        End If
    End Sub
</script>

<asp:Panel ID="panel_sucursal_casas" runat="server" GroupingText="Pagos a contratos de Casas y Departamentos en Sucursales">
    <table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formHorTdMsg" colspan="2">
                <asp:Msg ID="Msg4" runat="server"></asp:Msg>
            </td>
        </tr>
        <tr>
            <td class="formHorTdEnun1">Permitir pagos:</td>
            <td class="formHorTdDato">
                <asp:RadioButtonList ID="rbl_sucursal_permitir_pago_casas" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                    <asp:ListItem Text="No cobrar en Sucursales" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Cobrar en Sucursales" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View id="View1" runat="server">
            <table class="formEntTable">
                <tr>
                    <td class="formEntTdButtonParam">
                        <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CausesValidation="false" SkinID="btnAccion"/>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table class="formEntTable">
                <tr>
                    <td class="formEntTdButtonParam">
                        <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="false"/>
                        <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion"/>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Panel>