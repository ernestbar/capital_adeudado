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
/// Summary description for cliente_contrato
/// </summary>
namespace terrasur
{
    public class adj_archivo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_archivo = 0;
        private int _id_documento = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private string _codigo = "";
        private string _nombre = "";

        private string _documento_nombre = "";
        private string _num_contrato = "";

        //Propiedades públicas
        public int id_archivo { get { return _id_archivo; } set { _id_archivo = value; } }
        public int id_documento { get { return _id_documento; } set { _id_documento = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public string documento_nombre { get { return _documento_nombre; } }
        public string num_contrato { get { return _num_contrato; } }
        #endregion

        #region Constructores
        public adj_archivo(int Id_documento, string Nombre)
        {
            _id_documento = Id_documento;
            _nombre = Nombre;
        }
        public adj_archivo(int Id_archivo)
        {
            _id_archivo = Id_archivo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_documento)
        {
            //[id_archivo],[fecha],[codigo],[nombre],[usuario]
            DbCommand cmd = db1.GetStoredProcCommand("adj_archivo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_documento", DbType.Int32, Id_documento);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        public void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_archivo_RecuperarDatos");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);

                db1.AddOutParameter(cmd, "id_documento", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);

                db1.AddOutParameter(cmd, "documento_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 25);

                db1.ExecuteNonQuery(cmd);

                _id_documento = (int)db1.GetParameterValue(cmd, "id_documento");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");

                _documento_nombre = (string)db1.GetParameterValue(cmd, "documento_nombre");
                _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_archivo_Insertar");
                db1.AddInParameter(cmd, "id_documento", DbType.Int32, _id_documento);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                _id_archivo = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_archivo_Actualizar");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);
                db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_archivo_Eliminar");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}