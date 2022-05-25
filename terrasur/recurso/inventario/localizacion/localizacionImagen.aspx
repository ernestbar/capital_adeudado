<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_localizacion"] == null)
        {
            Page.Visible = false;
        }
        else
        {
            localizacion loc = new localizacion(Int32.Parse(Session["id_localizacion"].ToString()));
            img_imagen.ImageUrl = localizacion.ImagenDireccion(loc.imagen);
            Page.Title = "Vista de Imagen:" + loc.nombre;
            Session.Remove("id_localizacion");
        }

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Imagen</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="img_imagen" runat="server" /></div>
    </form>
</body>
</html>
