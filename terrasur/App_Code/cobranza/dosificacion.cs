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
/// Summary description for dosificacion 
/// </summary>
/// 
namespace terrasur
{
    public class dosificacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_dosificacion = 0;
        private int _id_usuario = 0;
        private int _desde = 0;
        private int _hasta = 0;
        private DateTime _fecha;
        private bool _activo;
        private int _id_negocio = 0;

        private int _dosificaciones_posteriores;
        private int _id_recibocobrador_ultimo_utilizado = 0;
        private int _numero_ultimo_recibo_utilizado = 0;
        private string _nombre_cobrador = "";
        private int _total_recibos_dosificados = 0;
        private int _num_recibos_utilizados = 0;
        private int _num_recibos_desactivados = 0;
        private int _numero_ultimo_recibo = 0;

        //Propiedades públicas
        public int id_dosificacion { get { return _id_dosificacion; } set { _id_dosificacion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int desde { get { return _desde; } set { _desde = value; } }
        public int hasta { get { return _hasta; } set { _hasta = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public int id_negocio { get { return _id_negocio; } set { _id_negocio = value; } }

        public int dosificaciones_posteriores { get { return _dosificaciones_posteriores; } set { _dosificaciones_posteriores = value; } }
        public int id_recibocobrador_ultimo_utilizado { get { return _id_recibocobrador_ultimo_utilizado; } set { _id_recibocobrador_ultimo_utilizado = value; } }
        public int numero_ultimo_recibo_utilizado { get { return _numero_ultimo_recibo_utilizado; } set { _numero_ultimo_recibo_utilizado = value; } }
        public string nombre_cobrador { get { return _nombre_cobrador; } set { _nombre_cobrador = value; } }
        public int total_recibos_dosificados { get { return _total_recibos_dosificados; } set { _total_recibos_dosificados = value; } }
        public int num_recibos_utilizados { get { return _num_recibos_utilizados; } set { _num_recibos_utilizados = value; } }
        public int num_recibos_desactivados { get { return _num_recibos_desactivados; } set { _num_recibos_desactivados = value; } }
        public int numero_ultimo_recibo { get { return _numero_ultimo_recibo; } set { _numero_ultimo_recibo = value; } }

        #endregion

        #region Constructores
        public dosificacion()
        {
        }
        public dosificacion(int Id_dosificacion)
        {
            _id_dosificacion = Id_dosificacion;
            RecuperarDatos();
        }
        public dosificacion(int Id_usuario, bool Activo)
        {
            _id_usuario = Id_usuario;
            _activo = Activo;
            RecuperarUltimaDosificacion();
        }
        public dosificacion(int Id_usuario, int Desde, int Hasta, bool Activo, int Id_negocio)
        {
            _id_usuario = Id_usuario;
            _desde = Desde;
            _hasta = Hasta;
            _activo = Activo;
            _id_negocio = Id_negocio;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_dosificacion],[id_usuario],[desde],[hasta],[fecha],[activo],[negocio]
            DbCommand cmd = db1.GetStoredProcCommand("dosificacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorActivo(bool Activo)
        {
            //[id_dosificacion],[id_usuario],[desde],[hasta],[fecha],[activo],[negocio]
            DbCommand cmd = db1.GetStoredProcCommand("dosificacion_ListaPorActivo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "activo", DbType.Boolean, Activo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarDesde(int Desde)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dosificacion_VerificarDesde");
                db1.AddInParameter(cmd, "desde", DbType.Int32, Desde);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        public static bool VerificarHasta(int Hasta)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dosificacion_VerificarHasta");
                db1.AddInParameter(cmd, "hasta", DbType.Int32, Hasta);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dosificacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_dosificacion", DbType.Int32, _id_dosificacion);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "desde", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "hasta", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "id_negocio", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "dosificaciones_posteriores", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_recibocobrador_ultimo_utilizado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "numero_ultimo_recibo_utilizado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_cobrador", DbType.String, 500);
                db1.AddOutParameter(cmd, "total_recibos_dosificados", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_recibos_utilizados", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_recibos_desactivados", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _desde = (int)db1.GetParameterValue(cmd, "desde");
                _hasta = (int)db1.GetParameterValue(cmd, "hasta");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _id_negocio = (int)db1.GetParameterValue(cmd, "id_negocio");

                _dosificaciones_posteriores = (int)db1.GetParameterValue(cmd, "dosificaciones_posteriores");
                _id_recibocobrador_ultimo_utilizado = (int)db1.GetParameterValue(cmd, "id_recibocobrador_ultimo_utilizado");
                _numero_ultimo_recibo_utilizado = (int)db1.GetParameterValue(cmd, "numero_ultimo_recibo_utilizado");
                _nombre_cobrador = (string)db1.GetParameterValue(cmd, "nombre_cobrador");
                _total_recibos_dosificados = (int)db1.GetParameterValue(cmd, "total_recibos_dosificados");
                _num_recibos_utilizados = (int)db1.GetParameterValue(cmd, "num_recibos_utilizados");
                _num_recibos_desactivados = (int)db1.GetParameterValue(cmd, "num_recibos_desactivados");


            }
            catch { }
        }
        private void RecuperarUltimaDosificacion()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dosificacion_RecuperarUltimaDosificacion");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "activo", DbType.Boolean , _activo);
                db1.AddOutParameter(cmd, "id_dosificacion", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_dosificacion = (int)db1.GetParameterValue(cmd, "id_dosificacion");
            }
            catch { }
        }
        public void RecuperarUltimoNumero()
        { 
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dosificacion_RecuperarUltimoNumero");
                db1.AddOutParameter(cmd, "numero_ultimo_recibo", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _numero_ultimo_recibo = (int)db1.GetParameterValue(cmd, "numero_ultimo_recibo");
            }
            catch { }
        }
        public bool Insertar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dosificacion_Insertar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "desde", DbType.Int32, _desde);
                db1.AddInParameter(cmd, "hasta", DbType.Int32, _hasta);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, _id_negocio);
                _id_dosificacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar()
        {
            if (_dosificaciones_posteriores == 0)
            {
                if (_numero_ultimo_recibo_utilizado < _hasta)
                {
                    try
                    {
                        DbCommand cmd = db1.GetStoredProcCommand("dosificacion_Actualizar");
                        db1.AddInParameter(cmd, "id_dosificacion", DbType.Int32, _id_dosificacion);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                        db1.AddInParameter(cmd, "hasta", DbType.Int32, _hasta);
                        db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, _id_negocio);
                        db1.ExecuteNonQuery(cmd);
                        return true;
                    }
                    catch { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        public bool Eliminar()
        {
            if (_dosificaciones_posteriores == 0)
            {
                if (_num_recibos_utilizados == 0)
                {
                    try
                    {
                        DbCommand cmd = db1.GetStoredProcCommand("dosificacion_Eliminar");
                        db1.AddInParameter(cmd, "id_dosificacion", DbType.Int32, _id_dosificacion);
                        db1.ExecuteNonQuery(cmd);
                        return true;
                    }
                    catch { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }
        #endregion

    }
}