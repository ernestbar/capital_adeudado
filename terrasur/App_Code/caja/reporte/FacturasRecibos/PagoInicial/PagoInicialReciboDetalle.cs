using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for PagoInicialReciboDetalle.
/// </summary>
/// 
namespace terrasur
{
    public class PagoInicialReciboDetalle : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.Detail detail;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox6;

        public PagoInicialReciboDetalle()
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

        private void PagoInicialReciboDetalle_ReportStart(object sender, EventArgs e)
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
        public void LlenarDatos(int Id_transaccion)
        {
            int id_contrato = transaccion.IdContrato(Id_transaccion);
            contrato c = new contrato(id_contrato);
            pago p = new pago(c.id_cuota_inicial);
            textBox4.Text = c.precio_final.ToString("F2") + " " + c.codigo_moneda;
            textBox5.Text = p.monto_pago.ToString("F2") + " " + c.codigo_moneda;
            textBox6.Text = p.saldo.ToString("F2") + " " + c.codigo_moneda;
        }
        public void CargarEstilos()
        {
            textBox1.ClassName = "reciboDetalleEnun";
            textBox2.ClassName = "reciboDetalleEnun";
            textBox3.ClassName = "reciboDetalleEnun";
            textBox4.ClassName = "reciboDetalleDato";
            textBox5.ClassName = "reciboDetalleDato";
            textBox6.ClassName = "reciboDetalleDato";

        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "PagoInicialReciboDetalle.resx";
            System.Resources.ResourceManager resources = Resources.PagoInicialReciboDetalle.ResourceManager;
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.textBox3,
            this.textBox5,
            this.textBox6,
            this.textBox1,
            this.textBox4});
            this.detail.Height = 0.7083334F;
            this.detail.Name = "detail";
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = null;
            this.textBox2.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
            this.textBox2.Text = "Cuota inicial:";
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = null;
            this.textBox3.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
            this.textBox3.Text = "Saldo Capital:";
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
            this.textBox5.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox5.Text = null;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DistinctField = null;
            this.textBox6.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = null;
            this.textBox6.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox6.Text = null;
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
            this.textBox1.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
            this.textBox1.Text = "Monto Adeudado:";
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
            this.textBox4.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox4.Text = null;
            // 
            // PagoInicialReciboDetalle
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.Sections.Add(this.detail);
            this.ReportStart += new System.EventHandler(this.PagoInicialReciboDetalle_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();

        }
        #endregion

    }
}