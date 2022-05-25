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
/// Descripción breve de Class2
/// </summary>
namespace terrasur
{
    public class transaccionReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        //public transaccionReporte()
        //{
        //}
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ReporteDocumentos(
            DateTime Fecha_inicio, DateTime Fecha_final, int Id_transaccion, string Ids_transacciones
            , int Id_factura, int Id_recibo, int Id_comprobantedpr, bool Sin_docs_anulados
            )
        {
            DbCommand cmd = db1.GetStoredProcCommand("transaccion_ReporteDocumentos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);

            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_final", DbType.DateTime, Fecha_final);
            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
            db1.AddInParameter(cmd, "ids_transacciones", DbType.String, Ids_transacciones);

            db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
            db1.AddInParameter(cmd, "id_recibo", DbType.Int32, Id_recibo);
            db1.AddInParameter(cmd, "id_comprobantedpr", DbType.Int32, Id_comprobantedpr);
            db1.AddInParameter(cmd, "sin_docs_anulados", DbType.Boolean, Sin_docs_anulados);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ReporteRespaldo(
            DateTime Fecha_inicio, DateTime Fecha_final
            , int Trans_vigentes, int Con_factura
            , int Id_negocio, int Id_usuario
            , string Nit_razon_social, int Id_sucursal
            )
        {
            DbCommand cmd = db1.GetStoredProcCommand("transaccion_ReporteRespaldo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);

            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_final", DbType.DateTime, Fecha_final);

            db1.AddInParameter(cmd, "trans_vigentes", DbType.Int32, Trans_vigentes);
            db1.AddInParameter(cmd, "con_factura", DbType.Int32, Con_factura);

            db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);

            db1.AddInParameter(cmd, "nit_razon_social", DbType.String, Nit_razon_social);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaUsuariosTransaccion(bool Con_inactivos)
        {
            //[id_usuario],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("transaccion_ListaUsuariosTransaccion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "con_inactivos", DbType.Boolean, Con_inactivos);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}