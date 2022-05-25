using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_audit_reporte_cliente.
/// </summary>
public class rpt_audit_reporte_cliente : DataDynamics.ActiveReports.ActiveReport3
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
        if (Cadena != "") textBox12.Text = Cadena; else textBox12.Text = "-------";
    }

    private void rpt_audit_reporte_cliente_ReportStart(object sender, EventArgs e)
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
        textBox11.ClassName = "estiloEncabEnun";
        textBox4.ClassName = "estiloEncabDato";
        textBox6.ClassName = "estiloEncabDato";
        textBox8.ClassName = "estiloEncabDato";
        textBox10.ClassName = "estiloEncabDato";
        textBox12.ClassName = "estiloEncabDato";
        //Detalle (header):
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
        textBox23.ClassName = "estiloDetalleEnun";
        textBox24.ClassName = "estiloDetalleEnun";
        textBox25.ClassName = "estiloDetalleEnun";
        textBox26.ClassName = "estiloDetalleEnun";
        textBox27.ClassName = "estiloDetalleEnun";
        textBox28.ClassName = "estiloDetalleEnun";
        textBox29.ClassName = "estiloDetalleEnun";
        textBox30.ClassName = "estiloDetalleEnun";
        textBox31.ClassName = "estiloDetalleEnun";
        textBox32.ClassName = "estiloDetalleEnun";
        textBox33.ClassName = "estiloDetalleEnun";
        textBox34.ClassName = "estiloDetalleEnun";
        textBox57.ClassName = "estiloDetalleEnun";
        //Detalle (datos):
        textBox35.ClassName = "estiloDetalleDatoString";
        textBox36.ClassName = "estiloDetalleDatoString";
        textBox37.ClassName = "estiloDetalleDatoString";
        textBox38.ClassName = "estiloDetalleDato";
        textBox39.ClassName = "estiloDetalleDato";
        textBox40.ClassName = "estiloDetalleDatoString";
        textBox41.ClassName = "estiloDetalleDatoString";
        textBox42.ClassName = "estiloDetalleDatoString";
        textBox43.ClassName = "estiloDetalleDatoString";
        textBox44.ClassName = "estiloDetalleDatoString";
        textBox45.ClassName = "estiloDetalleDatoString";
        textBox46.ClassName = "estiloDetalleDatoString";
        textBox47.ClassName = "estiloDetalleDatoString";
        textBox48.ClassName = "estiloDetalleDatoString";
        textBox49.ClassName = "estiloDetalleDatoString";
        textBox50.ClassName = "estiloDetalleDatoString";
        textBox51.ClassName = "estiloDetalleDatoString";
        textBox52.ClassName = "estiloDetalleDatoString";
        textBox53.ClassName = "estiloDetalleDatoString";
        textBox54.ClassName = "estiloDetalleDatoString";
        textBox55.ClassName = "estiloDetalleDatoString";
        textBox56.ClassName = "estiloDetalleDatoString";
        textBox58.ClassName = "estiloDetalleDatoString";
        //Report (footer):
        //Cometario:
    } 

	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
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
    private TextBox textBox33;
    private TextBox textBox34;
    private TextBox textBox35;
    private TextBox textBox36;
    private TextBox textBox37;
    private TextBox textBox38;
    private TextBox textBox39;
    private TextBox textBox40;
    private TextBox textBox41;
    private TextBox textBox42;
    private TextBox textBox43;
    private TextBox textBox44;
    private TextBox textBox45;
    private TextBox textBox46;
    private TextBox textBox47;
    private TextBox textBox48;
    private TextBox textBox49;
    private TextBox textBox50;
    private TextBox textBox51;
    private TextBox textBox52;
    private TextBox textBox53;
    private TextBox textBox54;
    private TextBox textBox55;
    private TextBox textBox56;
    private TextBox textBox57;
    private TextBox textBox58;
    private Picture picture1;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_audit_reporte_cliente()
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
        string resourceFileName = "rpt_audit_reporte_cliente.resx";
        System.Resources.ResourceManager resources = Resources.rpt_audit_reporte_cliente.ResourceManager;
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
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
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        this.textBox47 = new DataDynamics.ActiveReports.TextBox();
        this.textBox48 = new DataDynamics.ActiveReports.TextBox();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox50 = new DataDynamics.ActiveReports.TextBox();
        this.textBox51 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.textBox34,
            this.textBox57});
        this.pageHeader.Height = 0.2083333F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox13.Size = new System.Drawing.SizeF(1.375F, 0.1979167F);
        this.textBox13.Text = "Fecha";
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
        this.textBox14.Size = new System.Drawing.SizeF(2.3125F, 0.1875F);
        this.textBox14.Text = "Usuario";
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
        this.textBox15.Size = new System.Drawing.SizeF(1.5F, 0.1875F);
        this.textBox15.Text = "Evento";
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
        this.textBox16.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
        this.textBox16.Text = "id_cliente";
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
        this.textBox17.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox17.Text = "C.I.";
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
        this.textBox18.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.textBox18.Text = "Lugar CI";
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
        this.textBox19.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox19.Text = "Lugar de cobro";
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
        this.textBox20.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox20.Text = "NIT";
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
        this.textBox21.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox21.Text = "Nombres";
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
        this.textBox22.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox22.Text = "Ap. Paterno";
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
        this.textBox23.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox23.Text = "Ap. Materno";
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
        this.textBox24.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox24.Text = "F.Nacimiento";
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
        this.textBox25.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox25.Text = "Celular";
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
        this.textBox26.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox26.Text = "Fax";
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
        this.textBox27.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox27.Text = "Email";
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
        this.textBox28.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox28.Text = "Nº Casilla";
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
        this.textBox29.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox29.Text = "Domicilio Dirección";
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
        this.textBox30.Size = new System.Drawing.SizeF(1F, 0.1875F);
        this.textBox30.Text = "Domicilio Fono.";
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
        this.textBox31.Size = new System.Drawing.SizeF(1.25F, 0.1875F);
        this.textBox31.Text = "Domicilio Zona";
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
        this.textBox32.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox32.Text = "Oficina Dirección";
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
        this.textBox33.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox33.Text = "Oficina Fono.";
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
        this.textBox34.Size = new System.Drawing.SizeF(1.25F, 0.1875F);
        this.textBox34.Text = "Oficina Zona";
        // 
        // textBox57
        // 
        this.textBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.DistinctField = null;
        this.textBox57.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox57.Location = ((System.Drawing.PointF)(resources.GetObject("textBox57.Location")));
        this.textBox57.Name = "textBox57";
        this.textBox57.OutputFormat = null;
        this.textBox57.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox57.Text = "Transitorio";
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox48,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox58});
        this.detail.Height = 0.1770833F;
        this.detail.Name = "detail";
        // 
        // textBox35
        // 
        this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.DataField = "fecha";
        this.textBox35.DistinctField = null;
        this.textBox35.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox35.Location = ((System.Drawing.PointF)(resources.GetObject("textBox35.Location")));
        this.textBox35.Name = "textBox35";
        this.textBox35.OutputFormat = null;
        this.textBox35.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
        this.textBox35.Text = "textBox35";
        // 
        // textBox36
        // 
        this.textBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox36.DataField = "usuario";
        this.textBox36.DistinctField = null;
        this.textBox36.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox36.Location = ((System.Drawing.PointF)(resources.GetObject("textBox36.Location")));
        this.textBox36.Name = "textBox36";
        this.textBox36.OutputFormat = null;
        this.textBox36.Size = new System.Drawing.SizeF(2.3125F, 0.1875F);
        this.textBox36.Text = "textBox36";
        // 
        // textBox37
        // 
        this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.DataField = "evento";
        this.textBox37.DistinctField = null;
        this.textBox37.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox37.Location = ((System.Drawing.PointF)(resources.GetObject("textBox37.Location")));
        this.textBox37.Name = "textBox37";
        this.textBox37.OutputFormat = null;
        this.textBox37.Size = new System.Drawing.SizeF(1.5F, 0.1875F);
        this.textBox37.Text = "textBox37";
        // 
        // textBox38
        // 
        this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.DataField = "id_cliente";
        this.textBox38.DistinctField = null;
        this.textBox38.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox38.Location = ((System.Drawing.PointF)(resources.GetObject("textBox38.Location")));
        this.textBox38.Name = "textBox38";
        this.textBox38.OutputFormat = null;
        this.textBox38.Size = new System.Drawing.SizeF(0.6875F, 0.1875F);
        this.textBox38.Text = "textBox38";
        // 
        // textBox39
        // 
        this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.DataField = "ci";
        this.textBox39.DistinctField = null;
        this.textBox39.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox39.Location = ((System.Drawing.PointF)(resources.GetObject("textBox39.Location")));
        this.textBox39.Name = "textBox39";
        this.textBox39.OutputFormat = null;
        this.textBox39.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox39.Text = "textBox39";
        // 
        // textBox40
        // 
        this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.DataField = "lugar_ci";
        this.textBox40.DistinctField = null;
        this.textBox40.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox40.Location = ((System.Drawing.PointF)(resources.GetObject("textBox40.Location")));
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = null;
        this.textBox40.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.textBox40.Text = "textBox40";
        // 
        // textBox41
        // 
        this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.DataField = "lugar_cobro";
        this.textBox41.DistinctField = null;
        this.textBox41.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox41.Location = ((System.Drawing.PointF)(resources.GetObject("textBox41.Location")));
        this.textBox41.Name = "textBox41";
        this.textBox41.OutputFormat = null;
        this.textBox41.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox41.Text = "textBox41";
        // 
        // textBox42
        // 
        this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.DataField = "nit";
        this.textBox42.DistinctField = null;
        this.textBox42.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox42.Location = ((System.Drawing.PointF)(resources.GetObject("textBox42.Location")));
        this.textBox42.Name = "textBox42";
        this.textBox42.OutputFormat = null;
        this.textBox42.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox42.Text = "textBox42";
        // 
        // textBox43
        // 
        this.textBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.DataField = "nombres";
        this.textBox43.DistinctField = null;
        this.textBox43.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox43.Location = ((System.Drawing.PointF)(resources.GetObject("textBox43.Location")));
        this.textBox43.Name = "textBox43";
        this.textBox43.OutputFormat = null;
        this.textBox43.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox43.Text = "textBox43";
        // 
        // textBox44
        // 
        this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.DataField = "paterno";
        this.textBox44.DistinctField = null;
        this.textBox44.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox44.Location = ((System.Drawing.PointF)(resources.GetObject("textBox44.Location")));
        this.textBox44.Name = "textBox44";
        this.textBox44.OutputFormat = null;
        this.textBox44.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox44.Text = "textBox44";
        // 
        // textBox45
        // 
        this.textBox45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.DataField = "materno";
        this.textBox45.DistinctField = null;
        this.textBox45.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox45.Location = ((System.Drawing.PointF)(resources.GetObject("textBox45.Location")));
        this.textBox45.Name = "textBox45";
        this.textBox45.OutputFormat = null;
        this.textBox45.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox45.Text = "textBox45";
        // 
        // textBox46
        // 
        this.textBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.DataField = "fecha_nacimiento";
        this.textBox46.DistinctField = null;
        this.textBox46.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox46.Location = ((System.Drawing.PointF)(resources.GetObject("textBox46.Location")));
        this.textBox46.Name = "textBox46";
        this.textBox46.OutputFormat = "dd/MM/yyyy";
        this.textBox46.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox46.Text = "textBox46";
        // 
        // textBox47
        // 
        this.textBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.DataField = "celular";
        this.textBox47.DistinctField = null;
        this.textBox47.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox47.Location = ((System.Drawing.PointF)(resources.GetObject("textBox47.Location")));
        this.textBox47.Name = "textBox47";
        this.textBox47.OutputFormat = null;
        this.textBox47.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox47.Text = "textBox47";
        // 
        // textBox48
        // 
        this.textBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.DataField = "fax";
        this.textBox48.DistinctField = null;
        this.textBox48.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox48.Location = ((System.Drawing.PointF)(resources.GetObject("textBox48.Location")));
        this.textBox48.Name = "textBox48";
        this.textBox48.OutputFormat = null;
        this.textBox48.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox48.Text = "textBox48";
        // 
        // textBox49
        // 
        this.textBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.DataField = "email";
        this.textBox49.DistinctField = null;
        this.textBox49.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox49.Location = ((System.Drawing.PointF)(resources.GetObject("textBox49.Location")));
        this.textBox49.Name = "textBox49";
        this.textBox49.OutputFormat = null;
        this.textBox49.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox49.Text = "textBox49";
        // 
        // textBox50
        // 
        this.textBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.DataField = "casilla";
        this.textBox50.DistinctField = null;
        this.textBox50.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox50.Location = ((System.Drawing.PointF)(resources.GetObject("textBox50.Location")));
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = null;
        this.textBox50.Size = new System.Drawing.SizeF(0.75F, 0.1875F);
        this.textBox50.Text = "textBox50";
        // 
        // textBox51
        // 
        this.textBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.DataField = "domicilio_direccion";
        this.textBox51.DistinctField = null;
        this.textBox51.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox51.Location = ((System.Drawing.PointF)(resources.GetObject("textBox51.Location")));
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = null;
        this.textBox51.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox51.Text = "textBox51";
        // 
        // textBox52
        // 
        this.textBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.DataField = "domicilio_zona";
        this.textBox52.DistinctField = null;
        this.textBox52.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox52.Location = ((System.Drawing.PointF)(resources.GetObject("textBox52.Location")));
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = null;
        this.textBox52.Size = new System.Drawing.SizeF(1.25F, 0.1875F);
        this.textBox52.Text = "textBox52";
        // 
        // textBox53
        // 
        this.textBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.DataField = "domicilio_fono";
        this.textBox53.DistinctField = null;
        this.textBox53.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox53.Location = ((System.Drawing.PointF)(resources.GetObject("textBox53.Location")));
        this.textBox53.Name = "textBox53";
        this.textBox53.OutputFormat = null;
        this.textBox53.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox53.Text = "textBox53";
        // 
        // textBox54
        // 
        this.textBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.DataField = "oficina_direccion";
        this.textBox54.DistinctField = null;
        this.textBox54.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox54.Location = ((System.Drawing.PointF)(resources.GetObject("textBox54.Location")));
        this.textBox54.Name = "textBox54";
        this.textBox54.OutputFormat = null;
        this.textBox54.Size = new System.Drawing.SizeF(2F, 0.1875F);
        this.textBox54.Text = "textBox54";
        // 
        // textBox55
        // 
        this.textBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.DataField = "oficina_fono";
        this.textBox55.DistinctField = null;
        this.textBox55.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox55.Location = ((System.Drawing.PointF)(resources.GetObject("textBox55.Location")));
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = null;
        this.textBox55.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox55.Text = "textBox55";
        // 
        // textBox56
        // 
        this.textBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.DataField = "oficina_zona";
        this.textBox56.DistinctField = null;
        this.textBox56.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox56.Location = ((System.Drawing.PointF)(resources.GetObject("textBox56.Location")));
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = null;
        this.textBox56.Size = new System.Drawing.SizeF(1.25F, 0.1875F);
        this.textBox56.Text = "textBox56";
        // 
        // textBox58
        // 
        this.textBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.DataField = "transitorio";
        this.textBox58.DistinctField = null;
        this.textBox58.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox58.Location = ((System.Drawing.PointF)(resources.GetObject("textBox58.Location")));
        this.textBox58.Name = "textBox58";
        this.textBox58.OutputFormat = null;
        this.textBox58.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
        this.textBox58.Text = "textBox58";
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
            this.textBox11,
            this.textBox12,
            this.picture1});
        this.reportHeader1.Height = 1.447917F;
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
        this.textBox1.Size = new System.Drawing.SizeF(5.25F, 0.1875F);
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
        this.textBox2.Size = new System.Drawing.SizeF(27.625F, 0.1875F);
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
        this.textBox3.Size = new System.Drawing.SizeF(1F, 0.1979167F);
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
        this.textBox4.Size = new System.Drawing.SizeF(4.125F, 0.1875F);
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
        this.textBox5.Size = new System.Drawing.SizeF(1F, 0.1979167F);
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
        this.textBox6.Size = new System.Drawing.SizeF(4.125F, 0.1875F);
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
        this.textBox7.Size = new System.Drawing.SizeF(1F, 0.1979167F);
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
        this.textBox8.Size = new System.Drawing.SizeF(4.125F, 0.1875F);
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
        this.textBox9.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox9.Text = "Id. Cliente:";
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
        this.textBox10.Size = new System.Drawing.SizeF(4.125F, 0.1875F);
        this.textBox10.Text = "textBox10";
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
        this.textBox11.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        this.textBox11.Text = "Cliente:";
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
        this.textBox12.Size = new System.Drawing.SizeF(4.125F, 0.1875F);
        this.textBox12.Text = "textBox12";
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
        // rpt_audit_reporte_cliente
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 27.76042F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.ReportStart += new System.EventHandler(this.rpt_audit_reporte_cliente_ReportStart);
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();

	}
	#endregion


}
