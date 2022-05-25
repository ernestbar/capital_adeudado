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
/// Summary description for lote
/// </summary>
namespace terrasur
{
    public class lote
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_lote = 0;
        private int _id_manzano = 0;
        private int _id_usuario = 0;
        private DateTime _fecha_registro = DateTime.Now;
        private string _codigo = "";
        private decimal _superficie_m2 = 0;
        private decimal _costo_m2_sus = 0;
        private decimal _precio_m2_sus = 0;
        private string _anterior_propietario = "";
        private string _num_partida = "";
        private bool _con_muro = false;
        private bool _con_construccion = false;

        private string _codigo_manzano = "";
        private string _codigo_urbanizacion = "";
        private string _codigo_localizacion = "";
        private string _nombre_urbanizacion = "";
        private string _nombre_localizacion = "";
        private string _nombre_estado = "";
        private string _nombre_negocio = "";
        private int _id_urbanizacion = 0;
        private int _id_localizacion = 0;
        private int _id_estadolote = 0;
        private int _id_negociolote = 0;
        private int _num_contratos = 0;
        private int _id_contrato_asignado = 0;

        //Propiedades públicas
        public int id_lote { get { return _id_lote; } set { _id_lote = value; } }
        public int id_manzano { get { return _id_manzano; } set { _id_manzano = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha_registro { get { return _fecha_registro; } set { _fecha_registro = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public decimal superficie_m2 { get { return _superficie_m2; } set { _superficie_m2 = value; } }
        public decimal costo_m2_sus { get { return _costo_m2_sus; } set { _costo_m2_sus = value; } }
        public decimal precio_m2_sus { get { return _precio_m2_sus; } set { _precio_m2_sus = value; } }
        public string anterior_propietario { get { return _anterior_propietario; } set { _anterior_propietario = value; } }
        public string num_partida { get { return _num_partida; } set { _num_partida = value; } }
        public bool con_muro { get { return _con_muro; } set { _con_muro = value; } }
        public bool con_construccion { get { return _con_construccion; } set { _con_construccion = value; } }

        public string codigo_manzano { get { return _codigo_manzano; } }
        public string codigo_urbanizacion { get { return _codigo_urbanizacion; } }
        public string codigo_localizacion { get { return _codigo_localizacion; } }
        public string nombre_urbanizacion { get { return _nombre_urbanizacion; } }
        public string nombre_localizacion { get { return _nombre_localizacion; } }
        public string nombre_estado { get { return _nombre_estado; } }
        public string nombre_negocio { get { return _nombre_negocio; } }
        public int id_urbanizacion { get { return _id_urbanizacion; } }
        public int id_localizacion { get { return _id_localizacion; } }
        public int id_estadolote { get { return _id_estadolote; } }
        public int id_negociolote { get { return _id_negociolote; } }
        public int num_contratos { get { return _num_contratos; } }
        public int id_contrato_asignado { get { return _id_contrato_asignado; } }
        #endregion

        #region Constructores
        public lote(int Id_lote)
        {
            _id_lote = Id_lote;
            RecuperarDatos();
        }
        public lote(int Id_manzano, string Codigo, decimal Superficie_m2, decimal Costo_m2_sus, decimal Precio_m2_sus, string Anterior_propietario, string Num_partida, bool Con_muro, bool Con_construccion)
        {
            _id_manzano = Id_manzano;
            _codigo = Codigo;
            _superficie_m2 = Superficie_m2;
            _costo_m2_sus = Costo_m2_sus;
            _precio_m2_sus = Precio_m2_sus;
            _anterior_propietario = Anterior_propietario;
            _num_partida = Num_partida;
            _con_muro = Con_muro;
            _con_construccion = Con_construccion;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_manzano)
        {
            //[id_lote],[id_usuario],[fecha_registro],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[anterior_propietario],[num_partida]
            DbCommand cmd = db1.GetStoredProcCommand("lote_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaDisponible(int Id_manzano)
        {
            //[id_lote],[codigo]
            DbCommand cmd = db1.GetStoredProcCommand("lote_ListaDisponible");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaContratos(int Id_lote)
        {
            //[id_contrato],[numero_contrato],[descrip]
            DbCommand cmd = db1.GetStoredProcCommand("lote_ListaContratos");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        
        public static bool VerificarCodigo(bool Inserta, int Id_manzano, int Id_lote, string Codigo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lote_VerificarCodigo");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, Id_lote);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static int Buscar(int Id_urbanizacion, bool Por_codigo_lote, string Codigo_numero)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lote_Buscar");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "por_codigo_lote", DbType.Boolean, Por_codigo_lote);
                db1.AddInParameter(cmd, "codigo_numero", DbType.String, Codigo_numero);
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
                DbCommand cmd = db1.GetStoredProcCommand("lote_RecuperarDatos");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);

                db1.AddOutParameter(cmd, "id_manzano", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha_registro", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "superficie_m2", DbType.Double, 14);
                db1.AddOutParameter(cmd, "costo_m2_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "precio_m2_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "anterior_propietario", DbType.String, 100);
                db1.AddOutParameter(cmd, "num_partida", DbType.String, 10);
                db1.AddOutParameter(cmd, "con_muro", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "con_construccion", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "codigo_manzano", DbType.String, 50);
                db1.AddOutParameter(cmd, "codigo_urbanizacion", DbType.String, 50);
                db1.AddOutParameter(cmd, "codigo_localizacion", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_urbanizacion", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_localizacion", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_estado", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_negocio", DbType.String, 100);
                db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_localizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_estadolote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_negociolote", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_contratos", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato_asignado", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_manzano = (int)db1.GetParameterValue(cmd, "id_manzano");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha_registro = (DateTime)db1.GetParameterValue(cmd, "fecha_registro");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _superficie_m2 = (decimal)(double)db1.GetParameterValue(cmd, "superficie_m2");
                _costo_m2_sus = (decimal)(double)db1.GetParameterValue(cmd, "costo_m2_sus");
                _precio_m2_sus = (decimal)(double)db1.GetParameterValue(cmd, "precio_m2_sus");
                _anterior_propietario = (string)db1.GetParameterValue(cmd, "anterior_propietario");
                _num_partida = (string)db1.GetParameterValue(cmd, "num_partida");
                _con_muro = (bool)db1.GetParameterValue(cmd, "con_muro");
                _con_construccion = (bool)db1.GetParameterValue(cmd, "con_construccion");

                _codigo_manzano = (string)db1.GetParameterValue(cmd, "codigo_manzano");
                _codigo_urbanizacion = (string)db1.GetParameterValue(cmd, "codigo_urbanizacion");
                _codigo_localizacion = (string)db1.GetParameterValue(cmd, "codigo_localizacion");
                _nombre_urbanizacion = (string)db1.GetParameterValue(cmd, "nombre_urbanizacion");
                _nombre_localizacion = (string)db1.GetParameterValue(cmd, "nombre_localizacion");
                _nombre_estado = (string)db1.GetParameterValue(cmd, "nombre_estado");
                _nombre_negocio = (string)db1.GetParameterValue(cmd, "nombre_negocio");
                _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                _id_localizacion = (int)db1.GetParameterValue(cmd, "id_localizacion");
                _id_estadolote = (int)db1.GetParameterValue(cmd, "id_estadolote");
                _id_negociolote = (int)db1.GetParameterValue(cmd, "id_negociolote");
                _num_contratos = (int)db1.GetParameterValue(cmd, "num_contratos");
                _id_contrato_asignado = (int)db1.GetParameterValue(cmd, "id_contrato_asignado");
            }
            catch { }
        }
        public bool Insertar(int Id_negocio, int context_id_usuario)
        {
            if (VerificarCodigo(true,_id_manzano, 0, _codigo) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("lote_Insertar");
                    db1.AddInParameter(cmd, "id_negocio_i", DbType.Int32, Id_negocio);
                    db1.AddInParameter(cmd, "id_manzano", DbType.Int32, _id_manzano);
                    db1.AddInParameter(cmd, "id_usuario_i", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "superficie_m2", DbType.Decimal, _superficie_m2);
                    db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, _costo_m2_sus);
                    db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, _precio_m2_sus);
                    db1.AddInParameter(cmd, "anterior_propietario", DbType.String, _anterior_propietario);
                    db1.AddInParameter(cmd, "num_partida", DbType.String, _num_partida);
                    db1.AddInParameter(cmd, "con_muro", DbType.Boolean, _con_muro);
                    db1.AddInParameter(cmd, "con_construccion", DbType.Boolean, _con_construccion);
                    _id_lote = (int)db1.ExecuteScalar(cmd);
                    if(_id_lote>0)
                    {if (Id_negocio == 3)
                    {
                        lote lot = new lote(_id_lote);
                        tipo_cambio tc = new tipo_cambio(DateTime.Now);
                        string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                        ////////////////INVENTARIOS////////////////
                        decimal costo_lote = _superficie_m2 * _costo_m2_sus*tc.compra;
                        manzano man = new manzano(_id_manzano);
                        urbanizacion urb = new urbanizacion(man.id_urbanizacion);
                        string nombre_urbanizacion = "";
                        nombre_urbanizacion = urb.nombre.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",",".") + " " + man.codigo.Trim() + " " + _codigo.Trim();
                        ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                        string resultado = obj.insertarMovimientosOdoo(3, true, "0", "", _id_lote.ToString(), 0, true, "INVENTARIO CREACION DE LOTES", 
                            0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, urb.id_urbanizacion.ToString(), "", "", true, true, nombre_urbanizacion, "", false, true, context_id_usuario,
                            true, ip, DateTime.Now.ToShortDateString(), costo_lote, true, 0, true, 0, true);
                    
                    }}
                    
                    return true;
                }
                catch(Exception EX) { return false; }
            }
            else { return false; }
        }


        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarCodigo(false,_id_manzano, _id_lote, _codigo) == false)
            {

                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("lote_Actualizar");
                    db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                    db1.AddInParameter(cmd, "id_manzano", DbType.Int32, _id_manzano);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "superficie_m2", DbType.Decimal, _superficie_m2);
                    db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, _costo_m2_sus);
                    db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, _precio_m2_sus);
                    db1.AddInParameter(cmd, "anterior_propietario", DbType.String, _anterior_propietario);
                    db1.AddInParameter(cmd, "num_partida", DbType.String, _num_partida);
                    db1.AddInParameter(cmd, "con_muro", DbType.Boolean, _con_muro);
                    db1.AddInParameter(cmd, "con_construccion", DbType.Boolean, _con_construccion);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_contratos == 0)
            {
                try
                {
                    
                    DbCommand cmd = db1.GetStoredProcCommand("lote_Eliminar");
                    db1.AddInParameter(cmd, "id_lote", DbType.Int32, _id_lote);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    ////////////////INVENTARIOS////////////////
                    RecuperarDatos();

                    
                    decimal costo_lote = _superficie_m2 * _costo_m2_sus * tc.compra;
                    manzano man = new manzano(_id_manzano);
                    urbanizacion urb = new urbanizacion(man.id_urbanizacion);
                    string nombre_urbanizacion = "";
                    nombre_urbanizacion = urb.nombre.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + man.codigo.Trim() + " " + _codigo.Trim();
                    ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    string resultado = obj.insertarMovimientosOdoo(3, true, "0", "", _id_lote.ToString(), 0, true, "INVENTARIO CREACION DE LOTES", 
                        0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, urb.id_urbanizacion.ToString(), 
                        "", "", true, true, nombre_urbanizacion, "", true, true, context_id_usuario,
                        true, ip, DateTime.Now.ToShortDateString(), costo_lote, true, 0, true, 0, true);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }
        #endregion
    }
}