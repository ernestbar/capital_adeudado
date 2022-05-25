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
/// Summary description for lugar_cobro
/// </summary>
namespace terrasur
{
    public class lugar_cobro
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_lugarcobro = 0;
        private int _id_usuario = 0;
        private string _codigo = "";
        private string _nombre = "";
        private bool _cobrador = false;

        private int _num_clientes = 0;

        //Propiedades públicas
        public int id_lugarcobro { get { return _id_lugarcobro; } set { _id_lugarcobro = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool cobrador { get { return _cobrador; } set { _cobrador = value; } }

        public int num_clientes { get { return _num_clientes; } }
        #endregion

        #region Constructores
        public lugar_cobro(int Id_lugarcobro)
        {
            _id_lugarcobro = Id_lugarcobro;
            RecuperarDatos();
        }
        public lugar_cobro(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        public lugar_cobro(string Codigo, string Nombre, bool Cobrador)
        {
            _codigo = Codigo;
            _nombre = Nombre;
            _cobrador = Cobrador;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_lugarcobro],[id_usuario],[codigo],[nombre],[cobrador],[num_clientes]
            DbCommand cmd = db1.GetStoredProcCommand("lugar_cobro_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarCodigoNombre(bool Inserta, int Id_lugarcobro, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lugar_cobro_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, Id_lugarcobro);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
                db1.AddInParameter(cmd, "nombre", DbType.String, Nombre);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lugar_cobro_RecuperarDatos");
                db1.AddInParameter(cmd, "id_lugarcobro0", DbType.Int32, _id_lugarcobro);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);
                db1.AddOutParameter(cmd, "id_lugarcobro", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "cobrador", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_clientes", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_lugarcobro = (int)db1.GetParameterValue(cmd, "id_lugarcobro");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _cobrador = (bool)db1.GetParameterValue(cmd, "cobrador");

                _num_clientes = (int)db1.GetParameterValue(cmd, "num_clientes");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
    {
        if (VerificarCodigoNombre(true, 0,_codigo , _nombre) == false)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lugar_cobro_Insertar");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "cobrador", DbType.Boolean, _cobrador);
                _id_lugarcobro = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        else { return false; }
    }


        public bool Actualizar(int context_id_usuario)
    {
        if (VerificarCodigoNombre(false, _id_lugarcobro, _codigo , _nombre) == false)
        {

            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lugar_cobro_Actualizar");
                db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, _id_lugarcobro);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "cobrador", DbType.Boolean, _cobrador);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        else { return false; }
    }

        public bool Eliminar(int context_id_usuario)
    {
        if (this._num_clientes == 0)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("lugar_cobro_Eliminar");
                db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, _id_lugarcobro);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        else { return false; }
    }

    #endregion
    }
}