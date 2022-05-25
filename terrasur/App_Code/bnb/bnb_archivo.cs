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
    public class bnb_archivo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_archivo = 0;
        private int _id_archivo_origen = 0;
        private int _id_institucion = 0;
        private int _id_tipoarchivo = 0;
        private int _id_clasearchivo = 0;
        private int _id_codigociudad = 0;
        private int _id_usuario = 0;
        private DateTime _enviado_fecha = DateTime.Now;
        private int _enviado_num = 0;
        private int _enviado_num_registros = 0;
        private DateTime _procesado_fecha = DateTime.Now;
        private int _procesado_num_registros = 0;
        private string _version_archivo = "";
        private string _nombre = "";
        private string _cabecera = "";

        private string _codigo_tipoarchivo = "";
        private string _codigo_clasearchivo = "";
        private string _codigo_codigociudad = "";
        private string _codigo_institucion = "";

        //Propiedades públicas
        public int id_archivo { get { return _id_archivo; } set { _id_archivo = value; } }
        public int id_archivo_origen { get { return _id_archivo_origen; } set { _id_archivo_origen = value; } }
        public int id_institucion { get { return _id_institucion; } set { _id_institucion = value; } }
        public int id_tipoarchivo { get { return _id_tipoarchivo; } set { _id_tipoarchivo = value; } }
        public int id_clasearchivo { get { return _id_clasearchivo; } set { _id_clasearchivo = value; } }
        public int id_codigociudad { get { return _id_codigociudad; } set { _id_codigociudad = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime enviado_fecha { get { return _enviado_fecha; } set { _enviado_fecha = value; } }
        public int enviado_num { get { return _enviado_num; } set { _enviado_num = value; } }
        public int enviado_num_registros { get { return _enviado_num_registros; } set { _enviado_num_registros = value; } }
        public DateTime procesado_fecha { get { return _procesado_fecha; } set { _procesado_fecha = value; } }
        public int procesado_num_registros { get { return _procesado_num_registros; } set { _procesado_num_registros = value; } }
        public string version_archivo { get { return _version_archivo; } set { _version_archivo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string cabecera { get { return _cabecera; } set { _cabecera = value; } }

        public string codigo_tipoarchivo { get { return _codigo_tipoarchivo; } }
        public string codigo_clasearchivo { get { return _codigo_clasearchivo; } }
        public string codigo_codigociudad { get { return _codigo_codigociudad; } }
        public string codigo_institucion { get { return _codigo_institucion; } }
        #endregion

        #region Constructores
        public bnb_archivo(int Id_archivo)
        {
            _id_archivo = Id_archivo;
            RecuperarDatos();
        }
        public bnb_archivo(int Id_institucion, DateTime Enviado_fecha, string Codigo_tipoarchivo, string Codigo_clasearchivo, string Codigo_codigociudad)
        {
            _id_institucion = Id_institucion;
            _enviado_fecha = Enviado_fecha;
            _codigo_tipoarchivo = Codigo_tipoarchivo;
            _codigo_clasearchivo = Codigo_clasearchivo;
            _codigo_codigociudad = Codigo_codigociudad;
        }
        public bnb_archivo(int Id_archivo_origen, string Nombre, string Cabecera)
        {
            _id_archivo_origen = Id_archivo_origen;
            _nombre = Nombre;
            _cabecera = Cabecera;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_institucion, string Codigo_tipo_archivo)
        {
            //[id_archivo],[codigo_tipo_archivo],[tipo_archivo],[clase_archivo],[enviado_fecha],[enviado_num],
            //[enviado_num_registros],[procesado_fecha],[procesado_num_registros],[nombre],[audit_fecha],[usuario],
            //[permitir_confirmacion],[confirmacion_id_archivo],[confirmacion_nombre]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
            db1.AddInParameter(cmd, "codigo_tipo_archivo", DbType.String, Codigo_tipo_archivo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaSimple(int Id_institucion, string Codigo_tipo_archivo)
        {
            //[id_archivo],[enviado_fecha],[enviado_num],[enviado_num_registros],[nombre],[estado],
            //[procesado],[procesado_id_archivo],[procesado_fecha],[procesado_num_registros],[procesado_nombre]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_ListaSimple");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_institucion", DbType.Int32, Id_institucion);
            db1.AddInParameter(cmd, "codigo_tipo_archivo", DbType.String, Codigo_tipo_archivo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        private static DataTable ContenidoParaTxt(int Id_archivo)
        {
            //[id_item],[item]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_ContenidoParaTxt");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_archivo", DbType.Int32, Id_archivo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static StringBuilder ContenidoParaTxt_StringBuilder(int Id_archivo)
        {
            DataTable tabla = ContenidoParaTxt(Id_archivo);
            StringBuilder str = new StringBuilder();
            for (int j = 0; j < tabla.Rows.Count; j++)
            {
                if (j == tabla.Rows.Count - 1) str.Append(tabla.Rows[j]["item"].ToString());
                else str.AppendLine(tabla.Rows[j]["item"].ToString());
            }
            return str;
        }

        public static DataTable ContenidoParaReporte(int Id_archivo)
        {
            //A: Deudores
            //[id_deudor],[id_contrato],[id_cliente],[codigo_deudor],[ci],[numero],[proceso],[proceso_fecha]
            //[correcto],[incorrecto_codigo],[incorrecto_nombre],[nombre],[fono],[factura_nit],[factura_nombre]

            //B: Conceptos de cobro
            //[id_conceptocobro],[id_parametroconcepto],[codigo],[codigo_concepto_cobro],[proceso],[proceso_fecha],
            //[correcto],[incorrecto_codigo],[incorrecto_nombre],[descripcion],[abreviacion],[genera_factura]

            //C: Cobros
            //[id_cobro],[codigo_deudor],[codigo_concepto_cobro],[proceso],[proceso_fecha],[correcto],[incorrecto_codigo],[incorrecto_nombre]
            //[cobrado],[cobrado_fecha],[cobrado_num_factura],[numero],[periodo_facturacion],[concepto_abreviacion],[importe_cobrar]

            DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_ContenidoParaReporte");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_archivo", DbType.Int32, Id_archivo);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool CargarConfirmacion(bnb_archivo archivo_origen, string ruta_archivo, string Nombre, int Context_id_usuario)
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

                if (lista_items.Count > 0)
                {
                    //Se registra el archivo de confirmacion
                    bnb_archivo aObj = new bnb_archivo(archivo_origen.id_archivo, Nombre, lista_items[0]);
                    if (aObj.ConfirmacionInsertar(Context_id_usuario) == true)
                    {
                        DataTable tabla_items = ContenidoParaTxt(archivo_origen.id_archivo);

                        //Se revisan los registros de errores uno a uno
                        for (int j = 1; j < lista_items.Count; j++)
                        {
                            int num_registro_errado = 0;
                            switch (archivo_origen.codigo_tipoarchivo)
                            {
                                case "A": if (int.TryParse(lista_items[j].Substring(140, 6), out num_registro_errado) == false) num_registro_errado = 0; break;
                                case "B": if (int.TryParse(lista_items[j].Substring(94, 6), out num_registro_errado) == false) num_registro_errado = 0; break;
                                case "C": if (int.TryParse(lista_items[j].Substring(151, 6), out num_registro_errado) == false) num_registro_errado = 0; break;
                            }
                            if (num_registro_errado > 0 && num_registro_errado < tabla_items.Rows.Count)
                            {
                                if (ConfirmacionActualizar(archivo_origen.codigo_tipoarchivo, aObj.id_archivo, int.Parse(tabla_items.Rows[num_registro_errado]["id_item"].ToString()), lista_items[j]) == false)
                                    correcto = false;
                            }
                            else { correcto = false; }
                        }
                    }
                    else { correcto = false; }
                }
                else { correcto = false; }
            }
            else { correcto = false; }
            return correcto;
        }
        public static bool ConfirmacionActualizar(string Codigo_tipo_archivo, int Id_archivo_confirmacion, int Id_item, string Registro)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_ConfirmacionActualizar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "codigo_tipo_archivo", DbType.String, Codigo_tipo_archivo);
                db1.AddInParameter(cmd, "id_archivo_confirmacion", DbType.Int32, Id_archivo_confirmacion);
                db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);
                db1.AddInParameter(cmd, "registro", DbType.String, Registro);
                if ((int)db1.ExecuteScalar(cmd) == 1) return true;
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
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);
                db1.AddOutParameter(cmd, "id_institucion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_tipoarchivo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_clasearchivo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_codigociudad", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "enviado_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "enviado_num", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "enviado_num_registros", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "procesado_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "procesado_num_registros", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "version_archivo", DbType.String, 5);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 12);
                db1.AddOutParameter(cmd, "cabecera", DbType.String, 200);

                db1.AddOutParameter(cmd, "codigo_tipoarchivo", DbType.String, 10);
                db1.AddOutParameter(cmd, "codigo_clasearchivo", DbType.String, 10);
                db1.AddOutParameter(cmd, "codigo_codigociudad", DbType.String, 10);
                db1.AddOutParameter(cmd, "codigo_institucion", DbType.String, 10);

                db1.ExecuteNonQuery(cmd);

                _id_institucion = (int)db1.GetParameterValue(cmd, "id_institucion");
                _id_tipoarchivo = (int)db1.GetParameterValue(cmd, "id_tipoarchivo");
                _id_clasearchivo = (int)db1.GetParameterValue(cmd, "id_clasearchivo");
                _id_codigociudad = (int)db1.GetParameterValue(cmd, "id_codigociudad");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _enviado_fecha = (DateTime)db1.GetParameterValue(cmd, "enviado_fecha");
                _enviado_num = (int)db1.GetParameterValue(cmd, "enviado_num");
                _enviado_num_registros = (int)db1.GetParameterValue(cmd, "enviado_num_registros");
                _procesado_fecha = (DateTime)db1.GetParameterValue(cmd, "procesado_fecha");
                _procesado_num_registros = (int)db1.GetParameterValue(cmd, "procesado_num_registros");
                _version_archivo = (string)db1.GetParameterValue(cmd, "version_archivo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _cabecera = (string)db1.GetParameterValue(cmd, "cabecera");

                _codigo_tipoarchivo = (string)db1.GetParameterValue(cmd, "codigo_tipoarchivo");
                _codigo_clasearchivo = (string)db1.GetParameterValue(cmd, "codigo_clasearchivo");
                _codigo_codigociudad = (string)db1.GetParameterValue(cmd, "codigo_codigociudad");
                _codigo_institucion = (string)db1.GetParameterValue(cmd, "codigo_institucion");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_Insertar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_institucion", DbType.Int32, _id_institucion);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _enviado_fecha);

                db1.AddInParameter(cmd, "codigo_tipoarchivo", DbType.String, _codigo_tipoarchivo);
                db1.AddInParameter(cmd, "codigo_clasearchivo", DbType.String, _codigo_clasearchivo);
                db1.AddInParameter(cmd, "codigo_codigociudad", DbType.String, _codigo_codigociudad);

                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.AddOutParameter(cmd, "id_archivo", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _id_archivo = (int)db1.GetParameterValue(cmd, "id_archivo");
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_Actualizar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool ConfirmacionInsertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_ConfirmacionInsertar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivo_origen", DbType.Int32, id_archivo_origen);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "cabecera", DbType.String, _cabecera);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_archivo = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion


    }
}