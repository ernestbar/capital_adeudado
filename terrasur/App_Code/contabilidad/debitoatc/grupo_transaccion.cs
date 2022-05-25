using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de grupo_transaccion
/// </summary>
namespace terrasur
{
    public class grupo_transaccion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupotransaccion = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private int _numero = 0;
        private string _periodo_deuda_mes = "";
        private string _periodo_deuda_anio = "";
        private DateTime _fecha_debito = DateTime.Now;
        private bool _enviado = false;
        private DateTime _enviado_fecha = DateTime.Now;
        private int _enviado_id_usuario = 0;

        private int _num_transacciones = 0;
        private int _num_transacciones_efectivas = 0;
        private decimal _monto_transacciones_sus = 0;
        private decimal _monto_transacciones_efectivas_sus = 0;
        private decimal _monto_transacciones_bs = 0;
        private decimal _monto_transacciones_efectivas_bs = 0;
        private int _num_archivos = 0;
        private string _eleccion_usuario = "";
        private DateTime _eleccion_fecha = DateTime.Now;
        private string _enviado_usuario = "";
        private string _aceptados_usuario = "";
        private DateTime _aceptados_fecha = DateTime.Now;
        private string _denegados_usuario = "";
        private DateTime _denegados_fecha = DateTime.Now;

        //Propiedades públicas
        public int id_grupotransaccion { get { return _id_grupotransaccion; } set { _id_grupotransaccion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int numero { get { return _numero; } set { _numero = value; } }
        public string periodo_deuda_mes { get { return _periodo_deuda_mes; } set { _periodo_deuda_mes = value; } }
        public string periodo_deuda_anio { get { return _periodo_deuda_anio; } set { _periodo_deuda_anio = value; } }
        public DateTime fecha_debito { get { return _fecha_debito; } set { _fecha_debito = value; } }
        public bool enviado { get { return _enviado; } set { _enviado = value; } }
        public DateTime enviado_fecha { get { return _enviado_fecha; } set { _enviado_fecha = value; } }
        public int enviado_id_usuario { get { return _enviado_id_usuario; } set { _enviado_id_usuario = value; } }

        public int num_transacciones { get { return _num_transacciones; } set { _num_transacciones = value; } }
        public int num_transacciones_efectivas { get { return _num_transacciones_efectivas; } set { _num_transacciones_efectivas = value; } }

        public decimal monto_transacciones_sus { get { return _monto_transacciones_sus; } set { _monto_transacciones_sus = value; } }
        public decimal monto_transacciones_efectivas_sus { get { return _monto_transacciones_efectivas_sus; } set { _monto_transacciones_efectivas_sus = value; } }

        public decimal monto_transacciones_bs { get { return _monto_transacciones_bs; } set { _monto_transacciones_bs = value; } }
        public decimal monto_transacciones_efectivas_bs { get { return _monto_transacciones_efectivas_bs; } set { _monto_transacciones_efectivas_bs = value; } }

        public int num_archivos { get { return _num_archivos; } set { _num_archivos = value; } }
        public string eleccion_usuario { get { return _eleccion_usuario; } set { _eleccion_usuario = value; } }
        public DateTime eleccion_fecha { get { return _eleccion_fecha; } set { _eleccion_fecha = value; } }
        public string enviado_usuario { get { return _enviado_usuario; } set { _enviado_usuario = value; } }
        public string aceptados_usuario { get { return _aceptados_usuario; } set { _aceptados_usuario = value; } }
        public DateTime aceptados_fecha { get { return _aceptados_fecha; } set { _aceptados_fecha = value; } }
        public string denegados_usuario { get { return _denegados_usuario; } set { _denegados_usuario = value; } }
        public DateTime denegados_fecha { get { return _denegados_fecha; } set { _denegados_fecha = value; } }
        #endregion

        #region Constructores
        public grupo_transaccion(int Id_grupotransaccion)
        {
            _id_grupotransaccion = Id_grupotransaccion;
            RecuperarDatos();
        }
        public grupo_transaccion(int Numero, string Periodo_deuda_mes, string Periodo_deuda_anio, DateTime Fecha_debito)
        {
            _numero = Numero;
            _periodo_deuda_mes = Periodo_deuda_mes;
            _periodo_deuda_anio = Periodo_deuda_anio;
            _fecha_debito = Fecha_debito;
        }
        public grupo_transaccion(int Id_grupotransaccion, int Numero, string Periodo_deuda_mes, string Periodo_deuda_anio, DateTime Fecha_debito)
        {
            _id_grupotransaccion = Id_grupotransaccion;
            _numero = Numero;
            _periodo_deuda_mes = Periodo_deuda_mes;
            _periodo_deuda_anio = Periodo_deuda_anio;
            _fecha_debito = Fecha_debito;
        }

        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_grupotransaccion],[estado],[numero],[fecha_debito],[periodo_debito],[usuario],[num_debitos],
            //[num_debitos_efectivos],[monto_debitos],[monto_debitos_efectivos],[enviado],[num_archivos_respuesta]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaSimple()
        {
            //[id_grupotransaccion],[numero]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_ListaSimple");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int SiguienteNumero()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_SiguienteNumero");
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        public static bool RegistrarEnviado(int Id_grupotransaccion, int Id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_RegistrarEnviado");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, Id_grupotransaccion);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static DataTable ListaMesParaDebito(string Fecha_referencia)
        {
            DateTime Fecha = DateTime.Parse(Fecha_referencia);
            //[codigo],[nombre]
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("nombre", typeof(string));

            //for (int m = Fecha.Month; m <= 12; m++)
            for (int m = 1; m <= 12; m++)
            {
                DataRow fila = tabla.NewRow();
                if (m < 10) fila["codigo"] = "0" + m.ToString();
                else fila["codigo"] = m.ToString();
                switch (m)
                {
                    case 1: fila["nombre"] = "Enero"; break;
                    case 2: fila["nombre"] = "Febrero"; break;
                    case 3: fila["nombre"] = "Marzo"; break;
                    case 4: fila["nombre"] = "Abril"; break;
                    case 5: fila["nombre"] = "Mayo"; break;
                    case 6: fila["nombre"] = "Junio"; break;
                    case 7: fila["nombre"] = "Julio"; break;
                    case 8: fila["nombre"] = "Agosto"; break;
                    case 9: fila["nombre"] = "Septiembre"; break;
                    case 10: fila["nombre"] = "Octubre"; break;
                    case 11: fila["nombre"] = "Noviembre"; break;
                    case 12: fila["nombre"] = "Diciembre"; break;
                }
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static DataTable ListaAnioParaDebito(string Fecha_referencia)
        {
            DateTime Fecha = DateTime.Parse(Fecha_referencia);
            //[codigo],[nombre]
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("nombre", typeof(string));

            int anio = Fecha.Year;
            DataRow fila = tabla.NewRow();
            fila["codigo"] = anio - 2000;
            fila["nombre"] = anio;
            tabla.Rows.Add(fila);

            //if (Fecha.Month == 12)
            if (Fecha.Month >= 11)
            {
                DataRow fila2 = tabla.NewRow();
                fila2["codigo"] = (anio + 1) - 2000;
                fila2["nombre"] = (anio + 1);
                tabla.Rows.Add(fila2);
            }
            return tabla;
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "numero", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "periodo_deuda_mes", DbType.String, 2);
                db1.AddOutParameter(cmd, "periodo_deuda_anio", DbType.String, 2);
                db1.AddOutParameter(cmd, "fecha_debito", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "enviado", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "enviado_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "enviado_id_usuario", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "num_transacciones", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_transacciones_efectivas", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "monto_transacciones_sus", DbType.Double, 32);
                db1.AddOutParameter(cmd, "monto_transacciones_efectivas_sus", DbType.Double, 32);
                db1.AddOutParameter(cmd, "monto_transacciones_bs", DbType.Double, 32);
                db1.AddOutParameter(cmd, "monto_transacciones_efectivas_bs", DbType.Double, 32);
                db1.AddOutParameter(cmd, "num_archivos", DbType.Int32, 32);
                
                db1.AddOutParameter(cmd, "eleccion_usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "eleccion_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "enviado_usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "aceptados_usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "aceptados_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "denegados_usuario", DbType.String, 50);
                db1.AddOutParameter(cmd, "denegados_fecha", DbType.DateTime, 32);

                db1.ExecuteNonQuery(cmd);

                _id_grupotransaccion = (int)db1.GetParameterValue(cmd, "id_grupotransaccion");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _numero = (int)db1.GetParameterValue(cmd, "numero");
                _periodo_deuda_mes = (string)db1.GetParameterValue(cmd, "periodo_deuda_mes");
                _periodo_deuda_anio = (string)db1.GetParameterValue(cmd, "periodo_deuda_anio");
                _fecha_debito = (DateTime)db1.GetParameterValue(cmd, "fecha_debito");
                _enviado = (bool)db1.GetParameterValue(cmd, "enviado");
                _enviado_fecha = (DateTime)db1.GetParameterValue(cmd, "enviado_fecha");
                _enviado_id_usuario = (int)db1.GetParameterValue(cmd, "enviado_id_usuario");

                _num_transacciones = (int)db1.GetParameterValue(cmd, "num_transacciones");
                _num_transacciones_efectivas = (int)db1.GetParameterValue(cmd, "num_transacciones_efectivas");
                _monto_transacciones_sus = (decimal)(double)db1.GetParameterValue(cmd, "monto_transacciones_sus");
                _monto_transacciones_efectivas_sus = (decimal)(double)db1.GetParameterValue(cmd, "monto_transacciones_efectivas_sus");
                _monto_transacciones_bs = (decimal)(double)db1.GetParameterValue(cmd, "monto_transacciones_bs");
                _monto_transacciones_efectivas_bs = (decimal)(double)db1.GetParameterValue(cmd, "monto_transacciones_efectivas_bs");
                _num_archivos = (int)db1.GetParameterValue(cmd, "num_archivos");

                _eleccion_usuario = (string)db1.GetParameterValue(cmd, "eleccion_usuario");
                _eleccion_fecha = (DateTime)db1.GetParameterValue(cmd, "eleccion_fecha");
                _enviado_usuario = (string)db1.GetParameterValue(cmd, "enviado_usuario");
                _aceptados_usuario = (string)db1.GetParameterValue(cmd, "aceptados_usuario");
                _aceptados_fecha = (DateTime)db1.GetParameterValue(cmd, "aceptados_fecha");
                _denegados_usuario = (string)db1.GetParameterValue(cmd, "denegados_usuario");
                _denegados_fecha = (DateTime)db1.GetParameterValue(cmd, "denegados_fecha");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_Insertar");
                db1.AddInParameter(cmd, "numero", DbType.Int32, _numero);
                db1.AddInParameter(cmd, "periodo_deuda_mes", DbType.String, _periodo_deuda_mes);
                db1.AddInParameter(cmd, "periodo_deuda_anio", DbType.String, _periodo_deuda_anio);
                db1.AddInParameter(cmd, "fecha_debito", DbType.DateTime, _fecha_debito);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_grupotransaccion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_Actualizar");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
                db1.AddInParameter(cmd, "periodo_deuda_mes", DbType.String, _periodo_deuda_mes);
                db1.AddInParameter(cmd, "periodo_deuda_anio", DbType.String, _periodo_deuda_anio);
                db1.AddInParameter(cmd, "fecha_debito", DbType.DateTime, _fecha_debito);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (_num_archivos == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("grupo_transaccion_Eliminar");
                    db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
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