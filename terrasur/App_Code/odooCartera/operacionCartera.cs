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

namespace terrasur
{
    /// <summary>
    /// Descripción breve de operacionCartera
    /// </summary>
    public class operacionCartera
    {
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_operacioncartera = 0;
        private string _nombre = "";
        private bool _activo = true;
        private int _usuario = 0;
        //Propiedades públicas
        public int id_operacioncartera { get { return _id_operacioncartera; } set { _id_operacioncartera = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public int usuario { get { return _usuario; } set { _usuario = value; } }
        #endregion

        #region Constructores
        public operacionCartera(int Id_operacioncartera)
        {
            _id_operacioncartera = Id_operacioncartera;
            RecuperarDatos();
        }

        public operacionCartera(string Nombre)
        {
            _nombre = Nombre;
            RecuperarDatosXnombre();
        }
        public operacionCartera(int Id_operacioncartera, string Nombre,bool Activo, int Usuario)
        {
            _id_operacioncartera = Id_operacioncartera;
            _nombre = Nombre;
            _activo = Activo;
            _usuario = Usuario;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_lote],[id_usuario],[fecha_registro],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[anterior_propietario],[num_partida]
            DbCommand cmd = db1.GetStoredProcCommand("odoo_operacion_cartera_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        //public static DataTable ListaDisponible(int Id_manzano)
        //{
        //    //[id_lote],[codigo]
        //    DbCommand cmd = db1.GetStoredProcCommand("lote_ListaDisponible");
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}
        //public static DataTable ListaContratos(int Id_lote)
        //{
        //    //[id_contrato],[numero_contrato],[descrip]
        //    DbCommand cmd = db1.GetStoredProcCommand("lote_ListaContratos");
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static bool VerificarCodigo(bool Inserta, int Id_manzano, int Id_lote, string Codigo)
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("lote_VerificarCodigo");
        //        db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
        //        db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
        //        db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
        //        db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
        //        if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
        //        else { return false; }
        //    }
        //    catch { return true; }
        //}

        //public static int Buscar(int Id_urbanizacion, bool Por_codigo_lote, string Codigo_numero)
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("lote_Buscar");
        //        db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
        //        db1.AddInParameter(cmd, "por_codigo_lote", DbType.Boolean, Por_codigo_lote);
        //        db1.AddInParameter(cmd, "codigo_numero", DbType.String, Codigo_numero);
        //        return (int)db1.ExecuteScalar(cmd);
        //    }
        //    catch { return 0; }
        //}
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_operacion_cartera_RecuperarDatos");
                db1.AddInParameter(cmd, "id_operacioncartera", DbType.Int32, _id_operacioncartera);

                db1.AddOutParameter(cmd, "nombre", DbType.String, 200);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 1 );
                db1.AddOutParameter(cmd, "usuario", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _usuario = (int)db1.GetParameterValue(cmd, "usuario");
            }
            catch { }
        }

        private void RecuperarDatosXnombre()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_operacion_cartera_RecuperarDatosXnombre");

                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);

                db1.AddOutParameter(cmd, "id_operacioncartera", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 1);
                db1.AddOutParameter(cmd, "usuario", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_operacioncartera = (int)db1.GetParameterValue(cmd, "id_operacioncartera");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _usuario = (int)db1.GetParameterValue(cmd, "usuario");
            }
            catch { }
        }
        public bool Insertar()
        {
            
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("odoo_operacion_cartera_Insertar");
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "actvo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
                    _id_operacioncartera = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
           
        }


        public bool Actualizar()
        {
            
                try
                {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_operacion_cartera_Actualizar");
                db1.AddInParameter(cmd, "id_operacioncartera", DbType.String, _id_operacioncartera);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "actvo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
                db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
       
        }

        public bool Eliminar()
        {
            
                try
                {

                    DbCommand cmd = db1.GetStoredProcCommand("odoo_operacion_cartera_Eliminar");
                    db1.AddInParameter(cmd, "id_operacioncartera", DbType.Int32, _id_operacioncartera);
                    db1.AddInParameter(cmd, "usuario", DbType.Int32, _usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            
           
        }
        #endregion
    }
}
