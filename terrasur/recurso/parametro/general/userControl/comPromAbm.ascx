<%@ Control Language="VB" ClassName="comPromAbm" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            'CargarActualizar()
            'txt_valor.Enabled = False
            'txt_valor_2.Enabled = False
            'txt_valor_3.Enabled = False
            'btn_mod.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "update")
            
        End If
    End Sub

</script>

<asp:Panel ID="panel_cartera" runat="server" GroupingText="Comisiones a Promotores">
    <table class="formTable" align="center" cellspacing="0">
        <tr>
            <td>
                <asp:GridView ID="gv_comisiones" runat="server" DataSourceID="ods_lista_comisiones" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Tipo de Inmueble" DataField="tipo_inmueble" />
                        <asp:BoundField HeaderText="Tipo de Promotor" DataField="tipo_promotor" />
                        <%--<asp:BoundField HeaderText="%Com. Cuo.Ini<50%" DataField="porcent_cuo_ini_menor50" />
                        <asp:BoundField HeaderText="%Com. Cuo.Ini<100%" DataField="porcent_cuo_ini_menor100" />
                        <asp:BoundField HeaderText="%Com. Cuo.Ini=100%" DataField="porcent_cuo_ini_igual100" />
                        <asp:BoundField HeaderText="Com.Ini. % de Cuo.Ini." DataField="com_ini_porcent_cuo_ini" />
                        <asp:BoundField HeaderText="Com.Ini. % de Com.Total" DataField="com_ini_porcent_comision" />
                        <asp:BoundField HeaderText="Nº arrastres" DataField="com_num_adicional" />
                        --%>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>% Comisión<br />Cuo.Ini<50%</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_porcent_cuo_ini_menor50" runat="server" Text='<%# Eval("porcent_cuo_ini_menor50") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>% Comisión<br />Cuo.Ini<100%</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_porcent_cuo_ini_menor100" runat="server" Text='<%# Eval("porcent_cuo_ini_menor100") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>% Comisión<br />Cuo.Ini=100%</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_porcent_cuo_ini_igual100" runat="server" Text='<%# Eval("porcent_cuo_ini_igual100") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Com.Inicial<br />% de Cuo.Ini.</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_com_ini_porcent_cuo_ini" runat="server" Text='<%# Eval("com_ini_porcent_cuo_ini") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Com.Inicial<br />% de Com.Total</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_com_ini_porcent_comision" runat="server" Text='<%# Eval("com_ini_porcent_comision") %>'></asp:Label> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Nº <br />arrastres</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_com_num_adicional" runat="server" Text='<%# Eval("com_num_adicional") %>'></asp:Label> </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--[tipo_inmueble],[tipo_promotor],
                [porcent_cuo_ini_menor50],[porcent_cuo_ini_menor100],[porcent_cuo_ini_igual100]
                [com_ini_porcent_cuo_ini],[com_ini_porcent_comision],[com_num_adicional]--%>
                <asp:ObjectDataSource ID="ods_lista_comisiones" runat="server" TypeName="terrasur.tipoPromotor" SelectMethod="Lista_ParametrosComisionPromotor">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="ods_lista_arrastres" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Tipo de Inmueble" DataField="tipo_inmueble" />
                        <%--<asp:BoundField HeaderText="Nº arrastre" DataField="num_arrastre" />
                        <asp:BoundField HeaderText="% comisión a pagar" DataField="porcent_arrastre" />
                        <asp:BoundField HeaderText="Condición: % pago a capital del cliente" DataField="porcent_capital" />--%>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Nº<br />arrastre</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_num_arrastre1" runat="server" Text='<%# Eval("num_arrastre") %>'></asp:Label> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>% a pagar<br />del total de<br />la comisión</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_porcent_arrastre" runat="server" Text='<%# Eval("porcent_arrastre") %>'></asp:Label> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Condición:<br />% pago a capital<br />del cliente</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="lbl_porcent_capital" runat="server" Text='<%# Eval("porcent_capital") %>'></asp:Label> </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--[tipo_inmueble],[num_arrastre],[porcent_arrastre],[porcent_capital]--%>
                <asp:ObjectDataSource ID="ods_lista_arrastres" runat="server" TypeName="terrasur.tipoPromotor" SelectMethod="Lista_ParametrosArrastreInmuebles">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>
