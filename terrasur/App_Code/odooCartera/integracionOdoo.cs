using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace terrasur
{
    /// <summary>
    /// Descripción breve de integracionOdoo
    /// </summary>
    public class integracionOdoo
    {

        #region pago_odoo
        public  bool test()
        {
            bool resultado = false;
            string UrlBase = "http://odoo.bbr.com.bo/dao_terrasur/get_analytic_accounts";
            Label Label1 = new Label();
            Label1.Text = "{ \"jsonrpc\":\"" + ConfigurationManager.AppSettings["versionJson"] + "\",\"id\":\"20170317103327\",\"method\":\"call\",\"params\":{ \"context\":{ \"lang\":\"en_US\",\"tz\":\"America/La_Paz\" }, \"args\":[\"" + ConfigurationManager.AppSettings["token"] + "\"]}}";
            string respuestaServidor = odooRest.GetResponse_POST(UrlBase, Label1.Text);
            return resultado;
        }

        public string ListaCuentasAnaliticas()
        {
            string resultado = "";
            string UrlBase = "http://odoo.bbr.com.bo/dao_terrasur/get_analytic_accounts";
            Label Label1 = new Label();
            Label1.Text = "{ \"jsonrpc\":\"" + ConfigurationManager.AppSettings["versionJson"] + "\",\"id\":\"20170317103327\",\"method\":\"call\",\"params\":{ \"context\":{ \"lang\":\"en_US\",\"tz\":\"America/La_Paz\" }, \"args\":[\"" + ConfigurationManager.AppSettings["token"] + "\"]}}";
            string respuestaServidor = odooRest.GetResponse_POST(UrlBase, Label1.Text);
            return resultado;
        }

        public string AutenticarUsuarios()
        {
            string resultado = "";
            string UrlBase = "http://odoo.bbr.com.bo/dao_terrasur/authenticate";
            Label Label1 = new Label();
            Label1.Text = "{ \"jsonrpc\":\"" + ConfigurationManager.AppSettings["versionJson"] + "\",\"id\":\"20170317103327\",\"method\":\"call\",\"params\":{ \"context\":{ \"lang\":\"en_US\",\"tz\":\"America/La_Paz\" }, \"args\":[\"" + ConfigurationManager.AppSettings["token"] + "\"]}}";
            string respuestaServidor = odooRest.GetResponse_POST(UrlBase, Label1.Text);
            return resultado;
        }

        public string insertCuentaOdoo(string contrato, string lote, string id_transaccion, string detalle)
        {
            string resultado = "";
            string UrlBase = "http://odoo.bbr.com.bo/dao_terrasur/insert_account_move";
            Label Label1 = new Label();
            Label1.Text = "{ \"jsonrpc\":\"" + ConfigurationManager.AppSettings["versionJson"] + 
                "\",\"id\":\"20170317103327\",\"method\":\"call\",\"params\":{ \"context\":{ \"lang\":\"en_US\",\"tz\":\"America/La_Paz\" }, \"args\":[\"" + 
                ConfigurationManager.AppSettings["token"] + "\",{\"company_id\": 3,\"trans_id\":\"" +id_transaccion +"\", \"fecha\": \"" + 
                 DateTime.Now.Year.ToString()+ "-0" + DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString()+ "\",\"hora\": \"" + 
                 DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString() +
                  "\",\"ref\": \"PAGO DE CUOTA CONTRATO " + contrato +  "\", \"tipo_id\": 1, \"detalle\": [" + detalle + "]}]}}";
            string respuestaServidor = odooRest.GetResponse_POST(UrlBase, Label1.Text);
            return resultado;
        }


        #endregion
    }
}
   