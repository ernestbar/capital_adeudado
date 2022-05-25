<%@ Control Language="VB" ClassName="liquidacionViewServiciosVendidos" %>

<script runat="server">
    Public WriteOnly Property id_contrato() As Integer
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value.ToString()

            gv_servicios.Columns(2).HeaderText = "Precio Total (" & contrato.CodigoMoneda(value) & ")"

            gv_servicios.DataBind()
        End Set
    End Property 
  
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Visible="false"></asp:Label>
<table class="liquidacionViewTable" align="center" cellspacing="0">
    <tr>
        <td class="tdGrid">
            <asp:GridView ID="gv_servicios" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_servicios" DataKeyNames="id_servicio">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="Servicio" />
                    <asp:BoundField DataField="num_unidades" HeaderText="No. unidades/cuotas" ItemStyle-CssClass="gvCell1"/>
                    <asp:BoundField DataField="precio_total" HeaderText="Precio Total" ItemStyle-CssClass="gvCell1"/>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="ods_lista_servicios" runat="server" TypeName="terrasur.liquidacion" SelectMethod="ListaServiciosLiquidablesVendidos">
    <SelectParameters>
        <asp:ControlParameter Name="id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>
