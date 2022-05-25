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

namespace terrasur
{
    /// <summary>
    /// Descripción breve de odoo_control_migracion
    /// </summary>
    public class odoo_control_migracion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_control = 0;
        private DateTime _fecha = DateTime.Now;
        private bool _migrado = true;

        //Propiedades públicas
        public int id_control { get { return _id_control; } set { _id_control = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool migrado { get { return _migrado; } set { _migrado = value; } }

        #endregion

        #region Constructores
        public odoo_control_migracion(DateTime Fecha)
        {
            _fecha = Fecha;
            RecuperarDatos();
        }
        public odoo_control_migracion(DateTime Fecha, bool Migrado)
        {
            _fecha = Fecha;
            _migrado = Migrado;
        }
        #endregion

        #region Métodos que NO requieren constructor
       
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_control_migracion_RecuperarDatos");
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddOutParameter(cmd, "id_control", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);

                _id_control = (Int32)db1.GetParameterValue(cmd, "id_control");
            }
            catch(Exception ex) { }
        }

        public bool Insertar(int context_id_usuario)
        {
            
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("odoo_control_migracion_Insertar");
                db1.AddInParameter(cmd, "fecha", DbType.String, _fecha);
                db1.AddInParameter(cmd, "migrado", DbType.Boolean, _migrado);
                _id_control = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
           
        }


        #endregion
    }
}