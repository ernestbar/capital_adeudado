<%@ Control Language="VB" ClassName="fijoViewDato" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsPostBack Then
            Dim itObj As New parametro("it")
            Dim ddrrObj As New parametro("ddrr")
            Dim fiObj As New parametro("factor_impuestos")
            lbl_it.Text = itObj.valor.ToString()
            lbl_ddrr.Text = ddrrObj.valor.ToString()
            lbl_factor.Text = fiObj.valor.ToString()
        End If
    End Sub
    Protected Sub tv_modulo_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs)
        If e.Node.ChildNodes.Count = 0 Then
            Select Case e.Node.Depth
                Case 0
                    general.LlenarModulos(e.Node)
                Case 1
                    general.LlenarGrupoRecursos(e.Node)
                Case 2
                    general.LlenarRecursos(e.Node)
            End Select
        End If
    End Sub
    Protected Sub tv_recursos_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs)
        If e.Node.ChildNodes.Count = 0 Then
            Select Case e.Node.Depth
                Case 0
                    general.LlenarGrupoRecursosLista(e.Node)
                Case 1
                    general.LlenarRecursos(e.Node)
                Case 2
                    general.LlenarPermisos(e.Node)
            End Select
        End If
    End Sub
</script>

<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_negocio" runat="server" GroupingText="Negocios (propietarios de los lotes)">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="gv_negocio" runat="server" AutoGenerateColumns="false" DataSourceID="ods_negocio_lista"
                                DataKeyNames="id_negocio">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_negocio],[codigo],[nombre],[origen]--%>
                            <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio"
                                SelectMethod="Lista"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_cedula" runat="server" GroupingText="Lugares de la cédula (ciudad de emisión)">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="gv_cedula" runat="server" AutoGenerateColumns="false" DataSourceID="ods_cedula_lista"
                                DataKeyNames="id_lugarcedula">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_lugarcedula],[codigo],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_cedula_lista" runat="server" TypeName="terrasur.lugar_cedula"
                                SelectMethod="Lista"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_tipopago" runat="server" GroupingText="Tipos de pago (pagos sobre un contrato)">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="gv_tipopago" runat="server" AutoGenerateColumns="false" DataSourceID="ods_tipopago_lista"
                                DataKeyNames="id_tipopago">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_tipopago],[codigo],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_tipopago_lista" runat="server" TypeName="terrasur.tipo_pago"
                                SelectMethod="Lista"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_moneda" runat="server" GroupingText="Moneda (por defecto solo $us)">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="gv_moneda" runat="server" AutoGenerateColumns="false" DataSourceID="ods_moneda_lista"
                                DataKeyNames="id_moneda">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_moneda],[codigo],[nombre]--%>
                            <asp:ObjectDataSource ID="ods_moneda_lista" runat="server" TypeName="terrasur.moneda"
                                SelectMethod="Lista"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_estado" runat="server" GroupingText="Estados de un lote">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataSourceID="ods_estado_lista"
                                DataKeyNames="id_estado">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                    <asp:BoundField HeaderText="Horas Limite" DataField="horas_limite" />
                                    <asp:CheckBoxField HeaderText="Vendible" DataField="vendible" Text="Vendible" />
                                    <asp:CheckBoxField HeaderText="Cambiar" DataField="permitir_cambiar" Text="Cambiar" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_estado],[codigo],[nombre],[horas_limite],[vendible],[permitir_cambiar]--%>
                            <asp:ObjectDataSource ID="ods_estado_lista" runat="server" TypeName="terrasur.estado"
                                SelectMethod="Lista"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_liquidacion" runat="server" GroupingText="Liquidación">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdEnun">
                            <asp:Label ID="lbl_it_enun" runat="server" Text="IT:"></asp:Label></td>
                        <td class="formTdDato">
                            <asp:Label ID="lbl_it" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">
                            <asp:Label ID="lbl_ddrr_enum" runat="server" Text="DDRR:"></asp:Label></td>
                        <td class="formTdDato">
                            <asp:Label ID="lbl_ddrr" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">
                            <asp:Label ID="lbl_factor_enum" runat="server" Text="Factor de impuestos:"></asp:Label></td>
                        <td class="formTdDato">
                            <asp:Label ID="lbl_factor" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_rol" runat="server" GroupingText="Roles (funciones de los usuarios)">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdGrid">
                            <asp:GridView ID="gv_rol" runat="server" AutoGenerateColumns="false" DataSourceID="ods_rol_lista"
                                DataKeyNames="id_rol">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                    <asp:BoundField HeaderText="Módulo" DataField="modulo_nombre" />
                                </Columns>
                            </asp:GridView>
                            <%--[id_rol],[id_modulo],[codigo],[nombre],[modulo_nombre]--%>
                            <asp:ObjectDataSource ID="ods_rol_lista" runat="server" TypeName="terrasur.rol" SelectMethod="Lista">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_modulos" runat="server" GroupingText="Módulos">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdEnun">
                            <asp:TreeView ID="tv_modulo" runat="server" MaxDataBindDepth="4" OnTreeNodePopulate="tv_modulo_TreeNodePopulate">
                                <Nodes>
                                    <asp:TreeNode PopulateOnDemand="True" Text="Modulos" Value="Modulos" SelectAction="Expand">
                                    </asp:TreeNode>
                                </Nodes>
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_recursos" runat="server" GroupingText="Grupo de recursos - Recursos - Permisos">
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdEnun">
                            <asp:TreeView ID="tv_recursos" runat="server" MaxDataBindDepth="4" OnTreeNodePopulate="tv_recursos_TreeNodePopulate">
                                <Nodes>
                                    <asp:TreeNode PopulateOnDemand="True" Text="Grupo de Recursos" Value="Grupo de recursos"
                                        SelectAction="Expand"></asp:TreeNode>
                                </Nodes>
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table> 
