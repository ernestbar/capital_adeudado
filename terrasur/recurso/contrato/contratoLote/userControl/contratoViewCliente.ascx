<%@ Control Language="VB" ClassName="contratoViewCliente" %>

<script runat="server">
    Public WriteOnly Property lista_clientes() As String
        Set(ByVal value As String)
            'lbl_strCl.Text = value
            gv_clientes.DataSource = tmpCliente.TablaCliente(value)
            gv_clientes.DataBind()
        End Set
    End Property
</script>
<%--<asp:Label ID="lbl_strCl" runat="server" Visible="false"></asp:Label>--%>
<table class="contratoFormTable" align="left" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdLeft"></td>
        <td>
            <asp:GridView ID="gv_clientes" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="C.I." ItemStyle-HorizontalAlign="Right"><ItemTemplate><asp:Label ID="lbl_ci" runat="server" Text='<%# String.Format("{0} {1}",Eval("ci"),Eval("codigo_lugar_cedula")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre completo"><ItemTemplate><asp:Label ID="lbl_nombre" runat="server" Text='<%# String.Format("{0} {1} {2}",Eval("paterno"),Eval("materno"),Eval("nombres")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:BoundField HeaderText="NIT" DataField="nit" />
                    <asp:BoundField HeaderText="Teléfono" DataField="fono" />
                    <asp:BoundField HeaderText="Email" DataField="email" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<%--[id_cliente],[ci],[codigo_lugar_cedula],[paterno],[materno],[nombres],[nit],[fono],[email]--%>
<%--<asp:ObjectDataSource ID="ods_lista_cliente_tmp" runat="server" TypeName="terrasur.tmpCliente" SelectMethod="TablaCliente">
    <SelectParameters>
        <asp:ControlParameter Name="strCl" Type="String" ControlID="lbl_strCl" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>--%>