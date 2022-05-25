using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_tipo_cambio_historico.
/// </summary>
public class rpt_tipo_cambio_historico : DataDynamics.ActiveReports.ActiveReport3
{
    public void CargarDatos(string inicio, string fin)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        label12.Text = inicio;
        label14.Text = fin;
    }
    private void rpt_tipo_cambio_historico_ReportStart(object sender, EventArgs e)
    {
        //MARGENES
        this.PageSettings.Margins.Top = 0.5F;
        this.PageSettings.Margins.Bottom = 0.5F;
        this.PageSettings.Margins.Right = 0.5F;
        this.PageSettings.Margins.Left = 0.5F;

        EstilosBase rpt = new EstilosBase();
        rpt.LoadLayout(System.Web.HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBase.rpx");
        for (int i = 4; i < rpt.StyleSheet.Count; i++)
        {
            DataDynamics.ActiveReports.Style s = rpt.StyleSheet[i];
            this.StyleSheet.Add(s.Name);
            if (s.Value != null) this.StyleSheet[i].Value = s.Value;
        }
        CargarEstilos();
    }

    public void CargarEstilos()
    {
        //Report (Date):
        textBox1.ClassName = "estiloFecha";
        //Report (Title):
        label15.ClassName = "estiloTitulo";
        //Report (Header):
        label11.ClassName = "estiloEncabEnun";
        label13.ClassName = "estiloEncabEnun";
        label12.ClassName = "estiloEncabDato";
        label14.ClassName = "estiloEncabDato";
        //Detalle (header):
        label1.ClassName = "estiloDetalleEnun";
        label2.ClassName = "estiloDetalleEnun";
        label3.ClassName = "estiloDetalleEnun";
        label4.ClassName = "estiloDetalleEnun";
        label5.ClassName = "estiloDetalleEnun";
        //Detalle (datos):
        textBox2.ClassName = "estiloDetalleDatoString";
        textBox3.ClassName = "estiloDetalleDato";
        textBox4.ClassName = "estiloDetalleDato";
        textBox5.ClassName = "estiloDetalleDatoString";
        textBox6.ClassName = "estiloDetalleDatoString";
        //Report (footer):
        //Cometario:
    } 


    private DataDynamics.ActiveReports.PageHeader pageHeader;
    private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label15;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox1;
    private Picture picture1;
    private DataDynamics.ActiveReports.PageFooter pageFooter;

    public rpt_tipo_cambio_historico()
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

    #region ActiveReport Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        string resourceFileName = "rpt_tipo_cambio_historico.resx";
        System.Resources.ResourceManager resources = Resources.rpt_tipo_cambio_historico.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5});
        this.pageHeader.Height = 0.3645833F;
        this.pageHeader.Name = "pageHeader";
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
        this.label1.Size = new System.Drawing.SizeF(0.9375F, 0.1875F);
        this.label1.Text = "Fecha";
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
        this.label2.Size = new System.Drawing.SizeF(0.625F, 0.375F);
        this.label2.Text = "T/C Compra";
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
        this.label3.Size = new System.Drawing.SizeF(0.625F, 0.375F);
        this.label3.Text = "T/C Venta";
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
        this.label4.Size = new System.Drawing.SizeF(2.4375F, 0.1875F);
        this.label4.Text = "Usuario";
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
        this.label5.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
        this.label5.Text = "Fecha de registro";
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6});
        this.detail.Height = 0.2083333F;
        this.detail.Name = "detail";
        // 
        // textBox2
        // 
        this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.DataField = "fecha";
        this.textBox2.DistinctField = null;
        this.textBox2.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = "dd/MM/yyyy";
        this.textBox2.Size = new System.Drawing.SizeF(0.9375F, 0.1875F);
        this.textBox2.Text = "textBox2";
        // 
        // textBox3
        // 
        this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.DataField = "compra";
        this.textBox3.DistinctField = null;
        this.textBox3.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = "#,##0.00";
        this.textBox3.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox3.Text = "textBox3";
        // 
        // textBox4
        // 
        this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.DataField = "venta";
        this.textBox4.DistinctField = null;
        this.textBox4.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
        this.textBox4.Name = "textBox4";
        this.textBox4.OutputFormat = "#,##0.00";
        this.textBox4.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox4.Text = "textBox4";
        // 
        // textBox5
        // 
        this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.DataField = "nombre_usuario";
        this.textBox5.DistinctField = null;
        this.textBox5.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
        this.textBox5.Name = "textBox5";
        this.textBox5.OutputFormat = null;
        this.textBox5.Size = new System.Drawing.SizeF(2.4375F, 0.1875F);
        this.textBox5.Text = "textBox5";
        // 
        // textBox6
        // 
        this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.DataField = "registro_fecha";
        this.textBox6.DistinctField = null;
        this.textBox6.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
        this.textBox6.Name = "textBox6";
        this.textBox6.OutputFormat = null;
        this.textBox6.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
        this.textBox6.Text = "textBox6";
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.textBox1,
            this.picture1});
        this.reportHeader1.Height = 1.15625F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // label11
        // 
        this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Font = new System.Drawing.Font("Arial", 10F);
        this.label11.HyperLink = null;
        this.label11.Location = ((System.Drawing.PointF)(resources.GetObject("label11.Location")));
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.label11.Text = "Desde:";
        // 
        // label12
        // 
        this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Font = new System.Drawing.Font("Arial", 10F);
        this.label12.HyperLink = null;
        this.label12.Location = ((System.Drawing.PointF)(resources.GetObject("label12.Location")));
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.SizeF(2.4375F, 0.1875F);
        this.label12.Text = "label12";
        // 
        // label13
        // 
        this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Font = new System.Drawing.Font("Arial", 10F);
        this.label13.HyperLink = null;
        this.label13.Location = ((System.Drawing.PointF)(resources.GetObject("label13.Location")));
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.label13.Text = "Hasta:";
        // 
        // label14
        // 
        this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Font = new System.Drawing.Font("Arial", 10F);
        this.label14.HyperLink = null;
        this.label14.Location = ((System.Drawing.PointF)(resources.GetObject("label14.Location")));
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.SizeF(2.4375F, 0.1875F);
        this.label14.Text = "label14";
        // 
        // label15
        // 
        this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Font = new System.Drawing.Font("Arial", 10F);
        this.label15.HyperLink = null;
        this.label15.Location = ((System.Drawing.PointF)(resources.GetObject("label15.Location")));
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.SizeF(6.375F, 0.375F);
        this.label15.Text = "Tipos de cambio históricos";
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
        this.textBox1.Size = new System.Drawing.SizeF(4.1875F, 0.1875F);
        this.textBox1.Text = "textBox1";
        // 
        // picture1
        // 
        this.picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.LineWeight = 0F;
        this.picture1.Location = ((System.Drawing.PointF)(resources.GetObject("picture1.Location")));
        this.picture1.Name = "picture1";
        this.picture1.Size = new System.Drawing.SizeF(2.125F, 0.25F);
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // rpt_tipo_cambio_historico
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.489583F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.ReportStart += new System.EventHandler(this.rpt_tipo_cambio_historico_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();

    }
    #endregion

}
