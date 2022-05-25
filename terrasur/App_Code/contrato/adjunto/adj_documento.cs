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
    public class adj_documento
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_documento = 0;
        private int _id_contrato = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private string _nombre="";

        private string _num_contrato = "";
        private string _usuario = "";
        private int _num_archivos = 0;

        //Propiedades públicas
        public int id_documento { get { return _id_documento; } set { _id_documento = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public string num_contrato { get { return _num_contrato; } }
        public string usuario { get { return _usuario; } }
        public int num_archivos { get { return _num_archivos; } }
        #endregion

        #region Constructores
        public adj_documento(int Id_documento)
        {
            _id_documento = Id_documento;
            RecuperarDatos();
        }
        public adj_documento(int Id_contrato, string Nombre)
        {
            _id_contrato = Id_contrato;
            _nombre = Nombre;
        }
        public adj_documento(int Id_documento, int Id_contrato, string Nombre)
        {
            _id_documento = Id_documento;
            _id_contrato = Id_contrato;
            _nombre = Nombre;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorContrato(int Id_contrato)
        {
            //[id_documento],[fecha],[nombre],[usuario],[num_archivos]
            DbCommand cmd = db1.GetStoredProcCommand("adj_documento_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista(int Id_contrato)
        {
            //[id_contrato],[num_contrato],[lote],[cliente],[num_documentos]
            DbCommand cmd = db1.GetStoredProcCommand("adj_documento_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_documento_RecuperarDatos");
                db1.AddInParameter(cmd, "id_documento", DbType.Int32, _id_documento);

                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);

                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 25);
                db1.AddOutParameter(cmd, "usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "num_archivos", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");

                _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                _usuario = (string)db1.GetParameterValue(cmd, "usuario");
                _num_archivos = (int)db1.GetParameterValue(cmd, "num_archivos");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_documento_Insertar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                _id_documento = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_documento_Actualizar");
                db1.AddInParameter(cmd, "id_documento", DbType.Int32, _id_documento);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("adj_documento_Eliminar");
                db1.AddInParameter(cmd, "id_documento", DbType.Int32, _id_documento);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}