using System;
using System.Data;
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

/// <summary>
/// Descripción breve de tp_plan
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_plan
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_plan = 0;
            private int _id_contrato = 0;
            private int _id_usuario = 0;
            private int _id_moneda = 0;
            private DateTime _fecha = DateTime.Now;
            private decimal _monto = 0;
            private DateTime _mes_inicio = DateTime.Now;
            private int _meses_restriccion = 0;
            private int _meses_reversion = 0;
            private int _meses_consecutivo = 0;

            private string _codigo_moneda = "";
            private string _nombre_usuario = "";
            
            //Propiedades públicas
            public int id_plan { get { return _id_plan; } set { _id_plan = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            public DateTime mes_inicio { get { return _mes_inicio; } set { _mes_inicio = value; } }
            public int meses_restriccion { get { return _meses_restriccion; } set { _meses_restriccion = value; } }
            public int meses_reversion { get { return _meses_reversion; } set { _meses_reversion = value; } }
            public int meses_consecutivo { get { return _meses_consecutivo; } set { _meses_consecutivo = value; } }

            public string codigo_moneda { get { return _codigo_moneda; } }
            public string nombre_usuario { get { return _nombre_usuario; } }
            #endregion

            #region Constructores
            public tp_plan(int Id_plan)
            {
                _id_plan = Id_plan;
                RecuperarDatos();
            }
            public tp_plan(int Id_contrato, int Id_moneda, decimal Monto, DateTime Mes_inicio, 
                int Meses_restriccion, int Meses_reversion, int Meses_consecutivo)
            {
                _id_contrato = Id_contrato;
                _id_moneda = Id_moneda;
                _monto = Monto;
                _mes_inicio = Mes_inicio;
                _meses_restriccion = Meses_restriccion;
                _meses_reversion = Meses_reversion;
                _meses_consecutivo = Meses_consecutivo;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static int Actual(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_plan_Actual");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static DataTable Lista(int Id_contrato)
            {
                //[id_estadocontrato],[id_contrato],[id_estado],[fecha],[usuario],[num_contrato],[estado_codigo],[estado_nombre],[observacion]
                DbCommand cmd = db1.GetStoredProcCommand("tp_plan_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_plan_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_plan", DbType.Int32, _id_plan);

                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_moneda", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "monto", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "mes_inicio", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "meses_restriccion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "meses_reversion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "meses_consecutivo", DbType.Int32, 32);

                    db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 20);
                    db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _id_moneda = (int)db1.GetParameterValue(cmd, "id_moneda");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _monto = (decimal)(double)db1.GetParameterValue(cmd, "monto");
                    _mes_inicio = (DateTime)db1.GetParameterValue(cmd, "mes_inicio");
                    _meses_restriccion = (int)db1.GetParameterValue(cmd, "meses_restriccion");
                    _meses_reversion = (int)db1.GetParameterValue(cmd, "meses_reversion");
                    _meses_consecutivo = (int)db1.GetParameterValue(cmd, "meses_consecutivo");

                    _codigo_moneda = (string)db1.GetParameterValue(cmd, "codigo_moneda");
                    _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_plan_Insertar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_moneda", DbType.Int32, _id_moneda);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                    db1.AddInParameter(cmd, "mes_inicio", DbType.DateTime, _mes_inicio);
                    db1.AddInParameter(cmd, "meses_restriccion", DbType.Int32, _meses_restriccion);
                    db1.AddInParameter(cmd, "meses_reversion", DbType.Int32, _meses_reversion);
                    db1.AddInParameter(cmd, "meses_consecutivo", DbType.Int32, _meses_consecutivo);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_plan = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion

        }
    }
}
