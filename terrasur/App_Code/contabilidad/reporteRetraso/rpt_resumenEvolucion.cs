using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_resumenEvolucion.
/// </summary>
public class rpt_resumenEvolucion : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Shape shape1;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox5;
    private TextBox textBox10;
    private TextBox textBox11;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox8;
    private TextBox textBox9;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox textBox17;
    private TextBox textBox26;
    private TextBox textBox22;
    private TextBox textBox27;
    private TextBox textBox28;
    private TextBox textBox30;
    private TextBox textBox32;
    private TextBox textBox33;
    private TextBox textBox29;
    private Picture picture1;
    private TextBox textBox14;
    private TextBox textBox15;
    private TextBox textBox16;
    private TextBox textBox18;
    private TextBox textBox19;
    private TextBox textBox20;
    private TextBox textBox21;
    private TextBox textBox23;
    private TextBox textBox36;
    private TextBox textBox37;
    private TextBox textBox31;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private TextBox textBox34;
    private TextBox textBox35;
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
    private Line line2;
    private Line line3;
    private Line line15;
    private Line line16;
    private Line line17;
    private Line line18;
    private Line line19;
    private Line line20;
    private Line line21;
    private Line line22;
    private Line line23;
    private Line line24;
    private Line line25;
    private Line line26;
    private Line line27;
    private Line line14;
    private Line line28;
    private Line line29;
    private Line line30;
    private Line line40;
    private Line line41;
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
    private Line line4;
    private Line line5;
    private Line line6;
    private Line line7;
    private Line line8;
    private Line line9;
    private Line line10;
    private Line line11;
    private Line line12;
    private Line line13;
    private Line line42;
    private Line line43;
    private TextBox textBox105;
    private TextBox textBox106;
    private TextBox textBox107;
    private TextBox textBox108;
    private TextBox textBox109;
    private TextBox textBox110;
    private TextBox textBox111;
    private TextBox textBox112;
    private TextBox textBox113;
    private TextBox textBox114;
    private TextBox textBox115;
    private TextBox textBox116;
    private TextBox textBox117;
    private TextBox textBox118;
    private TextBox textBox119;
    private TextBox textBox120;
    private TextBox textBox121;
    private TextBox textBox122;
    private TextBox textBox123;
    private TextBox textBox124;
    private TextBox textBox125;
    private TextBox textBox126;
    private TextBox textBox127;
    private TextBox textBox128;
    private TextBox textBox129;
    private TextBox textBox130;
    private TextBox textBox131;
    private TextBox textBox132;
    private TextBox textBox133;
    private TextBox textBox134;
    private TextBox textBox135;
    private TextBox textBox136;
    private TextBox textBox137;
    private TextBox textBox138;
    private TextBox textBox139;
    private TextBox textBox140;
    private TextBox textBox141;
    private TextBox textBox142;
    private TextBox textBox143;
    private TextBox textBox144;
    private Line line44;
    private Line line45;
    private Line line46;
    private Line line47;
    private Line line48;
    private Line line49;
    private Line line50;
    private Line line52;
    private Line line53;
    private Line line51;
    private Line line31;
    private Line line32;
    private Line line1;
    private Shape shape2;
    private Shape shape3;
    private Shape shape4;
    private Shape shape5;
    private Shape shape6;
    private Shape shape7;
    private Shape shape8;
    private Shape shape9;
    private Shape shape10;
    private Shape shape11;
    private Shape shape12;
    private Shape shape13;
    private Shape shape14;
    private Shape shape15;
    private Shape shape16;
    private Shape shape17;
    private Shape shape18;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_resumenEvolucion()
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

    public void CargarEncabezado(string Usuario, DateTime Fecha, DateTime Fecha2, string Negocios, string Moneda, string Consolidado, string Codigo_moneda)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox31.Text = "Usuario: " + Usuario;

        textBox6.Text = Fecha.ToString("d") + " - " + Fecha2.ToString("d");
        textBox7.Text = Negocios;
        textBox19.Text = Moneda;
        textBox21.Text = Consolidado;
    }


    private void rpt_resumenEvolucion_ReportStart(object sender, EventArgs e)
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
    }

    public void CargarEstilos()
    {
        textBox1.ClassName = "estiloFecha";
        textBox31.ClassName = "estiloFecha";

        textBox2.ClassName = "estiloTitulo";

        textBox3.ClassName = "estiloEncabEnun";
        textBox6.ClassName = "estiloEncabDato";
        textBox4.ClassName = "estiloEncabEnun";
        textBox7.ClassName = "estiloEncabDato";

        textBox18.ClassName = "estiloEncabEnun";
        textBox19.ClassName = "estiloEncabDato";
        textBox20.ClassName = "estiloEncabEnun";
        textBox21.ClassName = "estiloEncabDato";

        textBox5.ClassName = "estiloDetalleGrupo";
        textBox10.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox11.ClassName = "estiloDetalleEnun";
        textBox12.ClassName = "estiloDetalleEnun";
        textBox13.ClassName = "estiloDetalleEnun";
        textBox8.ClassName = "estiloDetalleEnun";
        textBox9.ClassName = "estiloDetalleEnun";
        textBox23.ClassName = "estiloDetalleEnun";
        textBox36.ClassName = "estiloDetalleEnun";
        textBox23.ClassName = "estiloDetalleEnun";

        textBox37.ClassName = "estiloDetalleGrupo";

        textBox24.ClassName = "estiloDetalleDatoString";
        textBox61.ClassName = "estiloDetalleDatoString";
        textBox62.ClassName = "estiloDetalleDatoString";
        textBox63.ClassName = "estiloDetalleDatoString";
        textBox64.ClassName = "estiloDetalleDatoString";
        textBox65.ClassName = "estiloDetalleDatoString";
        textBox75.ClassName = "estiloDetalleDatoString";
        textBox85.ClassName = "estiloDetalleDatoString";
        textBox95.ClassName = "estiloDetalleDatoString";
        textBox105.ClassName = "estiloDetalleDatoString";
        textBox115.ClassName = "estiloDetalleDatoString";
        textBox125.ClassName = "estiloDetalleDatoString";
        textBox135.ClassName = "estiloDetalleDatoString";



        textBox25.ClassName = "estiloDetalleDato";
        textBox15.ClassName = "estiloDetalleDato";
        textBox26.ClassName = "estiloDetalleDato";
        textBox27.ClassName = "estiloDetalleDato";
        textBox17.ClassName = "estiloDetalleDato";
        textBox22.ClassName = "estiloDetalleDato";
        textBox28.ClassName = "estiloDetalleDato";
        textBox34.ClassName = "estiloDetalleDato";
        textBox35.ClassName = "estiloDetalleDato";

        textBox52.ClassName = "estiloDetalleDato";
        textBox53.ClassName = "estiloDetalleDato";
        textBox54.ClassName = "estiloDetalleDato";
        textBox55.ClassName = "estiloDetalleDato";
        textBox56.ClassName = "estiloDetalleDato";
        textBox57.ClassName = "estiloDetalleDato";
        textBox58.ClassName = "estiloDetalleDato";
        textBox59.ClassName = "estiloDetalleDato";
        textBox60.ClassName = "estiloDetalleDato";

        textBox66.ClassName = "estiloDetalleDato";
        textBox67.ClassName = "estiloDetalleDato";
        textBox68.ClassName = "estiloDetalleDato";
        textBox69.ClassName = "estiloDetalleDato";
        textBox70.ClassName = "estiloDetalleDato";
        textBox71.ClassName = "estiloDetalleDato";
        textBox72.ClassName = "estiloDetalleDato";
        textBox73.ClassName = "estiloDetalleDato";
        textBox74.ClassName = "estiloDetalleDato";

        textBox76.ClassName = "estiloDetalleDato";
        textBox77.ClassName = "estiloDetalleDato";
        textBox78.ClassName = "estiloDetalleDato";
        textBox79.ClassName = "estiloDetalleDato";
        textBox80.ClassName = "estiloDetalleDato";
        textBox81.ClassName = "estiloDetalleDato";
        textBox82.ClassName = "estiloDetalleDato";
        textBox83.ClassName = "estiloDetalleDato";
        textBox84.ClassName = "estiloDetalleDato";

        textBox86.ClassName = "estiloDetalleDato";
        textBox87.ClassName = "estiloDetalleDato";
        textBox88.ClassName = "estiloDetalleDato";
        textBox89.ClassName = "estiloDetalleDato";
        textBox90.ClassName = "estiloDetalleDato";
        textBox91.ClassName = "estiloDetalleDato";
        textBox92.ClassName = "estiloDetalleDato";
        textBox93.ClassName = "estiloDetalleDato";
        textBox94.ClassName = "estiloDetalleDato";

        textBox96.ClassName = "estiloDetalleDato";
        textBox97.ClassName = "estiloDetalleDato";
        textBox98.ClassName = "estiloDetalleDato";
        textBox99.ClassName = "estiloDetalleDato";
        textBox100.ClassName = "estiloDetalleDato";
        textBox101.ClassName = "estiloDetalleDato";
        textBox102.ClassName = "estiloDetalleDato";
        textBox103.ClassName = "estiloDetalleDato";
        textBox104.ClassName = "estiloDetalleDato";

        
        textBox30.ClassName = "estiloTotalEnun";
        textBox32.ClassName = "estiloTotal";
        textBox16.ClassName = "estiloTotal";
        textBox33.ClassName = "estiloTotal";
        textBox29.ClassName = "estiloTotal";
        textBox38.ClassName = "estiloTotal";
        textBox39.ClassName = "estiloTotal";
        textBox40.ClassName = "estiloTotal";
        textBox41.ClassName = "estiloTotal";
        textBox42.ClassName = "estiloTotal";

        textBox43.ClassName = "estiloTotal";
        textBox44.ClassName = "estiloTotal";
        textBox45.ClassName = "estiloTotal";
        textBox46.ClassName = "estiloTotal";
        textBox47.ClassName = "estiloTotal";
        textBox48.ClassName = "estiloTotal";
        textBox49.ClassName = "estiloTotal";
        textBox50.ClassName = "estiloTotal";
        textBox51.ClassName = "estiloTotal";


        textBox106.ClassName = "estiloDetalleDato";
        textBox107.ClassName = "estiloDetalleDato";
        textBox108.ClassName = "estiloDetalleDato";
        textBox109.ClassName = "estiloDetalleDato";
        textBox110.ClassName = "estiloDetalleDato";
        textBox111.ClassName = "estiloDetalleDato";
        textBox112.ClassName = "estiloDetalleDato";
        textBox113.ClassName = "estiloDetalleDato";
        textBox114.ClassName = "estiloDetalleDato";
        
        textBox116.ClassName = "estiloDetalleDato";
        textBox117.ClassName = "estiloDetalleDato";
        textBox118.ClassName = "estiloDetalleDato";
        textBox119.ClassName = "estiloDetalleDato";
        textBox120.ClassName = "estiloDetalleDato";
        textBox121.ClassName = "estiloDetalleDato";
        textBox122.ClassName = "estiloDetalleDato";
        textBox123.ClassName = "estiloDetalleDato";
        textBox124.ClassName = "estiloDetalleDato";

        textBox126.ClassName = "estiloDetalleDato";
        textBox127.ClassName = "estiloDetalleDato";
        textBox128.ClassName = "estiloDetalleDato";
        textBox129.ClassName = "estiloDetalleDato";
        textBox130.ClassName = "estiloDetalleDato";
        textBox131.ClassName = "estiloDetalleDato";
        textBox132.ClassName = "estiloDetalleDato";
        textBox133.ClassName = "estiloDetalleDato";
        textBox134.ClassName = "estiloDetalleDato";

        textBox136.ClassName = "estiloDetalleDato";
        textBox137.ClassName = "estiloDetalleDato";
        textBox138.ClassName = "estiloDetalleDato";
        textBox139.ClassName = "estiloDetalleDato";
        textBox140.ClassName = "estiloDetalleDato";
        textBox141.ClassName = "estiloDetalleDato";
        textBox142.ClassName = "estiloDetalleDato";
        textBox143.ClassName = "estiloDetalleDato";
        textBox144.ClassName = "estiloDetalleDato";

    }


	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_resumenEvolucion));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.line15 = new DataDynamics.ActiveReports.Line();
        this.line16 = new DataDynamics.ActiveReports.Line();
        this.line17 = new DataDynamics.ActiveReports.Line();
        this.line18 = new DataDynamics.ActiveReports.Line();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.line20 = new DataDynamics.ActiveReports.Line();
        this.line21 = new DataDynamics.ActiveReports.Line();
        this.line22 = new DataDynamics.ActiveReports.Line();
        this.line23 = new DataDynamics.ActiveReports.Line();
        this.line24 = new DataDynamics.ActiveReports.Line();
        this.line25 = new DataDynamics.ActiveReports.Line();
        this.line26 = new DataDynamics.ActiveReports.Line();
        this.line27 = new DataDynamics.ActiveReports.Line();
        this.line28 = new DataDynamics.ActiveReports.Line();
        this.line32 = new DataDynamics.ActiveReports.Line();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
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
        this.line29 = new DataDynamics.ActiveReports.Line();
        this.line30 = new DataDynamics.ActiveReports.Line();
        this.line40 = new DataDynamics.ActiveReports.Line();
        this.line41 = new DataDynamics.ActiveReports.Line();
        this.textBox63 = new DataDynamics.ActiveReports.TextBox();
        this.textBox64 = new DataDynamics.ActiveReports.TextBox();
        this.textBox105 = new DataDynamics.ActiveReports.TextBox();
        this.textBox106 = new DataDynamics.ActiveReports.TextBox();
        this.textBox107 = new DataDynamics.ActiveReports.TextBox();
        this.textBox108 = new DataDynamics.ActiveReports.TextBox();
        this.textBox109 = new DataDynamics.ActiveReports.TextBox();
        this.textBox110 = new DataDynamics.ActiveReports.TextBox();
        this.textBox111 = new DataDynamics.ActiveReports.TextBox();
        this.textBox112 = new DataDynamics.ActiveReports.TextBox();
        this.textBox113 = new DataDynamics.ActiveReports.TextBox();
        this.textBox114 = new DataDynamics.ActiveReports.TextBox();
        this.textBox115 = new DataDynamics.ActiveReports.TextBox();
        this.textBox116 = new DataDynamics.ActiveReports.TextBox();
        this.textBox117 = new DataDynamics.ActiveReports.TextBox();
        this.textBox118 = new DataDynamics.ActiveReports.TextBox();
        this.textBox119 = new DataDynamics.ActiveReports.TextBox();
        this.textBox120 = new DataDynamics.ActiveReports.TextBox();
        this.textBox121 = new DataDynamics.ActiveReports.TextBox();
        this.textBox122 = new DataDynamics.ActiveReports.TextBox();
        this.textBox123 = new DataDynamics.ActiveReports.TextBox();
        this.textBox124 = new DataDynamics.ActiveReports.TextBox();
        this.textBox125 = new DataDynamics.ActiveReports.TextBox();
        this.textBox126 = new DataDynamics.ActiveReports.TextBox();
        this.textBox127 = new DataDynamics.ActiveReports.TextBox();
        this.textBox128 = new DataDynamics.ActiveReports.TextBox();
        this.textBox129 = new DataDynamics.ActiveReports.TextBox();
        this.textBox130 = new DataDynamics.ActiveReports.TextBox();
        this.textBox131 = new DataDynamics.ActiveReports.TextBox();
        this.textBox132 = new DataDynamics.ActiveReports.TextBox();
        this.textBox133 = new DataDynamics.ActiveReports.TextBox();
        this.textBox134 = new DataDynamics.ActiveReports.TextBox();
        this.textBox135 = new DataDynamics.ActiveReports.TextBox();
        this.textBox136 = new DataDynamics.ActiveReports.TextBox();
        this.textBox137 = new DataDynamics.ActiveReports.TextBox();
        this.textBox138 = new DataDynamics.ActiveReports.TextBox();
        this.textBox139 = new DataDynamics.ActiveReports.TextBox();
        this.textBox140 = new DataDynamics.ActiveReports.TextBox();
        this.textBox141 = new DataDynamics.ActiveReports.TextBox();
        this.textBox142 = new DataDynamics.ActiveReports.TextBox();
        this.textBox143 = new DataDynamics.ActiveReports.TextBox();
        this.textBox144 = new DataDynamics.ActiveReports.TextBox();
        this.line44 = new DataDynamics.ActiveReports.Line();
        this.line45 = new DataDynamics.ActiveReports.Line();
        this.line46 = new DataDynamics.ActiveReports.Line();
        this.line47 = new DataDynamics.ActiveReports.Line();
        this.line48 = new DataDynamics.ActiveReports.Line();
        this.line49 = new DataDynamics.ActiveReports.Line();
        this.line50 = new DataDynamics.ActiveReports.Line();
        this.line51 = new DataDynamics.ActiveReports.Line();
        this.line52 = new DataDynamics.ActiveReports.Line();
        this.line53 = new DataDynamics.ActiveReports.Line();
        this.line31 = new DataDynamics.ActiveReports.Line();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.shape2 = new DataDynamics.ActiveReports.Shape();
        this.shape3 = new DataDynamics.ActiveReports.Shape();
        this.shape4 = new DataDynamics.ActiveReports.Shape();
        this.shape5 = new DataDynamics.ActiveReports.Shape();
        this.shape6 = new DataDynamics.ActiveReports.Shape();
        this.shape7 = new DataDynamics.ActiveReports.Shape();
        this.shape8 = new DataDynamics.ActiveReports.Shape();
        this.shape9 = new DataDynamics.ActiveReports.Shape();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
        this.textBox59 = new DataDynamics.ActiveReports.TextBox();
        this.textBox60 = new DataDynamics.ActiveReports.TextBox();
        this.textBox61 = new DataDynamics.ActiveReports.TextBox();
        this.textBox62 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.line14 = new DataDynamics.ActiveReports.Line();
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
        this.textBox79 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox103 = new DataDynamics.ActiveReports.TextBox();
        this.textBox104 = new DataDynamics.ActiveReports.TextBox();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.line9 = new DataDynamics.ActiveReports.Line();
        this.line10 = new DataDynamics.ActiveReports.Line();
        this.line11 = new DataDynamics.ActiveReports.Line();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.line13 = new DataDynamics.ActiveReports.Line();
        this.line42 = new DataDynamics.ActiveReports.Line();
        this.line43 = new DataDynamics.ActiveReports.Line();
        this.shape10 = new DataDynamics.ActiveReports.Shape();
        this.shape11 = new DataDynamics.ActiveReports.Shape();
        this.shape12 = new DataDynamics.ActiveReports.Shape();
        this.shape13 = new DataDynamics.ActiveReports.Shape();
        this.shape14 = new DataDynamics.ActiveReports.Shape();
        this.shape15 = new DataDynamics.ActiveReports.Shape();
        this.shape16 = new DataDynamics.ActiveReports.Shape();
        this.shape17 = new DataDynamics.ActiveReports.Shape();
        this.shape18 = new DataDynamics.ActiveReports.Shape();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox132)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox133)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox134)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox135)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox136)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox137)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox138)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox139)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox140)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox141)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox142)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox143)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox144)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox5,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox8,
            this.textBox9,
            this.textBox14,
            this.textBox23,
            this.textBox36,
            this.textBox37,
            this.line15,
            this.line16,
            this.line17,
            this.line18,
            this.line19,
            this.line20,
            this.line21,
            this.line22,
            this.line23,
            this.line24,
            this.line25,
            this.line26,
            this.line27,
            this.line28,
            this.line32,
            this.line1});
        this.pageHeader.Height = 0.5729167F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox5.Left = 0F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "Clasificación inicial";
        this.textBox5.Top = 0.375F;
        this.textBox5.Width = 2.4375F;
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
        this.textBox10.Height = 0.3125F;
        this.textBox10.Left = 3.4375F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Contratos al día";
        this.textBox10.Top = 0.1875F;
        this.textBox10.Width = 1F;
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
        this.textBox11.Height = 0.3125F;
        this.textBox11.Left = 5.5625F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Retraso de 31 a 60 días";
        this.textBox11.Top = 0.1875F;
        this.textBox11.Width = 1F;
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
        this.textBox12.Height = 0.3125F;
        this.textBox12.Left = 8.75F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Retraso mayor a 120";
        this.textBox12.Top = 0.1875F;
        this.textBox12.Width = 1F;
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
        this.textBox13.Left = 9.8125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "Cartera especial";
        this.textBox13.Top = 0.1875F;
        this.textBox13.Width = 1F;
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
        this.textBox8.Height = 0.3125F;
        this.textBox8.Left = 6.625F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Retraso de 61 a 90 días";
        this.textBox8.Top = 0.1875F;
        this.textBox8.Width = 1F;
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
        this.textBox9.Height = 0.3125F;
        this.textBox9.Left = 7.6875F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "Retraso de 91 a 120 días";
        this.textBox9.Top = 0.1875F;
        this.textBox9.Width = 1F;
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
        this.textBox14.Left = 4.5F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Retraso de 1 a 30 días";
        this.textBox14.Top = 0.1875F;
        this.textBox14.Width = 1F;
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
        this.textBox23.Left = 10.875F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Revertidos y cancelados";
        this.textBox23.Top = 0.1875F;
        this.textBox23.Width = 1F;
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
        this.textBox36.Left = 11.9375F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Total del rango";
        this.textBox36.Top = 0.1875F;
        this.textBox36.Width = 1F;
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
        this.textBox37.Height = 0.1875F;
        this.textBox37.Left = 3.4375F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "Clasificación final";
        this.textBox37.Top = 0F;
        this.textBox37.Width = 9.5625F;
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
        this.line15.Height = 0.1875F;
        this.line15.Left = 0F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 0.375F;
        this.line15.Width = 0F;
        this.line15.X1 = 0F;
        this.line15.X2 = 0F;
        this.line15.Y1 = 0.5625F;
        this.line15.Y2 = 0.375F;
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
        this.line16.Height = 0.1875F;
        this.line16.Left = 2.4375F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 0.375F;
        this.line16.Width = 0F;
        this.line16.X1 = 2.4375F;
        this.line16.X2 = 2.4375F;
        this.line16.Y1 = 0.5625F;
        this.line16.Y2 = 0.375F;
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
        this.line17.Height = 0.5625F;
        this.line17.Left = 3.4375F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 0F;
        this.line17.Width = 0F;
        this.line17.X1 = 3.4375F;
        this.line17.X2 = 3.4375F;
        this.line17.Y1 = 0.5625F;
        this.line17.Y2 = 0F;
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
        this.line18.Height = 0.375F;
        this.line18.Left = 4.5F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 0.1875F;
        this.line18.Width = 0F;
        this.line18.X1 = 4.5F;
        this.line18.X2 = 4.5F;
        this.line18.Y1 = 0.5625F;
        this.line18.Y2 = 0.1875F;
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
        this.line19.Height = 0.375F;
        this.line19.Left = 5.5625F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 0.1875F;
        this.line19.Width = 0F;
        this.line19.X1 = 5.5625F;
        this.line19.X2 = 5.5625F;
        this.line19.Y1 = 0.5625F;
        this.line19.Y2 = 0.1875F;
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
        this.line20.Height = 0.375F;
        this.line20.Left = 6.625F;
        this.line20.LineWeight = 1F;
        this.line20.Name = "line20";
        this.line20.Top = 0.1875F;
        this.line20.Width = 0F;
        this.line20.X1 = 6.625F;
        this.line20.X2 = 6.625F;
        this.line20.Y1 = 0.5625F;
        this.line20.Y2 = 0.1875F;
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
        this.line21.Height = 0.375F;
        this.line21.Left = 8.75F;
        this.line21.LineWeight = 1F;
        this.line21.Name = "line21";
        this.line21.Top = 0.1875F;
        this.line21.Width = 0F;
        this.line21.X1 = 8.75F;
        this.line21.X2 = 8.75F;
        this.line21.Y1 = 0.5625F;
        this.line21.Y2 = 0.1875F;
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
        this.line22.Height = 0.375F;
        this.line22.Left = 7.6875F;
        this.line22.LineWeight = 1F;
        this.line22.Name = "line22";
        this.line22.Top = 0.1875F;
        this.line22.Width = 0F;
        this.line22.X1 = 7.6875F;
        this.line22.X2 = 7.6875F;
        this.line22.Y1 = 0.5625F;
        this.line22.Y2 = 0.1875F;
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
        this.line23.Height = 0.375F;
        this.line23.Left = 9.8125F;
        this.line23.LineWeight = 1F;
        this.line23.Name = "line23";
        this.line23.Top = 0.1875F;
        this.line23.Width = 0F;
        this.line23.X1 = 9.8125F;
        this.line23.X2 = 9.8125F;
        this.line23.Y1 = 0.5625F;
        this.line23.Y2 = 0.1875F;
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
        this.line24.Height = 0.375F;
        this.line24.Left = 10.875F;
        this.line24.LineWeight = 1F;
        this.line24.Name = "line24";
        this.line24.Top = 0.1875F;
        this.line24.Width = 0F;
        this.line24.X1 = 10.875F;
        this.line24.X2 = 10.875F;
        this.line24.Y1 = 0.5625F;
        this.line24.Y2 = 0.1875F;
        // 
        // line25
        // 
        this.line25.Border.BottomColor = System.Drawing.Color.Black;
        this.line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line25.Border.LeftColor = System.Drawing.Color.Black;
        this.line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line25.Border.RightColor = System.Drawing.Color.Black;
        this.line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line25.Border.TopColor = System.Drawing.Color.Black;
        this.line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line25.Height = 0.375F;
        this.line25.Left = 11.9375F;
        this.line25.LineWeight = 1F;
        this.line25.Name = "line25";
        this.line25.Top = 0.1875F;
        this.line25.Width = 0F;
        this.line25.X1 = 11.9375F;
        this.line25.X2 = 11.9375F;
        this.line25.Y1 = 0.5625F;
        this.line25.Y2 = 0.1875F;
        // 
        // line26
        // 
        this.line26.Border.BottomColor = System.Drawing.Color.Black;
        this.line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line26.Border.LeftColor = System.Drawing.Color.Black;
        this.line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line26.Border.RightColor = System.Drawing.Color.Black;
        this.line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line26.Border.TopColor = System.Drawing.Color.Black;
        this.line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line26.Height = 0.5625F;
        this.line26.Left = 13F;
        this.line26.LineWeight = 1F;
        this.line26.Name = "line26";
        this.line26.Top = 0F;
        this.line26.Width = 0F;
        this.line26.X1 = 13F;
        this.line26.X2 = 13F;
        this.line26.Y1 = 0.5625F;
        this.line26.Y2 = 0F;
        // 
        // line27
        // 
        this.line27.Border.BottomColor = System.Drawing.Color.Black;
        this.line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line27.Border.LeftColor = System.Drawing.Color.Black;
        this.line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line27.Border.RightColor = System.Drawing.Color.Black;
        this.line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line27.Border.TopColor = System.Drawing.Color.Black;
        this.line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line27.Height = 0F;
        this.line27.Left = 3.4375F;
        this.line27.LineWeight = 1F;
        this.line27.Name = "line27";
        this.line27.Top = 0.1875F;
        this.line27.Width = 9.5625F;
        this.line27.X1 = 3.4375F;
        this.line27.X2 = 13F;
        this.line27.Y1 = 0.1875F;
        this.line27.Y2 = 0.1875F;
        // 
        // line28
        // 
        this.line28.Border.BottomColor = System.Drawing.Color.Black;
        this.line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line28.Border.LeftColor = System.Drawing.Color.Black;
        this.line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line28.Border.RightColor = System.Drawing.Color.Black;
        this.line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line28.Border.TopColor = System.Drawing.Color.Black;
        this.line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line28.Height = 0F;
        this.line28.Left = 3.4375F;
        this.line28.LineWeight = 1F;
        this.line28.Name = "line28";
        this.line28.Top = 0F;
        this.line28.Width = 9.5625F;
        this.line28.X1 = 3.4375F;
        this.line28.X2 = 13F;
        this.line28.Y1 = 0F;
        this.line28.Y2 = 0F;
        // 
        // line32
        // 
        this.line32.Border.BottomColor = System.Drawing.Color.Black;
        this.line32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line32.Border.LeftColor = System.Drawing.Color.Black;
        this.line32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line32.Border.RightColor = System.Drawing.Color.Black;
        this.line32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line32.Border.TopColor = System.Drawing.Color.Black;
        this.line32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line32.Height = 0F;
        this.line32.Left = 0F;
        this.line32.LineWeight = 1F;
        this.line32.Name = "line32";
        this.line32.Top = 0.5625F;
        this.line32.Width = 13F;
        this.line32.X1 = 0F;
        this.line32.X2 = 13F;
        this.line32.Y1 = 0.5625F;
        this.line32.Y2 = 0.5625F;
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
        this.line1.Left = 0F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.375F;
        this.line1.Width = 2.4375F;
        this.line1.X1 = 0F;
        this.line1.X2 = 2.4375F;
        this.line1.Y1 = 0.375F;
        this.line1.Y2 = 0.375F;
        // 
        // shape1
        // 
        this.shape1.Border.BottomColor = System.Drawing.Color.Black;
        this.shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Border.LeftColor = System.Drawing.Color.Black;
        this.shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Border.RightColor = System.Drawing.Color.Black;
        this.shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Border.TopColor = System.Drawing.Color.Black;
        this.shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Height = 1.5F;
        this.shape1.Left = 3.4375F;
        this.shape1.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape1.Name = "shape1";
        this.shape1.RoundingRadius = 9.999999F;
        this.shape1.Top = 0F;
        this.shape1.Width = 1.0625F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Height = 0F;
        this.detail.Name = "detail";
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
        this.textBox24.DataField = "ini_rango";
        this.textBox24.Height = 0.1875F;
        this.textBox24.Left = 0.0625F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = null;
        this.textBox24.Top = 0.0625F;
        this.textBox24.Width = 2.3125F;
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
        this.textBox25.DataField = "d0_ini_saldo";
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 3.4375F;
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
        this.textBox25.Style = "";
        this.textBox25.SummaryGroup = "groupHeader1";
        this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox25.Text = "textBox25";
        this.textBox25.Top = 0.0625F;
        this.textBox25.Width = 1F;
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
        this.textBox17.DataField = "d61_ini_saldo";
        this.textBox17.Height = 0.1875F;
        this.textBox17.Left = 6.625F;
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
        this.textBox17.Style = "";
        this.textBox17.SummaryGroup = "groupHeader1";
        this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox17.Text = "textBox17";
        this.textBox17.Top = 0.0625F;
        this.textBox17.Width = 1F;
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
        this.textBox26.DataField = "d31_ini_saldo";
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 5.5625F;
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
        this.textBox26.Style = "";
        this.textBox26.SummaryGroup = "groupHeader1";
        this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox26.Text = "textBox26";
        this.textBox26.Top = 0.0625F;
        this.textBox26.Width = 1F;
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
        this.textBox22.DataField = "d91_ini_saldo";
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 7.6875F;
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
        this.textBox22.Style = "";
        this.textBox22.SummaryGroup = "groupHeader1";
        this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox22.Text = "textBox22";
        this.textBox22.Top = 0.0625F;
        this.textBox22.Width = 1F;
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
        this.textBox27.DataField = "d121_ini_saldo";
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 8.75F;
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
        this.textBox27.Style = "";
        this.textBox27.SummaryGroup = "groupHeader1";
        this.textBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox27.Text = "textBox27";
        this.textBox27.Top = 0.0625F;
        this.textBox27.Width = 1F;
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
        this.textBox28.DataField = "desp_ini_saldo";
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 9.8125F;
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
        this.textBox28.Style = "";
        this.textBox28.SummaryGroup = "groupHeader1";
        this.textBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox28.Text = "textBox28";
        this.textBox28.Top = 0.0625F;
        this.textBox28.Width = 1F;
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
        this.textBox15.DataField = "d1_ini_saldo";
        this.textBox15.Height = 0.1875F;
        this.textBox15.Left = 4.5F;
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
        this.textBox15.Style = "";
        this.textBox15.SummaryGroup = "groupHeader1";
        this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox15.Text = "textBox15";
        this.textBox15.Top = 0.0625F;
        this.textBox15.Width = 1F;
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
            this.textBox6,
            this.textBox7,
            this.picture1,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox31});
        this.reportHeader1.Height = 1.552083F;
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
        this.textBox1.Left = 7.6875F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = null;
        this.textBox1.Top = 0.0625F;
        this.textBox1.Width = 5.25F;
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
        this.textBox2.Left = 2.4375F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Evolución de cartera vigente por rangos de retraso";
        this.textBox2.Top = 0.5F;
        this.textBox2.Width = 8.25F;
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
        this.textBox3.Left = 4.5F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "Periodo:";
        this.textBox3.Top = 0.75F;
        this.textBox3.Width = 1F;
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
        this.textBox4.Left = 4.5F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Negocio:";
        this.textBox4.Top = 0.9375F;
        this.textBox4.Width = 1F;
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
        this.textBox6.Left = 5.5625F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = null;
        this.textBox6.Top = 0.75F;
        this.textBox6.Width = 4.1875F;
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
        this.textBox7.Left = 5.5625F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = null;
        this.textBox7.Top = 0.9375F;
        this.textBox7.Width = 4.1875F;
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
        this.textBox18.Left = 4.5F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "MONEDA:";
        this.textBox18.Top = 1.125F;
        this.textBox18.Width = 1F;
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
        this.textBox19.Height = 0.1875F;
        this.textBox19.Left = 5.5625F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "textBox19";
        this.textBox19.Top = 1.125F;
        this.textBox19.Width = 4.1875F;
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
        this.textBox20.Left = 4.5F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "DATOS:";
        this.textBox20.Top = 1.3125F;
        this.textBox20.Width = 1F;
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
        this.textBox21.Height = 0.1875F;
        this.textBox21.Left = 5.5625F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "textBox21";
        this.textBox21.Top = 1.3125F;
        this.textBox21.Width = 4.1875F;
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
        this.textBox31.Height = 0.1875F;
        this.textBox31.Left = 7.6875F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "textBox31";
        this.textBox31.Top = 0.25F;
        this.textBox31.Width = 5.25F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape10,
            this.shape11,
            this.shape12,
            this.shape13,
            this.shape14,
            this.shape15,
            this.shape16,
            this.shape17,
            this.shape18,
            this.textBox30,
            this.textBox32,
            this.textBox33,
            this.textBox29,
            this.textBox16,
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
            this.line29,
            this.line30,
            this.line40,
            this.line41,
            this.textBox63,
            this.textBox64,
            this.textBox105,
            this.textBox106,
            this.textBox107,
            this.textBox108,
            this.textBox109,
            this.textBox110,
            this.textBox111,
            this.textBox112,
            this.textBox113,
            this.textBox114,
            this.textBox115,
            this.textBox116,
            this.textBox117,
            this.textBox118,
            this.textBox119,
            this.textBox120,
            this.textBox121,
            this.textBox122,
            this.textBox123,
            this.textBox124,
            this.textBox125,
            this.textBox126,
            this.textBox127,
            this.textBox128,
            this.textBox129,
            this.textBox130,
            this.textBox131,
            this.textBox132,
            this.textBox133,
            this.textBox134,
            this.textBox135,
            this.textBox136,
            this.textBox137,
            this.textBox138,
            this.textBox139,
            this.textBox140,
            this.textBox141,
            this.textBox142,
            this.textBox143,
            this.textBox144,
            this.line44,
            this.line45,
            this.line46,
            this.line47,
            this.line48,
            this.line49,
            this.line50,
            this.line51,
            this.line52,
            this.line53,
            this.line31});
        this.reportFooter1.Height = 1.520833F;
        this.reportFooter1.Name = "reportFooter1";
        this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
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
        this.textBox30.Left = 0.0625F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "Total General:";
        this.textBox30.Top = 0.0625F;
        this.textBox30.Width = 2.3125F;
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
        this.textBox32.DataField = "d0_ini_saldo";
        this.textBox32.Height = 0.1875F;
        this.textBox32.Left = 3.4375F;
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
        this.textBox32.Style = "";
        this.textBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox32.Text = "textBox32";
        this.textBox32.Top = 0.0625F;
        this.textBox32.Width = 1F;
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
        this.textBox33.DataField = "d31_ini_saldo";
        this.textBox33.Height = 0.1875F;
        this.textBox33.Left = 5.5625F;
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
        this.textBox33.Style = "";
        this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox33.Text = "textBox33";
        this.textBox33.Top = 0.0625F;
        this.textBox33.Width = 1F;
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
        this.textBox29.DataField = "d61_ini_saldo";
        this.textBox29.Height = 0.1875F;
        this.textBox29.Left = 6.625F;
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
        this.textBox29.Style = "";
        this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox29.Text = "textBox29";
        this.textBox29.Top = 0.0625F;
        this.textBox29.Width = 1F;
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
        this.textBox16.DataField = "d1_ini_saldo";
        this.textBox16.Height = 0.1875F;
        this.textBox16.Left = 4.5F;
        this.textBox16.Name = "textBox16";
        this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
        this.textBox16.Style = "";
        this.textBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox16.Text = "textBox16";
        this.textBox16.Top = 0.0625F;
        this.textBox16.Width = 1F;
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
        this.textBox38.DataField = "d91_ini_saldo";
        this.textBox38.Height = 0.1875F;
        this.textBox38.Left = 7.6875F;
        this.textBox38.Name = "textBox38";
        this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
        this.textBox38.Style = "";
        this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox38.Text = "textBox38";
        this.textBox38.Top = 0.0625F;
        this.textBox38.Width = 1F;
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
        this.textBox39.DataField = "d121_ini_saldo";
        this.textBox39.Height = 0.1875F;
        this.textBox39.Left = 8.75F;
        this.textBox39.Name = "textBox39";
        this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
        this.textBox39.Style = "";
        this.textBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox39.Text = "textBox39";
        this.textBox39.Top = 0.0625F;
        this.textBox39.Width = 1F;
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
        this.textBox40.DataField = "desp_ini_saldo";
        this.textBox40.Height = 0.1875F;
        this.textBox40.Left = 9.8125F;
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
        this.textBox40.Style = "";
        this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox40.Text = "textBox40";
        this.textBox40.Top = 0.0625F;
        this.textBox40.Width = 1F;
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
        this.textBox41.DataField = "rev_ini_saldo";
        this.textBox41.Height = 0.1875F;
        this.textBox41.Left = 10.875F;
        this.textBox41.Name = "textBox41";
        this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
        this.textBox41.Style = "";
        this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox41.Text = "textBox41";
        this.textBox41.Top = 0.0625F;
        this.textBox41.Width = 1F;
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
        this.textBox42.DataField = "ini_saldo";
        this.textBox42.Height = 0.1875F;
        this.textBox42.Left = 11.9375F;
        this.textBox42.Name = "textBox42";
        this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
        this.textBox42.Style = "";
        this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 0.0625F;
        this.textBox42.Width = 1F;
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
        this.textBox43.DataField = "d0_fin_saldo";
        this.textBox43.Height = 0.1979167F;
        this.textBox43.Left = 3.4375F;
        this.textBox43.Name = "textBox43";
        this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
        this.textBox43.Style = "";
        this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0.25F;
        this.textBox43.Width = 1F;
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
        this.textBox44.DataField = "d1_fin_saldo";
        this.textBox44.Height = 0.1979167F;
        this.textBox44.Left = 4.5F;
        this.textBox44.Name = "textBox44";
        this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
        this.textBox44.Style = "";
        this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 0.25F;
        this.textBox44.Width = 1F;
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
        this.textBox45.DataField = "d31_fin_saldo";
        this.textBox45.Height = 0.1979167F;
        this.textBox45.Left = 5.5625F;
        this.textBox45.Name = "textBox45";
        this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
        this.textBox45.Style = "";
        this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox45.Text = "textBox45";
        this.textBox45.Top = 0.25F;
        this.textBox45.Width = 1F;
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
        this.textBox46.DataField = "d61_fin_saldo";
        this.textBox46.Height = 0.1979167F;
        this.textBox46.Left = 6.625F;
        this.textBox46.Name = "textBox46";
        this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
        this.textBox46.Style = "";
        this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0.25F;
        this.textBox46.Width = 1F;
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
        this.textBox47.DataField = "d91_fin_saldo";
        this.textBox47.Height = 0.1979167F;
        this.textBox47.Left = 7.6875F;
        this.textBox47.Name = "textBox47";
        this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
        this.textBox47.Style = "";
        this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0.25F;
        this.textBox47.Width = 1F;
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
        this.textBox48.DataField = "d121_fin_saldo";
        this.textBox48.Height = 0.1979167F;
        this.textBox48.Left = 8.75F;
        this.textBox48.Name = "textBox48";
        this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
        this.textBox48.Style = "";
        this.textBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox48.Text = "textBox48";
        this.textBox48.Top = 0.25F;
        this.textBox48.Width = 1F;
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
        this.textBox49.DataField = "desp_fin_saldo";
        this.textBox49.Height = 0.1979167F;
        this.textBox49.Left = 9.8125F;
        this.textBox49.Name = "textBox49";
        this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
        this.textBox49.Style = "";
        this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox49.Text = "textBox49";
        this.textBox49.Top = 0.25F;
        this.textBox49.Width = 1F;
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
        this.textBox50.DataField = "rev_fin_saldo";
        this.textBox50.Height = 0.1979167F;
        this.textBox50.Left = 10.875F;
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
        this.textBox50.Style = "";
        this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox50.Text = "textBox50";
        this.textBox50.Top = 0.25F;
        this.textBox50.Width = 1F;
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
        this.textBox51.DataField = "fin_saldo";
        this.textBox51.Height = 0.1979167F;
        this.textBox51.Left = 11.9375F;
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
        this.textBox51.Style = "";
        this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox51.Text = "textBox51";
        this.textBox51.Top = 0.25F;
        this.textBox51.Width = 1F;
        // 
        // line29
        // 
        this.line29.Border.BottomColor = System.Drawing.Color.Black;
        this.line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line29.Border.LeftColor = System.Drawing.Color.Black;
        this.line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line29.Border.RightColor = System.Drawing.Color.Black;
        this.line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line29.Border.TopColor = System.Drawing.Color.Black;
        this.line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line29.Height = 1.5F;
        this.line29.Left = 0F;
        this.line29.LineWeight = 1F;
        this.line29.Name = "line29";
        this.line29.Top = 0F;
        this.line29.Width = 0F;
        this.line29.X1 = 0F;
        this.line29.X2 = 0F;
        this.line29.Y1 = 0F;
        this.line29.Y2 = 1.5F;
        // 
        // line30
        // 
        this.line30.Border.BottomColor = System.Drawing.Color.Black;
        this.line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line30.Border.LeftColor = System.Drawing.Color.Black;
        this.line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line30.Border.RightColor = System.Drawing.Color.Black;
        this.line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line30.Border.TopColor = System.Drawing.Color.Black;
        this.line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line30.Height = 1.5F;
        this.line30.Left = 2.4375F;
        this.line30.LineWeight = 1F;
        this.line30.Name = "line30";
        this.line30.Top = 0F;
        this.line30.Width = 0F;
        this.line30.X1 = 2.4375F;
        this.line30.X2 = 2.4375F;
        this.line30.Y1 = 0F;
        this.line30.Y2 = 1.5F;
        // 
        // line40
        // 
        this.line40.Border.BottomColor = System.Drawing.Color.Black;
        this.line40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line40.Border.LeftColor = System.Drawing.Color.Black;
        this.line40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line40.Border.RightColor = System.Drawing.Color.Black;
        this.line40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line40.Border.TopColor = System.Drawing.Color.Black;
        this.line40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line40.Height = 1.5F;
        this.line40.Left = 13F;
        this.line40.LineWeight = 1F;
        this.line40.Name = "line40";
        this.line40.Top = 0F;
        this.line40.Width = 0F;
        this.line40.X1 = 13F;
        this.line40.X2 = 13F;
        this.line40.Y1 = 0F;
        this.line40.Y2 = 1.5F;
        // 
        // line41
        // 
        this.line41.Border.BottomColor = System.Drawing.Color.Black;
        this.line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line41.Border.LeftColor = System.Drawing.Color.Black;
        this.line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line41.Border.RightColor = System.Drawing.Color.Black;
        this.line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line41.Border.TopColor = System.Drawing.Color.Black;
        this.line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line41.Height = 0F;
        this.line41.Left = 0F;
        this.line41.LineWeight = 1F;
        this.line41.Name = "line41";
        this.line41.Top = 1.5F;
        this.line41.Width = 13F;
        this.line41.X1 = 0F;
        this.line41.X2 = 13F;
        this.line41.Y1 = 1.5F;
        this.line41.Y2 = 1.5F;
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
        this.textBox63.Height = 0.1875F;
        this.textBox63.Left = 2.5F;
        this.textBox63.Name = "textBox63";
        this.textBox63.Style = "";
        this.textBox63.Text = "Saldo inicial";
        this.textBox63.Top = 0.0625F;
        this.textBox63.Width = 0.875F;
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
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 2.5F;
        this.textBox64.Name = "textBox64";
        this.textBox64.Style = "";
        this.textBox64.Text = "Saldo final";
        this.textBox64.Top = 0.25F;
        this.textBox64.Width = 0.875F;
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
        this.textBox105.Height = 0.1875F;
        this.textBox105.Left = 2.5F;
        this.textBox105.Name = "textBox105";
        this.textBox105.Style = "";
        this.textBox105.Text = "P.Pend inicial";
        this.textBox105.Top = 0.5625F;
        this.textBox105.Width = 0.9375F;
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
        this.textBox106.DataField = "d0_ini_monto_adeuda";
        this.textBox106.Height = 0.1875F;
        this.textBox106.Left = 3.4375F;
        this.textBox106.Name = "textBox106";
        this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
        this.textBox106.Style = "";
        this.textBox106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox106.Text = "textBox66";
        this.textBox106.Top = 0.5625F;
        this.textBox106.Width = 1F;
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
        this.textBox107.DataField = "d1_ini_monto_adeuda";
        this.textBox107.Height = 0.1875F;
        this.textBox107.Left = 4.5F;
        this.textBox107.Name = "textBox107";
        this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
        this.textBox107.Style = "";
        this.textBox107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox107.Text = "textBox67";
        this.textBox107.Top = 0.5625F;
        this.textBox107.Width = 1F;
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
        this.textBox108.DataField = "d31_ini_monto_adeuda";
        this.textBox108.Height = 0.1875F;
        this.textBox108.Left = 5.5625F;
        this.textBox108.Name = "textBox108";
        this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
        this.textBox108.Style = "";
        this.textBox108.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox108.Text = "textBox68";
        this.textBox108.Top = 0.5625F;
        this.textBox108.Width = 1F;
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
        this.textBox109.DataField = "d61_ini_monto_adeuda";
        this.textBox109.Height = 0.1875F;
        this.textBox109.Left = 6.625F;
        this.textBox109.Name = "textBox109";
        this.textBox109.OutputFormat = resources.GetString("textBox109.OutputFormat");
        this.textBox109.Style = "";
        this.textBox109.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox109.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox109.Text = "textBox69";
        this.textBox109.Top = 0.5625F;
        this.textBox109.Width = 1F;
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
        this.textBox110.DataField = "d91_ini_monto_adeuda";
        this.textBox110.Height = 0.1875F;
        this.textBox110.Left = 7.6875F;
        this.textBox110.Name = "textBox110";
        this.textBox110.OutputFormat = resources.GetString("textBox110.OutputFormat");
        this.textBox110.Style = "";
        this.textBox110.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox110.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox110.Text = "textBox70";
        this.textBox110.Top = 0.5625F;
        this.textBox110.Width = 1F;
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
        this.textBox111.DataField = "d121_ini_monto_adeuda";
        this.textBox111.Height = 0.1875F;
        this.textBox111.Left = 8.75F;
        this.textBox111.Name = "textBox111";
        this.textBox111.OutputFormat = resources.GetString("textBox111.OutputFormat");
        this.textBox111.Style = "";
        this.textBox111.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox111.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox111.Text = "textBox71";
        this.textBox111.Top = 0.5625F;
        this.textBox111.Width = 1F;
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
        this.textBox112.DataField = "desp_ini_monto_adeuda";
        this.textBox112.Height = 0.1875F;
        this.textBox112.Left = 9.8125F;
        this.textBox112.Name = "textBox112";
        this.textBox112.OutputFormat = resources.GetString("textBox112.OutputFormat");
        this.textBox112.Style = "";
        this.textBox112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox112.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox112.Text = "textBox72";
        this.textBox112.Top = 0.5625F;
        this.textBox112.Width = 1F;
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
        this.textBox113.DataField = "rev_ini_monto_adeuda";
        this.textBox113.Height = 0.1875F;
        this.textBox113.Left = 10.875F;
        this.textBox113.Name = "textBox113";
        this.textBox113.OutputFormat = resources.GetString("textBox113.OutputFormat");
        this.textBox113.Style = "";
        this.textBox113.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox113.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox113.Text = "textBox73";
        this.textBox113.Top = 0.5625F;
        this.textBox113.Width = 1F;
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
        this.textBox114.DataField = "ini_monto_adeuda";
        this.textBox114.Height = 0.1875F;
        this.textBox114.Left = 11.9375F;
        this.textBox114.Name = "textBox114";
        this.textBox114.OutputFormat = resources.GetString("textBox114.OutputFormat");
        this.textBox114.Style = "";
        this.textBox114.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox114.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox114.Text = "textBox74";
        this.textBox114.Top = 0.5625F;
        this.textBox114.Width = 1F;
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
        this.textBox115.Left = 2.5F;
        this.textBox115.Name = "textBox115";
        this.textBox115.Style = "";
        this.textBox115.Text = "P.Pend final";
        this.textBox115.Top = 0.75F;
        this.textBox115.Width = 0.9375F;
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
        this.textBox116.DataField = "d0_fin_monto_adeuda";
        this.textBox116.Height = 0.1875F;
        this.textBox116.Left = 3.4375F;
        this.textBox116.Name = "textBox116";
        this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
        this.textBox116.Style = "";
        this.textBox116.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox116.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox116.Text = "textBox76";
        this.textBox116.Top = 0.75F;
        this.textBox116.Width = 1F;
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
        this.textBox117.DataField = "d1_fin_monto_adeuda";
        this.textBox117.Height = 0.1875F;
        this.textBox117.Left = 4.5F;
        this.textBox117.Name = "textBox117";
        this.textBox117.OutputFormat = resources.GetString("textBox117.OutputFormat");
        this.textBox117.Style = "";
        this.textBox117.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox117.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox117.Text = "textBox77";
        this.textBox117.Top = 0.75F;
        this.textBox117.Width = 1F;
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
        this.textBox118.DataField = "d31_fin_monto_adeuda";
        this.textBox118.Height = 0.1875F;
        this.textBox118.Left = 5.5625F;
        this.textBox118.Name = "textBox118";
        this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
        this.textBox118.Style = "";
        this.textBox118.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox118.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox118.Text = "textBox78";
        this.textBox118.Top = 0.75F;
        this.textBox118.Width = 1F;
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
        this.textBox119.DataField = "d61_fin_monto_adeuda";
        this.textBox119.Height = 0.1875F;
        this.textBox119.Left = 6.625F;
        this.textBox119.Name = "textBox119";
        this.textBox119.OutputFormat = resources.GetString("textBox119.OutputFormat");
        this.textBox119.Style = "";
        this.textBox119.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox119.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox119.Text = "textBox79";
        this.textBox119.Top = 0.75F;
        this.textBox119.Width = 1F;
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
        this.textBox120.DataField = "d91_fin_monto_adeuda";
        this.textBox120.Height = 0.1875F;
        this.textBox120.Left = 7.6875F;
        this.textBox120.Name = "textBox120";
        this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
        this.textBox120.Style = "";
        this.textBox120.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox120.Text = "textBox80";
        this.textBox120.Top = 0.75F;
        this.textBox120.Width = 1F;
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
        this.textBox121.DataField = "d121_fin_monto_adeuda";
        this.textBox121.Height = 0.1875F;
        this.textBox121.Left = 8.75F;
        this.textBox121.Name = "textBox121";
        this.textBox121.OutputFormat = resources.GetString("textBox121.OutputFormat");
        this.textBox121.Style = "";
        this.textBox121.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox121.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox121.Text = "textBox81";
        this.textBox121.Top = 0.75F;
        this.textBox121.Width = 1F;
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
        this.textBox122.DataField = "desp_fin_monto_adeuda";
        this.textBox122.Height = 0.1875F;
        this.textBox122.Left = 9.8125F;
        this.textBox122.Name = "textBox122";
        this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
        this.textBox122.Style = "";
        this.textBox122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox122.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox122.Text = "textBox82";
        this.textBox122.Top = 0.75F;
        this.textBox122.Width = 1F;
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
        this.textBox123.DataField = "rev_fin_monto_adeuda";
        this.textBox123.Height = 0.1875F;
        this.textBox123.Left = 10.875F;
        this.textBox123.Name = "textBox123";
        this.textBox123.OutputFormat = resources.GetString("textBox123.OutputFormat");
        this.textBox123.Style = "";
        this.textBox123.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox123.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox123.Text = "textBox83";
        this.textBox123.Top = 0.75F;
        this.textBox123.Width = 1F;
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
        this.textBox124.DataField = "fin_monto_adeuda";
        this.textBox124.Height = 0.1875F;
        this.textBox124.Left = 11.9375F;
        this.textBox124.Name = "textBox124";
        this.textBox124.OutputFormat = resources.GetString("textBox124.OutputFormat");
        this.textBox124.Style = "";
        this.textBox124.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox124.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox124.Text = "textBox84";
        this.textBox124.Top = 0.75F;
        this.textBox124.Width = 1F;
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
        this.textBox125.Left = 2.5F;
        this.textBox125.Name = "textBox125";
        this.textBox125.Style = "";
        this.textBox125.Text = "Nºcttos inicial";
        this.textBox125.Top = 1.0625F;
        this.textBox125.Width = 0.9375F;
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
        this.textBox126.DataField = "d0_ini_saldo";
        this.textBox126.Height = 0.1875F;
        this.textBox126.Left = 3.4375F;
        this.textBox126.Name = "textBox126";
        this.textBox126.Style = "";
        this.textBox126.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox126.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox126.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox126.Text = "textBox86";
        this.textBox126.Top = 1.0625F;
        this.textBox126.Width = 1F;
        // 
        // textBox127
        // 
        this.textBox127.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox127.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox127.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox127.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox127.Border.RightColor = System.Drawing.Color.Black;
        this.textBox127.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox127.Border.TopColor = System.Drawing.Color.Black;
        this.textBox127.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox127.DataField = "d1_ini_saldo";
        this.textBox127.Height = 0.1875F;
        this.textBox127.Left = 4.5F;
        this.textBox127.Name = "textBox127";
        this.textBox127.Style = "";
        this.textBox127.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox127.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox127.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox127.Text = "textBox87";
        this.textBox127.Top = 1.0625F;
        this.textBox127.Width = 1F;
        // 
        // textBox128
        // 
        this.textBox128.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox128.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox128.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox128.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox128.Border.RightColor = System.Drawing.Color.Black;
        this.textBox128.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox128.Border.TopColor = System.Drawing.Color.Black;
        this.textBox128.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox128.DataField = "d31_ini_saldo";
        this.textBox128.Height = 0.1875F;
        this.textBox128.Left = 5.5625F;
        this.textBox128.Name = "textBox128";
        this.textBox128.Style = "";
        this.textBox128.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox128.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox128.Text = "textBox88";
        this.textBox128.Top = 1.0625F;
        this.textBox128.Width = 1F;
        // 
        // textBox129
        // 
        this.textBox129.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox129.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox129.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox129.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox129.Border.RightColor = System.Drawing.Color.Black;
        this.textBox129.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox129.Border.TopColor = System.Drawing.Color.Black;
        this.textBox129.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox129.DataField = "d61_ini_saldo";
        this.textBox129.Height = 0.1875F;
        this.textBox129.Left = 6.625F;
        this.textBox129.Name = "textBox129";
        this.textBox129.Style = "";
        this.textBox129.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox129.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox129.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox129.Text = "textBox89";
        this.textBox129.Top = 1.0625F;
        this.textBox129.Width = 1F;
        // 
        // textBox130
        // 
        this.textBox130.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox130.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox130.Border.RightColor = System.Drawing.Color.Black;
        this.textBox130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox130.Border.TopColor = System.Drawing.Color.Black;
        this.textBox130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox130.DataField = "d91_ini_saldo";
        this.textBox130.Height = 0.1875F;
        this.textBox130.Left = 7.6875F;
        this.textBox130.Name = "textBox130";
        this.textBox130.Style = "";
        this.textBox130.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox130.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox130.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox130.Text = "textBox90";
        this.textBox130.Top = 1.0625F;
        this.textBox130.Width = 1F;
        // 
        // textBox131
        // 
        this.textBox131.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox131.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox131.Border.RightColor = System.Drawing.Color.Black;
        this.textBox131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox131.Border.TopColor = System.Drawing.Color.Black;
        this.textBox131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox131.DataField = "d121_ini_saldo";
        this.textBox131.Height = 0.1875F;
        this.textBox131.Left = 8.75F;
        this.textBox131.Name = "textBox131";
        this.textBox131.Style = "";
        this.textBox131.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox131.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox131.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox131.Text = "textBox91";
        this.textBox131.Top = 1.0625F;
        this.textBox131.Width = 1F;
        // 
        // textBox132
        // 
        this.textBox132.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox132.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox132.Border.RightColor = System.Drawing.Color.Black;
        this.textBox132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox132.Border.TopColor = System.Drawing.Color.Black;
        this.textBox132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox132.DataField = "desp_ini_saldo";
        this.textBox132.Height = 0.1875F;
        this.textBox132.Left = 9.8125F;
        this.textBox132.Name = "textBox132";
        this.textBox132.Style = "";
        this.textBox132.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox132.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox132.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox132.Text = "textBox92";
        this.textBox132.Top = 1.0625F;
        this.textBox132.Width = 1F;
        // 
        // textBox133
        // 
        this.textBox133.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox133.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox133.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox133.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox133.Border.RightColor = System.Drawing.Color.Black;
        this.textBox133.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox133.Border.TopColor = System.Drawing.Color.Black;
        this.textBox133.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox133.DataField = "rev_ini_saldo";
        this.textBox133.Height = 0.1875F;
        this.textBox133.Left = 10.875F;
        this.textBox133.Name = "textBox133";
        this.textBox133.Style = "";
        this.textBox133.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox133.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox133.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox133.Text = "textBox93";
        this.textBox133.Top = 1.0625F;
        this.textBox133.Width = 1F;
        // 
        // textBox134
        // 
        this.textBox134.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox134.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox134.Border.RightColor = System.Drawing.Color.Black;
        this.textBox134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox134.Border.TopColor = System.Drawing.Color.Black;
        this.textBox134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox134.DataField = "ini_saldo";
        this.textBox134.Height = 0.1875F;
        this.textBox134.Left = 11.9375F;
        this.textBox134.Name = "textBox134";
        this.textBox134.Style = "";
        this.textBox134.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox134.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox134.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox134.Text = "textBox94";
        this.textBox134.Top = 1.0625F;
        this.textBox134.Width = 1F;
        // 
        // textBox135
        // 
        this.textBox135.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox135.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox135.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox135.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox135.Border.RightColor = System.Drawing.Color.Black;
        this.textBox135.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox135.Border.TopColor = System.Drawing.Color.Black;
        this.textBox135.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox135.Height = 0.1875F;
        this.textBox135.Left = 2.5F;
        this.textBox135.Name = "textBox135";
        this.textBox135.Style = "";
        this.textBox135.Text = "Nºcttos final";
        this.textBox135.Top = 1.25F;
        this.textBox135.Width = 0.9375F;
        // 
        // textBox136
        // 
        this.textBox136.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox136.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox136.Border.RightColor = System.Drawing.Color.Black;
        this.textBox136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox136.Border.TopColor = System.Drawing.Color.Black;
        this.textBox136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox136.DataField = "d0_fin_saldo";
        this.textBox136.Height = 0.1875F;
        this.textBox136.Left = 3.4375F;
        this.textBox136.Name = "textBox136";
        this.textBox136.Style = "";
        this.textBox136.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox136.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox136.Text = "textBox96";
        this.textBox136.Top = 1.25F;
        this.textBox136.Width = 1F;
        // 
        // textBox137
        // 
        this.textBox137.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox137.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox137.Border.RightColor = System.Drawing.Color.Black;
        this.textBox137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox137.Border.TopColor = System.Drawing.Color.Black;
        this.textBox137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox137.DataField = "d1_fin_saldo";
        this.textBox137.Height = 0.1875F;
        this.textBox137.Left = 4.5F;
        this.textBox137.Name = "textBox137";
        this.textBox137.Style = "";
        this.textBox137.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox137.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox137.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox137.Text = "textBox97";
        this.textBox137.Top = 1.25F;
        this.textBox137.Width = 1F;
        // 
        // textBox138
        // 
        this.textBox138.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox138.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox138.Border.RightColor = System.Drawing.Color.Black;
        this.textBox138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox138.Border.TopColor = System.Drawing.Color.Black;
        this.textBox138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox138.DataField = "d31_fin_saldo";
        this.textBox138.Height = 0.1875F;
        this.textBox138.Left = 5.5625F;
        this.textBox138.Name = "textBox138";
        this.textBox138.Style = "";
        this.textBox138.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox138.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox138.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox138.Text = "textBox98";
        this.textBox138.Top = 1.25F;
        this.textBox138.Width = 1F;
        // 
        // textBox139
        // 
        this.textBox139.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox139.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox139.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox139.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox139.Border.RightColor = System.Drawing.Color.Black;
        this.textBox139.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox139.Border.TopColor = System.Drawing.Color.Black;
        this.textBox139.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox139.DataField = "d61_fin_saldo";
        this.textBox139.Height = 0.1875F;
        this.textBox139.Left = 6.625F;
        this.textBox139.Name = "textBox139";
        this.textBox139.Style = "";
        this.textBox139.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox139.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox139.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox139.Text = "textBox99";
        this.textBox139.Top = 1.25F;
        this.textBox139.Width = 1F;
        // 
        // textBox140
        // 
        this.textBox140.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox140.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox140.Border.RightColor = System.Drawing.Color.Black;
        this.textBox140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox140.Border.TopColor = System.Drawing.Color.Black;
        this.textBox140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox140.DataField = "d91_fin_saldo";
        this.textBox140.Height = 0.1875F;
        this.textBox140.Left = 7.6875F;
        this.textBox140.Name = "textBox140";
        this.textBox140.Style = "";
        this.textBox140.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox140.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox140.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox140.Text = "textBox100";
        this.textBox140.Top = 1.25F;
        this.textBox140.Width = 1F;
        // 
        // textBox141
        // 
        this.textBox141.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox141.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox141.Border.RightColor = System.Drawing.Color.Black;
        this.textBox141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox141.Border.TopColor = System.Drawing.Color.Black;
        this.textBox141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox141.DataField = "d121_fin_saldo";
        this.textBox141.Height = 0.1875F;
        this.textBox141.Left = 8.75F;
        this.textBox141.Name = "textBox141";
        this.textBox141.Style = "";
        this.textBox141.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox141.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox141.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox141.Text = "textBox101";
        this.textBox141.Top = 1.25F;
        this.textBox141.Width = 1F;
        // 
        // textBox142
        // 
        this.textBox142.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox142.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox142.Border.RightColor = System.Drawing.Color.Black;
        this.textBox142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox142.Border.TopColor = System.Drawing.Color.Black;
        this.textBox142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox142.DataField = "desp_fin_saldo";
        this.textBox142.Height = 0.1875F;
        this.textBox142.Left = 9.8125F;
        this.textBox142.Name = "textBox142";
        this.textBox142.Style = "";
        this.textBox142.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox142.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox142.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox142.Text = "textBox102";
        this.textBox142.Top = 1.25F;
        this.textBox142.Width = 1F;
        // 
        // textBox143
        // 
        this.textBox143.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox143.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox143.Border.RightColor = System.Drawing.Color.Black;
        this.textBox143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox143.Border.TopColor = System.Drawing.Color.Black;
        this.textBox143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox143.DataField = "rev_fin_saldo";
        this.textBox143.Height = 0.1875F;
        this.textBox143.Left = 10.875F;
        this.textBox143.Name = "textBox143";
        this.textBox143.Style = "";
        this.textBox143.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox143.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox143.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox143.Text = "textBox103";
        this.textBox143.Top = 1.25F;
        this.textBox143.Width = 1F;
        // 
        // textBox144
        // 
        this.textBox144.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox144.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox144.Border.RightColor = System.Drawing.Color.Black;
        this.textBox144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox144.Border.TopColor = System.Drawing.Color.Black;
        this.textBox144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox144.DataField = "fin_saldo";
        this.textBox144.Height = 0.1875F;
        this.textBox144.Left = 11.9375F;
        this.textBox144.Name = "textBox144";
        this.textBox144.Style = "";
        this.textBox144.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox144.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox144.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox144.Text = "textBox104";
        this.textBox144.Top = 1.25F;
        this.textBox144.Width = 1F;
        // 
        // line44
        // 
        this.line44.Border.BottomColor = System.Drawing.Color.Black;
        this.line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line44.Border.LeftColor = System.Drawing.Color.Black;
        this.line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line44.Border.RightColor = System.Drawing.Color.Black;
        this.line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line44.Border.TopColor = System.Drawing.Color.Black;
        this.line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line44.Height = 1.5F;
        this.line44.Left = 3.4375F;
        this.line44.LineWeight = 1F;
        this.line44.Name = "line44";
        this.line44.Top = 0F;
        this.line44.Width = 0F;
        this.line44.X1 = 3.4375F;
        this.line44.X2 = 3.4375F;
        this.line44.Y1 = 1.5F;
        this.line44.Y2 = 0F;
        // 
        // line45
        // 
        this.line45.Border.BottomColor = System.Drawing.Color.Black;
        this.line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line45.Border.LeftColor = System.Drawing.Color.Black;
        this.line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line45.Border.RightColor = System.Drawing.Color.Black;
        this.line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line45.Border.TopColor = System.Drawing.Color.Black;
        this.line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line45.Height = 1.5F;
        this.line45.Left = 4.5F;
        this.line45.LineWeight = 1F;
        this.line45.Name = "line45";
        this.line45.Top = 0F;
        this.line45.Width = 0F;
        this.line45.X1 = 4.5F;
        this.line45.X2 = 4.5F;
        this.line45.Y1 = 1.5F;
        this.line45.Y2 = 0F;
        // 
        // line46
        // 
        this.line46.Border.BottomColor = System.Drawing.Color.Black;
        this.line46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line46.Border.LeftColor = System.Drawing.Color.Black;
        this.line46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line46.Border.RightColor = System.Drawing.Color.Black;
        this.line46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line46.Border.TopColor = System.Drawing.Color.Black;
        this.line46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line46.Height = 1.5F;
        this.line46.Left = 5.5625F;
        this.line46.LineWeight = 1F;
        this.line46.Name = "line46";
        this.line46.Top = 0F;
        this.line46.Width = 0F;
        this.line46.X1 = 5.5625F;
        this.line46.X2 = 5.5625F;
        this.line46.Y1 = 1.5F;
        this.line46.Y2 = 0F;
        // 
        // line47
        // 
        this.line47.Border.BottomColor = System.Drawing.Color.Black;
        this.line47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line47.Border.LeftColor = System.Drawing.Color.Black;
        this.line47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line47.Border.RightColor = System.Drawing.Color.Black;
        this.line47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line47.Border.TopColor = System.Drawing.Color.Black;
        this.line47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line47.Height = 1.5F;
        this.line47.Left = 6.625F;
        this.line47.LineWeight = 1F;
        this.line47.Name = "line47";
        this.line47.Top = 0F;
        this.line47.Width = 0F;
        this.line47.X1 = 6.625F;
        this.line47.X2 = 6.625F;
        this.line47.Y1 = 1.5F;
        this.line47.Y2 = 0F;
        // 
        // line48
        // 
        this.line48.Border.BottomColor = System.Drawing.Color.Black;
        this.line48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line48.Border.LeftColor = System.Drawing.Color.Black;
        this.line48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line48.Border.RightColor = System.Drawing.Color.Black;
        this.line48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line48.Border.TopColor = System.Drawing.Color.Black;
        this.line48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line48.Height = 1.5F;
        this.line48.Left = 7.6875F;
        this.line48.LineWeight = 1F;
        this.line48.Name = "line48";
        this.line48.Top = 0F;
        this.line48.Width = 0F;
        this.line48.X1 = 7.6875F;
        this.line48.X2 = 7.6875F;
        this.line48.Y1 = 1.5F;
        this.line48.Y2 = 0F;
        // 
        // line49
        // 
        this.line49.Border.BottomColor = System.Drawing.Color.Black;
        this.line49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line49.Border.LeftColor = System.Drawing.Color.Black;
        this.line49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line49.Border.RightColor = System.Drawing.Color.Black;
        this.line49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line49.Border.TopColor = System.Drawing.Color.Black;
        this.line49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line49.Height = 1.5F;
        this.line49.Left = 8.75F;
        this.line49.LineWeight = 1F;
        this.line49.Name = "line49";
        this.line49.Top = 0F;
        this.line49.Width = 0F;
        this.line49.X1 = 8.75F;
        this.line49.X2 = 8.75F;
        this.line49.Y1 = 1.5F;
        this.line49.Y2 = 0F;
        // 
        // line50
        // 
        this.line50.Border.BottomColor = System.Drawing.Color.Black;
        this.line50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line50.Border.LeftColor = System.Drawing.Color.Black;
        this.line50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line50.Border.RightColor = System.Drawing.Color.Black;
        this.line50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line50.Border.TopColor = System.Drawing.Color.Black;
        this.line50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line50.Height = 1.5F;
        this.line50.Left = 9.8125F;
        this.line50.LineWeight = 1F;
        this.line50.Name = "line50";
        this.line50.Top = 0F;
        this.line50.Width = 0F;
        this.line50.X1 = 9.8125F;
        this.line50.X2 = 9.8125F;
        this.line50.Y1 = 1.5F;
        this.line50.Y2 = 0F;
        // 
        // line51
        // 
        this.line51.Border.BottomColor = System.Drawing.Color.Black;
        this.line51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line51.Border.LeftColor = System.Drawing.Color.Black;
        this.line51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line51.Border.RightColor = System.Drawing.Color.Black;
        this.line51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line51.Border.TopColor = System.Drawing.Color.Black;
        this.line51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line51.Height = 1.5F;
        this.line51.Left = 10.875F;
        this.line51.LineWeight = 1F;
        this.line51.Name = "line51";
        this.line51.Top = 0F;
        this.line51.Width = 0F;
        this.line51.X1 = 10.875F;
        this.line51.X2 = 10.875F;
        this.line51.Y1 = 1.5F;
        this.line51.Y2 = 0F;
        // 
        // line52
        // 
        this.line52.Border.BottomColor = System.Drawing.Color.Black;
        this.line52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line52.Border.LeftColor = System.Drawing.Color.Black;
        this.line52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line52.Border.RightColor = System.Drawing.Color.Black;
        this.line52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line52.Border.TopColor = System.Drawing.Color.Black;
        this.line52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line52.Height = 1.5F;
        this.line52.Left = 11.9375F;
        this.line52.LineWeight = 1F;
        this.line52.Name = "line52";
        this.line52.Top = 0F;
        this.line52.Width = 0F;
        this.line52.X1 = 11.9375F;
        this.line52.X2 = 11.9375F;
        this.line52.Y1 = 1.5F;
        this.line52.Y2 = 0F;
        // 
        // line53
        // 
        this.line53.Border.BottomColor = System.Drawing.Color.Black;
        this.line53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line53.Border.LeftColor = System.Drawing.Color.Black;
        this.line53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line53.Border.RightColor = System.Drawing.Color.Black;
        this.line53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line53.Border.TopColor = System.Drawing.Color.Black;
        this.line53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line53.Height = 0F;
        this.line53.Left = 2.4375F;
        this.line53.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line53.LineWeight = 1F;
        this.line53.Name = "line53";
        this.line53.Top = 0.5F;
        this.line53.Width = 10.5625F;
        this.line53.X1 = 2.4375F;
        this.line53.X2 = 13F;
        this.line53.Y1 = 0.5F;
        this.line53.Y2 = 0.5F;
        // 
        // line31
        // 
        this.line31.Border.BottomColor = System.Drawing.Color.Black;
        this.line31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line31.Border.LeftColor = System.Drawing.Color.Black;
        this.line31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line31.Border.RightColor = System.Drawing.Color.Black;
        this.line31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line31.Border.TopColor = System.Drawing.Color.Black;
        this.line31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line31.Height = 0F;
        this.line31.Left = 2.4375F;
        this.line31.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line31.LineWeight = 1F;
        this.line31.Name = "line31";
        this.line31.Top = 1F;
        this.line31.Width = 10.5625F;
        this.line31.X1 = 2.4375F;
        this.line31.X2 = 13F;
        this.line31.Y1 = 1F;
        this.line31.Y2 = 1F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.DataField = "ini_rango";
        this.groupHeader1.Height = 0F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.shape2,
            this.shape3,
            this.shape4,
            this.shape5,
            this.shape6,
            this.shape7,
            this.shape8,
            this.shape9,
            this.textBox24,
            this.textBox25,
            this.textBox17,
            this.textBox26,
            this.textBox22,
            this.textBox27,
            this.textBox28,
            this.textBox15,
            this.textBox34,
            this.textBox35,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
            this.textBox58,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.line2,
            this.line3,
            this.line14,
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
            this.textBox79,
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
            this.textBox103,
            this.textBox104,
            this.line4,
            this.line5,
            this.line6,
            this.line7,
            this.line8,
            this.line9,
            this.line10,
            this.line11,
            this.line12,
            this.line13,
            this.line42,
            this.line43});
        this.groupFooter1.Height = 1.510417F;
        this.groupFooter1.KeepTogether = true;
        this.groupFooter1.Name = "groupFooter1";
        this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
        // 
        // shape2
        // 
        this.shape2.Border.BottomColor = System.Drawing.Color.Black;
        this.shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Border.LeftColor = System.Drawing.Color.Black;
        this.shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Border.RightColor = System.Drawing.Color.Black;
        this.shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Border.TopColor = System.Drawing.Color.Black;
        this.shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Height = 1.5F;
        this.shape2.Left = 4.5F;
        this.shape2.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape2.Name = "shape2";
        this.shape2.RoundingRadius = 9.999999F;
        this.shape2.Top = 0F;
        this.shape2.Width = 1.0625F;
        // 
        // shape3
        // 
        this.shape3.Border.BottomColor = System.Drawing.Color.Black;
        this.shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape3.Border.LeftColor = System.Drawing.Color.Black;
        this.shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape3.Border.RightColor = System.Drawing.Color.Black;
        this.shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape3.Border.TopColor = System.Drawing.Color.Black;
        this.shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape3.Height = 1.5F;
        this.shape3.Left = 5.5625F;
        this.shape3.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape3.Name = "shape3";
        this.shape3.RoundingRadius = 9.999999F;
        this.shape3.Top = 0F;
        this.shape3.Width = 1.0625F;
        // 
        // shape4
        // 
        this.shape4.Border.BottomColor = System.Drawing.Color.Black;
        this.shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape4.Border.LeftColor = System.Drawing.Color.Black;
        this.shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape4.Border.RightColor = System.Drawing.Color.Black;
        this.shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape4.Border.TopColor = System.Drawing.Color.Black;
        this.shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape4.Height = 1.5F;
        this.shape4.Left = 6.625F;
        this.shape4.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape4.Name = "shape4";
        this.shape4.RoundingRadius = 9.999999F;
        this.shape4.Top = 0F;
        this.shape4.Width = 1.0625F;
        // 
        // shape5
        // 
        this.shape5.Border.BottomColor = System.Drawing.Color.Black;
        this.shape5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape5.Border.LeftColor = System.Drawing.Color.Black;
        this.shape5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape5.Border.RightColor = System.Drawing.Color.Black;
        this.shape5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape5.Border.TopColor = System.Drawing.Color.Black;
        this.shape5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape5.Height = 1.5F;
        this.shape5.Left = 7.6875F;
        this.shape5.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape5.Name = "shape5";
        this.shape5.RoundingRadius = 9.999999F;
        this.shape5.Top = 0F;
        this.shape5.Width = 1.0625F;
        // 
        // shape6
        // 
        this.shape6.Border.BottomColor = System.Drawing.Color.Black;
        this.shape6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape6.Border.LeftColor = System.Drawing.Color.Black;
        this.shape6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape6.Border.RightColor = System.Drawing.Color.Black;
        this.shape6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape6.Border.TopColor = System.Drawing.Color.Black;
        this.shape6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape6.Height = 1.5F;
        this.shape6.Left = 8.75F;
        this.shape6.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape6.Name = "shape6";
        this.shape6.RoundingRadius = 9.999999F;
        this.shape6.Top = 0F;
        this.shape6.Width = 1.0625F;
        // 
        // shape7
        // 
        this.shape7.Border.BottomColor = System.Drawing.Color.Black;
        this.shape7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape7.Border.LeftColor = System.Drawing.Color.Black;
        this.shape7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape7.Border.RightColor = System.Drawing.Color.Black;
        this.shape7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape7.Border.TopColor = System.Drawing.Color.Black;
        this.shape7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape7.Height = 1.5F;
        this.shape7.Left = 9.8125F;
        this.shape7.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape7.Name = "shape7";
        this.shape7.RoundingRadius = 9.999999F;
        this.shape7.Top = 0F;
        this.shape7.Width = 1.0625F;
        // 
        // shape8
        // 
        this.shape8.Border.BottomColor = System.Drawing.Color.Black;
        this.shape8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape8.Border.LeftColor = System.Drawing.Color.Black;
        this.shape8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape8.Border.RightColor = System.Drawing.Color.Black;
        this.shape8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape8.Border.TopColor = System.Drawing.Color.Black;
        this.shape8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape8.Height = 1.5F;
        this.shape8.Left = 10.875F;
        this.shape8.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape8.Name = "shape8";
        this.shape8.RoundingRadius = 9.999999F;
        this.shape8.Top = 0F;
        this.shape8.Width = 1.0625F;
        // 
        // shape9
        // 
        this.shape9.Border.BottomColor = System.Drawing.Color.Black;
        this.shape9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape9.Border.LeftColor = System.Drawing.Color.Black;
        this.shape9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape9.Border.RightColor = System.Drawing.Color.Black;
        this.shape9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape9.Border.TopColor = System.Drawing.Color.Black;
        this.shape9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape9.Height = 1.5F;
        this.shape9.Left = 11.9375F;
        this.shape9.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape9.Name = "shape9";
        this.shape9.RoundingRadius = 9.999999F;
        this.shape9.Top = 0F;
        this.shape9.Width = 1.0625F;
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
        this.textBox34.DataField = "rev_ini_saldo";
        this.textBox34.Height = 0.1875F;
        this.textBox34.Left = 10.875F;
        this.textBox34.Name = "textBox34";
        this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
        this.textBox34.Style = "";
        this.textBox34.SummaryGroup = "groupHeader1";
        this.textBox34.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox34.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox34.Text = "textBox34";
        this.textBox34.Top = 0.0625F;
        this.textBox34.Width = 1F;
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
        this.textBox35.DataField = "ini_saldo";
        this.textBox35.Height = 0.1875F;
        this.textBox35.Left = 11.9375F;
        this.textBox35.Name = "textBox35";
        this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
        this.textBox35.Style = "";
        this.textBox35.SummaryGroup = "groupHeader1";
        this.textBox35.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox35.Text = "textBox35";
        this.textBox35.Top = 0.0625F;
        this.textBox35.Width = 1F;
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
        this.textBox52.DataField = "d0_fin_saldo";
        this.textBox52.Height = 0.1979167F;
        this.textBox52.Left = 3.4375F;
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
        this.textBox52.Style = "";
        this.textBox52.SummaryGroup = "groupHeader1";
        this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox52.Text = "textBox52";
        this.textBox52.Top = 0.25F;
        this.textBox52.Width = 1F;
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
        this.textBox53.DataField = "d1_fin_saldo";
        this.textBox53.Height = 0.1979167F;
        this.textBox53.Left = 4.5F;
        this.textBox53.Name = "textBox53";
        this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
        this.textBox53.Style = "";
        this.textBox53.SummaryGroup = "groupHeader1";
        this.textBox53.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox53.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox53.Text = "textBox53";
        this.textBox53.Top = 0.25F;
        this.textBox53.Width = 1F;
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
        this.textBox54.DataField = "d31_fin_saldo";
        this.textBox54.Height = 0.1979167F;
        this.textBox54.Left = 5.5625F;
        this.textBox54.Name = "textBox54";
        this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
        this.textBox54.Style = "";
        this.textBox54.SummaryGroup = "groupHeader1";
        this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox54.Text = "textBox54";
        this.textBox54.Top = 0.25F;
        this.textBox54.Width = 1F;
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
        this.textBox55.DataField = "d61_fin_saldo";
        this.textBox55.Height = 0.1979167F;
        this.textBox55.Left = 6.625F;
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
        this.textBox55.Style = "";
        this.textBox55.SummaryGroup = "groupHeader1";
        this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox55.Text = "textBox55";
        this.textBox55.Top = 0.25F;
        this.textBox55.Width = 1F;
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
        this.textBox56.DataField = "d91_fin_saldo";
        this.textBox56.Height = 0.1979167F;
        this.textBox56.Left = 7.6875F;
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
        this.textBox56.Style = "";
        this.textBox56.SummaryGroup = "groupHeader1";
        this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox56.Text = "textBox56";
        this.textBox56.Top = 0.25F;
        this.textBox56.Width = 1F;
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
        this.textBox57.DataField = "d121_fin_saldo";
        this.textBox57.Height = 0.1979167F;
        this.textBox57.Left = 8.75F;
        this.textBox57.Name = "textBox57";
        this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
        this.textBox57.Style = "";
        this.textBox57.SummaryGroup = "groupHeader1";
        this.textBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox57.Text = "textBox57";
        this.textBox57.Top = 0.25F;
        this.textBox57.Width = 1F;
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
        this.textBox58.DataField = "desp_fin_saldo";
        this.textBox58.Height = 0.1979167F;
        this.textBox58.Left = 9.8125F;
        this.textBox58.Name = "textBox58";
        this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
        this.textBox58.Style = "";
        this.textBox58.SummaryGroup = "groupHeader1";
        this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox58.Text = "textBox58";
        this.textBox58.Top = 0.25F;
        this.textBox58.Width = 1F;
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
        this.textBox59.DataField = "rev_fin_saldo";
        this.textBox59.Height = 0.1979167F;
        this.textBox59.Left = 10.875F;
        this.textBox59.Name = "textBox59";
        this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
        this.textBox59.Style = "";
        this.textBox59.SummaryGroup = "groupHeader1";
        this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox59.Text = "textBox59";
        this.textBox59.Top = 0.25F;
        this.textBox59.Width = 1F;
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
        this.textBox60.DataField = "fin_saldo";
        this.textBox60.Height = 0.1979167F;
        this.textBox60.Left = 11.9375F;
        this.textBox60.Name = "textBox60";
        this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
        this.textBox60.Style = "";
        this.textBox60.SummaryGroup = "groupHeader1";
        this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox60.Text = "textBox60";
        this.textBox60.Top = 0.25F;
        this.textBox60.Width = 1F;
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
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 2.5F;
        this.textBox61.Name = "textBox61";
        this.textBox61.Style = "";
        this.textBox61.Text = "Saldo inicial";
        this.textBox61.Top = 0.0625F;
        this.textBox61.Width = 0.875F;
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
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 2.5F;
        this.textBox62.Name = "textBox62";
        this.textBox62.Style = "";
        this.textBox62.Text = "Saldo final";
        this.textBox62.Top = 0.25F;
        this.textBox62.Width = 0.875F;
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
        this.line2.Left = 0F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 1.5F;
        this.line2.Width = 13F;
        this.line2.X1 = 0F;
        this.line2.X2 = 13F;
        this.line2.Y1 = 1.5F;
        this.line2.Y2 = 1.5F;
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
        this.line3.Height = 1.5F;
        this.line3.Left = 0F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0F;
        this.line3.Width = 0F;
        this.line3.X1 = 0F;
        this.line3.X2 = 0F;
        this.line3.Y1 = 1.5F;
        this.line3.Y2 = 0F;
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
        this.line14.Height = 1.5F;
        this.line14.Left = 2.4375F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 0F;
        this.line14.Width = 0F;
        this.line14.X1 = 2.4375F;
        this.line14.X2 = 2.4375F;
        this.line14.Y1 = 1.5F;
        this.line14.Y2 = 0F;
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
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 2.5F;
        this.textBox65.Name = "textBox65";
        this.textBox65.Style = "";
        this.textBox65.Text = "P.Pend inicial";
        this.textBox65.Top = 0.5625F;
        this.textBox65.Width = 0.9375F;
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
        this.textBox66.DataField = "d0_ini_monto_adeuda";
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 3.4375F;
        this.textBox66.Name = "textBox66";
        this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
        this.textBox66.Style = "";
        this.textBox66.SummaryGroup = "groupHeader1";
        this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox66.Text = "textBox66";
        this.textBox66.Top = 0.5625F;
        this.textBox66.Width = 1F;
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
        this.textBox67.DataField = "d1_ini_monto_adeuda";
        this.textBox67.Height = 0.1875F;
        this.textBox67.Left = 4.5F;
        this.textBox67.Name = "textBox67";
        this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
        this.textBox67.Style = "";
        this.textBox67.SummaryGroup = "groupHeader1";
        this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox67.Text = "textBox67";
        this.textBox67.Top = 0.5625F;
        this.textBox67.Width = 1F;
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
        this.textBox68.DataField = "d31_ini_monto_adeuda";
        this.textBox68.Height = 0.1875F;
        this.textBox68.Left = 5.5625F;
        this.textBox68.Name = "textBox68";
        this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
        this.textBox68.Style = "";
        this.textBox68.SummaryGroup = "groupHeader1";
        this.textBox68.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox68.Text = "textBox68";
        this.textBox68.Top = 0.5625F;
        this.textBox68.Width = 1F;
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
        this.textBox69.DataField = "d61_ini_monto_adeuda";
        this.textBox69.Height = 0.1875F;
        this.textBox69.Left = 6.625F;
        this.textBox69.Name = "textBox69";
        this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
        this.textBox69.Style = "";
        this.textBox69.SummaryGroup = "groupHeader1";
        this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox69.Text = "textBox69";
        this.textBox69.Top = 0.5625F;
        this.textBox69.Width = 1F;
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
        this.textBox70.DataField = "d91_ini_monto_adeuda";
        this.textBox70.Height = 0.1875F;
        this.textBox70.Left = 7.6875F;
        this.textBox70.Name = "textBox70";
        this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
        this.textBox70.Style = "";
        this.textBox70.SummaryGroup = "groupHeader1";
        this.textBox70.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox70.Text = "textBox70";
        this.textBox70.Top = 0.5625F;
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
        this.textBox71.DataField = "d121_ini_monto_adeuda";
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 8.75F;
        this.textBox71.Name = "textBox71";
        this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
        this.textBox71.Style = "";
        this.textBox71.SummaryGroup = "groupHeader1";
        this.textBox71.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox71.Text = "textBox71";
        this.textBox71.Top = 0.5625F;
        this.textBox71.Width = 1F;
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
        this.textBox72.DataField = "desp_ini_monto_adeuda";
        this.textBox72.Height = 0.1875F;
        this.textBox72.Left = 9.8125F;
        this.textBox72.Name = "textBox72";
        this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
        this.textBox72.Style = "";
        this.textBox72.SummaryGroup = "groupHeader1";
        this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox72.Text = "textBox72";
        this.textBox72.Top = 0.5625F;
        this.textBox72.Width = 1F;
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
        this.textBox73.DataField = "rev_ini_monto_adeuda";
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 10.875F;
        this.textBox73.Name = "textBox73";
        this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
        this.textBox73.Style = "";
        this.textBox73.SummaryGroup = "groupHeader1";
        this.textBox73.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox73.Text = "textBox73";
        this.textBox73.Top = 0.5625F;
        this.textBox73.Width = 1F;
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
        this.textBox74.DataField = "ini_monto_adeuda";
        this.textBox74.Height = 0.1875F;
        this.textBox74.Left = 11.9375F;
        this.textBox74.Name = "textBox74";
        this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
        this.textBox74.Style = "";
        this.textBox74.SummaryGroup = "groupHeader1";
        this.textBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox74.Text = "textBox74";
        this.textBox74.Top = 0.5625F;
        this.textBox74.Width = 1F;
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
        this.textBox75.Height = 0.1875F;
        this.textBox75.Left = 2.5F;
        this.textBox75.Name = "textBox75";
        this.textBox75.Style = "";
        this.textBox75.Text = "P.Pend final";
        this.textBox75.Top = 0.75F;
        this.textBox75.Width = 0.9375F;
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
        this.textBox76.DataField = "d0_fin_monto_adeuda";
        this.textBox76.Height = 0.1875F;
        this.textBox76.Left = 3.4375F;
        this.textBox76.Name = "textBox76";
        this.textBox76.OutputFormat = resources.GetString("textBox76.OutputFormat");
        this.textBox76.Style = "";
        this.textBox76.SummaryGroup = "groupHeader1";
        this.textBox76.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox76.Text = "textBox76";
        this.textBox76.Top = 0.75F;
        this.textBox76.Width = 1F;
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
        this.textBox77.DataField = "d1_fin_monto_adeuda";
        this.textBox77.Height = 0.1875F;
        this.textBox77.Left = 4.5F;
        this.textBox77.Name = "textBox77";
        this.textBox77.OutputFormat = resources.GetString("textBox77.OutputFormat");
        this.textBox77.Style = "";
        this.textBox77.SummaryGroup = "groupHeader1";
        this.textBox77.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox77.Text = "textBox77";
        this.textBox77.Top = 0.75F;
        this.textBox77.Width = 1F;
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
        this.textBox78.DataField = "d31_fin_monto_adeuda";
        this.textBox78.Height = 0.1875F;
        this.textBox78.Left = 5.5625F;
        this.textBox78.Name = "textBox78";
        this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
        this.textBox78.Style = "";
        this.textBox78.SummaryGroup = "groupHeader1";
        this.textBox78.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox78.Text = "textBox78";
        this.textBox78.Top = 0.75F;
        this.textBox78.Width = 1F;
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
        this.textBox79.DataField = "d61_fin_monto_adeuda";
        this.textBox79.Height = 0.1875F;
        this.textBox79.Left = 6.625F;
        this.textBox79.Name = "textBox79";
        this.textBox79.OutputFormat = resources.GetString("textBox79.OutputFormat");
        this.textBox79.Style = "";
        this.textBox79.SummaryGroup = "groupHeader1";
        this.textBox79.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox79.Text = "textBox79";
        this.textBox79.Top = 0.75F;
        this.textBox79.Width = 1F;
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
        this.textBox80.DataField = "d91_fin_monto_adeuda";
        this.textBox80.Height = 0.1875F;
        this.textBox80.Left = 7.6875F;
        this.textBox80.Name = "textBox80";
        this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
        this.textBox80.Style = "";
        this.textBox80.SummaryGroup = "groupHeader1";
        this.textBox80.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox80.Text = "textBox80";
        this.textBox80.Top = 0.75F;
        this.textBox80.Width = 1F;
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
        this.textBox81.DataField = "d121_fin_monto_adeuda";
        this.textBox81.Height = 0.1875F;
        this.textBox81.Left = 8.75F;
        this.textBox81.Name = "textBox81";
        this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
        this.textBox81.Style = "";
        this.textBox81.SummaryGroup = "groupHeader1";
        this.textBox81.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox81.Text = "textBox81";
        this.textBox81.Top = 0.75F;
        this.textBox81.Width = 1F;
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
        this.textBox82.DataField = "desp_fin_monto_adeuda";
        this.textBox82.Height = 0.1875F;
        this.textBox82.Left = 9.8125F;
        this.textBox82.Name = "textBox82";
        this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
        this.textBox82.Style = "";
        this.textBox82.SummaryGroup = "groupHeader1";
        this.textBox82.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox82.Text = "textBox82";
        this.textBox82.Top = 0.75F;
        this.textBox82.Width = 1F;
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
        this.textBox83.DataField = "rev_fin_monto_adeuda";
        this.textBox83.Height = 0.1875F;
        this.textBox83.Left = 10.875F;
        this.textBox83.Name = "textBox83";
        this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
        this.textBox83.Style = "";
        this.textBox83.SummaryGroup = "groupHeader1";
        this.textBox83.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox83.Text = "textBox83";
        this.textBox83.Top = 0.75F;
        this.textBox83.Width = 1F;
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
        this.textBox84.DataField = "fin_monto_adeuda";
        this.textBox84.Height = 0.1875F;
        this.textBox84.Left = 11.9375F;
        this.textBox84.Name = "textBox84";
        this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
        this.textBox84.Style = "";
        this.textBox84.SummaryGroup = "groupHeader1";
        this.textBox84.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox84.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox84.Text = "textBox84";
        this.textBox84.Top = 0.75F;
        this.textBox84.Width = 1F;
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
        this.textBox85.Height = 0.1875F;
        this.textBox85.Left = 2.5F;
        this.textBox85.Name = "textBox85";
        this.textBox85.Style = "";
        this.textBox85.Text = "Nºcttos inicial";
        this.textBox85.Top = 1.0625F;
        this.textBox85.Width = 0.9375F;
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
        this.textBox86.DataField = "d0_ini_saldo";
        this.textBox86.Height = 0.1875F;
        this.textBox86.Left = 3.4375F;
        this.textBox86.Name = "textBox86";
        this.textBox86.Style = "";
        this.textBox86.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox86.SummaryGroup = "groupHeader1";
        this.textBox86.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox86.Text = "textBox86";
        this.textBox86.Top = 1.0625F;
        this.textBox86.Width = 1F;
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
        this.textBox87.DataField = "d1_ini_saldo";
        this.textBox87.Height = 0.1875F;
        this.textBox87.Left = 4.5F;
        this.textBox87.Name = "textBox87";
        this.textBox87.Style = "";
        this.textBox87.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox87.SummaryGroup = "groupHeader1";
        this.textBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox87.Text = "textBox87";
        this.textBox87.Top = 1.0625F;
        this.textBox87.Width = 1F;
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
        this.textBox88.DataField = "d31_ini_saldo";
        this.textBox88.Height = 0.1875F;
        this.textBox88.Left = 5.5625F;
        this.textBox88.Name = "textBox88";
        this.textBox88.Style = "";
        this.textBox88.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox88.SummaryGroup = "groupHeader1";
        this.textBox88.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox88.Text = "textBox88";
        this.textBox88.Top = 1.0625F;
        this.textBox88.Width = 1F;
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
        this.textBox89.DataField = "d61_ini_saldo";
        this.textBox89.Height = 0.1875F;
        this.textBox89.Left = 6.625F;
        this.textBox89.Name = "textBox89";
        this.textBox89.Style = "";
        this.textBox89.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox89.SummaryGroup = "groupHeader1";
        this.textBox89.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox89.Text = "textBox89";
        this.textBox89.Top = 1.0625F;
        this.textBox89.Width = 1F;
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
        this.textBox90.DataField = "d91_ini_saldo";
        this.textBox90.Height = 0.1875F;
        this.textBox90.Left = 7.6875F;
        this.textBox90.Name = "textBox90";
        this.textBox90.Style = "";
        this.textBox90.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox90.SummaryGroup = "groupHeader1";
        this.textBox90.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox90.Text = "textBox90";
        this.textBox90.Top = 1.0625F;
        this.textBox90.Width = 1F;
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
        this.textBox91.DataField = "d121_ini_saldo";
        this.textBox91.Height = 0.1875F;
        this.textBox91.Left = 8.75F;
        this.textBox91.Name = "textBox91";
        this.textBox91.Style = "";
        this.textBox91.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox91.SummaryGroup = "groupHeader1";
        this.textBox91.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox91.Text = "textBox91";
        this.textBox91.Top = 1.0625F;
        this.textBox91.Width = 1F;
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
        this.textBox92.DataField = "desp_ini_saldo";
        this.textBox92.Height = 0.1875F;
        this.textBox92.Left = 9.8125F;
        this.textBox92.Name = "textBox92";
        this.textBox92.Style = "";
        this.textBox92.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox92.SummaryGroup = "groupHeader1";
        this.textBox92.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox92.Text = "textBox92";
        this.textBox92.Top = 1.0625F;
        this.textBox92.Width = 1F;
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
        this.textBox93.DataField = "rev_ini_saldo";
        this.textBox93.Height = 0.1875F;
        this.textBox93.Left = 10.875F;
        this.textBox93.Name = "textBox93";
        this.textBox93.Style = "";
        this.textBox93.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox93.SummaryGroup = "groupHeader1";
        this.textBox93.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox93.Text = "textBox93";
        this.textBox93.Top = 1.0625F;
        this.textBox93.Width = 1F;
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
        this.textBox94.DataField = "ini_saldo";
        this.textBox94.Height = 0.1875F;
        this.textBox94.Left = 11.9375F;
        this.textBox94.Name = "textBox94";
        this.textBox94.Style = "";
        this.textBox94.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox94.SummaryGroup = "groupHeader1";
        this.textBox94.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox94.Text = "textBox94";
        this.textBox94.Top = 1.0625F;
        this.textBox94.Width = 1F;
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
        this.textBox95.Height = 0.1875F;
        this.textBox95.Left = 2.5F;
        this.textBox95.Name = "textBox95";
        this.textBox95.Style = "";
        this.textBox95.Text = "Nºcttos final";
        this.textBox95.Top = 1.25F;
        this.textBox95.Width = 0.9375F;
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
        this.textBox96.DataField = "d0_fin_saldo";
        this.textBox96.Height = 0.1875F;
        this.textBox96.Left = 3.4375F;
        this.textBox96.Name = "textBox96";
        this.textBox96.Style = "";
        this.textBox96.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox96.SummaryGroup = "groupHeader1";
        this.textBox96.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox96.Text = "textBox96";
        this.textBox96.Top = 1.25F;
        this.textBox96.Width = 1F;
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
        this.textBox97.DataField = "d1_fin_saldo";
        this.textBox97.Height = 0.1875F;
        this.textBox97.Left = 4.5F;
        this.textBox97.Name = "textBox97";
        this.textBox97.Style = "";
        this.textBox97.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox97.SummaryGroup = "groupHeader1";
        this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox97.Text = "textBox97";
        this.textBox97.Top = 1.25F;
        this.textBox97.Width = 1F;
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
        this.textBox98.DataField = "d31_fin_saldo";
        this.textBox98.Height = 0.1875F;
        this.textBox98.Left = 5.5625F;
        this.textBox98.Name = "textBox98";
        this.textBox98.Style = "";
        this.textBox98.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox98.SummaryGroup = "groupHeader1";
        this.textBox98.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox98.Text = "textBox98";
        this.textBox98.Top = 1.25F;
        this.textBox98.Width = 1F;
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
        this.textBox99.DataField = "d61_fin_saldo";
        this.textBox99.Height = 0.1875F;
        this.textBox99.Left = 6.625F;
        this.textBox99.Name = "textBox99";
        this.textBox99.Style = "";
        this.textBox99.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox99.SummaryGroup = "groupHeader1";
        this.textBox99.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox99.Text = "textBox99";
        this.textBox99.Top = 1.25F;
        this.textBox99.Width = 1F;
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
        this.textBox100.DataField = "d91_fin_saldo";
        this.textBox100.Height = 0.1875F;
        this.textBox100.Left = 7.6875F;
        this.textBox100.Name = "textBox100";
        this.textBox100.Style = "";
        this.textBox100.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox100.SummaryGroup = "groupHeader1";
        this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox100.Text = "textBox100";
        this.textBox100.Top = 1.25F;
        this.textBox100.Width = 1F;
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
        this.textBox101.DataField = "d121_fin_saldo";
        this.textBox101.Height = 0.1875F;
        this.textBox101.Left = 8.75F;
        this.textBox101.Name = "textBox101";
        this.textBox101.Style = "";
        this.textBox101.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox101.SummaryGroup = "groupHeader1";
        this.textBox101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox101.Text = "textBox101";
        this.textBox101.Top = 1.25F;
        this.textBox101.Width = 1F;
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
        this.textBox102.DataField = "desp_fin_saldo";
        this.textBox102.Height = 0.1875F;
        this.textBox102.Left = 9.8125F;
        this.textBox102.Name = "textBox102";
        this.textBox102.Style = "";
        this.textBox102.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox102.SummaryGroup = "groupHeader1";
        this.textBox102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox102.Text = "textBox102";
        this.textBox102.Top = 1.25F;
        this.textBox102.Width = 1F;
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
        this.textBox103.DataField = "rev_fin_saldo";
        this.textBox103.Height = 0.1875F;
        this.textBox103.Left = 10.875F;
        this.textBox103.Name = "textBox103";
        this.textBox103.Style = "";
        this.textBox103.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox103.SummaryGroup = "groupHeader1";
        this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox103.Text = "textBox103";
        this.textBox103.Top = 1.25F;
        this.textBox103.Width = 1F;
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
        this.textBox104.DataField = "fin_saldo";
        this.textBox104.Height = 0.1875F;
        this.textBox104.Left = 11.9375F;
        this.textBox104.Name = "textBox104";
        this.textBox104.Style = "";
        this.textBox104.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox104.SummaryGroup = "groupHeader1";
        this.textBox104.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox104.Text = "textBox104";
        this.textBox104.Top = 1.25F;
        this.textBox104.Width = 1F;
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
        this.line4.Height = 1.5F;
        this.line4.Left = 3.4375F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 0F;
        this.line4.X1 = 3.4375F;
        this.line4.X2 = 3.4375F;
        this.line4.Y1 = 1.5F;
        this.line4.Y2 = 0F;
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
        this.line5.Height = 1.5F;
        this.line5.Left = 4.5F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 0F;
        this.line5.X1 = 4.5F;
        this.line5.X2 = 4.5F;
        this.line5.Y1 = 1.5F;
        this.line5.Y2 = 0F;
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
        this.line6.Height = 1.5F;
        this.line6.Left = 5.5625F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0F;
        this.line6.Width = 0F;
        this.line6.X1 = 5.5625F;
        this.line6.X2 = 5.5625F;
        this.line6.Y1 = 1.5F;
        this.line6.Y2 = 0F;
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
        this.line7.Height = 1.5F;
        this.line7.Left = 6.625F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0F;
        this.line7.Width = 0F;
        this.line7.X1 = 6.625F;
        this.line7.X2 = 6.625F;
        this.line7.Y1 = 1.5F;
        this.line7.Y2 = 0F;
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
        this.line8.Height = 1.5F;
        this.line8.Left = 7.6875F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0F;
        this.line8.Width = 0F;
        this.line8.X1 = 7.6875F;
        this.line8.X2 = 7.6875F;
        this.line8.Y1 = 1.5F;
        this.line8.Y2 = 0F;
        // 
        // line9
        // 
        this.line9.Border.BottomColor = System.Drawing.Color.Black;
        this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line9.Border.LeftColor = System.Drawing.Color.Black;
        this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line9.Border.RightColor = System.Drawing.Color.Black;
        this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line9.Border.TopColor = System.Drawing.Color.Black;
        this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line9.Height = 1.5F;
        this.line9.Left = 8.75F;
        this.line9.LineWeight = 1F;
        this.line9.Name = "line9";
        this.line9.Top = 0F;
        this.line9.Width = 0F;
        this.line9.X1 = 8.75F;
        this.line9.X2 = 8.75F;
        this.line9.Y1 = 1.5F;
        this.line9.Y2 = 0F;
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
        this.line10.Height = 1.5F;
        this.line10.Left = 9.8125F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 0F;
        this.line10.Width = 0F;
        this.line10.X1 = 9.8125F;
        this.line10.X2 = 9.8125F;
        this.line10.Y1 = 1.5F;
        this.line10.Y2 = 0F;
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
        this.line11.Height = 1.5F;
        this.line11.Left = 10.875F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 0F;
        this.line11.Width = 0F;
        this.line11.X1 = 10.875F;
        this.line11.X2 = 10.875F;
        this.line11.Y1 = 1.5F;
        this.line11.Y2 = 0F;
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
        this.line12.Height = 1.5F;
        this.line12.Left = 11.9375F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 0F;
        this.line12.Width = 0F;
        this.line12.X1 = 11.9375F;
        this.line12.X2 = 11.9375F;
        this.line12.Y1 = 1.5F;
        this.line12.Y2 = 0F;
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
        this.line13.Height = 1.5F;
        this.line13.Left = 13F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 0F;
        this.line13.Width = 0F;
        this.line13.X1 = 13F;
        this.line13.X2 = 13F;
        this.line13.Y1 = 1.5F;
        this.line13.Y2 = 0F;
        // 
        // line42
        // 
        this.line42.Border.BottomColor = System.Drawing.Color.Black;
        this.line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line42.Border.LeftColor = System.Drawing.Color.Black;
        this.line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line42.Border.RightColor = System.Drawing.Color.Black;
        this.line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line42.Border.TopColor = System.Drawing.Color.Black;
        this.line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line42.Height = 0F;
        this.line42.Left = 2.4375F;
        this.line42.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line42.LineWeight = 1F;
        this.line42.Name = "line42";
        this.line42.Top = 0.5F;
        this.line42.Width = 10.5625F;
        this.line42.X1 = 2.4375F;
        this.line42.X2 = 13F;
        this.line42.Y1 = 0.5F;
        this.line42.Y2 = 0.5F;
        // 
        // line43
        // 
        this.line43.Border.BottomColor = System.Drawing.Color.Black;
        this.line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line43.Border.LeftColor = System.Drawing.Color.Black;
        this.line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line43.Border.RightColor = System.Drawing.Color.Black;
        this.line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line43.Border.TopColor = System.Drawing.Color.Black;
        this.line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line43.Height = 0F;
        this.line43.Left = 2.4375F;
        this.line43.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line43.LineWeight = 1F;
        this.line43.Name = "line43";
        this.line43.Top = 1F;
        this.line43.Width = 10.5625F;
        this.line43.X1 = 2.4375F;
        this.line43.X2 = 13F;
        this.line43.Y1 = 1F;
        this.line43.Y2 = 1F;
        // 
        // shape10
        // 
        this.shape10.Border.BottomColor = System.Drawing.Color.Black;
        this.shape10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape10.Border.LeftColor = System.Drawing.Color.Black;
        this.shape10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape10.Border.RightColor = System.Drawing.Color.Black;
        this.shape10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape10.Border.TopColor = System.Drawing.Color.Black;
        this.shape10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape10.Height = 1.5F;
        this.shape10.Left = 3.4375F;
        this.shape10.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape10.Name = "shape10";
        this.shape10.RoundingRadius = 10F;
        this.shape10.Top = 0F;
        this.shape10.Width = 1.0625F;
        // 
        // shape11
        // 
        this.shape11.Border.BottomColor = System.Drawing.Color.Black;
        this.shape11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape11.Border.LeftColor = System.Drawing.Color.Black;
        this.shape11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape11.Border.RightColor = System.Drawing.Color.Black;
        this.shape11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape11.Border.TopColor = System.Drawing.Color.Black;
        this.shape11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape11.Height = 1.5F;
        this.shape11.Left = 4.5F;
        this.shape11.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape11.Name = "shape11";
        this.shape11.RoundingRadius = 10F;
        this.shape11.Top = 0F;
        this.shape11.Width = 1.0625F;
        // 
        // shape12
        // 
        this.shape12.Border.BottomColor = System.Drawing.Color.Black;
        this.shape12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape12.Border.LeftColor = System.Drawing.Color.Black;
        this.shape12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape12.Border.RightColor = System.Drawing.Color.Black;
        this.shape12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape12.Border.TopColor = System.Drawing.Color.Black;
        this.shape12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape12.Height = 1.5F;
        this.shape12.Left = 5.5625F;
        this.shape12.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape12.Name = "shape12";
        this.shape12.RoundingRadius = 10F;
        this.shape12.Top = 0F;
        this.shape12.Width = 1.0625F;
        // 
        // shape13
        // 
        this.shape13.Border.BottomColor = System.Drawing.Color.Black;
        this.shape13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape13.Border.LeftColor = System.Drawing.Color.Black;
        this.shape13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape13.Border.RightColor = System.Drawing.Color.Black;
        this.shape13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape13.Border.TopColor = System.Drawing.Color.Black;
        this.shape13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape13.Height = 1.5F;
        this.shape13.Left = 6.625F;
        this.shape13.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape13.Name = "shape13";
        this.shape13.RoundingRadius = 10F;
        this.shape13.Top = 0F;
        this.shape13.Width = 1.0625F;
        // 
        // shape14
        // 
        this.shape14.Border.BottomColor = System.Drawing.Color.Black;
        this.shape14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape14.Border.LeftColor = System.Drawing.Color.Black;
        this.shape14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape14.Border.RightColor = System.Drawing.Color.Black;
        this.shape14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape14.Border.TopColor = System.Drawing.Color.Black;
        this.shape14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape14.Height = 1.5F;
        this.shape14.Left = 7.6875F;
        this.shape14.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape14.Name = "shape14";
        this.shape14.RoundingRadius = 10F;
        this.shape14.Top = 0F;
        this.shape14.Width = 1.0625F;
        // 
        // shape15
        // 
        this.shape15.Border.BottomColor = System.Drawing.Color.Black;
        this.shape15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape15.Border.LeftColor = System.Drawing.Color.Black;
        this.shape15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape15.Border.RightColor = System.Drawing.Color.Black;
        this.shape15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape15.Border.TopColor = System.Drawing.Color.Black;
        this.shape15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape15.Height = 1.5F;
        this.shape15.Left = 8.75F;
        this.shape15.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape15.Name = "shape15";
        this.shape15.RoundingRadius = 10F;
        this.shape15.Top = 0F;
        this.shape15.Width = 1.0625F;
        // 
        // shape16
        // 
        this.shape16.Border.BottomColor = System.Drawing.Color.Black;
        this.shape16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape16.Border.LeftColor = System.Drawing.Color.Black;
        this.shape16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape16.Border.RightColor = System.Drawing.Color.Black;
        this.shape16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape16.Border.TopColor = System.Drawing.Color.Black;
        this.shape16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape16.Height = 1.5F;
        this.shape16.Left = 9.8125F;
        this.shape16.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape16.Name = "shape16";
        this.shape16.RoundingRadius = 10F;
        this.shape16.Top = 0F;
        this.shape16.Width = 1.0625F;
        // 
        // shape17
        // 
        this.shape17.Border.BottomColor = System.Drawing.Color.Black;
        this.shape17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape17.Border.LeftColor = System.Drawing.Color.Black;
        this.shape17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape17.Border.RightColor = System.Drawing.Color.Black;
        this.shape17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape17.Border.TopColor = System.Drawing.Color.Black;
        this.shape17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape17.Height = 1.5F;
        this.shape17.Left = 10.875F;
        this.shape17.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape17.Name = "shape17";
        this.shape17.RoundingRadius = 10F;
        this.shape17.Top = 0F;
        this.shape17.Width = 1.0625F;
        // 
        // shape18
        // 
        this.shape18.Border.BottomColor = System.Drawing.Color.Black;
        this.shape18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape18.Border.LeftColor = System.Drawing.Color.Black;
        this.shape18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape18.Border.RightColor = System.Drawing.Color.Black;
        this.shape18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape18.Border.TopColor = System.Drawing.Color.Black;
        this.shape18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape18.Height = 1.5F;
        this.shape18.Left = 11.9375F;
        this.shape18.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
        this.shape18.Name = "shape18";
        this.shape18.RoundingRadius = 10F;
        this.shape18.Top = 0F;
        this.shape18.Width = 1.0625F;
        // 
        // rpt_resumenEvolucion
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 13.01042F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black; ", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic; ", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rpt_resumenEvolucion_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox132)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox133)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox134)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox135)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox136)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox137)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox138)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox139)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox140)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox141)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox142)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox143)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox144)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void reportFooter1_Format(object sender, EventArgs e)
    {
        System.Drawing.Color color_nuevo = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_nuevo"]);
        System.Drawing.Color color_total = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_total"]);
        System.Drawing.Color color_total_general = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_total_general"]);

        shape10.BackColor = color_total;
        shape11.BackColor = color_total;
        shape12.BackColor = color_total;
        shape13.BackColor = color_total;
        shape14.BackColor = color_total;
        shape15.BackColor = color_total;
        shape16.BackColor = color_total;
        shape17.BackColor = color_nuevo;
        shape18.BackColor = color_total_general;
    }

    private void groupFooter1_Format(object sender, EventArgs e)
    {
        System.Drawing.Color color_igual = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_igual"]);
        System.Drawing.Color color_recuperacion = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_recuperacion"]);
        System.Drawing.Color color_mora = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_mora"]);
        System.Drawing.Color color_especial = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_especial"]);
        System.Drawing.Color color_nuevo = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_nuevo"]);
        System.Drawing.Color color_total = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_total"]);
        System.Drawing.Color color_total_general = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_total_general"]);
        
        if (textBox24.Text.Contains("al día") == true)
        {
            shape1.BackColor = color_igual;
            shape2.BackColor = color_mora;
            shape3.BackColor = color_mora;
            shape4.BackColor = color_mora;
            shape5.BackColor = color_mora;
            shape6.BackColor = color_mora;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("1 a 30") == true)
        {
            shape1.BackColor = color_recuperacion;
            shape2.BackColor = color_igual;
            shape3.BackColor = color_mora;
            shape4.BackColor = color_mora;
            shape5.BackColor = color_mora;
            shape6.BackColor = color_mora;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("31 a 60") == true)
        {
            shape1.BackColor = color_recuperacion;
            shape2.BackColor = color_recuperacion;
            shape3.BackColor = color_igual;
            shape4.BackColor = color_mora;
            shape5.BackColor = color_mora;
            shape6.BackColor = color_mora;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("61 a 90") == true)
        {
            shape1.BackColor = color_recuperacion;
            shape2.BackColor = color_recuperacion;
            shape3.BackColor = color_recuperacion;
            shape4.BackColor = color_igual;
            shape5.BackColor = color_mora;
            shape6.BackColor = color_mora;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("91 a 120") == true)
        {
            shape1.BackColor = color_recuperacion;
            shape2.BackColor = color_recuperacion;
            shape3.BackColor = color_recuperacion;
            shape4.BackColor = color_recuperacion;
            shape5.BackColor = color_igual;
            shape6.BackColor = color_mora;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("mayor a 120") == true)
        {
            shape1.BackColor = color_recuperacion;
            shape2.BackColor = color_recuperacion;
            shape3.BackColor = color_recuperacion;
            shape4.BackColor = color_recuperacion;
            shape5.BackColor = color_recuperacion;
            shape6.BackColor = color_igual;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("especial") == true)
        {
            shape1.BackColor = color_especial;
            shape2.BackColor = color_especial;
            shape3.BackColor = color_especial;
            shape4.BackColor = color_especial;
            shape5.BackColor = color_especial;
            shape6.BackColor = color_especial;
            shape7.BackColor = color_especial;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_total;
        }
        else if (textBox24.Text.Contains("vendidos") == true)
        {
            shape1.BackColor = color_nuevo;
            shape2.BackColor = color_nuevo;
            shape3.BackColor = color_nuevo;
            shape4.BackColor = color_nuevo;
            shape5.BackColor = color_nuevo;
            shape6.BackColor = color_nuevo;
            shape7.BackColor = color_nuevo;
            shape8.BackColor = color_nuevo;
            shape9.BackColor = color_nuevo;
        }
        


        if (textBox24.Text.Contains("reac") == false)
        {
            if (decimal.Parse(textBox25.Text) == 0 && decimal.Parse(textBox52.Text) == 0) { textBox25.Text = ""; textBox52.Text = ""; }
            if (decimal.Parse(textBox15.Text) == 0 && decimal.Parse(textBox53.Text) == 0) { textBox15.Text = ""; textBox53.Text = ""; }
            if (decimal.Parse(textBox26.Text) == 0 && decimal.Parse(textBox54.Text) == 0) { textBox26.Text = ""; textBox54.Text = ""; }
            if (decimal.Parse(textBox17.Text) == 0 && decimal.Parse(textBox55.Text) == 0) { textBox17.Text = ""; textBox55.Text = ""; }
            if (decimal.Parse(textBox22.Text) == 0 && decimal.Parse(textBox56.Text) == 0) { textBox22.Text = ""; textBox56.Text = ""; }
            if (decimal.Parse(textBox27.Text) == 0 && decimal.Parse(textBox57.Text) == 0) { textBox27.Text = ""; textBox57.Text = ""; }
            if (decimal.Parse(textBox28.Text) == 0 && decimal.Parse(textBox58.Text) == 0) { textBox28.Text = ""; textBox58.Text = ""; }

            if (decimal.Parse(textBox66.Text) == 0 && decimal.Parse(textBox76.Text) == 0) { textBox66.Text = ""; textBox76.Text = ""; }
            if (decimal.Parse(textBox67.Text) == 0 && decimal.Parse(textBox77.Text) == 0) { textBox67.Text = ""; textBox77.Text = ""; }
            if (decimal.Parse(textBox68.Text) == 0 && decimal.Parse(textBox78.Text) == 0) { textBox68.Text = ""; textBox78.Text = ""; }
            if (decimal.Parse(textBox69.Text) == 0 && decimal.Parse(textBox79.Text) == 0) { textBox69.Text = ""; textBox79.Text = ""; }
            if (decimal.Parse(textBox70.Text) == 0 && decimal.Parse(textBox80.Text) == 0) { textBox70.Text = ""; textBox80.Text = ""; }
            if (decimal.Parse(textBox71.Text) == 0 && decimal.Parse(textBox81.Text) == 0) { textBox71.Text = ""; textBox81.Text = ""; }
            if (decimal.Parse(textBox72.Text) == 0 && decimal.Parse(textBox82.Text) == 0) { textBox72.Text = ""; textBox82.Text = ""; }

            if (int.Parse(textBox86.Text) == 0 && int.Parse(textBox96.Text) == 0) { textBox86.Text = ""; textBox96.Text = ""; }
            if (int.Parse(textBox87.Text) == 0 && int.Parse(textBox97.Text) == 0) { textBox87.Text = ""; textBox97.Text = ""; }
            if (int.Parse(textBox88.Text) == 0 && int.Parse(textBox98.Text) == 0) { textBox88.Text = ""; textBox98.Text = ""; }
            if (int.Parse(textBox89.Text) == 0 && int.Parse(textBox99.Text) == 0) { textBox89.Text = ""; textBox99.Text = ""; }
            if (int.Parse(textBox90.Text) == 0 && int.Parse(textBox100.Text) == 0) { textBox90.Text = ""; textBox100.Text = ""; }
            if (int.Parse(textBox91.Text) == 0 && int.Parse(textBox101.Text) == 0) { textBox91.Text = ""; textBox101.Text = ""; }
            if (int.Parse(textBox92.Text) == 0 && int.Parse(textBox102.Text) == 0) { textBox92.Text = ""; textBox102.Text = ""; }
        }
        else
        {
            if (decimal.Parse(textBox25.Text) == 0) { textBox25.Text = ""; }
            if (decimal.Parse(textBox15.Text) == 0) { textBox15.Text = ""; }
            if (decimal.Parse(textBox26.Text) == 0) { textBox26.Text = ""; }
            if (decimal.Parse(textBox17.Text) == 0) { textBox17.Text = ""; }
            if (decimal.Parse(textBox22.Text) == 0) { textBox22.Text = ""; }
            if (decimal.Parse(textBox27.Text) == 0) { textBox27.Text = ""; }
            if (decimal.Parse(textBox28.Text) == 0) { textBox28.Text = ""; }
            if (decimal.Parse(textBox34.Text) == 0) { textBox34.Text = ""; }

            if (decimal.Parse(textBox66.Text) == 0) { textBox66.Text = ""; }
            if (decimal.Parse(textBox67.Text) == 0) { textBox67.Text = ""; }
            if (decimal.Parse(textBox68.Text) == 0) { textBox68.Text = ""; }
            if (decimal.Parse(textBox69.Text) == 0) { textBox69.Text = ""; }
            if (decimal.Parse(textBox70.Text) == 0) { textBox70.Text = ""; }
            if (decimal.Parse(textBox71.Text) == 0) { textBox71.Text = ""; }
            if (decimal.Parse(textBox72.Text) == 0) { textBox72.Text = ""; }
            if (decimal.Parse(textBox73.Text) == 0) { textBox73.Text = ""; }

            if (int.Parse(textBox86.Text) == 0) { textBox86.Text = ""; }
            if (int.Parse(textBox87.Text) == 0) { textBox87.Text = ""; }
            if (int.Parse(textBox88.Text) == 0) { textBox88.Text = ""; }
            if (int.Parse(textBox89.Text) == 0) { textBox89.Text = ""; }
            if (int.Parse(textBox90.Text) == 0) { textBox90.Text = ""; }
            if (int.Parse(textBox91.Text) == 0) { textBox91.Text = ""; }
            if (int.Parse(textBox92.Text) == 0) { textBox92.Text = ""; }
            if (int.Parse(textBox93.Text) == 0) { textBox93.Text = ""; }
        }

        if (decimal.Parse(textBox59.Text) == 0) { textBox59.Text = ""; }
        if (decimal.Parse(textBox83.Text) == 0) { textBox83.Text = ""; }
        if (int.Parse(textBox103.Text) == 0) { textBox103.Text = ""; }
    }


}
