using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// Summary description for srpt_PagosRealizados.
/// </summary>
/// 
 public class srpt_PagosRealizados : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
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
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public srpt_PagosRealizados()
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
        public void DatosPagosRealizados(int Id_contrato)
    {
        terrasur.contrato c = new terrasur.contrato(Id_contrato);
        DataTable tabla = terrasur.contratoReporte.ReporteDatosContratoEstadoCuenta(Id_contrato);
        foreach (DataRow fila in tabla.Rows)
        {
            textBox7.Text = fila["num_pagos_realizados"].ToString();
            textBox8.Text = fila["total_cuotas_realizadas"].ToString();
            textBox9.Text = fila["pagos_meses_seguro_realizados"].ToString();
            textBox10.Text = fila["pagos_meses_mantenimiento_realizados"].ToString();
            textBox11.Text = fila["pagos_dias_interes_realizados"].ToString();
            textBox12.Text = fila["monto_pagos_realizados"].ToString();
            textBox13.Text = fila["pagos_seguro_realizados"].ToString();
            textBox14.Text = fila["pagos_mantenimiento_realizados"].ToString();
            textBox15.Text = fila["pagos_interes_realizados"].ToString();
        }
        label2.Text = c.codigo_moneda;
        label7.Text = c.codigo_moneda;
        label8.Text = c.codigo_moneda;
        label9.Text = c.codigo_moneda;
    }
     private void srpt_PagosRealizados_ReportStart(object sender, EventArgs e)
     {
         EstilosBase rpt = new EstilosBase();
         string filepath = HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBase.rpx";
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
     public void CargarEstilos()
     {
         textBox1.ClassName = "estiloGrupoEnun";

         textBox2.ClassName = "estiloDetalleEnun";
         textBox3.ClassName = "estiloDetalleEnun";
         textBox4.ClassName = "estiloDetalleEnun";
         textBox5.ClassName = "estiloDetalleEnun";
         textBox6.ClassName = "estiloDetalleEnun";

         textBox7.ClassName = "estiloDetalleDato";
         textBox8.ClassName = "estiloDetalleDato";
         textBox9.ClassName = "estiloDetalleDato";
         textBox10.ClassName = "estiloDetalleDato";
         textBox11.ClassName = "estiloDetalleDato";

         textBox12.ClassName = "estiloDetalleDato";
         textBox13.ClassName = "estiloDetalleDato";
         textBox14.ClassName = "estiloDetalleDato";
         textBox15.ClassName = "estiloDetalleDato";

         label1.ClassName = "estiloDetalleDato";
         label2.ClassName = "estiloDetalleDato";
         label3.ClassName = "estiloDetalleDato";
         label4.ClassName = "estiloDetalleDato";
         label5.ClassName = "estiloDetalleDato";
         label6.ClassName = "estiloDetalleDato";
         label7.ClassName = "estiloDetalleDato";
         label8.ClassName = "estiloDetalleDato";
         label9.ClassName = "estiloDetalleDato";
     }
     #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "srpt_PagosRealizados.resx";
            System.Resources.ResourceManager resources = Resources.srpt_PagosRealizados.ResourceManager;
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
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
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
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
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9});
            this.detail.Height = 0.84375F;
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
            this.textBox1.Size = new System.Drawing.SizeF(1.25F, 0.1875F);
            this.textBox1.Text = "Pagos realizados";
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
            this.textBox2.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox2.Text = "Pagos";
            // 
            // textBox3
            // 
            this.textBox3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = null;
            this.textBox3.Size = new System.Drawing.SizeF(1F, 0.1979167F);
            this.textBox3.Text = "Cuotas";
            // 
            // textBox4
            // 
            this.textBox4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
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
            this.textBox4.Text = "Seguro";
            // 
            // textBox5
            // 
            this.textBox5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
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
            this.textBox5.Text = "Mantenimiento";
            // 
            // textBox6
            // 
            this.textBox6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
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
            this.textBox6.Text = "Interés";
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
            this.textBox7.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
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
            this.textBox8.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
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
            this.textBox9.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
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
            this.textBox10.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
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
            this.textBox11.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox11.Text = null;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.DistinctField = null;
            this.textBox12.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox12.Location = ((System.Drawing.PointF)(resources.GetObject("textBox12.Location")));
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = "#,##0.00";
            this.textBox12.Size = new System.Drawing.SizeF(0.6875F, 0.198F);
            this.textBox12.Text = null;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.DistinctField = null;
            this.textBox13.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox13.Location = ((System.Drawing.PointF)(resources.GetObject("textBox13.Location")));
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = "#,##0.00";
            this.textBox13.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox13.Text = null;
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DistinctField = null;
            this.textBox14.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox14.Location = ((System.Drawing.PointF)(resources.GetObject("textBox14.Location")));
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = "#,##0.00";
            this.textBox14.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox14.Text = null;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.DistinctField = null;
            this.textBox15.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox15.Location = ((System.Drawing.PointF)(resources.GetObject("textBox15.Location")));
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = "#,##0.00";
            this.textBox15.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox15.Text = null;
            // 
            // label1
            // 
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.HyperLink = null;
            this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.SizeF(0.375F, 0.1875F);
            this.label1.Text = "(No.)";
            // 
            // label2
            // 
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.HyperLink = null;
            this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
            this.label2.Text = "$us";
            // 
            // label3
            // 
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.HyperLink = null;
            this.label3.Location = ((System.Drawing.PointF)(resources.GetObject("label3.Location")));
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.SizeF(0.375F, 0.1875F);
            this.label3.Text = "(No.)";
            // 
            // label4
            // 
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.HyperLink = null;
            this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
            this.label4.Text = "Meses";
            // 
            // label5
            // 
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.HyperLink = null;
            this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
            this.label5.Text = "Meses";
            // 
            // label6
            // 
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Font = new System.Drawing.Font("Arial", 10F);
            this.label6.HyperLink = null;
            this.label6.Location = ((System.Drawing.PointF)(resources.GetObject("label6.Location")));
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
            this.label6.Text = "días";
            // 
            // label7
            // 
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Font = new System.Drawing.Font("Arial", 10F);
            this.label7.HyperLink = null;
            this.label7.Location = ((System.Drawing.PointF)(resources.GetObject("label7.Location")));
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
            this.label7.Text = "$us";
            // 
            // label8
            // 
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Font = new System.Drawing.Font("Arial", 10F);
            this.label8.HyperLink = null;
            this.label8.Location = ((System.Drawing.PointF)(resources.GetObject("label8.Location")));
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
            this.label8.Text = "$us";
            // 
            // label9
            // 
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Font = new System.Drawing.Font("Arial", 10F);
            this.label9.HyperLink = null;
            this.label9.Location = ((System.Drawing.PointF)(resources.GetObject("label9.Location")));
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
            this.label9.Text = "$us";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // srpt_PagosRealizados
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.ReportStart += new System.EventHandler(this.srpt_PagosRealizados_ReportStart);
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();

        }
        #endregion

     
    }
