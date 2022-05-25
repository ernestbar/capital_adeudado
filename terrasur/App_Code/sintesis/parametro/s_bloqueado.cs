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
/// Descripción breve de s_bloqueado
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_bloqueado
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_bloqueado = 0;
            private int _id_contrato = 0;
            private bool _activo = false;
            private DateTime _activo_fecha = DateTime.Now;
            private int _activo_id_usuario = 0;
            private string _activo_observacion = "";
            private DateTime _inactivo_fecha = DateTime.Now;
            private int _inactivo_id_usuario = 0;
            private string _inactivo_observacion = "";

            private string _num_contrato = "";

            //Propiedades públicas
            public int id_bloqueado { get { return _id_bloqueado; } set { _id_bloqueado = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public bool activo { get { return _activo; } set { _activo = value; } }
            public DateTime activo_fecha { get { return _activo_fecha; } set { _activo_fecha = value; } }
            public int activo_id_usuario { get { return _activo_id_usuario; } set { _activo_id_usuario = value; } }
            public string activo_observacion { get { return _activo_observacion; } set { _activo_observacion = value; } }
            public DateTime inactivo_fecha { get { return _inactivo_fecha; } set { _inactivo_fecha = value; } }
            public int inactivo_id_usuario { get { return _inactivo_id_usuario; } set { _inactivo_id_usuario = value; } }
            public string inactivo_observacion { get { return _inactivo_observacion; } set { _inactivo_observacion = value; } }

            public string num_contrato { get { return _num_contrato; } }
            #endregion

            #region Constructores
            public s_bloqueado(int Id_bloqueado)
            {
                _id_bloqueado = Id_bloqueado;
                RecuperarDatos();
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable ListaActivo()
            {
                //[id_bloqueado],[num_contrato],[estado],[activo_fecha],[activo_usuario],[activo_observacion]
                DbCommand cmd = db1.GetStoredProcCommand("s_bloqueado_ListaActivo");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable Lista(DateTime Fecha_inicio, DateTime Fecha_fin, string Num_contrato, string Usuario, int Activo)
            {
                //[id_bloqueado],[num_contrato],[estado],[estado_bloqueo],
                //[activo_fecha],[activo_usuario],[activo_observacion],
                //[inactivo_fecha],[inactivo_usuario],[inactivo_observacion]
                DbCommand cmd = db1.GetStoredProcCommand("s_bloqueado_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1.AddInParameter(cmd, "usuario", DbType.String, Usuario);
                db1.AddInParameter(cmd, "activo", DbType.Int32, Activo);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static bool Verificar(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_bloqueado_Verificar");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    if (((int)db1.ExecuteScalar(cmd)) > 0) { return true; }
                    else { return false; }
                }
                catch { return false; }
            }

            public static bool Bloquear(int Id_contrato, string Observacion, int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_bloqueado_Bloquear");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    db1.AddInParameter(cmd, "observacion", DbType.String, Observacion);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public static bool Desbloquear(int Id_bloqueado, string Observacion, int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_bloqueado_Desbloquear");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_bloqueado", DbType.Int32, Id_bloqueado);
                    db1.AddInParameter(cmd, "observacion", DbType.String, Observacion);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }


            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_bloqueado_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_bloqueado", DbType.Int32, _id_bloqueado);
                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                    db1.AddOutParameter(cmd, "activo_fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "activo_id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "activo_observacion", DbType.String, 200);

                    db1.AddOutParameter(cmd, "inactivo_fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "inactivo_id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "inactivo_observacion", DbType.String, 200);

                    db1.AddOutParameter(cmd, "num_contrato", DbType.String, 25);
                    
                    db1.ExecuteNonQuery(cmd);

                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _activo = (bool)db1.GetParameterValue(cmd, "activo");

                    _activo_fecha = (DateTime)db1.GetParameterValue(cmd, "activo_fecha");
                    _activo_id_usuario = (int)db1.GetParameterValue(cmd, "activo_id_usuario");
                    _activo_observacion = (string)db1.GetParameterValue(cmd, "activo_observacion");

                    _inactivo_fecha = (DateTime)db1.GetParameterValue(cmd, "inactivo_fecha");
                    _inactivo_id_usuario = (int)db1.GetParameterValue(cmd, "inactivo_id_usuario");
                    _inactivo_observacion = (string)db1.GetParameterValue(cmd, "inactivo_observacion");

                    _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                }
                catch { }
            }

            #endregion

        }
    }
}