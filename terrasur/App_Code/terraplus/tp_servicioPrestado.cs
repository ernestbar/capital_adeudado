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
/// Descripción breve de tp_servicioPrestado
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_servicioPrestado
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_servicioprestado = 0;
            private int _id_contrato = 0;
            private int _id_usuario = 0;
            private DateTime _fecha_registro = DateTime.Now;
            private DateTime _fecha_servicio = DateTime.Now;
            private string _num_contrato = "";
            private string _observacion = "";

            private string _nombre_usuario = "";

            //Propiedades públicas
            public int id_servicioprestado { get { return _id_servicioprestado; } set { _id_servicioprestado = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public DateTime fecha_registro { get { return _fecha_registro; } set { _fecha_registro = value; } }
            public DateTime fecha_servicio { get { return _fecha_servicio; } set { _fecha_servicio = value; } }
            public string num_contrato { get { return _num_contrato; } set { _num_contrato = value; } }
            public string observacion { get { return _observacion; } set { _observacion = value; } }

            public string nombre_usuario { get { return _nombre_usuario; } }
            #endregion

            #region Constructores
            public tp_servicioPrestado(int Id_servicioprestado)
            {
                _id_servicioprestado = Id_servicioprestado;
                RecuperarDatos();
            }

            public tp_servicioPrestado(int Id_contrato, DateTime Fecha_servicio, string Num_contrato, string Observacion)
            {
                _id_contrato = Id_contrato;
                _fecha_servicio = Fecha_servicio;
                _num_contrato = Num_contrato;
                _observacion = Observacion;
            }
            #endregion

            #region Métodos que NO requieren constructor
            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_servicioPrestado_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_servicioprestado", DbType.Int32, _id_servicioprestado);

                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha_registro", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fecha_servicio", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "num_contrato", DbType.String, 20);
                    db1.AddOutParameter(cmd, "observacion", DbType.String, 200);

                    db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _fecha_registro = (DateTime)db1.GetParameterValue(cmd, "fecha_registro");
                    _fecha_servicio = (DateTime)db1.GetParameterValue(cmd, "fecha_servicio");
                    _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                    _observacion = (string)db1.GetParameterValue(cmd, "observacion");

                    _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_servicioPrestado_Insertar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "fecha_servicio", DbType.DateTime, _fecha_servicio);
                    db1.AddInParameter(cmd, "num_contrato", DbType.String, _num_contrato);
                    db1.AddInParameter(cmd, "observacion", DbType.String, _observacion);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_servicioprestado = (int)db1.ExecuteScalar(cmd);
                    if (_id_servicioprestado > 0) { return true; } else { return false; }
                }
                catch { return false; }
            }

            #endregion

        }
    }
}