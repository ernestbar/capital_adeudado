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
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Xml;
using System.Text;

/// <summary>
/// Descripción breve de so_urbanizacion_prioridad
/// </summary>
namespace terrasur
{
    namespace so
    {
        public class so_urbanizacion_prioridad
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_urbanizacionprioridad = 0;
            private int _id_urbanizacion = 0;
            private int _id_prioridad = 0;
            private int _id_usuario = 0;
            private DateTime _fecha = DateTime.Now;
            private DateTime _fecha_planificada = DateTime.Now;
            private string _observacion = "";

            private string _prioridad_nombre = "";
            private int _prioridad_numero = 0;
            private string _usuario_nombre = "";

            //Propiedades públicas
            public int id_urbanizacionprioridad { get { return _id_urbanizacionprioridad; } set { _id_urbanizacionprioridad = value; } }
            public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
            public int id_prioridad { get { return _id_prioridad; } set { _id_prioridad = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public DateTime fecha_planificada { get { return _fecha_planificada; } set { _fecha_planificada = value; } }
            public string observacion { get { return _observacion; } set { _observacion = value; } }

            public string prioridad_nombre { get { return _prioridad_nombre; } }
            public int prioridad_numero { get { return _prioridad_numero; } }
            public string usuario_nombre { get { return _usuario_nombre; } }
            #endregion

            #region Constructores
            public so_urbanizacion_prioridad(int Id_urbanizacionprioridad, int Id_urbanizacion)
            {
                _id_urbanizacionprioridad = Id_urbanizacionprioridad;
                _id_urbanizacion = Id_urbanizacion;
                RecuperarDatos();
            }

            public so_urbanizacion_prioridad(int Id_urbanizacion, int Id_prioridad, int Id_usuario, DateTime Fecha_planificada, string Observacion)
            {
                _id_urbanizacion = Id_urbanizacion;
                _id_prioridad = Id_prioridad;
                _id_usuario = Id_usuario;
                _fecha_planificada = Fecha_planificada;
                _observacion = Observacion;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_urbanizacion)
            {
                //[id_urbanizacionprioridad],[id_prioridad],[id_usuario],[fecha],[fecha_planificada],[observacion], 
                //[prioridad_nombre],[prioridad_numero],[usuario_nombre]
                DbCommand cmd = db1.GetStoredProcCommand("so_urbanizacion_prioridad_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_urbanizacion_prioridad_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_urbanizacionprioridad0", DbType.Int32, _id_urbanizacionprioridad);
                    db1.AddInParameter(cmd, "id_urbanizacion0", DbType.Int32, _id_urbanizacion);

                    db1.AddOutParameter(cmd, "id_urbanizacionprioridad", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_prioridad", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fecha_planificada", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "observacion", DbType.String, 200);

                    db1.AddOutParameter(cmd, "prioridad_nombre", DbType.String, 30);
                    db1.AddOutParameter(cmd, "prioridad_numero", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_urbanizacionprioridad = (int)db1.GetParameterValue(cmd, "id_urbanizacionprioridad");
                    _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                    _id_prioridad = (int)db1.GetParameterValue(cmd, "id_prioridad");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _fecha_planificada = (DateTime)db1.GetParameterValue(cmd, "fecha_planificada");
                    _observacion = (string)db1.GetParameterValue(cmd, "observacion");

                    _prioridad_nombre = (string)db1.GetParameterValue(cmd, "prioridad_nombre");
                    _prioridad_numero = (int)db1.GetParameterValue(cmd, "prioridad_numero");
                    _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
                }
                catch { }
            }

            public bool Insertar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_urbanizacion_prioridad_Insertar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_prioridad", DbType.Int32, _id_prioridad);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "fecha_planificada", DbType.DateTime, _fecha_planificada);
                    db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
                    _id_urbanizacionprioridad = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion
        }
    }
}