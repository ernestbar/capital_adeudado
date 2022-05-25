using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionComprobante.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionComprobante : DataDynamics.ActiveReports.ActiveReport3
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
        private TextBox textBox12;
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
        private TextBox textBox30;
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
        private TextBox textBox72;
        private TextBox textBox73;
        private Shape shape5;
        private Shape shape4;
        private TextBox textBox75;
        private TextBox textBox76;
        private TextBox textBox77;
        private TextBox textBox78;
        private TextBox textBox50;
        private TextBox textBox55;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionComprobante()
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

        private void cajaTransaccionComprobante_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionComprob", 850, 400);
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
            bool reimpresion,
            string t_codigo_moneda, int t_num_recibo_cobrador, DateTime t_fecha, string t_usuario,
            int su_numero, string su_nombre,
            bool fp_dpr, decimal fp_dpr_monto, string fp_dpr_concepto, decimal fp_efectivo_sus, decimal fp_efectivo_bs, decimal fp_tarjeta_sus, decimal fp_tarjeta_bs, string fp_tarjeta_numero, decimal fp_cheque_sus, decimal fp_cheque_bs, string fp_cheque_numero, string fp_cheque_banco, decimal fp_deposito_sus, decimal fp_deposito_bs,
            int id_contrato, string co_numero, string co_descripcion, string co_promotor,
            int id_pago, string pa_codigo, int pa_num_pago, int pa_num_cuotas, DateTime pa_fecha_pago, DateTime pa_fecha_interes, DateTime pa_fecha_proximo, decimal pa_monto_pago, decimal pa_seguro, decimal pa_mantenimiento, decimal pa_interes, decimal pa_capital, decimal pa_saldo,
            int id_comprobantedpr, int cd_num_comprobante, DateTime cd_fecha, string cd_concepto, string cd_cliente, decimal cd_monto, decimal cd_tipo_cambio, string cd_encabezado, bool cd_anulado
            //int id_transaccion, DateTime t_fecha, string t_codigo_moneda, decimal t_monto, string t_usuario, int t_num_recibo_cobrador, bool t_anulado,
            //int id_sucursal, string su_nombre, int su_numero, string su_lugar, string su_telefono, string su_direccion,
            //bool fp_dpr, decimal fp_dpr_monto, string fp_dpr_concepto, decimal fp_efectivo_sus, decimal fp_efectivo_bs, decimal fp_tarjeta_sus, decimal fp_tarjeta_bs, string fp_tarjeta_numero, decimal fp_cheque_sus, decimal fp_cheque_bs, string fp_cheque_numero, string fp_cheque_banco, decimal fp_deposito_sus, decimal fp_deposito_bs,
            //int id_contrato, string co_numero, string co_descripcion, string co_promotor,
            //int id_pago, string pa_codigo, int pa_num_pago, int pa_num_cuotas, DateTime pa_fecha_pago, DateTime pa_fecha_interes, DateTime pa_fecha_proximo, decimal pa_monto_pago, decimal pa_seguro, decimal pa_mantenimiento, decimal pa_interes, decimal pa_capital, decimal pa_saldo,
            //int id_serviciovendido, string sv_nombre, int sv_num_unidades, decimal sv_precio_unidad, decimal sv_precio_total,
            ////int tp_id_contrato, string tp_num_contrato, string tp_titular, DateTime tp_fecha_inicial, DateTime tp_fecha_final, int tp_num_meses,
            //int id_recibo, int r_num_recibo, DateTime r_fecha, string r_concepto, string r_cliente, decimal r_monto, decimal r_tipo_cambio, string r_encabezado, bool r_anulado
            )
        {
           
            string cd_encab_empresa = ""; string cd_encab_actividad = ""; string cd_encab_direccion = ""; string cd_encab_telefono = ""; string cd_encab_lugar = "";
            if (cd_encabezado.Contains("|") == true) { string[] cd_enca = cd_encabezado.Split('|'); cd_encab_empresa = cd_enca[0]; cd_encab_actividad = cd_enca[1]; cd_encab_direccion = cd_enca[2]; cd_encab_telefono = cd_enca[3]; cd_encab_lugar = cd_enca[4]; }

            textBox1.Text = cd_encab_empresa;
            if (cd_encab_actividad != ".") { textBox2.Text = cd_encab_actividad; } else { textBox2.Text = ""; }
            if (cd_encab_direccion != ".") { textBox3.Text = cd_encab_direccion; } else { textBox3.Text = ""; }
            if (cd_encab_telefono != ".") { textBox4.Text = cd_encab_telefono; } else { textBox4.Text = ""; }
            if (cd_encab_lugar != ".") { textBox5.Text = cd_encab_lugar; } else { textBox5.Text = ""; }

            textBox52.Text = cd_num_comprobante.ToString();
            textBox54.Text = cd_fecha.ToString("d");
            if (t_num_recibo_cobrador > 0) { textBox11.Text = t_num_recibo_cobrador.ToString(); } else { textBox11.Text = "Sin recibo"; }
            textBox13.Text = su_numero.ToString() + " - " + su_nombre;

            textBox6.Text = t_codigo_moneda;
            textBox7.Text = cd_monto.ToString("N2");
            textBox9.Text = cd_tipo_cambio.ToString("N2");


            textBox16.Text = cd_cliente;
            string literal = Conversiones.enletras(cd_monto.ToString("F2")).ToLower();
            literal = literal.Substring(0, 1).ToUpper() + literal.Substring(1, literal.Length - 1);
            if (t_codigo_moneda == "Bs")
            {
                //textBox77.Text = "La suma de Bs:";
                textBox78.Text = "Bs: " + cd_monto.ToString("N2") + "   son: " + literal + " bolivianos";
            }
            else
            {
                //textBox77.Text = "La suma de $us:";
                textBox78.Text = "$us: " + cd_monto.ToString("N2") + "   son: " + literal + " dólares americanos";
            }
            //

            if (id_contrato > 0)
            {
                textBox21.Text = "Del contrato Nº:";
                textBox22.Text = co_numero;
                textBox23.Text = "del Lote / Servicio:";
                textBox24.Text = co_descripcion;
                if (co_promotor != "")
                {
                    textBox19.Text = "Asesor de ventas:";
                    textBox20.Text = co_promotor;
                }
                else
                {
                    textBox19.Text = "";
                    textBox20.Text = "";
                }
            }
            else
            {
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox24.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
            }
            textBox26.Text = cd_concepto.ToUpper();

            bool mostrar_detalle_pago = false;
            if (id_pago > 0)
            {
                mostrar_detalle_pago = true;

                System.Text.StringBuilder str_enun_pago = new System.Text.StringBuilder(); str_enun_pago.AppendLine("Pago"); str_enun_pago.AppendLine("(" + t_codigo_moneda + ")");
                System.Text.StringBuilder str_enun_seguro = new System.Text.StringBuilder(); str_enun_seguro.AppendLine("Seguro"); str_enun_seguro.AppendLine("(" + t_codigo_moneda + ")");
                System.Text.StringBuilder str_enun_menten = new System.Text.StringBuilder(); str_enun_menten.AppendLine("Mantenim."); str_enun_menten.AppendLine("(" + t_codigo_moneda + ")");
                System.Text.StringBuilder str_enun_interes = new System.Text.StringBuilder(); str_enun_interes.AppendLine("Interés"); str_enun_interes.AppendLine("(" + t_codigo_moneda + ")");
                System.Text.StringBuilder str_enun_capital = new System.Text.StringBuilder(); str_enun_capital.AppendLine("Capital"); str_enun_capital.AppendLine("(" + t_codigo_moneda + ")");
                System.Text.StringBuilder str_enun_saldo = new System.Text.StringBuilder(); str_enun_saldo.AppendLine("Saldo"); str_enun_saldo.AppendLine("(" + t_codigo_moneda + ")");

                //shape3.Visible = true;
                //textBox31.Text = "Datos del pago";

                //textBox17.Text = "Nº de pago";
                //textBox18.Text = "Fecha de Pago";
                //textBox32.Text = "F.Pago Interés";
                //textBox27.Text = "F.Prox. Pago:";
                //textBox28.Text = "Cuota(s)";
                textBox29.Text = str_enun_pago.ToString();
                textBox30.Text = str_enun_seguro.ToString();
                textBox33.Text = str_enun_menten.ToString();
                textBox35.Text = str_enun_interes.ToString();
                textBox37.Text = str_enun_capital.ToString();
                textBox34.Text = str_enun_saldo.ToString();

                textBox36.Text = pa_num_pago.ToString();
                textBox38.Text = pa_fecha_pago.ToString("d");
                textBox39.Text = pa_fecha_interes.ToString("d");
                textBox40.Text = pa_fecha_proximo.ToString("d");
                if (pa_num_cuotas > 0)
                {
                    textBox28.Text = "Cuota(s)";
                    textBox41.Text = pa_num_cuotas.ToString();
                }
                else
                {
                    textBox28.Text = "";
                    textBox41.Text = "";
                }
                textBox42.Text = pa_monto_pago.ToString("N2");
                textBox43.Text = pa_seguro.ToString("N2");
                textBox44.Text = pa_mantenimiento.ToString("N2");
                textBox45.Text = pa_interes.ToString("N2");
                textBox46.Text = pa_capital.ToString("N2");
                textBox47.Text = pa_saldo.ToString("N2");
            }

            shape4.Visible = mostrar_detalle_pago;
            textBox31.Visible = mostrar_detalle_pago;

            textBox17.Visible = mostrar_detalle_pago;
            textBox18.Visible = mostrar_detalle_pago;
            textBox32.Visible = mostrar_detalle_pago;
            textBox27.Visible = mostrar_detalle_pago;
            textBox28.Visible = mostrar_detalle_pago;
            textBox29.Visible = mostrar_detalle_pago;
            textBox30.Visible = mostrar_detalle_pago;
            textBox33.Visible = mostrar_detalle_pago;
            textBox35.Visible = mostrar_detalle_pago;
            textBox37.Visible = mostrar_detalle_pago;
            textBox34.Visible = mostrar_detalle_pago;

            textBox36.Visible = mostrar_detalle_pago;
            textBox38.Visible = mostrar_detalle_pago;
            textBox39.Visible = mostrar_detalle_pago;
            textBox40.Visible = mostrar_detalle_pago;
            textBox41.Visible = mostrar_detalle_pago;
            textBox42.Visible = mostrar_detalle_pago;
            textBox43.Visible = mostrar_detalle_pago;
            textBox44.Visible = mostrar_detalle_pago;
            textBox45.Visible = mostrar_detalle_pago;
            textBox46.Visible = mostrar_detalle_pago;
            textBox47.Visible = mostrar_detalle_pago;


            textBox51.Text = fp_dpr_concepto;
            //textBox57.Text = fp_efectivo_sus.ToString("N2");
            //textBox59.Text = fp_efectivo_bs.ToString("N2");
            //textBox61.Text = fp_tarjeta_sus.ToString("N2");
            //textBox63.Text = fp_tarjeta_bs.ToString("N2");
            //textBox65.Text = fp_deposito_sus.ToString("N2");
            //textBox67.Text = fp_deposito_bs.ToString("N2");
            //textBox69.Text = fp_cheque_sus.ToString("N2");
            //textBox71.Text = fp_cheque_bs.ToString("N2");
            //if ((fp_tarjeta_bs + fp_tarjeta_sus) > 0) { textBox74.Text = "Tarjeta número: " + fp_tarjeta_numero; }
            //else if ((fp_cheque_bs + fp_cheque_sus) > 0) { textBox74.Text = "Cheque número: " + fp_cheque_numero + " (" + fp_cheque_banco + ")"; }
            //else { textBox74.Text = ""; }

            textBox75.Text = "Procesado por: " + t_usuario;
            textBox76.Text = t_fecha.ToString();

            textBox50.Visible = reimpresion;
            textBox55.Visible = cd_anulado;
        }

        private void cajaTransaccionComprobante_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
            if (Fields.Count > 0)
            {
                bool reimpresion = true;

                DateTime t_fecha = (DateTime)Fields["t_fecha"].Value;
                string t_codigo_moneda = (string)Fields["t_codigo_moneda"].Value;
                string t_usuario = (string)Fields["t_usuario"].Value;
                int t_num_recibo_cobrador = (int)Fields["t_num_recibo_cobrador"].Value;

                string su_nombre = (string)Fields["su_nombre"].Value;
                int su_numero = (int)Fields["su_numero"].Value;

                bool fp_dpr = (bool)Fields["fp_dpr"].Value;
                decimal fp_dpr_monto = (decimal)Fields["fp_dpr_monto"].Value;
                string fp_dpr_concepto = (string)Fields["fp_dpr_concepto"].Value;
                decimal fp_efectivo_sus = (decimal)Fields["fp_efectivo_sus"].Value;
                decimal fp_efectivo_bs = (decimal)Fields["fp_efectivo_bs"].Value;
                decimal fp_tarjeta_sus = (decimal)Fields["fp_tarjeta_sus"].Value;
                decimal fp_tarjeta_bs = (decimal)Fields["fp_tarjeta_bs"].Value;
                string fp_tarjeta_numero = (string)Fields["fp_tarjeta_numero"].Value;
                decimal fp_cheque_sus = (decimal)Fields["fp_cheque_sus"].Value;
                decimal fp_cheque_bs = (decimal)Fields["fp_cheque_bs"].Value;
                string fp_cheque_numero = (string)Fields["fp_cheque_numero"].Value;
                string fp_cheque_banco = (string)Fields["fp_cheque_banco"].Value;
                decimal fp_deposito_sus = (decimal)Fields["fp_deposito_sus"].Value;
                decimal fp_deposito_bs = (decimal)Fields["fp_deposito_bs"].Value;

                int id_contrato = (int)Fields["id_contrato"].Value;
                string co_numero = (string)Fields["co_numero"].Value;
                string co_descripcion = (string)Fields["co_descripcion"].Value;
                string co_promotor = (string)Fields["co_promotor"].Value;

                int id_pago = (int)Fields["id_pago"].Value;
                string pa_codigo = (string)Fields["pa_codigo"].Value;
                int pa_num_pago = (int)Fields["pa_num_pago"].Value;
                int pa_num_cuotas = (int)Fields["pa_num_cuotas"].Value;
                DateTime pa_fecha_pago = (DateTime)Fields["pa_fecha_pago"].Value;
                DateTime pa_fecha_interes = (DateTime)Fields["pa_fecha_interes"].Value;
                DateTime pa_fecha_proximo = (DateTime)Fields["pa_fecha_proximo"].Value;
                decimal pa_monto_pago = (decimal)Fields["pa_monto_pago"].Value;
                decimal pa_seguro = (decimal)Fields["pa_seguro"].Value;
                decimal pa_mantenimiento = (decimal)Fields["pa_mantenimiento"].Value;
                decimal pa_interes = (decimal)Fields["pa_interes"].Value;
                decimal pa_capital = (decimal)Fields["pa_capital"].Value;
                decimal pa_saldo = (decimal)Fields["pa_saldo"].Value;

                int id_comprobantedpr = (int)Fields["id_comprobantedpr"].Value;
                int cd_num_comprobante = (int)Fields["cd_num_comprobante"].Value;
                DateTime cd_fecha = (DateTime)Fields["cd_fecha"].Value;
                string cd_concepto = (string)Fields["cd_concepto"].Value;
                string cd_cliente = (string)Fields["cd_cliente"].Value;
                decimal cd_monto = (decimal)Fields["cd_monto"].Value;
                decimal cd_tipo_cambio = (decimal)Fields["cd_tipo_cambio"].Value;
                string cd_encabezado = (string)Fields["cd_encabezado"].Value;
                bool cd_anulado = (bool)Fields["cd_anulado"].Value;

                CargarDatos
                (
                reimpresion,
                t_codigo_moneda, t_num_recibo_cobrador, t_fecha, t_usuario,
                su_numero, su_nombre,
                fp_dpr, fp_dpr_monto, fp_dpr_concepto, fp_efectivo_sus, fp_efectivo_bs, fp_tarjeta_sus, fp_tarjeta_bs, fp_tarjeta_numero, fp_cheque_sus, fp_cheque_bs, fp_cheque_numero, fp_cheque_banco, fp_deposito_sus, fp_deposito_bs,
                id_contrato, co_numero, co_descripcion, co_promotor,
                id_pago, pa_codigo, pa_num_pago, pa_num_cuotas, pa_fecha_pago, pa_fecha_interes, pa_fecha_proximo, pa_monto_pago, pa_seguro, pa_mantenimiento, pa_interes, pa_capital, pa_saldo,
                id_comprobantedpr, cd_num_comprobante, cd_fecha, cd_concepto, cd_cliente, cd_monto, cd_tipo_cambio, cd_encabezado, cd_anulado
                );
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionComprobante));
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
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
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
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
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
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.textBox73 = new DataDynamics.ActiveReports.TextBox();
            this.shape5 = new DataDynamics.ActiveReports.Shape();
            this.shape4 = new DataDynamics.ActiveReports.Shape();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.textBox76 = new DataDynamics.ActiveReports.TextBox();
            this.textBox77 = new DataDynamics.ActiveReports.TextBox();
            this.textBox78 = new DataDynamics.ActiveReports.TextBox();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox55 = new DataDynamics.ActiveReports.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
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
            this.textBox12,
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
            this.textBox30,
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
            this.textBox72,
            this.textBox73,
            this.shape5,
            this.shape4,
            this.textBox75,
            this.textBox76,
            this.textBox77,
            this.textBox78,
            this.textBox50,
            this.textBox55});
            this.detail.Height = 3.9375F;
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
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 0.25F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; font-fam" +
                "ily: Arial; ";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.2F;
            this.textBox1.Width = 2.25F;
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
            this.textBox2.Height = 0.15F;
            this.textBox2.Left = 0.25F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.4F;
            this.textBox2.Width = 2.25F;
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
            this.textBox3.Height = 0.15F;
            this.textBox3.Left = 0.25F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox3.Text = "textBox3";
            this.textBox3.Top = 0.55F;
            this.textBox3.Width = 2.25F;
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
            this.textBox4.Height = 0.15F;
            this.textBox4.Left = 0.25F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox4.Text = "textBox4";
            this.textBox4.Top = 0.7F;
            this.textBox4.Width = 2.25F;
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
            this.textBox5.Height = 0.15F;
            this.textBox5.Left = 0.25F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox5.Text = "textBox5";
            this.textBox5.Top = 0.85F;
            this.textBox5.Width = 2.25F;
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
            this.textBox6.Left = 6.625F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "ddo-char-set: 1; font-weight: bold; font-size: 10pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox6.Text = "$us:";
            this.textBox6.Top = 0.25F;
            this.textBox6.Width = 0.75F;
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
            this.textBox7.Left = 7.375F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "ddo-char-set: 1; text-align: right; font-size: 10pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox7.Text = "textBox7";
            this.textBox7.Top = 0.25F;
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
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 6.625F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "ddo-char-set: 1; font-weight: bold; font-size: 10pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox8.Text = "T/C oficial:";
            this.textBox8.Top = 0.5F;
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
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 7.375F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "ddo-char-set: 1; text-align: right; font-size: 10pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox9.Text = "textBox9";
            this.textBox9.Top = 0.5F;
            this.textBox9.Width = 0.75F;
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
            this.textBox10.Left = 3F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox10.Text = "Nº recibo cobrador:";
            this.textBox10.Top = 0.625F;
            this.textBox10.Width = 1.375F;
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
            this.textBox11.Left = 4.5F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox11.Text = "textBox11";
            this.textBox11.Top = 0.625F;
            this.textBox11.Width = 1.25F;
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
            this.textBox12.Left = 3F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "ddo-char-set: 1; text-align: left; font-size: 10pt; font-family: Arial; vertical-" +
                "align: middle; ";
            this.textBox12.Text = "Sucursal:";
            this.textBox12.Top = 0.8125F;
            this.textBox12.Width = 1.375F;
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
            this.textBox13.Left = 4.5F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "ddo-char-set: 1; text-align: left; font-size: 10pt; font-family: Arial; vertical-" +
                "align: middle; ";
            this.textBox13.Text = "textBox13";
            this.textBox13.Top = 0.8125F;
            this.textBox13.Width = 2F;
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
            this.textBox14.Height = 0.25F;
            this.textBox14.Left = 2.75F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 14pt; ";
            this.textBox14.Text = "COMPROBANTE DPR:";
            this.textBox14.Top = 0.1875F;
            this.textBox14.Width = 2.3125F;
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
            this.shape1.Height = 0.5625F;
            this.shape1.Left = 6.5625F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape1.Top = 0.1875F;
            this.shape1.Width = 1.625F;
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
            this.textBox15.Height = 0.15F;
            this.textBox15.Left = 0.3125F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox15.Text = "Cliente:";
            this.textBox15.Top = 1.05F;
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
            this.textBox16.Left = 1.75F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox16.Text = "textBox16";
            this.textBox16.Top = 1.05F;
            this.textBox16.Width = 6.375F;
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
            this.textBox17.Height = 0.3125F;
            this.textBox17.Left = 0.375F;
            this.textBox17.Name = "textBox17";
            this.textBox17.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox17.Text = "Nº de pago";
            this.textBox17.Top = 1.9375F;
            this.textBox17.Width = 0.5F;
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
            this.textBox18.Height = 0.3125F;
            this.textBox18.Left = 0.875F;
            this.textBox18.Name = "textBox18";
            this.textBox18.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox18.Text = "Fecha de Pago";
            this.textBox18.Top = 1.9375F;
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
            this.textBox19.CanGrow = false;
            this.textBox19.Height = 0.15F;
            this.textBox19.Left = 5.6875F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox19.Text = "Asesor de ventas:";
            this.textBox19.Top = 1.51F;
            this.textBox19.Width = 1.25F;
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
            this.textBox20.Left = 6.9375F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox20.Text = "textBox20";
            this.textBox20.Top = 1.51F;
            this.textBox20.Width = 1.1875F;
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
            this.textBox21.Left = 0.3125F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox21.Text = "Del contrato número:";
            this.textBox21.Top = 1.36F;
            this.textBox21.Width = 1.375F;
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
            this.textBox22.Height = 0.15F;
            this.textBox22.Left = 1.75F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.Style = "ddo-char-set: 1; font-weight: bold; font-size: 9pt; font-family: Arial; vertical-" +
                "align: middle; ";
            this.textBox22.Text = "textBox22";
            this.textBox22.Top = 1.36F;
            this.textBox22.Width = 1.0625F;
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
            this.textBox23.Left = 2.875F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox23.Text = "del Lote / Servicio:";
            this.textBox23.Top = 1.36F;
            this.textBox23.Width = 1.25F;
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
            this.textBox24.Left = 4.1875F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox24.Text = "textBox24";
            this.textBox24.Top = 1.36F;
            this.textBox24.Width = 3.9375F;
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
            this.textBox25.Left = 0.3125F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox25.Text = "Concepto de pago:";
            this.textBox25.Top = 1.51F;
            this.textBox25.Width = 1.375F;
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
            this.textBox26.Left = 1.75F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox26.Text = "textBox26";
            this.textBox26.Top = 1.51F;
            this.textBox26.Width = 3.875F;
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
            this.textBox27.Height = 0.3125F;
            this.textBox27.Left = 2.375F;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox27.Text = "F.Prox. Pago:";
            this.textBox27.Top = 1.9375F;
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
            this.textBox28.CanGrow = false;
            this.textBox28.Height = 0.3125F;
            this.textBox28.Left = 3.125F;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox28.Text = "Cuota(s)";
            this.textBox28.Top = 1.9375F;
            this.textBox28.Width = 0.5F;
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
            this.textBox29.Height = 0.3125F;
            this.textBox29.Left = 3.625F;
            this.textBox29.Name = "textBox29";
            this.textBox29.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox29.Text = "Pago";
            this.textBox29.Top = 1.9375F;
            this.textBox29.Width = 0.75F;
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
            this.textBox30.CanGrow = false;
            this.textBox30.Height = 0.3125F;
            this.textBox30.Left = 4.375F;
            this.textBox30.Name = "textBox30";
            this.textBox30.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox30.Text = "Seguro";
            this.textBox30.Top = 1.9375F;
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
            this.textBox31.Height = 0.125F;
            this.textBox31.Left = 0.3125F;
            this.textBox31.Name = "textBox31";
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: Arial; vertical-a" +
                "lign: bottom; ";
            this.textBox31.Text = "Datos del pago";
            this.textBox31.Top = 1.8125F;
            this.textBox31.Width = 1.25F;
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
            this.textBox32.Height = 0.3125F;
            this.textBox32.Left = 1.625F;
            this.textBox32.Name = "textBox32";
            this.textBox32.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox32.Text = "F.Pago Interés";
            this.textBox32.Top = 1.9375F;
            this.textBox32.Width = 0.75F;
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
            this.textBox33.Height = 0.3125F;
            this.textBox33.Left = 5.125F;
            this.textBox33.Name = "textBox33";
            this.textBox33.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox33.Text = "Mantenim.";
            this.textBox33.Top = 1.9375F;
            this.textBox33.Width = 0.75F;
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
            this.textBox34.Height = 0.3125F;
            this.textBox34.Left = 7.375F;
            this.textBox34.Name = "textBox34";
            this.textBox34.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox34.Text = "Saldo";
            this.textBox34.Top = 1.9375F;
            this.textBox34.Width = 0.75F;
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
            this.textBox35.Height = 0.3125F;
            this.textBox35.Left = 5.875F;
            this.textBox35.Name = "textBox35";
            this.textBox35.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox35.Text = "Interés";
            this.textBox35.Top = 1.9375F;
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
            this.textBox36.Left = 0.375F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox36.Text = "textBox36";
            this.textBox36.Top = 2.25F;
            this.textBox36.Width = 0.5F;
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
            this.textBox37.Height = 0.3125F;
            this.textBox37.Left = 6.625F;
            this.textBox37.Name = "textBox37";
            this.textBox37.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox37.Text = "Capital";
            this.textBox37.Top = 1.9375F;
            this.textBox37.Width = 0.75F;
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
            this.textBox38.Left = 0.875F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: top; ";
            this.textBox38.Text = "textBox38";
            this.textBox38.Top = 2.25F;
            this.textBox38.Width = 0.75F;
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
            this.textBox52.Height = 0.25F;
            this.textBox52.Left = 5.125F;
            this.textBox52.Name = "textBox52";
            this.textBox52.Style = "font-weight: normal; font-size: 14pt; ";
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
            this.textBox53.Height = 0.1875F;
            this.textBox53.Left = 3F;
            this.textBox53.Name = "textBox53";
            this.textBox53.Style = "";
            this.textBox53.Text = "Fecha:";
            this.textBox53.Top = 0.4375F;
            this.textBox53.Width = 1.375F;
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
            this.textBox54.Height = 0.1875F;
            this.textBox54.Left = 4.5F;
            this.textBox54.Name = "textBox54";
            this.textBox54.Style = "";
            this.textBox54.Text = "textBox54";
            this.textBox54.Top = 0.4375F;
            this.textBox54.Width = 1.25F;
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
            this.shape2.Height = 0.675F;
            this.shape2.Left = 0.25F;
            this.shape2.Name = "shape2";
            this.shape2.RoundingRadius = 9.999999F;
            this.shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape2.Top = 1.02F;
            this.shape2.Width = 7.938F;
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
            this.textBox39.Height = 0.1875F;
            this.textBox39.Left = 1.625F;
            this.textBox39.Name = "textBox39";
            this.textBox39.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox39.Text = "textBox39";
            this.textBox39.Top = 2.25F;
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
            this.textBox40.Height = 0.1875F;
            this.textBox40.Left = 2.375F;
            this.textBox40.Name = "textBox40";
            this.textBox40.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox40.Text = "textBox40";
            this.textBox40.Top = 2.25F;
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
            this.textBox41.Height = 0.1875F;
            this.textBox41.Left = 3.125F;
            this.textBox41.Name = "textBox41";
            this.textBox41.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox41.Text = "textBox41";
            this.textBox41.Top = 2.25F;
            this.textBox41.Width = 0.5F;
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
            this.textBox42.Height = 0.1875F;
            this.textBox42.Left = 3.625F;
            this.textBox42.Name = "textBox42";
            this.textBox42.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox42.Text = "textBox42";
            this.textBox42.Top = 2.25F;
            this.textBox42.Width = 0.75F;
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
            this.textBox43.Left = 4.375F;
            this.textBox43.Name = "textBox43";
            this.textBox43.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox43.Text = "textBox43";
            this.textBox43.Top = 2.25F;
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
            this.textBox44.Height = 0.1875F;
            this.textBox44.Left = 5.125F;
            this.textBox44.Name = "textBox44";
            this.textBox44.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox44.Text = "textBox44";
            this.textBox44.Top = 2.25F;
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
            this.textBox45.Height = 0.1875F;
            this.textBox45.Left = 5.875F;
            this.textBox45.Name = "textBox45";
            this.textBox45.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox45.Text = "textBox45";
            this.textBox45.Top = 2.25F;
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
            this.textBox46.Height = 0.1875F;
            this.textBox46.Left = 6.625F;
            this.textBox46.Name = "textBox46";
            this.textBox46.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox46.Text = "textBox46";
            this.textBox46.Top = 2.25F;
            this.textBox46.Width = 0.75F;
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
            this.textBox47.Left = 7.375F;
            this.textBox47.Name = "textBox47";
            this.textBox47.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; ";
            this.textBox47.Text = "textBox47";
            this.textBox47.Top = 2.25F;
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
            this.textBox48.Height = 0.125F;
            this.textBox48.Left = 0.3125F;
            this.textBox48.Name = "textBox48";
            this.textBox48.Style = "font-size: 8pt; vertical-align: bottom; ";
            this.textBox48.Text = "Forma de pago";
            this.textBox48.Top = 2.5625F;
            this.textBox48.Width = 2F;
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
            this.textBox49.Left = 0.3125F;
            this.textBox49.Name = "textBox49";
            this.textBox49.Style = "text-align: left; font-size: 9pt; ";
            this.textBox49.Text = "Concepto del DPR:";
            this.textBox49.Top = 2.75F;
            this.textBox49.Width = 1.25F;
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
            this.textBox51.Height = 0.1875F;
            this.textBox51.Left = 1.625F;
            this.textBox51.Name = "textBox51";
            this.textBox51.Style = "text-align: left; font-size: 9pt; ";
            this.textBox51.Text = "textBox51";
            this.textBox51.Top = 2.75F;
            this.textBox51.Width = 4.375F;
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
            this.textBox72.Height = 0.1875F;
            this.textBox72.Left = 0.25F;
            this.textBox72.Name = "textBox72";
            this.textBox72.Style = "font-style: italic; font-size: 8.2pt; ";
            this.textBox72.Text = "Comunicado: El traspaso y/o cambio de nombre del contrato tendrá un costo variabl" +
                "e de acuerdo a la urbanización";
            this.textBox72.Top = 3.3125F;
            this.textBox72.Width = 5.875F;
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
            this.textBox73.Height = 0.25F;
            this.textBox73.Left = 0.25F;
            this.textBox73.Name = "textBox73";
            this.textBox73.Style = "font-size: 6.7pt; ";
            this.textBox73.Text = resources.GetString("textBox73.Text");
            this.textBox73.Top = 3.5F;
            this.textBox73.Width = 5.875F;
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
            this.shape5.Height = 0.4375F;
            this.shape5.Left = 0.25F;
            this.shape5.Name = "shape5";
            this.shape5.RoundingRadius = 9.999999F;
            this.shape5.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape5.Top = 2.6875F;
            this.shape5.Width = 5.8125F;
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
            this.shape4.Height = 0.5F;
            this.shape4.Left = 0.25F;
            this.shape4.Name = "shape4";
            this.shape4.RoundingRadius = 9.999999F;
            this.shape4.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape4.Top = 1.9375F;
            this.shape4.Width = 7.9375F;
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
            this.textBox75.CanGrow = false;
            this.textBox75.Height = 0.125F;
            this.textBox75.Left = 6.1875F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.Style = "text-align: center; font-size: 7pt; ";
            this.textBox75.Text = "textBox75";
            this.textBox75.Top = 3.5F;
            this.textBox75.Width = 2F;
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
            this.textBox76.CanGrow = false;
            this.textBox76.Height = 0.125F;
            this.textBox76.Left = 6.1875F;
            this.textBox76.MultiLine = false;
            this.textBox76.Name = "textBox76";
            this.textBox76.Style = "text-align: center; font-size: 7pt; ";
            this.textBox76.Text = "textBox76";
            this.textBox76.Top = 3.625F;
            this.textBox76.Width = 2F;
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
            this.textBox77.Height = 0.15F;
            this.textBox77.Left = 0.3125F;
            this.textBox77.Name = "textBox77";
            this.textBox77.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox77.Text = "La suma de:";
            this.textBox77.Top = 1.2F;
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
            this.textBox78.Height = 0.15F;
            this.textBox78.Left = 1.75F;
            this.textBox78.Name = "textBox78";
            this.textBox78.Style = "font-size: 9pt; vertical-align: middle; ";
            this.textBox78.Text = "textBox78";
            this.textBox78.Top = 1.2F;
            this.textBox78.Width = 6.375F;
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
            this.textBox50.Height = 0.15F;
            this.textBox50.Left = 7.0625F;
            this.textBox50.Name = "textBox50";
            this.textBox50.Style = "text-align: right; font-weight: bold; font-style: italic; vertical-align: middle;" +
                " ";
            this.textBox50.Text = "Reimpresiòn";
            this.textBox50.Top = 0.76F;
            this.textBox50.Visible = false;
            this.textBox50.Width = 1.125F;
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
            this.textBox55.Height = 0.375F;
            this.textBox55.Left = 5.75F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.Style = "color: Red; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 32" +
                ".25pt; vertical-align: middle; ";
            this.textBox55.Text = "ANULADO";
            this.textBox55.Top = 0.875F;
            this.textBox55.Width = 2.375F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // cajaTransaccionComprobante
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionComprobante_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionComprobante_ReportStart);
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}