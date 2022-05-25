<%@ Control Language="C#" ClassName="legalFiltroLote" %>

<script runat="server">
    public int id_localizacion { get { if (ddl_localizacion.Items.Count > 0) { return int.Parse(ddl_localizacion.SelectedValue); } else { return 0; } } }
    public int id_urbanizacion { get { if (ddl_urbanizacion.Items.Count > 0) { return int.Parse(ddl_urbanizacion.SelectedValue); } else { return 0; } } }
    public int id_manzano { get { if (ddl_manzano.Items.Count > 0) { return int.Parse(ddl_manzano.SelectedValue); } else { return 0; } } }
    public int id_lote { get { if (ddl_lote.Items.Count > 0) { return int.Parse(ddl_lote.SelectedValue); } else { return 0; } } }
    public string id_estado
    {
        get
        {
            StringBuilder str = new StringBuilder();
            foreach (ListItem item in cbl_estado.Items) { if (item.Selected == true) str.Append(item.Value + ","); }
            if (str.ToString() != "") return "," + str.ToString().TrimEnd(',') + ",";
            else return "";
        }
    }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } }

    
    public string string_localizacion { get { if (ddl_localizacion.Items.Count > 0) return ddl_localizacion.SelectedItem.Text; else return ""; } }
    public string string_urbanizacion { get { if (ddl_urbanizacion.Items.Count > 0) return ddl_urbanizacion.SelectedItem.Text; else return ""; } }
    public string string_manzano { get { if (ddl_manzano.Items.Count > 0) return ddl_manzano.SelectedItem.Text; else  return ""; } }
    public string string_lote { get { if (ddl_lote.Items.Count > 0) return ddl_lote.SelectedItem.Text; else  return ""; } }
    public string string_estado
    {
        get
        {
            StringBuilder str = new StringBuilder();
            int num_elegidos = 0;
            foreach (ListItem item in cbl_estado.Items)
            {
                if (item.Selected == true)
                {
                    str.Append(item.Text + ", ");
                    num_elegidos += 1;
                }
            }
            if (num_elegidos == cbl_estado.Items.Count) return "Todos";
            else if (num_elegidos == 0) return "Ninguno";
            else return str.ToString().Trim().TrimEnd(',');
        }
    }
    public string string_num_contrato { get { if (txt_num_contrato.Text.Trim() == "") return "Todos"; else return txt_num_contrato.Text.Trim(); } }


    public void Reset()
    {
        ddl_localizacion.DataBind();
        ddl_urbanizacion.DataBind();
        ddl_manzano.DataBind();
        ddl_lote.DataBind();
        cbl_estado.DataBind();
        txt_num_contrato.Text = "";
    }

    protected void ddl_localizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_urbanizacion.DataBind();
    }
    protected void ddl_urbanizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_manzano.DataBind();
        ddl_lote.DataBind();
    }
    protected void ddl_localizacion_DataBound(object sender, EventArgs e)
    {
        ddl_localizacion.Items.Insert(0, new ListItem("Todos", "0"));
        ddl_urbanizacion.DataBind();
    }
    protected void ddl_urbanizacion_DataBound(object sender, EventArgs e)
    {
        ddl_urbanizacion.Items.Insert(0, new ListItem("Todos", "0"));
        ddl_manzano.DataBind();
    }
    protected void ddl_manzano_DataBound(object sender, EventArgs e)
    {
        ddl_manzano.Items.Insert(0, new ListItem("Todos", "0"));
        ddl_lote.DataBind();
    }
    protected void ddl_lote_DataBound(object sender, EventArgs e)
    {
        ddl_lote.Items.Insert(0, new ListItem("Todos", "0"));
    }

    protected void cbl_estado_DataBound(object sender, EventArgs e)
    {
        estado eObj = new estado("ine");
        foreach (ListItem item in cbl_estado.Items)
        {
            if (item.Value != eObj.id_estado.ToString()) item.Selected = true;
        }
    }
</script>
<asp:Panel ID="panel_lote" runat="server" GroupingText="Lote">
    <table class="formTable" cellpadding="0" cellspacing="0" align="left">
        <tr>
            <td class="formTdEnun">Localización:</td>
            <td class="formTdDato">
                <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion" OnSelectedIndexChanged="ddl_localizacion_SelectedIndexChanged" OnDataBound="ddl_localizacion_DataBound"></asp:DropDownList>
                <%--[id_localizacion],[nombre]--%>
                <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Sector:</td>
            <td class="formTdDato">
                <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion" OnSelectedIndexChanged="ddl_urbanizacion_SelectedIndexChanged" OnDataBound="ddl_urbanizacion_DataBound"></asp:DropDownList>
                <%--[id_urbanizacion],[nombre_completo]--%>
                <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista_para_ddl">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Manzano:</td>
            <td class="formTdDato">
                <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano" OnDataBound="ddl_manzano_DataBound"></asp:DropDownList>
                <%--[id_manzano],[codigo]--%>
                <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Lote:</td>
            <td class="formTdDato">
                <asp:DropDownList ID="ddl_lote" runat="server" DataSourceID="ods_lote_lista" DataTextField="codigo" DataValueField="id_lote" OnDataBound="ddl_lote_DataBound">
                </asp:DropDownList>
                <%-- [id_lote],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[nombre_estado],[nombre_lote]--%>
                <asp:ObjectDataSource ID="ods_lote_lista" runat="server" TypeName="terrasur.lote" SelectMethod="Lista">
                    <SelectParameters>
                       <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
                   </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Estado:</td>
            <td class="formTdDato">
                <asp:CheckBoxList ID="cbl_estado" runat="server" DataSourceID="ods_estado_lista" RepeatColumns="3" RepeatDirection="Horizontal" DataTextField="nombre" DataValueField="id_estado" CellPadding="0" CellSpacing="0" OnDataBound="cbl_estado_DataBound">
                </asp:CheckBoxList>
                <%--[id_estado],[codigo],[nombre],[horas_limite],[vendible],[permitir_cambiar]--%>
                <asp:ObjectDataSource ID="ods_estado_lista" runat="server" TypeName="terrasur.estado" SelectMethod="Lista">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Nº contrato:</td>
            <td class="formTdDato">
                <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="6">
                </asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>