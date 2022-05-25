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
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Descripción breve de seguro_provida
/// </summary>
namespace terrasur
{
    public class seguro_provida
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_seguro = 0;
        private int _id_contrato = 0;
        private int _id_usuario = 0;
        private int _numero = 0;
        private DateTime _fecha = DateTime.Now;

        private string _num_contrato = "";
        private string _nombre_usuario = "";

        //Propiedades públicas
        public int id_seguro { get { return _id_seguro; } set { _id_seguro = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int numero { get { return _numero; } set { _numero = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }

        public string num_contrato { get { return _num_contrato; } }
        public string nombre_usuario { get { return _nombre_usuario; } }
        #endregion

        #region Constructores
        public seguro_provida(int Id_contrato)
        {
            _id_contrato = Id_contrato;
            RecuperarDatos();
        }

        public seguro_provida(int Id_contrato, int Id_usuario, int Numero)
        {
            _id_contrato = Id_contrato;
            _id_usuario = Id_usuario;
            _numero = Numero;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(int Id_contrato, int Id_cliente)
        {
            //[id_contrato],[num_contrato],[estado],[num_seguro],[fecha_registro],[usuario],[porcentaje_seguro],[cliente],[tipo_contrato],[lote]
            DbCommand cmd = db1.GetStoredProcCommand("seguro_provida_Lista");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static bool VerificarUtilizado(int Id_contrato, int Numero)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("seguro_provida_Verificar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "numero", DbType.Int32, Numero);
                if ((int)db1.ExecuteScalar(cmd) == 0) return false;
                else return true;
            }
            catch { return true; }
        }

        public static string Num_contrato_por_seguro(int Id_seguro, int Num_seguro, bool Devolver_id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("seguro_provida_Num_contrato");
                db1.AddInParameter(cmd, "id_seguro", DbType.Int32, Id_seguro);
                db1.AddInParameter(cmd, "num_seguro", DbType.Int32, Num_seguro);
                db1.AddInParameter(cmd, "devolver_id_contrato", DbType.Boolean, Devolver_id_contrato);
                return db1.ExecuteScalar(cmd).ToString();
            }
            catch
            {
                if (Devolver_id_contrato == true) return "0";
                else return "";
            }
        }

        public static DataTable ReporteCobroSeguro(bool Pago_mensual, DateTime Seguro_inicio, DateTime Seguro_fin, DateTime Pago_inicio, DateTime Pago_fin, bool Cuota_inicial, DateTime Cuota_inicial_fecha_inicio, DateTime Cuota_inicial_fecha_fin, string Id_negocio, int Estado_vigente, int Id_moneda, bool Consolidado)
        {
            //[tipo_pago],[tipo_contrato],[num],[reg],[ag],[num_contrato],[num_poliza],[tipo_contrato_codigo],[cliente],[direccion]
            //[fecha_cuota_inicial],[edad],[fecha_nacimiento],[ci],[lugar_cedula]
            //[saldo_anterior],[pago_fecha],[tasa_seguro],[pago_monto],[pago_capital],[pago_interes],[pago_seguro],[pago_saldo]
            //[codigo_moneda],[tipo_cambio]
            //ORDENAR POR: [tipo_pago] DESC,[tipo_contrato] DESC,[num_contrato]
            DataTable tabla;
            if (Consolidado == false) { tabla = ReporteCobroSeguro_original(Pago_mensual, Seguro_inicio, Seguro_fin, Pago_inicio, Pago_fin, Cuota_inicial, Cuota_inicial_fecha_inicio, Cuota_inicial_fecha_fin, Id_negocio, Estado_vigente, Id_moneda); }
            else
            {
                string codigo_moneda = new moneda(Id_moneda).codigo;
                DataTable tabla_sus; DataTable tabla_bs;
                if (codigo_moneda == "$us")
                {
                    int Id_segunda_moneda = new moneda("Bs").id_moneda;
                    tabla_sus = ReporteCobroSeguro_original(Pago_mensual, Seguro_inicio, Seguro_fin, Pago_inicio, Pago_fin, Cuota_inicial, Cuota_inicial_fecha_inicio, Cuota_inicial_fecha_fin, Id_negocio, Estado_vigente, Id_moneda);
                    tabla_bs = ReporteCobroSeguro_original(Pago_mensual, Seguro_inicio, Seguro_fin, Pago_inicio, Pago_fin, Cuota_inicial, Cuota_inicial_fecha_inicio, Cuota_inicial_fecha_fin, Id_negocio, Estado_vigente, Id_segunda_moneda);
                }
                else
                {
                    int Id_segunda_moneda = new moneda("$us").id_moneda;
                    tabla_sus = ReporteCobroSeguro_original(Pago_mensual, Seguro_inicio, Seguro_fin, Pago_inicio, Pago_fin, Cuota_inicial, Cuota_inicial_fecha_inicio, Cuota_inicial_fecha_fin, Id_negocio, Estado_vigente, Id_segunda_moneda);
                    tabla_bs = ReporteCobroSeguro_original(Pago_mensual, Seguro_inicio, Seguro_fin, Pago_inicio, Pago_fin, Cuota_inicial, Cuota_inicial_fecha_inicio, Cuota_inicial_fecha_fin, Id_negocio, Estado_vigente, Id_moneda);
                }
                tabla = general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "saldo_anterior,pago_monto,pago_capital,pago_interes,pago_seguro,pago_saldo", false, false, "", "tipo_pago DESC,tipo_contrato DESC,num_contrato");
            }

            //Se realiza la numeración
            if (tabla.Rows.Count > 0)
            {
                string tipo_p = tabla.Rows[0]["tipo_pago"].ToString();
                int contador = 1;
                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    if (tabla.Rows[j]["tipo_pago"].ToString() == tipo_p)
                    {
                        tabla.Rows[j]["num"] = contador;
                        contador += 1;
                    }
                    else
                    {
                        tipo_p = tabla.Rows[j]["tipo_pago"].ToString();
                        contador = 1;
                        tabla.Rows[j]["num"] = contador;
                        contador += 1;
                    }
                }
            }

            return tabla;
        }
        private static DataTable ReporteCobroSeguro_original(bool Pago_mensual, DateTime Seguro_inicio, DateTime Seguro_fin, DateTime Pago_inicio, DateTime Pago_fin, bool Cuota_inicial, DateTime Cuota_inicial_fecha_inicio, DateTime Cuota_inicial_fecha_fin, string Id_negocio, int Estado_vigente, int Id_moneda)
        {
            DbCommand cmd = db1.GetStoredProcCommand("seguro_provida_ReporteCobroSeguro");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "pago_mensual", DbType.Boolean, Pago_mensual);
            db1.AddInParameter(cmd, "seguro_inicio", DbType.DateTime, Seguro_inicio);
            db1.AddInParameter(cmd, "seguro_fin", DbType.DateTime, Seguro_fin);
            db1.AddInParameter(cmd, "pago_inicio", DbType.DateTime, Pago_inicio);
            db1.AddInParameter(cmd, "pago_fin", DbType.DateTime, Pago_fin);

            db1.AddInParameter(cmd, "cuota_inicial", DbType.Boolean, Cuota_inicial);
            db1.AddInParameter(cmd, "cuota_inicial_fecha_inicio", DbType.DateTime, Cuota_inicial_fecha_inicio);
            db1.AddInParameter(cmd, "cuota_inicial_fecha_fin", DbType.DateTime, Cuota_inicial_fecha_fin);

            db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
            db1.AddInParameter(cmd, "estado_vigente", DbType.Int32, Estado_vigente);
            db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("seguro_provida_RecuperarDatos");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddOutParameter(cmd, "id_seguro", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "numero", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);

                db1.AddOutParameter(cmd, "num_contrato", DbType.String, 32);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);
                
                db1.ExecuteNonQuery(cmd);

                _id_seguro = (int)db1.GetParameterValue(cmd, "id_seguro");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _numero = (int)db1.GetParameterValue(cmd, "numero");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");

                _num_contrato = db1.GetParameterValue(cmd, "num_contrato").ToString();
                _nombre_usuario = db1.GetParameterValue(cmd, "nombre_usuario").ToString();
            }
            catch { }
        }

        public bool Asignar(bool Registrar)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("seguro_provida_Asignar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario);
                db1.AddInParameter(cmd, "numero", DbType.Int32, _numero);
                db1.AddInParameter(cmd, "registrar", DbType.Boolean, Registrar);

                _id_seguro = (int)db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        #endregion
    }
}