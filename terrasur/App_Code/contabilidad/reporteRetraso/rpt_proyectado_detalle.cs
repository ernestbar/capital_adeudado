using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_proyectado_detalle.
/// </summary>
public class rpt_proyectado_detalle : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
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
    private Line line1;
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
    private TextBox textBox31;
    private TextBox textBox34;
    private TextBox textBox35;
    private TextBox textBox38;
    private TextBox textBox39;
    private TextBox textBox40;
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
    private TextBox textBox53;
    private TextBox textBox54;
    private TextBox textBox55;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private GroupHeader groupHeader2;
    private GroupFooter groupFooter2;
    private TextBox textBox37;
    private TextBox textBox41;
    private TextBox textBox52;
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
    private GroupHeader groupHeader3;
    private GroupFooter groupFooter3;
    private TextBox textBox72;
    private TextBox textBox73;
    private TextBox textBox74;
    private TextBox textBox75;
    private TextBox textBox76;
    private Line line2;
    private Line line3;
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
    private TextBox textBox145;
    private TextBox textBox146;
    private TextBox textBox147;
    private TextBox textBox148;
    private Line line4;
    private TextBox textBox149;
    private TextBox textBox150;
    private TextBox textBox151;
    private TextBox textBox152;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_proyectado_detalle()
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

    public void CargarEncabezado(string Usuario, DateTime Fecha_inicio, DateTime Fecha_fin, DateTime Ejec_fecha_inicio, DateTime Ejec_fecha_fin, string Negocios, string Moneda, string Consolidado, string Codigo_moneda, string Grupo, string Grupo_original_actual)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox31.Text = "Usuario: " + Usuario;

        textBox6.Text = Fecha_inicio.ToString("d") + " - " + Fecha_fin.ToString("d");
        textBox67.Text = Ejec_fecha_inicio.ToString("d") + " - " + Ejec_fecha_fin.ToString("d");
        textBox7.Text = Negocios;
        textBox19.Text = Moneda;
        textBox21.Text = Consolidado;
        textBox152.Text = Grupo;
        textBox150.Text = Grupo_original_actual;


        textBox39.Text = "Saldo en " + Codigo_moneda;

        textBox14.Text = "Monto de pagos " + Codigo_moneda;
        textBox8.Text = "Monto de pagos " + Codigo_moneda;
        textBox12.Text = "Monto de pagos " + Codigo_moneda;
        textBox34.Text = "Monto de pagos " + Codigo_moneda;
        textBox38.Text = "Monto de pagos " + Codigo_moneda;
        textBox56.Text = "Monto de pagos " + Codigo_moneda;
        textBox112.Text = "Monto de pagos " + Codigo_moneda;
        textBox114.Text = "Monto de pagos " + Codigo_moneda;
    }


    private void rpt_proyectado_detalle_ReportStart(object sender, EventArgs e)
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
        textBox66.ClassName = "estiloEncabEnun";
        textBox67.ClassName = "estiloEncabDato";
        textBox151.ClassName = "estiloEncabEnun";
        textBox152.ClassName = "estiloEncabDato";

        textBox18.ClassName = "estiloEncabEnun";
        textBox19.ClassName = "estiloEncabDato";
        textBox20.ClassName = "estiloEncabEnun";
        textBox21.ClassName = "estiloEncabDato";
        textBox149.ClassName = "estiloEncabEnun";
        textBox150.ClassName = "estiloEncabDato";

        textBox37.ClassName = "estiloGrupoEnun";
        textBox41.ClassName = "estiloGrupoEnun";
        textBox72.ClassName = "estiloGrupoEnun";
        textBox73.ClassName = "estiloGrupoEnun";
        textBox74.ClassName = "estiloGrupoEnun";
        textBox75.ClassName = "estiloGrupoEnun";


        textBox23.ClassName = "estiloDetalleGrupo";
        textBox36.ClassName = "estiloDetalleGrupo";
        textBox57.ClassName = "estiloDetalleGrupo";
        textBox58.ClassName = "estiloDetalleGrupo";
        textBox59.ClassName = "estiloDetalleGrupo";
        textBox60.ClassName = "estiloDetalleGrupo";
        textBox109.ClassName = "estiloDetalleGrupo";
        textBox110.ClassName = "estiloDetalleGrupo";

        textBox5.ClassName = "estiloDetalleEnun";
        textBox45.ClassName = "estiloDetalleEnun";
        textBox39.ClassName = "estiloDetalleEnun";
        textBox68.ClassName = "estiloDetalleEnun";
        textBox69.ClassName = "estiloDetalleEnun";
        textBox70.ClassName = "estiloDetalleEnun";
        textBox71.ClassName = "estiloDetalleEnun";
        textBox10.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox11.ClassName = "estiloDetalleEnun";
        textBox12.ClassName = "estiloDetalleEnun";
        textBox13.ClassName = "estiloDetalleEnun";
        textBox34.ClassName = "estiloDetalleEnun";
        textBox35.ClassName = "estiloDetalleEnun";
        textBox38.ClassName = "estiloDetalleEnun";
        textBox52.ClassName = "estiloDetalleEnun";
        textBox56.ClassName = "estiloDetalleEnun";
        textBox8.ClassName = "estiloDetalleEnun";
        textBox9.ClassName = "estiloDetalleEnun";
        textBox111.ClassName = "estiloDetalleEnun";
        textBox112.ClassName = "estiloDetalleEnun";
        textBox113.ClassName = "estiloDetalleEnun";
        textBox114.ClassName = "estiloDetalleEnun";

        textBox77.ClassName = "estiloDetalleDato";
        textBox78.ClassName = "estiloDetalleDatoString";
        textBox79.ClassName = "estiloDetalleDatoString";
        textBox80.ClassName = "estiloDetalleDato";
        textBox81.ClassName = "estiloDetalleDato";
        textBox82.ClassName = "estiloDetalleDato";
        textBox83.ClassName = "estiloDetalleDato";
        textBox84.ClassName = "estiloDetalleDato";
        textBox85.ClassName = "estiloDetalleDato";
        textBox86.ClassName = "estiloDetalleDato";
        textBox87.ClassName = "estiloDetalleDato";
        textBox88.ClassName = "estiloDetalleDato";
        textBox89.ClassName = "estiloDetalleDato";
        textBox90.ClassName = "estiloDetalleDato";
        textBox91.ClassName = "estiloDetalleDato";
        textBox92.ClassName = "estiloDetalleDato";
        textBox93.ClassName = "estiloDetalleDato";
        textBox94.ClassName = "estiloDetalleDato";
        textBox95.ClassName = "estiloDetalleDato";
        textBox115.ClassName = "estiloDetalleDato";
        textBox116.ClassName = "estiloDetalleDato";
        textBox117.ClassName = "estiloDetalleDato";
        textBox118.ClassName = "estiloDetalleDato";


        textBox16.ClassName = "estiloSubtotalEnun";
        textBox76.ClassName = "estiloSubtotalEnun";
        textBox96.ClassName = "estiloSubtotal";
        textBox97.ClassName = "estiloSubtotal";
        textBox98.ClassName = "estiloSubtotal";
        textBox99.ClassName = "estiloSubtotal";
        textBox100.ClassName = "estiloSubtotal";
        textBox101.ClassName = "estiloSubtotal";
        textBox102.ClassName = "estiloSubtotal";
        textBox103.ClassName = "estiloSubtotal";
        textBox104.ClassName = "estiloSubtotal";
        textBox105.ClassName = "estiloSubtotal";
        textBox106.ClassName = "estiloSubtotal";
        textBox107.ClassName = "estiloSubtotal";
        textBox108.ClassName = "estiloSubtotal";
        textBox119.ClassName = "estiloSubtotal";
        textBox120.ClassName = "estiloSubtotal";
        textBox121.ClassName = "estiloSubtotal";
        textBox122.ClassName = "estiloSubtotal";

        textBox24.ClassName = "estiloSubtotalEnun";
        textBox25.ClassName = "estiloSubtotalEnun";
        textBox46.ClassName = "estiloSubtotal";
        textBox15.ClassName = "estiloSubtotal";
        textBox26.ClassName = "estiloSubtotal";
        textBox17.ClassName = "estiloSubtotal";
        textBox22.ClassName = "estiloSubtotal";
        textBox27.ClassName = "estiloSubtotal";
        textBox28.ClassName = "estiloSubtotal";
        textBox40.ClassName = "estiloSubtotal";
        textBox42.ClassName = "estiloSubtotal";
        textBox43.ClassName = "estiloSubtotal";
        textBox44.ClassName = "estiloSubtotal";
        textBox61.ClassName = "estiloSubtotal";
        textBox62.ClassName = "estiloSubtotal";
        textBox123.ClassName = "estiloSubtotal";
        textBox124.ClassName = "estiloSubtotal";
        textBox125.ClassName = "estiloSubtotal";
        textBox126.ClassName = "estiloSubtotal";

        textBox30.ClassName = "estiloSubtotalEnun";
        textBox65.ClassName = "estiloSubtotalEnun";
        textBox32.ClassName = "estiloSubtotal";
        textBox33.ClassName = "estiloSubtotal";
        textBox29.ClassName = "estiloSubtotal";
        textBox47.ClassName = "estiloSubtotal";
        textBox48.ClassName = "estiloSubtotal";
        textBox49.ClassName = "estiloSubtotal";
        textBox50.ClassName = "estiloSubtotal";
        textBox51.ClassName = "estiloSubtotal";
        textBox53.ClassName = "estiloSubtotal";
        textBox54.ClassName = "estiloSubtotal";
        textBox55.ClassName = "estiloSubtotal";
        textBox63.ClassName = "estiloSubtotal";
        textBox64.ClassName = "estiloSubtotal";
        textBox127.ClassName = "estiloSubtotal";
        textBox128.ClassName = "estiloSubtotal";
        textBox129.ClassName = "estiloSubtotal";
        textBox130.ClassName = "estiloSubtotal";

        textBox131.ClassName = "estiloTotalEnun";
        textBox132.ClassName = "estiloTotal";
        textBox133.ClassName = "estiloTotal";
        textBox134.ClassName = "estiloTotal";
        textBox135.ClassName = "estiloTotal";
        textBox136.ClassName = "estiloTotal";
        textBox137.ClassName = "estiloTotal";
        textBox138.ClassName = "estiloTotal";
        textBox139.ClassName = "estiloTotal";
        textBox140.ClassName = "estiloTotal";
        textBox141.ClassName = "estiloTotal";
        textBox142.ClassName = "estiloTotal";
        textBox143.ClassName = "estiloTotal";
        textBox144.ClassName = "estiloTotal";
        textBox145.ClassName = "estiloTotal";
        textBox146.ClassName = "estiloTotal";
        textBox147.ClassName = "estiloTotal";
        textBox148.ClassName = "estiloTotal";

    
    }


	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_proyectado_detalle));
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
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
        this.textBox59 = new DataDynamics.ActiveReports.TextBox();
        this.textBox60 = new DataDynamics.ActiveReports.TextBox();
        this.textBox68 = new DataDynamics.ActiveReports.TextBox();
        this.textBox69 = new DataDynamics.ActiveReports.TextBox();
        this.textBox70 = new DataDynamics.ActiveReports.TextBox();
        this.textBox71 = new DataDynamics.ActiveReports.TextBox();
        this.textBox109 = new DataDynamics.ActiveReports.TextBox();
        this.textBox110 = new DataDynamics.ActiveReports.TextBox();
        this.textBox111 = new DataDynamics.ActiveReports.TextBox();
        this.textBox112 = new DataDynamics.ActiveReports.TextBox();
        this.textBox113 = new DataDynamics.ActiveReports.TextBox();
        this.textBox114 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
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
        this.textBox118 = new DataDynamics.ActiveReports.TextBox();
        this.textBox116 = new DataDynamics.ActiveReports.TextBox();
        this.textBox117 = new DataDynamics.ActiveReports.TextBox();
        this.textBox115 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox66 = new DataDynamics.ActiveReports.TextBox();
        this.textBox67 = new DataDynamics.ActiveReports.TextBox();
        this.textBox149 = new DataDynamics.ActiveReports.TextBox();
        this.textBox150 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
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
        this.textBox145 = new DataDynamics.ActiveReports.TextBox();
        this.textBox146 = new DataDynamics.ActiveReports.TextBox();
        this.textBox147 = new DataDynamics.ActiveReports.TextBox();
        this.textBox148 = new DataDynamics.ActiveReports.TextBox();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox47 = new DataDynamics.ActiveReports.TextBox();
        this.textBox48 = new DataDynamics.ActiveReports.TextBox();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox50 = new DataDynamics.ActiveReports.TextBox();
        this.textBox51 = new DataDynamics.ActiveReports.TextBox();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox63 = new DataDynamics.ActiveReports.TextBox();
        this.textBox64 = new DataDynamics.ActiveReports.TextBox();
        this.textBox65 = new DataDynamics.ActiveReports.TextBox();
        this.textBox130 = new DataDynamics.ActiveReports.TextBox();
        this.textBox128 = new DataDynamics.ActiveReports.TextBox();
        this.textBox129 = new DataDynamics.ActiveReports.TextBox();
        this.textBox127 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox72 = new DataDynamics.ActiveReports.TextBox();
        this.textBox73 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox61 = new DataDynamics.ActiveReports.TextBox();
        this.textBox62 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.textBox126 = new DataDynamics.ActiveReports.TextBox();
        this.textBox124 = new DataDynamics.ActiveReports.TextBox();
        this.textBox125 = new DataDynamics.ActiveReports.TextBox();
        this.textBox123 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader3 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox74 = new DataDynamics.ActiveReports.TextBox();
        this.textBox75 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter3 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox76 = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.textBox96 = new DataDynamics.ActiveReports.TextBox();
        this.textBox97 = new DataDynamics.ActiveReports.TextBox();
        this.textBox98 = new DataDynamics.ActiveReports.TextBox();
        this.textBox99 = new DataDynamics.ActiveReports.TextBox();
        this.textBox100 = new DataDynamics.ActiveReports.TextBox();
        this.textBox101 = new DataDynamics.ActiveReports.TextBox();
        this.textBox102 = new DataDynamics.ActiveReports.TextBox();
        this.textBox103 = new DataDynamics.ActiveReports.TextBox();
        this.textBox104 = new DataDynamics.ActiveReports.TextBox();
        this.textBox105 = new DataDynamics.ActiveReports.TextBox();
        this.textBox106 = new DataDynamics.ActiveReports.TextBox();
        this.textBox107 = new DataDynamics.ActiveReports.TextBox();
        this.textBox108 = new DataDynamics.ActiveReports.TextBox();
        this.textBox122 = new DataDynamics.ActiveReports.TextBox();
        this.textBox120 = new DataDynamics.ActiveReports.TextBox();
        this.textBox121 = new DataDynamics.ActiveReports.TextBox();
        this.textBox119 = new DataDynamics.ActiveReports.TextBox();
        this.textBox151 = new DataDynamics.ActiveReports.TextBox();
        this.textBox152 = new DataDynamics.ActiveReports.TextBox();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox150)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).BeginInit();
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
            this.textBox34,
            this.textBox35,
            this.textBox38,
            this.textBox39,
            this.textBox45,
            this.textBox52,
            this.textBox56,
            this.textBox57,
            this.textBox58,
            this.textBox59,
            this.textBox60,
            this.textBox68,
            this.textBox69,
            this.textBox70,
            this.textBox71,
            this.textBox109,
            this.textBox110,
            this.textBox111,
            this.textBox112,
            this.textBox113,
            this.textBox114});
        this.pageHeader.Height = 0.6354167F;
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
        this.textBox5.Height = 0.3125F;
        this.textBox5.Left = 0F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "Nº contrato";
        this.textBox5.Top = 0.3125F;
        this.textBox5.Width = 0.6875F;
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
        this.textBox10.Left = 5.5625F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Nro. pagos";
        this.textBox10.Top = 0.3125F;
        this.textBox10.Width = 0.5F;
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
        this.textBox11.Left = 6.875F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Nro. pagos";
        this.textBox11.Top = 0.3125F;
        this.textBox11.Width = 0.5F;
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
        this.textBox12.Left = 11.375F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Monto de pagos $us";
        this.textBox12.Top = 0.3125F;
        this.textBox12.Width = 0.75F;
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
        this.textBox13.Left = 12.125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "Nro. pagos";
        this.textBox13.Top = 0.3125F;
        this.textBox13.Width = 0.5F;
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
        this.textBox8.Left = 7.4375F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Monto de pagos $us";
        this.textBox8.Top = 0.3125F;
        this.textBox8.Width = 0.6875F;
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
        this.textBox9.Left = 10.8125F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "Nro. pagos";
        this.textBox9.Top = 0.3125F;
        this.textBox9.Width = 0.5F;
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
        this.textBox14.Left = 6.125F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Monto de pagos $us";
        this.textBox14.Top = 0.3125F;
        this.textBox14.Width = 0.75F;
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
        this.textBox23.Left = 5.5625F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Pagos pendientes de per. anteriores";
        this.textBox23.Top = 0F;
        this.textBox23.Width = 1.3125F;
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
        this.textBox36.Left = 6.875F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Pagos pendientes del periodo elegido";
        this.textBox36.Top = 0F;
        this.textBox36.Width = 1.3125F;
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
        this.textBox34.Left = 12.6875F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "Monto de pagos $us";
        this.textBox34.Top = 0.3125F;
        this.textBox34.Width = 0.75F;
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
        this.textBox35.Left = 13.4375F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "Nro. pagos";
        this.textBox35.Top = 0.3125F;
        this.textBox35.Width = 0.5F;
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
        this.textBox38.Left = 14F;
        this.textBox38.Name = "textBox38";
        this.textBox38.Style = "";
        this.textBox38.Text = "Monto de pagos $us";
        this.textBox38.Top = 0.3125F;
        this.textBox38.Width = 0.75F;
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
        this.textBox39.Left = 4.5F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "Saldo en $us";
        this.textBox39.Top = 0.3125F;
        this.textBox39.Width = 1F;
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
        this.textBox45.Left = 0.8125F;
        this.textBox45.Name = "textBox45";
        this.textBox45.Style = "";
        this.textBox45.Text = "Mon eda";
        this.textBox45.Top = 0.3125F;
        this.textBox45.Width = 0.375F;
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
        this.textBox52.Left = 14.75F;
        this.textBox52.Name = "textBox52";
        this.textBox52.Style = "";
        this.textBox52.Text = "Nro. pagos";
        this.textBox52.Top = 0.3125F;
        this.textBox52.Width = 0.5F;
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
        this.textBox56.Left = 15.3125F;
        this.textBox56.Name = "textBox56";
        this.textBox56.Style = "";
        this.textBox56.Text = "Monto de pagos $us";
        this.textBox56.Top = 0.3125F;
        this.textBox56.Width = 0.875F;
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
        this.textBox57.Left = 10.8125F;
        this.textBox57.Name = "textBox57";
        this.textBox57.Style = "";
        this.textBox57.Text = "Pagos cobrandos a capital";
        this.textBox57.Top = 0F;
        this.textBox57.Width = 1.3125F;
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
        this.textBox58.Height = 0.3125F;
        this.textBox58.Left = 12.125F;
        this.textBox58.Name = "textBox58";
        this.textBox58.Style = "";
        this.textBox58.Text = "Pagos cobrandos por adelantado";
        this.textBox58.Top = 0F;
        this.textBox58.Width = 1.3125F;
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
        this.textBox59.Height = 0.3125F;
        this.textBox59.Left = 13.4375F;
        this.textBox59.Name = "textBox59";
        this.textBox59.Style = "";
        this.textBox59.Text = "Pagos cobrandos por ventas o react.";
        this.textBox59.Top = 0F;
        this.textBox59.Width = 1.3125F;
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
        this.textBox60.Height = 0.3125F;
        this.textBox60.Left = 14.75F;
        this.textBox60.Name = "textBox60";
        this.textBox60.Style = "";
        this.textBox60.Text = "Pagos cobrados en total";
        this.textBox60.Top = 0F;
        this.textBox60.Width = 1.4375F;
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
        this.textBox68.Height = 0.3125F;
        this.textBox68.Left = 1.3125F;
        this.textBox68.Name = "textBox68";
        this.textBox68.Style = "";
        this.textBox68.Text = "Negocio";
        this.textBox68.Top = 0.3125F;
        this.textBox68.Width = 0.75F;
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
        this.textBox69.Height = 0.3125F;
        this.textBox69.Left = 2.0625F;
        this.textBox69.Name = "textBox69";
        this.textBox69.Style = "";
        this.textBox69.Text = "Fecha de Ult. Pago";
        this.textBox69.Top = 0.3125F;
        this.textBox69.Width = 0.8125F;
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
        this.textBox70.Height = 0.3125F;
        this.textBox70.Left = 2.875F;
        this.textBox70.Name = "textBox70";
        this.textBox70.Style = "";
        this.textBox70.Text = "Fecha de Interés";
        this.textBox70.Top = 0.3125F;
        this.textBox70.Width = 0.8125F;
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
        this.textBox71.Height = 0.3125F;
        this.textBox71.Left = 3.6875F;
        this.textBox71.Name = "textBox71";
        this.textBox71.Style = "";
        this.textBox71.Text = "F.Pago Proyectado";
        this.textBox71.Top = 0.3125F;
        this.textBox71.Width = 0.8125F;
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
        this.textBox109.Height = 0.3125F;
        this.textBox109.Left = 8.1875F;
        this.textBox109.Name = "textBox109";
        this.textBox109.Style = "";
        this.textBox109.Text = "Pagos cobrados de per. anteriores";
        this.textBox109.Top = 0F;
        this.textBox109.Width = 1.3125F;
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
        this.textBox110.Left = 9.5F;
        this.textBox110.Name = "textBox110";
        this.textBox110.Style = "";
        this.textBox110.Text = "Pagos cobrados del periodo elegido";
        this.textBox110.Top = 0F;
        this.textBox110.Width = 1.3125F;
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
        this.textBox111.Height = 0.3125F;
        this.textBox111.Left = 8.1875F;
        this.textBox111.Name = "textBox111";
        this.textBox111.Style = "";
        this.textBox111.Text = "Nro. pagos";
        this.textBox111.Top = 0.3125F;
        this.textBox111.Width = 0.5F;
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
        this.textBox112.Height = 0.3125F;
        this.textBox112.Left = 8.75F;
        this.textBox112.Name = "textBox112";
        this.textBox112.Style = "";
        this.textBox112.Text = "Monto de pagos $us";
        this.textBox112.Top = 0.3125F;
        this.textBox112.Width = 0.75F;
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
        this.textBox113.Height = 0.3125F;
        this.textBox113.Left = 9.5F;
        this.textBox113.Name = "textBox113";
        this.textBox113.Style = "";
        this.textBox113.Text = "Nro. pagos";
        this.textBox113.Top = 0.3125F;
        this.textBox113.Width = 0.5F;
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
        this.textBox114.Height = 0.3125F;
        this.textBox114.Left = 10.0625F;
        this.textBox114.Name = "textBox114";
        this.textBox114.Style = "";
        this.textBox114.Text = "Monto de pagos $us";
        this.textBox114.Top = 0.3125F;
        this.textBox114.Width = 0.75F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.textBox118,
            this.textBox116,
            this.textBox117,
            this.textBox115});
        this.detail.Height = 0.1979167F;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
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
        this.textBox77.DataField = "numero_contrato";
        this.textBox77.Height = 0.1875F;
        this.textBox77.Left = 0.0625F;
        this.textBox77.Name = "textBox77";
        this.textBox77.Style = "";
        this.textBox77.Text = "textBox77";
        this.textBox77.Top = 0F;
        this.textBox77.Width = 0.6875F;
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
        this.textBox78.DataField = "codigo_moneda";
        this.textBox78.Height = 0.1875F;
        this.textBox78.Left = 0.75F;
        this.textBox78.Name = "textBox78";
        this.textBox78.Style = "";
        this.textBox78.Text = "textBox78";
        this.textBox78.Top = 0F;
        this.textBox78.Width = 0.4375F;
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
        this.textBox79.DataField = "negocio";
        this.textBox79.Height = 0.1875F;
        this.textBox79.Left = 1.25F;
        this.textBox79.Name = "textBox79";
        this.textBox79.Style = "";
        this.textBox79.Text = "textBox79";
        this.textBox79.Top = 0F;
        this.textBox79.Width = 0.75F;
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
        this.textBox80.DataField = "fecha_ultimo_pago";
        this.textBox80.Height = 0.1875F;
        this.textBox80.Left = 2.0625F;
        this.textBox80.Name = "textBox80";
        this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
        this.textBox80.Style = "";
        this.textBox80.Text = "textBox80";
        this.textBox80.Top = 0F;
        this.textBox80.Width = 0.8125F;
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
        this.textBox81.DataField = "interes_fecha";
        this.textBox81.Height = 0.1875F;
        this.textBox81.Left = 2.875F;
        this.textBox81.Name = "textBox81";
        this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
        this.textBox81.Style = "";
        this.textBox81.Text = "textBox81";
        this.textBox81.Top = 0F;
        this.textBox81.Width = 0.8125F;
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
        this.textBox82.DataField = "proy_fecha";
        this.textBox82.Height = 0.1875F;
        this.textBox82.Left = 3.6875F;
        this.textBox82.Name = "textBox82";
        this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
        this.textBox82.Style = "";
        this.textBox82.Text = "textBox82";
        this.textBox82.Top = 0F;
        this.textBox82.Width = 0.8125F;
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
        this.textBox83.DataField = "saldo";
        this.textBox83.Height = 0.1875F;
        this.textBox83.Left = 4.5F;
        this.textBox83.Name = "textBox83";
        this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
        this.textBox83.Style = "";
        this.textBox83.Text = "textBox83";
        this.textBox83.Top = 0F;
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
        this.textBox84.DataField = "pend_num";
        this.textBox84.Height = 0.1875F;
        this.textBox84.Left = 5.5625F;
        this.textBox84.Name = "textBox84";
        this.textBox84.Style = "";
        this.textBox84.Text = "textBox84";
        this.textBox84.Top = 0F;
        this.textBox84.Width = 0.5F;
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
        this.textBox85.DataField = "pend_monto";
        this.textBox85.Height = 0.1875F;
        this.textBox85.Left = 6.125F;
        this.textBox85.Name = "textBox85";
        this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
        this.textBox85.Style = "";
        this.textBox85.Text = "textBox85";
        this.textBox85.Top = 0F;
        this.textBox85.Width = 0.75F;
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
        this.textBox86.DataField = "proy_num";
        this.textBox86.Height = 0.1875F;
        this.textBox86.Left = 6.875F;
        this.textBox86.Name = "textBox86";
        this.textBox86.Style = "";
        this.textBox86.Text = "textBox86";
        this.textBox86.Top = 0F;
        this.textBox86.Width = 0.5F;
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
        this.textBox87.DataField = "proy_monto";
        this.textBox87.Height = 0.1875F;
        this.textBox87.Left = 7.4375F;
        this.textBox87.Name = "textBox87";
        this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
        this.textBox87.Style = "";
        this.textBox87.Text = "textBox87";
        this.textBox87.Top = 0F;
        this.textBox87.Width = 0.75F;
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
        this.textBox88.DataField = "eje_cap_num";
        this.textBox88.Height = 0.1875F;
        this.textBox88.Left = 10.8125F;
        this.textBox88.Name = "textBox88";
        this.textBox88.Style = "";
        this.textBox88.Text = "textBox88";
        this.textBox88.Top = 0F;
        this.textBox88.Width = 0.5F;
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
        this.textBox89.DataField = "eje_cap_monto";
        this.textBox89.Height = 0.1875F;
        this.textBox89.Left = 11.375F;
        this.textBox89.Name = "textBox89";
        this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
        this.textBox89.Style = "";
        this.textBox89.Text = "textBox89";
        this.textBox89.Top = 0F;
        this.textBox89.Width = 0.75F;
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
        this.textBox90.DataField = "eje_ade_num";
        this.textBox90.Height = 0.1875F;
        this.textBox90.Left = 12.125F;
        this.textBox90.Name = "textBox90";
        this.textBox90.Style = "";
        this.textBox90.Text = "textBox90";
        this.textBox90.Top = 0F;
        this.textBox90.Width = 0.5F;
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
        this.textBox91.DataField = "eje_ade_monto";
        this.textBox91.Height = 0.1875F;
        this.textBox91.Left = 12.6875F;
        this.textBox91.Name = "textBox91";
        this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
        this.textBox91.Style = "";
        this.textBox91.Text = "textBox91";
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
        this.textBox92.DataField = "eje_nue_num";
        this.textBox92.Height = 0.1875F;
        this.textBox92.Left = 13.4375F;
        this.textBox92.Name = "textBox92";
        this.textBox92.Style = "";
        this.textBox92.Text = "textBox92";
        this.textBox92.Top = 0F;
        this.textBox92.Width = 0.5F;
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
        this.textBox93.DataField = "eje_nue_monto";
        this.textBox93.Height = 0.1875F;
        this.textBox93.Left = 14F;
        this.textBox93.Name = "textBox93";
        this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
        this.textBox93.Style = "";
        this.textBox93.Text = "textBox93";
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
        this.textBox94.DataField = "eje_tot_num";
        this.textBox94.Height = 0.1875F;
        this.textBox94.Left = 14.75F;
        this.textBox94.Name = "textBox94";
        this.textBox94.Style = "";
        this.textBox94.Text = "textBox94";
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
        this.textBox95.DataField = "eje_tot_monto";
        this.textBox95.Height = 0.1875F;
        this.textBox95.Left = 15.3125F;
        this.textBox95.Name = "textBox95";
        this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
        this.textBox95.Style = "";
        this.textBox95.Text = "textBox95";
        this.textBox95.Top = 0F;
        this.textBox95.Width = 0.875F;
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
        this.textBox118.DataField = "eje_proy_monto";
        this.textBox118.Height = 0.1875F;
        this.textBox118.Left = 10.0625F;
        this.textBox118.Name = "textBox118";
        this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
        this.textBox118.Style = "";
        this.textBox118.Text = "textBox118";
        this.textBox118.Top = 0F;
        this.textBox118.Width = 0.75F;
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
        this.textBox116.DataField = "eje_pend_monto";
        this.textBox116.Height = 0.1875F;
        this.textBox116.Left = 8.75F;
        this.textBox116.Name = "textBox116";
        this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
        this.textBox116.Style = "";
        this.textBox116.Text = "textBox116";
        this.textBox116.Top = 0F;
        this.textBox116.Width = 0.75F;
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
        this.textBox117.DataField = "eje_proy_num";
        this.textBox117.Height = 0.1875F;
        this.textBox117.Left = 9.5F;
        this.textBox117.Name = "textBox117";
        this.textBox117.Style = "";
        this.textBox117.Text = "textBox117";
        this.textBox117.Top = 0F;
        this.textBox117.Width = 0.5F;
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
        this.textBox115.DataField = "eje_pend_num";
        this.textBox115.Height = 0.1875F;
        this.textBox115.Left = 8.1875F;
        this.textBox115.Name = "textBox115";
        this.textBox115.Style = "";
        this.textBox115.Text = "textBox115";
        this.textBox115.Top = 0F;
        this.textBox115.Width = 0.5F;
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
        this.textBox24.Left = 0.0625F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "Total:";
        this.textBox24.Top = 0.0625F;
        this.textBox24.Width = 0.6875F;
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
        this.textBox25.DataField = "promotor";
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 0.8125F;
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
        this.textBox25.Style = "";
        this.textBox25.Text = "textBox25";
        this.textBox25.Top = 0.0625F;
        this.textBox25.Width = 3.6875F;
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
        this.textBox17.DataField = "proy_num";
        this.textBox17.Height = 0.1875F;
        this.textBox17.Left = 6.875F;
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
        this.textBox17.Style = "";
        this.textBox17.SummaryGroup = "groupHeader2";
        this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox17.Text = "textBox17";
        this.textBox17.Top = 0.0625F;
        this.textBox17.Width = 0.5F;
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
        this.textBox26.DataField = "pend_monto";
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 6.125F;
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
        this.textBox26.Style = "";
        this.textBox26.SummaryGroup = "groupHeader2";
        this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox26.Text = "textBox26";
        this.textBox26.Top = 0.0625F;
        this.textBox26.Width = 0.75F;
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
        this.textBox22.DataField = "proy_monto";
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 7.4375F;
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
        this.textBox22.Style = "";
        this.textBox22.SummaryGroup = "groupHeader2";
        this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox22.Text = "textBox22";
        this.textBox22.Top = 0.0625F;
        this.textBox22.Width = 0.75F;
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
        this.textBox27.DataField = "eje_cap_num";
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 10.8125F;
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
        this.textBox27.Style = "";
        this.textBox27.SummaryGroup = "groupHeader2";
        this.textBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox27.Text = "textBox27";
        this.textBox27.Top = 0.0625F;
        this.textBox27.Width = 0.5F;
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
        this.textBox28.DataField = "eje_cap_monto";
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 11.375F;
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
        this.textBox28.Style = "";
        this.textBox28.SummaryGroup = "groupHeader2";
        this.textBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox28.Text = "textBox28";
        this.textBox28.Top = 0.0625F;
        this.textBox28.Width = 0.75F;
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
        this.textBox15.DataField = "pend_num";
        this.textBox15.Height = 0.1875F;
        this.textBox15.Left = 5.5625F;
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
        this.textBox15.Style = "";
        this.textBox15.SummaryGroup = "groupHeader2";
        this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox15.Text = "textBox15";
        this.textBox15.Top = 0.0625F;
        this.textBox15.Width = 0.5F;
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
            this.textBox31,
            this.textBox66,
            this.textBox67,
            this.textBox149,
            this.textBox150,
            this.textBox151,
            this.textBox152});
        this.reportHeader1.Height = 1.395833F;
        this.reportHeader1.Name = "reportHeader1";
        this.reportHeader1.Format += new System.EventHandler(this.reportHeader1_Format);
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
        this.textBox1.Left = 10.8125F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = null;
        this.textBox1.Top = 0F;
        this.textBox1.Width = 5.375F;
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
        this.textBox2.Left = 2.0625F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Detalle de proyección y ejecución de cobranza";
        this.textBox2.Top = 0.375F;
        this.textBox2.Width = 11.875F;
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
        this.textBox3.Left = 2.0625F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "Periodo de proyección de pagos:";
        this.textBox3.Top = 0.5625F;
        this.textBox3.Width = 2.4375F;
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
        this.textBox4.Left = 2.0625F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Negocio:";
        this.textBox4.Top = 1.125F;
        this.textBox4.Width = 2.4375F;
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
        this.textBox6.Left = 4.5F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "textBox6";
        this.textBox6.Top = 0.5625F;
        this.textBox6.Width = 2.875F;
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
        this.textBox7.Left = 4.5F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = "textBox7";
        this.textBox7.Top = 1.125F;
        this.textBox7.Width = 8.125F;
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
        this.textBox18.Left = 7.4375F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "MONEDA:";
        this.textBox18.Top = 0.5625F;
        this.textBox18.Width = 2.0625F;
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
        this.textBox19.Left = 9.5F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "textBox19";
        this.textBox19.Top = 0.5625F;
        this.textBox19.Width = 3.125F;
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
        this.textBox20.Left = 7.4375F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "DATOS:";
        this.textBox20.Top = 0.75F;
        this.textBox20.Width = 2.0625F;
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
        this.textBox21.Left = 9.5F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "textBox21";
        this.textBox21.Top = 0.75F;
        this.textBox21.Width = 3.125F;
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
        this.textBox31.Left = 10.8125F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "textBox31";
        this.textBox31.Top = 0.1875F;
        this.textBox31.Width = 5.375F;
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
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 2.0625F;
        this.textBox66.Name = "textBox66";
        this.textBox66.Style = "";
        this.textBox66.Text = "Periodo de cobros realizados:";
        this.textBox66.Top = 0.75F;
        this.textBox66.Width = 2.4375F;
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
        this.textBox67.Height = 0.1875F;
        this.textBox67.Left = 4.5F;
        this.textBox67.Name = "textBox67";
        this.textBox67.Style = "";
        this.textBox67.Text = "textBox67";
        this.textBox67.Top = 0.75F;
        this.textBox67.Width = 2.875F;
        // 
        // textBox149
        // 
        this.textBox149.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox149.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox149.Border.RightColor = System.Drawing.Color.Black;
        this.textBox149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox149.Border.TopColor = System.Drawing.Color.Black;
        this.textBox149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox149.Height = 0.1875F;
        this.textBox149.Left = 7.4375F;
        this.textBox149.Name = "textBox149";
        this.textBox149.Style = "";
        this.textBox149.Text = "Contratos asocidos al:";
        this.textBox149.Top = 0.9375F;
        this.textBox149.Width = 2.0625F;
        // 
        // textBox150
        // 
        this.textBox150.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox150.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox150.Border.RightColor = System.Drawing.Color.Black;
        this.textBox150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox150.Border.TopColor = System.Drawing.Color.Black;
        this.textBox150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox150.Height = 0.1875F;
        this.textBox150.Left = 9.5F;
        this.textBox150.Name = "textBox150";
        this.textBox150.Style = "";
        this.textBox150.Text = "textBox150";
        this.textBox150.Top = 0.9375F;
        this.textBox150.Width = 3.125F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.textBox145,
            this.textBox146,
            this.textBox147,
            this.textBox148,
            this.line4});
        this.reportFooter1.Height = 0.2708333F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.textBox131.Height = 0.1875F;
        this.textBox131.Left = 0.0625F;
        this.textBox131.Name = "textBox131";
        this.textBox131.Style = "";
        this.textBox131.Text = "Total General:";
        this.textBox131.Top = 0.0625F;
        this.textBox131.Width = 4.4375F;
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
        this.textBox132.DataField = "saldo";
        this.textBox132.Height = 0.1979167F;
        this.textBox132.Left = 4.5F;
        this.textBox132.Name = "textBox132";
        this.textBox132.OutputFormat = resources.GetString("textBox132.OutputFormat");
        this.textBox132.Style = "";
        this.textBox132.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox132.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox132.Text = "textBox132";
        this.textBox132.Top = 0.0625F;
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
        this.textBox133.DataField = "pend_num";
        this.textBox133.Height = 0.1875F;
        this.textBox133.Left = 5.5625F;
        this.textBox133.Name = "textBox133";
        this.textBox133.Style = "";
        this.textBox133.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox133.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox133.Text = "textBox133";
        this.textBox133.Top = 0.0625F;
        this.textBox133.Width = 0.5F;
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
        this.textBox134.DataField = "pend_monto";
        this.textBox134.Height = 0.1875F;
        this.textBox134.Left = 6.125F;
        this.textBox134.Name = "textBox134";
        this.textBox134.OutputFormat = resources.GetString("textBox134.OutputFormat");
        this.textBox134.Style = "";
        this.textBox134.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox134.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox134.Text = "textBox134";
        this.textBox134.Top = 0.0625F;
        this.textBox134.Width = 0.75F;
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
        this.textBox135.DataField = "proy_num";
        this.textBox135.Height = 0.1875F;
        this.textBox135.Left = 6.875F;
        this.textBox135.Name = "textBox135";
        this.textBox135.Style = "";
        this.textBox135.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox135.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox135.Text = "textBox135";
        this.textBox135.Top = 0.0625F;
        this.textBox135.Width = 0.5F;
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
        this.textBox136.DataField = "proy_monto";
        this.textBox136.Height = 0.1875F;
        this.textBox136.Left = 7.4375F;
        this.textBox136.Name = "textBox136";
        this.textBox136.OutputFormat = resources.GetString("textBox136.OutputFormat");
        this.textBox136.Style = "";
        this.textBox136.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox136.Text = "textBox136";
        this.textBox136.Top = 0.0625F;
        this.textBox136.Width = 0.75F;
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
        this.textBox137.DataField = "eje_pend_num";
        this.textBox137.Height = 0.1875F;
        this.textBox137.Left = 8.1875F;
        this.textBox137.Name = "textBox137";
        this.textBox137.Style = "";
        this.textBox137.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox137.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox137.Text = "textBox137";
        this.textBox137.Top = 0.0625F;
        this.textBox137.Width = 0.5F;
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
        this.textBox138.DataField = "eje_pend_monto";
        this.textBox138.Height = 0.1875F;
        this.textBox138.Left = 8.75F;
        this.textBox138.Name = "textBox138";
        this.textBox138.OutputFormat = resources.GetString("textBox138.OutputFormat");
        this.textBox138.Style = "";
        this.textBox138.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox138.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox138.Text = "textBox138";
        this.textBox138.Top = 0.0625F;
        this.textBox138.Width = 0.75F;
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
        this.textBox139.DataField = "eje_proy_num";
        this.textBox139.Height = 0.1875F;
        this.textBox139.Left = 9.5F;
        this.textBox139.Name = "textBox139";
        this.textBox139.Style = "";
        this.textBox139.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox139.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox139.Text = "textBox139";
        this.textBox139.Top = 0.0625F;
        this.textBox139.Width = 0.5F;
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
        this.textBox140.DataField = "eje_proy_monto";
        this.textBox140.Height = 0.1875F;
        this.textBox140.Left = 10.0625F;
        this.textBox140.Name = "textBox140";
        this.textBox140.OutputFormat = resources.GetString("textBox140.OutputFormat");
        this.textBox140.Style = "";
        this.textBox140.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox140.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox140.Text = "textBox140";
        this.textBox140.Top = 0.0625F;
        this.textBox140.Width = 0.75F;
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
        this.textBox141.DataField = "eje_cap_num";
        this.textBox141.Height = 0.1875F;
        this.textBox141.Left = 10.8125F;
        this.textBox141.Name = "textBox141";
        this.textBox141.Style = "";
        this.textBox141.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox141.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox141.Text = "textBox141";
        this.textBox141.Top = 0.0625F;
        this.textBox141.Width = 0.5F;
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
        this.textBox142.DataField = "eje_cap_monto";
        this.textBox142.Height = 0.1875F;
        this.textBox142.Left = 11.375F;
        this.textBox142.Name = "textBox142";
        this.textBox142.OutputFormat = resources.GetString("textBox142.OutputFormat");
        this.textBox142.Style = "";
        this.textBox142.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox142.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox142.Text = "textBox142";
        this.textBox142.Top = 0.0625F;
        this.textBox142.Width = 0.75F;
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
        this.textBox143.DataField = "eje_ade_num";
        this.textBox143.Height = 0.1875F;
        this.textBox143.Left = 12.125F;
        this.textBox143.Name = "textBox143";
        this.textBox143.Style = "";
        this.textBox143.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox143.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox143.Text = "textBox143";
        this.textBox143.Top = 0.0625F;
        this.textBox143.Width = 0.5F;
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
        this.textBox144.DataField = "eje_ade_monto";
        this.textBox144.Height = 0.1875F;
        this.textBox144.Left = 12.6875F;
        this.textBox144.Name = "textBox144";
        this.textBox144.OutputFormat = resources.GetString("textBox144.OutputFormat");
        this.textBox144.Style = "";
        this.textBox144.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox144.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox144.Text = "textBox144";
        this.textBox144.Top = 0.0625F;
        this.textBox144.Width = 0.75F;
        // 
        // textBox145
        // 
        this.textBox145.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox145.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox145.Border.RightColor = System.Drawing.Color.Black;
        this.textBox145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox145.Border.TopColor = System.Drawing.Color.Black;
        this.textBox145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox145.DataField = "eje_nue_num";
        this.textBox145.Height = 0.1875F;
        this.textBox145.Left = 13.4375F;
        this.textBox145.Name = "textBox145";
        this.textBox145.Style = "";
        this.textBox145.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox145.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox145.Text = "textBox145";
        this.textBox145.Top = 0.0625F;
        this.textBox145.Width = 0.5F;
        // 
        // textBox146
        // 
        this.textBox146.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox146.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox146.Border.RightColor = System.Drawing.Color.Black;
        this.textBox146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox146.Border.TopColor = System.Drawing.Color.Black;
        this.textBox146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox146.DataField = "eje_nue_monto";
        this.textBox146.Height = 0.1875F;
        this.textBox146.Left = 14F;
        this.textBox146.Name = "textBox146";
        this.textBox146.OutputFormat = resources.GetString("textBox146.OutputFormat");
        this.textBox146.Style = "";
        this.textBox146.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox146.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox146.Text = "textBox146";
        this.textBox146.Top = 0.0625F;
        this.textBox146.Width = 0.75F;
        // 
        // textBox147
        // 
        this.textBox147.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox147.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox147.Border.RightColor = System.Drawing.Color.Black;
        this.textBox147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox147.Border.TopColor = System.Drawing.Color.Black;
        this.textBox147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox147.DataField = "eje_tot_num";
        this.textBox147.Height = 0.1875F;
        this.textBox147.Left = 14.75F;
        this.textBox147.Name = "textBox147";
        this.textBox147.Style = "";
        this.textBox147.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox147.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox147.Text = "textBox147";
        this.textBox147.Top = 0.0625F;
        this.textBox147.Width = 0.5F;
        // 
        // textBox148
        // 
        this.textBox148.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox148.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox148.Border.RightColor = System.Drawing.Color.Black;
        this.textBox148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox148.Border.TopColor = System.Drawing.Color.Black;
        this.textBox148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox148.DataField = "eje_tot_monto";
        this.textBox148.Height = 0.1875F;
        this.textBox148.Left = 15.3125F;
        this.textBox148.Name = "textBox148";
        this.textBox148.OutputFormat = resources.GetString("textBox148.OutputFormat");
        this.textBox148.Style = "";
        this.textBox148.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox148.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox148.Text = "textBox148";
        this.textBox148.Top = 0.0625F;
        this.textBox148.Width = 0.875F;
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
        this.line4.Left = 0.0625F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 16.125F;
        this.line4.X1 = 0.0625F;
        this.line4.X2 = 16.1875F;
        this.line4.Y1 = 0F;
        this.line4.Y2 = 0F;
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
        this.textBox30.Text = "Total:";
        this.textBox30.Top = 0.0625F;
        this.textBox30.Width = 0.6875F;
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
        this.textBox32.DataField = "saldo";
        this.textBox32.Height = 0.1875F;
        this.textBox32.Left = 4.5F;
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
        this.textBox32.Style = "";
        this.textBox32.SummaryGroup = "groupHeader1";
        this.textBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
        this.textBox33.DataField = "pend_num";
        this.textBox33.Height = 0.1875F;
        this.textBox33.Left = 5.5625F;
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
        this.textBox33.Style = "";
        this.textBox33.SummaryGroup = "groupHeader1";
        this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox33.Text = "textBox33";
        this.textBox33.Top = 0.0625F;
        this.textBox33.Width = 0.5F;
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
        this.textBox29.DataField = "pend_monto";
        this.textBox29.Height = 0.1875F;
        this.textBox29.Left = 6.125F;
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
        this.textBox29.Style = "";
        this.textBox29.SummaryGroup = "groupHeader1";
        this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox29.Text = "textBox29";
        this.textBox29.Top = 0.0625F;
        this.textBox29.Width = 0.75F;
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
        this.line1.Top = 0F;
        this.line1.Width = 16.125F;
        this.line1.X1 = 0.0625F;
        this.line1.X2 = 16.1875F;
        this.line1.Y1 = 0F;
        this.line1.Y2 = 0F;
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
        this.textBox16.Left = 0.8125F;
        this.textBox16.Name = "textBox16";
        this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
        this.textBox16.Style = "";
        this.textBox16.Text = "SubTotal:";
        this.textBox16.Top = 0.0625F;
        this.textBox16.Width = 1.1875F;
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
        this.textBox47.DataField = "proy_num";
        this.textBox47.Height = 0.1875F;
        this.textBox47.Left = 6.875F;
        this.textBox47.Name = "textBox47";
        this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
        this.textBox47.Style = "";
        this.textBox47.SummaryGroup = "groupHeader1";
        this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0.0625F;
        this.textBox47.Width = 0.5F;
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
        this.textBox48.DataField = "proy_monto";
        this.textBox48.Height = 0.1875F;
        this.textBox48.Left = 7.4375F;
        this.textBox48.Name = "textBox48";
        this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
        this.textBox48.Style = "";
        this.textBox48.SummaryGroup = "groupHeader1";
        this.textBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox48.Text = "textBox48";
        this.textBox48.Top = 0.0625F;
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
        this.textBox49.DataField = "eje_cap_num";
        this.textBox49.Height = 0.1875F;
        this.textBox49.Left = 10.8125F;
        this.textBox49.Name = "textBox49";
        this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
        this.textBox49.Style = "";
        this.textBox49.SummaryGroup = "groupHeader1";
        this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox49.Text = "textBox49";
        this.textBox49.Top = 0.0625F;
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
        this.textBox50.DataField = "eje_cap_monto";
        this.textBox50.Height = 0.1875F;
        this.textBox50.Left = 11.375F;
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
        this.textBox50.Style = "";
        this.textBox50.SummaryGroup = "groupHeader1";
        this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox50.Text = "textBox50";
        this.textBox50.Top = 0.0625F;
        this.textBox50.Width = 0.75F;
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
        this.textBox51.DataField = "eje_ade_num";
        this.textBox51.Height = 0.1875F;
        this.textBox51.Left = 12.125F;
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
        this.textBox51.Style = "";
        this.textBox51.SummaryGroup = "groupHeader1";
        this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox51.Text = "textBox51";
        this.textBox51.Top = 0.0625F;
        this.textBox51.Width = 0.5F;
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
        this.textBox53.DataField = "eje_ade_monto";
        this.textBox53.Height = 0.1875F;
        this.textBox53.Left = 12.6875F;
        this.textBox53.Name = "textBox53";
        this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
        this.textBox53.Style = "";
        this.textBox53.SummaryGroup = "groupHeader1";
        this.textBox53.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox53.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox53.Text = "textBox53";
        this.textBox53.Top = 0.0625F;
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
        this.textBox54.DataField = "eje_nue_num";
        this.textBox54.Height = 0.1875F;
        this.textBox54.Left = 13.4375F;
        this.textBox54.Name = "textBox54";
        this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
        this.textBox54.Style = "";
        this.textBox54.SummaryGroup = "groupHeader1";
        this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox54.Text = "textBox54";
        this.textBox54.Top = 0.0625F;
        this.textBox54.Width = 0.5F;
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
        this.textBox55.DataField = "eje_nue_monto";
        this.textBox55.Height = 0.1875F;
        this.textBox55.Left = 14F;
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
        this.textBox55.Style = "";
        this.textBox55.SummaryGroup = "groupHeader1";
        this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox55.Text = "textBox55";
        this.textBox55.Top = 0.0625F;
        this.textBox55.Width = 0.75F;
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
        this.textBox40.DataField = "eje_ade_num";
        this.textBox40.Height = 0.1875F;
        this.textBox40.Left = 12.125F;
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
        this.textBox40.Style = "";
        this.textBox40.SummaryGroup = "groupHeader2";
        this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox40.Text = "textBox40";
        this.textBox40.Top = 0.0625F;
        this.textBox40.Width = 0.5F;
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
        this.textBox42.DataField = "eje_ade_monto";
        this.textBox42.Height = 0.1875F;
        this.textBox42.Left = 12.6875F;
        this.textBox42.Name = "textBox42";
        this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
        this.textBox42.Style = "";
        this.textBox42.SummaryGroup = "groupHeader2";
        this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 0.0625F;
        this.textBox42.Width = 0.75F;
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
        this.textBox43.DataField = "eje_nue_num";
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 13.4375F;
        this.textBox43.Name = "textBox43";
        this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
        this.textBox43.Style = "";
        this.textBox43.SummaryGroup = "groupHeader2";
        this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0.0625F;
        this.textBox43.Width = 0.5F;
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
        this.textBox44.DataField = "eje_nue_monto";
        this.textBox44.Height = 0.1875F;
        this.textBox44.Left = 14F;
        this.textBox44.Name = "textBox44";
        this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
        this.textBox44.Style = "";
        this.textBox44.SummaryGroup = "groupHeader2";
        this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 0.0625F;
        this.textBox44.Width = 0.75F;
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
        this.textBox46.DataField = "saldo";
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 4.5F;
        this.textBox46.Name = "textBox46";
        this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
        this.textBox46.Style = "";
        this.textBox46.SummaryGroup = "groupHeader2";
        this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0.0625F;
        this.textBox46.Width = 1F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox37,
            this.textBox41});
        this.groupHeader1.DataField = "grupo";
        this.groupHeader1.Height = 0.2083333F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox37.Left = 0.0625F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "Grupo:";
        this.textBox37.Top = 0F;
        this.textBox37.Width = 0.6875F;
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
        this.textBox41.DataField = "grupo";
        this.textBox41.Height = 0.1875F;
        this.textBox41.Left = 0.8125F;
        this.textBox41.Name = "textBox41";
        this.textBox41.Style = "";
        this.textBox41.Text = "textBox41";
        this.textBox41.Top = 0F;
        this.textBox41.Width = 2.0625F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox30,
            this.textBox32,
            this.textBox33,
            this.textBox29,
            this.textBox47,
            this.textBox48,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.line1,
            this.textBox63,
            this.textBox64,
            this.textBox65,
            this.textBox130,
            this.textBox128,
            this.textBox129,
            this.textBox127});
        this.groupFooter1.Height = 0.2916667F;
        this.groupFooter1.Name = "groupFooter1";
        this.groupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After;
        this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
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
        this.textBox63.DataField = "eje_tot_num";
        this.textBox63.Height = 0.1875F;
        this.textBox63.Left = 14.75F;
        this.textBox63.Name = "textBox63";
        this.textBox63.Style = "";
        this.textBox63.SummaryGroup = "groupHeader1";
        this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox63.Text = "textBox63";
        this.textBox63.Top = 0.0625F;
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
        this.textBox64.DataField = "eje_tot_monto";
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 15.3125F;
        this.textBox64.Name = "textBox64";
        this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
        this.textBox64.Style = "";
        this.textBox64.SummaryGroup = "groupHeader1";
        this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox64.Text = "textBox64";
        this.textBox64.Top = 0.0625F;
        this.textBox64.Width = 0.875F;
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
        this.textBox65.DataField = "grupo";
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 0.8125F;
        this.textBox65.Name = "textBox65";
        this.textBox65.Style = "";
        this.textBox65.Text = "textBox65";
        this.textBox65.Top = 0.0625F;
        this.textBox65.Width = 3.6875F;
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
        this.textBox130.DataField = "eje_proy_monto";
        this.textBox130.Height = 0.1875F;
        this.textBox130.Left = 10.0625F;
        this.textBox130.Name = "textBox130";
        this.textBox130.OutputFormat = resources.GetString("textBox130.OutputFormat");
        this.textBox130.Style = "";
        this.textBox130.SummaryGroup = "groupHeader1";
        this.textBox130.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox130.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox130.Text = "textBox130";
        this.textBox130.Top = 0.0625F;
        this.textBox130.Width = 0.75F;
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
        this.textBox128.DataField = "eje_pend_monto";
        this.textBox128.Height = 0.1875F;
        this.textBox128.Left = 8.75F;
        this.textBox128.Name = "textBox128";
        this.textBox128.OutputFormat = resources.GetString("textBox128.OutputFormat");
        this.textBox128.Style = "";
        this.textBox128.SummaryGroup = "groupHeader1";
        this.textBox128.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox128.Text = "textBox128";
        this.textBox128.Top = 0.0625F;
        this.textBox128.Width = 0.75F;
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
        this.textBox129.DataField = "eje_proy_num";
        this.textBox129.Height = 0.1875F;
        this.textBox129.Left = 9.5F;
        this.textBox129.Name = "textBox129";
        this.textBox129.Style = "";
        this.textBox129.SummaryGroup = "groupHeader1";
        this.textBox129.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox129.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox129.Text = "textBox129";
        this.textBox129.Top = 0.0625F;
        this.textBox129.Width = 0.5F;
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
        this.textBox127.DataField = "eje_pend_num";
        this.textBox127.Height = 0.1875F;
        this.textBox127.Left = 8.1875F;
        this.textBox127.Name = "textBox127";
        this.textBox127.Style = "";
        this.textBox127.SummaryGroup = "groupHeader1";
        this.textBox127.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox127.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox127.Text = "textBox127";
        this.textBox127.Top = 0.0625F;
        this.textBox127.Width = 0.5F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox72,
            this.textBox73});
        this.groupHeader2.DataField = "promotor";
        this.groupHeader2.Height = 0.21875F;
        this.groupHeader2.Name = "groupHeader2";
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
        this.textBox72.Height = 0.1875F;
        this.textBox72.Left = 0.0625F;
        this.textBox72.Name = "textBox72";
        this.textBox72.Style = "";
        this.textBox72.Text = "Promotor:";
        this.textBox72.Top = 0F;
        this.textBox72.Width = 0.6875F;
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
        this.textBox73.DataField = "promotor";
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 0.8125F;
        this.textBox73.Name = "textBox73";
        this.textBox73.Style = "";
        this.textBox73.Text = "textBox73";
        this.textBox73.Top = 0F;
        this.textBox73.Width = 3.6875F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox46,
            this.textBox25,
            this.textBox17,
            this.textBox26,
            this.textBox22,
            this.textBox27,
            this.textBox28,
            this.textBox15,
            this.textBox40,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox24,
            this.textBox61,
            this.textBox62,
            this.line2,
            this.textBox126,
            this.textBox124,
            this.textBox125,
            this.textBox123});
        this.groupFooter2.Height = 0.375F;
        this.groupFooter2.Name = "groupFooter2";
        this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
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
        this.textBox61.DataField = "eje_tot_num";
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 14.75F;
        this.textBox61.Name = "textBox61";
        this.textBox61.Style = "";
        this.textBox61.SummaryGroup = "groupHeader2";
        this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox61.Text = "textBox61";
        this.textBox61.Top = 0.0625F;
        this.textBox61.Width = 0.5F;
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
        this.textBox62.DataField = "eje_tot_monto";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 15.3125F;
        this.textBox62.Name = "textBox62";
        this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
        this.textBox62.Style = "";
        this.textBox62.SummaryGroup = "groupHeader2";
        this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox62.Text = "textBox62";
        this.textBox62.Top = 0.0625F;
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
        this.line2.Left = 0.0625F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0F;
        this.line2.Width = 16.125F;
        this.line2.X1 = 0.0625F;
        this.line2.X2 = 16.1875F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0F;
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
        this.textBox126.DataField = "eje_proy_monto";
        this.textBox126.Height = 0.1875F;
        this.textBox126.Left = 10.0625F;
        this.textBox126.Name = "textBox126";
        this.textBox126.OutputFormat = resources.GetString("textBox126.OutputFormat");
        this.textBox126.Style = "";
        this.textBox126.SummaryGroup = "groupHeader2";
        this.textBox126.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox126.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox126.Text = "textBox126";
        this.textBox126.Top = 0.0625F;
        this.textBox126.Width = 0.75F;
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
        this.textBox124.DataField = "eje_pend_monto";
        this.textBox124.Height = 0.1875F;
        this.textBox124.Left = 8.75F;
        this.textBox124.Name = "textBox124";
        this.textBox124.OutputFormat = resources.GetString("textBox124.OutputFormat");
        this.textBox124.Style = "";
        this.textBox124.SummaryGroup = "groupHeader2";
        this.textBox124.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox124.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox124.Text = "textBox124";
        this.textBox124.Top = 0.0625F;
        this.textBox124.Width = 0.75F;
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
        this.textBox125.DataField = "eje_proy_num";
        this.textBox125.Height = 0.1875F;
        this.textBox125.Left = 9.5F;
        this.textBox125.Name = "textBox125";
        this.textBox125.Style = "";
        this.textBox125.SummaryGroup = "groupHeader2";
        this.textBox125.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox125.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox125.Text = "textBox125";
        this.textBox125.Top = 0.0625F;
        this.textBox125.Width = 0.5F;
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
        this.textBox123.DataField = "eje_pend_num";
        this.textBox123.Height = 0.1875F;
        this.textBox123.Left = 8.1875F;
        this.textBox123.Name = "textBox123";
        this.textBox123.Style = "";
        this.textBox123.SummaryGroup = "groupHeader2";
        this.textBox123.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox123.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox123.Text = "textBox123";
        this.textBox123.Top = 0.0625F;
        this.textBox123.Width = 0.5F;
        // 
        // groupHeader3
        // 
        this.groupHeader3.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox74,
            this.textBox75});
        this.groupHeader3.DataField = "rango";
        this.groupHeader3.Height = 0.25F;
        this.groupHeader3.Name = "groupHeader3";
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
        this.textBox74.Height = 0.1875F;
        this.textBox74.Left = 0.8125F;
        this.textBox74.Name = "textBox74";
        this.textBox74.Style = "";
        this.textBox74.Text = "Rango:";
        this.textBox74.Top = 0F;
        this.textBox74.Width = 1.1875F;
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
        this.textBox75.DataField = "rango";
        this.textBox75.Height = 0.1875F;
        this.textBox75.Left = 2.0625F;
        this.textBox75.Name = "textBox75";
        this.textBox75.Style = "";
        this.textBox75.Text = "textBox75";
        this.textBox75.Top = 0F;
        this.textBox75.Width = 2.4375F;
        // 
        // groupFooter3
        // 
        this.groupFooter3.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox16,
            this.textBox76,
            this.line3,
            this.textBox96,
            this.textBox97,
            this.textBox98,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textBox102,
            this.textBox103,
            this.textBox104,
            this.textBox105,
            this.textBox106,
            this.textBox107,
            this.textBox108,
            this.textBox122,
            this.textBox120,
            this.textBox121,
            this.textBox119});
        this.groupFooter3.Height = 0.3645833F;
        this.groupFooter3.Name = "groupFooter3";
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
        this.textBox76.DataField = "rango";
        this.textBox76.Height = 0.1875F;
        this.textBox76.Left = 2.0625F;
        this.textBox76.Name = "textBox76";
        this.textBox76.Style = "";
        this.textBox76.Text = "textBox76";
        this.textBox76.Top = 0.0625F;
        this.textBox76.Width = 2.4375F;
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
        this.line3.Left = 0.8125F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0F;
        this.line3.Width = 15.375F;
        this.line3.X1 = 0.8125F;
        this.line3.X2 = 16.1875F;
        this.line3.Y1 = 0F;
        this.line3.Y2 = 0F;
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
        this.textBox96.DataField = "saldo";
        this.textBox96.Height = 0.1979167F;
        this.textBox96.Left = 4.5F;
        this.textBox96.Name = "textBox96";
        this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
        this.textBox96.Style = "";
        this.textBox96.SummaryGroup = "groupHeader3";
        this.textBox96.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox96.Text = "textBox96";
        this.textBox96.Top = 0.0625F;
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
        this.textBox97.DataField = "pend_num";
        this.textBox97.Height = 0.1875F;
        this.textBox97.Left = 5.5625F;
        this.textBox97.Name = "textBox97";
        this.textBox97.Style = "";
        this.textBox97.SummaryGroup = "groupHeader3";
        this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox97.Text = "textBox97";
        this.textBox97.Top = 0.0625F;
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
        this.textBox98.DataField = "pend_monto";
        this.textBox98.Height = 0.1875F;
        this.textBox98.Left = 6.125F;
        this.textBox98.Name = "textBox98";
        this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
        this.textBox98.Style = "";
        this.textBox98.SummaryGroup = "groupHeader3";
        this.textBox98.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox98.Text = "textBox98";
        this.textBox98.Top = 0.0625F;
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
        this.textBox99.DataField = "proy_num";
        this.textBox99.Height = 0.1875F;
        this.textBox99.Left = 6.875F;
        this.textBox99.Name = "textBox99";
        this.textBox99.Style = "";
        this.textBox99.SummaryGroup = "groupHeader3";
        this.textBox99.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox99.Text = "textBox99";
        this.textBox99.Top = 0.0625F;
        this.textBox99.Width = 0.5F;
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
        this.textBox100.DataField = "proy_monto";
        this.textBox100.Height = 0.1875F;
        this.textBox100.Left = 7.4375F;
        this.textBox100.Name = "textBox100";
        this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
        this.textBox100.Style = "";
        this.textBox100.SummaryGroup = "groupHeader3";
        this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox100.Text = "textBox100";
        this.textBox100.Top = 0.0625F;
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
        this.textBox101.DataField = "eje_cap_num";
        this.textBox101.Height = 0.1875F;
        this.textBox101.Left = 10.8125F;
        this.textBox101.Name = "textBox101";
        this.textBox101.Style = "";
        this.textBox101.SummaryGroup = "groupHeader3";
        this.textBox101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox101.Text = "textBox101";
        this.textBox101.Top = 0.0625F;
        this.textBox101.Width = 0.5F;
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
        this.textBox102.DataField = "eje_cap_monto";
        this.textBox102.Height = 0.1875F;
        this.textBox102.Left = 11.375F;
        this.textBox102.Name = "textBox102";
        this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
        this.textBox102.Style = "";
        this.textBox102.SummaryGroup = "groupHeader3";
        this.textBox102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox102.Text = "textBox102";
        this.textBox102.Top = 0.0625F;
        this.textBox102.Width = 0.75F;
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
        this.textBox103.DataField = "eje_ade_num";
        this.textBox103.Height = 0.1875F;
        this.textBox103.Left = 12.125F;
        this.textBox103.Name = "textBox103";
        this.textBox103.Style = "";
        this.textBox103.SummaryGroup = "groupHeader3";
        this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox103.Text = "textBox103";
        this.textBox103.Top = 0.0625F;
        this.textBox103.Width = 0.5F;
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
        this.textBox104.DataField = "eje_ade_monto";
        this.textBox104.Height = 0.1875F;
        this.textBox104.Left = 12.6875F;
        this.textBox104.Name = "textBox104";
        this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
        this.textBox104.Style = "";
        this.textBox104.SummaryGroup = "groupHeader3";
        this.textBox104.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox104.Text = "textBox104";
        this.textBox104.Top = 0.0625F;
        this.textBox104.Width = 0.75F;
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
        this.textBox105.DataField = "eje_nue_num";
        this.textBox105.Height = 0.1875F;
        this.textBox105.Left = 13.4375F;
        this.textBox105.Name = "textBox105";
        this.textBox105.Style = "";
        this.textBox105.SummaryGroup = "groupHeader3";
        this.textBox105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox105.Text = "textBox105";
        this.textBox105.Top = 0.0625F;
        this.textBox105.Width = 0.5F;
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
        this.textBox106.DataField = "eje_nue_monto";
        this.textBox106.Height = 0.1875F;
        this.textBox106.Left = 14F;
        this.textBox106.Name = "textBox106";
        this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
        this.textBox106.Style = "";
        this.textBox106.SummaryGroup = "groupHeader3";
        this.textBox106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox106.Text = "textBox106";
        this.textBox106.Top = 0.0625F;
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
        this.textBox107.DataField = "eje_tot_num";
        this.textBox107.Height = 0.1875F;
        this.textBox107.Left = 14.75F;
        this.textBox107.Name = "textBox107";
        this.textBox107.Style = "";
        this.textBox107.SummaryGroup = "groupHeader3";
        this.textBox107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox107.Text = "textBox107";
        this.textBox107.Top = 0.0625F;
        this.textBox107.Width = 0.5F;
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
        this.textBox108.DataField = "eje_tot_monto";
        this.textBox108.Height = 0.1875F;
        this.textBox108.Left = 15.3125F;
        this.textBox108.Name = "textBox108";
        this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
        this.textBox108.Style = "";
        this.textBox108.SummaryGroup = "groupHeader3";
        this.textBox108.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox108.Text = "textBox108";
        this.textBox108.Top = 0.0625F;
        this.textBox108.Width = 0.875F;
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
        this.textBox122.DataField = "eje_proy_monto";
        this.textBox122.Height = 0.1875F;
        this.textBox122.Left = 10.0625F;
        this.textBox122.Name = "textBox122";
        this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
        this.textBox122.Style = "";
        this.textBox122.SummaryGroup = "groupHeader3";
        this.textBox122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox122.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox122.Text = "textBox122";
        this.textBox122.Top = 0.0625F;
        this.textBox122.Width = 0.75F;
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
        this.textBox120.DataField = "eje_pend_monto";
        this.textBox120.Height = 0.1875F;
        this.textBox120.Left = 8.75F;
        this.textBox120.Name = "textBox120";
        this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
        this.textBox120.Style = "";
        this.textBox120.SummaryGroup = "groupHeader3";
        this.textBox120.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox120.Text = "textBox120";
        this.textBox120.Top = 0.0625F;
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
        this.textBox121.DataField = "eje_proy_num";
        this.textBox121.Height = 0.1875F;
        this.textBox121.Left = 9.5F;
        this.textBox121.Name = "textBox121";
        this.textBox121.Style = "";
        this.textBox121.SummaryGroup = "groupHeader3";
        this.textBox121.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox121.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox121.Text = "textBox121";
        this.textBox121.Top = 0.0625F;
        this.textBox121.Width = 0.5F;
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
        this.textBox119.DataField = "eje_pend_num";
        this.textBox119.Height = 0.1875F;
        this.textBox119.Left = 8.1875F;
        this.textBox119.Name = "textBox119";
        this.textBox119.Style = "";
        this.textBox119.SummaryGroup = "groupHeader3";
        this.textBox119.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox119.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox119.Text = "textBox119";
        this.textBox119.Top = 0.0625F;
        this.textBox119.Width = 0.5F;
        // 
        // textBox151
        // 
        this.textBox151.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox151.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox151.Border.RightColor = System.Drawing.Color.Black;
        this.textBox151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox151.Border.TopColor = System.Drawing.Color.Black;
        this.textBox151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox151.Height = 0.1875F;
        this.textBox151.Left = 2.0625F;
        this.textBox151.Name = "textBox151";
        this.textBox151.Style = "";
        this.textBox151.Text = "Grupo:";
        this.textBox151.Top = 0.9375F;
        this.textBox151.Width = 2.4375F;
        // 
        // textBox152
        // 
        this.textBox152.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox152.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox152.Border.RightColor = System.Drawing.Color.Black;
        this.textBox152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox152.Border.TopColor = System.Drawing.Color.Black;
        this.textBox152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox152.Height = 0.1875F;
        this.textBox152.Left = 4.5F;
        this.textBox152.Name = "textBox152";
        this.textBox152.Style = "";
        this.textBox152.Text = "textBox152";
        this.textBox152.Top = 0.9375F;
        this.textBox152.Width = 2.875F;
        // 
        // rpt_proyectado_detalle
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 16.21875F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.groupHeader3);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter3);
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
        this.ReportStart += new System.EventHandler(this.rpt_proyectado_detalle_ReportStart);
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox150)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void reportHeader1_Format(object sender, EventArgs e)
    {

    }

    private void groupFooter2_Format(object sender, EventArgs e)
    {
        //if (decimal.Parse(textBox46.Text) == 0) textBox46.Text = "";
        //if (int.Parse(textBox25.Text) == 0) textBox25.Text = "";

        //if (textBox41.Text.ToLower() != "cobrado")
        //{
        //    if (int.Parse(textBox27.Text) == 0) textBox27.Text = "";
        //    if (decimal.Parse(textBox28.Text) == 0) textBox28.Text = "";
        //    if (int.Parse(textBox40.Text) == 0) textBox40.Text = "";
        //    if (decimal.Parse(textBox42.Text) == 0) textBox42.Text = "";
        //    if (int.Parse(textBox43.Text) == 0) textBox43.Text = "";
        //    if (decimal.Parse(textBox44.Text) == 0) textBox44.Text = "";

        //    if (textBox24.Text.Contains("vendido") == true)
        //    {
        //        if (int.Parse(textBox61.Text) == 0) textBox61.Text = "";
        //        if (decimal.Parse(textBox62.Text) == 0) textBox62.Text = "";
        //    }
        //}

        //if (textBox24.Text.Contains("vendido") == true)
        //{
        //    if (int.Parse(textBox15.Text) == 0) textBox15.Text = "";
        //    if (decimal.Parse(textBox26.Text) == 0) textBox26.Text = "";
        //    if (int.Parse(textBox17.Text) == 0) textBox17.Text = "";
        //    if (decimal.Parse(textBox22.Text) == 0) textBox22.Text = "";
        //}
    }

    private void groupFooter1_Format(object sender, EventArgs e)
    {
        //if (decimal.Parse(textBox32.Text) == 0) textBox32.Text = "";
        //if (int.Parse(textBox16.Text) == 0) textBox16.Text = "";

        //if (int.Parse(textBox49.Text) == 0) textBox49.Text = "";
        //if (decimal.Parse(textBox50.Text) == 0) textBox50.Text = "";
        //if (int.Parse(textBox51.Text) == 0) textBox51.Text = "";
        //if (decimal.Parse(textBox53.Text) == 0) textBox53.Text = "";
        //if (int.Parse(textBox54.Text) == 0) textBox54.Text = "";
        //if (decimal.Parse(textBox55.Text) == 0) textBox55.Text = "";
    }

    private void detail_Format(object sender, EventArgs e)
    {

    }


}
