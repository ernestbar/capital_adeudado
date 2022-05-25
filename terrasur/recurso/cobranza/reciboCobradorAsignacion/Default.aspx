<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Modificación en la asignación de recibos de cobrador a pagos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    Protected Property primera_consulta() As Boolean
        Get
            Return Boolean.Parse(lbl_primera_consulta.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_primera_consulta.Text = value
        End Set
    End Property
    Protected Property modificar_asignacion() As Boolean
        Get
            Return Boolean.Parse(lbl_modificar_asignacion.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_modificar_asignacion.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboCobradorAsignacion", "view") Then
                primera_consulta = True
                modificar_asignacion = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboCobradorAsignacion", "update")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_criterio_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_buscar.Click
        If txt_contrato.Text.Trim = "" And txt_fecha.SelectedValue.HasValue = False And txt_recibo.Text.Trim = "" Then
            msg_criterio.Text = "Debe introducir un criterio de búsqueda"
        Else
            primera_consulta = False
            gv0.DataBind()
        End If
    End Sub

    Protected Sub ods_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_lista.Selecting
        'Numero_contrato,Fecha,Numero_recibo
        If primera_consulta Then
            e.InputParameters("Numero_contrato") = "1"
            e.InputParameters("Fecha") = DateTime.Parse("01/01/1950")
            e.InputParameters("Numero_recibo") = 1
        Else
            e.InputParameters("Numero_contrato") = txt_contrato.Text.Trim
            If txt_fecha.SelectedValue.HasValue = True Then
                e.InputParameters("Fecha") = txt_fecha.SelectedValue.Value
            Else
                e.InputParameters("Fecha") = DateTime.Parse("01/01/1950")
            End If
            If txt_recibo.Text.Trim <> "" Then
                e.InputParameters("Numero_recibo") = Integer.Parse(txt_recibo.Text.Trim)
            Else
                e.InputParameters("Numero_recibo") = 0
            End If
        End If
    End Sub

    Protected Sub gv0_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv0.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "recibo_cobrador").ToString) = 0 Then
                CType(e.Row.FindControl("btn_delete"), ImageButton).Visible = False
            Else
                CType(e.Row.FindControl("btn_delete"), ImageButton).Visible = modificar_asignacion
            End If
            CType(e.Row.FindControl("btn_editar"), ImageButton).Visible = modificar_asignacion
            
            CType(e.Row.FindControl("btn_editar"), ImageButton).CommandArgument = e.Row.RowIndex
            CType(e.Row.FindControl("btn_actualizar"), LinkButton).CommandArgument = e.Row.RowIndex
            CType(e.Row.FindControl("btn_cancelar"), LinkButton).CommandArgument = e.Row.RowIndex

            'If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "recibo_cobrador").ToString) = 0 Then
            '    CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btn_delete"), ImageButton).Visible = False
            'Else
            '    CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btn_delete"), ImageButton).Visible = modificar_asignacion
            'End If
            'CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btn_editar"), ImageButton).Visible = modificar_asignacion

            'CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btn_editar"), ImageButton).CommandArgument = e.Row.RowIndex
            'CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btn_actualizar"), LinkButton).CommandArgument = e.Row.RowIndex
            'CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btn_cancelar"), LinkButton).CommandArgument = e.Row.RowIndex
        End If
    End Sub

    Protected Sub gv0_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv0.RowCommand
        Select Case e.CommandName
            Case "eliminar"
                Dim id_transaccion As Integer = Integer.Parse(e.CommandArgument.ToString)
                If recibo_cobrador.AsignacionModificar(id_transaccion, 0, Profile.id_usuario) Then
                    Msg1.Text = "La asignación del recibo al pago se modificó correctamente"
                    gv0.DataBind()
                Else
                    Msg1.Text = "La asignación del recibo al pago NO se modificó correctamente"
                End If
            Case "editar"
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("lbl_num_recibo"), Label).Visible = False
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("panel_num_recibo"), Panel).Visible = True

                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_delete"), ImageButton).Enabled = False
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_editar"), ImageButton).Visible = False
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_actualizar"), LinkButton).Visible = True
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_cancelar"), LinkButton).Visible = True

                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(5).FindControl("lbl_num_recibo"), Label).Visible = False
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(5).FindControl("panel_num_recibo"), Panel).Visible = True

                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_delete"), ImageButton).Enabled = False
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_editar"), ImageButton).Visible = False
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_actualizar"), LinkButton).Visible = True
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_cancelar"), LinkButton).Visible = True
            Case "actualizar"
                Dim id_transaccion As Integer = Integer.Parse(gv0.DataKeys(Integer.Parse(e.CommandArgument)).Value.ToString)
                Dim numero_recibo As Integer = Integer.Parse(CType(gv0.Rows(Integer.Parse(e.CommandArgument)).Cells(5).FindControl("txt_num_recibo"), TextBox).Text.Trim)
                Dim correcto As Boolean = True
                If numero_recibo > 0 Then
                    Dim reciboObj As New recibo_cobrador(0, numero_recibo)
                    If reciboObj.id_recibocobrador = 0 Then
                        correcto = False
                        Msg1.Text = "El recibo de cobrador no existe"
                    End If
                End If
                If correcto = True Then
                    If recibo_cobrador.AsignacionModificar(id_transaccion, numero_recibo, Profile.id_usuario) Then
                        Msg1.Text = "La asignación del recibo al pago se modificó correctamente"
                        gv0.DataBind()
                    Else
                        Msg1.Text = "La asignación del recibo al pago NO se modificó correctamente"
                    End If
                End If
            Case "cancelar"
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("lbl_num_recibo"), Label).Visible = True
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("panel_num_recibo"), Panel).Visible = False

                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_delete"), ImageButton).Enabled = True
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_editar"), ImageButton).Visible = True
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_actualizar"), LinkButton).Visible = False
                CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).FindControl("btn_cancelar"), LinkButton).Visible = False

                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(5).FindControl("lbl_num_recibo"), Label).Visible = True
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(5).FindControl("panel_num_recibo"), Panel).Visible = False

                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_delete"), ImageButton).Enabled = True
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_editar"), ImageButton).Visible = True
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_actualizar"), LinkButton).Visible = False
                'CType(gv0.Rows(Integer.Parse(e.CommandArgument.ToString)).Cells(6).FindControl("btn_cancelar"), LinkButton).Visible = False
        End Select
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reciboCobradorAsignacion" MostrarLink="true"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_primera_consulta" runat="server" Text="True" Visible="false"></asp:Label>
<asp:Label ID="lbl_modificar_asignacion" runat="server" Text="True" Visible="false"></asp:Label>
<table class="priTable">
    <tr><td class="priTdTitle">Modificación en la asignación de recibos de cobrador a pagos</td></tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td class="tdBusqueda">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de búsqueda" DefaultButton="btn_criterio_buscar">
                                        <table>
                                            <tr>
                                                <td class="tdMsg">
                                                    <asp:Msg ID="msg_criterio" runat="server"></asp:Msg>
                                                    <asp:ValidationSummary ID="vs_criterio" runat="server" DisplayMode="List" ValidationGroup="criterio" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formHorEntTdForm">
                                                    <table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="formHorTdEnun">Nº contrato</td>
                                                            <td class="formHorTdEnun">Fecha</td>
                                                            <td class="formHorTdEnun">Nº recibo</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formHorTdDato">
                                                                <asp:TextBox ID="txt_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="rev_contrato" runat="server" ControlToValidate="txt_contrato" Display="Dynamic" ValidationGroup="criterio" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*" ErrorMessage="El Nº de contrato contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                                            </td>
                                                            <td class="formHorTdDato">
                                                                <ew:CalendarPopup ID="txt_fecha" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                                                            </td>
                                                            <td class="formHorTdDato">
                                                                <asp:TextBox ID="txt_recibo" runat="server" SkinID="txtSingleLine100" MaxLength="8"></asp:TextBox>
                                                                <asp:RangeValidator ID="rv_recibo" runat="server" ControlToValidate="txt_recibo" ValidationGroup="criterio" Type="Integer" MinimumValue="0" MaximumValue="99999999" Display="dynamic" Text='*' ErrorMessage="Debe introducir un número entero positivo"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formHorEntTdButton">
                                                    <asp:Button ID="btn_criterio_buscar" runat="server" Text="Buscar" CausesValidation="true" SkinID="btnAccion" ValidationGroup="criterio" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               <tr>
                    <td class="tdMsg">
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        <asp:ValidationSummary ID="vs_recibo" runat="server" DisplayMode="List" ValidationGroup="recibo" />
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <asp:GridView ID="gv0" runat="server" AutoGenerateColumns="False" DataSourceID="ods_lista" DataKeyNames="id_transaccion">
                            <Columns>
                                <asp:BoundField HeaderText="N&#186; Contrato" DataField="contrato" ItemStyle-CssClass="gvCell1"/>
                                <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField HeaderText="Tipo de pago" DataField="tipo_pago"/>
                                <asp:BoundField HeaderText="Monto ($us)" DataField="monto_pago_sus" HtmlEncode="False" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1"/>
                                <asp:BoundField HeaderText="Monto (Bs)" DataField="monto_pago_bs" HtmlEncode="False" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1"/>
                                <asp:BoundField HeaderText="Cajero" DataField="nombre_usuario" />
                                <asp:BoundField HeaderText="Cobrador" DataField="cobrador" />
                                <asp:TemplateField HeaderText="N&#186; recibo" ItemStyle-CssClass="gvCell1">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_num_recibo" runat="server" Text='<%# Eval("recibo_cobrador") %>'></asp:Label>
                                        <asp:Panel ID="panel_num_recibo" runat="server" Visible="false">
                                            <asp:TextBox ID="txt_num_recibo" runat="server" MaxLength="7" SkinID="txtSingleLine50" Text='<%# Eval("recibo_cobrador") %>' ValidationGroup="recibo"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_num_recibo" runat="server" ControlToValidate="txt_num_recibo" ValidationGroup="recibo" Display="dynamic" Text='*' ErrorMessage="Debe introducir el número del recibo"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="rv_num_recibo" runat="server" ControlToValidate="txt_num_recibo" ValidationGroup="recibo" Type="Integer" MinimumValue="0" MaximumValue="9999999" Display="dynamic" Text='*' ErrorMessage="Debe introducir un número entero positivo"></asp:RangeValidator>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="2">
                                            <tr>
                                                <td><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_transaccion") %>' OnClientClick="return confirm('¿Esta seguro que desea quitar la asignación del recibo al pago?');" /></td>
                                                <td><asp:ImageButton ID="btn_editar" runat="server" CommandName="editar" ImageUrl="~/images/gv/edit.gif"/></td>
                                                <td><asp:LinkButton ID="btn_actualizar" runat="server" Visible="false" CommandName="actualizar" Text="Actualizar" CausesValidation="true" ValidationGroup="recibo"></asp:LinkButton></td>
                                                <td><asp:LinkButton ID="btn_cancelar" runat="server" Visible="false" CommandName="cancelar" Text="Cancelar" CausesValidation="false"></asp:LinkButton></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--[id_transaccion],[contrato],[tipo_pago],[fecha],[monto_pago_sus],[monto_pago_bs],[nombre_usuario],[cobrador],[recibo_cobrador]--%>
                        <asp:ObjectDataSource ID="ods_lista" runat="server" TypeName="terrasur.recibo_cobrador" SelectMethod="AsignacionLista">
                            <SelectParameters>
                                <asp:Parameter Name="Numero_contrato" Type="String" />
                                <asp:Parameter Name="Fecha" Type="DateTime" />
                                <asp:Parameter Name="Numero_recibo" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>

        </td>
    </tr>
    </table>
</asp:Content>

