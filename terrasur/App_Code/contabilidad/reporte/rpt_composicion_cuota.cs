using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rpt_composicion_cuota.
/// </summary>
public class rpt_composicion_cuota : DataDynamics.ActiveReports.ActiveReport3
{
    public void CargarDatos(DateTime Inicio, DateTime Fin, string Negocio, string Moneda, string Consolidado, string Codigo_moneda)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox4.Text = Inicio.ToString("d");
        textBox6.Text = Fin.ToString("d");
        textBox8.Text = Negocio;

        textBox129.Text = Moneda;
        textBox131.Text = Consolidado;

        textBox9.Text = "PAGOS (" + Codigo_moneda + ")";
        textBox15.Text = "Total pagado (" + Codigo_moneda + ")";
        textBox16.Text = "Capital (" + Codigo_moneda + ")";
        textBox17.Text = "Interés corriente (" + Codigo_moneda + ")";
        textBox20.Text = "Interés penal (" + Codigo_moneda + ")";
        textBox18.Text = "Seguro desgrav. (" + Codigo_moneda + ")";
        textBox19.Text = "Mantenim. (" + Codigo_moneda + ")";
        textBox21.Text = "Otros servicios (" + Codigo_moneda + ")";

        textBox10.Text = "PAGOS EN DOCUMENTO (" + Codigo_moneda + ")";
        textBox22.Text = "Total pago en DPR (" + Codigo_moneda + ")";
        textBox23.Text = "Capital (" + Codigo_moneda + ")";
        textBox24.Text = "Interés corriente (" + Codigo_moneda + ")";
        textBox27.Text = "Interés penal (" + Codigo_moneda + ")";
        textBox25.Text = "Seguro desgrav. (" + Codigo_moneda + ")";
        textBox26.Text = "Mantenim. (" + Codigo_moneda + ")";
        textBox28.Text = "Otros servicios (" + Codigo_moneda + ")";

        textBox11.Text = "PAGOS EN EFECTIVO (" + Codigo_moneda + ")";
        textBox29.Text = "Total pago Efectivo (" + Codigo_moneda + ")";
        textBox30.Text = "Capital (" + Codigo_moneda + ")";
        textBox31.Text = "Interés corriente (" + Codigo_moneda + ")";
        textBox34.Text = "Interés penal (" + Codigo_moneda + ")";
        textBox32.Text = "Seguro desgrav. (" + Codigo_moneda + ")";
        textBox33.Text = "Mantenim. (" + Codigo_moneda + ")";
        textBox35.Text = "Otros servicios (" + Codigo_moneda + ")";

        textBox36.Text = "Ventas del mes (" + Codigo_moneda + ")";
        textBox37.Text = "Saldo Revertido (" + Codigo_moneda + ")";
    }

    private void rpt_composicion_cuota_ReportStart(object sender, EventArgs e)
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
        textBox4.ClassName = "estiloEncabDato";
        textBox6.ClassName = "estiloEncabDato";
        textBox8.ClassName = "estiloEncabDato";

        textBox128.ClassName = "estiloEncabEnun";
        textBox129.ClassName = "estiloEncabDato";
        textBox130.ClassName = "estiloEncabEnun";
        textBox131.ClassName = "estiloEncabDato";

        textBox124.ClassName = "estiloGrupoEnun";
        textBox125.ClassName = "estiloGrupoEnun";
        textBox126.ClassName = "estiloSubTotalEnun";
        textBox127.ClassName = "estiloTotalEnun";

        //Detalle (header):
        textBox9.ClassName = "estiloDetalleGrupo";
        textBox10.ClassName = "estiloDetalleGrupo";
        textBox11.ClassName = "estiloDetalleGrupo";
        textBox12.ClassName = "estiloDetalleGrupo";
        textBox13.ClassName = "estiloDetalleGrupo";

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
        textBox35.ClassName = "estiloDetalleEnun";
        textBox36.ClassName = "estiloDetalleEnun";
        textBox37.ClassName = "estiloDetalleEnun";
        textBox38.ClassName = "estiloDetalleEnun";
        textBox39.ClassName = "estiloDetalleEnun";
        textBox40.ClassName = "estiloDetalleEnun";
        textBox41.ClassName = "estiloDetalleEnun";

        //Detalle (datos):
        textBox42.ClassName = "estiloDetalleDatoString";
        textBox43.ClassName = "estiloDetalleDato";
        textBox44.ClassName = "estiloDetalleDato";
        textBox45.ClassName = "estiloDetalleDato";
        textBox46.ClassName = "estiloDetalleDato";
        textBox47.ClassName = "estiloDetalleDato";
        textBox48.ClassName = "estiloDetalleDato";
        textBox49.ClassName = "estiloDetalleDato";
        textBox50.ClassName = "estiloDetalleDato";
        textBox51.ClassName = "estiloDetalleDato";
        textBox52.ClassName = "estiloDetalleDato";
        textBox53.ClassName = "estiloDetalleDato";
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

        textBox70.ClassName = "estiloSubTotal";
        textBox71.ClassName = "estiloSubTotal";
        textBox72.ClassName = "estiloSubTotal";
        textBox73.ClassName = "estiloSubTotal";
        textBox74.ClassName = "estiloSubTotal";
        textBox75.ClassName = "estiloSubTotal";
        textBox76.ClassName = "estiloSubTotal";
        textBox77.ClassName = "estiloSubTotal";
        textBox78.ClassName = "estiloSubTotal";
        textBox79.ClassName = "estiloSubTotal";
        textBox80.ClassName = "estiloSubTotal";
        textBox81.ClassName = "estiloSubTotal";
        textBox82.ClassName = "estiloSubTotal";
        textBox83.ClassName = "estiloSubTotal";
        textBox84.ClassName = "estiloSubTotal";
        textBox85.ClassName = "estiloSubTotal";
        textBox86.ClassName = "estiloSubTotal";
        textBox87.ClassName = "estiloSubTotal";
        textBox88.ClassName = "estiloSubTotal";
        textBox89.ClassName = "estiloSubTotal";
        textBox90.ClassName = "estiloSubTotal";
        textBox91.ClassName = "estiloSubTotal";
        textBox92.ClassName = "estiloSubTotal";
        textBox93.ClassName = "estiloSubTotal";
        textBox94.ClassName = "estiloSubTotal";
        textBox95.ClassName = "estiloSubTotal";
        textBox96.ClassName = "estiloSubTotal";

        textBox97.ClassName = "estiloTotal";
        textBox98.ClassName = "estiloTotal";
        textBox99.ClassName = "estiloTotal";
        textBox100.ClassName = "estiloTotal";
        textBox101.ClassName = "estiloTotal";
        textBox102.ClassName = "estiloTotal";
        textBox103.ClassName = "estiloTotal";
        textBox104.ClassName = "estiloTotal";
        textBox105.ClassName = "estiloTotal";
        textBox106.ClassName = "estiloTotal";
        textBox107.ClassName = "estiloTotal";
        textBox108.ClassName = "estiloTotal";
        textBox109.ClassName = "estiloTotal";
        textBox110.ClassName = "estiloTotal";
        textBox111.ClassName = "estiloTotal";
        textBox112.ClassName = "estiloTotal";
        textBox113.ClassName = "estiloTotal";
        textBox114.ClassName = "estiloTotal";
        textBox115.ClassName = "estiloTotal";
        textBox116.ClassName = "estiloTotal";
        textBox117.ClassName = "estiloTotal";
        textBox118.ClassName = "estiloTotal";
        textBox119.ClassName = "estiloTotal";
        textBox120.ClassName = "estiloTotal";
        textBox121.ClassName = "estiloTotal";
        textBox122.ClassName = "estiloTotal";
        textBox123.ClassName = "estiloTotal";

        //Report (footer):
        //Cometario:
    } 

	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
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
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
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
    private Line line2;
    private Line line1;
    private Picture picture1;
    private TextBox textBox128;
    private TextBox textBox129;
    private TextBox textBox130;
    private TextBox textBox131;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_composicion_cuota()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_composicion_cuota));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
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
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox127 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
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
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox124 = new DataDynamics.ActiveReports.TextBox();
        this.textBox125 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox126 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
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
        this.textBox128 = new DataDynamics.ActiveReports.TextBox();
        this.textBox129 = new DataDynamics.ActiveReports.TextBox();
        this.textBox130 = new DataDynamics.ActiveReports.TextBox();
        this.textBox131 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox9,
            this.textBox10,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox11,
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
            this.textBox13,
            this.textBox12,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox20});
        this.pageHeader.Height = 0.6979167F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox9.Left = 2.5625F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "PAGOS";
        this.textBox9.Top = 0F;
        this.textBox9.Width = 6.6875F;
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
        this.textBox10.Left = 9.3125F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "PAGOS EN DOCUMENTO";
        this.textBox10.Top = 0F;
        this.textBox10.Width = 6.6875F;
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
        this.textBox14.Text = "Sector";
        this.textBox14.Top = 0.375F;
        this.textBox14.Width = 1.5F;
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
        this.textBox15.Left = 2.5625F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = "Total pagado";
        this.textBox15.Top = 0.375F;
        this.textBox15.Width = 0.9375F;
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
        this.textBox16.Left = 3.5625F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Capital";
        this.textBox16.Top = 0.375F;
        this.textBox16.Width = 0.9375F;
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
        this.textBox17.Left = 4.5625F;
        this.textBox17.Name = "textBox17";
        this.textBox17.Style = "";
        this.textBox17.Text = "Interés corriente";
        this.textBox17.Top = 0.375F;
        this.textBox17.Width = 0.9375F;
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
        this.textBox18.Left = 6.5F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "Seguro desgrav.";
        this.textBox18.Top = 0.375F;
        this.textBox18.Width = 0.875F;
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
        this.textBox19.Left = 7.4375F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "Mantenim.";
        this.textBox19.Top = 0.375F;
        this.textBox19.Width = 0.875F;
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
        this.textBox21.Left = 8.375F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "Otros servicios";
        this.textBox21.Top = 0.375F;
        this.textBox21.Width = 0.875F;
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
        this.textBox22.Left = 9.3125F;
        this.textBox22.Name = "textBox22";
        this.textBox22.Style = "";
        this.textBox22.Text = "Total pago en Documento";
        this.textBox22.Top = 0.375F;
        this.textBox22.Width = 0.9375F;
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
        this.textBox23.Left = 10.3125F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Capital";
        this.textBox23.Top = 0.375F;
        this.textBox23.Width = 0.9375F;
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
        this.textBox24.Left = 11.3125F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "Interés corriente";
        this.textBox24.Top = 0.375F;
        this.textBox24.Width = 0.9375F;
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
        this.textBox11.Left = 16.0625F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "PAGOS EN EFECTIVO";
        this.textBox11.Top = 0F;
        this.textBox11.Width = 6.6875F;
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
        this.textBox25.Left = 13.25F;
        this.textBox25.Name = "textBox25";
        this.textBox25.Style = "";
        this.textBox25.Text = "Seguro desgrav.";
        this.textBox25.Top = 0.375F;
        this.textBox25.Width = 0.875F;
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
        this.textBox26.Left = 14.1875F;
        this.textBox26.Name = "textBox26";
        this.textBox26.Style = "";
        this.textBox26.Text = "Mantenim.";
        this.textBox26.Top = 0.375F;
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
        this.textBox27.Left = 12.3125F;
        this.textBox27.Name = "textBox27";
        this.textBox27.Style = "";
        this.textBox27.Text = "Interés penal";
        this.textBox27.Top = 0.375F;
        this.textBox27.Width = 0.875F;
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
        this.textBox28.Left = 15.125F;
        this.textBox28.Name = "textBox28";
        this.textBox28.Style = "";
        this.textBox28.Text = "Otros servicios";
        this.textBox28.Top = 0.375F;
        this.textBox28.Width = 0.875F;
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
        this.textBox29.Left = 16.0625F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "";
        this.textBox29.Text = "Total pago en Efectivo";
        this.textBox29.Top = 0.375F;
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
        this.textBox30.Left = 17.0625F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "Capital";
        this.textBox30.Top = 0.375F;
        this.textBox30.Width = 0.9375F;
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
        this.textBox31.Left = 18.0625F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "Interés corriente";
        this.textBox31.Top = 0.375F;
        this.textBox31.Width = 0.9375F;
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
        this.textBox32.Left = 20F;
        this.textBox32.Name = "textBox32";
        this.textBox32.Style = "";
        this.textBox32.Text = "Seguro desgrav.";
        this.textBox32.Top = 0.375F;
        this.textBox32.Width = 0.875F;
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
        this.textBox33.Left = 20.9375F;
        this.textBox33.Name = "textBox33";
        this.textBox33.Style = "";
        this.textBox33.Text = "Mantenim.";
        this.textBox33.Top = 0.375F;
        this.textBox33.Width = 0.875F;
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
        this.textBox34.Left = 19.0625F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "Interés penal";
        this.textBox34.Top = 0.375F;
        this.textBox34.Width = 0.875F;
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
        this.textBox13.Left = 23.8125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "REVERSIÓN";
        this.textBox13.Top = 0F;
        this.textBox13.Width = 0.9375F;
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
        this.textBox12.Left = 22.8125F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "VENTAS NUEVAS";
        this.textBox12.Top = 0F;
        this.textBox12.Width = 0.9375F;
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
        this.textBox35.Left = 21.875F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "Otros servicios";
        this.textBox35.Top = 0.375F;
        this.textBox35.Width = 0.875F;
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
        this.textBox36.Left = 22.8125F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Ventas del mes";
        this.textBox36.Top = 0.375F;
        this.textBox36.Width = 0.9375F;
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
        this.textBox37.Left = 23.8125F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "Saldo Revertido";
        this.textBox37.Top = 0.375F;
        this.textBox37.Width = 0.9375F;
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
        this.textBox38.Left = 24.8125F;
        this.textBox38.Name = "textBox38";
        this.textBox38.Style = "";
        this.textBox38.Text = "Ingreso trámites (Bs)";
        this.textBox38.Top = 0.375F;
        this.textBox38.Width = 0.9375F;
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
        this.textBox39.Left = 25.8125F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "Libro de ventas (Bs) ";
        this.textBox39.Top = 0.375F;
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
        this.textBox40.Left = 26.8125F;
        this.textBox40.Name = "textBox40";
        this.textBox40.Style = "";
        this.textBox40.Text = "Débito fiscal IVA 13% (Bs)";
        this.textBox40.Top = 0.375F;
        this.textBox40.Width = 0.9375F;
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
        this.textBox41.Left = 27.8125F;
        this.textBox41.Name = "textBox41";
        this.textBox41.Style = "";
        this.textBox41.Text = "Importe neto 87 % (Bs)";
        this.textBox41.Top = 0.375F;
        this.textBox41.Width = 0.9375F;
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
        this.textBox20.Left = 5.5625F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "Interés penal";
        this.textBox20.Top = 0.375F;
        this.textBox20.Width = 0.875F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.textBox69});
        this.detail.Height = 0.1875F;
        this.detail.Name = "detail";
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
        this.textBox42.DataField = "urbanizacion";
        this.textBox42.Height = 0.1875F;
        this.textBox42.Left = 1F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 0F;
        this.textBox42.Width = 1.5F;
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
        this.textBox43.DataField = "pagos_total";
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 2.5625F;
        this.textBox43.Name = "textBox43";
        this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
        this.textBox43.Style = "";
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0F;
        this.textBox43.Width = 0.9375F;
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
        this.textBox44.DataField = "pagos_capital";
        this.textBox44.Height = 0.1875F;
        this.textBox44.Left = 3.5625F;
        this.textBox44.Name = "textBox44";
        this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
        this.textBox44.Style = "";
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 0F;
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
        this.textBox45.DataField = "pagos_interes";
        this.textBox45.Height = 0.1875F;
        this.textBox45.Left = 4.5625F;
        this.textBox45.Name = "textBox45";
        this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
        this.textBox45.Style = "";
        this.textBox45.Text = "textBox45";
        this.textBox45.Top = 0F;
        this.textBox45.Width = 0.9375F;
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
        this.textBox46.DataField = "pagos_seguro";
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 6.5F;
        this.textBox46.Name = "textBox46";
        this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
        this.textBox46.Style = "";
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0F;
        this.textBox46.Width = 0.875F;
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
        this.textBox47.DataField = "pagos_mantenimiento";
        this.textBox47.Height = 0.1875F;
        this.textBox47.Left = 7.4375F;
        this.textBox47.Name = "textBox47";
        this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
        this.textBox47.Style = "";
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0F;
        this.textBox47.Width = 0.875F;
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
        this.textBox48.DataField = "pagos_mora";
        this.textBox48.Height = 0.1875F;
        this.textBox48.Left = 5.5625F;
        this.textBox48.Name = "textBox48";
        this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
        this.textBox48.Style = "";
        this.textBox48.Text = "textBox48";
        this.textBox48.Top = 0F;
        this.textBox48.Width = 0.875F;
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
        this.textBox49.DataField = "pagos_servicios";
        this.textBox49.Height = 0.1875F;
        this.textBox49.Left = 8.375F;
        this.textBox49.Name = "textBox49";
        this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
        this.textBox49.Style = "";
        this.textBox49.Text = "textBox49";
        this.textBox49.Top = 0F;
        this.textBox49.Width = 0.875F;
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
        this.textBox50.DataField = "dpr_total";
        this.textBox50.Height = 0.1875F;
        this.textBox50.Left = 9.3125F;
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
        this.textBox50.Style = "";
        this.textBox50.Text = "textBox50";
        this.textBox50.Top = 0F;
        this.textBox50.Width = 0.9375F;
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
        this.textBox51.DataField = "dpr_capital";
        this.textBox51.Height = 0.1875F;
        this.textBox51.Left = 10.3125F;
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
        this.textBox51.Style = "";
        this.textBox51.Text = "textBox51";
        this.textBox51.Top = 0F;
        this.textBox51.Width = 0.9375F;
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
        this.textBox52.DataField = "dpr_interes";
        this.textBox52.Height = 0.1875F;
        this.textBox52.Left = 11.3125F;
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
        this.textBox52.Style = "";
        this.textBox52.Text = "textBox52";
        this.textBox52.Top = 0F;
        this.textBox52.Width = 0.9375F;
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
        this.textBox53.DataField = "dpr_seguro";
        this.textBox53.Height = 0.1875F;
        this.textBox53.Left = 13.25F;
        this.textBox53.Name = "textBox53";
        this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
        this.textBox53.Style = "";
        this.textBox53.Text = "textBox53";
        this.textBox53.Top = 0F;
        this.textBox53.Width = 0.875F;
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
        this.textBox54.DataField = "dpr_mantenimiento";
        this.textBox54.Height = 0.1875F;
        this.textBox54.Left = 14.1875F;
        this.textBox54.Name = "textBox54";
        this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
        this.textBox54.Style = "";
        this.textBox54.Text = "textBox54";
        this.textBox54.Top = 0F;
        this.textBox54.Width = 0.875F;
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
        this.textBox55.DataField = "dpr_mora";
        this.textBox55.Height = 0.1875F;
        this.textBox55.Left = 12.3125F;
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
        this.textBox55.Style = "";
        this.textBox55.Text = "textBox55";
        this.textBox55.Top = 0F;
        this.textBox55.Width = 0.875F;
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
        this.textBox56.DataField = "dpr_servicios";
        this.textBox56.Height = 0.1875F;
        this.textBox56.Left = 15.125F;
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
        this.textBox56.Style = "";
        this.textBox56.Text = "textBox56";
        this.textBox56.Top = 0F;
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
        this.textBox57.DataField = "efectivo_total";
        this.textBox57.Height = 0.1875F;
        this.textBox57.Left = 16.0625F;
        this.textBox57.Name = "textBox57";
        this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
        this.textBox57.Style = "";
        this.textBox57.Text = "textBox57";
        this.textBox57.Top = 0F;
        this.textBox57.Width = 0.9375F;
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
        this.textBox58.DataField = "efectivo_capital";
        this.textBox58.Height = 0.1875F;
        this.textBox58.Left = 17.0625F;
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
        this.textBox59.DataField = "efectivo_interes";
        this.textBox59.Height = 0.1875F;
        this.textBox59.Left = 18.0625F;
        this.textBox59.Name = "textBox59";
        this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
        this.textBox59.Style = "";
        this.textBox59.Text = "textBox59";
        this.textBox59.Top = 0F;
        this.textBox59.Width = 0.9375F;
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
        this.textBox60.DataField = "efectivo_seguro";
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 20F;
        this.textBox60.Name = "textBox60";
        this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
        this.textBox60.Style = "";
        this.textBox60.Text = "textBox60";
        this.textBox60.Top = 0F;
        this.textBox60.Width = 0.875F;
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
        this.textBox61.DataField = "efectivo_mantenimiento";
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 20.9375F;
        this.textBox61.Name = "textBox61";
        this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
        this.textBox61.Style = "";
        this.textBox61.Text = "textBox61";
        this.textBox61.Top = 0F;
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
        this.textBox62.DataField = "efectivo_mora";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 19.0625F;
        this.textBox62.Name = "textBox62";
        this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
        this.textBox62.Style = "";
        this.textBox62.Text = "textBox62";
        this.textBox62.Top = 0F;
        this.textBox62.Width = 0.875F;
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
        this.textBox63.DataField = "efectivo_servicios";
        this.textBox63.Height = 0.1875F;
        this.textBox63.Left = 21.875F;
        this.textBox63.Name = "textBox63";
        this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
        this.textBox63.Style = "";
        this.textBox63.Text = "textBox63";
        this.textBox63.Top = 0F;
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
        this.textBox64.DataField = "ventas_mes";
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 22.8125F;
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
        this.textBox65.DataField = "saldo_revertido";
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 23.8125F;
        this.textBox65.Name = "textBox65";
        this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
        this.textBox65.Style = "";
        this.textBox65.Text = "textBox65";
        this.textBox65.Top = 0F;
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
        this.textBox66.DataField = "ingreso_tramites";
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 24.8125F;
        this.textBox66.Name = "textBox66";
        this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
        this.textBox66.Style = "";
        this.textBox66.Text = "textBox66";
        this.textBox66.Top = 0F;
        this.textBox66.Width = 0.9375F;
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
        this.textBox67.DataField = "libro_ventas";
        this.textBox67.Height = 0.1875F;
        this.textBox67.Left = 25.8125F;
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
        this.textBox68.DataField = "debito_fiscal";
        this.textBox68.Height = 0.1875F;
        this.textBox68.Left = 26.8125F;
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
        this.textBox69.DataField = "importe_neto";
        this.textBox69.Height = 0.1875F;
        this.textBox69.Left = 27.8125F;
        this.textBox69.Name = "textBox69";
        this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
        this.textBox69.Style = "";
        this.textBox69.Text = "textBox69";
        this.textBox69.Top = 0F;
        this.textBox69.Width = 0.9375F;
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
        this.textBox1.Left = 24.8125F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "textBox1";
        this.textBox1.Top = 0.0625F;
        this.textBox1.Width = 3.9375F;
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
        this.textBox2.Text = "Composición de cuota";
        this.textBox2.Top = 0.3125F;
        this.textBox2.Width = 28.6875F;
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
        this.textBox3.Left = 12.3125F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "Desde:";
        this.textBox3.Top = 0.5F;
        this.textBox3.Width = 0.875F;
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
        this.textBox4.Left = 13.25F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "textBox4";
        this.textBox4.Top = 0.5F;
        this.textBox4.Width = 2.75F;
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
        this.textBox5.Left = 12.3125F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "Hasta:";
        this.textBox5.Top = 0.6875F;
        this.textBox5.Width = 0.875F;
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
        this.textBox6.Left = 13.25F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "textBox6";
        this.textBox6.Top = 0.6875F;
        this.textBox6.Width = 2.75F;
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
        this.textBox7.Left = 12.3125F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = "Negocio:";
        this.textBox7.Top = 0.875F;
        this.textBox7.Width = 0.875F;
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
        this.textBox8.Left = 13.25F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "textBox8";
        this.textBox8.Top = 0.875F;
        this.textBox8.Width = 2.75F;
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
            this.picture1,
            this.textBox128,
            this.textBox129,
            this.textBox130,
            this.textBox131});
        this.reportHeader1.Height = 1.447917F;
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
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox127,
            this.line2,
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
            this.textBox123});
        this.reportFooter1.Height = 0.34375F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.textBox127.Height = 0.1875F;
        this.textBox127.Left = 0.0625F;
        this.textBox127.Name = "textBox127";
        this.textBox127.Style = "";
        this.textBox127.Text = "TOTAL:";
        this.textBox127.Top = 0.125F;
        this.textBox127.Width = 0.875F;
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
        this.line2.Width = 28.6875F;
        this.line2.X1 = 0.0625F;
        this.line2.X2 = 28.75F;
        this.line2.Y1 = 0.0625F;
        this.line2.Y2 = 0.0625F;
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
        this.textBox97.DataField = "pagos_total";
        this.textBox97.Height = 0.1875F;
        this.textBox97.Left = 2.5625F;
        this.textBox97.Name = "textBox97";
        this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
        this.textBox97.Style = "";
        this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox97.Text = "textBox97";
        this.textBox97.Top = 0.125F;
        this.textBox97.Width = 0.9375F;
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
        this.textBox98.DataField = "pagos_capital";
        this.textBox98.Height = 0.1875F;
        this.textBox98.Left = 3.5625F;
        this.textBox98.Name = "textBox98";
        this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
        this.textBox98.Style = "";
        this.textBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox98.Text = "textBox98";
        this.textBox98.Top = 0.125F;
        this.textBox98.Width = 0.9375F;
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
        this.textBox99.DataField = "pagos_interes";
        this.textBox99.Height = 0.1875F;
        this.textBox99.Left = 4.5625F;
        this.textBox99.Name = "textBox99";
        this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
        this.textBox99.Style = "";
        this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox100.DataField = "pagos_seguro";
        this.textBox100.Height = 0.1875F;
        this.textBox100.Left = 6.5F;
        this.textBox100.Name = "textBox100";
        this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
        this.textBox100.Style = "";
        this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox100.Text = "textBox100";
        this.textBox100.Top = 0.125F;
        this.textBox100.Width = 0.875F;
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
        this.textBox101.DataField = "pagos_mantenimiento";
        this.textBox101.Height = 0.1875F;
        this.textBox101.Left = 7.4375F;
        this.textBox101.Name = "textBox101";
        this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
        this.textBox101.Style = "";
        this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox101.Text = "textBox101";
        this.textBox101.Top = 0.125F;
        this.textBox101.Width = 0.875F;
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
        this.textBox102.DataField = "pagos_mora";
        this.textBox102.Height = 0.1875F;
        this.textBox102.Left = 5.5625F;
        this.textBox102.Name = "textBox102";
        this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
        this.textBox102.Style = "";
        this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox102.Text = "textBox102";
        this.textBox102.Top = 0.125F;
        this.textBox102.Width = 0.875F;
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
        this.textBox103.DataField = "pagos_servicios";
        this.textBox103.Height = 0.1875F;
        this.textBox103.Left = 8.375F;
        this.textBox103.Name = "textBox103";
        this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
        this.textBox103.Style = "";
        this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox103.Text = "textBox103";
        this.textBox103.Top = 0.125F;
        this.textBox103.Width = 0.875F;
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
        this.textBox104.DataField = "dpr_total";
        this.textBox104.Height = 0.1875F;
        this.textBox104.Left = 9.3125F;
        this.textBox104.Name = "textBox104";
        this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
        this.textBox104.Style = "";
        this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox104.Text = "textBox104";
        this.textBox104.Top = 0.125F;
        this.textBox104.Width = 0.9375F;
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
        this.textBox105.DataField = "dpr_capital";
        this.textBox105.Height = 0.1875F;
        this.textBox105.Left = 10.3125F;
        this.textBox105.Name = "textBox105";
        this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
        this.textBox105.Style = "";
        this.textBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox105.Text = "textBox105";
        this.textBox105.Top = 0.125F;
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
        this.textBox106.DataField = "dpr_interes";
        this.textBox106.Height = 0.1875F;
        this.textBox106.Left = 11.3125F;
        this.textBox106.Name = "textBox106";
        this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
        this.textBox106.Style = "";
        this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox106.Text = "textBox106";
        this.textBox106.Top = 0.125F;
        this.textBox106.Width = 0.9375F;
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
        this.textBox107.DataField = "dpr_seguro";
        this.textBox107.Height = 0.1875F;
        this.textBox107.Left = 13.25F;
        this.textBox107.Name = "textBox107";
        this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
        this.textBox107.Style = "";
        this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox107.Text = "textBox107";
        this.textBox107.Top = 0.125F;
        this.textBox107.Width = 0.875F;
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
        this.textBox108.DataField = "dpr_mantenimiento";
        this.textBox108.Height = 0.1875F;
        this.textBox108.Left = 14.1875F;
        this.textBox108.Name = "textBox108";
        this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
        this.textBox108.Style = "";
        this.textBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox108.Text = "textBox108";
        this.textBox108.Top = 0.125F;
        this.textBox108.Width = 0.875F;
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
        this.textBox109.DataField = "dpr_mora";
        this.textBox109.Height = 0.1875F;
        this.textBox109.Left = 12.3125F;
        this.textBox109.Name = "textBox109";
        this.textBox109.OutputFormat = resources.GetString("textBox109.OutputFormat");
        this.textBox109.Style = "";
        this.textBox109.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox109.Text = "textBox109";
        this.textBox109.Top = 0.125F;
        this.textBox109.Width = 0.875F;
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
        this.textBox110.DataField = "dpr_servicios";
        this.textBox110.Height = 0.1875F;
        this.textBox110.Left = 15.125F;
        this.textBox110.Name = "textBox110";
        this.textBox110.OutputFormat = resources.GetString("textBox110.OutputFormat");
        this.textBox110.Style = "";
        this.textBox110.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox110.Text = "textBox110";
        this.textBox110.Top = 0.125F;
        this.textBox110.Width = 0.875F;
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
        this.textBox111.DataField = "efectivo_total";
        this.textBox111.Height = 0.1875F;
        this.textBox111.Left = 16.0625F;
        this.textBox111.Name = "textBox111";
        this.textBox111.OutputFormat = resources.GetString("textBox111.OutputFormat");
        this.textBox111.Style = "";
        this.textBox111.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox111.Text = "textBox111";
        this.textBox111.Top = 0.125F;
        this.textBox111.Width = 0.9375F;
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
        this.textBox112.DataField = "efectivo_capital";
        this.textBox112.Height = 0.1875F;
        this.textBox112.Left = 17.0625F;
        this.textBox112.Name = "textBox112";
        this.textBox112.OutputFormat = resources.GetString("textBox112.OutputFormat");
        this.textBox112.Style = "";
        this.textBox112.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox112.Text = "textBox112";
        this.textBox112.Top = 0.125F;
        this.textBox112.Width = 0.9375F;
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
        this.textBox113.DataField = "efectivo_interes";
        this.textBox113.Height = 0.1875F;
        this.textBox113.Left = 18.0625F;
        this.textBox113.Name = "textBox113";
        this.textBox113.OutputFormat = resources.GetString("textBox113.OutputFormat");
        this.textBox113.Style = "";
        this.textBox113.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox113.Text = "textBox113";
        this.textBox113.Top = 0.125F;
        this.textBox113.Width = 0.9375F;
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
        this.textBox114.DataField = "efectivo_seguro";
        this.textBox114.Height = 0.1875F;
        this.textBox114.Left = 20F;
        this.textBox114.Name = "textBox114";
        this.textBox114.OutputFormat = resources.GetString("textBox114.OutputFormat");
        this.textBox114.Style = "";
        this.textBox114.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox114.Text = "textBox114";
        this.textBox114.Top = 0.125F;
        this.textBox114.Width = 0.875F;
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
        this.textBox115.DataField = "efectivo_mantenimiento";
        this.textBox115.Height = 0.1875F;
        this.textBox115.Left = 20.9375F;
        this.textBox115.Name = "textBox115";
        this.textBox115.OutputFormat = resources.GetString("textBox115.OutputFormat");
        this.textBox115.Style = "";
        this.textBox115.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox115.Text = "textBox115";
        this.textBox115.Top = 0.125F;
        this.textBox115.Width = 0.875F;
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
        this.textBox116.DataField = "efectivo_mora";
        this.textBox116.Height = 0.1875F;
        this.textBox116.Left = 19.0625F;
        this.textBox116.Name = "textBox116";
        this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
        this.textBox116.Style = "";
        this.textBox116.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox116.Text = "textBox116";
        this.textBox116.Top = 0.125F;
        this.textBox116.Width = 0.875F;
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
        this.textBox117.DataField = "efectivo_servicios";
        this.textBox117.Height = 0.1875F;
        this.textBox117.Left = 21.875F;
        this.textBox117.Name = "textBox117";
        this.textBox117.OutputFormat = resources.GetString("textBox117.OutputFormat");
        this.textBox117.Style = "";
        this.textBox117.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox117.Text = "textBox117";
        this.textBox117.Top = 0.125F;
        this.textBox117.Width = 0.875F;
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
        this.textBox118.DataField = "ventas_mes";
        this.textBox118.Height = 0.1875F;
        this.textBox118.Left = 22.8125F;
        this.textBox118.Name = "textBox118";
        this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
        this.textBox118.Style = "";
        this.textBox118.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox118.Text = "textBox118";
        this.textBox118.Top = 0.125F;
        this.textBox118.Width = 0.9375F;
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
        this.textBox119.DataField = "saldo_revertido";
        this.textBox119.Height = 0.1875F;
        this.textBox119.Left = 23.8125F;
        this.textBox119.Name = "textBox119";
        this.textBox119.OutputFormat = resources.GetString("textBox119.OutputFormat");
        this.textBox119.Style = "";
        this.textBox119.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox120.DataField = "ingreso_tramites";
        this.textBox120.Height = 0.1875F;
        this.textBox120.Left = 24.8125F;
        this.textBox120.Name = "textBox120";
        this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
        this.textBox120.Style = "";
        this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox120.Text = "textBox120";
        this.textBox120.Top = 0.125F;
        this.textBox120.Width = 0.9375F;
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
        this.textBox121.DataField = "libro_ventas";
        this.textBox121.Height = 0.1875F;
        this.textBox121.Left = 25.8125F;
        this.textBox121.Name = "textBox121";
        this.textBox121.OutputFormat = resources.GetString("textBox121.OutputFormat");
        this.textBox121.Style = "";
        this.textBox121.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox121.Text = "textBox121";
        this.textBox121.Top = 0.125F;
        this.textBox121.Width = 0.9375F;
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
        this.textBox122.DataField = "debito_fiscal";
        this.textBox122.Height = 0.1875F;
        this.textBox122.Left = 26.8125F;
        this.textBox122.Name = "textBox122";
        this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
        this.textBox122.Style = "";
        this.textBox122.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox123.DataField = "importe_neto";
        this.textBox123.Height = 0.1875F;
        this.textBox123.Left = 27.8125F;
        this.textBox123.Name = "textBox123";
        this.textBox123.OutputFormat = resources.GetString("textBox123.OutputFormat");
        this.textBox123.Style = "";
        this.textBox123.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox123.Text = "textBox123";
        this.textBox123.Top = 0.125F;
        this.textBox123.Width = 0.9375F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox124,
            this.textBox125});
        this.groupHeader1.DataField = "negocio";
        this.groupHeader1.Height = 0.1875F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox124.Left = 0.0625F;
        this.textBox124.Name = "textBox124";
        this.textBox124.Style = "";
        this.textBox124.Text = "Negocio:";
        this.textBox124.Top = 0F;
        this.textBox124.Width = 0.875F;
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
        this.textBox125.DataField = "negocio";
        this.textBox125.Height = 0.1875F;
        this.textBox125.Left = 1F;
        this.textBox125.Name = "textBox125";
        this.textBox125.Style = "";
        this.textBox125.Text = "textBox125";
        this.textBox125.Top = 0F;
        this.textBox125.Width = 8.25F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox126,
            this.line1,
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
            this.textBox96});
        this.groupFooter1.Height = 0.53125F;
        this.groupFooter1.Name = "groupFooter1";
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
        this.textBox126.Left = 0.0625F;
        this.textBox126.Name = "textBox126";
        this.textBox126.Style = "";
        this.textBox126.Text = "Sub Total:";
        this.textBox126.Top = 0.125F;
        this.textBox126.Width = 0.875F;
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
        this.line1.Width = 28.6875F;
        this.line1.X1 = 0.0625F;
        this.line1.X2 = 28.75F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
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
        this.textBox70.DataField = "pagos_total";
        this.textBox70.Height = 0.1875F;
        this.textBox70.Left = 2.5625F;
        this.textBox70.Name = "textBox70";
        this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
        this.textBox70.Style = "";
        this.textBox70.SummaryGroup = "groupHeader1";
        this.textBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox70.Text = "textBox70";
        this.textBox70.Top = 0.125F;
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
        this.textBox71.DataField = "pagos_capital";
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 3.5625F;
        this.textBox71.Name = "textBox71";
        this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
        this.textBox71.Style = "";
        this.textBox71.SummaryGroup = "groupHeader1";
        this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox71.Text = "textBox71";
        this.textBox71.Top = 0.125F;
        this.textBox71.Width = 0.9375F;
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
        this.textBox72.DataField = "pagos_interes";
        this.textBox72.Height = 0.1875F;
        this.textBox72.Left = 4.5625F;
        this.textBox72.Name = "textBox72";
        this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
        this.textBox72.Style = "";
        this.textBox72.SummaryGroup = "groupHeader1";
        this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox72.Text = "textBox72";
        this.textBox72.Top = 0.125F;
        this.textBox72.Width = 0.9375F;
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
        this.textBox73.DataField = "pagos_seguro";
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 6.5F;
        this.textBox73.Name = "textBox73";
        this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
        this.textBox73.Style = "";
        this.textBox73.SummaryGroup = "groupHeader1";
        this.textBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox73.Text = "textBox73";
        this.textBox73.Top = 0.125F;
        this.textBox73.Width = 0.875F;
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
        this.textBox74.DataField = "pagos_mantenimiento";
        this.textBox74.Height = 0.1875F;
        this.textBox74.Left = 7.4375F;
        this.textBox74.Name = "textBox74";
        this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
        this.textBox74.Style = "";
        this.textBox74.SummaryGroup = "groupHeader1";
        this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox74.Text = "textBox74";
        this.textBox74.Top = 0.125F;
        this.textBox74.Width = 0.875F;
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
        this.textBox75.DataField = "pagos_mora";
        this.textBox75.Height = 0.1875F;
        this.textBox75.Left = 5.5625F;
        this.textBox75.Name = "textBox75";
        this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
        this.textBox75.Style = "";
        this.textBox75.SummaryGroup = "groupHeader1";
        this.textBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox75.Text = "textBox75";
        this.textBox75.Top = 0.125F;
        this.textBox75.Width = 0.875F;
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
        this.textBox76.DataField = "pagos_servicios";
        this.textBox76.Height = 0.1875F;
        this.textBox76.Left = 8.375F;
        this.textBox76.Name = "textBox76";
        this.textBox76.OutputFormat = resources.GetString("textBox76.OutputFormat");
        this.textBox76.Style = "";
        this.textBox76.SummaryGroup = "groupHeader1";
        this.textBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox76.Text = "textBox76";
        this.textBox76.Top = 0.125F;
        this.textBox76.Width = 0.875F;
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
        this.textBox77.DataField = "dpr_total";
        this.textBox77.Height = 0.1875F;
        this.textBox77.Left = 9.3125F;
        this.textBox77.Name = "textBox77";
        this.textBox77.OutputFormat = resources.GetString("textBox77.OutputFormat");
        this.textBox77.Style = "";
        this.textBox77.SummaryGroup = "groupHeader1";
        this.textBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox77.Text = "textBox77";
        this.textBox77.Top = 0.125F;
        this.textBox77.Width = 0.9375F;
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
        this.textBox78.DataField = "dpr_capital";
        this.textBox78.Height = 0.1875F;
        this.textBox78.Left = 10.3125F;
        this.textBox78.Name = "textBox78";
        this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
        this.textBox78.Style = "";
        this.textBox78.SummaryGroup = "groupHeader1";
        this.textBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox78.Text = "textBox78";
        this.textBox78.Top = 0.125F;
        this.textBox78.Width = 0.9375F;
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
        this.textBox79.DataField = "dpr_interes";
        this.textBox79.Height = 0.1875F;
        this.textBox79.Left = 11.3125F;
        this.textBox79.Name = "textBox79";
        this.textBox79.OutputFormat = resources.GetString("textBox79.OutputFormat");
        this.textBox79.Style = "";
        this.textBox79.SummaryGroup = "groupHeader1";
        this.textBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox79.Text = "textBox79";
        this.textBox79.Top = 0.125F;
        this.textBox79.Width = 0.9375F;
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
        this.textBox80.DataField = "dpr_seguro";
        this.textBox80.Height = 0.1875F;
        this.textBox80.Left = 13.25F;
        this.textBox80.Name = "textBox80";
        this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
        this.textBox80.Style = "";
        this.textBox80.SummaryGroup = "groupHeader1";
        this.textBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox80.Text = "textBox80";
        this.textBox80.Top = 0.125F;
        this.textBox80.Width = 0.875F;
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
        this.textBox81.DataField = "dpr_mantenimiento";
        this.textBox81.Height = 0.1875F;
        this.textBox81.Left = 14.1875F;
        this.textBox81.Name = "textBox81";
        this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
        this.textBox81.Style = "";
        this.textBox81.SummaryGroup = "groupHeader1";
        this.textBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox81.Text = "textBox81";
        this.textBox81.Top = 0.125F;
        this.textBox81.Width = 0.875F;
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
        this.textBox82.DataField = "dpr_mora";
        this.textBox82.Height = 0.1875F;
        this.textBox82.Left = 12.3125F;
        this.textBox82.Name = "textBox82";
        this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
        this.textBox82.Style = "";
        this.textBox82.SummaryGroup = "groupHeader1";
        this.textBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox82.Text = "textBox82";
        this.textBox82.Top = 0.125F;
        this.textBox82.Width = 0.875F;
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
        this.textBox83.DataField = "dpr_servicios";
        this.textBox83.Height = 0.1875F;
        this.textBox83.Left = 15.125F;
        this.textBox83.Name = "textBox83";
        this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
        this.textBox83.Style = "";
        this.textBox83.SummaryGroup = "groupHeader1";
        this.textBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox83.Text = "textBox83";
        this.textBox83.Top = 0.125F;
        this.textBox83.Width = 0.875F;
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
        this.textBox84.DataField = "efectivo_total";
        this.textBox84.Height = 0.1875F;
        this.textBox84.Left = 16.0625F;
        this.textBox84.Name = "textBox84";
        this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
        this.textBox84.Style = "";
        this.textBox84.SummaryGroup = "groupHeader1";
        this.textBox84.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox84.Text = "textBox84";
        this.textBox84.Top = 0.125F;
        this.textBox84.Width = 0.9375F;
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
        this.textBox85.DataField = "efectivo_capital";
        this.textBox85.Height = 0.1875F;
        this.textBox85.Left = 17.0625F;
        this.textBox85.Name = "textBox85";
        this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
        this.textBox85.Style = "";
        this.textBox85.SummaryGroup = "groupHeader1";
        this.textBox85.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox85.Text = "textBox85";
        this.textBox85.Top = 0.125F;
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
        this.textBox86.DataField = "efectivo_interes";
        this.textBox86.Height = 0.1875F;
        this.textBox86.Left = 18.0625F;
        this.textBox86.Name = "textBox86";
        this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
        this.textBox86.Style = "";
        this.textBox86.SummaryGroup = "groupHeader1";
        this.textBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox86.Text = "textBox86";
        this.textBox86.Top = 0.125F;
        this.textBox86.Width = 0.9375F;
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
        this.textBox87.DataField = "efectivo_seguro";
        this.textBox87.Height = 0.1875F;
        this.textBox87.Left = 20F;
        this.textBox87.Name = "textBox87";
        this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
        this.textBox87.Style = "";
        this.textBox87.SummaryGroup = "groupHeader1";
        this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox87.Text = "textBox87";
        this.textBox87.Top = 0.125F;
        this.textBox87.Width = 0.875F;
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
        this.textBox88.DataField = "efectivo_mantenimiento";
        this.textBox88.Height = 0.1875F;
        this.textBox88.Left = 20.9375F;
        this.textBox88.Name = "textBox88";
        this.textBox88.OutputFormat = resources.GetString("textBox88.OutputFormat");
        this.textBox88.Style = "";
        this.textBox88.SummaryGroup = "groupHeader1";
        this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox88.Text = "textBox88";
        this.textBox88.Top = 0.125F;
        this.textBox88.Width = 0.875F;
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
        this.textBox89.DataField = "efectivo_mora";
        this.textBox89.Height = 0.1875F;
        this.textBox89.Left = 19.0625F;
        this.textBox89.Name = "textBox89";
        this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
        this.textBox89.Style = "";
        this.textBox89.SummaryGroup = "groupHeader1";
        this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox89.Text = "textBox89";
        this.textBox89.Top = 0.125F;
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
        this.textBox90.DataField = "efectivo_servicios";
        this.textBox90.Height = 0.1875F;
        this.textBox90.Left = 21.875F;
        this.textBox90.Name = "textBox90";
        this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
        this.textBox90.Style = "";
        this.textBox90.SummaryGroup = "groupHeader1";
        this.textBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox90.Text = "textBox90";
        this.textBox90.Top = 0.125F;
        this.textBox90.Width = 0.875F;
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
        this.textBox91.DataField = "ventas_mes";
        this.textBox91.Height = 0.1875F;
        this.textBox91.Left = 22.8125F;
        this.textBox91.Name = "textBox91";
        this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
        this.textBox91.Style = "";
        this.textBox91.SummaryGroup = "groupHeader1";
        this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox91.Text = "textBox91";
        this.textBox91.Top = 0.125F;
        this.textBox91.Width = 0.9375F;
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
        this.textBox92.DataField = "saldo_revertido";
        this.textBox92.Height = 0.1875F;
        this.textBox92.Left = 23.8125F;
        this.textBox92.Name = "textBox92";
        this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
        this.textBox92.Style = "";
        this.textBox92.SummaryGroup = "groupHeader1";
        this.textBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox92.Text = "textBox92";
        this.textBox92.Top = 0.125F;
        this.textBox92.Width = 0.9375F;
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
        this.textBox93.DataField = "ingreso_tramites";
        this.textBox93.Height = 0.1875F;
        this.textBox93.Left = 24.8125F;
        this.textBox93.Name = "textBox93";
        this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
        this.textBox93.Style = "";
        this.textBox93.SummaryGroup = "groupHeader1";
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
        this.textBox94.DataField = "libro_ventas";
        this.textBox94.Height = 0.1875F;
        this.textBox94.Left = 25.8125F;
        this.textBox94.Name = "textBox94";
        this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
        this.textBox94.Style = "";
        this.textBox94.SummaryGroup = "groupHeader1";
        this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox94.Text = "textBox94";
        this.textBox94.Top = 0.125F;
        this.textBox94.Width = 0.9375F;
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
        this.textBox95.DataField = "debito_fiscal";
        this.textBox95.Height = 0.1875F;
        this.textBox95.Left = 26.8125F;
        this.textBox95.Name = "textBox95";
        this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
        this.textBox95.Style = "";
        this.textBox95.SummaryGroup = "groupHeader1";
        this.textBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox95.Text = "textBox95";
        this.textBox95.Top = 0.125F;
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
        this.textBox96.DataField = "importe_neto";
        this.textBox96.Height = 0.1875F;
        this.textBox96.Left = 27.8125F;
        this.textBox96.Name = "textBox96";
        this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
        this.textBox96.Style = "";
        this.textBox96.SummaryGroup = "groupHeader1";
        this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox96.Text = "textBox96";
        this.textBox96.Top = 0.125F;
        this.textBox96.Width = 0.9375F;
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
        this.textBox128.Height = 0.1875F;
        this.textBox128.Left = 12.3125F;
        this.textBox128.Name = "textBox128";
        this.textBox128.Style = "";
        this.textBox128.Text = "MONEDA:";
        this.textBox128.Top = 1.0625F;
        this.textBox128.Width = 0.875F;
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
        this.textBox129.Height = 0.1875F;
        this.textBox129.Left = 13.25F;
        this.textBox129.Name = "textBox129";
        this.textBox129.Style = "";
        this.textBox129.Text = "textBox129";
        this.textBox129.Top = 1.0625F;
        this.textBox129.Width = 2.75F;
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
        this.textBox130.Height = 0.1875F;
        this.textBox130.Left = 12.3125F;
        this.textBox130.Name = "textBox130";
        this.textBox130.Style = "";
        this.textBox130.Text = "DATOS:";
        this.textBox130.Top = 1.25F;
        this.textBox130.Width = 0.875F;
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
        this.textBox131.Left = 13.25F;
        this.textBox131.Name = "textBox131";
        this.textBox131.Style = "";
        this.textBox131.Text = "textBox131";
        this.textBox131.Top = 1.25F;
        this.textBox131.Width = 2.75F;
        // 
        // rpt_composicion_cuota
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 28.82292F;
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
        this.ReportStart += new System.EventHandler(this.rpt_composicion_cuota_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

}
