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
/// Summary description for cliente_contrato
/// </summary>
namespace terrasur
{
    public class cliente_contrato
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_cliente = 0;
        private int _id_contrato = 0;
        private bool _primer_titular = false;

        //Propiedades públicas
        public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public bool primer_titular { get { return _primer_titular; } set { _primer_titular = value; } }
        #endregion

        #region Constructores
        public cliente_contrato(int Id_cliente, int Id_contrato)
        {
            _id_cliente = Id_cliente;
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }
        public cliente_contrato(int Id_cliente, int Id_contrato, bool Primer_titular)
        {
            _id_cliente = Id_cliente;
            _id_contrato = Id_contrato;
            _primer_titular = Primer_titular;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Verificar(int Id_cliente, int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_contrato_Verificar");
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }
        public static DataTable ListaClientesAdicionales(int Id_contrato)
        {
            //[id_cliente],[ci],[nombre_completo],[nit],[celular],[email]
            DbCommand cmd = db1.GetStoredProcCommand("cliente_contrato_ListaClientesAdicionales");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static string ListaClientesAdicionales_String(int Id_contrato)
        {
            DataTable tabla = ListaClientesAdicionales(Id_contrato);
            if (tabla.Rows.Count > 0)
            {
                System.Text.StringBuilder str = new System.Text.StringBuilder();
                foreach (DataRow fila in tabla.Rows) str.Append(fila["nombre_completo"].ToString() + ", ");
                return str.ToString().Trim().TrimEnd(',');
            }
            else return "Ninguno";
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cliente_contrato_RecuperarDatos");
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddOutParameter(cmd, "primer_titular", DbType.Boolean, 32);

                db1.ExecuteNonQuery(cmd);
                _primer_titular = (bool)db1.GetParameterValue(cmd, "primer_titular");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (Verificar(_id_cliente, _id_contrato) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("cliente_contrato_Insertar");
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "primer_titular", DbType.Boolean, _primer_titular);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (Verificar(_id_cliente, _id_contrato) == true)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("cliente_contrato_Eliminar");
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }
        #endregion
    }
}