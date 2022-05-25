<%@ Control Language="VB" ClassName="preasigAbm" %>

<script runat="server">
    'Private Property nombre() As String
    '    Get
    '        Return lbl_nombre.Text
    '    End Get
    '    Set(ByVal value As String)
    '        lbl_nombre.Text = value
    '    End Set
    'End Property
    
    Protected Sub btn_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 1
        txt_valor.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarActualizar()
    End Sub
    
    Public Sub CargarActualizar()
        Dim paramObj As New parametro(lbl_nombre.Text)
        txt_valor.Text = paramObj.valor.ToString
        txt_valor.Focus()
        MultiView1.ActiveViewIndex = 0
        txt_valor.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            txt_valor.Enabled = False
            btn_mod.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim paramObj As New parametro(lbl_nombre.Text)
        paramObj.valor = Decimal.Parse(txt_valor.Text)
        If paramObj.Actualizar(Profile.id_usuario) Then
            Msg1.Text = "Los datos del parámetro de preasignación se actualizaron correctamente"
            CargarActualizar()
        Else
            Msg1.Text = "Los datos del parámetro de preasignación NO se actualizaron correctamente"
        End If
    End Sub
</script>

<asp:Label ID="lbl_nombre" runat="server" Text="plazo_preasignacion" Visible="false"></asp:Label>
<asp:ValidationSummary ID="vs_preasig" runat="server" DisplayMode="List" ValidationGroup="preasig" />
<asp:Panel ID="panel_preasignacion" runat="server" GroupingText="Preasignación">
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <%--<asp:Label ID="lbl_title" runat="server" Text="Preasignación"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_preasig_enun" runat="server" Text="Plazo de preasignación (Horas):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_valor" Display="Dynamic" SetFocusOnError="true" ValidationGroup="preasig" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_nombre" runat="server" Type="Integer" MinimumValue="0" MaximumValue="9999" ControlToValidate="txt_valor"  Display="Dynamic" ValidationGroup="preasig" SetFocusOnError="true" Text="*" ErrorMessage="El valor del plazo contiene caracteres inválidos"></asp:RangeValidator>
            
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