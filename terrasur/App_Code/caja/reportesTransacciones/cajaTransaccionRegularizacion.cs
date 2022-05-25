using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;      
   
/// <summary>
/// Summary description for cajaTransaccionRegularizacion.
/// </summary>
/// 
namespace terrasur
{
    public class cajaTransaccionRegularizacion : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Shape shape1;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private SubReport subReport1;
        private SubReport subReport2;
        private TextBox textBox12;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox27;
        private TextBox textBox28;
        private Line line1;
        private Line line2;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox11;
        public TextBox textBox38;
        private TextBox textBox39;
        private TextBox textBox40;
        private TextBox textBox41;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox textBox44;
        private TextBox textBox17;
        private TextBox textBox26;
        private TextBox textBox35;
        private SubReport subReport3;
        private SubReport subReport4;
        private Line line5;
        private Line line3;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionRegularizacion()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void cajaTransaccionRegularizacion_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("ReciboRegularizacion", 850, 1100);
            this.PageSettings.Margins.Top = 0.0F;
            this.PageSettings.Margins.Bottom = 0.0F;
            this.PageSettings.Margins.Right = 0.0F;
            this.PageSettings.Margins.Left = 0.0F;

            //ESTILOS
            
            EstilosBase rpt = new EstilosBase();
            string filepath = HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBaseRecibo.rpx";
            rpt.LoadLayout(filepath);
            for (int i = 4; i < rpt.StyleSheet.Count; i++)
            {
                DataDynamics.ActiveReports.Style s = rpt.StyleSheet[i];
                this.StyleSheet.Add(s.Name);
                if (s.Value != null)
                {
                    this.StyleSheet[i].Value = s.Value;
                }
            }
            CargarEstilos();
        }

        private void cajaTransaccionRegularizacion_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
            recibo_regularizacion rObj = new recibo_regularizacion(Convert.ToInt32(Fields["id_reciboregularizacion"].Value));
            string codigo_moneda = contrato.CodigoMoneda(rObj.id_contrato);
            //ENCABEZADO
            textBox39.Text = "TERRASUR LTDA.";
            textBox40.Text = "ACT.INMOBILIARIA";
            textBox41.Text = "CASA MATRIZ";
            textBox42.Text = "C. Belisario Salinas Nº 525 - Sopocachi";
            textBox43.Text = "Teléfono: 2423034";
            textBox44.Text = "La Paz - Bolivia";
            
            //Sucursales:
            textBox26.Text = "Oficina Central";

            textBox5.Text = codigo_moneda + ":";
            textBox7.Text = rObj.monto_sus.ToString("F2");
            textBox10.Text = rObj.fecha.ToString("D");
            textBox8.Text = new tipo_cambio(tipo_cambio.Anterior(rObj.fecha)).compra.ToString("F2");
            textBox4.Text = "Sin recibo";

            System.Data.DataTable tabla = new System.Data.DataTable();
            tabla.Columns.Add("fecha", typeof(DateTime)); tabla.Columns.Add("monto_pago", typeof(Decimal)); tabla.Columns.Add("monto_pago_moneda", typeof(string));
            System.Data.DataRow fila = tabla.NewRow();
            fila["fecha"] = rObj.fecha; fila["monto_pago"] = rObj.monto_sus;
            fila["monto_pago_moneda"] = "Monto del Pago (" + codigo_moneda + ")";
            tabla.Rows.Add(fila);

            PagoReciboRegularizacionConcepto prrc = new PagoReciboRegularizacionConcepto();
            prrc.LlenarDatos(rObj.cliente, rObj.num_contrato, rObj.lote, rObj.monto_sus, rObj.concepto, rObj.promotor, codigo_moneda);
            subReport1.Report = prrc;

            PagoReciboRegularizacionDetalle prrd = new PagoReciboRegularizacionDetalle();
            prrd.DataSource = tabla;
            subReport2.Report = prrd;
            textBox11.Visible = true;

            //FORMA DE PAGO
            if (codigo_moneda == "$us") { textBox27.Text = rObj.monto_sus.ToString("F2"); } else { textBox27.Text = "0,00"; }
            if (codigo_moneda == "Bs") { textBox28.Text = rObj.monto_sus.ToString("F2"); } else { textBox28.Text = "0,00"; }
            //textBox29.Text = "0,00";
            //textBox30.Text = "0,00";
            //textBox31.Text = "0,00";
            //textBox32.Text = "0,00";
            //textBox33.Text = "0,00";
            //textBox34.Text = "0,00";

            cajaTransaccionVacio1 reciboRegularizacionVacioObj = new cajaTransaccionVacio1();
            subReport3.Report = reciboRegularizacionVacioObj;

            cajaTransaccionVacio1 talonVacioObj = new cajaTransaccionVacio1();
            subReport4.Report = talonVacioObj;
        }
        public void CargarEstilos()
        {
            //ENCABEZADO
            textBox39.ClassName = "reciboEncabezadoEmpresa";
            textBox40.ClassName = "reciboEncabezadoActividad";
            textBox41.ClassName = "reciboEncabezadoCasaMatriz";
            textBox42.ClassName = "reciboEncabezadoDireccion";
            textBox43.ClassName = "reciboEncabezadoTelefono";
            textBox44.ClassName = "reciboEncabezadoLugar";
            //
            textBox1.ClassName = "reciboTituloEnun";
            textBox3.ClassName = "reciboConceptoEnun";
            textBox4.ClassName = "reciboConceptoDato";
            textBox5.ClassName = "reciboConceptoEnun";
            textBox6.ClassName = "reciboConceptoEnun";
            textBox7.ClassName = "reciboDetalleDato";
            textBox8.ClassName = "reciboDetalleDato";
            textBox9.ClassName = "reciboFecha";
            textBox10.ClassName = "reciboFecha";
            textBox11.ClassName = "reciboDetalleEnun";
            textBox12.ClassName = "reciboDetalleEnun";

            textBox17.ClassName = "reciboConceptoEnun";
            textBox26.ClassName = "reciboConceptoDato";

            //textBox13.ClassName = "reciboDetalleTablaGrupo";
            //textBox14.ClassName = "reciboDetalleTablaGrupo";
            //textBox15.ClassName = "reciboDetalleTablaGrupo";
            //textBox16.ClassName = "reciboDetalleTablaGrupo";
            //textBox17.ClassName = "reciboDetalleTablaGrupo";

            textBox18.ClassName = "reciboDetalleTablaEnun";
            textBox19.ClassName = "reciboDetalleTablaEnun";
            //textBox20.ClassName = "reciboDetalleTablaEnun";
            //textBox21.ClassName = "reciboDetalleTablaEnun";
            //textBox22.ClassName = "reciboDetalleTablaEnun";
            //textBox23.ClassName = "reciboDetalleTablaEnun";
            //textBox24.ClassName = "reciboDetalleTablaEnun";
            //textBox25.ClassName = "reciboDetalleTablaEnun";
            //textBox26.ClassName = "reciboDetalleTablaEnun";

            textBox27.ClassName = "reciboDetalleTablaDato";
            textBox28.ClassName = "reciboDetalleTablaDato";
            //textBox29.ClassName = "reciboDetalleTablaDato";
            //textBox30.ClassName = "reciboDetalleTablaDato";
            //textBox31.ClassName = "reciboDetalleTablaDato";
            //textBox32.ClassName = "reciboDetalleTablaDato";
            //textBox33.ClassName = "reciboDetalleTablaDato";
            //textBox34.ClassName = "reciboDetalleTablaDato";
            //textBox35.ClassName = "reciboDetalleTablaDato";

            textBox36.ClassName = "reciboFirmas";
            textBox37.ClassName = "reciboFirmas";
            textBox38.ClassName = "reciboNota";
        }
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionRegularizacion));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.subReport2 = new DataDynamics.ActiveReports.SubReport();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.subReport3 = new DataDynamics.ActiveReports.SubReport();
            this.subReport4 = new DataDynamics.ActiveReports.SubReport();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.CanGrow = false;
            this.textBox3.Height = 0.1875F;
            this.textBox3.Left = 2.4375F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "";
            this.textBox3.Text = "No. recibo de cobrador:";
            this.textBox3.Top = 0.375F;
            this.textBox3.Width = 2F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.CanGrow = false;
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 4.4375F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "";
            this.textBox4.Text = null;
            this.textBox4.Top = 0.375F;
            this.textBox4.Width = 1F;
            // 
            // shape1
            // 
            this.shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Border.RightColor = System.Drawing.Color.Black;
            this.shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Border.TopColor = System.Drawing.Color.Black;
            this.shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape1.Height = 0.5625F;
            this.shape1.Left = 7.0625F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape1.Top = 0.1875F;
            this.shape1.Width = 1.1875F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.CanGrow = false;
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 7.125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "";
            this.textBox5.Text = "$us:";
            this.textBox5.Top = 0.25F;
            this.textBox5.Width = 0.5F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.CanGrow = false;
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 7.125F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "";
            this.textBox6.Text = "T/C:";
            this.textBox6.Top = 0.5F;
            this.textBox6.Width = 0.5F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.CanGrow = false;
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 7.625F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "";
            this.textBox7.Text = null;
            this.textBox7.Top = 0.25F;
            this.textBox7.Width = 0.5625F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.CanGrow = false;
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 7.625F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "";
            this.textBox8.Text = null;
            this.textBox8.Top = 0.5F;
            this.textBox8.Width = 0.5625F;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.CanGrow = false;
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 2.4375F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "";
            this.textBox9.Text = "La Paz,";
            this.textBox9.Top = 0.5625F;
            this.textBox9.Width = 0.6875F;
            // 
            // textBox10
            // 
            this.textBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.RightColor = System.Drawing.Color.Black;
            this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.TopColor = System.Drawing.Color.Black;
            this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.CanGrow = false;
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 3.125F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "";
            this.textBox10.Text = null;
            this.textBox10.Top = 0.5625F;
            this.textBox10.Width = 2.3125F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.CanGrow = false;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 3.5625F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "text-align: center; ";
            this.textBox1.Text = "RECIBO";
            this.textBox1.Top = 0.1875F;
            this.textBox1.Width = 1.3125F;
            // 
            // subReport1
            // 
            this.subReport1.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.RightColor = System.Drawing.Color.Black;
            this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.TopColor = System.Drawing.Color.Black;
            this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.CanGrow = false;
            this.subReport1.CanShrink = false;
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 0.9375F;
            this.subReport1.Left = 0.6875F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0.9375F;
            this.subReport1.Width = 7.125F;
            // 
            // detail
            // 
            this.detail.CanGrow = false;
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // subReport2
            // 
            this.subReport2.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.Border.RightColor = System.Drawing.Color.Black;
            this.subReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.Border.TopColor = System.Drawing.Color.Black;
            this.subReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.CanGrow = false;
            this.subReport2.CanShrink = false;
            this.subReport2.CloseBorder = false;
            this.subReport2.Height = 0.375F;
            this.subReport2.Left = 2.0625F;
            this.subReport2.Name = "subReport2";
            this.subReport2.Report = null;
            this.subReport2.ReportName = "subReport1";
            this.subReport2.Top = 1.9375F;
            this.subReport2.Width = 5.75F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.CanGrow = false;
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 0.6875F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "";
            this.textBox11.Text = "Observaciones:";
            this.textBox11.Top = 1.9375F;
            this.textBox11.Width = 1.3125F;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightColor = System.Drawing.Color.Black;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopColor = System.Drawing.Color.Black;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.CanGrow = false;
            this.textBox12.Height = 0.1875F;
            this.textBox12.Left = 0.6875F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "";
            this.textBox12.Text = "Forma de Pago:";
            this.textBox12.Top = 2.375F;
            this.textBox12.Width = 1.3125F;
            // 
            // textBox18
            // 
            this.textBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.RightColor = System.Drawing.Color.Black;
            this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.TopColor = System.Drawing.Color.Black;
            this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.CanGrow = false;
            this.textBox18.Height = 0.1875F;
            this.textBox18.Left = 2.0625F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.Style = "";
            this.textBox18.Text = "$us";
            this.textBox18.Top = 2.375F;
            this.textBox18.Width = 0.375F;
            // 
            // textBox19
            // 
            this.textBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.RightColor = System.Drawing.Color.Black;
            this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.TopColor = System.Drawing.Color.Black;
            this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.CanGrow = false;
            this.textBox19.Height = 0.1875F;
            this.textBox19.Left = 3.6875F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.Style = "";
            this.textBox19.Text = "Bs";
            this.textBox19.Top = 2.375F;
            this.textBox19.Width = 0.375F;
            // 
            // textBox27
            // 
            this.textBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.RightColor = System.Drawing.Color.Black;
            this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.TopColor = System.Drawing.Color.Black;
            this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.CanGrow = false;
            this.textBox27.Height = 0.1875F;
            this.textBox27.Left = 2.5F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "";
            this.textBox27.Text = null;
            this.textBox27.Top = 2.375F;
            this.textBox27.Width = 0.8125F;
            // 
            // textBox28
            // 
            this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.RightColor = System.Drawing.Color.Black;
            this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.TopColor = System.Drawing.Color.Black;
            this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.CanGrow = false;
            this.textBox28.Height = 0.1875F;
            this.textBox28.Left = 4.125F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "";
            this.textBox28.Text = null;
            this.textBox28.Top = 2.375F;
            this.textBox28.Width = 0.8125F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 1.5625F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 3.25F;
            this.line1.Width = 2.25F;
            this.line1.X1 = 1.5625F;
            this.line1.X2 = 3.8125F;
            this.line1.Y1 = 3.25F;
            this.line1.Y2 = 3.25F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 4.6875F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 3.25F;
            this.line2.Width = 2.25F;
            this.line2.X1 = 4.6875F;
            this.line2.X2 = 6.9375F;
            this.line2.Y1 = 3.25F;
            this.line2.Y2 = 3.25F;
            // 
            // textBox36
            // 
            this.textBox36.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.RightColor = System.Drawing.Color.Black;
            this.textBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.TopColor = System.Drawing.Color.Black;
            this.textBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Height = 0.16F;
            this.textBox36.Left = 1.5625F;
            this.textBox36.Name = "textBox36";
            this.textBox36.Style = "text-align: center; font-size: 9pt; ";
            this.textBox36.Text = "Firma del Cliente";
            this.textBox36.Top = 3.25F;
            this.textBox36.Width = 2.25F;
            // 
            // textBox37
            // 
            this.textBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.RightColor = System.Drawing.Color.Black;
            this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.TopColor = System.Drawing.Color.Black;
            this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Height = 0.16F;
            this.textBox37.Left = 4.6875F;
            this.textBox37.Name = "textBox37";
            this.textBox37.Style = "text-align: center; font-size: 9pt; ";
            this.textBox37.Text = "DPTO. TESORERIA";
            this.textBox37.Top = 3.25F;
            this.textBox37.Width = 2.25F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
            // 
            // textBox35
            // 
            this.textBox35.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.RightColor = System.Drawing.Color.Black;
            this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.TopColor = System.Drawing.Color.Black;
            this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Height = 0.25F;
            this.textBox35.Left = 0.25F;
            this.textBox35.Name = "textBox35";
            this.textBox35.Style = "ddo-char-set: 0; font-weight: normal; font-style: italic; font-size: 8.25pt; ";
            this.textBox35.Text = resources.GetString("textBox35.Text");
            this.textBox35.Top = 3.4375F;
            this.textBox35.Width = 8F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.textBox7,
            this.textBox5,
            this.textBox6,
            this.shape1,
            this.textBox8,
            this.textBox1,
            this.textBox3,
            this.textBox4,
            this.textBox9,
            this.textBox10,
            this.textBox38,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox39,
            this.textBox17,
            this.textBox26,
            this.textBox11,
            this.subReport2,
            this.textBox12,
            this.textBox18,
            this.textBox19,
            this.textBox27,
            this.textBox28,
            this.textBox36,
            this.line2,
            this.textBox37,
            this.line1,
            this.textBox35,
            this.subReport3,
            this.subReport4,
            this.line5,
            this.line3});
            this.groupHeader1.DataField = "id_reciboregularizacion";
            this.groupHeader1.Height = 10.948F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // textBox38
            // 
            this.textBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.RightColor = System.Drawing.Color.Black;
            this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.TopColor = System.Drawing.Color.Black;
            this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.CanGrow = false;
            this.textBox38.Height = 0.18F;
            this.textBox38.Left = 7.1875F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.Style = "";
            this.textBox38.Text = "Reimpresión";
            this.textBox38.Top = 0.77F;
            this.textBox38.Visible = false;
            this.textBox38.Width = 1F;
            // 
            // textBox40
            // 
            this.textBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.RightColor = System.Drawing.Color.Black;
            this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.TopColor = System.Drawing.Color.Black;
            this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.CanGrow = false;
            this.textBox40.Height = 0.12F;
            this.textBox40.Left = 0.25F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.Style = "text-align: center; font-size: 7pt; ";
            this.textBox40.Text = null;
            this.textBox40.Top = 0.3125F;
            this.textBox40.Width = 1.875F;
            // 
            // textBox41
            // 
            this.textBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.RightColor = System.Drawing.Color.Black;
            this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.TopColor = System.Drawing.Color.Black;
            this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.CanGrow = false;
            this.textBox41.Height = 0.12F;
            this.textBox41.Left = 0.25F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.Style = "text-align: center; font-size: 7pt; ";
            this.textBox41.Text = null;
            this.textBox41.Top = 0.4375F;
            this.textBox41.Width = 1.875F;
            // 
            // textBox42
            // 
            this.textBox42.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.RightColor = System.Drawing.Color.Black;
            this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.TopColor = System.Drawing.Color.Black;
            this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.CanGrow = false;
            this.textBox42.Height = 0.12F;
            this.textBox42.Left = 0.25F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.Style = "text-align: center; font-size: 7pt; ";
            this.textBox42.Text = null;
            this.textBox42.Top = 0.5625F;
            this.textBox42.Width = 1.875F;
            // 
            // textBox43
            // 
            this.textBox43.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.RightColor = System.Drawing.Color.Black;
            this.textBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.TopColor = System.Drawing.Color.Black;
            this.textBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.CanGrow = false;
            this.textBox43.Height = 0.12F;
            this.textBox43.Left = 0.25F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.Style = "text-align: center; font-size: 7pt; ";
            this.textBox43.Text = null;
            this.textBox43.Top = 0.6875F;
            this.textBox43.Width = 1.875F;
            // 
            // textBox44
            // 
            this.textBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.RightColor = System.Drawing.Color.Black;
            this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.TopColor = System.Drawing.Color.Black;
            this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.CanGrow = false;
            this.textBox44.Height = 0.12F;
            this.textBox44.Left = 0.25F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.Style = "text-align: center; font-size: 7pt; ";
            this.textBox44.Text = null;
            this.textBox44.Top = 0.8125F;
            this.textBox44.Width = 1.875F;
            // 
            // textBox39
            // 
            this.textBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.RightColor = System.Drawing.Color.Black;
            this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.TopColor = System.Drawing.Color.Black;
            this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.CanGrow = false;
            this.textBox39.Height = 0.13F;
            this.textBox39.Left = 0.25F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.Style = "";
            this.textBox39.Text = null;
            this.textBox39.Top = 0.1875F;
            this.textBox39.Width = 1.88F;
            // 
            // textBox17
            // 
            this.textBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.RightColor = System.Drawing.Color.Black;
            this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.TopColor = System.Drawing.Color.Black;
            this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.CanGrow = false;
            this.textBox17.Height = 0.1875F;
            this.textBox17.Left = 2.4375F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.Style = "";
            this.textBox17.Text = "Sucursal:";
            this.textBox17.Top = 0.75F;
            this.textBox17.Width = 0.8125F;
            // 
            // textBox26
            // 
            this.textBox26.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.RightColor = System.Drawing.Color.Black;
            this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.TopColor = System.Drawing.Color.Black;
            this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.CanGrow = false;
            this.textBox26.Height = 0.1875F;
            this.textBox26.Left = 3.25F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.Style = "";
            this.textBox26.Text = "textBox26";
            this.textBox26.Top = 0.75F;
            this.textBox26.Width = 2.1875F;
            // 
            // subReport3
            // 
            this.subReport3.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport3.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport3.Border.RightColor = System.Drawing.Color.Black;
            this.subReport3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport3.Border.TopColor = System.Drawing.Color.Black;
            this.subReport3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport3.CanGrow = false;
            this.subReport3.CloseBorder = false;
            this.subReport3.Height = 4F;
            this.subReport3.Left = 0F;
            this.subReport3.Name = "subReport3";
            this.subReport3.Report = null;
            this.subReport3.ReportName = "subReport3";
            this.subReport3.Top = 4F;
            this.subReport3.Width = 8.5F;
            // 
            // subReport4
            // 
            this.subReport4.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport4.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport4.Border.RightColor = System.Drawing.Color.Black;
            this.subReport4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport4.Border.TopColor = System.Drawing.Color.Black;
            this.subReport4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport4.CanGrow = false;
            this.subReport4.CloseBorder = false;
            this.subReport4.Height = 2.9375F;
            this.subReport4.Left = 0F;
            this.subReport4.Name = "subReport4";
            this.subReport4.Report = null;
            this.subReport4.ReportName = "subReport4";
            this.subReport4.Top = 8F;
            this.subReport4.Width = 8.5F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 4F;
            this.line5.Visible = false;
            this.line5.Width = 8.5F;
            this.line5.X1 = 0F;
            this.line5.X2 = 8.5F;
            this.line5.Y1 = 4F;
            this.line5.Y2 = 4F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 8F;
            this.line3.Visible = false;
            this.line3.Width = 8.5F;
            this.line3.X1 = 0F;
            this.line3.X2 = 8.5F;
            this.line3.Y1 = 8F;
            this.line3.Y2 = 8F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.PrintAtBottom = true;
            // 
            // cajaTransaccionRegularizacion
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionRegularizacion_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionRegularizacion_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void pageFooter_Format(object sender, EventArgs e)
        {

        }

        }
}