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
/// Descripción breve de so_obraMaestro
/// </summary>
namespace terrasur
{
    namespace so
    {
        public class so_obraMaestro
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_urbanizacion = 0;
            private int _id_usuario = 0;
            private DateTime _fecha_registro = DateTime.Now;

            private string _urbanizacion_nombre = "";
            private string _localizacion_nombre = "";
            private string _usuario_nombre = "";
            private int _id_estadoobramaestro = 0;
            private int _id_estado = 0;
            private string _estado_codigo = "";
            private string _estado_nombre = "";
            private decimal _avance = 0;

            //Propiedades públicas
            public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha_registro { get { return _fecha_registro; } set { _fecha_registro = value; } }

            public string urbanizacion_nombre { get { return _urbanizacion_nombre; } }
            public string localizacion_nombre { get { return _localizacion_nombre; } }
            public string usuario_nombre { get { return _usuario_nombre; } }
            public int id_estadoobramaestro { get { return _id_estadoobramaestro; } }
            public int id_estado { get { return _id_estado; } }
            public string estado_codigo { get { return _estado_codigo; } }
            public string estado_nombre { get { return _estado_nombre; } }
            public decimal avance { get { return _avance; } }

            #endregion

            #region Constructores
            public so_obraMaestro(int Id_urbanizacion)
            {
                _id_urbanizacion = Id_urbanizacion;
                RecuperarDatos();
            }
            public so_obraMaestro(int Id_urbanizacion, int Id_usuario)
            {
                _id_urbanizacion = Id_urbanizacion;
                _id_usuario = Id_usuario;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_localizacion)
            {
                //[id_urbanizacion],[localizacion],[urbanizacion],[registro_usuario],[registro_fecha],[estado],[prioridad],[fecha_planificada],[avance]
                DbCommand cmd = db1.GetStoredProcCommand("so_obraMaestro_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static DataTable Reporte(DateTime Fecha, int Id_localizacion, int Id_prioridad, int Id_estado, DateTime Fecha_inicio, DateTime Fecha_fin)
            {
                //[id_urbanizacion],[localizacion],[urbanizacion],[estado],[prioriodad],[fecha_ventas],[fecha_planificada],[obras]
                //[e_alum],[e_post],[e_agua],[e_sani],[e_pluv],[e_empe],[e_acer],[e_aper]
                DbCommand cmd = db1.GetStoredProcCommand("so_obraMaestro_Reporte");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
                db1.AddInParameter(cmd, "id_prioridad", DbType.Int32, Id_prioridad);
                db1.AddInParameter(cmd, "id_estado", DbType.Int32, Id_estado);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static bool Verificar(int Id_urbanizacion)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraMaestro_Verificar");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                    if ((int)db1.ExecuteScalar(cmd) == 0) { return false; }
                    else { return true; }
                }
                catch { return false; }
            }
            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraMaestro_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);

                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha_registro", DbType.DateTime, 32);

                    db1.AddOutParameter(cmd, "urbanizacion_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "localizacion_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "id_estadoobramaestro", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "estado_codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "avance", DbType.Double, 32);

                    db1.ExecuteNonQuery(cmd);

                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha_registro = (DateTime)db1.GetParameterValue(cmd, "fecha_registro");

                    _urbanizacion_nombre = (string)db1.GetParameterValue(cmd, "urbanizacion_nombre");
                    _localizacion_nombre = (string)db1.GetParameterValue(cmd, "localizacion_nombre");
                    _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
                    _id_estadoobramaestro = (int)db1.GetParameterValue(cmd, "id_estadoobramaestro");
                    _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                    _estado_codigo = (string)db1.GetParameterValue(cmd, "estado_codigo");
                    _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
                    _avance = (decimal)(double)db1.GetParameterValue(cmd, "avance");
                }
                catch { }
            }

            public bool Insertar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraMaestro_Insertar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion
        }
    }
}