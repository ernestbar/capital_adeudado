<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Asignación de contratos a tarjetas de crédito" %>
<%@ Register src="~/recurso/contabilidad/debitoatc/userControl/tarjetaCreditoView.ascx" tagname="tarjetaCreditoView" tagprefix="uc1" %>
<%@ Register src="~/recurso/contabilidad/debitoatc/userControl/tarjetaContratoAbm.ascx" tagname="tarjetaContratoAbm" tagprefix="uc2" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Property id_tarjetacredito() As Integer
        Get
            Return Integer.Parse(lbl_id_tarjetacredito.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_tarjetacredito.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_tarjetacredito") IsNot Nothing Then
                id_tarjetacredito = Integer.Parse(Session("id_tarjetacredito").ToString)
                tarjetaCreditoView1.id_tarjetacredito = id_tarjetacredito
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCreditoContrato", "insert")
                Session.Remove("id_tarjetacredito")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_tarjeta_abm.Text = "Nueva asignación"
        tarjetaContratoAbm1.CargarInsertar(id_tarjetacredito)
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If tarjetaContratoAbm1.Insertar Then
            gv_contrato.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If tarjetaContratoAbm1.Actualizar Then
            gv_contrato.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub gv_contrato_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_contrato.DataBound
        gv_contrato.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCreditoContrato", "update")
        gv_contrato.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCreditoContrato", "delete")
    End Sub

    Protected Sub gv_contrato_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_contrato.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_debitos")) > 0 Then
                CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub

    Protected Sub gv_contrato_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_contrato.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_tarjeta_abm.Text = "Edición de la asignación"
                tarjetaContratoAbm1.CargarActualizar(Integer.Parse(gv_contrato.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim tcObj As New tarjeta_credito_contrato(Integer.Parse(e.CommandArgument.ToString))
                If tcObj.num_transacciones = 0 Then
                    If tcObj.Eliminar(Profile.id_usuario) Then
                        gv_contrato.DataBind()
                        Msg1.Text = "La asignación se eliminó correctamente"
                    Else
                        Msg1.Text = "La asignación NO se eliminó correctamente"
                    End If
                Else
                    Msg1.Text = "La asignación NO se eliminó correctamente"
                End If
        End Select
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Response.Redirect("~/recurso/contabilidad/debitoatc/tarjetaCredito.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="tarjeta_credito_contrato" MostrarLink="true"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_id_tarjetacredito" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="priTable">
        <tr><td class="priTdTitle">Asignación de contratos a tarjetas de crédito</td></tr>
        <tr>
            <td class="priTdContenido">
                <table width="100%">
                    <%--<tr>
                        <td align="right">
                            <asp:Button ID="btn_volver" runat="server" Text="Volver a Tarjetas de crédito" SkinID="btnVolver" CausesValidation="false" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <uc1:tarjetacreditoview ID="tarjetaCreditoView1" runat="server" MostrarDatosRegistro="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View id="View1" runat="server">
                                    <table class="tableContenido" align="center">
                                        <tr>
                                            <td class="tdButton">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left"><asp:Button ID="btn_nuevo" runat="server" Text="Nueva asignación" /></td>
                                                        <td align="right"><asp:Button ID="btn_volver" runat="server" Text="Volver a Tarjetas de crédito" CausesValidation="false" /></td>
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
                                                <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_contratos" DataKeyNames="id_tarjetacreditocontrato">
                                                    <Columns>
                                                        <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                                        <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_tarjetacreditocontrato") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar la asignación?');" /></ItemTemplate></asp:TemplateField>
                                                        <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                                        <asp:BoundField HeaderText="Moneda" DataField="codigo_moneda" />
                                                        <asp:BoundField HeaderText="Periodicidad" DataField="periodicidad_nombre" ItemStyle-CssClass="gvCell1" />
                                                        <asp:BoundField HeaderText="F. debito (día)" DataField="fecha_debito" HtmlEncode="false" DataFormatString="{0:dd}" ItemStyle-CssClass="gvCell1" />
                                                        <asp:BoundField HeaderText="Monto ($us)" DataField="monto_sus" ItemStyle-CssClass="gvCell1" />
                                                        <asp:BoundField HeaderText="Monto (Bs)" DataField="monto_bs" ItemStyle-CssClass="gvCell1" />
                                                        <asp:BoundField HeaderText="Activo" DataField="activo" />
                                                    </Columns>
                                                </asp:GridView>
                                                <%--[id_tarjetacreditocontrato],[id_contrato],[num_contrato],[periodicidad_codigo],[periodicidad_nombre],
                                                [fecha_debito],[monto_bs],[monto_sus],[num_debitos],[num_debitos_efectivos],[activo]--%>
                                                <asp:ObjectDataSource ID="ods_lista_contratos" runat="server" TypeName="terrasur.tarjeta_credito_contrato" SelectMethod="ListaContratos">
                                                    <SelectParameters>
                                                        <asp:ControlParameter Name="Id_tarjetacredito" Type="Int32" ControlID="lbl_id_tarjetacredito" PropertyName="Text" />
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
                                            <tr><td class="formEntTdForm"><uc2:tarjetaContratoAbm ID="tarjetaContratoAbm1" runat="server" /></td></tr>
                                            <tr>
                                                <td class="formEntTdButton">
                                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="tarjeta_contrato" />
                                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="tarjeta_contrato" />
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
            </td>
        </tr>
    </table>
</asp:Content>