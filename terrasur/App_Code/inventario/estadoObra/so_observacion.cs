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
/// Descripción breve de so_observacion
/// </summary>
namespace terrasur
{
    namespace so
    {
        public class so_observacion
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_observacion = 0;
            private int _id_estadoobramaestro = 0;
            private int _id_estadoobradetalle = 0;
            private int _id_usuario = 0;
            private DateTime _fecha = DateTime.Now;
            private string _texto = "";

            private string _nombre_usuario = "";

            //Propiedades públicas
            public int id_observacion { get { return _id_observacion; } set { _id_observacion = value; } }
            public int id_estadoobramaestro { get { return _id_estadoobramaestro; } set { _id_estadoobramaestro = value; } }
            public int id_estadoobradetalle { get { return _id_estadoobradetalle; } set { _id_estadoobradetalle = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public string texto { get { return _texto; } set { _texto = value; } }

            public string nombre_usuario { get { return _nombre_usuario; } }
            #endregion

            #region Constructores
            public so_observacion(int Id_estadoobramaestro, int Id_estadoobradetalle)
            {
                _id_estadoobramaestro = Id_estadoobramaestro;
                _id_estadoobradetalle = Id_estadoobradetalle;
                RecuperarDatos();
            }
            
            public so_observacion(int Id_estadoobramaestro, int Id_estadoobradetalle, int Id_usuario, string Texto)
            {
                _id_estadoobramaestro = Id_estadoobramaestro;
                _id_estadoobradetalle = Id_estadoobradetalle;
                _id_usuario = Id_usuario;
                _texto = Texto;
            }

            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable ListaPorUrbanizacion(int Id_urbanizacion)
            {
                //[id_observacion],[usuario],[estado],[fecha],[texto]
                DbCommand cmd = db1.GetStoredProcCommand("so_observacion_ListaPorUrbanizacion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaPorObra(int Id_urbanizacion, int Id_tipoobra)
            {
                //[id_observacion],[usuario],[estado],[fecha],[texto]
                DbCommand cmd = db1.GetStoredProcCommand("so_observacion_ListaPorObra");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "id_tipoobra", DbType.Int32, Id_tipoobra);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_observacion_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_estadoobramaestro", DbType.Int32, _id_estadoobramaestro);
                    db1.AddInParameter(cmd, "id_estadoobradetalle", DbType.Int32, _id_estadoobradetalle);

                    db1.AddOutParameter(cmd, "id_observacion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "texto", DbType.String, 500);

                    db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 25);

                    db1.ExecuteNonQuery(cmd);

                    _id_observacion = (int)db1.GetParameterValue(cmd, "id_observacion");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _texto = (string)db1.GetParameterValue(cmd, "texto");

                    _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                }
                catch { }
            }

            public bool Insertar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("so_observacion_Insertar");
                    db1.AddInParameter(cmd, "id_estadoobramaestro", DbType.Int32, _id_estadoobramaestro);
                    db1.AddInParameter(cmd, "id_estadoobradetalle", DbType.Int32, _id_estadoobradetalle);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "texto", DbType.String, _texto);
                    _id_observacion = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion


        }
    }
}
