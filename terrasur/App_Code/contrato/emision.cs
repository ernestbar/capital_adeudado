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
/// Descripción breve de emision
/// </summary>
namespace terrasur
{
    namespace emDoc
    {
        public class emision
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_emision = 0;
            private int _id_tipodocumento = 0;
            private int _id_contrato = 0;
            private int _id_usuario = 0;
            private int _id_cliente = 0;
            private string _cliente_nombre = "";
            private string _cliente_ci = "";
            private bool _para_cliente = false;
            private DateTime _fecha = DateTime.Now;

            private string _tipoDocumento_codigo = "";

            //Propiedades públicas
            public int id_emision { get { return _id_emision; } set { _id_emision = value; } }
            public int id_tipodocumento { get { return _id_tipodocumento; } set { _id_tipodocumento = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
            public string cliente_nombre { get { return _cliente_nombre; } set { _cliente_nombre = value; } }
            public string cliente_ci { get { return _cliente_ci; } set { _cliente_ci = value; } }
            public bool para_cliente { get { return _para_cliente; } set { _para_cliente = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }

            public string tipoDocumento_codigo { get { return _tipoDocumento_codigo; } set { _tipoDocumento_codigo = value; } }
            #endregion

            #region Constructores
            public emision(string TipoDocumento_codigo, int Id_contrato, int Id_usuario, int Id_cliente, string Cliente_nombre, string Cliente_ci)
            {
                _tipoDocumento_codigo = TipoDocumento_codigo;
                _id_contrato = Id_contrato;
                _id_usuario = Id_usuario;
                _id_cliente = Id_cliente;
                _cliente_nombre = Cliente_nombre.Trim();
                _cliente_ci = Cliente_ci.Trim();
                if (_id_cliente > 0 || _cliente_nombre != "" || _cliente_ci != "") { _para_cliente = true; }
                else { _para_cliente = false; }
            }

            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(DateTime Fecha_inicio, DateTime Fecha_fin, string TipoDocumento_codigo
                , int Id_usuario, string Num_contrato, string Cliente, int Para_cliente)
            {
                //[id_emision],[fecha],[usuario],[tipo_documento],[tipo_emision],[num_contrato],[cliente]
                DbCommand cmd = db1.GetStoredProcCommand("em_emision_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
                db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
                db1.AddInParameter(cmd, "tipoDocumento_codigo", DbType.String, TipoDocumento_codigo);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1.AddInParameter(cmd, "cliente", DbType.String, Cliente);
                db1.AddInParameter(cmd, "para_cliente", DbType.Int32, Para_cliente);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaPorContrato(int Id_contrato, string TipoDocumento_codigo, int Para_cliente)
            {
                //[id_emision],[fecha],[usuario],[tipo_documento],[cliente]
                DbCommand cmd = db1.GetStoredProcCommand("em_emision_ListaPorContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "tipoDocumento_codigo", DbType.String, TipoDocumento_codigo);
                db1.AddInParameter(cmd, "para_cliente", DbType.Int32, Para_cliente);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaUsuarios()
            {
                //[id_usuario],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("em_emision_ListaUsuarios");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static DataTable ListaTipoDocumento()
            {
                //[id_tipodocumento],[codigo],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("em_emision_ListaTipoDocumento");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static DataTable ListaTitulares(int Id_contrato)
            {
                //[id_cliente],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("em_emision_ListaTitulares");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static string NombreTipoDocumentoPorCodigo(string Codigo_tipo_documento)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("em_emision_NombreTipoDocumentoPorCodigo");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "codigo", DbType.String, Codigo_tipo_documento);
                    return db1.ExecuteScalar(cmd).ToString();
                }
                catch { return ""; }
            }

            public static bool Verificar(string TipoDocumento_codigo, int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("em_emision_Verificar");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "tipoDocumento_codigo", DbType.String, TipoDocumento_codigo);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    if ((int)db1.ExecuteScalar(cmd) == 0) { return false; }
                    else { return true; }
                }
                catch { return false; }
            }
            #endregion

            #region Métodos que requieren constructor
            public bool Registrar()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("em_emision_Registrar");
                    db1.AddInParameter(cmd, "tipoDocumento_codigo", DbType.String, _tipoDocumento_codigo);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                    db1.AddInParameter(cmd, "cliente_nombre", DbType.String, _cliente_nombre);
                    db1.AddInParameter(cmd, "cliente_ci", DbType.String, _cliente_ci);
                    db1.AddInParameter(cmd, "para_cliente", DbType.Boolean, _para_cliente);
                    _id_emision = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion
        }
    }
}