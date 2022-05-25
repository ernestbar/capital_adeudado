<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Intercambios" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register src="~/recurso/contrato/intercambio/userControl/intercambioAbm.ascx" tagname="intercambioAbm" tagprefix="uc1" %>
<%@ Register src="~/recurso/contrato/intercambio/userControl/filtroReporteIntercambio.ascx" tagname="filtroReporteIntercambio" tagprefix="uc3" %>

<script runat="server">
    Protected Property primer_ingreso() As Boolean
        Get
            Return Boolean.Parse(lbl_primer_ingreso.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_primer_ingreso.Text = value
        End Set
    End Property
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            primer_ingreso = True
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "insert")
                btn_reporte.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "reporteIntercambio")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_intercambio_abm.Text = "Nuevo intercambio"
        intercambioAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If intercambioAbm1.Insertar Then
            gv1.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If intercambioAbm1.Actualizar Then
            gv1.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    Protected Sub gv1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv1.DataBound
        gv1.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "update")
        gv1.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "delete")
        lbl_num_intercambios.Visible = primer_ingreso.Equals(False)
        lbl_num_intercambios.Text = "Nº intercambios: " + gv1.Rows.Count.ToString
    End Sub

    Protected Sub gv1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            'CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_clientes").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv1.RowCommand
        Select Case e.CommandName
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_intercambio_abm.Text = "Edición de datos de un intercambio"
                intercambioAbm1.CargarActualizar(Integer.Parse(gv1.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim iObj As New intercambio(Integer.Parse(e.CommandArgument.ToString))
                If iObj.Eliminar(Profile.id_usuario) Then
                    gv1.DataBind()
                    Msg1.Text = "La intercambio se eliminó correctamente"
                Else
                    Msg1.Text = "La intercambio NO se eliminó correctamente"
                End If
        End Select
    End Sub

    Protected Sub btn_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Response.Redirect("~/recurso/contrato/intercambio/reporteIntercambio.aspx")
        Session("datosFiltroIntercambio") = f1.datosFiltro
        WinPopUp1.Show()
    End Sub

    'Protected Sub btn_auditoria_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Response.Redirect("~/recurso/contrato/intercambio/reporteAuditoria.aspx")
    'End Sub

    Protected Sub ods_intercambio_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
        e.InputParameters("Fecha_inicio") = f1.fecha_inicio
        e.InputParameters("Fecha_fin") = f1.fecha_fin
        If primer_ingreso Then
            e.InputParameters("Num_contrato") = "0"
        Else
            e.InputParameters("Num_contrato") = f1.num_contrato
        End If
        e.InputParameters("Id_localizacion") = f1.id_localizacion
        e.InputParameters("Id_urbanizacion") = f1.id_urbanizacion
        e.InputParameters("Id_manzano") = f1.id_manzano
        e.InputParameters("Empresa") = f1.empresa
        e.InputParameters("Descripcion") = f1.descripcion
    End Sub

    Protected Sub btn_mostrar_datos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        primer_ingreso = False
        gv1.DataBind()
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="intercambio" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/intercambio/reporteIntercambio.aspx" Win_Left="100" Win_Top="100" Win_Width="850" Win_Height="500"></asp:WinPopUp>
    <asp:Label ID="lbl_primer_ingreso" runat="server" Text="true" Visible="false"></asp:Label>
    <table class="priTable">
        <tr><td class="priTdTitle">Intercambios</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center" width="100%">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de búsqueda" DefaultButton="btn_mostrar_datos">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <uc3:filtroReporteIntercambio ID="f1" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btn_mostrar_datos" runat="server" Text="Obtener datos" OnClick="btn_mostrar_datos_Click" />
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
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <%--<asp:WizardGridView AllowPaging="true" PageSize="20" --%>
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left"><asp:Button ID="btn_nuevo" runat="server" Text="Nuevo intercambio" /></td>
                                                        <td><div style="width:400px;"></div></td>
                                                        <td align="right"><asp:Button ID="btn_reporte" runat="server" Text="Reporte de intercambios" OnClick="btn_reporte_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_num_intercambios" runat="server" SkinID="lblEnun"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" DataSourceID="ods_intercambio_lista" DataKeyNames="id_intercambio">
                                                    <Columns>
                                                        <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                                        <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_intercambio") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el intercambio?');" /></ItemTemplate></asp:TemplateField>
                                                        <asp:BoundField HeaderText="Nº ctto." DataField="num_contrato" />
                                                        <asp:BoundField HeaderText="Lote" DataField="lote" />
                                                        <asp:BoundField HeaderText="F.Inter." DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                                        <asp:BoundField HeaderText="Empresa" DataField="empresa" />
                                                        <asp:TemplateField HeaderText="Descripción">
                                                            <ItemTemplate>
                                                                <div style="width:450px;">
                                                                    <asp:Label ID="lbl_descripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--[id_intercambio],[id_contrato],[id_estadolote],[num_contrato],[lote],[usuario],[fecha],[empresa],[descripcion],[fecha_registro]--%>
                                    <%--<asp:ObjectDataSource ID="ods_intercambio_lista" runat="server" TypeName="terrasur.intercambio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>--%>
                                    <asp:ObjectDataSource ID="ods_intercambio_lista" runat="server" TypeName="terrasur.intercambio" SelectMethod="Reporte" OnSelecting="ods_intercambio_lista_Selecting">
                                        <SelectParameters>
                                            <asp:Parameter Name="Fecha_inicio" Type="DateTime" />
                                            <asp:Parameter Name="Fecha_fin" Type="DateTime" />
                                            <asp:Parameter Name="Num_contrato" Type="String" />
                                            <asp:Parameter Name="Id_localizacion" Type="Int32" />
                                            <asp:Parameter Name="Id_urbanizacion" Type="Int32" />
                                            <asp:Parameter Name="Id_manzano" Type="Int32" />
                                            <asp:Parameter Name="Empresa" Type="String" />
                                            <asp:Parameter Name="Descripcion" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_intercambio_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc1:intercambioAbm ID="intercambioAbm1" runat="server" />
                                </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="intercambio" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="intercambio" />
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
