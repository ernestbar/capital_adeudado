using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace terrasur
{
    public class odooRest
    {
        public enum Method { GET, POST }

        /*

        // Ejemplo de uso
         
        public void EnviarDatos()
        {
            string UrlBase = "http://findemor.porExpertos.es/servicioInventado.aspx";

            Dictionary<string, string> Parametros = new Dictionary<string,string>();
            Parametros.Add("nombre","Manuel");
            Parametros.Add("fecha","2012");

            string respuestaServidor = GetResponse(UrlBase, Parametros, Method.GET);
        }
         
        */






        /// <summary>
        /// Realiza el envio de parametros a un servicio web utilizando el metodo GET o POST
        /// </summary>
        /// <param name="urlBase">url del servicio</param>
        /// <param name="parameters">pares clave-valor que se enviaran</param>
        /// <param name="method">GET | POST</param>
        /// <returns>devuelve una cadena con la respuesta del servidor, o excepción si no funcionó</returns>
        /// <author>Findemor http://findemor.porExpertos.es</author>
        /// <history>Creado 17/02/2012</history>
       /// public static string GetResponse(string urlBase, Dictionary<string, string> parameters, Method method)
        public static string GetResponse(string urlBase, string parameters, Method method)
        {
            switch (method)
            {
                case Method.GET:
                    return GetResponse_GET(urlBase, parameters);
                case Method.POST:
                    return GetResponse_POST(urlBase, parameters);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Concatena los parámetros a una cadena de texto compatible con el API Rest
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Parametros concatenados en formato URL, no establece el caracter "?" al principio
        /// pero sí los "&" separadores</returns>
        /// <author>Findemor http://findemor.porExpertos.es</author>
        /// <history>Creado 17/02/2012</history>
        private static string ConcatParams(string parameters)
        {
            bool FirstParam = true;
            StringBuilder Parametros = null;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
            //if (parameters != null)
            //{
            //    Parametros = new StringBuilder();
            //    foreach (KeyValuePair<string, string> param in parameters)
            //    {
            //        Parametros.Append(FirstParam ? "" : ",");
            //        Parametros.Append(param.Key + "=" + System.Web.HttpUtility.UrlEncode(param.Value));
            //        FirstParam = false;
            //    }
            //}
            // Nirvana.JsonSerializer.Serializer obj=new Nirvana.JsonSerializer.Serializer();
            // return obj.Serialize(Parametros, true);
            //return Parametros == null ? string.Empty : Parametros.ToString();
            return json;
        }


        /// <summary>
        /// Realiza la peticion utilizando el método GET y devuelve la respuesta del servidor
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <author>Findemor http://findemor.porExpertos.es</author>
        /// <history>Creado 17/02/2012</history>
        public static string GetResponse_GET(string url, string parameters)
        {
            try
            {
                //Concatenamos los parametros, OJO: antes del primero debe estar el caracter "?"
                string parametrosConcatenados = ConcatParams(parameters);
                string urlConParametros = url + "?" + parametrosConcatenados;

                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(urlConParametros);
                wr.Method = "GET";

                wr.ContentType = "application/x-www-form-urlencoded";

                System.IO.Stream newStream;
                // Obtiene la respuesta
                System.Net.WebResponse response = wr.GetResponse();
                // Stream con el contenido recibido del servidor
                newStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(newStream);
                // Leemos el contenido
                string responseFromServer = reader.ReadToEnd();

                // Cerramos los streams
                reader.Close();
                newStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch (System.Web.HttpException ex)
            {
                if (ex.ErrorCode == 404)
                    throw new Exception("Not found remote service " + url);
                else throw ex;
            }
        }


        /// <summary>
        /// Realiza la petición utilizando el método POST y devuelve la respuesta del servidor
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <author>Findemor http://findemor.porExpertos.es</author>
        /// <history>Creado 17/02/2012</history>

        //public static string GetResponse_POST(string url, Dictionary<string, string> parameters)
        public static string GetResponse_POST(string url, string cadena)
        {
            try
            {
                //Concatenamos los parametros, OJO: NO se añade el caracter "?"

                //string parametrosConcatenados = ConcatParams(parameters);
                string parametrosConcatenados =cadena;
                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                wr.Method = "POST";

                wr.ContentType = "application/json";

                System.IO.Stream newStream;
                //Codificación del mensaje
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] byte1 = encoding.GetBytes(parametrosConcatenados);
                wr.ContentLength = byte1.Length;
                //Envio de parametros
                newStream = wr.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);

                // Obtiene la respuesta
                System.Net.WebResponse response = wr.GetResponse();
                // Stream con el contenido recibido del servidor
                newStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(newStream);
                // Leemos el contenido
                string responseFromServer = reader.ReadToEnd();

                // Cerramos los streams
                reader.Close();
                newStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch (System.Web.HttpException ex)
            {
                if (ex.ErrorCode == 404)
                    throw new Exception("Not found remote service " + url);
                else throw ex;
            }
        }

    }
}
    /// <summary>
    /// Descripción breve de odooRest
    /// </summary>
    