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
/// Summary description for parametro_facturacion_negocio
/// </summary>
namespace terrasur
{
    public class parametro_facturacion_negocio
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        public parametro_facturacion_negocio() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaNegocio(int Id_parametrofacturacion)
        {
            //[negocio]
            DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_negocio_ListaNegocio");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, Id_parametrofacturacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static string ListaNegocio_String(int Id_parametrofacturacion)
        {
            DataTable tabla = ListaNegocio(Id_parametrofacturacion);
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            foreach (DataRow fila in tabla.Rows) { str.Append(fila["negocio"].ToString() + ", "); }
            if (str.ToString() == "") return "Ninguno";
            else return str.ToString().Trim().TrimEnd(',');
        }

        public static bool Verificar(int Id_parametrofacturacion, int Id_negocio)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_negocio_Verificar");
                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, Id_parametrofacturacion);
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool VerificarNegocioAsignado(int Id_sucursal, int Id_negocio, int Id_parametrofacturacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_negocio_VerificarNegocioAsignado");
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, Id_parametrofacturacion);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool InsertarEliminar(bool Inserta, int Id_parametrofacturacion, int Id_negocio, int context_id_usuario)
        {
            bool verifica = Verificar(Id_parametrofacturacion, Id_negocio);
            if ((Inserta == true && verifica == false) || (Inserta == false && verifica == true))
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_negocio_InsertarEliminar");
                    db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                    db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, Id_parametrofacturacion);
                    db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}