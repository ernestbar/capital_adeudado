<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Dosificación de recibos" %>
<%@ Register Src="~/recurso/cobranza/dosificacion/userControl/dosificacionAbm.ascx" TagName="dosificacionAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "insert")
                btn_buscar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "buscar")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_dosificacion_abm.Text = "Nueva dosificacion"
        dosificacionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If dosificacionAbm1.VerificarInsertar Then
            If dosificacionAbm1.Insertar Then
                gv_dosificacion.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If dosificacionAbm1.VerificarActualizar Then
            If dosificacionAbm1.Actualizar Then
                gv_dosificacion.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_dosificacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_dosificacion.DataBound
        gv_dosificacion.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "update")
        gv_dosificacion.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "delete")
    End Sub

    Protected Sub gv_dosificacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_dosificacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "dosificaciones_posteriores").ToString).Equals(0) = True Then
                If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "numero_ultimo_recibo_utilizado").ToString).Equals(0) = True Then
                    CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = True
                Else
                    CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
                End If
            Else
                CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub gv_dosificacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_dosificacion.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_dosificacion_abm.Text = "Edición de datos de una dosificacion"
                dosificacionAbm1.CargarActualizar(Integer.Parse(gv_dosificacion.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim dosificacionObj As New dosificacion(Integer.Parse(e.CommandArgument.ToString))
                If dosificacionObj.Eliminar() Then
                    gv_dosificacion.DataBind()
                    Msg1.Text = "La dosificacion se eliminó correctamente"
                Else
                    Msg1.Text = "La dosificacion NO se eliminó correctamente"
                End If
        End Select
    End Sub


    Protected Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/dosificacion/busquedaRecibo.aspx")
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="dosificacion" MostrarLink="true"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Dosificación de recibos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nueva dosificación" />
                                    <asp:Button ID="btn_buscar" runat="server" Text="Buscar recibo" OnClick="btn_buscar_Click" />
                                </td>
                            </tr>
                           <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_dosificacion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_dosificacion_lista" DataKeyNames="id_dosificacion">
                                        <Columns>
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_dosificacion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la dosificación?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Del" DataField="desde" />
                                            <asp:BoundField HeaderText="Al" DataField="hasta" />
                                            <asp:BoundField HeaderText="Negocio" DataField="negocio" />
                                            <asp:BoundField HeaderText="Cobrador" DataField="nombre_cobrador" />
                                            <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />                    
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_dosificacion],[id_usuario],[codigo],[nombre],[valor]--%>
                                    <asp:ObjectDataSource ID="ods_dosificacion_lista" runat="server" TypeName="terrasur.dosificacion" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_dosificacion_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:dosificacionAbm ID="DosificacionAbm1" runat="server" />
                            
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="dosificacion" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="dosificacion" />
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

