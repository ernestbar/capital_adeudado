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
/// Summary description for grupo_promotor
/// </summary>
namespace terrasur
{
    public class grupo_promotor
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_grupopromotor = 0;
        private int _id_grupoventa = 0;
        private int _id_promotor = 0;
        private DateTime _fecha = DateTime.Now;
        private bool _activo = false;

        private int _num_asignacion = 0;
        private string _nombre_promotor = "";
        private string _nombre_grupo = "";

        //Propiedades públicas
        public int id_grupopromotor { get { return _id_grupopromotor; } set { _id_grupopromotor = value; } }
        public int id_grupoventa { get { return _id_grupoventa; } set { _id_grupoventa = value; } }
        public int id_promotor { get { return _id_promotor; } set { _id_promotor = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool activo { get { return _activo; } set { _activo = value; } }

        public int num_asignacion { get { return _num_asignacion; } }
        public string nombre_promotor { get { return _nombre_promotor; } }
        public string nombre_grupo { get { return _nombre_grupo; } }
        #endregion

        #region Constructores
        public grupo_promotor(int Id_grupopromotor)
        {
            _id_grupopromotor = Id_grupopromotor;
            RecuperarDatos();
        }
        public grupo_promotor(int Id_grupoventa, int Id_promotor)
        {
            _id_grupoventa = Id_grupoventa;
            _id_promotor = Id_promotor;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool Verificar(int Id_grupoventa, int Id_promotor)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_Verificar");
                db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_promotor);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static DataTable ListaPromotorPorGrupo(int Id_grupoventa, string Ids_promotores)
        {
            //[id_grupopromotor],[id_usuario],[nombre_completo],[ci],[nombre_usuario]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_ListaPromotorPorGrupo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
            if (Id_grupoventa == 0 && Ids_promotores != null && Ids_promotores != "")
            {
                string[] ids_lista = Ids_promotores.TrimEnd(',').Split(',');
                for (int j = 0; j < ids_lista.Length; j++)
                {
                    usuario usrObj = new usuario(Int32.Parse(ids_lista[j]));
                    DataRow nueva_fila = tabla.NewRow();
                    nueva_fila["id_grupopromotor"] = 0;
                    nueva_fila["id_usuario"] = usrObj.id_usuario;
                    nueva_fila["nombre_completo"] = usrObj.paterno + ' ' + usrObj.materno + ' ' + usrObj.nombres;
                    nueva_fila["ci"] = usrObj.ci;
                    nueva_fila["nombre_usuario"] = usrObj.nombre_usuario;
                    tabla.Rows.Add(nueva_fila);
                }
            }
            return tabla;
        }
        public static DataTable ListaPromotorSinGrupo(int Id_grupoventa, string Ids_promotores)
        {
            //[id_usuario],[nombre_completo],[ci],[nombre_usuario]
            DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_ListaPromotorSinGrupo");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, Id_grupoventa);
            db1.AddInParameter(cmd, "codigo_rol", DbType.String, ConfigurationManager.AppSettings["promotor_codigo"]);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            if (Ids_promotores != null && Ids_promotores != "")
            {
                string[] ids_lista = Ids_promotores.TrimEnd(',').Split(',');
                for (int j = 0; j < ids_lista.Length; j++)
                    for (int k = tabla.Rows.Count - 1; k >= 0; k--)
                        if (tabla.Rows[k]["id_usuario"].ToString() == ids_lista[j])
                            tabla.Rows.RemoveAt(k);
            }
            return tabla;
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_RecuperarDatos");
                db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, _id_grupopromotor);
                db1.AddOutParameter(cmd, "id_grupoventa", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_promotor", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "activo", DbType.Boolean, 32);

                db1.AddOutParameter(cmd, "num_asignacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_promotor", DbType.String, 300);
                db1.AddOutParameter(cmd, "nombre_grupo", DbType.String, 100);

                db1.ExecuteNonQuery(cmd);
                _id_grupoventa = (int)db1.GetParameterValue(cmd, "id_grupoventa");
                _id_promotor = (int)db1.GetParameterValue(cmd, "id_promotor");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _activo = (bool)db1.GetParameterValue(cmd, "activo");

                _num_asignacion = (int)db1.GetParameterValue(cmd, "num_asignacion");
                _nombre_promotor = (string)db1.GetParameterValue(cmd, "nombre_promotor");
                _nombre_grupo = (string)db1.GetParameterValue(cmd, "nombre_grupo");
            }
            catch { }
        }

        public bool Insertar()
        {
            if (Verificar(_id_grupoventa, _id_promotor) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_Insertar");
                    db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, _id_grupoventa);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_promotor);
                    _id_grupopromotor = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }

        public bool Eliminar()
        {
            if (Verificar(_id_grupoventa, _id_promotor) == true)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("grupo_promotor_Eliminar");
                    db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, _id_grupopromotor);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return true; }
        }
        #endregion
    }
}