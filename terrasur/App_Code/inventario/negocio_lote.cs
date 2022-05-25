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
/// Summary description for negocio_lote
/// </summary>
/// 
namespace terrasur
{

    public class negocio_lote
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_negociolote = 0;
        private int _id_negocio = 0;
        private int _id_lote = 0;
        private int _id_usuario = 0;
        private DateTime _fecha;
        
        private string _negocio_nombre = "";
        private string _usuario_nombre = "";



        //Propiedades públicas
        public int id_negociolote { get { return _id_negociolote; } set { _id_negociolote = value; } }
        public int id_negocio { get { return _id_negocio; } set { _id_negocio = value; } }
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }

        public string negocio_nombre { get { return _negocio_nombre; } set { _negocio_nombre = value; } }
        public string usuario_nombre { get { return _usuario_nombre; } set { _usuario_nombre = value; } }

        #endregion
        
        #region Constructores
        public negocio_lote(int Id_negociolote)
        {
            _id_negociolote = Id_negociolote;
            RecuperarDatos();
        }
        public negocio_lote(int Id_negocio, int Id_lote)
        {
            _id_negocio = Id_negocio;
            _id_lote = Id_lote;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorLote(int Id_lote)
        {
            //[id_negociolote],[id_negocio],[id_lote],[id_usuario],[fecha],[negocio_nombre],[usuario_nombre]
            DbCommand cmd = db1.GetStoredProcCommand("negocio_lote_ListaPorLote");
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
                DbCommand cmd = db1.GetStoredProcCommand("negocio_lote_RecuperarDatos");
                db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, _id_negociolote);
                db1.AddOutParameter(cmd, "id_negocio", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_lote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "negocio_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 100);

                db1.ExecuteNonQuery(cmd);
                _id_negocio = (int)db1.GetParameterValue(cmd, "id_negocio");
                _id_lote = (int)db1.GetParameterValue(cmd, "id_lote");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");

                _negocio_nombre = (string)db1.GetParameterValue(cmd, "negocio_nombre");
                _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
            }
            catch { }
        }
        public bool Insertar(int context_id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("negocio_lote_Insertar");
            db1.AddInParameter(cmd, "id_negocio", DbType.Int32, _id_negocio);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
            _id_negociolote = (int)db1.ExecuteScalar(cmd);
            return true;

        }
        public bool Eliminar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("negocio_lote_Eliminar");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}