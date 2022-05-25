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
/// Summary description for usuario
/// </summary>
namespace terrasur
{
    public class usuario
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_usuario = 0;
        private string _nombres = "";
        private string _paterno = "";
        private string _materno = "";
        private string _ci = "";
        private string _email = "";
        private string _imagen = "";
        private string _nombre_usuario = "";
        private string _password = "";
        private bool _activo = true;
        private bool _eliminado = false;
        private int _audit_id_usuario = 0;

        private bool _eliminable = true;
        private int _numero_roles = 0;

        //Propiedades públicas
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string nombres { get { return _nombres; } set { _nombres = value; } }
        public string paterno { get { return _paterno; } set { _paterno = value; } }
        public string materno { get { return _materno; } set { _materno = value; } }
        public string ci { get { return _ci; } set { _ci = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public string imagen { get { return _imagen; } set { _imagen = value; } }
        public string nombre_usuario { get { return _nombre_usuario; } set { _nombre_usuario = value; } }
        public string password { get { return _password; } set { _password = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public bool eliminado { get { return _eliminado; } set { _eliminado = value; } }
        public int audit_id_usuario { get { return _audit_id_usuario; } }

        public bool eliminable { get { return _eliminable; } }
        public int numero_roles { get { return _numero_roles; } }
        #endregion

        #region Constructores
        public usuario(int Id_usuario)
        {
            _id_usuario = Id_usuario;
            RecuperarDatos();
        }
        public usuario(string Nombres, string Paterno, string Materno, string Ci, string Email, string Nombre_usuario, string Password, bool Activo)
        {
            _nombres = Nombres;
            _paterno = Paterno;
            _materno = Materno;
            _ci = Ci;
            _email = Email;
            _nombre_usuario = Nombre_usuario;
            _password = Password;
            _activo = Activo;
        }
        public usuario(int Id_usuario, string Nombres, string Paterno, string Materno, string Ci, string Email, string Nombre_usuario, string Password, bool Activo)
        {
            _id_usuario = Id_usuario;
            _nombres = Nombres;
            _paterno = Paterno;
            _materno = Materno;
            _ci = Ci;
            _email = Email;
            _nombre_usuario = Nombre_usuario;
            _password = Password;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_rol, bool Eliminado, bool Busqueda,
            string Ci, string Paterno, string Materno, string Nombres, string Nombre_usuario)
        {
            //[id_usuario],[nombres],[paterno],[materno],[ci],[email],[imagen],[nombre_usuario],[password],[activo],[eliminable],[roles]
            DbCommand cmd = db1.GetStoredProcCommand("usuario_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
            db1.AddInParameter(cmd, "eliminado", DbType.Boolean, Eliminado);
            db1.AddInParameter(cmd, "busqueda", DbType.Boolean, Busqueda);

            db1.AddInParameter(cmd, "ci", DbType.String, Ci);
            db1.AddInParameter(cmd, "paterno", DbType.String, Paterno);
            db1.AddInParameter(cmd, "materno", DbType.String, Materno);
            db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
            db1.AddInParameter(cmd, "nombre_usuario", DbType.String, Nombre_usuario);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            tabla.Columns.Add("roles");
            if (Id_rol == 0) foreach (DataRow fila in tabla.Rows) fila["roles"] = rol.ListaPorUsuario_String((int)fila["id_usuario"]);
            return tabla;
        }

        public static int ObtenerIdPorNombreUsuario(string Nombre_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_ObtenerIdPorNombreUsuario");
                db1.AddInParameter(cmd, "nombre_usuario", DbType.String, Nombre_usuario);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static string ObtenerNombreUsuarioPorId(int Id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_ObtenerNombreUsuarioPorId");
                db1.AddInParameter(cmd, "id_usuario", DbType.String, Id_usuario);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                db1.ExecuteNonQuery(cmd);
                return db1.GetParameterValue(cmd, "nombre_usuario").ToString();
            }
            catch { return ""; }
        }

        public static string ObtenerNombreCompletoPorId(int Id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_ObtenerNombreCompletoPorId");
                db1.AddInParameter(cmd, "id_usuario", DbType.String, Id_usuario);
                db1.AddOutParameter(cmd, "nombre_completo", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                return db1.GetParameterValue(cmd, "nombre_completo").ToString();
            }
            catch { return ""; }
        }

        public static DataTable ListaCajerosNoEliminados()
        {
            //[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("usuario_ListaCajerosNoEliminados");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["cajero_codigo"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_RecuperarDatos");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddOutParameter(cmd, "nombres", DbType.String, 100);
                db1.AddOutParameter(cmd, "paterno", DbType.String, 100);
                db1.AddOutParameter(cmd, "materno", DbType.String, 100);
                db1.AddOutParameter(cmd, "ci", DbType.String, 50);
                db1.AddOutParameter(cmd, "email", DbType.String, 200);
                db1.AddOutParameter(cmd, "imagen", DbType.String, 200);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "password", DbType.String, 300);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "eliminado", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "eliminable", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "numero_roles", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _nombres = (string)db1.GetParameterValue(cmd, "nombres");
                _paterno = (string)db1.GetParameterValue(cmd, "paterno");
                _materno = (string)db1.GetParameterValue(cmd, "materno");
                _ci = (string)db1.GetParameterValue(cmd, "ci");
                _email = (string)db1.GetParameterValue(cmd, "email");
                _imagen = (string)db1.GetParameterValue(cmd, "imagen");
                _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                _password = (string)db1.GetParameterValue(cmd, "password");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _eliminado = (bool)db1.GetParameterValue(cmd, "eliminado");

                _eliminable = (bool)db1.GetParameterValue(cmd, "eliminable");
                _numero_roles = (int)db1.GetParameterValue(cmd, "numero_roles");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarTodo(true, 0, _nombres, _paterno, _materno, _ci, _nombre_usuario) == false && VerificarMembershipUser(_nombre_usuario) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("usuario_Insertar");
                    db1.AddInParameter(cmd, "nombres", DbType.String, _nombres);
                    db1.AddInParameter(cmd, "paterno", DbType.String, _paterno);
                    db1.AddInParameter(cmd, "materno", DbType.String, _materno);
                    db1.AddInParameter(cmd, "ci", DbType.String, _ci);
                    db1.AddInParameter(cmd, "email", DbType.String, _email);
                    db1.AddInParameter(cmd, "nombre_usuario", DbType.String, _nombre_usuario);
                    db1.AddInParameter(cmd, "password", DbType.String, _password);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);

                    _id_usuario = (int)db1.ExecuteScalar(cmd);
                    MembershipCreateStatus status;
                    MembershipUser new_user = Membership.CreateUser(_nombre_usuario, _password, _email, "nothing", "nothing", _activo, out status);
                    if (new_user != null) { return true; }
                    else { this.Eliminar(context_id_usuario); return false; }
                }
                catch { this.Eliminar(context_id_usuario); return false; }
            }
            else { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarTodo(false, _id_usuario, _nombres, _paterno, _materno, _ci, _nombre_usuario) == false)
            {
                try
                {
                    bool correcto = true;
                    usuario antiguo_usuario = new usuario(this._id_usuario);
                    if (this._password == "") this._password = antiguo_usuario.password;

                    if (antiguo_usuario.nombre_usuario != this.nombre_usuario)
                    {
                        if (VerificarMembershipUser(this.nombre_usuario) == false)
                        {
                            MembershipCreateStatus status;
                            MembershipUser new_user = Membership.CreateUser(this._nombre_usuario, this._password, this._email, "nothing", "nothing", this._activo, out status);
                            if (new_user != null)
                            {
                                Roles.AddUserToRoles(new_user.UserName, Roles.GetRolesForUser(antiguo_usuario.nombre_usuario));
                                Membership.DeleteUser(antiguo_usuario.nombre_usuario, true);
                            }
                            else { correcto = false; }
                        }
                        else { correcto = false; }
                    }
                    else if (this._password != antiguo_usuario.password)
                    {
                        MembershipUser current_user = Membership.GetUser(this.nombre_usuario);
                        if (current_user.ChangePassword(antiguo_usuario.password, this.password) == true)
                        {
                            current_user.IsApproved = this.activo;
                            current_user.Email = this.email;
                            Membership.UpdateUser(current_user);
                        }
                        else { correcto = false; }
                    }
                    else if (this._activo != antiguo_usuario.activo || this._email != antiguo_usuario.email)
                    {
                        MembershipUser current_user = Membership.GetUser(this.nombre_usuario);
                        current_user.IsApproved = this.activo;
                        current_user.Email = this.email;
                        Membership.UpdateUser(current_user);
                    }

                    if (correcto == true)
                    {
                        DbCommand cmd = db1.GetStoredProcCommand("usuario_Actualizar");
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                        db1.AddInParameter(cmd, "nombres", DbType.String, _nombres);
                        db1.AddInParameter(cmd, "paterno", DbType.String, _paterno);
                        db1.AddInParameter(cmd, "materno", DbType.String, _materno);
                        db1.AddInParameter(cmd, "ci", DbType.String, _ci);
                        db1.AddInParameter(cmd, "email", DbType.String, _email);
                        db1.AddInParameter(cmd, "nombre_usuario", DbType.String, _nombre_usuario);
                        db1.AddInParameter(cmd, "password", DbType.String, _password);
                        db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                        db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                        db1.ExecuteNonQuery(cmd);
                        return true;
                    }
                    else { return false; }
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int Id_rol, int context_id_usuario)
        {
            //if (Id_rol == 0 && _numero_roles == 1) Id_rol = (int)rol.ListaPorUsuario(_id_usuario).Rows[0]["id_rol"];
            if (_numero_roles > 1) { return usuario_rol.InsertarEliminar(false, _id_usuario, Id_rol); }
            else { return Eliminar(context_id_usuario); }
        }

        private bool Eliminar(int context_id_usuario)
        {
            try
            {
                if (_eliminable)
                {
                    DbCommand cmd = db1.GetStoredProcCommand("usuario_Eliminar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    Membership.DeleteUser(_nombre_usuario, true);
                    return true;
                }
                else { return EliminarTemporalmente(context_id_usuario); }
            }
            catch { return false; }
        }

        public bool EliminarTemporalmente(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_EliminarTemporalmente");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);

                MembershipUser current_user = Membership.GetUser(this._nombre_usuario);
                current_user.IsApproved = false;
                Membership.UpdateUser(current_user);

                return true;
            }
            catch { return false; }
        }

        public bool RecuperarEliminado(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_RecuperarEliminado");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);

                MembershipUser current_user = Membership.GetUser(this._nombre_usuario);
                current_user.IsApproved = true;
                Membership.UpdateUser(current_user);

                return true;
            }
            catch { return false; }
        }

        public void ImagenActualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_ImagenActualizar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "imagen", DbType.String, _imagen);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }

        public static string ImagenDireccion(string Img)
        {
            string dir_upload = ConfigurationManager.AppSettings["usuario_dir_imagen"];
            if (Img != "" && System.IO.File.Exists(HttpContext.Current.Server.MapPath(dir_upload + Img)) == true) { return dir_upload + Img; }
            else { return ConfigurationManager.AppSettings["usuario_dir_imagen_vacio"]; }
        }
        #endregion

        #region Verificaciones
        public static bool VerificarTodo(bool Inserta, int Id_usuario, string Nombres, string Paterno, string Materno, string CI, string Nombre_usuario)
        {
            bool existe = false;
            if (VerificarNombreUsuario(Inserta, Id_usuario, Nombre_usuario) == true) existe = true;
            else if (VerificarCI(Inserta, Id_usuario, CI) == true) existe = true;
            //else if (VerificarNombreCompleto(Inserta, Id_usuario, Nombres, Paterno, Materno) == true) existe = true;
            return existe;
        }

        public static bool VerificarNombreCompleto(bool Inserta, int Id_usuario, string Nombres, string Paterno, string Materno)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_VerificarNombreCompleto");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
                db1.AddInParameter(cmd, "paterno", DbType.String, Paterno);
                db1.AddInParameter(cmd, "materno", DbType.String, Materno);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool VerificarCI(bool Inserta, int Id_usuario, string CI)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_VerificarCI");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "ci", DbType.String, CI);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool VerificarNombreUsuario(bool Inserta, int Id_usuario, string Nombre_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_VerificarNombreUsuario");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "nombre_usuario", DbType.String, Nombre_usuario);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool VerificarMembershipUser(string Nombre_usuario)
        {
            if (Membership.GetUser(Nombre_usuario) != null) { return true; }
            else { return false; }
        }
        #endregion
    }
}