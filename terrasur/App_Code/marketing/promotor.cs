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
/// Summary description for promotor
/// </summary>
namespace terrasur
{
    public class promotor : usuario
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupoventa = 0;
        private string _nombre_grupoventa = "";
        private int _id_grupopromotor = 0;

        //Propiedades públicas
        public int id_grupoventa { get { return _id_grupoventa; } set { _id_grupoventa = value; } }
        public string nombre_grupoventa { get { return _nombre_grupoventa; } set { _nombre_grupoventa = value; } }
        public int id_grupopromotor { get { return _id_grupopromotor; } set { _id_grupopromotor = value; } }
        #endregion

        #region Constructores
        public promotor(int Id_promotor)
            : base(Id_promotor)
        {
            RecuperarDatosPromotor();
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaNoEliminado(int Id_grupoventa)
        {
            //[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario],[activo],[nombre_grupo]
            DbCommand cmd = db1.GetStoredProcCommand("promotor_ListaNoEliminado");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["promotor_codigo"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaActivoPorGrupo(int Id_grupoventa, int Id_grupopromotor)
        {
            //[id_grupopromotor],[id_usuario],[nombre_completo],[ci]
            DbCommand cmd = db1.GetStoredProcCommand("promotor_ListaActivoPorGrupo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, Id_grupopromotor);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        
        public static DataTable ListaGruposPorPromotor(int Id_promotor)
        {
            //[id_grupopromotor],[id_grupoventa],[nombre_grupoventa],[nombre_director],[fecha],[activo],[num_asignacion]
            DbCommand cmd = db1.GetStoredProcCommand("promotor_ListaGruposPorPromotor");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_promotor);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivoYAnteriores()
        {
            //[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario]
            DbCommand cmd = db1.GetStoredProcCommand("promotor_ListaActivoYAnteriores");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["promotor_codigo"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable ListaActivoOConVentas(int Id_grupoventa)
        {
            //[id_grupopromotor],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_ListaActivoOConVentas");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatosPromotor()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("promotor_RecuperarDatosPromotor");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, this.id_usuario);
                db1.AddOutParameter(cmd, "id_grupoventa", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_grupoventa", DbType.String, 100);
                db1.AddOutParameter(cmd, "id_grupopromotor", DbType.Int32, 32);
                db1.ExecuteNonQuery(cmd);
                _id_grupoventa = (int)db1.GetParameterValue(cmd, "id_grupoventa");
                _nombre_grupoventa = (string)db1.GetParameterValue(cmd, "nombre_grupoventa");
                _id_grupopromotor = (int)db1.GetParameterValue(cmd, "id_grupopromotor");
            }
            catch { }
        }
        #endregion

    }
}