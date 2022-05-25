<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Tarjetas de crédito" %>
<%@ Register Src="~/recurso/contabilidad/debitoatc/userControl/tarjetaCreditoCriterio.ascx" TagName="tarjetaCreditoCriterio" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/contabilidad/debitoatc/userControl/tarjetaCreditoAbm.ascx" TagName="tarjetaCreditoAbm" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCredito", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCredito", "insert")
                btn_grupo_transaccion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "view")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_tarjeta_abm.Text = "Nueva tarjeta de crédito"
        TarjetaCreditoAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        panel_criterio.Visible = True
        TarjetaCreditoCriterio1.Reset()
    End Sub
    Protected Sub btn_criterio_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_buscar.Click
        If TarjetaCreditoCriterio1.TieneCriterio Then
            gv_tarjeta.DataBind()
        Else
            msg_criterio.Text = "Debe introducir un criterio de busqueda"
        End If
    End Sub
    Protected Sub btn_criterio_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_cancelar.Click
        panel_criterio.Visible = False
        TarjetaCreditoCriterio1.Reset()
        gv_tarjeta.DataBind()
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If TarjetaCreditoAbm1.Insertar Then
            gv_tarjeta.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If TarjetaCreditoAbm1.Actualizar Then
            gv_tarjeta.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub gv_tarjeta_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_tarjeta.DataBound
        gv_tarjeta.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCredito", "update")
        gv_tarjeta.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCredito", "delete")
        gv_tarjeta.Columns(3).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCreditoContrato", "view")
    End Sub

    Protected Sub gv_tarjeta_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_tarjeta.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_contratos")) > 0 Then
                CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub gv_tarjeta_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_tarjeta.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_tarjetacredito") = Integer.Parse(gv_tarjeta.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_tarjeta_abm.Text = "Edición de datos de una tarjeta de crédito"
                TarjetaCreditoAbm1.CargarActualizar(Integer.Parse(gv_tarjeta.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim tarjetaObj As New tarjeta_credito(Integer.Parse(e.CommandArgument.ToString))
                If tarjetaObj.num_contratos_asignados = 0 Then
                    If tarjetaObj.Eliminar(Profile.id_usuario) Then
                        gv_tarjeta.DataBind()
                        Msg1.Text = "La tarjeta de crédito se eliminó correctamente"
                    Else
                        Msg1.Text = "La tarjeta de crédito NO se eliminó correctamente"
                    End If
                Else
                    Msg1.Text = "La tarjeta de crédito NO se eliminó correctamente"
                End If
            Case "contratos"
                Session("id_tarjetacredito") = Integer.Parse(gv_tarjeta.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Response.Redirect("~/recurso/contabilidad/debitoatc/tarjetaCreditoContrato.aspx")
        End Select
    End Sub

    Protected Function Lista_contratos_por_tarjeta(ByVal Id_tarjetacredito As String) As String
        Return tarjeta_credito_contrato.ListaContratosSimple_string(Integer.Parse(Id_tarjetacredito))
    End Function
    
    Protected Sub ods_tarjeta_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_tarjeta_lista.Selecting
        'Lista(int Id_tipotarjetacredito, int Id_banco, string Num_tarjeta, string Titular, string Ci, string Num_contrato, int Tarjeta_activa )
        e.InputParameters("Id_tipotarjetacredito") = TarjetaCreditoCriterio1.id_tipotarjetacredito
        e.InputParameters("Id_banco") = TarjetaCreditoCriterio1.id_banco
        e.InputParameters("Num_tarjeta") = TarjetaCreditoCriterio1.num_tarjeta
        e.InputParameters("Titular") = TarjetaCreditoCriterio1.titular
        e.InputParameters("Ci") = TarjetaCreditoCriterio1.ci
        e.InputParameters("Num_contrato") = TarjetaCreditoCriterio1.num_contrato
        e.InputParameters("Tarjeta_activa") = TarjetaCreditoCriterio1.activo
    End Sub

    Protected Sub btn_grupo_transaccion_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/debitoatc/grupoTransaccion.aspx")
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="tarjetaCredito"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contabilidad/debitoatc/tarjetaCreditoDetalle.aspx" ></asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Tarjetas de crédito</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="btn_nuevo" runat="server" Text="Nueva tarjeta" />
                                                <asp:Button ID="btn_busqueda" runat="server" Text="Busqueda de tarjetas" />
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btn_grupo_transaccion" runat="server" Text="Debito automático" OnClick="btn_grupo_transaccion_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdBusqueda">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de búsqueda" DefaultButton="btn_criterio_buscar" Visible="false">
                                                    <table>
                                                        <tr><td class="tdMsg"><asp:Msg ID="msg_criterio" runat="server"></asp:Msg></td></tr>
                                                        <tr><td class="formHorEntTdForm"><uc1:tarjetaCreditoCriterio ID="TarjetaCreditoCriterio1" runat="server" /></td></tr>
                                                        <tr>
                                                            <td class="formHorEntTdButton">
                                                                <asp:Button ID="btn_criterio_buscar" runat="server" Text="Buscar" CausesValidation="true" SkinID="btnAccion" ValidationGroup="criterio" />
                                                                <asp:Button ID="btn_criterio_cancelar" runat="server" Text="Cancelar" CausesValidation="false" SkinID="btnAccion" />
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
                                <td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView AllowPaging="true" PageSize="20" ID="gv_tarjeta" runat="server" AutoGenerateColumns="false" DataSourceID="ods_tarjeta_lista" DataKeyNames="id_tarjetacredito">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_tarjetacredito") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la tarjeta de crédito?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="contratos" Text="Contratos" ControlStyle-CssClass="gvButton" />

                                            <asp:BoundField HeaderText="Tipo" DataField="tipo_tarjeta" />
                                            <asp:BoundField HeaderText="Banco" DataField="codigo_banco" />
                                            <asp:BoundField HeaderText="Nº tarjeta" DataField="num_tarjeta" />
                                            <asp:BoundField HeaderText="F.Vencim." DataField="fecha_vencimiento" />
                                            <asp:BoundField HeaderText="Titular" DataField="titular" />
                                            <asp:BoundField HeaderText="CI" DataField="ci" />
                                            <asp:TemplateField HeaderText="Contratos"><ItemTemplate><asp:Label ID="lbl_contrato" runat="server" Text='<%# Lista_contratos_por_tarjeta(Eval("id_tarjetacredito").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Activo" DataField="activo" />
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_tarjetacredito],[tipo_tarjeta],[codigo_banco],[num_tarjeta],[fecha_vencimiento],[titular],[ci],[activo],[num_contratos]--%>
                                    <asp:ObjectDataSource ID="ods_tarjeta_lista" runat="server" TypeName="terrasur.tarjeta_credito" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:Parameter Name="Id_tipotarjetacredito" Type="Int32" />
                                            <asp:Parameter Name="Id_banco" Type="Int32" />
                                            <asp:Parameter Name="Num_tarjeta" Type="String" />
                                            <asp:Parameter Name="Titular" Type="String" />
                                            <asp:Parameter Name="Ci" Type="String" />
                                            <asp:Parameter Name="Num_contrato" Type="String" />
                                            <asp:Parameter Name="Tarjeta_activa" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_tarjeta_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc2:tarjetaCreditoAbm ID="TarjetaCreditoAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="tarjeta" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="tarjeta" />
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