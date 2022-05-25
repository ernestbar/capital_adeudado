using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de tarjeta_credito
/// </summary>
namespace terrasur
{
    public class tarjeta_credito
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_tarjetacredito = 0;
        private int _id_tipotarjetacredito = 0;
        private int _id_banco = 0;
        private int _id_lugarcedula = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private string _titular = "";
        private string _ci = "";
        private string _numero = "";
        private string _vencimiento_mes = "";
        private string _vencimiento_anio = "";
        private bool _activo = false;

        private int _num_contratos_asignados = 0;
        private int _num_transacciones = 0;
        private string _lugar_cedula_codigo = "";
        private string _banco_codigo = "";
        private string _banco_nombre = "";
        private string _tipo_tarjeta_codigo = "";
        private string _tipo_tarjeta_nombre = "";

        private DateTime _registro_fecha = DateTime.Now;
        private string _registro_usuario = "";
        private DateTime _actualizacion_fecha = DateTime.Now;
        private string _actualizacion_usuario = "";

        //Propiedades públicas
        public int id_tarjetacredito { get { return _id_tarjetacredito; } set { _id_tarjetacredito = value; } }
        public int id_tipotarjetacredito { get { return _id_tipotarjetacredito; } set { _id_tipotarjetacredito = value; } }
        public int id_banco { get { return _id_banco; } set { _id_banco = value; } }
        public int id_lugarcedula { get { return _id_lugarcedula; } set { _id_lugarcedula = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string titular { get { return _titular; } set { _titular = value; } }
        public string ci { get { return _ci; } set { _ci = value; } }
        public string numero { get { return _numero; } set { _numero = value; } }
        public string vencimiento_mes { get { return _vencimiento_mes; } set { _vencimiento_mes = value; } }
        public string vencimiento_anio { get { return _vencimiento_anio; } set { _vencimiento_anio = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_contratos_asignados { get { return _num_contratos_asignados; } }
        public int num_transacciones { get { return _num_transacciones; } }
        public string lugar_cedula_codigo { get { return _lugar_cedula_codigo; } }
        public string banco_codigo { get { return _banco_codigo; } }
        public string banco_nombre { get { return _banco_nombre; } }
        public string tipo_tarjeta_codigo { get { return _tipo_tarjeta_codigo; } }
        public string tipo_tarjeta_nombre { get { return _tipo_tarjeta_nombre; } }

        public DateTime registro_fecha { get { return _registro_fecha; } }
        public string registro_usuario { get { return _registro_usuario; } }
        public DateTime actualizacion_fecha { get { return _actualizacion_fecha; } }
        public string actualizacion_usuario { get { return _actualizacion_usuario; } }

        #endregion

        #region Constructores
        public tarjeta_credito(int Id_tarjetacredito)
        {
            _id_tarjetacredito = Id_tarjetacredito;
            RecuperarDatos();
        }
        public tarjeta_credito(int Id_tipotarjetacredito, int Id_banco, int Id_lugarcedula,
            string Titular, string Ci, string Numero, string Vencimiento_mes,
            string Vencimiento_anio, bool Activo)
        {
            _id_tipotarjetacredito = Id_tipotarjetacredito;
            _id_banco = Id_banco;
            _id_lugarcedula = Id_lugarcedula;
            _titular = Titular;
            _ci = Ci;
            _numero = Numero;
            _vencimiento_mes = Vencimiento_mes;
            _vencimiento_anio = Vencimiento_anio;
            _activo = Activo;
        }
        public tarjeta_credito(int Id_tarjetacredito, int Id_tipotarjetacredito, int Id_banco, int Id_lugarcedula,
            string Titular, string Ci, string Numero, string Vencimiento_mes,
            string Vencimiento_anio, bool Activo)
        {
            _id_tarjetacredito = Id_tarjetacredito;
            _id_tipotarjetacredito = Id_tipotarjetacredito;
            _id_banco = Id_banco;
            _id_lugarcedula = Id_lugarcedula;
            _titular = Titular;
            _ci = Ci;
            _numero = Numero;
            _vencimiento_mes = Vencimiento_mes;
            _vencimiento_anio = Vencimiento_anio;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool VerificarNumero(bool Inserta, int Id_tarjetacredito, string Numero)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_VerificarNumero");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, Id_tarjetacredito);
                db1.AddInParameter(cmd, "numero", DbType.String, Numero);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static DataTable Lista(int Id_tipotarjetacredito, int Id_banco, string Num_tarjeta, string Titular, string Ci, string Num_contrato, int Tarjeta_activa )
        {
            //[id_tarjetacredito],[tipo_tarjeta],[codigo_banco],[num_tarjeta],[fecha_vencimiento],[titular],[ci],[activo],[num_contratos]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_Lista");
            db1.AddInParameter(cmd, "id_tipotarjetacredito", DbType.Int32, Id_tipotarjetacredito);
            db1.AddInParameter(cmd, "id_banco", DbType.Int32, Id_banco);
            db1.AddInParameter(cmd, "num_tarjeta", DbType.String, Num_tarjeta);
            db1.AddInParameter(cmd, "titular", DbType.String, Titular);
            db1.AddInParameter(cmd, "ci", DbType.String, Ci);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "tarjeta_activa", DbType.Int32, Tarjeta_activa);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_RecuperarDatos");
                db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, _id_tarjetacredito);
                db1.AddOutParameter(cmd, "id_tipotarjetacredito", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_banco", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_lugarcedula", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "titular", DbType.String, 100);
                db1.AddOutParameter(cmd, "ci", DbType.String, 20);
                db1.AddOutParameter(cmd, "numero", DbType.String, 30);
                db1.AddOutParameter(cmd, "vencimiento_mes", DbType.String, 2);
                db1.AddOutParameter(cmd, "vencimiento_anio", DbType.String, 2);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "num_contratos_asignados", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_transacciones", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "lugar_cedula_codigo", DbType.String, 10);
                db1.AddOutParameter(cmd, "banco_codigo", DbType.String, 10);
                db1.AddOutParameter(cmd, "banco_nombre", DbType.String, 50);
                db1.AddOutParameter(cmd, "tipo_tarjeta_codigo", DbType.String, 10);
                db1.AddOutParameter(cmd, "tipo_tarjeta_nombre", DbType.String, 20);
                db1.AddOutParameter(cmd, "registro_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "registro_usuario", DbType.String, 100);
                db1.AddOutParameter(cmd, "actualizacion_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "actualizacion_usuario", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);

                _id_tipotarjetacredito = (int)db1.GetParameterValue(cmd, "id_tipotarjetacredito");
                _id_banco = (int)db1.GetParameterValue(cmd, "id_banco");
                _id_lugarcedula = (int)db1.GetParameterValue(cmd, "id_lugarcedula");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");

                _titular = (string)db1.GetParameterValue(cmd, "titular");
                _ci = (string)db1.GetParameterValue(cmd, "ci");
                _numero = (string)db1.GetParameterValue(cmd, "numero");
                _vencimiento_mes = (string)db1.GetParameterValue(cmd, "vencimiento_mes");
                _vencimiento_anio = (string)db1.GetParameterValue(cmd, "vencimiento_anio");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");
                _num_contratos_asignados = (int)db1.GetParameterValue(cmd, "num_contratos_asignados");
                _num_transacciones = (int)db1.GetParameterValue(cmd, "num_transacciones");
                _lugar_cedula_codigo = (string)db1.GetParameterValue(cmd, "lugar_cedula_codigo");
                _banco_codigo = (string)db1.GetParameterValue(cmd, "banco_codigo");
                _banco_nombre = (string)db1.GetParameterValue(cmd, "banco_nombre");
                _tipo_tarjeta_codigo = (string)db1.GetParameterValue(cmd, "tipo_tarjeta_codigo");
                _tipo_tarjeta_nombre = (string)db1.GetParameterValue(cmd, "tipo_tarjeta_nombre");
                _registro_fecha = (DateTime)db1.GetParameterValue(cmd, "registro_fecha");
                _registro_usuario = (string)db1.GetParameterValue(cmd, "registro_usuario");
                _actualizacion_fecha = (DateTime)db1.GetParameterValue(cmd, "actualizacion_fecha");
                _actualizacion_usuario = (string)db1.GetParameterValue(cmd, "actualizacion_usuario");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarNumero(true, 0, _numero) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_Insertar");
                    db1.AddInParameter(cmd, "id_tipotarjetacredito", DbType.Int32, _id_tipotarjetacredito);
                    db1.AddInParameter(cmd, "id_banco", DbType.Int32, _id_banco);
                    db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, _id_lugarcedula);
                    db1.AddInParameter(cmd, "titular", DbType.String, _titular);
                    db1.AddInParameter(cmd, "ci", DbType.String, _ci);
                    db1.AddInParameter(cmd, "numero", DbType.String, _numero);
                    db1.AddInParameter(cmd, "vencimiento_mes", DbType.String, _vencimiento_mes);
                    db1.AddInParameter(cmd, "vencimiento_anio", DbType.String, _vencimiento_anio);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    _id_tarjetacredito = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarNumero(false, _id_tarjetacredito, _numero) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_Actualizar");
                    db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, _id_tarjetacredito);
                    db1.AddInParameter(cmd, "id_tipotarjetacredito", DbType.Int32, _id_tipotarjetacredito);
                    db1.AddInParameter(cmd, "id_banco", DbType.Int32, _id_banco);
                    db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, _id_lugarcedula);
                    db1.AddInParameter(cmd, "titular", DbType.String, _titular);
                    db1.AddInParameter(cmd, "ci", DbType.String, _ci);
                    db1.AddInParameter(cmd, "numero", DbType.String, _numero);
                    db1.AddInParameter(cmd, "vencimiento_mes", DbType.String, _vencimiento_mes);
                    db1.AddInParameter(cmd, "vencimiento_anio", DbType.String, _vencimiento_anio);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (_num_contratos_asignados == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_Eliminar");
                    db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, _id_tarjetacredito);
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