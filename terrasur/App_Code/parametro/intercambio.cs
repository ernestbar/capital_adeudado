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
/// Summary description for intercambio
/// </summary>
namespace terrasur
{
    public class intercambio
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_intercambio = 0;
        private int _id_contrato = 0;
        private int _id_estadolote = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private string _empresa = "";
        private string _descripcion = "";
        private DateTime _fecha_registro = DateTime.Now;

        private string _nombre_usuario = "";
        private string _num_contrato = "";
        private string _lote_string = "";
        private int _id_localizacion = 0;
        private int _id_urbanizacion = 0;
        private int _id_manzano = 0;
        private int _id_lote = 0;

        //Propiedades públicas
        public int id_intercambio { get { return _id_intercambio; } set { _id_intercambio = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_estadolote { get { return _id_estadolote; } set { _id_estadolote = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string empresa { get { return _empresa; } set { _empresa = value; } }
        public string descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public DateTime fecha_registro { get { return _fecha_registro; } set { _fecha_registro = value; } }

        public string nombre_usuario { get { return _nombre_usuario; } }
        public string num_contrato { get { return _num_contrato; } }
        public string lote_string { get { return _lote_string; } }
        public int id_localizacion { get { return _id_localizacion; } }
        public int id_urbanizacion { get { return _id_urbanizacion; } }
        public int id_manzano { get { return _id_manzano; } }
        public int id_lote { get { return _id_lote; } }

        #endregion

        #region Constructores
        public intercambio(int Id_intercambio)
        {
            _id_intercambio = Id_intercambio;
            RecuperarDatos();
        }

        public intercambio(int Id_contrato, int Id_estadolote, DateTime Fecha, string Empresa, string Descripcion)
        {
            _id_contrato = Id_contrato;
            _id_estadolote = Id_estadolote;
            _fecha = Fecha;
            _empresa = Empresa;
            _descripcion = Descripcion;
        }

        public intercambio(int Id_intercambio, int Id_contrato, int Id_estadolote, DateTime Fecha, string Empresa, string Descripcion)
        {
            _id_intercambio = Id_intercambio;
            _id_contrato = Id_contrato;
            _id_estadolote = Id_estadolote;
            _fecha = Fecha;
            _empresa = Empresa;
            _descripcion = Descripcion;
        }

        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_intercambio],[id_contrato],[id_estadolote],[num_contrato],[lote],[usuario],[fecha],[empresa],[descripcion],[fecha_registro]
            DbCommand cmd = db1.GetStoredProcCommand("intercambio_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaPorLote(int Id_lote)
        {
            //[id_intercambio],[fecha],[nombre_usuario],[empresa],[descripcion],[num_contrato]
            DbCommand cmd = db1.GetStoredProcCommand("intercambio_ListaPorLote");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaLotesBloqueados(int Id_manzano, int Id_lote)
        {
            //[id_lote],[codigo],[id_estadolote]
            DbCommand cmd = db1.GetStoredProcCommand("intercambio_ListaLotesBloqueados");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Reporte(DateTime Fecha_inicio, DateTime Fecha_fin, string Num_contrato,
            int Id_localizacion, int Id_urbanizacion, int Id_manzano, string Empresa, string Descripcion)
        {
            //[id_intercambio],[num_contrato],[lote],[usuario],[fecha],[empresa],[descripcion],[fecha_registro]
            DbCommand cmd = db1.GetStoredProcCommand("intercambio_Reporte");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "empresa", DbType.String, Empresa);
            db1.AddInParameter(cmd, "descripcion", DbType.String, Descripcion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int IdIntercambio_por_contrato(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("intercambio_IdIntercambio_por_contrato");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("intercambio_RecuperarDatos");
                db1.AddInParameter(cmd, "id_intercambio", DbType.Int32, _id_intercambio);

                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_estadolote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "empresa", DbType.String, 500);
                db1.AddOutParameter(cmd, "descripcion", DbType.String, 1000);
                db1.AddOutParameter(cmd, "fecha_registro", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 20);
                db1.AddOutParameter(cmd, "lote_string", DbType.String, 100);
                db1.AddOutParameter(cmd, "id_localizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_manzano", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_lote", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_estadolote = (int)db1.GetParameterValue(cmd, "id_estadolote");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _empresa = (string)db1.GetParameterValue(cmd, "empresa");
                _descripcion = (string)db1.GetParameterValue(cmd, "descripcion");
                _fecha_registro = (DateTime)db1.GetParameterValue(cmd, "fecha_registro");

                _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                _lote_string = (string)db1.GetParameterValue(cmd, "lote_string");
                _id_localizacion = (int)db1.GetParameterValue(cmd, "id_localizacion");
                _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                _id_manzano = (int)db1.GetParameterValue(cmd, "id_manzano");
                _id_lote = (int)db1.GetParameterValue(cmd, "id_lote");
            }
            catch { }
        }
        
        public bool Insertar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("intercambio_Insertar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_estadolote", DbType.Int32, _id_estadolote);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "empresa", DbType.String, _empresa);
                db1.AddInParameter(cmd, "descripcion", DbType.String, _descripcion);
                _id_intercambio = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("intercambio_Actualizar");
                db1.AddInParameter(cmd, "id_intercambio", DbType.Int32, _id_intercambio);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_estadolote", DbType.Int32, _id_estadolote);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "empresa", DbType.String, _empresa);
                db1.AddInParameter(cmd, "descripcion", DbType.String, _descripcion);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("intercambio_Eliminar");
                db1.AddInParameter(cmd, "id_intercambio", DbType.Int32, _id_intercambio);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

    }
}