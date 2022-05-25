using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_ingresosRecaudacion.
/// </summary>
public class rpt_ingresosRecaudacion : DataDynamics.ActiveReports.ActiveReport3
{
    public void Encabezado(string Sucursal, DateTime Desde, DateTime Hasta, int Formapago, string Negocio, string Moneda, string Consolidado, string Codigo_moneda)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");

        //textBox30.Text = Negocio;
        textBox4.Text = Sucursal;

        textBox24.Text = Desde.ToString("d") + " - " + Hasta.ToString("d");

        if (Formapago > 0)
        {
            if (Formapago == 1) { textBox26.Text = "Efectivo"; }
            if (Formapago == 2) { textBox26.Text = "DPR"; }
        }
        else { textBox26.Text = "Todos"; }

        textBox30.Text = Negocio;

        textBox44.Text = Moneda;
        textBox46.Text = Consolidado;
        if (Codigo_moneda == "$us") { textBox9.Text = "US$"; } else { textBox9.Text = Codigo_moneda; }
    }

    private void rpt_ingresosRecaudacion_ReportStart(object sender, EventArgs e)
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
        textBox4.ClassName = "estiloEncabDato";
        textBox23.ClassName = "estiloEncabEnun";
        textBox24.ClassName = "estiloEncabDato";
        textBox25.ClassName = "estiloEncabEnun";
        textBox26.ClassName = "estiloEncabDato";
        textBox29.ClassName = "estiloEncabEnun";
        textBox30.ClassName = "estiloEncabDato";

        textBox34.ClassName = "estiloEncabEnun";
        textBox44.ClassName = "estiloEncabDato";
        textBox45.ClassName = "estiloEncabEnun";
        textBox46.ClassName = "estiloEncabDato";

        textBox5.ClassName = "estiloGrupoEnun";
        textBox6.ClassName = "estiloGrupoEnun";
        textBox7.ClassName = "estiloGrupoEnun";
        textBox8.ClassName = "estiloGrupoEnun";
        textBox9.ClassName = "estiloDetalleEnun";

        textBox10.ClassName = "estiloDetalleDatoString";
        textBox11.ClassName = "estiloDetalleDato";
        textBox12.ClassName = "estiloDetalleDatoString";
        textBox13.ClassName = "estiloDetalleDato";
        textBox14.ClassName = "estiloDetalleDatoString";
        textBox15.ClassName = "estiloDetalleDato";
        textBox16.ClassName = "estiloDetalleDatoString";
        textBox17.ClassName = "estiloDetalleDato";
        textBox18.ClassName = "estiloDetalleDatoString";
        textBox19.ClassName = "estiloDetalleDato";
        textBox20.ClassName = "estiloDetalleDatoString";
        textBox21.ClassName = "estiloDetalleDato";
        textBox22.ClassName = "estiloDetalleDatoString";
        textBox27.ClassName = "estiloDetalleDato";

        textBox28.ClassName = "estiloTotalEnun";
        //textBox31.ClassName = "estiloTotalEnun";
        textBox32.ClassName = "estiloTotal";

        textBox33.ClassName = "estiloTotalEnun";
        //textBox34.ClassName = "estiloTotalEnun";
        textBox35.ClassName = "estiloTotal";

        textBox36.ClassName = "estiloTotalEnun";
        textBox37.ClassName = "estiloTotalEnun";
        textBox38.ClassName = "estiloTotal";

        textBox39.ClassName = "estiloTotalEnun";
        textBox40.ClassName = "estiloTotalEnun";
        textBox41.ClassName = "estiloTotal";
        textBox42.ClassName = "estiloTotalEnun";
        textBox43.ClassName = "estiloTotal";

        textBox31.ClassName = "estiloNota";
    } 

    
    private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Picture picture1;
    private TextBox textBox23;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox textBox26;
    private TextBox textBox29;
    private TextBox textBox30;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private TextBox textBox5;
    private TextBox textBox6;
    private GroupHeader groupHeader2;
    private TextBox textBox7;
    private GroupFooter groupFooter2;
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
    private TextBox textBox27;
    private TextBox textBox28;
    private TextBox textBox32;
    private TextBox textBox33;
    private TextBox textBox35;
    private TextBox textBox36;
    private TextBox textBox37;
    private TextBox textBox38;
    private Line line1;
    private Line line2;
    private TextBox textBox42;
    private TextBox textBox43;
    private Line line4;
    private TextBox textBox39;
    private TextBox textBox40;
    private TextBox textBox41;
    private Line line3;
    private Line line10;
    private Line line11;
    private Line line12;
    private Line line13;
    private Line line14;
    private Line line15;
    private Line line16;
    private Line line17;
    private Line line5;
    private Line line6;
    private Line line7;
    private Line line8;
    private Line line18;
    private Line line19;
    private Line line24;
    private Line line20;
    private Line line21;
    private Line line22;
    private Line line23;
    private TextBox textBox31;
    private TextBox textBox34;
    private TextBox textBox44;
    private TextBox textBox45;
    private TextBox textBox46;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_ingresosRecaudacion()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_ingresosRecaudacion));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.line10 = new DataDynamics.ActiveReports.Line();
        this.line11 = new DataDynamics.ActiveReports.Line();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.line13 = new DataDynamics.ActiveReports.Line();
        this.line14 = new DataDynamics.ActiveReports.Line();
        this.line15 = new DataDynamics.ActiveReports.Line();
        this.line16 = new DataDynamics.ActiveReports.Line();
        this.line17 = new DataDynamics.ActiveReports.Line();
        this.line18 = new DataDynamics.ActiveReports.Line();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.line24 = new DataDynamics.ActiveReports.Line();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.line20 = new DataDynamics.ActiveReports.Line();
        this.line21 = new DataDynamics.ActiveReports.Line();
        this.line22 = new DataDynamics.ActiveReports.Line();
        this.line23 = new DataDynamics.ActiveReports.Line();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
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
            this.textBox10,
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
            this.textBox22,
            this.textBox27,
            this.line10,
            this.line11,
            this.line12,
            this.line13,
            this.line14,
            this.line15,
            this.line16,
            this.line17,
            this.line18,
            this.line19});
        this.detail.Height = 1.322917F;
        this.detail.Name = "detail";
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
        this.textBox10.Left = 2.25F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Recaudación por cuotas iniciales";
        this.textBox10.Top = 0F;
        this.textBox10.Width = 2.8125F;
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
        this.textBox11.DataField = "cuotas_inicial";
        this.textBox11.Height = 0.1875F;
        this.textBox11.Left = 5.125F;
        this.textBox11.Name = "textBox11";
        this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
        this.textBox11.Style = "";
        this.textBox11.Text = "textBox11";
        this.textBox11.Top = 0F;
        this.textBox11.Width = 0.75F;
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
        this.textBox12.Height = 0.1875F;
        this.textBox12.Left = 2.25F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Recaudación por cuotas a capital";
        this.textBox12.Top = 0.1875F;
        this.textBox12.Width = 2.8125F;
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
        this.textBox13.DataField = "capital";
        this.textBox13.Height = 0.1875F;
        this.textBox13.Left = 5.125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
        this.textBox13.Style = "";
        this.textBox13.Text = "textBox13";
        this.textBox13.Top = 0.1875F;
        this.textBox13.Width = 0.75F;
        // 
        // textBox14
        // 
        this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.RightColor = System.Drawing.Color.Black;
        this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.TopColor = System.Drawing.Color.Black;
        this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Height = 0.1875F;
        this.textBox14.Left = 2.25F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Recaudación por intereses";
        this.textBox14.Top = 0.375F;
        this.textBox14.Width = 2.8125F;
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
        this.textBox15.DataField = "interes";
        this.textBox15.Height = 0.1875F;
        this.textBox15.Left = 5.125F;
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
        this.textBox15.Style = "";
        this.textBox15.Text = "textBox15";
        this.textBox15.Top = 0.375F;
        this.textBox15.Width = 0.75F;
        // 
        // textBox16
        // 
        this.textBox16.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.RightColor = System.Drawing.Color.Black;
        this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.TopColor = System.Drawing.Color.Black;
        this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Height = 0.1875F;
        this.textBox16.Left = 2.25F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Recaudación por seguro de desgravamen";
        this.textBox16.Top = 0.5625F;
        this.textBox16.Width = 2.8125F;
        // 
        // textBox17
        // 
        this.textBox17.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.RightColor = System.Drawing.Color.Black;
        this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.TopColor = System.Drawing.Color.Black;
        this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.DataField = "seguro";
        this.textBox17.Height = 0.1875F;
        this.textBox17.Left = 5.125F;
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
        this.textBox17.Style = "";
        this.textBox17.Text = "textBox17";
        this.textBox17.Top = 0.5625F;
        this.textBox17.Width = 0.75F;
        // 
        // textBox18
        // 
        this.textBox18.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.RightColor = System.Drawing.Color.Black;
        this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.TopColor = System.Drawing.Color.Black;
        this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Height = 0.1875F;
        this.textBox18.Left = 2.25F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "Recaudación por mantenimiento";
        this.textBox18.Top = 0.75F;
        this.textBox18.Width = 2.8125F;
        // 
        // textBox19
        // 
        this.textBox19.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.RightColor = System.Drawing.Color.Black;
        this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.TopColor = System.Drawing.Color.Black;
        this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.DataField = "mantenimiento";
        this.textBox19.Height = 0.1875F;
        this.textBox19.Left = 5.125F;
        this.textBox19.Name = "textBox19";
        this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
        this.textBox19.Style = "";
        this.textBox19.Text = "textBox19";
        this.textBox19.Top = 0.75F;
        this.textBox19.Width = 0.75F;
        // 
        // textBox20
        // 
        this.textBox20.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.RightColor = System.Drawing.Color.Black;
        this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.TopColor = System.Drawing.Color.Black;
        this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Height = 0.1875F;
        this.textBox20.Left = 2.25F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "Recaudación por otros servicios";
        this.textBox20.Top = 0.9375F;
        this.textBox20.Width = 2.8125F;
        // 
        // textBox21
        // 
        this.textBox21.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.RightColor = System.Drawing.Color.Black;
        this.textBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.TopColor = System.Drawing.Color.Black;
        this.textBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.DataField = "servicios";
        this.textBox21.Height = 0.1875F;
        this.textBox21.Left = 5.125F;
        this.textBox21.Name = "textBox21";
        this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
        this.textBox21.Style = "";
        this.textBox21.Text = "textBox21";
        this.textBox21.Top = 0.9375F;
        this.textBox21.Width = 0.75F;
        // 
        // textBox22
        // 
        this.textBox22.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.RightColor = System.Drawing.Color.Black;
        this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.TopColor = System.Drawing.Color.Black;
        this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 2.25F;
        this.textBox22.Name = "textBox22";
        this.textBox22.Style = "";
        this.textBox22.Text = "Recaudación por pago al contado";
        this.textBox22.Top = 1.125F;
        this.textBox22.Width = 2.8125F;
        // 
        // textBox27
        // 
        this.textBox27.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.RightColor = System.Drawing.Color.Black;
        this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.Border.TopColor = System.Drawing.Color.Black;
        this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox27.DataField = "pago_contado";
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 5.125F;
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
        this.textBox27.Style = "";
        this.textBox27.Text = "textBox27";
        this.textBox27.Top = 1.125F;
        this.textBox27.Width = 0.75F;
        // 
        // line10
        // 
        this.line10.Border.BottomColor = System.Drawing.Color.Black;
        this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line10.Border.LeftColor = System.Drawing.Color.Black;
        this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line10.Border.RightColor = System.Drawing.Color.Black;
        this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line10.Border.TopColor = System.Drawing.Color.Black;
        this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line10.Height = 0F;
        this.line10.Left = 2.1875F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 0.1875F;
        this.line10.Width = 3.75F;
        this.line10.X1 = 5.9375F;
        this.line10.X2 = 2.1875F;
        this.line10.Y1 = 0.1875F;
        this.line10.Y2 = 0.1875F;
        // 
        // line11
        // 
        this.line11.Border.BottomColor = System.Drawing.Color.Black;
        this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line11.Border.LeftColor = System.Drawing.Color.Black;
        this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line11.Border.RightColor = System.Drawing.Color.Black;
        this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line11.Border.TopColor = System.Drawing.Color.Black;
        this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line11.Height = 0F;
        this.line11.Left = 2.1875F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 0.375F;
        this.line11.Width = 3.75F;
        this.line11.X1 = 5.9375F;
        this.line11.X2 = 2.1875F;
        this.line11.Y1 = 0.375F;
        this.line11.Y2 = 0.375F;
        // 
        // line12
        // 
        this.line12.Border.BottomColor = System.Drawing.Color.Black;
        this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line12.Border.LeftColor = System.Drawing.Color.Black;
        this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line12.Border.RightColor = System.Drawing.Color.Black;
        this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line12.Border.TopColor = System.Drawing.Color.Black;
        this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line12.Height = 0F;
        this.line12.Left = 2.1875F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 0.5625F;
        this.line12.Width = 3.75F;
        this.line12.X1 = 2.1875F;
        this.line12.X2 = 5.9375F;
        this.line12.Y1 = 0.5625F;
        this.line12.Y2 = 0.5625F;
        // 
        // line13
        // 
        this.line13.Border.BottomColor = System.Drawing.Color.Black;
        this.line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line13.Border.LeftColor = System.Drawing.Color.Black;
        this.line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line13.Border.RightColor = System.Drawing.Color.Black;
        this.line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line13.Border.TopColor = System.Drawing.Color.Black;
        this.line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line13.Height = 0F;
        this.line13.Left = 2.1875F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 0.75F;
        this.line13.Width = 3.75F;
        this.line13.X1 = 2.1875F;
        this.line13.X2 = 5.9375F;
        this.line13.Y1 = 0.75F;
        this.line13.Y2 = 0.75F;
        // 
        // line14
        // 
        this.line14.Border.BottomColor = System.Drawing.Color.Black;
        this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line14.Border.LeftColor = System.Drawing.Color.Black;
        this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line14.Border.RightColor = System.Drawing.Color.Black;
        this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line14.Border.TopColor = System.Drawing.Color.Black;
        this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line14.Height = 0F;
        this.line14.Left = 2.1875F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 0.9375F;
        this.line14.Width = 3.75F;
        this.line14.X1 = 2.1875F;
        this.line14.X2 = 5.9375F;
        this.line14.Y1 = 0.9375F;
        this.line14.Y2 = 0.9375F;
        // 
        // line15
        // 
        this.line15.Border.BottomColor = System.Drawing.Color.Black;
        this.line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line15.Border.LeftColor = System.Drawing.Color.Black;
        this.line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line15.Border.RightColor = System.Drawing.Color.Black;
        this.line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line15.Border.TopColor = System.Drawing.Color.Black;
        this.line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line15.Height = 0F;
        this.line15.Left = 2.1875F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 1.125F;
        this.line15.Width = 3.75F;
        this.line15.X1 = 2.1875F;
        this.line15.X2 = 5.9375F;
        this.line15.Y1 = 1.125F;
        this.line15.Y2 = 1.125F;
        // 
        // line16
        // 
        this.line16.Border.BottomColor = System.Drawing.Color.Black;
        this.line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line16.Border.LeftColor = System.Drawing.Color.Black;
        this.line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line16.Border.RightColor = System.Drawing.Color.Black;
        this.line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line16.Border.TopColor = System.Drawing.Color.Black;
        this.line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line16.Height = 0F;
        this.line16.Left = 2.1875F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 1.3125F;
        this.line16.Width = 3.75F;
        this.line16.X1 = 2.1875F;
        this.line16.X2 = 5.9375F;
        this.line16.Y1 = 1.3125F;
        this.line16.Y2 = 1.3125F;
        // 
        // line17
        // 
        this.line17.Border.BottomColor = System.Drawing.Color.Black;
        this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line17.Border.LeftColor = System.Drawing.Color.Black;
        this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line17.Border.RightColor = System.Drawing.Color.Black;
        this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line17.Border.TopColor = System.Drawing.Color.Black;
        this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line17.Height = 1.3125F;
        this.line17.Left = 2.1875F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 0F;
        this.line17.Width = 0F;
        this.line17.X1 = 2.1875F;
        this.line17.X2 = 2.1875F;
        this.line17.Y1 = 0F;
        this.line17.Y2 = 1.3125F;
        // 
        // line18
        // 
        this.line18.Border.BottomColor = System.Drawing.Color.Black;
        this.line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line18.Border.LeftColor = System.Drawing.Color.Black;
        this.line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line18.Border.RightColor = System.Drawing.Color.Black;
        this.line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line18.Border.TopColor = System.Drawing.Color.Black;
        this.line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line18.Height = 1.3125F;
        this.line18.Left = 5.0625F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 0F;
        this.line18.Width = 0F;
        this.line18.X1 = 5.0625F;
        this.line18.X2 = 5.0625F;
        this.line18.Y1 = 0F;
        this.line18.Y2 = 1.3125F;
        // 
        // line19
        // 
        this.line19.Border.BottomColor = System.Drawing.Color.Black;
        this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line19.Border.LeftColor = System.Drawing.Color.Black;
        this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line19.Border.RightColor = System.Drawing.Color.Black;
        this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line19.Border.TopColor = System.Drawing.Color.Black;
        this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line19.Height = 1.3125F;
        this.line19.Left = 5.9375F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 0F;
        this.line19.Width = 0F;
        this.line19.X1 = 5.9375F;
        this.line19.X2 = 5.9375F;
        this.line19.Y1 = 0F;
        this.line19.Y2 = 1.3125F;
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
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
        this.textBox1.Left = 3.0625F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "textBox1";
        this.textBox1.Top = 0.0625F;
        this.textBox1.Width = 4.25F;
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
        this.textBox2.Left = 1.25F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Reporte de Recaudación";
        this.textBox2.Top = 0.3125F;
        this.textBox2.Width = 5F;
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
        this.textBox3.Left = 1.25F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "Sucursal:";
        this.textBox3.Top = 0.5625F;
        this.textBox3.Width = 1.3125F;
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
        this.textBox4.Left = 2.625F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "textBox4";
        this.textBox4.Top = 0.5625F;
        this.textBox4.Width = 3.625F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.picture1,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox29,
            this.textBox30,
            this.textBox34,
            this.textBox44,
            this.textBox45,
            this.textBox46});
        this.reportHeader1.Height = 1.71875F;
        this.reportHeader1.Name = "reportHeader1";
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
        // textBox23
        // 
        this.textBox23.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.RightColor = System.Drawing.Color.Black;
        this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.TopColor = System.Drawing.Color.Black;
        this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Height = 0.1875F;
        this.textBox23.Left = 1.25F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Periodo:";
        this.textBox23.Top = 0.75F;
        this.textBox23.Width = 1.3125F;
        // 
        // textBox24
        // 
        this.textBox24.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.RightColor = System.Drawing.Color.Black;
        this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.TopColor = System.Drawing.Color.Black;
        this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Height = 0.1875F;
        this.textBox24.Left = 2.625F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "textBox24";
        this.textBox24.Top = 0.75F;
        this.textBox24.Width = 3.625F;
        // 
        // textBox25
        // 
        this.textBox25.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.RightColor = System.Drawing.Color.Black;
        this.textBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Border.TopColor = System.Drawing.Color.Black;
        this.textBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 1.25F;
        this.textBox25.Name = "textBox25";
        this.textBox25.Style = "";
        this.textBox25.Text = "Forma de pago:";
        this.textBox25.Top = 0.9375F;
        this.textBox25.Width = 1.3125F;
        // 
        // textBox26
        // 
        this.textBox26.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.RightColor = System.Drawing.Color.Black;
        this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Border.TopColor = System.Drawing.Color.Black;
        this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 2.625F;
        this.textBox26.Name = "textBox26";
        this.textBox26.Style = "";
        this.textBox26.Text = "textBox26";
        this.textBox26.Top = 0.9375F;
        this.textBox26.Width = 3.625F;
        // 
        // textBox29
        // 
        this.textBox29.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.RightColor = System.Drawing.Color.Black;
        this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Border.TopColor = System.Drawing.Color.Black;
        this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox29.Height = 0.1875F;
        this.textBox29.Left = 1.25F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "";
        this.textBox29.Text = "Negocio:";
        this.textBox29.Top = 1.125F;
        this.textBox29.Width = 1.3125F;
        // 
        // textBox30
        // 
        this.textBox30.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.RightColor = System.Drawing.Color.Black;
        this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Border.TopColor = System.Drawing.Color.Black;
        this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox30.Height = 0.1875F;
        this.textBox30.Left = 2.625F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "textBox30";
        this.textBox30.Top = 1.125F;
        this.textBox30.Width = 3.625F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox42,
            this.textBox43,
            this.line4,
            this.textBox31});
        this.reportFooter1.Height = 0.8333333F;
        this.reportFooter1.Name = "reportFooter1";
        this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
        // 
        // textBox42
        // 
        this.textBox42.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.RightColor = System.Drawing.Color.Black;
        this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Border.TopColor = System.Drawing.Color.Black;
        this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox42.Height = 0.1875F;
        this.textBox42.Left = 0.625F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "Total GENERAL:";
        this.textBox42.Top = 0.125F;
        this.textBox42.Width = 4.4375F;
        // 
        // textBox43
        // 
        this.textBox43.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.Border.RightColor = System.Drawing.Color.Black;
        this.textBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.Border.TopColor = System.Drawing.Color.Black;
        this.textBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox43.DataField = "total_general";
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 5.125F;
        this.textBox43.Name = "textBox43";
        this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
        this.textBox43.Style = "";
        this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0.125F;
        this.textBox43.Width = 0.75F;
        // 
        // line4
        // 
        this.line4.Border.BottomColor = System.Drawing.Color.Black;
        this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line4.Border.LeftColor = System.Drawing.Color.Black;
        this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line4.Border.RightColor = System.Drawing.Color.Black;
        this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line4.Border.TopColor = System.Drawing.Color.Black;
        this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line4.Height = 0F;
        this.line4.Left = 0.625F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0.0625F;
        this.line4.Width = 5.3125F;
        this.line4.X1 = 0.625F;
        this.line4.X2 = 5.9375F;
        this.line4.Y1 = 0.0625F;
        this.line4.Y2 = 0.0625F;
        // 
        // textBox31
        // 
        this.textBox31.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.RightColor = System.Drawing.Color.Black;
        this.textBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Border.TopColor = System.Drawing.Color.Black;
        this.textBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox31.Height = 0.3125F;
        this.textBox31.Left = 0F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "NOTA: Para el presente reporte el negocio TERRASUR agrupa la recaudación de los n" +
            "egocios: Terrasur, CEA y ROLDAN ";
        this.textBox31.Top = 0.4375F;
        this.textBox31.Width = 6.4375F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox5,
            this.textBox6});
        this.groupHeader1.DataField = "sucursal";
        this.groupHeader1.Height = 0.1875F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox5.Left = 0.625F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "Sucursal:";
        this.textBox5.Top = 0F;
        this.textBox5.Width = 0.6875F;
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
        this.textBox6.DataField = "sucursal";
        this.textBox6.Height = 0.1875F;
        this.textBox6.Left = 1.375F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "textBox6";
        this.textBox6.Top = 0F;
        this.textBox6.Width = 4.5F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.line3});
        this.groupFooter1.Height = 0.4270833F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // textBox39
        // 
        this.textBox39.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.RightColor = System.Drawing.Color.Black;
        this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Border.TopColor = System.Drawing.Color.Black;
        this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox39.Height = 0.1875F;
        this.textBox39.Left = 0.625F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "Total:";
        this.textBox39.Top = 0.125F;
        this.textBox39.Width = 0.6875F;
        // 
        // textBox40
        // 
        this.textBox40.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.RightColor = System.Drawing.Color.Black;
        this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.Border.TopColor = System.Drawing.Color.Black;
        this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox40.DataField = "sucursal";
        this.textBox40.Height = 0.1875F;
        this.textBox40.Left = 1.375F;
        this.textBox40.Name = "textBox40";
        this.textBox40.Style = "";
        this.textBox40.Text = "textBox40";
        this.textBox40.Top = 0.125F;
        this.textBox40.Width = 3.6875F;
        // 
        // textBox41
        // 
        this.textBox41.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.RightColor = System.Drawing.Color.Black;
        this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.Border.TopColor = System.Drawing.Color.Black;
        this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox41.DataField = "total_general";
        this.textBox41.Height = 0.1875F;
        this.textBox41.Left = 5.125F;
        this.textBox41.Name = "textBox41";
        this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
        this.textBox41.Style = "";
        this.textBox41.SummaryGroup = "groupHeader1";
        this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox41.Text = "textBox41";
        this.textBox41.Top = 0.125F;
        this.textBox41.Width = 0.75F;
        // 
        // line3
        // 
        this.line3.Border.BottomColor = System.Drawing.Color.Black;
        this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Border.LeftColor = System.Drawing.Color.Black;
        this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Border.RightColor = System.Drawing.Color.Black;
        this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Border.TopColor = System.Drawing.Color.Black;
        this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line3.Height = 0F;
        this.line3.Left = 0.625F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0.0625F;
        this.line3.Width = 5.3125F;
        this.line3.X1 = 0.625F;
        this.line3.X2 = 5.9375F;
        this.line3.Y1 = 0.0625F;
        this.line3.Y2 = 0.0625F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.line5,
            this.line6,
            this.line7,
            this.line8,
            this.line24});
        this.groupHeader2.DataField = "negocio";
        this.groupHeader2.Height = 0.2604167F;
        this.groupHeader2.Name = "groupHeader2";
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
        this.textBox7.Left = 1.375F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = "Negocio:";
        this.textBox7.Top = 0.0625F;
        this.textBox7.Width = 0.8125F;
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
        this.textBox8.DataField = "negocio";
        this.textBox8.Height = 0.1875F;
        this.textBox8.Left = 2.25F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "textBox8";
        this.textBox8.Top = 0.0625F;
        this.textBox8.Width = 2.8125F;
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
        this.textBox9.Height = 0.1875F;
        this.textBox9.Left = 5.125F;
        this.textBox9.Name = "textBox9";
        this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
        this.textBox9.Style = "";
        this.textBox9.Text = "US$";
        this.textBox9.Top = 0.0625F;
        this.textBox9.Width = 0.75F;
        // 
        // line5
        // 
        this.line5.Border.BottomColor = System.Drawing.Color.Black;
        this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line5.Border.LeftColor = System.Drawing.Color.Black;
        this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line5.Border.RightColor = System.Drawing.Color.Black;
        this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line5.Border.TopColor = System.Drawing.Color.Black;
        this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line5.Height = 0F;
        this.line5.Left = 1.3125F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0.0625F;
        this.line5.Width = 4.625F;
        this.line5.X1 = 1.3125F;
        this.line5.X2 = 5.9375F;
        this.line5.Y1 = 0.0625F;
        this.line5.Y2 = 0.0625F;
        // 
        // line6
        // 
        this.line6.Border.BottomColor = System.Drawing.Color.Black;
        this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line6.Border.LeftColor = System.Drawing.Color.Black;
        this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line6.Border.RightColor = System.Drawing.Color.Black;
        this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line6.Border.TopColor = System.Drawing.Color.Black;
        this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line6.Height = 0.1875F;
        this.line6.Left = 1.3125F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0.0625F;
        this.line6.Width = 0F;
        this.line6.X1 = 1.3125F;
        this.line6.X2 = 1.3125F;
        this.line6.Y1 = 0.0625F;
        this.line6.Y2 = 0.25F;
        // 
        // line7
        // 
        this.line7.Border.BottomColor = System.Drawing.Color.Black;
        this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line7.Border.LeftColor = System.Drawing.Color.Black;
        this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line7.Border.RightColor = System.Drawing.Color.Black;
        this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line7.Border.TopColor = System.Drawing.Color.Black;
        this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line7.Height = 0.1875F;
        this.line7.Left = 5.0625F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0.0625F;
        this.line7.Width = 0F;
        this.line7.X1 = 5.0625F;
        this.line7.X2 = 5.0625F;
        this.line7.Y1 = 0.0625F;
        this.line7.Y2 = 0.25F;
        // 
        // line8
        // 
        this.line8.Border.BottomColor = System.Drawing.Color.Black;
        this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line8.Border.LeftColor = System.Drawing.Color.Black;
        this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line8.Border.RightColor = System.Drawing.Color.Black;
        this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line8.Border.TopColor = System.Drawing.Color.Black;
        this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line8.Height = 0.1875F;
        this.line8.Left = 5.9375F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0.0625F;
        this.line8.Width = 0F;
        this.line8.X1 = 5.9375F;
        this.line8.X2 = 5.9375F;
        this.line8.Y1 = 0.0625F;
        this.line8.Y2 = 0.25F;
        // 
        // line24
        // 
        this.line24.Border.BottomColor = System.Drawing.Color.Black;
        this.line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line24.Border.LeftColor = System.Drawing.Color.Black;
        this.line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line24.Border.RightColor = System.Drawing.Color.Black;
        this.line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line24.Border.TopColor = System.Drawing.Color.Black;
        this.line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line24.Height = 0F;
        this.line24.Left = 1.3125F;
        this.line24.LineWeight = 1F;
        this.line24.Name = "line24";
        this.line24.Top = 0.25F;
        this.line24.Width = 4.625F;
        this.line24.X1 = 5.9375F;
        this.line24.X2 = 1.3125F;
        this.line24.Y1 = 0.25F;
        this.line24.Y2 = 0.25F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox28,
            this.textBox32,
            this.textBox33,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.line1,
            this.line2,
            this.line20,
            this.line21,
            this.line22,
            this.line23});
        this.groupFooter2.Height = 0.875F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // textBox28
        // 
        this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.RightColor = System.Drawing.Color.Black;
        this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Border.TopColor = System.Drawing.Color.Black;
        this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 2.25F;
        this.textBox28.Name = "textBox28";
        this.textBox28.Style = "";
        this.textBox28.Text = "Total Recaudación";
        this.textBox28.Top = 0.125F;
        this.textBox28.Width = 2.8125F;
        // 
        // textBox32
        // 
        this.textBox32.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.RightColor = System.Drawing.Color.Black;
        this.textBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.Border.TopColor = System.Drawing.Color.Black;
        this.textBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox32.DataField = "total_ingresos";
        this.textBox32.Height = 0.1875F;
        this.textBox32.Left = 5.125F;
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
        this.textBox32.Style = "";
        this.textBox32.Text = "textBox32";
        this.textBox32.Top = 0.125F;
        this.textBox32.Width = 0.75F;
        // 
        // textBox33
        // 
        this.textBox33.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.RightColor = System.Drawing.Color.Black;
        this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Border.TopColor = System.Drawing.Color.Black;
        this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox33.Height = 0.1875F;
        this.textBox33.Left = 2.25F;
        this.textBox33.Name = "textBox33";
        this.textBox33.Style = "";
        this.textBox33.Text = "Total Gastos:";
        this.textBox33.Top = 0.3125F;
        this.textBox33.Width = 2.8125F;
        // 
        // textBox35
        // 
        this.textBox35.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.RightColor = System.Drawing.Color.Black;
        this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.Border.TopColor = System.Drawing.Color.Black;
        this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox35.DataField = "gastos";
        this.textBox35.Height = 0.1875F;
        this.textBox35.Left = 5.125F;
        this.textBox35.Name = "textBox35";
        this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
        this.textBox35.Style = "";
        this.textBox35.Text = "textBox35";
        this.textBox35.Top = 0.3125F;
        this.textBox35.Width = 0.75F;
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
        this.textBox36.Left = 2.25F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Total (Recaudación - Gastos):";
        this.textBox36.Top = 0.625F;
        this.textBox36.Width = 2F;
        // 
        // textBox37
        // 
        this.textBox37.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.RightColor = System.Drawing.Color.Black;
        this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.Border.TopColor = System.Drawing.Color.Black;
        this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox37.DataField = "negocio";
        this.textBox37.Height = 0.1875F;
        this.textBox37.Left = 4.25F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "textBox37";
        this.textBox37.Top = 0.625F;
        this.textBox37.Width = 0.8125F;
        // 
        // textBox38
        // 
        this.textBox38.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.RightColor = System.Drawing.Color.Black;
        this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.Border.TopColor = System.Drawing.Color.Black;
        this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox38.DataField = "total_general";
        this.textBox38.Height = 0.1875F;
        this.textBox38.Left = 5.125F;
        this.textBox38.Name = "textBox38";
        this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
        this.textBox38.Style = "";
        this.textBox38.Text = "textBox38";
        this.textBox38.Top = 0.625F;
        this.textBox38.Width = 0.75F;
        // 
        // line1
        // 
        this.line1.Border.BottomColor = System.Drawing.Color.Black;
        this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.LeftColor = System.Drawing.Color.Black;
        this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.RightColor = System.Drawing.Color.Black;
        this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Border.TopColor = System.Drawing.Color.Black;
        this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line1.Height = 0F;
        this.line1.Left = 2.1875F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.0625F;
        this.line1.Width = 3.75F;
        this.line1.X1 = 2.1875F;
        this.line1.X2 = 5.9375F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
        // 
        // line2
        // 
        this.line2.Border.BottomColor = System.Drawing.Color.Black;
        this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.LeftColor = System.Drawing.Color.Black;
        this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.RightColor = System.Drawing.Color.Black;
        this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Border.TopColor = System.Drawing.Color.Black;
        this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line2.Height = 0F;
        this.line2.Left = 2.1875F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0.5625F;
        this.line2.Width = 3.75F;
        this.line2.X1 = 2.1875F;
        this.line2.X2 = 5.9375F;
        this.line2.Y1 = 0.5625F;
        this.line2.Y2 = 0.5625F;
        // 
        // line20
        // 
        this.line20.Border.BottomColor = System.Drawing.Color.Black;
        this.line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line20.Border.LeftColor = System.Drawing.Color.Black;
        this.line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line20.Border.RightColor = System.Drawing.Color.Black;
        this.line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line20.Border.TopColor = System.Drawing.Color.Black;
        this.line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line20.Height = 0.875F;
        this.line20.Left = 2.1875F;
        this.line20.LineWeight = 1F;
        this.line20.Name = "line20";
        this.line20.Top = 0F;
        this.line20.Width = 0F;
        this.line20.X1 = 2.1875F;
        this.line20.X2 = 2.1875F;
        this.line20.Y1 = 0F;
        this.line20.Y2 = 0.875F;
        // 
        // line21
        // 
        this.line21.Border.BottomColor = System.Drawing.Color.Black;
        this.line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line21.Border.LeftColor = System.Drawing.Color.Black;
        this.line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line21.Border.RightColor = System.Drawing.Color.Black;
        this.line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line21.Border.TopColor = System.Drawing.Color.Black;
        this.line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line21.Height = 0.875F;
        this.line21.Left = 5.0625F;
        this.line21.LineWeight = 1F;
        this.line21.Name = "line21";
        this.line21.Top = 0F;
        this.line21.Width = 0F;
        this.line21.X1 = 5.0625F;
        this.line21.X2 = 5.0625F;
        this.line21.Y1 = 0F;
        this.line21.Y2 = 0.875F;
        // 
        // line22
        // 
        this.line22.Border.BottomColor = System.Drawing.Color.Black;
        this.line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line22.Border.LeftColor = System.Drawing.Color.Black;
        this.line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line22.Border.RightColor = System.Drawing.Color.Black;
        this.line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line22.Border.TopColor = System.Drawing.Color.Black;
        this.line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line22.Height = 0.875F;
        this.line22.Left = 5.9375F;
        this.line22.LineWeight = 1F;
        this.line22.Name = "line22";
        this.line22.Top = 0F;
        this.line22.Width = 0F;
        this.line22.X1 = 5.9375F;
        this.line22.X2 = 5.9375F;
        this.line22.Y1 = 0F;
        this.line22.Y2 = 0.875F;
        // 
        // line23
        // 
        this.line23.Border.BottomColor = System.Drawing.Color.Black;
        this.line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line23.Border.LeftColor = System.Drawing.Color.Black;
        this.line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line23.Border.RightColor = System.Drawing.Color.Black;
        this.line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line23.Border.TopColor = System.Drawing.Color.Black;
        this.line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line23.Height = 0F;
        this.line23.Left = 2.1875F;
        this.line23.LineWeight = 1F;
        this.line23.Name = "line23";
        this.line23.Top = 0.875F;
        this.line23.Width = 3.75F;
        this.line23.X1 = 5.9375F;
        this.line23.X2 = 2.1875F;
        this.line23.Y1 = 0.875F;
        this.line23.Y2 = 0.875F;
        // 
        // textBox34
        // 
        this.textBox34.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.RightColor = System.Drawing.Color.Black;
        this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Border.TopColor = System.Drawing.Color.Black;
        this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox34.Height = 0.1875F;
        this.textBox34.Left = 1.25F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "MONEDA:";
        this.textBox34.Top = 1.3125F;
        this.textBox34.Width = 1.3125F;
        // 
        // textBox44
        // 
        this.textBox44.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Border.RightColor = System.Drawing.Color.Black;
        this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Border.TopColor = System.Drawing.Color.Black;
        this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox44.Height = 0.1875F;
        this.textBox44.Left = 2.625F;
        this.textBox44.Name = "textBox44";
        this.textBox44.Style = "";
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 1.3125F;
        this.textBox44.Width = 3.625F;
        // 
        // textBox45
        // 
        this.textBox45.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Border.RightColor = System.Drawing.Color.Black;
        this.textBox45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Border.TopColor = System.Drawing.Color.Black;
        this.textBox45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox45.Height = 0.1875F;
        this.textBox45.Left = 1.25F;
        this.textBox45.Name = "textBox45";
        this.textBox45.Style = "";
        this.textBox45.Text = "DATOS:";
        this.textBox45.Top = 1.5F;
        this.textBox45.Width = 1.3125F;
        // 
        // textBox46
        // 
        this.textBox46.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Border.RightColor = System.Drawing.Color.Black;
        this.textBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Border.TopColor = System.Drawing.Color.Black;
        this.textBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 2.625F;
        this.textBox46.Name = "textBox46";
        this.textBox46.Style = "";
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 1.5F;
        this.textBox46.Width = 3.625F;
        // 
        // rpt_ingresosRecaudacion
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 7.333333F;
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
        this.ReportStart += new System.EventHandler(this.rpt_ingresosRecaudacion_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void reportFooter1_Format(object sender, EventArgs e)
    {
        //decimal SubTotalEfectivo = decimal.Parse(textBox49.Text) - decimal.Parse(textBox46.Text);
        //textBox43.Text = SubTotalEfectivo.ToString("N2");
    }

}
