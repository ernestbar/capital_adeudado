using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for srpt_EstadoCuenta.
/// </summary>
public class srpt_EstadoCuenta : DataDynamics.ActiveReports.ActiveReport3
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
    private SubReport subReport1;
    private SubReport subReport2;
    private TextBox textBox8;
    private Label label1;
    private Label label2;
    private Label label3;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public srpt_EstadoCuenta()
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
    public void DatosEstadoCuenta(int Id_contrato)
    {
        terrasur.contrato c = new terrasur.contrato(Id_contrato);
        textBox5.Text = c.precio_final.ToString("F2");
        textBox6.Text = c.capital_pagado.ToString("F2");
        textBox7.Text = c.saldo_capital.ToString("F2");
        Bordes();
        srpt_PagosRealizados sP1 = new srpt_PagosRealizados();
        subReport1.Report = sP1;
        sP1.DatosPagosRealizados(Id_contrato);
        srpt_PagosRestantes sP2 = new srpt_PagosRestantes();
        subReport2.Report = sP2;
        sP2.DatosPagosRestantes(Id_contrato);

        label1.Text = c.codigo_moneda;
        label2.Text = c.codigo_moneda;
        label3.Text = c.codigo_moneda;
    }
    public void Bordes()
    {
        subReport1.Border.TopStyle = BorderLineStyle.Solid;
        subReport1.Border.LeftStyle = BorderLineStyle.Solid;
        subReport1.Border.RightStyle = BorderLineStyle.Solid;
        subReport1.Border.BottomStyle = BorderLineStyle.Solid;

        subReport2.Border.TopStyle = BorderLineStyle.Solid;
        subReport2.Border.LeftStyle = BorderLineStyle.Solid;
        subReport2.Border.RightStyle = BorderLineStyle.Solid;
        subReport2.Border.BottomStyle = BorderLineStyle.Solid;
    }
    private void srpt_EstadoCuenta_ReportStart(object sender, EventArgs e)
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
        //textBox8.HyperLink = "reporteContratoEstadoCuentaDetalle.aspx";
    }
    public void CargarEstilos()
    {
        textBox1.ClassName = "estiloGrupoEnun";

        textBox2.ClassName = "estiloDetalleEnun";
        textBox3.ClassName = "estiloDetalleEnun";
        textBox4.ClassName = "estiloDetalleEnun";

        textBox5.ClassName = "estiloDetalleDato";
        textBox6.ClassName = "estiloDetalleDato";
        textBox7.ClassName = "estiloDetalleDato";
        label1.ClassName = "estiloDetalleDato";
        label2.ClassName = "estiloDetalleDato";
        label3.ClassName = "estiloDetalleDato";

        textBox8.ClassName = "estiloNota";
    }
    #region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        string resourceFileName = "srpt_EstadoCuenta.resx";
        System.Resources.ResourceManager resources = Resources.srpt_EstadoCuenta.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.subReport1 = new DataDynamics.ActiveReports.SubReport();
        this.subReport2 = new DataDynamics.ActiveReports.SubReport();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
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
            this.subReport1,
            this.subReport2,
            this.textBox8,
            this.label1,
            this.label2,
            this.label3});
        this.detail.Height = 1.885417F;
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
        this.textBox1.Size = new System.Drawing.SizeF(1.3125F, 0.1875F);
        this.textBox1.Text = "Estado de cuenta";
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
        this.textBox2.Text = "Capital Total";
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
        this.textBox3.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox3.Text = "Amortiz. Total";
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
        this.textBox4.Text = "Saldo a Capital";
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
        this.textBox5.OutputFormat = "#,##0.00";
        this.textBox5.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
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
        this.textBox6.OutputFormat = "#,##0.00";
        this.textBox6.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
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
        this.textBox7.OutputFormat = "#,##0.00";
        this.textBox7.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
        this.textBox7.Text = null;
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
        this.subReport1.Size = new System.Drawing.SizeF(6.25F, 0.375F);
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
        this.subReport2.ReportName = "subReport2";
        this.subReport2.Size = new System.Drawing.SizeF(6.25F, 0.4375F);
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
        this.textBox8.Size = new System.Drawing.SizeF(1.9375F, 0.1875F);
        this.textBox8.Text = "Ver otros reportes del contrato";
        this.textBox8.Visible = false;
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
        this.label1.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
        this.label1.Text = "$us";
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
        this.label3.Size = new System.Drawing.SizeF(0.3125F, 0.1875F);
        this.label3.Text = "$us";
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
        // 
        // srpt_EstadoCuenta
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.ReportStart += new System.EventHandler(this.srpt_EstadoCuenta_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();

	}
	#endregion

    
}
