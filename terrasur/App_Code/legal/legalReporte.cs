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
/// Summary description for legalReporte
/// </summary>
namespace terrasur
{
    public class legalReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas

        #endregion

        #region Constructores

        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ReporteNegociosFolios(DateTime Fecha,
            int Id_localizacion, int Id_urbanizacion, int Id_manzano, int Id_lote, string Id_estado, string Num_contrato,
            string Id_negocio,
            string Legal_id_negocio, int Id_estadotramite, DateTime Legal_negocio_fecha_inicio, DateTime Legal_negocio_fecha_fin,
            int Con_folio, string Num_folio, int Entregado, DateTime Entregado_fecha_inicio, DateTime Entregado_fecha_fin,
            bool Varias_observaciones)
        {
            //
            DbCommand cmd = db1.GetStoredProcCommand("legal_ReporteNegociosFolios");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);

            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            db1.AddInParameter(cmd, "id_estado", DbType.String, Id_estado);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);

            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);

            db1.AddInParameter(cmd, "legal_id_negocio", DbType.String, Legal_id_negocio);
            db1.AddInParameter(cmd, "id_estadotramite", DbType.Int32, Id_estadotramite);
            db1.AddInParameter(cmd, "legal_negocio_fecha_inicio", DbType.DateTime, Legal_negocio_fecha_inicio);
            db1.AddInParameter(cmd, "legal_negocio_fecha_fin", DbType.DateTime, Legal_negocio_fecha_fin);

            db1.AddInParameter(cmd, "con_folio", DbType.Int32, Con_folio);
            db1.AddInParameter(cmd, "num_folio", DbType.String, Num_folio);
            db1.AddInParameter(cmd, "entregado", DbType.Int32, Entregado);
            db1.AddInParameter(cmd, "entregado_fecha_inicio", DbType.DateTime, Entregado_fecha_inicio);
            db1.AddInParameter(cmd, "entregado_fecha_fin", DbType.DateTime, Entregado_fecha_fin);

            db1.AddInParameter(cmd, "varias_observaciones", DbType.Boolean, Varias_observaciones);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor

        #endregion
    }
}