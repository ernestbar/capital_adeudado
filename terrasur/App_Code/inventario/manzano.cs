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
/// Summary description for manzano
/// </summary>
namespace terrasur
{
    public class manzano
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_manzano = 0;
        private int _id_urbanizacion = 0;
        private string _codigo = "";

        private int _num_lote = 0;

        //Propiedades públicas
        public int id_manzano { get { return _id_manzano; } set { _id_manzano = value; } }
        public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }

        public int num_lote { get { return _num_lote; } }
        #endregion

        #region Constructores
        public manzano(int Id_manzano)
        {
            _id_manzano = Id_manzano;
            RecuperarDatos();
        }
        public manzano(string Codigo)
        {
            _codigo = Codigo;
            RecuperarDatos();
        }
        public manzano(int Id_urbanizacion, string Codigo)
        {
            _id_urbanizacion = Id_urbanizacion;
            _codigo = Codigo;
        }  
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_urbanizacion)
        {
            //[id_manzano],[codigo],[num_lote]
            DbCommand cmd = db1.GetStoredProcCommand("manzano_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable Lista_para_ddl(int Id_urbanizacion)
        {
            //[id_manzano],[codigo]
            DbCommand cmd = db1.GetStoredProcCommand("manzano_Lista_para_ddl");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        public static bool VerificarCodigo(bool Inserta,int Id_urbanizacion, int Id_manzano, string Codigo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("manzano_VerificarCodigo");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
                db1.AddInParameter(cmd, "id_manzano", DbType.Int32, Id_manzano);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
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
                DbCommand cmd = db1.GetStoredProcCommand("manzano_RecuperarDatos");
                db1.AddInParameter(cmd, "id_manzano0", DbType.Int32, _id_manzano);
                db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                db1.AddOutParameter(cmd, "id_manzano", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);

                db1.AddOutParameter(cmd, "num_lote", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_manzano = (int)db1.GetParameterValue(cmd, "id_manzano");
                _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");

                _num_lote = (int)db1.GetParameterValue(cmd, "num_lote");
            }
            catch { }
        }
        public bool Insertar()
        {
            if (VerificarCodigo(true,_id_urbanizacion, 0, _codigo) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("manzano_Insertar");
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.String, _id_urbanizacion);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    _id_urbanizacion = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }


        public bool Actualizar()
        {
            if (VerificarCodigo(false,_id_urbanizacion, _id_manzano, _codigo) == false)
            {

                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("manzano_Actualizar");
                    db1.AddInParameter(cmd, "id_manzano", DbType.Int32, _id_manzano);
                    db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar()
        {
            if (this._num_lote == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("manzano_Eliminar");
                    db1.AddInParameter(cmd, "id_manzano", DbType.Int32, _id_manzano);
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