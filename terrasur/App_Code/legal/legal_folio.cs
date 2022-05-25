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
/// Summary description for legal_folio
/// </summary>
namespace terrasur
{
    public class legal_folio
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_folio = 0;
        private int _id_lote = 0;
        private string _numero = "";
        private bool _entregado = false;
        private DateTime _entregado_fecha = DateTime.Now;
        private int _audit_id_usuario = 0;
        private DateTime _audit_fecha = DateTime.Now;

        private string _nombre_audit_usuario = "";

        //Propiedades públicas
        public int id_folio { get { return _id_folio; } set { _id_folio = value; } }
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public string numero { get { return _numero; } set { _numero = value; } }
        public bool entregado { get { return _entregado; } set { _entregado = value; } }
        public DateTime entregado_fecha { get { return _entregado_fecha; } set { _entregado_fecha = value; } }
        public int audit_id_usuario { get { return _audit_id_usuario; } set { _audit_id_usuario = value; } }
        public DateTime audit_fecha { get { return _audit_fecha; } set { _audit_fecha = value; } }

        public string nombre_audit_usuario { get { return _nombre_audit_usuario; } }
        #endregion

        #region Constructores
        public legal_folio(int Id_lote)
        {
            _id_lote = Id_lote;
            RecuperarDatos();
        }
        public legal_folio(int Id_lote, string Numero, bool Entregado, DateTime Entregado_fecha)
        {
            _id_lote = Id_lote;
            _numero = Numero;
            _entregado = Entregado;
            _entregado_fecha = Entregado_fecha;
        }
        public legal_folio(int Id_folio, int Id_lote, string Numero, bool Entregado, DateTime Entregado_fecha)
        {
            _id_folio = Id_folio;
            _id_lote = Id_lote;
            _numero = Numero;
            _entregado = Entregado;
            _entregado_fecha = Entregado_fecha;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_lote)
        {
            //[id_folio],[numero],[entregado],[entregado_fecha],[audit_usuario],[audit_fecha]
            DbCommand cmd = db1.GetStoredProcCommand("legal_folio_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaAnteriores(int Id_lote)
        {
            //[id_folio],[accion],[numero],[entregado],[entregado_fecha],[audit_usuario],[audit_fecha]
            DbCommand cmd = db1.GetStoredProcCommand("legal_folio_ListaAnteriores");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_folio_RecuperarDatos");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                db1.AddOutParameter(cmd, "id_folio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "numero", DbType.String, 30);
                db1.AddOutParameter(cmd, "entregado", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "entregado_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "audit_id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "audit_fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "nombre_audit_usuario", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_folio = (int)db1.GetParameterValue(cmd, "id_folio");
                _numero = (string)db1.GetParameterValue(cmd, "numero");
                _entregado = (bool)db1.GetParameterValue(cmd, "entregado");
                _entregado_fecha = (DateTime)db1.GetParameterValue(cmd, "entregado_fecha");
                _audit_id_usuario = (int)db1.GetParameterValue(cmd, "audit_id_usuario");
                _audit_fecha = (DateTime)db1.GetParameterValue(cmd, "audit_fecha");

                _nombre_audit_usuario = (string)db1.GetParameterValue(cmd, "nombre_audit_usuario");
            }
            catch { }
        }
        public bool Insertar(int audit_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_folio_Insertar");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                db1.AddInParameter(cmd, "numero", DbType.String, _numero);
                db1.AddInParameter(cmd, "entregado", DbType.Boolean, _entregado);
                db1.AddInParameter(cmd, "entregado_fecha", DbType.DateTime, _entregado_fecha);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, audit_id_usuario);
                _id_folio = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        public bool Actualizar(int audit_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_folio_Actualizar");
                db1.AddInParameter(cmd, "id_folio", DbType.Int32, _id_folio);
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                db1.AddInParameter(cmd, "numero", DbType.String, _numero);
                db1.AddInParameter(cmd, "entregado", DbType.Boolean, _entregado);
                db1.AddInParameter(cmd, "entregado_fecha", DbType.DateTime, _entregado_fecha);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, audit_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}