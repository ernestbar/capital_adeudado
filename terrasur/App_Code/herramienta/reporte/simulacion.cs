using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;  
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for simulacion.
/// </summary>
public class simulacion : DataDynamics.ActiveReports.ActiveReport3
{
    public void CargarDatos(string const_cliente, string const_ci, decimal const_capital, decimal const_inicial, int const_num_cuota,
int const_gracia, decimal const_interes, decimal const_seguro, decimal const_mantenimiento,
DateTime const_fecha_inicio, string Moneda, string Codigo_moneda)
    {
        label3.Text = DateTime.Now.ToString("F");

        textBox1.Text = const_cliente;
        textBox2.Text = const_ci;

        textBox11.Text = const_capital.ToString("F2");
        textBox12.Text = const_inicial.ToString("F2");
        textBox13.Text = const_num_cuota.ToString();
        textBox14.Text = const_gracia.ToString();
        textBox15.Text = const_fecha_inicio.ToString("d");
        textBox16.Text = const_interes.ToString("F2");
        textBox17.Text = const_seguro.ToString("F3");
        textBox18.Text = const_mantenimiento.ToString("F2");

        textBox4.Text = Moneda;
        label6.Text = "Capital total (" + Codigo_moneda + "):";
        label7.Text = "Cuota inicial (" + Codigo_moneda + "):";
        label13.Text = "Mantenimiento (" + Codigo_moneda + " mensual):";
        label16.Text = "Pago (" + Codigo_moneda + ")";
        label17.Text = "Seguro    (" + Codigo_moneda + ")";
        label18.Text = "Mantenim. (" + Codigo_moneda + ")";
        label19.Text = "Interés   (" + Codigo_moneda + ")";
        label20.Text = "Capital     (" + Codigo_moneda + ")";
        label21.Text = "Saldo (" + Codigo_moneda + ")";
    }

    private void simulacion_ReportStart(object sender, EventArgs e)
    {
        //this.DataSource = terrasur.simular.tabla_plan_simulado(terrasur.simular.lista_plan_simulado(
        //    Decimal.Parse(par_capital.Value.ToString()),
        //    Decimal.Parse(par_inicial.Value.ToString()),
        //    Int32.Parse(par_num_cuota.Value.ToString()),
        //    Int32.Parse(par_num_gracia.Value.ToString()),
        //    Decimal.Parse(par_interes.Value.ToString()),
        //    Decimal.Parse(par_seguro.Value.ToString()),
        //    Decimal.Parse(par_mantenimiento.Value.ToString()),
        //    DateTime.Parse(par_fecha_inicio.Value.ToString()).Date));
        //label3.Text = DateTime.Now.ToString("dd/MM/yyyy h:m:s");
        //textBox15.Text = DateTime.Parse(par_fecha_inicio.Value.ToString()).ToString("dd/MM/yyyy");

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

        //Report (Title):
        label1.ClassName = "estiloTitulo";
        //Report (Header):
        label2.ClassName = "estiloEncabEnun";
        label4.ClassName = "estiloEncabEnun";
        label5.ClassName = "estiloEncabEnun";
        label6.ClassName = "estiloEncabEnun";
        label7.ClassName = "estiloEncabEnun";
        label8.ClassName = "estiloEncabEnun";
        label9.ClassName = "estiloEncabEnun";
        label10.ClassName = "estiloEncabEnun";
        label11.ClassName = "estiloEncabEnun";
        label12.ClassName = "estiloEncabEnun";
        label13.ClassName = "estiloEncabEnun";

        textBox3.ClassName = "estiloEncabEnun";
        textBox4.ClassName = "estiloEncabDato";

        label3.ClassName = "estiloEncabDato";
        textBox1.ClassName = "estiloEncabDato";
        textBox2.ClassName = "estiloEncabDato";
        textBox11.ClassName = "estiloEncabDato";
        textBox12.ClassName = "estiloEncabDato";
        textBox13.ClassName = "estiloEncabDato";
        textBox14.ClassName = "estiloEncabDato";
        textBox15.ClassName = "estiloEncabDato";
        textBox16.ClassName = "estiloEncabDato";
        textBox17.ClassName = "estiloEncabDato";
        textBox18.ClassName = "estiloEncabDato";
        //Detalle (header):
        label14.ClassName = "estiloDetalleEnun";
        label15.ClassName = "estiloDetalleEnun";
        label16.ClassName = "estiloDetalleEnun";
        label17.ClassName = "estiloDetalleEnun";
        label18.ClassName = "estiloDetalleEnun";
        label19.ClassName = "estiloDetalleEnun";
        label20.ClassName = "estiloDetalleEnun";
        label21.ClassName = "estiloDetalleEnun";
        //Detalle (datos):
        textBox19.ClassName = "estiloDetalleDato";
        textBox20.ClassName = "estiloDetalleDato";
        textBox21.ClassName = "estiloDetalleDato";
        textBox22.ClassName = "estiloDetalleDato";
        textBox23.ClassName = "estiloDetalleDato";
        textBox24.ClassName = "estiloDetalleDato";
        textBox25.ClassName = "estiloDetalleDato";
        textBox26.ClassName = "estiloDetalleDato";

        textBox27.ClassName = "estiloTotal";
        textBox28.ClassName = "estiloTotal";
        textBox29.ClassName = "estiloTotal";
        textBox30.ClassName = "estiloTotal";
        textBox31.ClassName = "estiloTotal";
        //Report (footer):
        //Cometario:
        label22.ClassName = "estiloNota";
    } 


    private DataDynamics.ActiveReports.PageHeader pageHeader;
    private DataDynamics.ActiveReports.Detail detail;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Label label14;
    private TextBox textBox11;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox14;
    private TextBox textBox15;
    private TextBox textBox16;
    private TextBox textBox17;
    private TextBox textBox18;
    private Label label15;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label20;
    private Label label21;
    private TextBox textBox19;
    private TextBox textBox20;
    private TextBox textBox21;
    private TextBox textBox22;
    private TextBox textBox23;
    private TextBox textBox24;
    private TextBox textBox25;
    private TextBox textBox26;
    private Line line1;
    private TextBox textBox27;
    private TextBox textBox28;
    private TextBox textBox29;
    private TextBox textBox30;
    private TextBox textBox31;
    private Label label22;
    private Field par_cliente;
    private Field par_ci;
    private Field par_capital;
    private Field par_inicial;
    private Field par_num_cuota;
    private Field par_num_gracia;
    private Field par_interes;
    private Field par_seguro;
    private Field par_mantenimiento;
    private Field par_fecha_inicio;
    private Shape shape1;
    private Picture picture1;
    private TextBox textBox3;
    private TextBox textBox4;
    private DataDynamics.ActiveReports.PageFooter pageFooter;

    public simulacion()
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
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    #region ActiveReport Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.simulacion));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label18 = new DataDynamics.ActiveReports.Label();
        this.label19 = new DataDynamics.ActiveReports.Label();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.label21 = new DataDynamics.ActiveReports.Label();
        this.label17 = new DataDynamics.ActiveReports.Label();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.textBox25 = new DataDynamics.ActiveReports.TextBox();
        this.textBox26 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.textBox27 = new DataDynamics.ActiveReports.TextBox();
        this.textBox28 = new DataDynamics.ActiveReports.TextBox();
        this.textBox29 = new DataDynamics.ActiveReports.TextBox();
        this.textBox30 = new DataDynamics.ActiveReports.TextBox();
        this.textBox31 = new DataDynamics.ActiveReports.TextBox();
        this.label22 = new DataDynamics.ActiveReports.Label();
        this.par_cliente = new DataDynamics.ActiveReports.Field();
        this.par_ci = new DataDynamics.ActiveReports.Field();
        this.par_capital = new DataDynamics.ActiveReports.Field();
        this.par_inicial = new DataDynamics.ActiveReports.Field();
        this.par_num_cuota = new DataDynamics.ActiveReports.Field();
        this.par_num_gracia = new DataDynamics.ActiveReports.Field();
        this.par_interes = new DataDynamics.ActiveReports.Field();
        this.par_seguro = new DataDynamics.ActiveReports.Field();
        this.par_mantenimiento = new DataDynamics.ActiveReports.Field();
        this.par_fecha_inicio = new DataDynamics.ActiveReports.Field();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label14,
            this.label15,
            this.label16,
            this.label18,
            this.label19,
            this.label20,
            this.label21,
            this.label17});
        this.pageHeader.Height = 0.3645833F;
        this.pageHeader.Name = "pageHeader";
        // 
        // label14
        // 
        this.label14.Border.BottomColor = System.Drawing.Color.Black;
        this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Border.LeftColor = System.Drawing.Color.Black;
        this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Border.RightColor = System.Drawing.Color.Black;
        this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Border.TopColor = System.Drawing.Color.Black;
        this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label14.Height = 0.3125F;
        this.label14.HyperLink = null;
        this.label14.Left = 0F;
        this.label14.Name = "label14";
        this.label14.Style = "text-align: right; ";
        this.label14.Text = "N. Pago";
        this.label14.Top = 0F;
        this.label14.Width = 0.5625F;
        // 
        // label15
        // 
        this.label15.Border.BottomColor = System.Drawing.Color.Black;
        this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Border.LeftColor = System.Drawing.Color.Black;
        this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Border.RightColor = System.Drawing.Color.Black;
        this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Border.TopColor = System.Drawing.Color.Black;
        this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label15.Height = 0.3125F;
        this.label15.HyperLink = null;
        this.label15.Left = 0.5625F;
        this.label15.Name = "label15";
        this.label15.Style = "text-align: right; ";
        this.label15.Text = "F. Pago";
        this.label15.Top = 0F;
        this.label15.Width = 0.8125F;
        // 
        // label16
        // 
        this.label16.Border.BottomColor = System.Drawing.Color.Black;
        this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label16.Border.LeftColor = System.Drawing.Color.Black;
        this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label16.Border.RightColor = System.Drawing.Color.Black;
        this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label16.Border.TopColor = System.Drawing.Color.Black;
        this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label16.Height = 0.3125F;
        this.label16.HyperLink = null;
        this.label16.Left = 1.4375F;
        this.label16.Name = "label16";
        this.label16.Style = "text-align: right; ";
        this.label16.Text = "Pago";
        this.label16.Top = 0F;
        this.label16.Width = 0.8125F;
        // 
        // label18
        // 
        this.label18.Border.BottomColor = System.Drawing.Color.Black;
        this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Border.LeftColor = System.Drawing.Color.Black;
        this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Border.RightColor = System.Drawing.Color.Black;
        this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Border.TopColor = System.Drawing.Color.Black;
        this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label18.Height = 0.3125F;
        this.label18.HyperLink = null;
        this.label18.Left = 3.1875F;
        this.label18.Name = "label18";
        this.label18.Style = "text-align: right; ";
        this.label18.Text = "Mantenim.";
        this.label18.Top = 0F;
        this.label18.Width = 0.8125F;
        // 
        // label19
        // 
        this.label19.Border.BottomColor = System.Drawing.Color.Black;
        this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Border.LeftColor = System.Drawing.Color.Black;
        this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Border.RightColor = System.Drawing.Color.Black;
        this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Border.TopColor = System.Drawing.Color.Black;
        this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label19.Height = 0.3125F;
        this.label19.HyperLink = null;
        this.label19.Left = 4.0625F;
        this.label19.Name = "label19";
        this.label19.Style = "text-align: right; ";
        this.label19.Text = "Interés";
        this.label19.Top = 0F;
        this.label19.Width = 0.8125F;
        // 
        // label20
        // 
        this.label20.Border.BottomColor = System.Drawing.Color.Black;
        this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Border.LeftColor = System.Drawing.Color.Black;
        this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Border.RightColor = System.Drawing.Color.Black;
        this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Border.TopColor = System.Drawing.Color.Black;
        this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label20.Height = 0.3125F;
        this.label20.HyperLink = null;
        this.label20.Left = 4.9375F;
        this.label20.Name = "label20";
        this.label20.Style = "text-align: right; ";
        this.label20.Text = "Capital";
        this.label20.Top = 0F;
        this.label20.Width = 0.875F;
        // 
        // label21
        // 
        this.label21.Border.BottomColor = System.Drawing.Color.Black;
        this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label21.Border.LeftColor = System.Drawing.Color.Black;
        this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label21.Border.RightColor = System.Drawing.Color.Black;
        this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label21.Border.TopColor = System.Drawing.Color.Black;
        this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label21.Height = 0.3125F;
        this.label21.HyperLink = null;
        this.label21.Left = 5.875F;
        this.label21.Name = "label21";
        this.label21.Style = "text-align: right; ";
        this.label21.Text = "Saldo";
        this.label21.Top = 0F;
        this.label21.Width = 0.8125F;
        // 
        // label17
        // 
        this.label17.Border.BottomColor = System.Drawing.Color.Black;
        this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Border.LeftColor = System.Drawing.Color.Black;
        this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Border.RightColor = System.Drawing.Color.Black;
        this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Border.TopColor = System.Drawing.Color.Black;
        this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label17.Height = 0.3125F;
        this.label17.HyperLink = null;
        this.label17.Left = 2.3125F;
        this.label17.Name = "label17";
        this.label17.Style = "text-align: right; ";
        this.label17.Text = "Seguro";
        this.label17.Top = 0F;
        this.label17.Width = 0.8125F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26});
        this.detail.Height = 0.1875F;
        this.detail.Name = "detail";
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
        this.textBox19.DataField = "num_pago";
        this.textBox19.Height = 0.1875F;
        this.textBox19.Left = 0F;
        this.textBox19.Name = "textBox19";
        this.textBox19.Style = "text-align: right; ";
        this.textBox19.Text = "num_pago";
        this.textBox19.Top = 0F;
        this.textBox19.Width = 0.5625F;
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
        this.textBox20.DataField = "fecha";
        this.textBox20.Height = 0.1875F;
        this.textBox20.Left = 0.5625F;
        this.textBox20.Name = "textBox20";
        this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
        this.textBox20.Style = "text-align: right; ";
        this.textBox20.Text = "fecha";
        this.textBox20.Top = 0F;
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
        this.textBox21.DataField = "monto_pago";
        this.textBox21.Height = 0.1875F;
        this.textBox21.Left = 1.4375F;
        this.textBox21.Name = "textBox21";
        this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
        this.textBox21.Style = "text-align: right; ";
        this.textBox21.Text = "monto_pago";
        this.textBox21.Top = 0F;
        this.textBox21.Width = 0.8125F;
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
        this.textBox22.DataField = "seguro";
        this.textBox22.Height = 0.1875F;
        this.textBox22.Left = 2.3125F;
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
        this.textBox22.Style = "text-align: right; ";
        this.textBox22.Text = "seguro";
        this.textBox22.Top = 0F;
        this.textBox22.Width = 0.8125F;
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
        this.textBox23.DataField = "mantenimiento_sus";
        this.textBox23.Height = 0.1875F;
        this.textBox23.Left = 3.1875F;
        this.textBox23.Name = "textBox23";
        this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
        this.textBox23.Style = "text-align: right; ";
        this.textBox23.Text = "mantenimiento_sus";
        this.textBox23.Top = 0F;
        this.textBox23.Width = 0.8125F;
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
        this.textBox24.DataField = "interes";
        this.textBox24.Height = 0.1875F;
        this.textBox24.Left = 4.0625F;
        this.textBox24.Name = "textBox24";
        this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
        this.textBox24.Style = "text-align: right; ";
        this.textBox24.Text = "interes";
        this.textBox24.Top = 0F;
        this.textBox24.Width = 0.8125F;
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
        this.textBox25.DataField = "amortizacion";
        this.textBox25.Height = 0.1875F;
        this.textBox25.Left = 4.9375F;
        this.textBox25.Name = "textBox25";
        this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
        this.textBox25.Style = "text-align: right; ";
        this.textBox25.Text = "amortizacion";
        this.textBox25.Top = 0F;
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
        this.textBox26.DataField = "saldo";
        this.textBox26.Height = 0.1875F;
        this.textBox26.Left = 5.875F;
        this.textBox26.Name = "textBox26";
        this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
        this.textBox26.Style = "text-align: right; ";
        this.textBox26.Text = "saldo";
        this.textBox26.Top = 0F;
        this.textBox26.Width = 0.8125F;
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0.01041667F;
        this.pageFooter.Name = "pageFooter";
        // 
        // label1
        // 
        this.label1.Border.BottomColor = System.Drawing.Color.Black;
        this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.LeftColor = System.Drawing.Color.Black;
        this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.RightColor = System.Drawing.Color.Black;
        this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.TopColor = System.Drawing.Color.Black;
        this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Height = 0.4375F;
        this.label1.HyperLink = null;
        this.label1.Left = 0.1875F;
        this.label1.Name = "label1";
        this.label1.Style = "";
        this.label1.Text = "Simulación de plan de pagos";
        this.label1.Top = 0.4375F;
        this.label1.Width = 6.1875F;
        // 
        // label2
        // 
        this.label2.Border.BottomColor = System.Drawing.Color.Black;
        this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.LeftColor = System.Drawing.Color.Black;
        this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.RightColor = System.Drawing.Color.Black;
        this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.TopColor = System.Drawing.Color.Black;
        this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = null;
        this.label2.Left = 0.1875F;
        this.label2.Name = "label2";
        this.label2.Style = "";
        this.label2.Text = "Fecha de emisión:";
        this.label2.Top = 1F;
        this.label2.Width = 1.1875F;
        // 
        // label3
        // 
        this.label3.Border.BottomColor = System.Drawing.Color.Black;
        this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.LeftColor = System.Drawing.Color.Black;
        this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.RightColor = System.Drawing.Color.Black;
        this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.TopColor = System.Drawing.Color.Black;
        this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = null;
        this.label3.Left = 1.4375F;
        this.label3.Name = "label3";
        this.label3.Style = "";
        this.label3.Text = "label3";
        this.label3.Top = 1F;
        this.label3.Width = 4.9375F;
        // 
        // label4
        // 
        this.label4.Border.BottomColor = System.Drawing.Color.Black;
        this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.LeftColor = System.Drawing.Color.Black;
        this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.RightColor = System.Drawing.Color.Black;
        this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.TopColor = System.Drawing.Color.Black;
        this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Height = 0.1875F;
        this.label4.HyperLink = null;
        this.label4.Left = 0.1875F;
        this.label4.Name = "label4";
        this.label4.Style = "";
        this.label4.Text = "Cliente:";
        this.label4.Top = 1.25F;
        this.label4.Width = 0.5625F;
        // 
        // label5
        // 
        this.label5.Border.BottomColor = System.Drawing.Color.Black;
        this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.LeftColor = System.Drawing.Color.Black;
        this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.RightColor = System.Drawing.Color.Black;
        this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Border.TopColor = System.Drawing.Color.Black;
        this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label5.Height = 0.1875F;
        this.label5.HyperLink = null;
        this.label5.Left = 4.875F;
        this.label5.Name = "label5";
        this.label5.Style = "";
        this.label5.Text = "C.I.:";
        this.label5.Top = 1.25F;
        this.label5.Width = 0.25F;
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
        this.textBox2.Left = 5.125F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "";
        this.textBox2.Text = "par_ci";
        this.textBox2.Top = 1.25F;
        this.textBox2.Width = 1.25F;
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
        this.textBox1.Left = 0.8125F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "";
        this.textBox1.Text = "par_cliente";
        this.textBox1.Top = 1.25F;
        this.textBox1.Width = 4F;
        // 
        // label6
        // 
        this.label6.Border.BottomColor = System.Drawing.Color.Black;
        this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.LeftColor = System.Drawing.Color.Black;
        this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.RightColor = System.Drawing.Color.Black;
        this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Border.TopColor = System.Drawing.Color.Black;
        this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label6.Height = 0.1875F;
        this.label6.HyperLink = null;
        this.label6.Left = 0.1875F;
        this.label6.Name = "label6";
        this.label6.Style = "";
        this.label6.Text = "Capital total ($us):";
        this.label6.Top = 1.75F;
        this.label6.Width = 1.875F;
        // 
        // label7
        // 
        this.label7.Border.BottomColor = System.Drawing.Color.Black;
        this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label7.Border.LeftColor = System.Drawing.Color.Black;
        this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label7.Border.RightColor = System.Drawing.Color.Black;
        this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label7.Border.TopColor = System.Drawing.Color.Black;
        this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label7.Height = 0.1875F;
        this.label7.HyperLink = null;
        this.label7.Left = 0.1875F;
        this.label7.Name = "label7";
        this.label7.Style = "";
        this.label7.Text = "Cuota inicial ($us):";
        this.label7.Top = 2F;
        this.label7.Width = 1.875F;
        // 
        // label8
        // 
        this.label8.Border.BottomColor = System.Drawing.Color.Black;
        this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Border.LeftColor = System.Drawing.Color.Black;
        this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Border.RightColor = System.Drawing.Color.Black;
        this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Border.TopColor = System.Drawing.Color.Black;
        this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = null;
        this.label8.Left = 0.1875F;
        this.label8.Name = "label8";
        this.label8.Style = "";
        this.label8.Text = "Nº de cuotas:";
        this.label8.Top = 2.25F;
        this.label8.Width = 1.875F;
        // 
        // label9
        // 
        this.label9.Border.BottomColor = System.Drawing.Color.Black;
        this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label9.Border.LeftColor = System.Drawing.Color.Black;
        this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label9.Border.RightColor = System.Drawing.Color.Black;
        this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label9.Border.TopColor = System.Drawing.Color.Black;
        this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label9.Height = 0.1875F;
        this.label9.HyperLink = null;
        this.label9.Left = 0.1875F;
        this.label9.Name = "label9";
        this.label9.Style = "";
        this.label9.Text = "Periodo de gracia (meses):";
        this.label9.Top = 2.5F;
        this.label9.Width = 1.875F;
        // 
        // label10
        // 
        this.label10.Border.BottomColor = System.Drawing.Color.Black;
        this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Border.LeftColor = System.Drawing.Color.Black;
        this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Border.RightColor = System.Drawing.Color.Black;
        this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Border.TopColor = System.Drawing.Color.Black;
        this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label10.Height = 0.1875F;
        this.label10.HyperLink = null;
        this.label10.Left = 3.1875F;
        this.label10.Name = "label10";
        this.label10.Style = "";
        this.label10.Text = "Fecha de inicio del plan:";
        this.label10.Top = 1.75F;
        this.label10.Width = 2.125F;
        // 
        // label11
        // 
        this.label11.Border.BottomColor = System.Drawing.Color.Black;
        this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.LeftColor = System.Drawing.Color.Black;
        this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.RightColor = System.Drawing.Color.Black;
        this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Border.TopColor = System.Drawing.Color.Black;
        this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label11.Height = 0.1875F;
        this.label11.HyperLink = null;
        this.label11.Left = 3.1875F;
        this.label11.Name = "label11";
        this.label11.Style = "";
        this.label11.Text = "Interés corriente (% anual):";
        this.label11.Top = 2F;
        this.label11.Width = 2.125F;
        // 
        // label12
        // 
        this.label12.Border.BottomColor = System.Drawing.Color.Black;
        this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.LeftColor = System.Drawing.Color.Black;
        this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.RightColor = System.Drawing.Color.Black;
        this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Border.TopColor = System.Drawing.Color.Black;
        this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = null;
        this.label12.Left = 3.1875F;
        this.label12.Name = "label12";
        this.label12.Style = "";
        this.label12.Text = "Seguro de desgrav. (% mensual):";
        this.label12.Top = 2.25F;
        this.label12.Width = 2.125F;
        // 
        // label13
        // 
        this.label13.Border.BottomColor = System.Drawing.Color.Black;
        this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Border.LeftColor = System.Drawing.Color.Black;
        this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Border.RightColor = System.Drawing.Color.Black;
        this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Border.TopColor = System.Drawing.Color.Black;
        this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = null;
        this.label13.Left = 3.1875F;
        this.label13.Name = "label13";
        this.label13.Style = "";
        this.label13.Text = "Mantenimineto ($us mensual):";
        this.label13.Top = 2.5F;
        this.label13.Width = 2.125F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5,
            this.textBox2,
            this.textBox1,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.shape1,
            this.picture1,
            this.textBox3,
            this.textBox4});
        this.reportHeader1.Height = 2.8125F;
        this.reportHeader1.Name = "reportHeader1";
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
        this.textBox11.Left = 2.125F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "";
        this.textBox11.Text = "par_capital";
        this.textBox11.Top = 1.75F;
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
        this.textBox12.Height = 0.1875F;
        this.textBox12.Left = 2.125F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "";
        this.textBox12.Text = "par_inicial";
        this.textBox12.Top = 2F;
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
        this.textBox13.Height = 0.1875F;
        this.textBox13.Left = 2.125F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "";
        this.textBox13.Text = "par_num_cuota";
        this.textBox13.Top = 2.25F;
        this.textBox13.Width = 0.875F;
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
        this.textBox14.Left = 2.125F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "";
        this.textBox14.Text = "par_num_gracia";
        this.textBox14.Top = 2.5F;
        this.textBox14.Width = 0.875F;
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
        this.textBox15.Height = 0.1979167F;
        this.textBox15.Left = 5.375F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "";
        this.textBox15.Text = null;
        this.textBox15.Top = 1.75F;
        this.textBox15.Width = 1F;
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
        this.textBox16.Height = 0.1979167F;
        this.textBox16.Left = 5.375F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "";
        this.textBox16.Text = "par_interes";
        this.textBox16.Top = 2F;
        this.textBox16.Width = 1F;
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
        this.textBox17.Height = 0.1979167F;
        this.textBox17.Left = 5.375F;
        this.textBox17.Name = "textBox17";
        this.textBox17.Style = "";
        this.textBox17.Text = "par_seguro";
        this.textBox17.Top = 2.25F;
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
        this.textBox18.Height = 0.1979167F;
        this.textBox18.Left = 5.375F;
        this.textBox18.Name = "textBox18";
        this.textBox18.Style = "";
        this.textBox18.Text = "par_mantenimiento";
        this.textBox18.Top = 2.5F;
        this.textBox18.Width = 1F;
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
        this.shape1.Height = 1.8125F;
        this.shape1.Left = 0.125F;
        this.shape1.Name = "shape1";
        this.shape1.RoundingRadius = 9.999999F;
        this.shape1.Top = 0.9375F;
        this.shape1.Width = 6.3125F;
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
        this.picture1.Height = 0.3125F;
        this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.Left = 0.1875F;
        this.picture1.LineWeight = 0F;
        this.picture1.Name = "picture1";
        this.picture1.Top = 0.0625F;
        this.picture1.Width = 2.0625F;
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
        this.textBox3.Left = 0.1875F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "";
        this.textBox3.Text = "Moneda:";
        this.textBox3.Top = 1.5F;
        this.textBox3.Width = 1.1875F;
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
        this.textBox4.Left = 1.4375F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "";
        this.textBox4.Text = "textBox4";
        this.textBox4.Top = 1.5F;
        this.textBox4.Width = 1.5625F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line1,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.label22});
        this.reportFooter1.Height = 0.6145833F;
        this.reportFooter1.Name = "reportFooter1";
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
        this.line1.LineWeight = 2F;
        this.line1.Name = "line1";
        this.line1.Top = 0.0625F;
        this.line1.Width = 6.6875F;
        this.line1.X1 = 0F;
        this.line1.X2 = 6.6875F;
        this.line1.Y1 = 0.0625F;
        this.line1.Y2 = 0.0625F;
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
        this.textBox27.DataField = "monto_pago";
        this.textBox27.Height = 0.1875F;
        this.textBox27.Left = 1.4375F;
        this.textBox27.Name = "textBox27";
        this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
        this.textBox27.Style = "text-align: right; ";
        this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox27.Text = "monto_pago";
        this.textBox27.Top = 0.125F;
        this.textBox27.Width = 0.8125F;
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
        this.textBox28.DataField = "seguro";
        this.textBox28.Height = 0.1875F;
        this.textBox28.Left = 2.3125F;
        this.textBox28.Name = "textBox28";
        this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
        this.textBox28.Style = "text-align: right; ";
        this.textBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox28.Text = "seguro";
        this.textBox28.Top = 0.125F;
        this.textBox28.Width = 0.8125F;
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
        this.textBox29.DataField = "mantenimiento_sus";
        this.textBox29.Height = 0.1875F;
        this.textBox29.Left = 3.1875F;
        this.textBox29.Name = "textBox29";
        this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
        this.textBox29.Style = "text-align: right; ";
        this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox29.Text = "mantenimiento_sus";
        this.textBox29.Top = 0.125F;
        this.textBox29.Width = 0.8125F;
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
        this.textBox30.DataField = "interes";
        this.textBox30.Height = 0.1875F;
        this.textBox30.Left = 4.0625F;
        this.textBox30.Name = "textBox30";
        this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
        this.textBox30.Style = "text-align: right; ";
        this.textBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox30.Text = "interes";
        this.textBox30.Top = 0.125F;
        this.textBox30.Width = 0.8125F;
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
        this.textBox31.DataField = "amortizacion";
        this.textBox31.Height = 0.1875F;
        this.textBox31.Left = 4.9375F;
        this.textBox31.Name = "textBox31";
        this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
        this.textBox31.Style = "text-align: right; ";
        this.textBox31.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.textBox31.Text = "amortizacion";
        this.textBox31.Top = 0.125F;
        this.textBox31.Width = 0.875F;
        // 
        // label22
        // 
        this.label22.Border.BottomColor = System.Drawing.Color.Black;
        this.label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label22.Border.LeftColor = System.Drawing.Color.Black;
        this.label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label22.Border.RightColor = System.Drawing.Color.Black;
        this.label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label22.Border.TopColor = System.Drawing.Color.Black;
        this.label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label22.Height = 0.1875F;
        this.label22.HyperLink = null;
        this.label22.Left = 3.625F;
        this.label22.Name = "label22";
        this.label22.Style = "";
        this.label22.Text = "El presente plan de pagos es REFERENCIAL";
        this.label22.Top = 0.375F;
        this.label22.Width = 2.9375F;
        // 
        // par_cliente
        // 
        this.par_cliente.DefaultValue = null;
        this.par_cliente.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_cliente.Formula = null;
        this.par_cliente.Name = "par_cliente";
        this.par_cliente.Tag = null;
        // 
        // par_ci
        // 
        this.par_ci.DefaultValue = null;
        this.par_ci.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_ci.Formula = null;
        this.par_ci.Name = "par_ci";
        this.par_ci.Tag = null;
        // 
        // par_capital
        // 
        this.par_capital.DefaultValue = null;
        this.par_capital.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_capital.Formula = null;
        this.par_capital.Name = "par_capital";
        this.par_capital.Tag = null;
        // 
        // par_inicial
        // 
        this.par_inicial.DefaultValue = null;
        this.par_inicial.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_inicial.Formula = null;
        this.par_inicial.Name = "par_inicial";
        this.par_inicial.Tag = null;
        // 
        // par_num_cuota
        // 
        this.par_num_cuota.DefaultValue = null;
        this.par_num_cuota.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_num_cuota.Formula = null;
        this.par_num_cuota.Name = "par_num_cuota";
        this.par_num_cuota.Tag = null;
        // 
        // par_num_gracia
        // 
        this.par_num_gracia.DefaultValue = null;
        this.par_num_gracia.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_num_gracia.Formula = null;
        this.par_num_gracia.Name = "par_num_gracia";
        this.par_num_gracia.Tag = null;
        // 
        // par_interes
        // 
        this.par_interes.DefaultValue = null;
        this.par_interes.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_interes.Formula = null;
        this.par_interes.Name = "par_interes";
        this.par_interes.Tag = null;
        // 
        // par_seguro
        // 
        this.par_seguro.DefaultValue = null;
        this.par_seguro.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_seguro.Formula = null;
        this.par_seguro.Name = "par_seguro";
        this.par_seguro.Tag = null;
        // 
        // par_mantenimiento
        // 
        this.par_mantenimiento.DefaultValue = null;
        this.par_mantenimiento.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_mantenimiento.Formula = null;
        this.par_mantenimiento.Name = "par_mantenimiento";
        this.par_mantenimiento.Tag = null;
        // 
        // par_fecha_inicio
        // 
        this.par_fecha_inicio.DefaultValue = null;
        this.par_fecha_inicio.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.None;
        this.par_fecha_inicio.Formula = null;
        this.par_fecha_inicio.Name = "par_fecha_inicio";
        this.par_fecha_inicio.Tag = null;
        // 
        // simulacion
        // 
        this.MasterReport = false;
        this.CalculatedFields.Add(this.par_cliente);
        this.CalculatedFields.Add(this.par_ci);
        this.CalculatedFields.Add(this.par_capital);
        this.CalculatedFields.Add(this.par_inicial);
        this.CalculatedFields.Add(this.par_num_cuota);
        this.CalculatedFields.Add(this.par_num_gracia);
        this.CalculatedFields.Add(this.par_interes);
        this.CalculatedFields.Add(this.par_seguro);
        this.CalculatedFields.Add(this.par_mantenimiento);
        this.CalculatedFields.Add(this.par_fecha_inicio);
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.6875F;
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
        this.ReportStart += new System.EventHandler(this.simulacion_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

}
