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
/// Summary description for recibo
/// </summary>
namespace terrasur
{
    public class recibo_gastos
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_recibogastos = 0;
        private int _id_usuario = 0;
        private DateTime _fecha;
        private string _concepto = "";
        private string _entregado = "";
        private decimal _monto_sus = 0;
        private decimal _monto_bs = 0;

        private string _usuario_nombre = "";
        //Propiedades públicas
        public int id_recibogastos { get { return _id_recibogastos; } set { _id_recibogastos = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string concepto { get { return _concepto; } set { _concepto = value; } }
        public string entregado { get { return _entregado; } set { _entregado = value; } }
        public decimal monto_sus { get { return _monto_sus; } set { _monto_sus = value; } }
        public decimal monto_bs { get { return _monto_bs; } set { _monto_bs = value; } }

        public string usuario_nombre { get { return _usuario_nombre; } }
        #endregion

        #region Constructores
        public recibo_gastos(int Id_recibogastos)
        {
            _id_recibogastos = Id_recibogastos;
            RecuperarDatos();
        }
        public recibo_gastos(int Id_usuario, DateTime Fecha, string Concepto, string Entregado, decimal Monto_sus, decimal Monto_bs)
        {
            _id_usuario = Id_usuario;
            _fecha = Fecha;
            _concepto = Concepto;
            _entregado = Entregado;
            _monto_sus = Monto_sus;
            _monto_bs = Monto_bs;
        }
        public recibo_gastos(int Id_recibogastos, int Id_usuario, DateTime Fecha, string Concepto, string Entregado, decimal Monto_sus, decimal Monto_bs)
        {
            _id_recibogastos = Id_recibogastos;
            _id_usuario = Id_usuario;
            _fecha = Fecha;
            _concepto = Concepto;
            _entregado = Entregado;
            _monto_sus = Monto_sus;
            _monto_bs = Monto_bs;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            //[id_recibogastos],[usuario],[fecha],[concepto],[entregado],[monto_sus],[monto_bs],[tipo_cambio]
            DbCommand cmd = db1.GetStoredProcCommand("recibo_gastos_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteRecaudacion(int Id_sucursal, DateTime Fecha_inicio, DateTime Fecha_fin, int Formapago, string Id_negocio, int Id_moneda, bool Consolidado)
        {
            //[orden_sucursal],[sucursal],[orden_negocio],[negocio],[cuotas_inicial],[seguro],[mantenimiento],[interes],[capital],[servicios],[pago_contado],[total_ingresos],[gastos],[total_general]
            DbCommand cmd = db1.GetStoredProcCommand("caja_ReporteRecaudacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "formapago", DbType.Int32, Formapago);
            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);

            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            db1.AddInParameter(cmd, "consolidado", DbType.Boolean, Consolidado);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_gastos_RecuperarDatos");
                db1.AddInParameter(cmd, "id_recibogastos", DbType.Int32, _id_recibogastos);

                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "concepto", DbType.String, 200);
                db1.AddOutParameter(cmd, "entregado", DbType.String, 100);
                db1.AddOutParameter(cmd, "monto_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "monto_bs", DbType.Double, 14);

                db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 150);

                db1.ExecuteNonQuery(cmd);

                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _concepto = (string)db1.GetParameterValue(cmd, "concepto");
                _entregado = (string)db1.GetParameterValue(cmd, "entregado");
                _monto_sus = (decimal)(double)db1.GetParameterValue(cmd, "monto_sus");
                _monto_bs = (decimal)(double)db1.GetParameterValue(cmd, "monto_bs");

                _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_gastos_Insertar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "concepto", DbType.String, _concepto);
                db1.AddInParameter(cmd, "entregado", DbType.String, _entregado);
                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, _monto_bs);

                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_recibogastos = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_gastos_Actualizar");
                db1.AddInParameter(cmd, "id_recibogastos", DbType.Int32, _id_recibogastos);

                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "concepto", DbType.String, _concepto);
                db1.AddInParameter(cmd, "entregado", DbType.String, _entregado);
                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, _monto_bs);

                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_gastos_Eliminar");
                db1.AddInParameter(cmd, "id_recibogastos", DbType.Int32, _id_recibogastos);

                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}