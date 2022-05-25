<%@ Control Language="VB" ClassName="carteraAbm" %>

<script runat="server">
    
    
    Protected Sub btn_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 1
        txt_valor.Enabled = True
        txt_valor_2.Enabled = True
        txt_seguro.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
       CargarActualizar()
    End Sub
    
    Public Sub CargarActualizar()
        Dim paramObj As New parametro(lbl_nombre.Text)
        Dim paramObj_2 As New parametro(lbl_nombre_2.Text)
        Dim paramObj_seguro As New parametro("tasa_seguro")
        
        txt_valor.Text = paramObj.valor.ToString
        txt_valor_2.Text = paramObj_2.valor.ToString
        txt_seguro.Text = paramObj_seguro.valor.ToString
        txt_valor.Focus()
        MultiView1.ActiveViewIndex = 0
        txt_valor.Enabled = False
        txt_valor_2.Enabled = False
        txt_seguro.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            txt_valor.Enabled = False
            txt_valor_2.Enabled = False
            txt_seguro.Enabled = False
            btn_mod.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim paramObj As New parametro(lbl_nombre.Text)
        Dim paramObj_2 As New parametro(lbl_nombre_2.Text)
        Dim paramObj_seguro As New parametro("tasa_seguro")
        paramObj.valor = Decimal.Parse(txt_valor.Text)
        paramObj_2.valor = Decimal.Parse(txt_valor_2.Text)
        paramObj_seguro.valor = Decimal.Parse(txt_seguro.Text)
        If paramObj.Actualizar(Profile.id_usuario) And paramObj_2.Actualizar(Profile.id_usuario) And paramObj_seguro.Actualizar(Profile.id_usuario) Then
            Msg2.Text = "Los datos del parámetro de cartera se actualizaron correctamente"
            CargarActualizar()
        Else
            Msg2.Text = "Los datos del parámetro de cartera NO se actualizaron correctamente"
        End If
    End Sub
</script>

<asp:Label ID="lbl_nombre" runat="server" Text="tasa_mora" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_2" runat="server" Text="plazo_mora" Visible="false"></asp:Label>
<asp:Panel ID="panel_cartera" runat="server" GroupingText="Cartera">
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg2" runat="server"></asp:Msg>
            <%--<asp:ValidationSummary ID="vs_cartera" runat="server" DisplayMode="List" ValidationGroup="cartera" />--%>
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <%--<asp:Label ID="lbl_title" runat="server" Text="Cartera"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_tasa_mora_enun" runat="server" Text="Tasa mensual de mora (%):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor" runat="server" SkinID="txtSingleLine50" MaxLength="10" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor" runat="server" ControlToValidate="txt_valor" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cartera" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor" runat="server" Type="Double" MinimumValue="0" MaximumValue="100" ControlToValidate="txt_valor"  Display="Dynamic" ValidationGroup="cartera" SetFocusOnError="true" Text="*" ErrorMessage="El valor de tasa de mora contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_plazo_mora_enun" runat="server" Text="Plazo para la aplicación de mora (días):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor_2" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor_2" runat="server" ControlToValidate="txt_valor_2" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cartera" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor_2" runat="server" Type="Integer" MinimumValue="0" MaximumValue="9999" ControlToValidate="txt_valor_2"  Display="Dynamic" ValidationGroup="cartera" SetFocusOnError="true" Text="*" ErrorMessage="El valor del plazo de mora contiene caracteres inválidos"></asp:RangeValidator>
            
        </td>
    </tr>
        <tr>
            <td class="formTdEnunParam">
                <asp:Label ID="lbl_tasa_seguro" runat="server" Text="Seguro de Desgravamen (% mensual):"></asp:Label>
            </td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_seguro" runat="server" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_seguro" runat="server" ControlToValidate="txt_seguro" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cartera" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rav_seguro" runat="server" Type="Double" MinimumValue="0" MaximumValue="99" ControlToValidate="txt_seguro" Display="Dynamic" ValidationGroup="cartera" SetFocusOnError="true" Text="*" ErrorMessage="El valor del Seguro de Desgravamen contiene caracteres inválidos"></asp:RangeValidator>
            </td>
        </tr>
</table>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
<asp:View id="View1" runat="server">
   
        <table class="formEntTable">
            <tr>
                <td class="formEntTdButtonParam">
                    <asp:Button ID="btn_mod" runat="server" Text="Modificar"
                        CausesValidation="false" SkinID="btnAccion" OnClick="btn_mod_Click" />
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
                            ValidationGroup="preasig" OnClick="btn_actualizar_Click" />
                        <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>"
                            CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                    </td>
                </tr>
            </table>
    
    </asp:View>
</asp:MultiView>
</asp:Panel>