using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionVacio2.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionVacio2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionVacio2()
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

        private void cajaTransaccionVacio2_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionTalonVacio", 850, 293);
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
            textBox45.Text = f_fecha.ToString("d");

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
            */
        }

        private void cajaTransaccionVacio2_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionVacio2));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
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
            this.detail.Height = 2.9375F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // cajaTransaccionVacio2
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionVacio2_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionVacio2_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}