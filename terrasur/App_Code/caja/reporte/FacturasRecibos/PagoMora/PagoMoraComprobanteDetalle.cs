using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;    

/// <summary>
/// Summary description for PagoMoraComprobanteDetalle.
/// </summary>
/// 
namespace terrasur
{
    public class PagoMoraComprobanteDetalle : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.Detail detail;

        public PagoMoraComprobanteDetalle()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;

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
        private void PagoMoraComprobanteDetalle_ReportStart(object sender, EventArgs e)
        {
            //ESTILOS
            EstilosBase rpt = new EstilosBase();
            string filepath = HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBaseComprobante.rpx";
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
            int id_pagomora = pago_mora.IdPorTransaccion(Id_transaccion);
            pago_mora pm = new pago_mora(id_pagomora);
            DateTime fecha_ultimo_pago = new pago(pm.id_pago).fecha_proximo;
            textBox6.Text = fecha_ultimo_pago.ToString("d");
            textBox7.Text = pm.fecha.AddDays(((-1) * pm.num_dias)).ToString("d");
            textBox8.Text = pm.num_dias.ToString();

            contrato cObj = new contrato(transaccion.IdContrato(Id_transaccion));
            textBox9.Text = cObj.interes_penal.ToString() + " % mensual";
            textBox10.Text = pm.monto_pagado.ToString("F2") + " " + cObj.codigo_moneda;
        }
        public void CargarEstilos()
        {
            textBox1.ClassName = "comprobanteDetalleEnun";
            textBox2.ClassName = "comprobanteDetalleEnun";
            textBox3.ClassName = "comprobanteDetalleEnun";
            textBox4.ClassName = "comprobanteDetalleEnun";
            textBox5.ClassName = "comprobanteDetalleEnun";
            textBox6.ClassName = "comprobanteDetalleDato";
            textBox7.ClassName = "comprobanteDetalleDato";
            textBox8.ClassName = "comprobanteDetalleDato";
            textBox9.ClassName = "comprobanteDetalleDato";
            textBox10.ClassName = "comprobanteDetalleDato";
        }
        
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "PagoMoraComprobanteDetalle.resx";
            System.Resources.ResourceManager resources = Resources.PagoMoraComprobanteDetalle.ResourceManager;
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10});
            this.detail.Height = 0.96875F;
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
            this.textBox1.Size = new System.Drawing.SizeF(3.6875F, 0.1875F);
            this.textBox1.Text = "Fecha de vencimiento del último pago:";
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
            this.textBox2.Size = new System.Drawing.SizeF(3.6875F, 0.1875F);
            this.textBox2.Text = "Fecha desde la que se cobró el interés penal:";
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
            this.textBox3.Size = new System.Drawing.SizeF(3.6875F, 0.1875F);
            this.textBox3.Text = "Número de dias de intereses penales:";
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
            this.textBox4.Size = new System.Drawing.SizeF(3.6875F, 0.1875F);
            this.textBox4.Text = "Interés penal del:";
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
            this.textBox5.Size = new System.Drawing.SizeF(3.6875F, 0.1875F);
            this.textBox5.Text = "Monto pagado por concepto de interés penal:";
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
            this.textBox7.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox7.Text = null;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.DistinctField = null;
            this.textBox8.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox8.Location = ((System.Drawing.PointF)(resources.GetObject("textBox8.Location")));
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = null;
            this.textBox8.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox8.Text = null;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.DistinctField = null;
            this.textBox9.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox9.Location = ((System.Drawing.PointF)(resources.GetObject("textBox9.Location")));
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = null;
            this.textBox9.Size = new System.Drawing.SizeF(1.5F, 0.1875F);
            this.textBox9.Text = null;
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
            this.textBox10.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox10.Text = null;
            // 
            // PagoMoraComprobanteDetalle
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.03125F;
            this.Sections.Add(this.detail);
            this.ReportStart += new System.EventHandler(this.PagoMoraComprobanteDetalle_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();

        }
        #endregion

    }
}