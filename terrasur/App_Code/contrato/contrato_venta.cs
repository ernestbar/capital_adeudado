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
/// Summary description for contrato_venta
/// </summary>
namespace terrasur
{
    public class contrato_venta : contrato
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        
        #region Propiedades
        //Propiedades privadas
        private int _id_lote = 0;
        private decimal _superficie_m2 = 0;
        private decimal _precio_m2_sus = 0;
        private decimal _costo_m2_sus = 0;

        private string _localizacion_nombre = "";
        private string _urbanizacion_nombre = "";
        private string _urbanizacion_nombre_corto = "";
        private string _manzano_codigo = "";
        private string _lote_codigo = "";


        //Propiedades públicas
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public decimal superficie_m2 { get { return _superficie_m2; } set { _superficie_m2 = value; } }
        public decimal precio_m2_sus { get { return _precio_m2_sus; } set { _precio_m2_sus = value; } }
        public decimal costo_m2_sus { get { return _costo_m2_sus; } set { _costo_m2_sus = value; } }

        public string localizacion_nombre { get { return _localizacion_nombre; } }
        public string urbanizacion_nombre { get { return _urbanizacion_nombre; } }
        public string urbanizacion_nombre_corto { get { return _urbanizacion_nombre_corto; } }
        public string manzano_codigo { get { return _manzano_codigo; } }
        public string lote_codigo { get { return _lote_codigo; } }
        #endregion

        #region Constructores
        public contrato_venta(int Id_contrato)
            : base(Id_contrato)
        {
            cvRecuperarDatos();
        }
        public contrato_venta(string Numero)
            : base(Numero)
        {
            cvRecuperarDatos();
        }
        public contrato_venta(int Id_lote, decimal Superficie_m2, decimal Precio_m2_sus, decimal Costo_m2_sus,
            int Id_moneda, string Numero, bool Contado, bool Preferencial,
            decimal Precio, decimal Descuento_porcentaje, decimal Descuento_efectivo, decimal Precio_final,
            decimal Cuota_inicial, int Num_cuotas, decimal Seguro, decimal Mantenimiento_sus, decimal Interes_corriente,
            decimal Interes_penal, decimal Cuota_base, DateTime Fecha_inicio_plan, string Observacion)
            : base(Id_moneda, Numero, Contado, Preferencial,
            Precio, Descuento_porcentaje, Descuento_efectivo, Precio_final,
            Cuota_inicial, Num_cuotas, Seguro, Mantenimiento_sus, Interes_corriente,
            Interes_penal, Cuota_base, Fecha_inicio_plan, Observacion)
        {
            _id_lote = Id_lote;
            _superficie_m2 = Superficie_m2;
            _precio_m2_sus = Precio_m2_sus;
            _costo_m2_sus = Costo_m2_sus;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static string SiguienteNumero()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_venta_SiguienteNumero");
                db1.AddOutParameter(cmd, "num", DbType.String, 50);
                db1.ExecuteNonQuery(cmd);
                return (string)db1.GetParameterValue(cmd, "num");
            }
            catch { return "0"; }
        }

        public static DataTable Lista(int Id_localizacion, int Id_urbanizacion, int Id_manzano, int Id_lote,
    int Id_estado_contrato, int Id_promotor, int Id_lugarcobro, int Por_cobrador,
    bool Fecha_registro_inicio_existe, DateTime Fecha_registro_inicio, bool Fecha_registro_fin_existe, DateTime Fecha_registro_fin,
    bool Fecha_proximo_inicio_existe, DateTime Fecha_proximo_inicio, bool Fecha_proximo_fin_existe, DateTime fecha_proximo_fin)
        {
            //[id_contrato],[fecha_registro],[numero],[estado_contrato],[precio_final],[codigo_moneda]
            //[localizacion_nombre],[urbanizacion_nombre],[manzano_codigo],[lote_codigo]
            //[promotor],[cobrador],[cobro_lugar],[cobro_direccion],[cobro_zona],[fecha_proximo_pago]
            DbCommand cmd = db1.GetStoredProcCommand("contrato_venta_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);

            db1.AddInParameter(cmd, "id_estado_contrato", DbType.Int32, Id_estado_contrato);
            db1.AddInParameter(cmd, "id_promotor", DbType.Int32, Id_promotor);
            db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, Id_lugarcobro);
            db1.AddInParameter(cmd, "por_cobrador", DbType.Int32, Por_cobrador);

            db1.AddInParameter(cmd, "fecha_registro_inicio_existe", DbType.Boolean, Fecha_registro_inicio_existe);
            db1.AddInParameter(cmd, "fecha_registro_inicio", DbType.DateTime, Fecha_registro_inicio);
            db1.AddInParameter(cmd, "fecha_registro_fin_existe", DbType.Boolean, Fecha_registro_fin_existe);
            db1.AddInParameter(cmd, "fecha_registro_fin", DbType.DateTime, Fecha_registro_fin);

            db1.AddInParameter(cmd, "fecha_proximo_inicio_existe", DbType.Boolean, Fecha_proximo_inicio_existe);
            db1.AddInParameter(cmd, "fecha_proximo_inicio", DbType.DateTime, Fecha_proximo_inicio);
            db1.AddInParameter(cmd, "fecha_proximo_fin_existe", DbType.Boolean, Fecha_proximo_fin_existe);
            db1.AddInParameter(cmd, "fecha_proximo_fin", DbType.DateTime, fecha_proximo_fin);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static void DatosWebPart(ref int Num_preasignado, ref int Num_vigente, ref int Num_liquidado, ref int Num_revertido)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_venta_DatosWebPart");
                db1.AddOutParameter(cmd, "num_preasignado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_vigente", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_liquidado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_revertido", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                Num_preasignado = (int)db1.GetParameterValue(cmd, "num_preasignado");
                Num_vigente = (int)db1.GetParameterValue(cmd, "num_vigente");
                Num_liquidado = (int)db1.GetParameterValue(cmd, "num_liquidado");
                Num_revertido = (int)db1.GetParameterValue(cmd, "num_revertido");
            }
            catch { }
        }

        #endregion

        #region Métodos que requieren constructor
        private void cvRecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_venta_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, base.id_contrato);
                db1.AddOutParameter(cmd, "id_lote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "superficie_m2", DbType.Double, 14);
                db1.AddOutParameter(cmd, "precio_m2_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "costo_m2_sus", DbType.Double, 14);

                db1.AddOutParameter(cmd, "localizacion_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "urbanizacion_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "urbanizacion_nombre_corto", DbType.String, 50);
                db1.AddOutParameter(cmd, "manzano_codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "lote_codigo", DbType.String, 50);
                db1.ExecuteNonQuery(cmd);

                _id_lote = (int)db1.GetParameterValue(cmd, "id_lote");
                _superficie_m2 = (decimal)(double)db1.GetParameterValue(cmd, "superficie_m2");
                _precio_m2_sus = (decimal)(double)db1.GetParameterValue(cmd, "precio_m2_sus");
                _costo_m2_sus = (decimal)(double)db1.GetParameterValue(cmd, "costo_m2_sus");

                _localizacion_nombre = (string)db1.GetParameterValue(cmd, "localizacion_nombre");
                _urbanizacion_nombre = (string)db1.GetParameterValue(cmd, "urbanizacion_nombre");
                _urbanizacion_nombre_corto = (string)db1.GetParameterValue(cmd, "urbanizacion_nombre_corto");
                _manzano_codigo = (string)db1.GetParameterValue(cmd, "manzano_codigo");
                _lote_codigo = (string)db1.GetParameterValue(cmd, "lote_codigo");
            }
            catch { }
        }

        public bool cvInsertar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_venta_Insertar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, base.id_contrato);
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, this._id_lote);
                db1.AddInParameter(cmd, "superficie_m2", DbType.Decimal, this._superficie_m2);
                db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, this._precio_m2_sus);
                db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, this._costo_m2_sus);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }


        public bool CambiarLote(int Id_nuevo_lote, int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_venta_CambiarLote");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, base.id_contrato);
                db1.AddInParameter(cmd, "nuevo_id_lote", DbType.Int32, Id_nuevo_lote);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                contrato.RectificarCuotaBase(base.id_contrato);
                return true;
            }
            catch { return false; }
        }

        #endregion
    }
}
