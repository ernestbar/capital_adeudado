using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_cxc_detalle.
/// </summary>
public class rpt_cxc_detalle : DataDynamics.ActiveReports.ActiveReport3
{
    public void CargarDatos(DateTime Fecha_inicio, string Nombre_negocio, string Moneda, string Consolidado, string Codigo_moneda)
    {
        textBox1.Text = "Fecha de emisi?n: " + DateTime.Now.ToString("F");
        textBox4.Text = Fecha_inicio.ToString("d");
        textBox6.Text = Nombre_negocio;

        textBox80.Text = Moneda;
        textBox82.Text = Consolidado;

        textBox14.Text = "Pagos realizados (" + Codigo_moneda + ")";
        textBox15.Text = "Pagos restantes (" + Codigo_moneda + ")";
        textBox16.Text = "Pagos Total (" + Codigo_moneda + ")";

        textBox20.Text = "Precio final (" + Codigo_moneda + ")";
        textBox22.Text = "Mant. (" + Codigo_moneda + ")";

        textBox29.Text = "Amortiz. (" + Codigo_moneda + ")";
        textBox30.Text = "Seguro (" + Codigo_moneda + ")";
        textBox31.Text = "Mantenim. (" + Codigo_moneda + ")";
        textBox32.Text = "Inter?s (" + Codigo_moneda + ")";
        textBox33.Text = "T.Pagado (" + Codigo_moneda + ")";

        textBox35.Text = "Amortiz. (" + Codigo_moneda + ")";
        textBox36.Text = "Seguro (" + Codigo_moneda + ")";
        textBox37.Text = "Mantenim. (" + Codigo_moneda + ")";
        textBox38.Text = "Inter?s (" + Codigo_moneda + ")";
        textBox39.Text = "T.Restante (" + Codigo_moneda + ")";

        textBox41.Text = "Amortiz (" + Codigo_moneda + ")";
        textBox42.Text = "Seguro (" + Codigo_moneda + ")";
        textBox43.Text = "Mantenim. (" + Codigo_moneda + ")";
        textBox44.Text = "Inter?s (" + Codigo_moneda + ")";
        textBox45.Text = "Total (" + Codigo_moneda + ")";
    }

    private void rpt_cxc_detalle_ReportStart(object sender, EventArgs e)
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
        textBox5.ClassName = "estiloEncabEnun";
        textBox6.ClassName = "estiloEncabDato";

        textBox79.ClassName = "estiloEncabEnun";
        textBox80.ClassName = "estiloEncabDato";
        textBox81.ClassName = "estiloEncabEnun";
        textBox82.ClassName = "estiloEncabDato";
        
        //Report (Enuncado del grupo):
        textBox7.ClassName = "estiloGrupoEnun";
        textBox8.ClassName = "estiloGrupoEnun";
        textBox9.ClassName = "estiloGrupoEnun";
        textBox10.ClassName = "estiloGrupoEnun";
        //Detalle (header):
        textBox11.ClassName = "estiloDetalleGrupo";
        textBox12.ClassName = "estiloDetalleGrupo";
        textBox13.ClassName = "estiloDetalleGrupo";
        textBox14.ClassName = "estiloDetalleGrupo";
        textBox15.ClassName = "estiloDetalleGrupo";
        textBox16.ClassName = "estiloDetalleGrupo";
        //Detalle (enunciado):
        textBox17.ClassName = "estiloDetalleEnun";
        textBox18.ClassName = "estiloDetalleEnun";
        textBox19.ClassName = "estiloDetalleEnun";
        textBox76.ClassName = "estiloDetalleEnun";
        textBox20.ClassName = "estiloDetalleEnun";
        textBox21.ClassName = "estiloDetalleEnun";
        textBox22.ClassName = "estiloDetalleEnun";
        textBox23.ClassName = "estiloDetalleEnun";
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
        //Detalle (datos):
        textBox46.ClassName = "estiloDetalleDatoString";
        textBox47.ClassName = "estiloDetalleDatoString";
        textBox48.ClassName = "estiloDetalleDato";
        textBox77.ClassName = "estiloDetalleDatoString";
        textBox49.ClassName = "estiloDetalleDato";
        textBox50.ClassName = "estiloDetalleDato";
        textBox51.ClassName = "estiloDetalleDato";
        textBox52.ClassName = "estiloDetalleDato";
        textBox54.ClassName = "estiloDetalleDato";
        textBox55.ClassName = "estiloDetalleDato";
        textBox56.ClassName = "estiloDetalleDato";
        textBox57.ClassName = "estiloDetalleDato";
        textBox58.ClassName = "estiloDetalleDato";
        textBox59.ClassName = "estiloDetalleDato";
        textBox60.ClassName = "estiloDetalleDato";
        textBox61.ClassName = "estiloDetalleDato";
        textBox62.ClassName = "estiloDetalleDato";
        textBox63.ClassName = "estiloDetalleDato";
        textBox64.ClassName = "estiloDetalleDato";
        textBox65.ClassName = "estiloDetalleDato";
        textBox66.ClassName = "estiloDetalleDato";
        textBox67.ClassName = "estiloDetalleDato";
        textBox68.ClassName = "estiloDetalleDato";
        textBox69.ClassName = "estiloDetalleDato";
        textBox70.ClassName = "estiloDetalleDato";
        textBox71.ClassName = "estiloDetalleDato";
        textBox72.ClassName = "estiloDetalleDato";
        textBox73.ClassName = "estiloDetalleDato";
        textBox74.ClassName = "estiloDetalleDato";
        //Report (Subtotal):
        textBox24.ClassName = "estiloSubTotalEnun";
        textBox53.ClassName = "estiloSubTotalEnun";
        //78 87-91 93-97 99-103
        textBox78.ClassName = "estiloSubTotal";
        textBox87.ClassName = "estiloSubTotal";
        textBox88.ClassName = "estiloSubTotal";
        textBox89.ClassName = "estiloSubTotal";
        textBox90.ClassName = "estiloSubTotal";
        textBox91.ClassName = "estiloSubTotal";
        textBox93.ClassName = "estiloSubTotal";
        textBox94.ClassName = "estiloSubTotal";
        textBox95.ClassName = "estiloSubTotal";
        textBox96.ClassName = "estiloSubTotal";
        textBox97.ClassName = "estiloSubTotal";
        textBox99.ClassName = "estiloSubTotal";
        textBox100.ClassName = "estiloSubTotal";
        textBox101.ClassName = "estiloSubTotal";
        textBox102.ClassName = "estiloSubTotal";
        textBox103.ClassName = "estiloSubTotal";
        //107 116-120 122-126 128-132
        textBox107.ClassName = "estiloSubTotal";
        textBox116.ClassName = "estiloSubTotal";
        textBox117.ClassName = "estiloSubTotal";
        textBox118.ClassName = "estiloSubTotal";
        textBox119.ClassName = "estiloSubTotal";
        textBox120.ClassName = "estiloSubTotal";
        textBox122.ClassName = "estiloSubTotal";
        textBox123.ClassName = "estiloSubTotal";
        textBox124.ClassName = "estiloSubTotal";
        textBox125.ClassName = "estiloSubTotal";
        textBox126.ClassName = "estiloSubTotal";
        textBox128.ClassName = "estiloSubTotal";
        textBox129.ClassName = "estiloSubTotal";
        textBox130.ClassName = "estiloSubTotal";
        textBox131.ClassName = "estiloSubTotal";
        textBox132.ClassName = "estiloSubTotal";

        //Report (Total):
        textBox75.ClassName = "estiloTotalEnun";
        //136 145-149 151-155 157-161
        textBox136.ClassName = "estiloTotal";
        textBox145.ClassName = "estiloTotal";
        textBox146.ClassName = "estiloTotal";
        textBox147.ClassName = "estiloTotal";
        textBox148.ClassName = "estiloTotal";
        textBox149.ClassName = "estiloTotal";
        textBox151.ClassName = "estiloTotal";
        textBox152.ClassName = "estiloTotal";
        textBox153.ClassName = "estiloTotal";
        textBox154.ClassName = "estiloTotal";
        textBox155.ClassName = "estiloTotal";
        textBox157.ClassName = "estiloTotal";
        textBox158.ClassName = "estiloTotal";
        textBox159.ClassName = "estiloTotal";
        textBox160.ClassName = "estiloTotal";
        textBox161.ClassName = "estiloTotal";

        //Report (footer):
        //Cometario:
    } 

	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private TextBox textBox1;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private GroupHeader groupHeader2;
    private GroupFooter groupFooter2;
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
    private TextBox textBox54;
    private TextBox textBox55;
    private TextBox textBox56;
    private TextBox textBox57;
    private TextBox textBox58;
    private TextBox textBox59;
    private TextBox textBox60;
    private TextBox textBox61;
    private TextBox textBox62;
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
    private TextBox textBox78;
    private TextBox textBox87;
    private TextBox textBox88;
    private TextBox textBox89;
    private TextBox textBox90;
    private TextBox textBox91;
    private TextBox textBox93;
    private TextBox textBox94;
    private TextBox textBox95;
    private TextBox textBox96;
    private TextBox textBox97;
    private TextBox textBox99;
    private TextBox textBox100;
    private TextBox textBox101;
    private TextBox textBox102;
    private TextBox textBox103;
    private TextBox textBox107;
    private TextBox textBox116;
    private TextBox textBox117;
    private TextBox textBox118;
    private TextBox textBox119;
    private TextBox textBox120;
    private TextBox textBox122;
    private TextBox textBox123;
    private TextBox textBox124;
    private TextBox textBox125;
    private TextBox textBox126;
    private TextBox textBox128;
    private TextBox textBox129;
    private TextBox textBox130;
    private TextBox textBox131;
    private TextBox textBox132;
    private TextBox textBox136;
    private TextBox textBox145;
    private TextBox textBox146;
    private TextBox textBox147;
    private TextBox textBox148;
    private TextBox textBox149;
    private TextBox textBox151;
    private TextBox textBox152;
    private TextBox textBox153;
    private TextBox textBox154;
    private TextBox textBox155;
    private TextBox textBox157;
    private TextBox textBox158;
    private TextBox textBox159;
    private TextBox textBox160;
    private TextBox textBox161;
    private TextBox textBox63;
    private Line line2;
    private Line line1;
    private Line line3;
    private TextBox textBox24;
    private TextBox textBox53;
    private TextBox textBox75;
    private Picture picture1;
    private TextBox textBox76;
    private TextBox textBox77;
    private TextBox textBox79;
    private TextBox textBox80;
    private TextBox textBox81;
    private TextBox textBox82;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_cxc_detalle()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_cxc_detalle));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox76 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        this.textBox47 = new DataDynamics.ActiveReports.TextBox();
        this.textBox48 = new DataDynamics.ActiveReports.TextBox();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox50 = new DataDynamics.ActiveReports.TextBox();
        this.textBox51 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox77 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox79 = new DataDynamics.ActiveReports.TextBox();
        this.textBox80 = new DataDynamics.ActiveReports.TextBox();
        this.textBox81 = new DataDynamics.ActiveReports.TextBox();
        this.textBox82 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox136 = new DataDynamics.ActiveReports.TextBox();
        this.textBox145 = new DataDynamics.ActiveReports.TextBox();
        this.textBox146 = new DataDynamics.ActiveReports.TextBox();
        this.textBox147 = new DataDynamics.ActiveReports.TextBox();
        this.textBox148 = new DataDynamics.ActiveReports.TextBox();
        this.textBox149 = new DataDynamics.ActiveReports.TextBox();
        this.textBox151 = new DataDynamics.ActiveReports.TextBox();
        this.textBox152 = new DataDynamics.ActiveReports.TextBox();
        this.textBox153 = new DataDynamics.ActiveReports.TextBox();
        this.textBox154 = new DataDynamics.ActiveReports.TextBox();
        this.textBox155 = new DataDynamics.ActiveReports.TextBox();
        this.textBox157 = new DataDynamics.ActiveReports.TextBox();
        this.textBox158 = new DataDynamics.ActiveReports.TextBox();
        this.textBox159 = new DataDynamics.ActiveReports.TextBox();
        this.textBox160 = new DataDynamics.ActiveReports.TextBox();
        this.textBox161 = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.textBox75 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox107 = new DataDynamics.ActiveReports.TextBox();
        this.textBox116 = new DataDynamics.ActiveReports.TextBox();
        this.textBox117 = new DataDynamics.ActiveReports.TextBox();
        this.textBox118 = new DataDynamics.ActiveReports.TextBox();
        this.textBox119 = new DataDynamics.ActiveReports.TextBox();
        this.textBox120 = new DataDynamics.ActiveReports.TextBox();
        this.textBox122 = new DataDynamics.ActiveReports.TextBox();
        this.textBox123 = new DataDynamics.ActiveReports.TextBox();
        this.textBox124 = new DataDynamics.ActiveReports.TextBox();
        this.textBox125 = new DataDynamics.ActiveReports.TextBox();
        this.textBox126 = new DataDynamics.ActiveReports.TextBox();
        this.textBox128 = new DataDynamics.ActiveReports.TextBox();
        this.textBox129 = new DataDynamics.ActiveReports.TextBox();
        this.textBox130 = new DataDynamics.ActiveReports.TextBox();
        this.textBox131 = new DataDynamics.ActiveReports.TextBox();
        this.textBox132 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox78 = new DataDynamics.ActiveReports.TextBox();
        this.textBox87 = new DataDynamics.ActiveReports.TextBox();
        this.textBox88 = new DataDynamics.ActiveReports.TextBox();
        this.textBox89 = new DataDynamics.ActiveReports.TextBox();
        this.textBox90 = new DataDynamics.ActiveReports.TextBox();
        this.textBox91 = new DataDynamics.ActiveReports.TextBox();
        this.textBox93 = new DataDynamics.ActiveReports.TextBox();
        this.textBox94 = new DataDynamics.ActiveReports.TextBox();
        this.textBox95 = new DataDynamics.ActiveReports.TextBox();
        this.textBox96 = new DataDynamics.ActiveReports.TextBox();
        this.textBox97 = new DataDynamics.ActiveReports.TextBox();
        this.textBox99 = new DataDynamics.ActiveReports.TextBox();
        this.textBox100 = new DataDynamics.ActiveReports.TextBox();
        this.textBox101 = new DataDynamics.ActiveReports.TextBox();
        this.textBox102 = new DataDynamics.ActiveReports.TextBox();
        this.textBox103 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox80)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox81)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox82)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox136)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox153)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox154)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox155)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox157)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox158)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox159)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox160)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox161)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox132)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox87)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox90)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox93)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox94)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox95)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox14,
            this.textBox15,
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
            this.textBox16,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox76});
        this.pageHeader.Height = 0.6041667F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox11.Left = 0.75F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Cliente";
        this.textBox11.Top = 0F;
        this.textBox11.Width = 2.0625F;
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
        this.textBox12.Left = 2.875F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Contrato";
        this.textBox12.Top = 0F;
        this.textBox12.Width = 4.1875F;
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
        this.textBox13.Height = 0.1875F;
        this.textBox13.Left = 7.125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "Lote";
        this.textBox13.Top = 0F;
        this.textBox13.Width = 1.6875F;
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
        this.textBox17.Left = 0.75F;
        this.textBox17.Name = "textBox17";
        this.textBox17.Style = "";
        this.textBox17.Text = "Ap.Paterno";
        this.textBox17.Top = 0.25F;
        this.textBox17.Width = 1F;
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
        this.textBox18.Left = 1.8125F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "Ap.Materno";
        this.textBox18.Top = 0.25F;
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
        this.textBox19.Height = 0.3125F;
        this.textBox19.Left = 2.8125F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "N? contrato";
        this.textBox19.Top = 0.25F;
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
        this.textBox20.Height = 0.3125F;
        this.textBox20.Left = 4.1875F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "Precio final";
        this.textBox20.Top = 0.25F;
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
        this.textBox21.Height = 0.3125F;
        this.textBox21.Left = 5.25F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "Seg.(%)";
        this.textBox21.Top = 0.25F;
        this.textBox21.Width = 0.5625F;
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
        this.textBox22.Left = 5.875F;
        this.textBox22.Name = "textBox22";
        this.textBox22.Style = "";
        this.textBox22.Text = "Mant.($)";
        this.textBox22.Top = 0.25F;
        this.textBox22.Width = 0.5625F;
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
        this.textBox23.Left = 6.5F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Int.(%)";
        this.textBox23.Top = 0.25F;
        this.textBox23.Width = 0.5625F;
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
        this.textBox25.Left = 7.125F;
        this.textBox25.Name = "textBox25";
        this.textBox25.Style = "";
        this.textBox25.Text = "Mzno.";
        this.textBox25.Top = 0.25F;
        this.textBox25.Width = 0.4375F;
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
        this.textBox26.Left = 7.625F;
        this.textBox26.Name = "textBox26";
        this.textBox26.Style = "";
        this.textBox26.Text = "Lote";
        this.textBox26.Top = 0.25F;
        this.textBox26.Width = 0.5F;
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
        this.textBox27.Left = 8.1875F;
        this.textBox27.Name = "textBox27";
        this.textBox27.Style = "";
        this.textBox27.Text = "Sup.";
        this.textBox27.Top = 0.25F;
        this.textBox27.Width = 0.625F;
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
        this.textBox14.Left = 8.875F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Pagos realizados";
        this.textBox14.Top = 0F;
        this.textBox14.Width = 5F;
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
        this.textBox15.Height = 0.1875F;
        this.textBox15.Left = 13.9375F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = "Pagos restantes";
        this.textBox15.Top = 0F;
        this.textBox15.Width = 5F;
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
        this.textBox28.Left = 8.875F;
        this.textBox28.Name = "textBox28";
        this.textBox28.Style = "";
        this.textBox28.Text = "N? cuo.";
        this.textBox28.Top = 0.25F;
        this.textBox28.Width = 0.5F;
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
        this.textBox29.Left = 9.4375F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "";
        this.textBox29.Text = "Amortiz.";
        this.textBox29.Top = 0.25F;
        this.textBox29.Width = 0.9375F;
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
        this.textBox30.Left = 10.4375F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "Seguro";
        this.textBox30.Top = 0.25F;
        this.textBox30.Width = 0.6875F;
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
        this.textBox31.Left = 11.1875F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "Mantenim.";
        this.textBox31.Top = 0.25F;
        this.textBox31.Width = 0.6875F;
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
        this.textBox32.Left = 11.9375F;
        this.textBox32.Name = "textBox32";
        this.textBox32.Style = "";
        this.textBox32.Text = "Inter?s";
        this.textBox32.Top = 0.25F;
        this.textBox32.Width = 0.9375F;
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
        this.textBox33.Left = 12.9375F;
        this.textBox33.Name = "textBox33";
        this.textBox33.Style = "";
        this.textBox33.Text = "T.Pagado";
        this.textBox33.Top = 0.25F;
        this.textBox33.Width = 0.9375F;
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
        this.textBox34.Left = 13.9375F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "N? cuo.";
        this.textBox34.Top = 0.25F;
        this.textBox34.Width = 0.5F;
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
        this.textBox35.Left = 14.5F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "Amortiz.";
        this.textBox35.Top = 0.25F;
        this.textBox35.Width = 0.9375F;
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
        this.textBox36.Left = 15.5F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Seguro";
        this.textBox36.Top = 0.25F;
        this.textBox36.Width = 0.6875F;
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
        this.textBox37.Left = 16.25F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "Mantenim.";
        this.textBox37.Top = 0.25F;
        this.textBox37.Width = 0.6875F;
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
        this.textBox38.Left = 17F;
        this.textBox38.Name = "textBox38";
        this.textBox38.Style = "";
        this.textBox38.Text = "Inter?s";
        this.textBox38.Top = 0.25F;
        this.textBox38.Width = 0.9375F;
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
        this.textBox16.Left = 19F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Pagos Total";
        this.textBox16.Top = 0F;
        this.textBox16.Width = 5F;
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
        this.textBox39.Left = 18F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "T.Restante";
        this.textBox39.Top = 0.25F;
        this.textBox39.Width = 0.9375F;
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
        this.textBox40.Left = 19F;
        this.textBox40.Name = "textBox40";
        this.textBox40.Style = "";
        this.textBox40.Text = "N? cuo.";
        this.textBox40.Top = 0.25F;
        this.textBox40.Width = 0.5F;
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
        this.textBox41.Left = 19.5625F;
        this.textBox41.Name = "textBox41";
        this.textBox41.Style = "";
        this.textBox41.Text = "Amortiz";
        this.textBox41.Top = 0.25F;
        this.textBox41.Width = 0.9375F;
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
        this.textBox42.Left = 20.5625F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "Seguro";
        this.textBox42.Top = 0.25F;
        this.textBox42.Width = 0.6875F;
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
        this.textBox43.Left = 21.3125F;
        this.textBox43.Name = "textBox43";
        this.textBox43.Style = "";
        this.textBox43.Text = "Mantenim.";
        this.textBox43.Top = 0.25F;
        this.textBox43.Width = 0.6875F;
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
        this.textBox44.Left = 22.0625F;
        this.textBox44.Name = "textBox44";
        this.textBox44.Style = "";
        this.textBox44.Text = "Inter?s";
        this.textBox44.Top = 0.25F;
        this.textBox44.Width = 0.9375F;
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
        this.textBox45.Left = 23.0625F;
        this.textBox45.Name = "textBox45";
        this.textBox45.Style = "";
        this.textBox45.Text = "Total";
        this.textBox45.Top = 0.25F;
        this.textBox45.Width = 0.9375F;
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
        this.textBox76.Height = 0.3125F;
        this.textBox76.Left = 3.6875F;
        this.textBox76.Name = "textBox76";
        this.textBox76.Style = "";
        this.textBox76.Text = "Mon eda";
        this.textBox76.Top = 0.25F;
        this.textBox76.Width = 0.4375F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox46,
            this.textBox47,
            this.textBox48,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox52,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
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
            this.textBox77});
        this.detail.Height = 0.21875F;
        this.detail.Name = "detail";
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
        this.textBox46.DataField = "cliente_paterno";
        this.textBox46.Height = 0.1979167F;
        this.textBox46.Left = 0.75F;
        this.textBox46.Name = "textBox46";
        this.textBox46.Style = "";
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0F;
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
        this.textBox47.DataField = "cliente_materno";
        this.textBox47.Height = 0.1979167F;
        this.textBox47.Left = 1.8125F;
        this.textBox47.Name = "textBox47";
        this.textBox47.Style = "";
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0F;
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
        this.textBox48.DataField = "numero";
        this.textBox48.Height = 0.1875F;
        this.textBox48.Left = 2.875F;
        this.textBox48.Name = "textBox48";
        this.textBox48.Style = "";
        this.textBox48.Text = "textBox48";
        this.textBox48.Top = 0F;
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
        this.textBox49.DataField = "precio_final";
        this.textBox49.Height = 0.1875F;
        this.textBox49.Left = 4.1875F;
        this.textBox49.Name = "textBox49";
        this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
        this.textBox49.Style = "";
        this.textBox49.Text = "textBox49";
        this.textBox49.Top = 0F;
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
        this.textBox50.DataField = "seguro";
        this.textBox50.Height = 0.1875F;
        this.textBox50.Left = 5.25F;
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
        this.textBox50.Style = "";
        this.textBox50.Text = "textBox50";
        this.textBox50.Top = 0F;
        this.textBox50.Width = 0.5625F;
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
        this.textBox51.DataField = "mantenimiento_sus";
        this.textBox51.Height = 0.1875F;
        this.textBox51.Left = 5.875F;
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
        this.textBox51.Style = "";
        this.textBox51.Text = "textBox51";
        this.textBox51.Top = 0F;
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
        this.textBox52.DataField = "interes_corriente";
        this.textBox52.Height = 0.1875F;
        this.textBox52.Left = 6.4375F;
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
        this.textBox52.Style = "";
        this.textBox52.Text = "textBox52";
        this.textBox52.Top = 0F;
        this.textBox52.Width = 0.5625F;
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
        this.textBox54.DataField = "manzano";
        this.textBox54.Height = 0.1875F;
        this.textBox54.Left = 7.0625F;
        this.textBox54.Name = "textBox54";
        this.textBox54.Style = "";
        this.textBox54.Text = "textBox54";
        this.textBox54.Top = 0F;
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
        this.textBox55.DataField = "lote";
        this.textBox55.Height = 0.1875F;
        this.textBox55.Left = 7.625F;
        this.textBox55.Name = "textBox55";
        this.textBox55.Style = "";
        this.textBox55.Text = "textBox55";
        this.textBox55.Top = 0F;
        this.textBox55.Width = 0.4375F;
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
        this.textBox56.DataField = "superficie_m2";
        this.textBox56.Height = 0.1875F;
        this.textBox56.Left = 8.1875F;
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
        this.textBox56.Style = "";
        this.textBox56.Text = "textBox56";
        this.textBox56.Top = 0F;
        this.textBox56.Width = 0.5625F;
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
        this.textBox57.DataField = "realizado_num_cuotas";
        this.textBox57.Height = 0.1875F;
        this.textBox57.Left = 8.875F;
        this.textBox57.Name = "textBox57";
        this.textBox57.Style = "";
        this.textBox57.Text = "textBox57";
        this.textBox57.Top = 0F;
        this.textBox57.Width = 0.5F;
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
        this.textBox58.DataField = "realizado_amortizacion";
        this.textBox58.Height = 0.1875F;
        this.textBox58.Left = 9.4375F;
        this.textBox58.Name = "textBox58";
        this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
        this.textBox58.Style = "";
        this.textBox58.Text = "textBox58";
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
        this.textBox59.DataField = "realizado_seguro";
        this.textBox59.Height = 0.1875F;
        this.textBox59.Left = 10.4375F;
        this.textBox59.Name = "textBox59";
        this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
        this.textBox59.Style = "";
        this.textBox59.Text = "textBox59";
        this.textBox59.Top = 0F;
        this.textBox59.Width = 0.6875F;
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
        this.textBox60.DataField = "realizado_mantenimiento";
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 11.1875F;
        this.textBox60.Name = "textBox60";
        this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
        this.textBox60.Style = "";
        this.textBox60.Text = "textBox60";
        this.textBox60.Top = 0F;
        this.textBox60.Width = 0.6875F;
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
        this.textBox61.DataField = "realizado_interes";
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 11.9375F;
        this.textBox61.Name = "textBox61";
        this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
        this.textBox61.Style = "";
        this.textBox61.Text = "textBox61";
        this.textBox61.Top = 0F;
        this.textBox61.Width = 0.9375F;
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
        this.textBox62.DataField = "realizado_total";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 12.9375F;
        this.textBox62.Name = "textBox62";
        this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
        this.textBox62.Style = "";
        this.textBox62.Text = "textBox62";
        this.textBox62.Top = 0F;
        this.textBox62.Width = 0.9375F;
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
        this.textBox63.DataField = "restante_num_cuotas";
        this.textBox63.Height = 0.1875F;
        this.textBox63.Left = 13.9375F;
        this.textBox63.Name = "textBox63";
        this.textBox63.Style = "";
        this.textBox63.Text = "textBox63";
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
        this.textBox64.DataField = "restante_amortizacion";
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 14.5F;
        this.textBox64.Name = "textBox64";
        this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
        this.textBox64.Style = "";
        this.textBox64.Text = "textBox64";
        this.textBox64.Top = 0F;
        this.textBox64.Width = 0.9375F;
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
        this.textBox65.DataField = "restante_seguro";
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 15.5F;
        this.textBox65.Name = "textBox65";
        this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
        this.textBox65.Style = "";
        this.textBox65.Text = "textBox65";
        this.textBox65.Top = 0F;
        this.textBox65.Width = 0.6875F;
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
        this.textBox66.DataField = "restante_mantenimiento";
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 16.25F;
        this.textBox66.Name = "textBox66";
        this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
        this.textBox66.Style = "";
        this.textBox66.Text = "textBox66";
        this.textBox66.Top = 0F;
        this.textBox66.Width = 0.6875F;
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
        this.textBox67.DataField = "restante_interes";
        this.textBox67.Height = 0.1875F;
        this.textBox67.Left = 17F;
        this.textBox67.Name = "textBox67";
        this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
        this.textBox67.Style = "";
        this.textBox67.Text = "textBox67";
        this.textBox67.Top = 0F;
        this.textBox67.Width = 0.9375F;
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
        this.textBox68.DataField = "restante_total";
        this.textBox68.Height = 0.1875F;
        this.textBox68.Left = 18F;
        this.textBox68.Name = "textBox68";
        this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
        this.textBox68.Style = "";
        this.textBox68.Text = "textBox68";
        this.textBox68.Top = 0F;
        this.textBox68.Width = 0.9375F;
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
        this.textBox69.DataField = "total_num_cuotas";
        this.textBox69.Height = 0.1875F;
        this.textBox69.Left = 19F;
        this.textBox69.Name = "textBox69";
        this.textBox69.Style = "";
        this.textBox69.Text = "textBox69";
        this.textBox69.Top = 0F;
        this.textBox69.Width = 0.5F;
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
        this.textBox70.DataField = "total_precio";
        this.textBox70.Height = 0.1875F;
        this.textBox70.Left = 19.5625F;
        this.textBox70.Name = "textBox70";
        this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
        this.textBox70.Style = "";
        this.textBox70.Text = "textBox70";
        this.textBox70.Top = 0F;
        this.textBox70.Width = 0.9375F;
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
        this.textBox71.DataField = "total_seguro";
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 20.5625F;
        this.textBox71.Name = "textBox71";
        this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
        this.textBox71.Style = "";
        this.textBox71.Text = "textBox71";
        this.textBox71.Top = 0F;
        this.textBox71.Width = 0.6875F;
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
        this.textBox72.DataField = "total_mantenimiento";
        this.textBox72.Height = 0.1875F;
        this.textBox72.Left = 21.3125F;
        this.textBox72.Name = "textBox72";
        this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
        this.textBox72.Style = "";
        this.textBox72.Text = "textBox72";
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
        this.textBox73.DataField = "total_interes";
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 22.0625F;
        this.textBox73.Name = "textBox73";
        this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
        this.textBox73.Style = "";
        this.textBox73.Text = "textBox73";
        this.textBox73.Top = 0F;
        this.textBox73.Width = 0.9375F;
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
        this.textBox74.DataField = "total_total";
        this.textBox74.Height = 0.1875F;
        this.textBox74.Left = 23.0625F;
        this.textBox74.Name = "textBox74";
        this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
        this.textBox74.Style = "";
        this.textBox74.Text = "textBox74";
        this.textBox74.Top = 0F;
        this.textBox74.Width = 0.9375F;
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
        this.textBox77.DataField = "codigo_moneda";
        this.textBox77.Height = 0.1875F;
        this.textBox77.Left = 3.6875F;
        this.textBox77.Name = "textBox77";
        this.textBox77.Style = "";
        this.textBox77.Text = "textBox77";
        this.textBox77.Top = 0F;
        this.textBox77.Width = 0.4375F;
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
            this.picture1,
            this.textBox79,
            this.textBox80,
            this.textBox81,
            this.textBox82});
        this.reportHeader1.Height = 1.322917F;
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
        this.textBox1.Left = 19.5625F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "textBox1";
        this.textBox1.Top = 0.0625F;
        this.textBox1.Width = 4.4375F;
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
        this.textBox2.Left = 0.0625F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Cuentas por Cobrar (detalle)";
        this.textBox2.Top = 0.3125F;
        this.textBox2.Width = 23.9375F;
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
        this.textBox3.Left = 10.4375F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "A la fecha:";
        this.textBox3.Top = 0.5F;
        this.textBox3.Width = 1.4375F;
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
        this.textBox4.Left = 11.9375F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "textBox4";
        this.textBox4.Top = 0.5F;
        this.textBox4.Width = 4.25F;
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
        this.textBox5.Left = 10.4375F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "Negocio:";
        this.textBox5.Top = 0.6875F;
        this.textBox5.Width = 1.4375F;
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
        this.textBox6.Left = 11.9375F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "textBox6";
        this.textBox6.Top = 0.6875F;
        this.textBox6.Width = 4.25F;
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
        this.textBox79.Height = 0.1875F;
        this.textBox79.Left = 10.4375F;
        this.textBox79.Name = "textBox79";
        this.textBox79.Style = "";
        this.textBox79.Text = "MONEDA:";
        this.textBox79.Top = 0.875F;
        this.textBox79.Width = 1.4375F;
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
        this.textBox80.Height = 0.1875F;
        this.textBox80.Left = 11.9375F;
        this.textBox80.Name = "textBox80";
        this.textBox80.Style = "";
        this.textBox80.Text = "textBox80";
        this.textBox80.Top = 0.875F;
        this.textBox80.Width = 4.25F;
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
        this.textBox81.Height = 0.1875F;
        this.textBox81.Left = 10.4375F;
        this.textBox81.Name = "textBox81";
        this.textBox81.Style = "";
        this.textBox81.Text = "DATOS:";
        this.textBox81.Top = 1.0625F;
        this.textBox81.Width = 1.4375F;
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
        this.textBox82.Height = 0.1875F;
        this.textBox82.Left = 11.9375F;
        this.textBox82.Name = "textBox82";
        this.textBox82.Style = "";
        this.textBox82.Text = "textBox82";
        this.textBox82.Top = 1.0625F;
        this.textBox82.Width = 4.25F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox136,
            this.textBox145,
            this.textBox146,
            this.textBox147,
            this.textBox148,
            this.textBox149,
            this.textBox151,
            this.textBox152,
            this.textBox153,
            this.textBox154,
            this.textBox155,
            this.textBox157,
            this.textBox158,
            this.textBox159,
            this.textBox160,
            this.textBox161,
            this.line3,
            this.textBox75});
        this.reportFooter1.Height = 0.3645833F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.textBox136.DataField = "precio_final";
        this.textBox136.Height = 0.1875F;
        this.textBox136.Left = 4.1875F;
        this.textBox136.Name = "textBox136";
        this.textBox136.OutputFormat = resources.GetString("textBox136.OutputFormat");
        this.textBox136.Style = "";
        this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox136.Text = "textBox136";
        this.textBox136.Top = 0.125F;
        this.textBox136.Width = 1F;
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
        this.textBox145.DataField = "realizado_amortizacion";
        this.textBox145.Height = 0.1875F;
        this.textBox145.Left = 9.4375F;
        this.textBox145.Name = "textBox145";
        this.textBox145.OutputFormat = resources.GetString("textBox145.OutputFormat");
        this.textBox145.Style = "";
        this.textBox145.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox145.Text = "textBox145";
        this.textBox145.Top = 0.125F;
        this.textBox145.Width = 0.9375F;
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
        this.textBox146.DataField = "realizado_seguro";
        this.textBox146.Height = 0.1875F;
        this.textBox146.Left = 10.4375F;
        this.textBox146.Name = "textBox146";
        this.textBox146.OutputFormat = resources.GetString("textBox146.OutputFormat");
        this.textBox146.Style = "";
        this.textBox146.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox146.Text = "textBox146";
        this.textBox146.Top = 0.125F;
        this.textBox146.Width = 0.6875F;
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
        this.textBox147.DataField = "realizado_mantenimiento";
        this.textBox147.Height = 0.1875F;
        this.textBox147.Left = 11.1875F;
        this.textBox147.Name = "textBox147";
        this.textBox147.OutputFormat = resources.GetString("textBox147.OutputFormat");
        this.textBox147.Style = "";
        this.textBox147.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox147.Text = "textBox147";
        this.textBox147.Top = 0.125F;
        this.textBox147.Width = 0.6875F;
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
        this.textBox148.DataField = "realizado_interes";
        this.textBox148.Height = 0.1875F;
        this.textBox148.Left = 11.9375F;
        this.textBox148.Name = "textBox148";
        this.textBox148.OutputFormat = resources.GetString("textBox148.OutputFormat");
        this.textBox148.Style = "";
        this.textBox148.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox148.Text = "textBox148";
        this.textBox148.Top = 0.125F;
        this.textBox148.Width = 0.9375F;
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
        this.textBox149.DataField = "realizado_total";
        this.textBox149.Height = 0.1875F;
        this.textBox149.Left = 12.9375F;
        this.textBox149.Name = "textBox149";
        this.textBox149.OutputFormat = resources.GetString("textBox149.OutputFormat");
        this.textBox149.Style = "";
        this.textBox149.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox149.Text = "textBox149";
        this.textBox149.Top = 0.125F;
        this.textBox149.Width = 0.9375F;
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
        this.textBox151.DataField = "restante_amortizacion";
        this.textBox151.Height = 0.1875F;
        this.textBox151.Left = 14.5F;
        this.textBox151.Name = "textBox151";
        this.textBox151.OutputFormat = resources.GetString("textBox151.OutputFormat");
        this.textBox151.Style = "";
        this.textBox151.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox151.Text = "textBox151";
        this.textBox151.Top = 0.125F;
        this.textBox151.Width = 0.9375F;
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
        this.textBox152.DataField = "restante_seguro";
        this.textBox152.Height = 0.1875F;
        this.textBox152.Left = 15.5F;
        this.textBox152.Name = "textBox152";
        this.textBox152.OutputFormat = resources.GetString("textBox152.OutputFormat");
        this.textBox152.Style = "";
        this.textBox152.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox152.Text = "textBox152";
        this.textBox152.Top = 0.125F;
        this.textBox152.Width = 0.6875F;
        // 
        // textBox153
        // 
        this.textBox153.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox153.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox153.Border.RightColor = System.Drawing.Color.Black;
        this.textBox153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox153.Border.TopColor = System.Drawing.Color.Black;
        this.textBox153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox153.DataField = "restante_mantenimiento";
        this.textBox153.Height = 0.1875F;
        this.textBox153.Left = 16.25F;
        this.textBox153.Name = "textBox153";
        this.textBox153.OutputFormat = resources.GetString("textBox153.OutputFormat");
        this.textBox153.Style = "";
        this.textBox153.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox153.Text = "textBox153";
        this.textBox153.Top = 0.125F;
        this.textBox153.Width = 0.6875F;
        // 
        // textBox154
        // 
        this.textBox154.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox154.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox154.Border.RightColor = System.Drawing.Color.Black;
        this.textBox154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox154.Border.TopColor = System.Drawing.Color.Black;
        this.textBox154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox154.DataField = "restante_interes";
        this.textBox154.Height = 0.1875F;
        this.textBox154.Left = 17F;
        this.textBox154.Name = "textBox154";
        this.textBox154.OutputFormat = resources.GetString("textBox154.OutputFormat");
        this.textBox154.Style = "";
        this.textBox154.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox154.Text = "textBox154";
        this.textBox154.Top = 0.125F;
        this.textBox154.Width = 0.9375F;
        // 
        // textBox155
        // 
        this.textBox155.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox155.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox155.Border.RightColor = System.Drawing.Color.Black;
        this.textBox155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox155.Border.TopColor = System.Drawing.Color.Black;
        this.textBox155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox155.DataField = "restante_total";
        this.textBox155.Height = 0.1875F;
        this.textBox155.Left = 18F;
        this.textBox155.Name = "textBox155";
        this.textBox155.OutputFormat = resources.GetString("textBox155.OutputFormat");
        this.textBox155.Style = "";
        this.textBox155.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox155.Text = "textBox155";
        this.textBox155.Top = 0.125F;
        this.textBox155.Width = 0.9375F;
        // 
        // textBox157
        // 
        this.textBox157.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox157.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox157.Border.RightColor = System.Drawing.Color.Black;
        this.textBox157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox157.Border.TopColor = System.Drawing.Color.Black;
        this.textBox157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox157.DataField = "total_precio";
        this.textBox157.Height = 0.1875F;
        this.textBox157.Left = 19.5625F;
        this.textBox157.Name = "textBox157";
        this.textBox157.OutputFormat = resources.GetString("textBox157.OutputFormat");
        this.textBox157.Style = "";
        this.textBox157.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox157.Text = "textBox157";
        this.textBox157.Top = 0.125F;
        this.textBox157.Width = 0.9375F;
        // 
        // textBox158
        // 
        this.textBox158.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox158.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox158.Border.RightColor = System.Drawing.Color.Black;
        this.textBox158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox158.Border.TopColor = System.Drawing.Color.Black;
        this.textBox158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox158.DataField = "total_seguro";
        this.textBox158.Height = 0.1875F;
        this.textBox158.Left = 20.5625F;
        this.textBox158.Name = "textBox158";
        this.textBox158.OutputFormat = resources.GetString("textBox158.OutputFormat");
        this.textBox158.Style = "";
        this.textBox158.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox158.Text = "textBox158";
        this.textBox158.Top = 0.125F;
        this.textBox158.Width = 0.6875F;
        // 
        // textBox159
        // 
        this.textBox159.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox159.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox159.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox159.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox159.Border.RightColor = System.Drawing.Color.Black;
        this.textBox159.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox159.Border.TopColor = System.Drawing.Color.Black;
        this.textBox159.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox159.DataField = "total_mantenimiento";
        this.textBox159.Height = 0.1875F;
        this.textBox159.Left = 21.3125F;
        this.textBox159.Name = "textBox159";
        this.textBox159.OutputFormat = resources.GetString("textBox159.OutputFormat");
        this.textBox159.Style = "";
        this.textBox159.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox159.Text = "textBox159";
        this.textBox159.Top = 0.125F;
        this.textBox159.Width = 0.6875F;
        // 
        // textBox160
        // 
        this.textBox160.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox160.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox160.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox160.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox160.Border.RightColor = System.Drawing.Color.Black;
        this.textBox160.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox160.Border.TopColor = System.Drawing.Color.Black;
        this.textBox160.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox160.DataField = "total_interes";
        this.textBox160.Height = 0.1875F;
        this.textBox160.Left = 22.0625F;
        this.textBox160.Name = "textBox160";
        this.textBox160.OutputFormat = resources.GetString("textBox160.OutputFormat");
        this.textBox160.Style = "";
        this.textBox160.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox160.Text = "textBox160";
        this.textBox160.Top = 0.125F;
        this.textBox160.Width = 0.9375F;
        // 
        // textBox161
        // 
        this.textBox161.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox161.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox161.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox161.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox161.Border.RightColor = System.Drawing.Color.Black;
        this.textBox161.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox161.Border.TopColor = System.Drawing.Color.Black;
        this.textBox161.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox161.DataField = "total_total";
        this.textBox161.Height = 0.1875F;
        this.textBox161.Left = 23.0625F;
        this.textBox161.Name = "textBox161";
        this.textBox161.OutputFormat = resources.GetString("textBox161.OutputFormat");
        this.textBox161.Style = "";
        this.textBox161.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox161.Text = "textBox161";
        this.textBox161.Top = 0.125F;
        this.textBox161.Width = 0.9375F;
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
        this.line3.Left = 0.0625F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0.0625F;
        this.line3.Width = 23.9375F;
        this.line3.X1 = 0.0625F;
        this.line3.X2 = 24F;
        this.line3.Y1 = 0.0625F;
        this.line3.Y2 = 0.0625F;
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
        this.textBox75.Left = 0.0625F;
        this.textBox75.Name = "textBox75";
        this.textBox75.Style = "";
        this.textBox75.Text = "TOTAL:";
        this.textBox75.Top = 0.125F;
        this.textBox75.Width = 2.75F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.textBox8});
        this.groupHeader1.DataField = "negocio";
        this.groupHeader1.Height = 0.2083333F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox7.Left = 0.0625F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = "Negocio:";
        this.textBox7.Top = 0F;
        this.textBox7.Width = 0.625F;
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
        this.textBox8.Left = 0.75F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "textBox8";
        this.textBox8.Top = 0F;
        this.textBox8.Width = 2.875F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox107,
            this.textBox116,
            this.textBox117,
            this.textBox118,
            this.textBox119,
            this.textBox120,
            this.textBox122,
            this.textBox123,
            this.textBox124,
            this.textBox125,
            this.textBox126,
            this.textBox128,
            this.textBox129,
            this.textBox130,
            this.textBox131,
            this.textBox132,
            this.line2,
            this.textBox53});
        this.groupFooter1.Height = 0.53125F;
        this.groupFooter1.Name = "groupFooter1";
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
        this.textBox107.DataField = "precio_final";
        this.textBox107.Height = 0.1875F;
        this.textBox107.Left = 4.1875F;
        this.textBox107.Name = "textBox107";
        this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
        this.textBox107.Style = "";
        this.textBox107.SummaryGroup = "groupHeader1";
        this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox107.Text = "textBox107";
        this.textBox107.Top = 0.125F;
        this.textBox107.Width = 1F;
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
        this.textBox116.DataField = "realizado_amortizacion";
        this.textBox116.Height = 0.1875F;
        this.textBox116.Left = 9.4375F;
        this.textBox116.Name = "textBox116";
        this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
        this.textBox116.Style = "";
        this.textBox116.SummaryGroup = "groupHeader1";
        this.textBox116.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox116.Text = "textBox116";
        this.textBox116.Top = 0.125F;
        this.textBox116.Width = 0.9375F;
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
        this.textBox117.DataField = "realizado_seguro";
        this.textBox117.Height = 0.1875F;
        this.textBox117.Left = 10.4375F;
        this.textBox117.Name = "textBox117";
        this.textBox117.OutputFormat = resources.GetString("textBox117.OutputFormat");
        this.textBox117.Style = "";
        this.textBox117.SummaryGroup = "groupHeader1";
        this.textBox117.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox117.Text = "textBox117";
        this.textBox117.Top = 0.125F;
        this.textBox117.Width = 0.6875F;
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
        this.textBox118.DataField = "realizado_mantenimiento";
        this.textBox118.Height = 0.1875F;
        this.textBox118.Left = 11.1875F;
        this.textBox118.Name = "textBox118";
        this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
        this.textBox118.Style = "";
        this.textBox118.SummaryGroup = "groupHeader1";
        this.textBox118.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox118.Text = "textBox118";
        this.textBox118.Top = 0.125F;
        this.textBox118.Width = 0.6875F;
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
        this.textBox119.DataField = "realizado_interes";
        this.textBox119.Height = 0.1875F;
        this.textBox119.Left = 11.9375F;
        this.textBox119.Name = "textBox119";
        this.textBox119.OutputFormat = resources.GetString("textBox119.OutputFormat");
        this.textBox119.Style = "";
        this.textBox119.SummaryGroup = "groupHeader1";
        this.textBox119.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox119.Text = "textBox119";
        this.textBox119.Top = 0.125F;
        this.textBox119.Width = 0.9375F;
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
        this.textBox120.DataField = "realizado_total";
        this.textBox120.Height = 0.1875F;
        this.textBox120.Left = 12.9375F;
        this.textBox120.Name = "textBox120";
        this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
        this.textBox120.Style = "";
        this.textBox120.SummaryGroup = "groupHeader1";
        this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox120.Text = "textBox120";
        this.textBox120.Top = 0.125F;
        this.textBox120.Width = 0.9375F;
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
        this.textBox122.DataField = "restante_amortizacion";
        this.textBox122.Height = 0.1875F;
        this.textBox122.Left = 14.5F;
        this.textBox122.Name = "textBox122";
        this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
        this.textBox122.Style = "";
        this.textBox122.SummaryGroup = "groupHeader1";
        this.textBox122.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox122.Text = "textBox122";
        this.textBox122.Top = 0.125F;
        this.textBox122.Width = 0.9375F;
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
        this.textBox123.DataField = "restante_seguro";
        this.textBox123.Height = 0.1875F;
        this.textBox123.Left = 15.5F;
        this.textBox123.Name = "textBox123";
        this.textBox123.OutputFormat = resources.GetString("textBox123.OutputFormat");
        this.textBox123.Style = "";
        this.textBox123.SummaryGroup = "groupHeader1";
        this.textBox123.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox123.Text = "textBox123";
        this.textBox123.Top = 0.125F;
        this.textBox123.Width = 0.6875F;
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
        this.textBox124.DataField = "restante_mantenimiento";
        this.textBox124.Height = 0.1875F;
        this.textBox124.Left = 16.25F;
        this.textBox124.Name = "textBox124";
        this.textBox124.OutputFormat = resources.GetString("textBox124.OutputFormat");
        this.textBox124.Style = "";
        this.textBox124.SummaryGroup = "groupHeader1";
        this.textBox124.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox124.Text = "textBox124";
        this.textBox124.Top = 0.125F;
        this.textBox124.Width = 0.6875F;
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
        this.textBox125.DataField = "restante_interes";
        this.textBox125.Height = 0.1875F;
        this.textBox125.Left = 17F;
        this.textBox125.Name = "textBox125";
        this.textBox125.OutputFormat = resources.GetString("textBox125.OutputFormat");
        this.textBox125.Style = "";
        this.textBox125.SummaryGroup = "groupHeader1";
        this.textBox125.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox125.Text = "textBox125";
        this.textBox125.Top = 0.125F;
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
        this.textBox126.DataField = "restante_total";
        this.textBox126.Height = 0.1875F;
        this.textBox126.Left = 18F;
        this.textBox126.Name = "textBox126";
        this.textBox126.OutputFormat = resources.GetString("textBox126.OutputFormat");
        this.textBox126.Style = "";
        this.textBox126.SummaryGroup = "groupHeader1";
        this.textBox126.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox126.Text = "textBox126";
        this.textBox126.Top = 0.125F;
        this.textBox126.Width = 0.9375F;
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
        this.textBox128.DataField = "total_precio";
        this.textBox128.Height = 0.1875F;
        this.textBox128.Left = 19.5625F;
        this.textBox128.Name = "textBox128";
        this.textBox128.OutputFormat = resources.GetString("textBox128.OutputFormat");
        this.textBox128.Style = "";
        this.textBox128.SummaryGroup = "groupHeader1";
        this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox128.Text = "textBox128";
        this.textBox128.Top = 0.125F;
        this.textBox128.Width = 0.9375F;
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
        this.textBox129.DataField = "total_seguro";
        this.textBox129.Height = 0.1875F;
        this.textBox129.Left = 20.5625F;
        this.textBox129.Name = "textBox129";
        this.textBox129.OutputFormat = resources.GetString("textBox129.OutputFormat");
        this.textBox129.Style = "";
        this.textBox129.SummaryGroup = "groupHeader1";
        this.textBox129.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox129.Text = "textBox129";
        this.textBox129.Top = 0.125F;
        this.textBox129.Width = 0.6875F;
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
        this.textBox130.DataField = "total_mantenimiento";
        this.textBox130.Height = 0.1875F;
        this.textBox130.Left = 21.3125F;
        this.textBox130.Name = "textBox130";
        this.textBox130.OutputFormat = resources.GetString("textBox130.OutputFormat");
        this.textBox130.Style = "";
        this.textBox130.SummaryGroup = "groupHeader1";
        this.textBox130.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox130.Text = "textBox130";
        this.textBox130.Top = 0.125F;
        this.textBox130.Width = 0.6875F;
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
        this.textBox131.DataField = "total_interes";
        this.textBox131.Height = 0.1875F;
        this.textBox131.Left = 22.0625F;
        this.textBox131.Name = "textBox131";
        this.textBox131.OutputFormat = resources.GetString("textBox131.OutputFormat");
        this.textBox131.Style = "";
        this.textBox131.SummaryGroup = "groupHeader1";
        this.textBox131.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox131.Text = "textBox131";
        this.textBox131.Top = 0.125F;
        this.textBox131.Width = 0.9375F;
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
        this.textBox132.DataField = "total_total";
        this.textBox132.Height = 0.1875F;
        this.textBox132.Left = 23.0625F;
        this.textBox132.Name = "textBox132";
        this.textBox132.OutputFormat = resources.GetString("textBox132.OutputFormat");
        this.textBox132.Style = "";
        this.textBox132.SummaryGroup = "groupHeader1";
        this.textBox132.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox132.Text = "textBox132";
        this.textBox132.Top = 0.125F;
        this.textBox132.Width = 0.9375F;
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
        this.line2.Top = 0.0625F;
        this.line2.Width = 23.9375F;
        this.line2.X1 = 0.0625F;
        this.line2.X2 = 24F;
        this.line2.Y1 = 0.0625F;
        this.line2.Y2 = 0.0625F;
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
        this.textBox53.Height = 0.1875F;
        this.textBox53.Left = 0.0625F;
        this.textBox53.Name = "textBox53";
        this.textBox53.Style = "";
        this.textBox53.Text = "Sub total (Negocio):";
        this.textBox53.Top = 0.125F;
        this.textBox53.Width = 2.75F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox9,
            this.textBox10});
        this.groupHeader2.DataField = "urbanizacion";
        this.groupHeader2.Height = 0.1979167F;
        this.groupHeader2.Name = "groupHeader2";
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
        this.textBox9.Left = 0.75F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "Sector:";
        this.textBox9.Top = 0F;
        this.textBox9.Width = 1F;
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
        this.textBox10.DataField = "urbanizacion";
        this.textBox10.Height = 0.1875F;
        this.textBox10.Left = 1.8125F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "textBox10";
        this.textBox10.Top = 0F;
        this.textBox10.Width = 3.375F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox78,
            this.textBox87,
            this.textBox88,
            this.textBox89,
            this.textBox90,
            this.textBox91,
            this.textBox93,
            this.textBox94,
            this.textBox95,
            this.textBox96,
            this.textBox97,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textBox102,
            this.textBox103,
            this.line1,
            this.textBox24});
        this.groupFooter2.Height = 0.3645833F;
        this.groupFooter2.Name = "groupFooter2";
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
        this.textBox78.DataField = "precio_final";
        this.textBox78.Height = 0.1875F;
        this.textBox78.Left = 4.1875F;
        this.textBox78.Name = "textBox78";
        this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
        this.textBox78.Style = "";
        this.textBox78.SummaryGroup = "groupHeader2";
        this.textBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox78.Text = "textBox78";
        this.textBox78.Top = 0.125F;
        this.textBox78.Width = 1F;
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
        this.textBox87.DataField = "realizado_amortizacion";
        this.textBox87.Height = 0.1875F;
        this.textBox87.Left = 9.4375F;
        this.textBox87.Name = "textBox87";
        this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
        this.textBox87.Style = "";
        this.textBox87.SummaryGroup = "groupHeader2";
        this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox87.Text = "textBox87";
        this.textBox87.Top = 0.125F;
        this.textBox87.Width = 0.9375F;
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
        this.textBox88.DataField = "realizado_seguro";
        this.textBox88.Height = 0.1875F;
        this.textBox88.Left = 10.4375F;
        this.textBox88.Name = "textBox88";
        this.textBox88.OutputFormat = resources.GetString("textBox88.OutputFormat");
        this.textBox88.Style = "";
        this.textBox88.SummaryGroup = "groupHeader2";
        this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox88.Text = "textBox88";
        this.textBox88.Top = 0.125F;
        this.textBox88.Width = 0.6875F;
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
        this.textBox89.DataField = "realizado_mantenimiento";
        this.textBox89.Height = 0.1875F;
        this.textBox89.Left = 11.1875F;
        this.textBox89.Name = "textBox89";
        this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
        this.textBox89.Style = "";
        this.textBox89.SummaryGroup = "groupHeader2";
        this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox89.Text = "textBox89";
        this.textBox89.Top = 0.125F;
        this.textBox89.Width = 0.6875F;
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
        this.textBox90.DataField = "realizado_interes";
        this.textBox90.Height = 0.1875F;
        this.textBox90.Left = 11.9375F;
        this.textBox90.Name = "textBox90";
        this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
        this.textBox90.Style = "";
        this.textBox90.SummaryGroup = "groupHeader2";
        this.textBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox90.Text = "textBox90";
        this.textBox90.Top = 0.125F;
        this.textBox90.Width = 0.9375F;
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
        this.textBox91.DataField = "realizado_total";
        this.textBox91.Height = 0.1875F;
        this.textBox91.Left = 12.9375F;
        this.textBox91.Name = "textBox91";
        this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
        this.textBox91.Style = "";
        this.textBox91.SummaryGroup = "groupHeader2";
        this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox91.Text = "textBox91";
        this.textBox91.Top = 0.125F;
        this.textBox91.Width = 0.9375F;
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
        this.textBox93.DataField = "restante_amortizacion";
        this.textBox93.Height = 0.1875F;
        this.textBox93.Left = 14.5F;
        this.textBox93.Name = "textBox93";
        this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
        this.textBox93.Style = "";
        this.textBox93.SummaryGroup = "groupHeader2";
        this.textBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox93.Text = "textBox93";
        this.textBox93.Top = 0.125F;
        this.textBox93.Width = 0.9375F;
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
        this.textBox94.DataField = "restante_seguro";
        this.textBox94.Height = 0.1875F;
        this.textBox94.Left = 15.5F;
        this.textBox94.Name = "textBox94";
        this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
        this.textBox94.Style = "";
        this.textBox94.SummaryGroup = "groupHeader2";
        this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox94.Text = "textBox94";
        this.textBox94.Top = 0.125F;
        this.textBox94.Width = 0.6875F;
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
        this.textBox95.DataField = "restante_mantenimiento";
        this.textBox95.Height = 0.1875F;
        this.textBox95.Left = 16.25F;
        this.textBox95.Name = "textBox95";
        this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
        this.textBox95.Style = "";
        this.textBox95.SummaryGroup = "groupHeader2";
        this.textBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox95.Text = "textBox95";
        this.textBox95.Top = 0.125F;
        this.textBox95.Width = 0.6875F;
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
        this.textBox96.DataField = "restante_interes";
        this.textBox96.Height = 0.1875F;
        this.textBox96.Left = 17F;
        this.textBox96.Name = "textBox96";
        this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
        this.textBox96.Style = "";
        this.textBox96.SummaryGroup = "groupHeader2";
        this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox96.Text = "textBox96";
        this.textBox96.Top = 0.125F;
        this.textBox96.Width = 0.9375F;
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
        this.textBox97.DataField = "restante_total";
        this.textBox97.Height = 0.1875F;
        this.textBox97.Left = 18F;
        this.textBox97.Name = "textBox97";
        this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
        this.textBox97.Style = "";
        this.textBox97.SummaryGroup = "groupHeader2";
        this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox97.Text = "textBox97";
        this.textBox97.Top = 0.125F;
        this.textBox97.Width = 0.9375F;
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
        this.textBox99.DataField = "total_precio";
        this.textBox99.Height = 0.1875F;
        this.textBox99.Left = 19.5625F;
        this.textBox99.Name = "textBox99";
        this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
        this.textBox99.Style = "";
        this.textBox99.SummaryGroup = "groupHeader2";
        this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox99.Text = "textBox99";
        this.textBox99.Top = 0.125F;
        this.textBox99.Width = 0.9375F;
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
        this.textBox100.DataField = "total_seguro";
        this.textBox100.Height = 0.1875F;
        this.textBox100.Left = 20.5625F;
        this.textBox100.Name = "textBox100";
        this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
        this.textBox100.Style = "";
        this.textBox100.SummaryGroup = "groupHeader2";
        this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox100.Text = "textBox100";
        this.textBox100.Top = 0.125F;
        this.textBox100.Width = 0.6875F;
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
        this.textBox101.DataField = "total_mantenimiento";
        this.textBox101.Height = 0.1875F;
        this.textBox101.Left = 21.3125F;
        this.textBox101.Name = "textBox101";
        this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
        this.textBox101.Style = "";
        this.textBox101.SummaryGroup = "groupHeader2";
        this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox101.Text = "textBox101";
        this.textBox101.Top = 0.125F;
        this.textBox101.Width = 0.6875F;
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
        this.textBox102.DataField = "total_interes";
        this.textBox102.Height = 0.1875F;
        this.textBox102.Left = 22.0625F;
        this.textBox102.Name = "textBox102";
        this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
        this.textBox102.Style = "";
        this.textBox102.SummaryGroup = "groupHeader2";
        this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox102.Text = "textBox102";
        this.textBox102.Top = 0.125F;
        this.textBox102.Width = 0.9375F;
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
        this.textBox103.DataField = "total_total";
        this.textBox103.Height = 0.1875F;
        this.textBox103.Left = 23.0625F;
        this.textBox103.Name = "textBox103";
        this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
        this.textBox103.Style = "";
        this.textBox103.SummaryGroup = "groupHeader2";
        this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox103.Text = "textBox103";
        this.textBox103.Top = 0.125F;
        this.textBox103.Width = 0.9375F;
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
        this.line1.Left = 0.75F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.0625F;
        this.line1.Width = 23.25F;
        this.line1.X1 = 0.75F;
        this.line1.X2 = 24F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
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
        this.textBox24.Left = 0.75F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "Sub total (Sector):";
        this.textBox24.Top = 0.125F;
        this.textBox24.Width = 2.0625F;
        // 
        // rpt_cxc_detalle
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 24.07292F;
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
        this.ReportStart += new System.EventHandler(this.rpt_cxc_detalle_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox80)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox81)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox82)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox136)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox153)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox154)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox155)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox157)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox158)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox159)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox160)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox161)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox132)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox87)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox90)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox93)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox94)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox95)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion
}
