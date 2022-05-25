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
/// Summary description for beneficiario_factura
/// </summary>
namespace terrasur
{
    public class beneficiario_factura
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_beneficiariofactura = 0;
        private int _id_contrato = 0;
        private string _nombre = "";
        private string _nit = "";

        //Propiedades públicas
        public int id_beneficiariofactura { get { return _id_beneficiariofactura; } set { _id_beneficiariofactura = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string nit { get { return _nit; } set { _nit = value; } }
        #endregion

        #region Constructores
        public beneficiario_factura(int Id_contrato)
        {
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }
        public beneficiario_factura(int Id_contrato, string Nombre, string Nit)
        {
            _id_contrato = Id_contrato;
            _nombre = Nombre;
            _nit = Nit;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaPorContrato(int Id_contrato)
        {
            DbCommand cmd = db1.GetStoredProcCommand("beneficiario_factura_ListaPorContrato");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("beneficiario_factura_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);

                db1.AddOutParameter(cmd, "id_beneficiariofactura", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "nit", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_beneficiariofactura = (int)db1.GetParameterValue(cmd, "id_beneficiariofactura");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _nit = (string)db1.GetParameterValue(cmd, "nit");
            }
            catch { }
        }

        public bool Asignar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("beneficiario_factura_Asignar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "nit", DbType.String, _nit);
                _id_beneficiariofactura = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}