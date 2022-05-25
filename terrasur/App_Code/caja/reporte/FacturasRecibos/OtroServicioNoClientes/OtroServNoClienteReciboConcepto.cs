using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for OtroServNoClienteReciboConcepto.
/// </summary>
/// 
namespace terrasur
{
    public class OtroServNoClienteReciboConcepto : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.Detail detail;

        public OtroServNoClienteReciboConcepto()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox7;
        private TextBox textBox10;
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
        private void OtroServNoClienteReciboConcepto_ReportStart(object sender, EventArgs e)
        {
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
        public void LlenarDatos(int Id_transaccion, int Id_recibo)
        {
            //int num_recibo = recibo.IdPorTransaccion(Id_transaccion);
            recibo rec = new recibo(Id_recibo, 0);
            textBox7.Text = rec.nombre_cliente;

            if (rec.codigo_moneda == "$us")
            {
                textBox4.Text = "la suma de $us:";
                textBox10.Text = rec.monto_sus.ToString("F2") + " son: (" + Conversiones.enletras(rec.monto_sus.ToString()) + " DOLARES AMERICANOS)";
            }
            else
            {
                textBox4.Text = "la suma de Bs:";
                textBox10.Text = rec.monto_sus.ToString("F2") + " son: (" + Conversiones.enletras(rec.monto_sus.ToString()) + " BOLIVIANOS)";
            }
            textBox11.Text = rec.concepto;
        }
        public void CargarEstilos()
        {
            textBox1.ClassName = "reciboConceptoEnun";
            textBox4.ClassName = "reciboConceptoEnun";
            textBox5.ClassName = "reciboConceptoEnun";

            textBox7.ClassName = "reciboConceptoDato";
            textBox10.ClassName = "reciboConceptoDato";
            textBox11.ClassName = "reciboConceptoDato";

        }
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "OtroServNoClienteReciboConcepto.resx";
            System.Resources.ResourceManager resources = Resources.OtroServNoClienteReciboConcepto.ResourceManager;
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox4,
            this.textBox5,
            this.textBox7,
            this.textBox10,
            this.textBox11});
            this.detail.Height = 0.71875F;
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DistinctField = null;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = null;
            this.textBox1.Size = new System.Drawing.SizeF(1.875F, 0.1875F);
            this.textBox1.Text = "Hemos recibido de:";
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DistinctField = null;
            this.textBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = null;
            this.textBox4.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
            this.textBox4.Text = "la suma de $us:";
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
            this.textBox5.Size = new System.Drawing.SizeF(1.4375F, 0.1875F);
            this.textBox5.Text = "Concepto de pago:";
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.DistinctField = null;
            this.textBox7.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox7.Location = ((System.Drawing.PointF)(resources.GetObject("textBox7.Location")));
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = null;
            this.textBox7.Size = new System.Drawing.SizeF(5.125F, 0.1875F);
            this.textBox7.Text = null;
            // 
            // textBox10
            // 
            this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.DistinctField = null;
            this.textBox10.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox10.Location = ((System.Drawing.PointF)(resources.GetObject("textBox10.Location")));
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = null;
            this.textBox10.Size = new System.Drawing.SizeF(5.5625F, 0.1875F);
            this.textBox10.Text = null;
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
            this.textBox11.Size = new System.Drawing.SizeF(5.5625F, 0.1875F);
            this.textBox11.Text = null;
            // 
            // OtroServNoClienteReciboConcepto
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7F;
            this.Sections.Add(this.detail);
            this.ReportStart += new System.EventHandler(this.OtroServNoClienteReciboConcepto_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();

        }
        #endregion

        
    }
}