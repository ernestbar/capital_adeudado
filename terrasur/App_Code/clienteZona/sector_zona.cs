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
/// Summary description for sector
/// </summary>
namespace terrasur
{
    public class sector_zona
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_sector = 0;
        private string _codigo = "";
        private string _nombre = "";

        private int _num_zonas = 0;

        //Propiedades públicas
        public int id_sector { get { return _id_sector; } set { _id_sector = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public int num_zonas { get { return _num_zonas; } }
        #endregion

        #region Constructores
        public sector_zona(int Id_sector)
        {
            _id_sector = Id_sector;
            RecuperarDatos();
        }
        public sector_zona(string Codigo, string Nombre)
        {
            _codigo = Codigo;
            _nombre = Nombre;
        }
        public sector_zona(int Id_sector, string Codigo, string Nombre)
        {
            _id_sector = Id_sector;
            _codigo = Codigo;
            _nombre = Nombre;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_sector],[codigo],[nombre],[num_zonas]
            DbCommand cmd = db1.GetStoredProcCommand("sector_zona_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarCodigo(bool Inserta, int Id_sector, string Codigo)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("sector_zona_VerificarCodigo");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_sector", DbType.Int32, Id_sector);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static bool VerificarNombre(bool Inserta, int Id_sector, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("sector_zona_VerificarNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_sector", DbType.Int32, Id_sector);
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
                DbCommand cmd = db1.GetStoredProcCommand("sector_zona_RecuperarDatos");
                db1.AddInParameter(cmd, "id_sector", DbType.Int32, _id_sector);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 10);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);

                db1.AddOutParameter(cmd, "num_zonas", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");

                _num_zonas = (int)db1.GetParameterValue(cmd, "num_zonas");
            }
            catch { }
        }

        public bool Insertar()
        {
            if (VerificarCodigo(true, 0, _codigo) == false && VerificarNombre(true, 0, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("sector_zona_Insertar");
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    _id_sector = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Actualizar()
        {
            if (VerificarCodigo(false, _id_sector, _codigo) == false && VerificarNombre(false, _id_sector, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("sector_zona_Actualizar");
                    db1.AddInParameter(cmd, "id_sector", DbType.Int32, _id_sector);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar()
        {
            if (this._num_zonas == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("sector_zona_Eliminar");
                    db1.AddInParameter(cmd, "id_sector", DbType.Int32, _id_sector);
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