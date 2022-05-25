using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionFactura.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionFactura : DataDynamics.ActiveReports.ActiveReport3
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
        private TextBox textBox33;
        private TextBox textBox34;
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
        private Shape shape5;
        private TextBox textBox49;
        private TextBox textBox50;
        private TextBox textBox51;
        private Shape shape6;
        private Line line1;
        private Line line4;
        private Line line5;
        private Line line6;
        private Picture picture1;
        private TextBox textBox52;
        private TextBox textBox53;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionFactura()
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

        private void cajaTransaccionFactura_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionFactura", 850, 400);
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
            string t_usuario,
            int su_numero, string su_lugar, string su_telefono, string su_direccion,
            int id_contrato, string co_numero, string co_descripcion,
            int id_pago, int pa_num_pago, int pa_num_cuotas,
            int id_serviciovendido, string sv_nombre,
            int tp_id_contrato, string tp_num_contrato, string tp_titular, DateTime tp_fecha_inicial, DateTime tp_fecha_final, int tp_num_meses,
            int id_factura, string f_razon_social, decimal f_nit, decimal f_num_autorizacion, DateTime f_fecha_limite, string f_encabezado,
            int f_num_factura, DateTime f_fecha, string f_cliente_nombre, decimal f_cliente_nit, string f_concepto, decimal f_monto_bs, decimal f_tipo_cambio, string f_numero_control, bool f_anulado,
            decimal f_mantenimiento, decimal f_interes, decimal f_capital, decimal f_servicio, string f_ley453
            )
        {

            textBox1.Text = f_razon_social;

            //Se construye el encabezado principal
            string f_encab_empresa = ""; string f_encab_actividad = ""; string f_encab_direccion = ""; string f_encab_telefono = ""; string f_encab_lugar = "";
            if (f_encabezado.Contains("|") == true) { string[] f_enca = f_encabezado.Split('|'); f_encab_empresa = f_enca[0]; f_encab_actividad = f_enca[1]; f_encab_direccion = f_enca[2]; f_encab_telefono = f_enca[3]; f_encab_lugar = f_enca[4]; }


            System.Text.StringBuilder str_encab_principal = new System.Text.StringBuilder();
            str_encab_principal.AppendLine("Casa Matriz");
            if (f_encab_direccion.Contains("-"))
            {
                str_encab_principal.AppendLine(f_encab_direccion.Split('-')[0].Trim());
                str_encab_principal.AppendLine("ZONA " + f_encab_direccion.Split('-')[1].Trim().ToUpper());
            }
            else { str_encab_principal.AppendLine(f_encab_direccion); }
            str_encab_principal.AppendLine(f_encab_telefono);
            str_encab_principal.AppendLine(f_encab_lugar);
            textBox2.Text = str_encab_principal.ToString();

            //Se contruye el encabezado de la sucursal (si es necesario)
            if (su_numero > 0)
            {
                //textBox3.Text = str_encab_principal.ToString();
                System.Text.StringBuilder str_encab_sucursal = new System.Text.StringBuilder();
                str_encab_sucursal.AppendLine("Sucursal Nº " + su_numero.ToString());
                if (su_direccion.Contains("-"))
                {
                    str_encab_sucursal.AppendLine(su_direccion.Split('-')[0].Trim());
                    str_encab_sucursal.AppendLine("ZONA " + su_direccion.Split('-')[1].Trim().ToUpper());
                }
                else { str_encab_sucursal.AppendLine(su_direccion); }
                str_encab_sucursal.AppendLine(su_telefono);
                str_encab_sucursal.AppendLine(su_lugar);
                textBox3.Text = str_encab_sucursal.ToString();
            }
            else { textBox3.Text = ""; }



            textBox7.Text = f_nit.ToString();
            textBox9.Text = f_num_factura.ToString();
            textBox11.Text = f_num_autorizacion.ToString();
            textBox13.Text = f_encab_actividad;

            string f_mes = ""; switch (f_fecha.Month) { case 1: f_mes = "enero"; break; case 2: f_mes = "febrero"; break; case 3: f_mes = "marzo"; break; case 4: f_mes = "abril"; break; case 5: f_mes = "mayo"; break; case 6: f_mes = "junio"; break; case 7: f_mes = "julio"; break; case 8: f_mes = "agosto"; break; case 9: f_mes = "septiembre"; break; case 10: f_mes = "octubre"; break; case 11: f_mes = "noviembre"; break; case 12: f_mes = "diciembre"; break; }
            string lugar_fecha = su_lugar.TrimEnd("Bolivia".ToCharArray()).Trim().TrimEnd('-').Trim() + ", " + f_fecha.ToString("dd") + " de " + f_mes + " de " + f_fecha.ToString("yyyy");
            textBox16.Text = lugar_fecha;
            textBox18.Text = f_cliente_nit.ToString();
            textBox20.Text = f_cliente_nombre;

            //Datos adicionales de la factura (contrato, lote, etc.)
            if (id_pago > 0)
            {
                textBox21.Text = "Nº contrato:";
                textBox22.Text = co_numero;
                textBox23.Text = "del Lote / Servicio:";
                textBox24.Text = co_descripcion;
                textBox26.Text = f_concepto;

                textBox27.Text = "Nº pago:";
                textBox28.Text = pa_num_pago.ToString();
                if (pa_num_cuotas > 0)
                {
                    textBox29.Text = "Cuota(s):";
                    textBox30.Text = pa_num_cuotas.ToString();
                }
                else
                {
                    textBox29.Text = "";
                    textBox30.Text = "";
                }
            }
            else if (id_serviciovendido > 0)
            {
                if (tp_id_contrato == 0)
                {
                    if (id_contrato > 0)
                    {
                        textBox21.Text = "Nº contrato:";
                        textBox22.Text = co_numero;
                        textBox23.Text = "del Lote / Servicio:";
                        textBox24.Text = co_descripcion;
                    }
                    else
                    {
                        textBox21.Text = "";
                        textBox22.Text = "";
                        textBox23.Text = "";
                        textBox24.Text = "";
                    }
                }
                else
                {
                    textBox21.Text = "Nº ctto. Terraplus:";
                    textBox22.Text = tp_num_contrato;
                    textBox23.Text = "Titular del contrato:";
                    textBox24.Text = tp_titular;
                }

                textBox26.Text = f_concepto;

                textBox27.Text = "";
                textBox28.Text = "";
                textBox29.Text = "";
                textBox30.Text = "";
            }

            //Detalle de la factura
            if (id_pago > 0)
            {
                textBox33.Text = "Interés corriente";
                textBox34.Text = f_interes.ToString("N2");

                textBox35.Text = "Mantenimiento";
                textBox36.Text = f_mantenimiento.ToString("N2");

                textBox37.Text = ""; textBox38.Text = "";
            }
            else if (id_serviciovendido > 0)
            {
                if (tp_id_contrato == 0) { textBox33.Text = sv_nombre; }
                else
                {
                    string tp_detalle_factura = terrasur.terraplus.tp_pago.StringMes(tp_fecha_inicial, tp_fecha_final);
                    if (tp_num_meses > 1) { tp_detalle_factura = tp_detalle_factura + " (" + tp_num_meses.ToString() + " meses)"; }
                    textBox33.Text = tp_detalle_factura;
                }
                textBox34.Text = f_servicio.ToString("N2");

                textBox35.Text = ""; textBox36.Text = "";
                textBox37.Text = ""; textBox38.Text = "";
            }

            //Total de la factura en numeral y literal
            string literal = Conversiones.enletras(f_monto_bs.ToString("F2")).ToLower();
            literal = literal.Substring(0, 1).ToUpper() + literal.Substring(1, literal.Length - 1);
            textBox39.Text = "Son: " + literal + " Bolivianos";
            textBox41.Text = f_monto_bs.ToString("N2");

            //Cñodigo de control y fecha límite de emisión
            textBox43.Text = f_numero_control;
            textBox45.Text = f_fecha_limite.ToString("d");

            //Usuario y tipo de cambio de la transacción
            textBox49.Text = t_usuario;
            textBox51.Text = f_tipo_cambio.ToString("N2");

            //Se crea el QR 
            if (id_factura > 0)
            {
                System.Text.StringBuilder str_qr = new System.Text.StringBuilder();
                str_qr.Append(f_nit.ToString("F0"));
                str_qr.Append("|");
                str_qr.Append(f_num_factura.ToString());
                str_qr.Append("|");
                str_qr.Append(f_num_autorizacion.ToString("F0"));
                str_qr.Append("|");
                str_qr.Append(f_fecha.ToString("dd/MM/yyyy"));
                str_qr.Append("|");
                str_qr.Append(f_monto_bs.ToString("F2").Replace(",", "."));
                str_qr.Append("|");
                str_qr.Append(f_monto_bs.ToString("F2").Replace(",", "."));
                str_qr.Append("|");
                str_qr.Append(f_numero_control);
                str_qr.Append("|");
                str_qr.Append(f_cliente_nit.ToString("F0"));
                str_qr.Append("|0|0|0|0");

                ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter();
                writer.Format = ZXing.BarcodeFormat.QR_CODE;
                writer.Options.Margin = 0;

                //writer.Options.PureBarcode = true;
                writer.Options.Height = 10;
                writer.Options.Width = 10;

                System.Drawing.Bitmap barcodeBitmap = new System.Drawing.Bitmap(writer.Write(str_qr.ToString()));
                this.picture1.Image = barcodeBitmap;
            }
            //else { this.picture1.Visible = false; }
            textBox53.Visible = reimpresion;
            textBox52.Visible = f_anulado;

            if (f_ley453 == "") { f_ley453 = "Tienes derecho a recibir información que te proteja de la publicidad engañosa"; }
            textBox47.Text = "Ley Nº 453: \"" + f_ley453 + "\"";
        }

        private void cajaTransaccionFactura_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
            if (Fields.Count > 0)
            {
                bool reimpresion = true;
                string t_usuario = (string)Fields["t_usuario"].Value;
                int su_numero = (int)Fields["su_numero"].Value;
                string su_lugar = (string)Fields["su_lugar"].Value;
                string su_telefono = (string)Fields["su_telefono"].Value;
                string su_direccion = (string)Fields["su_direccion"].Value;

                int id_contrato = (int)Fields["id_contrato"].Value;
                string co_numero = (string)Fields["co_numero"].Value;
                string co_descripcion = (string)Fields["co_descripcion"].Value;

                int id_pago = (int)Fields["id_pago"].Value;
                int pa_num_pago = (int)Fields["pa_num_pago"].Value;
                int pa_num_cuotas = (int)Fields["pa_num_cuotas"].Value;
                int id_serviciovendido = (int)Fields["id_serviciovendido"].Value;
                string sv_nombre = (string)Fields["sv_nombre"].Value;

                int tp_id_contrato = (int)Fields["tp_id_contrato"].Value;
                string tp_num_contrato = (string)Fields["tp_num_contrato"].Value;
                string tp_titular = (string)Fields["tp_titular"].Value;
                DateTime tp_fecha_inicial = (DateTime)Fields["tp_fecha_inicial"].Value;
                DateTime tp_fecha_final = (DateTime)Fields["tp_fecha_final"].Value;
                int tp_num_meses = (int)Fields["tp_num_meses"].Value;

                int id_factura = (int)Fields["id_factura"].Value;
                string f_razon_social = (string)Fields["f_razon_social"].Value;
                decimal f_nit = (decimal)Fields["f_nit"].Value;
                decimal f_num_autorizacion = (decimal)Fields["f_num_autorizacion"].Value;
                DateTime f_fecha_limite = (DateTime)Fields["f_fecha_limite"].Value;
                string f_encabezado = (string)Fields["f_encabezado"].Value;
                int f_num_factura = (int)Fields["f_num_factura"].Value;
                DateTime f_fecha = (DateTime)Fields["f_fecha"].Value;
                string f_cliente_nombre = (string)Fields["f_cliente_nombre"].Value;
                decimal f_cliente_nit = (decimal)Fields["f_cliente_nit"].Value;
                string f_concepto = (string)Fields["f_concepto"].Value;
                decimal f_monto_bs = (decimal)Fields["f_monto_bs"].Value;
                decimal f_tipo_cambio = (decimal)Fields["f_tipo_cambio"].Value;
                string f_numero_control = (string)Fields["f_numero_control"].Value;
                bool f_anulado = (bool)Fields["f_anulado"].Value;
                decimal f_mantenimiento = (decimal)Fields["f_mantenimiento"].Value;
                decimal f_interes = (decimal)Fields["f_interes"].Value;
                decimal f_capital = (decimal)Fields["f_capital"].Value;
                decimal f_servicio = (decimal)Fields["f_servicio"].Value;
                string f_ley453 = (string)Fields["f_ley453"].Value;

                CargarDatos
                (
                reimpresion,
                t_usuario,
                su_numero, su_lugar, su_telefono, su_direccion,
                id_contrato, co_numero, co_descripcion,
                id_pago, pa_num_pago, pa_num_cuotas,
                id_serviciovendido, sv_nombre,
                tp_id_contrato, tp_num_contrato, tp_titular, tp_fecha_inicial, tp_fecha_final, tp_num_meses,
                id_factura, f_razon_social, f_nit, f_num_autorizacion, f_fecha_limite, f_encabezado,
                f_num_factura, f_fecha, f_cliente_nombre, f_cliente_nit, f_concepto, f_monto_bs, f_tipo_cambio, f_numero_control, f_anulado,
                f_mantenimiento, f_interes, f_capital, f_servicio, f_ley453
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionFactura));
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
            this.shape5 = new DataDynamics.ActiveReports.Shape();
            this.textBox49 = new DataDynamics.ActiveReports.TextBox();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox51 = new DataDynamics.ActiveReports.TextBox();
            this.shape6 = new DataDynamics.ActiveReports.Shape();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.textBox53 = new DataDynamics.ActiveReports.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
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
            this.shape5,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.shape6,
            this.line1,
            this.line4,
            this.line5,
            this.line6,
            this.picture1,
            this.textBox52,
            this.textBox53});
            this.detail.Height = 3.947917F;
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
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 0.3125F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; font-fam" +
                "ily: Arial; ";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.1875F;
            this.textBox1.Width = 3.0625F;
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
            this.textBox2.Height = 0.625F;
            this.textBox2.Left = 0.3125F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.375F;
            this.textBox2.Width = 3.0625F;
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
            this.textBox3.Height = 0.625F;
            this.textBox3.Left = 0.3125F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox3.Text = "textBox3";
            this.textBox3.Top = 1F;
            this.textBox3.Width = 3.0625F;
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
            this.textBox4.Left = 3.5625F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox4.Text = "textBox4";
            this.textBox4.Top = 0.9375F;
            this.textBox4.Visible = false;
            this.textBox4.Width = 1.375F;
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
            this.textBox5.Left = 3.5625F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: Arial; ";
            this.textBox5.Text = "textBox5";
            this.textBox5.Top = 1.125F;
            this.textBox5.Visible = false;
            this.textBox5.Width = 1.375F;
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
            this.textBox6.Left = 5.75F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox6.Text = "NIT:";
            this.textBox6.Top = 0.25F;
            this.textBox6.Width = 1.125F;
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
            this.textBox7.Left = 6.875F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox7.Text = "textBox7";
            this.textBox7.Top = 0.25F;
            this.textBox7.Width = 1.25F;
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
            this.textBox8.Left = 5.75F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox8.Text = "Nº Factura:";
            this.textBox8.Top = 0.4375F;
            this.textBox8.Width = 1.125F;
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
            this.textBox9.Left = 6.875F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox9.Text = "textBox9";
            this.textBox9.Top = 0.4375F;
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
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 5.75F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "ddo-char-set: 1; font-size: 10pt; font-family: Arial; vertical-align: middle; ";
            this.textBox10.Text = "Nº Autorización:";
            this.textBox10.Top = 0.625F;
            this.textBox10.Width = 1.125F;
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
            this.textBox11.Left = 6.875F;
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
            this.textBox12.Left = 5.75F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt; font-family: Arial; vertica" +
                "l-align: middle; ";
            this.textBox12.Text = "ORIGINAL";
            this.textBox12.Top = 0.9375F;
            this.textBox12.Width = 2.375F;
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
            this.textBox13.Left = 5.75F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "ddo-char-set: 1; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: middle; ";
            this.textBox13.Text = "textBox13";
            this.textBox13.Top = 1.125F;
            this.textBox13.Width = 2.375F;
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
            this.textBox14.Left = 3.5625F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 15.75pt; ";
            this.textBox14.Text = "FACTURA";
            this.textBox14.Top = 0.6875F;
            this.textBox14.Width = 1.375F;
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
            this.shape1.Left = 5.6875F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape1.Top = 0.1875F;
            this.shape1.Width = 2.5F;
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
            this.textBox15.Left = 0.375F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox15.Text = "Lugar y fecha:";
            this.textBox15.Top = 1.65F;
            this.textBox15.Width = 1.125F;
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
            this.textBox16.Left = 1.5625F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox16.Text = "textBox16";
            this.textBox16.Top = 1.65F;
            this.textBox16.Width = 2.875F;
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
            this.textBox17.Left = 4.5F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox17.Text = "NIT/CI:";
            this.textBox17.Top = 1.65F;
            this.textBox17.Width = 0.6875F;
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
            this.textBox18.Left = 5.25F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox18.Text = "textBox18";
            this.textBox18.Top = 1.65F;
            this.textBox18.Width = 2.875F;
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
            this.textBox19.Left = 0.375F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox19.Text = "Señor(es):";
            this.textBox19.Top = 1.8F;
            this.textBox19.Width = 1.125F;
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
            this.textBox20.Height = 0.17F;
            this.textBox20.Left = 1.5625F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox20.Text = "textBox20";
            this.textBox20.Top = 1.78F;
            this.textBox20.Width = 6.5625F;
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
            this.textBox21.Left = 0.375F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox21.Text = "Nº contrato:";
            this.textBox21.Top = 1.95F;
            this.textBox21.Width = 1.125F;
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
            this.textBox22.Left = 1.5625F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox22.Text = "textBox22";
            this.textBox22.Top = 1.95F;
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
            this.textBox23.Left = 2.6875F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox23.Text = "del Lote / Servicio:";
            this.textBox23.Top = 1.95F;
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
            this.textBox24.Left = 4F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox24.Text = "textBox24";
            this.textBox24.Top = 1.95F;
            this.textBox24.Width = 4.125F;
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
            this.textBox25.Left = 0.375F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox25.Text = "Concepto de pago:";
            this.textBox25.Top = 2.1F;
            this.textBox25.Width = 1.1875F;
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
            this.textBox26.Left = 1.5625F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox26.Text = "textBox26";
            this.textBox26.Top = 2.1F;
            this.textBox26.Width = 3.3125F;
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
            this.textBox27.Height = 0.15F;
            this.textBox27.Left = 4.9375F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox27.Text = "Nº pago:";
            this.textBox27.Top = 2.1F;
            this.textBox27.Width = 0.625F;
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
            this.textBox28.Height = 0.15F;
            this.textBox28.Left = 5.625F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox28.Text = "textBox28";
            this.textBox28.Top = 2.1F;
            this.textBox28.Width = 0.4375F;
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
            this.textBox29.Height = 0.15F;
            this.textBox29.Left = 6.125F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox29.Text = "Cuota(s):";
            this.textBox29.Top = 2.1F;
            this.textBox29.Width = 0.625F;
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
            this.textBox30.Height = 0.15F;
            this.textBox30.Left = 6.75F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.Style = "ddo-char-set: 1; font-size: 8.9pt; font-family: Arial; vertical-align: bottom; ";
            this.textBox30.Text = "textBox30";
            this.textBox30.Top = 2.1F;
            this.textBox30.Width = 0.5625F;
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
            this.textBox31.Left = 0.375F;
            this.textBox31.Name = "textBox31";
            this.textBox31.Style = "ddo-char-set: 1; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: bottom; ";
            this.textBox31.Text = "DESCRIPCIÓN";
            this.textBox31.Top = 2.28F;
            this.textBox31.Width = 5F;
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
            this.textBox32.Height = 0.1875F;
            this.textBox32.Left = 5.5F;
            this.textBox32.Name = "textBox32";
            this.textBox32.Style = "ddo-char-set: 1; text-align: center; font-size: 9pt; font-family: Arial; vertical" +
                "-align: bottom; ";
            this.textBox32.Text = "SUBTOTAL Bs";
            this.textBox32.Top = 2.28F;
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
            this.textBox33.Height = 0.14F;
            this.textBox33.Left = 0.4375F;
            this.textBox33.Name = "textBox33";
            this.textBox33.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox33.Text = "Interés corriente";
            this.textBox33.Top = 2.48F;
            this.textBox33.Width = 4.9375F;
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
            this.textBox34.Height = 0.14F;
            this.textBox34.Left = 5.5F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Arial; vertical-" +
                "align: middle; ";
            this.textBox34.Text = "textBox34";
            this.textBox34.Top = 2.48F;
            this.textBox34.Width = 0.875F;
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
            this.textBox35.Height = 0.125F;
            this.textBox35.Left = 0.4375F;
            this.textBox35.Name = "textBox35";
            this.textBox35.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox35.Text = "Mantenimiento";
            this.textBox35.Top = 2.625F;
            this.textBox35.Width = 4.9375F;
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
            this.textBox36.Height = 0.125F;
            this.textBox36.Left = 5.5F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Arial; vertical-" +
                "align: middle; ";
            this.textBox36.Text = "textBox36";
            this.textBox36.Top = 2.625F;
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
            this.textBox37.Height = 0.125F;
            this.textBox37.Left = 0.4375F;
            this.textBox37.Name = "textBox37";
            this.textBox37.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; ";
            this.textBox37.Text = "textBox37";
            this.textBox37.Top = 2.75F;
            this.textBox37.Width = 4.9375F;
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
            this.textBox38.Height = 0.125F;
            this.textBox38.Left = 5.5F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Arial; ";
            this.textBox38.Text = "textBox38";
            this.textBox38.Top = 2.75F;
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
            this.textBox39.CanGrow = false;
            this.textBox39.Height = 0.1875F;
            this.textBox39.Left = 0.375F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox39.Text = "textBox39";
            this.textBox39.Top = 2.875F;
            this.textBox39.Width = 4.3125F;
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
            this.textBox40.Left = 4.75F;
            this.textBox40.Name = "textBox40";
            this.textBox40.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox40.Text = "TOTAL Bs";
            this.textBox40.Top = 2.875F;
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
            this.textBox41.CanGrow = false;
            this.textBox41.Height = 0.1875F;
            this.textBox41.Left = 5.5F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Arial; vertical-" +
                "align: middle; ";
            this.textBox41.Text = "textBox41";
            this.textBox41.Top = 2.875F;
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
            this.textBox42.CanGrow = false;
            this.textBox42.Height = 0.1875F;
            this.textBox42.Left = 0.375F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox42.Text = "Código de Control:";
            this.textBox42.Top = 3.0625F;
            this.textBox42.Width = 1.75F;
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
            this.textBox43.Left = 2.1875F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox43.Text = "textBox43";
            this.textBox43.Top = 3.0625F;
            this.textBox43.Width = 1.8125F;
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
            this.textBox44.Left = 0.375F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox44.Text = "Fecha Límite de Emisión:";
            this.textBox44.Top = 3.25F;
            this.textBox44.Width = 1.75F;
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
            this.textBox45.Left = 2.1875F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox45.Text = "textBox45";
            this.textBox45.Top = 3.25F;
            this.textBox45.Width = 1.8125F;
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
            this.textBox46.Left = 0.3125F;
            this.textBox46.Name = "textBox46";
            this.textBox46.Style = "ddo-char-set: 1; text-align: center; font-size: 8.75pt; font-family: Arial; ";
            this.textBox46.Text = "\"ESTA FACTURA CONTRIBUYE AL DESARROLLO DEL PAÍS. EL USO ILÍCITO DE ÉSTA SERÁ SANC" +
                "IONADO DE ACUERDO A LEY\"";
            this.textBox46.Top = 3.4375F;
            this.textBox46.Width = 7.875F;
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
            this.textBox47.Height = 0.125F;
            this.textBox47.Left = 0.3125F;
            this.textBox47.Name = "textBox47";
            this.textBox47.Style = "ddo-char-set: 1; text-align: center; font-size: 7pt; font-family: Tahoma; ";
            this.textBox47.Text = "Ley Nº 453: “Tienes derecho a recibir información que te proteja de la publicidad" +
                " engañosa”";
            this.textBox47.Top = 3.625F;
            this.textBox47.Width = 7.875F;
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
            this.textBox48.Left = 4.75F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox48.Text = "Cajero(a):";
            this.textBox48.Top = 3.0625F;
            this.textBox48.Width = 0.75F;
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
            this.shape5.Height = 0.625F;
            this.shape5.Left = 0.3125F;
            this.shape5.Name = "shape5";
            this.shape5.RoundingRadius = 9.999999F;
            this.shape5.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape5.Top = 1.63F;
            this.shape5.Width = 7.875F;
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
            this.textBox49.Left = 5.5F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox49.Text = "textBox49";
            this.textBox49.Top = 3.0625F;
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
            this.textBox50.CanGrow = false;
            this.textBox50.Height = 0.1875F;
            this.textBox50.Left = 4.75F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox50.Text = "T/C $us: Bs";
            this.textBox50.Top = 3.25F;
            this.textBox50.Width = 0.75F;
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
            this.textBox51.Left = 5.5F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Arial; vertical-align: middle; ";
            this.textBox51.Text = "textBox51";
            this.textBox51.Top = 3.25F;
            this.textBox51.Width = 0.875F;
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
            this.shape6.Height = 0.78F;
            this.shape6.Left = 0.3125F;
            this.shape6.Name = "shape6";
            this.shape6.RoundingRadius = 9.999999F;
            this.shape6.Style = DataDynamics.ActiveReports.ShapeType.RoundRect;
            this.shape6.Top = 2.28F;
            this.shape6.Width = 6.125F;
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
            this.line1.Left = 0.3125F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 2.47F;
            this.line1.Width = 6.125F;
            this.line1.X1 = 0.3125F;
            this.line1.X2 = 6.4375F;
            this.line1.Y1 = 2.47F;
            this.line1.Y2 = 2.47F;
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
            this.line4.Left = 0.3125F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 2.875F;
            this.line4.Width = 6.125F;
            this.line4.X1 = 0.3125F;
            this.line4.X2 = 6.4375F;
            this.line4.Y1 = 2.875F;
            this.line4.Y2 = 2.875F;
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
            this.line5.Height = 0.7825F;
            this.line5.Left = 5.4375F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 2.28F;
            this.line5.Width = 0F;
            this.line5.X1 = 5.4375F;
            this.line5.X2 = 5.4375F;
            this.line5.Y1 = 2.28F;
            this.line5.Y2 = 3.0625F;
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
            this.line6.Height = 0.1875F;
            this.line6.Left = 4.6875F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 2.875F;
            this.line6.Width = 0F;
            this.line6.X1 = 4.6875F;
            this.line6.X2 = 4.6875F;
            this.line6.Y1 = 3.0625F;
            this.line6.Y2 = 2.875F;
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
            this.picture1.Height = 1.0625F;
            this.picture1.Image = null;
            this.picture1.ImageData = null;
            this.picture1.Left = 6.8125F;
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picture1.Top = 2.3125F;
            this.picture1.Width = 1.0625F;
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
            this.textBox52.Height = 0.5625F;
            this.textBox52.Left = 2.5625F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.Style = "color: Red; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 45" +
                "pt; font-family: Arial; vertical-align: middle; ";
            this.textBox52.Text = "ANULADO";
            this.textBox52.Top = 1F;
            this.textBox52.Width = 3.375F;
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
            this.textBox53.Height = 0.15F;
            this.textBox53.Left = 7.125F;
            this.textBox53.Name = "textBox53";
            this.textBox53.Style = "text-align: right; font-weight: bold; font-style: italic; font-size: 9pt; ";
            this.textBox53.Text = "Reimpresiòn";
            this.textBox53.Top = 1.46F;
            this.textBox53.Visible = false;
            this.textBox53.Width = 1.0625F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // cajaTransaccionFactura
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionFactura_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionFactura_ReportStart);
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}