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
/// Summary description for grupo_venta
/// </summary>
namespace terrasur
{
    public class grupo_venta
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupoventa = 0;
        private int _id_director = 0;
        private string _nombre = "";
        private bool _activo = false;
        private bool _en_planilla = false;

        private int _num_promotor = 0;
        private int _num_promotor_activo = 0;
        private int _num_asignacion = 0;
        private string _nombre_director = "";

        //Propiedades públicas
        public int id_grupoventa { get { return _id_grupoventa; } set { _id_grupoventa = value; } }
        public int id_director { get { return _id_director; } set { _id_director = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public bool en_planilla { get { return _en_planilla; } set { _en_planilla = value; } }

        public int num_promotor { get { return _num_promotor; } }
        public int num_promotor_activo { get { return _num_promotor_activo; } }
        public int num_asignacion { get { return _num_asignacion; } }
        public string nombre_director { get { return _nombre_director; } }
        #endregion

        #region Constructores
        public grupo_venta(int Id_grupoventa)
        {
            _id_grupoventa = Id_grupoventa;
            RecuperarDatos();
        }
        public grupo_venta(int Id_director, string Nombre, bool Activo, bool En_planilla)
        {
            _id_director = Id_director;
            _nombre = Nombre;
            _activo = Activo;
            _en_planilla = En_planilla;
        }
        public grupo_venta(int Id_grupoventa, int Id_director, string Nombre, bool Activo, bool En_planilla)
        {
            _id_grupoventa = Id_grupoventa;
            _id_director = Id_director;
            _nombre = Nombre;
            _activo = Activo;
            _en_planilla = En_planilla;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_grupoventa],[id_director],[nombre],[activo],[en_planilla],[num_promotor],[num_promotor_activo],[num_asignacion],[nombre_director]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista_ParaDropDownList()
        {
            //[id_grupoventa],[nombre]
            DataTable tabla1 = grupo_venta.Lista();
            DataTable tabla2 = new DataTable();
            tabla2.Columns.Add("id_grupoventa", typeof(Int32));
            tabla2.Columns.Add("nombre", typeof(string));
            foreach (DataRow fila1 in tabla1.Rows)
            {
                DataRow fila2 = tabla2.NewRow();
                fila2["id_grupoventa"] = fila1["id_grupoventa"];
                fila2["nombre"] = "Grupo: " + fila1["nombre"].ToString() + " (" + fila1["nombre_director"].ToString() + ")";
                tabla2.Rows.Add(fila2);
            }
            return tabla2;
        }

        public static DataTable ListaActivoConPromotor(int Id_grupoventa)
        {
            //[id_grupoventa],[id_director],[nombre],[num_promotor_activo],[nombre_director]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_ListaActivoConPromotor");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivoOConVentas()
        {
            //[id_grupoventa],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_ListaActivoOConVentas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarNombre(bool Inserta, int Id_grupoventa, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_VerificarNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
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
                DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_RecuperarDatos");
                db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, _id_grupoventa);
                db1.AddOutParameter(cmd, "id_director", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "en_planilla", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_promotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_promotor_activo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_asignacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_director", DbType.String, 300);

                db1.ExecuteNonQuery(cmd);
                _id_director = (int)db1.GetParameterValue(cmd, "id_director");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _en_planilla = (bool)db1.GetParameterValue(cmd, "en_planilla");

                _num_promotor = (int)db1.GetParameterValue(cmd, "num_promotor");
                _num_promotor_activo = (int)db1.GetParameterValue(cmd, "num_promotor_activo");
                _num_asignacion = (int)db1.GetParameterValue(cmd, "num_asignacion");
                _nombre_director = (string)db1.GetParameterValue(cmd, "nombre_director");
            }
            catch { }
        }

        public bool Insertar()
        {
            if (VerificarNombre(true, 0, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_director);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "en_planilla", DbType.Boolean, _en_planilla);
                    _id_grupoventa = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Actualizar()
        {
            if (VerificarNombre(false, _id_grupoventa, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_Actualizar");
                    db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, _id_grupoventa);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_director);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "en_planilla", DbType.Boolean, _en_planilla);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_venta_Eliminar");
                db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, _id_grupoventa);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}