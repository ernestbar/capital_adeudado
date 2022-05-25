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
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for auditoriaReporte
/// </summary>
namespace terrasur
{
    public class auditoriaReporte
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
        public static DataTable Reporte(string Codigo_reporte, string Usuario, int Tipo_fecha,
            DateTime Fecha_inicio, DateTime Fecha_fin, string Numero_contrato, int Entero, string Cadena)
        {
            DbCommand cmd = db1.GetStoredProcCommand(Codigo_reporte);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "usuario", DbType.String, Usuario);
            db1.AddInParameter(cmd, "tipo_fecha", DbType.Int32, Tipo_fecha);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            db1.AddInParameter(cmd, "numero_contrato", DbType.String, Numero_contrato);
            db1.AddInParameter(cmd, "entero", DbType.Int32, Entero);
            db1.AddInParameter(cmd, "cadena", DbType.String, Cadena);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static void Reporte_pago_fuera_del_periodo_totales(DateTime Fecha_inicio, DateTime Fecha_fin, DateTime Periodo1_ini, DateTime Periodo1_fin, DateTime Periodo2_ini, DateTime Periodo2_fin,
            ref int Num_transacciones, ref int Num_transacciones_anuladas, ref int Num_facturas_anulados, ref int Num_recibos_anulados, ref int Num_comprobantes_anulados)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("audit_reporte_pago_fuera_del_periodo_totales");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "periodo1_ini", DbType.DateTime, Periodo1_ini);
                db1.AddInParameter(cmd, "periodo1_fin", DbType.DateTime, Periodo1_fin);
                db1.AddInParameter(cmd, "periodo2_ini", DbType.DateTime, Periodo2_ini);
                db1.AddInParameter(cmd, "periodo2_fin", DbType.DateTime, Periodo2_fin);
                db1.AddOutParameter(cmd, "num_transacciones", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_transacciones_anuladas", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_facturas_anulados", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_recibos_anulados", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_comprobantes_anulados", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                Num_transacciones = (int)db1.GetParameterValue(cmd, "num_transacciones");
                Num_transacciones_anuladas = (int)db1.GetParameterValue(cmd, "num_transacciones_anuladas");
                Num_facturas_anulados = (int)db1.GetParameterValue(cmd, "num_facturas_anulados");
                Num_recibos_anulados = (int)db1.GetParameterValue(cmd, "num_recibos_anulados");
                Num_comprobantes_anulados = (int)db1.GetParameterValue(cmd, "num_comprobantes_anulados");
            }
            catch { }
        }


        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
    public class xml_reporte_audit
    {
        #region Propiedades
        //Propiedades privadas
        private string _codigo = "";
        private string _nombre = "";
        private bool _parametro = false;
        private bool _contrato = false;
        private string _entero = "";
        private string _cadena = "";
        //Propiedades públicas
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool parametro { get { return _parametro; } set { _parametro = value; } }
        public bool contrato { get { return _contrato; } set { _contrato = value; } }
        public string entero { get { return _entero; } set { _entero = value; } }
        public string cadena { get { return _cadena; } set { _cadena = value; } }
        #endregion

        #region Constructores
        public xml_reporte_audit(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static XmlNodeList Lista(bool Parametro)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/reportesAuditoria.xml"));
            if (Parametro) return doc.SelectNodes(@"reportes/reporte[@parametro='true']");
            else return doc.SelectNodes(@"reportes/reporte[@parametro='false']");
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            if (codigo != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/reportesAuditoria.xml"));
                XmlNode reporte = doc.SelectSingleNode("/reportes/reporte[@codigo=\'" + codigo + "\']");
                if (reporte != null)
                {
                    _nombre = reporte.Attributes["nombre"].Value;
                    _parametro = bool.Parse(reporte.Attributes["parametro"].Value);
                    _contrato = bool.Parse(reporte.Attributes["contrato"].Value);
                    _entero = reporte.Attributes["entero"].Value;
                    _cadena = reporte.Attributes["cadena"].Value;
                }
            }
        }
        #endregion
    }
}