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
/// Summary description for bnb_tipo_archivo
/// </summary>
namespace terrasur
{
    public class bnb_tipo_archivo
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades privadas
        private int _id_tipoarchivo = 0;
        private string _codigo = "";
        private string _nombre = "";
        private string _nombre_corto = "";
        private int _longitud = 0;
        private string _version_archivo = "";
        #endregion

        #region Propiedades públicas
        public int id_tipoarchivo { get { return _id_tipoarchivo; } set { _id_tipoarchivo = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string nombre_corto { get { return _nombre_corto; } set { _nombre_corto = value; } }
        public int longitud { get { return _longitud; } set { _longitud = value; } }
        public string version_archivo { get { return _version_archivo; } set { _version_archivo = value; } }
        #endregion

        #region Constructores
        public bnb_tipo_archivo(int Id_tipoarchivo)
        {
            _id_tipoarchivo = Id_tipoarchivo;
            RecuperarDatos();
        }
        public bnb_tipo_archivo(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_tipoarchivo],[codigo],[nombre],[nombre_corto],[longitud],[version_archivo]
            DbCommand cmd = db1.GetStoredProcCommand("bnb_tipo_archivo_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_tipo_archivo_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_tipoarchivo0", DbType.Int32, _id_tipoarchivo);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_tipoarchivo", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 1);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "nombre_corto", DbType.String, 50);
                db1.AddOutParameter(cmd, "longitud", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "version_archivo", DbType.String, 5);

                db1.ExecuteNonQuery(cmd);

                _id_tipoarchivo = (int)db1.GetParameterValue(cmd, "id_tipoarchivo");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _nombre_corto = (string)db1.GetParameterValue(cmd, "nombre_corto");
                _longitud = (int)db1.GetParameterValue(cmd, "longitud");
                _version_archivo = (string)db1.GetParameterValue(cmd, "version_archivo");
            }
            catch { }
        }

        #endregion


    }
}