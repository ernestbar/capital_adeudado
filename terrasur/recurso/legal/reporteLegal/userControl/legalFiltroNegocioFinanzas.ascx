<%@ Control Language="C#" ClassName="legalFiltroNegocioFinanzas" %>

<script runat="server">
public string id_negocio
{
    get
    {
        StringBuilder str = new StringBuilder();
        foreach (ListItem item in cbl_negocio.Items) { if (item.Selected == true) str.Append(item.Value + ","); }
        if (str.ToString() != "") return "," + str.ToString().TrimEnd(',') + ",";
        else return "";
    }
}

public string string_negocio
{
    get
    {
        StringBuilder str = new StringBuilder();
        int num_elegidos = 0;
        foreach (ListItem item in cbl_negocio.Items)
        {
            if (item.Selected == true)
            {
                str.Append(item.Text + ", ");
                num_elegidos += 1;
            }
        }
        if (num_elegidos == cbl_negocio.Items.Count) return "Todos";
        else if (num_elegidos == 0) return "Ninguno";
        else return str.ToString().Trim().TrimEnd(',');
    }
}

public void Reset()
{
    cbl_negocio.DataBind();
}

protected void cbl_negocio_DataBound(object sender, EventArgs e)
{
    negocio nObj = new negocio("bbr");
    string casas_edif = ConfigurationManager.AppSettings["negocios_casas"];
    foreach (ListItem item in cbl_negocio.Items)
    {
        item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(false);
        if (item.Value == nObj.id_negocio.ToString()) item.Text = "BBR";
    }
}
</script>
<asp:Panel ID="panel_finanzas_negocio" runat="server" GroupingText="Negocio (para el dpto. Finanzas - Sistema de Cartera)">
    <table class="formTable" cellpadding="0" cellspacing="0" align="left">
        <tr>
            <td class="formTdEnun">Negocio:</td>
            <td class="formTdDato">
                <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="cbl_negocio_DataBound" RepeatColumns="5" RepeatLayout="Flow"></asp:CheckBoxList>
                <%--[id_negocio],[codigo],[nombre],[origen]--%>
                <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>