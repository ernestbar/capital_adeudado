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
/// Summary description for estado_lote
/// </summary>
namespace terrasur
{
    public class estado_lote
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades 
        //Propiedades privadas
        private int _id_estadolote = 0;
        private int _id_estado = 0;
        private int _id_lote = 0;
        private int _id_contrato = 0;
        private int _id_reversion = 0;
        private int _id_usuario = 0;
        private DateTime _fecha;
        private string _observacion = "";

        private string _numero_contrato = "";
        private string _numero_contrato_revertido = "";
        private string _nombre_estado = "";
        private string _codigo_estado = "";
        private string _nombre_usuario = "";
        
        //Propiedades públicas
        public int id_estadolote { get { return _id_estadolote; } set { _id_estadolote = value; } }
        public int id_estado { get { return _id_estado; } set { _id_estado = value; } }
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_reversion { get { return _id_reversion; } set { _id_reversion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string observacion { get { return _observacion; } set { _observacion = value; } }

        public string numero_contrato { get { return _numero_contrato; } set { _numero_contrato = value; } }
        public string numero_contrato_revertido { get { return _numero_contrato_revertido; } set { _numero_contrato_revertido = value; } }
        public string nombre_estado { get { return _nombre_estado; } set { _nombre_estado = value; } }
        public string codigo_estado { get { return _codigo_estado; } set { _codigo_estado = value; } }
        public string nombre_usuario { get { return _nombre_usuario; } set { _nombre_usuario = value; } }

        #endregion

        #region Constructores
        public estado_lote(int Id_estadolote)
        {
            _id_estadolote = Id_estadolote;
            RecuperarDatos();
        }
        public estado_lote(int Id_estado, int Id_lote, int Id_contrato, int Id_reversion, string Observacion)
        {
            _id_estado = Id_estado;
            _id_lote = Id_lote;
            _id_contrato = Id_contrato;
            _id_reversion = Id_reversion;
            _observacion = Observacion;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorLote(int Id_lote)
        {
            //[id_estadolote],[id_estado],[id_lote],[id_contrato],[id_reversion].[id_usuario],[fecha],[observacion],[numero_contrato],[numero_contrato_revertido]
            DbCommand cmd = db1.GetStoredProcCommand("estado_lote_ListaPorLote");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarDisponible(int Id_lote)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("estado_lote_VerificarDisponible");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
                if ((int)db1.ExecuteScalar(cmd) == 1) return true;
                else return false;
            }
            catch { return false; }
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("estado_lote_RecuperarDatos");
                db1.AddInParameter(cmd, "id_estadolote", DbType.Int32, _id_estadolote);
                db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_lote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_reversion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "observacion", DbType.String, 500);

                db1.AddOutParameter(cmd, "numero_contrato", DbType.String, 50);
                db1.AddOutParameter(cmd, "numero_contrato_revertido", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_estado", DbType.String, 100);
                db1.AddOutParameter(cmd, "codigo_estado", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                _id_lote = (int)db1.GetParameterValue(cmd, "id_lote");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_reversion = (int)db1.GetParameterValue(cmd, "id_reversion");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _observacion = (string)db1.GetParameterValue(cmd, "observacion");

                _numero_contrato = (string)db1.GetParameterValue(cmd, "numero_contrato");
                _numero_contrato_revertido = (string)db1.GetParameterValue(cmd, "numero_contrato_revertido");
                _nombre_estado = (string)db1.GetParameterValue(cmd, "nombre_estado");
                _codigo_estado = (string)db1.GetParameterValue(cmd, "codigo_estado");
                _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
            }
            catch { }
        }
        public bool Insertar(int context_id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("estado_lote_Insertar");
            db1.AddInParameter(cmd, "id_estado", DbType.Int32, _id_estado);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
            db1.AddInParameter(cmd, "id_reversion", DbType.Int32, _id_reversion);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
            db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
            _id_estadolote = (int)db1.ExecuteScalar(cmd);
            return true;
          
        }
        public bool Eliminar()
        {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("estado_lote_Eliminar");
                    db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
        }
        #endregion


    }
}
