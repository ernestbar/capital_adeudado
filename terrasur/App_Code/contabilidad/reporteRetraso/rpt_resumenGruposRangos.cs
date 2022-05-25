using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_resumenGruposRangos.
/// </summary>
public class rpt_resumenGruposRangos : DataDynamics.ActiveReports.ActiveReport3
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
    private TextBox textBox31;
    private TextBox textBox34;
    private TextBox textBox58;
    private TextBox textBox59;
    private TextBox textBox60;
    private TextBox textBox61;
    private TextBox textBox62;
    private TextBox textBox63;
    private TextBox textBox64;
    private TextBox textBox65;
    private TextBox textBox16;
    private TextBox textBox29;
    private TextBox textBox30;
    private TextBox textBox32;
    private TextBox textBox33;
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
    private Line line1;
    private Line line3;
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
    private Line line14;
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
    private TextBox textBox76;
    private Line line27;
    private Line line28;
    private Line line29;
    private Line line30;
    private Line line31;
    private Line line32;
    private Line line33;
    private Line line34;
    private Line line35;
    private Line line36;
    private Line line37;
    private Line line38;
    private Line line39;
    private Line line40;
    private Line line2;
    private Line line41;
    private TextBox textBox77;
    private TextBox textBox78;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_resumenGruposRangos()
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

    public void CargarEncabezado(string Usuario, DateTime Fecha, string Negocios, string Moneda, string Consolidado, string Codigo_moneda, string Grupo_original_actual)
    {
        textBox1.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox31.Text = "Usuario: " + Usuario;

        textBox6.Text = Fecha.ToString("d");
        textBox7.Text = Negocios;
        textBox19.Text = Moneda;
        textBox21.Text = Consolidado;
        textBox78.Text = Grupo_original_actual;

        //textBox14.Text = "Efectivo en " + Codigo_moneda;
        //textBox8.Text = "Efectivo en " + Codigo_moneda;
        //textBox12.Text = "Efectivo en " + Codigo_moneda;
    }


    private void rpt_resumenGruposRangos_ReportStart(object sender, EventArgs e)
    {
        //MARGENES
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.Margins.Bottom = 0.0F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;

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
        textBox77.ClassName = "estiloEncabEnun";
        textBox78.ClassName = "estiloEncabDato";

        textBox5.ClassName = "estiloDetalleEnun";
        textBox10.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox11.ClassName = "estiloDetalleEnun";
        textBox12.ClassName = "estiloDetalleEnun";
        textBox13.ClassName = "estiloDetalleEnun";
        textBox23.ClassName = "estiloDetalleEnun";
        textBox8.ClassName = "estiloDetalleEnun";
        textBox9.ClassName = "estiloDetalleEnun";

        textBox24.ClassName = "estiloDetalleDatoString";
        textBox16.ClassName = "estiloDetalleDatoString";
        textBox29.ClassName = "estiloDetalleDatoString";
        textBox30.ClassName = "estiloDetalleDatoString";
        textBox34.ClassName = "estiloDetalleDato";
        textBox25.ClassName = "estiloDetalleDato";
        textBox15.ClassName = "estiloDetalleDato";
        textBox26.ClassName = "estiloDetalleDato";
        textBox27.ClassName = "estiloDetalleDato";
        textBox17.ClassName = "estiloDetalleDato";
        textBox22.ClassName = "estiloDetalleDato";
        textBox28.ClassName = "estiloDetalleDato";

        textBox32.ClassName = "estiloDetalleDato";
        textBox33.ClassName = "estiloDetalleDato";
        textBox34.ClassName = "estiloDetalleDato";
        textBox35.ClassName = "estiloDetalleDato";
        textBox36.ClassName = "estiloDetalleDato";
        textBox37.ClassName = "estiloDetalleDato";
        textBox38.ClassName = "estiloDetalleDato";
        textBox39.ClassName = "estiloDetalleDato";
        textBox40.ClassName = "estiloDetalleDato";
        textBox41.ClassName = "estiloDetalleDato";
        textBox42.ClassName = "estiloDetalleDato";
        textBox43.ClassName = "estiloDetalleDato";
        textBox44.ClassName = "estiloDetalleDato";
        textBox45.ClassName = "estiloDetalleDato";
        textBox46.ClassName = "estiloDetalleDato";
        textBox47.ClassName = "estiloDetalleDato";
        textBox48.ClassName = "estiloDetalleDato";

        textBox73.ClassName = "estiloDetalleDatoString";
        textBox74.ClassName = "estiloDetalleDatoString";
        textBox75.ClassName = "estiloDetalleDatoString";

        textBox76.ClassName = "estiloTotalEnun";
        textBox58.ClassName = "estiloTotal";
        textBox59.ClassName = "estiloTotal";
        textBox60.ClassName = "estiloTotal";
        textBox61.ClassName = "estiloTotal";
        textBox62.ClassName = "estiloTotal";
        textBox63.ClassName = "estiloTotal";
        textBox64.ClassName = "estiloTotal";
        textBox65.ClassName = "estiloTotal";
        textBox49.ClassName = "estiloTotal";
        textBox50.ClassName = "estiloTotal";
        textBox51.ClassName = "estiloTotal";
        textBox52.ClassName = "estiloTotal";
        textBox53.ClassName = "estiloTotal";
        textBox54.ClassName = "estiloTotal";
        textBox55.ClassName = "estiloTotal";
        textBox56.ClassName = "estiloTotal";
        textBox57.ClassName = "estiloTotal";
        textBox66.ClassName = "estiloTotal";
        textBox67.ClassName = "estiloTotal";
        textBox68.ClassName = "estiloTotal";
        textBox69.ClassName = "estiloTotal";
        textBox70.ClassName = "estiloTotal";
        textBox71.ClassName = "estiloTotal";
        textBox72.ClassName = "estiloTotal";


    }


	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_resumenGruposRangos));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line3 = new DataDynamics.ActiveReports.Line();
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
        this.line14 = new DataDynamics.ActiveReports.Line();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
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
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.line41 = new DataDynamics.ActiveReports.Line();
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
        this.textBox65 = new DataDynamics.ActiveReports.TextBox();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
        this.textBox60 = new DataDynamics.ActiveReports.TextBox();
        this.textBox61 = new DataDynamics.ActiveReports.TextBox();
        this.textBox62 = new DataDynamics.ActiveReports.TextBox();
        this.textBox63 = new DataDynamics.ActiveReports.TextBox();
        this.textBox64 = new DataDynamics.ActiveReports.TextBox();
        this.textBox59 = new DataDynamics.ActiveReports.TextBox();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox50 = new DataDynamics.ActiveReports.TextBox();
        this.textBox51 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
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
        this.line27 = new DataDynamics.ActiveReports.Line();
        this.line28 = new DataDynamics.ActiveReports.Line();
        this.line29 = new DataDynamics.ActiveReports.Line();
        this.line30 = new DataDynamics.ActiveReports.Line();
        this.line31 = new DataDynamics.ActiveReports.Line();
        this.line32 = new DataDynamics.ActiveReports.Line();
        this.line33 = new DataDynamics.ActiveReports.Line();
        this.line34 = new DataDynamics.ActiveReports.Line();
        this.line35 = new DataDynamics.ActiveReports.Line();
        this.line36 = new DataDynamics.ActiveReports.Line();
        this.line37 = new DataDynamics.ActiveReports.Line();
        this.line38 = new DataDynamics.ActiveReports.Line();
        this.line39 = new DataDynamics.ActiveReports.Line();
        this.line40 = new DataDynamics.ActiveReports.Line();
        this.textBox77 = new DataDynamics.ActiveReports.TextBox();
        this.textBox78 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox8,
            this.textBox9,
            this.textBox14,
            this.textBox23,
            this.textBox5,
            this.line1,
            this.line3,
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
            this.line14});
        this.pageHeader.Height = 0.3854167F;
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
        this.textBox10.Left = 1.625F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Contratos al día";
        this.textBox10.Top = 0F;
        this.textBox10.Width = 0.875F;
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
        this.textBox11.Left = 3.375F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Retraso de 31 a 60 días";
        this.textBox11.Top = 0F;
        this.textBox11.Width = 0.875F;
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
        this.textBox12.Left = 6F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Retraso mayor a 121";
        this.textBox12.Top = 0F;
        this.textBox12.Width = 0.875F;
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
        this.textBox13.Left = 6.875F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "Cartera especial";
        this.textBox13.Top = 0F;
        this.textBox13.Width = 0.75F;
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
        this.textBox8.Left = 4.25F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Retraso de 61 a 90 días";
        this.textBox8.Top = 0F;
        this.textBox8.Width = 0.875F;
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
        this.textBox9.Left = 5.125F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "Retraso de 91 a 120 días";
        this.textBox9.Top = 0F;
        this.textBox9.Width = 0.875F;
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
        this.textBox14.Left = 2.5F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Retraso de 1 a 30 días";
        this.textBox14.Top = 0F;
        this.textBox14.Width = 0.875F;
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
        this.textBox23.Left = 7.625F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "Total del grupo";
        this.textBox23.Top = 0F;
        this.textBox23.Width = 0.9375F;
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
        this.textBox5.Text = "Grupo";
        this.textBox5.Top = 0F;
        this.textBox5.Width = 1.0625F;
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
        this.line1.Top = 0F;
        this.line1.Width = 8.5625F;
        this.line1.X1 = 0F;
        this.line1.X2 = 8.5625F;
        this.line1.Y1 = 0F;
        this.line1.Y2 = 0F;
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
        this.line3.Height = 0.375F;
        this.line3.Left = 0F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0F;
        this.line3.Width = 0F;
        this.line3.X1 = 0F;
        this.line3.X2 = 0F;
        this.line3.Y1 = 0F;
        this.line3.Y2 = 0.375F;
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
        this.line4.Height = 0.375F;
        this.line4.Left = 1.0625F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 0F;
        this.line4.X1 = 1.0625F;
        this.line4.X2 = 1.0625F;
        this.line4.Y1 = 0F;
        this.line4.Y2 = 0.375F;
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
        this.line5.Height = 0.375F;
        this.line5.Left = 1.625F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 0F;
        this.line5.X1 = 1.625F;
        this.line5.X2 = 1.625F;
        this.line5.Y1 = 0F;
        this.line5.Y2 = 0.375F;
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
        this.line6.Height = 0.375F;
        this.line6.Left = 2.5F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0F;
        this.line6.Width = 0F;
        this.line6.X1 = 2.5F;
        this.line6.X2 = 2.5F;
        this.line6.Y1 = 0F;
        this.line6.Y2 = 0.375F;
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
        this.line7.Height = 0.375F;
        this.line7.Left = 3.375F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0F;
        this.line7.Width = 0F;
        this.line7.X1 = 3.375F;
        this.line7.X2 = 3.375F;
        this.line7.Y1 = 0F;
        this.line7.Y2 = 0.375F;
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
        this.line8.Height = 0.375F;
        this.line8.Left = 4.25F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0F;
        this.line8.Width = 0F;
        this.line8.X1 = 4.25F;
        this.line8.X2 = 4.25F;
        this.line8.Y1 = 0F;
        this.line8.Y2 = 0.375F;
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
        this.line9.Height = 0.375F;
        this.line9.Left = 5.125F;
        this.line9.LineWeight = 1F;
        this.line9.Name = "line9";
        this.line9.Top = 0F;
        this.line9.Width = 0F;
        this.line9.X1 = 5.125F;
        this.line9.X2 = 5.125F;
        this.line9.Y1 = 0F;
        this.line9.Y2 = 0.375F;
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
        this.line10.Height = 0.375F;
        this.line10.Left = 6F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 0F;
        this.line10.Width = 0F;
        this.line10.X1 = 6F;
        this.line10.X2 = 6F;
        this.line10.Y1 = 0F;
        this.line10.Y2 = 0.375F;
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
        this.line11.Height = 0.375F;
        this.line11.Left = 6.875F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 0F;
        this.line11.Width = 0F;
        this.line11.X1 = 6.875F;
        this.line11.X2 = 6.875F;
        this.line11.Y1 = 0F;
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
        this.line12.Height = 0.375F;
        this.line12.Left = 7.625F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 0F;
        this.line12.Width = 0F;
        this.line12.X1 = 7.625F;
        this.line12.X2 = 7.625F;
        this.line12.Y1 = 0F;
        this.line12.Y2 = 0.375F;
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
        this.line13.Height = 0.375F;
        this.line13.Left = 8.5625F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 0F;
        this.line13.Width = 0F;
        this.line13.X1 = 8.5625F;
        this.line13.X2 = 8.5625F;
        this.line13.Y1 = 0F;
        this.line13.Y2 = 0.375F;
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
        this.line14.Left = 0F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 0.375F;
        this.line14.Width = 8.5625F;
        this.line14.X1 = 0F;
        this.line14.X2 = 8.5625F;
        this.line14.Y1 = 0.375F;
        this.line14.Y2 = 0.375F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox24,
            this.textBox25,
            this.textBox17,
            this.textBox26,
            this.textBox22,
            this.textBox27,
            this.textBox28,
            this.textBox15,
            this.textBox34,
            this.textBox16,
            this.textBox29,
            this.textBox30,
            this.textBox32,
            this.textBox33,
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
            this.line2,
            this.line41});
        this.detail.Height = 0.5729167F;
        this.detail.KeepTogether = true;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
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
        this.textBox24.DataField = "grupo";
        this.textBox24.Height = 0.1875F;
        this.textBox24.Left = 0F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "textBox24";
        this.textBox24.Top = 0F;
        this.textBox24.Width = 1.0625F;
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
        this.textBox25.DataField = "d1_saldo";
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 2.5F;
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
        this.textBox25.Style = "";
        this.textBox25.Text = "textBox25";
        this.textBox25.Top = 0F;
        this.textBox25.Width = 0.875F;
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
        this.textBox17.DataField = "d91_saldo";
        this.textBox17.Height = 0.1875F;
        this.textBox17.Left = 5.125F;
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
        this.textBox17.Style = "";
        this.textBox17.Text = "textBox17";
        this.textBox17.Top = 0F;
        this.textBox17.Width = 0.875F;
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
        this.textBox26.DataField = "d61_saldo";
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 4.25F;
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
        this.textBox26.Style = "";
        this.textBox26.Text = "textBox26";
        this.textBox26.Top = 0F;
        this.textBox26.Width = 0.875F;
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
        this.textBox22.DataField = "d121_saldo";
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 6F;
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
        this.textBox22.Style = "";
        this.textBox22.Text = "textBox22";
        this.textBox22.Top = 0F;
        this.textBox22.Width = 0.875F;
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
        this.textBox27.DataField = "desp_saldo";
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 6.875F;
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
        this.textBox27.Style = "";
        this.textBox27.Text = "textBox27";
        this.textBox27.Top = 0F;
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
        this.textBox28.DataField = "tot_saldo";
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 7.625F;
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
        this.textBox28.Style = "";
        this.textBox28.Text = "textBox28";
        this.textBox28.Top = 0F;
        this.textBox28.Width = 0.9375F;
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
        this.textBox15.DataField = "d31_saldo";
        this.textBox15.Height = 0.1875F;
        this.textBox15.Left = 3.375F;
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
        this.textBox15.Style = "";
        this.textBox15.Text = "textBox15";
        this.textBox15.Top = 0F;
        this.textBox15.Width = 0.875F;
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
        this.textBox34.DataField = "d0_saldo";
        this.textBox34.Height = 0.1875F;
        this.textBox34.Left = 1.625F;
        this.textBox34.Name = "textBox34";
        this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
        this.textBox34.Style = "";
        this.textBox34.Text = "textBox34";
        this.textBox34.Top = 0F;
        this.textBox34.Width = 0.875F;
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
        this.textBox16.Left = 1.0625F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Saldo";
        this.textBox16.Top = 0F;
        this.textBox16.Width = 0.5625F;
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
        this.textBox29.Left = 1.0625F;
        this.textBox29.Name = "textBox29";
        this.textBox29.Style = "";
        this.textBox29.Text = "P.Pend.";
        this.textBox29.Top = 0.1875F;
        this.textBox29.Width = 0.5625F;
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
        this.textBox30.Left = 1.0625F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "Nºcttos";
        this.textBox30.Top = 0.375F;
        this.textBox30.Width = 0.5625F;
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
        this.textBox32.DataField = "d0_pagos";
        this.textBox32.Height = 0.1875F;
        this.textBox32.Left = 1.625F;
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
        this.textBox32.Style = "";
        this.textBox32.Text = "textBox32";
        this.textBox32.Top = 0.1875F;
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
        this.textBox33.DataField = "d1_pagos";
        this.textBox33.Height = 0.1875F;
        this.textBox33.Left = 2.5F;
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
        this.textBox33.Style = "";
        this.textBox33.Text = "textBox33";
        this.textBox33.Top = 0.1875F;
        this.textBox33.Width = 0.875F;
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
        this.textBox35.DataField = "d31_pagos";
        this.textBox35.Height = 0.1875F;
        this.textBox35.Left = 3.375F;
        this.textBox35.Name = "textBox35";
        this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
        this.textBox35.Style = "";
        this.textBox35.Text = "textBox35";
        this.textBox35.Top = 0.1875F;
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
        this.textBox36.DataField = "d61_pagos";
        this.textBox36.Height = 0.1875F;
        this.textBox36.Left = 4.25F;
        this.textBox36.Name = "textBox36";
        this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
        this.textBox36.Style = "";
        this.textBox36.Text = "textBox36";
        this.textBox36.Top = 0.1875F;
        this.textBox36.Width = 0.875F;
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
        this.textBox37.DataField = "d91_pagos";
        this.textBox37.Height = 0.1875F;
        this.textBox37.Left = 5.125F;
        this.textBox37.Name = "textBox37";
        this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
        this.textBox37.Style = "";
        this.textBox37.Text = "textBox37";
        this.textBox37.Top = 0.1875F;
        this.textBox37.Width = 0.875F;
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
        this.textBox38.DataField = "d121_pagos";
        this.textBox38.Height = 0.1875F;
        this.textBox38.Left = 6F;
        this.textBox38.Name = "textBox38";
        this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
        this.textBox38.Style = "";
        this.textBox38.Text = "textBox38";
        this.textBox38.Top = 0.1875F;
        this.textBox38.Width = 0.875F;
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
        this.textBox39.DataField = "desp_pagos";
        this.textBox39.Height = 0.1875F;
        this.textBox39.Left = 6.875F;
        this.textBox39.Name = "textBox39";
        this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
        this.textBox39.Style = "";
        this.textBox39.Text = "textBox39";
        this.textBox39.Top = 0.1875F;
        this.textBox39.Width = 0.75F;
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
        this.textBox40.DataField = "tot_pagos";
        this.textBox40.Height = 0.1875F;
        this.textBox40.Left = 7.625F;
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
        this.textBox40.Style = "";
        this.textBox40.Text = "textBox40";
        this.textBox40.Top = 0.1875F;
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
        this.textBox41.DataField = "d0_num_contratos";
        this.textBox41.Height = 0.1875F;
        this.textBox41.Left = 1.625F;
        this.textBox41.Name = "textBox41";
        this.textBox41.Style = "";
        this.textBox41.Text = "textBox41";
        this.textBox41.Top = 0.375F;
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
        this.textBox42.DataField = "d1_num_contratos";
        this.textBox42.Height = 0.1875F;
        this.textBox42.Left = 2.5F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 0.375F;
        this.textBox42.Width = 0.875F;
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
        this.textBox43.DataField = "d31_num_contratos";
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 3.375F;
        this.textBox43.Name = "textBox43";
        this.textBox43.Style = "";
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0.375F;
        this.textBox43.Width = 0.875F;
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
        this.textBox44.DataField = "d61_num_contratos";
        this.textBox44.Height = 0.1875F;
        this.textBox44.Left = 4.25F;
        this.textBox44.Name = "textBox44";
        this.textBox44.Style = "";
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 0.375F;
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
        this.textBox45.DataField = "d91_num_contratos";
        this.textBox45.Height = 0.1875F;
        this.textBox45.Left = 5.125F;
        this.textBox45.Name = "textBox45";
        this.textBox45.Style = "";
        this.textBox45.Text = "textBox45";
        this.textBox45.Top = 0.375F;
        this.textBox45.Width = 0.875F;
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
        this.textBox46.DataField = "d121_num_contratos";
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 6F;
        this.textBox46.Name = "textBox46";
        this.textBox46.Style = "";
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0.375F;
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
        this.textBox47.DataField = "desp_num_contratos";
        this.textBox47.Height = 0.1875F;
        this.textBox47.Left = 6.875F;
        this.textBox47.Name = "textBox47";
        this.textBox47.Style = "";
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0.375F;
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
        this.textBox48.DataField = "tot_num_contratos";
        this.textBox48.Height = 0.1875F;
        this.textBox48.Left = 7.625F;
        this.textBox48.Name = "textBox48";
        this.textBox48.Style = "";
        this.textBox48.Text = "textBox48";
        this.textBox48.Top = 0.375F;
        this.textBox48.Width = 0.9375F;
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
        this.line15.Left = 0F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 0.5625F;
        this.line15.Width = 8.5625F;
        this.line15.X1 = 0F;
        this.line15.X2 = 8.5625F;
        this.line15.Y1 = 0.5625F;
        this.line15.Y2 = 0.5625F;
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
        this.line16.Height = 0.5625F;
        this.line16.Left = 0F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 0F;
        this.line16.Width = 0F;
        this.line16.X1 = 0F;
        this.line16.X2 = 0F;
        this.line16.Y1 = 0F;
        this.line16.Y2 = 0.5625F;
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
        this.line17.Left = 1.0625F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 0F;
        this.line17.Width = 0F;
        this.line17.X1 = 1.0625F;
        this.line17.X2 = 1.0625F;
        this.line17.Y1 = 0F;
        this.line17.Y2 = 0.5625F;
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
        this.line18.Height = 0.5625F;
        this.line18.Left = 1.625F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 0F;
        this.line18.Width = 0F;
        this.line18.X1 = 1.625F;
        this.line18.X2 = 1.625F;
        this.line18.Y1 = 0F;
        this.line18.Y2 = 0.5625F;
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
        this.line19.Height = 0.5625F;
        this.line19.Left = 2.5F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 0F;
        this.line19.Width = 0F;
        this.line19.X1 = 2.5F;
        this.line19.X2 = 2.5F;
        this.line19.Y1 = 0F;
        this.line19.Y2 = 0.5625F;
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
        this.line20.Height = 0.5625F;
        this.line20.Left = 4.25F;
        this.line20.LineWeight = 1F;
        this.line20.Name = "line20";
        this.line20.Top = 0F;
        this.line20.Width = 0F;
        this.line20.X1 = 4.25F;
        this.line20.X2 = 4.25F;
        this.line20.Y1 = 0F;
        this.line20.Y2 = 0.5625F;
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
        this.line21.Height = 0.5625F;
        this.line21.Left = 3.375F;
        this.line21.LineWeight = 1F;
        this.line21.Name = "line21";
        this.line21.Top = 0F;
        this.line21.Width = 0F;
        this.line21.X1 = 3.375F;
        this.line21.X2 = 3.375F;
        this.line21.Y1 = 0F;
        this.line21.Y2 = 0.5625F;
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
        this.line22.Height = 0.5625F;
        this.line22.Left = 5.125F;
        this.line22.LineWeight = 1F;
        this.line22.Name = "line22";
        this.line22.Top = 0F;
        this.line22.Width = 0F;
        this.line22.X1 = 5.125F;
        this.line22.X2 = 5.125F;
        this.line22.Y1 = 0F;
        this.line22.Y2 = 0.5625F;
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
        this.line23.Height = 0.5625F;
        this.line23.Left = 6F;
        this.line23.LineWeight = 1F;
        this.line23.Name = "line23";
        this.line23.Top = 0F;
        this.line23.Width = 0F;
        this.line23.X1 = 6F;
        this.line23.X2 = 6F;
        this.line23.Y1 = 0F;
        this.line23.Y2 = 0.5625F;
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
        this.line24.Height = 0.5625F;
        this.line24.Left = 6.875F;
        this.line24.LineWeight = 1F;
        this.line24.Name = "line24";
        this.line24.Top = 0F;
        this.line24.Width = 0F;
        this.line24.X1 = 6.875F;
        this.line24.X2 = 6.875F;
        this.line24.Y1 = 0F;
        this.line24.Y2 = 0.5625F;
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
        this.line25.Height = 0.5625F;
        this.line25.Left = 7.625F;
        this.line25.LineWeight = 1F;
        this.line25.Name = "line25";
        this.line25.Top = 0F;
        this.line25.Width = 0F;
        this.line25.X1 = 7.625F;
        this.line25.X2 = 7.625F;
        this.line25.Y1 = 0F;
        this.line25.Y2 = 0.5625F;
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
        this.line26.Left = 8.5625F;
        this.line26.LineWeight = 1F;
        this.line26.Name = "line26";
        this.line26.Top = 0F;
        this.line26.Width = 0F;
        this.line26.X1 = 8.5625F;
        this.line26.X2 = 8.5625F;
        this.line26.Y1 = 0F;
        this.line26.Y2 = 0.5625F;
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
        this.line2.Left = 1.0625F;
        this.line2.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0.1875F;
        this.line2.Width = 7.5F;
        this.line2.X1 = 1.0625F;
        this.line2.X2 = 8.5625F;
        this.line2.Y1 = 0.1875F;
        this.line2.Y2 = 0.1875F;
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
        this.line41.Left = 1.0625F;
        this.line41.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line41.LineWeight = 1F;
        this.line41.Name = "line41";
        this.line41.Top = 0.375F;
        this.line41.Width = 7.5F;
        this.line41.X1 = 1.0625F;
        this.line41.X2 = 8.5625F;
        this.line41.Y1 = 0.375F;
        this.line41.Y2 = 0.375F;
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
            this.textBox77,
            this.textBox78});
        this.reportHeader1.Height = 1.510417F;
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
        this.textBox1.Left = 4.25F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = null;
        this.textBox1.Top = 0F;
        this.textBox1.Width = 4.3125F;
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
        this.textBox2.Left = 0F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Resumen de cartera vigente por grupos y rangos de retraso";
        this.textBox2.Top = 0.375F;
        this.textBox2.Width = 8.5625F;
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
        this.textBox3.Left = 1.625F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "A la fecha:";
        this.textBox3.Top = 0.5625F;
        this.textBox3.Width = 1.75F;
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
        this.textBox4.Left = 1.625F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Negocio:";
        this.textBox4.Top = 0.75F;
        this.textBox4.Width = 1.75F;
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
        this.textBox6.Left = 3.375F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = null;
        this.textBox6.Top = 0.5625F;
        this.textBox6.Width = 3.5F;
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
        this.textBox7.Left = 3.375F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = null;
        this.textBox7.Top = 0.75F;
        this.textBox7.Width = 3.5F;
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
        this.textBox18.Left = 1.625F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "MONEDA:";
        this.textBox18.Top = 0.9375F;
        this.textBox18.Width = 1.75F;
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
        this.textBox19.Left = 3.375F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "textBox19";
        this.textBox19.Top = 0.9375F;
        this.textBox19.Width = 3.5F;
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
        this.textBox20.Left = 1.625F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "DATOS:";
        this.textBox20.Top = 1.125F;
        this.textBox20.Width = 1.75F;
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
        this.textBox21.Left = 3.375F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "textBox21";
        this.textBox21.Top = 1.125F;
        this.textBox21.Width = 3.5F;
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
        this.textBox31.Left = 4.25F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "textBox31";
        this.textBox31.Top = 0.1875F;
        this.textBox31.Width = 4.3125F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox65,
            this.textBox58,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.textBox63,
            this.textBox64,
            this.textBox59,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
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
            this.line27,
            this.line28,
            this.line29,
            this.line30,
            this.line31,
            this.line32,
            this.line33,
            this.line34,
            this.line35,
            this.line36,
            this.line37,
            this.line38,
            this.line39,
            this.line40});
        this.reportFooter1.Height = 0.5729167F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.textBox65.DataField = "tot_saldo";
        this.textBox65.Height = 0.1875F;
        this.textBox65.Left = 7.625F;
        this.textBox65.Name = "textBox65";
        this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
        this.textBox65.Style = "";
        this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox65.Text = "textBox65";
        this.textBox65.Top = 0F;
        this.textBox65.Width = 0.9375F;
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
        this.textBox58.DataField = "d0_saldo";
        this.textBox58.Height = 0.1875F;
        this.textBox58.Left = 1.625F;
        this.textBox58.Name = "textBox58";
        this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
        this.textBox58.Style = "";
        this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox58.Text = "textBox58";
        this.textBox58.Top = 0F;
        this.textBox58.Width = 0.875F;
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
        this.textBox60.DataField = "d31_saldo";
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 3.375F;
        this.textBox60.Name = "textBox60";
        this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
        this.textBox60.Style = "";
        this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox61.DataField = "d61_saldo";
        this.textBox61.Height = 0.1875F;
        this.textBox61.Left = 4.25F;
        this.textBox61.Name = "textBox61";
        this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
        this.textBox61.Style = "";
        this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox62.DataField = "d91_saldo";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 5.125F;
        this.textBox62.Name = "textBox62";
        this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
        this.textBox62.Style = "";
        this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox63.DataField = "d121_saldo";
        this.textBox63.Height = 0.1875F;
        this.textBox63.Left = 6F;
        this.textBox63.Name = "textBox63";
        this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
        this.textBox63.Style = "";
        this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
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
        this.textBox64.DataField = "desp_saldo";
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 6.875F;
        this.textBox64.Name = "textBox64";
        this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
        this.textBox64.Style = "";
        this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox64.Text = "textBox64";
        this.textBox64.Top = 0F;
        this.textBox64.Width = 0.75F;
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
        this.textBox59.DataField = "d1_saldo";
        this.textBox59.Height = 0.1875F;
        this.textBox59.Left = 2.5F;
        this.textBox59.Name = "textBox59";
        this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
        this.textBox59.Style = "";
        this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox59.Text = "textBox59";
        this.textBox59.Top = 0F;
        this.textBox59.Width = 0.875F;
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
        this.textBox49.DataField = "d0_pagos";
        this.textBox49.Height = 0.1875F;
        this.textBox49.Left = 1.625F;
        this.textBox49.Name = "textBox49";
        this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
        this.textBox49.Style = "";
        this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox49.Text = "textBox49";
        this.textBox49.Top = 0.1875F;
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
        this.textBox50.DataField = "d1_pagos";
        this.textBox50.Height = 0.1875F;
        this.textBox50.Left = 2.5F;
        this.textBox50.Name = "textBox50";
        this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
        this.textBox50.Style = "";
        this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox50.Text = "textBox50";
        this.textBox50.Top = 0.1875F;
        this.textBox50.Width = 0.875F;
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
        this.textBox51.DataField = "d31_pagos";
        this.textBox51.Height = 0.1875F;
        this.textBox51.Left = 3.375F;
        this.textBox51.Name = "textBox51";
        this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
        this.textBox51.Style = "";
        this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox51.Text = "textBox51";
        this.textBox51.Top = 0.1875F;
        this.textBox51.Width = 0.875F;
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
        this.textBox52.DataField = "d61_pagos";
        this.textBox52.Height = 0.1875F;
        this.textBox52.Left = 4.25F;
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
        this.textBox52.Style = "";
        this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox52.Text = "textBox52";
        this.textBox52.Top = 0.1875F;
        this.textBox52.Width = 0.875F;
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
        this.textBox53.DataField = "d91_pagos";
        this.textBox53.Height = 0.1875F;
        this.textBox53.Left = 5.125F;
        this.textBox53.Name = "textBox53";
        this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
        this.textBox53.Style = "";
        this.textBox53.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox53.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox53.Text = "textBox53";
        this.textBox53.Top = 0.1875F;
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
        this.textBox54.DataField = "d121_pagos";
        this.textBox54.Height = 0.1875F;
        this.textBox54.Left = 6F;
        this.textBox54.Name = "textBox54";
        this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
        this.textBox54.Style = "";
        this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox54.Text = "textBox54";
        this.textBox54.Top = 0.1875F;
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
        this.textBox55.DataField = "desp_pagos";
        this.textBox55.Height = 0.1875F;
        this.textBox55.Left = 6.875F;
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
        this.textBox55.Style = "";
        this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox55.Text = "textBox55";
        this.textBox55.Top = 0.1875F;
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
        this.textBox56.DataField = "tot_pagos";
        this.textBox56.Height = 0.1875F;
        this.textBox56.Left = 7.625F;
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
        this.textBox56.Style = "";
        this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox56.Text = "textBox56";
        this.textBox56.Top = 0.1875F;
        this.textBox56.Width = 0.9375F;
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
        this.textBox57.DataField = "d0_num_contratos";
        this.textBox57.Height = 0.1875F;
        this.textBox57.Left = 1.625F;
        this.textBox57.Name = "textBox57";
        this.textBox57.Style = "";
        this.textBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox57.Text = "textBox57";
        this.textBox57.Top = 0.375F;
        this.textBox57.Width = 0.875F;
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
        this.textBox66.DataField = "d1_num_contratos";
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 2.5F;
        this.textBox66.Name = "textBox66";
        this.textBox66.Style = "";
        this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox66.Text = "textBox66";
        this.textBox66.Top = 0.375F;
        this.textBox66.Width = 0.875F;
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
        this.textBox67.DataField = "d31_num_contratos";
        this.textBox67.Height = 0.1875F;
        this.textBox67.Left = 3.375F;
        this.textBox67.Name = "textBox67";
        this.textBox67.Style = "";
        this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox67.Text = "textBox67";
        this.textBox67.Top = 0.375F;
        this.textBox67.Width = 0.875F;
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
        this.textBox68.DataField = "d61_num_contratos";
        this.textBox68.Height = 0.1875F;
        this.textBox68.Left = 4.25F;
        this.textBox68.Name = "textBox68";
        this.textBox68.Style = "";
        this.textBox68.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox68.Text = "textBox68";
        this.textBox68.Top = 0.375F;
        this.textBox68.Width = 0.875F;
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
        this.textBox69.DataField = "d91_num_contratos";
        this.textBox69.Height = 0.1875F;
        this.textBox69.Left = 5.125F;
        this.textBox69.Name = "textBox69";
        this.textBox69.Style = "";
        this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox69.Text = "textBox69";
        this.textBox69.Top = 0.375F;
        this.textBox69.Width = 0.875F;
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
        this.textBox70.DataField = "d121_num_contratos";
        this.textBox70.Height = 0.1875F;
        this.textBox70.Left = 6F;
        this.textBox70.Name = "textBox70";
        this.textBox70.Style = "";
        this.textBox70.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox70.Text = "textBox70";
        this.textBox70.Top = 0.375F;
        this.textBox70.Width = 0.875F;
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
        this.textBox71.DataField = "desp_num_contratos";
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 6.875F;
        this.textBox71.Name = "textBox71";
        this.textBox71.Style = "";
        this.textBox71.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox71.Text = "textBox71";
        this.textBox71.Top = 0.375F;
        this.textBox71.Width = 0.75F;
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
        this.textBox72.DataField = "tot_num_contratos";
        this.textBox72.Height = 0.1875F;
        this.textBox72.Left = 7.625F;
        this.textBox72.Name = "textBox72";
        this.textBox72.Style = "";
        this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox72.Text = "textBox72";
        this.textBox72.Top = 0.375F;
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
        this.textBox73.Height = 0.1875F;
        this.textBox73.Left = 1.0625F;
        this.textBox73.Name = "textBox73";
        this.textBox73.Style = "";
        this.textBox73.Text = "Saldo";
        this.textBox73.Top = 0F;
        this.textBox73.Width = 0.5625F;
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
        this.textBox74.Left = 1.0625F;
        this.textBox74.Name = "textBox74";
        this.textBox74.Style = "";
        this.textBox74.Text = "P.Pend.";
        this.textBox74.Top = 0.1875F;
        this.textBox74.Width = 0.5625F;
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
        this.textBox75.Left = 1.0625F;
        this.textBox75.Name = "textBox75";
        this.textBox75.Style = "";
        this.textBox75.Text = "Nºcttos";
        this.textBox75.Top = 0.375F;
        this.textBox75.Width = 0.5625F;
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
        this.textBox76.Left = 0F;
        this.textBox76.Name = "textBox76";
        this.textBox76.Style = "";
        this.textBox76.Text = "Total:";
        this.textBox76.Top = 0F;
        this.textBox76.Width = 1.0625F;
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
        this.line27.Top = 0.5625F;
        this.line27.Width = 8.5625F;
        this.line27.X1 = 0F;
        this.line27.X2 = 8.5625F;
        this.line27.Y1 = 0.5625F;
        this.line27.Y2 = 0.5625F;
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
        this.line28.Height = 0.5625F;
        this.line28.Left = 0F;
        this.line28.LineWeight = 1F;
        this.line28.Name = "line28";
        this.line28.Top = 0F;
        this.line28.Width = 0F;
        this.line28.X1 = 0F;
        this.line28.X2 = 0F;
        this.line28.Y1 = 0F;
        this.line28.Y2 = 0.5625F;
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
        this.line29.Height = 0.5625F;
        this.line29.Left = 1.0625F;
        this.line29.LineWeight = 1F;
        this.line29.Name = "line29";
        this.line29.Top = 0F;
        this.line29.Width = 0F;
        this.line29.X1 = 1.0625F;
        this.line29.X2 = 1.0625F;
        this.line29.Y1 = 0F;
        this.line29.Y2 = 0.5625F;
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
        this.line30.Height = 0.5625F;
        this.line30.Left = 1.625F;
        this.line30.LineWeight = 1F;
        this.line30.Name = "line30";
        this.line30.Top = 0F;
        this.line30.Width = 0F;
        this.line30.X1 = 1.625F;
        this.line30.X2 = 1.625F;
        this.line30.Y1 = 0F;
        this.line30.Y2 = 0.5625F;
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
        this.line31.Height = 0.5625F;
        this.line31.Left = 2.5F;
        this.line31.LineWeight = 1F;
        this.line31.Name = "line31";
        this.line31.Top = 0F;
        this.line31.Width = 0F;
        this.line31.X1 = 2.5F;
        this.line31.X2 = 2.5F;
        this.line31.Y1 = 0F;
        this.line31.Y2 = 0.5625F;
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
        this.line32.Height = 0.5625F;
        this.line32.Left = 3.375F;
        this.line32.LineWeight = 1F;
        this.line32.Name = "line32";
        this.line32.Top = 0F;
        this.line32.Width = 0F;
        this.line32.X1 = 3.375F;
        this.line32.X2 = 3.375F;
        this.line32.Y1 = 0F;
        this.line32.Y2 = 0.5625F;
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
        this.line33.Height = 0.5625F;
        this.line33.Left = 4.25F;
        this.line33.LineWeight = 1F;
        this.line33.Name = "line33";
        this.line33.Top = 0F;
        this.line33.Width = 0F;
        this.line33.X1 = 4.25F;
        this.line33.X2 = 4.25F;
        this.line33.Y1 = 0F;
        this.line33.Y2 = 0.5625F;
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
        this.line34.Height = 0.5625F;
        this.line34.Left = 5.125F;
        this.line34.LineWeight = 1F;
        this.line34.Name = "line34";
        this.line34.Top = 0F;
        this.line34.Width = 0F;
        this.line34.X1 = 5.125F;
        this.line34.X2 = 5.125F;
        this.line34.Y1 = 0F;
        this.line34.Y2 = 0.5625F;
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
        this.line35.Height = 0.5625F;
        this.line35.Left = 6F;
        this.line35.LineWeight = 1F;
        this.line35.Name = "line35";
        this.line35.Top = 0F;
        this.line35.Width = 0F;
        this.line35.X1 = 6F;
        this.line35.X2 = 6F;
        this.line35.Y1 = 0F;
        this.line35.Y2 = 0.5625F;
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
        this.line36.Height = 0.5625F;
        this.line36.Left = 6.875F;
        this.line36.LineWeight = 1F;
        this.line36.Name = "line36";
        this.line36.Top = 0F;
        this.line36.Width = 0F;
        this.line36.X1 = 6.875F;
        this.line36.X2 = 6.875F;
        this.line36.Y1 = 0F;
        this.line36.Y2 = 0.5625F;
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
        this.line37.Height = 0.5625F;
        this.line37.Left = 7.625F;
        this.line37.LineWeight = 1F;
        this.line37.Name = "line37";
        this.line37.Top = 0F;
        this.line37.Width = 0F;
        this.line37.X1 = 7.625F;
        this.line37.X2 = 7.625F;
        this.line37.Y1 = 0F;
        this.line37.Y2 = 0.5625F;
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
        this.line38.Height = 0.5625F;
        this.line38.Left = 8.5625F;
        this.line38.LineWeight = 1F;
        this.line38.Name = "line38";
        this.line38.Top = 0F;
        this.line38.Width = 0F;
        this.line38.X1 = 8.5625F;
        this.line38.X2 = 8.5625F;
        this.line38.Y1 = 0F;
        this.line38.Y2 = 0.5625F;
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
        this.line39.Height = 0F;
        this.line39.Left = 1.0625F;
        this.line39.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line39.LineWeight = 1F;
        this.line39.Name = "line39";
        this.line39.Top = 0.1875F;
        this.line39.Width = 7.5F;
        this.line39.X1 = 1.0625F;
        this.line39.X2 = 8.5625F;
        this.line39.Y1 = 0.1875F;
        this.line39.Y2 = 0.1875F;
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
        this.line40.Height = 0F;
        this.line40.Left = 1.0625F;
        this.line40.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
        this.line40.LineWeight = 1F;
        this.line40.Name = "line40";
        this.line40.Top = 0.375F;
        this.line40.Width = 7.5F;
        this.line40.X1 = 1.0625F;
        this.line40.X2 = 8.5625F;
        this.line40.Y1 = 0.375F;
        this.line40.Y2 = 0.375F;
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
        this.textBox77.Left = 1.625F;
        this.textBox77.Name = "textBox77";
        this.textBox77.Style = "";
        this.textBox77.Text = "Contratos asocidos al:";
        this.textBox77.Top = 1.3125F;
        this.textBox77.Width = 1.75F;
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
        this.textBox78.Height = 0.1875F;
        this.textBox78.Left = 3.375F;
        this.textBox78.Name = "textBox78";
        this.textBox78.Style = "";
        this.textBox78.Text = "textBox78";
        this.textBox78.Top = 1.3125F;
        this.textBox78.Width = 3.5F;
        // 
        // rpt_resumenGruposRangos
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 8.572917F;
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
        this.ReportStart += new System.EventHandler(this.rpt_resumenGruposRangos_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void groupHeader1_Format(object sender, EventArgs e)
    {
        /*
        if (textBox79.Text == "Número de contratos")
        {
            textBox34.OutputFormat = "";
            textBox25.OutputFormat = "";
            textBox15.OutputFormat = "";
            textBox26.OutputFormat = "";
            textBox17.OutputFormat = "";
            textBox22.OutputFormat = "";
            textBox27.OutputFormat = "";
            textBox28.OutputFormat = "";

            textBox58.OutputFormat = "";
            textBox59.OutputFormat = "";
            textBox60.OutputFormat = "";
            textBox61.OutputFormat = "";
            textBox62.OutputFormat = "";
            textBox63.OutputFormat = "";
            textBox64.OutputFormat = "";
            textBox65.OutputFormat = "";
        }
        else
        {
            textBox34.OutputFormat = "#,##0.00";
            textBox25.OutputFormat = "#,##0.00";
            textBox15.OutputFormat = "#,##0.00";
            textBox26.OutputFormat = "#,##0.00";
            textBox17.OutputFormat = "#,##0.00";
            textBox22.OutputFormat = "#,##0.00";
            textBox27.OutputFormat = "#,##0.00";
            textBox28.OutputFormat = "#,##0.00";

            textBox58.OutputFormat = "#,##0.00";
            textBox59.OutputFormat = "#,##0.00";
            textBox60.OutputFormat = "#,##0.00";
            textBox61.OutputFormat = "#,##0.00";
            textBox62.OutputFormat = "#,##0.00";
            textBox63.OutputFormat = "#,##0.00";
            textBox64.OutputFormat = "#,##0.00";
            textBox65.OutputFormat = "#,##0.00";
        }
        */
    }

    private void detail_Format(object sender, EventArgs e)
    {

    }


}
