using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web;


/// <summary>
/// Summary description for rpt_asignacion_recibos.
/// </summary>
/// 
   public class rpt_asignacion_recibos : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private ReportHeader reportHeader1;
        private ReportFooter reportFooter1;
        private GroupHeader groupHeader1;
       private GroupFooter groupFooter1;
       private GroupHeader groupHeader2;
       private GroupFooter groupFooter2;
       private TextBox textBox1;
       private TextBox textBox2;
       private TextBox txtcobrador;
       private TextBox textBox6;
       private TextBox textBox4;
       private TextBox textBox5;
       private TextBox textBox7;
       private TextBox textBox8;
       private TextBox textBox11;
       private TextBox textBox10;
       private TextBox textBox9;
       private TextBox textBox13;
       private TextBox textBox15;
       private TextBox textBox36;
       private Picture picture1;
       private TextBox textBox3;
       private TextBox textBox12;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public rpt_asignacion_recibos()
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
        public void Encabezado(DateTime Desde, DateTime Hasta)
        {
            //terrasur.usuario usrObj = new terrasur.usuario(Id_usuario);
            //txtcobrador.Text = usrObj.nombres + " " + usrObj.paterno + " " + usrObj.materno;
            textBox6.Text = Desde.ToString("d");
            textBox7.Text = Hasta.ToString("d");

        }
        private void rpt_asignacion_recibos_ReportStart(object sender, EventArgs e)
        {
            //MARGENES
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Right = 0.5F;
            this.PageSettings.Margins.Left = 0.5F;

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
            textBox36.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        }
        public void CargarEstilos()
        {
            textBox1.ClassName = "estiloTitulo";

            textBox3.ClassName = "estiloEncabEnun";
            textBox12.ClassName = "estiloEncabDato"; 

            textBox2.ClassName = "estiloEncabEnun";
            txtcobrador.ClassName = "estiloEncabDato"; 

            textBox4.ClassName = "estiloEncabEnun";
            textBox5.ClassName = "estiloEncabEnun";
            textBox6.ClassName = "estiloEncabDato";
            textBox7.ClassName = "estiloEncabDato";

            textBox8.ClassName = "estiloDetalleEnun";
            textBox10.ClassName = "estiloDetalleEnun";
            textBox11.ClassName = "estiloDetalleEnun";
            
            textBox9.ClassName = "estiloEncabDato";
            textBox13.ClassName = "estiloEncabDato";
            textBox15.ClassName = "estiloEncabDato";

            textBox36.ClassName = "estiloFecha";
        }
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_asignacion_recibos));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.txtcobrador = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcobrador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
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
            this.textBox9,
            this.textBox13,
            this.textBox15});
            this.detail.Height = 0.2187501F;
            this.detail.Name = "detail";
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
            this.textBox9.DataField = "desde";
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 3.8125F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "";
            this.textBox9.Text = null;
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.625F;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightColor = System.Drawing.Color.Black;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopColor = System.Drawing.Color.Black;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.DataField = "hasta";
            this.textBox13.Height = 0.1875F;
            this.textBox13.Left = 4.4375F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "";
            this.textBox13.Text = null;
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.625F;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightColor = System.Drawing.Color.Black;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopColor = System.Drawing.Color.Black;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.DataField = "fecha";
            this.textBox15.Height = 0.1979167F;
            this.textBox15.Left = 2.8125F;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "";
            this.textBox15.Text = null;
            this.textBox15.Top = 0F;
            this.textBox15.Width = 1F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox36,
            this.picture1,
            this.textBox4,
            this.textBox6,
            this.textBox5,
            this.textBox7});
            this.reportHeader1.Height = 0.9791667F;
            this.reportHeader1.Name = "reportHeader1";
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
            this.textBox1.Left = 0F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "";
            this.textBox1.Text = "Asignación de recibos oficiales a cobradores";
            this.textBox1.Top = 0.3125F;
            this.textBox1.Width = 6.5F;
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
            this.textBox36.Height = 0.1875F;
            this.textBox36.Left = 2.5625F;
            this.textBox36.Name = "textBox36";
            this.textBox36.Style = "";
            this.textBox36.Text = null;
            this.textBox36.Top = 0.0625F;
            this.textBox36.Width = 3.9375F;
            // 
            // picture1
            // 
            this.picture1.Border.BottomColor = System.Drawing.Color.Black;
            this.picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.LeftColor = System.Drawing.Color.Black;
            this.picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.RightColor = System.Drawing.Color.Black;
            this.picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.TopColor = System.Drawing.Color.Black;
            this.picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Height = 0.25F;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.Top = 0F;
            this.picture1.Width = 2.125F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox3,
            this.textBox12});
            this.groupHeader1.DataField = "negocio";
            this.groupHeader1.Height = 0.1979167F;
            this.groupHeader1.Name = "groupHeader1";
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
            this.textBox2.Left = 0.75F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "";
            this.textBox2.Text = "Cobrador:";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.6875F;
            // 
            // txtcobrador
            // 
            this.txtcobrador.Border.BottomColor = System.Drawing.Color.Black;
            this.txtcobrador.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtcobrador.Border.LeftColor = System.Drawing.Color.Black;
            this.txtcobrador.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtcobrador.Border.RightColor = System.Drawing.Color.Black;
            this.txtcobrador.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtcobrador.Border.TopColor = System.Drawing.Color.Black;
            this.txtcobrador.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtcobrador.DataField = "cobrador";
            this.txtcobrador.Height = 0.1875F;
            this.txtcobrador.Left = 1.5F;
            this.txtcobrador.Name = "txtcobrador";
            this.txtcobrador.Style = "";
            this.txtcobrador.Text = null;
            this.txtcobrador.Top = 0F;
            this.txtcobrador.Width = 1.25F;
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
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 2.8125F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "";
            this.textBox6.Text = null;
            this.textBox6.Top = 0.5F;
            this.textBox6.Width = 1.625F;
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
            this.textBox4.Left = 1.5F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "";
            this.textBox4.Text = "Desde:";
            this.textBox4.Top = 0.5F;
            this.textBox4.Width = 1.25F;
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
            this.textBox5.Left = 1.5F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "";
            this.textBox5.Text = "Hasta:";
            this.textBox5.Top = 0.75F;
            this.textBox5.Width = 1.25F;
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
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 2.8125F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "";
            this.textBox7.Text = null;
            this.textBox7.Top = 0.75F;
            this.textBox7.Width = 1.625F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // groupHeader2
            // 
            this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox8,
            this.textBox11,
            this.textBox10,
            this.textBox2,
            this.txtcobrador});
            this.groupHeader2.DataField = "id_usuario";
            this.groupHeader2.Height = 0.2083333F;
            this.groupHeader2.Name = "groupHeader2";
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
            this.textBox8.Height = 0.1979167F;
            this.textBox8.Left = 2.8125F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "";
            this.textBox8.Text = "Fecha";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 1F;
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
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 4.4375F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "";
            this.textBox11.Text = "Al";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.625F;
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
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 3.8125F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "";
            this.textBox10.Text = "Del";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.625F;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
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
            this.textBox3.Left = 0F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "";
            this.textBox3.Text = "Negocio:";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.6875F;
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
            this.textBox12.DataField = "negocio";
            this.textBox12.Height = 0.1875F;
            this.textBox12.Left = 0.75F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "";
            this.textBox12.Text = "textBox12";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 2F;
            // 
            // rpt_asignacion_recibos
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.583333F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rpt_asignacion_recibos_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcobrador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    
    }
