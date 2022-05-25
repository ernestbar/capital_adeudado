<%@ Page Language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub lb_modulo_marketing_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/modulo/marketing/Default.aspx")
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TERRASUR</title> 
    <link rel="shortcut icon" href="favicon.ico"/>
</head>
<body class="masterBody">
    <form id="form1" runat="server">
    <div>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Image ID="image1" runat="server" ImageUrl="~/images/bannerTerrasur.jpg" />
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td class="tdEnun" valign="top" style="padding-top:5px"></td>
                        <td>
                            <asp:LinkButton ID="lb_modulo_marketing" runat="server" Width="300px" Height="38px" SkinID="lbNombreModulo" Text="Marketing" OnClick="lb_modulo_marketing_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
