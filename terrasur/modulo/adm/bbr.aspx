<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
            DbCommand cmd = db1.GetStoredProcCommand("lote_TransferirBBR");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.ExecuteNonQuery(cmd);
            lbl.Text = "Los lotes y contratos se transfirieron correctamente";
        }
        catch { lbl.Text = "Los lotes y contratos NO se transfirieron correctamente"; }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn" runat="server" Text="Transferir lotes y contratos a BBR" OnClick="btn_Click" />
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
