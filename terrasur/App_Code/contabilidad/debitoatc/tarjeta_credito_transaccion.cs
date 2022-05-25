using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;

/// <summary>
/// Descripción breve de tarjeta_credito_transaccion
/// </summary>
namespace terrasur
{
    public class tarjeta_credito_transaccion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_transaccion = 0;
        private int _id_grupotransaccion = 0;
        private int _id_tarjetacreditocontrato = 0;

        //Propiedades públicas
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public int id_grupotransaccion { get { return _id_grupotransaccion; } set { _id_grupotransaccion = value; } }
        public int id_tarjetacreditocontrato { get { return _id_tarjetacreditocontrato; } set { _id_tarjetacreditocontrato = value; } }
        #endregion

        #region Constructores
        //public tarjeta_credito_transaccion(int Id_transaccion)
        //{
        //    _id_transaccion = Id_transaccion;
        //}
        public tarjeta_credito_transaccion(int Id_grupotransaccion, int Id_tarjetacreditocontrato)
        {
            _id_grupotransaccion = Id_grupotransaccion;
            _id_tarjetacreditocontrato = Id_tarjetacreditocontrato;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool PermitirDebito(int Id_grupotransaccion, int Id_tarjetacreditocontrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_PermitirDebito");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, Id_grupotransaccion);
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, Id_tarjetacreditocontrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public static bool Verificar(int Id_grupotransaccion, int Id_tarjetacreditocontrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_Verificar");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, Id_grupotransaccion);
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, Id_tarjetacreditocontrato);
                if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                else { return false; }
            }
            catch { return true; }
        }

        public static DataTable ListaTransacciones(int Id_tarjetacredito, int Id_grupotransaccion, string Tipo_transaccion)
        {
            //[id_transaccion],[id_transaccion_string],[id_establecimiento],[numero_tarjeta],[importe],[codigo_moneda],[fecha_vencimiento],
            //[nombre_cliente],[codigo_cliente],[periodo_deuda],[id_agrupacion],[id_agrupacion_string],[respuesta1],[codigo_error]
            //[num_contrato],[fecha_debito],[importe_sus],[respuesta2],[periodo_deuda2]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_ListaTransacciones");
            db1.AddInParameter(cmd, "id_tarjetacredito", DbType.Int32, Id_tarjetacredito);

            db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, Id_grupotransaccion);
            db1.AddInParameter(cmd, "tipo_transaccion", DbType.String, Tipo_transaccion);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static StringBuilder ListaTransacciones(int Id_grupotransaccion)
        {
            DataTable tabla = ListaTransacciones(0, Id_grupotransaccion, "todos");
            tabla.Columns.Remove("id_transaccion");
            tabla.Columns.Remove("id_agrupacion");
            tabla.Columns.Remove("respuesta1");
            tabla.Columns.Remove("codigo_error");
            tabla.Columns.Remove("num_contrato");
            tabla.Columns.Remove("fecha_debito");
            tabla.Columns.Remove("importe_sus");
            tabla.Columns.Remove("respuesta2");
            tabla.Columns.Remove("periodo_deuda2");
            tabla.Columns.Remove("importe_sus2");
            tabla.Columns.Remove("importe_bs2");

            StringBuilder str = new StringBuilder();
            for (int f = 0; f < tabla.Rows.Count; f++)
            {
                for (int c = 0; c < tabla.Columns.Count; c++)
                {
                    str.Append(tabla.Rows[f][c].ToString());
                    if (c < tabla.Columns.Count - 1) str.Append('|');
                    else str.Append("|;");
                }
                //if (f < tabla.Rows.Count - 1) str.Append(';');
            }
            return str;
        }

        public static DataTable ListaAceptados(int Id_grupotransaccion, int Tipo_fecha, DateTime Fecha_inicio, DateTime Fecha_fin)
        {
            //[id_transaccion],[fecha_debito],[numero],[importe_sus],[lote],[nombre_cliente],[id_agrupacion],[numero_tarjeta]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_ListaAceptados");
            db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, Id_grupotransaccion);
            db1.AddInParameter(cmd, "tipo_fecha", DbType.Int32, Tipo_fecha);
            db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
            db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaPorPeriodo(int Id_grupotransaccion, string Periodo_deuda_mes, string Periodo_deuda_anio)
        {
            //[id_tarjetacreditocontrato],[num_contrato],[estado],[permitir_debito]
            //[cuota_base],[fecha],[interes_fecha],[fecha_proximo],[saldo]
            //[monto_sus],[monto_bs],[fecha_debito],[num_tarjeta],[titular],[ultimo_debito]
            DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_ListaPorPeriodo");
            db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, Id_grupotransaccion);
            db1.AddInParameter(cmd, "periodo_deuda_mes", DbType.String, Periodo_deuda_mes);
            db1.AddInParameter(cmd, "periodo_deuda_anio", DbType.String, Periodo_deuda_anio);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_Insertar");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, _id_tarjetacreditocontrato);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                _id_transaccion = (int)db1.ExecuteScalar(cmd);
                if (_id_transaccion > 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public bool Eliminar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("tarjeta_credito_transaccion_Eliminar");
                db1.AddInParameter(cmd, "id_grupotransaccion", DbType.Int32, _id_grupotransaccion);
                db1.AddInParameter(cmd, "id_tarjetacreditocontrato", DbType.Int32, _id_tarjetacreditocontrato);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion

    }
}