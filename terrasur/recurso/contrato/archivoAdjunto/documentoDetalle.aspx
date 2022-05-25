<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["id_documento"] != null)
            {

                adj_documento dObj = new adj_documento(int.Parse(Session["id_documento"].ToString()));
                lbl_documento.Text = "Documento: " + dObj.nombre + " (contrato: " + dObj.num_contrato + ")";
                Page.Title = "Documento: " + dObj.nombre + " (contrato: " + dObj.num_contrato + ")";
                if (dObj.num_archivos == 1) { lbl_archivo.Text = dObj.num_archivos.ToString() + " archivo"; }
                else { lbl_archivo.Text = dObj.num_archivos.ToString() + " archivo(s)"; }

                adj_ingreso.Insertar(dObj.id_documento, Profile.id_usuario);

                panel_archivo.Visible = false;
                lbl_id_documento.Text = Session["id_documento"].ToString();
                dl_archivo.Visible = true;
                dl_archivo.DataBind();

                Session.Remove("id_documento");
            }
            else if (Session["id_archivo"] != null)
            {
                adj_archivo aObj = new adj_archivo(int.Parse(Session["id_archivo"].ToString()));
                aObj.RecuperarDatos();
                lbl_documento.Text = "Documento: " + aObj.documento_nombre + " (contrato: " + aObj.num_contrato + ")";
                Page.Title = "Documento: " + aObj.documento_nombre + " (contrato: " + aObj.num_contrato + ")";
                lbl_archivo.Text = "Archivo: " + aObj.nombre;

                panel_archivo.Visible = true;
                dl_archivo.Visible = false;

                panel_archivo.GroupingText = "Archivo: " + aObj.nombre;
                img_archivo.ImageUrl = ConfigurationManager.AppSettings["adjunto_dir_imagen"] + aObj.codigo;

                Session.Remove("id_archivo");
            }
        }
    }

    protected void dl_archivo_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((Panel)e.Item.FindControl("panel_archivo1")).GroupingText = "Archivo: " + DataBinder.Eval(e.Item.DataItem, "nombre").ToString();
            ((Image)e.Item.FindControl("img_archivo1")).ImageUrl = ConfigurationManager.AppSettings["adjunto_dir_imagen"] + DataBinder.Eval(e.Item.DataItem, "codigo").ToString();
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_id_documento" runat="server" Text="0" Visible="false"></asp:Label>
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_documento" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_archivo" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="Larger"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="panel_archivo" runat="server" Width="800" Height="500" ScrollBars="Both">
                        <asp:Image ID="img_archivo" runat="server" />
                    </asp:Panel>
                    <asp:DataList ID="dl_archivo" runat="server" RepeatLayout="Table" RepeatColumns="1" RepeatDirection="Vertical" DataSourceID="ods_lista_archivos" OnItemDataBound="dl_archivo_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel ID="panel_archivo1" runat="server" Width="800" Height="500" ScrollBars="Both">
                                <asp:Image ID="img_archivo1" runat="server" />
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:DataList>
                    <%--[id_archivo],[fecha],[codigo],[nombre],[usuario]--%>
                    <asp:ObjectDataSource ID="ods_lista_archivos" runat="server" TypeName="terrasur.adj_archivo" SelectMethod="Lista">
                        <SelectParameters>
                            <asp:ControlParameter Name="Id_documento" Type="Int32" ControlID="lbl_id_documento" PropertyName="Text" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
