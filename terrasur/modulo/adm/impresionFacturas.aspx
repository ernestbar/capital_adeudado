<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void btn_Click(object sender, EventArgs e)
    {
        string _transacciones = IdsTransacciones(txt_num_factura.Text.Trim(), cp_fecha.SelectedDate);
        int num_impresiones = 0;
        cajaFacturaMaestro factura_maestro = new cajaFacturaMaestro();
        factura_maestro.DataSource = cajaReporte.TablaTransaccionFactura(_transacciones, 0);
        factura_maestro.Run();
        if (general.Impersonate_Context(ConfigurationManager.AppSettings["impersonate_user"], "", ConfigurationManager.AppSettings["impersonate_password"]))
        {
            try
            {
                factura_maestro.Document.Printer.PrinterName = rbl_impresoras.SelectedValue;
                factura_maestro.Document.Printer.PrinterSettings.Copies = 1;
                factura_maestro.Document.Print(false, false, false);
                num_impresiones += 1;
            }
            catch { lbl.Visible = false; }
            finally { general.Impersonate_Undo(); }
        }
        lbl.Text = num_impresiones.ToString() + " impresiones realizadas";
        //lbl.Text = _transacciones;
    }
    protected string IdsTransacciones(string NumFacturas, DateTime Fecha)
    {
        string IdsTrans = "";
        string[] NumFact = NumFacturas.Split(',');
        for (int j = 0; j < NumFact.Length; j++)
        {
            int id_fact = factura.IdPorNumeroFecha(int.Parse(rbl_sucursal.SelectedValue), int.Parse(NumFact[j]), Fecha,int.Parse(rbl_negocio.SelectedValue));
            factura f = new factura(id_fact);
            if (f.id_transaccion > 0) IdsTrans += f.id_transaccion.ToString() + ',';
        }
        return IdsTrans.TrimEnd(',');
    }
    
    protected void rbl_sucursal_DataBound(object sender, EventArgs e)
    {
        if (rbl_sucursal.Items.Count > 0)
        {
            rbl_sucursal.SelectedIndex = 0;
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Fecha:</td>
                <td><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
            </tr>
            <tr>
                <td>Facturas:</td>
                <td><asp:TextBox ID="txt_num_factura" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Impresora:</td>
                <td>
                    <asp:RadioButtonList ID="rbl_impresoras" runat="server" DataSourceID="ods_lista_impresoras" DataTextField="nombre" DataValueField="direccion_red" RepeatDirection="Horizontal" RepeatColumns="3"/>
                    <asp:ObjectDataSource ID="ods_lista_impresoras" runat="server" TypeName="terrasur.impresora_usuario" SelectMethod="ListaImpresoraPorUsuario">
                        <SelectParameters>
                            <asp:ProfileParameter Name="Id_usuario" Type="Int32" PropertyName="id_usuario" />
                            <asp:Parameter Name="Factura" Type="Boolean" DefaultValue="True" />
                            <asp:Parameter Name="Recibo" Type="Boolean" DefaultValue="False" />
                            <asp:Parameter Name="Comprobante" Type="Boolean" DefaultValue="False" />
                            <asp:Parameter Name="Solo_activos" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>Negocio:</td>
                <td>
                    <asp:RadioButtonList ID="rbl_negocio" runat="server" DataSourceID="ods_negocio" DataTextField="nombre" DataValueField="id_negocio" CellSpacing="0" CellPadding="0" >
                    </asp:RadioButtonList>
                    <%--[id_sucursal],[nombre]--%>
                    <asp:ObjectDataSource ID="ods_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista" FilterExpression="id_negocio IN (1,3)">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>Sucursal:</td>
                <td>
                    <asp:RadioButtonList ID="rbl_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataTextField="nombre" DataValueField="id_sucursal" CellSpacing="0" CellPadding="0" OnDataBound="rbl_sucursal_DataBound">
                    </asp:RadioButtonList>
                    <%--[id_sucursal],[nombre]--%>
                    <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sucursal" SelectMethod="ListaParaDDL">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="btn" runat="server" Text="Imprimir" OnClick="btn_Click" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="lbl" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
