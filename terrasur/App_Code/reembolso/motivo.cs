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
/// Descripción breve de re_motivo
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class motivo
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_motivo = 0;
            private string _codigo = "";
            private string _nombre = "";
            private bool _activo = false;

            private int _num_traspasos = 0;
            private int _num_devoluciones = 0;

            //Propiedades públicas
            public int id_motivo { get { return _id_motivo; } set { _id_motivo = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            public bool activo { get { return _activo; } set { _activo = value; } }

            public int num_traspasos { get { return _num_traspasos; } }
            public int num_devoluciones { get { return _num_devoluciones; } }
            #endregion

            #region Constructores
            public motivo(int Id_motivo)
            {
                _id_motivo = Id_motivo;
                RecuperarDatos();
            }

            public motivo(string Codigo,string Nombre,bool Activo )
            {
                _codigo = Codigo;
                _nombre = Nombre;
                _activo = Activo;
            }

            public motivo(int Id_motivo, string Codigo, string Nombre, bool Activo)
            {
                _id_motivo = Id_motivo;
                _codigo = Codigo;
                _nombre = Nombre;
                _activo = Activo;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_motivo],[codigo],[nombre],[activo],[num_traspasos],[num_devoluciones]
                DbCommand cmd = db1.GetStoredProcCommand("re_motivo_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaParaDll(int Id_motivo)
            {
                //[id_motivo],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("re_motivo_ListaParaDll");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_motivo", DbType.Int32, Id_motivo);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static bool VerificarCodigo(bool Insertar, int Id_motivo, string Codigo)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_motivo_VerificarCodigo");
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_motivo", DbType.Int32, Id_motivo);
                    db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);

                    if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                    else { return false; }
                }
                catch { return true; }
            }

            public static bool VerificarNombre(bool Insertar, int Id_motivo, string Nombre)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_motivo_VerificarNombre");
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_motivo", DbType.Int32, Id_motivo);
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
                    DbCommand cmd = db1.GetStoredProcCommand("re_motivo_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_motivo", DbType.Int32, _id_motivo);

                    db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                    db1.AddOutParameter(cmd, "num_traspasos", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "num_devoluciones", DbType.Int32, 32);
                    
                    db1.ExecuteNonQuery(cmd);

                    _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                    _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                    _activo = (bool)db1.GetParameterValue(cmd, "activo");

                    _num_traspasos = (int)db1.GetParameterValue(cmd, "num_traspasos");
                    _num_devoluciones = (int)db1.GetParameterValue(cmd, "num_devoluciones");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_motivo_Insertar");
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_motivo = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Actualizar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_motivo_Actualizar");
                    db1.AddInParameter(cmd, "id_motivo", DbType.String, _id_motivo);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Eliminar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_motivo_Eliminar");
                    db1.AddInParameter(cmd, "id_motivo", DbType.String, _id_motivo);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion

        }
    }
}