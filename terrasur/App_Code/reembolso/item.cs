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
/// Descripción breve de item
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class item
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_item = 0;
            private string _codigo = "";
            private string _nombre = "";
            private bool _incremento = false;
            private bool _traspaso = false;
            private bool _traspaso_por_defecto = false;
            private bool _devolucion = false;
            private bool _devolucion_por_defecto = false;

            private int _num_reembolsos = 0;
            
            //Propiedades públicas
            public int id_item { get { return _id_item; } set { _id_item = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            public bool incremento { get { return _incremento; } set { _incremento = value; } }
            public bool traspaso { get { return _traspaso; } set { _traspaso = value; } }
            public bool traspaso_por_defecto { get { return _traspaso_por_defecto; } set { _traspaso_por_defecto = value; } }
            public bool devolucion { get { return _devolucion; } set { _devolucion = value; } }
            public bool devolucion_por_defecto { get { return _devolucion_por_defecto; } set { _devolucion_por_defecto = value; } }

            public int num_reembolsos { get { return _num_reembolsos; } }
            #endregion

            #region Constructores
            public item(int Id_item)
            {
                _id_item = Id_item;
                RecuperarDatos();
            }

            public item(string Codigo, string Nombre, bool Incremento, bool Traspaso, bool Traspaso_por_defecto, bool Devolucion, bool Devolucion_por_defecto)
            {
                _codigo = Codigo;
                _nombre = Nombre;
                _incremento = Incremento;
                _traspaso = Traspaso;
                _traspaso_por_defecto = Traspaso_por_defecto;
                _devolucion = Devolucion;
                _devolucion_por_defecto = Devolucion_por_defecto;
            }

            public item(int Id_item, string Codigo, string Nombre, bool Incremento, bool Traspaso, bool Traspaso_por_defecto, bool Devolucion, bool Devolucion_por_defecto)
            {
                _id_item = Id_item;
                _codigo = Codigo;
                _nombre = Nombre;
                _incremento = Incremento;
                _traspaso = Traspaso;
                _traspaso_por_defecto = Traspaso_por_defecto;
                _devolucion = Devolucion;
                _devolucion_por_defecto = Devolucion_por_defecto;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_item],[codigo],[nombre],[tipo],[traspaso],[devolucion],[num_reembolsos]
                DbCommand cmd = db1.GetStoredProcCommand("re_item_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaParaDll(bool Traspaso)
            {
                //[id_item],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("re_item_ListaParaDll");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "traspaso", DbType.Boolean, Traspaso);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaPredeterminada(bool Traspaso, int Id_contrato, DateTime Fecha)
            {
                //[id_item],[preliminar]
                DbCommand cmd = db1.GetStoredProcCommand("re_item_ListaPredeterminada");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "traspaso", DbType.Boolean, Traspaso);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static decimal MontoPredeterminadoPorContrato(int Id_item, int Id_contrato, DateTime Fecha)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_MontoPredeterminadoPorContrato");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                    return (decimal)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static decimal MontoPredeterminadoPorReembolso(int Id_item, int Id_reembolso)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_MontoPredeterminadoPorReembolso");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    return (decimal)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }


            public static bool VerificarCodigo(bool Insertar, int Id_item, string Codigo)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_VerificarCodigo");
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);
                    db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);

                    if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                    else { return false; }
                }
                catch { return true; }
            }

            public static bool VerificarNombre(bool Insertar, int Id_item, string Nombre)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_VerificarNombre");
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);
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
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, _id_item);

                    db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "incremento", DbType.Boolean, 32);
                    db1.AddOutParameter(cmd, "traspaso", DbType.Boolean, 32);
                    db1.AddOutParameter(cmd, "traspaso_por_defecto", DbType.Boolean, 32);
                    db1.AddOutParameter(cmd, "devolucion", DbType.Boolean, 32);
                    db1.AddOutParameter(cmd, "devolucion_por_defecto", DbType.Boolean, 32);

                    db1.AddOutParameter(cmd, "num_reembolsos", DbType.Int32, 32);

                    db1.ExecuteNonQuery(cmd);

                    _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                    _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                    _incremento = (bool)db1.GetParameterValue(cmd, "incremento");
                    _traspaso = (bool)db1.GetParameterValue(cmd, "traspaso");
                    _traspaso_por_defecto = (bool)db1.GetParameterValue(cmd, "traspaso_por_defecto");
                    _devolucion = (bool)db1.GetParameterValue(cmd, "devolucion");
                    _devolucion_por_defecto = (bool)db1.GetParameterValue(cmd, "devolucion_por_defecto");

                    _num_reembolsos = (int)db1.GetParameterValue(cmd, "num_reembolsos");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_Insertar");
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "incremento", DbType.Boolean, _incremento);
                    db1.AddInParameter(cmd, "traspaso", DbType.Boolean, _traspaso);
                    db1.AddInParameter(cmd, "traspaso_por_defecto", DbType.Boolean, _traspaso_por_defecto);
                    db1.AddInParameter(cmd, "devolucion", DbType.Boolean, _devolucion);
                    db1.AddInParameter(cmd, "devolucion_por_defecto", DbType.Boolean, _devolucion_por_defecto);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_item = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Actualizar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_Actualizar");
                    db1.AddInParameter(cmd, "id_item", DbType.String, _id_item);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "incremento", DbType.Boolean, _incremento);
                    db1.AddInParameter(cmd, "traspaso", DbType.Boolean, _traspaso);
                    db1.AddInParameter(cmd, "traspaso_por_defecto", DbType.Boolean, _traspaso_por_defecto);
                    db1.AddInParameter(cmd, "devolucion", DbType.Boolean, _devolucion);
                    db1.AddInParameter(cmd, "devolucion_por_defecto", DbType.Boolean, _devolucion_por_defecto);

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
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_Eliminar");
                    db1.AddInParameter(cmd, "id_item", DbType.String, _id_item);

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