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

/// <summary>
/// Descripción breve de usuario_tipoPromotor
/// </summary>
namespace terrasur
{
    public class usuario_tipoPromotor
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_usuariotipopromotor = 0;
        private int _id_usuario_registro = 0;
        private int _id_usuario = 0;
        private int _id_tipopromotor = 0;
        private DateTime _fecha = DateTime.Now;

        private string _nombre_usuario_registro = "";
        private string _nombre_tipo_promotor = "";
        private string _codigo_tipo_promotor = "";

        //Propiedades públicas
        public int id_usuariotipopromotor { get { return _id_usuariotipopromotor; } set { _id_usuariotipopromotor = value; } }
        public int id_usuario_registro { get { return _id_usuario_registro; } set { _id_usuario_registro = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int id_tipopromotor { get { return _id_tipopromotor; } set { _id_tipopromotor = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }

        public string nombre_usuario_registro { get { return _nombre_usuario_registro; } }
        public string nombre_tipo_promotor { get { return _nombre_tipo_promotor; } }
        public string codigo_tipo_promotor { get { return _codigo_tipo_promotor; } }
        #endregion

        #region Constructores
        public usuario_tipoPromotor(int Id_usuario_promotor)
        {
            _id_usuario = Id_usuario_promotor;
            RecuperarDatos();
        }

        public usuario_tipoPromotor(int Id_usuario_promotor, int Id_tipopromotor)
        {
            _id_usuario = Id_usuario_promotor;
            _id_tipopromotor = Id_tipopromotor;
        }
        #endregion

        #region Métodos que NO requieren constructor
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_tipoPromotor_RecuperarDatos");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);

                db1.AddOutParameter(cmd, "id_usuariotipopromotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario_registro", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_tipopromotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "nombre_usuario_registro", DbType.String, 30);
                db1.AddOutParameter(cmd, "nombre_tipo_promotor", DbType.String, 40);
                db1.AddOutParameter(cmd, "codigo_tipo_promotor", DbType.String, 20);

                db1.ExecuteNonQuery(cmd);

                _id_usuariotipopromotor = (int)db1.GetParameterValue(cmd, "id_usuariotipopromotor");
                _id_usuario_registro = (int)db1.GetParameterValue(cmd, "id_usuario_registro");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _id_tipopromotor = (int)db1.GetParameterValue(cmd, "id_tipopromotor");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");

                _nombre_usuario_registro = (string)db1.GetParameterValue(cmd, "nombre_usuario_registro");
                _nombre_tipo_promotor = (string)db1.GetParameterValue(cmd, "nombre_tipo_promotor");
                _codigo_tipo_promotor = (string)db1.GetParameterValue(cmd, "codigo_tipo_promotor");
            }
            catch { }
        }

        public bool Insertar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("usuario_tipoPromotor_Insertar");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "id_tipopromotor", DbType.Int32, _id_tipopromotor);
                _id_usuariotipopromotor = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

    }
}