using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace terrasur
{
    /// <summary>
    /// Descripción breve de logOdoo
    /// </summary>
    public class logOdoo
    {
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_logoperacion = 0;
        private string _operacioncartera = "";
        private decimal _monto = 0;
        private DateTime _fecha = DateTime.Now;
        private int _usuario = 0;
        private string _respuesta = "";
        private string _ip = "";
        private bool _realizado_exito = true;
        private string _codigo_cuenta = "";
        private int _id_contrato = 0;
        private int _id_lote = 0;
        private int _id_transaccion = 0;

        //Propiedades públicas
        public int id_logoperacion { get { return _id_logoperacion; } set { _id_logoperacion = value; } }
        public string operacioncartera { get { return _operacioncartera; } set { _operacioncartera = value; } }
        public decimal monto { get { return _monto; } set { _monto = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int usuario { get { return _usuario; } set { _usuario = value; } }
        public string respuesta { get { return _respuesta; } set { _respuesta = value; } }
        public string ip { get { return _ip; } set { _ip = value; } }
        public bool realizado_exito { get { return _realizado_exito; } set { _realizado_exito = value; } }
        public string codigo_cuenta { get { return _codigo_cuenta; } set { _codigo_cuenta = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        
        #endregion

        #region Constructores
        public logOdoo(int Id_logoperacion)
        {
            _id_logoperacion = Id_logoperacion;
            RecuperarDatos();
        }

        //public cuentaContable(string Nombre)
        //{
        //    _nombre = Nombre;
        //    RecuperarDatosXnombre();
        //}
        public logOdoo(int Id_logoperacion, string Operacioncartera, decimal Monto, DateTime Fecha, int Usuario,
            string Respuesta, string Ip, bool Realizado_exito, string Codigo_cuenta,
            int Id_contrato, int Id_lote, int Id_transaccion)
        {
            _id_logoperacion = Id_logoperacion;
            _operacioncartera = Operacioncartera;
            _monto = Monto;
            _fecha = Fecha;
            _usuario = Usuario;
            _respuesta = Respuesta;
            _ip = Ip;
            _realizado_exito = Realizado_exito;
            _codigo_cuenta = Codigo_cuenta;
            _id_contrato = Id_contrato;
            _id_lote = Id_lote;
            _id_transaccion = Id_transaccion;
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
                //DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_RecuperarDatos");
                //db1.AddInParameter(cmd, "id_cuentacontable", DbType.Int32, _id_cuentacontable);
                //db1.AddOutParameter(cmd, "id_operacionbancaria", DbType.Int32, 32);
                //db1.AddOutParameter(cmd, "codigo_cuenta", DbType.String, 100);
                //db1.AddOutParameter(cmd, "nombre_cuenta", DbType.String, 300);
                //db1.AddOutParameter(cmd, "descripcion_cuenta", DbType.String, 1000);
                //db1.AddOutParameter(cmd, "debe", DbType.Boolean, 1);
                //db1.AddOutParameter(cmd, "haber", DbType.Boolean, 1);
                //db1.AddOutParameter(cmd, "activo", DbType.Boolean, 1);
                //db1.AddOutParameter(cmd, "usuario", DbType.Int32, 32);
                //db1.AddOutParameter(cmd, "operacion_cartera", DbType.String, 200);

                //db1.ExecuteNonQuery(cmd);
                //_id_operacioncartera = (int)db1.GetParameterValue(cmd, "id_operacionbancaria");
                //_codigo_cuenta = (string)db1.GetParameterValue(cmd, "codigo_cuenta");
                //_nombre_cuenta = (string)db1.GetParameterValue(cmd, "nombre_cuenta");
                //_descripcion_cuenta = (string)db1.GetParameterValue(cmd, "descripcion_cuenta");
                //_debe = (bool)db1.GetParameterValue(cmd, "debe");
                //_haber = (bool)db1.GetParameterValue(cmd, "haber");
                //_activo = (bool)db1.GetParameterValue(cmd, "activo");
                //_usuario = (int)db1.GetParameterValue(cmd, "usuario");
                //_porcentaje = (decimal)db1.GetParameterValue(cmd, "porcentaje");
                //_operacion_cartera = (string)db1.GetParameterValue(cmd, "operacion_cartera");
            }
            catch { }
        }


        public bool Insertar()
        {

            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_log_operaciones_Insertar");
                db1.AddInParameter(cmd, "operacioncartera", DbType.Int32, _operacioncartera);
                db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "usuario", DbType.String, _usuario);
                db1.AddInParameter(cmd, "respuesta", DbType.String, _respuesta);
                db1.AddInParameter(cmd, "ip", DbType.String, _ip);
                db1.AddInParameter(cmd, "realizado_exito", DbType.Boolean, _realizado_exito);
                db1.AddInParameter(cmd, "@codigo_cuenta", DbType.String, _codigo_cuenta);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                _id_logoperacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }

        }


        //public bool Actualizar()
        //{

        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_Actualizar");
        //        db1.AddInParameter(cmd, "id_cuentacontable", DbType.Int32, _id_cuentacontable);
        //        db1.AddInParameter(cmd, "id_operacioncartera", DbType.Int32, _id_operacioncartera);
        //        db1.AddInParameter(cmd, "codigo_cuenta", DbType.String, _codigo_cuenta);
        //        db1.AddInParameter(cmd, "nombre_cuenta", DbType.String, _nombre_cuenta);
        //        db1.AddInParameter(cmd, "descripcion_cuenta", DbType.String, _descripcion_cuenta);
        //        db1.AddInParameter(cmd, "debe", DbType.Boolean, _debe);
        //        db1.AddInParameter(cmd, "haber", DbType.Boolean, _haber);
        //        db1.AddInParameter(cmd, "actvo", DbType.Boolean, _activo);
        //        db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
        //        db1.AddInParameter(cmd, "porcentaje", DbType.Int32, _porcentaje);
        //        db1.ExecuteNonQuery(cmd);
        //        return true;
        //    }
        //    catch { return false; }

        //}

        //public bool Eliminar()
        //{

        //    try
        //    {

        //        DbCommand cmd = db1.GetStoredProcCommand("odoo_cuenta_contable_Eliminar");
        //        db1.AddInParameter(cmd, "id_cuentacontable", DbType.Int32, _id_cuentacontable);
        //        db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
        //        db1.ExecuteNonQuery(cmd);
        //        return true;
        //    }
        //    catch { return false; }


        //}
        #endregion
    }
}
    