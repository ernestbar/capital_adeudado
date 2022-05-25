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
/// Descripción breve de tp_estado_contrato
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_estado_contrato
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_estadocontrato = 0;
            private int _id_contrato = 0;
            private int _id_estado = 0;
            private int _id_usuario = 0;
            private int _id_reversion = 0;
            private int _id_servicioprestado = 0;
            private DateTime _fecha = DateTime.Now;
            private string _observacion = "";

            private string _estado_codigo = "";
            private string _estado_nombre = "";
            private string _usuario_nombre = "";

            //Propiedades públicas
            public int id_estadocontrato { get { return _id_estadocontrato; } set { _id_estadocontrato = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_estado { get { return _id_estado; } set { _id_estado = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public int id_reversion { get { return _id_reversion; } set { _id_reversion = value; } }
            public int id_servicioprestado { get { return _id_servicioprestado; } set { _id_servicioprestado = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public string observacion { get { return _observacion; } set { _observacion = value; } }

            public string estado_codigo { get { return _estado_codigo; } }
            public string estado_nombre { get { return _estado_nombre; } }
            public string usuario_nombre { get { return _usuario_nombre; } }
            #endregion

            #region Constructores
            public tp_estado_contrato(int Id_estadocontrato)
            {
                _id_estadocontrato = Id_estadocontrato;
                RecuperarDatos();
            }

            public tp_estado_contrato(int Id_contrato, int Id_estado, int Id_reversion, int Id_servicioprestado, string Observacion)
            {
                _id_contrato = Id_contrato;
                _id_estado = Id_estado;
                _id_reversion = Id_reversion;
                _id_servicioprestado = Id_servicioprestado;
                _observacion = Observacion;
            }
            #endregion

            #region Métodos que NO requieren constructor

            public static int Actual(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_estado_contrato_Actual");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static DataTable Lista(int Id_contrato)
            {
                //[id_estadocontrato],[id_contrato],[id_estado],[fecha],[usuario],[num_contrato],[estado_codigo],[estado_nombre],[observacion]
                DbCommand cmd = db1.GetStoredProcCommand("tp_estado_contrato_Lista");
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
                    DbCommand cmd = db1.GetStoredProcCommand("tp_estado_contrato_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_estadocontrato", DbType.Int32, _id_estadocontrato);

                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_reversion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_servicioprestado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "observacion", DbType.String, 200);

                    db1.AddOutParameter(cmd, "estado_codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _id_reversion = (int)db1.GetParameterValue(cmd, "id_reversion");
                    _id_servicioprestado = (int)db1.GetParameterValue(cmd, "id_servicioprestado");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _observacion = (string)db1.GetParameterValue(cmd, "observacion");

                    _estado_codigo = (string)db1.GetParameterValue(cmd, "estado_codigo");
                    _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
                    _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_estado_contrato_Insertar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_estado", DbType.Int32, _id_estado);
                    db1.AddInParameter(cmd, "id_reversion", DbType.Int32, _id_reversion);
                    db1.AddInParameter(cmd, "id_servicioprestado", DbType.Int32, _id_servicioprestado);
                    db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_estadocontrato = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion


        }
    }
}