<%@ Control Language="C#" ClassName="revisionShape" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    protected DataTable tabla_de_lotes_del_sistema(int Id_urbanizacion)
    {
        //[id_lote],[codigo]
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_ListaLotes");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }
    protected DataTable tabla_de_lotes_del_shape(int Id_urbanizacion, int Id_shape)
    {
        
        SharpMap.Data.Providers.ShapeFile sh = new SharpMap.Data.Providers.ShapeFile(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + Id_urbanizacion.ToString() + "shape" + Id_shape.ToString() + ".shp"), true);
        sh.Open();
        DataTable tabla = new DataTable();
        tabla.Columns.Add("id_lote", typeof(int));
        tabla.Columns.Add("codigo", typeof(string));
        for (uint j = 0; j < sh.GetFeatureCount(); j++)
        {
            int id_lote;
            if (sh.GetFeature(j).Table.Columns.IndexOf("ID") >= 0)
            {
                if (int.TryParse(sh.GetFeature(j)["ID"].ToString(), out id_lote) == false)
                    id_lote = 0;
            }
            else id_lote = 0;

            string codigo = "";
            if (sh.GetFeature(j).Table.Columns.IndexOf("codigo") >= 0)
                codigo = sh.GetFeature(j)["codigo"].ToString();

            DataRow fila = tabla.NewRow(); fila["id_lote"] = id_lote; fila["codigo"] = codigo;
            tabla.Rows.Add(fila);
        }
        sh.Close();
        return tabla;
    }

    protected void btn_revisar_Click(object sender, EventArgs e)
    {
        StringBuilder res = new StringBuilder();
        DataTable tabla_sistema = tabla_de_lotes_del_sistema(int.Parse(ddl_urbanizacion.SelectedValue));
        foreach (ListItem item_shape in cbl_shape.Items)
        {
            archivo_shape ashape = new archivo_shape(int.Parse(item_shape.Value));
            if (item_shape.Selected == true && (ashape.guia_datos == true || ashape.guia_lotes == true))
            {
                res.Append("Shape: " + item_shape.Text + " (" + ddl_urbanizacion.SelectedValue + "shape" + item_shape.Value + ".shp)" + "|");
                DataTable tabla_shape = tabla_de_lotes_del_shape(int.Parse(ddl_urbanizacion.SelectedValue), int.Parse(item_shape.Value));

                //se vertifica que todos los lotes del sistema se encuentren en el shape
                StringBuilder si_sistema_no_shape = new StringBuilder();
                foreach (DataRow fila_sistema in tabla_sistema.Rows)
                {
                    bool existe = false;
                    foreach (DataRow fila_shape in tabla_shape.Rows)
                    {
                        if (int.Parse(fila_shape["id_lote"].ToString()) == int.Parse(fila_sistema["id_lote"].ToString()))
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                        si_sistema_no_shape.Append(fila_sistema["codigo"].ToString() + " (" + fila_sistema["id_lote"].ToString() + "),");
                }

                //se vertifica que todos los lotes del shape se encuentren en el sistema
                StringBuilder si_shape_no_sistema = new StringBuilder();
                foreach (DataRow fila_shape in tabla_shape.Rows)
                {
                    bool existe = false;
                    foreach (DataRow fila_sistema in tabla_sistema.Rows)
                    {
                        if (int.Parse(fila_sistema["id_lote"].ToString()) == int.Parse(fila_shape["id_lote"].ToString()))
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                        si_shape_no_sistema.Append(fila_shape["codigo"].ToString() + " (" + fila_shape["id_lote"].ToString() + "),");
                }

                //Lotes sin id, sin código o con código incorrecto en el shape
                StringBuilder lote_sin_id_en_shape = new StringBuilder();
                StringBuilder lote_sin_codigo_en_shape = new StringBuilder();
                StringBuilder lote_codigo_erroneo_en_shape = new StringBuilder();
                StringBuilder lote_id_duplicado_en_shape = new StringBuilder();
                foreach (DataRow fila_shape in tabla_shape.Rows)
                {
                    if (int.Parse(fila_shape["id_lote"].ToString()) == 0)
                        lote_sin_id_en_shape.Append(fila_shape["codigo"].ToString() + " (" + fila_shape["id_lote"].ToString() + "),");
                    else
                    {
                        int num_id_igual = 0;
                        foreach (DataRow fila_shape1 in tabla_shape.Rows)
                        {
                            int id_lote = int.Parse(fila_shape1["id_lote"].ToString());
                            if (id_lote > 0)
                                if (id_lote == int.Parse(fila_shape["id_lote"].ToString()))
                                    num_id_igual += 1;
                        }
                        if (num_id_igual > 1)
                            lote_id_duplicado_en_shape.Append(fila_shape["codigo"].ToString() + " (" + fila_shape["id_lote"].ToString() + "),");
                    }
                    if (fila_shape["codigo"].ToString() == "")
                        lote_sin_codigo_en_shape.Append(fila_shape["codigo"].ToString() + " (" + fila_shape["id_lote"].ToString() + "),");
                    else
                    {
                        foreach (DataRow fila_sistema in tabla_sistema.Rows)
                        {
                            if (int.Parse(fila_sistema["id_lote"].ToString()) == int.Parse(fila_shape["id_lote"].ToString()))
                            {
                                if (fila_sistema["codigo"].ToString() != fila_shape["codigo"].ToString())
                                    lote_codigo_erroneo_en_shape.Append(fila_sistema["codigo"].ToString() + " (" + fila_sistema["id_lote"].ToString() + "),");
                                break;
                            }
                        }
                    }
                }
                if (lote_sin_codigo_en_shape.ToString() != "") { string[] lista = lote_sin_codigo_en_shape.ToString().TrimEnd(',').Split(','); if (tabla_shape.Rows.Count == lista.Length) lote_sin_codigo_en_shape.Remove(0, lote_sin_codigo_en_shape.Length); lote_sin_codigo_en_shape.Append("Todos"); }

                if (si_sistema_no_shape.Length == 0) si_sistema_no_shape.Append("---");
                if (si_shape_no_sistema.Length == 0) si_shape_no_sistema.Append("---");
                if (lote_sin_id_en_shape.Length == 0) lote_sin_id_en_shape.Append("---");
                if (lote_sin_codigo_en_shape.Length == 0) lote_sin_codigo_en_shape.Append("---");
                if (lote_codigo_erroneo_en_shape.Length == 0) lote_codigo_erroneo_en_shape.Append("---");
                if (lote_id_duplicado_en_shape.Length == 0) lote_id_duplicado_en_shape.Append("---");
                
                res.Append("Lotes faltantes en el Shape:" + si_sistema_no_shape.ToString().TrimEnd(',') + "|");
                res.Append("Lotes faltantes en el Sistema:" + si_shape_no_sistema.ToString().TrimEnd(',') + "|");
                res.Append("Lotes sin Id en el Shape:" + lote_sin_id_en_shape.ToString().TrimEnd(',') + "|");
                res.Append("Lotes sin Código en el Shape:" + lote_sin_codigo_en_shape.ToString().TrimEnd(',') + "|");
                res.Append("Lotes con código erroneo en el Shape:" + lote_codigo_erroneo_en_shape.ToString().TrimEnd(',') + "|");
                res.Append("Lotes con Id duplicado en el Shape:" + lote_id_duplicado_en_shape.ToString().TrimEnd(',') + "|");
            }
        }
        lbl_resultado.Text = "<table border=1><tr><td>" + res.ToString().TrimEnd('|').Replace("|", "</td></tr><tr><td>").Replace(":",":</td><td>") + "</td></tr></table>";
    }

    protected void cbl_shape_DataBound(object sender, EventArgs e)
    {
        foreach (ListItem item in cbl_shape.Items) item.Selected = true;
    }

    protected void ddl_urbanizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_resultado.Text = "";
    }
</script>
<table align="center">
    <tr>
        <td class="formTdTitle" colspan="2" style="padding:2px 10px;">Verificación de consistencia de archivos Shape</td>
    </tr>
    <tr>
        <td class="formTdEnun">Sector:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre" DataValueField="id_urbanizacion" OnSelectedIndexChanged="ddl_urbanizacion_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_urbanizacion" runat="server" ControlToValidate="ddl_urbanizacion" Display="Dynamic" Text="*" ValidationGroup="revision"></asp:RequiredFieldValidator>
            <%--[id_urbanizacion],[nombre]--%>
            <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.archivo_shape" SelectMethod="ListaUrbanizacionConPlanimetria">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Archivos Shape:</td>
        <td class="formTdDato">
            <asp:CheckBoxList ID="cbl_shape" runat="server" DataSourceID="ods_lista_archivos" DataTextField="nombre" DataValueField="id_archivo" OnDataBound="cbl_shape_DataBound">
            </asp:CheckBoxList>
            <%--[id_archivo],[nombre],[shp],[dbf],[shx],[guia_datos],[guia_lotes],[fecha],[nombre_usuario]--%>
            <asp:ObjectDataSource ID="ods_lista_archivos" runat="server" TypeName="terrasur.archivo_shape" SelectMethod="ListaArchivosPorUrbanizacion">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="btn_revisar" runat="server" Text="Verificar consistencia" CausesValidation="true" ValidationGroup="revision" OnClick="btn_revisar_Click" />
        </td>
    </tr>
</table>
<table align="center">
    <tr><td align="left"><asp:Label ID="lbl_resultado_enun" runat="server" SkinID="lblEnun" Text="Resultados de la revisión:"></asp:Label></td></tr>
    <tr>
        <td align="left">
            <asp:Label ID="lbl_resultado" runat="server"></asp:Label>
        </td>
    </tr>
</table>
