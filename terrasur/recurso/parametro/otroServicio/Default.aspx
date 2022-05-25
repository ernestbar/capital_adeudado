<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Servicios" %>
<%@ Register Src="~/recurso/parametro/otroServicio/userControl/otroServicioAbm.ascx" TagName="otroServicioAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "otroServicio", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "otroServicio", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_servicio_abm.Text = "Nuevo servicio"
        OtroServicioAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If OtroServicioAbm1.VerificarInsertar Then
            If OtroServicioAbm1.Insertar Then
                gv_servicio.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If OtroServicioAbm1.VerificarActualizar Then
            If OtroServicioAbm1.Actualizar Then
                gv_servicio.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    
    Protected Sub gv_servicio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_servicio.DataBound
        gv_servicio.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "otroServicio", "view")
        gv_servicio.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "otroServicio", "update")
        gv_servicio.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "otroServicio", "delete")
    End Sub

    Protected Sub gv_servicio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_servicio.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_vendidos").ToString).Equals(0)
            If DataBinder.Eval(e.Row.DataItem, "codigo").ToString.ToUpper() = "ITR" or DataBinder.Eval(e.Row.DataItem, "codigo").ToString.ToUpper() = "DRE" or DataBinder.Eval(e.Row.DataItem, "codigo").ToString.ToUpper() = "IMP" Then
                CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = False 
            End If
        End If
    End Sub

    Protected Sub gv_servicio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_servicio.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_servicio") = Integer.Parse(gv_servicio.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_servicio_abm.Text = "Edición de datos de un servicio"
                OtroServicioAbm1.CargarActualizar(Integer.Parse(gv_servicio.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim servicioObj As New servicio(Integer.Parse(e.CommandArgument.ToString))
                If servicioObj.Eliminar(Profile.id_usuario) Then
                    gv_servicio.DataBind()
                    Msg1.Text = "El servicio se eliminó correctamente"
                Else
                    Msg1.Text = "El servicio NO se eliminó correctamente"
                End If
        End Select
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="otroServicio" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/parametro/otroServicio/servicioDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="priTable">
        <tr><td class="priTdTitle">Servicios</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo servicio" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_servicio" runat="server" AutoGenerateColumns="false" DataSourceID="ods_servicio_lista" DataKeyNames="id_servicio">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_servicio") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el servicio?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Código" DataField="codigo" />
                                            <asp:BoundField HeaderText="Servicio" DataField="nombre" />
                                            <asp:BoundField HeaderText="Valor" DataField="valor_sus" ItemStyle-CssClass="gvCell1" />
                                            <asp:CheckBoxField HeaderText="Facturar" DataField="facturar" Text="Facturar" /> 
                                            <asp:CheckBoxField HeaderText="Liquidación" DataField="liquidacion" Text="Liquidación" /> 
                                            <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />                    
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo],[num_pagos]--%>
                                    <asp:ObjectDataSource ID="ods_servicio_lista" runat="server" TypeName="terrasur.servicio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_servicio_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:otroServicioAbm ID="OtroServicioAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="servicio" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="servicio" />
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

