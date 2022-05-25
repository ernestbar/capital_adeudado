<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Recibos de Gastos (Caja)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/caja/reciboGastos/userControl/reciboGastosAbm.ascx" tagname="reciboGastosAbm" tagprefix="uc4" %>

<script runat="server">
    Protected Property id_recibo() As Integer
        Get
            Return Integer.Parse(lbl_id_recibo.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_recibo.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "view") Then
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "insert") = True And ConfigurationManager.AppSettings("num_sucursal") = "0" Then
                    btn_nuevo.Visible = True
                Else
                    btn_nuevo.Visible = False
                End If
                cp_fecha_inicio.SelectedDate = DateTime.Now.Date
                cp_fecha_fin.SelectedDate = DateTime.Now.Date
                gv_recibo.DataBind()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub gv_recibo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_recibo.DataBound
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "update") = True And ConfigurationManager.AppSettings("num_sucursal") = "0" Then
            gv_recibo.Columns(0).Visible = True
        Else
            gv_recibo.Columns(0).Visible = False
        End If
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboGastos", "delete") = True And ConfigurationManager.AppSettings("num_sucursal") = "0" Then
            gv_recibo.Columns(1).Visible = True
        Else
            gv_recibo.Columns(1).Visible = False
        End If
    End Sub

    Protected Sub gv_recibo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_recibo.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_recibo_abm.Text = "Edición de datos de un Recibo de Gastos"
                
                Dim id_recibogastos As Integer = Integer.Parse(gv_recibo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                reciboGastosAbm1.CargarActualizar(id_recibogastos)
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim id_recibogastos As Integer = Integer.Parse(e.CommandArgument.ToString)
                If (New recibo_gastos(id_recibogastos).Eliminar(Profile.id_usuario) = True) Then
                    Msg1.Text = "El recibo de gastos se eliminó correctamente"
                    gv_recibo.DataBind()
                Else
                    Msg1.Text = "El recibo de gastos NO se eliminó correctamente"
                End If
        End Select
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        panel_abm.DefaultButton = "btn_insertar"
        lbl_recibo_abm.Text = "Recibo de Gastos"
        reciboGastosAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If reciboGastosAbm1.Insertar Then
            gv_recibo.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If reciboGastosAbm1.Actualizar Then
            gv_recibo.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Function TextoCorto(ByVal texto As String) As String
        If texto.Length <= 40 Then
            Return texto
        Else
            Return texto.Substring(0, 40) & "..."
        End If
    End Function

    Protected Sub btn_mostrar_recibos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_recibos.Click
        gv_recibo.DataBind()
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reciboGastos" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_id_recibo" runat="server" Text="0" Visible="false"></asp:Label>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Recibos de Gastos (Caja)</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View1" runat="server">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo recibo de gastos" OnClick="btn_nuevo_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <table>
                                                            <tr>
                                                                <td><asp:Label ID="lbl_periodo" runat="server" Text="Recibos en el periodo:" SkinID="lblEnun"></asp:Label></td>
                                                                <td><ew:CalendarPopup ID="cp_fecha_inicio" runat="server"></ew:CalendarPopup></td>
                                                                <td>-</td>
                                                                <td><ew:CalendarPopup ID="cp_fecha_fin" runat="server"></ew:CalendarPopup></td>
                                                                <td><asp:Button ID="btn_mostrar_recibos" runat="server" Text="Mostrar" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gv_recibo" runat="server" AutoGenerateColumns="false" DataKeyNames="id_recibogastos" DataSourceID="ods_lista_recibo">
                                                            <Columns>
                                                                <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                                                <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_recibogastos") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el recibo de gastos?');" /></ItemTemplate></asp:TemplateField>
                                                                <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:d}" />
                                                                <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                                                                <asp:TemplateField HeaderText="Concepto"><ItemTemplate><asp:Label ID="lbl_concepto" runat="server" ToolTip='<%# Eval("concepto") %>' Text='<%# TextoCorto(Eval("concepto").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Entregado a"><ItemTemplate><asp:Label ID="lbl_entregado" runat="server" ToolTip='<%# Eval("entregado") %>' Text='<%# TextoCorto(Eval("entregado").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                                <asp:BoundField HeaderText="Monto($us)" DataField="monto_sus" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                <asp:BoundField HeaderText="Monto(Bs)" DataField="monto_bs" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                                <asp:BoundField HeaderText="TC" DataField="tipo_cambio" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--[id_recibogastos],[usuario],[fecha],[concepto],[entregado],[monto_sus],[monto_bs],[tipo_cambio]--%>
                                            <asp:ObjectDataSource ID="ods_lista_recibo" runat="server" TypeName="terrasur.recibo_gastos" SelectMethod="Lista">
                                                <SelectParameters>
                                                    <asp:ControlParameter Name="Fecha_inicio" Type="DateTime" ControlID="cp_fecha_inicio" PropertyName="SelectedDate" />
                                                    <asp:ControlParameter Name="Fecha_fin" Type="DateTime" ControlID="cp_fecha_fin" PropertyName="SelectedDate" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_abm" runat="server">
                                                <table class="formEntTable">
                                                    <tr><td class="formEntTdTitle"><asp:Label ID="lbl_recibo_abm" runat="server"></asp:Label></td></tr>
                                                    <tr><td class="formEntTdForm"><uc4:reciboGastosAbm ID="reciboGastosAbm1" runat="server" /></td></tr>
                                                    <tr>
                                                        <td class="formEntTdButton">
                                                            <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="recibo" OnClick="btn_insertar_Click" />
                                                            <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="recibo" OnClick="btn_actualizar_Click" />
                                                            <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

