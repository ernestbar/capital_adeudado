<%@ Control Language="C#" ClassName="cajaImpresionNueva" %>

<script runat="server"> 
    
    public Button btn_imprimir_1 {get { return btn_imprimir; } set {btn_imprimir = value;}}
    public RadioButtonList rbl_impresoras_1 { get { return rbl_impresoras; } set { rbl_impresoras = value; } }
    public WebViewer wv_documento_1 { get { return wv_documento; } set { wv_documento = value; } }

    protected string _transacciones { get { return lbl_transacciones.Text; } set { lbl_transacciones.Text = value; } }

    protected bool _reimpresion { get { return bool.Parse(lbl_reimpresion.Text); } set { lbl_reimpresion.Text = value.ToString(); } }
    protected string _tipo_documento { get { return lbl_tipo_documento.Text; } set { lbl_tipo_documento.Text = value; } }
    protected int _id_documento { get { return int.Parse(lbl_id_documento.Text); } set { lbl_id_documento.Text = value.ToString(); } }
    

    /*
    //No es necesario verificar el tipo de documento porque ahora no se imprime uno a uno sino toda la transacción
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
    */

    public void MostrarDocumento(string tipo_documento, string transacciones, bool reimpresion, int Id_documento, Unit ancho, Unit alto)
    {
        _transacciones = transacciones;

        _reimpresion = reimpresion;
        _tipo_documento = tipo_documento;
        _id_documento = Id_documento;

        rbl_impresoras.DataBind();

        if (_reimpresion == true)
        {
            if (_tipo_documento == "")
            {
                cajaTransaccionDocumentos reporteDocumentos = new cajaTransaccionDocumentos();
                wv_documento.Visible = true;
                reporteDocumentos.CargarDatos(Profile.id_usuario, _reimpresion);
                reporteDocumentos.DataSource = transaccionReporte.ReporteDocumentos(
                    DateTime.Now.Date, DateTime.Now.Date, 0, _transacciones
                    , 0, 0, 0, true
                    );
                wv_documento.Report = reporteDocumentos;
            }
            else
            {
                int _Id_factura = 0; int _Id_recibo = 0; int _Id_comprobantedpr = 0; if (_tipo_documento == "Factura") { _Id_factura = _id_documento; } else if (_tipo_documento == "Recibo") { _Id_recibo = _id_documento; } else if (_tipo_documento == "Comprobante") { _Id_comprobantedpr = _id_documento; }
                int _Id_transaccion = 0; string _Id_transacciones = ""; if (int.TryParse(_transacciones, out _Id_transaccion) == true) { _Id_transacciones = ""; } else { _Id_transaccion = 0; _Id_transacciones = _transacciones; }
                
                cajaTransaccionReimpresionUnDoc reporteReimpresionDocumento = new cajaTransaccionReimpresionUnDoc();
                wv_documento.Visible = true;
                reporteReimpresionDocumento.CargarDatos(Profile.id_usuario, _reimpresion, _tipo_documento);
                reporteReimpresionDocumento.DataSource = transaccionReporte.ReporteDocumentos(
                    DateTime.Parse("01/01/1990"), DateTime.Parse("01/01/2050"), _Id_transaccion, _Id_transacciones
                    , _Id_factura, _Id_recibo, _Id_comprobantedpr, false
                    );
                wv_documento.Report = reporteReimpresionDocumento;
            }
            wv_documento.Width = ancho;
            wv_documento.Height = alto;
        }
    }                                                                                                                                                                                                                                                                                   

    protected void btn_imprimir_Click(object sender, EventArgs e)
    {
        lbl_enviado.Visible = true;

        Profile.seleccion_impresora.transaccion = rbl_impresoras.SelectedValue;

        string _PrinterDir = rbl_impresoras.SelectedValue; string _PrinterName = ""; int _NumBandeja = 0;
        if (_PrinterDir.Contains("|")) { _PrinterName = _PrinterDir.Split('|')[0]; _NumBandeja = int.Parse(_PrinterDir.Split('|')[1]); }
        else { _PrinterName = _PrinterDir; _NumBandeja = 0; }

        if (_tipo_documento == "")
        {
            System.Data.DataTable tabla_datos1 = transaccionReporte.ReporteDocumentos(
                DateTime.Now.Date, DateTime.Now.Date, 0, _transacciones
                , 0, 0, 0, true
                );

            if (tabla_datos1.Rows.Count > 0)
            {
                cajaTransaccionDocumentos reporteTrans = new cajaTransaccionDocumentos();
                reporteTrans.CargarDatos(Profile.id_usuario, _reimpresion);
                reporteTrans.DataSource = tabla_datos1;
                reporteTrans.Run();
                try
                {
                    reporteTrans.Document.Printer.PrinterName = _PrinterName;
                    reporteTrans.Document.Printer.PrinterSettings.Copies = 1;
                    reporteTrans.Document.Printer.DefaultPageSettings.PaperSource = reporteTrans.Document.Printer.PrinterSettings.PaperSources[_NumBandeja];
                    System.Drawing.Printing.PaperSize PaperSizeLetter = new System.Drawing.Printing.PaperSize("TransaccionCarta", 850, 1100);
                    reporteTrans.Document.Printer.DefaultPageSettings.PaperSize = PaperSizeLetter;
                    reporteTrans.Document.Print(false, false, false);
                    transaccion_impresion.Registrar(0, _transacciones, 0, 0, 0, 0, Profile.id_usuario, rbl_impresoras.SelectedItem.Text, rbl_impresoras.SelectedItem.Value);
                }
                catch { lbl_enviado.Visible = false; }
                
                lbl_sin_impresion.Visible = false;
            }
            else { lbl_sin_impresion.Visible = true; }
        }
        else
        {
            int _Id_factura = 0; int _Id_recibo = 0; int _Id_comprobantedpr = 0; if (_tipo_documento == "Factura") { _Id_factura = _id_documento; } else if (_tipo_documento == "Recibo") { _Id_recibo = _id_documento; } else if (_tipo_documento == "Comprobante") { _Id_comprobantedpr = _id_documento; }
            int _Id_transaccion = 0; string _Id_transacciones = ""; if (int.TryParse(_transacciones, out _Id_transaccion) == true) { _Id_transacciones = ""; } else { _Id_transaccion = 0; _Id_transacciones = _transacciones; }

            System.Data.DataTable tabla_datos2 = transaccionReporte.ReporteDocumentos(
                DateTime.Parse("01/01/1990"), DateTime.Parse("01/01/2050"), _Id_transaccion, _Id_transacciones
                , _Id_factura, _Id_recibo, _Id_comprobantedpr, false
                );

            if (tabla_datos2.Rows.Count > 0)
            {
                cajaTransaccionReimpresionUnDoc reporteReimpUnDoc = new cajaTransaccionReimpresionUnDoc();
                reporteReimpUnDoc.CargarDatos(Profile.id_usuario, _reimpresion, _tipo_documento);
                reporteReimpUnDoc.DataSource = tabla_datos2;
                reporteReimpUnDoc.Run();
                try
                {
                    reporteReimpUnDoc.Document.Printer.PrinterName = _PrinterName;
                    reporteReimpUnDoc.Document.Printer.PrinterSettings.Copies = 1;
                    reporteReimpUnDoc.Document.Printer.DefaultPageSettings.PaperSource = reporteReimpUnDoc.Document.Printer.PrinterSettings.PaperSources[_NumBandeja];
                    System.Drawing.Printing.PaperSize PaperSizeLetterUnDoc = new System.Drawing.Printing.PaperSize("TransaccionCarta", 850, 1100);
                    reporteReimpUnDoc.Document.Printer.DefaultPageSettings.PaperSize = PaperSizeLetterUnDoc;
                    reporteReimpUnDoc.Document.Print(false, false, false);
                    transaccion_impresion.Registrar(_Id_transaccion, _Id_transacciones, _Id_factura, _Id_recibo, _Id_comprobantedpr, 0, Profile.id_usuario, rbl_impresoras.SelectedItem.Text, rbl_impresoras.SelectedItem.Value);
                }
                catch { lbl_enviado.Visible = false; }
                
                lbl_sin_impresion.Visible = false;
            }
            else { lbl_sin_impresion.Visible = true; }
        }
        
        //Para el detalle se debe considerar la reimpresión de: solo la factura, solo el recibo o solo el comprobante
        //_reimpresion,  _tipo_documento,  _id_documento

        /*if (general.Impersonate_Context(ConfigurationManager.AppSettings["impersonate_user"], "", ConfigurationManager.AppSettings["impersonate_password"]))
        {
        finally { general.Impersonate_Undo(); }
        }*/
    }

    protected void rbl_impresoras_DataBound(object sender, EventArgs e)
    {
        lbl_enviado.Visible = false;
        btn_imprimir.Visible = rbl_impresoras.Items.Count.Equals(0).Equals(false);
        if (rbl_impresoras.Items.Count > 0)
        {
            if (rbl_impresoras.Items.FindByValue(Profile.seleccion_impresora.transaccion) != null)
            {
                try { rbl_impresoras.SelectedValue = Profile.seleccion_impresora.transaccion; }
                catch { }
            }
            else { rbl_impresoras.SelectedIndex = 0; }
        }
    }

    protected void btn_cargar_impresoras_Click(object sender, ImageClickEventArgs e)
    {
        rbl_impresoras.DataBind();
    }
</script>
<asp:Label ID="lbl_transacciones" runat="server" Text="0" Visible="false"/>

<asp:Label ID="lbl_reimpresion" runat="server" Text="false" Visible="false"/>
<asp:Label id="lbl_tipo_documento" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_documento" runat="server" Text="true" Visible="false"></asp:Label>

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
            <asp:Label ID="lbl_sin_impresion" runat="server" Visible="false" Text="La impresión NO se envió correctamente, COMUNÍQUESE CON EL ADMINISTRADOR" Font-Size="Medium" Font-Bold="true" ForeColor="Red" Font-Names="Arial"></asp:Label>
            <ActiveReportsWeb:WebViewer ID="wv_documento" runat="server" Height="200" Width="300" ViewerType="HtmlViewer" Visible="false">
            </ActiveReportsWeb:WebViewer>
            <%--<ActiveReportsWeb:WebViewer ID="wv_documento" runat="server" Height="200" Width="300" ViewerType="AcrobatReader" Visible="false">
            </ActiveReportsWeb:WebViewer>--%>
        </td>
    </tr>
</table>
<%--[id_impresora],[nombre],[direccion_red],[activo]--%>
<asp:ObjectDataSource ID="ods_lista_impresoras" runat="server" TypeName="terrasur.impresora_usuario" SelectMethod="ListaImpresoraPorUsuario2">
    <SelectParameters>
        <asp:ProfileParameter Name="Id_usuario" Type="Int32" PropertyName="id_usuario" />
        <asp:Parameter Name="Solo_activos" Type="Boolean" DefaultValue="true" />
    </SelectParameters>
</asp:ObjectDataSource>


