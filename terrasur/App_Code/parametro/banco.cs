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
/// Summary description for banco
/// </summary>
namespace terrasur
{
    public class banco
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_banco = 0;
        private int _id_usuario = 0;
        private string _codigo = "";
        private string _nombre = "";
        private bool _activo = true;

        private int _num_cheques = 0;

        //Propiedades públicas
        public int id_banco { get { return _id_banco; } set { _id_banco = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_cheques { get { return _num_cheques; } }

        #endregion

        #region Constructores
        public banco(int Id_banco)
        {
            _id_banco = Id_banco;
            RecuperarDatos();
        }
        public banco(string Codigo, string Nombre, bool Activo)
        {
            _codigo = Codigo;
            _nombre = Nombre;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_banco],[id_usuario],[codigo],[nombre],[activo],[num_cheques]
            DbCommand cmd = db1.GetStoredProcCommand("banco_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivo()
        {
            //[id_banco],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("banco_ListaActivo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarCodigoNombre(bool Inserta, int Id_banco, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("banco_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_banco", DbType.Int32, Id_banco);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
                db1.AddInParameter(cmd, "nombre", DbType.String, Nombre);
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
                DbCommand cmd = db1.GetStoredProcCommand("banco_RecuperarDatos");
                db1.AddInParameter(cmd, "id_banco", DbType.Int32, _id_banco);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "num_cheques", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);

                _id_banco = (int)db1.GetParameterValue(cmd, "id_banco");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _activo = (Boolean)db1.GetParameterValue(cmd, "activo");

                _num_cheques = (int)db1.GetParameterValue(cmd, "num_cheques");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("banco_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    _id_banco = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }


        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(false, _id_banco, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("banco_Actualizar");
                    db1.AddInParameter(cmd, "id_banco", DbType.Int32, _id_banco);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_cheques == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("banco_Eliminar");
                    db1.AddInParameter(cmd, "id_banco", DbType.Int32, _id_banco);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        #endregion


    }
}