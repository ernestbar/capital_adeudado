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
/// Summary description for motivo_desactivacion
/// </summary>
namespace terrasur
{
    public class motivo_desactivacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_motivodesactivacion = 0;
        private int _id_usuario = 0;
        private string _codigo = "";
        private string _nombre = "";

        private int _num_recibos = 0;

        //Propiedades públicas
        public int id_motivodesactivacion { get { return _id_motivodesactivacion; } set { _id_motivodesactivacion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public int num_recibos { get { return _num_recibos; } }
        #endregion

        #region Constructores
        public motivo_desactivacion(int Id_motivodesactivacion)
        {
            _id_motivodesactivacion = Id_motivodesactivacion;
            RecuperarDatos();
        }
        public motivo_desactivacion(string Codigo, string Nombre)
        {
            _codigo = Codigo;
            _nombre = Nombre;
        }
        #endregion


        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_motivodesactivacion],[codigo],[nombre],[num_recibos]
            DbCommand cmd = db1.GetStoredProcCommand("motivo_desactivacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarCodigoNombre(bool Inserta, int Id_motivodesactivacion, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("motivo_desactivacion_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32, Id_motivodesactivacion);
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
                DbCommand cmd = db1.GetStoredProcCommand("motivo_desactivacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32, _id_motivodesactivacion);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);

                db1.AddOutParameter(cmd, "num_recibos", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");

                _num_recibos = (int)db1.GetParameterValue(cmd, "num_recibos");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("motivo_desactivacion_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    _id_motivodesactivacion = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }

        }


        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(false, _id_motivodesactivacion, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("motivo_desactivacion_Actualizar");
                    db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32, _id_motivodesactivacion);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_recibos == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("motivo_desactivacion_Eliminar");
                    db1.AddInParameter(cmd, "id_motivodesactivacion", DbType.Int32, _id_motivodesactivacion);
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