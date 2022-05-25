<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Estados especiales de contratos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/contrato/contratoEstadoEspecial/userControl/estadoEspecialAbm.ascx" TagName="estadoEspecialAbm" TagPrefix="uc2" %>

<script runat="server">
    Protected Property permiso_insert() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_insert.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_insert.Text = value
        End Set
    End Property
    Protected Property permiso_update() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_update.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_update.Text = value
        End Set
    End Property
    Protected Property permiso_delete() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_delete.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_delete.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "view") Then
                permiso_insert = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "insert")
                permiso_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "update")
                permiso_delete = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "delete")
                btn_auditoria.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEstadoEspecial", "reporteAudit")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub ddl_estadoespecial_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_estadoespecial.DataBound
        If ddl_estadoespecial.Items.Count > 0 Then
            panel_abm.Visible = permiso_insert
        Else
            panel_abm.Visible = False
        End If
        ddl_estadoespecial.Items.Add(New ListItem("Todos", "0"))
        EstadoEspecialAbm1.id_estadoespecial = Integer.Parse(ddl_estadoespecial.SelectedValue)
    End Sub
    Protected Sub ddl_estadoespecial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_estadoespecial.SelectedIndexChanged
        If Integer.Parse(ddl_estadoespecial.SelectedValue) > 0 Then
            If permiso_insert = True Then
                EstadoEspecialAbm1.id_estadoespecial = Integer.Parse(ddl_estadoespecial.SelectedValue)
                panel_abm.Visible = True
            Else
                panel_abm.Visible = False
            End If
        Else
            panel_abm.Visible = False
        End If
    End Sub
    
    
    Protected Sub gv_contrato_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_contrato.DataBound
        'gv_contrato.Columns(0).Visible = Integer.Parse(ddl_estadoespecial.SelectedValue).Equals(0)
        gv_contrato.Columns(1).Visible = permiso_delete
        gv_contrato.Columns(gv_contrato.Columns.Count - 2).Visible = permiso_update
    End Sub
    Protected Sub gv_contrato_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_contrato.RowCommand
        If e.CommandName = "eliminar" Then
            Dim id_contrato As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(0))
            Dim id_estadoespecial As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(1))
            If contrato_estado_especial.Eliminar(id_contrato, id_estadoespecial, Profile.id_usuario) Then
                Msg1.Text = "El estado del contrato se retiró correctamente"
                gv_contrato.DataBind()
            Else
                Msg1.Text = "El estado del contrato NO se retiró correctamente"
            End If
        ElseIf e.CommandName = "modificar" Then
            Dim id_contrato As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(0))
            Dim id_estadoespecial As Integer = Integer.Parse(e.CommandArgument.ToString.Split(",")(1))
            If contrato_estado_especial.Modificar(id_contrato, id_estadoespecial, Profile.id_usuario) Then
                gv_contrato.DataBind()
            End If
        End If
    End Sub
    
    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If EstadoEspecialAbm1.Insertar Then
            gv_contrato.DataBind()
        End If
    End Sub

    Protected Sub btn_auditoria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_auditoria.Click
        WinPopUp1.Show()
    End Sub

    Protected Function StringActivar(ByVal activo As String) As String
        If activo.ToLower = "activo" Then
            Return "Desactivar"
        Else
            Return "Activar"
        End If
    End Function

    Protected Sub gv_contrato_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_contrato.RowDataBound
        general.OnMouseOver(sender, e)
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="contratoEstadoEspecial" MostrarLink="true"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_permiso_insert" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_update" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_delete" runat="server" Text="False" Visible="false"></asp:Label>
<asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/contratoEstadoEspecial/reporteAuditoria.aspx"></asp:WinPopUp>
<table class="priTable">
    <tr><td class="priTdTitle">Estados especiales de contratos</td></tr>
    <tr><td align="right"><asp:Button ID="btn_auditoria" runat="server" Text="Reporte de auditoría"/></td></tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td class="tdDropDown">
                        <table width="100%">
                            <tr>
                                <td align="left">
                                    <table class="tableDDL" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="tdDDLEnun">Estado especial:</td>
                                            <td class="tdDDLEspacio">
                                                <asp:DropDownList ID="ddl_estadoespecial" runat="server" AutoPostBack="true" DataSourceID="ods_estadoespecial_lista" DataTextField="nombre" DataValueField="id_estadoespecial"></asp:DropDownList>
                                                <%--[id_estadoespecial],[codigo],[nombre]--%>
                                                <asp:ObjectDataSource ID="ods_estadoespecial_lista" runat="server" TypeName="terrasur.estado_especial" SelectMethod="Lista"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="right" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <%--<td valign="top"></td>--%>
                                <td valign="top">
                                    <asp:Panel ID="panel_abm" runat="server" GroupingText="Asignar estado especial al contrato" DefaultButton="btn_insertar">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td><uc2:estadoEspecialAbm ID="EstadoEspecialAbm1" runat="server" /></td>
                                                <td valign="bottom"><asp:Button ID="btn_insertar" runat="server" Text="Agregar" CausesValidation="true" ValidationGroup="contrato"/></td>
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
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="False" DataSourceID="ods_lista_contratos" DataKeyNames="id_contrato,id_estadoespecial">
                            <Columns>
                                <asp:BoundField HeaderText="Estado especial" DataField="estado_especial" />
                                <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# String.Format("{0},{1}",Eval("id_contrato"),Eval("id_estadoespecial")) %>' OnClientClick="return confirm('¿Esta seguro?');" /></ItemTemplate></asp:TemplateField>
                                <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField HeaderText="Estado" DataField="estado" />
                                <asp:BoundField HeaderText="Negocio" DataField="negocio" />
                                <asp:BoundField HeaderText="Activo" DataField="activo" />
                                <asp:TemplateField><ItemTemplate><asp:LinkButton ID="lb_activo" runat="server" Text='<%# StringActivar(Eval("activo").ToString()) %>' CommandName="modificar" CommandArgument='<%# String.Format("{0},{1}",Eval("id_contrato"),Eval("id_estadoespecial")) %>'></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                <asp:BoundField HeaderText="Observación" DataField="observacion" />
                            </Columns>
                        </asp:GridView>
                        <%--[id_contrato],[id_estadoespecial],[estado_especial],[num_contrato],[estado],[negocio]--%>
                        <asp:ObjectDataSource ID="ods_lista_contratos" runat="server" TypeName="terrasur.contrato_estado_especial" SelectMethod="ListaPorEstado">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_estadoespecial" Type="Int32" ControlID="ddl_estadoespecial" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>

        </td>
    </tr>
    </table>
</asp:Content>

