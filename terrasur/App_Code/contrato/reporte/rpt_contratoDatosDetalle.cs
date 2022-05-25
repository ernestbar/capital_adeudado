using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document; 
using System.Web; 
   
/// <summary>
/// Summary description for rpt_contratoDatosDetalle.
/// </summary>
public class rpt_contratoDatosDetalle : DataDynamics.ActiveReports.ActiveReport3
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
    private TextBox textBox9;
    public SubReport subReport1;
    public SubReport subReport2;
    public SubReport subReport3;
    public SubReport subReport4;
    public SubReport subReport5;
    public SubReport subReport6;
    public SubReport subReport7;
    public SubReport subReport8;
    public SubReport subReport9;
    public SubReport subReport10;
    private TextBox textBox36;
    private Picture picture1;
    public SubReport subReport11;
    private TextBox textBox10;
    private TextBox textBox11;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox14;
    private TextBox textBox15;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rpt_contratoDatosDetalle()
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
    public void Encabezado(int Id_contrato)
    {
        terrasur.contrato c = new terrasur.contrato(Id_contrato);
        textBox3.Text = c.numero;
        textBox5.Text = c.estado_nombre + " (" + terrasur.contrato.EstadoActualFecha(Id_contrato).ToShortDateString() + ")";
        textBox7.Text = c.fecha.ToString("d");
        terrasur.usuario uObj = new terrasur.usuario(c.id_usuario);

        textBox9.Text = uObj.nombres.Substring(0,1).ToUpper() + "." + uObj.paterno.ToUpper();
        textBox36.Text = "Fecha de emisión: " + DateTime.Now.ToString("F");
        textBox11.Text = c.negocio_nombre;

        textBox13.Text = new terrasur.moneda(c.id_moneda).nombre;

        int num_seguro = new terrasur.seguro_provida(Id_contrato).numero;
        if (num_seguro > 0) { textBox15.Text = num_seguro.ToString(); } else { textBox15.Text = "---"; }

        Bordes();
     }
    public void Bordes()
    {
        subReport1.Border.TopStyle = BorderLineStyle.Solid;
        subReport1.Border.LeftStyle = BorderLineStyle.Solid;
        subReport1.Border.RightStyle  = BorderLineStyle.Solid;
        subReport1.Border.BottomStyle  = BorderLineStyle.Solid;
        
        subReport2.Border.TopStyle = BorderLineStyle.Solid;
        subReport2.Border.LeftStyle = BorderLineStyle.Solid;
        subReport2.Border.RightStyle = BorderLineStyle.Solid;
        subReport2.Border.BottomStyle = BorderLineStyle.Solid;

        subReport3.Border.TopStyle = BorderLineStyle.Solid;
        subReport3.Border.LeftStyle = BorderLineStyle.Solid;
        subReport3.Border.RightStyle = BorderLineStyle.Solid;
        subReport3.Border.BottomStyle = BorderLineStyle.Solid;

        subReport4.Border.TopStyle = BorderLineStyle.Solid;
        subReport4.Border.LeftStyle = BorderLineStyle.Solid;
        subReport4.Border.RightStyle = BorderLineStyle.Solid;
        subReport4.Border.BottomStyle = BorderLineStyle.Solid;

        subReport5.Border.TopStyle = BorderLineStyle.Solid;
        subReport5.Border.LeftStyle = BorderLineStyle.Solid;
        subReport5.Border.RightStyle = BorderLineStyle.Solid;
        subReport5.Border.BottomStyle = BorderLineStyle.Solid;

        subReport6.Border.TopStyle = BorderLineStyle.Solid;
        subReport6.Border.LeftStyle = BorderLineStyle.Solid;
        subReport6.Border.RightStyle = BorderLineStyle.Solid;
        subReport6.Border.BottomStyle = BorderLineStyle.Solid;

        subReport7.Border.TopStyle = BorderLineStyle.Solid;
        subReport7.Border.LeftStyle = BorderLineStyle.Solid;
        subReport7.Border.RightStyle = BorderLineStyle.Solid;
        subReport7.Border.BottomStyle = BorderLineStyle.Solid;

        subReport8.Border.TopStyle = BorderLineStyle.Solid;
        subReport8.Border.LeftStyle = BorderLineStyle.Solid;
        subReport8.Border.RightStyle = BorderLineStyle.Solid;
        subReport8.Border.BottomStyle = BorderLineStyle.Solid;

        subReport9.Border.TopStyle = BorderLineStyle.Solid;
        subReport9.Border.LeftStyle = BorderLineStyle.Solid;
        subReport9.Border.RightStyle = BorderLineStyle.Solid;
        subReport9.Border.BottomStyle = BorderLineStyle.Solid;

        subReport10.Border.TopStyle = BorderLineStyle.Solid;
        subReport10.Border.LeftStyle = BorderLineStyle.Solid;
        subReport10.Border.RightStyle = BorderLineStyle.Solid;
        subReport10.Border.BottomStyle = BorderLineStyle.Solid;

        subReport11.Border.TopStyle = BorderLineStyle.Solid;
        subReport11.Border.LeftStyle = BorderLineStyle.Solid;
        subReport11.Border.RightStyle = BorderLineStyle.Solid;
        subReport11.Border.BottomStyle = BorderLineStyle.Solid;
    }
    private void rpt_contratoDatosDetalle_ReportStart(object sender, EventArgs e)
    {
        //MARGENES
        //this.PageSettings.Margins.Top = 0.5F;
        //this.PageSettings.Margins.Bottom = 0.5F;
        //this.PageSettings.Margins.Right = 0.5F;
        //this.PageSettings.Margins.Left = 0.5F;

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
        textBox3.ClassName = "estiloTitulo";
        textBox12.ClassName = "estiloEncabEnun";
        textBox13.ClassName = "estiloTitulo";
        textBox4.ClassName = "estiloEncabEnun";
        textBox5.ClassName = "estiloEncabDato";
        textBox6.ClassName = "estiloEncabEnun";
        textBox7.ClassName = "estiloEncabDato";
        textBox10.ClassName = "estiloEncabEnun";
        textBox11.ClassName = "estiloEncabDato";
        textBox8.ClassName = "estiloEncabEnun";
        textBox9.ClassName = "estiloEncabDato";
        textBox14.ClassName = "estiloEncabEnun";
        textBox15.ClassName = "estiloEncabDato";
    }
    #region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rpt_contratoDatosDetalle));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.subReport1 = new DataDynamics.ActiveReports.SubReport();
        this.subReport2 = new DataDynamics.ActiveReports.SubReport();
        this.subReport3 = new DataDynamics.ActiveReports.SubReport();
        this.subReport4 = new DataDynamics.ActiveReports.SubReport();
        this.subReport5 = new DataDynamics.ActiveReports.SubReport();
        this.subReport6 = new DataDynamics.ActiveReports.SubReport();
        this.subReport7 = new DataDynamics.ActiveReports.SubReport();
        this.subReport8 = new DataDynamics.ActiveReports.SubReport();
        this.subReport9 = new DataDynamics.ActiveReports.SubReport();
        this.subReport10 = new DataDynamics.ActiveReports.SubReport();
        this.subReport11 = new DataDynamics.ActiveReports.SubReport();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox36 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Height = 0F;
        this.pageHeader.Name = "pageHeader";
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
        this.textBox2.Text = "No. de contrato:";
        this.textBox2.Top = 0.1875F;
        this.textBox2.Width = 1.0625F;
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
        this.textBox3.Height = 0.25F;
        this.textBox3.Left = 1.0625F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = null;
        this.textBox3.Top = 0.125F;
        this.textBox3.Width = 1.0625F;
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
        this.textBox4.Left = 0F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "Estado Actual:";
        this.textBox4.Top = 0.4375F;
        this.textBox4.Width = 1.0625F;
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
        this.textBox5.Left = 1.0625F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "";
        this.textBox5.Text = null;
        this.textBox5.Top = 0.4375F;
        this.textBox5.Width = 1.625F;
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
        this.textBox6.Left = 2.6875F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "";
        this.textBox6.Text = "Fecha de Registro:";
        this.textBox6.Top = 0.4375F;
        this.textBox6.Width = 1.25F;
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
        this.textBox7.Left = 3.9375F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "";
        this.textBox7.Text = null;
        this.textBox7.Top = 0.4375F;
        this.textBox7.Width = 0.8125F;
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
        this.textBox8.Left = 4.75F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "";
        this.textBox8.Text = "Usuario:";
        this.textBox8.Top = 0.4375F;
        this.textBox8.Width = 0.75F;
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
        this.textBox9.Height = 0.1979167F;
        this.textBox9.Left = 5.5F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "";
        this.textBox9.Text = null;
        this.textBox9.Top = 0.4375F;
        this.textBox9.Width = 1F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.subReport2,
            this.subReport3,
            this.subReport4,
            this.subReport5,
            this.subReport6,
            this.subReport7,
            this.subReport8,
            this.subReport9,
            this.subReport10,
            this.textBox4,
            this.textBox3,
            this.textBox2,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.subReport11,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15});
        this.detail.Height = 2.270833F;
        this.detail.Name = "detail";
        // 
        // subReport1
        // 
        this.subReport1.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.Border.RightColor = System.Drawing.Color.Black;
        this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.Border.TopColor = System.Drawing.Color.Black;
        this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport1.CloseBorder = false;
        this.subReport1.Height = 0.0625F;
        this.subReport1.Left = 0F;
        this.subReport1.Name = "subReport1";
        this.subReport1.Report = null;
        this.subReport1.ReportName = "subReport1";
        this.subReport1.Top = 0.9375F;
        this.subReport1.Width = 6.5F;
        // 
        // subReport2
        // 
        this.subReport2.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.Border.RightColor = System.Drawing.Color.Black;
        this.subReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.Border.TopColor = System.Drawing.Color.Black;
        this.subReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport2.CloseBorder = false;
        this.subReport2.Height = 0.0625F;
        this.subReport2.Left = 0F;
        this.subReport2.Name = "subReport2";
        this.subReport2.Report = null;
        this.subReport2.ReportName = "subReport1";
        this.subReport2.Top = 1.0625F;
        this.subReport2.Width = 6.5F;
        // 
        // subReport3
        // 
        this.subReport3.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.Border.RightColor = System.Drawing.Color.Black;
        this.subReport3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.Border.TopColor = System.Drawing.Color.Black;
        this.subReport3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport3.CloseBorder = false;
        this.subReport3.Height = 0.0625F;
        this.subReport3.Left = 0F;
        this.subReport3.Name = "subReport3";
        this.subReport3.Report = null;
        this.subReport3.ReportName = "subReport1";
        this.subReport3.Top = 1.1875F;
        this.subReport3.Width = 6.5F;
        // 
        // subReport4
        // 
        this.subReport4.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.Border.RightColor = System.Drawing.Color.Black;
        this.subReport4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.Border.TopColor = System.Drawing.Color.Black;
        this.subReport4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport4.CloseBorder = false;
        this.subReport4.Height = 0.0625F;
        this.subReport4.Left = 0F;
        this.subReport4.Name = "subReport4";
        this.subReport4.Report = null;
        this.subReport4.ReportName = "subReport1";
        this.subReport4.Top = 1.3125F;
        this.subReport4.Width = 6.5F;
        // 
        // subReport5
        // 
        this.subReport5.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport5.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport5.Border.RightColor = System.Drawing.Color.Black;
        this.subReport5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport5.Border.TopColor = System.Drawing.Color.Black;
        this.subReport5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport5.CloseBorder = false;
        this.subReport5.Height = 0.0625F;
        this.subReport5.Left = 0F;
        this.subReport5.Name = "subReport5";
        this.subReport5.Report = null;
        this.subReport5.ReportName = "subReport1";
        this.subReport5.Top = 1.4375F;
        this.subReport5.Width = 6.5F;
        // 
        // subReport6
        // 
        this.subReport6.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport6.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport6.Border.RightColor = System.Drawing.Color.Black;
        this.subReport6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport6.Border.TopColor = System.Drawing.Color.Black;
        this.subReport6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport6.CloseBorder = false;
        this.subReport6.Height = 0.0625F;
        this.subReport6.Left = 0F;
        this.subReport6.Name = "subReport6";
        this.subReport6.Report = null;
        this.subReport6.ReportName = "subReport1";
        this.subReport6.Top = 1.5625F;
        this.subReport6.Width = 6.5F;
        // 
        // subReport7
        // 
        this.subReport7.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport7.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport7.Border.RightColor = System.Drawing.Color.Black;
        this.subReport7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport7.Border.TopColor = System.Drawing.Color.Black;
        this.subReport7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport7.CloseBorder = false;
        this.subReport7.Height = 0.0625F;
        this.subReport7.Left = 0F;
        this.subReport7.Name = "subReport7";
        this.subReport7.Report = null;
        this.subReport7.ReportName = "subReport1";
        this.subReport7.Top = 1.6875F;
        this.subReport7.Width = 6.5F;
        // 
        // subReport8
        // 
        this.subReport8.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport8.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport8.Border.RightColor = System.Drawing.Color.Black;
        this.subReport8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport8.Border.TopColor = System.Drawing.Color.Black;
        this.subReport8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport8.CloseBorder = false;
        this.subReport8.Height = 0.0625F;
        this.subReport8.Left = 0F;
        this.subReport8.Name = "subReport8";
        this.subReport8.Report = null;
        this.subReport8.ReportName = "subReport1";
        this.subReport8.Top = 1.8125F;
        this.subReport8.Width = 6.5F;
        // 
        // subReport9
        // 
        this.subReport9.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport9.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport9.Border.RightColor = System.Drawing.Color.Black;
        this.subReport9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport9.Border.TopColor = System.Drawing.Color.Black;
        this.subReport9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport9.CloseBorder = false;
        this.subReport9.Height = 0.0625F;
        this.subReport9.Left = 0F;
        this.subReport9.Name = "subReport9";
        this.subReport9.Report = null;
        this.subReport9.ReportName = "subReport1";
        this.subReport9.Top = 1.9375F;
        this.subReport9.Width = 6.5F;
        // 
        // subReport10
        // 
        this.subReport10.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport10.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport10.Border.RightColor = System.Drawing.Color.Black;
        this.subReport10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport10.Border.TopColor = System.Drawing.Color.Black;
        this.subReport10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport10.CloseBorder = false;
        this.subReport10.Height = 0.0625F;
        this.subReport10.Left = 0F;
        this.subReport10.Name = "subReport10";
        this.subReport10.Report = null;
        this.subReport10.ReportName = "subReport1";
        this.subReport10.Top = 2.0625F;
        this.subReport10.Width = 6.5F;
        // 
        // subReport11
        // 
        this.subReport11.Border.BottomColor = System.Drawing.Color.Black;
        this.subReport11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport11.Border.LeftColor = System.Drawing.Color.Black;
        this.subReport11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport11.Border.RightColor = System.Drawing.Color.Black;
        this.subReport11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport11.Border.TopColor = System.Drawing.Color.Black;
        this.subReport11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.subReport11.CloseBorder = false;
        this.subReport11.Height = 0.0625F;
        this.subReport11.Left = 0F;
        this.subReport11.Name = "subReport11";
        this.subReport11.Report = null;
        this.subReport11.ReportName = "subReport11";
        this.subReport11.Top = 2.1875F;
        this.subReport11.Width = 6.5F;
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
        this.textBox10.Left = 4.0625F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "";
        this.textBox10.Text = "Negocio:";
        this.textBox10.Top = 0.1875F;
        this.textBox10.Width = 0.6875F;
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
        this.textBox11.Left = 4.75F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "textBox11";
        this.textBox11.Top = 0.1875F;
        this.textBox11.Width = 1.75F;
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
        this.textBox12.Left = 2.1875F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "Moneda:";
        this.textBox12.Top = 0.1875F;
        this.textBox12.Width = 0.625F;
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
        this.textBox13.Height = 0.25F;
        this.textBox13.Left = 2.8125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "textBox13";
        this.textBox13.Top = 0.125F;
        this.textBox13.Width = 1.125F;
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
        this.textBox14.Left = 2.6875F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "Nº Form. Seguro:";
        this.textBox14.Top = 0.6875F;
        this.textBox14.Width = 1.25F;
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
        this.textBox15.Left = 3.9375F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = "textBox15";
        this.textBox15.Top = 0.6875F;
        this.textBox15.Width = 0.8125F;
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
            this.textBox36,
            this.picture1});
        this.reportHeader1.Height = 0.5F;
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
        this.textBox1.Text = "Datos de contrato";
        this.textBox1.Top = 0.3125F;
        this.textBox1.Width = 6.5F;
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
        this.textBox36.Left = 2.6875F;
        this.textBox36.Name = "textBox36";
        this.textBox36.Style = "";
        this.textBox36.Text = null;
        this.textBox36.Top = 0.0625F;
        this.textBox36.Width = 3.8125F;
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
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // rpt_contratoDatosDetalle
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.520833F;
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
        this.ReportStart += new System.EventHandler(this.rpt_contratoDatosDetalle_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    
}
