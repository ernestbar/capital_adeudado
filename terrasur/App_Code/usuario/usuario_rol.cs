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
/// Summary description for usuario_rol
/// </summary>
namespace terrasur
{
    public class usuario_rol
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        #endregion

        #region Constructores
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Verificar(int Id_usuario, int Id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_rol_Verificar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool Verificar(int Id_usuario, string Codigo_rol)
        {
            return Verificar(Id_usuario, new rol(Codigo_rol).id_rol);
        }

        public static bool InsertarEliminar(bool Inserta, int Id_usuario, int Id_rol)
        {
            bool verifica = Verificar(Id_usuario, Id_rol);
            if ((Inserta == true && verifica == false) || (Inserta == false && verifica == true))
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("usuario_rol_InsertarEliminar");
                    db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                    db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                    db1.ExecuteNonQuery(cmd);
                    if (Inserta == true) Roles.AddUserToRole(new usuario(Id_usuario).nombre_usuario, new rol(Id_rol).codigo);
                    else Roles.RemoveUserFromRole(new usuario(Id_usuario).nombre_usuario, new rol(Id_rol).codigo);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }

        public static int NumeroRolesPorUsuario(int Id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_rol_NumeroRolesPorUsuario");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}