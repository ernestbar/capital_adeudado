using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionPruebaImpresion2.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionPruebaImpresion2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private Line line1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Line line2;
        private Line line4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Shape shape1;
        private Shape shape2;
        private Shape shape3;
        private TextBox textBox5;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionPruebaImpresion2()
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

        private void cajaTransaccionPruebaImpresion2_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionCarta", 850, 1100);
            this.PageSettings.Margins.Top = 0.0F;
            this.PageSettings.Margins.Bottom = 0.0F;
            this.PageSettings.Margins.Right = 0.0F;
            this.PageSettings.Margins.Left = 0.0F;

            //ESTILOS
            /*
            EstilosBase rpt = new EstilosBase();
            string filepath = HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBaseFactura.rpx";
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
            */
        }
        public void CargarDatos(string NombreImpresora, int NumBandeja, string NombreBandeja)
        {
            textBox2.Text = "Nombre de la impresora: " + NombreImpresora;
            textBox3.Text = "Número de la bandeja: " + NumBandeja.ToString();
            textBox4.Text = "Nombre de la bandeja: " + NombreBandeja;
            textBox5.Text = "Hora de envío: " + DateTime.Now.ToString();
            
        }

        private void cajaTransaccionPruebaImpresion2_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
        }

        public void CargarEstilos()
        {

        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionPruebaImpresion2));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
            this.shape2 = new DataDynamics.ActiveReports.Shape();
            this.shape3 = new DataDynamics.ActiveReports.Shape();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.CanGrow = false;
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
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
            this.line1.Left = 0.1875F;
            this.line1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 4F;
            this.line1.Width = 8.125F;
            this.line1.X1 = 0.1875F;
            this.line1.X2 = 8.3125F;
            this.line1.Y1 = 4F;
            this.line1.Y2 = 4F;
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
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 2.5F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "text-align: center; ";
            this.textBox1.Text = "Prueba de impresión";
            this.textBox1.Top = 0.25F;
            this.textBox1.Width = 3.5F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 1F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.5F;
            this.textBox2.Width = 5F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line1,
            this.textBox1,
            this.textBox2,
            this.line2,
            this.line4,
            this.textBox3,
            this.textBox4,
            this.shape1,
            this.shape2,
            this.shape3,
            this.textBox5});
            this.groupHeader1.DataField = "id_compuesto";
            this.groupHeader1.Height = 11F;
            this.groupHeader1.Name = "groupHeader1";
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
            this.line2.Left = 0.1875F;
            this.line2.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 8F;
            this.line2.Width = 8.125F;
            this.line2.X1 = 0.1875F;
            this.line2.X2 = 8.3125F;
            this.line2.Y1 = 8F;
            this.line2.Y2 = 8F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0.1875F;
            this.line4.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.1875F;
            this.line4.Width = 8.125F;
            this.line4.X1 = 0.1875F;
            this.line4.X2 = 8.3125F;
            this.line4.Y1 = 0.1875F;
            this.line4.Y2 = 0.1875F;
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
            this.textBox3.Height = 0.1875F;
            this.textBox3.Left = 1F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "";
            this.textBox3.Text = "textBox3";
            this.textBox3.Top = 0.75F;
            this.textBox3.Width = 5F;
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
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 1F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "";
            this.textBox4.Text = "textBox4";
            this.textBox4.Top = 1F;
            this.textBox4.Width = 5F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.PrintAtBottom = true;
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
            this.shape1.Height = 3.625F;
            this.shape1.Left = 0.1875F;
            this.shape1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 10F;
            this.shape1.Top = 0.1875F;
            this.shape1.Width = 8.125F;
            // 
            // shape2
            // 
            this.shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Border.RightColor = System.Drawing.Color.Black;
            this.shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Border.TopColor = System.Drawing.Color.Black;
            this.shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Height = 3.625F;
            this.shape2.Left = 0.1875F;
            this.shape2.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.shape2.Name = "shape2";
            this.shape2.RoundingRadius = 9.999999F;
            this.shape2.Top = 4.1875F;
            this.shape2.Width = 8.125F;
            // 
            // shape3
            // 
            this.shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape3.Border.RightColor = System.Drawing.Color.Black;
            this.shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape3.Border.TopColor = System.Drawing.Color.Black;
            this.shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape3.Height = 2.625F;
            this.shape3.Left = 0.1875F;
            this.shape3.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.shape3.Name = "shape3";
            this.shape3.RoundingRadius = 10F;
            this.shape3.Top = 8.1875F;
            this.shape3.Width = 8.125F;
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
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 1F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "";
            this.textBox5.Text = "textBox5";
            this.textBox5.Top = 1.25F;
            this.textBox5.Width = 5F;
            // 
            // cajaTransaccionPruebaImpresion2
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Factura";
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionPruebaImpresion2_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionPruebaImpresion2_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}