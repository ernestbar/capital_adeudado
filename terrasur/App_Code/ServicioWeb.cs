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
using System.Web.Services;

namespace terrasur
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : WebService
    {
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        [WebMethod]
        public string[] NombreCliente(string prefixText, int count)
        {
            if (count == 0) { count = 10; }
            DataTable tabla_nombrecompleto = cliente.AutocompletarNombre(prefixText);
            //string[] lista = new string[tabla_nombrecompleto.Rows.Count];
            //for (int j = 0; j < tabla_nombrecompleto.Rows.Count; j++)
            //    lista[j] = tabla_nombrecompleto.Rows[j]["nombre_completo"].ToString();
            //return lista;
            List<string> items = new List<string>(count);
            foreach (DataRow fila in tabla_nombrecompleto.Rows) items.Add(fila["nombre_completo"].ToString().Trim());
            return items.ToArray();
        }
    }
}
