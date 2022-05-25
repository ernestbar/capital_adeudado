<%@ Control Language="VB" ClassName="comDirecAbm" %>

<script runat="server">
    Protected Sub btn_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 1
        txt_valor.Enabled = True
        txt_valor_2.Enabled = True
        txt_valor_3.Enabled = True
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
       CargarActualizar()
    End Sub
    
    Public Sub CargarActualizar()
        Dim paramObj As New parametro(lbl_nombre.Text)
        Dim paramObj_2 As New parametro(lbl_nombre_2.Text)
        Dim paramObj_3 As New parametro(lbl_nombre_3.Text)
        txt_valor.Text = paramObj.valor.ToString
        txt_valor_2.Text = paramObj_2.valor.ToString
        txt_valor_3.Text = paramObj_3.valor.ToString
        txt_valor.Focus()
        MultiView1.ActiveViewIndex = 0
        txt_valor.Enabled = False
        txt_valor_2.Enabled = False
        txt_valor_3.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            txt_valor.Enabled = False
            txt_valor_2.Enabled = False
            txt_valor_3.Enabled = False
            btn_mod.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim paramObj As New parametro(lbl_nombre.Text)
        Dim paramObj_2 As New parametro(lbl_nombre_2.Text)
        Dim paramObj_3 As New parametro(lbl_nombre_3.Text)
        paramObj.valor = txt_valor.Text
        paramObj_2.valor = txt_valor_2.Text
        paramObj_3.valor = txt_valor_3.Text
        If paramObj.Actualizar(Profile.id_usuario) And paramObj_2.Actualizar(Profile.id_usuario) And paramObj_3.Actualizar(Profile.id_usuario) Then
            Msg6.Text = "Los datos del parámetro de comisiones a directores se actualizaron correctamente"
            CargarActualizar()
        Else
            Msg6.Text = "Los datos del parámetro de comisiones a directores NO se actualizaron correctamente"
        End If
    End Sub
</script>

<asp:Label ID="lbl_nombre" runat="server" Text="director_presupuesto" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_2" runat="server" Text="director_quincena" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_3" runat="server" Text="director_comision" Visible="false"></asp:Label>
<asp:Panel ID="panel_cartera" runat="server" GroupingText="Comisiones a Directores">
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg6" runat="server"></asp:Msg>
           <%-- <asp:ValidationSummary ID="vs_factores" runat="server" DisplayMode="List" ValidationGroup="factores" />--%>
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <%--<asp:Label ID="lbl_title" runat="server" Text="El porcentaje de comisión que recibe un promotor depende del monto de la cuota inicial con relación al valor total de la venta (porcentaje)"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_pmin_enun" runat="server" Text="Presupuesto mínimo de ventas del ciclo comercial:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor" runat="server" ControlToValidate="txt_valor" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comDir" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor" runat="server" Type="Double" MinimumValue="0" MaximumValue="999999" ControlToValidate="txt_valor"  Display="Dynamic" ValidationGroup="comDir" SetFocusOnError="true" Text="*" ErrorMessage="El valor del Presupuesto mínimo de ventas del ciclo comercial contiene caracteres inválidos"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_porquincena_enun" runat="server" Text="% presupuesto a cumplir en la primera quincena:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor_2" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_valor_2" runat="server" ControlToValidate="txt_valor_2" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comDir" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rav_valor_2" runat="server" Type="Integer" MinimumValue="0" MaximumValue="100" ControlToValidate="txt_valor_2"  Display="Dynamic" ValidationGroup="comDir" SetFocusOnError="true" Text="*" ErrorMessage="El valor del pocentaje presupuesto a cumplir en la primera quincena contiene caracteres inválidos"></asp:RangeValidator>
            
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_comDirec_enun" runat="server" Text="Comisión del director (sobre el volumen de ventas del ciclo comercial):"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_valor_3" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_valor_3" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comDir" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" MinimumValue="0" MaximumValue="100" ControlToValidate="txt_valor_3"  Display="Dynamic" ValidationGroup="comDir" SetFocusOnError="true" Text="*" ErrorMessage="El valor de la Comisión del director (sobre el volumen de ventas del ciclo comercial) contiene caracteres inválidos"></asp:RangeValidator>
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