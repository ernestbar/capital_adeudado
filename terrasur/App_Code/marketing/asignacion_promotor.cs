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
/// Summary description for asignacion_promotor
/// </summary>
namespace terrasur
{
    public class asignacion_promotor
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupopromotor = 0;
        private int _id_contrato = 0;
        private int _id_usuario = 0;
        private decimal _porcentaje = 0;
        private decimal _comision_total = 0;
        private DateTime _fecha = DateTime.Now;
        private bool _activo = false;

        private int _id_promotor = 0;
        private int _num_comision = 0;
        private decimal _monto_comision = 0;
        private int _num_asignacion_inactiva = 0;

        //Propiedades públicas
        public int id_grupopromotor { get { return _id_grupopromotor; } set { _id_grupopromotor = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public decimal porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public decimal comision_total { get { return _comision_total; } set { _comision_total = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int id_promotor { get { return _id_promotor; } }
        public int num_comision { get { return _num_comision; } }
        public decimal monto_comision { get { return _monto_comision; } }
        public int num_asignacion_inactiva { get { return _num_asignacion_inactiva; } }
        #endregion

        #region Constructores
        public asignacion_promotor(int Id_contrato)
        {
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }
        public asignacion_promotor(int Id_contrato, int Id_grupopromotor)
        {
            _id_contrato = Id_contrato;
            _id_grupopromotor = Id_grupopromotor;
        }
        //Este constructor se utiliza para modificar el procentaje de la comisión
        public asignacion_promotor(int Id_contrato, decimal Porcentaje)
        {
            _id_contrato = Id_contrato;
            _porcentaje = Porcentaje;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaComisiones(int Id_contrato)
        {//[numero],[fecha],[monto_pago],[monto]
            DbCommand cmd = db1.GetStoredProcCommand("asignacion_promotor_ListaComisiones");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool PermitirModificar(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("asignacion_promotor_PermitirModificar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) return true;
                else return false;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("asignacion_promotor_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddOutParameter(cmd, "id_grupopromotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "porcentaje", DbType.Double, 12);
                db1.AddOutParameter(cmd, "comision_total", DbType.Double, 12);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "id_promotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_comision", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto_comision", DbType.Double, 12);
                db1.AddOutParameter(cmd, "num_asignacion_inactiva", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_grupopromotor = (int)db1.GetParameterValue(cmd, "id_grupopromotor");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _porcentaje = (decimal)(double)db1.GetParameterValue(cmd, "porcentaje");
                _comision_total = (decimal)(double)db1.GetParameterValue(cmd, "comision_total");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");

                _id_promotor = (int)db1.GetParameterValue(cmd, "id_promotor");
                _num_comision = (int)db1.GetParameterValue(cmd, "num_comision");
                _monto_comision = (decimal)(double)db1.GetParameterValue(cmd, "monto_comision");
                _num_asignacion_inactiva = (int)db1.GetParameterValue(cmd, "num_asignacion_inactiva");
            }
            catch { }
        }

        public bool Asignar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("asignacion_promotor_Asignar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, _id_grupopromotor);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool ModificarPorcentaje(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("asignacion_promotor_ModificarPorcentaje");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "nuevo_porcentaje", DbType.Decimal, _porcentaje);
                db1.AddInParameter(cmd, "nuevo_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion
    }
}