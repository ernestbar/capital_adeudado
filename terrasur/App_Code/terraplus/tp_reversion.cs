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
/// Descripción breve de tp_reversion
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_reversion
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_reversion = 0;
            private int _id_contrato = 0;
            private int _id_motivoreversion = 0;
            private int _id_usuario = 0;
            private int _id_pago = 0;
            private DateTime _fecha = DateTime.Now;
            private int _meses_incumplidos = 0;
            private bool _anulado = false;
            private int _anulado_id_usuario = 0;
            private DateTime _anulado_fecha = DateTime.Now;

            private string _nombre_usuario = "";
            private string _motivo_nombre = "";
            private string _codigo_moneda = "";
            private int _pagado_num_pagos = 0;
            private decimal _pagado_monto = 0;
            private string _anulado_usuario = "";

            //Propiedades públicas
            public int id_reversion { get { return _id_reversion; } set { _id_reversion = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_motivoreversion { get { return _id_motivoreversion; } set { _id_motivoreversion = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public int meses_incumplidos { get { return _meses_incumplidos; } set { _meses_incumplidos = value; } }
            public bool anulado { get { return _anulado; } set { _anulado = value; } }
            public int anulado_id_usuario { get { return _anulado_id_usuario; } set { _anulado_id_usuario = value; } }
            public DateTime anulado_fecha { get { return _anulado_fecha; } set { _anulado_fecha = value; } }

            public string nombre_usuario { get { return _nombre_usuario; } }
            public string motivo_nombre { get { return _motivo_nombre; } }
            public string codigo_moneda { get { return _codigo_moneda; } }
            public int pagado_num_pagos { get { return _pagado_num_pagos; } }
            public decimal pagado_monto { get { return _pagado_monto; } }
            public string anulado_usuario { get { return _anulado_usuario; } }
            #endregion

            #region Constructores
            public tp_reversion(int Id_reversion)
            {
                _id_reversion = Id_reversion;
                RecuperarDatos();
            }

            public tp_reversion(int Id_contrato, int Id_motivoreversion)
            {
                _id_contrato = Id_contrato;
                _id_motivoreversion = Id_motivoreversion;
            }

            #endregion

            #region Métodos que NO requieren constructor



            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_reversion_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_reversion", DbType.Int32, _id_reversion);

                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_motivoreversion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_pago", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "meses_incumplidos", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);
                    db1.AddOutParameter(cmd, "anulado_id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "anulado_fecha", DbType.DateTime, 32);

                    db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                    db1.AddOutParameter(cmd, "motivo_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "codigo_moneda", DbType.String, 20);

                    db1.AddOutParameter(cmd, "pagado_num_pagos", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "pagado_monto", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "anulado_usuario", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _id_motivoreversion = (int)db1.GetParameterValue(cmd, "id_motivoreversion");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _id_pago = (int)db1.GetParameterValue(cmd, "id_pago");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _meses_incumplidos = (int)db1.GetParameterValue(cmd, "meses_incumplidos");
                    _anulado = (bool)db1.GetParameterValue(cmd, "anulado");
                    _anulado_id_usuario = (int)db1.GetParameterValue(cmd, "anulado_id_usuario");
                    _anulado_fecha = (DateTime)db1.GetParameterValue(cmd, "anulado_fecha");

                    _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                    _motivo_nombre = (string)db1.GetParameterValue(cmd, "motivo_nombre");
                    _codigo_moneda = (string)db1.GetParameterValue(cmd, "codigo_moneda");

                    _pagado_num_pagos = (int)db1.GetParameterValue(cmd, "pagado_num_pagos");
                    _pagado_monto = (decimal)(double)db1.GetParameterValue(cmd, "pagado_monto");
                    _anulado_usuario = (string)db1.GetParameterValue(cmd, "anulado_usuario");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_reversion_Insertar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_motivoreversion", DbType.Int32, _id_motivoreversion);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_reversion = (int)db1.ExecuteScalar(cmd);
                    if (_id_reversion > 0) { return true; } else { return false; }
                }
                catch { return false; }
            }

            public bool Reactivar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                if (this.anulado == false)
                {
                    try
                    {
                        DbCommand cmd = db1.GetStoredProcCommand("tp_reversion_Reactivar");
                        db1.AddInParameter(cmd, "id_reversion", DbType.Int32, _id_reversion);

                        db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                        db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                        db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
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
}