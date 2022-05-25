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
/// Descripción breve de callcenter
/// </summary>
namespace terrasur
{
    public class callcenter
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["connCallCenter"]);


        public static DataTable ListaLLamadasContrato(int id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("llamada_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch(Exception ex)
            {
                DataTable dt=new DataTable();
                return dt;
            }
            //[id_archivo],[codigo_tipo_archivo],[tipo_archivo],[clase_archivo],[enviado_fecha],[enviado_num],
            //[enviado_num_registros],[procesado_fecha],[procesado_num_registros],[nombre],[audit_fecha],[usuario],
            //[permitir_confirmacion],[confirmacion_id_archivo],[confirmacion_nombre]

            }
    }
}