using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;   
            
/// <summary>
/// Summary description for cajaTransaccionDocumentos.
/// </summary>
/// 
namespace terrasur 
{
    public class cajaTransaccionDocumentos : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private SubReport subReport1;
        private SubReport subReport2;
        private Line line1;
        private SubReport subReport3;
        private Line line2;
        private TextBox textBox1;
        private TextBox textBox2;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        public cajaTransaccionDocumentos()
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

        private void cajaTransaccionDocumentos_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.DefaultPaperSource = false;
            this.Document.Printer.PrinterName = "";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Document.Printer.PaperSize = new System.Drawing.Printing.PaperSize("TransaccionCarta", 850, 1100);
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
        public void CargarDatos(int Id_usuario, bool Reimpresion)
        {
            textBox1.Text = Id_usuario.ToString();
            if (Reimpresion == true) { textBox2.Text = "1"; } else { textBox2.Text = "0"; }
        }

        private void cajaTransaccionDocumentos_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs eArgs)
        {
            //id_transaccion,t_fecha,t_codigo_moneda,t_monto,t_usuario,t_num_recibo_cobrador,t_negocio_codigo,t_negocio_nombre,t_anulado
            int id_transaccion = (int)Fields["id_transaccion"].Value;
            int t_id_usuario = (int)Fields["t_id_usuario"].Value;
            DateTime t_fecha = (DateTime)Fields["t_fecha"].Value;
            string t_codigo_moneda = (string)Fields["t_codigo_moneda"].Value;
            decimal t_monto = (decimal)Fields["t_monto"].Value;
            decimal t_tipo_cambio = (decimal)Fields["t_tipo_cambio"].Value;
            string t_usuario = (string)Fields["t_usuario"].Value;
            int t_num_recibo_cobrador = (int)Fields["t_num_recibo_cobrador"].Value;
            string t_negocio_codigo = (string)Fields["t_negocio_codigo"].Value;
            string t_negocio_nombre = (string)Fields["t_negocio_nombre"].Value;
            bool t_anulado = (bool)Fields["t_anulado"].Value;

            //id_sucursal,su_nombre,su_numero,su_lugar,su_telefono,su_direccion
            int id_sucursal = (int)Fields["id_sucursal"].Value;
            string su_nombre = (string)Fields["su_nombre"].Value;
            int su_numero = (int)Fields["su_numero"].Value;
            string su_lugar = (string)Fields["su_lugar"].Value;
            string su_telefono = (string)Fields["su_telefono"].Value;
            string su_direccion = (string)Fields["su_direccion"].Value;

            //fp_dpr,fp_dpr_monto,fp_dpr_concepto,fp_efectivo_sus,fp_efectivo_bs,fp_tarjeta_sus,fp_tarjeta_bs,fp_tarjeta_numero
            //fp_cheque_sus,fp_cheque_bs,fp_cheque_numero,fp_cheque_banco,fp_deposito_sus,fp_deposito_bs
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

            //id_contrato,co_numero,co_descripcion,co_promotor
            int id_contrato = (int)Fields["id_contrato"].Value;
            string co_numero = (string)Fields["co_numero"].Value;
            string co_descripcion = (string)Fields["co_descripcion"].Value;
            string co_promotor = (string)Fields["co_promotor"].Value;

            //id_pago,pa_codigo,pa_num_pago,pa_num_cuotas,pa_fecha_pago,pa_fecha_interes,pa_fecha_proximo,
            //pa_monto_pago,pa_seguro,pa_mantenimiento,pa_interes,pa_capital,pa_saldo
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

            //id_serviciovendido,sv_nombre,sv_num_unidades,sv_precio_unidad,sv_precio_total
            int id_serviciovendido = (int)Fields["id_serviciovendido"].Value;
            string sv_nombre = (string)Fields["sv_nombre"].Value;
            int sv_num_unidades = (int)Fields["sv_num_unidades"].Value;
            decimal sv_precio_unidad = (decimal)Fields["sv_precio_unidad"].Value;
            decimal sv_precio_total = (decimal)Fields["sv_precio_total"].Value;

            //tp_id_contrato,tp_num_contrato,tp_titular,tp_fecha_inicial,tp_fecha_final,tp_num_meses
            int tp_id_contrato = (int)Fields["tp_id_contrato"].Value;
            string tp_num_contrato = (string)Fields["tp_num_contrato"].Value;
            string tp_titular = (string)Fields["tp_titular"].Value;
            DateTime tp_fecha_inicial = (DateTime)Fields["tp_fecha_inicial"].Value;
            DateTime tp_fecha_final = (DateTime)Fields["tp_fecha_final"].Value;
            int tp_num_meses = (int)Fields["tp_num_meses"].Value;

            //id_recibo,r_num_recibo,r_fecha,r_concepto,r_cliente,r_monto,r_tipo_cambio,r_encabezado,r_anulado
            int id_recibo = (int)Fields["id_recibo"].Value;
            int r_num_recibo = (int)Fields["r_num_recibo"].Value;
            DateTime r_fecha = (DateTime)Fields["r_fecha"].Value;
            string r_concepto = (string)Fields["r_concepto"].Value;
            string r_cliente = (string)Fields["r_cliente"].Value;
            decimal r_monto = (decimal)Fields["r_monto"].Value;
            decimal r_tipo_cambio = (decimal)Fields["r_tipo_cambio"].Value;
            string r_encabezado = (string)Fields["r_encabezado"].Value;
            /*string r_encab_empresa = ""; string r_encab_actividad = ""; string r_encab_direccion = ""; string r_encab_telefono = ""; string r_encab_lugar = "";
            if (r_encabezado.Contains("|") == true) { string[] r_enca = r_encabezado.Split('|'); r_encab_empresa = r_enca[0]; r_encab_actividad = r_enca[1]; r_encab_direccion = r_enca[2]; r_encab_telefono = r_enca[3]; r_encab_lugar = r_enca[4]; }*/
            bool r_anulado = (bool)Fields["r_anulado"].Value;

            //id_comprobantedpr,cd_num_comprobante,cd_fecha,cd_concepto,cd_cliente,cd_monto,cd_tipo_cambio,cd_encabezado,cd_anulado
            int id_comprobantedpr = (int)Fields["id_comprobantedpr"].Value;
            int cd_num_comprobante = (int)Fields["cd_num_comprobante"].Value;
            DateTime cd_fecha = (DateTime)Fields["cd_fecha"].Value;
            string cd_concepto = (string)Fields["cd_concepto"].Value;
            string cd_cliente = (string)Fields["cd_cliente"].Value;
            decimal cd_monto = (decimal)Fields["cd_monto"].Value;
            decimal cd_tipo_cambio = (decimal)Fields["cd_tipo_cambio"].Value;
            string cd_encabezado = (string)Fields["cd_encabezado"].Value;
            /*string cd_encab_empresa = ""; string cd_encab_actividad = ""; string cd_encab_direccion = ""; string cd_encab_telefono = ""; string cd_encab_lugar = "";
            if (cd_encabezado.Contains("|") == true) { string[] cd_enca = cd_encabezado.Split('|'); cd_encab_empresa = cd_enca[0]; cd_encab_actividad = cd_enca[1]; cd_encab_direccion = cd_enca[2]; cd_encab_telefono = cd_enca[3]; cd_encab_lugar = cd_enca[4]; }*/
            bool cd_anulado = (bool)Fields["cd_anulado"].Value;

            //id_factura,f_razon_social,f_nit,f_num_autorizacion,f_fecha_limite,f_encabezado,f_num_factura,f_fecha,f_cliente_nombre
            //,f_cliente_nit,f_concepto,f_monto_bs,f_tipo_cambio,f_numero_control,f_anulado,f_mantenimiento,f_interes,f_capital,f_servicio,f_ley453
            int id_factura = (int)Fields["id_factura"].Value;
            string f_razon_social = (string)Fields["f_razon_social"].Value;
            decimal f_nit = (decimal)Fields["f_nit"].Value;
            decimal f_num_autorizacion = (decimal)Fields["f_num_autorizacion"].Value;
            DateTime f_fecha_limite = (DateTime)Fields["f_fecha_limite"].Value;
            string f_encabezado = (string)Fields["f_encabezado"].Value;
            /*string f_encab_empresa = ""; string f_encab_actividad = ""; string f_encab_direccion = ""; string f_encab_telefono = ""; string f_encab_lugar = "";
            if (f_encabezado.Contains("|") == true) { string[] f_enca = f_encabezado.Split('|'); f_encab_empresa = f_enca[0]; f_encab_actividad = f_enca[1]; f_encab_direccion = f_enca[2]; f_encab_telefono = f_enca[3]; f_encab_lugar = f_enca[4]; }*/
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

            //se cargan los reportes

            int _Id_usuario_impresion = 0;
            if (int.TryParse(textBox1.Text, out _Id_usuario_impresion) == false) { _Id_usuario_impresion = 0; }
            bool _Reimpresion = false;
            if (textBox2.Text == "1") { _Reimpresion = true; } else { _Reimpresion = false; }

            if (tp_id_contrato > 0)
            {
                //TerraPlus
                cajaTransaccionFactura tpFactObj = new cajaTransaccionFactura();
                tpFactObj.CargarDatos(_Reimpresion,
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
                subReport1.Report = tpFactObj;

                cajaTransaccionVacio1 tpVacioObj = new cajaTransaccionVacio1();
                subReport2.Report = tpVacioObj;
            }
            else
            {
                //Para el primer espacio:
                if (id_recibo > 0)
                {
                    cajaTransaccionRecibo rObj = new cajaTransaccionRecibo();
                    rObj.CargarDatos(_Reimpresion,
                         t_codigo_moneda, t_num_recibo_cobrador, t_fecha, t_usuario,
                         su_numero, su_nombre,
                         fp_dpr, fp_dpr_monto, fp_dpr_concepto, fp_efectivo_sus, fp_efectivo_bs, fp_tarjeta_sus, fp_tarjeta_bs, fp_tarjeta_numero, fp_cheque_sus, fp_cheque_bs, fp_cheque_numero, fp_cheque_banco, fp_deposito_sus, fp_deposito_bs,
                         id_contrato, co_numero, co_descripcion, co_promotor,
                         id_pago, pa_codigo, pa_num_pago, pa_num_cuotas, pa_fecha_pago, pa_fecha_interes, pa_fecha_proximo, pa_monto_pago, pa_seguro, pa_mantenimiento, pa_interes, pa_capital, pa_saldo,
                         id_recibo, r_num_recibo, r_fecha, r_concepto, r_cliente, r_monto, r_tipo_cambio, r_encabezado, r_anulado
                       );
                    subReport1.Report = rObj;
                }
                else if (id_comprobantedpr > 0)
                {
                    cajaTransaccionComprobante cdObj = new cajaTransaccionComprobante();
                    cdObj.CargarDatos(_Reimpresion,
                         t_codigo_moneda, t_num_recibo_cobrador, t_fecha, t_usuario,
                         su_numero, su_nombre,
                         fp_dpr, fp_dpr_monto, fp_dpr_concepto, fp_efectivo_sus, fp_efectivo_bs, fp_tarjeta_sus, fp_tarjeta_bs, fp_tarjeta_numero, fp_cheque_sus, fp_cheque_bs, fp_cheque_numero, fp_cheque_banco, fp_deposito_sus, fp_deposito_bs,
                         id_contrato, co_numero, co_descripcion, co_promotor,
                         id_pago, pa_codigo, pa_num_pago, pa_num_cuotas, pa_fecha_pago, pa_fecha_interes, pa_fecha_proximo, pa_monto_pago, pa_seguro, pa_mantenimiento, pa_interes, pa_capital, pa_saldo,
                         id_comprobantedpr, cd_num_comprobante, cd_fecha, cd_concepto, cd_cliente, cd_monto, cd_tipo_cambio, cd_encabezado, cd_anulado
                       );
                    subReport1.Report = cdObj;
                }
                else
                {
                    cajaTransaccionVacio1 pagVacioObj = new cajaTransaccionVacio1();
                    subReport1.Report = pagVacioObj;
                }

                //Para el segundo espacio:
                if (id_factura > 0)
                {
                    cajaTransaccionFactura fObj = new cajaTransaccionFactura();
                    fObj.CargarDatos(_Reimpresion,
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

                    // Facturacion Sintesis
                    //subReport2.Report = fObj;
                    cajaTransaccionVacio1 fVacioObj = new cajaTransaccionVacio1();
                    subReport2.Report = fVacioObj;
                    //
                }
                else
                {
                    cajaTransaccionVacio1 fVacioObj = new cajaTransaccionVacio1();
                    subReport2.Report = fVacioObj;
                }
            }

            //Para el talón
            cajaTransaccionTalon tObj = new cajaTransaccionTalon();

            tObj.CargarDatos(_Reimpresion, _Id_usuario_impresion,
                id_transaccion, t_id_usuario, t_fecha, t_codigo_moneda, t_monto, t_tipo_cambio, t_usuario, t_num_recibo_cobrador, t_negocio_nombre, t_anulado,
                su_nombre, su_numero,
                fp_dpr, fp_dpr_monto, fp_dpr_concepto, fp_efectivo_sus, fp_efectivo_bs, fp_tarjeta_sus, fp_tarjeta_bs, fp_tarjeta_numero, fp_cheque_sus, fp_cheque_bs, fp_cheque_numero, fp_cheque_banco, fp_deposito_sus, fp_deposito_bs,
                id_contrato, co_numero, co_descripcion, co_promotor,
                id_pago, pa_num_pago, pa_num_cuotas, pa_fecha_pago, pa_fecha_interes, pa_monto_pago, pa_seguro, pa_mantenimiento, pa_interes, pa_capital, pa_saldo,
                id_serviciovendido,
                tp_id_contrato, tp_num_contrato, tp_titular, tp_fecha_inicial, tp_fecha_final, tp_num_meses,
                id_recibo, r_num_recibo, r_concepto, r_cliente,
                id_comprobantedpr, cd_num_comprobante, cd_concepto, cd_cliente,
                id_factura, f_razon_social, f_nit, f_num_autorizacion, f_fecha_limite, f_encabezado,
                f_num_factura, f_fecha, f_cliente_nombre, f_cliente_nit, f_concepto, f_monto_bs, f_tipo_cambio, f_numero_control, f_anulado
                );
            subReport3.Report = tObj;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.cajaTransaccionDocumentos));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.subReport2 = new DataDynamics.ActiveReports.SubReport();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.subReport3 = new DataDynamics.ActiveReports.SubReport();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
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
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
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
            this.subReport1.CanGrow = false;
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 4F;
            this.subReport1.Left = 0F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0F;
            this.subReport1.Width = 8.5F;
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
            this.subReport2.CanGrow = false;
            this.subReport2.CloseBorder = false;
            this.subReport2.Height = 4F;
            this.subReport2.Left = 0F;
            this.subReport2.Name = "subReport2";
            this.subReport2.Report = null;
            this.subReport2.ReportName = "subReport2";
            this.subReport2.Top = 4F;
            this.subReport2.Width = 8.5F;
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
            this.line1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 4F;
            this.line1.Visible = false;
            this.line1.Width = 8.5F;
            this.line1.X1 = 0F;
            this.line1.X2 = 8.5F;
            this.line1.Y1 = 4F;
            this.line1.Y2 = 4F;
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
            this.subReport3.CanGrow = false;
            this.subReport3.CloseBorder = false;
            this.subReport3.Height = 2.9375F;
            this.subReport3.Left = 0F;
            this.subReport3.Name = "subReport3";
            this.subReport3.Report = null;
            this.subReport3.ReportName = "subReport3";
            this.subReport3.Top = 8F;
            this.subReport3.Width = 8.5F;
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
            this.line2.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 8F;
            this.line2.Visible = false;
            this.line2.Width = 8.5F;
            this.line2.X1 = 0F;
            this.line2.X2 = 8.5F;
            this.line2.Y1 = 8F;
            this.line2.Y2 = 8F;
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
            this.textBox1.Height = 0.1979167F;
            this.textBox1.Left = 0.0625F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "";
            this.textBox1.Text = "0";
            this.textBox1.Top = 7.9375F;
            this.textBox1.Visible = false;
            this.textBox1.Width = 1F;
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
            this.textBox2.Left = 1.125F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "";
            this.textBox2.Text = "0";
            this.textBox2.Top = 7.9375F;
            this.textBox2.Visible = false;
            this.textBox2.Width = 1F;
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
            this.subReport2,
            this.subReport3,
            this.line1,
            this.line2,
            this.textBox1,
            this.textBox2});
            this.groupHeader1.DataField = "id_compuesto";
            this.groupHeader1.Height = 10.948F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.PrintAtBottom = true;
            // 
            // cajaTransaccionDocumentos
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperName = "Factura";
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.5F;
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
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.cajaTransaccionDocumentos_FetchData);
            this.ReportStart += new System.EventHandler(this.cajaTransaccionDocumentos_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private void detail_Format(object sender, EventArgs e)
        {

        }

    }
}