<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Información Gerencial" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Import Namespace="System.Collections.Generic" %>
<script runat="server">
    Protected Sub btn_semanal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_semanal.Click
        Dim Fecha As DateTime = cp_semanal.SelectedDate
        Dim Fecha_inicio_semana As DateTime
        Dim Fecha_inicio_anio As DateTime
        infoGerencialTerrasur.FechasInfoSemanal(Fecha, Fecha_inicio_semana, Fecha_inicio_anio)

        Dim Lista As List(Of tmpInfoGerencialTerrasur) = tmpInfoGerencialTerrasur.ListaPredefinida

        Dim Res As String = infoGerencialTerrasur.EnviarInfo(Fecha_inicio_semana, Fecha_inicio_semana, Fecha, Lista)
        Dim listaRes As String() = Res.Split("|")
        For i As Integer = 0 To listaRes.Length - 1
            Msg1.Text = listaRes(i)
        Next
    End Sub

    Protected Sub btn_manual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_manual.Click
        Dim Fecha_inicio As DateTime = cp_manual_inicio.SelectedDate
        Dim Fecha_fin As DateTime = cp_manual_fin.SelectedDate
        
        Dim Lista As New List(Of tmpInfoGerencialTerrasur)
        If rbl_manual_destino.SelectedValue = "digitar" Then
            If cb_repIngresos.Checked = True Or cb_repVentas.Checked = True Or cb_repReversiones.Checked = True Or cb_repMora.Checked = True Or cb_repCxc.Checked = True Then
                Lista.Add(New tmpInfoGerencialTerrasur(txt_manual_email.Text.Trim, cb_repIngresos.Checked, cb_repVentas.Checked, cb_repReversiones.Checked, cb_repMora.Checked, cb_repCxc.Checked))
                If rbl_manual_accion.SelectedValue = "ver" Then
                    Literal1.Text = infoGerencialTerrasur.VerInfo(Fecha_inicio, Fecha_inicio, Fecha_fin, Lista)
                Else
                    If txt_manual_email.Text.Trim <> "" Then
                        Dim Res As String = infoGerencialTerrasur.EnviarInfo(Fecha_inicio, Fecha_inicio, Fecha_fin, Lista)
                        Dim listaRes As String() = Res.Split("|")
                        For i As Integer = 0 To listaRes.Length - 1
                            Msg1.Text = listaRes(i)
                        Next
                    Else
                        Msg1.Text = "Debe introducir la dirección email a la que se enviará la información"
                    End If
                End If
            Else
                Msg1.Text = "Debe elegir los reportes que desea"
            End If
            
        Else
            For Each fila As GridViewRow In gv_personas.Rows
                Dim email As String = fila.Cells(1).Text
                Dim repIngresos As Boolean = CType(fila.Cells(2).FindControl("cb_repIngresos"), CheckBox).Checked
                Dim repVentas As Boolean = CType(fila.Cells(3).FindControl("cb_repVentas"), CheckBox).Checked
                Dim repReversiones As Boolean = CType(fila.Cells(4).FindControl("cb_repReversiones"), CheckBox).Checked
                Dim repMora As Boolean = CType(fila.Cells(5).FindControl("cb_repMora"), CheckBox).Checked
                Dim repCxc As Boolean = CType(fila.Cells(6).FindControl("cb_repCxc"), CheckBox).Checked
                If repIngresos = True Or repVentas = True Or repReversiones = True Or repMora = True Or repCxc = True Then
                    Lista.Add(New tmpInfoGerencialTerrasur(email, repIngresos, repVentas, repReversiones, repMora, repCxc))
                End If
            Next

            Dim Res As String = infoGerencialTerrasur.EnviarInfo(Fecha_inicio, Fecha_inicio, Fecha_fin, Lista)
            Dim listaRes As String() = Res.Split("|")
            For i As Integer = 0 To listaRes.Length - 1
                Msg1.Text = listaRes(i)
            Next
        End If
        
    End Sub

    Protected Sub rbl_manual_destino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_manual_destino.SelectedIndexChanged
        If rbl_manual_destino.SelectedValue = "digitar" Then
            MultiView1.ActiveViewIndex = 0
            rbl_manual_accion.SelectedValue = "ver"
            rbl_manual_accion.Enabled = True
        Else
            MultiView1.ActiveViewIndex = 1
            gv_personas.DataBind()
            rbl_manual_accion.SelectedValue = "email"
            rbl_manual_accion.Enabled = False
        End If
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="infoGerencial" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Información Gerencial</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_semanal" runat="server" GroupingText="Envío semanal de información">
                                        <table cellpadding="0" cellspacing="0" align="center">
                                            <tr>
                                                <td><asp:Label ID="lbl_semanal" runat="server" Text="A la fecha:" SkinID="lblEnun"></asp:Label></td>
                                                <td><ew:CalendarPopup ID="cp_semanal" runat="server"></ew:CalendarPopup></td>
                                                <td><asp:Button ID="btn_semanal" runat="server" Text="Enviar" OnClientClick="return confirm(¿Esta seguro que desea enviar la información?);" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_manual" runat="server" GroupingText="Envío manual de información">
                                        <table class="formTable" cellpadding="0" cellspacing="0" align="center">
                                            <tr>
                                                <td class="formTdEnun">Periodo:</td>
                                                <td class="formTdDato">
                                                    <ew:CalendarPopup ID="cp_manual_inicio" runat="server"></ew:CalendarPopup>
                                                    -
                                                    <ew:CalendarPopup ID="cp_manual_fin" runat="server"></ew:CalendarPopup>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formTdEnun">Destinatario:</td>
                                                <td class="formTdDato">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbl_manual_destino" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Digitar destinatario" Value="digitar" Selected="True" />
                                                                    <asp:ListItem Text="Elegir de una lista" Value="elegir" />
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                                                    <asp:View ID="View" runat="server">
                                                                        <table cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td><asp:Label ID="lbl_manual_email_enun" runat="server" Text="Email:" SkinID="lblEnun"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_manual_email" runat="server" SkinID="txtSingleLine200"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfv_manual_email" runat="server" ControlToValidate="txt_manual_email" Display="Dynamic" Text="*" ErrorMessage="Debe introducir una dirección email" ValidationGroup="manual" ></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="rev_manual_email" runat="server" ControlToValidate="txt_manual_email" Display="Dynamic" Text="*" ErrorMessage="Debe introducir una dirección email válida" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="manual"></asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td><asp:Label ID="lbl_manual_reportes_enun" runat="server" Text="Reportes:" SkinID="lblEnun"></asp:Label></td>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td><asp:CheckBox ID="cb_repIngresos" runat="server" Text="Rep.Ingresos" /></td>
                                                                                            <td><asp:CheckBox ID="cb_repVentas" runat="server" Text="Rep.Ventas" /></td>
                                                                                            <td><asp:CheckBox ID="cb_repReversiones" runat="server" Text="Rep.Reversiones" /></td>
                                                                                            <td><asp:CheckBox ID="cb_repMora" runat="server" Text="Rep.Mora" /></td>
                                                                                            <td><asp:CheckBox ID="cb_repCxc" runat="server" Text="Rep.Cxc" /></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:View>
                                                                    <asp:View ID="View1" runat="server">
                                                                        <asp:GridView ID="gv_personas" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_personas" DataKeyNames="id_persona">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Persona" DataField="nombre" />
                                                                                <asp:BoundField HeaderText="Email" DataField="email" />
                                                                                <asp:TemplateField><ItemTemplate><asp:CheckBox ID="cb_repIngresos" runat="server" Text="Rep.Ingresos" Checked='<%# Eval("repIngresos") %>' /></ItemTemplate></asp:TemplateField>
                                                                                <asp:TemplateField><ItemTemplate><asp:CheckBox ID="cb_repVentas" runat="server" Text="Rep.Ventas" Checked='<%# Eval("repVentas") %>' /></ItemTemplate></asp:TemplateField>
                                                                                <asp:TemplateField><ItemTemplate><asp:CheckBox ID="cb_repReversiones" runat="server" Text="Rep.Reversiones" Checked='<%# Eval("repReversiones") %>' /></ItemTemplate></asp:TemplateField>
                                                                                <asp:TemplateField><ItemTemplate><asp:CheckBox ID="cb_repMora" runat="server" Text="Rep.Mora" Checked='<%# Eval("repMora") %>' /></ItemTemplate></asp:TemplateField>
                                                                                <asp:TemplateField><ItemTemplate><asp:CheckBox ID="cb_repCxc" runat="server" Text="Rep.Cxc" Checked='<%# Eval("repCxc") %>' /></ItemTemplate></asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        <%--[id_persona],[activo],[nombre],[email],[repIngresos],[repVentas],[repReversiones],[repMora]--%>
                                                                        <asp:ObjectDataSource ID="ods_lista_personas" runat="server" TypeName="terrasur.infoGerencialTerrasur" SelectMethod="Lista">
                                                                        </asp:ObjectDataSource>
                                                                    </asp:View>
                                                                </asp:MultiView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formTdEnun">Acción:</td>
                                                <td class="formTdDato">
                                                    <asp:RadioButtonList ID="rbl_manual_accion" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Mostrar en pantalla" Value="ver" Selected="True" />
                                                        <asp:ListItem Text="Enviar email" Value="email" />
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="btn_manual" runat="server" Text="Realizar acción" OnClientClick="return confirm(¿Está seguro que desea realizar esta acción?);" CausesValidation="true" ValidationGroup="manual"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>


