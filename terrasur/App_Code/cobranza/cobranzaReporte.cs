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
/// Summary description for cobranzaReporte
/// </summary>
/// 
namespace terrasur
{
    public class cobranzaReporte
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Constructores
        public cobranzaReporte()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ReporteAsignacionRecibos(DateTime Desde, DateTime Hasta, int Id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteAsignacionRecibos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReportePorCobrador(DateTime Desde, DateTime Hasta, int Id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReportePorCobrador");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteControlDiarioRecibos(DateTime Desde, DateTime Hasta, int Id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteControlDiarioRecibos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteReciboCobrador(int Desde, int Hasta, int Estado)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteReciboCobrador");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "desde", DbType.Int32, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.Int32, Hasta);
            db1.AddInParameter(cmd, "estado", DbType.Int32, Estado);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteAsignacionCobrador(int Id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteAsignacionCobrador");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteContratoCobrarCobrador(int Id_usuario, DateTime Desde, DateTime Hasta)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteContratoCobrarCobrador");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "desde", DbType.DateTime, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.DateTime, Hasta);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteClienteZona(int Id_sector, int Id_zona, bool Cobrador, DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteClienteZona");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sector", DbType.Int32, Id_sector);
            db1.AddInParameter(cmd, "id_zona", DbType.Int32, Id_zona);
            db1.AddInParameter(cmd, "cobrador", DbType.Boolean, Cobrador);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteCobranzaVentasGeneral_original(DateTime Fecha_incio, DateTime Fecha_fin, int Cobrador,int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteVentasGeneral");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_incio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "por_cobrador", DbType.Int32, Cobrador);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ReporteCobranzaVentasGeneral(DateTime Fecha_inicio, DateTime Fecha_fin, int Cobrador, int Id_moneda,bool Consolidado)
        {
            if (Consolidado == false) { return ReporteCobranzaVentasGeneral_original(Fecha_inicio, Fecha_fin,Cobrador, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteCobranzaVentasGeneral_original(Fecha_inicio, Fecha_fin, Cobrador, Id_moneda);
                    tabla_bs = ReporteCobranzaVentasGeneral_original(Fecha_inicio, Fecha_fin, Cobrador, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteCobranzaVentasGeneral_original(Fecha_inicio, Fecha_fin, Cobrador, Id_segunda_moneda);
                    tabla_bs = ReporteCobranzaVentasGeneral_original(Fecha_inicio, Fecha_fin, Cobrador, Id_moneda);
                }//
                return general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio,descuento,precio_final,cuota_inicial,cuota_base", false, false, "", "negocio,contrato_numero");
            }

            //DbCommand cmd = db1.GetStoredProcCommand("cobranza_ReporteVentasGeneral");
            //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            //db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_incio);
            //db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            //db1.AddInParameter(cmd, "por_cobrador", DbType.Boolean, Cobrador);
            //return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion
    }
}