using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_cobranza_contratos_asignados.
/// </summary>
public class rpt_cobranza_contratos_asignados : DataDynamics.ActiveReports.ActiveReport3
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
    private TextBox textBox13;
    private TextBox textBox14;
    private TextBox textBox17;
    private TextBox textBox15;
    private TextBox textBox16;
    private TextBox textBox29;
    private TextBox textBox28;
    private TextBox textBox27;
    private TextBox textBox26;
    private TextBox textBox25;
    private TextBox textBox24;
    private TextBox textBox23;
    private TextBox textBox22;
    private TextBox textBox21;
    private TextBox textBox20;
    private TextBox textBox19;
    private TextBox textBox18;
    private TextBox textBox36;
    private Picture picture1;
    private TextBox textBox30;
    private TextBox textBox31;
    private Line line1;
    private TextBox textBox33;
    private TextBox textBox32;
    private TextBox textBox34;
    private TextBox textBox35;
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
    private Line line2;
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
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_cobranza_contratos_asignados()
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
    public void Encabezado(DateTime Fecha, string Fecha_cuota_inicial, string Cobrador, string Mora)
    {
        textBox36.Text = "Fecha de emisi?n: " + DateTime.Now.ToString("F");

        textBox5.Text = Fecha.ToString("d");
        textBox4.Text = Fecha_cuota_inicial;
        textBox35.Text = Cobrador;
        textBox38.Text = Mora;
    }
    private void rpt_cobranza_contratos_asignados_ReportStart(object sender, EventArgs e)
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
        textBox36.ClassName = "estiloFecha";

        textBox1.ClassName = "estiloTitulo";

        textBox2.ClassName = "estiloEncabEnun";
        textBox3.ClassName = "estiloEncabEnun";
        textBox34.ClassName = "estiloEncabEnun";
        textBox37.ClassName = "estiloEncabEnun";

        textBox4.ClassName = "estiloEncabDato";
        textBox5.ClassName = "estiloEncabDato";
        textBox35.ClassName = "estiloEncabDato";
        textBox38.ClassName = "estiloEncabDato";

        textBox6.ClassName = "estiloTotalEnun";
        textBox7.ClassName = "estiloDetalleEnun";
        textBox32.ClassName = "estiloDetalleEnun";
        textBox8.ClassName = "estiloDetalleEnun";
        textBox50.ClassName = "estiloDetalleEnun";
        textBox51.ClassName = "estiloDetalleEnun";
        textBox58.ClassName = "estiloDetalleEnun";
        textBox54.ClassName = "estiloDetalleEnun";
        textBox9.ClassName = "estiloDetalleEnun";
        textBox10.ClassName = "estiloDetalleEnun";
        textBox11.ClassName = "estiloDetalleEnun";
        textBox48.ClassName = "estiloDetalleEnun";
        textBox12.ClassName = "estiloDetalleEnun";
        textBox13.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox15.ClassName = "estiloDetalleEnun";
        textBox16.ClassName = "estiloDetalleEnun";
        textBox40.ClassName = "estiloDetalleEnun";
        textBox41.ClassName = "estiloDetalleEnun";
        textBox17.ClassName = "estiloDetalleEnun";
        textBox18.ClassName = "estiloTotalEnun";

        textBox19.ClassName = "estiloDetalleDato";
        textBox23.ClassName = "estiloDetalleDatoString";
        textBox49.ClassName = "estiloDetalleDatoString";
        textBox21.ClassName = "estiloDetalleDatoString";
        textBox22.ClassName = "estiloDetalleDatoString";
        textBox33.ClassName = "estiloDetalleDato";

        textBox20.ClassName = "estiloDetalleDato";
        textBox52.ClassName = "estiloDetalleDato";
        textBox53.ClassName = "estiloDetalleDato";
        textBox59.ClassName = "estiloDetalleDato";
        textBox55.ClassName = "estiloDetalleDato";
        textBox24.ClassName = "estiloDetalleDatoString";
        textBox25.ClassName = "estiloDetalleDato";
        textBox26.ClassName = "estiloDetalleDato";
        textBox27.ClassName = "estiloDetalleDatoString";
        textBox28.ClassName = "estiloDetalleDatoString";
        textBox29.ClassName = "estiloDetalleDato";
        textBox42.ClassName = "estiloDetalleDato";
        textBox43.ClassName = "estiloDetalleDato";

        textBox30.ClassName = "estiloTotalEnun";
        textBox39.ClassName = "estiloTotalEnun";
        textBox44.ClassName = "estiloTotal";
        textBox31.ClassName = "estiloTotal";

        textBox45.ClassName = "estiloTotalEnun";
        textBox46.ClassName = "estiloTotal";
        textBox60.ClassName = "estiloTotal";
        textBox47.ClassName = "estiloTotal";
        textBox57.ClassName = "estiloTotal";
    }    
	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_cobranza_contratos_asignados));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.textBox48 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        this.textBox47 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox17,
            this.textBox15,
            this.textBox16,
            this.textBox32,
            this.textBox40,
            this.textBox41,
            this.textBox48,
            this.textBox50,
            this.textBox51,
            this.textBox54,
            this.textBox58});
        this.pageHeader.Height = 0.375F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox7.Height = 0.3125F;
        this.textBox7.Left = 0F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = "No. contrato";
        this.textBox7.Top = 0F;
        this.textBox7.Width = 0.6875F;
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
        this.textBox8.Left = 6.0625F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Cuota inicial $us";
        this.textBox8.Top = 0F;
        this.textBox8.Width = 0.9375F;
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
        this.textBox9.Left = 3.1875F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "Sector";
        this.textBox9.Top = 0F;
        this.textBox9.Width = 1.375F;
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
        this.textBox10.Left = 4.5625F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Lote";
        this.textBox10.Top = 0F;
        this.textBox10.Width = 0.5625F;
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
        this.textBox11.Left = 0.6875F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Lugar de Cobro";
        this.textBox11.Top = 0F;
        this.textBox11.Width = 1.5F;
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
        this.textBox12.Left = 8.875F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Fecha Cuo.Inicial";
        this.textBox12.Top = 0F;
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
        this.textBox13.Left = 9.625F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "Cuota mes $us";
        this.textBox13.Top = 0F;
        this.textBox13.Width = 0.6875F;
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
        this.textBox14.Left = 11.625F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Fecha Ult.Pago";
        this.textBox14.Top = 0F;
        this.textBox14.Width = 0.8125F;
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
        this.textBox17.Left = 11F;
        this.textBox17.Name = "textBox17";
        this.textBox17.Style = "";
        this.textBox17.Text = "Inter?s anual";
        this.textBox17.Top = 0F;
        this.textBox17.Width = 0.625F;
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
        this.textBox15.Left = 12.4375F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = "Fecha Inter?s";
        this.textBox15.Top = 0F;
        this.textBox15.Width = 0.8125F;
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
        this.textBox16.Left = 13.25F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "Saldo $us";
        this.textBox16.Top = 0F;
        this.textBox16.Width = 0.9375F;
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
        this.textBox32.Left = 5.125F;
        this.textBox32.Name = "textBox32";
        this.textBox32.Style = "";
        this.textBox32.Text = "Precio Final $us";
        this.textBox32.Top = 0F;
        this.textBox32.Width = 0.9375F;
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
        this.textBox40.Left = 15.125F;
        this.textBox40.Name = "textBox40";
        this.textBox40.Style = "";
        this.textBox40.Text = "N? d?as retraso";
        this.textBox40.Top = 0F;
        this.textBox40.Width = 0.625F;
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
        this.textBox41.Left = 15.75F;
        this.textBox41.Name = "textBox41";
        this.textBox41.Style = "";
        this.textBox41.Text = "N? d?as mora";
        this.textBox41.Top = 0F;
        this.textBox41.Width = 0.625F;
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
        this.textBox48.Left = 2.1875F;
        this.textBox48.Name = "textBox48";
        this.textBox48.Style = "";
        this.textBox48.Text = "Negocio";
        this.textBox48.Top = 0F;
        this.textBox48.Width = 1F;
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
        this.textBox2.Left = 5.4375F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Fecha de venta:";
        this.textBox2.Top = 0.75F;
        this.textBox2.Width = 1.8125F;
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
        this.textBox3.Left = 5.4375F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "A la fecha:";
        this.textBox3.Top = 0.5625F;
        this.textBox3.Width = 1.8125F;
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
        this.textBox4.Left = 7.25F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = null;
        this.textBox4.Top = 0.75F;
        this.textBox4.Width = 3.8125F;
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
        this.textBox5.Left = 7.25F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = null;
        this.textBox5.Top = 0.5625F;
        this.textBox5.Width = 3.8125F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox29,
            this.textBox28,
            this.textBox27,
            this.textBox26,
            this.textBox25,
            this.textBox24,
            this.textBox23,
            this.textBox22,
            this.textBox21,
            this.textBox20,
            this.textBox19,
            this.textBox33,
            this.textBox42,
            this.textBox43,
            this.textBox49,
            this.textBox52,
            this.textBox53,
            this.textBox55,
            this.textBox59});
        this.detail.Height = 0.2083333F;
        this.detail.Name = "detail";
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
        this.textBox29.DataField = "saldo_sus";
        this.textBox29.Height = 0.1875F;
        this.textBox29.Left = 13.25F;
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
        this.textBox29.Style = "";
        this.textBox29.Text = null;
        this.textBox29.Top = 0F;
        this.textBox29.Width = 0.9375F;
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
        this.textBox28.DataField = "fecha_interes";
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 12.4375F;
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
        this.textBox28.Style = "";
        this.textBox28.Text = null;
        this.textBox28.Top = 0F;
        this.textBox28.Width = 0.8125F;
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
        this.textBox27.DataField = "fecha_ultimo";
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 11.625F;
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
        this.textBox27.Style = "";
        this.textBox27.Text = null;
        this.textBox27.Top = 0F;
        this.textBox27.Width = 0.8125F;
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
        this.textBox26.DataField = "interes_corriente";
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 11F;
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
        this.textBox26.Style = "";
        this.textBox26.Text = null;
        this.textBox26.Top = 0F;
        this.textBox26.Width = 0.625F;
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
        this.textBox25.DataField = "cuota_base_sus";
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 9.625F;
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
        this.textBox25.Style = "";
        this.textBox25.Text = null;
        this.textBox25.Top = 0F;
        this.textBox25.Width = 0.6875F;
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
        this.textBox24.DataField = "fecha_inicial";
        this.textBox24.Height = 0.1875F;
        this.textBox24.Left = 8.875F;
        this.textBox24.Name = "textBox24";
        this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
        this.textBox24.Style = "";
        this.textBox24.Text = null;
        this.textBox24.Top = 0F;
        this.textBox24.Width = 0.75F;
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
        this.textBox23.DataField = "lugar_cobro";
        this.textBox23.Height = 0.1875F;
        this.textBox23.Left = 0.6875F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = null;
        this.textBox23.Top = 0F;
        this.textBox23.Width = 1.5F;
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
        this.textBox22.DataField = "lote";
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 4.5625F;
        this.textBox22.Name = "textBox22";
        this.textBox22.Style = "";
        this.textBox22.Text = null;
        this.textBox22.Top = 0F;
        this.textBox22.Width = 0.5625F;
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
        this.textBox21.DataField = "sector";
        this.textBox21.Height = 0.1875F;
        this.textBox21.Left = 3.1875F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = null;
        this.textBox21.Top = 0F;
        this.textBox21.Width = 1.375F;
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
        this.textBox20.DataField = "cuota_inicial_sus";
        this.textBox20.Height = 0.1875F;
        this.textBox20.Left = 6.0625F;
        this.textBox20.Name = "textBox20";
        this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
        this.textBox20.Style = "";
        this.textBox20.Text = null;
        this.textBox20.Top = 0F;
        this.textBox20.Width = 0.9375F;
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
        this.textBox19.DataField = "num_contrato";
        this.textBox19.Height = 0.1875F;
        this.textBox19.Left = 0.0625F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = null;
        this.textBox19.Top = 0F;
        this.textBox19.Width = 0.625F;
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
        this.textBox33.DataField = "precio_final_sus";
        this.textBox33.Height = 0.1875F;
        this.textBox33.Left = 5.125F;
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
        this.textBox33.Style = "";
        this.textBox33.Text = "textBox33";
        this.textBox33.Top = 0F;
        this.textBox33.Width = 0.9375F;
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
        this.textBox42.DataField = "num_dias_retraso";
        this.textBox42.Height = 0.1875F;
        this.textBox42.Left = 15.125F;
        this.textBox42.Name = "textBox42";
        this.textBox42.Style = "";
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 0F;
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
        this.textBox43.DataField = "num_dias_mora";
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 15.75F;
        this.textBox43.Name = "textBox43";
        this.textBox43.Style = "";
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0F;
        this.textBox43.Width = 0.625F;
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
        this.textBox49.DataField = "negocio";
        this.textBox49.Height = 0.1875F;
        this.textBox49.Left = 2.1875F;
        this.textBox49.Name = "textBox49";
        this.textBox49.Style = "";
        this.textBox49.Text = null;
        this.textBox49.Top = 0F;
        this.textBox49.Width = 1F;
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
        this.textBox18.DataField = "cobrador";
        this.textBox18.Height = 0.1875F;
        this.textBox18.Left = 0.8125F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = null;
        this.textBox18.Top = 0F;
        this.textBox18.Width = 3.25F;
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
            this.textBox36,
            this.picture1,
            this.textBox34,
            this.textBox35,
            this.textBox37,
            this.textBox38});
        this.reportHeader1.Height = 1.385417F;
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
        this.textBox1.Left = 0F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "Reporte de asignaci?n de contratos a cobradores";
        this.textBox1.Top = 0.3125F;
        this.textBox1.Width = 14.0625F;
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
        this.textBox36.Left = 8.1875F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = null;
        this.textBox36.Top = 0.0625F;
        this.textBox36.Width = 5.875F;
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
        this.textBox34.Left = 5.4375F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "Cobrador:";
        this.textBox34.Top = 0.9375F;
        this.textBox34.Width = 1.8125F;
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
        this.textBox35.Height = 0.1875F;
        this.textBox35.Left = 7.25F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "textBox35";
        this.textBox35.Top = 0.9375F;
        this.textBox35.Width = 3.8125F;
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
        this.textBox37.Left = 5.4375F;
        this.textBox37.Name = "textBox37";
        this.textBox37.Style = "";
        this.textBox37.Text = "Contratos:";
        this.textBox37.Top = 1.125F;
        this.textBox37.Width = 1.8125F;
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
        this.textBox38.Height = 0.1875F;
        this.textBox38.Left = 7.25F;
        this.textBox38.Name = "textBox38";
        this.textBox38.Style = "";
        this.textBox38.Text = "textBox38";
        this.textBox38.Top = 1.125F;
        this.textBox38.Width = 3.8125F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.line2,
            this.textBox57,
            this.textBox60});
        this.reportFooter1.Height = 0.5625F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.textBox45.Left = 0F;
        this.textBox45.Name = "textBox45";
        this.textBox45.Style = "";
        this.textBox45.Text = "Total:";
        this.textBox45.Top = 0.125F;
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
        this.textBox46.DataField = "precio_final_sus";
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 5.125F;
        this.textBox46.Name = "textBox46";
        this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
        this.textBox46.Style = "";
        this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0.125F;
        this.textBox46.Width = 0.9375F;
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
        this.textBox47.DataField = "saldo_sus";
        this.textBox47.Height = 0.1875F;
        this.textBox47.Left = 13.3125F;
        this.textBox47.Name = "textBox47";
        this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
        this.textBox47.Style = "";
        this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0.125F;
        this.textBox47.Width = 0.9375F;
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
        this.line2.Top = 0.0625F;
        this.line2.Width = 16.125F;
        this.line2.X1 = 0F;
        this.line2.X2 = 16.125F;
        this.line2.Y1 = 0.0625F;
        this.line2.Y2 = 0.0625F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox6,
            this.textBox18});
        this.groupHeader1.DataField = "cobrador";
        this.groupHeader1.Height = 0.28125F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox6.Left = 0F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "Cobrador:";
        this.textBox6.Top = 0F;
        this.textBox6.Width = 0.75F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox30,
            this.textBox31,
            this.line1,
            this.textBox39,
            this.textBox44,
            this.textBox56});
        this.groupFooter1.Height = 0.34375F;
        this.groupFooter1.Name = "groupFooter1";
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
        this.textBox30.Left = 0F;
        this.textBox30.Name = "textBox30";
        this.textBox30.Style = "";
        this.textBox30.Text = "SubTotal::";
        this.textBox30.Top = 0.125F;
        this.textBox30.Width = 0.75F;
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
        this.textBox31.DataField = "saldo_sus";
        this.textBox31.Height = 0.1875F;
        this.textBox31.Left = 13.25F;
        this.textBox31.Name = "textBox31";
        this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
        this.textBox31.Style = "";
        this.textBox31.SummaryGroup = "groupHeader1";
        this.textBox31.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox31.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox31.Text = null;
        this.textBox31.Top = 0.125F;
        this.textBox31.Width = 0.9375F;
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
        this.line1.Top = 0.0625F;
        this.line1.Width = 16.375F;
        this.line1.X1 = 0F;
        this.line1.X2 = 16.375F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
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
        this.textBox39.DataField = "cobrador";
        this.textBox39.Height = 0.1875F;
        this.textBox39.Left = 0.8125F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "textBox39";
        this.textBox39.Top = 0.125F;
        this.textBox39.Width = 3.25F;
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
        this.textBox44.DataField = "precio_final_sus";
        this.textBox44.Height = 0.1875F;
        this.textBox44.Left = 5.125F;
        this.textBox44.Name = "textBox44";
        this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
        this.textBox44.Style = "";
        this.textBox44.SummaryGroup = "groupHeader1";
        this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 0.125F;
        this.textBox44.Width = 0.9375F;
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
        this.textBox50.Left = 7F;
        this.textBox50.Name = "textBox50";
        this.textBox50.Style = "";
        this.textBox50.Text = "Precio Final Bs";
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
        this.textBox51.Height = 0.3125F;
        this.textBox51.Left = 7.9375F;
        this.textBox51.Name = "textBox51";
        this.textBox51.Style = "";
        this.textBox51.Text = "Cuota inicial Bs";
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
        this.textBox52.DataField = "precio_final_bs";
        this.textBox52.Height = 0.1875F;
        this.textBox52.Left = 7F;
        this.textBox52.Name = "textBox52";
        this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
        this.textBox52.Style = "";
        this.textBox52.Text = null;
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
        this.textBox53.DataField = "cuota_inicial_bs";
        this.textBox53.Height = 0.1875F;
        this.textBox53.Left = 7.9375F;
        this.textBox53.Name = "textBox53";
        this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
        this.textBox53.Style = "";
        this.textBox53.Text = null;
        this.textBox53.Top = 0F;
        this.textBox53.Width = 0.9375F;
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
        this.textBox54.Left = 14.1875F;
        this.textBox54.Name = "textBox54";
        this.textBox54.Style = "";
        this.textBox54.Text = "Saldo Bs";
        this.textBox54.Top = 0F;
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
        this.textBox55.DataField = "saldo_bs";
        this.textBox55.Height = 0.1875F;
        this.textBox55.Left = 14.1875F;
        this.textBox55.Name = "textBox55";
        this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
        this.textBox55.Style = "";
        this.textBox55.Text = null;
        this.textBox55.Top = 0F;
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
        this.textBox56.DataField = "saldo_bs";
        this.textBox56.Height = 0.1875F;
        this.textBox56.Left = 14.1875F;
        this.textBox56.Name = "textBox56";
        this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
        this.textBox56.Style = "";
        this.textBox56.SummaryGroup = "groupHeader1";
        this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox56.Text = null;
        this.textBox56.Top = 0.125F;
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
        this.textBox57.DataField = "saldo_bs";
        this.textBox57.Height = 0.1875F;
        this.textBox57.Left = 14.25F;
        this.textBox57.Name = "textBox57";
        this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
        this.textBox57.Style = "";
        this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox57.Text = "textBox47";
        this.textBox57.Top = 0.125F;
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
        this.textBox58.Height = 0.3125F;
        this.textBox58.Left = 10.3125F;
        this.textBox58.Name = "textBox58";
        this.textBox58.Style = "";
        this.textBox58.Text = "Cuota mes Bs";
        this.textBox58.Top = 0F;
        this.textBox58.Width = 0.6875F;
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
        this.textBox59.DataField = "cuota_base_bs";
        this.textBox59.Height = 0.1875F;
        this.textBox59.Left = 10.3125F;
        this.textBox59.Name = "textBox59";
        this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
        this.textBox59.Style = "";
        this.textBox59.Text = null;
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
        this.textBox60.DataField = "precio_final_bs";
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 7F;
        this.textBox60.Name = "textBox60";
        this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
        this.textBox60.Style = "";
        this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox60.Text = "textBox46";
        this.textBox60.Top = 0.125F;
        this.textBox60.Width = 0.9375F;
        // 
        // rpt_cobranza_contratos_asignados
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 16.48958F;
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
        this.ReportStart += new System.EventHandler(this.rpt_cobranza_contratos_asignados_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    
}
