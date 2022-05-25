<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Motivos de Desactivación" %>
<%@ Register Src="~/recurso/parametro/motivoDesactivacion/userControl/motivoDesactivacionAbm.ascx" TagName="motivoDesactivacionAbm"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "motivoDesactivacion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "motivoDesactivacion", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_motivoDesactivacion_abm.Text = "Nuevo motivo de desactivación"
        MotivoDesactivacionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If MotivoDesactivacionAbm1.VerificarInsertar Then
            If MotivoDesactivacionAbm1.Insertar Then
                gv_motivoDesactivacion.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If MotivoDesactivacionAbm1.VerificarActualizar Then
            If MotivoDesactivacionAbm1.Actualizar Then
                gv_motivoDesactivacion.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_motivoReversion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_motivoDesactivacion.DataBound
        gv_motivoDesactivacion.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "motivoDesactivacion", "update")
        gv_motivoDesactivacion.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "motivoDesactivacion", "delete")
    End Sub

    Protected Sub gv_motivoReversion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_motivoDesactivacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_recibos").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_motivoReversion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_motivoDesactivacion.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_motivoDesactivacion_abm.Text = "Edición de datos de un motivo de desactivación"
                MotivoDesactivacionAbm1.CargarActualizar(Integer.Parse(gv_motivoDesactivacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim motivoDesactivacionObj As New motivo_desactivacion(Integer.Parse(e.CommandArgument.ToString))
                If motivoDesactivacionObj.Eliminar(Profile.id_usuario) Then
                    gv_motivoDesactivacion.DataBind()
                    Msg1.Text = "El motivo de desactivación se eliminó correctamente"
                Else
                    Msg1.Text = "El motivo de desactivación NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="motivoDesactivacion" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Motivos de Desactivación</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo motivo de desactivación" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_motivoDesactivacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_motivoDesactivacion_lista" DataKeyNames="id_motivodesactivacion">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_motivodesactivacion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el motivo de desactivación?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Motivo de desactivación" DataField="nombre" />
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_motivodesactivacion],[codigo],[nombre],[num_recibos]--%>
                                    <asp:ObjectDataSource ID="ods_motivoDesactivacion_lista" runat="server" TypeName="terrasur.motivo_desactivacion" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_motivoDesactivacion_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:motivoDesactivacionAbm ID="MotivoDesactivacionAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="motivoDesactivacion" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="motivoDesactivacion" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

