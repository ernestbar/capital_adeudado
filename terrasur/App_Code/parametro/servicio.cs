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
/// Summary description for servicio
/// </summary>
namespace terrasur
{
    public class servicio
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_servicio = 0;
        private int _id_usuario = 0;
        private string _codigo = "";
        private string _nombre = "";
        private decimal _valor_sus = 0;
        private bool _varios = false;
        private bool _facturar = true;
        private bool _liquidacion = false;
        private bool _activo = true;
        private int _num_vendidos = 0;

        //Propiedades públicas
        public int id_servicio { get { return _id_servicio; } set { _id_servicio = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public decimal valor_sus { get { return _valor_sus; } set { _valor_sus = value; } }
        public bool varios { get { return _varios; } set { _varios = value; } }
        public bool facturar { get { return _facturar; } set { _facturar = value; } }
        public bool liquidacion { get { return _liquidacion; } set { _liquidacion = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }
        public int num_vendidos { get { return _num_vendidos; } }
        #endregion

        #region Constructores
        public servicio(int Id_servicio)
        {
            _id_servicio = Id_servicio;
            RecuperarDatos();
        }
        public servicio(string Codigo, string Nombre, decimal Valor_sus, bool Varios, bool Facturar, bool Liquidacion, bool Activo)
        {
            _codigo = Codigo;
            _nombre = Nombre;
            _valor_sus = Valor_sus;
            _varios = Varios;
            _facturar = Facturar;
            _liquidacion = Liquidacion;
            _activo = Activo;
        }
        #endregion


        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("servicio_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivosParaVenta()
        {
            //[id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("servicio_ListaActivosParaVenta");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivosParaLiquidacion()
        {
            //[id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("servicio_ListaActivosParaLiquidacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaLiquidacionDefecto()
        {
            //[id_servicio],[id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("servicio_ListaLiquidacionDefecto");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarCodigoNombre(bool Inserta, int Id_servicio, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_servicio", DbType.Int32, Id_servicio);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
                db1.AddInParameter(cmd, "nombre", DbType.String, Nombre);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("servicio_RecuperarDatos");
                db1.AddInParameter(cmd, "id_servicio", DbType.Int32, _id_servicio);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "valor_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "varios", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "facturar", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "liquidacion", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_vendidos", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _valor_sus = (decimal)(double)db1.GetParameterValue(cmd, "valor_sus");
                _varios = (bool)db1.GetParameterValue(cmd, "varios");
                _facturar = (bool)db1.GetParameterValue(cmd, "facturar");
                _liquidacion = (bool)db1.GetParameterValue(cmd, "liquidacion");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");


                _num_vendidos = (int)db1.GetParameterValue(cmd, "num_vendidos");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("servicio_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "valor_sus", DbType.Decimal, _valor_sus);
                    db1.AddInParameter(cmd, "varios", DbType.Boolean, _varios);
                    db1.AddInParameter(cmd, "facturar", DbType.Boolean, _facturar);
                    db1.AddInParameter(cmd, "liquidacion", DbType.Boolean, _liquidacion);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    _id_servicio = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }

        }


        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(false, _id_servicio, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("servicio_Actualizar");
                    db1.AddInParameter(cmd, "id_servicio", DbType.Int32, _id_servicio);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "valor_sus", DbType.Decimal, _valor_sus);
                    db1.AddInParameter(cmd, "varios", DbType.Boolean, _varios);
                    db1.AddInParameter(cmd, "facturar", DbType.Boolean, _facturar);
                    db1.AddInParameter(cmd, "liquidacion", DbType.Boolean, _liquidacion);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_vendidos == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("servicio_Eliminar");
                    db1.AddInParameter(cmd, "id_servicio", DbType.Int32, _id_servicio);
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

    public class tmpServicio
    {
        #region Propiedades
        //Propiedades privadas
        private int _id_servicio = 0;
        private string _nombre = "";
        private int _unidades = 0;
        private decimal _precio_unitario = 0;
        private decimal _precio_total = 0;
        private bool _facturar = true;
        private string _otros = "";
        //Propiedades públicas
        public int id_servicio { get { return _id_servicio; } set { _id_servicio = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int unidades { get { return _unidades; } set { _unidades = value; } }
        public decimal precio_unitario { get { return _precio_unitario; } set { _precio_unitario = value; } }
        public decimal precio_total { get { return _precio_total; } set { _precio_total = value; } }
        public bool facturar { get { return _facturar; } set { _facturar = value; } }
        public string otros { get { return _otros; } set { _otros = value; } }
        #endregion

        #region Constructores
        public tmpServicio(int Id_servicio, string Nombre, int Unidades, decimal Precio_unitario, decimal Precio_total, bool Facturar, string Otros)
        {
            this._id_servicio = Id_servicio;
            this._nombre = Nombre;
            this._unidades = Unidades;
            this._precio_unitario = Precio_unitario;
            this._precio_total = Precio_total;
            this._facturar = Facturar;
            this._otros = Otros;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static string Insertar(string strServ, int Id_servicio, string Nombre,
            int Unidades, decimal Precio_unitario, decimal Precio_total, bool Facturar, string Otros)
        {
            List<tmpServicio> lista = ListaServicio(strServ);
            lista.Add(new tmpServicio(Id_servicio, Nombre, Unidades, Precio_unitario, Precio_total, Facturar, Otros));
            return StringServicio(ref lista);
        }

        public static string Eliminar(string strServ, int Index)
        {
            List<tmpServicio> lista = ListaServicio(strServ);
            lista.RemoveAt(Index);
            return StringServicio(ref lista);
        }

        public static bool Verificar(string strServ, int Id_servicio)
        {
            List<tmpServicio> lista = ListaServicio(strServ);
            bool existe = false;
            foreach (tmpServicio s in lista) if (s.id_servicio == Id_servicio) { existe = true; break; }
            return existe;
        }

        public static decimal PrecioTotal(string strServ)
        {
            List<tmpServicio> lista = ListaServicio(strServ);
            decimal total = 0;
            foreach (tmpServicio s in lista) total += s.precio_total;
            return total;
        }

        private static string StringServicio(ref List<tmpServicio> lista)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            foreach (tmpServicio item in lista)
            {
                str.Append(item._id_servicio.ToString() + "Ù");
                str.Append(item.nombre + "Ù");
                str.Append(item.unidades.ToString() + "Ù");
                str.Append(item.precio_unitario.ToString() + "Ù");
                str.Append(item.precio_total.ToString() + "Ù");
                str.Append(item.facturar.ToString() + "Ù");
                str.Append(item.otros.ToString());
                str.Append("Þ");
            }
            return str.ToString();
        }

        public static List<tmpServicio> ListaServicio(string strServ)
        {
            List<tmpServicio> lista = new List<tmpServicio>();
            if (strServ != null && strServ != "")
            {
                string[] fila = strServ.TrimEnd("Þ".ToCharArray()).Split("Þ".ToCharArray());
                for (int j = 0; j < fila.Length; j++)
                {
                    string[] s = fila[j].Split("Ù".ToCharArray());
                    lista.Add(new tmpServicio(int.Parse(s[0]), s[1], int.Parse(s[2]), decimal.Parse(s[3]), decimal.Parse(s[4]), bool.Parse(s[5]), s[6]));
                }
            }
            return lista;
        }

        public static DataTable TablaServicio(string strServ)
        {
            //[id_servicio],[nombre],[unidades],[precio_unitario],[precio_total]
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_servicio", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("unidades", typeof(int));
            tabla.Columns.Add("precio_unitario", typeof(decimal));
            tabla.Columns.Add("precio_total", typeof(decimal));
            tabla.Columns.Add("facturar", typeof(bool));
            foreach (tmpServicio s in ListaServicio(strServ))
            {
                DataRow fila = tabla.NewRow();
                fila["id_servicio"] = s.id_servicio;
                fila["nombre"] = s.nombre;
                fila["unidades"] = s.unidades;
                fila["precio_unitario"] = s.precio_unitario;
                fila["precio_total"] = s.precio_total;
                fila["facturar"] = s.facturar;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }

    // Facturacion Sintesis
    public class tmpServicio2
    {
        #region Propiedades
        //Propiedades privadas
        private int _id_transaccion = 0;
        private int _id_servicio = 0;
        private string _nombre = "";
        private int _unidades = 0;
        private decimal _precio_unitario = 0;
        private decimal _precio_total = 0;
        private bool _facturar = true;
        private string _otros = "";
        private int _id_cliente = 0;

        //Propiedades públicas
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public int id_servicio { get { return _id_servicio; } set { _id_servicio = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public int unidades { get { return _unidades; } set { _unidades = value; } }
        public decimal precio_unitario { get { return _precio_unitario; } set { _precio_unitario = value; } }
        public decimal precio_total { get { return _precio_total; } set { _precio_total = value; } }
        public bool facturar { get { return _facturar; } set { _facturar = value; } }
        public string otros { get { return _otros; } set { _otros = value; } }
        public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
        #endregion
    }
    //
}