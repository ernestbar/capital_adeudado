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
using System.Collections.Generic;

/// <summary>
/// Summary description for cliente
/// </summary>
namespace terrasur
{
    public class cliente
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_cliente = 0;
        private int _id_lugarcedula = 0;
        private int _id_lugarcobro = 0;
        private int _id_usuario = 0;
        private string _ci = "";
        private string _nit = "";
        private string _nombres = "";
        private string _paterno = "";
        private string _materno = "";
        private DateTime _fecha_nacimiento;
        private string _celular = "";
        private string _fax = "";
        private string _email = "";
        private string _casilla = "";
        private string _domicilio_direccion = "";
        private string _domicilio_fono = "";
        private int _domicilio_id_zona = 0;
        private string _oficina_direccion = "";
        private string _oficina_fono = "";
        private int _oficina_id_zona = 0;
        private bool _transitorio = false;

        private string _codigo_lugarcedula = "";
        private string _nombre_lugarcobro = "";
        private string _nombre_zona_domicilio = "";
        private string _nombre_zona_oficina = "";
        private int _num_contratos = 0;
        private int _num_servicios = 0;
        private int _num_audit = 0;

        //Propiedades públicas
        public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
        public int id_lugarcedula { get { return _id_lugarcedula; } set { _id_lugarcedula = value; } }
        public int id_lugarcobro { get { return _id_lugarcobro; } set { _id_lugarcobro = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string ci { get { return _ci; } set { _ci = value; } }
        public string nit { get { return _nit; } set { _nit = value; } }
        public string nombres { get { return _nombres; } set { _nombres = value; } }
        public string paterno { get { return _paterno; } set { _paterno = value; } }
        public string materno { get { return _materno; } set { _materno = value; } }
        public DateTime fecha_nacimiento { get { return _fecha_nacimiento; } set { _fecha_nacimiento = value; } }
        public string celular { get { return _celular; } set { _celular = value; } }
        public string fax { get { return _fax; } set { _fax = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public string casilla { get { return _casilla; } set { _casilla = value; } }
        public string domicilio_direccion { get { return _domicilio_direccion; } set { _domicilio_direccion = value; } }
        public string domicilio_fono { get { return _domicilio_fono; } set { _domicilio_fono = value; } }
        public int domicilio_id_zona { get { return _domicilio_id_zona; } set { _domicilio_id_zona = value; } }
        public string oficina_direccion { get { return _oficina_direccion; } set { _oficina_direccion = value; } }
        public string oficina_fono { get { return _oficina_fono; } set { _oficina_fono = value; } }
        public int oficina_id_zona { get { return _oficina_id_zona; } set { _oficina_id_zona = value; } }
        public bool transitorio { get { return _transitorio; } set { _transitorio = value; } }

        public string codigo_lugarcedula { get { return _codigo_lugarcedula; } }
        public string nombre_lugarcobro { get { return _nombre_lugarcobro; } }
        public string nombre_zona_domicilio { get { return _nombre_zona_domicilio; } }
        public string nombre_zona_oficina { get { return _nombre_zona_oficina; } }
        public int num_contratos { get { return _num_contratos; } }
        public int num_servicios { get { return _num_servicios; } }
        public int num_audit { get { return _num_audit; } }
        #endregion

        #region Constructores
        public cliente(int Id_cliente)
        {
            _id_cliente = Id_cliente;
            RecuperarDatos();
        }

        public cliente(int Id_lugarcedula, int Id_lugarcobro, string Ci, string Nit,
            string Nombres, string Paterno, string Materno, DateTime Fecha_nacimiento, string Celular,
            string Fax, string Email, string Casilla, string Domicilio_direccion, string Domicilio_fono,
            int Domicilio_id_zona, string Oficina_direccion, string Oficina_fono, int Oficina_id_zona,
            bool Transitorio)
        {
            _id_lugarcedula = Id_lugarcedula;
            _id_lugarcobro = Id_lugarcobro;
            _ci = Ci;
            _nit = Nit;
            _nombres = Nombres;
            _paterno = Paterno;
            _materno = Materno;
            _fecha_nacimiento = Fecha_nacimiento;
            _celular = Celular;
            _fax = Fax;
            _email = Email;
            _casilla = Casilla;
            _domicilio_direccion = Domicilio_direccion;
            _domicilio_fono = Domicilio_fono;
            _domicilio_id_zona = Domicilio_id_zona;
            _oficina_direccion = Oficina_direccion;
            _oficina_fono = Oficina_fono;
            _oficina_id_zona = Oficina_id_zona;
            _transitorio = Transitorio;
        }

        public cliente(int Id_cliente, int Id_lugarcedula, int Id_lugarcobro, string Ci, string Nit,
            string Nombres, string Paterno, string Materno, DateTime Fecha_nacimiento, string Celular,
            string Fax, string Email, string Casilla, string Domicilio_direccion, string Domicilio_fono,
            int Domicilio_id_zona, string Oficina_direccion, string Oficina_fono, int Oficina_id_zona,
            bool Transitorio)
        {
            _id_cliente = Id_cliente;
            _id_lugarcedula = Id_lugarcedula;
            _id_lugarcobro = Id_lugarcobro;
            _ci = Ci;
            _nit = Nit;
            _nombres = Nombres;
            _paterno = Paterno;
            _materno = Materno;
            _fecha_nacimiento = Fecha_nacimiento;
            _celular = Celular;
            _fax = Fax;
            _email = Email;
            _casilla = Casilla;
            _domicilio_direccion = Domicilio_direccion;
            _domicilio_fono = Domicilio_fono;
            _domicilio_id_zona = Domicilio_id_zona;
            _oficina_direccion = Oficina_direccion;
            _oficina_fono = Oficina_fono;
            _oficina_id_zona = Oficina_id_zona;
            _transitorio = Transitorio;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Tipo_cliente, bool Busqueda,
            string Ci, string Paterno, string Materno, string Nombres, string Num_contrato)
        {
            //[id_cliente],[id_lugarcedula],[id_lugarcobro],[id_usuario],[ci],[nit],
            //[nombres],[paterno],[materno],[fecha_nacimiento],[celular],[fax],[email],[casilla],
            //[domicilio_direccion],[domicilio_fono],[domicilio_id_zona],
            //[oficina_direccion],[oficina_fono],[oficina_id_zona],[transitorio],
            //[codigo_lugarcedula],[nombre_lugarcobro],[nombre_zona_domicilio],[nombre_zona_oficina]
            //[num_contratos],[num_servicios],[num_audit]
            DbCommand cmd = db1.GetStoredProcCommand("cliente_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "tipo_cliente", DbType.Int32, Tipo_cliente);
            db1.AddInParameter(cmd, "busqueda", DbType.Boolean, Busqueda);
            db1.AddInParameter(cmd, "ci", DbType.String, Ci);
            db1.AddInParameter(cmd, "paterno", DbType.String, Paterno);
            db1.AddInParameter(cmd, "materno", DbType.String, Materno);
            db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int ObtenerIdPorCi(string Ci)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_ObtenerIdPorCi");
                db1.AddInParameter(cmd, "ci", DbType.String, Ci);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static bool VerificarCI(bool Inserta, int Id_cliente, string CI)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_VerificarCI");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddInParameter(cmd, "ci", DbType.String, CI);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static int ObtenerIdPorNit(string Nit)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_ObtenerIdPorNit");
                db1.AddInParameter(cmd, "nit", DbType.String, Nit);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static bool VerificarNIT(bool Inserta, int Id_cliente, string NIT)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_VerificarNIT");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddInParameter(cmd, "nit", DbType.String, NIT);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool VerificarNombreCompleto(bool Inserta, int Id_cliente, string Nombres, string Paterno, string Materno)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_VerificarNombreCompleto");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
                db1.AddInParameter(cmd, "paterno", DbType.String, Paterno);
                db1.AddInParameter(cmd, "materno", DbType.String, Materno);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static void NumeroClientes(ref int Permanente, ref int Transitorio)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_NumeroClientes");
                db1.AddOutParameter(cmd, "permanente", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "transitorio", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                Permanente = (int)db1.GetParameterValue(cmd, "permanente");
                Transitorio = (int)db1.GetParameterValue(cmd, "transitorio");
            }
            catch { }
        }

        public static void UltimaModificacion(int Id_cliente, ref int Id_usuario, ref DateTime Fecha, ref string Nombre_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_UltimaModificacion");
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                Id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                Fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                Nombre_usuario = db1.GetParameterValue(cmd, "nombre_usuario").ToString();
            }
            catch
            {
                Id_usuario = 0;
                Fecha = DateTime.Now;
                Nombre_usuario = "";
            }
        }
        public static DataTable ReporteClientesDetalle(string Ci, string Paterno, string Materno, string Nombres,
                string Num_contrato, int Estado_contrato, DateTime Fecha_ultima_modificacion, int Preferencial,
                int Id_zona, int Transitorio)
        {
            DbCommand cmd = db1.GetStoredProcCommand("cliente_ReporteClientesDetalle");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "ci", DbType.String, Ci);
            db1.AddInParameter(cmd, "paterno", DbType.String, Paterno);
            db1.AddInParameter(cmd, "materno", DbType.String, Materno);
            db1.AddInParameter(cmd, "nombres", DbType.String, Nombres);
            db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
            db1.AddInParameter(cmd, "estado_contrato", DbType.Int32, Estado_contrato);
            db1.AddInParameter(cmd, "fecha_ultima_modificacion", DbType.DateTime, Fecha_ultima_modificacion);
            db1.AddInParameter(cmd, "preferencial", DbType.Int32, Preferencial);
            db1.AddInParameter(cmd, "id_zona", DbType.Int32, Id_zona);
            db1.AddInParameter(cmd, "transitorio", DbType.Int32, Transitorio);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_RecuperarDatos");
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                db1.AddOutParameter(cmd, "id_lugarcedula", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_lugarcobro", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "ci", DbType.String, 50);
                db1.AddOutParameter(cmd, "nit", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombres", DbType.String, 100);
                db1.AddOutParameter(cmd, "paterno", DbType.String, 100);
                db1.AddOutParameter(cmd, "materno", DbType.String, 100);
                db1.AddOutParameter(cmd, "fecha_nacimiento", DbType.DateTime, 100);
                db1.AddOutParameter(cmd, "celular", DbType.String, 50);
                db1.AddOutParameter(cmd, "fax", DbType.String, 50);
                db1.AddOutParameter(cmd, "email", DbType.String, 200);
                db1.AddOutParameter(cmd, "casilla", DbType.String, 50);
                db1.AddOutParameter(cmd, "domicilio_direccion", DbType.String, 200);
                db1.AddOutParameter(cmd, "domicilio_fono", DbType.String, 50);
                db1.AddOutParameter(cmd, "domicilio_id_zona", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "oficina_direccion", DbType.String, 200);
                db1.AddOutParameter(cmd, "oficina_fono", DbType.String, 50);
                db1.AddOutParameter(cmd, "oficina_id_zona", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "transitorio", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "codigo_lugarcedula", DbType.String, 10);
                db1.AddOutParameter(cmd, "nombre_lugarcobro", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_zona_domicilio", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_zona_oficina", DbType.String, 50);
                db1.AddOutParameter(cmd, "num_contratos", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_servicios", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_audit", DbType.Int32, 32);


                db1.ExecuteNonQuery(cmd);

                _id_lugarcedula = (int)db1.GetParameterValue(cmd, "id_lugarcedula");
                _id_lugarcobro = (int)db1.GetParameterValue(cmd, "id_lugarcobro");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _ci = (string)db1.GetParameterValue(cmd, "ci");
                _nit = (string)db1.GetParameterValue(cmd, "nit");
                _nombres = (string)db1.GetParameterValue(cmd, "nombres");
                _paterno = (string)db1.GetParameterValue(cmd, "paterno");
                _materno = (string)db1.GetParameterValue(cmd, "materno");
                _fecha_nacimiento = (DateTime)db1.GetParameterValue(cmd, "fecha_nacimiento");
                _celular = (string)db1.GetParameterValue(cmd, "celular");
                _fax = (string)db1.GetParameterValue(cmd, "fax");
                _email = (string)db1.GetParameterValue(cmd, "email");
                _casilla = (string)db1.GetParameterValue(cmd, "casilla");
                _domicilio_direccion = (string)db1.GetParameterValue(cmd, "domicilio_direccion");
                _domicilio_fono = (string)db1.GetParameterValue(cmd, "domicilio_fono");
                _domicilio_id_zona = (int)db1.GetParameterValue(cmd, "domicilio_id_zona");
                _oficina_direccion = (string)db1.GetParameterValue(cmd, "oficina_direccion");
                _oficina_fono = (string)db1.GetParameterValue(cmd, "oficina_fono");
                _oficina_id_zona = (int)db1.GetParameterValue(cmd, "oficina_id_zona");
                _transitorio = (bool)db1.GetParameterValue(cmd, "transitorio");

                _codigo_lugarcedula = (string)db1.GetParameterValue(cmd, "codigo_lugarcedula");
                _nombre_lugarcobro = (string)db1.GetParameterValue(cmd, "nombre_lugarcobro");
                _nombre_zona_domicilio = (string)db1.GetParameterValue(cmd, "nombre_zona_domicilio");
                _nombre_zona_oficina = (string)db1.GetParameterValue(cmd, "nombre_zona_oficina");
                _num_contratos = (int)db1.GetParameterValue(cmd, "num_contratos");
                _num_servicios = (int)db1.GetParameterValue(cmd, "num_servicios");
                _num_audit = (int)db1.GetParameterValue(cmd, "num_audit");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            bool correcto = true;
            if (_ci != "") correcto = VerificarCI(true, 0, _ci).Equals(false);
            if (correcto == true)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("cliente_Insertar");
                    db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, _id_lugarcedula);
                    db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, _id_lugarcobro);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "ci", DbType.String, _ci);
                    db1.AddInParameter(cmd, "nit", DbType.String, _nit);
                    db1.AddInParameter(cmd, "nombres", DbType.String, _nombres);
                    db1.AddInParameter(cmd, "paterno", DbType.String, _paterno);
                    db1.AddInParameter(cmd, "materno", DbType.String, _materno);
                    if (_fecha_nacimiento.Date == DateTime.Now.Date)
                        db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, null);
                    else db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, _fecha_nacimiento);
                    db1.AddInParameter(cmd, "celular", DbType.String, _celular);
                    db1.AddInParameter(cmd, "fax", DbType.String, _fax);
                    db1.AddInParameter(cmd, "email", DbType.String, _email);
                    db1.AddInParameter(cmd, "casilla", DbType.String, _casilla);
                    db1.AddInParameter(cmd, "domicilio_direccion", DbType.String, _domicilio_direccion);
                    db1.AddInParameter(cmd, "domicilio_fono", DbType.String, _domicilio_fono);
                    db1.AddInParameter(cmd, "domicilio_id_zona", DbType.Int32, _domicilio_id_zona);
                    db1.AddInParameter(cmd, "oficina_direccion", DbType.String, _oficina_direccion);
                    db1.AddInParameter(cmd, "oficina_fono", DbType.String, _oficina_fono);
                    db1.AddInParameter(cmd, "oficina_id_zona", DbType.Int32, _oficina_id_zona);
                    db1.AddInParameter(cmd, "transitorio", DbType.Boolean, _transitorio);
                    _id_cliente = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Actualizar(int context_id_usuario)
        {
            bool correcto = true;
            if (_ci != "") correcto = VerificarCI(false, _id_cliente, _ci).Equals(false);
            if (correcto == true)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("cliente_Actualizar");
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                    db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, _id_lugarcedula);
                    db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, _id_lugarcobro);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "ci", DbType.String, _ci);
                    db1.AddInParameter(cmd, "nit", DbType.String, _nit);
                    db1.AddInParameter(cmd, "nombres", DbType.String, _nombres);
                    db1.AddInParameter(cmd, "paterno", DbType.String, _paterno);
                    db1.AddInParameter(cmd, "materno", DbType.String, _materno);
                    if (_fecha_nacimiento.Date == DateTime.Now.Date)
                        db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, null);
                    else db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, _fecha_nacimiento);
                    db1.AddInParameter(cmd, "celular", DbType.String, _celular);
                    db1.AddInParameter(cmd, "fax", DbType.String, _fax);
                    db1.AddInParameter(cmd, "email", DbType.String, _email);
                    db1.AddInParameter(cmd, "casilla", DbType.String, _casilla);
                    db1.AddInParameter(cmd, "domicilio_direccion", DbType.String, _domicilio_direccion);
                    db1.AddInParameter(cmd, "domicilio_fono", DbType.String, _domicilio_fono);
                    db1.AddInParameter(cmd, "domicilio_id_zona", DbType.Int32, _domicilio_id_zona);
                    db1.AddInParameter(cmd, "oficina_direccion", DbType.String, _oficina_direccion);
                    db1.AddInParameter(cmd, "oficina_fono", DbType.String, _oficina_fono);
                    db1.AddInParameter(cmd, "oficina_id_zona", DbType.Int32, _oficina_id_zona);
                    db1.AddInParameter(cmd, "transitorio", DbType.Boolean, _transitorio);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_Eliminar");
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos para Autocompletar
        public static DataTable AutocompletarNombre(string Prefix)
        {
            //[nombre_completo]
            DbCommand cmd = db1.GetStoredProcCommand("cliente_AutocompletarNombre");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "prefix", DbType.String, Prefix);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion
    }
    public class tmpCliente
    {
        #region Propiedades
        //Propiedades privadas
        private int _id_cliente = 0;
        private string _ci = "";
        private string _codigo_lugar_cedula = "";
        private string _paterno = "";
        private string _materno = "";
        private string _nombres = "";
        private string _nit = "";
        private string _fono = "";
        private string _email = "";

        //Propiedades públicas
        public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
        public string ci { get { return _ci; } set { _ci = value; } }
        public string codigo_lugar_cedula { get { return _codigo_lugar_cedula; } set { _codigo_lugar_cedula = value; } }
        public string paterno { get { return _paterno; } set { _paterno = value; } }
        public string materno { get { return _materno; } set { _materno = value; } }
        public string nombres { get { return _nombres; } set { _nombres = value; } }
        public string nit { get { return _nit; } set { _nit = value; } }
        public string fono { get { return _fono; } set { _fono = value; } }
        public string email { get { return _email; } set { _email = value; } }
        #endregion

        #region Constructores
        public tmpCliente(int Id_cliente, string Ci, string Codigo_lugar_cedula,
            string Paterno, string Materno, string Nombres, string Nit, string Fono, string Email)
        {
            this._id_cliente = Id_cliente;
            this._ci = Ci;
            this._codigo_lugar_cedula = Codigo_lugar_cedula;
            this._paterno = Paterno;
            this._materno = Materno;
            this._nombres = Nombres;
            this._nit = Nit;
            this._fono = Fono;
            this._email = Email;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static string Insertar(string strCl, int Id_cliente, string Ci, string Codigo_lugar_cedula,
    string Paterno, string Materno, string Nombres, string Nit, string Fono, string Email)
        {
            List<tmpCliente> lista = ListaCliente(strCl);
            lista.Add(new tmpCliente(Id_cliente, Ci, Codigo_lugar_cedula, Paterno, Materno, Nombres, Nit, Fono, Email));
            return StringCliente(ref lista);
        }

        public static string Eliminar(string strCl, int Index)
        {
            List<tmpCliente> lista = ListaCliente(strCl);
            lista.RemoveAt(Index);
            return StringCliente(ref lista);
        }

        public static bool Verificar(string strCl, string Ci)
        {
            List<tmpCliente> lista = ListaCliente(strCl);
            bool existe = false;
            foreach (tmpCliente c in lista) if (c.ci == Ci) { existe = true; break; }
            return existe;
        }

        public static bool Verificar(string strCl, string Ci, string Paterno, string Materno, string Nombres)
        {
            List<tmpCliente> lista = ListaCliente(strCl);
            bool existe = false;
            foreach (tmpCliente c in lista)
            {
                if ((c.ci == Ci) || (c.paterno == Paterno && c.materno == Materno && c.nombres == Nombres))
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }

        private static string StringCliente(ref List<tmpCliente> lista)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            foreach (tmpCliente item in lista)
            {
                str.Append(item.id_cliente.ToString() + "Ù");
                str.Append(item.ci + "Ù");
                str.Append(item.codigo_lugar_cedula + "Ù");
                str.Append(item.paterno + "Ù");
                str.Append(item.materno + "Ù");
                str.Append(item.nombres + "Ù");
                str.Append(item.nit + "Ù");
                str.Append(item.fono + "Ù");
                str.Append(item.email);
                str.Append("Þ");
            }
            return str.ToString();
        }

        public static List<tmpCliente> ListaCliente(string strCl)
        {
            List<tmpCliente> lista = new List<tmpCliente>();
            if (strCl != null && strCl != "")
            {
                string[] fila = strCl.TrimEnd("Þ".ToCharArray()).Split("Þ".ToCharArray());
                for (int j = 0; j < fila.Length; j++)
                {
                    string[] c = fila[j].Split("Ù".ToCharArray());
                    lista.Add(new tmpCliente(int.Parse(c[0]), c[1], c[2], c[3], c[4], c[5], c[6], c[7], c[8]));
                }
            }
            return lista;
        }

        public static DataTable TablaCliente(string strCl)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_cliente", typeof(int));
            tabla.Columns.Add("ci", typeof(string));
            tabla.Columns.Add("codigo_lugar_cedula", typeof(string));
            tabla.Columns.Add("paterno", typeof(string));
            tabla.Columns.Add("materno", typeof(string));
            tabla.Columns.Add("nombres", typeof(string));
            tabla.Columns.Add("nit", typeof(string));
            tabla.Columns.Add("fono", typeof(string));
            tabla.Columns.Add("email", typeof(string));
            foreach (tmpCliente c in ListaCliente(strCl))
            {
                DataRow fila = tabla.NewRow();
                fila["id_cliente"] = c.id_cliente;
                fila["ci"] = c.ci;
                fila["codigo_lugar_cedula"] = c.codigo_lugar_cedula;
                fila["paterno"] = c.paterno;
                fila["materno"] = c.materno;
                fila["nombres"] = c.nombres;
                fila["nit"] = c.nit;
                fila["fono"] = c.fono;
                fila["email"] = c.email;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion

    }
}