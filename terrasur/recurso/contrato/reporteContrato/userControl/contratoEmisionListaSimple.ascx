<%@ Control Language="C#" ClassName="contratoEmisionListaSimple" %>

<script runat="server">
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    private string tipo_documento { get { return lbl_tipo_documento.Text; } set { lbl_tipo_documento.Text = value; } }

    public void Cargar(int Id_contrato, string Tipo_documento)
    {
        id_contrato = Id_contrato;
        tipo_documento = Tipo_documento;
        //hl_detalle.NavigateUrl = "~/recurso/contrato/reporteContrato/reporteContratoEmisionContrato.aspx?ic=" + Id_contrato.ToString() + "&td=" + Tipo_documento.ToString();
        hl_detalle.NavigateUrl = "~/recurso/contrato/reporteContrato/reporteContratoEmisionContrato.aspx?ic=" + Id_contrato.ToString();
        panel_emision.GroupingText = "Emisiones del: " + terrasur.emDoc.emision.NombreTipoDocumentoPorCodigo(Tipo_documento) + " (para clientes)";
        gv_lista.DataBind();
        panel_emision.Visible = gv_lista.Rows.Count.Equals(0).Equals(false);
    }
    
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_tipo_documento" runat="server" Text="" Visible="false"></asp:Label>
<asp:Panel ID="panel_emision" runat="server" ScrollBars="Vertical" Height="80">
    <table cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td align="right">
                <asp:HyperLink ID="hl_detalle" runat="server" Text="Detalles de la emisión" Target="_blank" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoEmisionContrato.aspx"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gv_lista" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista" DataKeyNames="id_emision">
                    <Columns>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy hh:mm}" ItemStyle-CssClass="cajaGvCellDate" />
                        <asp:BoundField DataField="tipo_documento" HeaderText="Tipo de doc." />
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lbl_sin_registros" runat="server" Text="Sin registros de emisión de documentos para clientes"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <%--[id_emision],[fecha],[usuario],[tipo_documento],[cliente]--%>
                <asp:ObjectDataSource ID="ods_lista" runat="server" TypeName="terrasur.emDoc.emision" SelectMethod="ListaPorContrato">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                        <asp:ControlParameter Name="TipoDocumento_codigo" Type="String" ControlID="lbl_tipo_documento" PropertyName="Text" />
                        <asp:Parameter Name="Para_cliente" Type="Int32" DefaultValue="1" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <%--int Id_contrato, string TipoDocumento_codigo, int Para_cliente--%>
            </td>
        </tr>
    </table>
</asp:Panel>


