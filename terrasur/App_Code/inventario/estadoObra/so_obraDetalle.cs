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
/// Descripción breve de so_obraDetalle
/// </summary>
namespace terrasur
{
    namespace so
    {
        public class so_obraDetalle
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_urbanizacion = 0;
            private int _id_tipoobra = 0;
            private int _id_usuario = 0;
            private DateTime _fecha_registro = DateTime.Now;
            private DateTime _fecha_planificada = DateTime.Now;

            private string _usuario_nombre = "";
            private int _id_estadoobradetalle = 0;
            private int _id_estado = 0;
            private string _estado_codigo = "";
            private string _estado_nombre = "";
            private decimal _avance = 0;
            private string _tipoObra_codigo = "";
            private string _tipoObra_nombre = "";

            //Propiedades públicas
            public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
            public int id_tipoobra { get { return _id_tipoobra; } set { _id_tipoobra = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha_registro { get { return _fecha_registro; } set { _fecha_registro = value; } }
            public DateTime fecha_planificada { get { return _fecha_planificada; } set { _fecha_planificada = value; } }

            public string usuario_nombre { get { return _usuario_nombre; } }
            public int id_estadoobradetalle { get { return _id_estadoobradetalle; } }
            public int id_estado { get { return _id_estado; } }
            public string estado_codigo { get { return _estado_codigo; } }
            public string estado_nombre { get { return _estado_nombre; } }
            public decimal avance { get { return _avance; } }
            public string tipoObra_codigo { get { return _tipoObra_codigo; } }
            public string tipoObra_nombre { get { return _tipoObra_nombre; } }
            #endregion

            #region Constructores
            public so_obraDetalle(int Id_urbanizacion, int Id_tipoobra)
            {
                _id_urbanizacion = Id_urbanizacion;
                _id_tipoobra = Id_tipoobra;
                RecuperarDatos();
            }
            public so_obraDetalle(int Id_urbanizacion, int Id_tipoobra, int Id_usuario, DateTime Fecha_planificada)
            {
                _id_urbanizacion = Id_urbanizacion;
                _id_tipoobra = Id_tipoobra;
                _id_usuario = Id_usuario;
                _fecha_planificada = Fecha_planificada;
            }

            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_urbanizacion)
            {
                //[id_tipoobra],[tipoObra_nombre],[tipoObra_fecha],[tipoObra_usuario]
                //[tipoObra_fechaPlanif],[tipoObra_diasPlanif]
                //[estado_nombre],[estado_avance],[estado_observacion]
                DbCommand cmd = db1.GetStoredProcCommand("so_obraDetalle_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaTiposPendiente(int Id_urbanizacion)
            {
                //[id_tipoobra],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("so_obraDetalle_ListaTiposPendiente");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static bool Verificar(int Id_urbanizacion, int Id_tipoobra)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraDetalle_Verificar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, Id_tipoobra);
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
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraDetalle_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, _id_tipoobra);

                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha_registro", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fecha_planificada", DbType.DateTime, 32);

                    db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "id_estadoobradetalle", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "estado_codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "avance", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "tipoObra_codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "tipoObra_nombre", DbType.String, 50);
                    
                    db1.ExecuteNonQuery(cmd);

                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha_registro = (DateTime)db1.GetParameterValue(cmd, "fecha_registro");
                    _fecha_planificada = (DateTime)db1.GetParameterValue(cmd, "fecha_planificada");

                    _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
                    _id_estadoobradetalle = (int)db1.GetParameterValue(cmd, "id_estadoobradetalle");
                    _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                    _estado_codigo = (string)db1.GetParameterValue(cmd, "estado_codigo");
                    _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
                    _avance = (decimal)(double)db1.GetParameterValue(cmd, "avance");
                    _tipoObra_codigo = (string)db1.GetParameterValue(cmd, "tipoObra_codigo");
                    _tipoObra_nombre = (string)db1.GetParameterValue(cmd, "tipoObra_nombre");
                }
                catch { }
            }

            public bool Insertar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraDetalle_Insertar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, _id_tipoobra);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "fecha_planificada", DbType.DateTime, _fecha_planificada);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Actualizar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_obraDetalle_Actualizar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, _id_tipoobra);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "fecha_planificada", DbType.DateTime, _fecha_planificada);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion

        }
    }
}