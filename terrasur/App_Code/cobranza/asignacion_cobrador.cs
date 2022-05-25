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

/// <summary>
/// Summary description for asignacion_cobrador
/// </summary>
/// 
namespace terrasur
{ 
    public class asignacion_cobrador
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_asignacioncobrador = 0;
        private int _id_contrato = 0;
        private int _id_usuario_cobrador = 0;
        private int _id_usuario = 0;
        private DateTime _fecha;
        private bool _activo;

        //Propiedades públicas
        public int id_asignacioncobrador { get { return _id_asignacioncobrador; } set { _id_asignacioncobrador = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario_cobrador { get { return _id_usuario_cobrador; } set { _id_usuario_cobrador = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        #endregion

        #region Constructores
        public asignacion_cobrador()
        {
        }
        public asignacion_cobrador(int Id_contrato)
        {
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }
        public asignacion_cobrador(int Id_contrato, int Id_usuario_cobrador)
        {
            _id_contrato = Id_contrato;
            _id_usuario_cobrador = Id_usuario_cobrador;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorContrato(int Id_contrato)
        {
            //[id_asignacioncobrador],[id_contrato],[id_usuario_cobrador],[id_usuario],[fecha],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("asignacion_cobrador_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorCobrador(int Id_usuario_cobrador)
        {
            //[id_asignacioncobrador],[id_contrato],[id_usuario_cobrador],[id_usuario],[fecha],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("asignacion_cobrador_ListaPorCobrador");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario_cobrador", DbType.Int32, Id_usuario_cobrador);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaPorActivo(int Id_contrato, bool Activo)
        {
            //[id_asignacioncobrador],[id_contrato],[id_usuario_cobrador],[id_usuario],[fecha],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("asignacion_cobrador_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            db1.AddInParameter(cmd, "activo", DbType.Boolean, Activo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion
        
        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("asignacion_cobrador_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddOutParameter(cmd, "id_asignacioncobrador", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario_cobrador", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.ExecuteNonQuery(cmd);
                _id_asignacioncobrador = (int)db1.GetParameterValue(cmd, "id_asignacioncobrador");
                _id_usuario_cobrador = (int)db1.GetParameterValue(cmd, "id_usuario_cobrador");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
            }
            catch { }
        }
        public bool Asignar(int context_id_usuario)
        {
            DbCommand cmd = db1.GetStoredProcCommand("asignacion_cobrador_Asignar");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
            db1.AddInParameter(cmd, "id_usuario_cobrador", DbType.Int32, _id_usuario_cobrador);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
            _id_asignacioncobrador = (int)db1.ExecuteScalar(cmd);
            return true;

        }
        public bool Eliminar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("asignacion_cobrador_Eliminar");
                db1.AddInParameter(cmd, "id_asignacioncobrador", DbType.Int32, _id_asignacioncobrador);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion



    }
}