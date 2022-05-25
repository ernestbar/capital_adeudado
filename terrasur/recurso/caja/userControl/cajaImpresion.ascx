<%@ Control Language="C#" ClassName="cajaImpresion" %>

<script runat="server"> 
    
    public Button btn_imprimir_1 {get { return btn_imprimir; } set {btn_imprimir = value;}}
    public RadioButtonList rbl_impresoras_1 { get { return rbl_impresoras; } set { rbl_impresoras = value; } }
    public WebViewer wv_documento_1 { get { return wv_documento; } set { wv_documento = value; } }

    protected string _tipo_documento { get { return lbl_tipo_documento.Text; } set { lbl_tipo_documento.Text = value; } }
    protected string _transacciones { get { return lbl_transacciones.Text; } set { lbl_transacciones.Text = value; } }
    protected bool _reimpresion { get { return bool.Parse(lbl_reimpresion.Text); } set { lbl_reimpresion.Text = value.ToString(); } }

    protected bool _factura { get { return bool.Parse(lbl_factura.Text); } set { lbl_factura.Text = value.ToString(); } }
    protected int _id_documento { get { return int.Parse(lbl_id_documento.Text); } set { lbl_id_documento.Text = value.ToString(); } }
    protected bool _recibo { get { return bool.Parse(lbl_recibo.Text); } set { lbl_recibo.Text = value.ToString(); } }
    protected bool _comprobante { get { return bool.Parse(lbl_comprobante.Text); } set { lbl_comprobante.Text = value.ToString(); } }
    

    public bool VerificarDocumento(string tipo_documento, string transacciones)
    {
        switch (tipo_documento)
        {
            case "Factura":
                if (cajaReporte.TablaTransaccionFactura(transacciones, 0).Rows.Count > 0) { return true; } else { return false; }
            case "Recibo":
                if (cajaReporte.TablaTransaccionRecibo(transacciones, 0).Rows.Count > 0) { return true; } else { return false; }
            case "Comprobante":
                if (cajaReporte.TablaTransaccionComprobante(transacciones, 0).Rows.Count > 0) { return true; } else { return false; }
            default:
                return false;
        }
    }

    public void MostrarDocumento(string tipo_documento, string transacciones, bool reimpresion,int Id_documento, Unit ancho, Unit alto)
    {
        _tipo_documento = tipo_documento;
        _transacciones = transacciones;
        _reimpresion = reimpresion;
        _id_documento = Id_documento;
        switch (_tipo_documento)
        {
            case "Factura": 
                _factura = true; _recibo = false; _comprobante = false; 
                rbl_impresoras.DataBind();
                break;
            case "Recibo":
                _factura = false; _recibo = true; _comprobante = false;
                rbl_impresoras.DataBind();
                break;
            case "Comprobante":
                _factura = false; _recibo = false; _comprobante = true;
                rbl_impresoras.DataBind();
                break;
            default:
                break;
        }

        if (_reimpresion == true)
        {
            switch (_tipo_documento)
            {
                case "Factura":
                    cajaFacturaMaestro factura_maestro = new cajaFacturaMaestro();
                    wv_documento.Visible = true;
                    factura_maestro.DataSource = cajaReporte.TablaTransaccionFactura(transacciones, _id_documento);
                    factura_maestro.textBox22.Visible = _reimpresion;
                    wv_documento.Report = factura_maestro;
                    break;
                case "Recibo":
                    cajaReciboMaestro recibo_maestro = new cajaReciboMaestro();
                    wv_documento.Visible = true;
                    recibo_maestro.DataSource = cajaReporte.TablaTransaccionRecibo(transacciones, _id_documento);
                    recibo_maestro.textBox38.Visible = _reimpresion;
                    wv_documento.Report = recibo_maestro;
                    break;
                case "Comprobante":
                    cajaComprobanteDprMaestro comprobante_maestro = new cajaComprobanteDprMaestro();
                    wv_documento.Visible = true;
                    comprobante_maestro.DataSource = cajaReporte.TablaTransaccionComprobante(transacciones, _id_documento);
                    comprobante_maestro.textBox38.Visible = _reimpresion;
                    wv_documento.Report = comprobante_maestro;
                    break;
                default:
                    break;
            }
            wv_documento.Width = ancho;
            wv_documento.Height = alto;
        }
    }

    protected void btn_imprimir_Click(object sender, EventArgs e)
    {
        //if (general.Impersonate_Context(ConfigurationManager.AppSettings["impersonate_user"], "", ConfigurationManager.AppSettings["impersonate_password"]))
        //{
        //    try
        //    {
        lbl_enviado.Visible = true;
        switch (_tipo_documento)
        {
            case "Factura":
                Profile.seleccion_impresora.factura = rbl_impresoras.SelectedValue;
                cajaFacturaMaestro factura_maestro = new cajaFacturaMaestro();
                if (_reimpresion == true)
                    factura_maestro.DataSource = cajaReporte.TablaTransaccionFactura(_transacciones, _id_documento);
                else
                    factura_maestro.DataSource = cajaReporte.TablaTransaccionFactura(_transacciones, 0);
                factura_maestro.textBox22.Visible = _reimpresion;
                factura_maestro.Run();
                if (general.Impersonate_Context(ConfigurationManager.AppSettings["impersonate_user"], "", ConfigurationManager.AppSettings["impersonate_password"]))
                {
                    try
                    {
                        factura_maestro.Document.Printer.PrinterName = rbl_impresoras.SelectedValue;
                        factura_maestro.Document.Printer.PrinterSettings.Copies = 1;
                        factura_maestro.Document.Print(false, false, false);
                    }
                    catch { lbl_enviado.Visible = false; }
                    finally { general.Impersonate_Undo(); }
                }
                break;
            case "Recibo":
                Profile.seleccion_impresora.recibo = rbl_impresoras.SelectedValue;
                cajaReciboMaestro recibo_maestro = new cajaReciboMaestro();
                if (_reimpresion == true)
                    recibo_maestro.DataSource = cajaReporte.TablaTransaccionRecibo(_transacciones, _id_documento);
                else
                    recibo_maestro.DataSource = cajaReporte.TablaTransaccionRecibo(_transacciones, 0);
                
                recibo_maestro.textBox38.Visible = _reimpresion;
                recibo_maestro.Run();
                if (general.Impersonate_Context(ConfigurationManager.AppSettings["impersonate_user"], "", ConfigurationManager.AppSettings["impersonate_password"]))
                {
                    try
                    {
                        recibo_maestro.Document.Printer.PrinterName = rbl_impresoras.SelectedValue;
                        recibo_maestro.Document.Printer.PrinterSettings.Copies = 1;
                        recibo_maestro.Document.Print(false, false, false);
                    }
                    catch { lbl_enviado.Visible = false; }
                    finally { general.Impersonate_Undo(); }
                }
                break;
            case "Comprobante":
                Profile.seleccion_impresora.comprobante = rbl_impresoras.SelectedValue;
                cajaComprobanteDprMaestro comprobante_maestro = new cajaComprobanteDprMaestro();
                if (_reimpresion == true)
                    comprobante_maestro.DataSource = cajaReporte.TablaTransaccionComprobante(_transacciones, _id_documento);
                else
                    comprobante_maestro.DataSource = cajaReporte.TablaTransaccionComprobante(_transacciones, 0);
                
                comprobante_maestro.textBox38.Visible = _reimpresion;
                comprobante_maestro.Run();
                if (general.Impersonate_Context(ConfigurationManager.AppSettings["impersonate_user"], "", ConfigurationManager.AppSettings["impersonate_password"]))
                {
                    try
                    {
                        comprobante_maestro.Document.Printer.PrinterName = rbl_impresoras.SelectedValue;
                        comprobante_maestro.Document.Printer.PrinterSettings.Copies = 1;
                        comprobante_maestro.Document.Print(false, false, false);
                    }
                    catch { lbl_enviado.Visible = false; }
                    finally { general.Impersonate_Undo(); }
                }
                break;
            default:
                break;
        }
        //    }
        //    catch { lbl_enviado.Visible = false; }
        //    finally { general.Impersonate_Undo(); }
        //}
    }

    protected void rbl_impresoras_DataBound(object sender, EventArgs e)
    {
        lbl_enviado.Visible = false;
        btn_imprimir.Visible = rbl_impresoras.Items.Count.Equals(0).Equals(false);
        if (rbl_impresoras.Items.Count > 0)
        {
            switch (_tipo_documento)
            {
                case "Factura":
                    if (rbl_impresoras.Items.FindByValue(Profile.seleccion_impresora.factura) != null)
                    {
                        try { rbl_impresoras.SelectedValue = Profile.seleccion_impresora.factura; }
                        catch { }
                    }
                    else rbl_impresoras.SelectedIndex = 0;
                    break;
                case "Recibo":
                    if (rbl_impresoras.Items.FindByValue(Profile.seleccion_impresora.recibo) != null)
                    {
                        try { rbl_impresoras.SelectedValue = Profile.seleccion_impresora.recibo; }
                        catch { }
                    }
                    else rbl_impresoras.SelectedIndex = 0;
                    break;
                case "Comprobante":
                    if (rbl_impresoras.Items.FindByValue(Profile.seleccion_impresora.comprobante) != null)
                    {
                        try { rbl_impresoras.SelectedValue = Profile.seleccion_impresora.comprobante; }
                        catch { }
                    }
                    else rbl_impresoras.SelectedIndex = 0;
                    break;
                default:
                    rbl_impresoras.SelectedIndex = 0;
                    break;
            }
        }
    }

    protected void btn_cargar_impresoras_Click(object sender, ImageClickEventArgs e)
    {
        rbl_impresoras.DataBind();
    }
</script>
<asp:Label id="lbl_tipo_documento" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lbl_transacciones" runat="server" Text="0" Visible="false"/>
<asp:Label ID="lbl_reimpresion" runat="server" Text="false" Visible="false"/>

<asp:Label ID="lbl_factura" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_documento" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_recibo" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_comprobante" runat="server" Text="true" Visible="false"></asp:Label>

<table width="100%">
    <tr>
        <td align="right">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rbl_impresoras" EventName="DataBound" />
                </Triggers>
                <ContentTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left"><asp:Label ID="lbl_enviado" runat="server" Text="Imprimiendo..." SkinID="lbl_CajaIngresoPermitido"></asp:Label></td>
                            <td align="right"><asp:Button ID="btn_imprimir" runat="server" Text="Imprimir" SkinID="cajaImprimirButton" CausesValidation="false"  OnClick="btn_imprimir_Click" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel runat="server" ID="panel_impresoras" GroupingText="Impresoras Habilitadas">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" valign="bottom" width="20px">
                            <asp:ImageButton ID="btn_cargar_impresoras" runat="server" ImageUrl="~/images/update.gif" ToolTip="Cargar la lista de impresoras" OnClick="btn_cargar_impresoras_Click" />
                        </td>
                        <td>
                            <table align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <Triggers><asp:AsyncPostBackTrigger ControlID="btn_cargar_impresoras" EventName="Click" /></Triggers>
                                            <ContentTemplate>
                                        <asp:RadioButtonList ID="rbl_impresoras" runat="server" DataSourceID="ods_lista_impresoras" DataTextField="nombre" DataValueField="direccion_red" RepeatDirection="Horizontal" RepeatColumns="3" OnDataBound="rbl_impresoras_DataBound" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left">
            <ActiveReportsWeb:WebViewer ID="wv_documento" runat="server" Height="200" Width="300" ViewerType="HtmlViewer" Visible="false">
            </ActiveReportsWeb:WebViewer>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="ods_lista_impresoras" runat="server" TypeName="terrasur.impresora_usuario" SelectMethod="ListaImpresoraPorUsuario">
    <SelectParameters>
        <asp:ProfileParameter Name="Id_usuario" Type="Int32" PropertyName="id_usuario" />
        <asp:ControlParameter Name="Factura" Type="Boolean" ControlID="lbl_factura" PropertyName="Text" />
        <asp:ControlParameter Name="Recibo" Type="Boolean" ControlID="lbl_recibo" PropertyName="Text" />
        <asp:ControlParameter Name="Comprobante" Type="Boolean" ControlID="lbl_comprobante" PropertyName="Text" />
        <asp:Parameter Name="Solo_activos" Type="Boolean" DefaultValue="true" />
    </SelectParameters>
</asp:ObjectDataSource>


