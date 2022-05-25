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

/// <summary>
/// Summary description for liquidacion
/// </summary>
/// 
namespace terrasur
{
    public class liquidacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);


        #region Propiedades
        //Propiedades privadas
        private int _id_liquidacion = 0;
        private int _id_contrato = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private decimal _it = 0;
        private decimal _ddrr = 0;
        private decimal _factor_impuesto = 0;
        private decimal _tipo_cambio = 0;

        //Propiedades públicas
        public int id_liquidacion { get { return _id_liquidacion; } set { _id_liquidacion = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public decimal it { get { return _it; } set { _it = value; } }
        public decimal ddrr { get { return _ddrr; } set { _ddrr = value; } }
        public decimal factor_impuesto { get { return _factor_impuesto; } set { _factor_impuesto = value; } }
        public decimal tipo_cambio { get { return _tipo_cambio; } set { _tipo_cambio = value; } }
        #endregion
        
        #region Constructores
        public liquidacion(int Id_liquidacion)
        {
            _id_contrato = Id_liquidacion;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static decimal DescuentoDpr(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("liquidacion_DescuentoDpr");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (decimal)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static DataTable ListaDescuentoDpr(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("liquidacion_ListaDescuentoDpr");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaServiciosLiquidablesVendidos(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("liquidacion_ListaServiciosLiquidablesVendidos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("liquidacion_RecuperarDatos");
                db1.AddOutParameter(cmd, "id_liquidacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "it", DbType.Double, 11);
                db1.AddOutParameter(cmd, "ddrr", DbType.Double, 11);
                db1.AddOutParameter(cmd, "factor_impuesto", DbType.Double, 11);
                db1.AddOutParameter(cmd, "tipo_cambio", DbType.Double, 14);

                db1.ExecuteNonQuery(cmd);

                _id_liquidacion = (int)db1.GetParameterValue(cmd, "id_liquidacion");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _it = (decimal)(double)db1.GetParameterValue(cmd, "it");
                _ddrr = (decimal)(double)db1.GetParameterValue(cmd, "ddrr");
                _factor_impuesto = (decimal)(double)db1.GetParameterValue(cmd, "factor_impuesto");
                _tipo_cambio = (decimal)(double)db1.GetParameterValue(cmd, "tipo_cambio");
            }
            catch { }
        }
        #endregion

        #region Pago por Liquidación
        public static bool LiquidacionPermitir(int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                DbCommand cmd = db1.GetStoredProcCommand("liquidacion_LiquidacionPermitir");
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public static string Insertar_PagoLiquidacion_VARIOS_PAGOS(int context_id_usuario, int context_id_rol,
        int Id_contrato, int Id_recibocobrador, string Lista_servicios, tmpFormaPago tfp,
        string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar)
        {
            try
            {
                System.Text.StringBuilder tr = new System.Text.StringBuilder();
                tmpFormaPago tfp_aux1 = tmpFormaPago.TmpFormaPagoReplica(tfp);
                foreach (tmpServicio s in tmpServicio.ListaServicio(Lista_servicios))
                {
                    int Id_transaccion = Insertar_PagoLiquidacion(context_id_usuario, context_id_rol,
                        Id_contrato, s.id_servicio, Id_recibocobrador, Cliente_nombre, Cliente_nit, Cliente_guardar,
                        s.unidades, s.precio_unitario, s.precio_total, s.facturar, tfp.dpr);
                    if (Id_transaccion > 0)
                    {
                        forma_pago fp = tmpFormaPago.FormaPagoTransaccion(Id_transaccion, ref tfp_aux1, s.precio_total);
                        //forma_pago fp = tfp.FormaPagoTransaccion(Id_transaccion, s.precio_total);
                        if (fp.Insertar() == true) tr.Append(Id_transaccion.ToString() + ',');
                    }
                }
                return tr.ToString().TrimEnd(',');
            }
            catch { return ""; }
        }

        private static int Insertar_PagoLiquidacion(int context_id_usuario, int context_id_rol,
        int Id_contrato, int Id_servicio, int Id_recibocobrador,
        string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar,
        int Num_unidades, decimal Precio_unidad, decimal Precio_total, bool Facturar, bool Forma_dpr)
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                DbCommand cmd = db1.GetStoredProcCommand("liquidacion_Insertar_PagoLiquidacion");
                db1.AddInParameter(cmd, "p_id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "p_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "p_id_rol", DbType.Int32, context_id_rol);
                db1.AddInParameter(cmd, "p_id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "p_id_servicio", DbType.String, Id_servicio);
                db1.AddInParameter(cmd, "p_id_recibocobrador", DbType.Int32, Id_recibocobrador);

                db1.AddInParameter(cmd, "p_forma_dpr", DbType.Boolean, Forma_dpr);

                db1.AddInParameter(cmd, "p_cliente_nombre", DbType.String, Cliente_nombre);
                db1.AddInParameter(cmd, "p_cliente_nit", DbType.Decimal, Cliente_nit);
                db1.AddInParameter(cmd, "p_cliente_guardar", DbType.Boolean, Cliente_guardar);

                db1.AddInParameter(cmd, "p_num_unidades", DbType.Int32, Num_unidades);
                db1.AddInParameter(cmd, "p_precio_unidad", DbType.Double, Precio_unidad);
                db1.AddInParameter(cmd, "p_precio_total", DbType.Double, Precio_total);
                db1.AddInParameter(cmd, "p_facturar", DbType.Decimal, Facturar);

                db1.AddOutParameter(cmd, "p_id_transaccion", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                int Id_transaccion = (int)db1.GetParameterValue(cmd, "p_id_transaccion");
                return Id_transaccion;
            }
            catch { return 0; }
        }

        #endregion
    }
}