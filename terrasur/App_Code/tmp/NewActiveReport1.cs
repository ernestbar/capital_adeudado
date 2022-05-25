using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for NewActiveReport1.
/// </summary>
public class NewActiveReport1 : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
    private DataDynamics.ActiveReports.Detail detail;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label8;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Field par1;
    private TextBox textBox1;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label15;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public NewActiveReport1()
	{
		// Required for Windows Form Designer support
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

	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        string resourceFileName = "NewActiveReport1.resx";
        System.Resources.ResourceManager resources = Resources.NewActiveReport1.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.par1 = new DataDynamics.ActiveReports.Field();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Height = 0F;
        this.pageHeader.Name = "pageHeader";
        // 
        // detail
        // 
        this.detail.CanShrink = true;
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label4,
            this.label5,
            this.label6,
            this.label8,
            this.label10});
        this.detail.Height = 0.1979167F;
        this.detail.Name = "detail";
        // 
        // label4
        // 
        this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.DataField = "nombre";
        this.label4.Font = new System.Drawing.Font("Arial", 10F);
        this.label4.HyperLink = null;
        this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label4.Text = "";
        // 
        // label5
        // 
        this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.DataField = "paterno";
        this.label5.Font = new System.Drawing.Font("Arial", 10F);
        this.label5.HyperLink = null;
        this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label5.Text = "";
        // 
        // label6
        // 
        this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.DataField = "nit";
        this.label6.Font = new System.Drawing.Font("Arial", 10F);
        this.label6.HyperLink = null;
        this.label6.Location = ((System.Drawing.PointF)(resources.GetObject("label6.Location")));
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label6.Text = "";
        // 
        // label8
        // 
        this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.DataField = "num";
        this.label8.Font = new System.Drawing.Font("Arial", 10F);
        this.label8.HyperLink = null;
        this.label8.Location = ((System.Drawing.PointF)(resources.GetObject("label8.Location")));
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label8.Text = "";
        // 
        // label10
        // 
        this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.DataField = "clase";
        this.label10.Font = new System.Drawing.Font("Arial", 10F);
        this.label10.HyperLink = null;
        this.label10.Location = ((System.Drawing.PointF)(resources.GetObject("label10.Location")));
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label10.Text = "";
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
            this.label15});
        this.reportHeader1.Height = 0.2604167F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // par1
        // 
        this.par1.DefaultValue = "0";
        this.par1.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.Int32;
        this.par1.Formula = null;
        this.par1.Name = "par1";
        this.par1.Tag = null;
        // 
        // textBox1
        // 
        this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.DataField = "num";
        this.textBox1.DistinctField = null;
        this.textBox1.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = null;
        this.textBox1.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox1.Text = "textBox1";
        // 
        // groupHeader1
        // 
        this.groupHeader1.Height = 0F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1});
        this.groupFooter1.Height = 0.25F;
        this.groupFooter1.Name = "groupFooter1";
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
        this.label11.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label11.Text = "clase";
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
        this.label12.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label12.Text = "nombre";
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
        this.label13.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label13.Text = "paterno";
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
        this.label14.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label14.Text = "nit";
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
        this.label15.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label15.Text = "num";
        // 
        // NewActiveReport1
        // 
        this.CalculatedFields.Add(this.par1);
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.ReportStart += new System.EventHandler(this.NewActiveReport1_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();

	}
	#endregion

    private void NewActiveReport1_ReportStart(object sender, EventArgs e)
    {
        this.DataSource = Class1.abc(int.Parse(par1.Value.ToString()));
    }
}
