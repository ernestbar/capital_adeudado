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
/// Descripción breve de transaccion_impresion
/// </summary>
namespace terrasur
{
    public class transaccion_impresion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public transaccion_impresion() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static void Registrar(int Id_transaccion, string Ids_transacciones
            , int Id_factura, int Id_recibo, int Id_comprobantedpr, int Id_reciboregularizacion
            , int Id_usuario, string Impresora_nombre, string Impresora_direccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("transaccion_impresion_Registrar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                db1.AddInParameter(cmd, "ids_transacciones", DbType.String, Ids_transacciones);

                db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                db1.AddInParameter(cmd, "id_recibo", DbType.Int32, Id_recibo);
                db1.AddInParameter(cmd, "id_comprobantedpr", DbType.Int32, Id_comprobantedpr);
                db1.AddInParameter(cmd, "id_reciboregularizacion", DbType.Int32, Id_reciboregularizacion);

                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "impresora_nombre", DbType.String, Impresora_nombre);
                db1.AddInParameter(cmd, "impresora_direccion", DbType.String, Impresora_direccion);

                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}