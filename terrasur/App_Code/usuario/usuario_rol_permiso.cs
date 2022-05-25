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
/// Summary description for usuario_rol_permiso
/// </summary>
namespace terrasur
{
    public class usuario_rol_permiso
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        #endregion

        #region Constructores
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Verificar(int Id_usuario, int Id_rol, int Id_permiso)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_rol_permiso_Verificar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                db1.AddInParameter(cmd, "id_permiso", DbType.Int32, Id_permiso);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool InsertarEliminar(bool Inserta, int Id_usuario, int Id_rol, int Id_permiso)
        {
            bool verifica = Verificar(Id_usuario, Id_rol, Id_permiso);
            if ((Inserta == true && verifica == false) || (Inserta == false && verifica == true))
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("usuario_rol_permiso_InsertarEliminar");
                    db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                    db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                    db1.AddInParameter(cmd, "id_permiso", DbType.Int32, Id_permiso);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }

        public static DataTable ListaPermisoPorUsuarioRolRecurso(int Id_usuario, int Id_rol, int Id_recurso)
        {
            //[id_permiso],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("usuario_rol_permiso_ListaPermisoPorUsuarioRolRecurso");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
            db1.AddInParameter(cmd, "id_recurso", DbType.Int32, Id_recurso);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}