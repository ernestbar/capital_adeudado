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
/// Summary description for recibo_cobrador
/// </summary>
/// 
namespace terrasur
{
    public class recibo_cobrador
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_recibocobrador = 0;
        private int _id_dosificacion = 0;
        private int _id_motivodesactivacion = 0;
        private int _id_usuario = 0;
        private int _numero = 0;
        private bool _activo;
        private DateTime _fecha_desactivado;

        private int _con_transaccion = 0;
        private decimal _monto_transaccion = 0;
        private int _numero_contrato = 0;
        private DateTime _fecha_transaccion;

        //Propiedades públicas
        public int id_recibocobrador { get { return _id_recibocobrador; } set { _id_recibocobrador = value; } }
        public int id_dosificacion { get { return _id_dosificacion; } set { _id_dosificacion = value; } }
        public int id_motivodesactivacion { get { return _id_motivodesactivacion; } set { _id_motivodesactivacion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int numero { get { return _numero; } set { _numero = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public DateTime fecha_desactivado { get { return _fecha_desactivado; } set { _fecha_desactivado = value; } }

        public int con_transaccion { get { return _con_transaccion; } set { _con_transaccion = value; } }
        public decimal monto_transaccion { get { return _monto_transaccion; } set { _monto_transaccion = value; } }
        public int numero_contrato { get { return _numero_contrato; } set { _numero_contrato = value; } }
        public DateTime fecha_transaccion { get { return _fecha_transaccion; } set { _fecha_transaccion = value; } }
        #endregion

        #region Constructores
        public recibo_cobrador(int Id_recibocobrador, int Numero)
        {
            _id_recibocobrador = Id_recibocobrador;
            _numero = Numero;
            RecuperarDatos();
        }
        //public recibo_cobrador(int Numero)
        //{
        //    _numero = Numero;
        //    RecuperarDatos();
        //}
        public recibo_cobrador(int Id_dosificacion, int Id_motivodesactivacion, int Numero)
        {
            _id_dosificacion = Id_dosificacion;
            _id_motivodesactivacion = Id_motivodesactivacion;
            _numero = Numero;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorDosificacion(int Id_dosificacion)
        {
            //[id_recibocobrador],[id_dosificacion],[id_motivodesactivacion],[id_usuario],[numero],[activo],[fecha_desactivado]
            DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_ListaPorDosificacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_dosificacion", DbType.Int32, Id_dosificacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorMotivoDesactivacion(int Id_motivodesactivacion)
        {
            //[id_recibocobrador],[id_dosificacion],[id_motivodesactivacion],[id_usuario],[numero],[activo],[fecha_desactivado]
            DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_ListaPorMotivoDesactivacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32, Id_motivodesactivacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorActivo(bool Activo)
        {
            //[id_recibocobrador],[id_dosificacion],[id_motivodesactivacion],[id_usuario],[numero],[activo],[fecha_desactivado]
            DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_ListaPorActivo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "activo", DbType.Boolean, Activo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool PermitirUtilizar(int Id_recibo, int Numero, int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_PermitirUtilizar");
                db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, Id_recibo);
                db1.AddInParameter(cmd, "numero", DbType.Int32, Numero);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) return true;
                else return false;
            }
            catch { return false; }
        }
        public static int IdPorTransaccion(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_IdPorTransaccion");
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static DataTable AsignacionLista(string Numero_contrato, DateTime Fecha, int Numero_recibo)
        {
            //[id_transaccion],[contrato],[tipo_pago],[fecha],[monto_pago],[nombre_usuario],[recibo_cobrador]
            DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_AsignacionLista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "numero_contrato", DbType.String, Numero_contrato);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.AddInParameter(cmd, "numero_recibo", DbType.Int32, Numero_recibo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool AsignacionModificar(int Id_transaccion, int Numero_recibo, int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_AsignacionModificar");
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                db1.AddInParameter(cmd, "numero_recibo", DbType.Int32, Numero_recibo);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_RecuperarDatos");
                db1.AddInParameter(cmd, "id_recibocobrador0", DbType.Int32, _id_recibocobrador);
                db1.AddInParameter(cmd, "numero0", DbType.Int32, _numero);
                db1.AddOutParameter(cmd, "id_recibocobrador", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_dosificacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_motivodesactivacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "numero", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "fecha_desactivado", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "con_transaccion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto_transaccion", DbType.Double, 32);
                db1.AddOutParameter(cmd, "numero_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha_transaccion", DbType.DateTime, 32);

                db1.ExecuteNonQuery(cmd);
                _id_recibocobrador = (int)db1.GetParameterValue(cmd, "id_recibocobrador");
                _id_dosificacion = (int)db1.GetParameterValue(cmd, "id_dosificacion");
                _id_motivodesactivacion = (int)db1.GetParameterValue(cmd, "id_motivodesactivacion");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _numero = (int)db1.GetParameterValue(cmd, "numero");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _fecha_desactivado = (DateTime)db1.GetParameterValue(cmd, "fecha_desactivado");

                _con_transaccion = (int)db1.GetParameterValue(cmd, "con_transaccion");
                _monto_transaccion = (decimal)(double)db1.GetParameterValue(cmd, "monto_transaccion");
                _numero_contrato = (int)db1.GetParameterValue(cmd, "numero_contrato");
                _fecha_transaccion = (DateTime)db1.GetParameterValue(cmd, "fecha_transaccion");
            }
            catch { }
        }
        public bool Insertar()
        {
            DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_Insertar");
            db1.AddInParameter(cmd, "id_dosificacion", DbType.Int32, _id_dosificacion);
            db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32, _id_motivodesactivacion);
            db1.AddInParameter(cmd, "numero", DbType.Int32, _numero);
            _id_recibocobrador = (int)db1.ExecuteScalar(cmd);
            return true;

        }
        public bool Desactivar(int context_id_usuario)
        {
            if (con_transaccion == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_Desactivar");
                    db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, _id_recibocobrador);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32,_id_motivodesactivacion);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }

        }

        public bool Eliminar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("recibo_cobrador_Eliminar");
                db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, _id_recibocobrador);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

    }
}