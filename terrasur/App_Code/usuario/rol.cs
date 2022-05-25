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
/// Summary description for rol
/// </summary>
namespace terrasur
{
    public class rol
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_rol = 0;
        private int _id_modulo = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_rol { get { return _id_rol; } set { _id_rol = value; } }
        public int id_modulo { get { return _id_modulo; } set { _id_modulo = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public rol(int Id_rol)
        {
            _id_rol = Id_rol;
            RecuperarDatos();
        }
        public rol(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_rol],[id_modulo],[codigo],[nombre],[num_usuario_activo],[num_usuario_total]
            DbCommand cmd = db1.GetStoredProcCommand("rol_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable Lista(bool para_menu)
        {
            //[id_rol],[id_modulo],[codigo],[nombre],[num_usuario_activo],[num_usuario_total]
            DbCommand cmd = db1.GetStoredProcCommand("rol_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            if (para_menu == true)
            {
                DataRow todos = tabla.NewRow();
                todos["id_rol"] = 0;
                todos["codigo"] = "Todos";
                todos["nombre"] = "Todos";
                tabla.Rows.InsertAt(todos, 0);
            }
            return tabla;
        }
        public static DataTable ListaPorUsuario(int Id_usuario)
        {
            //[id_rol],[id_modulo],[codigo],[nombre],[modulo_codigo],[modulo_nombre]
            DbCommand cmd = db1.GetStoredProcCommand("rol_ListaPorUsuario");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static string ListaPorUsuario_String(int Id_usuario)
        {
            //[id_rol],[codigo],[nombre]
            System.Text.StringBuilder st = new System.Text.StringBuilder();
            foreach (DataRow fila in ListaPorUsuario(Id_usuario).Rows) st.Append(fila["nombre"].ToString() + ", ");
            return st.ToString().Trim().TrimEnd(',');
        }
        public static DataTable ListaNuevoRol(int Id_usuario)
        {
            //[id_rol],[id_modulo],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("rol_ListaNuevoRol");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("rol_RecuperarDatos");
                db1.AddInParameter(cmd, "id_rol0", DbType.Int32, _id_rol);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_rol", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_modulo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_rol = (int)db1.GetParameterValue(cmd, "id_rol");
                _id_modulo = (int)db1.GetParameterValue(cmd, "id_modulo");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion
    }
}