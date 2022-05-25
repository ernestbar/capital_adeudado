<%@ Control Language="C#" ClassName="manzanoViewDato" %>

<script runat="server">
    public int id_manzano
    {
        get { return int.Parse(lbl_id_manzano.Text); }
        
        set
        {
            manzano manzanoObj = new manzano(value);
            urbanizacion urbObj = new urbanizacion(manzanoObj.id_urbanizacion);
            localizacion locObj = new localizacion(urbObj.id_localizacion);
            lbl_localizacion.Text = locObj.nombre + " (" + locObj.codigo + ")";
            lbl_urbanizacion.Text = urbObj.nombre + " (" + urbObj.codigo + ")";
            lbl_codigo.Text = manzanoObj.codigo;
            lbl_num_lotes.Text = manzanoObj.num_lote.ToString();
            lbl_id_manzano.Text = value.ToString();
        }
    }

    protected void gv_lotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
        case "lote":
            Session["id_lote"] = int.Parse(gv_lotes.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            Response.Redirect("~/recurso/inventario/lote/loteDetalle.aspx");
         break;
        default:
         break;
        }
    }
</script>

<asp:Label ID="lbl_id_manzano" runat="server" Text="0" Visible="false"></asp:Label>
<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Manzano:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_codigo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_num_lotes_enun" runat="server" Text="No. de lotes:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_num_lotes" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_lotes_enun" runat="server" Text="Lotes:"></asp:Label></td>
        <td class="formTdDato">
           <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdGrid">
                        <asp:GridView ID="gv_lotes" runat="server" AutoGenerateColumns="False" DataSourceID="ods_lotes_lista"
                            DataKeyNames="id_lote" OnRowCommand="gv_lotes_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Lote" DataField="codigo" />
                                <asp:BoundField HeaderText="Estado" DataField="nombre_estado" />
                                <asp:ButtonField CommandName="lote" Text="Ver Lote" ControlStyle-CssClass="gvButton"  ButtonType="Link" />
                            </Columns>
                        </asp:GridView>
                        <%--[id_manzano],[codigo],[num_lote]--%>
                        <asp:ObjectDataSource ID="ods_lotes_lista" runat="server" TypeName="terrasur.lote"
                            SelectMethod="Lista">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="lbl_id_manzano" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
    </tr>
</table>