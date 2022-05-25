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
using System.Text;
using System.Collections.Generic;
/// <summary>
/// Summary description for bnb_archivo
/// </summary>

namespace terrasur
{
    public class bnb_archivo_conciliacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_archivoconciliacion = 0;
        private int _id_institucion = 0;
        private int _id_tipoarchivo = 0;
        private int _id_clasearchivo = 0;
        private int _id_codigociudad = 0;
        private int _id_usuario = 0;
        private DateTime _fecha_inicio = DateTime.Now;
        private DateTime _fecha_fin = DateTime.Now;
        private int _num_registros = 0;
        private decimal _total_bs = 0;
        private decimal _total_sus = 0;
        private string _nombre = "";
        private string _cabecera = "";

        private string _codigo_tipoarchivo = "";
        private string _codigo_clasearchivo = "";
        private string _codigo_codigociudad = "";

        //Propiedades públicas
        public int id_archivoconciliacion { get { return _id_archivoconciliacion; } set { _id_archivoconciliacion = value; } }
        public int id_institucion { get { return _id_institucion; } set { _id_institucion = value; } }
        public int id_tipoarchivo { get { return _id_tipoarchivo; } set { _id_tipoarchivo = value; } }
        public int id_clasearchivo { get { return _id_clasearchivo; } set { _id_clasearchivo = value; } }
        public int id_codigociudad { get { return _id_codigociudad; } set { _id_codigociudad = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha_inicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
        public DateTime fecha_fin { get { return _fecha_fin; } set { _fecha_fin = value; } }
        public int num_registros { get { return _num_registros; } set { _num_registros = value; } }
        public decimal total_bs { get { return _total_bs; } set { _total_bs = value; } }
        public decimal total_sus { get { return _total_sus; } set { _total_sus = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string cabecera { get { return _cabecera; } set { _cabecera = value; } }

        public string codigo_tipoarchivo { get { return _codigo_tipoarchivo; } }
        public string codigo_clasearchivo { get { return _codigo_clasearchivo; } }
        public string codigo_codigociudad { get { return _codigo_codigociudad; } }
        #endregion

        #region Constructores
        public bnb_archivo_conciliacion(int Id_archivoconciliacion)
        {
            _id_archivoconciliacion = Id_archivoconciliacion;
            RecuperarDatos();
        }
        public bnb_archivo_conciliacion(int Id_institucion, string Nombre, string Cabecera)
        {
            _id_institucion = Id_institucion;
            _nombre = Nombre;
            _cabecera = Cabecera;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_institucion)
        {
            //[id_archivoconciliacion],[fecha_inicio],[fecha_fin],[num_registros],[total_bs],[total_sus],[num_pagos],[monto_pagos],[nombre],[audit_fecha],[permitir_conciliacion]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_conciliacion_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaSimple(int Id_institucion)
        {
            //[id_archivoconciliacion],[fecha_inicio],[fecha_fin],[num_registros],[total_bs],[total_sus],[num_pagos],[monto_pagos],[nombre],[anio]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_conciliacion_ListaSimple");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        private static DataTable ConciliacionParaTxt(int Id_archivoconciliacion)
        {
            //[id_item],[item]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_conciliacion_ContenidoParaTxt");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "Id_archivoconciliacion", DbType.Int32, Id_archivoconciliacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static StringBuilder ConciliacionParaTxt_StringBuilder(int Id_archivoconciliacion)
        {
            DataTable tabla = ConciliacionParaTxt(Id_archivoconciliacion);
            StringBuilder str = new StringBuilder();
            for (int j = 0; j < tabla.Rows.Count; j++)
            {
                if (j == tabla.Rows.Count - 1) str.Append(tabla.Rows[j]["item"].ToString());
                else str.AppendLine(tabla.Rows[j]["item"].ToString());
            }
            return str;
        }

        public static bool CargarConciliacion(int Id_institucion, string ruta_archivo, string Nombre, int Context_id_usuario, ref int Id_archivoconciliacion)
        {
            bool correcto = true;
            if (System.IO.File.Exists(ruta_archivo) == true)
            {
                //Se leen los datos:
                List<string> lista_items = new List<string>();
                System.IO.StreamReader archivo = new System.IO.StreamReader(ruta_archivo);
                string linea = archivo.ReadLine();
                while (linea != null && linea.Trim() != "") { lista_items.Add(linea); linea = archivo.ReadLine(); }
                archivo.Close();
                ordernar_lista(ref lista_items);

                if (lista_items.Count > 0)
                {
                    //Se registra el archivo de confirmacion
                    bnb_archivo_conciliacion aObj = new bnb_archivo_conciliacion(Id_institucion, Nombre, lista_items[0]);
                    if (aObj.Insertar(Context_id_usuario) == true)
                    {
                        for (int j = 1; j < lista_items.Count; j++)
                        {
                            if (new bnb_conciliacion(aObj.id_archivoconciliacion, lista_items[j]).Insertar() == false)
                            {
                                correcto = false;
                            }
                        }
                        if(correcto == true){Id_archivoconciliacion = aObj.id_archivoconciliacion;}
                    }
                    else { correcto = false; }
                }
                else { correcto = false; }
            }
            else { correcto = false; }
            //if (Id_archivoconciliacion > 0)
            return correcto;
        }

        private static void ordernar_lista(ref List<string> lista_items)
        {
            if (lista_items.Count > 1)
            {
                //Se guarda y retira el encabezado
                string encabezado = lista_items[0];
                lista_items.RemoveAt(0);
                //Se crea la tabla para depositar los datos
                DataTable tabla = new DataTable();
                tabla.Columns.Add("item", typeof(string));
                tabla.Columns.Add("contrato", typeof(string));
                tabla.Columns.Add("periodo", typeof(decimal));
                tabla.Columns.Add("num_factura", typeof(decimal));
                foreach (string item in lista_items)
                {
                    DataRow fila = tabla.NewRow();
                    fila["item"] = item;
                    fila["contrato"] = item.Substring(14, 8);
                    fila["periodo"] = decimal.Parse(item.Substring(30, 6));
                    fila["num_factura"] = decimal.Parse(item.Substring(84, 14));
                    tabla.Rows.Add(fila);
                }
                //Se crea una tabla ordenada
                tabla.DefaultView.Sort = "contrato,periodo,num_factura desc";
                DataTable tabla_ordenada = tabla.Clone();
                tabla_ordenada = tabla.DefaultView.ToTable();
                //Se limpia y reconstruye la lista con los datos ordenados
                lista_items.Clear();
                lista_items.Add(encabezado);
                for (int j = 0; j < tabla_ordenada.Rows.Count; j++) { lista_items.Add(tabla_ordenada.Rows[j]["item"].ToString()); }
            }
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_conciliacion_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivoconciliacion", DbType.Int32, _id_archivoconciliacion);
                db1.AddOutParameter(cmd, "id_institucion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_tipoarchivo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_clasearchivo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_codigociudad", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "fecha_inicio", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "fecha_fin", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "num_registros", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "total_bs", DbType.Decimal, 14);
                db1.AddOutParameter(cmd, "total_sus", DbType.Decimal, 14);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 12);
                db1.AddOutParameter(cmd, "cabecera", DbType.String, 144);

                db1.AddOutParameter(cmd, "codigo_tipoarchivo", DbType.String, 10);
                db1.AddOutParameter(cmd, "codigo_clasearchivo", DbType.String, 10);
                db1.AddOutParameter(cmd, "codigo_codigociudad", DbType.String, 10);

                db1.ExecuteNonQuery(cmd);

                _id_institucion = (int)db1.GetParameterValue(cmd, "id_institucion");
                _id_tipoarchivo = (int)db1.GetParameterValue(cmd, "id_tipoarchivo");
                _id_clasearchivo = (int)db1.GetParameterValue(cmd, "id_clasearchivo");
                _id_codigociudad = (int)db1.GetParameterValue(cmd, "id_codigociudad");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");

                _fecha_inicio = (DateTime)db1.GetParameterValue(cmd, "fecha_inicio");
                _fecha_fin = (DateTime)db1.GetParameterValue(cmd, "fecha_fin");
                _num_registros = (int)db1.GetParameterValue(cmd, "num_registros");
                _total_bs = (decimal)db1.GetParameterValue(cmd, "total_bs");
                _total_sus = (decimal)db1.GetParameterValue(cmd, "total_sus");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _cabecera = (string)db1.GetParameterValue(cmd, "cabecera");

                _codigo_tipoarchivo = (string)db1.GetParameterValue(cmd, "codigo_tipoarchivo");
                _codigo_clasearchivo = (string)db1.GetParameterValue(cmd, "codigo_clasearchivo");
                _codigo_codigociudad = (string)db1.GetParameterValue(cmd, "codigo_codigociudad");
            }
            catch { }
        }


        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_conciliacion_Insertar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_institucion", DbType.Int32, _id_institucion);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "cabecera", DbType.String, _cabecera);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_archivoconciliacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion
    }
}