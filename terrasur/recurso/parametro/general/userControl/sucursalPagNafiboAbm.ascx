<%@ Control Language="VB" ClassName="sucursalPagNafiboAbm" %>
<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            tp_lun_vie.Enabled = False
            txt_lun_vie.Enabled = False
            tp_sabado.Enabled = False
            txt_sabado.Enabled = False
            btn_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Public Sub CargarActualizar()
        Dim p_sucursal_permitir_pago_nafibo As New parametro("sucursal_permitir_pago_nafibo")
        Dim p_lun_vie_hora As New parametro("sucursal_fuera_hora_lun_vie_hora")
        Dim p_lun_vie_dias As New parametro("sucursal_fuera_hora_lun_vie_dias")
        Dim p_sabado_hora As New parametro("sucursal_fuera_hora_sabado_hora")
        Dim p_sabado_dias As New parametro("sucursal_fuera_hora_sabado_dias")

        If p_sucursal_permitir_pago_nafibo.valor = 1 Then
            rbl_sucursal_permitir_pago_nafibo.SelectedValue = "1"
        Else
            rbl_sucursal_permitir_pago_nafibo.SelectedValue = "0"
        End If
        tp_lun_vie.SelectedTime = parametro.ConvertDecimalToDateTime(p_lun_vie_hora.valor)
        txt_lun_vie.Text = p_lun_vie_dias.valor
        tp_sabado.SelectedTime = parametro.ConvertDecimalToDateTime(p_sabado_hora.valor)
        txt_sabado.Text = p_sabado_dias.valor
        
        MultiView1.ActiveViewIndex = 0
        rbl_sucursal_permitir_pago_nafibo.Enabled = False
        tp_lun_vie.Enabled = False
        txt_lun_vie.Enabled = False
        tp_sabado.Enabled = False
        txt_sabado.Enabled = False
    End Sub

    Protected Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        MultiView1.ActiveViewIndex = 1
        rbl_sucursal_permitir_pago_nafibo.Enabled = True
        tp_lun_vie.Enabled = True
        txt_lun_vie.Enabled = True
        tp_sabado.Enabled = True
        txt_sabado.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        CargarActualizar()
    End Sub
    
    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Dim p_sucursal_permitir_pago_nafibo As New parametro("sucursal_permitir_pago_nafibo")
        Dim p_lun_vie_hora As New parametro("sucursal_fuera_hora_lun_vie_hora")
        Dim p_lun_vie_dias As New parametro("sucursal_fuera_hora_lun_vie_dias")
        Dim p_sabado_hora As New parametro("sucursal_fuera_hora_sabado_hora")
        Dim p_sabado_dias As New parametro("sucursal_fuera_hora_sabado_dias")

        If rbl_sucursal_permitir_pago_nafibo.SelectedValue = "1" Then
            p_sucursal_permitir_pago_nafibo.valor = 1
        Else
            p_sucursal_permitir_pago_nafibo.valor = 0
        End If
        p_lun_vie_hora.valor = Convert.ToDecimal(parametro.ConvertDateTimeToDecimal(tp_lun_vie.SelectedTime))
        p_lun_vie_dias.valor = Decimal.Parse(txt_lun_vie.Text)
        p_sabado_hora.valor = Convert.ToDecimal(parametro.ConvertDateTimeToDecimal(tp_sabado.SelectedTime))
        p_sabado_dias.valor = Decimal.Parse(txt_sabado.Text)
        If p_sucursal_permitir_pago_nafibo.Actualizar(Profile.id_usuario) _
        And p_lun_vie_hora.Actualizar(Profile.id_usuario) _
        And p_lun_vie_dias.Actualizar(Profile.id_usuario) _
        And p_sabado_hora.Actualizar(Profile.id_usuario) _
        And p_sabado_dias.Actualizar(Profile.id_usuario) Then
            Msg4.Text = "Los datos del parámetro de pagos fuera de hora NAFIBO se actualizaron correctamente"
            CargarActualizar()
        Else
            Msg4.Text = "Los datos del parámetro de pagos fuera de hora NAFIBO NO se actualizaron correctamente"
        End If
    End Sub
</script>

<asp:Panel ID="panel_cartera" runat="server" GroupingText="Pagos de contratos NAFIBO en Sucursales">
    <table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formHorTdMsg" colspan="3">
                <asp:Msg ID="Msg4" runat="server"></asp:Msg>
            </td>
        </tr>
        <tr>
            <td class="formHorTdEnun1">Permitir pagos:</td>
            <td class="formHorTdDato" colspan="2">
                <asp:RadioButtonList ID="rbl_sucursal_permitir_pago_nafibo" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                    <asp:ListItem Text="No cobrar en Sucursales" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Cobrar en Sucursales" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr> 
            <td class="formHorTdEnun">Pagos fuera de hora:</td>
            <td class="formHorTdEnun"></td>
            <td class="formHorTdEnun"></td>
        </tr>
        <tr> 
            <td class="formHorTdEnun"></td>
            <td class="formHorTdEnun">Hora límite</td>
            <td class="formHorTdEnun">Nº días adicionales</td>
        </tr>
        <tr>
            <td class="formHorTdEnun1">Lunes - Viernes :</td>
            <td class="formHorTdDato"><ew:TimePicker id="tp_lun_vie" runat="server"></ew:TimePicker></td>
            <td class="formHorTdDato">
                <asp:TextBox ID="txt_lun_vie" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_lun_vie" runat="server" ControlToValidate="txt_lun_vie" Display="Dynamic" SetFocusOnError="true" ValidationGroup="pagNafibo" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rav_lun_vie" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_lun_vie"  Display="Dynamic" ValidationGroup="pagNafibo" SetFocusOnError="true" Text="*" ErrorMessage="El No. de días adicionales de Pago NAFIBO fuera de hora tiene valores inválidos"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="formHorTdEnun1">Sábado:</td>
            <td class="formHorTdDato"><ew:TimePicker id="tp_sabado" runat="server"></ew:TimePicker></td>
            <td class="formHorTdDato">
                <asp:TextBox ID="txt_sabado" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_sabado" runat="server" ControlToValidate="txt_sabado" Display="Dynamic" SetFocusOnError="true" ValidationGroup="pagNafibo" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_sabado" runat="server" Type="Integer" MinimumValue="0" MaximumValue="999999" ControlToValidate="txt_sabado"  Display="Dynamic" ValidationGroup="pagNafibo" SetFocusOnError="true" Text="*" ErrorMessage="El No. de días adicionales de Pago NAFIBO fuera de hora tiene valores inválidos"></asp:RangeValidator>
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
                        <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="pagNafibo"/>
                        <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion"/>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Panel>