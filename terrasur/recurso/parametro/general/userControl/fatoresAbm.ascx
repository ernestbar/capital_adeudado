<%@ Control Language="VB" ClassName="fatoresAbm" %>

<script runat="server">
    
    Protected Sub btn_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 1
        txt_valor.Enabled = True
        txt_valor_2.Enabled = True
        txt_valor_3.Enabled = True
        txt_valor_4.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
       CargarActualizar()
    End Sub
    
    Public Sub CargarActualizar()
        Dim paramObj As New parametro(lbl_nombre.Text)
        Dim paramObj_2 As New parametro(lbl_nombre_2.Text)
        Dim paramObj_3 As New parametro(lbl_nombre_3.Text)
        Dim paramObj_4 As New parametro(lbl_nombre_4.Text)
        txt_valor.Text = paramObj.valor.ToString
        txt_valor_2.Text = paramObj_2.valor.ToString
        txt_valor_3.Text = paramObj_3.valor.ToString
        txt_valor_4.Text = paramObj_4.valor.ToString
        txt_valor.Focus()
        MultiView1.ActiveViewIndex = 0
        txt_valor.Enabled = False
        txt_valor_2.Enabled = False
        txt_valor_3.Enabled = False
        txt_valor_4.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            txt_valor.Enabled = False
            txt_valor_2.Enabled = False
            txt_valor_3.Enabled = False
            txt_valor_4.Enabled = False
            btn_mod.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim paramObj As New parametro(lbl_nombre.Text)
        Dim paramObj_2 As New parametro(lbl_nombre_2.Text)
        Dim paramObj_3 As New parametro(lbl_nombre_3.Text)
        Dim paramObj_4 As New parametro(lbl_nombre_4.Text)
        paramObj.valor = txt_valor.Text
        paramObj_2.valor = txt_valor_2.Text
        paramObj_3.valor = txt_valor_3.Text
        paramObj_4.valor = txt_valor_4.Text
        If paramObj.Actualizar(Profile.id_usuario) And paramObj_2.Actualizar(Profile.id_usuario) And paramObj_3.Actualizar(Profile.id_usuario) And paramObj_4.Actualizar(Profile.id_usuario) Then
            Msg4.Text = "Los datos del parámetro de factores se actualizaron correctamente"
            CargarActualizar()
        Else
            Msg4.Text = "Los datos del parámetro de factores NO se actualizaron correctamente"
        End If
    End Sub
</script>

<asp:Label ID="lbl_nombre" runat="server" Text="factor_nivel1" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_2" runat="server" Text="factor_nivel2" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_3" runat="server" Text="factor_ni_lote" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_4" runat="server" Text="factor_ni_servicio" Visible="false"></asp:Label>
<asp:Panel ID="panel_cartera" runat="server" GroupingText="Factores">
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg4" runat="server"></asp:Msg>
           <%-- <asp:ValidationSummary ID="vs_factores" runat="server" DisplayMode="List" ValidationGroup="factores" />--%>
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <%--<asp:Label ID="lbl_title" runat="server" Text="Cartera"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_fn1_enun" runat="server" Text="Factor de referencia 1er. Nivel:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor" runat="server" ControlToValidate="txt_valor" Display="Dynamic" SetFocusOnError="true" ValidationGroup="factores" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor" runat="server" Type="Double" MinimumValue="0" MaximumValue="9999" ControlToValidate="txt_valor"  Display="Dynamic" ValidationGroup="factores" SetFocusOnError="true" Text="*" ErrorMessage="El valor del factor de 1er. nivel contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_fn2_enun" runat="server" Text="Factor de referencia 2do. Nivel:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor_2" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor_2" runat="server" ControlToValidate="txt_valor_2" Display="Dynamic" SetFocusOnError="true" ValidationGroup="factores" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor_2" runat="server" Type="Double" MinimumValue="0" MaximumValue="9999" ControlToValidate="txt_valor_2"  Display="Dynamic" ValidationGroup="factores" SetFocusOnError="true" Text="*" ErrorMessage="El valor del factor de 2do. nivel contiene caracteres inválidos"></asp:RangeValidator>
            
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_ni_enun" runat="server" Text="Factor de incremento por NI para lotes (%):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor_3" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_valor_3" Display="Dynamic" SetFocusOnError="true" ValidationGroup="factores" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" MinimumValue="0" MaximumValue="100" ControlToValidate="txt_valor_3"  Display="Dynamic" ValidationGroup="factores" SetFocusOnError="true" Text="*" ErrorMessage="El valor del factor de incremento NI para lotes contiene caracteres inválidos"></asp:RangeValidator>
            
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_ni_serv_enun" runat="server" Text="Factor de incremento por NI para servicios funerarios (%):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor_4" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_valor_4" Display="Dynamic" SetFocusOnError="true" ValidationGroup="factores" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator2" runat="server" Type="Integer" MinimumValue="0" MaximumValue="100" ControlToValidate="txt_valor_4"  Display="Dynamic" ValidationGroup="factores" SetFocusOnError="true" Text="*" ErrorMessage="El valor del factor de incremento NI para serv. fun. contiene caracteres inválidos"></asp:RangeValidator>
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