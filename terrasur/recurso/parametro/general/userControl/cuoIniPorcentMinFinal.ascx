<%@ Control Language="VB" ClassName="cuoIniPorcentMinFinal" %>

<script runat="server">
    Protected Sub btn_mod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 1
        txt_cuoIni_terreno.Enabled = True
        txt_cuoIni_casa.Enabled = True
        txt_cuoIni_dpto.Enabled = True
        txt_cuoIni_mercado.Enabled = True
        txt_cuoIni_terreno.Focus()
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
       CargarActualizar()
    End Sub
    
    Public Sub CargarActualizar()
        Dim paramObj_terreno As New parametro("cuoIni_porcent_min_terreno")
        Dim paramObj_casa As New parametro("cuoIni_porcent_min_casa")
        Dim paramObj_dpto As New parametro("cuoIni_porcent_min_dpto")
        Dim paramObj_mercado As New parametro("cuoIni_porcent_min_mercado")
        
        txt_cuoIni_terreno.Text = paramObj_terreno.valor.ToString
        txt_cuoIni_casa.Text = paramObj_casa.valor.ToString
        txt_cuoIni_dpto.Text = paramObj_dpto.valor.ToString
        txt_cuoIni_mercado.Text = paramObj_mercado.valor.ToString
        
        
        MultiView1.ActiveViewIndex = 0
        txt_cuoIni_terreno.Enabled = False
        txt_cuoIni_casa.Enabled = False
        txt_cuoIni_dpto.Enabled = False
        txt_cuoIni_mercado.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            CargarActualizar()
            'txt_cuoIni_terreno.Enabled = False
            'txt_cuoIni_casa.Enabled = False
            'txt_cuoIni_dpto.Enabled = False
            'txt_cuoIni_mercado.Enabled = False
            btn_mod.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim paramObj_terreno As New parametro("cuoIni_porcent_min_terreno")
        Dim paramObj_casa As New parametro("cuoIni_porcent_min_casa")
        Dim paramObj_dpto As New parametro("cuoIni_porcent_min_dpto")
        Dim paramObj_mercado As New parametro("cuoIni_porcent_min_mercado")
        
        Dim num_cambios As Integer = 0
        Dim num_cambios_correctos As Integer = 0
        If paramObj_terreno.valor <> Decimal.Parse(txt_cuoIni_terreno.Text) Then
            num_cambios = num_cambios + 1
            paramObj_terreno.valor = Decimal.Parse(txt_cuoIni_terreno.Text)
            If paramObj_terreno.Actualizar(Profile.id_usuario) Then
                num_cambios_correctos = num_cambios_correctos + 1
                Msg5.Text = "El % de cuota inicial mínima de TERRENOS se actualizó correctamente"
            Else
                Msg5.Text = "El % de cuota inicial mínima de TERRENOS NO se actualizó correctamente"
            End If
        End If
        
        If paramObj_casa.valor <> Decimal.Parse(txt_cuoIni_casa.Text) Then
            num_cambios = num_cambios + 1
            paramObj_casa.valor = Decimal.Parse(txt_cuoIni_casa.Text)
            If paramObj_casa.Actualizar(Profile.id_usuario) Then
                num_cambios_correctos = num_cambios_correctos + 1
                Msg5.Text = "El % de cuota inicial mínima de CASAS se actualizó correctamente"
            Else
                Msg5.Text = "El % de cuota inicial mínima de CASAS NO se actualizó correctamente"
            End If
        End If
        
        If paramObj_dpto.valor <> Decimal.Parse(txt_cuoIni_dpto.Text) Then
            num_cambios = num_cambios + 1
            paramObj_dpto.valor = Decimal.Parse(txt_cuoIni_dpto.Text)
            If paramObj_dpto.Actualizar(Profile.id_usuario) Then
                num_cambios_correctos = num_cambios_correctos + 1
                Msg5.Text = "El % de cuota inicial mínima de DEPARTAMENTOS se actualizó correctamente"
            Else
                Msg5.Text = "El % de cuota inicial mínima de DEPARTAMENTOS NO se actualizó correctamente"
            End If
        End If
        
        If paramObj_mercado.valor <> Decimal.Parse(txt_cuoIni_mercado.Text) Then
            num_cambios = num_cambios + 1
            paramObj_mercado.valor = Decimal.Parse(txt_cuoIni_mercado.Text)
            If paramObj_mercado.Actualizar(Profile.id_usuario) Then
                num_cambios_correctos = num_cambios_correctos + 1
                Msg5.Text = "El % de cuota inicial mínima del MERCADO se actualizó correctamente"
            Else
                Msg5.Text = "El % de cuota inicial mínima del MERCADO NO se actualizó correctamente"
            End If
        End If

        If num_cambios > 0 Then
            If num_cambios_correctos = num_cambios Then
                CargarActualizar()
            End If
        Else
            Msg5.Text = "No realizó ningún cambio"
        End If
    End Sub
</script>

<asp:Label ID="lbl_nombre" runat="server" Text="comision_menor50" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_2" runat="server" Text="comision_menor100" Visible="false"></asp:Label>
<asp:Label ID="lbl_nombre_3" runat="server" Text="comision_igual100" Visible="false"></asp:Label>
<asp:Panel ID="panel_cartera" runat="server" GroupingText="Cuota Inicial Mínima">
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg5" runat="server"></asp:Msg>
            <%--<asp:ValidationSummary ID="vs_comIniMin" runat="server" DisplayMode="List" ValidationGroup="comIniMin" />--%>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left"><%--class="formTdTitle"--%>
            <asp:Label ID="lbl_title" runat="server" SkinID="lblEnun" Text="La cuota inicial de los contratos no puede ser inferior a los siguientes porcentajes (con respecto al precio final)"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_cuoIni_terreno" runat="server" Text="% Cuota inicial mínima (respecto al precio final) para TERRENOS:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cuoIni_terreno" runat="server" SkinID="txtSingleLine50" MaxLength="6" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_cuoIni_terreno" runat="server" ControlToValidate="txt_cuoIni_terreno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_cuoIni_terreno" runat="server" ControlToValidate="txt_cuoIni_terreno" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="El pocentaje no está en el rango permitido (de 0 a 100)" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_cuoIni_casa" runat="server" Text="% Cuota inicial mínima (respecto al precio final) para CASAS:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cuoIni_casa" runat="server" SkinID="txtSingleLine50" MaxLength="6" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_cuoIni_casa" runat="server" ControlToValidate="txt_cuoIni_casa" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_cuoIni_casa" runat="server" ControlToValidate="txt_cuoIni_casa" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="El pocentaje no está en el rango permitido (de 0 a 100)" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_cuoIni_dpto" runat="server" Text="% Cuota inicial mínima (respecto al precio final) para DEPARTAMENTOS:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cuoIni_dpto" runat="server" SkinID="txtSingleLine50" MaxLength="6" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_cuoIni_dpto" runat="server" ControlToValidate="txt_cuoIni_dpto" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_cuoIni_dpto" runat="server" ControlToValidate="txt_cuoIni_dpto" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="El pocentaje no está en el rango permitido (de 0 a 100)" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>   
        </td>
    </tr>
    <tr>
        <td class="formTdEnunParam">
            <asp:Label ID="lbl_cuoIni_mercado" runat="server" Text="% Cuota inicial mínima (respecto al precio final) para el MERCADO:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_cuoIni_mercado" runat="server" SkinID="txtSingleLine50" MaxLength="6" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_cuoIni_mercado" runat="server" ControlToValidate="txt_cuoIni_mercado" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_cuoIni_mercado" runat="server" ControlToValidate="txt_cuoIni_mercado" Display="Dynamic" SetFocusOnError="true" ValidationGroup="comIniMin" Text="*" ErrorMessage="El pocentaje no está en el rango permitido (de 0 a 100)" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>   
        </td>
    </tr>

</table>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View id="View1" runat="server">
        <table class="formEntTable">
            <tr>
                <td class="formEntTdButtonParam">
                    <asp:Button ID="btn_mod" runat="server" Text="Modificar" CausesValidation="false" SkinID="btnAccion" OnClick="btn_mod_Click" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="formEntTable">
            <tr>
                <td class="formEntTdButtonParam">
                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="comIniMin" OnClick="btn_actualizar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
</asp:Panel>