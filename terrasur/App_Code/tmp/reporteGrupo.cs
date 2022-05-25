using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for reporteGrupo.
/// </summary>
public class reporteGrupo : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label4;
    private TextBox textBox1;
    private Field param_num;
    private Label label11;
    private Label label12;
    private Label label19;
    private Label label18;
    private Label label20;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private Label label1;
    private Label label2;
    private GroupHeader groupHeader2;
    private GroupFooter groupFooter2;
    private TextBox textBox7;
    private Label label3;
    private Line line1;
    private Line line2;
    private Label label5;
    private TextBox textBox8;
    private Label label6;
    private TextBox textBox9;
    private TextBox textBox2;
    private Label label17;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public reporteGrupo()
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

	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        string resourceFileName = "reporteGrupo.resx";
        System.Resources.ResourceManager resources = Resources.reporteGrupo.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label19 = new DataDynamics.ActiveReports.Label();
        this.label18 = new DataDynamics.ActiveReports.Label();
        this.label17 = new DataDynamics.ActiveReports.Label();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.param_num = new DataDynamics.ActiveReports.Field();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
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
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6});
        this.detail.Height = 0.1979167F;
        this.detail.KeepTogether = true;
        this.detail.Name = "detail";
        // 
        // textBox2
        // 
        this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.DataField = "clase";
        this.textBox2.DistinctField = null;
        this.textBox2.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = null;
        this.textBox2.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox2.Text = "textBox2";
        // 
        // textBox3
        // 
        this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.DataField = "nombre";
        this.textBox3.DistinctField = null;
        this.textBox3.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = null;
        this.textBox3.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox3.Text = "textBox3";
        // 
        // textBox4
        // 
        this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.DataField = "paterno";
        this.textBox4.DistinctField = null;
        this.textBox4.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
        this.textBox4.Name = "textBox4";
        this.textBox4.OutputFormat = null;
        this.textBox4.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox4.Text = "textBox4";
        // 
        // textBox5
        // 
        this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.DataField = "nit";
        this.textBox5.DistinctField = null;
        this.textBox5.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
        this.textBox5.Name = "textBox5";
        this.textBox5.OutputFormat = null;
        this.textBox5.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox5.Text = "textBox5";
        // 
        // textBox6
        // 
        this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.DataField = "num";
        this.textBox6.DistinctField = null;
        this.textBox6.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
        this.textBox6.Name = "textBox6";
        this.textBox6.OutputFormat = null;
        this.textBox6.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox6.Text = "textBox6";
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
        // 
        // groupHeader1
        // 
        this.groupHeader1.ColumnLayout = false;
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label11,
            this.label12,
            this.label19,
            this.label18,
            this.label17,
            this.label20,
            this.label4,
            this.label5,
            this.textBox8});
        this.groupHeader1.DataField = "clase";
        this.groupHeader1.Height = 0.4583334F;
        this.groupHeader1.KeepTogether = true;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // label11
        // 
        this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label11.HyperLink = null;
        this.label11.Location = ((System.Drawing.PointF)(resources.GetObject("label11.Location")));
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.label11.Text = "Clase:";
        // 
        // label12
        // 
        this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.DataField = "clase";
        this.label12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label12.HyperLink = null;
        this.label12.Location = ((System.Drawing.PointF)(resources.GetObject("label12.Location")));
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label12.Text = "label12";
        // 
        // label19
        // 
        this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Font = new System.Drawing.Font("Arial", 10F);
        this.label19.HyperLink = null;
        this.label19.Location = ((System.Drawing.PointF)(resources.GetObject("label19.Location")));
        this.label19.Name = "label19";
        this.label19.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label19.Text = "paterno";
        // 
        // label18
        // 
        this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Font = new System.Drawing.Font("Arial", 10F);
        this.label18.HyperLink = null;
        this.label18.Location = ((System.Drawing.PointF)(resources.GetObject("label18.Location")));
        this.label18.Name = "label18";
        this.label18.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label18.Text = "nombre";
        // 
        // label17
        // 
        this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Font = new System.Drawing.Font("Arial", 10F);
        this.label17.HyperLink = null;
        this.label17.Location = ((System.Drawing.PointF)(resources.GetObject("label17.Location")));
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label17.Text = "clase";
        // 
        // label20
        // 
        this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Font = new System.Drawing.Font("Arial", 10F);
        this.label20.HyperLink = null;
        this.label20.Location = ((System.Drawing.PointF)(resources.GetObject("label20.Location")));
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label20.Text = "nit";
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
        this.label4.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.label4.Text = "num";
        // 
        // label5
        // 
        this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label5.HyperLink = null;
        this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.SizeF(1.0625F, 0.1875F);
        this.label5.Text = "Nº de registros";
        // 
        // textBox8
        // 
        this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.DataField = "clase";
        this.textBox8.DistinctField = null;
        this.textBox8.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox8.Location = ((System.Drawing.PointF)(resources.GetObject("textBox8.Location")));
        this.textBox8.Name = "textBox8";
        this.textBox8.OutputFormat = null;
        this.textBox8.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox8.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox8.SummaryGroup = "groupHeader1";
        this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox8.Text = "textBox8";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.label1,
            this.label2,
            this.line2});
        this.groupFooter1.Height = 0.28125F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // textBox1
        // 
        this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.DataField = "num";
        this.textBox1.DistinctField = null;
        this.textBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = null;
        this.textBox1.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox1.SummaryGroup = "groupHeader1";
        this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox1.Text = "textBox1";
        // 
        // label1
        // 
        this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label1.HyperLink = null;
        this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.SizeF(1.0625F, 0.1875F);
        this.label1.Text = "Subtotal clase: ";
        // 
        // label2
        // 
        this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.DataField = "clase";
        this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label2.HyperLink = null;
        this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
        this.label2.Text = "label2";
        // 
        // line2
        // 
        this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.X1 = 1F;
        this.line2.X2 = 6F;
        this.line2.Y1 = 0.02F;
        this.line2.Y2 = 0.02F;
        // 
        // param_num
        // 
        this.param_num.DefaultValue = null;
        this.param_num.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.Int32;
        this.param_num.Formula = null;
        this.param_num.Name = "param_num";
        this.param_num.Tag = null;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.textBox9});
        this.groupHeader2.Height = 0.21875F;
        this.groupHeader2.Name = "groupHeader2";
        // 
        // label6
        // 
        this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label6.HyperLink = null;
        this.label6.Location = ((System.Drawing.PointF)(resources.GetObject("label6.Location")));
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.SizeF(1.0625F, 0.1875F);
        this.label6.Text = "Nº de registros";
        // 
        // textBox9
        // 
        this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.DataField = "clase";
        this.textBox9.DistinctField = null;
        this.textBox9.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox9.Location = ((System.Drawing.PointF)(resources.GetObject("textBox9.Location")));
        this.textBox9.Name = "textBox9";
        this.textBox9.OutputFormat = null;
        this.textBox9.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox9.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox9.Text = "textBox8";
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.label3,
            this.line1});
        this.groupFooter2.Height = 0.3125F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // textBox7
        // 
        this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.DataField = "num";
        this.textBox7.DistinctField = null;
        this.textBox7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.textBox7.Location = ((System.Drawing.PointF)(resources.GetObject("textBox7.Location")));
        this.textBox7.Name = "textBox7";
        this.textBox7.OutputFormat = null;
        this.textBox7.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox7.Text = "textBox7";
        // 
        // label3
        // 
        this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.label3.HyperLink = null;
        this.label3.Location = ((System.Drawing.PointF)(resources.GetObject("label3.Location")));
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.SizeF(1.6875F, 0.1875F);
        this.label3.Text = "Total (todas las clases):";
        // 
        // line1
        // 
        this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.LineWeight = 3F;
        this.line1.Name = "line1";
        this.line1.X1 = 0F;
        this.line1.X2 = 6.5625F;
        this.line1.Y1 = 0.02F;
        this.line1.Y2 = 0.02F;
        // 
        // reporteGrupo
        // 
        this.CalculatedFields.Add(this.param_num);
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.5625F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.pageFooter);
        this.ReportStart += new System.EventHandler(this.reporteGrupo_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();

	}
	#endregion

    private void reporteGrupo_ReportStart(object sender, EventArgs e)
    {
        System.Data.DataView dv = Class1.abc(Int32.Parse(param_num.Value.ToString())).DefaultView;
        dv.Sort = "clase";
        this.DataSource = dv;
    }
}
