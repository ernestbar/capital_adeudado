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
/// Descripción breve de so_estadoObra_detalle
/// </summary>
namespace terrasur
{
    namespace so
    {
        public class so_estadoObra_detalle
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_estadoobradetalle = 0;
            private int _id_estado = 0;
            private int _id_urbanizacion = 0;
            private int _id_tipoobra = 0;
            private int _id_usuario = 0;
            private DateTime _fecha = DateTime.Now;
            private decimal _avance = 0;

            private string _usuario_nombre = "";
            private string _observacion = "";
            private string _observacion_usuario = "";
            private string _estado_codigo = "";
            private string _estado_nombre = "";

            //Propiedades públicas
            public int id_estadoobradetalle { get { return _id_estadoobradetalle; } set { _id_estadoobradetalle = value; } }
            public int id_estado { get { return _id_estado; } set { _id_estado = value; } }
            public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
            public int id_tipoobra { get { return _id_tipoobra; } set { _id_tipoobra = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal avance { get { return _avance; } set { _avance = value; } }

            public string usuario_nombre { get { return _usuario_nombre; } }
            public string observacion { get { return _observacion; } }
            public string observacion_usuario { get { return _observacion_usuario; } }
            public string estado_codigo { get { return _estado_codigo; } }
            public string estado_nombre { get { return _estado_nombre; } }
            #endregion

            #region Constructores
            public so_estadoObra_detalle(int Id_estadoobradetalle, int Id_urbanizacion, int Id_tipoobra)
            {
                _id_estadoobradetalle = Id_estadoobradetalle;
                _id_urbanizacion = Id_urbanizacion;
                _id_tipoobra = Id_tipoobra;
                RecuperarDatos();
            }

            public so_estadoObra_detalle(int Id_estado, int Id_urbanizacion, int Id_tipoobra, int Id_usuario, decimal Avance)
            {
                _id_estado = Id_estado;
                _id_urbanizacion = Id_urbanizacion;
                _id_tipoobra = Id_tipoobra;
                _id_usuario = Id_usuario;
                _avance = Avance;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static int IdEstadoObraDetalle_actual(int Id_urbanizacion, int Id_tipoobra)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_estadoObra_detalle_IdEstadoObraDetalle_actual");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, Id_tipoobra);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }


            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_estadoObra_detalle_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_estadoobradetalle0", DbType.Int32, _id_estadoobradetalle);
                    db1.AddInParameter(cmd, "id_urbanizacion0", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra0", DbType.Int32, _id_tipoobra);

                    db1.AddOutParameter(cmd, "id_estadoobradetalle", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_tipoobra", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "avance", DbType.Double, 32);

                    db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "observacion", DbType.String, 500);
                    db1.AddOutParameter(cmd, "observacion_usuario", DbType.String, 50);
                    db1.AddOutParameter(cmd, "estado_codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_estadoobradetalle = (int)db1.GetParameterValue(cmd, "id_estadoobradetalle");
                    _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                    _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                    _id_tipoobra = (int)db1.GetParameterValue(cmd, "id_tipoobra");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _avance = (decimal)(double)db1.GetParameterValue(cmd, "avance");

                    _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
                    _observacion = (string)db1.GetParameterValue(cmd, "observacion");
                    _observacion_usuario = (string)db1.GetParameterValue(cmd, "observacion_usuario");
                    _estado_codigo = (string)db1.GetParameterValue(cmd, "estado_codigo");
                    _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
                }
                catch { }
            }

            public bool Insertar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_estadoObra_detalle_Insertar");
                    db1.AddInParameter(cmd, "id_estado", DbType.Int32, _id_estado);
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, _id_tipoobra);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "avance", DbType.Decimal, _avance);
                    _id_estadoobradetalle = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }


            #endregion
        }
    }
}
