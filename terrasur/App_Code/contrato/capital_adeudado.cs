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
/// Summary description for capital_adeudado
/// </summary>
namespace terrasur
{
    public class capital_adeudado
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_capitaladeudado = 0;
        private int _id_parametrocapitaldeudor = 0;
        private int _id_contrato = 0;
        private decimal _monto = 0;
        private DateTime _fecha = DateTime.Now;
        private int _id_usuario = 0;
        private bool _activo = true;
        private DateTime _fecha_audit = DateTime.Now;

        //Propiedades públicas
        public int id_capitaladeudado { get { return _id_capitaladeudado; } set { _id_capitaladeudado = value; } }
        public int id_parametrocapitaldeudor { get { return _id_parametrocapitaldeudor; } set { _id_parametrocapitaldeudor = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public decimal monto { get { return _monto; } set { _monto = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public DateTime fecha_audit { get { return _fecha_audit; } set { _fecha_audit = value; } }

        #endregion

        #region Constructores
        public capital_adeudado(int Id_capitaladeudado)
        {
            _id_capitaladeudado = Id_capitaladeudado;
            RecuperarDatos();
        }

        public capital_adeudado(int Id_parametrocapitaldeudor, int Id_contrato, decimal Monto, DateTime Fecha, int Id_usuario, bool Activo, DateTime Fecha_audit)
        {
            _id_parametrocapitaldeudor = Id_parametrocapitaldeudor;
            _id_contrato = Id_contrato;
            _monto = Monto;
            _fecha = Fecha;
            _id_usuario = Id_usuario;
            _activo = Activo;
            _fecha_audit = Fecha_audit;
        }

        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_RecuperarDatos");
                db1.AddInParameter(cmd, "id_capitaladeudado", DbType.Int32, _id_capitaladeudado);
                db1.AddOutParameter(cmd, "id_parametrocapitaldeudor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto", DbType.Double, 14);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "fecha_audit", DbType.DateTime, 200);
                db1.ExecuteNonQuery(cmd);

                _id_parametrocapitaldeudor = (int)db1.GetParameterValue(cmd, "id_parametrocapitaldeudor");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _monto = (decimal)db1.GetParameterValue(cmd, "monto");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _fecha_audit = (DateTime)db1.GetParameterValue(cmd, "fecha_audit");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_Insertar");
                db1.AddInParameter(cmd, "id_parametrocapitaldeudor", DbType.Int32, _id_parametrocapitaldeudor);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "fecha_audit", DbType.DateTime, _fecha_audit);

                _id_capitaladeudado = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }


        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("capital_adeudado_Actualizar");
                db1.AddInParameter(cmd, "id_capitaladeudado", DbType.Int32, _id_capitaladeudado);
                db1.AddInParameter(cmd, "id_parametrocapitaldeudor", DbType.Int32, _id_parametrocapitaldeudor);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "fecha_audit", DbType.DateTime, _fecha_audit);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}