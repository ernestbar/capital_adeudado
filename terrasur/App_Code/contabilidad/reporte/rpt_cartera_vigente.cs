using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_cartera_vigente.
/// </summary>
public class rpt_cartera_vigente : DataDynamics.ActiveReports.ActiveReport3
{
    public void CargarDatos(DateTime Fecha,string Negocio, string Localizacion, string Urbanizacion, string Manzano, string Moneda, string Consolidado, string Codigo_moneda)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox4.Text = Fecha.ToString("d");
        textBox113.Text = Negocio;
        textBox115.Text = Localizacion;
        textBox117.Text = Urbanizacion;
        textBox119.Text = Manzano;

        textBox124.Text = Moneda;
        textBox126.Text = Consolidado;
        textBox37.Text = "Valor Orig. (" + Codigo_moneda + ")";
        textBox39.Text = "Desc. (" + Codigo_moneda + ")";
        textBox40.Text = "Valor final (" + Codigo_moneda + ")";
        textBox41.Text = "Cuota Inicial (" + Codigo_moneda + ")";
        textBox44.Text = "Cuota mensual (" + Codigo_moneda + ")";
        textBox53.Text = "Valor final lote (" + Codigo_moneda + ")";
        textBox54.Text = "Total aport. (" + Codigo_moneda + ")";
        textBox55.Text = "Aporte inte. (" + Codigo_moneda + ")";
        textBox56.Text = "Aporte amortiz. (" + Codigo_moneda + ")";
        textBox57.Text = "Saldo (" + Codigo_moneda + ")";
    }

    private void rpt_cartera_vigente_ReportStart(object sender, EventArgs e)
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
        textBox112.ClassName = "estiloEncabEnun";
        textBox113.ClassName = "estiloEncabDato";
        textBox114.ClassName = "estiloEncabEnun";
        textBox115.ClassName = "estiloEncabDato";
        textBox116.ClassName = "estiloEncabEnun";
        textBox117.ClassName = "estiloEncabDato";
        textBox118.ClassName = "estiloEncabEnun";
        textBox119.ClassName = "estiloEncabDato";

        textBox123.ClassName = "estiloEncabEnun";
        textBox124.ClassName = "estiloEncabDato";
        textBox125.ClassName = "estiloEncabEnun";
        textBox126.ClassName = "estiloEncabDato";

        textBox5.ClassName = "estiloDetalleGrupo";
        textBox6.ClassName = "estiloDetalleGrupo";
        textBox7.ClassName = "estiloDetalleGrupo";
        textBox8.ClassName = "estiloDetalleGrupo";
        textBox9.ClassName = "estiloDetalleGrupo";
        textBox10.ClassName = "estiloDetalleGrupo";
        textBox11.ClassName = "estiloDetalleGrupo";
        textBox12.ClassName = "estiloDetalleGrupo";

        textBox13.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox15.ClassName = "estiloDetalleEnun";
        textBox16.ClassName = "estiloDetalleEnun";
        textBox121.ClassName = "estiloDetalleEnun";
        textBox17.ClassName = "estiloDetalleEnun";
        textBox110.ClassName = "estiloDetalleEnun";
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
        textBox35.ClassName = "estiloDetalleEnun";
        textBox36.ClassName = "estiloDetalleEnun";
        textBox37.ClassName = "estiloDetalleEnun";
        textBox38.ClassName = "estiloDetalleEnun";
        textBox39.ClassName = "estiloDetalleEnun";
        textBox40.ClassName = "estiloDetalleEnun";
        textBox41.ClassName = "estiloDetalleEnun";
        textBox42.ClassName = "estiloDetalleEnun";
        textBox43.ClassName = "estiloDetalleEnun";
        textBox44.ClassName = "estiloDetalleEnun";
        textBox45.ClassName = "estiloDetalleEnun";
        textBox46.ClassName = "estiloDetalleEnun";
        textBox47.ClassName = "estiloDetalleEnun";
        textBox48.ClassName = "estiloDetalleEnun";
        textBox49.ClassName = "estiloDetalleEnun";
        textBox50.ClassName = "estiloDetalleEnun";
        textBox51.ClassName = "estiloDetalleEnun";
        textBox52.ClassName = "estiloDetalleEnun";
        textBox53.ClassName = "estiloDetalleEnun";
        textBox54.ClassName = "estiloDetalleEnun";
        textBox55.ClassName = "estiloDetalleEnun";
        textBox56.ClassName = "estiloDetalleEnun";
        textBox57.ClassName = "estiloDetalleEnun";

        textBox58.ClassName = "estiloDetalleDatoString";
        textBox59.ClassName = "estiloDetalleDatoString";
        textBox60.ClassName = "estiloDetalleDatoString";
        textBox61.ClassName = "estiloDetalleDato";
        textBox122.ClassName = "estiloDetalleDatoString";
        textBox62.ClassName = "estiloDetalleDatoString";
        textBox111.ClassName = "estiloDetalleDatoString";
        textBox63.ClassName = "estiloDetalleDatoString";
        textBox64.ClassName = "estiloDetalleDatoString";
        textBox65.ClassName = "estiloDetalleDatoString";
        textBox66.ClassName = "estiloDetalleDatoString";
        textBox67.ClassName = "estiloDetalleDatoString";
        textBox68.ClassName = "estiloDetalleDatoString";
        textBox69.ClassName = "estiloDetalleDatoString";
        textBox70.ClassName = "estiloDetalleDatoString";
        textBox71.ClassName = "estiloDetalleDatoString";
        textBox72.ClassName = "estiloDetalleDatoString";
        textBox73.ClassName = "estiloDetalleDatoString";
        textBox74.ClassName = "estiloDetalleDatoString";
        textBox75.ClassName = "estiloDetalleDatoString";
        textBox76.ClassName = "estiloDetalleDatoString";
        textBox77.ClassName = "estiloDetalleDatoString";
        textBox78.ClassName = "estiloDetalleDatoString";
        textBox79.ClassName = "estiloDetalleDatoString";
        textBox80.ClassName = "estiloDetalleDatoString";
        textBox81.ClassName = "estiloDetalleDatoString";
        textBox82.ClassName = "estiloDetalleDato";
        textBox83.ClassName = "estiloDetalleDato";
        textBox84.ClassName = "estiloDetalleDato";
        textBox85.ClassName = "estiloDetalleDato";
        textBox86.ClassName = "estiloDetalleDato";
        textBox87.ClassName = "estiloDetalleDato";
        textBox88.ClassName = "estiloDetalleDato";
        textBox89.ClassName = "estiloDetalleDato";
        textBox90.ClassName = "estiloDetalleDatoString";
        textBox91.ClassName = "estiloDetalleDatoString";
        textBox92.ClassName = "estiloDetalleDatoString";
        textBox93.ClassName = "estiloDetalleDatoString";
        textBox94.ClassName = "estiloDetalleDato";
        textBox95.ClassName = "estiloDetalleDato";
        textBox96.ClassName = "estiloDetalleDato";
        textBox97.ClassName = "estiloDetalleDato";
        textBox98.ClassName = "estiloDetalleDato";
        textBox99.ClassName = "estiloDetalleDato";
        textBox100.ClassName = "estiloDetalleDato";
        textBox101.ClassName = "estiloDetalleDato";
        textBox102.ClassName = "estiloDetalleDato";


        textBox103.ClassName = "estiloTotal";
        textBox104.ClassName = "estiloTotal";
        textBox105.ClassName = "estiloTotal";
        textBox106.ClassName = "estiloTotal";
        textBox107.ClassName = "estiloTotal";
        textBox108.ClassName = "estiloTotal";
        textBox109.ClassName = "estiloTotal";
        textBox120.ClassName = "estiloTotal";
        //Report (footer):
        //Cometario:
    } 

	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private Picture picture1;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
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
    private TextBox textBox59;
    private TextBox textBox60;
    private TextBox textBox61;
    private TextBox textBox62;
    private TextBox textBox63;
    private TextBox textBox64;
    private TextBox textBox65;
    private TextBox textBox66;
    private TextBox textBox67;
    private TextBox textBox68;
    private TextBox textBox69;
    private TextBox textBox70;
    private TextBox textBox71;
    private TextBox textBox72;
    private TextBox textBox73;
    private TextBox textBox74;
    private TextBox textBox75;
    private TextBox textBox76;
    private TextBox textBox77;
    private TextBox textBox78;
    private TextBox textBox79;
    private TextBox textBox80;
    private TextBox textBox81;
    private TextBox textBox82;
    private TextBox textBox83;
    private TextBox textBox84;
    private TextBox textBox85;
    private TextBox textBox86;
    private TextBox textBox87;
    private TextBox textBox88;
    private TextBox textBox89;
    private TextBox textBox90;
    private TextBox textBox91;
    private TextBox textBox92;
    private TextBox textBox93;
    private TextBox textBox94;
    private TextBox textBox95;
    private TextBox textBox96;
    private TextBox textBox97;
    private TextBox textBox98;
    private TextBox textBox99;
    private TextBox textBox100;
    private TextBox textBox101;
    private TextBox textBox102;
    private TextBox textBox103;
    private TextBox textBox104;
    private TextBox textBox105;
    private TextBox textBox106;
    private TextBox textBox107;
    private TextBox textBox108;
    private TextBox textBox109;
    private Line line1;
    private TextBox textBox111;
    private TextBox textBox110;
    private TextBox textBox112;
    private TextBox textBox113;
    private TextBox textBox114;
    private TextBox textBox115;
    private TextBox textBox116;
    private TextBox textBox117;
    private TextBox textBox118;
    private TextBox textBox119;
    private TextBox textBox120;
    private TextBox textBox122;
    private TextBox textBox121;
    private TextBox textBox123;
    private TextBox textBox124;
    private TextBox textBox125;
    private TextBox textBox126;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_cartera_vigente()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_cartera_vigente));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
        this.textBox59 = new DataDynamics.ActiveReports.TextBox();
        this.textBox60 = new DataDynamics.ActiveReports.TextBox();
        this.textBox61 = new DataDynamics.ActiveReports.TextBox();
        this.textBox62 = new DataDynamics.ActiveReports.TextBox();
        this.textBox63 = new DataDynamics.ActiveReports.TextBox();
        this.textBox64 = new DataDynamics.ActiveReports.TextBox();
        this.textBox65 = new DataDynamics.ActiveReports.TextBox();
        this.textBox66 = new DataDynamics.ActiveReports.TextBox();
        this.textBox67 = new DataDynamics.ActiveReports.TextBox();
        this.textBox68 = new DataDynamics.ActiveReports.TextBox();
        this.textBox69 = new DataDynamics.ActiveReports.TextBox();
        this.textBox70 = new DataDynamics.ActiveReports.TextBox();
        this.textBox71 = new DataDynamics.ActiveReports.TextBox();
        this.textBox72 = new DataDynamics.ActiveReports.TextBox();
        this.textBox73 = new DataDynamics.ActiveReports.TextBox();
        this.textBox74 = new DataDynamics.ActiveReports.TextBox();
        this.textBox75 = new DataDynamics.ActiveReports.TextBox();
        this.textBox76 = new DataDynamics.ActiveReports.TextBox();
        this.textBox77 = new DataDynamics.ActiveReports.TextBox();
        this.textBox78 = new DataDynamics.ActiveReports.TextBox();
        this.textBox80 = new DataDynamics.ActiveReports.TextBox();
        this.textBox81 = new DataDynamics.ActiveReports.TextBox();
        this.textBox82 = new DataDynamics.ActiveReports.TextBox();
        this.textBox83 = new DataDynamics.ActiveReports.TextBox();
        this.textBox84 = new DataDynamics.ActiveReports.TextBox();
        this.textBox85 = new DataDynamics.ActiveReports.TextBox();
        this.textBox86 = new DataDynamics.ActiveReports.TextBox();
        this.textBox87 = new DataDynamics.ActiveReports.TextBox();
        this.textBox88 = new DataDynamics.ActiveReports.TextBox();
        this.textBox89 = new DataDynamics.ActiveReports.TextBox();
        this.textBox90 = new DataDynamics.ActiveReports.TextBox();
        this.textBox91 = new DataDynamics.ActiveReports.TextBox();
        this.textBox92 = new DataDynamics.ActiveReports.TextBox();
        this.textBox93 = new DataDynamics.ActiveReports.TextBox();
        this.textBox94 = new DataDynamics.ActiveReports.TextBox();
        this.textBox95 = new DataDynamics.ActiveReports.TextBox();
        this.textBox96 = new DataDynamics.ActiveReports.TextBox();
        this.textBox97 = new DataDynamics.ActiveReports.TextBox();
        this.textBox98 = new DataDynamics.ActiveReports.TextBox();
        this.textBox99 = new DataDynamics.ActiveReports.TextBox();
        this.textBox100 = new DataDynamics.ActiveReports.TextBox();
        this.textBox101 = new DataDynamics.ActiveReports.TextBox();
        this.textBox102 = new DataDynamics.ActiveReports.TextBox();
        this.textBox79 = new DataDynamics.ActiveReports.TextBox();
        this.textBox111 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
        this.textBox110 = new DataDynamics.ActiveReports.TextBox();
        this.textBox112 = new DataDynamics.ActiveReports.TextBox();
        this.textBox113 = new DataDynamics.ActiveReports.TextBox();
        this.textBox114 = new DataDynamics.ActiveReports.TextBox();
        this.textBox115 = new DataDynamics.ActiveReports.TextBox();
        this.textBox116 = new DataDynamics.ActiveReports.TextBox();
        this.textBox117 = new DataDynamics.ActiveReports.TextBox();
        this.textBox118 = new DataDynamics.ActiveReports.TextBox();
        this.textBox119 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox106 = new DataDynamics.ActiveReports.TextBox();
        this.textBox107 = new DataDynamics.ActiveReports.TextBox();
        this.textBox108 = new DataDynamics.ActiveReports.TextBox();
        this.textBox109 = new DataDynamics.ActiveReports.TextBox();
        this.textBox103 = new DataDynamics.ActiveReports.TextBox();
        this.textBox104 = new DataDynamics.ActiveReports.TextBox();
        this.textBox105 = new DataDynamics.ActiveReports.TextBox();
        this.textBox120 = new DataDynamics.ActiveReports.TextBox();
        this.textBox121 = new DataDynamics.ActiveReports.TextBox();
        this.textBox122 = new DataDynamics.ActiveReports.TextBox();
        this.textBox123 = new DataDynamics.ActiveReports.TextBox();
        this.textBox124 = new DataDynamics.ActiveReports.TextBox();
        this.textBox125 = new DataDynamics.ActiveReports.TextBox();
        this.textBox126 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox80)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox81)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox82)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox83)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox84)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox85)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox86)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox87)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox90)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox92)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox93)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox94)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox95)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
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
            this.textBox58,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.textBox63,
            this.textBox64,
            this.textBox65,
            this.textBox66,
            this.textBox67,
            this.textBox68,
            this.textBox69,
            this.textBox70,
            this.textBox71,
            this.textBox72,
            this.textBox73,
            this.textBox74,
            this.textBox75,
            this.textBox76,
            this.textBox77,
            this.textBox78,
            this.textBox80,
            this.textBox81,
            this.textBox82,
            this.textBox83,
            this.textBox84,
            this.textBox85,
            this.textBox86,
            this.textBox87,
            this.textBox88,
            this.textBox89,
            this.textBox90,
            this.textBox91,
            this.textBox92,
            this.textBox93,
            this.textBox94,
            this.textBox95,
            this.textBox96,
            this.textBox97,
            this.textBox98,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textBox102,
            this.textBox79,
            this.textBox111,
            this.textBox122});
        this.detail.Height = 0.1979167F;
        this.detail.Name = "detail";
        // 
        // textBox58
        // 
        this.textBox58.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.Border.RightColor = System.Drawing.Color.Black;
        this.textBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.Border.TopColor = System.Drawing.Color.Black;
        this.textBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox58.DataField = "grupo_ventas";
        this.textBox58.Height = 0.1875F;
        this.textBox58.Left = 0.0625F;
        this.textBox58.Name = "textBox58";
        this.textBox58.Style = "";
        this.textBox58.Text = "Grupo de Ventas";
        this.textBox58.Top = 0F;
        this.textBox58.Width = 0.9375F;
        // 
        // textBox59
        // 
        this.textBox59.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox59.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox59.Border.RightColor = System.Drawing.Color.Black;
        this.textBox59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox59.Border.TopColor = System.Drawing.Color.Black;
        this.textBox59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox59.DataField = "director";
        this.textBox59.Height = 0.1875F;
        this.textBox59.Left = 1F;
        this.textBox59.Name = "textBox59";
        this.textBox59.Style = "";
        this.textBox59.Text = "Director del grupo";
        this.textBox59.Top = 0F;
        this.textBox59.Width = 2.25F;
        // 
        // textBox60
        // 
        this.textBox60.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox60.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox60.Border.RightColor = System.Drawing.Color.Black;
        this.textBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox60.Border.TopColor = System.Drawing.Color.Black;
        this.textBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox60.DataField = "promotor";
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 3.25F;
        this.textBox60.Name = "textBox60";
        this.textBox60.Style = "";
        this.textBox60.Text = "Promotor";
        this.textBox60.Top = 0F;
        this.textBox60.Width = 2.25F;
        // 
        // textBox61
        // 
        this.textBox61.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox61.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox61.Border.RightColor = System.Drawing.Color.Black;
        this.textBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox61.Border.TopColor = System.Drawing.Color.Black;
        this.textBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox61.DataField = "numero_contrato";
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 5.5F;
        this.textBox61.Name = "textBox61";
        this.textBox61.Style = "";
        this.textBox61.Text = "Nº contrato";
        this.textBox61.Top = 0F;
        this.textBox61.Width = 0.8125F;
        // 
        // textBox62
        // 
        this.textBox62.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox62.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox62.Border.RightColor = System.Drawing.Color.Black;
        this.textBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox62.Border.TopColor = System.Drawing.Color.Black;
        this.textBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox62.DataField = "fecha_registro";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 6.875F;
        this.textBox62.Name = "textBox62";
        this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
        this.textBox62.Style = "";
        this.textBox62.Text = "F.registro";
        this.textBox62.Top = 0F;
        this.textBox62.Width = 0.75F;
        // 
        // textBox63
        // 
        this.textBox63.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox63.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox63.Border.RightColor = System.Drawing.Color.Black;
        this.textBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox63.Border.TopColor = System.Drawing.Color.Black;
        this.textBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox63.DataField = "localizacion";
        this.textBox63.Height = 0.1875F;
        this.textBox63.Left = 8.625F;
        this.textBox63.Name = "textBox63";
        this.textBox63.Style = "";
        this.textBox63.Text = "Localiz.";
        this.textBox63.Top = 0F;
        this.textBox63.Width = 0.5F;
        // 
        // textBox64
        // 
        this.textBox64.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox64.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox64.Border.RightColor = System.Drawing.Color.Black;
        this.textBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox64.Border.TopColor = System.Drawing.Color.Black;
        this.textBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox64.DataField = "urbanizacion";
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 9.125F;
        this.textBox64.Name = "textBox64";
        this.textBox64.Style = "";
        this.textBox64.Text = "Sector";
        this.textBox64.Top = 0F;
        this.textBox64.Width = 1.375F;
        // 
        // textBox65
        // 
        this.textBox65.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox65.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox65.Border.RightColor = System.Drawing.Color.Black;
        this.textBox65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox65.Border.TopColor = System.Drawing.Color.Black;
        this.textBox65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox65.DataField = "manzano";
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 10.625F;
        this.textBox65.Name = "textBox65";
        this.textBox65.Style = "";
        this.textBox65.Text = "Mzno.";
        this.textBox65.Top = 0F;
        this.textBox65.Width = 0.5F;
        // 
        // textBox66
        // 
        this.textBox66.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox66.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox66.Border.RightColor = System.Drawing.Color.Black;
        this.textBox66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox66.Border.TopColor = System.Drawing.Color.Black;
        this.textBox66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox66.DataField = "lote";
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 11.125F;
        this.textBox66.Name = "textBox66";
        this.textBox66.Style = "";
        this.textBox66.Text = "Lote";
        this.textBox66.Top = 0F;
        this.textBox66.Width = 0.5F;
        // 
        // textBox67
        // 
        this.textBox67.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox67.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox67.Border.RightColor = System.Drawing.Color.Black;
        this.textBox67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox67.Border.TopColor = System.Drawing.Color.Black;
        this.textBox67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox67.DataField = "paterno";
        this.textBox67.Height = 0.1875F;
        this.textBox67.Left = 11.625F;
        this.textBox67.Name = "textBox67";
        this.textBox67.Style = "";
        this.textBox67.Text = "Apellido Paterno";
        this.textBox67.Top = 0F;
        this.textBox67.Width = 1.25F;
        // 
        // textBox68
        // 
        this.textBox68.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox68.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox68.Border.RightColor = System.Drawing.Color.Black;
        this.textBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox68.Border.TopColor = System.Drawing.Color.Black;
        this.textBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox68.DataField = "materno";
        this.textBox68.Height = 0.1875F;
        this.textBox68.Left = 12.875F;
        this.textBox68.Name = "textBox68";
        this.textBox68.Style = "";
        this.textBox68.Text = "Apellido Materno";
        this.textBox68.Top = 0F;
        this.textBox68.Width = 1.25F;
        // 
        // textBox69
        // 
        this.textBox69.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox69.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox69.Border.RightColor = System.Drawing.Color.Black;
        this.textBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox69.Border.TopColor = System.Drawing.Color.Black;
        this.textBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox69.DataField = "nombres";
        this.textBox69.Height = 0.1875F;
        this.textBox69.Left = 14.125F;
        this.textBox69.Name = "textBox69";
        this.textBox69.Style = "";
        this.textBox69.Text = "Nombres";
        this.textBox69.Top = 0F;
        this.textBox69.Width = 2F;
        // 
        // textBox70
        // 
        this.textBox70.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox70.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox70.Border.RightColor = System.Drawing.Color.Black;
        this.textBox70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox70.Border.TopColor = System.Drawing.Color.Black;
        this.textBox70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox70.DataField = "ci";
        this.textBox70.Height = 0.1875F;
        this.textBox70.Left = 16.125F;
        this.textBox70.Name = "textBox70";
        this.textBox70.Style = "";
        this.textBox70.Text = "C.I.";
        this.textBox70.Top = 0F;
        this.textBox70.Width = 1F;
        // 
        // textBox71
        // 
        this.textBox71.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox71.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox71.Border.RightColor = System.Drawing.Color.Black;
        this.textBox71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox71.Border.TopColor = System.Drawing.Color.Black;
        this.textBox71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox71.DataField = "nit";
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 17.125F;
        this.textBox71.Name = "textBox71";
        this.textBox71.Style = "";
        this.textBox71.Text = "NIT";
        this.textBox71.Top = 0F;
        this.textBox71.Width = 0.875F;
        // 
        // textBox72
        // 
        this.textBox72.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox72.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox72.Border.RightColor = System.Drawing.Color.Black;
        this.textBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox72.Border.TopColor = System.Drawing.Color.Black;
        this.textBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox72.DataField = "celular";
        this.textBox72.Height = 0.1875F;
        this.textBox72.Left = 18F;
        this.textBox72.Name = "textBox72";
        this.textBox72.Style = "";
        this.textBox72.Text = "Celular";
        this.textBox72.Top = 0F;
        this.textBox72.Width = 0.75F;
        // 
        // textBox73
        // 
        this.textBox73.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox73.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox73.Border.RightColor = System.Drawing.Color.Black;
        this.textBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox73.Border.TopColor = System.Drawing.Color.Black;
        this.textBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox73.DataField = "fax";
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 18.75F;
        this.textBox73.Name = "textBox73";
        this.textBox73.Style = "";
        this.textBox73.Text = "Fax";
        this.textBox73.Top = 0F;
        this.textBox73.Width = 0.75F;
        // 
        // textBox74
        // 
        this.textBox74.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox74.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox74.Border.RightColor = System.Drawing.Color.Black;
        this.textBox74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox74.Border.TopColor = System.Drawing.Color.Black;
        this.textBox74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox74.DataField = "email";
        this.textBox74.Height = 0.1875F;
        this.textBox74.Left = 19.5F;
        this.textBox74.Name = "textBox74";
        this.textBox74.Style = "";
        this.textBox74.Text = "Email";
        this.textBox74.Top = 0F;
        this.textBox74.Width = 1.875F;
        // 
        // textBox75
        // 
        this.textBox75.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox75.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox75.Border.RightColor = System.Drawing.Color.Black;
        this.textBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox75.Border.TopColor = System.Drawing.Color.Black;
        this.textBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox75.DataField = "casilla";
        this.textBox75.Height = 0.1875F;
        this.textBox75.Left = 21.5F;
        this.textBox75.Name = "textBox75";
        this.textBox75.Style = "";
        this.textBox75.Text = "Casilla";
        this.textBox75.Top = 0F;
        this.textBox75.Width = 0.5F;
        // 
        // textBox76
        // 
        this.textBox76.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox76.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox76.Border.RightColor = System.Drawing.Color.Black;
        this.textBox76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox76.Border.TopColor = System.Drawing.Color.Black;
        this.textBox76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox76.DataField = "domicilio_direccion";
        this.textBox76.Height = 0.1875F;
        this.textBox76.Left = 22F;
        this.textBox76.Name = "textBox76";
        this.textBox76.Style = "white-space: inherit; ";
        this.textBox76.Text = "Dirección (Domicilio)";
        this.textBox76.Top = 0F;
        this.textBox76.Width = 4F;
        // 
        // textBox77
        // 
        this.textBox77.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox77.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox77.Border.RightColor = System.Drawing.Color.Black;
        this.textBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox77.Border.TopColor = System.Drawing.Color.Black;
        this.textBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox77.DataField = "domicilio_fono";
        this.textBox77.Height = 0.1875F;
        this.textBox77.Left = 26F;
        this.textBox77.Name = "textBox77";
        this.textBox77.Style = "";
        this.textBox77.Text = "Fono. (Domicilio)";
        this.textBox77.Top = 0F;
        this.textBox77.Width = 0.625F;
        // 
        // textBox78
        // 
        this.textBox78.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox78.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox78.Border.RightColor = System.Drawing.Color.Black;
        this.textBox78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox78.Border.TopColor = System.Drawing.Color.Black;
        this.textBox78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox78.DataField = "domicilio_zona";
        this.textBox78.Height = 0.1875F;
        this.textBox78.Left = 26.625F;
        this.textBox78.Name = "textBox78";
        this.textBox78.Style = "";
        this.textBox78.Text = "Zona (Domicilio)";
        this.textBox78.Top = 0F;
        this.textBox78.Width = 2.0625F;
        // 
        // textBox80
        // 
        this.textBox80.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox80.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox80.Border.RightColor = System.Drawing.Color.Black;
        this.textBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox80.Border.TopColor = System.Drawing.Color.Black;
        this.textBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox80.DataField = "oficina_fono";
        this.textBox80.Height = 0.1875F;
        this.textBox80.Left = 32.6875F;
        this.textBox80.Name = "textBox80";
        this.textBox80.Style = "";
        this.textBox80.Text = "Teléfono (Oficina)";
        this.textBox80.Top = 0F;
        this.textBox80.Width = 0.625F;
        // 
        // textBox81
        // 
        this.textBox81.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox81.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox81.Border.RightColor = System.Drawing.Color.Black;
        this.textBox81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox81.Border.TopColor = System.Drawing.Color.Black;
        this.textBox81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox81.DataField = "oficina_zona";
        this.textBox81.Height = 0.1875F;
        this.textBox81.Left = 33.3125F;
        this.textBox81.Name = "textBox81";
        this.textBox81.Style = "";
        this.textBox81.Text = "Zona (Oficina)";
        this.textBox81.Top = 0F;
        this.textBox81.Width = 2F;
        // 
        // textBox82
        // 
        this.textBox82.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox82.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox82.Border.RightColor = System.Drawing.Color.Black;
        this.textBox82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox82.Border.TopColor = System.Drawing.Color.Black;
        this.textBox82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox82.DataField = "precio";
        this.textBox82.Height = 0.1875F;
        this.textBox82.Left = 35.3125F;
        this.textBox82.Name = "textBox82";
        this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
        this.textBox82.Style = "";
        this.textBox82.Text = "Valor Original";
        this.textBox82.Top = 0F;
        this.textBox82.Width = 0.75F;
        // 
        // textBox83
        // 
        this.textBox83.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox83.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox83.Border.RightColor = System.Drawing.Color.Black;
        this.textBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox83.Border.TopColor = System.Drawing.Color.Black;
        this.textBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox83.DataField = "descuento_porcentaje";
        this.textBox83.Height = 0.1875F;
        this.textBox83.Left = 36.0625F;
        this.textBox83.Name = "textBox83";
        this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
        this.textBox83.Style = "";
        this.textBox83.Text = "Desc.(%)";
        this.textBox83.Top = 0F;
        this.textBox83.Width = 0.625F;
        // 
        // textBox84
        // 
        this.textBox84.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox84.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox84.Border.RightColor = System.Drawing.Color.Black;
        this.textBox84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox84.Border.TopColor = System.Drawing.Color.Black;
        this.textBox84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox84.DataField = "descuento_efectivo";
        this.textBox84.Height = 0.1875F;
        this.textBox84.Left = 36.6875F;
        this.textBox84.Name = "textBox84";
        this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
        this.textBox84.Style = "";
        this.textBox84.Text = "Desc.($us)";
        this.textBox84.Top = 0F;
        this.textBox84.Width = 0.6875F;
        // 
        // textBox85
        // 
        this.textBox85.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox85.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox85.Border.RightColor = System.Drawing.Color.Black;
        this.textBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox85.Border.TopColor = System.Drawing.Color.Black;
        this.textBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox85.DataField = "precio_final";
        this.textBox85.Height = 0.1875F;
        this.textBox85.Left = 37.375F;
        this.textBox85.Name = "textBox85";
        this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
        this.textBox85.Style = "";
        this.textBox85.Text = "Valor final";
        this.textBox85.Top = 0F;
        this.textBox85.Width = 0.875F;
        // 
        // textBox86
        // 
        this.textBox86.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox86.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox86.Border.RightColor = System.Drawing.Color.Black;
        this.textBox86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox86.Border.TopColor = System.Drawing.Color.Black;
        this.textBox86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox86.DataField = "cuota_inicial";
        this.textBox86.Height = 0.1875F;
        this.textBox86.Left = 38.25F;
        this.textBox86.Name = "textBox86";
        this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
        this.textBox86.Style = "";
        this.textBox86.Text = "Cuota Inicial";
        this.textBox86.Top = 0F;
        this.textBox86.Width = 0.875F;
        // 
        // textBox87
        // 
        this.textBox87.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox87.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox87.Border.RightColor = System.Drawing.Color.Black;
        this.textBox87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox87.Border.TopColor = System.Drawing.Color.Black;
        this.textBox87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox87.DataField = "interes_corriente";
        this.textBox87.Height = 0.1875F;
        this.textBox87.Left = 39.125F;
        this.textBox87.Name = "textBox87";
        this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
        this.textBox87.Style = "";
        this.textBox87.Text = "Interés (% anual)";
        this.textBox87.Top = 0F;
        this.textBox87.Width = 0.625F;
        // 
        // textBox88
        // 
        this.textBox88.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox88.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox88.Border.RightColor = System.Drawing.Color.Black;
        this.textBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox88.Border.TopColor = System.Drawing.Color.Black;
        this.textBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox88.DataField = "num_cuotas";
        this.textBox88.Height = 0.1875F;
        this.textBox88.Left = 39.75F;
        this.textBox88.Name = "textBox88";
        this.textBox88.Style = "";
        this.textBox88.Text = "Nº cuo";
        this.textBox88.Top = 0F;
        this.textBox88.Width = 0.4375F;
        // 
        // textBox89
        // 
        this.textBox89.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox89.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox89.Border.RightColor = System.Drawing.Color.Black;
        this.textBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox89.Border.TopColor = System.Drawing.Color.Black;
        this.textBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox89.DataField = "cuota_base";
        this.textBox89.Height = 0.1875F;
        this.textBox89.Left = 40.1875F;
        this.textBox89.Name = "textBox89";
        this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
        this.textBox89.Style = "";
        this.textBox89.Text = "Cuota mensual";
        this.textBox89.Top = 0F;
        this.textBox89.Width = 0.875F;
        // 
        // textBox90
        // 
        this.textBox90.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox90.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox90.Border.RightColor = System.Drawing.Color.Black;
        this.textBox90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox90.Border.TopColor = System.Drawing.Color.Black;
        this.textBox90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox90.DataField = "fecha_inicio_plan";
        this.textBox90.Height = 0.1875F;
        this.textBox90.Left = 41.0625F;
        this.textBox90.Name = "textBox90";
        this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
        this.textBox90.Style = "";
        this.textBox90.Text = "F.Ini.Plan";
        this.textBox90.Top = 0F;
        this.textBox90.Width = 0.75F;
        // 
        // textBox91
        // 
        this.textBox91.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox91.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox91.Border.RightColor = System.Drawing.Color.Black;
        this.textBox91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox91.Border.TopColor = System.Drawing.Color.Black;
        this.textBox91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox91.DataField = "fecha_ultimo_pago";
        this.textBox91.Height = 0.1875F;
        this.textBox91.Left = 41.8125F;
        this.textBox91.Name = "textBox91";
        this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
        this.textBox91.Style = "";
        this.textBox91.Text = "F.Ult.pago";
        this.textBox91.Top = 0F;
        this.textBox91.Width = 0.75F;
        // 
        // textBox92
        // 
        this.textBox92.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox92.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox92.Border.RightColor = System.Drawing.Color.Black;
        this.textBox92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox92.Border.TopColor = System.Drawing.Color.Black;
        this.textBox92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox92.DataField = "interes_fecha";
        this.textBox92.Height = 0.1875F;
        this.textBox92.Left = 42.5625F;
        this.textBox92.Name = "textBox92";
        this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
        this.textBox92.Style = "";
        this.textBox92.Text = "F. Interés";
        this.textBox92.Top = 0F;
        this.textBox92.Width = 0.75F;
        // 
        // textBox93
        // 
        this.textBox93.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox93.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox93.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox93.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox93.Border.RightColor = System.Drawing.Color.Black;
        this.textBox93.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox93.Border.TopColor = System.Drawing.Color.Black;
        this.textBox93.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox93.DataField = "fecha_proximo";
        this.textBox93.Height = 0.1875F;
        this.textBox93.Left = 43.3125F;
        this.textBox93.Name = "textBox93";
        this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
        this.textBox93.Style = "";
        this.textBox93.Text = "F.Prox.Pago";
        this.textBox93.Top = 0F;
        this.textBox93.Width = 0.75F;
        // 
        // textBox94
        // 
        this.textBox94.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox94.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox94.Border.RightColor = System.Drawing.Color.Black;
        this.textBox94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox94.Border.TopColor = System.Drawing.Color.Black;
        this.textBox94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox94.DataField = "num_dias_retraso";
        this.textBox94.Height = 0.1875F;
        this.textBox94.Left = 44.0625F;
        this.textBox94.Name = "textBox94";
        this.textBox94.Style = "";
        this.textBox94.Text = "Nº días retraso";
        this.textBox94.Top = 0F;
        this.textBox94.Width = 0.5F;
        // 
        // textBox95
        // 
        this.textBox95.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox95.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox95.Border.RightColor = System.Drawing.Color.Black;
        this.textBox95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox95.Border.TopColor = System.Drawing.Color.Black;
        this.textBox95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox95.DataField = "num_cuotas_adeuda";
        this.textBox95.Height = 0.1875F;
        this.textBox95.Left = 44.5625F;
        this.textBox95.Name = "textBox95";
        this.textBox95.Style = "";
        this.textBox95.Text = "Nº cuo. adeuda";
        this.textBox95.Top = 0F;
        this.textBox95.Width = 0.5F;
        // 
        // textBox96
        // 
        this.textBox96.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox96.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox96.Border.RightColor = System.Drawing.Color.Black;
        this.textBox96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox96.Border.TopColor = System.Drawing.Color.Black;
        this.textBox96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox96.DataField = "num_dias_mora";
        this.textBox96.Height = 0.1875F;
        this.textBox96.Left = 45.0625F;
        this.textBox96.Name = "textBox96";
        this.textBox96.Style = "";
        this.textBox96.Text = "Nº días mora";
        this.textBox96.Top = 0F;
        this.textBox96.Width = 0.5F;
        // 
        // textBox97
        // 
        this.textBox97.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox97.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox97.Border.RightColor = System.Drawing.Color.Black;
        this.textBox97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox97.Border.TopColor = System.Drawing.Color.Black;
        this.textBox97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox97.DataField = "num_cuotas_mora";
        this.textBox97.Height = 0.1875F;
        this.textBox97.Left = 45.5625F;
        this.textBox97.Name = "textBox97";
        this.textBox97.Style = "";
        this.textBox97.Text = "Nº cuo. mora";
        this.textBox97.Top = 0F;
        this.textBox97.Width = 0.5F;
        // 
        // textBox98
        // 
        this.textBox98.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox98.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox98.Border.RightColor = System.Drawing.Color.Black;
        this.textBox98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox98.Border.TopColor = System.Drawing.Color.Black;
        this.textBox98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox98.DataField = "valor_final_terreno";
        this.textBox98.Height = 0.1875F;
        this.textBox98.Left = 46.0625F;
        this.textBox98.Name = "textBox98";
        this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
        this.textBox98.Style = "";
        this.textBox98.Text = "Valor final lote ($us)";
        this.textBox98.Top = 0F;
        this.textBox98.Width = 0.75F;
        // 
        // textBox99
        // 
        this.textBox99.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox99.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox99.Border.RightColor = System.Drawing.Color.Black;
        this.textBox99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox99.Border.TopColor = System.Drawing.Color.Black;
        this.textBox99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox99.DataField = "total_pago";
        this.textBox99.Height = 0.1875F;
        this.textBox99.Left = 46.8125F;
        this.textBox99.Name = "textBox99";
        this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
        this.textBox99.Style = "";
        this.textBox99.Text = "Total aportado";
        this.textBox99.Top = 0F;
        this.textBox99.Width = 0.75F;
        // 
        // textBox100
        // 
        this.textBox100.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox100.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox100.Border.RightColor = System.Drawing.Color.Black;
        this.textBox100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox100.Border.TopColor = System.Drawing.Color.Black;
        this.textBox100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox100.DataField = "total_interes";
        this.textBox100.Height = 0.1875F;
        this.textBox100.Left = 47.5625F;
        this.textBox100.Name = "textBox100";
        this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
        this.textBox100.Style = "";
        this.textBox100.Text = "Aporte inte. ($us)";
        this.textBox100.Top = 0F;
        this.textBox100.Width = 0.75F;
        // 
        // textBox101
        // 
        this.textBox101.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox101.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox101.Border.RightColor = System.Drawing.Color.Black;
        this.textBox101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox101.Border.TopColor = System.Drawing.Color.Black;
        this.textBox101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox101.DataField = "total_amortizacion";
        this.textBox101.Height = 0.1875F;
        this.textBox101.Left = 48.3125F;
        this.textBox101.Name = "textBox101";
        this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
        this.textBox101.Style = "";
        this.textBox101.Text = "Aporte amortiz.";
        this.textBox101.Top = 0F;
        this.textBox101.Width = 0.75F;
        // 
        // textBox102
        // 
        this.textBox102.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox102.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox102.Border.RightColor = System.Drawing.Color.Black;
        this.textBox102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox102.Border.TopColor = System.Drawing.Color.Black;
        this.textBox102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox102.DataField = "saldo";
        this.textBox102.Height = 0.1875F;
        this.textBox102.Left = 49.0625F;
        this.textBox102.Name = "textBox102";
        this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
        this.textBox102.Style = "";
        this.textBox102.Text = "Saldo ($us)";
        this.textBox102.Top = 0F;
        this.textBox102.Width = 0.75F;
        // 
        // textBox79
        // 
        this.textBox79.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox79.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox79.Border.RightColor = System.Drawing.Color.Black;
        this.textBox79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox79.Border.TopColor = System.Drawing.Color.Black;
        this.textBox79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox79.DataField = "oficina_direccion";
        this.textBox79.Height = 0.1875F;
        this.textBox79.Left = 28.6875F;
        this.textBox79.Name = "textBox79";
        this.textBox79.Style = "white-space: inherit; ";
        this.textBox79.Text = "Dirección (Oficina)";
        this.textBox79.Top = 0F;
        this.textBox79.Width = 4F;
        // 
        // textBox111
        // 
        this.textBox111.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox111.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox111.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox111.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox111.Border.RightColor = System.Drawing.Color.Black;
        this.textBox111.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox111.Border.TopColor = System.Drawing.Color.Black;
        this.textBox111.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox111.DataField = "negocio";
        this.textBox111.Height = 0.1875F;
        this.textBox111.Left = 7.625F;
        this.textBox111.Name = "textBox111";
        this.textBox111.Style = "";
        this.textBox111.Text = "textBox111";
        this.textBox111.Top = 0F;
        this.textBox111.Width = 0.9375F;
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
            this.picture1,
            this.textBox14,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox5,
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
            this.textBox57,
            this.textBox110,
            this.textBox112,
            this.textBox113,
            this.textBox114,
            this.textBox115,
            this.textBox116,
            this.textBox117,
            this.textBox118,
            this.textBox119,
            this.textBox121,
            this.textBox123,
            this.textBox124,
            this.textBox125,
            this.textBox126});
        this.reportHeader1.Height = 2.21875F;
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
        this.textBox1.Left = 45.0625F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "textBox1";
        this.textBox1.Top = 0.0625F;
        this.textBox1.Width = 4.75F;
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
        this.textBox2.Left = 21.5F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Reporte de cartera vigente";
        this.textBox2.Top = 0.0625F;
        this.textBox2.Width = 4.5F;
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
        this.textBox3.Left = 19.625F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "A la fecha:";
        this.textBox3.Top = 0.3125F;
        this.textBox3.Width = 1.875F;
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
        this.textBox4.Left = 21.5F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "textBox4";
        this.textBox4.Top = 0.3125F;
        this.textBox4.Width = 4.5F;
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
        this.picture1.Height = 0.375F;
        this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.Left = 0.0625F;
        this.picture1.LineWeight = 0F;
        this.picture1.Name = "picture1";
        this.picture1.Top = 0.0625F;
        this.picture1.Width = 2.1875F;
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
        this.textBox14.Height = 0.3125F;
        this.textBox14.Left = 1F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Director del grupo";
        this.textBox14.Top = 1.875F;
        this.textBox14.Width = 2.25F;
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
        this.textBox6.Left = 8.625F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "DATOS DEL LOTE";
        this.textBox6.Top = 1.6875F;
        this.textBox6.Width = 3F;
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
        this.textBox7.Left = 11.625F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = "DATOS DEL CLIENTE";
        this.textBox7.Top = 1.6875F;
        this.textBox7.Width = 23.6875F;
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
        this.textBox8.Height = 0.1875F;
        this.textBox8.Left = 35.3125F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "DATOS DE LA VENTA";
        this.textBox8.Top = 1.6875F;
        this.textBox8.Width = 3.8125F;
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
        this.textBox9.Left = 39.125F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "PLAN DE PAGOS VIGENTE";
        this.textBox9.Top = 1.6875F;
        this.textBox9.Width = 2.6875F;
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
        this.textBox10.Left = 41.8125F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "DATOS DEL ÚLTIMO PAGO";
        this.textBox10.Top = 1.6875F;
        this.textBox10.Width = 2.25F;
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
        this.textBox11.Left = 44.0625F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "DATOS DE MORA";
        this.textBox11.Top = 1.6875F;
        this.textBox11.Width = 2F;
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
        this.textBox12.Left = 46.0625F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "DATOS DEL APORTE";
        this.textBox12.Top = 1.6875F;
        this.textBox12.Width = 3.75F;
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
        this.textBox13.Height = 0.3125F;
        this.textBox13.Left = 0.0625F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "Grupo de Ventas";
        this.textBox13.Top = 1.875F;
        this.textBox13.Width = 0.9375F;
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
        this.textBox5.Left = 0.0625F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "DATOS DE VENTAS";
        this.textBox5.Top = 1.6875F;
        this.textBox5.Width = 5.4375F;
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
        this.textBox15.Height = 0.3125F;
        this.textBox15.Left = 3.25F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = "Promotor";
        this.textBox15.Top = 1.875F;
        this.textBox15.Width = 2.25F;
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
        this.textBox16.Height = 0.3125F;
        this.textBox16.Left = 5.5F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Nº contrato";
        this.textBox16.Top = 1.875F;
        this.textBox16.Width = 0.8125F;
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
        this.textBox17.Height = 0.3125F;
        this.textBox17.Left = 6.875F;
        this.textBox17.Name = "textBox17";
        this.textBox17.Style = "";
        this.textBox17.Text = "F.registro";
        this.textBox17.Top = 1.875F;
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
        this.textBox18.Height = 0.3125F;
        this.textBox18.Left = 8.625F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "Loc.";
        this.textBox18.Top = 1.875F;
        this.textBox18.Width = 0.5F;
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
        this.textBox19.Height = 0.3125F;
        this.textBox19.Left = 9.1875F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "Sector";
        this.textBox19.Top = 1.875F;
        this.textBox19.Width = 1.4375F;
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
        this.textBox20.Height = 0.3125F;
        this.textBox20.Left = 10.625F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "Mzno.";
        this.textBox20.Top = 1.875F;
        this.textBox20.Width = 0.5F;
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
        this.textBox21.Height = 0.3125F;
        this.textBox21.Left = 11.125F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "Lote";
        this.textBox21.Top = 1.875F;
        this.textBox21.Width = 0.5F;
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
        this.textBox22.Height = 0.3125F;
        this.textBox22.Left = 11.625F;
        this.textBox22.Name = "textBox22";
        this.textBox22.Style = "";
        this.textBox22.Text = "Apellido Paterno";
        this.textBox22.Top = 1.875F;
        this.textBox22.Width = 1.25F;
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
        this.textBox23.Height = 0.3125F;
        this.textBox23.Left = 12.875F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Apellido Materno";
        this.textBox23.Top = 1.875F;
        this.textBox23.Width = 1.25F;
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
        this.textBox24.Height = 0.3125F;
        this.textBox24.Left = 14.125F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "Nombres";
        this.textBox24.Top = 1.875F;
        this.textBox24.Width = 2F;
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
        this.textBox25.Height = 0.3125F;
        this.textBox25.Left = 16.125F;
        this.textBox25.Name = "textBox25";
        this.textBox25.Style = "";
        this.textBox25.Text = "C.I.";
        this.textBox25.Top = 1.875F;
        this.textBox25.Width = 1F;
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
        this.textBox26.Height = 0.3125F;
        this.textBox26.Left = 17.125F;
        this.textBox26.Name = "textBox26";
        this.textBox26.Style = "";
        this.textBox26.Text = "NIT";
        this.textBox26.Top = 1.875F;
        this.textBox26.Width = 0.875F;
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
        this.textBox27.Height = 0.3125F;
        this.textBox27.Left = 18F;
        this.textBox27.Name = "textBox27";
        this.textBox27.Style = "";
        this.textBox27.Text = "Celular";
        this.textBox27.Top = 1.875F;
        this.textBox27.Width = 0.75F;
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
        this.textBox28.Height = 0.3125F;
        this.textBox28.Left = 18.75F;
        this.textBox28.Name = "textBox28";
        this.textBox28.Style = "";
        this.textBox28.Text = "Fax";
        this.textBox28.Top = 1.875F;
        this.textBox28.Width = 0.75F;
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
        this.textBox29.Height = 0.3125F;
        this.textBox29.Left = 19.625F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "";
        this.textBox29.Text = "Email";
        this.textBox29.Top = 1.875F;
        this.textBox29.Width = 1.875F;
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
        this.textBox30.Height = 0.3125F;
        this.textBox30.Left = 21.5F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "Casilla";
        this.textBox30.Top = 1.875F;
        this.textBox30.Width = 0.5F;
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
        this.textBox31.Left = 22F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "Dirección (Domicilio)";
        this.textBox31.Top = 1.875F;
        this.textBox31.Width = 4F;
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
        this.textBox32.Height = 0.3125F;
        this.textBox32.Left = 26F;
        this.textBox32.Name = "textBox32";
        this.textBox32.Style = "";
        this.textBox32.Text = "Fono (Domic.)";
        this.textBox32.Top = 1.875F;
        this.textBox32.Width = 0.625F;
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
        this.textBox33.Height = 0.3125F;
        this.textBox33.Left = 26.625F;
        this.textBox33.Name = "textBox33";
        this.textBox33.Style = "";
        this.textBox33.Text = "Zona (Domicilio)";
        this.textBox33.Top = 1.875F;
        this.textBox33.Width = 2.0625F;
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
        this.textBox34.Height = 0.3125F;
        this.textBox34.Left = 28.6875F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "Dirección (Oficina)";
        this.textBox34.Top = 1.875F;
        this.textBox34.Width = 4F;
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
        this.textBox35.Height = 0.3125F;
        this.textBox35.Left = 32.6875F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "Fono (Ofi.)";
        this.textBox35.Top = 1.875F;
        this.textBox35.Width = 0.625F;
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
        this.textBox36.Height = 0.3125F;
        this.textBox36.Left = 33.3125F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Zona (Oficina)";
        this.textBox36.Top = 1.875F;
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
        this.textBox37.Height = 0.3125F;
        this.textBox37.Left = 35.3125F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "Valor Original";
        this.textBox37.Top = 1.875F;
        this.textBox37.Width = 0.75F;
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
        this.textBox38.Height = 0.3125F;
        this.textBox38.Left = 36.0625F;
        this.textBox38.Name = "textBox38";
        this.textBox38.Style = "";
        this.textBox38.Text = "Desc.(%)";
        this.textBox38.Top = 1.875F;
        this.textBox38.Width = 0.625F;
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
        this.textBox39.Height = 0.3125F;
        this.textBox39.Left = 36.6875F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "Desc.($us)";
        this.textBox39.Top = 1.875F;
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
        this.textBox40.Height = 0.3125F;
        this.textBox40.Left = 37.375F;
        this.textBox40.Name = "textBox40";
        this.textBox40.Style = "";
        this.textBox40.Text = "Valor final";
        this.textBox40.Top = 1.875F;
        this.textBox40.Width = 0.875F;
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
        this.textBox41.Height = 0.3125F;
        this.textBox41.Left = 38.25F;
        this.textBox41.Name = "textBox41";
        this.textBox41.Style = "";
        this.textBox41.Text = "Cuota Inicial";
        this.textBox41.Top = 1.875F;
        this.textBox41.Width = 0.875F;
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
        this.textBox42.Height = 0.3125F;
        this.textBox42.Left = 39.125F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "Interés";
        this.textBox42.Top = 1.875F;
        this.textBox42.Width = 0.625F;
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
        this.textBox43.Height = 0.3125F;
        this.textBox43.Left = 39.75F;
        this.textBox43.Name = "textBox43";
        this.textBox43.Style = "";
        this.textBox43.Text = "Nº cuo";
        this.textBox43.Top = 1.875F;
        this.textBox43.Width = 0.4375F;
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
        this.textBox44.Height = 0.3125F;
        this.textBox44.Left = 40.1875F;
        this.textBox44.Name = "textBox44";
        this.textBox44.Style = "";
        this.textBox44.Text = "Cuota mensual";
        this.textBox44.Top = 1.875F;
        this.textBox44.Width = 0.875F;
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
        this.textBox45.Height = 0.3125F;
        this.textBox45.Left = 41.0625F;
        this.textBox45.Name = "textBox45";
        this.textBox45.Style = "";
        this.textBox45.Text = "F.Ini.Plan";
        this.textBox45.Top = 1.875F;
        this.textBox45.Width = 0.75F;
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
        this.textBox46.Height = 0.3125F;
        this.textBox46.Left = 41.8125F;
        this.textBox46.Name = "textBox46";
        this.textBox46.Style = "";
        this.textBox46.Text = "F.Ult.pago";
        this.textBox46.Top = 1.875F;
        this.textBox46.Width = 0.75F;
        // 
        // textBox47
        // 
        this.textBox47.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Border.RightColor = System.Drawing.Color.Black;
        this.textBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Border.TopColor = System.Drawing.Color.Black;
        this.textBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox47.Height = 0.3125F;
        this.textBox47.Left = 42.5625F;
        this.textBox47.Name = "textBox47";
        this.textBox47.Style = "";
        this.textBox47.Text = "F. Interés";
        this.textBox47.Top = 1.875F;
        this.textBox47.Width = 0.75F;
        // 
        // textBox48
        // 
        this.textBox48.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Border.RightColor = System.Drawing.Color.Black;
        this.textBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Border.TopColor = System.Drawing.Color.Black;
        this.textBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox48.Height = 0.3125F;
        this.textBox48.Left = 43.3125F;
        this.textBox48.Name = "textBox48";
        this.textBox48.Style = "";
        this.textBox48.Text = "F.Prox.Pago";
        this.textBox48.Top = 1.875F;
        this.textBox48.Width = 0.75F;
        // 
        // textBox49
        // 
        this.textBox49.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Border.RightColor = System.Drawing.Color.Black;
        this.textBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Border.TopColor = System.Drawing.Color.Black;
        this.textBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox49.Height = 0.3125F;
        this.textBox49.Left = 44.0625F;
        this.textBox49.Name = "textBox49";
        this.textBox49.Style = "";
        this.textBox49.Text = "Nº días retraso";
        this.textBox49.Top = 1.875F;
        this.textBox49.Width = 0.5F;
        // 
        // textBox50
        // 
        this.textBox50.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Border.RightColor = System.Drawing.Color.Black;
        this.textBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Border.TopColor = System.Drawing.Color.Black;
        this.textBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox50.Height = 0.3125F;
        this.textBox50.Left = 44.5625F;
        this.textBox50.Name = "textBox50";
        this.textBox50.Style = "";
        this.textBox50.Text = "Nº cuo. adeuda";
        this.textBox50.Top = 1.875F;
        this.textBox50.Width = 0.5F;
        // 
        // textBox51
        // 
        this.textBox51.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Border.RightColor = System.Drawing.Color.Black;
        this.textBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Border.TopColor = System.Drawing.Color.Black;
        this.textBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox51.Height = 0.3125F;
        this.textBox51.Left = 45.0625F;
        this.textBox51.Name = "textBox51";
        this.textBox51.Style = "";
        this.textBox51.Text = "Nº días mora";
        this.textBox51.Top = 1.875F;
        this.textBox51.Width = 0.5F;
        // 
        // textBox52
        // 
        this.textBox52.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Border.RightColor = System.Drawing.Color.Black;
        this.textBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Border.TopColor = System.Drawing.Color.Black;
        this.textBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox52.Height = 0.3125F;
        this.textBox52.Left = 45.5625F;
        this.textBox52.Name = "textBox52";
        this.textBox52.Style = "";
        this.textBox52.Text = "Nº cuo. mora";
        this.textBox52.Top = 1.875F;
        this.textBox52.Width = 0.5F;
        // 
        // textBox53
        // 
        this.textBox53.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Border.RightColor = System.Drawing.Color.Black;
        this.textBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Border.TopColor = System.Drawing.Color.Black;
        this.textBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox53.Height = 0.3125F;
        this.textBox53.Left = 46.0625F;
        this.textBox53.Name = "textBox53";
        this.textBox53.Style = "";
        this.textBox53.Text = "Valor final lote ($us)";
        this.textBox53.Top = 1.875F;
        this.textBox53.Width = 0.75F;
        // 
        // textBox54
        // 
        this.textBox54.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Border.RightColor = System.Drawing.Color.Black;
        this.textBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Border.TopColor = System.Drawing.Color.Black;
        this.textBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox54.Height = 0.3125F;
        this.textBox54.Left = 46.8125F;
        this.textBox54.Name = "textBox54";
        this.textBox54.Style = "";
        this.textBox54.Text = "Total aportado";
        this.textBox54.Top = 1.875F;
        this.textBox54.Width = 0.75F;
        // 
        // textBox55
        // 
        this.textBox55.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Border.RightColor = System.Drawing.Color.Black;
        this.textBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Border.TopColor = System.Drawing.Color.Black;
        this.textBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox55.Height = 0.3125F;
        this.textBox55.Left = 47.5625F;
        this.textBox55.Name = "textBox55";
        this.textBox55.Style = "";
        this.textBox55.Text = "Aporte inte. ($us)";
        this.textBox55.Top = 1.875F;
        this.textBox55.Width = 0.75F;
        // 
        // textBox56
        // 
        this.textBox56.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Border.RightColor = System.Drawing.Color.Black;
        this.textBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Border.TopColor = System.Drawing.Color.Black;
        this.textBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox56.Height = 0.3125F;
        this.textBox56.Left = 48.3125F;
        this.textBox56.Name = "textBox56";
        this.textBox56.Style = "";
        this.textBox56.Text = "Aporte amortiz.";
        this.textBox56.Top = 1.875F;
        this.textBox56.Width = 0.75F;
        // 
        // textBox57
        // 
        this.textBox57.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Border.RightColor = System.Drawing.Color.Black;
        this.textBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Border.TopColor = System.Drawing.Color.Black;
        this.textBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox57.Height = 0.3125F;
        this.textBox57.Left = 49.0625F;
        this.textBox57.Name = "textBox57";
        this.textBox57.Style = "";
        this.textBox57.Text = "Saldo ($us)";
        this.textBox57.Top = 1.875F;
        this.textBox57.Width = 0.75F;
        // 
        // textBox110
        // 
        this.textBox110.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox110.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox110.Border.RightColor = System.Drawing.Color.Black;
        this.textBox110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox110.Border.TopColor = System.Drawing.Color.Black;
        this.textBox110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox110.Height = 0.3125F;
        this.textBox110.Left = 7.625F;
        this.textBox110.Name = "textBox110";
        this.textBox110.Style = "";
        this.textBox110.Text = "Negocio";
        this.textBox110.Top = 1.875F;
        this.textBox110.Width = 0.9375F;
        // 
        // textBox112
        // 
        this.textBox112.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox112.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox112.Border.RightColor = System.Drawing.Color.Black;
        this.textBox112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox112.Border.TopColor = System.Drawing.Color.Black;
        this.textBox112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox112.Height = 0.1875F;
        this.textBox112.Left = 19.625F;
        this.textBox112.Name = "textBox112";
        this.textBox112.Style = "";
        this.textBox112.Text = "Negocio:";
        this.textBox112.Top = 0.5F;
        this.textBox112.Width = 1.875F;
        // 
        // textBox113
        // 
        this.textBox113.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox113.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox113.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox113.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox113.Border.RightColor = System.Drawing.Color.Black;
        this.textBox113.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox113.Border.TopColor = System.Drawing.Color.Black;
        this.textBox113.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox113.Height = 0.1875F;
        this.textBox113.Left = 21.5F;
        this.textBox113.Name = "textBox113";
        this.textBox113.Style = "";
        this.textBox113.Text = "textBox113";
        this.textBox113.Top = 0.5F;
        this.textBox113.Width = 4.5F;
        // 
        // textBox114
        // 
        this.textBox114.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox114.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox114.Border.RightColor = System.Drawing.Color.Black;
        this.textBox114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox114.Border.TopColor = System.Drawing.Color.Black;
        this.textBox114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox114.Height = 0.1875F;
        this.textBox114.Left = 19.625F;
        this.textBox114.Name = "textBox114";
        this.textBox114.Style = "";
        this.textBox114.Text = "Localización:";
        this.textBox114.Top = 0.6875F;
        this.textBox114.Width = 1.875F;
        // 
        // textBox115
        // 
        this.textBox115.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox115.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox115.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox115.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox115.Border.RightColor = System.Drawing.Color.Black;
        this.textBox115.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox115.Border.TopColor = System.Drawing.Color.Black;
        this.textBox115.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox115.Height = 0.1875F;
        this.textBox115.Left = 21.5F;
        this.textBox115.Name = "textBox115";
        this.textBox115.Style = "";
        this.textBox115.Text = "textBox115";
        this.textBox115.Top = 0.6875F;
        this.textBox115.Width = 4.5F;
        // 
        // textBox116
        // 
        this.textBox116.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox116.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox116.Border.RightColor = System.Drawing.Color.Black;
        this.textBox116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox116.Border.TopColor = System.Drawing.Color.Black;
        this.textBox116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox116.Height = 0.1875F;
        this.textBox116.Left = 19.625F;
        this.textBox116.Name = "textBox116";
        this.textBox116.Style = "";
        this.textBox116.Text = "Sector:";
        this.textBox116.Top = 0.875F;
        this.textBox116.Width = 1.875F;
        // 
        // textBox117
        // 
        this.textBox117.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox117.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox117.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox117.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox117.Border.RightColor = System.Drawing.Color.Black;
        this.textBox117.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox117.Border.TopColor = System.Drawing.Color.Black;
        this.textBox117.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox117.Height = 0.1875F;
        this.textBox117.Left = 21.5F;
        this.textBox117.Name = "textBox117";
        this.textBox117.Style = "";
        this.textBox117.Text = "textBox117";
        this.textBox117.Top = 0.875F;
        this.textBox117.Width = 4.5F;
        // 
        // textBox118
        // 
        this.textBox118.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox118.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox118.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox118.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox118.Border.RightColor = System.Drawing.Color.Black;
        this.textBox118.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox118.Border.TopColor = System.Drawing.Color.Black;
        this.textBox118.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox118.Height = 0.1875F;
        this.textBox118.Left = 19.625F;
        this.textBox118.Name = "textBox118";
        this.textBox118.Style = "";
        this.textBox118.Text = "Manzano:";
        this.textBox118.Top = 1.0625F;
        this.textBox118.Width = 1.875F;
        // 
        // textBox119
        // 
        this.textBox119.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox119.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox119.Border.RightColor = System.Drawing.Color.Black;
        this.textBox119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox119.Border.TopColor = System.Drawing.Color.Black;
        this.textBox119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox119.Height = 0.1875F;
        this.textBox119.Left = 21.5F;
        this.textBox119.Name = "textBox119";
        this.textBox119.Style = "";
        this.textBox119.Text = "textBox119";
        this.textBox119.Top = 1.0625F;
        this.textBox119.Width = 4.5F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line1,
            this.textBox106,
            this.textBox107,
            this.textBox108,
            this.textBox109,
            this.textBox103,
            this.textBox104,
            this.textBox105,
            this.textBox120});
        this.reportFooter1.Height = 0.3645833F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.line1.Left = 0.0625F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.0625F;
        this.line1.Width = 49.75F;
        this.line1.X1 = 0.0625F;
        this.line1.X2 = 49.8125F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
        // 
        // textBox106
        // 
        this.textBox106.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox106.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox106.Border.RightColor = System.Drawing.Color.Black;
        this.textBox106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox106.Border.TopColor = System.Drawing.Color.Black;
        this.textBox106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox106.DataField = "valor_final_terreno";
        this.textBox106.Height = 0.1875F;
        this.textBox106.Left = 46.0625F;
        this.textBox106.Name = "textBox106";
        this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
        this.textBox106.Style = "";
        this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox106.Text = "textBox106";
        this.textBox106.Top = 0.125F;
        this.textBox106.Width = 0.75F;
        // 
        // textBox107
        // 
        this.textBox107.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox107.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox107.Border.RightColor = System.Drawing.Color.Black;
        this.textBox107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox107.Border.TopColor = System.Drawing.Color.Black;
        this.textBox107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox107.DataField = "total_pago";
        this.textBox107.Height = 0.1875F;
        this.textBox107.Left = 46.8125F;
        this.textBox107.Name = "textBox107";
        this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
        this.textBox107.Style = "";
        this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox107.Text = "textBox107";
        this.textBox107.Top = 0.125F;
        this.textBox107.Width = 0.75F;
        // 
        // textBox108
        // 
        this.textBox108.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox108.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox108.Border.RightColor = System.Drawing.Color.Black;
        this.textBox108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox108.Border.TopColor = System.Drawing.Color.Black;
        this.textBox108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox108.DataField = "total_interes";
        this.textBox108.Height = 0.1875F;
        this.textBox108.Left = 47.5625F;
        this.textBox108.Name = "textBox108";
        this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
        this.textBox108.Style = "";
        this.textBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox108.Text = "textBox108";
        this.textBox108.Top = 0.125F;
        this.textBox108.Width = 0.75F;
        // 
        // textBox109
        // 
        this.textBox109.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox109.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox109.Border.RightColor = System.Drawing.Color.Black;
        this.textBox109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox109.Border.TopColor = System.Drawing.Color.Black;
        this.textBox109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox109.DataField = "total_amortizacion";
        this.textBox109.Height = 0.1875F;
        this.textBox109.Left = 48.3125F;
        this.textBox109.Name = "textBox109";
        this.textBox109.OutputFormat = resources.GetString("textBox109.OutputFormat");
        this.textBox109.Style = "";
        this.textBox109.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox109.Text = "textBox109";
        this.textBox109.Top = 0.125F;
        this.textBox109.Width = 0.75F;
        // 
        // textBox103
        // 
        this.textBox103.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox103.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox103.Border.RightColor = System.Drawing.Color.Black;
        this.textBox103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox103.Border.TopColor = System.Drawing.Color.Black;
        this.textBox103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox103.DataField = "precio";
        this.textBox103.Height = 0.1875F;
        this.textBox103.Left = 35.3125F;
        this.textBox103.Name = "textBox103";
        this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
        this.textBox103.Style = "";
        this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox103.Text = "textBox103";
        this.textBox103.Top = 0.125F;
        this.textBox103.Width = 0.75F;
        // 
        // textBox104
        // 
        this.textBox104.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox104.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox104.Border.RightColor = System.Drawing.Color.Black;
        this.textBox104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox104.Border.TopColor = System.Drawing.Color.Black;
        this.textBox104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox104.DataField = "precio_final";
        this.textBox104.Height = 0.1875F;
        this.textBox104.Left = 37.375F;
        this.textBox104.Name = "textBox104";
        this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
        this.textBox104.Style = "";
        this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox104.Text = "textBox104";
        this.textBox104.Top = 0.125F;
        this.textBox104.Width = 0.875F;
        // 
        // textBox105
        // 
        this.textBox105.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox105.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox105.Border.RightColor = System.Drawing.Color.Black;
        this.textBox105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox105.Border.TopColor = System.Drawing.Color.Black;
        this.textBox105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox105.DataField = "cuota_inicial";
        this.textBox105.Height = 0.1875F;
        this.textBox105.Left = 38.25F;
        this.textBox105.Name = "textBox105";
        this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
        this.textBox105.Style = "";
        this.textBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox105.Text = "textBox105";
        this.textBox105.Top = 0.125F;
        this.textBox105.Width = 0.875F;
        // 
        // textBox120
        // 
        this.textBox120.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox120.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox120.Border.RightColor = System.Drawing.Color.Black;
        this.textBox120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox120.Border.TopColor = System.Drawing.Color.Black;
        this.textBox120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox120.DataField = "saldo";
        this.textBox120.Height = 0.1875F;
        this.textBox120.Left = 49.0625F;
        this.textBox120.Name = "textBox120";
        this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
        this.textBox120.Style = "";
        this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox120.Text = "textBox120";
        this.textBox120.Top = 0.125F;
        this.textBox120.Width = 0.75F;
        // 
        // textBox121
        // 
        this.textBox121.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Border.RightColor = System.Drawing.Color.Black;
        this.textBox121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Border.TopColor = System.Drawing.Color.Black;
        this.textBox121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox121.Height = 0.3125F;
        this.textBox121.Left = 6.3125F;
        this.textBox121.Name = "textBox121";
        this.textBox121.Style = "";
        this.textBox121.Text = "Moneda";
        this.textBox121.Top = 1.875F;
        this.textBox121.Width = 0.5625F;
        // 
        // textBox122
        // 
        this.textBox122.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox122.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox122.Border.RightColor = System.Drawing.Color.Black;
        this.textBox122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox122.Border.TopColor = System.Drawing.Color.Black;
        this.textBox122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox122.DataField = "codigo_moneda";
        this.textBox122.Height = 0.1875F;
        this.textBox122.Left = 6.3125F;
        this.textBox122.Name = "textBox122";
        this.textBox122.Style = "";
        this.textBox122.Text = "textBox122";
        this.textBox122.Top = 0F;
        this.textBox122.Width = 0.5F;
        // 
        // textBox123
        // 
        this.textBox123.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox123.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox123.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox123.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox123.Border.RightColor = System.Drawing.Color.Black;
        this.textBox123.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox123.Border.TopColor = System.Drawing.Color.Black;
        this.textBox123.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox123.Height = 0.1875F;
        this.textBox123.Left = 19.625F;
        this.textBox123.Name = "textBox123";
        this.textBox123.Style = "";
        this.textBox123.Text = "MONEDA:";
        this.textBox123.Top = 1.25F;
        this.textBox123.Width = 1.875F;
        // 
        // textBox124
        // 
        this.textBox124.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox124.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox124.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox124.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox124.Border.RightColor = System.Drawing.Color.Black;
        this.textBox124.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox124.Border.TopColor = System.Drawing.Color.Black;
        this.textBox124.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox124.Height = 0.1875F;
        this.textBox124.Left = 21.5F;
        this.textBox124.Name = "textBox124";
        this.textBox124.Style = "";
        this.textBox124.Text = "textBox124";
        this.textBox124.Top = 1.25F;
        this.textBox124.Width = 4.5F;
        // 
        // textBox125
        // 
        this.textBox125.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox125.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox125.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox125.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox125.Border.RightColor = System.Drawing.Color.Black;
        this.textBox125.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox125.Border.TopColor = System.Drawing.Color.Black;
        this.textBox125.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox125.Height = 0.1875F;
        this.textBox125.Left = 19.625F;
        this.textBox125.Name = "textBox125";
        this.textBox125.Style = "";
        this.textBox125.Text = "DATOS:";
        this.textBox125.Top = 1.4375F;
        this.textBox125.Width = 1.875F;
        // 
        // textBox126
        // 
        this.textBox126.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox126.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox126.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox126.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox126.Border.RightColor = System.Drawing.Color.Black;
        this.textBox126.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox126.Border.TopColor = System.Drawing.Color.Black;
        this.textBox126.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox126.Height = 0.1875F;
        this.textBox126.Left = 21.5F;
        this.textBox126.Name = "textBox126";
        this.textBox126.Style = "";
        this.textBox126.Text = "textBox126";
        this.textBox126.Top = 1.4375F;
        this.textBox126.Width = 4.5F;
        // 
        // rpt_cartera_vigente
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 49.90625F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black; ", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic; ", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rpt_cartera_vigente_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox80)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox81)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox82)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox83)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox84)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox85)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox86)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox87)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox90)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox92)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox93)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox94)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox95)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion
}
