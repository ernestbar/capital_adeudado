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
/// Summary description for general
/// </summary>
namespace terrasur
{
    public class parametro
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_parametro = 0;
        private int _id_usuario = 0;
        private string _nombre = "";
        private decimal _valor = 0;


        //Propiedades públicas
        public int id_parametro { get { return _id_parametro; } set { _id_parametro = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public decimal valor { get { return _valor; } set { _valor = value; } }
        #endregion

        #region Constructores
        public parametro(int Id_parametro)
        {
            _id_parametro = Id_parametro;
            RecuperarDatos();
        }
        public parametro(string Nombre)
        {
            _nombre = Nombre;
            RecuperarDatos();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_parametro],[id_usuario],[nombre],[valor]
            DbCommand cmd = db1.GetStoredProcCommand("parametro_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DateTime ConvertDecimalToDateTime(decimal Numero)
        {
            int Horas = Convert.ToInt32(Math.Floor(Numero));
            int Minutos = Convert.ToInt32((Numero - Convert.ToDecimal(Horas)) * 100);
            //return DateTime.Parse("12/12/2000  " + Horas.ToString() + ":" + Minutos.ToString() + ":00");
            return DateTime.Parse("12/12/2000").AddHours(Horas).AddMinutes(Minutos);
        }
        public static DateTime ConvertDecimalToDateTime(DateTime Fecha_referencial, decimal Numero)
        {
            int Horas = Convert.ToInt32(Math.Floor(Numero));
            int Minutos = Convert.ToInt32((Numero - Convert.ToDecimal(Horas)) * 100);
            //return DateTime.Parse(Fecha_referencial.ToShortDateString() + " " + Horas.ToString() + ":" + Minutos.ToString() + ":00");
            return Fecha_referencial.Date.AddHours(Horas).AddMinutes(Minutos);

        }
        public static Decimal ConvertDateTimeToDecimal(DateTime Fecha)
        {
            return Convert.ToDecimal(Fecha.Hour) + (Convert.ToDecimal(Fecha.Minute) / 100);
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("parametro_RecuperarDatos");
                db1.AddInParameter(cmd, "id_parametro0", DbType.Int32, _id_parametro);
                db1.AddInParameter(cmd, "nombre0", DbType.String, _nombre);
                db1.AddOutParameter(cmd, "id_parametro", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                db1.AddOutParameter(cmd, "valor", DbType.Double, 20);
                db1.ExecuteNonQuery(cmd);
                _id_parametro = (int)db1.GetParameterValue(cmd, "id_parametro");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _valor = (decimal)(double)db1.GetParameterValue(cmd, "valor");

            }
            catch { }
        }


        public bool Actualizar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("parametro_Actualizar");
                db1.AddInParameter(cmd, "id_parametro", DbType.Int32, _id_parametro);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "valor", DbType.Decimal, _valor);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }

        }

        #endregion

    }
}