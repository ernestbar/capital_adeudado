﻿using System;
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
/// Descripción breve de tp_estado
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_estado
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_estado = 0;
            private string _codigo = "";
            private string _nombre = "";

            //Propiedades públicas
            public int id_estado { get { return _id_estado; } set { _id_estado = value; } }
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            #endregion

            #region Constructores
            public tp_estado(int Id_estado)
            {
                _id_estado = Id_estado;
                _codigo = "";
                RecuperarDatos();
            }
            public tp_estado(string Codigo)
            {
                _id_estado = 0;
                _codigo = Codigo;
                RecuperarDatos();
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista()
            {
                //[id_estado],[codigo],[nombre]
                DbCommand cmd = db1.GetStoredProcCommand("tp_estado_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_estado_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_estado0", DbType.Int32, _id_estado);
                    db1.AddInParameter(cmd, "codigo0", DbType.String, _codigo);

                    db1.AddOutParameter(cmd, "id_estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "codigo", DbType.String, 20);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 50);

                    db1.ExecuteNonQuery(cmd);

                    _id_estado = (int)db1.GetParameterValue(cmd, "id_estado");
                    _codigo = (string)db1.GetParameterValue(cmd, "codigo");
                    _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                }
                catch { }
            }

            #endregion


        }
    }
}