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
/// Summary description for ciclo_comercial
/// </summary>
namespace terrasur
{
    public class ciclo_comercial
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_ciclocomercial = 0;
        private int _id_usuario = 0;
        private DateTime _inicio = DateTime.Now;
        private DateTime _fin = DateTime.Now;

        //Propiedades públicas
        public int id_ciclocomercial { get { return _id_ciclocomercial; } set { _id_ciclocomercial = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime inicio { get { return _inicio; } set { _inicio = value; } }
        public DateTime fin { get { return _fin; } set { _fin = value; } }

        #endregion

        #region Constructores
        public ciclo_comercial(int Id_ciclocomercial)
        {
            _id_ciclocomercial = Id_ciclocomercial;
            RecuperarDatos();
        }
        public ciclo_comercial(DateTime Inicio, DateTime Fin)
        {
            _inicio = Inicio;
            _fin = Fin;
        }
        public ciclo_comercial(int Id_ciclocomercial, DateTime Inicio, DateTime Fin)
        {
            _id_ciclocomercial = Id_ciclocomercial;
            _inicio = Inicio;
            _fin = Fin;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool VerificarMismoCiclo(DateTime Fecha_referencia, DateTime Fecha_evaluacion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_VerificarMismoCiclo");
                db1.AddInParameter(cmd, "fecha_referencia", DbType.DateTime, Fecha_referencia);
                db1.AddInParameter(cmd, "fecha_evaluacion", DbType.DateTime, Fecha_evaluacion);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public static DataTable Lista()
        {
            //[id_ciclocomercial],[inicio],[fin]
            DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable Lista(bool para_opciones)
        {
            //[id_ciclocomercial],[inicio],[fin]
            DataTable tabla = ciclo_comercial.Lista();
            if (para_opciones == true && tabla.Rows.Count > 0)
            {
                if (((DateTime)tabla.Rows[tabla.Rows.Count - 1]["fin"]).Date < DateTime.Now.Date)
                {
                    DataRow ciclo_actual = tabla.NewRow();
                    ciclo_actual["id_ciclocomercial"] = 0;
                    ciclo_actual["inicio"] = (DateTime)tabla.Rows[tabla.Rows.Count - 1]["fin"];
                    ciclo_actual["fin"] = DateTime.Now;
                    tabla.Rows.Add(ciclo_actual);
                }
            }
            return tabla;
        }

        public static DataTable ListaReportes(bool Recientes_10)
        {
            //[id_ciclocomercial],[nombre]
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_ciclocomercial", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));

            ////Sin ciclo
            //if (Digitar_fecha == true)
            //{
            //    DataRow fila_sin_ciclo = tabla.NewRow();
            //    fila_sin_ciclo["id_ciclocomercial"] = 0;
            //    fila_sin_ciclo["nombre"] = "";
            //    tabla.Rows.Add(fila_sin_ciclo);
            //}

            //Se cargan los ciclos existentes
            //[id_ciclocomercial],[inicio],[fin]
            DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_ListaReportes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "recientes_10", DbType.Boolean, Recientes_10);
            DataTable tabla_ciclos = db1.ExecuteDataSet(cmd).Tables[0];
            foreach (DataRow fila_ciclo in tabla_ciclos.Rows)
            {
                DataRow fila = tabla.NewRow();
                fila["id_ciclocomercial"] = fila_ciclo["id_ciclocomercial"];
                fila["nombre"] = CicloString((DateTime)fila_ciclo["inicio"], (DateTime)fila_ciclo["fin"]);
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static string CicloString(int Id_ciclocomercial)
        {
            ciclo_comercial cicloObj = new ciclo_comercial(Id_ciclocomercial);
            return CicloString(cicloObj.inicio, cicloObj.fin);
        }
        public static string CicloString(DateTime Inicio, DateTime Fin)
        {
            if (Inicio.Year == Fin.Year)
            {
                if (Inicio.Month == Fin.Month)
                    return general.Capitalize(Inicio.ToString("MMMM")) + " " + Inicio.ToString("yyyy") + " (" + Inicio.ToString("dd MMM") + " - " + Fin.ToString("dd MMM") + ")";
                else return general.Capitalize(Inicio.ToString("MMMM")) + " - " + general.Capitalize(Fin.ToString("MMMM")) + " " + Fin.ToString("yyyy") + " (" + Inicio.ToString("dd MMM") + " - " + Fin.ToString("dd MMM") + ")";
            }
            else return general.Capitalize(Inicio.ToString("MMMM")) + " " + Inicio.ToString("yyyy") + " - " + general.Capitalize(Fin.ToString("MMMM")) + " " + Fin.ToString("yyyy").ToUpper() + " (" + Inicio.ToString("d") + " - " + Fin.ToString("d") + ")";
        }

        public static bool VerificarFechas(bool Inserta, int Id_ciclocomercial, DateTime Inicio, DateTime Fin)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_VerificarFechas");
                db1.AddInParameter(cmd, "inserta", DbType.Boolean, Inserta);
                db1.AddInParameter(cmd, "id_ciclocomercial", DbType.Int32, Id_ciclocomercial);
                db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
                db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static int VigentePorFecha(DateTime Fecha)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_VigentePorFecha");
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_RecuperarDatos");
                db1.AddInParameter(cmd, "id_ciclocomercial", DbType.Int32, _id_ciclocomercial);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "inicio", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "fin", DbType.DateTime, 200);
                db1.ExecuteNonQuery(cmd);
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _inicio = (DateTime)db1.GetParameterValue(cmd, "inicio");
                _fin = (DateTime)db1.GetParameterValue(cmd, "fin");
            }
            catch { }
        }
        public bool Insertar(int context_id_usuario)
        {
            if (VerificarFechas(true, 0, _inicio, _fin) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_Insertar");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "inicio", DbType.DateTime, _inicio);
                    db1.AddInParameter(cmd, "fin", DbType.DateTime, _fin);
                    _id_ciclocomercial = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }
        public bool Actualizar(int context_id_usuario)
        {
            if (VerificarFechas(false, _id_ciclocomercial, _inicio, _fin) == false)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_Actualizar");
                    db1.AddInParameter(cmd, "id_ciclocomercial", DbType.Int32, _id_ciclocomercial);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "inicio", DbType.DateTime, _inicio);
                    db1.AddInParameter(cmd, "fin", DbType.DateTime, _fin);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }
        public bool Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("ciclo_comercial_Eliminar");
                db1.AddInParameter(cmd, "id_ciclocomercial", DbType.Int32, _id_ciclocomercial);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}