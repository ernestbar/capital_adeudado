using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for PagoReciboDetalle.
/// </summary>
/// 
namespace terrasur
{
    public class PagoReciboDetalle : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.Detail detail;

        public PagoReciboDetalle()
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
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private TextBox textBox23;

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
        private void PagoReciboDetalle_ReportStart(object sender, EventArgs e)
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

        public void CargarDatos(string Codigo_moneda)
        {
            textBox6.Text = "Pago (" + Codigo_moneda + ")";
            textBox7.Text = "Seguro (" + Codigo_moneda + ")";
            textBox8.Text = "Manten. (" + Codigo_moneda + ")";
            textBox9.Text = "Interés (" + Codigo_moneda + ")";
            textBox10.Text = "Amort. (" + Codigo_moneda + ")";
            textBox11.Text = "Saldo (" + Codigo_moneda + ")";
        }

        public void CargarEstilos()
        {
            textBox1.ClassName = "reciboDetalleTablaEnun";
            textBox2.ClassName = "reciboDetalleTablaEnun";
            textBox3.ClassName = "reciboDetalleTablaEnun";
            textBox4.ClassName = "reciboDetalleTablaEnun";
            textBox5.ClassName = "reciboDetalleTablaEnun";
            textBox6.ClassName = "reciboDetalleTablaEnun";
            textBox7.ClassName = "reciboDetalleTablaEnun";
            textBox8.ClassName = "reciboDetalleTablaEnun";
            textBox9.ClassName = "reciboDetalleTablaEnun";
            textBox10.ClassName = "reciboDetalleTablaEnun";
            textBox11.ClassName = "reciboDetalleTablaEnun";
            textBox12.ClassName = "reciboNumeroContrato";
            textBox13.ClassName = "reciboDetalleTablaDato";
            textBox14.ClassName = "reciboDetalleTablaDato";
            textBox15.ClassName = "reciboDetalleTablaDato";
            textBox16.ClassName = "reciboDetalleTablaDato";
            textBox17.ClassName = "reciboDetalleTablaDato";
            textBox18.ClassName = "reciboDetalleTablaDato";
            textBox19.ClassName = "reciboDetalleTablaDato";
            textBox20.ClassName = "reciboDetalleTablaDato";
            textBox21.ClassName = "reciboDetalleTablaDato";
            textBox22.ClassName = "reciboDetalleTablaDato";
            textBox23.ClassName = "reciboDetalleTablaEnun";

        }
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            string resourceFileName = "PagoReciboDetalle.resx";
            System.Resources.ResourceManager resources = Resources.PagoReciboDetalle.ResourceManager;
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
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
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23});
            this.detail.Height = 0.1875F;
            this.detail.Name = "detail";
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.DataField = "tipo_pago";
            this.textBox12.DistinctField = null;
            this.textBox12.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox12.Location = ((System.Drawing.PointF)(resources.GetObject("textBox12.Location")));
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = null;
            this.textBox12.Size = new System.Drawing.SizeF(0.5F, 0.1875F);
            this.textBox12.Text = null;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.DataField = "fecha";
            this.textBox13.DistinctField = null;
            this.textBox13.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox13.Location = ((System.Drawing.PointF)(resources.GetObject("textBox13.Location")));
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = "dd/MM/yy";
            this.textBox13.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox13.Text = null;
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DataField = "interes_fecha";
            this.textBox14.DistinctField = null;
            this.textBox14.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox14.Location = ((System.Drawing.PointF)(resources.GetObject("textBox14.Location")));
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = "dd/MM/yy";
            this.textBox14.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox14.Text = null;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.DataField = "fecha_proximo";
            this.textBox15.DistinctField = null;
            this.textBox15.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox15.Location = ((System.Drawing.PointF)(resources.GetObject("textBox15.Location")));
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = "dd/MM/yy";
            this.textBox15.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
            this.textBox15.Text = null;
            // 
            // textBox16
            // 
            this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.DataField = "string_cuotas";
            this.textBox16.DistinctField = null;
            this.textBox16.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox16.Location = ((System.Drawing.PointF)(resources.GetObject("textBox16.Location")));
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = null;
            this.textBox16.Size = new System.Drawing.SizeF(0.5F, 0.1875F);
            this.textBox16.Text = null;
            // 
            // textBox17
            // 
            this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.DataField = "monto_pago";
            this.textBox17.DistinctField = null;
            this.textBox17.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox17.Location = ((System.Drawing.PointF)(resources.GetObject("textBox17.Location")));
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = null;
            this.textBox17.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
            this.textBox17.Text = null;
            // 
            // textBox18
            // 
            this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.DataField = "seguro";
            this.textBox18.DistinctField = null;
            this.textBox18.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox18.Location = ((System.Drawing.PointF)(resources.GetObject("textBox18.Location")));
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = null;
            this.textBox18.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
            this.textBox18.Text = null;
            // 
            // textBox19
            // 
            this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.DataField = "mantenimiento_sus";
            this.textBox19.DistinctField = null;
            this.textBox19.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox19.Location = ((System.Drawing.PointF)(resources.GetObject("textBox19.Location")));
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = null;
            this.textBox19.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
            this.textBox19.Text = null;
            // 
            // textBox20
            // 
            this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.DataField = "interes";
            this.textBox20.DistinctField = null;
            this.textBox20.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox20.Location = ((System.Drawing.PointF)(resources.GetObject("textBox20.Location")));
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = null;
            this.textBox20.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
            this.textBox20.Text = null;
            // 
            // textBox21
            // 
            this.textBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.DataField = "amortizacion";
            this.textBox21.DistinctField = null;
            this.textBox21.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox21.Location = ((System.Drawing.PointF)(resources.GetObject("textBox21.Location")));
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = null;
            this.textBox21.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
            this.textBox21.Text = null;
            // 
            // textBox22
            // 
            this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.DataField = "saldo";
            this.textBox22.DistinctField = null;
            this.textBox22.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox22.Location = ((System.Drawing.PointF)(resources.GetObject("textBox22.Location")));
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = null;
            this.textBox22.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
            this.textBox22.Text = null;
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
            this.textBox1.Size = new System.Drawing.SizeF(0.5F, 0.375F);
            this.textBox1.Text = "No. Pago";
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
            this.textBox2.Size = new System.Drawing.SizeF(0.6875F, 0.375F);
            this.textBox2.Text = "Fecha Pago";
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
            this.textBox3.Size = new System.Drawing.SizeF(0.6875F, 0.375F);
            this.textBox3.Text = "F. Pago Interes";
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
            this.textBox4.Size = new System.Drawing.SizeF(0.6875F, 0.375F);
            this.textBox4.Text = "F. Prox. Pago";
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
            this.textBox5.Size = new System.Drawing.SizeF(0.5F, 0.375F);
            this.textBox5.Text = "Cuotas";
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
            this.textBox6.Size = new System.Drawing.SizeF(0.5625F, 0.375F);
            this.textBox6.Text = "Pago ($us)";
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
            this.textBox7.Size = new System.Drawing.SizeF(0.5625F, 0.375F);
            this.textBox7.Text = "Seguro ($us)";
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
            this.textBox8.Size = new System.Drawing.SizeF(0.5625F, 0.375F);
            this.textBox8.Text = "Manten. ($us)";
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
            this.textBox9.Size = new System.Drawing.SizeF(0.5625F, 0.375F);
            this.textBox9.Text = "Interés ($us)";
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
            this.textBox10.Size = new System.Drawing.SizeF(0.5625F, 0.375F);
            this.textBox10.Text = "Amort. ($us)";
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
            this.textBox11.Size = new System.Drawing.SizeF(0.625F, 0.375F);
            this.textBox11.Text = "Saldo ($us)";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.textBox11});
            this.groupHeader1.Height = 0.3958333F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // textBox23
            // 
            this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.DistinctField = null;
            this.textBox23.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox23.Location = ((System.Drawing.PointF)(resources.GetObject("textBox23.Location")));
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = null;
            this.textBox23.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
            this.textBox23.Text = "Pago:";
            // 
            // PagoReciboDetalle
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.125F;
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.ReportStart += new System.EventHandler(this.PagoReciboDetalle_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();

        }
        #endregion

        
    }
}