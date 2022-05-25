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
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Descripción breve de s_tipo_cambio
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_tipo_cambio
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_tipocambio = 0;
            private int _id_usuario = 0;
            private DateTime _fecha = DateTime.Now;
            private decimal _oficial = 0;
            private decimal _compra = 0;
            private decimal _venta = 0;
            private DateTime _audit_fecha = DateTime.Now;

            //Propiedades públicas
            public int id_tipocambio { get { return _id_tipocambio; } set { _id_tipocambio = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal oficial { get { return _oficial; } set { _oficial = value; } }
            public decimal compra { get { return _compra; } set { _compra = value; } }
            public decimal venta { get { return _venta; } set { _venta = value; } }
            public DateTime audit_fecha { get { return _audit_fecha; } set { _audit_fecha = value; } }
            #endregion

            #region Constructores
            public s_tipo_cambio(int Id_tipocambio)
            {
                _id_tipocambio = Id_tipocambio;
                RecuperarDatos();
            }

            public s_tipo_cambio(DateTime Fecha, decimal Oficial, decimal Compra, decimal Venta)
            {
                _fecha = Fecha;
                _oficial = Oficial;
                _compra = Compra;
                _venta = Venta;
            }

            #endregion

            #region Métodos que NO requieren constructor
            public static int IdVigente(DateTime Fecha)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_tipo_cambio_IdVigente");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_tipo_cambio_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_tipocambio", DbType.Int32, _id_tipocambio);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "oficial", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "compra", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "venta", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "audit_fecha", DbType.DateTime, 32);

                    db1.ExecuteNonQuery(cmd);

                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _oficial = (decimal)(double)db1.GetParameterValue(cmd, "oficial");
                    _compra = (decimal)(double)db1.GetParameterValue(cmd, "compra");
                    _venta = (decimal)(double)db1.GetParameterValue(cmd, "venta");
                    _audit_fecha = (DateTime)db1.GetParameterValue(cmd, "audit_fecha");
                }
                catch { }
            }

            public bool Registrar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_tipo_cambio_Registrar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
                    db1.AddInParameter(cmd, "oficial", DbType.Decimal, _oficial);
                    db1.AddInParameter(cmd, "compra", DbType.Decimal, _compra);
                    db1.AddInParameter(cmd, "venta", DbType.Decimal, _venta);
                    _id_tipocambio = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion

        }
    }
}