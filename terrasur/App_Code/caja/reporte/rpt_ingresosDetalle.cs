using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document; 
using System.Web;
        
/// <summary>    
/// Summary description for rpt_ingresosDetalle.
/// </summary>
public class rpt_ingresosDetalle : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
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
    private TextBox textBox15;
    private TextBox textBox16;
    private TextBox textBox17;
    private TextBox textBox18;
    private TextBox textBox19;
    private TextBox textBox26;
    private TextBox textBox28;
    private TextBox textBox29;
    private TextBox textBox30;
    private TextBox textBox31;
    private TextBox textBox32;
    private TextBox textBox33;
    private TextBox textBox37;
    private TextBox textBox38;
    private TextBox textBox39;
    private TextBox textBox40;
    private TextBox textBox41;
    private TextBox textBox48;
    private TextBox textBox49;
    private TextBox textBox50;
    private TextBox textBox54;
    private TextBox textBox55;
    private TextBox textBox56;
    private TextBox textBox57;
    private TextBox textBox58;
    private TextBox textBox65;
    private Shape shape1;
    private Shape shape2;
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
    private TextBox textBox86;
    private TextBox textBox87;
    private TextBox textBox88;
    private TextBox textBox89;
    private TextBox textBox91;
    private TextBox textBox83;
    private TextBox textBox84;
    private TextBox textBox85;
    private TextBox textBox90;
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
    private Shape shape3;
    private TextBox textBox112;
    private TextBox textBox113;
    private TextBox textBox114;
    private TextBox textBox116;
    private TextBox textBox117;
    private TextBox textBox120;
    private TextBox textBox122;
    private TextBox textBox123;
    private TextBox textBox124;
    private TextBox textBox125;
    private TextBox textBox126;
    private TextBox textBox127;
    private TextBox textBox128;
    private TextBox textBox129;
    private TextBox textBox130;
    private TextBox textBox119;
    private TextBox textBox132;
    private TextBox textBox133;
    private TextBox textBox34;
    private TextBox textBox134;
    private TextBox textBox135;
    private TextBox textBox137;
    private TextBox textBox138;
    private TextBox textBox139;
    private TextBox textBox140;
    private TextBox textBox141;
    private TextBox textBox142;
    private TextBox textBox143;
    private TextBox textBox144;
    private TextBox textBox145;
    private TextBox textBox51;
    private TextBox textBox148;
    private TextBox textBox151;
    private TextBox textBox152;
    private TextBox textBox153;
    private TextBox textBox154;
    private TextBox textBox155;
    private TextBox textBox156;
    private TextBox textBox163;
    private TextBox textBox121;
    private TextBox textBox131;
    private TextBox textBox146;
    private Picture picture1;
    private Line line2;
    private Line line1;
    private TextBox textBox27;
    private GroupHeader groupHeader2;
    private TextBox textBox111;
    private TextBox textBox118;
    private GroupFooter groupFooter2;
    private TextBox textBox147;
    private TextBox textBox164;
    private TextBox textBox165;
    private TextBox textBox166;
    private TextBox textBox167;
    private TextBox textBox170;
    private TextBox textBox171;
    private TextBox textBox172;
    private TextBox textBox173;
    private TextBox textBox175;
    private TextBox textBox176;
    private Line line3;
    private TextBox textBox13;
    private TextBox textBox14;
    private TextBox textBox20;
    private TextBox textBox21;
    private TextBox textBox22;
    private TextBox textBox23;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox textBox35;
    private TextBox textBox36;
    private TextBox textBox42;
    private Shape shape4;
    private TextBox textBox43;
    private TextBox textBox44;
    private TextBox textBox45;
    private TextBox textBox46;
    private TextBox textBox47;
    private TextBox textBox52;
    private TextBox textBox53;
    private TextBox textBox59;
    private TextBox textBox60;
    private TextBox textBox61;
    private TextBox textBox62;
    private Line line4;
    private Shape shape5;
    private TextBox textBox63;
    private TextBox textBox64;
    private TextBox textBox115;
    private TextBox textBox136;
    private TextBox textBox149;
    private TextBox textBox150;
    private TextBox textBox157;
    private TextBox textBox183;
    private TextBox textBox158;
    private TextBox textBox159;
    private TextBox textBox160;
    private TextBox textBox161;
    private TextBox textBox162;
    private TextBox textBox168;
    private TextBox textBox169;
    private TextBox textBox174;
    private TextBox textBox177;
    private TextBox textBox178;
    private TextBox textBox181;
    private TextBox textBox180;
    private TextBox textBox179;
    private TextBox textBox182;
    private TextBox textBox184;
    private TextBox textBox185;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_ingresosDetalle()
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
    public void Encabezado(string Sucursal, DateTime Desde, DateTime Hasta, int Id_usuario, int Formapago, string Negocio, int Num_recibo_min, int Num_recibo_max, string Moneda, string Consolidado, string Codigo_moneda)
    {
        textBox21.Text = Sucursal;
        if (Id_usuario > 0)
        {
            terrasur.usuario usrObj = new terrasur.usuario(Id_usuario);
            textBox9.Text = usrObj.nombres + " " + usrObj.paterno + " " + usrObj.materno;
        }
        else { textBox9.Text = "Todos"; }
        textBox3.Text = Desde.ToString("d");
        textBox5.Text = Hasta.ToString("d");
        if (Formapago > 0)
        {
            if (Formapago == 1) { textBox7.Text = "Efectivo"; }
            if (Formapago == 2) { textBox7.Text = "DPR"; }
        }
        else { textBox7.Text = "Todos"; }

        textBox121.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox146.Text = Negocio;

        textBox35.Text = Num_recibo_min.ToString();
        textBox42.Text = Num_recibo_max.ToString();

        textBox168.Text = Moneda;
        textBox174.Text = Consolidado;

        textBox70.Text = Codigo_moneda;
        textBox73.Text = Codigo_moneda;
        textBox76.Text = Codigo_moneda;
        textBox79.Text = Codigo_moneda;
        textBox82.Text = Codigo_moneda;
        textBox109.Text = Codigo_moneda;
        textBox88.Text = Codigo_moneda;
        textBox115.Text = "Consolidado en " + Codigo_moneda;
    }
    private void rpt_ingresosDetalle_ReportStart(object sender, EventArgs e)
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
        textBox121.ClassName = "estiloFecha";

        textBox1.ClassName = "estiloTitulo";
        textBox2.ClassName = "estiloEncabEnun";
        textBox3.ClassName = "estiloEncabDato";
        textBox4.ClassName = "estiloEncabEnun";
        textBox5.ClassName = "estiloEncabDato";
        textBox6.ClassName = "estiloEncabEnun";
        textBox7.ClassName = "estiloEncabDato";
        textBox20.ClassName = "estiloEncabEnun";
        textBox21.ClassName = "estiloEncabDato";

        textBox162.ClassName = "estiloEncabEnun";
        textBox168.ClassName = "estiloEncabDato";

        textBox169.ClassName = "estiloEncabEnun";
        textBox174.ClassName = "estiloEncabDato";

        textBox8.ClassName = "estiloEncabEnun";
        textBox9.ClassName = "estiloEncabDato";
        textBox131.ClassName = "estiloEncabEnun";
        textBox146.ClassName = "estiloEncabDato";
        textBox10.ClassName = "estiloDetalleEnun";
        textBox11.ClassName = "estiloDetalleEnun";
        textBox13.ClassName = "estiloDetalleEnun";
        textBox12.ClassName = "estiloDetalleEnun";
        textBox15.ClassName = "estiloDetalleEnun";
        textBox16.ClassName = "estiloDetalleEnun";
        textBox177.ClassName = "estiloDetalleEnun";
        textBox17.ClassName = "estiloDetalleEnun";
        textBox18.ClassName = "estiloDetalleEnun";
        textBox19.ClassName = "estiloDetalleEnun";
        textBox26.ClassName = "estiloDetalleEnun";
        textBox157.ClassName = "estiloDetalleEnun";
        textBox28.ClassName = "estiloDetalleGrupo";
        textBox29.ClassName = "estiloDetalleGrupo";
        textBox30.ClassName = "estiloDetalleGrupo";
        textBox31.ClassName = "estiloDetalleGrupo";
        textBox32.ClassName = "estiloDetalleDatoString";
        textBox33.ClassName = "estiloDetalleDato";
        textBox14.ClassName = "estiloDetalleDato";
        textBox34.ClassName = "estiloDetalleDato";
        textBox37.ClassName = "estiloDetalleDato";
        textBox38.ClassName = "estiloDetalleDato";
        textBox178.ClassName = "estiloDetalleDato";
        textBox39.ClassName = "estiloDetalleDato";
        textBox40.ClassName = "estiloDetalleDato";
        textBox41.ClassName = "estiloDetalleDato";
        textBox48.ClassName = "estiloDetalleDato";
        textBox158.ClassName = "estiloDetalleDato";
        textBox49.ClassName = "estiloTotalEnun";
        textBox50.ClassName = "estiloTotal";
        textBox51.ClassName = "estiloTotal";
        textBox54.ClassName = "estiloTotal";
        textBox55.ClassName = "estiloTotal";
        textBox181.ClassName = "estiloTotal";
        textBox185.ClassName = "estiloTotal";
        textBox56.ClassName = "estiloTotal";
        textBox57.ClassName = "estiloTotal";
        textBox58.ClassName = "estiloTotal";
        textBox65.ClassName = "estiloTotal";
        textBox161.ClassName = "estiloTotal";
        textBox66.ClassName = "estiloGrupoEnun";
        textBox67.ClassName = "estiloEncabEnun";
        textBox68.ClassName = "estiloEncabEnun";
        textBox69.ClassName = "estiloTotal";
        textBox70.ClassName = "estiloTotal";
        textBox71.ClassName = "estiloEncabEnun";
        textBox72.ClassName = "estiloTotal";
        textBox73.ClassName = "estiloTotal";
        textBox74.ClassName = "estiloEncabEnun";
        textBox75.ClassName = "estiloTotal";
        textBox76.ClassName = "estiloTotal";
        textBox77.ClassName = "estiloEncabEnun";
        textBox78.ClassName = "estiloTotal";
        textBox79.ClassName = "estiloTotal";
        textBox80.ClassName = "estiloEncabEnun";
        textBox81.ClassName = "estiloTotal";
        textBox82.ClassName = "estiloTotal";
        textBox83.ClassName = "estiloGrupoEnun";
        textBox84.ClassName = "estiloEncabEnun";
        textBox85.ClassName = "estiloEncabEnun";
        textBox86.ClassName = "estiloEncabEnun";
        textBox87.ClassName = "estiloTotal";
        textBox88.ClassName = "estiloTotal";
        textBox89.ClassName = "estiloEncabEnun";
        textBox90.ClassName = "estiloEncabEnun";
        textBox91.ClassName = "estiloEncabEnun";
        textBox92.ClassName = "estiloEncabEnun";
        textBox93.ClassName = "estiloTotal";
        textBox94.ClassName = "estiloTotal";
        textBox95.ClassName = "estiloEncabEnun";
        textBox96.ClassName = "estiloTotal";
        textBox97.ClassName = "estiloTotal";
        textBox98.ClassName = "estiloEncabEnun";
        textBox99.ClassName = "estiloTotal";
        textBox100.ClassName = "estiloTotal";
        textBox101.ClassName = "estiloEncabEnun";
        textBox102.ClassName = "estiloTotal";
        textBox103.ClassName = "estiloTotal";
        textBox104.ClassName = "estiloEncabEnun";
        textBox105.ClassName = "estiloTotal";
        textBox106.ClassName = "estiloTotal";
        textBox107.ClassName = "estiloEncabEnun";
        textBox108.ClassName = "estiloTotal";
        textBox109.ClassName = "estiloTotal";
        textBox110.ClassName = "estiloEncabEnun";
        textBox112.ClassName = "estiloDetalleEnun";
        textBox113.ClassName = "estiloDetalleEnun";
        textBox114.ClassName = "estiloDetalleEnun";
        textBox116.ClassName = "estiloDetalleEnun";
        textBox147.ClassName = "estiloDetalleEnun";
        textBox117.ClassName = "estiloDetalleEnun";
        
        textBox27.ClassName = "estiloGrupoEnun";
        textBox119.ClassName = "estiloGrupoEnun";
        textBox120.ClassName = "estiloDetalleGrupo";
        //textBox121.ClassName = "estiloGrupoEnun";
        textBox122.ClassName = "estiloDetalleGrupo";
        textBox123.ClassName = "estiloDetalleEnun";
        textBox124.ClassName = "estiloDetalleEnun";
        textBox125.ClassName = "estiloDetalleGrupo";
        textBox126.ClassName = "estiloDetalleEnun";
        textBox127.ClassName = "estiloDetalleEnun";
        textBox128.ClassName = "estiloDetalleEnun";
        textBox129.ClassName = "estiloDetalleEnun";
        textBox22.ClassName = "estiloDetalleEnun";
        textBox130.ClassName = "estiloDetalleGrupo";
        //textBox131.ClassName = "estiloGrupoEnun";
        textBox132.ClassName = "estiloSubtotalEnun";
        textBox133.ClassName = "estiloSubtotalEnun";
        textBox134.ClassName = "estiloDetalleDato";
        textBox135.ClassName = "estiloDetalleDatoString";
        textBox137.ClassName = "estiloDetalleDatoString";
        textBox138.ClassName = "estiloDetalleDatoString";
        textBox139.ClassName = "estiloDetalleDato";
        textBox140.ClassName = "estiloDetalleDato";
        textBox141.ClassName = "estiloDetalleDatoString";
        textBox142.ClassName = "estiloDetalleDato";
        textBox143.ClassName = "estiloDetalleDato";
        textBox144.ClassName = "estiloDetalleDato";
        textBox145.ClassName = "estiloDetalleDato";
        textBox23.ClassName = "estiloDetalleDato";
        //textBox146.ClassName = "estiloSubtotal";
        //textBox147.ClassName = "estiloSubtotal";
        textBox148.ClassName = "estiloSubtotal";
        textBox151.ClassName = "estiloSubtotal";
        textBox152.ClassName = "estiloSubtotal";
        textBox180.ClassName = "estiloSubtotal";
        textBox184.ClassName = "estiloSubtotal";
        textBox153.ClassName = "estiloSubtotal";
        textBox154.ClassName = "estiloSubtotal";
        textBox155.ClassName = "estiloSubtotal";
        textBox156.ClassName = "estiloSubtotal";
        textBox163.ClassName = "estiloSubtotal";
        textBox160.ClassName = "estiloSubtotal";

        textBox111.ClassName = "estiloGrupoEnun";
        textBox118.ClassName = "estiloGrupoEnun";
        textBox165.ClassName = "estiloSubtotalEnun";
        textBox166.ClassName = "estiloSubtotalEnun";

        textBox167.ClassName = "estiloSubtotal";
        textBox170.ClassName = "estiloSubtotal";
        textBox171.ClassName = "estiloSubtotal";
        textBox179.ClassName = "estiloSubtotal";
        textBox182.ClassName = "estiloSubtotal";
        textBox172.ClassName = "estiloSubtotal";
        textBox173.ClassName = "estiloSubtotal";
        textBox175.ClassName = "estiloSubtotal";
        textBox176.ClassName = "estiloSubtotal";
        textBox183.ClassName = "estiloSubtotal";
        textBox159.ClassName = "estiloSubtotal";


        textBox24.ClassName = "estiloGrupoEnun";
        textBox25.ClassName = "estiloEncabEnun";
        textBox35.ClassName = "estiloTotal";
        textBox36.ClassName = "estiloEncabEnun";
        textBox42.ClassName = "estiloTotal";


        textBox43.ClassName = "estiloGrupoEnun";

        textBox44.ClassName = "estiloEncabEnun";
        textBox45.ClassName = "estiloTotal";
        textBox46.ClassName = "estiloEncabEnun";

        textBox47.ClassName = "estiloEncabEnun";
        textBox52.ClassName = "estiloTotal";
        textBox53.ClassName = "estiloEncabEnun";

        textBox60.ClassName = "estiloEncabEnun";
        textBox61.ClassName = "estiloTotal";
        textBox62.ClassName = "estiloTotal";
        textBox63.ClassName = "estiloTotal";
        textBox64.ClassName = "estiloTotal";

        textBox59.ClassName = "estiloNota";

        textBox115.ClassName = "estiloEncabEnun";
        textBox136.ClassName = "estiloTotal";
        textBox149.ClassName = "estiloTotal";
        textBox150.ClassName = "estiloTotal";

   }
	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_ingresosDetalle));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox120 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox112 = new DataDynamics.ActiveReports.TextBox();
        this.textBox113 = new DataDynamics.ActiveReports.TextBox();
        this.textBox114 = new DataDynamics.ActiveReports.TextBox();
        this.textBox116 = new DataDynamics.ActiveReports.TextBox();
        this.textBox117 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox122 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.textBox123 = new DataDynamics.ActiveReports.TextBox();
        this.textBox124 = new DataDynamics.ActiveReports.TextBox();
        this.textBox125 = new DataDynamics.ActiveReports.TextBox();
        this.textBox127 = new DataDynamics.ActiveReports.TextBox();
        this.textBox129 = new DataDynamics.ActiveReports.TextBox();
        this.textBox128 = new DataDynamics.ActiveReports.TextBox();
        this.textBox126 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox130 = new DataDynamics.ActiveReports.TextBox();
        this.textBox147 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox157 = new DataDynamics.ActiveReports.TextBox();
        this.textBox177 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.textBox48 = new DataDynamics.ActiveReports.TextBox();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox134 = new DataDynamics.ActiveReports.TextBox();
        this.textBox135 = new DataDynamics.ActiveReports.TextBox();
        this.textBox137 = new DataDynamics.ActiveReports.TextBox();
        this.textBox138 = new DataDynamics.ActiveReports.TextBox();
        this.textBox139 = new DataDynamics.ActiveReports.TextBox();
        this.textBox140 = new DataDynamics.ActiveReports.TextBox();
        this.textBox141 = new DataDynamics.ActiveReports.TextBox();
        this.textBox142 = new DataDynamics.ActiveReports.TextBox();
        this.textBox143 = new DataDynamics.ActiveReports.TextBox();
        this.textBox144 = new DataDynamics.ActiveReports.TextBox();
        this.textBox145 = new DataDynamics.ActiveReports.TextBox();
        this.textBox164 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox158 = new DataDynamics.ActiveReports.TextBox();
        this.textBox178 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox121 = new DataDynamics.ActiveReports.TextBox();
        this.textBox131 = new DataDynamics.ActiveReports.TextBox();
        this.textBox146 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox162 = new DataDynamics.ActiveReports.TextBox();
        this.textBox168 = new DataDynamics.ActiveReports.TextBox();
        this.textBox169 = new DataDynamics.ActiveReports.TextBox();
        this.textBox174 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.shape2 = new DataDynamics.ActiveReports.Shape();
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
        this.textBox86 = new DataDynamics.ActiveReports.TextBox();
        this.textBox87 = new DataDynamics.ActiveReports.TextBox();
        this.textBox88 = new DataDynamics.ActiveReports.TextBox();
        this.textBox89 = new DataDynamics.ActiveReports.TextBox();
        this.textBox91 = new DataDynamics.ActiveReports.TextBox();
        this.textBox83 = new DataDynamics.ActiveReports.TextBox();
        this.textBox84 = new DataDynamics.ActiveReports.TextBox();
        this.textBox85 = new DataDynamics.ActiveReports.TextBox();
        this.textBox90 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox105 = new DataDynamics.ActiveReports.TextBox();
        this.textBox106 = new DataDynamics.ActiveReports.TextBox();
        this.textBox107 = new DataDynamics.ActiveReports.TextBox();
        this.textBox108 = new DataDynamics.ActiveReports.TextBox();
        this.textBox109 = new DataDynamics.ActiveReports.TextBox();
        this.textBox110 = new DataDynamics.ActiveReports.TextBox();
        this.shape3 = new DataDynamics.ActiveReports.Shape();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox50 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
        this.textBox65 = new DataDynamics.ActiveReports.TextBox();
        this.textBox51 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.shape4 = new DataDynamics.ActiveReports.Shape();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        this.textBox47 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.textBox59 = new DataDynamics.ActiveReports.TextBox();
        this.textBox60 = new DataDynamics.ActiveReports.TextBox();
        this.textBox61 = new DataDynamics.ActiveReports.TextBox();
        this.textBox62 = new DataDynamics.ActiveReports.TextBox();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.shape5 = new DataDynamics.ActiveReports.Shape();
        this.textBox63 = new DataDynamics.ActiveReports.TextBox();
        this.textBox64 = new DataDynamics.ActiveReports.TextBox();
        this.textBox115 = new DataDynamics.ActiveReports.TextBox();
        this.textBox136 = new DataDynamics.ActiveReports.TextBox();
        this.textBox149 = new DataDynamics.ActiveReports.TextBox();
        this.textBox150 = new DataDynamics.ActiveReports.TextBox();
        this.textBox161 = new DataDynamics.ActiveReports.TextBox();
        this.textBox181 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox119 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox132 = new DataDynamics.ActiveReports.TextBox();
        this.textBox133 = new DataDynamics.ActiveReports.TextBox();
        this.textBox148 = new DataDynamics.ActiveReports.TextBox();
        this.textBox151 = new DataDynamics.ActiveReports.TextBox();
        this.textBox152 = new DataDynamics.ActiveReports.TextBox();
        this.textBox153 = new DataDynamics.ActiveReports.TextBox();
        this.textBox154 = new DataDynamics.ActiveReports.TextBox();
        this.textBox155 = new DataDynamics.ActiveReports.TextBox();
        this.textBox156 = new DataDynamics.ActiveReports.TextBox();
        this.textBox163 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox160 = new DataDynamics.ActiveReports.TextBox();
        this.textBox180 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox111 = new DataDynamics.ActiveReports.TextBox();
        this.textBox118 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox165 = new DataDynamics.ActiveReports.TextBox();
        this.textBox166 = new DataDynamics.ActiveReports.TextBox();
        this.textBox167 = new DataDynamics.ActiveReports.TextBox();
        this.textBox170 = new DataDynamics.ActiveReports.TextBox();
        this.textBox171 = new DataDynamics.ActiveReports.TextBox();
        this.textBox172 = new DataDynamics.ActiveReports.TextBox();
        this.textBox173 = new DataDynamics.ActiveReports.TextBox();
        this.textBox175 = new DataDynamics.ActiveReports.TextBox();
        this.textBox176 = new DataDynamics.ActiveReports.TextBox();
        this.textBox183 = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.textBox159 = new DataDynamics.ActiveReports.TextBox();
        this.textBox179 = new DataDynamics.ActiveReports.TextBox();
        this.textBox182 = new DataDynamics.ActiveReports.TextBox();
        this.textBox184 = new DataDynamics.ActiveReports.TextBox();
        this.textBox185 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox157)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox177)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox134)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox135)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox137)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox138)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox139)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox140)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox141)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox142)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox143)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox144)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox164)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox158)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox178)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox162)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox168)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox169)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox174)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox86)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox87)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox83)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox84)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox85)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox90)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox136)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox150)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox161)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox181)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox132)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox133)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox153)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox154)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox155)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox156)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox163)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox160)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox180)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox165)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox166)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox167)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox170)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox171)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox172)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox173)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox175)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox176)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox183)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox159)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox179)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox182)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox184)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox185)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox10,
            this.textBox12,
            this.textBox120,
            this.textBox28,
            this.textBox29,
            this.textBox112,
            this.textBox113,
            this.textBox114,
            this.textBox116,
            this.textBox117,
            this.textBox11,
            this.textBox122,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox30,
            this.textBox31,
            this.textBox123,
            this.textBox124,
            this.textBox125,
            this.textBox127,
            this.textBox129,
            this.textBox128,
            this.textBox126,
            this.textBox26,
            this.textBox130,
            this.textBox147,
            this.textBox13,
            this.textBox22,
            this.textBox157,
            this.textBox177});
        this.pageHeader.Height = 0.5104167F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox10.Left = 0.0625F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Tipo de  Pago";
        this.textBox10.Top = 0.1875F;
        this.textBox10.Width = 1.1875F;
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
        this.textBox12.Left = 7.625F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Seguro Desgr.";
        this.textBox12.Top = 0.1875F;
        this.textBox12.Width = 0.625F;
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
        this.textBox120.Height = 0.1875F;
        this.textBox120.Left = 2.8125F;
        this.textBox120.Name = "textBox120";
        this.textBox120.Style = "text-align: center; ";
        this.textBox120.Text = "Cliente";
        this.textBox120.Top = 0F;
        this.textBox120.Width = 1F;
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
        this.textBox28.Left = 6.1875F;
        this.textBox28.Name = "textBox28";
        this.textBox28.Style = "text-align: center; ";
        this.textBox28.Text = "Transacción";
        this.textBox28.Top = 0F;
        this.textBox28.Width = 1.375F;
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
        this.textBox29.Left = 7.6875F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "text-align: center; ";
        this.textBox29.Text = "Pago";
        this.textBox29.Top = 0F;
        this.textBox29.Width = 3.0625F;
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
        this.textBox112.Left = 1.25F;
        this.textBox112.Name = "textBox112";
        this.textBox112.Style = "";
        this.textBox112.Text = "Nº contrato";
        this.textBox112.Top = 0.1875F;
        this.textBox112.Width = 0.6875F;
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
        this.textBox113.Left = 1.9375F;
        this.textBox113.Name = "textBox113";
        this.textBox113.Style = "";
        this.textBox113.Text = "Fecha";
        this.textBox113.Top = 0.1875F;
        this.textBox113.Width = 0.8125F;
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
        this.textBox114.Left = 2.8125F;
        this.textBox114.Name = "textBox114";
        this.textBox114.Style = "";
        this.textBox114.Text = "Paterno";
        this.textBox114.Top = 0.1875F;
        this.textBox114.Width = 1F;
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
        this.textBox116.Height = 0.3125F;
        this.textBox116.Left = 5F;
        this.textBox116.Name = "textBox116";
        this.textBox116.Style = "";
        this.textBox116.Text = "Mzn";
        this.textBox116.Top = 0.1875F;
        this.textBox116.Width = 0.4375F;
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
        this.textBox117.Height = 0.3125F;
        this.textBox117.Left = 5.5F;
        this.textBox117.Name = "textBox117";
        this.textBox117.Style = "";
        this.textBox117.Text = "Lote";
        this.textBox117.Top = 0.1875F;
        this.textBox117.Width = 0.5625F;
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
        this.textBox11.Left = 6.125F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Monto";
        this.textBox11.Top = 0.1875F;
        this.textBox11.Width = 1F;
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
        this.textBox122.Height = 0.1875F;
        this.textBox122.Left = 3.875F;
        this.textBox122.Name = "textBox122";
        this.textBox122.Style = "text-align: center; ";
        this.textBox122.Text = "Lote";
        this.textBox122.Top = 0F;
        this.textBox122.Width = 2.1875F;
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
        this.textBox15.Left = 8.875F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = "Interés Corriente";
        this.textBox15.Top = 0.1875F;
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
        this.textBox16.Left = 9.8125F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Capital";
        this.textBox16.Top = 0.1875F;
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
        this.textBox17.Left = 10.8125F;
        this.textBox17.Name = "textBox17";
        this.textBox17.Style = "";
        this.textBox17.Text = "Int. Penal";
        this.textBox17.Top = 0.1875F;
        this.textBox17.Width = 0.625F;
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
        this.textBox18.Left = 13.0625F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "Efectivo $us";
        this.textBox18.Top = 0.1875F;
        this.textBox18.Width = 0.75F;
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
        this.textBox19.Left = 13.8125F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "Efectivo Bs.";
        this.textBox19.Top = 0.1875F;
        this.textBox19.Width = 0.75F;
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
        this.textBox30.Left = 10.875F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "text-align: center; ";
        this.textBox30.Text = "Mora";
        this.textBox30.Top = 0F;
        this.textBox30.Width = 0.5625F;
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
        this.textBox31.Left = 13.125F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "text-align: center; ";
        this.textBox31.Text = "Forma de pago";
        this.textBox31.Top = 0F;
        this.textBox31.Width = 2.9375F;
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
        this.textBox123.Height = 0.3125F;
        this.textBox123.Left = 11.5F;
        this.textBox123.Name = "textBox123";
        this.textBox123.Style = "";
        this.textBox123.Text = "Servicio Monto";
        this.textBox123.Top = 0.1875F;
        this.textBox123.Width = 0.875F;
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
        this.textBox124.Height = 0.3125F;
        this.textBox124.Left = 12.375F;
        this.textBox124.Name = "textBox124";
        this.textBox124.Style = "";
        this.textBox124.Text = "Servicio Código";
        this.textBox124.Top = 0.1875F;
        this.textBox124.Width = 0.625F;
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
        this.textBox125.Left = 11.5625F;
        this.textBox125.Name = "textBox125";
        this.textBox125.Style = "text-align: center; ";
        this.textBox125.Text = "Otros servicios";
        this.textBox125.Top = 0F;
        this.textBox125.Width = 1.4375F;
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
        this.textBox127.Height = 0.3125F;
        this.textBox127.Left = 16.8125F;
        this.textBox127.Name = "textBox127";
        this.textBox127.Style = "";
        this.textBox127.Text = "Nº recibo";
        this.textBox127.Top = 0.1875F;
        this.textBox127.Width = 0.625F;
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
        this.textBox129.Height = 0.3125F;
        this.textBox129.Left = 18.0625F;
        this.textBox129.Name = "textBox129";
        this.textBox129.Style = "";
        this.textBox129.Text = "Nº recibo cobrador";
        this.textBox129.Top = 0.1875F;
        this.textBox129.Width = 0.6875F;
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
        this.textBox128.Height = 0.3125F;
        this.textBox128.Left = 17.4375F;
        this.textBox128.Name = "textBox128";
        this.textBox128.Style = "";
        this.textBox128.Text = "Nº factura";
        this.textBox128.Top = 0.1875F;
        this.textBox128.Width = 0.625F;
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
        this.textBox126.Height = 0.3125F;
        this.textBox126.Left = 16.125F;
        this.textBox126.Name = "textBox126";
        this.textBox126.Style = "";
        this.textBox126.Text = "Nº Comp. DPR";
        this.textBox126.Top = 0.1875F;
        this.textBox126.Width = 0.6875F;
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
        this.textBox26.Left = 14.5625F;
        this.textBox26.Name = "textBox26";
        this.textBox26.Style = "";
        this.textBox26.Text = "DPR $us";
        this.textBox26.Top = 0.1875F;
        this.textBox26.Width = 0.75F;
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
        this.textBox130.Left = 16.125F;
        this.textBox130.Name = "textBox130";
        this.textBox130.Style = "text-align: center; ";
        this.textBox130.Text = "Documentos";
        this.textBox130.Top = 0F;
        this.textBox130.Width = 2.625F;
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
        this.textBox147.Height = 0.3125F;
        this.textBox147.Left = 3.8125F;
        this.textBox147.Name = "textBox147";
        this.textBox147.Style = "";
        this.textBox147.Text = "Sector";
        this.textBox147.Top = 0.1875F;
        this.textBox147.Width = 1.1875F;
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
        this.textBox13.Left = 7.125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "T/C";
        this.textBox13.Top = 0.1875F;
        this.textBox13.Width = 0.4375F;
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
        this.textBox22.Left = 18.8125F;
        this.textBox22.Name = "textBox22";
        this.textBox22.Style = "";
        this.textBox22.Text = "Suc.";
        this.textBox22.Top = 0.1875F;
        this.textBox22.Width = 0.3125F;
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
        this.textBox157.Height = 0.3125F;
        this.textBox157.Left = 15.3125F;
        this.textBox157.Name = "textBox157";
        this.textBox157.Style = "";
        this.textBox157.Text = "DPR Bs.";
        this.textBox157.Top = 0.1875F;
        this.textBox157.Width = 0.75F;
        // 
        // textBox177
        // 
        this.textBox177.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox177.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox177.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox177.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox177.Border.RightColor = System.Drawing.Color.Black;
        this.textBox177.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox177.Border.TopColor = System.Drawing.Color.Black;
        this.textBox177.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox177.Height = 0.3125F;
        this.textBox177.Left = 8.25F;
        this.textBox177.Name = "textBox177";
        this.textBox177.Style = "";
        this.textBox177.Text = "Manten.";
        this.textBox177.Top = 0.1875F;
        this.textBox177.Width = 0.625F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox32,
            this.textBox33,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox48,
            this.textBox34,
            this.textBox134,
            this.textBox135,
            this.textBox137,
            this.textBox138,
            this.textBox139,
            this.textBox140,
            this.textBox141,
            this.textBox142,
            this.textBox143,
            this.textBox144,
            this.textBox145,
            this.textBox164,
            this.textBox14,
            this.textBox23,
            this.textBox158,
            this.textBox178});
        this.detail.Height = 0.1979167F;
        this.detail.Name = "detail";
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
        this.textBox32.DataField = "tipo_pago";
        this.textBox32.Height = 0.1875F;
        this.textBox32.Left = 0.0625F;
        this.textBox32.Name = "textBox32";
        this.textBox32.Style = "";
        this.textBox32.Text = null;
        this.textBox32.Top = 0F;
        this.textBox32.Width = 1.1875F;
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
        this.textBox33.DataField = "monto_pago";
        this.textBox33.Height = 0.1979167F;
        this.textBox33.Left = 6.125F;
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
        this.textBox33.Style = "";
        this.textBox33.Text = null;
        this.textBox33.Top = 0F;
        this.textBox33.Width = 1F;
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
        this.textBox37.DataField = "interes";
        this.textBox37.Height = 0.1875F;
        this.textBox37.Left = 8.875F;
        this.textBox37.Name = "textBox37";
        this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
        this.textBox37.Style = "";
        this.textBox37.Text = null;
        this.textBox37.Top = 0F;
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
        this.textBox38.DataField = "amortizacion";
        this.textBox38.Height = 0.1875F;
        this.textBox38.Left = 9.8125F;
        this.textBox38.Name = "textBox38";
        this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
        this.textBox38.Style = "";
        this.textBox38.Text = null;
        this.textBox38.Top = 0F;
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
        this.textBox39.DataField = "interes_penal";
        this.textBox39.Height = 0.1875F;
        this.textBox39.Left = 10.8125F;
        this.textBox39.Name = "textBox39";
        this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
        this.textBox39.Style = "";
        this.textBox39.Text = null;
        this.textBox39.Top = 0F;
        this.textBox39.Width = 0.625F;
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
        this.textBox40.DataField = "efe_sus";
        this.textBox40.Height = 0.1875F;
        this.textBox40.Left = 13.0625F;
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
        this.textBox40.Style = "";
        this.textBox40.Text = null;
        this.textBox40.Top = 0F;
        this.textBox40.Width = 0.75F;
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
        this.textBox41.DataField = "efe_bs";
        this.textBox41.Height = 0.1875F;
        this.textBox41.Left = 13.8125F;
        this.textBox41.Name = "textBox41";
        this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
        this.textBox41.Style = "";
        this.textBox41.Text = null;
        this.textBox41.Top = 0F;
        this.textBox41.Width = 0.75F;
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
        this.textBox48.DataField = "dpr_sus";
        this.textBox48.Height = 0.1875F;
        this.textBox48.Left = 14.5625F;
        this.textBox48.Name = "textBox48";
        this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
        this.textBox48.Style = "";
        this.textBox48.Text = null;
        this.textBox48.Top = 0F;
        this.textBox48.Width = 0.75F;
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
        this.textBox34.DataField = "contrato_numero";
        this.textBox34.Height = 0.1875F;
        this.textBox34.Left = 1.25F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = null;
        this.textBox34.Top = 0F;
        this.textBox34.Width = 0.6875F;
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
        this.textBox134.DataField = "fecha_pago";
        this.textBox134.Height = 0.1875F;
        this.textBox134.Left = 1.9375F;
        this.textBox134.Name = "textBox134";
        this.textBox134.OutputFormat = resources.GetString("textBox134.OutputFormat");
        this.textBox134.Style = "";
        this.textBox134.Text = null;
        this.textBox134.Top = 0F;
        this.textBox134.Width = 0.8125F;
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
        this.textBox135.DataField = "paterno_cliente";
        this.textBox135.Height = 0.1979167F;
        this.textBox135.Left = 2.8125F;
        this.textBox135.Name = "textBox135";
        this.textBox135.Style = "";
        this.textBox135.Text = null;
        this.textBox135.Top = 0F;
        this.textBox135.Width = 1F;
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
        this.textBox137.DataField = "manzano_codigo";
        this.textBox137.Height = 0.1875F;
        this.textBox137.Left = 5F;
        this.textBox137.Name = "textBox137";
        this.textBox137.Style = "";
        this.textBox137.Text = null;
        this.textBox137.Top = 0F;
        this.textBox137.Width = 0.4375F;
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
        this.textBox138.DataField = "lote_codigo";
        this.textBox138.Height = 0.1875F;
        this.textBox138.Left = 5.5F;
        this.textBox138.Name = "textBox138";
        this.textBox138.Style = "";
        this.textBox138.Text = null;
        this.textBox138.Top = 0F;
        this.textBox138.Width = 0.5625F;
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
        this.textBox139.DataField = "seguro";
        this.textBox139.Height = 0.1875F;
        this.textBox139.Left = 7.625F;
        this.textBox139.Name = "textBox139";
        this.textBox139.OutputFormat = resources.GetString("textBox139.OutputFormat");
        this.textBox139.Style = "";
        this.textBox139.Text = null;
        this.textBox139.Top = 0F;
        this.textBox139.Width = 0.625F;
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
        this.textBox140.DataField = "servicio_monto";
        this.textBox140.Height = 0.1875F;
        this.textBox140.Left = 11.5F;
        this.textBox140.Name = "textBox140";
        this.textBox140.OutputFormat = resources.GetString("textBox140.OutputFormat");
        this.textBox140.Style = "";
        this.textBox140.Text = null;
        this.textBox140.Top = 0F;
        this.textBox140.Width = 0.875F;
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
        this.textBox141.DataField = "servicio_codigo";
        this.textBox141.Height = 0.1875F;
        this.textBox141.Left = 12.375F;
        this.textBox141.Name = "textBox141";
        this.textBox141.Style = "";
        this.textBox141.Text = null;
        this.textBox141.Top = 0F;
        this.textBox141.Width = 0.625F;
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
        this.textBox142.DataField = "num_comprobante";
        this.textBox142.Height = 0.1875F;
        this.textBox142.Left = 16.125F;
        this.textBox142.Name = "textBox142";
        this.textBox142.Style = "";
        this.textBox142.Text = null;
        this.textBox142.Top = 0F;
        this.textBox142.Width = 0.6875F;
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
        this.textBox143.DataField = "num_recibo";
        this.textBox143.Height = 0.1875F;
        this.textBox143.Left = 16.8125F;
        this.textBox143.Name = "textBox143";
        this.textBox143.Style = "";
        this.textBox143.Text = null;
        this.textBox143.Top = 0F;
        this.textBox143.Width = 0.625F;
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
        this.textBox144.DataField = "num_factura";
        this.textBox144.Height = 0.1875F;
        this.textBox144.Left = 17.4375F;
        this.textBox144.Name = "textBox144";
        this.textBox144.Style = "";
        this.textBox144.Text = null;
        this.textBox144.Top = 0F;
        this.textBox144.Width = 0.625F;
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
        this.textBox145.DataField = "num_control";
        this.textBox145.Height = 0.1875F;
        this.textBox145.Left = 18.0625F;
        this.textBox145.Name = "textBox145";
        this.textBox145.Style = "";
        this.textBox145.Text = null;
        this.textBox145.Top = 0F;
        this.textBox145.Width = 0.6875F;
        // 
        // textBox164
        // 
        this.textBox164.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox164.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox164.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox164.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox164.Border.RightColor = System.Drawing.Color.Black;
        this.textBox164.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox164.Border.TopColor = System.Drawing.Color.Black;
        this.textBox164.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox164.DataField = "urbanizacion_nombre";
        this.textBox164.Height = 0.1875F;
        this.textBox164.Left = 3.8125F;
        this.textBox164.Name = "textBox164";
        this.textBox164.Style = "";
        this.textBox164.Text = "textBox164";
        this.textBox164.Top = 0F;
        this.textBox164.Width = 1.0625F;
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
        this.textBox14.DataField = "tipo_cambio";
        this.textBox14.Height = 0.1875F;
        this.textBox14.Left = 7.125F;
        this.textBox14.Name = "textBox14";
        this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
        this.textBox14.Style = "";
        this.textBox14.Text = "textBox14";
        this.textBox14.Top = 0F;
        this.textBox14.Width = 0.4375F;
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
        this.textBox23.DataField = "num_sucursal";
        this.textBox23.Height = 0.1875F;
        this.textBox23.Left = 18.8125F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "textBox23";
        this.textBox23.Top = 0F;
        this.textBox23.Width = 0.3125F;
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
        this.textBox158.DataField = "dpr_bs";
        this.textBox158.Height = 0.1875F;
        this.textBox158.Left = 15.3125F;
        this.textBox158.Name = "textBox158";
        this.textBox158.OutputFormat = resources.GetString("textBox158.OutputFormat");
        this.textBox158.Style = "";
        this.textBox158.Text = "textBox158";
        this.textBox158.Top = 0F;
        this.textBox158.Width = 0.75F;
        // 
        // textBox178
        // 
        this.textBox178.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox178.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox178.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox178.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox178.Border.RightColor = System.Drawing.Color.Black;
        this.textBox178.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox178.Border.TopColor = System.Drawing.Color.Black;
        this.textBox178.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox178.DataField = "mantenimiento_sus";
        this.textBox178.Height = 0.1875F;
        this.textBox178.Left = 8.25F;
        this.textBox178.Name = "textBox178";
        this.textBox178.OutputFormat = resources.GetString("textBox178.OutputFormat");
        this.textBox178.Style = "";
        this.textBox178.Text = "textBox178";
        this.textBox178.Top = 0F;
        this.textBox178.Width = 0.625F;
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
            this.textBox121,
            this.textBox131,
            this.textBox146,
            this.picture1,
            this.textBox20,
            this.textBox21,
            this.textBox162,
            this.textBox168,
            this.textBox169,
            this.textBox174});
        this.reportHeader1.Height = 0.9270833F;
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
        this.textBox1.Left = 6.125F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "Reporte de ingresos en detalle";
        this.textBox1.Top = 0.3125F;
        this.textBox1.Width = 7.9375F;
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
        this.textBox2.Left = 1.9375F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Desde:";
        this.textBox2.Top = 0.6875F;
        this.textBox2.Width = 0.8125F;
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
        this.textBox3.Height = 0.1979167F;
        this.textBox3.Left = 2.8125F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = null;
        this.textBox3.Top = 0.6875F;
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
        this.textBox4.Left = 3.875F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Hasta:";
        this.textBox4.Top = 0.6875F;
        this.textBox4.Width = 1.125F;
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
        this.textBox5.Left = 5F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = null;
        this.textBox5.Top = 0.6875F;
        this.textBox5.Width = 1.0625F;
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
        this.textBox6.Left = 6.125F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "Forma de pago:";
        this.textBox6.Top = 0.6875F;
        this.textBox6.Width = 1.4375F;
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
        this.textBox7.Left = 7.625F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = null;
        this.textBox7.Top = 0.6875F;
        this.textBox7.Width = 2.5F;
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
        this.textBox8.Left = 10.8125F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Usuario:";
        this.textBox8.Top = 0.6875F;
        this.textBox8.Width = 0.625F;
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
        this.textBox9.Left = 11.5F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = null;
        this.textBox9.Top = 0.6875F;
        this.textBox9.Width = 1.75F;
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
        this.textBox121.Height = 0.1875F;
        this.textBox121.Left = 13.375F;
        this.textBox121.Name = "textBox121";
        this.textBox121.Style = "";
        this.textBox121.Text = null;
        this.textBox121.Top = 0.0625F;
        this.textBox121.Width = 5.75F;
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
        this.textBox131.Left = 13.3125F;
        this.textBox131.Name = "textBox131";
        this.textBox131.Style = "";
        this.textBox131.Text = "Negocio:";
        this.textBox131.Top = 0.6875F;
        this.textBox131.Width = 0.75F;
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
        this.textBox146.Height = 0.1875F;
        this.textBox146.Left = 14.0625F;
        this.textBox146.Name = "textBox146";
        this.textBox146.Style = "";
        this.textBox146.Text = null;
        this.textBox146.Top = 0.6875F;
        this.textBox146.Width = 4.6875F;
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
        this.textBox20.Left = 1.9375F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "Sucursal:";
        this.textBox20.Top = 0.5F;
        this.textBox20.Width = 0.8125F;
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
        this.textBox21.Left = 2.8125F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "textBox21";
        this.textBox21.Top = 0.5F;
        this.textBox21.Width = 3.25F;
        // 
        // textBox162
        // 
        this.textBox162.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox162.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox162.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox162.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox162.Border.RightColor = System.Drawing.Color.Black;
        this.textBox162.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox162.Border.TopColor = System.Drawing.Color.Black;
        this.textBox162.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox162.Height = 0.1875F;
        this.textBox162.Left = 6.125F;
        this.textBox162.Name = "textBox162";
        this.textBox162.Style = "";
        this.textBox162.Text = "MONEDA:";
        this.textBox162.Top = 0.5F;
        this.textBox162.Width = 1.4375F;
        // 
        // textBox168
        // 
        this.textBox168.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox168.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox168.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox168.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox168.Border.RightColor = System.Drawing.Color.Black;
        this.textBox168.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox168.Border.TopColor = System.Drawing.Color.Black;
        this.textBox168.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox168.Height = 0.1875F;
        this.textBox168.Left = 7.625F;
        this.textBox168.Name = "textBox168";
        this.textBox168.Style = "";
        this.textBox168.Text = "textBox168";
        this.textBox168.Top = 0.5F;
        this.textBox168.Width = 2.5F;
        // 
        // textBox169
        // 
        this.textBox169.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox169.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox169.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox169.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox169.Border.RightColor = System.Drawing.Color.Black;
        this.textBox169.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox169.Border.TopColor = System.Drawing.Color.Black;
        this.textBox169.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox169.Height = 0.1875F;
        this.textBox169.Left = 10.8125F;
        this.textBox169.Name = "textBox169";
        this.textBox169.Style = "";
        this.textBox169.Text = "DATOS:";
        this.textBox169.Top = 0.5F;
        this.textBox169.Width = 0.625F;
        // 
        // textBox174
        // 
        this.textBox174.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox174.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox174.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox174.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox174.Border.RightColor = System.Drawing.Color.Black;
        this.textBox174.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox174.Border.TopColor = System.Drawing.Color.Black;
        this.textBox174.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox174.Height = 0.1875F;
        this.textBox174.Left = 11.5F;
        this.textBox174.Name = "textBox174";
        this.textBox174.Style = "";
        this.textBox174.Text = "textBox174";
        this.textBox174.Top = 0.5F;
        this.textBox174.Width = 2.5625F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.shape2,
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
            this.textBox86,
            this.textBox87,
            this.textBox88,
            this.textBox89,
            this.textBox91,
            this.textBox83,
            this.textBox84,
            this.textBox85,
            this.textBox90,
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
            this.textBox105,
            this.textBox106,
            this.textBox107,
            this.textBox108,
            this.textBox109,
            this.textBox110,
            this.shape3,
            this.textBox49,
            this.textBox50,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
            this.textBox58,
            this.textBox65,
            this.textBox51,
            this.line2,
            this.textBox24,
            this.textBox25,
            this.textBox35,
            this.textBox36,
            this.textBox42,
            this.shape4,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox52,
            this.textBox53,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.line4,
            this.shape5,
            this.textBox63,
            this.textBox64,
            this.textBox115,
            this.textBox136,
            this.textBox149,
            this.textBox150,
            this.textBox161,
            this.textBox181,
            this.textBox185});
        this.reportFooter1.Height = 5.145833F;
        this.reportFooter1.Name = "reportFooter1";
        this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
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
        this.shape1.Height = 3.1875F;
        this.shape1.Left = 0F;
        this.shape1.Name = "shape1";
        this.shape1.RoundingRadius = 9.999999F;
        this.shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
        this.shape1.Top = 0.75F;
        this.shape1.Width = 3.75F;
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
        this.shape2.Height = 2.3125F;
        this.shape2.Left = 4.625F;
        this.shape2.Name = "shape2";
        this.shape2.RoundingRadius = 9.999999F;
        this.shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
        this.shape2.Top = 0.75F;
        this.shape2.Width = 3.75F;
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
        this.textBox66.Left = 0F;
        this.textBox66.Name = "textBox66";
        this.textBox66.Style = "";
        this.textBox66.Text = "Resumen General:";
        this.textBox66.Top = 0.5F;
        this.textBox66.Width = 2F;
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
        this.textBox67.Left = 0.1875F;
        this.textBox67.Name = "textBox67";
        this.textBox67.Style = "";
        this.textBox67.Text = "Pago";
        this.textBox67.Top = 0.875F;
        this.textBox67.Width = 2.8125F;
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
        this.textBox68.Height = 0.1875F;
        this.textBox68.Left = 0.375F;
        this.textBox68.Name = "textBox68";
        this.textBox68.Style = "";
        this.textBox68.Text = "Seguro de desgravamen:";
        this.textBox68.Top = 1.1875F;
        this.textBox68.Width = 1.625F;
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
        this.textBox69.DataField = "seguro";
        this.textBox69.Height = 0.1979167F;
        this.textBox69.Left = 2F;
        this.textBox69.Name = "textBox69";
        this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
        this.textBox69.Style = "";
        this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox69.Text = null;
        this.textBox69.Top = 1.1875F;
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
        this.textBox70.Height = 0.1875F;
        this.textBox70.Left = 3F;
        this.textBox70.Name = "textBox70";
        this.textBox70.Style = "";
        this.textBox70.Text = "$us";
        this.textBox70.Top = 1.1875F;
        this.textBox70.Width = 0.3125F;
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
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 0.375F;
        this.textBox71.Name = "textBox71";
        this.textBox71.Style = "";
        this.textBox71.Text = "Mantenimiento";
        this.textBox71.Top = 1.4375F;
        this.textBox71.Width = 1.625F;
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
        this.textBox72.DataField = "mantenimiento_sus";
        this.textBox72.Height = 0.1979167F;
        this.textBox72.Left = 2F;
        this.textBox72.Name = "textBox72";
        this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
        this.textBox72.Style = "";
        this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox72.Text = null;
        this.textBox72.Top = 1.4375F;
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
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 3F;
        this.textBox73.Name = "textBox73";
        this.textBox73.Style = "";
        this.textBox73.Text = "$us";
        this.textBox73.Top = 1.4375F;
        this.textBox73.Width = 0.3125F;
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
        this.textBox74.Left = 0.375F;
        this.textBox74.Name = "textBox74";
        this.textBox74.Style = "";
        this.textBox74.Text = "Interés corriente";
        this.textBox74.Top = 1.6875F;
        this.textBox74.Width = 1.625F;
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
        this.textBox75.DataField = "interes";
        this.textBox75.Height = 0.1979167F;
        this.textBox75.Left = 2F;
        this.textBox75.Name = "textBox75";
        this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
        this.textBox75.Style = "";
        this.textBox75.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox75.Text = null;
        this.textBox75.Top = 1.6875F;
        this.textBox75.Width = 1F;
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
        this.textBox76.Height = 0.1875F;
        this.textBox76.Left = 3F;
        this.textBox76.Name = "textBox76";
        this.textBox76.Style = "";
        this.textBox76.Text = "$us";
        this.textBox76.Top = 1.6875F;
        this.textBox76.Width = 0.3125F;
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
        this.textBox77.Height = 0.1875F;
        this.textBox77.Left = 0.375F;
        this.textBox77.Name = "textBox77";
        this.textBox77.Style = "";
        this.textBox77.Text = "Amortización a capital";
        this.textBox77.Top = 1.9375F;
        this.textBox77.Width = 1.625F;
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
        this.textBox78.DataField = "amortizacion";
        this.textBox78.Height = 0.1979167F;
        this.textBox78.Left = 2F;
        this.textBox78.Name = "textBox78";
        this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
        this.textBox78.Style = "";
        this.textBox78.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox78.Text = null;
        this.textBox78.Top = 1.9375F;
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
        this.textBox79.Height = 0.1875F;
        this.textBox79.Left = 3F;
        this.textBox79.Name = "textBox79";
        this.textBox79.Style = "";
        this.textBox79.Text = "$us";
        this.textBox79.Top = 1.9375F;
        this.textBox79.Width = 0.3125F;
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
        this.textBox80.Left = 0.375F;
        this.textBox80.Name = "textBox80";
        this.textBox80.Style = "";
        this.textBox80.Text = "Interés penal";
        this.textBox80.Top = 2.5F;
        this.textBox80.Width = 1.625F;
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
        this.textBox81.DataField = "interes_penal";
        this.textBox81.Height = 0.1979167F;
        this.textBox81.Left = 2F;
        this.textBox81.Name = "textBox81";
        this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
        this.textBox81.Style = "";
        this.textBox81.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox81.Text = null;
        this.textBox81.Top = 2.5F;
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
        this.textBox82.Height = 0.1875F;
        this.textBox82.Left = 3F;
        this.textBox82.Name = "textBox82";
        this.textBox82.Style = "";
        this.textBox82.Text = "$us";
        this.textBox82.Top = 2.5F;
        this.textBox82.Width = 0.3125F;
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
        this.textBox86.Height = 0.1875F;
        this.textBox86.Left = 0.375F;
        this.textBox86.Name = "textBox86";
        this.textBox86.Style = "";
        this.textBox86.Text = "Total general";
        this.textBox86.Top = 3.5625F;
        this.textBox86.Width = 1.625F;
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
        this.textBox87.DataField = "monto_pago";
        this.textBox87.Height = 0.1979167F;
        this.textBox87.Left = 2F;
        this.textBox87.Name = "textBox87";
        this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
        this.textBox87.Style = "";
        this.textBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox87.Text = null;
        this.textBox87.Top = 3.5625F;
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
        this.textBox88.Height = 0.1875F;
        this.textBox88.Left = 3F;
        this.textBox88.Name = "textBox88";
        this.textBox88.Style = "";
        this.textBox88.Text = "$us";
        this.textBox88.Top = 3.5625F;
        this.textBox88.Width = 0.3125F;
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
        this.textBox89.Height = 0.1875F;
        this.textBox89.Left = 0.1875F;
        this.textBox89.Name = "textBox89";
        this.textBox89.Style = "";
        this.textBox89.Text = "Mora";
        this.textBox89.Top = 2.25F;
        this.textBox89.Width = 2.8125F;
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
        this.textBox91.Height = 0.1875F;
        this.textBox91.Left = 0.1875F;
        this.textBox91.Name = "textBox91";
        this.textBox91.Style = "";
        this.textBox91.Text = "Totales";
        this.textBox91.Top = 3.3125F;
        this.textBox91.Width = 2.8125F;
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
        this.textBox83.Height = 0.1875F;
        this.textBox83.Left = 4.625F;
        this.textBox83.Name = "textBox83";
        this.textBox83.Style = "";
        this.textBox83.Text = "Resumen (Formas de pago)";
        this.textBox83.Top = 0.5F;
        this.textBox83.Width = 2.375F;
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
        this.textBox84.Height = 0.1979167F;
        this.textBox84.Left = 5F;
        this.textBox84.Name = "textBox84";
        this.textBox84.Style = "";
        this.textBox84.Text = "Forma de pago";
        this.textBox84.Top = 1.1875F;
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
        this.textBox85.Height = 0.1979167F;
        this.textBox85.Left = 6F;
        this.textBox85.Name = "textBox85";
        this.textBox85.Style = "text-align: center; ";
        this.textBox85.Text = "$us";
        this.textBox85.Top = 1.1875F;
        this.textBox85.Width = 1F;
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
        this.textBox90.Height = 0.1979167F;
        this.textBox90.Left = 7F;
        this.textBox90.Name = "textBox90";
        this.textBox90.Style = "text-align: center; ";
        this.textBox90.Text = "Bs.";
        this.textBox90.Top = 1.1875F;
        this.textBox90.Width = 1F;
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
        this.textBox92.Height = 0.1979167F;
        this.textBox92.Left = 5F;
        this.textBox92.Name = "textBox92";
        this.textBox92.Style = "";
        this.textBox92.Text = "Efectivo";
        this.textBox92.Top = 1.4375F;
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
        this.textBox93.DataField = "efectivo_sus";
        this.textBox93.Height = 0.1979167F;
        this.textBox93.Left = 6F;
        this.textBox93.Name = "textBox93";
        this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
        this.textBox93.Style = "";
        this.textBox93.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox93.Text = null;
        this.textBox93.Top = 1.4375F;
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
        this.textBox94.DataField = "efectivo_bs";
        this.textBox94.Height = 0.1979167F;
        this.textBox94.Left = 7F;
        this.textBox94.Name = "textBox94";
        this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
        this.textBox94.Style = "";
        this.textBox94.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox94.Text = null;
        this.textBox94.Top = 1.4375F;
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
        this.textBox95.Height = 0.1979167F;
        this.textBox95.Left = 5F;
        this.textBox95.Name = "textBox95";
        this.textBox95.Style = "";
        this.textBox95.Text = "Cheque";
        this.textBox95.Top = 1.6875F;
        this.textBox95.Width = 1F;
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
        this.textBox96.DataField = "cheque_sus";
        this.textBox96.Height = 0.1979167F;
        this.textBox96.Left = 6F;
        this.textBox96.Name = "textBox96";
        this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
        this.textBox96.Style = "";
        this.textBox96.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox96.Text = null;
        this.textBox96.Top = 1.6875F;
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
        this.textBox97.DataField = "cheque_bs";
        this.textBox97.Height = 0.1979167F;
        this.textBox97.Left = 7F;
        this.textBox97.Name = "textBox97";
        this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
        this.textBox97.Style = "";
        this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox97.Text = null;
        this.textBox97.Top = 1.6875F;
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
        this.textBox98.Height = 0.1979167F;
        this.textBox98.Left = 5F;
        this.textBox98.Name = "textBox98";
        this.textBox98.Style = "";
        this.textBox98.Text = "Tarjeta";
        this.textBox98.Top = 1.9375F;
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
        this.textBox99.DataField = "tarjeta_sus";
        this.textBox99.Height = 0.1979167F;
        this.textBox99.Left = 6F;
        this.textBox99.Name = "textBox99";
        this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
        this.textBox99.Style = "";
        this.textBox99.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox99.Text = null;
        this.textBox99.Top = 1.9375F;
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
        this.textBox100.DataField = "tarjeta_bs";
        this.textBox100.Height = 0.1979167F;
        this.textBox100.Left = 7F;
        this.textBox100.Name = "textBox100";
        this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
        this.textBox100.Style = "";
        this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox100.Text = null;
        this.textBox100.Top = 1.9375F;
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
        this.textBox101.Height = 0.1979167F;
        this.textBox101.Left = 5F;
        this.textBox101.Name = "textBox101";
        this.textBox101.Style = "";
        this.textBox101.Text = "Depósito";
        this.textBox101.Top = 2.25F;
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
        this.textBox102.DataField = "deposito_sus";
        this.textBox102.Height = 0.1979167F;
        this.textBox102.Left = 6F;
        this.textBox102.Name = "textBox102";
        this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
        this.textBox102.Style = "";
        this.textBox102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox102.Text = null;
        this.textBox102.Top = 2.25F;
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
        this.textBox103.DataField = "deposito_bs";
        this.textBox103.Height = 0.1979167F;
        this.textBox103.Left = 7F;
        this.textBox103.Name = "textBox103";
        this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
        this.textBox103.Style = "";
        this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox103.Text = null;
        this.textBox103.Top = 2.25F;
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
        this.textBox104.Height = 0.1979167F;
        this.textBox104.Left = 5F;
        this.textBox104.Name = "textBox104";
        this.textBox104.Style = "";
        this.textBox104.Text = "DPR";
        this.textBox104.Top = 2.5F;
        this.textBox104.Width = 1F;
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
        this.textBox105.DataField = "dpr_sus";
        this.textBox105.Height = 0.1979167F;
        this.textBox105.Left = 6F;
        this.textBox105.Name = "textBox105";
        this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
        this.textBox105.Style = "";
        this.textBox105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox105.Text = null;
        this.textBox105.Top = 2.5F;
        this.textBox105.Width = 1F;
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
        this.textBox106.DataField = "dpr_bs";
        this.textBox106.Height = 0.1979167F;
        this.textBox106.Left = 7F;
        this.textBox106.Name = "textBox106";
        this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
        this.textBox106.Style = "";
        this.textBox106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox106.Text = null;
        this.textBox106.Top = 2.5F;
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
        this.textBox107.Height = 0.1875F;
        this.textBox107.Left = 0.375F;
        this.textBox107.Name = "textBox107";
        this.textBox107.Style = "";
        this.textBox107.Text = "Otros servicios";
        this.textBox107.Top = 3.0625F;
        this.textBox107.Width = 1.625F;
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
        this.textBox108.DataField = "servicio_monto";
        this.textBox108.Height = 0.1979167F;
        this.textBox108.Left = 2F;
        this.textBox108.Name = "textBox108";
        this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
        this.textBox108.Style = "";
        this.textBox108.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox108.Text = null;
        this.textBox108.Top = 3.0625F;
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
        this.textBox109.Height = 0.1875F;
        this.textBox109.Left = 3F;
        this.textBox109.Name = "textBox109";
        this.textBox109.Style = "";
        this.textBox109.Text = "$us";
        this.textBox109.Top = 3.0625F;
        this.textBox109.Width = 0.3125F;
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
        this.textBox110.Height = 0.1875F;
        this.textBox110.Left = 0.1875F;
        this.textBox110.Name = "textBox110";
        this.textBox110.Style = "";
        this.textBox110.Text = "Servicios";
        this.textBox110.Top = 2.8125F;
        this.textBox110.Width = 2.8125F;
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
        this.shape3.Height = 1.625F;
        this.shape3.Left = 4.9375F;
        this.shape3.Name = "shape3";
        this.shape3.RoundingRadius = 9.999999F;
        this.shape3.Top = 1.125F;
        this.shape3.Width = 3.125F;
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
        this.textBox49.Height = 0.1875F;
        this.textBox49.Left = 0.0625F;
        this.textBox49.Name = "textBox49";
        this.textBox49.Style = "";
        this.textBox49.Text = "Total:";
        this.textBox49.Top = 0.125F;
        this.textBox49.Width = 1.1875F;
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
        this.textBox50.DataField = "monto_pago";
        this.textBox50.Height = 0.1979167F;
        this.textBox50.Left = 6.125F;
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
        this.textBox50.Style = "";
        this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox50.Text = null;
        this.textBox50.Top = 0.125F;
        this.textBox50.Width = 1F;
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
        this.textBox54.DataField = "interes";
        this.textBox54.Height = 0.1875F;
        this.textBox54.Left = 8.875F;
        this.textBox54.Name = "textBox54";
        this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
        this.textBox54.Style = "";
        this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox54.Text = null;
        this.textBox54.Top = 0.125F;
        this.textBox54.Width = 0.9375F;
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
        this.textBox55.DataField = "amortizacion";
        this.textBox55.Height = 0.1875F;
        this.textBox55.Left = 9.8125F;
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
        this.textBox55.Style = "";
        this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox55.Text = null;
        this.textBox55.Top = 0.125F;
        this.textBox55.Width = 0.9375F;
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
        this.textBox56.DataField = "interes_penal";
        this.textBox56.Height = 0.1875F;
        this.textBox56.Left = 10.8125F;
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
        this.textBox56.Style = "";
        this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox56.Text = null;
        this.textBox56.Top = 0.125F;
        this.textBox56.Width = 0.625F;
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
        this.textBox57.DataField = "efe_sus";
        this.textBox57.Height = 0.1875F;
        this.textBox57.Left = 13.0625F;
        this.textBox57.Name = "textBox57";
        this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
        this.textBox57.Style = "";
        this.textBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox57.Text = null;
        this.textBox57.Top = 0.125F;
        this.textBox57.Width = 0.75F;
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
        this.textBox58.DataField = "efe_bs";
        this.textBox58.Height = 0.1875F;
        this.textBox58.Left = 13.8125F;
        this.textBox58.Name = "textBox58";
        this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
        this.textBox58.Style = "";
        this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox58.Text = null;
        this.textBox58.Top = 0.125F;
        this.textBox58.Width = 0.75F;
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
        this.textBox65.DataField = "dpr_sus";
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 14.5625F;
        this.textBox65.Name = "textBox65";
        this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
        this.textBox65.Style = "";
        this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox65.Text = null;
        this.textBox65.Top = 0.125F;
        this.textBox65.Width = 0.75F;
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
        this.textBox51.DataField = "servicio_monto";
        this.textBox51.Height = 0.1875F;
        this.textBox51.Left = 11.5F;
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
        this.textBox51.Style = "";
        this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox51.Text = null;
        this.textBox51.Top = 0.125F;
        this.textBox51.Width = 0.875F;
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
        this.line2.Width = 19.0625F;
        this.line2.X1 = 0.0625F;
        this.line2.X2 = 19.125F;
        this.line2.Y1 = 0.0625F;
        this.line2.Y2 = 0.0625F;
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
        this.textBox24.Left = 9.125F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "Recibos de caja emitidos";
        this.textBox24.Top = 0.5F;
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
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 9.375F;
        this.textBox25.Name = "textBox25";
        this.textBox25.Style = "";
        this.textBox25.Text = "Primer recibo:";
        this.textBox25.Top = 1F;
        this.textBox25.Width = 1.0625F;
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
        this.textBox35.Height = 0.1979167F;
        this.textBox35.Left = 10.4375F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "textBox35";
        this.textBox35.Top = 1F;
        this.textBox35.Width = 1F;
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
        this.textBox36.Left = 9.375F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = "Último recibo:";
        this.textBox36.Top = 1.25F;
        this.textBox36.Width = 1.0625F;
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
        this.textBox42.Height = 0.1979167F;
        this.textBox42.Left = 10.4375F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 1.25F;
        this.textBox42.Width = 1F;
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
        this.shape4.Height = 1F;
        this.shape4.Left = 9.0625F;
        this.shape4.Name = "shape4";
        this.shape4.RoundingRadius = 9.999999F;
        this.shape4.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
        this.shape4.Top = 0.75F;
        this.shape4.Width = 2.6875F;
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
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 4.625F;
        this.textBox43.Name = "textBox43";
        this.textBox43.Style = "";
        this.textBox43.Text = "Resumen de pagos en Efectivo y DPR";
        this.textBox43.Top = 3.1875F;
        this.textBox43.Width = 3.75F;
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
        this.textBox44.Left = 4.8125F;
        this.textBox44.Name = "textBox44";
        this.textBox44.Style = "";
        this.textBox44.Text = "*Total Efectivo:";
        this.textBox44.Top = 3.75F;
        this.textBox44.Width = 1.125F;
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
        this.textBox45.DataField = "efe_sus";
        this.textBox45.Height = 0.1875F;
        this.textBox45.Left = 6F;
        this.textBox45.Name = "textBox45";
        this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
        this.textBox45.Style = "";
        this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox45.Text = "textBox45";
        this.textBox45.Top = 3.75F;
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
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 6F;
        this.textBox46.Name = "textBox46";
        this.textBox46.Style = "text-align: center; ";
        this.textBox46.Text = "$us";
        this.textBox46.Top = 3.5F;
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
        this.textBox47.Height = 0.1875F;
        this.textBox47.Left = 4.8125F;
        this.textBox47.Name = "textBox47";
        this.textBox47.Style = "";
        this.textBox47.Text = "Total DPR:";
        this.textBox47.Top = 4F;
        this.textBox47.Width = 1.125F;
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
        this.textBox52.DataField = "dpr_sus";
        this.textBox52.Height = 0.1875F;
        this.textBox52.Left = 6F;
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
        this.textBox52.Style = "";
        this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox52.Text = "textBox52";
        this.textBox52.Top = 4F;
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
        this.textBox53.Height = 0.1875F;
        this.textBox53.Left = 7F;
        this.textBox53.Name = "textBox53";
        this.textBox53.Style = "text-align: center; ";
        this.textBox53.Text = "Bs";
        this.textBox53.Top = 3.5F;
        this.textBox53.Width = 1F;
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
        this.textBox59.Height = 0.1875F;
        this.textBox59.Left = 0.0625F;
        this.textBox59.Name = "textBox59";
        this.textBox59.Style = "";
        this.textBox59.Text = "*Total Efectivo: Este dato totaliza los pagos cuya forma de pago es: efectivo, Ch" +
            "eque, Tarjeta y Depósito";
        this.textBox59.Top = 4.875F;
        this.textBox59.Width = 11.6875F;
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
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 4.8125F;
        this.textBox60.Name = "textBox60";
        this.textBox60.Style = "";
        this.textBox60.Text = "Total General:";
        this.textBox60.Top = 4.375F;
        this.textBox60.Width = 1.125F;
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
        this.textBox61.DataField = "total_sus";
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 6F;
        this.textBox61.Name = "textBox61";
        this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
        this.textBox61.Style = "";
        this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox61.Text = "textBox61";
        this.textBox61.Top = 4.375F;
        this.textBox61.Width = 1F;
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
        this.textBox62.DataField = "efe_bs";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 7F;
        this.textBox62.Name = "textBox62";
        this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
        this.textBox62.Style = "";
        this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox62.Text = "textBox62";
        this.textBox62.Top = 3.75F;
        this.textBox62.Width = 1F;
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
        this.line4.Left = 4.8125F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 4.3125F;
        this.line4.Width = 4.75F;
        this.line4.X1 = 4.8125F;
        this.line4.X2 = 9.5625F;
        this.line4.Y1 = 4.3125F;
        this.line4.Y2 = 4.3125F;
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
        this.shape5.Height = 1.1875F;
        this.shape5.Left = 4.625F;
        this.shape5.Name = "shape5";
        this.shape5.RoundingRadius = 9.999999F;
        this.shape5.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
        this.shape5.Top = 3.4375F;
        this.shape5.Width = 5.125F;
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
        this.textBox63.DataField = "dpr_bs";
        this.textBox63.Height = 0.1979167F;
        this.textBox63.Left = 7F;
        this.textBox63.Name = "textBox63";
        this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
        this.textBox63.Style = "";
        this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox63.Text = "textBox63";
        this.textBox63.Top = 4F;
        this.textBox63.Width = 1F;
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
        this.textBox64.DataField = "total_bs";
        this.textBox64.Height = 0.1979167F;
        this.textBox64.Left = 7F;
        this.textBox64.Name = "textBox64";
        this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
        this.textBox64.Style = "";
        this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox64.Text = "textBox64";
        this.textBox64.Top = 4.375F;
        this.textBox64.Width = 1F;
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
        this.textBox115.Left = 8.1875F;
        this.textBox115.Name = "textBox115";
        this.textBox115.Style = "";
        this.textBox115.Text = "Consolidado en $us";
        this.textBox115.Top = 3.5F;
        this.textBox115.Width = 1.375F;
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
        this.textBox136.DataField = "total_efe";
        this.textBox136.Height = 0.1875F;
        this.textBox136.Left = 8.1875F;
        this.textBox136.Name = "textBox136";
        this.textBox136.OutputFormat = resources.GetString("textBox136.OutputFormat");
        this.textBox136.Style = "";
        this.textBox136.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox136.Text = "textBox136";
        this.textBox136.Top = 3.75F;
        this.textBox136.Width = 1.375F;
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
        this.textBox149.DataField = "total_dpr";
        this.textBox149.Height = 0.1875F;
        this.textBox149.Left = 8.1875F;
        this.textBox149.Name = "textBox149";
        this.textBox149.OutputFormat = resources.GetString("textBox149.OutputFormat");
        this.textBox149.Style = "";
        this.textBox149.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox149.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox149.Text = "textBox149";
        this.textBox149.Top = 4F;
        this.textBox149.Width = 1.375F;
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
        this.textBox150.DataField = "monto_pago";
        this.textBox150.Height = 0.1875F;
        this.textBox150.Left = 8.1875F;
        this.textBox150.Name = "textBox150";
        this.textBox150.OutputFormat = resources.GetString("textBox150.OutputFormat");
        this.textBox150.Style = "";
        this.textBox150.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox150.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox150.Text = "textBox150";
        this.textBox150.Top = 4.375F;
        this.textBox150.Width = 1.375F;
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
        this.textBox161.DataField = "dpr_bs";
        this.textBox161.Height = 0.1875F;
        this.textBox161.Left = 15.3125F;
        this.textBox161.Name = "textBox161";
        this.textBox161.OutputFormat = resources.GetString("textBox161.OutputFormat");
        this.textBox161.Style = "";
        this.textBox161.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox161.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox161.Text = "textBox161";
        this.textBox161.Top = 0.125F;
        this.textBox161.Width = 0.75F;
        // 
        // textBox181
        // 
        this.textBox181.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox181.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox181.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox181.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox181.Border.RightColor = System.Drawing.Color.Black;
        this.textBox181.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox181.Border.TopColor = System.Drawing.Color.Black;
        this.textBox181.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox181.DataField = "mantenimiento_sus";
        this.textBox181.Height = 0.1875F;
        this.textBox181.Left = 8.25F;
        this.textBox181.Name = "textBox181";
        this.textBox181.OutputFormat = resources.GetString("textBox181.OutputFormat");
        this.textBox181.Style = "";
        this.textBox181.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox181.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox181.Text = "textBox181";
        this.textBox181.Top = 0.125F;
        this.textBox181.Width = 0.625F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox119,
            this.textBox27});
        this.groupHeader1.DataField = "urbanizacion_codigo";
        this.groupHeader1.Height = 0.2395833F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox119.DataField = "urbanizacion_codigo";
        this.textBox119.Height = 0.1875F;
        this.textBox119.Left = 1.25F;
        this.textBox119.Name = "textBox119";
        this.textBox119.Style = "";
        this.textBox119.Text = null;
        this.textBox119.Top = 0F;
        this.textBox119.Width = 2.5625F;
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
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 0.0625F;
        this.textBox27.Name = "textBox27";
        this.textBox27.Style = "";
        this.textBox27.Text = "Negocio:";
        this.textBox27.Top = 0F;
        this.textBox27.Width = 1.1875F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox132,
            this.textBox133,
            this.textBox148,
            this.textBox151,
            this.textBox152,
            this.textBox153,
            this.textBox154,
            this.textBox155,
            this.textBox156,
            this.textBox163,
            this.line1,
            this.textBox160,
            this.textBox180,
            this.textBox184});
        this.groupFooter1.Height = 0.4583333F;
        this.groupFooter1.Name = "groupFooter1";
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
        this.textBox132.Height = 0.1875F;
        this.textBox132.Left = 0.0625F;
        this.textBox132.Name = "textBox132";
        this.textBox132.Style = "";
        this.textBox132.Text = "SubTotal Neg.:";
        this.textBox132.Top = 0.125F;
        this.textBox132.Width = 1.1875F;
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
        this.textBox133.DataField = "urbanizacion_codigo";
        this.textBox133.Height = 0.1875F;
        this.textBox133.Left = 1.25F;
        this.textBox133.Name = "textBox133";
        this.textBox133.Style = "";
        this.textBox133.Text = null;
        this.textBox133.Top = 0.125F;
        this.textBox133.Width = 2.5625F;
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
        this.textBox148.DataField = "monto_pago";
        this.textBox148.Height = 0.1979167F;
        this.textBox148.Left = 6.125F;
        this.textBox148.Name = "textBox148";
        this.textBox148.OutputFormat = resources.GetString("textBox148.OutputFormat");
        this.textBox148.Style = "";
        this.textBox148.SummaryGroup = "groupHeader1";
        this.textBox148.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox148.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox148.Text = null;
        this.textBox148.Top = 0.125F;
        this.textBox148.Width = 1F;
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
        this.textBox151.DataField = "interes";
        this.textBox151.Height = 0.1875F;
        this.textBox151.Left = 8.875F;
        this.textBox151.Name = "textBox151";
        this.textBox151.OutputFormat = resources.GetString("textBox151.OutputFormat");
        this.textBox151.Style = "";
        this.textBox151.SummaryGroup = "groupHeader1";
        this.textBox151.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox151.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox151.Text = null;
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
        this.textBox152.DataField = "amortizacion";
        this.textBox152.Height = 0.1875F;
        this.textBox152.Left = 9.8125F;
        this.textBox152.Name = "textBox152";
        this.textBox152.OutputFormat = resources.GetString("textBox152.OutputFormat");
        this.textBox152.Style = "";
        this.textBox152.SummaryGroup = "groupHeader1";
        this.textBox152.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox152.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox152.Text = null;
        this.textBox152.Top = 0.125F;
        this.textBox152.Width = 0.9375F;
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
        this.textBox153.DataField = "interes_penal";
        this.textBox153.Height = 0.1875F;
        this.textBox153.Left = 10.8125F;
        this.textBox153.Name = "textBox153";
        this.textBox153.OutputFormat = resources.GetString("textBox153.OutputFormat");
        this.textBox153.Style = "";
        this.textBox153.SummaryGroup = "groupHeader1";
        this.textBox153.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox153.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox153.Text = null;
        this.textBox153.Top = 0.125F;
        this.textBox153.Width = 0.625F;
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
        this.textBox154.DataField = "servicio_monto";
        this.textBox154.Height = 0.1875F;
        this.textBox154.Left = 11.5F;
        this.textBox154.Name = "textBox154";
        this.textBox154.OutputFormat = resources.GetString("textBox154.OutputFormat");
        this.textBox154.Style = "";
        this.textBox154.SummaryGroup = "groupHeader1";
        this.textBox154.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox154.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox154.Text = null;
        this.textBox154.Top = 0.125F;
        this.textBox154.Width = 0.875F;
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
        this.textBox155.DataField = "efe_sus";
        this.textBox155.Height = 0.1875F;
        this.textBox155.Left = 13.0625F;
        this.textBox155.Name = "textBox155";
        this.textBox155.OutputFormat = resources.GetString("textBox155.OutputFormat");
        this.textBox155.Style = "";
        this.textBox155.SummaryGroup = "groupHeader1";
        this.textBox155.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox155.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox155.Text = null;
        this.textBox155.Top = 0.125F;
        this.textBox155.Width = 0.75F;
        // 
        // textBox156
        // 
        this.textBox156.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox156.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox156.Border.RightColor = System.Drawing.Color.Black;
        this.textBox156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox156.Border.TopColor = System.Drawing.Color.Black;
        this.textBox156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox156.DataField = "efe_bs";
        this.textBox156.Height = 0.1875F;
        this.textBox156.Left = 13.8125F;
        this.textBox156.Name = "textBox156";
        this.textBox156.OutputFormat = resources.GetString("textBox156.OutputFormat");
        this.textBox156.Style = "";
        this.textBox156.SummaryGroup = "groupHeader1";
        this.textBox156.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox156.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox156.Text = null;
        this.textBox156.Top = 0.125F;
        this.textBox156.Width = 0.75F;
        // 
        // textBox163
        // 
        this.textBox163.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox163.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox163.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox163.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox163.Border.RightColor = System.Drawing.Color.Black;
        this.textBox163.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox163.Border.TopColor = System.Drawing.Color.Black;
        this.textBox163.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox163.DataField = "dpr_sus";
        this.textBox163.Height = 0.1875F;
        this.textBox163.Left = 14.5625F;
        this.textBox163.Name = "textBox163";
        this.textBox163.OutputFormat = resources.GetString("textBox163.OutputFormat");
        this.textBox163.Style = "";
        this.textBox163.SummaryGroup = "groupHeader1";
        this.textBox163.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox163.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox163.Text = null;
        this.textBox163.Top = 0.125F;
        this.textBox163.Width = 0.75F;
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
        this.line1.Width = 19.0625F;
        this.line1.X1 = 0.0625F;
        this.line1.X2 = 19.125F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
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
        this.textBox160.DataField = "dpr_bs";
        this.textBox160.Height = 0.1875F;
        this.textBox160.Left = 15.3125F;
        this.textBox160.Name = "textBox160";
        this.textBox160.OutputFormat = resources.GetString("textBox160.OutputFormat");
        this.textBox160.Style = "";
        this.textBox160.SummaryGroup = "groupHeader1";
        this.textBox160.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox160.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox160.Text = "textBox160";
        this.textBox160.Top = 0.125F;
        this.textBox160.Width = 0.75F;
        // 
        // textBox180
        // 
        this.textBox180.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox180.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox180.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox180.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox180.Border.RightColor = System.Drawing.Color.Black;
        this.textBox180.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox180.Border.TopColor = System.Drawing.Color.Black;
        this.textBox180.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox180.DataField = "mantenimiento_sus";
        this.textBox180.Height = 0.1875F;
        this.textBox180.Left = 8.25F;
        this.textBox180.Name = "textBox180";
        this.textBox180.OutputFormat = resources.GetString("textBox180.OutputFormat");
        this.textBox180.Style = "";
        this.textBox180.SummaryGroup = "groupHeader1";
        this.textBox180.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox180.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox180.Text = "textBox180";
        this.textBox180.Top = 0.125F;
        this.textBox180.Width = 0.625F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox111,
            this.textBox118});
        this.groupHeader2.DataField = "urbanizacion_nombre";
        this.groupHeader2.Height = 0.2395833F;
        this.groupHeader2.Name = "groupHeader2";
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
        this.textBox111.Height = 0.1875F;
        this.textBox111.Left = 0.0625F;
        this.textBox111.Name = "textBox111";
        this.textBox111.Style = "";
        this.textBox111.Text = "Sector";
        this.textBox111.Top = 0F;
        this.textBox111.Width = 1.1875F;
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
        this.textBox118.DataField = "urbanizacion_nombre";
        this.textBox118.Height = 0.1875F;
        this.textBox118.Left = 1.25F;
        this.textBox118.Name = "textBox118";
        this.textBox118.Style = "";
        this.textBox118.Text = "textBox118";
        this.textBox118.Top = 0F;
        this.textBox118.Width = 2.5625F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox165,
            this.textBox166,
            this.textBox167,
            this.textBox170,
            this.textBox171,
            this.textBox172,
            this.textBox173,
            this.textBox175,
            this.textBox176,
            this.textBox183,
            this.line3,
            this.textBox159,
            this.textBox179,
            this.textBox182});
        this.groupFooter2.Height = 0.5F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // textBox165
        // 
        this.textBox165.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox165.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox165.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox165.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox165.Border.RightColor = System.Drawing.Color.Black;
        this.textBox165.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox165.Border.TopColor = System.Drawing.Color.Black;
        this.textBox165.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox165.Height = 0.1875F;
        this.textBox165.Left = 0.0625F;
        this.textBox165.Name = "textBox165";
        this.textBox165.Style = "";
        this.textBox165.Text = "SubTotal Sec.:";
        this.textBox165.Top = 0.125F;
        this.textBox165.Width = 1.1875F;
        // 
        // textBox166
        // 
        this.textBox166.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox166.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox166.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox166.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox166.Border.RightColor = System.Drawing.Color.Black;
        this.textBox166.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox166.Border.TopColor = System.Drawing.Color.Black;
        this.textBox166.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox166.DataField = "urbanizacion_nombre";
        this.textBox166.Height = 0.1875F;
        this.textBox166.Left = 1.25F;
        this.textBox166.Name = "textBox166";
        this.textBox166.Style = "";
        this.textBox166.Text = "textBox166";
        this.textBox166.Top = 0.125F;
        this.textBox166.Width = 2.5625F;
        // 
        // textBox167
        // 
        this.textBox167.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox167.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox167.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox167.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox167.Border.RightColor = System.Drawing.Color.Black;
        this.textBox167.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox167.Border.TopColor = System.Drawing.Color.Black;
        this.textBox167.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox167.DataField = "monto_pago";
        this.textBox167.Height = 0.1979167F;
        this.textBox167.Left = 6.125F;
        this.textBox167.Name = "textBox167";
        this.textBox167.OutputFormat = resources.GetString("textBox167.OutputFormat");
        this.textBox167.Style = "";
        this.textBox167.SummaryGroup = "groupHeader2";
        this.textBox167.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox167.Text = "textBox167";
        this.textBox167.Top = 0.125F;
        this.textBox167.Width = 1F;
        // 
        // textBox170
        // 
        this.textBox170.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox170.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox170.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox170.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox170.Border.RightColor = System.Drawing.Color.Black;
        this.textBox170.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox170.Border.TopColor = System.Drawing.Color.Black;
        this.textBox170.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox170.DataField = "interes";
        this.textBox170.Height = 0.1875F;
        this.textBox170.Left = 8.875F;
        this.textBox170.Name = "textBox170";
        this.textBox170.OutputFormat = resources.GetString("textBox170.OutputFormat");
        this.textBox170.Style = "";
        this.textBox170.SummaryGroup = "groupHeader2";
        this.textBox170.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox170.Text = "textBox170";
        this.textBox170.Top = 0.125F;
        this.textBox170.Width = 0.9375F;
        // 
        // textBox171
        // 
        this.textBox171.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox171.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox171.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox171.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox171.Border.RightColor = System.Drawing.Color.Black;
        this.textBox171.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox171.Border.TopColor = System.Drawing.Color.Black;
        this.textBox171.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox171.DataField = "amortizacion";
        this.textBox171.Height = 0.1875F;
        this.textBox171.Left = 9.8125F;
        this.textBox171.Name = "textBox171";
        this.textBox171.OutputFormat = resources.GetString("textBox171.OutputFormat");
        this.textBox171.Style = "";
        this.textBox171.SummaryGroup = "groupHeader2";
        this.textBox171.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox171.Text = "textBox171";
        this.textBox171.Top = 0.125F;
        this.textBox171.Width = 0.9375F;
        // 
        // textBox172
        // 
        this.textBox172.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox172.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox172.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox172.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox172.Border.RightColor = System.Drawing.Color.Black;
        this.textBox172.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox172.Border.TopColor = System.Drawing.Color.Black;
        this.textBox172.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox172.DataField = "interes_penal";
        this.textBox172.Height = 0.1875F;
        this.textBox172.Left = 10.8125F;
        this.textBox172.Name = "textBox172";
        this.textBox172.OutputFormat = resources.GetString("textBox172.OutputFormat");
        this.textBox172.Style = "";
        this.textBox172.SummaryGroup = "groupHeader2";
        this.textBox172.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox172.Text = "textBox172";
        this.textBox172.Top = 0.125F;
        this.textBox172.Width = 0.625F;
        // 
        // textBox173
        // 
        this.textBox173.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox173.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox173.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox173.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox173.Border.RightColor = System.Drawing.Color.Black;
        this.textBox173.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox173.Border.TopColor = System.Drawing.Color.Black;
        this.textBox173.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox173.DataField = "servicio_monto";
        this.textBox173.Height = 0.1875F;
        this.textBox173.Left = 11.5F;
        this.textBox173.Name = "textBox173";
        this.textBox173.OutputFormat = resources.GetString("textBox173.OutputFormat");
        this.textBox173.Style = "";
        this.textBox173.SummaryGroup = "groupHeader2";
        this.textBox173.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox173.Text = "textBox173";
        this.textBox173.Top = 0.125F;
        this.textBox173.Width = 0.875F;
        // 
        // textBox175
        // 
        this.textBox175.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox175.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox175.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox175.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox175.Border.RightColor = System.Drawing.Color.Black;
        this.textBox175.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox175.Border.TopColor = System.Drawing.Color.Black;
        this.textBox175.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox175.DataField = "efe_sus";
        this.textBox175.Height = 0.1875F;
        this.textBox175.Left = 13.0625F;
        this.textBox175.Name = "textBox175";
        this.textBox175.OutputFormat = resources.GetString("textBox175.OutputFormat");
        this.textBox175.Style = "";
        this.textBox175.SummaryGroup = "groupHeader2";
        this.textBox175.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox175.Text = "textBox175";
        this.textBox175.Top = 0.125F;
        this.textBox175.Width = 0.75F;
        // 
        // textBox176
        // 
        this.textBox176.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox176.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox176.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox176.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox176.Border.RightColor = System.Drawing.Color.Black;
        this.textBox176.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox176.Border.TopColor = System.Drawing.Color.Black;
        this.textBox176.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox176.DataField = "efe_bs";
        this.textBox176.Height = 0.1875F;
        this.textBox176.Left = 13.8125F;
        this.textBox176.Name = "textBox176";
        this.textBox176.OutputFormat = resources.GetString("textBox176.OutputFormat");
        this.textBox176.Style = "";
        this.textBox176.SummaryGroup = "groupHeader2";
        this.textBox176.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox176.Text = "textBox176";
        this.textBox176.Top = 0.125F;
        this.textBox176.Width = 0.75F;
        // 
        // textBox183
        // 
        this.textBox183.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox183.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox183.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox183.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox183.Border.RightColor = System.Drawing.Color.Black;
        this.textBox183.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox183.Border.TopColor = System.Drawing.Color.Black;
        this.textBox183.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox183.DataField = "dpr_sus";
        this.textBox183.Height = 0.1875F;
        this.textBox183.Left = 14.5625F;
        this.textBox183.Name = "textBox183";
        this.textBox183.OutputFormat = resources.GetString("textBox183.OutputFormat");
        this.textBox183.Style = "";
        this.textBox183.SummaryGroup = "groupHeader2";
        this.textBox183.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox183.Text = "textBox183";
        this.textBox183.Top = 0.125F;
        this.textBox183.Width = 0.75F;
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
        this.line3.Width = 19.0625F;
        this.line3.X1 = 0.0625F;
        this.line3.X2 = 19.125F;
        this.line3.Y1 = 0.0625F;
        this.line3.Y2 = 0.0625F;
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
        this.textBox159.DataField = "dpr_bs";
        this.textBox159.Height = 0.1875F;
        this.textBox159.Left = 15.3125F;
        this.textBox159.Name = "textBox159";
        this.textBox159.OutputFormat = resources.GetString("textBox159.OutputFormat");
        this.textBox159.Style = "";
        this.textBox159.SummaryGroup = "groupHeader2";
        this.textBox159.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox159.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox159.Text = "textBox159";
        this.textBox159.Top = 0.125F;
        this.textBox159.Width = 0.75F;
        // 
        // textBox179
        // 
        this.textBox179.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox179.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox179.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox179.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox179.Border.RightColor = System.Drawing.Color.Black;
        this.textBox179.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox179.Border.TopColor = System.Drawing.Color.Black;
        this.textBox179.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox179.DataField = "mantenimiento_sus";
        this.textBox179.Height = 0.1875F;
        this.textBox179.Left = 8.25F;
        this.textBox179.Name = "textBox179";
        this.textBox179.OutputFormat = resources.GetString("textBox179.OutputFormat");
        this.textBox179.Style = "";
        this.textBox179.SummaryGroup = "groupHeader2";
        this.textBox179.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox179.Text = "textBox179";
        this.textBox179.Top = 0.125F;
        this.textBox179.Width = 0.625F;
        // 
        // textBox182
        // 
        this.textBox182.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox182.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox182.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox182.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox182.Border.RightColor = System.Drawing.Color.Black;
        this.textBox182.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox182.Border.TopColor = System.Drawing.Color.Black;
        this.textBox182.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox182.DataField = "seguro";
        this.textBox182.Height = 0.1875F;
        this.textBox182.Left = 7.625F;
        this.textBox182.Name = "textBox182";
        this.textBox182.OutputFormat = resources.GetString("textBox182.OutputFormat");
        this.textBox182.Style = "";
        this.textBox182.SummaryGroup = "groupHeader2";
        this.textBox182.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox182.Text = "textBox182";
        this.textBox182.Top = 0.125F;
        this.textBox182.Width = 0.625F;
        // 
        // textBox184
        // 
        this.textBox184.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox184.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox184.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox184.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox184.Border.RightColor = System.Drawing.Color.Black;
        this.textBox184.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox184.Border.TopColor = System.Drawing.Color.Black;
        this.textBox184.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox184.DataField = "seguro";
        this.textBox184.Height = 0.1875F;
        this.textBox184.Left = 7.625F;
        this.textBox184.Name = "textBox184";
        this.textBox184.OutputFormat = resources.GetString("textBox184.OutputFormat");
        this.textBox184.Style = "";
        this.textBox184.SummaryGroup = "groupHeader1";
        this.textBox184.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox184.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox184.Text = "textBox184";
        this.textBox184.Top = 0.125F;
        this.textBox184.Width = 0.625F;
        // 
        // textBox185
        // 
        this.textBox185.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox185.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox185.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox185.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox185.Border.RightColor = System.Drawing.Color.Black;
        this.textBox185.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox185.Border.TopColor = System.Drawing.Color.Black;
        this.textBox185.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox185.DataField = "seguro";
        this.textBox185.Height = 0.1875F;
        this.textBox185.Left = 7.625F;
        this.textBox185.Name = "textBox185";
        this.textBox185.OutputFormat = resources.GetString("textBox185.OutputFormat");
        this.textBox185.Style = "";
        this.textBox185.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox185.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox185.Text = "textBox185";
        this.textBox185.Top = 0.125F;
        this.textBox185.Width = 0.625F;
        // 
        // rpt_ingresosDetalle
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 19.16667F;
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
        this.ReportStart += new System.EventHandler(this.rpt_ingresosDetalle_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox112)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox113)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox114)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox127)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox157)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox177)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox134)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox135)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox137)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox138)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox139)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox140)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox141)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox142)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox143)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox144)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox164)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox158)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox178)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox162)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox168)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox169)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox174)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox86)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox87)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox83)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox84)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox85)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox90)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox108)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox109)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox110)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox115)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox136)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox150)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox161)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox181)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox132)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox133)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox153)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox154)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox155)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox156)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox163)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox160)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox180)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox111)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox165)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox166)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox167)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox170)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox171)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox172)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox173)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox175)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox176)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox183)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox159)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox179)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox182)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox184)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox185)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void reportFooter1_Format(object sender, EventArgs e)
    {
        decimal SubTotalEfectivo = decimal.Parse(textBox61.Text) - decimal.Parse(textBox52.Text);
        textBox45.Text = SubTotalEfectivo.ToString("N2");
    }

    
}
