using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;

/// <summary>
/// Descripción breve de tarjeta_credito_contrato
/// </summary>
namespace terrasur
{
    public class tarjeta_credito_contrato
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_tarjetacreditocontrato = 0;
        private int _id_tarjetacredito = 0;
        private int _id_contrato = 0;
        private int _id_periodicidad = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private DateTime _fecha_debito = DateTime.Now;
        private decimal _monto_bs = 0;
        private decimal _monto_sus = 0;
        private bool _activo = false;

        private int _num_transacciones = 0;
        private string _num_contrato = "";

        //Propiedades públicas
        public int id_tarjetacreditocontrato { get { return _id_tarjetacreditocontrato; } set { _id_tarjetacreditocontrato = value; } }
        public int id_tarjetacredito { get { return _id_tarjetacredito; } set { _id_tarjetacredito = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_periodicidad { get { return _id_periodicidad; } set { _id_periodicidad = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public DateTime fecha_debito { get { return _fecha_debito; } set { _fecha_debito = value; } }
        public decimal monto_bs { get { return _monto_bs; } set { _monto_bs = value; } }
        public decimal monto_sus { get { return _monto_sus; } set { _monto_sus = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_transacciones { get { return _num_transacciones; } }
        public string num_contrato { get { return _num_contrato; } }
        #endregion

        #region Constructores
        public tarjeta_credito_contrato(int Id_tarjetacreditocontrato)
        {
            _id_tarjetacreditocontrato = Id_tarjetacreditocontrato;
            RecuperarDatos();
        }
        public tarjeta_credito_contrato(int Id_tarjetacredito, int Id_contrato, int Id_periodicidad, DateTime Fecha_debito, decimal Monto_bs, decimal Monto_sus, bool Activo)
        {
            _id_tarjetacredito = Id_tarjetacredito;
            _id_contrato = Id_contrato;
            _id_periodicidad = Id_periodicidad;
            _fecha_debito = Fecha_debito;
            _monto_bs = Monto_bs;
            _monto_sus = Monto_sus;
            _activo = Activo;
        }
        public tarjeta_credito_contrato(int Id_tarjetacreditocontrato, int Id_tarjetacredito, int Id_contrato, int Id_periodicidad, DateTime Fecha_debito, decimal Monto_bs, decimal Monto_sus, bool Activo)
        {
            _id_tarjetacreditocontrato = Id_tarjetacreditocontrato;
            _id_tarjetacredito = Id_tarjetacredito;
            _id_contrato = Id_contrato;
            _id_periodicidad = Id_periodicidad;
            _fecha_debito = Fecha_debito;
            _monto_bs = Monto_bs;
            _monto_sus = Monto_sus;
            _activo = Activo;
        }

        #endregion

        #region Métodos que NO requieren constructor
        public static bool VerificarContrato(bool Inserta, int Id_tarjetacreditocontrato, int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_VerificarContrato");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, Id_tarjetacreditocontrato);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static DataTable ListaContratosSimple(int Id_tarjetacredito)
        {
            //[numero]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_ListaContratosSimple");
            db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, Id_tarjetacredito);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static string ListaContratosSimple_string(int Id_tarjetacredito)
        {
            StringBuilder str = new StringBuilder();
            DataTable tabla = ListaContratosSimple(Id_tarjetacredito);
            foreach (DataRow fila in tabla.Rows) str.Append(fila["numero"].ToString() + ", ");
            return str.ToString().Trim().TrimEnd(',');
        }

        public static DataTable ListaContratos(int Id_tarjetacredito)
        {
            //[id_tarjetacreditocontrato],[id_contrato],[num_contrato],[periodicidad_codigo],[periodicidad_nombre],
            //[fecha_debito],[monto_bs],[monto_sus],[num_debitos],[num_debitos_efectivos],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_ListaContratos");
            db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, Id_tarjetacredito);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_RecuperarDatos");
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, _id_tarjetacreditocontrato);

                db1.AddOutParameter(cmd, "id_tarjetacredito", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_periodicidad", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "fecha_debito", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "monto_bs", DbType.Double, 20);
                db1.AddOutParameter(cmd, "monto_sus", DbType.Double, 20);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 5);

                db1.AddOutParameter(cmd, "num_transacciones", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 32);

                db1.ExecuteNonQuery(cmd);

                _id_tarjetacredito = (int)db1.GetParameterValue(cmd, "id_tarjetacredito");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_periodicidad = (int)db1.GetParameterValue(cmd, "id_periodicidad");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _fecha_debito = (DateTime)db1.GetParameterValue(cmd, "fecha_debito");
                _monto_bs = (decimal)(double)db1.GetParameterValue(cmd, "monto_bs");
                _monto_sus = (decimal)(double)db1.GetParameterValue(cmd, "monto_sus");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");

                _num_transacciones = (int)db1.GetParameterValue(cmd, "num_transacciones");
                _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_Insertar");
                db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, _id_tarjetacredito);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_periodicidad", DbType.Int32, _id_periodicidad);
                db1.AddInParameter(cmd, "fecha_debito", DbType.DateTime, _fecha_debito);
                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, _monto_bs);
                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_tarjetacreditocontrato = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_Actualizar");
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, _id_tarjetacreditocontrato);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_periodicidad", DbType.Int32, _id_periodicidad);
                db1.AddInParameter(cmd, "fecha_debito", DbType.DateTime, _fecha_debito);
                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, _monto_bs);
                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (_num_transacciones == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_contrato_Eliminar");
                    db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, _id_tarjetacreditocontrato);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        #endregion
    }
}