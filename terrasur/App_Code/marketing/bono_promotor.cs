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
/// Descripción breve de bono_promotor
/// </summary>
namespace terrasur
{
    public class bono_promotor
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_bono = 0;
        private int _id_promotor = 0;
        private DateTime _fecha = DateTime.Now;
        private decimal _bono_mov = -1;
        private decimal _bono_prod_num_ventas = -1;
        private decimal _bono_prod_monto_ventas = -1;
        private decimal _bono_prod_premio = -1;
        private int _audit_id_usuario = 0;

        //Propiedades públicas
        public int id_bono { get { return _id_bono; } set { _id_bono = value; } }
        public int id_promotor { get { return _id_promotor; } set { _id_promotor = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public decimal bono_mov { get { return _bono_mov; } set { _bono_mov = value; } }
        public decimal bono_prod_num_ventas { get { return _bono_prod_num_ventas; } set { _bono_prod_num_ventas = value; } }
        public decimal bono_prod_monto_ventas { get { return _bono_prod_monto_ventas; } set { _bono_prod_monto_ventas = value; } }
        public decimal bono_prod_premio { get { return _bono_prod_premio; } set { _bono_prod_premio = value; } }
        public int audit_id_usuario { get { return _audit_id_usuario; } set { _audit_id_usuario = value; } }
        #endregion

        #region Constructores
        public bono_promotor(int Id_promotor, DateTime Fecha)
        {
            _id_promotor = Id_promotor;
            _fecha = Fecha.Date;
            RecuperarDatos();
        }
        public bono_promotor(int Id_promotor, DateTime Fecha, 
            decimal Bono_mov, decimal Bono_prod_num_ventas, 
            decimal Bono_prod_monto_ventas, decimal Bono_prod_premio)
        {
            _id_promotor = Id_promotor;
            _fecha = Fecha.Date;

            _bono_mov = Bono_mov;
            _bono_prod_num_ventas = Bono_prod_num_ventas;
            _bono_prod_monto_ventas = Bono_prod_monto_ventas;
            _bono_prod_premio = Bono_prod_premio;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(DateTime Fecha)
        {
            //[id_bono],[id_promotor],[bono_mov],[bono_prod_num_ventas],[bono_prod_monto_ventas],[bono_prod_premio]
            DbCommand cmd = db1.GetStoredProcCommand("bono_promotor_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaMeses()
        {
            DateTime fecha_inicio = DateTime.Parse("01/01/2010");
            DateTime fecha_fin = DateTime.Now.AddMonths(1);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("fecha", typeof(DateTime));
            tabla.Columns.Add("nombre", typeof(string));

            DateTime aux = fecha_inicio.Date;
            while (aux < fecha_fin)
            {
                DataRow fila = tabla.NewRow();
                fila["fecha"] = aux;
                fila["nombre"] = aux.ToString("yyyy") + " - " + general.Capitalize(aux.ToString("MMMM"));
                tabla.Rows.Add(fila);
                aux = aux.AddMonths(1);
            }
            return tabla;
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bono_promotor_RecuperarDatos");
                db1.AddInParameter(cmd, "id_promotor", DbType.Int32, _id_promotor);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime,_fecha);

                db1.AddOutParameter(cmd, "id_bono", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "bono_mov", DbType.Double, 200);
                db1.AddOutParameter(cmd, "bono_prod_num_ventas", DbType.Double, 200);
                db1.AddOutParameter(cmd, "bono_prod_monto_ventas", DbType.Double, 200);
                db1.AddOutParameter(cmd, "bono_prod_premio", DbType.Double, 200);
                db1.AddOutParameter(cmd, "audit_id_usuario", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);

                _id_bono = (int)db1.GetParameterValue(cmd, "id_bono");
                _bono_mov = (decimal)(double)db1.GetParameterValue(cmd, "bono_mov");
                _bono_prod_num_ventas = (decimal)(double)db1.GetParameterValue(cmd, "bono_prod_num_ventas");
                _bono_prod_monto_ventas = (decimal)(double)db1.GetParameterValue(cmd, "bono_prod_monto_ventas");
                _bono_prod_premio = (decimal)(double)db1.GetParameterValue(cmd, "bono_prod_premio");
                _audit_id_usuario = (int)db1.GetParameterValue(cmd, "audit_id_usuario");
            }
            catch { }
        }

        public bool Registrar(int audit_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("bono_promotor_Registrar");
                db1.AddInParameter(cmd, "id_promotor", DbType.Int32, _id_promotor);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                db1.AddInParameter(cmd, "bono_mov", DbType.Decimal, _bono_mov);
                db1.AddInParameter(cmd, "bono_prod_num_ventas", DbType.Decimal, _bono_prod_num_ventas);
                db1.AddInParameter(cmd, "bono_prod_monto_ventas", DbType.Decimal, _bono_prod_monto_ventas);
                db1.AddInParameter(cmd, "bono_prod_premio", DbType.Decimal, _bono_prod_premio);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, audit_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

    }
}