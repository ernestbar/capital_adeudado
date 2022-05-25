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
    public class bnb_conciliacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_conciliacion = 0;
        private int _id_archivoconciliacion = 0;
        private string _item = "";

        //Propiedades públicas
        public int id_conciliacion { get { return _id_conciliacion; } set { _id_conciliacion = value; } }
        public int id_archivoconciliacion { get { return _id_archivoconciliacion; } set { _id_archivoconciliacion = value; } }
        public string item { get { return _item; } }
        #endregion

        #region Constructores
        public bnb_conciliacion(int Id_archivoconciliacion, string Item) 
        {
            _id_archivoconciliacion = Id_archivoconciliacion;
            _item = Item;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Conciliar(int Id_archivoconciliacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_conciliacion_Conciliar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivoconciliacion", DbType.Int32, Id_archivoconciliacion);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion

        #region Métodos que requieren constructor
        public bool Insertar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bnb_conciliacion_Insertar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_archivoconciliacion", DbType.Int32, _id_archivoconciliacion);
                db1.AddInParameter(cmd, "item", DbType.String, _item);
                _id_conciliacion = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion
    }
}