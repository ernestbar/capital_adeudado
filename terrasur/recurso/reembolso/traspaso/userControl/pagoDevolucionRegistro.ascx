<%@ Control Language="C#" ClassName="pagoDevolucionRegistro" %>

<script runat="server">
    public int id_reembolso
    {
        set
        {
            lbl_id_reembolso.Text = value.ToString();
            gv_pago.DataBind();
            //terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(value);
            //lbl_num_contrato.Text = rObj.num_contrato;
            //lbl_producto.Text = rObj.producto;
            //lbl_cliente.Text = terrasur.traspaso.cliente_reembolso.Lista_string(rObj.id_reembolso).Replace(",", "</br>");
            //lbl_monto_enun.Text = "Monto de devolución (" + rObj.codigo_moneda + "):";
            //lbl_monto.Text = rObj.monto.ToString("N2");
        }
    }

    protected void gv_pago_DataBound(object sender, EventArgs e)
    {
        if (gv_pago.Rows.Count > 0)
        {
            gv_pago.Rows[gv_pago.Rows.Count - 1].CssClass = "gvRowSelected";
        }
    }
    protected void gv_pago_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[gv_pago.Columns.Count - 1].Controls[0].Visible = (bool)DataBinder.Eval(e.Row.DataItem, "permitir_pago");
        }
    }

    protected void gv_pago_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "pagado")
        {
            int Id_pago = int.Parse(e.CommandArgument.ToString());
            if ((new terrasur.traspaso.pago(Id_pago)).MarcarPagado(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
            {
                Msg1.Text = "El pago se marcó como PAGADO";
                gv_pago.DataBind();
            }
            else { Msg1.Text = "El pago NO se marcó como PAGADO"; }
        }
    }
    
</script>
<asp:Label ID="lbl_id_reembolso" runat="server" Text="0" Visible="false"></asp:Label>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_pago" runat="server" AutoGenerateColumns="false" DataSourceID="ods_pago_lista" DataKeyNames="id_pago" OnDataBound="gv_pago_DataBound" OnRowCommand="gv_pago_RowCommand" OnRowDataBound="gv_pago_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="orden_string" />
                    <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Monto" DataField="monto" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                    <asp:TemplateField HeaderText="Estado"><ItemTemplate><asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado") %>' ToolTip='<%# Eval("estado_detalle") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <%--<asp:ButtonField CommandName="retirar" Text="Eliminar" ButtonType="Image" ImageUrl="~/images/gv/delete.gif" />--%>
                    <asp:TemplateField><ItemTemplate><asp:Button ID="btn_pagado" runat="server" Text="Pagado" CommandName="pagado" CommandArgument='<%# Eval("id_pago") %>' OnClientClick="return confirm('¿Esta seguro(a)?');" /></ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%--[id_pago],[orden],[orden_string],[fecha],[monto],[estado],[pagado],[estado_detalle],[permitir_pago],[permitir_retirar]--%>
            <asp:ObjectDataSource ID="ods_pago_lista" runat="server" TypeName="terrasur.traspaso.pago" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_reembolso" Type="Int32" ControlID="lbl_id_reembolso" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
