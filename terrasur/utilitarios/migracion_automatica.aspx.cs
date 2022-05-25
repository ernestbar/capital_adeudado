using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using terrasur;

public partial class modulo_consultas_migracion_automatica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string fecha = DateTime.Now.AddDays(-1).ToShortDateString();

            odoo_control_migracion odoo_control = new odoo_control_migracion(DateTime.Parse(fecha));

            /////////////////VERIFICA QUE NO SE HAGA MIGRADO LAS TRANSACCIONES A ODOO ANTERIORMENTE//////////////////
            if (odoo_control.id_control == 0)
            {
                string lblFin = "";
                string lblTotal = "0";
                string lblInicio = DateTime.Now.ToString();
                string lblTransInvalid = "";
                //string fecha = DateTime.Now.AddDays(-1).ToShortDateString();
                DateTime fecha1 = DateTime.Parse(fecha);
                DataTable dt = new DataTable();

                dt = cajaReporte.ReporteIngresos(0, 0, 0, fecha1, fecha1, ",3,", 2, true);
                //dt = cajaReporte.ReporteIngresos(0, 0, 0, DateTime.Parse("01/11/2019"), DateTime.Parse("17/11/2019"), ",3,", 2, true);

                lblTotal = dt.Rows.Count.ToString();
                int i = 0;

                int errores = 0;
                int validos = 0;
                DateTime fecha_hora = DateTime.Now;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool esDpr = false;
                        bool efectivo = true;

                        //////////////////datos generales/////////////////////////
                        string dato = dr["total_dpr"].ToString().Replace(",", ".");
                        fecha_hora = DateTime.Parse(dr["fecha_pago"].ToString());
                        string id_urbanizacion = "";
                        string nombre_urbanizacion = "";
                        string nombre_corto = "";
                        string numero_contrato = "";

                        decimal monto_pago = 0;
                        decimal monto_interes = 0;
                        decimal monto_capital = 0;


                        decimal costo_lote = 0;
                        decimal costo_lote_bs = 0;
                        decimal porcentaje_bs = 0;
                        decimal precio_final_bs = 0;
                        decimal costo_pagado_bs = 0;

                        monto_pago = Math.Round(decimal.Parse(dr["monto_pago"].ToString().Replace(".", ",")), 2);
                        monto_interes = Math.Round(decimal.Parse(dr["interes"].ToString().Replace(".", ",")), 2);
                        monto_capital = Math.Round(decimal.Parse(dr["amortizacion"].ToString().Replace(".", ",")), 2);

                        decimal saldo_costo = 0;
                        if (dr["contrato_numero"].ToString().Trim() == "Sin contrato")
                        {
                            numero_contrato = "0";
                            id_urbanizacion = "1000";
                            nombre_urbanizacion = "NO CLIENTE";
                            nombre_corto = "";
                        }
                        else
                        {

                            numero_contrato = dr["contrato_numero"].ToString().Trim();
                            contrato_venta objcv = new contrato_venta(dr["contrato_numero"].ToString());
                            lote lot = new lote(objcv.id_lote);
                            urbanizacion urb = new urbanizacion(lot.id_urbanizacion);
                            negocio_contrato neg = new negocio_contrato(objcv.id_negociocontrato);
                            saldo_costo = Math.Round(neg.saldo_costo, 2);
                            id_urbanizacion = lot.id_urbanizacion.ToString();
                            nombre_urbanizacion = urb.nombre.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",", "");
                            nombre_corto = urb.nombre_corto.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",", "");
                            costo_lote = Math.Round(objcv.superficie_m2 * objcv.costo_m2_sus, 2);
                            costo_lote_bs = Math.Round(costo_lote * decimal.Parse(dr["tipo_cambio"].ToString()), 2);
                            if (dr["codigo_moneda"].ToString().Trim() == "$us")
                            { precio_final_bs = Math.Round(objcv.precio_final * decimal.Parse(dr["tipo_cambio"].ToString()), 2); }
                            else
                            { precio_final_bs = Math.Round(objcv.precio_final, 2); }

                            porcentaje_bs = decimal.Parse(monto_capital.ToString()) / precio_final_bs;
                            costo_pagado_bs = Math.Round(costo_lote_bs * porcentaje_bs, 2);
                        }

                        string id_transaccion = dr["id_transaccion"].ToString();

                        ////////////////////FIN DATOS GENERALES/////////////////////

                        if (decimal.Parse(dr["total_dpr"].ToString()) > 0)
                        {
                            esDpr = true;
                            efectivo = false;
                        }
                        /////////////////CUOTAS INICIALES///////////////////////////
                        if (dr["tipo_pago"].ToString().Trim() == "Cuota inicial")
                        {
                            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();

                            string tipo_pago = "";
                            if (esDpr == true)
                            { tipo_pago = "CUOTA INICIAL DPR"; }
                            else
                            { tipo_pago = "CUOTA INICIAL EFECTIVO"; }

                            string resultado = "";
                            string resultado2 = "";
                            string resultado3 = "";
                            string resultado4 = "";


                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                                monto_pago, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);


                            ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                            resultado2 = obj2.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, "VENTA DE LOTES EFECTIVO Y DPR",
                                0, true, 0, true, 0, true, 0, true, precio_final_bs, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);


                            ServiceReference1.SintesisService obj3 = new ServiceReference1.SintesisService();
                            resultado3 = obj3.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);

                            ServiceReference1.SintesisService obj4 = new ServiceReference1.SintesisService();
                            resultado4 = obj4.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, "INVENTARIO VENTA DE LOTES",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), costo_lote_bs, true, 0, true, 0, true);


                            if (resultado.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            {
                                if (resultado2.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + ") ";
                                }
                                else
                                {
                                    if (resultado3.Contains("error"))
                                    {
                                        errores++;
                                        lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + " - COSTO) ";
                                    }
                                    else
                                        if (resultado4.Contains("error"))
                                    {
                                        errores++;
                                        lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + " - COSTO) ";
                                    }
                                    else
                                    {
                                        validos++;
                                    }

                                }
                            }

                        }
                        /////////////////FIN CUOTAS INICIALES///////////////////////////
                        ///////////////////PAGO NORMAL///////////////////////////
                        if (dr["tipo_pago"].ToString().Trim() == "Pago normal")
                        {
                            string tipo_pago = "";
                            if (esDpr == true)
                            { tipo_pago = "CUOTA NORMAL DPR"; }
                            else
                            { tipo_pago = "CUOTA NORMAL EFECTIVO"; }
                            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;

                            string resultado = "";
                            string resultado2 = "";


                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                            0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                            nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);

                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);


                            if (resultado.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            {
                                if (resultado2.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + " - COSTO) ";
                                }
                                else
                                { validos++; }
                            }
                        }
                        /////////////////FIN PAGO NORMAL///////////////////////////
                        ///////////////////PAGO ADELANTADO///////////////////////////
                        if (dr["tipo_pago"].ToString().Trim() == "Pago adelantado")
                        {
                            string tipo_pago = "";
                            if (esDpr == true)
                            { tipo_pago = "CUOTA NORMAL DPR"; }
                            else
                            { tipo_pago = "CUOTA NORMAL EFECTIVO"; }
                            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                            string resultado = "";
                            string resultado2 = "";


                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                            0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                            nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);



                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);

                            if (resultado.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            {
                                if (resultado2.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + " - COSTO) ";
                                }
                                else
                                { validos++; }
                            }
                        }
                        ///////////////////FIN PAGO ADELANTADO///////////////////////////
                        ///////////////////PAGO SEGUN PLAN///////////////////////////
                        if (dr["tipo_pago"].ToString().Trim() == "Pago según plan")
                        {
                            string tipo_pago = "";
                            if (esDpr == true)
                            { tipo_pago = "CUOTA NORMAL DPR"; }
                            else
                            { tipo_pago = "CUOTA NORMAL EFECTIVO"; }
                            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                            string resultado = "";
                            string resultado2 = "";


                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                                0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);

                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);

                            if (resultado.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            {
                                if (resultado2.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + " - COSTO) ";
                                }
                                else
                                { validos++; }
                            }
                        }
                        ///////////////////FIN PAGO SEGUN PLAN///////////////////////////
                        ///////////////////PAGO DIRECTO A CAPITAL///////////////////////////
                        if (dr["tipo_pago"].ToString().Trim() == "Pago directo a capital")
                        {
                            string tipo_pago = "";
                            if (esDpr == true)
                            { tipo_pago = "CUOTA NORMAL DPR"; }
                            else
                            { tipo_pago = "CUOTA NORMAL EFECTIVO"; }
                            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;

                            string resultado = "";
                            string resultado2 = "";


                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                                0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);

                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);

                            if (resultado.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            {
                                if (resultado2.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_pago + " - COSTO) ";
                                }
                                else
                                { validos++; }
                            }
                        }
                        /////////////////// FIN PAGO DIRECTO A CAPITAL///////////////////////////
                        ///////////////////PAGO OTROS SERVICIOS///////////////////////////
                        if (dr["tipo_pago"].ToString().Trim() == "Otro Serv.")
                        {
                            bool Facturar = true;
                            if (dr["num_factura"].ToString() == "")
                            {
                                Facturar = false;
                            }

                            decimal otro_serv_facturado = 0;
                            decimal otro_serv_sin_factura = 0;
                            string tipo_operacion = "";
                            if (esDpr == true)
                            {

                                if (Facturar == true)
                                {
                                    tipo_operacion = "OTROS SERVICIOS FACTURADOS DPR";
                                    otro_serv_facturado = monto_pago;
                                }
                                else
                                {
                                    tipo_operacion = "OTROS SERVICIOS NO FACTURADOS DPR";
                                    otro_serv_sin_factura = monto_pago;
                                }
                            }
                            else
                            {
                                if (Facturar == true)
                                {
                                    tipo_operacion = "OTROS SERVICIOS FACTURADOS EFECTIVO";
                                    otro_serv_facturado = monto_pago;
                                }
                                else
                                {
                                    tipo_operacion = "OTROS SERVICIOS NO FACTURADOS EFECTIVO";
                                    otro_serv_sin_factura = monto_pago;
                                }
                            }
                            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                            //contrato_venta ob_cv = new contrato_venta(dr["contrato_numero"].ToString());
                            //lote lot = new lote(ob_cv.id_lote);
                            //negocio_contrato neg = new negocio_contrato(ob_cv.id_negociocontrato);
                            string resultado = "";


                            ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                            resultado = obj2.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_operacion, 0,
                                true, 0, true, 0, true, 0, true, 0, true, 0, true, otro_serv_facturado, true, otro_serv_sin_factura, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, dr["servicio_codigo"].ToString(), false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);

                            if (resultado.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid = lblTransInvalid + "," + id_transaccion + "(" + tipo_operacion + ") ";
                            }
                            else
                            { validos++; }
                        }

                        i++;
                    }
                    lblFin = DateTime.Now.ToString();
                    string mensaje_correo = "";
                    mensaje_correo = "TOTAL TRANSACCIONES: " + lblTotal + "\n\r" +
                        "MIGRACIONES VALIDAS: " + validos.ToString() + "\n\r" +
                        "MIGRACIONES INVALIDAS: " + errores.ToString() + "\n\r" +
                        "TRANSACCIONES INVALIDAS: " + lblTransInvalid + "\n\r" +
                        "INICIO MIGRACION: " + lblInicio + "\n\r" +
                        "TERMINO MIGRACION: " + lblFin + "\n\r";


                    correo.EnviarCorreo(mensaje_correo, "ebarron@terrasur.com.bo|evaldez@terrasur.com.bo");
                    lblAviso.Text = "LA MIGRACION SE REALIZO CORRECTAMENTE! REVISE LOS LOGS EN CASO DE ERROR. VALIDAS: " + validos.ToString() + " INVALIDAS: " + errores.ToString();
                }
                else
                { lblAviso.Text = "NO EXISTEN REGISTROS PARA MIGRAR"; }

                migrarRevertidos();

                odoo_control_migracion reg_control_odoo = new odoo_control_migracion(fecha1, true);
                reg_control_odoo.Insertar(1);
                
            }
            else
            {
                lblAviso.Text = "YA SE REALIZO UNA MIGRACION MASIVA DE LA FECHA: " + fecha;
            }

        }
       
    }

    public void migrarRevertidos()
    {
        string fechaT = DateTime.Now.AddDays(-1).ToShortDateString();
        DateTime fecha1 = DateTime.Parse(fechaT);
      
        DataTable dt = new DataTable();
        dt = contratoReporte.ReporteReversion(fecha1, fecha1, ",3,", 2, true, DateTime.Parse("01/01/1900"), DateTime.Parse("01/01/5900"));
        
        string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
     
        foreach (DataRow dr in dt.Rows)
        {
            int id_contrato = int.Parse(dr["id_contrato"].ToString());
            int id_reversion = int.Parse(dr["id_reversion"].ToString());
            int id_usuario = int.Parse(dr["id_usuario"].ToString());
            int id_urbanizacion = int.Parse(dr["id_urbanizacion"].ToString());
            int id_lote = int.Parse(dr["id_lote"].ToString());
            string numero = dr["contrato_numero"].ToString();
            string usuario = dr["usuario"].ToString();
            string nombre_urbanizacion = dr["sector_nombre"].ToString().Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ");
            decimal cap_adeuda = Math.Round(decimal.Parse(dr["capital_deudor"].ToString()));
            DateTime fecha = DateTime.Parse(dr["fecha_reversion"].ToString());
            string resultado = "";
            string resultado2 = "";

            //////////////REVIERTE TODAS LAS REVERSIONES DE LAS FECHAS ELEGIDAS///////////////////

            if (cap_adeuda > 0)
            {
                ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                resultado = obj2.insertarMovimientosOdoo(3, true, numero, "", id_reversion.ToString(), 0, true, "REVERSIONES",
                    0, true, 0, true, 0, true, 0, true, 0, true, cap_adeuda, true, 0, true, 0, true, id_urbanizacion.ToString(),
                    "", "", true, true, nombre_urbanizacion, "", false, true, id_usuario,
                    true, ip, fecha.ToShortDateString(), 0, true, 0, true, 0, true);
            }
               
           

            
                //////////////INVENTARIOS////////////////
                lote lot = new lote(id_lote);
                contrato ob_con = new contrato(id_contrato);
                negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                contrato_venta ob_cv = new contrato_venta(id_contrato);
                tipo_cambio tc = new tipo_cambio(DateTime.Now);
                decimal costo_lote = Math.Round(ob_cv.superficie_m2 * ob_cv.costo_m2_sus, 2);
                decimal porcentaje = ob_cv.capital_pagado / ob_con.precio_final;
                decimal costo_pagado = costo_lote * porcentaje;
                decimal saldo_costo = costo_lote - costo_pagado;

                decimal costo_lote_bs = 0;
                decimal costo_pagado_bs = 0;
                decimal saldo_costo_bs = 0;


                costo_lote_bs = Math.Round(costo_lote * tc.compra, 2);
                costo_pagado_bs = Math.Round(costo_pagado * tc.compra, 2);
                saldo_costo_bs = Math.Round(saldo_costo * tc.compra, 2);

                
                ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                resultado2 = obj.insertarMovimientosOdoo(3, true, numero.ToString(), "", id_reversion.ToString(), 0, true, "INVENTARIO REVERSIONES",
                   0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(),
                   "", "", true, true, nombre_urbanizacion, "", false, true, id_usuario,
                   true, ip, fecha.ToShortDateString(), costo_lote_bs, true, costo_pagado_bs, true, saldo_costo_bs, true);
        }
      
    }

}