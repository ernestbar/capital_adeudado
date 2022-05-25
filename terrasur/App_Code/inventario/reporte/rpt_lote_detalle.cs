using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for rpt_lote_detalle.
/// </summary>
public class rpt_lote_detalle : DataDynamics.ActiveReports.ActiveReport3
{
    private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private DataDynamics.ActiveReports.GroupHeader groupHeader1;
    private DataDynamics.ActiveReports.GroupFooter groupFooter1;
    private DataDynamics.ActiveReports.ReportHeader reportHeader1;
    private DataDynamics.ActiveReports.ReportFooter reportFooter1;
    private DataDynamics.ActiveReports.GroupHeader groupHeader2;
    private DataDynamics.ActiveReports.GroupFooter groupFooter2;
    private DataDynamics.ActiveReports.TextBox textBox1;
    private DataDynamics.ActiveReports.TextBox textBox2;
    private DataDynamics.ActiveReports.TextBox textBox3;
    private DataDynamics.ActiveReports.TextBox textBox4;
    private DataDynamics.ActiveReports.TextBox textBox5;
    private DataDynamics.ActiveReports.TextBox textBox6;
    private DataDynamics.ActiveReports.TextBox textBox7;
    private DataDynamics.ActiveReports.TextBox textBox8;
    private DataDynamics.ActiveReports.TextBox textBox9;
    private DataDynamics.ActiveReports.TextBox textBox10;
    private DataDynamics.ActiveReports.TextBox textBox11;
    private DataDynamics.ActiveReports.TextBox textBox12;
    private DataDynamics.ActiveReports.TextBox textBox13;
    private DataDynamics.ActiveReports.TextBox textBox14;
    private DataDynamics.ActiveReports.TextBox textBox15;
    private DataDynamics.ActiveReports.TextBox textBox16;
    private DataDynamics.ActiveReports.TextBox textBox17;
    private DataDynamics.ActiveReports.TextBox textBox18;
    private DataDynamics.ActiveReports.TextBox textBox19;
    private DataDynamics.ActiveReports.TextBox textBox20;
    private DataDynamics.ActiveReports.TextBox textBox21;
    private DataDynamics.ActiveReports.TextBox textBox22;
    private DataDynamics.ActiveReports.TextBox textBox23;
    private DataDynamics.ActiveReports.TextBox textBox24;
    private DataDynamics.ActiveReports.TextBox textBox25;
    private DataDynamics.ActiveReports.TextBox textBox35;
    private DataDynamics.ActiveReports.TextBox textBox26;
    private DataDynamics.ActiveReports.TextBox textBox27;
    private DataDynamics.ActiveReports.TextBox textBox28;
    private DataDynamics.ActiveReports.TextBox textBox29;
    private DataDynamics.ActiveReports.TextBox textBox30;
    private DataDynamics.ActiveReports.TextBox textBox31;
    private DataDynamics.ActiveReports.TextBox textBox32;
    private DataDynamics.ActiveReports.TextBox textBox33;
    private DataDynamics.ActiveReports.TextBox textBox34;
    private DataDynamics.ActiveReports.TextBox textBox36;
    private DataDynamics.ActiveReports.TextBox textBox37;
    private DataDynamics.ActiveReports.TextBox textBox38;
    private DataDynamics.ActiveReports.TextBox textBox39;
    private DataDynamics.ActiveReports.Line line2;
    private DataDynamics.ActiveReports.Line line3;
    private DataDynamics.ActiveReports.Line line1;
    private DataDynamics.ActiveReports.Picture picture1;
    private DataDynamics.ActiveReports.TextBox textBox41;
    private DataDynamics.ActiveReports.TextBox textBox42;
    private DataDynamics.ActiveReports.TextBox textBox40;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_lote_detalle()
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
    private void rpt_lote_detalle_ReportStart(object sender, EventArgs e)
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
        textBox36.ClassName = "estiloFecha";
        textBox21.ClassName = "estiloTitulo";
        textBox22.ClassName = "estiloEncabEnun";
        textBox3.ClassName = "estiloEncabDato";

        textBox23.ClassName = "estiloGrupoEnun";
        textBox1.ClassName = "estiloEncabDato";

        textBox24.ClassName = "estiloGrupoEnun";
        textBox2.ClassName = "estiloEncabDato";

        textBox4.ClassName = "estiloDetalleDatoString";
        textBox5.ClassName = "estiloDetalleDato";
        textBox6.ClassName = "estiloDetalleDato";
        textBox7.ClassName = "estiloDetalleDato";
        textBox8.ClassName = "estiloDetalleDatoString";
        textBox9.ClassName = "estiloDetalleDatoString";
        textBox10.ClassName = "estiloDetalleDato";
        textBox11.ClassName = "estiloDetalleDatoString";
        textBox12.ClassName = "estiloDetalleDato";
        textBox19.ClassName = "estiloDetalleDatoString";
      
        textBox20.ClassName = "estiloDetalleEnun";
        textBox25.ClassName = "estiloDetalleEnun";
        textBox26.ClassName = "estiloDetalleEnun";
        textBox27.ClassName = "estiloDetalleEnun";
        textBox28.ClassName = "estiloDetalleEnun";
        textBox29.ClassName = "estiloDetalleEnun";
        textBox30.ClassName = "estiloDetalleEnun";
        textBox31.ClassName = "estiloDetalleEnun";
        textBox32.ClassName = "estiloDetalleEnun";
        textBox33.ClassName = "estiloDetalleEnun";

        textBox34.ClassName = "estiloSubtotalEnun";
        textBox13.ClassName = "estiloSubtotalEnun";
        textBox40.ClassName = "estiloSubtotal";
        textBox14.ClassName = "estiloSubtotal";
        textBox15.ClassName = "estiloSubtotal";
        
        textBox35.ClassName = "estiloSubtotalEnun";
        textBox16.ClassName = "estiloSubtotalEnun";
        textBox41.ClassName = "estiloSubtotal";
        textBox17.ClassName = "estiloSubtotal";
        textBox18.ClassName = "estiloSubtotal";

        textBox37.ClassName = "estiloTotalEnun";
        textBox42.ClassName = "estiloTotal";
        textBox38.ClassName = "estiloTotal";
        textBox39.ClassName = "estiloTotal";
    }        
	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        string resourceFileName = "rpt_lote_detalle.resx";
        System.Resources.ResourceManager resources = Resources.rpt_lote_detalle.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox20,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox33});
        this.pageHeader.Height = 0.3125F;
        this.pageHeader.Name = "pageHeader";
        // 
        // textBox20
        // 
        this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.DistinctField = null;
        this.textBox20.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox20.Location = ((System.Drawing.PointF)(resources.GetObject("textBox20.Location")));
        this.textBox20.Name = "textBox20";
        this.textBox20.OutputFormat = null;
        this.textBox20.Size = new System.Drawing.SizeF(0.5625F, 0.3125F);
        this.textBox20.Text = "Codigo";
        // 
        // textBox25
        // 
        this.textBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.DistinctField = null;
        this.textBox25.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox25.Location = ((System.Drawing.PointF)(resources.GetObject("textBox25.Location")));
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = null;
        this.textBox25.Size = new System.Drawing.SizeF(0.5625F, 0.3125F);
        this.textBox25.Text = "Mzno.";
        // 
        // textBox26
        // 
        this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.DistinctField = null;
        this.textBox26.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox26.Location = ((System.Drawing.PointF)(resources.GetObject("textBox26.Location")));
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = null;
        this.textBox26.Size = new System.Drawing.SizeF(0.8125F, 0.3125F);
        this.textBox26.Text = "Sup.(m2)";
        // 
        // textBox27
        // 
        this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.DistinctField = null;
        this.textBox27.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox27.Location = ((System.Drawing.PointF)(resources.GetObject("textBox27.Location")));
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = null;
        this.textBox27.Size = new System.Drawing.SizeF(0.625F, 0.3125F);
        this.textBox27.Text = "Costo ($/m2)";
        // 
        // textBox28
        // 
        this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.DistinctField = null;
        this.textBox28.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox28.Location = ((System.Drawing.PointF)(resources.GetObject("textBox28.Location")));
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = null;
        this.textBox28.Size = new System.Drawing.SizeF(0.625F, 0.3125F);
        this.textBox28.Text = "Precio($/m2)";
        // 
        // textBox29
        // 
        this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.DistinctField = null;
        this.textBox29.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox29.Location = ((System.Drawing.PointF)(resources.GetObject("textBox29.Location")));
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = null;
        this.textBox29.Size = new System.Drawing.SizeF(2F, 0.3125F);
        this.textBox29.Text = "Negocio";
        // 
        // textBox30
        // 
        this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.DistinctField = null;
        this.textBox30.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox30.Location = ((System.Drawing.PointF)(resources.GetObject("textBox30.Location")));
        this.textBox30.Name = "textBox30";
        this.textBox30.OutputFormat = null;
        this.textBox30.Size = new System.Drawing.SizeF(1F, 0.3125F);
        this.textBox30.Text = "Estado";
        // 
        // textBox31
        // 
        this.textBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.DistinctField = null;
        this.textBox31.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox31.Location = ((System.Drawing.PointF)(resources.GetObject("textBox31.Location")));
        this.textBox31.Name = "textBox31";
        this.textBox31.OutputFormat = null;
        this.textBox31.Size = new System.Drawing.SizeF(0.6875F, 0.3125F);
        this.textBox31.Text = "No. Contrato";
        // 
        // textBox32
        // 
        this.textBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.DistinctField = null;
        this.textBox32.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox32.Location = ((System.Drawing.PointF)(resources.GetObject("textBox32.Location")));
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = null;
        this.textBox32.Size = new System.Drawing.SizeF(2.0625F, 0.3125F);
        this.textBox32.Text = "Anterior Prop.";
        // 
        // textBox33
        // 
        this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.DistinctField = null;
        this.textBox33.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox33.Location = ((System.Drawing.PointF)(resources.GetObject("textBox33.Location")));
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = null;
        this.textBox33.Size = new System.Drawing.SizeF(0.8125F, 0.3125F);
        this.textBox33.Text = "No. Partida";
        // 
        // textBox3
        // 
        this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.DataField = "fecha";
        this.textBox3.DistinctField = null;
        this.textBox3.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = "dd/MM/yyyy";
        this.textBox3.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox3.Text = null;
        // 
        // textBox22
        // 
        this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.DistinctField = null;
        this.textBox22.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox22.Location = ((System.Drawing.PointF)(resources.GetObject("textBox22.Location")));
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = null;
        this.textBox22.Size = new System.Drawing.SizeF(1.3125F, 0.1875F);
        this.textBox22.Text = "Reporte al:";
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox19});
        this.detail.Height = 0.1979167F;
        this.detail.Name = "detail";
        // 
        // textBox4
        // 
        this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.DataField = "codigo";
        this.textBox4.DistinctField = null;
        this.textBox4.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
        this.textBox4.Name = "textBox4";
        this.textBox4.OutputFormat = null;
        this.textBox4.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
        this.textBox4.Text = null;
        // 
        // textBox5
        // 
        this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.DataField = "superficie_m2";
        this.textBox5.DistinctField = null;
        this.textBox5.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
        this.textBox5.Name = "textBox5";
        this.textBox5.OutputFormat = "#,##0.00";
        this.textBox5.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox5.Text = null;
        // 
        // textBox6
        // 
        this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.DataField = "costo_m2_sus";
        this.textBox6.DistinctField = null;
        this.textBox6.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
        this.textBox6.Name = "textBox6";
        this.textBox6.OutputFormat = "#,##0.00";
        this.textBox6.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox6.Text = null;
        // 
        // textBox7
        // 
        this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.DataField = "precio_m2_sus";
        this.textBox7.DistinctField = null;
        this.textBox7.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox7.Location = ((System.Drawing.PointF)(resources.GetObject("textBox7.Location")));
        this.textBox7.Name = "textBox7";
        this.textBox7.OutputFormat = "#,##0.00";
        this.textBox7.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox7.Text = null;
        // 
        // textBox8
        // 
        this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.DataField = "negocio_nombre";
        this.textBox8.DistinctField = null;
        this.textBox8.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox8.Location = ((System.Drawing.PointF)(resources.GetObject("textBox8.Location")));
        this.textBox8.Name = "textBox8";
        this.textBox8.OutputFormat = null;
        this.textBox8.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox8.Text = null;
        // 
        // textBox9
        // 
        this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.DataField = "estado_nombre";
        this.textBox9.DistinctField = null;
        this.textBox9.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox9.Location = ((System.Drawing.PointF)(resources.GetObject("textBox9.Location")));
        this.textBox9.Name = "textBox9";
        this.textBox9.OutputFormat = null;
        this.textBox9.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox9.Text = null;
        // 
        // textBox10
        // 
        this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.DataField = "numero_contrato";
        this.textBox10.DistinctField = null;
        this.textBox10.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox10.Location = ((System.Drawing.PointF)(resources.GetObject("textBox10.Location")));
        this.textBox10.Name = "textBox10";
        this.textBox10.OutputFormat = null;
        this.textBox10.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
        this.textBox10.Text = null;
        // 
        // textBox11
        // 
        this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.DataField = "anterior_propietario";
        this.textBox11.DistinctField = null;
        this.textBox11.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox11.Location = ((System.Drawing.PointF)(resources.GetObject("textBox11.Location")));
        this.textBox11.Name = "textBox11";
        this.textBox11.OutputFormat = null;
        this.textBox11.Size = new System.Drawing.SizeF(2.0625F, 0.1875F);
        this.textBox11.Text = null;
        // 
        // textBox12
        // 
        this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.DataField = "num_partida";
        this.textBox12.DistinctField = null;
        this.textBox12.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox12.Location = ((System.Drawing.PointF)(resources.GetObject("textBox12.Location")));
        this.textBox12.Name = "textBox12";
        this.textBox12.OutputFormat = null;
        this.textBox12.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox12.Text = null;
        // 
        // textBox19
        // 
        this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.DataField = "manzano_codigo";
        this.textBox19.DistinctField = null;
        this.textBox19.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox19.Location = ((System.Drawing.PointF)(resources.GetObject("textBox19.Location")));
        this.textBox19.Name = "textBox19";
        this.textBox19.OutputFormat = null;
        this.textBox19.Size = new System.Drawing.SizeF(0.5625F, 0.1875F);
        this.textBox19.Text = null;
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox23});
        this.groupHeader1.DataField = "id_localizacion";
        this.groupHeader1.Height = 0.1979167F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // textBox1
        // 
        this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.DataField = "localizacion_nombre";
        this.textBox1.DistinctField = null;
        this.textBox1.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = null;
        this.textBox1.Size = new System.Drawing.SizeF(2.875F, 0.1875F);
        this.textBox1.Text = null;
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
        this.textBox23.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox23.Text = "Localización:";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox35,
            this.line2,
            this.textBox41});
        this.groupFooter1.Height = 0.53125F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // textBox16
        // 
        this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.DataField = "localizacion_nombre";
        this.textBox16.DistinctField = null;
        this.textBox16.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox16.Location = ((System.Drawing.PointF)(resources.GetObject("textBox16.Location")));
        this.textBox16.Name = "textBox16";
        this.textBox16.OutputFormat = null;
        this.textBox16.Size = new System.Drawing.SizeF(2.875F, 0.1875F);
        this.textBox16.Text = null;
        // 
        // textBox17
        // 
        this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.DataField = "costo_m2_sus";
        this.textBox17.DistinctField = null;
        this.textBox17.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox17.Location = ((System.Drawing.PointF)(resources.GetObject("textBox17.Location")));
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = "#,##0.00";
        this.textBox17.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
        this.textBox17.SummaryGroup = "groupHeader1";
        this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox17.Text = null;
        // 
        // textBox18
        // 
        this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.DataField = "precio_m2_sus";
        this.textBox18.DistinctField = null;
        this.textBox18.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox18.Location = ((System.Drawing.PointF)(resources.GetObject("textBox18.Location")));
        this.textBox18.Name = "textBox18";
        this.textBox18.OutputFormat = "#,##0.00";
        this.textBox18.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox18.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
        this.textBox18.SummaryGroup = "groupHeader1";
        this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox18.Text = null;
        // 
        // textBox35
        // 
        this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.DistinctField = null;
        this.textBox35.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox35.Location = ((System.Drawing.PointF)(resources.GetObject("textBox35.Location")));
        this.textBox35.Name = "textBox35";
        this.textBox35.OutputFormat = null;
        this.textBox35.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox35.Text = "Subt. Loc.";
        // 
        // line2
        // 
        this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.X1 = 0.0625F;
        this.line2.X2 = 13F;
        this.line2.Y1 = 0.0625F;
        this.line2.Y2 = 0.0625F;
        // 
        // textBox41
        // 
        this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.DataField = "superficie_m2";
        this.textBox41.DistinctField = null;
        this.textBox41.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox41.Location = ((System.Drawing.PointF)(resources.GetObject("textBox41.Location")));
        this.textBox41.Name = "textBox41";
        this.textBox41.OutputFormat = "#,##0.00";
        this.textBox41.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox41.SummaryGroup = "groupHeader1";
        this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox41.Text = "textBox41";
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox36,
            this.textBox21,
            this.textBox22,
            this.textBox3,
            this.picture1});
        this.reportHeader1.Height = 0.7291667F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // textBox36
        // 
        this.textBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.DistinctField = null;
        this.textBox36.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox36.Location = ((System.Drawing.PointF)(resources.GetObject("textBox36.Location")));
        this.textBox36.Name = "textBox36";
        this.textBox36.OutputFormat = null;
        this.textBox36.Size = new System.Drawing.SizeF(4.75F, 0.1875F);
        this.textBox36.Text = null;
        // 
        // textBox21
        // 
        this.textBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.DistinctField = null;
        this.textBox21.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox21.Location = ((System.Drawing.PointF)(resources.GetObject("textBox21.Location")));
        this.textBox21.Name = "textBox21";
        this.textBox21.OutputFormat = null;
        this.textBox21.Size = new System.Drawing.SizeF(12.9375F, 0.1875F);
        this.textBox21.Text = "Inventario lote detalle";
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
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.line3,
            this.textBox42});
        this.reportFooter1.Height = 0.3125F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // textBox37
        // 
        this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.DistinctField = null;
        this.textBox37.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox37.Location = ((System.Drawing.PointF)(resources.GetObject("textBox37.Location")));
        this.textBox37.Name = "textBox37";
        this.textBox37.OutputFormat = null;
        this.textBox37.Size = new System.Drawing.SizeF(3.8125F, 0.1875F);
        this.textBox37.Text = "Total General:";
        // 
        // textBox38
        // 
        this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.DataField = "costo_m2_sus";
        this.textBox38.DistinctField = null;
        this.textBox38.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox38.Location = ((System.Drawing.PointF)(resources.GetObject("textBox38.Location")));
        this.textBox38.Name = "textBox38";
        this.textBox38.OutputFormat = "#,##0.00";
        this.textBox38.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox38.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
        this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox38.Text = null;
        // 
        // textBox39
        // 
        this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.DataField = "precio_m2_sus";
        this.textBox39.DistinctField = null;
        this.textBox39.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox39.Location = ((System.Drawing.PointF)(resources.GetObject("textBox39.Location")));
        this.textBox39.Name = "textBox39";
        this.textBox39.OutputFormat = "#,##0.00";
        this.textBox39.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox39.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
        this.textBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox39.Text = null;
        // 
        // line3
        // 
        this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.X1 = 0.0625F;
        this.line3.X2 = 13F;
        this.line3.Y1 = 0.0625F;
        this.line3.Y2 = 0.0625F;
        // 
        // textBox42
        // 
        this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.DataField = "superficie_m2";
        this.textBox42.DistinctField = null;
        this.textBox42.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox42.Location = ((System.Drawing.PointF)(resources.GetObject("textBox42.Location")));
        this.textBox42.Name = "textBox42";
        this.textBox42.OutputFormat = "#,##0.00";
        this.textBox42.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox42.Text = "textBox42";
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.textBox24});
        this.groupHeader2.DataField = "id_urbanizacion";
        this.groupHeader2.Height = 0.1979167F;
        this.groupHeader2.Name = "groupHeader2";
        // 
        // textBox2
        // 
        this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.DataField = "urbanizacion_nombre";
        this.textBox2.DistinctField = null;
        this.textBox2.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = null;
        this.textBox2.Size = new System.Drawing.SizeF(1.8125F, 0.1875F);
        this.textBox2.Text = null;
        // 
        // textBox24
        // 
        this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.DistinctField = null;
        this.textBox24.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox24.Location = ((System.Drawing.PointF)(resources.GetObject("textBox24.Location")));
        this.textBox24.Name = "textBox24";
        this.textBox24.OutputFormat = null;
        this.textBox24.Size = new System.Drawing.SizeF(1F, 0.1875F);
        this.textBox24.Text = "Sector";
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox34,
            this.line1,
            this.textBox40});
        this.groupFooter2.Height = 0.53125F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // textBox13
        // 
        this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.DataField = "urbanizacion_nombre";
        this.textBox13.DistinctField = null;
        this.textBox13.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox13.Location = ((System.Drawing.PointF)(resources.GetObject("textBox13.Location")));
        this.textBox13.Name = "textBox13";
        this.textBox13.OutputFormat = null;
        this.textBox13.Size = new System.Drawing.SizeF(1.8125F, 0.1875F);
        this.textBox13.Text = null;
        // 
        // textBox14
        // 
        this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.DataField = "costo_m2_sus";
        this.textBox14.DistinctField = null;
        this.textBox14.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox14.Location = ((System.Drawing.PointF)(resources.GetObject("textBox14.Location")));
        this.textBox14.Name = "textBox14";
        this.textBox14.OutputFormat = "#,##0.00";
        this.textBox14.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox14.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
        this.textBox14.SummaryGroup = "groupHeader2";
        this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox14.Text = null;
        // 
        // textBox15
        // 
        this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.DataField = "precio_m2_sus";
        this.textBox15.DistinctField = null;
        this.textBox15.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox15.Location = ((System.Drawing.PointF)(resources.GetObject("textBox15.Location")));
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = "#,##0.00";
        this.textBox15.Size = new System.Drawing.SizeF(0.625F, 0.1875F);
        this.textBox15.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
        this.textBox15.SummaryGroup = "groupHeader2";
        this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox15.Text = null;
        // 
        // textBox34
        // 
        this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.DistinctField = null;
        this.textBox34.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox34.Location = ((System.Drawing.PointF)(resources.GetObject("textBox34.Location")));
        this.textBox34.Name = "textBox34";
        this.textBox34.OutputFormat = null;
        this.textBox34.Size = new System.Drawing.SizeF(1F, 0.1875F);
        this.textBox34.Text = "Subt. Sect.";
        // 
        // line1
        // 
        this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.X1 = 1F;
        this.line1.X2 = 13F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
        // 
        // textBox40
        // 
        this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.DataField = "superficie_m2";
        this.textBox40.DistinctField = null;
        this.textBox40.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox40.Location = ((System.Drawing.PointF)(resources.GetObject("textBox40.Location")));
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = "#,##0.00";
        this.textBox40.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox40.SummaryGroup = "groupHeader2";
        this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox40.Text = "textBox40";
        // 
        // rpt_lote_detalle
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 13.07292F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.ReportStart += new System.EventHandler(this.rpt_lote_detalle_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();

	}
	#endregion

    
}
