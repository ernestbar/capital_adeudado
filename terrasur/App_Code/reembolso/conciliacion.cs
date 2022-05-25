using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Text;
/// <summary>
/// Descripción breve de conciliacion
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class conciliacion
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_contrato = 0;
            private string _observacion = "";
            private int _id_lote = 0;
            private DateTime _fecha = DateTime.Now;

            //Propiedades públicas
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public string observacion { get { return _observacion; } set { _observacion = value; } }
            public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            #endregion

            #region Constructores
            public conciliacion(int Id_contrato, string Observacion, int Id_lote, DateTime Fecha)
            {
                _id_contrato = Id_contrato;
                _observacion = Observacion;
                _id_lote = Id_lote;
                _fecha = Fecha;
            }
            #endregion

            #region Métodos que NO requieren constructor

            #endregion

            #region Métodos que requieren constructor

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("contrato_conciliacion_Insertar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
                    db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch
                { 
                    return false;
                }
            }
            #endregion
        }
    }
}