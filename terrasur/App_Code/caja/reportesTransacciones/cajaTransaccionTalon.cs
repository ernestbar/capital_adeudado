using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionTalon.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionTalon : DataDynamics.ActiveReports.ActiveReport3
    {
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
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox13;
        private TextBox textBox14;
        private Shape shape1;
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
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox28;
        private TextBox textBox29;
        private TextBox textBox31;
        private TextBox textBox32;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox38;
        private TextBox textBox52;
        private TextBox textBox53;
        private TextBox textBox54;
        private TextBox textBox33;
        private Shape shape2;
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
        private TextBox textBox51;
        private TextBox textBox57;
        private TextBox textBox59;
        private TextBox textBox61;
        private Shape shape5;
        private Shape shape4;
        private TextBox textBox77;
        private TextBox textBox78;
        private Shape shape6;
        private TextBox textBox12;
        private TextBox textBox30;
        private Line line1;
        private TextBox textBox50;
        private TextBox textBox55;
        private TextBox textBox56;
        private TextBox textBox58;
        private TextBox textBox60;
        private TextBox textBox62;
        private TextBox textBox63;
        private TextBox textBox64;
        private TextBox textBox65;
        private TextBox textBox66;
        private TextBox textBox67;
        private TextBox textBox68;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionTalon()
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

        private void cajaTransaccionTalon_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionTalon", 850, 293);
            this.PageSettings.Margins.Top = 0.0F;
            this.PageSettings.Margins.Bottom = 0.0F;
            this.PageSettings.Margins.Right = 0.0F;
            this.PageSettings.Margins.Left = 0.0F;

            //ESTILOS
            /*
            EstilosBase rpt = new EstilosBase();
            string filepath = HttpRuntime.AppDomainAppPath + "/App_Data/EstilosBaseFactura.rpx";
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
            */
        }

        public void CargarDatos
            (
                bool reimpresion,int id_usuario_impresion,
                int id_transaccion, int t_id_usuario, DateTime t_fecha, string t_codigo_moneda, decimal t_monto, decimal t_tipo_cambio, string t_usuario, int t_num_recibo_cobrador, string t_negocio_nombre, bool t_anulado,
                string su_nombre, int su_numero,
                bool fp_dpr, decimal fp_dpr_monto, string fp_dpr_concepto, decimal fp_efectivo_sus, decimal fp_efectivo_bs, decimal fp_tarjeta_sus, decimal fp_tarjeta_bs, string fp_tarjeta_numero, decimal fp_cheque_sus, decimal fp_cheque_bs, string fp_cheque_numero, string fp_cheque_banco, decimal fp_deposito_sus, decimal fp_deposito_bs,
                int id_contrato, string co_numero, string co_descripcion, string co_promotor,
                int id_pago, int pa_num_pago, int pa_num_cuotas, DateTime pa_fecha_pago, DateTime pa_fecha_interes, decimal pa_monto_pago, decimal pa_seguro, decimal pa_mantenimiento, decimal pa_interes, decimal pa_capital, decimal pa_saldo,
                int id_serviciovendido, 
                int tp_id_contrato, string tp_num_contrato, string tp_titular, DateTime tp_fecha_inicial, DateTime tp_fecha_final, int tp_num_meses,
                int id_recibo, int r_num_recibo, string r_concepto, string r_cliente,
                int id_comprobantedpr, int cd_num_comprobante, string cd_concepto, string cd_cliente,
                int id_factura, string f_razon_social, decimal f_nit, decimal f_num_autorizacion, DateTime f_fecha_limite, string f_encabezado,
                int f_num_factura, DateTime f_fecha, string f_cliente_nombre, decimal f_cliente_nit, string f_concepto, decimal f_monto_bs, decimal f_tipo_cambio, string f_numero_control, bool f_anulado
            )
        {
            textBox1.Text = t_negocio_nombre;
            textBox2.Text = su_numero.ToString() + " - " + su_nombre;
            textBox55.Text = t_tipo_cambio.ToString("N2");
            textBox3.Text = t_fecha.ToString() + " (" + t_usuario + ")";
            textBox4.Text = t_codigo_moneda + " " + t_monto.ToString("N2");
            if (t_anulado == true) { textBox58.Text = "Anulado"; } else { textBox58.Text = "Vigente"; }

            if (id_recibo > 0)
            {
                textBox15.Text = "Nº recibo:"; 
                textBox6.Text = r_num_recibo.ToString();
            }
            else if (id_comprobantedpr > 0)
            {
                textBox15.Text = "Nº comprobante DPR:";
                textBox6.Text = cd_num_comprobante.ToString();
            }
            else
            {
                textBox15.Text = "Nº recibo:"; 
                textBox6.Text = "---";
            }
            if (t_num_recibo_cobrador > 0) { textBox8.Text = t_num_recibo_cobrador.ToString(); }
            else { textBox8.Text = "---"; }

            if (tp_id_contrato > 0) { textBox5.Text = "Pago TerraPlus"; }
            else if (id_pago > 0) { textBox5.Text = "Pago sobre contrato"; }
            else if (id_serviciovendido > 0)
            {
                if (id_contrato > 0) { textBox5.Text = "Servicio a cliente con ctto."; }
                else { textBox5.Text = "Servicio a cliente transitorio"; }

            }
            else { textBox5.Text = ""; }

            if (id_factura > 0)
            {
                textBox60.Text = "Razón Social:";
                textBox62.Text = f_razon_social;
                if (f_anulado == true) { textBox68.Text = "(Anulada)"; } else { textBox68.Text = "(Vigente)"; }
                textBox66.Text = "Fecha:";
                textBox67.Text = f_fecha.ToString("d");
                textBox25.Text = "Nº factura:";
                textBox7.Text = f_num_factura.ToString();
                textBox21.Text = "NIT:";
                textBox11.Text = f_nit.ToString();
                textBox19.Text = "Nº autoriz.:";
                textBox13.Text = f_num_autorizacion.ToString();
                textBox23.Text = "F. Límite:";
                textBox20.Text = f_fecha_limite.ToString("d");

                textBox16.Text = "Cliente NIT:";
                textBox9.Text = f_cliente_nit.ToString();
                textBox78.Text = "Cli. Nombre:";
                textBox17.Text = f_cliente_nombre;
                textBox26.Text = "Monto Bs:";
                textBox18.Text = f_monto_bs.ToString("N2");
                textBox24.Text = "Cod.Control:";
                textBox32.Text = f_numero_control;

                shape4.Visible = true;
            }
            else
            {
                textBox60.Text = "";
                textBox62.Text = "";
                textBox68.Text = "";
                textBox66.Text = "";
                textBox67.Text = "";
                textBox25.Text = "";
                textBox7.Text = "";
                textBox21.Text = "";
                textBox11.Text = "";
                textBox19.Text = "";
                textBox13.Text = "";
                textBox23.Text = "";
                textBox20.Text = "";

                textBox16.Text = "";
                textBox9.Text = "";
                textBox78.Text = "";
                textBox17.Text = "";
                textBox26.Text = "";
                textBox18.Text = "";
                textBox24.Text = "";
                textBox32.Text = "";

                shape4.Visible = false;
            }

            //int tp_id_contrato, string tp_num_contrato, string tp_titular, DateTime tp_fecha_inicial, DateTime tp_fecha_final, int tp_num_meses
            if (tp_id_contrato > 0)
            {
                textBox54.Text = "Titular ctto.:";
                textBox36.Text = tp_titular;

                textBox22.Text = "Ctto. TerraPlus:";
                textBox38.Text = tp_num_contrato.ToString();

                textBox27.Text = "";
                textBox40.Text = "";

                textBox31.Text = "Concepto:";
                textBox39.Text = "Pago(s) del plan TerraPlus";

                textBox28.Text = "Mes(es):";
                string tp_detalle_meses = terrasur.terraplus.tp_pago.StringMes(tp_fecha_inicial, tp_fecha_final);
                if (tp_num_meses > 1) { tp_detalle_meses = tp_detalle_meses + " (" + tp_num_meses.ToString() + " meses)"; }
                textBox41.Text = tp_detalle_meses;
            }
            else
            {
                textBox54.Text = "Cliente:";
                if (id_recibo > 0) { textBox36.Text = r_cliente; }
                else if (id_comprobantedpr > 0) { textBox36.Text = cd_cliente; }
                else { textBox36.Text = ""; }

                textBox22.Text = "Nº contrato:";
                if (id_contrato > 0) { textBox38.Text = co_numero; }
                else { textBox38.Text = "---"; }

                if (id_contrato > 0 && co_promotor != "")
                {
                    textBox27.Text = "Asesor vent.:";
                    textBox40.Text = co_promotor;
                }
                else { textBox27.Text = ""; textBox40.Text = ""; }

                textBox31.Text = "Lote/Servicio:";
                textBox39.Text = co_descripcion;

                textBox28.Text = "Concepto:";
                if (id_recibo > 0) { textBox41.Text = r_concepto; }
                else if (id_comprobantedpr > 0) { textBox41.Text = cd_concepto; }
                else { textBox41.Text = ""; }
            }

            if (id_pago > 0)
            {
                string cod_moneda = ""; if (t_codigo_moneda == "Bs") { cod_moneda = "Bs"; } else { cod_moneda = "$"; }

                textBox29.Text = "Nº";
                textBox33.Text = "F.Interés";
                textBox35.Text = "Pago (" + cod_moneda + ")";
                textBox37.Text = "Seg.(" + cod_moneda + ")";
                textBox34.Text = "Mant.(" + cod_moneda + ")";
                textBox48.Text = "Interés (" + cod_moneda + ")";
                textBox49.Text = "Capital (" + cod_moneda + ")";
                textBox51.Text = "Saldo (" + cod_moneda + ")";

                textBox42.Text = pa_num_pago.ToString();
                textBox43.Text = pa_fecha_interes.ToString("d");
                textBox44.Text = pa_monto_pago.ToString("F2");
                textBox45.Text = pa_seguro.ToString("F2");
                textBox46.Text = pa_mantenimiento.ToString("F2");
                textBox47.Text = pa_interes.ToString("F2");
                textBox57.Text = pa_capital.ToString("F2");
                textBox59.Text = pa_saldo.ToString("F2");

                //shape6.Visible = true;
            }
            else
            {
                textBox29.Text = "";
                textBox33.Text = "";
                textBox35.Text = "";
                textBox37.Text = "";
                textBox34.Text = "";
                textBox48.Text = "";
                textBox49.Text = "";
                textBox51.Text = "";

                textBox42.Text = "";
                textBox43.Text = "";
                textBox44.Text = "";
                textBox45.Text = "";
                textBox46.Text = "";
                textBox47.Text = "";
                textBox57.Text = "";
                textBox59.Text = "";

                //shape6.Visible = false;
            }

            System.Text.StringBuilder dato_fp = new System.Text.StringBuilder();
            if (fp_dpr == true)
            {
                dato_fp.Append("DPR: " + t_codigo_moneda + " " + fp_dpr_monto.ToString("N2") + " ; " + fp_dpr_concepto);
            }
            else
            {
                if (fp_efectivo_sus > 0 || fp_efectivo_bs > 0)
                {
                    dato_fp.Append("En efectivo: ");
                    if (fp_efectivo_sus > 0) { dato_fp.Append("$us " + fp_efectivo_sus.ToString("N2") + " ; "); }
                    if (fp_efectivo_bs > 0) { dato_fp.Append("Bs " + fp_efectivo_bs.ToString("N2") + " ; "); }
                }
                if (fp_tarjeta_sus > 0 || fp_tarjeta_bs > 0)
                {
                    dato_fp.Append("Con tarjeta: ");
                    if (fp_tarjeta_sus > 0) { dato_fp.Append("$us " + fp_tarjeta_sus.ToString("N2") + " ; "); }
                    if (fp_tarjeta_bs > 0) { dato_fp.Append("Bs " + fp_tarjeta_bs.ToString("N2") + " ; "); }
                    dato_fp.Append("(Nº tarjeta: " + fp_tarjeta_numero + ") ;");
                }
                if (fp_deposito_sus > 0 || fp_deposito_bs > 0)
                {
                    dato_fp.Append("Depósito: ");
                    if (fp_deposito_sus > 0) { dato_fp.Append("$us " + fp_deposito_sus.ToString("N2") + " ; "); }
                    if (fp_deposito_bs > 0) { dato_fp.Append("Bs " + fp_deposito_bs.ToString("N2") + " ; "); }
                }
                if (fp_cheque_sus > 0 || fp_cheque_bs > 0)
                {
                    dato_fp.Append("Con depósito: ");
                    if (fp_cheque_sus > 0) { dato_fp.Append("$us " + fp_cheque_sus.ToString("N2") + " ; "); }
                    if (fp_cheque_bs > 0) { dato_fp.Append("Bs " + fp_cheque_bs.ToString("N2") + " ; "); }
                    dato_fp.Append("(Nº cheque: " + fp_cheque_numero + " del " + fp_cheque_banco + ") ;");
                }
            }
            textBox61.Text = dato_fp.ToString().Trim().TrimEnd(';');

            System.Text.StringBuilder str_datos = new System.Text.StringBuilder();
            str_datos.Append("T" + id_transaccion.ToString());
            str_datos.Append("TU" + t_id_usuario.ToString());
            if (t_codigo_moneda == "Bs") { str_datos.Append("MD2"); } else { str_datos.Append("MD1"); }
            str_datos.Append("MP" + t_monto.ToString("F2").Replace(".", "").Replace(",", ""));
            str_datos.Append("FT" + t_fecha.ToString("yyMMddhhmmss"));
            str_datos.Append("C" + id_contrato.ToString());
            str_datos.Append("P" + id_pago.ToString());
            str_datos.Append("SV" + id_serviciovendido.ToString());
            str_datos.Append("TPC" + tp_id_contrato.ToString());
            str_datos.Append("R" + id_recibo.ToString());
            str_datos.Append("CD" + id_comprobantedpr.ToString());
            str_datos.Append("F" + id_factura.ToString());
            str_datos.Append("IU" + id_usuario_impresion.ToString());
            str_datos.Append("IF" + DateTime.Now.ToString("yyMMddhhmmss"));
            textBox63.Text = str_datos.ToString();

            textBox64.Visible = reimpresion;
            textBox65.Visible = t_anulado;
        }

        private void cajaTransaccionTalon_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
            
        }

        public void CargarEstilos()
        {
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionTalon));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
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
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
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
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.textBox53 = new DataDynamics.ActiveReports.TextBox();
            this.textBox54 = new DataDynamics.ActiveReports.TextBox();
            this.shape2 = new DataDynamics.ActiveReports.Shape();
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
            this.textBox49 = new DataDynamics.ActiveReports.TextBox();
            this.textBox51 = new DataDynamics.ActiveReports.TextBox();
            this.textBox57 = new DataDynamics.ActiveReports.TextBox();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.shape5 = new DataDynamics.ActiveReports.Shape();
            this.shape4 = new DataDynamics.ActiveReports.Shape();
            this.textBox77 = new DataDynamics.ActiveReports.TextBox();
            this.textBox78 = new DataDynamics.ActiveReports.TextBox();
            this.shape6 = new DataDynamics.ActiveReports.Shape();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox55 = new DataDynamics.ActiveReports.TextBox();
            this.textBox56 = new DataDynamics.ActiveReports.TextBox();
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.textBox65 = new DataDynamics.ActiveReports.TextBox();
            this.textBox66 = new DataDynamics.ActiveReports.TextBox();
            this.textBox67 = new DataDynamics.ActiveReports.TextBox();
            this.textBox68 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.CanGrow = false;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.textBox13,
            this.textBox14,
            this.shape1,
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
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox34,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.shape2,
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
            this.textBox49,
            this.textBox51,
            this.textBox57,
            this.textBox59,
            this.textBox61,
            this.shape5,
            this.shape4,
            this.textBox77,
            this.textBox78,
            this.shape6,
            this.textBox12,
            this.textBox30,
            this.line1,
            this.textBox50,
            this.textBox55,
            this.textBox56,
            this.textBox58,
            this.textBox60,
            this.textBox62,
            this.textBox63,
            this.textBox64,
            this.textBox65,
            this.textBox66,
            this.textBox67,
            this.textBox68});
            this.detail.Height = 2.9375F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
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
            this.textBox1.CanGrow = false;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 1.25F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.25F;
            this.textBox1.Width = 2.5F;
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
            this.textBox2.CanGrow = false;
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 1.25F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.4375F;
            this.textBox2.Width = 1.375F;
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
            this.textBox3.CanGrow = false;
            this.textBox3.Height = 0.1875F;
            this.textBox3.Left = 1.25F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox3.Text = "textBox3";
            this.textBox3.Top = 0.625F;
            this.textBox3.Width = 2.5F;
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
            this.textBox4.CanGrow = false;
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 1.25F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox4.Text = "textBox4";
            this.textBox4.Top = 0.8125F;
            this.textBox4.Width = 0.9375F;
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
            this.textBox5.CanGrow = false;
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 1F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox5.Text = "Servicio a cliente transitorio";
            this.textBox5.Top = 1.1875F;
            this.textBox5.Width = 1.6875F;
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
            this.textBox6.CanGrow = false;
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 1.6875F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox6.Text = "textBox6";
            this.textBox6.Top = 1.375F;
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
            this.textBox7.CanGrow = false;
            this.textBox7.Height = 0.15F;
            this.textBox7.Left = 3F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox7.Text = "textBox7";
            this.textBox7.Top = 2.125F;
            this.textBox7.Width = 0.75F;
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
            this.textBox8.CanGrow = false;
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 1.6875F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox8.Text = "textBox8";
            this.textBox8.Top = 1.5625F;
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
            this.textBox9.CanGrow = false;
            this.textBox9.Height = 0.15F;
            this.textBox9.Left = 4.5625F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox9.Text = "textBox9";
            this.textBox9.Top = 2.125F;
            this.textBox9.Width = 1.25F;
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
            this.textBox10.CanGrow = false;
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 0.25F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox10.Text = "Monto:";
            this.textBox10.Top = 0.8125F;
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
            this.textBox11.CanGrow = false;
            this.textBox11.Height = 0.15F;
            this.textBox11.Left = 1F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox11.Text = "textBox11";
            this.textBox11.Top = 2.125F;
            this.textBox11.Width = 1.125F;
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
            this.textBox13.CanGrow = false;
            this.textBox13.Height = 0.15F;
            this.textBox13.Left = 1F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox13.Text = "textBox13";
            this.textBox13.Top = 2.29F;
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
            this.textBox14.CanGrow = false;
            this.textBox14.Height = 0.1875F;
            this.textBox14.Left = 0.25F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; vertical-" +
                "align: middle; ";
            this.textBox14.Text = "Sucursal:";
            this.textBox14.Top = 0.4375F;
            this.textBox14.Width = 1F;
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
            this.shape1.Height = 0.6875F;
            this.shape1.Left = 0.1875F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape1.Top = 1.125F;
            this.shape1.Width = 2.5625F;
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
            this.textBox15.CanGrow = false;
            this.textBox15.Height = 0.1875F;
            this.textBox15.Left = 0.25F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox15.Text = "Nº comprobante DPR:";
            this.textBox15.Top = 1.375F;
            this.textBox15.Width = 1.375F;
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
            this.textBox16.CanGrow = false;
            this.textBox16.Height = 0.15F;
            this.textBox16.Left = 3.8125F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox16.Text = "Cliente NIT:";
            this.textBox16.Top = 2.125F;
            this.textBox16.Width = 0.75F;
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
            this.textBox17.CanGrow = false;
            this.textBox17.Height = 0.15F;
            this.textBox17.Left = 3F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox17.Text = "textBox17";
            this.textBox17.Top = 2.29F;
            this.textBox17.Width = 2.8125F;
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
            this.textBox18.CanGrow = false;
            this.textBox18.Height = 0.15F;
            this.textBox18.Left = 3F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox18.Text = "textBox18";
            this.textBox18.Top = 2.46F;
            this.textBox18.Width = 0.8125F;
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
            this.textBox19.CanGrow = false;
            this.textBox19.Height = 0.15F;
            this.textBox19.Left = 0.25F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox19.Text = "Nº autoriz.:";
            this.textBox19.Top = 2.29F;
            this.textBox19.Width = 0.6875F;
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
            this.textBox20.CanGrow = false;
            this.textBox20.Height = 0.15F;
            this.textBox20.Left = 1F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox20.Text = "textBox20";
            this.textBox20.Top = 2.46F;
            this.textBox20.Width = 1.125F;
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
            this.textBox21.CanGrow = false;
            this.textBox21.Height = 0.15F;
            this.textBox21.Left = 0.25F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox21.Text = "NIT:";
            this.textBox21.Top = 2.125F;
            this.textBox21.Width = 0.6875F;
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
            this.textBox22.CanGrow = false;
            this.textBox22.Height = 0.1875F;
            this.textBox22.Left = 3.9375F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" +
                "ly: Arial; vertical-align: middle; ";
            this.textBox22.Text = "Nº contrato:";
            this.textBox22.Top = 0.4375F;
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
            this.textBox23.CanGrow = false;
            this.textBox23.Height = 0.15F;
            this.textBox23.Left = 0.25F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox23.Text = "F. Límite:";
            this.textBox23.Top = 2.46F;
            this.textBox23.Width = 0.6875F;
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
            this.textBox24.CanGrow = false;
            this.textBox24.Height = 0.15F;
            this.textBox24.Left = 3.875F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox24.Text = "Cod.Control:";
            this.textBox24.Top = 2.46F;
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
            this.textBox25.CanGrow = false;
            this.textBox25.Height = 0.15F;
            this.textBox25.Left = 2.1875F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox25.Text = "Nº factura:";
            this.textBox25.Top = 2.125F;
            this.textBox25.Width = 0.75F;
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
            this.textBox26.CanGrow = false;
            this.textBox26.Height = 0.15F;
            this.textBox26.Left = 2.1875F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox26.Text = "Monto Bs.:";
            this.textBox26.Top = 2.46F;
            this.textBox26.Width = 0.75F;
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
            this.textBox27.CanGrow = false;
            this.textBox27.Height = 0.1875F;
            this.textBox27.Left = 5.875F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox27.Text = "Asesor vent.:";
            this.textBox27.Top = 0.4375F;
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
            this.textBox28.CanGrow = false;
            this.textBox28.Height = 0.1875F;
            this.textBox28.Left = 3.9375F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox28.Text = "Concepto:";
            this.textBox28.Top = 0.8125F;
            this.textBox28.Width = 0.9375F;
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
            this.textBox29.CanGrow = false;
            this.textBox29.Height = 0.1875F;
            this.textBox29.Left = 2.875F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox29.Text = "Nº";
            this.textBox29.Top = 1.1875F;
            this.textBox29.Width = 0.375F;
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
            this.textBox31.CanGrow = false;
            this.textBox31.Height = 0.1875F;
            this.textBox31.Left = 3.9375F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox31.Text = "Lote/Servicio:";
            this.textBox31.Top = 0.625F;
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
            this.textBox32.CanGrow = false;
            this.textBox32.Height = 0.15F;
            this.textBox32.Left = 4.6875F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox32.Text = "textBox32";
            this.textBox32.Top = 2.46F;
            this.textBox32.Width = 1.125F;
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
            this.textBox33.CanGrow = false;
            this.textBox33.Height = 0.1875F;
            this.textBox33.Left = 3.25F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox33.Text = "F.Interés";
            this.textBox33.Top = 1.1875F;
            this.textBox33.Width = 0.6875F;
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
            this.textBox34.CanGrow = false;
            this.textBox34.Height = 0.1875F;
            this.textBox34.Left = 5.3125F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox34.Text = "Mant.(Bs)";
            this.textBox34.Top = 1.1875F;
            this.textBox34.Width = 0.625F;
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
            this.textBox35.CanGrow = false;
            this.textBox35.Height = 0.1875F;
            this.textBox35.Left = 3.9375F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox35.Text = "Pago (Bs)";
            this.textBox35.Top = 1.1875F;
            this.textBox35.Width = 0.75F;
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
            this.textBox36.CanGrow = false;
            this.textBox36.Height = 0.1875F;
            this.textBox36.Left = 4.9375F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; font-family: Arial; vertical-a" +
                "lign: middle; ";
            this.textBox36.Text = "textBox36";
            this.textBox36.Top = 0.25F;
            this.textBox36.Width = 3.25F;
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
            this.textBox37.CanGrow = false;
            this.textBox37.Height = 0.1875F;
            this.textBox37.Left = 4.6875F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox37.Text = "Seg.(Bs)";
            this.textBox37.Top = 1.1875F;
            this.textBox37.Width = 0.625F;
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
            this.textBox38.CanGrow = false;
            this.textBox38.Height = 0.1875F;
            this.textBox38.Left = 4.9375F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; font-family" +
                ": Arial; vertical-align: middle; ";
            this.textBox38.Text = "textBox38";
            this.textBox38.Top = 0.4375F;
            this.textBox38.Width = 0.875F;
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
            this.textBox52.CanGrow = false;
            this.textBox52.Height = 0.1875F;
            this.textBox52.Left = 0.25F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; vertical-" +
                "align: middle; ";
            this.textBox52.Text = "Unid. Negocios:";
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
            this.textBox53.CanGrow = false;
            this.textBox53.Height = 0.1875F;
            this.textBox53.Left = 0.25F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox53.Text = "Fecha / Usuario:";
            this.textBox53.Top = 0.625F;
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
            this.textBox54.CanGrow = false;
            this.textBox54.Height = 0.1875F;
            this.textBox54.Left = 3.9375F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox54.Text = "Cliente:";
            this.textBox54.Top = 0.25F;
            this.textBox54.Width = 0.9375F;
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
            this.shape2.Height = 0.875F;
            this.shape2.Left = 0.1875F;
            this.shape2.Name = "shape2";
            this.shape2.RoundingRadius = 9.999999F;
            this.shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape2.Top = 0.1875F;
            this.shape2.Width = 3.625F;
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
            this.textBox39.CanGrow = false;
            this.textBox39.Height = 0.1875F;
            this.textBox39.Left = 4.9375F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox39.Text = "textBox39";
            this.textBox39.Top = 0.625F;
            this.textBox39.Width = 3.25F;
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
            this.textBox40.CanGrow = false;
            this.textBox40.Height = 0.1875F;
            this.textBox40.Left = 6.75F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox40.Text = "textBox40";
            this.textBox40.Top = 0.4375F;
            this.textBox40.Width = 1.4375F;
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
            this.textBox41.CanGrow = false;
            this.textBox41.Height = 0.1875F;
            this.textBox41.Left = 4.9375F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox41.Text = "textBox41";
            this.textBox41.Top = 0.8125F;
            this.textBox41.Width = 3.25F;
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
            this.textBox42.CanGrow = false;
            this.textBox42.Height = 0.1875F;
            this.textBox42.Left = 2.875F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox42.Text = "textBox42";
            this.textBox42.Top = 1.375F;
            this.textBox42.Width = 0.375F;
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
            this.textBox43.CanGrow = false;
            this.textBox43.Height = 0.1875F;
            this.textBox43.Left = 3.25F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox43.Text = "textBox43";
            this.textBox43.Top = 1.375F;
            this.textBox43.Width = 0.6875F;
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
            this.textBox44.CanGrow = false;
            this.textBox44.Height = 0.1875F;
            this.textBox44.Left = 3.9375F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox44.Text = "textBox44";
            this.textBox44.Top = 1.375F;
            this.textBox44.Width = 0.75F;
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
            this.textBox45.CanGrow = false;
            this.textBox45.Height = 0.1875F;
            this.textBox45.Left = 4.6875F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox45.Text = "textBox45";
            this.textBox45.Top = 1.375F;
            this.textBox45.Width = 0.625F;
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
            this.textBox46.CanGrow = false;
            this.textBox46.Height = 0.1875F;
            this.textBox46.Left = 5.3125F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox46.Text = "textBox46";
            this.textBox46.Top = 1.375F;
            this.textBox46.Width = 0.625F;
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
            this.textBox47.CanGrow = false;
            this.textBox47.Height = 0.1875F;
            this.textBox47.Left = 5.9375F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox47.Text = "textBox47";
            this.textBox47.Top = 1.375F;
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
            this.textBox48.CanGrow = false;
            this.textBox48.Height = 0.1875F;
            this.textBox48.Left = 5.9375F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox48.Text = "Interés (Bs)";
            this.textBox48.Top = 1.1875F;
            this.textBox48.Width = 0.75F;
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
            this.textBox49.CanGrow = false;
            this.textBox49.Height = 0.1875F;
            this.textBox49.Left = 6.6875F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox49.Text = "Capital (Bs)";
            this.textBox49.Top = 1.1875F;
            this.textBox49.Width = 0.75F;
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
            this.textBox51.CanGrow = false;
            this.textBox51.Height = 0.1875F;
            this.textBox51.Left = 7.4375F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox51.Text = "Saldo (Bs)";
            this.textBox51.Top = 1.1875F;
            this.textBox51.Width = 0.75F;
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
            this.textBox57.CanGrow = false;
            this.textBox57.Height = 0.1875F;
            this.textBox57.Left = 6.6875F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox57.Text = "textBox57";
            this.textBox57.Top = 1.375F;
            this.textBox57.Width = 0.75F;
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
            this.textBox59.CanGrow = false;
            this.textBox59.Height = 0.1875F;
            this.textBox59.Left = 7.4375F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; vertical-align: middle; ";
            this.textBox59.Text = "textBox59";
            this.textBox59.Top = 1.375F;
            this.textBox59.Width = 0.75F;
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
            this.textBox61.CanGrow = false;
            this.textBox61.Height = 0.1875F;
            this.textBox61.Left = 2.875F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; vertical-align: middle; ";
            this.textBox61.Text = "textBox61";
            this.textBox61.Top = 1.625F;
            this.textBox61.Width = 5.3125F;
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
            this.shape5.Height = 0.875F;
            this.shape5.Left = 3.875F;
            this.shape5.Name = "shape5";
            this.shape5.RoundingRadius = 9.999999F;
            this.shape5.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape5.Top = 0.1875F;
            this.shape5.Width = 4.375F;
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
            this.shape4.Height = 0.74F;
            this.shape4.Left = 0.1875F;
            this.shape4.Name = "shape4";
            this.shape4.RoundingRadius = 9.999999F;
            this.shape4.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape4.Top = 1.9F;
            this.shape4.Width = 5.6875F;
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
            this.textBox77.CanGrow = false;
            this.textBox77.Height = 0.1875F;
            this.textBox77.Left = 0.25F;
            this.textBox77.MultiLine = false;
            this.textBox77.Name = "textBox77";
            this.textBox77.Style = "ddo-char-set: 0; font-size: 9pt; vertical-align: middle; ";
            this.textBox77.Text = "Nº recibo de cobrador:";
            this.textBox77.Top = 1.5625F;
            this.textBox77.Width = 1.375F;
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
            this.textBox78.CanGrow = false;
            this.textBox78.Height = 0.15F;
            this.textBox78.Left = 2.1875F;
            this.textBox78.MultiLine = false;
            this.textBox78.Name = "textBox78";
            this.textBox78.Style = "ddo-char-set: 0; font-size: 9pt; vertical-align: middle; ";
            this.textBox78.Text = "Cli. Nombre:";
            this.textBox78.Top = 2.29F;
            this.textBox78.Width = 0.75F;
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
            this.shape6.Height = 0.6875F;
            this.shape6.Left = 2.8125F;
            this.shape6.Name = "shape6";
            this.shape6.RoundingRadius = 9.999999F;
            this.shape6.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape6.Top = 1.125F;
            this.shape6.Width = 5.4375F;
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
            this.textBox12.CanGrow = false;
            this.textBox12.Height = 0.1875F;
            this.textBox12.Left = 0.25F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "font-size: 9pt; font-family: Arial Narrow; vertical-align: middle; ";
            this.textBox12.Text = "Tipo de pago:";
            this.textBox12.Top = 1.1875F;
            this.textBox12.Width = 0.6875F;
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
            this.textBox30.Height = 0.15F;
            this.textBox30.Left = 6.0625F;
            this.textBox30.Name = "textBox30";
            this.textBox30.Style = "text-align: center; font-size: 9pt; ";
            this.textBox30.Text = "Firma del cliente";
            this.textBox30.Top = 2.625F;
            this.textBox30.Width = 2.125F;
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
            this.line1.Left = 6F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 2.625F;
            this.line1.Width = 2.25F;
            this.line1.X1 = 6F;
            this.line1.X2 = 8.25F;
            this.line1.Y1 = 2.625F;
            this.line1.Y2 = 2.625F;
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
            this.textBox50.CanGrow = false;
            this.textBox50.Height = 0.1875F;
            this.textBox50.Left = 2.625F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox50.Text = "TC oficial:";
            this.textBox50.Top = 0.4375F;
            this.textBox50.Width = 0.6875F;
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
            this.textBox55.CanGrow = false;
            this.textBox55.Height = 0.1875F;
            this.textBox55.Left = 3.3125F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.Style = "font-weight: bold; font-size: 9pt; vertical-align: middle; ";
            this.textBox55.Text = "textBox55";
            this.textBox55.Top = 0.4375F;
            this.textBox55.Width = 0.4375F;
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
            this.textBox56.CanGrow = false;
            this.textBox56.Height = 0.1875F;
            this.textBox56.Left = 2.25F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox56.Text = "Estado:";
            this.textBox56.Top = 0.8125F;
            this.textBox56.Width = 0.5625F;
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
            this.textBox58.CanGrow = false;
            this.textBox58.Height = 0.1875F;
            this.textBox58.Left = 2.8125F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.Style = "font-weight: bold; font-size: 9pt; vertical-align: middle; ";
            this.textBox58.Text = "textBox58";
            this.textBox58.Top = 0.8125F;
            this.textBox58.Width = 0.9375F;
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
            this.textBox60.CanGrow = false;
            this.textBox60.Height = 0.1875F;
            this.textBox60.Left = 0.25F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox60.Text = "Razón Social:";
            this.textBox60.Top = 1.9375F;
            this.textBox60.Width = 0.84F;
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
            this.textBox62.CanGrow = false;
            this.textBox62.Height = 0.1875F;
            this.textBox62.Left = 1.12F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.Style = "font-weight: bold; font-size: 9pt; vertical-align: middle; ";
            this.textBox62.Text = "textBox62";
            this.textBox62.Top = 1.9375F;
            this.textBox62.Width = 2.64F;
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
            this.textBox63.Height = 0.11F;
            this.textBox63.Left = 0.25F;
            this.textBox63.Name = "textBox63";
            this.textBox63.Style = "font-size: 6pt; vertical-align: middle; ";
            this.textBox63.Text = "textBox63";
            this.textBox63.Top = 2.65F;
            this.textBox63.Width = 5.5625F;
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
            this.textBox64.CanGrow = false;
            this.textBox64.Height = 0.15F;
            this.textBox64.Left = 7.25F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.Style = "text-align: right; font-weight: bold; font-style: italic; font-size: 9pt; ";
            this.textBox64.Text = "Reimpresión";
            this.textBox64.Top = 1.82F;
            this.textBox64.Visible = false;
            this.textBox64.Width = 1F;
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
            this.textBox65.CanGrow = false;
            this.textBox65.Height = 0.4375F;
            this.textBox65.Left = 6F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.Style = "color: Red; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 30" +
                "pt; ";
            this.textBox65.Text = "ANULADO";
            this.textBox65.Top = 1.9375F;
            this.textBox65.Width = 2.25F;
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
            this.textBox66.CanGrow = false;
            this.textBox66.Height = 0.1875F;
            this.textBox66.Left = 3.78F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox66.Text = "Fecha:";
            this.textBox66.Top = 1.9375F;
            this.textBox66.Width = 0.5F;
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
            this.textBox67.CanGrow = false;
            this.textBox67.Height = 0.1875F;
            this.textBox67.Left = 4.295F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox67.Text = "textBox67";
            this.textBox67.Top = 1.9375F;
            this.textBox67.Width = 0.75F;
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
            this.textBox68.CanGrow = false;
            this.textBox68.Height = 0.1875F;
            this.textBox68.Left = 5.0625F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Arial; vertic" +
                "al-align: middle; ";
            this.textBox68.Text = "(Anulada)";
            this.textBox68.Top = 1.9375F;
            this.textBox68.Width = 0.75F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // cajaTransaccionTalon
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Factura";
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionTalon_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionTalon_ReportStart);
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}