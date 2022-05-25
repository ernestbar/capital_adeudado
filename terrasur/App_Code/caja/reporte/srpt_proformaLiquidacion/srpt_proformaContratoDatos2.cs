using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;

/// <summary>
/// Summary description for srpt_proformaContratoDatos2.
/// </summary>
public class srpt_proformaContratoDatos2 : DataDynamics.ActiveReports.ActiveReport3
{
    private DataDynamics.ActiveReports.Detail detail;
    private Shape shape1;
    private Shape shape2;
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
    private TextBox textBox15;
    private TextBox textBox16;
    private TextBox textBox17;
    private TextBox textBox18;
    private TextBox textBox19;
    private TextBox textBox20;
    private TextBox textBox21;
    private TextBox textBox22;
    private TextBox textBox23;
    private TextBox textBox24;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;

	public srpt_proformaContratoDatos2()
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
    private void srpt_proformaContratoDatos2_ReportStart(object sender, EventArgs e)
    {
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
        textBox1.ClassName = "estiloEncabEnun";
        textBox2.ClassName = "estiloEncabEnun";
        textBox3.ClassName = "estiloEncabEnun";
        textBox4.ClassName = "estiloEncabEnun";
        textBox5.ClassName = "estiloEncabEnun";
        textBox6.ClassName = "estiloEncabEnun";
        textBox7.ClassName = "estiloEncabEnun";
        textBox8.ClassName = "estiloEncabEnun";
        textBox9.ClassName = "estiloEncabEnun";
        textBox10.ClassName = "estiloEncabEnun";
        textBox11.ClassName = "estiloEncabEnun";
        textBox12.ClassName = "estiloEncabEnun";
        textBox13.ClassName = "estiloEncabDato";
        textBox14.ClassName = "estiloEncabDato";
        textBox15.ClassName = "estiloEncabDato";
        textBox16.ClassName = "estiloEncabDato";
        textBox17.ClassName = "estiloEncabDato";
        textBox18.ClassName = "estiloEncabDato";
        textBox19.ClassName = "estiloEncabDato";
        textBox20.ClassName = "estiloEncabDato";
        textBox21.ClassName = "estiloEncabDato";
        textBox22.ClassName = "estiloEncabDato";
        textBox23.ClassName = "estiloEncabDato";
        textBox24.ClassName = "estiloEncabDato";
        label1.ClassName = "estiloEncabDato";
        label2.ClassName = "estiloEncabDato";
        label3.ClassName = "estiloEncabDato";
        label4.ClassName = "estiloEncabDato";
    }
    public void LlenarDatos(int Id_contrato)
    {
        terrasur.contrato c = new terrasur.contrato(Id_contrato);
        terrasur.pago p = new terrasur.pago(c.id_ultimo_pago);
        tipo_cambio tc = new tipo_cambio(tipo_cambio.Actual());
        terrasur.plan_pago pp = new terrasur.plan_pago(c.id_planpago_vigente);

        label1.Text = "(" + c.codigo_moneda + ")";
        label2.Text = "(" + c.codigo_moneda + ")";
        label3.Text = "(" + c.codigo_moneda + ")";
        label4.Text = "(" + c.codigo_moneda + ")";

        textBox13.Text = c.precio.ToString("F2");
        textBox14.Text = (c.descuento_efectivo + ((c.descuento_porcentaje / 100) * c.precio)).ToString("F2");
        textBox15.Text = terrasur.liquidacion.DescuentoDpr(Id_contrato).ToString("F2");
        textBox16.Text = (Decimal.Parse(textBox13.Text) - Decimal.Parse(textBox14.Text) - Decimal.Parse(textBox15.Text)).ToString("F2");
        textBox17.Text = tc.compra.ToString("F2");
        textBox18.Text = tc.venta.ToString("F2");

        textBox19.Text = c.fecha.ToString("d");
        textBox20.Text = p.fecha.ToString("d");
        textBox21.Text = terrasur.logica.AñosContrato(c.fecha, p.fecha).ToString();
        textBox22.Text = DateTime.Now.ToString("d");
        textBox23.Text = terrasur.logica.MesesContrato(c.fecha).ToString();

        textBox12.Text = "Cuota de mantenimiento (" + c.codigo_moneda + "):";
        textBox24.Text = pp.mantenimiento_sus.ToString("F2");
    }
	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        string resourceFileName = "srpt_proformaContratoDatos2.resx";
        System.Resources.ResourceManager resources = Resources.srpt_proformaContratoDatos2.ResourceManager;
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.shape2 = new DataDynamics.ActiveReports.Shape();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.textBox17 = new DataDynamics.ActiveReports.TextBox();
        this.textBox18 = new DataDynamics.ActiveReports.TextBox();
        this.textBox19 = new DataDynamics.ActiveReports.TextBox();
        this.textBox20 = new DataDynamics.ActiveReports.TextBox();
        this.textBox21 = new DataDynamics.ActiveReports.TextBox();
        this.textBox22 = new DataDynamics.ActiveReports.TextBox();
        this.textBox23 = new DataDynamics.ActiveReports.TextBox();
        this.textBox24 = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.shape2,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.label1,
            this.label2,
            this.label3,
            this.label4});
        this.detail.Height = 1.9375F;
        this.detail.Name = "detail";
        // 
        // shape1
        // 
        this.shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape1.Location = ((System.Drawing.PointF)(resources.GetObject("shape1.Location")));
        this.shape1.Name = "shape1";
        this.shape1.Size = new System.Drawing.SizeF(3.1875F, 1.9375F);
        // 
        // shape2
        // 
        this.shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.shape2.Location = ((System.Drawing.PointF)(resources.GetObject("shape2.Location")));
        this.shape2.Name = "shape2";
        this.shape2.Size = new System.Drawing.SizeF(3.1875F, 1.9375F);
        // 
        // textBox1
        // 
        this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox1.DistinctField = null;
        this.textBox1.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = null;
        this.textBox1.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox1.Text = "Precio Real del lote:";
        // 
        // textBox2
        // 
        this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox2.DistinctField = null;
        this.textBox2.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = null;
        this.textBox2.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox2.Text = "Descuentos (venta):";
        // 
        // textBox3
        // 
        this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox3.DistinctField = null;
        this.textBox3.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = null;
        this.textBox3.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox3.Text = "Descuentos (DPR\'s)";
        // 
        // textBox4
        // 
        this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox4.DistinctField = null;
        this.textBox4.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
        this.textBox4.Name = "textBox4";
        this.textBox4.OutputFormat = null;
        this.textBox4.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox4.Text = "Precio Lote (Liquidable)";
        // 
        // textBox5
        // 
        this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox5.DistinctField = null;
        this.textBox5.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
        this.textBox5.Name = "textBox5";
        this.textBox5.OutputFormat = null;
        this.textBox5.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox5.Text = "T.C. compra:";
        // 
        // textBox6
        // 
        this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox6.DistinctField = null;
        this.textBox6.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
        this.textBox6.Name = "textBox6";
        this.textBox6.OutputFormat = null;
        this.textBox6.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox6.Text = "T.C. venta:";
        // 
        // textBox7
        // 
        this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox7.DistinctField = null;
        this.textBox7.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox7.Location = ((System.Drawing.PointF)(resources.GetObject("textBox7.Location")));
        this.textBox7.Name = "textBox7";
        this.textBox7.OutputFormat = null;
        this.textBox7.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox7.Text = "Fecha de compra:";
        // 
        // textBox8
        // 
        this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox8.DistinctField = null;
        this.textBox8.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox8.Location = ((System.Drawing.PointF)(resources.GetObject("textBox8.Location")));
        this.textBox8.Name = "textBox8";
        this.textBox8.OutputFormat = null;
        this.textBox8.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox8.Text = "Fecha de Pago Final:";
        // 
        // textBox9
        // 
        this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox9.DistinctField = null;
        this.textBox9.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox9.Location = ((System.Drawing.PointF)(resources.GetObject("textBox9.Location")));
        this.textBox9.Name = "textBox9";
        this.textBox9.OutputFormat = null;
        this.textBox9.Size = new System.Drawing.SizeF(1.5625F, 0.3125F);
        this.textBox9.Text = "Tiempo de contrato en años:";
        // 
        // textBox10
        // 
        this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox10.DistinctField = null;
        this.textBox10.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox10.Location = ((System.Drawing.PointF)(resources.GetObject("textBox10.Location")));
        this.textBox10.Name = "textBox10";
        this.textBox10.OutputFormat = null;
        this.textBox10.Size = new System.Drawing.SizeF(1.5625F, 0.1875F);
        this.textBox10.Text = "Fecha Actual:";
        // 
        // textBox11
        // 
        this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox11.DistinctField = null;
        this.textBox11.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox11.Location = ((System.Drawing.PointF)(resources.GetObject("textBox11.Location")));
        this.textBox11.Name = "textBox11";
        this.textBox11.OutputFormat = null;
        this.textBox11.Size = new System.Drawing.SizeF(1.5625F, 0.3125F);
        this.textBox11.Text = "Tiempo hasta fecha actual en meses:";
        // 
        // textBox12
        // 
        this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox12.DistinctField = null;
        this.textBox12.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox12.Location = ((System.Drawing.PointF)(resources.GetObject("textBox12.Location")));
        this.textBox12.Name = "textBox12";
        this.textBox12.OutputFormat = null;
        this.textBox12.Size = new System.Drawing.SizeF(1.5625F, 0.3125F);
        this.textBox12.Text = "Cuota de mantenimiento ($us):";
        // 
        // textBox13
        // 
        this.textBox13.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox13.DistinctField = null;
        this.textBox13.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox13.Location = ((System.Drawing.PointF)(resources.GetObject("textBox13.Location")));
        this.textBox13.Name = "textBox13";
        this.textBox13.OutputFormat = null;
        this.textBox13.Size = new System.Drawing.SizeF(1F, 0.1875F);
        // 
        // textBox14
        // 
        this.textBox14.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox14.DistinctField = null;
        this.textBox14.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox14.Location = ((System.Drawing.PointF)(resources.GetObject("textBox14.Location")));
        this.textBox14.Name = "textBox14";
        this.textBox14.OutputFormat = null;
        this.textBox14.Size = new System.Drawing.SizeF(1F, 0.1875F);
        // 
        // textBox15
        // 
        this.textBox15.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox15.DistinctField = null;
        this.textBox15.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox15.Location = ((System.Drawing.PointF)(resources.GetObject("textBox15.Location")));
        this.textBox15.Name = "textBox15";
        this.textBox15.OutputFormat = null;
        this.textBox15.Size = new System.Drawing.SizeF(1F, 0.1875F);
        // 
        // textBox16
        // 
        this.textBox16.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox16.DistinctField = null;
        this.textBox16.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox16.Location = ((System.Drawing.PointF)(resources.GetObject("textBox16.Location")));
        this.textBox16.Name = "textBox16";
        this.textBox16.OutputFormat = null;
        this.textBox16.Size = new System.Drawing.SizeF(1F, 0.1875F);
        // 
        // textBox17
        // 
        this.textBox17.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox17.DistinctField = null;
        this.textBox17.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox17.Location = ((System.Drawing.PointF)(resources.GetObject("textBox17.Location")));
        this.textBox17.Name = "textBox17";
        this.textBox17.OutputFormat = null;
        this.textBox17.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox18
        // 
        this.textBox18.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox18.DistinctField = null;
        this.textBox18.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox18.Location = ((System.Drawing.PointF)(resources.GetObject("textBox18.Location")));
        this.textBox18.Name = "textBox18";
        this.textBox18.OutputFormat = null;
        this.textBox18.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox19
        // 
        this.textBox19.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox19.DistinctField = null;
        this.textBox19.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox19.Location = ((System.Drawing.PointF)(resources.GetObject("textBox19.Location")));
        this.textBox19.Name = "textBox19";
        this.textBox19.OutputFormat = null;
        this.textBox19.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox20
        // 
        this.textBox20.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox20.DistinctField = null;
        this.textBox20.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox20.Location = ((System.Drawing.PointF)(resources.GetObject("textBox20.Location")));
        this.textBox20.Name = "textBox20";
        this.textBox20.OutputFormat = null;
        this.textBox20.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox21
        // 
        this.textBox21.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox21.DistinctField = null;
        this.textBox21.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox21.Location = ((System.Drawing.PointF)(resources.GetObject("textBox21.Location")));
        this.textBox21.Name = "textBox21";
        this.textBox21.OutputFormat = null;
        this.textBox21.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox22
        // 
        this.textBox22.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox22.DistinctField = null;
        this.textBox22.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox22.Location = ((System.Drawing.PointF)(resources.GetObject("textBox22.Location")));
        this.textBox22.Name = "textBox22";
        this.textBox22.OutputFormat = null;
        this.textBox22.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox23
        // 
        this.textBox23.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox23.DistinctField = null;
        this.textBox23.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox23.Location = ((System.Drawing.PointF)(resources.GetObject("textBox23.Location")));
        this.textBox23.Name = "textBox23";
        this.textBox23.OutputFormat = null;
        this.textBox23.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // textBox24
        // 
        this.textBox24.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
        this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.textBox24.DistinctField = null;
        this.textBox24.Font = new System.Drawing.Font("Arial", 10F);
        this.textBox24.Location = ((System.Drawing.PointF)(resources.GetObject("textBox24.Location")));
        this.textBox24.Name = "textBox24";
        this.textBox24.OutputFormat = null;
        this.textBox24.Size = new System.Drawing.SizeF(1F, 0.1979167F);
        // 
        // label1
        // 
        this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label1.Font = new System.Drawing.Font("Arial", 10F);
        this.label1.HyperLink = null;
        this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.label1.Text = "($us)";
        // 
        // label2
        // 
        this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label2.Font = new System.Drawing.Font("Arial", 10F);
        this.label2.HyperLink = null;
        this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.label2.Text = "($us)";
        // 
        // label3
        // 
        this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label3.Font = new System.Drawing.Font("Arial", 10F);
        this.label3.HyperLink = null;
        this.label3.Location = ((System.Drawing.PointF)(resources.GetObject("label3.Location")));
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.label3.Text = "($us)";
        // 
        // label4
        // 
        this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
        this.label4.Font = new System.Drawing.Font("Arial", 10F);
        this.label4.HyperLink = null;
        this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.SizeF(0.4375F, 0.1875F);
        this.label4.Text = "($us)";
        // 
        // srpt_proformaContratoDatos2
        // 
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.53125F;
        this.Sections.Add(this.detail);
        this.ReportStart += new System.EventHandler(this.srpt_proformaContratoDatos2_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();

	}
	#endregion

    
}
