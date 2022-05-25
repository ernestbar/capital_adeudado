<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Listado de contratos de venta de lotes" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoLoteFiltro.ascx" TagName="contratoLoteFiltro" TagPrefix="uc2" %>

<script runat="server">
    Protected Property primer_postback() As Boolean
        Get
            Return Boolean.Parse(lbl_primer_postback.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_primer_postback.Text = value
        End Set
    End Property
    Protected Sub ods_lista_contrato_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_lista_contrato.Selecting
        If primer_postback Then
            e.InputParameters("Id_localizacion") = -1
        Else
            e.InputParameters("Id_localizacion") = clf1.id_localizacion
        End If
        e.InputParameters("Id_urbanizacion") = clf1.id_urbanizacion
        e.InputParameters("Id_manzano") = clf1.id_manzano
        e.InputParameters("Id_lote") = clf1.id_lote
        
        e.InputParameters("Id_estado_contrato") = clf1.id_estado_contrato
        e.InputParameters("Id_promotor") = clf1.id_promotor
        e.InputParameters("Id_lugarcobro") = clf1.id_lugarcobro
        e.InputParameters("Por_cobrador") = clf1.por_cobrador
        
        e.InputParameters("Fecha_registro_inicio_existe") = clf1.fecha_registro_inicio_existe
        e.InputParameters("Fecha_registro_inicio") = clf1.fecha_registro_inicio
        e.InputParameters("Fecha_registro_fin_existe") = clf1.fecha_registro_fin_existe
        e.InputParameters("Fecha_registro_fin") = clf1.fecha_registro_fin
        
        e.InputParameters("Fecha_proximo_inicio_existe") = clf1.fecha_proximo_inicio_existe
        e.InputParameters("Fecha_proximo_inicio") = clf1.fecha_proximo_inicio
        e.InputParameters("Fecha_proximo_fin_existe") = clf1.fecha_proximo_fin_existe
        e.InputParameters("fecha_proximo_fin") = clf1.fecha_proximo_fin
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "ver_listado") Then
                RecursoMaster1.MostrarLink = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoLote", "registrar")
                primer_postback = True
                clf1.Reset()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If clf1.Verificar Then
            primer_postback = False
            gv_contrato.DataBind()
        End If
    End Sub

    Protected Sub gv_contrato_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_contrato.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
        End If
    End Sub

    Protected Sub gv_contrato_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_contrato.RowCommand
        If e.CommandName = "ver" Then
            Session("id_contrato") = Integer.Parse(gv_contrato.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
            WinPopUp1.Show()
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="contratoLote"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_primer_postback" runat="server" Text="True" Visible="false"></asp:Label>
    <asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoDatosDetalle.aspx"></asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Listado y detalle de contratos de venta de lotes</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdBusqueda">
                            <table align="center">
                                <tr>
                                    <td>
                                        <uc2:contratoLoteFiltro ID="clf1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ButtonAction ID="btn_mostrar" runat="server" Text="Buscar contratos" TextoEnviando="Buscando contratos" CausesValidation="true" ValidationGroup="contrato"/>
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
                            <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_contrato" runat="server" AllowSorting="true" AutoGenerateColumns="false" DataSourceID="ods_lista_contrato" DataKeyNames="id_contrato">
                                <Columns>
                                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                    <asp:BoundField HeaderText="Nº" DataField="numero" SortExpression="numero" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="F.Registro" DataField="fecha_registro" SortExpression="fecha_registro" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Estado" DataField="estado_contrato" SortExpression="estado_contrato" />
                                    <asp:TemplateField HeaderText="Lote" SortExpression="localizacion_nombre,urbanizacion_nombre,manzano_codigo,lote_codigo">
                                        <ItemTemplate><asp:Literal ID="l_lote" runat="server" Text='<%# String.Format("{0}/{1}/{2}/{3}",Eval("localizacion_nombre"),Eval("urbanizacion_nombre"),Eval("manzano_codigo"),Eval("lote_codigo")) %>'></asp:Literal></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Precio final" DataField="precio_final" SortExpression="precio_final" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Moneda" DataField="codigo_moneda" SortExpression="codigo_moneda" />
                                    <asp:BoundField HeaderText="Promotor" DataField="promotor" SortExpression="promotor" />
                                    <asp:BoundField HeaderText="Cobrador" DataField="cobrador" SortExpression="cobrador" />
                                    <asp:BoundField HeaderText="Lugar de cobro" DataField="cobro_lugar" SortExpression="cobro_lugar" />
                                    <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo_pago" SortExpression="fecha_proximo_pago" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1"/>
                                </Columns>
                                <EmptyDataTemplate>No se encontraron contratos (según el criterio de búsqueda)</EmptyDataTemplate>
                            </asp:WizardGridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--[id_contrato],[fecha_registro],[numero],[estado_contrato],[precio_final],[codigo_moneda]
    [localizacion_nombre],[urbanizacion_nombre],[manzano_codigo],[lote_codigo]
    [promotor],[cobrador],[cobro_lugar],[cobro_direccion],[cobro_zona],[fecha_proximo_pago]--%>
    <asp:ObjectDataSource ID="ods_lista_contrato" runat="server" TypeName="terrasur.contrato_venta" SelectMethod="Lista">
        <SelectParameters>
            <asp:Parameter Name="Id_localizacion" Type="Int32" />
            <asp:Parameter Name="Id_urbanizacion" Type="Int32" />
            <asp:Parameter Name="Id_manzano" Type="Int32" />
            <asp:Parameter Name="Id_lote" Type="Int32" />
            
            <asp:Parameter Name="Id_estado_contrato" Type="Int32" />
            <asp:Parameter Name="Id_promotor" Type="Int32" />
            <asp:Parameter Name="Id_lugarcobro" Type="Int32" />
            <asp:Parameter Name="Por_cobrador" Type="Int32" />
            
            <asp:Parameter Name="Fecha_registro_inicio_existe" Type="Boolean" />
            <asp:Parameter Name="Fecha_registro_inicio" Type="DateTime" />
            <asp:Parameter Name="Fecha_registro_fin_existe" Type="Boolean" />
            <asp:Parameter Name="Fecha_registro_fin" Type="DateTime" />

            <asp:Parameter Name="Fecha_proximo_inicio_existe" Type="Boolean" />
            <asp:Parameter Name="Fecha_proximo_inicio" Type="DateTime" />
            <asp:Parameter Name="Fecha_proximo_fin_existe" Type="Boolean" />
            <asp:Parameter Name="fecha_proximo_fin" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

