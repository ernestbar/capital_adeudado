using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;

/// <summary>
/// Descripción breve de contratoEspecial
/// </summary>
namespace terrasur
{
    public class contrato_especial
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_contratoespecial = 0;
        private int _id_contrato = 0;
        private bool _especial = false;
        private DateTime _fecha = DateTime.Now;
        private int _id_usuario = 0;
        private string _observacion = "";

        private string _num_contrato = "";
        private string _nombre_usuario = "";

        //Propiedades públicas
        public int id_contratoespecial { get { return _id_contratoespecial; } set { _id_contratoespecial = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public bool especial { get { return _especial; } set { _especial = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string observacion { get { return _observacion; } set { _observacion = value; } }

        public string num_contrato { get { return _num_contrato; } }
        public string nombre_usuario { get { return _nombre_usuario; } }
        #endregion

        #region Constructores
        public contrato_especial(int Id_contrato, string Num_Contrato)
        {
            _id_contrato = Id_contrato;
            _num_contrato = Num_Contrato;
            RecuperarDatos();
        }
        public contrato_especial(int Id_contrato, bool Especial, string Observacion)
        {
            _id_contrato = Id_contrato;
            _especial = Especial;
            _observacion = Observacion;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Especial)
        {
            //[id_contrato],[especial],[especial_string],[num_contrato],[estado],[lote],[titular],
            //[observacion],[observacion_breve],[fecha_ultimo_pago],[interes_fecha],[num_dias_mora],[saldo]
            DbCommand cmd = db1.GetStoredProcCommand("[dbo].[contrato_especial_Lista]");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "especial", DbType.Int32, Especial);

            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_especial_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato0", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "num_contrato0", DbType.String, _num_contrato);

                db1.AddOutParameter(cmd, "id_contratoespecial", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "especial", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 50);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "observacion", DbType.String, 200);

                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 100);

                db1.ExecuteNonQuery(cmd);

                _id_contratoespecial = (int)db1.GetParameterValue(cmd, "id_contratoespecial");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _especial = (bool)db1.GetParameterValue(cmd, "especial");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _observacion = db1.GetParameterValue(cmd, "observacion").ToString();

                _num_contrato = db1.GetParameterValue(cmd, "num_contrato").ToString();
                _nombre_usuario = db1.GetParameterValue(cmd, "nombre_usuario").ToString();
            }
            catch { }
        }

        public bool Insertar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_especial_Insertar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "especial", DbType.Boolean, _especial);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);
                _id_contratoespecial = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion

    }
}