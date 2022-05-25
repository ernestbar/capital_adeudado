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
/// Summary description for parametro_facturacion
/// </summary>
namespace terrasur
{
    public class parametro_facturacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_parametrofacturacion = 0;
        private int _id_sucursal = 0;
        private int _id_usuario = 0;
        private string _razon_social = "";
        private decimal _nit = 0;
        private DateTime _fecha_limite;
        private decimal _num_autorizacion = 0;
        private string _llave_dosificacion = "";
        private int _num_siguiente_factura = 0;
        private string _encabezado_empresa = "";
        private string _encabezado_actividad = "";
        private string _encabezado_direccion = "";
        private string _encabezado_telefono = "";
        private string _encabezado_lugar = "";

        private int _num_facturas = 0;

        //Propiedades públicas
        public int id_parametrofacturacion { get { return _id_parametrofacturacion; } set { _id_parametrofacturacion = value; } }
        public int id_sucursal { get { return _id_sucursal; } set { _id_sucursal = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string razon_social { get { return _razon_social; } set { _razon_social = value; } }
        public decimal nit { get { return _nit; } set { _nit = value; } }
        public DateTime fecha_limite { get { return _fecha_limite; } set { _fecha_limite = value; } }
        public decimal num_autorizacion { get { return _num_autorizacion; } set { _num_autorizacion = value; } }
        public string llave_dosificacion { get { return _llave_dosificacion; } set { _llave_dosificacion = value; } }
        public int num_siguiente_factura { get { return _num_siguiente_factura; } set { _num_siguiente_factura = value; } }
        public string encabezado_empresa { get { return _encabezado_empresa; } set { _encabezado_empresa = value; } }
        public string encabezado_actividad { get { return _encabezado_actividad; } set { _encabezado_actividad = value; } }
        public string encabezado_direccion { get { return _encabezado_direccion; } set { _encabezado_direccion = value; } }
        public string encabezado_telefono { get { return _encabezado_telefono; } set { _encabezado_telefono = value; } }
        public string encabezado_lugar { get { return _encabezado_lugar; } set { _encabezado_lugar = value; } }

        public int num_facturas { get { return _num_facturas; } }
        #endregion

        #region Constructores
        public parametro_facturacion(int Id_parametrofacturacion)
        {
            _id_parametrofacturacion = Id_parametrofacturacion;
            RecuperarDatos();
        }
        public parametro_facturacion(int Id_sucursal, string Razon_social, decimal Nit, DateTime Fecha_limite, decimal Num_autorizacion, string Llave_dosificacion, int Num_siguiente_factura,
            string Encabezado_empresa, string Encabezado_actividad, string Encabezado_direccion, string Encabezado_telefono, string Encabezado_lugar)
        {
            _id_sucursal = Id_sucursal;
            _razon_social = Razon_social;
            _nit = Nit;
            _fecha_limite = Fecha_limite;
            _num_autorizacion = Num_autorizacion;
            _llave_dosificacion = Llave_dosificacion;
            _num_siguiente_factura = Num_siguiente_factura;

            _encabezado_empresa = Encabezado_empresa;
            _encabezado_actividad = Encabezado_actividad;
            _encabezado_direccion = Encabezado_direccion;
            _encabezado_telefono = Encabezado_telefono;
            _encabezado_lugar = Encabezado_lugar;
        }
        public parametro_facturacion(int Id_parametrofacturacion, int Id_sucursal, string Razon_social, decimal Nit, DateTime Fecha_limite, decimal Num_autorizacion, string Llave_dosificacion, int Num_siguiente_factura,
            string Encabezado_empresa, string Encabezado_actividad, string Encabezado_direccion, string Encabezado_telefono, string Encabezado_lugar)
        {
            _id_parametrofacturacion = Id_parametrofacturacion;
            _id_sucursal = Id_sucursal;
            _razon_social = Razon_social;
            _nit = Nit;
            _fecha_limite = Fecha_limite;
            _num_autorizacion = Num_autorizacion;
            _llave_dosificacion = Llave_dosificacion;
            _num_siguiente_factura = Num_siguiente_factura;

            _encabezado_empresa = Encabezado_empresa;
            _encabezado_actividad = Encabezado_actividad;
            _encabezado_direccion = Encabezado_direccion;
            _encabezado_telefono = Encabezado_telefono;
            _encabezado_lugar = Encabezado_lugar;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_parametrofacturacion],[sucursal],[razon_social],[nit],[fecha_limite],[num_autorizacion],[num_siguiente_factura],[num_facturas],[negocios]
            DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            foreach (DataRow fila in tabla.Rows)
                fila["negocios"] = parametro_facturacion_negocio.ListaNegocio_String((int)fila["id_parametrofacturacion"]);
            return tabla;
        }

        public static DataTable ListaLibroVentas(int Id_sucursal)
        {
            //[id_parametrofacturacion],[razon_social]
            DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_ListaLibroVentas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int ActivoActual()
        {
            try
            {
                int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_ActivoActual");
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, Id_sucursal);
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
                DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, _id_parametrofacturacion);
                db1.AddOutParameter(cmd, "id_sucursal", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "razon_social", DbType.String, 100);
                db1.AddOutParameter(cmd, "nit", DbType.Double, 10);
                db1.AddOutParameter(cmd, "fecha_limite", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "num_autorizacion", DbType.Double, 15);
                db1.AddOutParameter(cmd, "llave_dosificacion", DbType.String, 256);
                db1.AddOutParameter(cmd, "num_siguiente_factura", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "encabezado", DbType.String, 300);

                db1.AddOutParameter(cmd, "num_facturas", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_sucursal = (int)db1.GetParameterValue(cmd, "id_sucursal");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _razon_social = (string)db1.GetParameterValue(cmd, "razon_social");
                _nit = (decimal)(double)db1.GetParameterValue(cmd, "nit");
                _fecha_limite = (DateTime)db1.GetParameterValue(cmd, "fecha_limite");
                _num_autorizacion = (decimal)(double)db1.GetParameterValue(cmd, "num_autorizacion");
                _llave_dosificacion = (string)db1.GetParameterValue(cmd, "llave_dosificacion");
                _num_siguiente_factura = (int)db1.GetParameterValue(cmd, "num_siguiente_factura");
                string encab = (string)db1.GetParameterValue(cmd, "encabezado");

                _num_facturas = (int)db1.GetParameterValue(cmd, "num_facturas");
                //try
                //{
                if (encab.Contains("|") == true)
                {
                    string[] enca = encab.Split('|');
                    _encabezado_empresa = enca[0];
                    _encabezado_actividad = enca[1];
                    _encabezado_direccion = enca[2];
                    _encabezado_telefono = enca[3];
                    _encabezado_lugar = enca[4];
                }
                //}
                //catch { }
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_Insertar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, _id_sucursal);
                db1.AddInParameter(cmd, "razon_social", DbType.String, _razon_social);
                db1.AddInParameter(cmd, "nit", DbType.Decimal, _nit);
                db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, _fecha_limite);
                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, _num_autorizacion);
                db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, _llave_dosificacion);
                db1.AddInParameter(cmd, "num_siguiente_factura", DbType.Int32, _num_siguiente_factura);
                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado_empresa.Trim() + '|' + _encabezado_actividad.Trim() + '|' + _encabezado_direccion.Trim() + '|' + _encabezado_telefono.Trim() + '|' + _encabezado_lugar.Trim());
                _id_parametrofacturacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }

        }

        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_Actualizar");
                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, _id_parametrofacturacion);
                db1.AddInParameter(cmd, "id_sucursal", DbType.Int32, _id_sucursal);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "razon_social", DbType.String, _razon_social);
                db1.AddInParameter(cmd, "nit", DbType.Decimal, _nit);
                db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, _fecha_limite);
                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, _num_autorizacion);
                db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, _llave_dosificacion);
                db1.AddInParameter(cmd, "num_siguiente_factura", DbType.Int32, _num_siguiente_factura);
                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado_empresa.Trim() + '|' + _encabezado_actividad.Trim() + '|' + _encabezado_direccion.Trim() + '|' + _encabezado_telefono.Trim() + '|' + _encabezado_lugar.Trim());
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_facturas == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_Eliminar");
                    db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, _id_parametrofacturacion);
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