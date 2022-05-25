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
/// Descripción breve de s_horario
/// </summary>
namespace terrasur
{
    namespace sintesis
    {
        public class s_horario
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private string _codigo = "";//lun_vie,sab,dom
            private DateTime _inicio = DateTime.Now;
            private DateTime _fin = DateTime.Now;
            
            //Propiedades públicas
            public string codigo { get { return _codigo; } set { _codigo = value; } }
            public DateTime inicio { get { return _inicio; } set { _inicio = value; } }
            public DateTime fin { get { return _fin; } set { _fin = value; } }
            #endregion

            #region Constructores
            public s_horario(string Codigo)
            {
                _codigo = Codigo;
                RecuperarDatos();
            }

            public s_horario(string Codigo, DateTime Inicio, DateTime Fin)
            {
                _codigo = Codigo;
                _inicio = Inicio;
                _fin = Fin;
            }
            #endregion

            #region Métodos que NO requieren constructor

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_horario_RecuperarDatos");
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddOutParameter(cmd, "inicio", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fin", DbType.DateTime, 32);

                    db1.ExecuteNonQuery(cmd);

                    _inicio = (DateTime)db1.GetParameterValue(cmd, "inicio");
                    _fin = (DateTime)db1.GetParameterValue(cmd, "fin");
                }
                catch { }
            }

            public bool Actualizar(int context_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("s_horario_Actualizar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, _codigo);
                    db1.AddInParameter(cmd, "inicio", DbType.DateTime, _inicio);
                    db1.AddInParameter(cmd, "fin", DbType.DateTime, _fin);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion

        }
    }
}