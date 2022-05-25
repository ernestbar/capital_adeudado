using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_proformaLiquidacion.
/// </summary>
public class rpt_proformaLiquidacion : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private TextBox textBox1;
    public SubReport subReport1;
    private Label label1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    public SubReport subReport3;
    public SubReport subReport4;
    private TextBox textBox121;
    private Picture picture1;
    public SubReport subReport2;

	public rpt_proformaLiquidacion()
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
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
			if(components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose( disposing );
	}
    private void rpt_proformaLiquidacion_ReportStart(object sender, EventArgs e)
    {
        //MARGENES
        //this.PageSettings.Margins.Top = 0.5F;
        //this.PageSettings.Margins.Bottom = 0.5F;
        //this.PageSettings.Margins.Right = 0.5F;
        //this.PageSettings.Margins.Left = 0.5F;

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
        Bordes();
        textBox121.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
    }
    public void CargarEstilos()
    {
        textBox121.ClassName = "estiloFecha";

        textBox1.ClassName = "estiloTitulo";

        label1.ClassName = "estiloNota";
        textBox2.ClassName = "estiloNota";
        textBox3.ClassName = "estiloNota";
        textBox4.ClassName = "estiloNota";
        textBox5.ClassName = "estiloNota";
    }
    public void LlenarDatos(int Id_contrato)
    {
        if (terrasur.contrato.Estado(Id_contrato,DateTime.Now) == 3)
        {
            textBox5.Text = "Liquidación EJECUTADA";
        }
        else
        {
            textBox5.Text = "Liquidación NO EJECUTADA";
        }
    }
    public void Bordes()
    {
        subReport3.Border.TopStyle = BorderLineStyle.Solid;
        subReport3.Border.LeftStyle = BorderLineStyle.Solid;
        subReport3.Border.RightStyle = BorderLineStyle.Solid;
        subReport3.Border.BottomStyle = BorderLineStyle.Solid;

        subReport4.Border.TopStyle = BorderLineStyle.Solid;
        subReport4.Border.LeftStyle = BorderLineStyle.Solid;
        subReport4.Border.RightStyle = BorderLineStyle.Solid;
        subReport4.Border.BottomStyle = BorderLineStyle.Solid;
    }
    #region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        string resourceFileName = "rpt_proformaLiquidacion.resx";
        System.Resources.ResourceManager resources = Resources.rpt_proformaLiquidacion.ResourceManager;
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.subReport1 = new DataDynamics.ActiveReports.SubReport();
        this.subReport2 = new DataDynamics.ActiveReports.SubReport();
        this.subReport3 = new DataDynamics.ActiveReports.SubReport();
        this.subReport4 = new DataDynamics.ActiveReports.SubReport();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox121 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.subReport2,
            this.subReport3,
            this.subReport4});
        this.detail.Height = 0.5104166F;
        this.detail.Name = "detail";
        // 
        // subReport1
        // 
        this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.CloseBorder = false;
        this.subReport1.Location = ((System.Drawing.PointF)(resources.GetObject("subReport1.Location")));
        this.subReport1.Name = "subReport1";
        this.subReport1.Report = null;
        this.subReport1.ReportName = "subReport1";
        this.subReport1.Size = new System.Drawing.SizeF(6.5F, 0.0625F);
        // 
        // subReport2
        // 
        this.subReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.CloseBorder = false;
        this.subReport2.Location = ((System.Drawing.PointF)(resources.GetObject("subReport2.Location")));
        this.subReport2.Name = "subReport2";
        this.subReport2.Report = null;
        this.subReport2.ReportName = "subReport1";
        this.subReport2.Size = new System.Drawing.SizeF(6.5F, 0.0625F);
        // 
        // subReport3
        // 
        this.subReport3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.CloseBorder = false;
        this.subReport3.Location = ((System.Drawing.PointF)(resources.GetObject("subReport3.Location")));
        this.subReport3.Name = "subReport3";
        this.subReport3.Report = null;
        this.subReport3.ReportName = "subReport1";
        this.subReport3.Size = new System.Drawing.SizeF(6.5F, 0.0625F);
        // 
        // subReport4
        // 
        this.subReport4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.CloseBorder = false;
        this.subReport4.Location = ((System.Drawing.PointF)(resources.GetObject("subReport4.Location")));
        this.subReport4.Name = "subReport4";
        this.subReport4.Report = null;
        this.subReport4.ReportName = "subReport1";
        this.subReport4.Size = new System.Drawing.SizeF(6.5F, 0.0625F);
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox121,
            this.picture1});
        this.reportHeader1.Height = 0.5416667F;
        this.reportHeader1.Name = "reportHeader1";
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
        this.textBox1.Size = new System.Drawing.SizeF(4.125F, 0.1875F);
        this.textBox1.Text = "Liquidación para transferencia de lote";
        // 
        // textBox121
        // 
        this.textBox121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.DistinctField = null;
        this.textBox121.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox121.Location = ((System.Drawing.PointF)(resources.GetObject("textBox121.Location")));
        this.textBox121.Name = "textBox121";
        this.textBox121.OutputFormat = null;
        this.textBox121.Size = new System.Drawing.SizeF(3.9375F, 0.1875F);
        this.textBox121.Text = null;
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
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5});
        this.reportFooter1.Height = 1.729167F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.label1.Size = new System.Drawing.SizeF(0.5F, 0.1875F);
        this.label1.Text = "Nota:";
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
        this.textBox2.Size = new System.Drawing.SizeF(5.625F, 0.1875F);
        this.textBox2.Text = "1.- Adjuntar fotocopia de C.I. con firma original del titular o titulares.";
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
        this.textBox3.Size = new System.Drawing.SizeF(5.625F, 0.5F);
        this.textBox3.Text = "2.- En caso de incluir a otra persona en la minuta, presentar carta de solicitud " +
            "de inclusión de nombre adjuntando C.I. (fotocopias) con firmas originales del o " +
            "los titulares y de la nueva persona.  ";
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
        this.textBox4.Size = new System.Drawing.SizeF(5.625F, 0.4375F);
        this.textBox4.Text = "3.- En caso de cambio de nombre, presentar carta de solicitud para realizar el ca" +
            "mbio, adjuntando C.I. (fotocopia) de la nueva persona y del o los titulares con " +
            "firmas originales.";
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
        this.textBox5.Size = new System.Drawing.SizeF(2.125F, 0.1875F);
        this.textBox5.Text = "textBox5";
        // 
        // rpt_proformaLiquidacion
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.5625F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.reportFooter1);
        this.ReportStart += new System.EventHandler(this.rpt_proformaLiquidacion_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();

	}
	#endregion

    
}
