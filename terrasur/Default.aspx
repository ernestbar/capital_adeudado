<%@ Page Language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Page.IsPostBack = False Then
            If Request.UserHostAddress = "192.168.14.200" Then
                Response.Redirect("~/marketing.aspx")
            End If
        End If
    End Sub

    'Protected Sub r_modulo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles r_modulo.ItemCommand
    '    If e.CommandName = "ingresar_modulo" Then
    '        FormsAuthentication.SignOut()
    '        Response.Redirect("~/modulo/" & e.CommandArgument & "/Default.aspx")
    '    End If
    'End Sub

    Protected Sub dl_modulo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dl_modulo.ItemCommand
        If e.CommandName = "ingresar_modulo" Then
            FormsAuthentication.SignOut()
            Response.Redirect("~/modulo/" & e.CommandArgument & "/Default.aspx")
            'If Integer.Parse(ConfigurationManager.AppSettings("num_sucursal")) > 0 Then
            '    Response.Redirect("~/modulo/" & e.CommandArgument & "/Default.aspx")
            'Else
            '    If e.CommandArgument = "caja" Or e.CommandArgument = "adm" Then
            '        Response.Redirect("http://172.16.1.5/terrasur/modulo/" & e.CommandArgument & "/Default.aspx")
            '    Else
            '        Response.Redirect("~/modulo/" & e.CommandArgument & "/Default.aspx")
            '        'Response.Redirect("http://servidor2/terrasur/modulo/" & e.CommandArgument & "/Default.aspx")
            '    End If
            'End If
        End If
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
                <%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" width="960" height="125">
                  <param name="movie" value="terrasur.swf" />
                  <param name="quality" value="high" />
                  <param name="allowScriptAccess" value="always" />
                  <param name="wmode" value="transparent">
                     <embed src="terrasur.swf" quality="high" type="application/x-shockwave-flash"
                      WMODE="transparent" width="960" height="125" pluginspage="http://www.macromedia.com/go/getflashplayer" allowScriptAccess="always" />
                </object>--%>
                <asp:Image ID="image1" runat="server" ImageUrl="~/images/bannerTerrasur.jpg" />
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td class="tdEnun" valign="top" style="padding-top:5px"><%--M?dulos del Sistema:--%></td>
                        <td>
                            <%--<asp:Repeater ID="r_modulo" runat="server" DataSourceID="ods_lista_modulo">
                                <HeaderTemplate><table align="center"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:LinkButton ID="lb_modulo" runat="server" SkinID="lbNombreModulo" Text='<%# Eval("nombre") %>' CommandName="ingresar_modulo" CommandArgument='<%# Eval("codigo") %>'></asp:LinkButton></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>--%>
                            <asp:DataList ID="dl_modulo" runat="server" DataSourceID="ods_lista_modulo" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="3" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_modulo" runat="server" Width="300px" Height="38px" SkinID="lbNombreModulo" Text='<%# Eval("nombre") %>' CommandName="ingresar_modulo" CommandArgument='<%# Eval("codigo") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:ObjectDataSource ID="ods_lista_modulo" runat="server" TypeName="terrasur.modulo" SelectMethod="Lista"></asp:ObjectDataSource>
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
