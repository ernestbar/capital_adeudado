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
/// Summary description for impresora_usuario
/// </summary>
namespace terrasur
{
    public class impresora_usuario
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public impresora_usuario() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Verificar(int Id_impresora, int Id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("impresora_usuario_Verificar");
                db1.AddInParameter(cmd, "id_impresora", DbType.Int32, Id_impresora);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            } 
            catch { return true; }

        }

        public static bool InsertarEliminar(bool Inserta, int Id_impresora, int Id_usuario)
        {
            bool verifica = Verificar(Id_impresora, Id_usuario);
            if ((Inserta == true && verifica == false) || (Inserta == false && verifica == true))
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("impresora_usuario_InsertarEliminar");
                    db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                    db1.AddInParameter(cmd, "id_impresora", DbType.Int32, Id_impresora);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }

        public static DataTable ListaImpresoraPorUsuario(int Id_usuario, bool Factura, bool Recibo, bool Comprobante, bool Solo_activos)
        {
            DbCommand cmd = db1.GetStoredProcCommand("impresora_usuario_ListaImpresoraPorUsuario");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "factura", DbType.Boolean, Factura);
            db1.AddInParameter(cmd, "recibo", DbType.Boolean, Recibo);
            db1.AddInParameter(cmd, "comprobante", DbType.Boolean, Comprobante);
            db1.AddInParameter(cmd, "solo_activos", DbType.Boolean, Solo_activos);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaImpresoraPorUsuario2(int Id_usuario, bool Solo_activos)
        {
            //[id_impresora],[nombre],[direccion_red],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("impresora_usuario_ListaImpresoraPorUsuario2");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "solo_activos", DbType.Boolean, Solo_activos);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaUsuarios()
        {
            DbCommand cmd = db1.GetStoredProcCommand("impresora_usuario_ListaUsuarios");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}