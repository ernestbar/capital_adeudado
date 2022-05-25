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
/// Summary description for dpr
/// </summary>
namespace terrasur
{
    public class dpr
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_dpr = 0;
        private int _id_usuario = 0;
        private string _codigo = "";
        private string _nombre = "";
        private bool _inicial = false;
        private bool _liquidable = false;
        private bool _activo = true;

        private int _num_pagos = 0;

        //Propiedades públicas
        public int id_dpr { get { return _id_dpr; } set { _id_dpr = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public bool inicial { get { return _inicial; } set { _inicial = value; } }
        public bool liquidable { get { return _liquidable; } set { _liquidable = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_pagos { get { return _num_pagos; } }
        #endregion

        #region Constructores
        public dpr(int Id_dpr)
        {
            _id_dpr = Id_dpr;
            RecuperarDatos();
        }
        public dpr(string Codigo, string Nombre,bool Inicial, bool Liquidable, bool Activo)
        {
            _codigo = Codigo;
            _nombre = Nombre;
            _inicial = Inicial;
            _liquidable = Liquidable;
            _activo = Activo;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista()
        {
            //[id_dpr],[id_usuario],[codigo],[nombre],[inicial],[liquidable],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("dpr_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivo(bool Cuota_inicial)
        {
            //[id_dpr],[codigo],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("dpr_ListaActivo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "inicial", DbType.Boolean, Cuota_inicial);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static bool VerificarCodigoNombre(bool Inserta, int Id_dpr, string Codigo, string Nombre)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("dpr_VerificarCodigoNombre");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_dpr", DbType.Int32, Id_dpr);
                db1.AddInParameter(cmd, "codigo", DbType.String, Codigo);
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
                DbCommand cmd = db1.GetStoredProcCommand("dpr_RecuperarDatos");
                db1.AddInParameter(cmd, "id_dpr", DbType.Int32, _id_dpr);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "codigo", DbType.String, 50);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 100);
                db1.AddOutParameter(cmd, "inicial", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "liquidable", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_pagos", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _inicial = (bool)db1.GetParameterValue(cmd, "inicial");
                _liquidable = (bool)db1.GetParameterValue(cmd, "liquidable");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");


                _num_pagos = (int)db1.GetParameterValue(cmd, "num_pagos");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(true, 0, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("dpr_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "inicial", DbType.Boolean, _inicial);
                    db1.AddInParameter(cmd, "liquidable", DbType.Boolean, _liquidable);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    _id_dpr = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }

        }


        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarCodigoNombre(false, _id_dpr, _codigo, _nombre) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("dpr_Actualizar");
                    db1.AddInParameter(cmd, "id_dpr", DbType.Int32, _id_dpr);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                    db1.AddInParameter(cmd, "inicial", DbType.Boolean, _inicial);
                    db1.AddInParameter(cmd, "liquidable", DbType.Boolean, _liquidable);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, _activo);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            if (this._num_pagos == 0)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("dpr_Eliminar");
                    db1.AddInParameter(cmd, "id_dpr", DbType.Int32, _id_dpr);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
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