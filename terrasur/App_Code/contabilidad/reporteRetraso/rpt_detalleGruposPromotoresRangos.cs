using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for rpt_detalleGruposPromotoresRangos.
/// </summary>
public class rpt_detalleGruposPromotoresRangos : DataDynamics.ActiveReports.ActiveReport3
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
    private TextBox textBox8;
    private TextBox textBox9;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox textBox17;
    private TextBox textBox26;
    private TextBox textBox22;
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
    private TextBox textBox31;
    private GroupHeader groupHeader1;
    private TextBox textBox34;
    private TextBox textBox35;
    private GroupFooter groupFooter1;
    private GroupHeader groupHeader2;
    private GroupFooter groupFooter2;
    private TextBox textBox38;
    private TextBox textBox39;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox23;
    private TextBox textBox27;
    private TextBox textBox28;
    private Line line2;
    private Line line3;
    private TextBox textBox36;
    private TextBox textBox37;
    private TextBox textBox40;
    private TextBox textBox41;
    private TextBox textBox42;
    private TextBox textBox43;
    private TextBox textBox44;
    private TextBox textBox45;
    private TextBox textBox46;
    private TextBox textBox47;
    private GroupHeader groupHeader3;
    private GroupFooter groupFooter3;
    private TextBox textBox48;
    private TextBox textBox49;
    private ReportInfo reportInfo1;
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
    private Line line4;
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
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_detalleGruposPromotoresRangos()
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

    public void CargarEncabezado(string Usuario, DateTime Fecha, string Negocios, string Moneda, string Consolidado, string Codigo_moneda, bool con_contratos_al_dia, bool con_retraso_1_a_30, bool con_contratos_especiales, string Grupo_original_actual)
    {
        textBox1.Text = "Fecha de emisi?n: " + DateTime.Now.ToString("F");
        textBox31.Text = "Usuario: " + Usuario;

        textBox6.Text = Fecha.ToString("d");
        textBox7.Text = Negocios;
        textBox19.Text = Moneda;
        textBox21.Text = Consolidado;
        textBox69.Text = Grupo_original_actual;

        textBox53.Text = "Cuota mes en " + Codigo_moneda;
        textBox54.Text = "Pagos que adeuda " + Codigo_moneda;
        textBox55.Text = "Saldo a Capital en " + Codigo_moneda;

        textBox72.Text = "Total Apor- tado en " + Codigo_moneda;
        textBox73.Text = "Capital Apor- tado en " + Codigo_moneda;


        //con_contratos_al_dia, bool con_contratos_especiales
        string cartera = "";
        if (con_contratos_al_dia == true) { cartera = "Con contratos al d?a"; } else { cartera = "Sin contratos al d?a"; }
        if (con_retraso_1_a_30 == true) { cartera += ", con contratos retrasados de 1 a 30 d?as"; } else { cartera += ", sin contratos retrasados de 1 a 30 d?as"; }
        if (con_contratos_especiales == true) { cartera += ", con contratos especiales"; } else { cartera += ", sin contratos especiales"; }
        textBox49.Text = cartera;
    }


    private void rpt_detalleGruposPromotoresRangos_ReportStart(object sender, EventArgs e)
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
        textBox48.ClassName = "estiloEncabEnun";
        textBox49.ClassName = "estiloEncabDato";
        textBox68.ClassName = "estiloEncabEnun";
        textBox69.ClassName = "estiloEncabDato";

        textBox34.ClassName = "estiloGrupoEnun";
        textBox35.ClassName = "estiloGrupoEnun";
        textBox38.ClassName = "estiloGrupoEnun";
        textBox39.ClassName = "estiloGrupoEnun";
        textBox50.ClassName = "estiloGrupoEnun";
        textBox51.ClassName = "estiloGrupoEnun";

        textBox13.ClassName = "estiloSubtotalEnun";
        textBox23.ClassName = "estiloSubtotalEnun";
        textBox27.ClassName = "estiloSubtotalEnun";
        textBox28.ClassName = "estiloSubtotalEnun";


        textBox5.ClassName = "estiloDetalleEnun";
        textBox10.ClassName = "estiloDetalleEnun";
        textBox14.ClassName = "estiloDetalleEnun";
        textBox11.ClassName = "estiloDetalleEnun";
        textBox8.ClassName = "estiloDetalleEnun";
        textBox70.ClassName = "estiloDetalleEnun";
        textBox9.ClassName = "estiloDetalleEnun";
        textBox52.ClassName = "estiloDetalleEnun";
        textBox53.ClassName = "estiloDetalleEnun";
        textBox54.ClassName = "estiloDetalleEnun";
        textBox55.ClassName = "estiloDetalleEnun";
        textBox72.ClassName = "estiloDetalleEnun";
        textBox73.ClassName = "estiloDetalleEnun";
        textBox56.ClassName = "estiloDetalleEnun";
        textBox57.ClassName = "estiloDetalleEnun";
        textBox58.ClassName = "estiloDetalleEnun";
        textBox59.ClassName = "estiloDetalleGrupo";

        textBox24.ClassName = "estiloDetalleDato";
        textBox25.ClassName = "estiloDetalleDatoString";
        textBox15.ClassName = "estiloDetalleDatoString";
        textBox26.ClassName = "estiloDetalleDatoString";
        textBox36.ClassName = "estiloDetalleDatoString";
        textBox71.ClassName = "estiloDetalleDatoString";
        textBox37.ClassName = "estiloDetalleDato";
        textBox40.ClassName = "estiloDetalleDato";
        textBox43.ClassName = "estiloDetalleDato";
        textBox44.ClassName = "estiloDetalleDato";
        textBox45.ClassName = "estiloDetalleDato";
        textBox74.ClassName = "estiloDetalleDato";
        textBox75.ClassName = "estiloDetalleDato";
        textBox12.ClassName = "estiloDetalleDatoString";
        textBox32.ClassName = "estiloDetalleDatoString";
        textBox16.ClassName = "estiloDetalleDatoString";

        textBox17.ClassName = "estiloDetalleDato";
        textBox22.ClassName = "estiloDetalleDato";
        textBox60.ClassName = "estiloDetalleDato";
        textBox61.ClassName = "estiloDetalleDatoString";

        textBox41.ClassName = "estiloDetalleDato";
        textBox42.ClassName = "estiloDetalleDato";
        textBox62.ClassName = "estiloDetalleDato";
        textBox63.ClassName = "estiloDetalleDatoString";

        textBox46.ClassName = "estiloDetalleDato";
        textBox47.ClassName = "estiloDetalleDato";
        textBox64.ClassName = "estiloDetalleDato";
        textBox65.ClassName = "estiloDetalleDatoString";
        
        textBox30.ClassName = "estiloTotalEnun";
        textBox33.ClassName = "estiloTotal";
        textBox29.ClassName = "estiloTotal";
        textBox66.ClassName = "estiloTotal";
        textBox67.ClassName = "estiloDetalleDatoString";
    }


	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_detalleGruposPromotoresRangos));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
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
        this.textBox48 = new DataDynamics.ActiveReports.TextBox();
        this.textBox49 = new DataDynamics.ActiveReports.TextBox();
        this.textBox52 = new DataDynamics.ActiveReports.TextBox();
        this.textBox53 = new DataDynamics.ActiveReports.TextBox();
        this.textBox54 = new DataDynamics.ActiveReports.TextBox();
        this.textBox55 = new DataDynamics.ActiveReports.TextBox();
        this.textBox56 = new DataDynamics.ActiveReports.TextBox();
        this.textBox57 = new DataDynamics.ActiveReports.TextBox();
        this.textBox58 = new DataDynamics.ActiveReports.TextBox();
        this.textBox59 = new DataDynamics.ActiveReports.TextBox();
        this.textBox68 = new DataDynamics.ActiveReports.TextBox();
        this.textBox69 = new DataDynamics.ActiveReports.TextBox();
        this.textBox70 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.textBox37 = new DataDynamics.ActiveReports.TextBox();
        this.textBox40 = new DataDynamics.ActiveReports.TextBox();
        this.textBox43 = new DataDynamics.ActiveReports.TextBox();
        this.textBox44 = new DataDynamics.ActiveReports.TextBox();
        this.textBox45 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox32 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox71 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox33 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox66 = new DataDynamics.ActiveReports.TextBox();
        this.textBox67 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox34 = new DataDynamics.ActiveReports.TextBox();
        this.textBox35 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.textBox46 = new DataDynamics.ActiveReports.TextBox();
        this.textBox47 = new DataDynamics.ActiveReports.TextBox();
        this.textBox64 = new DataDynamics.ActiveReports.TextBox();
        this.textBox65 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox38 = new DataDynamics.ActiveReports.TextBox();
        this.textBox39 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.textBox41 = new DataDynamics.ActiveReports.TextBox();
        this.textBox42 = new DataDynamics.ActiveReports.TextBox();
        this.textBox62 = new DataDynamics.ActiveReports.TextBox();
        this.textBox63 = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader3 = new DataDynamics.ActiveReports.GroupHeader();
        this.textBox50 = new DataDynamics.ActiveReports.TextBox();
        this.textBox51 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter3 = new DataDynamics.ActiveReports.GroupFooter();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.textBox60 = new DataDynamics.ActiveReports.TextBox();
        this.textBox61 = new DataDynamics.ActiveReports.TextBox();
        this.textBox72 = new DataDynamics.ActiveReports.TextBox();
        this.textBox73 = new DataDynamics.ActiveReports.TextBox();
        this.textBox74 = new DataDynamics.ActiveReports.TextBox();
        this.textBox75 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox5,
            this.textBox10,
            this.textBox11,
            this.textBox8,
            this.textBox9,
            this.textBox14,
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
            this.textBox48,
            this.textBox49,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
            this.textBox58,
            this.textBox59,
            this.textBox68,
            this.textBox69,
            this.textBox70,
            this.textBox72,
            this.textBox73});
        this.pageHeader.Height = 1.59375F;
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
        this.textBox5.Height = 0.375F;
        this.textBox5.Left = 0F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = "N? contrato";
        this.textBox5.Top = 1.1875F;
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
        this.textBox10.Height = 0.375F;
        this.textBox10.Left = 0.75F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Moneda";
        this.textBox10.Top = 1.1875F;
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
        this.textBox11.Height = 0.375F;
        this.textBox11.Left = 2.75F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "Fecha Ult. Pago";
        this.textBox11.Top = 1.1875F;
        this.textBox11.Width = 0.8125F;
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
        this.textBox8.Height = 0.375F;
        this.textBox8.Left = 3.5625F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Fecha Inter?s";
        this.textBox8.Top = 1.1875F;
        this.textBox8.Width = 0.8125F;
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
        this.textBox9.Height = 0.375F;
        this.textBox9.Left = 5.1875F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = "N? d?as retraso";
        this.textBox9.Top = 1.1875F;
        this.textBox9.Width = 0.5625F;
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
        this.textBox14.Height = 0.375F;
        this.textBox14.Left = 1.3125F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Lote";
        this.textBox14.Top = 1.1875F;
        this.textBox14.Width = 1.4375F;
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
        this.textBox1.Left = 10.6875F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = null;
        this.textBox1.Top = 0F;
        this.textBox1.Width = 5.8125F;
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
        this.textBox2.Left = 2.75F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "Detalle de cartera vigente por promotor";
        this.textBox2.Top = 0.375F;
        this.textBox2.Width = 10.625F;
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
        this.textBox3.Left = 1.3125F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "A la fecha:";
        this.textBox3.Top = 0.5625F;
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
        this.textBox4.Left = 1.3125F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Negocio:";
        this.textBox4.Top = 0.75F;
        this.textBox4.Width = 1.4375F;
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
        this.textBox6.Left = 2.75F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = null;
        this.textBox6.Top = 0.5625F;
        this.textBox6.Width = 4.3125F;
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
        this.textBox7.Left = 2.75F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = null;
        this.textBox7.Top = 0.75F;
        this.textBox7.Width = 4.3125F;
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
        this.picture1.Top = 0.0625F;
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
        this.textBox18.Left = 7.0625F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "MONEDA:";
        this.textBox18.Top = 0.5625F;
        this.textBox18.Width = 1.875F;
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
        this.textBox19.Left = 8.9375F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "";
        this.textBox19.Text = "textBox19";
        this.textBox19.Top = 0.5625F;
        this.textBox19.Width = 4.4375F;
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
        this.textBox20.Left = 7.0625F;
        this.textBox20.Name = "textBox20";
        this.textBox20.Style = "";
        this.textBox20.Text = "DATOS:";
        this.textBox20.Top = 0.75F;
        this.textBox20.Width = 1.875F;
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
        this.textBox21.Left = 8.9375F;
        this.textBox21.Name = "textBox21";
        this.textBox21.Style = "";
        this.textBox21.Text = "textBox21";
        this.textBox21.Top = 0.75F;
        this.textBox21.Width = 4.4375F;
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
        this.textBox31.Left = 10.6875F;
        this.textBox31.Name = "textBox31";
        this.textBox31.Style = "";
        this.textBox31.Text = "textBox31";
        this.textBox31.Top = 0.1875F;
        this.textBox31.Width = 5.8125F;
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
        this.textBox48.Height = 0.1875F;
        this.textBox48.Left = 1.3125F;
        this.textBox48.Name = "textBox48";
        this.textBox48.Style = "";
        this.textBox48.Text = "Cartera:";
        this.textBox48.Top = 0.9375F;
        this.textBox48.Width = 1.4375F;
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
        this.textBox49.Left = 2.75F;
        this.textBox49.Name = "textBox49";
        this.textBox49.Style = "";
        this.textBox49.Text = "textBox49";
        this.textBox49.Top = 0.9375F;
        this.textBox49.Width = 4.3125F;
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
        this.textBox52.Height = 0.375F;
        this.textBox52.Left = 5.75F;
        this.textBox52.Name = "textBox52";
        this.textBox52.Style = "";
        this.textBox52.Text = "N? cuo. adeuda";
        this.textBox52.Top = 1.1875F;
        this.textBox52.Width = 0.5625F;
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
        this.textBox53.Height = 0.375F;
        this.textBox53.Left = 6.3125F;
        this.textBox53.Name = "textBox53";
        this.textBox53.Style = "";
        this.textBox53.Text = "Cuota mes en $us";
        this.textBox53.Top = 1.1875F;
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
        this.textBox54.Height = 0.375F;
        this.textBox54.Left = 7.0625F;
        this.textBox54.Name = "textBox54";
        this.textBox54.Style = "";
        this.textBox54.Text = "Pagos que adeuda $us";
        this.textBox54.Top = 1.1875F;
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
        this.textBox55.Height = 0.375F;
        this.textBox55.Left = 7.9375F;
        this.textBox55.Name = "textBox55";
        this.textBox55.Style = "";
        this.textBox55.Text = "Saldo a Capital en $us";
        this.textBox55.Top = 1.1875F;
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
        this.textBox56.Height = 0.1875F;
        this.textBox56.Left = 10.6875F;
        this.textBox56.Name = "textBox56";
        this.textBox56.Style = "";
        this.textBox56.Text = "Nombre";
        this.textBox56.Top = 1.375F;
        this.textBox56.Width = 1.5625F;
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
        this.textBox57.Height = 0.1875F;
        this.textBox57.Left = 12.25F;
        this.textBox57.Name = "textBox57";
        this.textBox57.Style = "";
        this.textBox57.Text = "Tel?fonos";
        this.textBox57.Top = 1.375F;
        this.textBox57.Width = 1.125F;
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
        this.textBox58.Height = 0.1875F;
        this.textBox58.Left = 13.375F;
        this.textBox58.Name = "textBox58";
        this.textBox58.Style = "";
        this.textBox58.Text = "Direcci?n";
        this.textBox58.Top = 1.375F;
        this.textBox58.Width = 3.125F;
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
        this.textBox59.Left = 10.6875F;
        this.textBox59.Name = "textBox59";
        this.textBox59.Style = "";
        this.textBox59.Text = "Datos de clientes";
        this.textBox59.Top = 1.1875F;
        this.textBox59.Width = 5.8125F;
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
        this.textBox68.Left = 7.0625F;
        this.textBox68.Name = "textBox68";
        this.textBox68.Style = "";
        this.textBox68.Text = "Contratos asocidos al:";
        this.textBox68.Top = 0.9375F;
        this.textBox68.Width = 1.875F;
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
        this.textBox69.Height = 0.1875F;
        this.textBox69.Left = 8.9375F;
        this.textBox69.Name = "textBox69";
        this.textBox69.Style = "";
        this.textBox69.Text = "textBox69";
        this.textBox69.Top = 0.9375F;
        this.textBox69.Width = 4.4375F;
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
        this.textBox70.Height = 0.375F;
        this.textBox70.Left = 4.375F;
        this.textBox70.Name = "textBox70";
        this.textBox70.Style = "";
        this.textBox70.Text = "F. de Prox. Pago";
        this.textBox70.Top = 1.1875F;
        this.textBox70.Width = 0.8125F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox24,
            this.textBox25,
            this.textBox15,
            this.textBox26,
            this.textBox36,
            this.textBox37,
            this.textBox40,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox16,
            this.textBox32,
            this.textBox12,
            this.textBox71,
            this.textBox74,
            this.textBox75});
        this.detail.Height = 0.1979167F;
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
        this.textBox24.DataField = "numero_contrato";
        this.textBox24.Height = 0.1875F;
        this.textBox24.Left = 0F;
        this.textBox24.Name = "textBox24";
        this.textBox24.Style = "";
        this.textBox24.Text = "textBox24";
        this.textBox24.Top = 0F;
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
        this.textBox25.DataField = "codigo_moneda";
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 0.75F;
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
        this.textBox25.Style = "";
        this.textBox25.Text = "textBox25";
        this.textBox25.Top = 0F;
        this.textBox25.Width = 0.5625F;
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
        this.textBox15.DataField = "lote";
        this.textBox15.Height = 0.1875F;
        this.textBox15.Left = 1.3125F;
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
        this.textBox15.Style = "";
        this.textBox15.Text = "textBox15";
        this.textBox15.Top = 0F;
        this.textBox15.Width = 1.4375F;
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
        this.textBox26.DataField = "fecha_ultimo_pago";
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 2.75F;
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
        this.textBox26.Style = "";
        this.textBox26.Text = "textBox26";
        this.textBox26.Top = 0F;
        this.textBox26.Width = 0.8125F;
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
        this.textBox36.DataField = "interes_fecha";
        this.textBox36.Height = 0.1875F;
        this.textBox36.Left = 3.5625F;
        this.textBox36.Name = "textBox36";
        this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
        this.textBox36.Style = "";
        this.textBox36.Text = "textBox36";
        this.textBox36.Top = 0F;
        this.textBox36.Width = 0.8125F;
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
        this.textBox37.DataField = "num_dias_retraso";
        this.textBox37.Height = 0.1875F;
        this.textBox37.Left = 5.1875F;
        this.textBox37.Name = "textBox37";
        this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
        this.textBox37.Style = "";
        this.textBox37.Text = "textBox37";
        this.textBox37.Top = 0F;
        this.textBox37.Width = 0.5625F;
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
        this.textBox40.DataField = "num_cuotas_adeuda";
        this.textBox40.Height = 0.1875F;
        this.textBox40.Left = 5.75F;
        this.textBox40.Name = "textBox40";
        this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
        this.textBox40.Style = "";
        this.textBox40.Text = "textBox40";
        this.textBox40.Top = 0F;
        this.textBox40.Width = 0.5625F;
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
        this.textBox43.DataField = "cuota_base";
        this.textBox43.Height = 0.1875F;
        this.textBox43.Left = 6.3125F;
        this.textBox43.Name = "textBox43";
        this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
        this.textBox43.Style = "";
        this.textBox43.Text = "textBox43";
        this.textBox43.Top = 0F;
        this.textBox43.Width = 0.75F;
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
        this.textBox44.DataField = "monto_adeuda";
        this.textBox44.Height = 0.1875F;
        this.textBox44.Left = 7.0625F;
        this.textBox44.Name = "textBox44";
        this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
        this.textBox44.Style = "";
        this.textBox44.Text = "textBox44";
        this.textBox44.Top = 0F;
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
        this.textBox45.DataField = "saldo";
        this.textBox45.Height = 0.1979167F;
        this.textBox45.Left = 7.9375F;
        this.textBox45.Name = "textBox45";
        this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
        this.textBox45.Style = "";
        this.textBox45.Text = "textBox45";
        this.textBox45.Top = 0F;
        this.textBox45.Width = 1F;
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
        this.textBox16.DataField = "cliente_direccion";
        this.textBox16.Height = 0.1875F;
        this.textBox16.Left = 13.375F;
        this.textBox16.Name = "textBox16";
        this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
        this.textBox16.Style = "";
        this.textBox16.Text = "textBox16";
        this.textBox16.Top = 0F;
        this.textBox16.Width = 3.125F;
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
        this.textBox32.DataField = "cliente_telefono";
        this.textBox32.Height = 0.1875F;
        this.textBox32.Left = 12.25F;
        this.textBox32.Name = "textBox32";
        this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
        this.textBox32.Style = "";
        this.textBox32.Text = "textBox32";
        this.textBox32.Top = 0F;
        this.textBox32.Width = 1.125F;
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
        this.textBox12.DataField = "cliente_nombre";
        this.textBox12.Height = 0.1875F;
        this.textBox12.Left = 10.6875F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "textBox12";
        this.textBox12.Top = 0F;
        this.textBox12.Width = 1.5625F;
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
        this.textBox71.DataField = "fecha_proximo";
        this.textBox71.Height = 0.1875F;
        this.textBox71.Left = 4.375F;
        this.textBox71.Name = "textBox71";
        this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
        this.textBox71.Style = "";
        this.textBox71.Text = "textBox71";
        this.textBox71.Top = 0F;
        this.textBox71.Width = 0.8125F;
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
        this.textBox17.DataField = "monto_adeuda";
        this.textBox17.Height = 0.1875F;
        this.textBox17.Left = 7.0625F;
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
        this.textBox17.Style = "";
        this.textBox17.SummaryGroup = "groupHeader3";
        this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox17.Text = "textBox17";
        this.textBox17.Top = 0.0625F;
        this.textBox17.Width = 0.875F;
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
        this.textBox22.DataField = "saldo";
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 7.9375F;
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
        this.textBox22.Style = "";
        this.textBox22.SummaryGroup = "groupHeader3";
        this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox22.Text = "textBox22";
        this.textBox22.Top = 0.0625F;
        this.textBox22.Width = 1F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1});
        this.pageFooter.Height = 0.21875F;
        this.pageFooter.Name = "pageFooter";
        // 
        // reportInfo1
        // 
        this.reportInfo1.Border.BottomColor = System.Drawing.Color.Black;
        this.reportInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.reportInfo1.Border.LeftColor = System.Drawing.Color.Black;
        this.reportInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.reportInfo1.Border.RightColor = System.Drawing.Color.Black;
        this.reportInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.reportInfo1.Border.TopColor = System.Drawing.Color.Black;
        this.reportInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.reportInfo1.FormatString = "P?gina {PageNumber} de {PageCount}";
        this.reportInfo1.Height = 0.1875F;
        this.reportInfo1.Left = 13.375F;
        this.reportInfo1.Name = "reportInfo1";
        this.reportInfo1.Style = "ddo-char-set: 0; text-align: right; font-style: italic; font-size: 9.75pt; ";
        this.reportInfo1.Top = 0F;
        this.reportInfo1.Width = 3.125F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Height = 0F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox30,
            this.textBox33,
            this.textBox29,
            this.line1,
            this.textBox66,
            this.textBox67});
        this.reportFooter1.Height = 0.2708333F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.textBox30.Text = "Total:";
        this.textBox30.Top = 0.0625F;
        this.textBox30.Width = 0.6875F;
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
        this.textBox33.DataField = "monto_adeuda";
        this.textBox33.Height = 0.1875F;
        this.textBox33.Left = 7.0625F;
        this.textBox33.Name = "textBox33";
        this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
        this.textBox33.Style = "";
        this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox33.Text = "textBox33";
        this.textBox33.Top = 0.0625F;
        this.textBox33.Width = 0.875F;
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
        this.textBox29.DataField = "saldo";
        this.textBox29.Height = 0.1875F;
        this.textBox29.Left = 7.9375F;
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
        this.textBox29.Style = "";
        this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox29.Text = "textBox29";
        this.textBox29.Top = 0.0625F;
        this.textBox29.Width = 1F;
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
        this.line1.Width = 16.5F;
        this.line1.X1 = 0F;
        this.line1.X2 = 16.5F;
        this.line1.Y1 = 0F;
        this.line1.Y2 = 0F;
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
        this.textBox66.DataField = "saldo";
        this.textBox66.Height = 0.1875F;
        this.textBox66.Left = 10.6875F;
        this.textBox66.Name = "textBox66";
        this.textBox66.Style = "";
        this.textBox66.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox66.Text = "textBox66";
        this.textBox66.Top = 0.0625F;
        this.textBox66.Width = 1.5625F;
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
        this.textBox67.Left = 12.25F;
        this.textBox67.Name = "textBox67";
        this.textBox67.Style = "";
        this.textBox67.Text = "contrato(s)";
        this.textBox67.Top = 0.0625F;
        this.textBox67.Width = 1.125F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.DataField = "grupo";
        this.groupHeader1.Height = 0.01041667F;
        this.groupHeader1.Name = "groupHeader1";
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
        this.textBox34.Left = 0F;
        this.textBox34.Name = "textBox34";
        this.textBox34.Style = "";
        this.textBox34.Text = "Grupo:";
        this.textBox34.Top = 0F;
        this.textBox34.Width = 0.6875F;
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
        this.textBox35.DataField = "grupo";
        this.textBox35.Height = 0.1875F;
        this.textBox35.Left = 0.75F;
        this.textBox35.Name = "textBox35";
        this.textBox35.Style = "";
        this.textBox35.Text = "textBox35";
        this.textBox35.Top = 0F;
        this.textBox35.Width = 5F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox23,
            this.textBox13,
            this.line2,
            this.textBox46,
            this.textBox47,
            this.textBox64,
            this.textBox65});
        this.groupFooter1.Height = 0.2708333F;
        this.groupFooter1.Name = "groupFooter1";
        this.groupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After;
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
        this.textBox23.DataField = "grupo";
        this.textBox23.Height = 0.1875F;
        this.textBox23.Left = 0.75F;
        this.textBox23.Name = "textBox23";
        this.textBox23.Style = "";
        this.textBox23.Text = "textBox23";
        this.textBox23.Top = 0.0625F;
        this.textBox23.Width = 5F;
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
        this.textBox13.Left = 0F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "SubTotal:";
        this.textBox13.Top = 0.0625F;
        this.textBox13.Width = 0.6875F;
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
        this.line2.Top = 0F;
        this.line2.Width = 16.5F;
        this.line2.X1 = 0F;
        this.line2.X2 = 16.5F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0F;
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
        this.textBox46.DataField = "monto_adeuda";
        this.textBox46.Height = 0.1875F;
        this.textBox46.Left = 7.0625F;
        this.textBox46.Name = "textBox46";
        this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
        this.textBox46.Style = "";
        this.textBox46.SummaryGroup = "groupHeader1";
        this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox46.Text = "textBox46";
        this.textBox46.Top = 0.0625F;
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
        this.textBox47.DataField = "saldo";
        this.textBox47.Height = 0.1979167F;
        this.textBox47.Left = 7.9375F;
        this.textBox47.Name = "textBox47";
        this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
        this.textBox47.Style = "";
        this.textBox47.SummaryGroup = "groupHeader1";
        this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox47.Text = "textBox47";
        this.textBox47.Top = 0.0625F;
        this.textBox47.Width = 1F;
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
        this.textBox64.DataField = "saldo";
        this.textBox64.Height = 0.1875F;
        this.textBox64.Left = 10.6875F;
        this.textBox64.Name = "textBox64";
        this.textBox64.Style = "";
        this.textBox64.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox64.SummaryGroup = "groupHeader1";
        this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox64.Text = "textBox64";
        this.textBox64.Top = 0.0625F;
        this.textBox64.Width = 1.5625F;
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
        this.textBox65.Left = 12.25F;
        this.textBox65.Name = "textBox65";
        this.textBox65.Style = "";
        this.textBox65.Text = "contrato(s)";
        this.textBox65.Top = 0.0625F;
        this.textBox65.Width = 1.125F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox38,
            this.textBox39,
            this.textBox35,
            this.textBox34});
        this.groupHeader2.DataField = "promotor";
        this.groupHeader2.Height = 0.3958333F;
        this.groupHeader2.Name = "groupHeader2";
        this.groupHeader2.Format += new System.EventHandler(this.groupHeader2_Format);
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
        this.textBox38.Left = 0F;
        this.textBox38.Name = "textBox38";
        this.textBox38.Style = "";
        this.textBox38.Text = "Promotor:";
        this.textBox38.Top = 0.1875F;
        this.textBox38.Width = 0.6875F;
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
        this.textBox39.DataField = "promotor";
        this.textBox39.Height = 0.1875F;
        this.textBox39.Left = 0.75F;
        this.textBox39.Name = "textBox39";
        this.textBox39.Style = "";
        this.textBox39.Text = "textBox39";
        this.textBox39.Top = 0.1875F;
        this.textBox39.Width = 5F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox27,
            this.textBox28,
            this.line3,
            this.textBox41,
            this.textBox42,
            this.textBox62,
            this.textBox63});
        this.groupFooter2.Height = 0.375F;
        this.groupFooter2.Name = "groupFooter2";
        this.groupFooter2.NewPage = DataDynamics.ActiveReports.NewPage.After;
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
        this.textBox27.Left = 0F;
        this.textBox27.Name = "textBox27";
        this.textBox27.Style = "";
        this.textBox27.Text = "SubTotal:";
        this.textBox27.Top = 0.125F;
        this.textBox27.Width = 0.6875F;
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
        this.textBox28.DataField = "promotor";
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 0.75F;
        this.textBox28.Name = "textBox28";
        this.textBox28.Style = "";
        this.textBox28.Text = "textBox28";
        this.textBox28.Top = 0.125F;
        this.textBox28.Width = 5F;
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
        this.line3.Left = 0F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0.0625F;
        this.line3.Width = 16.5F;
        this.line3.X1 = 0F;
        this.line3.X2 = 16.5F;
        this.line3.Y1 = 0.0625F;
        this.line3.Y2 = 0.0625F;
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
        this.textBox41.DataField = "monto_adeuda";
        this.textBox41.Height = 0.1875F;
        this.textBox41.Left = 7.0625F;
        this.textBox41.Name = "textBox41";
        this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
        this.textBox41.Style = "";
        this.textBox41.SummaryGroup = "groupHeader2";
        this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox41.Text = "textBox41";
        this.textBox41.Top = 0.125F;
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
        this.textBox42.DataField = "saldo";
        this.textBox42.Height = 0.1979167F;
        this.textBox42.Left = 7.9375F;
        this.textBox42.Name = "textBox42";
        this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
        this.textBox42.Style = "";
        this.textBox42.SummaryGroup = "groupHeader2";
        this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox42.Text = "textBox42";
        this.textBox42.Top = 0.125F;
        this.textBox42.Width = 1F;
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
        this.textBox62.DataField = "saldo";
        this.textBox62.Height = 0.1875F;
        this.textBox62.Left = 10.6875F;
        this.textBox62.Name = "textBox62";
        this.textBox62.Style = "";
        this.textBox62.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox62.SummaryGroup = "groupHeader2";
        this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox62.Text = "textBox62";
        this.textBox62.Top = 0.125F;
        this.textBox62.Width = 1.5625F;
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
        this.textBox63.Left = 12.25F;
        this.textBox63.Name = "textBox63";
        this.textBox63.Style = "";
        this.textBox63.Text = "contrato(s)";
        this.textBox63.Top = 0.125F;
        this.textBox63.Width = 1.125F;
        // 
        // groupHeader3
        // 
        this.groupHeader3.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox50,
            this.textBox51});
        this.groupHeader3.DataField = "rango";
        this.groupHeader3.Height = 0.1979167F;
        this.groupHeader3.Name = "groupHeader3";
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
        this.textBox50.Height = 0.1875F;
        this.textBox50.Left = 0F;
        this.textBox50.Name = "textBox50";
        this.textBox50.Style = "";
        this.textBox50.Text = "Rango:";
        this.textBox50.Top = 0F;
        this.textBox50.Width = 0.6875F;
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
        this.textBox51.DataField = "rango";
        this.textBox51.Height = 0.1875F;
        this.textBox51.Left = 0.75F;
        this.textBox51.Name = "textBox51";
        this.textBox51.Style = "";
        this.textBox51.Text = "textBox51";
        this.textBox51.Top = 0F;
        this.textBox51.Width = 5F;
        // 
        // groupFooter3
        // 
        this.groupFooter3.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox22,
            this.textBox17,
            this.line4,
            this.textBox60,
            this.textBox61});
        this.groupFooter3.Height = 0.3125F;
        this.groupFooter3.Name = "groupFooter3";
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
        this.line4.Left = 0F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 16.5F;
        this.line4.X1 = 0F;
        this.line4.X2 = 16.5F;
        this.line4.Y1 = 0F;
        this.line4.Y2 = 0F;
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
        this.textBox60.DataField = "saldo";
        this.textBox60.Height = 0.1875F;
        this.textBox60.Left = 10.6875F;
        this.textBox60.Name = "textBox60";
        this.textBox60.Style = "";
        this.textBox60.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.textBox60.SummaryGroup = "groupHeader3";
        this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox60.Text = "textBox60";
        this.textBox60.Top = 0.0625F;
        this.textBox60.Width = 1.5625F;
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
        this.textBox61.Left = 12.25F;
        this.textBox61.Name = "textBox61";
        this.textBox61.Style = "";
        this.textBox61.Text = "contrato(s)";
        this.textBox61.Top = 0.0625F;
        this.textBox61.Width = 1.125F;
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
        this.textBox72.Height = 0.375F;
        this.textBox72.Left = 8.9375F;
        this.textBox72.Name = "textBox72";
        this.textBox72.Style = "";
        this.textBox72.Text = "Total Apor- tado en $us";
        this.textBox72.Top = 1.1875F;
        this.textBox72.Width = 0.875F;
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
        this.textBox73.Height = 0.375F;
        this.textBox73.Left = 9.8125F;
        this.textBox73.Name = "textBox73";
        this.textBox73.Style = "";
        this.textBox73.Text = "Capital Apor- tado en $us";
        this.textBox73.Top = 1.1875F;
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
        this.textBox74.DataField = "total_aporte";
        this.textBox74.Height = 0.1875F;
        this.textBox74.Left = 8.9375F;
        this.textBox74.Name = "textBox74";
        this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
        this.textBox74.Style = "";
        this.textBox74.Text = "textBox74";
        this.textBox74.Top = 0F;
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
        this.textBox75.DataField = "total_amortizacion";
        this.textBox75.Height = 0.1875F;
        this.textBox75.Left = 9.8125F;
        this.textBox75.Name = "textBox75";
        this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
        this.textBox75.Style = "";
        this.textBox75.Text = "textBox75";
        this.textBox75.Top = 0F;
        this.textBox75.Width = 0.875F;
        // 
        // rpt_detalleGruposPromotoresRangos
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 16.51042F;
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
        this.ReportStart += new System.EventHandler(this.rpt_detalleGruposPromotoresRangos_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void groupHeader2_Format(object sender, EventArgs e)
    {

    }

    private void pageHeader_Format(object sender, EventArgs e)
    {

    }


}
