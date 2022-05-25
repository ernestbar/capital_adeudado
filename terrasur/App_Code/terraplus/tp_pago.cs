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
/// Descripción breve de tp_pago
/// </summary>
namespace terrasur
{
    namespace terraplus
    {
        public class tp_pago
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_pago = 0;
            private int _id_plan = 0;
            private int _id_serviciovendido = 0;
            private int _id_estadocontrato = 0;
            private DateTime _fecha = DateTime.Now;
            private decimal _monto = 0;
            private DateTime _mes_pago = DateTime.Now;
            private int _mes_restriccion = 0;
            private bool _anulado = false;

            private int _id_contrato = 0;
            private int _id_transaccion = 0;

            //Propiedades públicas
            public int id_pago { get { return _id_pago; } set { _id_pago = value; } }
            public int id_plan { get { return _id_plan; } set { _id_plan = value; } }
            public int id_serviciovendido { get { return _id_serviciovendido; } set { _id_serviciovendido = value; } }
            public int id_estadocontrato { get { return _id_estadocontrato; } set { _id_estadocontrato = value; } }
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            public DateTime mes_pago { get { return _mes_pago; } set { _mes_pago = value; } }
            public int mes_restriccion { get { return _mes_restriccion; } set { _mes_restriccion = value; } }
            public bool anulado { get { return _anulado; } set { _anulado = value; } }

            public int id_contrato { get { return _id_contrato; } }
            public int id_transaccion { get { return _id_transaccion; } }
            #endregion

            #region Constructores
            public tp_pago(int Id_pago)
            {
                _id_pago = Id_pago;
                RecuperarDatos();
            }
            public tp_pago(int Id_contrato, int Id_transaccion, decimal Monto, DateTime Mes_pago)
            {
                _id_contrato = Id_contrato;
                _id_transaccion = Id_transaccion;
                _monto = Monto;
                _mes_pago = Mes_pago;
            }
            public tp_pago(int Id_contrato, int Id_pago)
            {
                _id_contrato = Id_contrato;
                _id_pago = Id_pago;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable ListaDePagoServicio(int Id_contrato)
            {
                //[id_serviciovendido],[fecha],[literal_meses],[num_meses]
                //[precio_total],[codigo_moneda],[num_factura],[num_recibo],[num_comprobante]
                DbCommand cmd = db1.GetStoredProcCommand("tp_pago_ListaDePagoServicio");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            
            public static DataTable ListaPorPagoServicio(int Id_serviciovendido)
            {
                //[id_pago],[fecha],[anulado]
                DbCommand cmd = db1.GetStoredProcCommand("tp_pago_ListaPorPagoServicio");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_serviciovendido", DbType.Int32, Id_serviciovendido);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static DataTable ListaUltimoPago(int Id_contrato)
            {
                //[id_serviciovendido],[fecha],[literal_meses],[num_meses]
                //[precio_total],[codigo_moneda],[num_factura]
                //[forma_pago],[sucursal],[usuario],[texto_pago]
                DbCommand cmd = db1.GetStoredProcCommand("tp_pago_ListaUltimoPago");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }



            public static int Id_ultimo(int Id_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_Id_ultimo");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    return (int)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            public static bool PermitirAnularUltimoPago(int Id_contrato, int Id_usuario, int Id_rol)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_PermitirAnularUltimoPago");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
                    db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
                    if ((int)db1.ExecuteScalar(cmd) > 0) { return true; }
                    else { return false; }
                }
                catch { return false; }
            }

            public static string MesLiteral(DateTime Fecha_inicial, DateTime Fecha_final)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_MesLiteral");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "fecha_inicial", DbType.DateTime, Fecha_inicial);
                    db1.AddInParameter(cmd, "fecha_final", DbType.DateTime, Fecha_final);
                    return db1.ExecuteScalar(cmd).ToString();
                }
                catch { return ""; }
            }

            public static bool VerificarTransaccionTerraPlus(int Id_transaccion)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_VerificarTransaccionTerraPlus");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                    if ((int)db1.ExecuteScalar(cmd) > 0) { return true; }
                    else{ return false;}
                }
                catch { return false; }
            }

            public static void DatosConceptoFactura(int Id_factura, ref string Concepto, ref string Nombre_cliente, ref string Num_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_DatosConceptoFactura");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_factura", DbType.Int32, Id_factura);
                    db1.AddOutParameter(cmd, "concepto", DbType.String, 100);
                    db1.AddOutParameter(cmd, "nombre_cliente", DbType.String, 100);
                    db1.AddOutParameter(cmd, "num_contrato", DbType.String, 10);
                    db1.ExecuteNonQuery(cmd);
                    Concepto = (string)db1.GetParameterValue(cmd, "concepto");
                    Nombre_cliente = (string)db1.GetParameterValue(cmd, "nombre_cliente");
                    Num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
                }
                catch
                {
                    Nombre_cliente = "";
                    Num_contrato = "0";
                }
            }

            public static string DatosDetalleFactura(int Id_transaccion)
            {
                try
                {
                    DateTime p_fecha_inicial = DateTime.Now;
                    DateTime p_fecha_final = DateTime.Now;
                    int p_num_meses = 0;

                    //Se obtienen los datos
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_DatosDetalleFactura");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                    db1.AddOutParameter(cmd, "fecha_inicial", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "fecha_final", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "num_meses", DbType.Int32, 32);
                    db1.ExecuteNonQuery(cmd);
                    p_fecha_inicial = (DateTime)db1.GetParameterValue(cmd, "fecha_inicial");
                    p_fecha_final = (DateTime)db1.GetParameterValue(cmd, "fecha_final");
                    p_num_meses = (int)db1.GetParameterValue(cmd, "num_meses");

                    //Se construye la cadena del detalle
                    string p_detalle = "";

                    if (p_num_meses > 0)
                    {
                        p_detalle = StringMes(p_fecha_inicial, p_fecha_final);
                        if (p_num_meses > 1) { p_detalle = p_detalle + " (" + p_num_meses.ToString() + " meses)"; }
                        //else { p_detalle = p_detalle + " (1 mes)"; }
                    }

                    return p_detalle;
                }
                catch { return ""; }
            }

            private static string StringMes_nombre(DateTime Fecha)
            {
                string Mes_literal = "";
                switch (Fecha.Month)
                {
                    case 1: Mes_literal = "ENERO"; break;
                    case 2: Mes_literal = "FEBRERO"; break;
                    case 3: Mes_literal = "MARZO"; break;
                    case 4: Mes_literal = "ABRIL"; break;
                    case 5: Mes_literal = "MAYO"; break;
                    case 6: Mes_literal = "JUNIO"; break;
                    case 7: Mes_literal = "JULIO"; break;
                    case 8: Mes_literal = "AGOSTO"; break;
                    case 9: Mes_literal = "SEPTIEMBRE"; break;
                    case 10: Mes_literal = "OCTUBRE"; break;
                    case 11: Mes_literal = "NOVIEMBRE"; break;
                    case 12: Mes_literal = "DICIEMBRE"; break;
                }
                return Mes_literal;
            }
            public static string StringMes(DateTime Fecha)
            {
                return Fecha.Year.ToString() + " - " + StringMes_nombre(Fecha);
            }
            public static string StringMes(DateTime Fecha1, DateTime Fecha2)
            {
                if (Fecha1.Year == Fecha2.Year && Fecha1.Month == Fecha2.Month)
                {
                    return StringMes_nombre(Fecha1) + " de " + Fecha1.Year.ToString();
                }
                else if (Fecha1 < Fecha2)
                {
                    if (Fecha1.Year == Fecha2.Year)
                    {
                        return "De " + StringMes_nombre(Fecha1) + " a " + StringMes_nombre(Fecha2) + " de " + Fecha1.Year.ToString();
                    }
                    else if (Fecha1.Year < Fecha2.Year)
                    {
                        return "De " + StringMes_nombre(Fecha1) + " de " + Fecha1.Year.ToString() + " a " + StringMes_nombre(Fecha2) + " de " + Fecha2.Year.ToString();
                    }
                    else { return "---"; }
                }
                else { return "---"; }
            }

            #endregion


            #region Métodos para registro de pagos
            public static int Insertar_PagosTerraPlus(int Id_contrato, int Num_meses,
                int Audit_id_usuario, string Audit_ip, string Audit_host, 
                int Id_recibocobrador, tmpFormaPago tfp, 
                string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar
                )
            {
                //Se obtienen los pagos TerraPlus y los montos
                List<tmpTpPago> lista_pagos = tmpTpPago.ListaMesesPagar(Id_contrato, Num_meses);
                int p_Num_meses = 0; decimal p_Precio_unitario = 0; decimal p_Monto_total = 0; 
                tmpTpPago.DatosMesesPagar(ref lista_pagos, ref p_Num_meses, ref p_Monto_total, ref p_Precio_unitario);

                //Se obtienen los datos del cliente y la moneda
                int p_Id_cliente = tp_contrato.IdClientePorContrato(Id_contrato);
                string p_Codigo_moneda = tp_contrato.CodigoMoneda(Id_contrato);

                //Se registra el servicio
                int p_Id_transaccion = Insertar_ServicioVendido(Audit_id_usuario, Id_recibocobrador, tfp.dpr
                    , p_Id_cliente, Cliente_nombre, Cliente_nit, Cliente_guardar
                    , p_Num_meses, p_Precio_unitario, p_Monto_total, true, p_Codigo_moneda);

                if (p_Id_transaccion > 0)
                {
                    //forma_pago fp = tfp.FormaPagoTransaccion(p_Id_transaccion, p_Monto_total);
                    //if (fp.Insertar() == true)
                    if (new forma_pago(p_Id_transaccion, tfp).Insertar() == true)
                    {
                        //Se registran los pagos terraplus individuales
                        bool correcto = true;
                        foreach (tmpTpPago item in lista_pagos)
                        {
                            tp_pago pObj = new tp_pago(Id_contrato, p_Id_transaccion, item.monto, item.mes_pago);
                            if (pObj.Insertar(Audit_id_usuario, Audit_ip, Audit_host) == false) { correcto = false; }
                        }
                        if (correcto == true) { return p_Id_transaccion; }
                        else { return 0; }
                    }
                    else { return 0; }
                }
                else { return 0; }
            }

            private static int Insertar_ServicioVendido(
                int context_id_usuario, int Id_recibocobrador, bool Forma_dpr,
                int Id_cliente, string Cliente_nombre, decimal Cliente_nit, bool Cliente_guardar,
                int Num_unidades, decimal Precio_unidad, decimal Precio_total, bool Facturar, string Codigo_moneda
                )
            {
                try
                {
                    int Id_sucursal = sucursal.IdSucursalPorNum(int.Parse(ConfigurationManager.AppSettings["num_sucursal"]));
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_Insertar_ServicioVendido");
                    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                    db1.AddInParameter(cmd, "p_id_sucursal", DbType.Int32, Id_sucursal);
                    db1.AddInParameter(cmd, "p_id_usuario", DbType.Int32, context_id_usuario);
                    db1.AddInParameter(cmd, "p_id_recibocobrador", DbType.Int32, Id_recibocobrador);

                    db1.AddInParameter(cmd, "p_forma_dpr", DbType.Boolean, Forma_dpr);

                    //Para el cliente transitorios
                    db1.AddInParameter(cmd, "p_id_cliente", DbType.Int32, Id_cliente);

                    //Para la factura
                    db1.AddInParameter(cmd, "p_cliente_nombre", DbType.String, Cliente_nombre);
                    db1.AddInParameter(cmd, "p_cliente_nit", DbType.Decimal, Cliente_nit);
                    db1.AddInParameter(cmd, "p_cliente_guardar", DbType.Boolean, Cliente_guardar);

                    db1.AddInParameter(cmd, "p_num_unidades", DbType.Int32, Num_unidades);
                    db1.AddInParameter(cmd, "p_precio_unidad", DbType.Double, Precio_unidad);
                    db1.AddInParameter(cmd, "p_precio_total", DbType.Double, Precio_total);
                    db1.AddInParameter(cmd, "p_facturar", DbType.Boolean, Facturar);

                    db1.AddInParameter(cmd, "p_codigo_moneda", DbType.String, Codigo_moneda);

                    db1.AddOutParameter(cmd, "p_id_transaccion", DbType.Int32, 32);
                    db1.ExecuteNonQuery(cmd);
                    int Id_transaccion = (int)db1.GetParameterValue(cmd, "p_id_transaccion");
                    return Id_transaccion;
                }
                catch { return 0; }
            }
            #endregion

            #region Métodos para anulación de pagos
            public static bool Anular_ServicioVendido_y_PagosTerraPlus(int Id_serviciovendido, int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    bool correcto = Anular_ServicioTerraPlus(Id_serviciovendido, Audit_id_usuario);
                    if (correcto)
                    {
                        DataTable tabla_pagos_tp = ListaPorPagoServicio(Id_serviciovendido);
                        foreach (DataRow fila in tabla_pagos_tp.Rows)
                        {
                            if ((new tp_pago((int)fila["id_pago"])).Anular(Audit_id_usuario, Audit_ip, Audit_host) == false)
                            {
                                correcto = false;
                                //break;
                            }
                        }
                    }
                    return correcto;
                }
                catch { return false; }
            }

            private static bool Anular_ServicioTerraPlus(int Id_serviciovendido, int Audit_id_usuario)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_Anular_ServicioVendido");
                    db1.AddInParameter(cmd, "id_serviciovendido", DbType.Int32, Id_serviciovendido);
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion

            #region Métodos que requieren constructor
            private void RecuperarDatos()
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_RecuperarDatos");
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);

                    db1.AddOutParameter(cmd, "id_plan", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_serviciovendido", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_estadocontrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "monto", DbType.Double, 32);
                    db1.AddOutParameter(cmd, "mes_pago", DbType.DateTime, 32);
                    db1.AddOutParameter(cmd, "mes_restriccion", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 32);

                    db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                    db1.AddOutParameter(cmd, "id_transaccion", DbType.Int32, 32);

                    db1.ExecuteNonQuery(cmd);

                    _id_plan = (int)db1.GetParameterValue(cmd, "id_plan");
                    _id_serviciovendido = (int)db1.GetParameterValue(cmd, "id_serviciovendido");
                    _id_estadocontrato = (int)db1.GetParameterValue(cmd, "id_estadocontrato");
                    _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                    _monto = (decimal)(double)db1.GetParameterValue(cmd, "monto");
                    _mes_pago = (DateTime)db1.GetParameterValue(cmd, "mes_pago");
                    _mes_restriccion = (int)db1.GetParameterValue(cmd, "mes_restriccion");
                    _anulado = (bool)db1.GetParameterValue(cmd, "anulado");

                    _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                    _id_transaccion = (int)db1.GetParameterValue(cmd, "id_transaccion");
                }
                catch { }
            }

            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_Insertar");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);
                    db1.AddInParameter(cmd, "mes_pago", DbType.DateTime, _mes_pago);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    _id_pago = (int)db1.ExecuteScalar(cmd);
                    if (_id_pago > 0) { return true; } else { return false; }
                }
                catch { return false; }
            }

            public bool Anular(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("tp_pago_Anular");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, _id_pago);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    if ((int)db1.ExecuteScalar(cmd) > 0) { return true; } 
                    else { return false; }
                }
                catch { return false; }
            }


            #endregion

        }

        public class tmpTpPago
        {
            #region Propiedades
            //Propiedades privadas
            private DateTime _fecha = DateTime.Now;
            private decimal _monto = 0;
            private DateTime _mes_pago = DateTime.Now;
            /*private int _mes_restriccion = 0;*/

            //Propiedades públicas
            public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            public DateTime mes_pago { get { return _mes_pago; } set { _mes_pago = value; } }
            /*public int mes_restriccion { get { return _mes_restriccion; } set { _mes_restriccion = value; } }*/
            #endregion

            #region Constructores
            public tmpTpPago(DateTime Fecha, decimal Monto, DateTime Mes_pago/*, int Mes_restriccion*/)
            {
                _fecha = Fecha;
                _monto = Monto;
                _mes_pago = Mes_pago;
                //_mes_restriccion = Mes_restriccion;
            }

            #endregion

            #region Métodos que NO requieren constructor

            public static DataTable TablaMesesPagar(int Id_contrato, int Num_meses)
            {
                //[id_mes],[fecha],[monto],[mes_pago],[mes_pago_string]
                List<tmpTpPago> lista = ListaMesesPagar(Id_contrato, Num_meses);
                DataTable tabla = new DataTable();
                tabla.Columns.Add("id_mes", typeof(int));
                tabla.Columns.Add("fecha", typeof(DateTime));
                tabla.Columns.Add("monto", typeof(decimal));
                tabla.Columns.Add("mes_pago", typeof(DateTime));
                tabla.Columns.Add("mes_pago_string", typeof(string));

                int Id_mes = 1;
                foreach (tmpTpPago i in lista)
                {
                    DataRow fila = tabla.NewRow();
                    fila["id_mes"] = Id_mes;
                    fila["fecha"] = i.fecha;
                    fila["monto"] = i.monto;
                    fila["mes_pago"] = i.mes_pago;
                    fila["mes_pago_string"] = tp_pago.StringMes(i.mes_pago);
                    tabla.Rows.Add(fila);

                    Id_mes = Id_mes + 1;
                }
                return tabla;
            }

            public static List<tmpTpPago> ListaMesesPagar(int Id_contrato, int Num_meses)
            {
                //Se obtiene el plan TerraPlus actual
                tp_plan ppObj = new tp_plan(tp_plan.Actual(Id_contrato));

                //Se determina el mes desde el cual se cobrará
                DateTime mes_pago;
                int Id_ultimo_pago = terrasur.terraplus.tp_pago.Id_ultimo(Id_contrato);
                if (Id_ultimo_pago > 0)
                {
                    mes_pago = (new tp_pago(Id_ultimo_pago)).mes_pago;

                    if (((mes_pago.Year * 100) + mes_pago.Month) >= ((DateTime.Now.Date.Year * 100) + DateTime.Now.Date.Month))
                    { mes_pago = mes_pago.AddMonths(1); }
                    else { mes_pago = DateTime.Now.Date.AddDays((DateTime.Now.Date.Day - 1) * (-1)); }
                }
                else
                {
                    mes_pago = (new tp_plan(tp_plan.Actual(Id_contrato))).mes_inicio;

                    if (((mes_pago.Year * 100) + mes_pago.Month) < ((DateTime.Now.Date.Year * 100) + DateTime.Now.Date.Month))
                    { mes_pago = DateTime.Now.Date.AddDays((DateTime.Now.Date.Day - 1) * (-1)); }
                }

                //Se generan los ítems
                List<tmpTpPago> lista_pagos = new List<tmpTpPago>();
                for (int j = 0; j < Num_meses; j++)
                {
                    lista_pagos.Add(new tmpTpPago(DateTime.Now.Date, ppObj.monto, mes_pago));
                    mes_pago = mes_pago.AddMonths(1);
                }

                return lista_pagos;
            }

            public static decimal MontoMesesPagar(int Id_contrato, int Num_meses)
            {
                decimal Monto = 0;
                List<tmpTpPago> lista = ListaMesesPagar(Id_contrato, Num_meses);
                foreach (tmpTpPago item in lista) { Monto += item.monto; }
                return Monto;
            }

            public static void DatosMesesPagar(ref List<tmpTpPago> lista, ref int Num_meses, ref decimal Monto_total, ref decimal Precio_unitario)
            {
                //List<tmpTpPago> lista = ListaMesesPagar(Id_contrato, Num_meses);
                Num_meses = lista.Count;
                if (Num_meses > 0)
                {
                    decimal _Monto_total = 0;
                    foreach (tmpTpPago item in lista) { _Monto_total += item.monto; }
                    Monto_total = _Monto_total;
                    Precio_unitario = lista[0].monto;
                }
                else
                {
                    Monto_total = 0;
                    Precio_unitario = 0;
                }
            }

            #endregion
        }
    }
}