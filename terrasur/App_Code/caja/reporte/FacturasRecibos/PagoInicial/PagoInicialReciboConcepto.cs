using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for PagoInicialReciboConcepto.
/// </summary>
/// 
namespace terrasur
{
    public class PagoInicialReciboConcepto : DataDynamics.ActiveReports.ActiveReport3
    {
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
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox12;

        public PagoInicialReciboConcepto()
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
        private void PagoInicialReciboConcepto_ReportStart(object sender, EventArgs e)
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
            int id_contrato = transaccion.IdContrato(Id_transaccion);
            contrato c = new contrato(id_contrato);
            //int num_recibo = recibo.IdPorTransaccion(Id_transaccion);
            recibo rec = new recibo(Id_recibo, 0);
            pago p = new pago(pago.IdPorTransaccion(Id_transaccion));
            textBox7.Text = rec.nombre_cliente;
            textBox8.Text = c.numero;
            if (contrato.EsContratoVenta(id_contrato) == true)
            {
                contrato_venta cv = new contrato_venta(id_contrato);
                textBox9.Text = cv.urbanizacion_nombre + "/" + cv.manzano_codigo + "/" + cv.lote_codigo;
            }
            else
            {
                textBox9.Text = "Servicios funerarios";
            }

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
            int num_pago = p.anterior_num_pagos + 1;
            textBox14.Text = num_pago.ToString();
            if (c.id_promotor_vigente > 0)
            {
                promotor pr = new promotor(c.id_promotor_vigente);
                textBox12.Text = pr.paterno + " " + pr.materno + " " + pr.nombres;
            }
            else
            {
                textBox12.Text = "Sin  promotor";
            }
        }
        public void CargarEstilos()
        {
            textBox1.ClassName = "reciboConceptoEnun";
            textBox2.ClassName = "reciboConceptoEnun";
            textBox3.ClassName = "reciboConceptoEnun";
            textBox4.ClassName = "reciboConceptoEnun";
            textBox5.ClassName = "reciboConceptoEnun";
            textBox6.ClassName = "reciboConceptoEnun";

            textBox7.ClassName = "reciboConceptoDato";
            textBox8.ClassName = "reciboNumeroContrato";
            textBox9.ClassName = "reciboConceptoDato";
            textBox10.ClassName = "reciboConceptoDato";
            textBox11.ClassName = "reciboConceptoDato";
            textBox12.ClassName = "reciboConceptoDato";
            textBox13.ClassName = "reciboConceptoEnun";
            textBox14.ClassName = "reciboNumeroContrato";

        }
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "PagoInicialReciboConcepto.resx";
            System.Resources.ResourceManager resources = Resources.PagoInicialReciboConcepto.ResourceManager;
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
            this.textBox14});
            this.detail.Height = 1.1875F;
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
            this.textBox1.Size = new System.Drawing.SizeF(2F, 0.1875F);
            this.textBox1.Text = "Hemos recibido de:";
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
            this.textBox2.Size = new System.Drawing.SizeF(1.125F, 0.1875F);
            this.textBox2.Text = "del contrato:";
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
            this.textBox3.Size = new System.Drawing.SizeF(1.625F, 0.1875F);
            this.textBox3.Text = "del Lote/Servicio:";
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
            this.textBox6.Size = new System.Drawing.SizeF(1.4375F, 0.1875F);
            this.textBox6.Text = "Asesor de ventas:";
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
            this.textBox7.Size = new System.Drawing.SizeF(5F, 0.1875F);
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
            this.textBox8.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
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
            this.textBox9.Size = new System.Drawing.SizeF(3.3125F, 0.1875F);
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
            this.textBox11.Size = new System.Drawing.SizeF(2.5F, 0.1875F);
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
            this.textBox12.OutputFormat = null;
            this.textBox12.Size = new System.Drawing.SizeF(5.5F, 0.1875F);
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
            this.textBox13.OutputFormat = null;
            this.textBox13.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
            this.textBox13.Text = "No. Pago:";
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
            this.textBox14.OutputFormat = null;
            this.textBox14.Size = new System.Drawing.SizeF(0.375F, 0.1875F);
            this.textBox14.Text = null;
            // 
            // PagoInicialReciboConcepto
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.010417F;
            this.Sections.Add(this.detail);
            this.ReportStart += new System.EventHandler(this.PagoInicialReciboConcepto_ReportStart);
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

        }
        #endregion

        
    }
}