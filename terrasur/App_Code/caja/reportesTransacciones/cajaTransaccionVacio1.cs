using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionVacio1.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionVacio1 : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private Line line1;
        private Line line2;
        private TextBox textBox10;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionVacio1()
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

        private void cajaTransaccionVacio1_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionVacio", 850, 400);
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

        public void CargarDatos()
        {
            /*
            string t_usuario,
            int su_numero, string su_lugar, string su_telefono, string su_direccion,
            int id_contrato, string co_numero, string co_descripcion,
            int id_pago, int pa_num_pago, int pa_num_cuotas,
            int id_serviciovendido, string sv_nombre,
            int tp_id_contrato, string tp_num_contrato, string tp_titular, DateTime tp_fecha_inicial, DateTime tp_fecha_final, int tp_num_meses,
            int id_factura, string f_razon_social, decimal f_nit, decimal f_num_autorizacion, DateTime f_fecha_limite, string f_encabezado,
            int f_num_factura, DateTime f_fecha, string f_cliente_nombre, decimal f_cliente_nit, string f_concepto, decimal f_monto_bs, decimal f_tipo_cambio, string f_numero_control, bool f_anulado,
            decimal f_mantenimiento, decimal f_interes, decimal f_capital, decimal f_servicio
            */

            /*
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
                str_encab_sucursal.AppendLine("Sucursal N? " + su_numero.ToString());
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
                textBox21.Text = "N? contrato:";
                textBox22.Text = co_numero;
                textBox23.Text = "del Lote / Servicio:";
                textBox24.Text = co_descripcion;
                textBox26.Text = f_concepto;

                textBox27.Text = "N? pago:";
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
                        textBox21.Text = "N? contrato:";
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
                    textBox21.Text = "N? ctto. Terraplus:";
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
                textBox33.Text = "Inter?s corriente";
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

            //C?odigo de control y fecha l?mite de emisi?n
            textBox43.Text = f_numero_control;
            textBox45.Text = f_fecha.ToString("d");

            //Usuario y tipo de cambio de la transacci?n
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
            */
        }

        private void cajaTransaccionVacio1_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionVacio1));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
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
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.line1,
            this.line2,
            this.textBox10});
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
            this.textBox1.CanGrow = false;
            this.textBox1.Height = 0.3125F;
            this.textBox1.Left = 1.875F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 20.25pt; font" +
                "-family: Lucida Bright; vertical-align: middle; ";
            this.textBox1.Text = "COMUNICADO";
            this.textBox1.Top = 0.25F;
            this.textBox1.Width = 4.75F;
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
            this.textBox2.Height = 0.625F;
            this.textBox2.Left = 0.4375F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 0; text-align: justify; font-style: normal; font-size: 11.25pt; fon" +
                "t-family: Constantia; vertical-align: middle; ";
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.Top = 0.6875F;
            this.textBox2.Width = 7.5625F;
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
            this.textBox3.Height = 0.25F;
            this.textBox3.Left = 1.625F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "ddo-char-set: 0; text-align: left; font-style: normal; font-size: 14.25pt; font-f" +
                "amily: Lucida Bright; vertical-align: middle; ";
            this.textBox3.Text = "";
            this.textBox3.Top = 1.375F;
            this.textBox3.Width = 5.125F;
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
            this.textBox4.Height = 0.25F;
            this.textBox4.Left = 1.625F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "ddo-char-set: 0; text-align: left; font-size: 14.25pt; font-family: Lucida Bright" +
                "; vertical-align: middle; ";
            this.textBox4.Text = "* CRECER";
            this.textBox4.Top = 1.6875F;
            this.textBox4.Width = 5.125F;
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
            this.textBox6.Height = 0.25F;
            this.textBox6.Left = 1.625F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "ddo-char-set: 0; text-align: left; font-size: 14.25pt; font-family: Lucida Bright" +
                "; vertical-align: middle; ";
            this.textBox6.Text = "* EMPRENDER";
            this.textBox6.Top = 2F;
            this.textBox6.Width = 5.125F;
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
            this.textBox7.Height = 0.25F;
            this.textBox7.Left = 1.625F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "ddo-char-set: 0; text-align: left; font-size: 14.25pt; font-family: Lucida Bright" +
                "; vertical-align: middle; ";
            this.textBox7.Text = "* BANCO NACIONAL DE BOLIVIA";
            this.textBox7.Top = 2.3125F;
            this.textBox7.Width = 5.125F;
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
            this.textBox8.Height = 0.25F;
            this.textBox8.Left = 1.625F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "ddo-char-set: 0; text-align: left; font-size: 14.25pt; font-family: Lucida Bright" +
                "; vertical-align: middle; ";
            this.textBox8.Text = "* BANCO SOL Y SOL AMIGO";
            this.textBox8.Top = 2.625F;
            this.textBox8.Width = 5.125F;
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
            this.textBox9.Left = 1.8125F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Lucida Bright; ";
            this.textBox9.Text = "(el servicio de cobranza en esta entidad est? habilitado a nivel nacional en toda" +
                "s sus agencias)";
            this.textBox9.Top = 2.875F;
            this.textBox9.Width = 6.3125F;
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
            this.line1.Left = 0.375F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 3.125F;
            this.line1.Width = 7.6875F;
            this.line1.X1 = 0.375F;
            this.line1.X2 = 8.0625F;
            this.line1.Y1 = 3.125F;
            this.line1.Y2 = 3.125F;
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
            this.line2.Left = 0.375F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 3.6875F;
            this.line2.Width = 7.6875F;
            this.line2.X1 = 0.375F;
            this.line2.X2 = 8.0625F;
            this.line2.Y1 = 3.6875F;
            this.line2.Y2 = 3.6875F;
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
            this.textBox10.Height = 0.4375F;
            this.textBox10.Left = 0.375F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "ddo-char-set: 0; text-align: justify; font-size: 11.25pt; font-family: Constantia" +
                "; vertical-align: middle; ";
            this.textBox10.Text = "NOTA: AL MOMENTO DE CANCELAR SUS CUOTAS MENSUALES, LAS ENTIDADES FINANCIERAS REAL" +
                "IZAR?N LA RESPECTIVA FACTURACI?N.";
            this.textBox10.Top = 3.1875F;
            this.textBox10.Width = 7.6875F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // cajaTransaccionVacio1
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionVacio1_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionVacio1_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}