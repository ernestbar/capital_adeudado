using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for OtroServNoClienteFacturaConcepto.
/// </summary>
/// 
namespace terrasur
{
    public class OtroServNoClienteFacturaConcepto : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.Detail detail;

        public OtroServNoClienteFacturaConcepto()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private TextBox textBox5;
        private TextBox textBox11;

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

        private void OtroServNoClienteFacturaConcepto_ReportStart(object sender, EventArgs e)
        {
            //ESTILOS
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

        }

        public void LlenarDatos(int Id_factura)
        {
            //int id_factura = factura.IdPorTransaccion(Id_transaccion);
            factura f = new factura(Id_factura);
            textBox11.Text = f.concepto;
        }

        public void CargarEstilos()
        {
            textBox5.ClassName = "facturaConceptoEnun";
            textBox11.ClassName = "facturaConceptoDato";
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "OtroServNoClienteFacturaConcepto.resx";
            System.Resources.ResourceManager resources = Resources.OtroServNoClienteFacturaConcepto.ResourceManager;
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox5,
            this.textBox11});
            this.detail.Height = 0.25F;
            this.detail.Name = "detail";
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DistinctField = null;
            this.textBox5.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = null;
            this.textBox5.Size = new System.Drawing.SizeF(1.5F, 0.1875F);
            this.textBox5.Text = "Concepto de pago:";
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.DistinctField = null;
            this.textBox11.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox11.Location = ((System.Drawing.PointF)(resources.GetObject("textBox11.Location")));
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = null;
            this.textBox11.Size = new System.Drawing.SizeF(5.5F, 0.1875F);
            this.textBox11.Text = null;
            // 
            // OtroServNoClienteFacturaConcepto
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.041667F;
            this.Sections.Add(this.detail);
            this.ReportStart += new System.EventHandler(this.OtroServNoClienteFacturaConcepto_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();

        }
        #endregion

       
    }
}