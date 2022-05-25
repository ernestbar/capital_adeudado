using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic; // Facturacion Sintesis

/// <summary>
/// Summary description for servicio_vendido
/// </summary>
/// 
namespace terrasur
{
    public class servicio_vendido
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);


        #region Propiedades
        // Propiedades privadas
        private int _id_serviciovendido = 0;
        private int _id_servicio = 0;
        private int _id_cliente = 0;
        private int _id_transaccion = 0;
        private int _id_contrato = 0;
        private int _id_liquidacion = 0;
        private DateTime _fecha = DateTime.Now;
        private int _num_unidades = 0;
        private decimal _precio_unidad = 0;
        private decimal _precio_total = 0;
        private bool _facturar;
        private bool _anulado;
        private string _otros = "";
        // Propiedades públicas
        public int id_serviciovendido { get { return _id_serviciovendido; } set { _id_serviciovendido = value; } }
        public int id_servicio { get { return _id_servicio; } set { _id_servicio = value; } }
        public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_liquidacion { get { return _id_liquidacion; } set { _id_liquidacion = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int num_unidades { get { return _num_unidades; } set { _num_unidades = value; } }
        public decimal precio_unidad { get { return _precio_unidad; } set { _precio_unidad = value; } }
        public decimal precio_total { get { return _precio_total; } set { _precio_total = value; } }
        public bool facturar { get { return _facturar; } set { _facturar = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }
        public string otros { get { return _otros; } set { _otros = value; } }
        #endregion

        #region Constructores
        public servicio_vendido(int Id_serviciovendido)
        {
            _id_serviciovendido = Id_serviciovendido;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaLiquidacionContrato(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_ListaLiquidacionContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaVendidosPorContrato(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_ListaVendidosPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaVendidosNoClientes(string Permiso)
        {
            DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_ListaVendidosNoClientes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "permiso", DbType.String, Permiso);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static int IdUltimoServicioVendido(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_IdUltimoServicioVendido");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                if ((int)db1.ExecuteScalar(cmd) > 0) return (int)db1.ExecuteScalar(cmd);
                else return 0;
            }
            catch { return 0; }
        }
        public static int IdPorTransaccion(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_IdPorTransaccion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static bool PermitirAnular(int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_PermitirAnular");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static bool Anulable(int Id_serviciovendido, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_Anulable");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_serviciovendido", DbType.Int32, Id_serviciovendido);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public static bool Anular(int Id_serviciovendido, int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_Anular");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_serviciovendido", DbType.Int32, Id_serviciovendido);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0)
                {
                    //////////////////////////    integracion odoo     /////////////////////////////
                    //servicio_vendido serven = new servicio_vendido(Id_serviciovendido);
                    //servicio serv = new servicio(serven.id_servicio);
                    //forma_pago fpago = new forma_pago(serven.id_transaccion);
                    //tipo_cambio tc = new tipo_cambio(DateTime.Now);




                    //float otro_serv_facturado = 0;
                    //float otro_serv_sin_factura = 0;
                    //string tipo_operacion = "";
                    //bool efectivo = true;
                    //decimal precio_total_bs = 0;
                    //transaccion tran = new transaccion(serven.id_transaccion);
                    //if (tran.id_moneda == 1)
                    //{  precio_total_bs = Math.Round(serven.precio_total * tc.compra, 2); }
                    //else
                    //{ precio_total_bs = Math.Round(serven.precio_total, 2); }

                    //if (fpago.dpr == true)
                    //{
                    //    efectivo = false;
                    //    if (serven.facturar == true)
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS FACTURADOS DPR";
                    //        otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //    else
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS NO FACTURADOS DPR";
                    //        otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //}
                    //else
                    //{
                    //    efectivo = true;
                    //    if (serven.facturar == true)
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS FACTURADOS EFECTIVO";
                    //        otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //    else
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS NO FACTURADOS EFECTIVO";
                    //        otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //}

                    //contrato ob_con = new contrato(Id_contrato);
                    //contrato_venta ob_cv = new contrato_venta(Id_contrato);
                    //lote lot = new lote(ob_cv.id_lote);
                    //negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                    //string nombre_urbanizacion;
                    //nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    //if (neg.id_negocio == 3)
                    //{
                    //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //    ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                    //    string resultado2 = obj2.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", serven.id_transaccion.ToString(), 0, true, tipo_operacion, 
                    //        0, true, 0, true, 0, true, 0, true, 0, true, 0, true, otro_serv_facturado, true, otro_serv_sin_factura, true, 
                    //        lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, serv.nombre, true, true, context_id_usuario, 
                    //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);
                    //}


                    return true;
                }
                else return false;
            }
            catch { return false; }
        }
        public static bool AnularServicioNoCliente(int Id_serviciovendido, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_AnularServicioNoCliente");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_serviciovendido", DbType.Int32, Id_serviciovendido);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0)
                {
                    //////////////////////////    integracion odoo     /////////////////////////////
                    //string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //servicio_vendido serven = new servicio_vendido(Id_serviciovendido);
                    //servicio serv = new servicio(serven.id_servicio);
                    //forma_pago fpago = new forma_pago(serven.id_transaccion);
                    //cliente cli = new cliente(serven.id_cliente);
                    //transaccion tran=new transaccion(serven.id_transaccion);
                    //tipo_cambio tc = new tipo_cambio(DateTime.Now);

                    //float otro_serv_facturado = 0;
                    //float otro_serv_sin_factura = 0;
                    //string tipo_operacion = "";
                    //string nombre_urbanizacion = "NO CLIENTE";

                    //decimal precio_total_bs = 0;
                    //if (tran.id_moneda == 1)
                    //{ precio_total_bs = Math.Round(serven.precio_total * tc.compra, 2); }
                    //else
                    //{ precio_total_bs = Math.Round(serven.precio_total, 2); }

                    //bool efectivo = true;
                    //if (fpago.dpr == true)
                    //{
                    //    efectivo = false;
                    //    if (serven.facturar == true)
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS FACTURADOS DPR";
                    //        otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //    else
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS NO FACTURADOS DPR";
                    //        otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //}
                    //else
                    //{
                    //    efectivo = true;
                    //    if (serven.facturar == true)
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS FACTURADOS EFECTIVO";
                    //        otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //    else
                    //    {
                    //        tipo_operacion = "OTROS SERVICIOS NO FACTURADOS EFECTIVO";
                    //        otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                    //    }
                    //}




                    //ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();

                    //string resultado2 = obj2.insertarMovimientosOdoo(3, true, cli.paterno.Trim() + " " + cli.materno.Trim() + " " + cli.nombres.Trim(), "", serven.id_transaccion.ToString(), 0, true, tipo_operacion, 
                    //    0, true, 0, true, 0, true, 0, true, 0, true, 0, true, otro_serv_facturado, true, otro_serv_sin_factura, true, 
                    //    "1000", "", "", efectivo, true, nombre_urbanizacion, serv.nombre, true, true, context_id_usuario, 
                    //    true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);


                    return true;
                }
                else return false;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_serviciovendido", DbType.Int32, _id_serviciovendido);
                db1.AddOutParameter(cmd, "id_servicio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_cliente", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_liquidacion", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "num_unidades", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "precio_unidad", DbType.Double, 14);
                db1.AddOutParameter(cmd, "precio_total", DbType.Double, 14);

                db1.AddOutParameter(cmd, "facturar", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);

                db1.ExecuteNonQuery(cmd);

                _id_servicio = (int)db1.GetParameterValue(cmd, "id_servicio");
                _id_cliente = (int)db1.GetParameterValue(cmd, "id_cliente");
                _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_liquidacion = (int)db1.GetParameterValue(cmd, "id_liquidacion");

                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _num_unidades = (int)db1.GetParameterValue(cmd, "num_unidades");
                _precio_unidad = (decimal)(double)db1.GetParameterValue(cmd, "precio_unidad");
                _precio_total = (decimal)(double)db1.GetParameterValue(cmd, "precio_total");
                _facturar = (bool)db1.GetParameterValue(cmd, "facturar");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");

            }
            catch { }
        }
        #endregion

        #region Pago por otros servicios
        private static int Insertar_PagoOtroServicio(int context_id_usuario, int context_id_rol,
            int Id_contrato, int Id_servicio, int Id_recibocobrador,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar,
            int Num_unidades, decimal Precio_unidad, decimal Precio_total, bool Facturar, bool Forma_dpr, string Otros)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_Insertar_PagoOtroServicio");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "p_id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "p_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "p_id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "p_id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "p_id_servicio", DbType.Int32, Id_servicio);
                db1.AddInParameter(cmd, "p_id_recibocobrador", DbType.Int32, Id_recibocobrador);

                db1.AddInParameter(cmd, "p_forma_dpr", DbType.Boolean, Forma_dpr);

                db1.AddInParameter(cmd, "p_cliente_nombre", DbType.String, Cliente_nombre);
                db1.AddInParameter(cmd, "p_cliente_nit", DbType.Decimal, Cliente_nit);
                db1.AddInParameter(cmd, "p_cliente_guardar", DbType.Boolean, Cliente_guardar);

                db1.AddInParameter(cmd, "p_num_unidades", DbType.Int32, Num_unidades);
                db1.AddInParameter(cmd, "p_precio_unidad", DbType.Double, Precio_unidad);
                db1.AddInParameter(cmd, "p_precio_total", DbType.Double, Precio_total);
                db1.AddInParameter(cmd, "p_facturar", DbType.Boolean, Facturar);
                db1.AddInParameter(cmd, "p_otros", DbType.String, Otros);
                db1.AddOutParameter(cmd, "p_id_transaccion", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                int Id_transaccion = (int)db1.GetParameterValue(cmd, "p_id_transaccion");

                //////////////////////////    integracion odoo     /////////////////////////////
                //tipo_cambio tc = new tipo_cambio(DateTime.Now);
                //decimal precio_total_bs = 0;
                //transaccion tran = new transaccion(Id_transaccion);
                //if (tran.id_moneda == 1)
                //{ precio_total_bs = Math.Round(Precio_total * tc.compra, 2); }
                //else
                //{ precio_total_bs = Math.Round(Precio_total, 2); }

                //if (Id_transaccion > 0)
                //{
                //    servicio serv=new servicio(Id_servicio);
                //    float otro_serv_facturado=0;
                //    float otro_serv_sin_factura=0;
                //    string tipo_operacion = "";
                //    bool efectivo = true;
                //    if (Forma_dpr == true)
                //    {
                //        efectivo = false;

                //        if (Facturar == true)
                //        {
                //            tipo_operacion = "OTROS SERVICIOS FACTURADOS DPR";
                //            otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //        else
                //        {
                //            tipo_operacion = "OTROS SERVICIOS NO FACTURADOS DPR";
                //            otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //    }
                //    else
                //    {
                //        efectivo = true;
                //        if (Facturar == true)
                //        {
                //            tipo_operacion = "OTROS SERVICIOS FACTURADOS EFECTIVO";
                //            otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //        else
                //        {
                //            tipo_operacion = "OTROS SERVICIOS NO FACTURADOS EFECTIVO";
                //            otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //    }
                //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                //    contrato ob_con = new contrato(Id_contrato);
                //    contrato_venta ob_cv = new contrato_venta(Id_contrato);
                //    lote lot = new lote(ob_cv.id_lote);
                //    negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                //    if (neg.id_negocio == 3)
                //    {
                //        string nombre_urbanizacion;
                //        nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();

                //        ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                //        string resultado2 = obj2.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_transaccion.ToString(), 0, true, tipo_operacion, 
                //            0, true, 0, true, 0, true, 0, true, 0, true, 0, true, otro_serv_facturado, true, otro_serv_sin_factura, true, 
                //            lot.id_urbanizacion.ToString(), "", "", efectivo, true, nombre_urbanizacion, serv.nombre, false, true, context_id_usuario, 
                //            true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);
                //    }

                //}
                return Id_transaccion;
            }
            catch { return 0; }
        }

        private static int Insertar_PagoOtroServicioNoCliente(int context_id_usuario, int context_id_rol,
            int Id_servicio, int Id_recibocobrador,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar,
            int Num_unidades, decimal Precio_unidad, decimal Precio_total, bool Facturar, bool Forma_dpr,
            int Id_cliente)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                DbCommand cmd = db1.GetStoredProcCommand("servicio_vendido_Insertar_PagoOtroServicioNoCliente");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "p_id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "p_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "p_id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "p_id_servicio", DbType.Int32, Id_servicio);
                db1.AddInParameter(cmd, "p_id_recibocobrador", DbType.Int32, Id_recibocobrador);

                db1.AddInParameter(cmd, "p_forma_dpr", DbType.Boolean, Forma_dpr);

                //Para el cliente transitorios
                db1.AddInParameter(cmd, "p_id_cliente", DbType.Int32, Id_cliente);

                //Para la factura
                db1.AddInParameter(cmd, "p_cliente_nombre", DbType.String, Cliente_nombre);
                db1.AddInParameter(cmd, "p_cliente_nit", DbType.Decimal, Cliente_nit);
                db1.AddInParameter(cmd, "p_cliente_guardar", DbType.Boolean, Cliente_guardar);

                db1.AddInParameter(cmd, "p_num_unidades", DbType.Int32, Num_unidades);
                db1.AddInParameter(cmd, "p_precio_unidad", DbType.Double, Precio_unidad);
                db1.AddInParameter(cmd, "p_precio_total", DbType.Double, Precio_total);
                db1.AddInParameter(cmd, "p_facturar", DbType.Boolean, Facturar);

                db1.AddOutParameter(cmd, "p_id_transaccion", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                int Id_transaccion = (int)db1.GetParameterValue(cmd, "p_id_transaccion");
                //tipo_cambio tc = new tipo_cambio(DateTime.Now);
                //decimal precio_total_bs = 0;
                //transaccion tran = new transaccion(Id_transaccion);
                //if (tran.id_moneda == 1)
                //{ precio_total_bs = Math.Round(Precio_total * tc.compra, 2); }
                //else
                //{ precio_total_bs = Math.Round(Precio_total, 2); }
                //////////////////////////    integracion odoo     /////////////////////////////
                //if (Id_transaccion > 0)
                //{
                //    servicio serv = new servicio(Id_servicio);
                //    float otro_serv_facturado = 0;
                //    float otro_serv_sin_factura = 0;
                //    bool efectivo = true;
                //    string tipo_operacion = "";
                //    if (Forma_dpr == true)
                //    {
                //        efectivo = false;
                //        if (Facturar == true)
                //        {
                //            tipo_operacion = "OTROS SERVICIOS FACTURADOS DPR";
                //            otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //        else
                //        {
                //            tipo_operacion = "OTROS SERVICIOS NO FACTURADOS DPR";
                //            otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //    }
                //    else
                //    {
                //        efectivo = true;
                //        if (Facturar == true)
                //        {
                //            tipo_operacion = "OTROS SERVICIOS FACTURADOS EFECTIVO";
                //            otro_serv_facturado = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //        else
                //        {
                //            tipo_operacion = "OTROS SERVICIOS NO FACTURADOS EFECTIVO";
                //            otro_serv_sin_factura = float.Parse(precio_total_bs.ToString("F2"));
                //        }
                //    }

                //    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;


                //    ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                //    string resultado2 = obj2.insertarMovimientosOdoo(3, true, "0", "", Id_transaccion.ToString(), 0, true, tipo_operacion, 
                //        0, true, 0, true, 0, true, 0, true, 0, true, 0, true, otro_serv_facturado, true, otro_serv_sin_factura, true,
                //        "1000", "", "", efectivo, true, Cliente_nombre, serv.nombre, false, true, context_id_usuario, 
                //        true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                //}
                return Id_transaccion;
            }
            catch { return 0; }
        }

        public static string Insertar_PagoOtroServicio_VARIOS_PAGOS(int context_id_usuario, int context_id_rol,
            int Id_contrato, int Id_recibocobrador, string Lista_servicios, tmpFormaPago tfp,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                System.Text.StringBuilder tr = new System.Text.StringBuilder();

                tmpFormaPago tfp_aux1 = tmpFormaPago.TmpFormaPagoReplica(tfp);
                foreach (tmpServicio s in tmpServicio.ListaServicio(Lista_servicios))
                {
                    int Id_transaccion = Insertar_PagoOtroServicio(context_id_usuario, context_id_rol,
                        Id_contrato, s.id_servicio, Id_recibocobrador, Cliente_nombre, Cliente_nit, Cliente_guardar,
                        s.unidades, s.precio_unitario, s.precio_total, s.facturar, tfp.dpr, s.otros);
                    if (Id_transaccion > 0)
                    {
                        forma_pago fp = tmpFormaPago.FormaPagoTransaccion(Id_transaccion, ref tfp_aux1, s.precio_total);
                        //forma_pago fp = tfp.FormaPagoTransaccion(Id_transaccion, s.precio_total);
                        if (fp.Insertar() == true) { tr.Append(Id_transaccion.ToString() + ','); }
                        else { return ""; }
                    }
                    else { return ""; }
                }
                return tr.ToString().TrimEnd(',');
            }
            catch { return ""; }
        }

        // Facturacion Sintesis
        public static List<tmpServicio2> Insertar_PagoOtroServicio_VARIOS_PAGOS2(int context_id_usuario, int context_id_rol,
            int Id_contrato, int Id_recibocobrador, string Lista_servicios, tmpFormaPago tfp,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                List<tmpServicio2> servicios = new List<tmpServicio2>();

                tmpFormaPago tfp_aux1 = tmpFormaPago.TmpFormaPagoReplica(tfp);
                foreach (tmpServicio s in tmpServicio.ListaServicio(Lista_servicios))
                {
                    int Id_transaccion = Insertar_PagoOtroServicio(context_id_usuario, context_id_rol,
                        Id_contrato, s.id_servicio, Id_recibocobrador, Cliente_nombre, Cliente_nit, Cliente_guardar,
                        s.unidades, s.precio_unitario, s.precio_total, s.facturar, tfp.dpr, s.otros);
                    if (Id_transaccion > 0)
                    {
                        forma_pago fp = tmpFormaPago.FormaPagoTransaccion(Id_transaccion, ref tfp_aux1, s.precio_total);
                        //forma_pago fp = tfp.FormaPagoTransaccion(Id_transaccion, s.precio_total);
                        if (fp.Insertar() == true) { 
                            tmpServicio2 serv = new tmpServicio2();
                            serv.id_transaccion = Id_transaccion;
                            serv.id_servicio = s.id_servicio;
                            serv.nombre = s.nombre;
                            serv.unidades = s.unidades;
                            serv.precio_unitario = s.precio_unitario;
                            serv.precio_total = s.precio_total;
                            serv.facturar = s.facturar;
                            serv.otros = s.otros;
                            servicios.Add(serv);
                        }
                        else {
                            return new List<tmpServicio2>(); 
                        }
                    }
                    else
                    {
                        return new List<tmpServicio2>();
                    }
                }
                return servicios;
            }
            catch { 
                return new List<tmpServicio2>(); 
            }
        }
        //

        public static string Insertar_PagoOtroServicioNoClientes_VARIOS_PAGOS(int context_id_usuario, int context_id_rol,
            int Id_recibocobrador, string Lista_servicios, tmpFormaPago tfp,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar, string Ci, int Id_cliente, int Id_lugarcedula, string Paterno, string Materno, string Nombres, string Nit,
            string Celular, string Email)
        {
            try
            {
                System.Text.StringBuilder tr = new System.Text.StringBuilder();
                //SE INGRESA EL CLIENTE EN CASO DE NO EXISTIR
                if (Id_cliente == 0)
                {
                    cliente c = new cliente(Id_lugarcedula, 0, Ci, Nit, Nombres, Paterno, Materno, DateTime.Now, Celular, "", Email, "", "", "", 0, "", "", 0, true);
                    c.Insertar(context_id_usuario);
                    Id_cliente = c.id_cliente;
                }
                tmpFormaPago tfp_aux2 = tmpFormaPago.TmpFormaPagoReplica(tfp);
                foreach (tmpServicio s in tmpServicio.ListaServicio(Lista_servicios))
                {
                    int Id_transaccion = Insertar_PagoOtroServicioNoCliente(context_id_usuario, context_id_rol,
                        s.id_servicio, Id_recibocobrador, Cliente_nombre, Cliente_nit, Cliente_guardar,
                        s.unidades, s.precio_unitario, s.precio_total, s.facturar, tfp.dpr, Id_cliente);
                    if (Id_transaccion > 0)
                    {
                        forma_pago fp = tmpFormaPago.FormaPagoTransaccion(Id_transaccion, ref tfp_aux2, s.precio_total);
                        //forma_pago fp = tfp.FormaPagoTransaccion(Id_transaccion, s.precio_total);
                        if (fp.Insertar() == true) { tr.Append(Id_transaccion.ToString() + ','); }
                        else { return ""; }
                    }
                    else { return ""; }
                }
                return tr.ToString().TrimEnd(',');
            }
            catch { return ""; }
        }

        public static List<tmpServicio2> Insertar_PagoOtroServicioNoClientes_VARIOS_PAGOS2(int context_id_usuario, int context_id_rol,
            int Id_recibocobrador, string Lista_servicios, tmpFormaPago tfp,
            string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar, string Ci, int Id_cliente, int Id_lugarcedula, string Paterno, string Materno, string Nombres, string Nit,
            string Celular, string Email)
        {
            try
            {
                List<tmpServicio2> servicios = new List<tmpServicio2>();

                //SE INGRESA EL CLIENTE EN CASO DE NO EXISTIR
                if (Id_cliente == 0)
                {
                    cliente c = new cliente(Id_lugarcedula, 0, Ci, Nit, Nombres, Paterno, Materno, DateTime.Now, Celular, "", Email, "", "", "", 0, "", "", 0, true);
                    c.Insertar(context_id_usuario);
                    Id_cliente = c.id_cliente;
                }
                tmpFormaPago tfp_aux2 = tmpFormaPago.TmpFormaPagoReplica(tfp);
                foreach (tmpServicio s in tmpServicio.ListaServicio(Lista_servicios))
                {
                    int Id_transaccion = Insertar_PagoOtroServicioNoCliente(context_id_usuario, context_id_rol,
                        s.id_servicio, Id_recibocobrador, Cliente_nombre, Cliente_nit, Cliente_guardar,
                        s.unidades, s.precio_unitario, s.precio_total, s.facturar, tfp.dpr, Id_cliente);
                    if (Id_transaccion > 0)
                    {
                        forma_pago fp = tmpFormaPago.FormaPagoTransaccion(Id_transaccion, ref tfp_aux2, s.precio_total);
                        //forma_pago fp = tfp.FormaPagoTransaccion(Id_transaccion, s.precio_total);
                        if (fp.Insertar() == true) {
                            tmpServicio2 serv = new tmpServicio2();
                            serv.id_transaccion = Id_transaccion;
                            serv.id_servicio = s.id_servicio;
                            serv.nombre = s.nombre;
                            serv.unidades = s.unidades;
                            serv.precio_unitario = s.precio_unitario;
                            serv.precio_total = s.precio_total;
                            serv.facturar = s.facturar;
                            serv.otros = s.otros;
                            serv.id_cliente = Id_cliente;
                            servicios.Add(serv);
                        }
                        else {
                            return new List<tmpServicio2>();
                        }
                    }
                    else {
                        return new List<tmpServicio2>(); 
                    }
                }
                return servicios;
            }
            catch {
                return new List<tmpServicio2>(); 
            }
        }
        #endregion
    }
}