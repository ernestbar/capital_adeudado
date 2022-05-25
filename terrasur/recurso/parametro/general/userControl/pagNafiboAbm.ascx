<%@ Control Language="VB" ClassName="pagNafiboAbm" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<script runat="server">
    
    Protected Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 1
        tp_lun_vie.Enabled = True
        txt_lun_vie.Enabled = True
        tp_sabado.Enabled = True
        txt_sabado.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
       CargarActualizar()
    End Sub
    
    Public Sub CargarActualizar()
        Dim p_lun_vie_hora As New parametro("fuera_hora_lun_vie_hora")
        Dim p_lun_vie_dias As New parametro("fuera_hora_lun_vie_dias")
        Dim p_sabado_hora As New parametro("fuera_hora_sabado_hora")
        Dim p_sabado_dias As New parametro("fuera_hora_sabado_dias")

        tp_lun_vie.SelectedTime = parametro.ConvertDecimalToDateTime(p_lun_vie_hora.valor)
        txt_lun_vie.Text = p_lun_vie_dias.valor
        tp_sabado.SelectedTime = parametro.ConvertDecimalToDateTime(p_sabado_hora.valor)
        txt_sabado.Text = p_sabado_dias.valor
        MultiView1.ActiveViewIndex = 0
        tp_lun_vie.Enabled = False
        txt_lun_vie.Enabled = False
        tp_sabado.Enabled = False
        txt_sabado.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            tp_lun_vie.Enabled = False
            txt_lun_vie.Enabled = False
            tp_sabado.Enabled = False
            txt_sabado.Enabled = False
            'btn_modificar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update") = True Or Profile.id_usuario = 513 Then
                btn_modificar.Visible = True
            Else
                btn_modificar.Visible = False
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p_lun_vie_hora As New parametro("fuera_hora_lun_vie_hora")
        Dim p_lun_vie_dias As New parametro("fuera_hora_lun_vie_dias")
        Dim p_sabado_hora As New parametro("fuera_hora_sabado_hora")
        Dim p_sabado_dias As New parametro("fuera_hora_sabado_dias")
        p_lun_vie_hora.valor = Convert.ToDecimal(parametro.ConvertDateTimeToDecimal(tp_lun_vie.SelectedTime))
        p_lun_vie_dias.valor = Decimal.Parse(txt_lun_vie.Text)
        p_sabado_hora.valor = Convert.ToDecimal(parametro.ConvertDateTimeToDecimal(tp_sabado.SelectedTime))
        p_sabado_dias.valor = Decimal.Parse(txt_sabado.Text)
        If p_lun_vie_hora.Actualizar(Profile.id_usuario) _
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

<asp:Panel ID="panel_cartera" runat="server" GroupingText="Pagos fuera de hora (NAFIBO)">
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdMsg" colspan="3">
            <asp:Msg ID="Msg4" runat="server"></asp:Msg>
           <%-- <asp:ValidationSummary ID="vs_factores" runat="server" DisplayMode="List" ValidationGroup="factores" />--%>
        </td>
    </tr>
    <tr>
        <td class="formHorTdTitle" colspan="3">
            <%--<asp:Label ID="lbl_title" runat="server" Text="Cartera"></asp:Label>--%>
        </td>
    </tr>
    <tr> 
        <td class="formHorTdEnun">
            
        </td>
        <td class="formHorTdEnun">
            <asp:Label ID="lbl_hora_enun" runat="server" Text="Hora límite"></asp:Label>
        </td>
        <td class="formHorTdEnun">
            <asp:Label ID="lbl_dias_enun" runat="server" Text="Nº días adicionales"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td class="formHorTdEnun1">
            <asp:Label ID="lbl_lun_vie_enun" runat="server" Text="Lunes - Viernes :"></asp:Label>
        </td>
        <td class="formHorTdDato">
            <ew:TimePicker id="tp_lun_vie" runat="server">
            </ew:TimePicker>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_lun_vie" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_lun_vie" runat="server" ControlToValidate="txt_lun_vie" Display="Dynamic" SetFocusOnError="true" ValidationGroup="pagNafibo" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_lun_vie" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999" ControlToValidate="txt_lun_vie"  Display="Dynamic" ValidationGroup="pagNafibo" SetFocusOnError="true" Text="*" ErrorMessage="El No. de días adicionales de Pago NAFIBO fuera de hora tiene valores inválidos"></asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td class="formHorTdEnun1">
            <asp:Label ID="lbl_sabado_enun" runat="server" Text="Sábado:"></asp:Label>
        </td>
        <td class="formHorTdDato">
            <ew:TimePicker id="tp_sabado" runat="server">
            </ew:TimePicker>
        </td>
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
                    <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CausesValidation="false" SkinID="btnAccion" OnClick="btn_modificar_Click" />
                </td>
            </tr>
        </table>
</asp:View>
    <asp:View ID="View2" runat="server">
        
            <table class="formEntTable">
                <tr>
                    <td class="formEntTdButtonParam">
                        <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>"
                            TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true"
                            ValidationGroup="pagNafibo" OnClick="btn_actualizar_Click" />
                        <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>"
                            CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                    </td>
                </tr>
            </table>
    
    </asp:View>
</asp:MultiView>&nbsp;
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Panel>