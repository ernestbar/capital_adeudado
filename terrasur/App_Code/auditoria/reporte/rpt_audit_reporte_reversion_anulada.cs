using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_audit_reporte_reversion_anulada.
/// </summary>
public class rpt_audit_reporte_reversion_anulada : DataDynamics.ActiveReports.ActiveReport3
{
    public void CargarDatos(string Nombre_reporte, string Usuario, int Tipo_fecha, DateTime Fecha_inicio, DateTime Fecha_fin, string Numero_contrato, int Entero, string Cadena)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox2.Text = Nombre_reporte;
        if (Usuario != "") textBox4.Text = Usuario; else textBox4.Text = "-------";
        switch (Tipo_fecha)
        {
            case 0: textBox6.Text = "-------"; break;
            case 1: textBox6.Text = "desde " + Fecha_inicio.ToString("d"); break;
            case 2: textBox6.Text = "hasta " + Fecha_fin.ToString("d"); break;
            case 3: textBox6.Text = "entre " + Fecha_inicio.ToString("d") + " y " + Fecha_fin.ToString("d"); break;
        }
        if (Numero_contrato != "") textBox8.Text = Numero_contrato; else textBox8.Text = "-------";
        if (Entero > 0) textBox10.Text = Entero.ToString(); else textBox10.Text = "-------";
    }

    private void rpt_audit_reporte_reversion_anulada_ReportStart(object sender, EventArgs e)
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
        textBox2.ClassName = "estiloTitulo";
        //Report (Header):
        textBox3.ClassName = "estiloEncabEnun";
        textBox5.ClassName = "estiloEncabEnun";
        textBox7.ClassName = "estiloEncabEnun";
        textBox9.ClassName = "estiloEncabEnun";
        textBox4.ClassName = "estiloEncabDato";
        textBox6.ClassName = "estiloEncabDato";
        textBox8.ClassName = "estiloEncabDato";
        textBox10.ClassName = "estiloEncabDato";
        //Detalle (header):
        textBox11.ClassName = "estiloDetalleEnun";
        textBox12.ClassName = "estiloDetalleEnun";
        textBox13.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox15.ClassName = "estiloDetalleEnun";
        textBox16.ClassName = "estiloDetalleEnun";
        textBox17.ClassName = "estiloDetalleEnun";
        textBox18.ClassName = "estiloDetalleEnun";
        textBox19.ClassName = "estiloDetalleEnun";
        textBox20.ClassName = "estiloDetalleEnun";
        textBox21.ClassName = "estiloDetalleEnun";
        textBox22.ClassName = "estiloDetalleEnun";
        //Detalle (datos):
        textBox23.ClassName = "estiloDetalleDatoString";
        textBox24.ClassName = "estiloDetalleDato";
        textBox25.ClassName = "estiloDetalleDatoString";
        textBox26.ClassName = "estiloDetalleDato";
        textBox27.ClassName = "estiloDetalleDatoString";
        textBox28.ClassName = "estiloDetalleDato";
        textBox29.ClassName = "estiloDetalleDato";
        textBox30.ClassName = "estiloDetalleDato";
        textBox31.ClassName = "estiloDetalleDato";
        textBox32.ClassName = "estiloDetalleDato";
        textBox33.ClassName = "estiloDetalleDato";
        textBox34.ClassName = "estiloDetalleDatoString";
        //Report (footer):
        //Cometario:
    } 

	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
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
    private TextBox textBox23;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox textBox26;
    private TextBox textBox27;
    private TextBox textBox28;
    private TextBox textBox29;
    private TextBox textBox30;
    private TextBox textBox31;
    private TextBox textBox32;
    private TextBox textBox33;
    private TextBox textBox34;
    private Picture picture1;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_audit_reporte_reversion_anulada()
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
        string resourceFileName = "rpt_audit_reporte_reversion_anulada.resx";
        System.Resources.ResourceManager resources = Resources.rpt_audit_reporte_reversion_anulada.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
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
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
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
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11,
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
            this.textBox22});
        this.pageHeader.Height = 0.1979167F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox11.Size = new System.Drawing.SizeF(1.375F, 0.1979167F);
        this.textBox11.Text = "Fecha";
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
        this.textBox12.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox12.Text = "id_reversion";
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
        this.textBox13.Size = new System.Drawing.SizeF(2.313F, 0.1979167F);
        this.textBox13.Text = "Usuario";
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
        this.textBox14.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox14.Text = "Nº contrato";
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
        this.textBox15.OutputFormat = null;
        this.textBox15.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox15.Text = "Nº días de mora";
        // 
        // textBox16
        // 
        this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.DistinctField = null;
        this.textBox16.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox16.Location = ((System.Drawing.PointF)(resources.GetObject("textBox16.Location")));
        this.textBox16.Name = "textBox16";
        this.textBox16.OutputFormat = null;
        this.textBox16.Size = new System.Drawing.SizeF(1.875F, 0.1875F);
        this.textBox16.Text = "Motivo de reversión";
        // 
        // textBox17
        // 
        this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.DistinctField = null;
        this.textBox17.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox17.Location = ((System.Drawing.PointF)(resources.GetObject("textBox17.Location")));
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = null;
        this.textBox17.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox17.Text = "Nº cuotas en mora";
        // 
        // textBox18
        // 
        this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.DistinctField = null;
        this.textBox18.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox18.Location = ((System.Drawing.PointF)(resources.GetObject("textBox18.Location")));
        this.textBox18.Name = "textBox18";
        this.textBox18.OutputFormat = null;
        this.textBox18.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox18.Text = "Capital total ($us)";
        // 
        // textBox19
        // 
        this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.DistinctField = null;
        this.textBox19.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox19.Location = ((System.Drawing.PointF)(resources.GetObject("textBox19.Location")));
        this.textBox19.Name = "textBox19";
        this.textBox19.OutputFormat = null;
        this.textBox19.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox19.Text = "Capital pagado ($us)";
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
        this.textBox20.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox20.Text = "Capital deudor ($us)";
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
        this.textBox21.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
        this.textBox21.Text = "Fecha de anulación";
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
        this.textBox22.Size = new System.Drawing.SizeF(2.3125F, 0.1875F);
        this.textBox22.Text = "Usuario (anulación)";
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox34});
        this.detail.Height = 0.1979167F;
        this.detail.Name = "detail";
        // 
        // textBox23
        // 
        this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.DataField = "fecha";
        this.textBox23.DistinctField = null;
        this.textBox23.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox23.Location = ((System.Drawing.PointF)(resources.GetObject("textBox23.Location")));
        this.textBox23.Name = "textBox23";
        this.textBox23.OutputFormat = null;
        this.textBox23.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
        this.textBox23.Text = "textBox23";
        // 
        // textBox24
        // 
        this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.DataField = "id_reversion";
        this.textBox24.DistinctField = null;
        this.textBox24.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox24.Location = ((System.Drawing.PointF)(resources.GetObject("textBox24.Location")));
        this.textBox24.Name = "textBox24";
        this.textBox24.OutputFormat = null;
        this.textBox24.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox24.Text = "textBox24";
        // 
        // textBox25
        // 
        this.textBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.DataField = "usuario";
        this.textBox25.DistinctField = null;
        this.textBox25.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox25.Location = ((System.Drawing.PointF)(resources.GetObject("textBox25.Location")));
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = null;
        this.textBox25.Size = new System.Drawing.SizeF(2.3125F, 0.1875F);
        this.textBox25.Text = "textBox25";
        // 
        // textBox26
        // 
        this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.DataField = "num_contrato";
        this.textBox26.DistinctField = null;
        this.textBox26.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox26.Location = ((System.Drawing.PointF)(resources.GetObject("textBox26.Location")));
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = null;
        this.textBox26.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox26.Text = "textBox26";
        // 
        // textBox27
        // 
        this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.DataField = "motivo";
        this.textBox27.DistinctField = null;
        this.textBox27.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox27.Location = ((System.Drawing.PointF)(resources.GetObject("textBox27.Location")));
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = null;
        this.textBox27.Size = new System.Drawing.SizeF(1.875F, 0.1875F);
        this.textBox27.Text = "textBox27";
        // 
        // textBox28
        // 
        this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.DataField = "dias_mora";
        this.textBox28.DistinctField = null;
        this.textBox28.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox28.Location = ((System.Drawing.PointF)(resources.GetObject("textBox28.Location")));
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = null;
        this.textBox28.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox28.Text = "textBox28";
        // 
        // textBox29
        // 
        this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.DataField = "cuotas_mora";
        this.textBox29.DistinctField = null;
        this.textBox29.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox29.Location = ((System.Drawing.PointF)(resources.GetObject("textBox29.Location")));
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = null;
        this.textBox29.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox29.Text = "textBox29";
        // 
        // textBox30
        // 
        this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.DataField = "capital_total";
        this.textBox30.DistinctField = null;
        this.textBox30.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox30.Location = ((System.Drawing.PointF)(resources.GetObject("textBox30.Location")));
        this.textBox30.Name = "textBox30";
        this.textBox30.OutputFormat = "#,##0.00";
        this.textBox30.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox30.Text = "textBox30";
        // 
        // textBox31
        // 
        this.textBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.DataField = "capital_pagado";
        this.textBox31.DistinctField = null;
        this.textBox31.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox31.Location = ((System.Drawing.PointF)(resources.GetObject("textBox31.Location")));
        this.textBox31.Name = "textBox31";
        this.textBox31.OutputFormat = "#,##0.00";
        this.textBox31.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox31.Text = "textBox31";
        // 
        // textBox32
        // 
        this.textBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.DataField = "capital_adeuda";
        this.textBox32.DistinctField = null;
        this.textBox32.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox32.Location = ((System.Drawing.PointF)(resources.GetObject("textBox32.Location")));
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = "#,##0.00";
        this.textBox32.Size = new System.Drawing.SizeF(0.875F, 0.1875F);
        this.textBox32.Text = "textBox32";
        // 
        // textBox33
        // 
        this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.DataField = "anulado_fecha";
        this.textBox33.DistinctField = null;
        this.textBox33.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox33.Location = ((System.Drawing.PointF)(resources.GetObject("textBox33.Location")));
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = null;
        this.textBox33.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
        this.textBox33.Text = "textBox33";
        // 
        // textBox34
        // 
        this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.DataField = "anulado_usuario";
        this.textBox34.DistinctField = null;
        this.textBox34.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox34.Location = ((System.Drawing.PointF)(resources.GetObject("textBox34.Location")));
        this.textBox34.Name = "textBox34";
        this.textBox34.OutputFormat = null;
        this.textBox34.Size = new System.Drawing.SizeF(2.3125F, 0.1875F);
        this.textBox34.Text = "textBox34";
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
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.picture1});
        this.reportHeader1.Height = 1.25F;
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
        this.textBox1.Size = new System.Drawing.SizeF(5.625F, 0.1875F);
        this.textBox1.Text = "textBox1";
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
        this.textBox2.Size = new System.Drawing.SizeF(15.75F, 0.1875F);
        this.textBox2.Text = "textBox2";
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
        this.textBox3.Size = new System.Drawing.SizeF(0.9375F, 0.1875F);
        this.textBox3.Text = "Usuario:";
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
        this.textBox4.Size = new System.Drawing.SizeF(4.4375F, 0.1875F);
        this.textBox4.Text = "textBox4";
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
        this.textBox5.Size = new System.Drawing.SizeF(0.9375F, 0.1875F);
        this.textBox5.Text = "Fecha:";
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
        this.textBox6.Size = new System.Drawing.SizeF(4.4375F, 0.1875F);
        this.textBox6.Text = "textBox6";
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
        this.textBox7.Size = new System.Drawing.SizeF(0.9375F, 0.1875F);
        this.textBox7.Text = "Nº contrato:";
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
        this.textBox8.Size = new System.Drawing.SizeF(4.4375F, 0.1875F);
        this.textBox8.Text = "textBox8";
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
        this.textBox9.Size = new System.Drawing.SizeF(0.9375F, 0.1875F);
        this.textBox9.Text = "Id. Reversión:";
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
        this.textBox10.Size = new System.Drawing.SizeF(4.4375F, 0.1875F);
        this.textBox10.Text = "textBox10";
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
        // rpt_audit_reporte_reversion_anulada
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 15.875F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.ReportStart += new System.EventHandler(this.rpt_audit_reporte_reversion_anulada_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();

	}
	#endregion

}
