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
/// Summary description for localizacion
/// </summary>
namespace terrasur
{
    public class localizacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_localizacion = 0;
        private string _codigo = "";
        private string _nombre = "";
        private string _imagen = "";

        private int _num_lote = 0;
        private int _num_urbanizacion = 0;
        private int _num_urbanizacion_activa = 0;
        //Propiedades públicas
        public int id_localizacion { get { return _id_localizacion; } set { _id_localizacion = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string imagen { get { return _imagen; } set { _imagen = value; } }

        public int num_lote { get { return _num_lote; } }
        public int num_urbanizacion { get { return _num_urbanizacion; } }
        public int num_urbanizacion_activa { get { return _num_urbanizacion_activa; } }
        #endregion

        #region Constructores
        public localizacion(int Id_localizacion)
        {
            _id_localizacion = Id_localizacion;
            RecuperarDatos();
        }
        public localizacion(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        public localizacion(string Codigo, string Nombre)
        {
            _codigo = Codigo;
            _nombre = Nombre;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_localizacion],[codigo],[nombre],[imagen],[num_urbanizacion],[num_lote],[num_urbanizacion_activa]
            DbCommand cmd = db1.GetStoredProcCommand("localizacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaConUrbanizacion(int Id_localizacion)
        {
            //[id_localizacion],[codigo],[nombre],[imagen]
            DbCommand cmd = db1.GetStoredProcCommand("localizacion_ListaConUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaConUrbanizacion_para_ddl(int Id_localizacion)
        {
            //[id_localizacion],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("localizacion_ListaConUrbanizacion_para_ddl");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarCodigoNombre(bool Inserta, int Id_localizacion, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("localizacion_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
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
                DbCommand cmd = db1.GetStoredProcCommand("localizacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_localizacion0", DbType.Int32, _id_localizacion);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                db1.AddOutParameter(cmd, "id_localizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "imagen", DbType.String, 100);

                db1.AddOutParameter(cmd, "num_lote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_urbanizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_urbanizacion_activa", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_localizacion = (int)db1.GetParameterValue(cmd, "id_localizacion");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _imagen = (string)db1.GetParameterValue(cmd, "imagen");

                _num_lote = (int)db1.GetParameterValue(cmd, "num_lote");
                _num_urbanizacion = (int)db1.GetParameterValue(cmd, "num_urbanizacion");
                _num_urbanizacion_activa = (int)db1.GetParameterValue(cmd, "num_urbanizacion_activa");
            }
            catch { }
        }
        public bool Insertar()
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("localizacion_Insertar");
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    _id_localizacion = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }


        public bool Actualizar()
        {
            if (VerificarCodigoNombre(false, _id_localizacion, _codigo, _nombre) == false)
            {

                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("localizacion_Actualizar");
                    db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, _id_localizacion);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar()
        {
            if (this._num_urbanizacion == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("localizacion_Eliminar");
                    db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, _id_localizacion);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }
        public void ImagenActualizar(int Id_localizacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("localizacion_ImagenActualizar");
                db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
                db1.AddInParameter(cmd, "imagen", DbType.String, _imagen);
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }

        public static string ImagenDireccion(string Img)
        {
            string dir_upload = ConfigurationManager.AppSettings["localizacion_dir_imagen"];
            if (Img != "" && System.IO.File.Exists(HttpContext.Current.Server.MapPath(dir_upload + Img)) == true) { return dir_upload + Img; }
            else { return ConfigurationManager.AppSettings["localizacion_dir_imagen_vacio"]; }
        }

        #endregion
    }
}