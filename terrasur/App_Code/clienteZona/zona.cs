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
/// Summary description for zona
/// </summary>
namespace terrasur
{
    public class zona
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_zona = 0;
        private int _id_sector = 0;
        private string _nombre = "";

        private int _num_clientes = 0;
        private string _nombre_sector = "";

        //Propiedades públicas
        public int id_zona { get { return _id_zona; } set { _id_zona = value; } }
        public int id_sector { get { return _id_sector; } set { _id_sector = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }

        public int num_clientes { get { return _num_clientes; } }
        public string nombre_sector { get { return _nombre_sector; } }
        #endregion

        #region Constructores
        public zona(int Id_zona)
        {
            _id_zona = Id_zona;
            RecuperarDatos();
        }
        public zona(int Id_sector, string Nombre)
        {
            _id_sector = Id_sector;
            _nombre = Nombre;
        }
        public zona(int Id_zona, int Id_sector, string Nombre)
        {
            _id_zona = Id_zona;
            _id_sector = Id_sector;
            _nombre = Nombre;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_sector)
        {
            //[id_zona],[id_sector],[nombre],[num_clientes],[nombre_sector]
            DbCommand cmd = db1.GetStoredProcCommand("zona_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_sector", DbType.Int32, Id_sector);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarNombre(bool Inserta, int Id_zona, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("zona_VerificarNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_zona", DbType.Int32, Id_zona);
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
                DbCommand cmd = db1.GetStoredProcCommand("zona_RecuperarDatos");
                db1.AddInParameter(cmd, "id_zona", DbType.Int32, _id_zona);
                db1.AddOutParameter(cmd, "id_sector", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);

                db1.AddOutParameter(cmd, "num_clientes", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_sector", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_sector = (int)db1.GetParameterValue(cmd, "id_sector");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");

                _num_clientes = (int)db1.GetParameterValue(cmd, "num_clientes");
                _nombre_sector = (string)db1.GetParameterValue(cmd, "nombre_sector");
            }
            catch { }
        }

        public bool Insertar()
        {
            if (VerificarNombre(true, 0, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("zona_Insertar");
                    db1.AddInParameter(cmd, "id_sector", DbType.Int32, _id_sector);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    _id_zona = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Actualizar()
        {
            if (VerificarNombre(false, _id_zona, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("zona_Actualizar");
                    db1.AddInParameter(cmd, "id_zona", DbType.Int32, _id_zona);
                    db1.AddInParameter(cmd, "id_sector", DbType.Int32, _id_sector);
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
            if (this._num_clientes == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("zona_Eliminar");
                    db1.AddInParameter(cmd, "id_zona", DbType.Int32, _id_zona);
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