using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_resumenEvolucionGrupos.
/// </summary>
public class rpt_resumenEvolucionGrupos : DataDynamics.ActiveReports.ActiveReport3
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
    private Picture picture1;
    private TextBox textBox14;
    private TextBox textBox15;
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
    private Line line14;
    private Line line28;
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
    private Line line32;
    private Line line1;
    private GroupHeader groupHeader2;
    private TextBox textBox145;
    private GroupFooter groupFooter2;
    private TextBox textBox146;
    private TextBox textBox147;
    private TextBox textBox148;
    private TextBox textBox149;
    private TextBox textBox150;
    private TextBox textBox151;
    private TextBox textBox152;
    private TextBox textBox153;
    private TextBox textBox154;
    private TextBox textBox155;
    private TextBox textBox156;
    private TextBox textBox157;
    private TextBox textBox158;
    private TextBox textBox159;
    private TextBox textBox160;
    private TextBox textBox161;
    private TextBox textBox162;
    private TextBox textBox163;
    private TextBox textBox164;
    private TextBox textBox165;
    private TextBox textBox166;
    private TextBox textBox167;
    private Line line33;
    private Line line34;
    private TextBox textBox168;
    private TextBox textBox169;
    private TextBox textBox170;
    private TextBox textBox171;
    private TextBox textBox172;
    private TextBox textBox173;
    private TextBox textBox174;
    private TextBox textBox175;
    private TextBox textBox176;
    private TextBox textBox177;
    private TextBox textBox178;
    private TextBox textBox179;
    private TextBox textBox180;
    private TextBox textBox181;
    private TextBox textBox182;
    private TextBox textBox183;
    private TextBox textBox184;
    private TextBox textBox185;
    private TextBox textBox186;
    private TextBox textBox187;
    private TextBox textBox188;
    private TextBox textBox189;
    private TextBox textBox190;
    private TextBox textBox191;
    private TextBox textBox192;
    private TextBox textBox193;
    private TextBox textBox194;
    private TextBox textBox195;
    private TextBox textBox196;
    private TextBox textBox197;
    private TextBox textBox198;
    private TextBox textBox199;
    private TextBox textBox200;
    private TextBox textBox201;
    private TextBox textBox202;
    private TextBox textBox203;
    private TextBox textBox204;
    private TextBox textBox205;
    private TextBox textBox206;
    private TextBox textBox207;
    private Line line35;
    private Line line36;
    private Line line37;
    private Line line38;
    private Line line39;
    private Line line54;
    private Line line55;
    private Line line56;
    private Line line57;
    private Line line58;
    private Line line59;
    private Line line60;
    private Line line62;
    private TextBox textBox208;
    private Line line2;
    private Line line27;
    private Shape shape1;
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
    private TextBox textBox16;
    private TextBox textBox29;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_resumenEvolucionGrupos()
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

    public void CargarEncabezado(string Usuario, DateTime Fecha, DateTime Fecha2, string Negocios, string Moneda, string Consolidado, string Codigo_moneda, string Grupo_original_actual)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox31.Text = "Usuario: " + Usuario;

        textBox6.Text = Fecha.ToString("d") + " - " + Fecha2.ToString("d");
        textBox7.Text = Negocios;
        textBox19.Text = Moneda;
        textBox21.Text = Consolidado;
        textBox29.Text = Grupo_original_actual;
    }


    private void rpt_resumenEvolucionGrupos_ReportStart(object sender, EventArgs e)
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
        textBox16.ClassName = "estiloEncabEnun";
        textBox29.ClassName = "estiloEncabDato";

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
        textBox65.ClassName = "estiloDetalleDatoString";
        textBox75.ClassName = "estiloDetalleDatoString";
        textBox85.ClassName = "estiloDetalleDatoString";
        textBox95.ClassName = "estiloDetalleDatoString";


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

        textBox145.ClassName = "estiloGrupoEnun";
        textBox146.ClassName = "estiloGrupoEnun";

        textBox147.ClassName = "estiloTotalEnun";
        textBox208.ClassName = "estiloTotalEnun";
        textBox148.ClassName = "estiloTotal";
        textBox149.ClassName = "estiloTotal";
        textBox150.ClassName = "estiloTotal";
        textBox151.ClassName = "estiloTotal";
        textBox152.ClassName = "estiloTotal";
        textBox153.ClassName = "estiloTotal";
        textBox154.ClassName = "estiloTotal";
        textBox155.ClassName = "estiloTotal";
        textBox156.ClassName = "estiloTotal";
        textBox157.ClassName = "estiloTotal";
        textBox158.ClassName = "estiloTotal";
        textBox159.ClassName = "estiloTotal";
        textBox160.ClassName = "estiloTotal";
        textBox161.ClassName = "estiloTotal";
        textBox162.ClassName = "estiloTotal";
        textBox163.ClassName = "estiloTotal";
        textBox164.ClassName = "estiloTotal";
        textBox165.ClassName = "estiloTotal";
        textBox166.ClassName = "estiloDetalleDatoString";
        textBox167.ClassName = "estiloDetalleDatoString";
        textBox168.ClassName = "estiloDetalleDatoString";
        textBox169.ClassName = "estiloTotal";
        textBox170.ClassName = "estiloTotal";
        textBox171.ClassName = "estiloTotal";
        textBox172.ClassName = "estiloTotal";
        textBox173.ClassName = "estiloTotal";
        textBox174.ClassName = "estiloTotal";
        textBox175.ClassName = "estiloTotal";
        textBox176.ClassName = "estiloTotal";
        textBox177.ClassName = "estiloTotal";
        textBox178.ClassName = "estiloDetalleDatoString";
        textBox179.ClassName = "estiloTotal";
        textBox180.ClassName = "estiloTotal";
        textBox181.ClassName = "estiloTotal";
        textBox182.ClassName = "estiloTotal";
        textBox183.ClassName = "estiloTotal";
        textBox184.ClassName = "estiloTotal";
        textBox185.ClassName = "estiloTotal";
        textBox186.ClassName = "estiloTotal";
        textBox187.ClassName = "estiloTotal";
        textBox188.ClassName = "estiloDetalleDatoString";
        textBox189.ClassName = "estiloTotal";
        textBox190.ClassName = "estiloTotal";
        textBox191.ClassName = "estiloTotal";
        textBox192.ClassName = "estiloTotal";
        textBox193.ClassName = "estiloTotal";
        textBox194.ClassName = "estiloTotal";
        textBox195.ClassName = "estiloTotal";
        textBox196.ClassName = "estiloTotal";
        textBox197.ClassName = "estiloTotal";
        textBox198.ClassName = "estiloDetalleDatoString";
        textBox199.ClassName = "estiloTotal";
        textBox200.ClassName = "estiloTotal";
        textBox201.ClassName = "estiloTotal";
        textBox202.ClassName = "estiloTotal";
        textBox203.ClassName = "estiloTotal";
        textBox204.ClassName = "estiloTotal";
        textBox205.ClassName = "estiloTotal";
        textBox206.ClassName = "estiloTotal";
        textBox207.ClassName = "estiloTotal";

    }


	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_resumenEvolucionGrupos));
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
        this.line28 = new DataDynamics.ActiveReports.Line();
        this.line32 = new DataDynamics.ActiveReports.Line();
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
        this.textBox146 = new DataDynamics.ActiveReports.TextBox();
        this.textBox145 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.line27 = new DataDynamics.ActiveReports.Line();
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
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
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
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.shape10 = new DataDynamics.ActiveReports.Shape();
        this.shape11 = new DataDynamics.ActiveReports.Shape();
        this.shape12 = new DataDynamics.ActiveReports.Shape();
        this.shape13 = new DataDynamics.ActiveReports.Shape();
        this.shape14 = new DataDynamics.ActiveReports.Shape();
        this.shape15 = new DataDynamics.ActiveReports.Shape();
        this.shape16 = new DataDynamics.ActiveReports.Shape();
        this.shape17 = new DataDynamics.ActiveReports.Shape();
        this.shape18 = new DataDynamics.ActiveReports.Shape();
        this.textBox147 = new DataDynamics.ActiveReports.TextBox();
        this.textBox148 = new DataDynamics.ActiveReports.TextBox();
        this.textBox149 = new DataDynamics.ActiveReports.TextBox();
        this.textBox150 = new DataDynamics.ActiveReports.TextBox();
        this.textBox151 = new DataDynamics.ActiveReports.TextBox();
        this.textBox152 = new DataDynamics.ActiveReports.TextBox();
        this.textBox153 = new DataDynamics.ActiveReports.TextBox();
        this.textBox154 = new DataDynamics.ActiveReports.TextBox();
        this.textBox155 = new DataDynamics.ActiveReports.TextBox();
        this.textBox156 = new DataDynamics.ActiveReports.TextBox();
        this.textBox157 = new DataDynamics.ActiveReports.TextBox();
        this.textBox158 = new DataDynamics.ActiveReports.TextBox();
        this.textBox159 = new DataDynamics.ActiveReports.TextBox();
        this.textBox160 = new DataDynamics.ActiveReports.TextBox();
        this.textBox161 = new DataDynamics.ActiveReports.TextBox();
        this.textBox162 = new DataDynamics.ActiveReports.TextBox();
        this.textBox163 = new DataDynamics.ActiveReports.TextBox();
        this.textBox164 = new DataDynamics.ActiveReports.TextBox();
        this.textBox165 = new DataDynamics.ActiveReports.TextBox();
        this.textBox166 = new DataDynamics.ActiveReports.TextBox();
        this.textBox167 = new DataDynamics.ActiveReports.TextBox();
        this.textBox168 = new DataDynamics.ActiveReports.TextBox();
        this.textBox169 = new DataDynamics.ActiveReports.TextBox();
        this.textBox170 = new DataDynamics.ActiveReports.TextBox();
        this.textBox171 = new DataDynamics.ActiveReports.TextBox();
        this.textBox172 = new DataDynamics.ActiveReports.TextBox();
        this.textBox173 = new DataDynamics.ActiveReports.TextBox();
        this.textBox174 = new DataDynamics.ActiveReports.TextBox();
        this.textBox175 = new DataDynamics.ActiveReports.TextBox();
        this.textBox176 = new DataDynamics.ActiveReports.TextBox();
        this.textBox177 = new DataDynamics.ActiveReports.TextBox();
        this.textBox178 = new DataDynamics.ActiveReports.TextBox();
        this.textBox179 = new DataDynamics.ActiveReports.TextBox();
        this.textBox180 = new DataDynamics.ActiveReports.TextBox();
        this.textBox181 = new DataDynamics.ActiveReports.TextBox();
        this.textBox182 = new DataDynamics.ActiveReports.TextBox();
        this.textBox183 = new DataDynamics.ActiveReports.TextBox();
        this.textBox184 = new DataDynamics.ActiveReports.TextBox();
        this.textBox185 = new DataDynamics.ActiveReports.TextBox();
        this.textBox186 = new DataDynamics.ActiveReports.TextBox();
        this.textBox187 = new DataDynamics.ActiveReports.TextBox();
        this.textBox188 = new DataDynamics.ActiveReports.TextBox();
        this.textBox189 = new DataDynamics.ActiveReports.TextBox();
        this.textBox190 = new DataDynamics.ActiveReports.TextBox();
        this.textBox191 = new DataDynamics.ActiveReports.TextBox();
        this.textBox192 = new DataDynamics.ActiveReports.TextBox();
        this.textBox193 = new DataDynamics.ActiveReports.TextBox();
        this.textBox194 = new DataDynamics.ActiveReports.TextBox();
        this.textBox195 = new DataDynamics.ActiveReports.TextBox();
        this.textBox196 = new DataDynamics.ActiveReports.TextBox();
        this.textBox197 = new DataDynamics.ActiveReports.TextBox();
        this.textBox198 = new DataDynamics.ActiveReports.TextBox();
        this.textBox199 = new DataDynamics.ActiveReports.TextBox();
        this.textBox200 = new DataDynamics.ActiveReports.TextBox();
        this.textBox201 = new DataDynamics.ActiveReports.TextBox();
        this.textBox202 = new DataDynamics.ActiveReports.TextBox();
        this.textBox203 = new DataDynamics.ActiveReports.TextBox();
        this.textBox204 = new DataDynamics.ActiveReports.TextBox();
        this.textBox205 = new DataDynamics.ActiveReports.TextBox();
        this.textBox206 = new DataDynamics.ActiveReports.TextBox();
        this.textBox207 = new DataDynamics.ActiveReports.TextBox();
        this.line59 = new DataDynamics.ActiveReports.Line();
        this.line60 = new DataDynamics.ActiveReports.Line();
        this.line62 = new DataDynamics.ActiveReports.Line();
        this.textBox208 = new DataDynamics.ActiveReports.TextBox();
        this.line58 = new DataDynamics.ActiveReports.Line();
        this.line34 = new DataDynamics.ActiveReports.Line();
        this.line35 = new DataDynamics.ActiveReports.Line();
        this.line36 = new DataDynamics.ActiveReports.Line();
        this.line37 = new DataDynamics.ActiveReports.Line();
        this.line38 = new DataDynamics.ActiveReports.Line();
        this.line39 = new DataDynamics.ActiveReports.Line();
        this.line54 = new DataDynamics.ActiveReports.Line();
        this.line55 = new DataDynamics.ActiveReports.Line();
        this.line56 = new DataDynamics.ActiveReports.Line();
        this.line57 = new DataDynamics.ActiveReports.Line();
        this.line33 = new DataDynamics.ActiveReports.Line();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox150)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox153)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox154)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox155)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox156)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox157)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox158)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox159)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox160)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox161)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox162)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox163)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox164)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox165)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox166)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox167)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox168)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox169)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox170)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox171)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox172)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox173)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox174)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox175)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox176)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox177)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox178)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox179)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox180)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox181)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox182)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox183)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox184)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox185)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox186)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox187)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox188)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox189)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox190)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox191)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox192)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox193)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox194)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox195)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox196)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox197)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox198)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox199)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox200)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox201)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox202)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox203)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox204)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox205)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox206)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox207)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox208)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
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
            this.line28,
            this.line32,
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
            this.textBox146,
            this.textBox145,
            this.line2,
            this.line27,
            this.textBox16,
            this.textBox29});
        this.pageHeader.Height = 2.197917F;
        this.pageHeader.Name = "pageHeader";
        this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
        this.textBox5.Top = 2F;
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
        this.textBox10.Top = 1.8125F;
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
        this.textBox11.Top = 1.8125F;
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
        this.textBox12.Top = 1.8125F;
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
        this.textBox13.Top = 1.8125F;
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
        this.textBox8.Top = 1.8125F;
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
        this.textBox9.Top = 1.8125F;
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
        this.textBox14.Top = 1.8125F;
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
        this.textBox23.Top = 1.8125F;
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
        this.textBox36.Top = 1.8125F;
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
        this.textBox37.Top = 1.625F;
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
        this.line15.Top = 2F;
        this.line15.Width = 0F;
        this.line15.X1 = 0F;
        this.line15.X2 = 0F;
        this.line15.Y1 = 2.1875F;
        this.line15.Y2 = 2F;
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
        this.line16.Top = 2F;
        this.line16.Width = 0F;
        this.line16.X1 = 2.4375F;
        this.line16.X2 = 2.4375F;
        this.line16.Y1 = 2.1875F;
        this.line16.Y2 = 2F;
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
        this.line17.Top = 1.625F;
        this.line17.Width = 0F;
        this.line17.X1 = 3.4375F;
        this.line17.X2 = 3.4375F;
        this.line17.Y1 = 2.1875F;
        this.line17.Y2 = 1.625F;
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
        this.line18.Top = 1.8125F;
        this.line18.Width = 0F;
        this.line18.X1 = 4.5F;
        this.line18.X2 = 4.5F;
        this.line18.Y1 = 2.1875F;
        this.line18.Y2 = 1.8125F;
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
        this.line19.Top = 1.8125F;
        this.line19.Width = 0F;
        this.line19.X1 = 5.5625F;
        this.line19.X2 = 5.5625F;
        this.line19.Y1 = 2.1875F;
        this.line19.Y2 = 1.8125F;
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
        this.line20.Top = 1.8125F;
        this.line20.Width = 0F;
        this.line20.X1 = 6.625F;
        this.line20.X2 = 6.625F;
        this.line20.Y1 = 2.1875F;
        this.line20.Y2 = 1.8125F;
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
        this.line21.Top = 1.8125F;
        this.line21.Width = 0F;
        this.line21.X1 = 8.75F;
        this.line21.X2 = 8.75F;
        this.line21.Y1 = 2.1875F;
        this.line21.Y2 = 1.8125F;
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
        this.line22.Top = 1.8125F;
        this.line22.Width = 0F;
        this.line22.X1 = 7.6875F;
        this.line22.X2 = 7.6875F;
        this.line22.Y1 = 2.1875F;
        this.line22.Y2 = 1.8125F;
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
        this.line23.Top = 1.8125F;
        this.line23.Width = 0F;
        this.line23.X1 = 9.8125F;
        this.line23.X2 = 9.8125F;
        this.line23.Y1 = 2.1875F;
        this.line23.Y2 = 1.8125F;
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
        this.line24.Top = 1.8125F;
        this.line24.Width = 0F;
        this.line24.X1 = 10.875F;
        this.line24.X2 = 10.875F;
        this.line24.Y1 = 2.1875F;
        this.line24.Y2 = 1.8125F;
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
        this.line25.Top = 1.8125F;
        this.line25.Width = 0F;
        this.line25.X1 = 11.9375F;
        this.line25.X2 = 11.9375F;
        this.line25.Y1 = 2.1875F;
        this.line25.Y2 = 1.8125F;
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
        this.line26.Top = 1.625F;
        this.line26.Width = 0F;
        this.line26.X1 = 13F;
        this.line26.X2 = 13F;
        this.line26.Y1 = 2.1875F;
        this.line26.Y2 = 1.625F;
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
        this.line28.Top = 1.625F;
        this.line28.Width = 9.5625F;
        this.line28.X1 = 3.4375F;
        this.line28.X2 = 13F;
        this.line28.Y1 = 1.625F;
        this.line28.Y2 = 1.625F;
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
        this.line32.Top = 2.1875F;
        this.line32.Width = 13F;
        this.line32.X1 = 0F;
        this.line32.X2 = 13F;
        this.line32.Y1 = 2.1875F;
        this.line32.Y2 = 2.1875F;
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
        this.textBox1.Top = 0F;
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
        this.textBox2.Left = 2.5F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Evolución de cartera vigente general";
        this.textBox2.Top = 0.4375F;
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
        this.textBox3.Left = 3.375F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "Periodo:";
        this.textBox3.Top = 0.625F;
        this.textBox3.Width = 2.125F;
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
        this.textBox4.Left = 3.375F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Negocio:";
        this.textBox4.Top = 0.8125F;
        this.textBox4.Width = 2.125F;
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
        this.textBox6.Top = 0.625F;
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
        this.textBox7.Top = 0.8125F;
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
        this.textBox18.Left = 3.375F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "MONEDA:";
        this.textBox18.Top = 1F;
        this.textBox18.Width = 2.125F;
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
        this.textBox19.Top = 1F;
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
        this.textBox20.Left = 3.375F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "DATOS:";
        this.textBox20.Top = 1.1875F;
        this.textBox20.Width = 2.125F;
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
        this.textBox21.Top = 1.1875F;
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
        this.textBox31.Top = 0.1875F;
        this.textBox31.Width = 5.25F;
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
        this.textBox146.DataField = "grupo";
        this.textBox146.Height = 0.1875F;
        this.textBox146.Left = 0.6875F;
        this.textBox146.Name = "textBox146";
        this.textBox146.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9.75pt; ";
        this.textBox146.Text = "textBox146";
        this.textBox146.Top = 1.625F;
        this.textBox146.Width = 2.6875F;
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
        this.textBox145.Height = 0.1875F;
        this.textBox145.Left = 0.0625F;
        this.textBox145.Name = "textBox145";
        this.textBox145.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9.75pt; ";
        this.textBox145.Text = "Grupo:";
        this.textBox145.Top = 1.625F;
        this.textBox145.Width = 0.5625F;
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
        this.line2.Left = 3.4375F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 1.8125F;
        this.line2.Width = 9.5625F;
        this.line2.X1 = 3.4375F;
        this.line2.X2 = 13F;
        this.line2.Y1 = 1.8125F;
        this.line2.Y2 = 1.8125F;
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
        this.line27.Left = 0F;
        this.line27.LineWeight = 1F;
        this.line27.Name = "line27";
        this.line27.Top = 2F;
        this.line27.Width = 2.4375F;
        this.line27.X1 = 0F;
        this.line27.X2 = 2.4375F;
        this.line27.Y1 = 2F;
        this.line27.Y2 = 2F;
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
        this.textBox24.Text = "textBox24";
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
        this.pageFooter.Height = 0.01041667F;
        this.pageFooter.Name = "pageFooter";
        this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
        // 
        // reportHeader1
        // 
        this.reportHeader1.Height = 0.02083333F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
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
            this.line43,
            this.line1});
        this.groupFooter1.Height = 1.510417F;
        this.groupFooter1.KeepTogether = true;
        this.groupFooter1.Name = "groupFooter1";
        this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
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
        this.line1.Top = 1.5F;
        this.line1.Width = 13F;
        this.line1.X1 = 0F;
        this.line1.X2 = 13F;
        this.line1.Y1 = 1.5F;
        this.line1.Y2 = 1.5F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.DataField = "grupo";
        this.groupHeader2.Height = 0F;
        this.groupHeader2.Name = "groupHeader2";
        this.groupHeader2.Format += new System.EventHandler(this.groupHeader2_Format);
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape10,
            this.shape11,
            this.shape12,
            this.shape13,
            this.shape14,
            this.shape15,
            this.shape16,
            this.shape17,
            this.shape18,
            this.textBox147,
            this.textBox148,
            this.textBox149,
            this.textBox150,
            this.textBox151,
            this.textBox152,
            this.textBox153,
            this.textBox154,
            this.textBox155,
            this.textBox156,
            this.textBox157,
            this.textBox158,
            this.textBox159,
            this.textBox160,
            this.textBox161,
            this.textBox162,
            this.textBox163,
            this.textBox164,
            this.textBox165,
            this.textBox166,
            this.textBox167,
            this.textBox168,
            this.textBox169,
            this.textBox170,
            this.textBox171,
            this.textBox172,
            this.textBox173,
            this.textBox174,
            this.textBox175,
            this.textBox176,
            this.textBox177,
            this.textBox178,
            this.textBox179,
            this.textBox180,
            this.textBox181,
            this.textBox182,
            this.textBox183,
            this.textBox184,
            this.textBox185,
            this.textBox186,
            this.textBox187,
            this.textBox188,
            this.textBox189,
            this.textBox190,
            this.textBox191,
            this.textBox192,
            this.textBox193,
            this.textBox194,
            this.textBox195,
            this.textBox196,
            this.textBox197,
            this.textBox198,
            this.textBox199,
            this.textBox200,
            this.textBox201,
            this.textBox202,
            this.textBox203,
            this.textBox204,
            this.textBox205,
            this.textBox206,
            this.textBox207,
            this.line59,
            this.line60,
            this.line62,
            this.textBox208,
            this.line58,
            this.line34,
            this.line35,
            this.line36,
            this.line37,
            this.line38,
            this.line39,
            this.line54,
            this.line55,
            this.line56,
            this.line57,
            this.line33});
        this.groupFooter2.Height = 1.510417F;
        this.groupFooter2.KeepTogether = true;
        this.groupFooter2.Name = "groupFooter2";
        this.groupFooter2.NewPage = DataDynamics.ActiveReports.NewPage.After;
        this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
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
        this.shape10.RoundingRadius = 9.999999F;
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
        this.shape11.RoundingRadius = 9.999999F;
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
        this.shape12.RoundingRadius = 9.999999F;
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
        this.shape13.RoundingRadius = 9.999999F;
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
        this.shape14.RoundingRadius = 9.999999F;
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
        this.shape15.RoundingRadius = 9.999999F;
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
        this.shape16.RoundingRadius = 9.999999F;
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
        this.shape17.RoundingRadius = 9.999999F;
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
        this.shape18.RoundingRadius = 9.999999F;
        this.shape18.Top = 0F;
        this.shape18.Width = 1.0625F;
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
        this.textBox147.DataField = "grupo";
        this.textBox147.Height = 0.1875F;
        this.textBox147.Left = 0.75F;
        this.textBox147.Name = "textBox147";
        this.textBox147.Style = "";
        this.textBox147.Text = "textBox147";
        this.textBox147.Top = 0.0625F;
        this.textBox147.Width = 1.625F;
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
        this.textBox148.DataField = "d0_ini_saldo";
        this.textBox148.Height = 0.1875F;
        this.textBox148.Left = 3.4375F;
        this.textBox148.Name = "textBox148";
        this.textBox148.OutputFormat = resources.GetString("textBox148.OutputFormat");
        this.textBox148.Style = "";
        this.textBox148.SummaryGroup = "groupHeader2";
        this.textBox148.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox148.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox148.Text = "textBox148";
        this.textBox148.Top = 0.0625F;
        this.textBox148.Width = 1F;
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
        this.textBox149.DataField = "d61_ini_saldo";
        this.textBox149.Height = 0.1875F;
        this.textBox149.Left = 6.625F;
        this.textBox149.Name = "textBox149";
        this.textBox149.OutputFormat = resources.GetString("textBox149.OutputFormat");
        this.textBox149.Style = "";
        this.textBox149.SummaryGroup = "groupHeader2";
        this.textBox149.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox149.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox149.Text = "textBox149";
        this.textBox149.Top = 0.0625F;
        this.textBox149.Width = 1F;
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
        this.textBox150.DataField = "d31_ini_saldo";
        this.textBox150.Height = 0.1875F;
        this.textBox150.Left = 5.5625F;
        this.textBox150.Name = "textBox150";
        this.textBox150.OutputFormat = resources.GetString("textBox150.OutputFormat");
        this.textBox150.Style = "";
        this.textBox150.SummaryGroup = "groupHeader2";
        this.textBox150.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox150.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox150.Text = "textBox150";
        this.textBox150.Top = 0.0625F;
        this.textBox150.Width = 1F;
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
        this.textBox151.DataField = "d91_ini_saldo";
        this.textBox151.Height = 0.1875F;
        this.textBox151.Left = 7.6875F;
        this.textBox151.Name = "textBox151";
        this.textBox151.OutputFormat = resources.GetString("textBox151.OutputFormat");
        this.textBox151.Style = "";
        this.textBox151.SummaryGroup = "groupHeader2";
        this.textBox151.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox151.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox151.Text = "textBox151";
        this.textBox151.Top = 0.0625F;
        this.textBox151.Width = 1F;
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
        this.textBox152.DataField = "d121_ini_saldo";
        this.textBox152.Height = 0.1875F;
        this.textBox152.Left = 8.75F;
        this.textBox152.Name = "textBox152";
        this.textBox152.OutputFormat = resources.GetString("textBox152.OutputFormat");
        this.textBox152.Style = "";
        this.textBox152.SummaryGroup = "groupHeader2";
        this.textBox152.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox152.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox152.Text = "textBox152";
        this.textBox152.Top = 0.0625F;
        this.textBox152.Width = 1F;
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
        this.textBox153.DataField = "desp_ini_saldo";
        this.textBox153.Height = 0.1875F;
        this.textBox153.Left = 9.8125F;
        this.textBox153.Name = "textBox153";
        this.textBox153.OutputFormat = resources.GetString("textBox153.OutputFormat");
        this.textBox153.Style = "";
        this.textBox153.SummaryGroup = "groupHeader2";
        this.textBox153.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox153.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox153.Text = "textBox153";
        this.textBox153.Top = 0.0625F;
        this.textBox153.Width = 1F;
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
        this.textBox154.DataField = "d1_ini_saldo";
        this.textBox154.Height = 0.1875F;
        this.textBox154.Left = 4.5F;
        this.textBox154.Name = "textBox154";
        this.textBox154.OutputFormat = resources.GetString("textBox154.OutputFormat");
        this.textBox154.Style = "";
        this.textBox154.SummaryGroup = "groupHeader2";
        this.textBox154.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox154.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox154.Text = "textBox154";
        this.textBox154.Top = 0.0625F;
        this.textBox154.Width = 1F;
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
        this.textBox155.DataField = "rev_ini_saldo";
        this.textBox155.Height = 0.1875F;
        this.textBox155.Left = 10.875F;
        this.textBox155.Name = "textBox155";
        this.textBox155.OutputFormat = resources.GetString("textBox155.OutputFormat");
        this.textBox155.Style = "";
        this.textBox155.SummaryGroup = "groupHeader2";
        this.textBox155.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox155.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox155.Text = "textBox155";
        this.textBox155.Top = 0.0625F;
        this.textBox155.Width = 1F;
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
        this.textBox156.DataField = "ini_saldo";
        this.textBox156.Height = 0.1875F;
        this.textBox156.Left = 11.9375F;
        this.textBox156.Name = "textBox156";
        this.textBox156.OutputFormat = resources.GetString("textBox156.OutputFormat");
        this.textBox156.Style = "";
        this.textBox156.SummaryGroup = "groupHeader2";
        this.textBox156.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox156.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox156.Text = "textBox156";
        this.textBox156.Top = 0.0625F;
        this.textBox156.Width = 1F;
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
        this.textBox157.DataField = "d0_fin_saldo";
        this.textBox157.Height = 0.1979167F;
        this.textBox157.Left = 3.4375F;
        this.textBox157.Name = "textBox157";
        this.textBox157.OutputFormat = resources.GetString("textBox157.OutputFormat");
        this.textBox157.Style = "";
        this.textBox157.SummaryGroup = "groupHeader2";
        this.textBox157.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox157.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox157.Text = "textBox157";
        this.textBox157.Top = 0.25F;
        this.textBox157.Width = 1F;
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
        this.textBox158.DataField = "d1_fin_saldo";
        this.textBox158.Height = 0.1979167F;
        this.textBox158.Left = 4.5F;
        this.textBox158.Name = "textBox158";
        this.textBox158.OutputFormat = resources.GetString("textBox158.OutputFormat");
        this.textBox158.Style = "";
        this.textBox158.SummaryGroup = "groupHeader2";
        this.textBox158.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox158.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox158.Text = "textBox158";
        this.textBox158.Top = 0.25F;
        this.textBox158.Width = 1F;
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
        this.textBox159.DataField = "d31_fin_saldo";
        this.textBox159.Height = 0.1979167F;
        this.textBox159.Left = 5.5625F;
        this.textBox159.Name = "textBox159";
        this.textBox159.OutputFormat = resources.GetString("textBox159.OutputFormat");
        this.textBox159.Style = "";
        this.textBox159.SummaryGroup = "groupHeader2";
        this.textBox159.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox159.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox159.Text = "textBox159";
        this.textBox159.Top = 0.25F;
        this.textBox159.Width = 1F;
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
        this.textBox160.DataField = "d61_fin_saldo";
        this.textBox160.Height = 0.1979167F;
        this.textBox160.Left = 6.625F;
        this.textBox160.Name = "textBox160";
        this.textBox160.OutputFormat = resources.GetString("textBox160.OutputFormat");
        this.textBox160.Style = "";
        this.textBox160.SummaryGroup = "groupHeader2";
        this.textBox160.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox160.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox160.Text = "textBox160";
        this.textBox160.Top = 0.25F;
        this.textBox160.Width = 1F;
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
        this.textBox161.DataField = "d91_fin_saldo";
        this.textBox161.Height = 0.1979167F;
        this.textBox161.Left = 7.6875F;
        this.textBox161.Name = "textBox161";
        this.textBox161.OutputFormat = resources.GetString("textBox161.OutputFormat");
        this.textBox161.Style = "";
        this.textBox161.SummaryGroup = "groupHeader2";
        this.textBox161.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox161.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox161.Text = "textBox161";
        this.textBox161.Top = 0.25F;
        this.textBox161.Width = 1F;
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
        this.textBox162.DataField = "d121_fin_saldo";
        this.textBox162.Height = 0.1979167F;
        this.textBox162.Left = 8.75F;
        this.textBox162.Name = "textBox162";
        this.textBox162.OutputFormat = resources.GetString("textBox162.OutputFormat");
        this.textBox162.Style = "";
        this.textBox162.SummaryGroup = "groupHeader2";
        this.textBox162.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox162.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox162.Text = "textBox162";
        this.textBox162.Top = 0.25F;
        this.textBox162.Width = 1F;
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
        this.textBox163.DataField = "desp_fin_saldo";
        this.textBox163.Height = 0.1979167F;
        this.textBox163.Left = 9.8125F;
        this.textBox163.Name = "textBox163";
        this.textBox163.OutputFormat = resources.GetString("textBox163.OutputFormat");
        this.textBox163.Style = "";
        this.textBox163.SummaryGroup = "groupHeader2";
        this.textBox163.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox163.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox163.Text = "textBox163";
        this.textBox163.Top = 0.25F;
        this.textBox163.Width = 1F;
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
        this.textBox164.DataField = "rev_fin_saldo";
        this.textBox164.Height = 0.1979167F;
        this.textBox164.Left = 10.875F;
        this.textBox164.Name = "textBox164";
        this.textBox164.OutputFormat = resources.GetString("textBox164.OutputFormat");
        this.textBox164.Style = "";
        this.textBox164.SummaryGroup = "groupHeader2";
        this.textBox164.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox164.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox164.Text = "textBox164";
        this.textBox164.Top = 0.25F;
        this.textBox164.Width = 1F;
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
        this.textBox165.DataField = "fin_saldo";
        this.textBox165.Height = 0.1979167F;
        this.textBox165.Left = 11.9375F;
        this.textBox165.Name = "textBox165";
        this.textBox165.OutputFormat = resources.GetString("textBox165.OutputFormat");
        this.textBox165.Style = "";
        this.textBox165.SummaryGroup = "groupHeader2";
        this.textBox165.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox165.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox165.Text = "textBox165";
        this.textBox165.Top = 0.25F;
        this.textBox165.Width = 1F;
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
        this.textBox166.Height = 0.1875F;
        this.textBox166.Left = 2.5F;
        this.textBox166.Name = "textBox166";
        this.textBox166.Style = "";
        this.textBox166.Text = "Saldo inicial";
        this.textBox166.Top = 0.0625F;
        this.textBox166.Width = 0.875F;
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
        this.textBox167.Height = 0.1875F;
        this.textBox167.Left = 2.5F;
        this.textBox167.Name = "textBox167";
        this.textBox167.Style = "";
        this.textBox167.Text = "Saldo final";
        this.textBox167.Top = 0.25F;
        this.textBox167.Width = 0.875F;
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
        this.textBox168.Left = 2.5F;
        this.textBox168.Name = "textBox168";
        this.textBox168.Style = "";
        this.textBox168.Text = "P.Pend inicial";
        this.textBox168.Top = 0.5625F;
        this.textBox168.Width = 0.9375F;
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
        this.textBox169.DataField = "d0_ini_monto_adeuda";
        this.textBox169.Height = 0.1875F;
        this.textBox169.Left = 3.4375F;
        this.textBox169.Name = "textBox169";
        this.textBox169.OutputFormat = resources.GetString("textBox169.OutputFormat");
        this.textBox169.Style = "";
        this.textBox169.SummaryGroup = "groupHeader2";
        this.textBox169.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox169.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox169.Text = "textBox169";
        this.textBox169.Top = 0.5625F;
        this.textBox169.Width = 1F;
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
        this.textBox170.DataField = "d1_ini_monto_adeuda";
        this.textBox170.Height = 0.1875F;
        this.textBox170.Left = 4.5F;
        this.textBox170.Name = "textBox170";
        this.textBox170.OutputFormat = resources.GetString("textBox170.OutputFormat");
        this.textBox170.Style = "";
        this.textBox170.SummaryGroup = "groupHeader2";
        this.textBox170.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox170.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox170.Text = "textBox170";
        this.textBox170.Top = 0.5625F;
        this.textBox170.Width = 1F;
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
        this.textBox171.DataField = "d31_ini_monto_adeuda";
        this.textBox171.Height = 0.1875F;
        this.textBox171.Left = 5.5625F;
        this.textBox171.Name = "textBox171";
        this.textBox171.OutputFormat = resources.GetString("textBox171.OutputFormat");
        this.textBox171.Style = "";
        this.textBox171.SummaryGroup = "groupHeader2";
        this.textBox171.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox171.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox171.Text = "textBox171";
        this.textBox171.Top = 0.5625F;
        this.textBox171.Width = 1F;
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
        this.textBox172.DataField = "d61_ini_monto_adeuda";
        this.textBox172.Height = 0.1875F;
        this.textBox172.Left = 6.625F;
        this.textBox172.Name = "textBox172";
        this.textBox172.OutputFormat = resources.GetString("textBox172.OutputFormat");
        this.textBox172.Style = "";
        this.textBox172.SummaryGroup = "groupHeader2";
        this.textBox172.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox172.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox172.Text = "textBox172";
        this.textBox172.Top = 0.5625F;
        this.textBox172.Width = 1F;
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
        this.textBox173.DataField = "d91_ini_monto_adeuda";
        this.textBox173.Height = 0.1875F;
        this.textBox173.Left = 7.6875F;
        this.textBox173.Name = "textBox173";
        this.textBox173.OutputFormat = resources.GetString("textBox173.OutputFormat");
        this.textBox173.Style = "";
        this.textBox173.SummaryGroup = "groupHeader2";
        this.textBox173.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox173.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox173.Text = "textBox173";
        this.textBox173.Top = 0.5625F;
        this.textBox173.Width = 1F;
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
        this.textBox174.DataField = "d121_ini_monto_adeuda";
        this.textBox174.Height = 0.1875F;
        this.textBox174.Left = 8.75F;
        this.textBox174.Name = "textBox174";
        this.textBox174.OutputFormat = resources.GetString("textBox174.OutputFormat");
        this.textBox174.Style = "";
        this.textBox174.SummaryGroup = "groupHeader2";
        this.textBox174.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox174.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox174.Text = "textBox174";
        this.textBox174.Top = 0.5625F;
        this.textBox174.Width = 1F;
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
        this.textBox175.DataField = "desp_ini_monto_adeuda";
        this.textBox175.Height = 0.1875F;
        this.textBox175.Left = 9.8125F;
        this.textBox175.Name = "textBox175";
        this.textBox175.OutputFormat = resources.GetString("textBox175.OutputFormat");
        this.textBox175.Style = "";
        this.textBox175.SummaryGroup = "groupHeader2";
        this.textBox175.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox175.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox175.Text = "textBox175";
        this.textBox175.Top = 0.5625F;
        this.textBox175.Width = 1F;
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
        this.textBox176.DataField = "rev_ini_monto_adeuda";
        this.textBox176.Height = 0.1875F;
        this.textBox176.Left = 10.875F;
        this.textBox176.Name = "textBox176";
        this.textBox176.OutputFormat = resources.GetString("textBox176.OutputFormat");
        this.textBox176.Style = "";
        this.textBox176.SummaryGroup = "groupHeader2";
        this.textBox176.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox176.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox176.Text = "textBox176";
        this.textBox176.Top = 0.5625F;
        this.textBox176.Width = 1F;
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
        this.textBox177.DataField = "ini_monto_adeuda";
        this.textBox177.Height = 0.1875F;
        this.textBox177.Left = 11.9375F;
        this.textBox177.Name = "textBox177";
        this.textBox177.OutputFormat = resources.GetString("textBox177.OutputFormat");
        this.textBox177.Style = "";
        this.textBox177.SummaryGroup = "groupHeader2";
        this.textBox177.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox177.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox177.Text = "textBox177";
        this.textBox177.Top = 0.5625F;
        this.textBox177.Width = 1F;
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
        this.textBox178.Height = 0.1875F;
        this.textBox178.Left = 2.5F;
        this.textBox178.Name = "textBox178";
        this.textBox178.Style = "";
        this.textBox178.Text = "P.Pend final";
        this.textBox178.Top = 0.75F;
        this.textBox178.Width = 0.9375F;
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
        this.textBox179.DataField = "d0_fin_monto_adeuda";
        this.textBox179.Height = 0.1875F;
        this.textBox179.Left = 3.4375F;
        this.textBox179.Name = "textBox179";
        this.textBox179.OutputFormat = resources.GetString("textBox179.OutputFormat");
        this.textBox179.Style = "";
        this.textBox179.SummaryGroup = "groupHeader2";
        this.textBox179.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox179.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox179.Text = "textBox179";
        this.textBox179.Top = 0.75F;
        this.textBox179.Width = 1F;
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
        this.textBox180.DataField = "d1_fin_monto_adeuda";
        this.textBox180.Height = 0.1875F;
        this.textBox180.Left = 4.5F;
        this.textBox180.Name = "textBox180";
        this.textBox180.OutputFormat = resources.GetString("textBox180.OutputFormat");
        this.textBox180.Style = "";
        this.textBox180.SummaryGroup = "groupHeader2";
        this.textBox180.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox180.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox180.Text = "textBox180";
        this.textBox180.Top = 0.75F;
        this.textBox180.Width = 1F;
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
        this.textBox181.DataField = "d31_fin_monto_adeuda";
        this.textBox181.Height = 0.1875F;
        this.textBox181.Left = 5.5625F;
        this.textBox181.Name = "textBox181";
        this.textBox181.OutputFormat = resources.GetString("textBox181.OutputFormat");
        this.textBox181.Style = "";
        this.textBox181.SummaryGroup = "groupHeader2";
        this.textBox181.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox181.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox181.Text = "textBox181";
        this.textBox181.Top = 0.75F;
        this.textBox181.Width = 1F;
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
        this.textBox182.DataField = "d61_fin_monto_adeuda";
        this.textBox182.Height = 0.1875F;
        this.textBox182.Left = 6.625F;
        this.textBox182.Name = "textBox182";
        this.textBox182.OutputFormat = resources.GetString("textBox182.OutputFormat");
        this.textBox182.Style = "";
        this.textBox182.SummaryGroup = "groupHeader2";
        this.textBox182.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox182.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox182.Text = "textBox182";
        this.textBox182.Top = 0.75F;
        this.textBox182.Width = 1F;
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
        this.textBox183.DataField = "d91_fin_monto_adeuda";
        this.textBox183.Height = 0.1875F;
        this.textBox183.Left = 7.6875F;
        this.textBox183.Name = "textBox183";
        this.textBox183.OutputFormat = resources.GetString("textBox183.OutputFormat");
        this.textBox183.Style = "";
        this.textBox183.SummaryGroup = "groupHeader2";
        this.textBox183.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox183.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox183.Text = "textBox183";
        this.textBox183.Top = 0.75F;
        this.textBox183.Width = 1F;
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
        this.textBox184.DataField = "d121_fin_monto_adeuda";
        this.textBox184.Height = 0.1875F;
        this.textBox184.Left = 8.75F;
        this.textBox184.Name = "textBox184";
        this.textBox184.OutputFormat = resources.GetString("textBox184.OutputFormat");
        this.textBox184.Style = "";
        this.textBox184.SummaryGroup = "groupHeader2";
        this.textBox184.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox184.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox184.Text = "textBox184";
        this.textBox184.Top = 0.75F;
        this.textBox184.Width = 1F;
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
        this.textBox185.DataField = "desp_fin_monto_adeuda";
        this.textBox185.Height = 0.1875F;
        this.textBox185.Left = 9.8125F;
        this.textBox185.Name = "textBox185";
        this.textBox185.OutputFormat = resources.GetString("textBox185.OutputFormat");
        this.textBox185.Style = "";
        this.textBox185.SummaryGroup = "groupHeader2";
        this.textBox185.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox185.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox185.Text = "textBox185";
        this.textBox185.Top = 0.75F;
        this.textBox185.Width = 1F;
        // 
        // textBox186
        // 
        this.textBox186.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox186.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox186.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox186.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox186.Border.RightColor = System.Drawing.Color.Black;
        this.textBox186.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox186.Border.TopColor = System.Drawing.Color.Black;
        this.textBox186.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox186.DataField = "rev_fin_monto_adeuda";
        this.textBox186.Height = 0.1875F;
        this.textBox186.Left = 10.875F;
        this.textBox186.Name = "textBox186";
        this.textBox186.OutputFormat = resources.GetString("textBox186.OutputFormat");
        this.textBox186.Style = "";
        this.textBox186.SummaryGroup = "groupHeader2";
        this.textBox186.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox186.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox186.Text = "textBox186";
        this.textBox186.Top = 0.75F;
        this.textBox186.Width = 1F;
        // 
        // textBox187
        // 
        this.textBox187.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox187.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox187.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox187.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox187.Border.RightColor = System.Drawing.Color.Black;
        this.textBox187.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox187.Border.TopColor = System.Drawing.Color.Black;
        this.textBox187.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox187.DataField = "fin_monto_adeuda";
        this.textBox187.Height = 0.1875F;
        this.textBox187.Left = 11.9375F;
        this.textBox187.Name = "textBox187";
        this.textBox187.OutputFormat = resources.GetString("textBox187.OutputFormat");
        this.textBox187.Style = "";
        this.textBox187.SummaryGroup = "groupHeader2";
        this.textBox187.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox187.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox187.Text = "textBox187";
        this.textBox187.Top = 0.75F;
        this.textBox187.Width = 1F;
        // 
        // textBox188
        // 
        this.textBox188.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox188.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox188.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox188.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox188.Border.RightColor = System.Drawing.Color.Black;
        this.textBox188.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox188.Border.TopColor = System.Drawing.Color.Black;
        this.textBox188.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox188.Height = 0.1875F;
        this.textBox188.Left = 2.5F;
        this.textBox188.Name = "textBox188";
        this.textBox188.Style = "";
        this.textBox188.Text = "Nºcttos inicial";
        this.textBox188.Top = 1.0625F;
        this.textBox188.Width = 0.9375F;
        // 
        // textBox189
        // 
        this.textBox189.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox189.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox189.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox189.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox189.Border.RightColor = System.Drawing.Color.Black;
        this.textBox189.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox189.Border.TopColor = System.Drawing.Color.Black;
        this.textBox189.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox189.DataField = "d0_ini_saldo";
        this.textBox189.Height = 0.1875F;
        this.textBox189.Left = 3.4375F;
        this.textBox189.Name = "textBox189";
        this.textBox189.Style = "";
        this.textBox189.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox189.SummaryGroup = "groupHeader2";
        this.textBox189.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox189.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox189.Text = "textBox189";
        this.textBox189.Top = 1.0625F;
        this.textBox189.Width = 1F;
        // 
        // textBox190
        // 
        this.textBox190.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox190.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox190.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox190.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox190.Border.RightColor = System.Drawing.Color.Black;
        this.textBox190.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox190.Border.TopColor = System.Drawing.Color.Black;
        this.textBox190.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox190.DataField = "d1_ini_saldo";
        this.textBox190.Height = 0.1875F;
        this.textBox190.Left = 4.5F;
        this.textBox190.Name = "textBox190";
        this.textBox190.Style = "";
        this.textBox190.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox190.SummaryGroup = "groupHeader2";
        this.textBox190.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox190.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox190.Text = "textBox190";
        this.textBox190.Top = 1.0625F;
        this.textBox190.Width = 1F;
        // 
        // textBox191
        // 
        this.textBox191.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox191.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox191.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox191.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox191.Border.RightColor = System.Drawing.Color.Black;
        this.textBox191.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox191.Border.TopColor = System.Drawing.Color.Black;
        this.textBox191.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox191.DataField = "d31_ini_saldo";
        this.textBox191.Height = 0.1875F;
        this.textBox191.Left = 5.5625F;
        this.textBox191.Name = "textBox191";
        this.textBox191.Style = "";
        this.textBox191.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox191.SummaryGroup = "groupHeader2";
        this.textBox191.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox191.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox191.Text = "textBox191";
        this.textBox191.Top = 1.0625F;
        this.textBox191.Width = 1F;
        // 
        // textBox192
        // 
        this.textBox192.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox192.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox192.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox192.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox192.Border.RightColor = System.Drawing.Color.Black;
        this.textBox192.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox192.Border.TopColor = System.Drawing.Color.Black;
        this.textBox192.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox192.DataField = "d61_ini_saldo";
        this.textBox192.Height = 0.1875F;
        this.textBox192.Left = 6.625F;
        this.textBox192.Name = "textBox192";
        this.textBox192.Style = "";
        this.textBox192.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox192.SummaryGroup = "groupHeader2";
        this.textBox192.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox192.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox192.Text = "textBox192";
        this.textBox192.Top = 1.0625F;
        this.textBox192.Width = 1F;
        // 
        // textBox193
        // 
        this.textBox193.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox193.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox193.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox193.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox193.Border.RightColor = System.Drawing.Color.Black;
        this.textBox193.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox193.Border.TopColor = System.Drawing.Color.Black;
        this.textBox193.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox193.DataField = "d91_ini_saldo";
        this.textBox193.Height = 0.1875F;
        this.textBox193.Left = 7.6875F;
        this.textBox193.Name = "textBox193";
        this.textBox193.Style = "";
        this.textBox193.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox193.SummaryGroup = "groupHeader2";
        this.textBox193.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox193.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox193.Text = "textBox193";
        this.textBox193.Top = 1.0625F;
        this.textBox193.Width = 1F;
        // 
        // textBox194
        // 
        this.textBox194.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox194.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox194.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox194.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox194.Border.RightColor = System.Drawing.Color.Black;
        this.textBox194.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox194.Border.TopColor = System.Drawing.Color.Black;
        this.textBox194.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox194.DataField = "d121_ini_saldo";
        this.textBox194.Height = 0.1875F;
        this.textBox194.Left = 8.75F;
        this.textBox194.Name = "textBox194";
        this.textBox194.Style = "";
        this.textBox194.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox194.SummaryGroup = "groupHeader2";
        this.textBox194.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox194.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox194.Text = "textBox194";
        this.textBox194.Top = 1.0625F;
        this.textBox194.Width = 1F;
        // 
        // textBox195
        // 
        this.textBox195.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox195.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox195.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox195.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox195.Border.RightColor = System.Drawing.Color.Black;
        this.textBox195.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox195.Border.TopColor = System.Drawing.Color.Black;
        this.textBox195.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox195.DataField = "desp_ini_saldo";
        this.textBox195.Height = 0.1875F;
        this.textBox195.Left = 9.8125F;
        this.textBox195.Name = "textBox195";
        this.textBox195.Style = "";
        this.textBox195.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox195.SummaryGroup = "groupHeader2";
        this.textBox195.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox195.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox195.Text = "textBox195";
        this.textBox195.Top = 1.0625F;
        this.textBox195.Width = 1F;
        // 
        // textBox196
        // 
        this.textBox196.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox196.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox196.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox196.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox196.Border.RightColor = System.Drawing.Color.Black;
        this.textBox196.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox196.Border.TopColor = System.Drawing.Color.Black;
        this.textBox196.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox196.DataField = "rev_ini_saldo";
        this.textBox196.Height = 0.1875F;
        this.textBox196.Left = 10.875F;
        this.textBox196.Name = "textBox196";
        this.textBox196.Style = "";
        this.textBox196.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox196.SummaryGroup = "groupHeader2";
        this.textBox196.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox196.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox196.Text = "textBox196";
        this.textBox196.Top = 1.0625F;
        this.textBox196.Width = 1F;
        // 
        // textBox197
        // 
        this.textBox197.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox197.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox197.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox197.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox197.Border.RightColor = System.Drawing.Color.Black;
        this.textBox197.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox197.Border.TopColor = System.Drawing.Color.Black;
        this.textBox197.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox197.DataField = "ini_saldo";
        this.textBox197.Height = 0.1875F;
        this.textBox197.Left = 11.9375F;
        this.textBox197.Name = "textBox197";
        this.textBox197.Style = "";
        this.textBox197.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox197.SummaryGroup = "groupHeader2";
        this.textBox197.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox197.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox197.Text = "textBox197";
        this.textBox197.Top = 1.0625F;
        this.textBox197.Width = 1F;
        // 
        // textBox198
        // 
        this.textBox198.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox198.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox198.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox198.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox198.Border.RightColor = System.Drawing.Color.Black;
        this.textBox198.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox198.Border.TopColor = System.Drawing.Color.Black;
        this.textBox198.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox198.Height = 0.1875F;
        this.textBox198.Left = 2.5F;
        this.textBox198.Name = "textBox198";
        this.textBox198.Style = "";
        this.textBox198.Text = "Nºcttos final";
        this.textBox198.Top = 1.25F;
        this.textBox198.Width = 0.9375F;
        // 
        // textBox199
        // 
        this.textBox199.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox199.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox199.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox199.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox199.Border.RightColor = System.Drawing.Color.Black;
        this.textBox199.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox199.Border.TopColor = System.Drawing.Color.Black;
        this.textBox199.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox199.DataField = "d0_fin_saldo";
        this.textBox199.Height = 0.1875F;
        this.textBox199.Left = 3.4375F;
        this.textBox199.Name = "textBox199";
        this.textBox199.Style = "";
        this.textBox199.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox199.SummaryGroup = "groupHeader2";
        this.textBox199.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox199.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox199.Text = "textBox199";
        this.textBox199.Top = 1.25F;
        this.textBox199.Width = 1F;
        // 
        // textBox200
        // 
        this.textBox200.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox200.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox200.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox200.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox200.Border.RightColor = System.Drawing.Color.Black;
        this.textBox200.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox200.Border.TopColor = System.Drawing.Color.Black;
        this.textBox200.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox200.DataField = "d1_fin_saldo";
        this.textBox200.Height = 0.1875F;
        this.textBox200.Left = 4.5F;
        this.textBox200.Name = "textBox200";
        this.textBox200.Style = "";
        this.textBox200.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox200.SummaryGroup = "groupHeader2";
        this.textBox200.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox200.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox200.Text = "textBox200";
        this.textBox200.Top = 1.25F;
        this.textBox200.Width = 1F;
        // 
        // textBox201
        // 
        this.textBox201.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox201.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox201.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox201.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox201.Border.RightColor = System.Drawing.Color.Black;
        this.textBox201.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox201.Border.TopColor = System.Drawing.Color.Black;
        this.textBox201.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox201.DataField = "d31_fin_saldo";
        this.textBox201.Height = 0.1875F;
        this.textBox201.Left = 5.5625F;
        this.textBox201.Name = "textBox201";
        this.textBox201.Style = "";
        this.textBox201.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox201.SummaryGroup = "groupHeader2";
        this.textBox201.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox201.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox201.Text = "textBox201";
        this.textBox201.Top = 1.25F;
        this.textBox201.Width = 1F;
        // 
        // textBox202
        // 
        this.textBox202.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox202.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox202.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox202.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox202.Border.RightColor = System.Drawing.Color.Black;
        this.textBox202.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox202.Border.TopColor = System.Drawing.Color.Black;
        this.textBox202.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox202.DataField = "d61_fin_saldo";
        this.textBox202.Height = 0.1875F;
        this.textBox202.Left = 6.625F;
        this.textBox202.Name = "textBox202";
        this.textBox202.Style = "";
        this.textBox202.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox202.SummaryGroup = "groupHeader2";
        this.textBox202.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox202.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox202.Text = "textBox202";
        this.textBox202.Top = 1.25F;
        this.textBox202.Width = 1F;
        // 
        // textBox203
        // 
        this.textBox203.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox203.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox203.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox203.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox203.Border.RightColor = System.Drawing.Color.Black;
        this.textBox203.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox203.Border.TopColor = System.Drawing.Color.Black;
        this.textBox203.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox203.DataField = "d91_fin_saldo";
        this.textBox203.Height = 0.1875F;
        this.textBox203.Left = 7.6875F;
        this.textBox203.Name = "textBox203";
        this.textBox203.Style = "";
        this.textBox203.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox203.SummaryGroup = "groupHeader2";
        this.textBox203.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox203.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox203.Text = "textBox203";
        this.textBox203.Top = 1.25F;
        this.textBox203.Width = 1F;
        // 
        // textBox204
        // 
        this.textBox204.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox204.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox204.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox204.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox204.Border.RightColor = System.Drawing.Color.Black;
        this.textBox204.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox204.Border.TopColor = System.Drawing.Color.Black;
        this.textBox204.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox204.DataField = "d121_fin_saldo";
        this.textBox204.Height = 0.1875F;
        this.textBox204.Left = 8.75F;
        this.textBox204.Name = "textBox204";
        this.textBox204.Style = "";
        this.textBox204.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox204.SummaryGroup = "groupHeader2";
        this.textBox204.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox204.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox204.Text = "textBox204";
        this.textBox204.Top = 1.25F;
        this.textBox204.Width = 1F;
        // 
        // textBox205
        // 
        this.textBox205.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox205.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox205.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox205.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox205.Border.RightColor = System.Drawing.Color.Black;
        this.textBox205.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox205.Border.TopColor = System.Drawing.Color.Black;
        this.textBox205.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox205.DataField = "desp_fin_saldo";
        this.textBox205.Height = 0.1875F;
        this.textBox205.Left = 9.8125F;
        this.textBox205.Name = "textBox205";
        this.textBox205.Style = "";
        this.textBox205.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox205.SummaryGroup = "groupHeader2";
        this.textBox205.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox205.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox205.Text = "textBox205";
        this.textBox205.Top = 1.25F;
        this.textBox205.Width = 1F;
        // 
        // textBox206
        // 
        this.textBox206.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox206.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox206.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox206.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox206.Border.RightColor = System.Drawing.Color.Black;
        this.textBox206.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox206.Border.TopColor = System.Drawing.Color.Black;
        this.textBox206.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox206.DataField = "rev_fin_saldo";
        this.textBox206.Height = 0.1875F;
        this.textBox206.Left = 10.875F;
        this.textBox206.Name = "textBox206";
        this.textBox206.Style = "";
        this.textBox206.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox206.SummaryGroup = "groupHeader2";
        this.textBox206.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox206.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox206.Text = "textBox206";
        this.textBox206.Top = 1.25F;
        this.textBox206.Width = 1F;
        // 
        // textBox207
        // 
        this.textBox207.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox207.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox207.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox207.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox207.Border.RightColor = System.Drawing.Color.Black;
        this.textBox207.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox207.Border.TopColor = System.Drawing.Color.Black;
        this.textBox207.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox207.DataField = "fin_saldo";
        this.textBox207.Height = 0.1875F;
        this.textBox207.Left = 11.9375F;
        this.textBox207.Name = "textBox207";
        this.textBox207.Style = "";
        this.textBox207.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox207.SummaryGroup = "groupHeader2";
        this.textBox207.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox207.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox207.Text = "textBox207";
        this.textBox207.Top = 1.25F;
        this.textBox207.Width = 1F;
        // 
        // line59
        // 
        this.line59.Border.BottomColor = System.Drawing.Color.Black;
        this.line59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line59.Border.LeftColor = System.Drawing.Color.Black;
        this.line59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line59.Border.RightColor = System.Drawing.Color.Black;
        this.line59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line59.Border.TopColor = System.Drawing.Color.Black;
        this.line59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line59.Height = 0F;
        this.line59.Left = 2.4375F;
        this.line59.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line59.LineWeight = 1F;
        this.line59.Name = "line59";
        this.line59.Top = 1F;
        this.line59.Width = 10.5625F;
        this.line59.X1 = 2.4375F;
        this.line59.X2 = 13F;
        this.line59.Y1 = 1F;
        this.line59.Y2 = 1F;
        // 
        // line60
        // 
        this.line60.Border.BottomColor = System.Drawing.Color.Black;
        this.line60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line60.Border.LeftColor = System.Drawing.Color.Black;
        this.line60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line60.Border.RightColor = System.Drawing.Color.Black;
        this.line60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line60.Border.TopColor = System.Drawing.Color.Black;
        this.line60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line60.Height = 0F;
        this.line60.Left = 2.4375F;
        this.line60.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line60.LineWeight = 1F;
        this.line60.Name = "line60";
        this.line60.Top = 0.5F;
        this.line60.Width = 10.5625F;
        this.line60.X1 = 2.4375F;
        this.line60.X2 = 13F;
        this.line60.Y1 = 0.5F;
        this.line60.Y2 = 0.5F;
        // 
        // line62
        // 
        this.line62.Border.BottomColor = System.Drawing.Color.Black;
        this.line62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line62.Border.LeftColor = System.Drawing.Color.Black;
        this.line62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line62.Border.RightColor = System.Drawing.Color.Black;
        this.line62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line62.Border.TopColor = System.Drawing.Color.Black;
        this.line62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line62.Height = 1.5F;
        this.line62.Left = 0F;
        this.line62.LineWeight = 1F;
        this.line62.Name = "line62";
        this.line62.Top = 0F;
        this.line62.Width = 0F;
        this.line62.X1 = 0F;
        this.line62.X2 = 0F;
        this.line62.Y1 = 1.5F;
        this.line62.Y2 = 0F;
        // 
        // textBox208
        // 
        this.textBox208.Border.BottomColor = System.Drawing.Color.Black;
        this.textBox208.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox208.Border.LeftColor = System.Drawing.Color.Black;
        this.textBox208.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox208.Border.RightColor = System.Drawing.Color.Black;
        this.textBox208.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox208.Border.TopColor = System.Drawing.Color.Black;
        this.textBox208.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox208.Height = 0.1875F;
        this.textBox208.Left = 0.0625F;
        this.textBox208.Name = "textBox208";
        this.textBox208.Style = "";
        this.textBox208.Text = "TOTAL";
        this.textBox208.Top = 0.0625F;
        this.textBox208.Width = 0.625F;
        // 
        // line58
        // 
        this.line58.Border.BottomColor = System.Drawing.Color.Black;
        this.line58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line58.Border.LeftColor = System.Drawing.Color.Black;
        this.line58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line58.Border.RightColor = System.Drawing.Color.Black;
        this.line58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line58.Border.TopColor = System.Drawing.Color.Black;
        this.line58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line58.Height = 1.5F;
        this.line58.Left = 13F;
        this.line58.LineWeight = 1F;
        this.line58.Name = "line58";
        this.line58.Top = 0F;
        this.line58.Width = 0F;
        this.line58.X1 = 13F;
        this.line58.X2 = 13F;
        this.line58.Y1 = 1.5F;
        this.line58.Y2 = 0F;
        // 
        // line34
        // 
        this.line34.Border.BottomColor = System.Drawing.Color.Black;
        this.line34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line34.Border.LeftColor = System.Drawing.Color.Black;
        this.line34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line34.Border.RightColor = System.Drawing.Color.Black;
        this.line34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line34.Border.TopColor = System.Drawing.Color.Black;
        this.line34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line34.Height = 1.5F;
        this.line34.Left = 2.4375F;
        this.line34.LineWeight = 1F;
        this.line34.Name = "line34";
        this.line34.Top = 0F;
        this.line34.Width = 0F;
        this.line34.X1 = 2.4375F;
        this.line34.X2 = 2.4375F;
        this.line34.Y1 = 1.5F;
        this.line34.Y2 = 0F;
        // 
        // line35
        // 
        this.line35.Border.BottomColor = System.Drawing.Color.Black;
        this.line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line35.Border.LeftColor = System.Drawing.Color.Black;
        this.line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line35.Border.RightColor = System.Drawing.Color.Black;
        this.line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line35.Border.TopColor = System.Drawing.Color.Black;
        this.line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line35.Height = 1.5F;
        this.line35.Left = 3.4375F;
        this.line35.LineWeight = 1F;
        this.line35.Name = "line35";
        this.line35.Top = 0F;
        this.line35.Width = 0F;
        this.line35.X1 = 3.4375F;
        this.line35.X2 = 3.4375F;
        this.line35.Y1 = 1.5F;
        this.line35.Y2 = 0F;
        // 
        // line36
        // 
        this.line36.Border.BottomColor = System.Drawing.Color.Black;
        this.line36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line36.Border.LeftColor = System.Drawing.Color.Black;
        this.line36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line36.Border.RightColor = System.Drawing.Color.Black;
        this.line36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line36.Border.TopColor = System.Drawing.Color.Black;
        this.line36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line36.Height = 1.5F;
        this.line36.Left = 4.5F;
        this.line36.LineWeight = 1F;
        this.line36.Name = "line36";
        this.line36.Top = 0F;
        this.line36.Width = 0F;
        this.line36.X1 = 4.5F;
        this.line36.X2 = 4.5F;
        this.line36.Y1 = 1.5F;
        this.line36.Y2 = 0F;
        // 
        // line37
        // 
        this.line37.Border.BottomColor = System.Drawing.Color.Black;
        this.line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line37.Border.LeftColor = System.Drawing.Color.Black;
        this.line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line37.Border.RightColor = System.Drawing.Color.Black;
        this.line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line37.Border.TopColor = System.Drawing.Color.Black;
        this.line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line37.Height = 1.5F;
        this.line37.Left = 5.5625F;
        this.line37.LineWeight = 1F;
        this.line37.Name = "line37";
        this.line37.Top = 0F;
        this.line37.Width = 0F;
        this.line37.X1 = 5.5625F;
        this.line37.X2 = 5.5625F;
        this.line37.Y1 = 1.5F;
        this.line37.Y2 = 0F;
        // 
        // line38
        // 
        this.line38.Border.BottomColor = System.Drawing.Color.Black;
        this.line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line38.Border.LeftColor = System.Drawing.Color.Black;
        this.line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line38.Border.RightColor = System.Drawing.Color.Black;
        this.line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line38.Border.TopColor = System.Drawing.Color.Black;
        this.line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line38.Height = 1.5F;
        this.line38.Left = 6.625F;
        this.line38.LineWeight = 1F;
        this.line38.Name = "line38";
        this.line38.Top = 0F;
        this.line38.Width = 0F;
        this.line38.X1 = 6.625F;
        this.line38.X2 = 6.625F;
        this.line38.Y1 = 1.5F;
        this.line38.Y2 = 0F;
        // 
        // line39
        // 
        this.line39.Border.BottomColor = System.Drawing.Color.Black;
        this.line39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line39.Border.LeftColor = System.Drawing.Color.Black;
        this.line39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line39.Border.RightColor = System.Drawing.Color.Black;
        this.line39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line39.Border.TopColor = System.Drawing.Color.Black;
        this.line39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line39.Height = 1.5F;
        this.line39.Left = 7.6875F;
        this.line39.LineWeight = 1F;
        this.line39.Name = "line39";
        this.line39.Top = 0F;
        this.line39.Width = 0F;
        this.line39.X1 = 7.6875F;
        this.line39.X2 = 7.6875F;
        this.line39.Y1 = 1.5F;
        this.line39.Y2 = 0F;
        // 
        // line54
        // 
        this.line54.Border.BottomColor = System.Drawing.Color.Black;
        this.line54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line54.Border.LeftColor = System.Drawing.Color.Black;
        this.line54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line54.Border.RightColor = System.Drawing.Color.Black;
        this.line54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line54.Border.TopColor = System.Drawing.Color.Black;
        this.line54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line54.Height = 1.5F;
        this.line54.Left = 8.75F;
        this.line54.LineWeight = 1F;
        this.line54.Name = "line54";
        this.line54.Top = 0F;
        this.line54.Width = 0F;
        this.line54.X1 = 8.75F;
        this.line54.X2 = 8.75F;
        this.line54.Y1 = 1.5F;
        this.line54.Y2 = 0F;
        // 
        // line55
        // 
        this.line55.Border.BottomColor = System.Drawing.Color.Black;
        this.line55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line55.Border.LeftColor = System.Drawing.Color.Black;
        this.line55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line55.Border.RightColor = System.Drawing.Color.Black;
        this.line55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line55.Border.TopColor = System.Drawing.Color.Black;
        this.line55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line55.Height = 1.5F;
        this.line55.Left = 9.8125F;
        this.line55.LineWeight = 1F;
        this.line55.Name = "line55";
        this.line55.Top = 0F;
        this.line55.Width = 0F;
        this.line55.X1 = 9.8125F;
        this.line55.X2 = 9.8125F;
        this.line55.Y1 = 1.5F;
        this.line55.Y2 = 0F;
        // 
        // line56
        // 
        this.line56.Border.BottomColor = System.Drawing.Color.Black;
        this.line56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line56.Border.LeftColor = System.Drawing.Color.Black;
        this.line56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line56.Border.RightColor = System.Drawing.Color.Black;
        this.line56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line56.Border.TopColor = System.Drawing.Color.Black;
        this.line56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line56.Height = 1.5F;
        this.line56.Left = 10.875F;
        this.line56.LineWeight = 1F;
        this.line56.Name = "line56";
        this.line56.Top = 0F;
        this.line56.Width = 0F;
        this.line56.X1 = 10.875F;
        this.line56.X2 = 10.875F;
        this.line56.Y1 = 1.5F;
        this.line56.Y2 = 0F;
        // 
        // line57
        // 
        this.line57.Border.BottomColor = System.Drawing.Color.Black;
        this.line57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line57.Border.LeftColor = System.Drawing.Color.Black;
        this.line57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line57.Border.RightColor = System.Drawing.Color.Black;
        this.line57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line57.Border.TopColor = System.Drawing.Color.Black;
        this.line57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line57.Height = 1.5F;
        this.line57.Left = 11.9375F;
        this.line57.LineWeight = 1F;
        this.line57.Name = "line57";
        this.line57.Top = 0F;
        this.line57.Width = 0F;
        this.line57.X1 = 11.9375F;
        this.line57.X2 = 11.9375F;
        this.line57.Y1 = 1.5F;
        this.line57.Y2 = 0F;
        // 
        // line33
        // 
        this.line33.Border.BottomColor = System.Drawing.Color.Black;
        this.line33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line33.Border.LeftColor = System.Drawing.Color.Black;
        this.line33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line33.Border.RightColor = System.Drawing.Color.Black;
        this.line33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line33.Border.TopColor = System.Drawing.Color.Black;
        this.line33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.line33.Height = 0F;
        this.line33.Left = 0F;
        this.line33.LineWeight = 1F;
        this.line33.Name = "line33";
        this.line33.Top = 1.5F;
        this.line33.Width = 13F;
        this.line33.X1 = 0F;
        this.line33.X2 = 13F;
        this.line33.Y1 = 1.5F;
        this.line33.Y2 = 1.5F;
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
        this.textBox16.Left = 3.375F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Contratos asocidos al:";
        this.textBox16.Top = 1.375F;
        this.textBox16.Width = 2.125F;
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
        this.textBox29.Left = 5.5625F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "";
        this.textBox29.Text = "textBox29";
        this.textBox29.Top = 1.375F;
        this.textBox29.Width = 4.1875F;
        // 
        // rpt_resumenEvolucionGrupos
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 13.02083F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.pageFooter);
        this.Sections.Add(this.reportFooter1);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black; ", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic; ", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rpt_resumenEvolucionGrupos_ReportStart);
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox146)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox145)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox148)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox149)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox150)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox151)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox152)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox153)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox154)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox155)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox156)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox157)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox158)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox159)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox160)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox161)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox162)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox163)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox164)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox165)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox166)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox167)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox168)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox169)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox170)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox171)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox172)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox173)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox174)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox175)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox176)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox177)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox178)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox179)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox180)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox181)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox182)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox183)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox184)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox185)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox186)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox187)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox188)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox189)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox190)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox191)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox192)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox193)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox194)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox195)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox196)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox197)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox198)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox199)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox200)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox201)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox202)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox203)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox204)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox205)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox206)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox207)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox208)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion


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

    private void groupHeader2_Format(object sender, EventArgs e)
    {

    }
    private void groupFooter2_Format(object sender, EventArgs e)
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
    private void reportFooter1_Format(object sender, EventArgs e)
    {
        textBox145.Text = "";
        textBox146.Text = "";
        
        System.Drawing.Color color_nuevo = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_nuevo"]);
        System.Drawing.Color color_total = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_total"]);
        System.Drawing.Color color_total_general = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["evolucion_color_total_general"]);
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {

    }

    private void pageFooter_Format(object sender, EventArgs e)
    {
        textBox146.Text = textBox147.Text;
    }


}
