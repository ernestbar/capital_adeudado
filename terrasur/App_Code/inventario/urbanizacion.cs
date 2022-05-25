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
/// Summary description for urbanizacion
/// </summary>
namespace terrasur
{
    public class urbanizacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_urbanizacion = 0;
        private int _id_localizacion = 0;
        private string _codigo = "";
        private string _nombre_corto = "";
        private string _nombre = "";
        private decimal _mantenimiento_sus = 0;
        private decimal _costo_m2_sus = 0;
        private decimal _precio_m2_sus = 0;
        private string _imagen = "";
        private bool _activo = false;

        private int _num_manzano = 0;
        private int _num_lote = 0;
        private string _nombre_completo = "";

        //Propiedades públicas
        public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
        public int id_localizacion { get { return _id_localizacion; } set { _id_localizacion = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre_corto { get { return _nombre_corto; } set { _nombre_corto = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public decimal mantenimiento_sus { get { return _mantenimiento_sus; } set { _mantenimiento_sus = value; } }
        public decimal costo_m2_sus { get { return _costo_m2_sus; } set { _costo_m2_sus = value; } }
        public decimal precio_m2_sus { get { return _precio_m2_sus; } set { _precio_m2_sus = value; } }
        public string imagen { get { return _imagen; } set { _imagen = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_manzano { get { return _num_manzano; } }
        public int num_lote { get { return _num_lote; } }
        public string nombre_completo { get { return _nombre_completo; } }
        #endregion

        #region Constructores
        public urbanizacion(int Id_urbanizacion)
        {
            _id_urbanizacion = Id_urbanizacion;
            RecuperarDatos();
        }
        public urbanizacion(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        public urbanizacion(int Id_localizacion, string Codigo, string Nombre_corto, string Nombre, decimal Mantenimiento_sus, decimal Costo_m2_sus, decimal Precio_m2_sus, bool Activo)
        {
            _id_localizacion = Id_localizacion;
            _codigo = Codigo;
            _nombre_corto = Nombre_corto;
            _nombre = Nombre;
            _mantenimiento_sus = Mantenimiento_sus;
            _costo_m2_sus = Costo_m2_sus;
            _precio_m2_sus = Precio_m2_sus;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_localizacion)
        {
            //[id_urbanizacion],[codigo],[nombre_corto],[nombre]
            //[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaPorActivo(int Id_localizacion, bool Activo)
        {
            //[id_urbanizacion],[id_localizacion],[codigo],[nombre_corto],[nombre]
            //[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_ListaPorActivo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "activo", DbType.Boolean, Activo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorActivo_para_ddl(int Id_localizacion, bool Activo)
        {
            //[id_urbanizacion],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_ListaPorActivo_para_ddl");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "activo", DbType.Boolean, Activo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable Lista_para_ddl(int Id_localizacion)
        {
            //[id_urbanizacion],[nombre_completo]
            DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_Lista_para_ddl");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarCodigoNombre(bool Inserta, int Id_urbanizacion, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
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
                DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_urbanizacion0", DbType.Int32, _id_urbanizacion);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_localizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_corto", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "mantenimiento_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "costo_m2_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "precio_m2_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "imagen", DbType.String, 100);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_manzano", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_lote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_completo", DbType.String, 160);

                db1.ExecuteNonQuery(cmd);
                _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                _id_localizacion = (int)db1.GetParameterValue(cmd, "id_localizacion");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre_corto = (string)db1.GetParameterValue(cmd, "nombre_corto");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _mantenimiento_sus = (decimal)(double)db1.GetParameterValue(cmd, "mantenimiento_sus");
                _costo_m2_sus = (decimal)(double)db1.GetParameterValue(cmd, "costo_m2_sus");
                _precio_m2_sus = (decimal)(double)db1.GetParameterValue(cmd, "precio_m2_sus");
                _imagen = (string)db1.GetParameterValue(cmd, "imagen");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");

                _num_manzano = (int)db1.GetParameterValue(cmd, "num_manzano");
                _num_lote = (int)db1.GetParameterValue(cmd, "num_lote");
                _nombre_completo = (string)db1.GetParameterValue(cmd, "nombre_completo");
            }
            catch { }
        }
        public bool Insertar()
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_Insertar");
                    db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, _id_localizacion);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre_corto", DbType.String,_nombre_corto);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, _mantenimiento_sus);
                    db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, _costo_m2_sus);
                    db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, _precio_m2_sus);
                    db1.AddInParameter(cmd, "imagen", DbType.String, _imagen);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    _id_urbanizacion = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }


        public bool Actualizar()
        {
            if (VerificarCodigoNombre(false, _id_urbanizacion, _codigo, _nombre) == false)
            {

                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_Actualizar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, _id_localizacion);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre_corto", DbType.String, _nombre_corto);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, _mantenimiento_sus);
                    db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, _costo_m2_sus);
                    db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, _precio_m2_sus);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar()
        {
            if (this._num_manzano == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_Eliminar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public void ImagenActualizar(int Id_urbanizacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_ImagenActualizar");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.String, Id_urbanizacion);
                db1.AddInParameter(cmd, "imagen", DbType.String, _imagen);
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }

        public static string ImagenDireccion(string Img)
        {
            string dir_upload = ConfigurationManager.AppSettings["urbanizacion_dir_imagen"];
            if (Img != "" && System.IO.File.Exists(HttpContext.Current.Server.MapPath(dir_upload + Img)) == true) { return dir_upload + Img; }
            else { return ConfigurationManager.AppSettings["urbanizacion_dir_imagen_vacio"]; }
        }

        public void lotesActualizarCosto(int Id_urbanizacion, decimal Costo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_lotesActualizarCosto");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, Costo);
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }
        public void lotesActualizarPrecio(int Id_urbanizacion, decimal Precio)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("urbanizacion_lotesActualizarPrecio");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.String, Id_urbanizacion);
                db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, Precio);
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }


        #endregion
    }
}