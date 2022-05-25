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
namespace terrasur
{
    public class cuentaContable
    {
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_cuentacontable = 0;
        private int _id_operacioncartera = 0;
        private string _codigo_cuenta = "";
        private string _nombre_cuenta = "";
        private string _descripcion_cuenta = "";
        private bool _debe = true;
        private bool _haber = true;
        private bool _activo = true;
        private int _usuario = 0;
        private decimal _porcentaje = 1;

        private string _operacion_cartera = "";
        //Propiedades públicas
        public int id_cuentacontable { get { return _id_cuentacontable; } set { _id_cuentacontable = value; } }
        public int id_operacioncartera { get { return _id_operacioncartera; } set { _id_operacioncartera = value; } }
        public string codigo_cuenta { get { return _codigo_cuenta; } set { _codigo_cuenta = value; } }
        public string nombre_cuenta { get { return _nombre_cuenta; } set { _nombre_cuenta = value; } }
        public string descripcion_cuenta { get { return _descripcion_cuenta; } set { _descripcion_cuenta = value; } }

        public bool debe { get { return _debe; } set { _debe = value; } }
        public bool haber { get { return _haber; } set { _haber = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public int usuario { get { return _usuario; } set { _usuario = value; } }

        public decimal porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public string operacion_cartera { get { return _operacion_cartera; } set { _operacion_cartera = value; } }
        #endregion

        #region Constructores
        public cuentaContable(int Id_cuentacontable)
        {
            _id_cuentacontable = Id_cuentacontable;
            RecuperarDatos();
        }

        //public cuentaContable(string Nombre)
        //{
        //    _nombre = Nombre;
        //    RecuperarDatosXnombre();
        //}
        public cuentaContable(int Id_cuentacontable,int Id_operacioncartera,string Codigo_cuenta,string Nombre_cuenta, string Descripcion_cuenta,
            bool Debe,bool Haber,bool Activo, int Usuario, decimal Porcentaje)
        {
            _id_cuentacontable = Id_cuentacontable;
            _id_operacioncartera = Id_operacioncartera;
            _codigo_cuenta = Codigo_cuenta;
            _nombre_cuenta = Nombre_cuenta;
            _descripcion_cuenta = Descripcion_cuenta;
            _debe = Debe;
            _haber = Haber;
            _activo = Activo;
            _usuario = Usuario;
            _porcentaje = Porcentaje;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_operacioncartera)
        {
            //[id_lote],[id_usuario],[fecha_registro],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[anterior_propietario],[num_partida]
            DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_operacioncartera", DbType.Int32, Id_operacioncartera);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        //public static DataTable ListaDisponible(int Id_manzano)
        //{
        //    //[id_lote],[codigo]
        //    DbCommand cmd = db1.GetStoredProcCommand("lote_ListaDisponible");
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}
        //public static DataTable ListaContratos(int Id_lote)
        //{
        //    //[id_contrato],[numero_contrato],[descrip]
        //    DbCommand cmd = db1.GetStoredProcCommand("lote_ListaContratos");
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static bool VerificarCodigo(bool Inserta, int Id_manzano, int Id_lote, string Codigo)
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("lote_VerificarCodigo");
        //        db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
        //        db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
        //        db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
        //        db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
        //        if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
        //        else { return false; }
        //    }
        //    catch { return true; }
        //}

        //public static int Buscar(int Id_urbanizacion, bool Por_codigo_lote, string Codigo_numero)
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("lote_Buscar");
        //        db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
        //        db1.AddInParameter(cmd, "por_codigo_lote", DbType.Boolean, Por_codigo_lote);
        //        db1.AddInParameter(cmd, "codigo_numero", DbType.String, Codigo_numero);
        //        return (int)db1.ExecuteScalar(cmd);
        //    }
        //    catch { return 0; }
        //}
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_RecuperarDatos");
                db1.AddInParameter(cmd, "id_cuentacontable", DbType.Int32, _id_cuentacontable);
                db1.AddOutParameter(cmd, "id_operacionbancaria", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo_cuenta", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_cuenta", DbType.String, 300);
                db1.AddOutParameter(cmd, "descripcion_cuenta", DbType.String, 1000);
                db1.AddOutParameter(cmd, "debe", DbType.Boolean, 1);
                db1.AddOutParameter(cmd, "haber", DbType.Boolean, 1);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 1);
                db1.AddOutParameter(cmd, "usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "operacion_cartera", DbType.String, 200);

                db1.ExecuteNonQuery(cmd);
                _id_operacioncartera = (int)db1.GetParameterValue(cmd, "id_operacionbancaria");
                _codigo_cuenta = (string)db1.GetParameterValue(cmd, "codigo_cuenta");
                _nombre_cuenta = (string)db1.GetParameterValue(cmd, "nombre_cuenta");
                _descripcion_cuenta = (string)db1.GetParameterValue(cmd, "descripcion_cuenta");
                _debe = (bool)db1.GetParameterValue(cmd, "debe");
                _haber = (bool)db1.GetParameterValue(cmd, "haber");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _usuario = (int)db1.GetParameterValue(cmd, "usuario");
                _porcentaje = (decimal)db1.GetParameterValue(cmd, "porcentaje");
                _operacion_cartera =(string)db1.GetParameterValue(cmd, "operacion_cartera");
            }
            catch { }
        }

      
        public bool Insertar()
        {

            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_Insertar");
                db1.AddInParameter(cmd, "id_operacioncartera", DbType.Int32, _id_operacioncartera);
                db1.AddInParameter(cmd, "codigo_cuenta", DbType.String, _codigo_cuenta);
                db1.AddInParameter(cmd, "nombre_cuenta", DbType.String, _nombre_cuenta);
                db1.AddInParameter(cmd, "descripcion_cuenta", DbType.String, _descripcion_cuenta);
                db1.AddInParameter(cmd, "debe", DbType.Boolean, _debe);
                db1.AddInParameter(cmd, "haber", DbType.Boolean, _haber);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
                db1.AddInParameter(cmd, "porcentaje", DbType.Decimal, _porcentaje);
                _id_operacioncartera = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            
            catch (System.Exception ex) { return false; }

        }


        public bool Actualizar()
        {

            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_Actualizar");
                db1.AddInParameter(cmd, "id_cuentacontable", DbType.Int32, _id_cuentacontable);
                db1.AddInParameter(cmd, "id_operacioncartera", DbType.Int32, _id_operacioncartera);
                db1.AddInParameter(cmd, "codigo_cuenta", DbType.String, _codigo_cuenta);
                db1.AddInParameter(cmd, "nombre_cuenta", DbType.String, _nombre_cuenta);
                db1.AddInParameter(cmd, "descripcion_cuenta", DbType.String, _descripcion_cuenta);
                db1.AddInParameter(cmd, "debe", DbType.Boolean, _debe);
                db1.AddInParameter(cmd, "haber", DbType.Boolean, _haber);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
                db1.AddInParameter(cmd, "porcentaje", DbType.Int32, _porcentaje);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }

        }

        public bool Eliminar()
        {

            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_Eliminar");
                db1.AddInParameter(cmd, "id_cuentacontable", DbType.Int32, _id_cuentacontable);
                db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }


        }
        #endregion
    }
}
    /// <summary>
    /// Descripción breve de cuentaContable
    /// </summary>
  