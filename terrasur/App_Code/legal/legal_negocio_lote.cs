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
/// Summary description for legal_negocio_lote
/// </summary>
namespace terrasur
{
    public class legal_negocio_lote
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_negociolote = 0;
        private int _id_negocio = 0;
        private int _id_lote = 0;
        private int _id_estadotramite = 0;
        private DateTime _fecha = DateTime.Now;
        private int _audit_id_usuario = 0;
        private DateTime _audit_fecha = DateTime.Now;

        private string _nombre_negocio = "";
        private string _nombre_estado = "";
        private string _nombre_audit_usuario = "";

        //Propiedades públicas
        public int id_negociolote { get { return _id_negociolote; } set { _id_negociolote = value; } }
        public int id_negocio { get { return _id_negocio; } set { _id_negocio = value; } }
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public int id_estadotramite { get { return _id_estadotramite; } set { _id_estadotramite = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int audit_id_usuario { get { return _audit_id_usuario; } set { _audit_id_usuario = value; } }
        public DateTime audit_fecha { get { return _audit_fecha; } set { _audit_fecha = value; } }

        public string nombre_negocio { get { return _nombre_negocio; } }
        public string nombre_estado { get { return _nombre_estado; } }
        public string nombre_audit_usuario { get { return _nombre_audit_usuario; } }
        #endregion

        #region Constructores
        public legal_negocio_lote(int Id_negociolote)
        {
            _id_negociolote = Id_negociolote;
            RecuperarDatos();
        }
        public legal_negocio_lote(int Id_negocio, int Id_lote, int Id_estadotramite, DateTime Fecha)
        {
            _id_negocio = Id_negocio;
            _id_lote = Id_lote;
            _id_estadotramite = Id_estadotramite;
            _fecha = Fecha;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_lote)
        {
            //[id_negociolote],[fecha],[negocio],[estado],[audit_usuario],[audit_fecha]
            DbCommand cmd = db1.GetStoredProcCommand("legal_negocio_lote_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaDatosLote(int Id_lote)
        {
            //[id_lote],[localizacion],[sector],[manzano],[lote],[superficie]
            DbCommand cmd = db1.GetStoredProcCommand("legal_negocio_lote_ListaDatosLote");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaLotes(int Id_urbanizacion, int Id_manzano)
        {
            //[id_lote],[manzano],[lote],[superficie],[estado]
            //[legal_negocio],[legal_negocio_fecha],[legal_negocio_estado]
            //[folio_numero],[folio_entregado],[folio_entregado_fecha],[observacion]
            DbCommand cmd = db1.GetStoredProcCommand("legal_negocio_lote_ListaLotes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int Id_negociolote_actual(int Id_lote)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_negocio_lote_Id_negociolote_actual");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
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
                DbCommand cmd = db1.GetStoredProcCommand("legal_negocio_lote_RecuperarDatos");
                db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, _id_negociolote);
                db1.AddOutParameter(cmd, "id_negocio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_lote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_estadotramite", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "audit_id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "audit_fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "nombre_negocio", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_estado", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_audit_usuario", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_negocio = (int)db1.GetParameterValue(cmd, "id_negocio");
                _id_lote = (int)db1.GetParameterValue(cmd, "id_lote");
                _id_estadotramite = (int)db1.GetParameterValue(cmd, "id_estadotramite");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _audit_id_usuario = (int)db1.GetParameterValue(cmd, "audit_id_usuario");
                _audit_fecha = (DateTime)db1.GetParameterValue(cmd, "audit_fecha");

                _nombre_negocio = (string)db1.GetParameterValue(cmd, "nombre_negocio");
                _nombre_estado = (string)db1.GetParameterValue(cmd, "nombre_estado");
                _nombre_audit_usuario = (string)db1.GetParameterValue(cmd, "nombre_audit_usuario");

            }
            catch { }
        }
        public bool Insertar(int audit_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_negocio_lote_Insertar");
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, _id_negocio);
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                db1.AddInParameter(cmd, "id_estadotramite", DbType.Int32, _id_estadotramite);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, audit_id_usuario);
                _id_negociolote = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

       #endregion
    }
}