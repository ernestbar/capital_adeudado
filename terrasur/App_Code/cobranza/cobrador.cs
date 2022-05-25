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
/// Summary description for cobrador
/// </summary>
/// 
namespace terrasur
{
    public class cobrador : usuario
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _num_contratos_asignados = 0;
        private int _num_dosificaciones = 0;


        //Propiedades públicas
        public int num_contratos_asignados { get { return _num_contratos_asignados; } set { _num_contratos_asignados = value; } }
        public int num_dosificaciones { get { return _num_dosificaciones; } set { _num_dosificaciones = value; } }

        #endregion


        #region Constructores
        public cobrador(int Id_cobrador)
            : base(Id_cobrador)
        {
            RecuperarDatosCobrador();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaNoEliminado()
        {
            //[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario],[activo]
            DbCommand cmd = db1.GetStoredProcCommand("cobrador_ListaNoEliminado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["cobrador_codigo"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        //public static DataTable ListaActivoYAnteriores()
        //{
        //    //[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario]
        //    DbCommand cmd = db1.GetStoredProcCommand("promotor_ListaActivoYAnteriores");
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["cobrador_codigo"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatosCobrador()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("cobrador_RecuperarDatosCobrador");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, this.id_usuario);
                db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["cobrador_codigo"]);
                db1.AddOutParameter(cmd, "num_contratos_asignados", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "num_dosificaciones", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _num_contratos_asignados = (int)db1.GetParameterValue(cmd, "num_contratos_asignados");
                _num_dosificaciones = (int)db1.GetParameterValue(cmd, "num_dosificaciones");
            }
            catch { }
        }
        #endregion
    }
}