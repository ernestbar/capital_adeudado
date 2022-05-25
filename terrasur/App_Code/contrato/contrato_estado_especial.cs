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
/// Descripción breve de contrato_estado_especial
/// </summary>
namespace terrasur
{
    public class estado_especial
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_estadoespecial = 0;
        private string _codigo = "";
        private string _nombre = "";

        //Propiedades públicas
        public int id_estadoespecial { get { return _id_estadoespecial; } set { _id_estadoespecial = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public estado_especial(int Id_estadoespecial,string Codigo)
        {
            _id_estadoespecial = Id_estadoespecial;
            _codigo = Codigo;
            RecuperarDatos();
        }

       
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_estadoespecial],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("estado_especial_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

      
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("estado_especial_RecuperarDatos");
                db1.AddInParameter(cmd, "id_estadoespecial0", DbType.Int32, _id_estadoespecial);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_estadoespecial", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.ExecuteNonQuery(cmd);
                _id_estadoespecial = (int)db1.GetParameterValue(cmd, "id_estadoespecial");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
            }
            catch { }
        }
        #endregion

    }

    public class contrato_estado_especial
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas


        //Propiedades públicas
        #endregion

        #region Constructores
        //public contrato_estado_especial() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool BloquearContrato(int Id_contrato, string Codigo_modulo)
        {
            if (Codigo_modulo == "adm") return false;
            else
                return contrato_estado_especial.VerificarActivo(Id_contrato, 0, "", "bloqueado");
        }

        public static bool Insertar(int Id_contrato, int Id_estadoespecial, int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_estado_especial_Insertar");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static bool Eliminar(int Id_contrato, int Id_estadoespecial, int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_estado_especial_Eliminar");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static bool Modificar(int Id_contrato, int Id_estadoespecial, int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_estado_especial_Modificar");
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static bool Verificar(int Id_contrato, int Id_estadoespecial, string Numero_contrato, string Codigo_estado_especial)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_estado_especial_Verificar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
                db1.AddInParameter(cmd, "numero_contrato", DbType.String, Numero_contrato);
                db1.AddInParameter(cmd, "codigo_estado_especial", DbType.String, Codigo_estado_especial);
                if ((int)db1.ExecuteScalar(cmd) == 0) return false;
                else return true;
            }
            catch { return false; }
        }

        public static bool VerificarActivo(int Id_contrato, int Id_estadoespecial, string Numero_contrato, string Codigo_estado_especial)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("contrato_estado_especial_VerificarActivo");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
                db1.AddInParameter(cmd, "numero_contrato", DbType.String, Numero_contrato);
                db1.AddInParameter(cmd, "codigo_estado_especial", DbType.String, Codigo_estado_especial);
                if ((int)db1.ExecuteScalar(cmd) == 0) return false;
                else return true;
            }
            catch { return false; }
        }

        public static DataTable ListaPorEstado(int Id_estadoespecial)
        {//[id_contrato],[id_estadoespecial],[estado_especial],[num_contrato],[estado],[negocio],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("contrato_estado_especial_ListaPorEstado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static DataTable RecuperarMensaje(int Id_contrato, int Id_estadoespecial)
        {
            //[id_estadoespecial],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("estado_especial_Lista_x_id_contrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, Id_estadoespecial);
            db1.AddInParameter(cmd, "id_contrato", DbType.String, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        #endregion

    }
}