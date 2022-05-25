<%@ Control Language="C#" AutoEventWireup="true" CodeFile="carteraOdooWP.ascx.cs" Inherits="recurso_userControl_webPart_carteraOdooWP" %>
<table class="wpContenidoTable" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle">Cuentas Cartera Odoo</td></tr>
                    <tr>
                        <td class="wpContenidoTdButton">
                            <%--<asp:Button ID="btn_contrato_lista" runat="server" Text="Listado" SkinID="btnWebPart" OnClick="btn_contrato_lista_Click" />--%>
                            <asp:Button ID="btn_contrato_insert" runat="server" Text="Entrar" SkinID="btnWebPart" OnClick="btn_contrato_insert_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
   

    <tr>
        <td>
            <asp:Panel ID="panel_reporte" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr><td class="wpContenidoTdTitle">Reportes operaciones cartera</td></tr>
                    <tr>
                        <td class="wpContenidoTd">
                            <asp:Repeater ID="r_reporte" runat="server" DataSourceID="ods_lista_reporte" OnItemCommand="r_reporte_ItemCommand">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_reporte" runat="server" CommandArgument='<%# Eval("codigo") %>' Text='<%# Eval("nombre") %>' SkinID="lbWebPart" OnClick="lb_reporte_Click"></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbl_reporte_id_recurso" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:ObjectDataSource ID="ods_lista_reporte" runat="server" TypeName="terrasur.permiso" SelectMethod="ListaPorRecurso">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_recurso" Type="Int32" ControlID="lbl_reporte_id_recurso" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:LinkButton ID="lbtnOdooMigracion" runat="server" 
                                onclick="lbtnOdooMigracion_Click">Migracion Odoo</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>