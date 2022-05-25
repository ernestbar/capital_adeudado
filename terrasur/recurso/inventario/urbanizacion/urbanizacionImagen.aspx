<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_urbanizacion"] == null)
        {
            Page.Visible = false;
        }
        else
        {
            urbanizacion urb = new urbanizacion(Int32.Parse(Session["id_urbanizacion"].ToString()));
            img_imagen.ImageUrl = urbanizacion.ImagenDireccion(urb.imagen);
            Page.Title = "Vista de Imagen:" + urb.nombre;
            Session.Remove("id_urbanizacion");
        }

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Image ID="img_imagen" runat="server" /></div>
    </div>
    </form>
</body>
</html>
