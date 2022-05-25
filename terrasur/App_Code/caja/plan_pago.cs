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
/// Summary description for plan_pago
/// </summary>
namespace terrasur
{
    public class plan_pago
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_planpago = 0;
        private int _id_contrato = 0;
        private int _id_pago = 0;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;
        private bool _vigente = false;
        private int _num_cuotas = 0;
        private decimal _seguro = 0;
        private decimal _mantenimiento_sus = 0;
        private decimal _interes_corriente = 0;
        private decimal _interes_penal = 0;
        private decimal _cuota_base = 0;
        private DateTime _fecha_inicio_plan = DateTime.Now;

        private int _num_pagos = 0;
        private int _id_ultimo_pago = 0;

        //Propiedades públicas
        public int id_planpago { get { return _id_planpago; } set { _id_planpago = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public bool vigente { get { return _vigente; } set { _vigente = value; } }
        public int num_cuotas { get { return _num_cuotas; } set { _num_cuotas = value; } }
        public decimal seguro { get { return _seguro; } set { _seguro = value; } }
        public decimal mantenimiento_sus { get { return _mantenimiento_sus; } set { _mantenimiento_sus = value; } }
        public decimal interes_corriente { get { return _interes_corriente; } set { _interes_corriente = value; } }
        public decimal interes_penal { get { return _interes_penal; } set { _interes_penal = value; } }
        public decimal cuota_base { get { return _cuota_base; } set { _cuota_base = value; } }
        public DateTime fecha_inicio_plan { get { return _fecha_inicio_plan; } set { _fecha_inicio_plan = value; } }

        public int num_pagos { get { return _num_pagos; } }
        public int id_ultimo_pago { get { return _id_ultimo_pago; } }
        #endregion

        #region Constructores
        public plan_pago(int Id_planpago)
        {
            _id_planpago = Id_planpago;
            RecuperarDatos();
        }

        public plan_pago(int Id_contrato, int Id_pago, int Num_cuotas,
            decimal Seguro, decimal Mantenimiento_sus, decimal Interes_corriente, decimal Interes_penal,
            decimal Cuota_base, DateTime Fecha_inicio_plan)
        {
            _id_contrato = Id_contrato;
            _id_pago = Id_pago;
            _num_cuotas = Num_cuotas;
            _seguro = Seguro;
            _mantenimiento_sus = Mantenimiento_sus;
            _interes_corriente = Interes_corriente;
            _interes_penal = Interes_penal;
            _cuota_base = Cuota_base;
            _fecha_inicio_plan = Fecha_inicio_plan;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable ListaNoVigentes(int Id_contrato)
        {
            //[id_planpago],[fecha],[num_cuotas],[seguro],[mantenimiento],[interes],[cuota_base],[fecha_inicio_plan]
            DbCommand cmd = db1.GetStoredProcCommand("plan_pago_ListaNoVigentes");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static int AnulacionIdReprogramacion(int Id_contrato, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("plan_pago_AnulacionIdReprogramacion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return (int)db1.ExecuteScalar(cmd);
                else return 0;
            }
            catch { return 0; }
        }
        public static bool AnularReprogramacion(int Id_plan_pago_anulable, int context_id_usuario, int context_id_rol)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("plan_pago_AnularReprogramacion");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_planpago", DbType.Int32, Id_plan_pago_anulable);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, context_id_rol);
                if ((int)db1.ExecuteScalar(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("plan_pago_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_planpago", DbType.Int32, _id_planpago);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_pago", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "vigente", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "num_cuotas", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "seguro", DbType.Double, 14);
                db1.AddOutParameter(cmd, "mantenimiento_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes_corriente", DbType.Double, 14);
                db1.AddOutParameter(cmd, "interes_penal", DbType.Double, 14);
                db1.AddOutParameter(cmd, "cuota_base", DbType.Double, 14);
                db1.AddOutParameter(cmd, "fecha_inicio_plan", DbType.DateTime, 200);

                db1.AddOutParameter(cmd, "num_pagos", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_ultimo_pago", DbType.Int32, 32);

                db1.ExecuteNonQuery(cmd);

                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_pago = (int)db1.GetParameterValue(cmd, "id_pago");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _vigente = (bool)db1.GetParameterValue(cmd, "vigente");
                _num_cuotas = (int)db1.GetParameterValue(cmd, "num_cuotas");
                _seguro = (decimal)(double)db1.GetParameterValue(cmd, "seguro");
                _mantenimiento_sus = (decimal)(double)db1.GetParameterValue(cmd, "mantenimiento_sus");
                _interes_corriente = (decimal)(double)db1.GetParameterValue(cmd, "interes_corriente");
                _interes_penal = (decimal)(double)db1.GetParameterValue(cmd, "interes_penal");
                _cuota_base = (decimal)(double)db1.GetParameterValue(cmd, "cuota_base");
                _fecha_inicio_plan = (DateTime)db1.GetParameterValue(cmd, "fecha_inicio_plan");

                _num_pagos = (int)db1.GetParameterValue(cmd, "num_pagos");
                _id_ultimo_pago = (int)db1.GetParameterValue(cmd, "id_ultimo_pago");
            }
            catch { }
        }

        public bool Reprogramar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("plan_pago_Reprogramar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, _num_cuotas);
                db1.AddInParameter(cmd, "seguro", DbType.Decimal, _seguro);
                db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, _mantenimiento_sus);
                db1.AddInParameter(cmd, "interes_corriente", DbType.Decimal, _interes_corriente);
                db1.AddInParameter(cmd, "interes_penal", DbType.Decimal, _interes_penal);
                db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, _cuota_base);
                db1.AddInParameter(cmd, "fecha_inicio_plan", DbType.DateTime, _fecha_inicio_plan);
                db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, logica.FechaProximoPago(new pago(_id_pago).interes_fecha,_fecha_inicio_plan));
                _id_planpago = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Reprogramaciones en bloque
        public static DataTable reprog_bloque_tabla_datos_reprogramacion(string cadena_datos)
        {
            //[num_contrato],[num_cuotas],[interes_corriente],[fecha_inicio_plan]
            DataTable tabla = new DataTable();
            tabla.Columns.Add("num_contrato", typeof(string));
            tabla.Columns.Add("num_cuotas", typeof(int));
            tabla.Columns.Add("interes_corriente", typeof(decimal));
            tabla.Columns.Add("fecha_inicio_plan", typeof(DateTime));

            if (cadena_datos.Trim() != "")
            {
                string[] filas = cadena_datos.TrimEnd(';').Split(';');
                for (int i = 0; i < filas.Length; i++)
                {
                    try
                    {
                        string[] columnas = filas[i].Split(':');
                        if (columnas.Length == 4)
                        {
                            string Num_contrato;
                            int Num_cuotas;
                            decimal Interes_corriente;
                            DateTime Fecha_inicio_plan;
                            if (columnas[0] != ""
                                && int.TryParse(columnas[1], out Num_cuotas)
                                && decimal.TryParse(columnas[2], out Interes_corriente)
                                && DateTime.TryParse(columnas[3], out Fecha_inicio_plan))
                            {
                                Num_contrato = columnas[0];
                                DataRow nueva_fila = tabla.NewRow();
                                nueva_fila["num_contrato"] = Num_contrato;
                                nueva_fila["num_cuotas"] = Num_cuotas;
                                nueva_fila["interes_corriente"] = Interes_corriente;
                                nueva_fila["fecha_inicio_plan"] = Fecha_inicio_plan;
                                tabla.Rows.Add(nueva_fila);
                            }
                        }
                    }
                    catch { }
                }
            }
            return tabla;
        }

        public static DataTable reprog_bloque_tabla_reprogramacion(string cadena_datos, ref int num_total, ref int num_reprog)
        {
            //[num_contrato],[estado],[saldo],[reprogramar],
            //[id_contrato],[id_pago],[num_cuotas],[seguro],[mantenimiento_sus],
            //[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan],[fecha_proximo],
            //[o_num_cuotas],[o_interes_corriente],[o_fecha_inicio_plan],[o_cuota_base]
            DataTable tabla = new DataTable();
            tabla.Columns.Add("num_contrato", typeof(string));
            tabla.Columns.Add("estado", typeof(string));
            tabla.Columns.Add("saldo", typeof(decimal));

            tabla.Columns.Add("reprogramar", typeof(bool));
            //tabla.Columns.Add("reprogramado", typeof(string));

            tabla.Columns.Add("id_contrato", typeof(int));
            tabla.Columns.Add("id_pago", typeof(int));
            tabla.Columns.Add("num_cuotas", typeof(int));
            tabla.Columns.Add("seguro", typeof(decimal));
            tabla.Columns.Add("mantenimiento_sus", typeof(decimal));
            tabla.Columns.Add("interes_corriente", typeof(decimal));
            tabla.Columns.Add("interes_penal", typeof(decimal));
            tabla.Columns.Add("cuota_base", typeof(decimal));
            tabla.Columns.Add("fecha_inicio_plan", typeof(DateTime));
            tabla.Columns.Add("fecha_proximo", typeof(DateTime));

            tabla.Columns.Add("o_num_cuotas", typeof(int));
            tabla.Columns.Add("o_interes_corriente", typeof(decimal));
            tabla.Columns.Add("o_fecha_inicio_plan", typeof(DateTime));
            tabla.Columns.Add("o_cuota_base", typeof(decimal));

            //[num_contrato],[num_cuotas],[interes_corriente],[fecha_inicio_plan]
            DataTable tabla_datos = reprog_bloque_tabla_datos_reprogramacion(cadena_datos);

            num_total = tabla_datos.Rows.Count;
            num_reprog = 0;
            foreach (DataRow fila_datos in tabla_datos.Rows)
            {
                string num_contrato = fila_datos["num_contrato"].ToString();
                int num_cuotas = (int)fila_datos["num_cuotas"];
                decimal interes_corriente = (decimal)fila_datos["interes_corriente"];
                DateTime fecha_inicio_plan = (DateTime)fila_datos["fecha_inicio_plan"];

                decimal saldo = 0;
                int id_pago = 0; DateTime fecha_proximo = DateTime.Now;
                decimal seguro = 0; decimal mantenimiento_sus = 0; decimal interes_penal = 0;
                decimal cuota_base = 0;

                bool reprogramar = false;
                //Se obtiene los datos del contrato
                int id_contrato = contrato.IdPorNumero(num_contrato);
                int id_estado_contrato = contrato.Estado(id_contrato, DateTime.Now);

                //Se obtiene el plan de pagos
                int id_planpago_anterior = contrato.PlanPagoVigente(id_contrato);
                plan_pago pp_anterior = new plan_pago(id_planpago_anterior);

                //Se obtiene el último pago
                id_pago = contrato.UltimoPago(id_contrato, DateTime.Now);
                pago ult_pago = new pago(id_pago);

                //Se verifica que: el contrato existe
                if (id_contrato > 0)
                {
                    if (id_pago > 0) { saldo = ult_pago.saldo; }
                    if (id_planpago_anterior > 0)
                    {
                        seguro = pp_anterior.seguro;
                        mantenimiento_sus = pp_anterior.mantenimiento_sus;
                        interes_penal = pp_anterior.interes_penal;
                    }

                    //Se verifica que: el plan de pagos tiene algún parámetro diferente a los vigentes
                    //Se verifica que: el saldo del último pago es mayor a 0
                    if (id_estado_contrato == 1 && id_planpago_anterior > 0 && ult_pago.saldo > 0
                        && (pp_anterior.num_cuotas != num_cuotas
                        || pp_anterior.interes_corriente != interes_corriente
                        || pp_anterior.fecha_inicio_plan.Date != fecha_inicio_plan.Date))
                    {
                        cuota_base = simular.Obtener_cuota_base(ult_pago.saldo, num_cuotas, seguro, mantenimiento_sus, interes_corriente);
                        fecha_proximo = logica.FechaProximoPago(ult_pago.interes_fecha, fecha_inicio_plan);
                        reprogramar = true;
                        num_reprog += 1;
                    }

                }

                //Se agrega la fila del contrato
                DataRow fila = tabla.NewRow();
                fila["num_contrato"] = num_contrato;
                fila["estado"] = contrato.Estado_string(id_contrato, DateTime.Now);
                if (id_contrato > 0) fila["saldo"] = saldo;

                fila["reprogramar"] = reprogramar;
                //fila["reprogramado"] = "No";

                if (id_estado_contrato == 1 && ult_pago.saldo > 0)
                {
                    fila["id_contrato"] = id_contrato;
                    fila["id_pago"] = id_pago;
                    fila["num_cuotas"] = num_cuotas;
                    fila["seguro"] = seguro;
                    fila["mantenimiento_sus"] = mantenimiento_sus;
                    fila["interes_corriente"] = interes_corriente;
                    fila["interes_penal"] = interes_penal;
                    if (cuota_base > 0) fila["cuota_base"] = cuota_base;
                    fila["fecha_inicio_plan"] = fecha_inicio_plan;
                    fila["fecha_proximo"] = fecha_proximo;
                }

                if (id_planpago_anterior > 0)
                {
                    fila["o_num_cuotas"] = pp_anterior.num_cuotas;
                    fila["o_interes_corriente"] = pp_anterior.interes_corriente;
                    fila["o_fecha_inicio_plan"] = pp_anterior.fecha_inicio_plan;
                    fila["o_cuota_base"] = pp_anterior.cuota_base;
                }
                tabla.Rows.Add(fila);
            }
            return tabla;
        }

        public static DataTable reprog_bloque_reprogramar(string cadena_datos, int Context_id_usuario, ref int num_total, ref int num_reprog)
        {
            int _num_total = 0; int _num_reprog = 0;
            DataTable tabla = reprog_bloque_tabla_reprogramacion(cadena_datos, ref _num_total, ref _num_reprog);
            tabla.Columns.Add("reprogramado", typeof(string));
            int reprog_correcta = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                bool reprogramar = (bool)fila["reprogramar"];
                if (reprogramar == true)
                {
                    int id_contrato = (int)fila["id_contrato"];
                    int id_pago = (int)fila["id_pago"];
                    int num_cuotas = (int)fila["num_cuotas"];
                    decimal seguro = (decimal)fila["seguro"];
                    decimal mantenimiento_sus = (decimal)fila["mantenimiento_sus"];
                    decimal interes_corriente = (decimal)fila["interes_corriente"];
                    decimal interes_penal = (decimal)fila["interes_penal"];
                    decimal cuota_base = (decimal)fila["cuota_base"];
                    DateTime fecha_inicio_plan = (DateTime)fila["fecha_inicio_plan"];

                    plan_pago ppObj = new plan_pago(id_contrato, id_pago, num_cuotas, seguro, mantenimiento_sus, interes_corriente, interes_penal, cuota_base, fecha_inicio_plan);
                    if (ppObj.Reprogramar(Context_id_usuario) == true)
                    {
                        fila["reprogramado"] = "Si";
                        reprog_correcta += 1;
                    }
                    else { fila["reprogramado"] = "No"; }
                }
                else { fila["reprogramado"] = "No"; }
            }
            num_total = tabla.Rows.Count;
            num_reprog = reprog_correcta;
            return tabla;
        }
        #endregion
    }
}