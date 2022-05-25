using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;       
     
/// <summary>
/// Summary description for cajaComprobanteDprMaestro.
/// </summary>
/// 
namespace terrasur
{
    public class cajaComprobanteDprMaestro : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private SubReport subReport1;
        private TextBox textBox1;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private SubReport subReport2;
        private TextBox textBox12;
        private TextBox textBox11;
        public TextBox textBox38;
        private TextBox textBox40;
        private TextBox textBox41;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox textBox44;
        private TextBox textBox39;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private Shape shape1;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaComprobanteDprMaestro()
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
        private void cajaComprobanteDprMaestro_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("Comprobante", 850, 550);
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.Margins.Bottom = 0.0F;
            this.PageSettings.Margins.Right = 0.0F;
            this.PageSettings.Margins.Left = 0.4F;

            //ESTILOS
            EstilosBase rpt = new EstilosBase();
            string filepath = HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBaseComprobante.rpx";
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
        private void cajaComprobanteDprMaestro_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
            string codigo_tp = transaccion.CodigoTipoPago(Convert.ToInt32(Fields["id_transaccion"].Value));
            int id_comprobantedpr = 0;
            if (Convert.ToInt32(Fields["id_comprobantedpr"].Value) > 0)
                id_comprobantedpr = Convert.ToInt32(Fields["id_comprobantedpr"].Value);
            else
                id_comprobantedpr = comprobante_dpr.IdPorTransaccion(Convert.ToInt32(Fields["id_transaccion"].Value));
            
             comprobante_dpr cmp = new comprobante_dpr(id_comprobantedpr, 0);
            //ENCABEZADO
            //string dir_imagen = HttpRuntime.AppDomainAppPath + "/Images/" + r.nit.ToString() + ".gif";
            //System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(dir_imagen);
            //this.picture1.Image = imgPhoto;
            //this.picture1.LineWeight = 0F;
            //this.picture1.Name = "picture1";
            //this.picture1.Size = new System.Drawing.SizeF(0.9375F, 0.3125F);
            textBox39.Text = cmp.encabezado_empresa.ToString();
            textBox40.Text = cmp.encabezado_actividad.ToString();
            textBox41.Text = "CASA MATRIZ";
            textBox42.Text = cmp.encabezado_direccion.ToString();
            textBox43.Text = cmp.encabezado_telefono.ToString();
            textBox44.Text = cmp.encabezado_lugar.ToString();
            
            //Sucursales:
            sucursal sObj = new sucursal(sucursal.IdSucursalPorIdDocumento(0, 0, id_comprobantedpr), 0);
            if (sObj.num_sucursal == 0) textBox18.Text = sObj.nombre;
            else textBox18.Text = sObj.num_sucursal.ToString() + " - " + sObj.nombre;

            textBox2.Text = cmp.num_comprobante.ToString();
            textBox7.Text = cmp.nombre_cliente;
            textBox8.Text = new dpr(new forma_pago(Convert.ToInt32(Fields["id_transaccion"].Value)).dpr_id_dpr).nombre.ToString();

            textBox6.Text = "DPR " + cmp.codigo_moneda + ":";
            if (cmp.codigo_moneda == "$us") { textBox11.Text = cmp.monto_sus.ToString("F2") + " son: (" + Conversiones.enletras(cmp.monto_sus.ToString()) + " DOLARES AMERICANOS)"; }
            else { textBox11.Text = cmp.monto_sus.ToString("F2") + " son: (" + Conversiones.enletras(cmp.monto_sus.ToString()) + " BOLIVIANOS)"; }

            textBox10.Text = cmp.fecha.ToString("D");

            textBox14.Text = cmp.codigo_moneda + ":";
            textBox13.Text = cmp.monto_sus.ToString("F2");

            textBox16.Text = new tipo_cambio(tipo_cambio.Anterior(cmp.fecha)).compra.ToString("F2");
            switch (codigo_tp)
            {
                case "ini":
                    PagoComprobanteConcepto pic = new PagoComprobanteConcepto();
                    pic.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value), id_comprobantedpr);
                    subReport1.Report = pic;
                    PagoInicialComprobanteDetalle pid = new PagoInicialComprobanteDetalle();
                    pid.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value));
                    subReport2.Report = pid;
                    textBox12.Visible = true;
                    break;
                case "cuo":
                case "ade":
                case "pla":
                    PagoComprobanteConcepto pic1 = new PagoComprobanteConcepto();
                    pic1.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value), id_comprobantedpr);
                    subReport1.Report = pic1;
                    PagoComprobanteDetalle pcd = new PagoComprobanteDetalle();
                    pcd.CargarDatos(cmp.codigo_moneda);
                    pcd.DataSource = pago.Lista_PagoNormalParaDocumentos(Convert.ToInt32(Fields["id_transaccion"].Value));
                    subReport2.Report = pcd;
                    textBox12.Visible = true;
                    break;
                case "cap":
                    PagoComprobanteConcepto pic2 = new PagoComprobanteConcepto();
                    pic2.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value), id_comprobantedpr);
                    subReport1.Report = pic2;
                    PagoCapitalComprobanteDetalle pdcd = new PagoCapitalComprobanteDetalle();
                    pdcd.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value));
                    subReport2.Report = pdcd;
                    textBox12.Visible = true;
                    break;
                case "OtroServicio":
                    PagoComprobanteConcepto pic3 = new PagoComprobanteConcepto();
                    pic3.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value), id_comprobantedpr);
                    subReport1.Report = pic3;
                    subReport2.Dispose();
                    textBox12.Visible = false;
                    break;
                case "OtroServicioNoCliente":
                    OtroServNoClienteComprobanteConcepto osnc = new OtroServNoClienteComprobanteConcepto();
                    osnc.LlenarDatos(id_comprobantedpr);
                    subReport1.Report = osnc;
                    subReport2.Dispose();
                    textBox12.Visible = false;
                    break;
                case "PagoMora":
                    PagoComprobanteConcepto pic4 = new PagoComprobanteConcepto();
                    pic4.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value), id_comprobantedpr);
                    subReport1.Report = pic4;
                    PagoMoraComprobanteDetalle pmd = new PagoMoraComprobanteDetalle();
                    pmd.LlenarDatos(Convert.ToInt32(Fields["id_transaccion"].Value));
                    subReport2.Report = pmd;
                    textBox12.Visible = true;
                    break;
                default:
                    break;
            }


            //Se ocultan algunos espacios en e recibos de casas
            //bool es_terreno = true;
            //if (cmp.encabezado_actividad == "." && cmp.encabezado_direccion == "." && cmp.encabezado_telefono == "." && cmp.encabezado_lugar == ".") es_terreno = false;

            bool es_terreno = false;
            if (cmp.encabezado_empresa.ToUpper().Contains("TERRASUR") == true || cmp.encabezado_empresa.ToUpper().Contains("BBR") == true) es_terreno = true;

            if (es_terreno == false)
            {
                //Se oculta el encabezado
                textBox40.Text = "";
                textBox41.Text = "";
                textBox42.Text = "";
                textBox43.Text = "";
                textBox44.Text = "";
            }

        }
        public void CargarEstilos()
        {
            //ENCABEZADO
            textBox39.ClassName = "comprobanteEncabezadoEmpresa";
            textBox40.ClassName = "comprobanteEncabezadoActividad";
            textBox41.ClassName = "comprobanteEncabezadoCasaMatriz";
            textBox42.ClassName = "comprobanteEncabezadoDireccion";
            textBox43.ClassName = "comprobanteEncabezadoTelefono";
            textBox44.ClassName = "comprobanteEncabezadoLugar";
            //

            textBox1.ClassName = "comprobanteTituloEnun";
            textBox2.ClassName = "comprobanteTituloDato";

            textBox3.ClassName = "comprobanteConceptoEnun";
            textBox4.ClassName = "comprobanteConceptoEnun";
            textBox5.ClassName = "comprobanteConceptoEnun";
            textBox6.ClassName = "comprobanteConceptoEnun";
            textBox7.ClassName = "comprobanteConceptoDato";
            textBox8.ClassName = "comprobanteConceptoDato";

            //Sucursales
            textBox17.ClassName = "comprobanteConceptoEnun";
            textBox18.ClassName = "comprobanteConceptoDato";

            textBox9.ClassName = "comprobanteFecha";
            textBox10.ClassName = "comprobanteFecha";

            textBox11.ClassName = "comprobanteConceptoDato";
            textBox12.ClassName = "comprobanteDetalleEnun";

            textBox14.ClassName = "comprobanteDetalleEnun";
            textBox13.ClassName = "comprobanteDetalleDato";
            textBox15.ClassName = "comprobanteDetalleEnun";
            textBox16.ClassName = "comprobanteDetalleDato";

            textBox38.ClassName = "comprobanteNota";
        }
        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaComprobanteDprMaestro));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.subReport2 = new DataDynamics.ActiveReports.SubReport();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport2,
            this.textBox12});
            this.detail.Height = 0.34375F;
            this.detail.Name = "detail";
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
            this.subReport2.Left = 0.3125F;
            this.subReport2.Name = "subReport2";
            this.subReport2.Report = null;
            this.subReport2.ReportName = "subReport1";
            this.subReport2.Top = 0.25F;
            this.subReport2.Width = 7.1875F;
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
            this.textBox12.Left = 0.3125F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "";
            this.textBox12.Text = "Observaciones:";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 1.5625F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.textBox1,
            this.textBox9,
            this.textBox10,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox11,
            this.textBox38,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox39,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.shape1,
            this.textBox16,
            this.textBox17,
            this.textBox18});
            this.groupHeader1.DataField = "id_transaccion";
            this.groupHeader1.Height = 2.625F;
            this.groupHeader1.Name = "groupHeader1";
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
            this.subReport1.Height = 0.5625F;
            this.subReport1.Left = 0.3125F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 2.0625F;
            this.subReport1.Width = 7.1875F;
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
            this.textBox1.Left = 2.1875F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "";
            this.textBox1.Text = "COMPROBANTE DPR:";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 2.0625F;
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
            this.textBox9.Left = 1.3125F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "";
            this.textBox9.Text = "La Paz,";
            this.textBox9.Top = 1.0625F;
            this.textBox9.Width = 0.875F;
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
            this.textBox10.Left = 2.1875F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "";
            this.textBox10.Text = null;
            this.textBox10.Top = 1.0625F;
            this.textBox10.Width = 5.125F;
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
            this.textBox2.Height = 0.1979167F;
            this.textBox2.Left = 4.25F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "";
            this.textBox2.Text = null;
            this.textBox2.Top = 0F;
            this.textBox2.Width = 1F;
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
            this.textBox3.Left = 0.3125F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "";
            this.textBox3.Text = "Fecha:";
            this.textBox3.Top = 1.0625F;
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
            this.textBox4.Height = 0.1979167F;
            this.textBox4.Left = 0.3125F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "";
            this.textBox4.Text = "Cliente:";
            this.textBox4.Top = 1.3125F;
            this.textBox4.Width = 1F;
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
            this.textBox5.Height = 0.1979167F;
            this.textBox5.Left = 0.3125F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "";
            this.textBox5.Text = "DPR:";
            this.textBox5.Top = 1.5625F;
            this.textBox5.Width = 1F;
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
            this.textBox6.Height = 0.1979167F;
            this.textBox6.Left = 0.3125F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "";
            this.textBox6.Text = "DPR $us:";
            this.textBox6.Top = 1.8125F;
            this.textBox6.Width = 1F;
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
            this.textBox7.Left = 1.3125F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "";
            this.textBox7.Text = null;
            this.textBox7.Top = 1.3125F;
            this.textBox7.Width = 6F;
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
            this.textBox8.Left = 1.3125F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "";
            this.textBox8.Text = null;
            this.textBox8.Top = 1.5625F;
            this.textBox8.Width = 6F;
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
            this.textBox11.Left = 1.3125F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "";
            this.textBox11.Text = null;
            this.textBox11.Top = 1.8125F;
            this.textBox11.Width = 6F;
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
            this.textBox38.Left = 6.5F;
            this.textBox38.Name = "textBox38";
            this.textBox38.Style = "";
            this.textBox38.Text = "Reimpresión";
            this.textBox38.Top = 0.25F;
            this.textBox38.Visible = false;
            this.textBox38.Width = 1F;
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
            this.textBox40.Height = 0.06F;
            this.textBox40.Left = 0F;
            this.textBox40.Name = "textBox40";
            this.textBox40.Style = "";
            this.textBox40.Text = null;
            this.textBox40.Top = 0.535F;
            this.textBox40.Width = 1.88F;
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
            this.textBox41.Height = 0.06F;
            this.textBox41.Left = 0F;
            this.textBox41.Name = "textBox41";
            this.textBox41.Style = "";
            this.textBox41.Text = null;
            this.textBox41.Top = 0.63F;
            this.textBox41.Width = 1.88F;
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
            this.textBox42.Height = 0.06F;
            this.textBox42.Left = 0F;
            this.textBox42.Name = "textBox42";
            this.textBox42.Style = "";
            this.textBox42.Text = null;
            this.textBox42.Top = 0.73F;
            this.textBox42.Width = 1.88F;
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
            this.textBox43.Height = 0.06F;
            this.textBox43.Left = 0F;
            this.textBox43.Name = "textBox43";
            this.textBox43.Style = "";
            this.textBox43.Text = null;
            this.textBox43.Top = 0.83F;
            this.textBox43.Width = 1.88F;
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
            this.textBox44.Height = 0.06F;
            this.textBox44.Left = 0F;
            this.textBox44.Name = "textBox44";
            this.textBox44.Style = "";
            this.textBox44.Text = null;
            this.textBox44.Top = 0.938F;
            this.textBox44.Width = 1.88F;
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
            this.textBox39.Height = 0.13F;
            this.textBox39.Left = 0F;
            this.textBox39.Name = "textBox39";
            this.textBox39.Style = "";
            this.textBox39.Text = null;
            this.textBox39.Top = 0.375F;
            this.textBox39.Width = 1.88F;
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
            this.textBox13.Left = 6.875F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "";
            this.textBox13.Text = null;
            this.textBox13.Top = 0.625F;
            this.textBox13.Width = 0.5625F;
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
            this.textBox14.Left = 6.375F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "";
            this.textBox14.Text = "$us:";
            this.textBox14.Top = 0.625F;
            this.textBox14.Width = 0.5F;
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
            this.textBox15.Left = 6.375F;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "";
            this.textBox15.Text = "T/C:";
            this.textBox15.Top = 0.875F;
            this.textBox15.Width = 0.5F;
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
            this.shape1.Height = 0.625F;
            this.shape1.Left = 6.3125F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape1.Top = 0.5F;
            this.shape1.Width = 1.1875F;
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
            this.textBox16.Left = 6.875F;
            this.textBox16.Name = "textBox16";
            this.textBox16.Style = "";
            this.textBox16.Text = null;
            this.textBox16.Top = 0.875F;
            this.textBox16.Width = 0.5625F;
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
            this.textBox17.Height = 0.1875F;
            this.textBox17.Left = 2.1875F;
            this.textBox17.Name = "textBox17";
            this.textBox17.Style = "";
            this.textBox17.Text = "Sucursal:";
            this.textBox17.Top = 0.375F;
            this.textBox17.Width = 0.875F;
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
            this.textBox18.Left = 3.0625F;
            this.textBox18.Name = "textBox18";
            this.textBox18.Style = "";
            this.textBox18.Text = "textBox18";
            this.textBox18.Top = 0.375F;
            this.textBox18.Width = 2.1875F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.PrintAtBottom = true;
            // 
            // cajaComprobanteDprMaestro
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 5.5F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.53125F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaComprobanteDprMaestro_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaComprobanteDprMaestro_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

    }
}