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
/// Summary description for legal_folio_observacion
/// </summary>
namespace terrasur
{
    public class legal_folio_observacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_observacion = 0;
        private int _id_folio = 0;
        private string _observacion = "";
        private int _audit_id_usuario = 0;
        private DateTime _audit_fecha = DateTime.Now;

        private string _nombre_audit_usuario = "";

        //Propiedades públicas
        public int id_observacion { get { return _id_observacion; } set { _id_observacion = value; } }
        public int id_folio { get { return _id_folio; } set { _id_folio = value; } }
        public string observacion { get { return _observacion; } set { _observacion = value; } }
        public int audit_id_usuario { get { return _audit_id_usuario; } set { _audit_id_usuario = value; } }
        public DateTime audit_fecha { get { return _audit_fecha; } set { _audit_fecha = value; } }

        public string nombre_audit_usuario { get { return _nombre_audit_usuario; } }
        #endregion

        #region Constructores
        public legal_folio_observacion(int Id_folio, string Observacion)
        {
            _id_folio = Id_folio;
            _observacion = Observacion;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_lote)
        {
            //[id_observacion],[observacion],[audit_usuario],[audit_fecha]
            DbCommand cmd = db1.GetStoredProcCommand("legal_folio_observacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        public bool Insertar(int audit_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("legal_folio_observacion_Insertar");
                db1.AddInParameter(cmd, "id_folio", DbType.Int32, _id_folio);
                db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, audit_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

       #endregion
    }
}