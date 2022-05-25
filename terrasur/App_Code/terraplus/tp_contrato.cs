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
using System.Text;

/// <summary>
/// Descripción breve de tp_contrato
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_contrato
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_contrato = 0;
            private int _id_cliente = 0;
            private int _id_usuario = 0;
            private int _id_moneda = 0;
            private DateTime _fecha = DateTime.Now;
            private string _numero = "";
            private decimal _monto = 0;
            private DateTime _mes_inicio = DateTime.Now;
            private int _meses_restriccion = 0;
            private int _meses_reversion = 0;
            private int _meses_consecutivo = 0;

            private string _cliente_nombre = "";
            private string _cliente_ci = "";
            private DateTime _cliente_fecha_nacimiento = DateTime.Now;
            private string _estado_nombre = "";
            private int _estado_id_estado = 0;
            private int _cuotas_pagadas = 0;
            private decimal _cuotas_monto = 0;
            private int _ultimo_id_pago = 0;
            private int _num_contratos_lotes = 0;
            private int _num_contratos_terraplus = 0;
            private string _moneda_codigo = "";

            //Propiedades públicas
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_cliente { get { return _id_cliente; } set { _id_cliente = value; } }
            public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
            public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public string numero { get { return _numero; } set { _numero = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            public DateTime mes_inicio { get { return _mes_inicio; } set { _mes_inicio = value; } }
            public int meses_restriccion { get { return _meses_restriccion; } set { _meses_restriccion = value; } }
            public int meses_reversion { get { return _meses_reversion; } set { _meses_reversion = value; } }
            public int meses_consecutivo { get { return _meses_consecutivo; } set { _meses_consecutivo = value; } }

            public string cliente_nombre { get { return _cliente_nombre; } }
            public string cliente_ci { get { return _cliente_ci; } }
            public DateTime cliente_fecha_nacimiento { get { return _cliente_fecha_nacimiento; } }
            public string estado_nombre { get { return _estado_nombre; } }
            public int estado_id_estado { get { return _estado_id_estado; } }
            public int cuotas_pagadas { get { return _cuotas_pagadas; } }
            public decimal cuotas_monto { get { return _cuotas_monto; } }
            public int ultimo_id_pago { get { return _ultimo_id_pago; } }
            public int num_contratos_lotes { get { return _num_contratos_lotes; } }
            public int num_contratos_terraplus { get { return _num_contratos_terraplus; } }
            public string moneda_codigo { get { return _moneda_codigo; } }

            #endregion

            #region Constructores
            public tp_contrato(int Id_contrato)
            {
                _id_contrato = Id_contrato;
                RecuperarDatos();
            }

            public tp_contrato(int Id_cliente, int Id_moneda, string Numero, decimal Monto, DateTime Mes_inicio,
                int Meses_restriccion, int Meses_reversion, int Meses_consecutivo)
            {
                _id_cliente = Id_cliente;
                _id_moneda = Id_moneda;
                _numero = Numero;
                _monto = Monto;
                _mes_inicio = Mes_inicio;

                _meses_restriccion = Meses_restriccion;
                _meses_reversion = Meses_reversion;
                _meses_consecutivo = Meses_consecutivo;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static int IdContratoPorNumero(string Numero)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_IdContratoPorNumero");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "numero", DbType.String, Numero);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static int IdContratoPorCliente_ParaBusqueda(int Id_cliente)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_IdContratoPorCliente_ParaBusqueda");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static int IdContratoPorCliente(int Id_cliente)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_IdContratoPorCliente");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static int IdClientePorNumero(string Numero)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_IdClientePorNumero");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "numero", DbType.String, Numero);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static int IdClientePorContrato(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_IdClientePorContrato");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static int NumReactivaciones(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_NumReactivaciones");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static int NumMesesIncumplidos(int Id_contrato)
            {
                try
                {
                    int Num_meses_incumplidos = 0;

                    DateTime Fecha_ultimo_mes;
                    int Id_ultimo_pago = terrasur.terraplus.tp_pago.Id_ultimo(Id_contrato);
                    if (Id_ultimo_pago > 0) { Fecha_ultimo_mes = (new terrasur.terraplus.tp_pago(Id_ultimo_pago)).mes_pago; }
                    else { Fecha_ultimo_mes = (new terrasur.terraplus.tp_contrato(Id_contrato)).mes_inicio; }

                    if (Fecha_ultimo_mes < DateTime.Now.Date)
                    { Num_meses_incumplidos = terrasur.terraplus.tp_contrato.CalculoNumMeses(Fecha_ultimo_mes, DateTime.Now.Date); }

                    return Num_meses_incumplidos;
                }
                catch { return 0; }
            }

            public static int CalculoNumMeses(DateTime Fecha_inicio, DateTime Fecha_fin)
            {
                Fecha_inicio = Fecha_inicio.Date.AddDays((Fecha_inicio.Day - 1) * (-1));
                Fecha_fin = Fecha_fin.AddDays((Fecha_fin.Day - 1) * (-1));

                int Num_meses = 0; 
                DateTime fecha_aux_inicio = Fecha_inicio;

                while (fecha_aux_inicio < Fecha_fin) { Num_meses += 1; fecha_aux_inicio = fecha_aux_inicio.AddMonths(1); }
                return Num_meses;
            }

            public static string CodigoMoneda(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_CodigoMoneda");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (string)db1.ExecuteScalar(cmd);
                }
                catch { return ""; }
            }

            public static void BeneficiarioFactura(int Id_contrato, ref string Nombre, ref string Nit)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_BeneficiarioFactura");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "nit", DbType.String, 15);
                    db1.ExecuteNonQuery(cmd);
                    Nombre = (string)db1.GetParameterValue(cmd, "nombre");
                    Nit = (string)db1.GetParameterValue(cmd, "nit");
                }
                catch
                {
                    Nombre = ""; 
                    Nit = "0";
                }
            }

            public static bool VerificarClienteTitularLote(int Id_cliente)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_VerificarClienteTitularLote");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                    if ((int)db1.ExecuteScalar(cmd) > 0) { return true; }
                    else { return false; }
                }
                catch { return false; }
            }


            public static DataTable ListaContratosLotes(int Id_cliente, bool Solo_1er_titular, bool Con_estado, bool Con_tipo_titular)
            {
                //[id_contrato],[num_contrato],[fecha],[nombre_estado],[tipo_titular]
                DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_ListaContratosLotes");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddInParameter(cmd, "solo_1er_titular", DbType.Boolean, Solo_1er_titular);
                db1.AddInParameter(cmd, "con_estado", DbType.Boolean, Con_estado);
                db1.AddInParameter(cmd, "con_tipo_titular", DbType.Boolean, Con_tipo_titular);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static string ListaContratosLotes_string(int Id_cliente, bool Solo_1er_titular, bool Con_estado, bool Con_tipo_titular)
            {
                StringBuilder str = new StringBuilder();
                DataTable tabla = ListaContratosLotes(Id_cliente, Solo_1er_titular, Con_estado, Con_tipo_titular);
                foreach (DataRow fila in tabla.Rows) { str.Append(fila["num_contrato"].ToString() + ", "); }
                return str.ToString().Trim().TrimEnd(',');
            }

            public static DataTable ListaContratosTerraplus(int Id_cliente, bool Con_estado)
            {
                //[id_contrato],[num_contrato],[fecha],[nombre_estado]
                DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_ListaContratosTerraplus");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_cliente", DbType.Int32, Id_cliente);
                db1.AddInParameter(cmd, "con_estado", DbType.Boolean, Con_estado);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static string ListaContratosTerraplus_string(int Id_cliente, bool Con_estado, int Id_contrato_actual)
            {
                StringBuilder str = new StringBuilder();
                DataTable tabla = ListaContratosTerraplus(Id_cliente, Con_estado);
                foreach (DataRow fila in tabla.Rows)
                {
                    if ((int)fila["id_contrato"] != Id_contrato_actual)
                    {
                        str.Append(fila["num_contrato"].ToString() + ", ");
                    }
                }
                return str.ToString().Trim().TrimEnd(',');
            }

            public static DataTable ListaContratosLotes(string Nombre_ci_cliente, 
                string Lote_num_contrato, DateTime Lote_fecha_inicio, DateTime Lote_fecha_fin,
                string Terraplus_num_contrato, DateTime Terraplus_fecha_inicio, DateTime Terraplus_fecha_fin,
                int Id_estado)
            {
                //[id_cliente],[nombre_cliente],[ci_cliente]
                //[lot_numero],[lot_descrip],[lot_tipo_cliente]
                //[tp_id_contrato],[tp_numero],[tp_estado],[tp_monto]
                DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "nombre_ci_cliente", DbType.String, Nombre_ci_cliente);

                db1.AddInParameter(cmd, "lote_num_contrato", DbType.String, Lote_num_contrato);
                db1.AddInParameter(cmd, "lote_fecha_inicio", DbType.DateTime, Lote_fecha_inicio);
                db1.AddInParameter(cmd, "lote_fecha_fin", DbType.DateTime, Lote_fecha_fin);

                db1.AddInParameter(cmd, "terraplus_num_contrato", DbType.String, Terraplus_num_contrato);
                db1.AddInParameter(cmd, "terraplus_fecha_inicio", DbType.DateTime, Terraplus_fecha_inicio);
                db1.AddInParameter(cmd, "terraplus_fecha_fin", DbType.DateTime, Terraplus_fecha_fin);

                db1.AddInParameter(cmd, "id_estado", DbType.Int32, Id_estado);
                
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaMesesInicioPlan(int Num_meses_antes, int Num_meses_despues)
            {
                return ListaMesesInicioPlan(DateTime.Now.Date, Num_meses_antes, Num_meses_despues);
            }
            public static DataTable ListaMesesInicioPlan(DateTime Fecha_referencia, int Num_meses_antes, int Num_meses_despues)
            {
                //[fechaMes],[literal]
                DataTable tabla = new DataTable();
                tabla.Columns.Add("fechaMes", typeof(string));
                tabla.Columns.Add("literal", typeof(string));
                DateTime fecha_base = Fecha_referencia.Date.AddDays((Fecha_referencia.Day - 1) * (-1));
                fecha_base = fecha_base.AddMonths(Num_meses_antes * (-1));

                for (int j = 0; j < (Num_meses_antes + Num_meses_despues + 1); j++)
                {
                    DataRow fila = tabla.NewRow();
                    fila["fechaMes"] = fecha_base.ToString("d"); //(fecha_base.Year * 100) + fecha_base.Month;
                    string literal_mes = ""; switch (fecha_base.Month) { case 1: literal_mes = "Enero"; break; case 2: literal_mes = "Febrero"; break; case 3: literal_mes = "Marzo"; break; case 4: literal_mes = "Abril"; break; case 5: literal_mes = "Mayo"; break; case 6: literal_mes = "Junio"; break; case 7: literal_mes = "Julio"; break; case 8: literal_mes = "Agosto"; break; case 9: literal_mes = "Septiembre"; break; case 10: literal_mes = "Octubre"; break; case 11: literal_mes = "Noviembre"; break; case 12: literal_mes = "Diciembre"; break; }
                    fila["literal"] = fecha_base.Year.ToString() + " " + literal_mes;
                    tabla.Rows.Add(fila);
                    fecha_base = fecha_base.AddMonths(1);
                }

                return tabla;
            }


            private static DataTable ListaContratosTerraplusPorContratoLote_base(int Id_contrato)
            {
                //[id_cliente],[nombre],[num_contrato],[estado],[ultimo_mes]
                DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_ListaContratosTerraplusPorContratoLote");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            public static DataTable ListaContratosTerraplusPorContratoLote_lista(int Id_contrato)
            {
                //[texto],[mensaje]
                DataTable tabla = new DataTable();
                tabla.Columns.Add("texto", typeof(string));
                tabla.Columns.Add("mensaje", typeof(string));

                DataTable tabla_base = ListaContratosTerraplusPorContratoLote_base(Id_contrato);
                foreach (DataRow fila_base in tabla_base.Rows)
                {
                    StringBuilder str_texto = new StringBuilder();
                    str_texto.Append(fila_base["nombre"].ToString());
                    str_texto.Append(" tiene TerraPlus");

                    StringBuilder str_mensaje = new StringBuilder();
                    str_mensaje.Append(fila_base["nombre"].ToString() + " tiene un contrato TerraPlus (Nro. " + fila_base["num_contrato"].ToString() + ") en estado: " + fila_base["estado"].ToString());
                    DateTime p_ultimo_mes = (DateTime)fila_base["ultimo_mes"];
                    if (p_ultimo_mes.Date != DateTime.Parse("01/01/1900").Date)
                    { str_mensaje.Append("; su último mes pagado fue: " + tp_pago.StringMes(p_ultimo_mes, p_ultimo_mes)); }
                    else { str_mensaje.Append("; no tiene pagos"); }

                    DataRow fila = tabla.NewRow();
                    fila["texto"] = str_texto.ToString();
                    fila["mensaje"] = str_mensaje.ToString();
                    tabla.Rows.Add(fila);
                }
                return tabla;
            }
            public static string ListaContratosTerraplusPorContratoLote_cadena(int Id_contrato)
            {
                StringBuilder str_resultado = new StringBuilder();

                DataTable tabla_base = ListaContratosTerraplusPorContratoLote_base(Id_contrato);
                foreach (DataRow fila_base in tabla_base.Rows)
                {

                    StringBuilder str_texto = new StringBuilder();
                    str_resultado.Append(fila_base["nombre"].ToString());
                    str_resultado.Append(" tiene el Ctto. TerraPlus Nro. ");
                    str_resultado.Append(fila_base["num_contrato"].ToString());
                    str_resultado.Append(" (");
                    str_resultado.Append(fila_base["estado"].ToString());
                    str_resultado.Append(")");

                    DateTime p_ultimo_mes = (DateTime)fila_base["ultimo_mes"];
                    if (p_ultimo_mes.Date != DateTime.Parse("01/01/1900").Date)
                    { str_resultado.Append(", pagado hasta: " + tp_pago.StringMes(p_ultimo_mes, p_ultimo_mes)); }

                    str_resultado.Append(" ; ");
                }
                return str_resultado.ToString().Trim().TrimEnd(';');
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);

                    db1.AddOutParameter(cmd, "id_cliente", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_moneda", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "numero", DbType.String, 20);
                    db1.AddOutParameter(cmd, "monto", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "mes_inicio", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "meses_restriccion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "meses_reversion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "meses_consecutivo", DbType.Int32, 32);

                    db1.AddOutParameter(cmd, "cliente_nombre", DbType.String, 100);
                    db1.AddOutParameter(cmd, "cliente_ci", DbType.String, 20);
                    db1.AddOutParameter(cmd, "cliente_fecha_nacimiento", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 50);
                    db1.AddOutParameter(cmd, "estado_id_estado", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "cuotas_pagadas", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "cuotas_monto", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "ultimo_id_pago", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "num_contratos_lotes", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "num_contratos_terraplus", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "moneda_codigo", DbType.String, 20);

                    db1.ExecuteNonQuery(cmd);

                    _id_cliente = (int)db1.GetParameterValue(cmd, "id_cliente");
                    _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                    _id_moneda = (int)db1.GetParameterValue(cmd, "id_moneda");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _numero = (string)db1.GetParameterValue(cmd, "numero");
                    _monto = (decimal)(double)db1.GetParameterValue(cmd, "monto");
                    _mes_inicio = (DateTime)db1.GetParameterValue(cmd, "mes_inicio");
                    _meses_restriccion = (int)db1.GetParameterValue(cmd, "meses_restriccion");
                    _meses_reversion = (int)db1.GetParameterValue(cmd, "meses_reversion");
                    _meses_consecutivo = (int)db1.GetParameterValue(cmd, "meses_consecutivo");

                    _cliente_nombre = (string)db1.GetParameterValue(cmd, "cliente_nombre");
                    _cliente_ci = (string)db1.GetParameterValue(cmd, "cliente_ci");
                    _cliente_fecha_nacimiento = (DateTime)db1.GetParameterValue(cmd, "cliente_fecha_nacimiento");
                    _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
                    _estado_id_estado = (int)db1.GetParameterValue(cmd, "estado_id_estado");
                    _cuotas_pagadas = (int)db1.GetParameterValue(cmd, "cuotas_pagadas");
                    _cuotas_monto = (decimal)(double)db1.GetParameterValue(cmd, "cuotas_monto");
                    _ultimo_id_pago = (int)db1.GetParameterValue(cmd, "ultimo_id_pago");
                    _num_contratos_lotes = (int)db1.GetParameterValue(cmd, "num_contratos_lotes");
                    _num_contratos_terraplus = (int)db1.GetParameterValue(cmd, "num_contratos_terraplus");
                    _moneda_codigo = (string)db1.GetParameterValue(cmd, "moneda_codigo");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_contrato_Insertar");
                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, _id_cliente);
                    db1.AddInParameter(cmd, "id_moneda", DbType.Int32, _id_moneda);
                    db1.AddInParameter(cmd, "numero", DbType.String, _numero);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                    db1.AddInParameter(cmd, "mes_inicio", DbType.DateTime, _mes_inicio);

                    db1.AddInParameter(cmd, "meses_restriccion", DbType.Int32, _meses_restriccion);
                    db1.AddInParameter(cmd, "meses_reversion", DbType.Int32, _meses_reversion);
                    db1.AddInParameter(cmd, "meses_consecutivo", DbType.Int32, _meses_consecutivo);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_contrato = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }
            #endregion
        }
    }
}