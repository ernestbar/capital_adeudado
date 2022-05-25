<%@ Control Language="C#" ClassName="sTipoPagoView" %>

<script runat="server">
    public void Cargar()
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "s_tipo_pago", "view") == true)
        {
            panel_tipo_pago.Visible = true;
            gv_tipo_pago.DataBind();
        }
        else { panel_tipo_pago.Visible = false; }
    }
</script>
<asp:Panel ID="panel_tipo_pago" runat="server" GroupingText="Tipos de pago">
    <table align="center">
        <tr>
            <td>
                <asp:GridView ID="gv_tipo_pago" runat="server" DataSourceID="ods_lista_tipo_pago" DataKeyNames="id_tipopago" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" />
                    </Columns>
                </asp:GridView>
                <%--[id_tipopago],[codigo],[nombre],[activo]--%>
                <asp:ObjectDataSource ID="ods_lista_tipo_pago" runat="server" TypeName="terrasur.sintesis.s_tipo_pago" SelectMethod="Lista">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>