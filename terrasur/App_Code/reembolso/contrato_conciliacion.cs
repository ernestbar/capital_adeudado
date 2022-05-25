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
/// Descripción breve de contrato_conciliacion
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class contrato_conciliacion
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_contrato = 0;
            private DateTime _fecha = DateTime.Now;
            private int _id_estadoconciliacion = 0;

            //Propiedades públicas
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public int id_estadoconciliacion { get { return _id_estadoconciliacion; } set { _id_estadoconciliacion = value; } }
            #endregion

            #region Constructores
            public contrato_conciliacion(int Id_contrato)
            {
                _id_contrato = Id_contrato;
                RecuperarDatos();
            }

            public contrato_conciliacion(int Id_contrato, int Id_estadoconciliacion)
            {
                _id_contrato = Id_contrato;
                _id_estadoconciliacion = Id_estadoconciliacion;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_conciliacion_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static bool VerificarActualizar(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("contrato_conciliacion_VerificarActualizar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (bool)db1.ExecuteScalar(cmd);
                }
                catch { return false; }
            }
            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("contrato_conciliacion_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                    db1.AddOutParameter(cmd, "id_estadoconciliacion", DbType.Int32, 32);
                    db1.ExecuteNonQuery(cmd);

                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _id_estadoconciliacion = (int)db1.GetParameterValue(cmd, "id_estadoconciliacion");
                }
                catch { }
            }

            public bool Actualizar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("contrato_conciliacion_Actualizar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_estadoconciliacion", DbType.Int32, _id_estadoconciliacion);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion
        }
    }
}