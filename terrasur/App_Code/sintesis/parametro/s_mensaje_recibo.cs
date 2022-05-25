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
/// Descripción breve de s_mensaje_recibo
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_mensaje_recibo
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_mensaje = 0;
            private int _id_usuario = 0;
            private DateTime _fecha_inicio = DateTime.Now;
            private DateTime _fecha_fin = DateTime.Now;
            private string _mensaje = "";

            private string _nombre_usuario = "";
            private string _periodo = "";

            //Propiedades públicas
            public int id_mensaje { get { return _id_mensaje; } set { _id_mensaje = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha_inicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
            public DateTime fecha_fin { get { return _fecha_fin; } set { _fecha_fin = value; } }
            public string mensaje { get { return _mensaje; } set { _mensaje = value; } }

            public string nombre_usuario { get { return _nombre_usuario; } }
            public string periodo { get { return _periodo; } }
            #endregion

            #region Constructores
            public s_mensaje_recibo(int Id_mensaje)
            {
                _id_mensaje = Id_mensaje;
                RecuperarDatos();
            }
            public s_mensaje_recibo(DateTime Fecha_inicio, DateTime Fecha_fin, string Mensaje)
            {
                _fecha_inicio = Fecha_inicio;
                _fecha_fin = Fecha_fin;
                _mensaje = Mensaje;
            }
            public s_mensaje_recibo(int Id_mensaje, DateTime Fecha_inicio, DateTime Fecha_fin, string Mensaje)
            {
                _id_mensaje = Id_mensaje;
                _fecha_inicio = Fecha_inicio;
                _fecha_fin = Fecha_fin;
                _mensaje = Mensaje;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista_anteriores()
            {
                //[id_mensaje],[usuario],[periodo],[mensaje]
                DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_Lista_anteriores");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static int IdActual()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_IdActual");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static bool Verificar(bool Insertar, int Id_mensaje, DateTime Fecha_inicio, DateTime Fecha_fin)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_Verificar");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_mensaje", DbType.Int32, Id_mensaje);
                    db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                    db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                    if (((int)db1.ExecuteScalar(cmd)) == 0) { return false; }
                    else { return true; }
                }
                catch { return true; }
            }
            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_mensaje", DbType.Int32, _id_mensaje);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha_inicio", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fecha_fin", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "mensaje", DbType.String, 400);

                    db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                    db1.AddOutParameter(cmd, "periodo", DbType.String, 25);

                    db1.ExecuteNonQuery(cmd);

                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha_inicio = (DateTime)db1.GetParameterValue(cmd, "fecha_inicio");
                    _fecha_fin = (DateTime)db1.GetParameterValue(cmd, "fecha_fin");
                    _mensaje = db1.GetParameterValue(cmd, "mensaje").ToString();

                    _nombre_usuario = db1.GetParameterValue(cmd, "nombre_usuario").ToString();
                    _periodo = db1.GetParameterValue(cmd, "periodo").ToString();
                }
                catch { }
            }

            public bool Insertar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, _fecha_inicio);
                    db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, _fecha_fin);
                    db1.AddInParameter(cmd, "mensaje", DbType.String, _mensaje);
                    _id_mensaje = (int)db1.ExecuteScalar(cmd);
                    if (_id_mensaje > 0) { return true; } else { return false; }
                }
                catch { return false; }
            }

            public bool Actualizar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_Actualizar");
                    db1.AddInParameter(cmd, "id_mensaje", DbType.Int32, _id_mensaje);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, _fecha_inicio);
                    db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, _fecha_fin);
                    db1.AddInParameter(cmd, "mensaje", DbType.String, _mensaje);
                    int correcto = (int)db1.ExecuteScalar(cmd);
                    if (correcto > 0) { return true; } else { return false; }
                }
                catch { return false; }
            }

            public bool Eliminar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_mensaje_recibo_Eliminar");
                    db1.AddInParameter(cmd, "id_mensaje", DbType.Int32, _id_mensaje);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion
        }
    }
}