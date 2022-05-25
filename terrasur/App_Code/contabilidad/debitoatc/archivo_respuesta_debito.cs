using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de archivo_respuesta_debito
/// </summary>
namespace terrasur
{
    public class archivo_respuesta_debito
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_archivorespuestadebito = 0;
        private int _id_grupotransaccion = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private string _nombre = "";
        private string _tipo_respuesta = "";

        private string _usuario_nombre = "";
        private int _num_grupo_transaccion = 0;

        //Propiedades públicas
        public int id_archivorespuestadebito { get { return _id_archivorespuestadebito; } set { _id_archivorespuestadebito = value; } }
        public int id_grupotransaccion { get { return _id_grupotransaccion; } set { _id_grupotransaccion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string tipo_respuesta { get { return _tipo_respuesta; } set { _tipo_respuesta = value; } }

        public string usuario_nombre { get { return _usuario_nombre; } }
        public int num_grupo_transaccion { get { return _num_grupo_transaccion; } }

        public string fileName { get { return _num_grupo_transaccion.ToString() + "_" + _tipo_respuesta + "_" + id_archivorespuestadebito.ToString() + ".txt"; } }
        #endregion

        #region Constructores
        public archivo_respuesta_debito(int Id_grupotransaccion, string Tipo_respuesta)
        {
            _id_grupotransaccion = Id_grupotransaccion;
            _tipo_respuesta = Tipo_respuesta;
            RecuperarDatos();
        }
        public archivo_respuesta_debito(int Id_grupotransaccion, string Nombre, string Tipo_respuesta)
        {
            _id_grupotransaccion = Id_grupotransaccion;
            _nombre = Nombre;
            _tipo_respuesta = Tipo_respuesta;
        }
        #endregion

        #region Métodos que NO requieren constructor
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_respuesta_debito_RecuperarDatos");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
                db1.AddInParameter(cmd, "tipo_respuesta", DbType.String, _tipo_respuesta);

                db1.AddOutParameter(cmd, "id_archivorespuestadebito", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);

                db1.AddOutParameter(cmd, "usuario_nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "num_grupo_transaccion", DbType.Int32, 32);
                
                
                db1.ExecuteNonQuery(cmd);

                _id_archivorespuestadebito = (int)db1.GetParameterValue(cmd, "id_archivorespuestadebito");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");

                _usuario_nombre = (string)db1.GetParameterValue(cmd, "usuario_nombre");
                _num_grupo_transaccion = (int)db1.GetParameterValue(cmd, "num_grupo_transaccion");
            }
            catch { }
        }

        public bool Guardar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_respuesta_debito_Guardar");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "tipo_respuesta", DbType.String, _tipo_respuesta);
                _id_archivorespuestadebito = (int)db1.ExecuteScalar(cmd);
                _num_grupo_transaccion = new grupo_transaccion(_id_grupotransaccion).numero;
                return true;
            }
            catch { return false; }
        }

        public void Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_respuesta_debito_Eliminar");
                db1.AddInParameter(cmd, "id_archivorespuestadebito", DbType.Int32, _id_archivorespuestadebito);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }

        public bool ObtenerDatosArchivo(string ruta_archivo)
        {
            bool correcto = true;

            //Se verifica que el archio exista
            if (System.IO.File.Exists(ruta_archivo) == true)
            {
                //Se leen los datos:
                List<string> lista_respuestas = new List<string>();
                System.IO.StreamReader archivo = new System.IO.StreamReader(ruta_archivo);
                string linea = archivo.ReadLine();
                while (linea != null) { lista_respuestas.Add(linea); linea = archivo.ReadLine(); }
                archivo.Close();
                
                //Se verifica que los datos sean correctos
                if (VerificarDatosArchivo(lista_respuestas) == true)
                {
                    //Se Obtienen y registran las respuestas
                    List<string> respuestas = ObtenerRespuestasArchivo(lista_respuestas);
                    if (respuestas.Count > 0)
                    {
                        foreach (string resp in respuestas)
                        {
                            DbCommand cmd = db1.GetStoredProcCommand("archivo_respuesta_debito_RegistrarRespuesta");
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, int.Parse(resp.Split(';')[0]));
                            db1.AddInParameter(cmd, "tipo_respuesta", DbType.String, this.tipo_respuesta);
                            db1.AddInParameter(cmd, "codigo_respuesta", DbType.String, resp.Split(';')[1]);
                            if ((int)db1.ExecuteScalar(cmd) == 0)
                            {
                                correcto = false;
                                break;
                            }
                        }
                    }
                }
                else { correcto = false; }
            }
            else { correcto = false; }

            return correcto;
        }
        protected bool VerificarDatosArchivo(List<string> lista_respuestas)
        {
            bool correcto = true;
            if (lista_respuestas.Count > 0)
            {
                foreach (string respuesta in lista_respuestas)
                {
                    if (respuesta.Trim() != "")
                    {
                        string[] datos = respuesta.TrimEnd('|').Split('|');
                        if (datos.Length == 11)
                        {
                            int id_trans = 0;
                            if (int.TryParse(datos[0], out id_trans) == false) { correcto = false; break; }
                        }
                        else { correcto = false; break; }
                    }
                }
            }
            return correcto;
        }
        protected List<string> ObtenerRespuestasArchivo(List<string> lista_respuestas)
        {
            List<string> respuestas = new List<string>();
            if (lista_respuestas.Count > 0)
            {
                foreach (string resp in lista_respuestas)
                {
                    if (resp.Trim() != "")
                    {
                        string[] datos = resp.TrimEnd('|').Split('|');
                        respuestas.Add(int.Parse(datos[0]).ToString() + ";" + datos[10]);
                    }
                }
            }
            return respuestas;
        }
        #endregion
    }
}